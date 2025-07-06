@echo off
echo =============================================
echo SAFWA MANAGEMENT SYSTEM - DATABASE SETUP
echo =============================================
echo.
echo This will create a new 'safwa' database with sample data.
echo WARNING: This will delete any existing 'safwa' database!
echo.
pause

echo.
echo Setting up database...
sqlcmd -S "DESKTOP-MER5NAJ\SQLEXPRESS" -E -i "SafwaDatabase_Complete.sql"

if %ERRORLEVEL% EQU 0 (
    echo.
    echo =============================================
    echo DATABASE SETUP COMPLETED SUCCESSFULLY!
    echo =============================================
    echo.
    echo Your Safwa database is now ready with:
    echo - 8 Teachers with different specializations
    echo - 10 Students with complete information
    echo - 8 Groups/Classes with schedules
    echo - Student enrollments and attendance records
    echo - Sample exams and grades
    echo - Payment records
    echo - All necessary views and stored procedures
    echo.
    echo You can now run the SafwaManagementSystem.exe application!
    echo.
) else (
    echo.
    echo =============================================
    echo ERROR: Database setup failed!
    echo =============================================
    echo.
    echo Please check:
    echo 1. SQL Server is running
    echo 2. Server name is correct: DESKTOP-MER5NAJ\SQLEXPRESS
    echo 3. You have administrator privileges
    echo.
)

pause
