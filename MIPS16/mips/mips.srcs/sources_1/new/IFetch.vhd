LIBRARY IEEE;
USE IEEE.STD_LOGIC_1164.ALL;
USE IEEE.STD_LOGIC_ARITH.ALL;
USE IEEE.STD_LOGIC_UNSIGNED.ALL;

ENTITY IFetch IS
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
END IFetch;

ARCHITECTURE Behavioral OF IFetch IS

	SIGNAL cnt : std_logic_vector(15 DOWNTO 0) := (OTHERS => '0');
	TYPE tROM IS ARRAY(0 TO 255) OF STD_LOGIC_VECTOR (15 DOWNTO 0);
	SIGNAL ROM : tROM := 
	(
	B"001_000_001_0000000", --$1=i=0 --X"2080"
            B"001_000_010_0000010", --$2=2 id mem --X"2102"
            B"001_000_011_0000001", --$3=1 --X"2181"
            B"010_000_100_0000000", --lw $4<=mem(0) --X"4200"
            B"010_011_101_0000000", --lw $5<=mem(1) --X"4E80"
            --B"001_000_011_0000000", --$3 = 0 aici numaram duplicatele numarului
            B"011_100_001_0000110", -- i == n ($4) --X"9086"
            B"010_010_110_0000000", -- $6=mem($2) --X"4B00"
            B"101_101_110_0000001", --$6!=$5 --X"B701"
            B"001_011_011_0000001", --duplicate++ $3 --X"2D81"
            B"001_001_001_0000001", --i++ --X"2481"
            B"001_010_010_0000001", --mem id++ --X"2901"
            B"100_0000000000101", --jump 5 --X"E005"
            B"001_011_011_1111111", --X"2DFF"
            --B"001_001_001_0000000", --X"2480"
            OTHERS => X"0000");
		SIGNAL PCAux, NextAddress, Aux : STD_LOGIC_VECTOR(15 DOWNTO 0);

BEGIN
	PROCESS (clk, rst, en)
	BEGIN
		IF rst = '1' THEN
			cnt <= (OTHERS => '0');
		END IF;

		IF rising_edge(clk) THEN
			IF en = '1' THEN
				cnt <= NextAddress;
			END IF;
		END IF;
	END PROCESS;

	Instr <= ROM(conv_integer(cnt(7 downto 0)));

	PCAux <= cnt + 1;
	PCInc <= PCAux;

	PROCESS (PCSrc, PCAux, BranchAddress)
 
		BEGIN
			CASE PCSrc IS
				WHEN '1' => Aux <= BranchAddress;
				WHEN OTHERS => Aux <= PCAux;
			END CASE;
		END PROCESS; 

		PROCESS (Jump, Aux, JumpAddress)
			BEGIN
				CASE Jump IS
					WHEN '1' => NextAddress <= JumpAddress;
					WHEN OTHERS => NextAddress <= Aux;
				END CASE;
			END PROCESS;
 
END Behavioral;