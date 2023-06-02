library IEEE;
use IEEE.STD_LOGIC_1164.ALL;

entity IF_ID_Reg is
  Port ( clk: in std_logic;
  rst: in std_logic;
  input: in std_logic_vector(31 downto 0);
  output: out std_logic_vector(31 downto 0));
end IF_ID_Reg;

architecture Behavioral of IF_ID_Reg is

begin
PROCESS (clk)
BEGIN
    IF rising_edge(clk) THEN
            output <= input;
    END IF;
    end process;
end Behavioral;
