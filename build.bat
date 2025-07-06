@echo off
echo Building Safwa Management System...

REM Set the path to MSBuild (adjust if needed)
set MSBUILD_PATH="C:\Program Files (x86)\Microsoft Visual Studio\2019\Professional\MSBuild\Current\Bin\MSBuild.exe"

REM Alternative paths for different Visual Studio versions
if not exist %MSBUILD_PATH% set MSBUILD_PATH="C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Current\Bin\MSBuild.exe"
if not exist %MSBUILD_PATH% set MSBUILD_PATH="C:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\MSBuild\15.0\Bin\MSBuild.exe"
if not exist %MSBUILD_PATH% set MSBUILD_PATH="C:\Windows\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe"

REM Check if MSBuild exists
if not exist %MSBUILD_PATH% (
    echo MSBuild not found. Please install Visual Studio or .NET Framework SDK.
    echo Or update the MSBUILD_PATH in this script.
    pause
    exit /b 1
)

REM Build the project
echo Using MSBuild: %MSBUILD_PATH%
%MSBUILD_PATH% SafwaManagementSystem.sln /p:Configuration=Debug /p:Platform=AnyCPU

if %ERRORLEVEL% EQU 0 (
    echo.
    echo Build successful!
    echo Executable location: bin\Debug\SafwaManagementSystem.exe
    echo.
    echo To run the application, make sure:
    echo 1. SQL Server is running
    echo 2. The 'safwa' database exists
    echo 3. Connection string in App.config is correct
    echo.
) else (
    echo.
    echo Build failed with error code %ERRORLEVEL%
    echo Please check the error messages above.
    echo.
)

pause
