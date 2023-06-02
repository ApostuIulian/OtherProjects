library IEEE;
use IEEE.STD_LOGIC_1164.ALL;

entity ID_EX_Reg is
  Port ( clk: in std_logic;
  rst: in std_logic;
  input: in std_logic_vector(83 downto 0);
  output: out std_logic_vector(83 downto 0));
end ID_EX_Reg;

architecture Behavioral of ID_EX_Reg is

begin
PROCESS (clk)
BEGIN
    IF rising_edge(clk) THEN
            output <= input;
    END IF;
    end process;
end Behavioral;
