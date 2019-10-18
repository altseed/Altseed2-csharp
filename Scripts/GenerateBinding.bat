cd %~dp0..\Core\scripts
FOR /f "usebackq tokens=*" %%i IN (`cd`) DO set PYTHONPATH=%%i

cd %~dp0..\CBG
FOR /f "usebackq tokens=*" %%i IN (`cd`) DO set PYTHONPATH=%%i;%PYTHONPATH%

python %~dp0generate_binding.py

pause
