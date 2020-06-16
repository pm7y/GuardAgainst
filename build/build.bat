@ECHO OFF

Powershell.exe -executionpolicy remotesigned -File .\build.ps1 -ScriptArgs "--configuration=Debug --buildVersion=1.0.0-dev --verbosity=minimal"

pause
