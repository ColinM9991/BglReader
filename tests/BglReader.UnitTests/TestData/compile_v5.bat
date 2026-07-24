@echo off
setlocal EnableExtensions

:: Path to the P3D v6 SDK BglComp.exe
set "BGLCOMP=C:\Program Files\Lockheed Martin\Prepar3D v6 SDK 6.1.10.31609\World\Scenery\bglcomp.exe"

:: Root folder containing XML files
set "ROOT=%~dp0"

if not exist "%BGLCOMP%" (
    echo ERROR: BglComp.exe not found:
    echo   %BGLCOMP%
    exit /b 1
)

for /r "%ROOT%" %%F in (*_v5.xml) do (
    echo.
    echo ==================================================
    echo Compiling %%~nxF
    echo ==================================================

    "%BGLCOMP%" "%%F"
)