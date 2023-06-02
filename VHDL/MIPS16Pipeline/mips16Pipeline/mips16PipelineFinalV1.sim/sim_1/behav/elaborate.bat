@echo off
set xv_path=D:\\Faculta\\ArhitecturaCalculatoarelor\\Vivado\\Vivado\\2016.4\\bin
call %xv_path%/xelab  -wto b1eeae8d24394e91b3e2b195546f600a -m64 --debug typical --relax --mt 2 -L xil_defaultlib -L secureip --snapshot test_env_behav xil_defaultlib.test_env -log elaborate.log
if "%errorlevel%"=="0" goto SUCCESS
if "%errorlevel%"=="1" goto END
:END
exit 1
:SUCCESS
exit 0
