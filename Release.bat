C:\Factory\Tools\RDMD.exe /RC out

C:\Factory\SubTools\makeDDResourceFile.exe ^
	C:\Dat\Resource ^
	/SD Fairy\Donut3\General ^
	/SD Etoile\G4Dungeon ^
	out\Resource.dat ^
	C:\Factory\Program\MaskGZDataForDonut3\MaskGZData.exe

C:\Factory\SubTools\makeDDResourceFile.exe ^
	res ^
	out\res.dat ^
	C:\Factory\Program\MaskGZDataForDonut3\MaskGZData.exe

C:\Factory\SubTools\CallConfuserCLI.exe G4Dungeon\G4Dungeon\bin\Release\G4Dungeon.exe out\G4Dungeon.exe
rem COPY /B G4Dungeon\G4Dungeon\bin\Release\G4Dungeon.exe out
COPY /B G4Dungeon\G4Dungeon\bin\Release\Chocolate.dll out
COPY /B G4Dungeon\G4Dungeon\bin\Release\DxLib.dll out
COPY /B G4Dungeon\G4Dungeon\bin\Release\DxLib_x64.dll out
COPY /B G4Dungeon\G4Dungeon\bin\Release\DxLibDotNet.dll out

C:\Factory\Tools\xcp.exe doc out
C:\Factory\Tools\xcp.exe C:\Dev\Fairy\Donut3\doc out
COPY /B AUTHORS out

C:\Factory\SubTools\zip.exe /PE- /RVE- /G out G4Dungeon
C:\Factory\Tools\summd5.exe /M out

IF NOT "%1" == "/-P" PAUSE
