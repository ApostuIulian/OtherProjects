LIBRARY ieee;
USE ieee.std_logic_1164.ALL;
entity test is	
end entity;
architecture testSem of test is
component semafor
	port(CLOCK, RESET: in std_logic;
	SENZOR1: in std_logic;
	SENZOR2: in std_logic;
	P: out std_logic;			
	R: out std_logic_vector(3 downto 0);
	G: out std_logic_vector(3 downto 0); 
	V: out std_logic_vector(3 downto 0));
	end component;
	signal clk: std_logic:='0';
	signal rst: std_logic:='0';
	signal sz1: std_logic:='0';
	signal sz2: std_logic:='0';
	signal p: std_logic;
	signal r: std_logic_vector(3 downto 0);
	signal g: std_logic_vector(3 downto 0);
	signal v: std_logic_vector(3 downto 0);
	constant clock_period: time := 100 ns;
	begin 
	U: semafor port map(clk, rst, sz1, sz2, p, r, g, v);			
	clock:process
	begin
		clk<='0'; 
		wait for clock_period;
		clk<='1';
		wait for clock_period;
	end process; 
	process
	begin
			sz1<='0'; 
		wait for clock_period*9;
		sz1<='1';
		wait for clock_period;
	end process; 
	   process
	begin
			sz2<='0'; 
		wait for clock_period*2;
		sz2<='1';
		wait for clock_period;
	end process; 
end architecture;