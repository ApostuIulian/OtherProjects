library IEEE;
use IEEE.STD_LOGIC_1164.ALL;

entity MEM_WB_Reg is
  Port ( clk: in std_logic;
  rst: in std_logic;
  input: in std_logic_vector(36 downto 0);
  output: out std_logic_vector(36 downto 0));
end MEM_WB_Reg;

architecture Behavioral of MEM_WB_Reg is

begin
PROCESS (clk)
BEGIN
    IF rising_edge(clk) THEN
            output <= input;
    END IF;
    end process;
end Behavioral;
