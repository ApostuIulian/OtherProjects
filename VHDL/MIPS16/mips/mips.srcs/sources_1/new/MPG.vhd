LIBRARY IEEE;
USE IEEE.STD_LOGIC_1164.ALL;
USE IEEE.STD_LOGIC_ARITH.ALL;
USE ieee.std_logic_unsigned.ALL;

ENTITY MPG IS
	PORT (
		clk : IN STD_LOGIC;
		input : IN STD_LOGIC;
	    en : OUT STD_LOGIC); 
END ENTITY;

ARCHITECTURE Behavioral OF MPG IS

	SIGNAL cnt : std_logic_vector(31 DOWNTO 0) := (others => '0');
	SIGNAL q1 : std_logic;
	SIGNAL q2 : std_logic;
	SIGNAL q3 : std_logic;

BEGIN

	PROCESS (clk)
	BEGIN
		IF rising_edge(clk) THEN
			cnt <= cnt + 1;
		END IF;

	END PROCESS;
	
	PROCESS (clk)
		BEGIN
			IF rising_edge(clk) THEN
				IF cnt(15 DOWNTO 0) = "1111111111111111" THEN
					q1 <= input;
				END IF;
			END IF;
		END PROCESS;
 
		PROCESS (clk)
			BEGIN
				IF rising_edge(clk) THEN
					q2 <= q1;
					q3 <= q2;
				END IF;
			END PROCESS;
 
			en <= q2 AND (NOT q3);
			
END Behavioral;