-- =============================================
-- SAFWA DATABASE VERIFICATION SCRIPT
-- =============================================

USE [safwa];
GO

PRINT '=============================================';
PRINT 'SAFWA DATABASE VERIFICATION';
PRINT '=============================================';
PRINT '';

-- Check Tables
PRINT 'CHECKING TABLES:';
PRINT '----------------';
SELECT 
    TABLE_NAME as 'Table Name',
    (SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = t.TABLE_NAME) as 'Columns',
    CASE TABLE_NAME
        WHEN 'Teachers' THEN (SELECT COUNT(*) FROM Teachers)
        WHEN 'Students' THEN (SELECT COUNT(*) FROM Students)
        WHEN 'Groups' THEN (SELECT COUNT(*) FROM Groups)
        WHEN 'Enrollment' THEN (SELECT COUNT(*) FROM Enrollment)
        WHEN 'Sessions' THEN (SELECT COUNT(*) FROM Sessions)
        WHEN 'Attendance' THEN (SELECT COUNT(*) FROM Attendance)
        WHEN 'Payments' THEN (SELECT COUNT(*) FROM Payments)
        WHEN 'Exams' THEN (SELECT COUNT(*) FROM Exams)
        WHEN 'Grades' THEN (SELECT COUNT(*) FROM Grades)
        ELSE 0
    END as 'Records'
FROM INFORMATION_SCHEMA.TABLES t
WHERE TABLE_TYPE = 'BASE TABLE'
ORDER BY TABLE_NAME;

PRINT '';
PRINT 'SAMPLE DATA VERIFICATION:';
PRINT '-------------------------';

-- Check Teachers
PRINT 'Teachers:';
SELECT TOP 3 teacher_id, teacher_name, specialization FROM Teachers;

PRINT '';
PRINT 'Students:';
SELECT TOP 3 student_id, student_name, guardian_name FROM Students;

PRINT '';
PRINT 'Groups:';
SELECT TOP 3 group_id, group_name, subject, day, time FROM Groups;

PRINT '';
PRINT 'Exams:';
SELECT TOP 3 exam_id, exam_name, exam_date, status FROM Exams;

PRINT '';
PRINT 'VIEWS VERIFICATION:';
PRINT '-------------------';
SELECT 
    TABLE_NAME as 'View Name'
FROM INFORMATION_SCHEMA.VIEWS
ORDER BY TABLE_NAME;

PRINT '';
PRINT 'STORED PROCEDURES VERIFICATION:';
PRINT '-------------------------------';
SELECT 
    ROUTINE_NAME as 'Procedure Name'
FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_TYPE = 'PROCEDURE'
ORDER BY ROUTINE_NAME;

PRINT '';
PRINT '=============================================';
PRINT 'DATABASE VERIFICATION COMPLETED!';
PRINT 'If you see data above, the database is ready.';
PRINT '=============================================';
