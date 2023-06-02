LIBRARY IEEE;
USE IEEE.STD_LOGIC_1164.ALL;
USE IEEE.STD_LOGIC_ARITH.ALL;
USE IEEE.STD_LOGIC_UNSIGNED.ALL;

ENTITY test_env IS
	PORT (
		clk : IN STD_LOGIC;
		btn : IN STD_LOGIC_VECTOR (4 DOWNTO 0);
		sw : IN STD_LOGIC_VECTOR (15 DOWNTO 0);
		led : OUT STD_LOGIC_VECTOR (15 DOWNTO 0);
		an : OUT STD_LOGIC_VECTOR (3 DOWNTO 0);
		cat : OUT STD_LOGIC_VECTOR (6 DOWNTO 0)
	);
END test_env;

ARCHITECTURE MIPS OF test_env IS

	COMPONENT MPG IS
		PORT (
			clk : IN STD_LOGIC;
			input : IN STD_LOGIC;
			en : OUT STD_LOGIC
		);
	END COMPONENT;

	COMPONENT IFetch IS
		PORT (
			clk : IN std_logic;
			rst : IN std_logic;
			en : IN std_logic;
			BranchAddress : IN STD_LOGIC_VECTOR(15 DOWNTO 0);
			JumpAddress : IN STD_LOGIC_VECTOR(15 DOWNTO 0);
			Jump : IN STD_LOGIC;
			PCSrc : IN STD_LOGIC;
			Instr : OUT std_logic_vector(15 DOWNTO 0);
			PCInc : OUT std_logic_vector(15 DOWNTO 0)
		);
	END COMPONENT;

	COMPONENT SSD IS
		PORT (
			clk : IN STD_LOGIC;
			digits : IN STD_LOGIC_VECTOR(15 DOWNTO 0);
			an : OUT STD_LOGIC_VECTOR(3 DOWNTO 0);
			cat : OUT STD_LOGIC_VECTOR(6 DOWNTO 0)
		);
	END COMPONENT;

	COMPONENT IDecode IS
		PORT (
			clk : IN std_logic;
			en : IN std_logic;
			Instr : IN STD_LOGIC_VECTOR(12 DOWNTO 0);
			WD : IN STD_LOGIC_VECTOR(15 DOWNTO 0);
			RegWrite : IN std_logic;
			RegDst : IN Std_logic;
			ExtOp : IN std_logic;
			RD1 : OUT STD_LOGIC_VECTOR(15 DOWNTO 0);
			RD2 : OUT STD_LOGIC_VECTOR(15 DOWNTO 0);
			Ext_imm : OUT STD_LOGIC_VECTOR(15 DOWNTO 0);
			func : OUT STD_LOGIC_VECTOR(2 DOWNTO 0);
			sa : OUT std_logic
		);
	END COMPONENT;

	COMPONENT MainControl IS
		PORT (
			Instr : IN STD_LOGIC_VECTOR(2 DOWNTO 0);
			RegDst : OUT std_logic;
			ExtOp : OUT std_logic;
			ALUSrc : OUT std_logic;
			Branch : OUT std_logic;
			Jump : OUT std_logic;
			ALUOp : OUT std_logic_vector(2 DOWNTO 0);
			MemWrite : OUT std_logic;
			MemToReg : OUT std_logic;
			RegWrite : OUT std_logic;
			BNE: out STD_LOGIC
		);
	END COMPONENT;

	COMPONENT ExecutionUnit IS
		PORT (
			PCInc : IN std_logic_vector(15 DOWNTO 0);
			RD1 : IN STD_LOGIC_VECTOR(15 DOWNTO 0);
			RD2 : IN STD_LOGIC_VECTOR(15 DOWNTO 0);
			Ext_imm : IN STD_LOGIC_VECTOR(15 DOWNTO 0);
			func : IN STD_LOGIC_VECTOR(2 DOWNTO 0);
			sa : IN std_logic;
			ALUSrc : IN std_logic;
			ALUOp : IN std_logic_vector(2 DOWNTO 0);
			BranchAddress : OUT std_logic_vector(15 DOWNTO 0);
			ALURes : OUT std_logic_vector(15 DOWNTO 0);
			Zero : OUT std_logic
		);
	END COMPONENT;

	COMPONENT DataMemory IS

		PORT (
			clk : IN STD_LOGIC;
			en : IN std_logic;
			ALUResIn : IN STD_LOGIC_vector(15 DOWNTO 0);
			RD2 : IN std_logic_vector(15 DOWNTO 0);
			MemWrite : IN std_logic;
			MemData : OUT std_logic_vector(15 DOWNTO 0);
			ALUResOut : OUT std_logic_vector(15 DOWNTO 0)
		);

	END COMPONENT;

	SIGNAL Instr, PCInc, sum, RD1, RD2, Ext_imm : STD_LOGIC_VECTOR(15 DOWNTO 0) := (OTHERS => '0');
	SIGNAL BranchAddress, JumpAddress, ALURes, ALURes1, MemData : STD_LOGIC_VECTOR(15 DOWNTO 0) := (OTHERS => '0');
	SIGNAL digits : STD_LOGIC_VECTOR(15 DOWNTO 0) := (OTHERS => '0');
	SIGNAL func : std_logic_vector(2 DOWNTO 0) := (OTHERS => '0');
	SIGNAL sa, en, rst, PCSrc, Zero : std_logic := '0';
	SIGNAL RegDst, ExtOp, ALUSrc, Branch, Jump, MemWrite, MemToReg, RegWrite, BNE : STD_LOGIC := '0';
	SIGNAL ALUOp : STD_LOGIC_VECTOR(2 DOWNTO 0) := (OTHERS => '0');
	SIGNAL WD : std_logic_vector(15 DOWNTO 0);
	SIGNAL BEQ, BranchCtrl: STD_LOGIC := '0'; --beq sau bne

