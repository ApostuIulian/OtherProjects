LIBRARY IEEE;
USE IEEE.STD_LOGIC_1164.ALL;
USE IEEE.STD_LOGIC_UNSIGNED.ALL;

ENTITY SSD IS
	PORT (
		clk : IN STD_LOGIC;
		digits : IN STD_LOGIC_VECTOR(15 DOWNTO 0);
		an : OUT STD_LOGIC_VECTOR(3 DOWNTO 0);
		cat : OUT STD_LOGIC_VECTOR(6 DOWNTO 0)
	);
END SSD;

ARCHITECTURE Behavioral OF SSD IS

	SIGNAL digit : STD_LOGIC_VECTOR (3 DOWNTO 0);
	SIGNAL cnt : STD_LOGIC_VECTOR (15 DOWNTO 0) := (OTHERS => '0');
	SIGNAL sel : STD_LOGIC_VECTOR (1 DOWNTO 0);
	
BEGIN

	PROCESS (clk)
	BEGIN
		IF rising_edge(clk) THEN
			cnt <= cnt + 1;
		END IF;
	END PROCESS;

	sel <= cnt(15 DOWNTO 14);

	PROCESS (sel, digits)
		BEGIN
			CASE sel IS
				WHEN "00" => digit <= digits(3 DOWNTO 0);
				WHEN "01" => digit <= digits(7 DOWNTO 4);
				WHEN "10" => digit <= digits(11 DOWNTO 8);
				WHEN "11" => digit <= digits(15 DOWNTO 12);
				WHEN OTHERS => digit <= (OTHERS => '0');
			END CASE;
		END PROCESS;
		
		PROCESS (sel)
			BEGIN
				CASE sel IS
					WHEN "00" => an <= "1110";
					WHEN "01" => an <= "1101";
					WHEN "10" => an <= "1011";
					WHEN "11" => an <= "0111";
					WHEN OTHERS => an <= (OTHERS => 'X');
				END CASE;
			END PROCESS;
			
			WITH digit SELECT
			cat <= "1000000" WHEN "0000", 
			       "1111001" WHEN "0001", 
			       "0100100" WHEN "0010", 
			       "0110000" WHEN "0011", 
			       "0011001" WHEN "0100", 
			       "0010010" WHEN "0101", 
			       "0000010" WHEN "0110", 
			       "1111000" WHEN "0111", 
			       "0000000" WHEN "1000", 
			       "0010000" WHEN "1001", 
			       "0001000" WHEN "1010", 
			       "0000011" WHEN "1011", 
			       "1000110" WHEN "1100", 
			       "0100001" WHEN "1101", 
			       "0000110" WHEN "1110", 
			       "0001110" WHEN "1111", 
			       (OTHERS => 'X') WHEN OTHERS;
			       
END Behavioral;