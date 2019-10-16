cd %~dp0..\CBG
FOR /f "usebackq tokens=*" %%i IN (`cd`) DO set PYTHONPATH=%%i

python %~dp0generate_binding.py

pause
