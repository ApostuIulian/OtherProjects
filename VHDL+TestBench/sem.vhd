library IEEE;
use IEEE.STD_LOGIC_1164.all; 
entity semafor is
	port(CLOCK, RESET: in std_logic;
	SENZOR1: in std_logic;
	SENZOR2: in std_logic;
	P: out std_logic;			
	R: out std_logic_vector(3 downto 0);
	G: out std_logic_vector(3 downto 0); 
	V: out std_logic_vector(3 downto 0));
end entity;	
architecture sem of semafor is					   
type STARE_T is (ST0, ST1, ST2, ST3, ST4, ST5, ST6, ST7, ST8, ST9);
signal STARE, NXSTARE: STARE_T;
begin
	ACTUALIZEAZA_STARE: process(CLOCK, RESET)
	begin
	if(RESET = '1') then
		STARE<=ST0;
	elsif (CLOCK'EVENT and CLOCK = '1') then
		STARE<=NXSTARE;
		end if;
end process; 
process(STARE, SENZOR1, SENZOR2)
begin 	  
	R(0)<='1'; R(1)<='1'; R(2)<='1';  R(3)<='1';
	G(0)<='0'; G(1)<='0'; G(2)<='0';  G(3)<='0';   
	V(0)<='0'; V(1)<='0'; V(2)<='0';  V(3)<='0';
	P<='0';
	case STARE is	
	when ST0=> 
	V(0)<='1';
	R(0)<='0';
	NXSTARE<=ST1;
	when ST1=>
		V(0)<='0';
		G(0)<='1';
		NXSTARE<=ST2;
	when ST2=>
	G(0)<='0';
	R(0)<='1';
	R(1)<='0';
	V(1)<='1';
	NXSTARE<=ST3;
	when ST3=>
	if SENZOR1='1' then
		G(1)<='1';
		R(1)<='0';
		NXSTARE<=ST2;	
	else
		V(1)<='0';
		R(1)<='0';
		G(1)<='1';
		NXSTARE<=ST4;
	end if;
	when ST4=>
	G(1)<='0';
	R(1)<='1';
	P<='1';
	NXSTARE<=ST5;
	when ST5=>
	P<='0';	 
	R(2)<='0';
	V(2)<='1';
    NXSTARE<=ST6;
	when ST6=>
	V(2)<='0';
	R(2)<='0';
	G(2)<='1';
	NXSTARE<=ST7;
	when ST7=>
	G(2)<='0'; 
	R(2)<='1';
	R(3)<='0';
	V(3)<='1';
	NXSTARE<=ST8;
	when ST8=>
	if SENZOR2='1'  then
	G(3)<='1';
	R(3)<='0';
NXSTARE<=ST7;
	else
	V(3)<='0';
	R(3)<='0';
	G(3)<='1';
	NXSTARE<=ST9;
	end if;	 
	when ST9=>
	G(3)<='0';
	R(3)<='1';
	P<='1';
	NXSTARE<=ST0;
	when others=>
	NXSTARE<=ST0;
	end case;
	end process;
end architecture;