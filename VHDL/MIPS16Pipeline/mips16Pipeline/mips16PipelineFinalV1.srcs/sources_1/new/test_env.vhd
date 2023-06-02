library IEEE;
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

	COMPONENT IDecode IS
		PORT (
		clk : IN std_logic;
        en : IN std_logic;
        Instr : IN STD_LOGIC_VECTOR(12 DOWNTO 0);
        WD : IN STD_LOGIC_VECTOR(15 DOWNTO 0);
        RegWrite : IN std_logic;
        WriteAddress : IN Std_logic_vector( 2 downto 0);
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
	    Instr97: in std_logic_vector(2 downto 0);
        Instr64: in std_logic_vector(2 downto 0);
        PCInc : IN std_logic_vector(15 DOWNTO 0);
        RD1 : IN STD_LOGIC_VECTOR(15 DOWNTO 0);
        RD2 : IN STD_LOGIC_VECTOR(15 DOWNTO 0);
        Ext_imm : IN STD_LOGIC_VECTOR(15 DOWNTO 0);
        func : IN STD_LOGIC_VECTOR(2 DOWNTO 0);
        sa : IN std_logic;
        ALUSrc : IN std_logic;
        ALUOp : IN std_logic_vector(2 DOWNTO 0);
        RegDst: in std_logic;
        BranchAddress : OUT std_logic_vector(15 DOWNTO 0);
        ALURes : OUT std_logic_vector(15 DOWNTO 0);
        Zero : OUT std_logic;
        WriteAddress: out std_logic_vector(2 downto 0)
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
	
	COMPONENT SSD IS
        PORT (
            clk : IN STD_LOGIC;
            digits : IN STD_LOGIC_VECTOR(15 DOWNTO 0);
            an : OUT STD_LOGIC_VECTOR(3 DOWNTO 0);
            cat : OUT STD_LOGIC_VECTOR(6 DOWNTO 0)
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
	
	Signal WriteAddress : std_logic_vector(2 downto 0);
	
	COMPONENT IF_ID_Reg is
	  Port ( clk: in std_logic;
    rst: in std_logic;
    input: in std_logic_vector(31 downto 0);
    output: out std_logic_vector(31 downto 0));
	end component;
	
	COMPONENT ID_EX_Reg is
      Port ( clk: in std_logic;
    rst: in std_logic;
    input: in std_logic_vector(83 downto 0);
    output: out std_logic_vector(83 downto 0));
    end component;
    
	COMPONENT EX_MEM_Reg is
  Port ( clk: in std_logic;
     rst: in std_logic;
  input: in std_logic_vector(56 downto 0);
   output: out std_logic_vector(56 downto 0));
end component;

	COMPONENT MEM_WB_Reg is
  Port ( clk: in std_logic;
     rst: in std_logic;
  input: in std_logic_vector(36 downto 0);
   output: out std_logic_vector(36 downto 0));
end component;
	
	SIGNAL IFID_in, IFID_out : std_logic_vector(31 downto 0):= (OTHERS => '0');
	SIGNAL IDEX_in, IDEX_out : std_logic_vector(83 downto 0) := (OTHERS => '0');
	SIGNAL EXMEM_in, EXMEM_out : std_logic_vector(56 downto 0) := (OTHERS => '0');
	SIGNAL MEMWB_in, MEMWB_out : std_logic_vector(36 downto 0) := (OTHERS => '0');

BEGIN
	A : MPG
	PORT MAP(clk, btn(0), en);
	B : MPG
	PORT MAP(clk, btn(1), rst);

	I : IFetch
	PORT MAP(clk, rst, en, EXMEM_out(15 downto 0), JumpAddress, Jump, PCSrc, Instr, PCInc);
	
	IFID_in(15 downto 0) <= Instr;
	IFID_in(31 downto 16) <= PCInc;
	IF_ID: IF_ID_Reg 
	PORT MAP(clk, rst, IFID_in, IFID_out);
	
D : IDecode
PORT MAP(clk, en, IFID_out(12 DOWNTO 0), WD, MEMWB_out(35), MEMWB_out(34 downto 32), 
ExtOp, RD1, RD2, Ext_imm, func, sa);

MC : MainControl
PORT MAP(IFID_out(15 DOWNTO 13), RegDst, ExtOp, ALUSrc, Branch, Jump, ALUOp, MemWrite, MemToReg, RegWrite, BNE);


    IDEX_in(15 downto 0) <= IFID_out(31 downto 16); --PCInc
    IDEX_in(31 downto 16) <= RD1;
    IDEX_in(47 downto 32) <= RD2;
    IDEX_in(63 downto 48) <= Ext_imm;
    IDEX_in(66 downto 64) <= func;
    IDEX_in(69 downto 67) <= IFID_out(9 downto 7); -- Instr
    IDEX_in(72 downto 70) <= IFID_out(6 downto 4); -- Instr
    
    IDEX_in(73) <= MemToReg;
    IDEX_in(74) <= RegWrite;
    IDEX_in(75) <= MemWrite;
    IDEX_in(76) <= Branch;
    IDEX_in(77) <= BNE;
    IDEX_in(80 downto 78) <= ALUOp;
    IDEX_in(81) <= ALUSrc;
    IDEX_in(82) <= RegDst;
    IDEX_in(83) <= sa;
    
    ID_EX: ID_EX_Reg
    PORT MAP(clk, rst, IDEX_in, IDEX_out);

EU : ExecutionUnit
PORT MAP(IDEX_out(69 downto 67), IDEX_out(72 downto 70), IDEX_out(15 downto 0), IDEX_out(31 downto 16), 
IDEX_out(47 downto 32), IDEX_out(63 downto 48), IDEX_out(66 downto 64), IDEX_out(83), IDEX_out(81), 
IDEX_out(80 downto 78), IDEX_out(82), BranchAddress, ALURes, Zero, WriteAddress);

EXMEM_in(15 downto 0) <= BranchAddress;
EXMEM_in(31 downto 16) <= ALURes;
EXMEM_in(47 downto 32) <= IDEX_out(47 downto 32); --RD2
EXMEM_in(50 downto 48) <= WriteAddress;
EXMEM_in(51) <= Zero;
EXMEM_in(52) <= IDEX_out(73); --MemToReg
EXMEM_in(53) <= IDEX_out(74); --RegWrite
EXMEM_in(54) <= IDEX_out(75); --MemWrite
EXMEM_in(55) <= IDEX_out(76); --Branch
EXMEM_in(56) <= IDEX_out(77); --BNE

EX_MEM: EX_MEM_Reg
PORT MAP(clk, rst, EXMEM_in, EXMEM_out);

DM : DataMemory
PORT MAP(clk, en, EXMEM_out(31 downto 16), EXMEM_out(47 downto 32), EXMEM_out(54), MemData, ALURes1);


MEMWB_in(15 downto 0) <= MemData;
MEMWB_in(31 downto 16) <= ALURes1;
MEMWB_in(34 downto 32) <= EXMEM_out(50 downto 48); --WriteAddress Final
MEMWB_in(35) <= EXMEM_out(53); -- RegWrite
MEMWB_in(36) <= EXMEM_out(52); --MemToReg

MEMWB: MEM_WB_Reg
PORT MAP(clk, en, MEMWB_in, MEMWB_out);


WITH MEMWB_out(36) SELECT --WriteBack
WD <= MEMWB_out(15 downto 0) WHEN '1', 
      MEMWB_out(31 downto 16) WHEN '0', 
      (OTHERS => 'X') WHEN OTHERS;
      
BEQ <= EXMEM_out(51) AND EXMEM_out(55);
BranchCtrl <= EXMEM_out(56) AND (not(EXMEM_out(51)));
PCSrc <= BEQ OR BranchCtrl;

JumpAddress <= IFID_out(31 DOWNTO 29) & IFID_out(12 DOWNTO 0);

WITH sw(7 DOWNTO 5) SELECT
digits <= Instr WHEN "000", 
          PCInc WHEN "001", 
          RD1 WHEN "010", 
          RD2 WHEN "011", 
          Ext_imm WHEN "100", 
          EXMEM_out(31 downto 16) WHEN "101", 
          MemData WHEN "110", 
          WD WHEN "111", 
          (OTHERS => 'X') WHEN OTHERS;

disp : SSD
PORT MAP(clk, digits, an, cat);

--led(10 DOWNTO 0) <= ALUOp & RegDst & ExtOp & ALUSrc & Branch & Jump & MemWrite & MemToReg & RegWrite;

END MIPS;