echo be sure to run this as Adminsitrator
sc.exe create "XXYXX Web App" binpath= "%~dp0..\bin\Release\net8.0\WebWM.exe /s"
pause