BEGIN
	A : MPG
	PORT MAP(clk, btn(0), en);
	B : MPG
	PORT MAP(clk, btn(1), rst);

	I : IFetch
	PORT MAP(clk, rst, en, BranchAddress, JumpAddress, Jump, PCSrc, Instr, PCInc);
D : IDecode
PORT MAP(clk, en, Instr(12 DOWNTO 0), WD, RegWrite, RegDst, ExtOp, RD1, RD2, Ext_imm, func, sa);
MC : MainControl
PORT MAP(Instr(15 DOWNTO 13), RegDst, ExtOp, ALUSrc, Branch, Jump, ALUOp, MemWrite, MemToReg, RegWrite, BNE);
EU : ExecutionUnit
PORT MAP(PCInc, RD1, RD2, Ext_imm, func, sa, ALUSrc, ALUOp, BranchAddress, ALURes, Zero);
DM : DataMemory
PORT MAP(clk, en, ALURes, RD2, MemWrite, MemData, ALURes1);

WITH MemToReg SELECT --WriteBack
WD <= MemData WHEN '1', 
      ALURes1 WHEN '0', 
      (OTHERS => 'X') WHEN OTHERS;
      
BEQ <= Zero AND Branch;
BranchCtrl <= BNE AND (not(Zero));
PCSrc <= BEQ OR BranchCtrl;

JumpAddress <= PCInc(15 DOWNTO 13) & Instr(12 DOWNTO 0);

WITH sw(7 DOWNTO 5) SELECT
digits <= Instr WHEN "000", 
          PCInc WHEN "001", 
          RD1 WHEN "010", 
          RD2 WHEN "011", 
          Ext_imm WHEN "100", 
          ALURes WHEN "101", 
          MemData WHEN "110", 
          WD WHEN "111", 
          (OTHERS => 'X') WHEN OTHERS;

disp : SSD
PORT MAP(clk, digits, an, cat);

led(10 DOWNTO 0) <= ALUOp & RegDst & ExtOp & ALUSrc & Branch & Jump & MemWrite & MemToReg & RegWrite;
END MIPS;