LIBRARY IEEE;
USE IEEE.STD_LOGIC_1164.ALL;
USE IEEE.STD_LOGIC_ARITH.ALL;
USE IEEE.STD_LOGIC_UNSIGNED.ALL;

ENTITY IDecode IS

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
	
END IDecode;

ARCHITECTURE Behavioral OF IDecode IS

	TYPE reg_array IS ARRAY (0 TO 7) OF std_logic_vector(15 DOWNTO 0);
	SIGNAL reg_file : reg_array := (OTHERS => X"0000");
	SIGNAL WriteAddress : STD_LOGIC_VECTOR(2 DOWNTO 0) := (OTHERS => '0');

BEGIN

 with RegDst select
                 WriteAddress <= Instr(6 downto 4) when '1',
                 Instr(9 downto 7) when '0',
                 (others => '0') when others;

	PROCESS (clk)
		BEGIN
			IF rising_edge(clk) THEN
				IF en = '1' AND RegWrite = '1' THEN
					reg_file(conv_integer(WriteAddress)) <= WD;
				END IF;
			END IF;
			
		END PROCESS;

		RD1 <= reg_file(conv_integer(Instr(12 DOWNTO 10))); --RS
		RD2 <= reg_file(conv_integer(Instr(9 DOWNTO 7))); --RT

		Ext_Imm(6 DOWNTO 0) <= Instr(6 DOWNTO 0);
		WITH ExtOp SELECT
		Ext_Imm(15 DOWNTO 7) <= (OTHERS => Instr(6)) WHEN '1', 
		                        (OTHERS => '0') WHEN '0', 
		                        (OTHERS => '0') WHEN OTHERS;
 
		func <= Instr(2 DOWNTO 0);
		sa <= Instr(3);

END Behavioral;