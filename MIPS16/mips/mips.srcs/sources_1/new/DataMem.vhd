LIBRARY IEEE;
USE IEEE.STD_LOGIC_1164.ALL;
USE IEEE.STD_LOGIC_ARITH.ALL;
USE IEEE.STD_LOGIC_UNSIGNED.ALL;

ENTITY DataMemory IS

	PORT (
		clk : IN STD_LOGIC;
		en : IN std_logic;
		ALUResIn : IN STD_LOGIC_vector(15 DOWNTO 0);
		RD2 : IN std_logic_vector(15 DOWNTO 0);
		MemWrite : IN std_logic;
		MemData : OUT std_logic_vector(15 DOWNTO 0);
		ALUResOut : OUT std_logic_vector(15 DOWNTO 0)
	);

END DataMemory;

ARCHITECTURE Behavioral OF DataMemory IS

	TYPE MRAM IS ARRAY(0 TO 31) OF STD_LOGIC_VECTOR(15 DOWNTO 0);
	SIGNAL ram : MRAM := (X"0005", X"0004", X"0001", X"0004", X"0004", X"0004", X"0005", OTHERS => X"0000");

BEGIN
	
	PROCESS (clk, MemWrite)
	BEGIN
		IF (rising_edge(clk)) THEN
			IF en = '1' AND MemWrite = '1' THEN
				ram(conv_integer(ALUResIn(4 DOWNTO 0))) <= RD2;
			END IF;
		END IF;
	END PROCESS;

	MemData <= ram(conv_integer(ALUResIn(4 DOWNTO 0)));
	ALUResOut <= ALUResIn;
	
END Behavioral;