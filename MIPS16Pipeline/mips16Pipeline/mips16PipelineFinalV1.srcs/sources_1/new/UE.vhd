LIBRARY IEEE;
USE IEEE.STD_LOGIC_1164.ALL;
USE IEEE.STD_LOGIC_ARITH.ALL;
USE IEEE.STD_LOGIC_UNSIGNED.ALL;

ENTITY ExecutionUnit IS

	PORT (
	    Instr97: in std_logic_vector(2 downto 0);
	    Instr64: in std_logic_vector(2 downto 0);
		PCInc : IN std_logic_vector(15 DOWNTO 0);
		RD1 : IN STD_LOGIC_VECTOR(15 DOWNTO 0);
		RD2 : IN STD_LOGIC_VECTOR(15 DOWNTO 0);
		Ext_imm : IN STD_LOGIC_VECTOR(15 DOWNTO 0);
		func : IN STD_LOGIC_VECTOR(2 DOWNTO 0);
		sa : IN std_logic;
		ALUSrc : IN std_logic;
		ALUOp : IN std_logic_vector(2 DOWNTO 0);
		RegDst: in std_logic;
		BranchAddress : OUT std_logic_vector(15 DOWNTO 0);
		ALURes : OUT std_logic_vector(15 DOWNTO 0);
		Zero : OUT std_logic;
		WriteAddress: out std_logic_vector(2 downto 0)
	);

END ExecutionUnit;

ARCHITECTURE Behavioral OF ExecutionUnit IS

	SIGNAL ALUIn1 : std_logic_vector(15 DOWNTO 0);
	SIGNAL res : std_logic_vector(15 DOWNTO 0);
	SIGNAL ALUCtrl : std_logic_vector(2 DOWNTO 0);
	
BEGIN

 with RegDst select
                 WriteAddress <= Instr64 when '1',
                 Instr97 when '0',
                 (others => '0') when others;

	WITH ALUSrc SELECT
	ALUIn1 <= RD2 WHEN '0', 
	          Ext_imm WHEN '1', 
	          (OTHERS => '0') WHEN OTHERS;

	PROCESS (ALUOp, func)
	BEGIN
		CASE ALUOp IS
			WHEN "000" => 
				CASE func IS
					WHEN "000" => ALUCtrl <= "000"; --add
					WHEN "001" => ALUCtrl <= "001"; --sub
					WHEN "010" => ALUCtrl <= "010"; --etc
					WHEN "011" => ALUCtrl <= "011";
					WHEN "100" => ALUCtrl <= "100";
					WHEN "101" => ALUCtrl <= "101";
					WHEN "110" => ALUCtrl <= "110";
					WHEN "111" => ALUCtrl <= "111";
					WHEN OTHERS => ALUCtrl <= (OTHERS => '0');
			END CASE;
			WHEN "001" => ALUCTrl <= "000"; -- add
			WHEN "010" => ALUCTrl <= "001"; -- sub
			WHEN OTHERS => ALUCtrl <= (OTHERS => '0');
		END CASE;
	END PROCESS;

	PROCESS (RD1, sa, ALUIn1, ALUCtrl, res)
		BEGIN
			CASE ALUCtrl IS
				WHEN "000" => res <= RD1 + ALUIn1;
				WHEN "001" => res <= RD1 - ALUIn1;
				WHEN OTHERS => res <= (OTHERS => '0');
			END CASE;

			ALURes <= res;

			IF res = "0000000000000000" THEN
				Zero <= '1';
			ELSE
				Zero <= '0';
			END IF;

			BranchAddress <= PCInc + Ext_Imm;

		END PROCESS;
		
END Behavioral;