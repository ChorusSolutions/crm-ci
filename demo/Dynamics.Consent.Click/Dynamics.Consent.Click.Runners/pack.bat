@echo Running Visualizations powershell fix

Powershell.exe -executionpolicy remotesigned -File ./VisualizationsXmlFix.ps1

@echo off
set package_root=..\..\
REM Find the spkl in the package folder (irrespective of version)
For /R %package_root% %%G IN (spkl.exe) do (
	IF EXIST "%%G" (set spkl_path=%%G
	goto :continue)
	)

:continue
@echo Using '%spkl_path%'

REM spkl instrument [path] [connection-string] [/p:release]
"%spkl_path%" pack "spkl.json" "" /p:release
"%spkl_path%" pack "spkl.json" "" /p:debug
pause