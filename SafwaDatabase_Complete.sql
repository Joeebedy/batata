-- =============================================
-- SAFWA MANAGEMENT SYSTEM - COMPLETE DATABASE SETUP
-- =============================================

USE [master];
GO

-- Drop database if exists
IF EXISTS (SELECT name FROM sys.databases WHERE name = N'safwa')
BEGIN
    ALTER DATABASE [safwa] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [safwa];
END
GO

-- Create new database
CREATE DATABASE [safwa] 
CONTAINMENT = NONE 
ON PRIMARY 
(
    NAME = N'safwa',
    FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\safwa.mdf',
    SIZE = 8192KB,
    MAXSIZE = UNLIMITED,
    FILEGROWTH = 65536KB
) 
LOG ON 
(
    NAME = N'safwa_log',
    FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\safwa_log.ldf',
    SIZE = 8192KB,
    MAXSIZE = 2048GB,
    FILEGROWTH = 65536KB
);
GO

USE [safwa];
GO

-- =============================================
-- CREATE TABLES
-- =============================================

-- Teachers Table
CREATE TABLE [dbo].[Teachers] (
    [teacher_id] [int] IDENTITY(1,1) NOT NULL,
    [teacher_name] [nvarchar](100) NOT NULL,
    [specialization] [nvarchar](100) NULL,
    [phone_number] [nvarchar](20) NULL,
    [email] [nvarchar](100) NULL,
    [notes] [nvarchar](max) NULL,
    [status] [nvarchar](20) DEFAULT 'Active',
    [hire_date] [date] DEFAULT GETDATE(),
    [created_at] [datetime2](7) DEFAULT GETDATE(),
    [updated_at] [datetime2](7) DEFAULT GETDATE(),
    PRIMARY KEY CLUSTERED ([teacher_id] ASC)
);

-- Students Table
CREATE TABLE [dbo].[Students] (
    [student_id] [int] IDENTITY(1,1) NOT NULL,
    [student_name] [nvarchar](100) NOT NULL,
    [guardian_name] [nvarchar](100) NULL,
    [guardian_phone] [nvarchar](20) NULL,
    [student_phone] [nvarchar](20) NULL,
    [address] [nvarchar](255) NULL,
    [birth_date] [date] NULL,
    [notes] [nvarchar](max) NULL,
    [status] [nvarchar](20) DEFAULT 'Active',
    [created_at] [datetime2](7) DEFAULT GETDATE(),
    [updated_at] [datetime2](7) DEFAULT GETDATE(),
    PRIMARY KEY CLUSTERED ([student_id] ASC)
);

-- Groups Table
CREATE TABLE [dbo].[Groups] (
    [group_id] [int] IDENTITY(1,1) NOT NULL,
    [group_name] [nvarchar](100) NOT NULL,
    [subject] [nvarchar](100) NOT NULL,
    [day] [nvarchar](10) NOT NULL,
    [time] [time](7) NOT NULL,
    [teacher_id] [int] NOT NULL,
    [capacity] [int] DEFAULT 30,
    [room] [nvarchar](50) NULL,
    [start_date] [date] NULL,
    [end_date] [date] NULL,
    [status] [nvarchar](20) DEFAULT 'Active',
    [created_at] [datetime2](7) DEFAULT GETDATE(),
    [updated_at] [datetime2](7) DEFAULT GETDATE(),
    PRIMARY KEY CLUSTERED ([group_id] ASC),
    FOREIGN KEY ([teacher_id]) REFERENCES [dbo].[Teachers]([teacher_id]) ON UPDATE CASCADE
);

-- Enrollment Table
CREATE TABLE [dbo].[Enrollment] (
    [enrollment_id] [int] IDENTITY(1,1) NOT NULL,
    [student_id] [int] NOT NULL,
    [group_id] [int] NOT NULL,
    [enrollment_date] [date] DEFAULT CAST(GETDATE() AS DATE),
    [status] [nvarchar](10) DEFAULT 'Active',
    [created_at] [datetime2](7) DEFAULT GETDATE(),
    [updated_at] [datetime2](7) DEFAULT GETDATE(),
    PRIMARY KEY CLUSTERED ([enrollment_id] ASC),
    FOREIGN KEY ([student_id]) REFERENCES [dbo].[Students]([student_id]) ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY ([group_id]) REFERENCES [dbo].[Groups]([group_id]) ON UPDATE CASCADE ON DELETE CASCADE,
    CONSTRAINT [unique_enrollment] UNIQUE NONCLUSTERED ([student_id] ASC, [group_id] ASC)
);

-- Sessions Table
CREATE TABLE [dbo].[Sessions] (
    [session_id] [int] IDENTITY(1,1) NOT NULL,
    [group_id] [int] NOT NULL,
    [session_date] [date] NOT NULL,
    [session_time] [time](7) NULL,
    [duration] [int] DEFAULT 60,
    [location] [nvarchar](100) NULL,
    [notes] [nvarchar](max) NULL,
    [status] [nvarchar](20) DEFAULT 'Scheduled',
    [created_at] [datetime2](7) DEFAULT GETDATE(),
    [updated_at] [datetime2](7) DEFAULT GETDATE(),
    PRIMARY KEY CLUSTERED ([session_id] ASC),
    FOREIGN KEY ([group_id]) REFERENCES [dbo].[Groups]([group_id]) ON UPDATE CASCADE ON DELETE CASCADE
);

-- Attendance Table
CREATE TABLE [dbo].[Attendance] (
    [attendance_id] [int] IDENTITY(1,1) NOT NULL,
    [student_id] [int] NOT NULL,
    [session_id] [int] NOT NULL,
    [status] [nvarchar](10) DEFAULT 'Present',
    [notes] [nvarchar](max) NULL,
    [created_at] [datetime2](7) DEFAULT GETDATE(),
    [updated_at] [datetime2](7) DEFAULT GETDATE(),
    PRIMARY KEY CLUSTERED ([attendance_id] ASC),
    FOREIGN KEY ([student_id]) REFERENCES [dbo].[Students]([student_id]) ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY ([session_id]) REFERENCES [dbo].[Sessions]([session_id]) ON UPDATE CASCADE ON DELETE CASCADE,
    CONSTRAINT [unique_attendance] UNIQUE NONCLUSTERED ([student_id] ASC, [session_id] ASC)
);

-- Payments Table
CREATE TABLE [dbo].[Payments] (
    [payment_id] [int] IDENTITY(1,1) NOT NULL,
    [student_id] [int] NOT NULL,
    [amount] [decimal](10,2) NOT NULL,
    [payment_date] [date] NOT NULL,
    [payment_method] [nvarchar](20) DEFAULT 'Cash',
    [payment_status] [nvarchar](20) DEFAULT 'Completed',
    [due_date] [date] NULL,
    [description] [nvarchar](255) NULL,
    [receipt_number] [nvarchar](50) NULL,
    [notes] [nvarchar](max) NULL,
    [created_at] [datetime2](7) DEFAULT GETDATE(),
    [updated_at] [datetime2](7) DEFAULT GETDATE(),
    PRIMARY KEY CLUSTERED ([payment_id] ASC),
    FOREIGN KEY ([student_id]) REFERENCES [dbo].[Students]([student_id]) ON UPDATE CASCADE ON DELETE CASCADE
);

-- Exams Table
CREATE TABLE [dbo].[Exams] (
    [exam_id] [int] IDENTITY(1,1) NOT NULL,
    [group_id] [int] NOT NULL,
    [exam_name] [nvarchar](100) NOT NULL,
    [exam_date] [datetime] NOT NULL,
    [duration_minutes] [int] DEFAULT 60,
    [total_marks] [decimal](5,2) DEFAULT 100.00,
    [exam_type] [nvarchar](50) DEFAULT 'Written',
    [status] [nvarchar](50) DEFAULT 'Scheduled',
    [description] [nvarchar](max) NULL,
    [instructions] [nvarchar](max) NULL,
    [created_date] [datetime2](7) DEFAULT GETDATE(),
    [updated_at] [datetime2](7) DEFAULT GETDATE(),
    PRIMARY KEY CLUSTERED ([exam_id] ASC),
    FOREIGN KEY ([group_id]) REFERENCES [dbo].[Groups]([group_id]) ON UPDATE CASCADE ON DELETE CASCADE
);

-- Grades Table
CREATE TABLE [dbo].[Grades] (
    [grade_id] [int] IDENTITY(1,1) NOT NULL,
    [exam_id] [int] NOT NULL,
    [student_id] [int] NOT NULL,
    [score] [decimal](5,2) NOT NULL,
    [grade_letter] [char](2) NULL,
    [notes] [nvarchar](max) NULL,
    [created_at] [datetime2](7) DEFAULT GETDATE(),
    [updated_at] [datetime2](7) DEFAULT GETDATE(),
    PRIMARY KEY CLUSTERED ([grade_id] ASC),
    FOREIGN KEY ([exam_id]) REFERENCES [dbo].[Exams]([exam_id]) ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY ([student_id]) REFERENCES [dbo].[Students]([student_id]) ON UPDATE CASCADE ON DELETE CASCADE,
    CONSTRAINT [unique_grade] UNIQUE NONCLUSTERED ([exam_id] ASC, [student_id] ASC)
);

-- =============================================
-- CREATE CONSTRAINTS
-- =============================================

-- Check constraints for data validation
ALTER TABLE [dbo].[Teachers] ADD CONSTRAINT [CK_Teachers_Status]
CHECK ([status] IN ('Active', 'Inactive', 'Suspended'));

ALTER TABLE [dbo].[Students] ADD CONSTRAINT [CK_Students_Status]
CHECK ([status] IN ('Active', 'Inactive', 'Graduated', 'Dropped'));

ALTER TABLE [dbo].[Groups] ADD CONSTRAINT [CK_Groups_Day]
CHECK ([day] IN ('Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'));

ALTER TABLE [dbo].[Groups] ADD CONSTRAINT [CK_Groups_Status]
CHECK ([status] IN ('Active', 'Inactive', 'Completed'));

ALTER TABLE [dbo].[Enrollment] ADD CONSTRAINT [CK_Enrollment_Status]
CHECK ([status] IN ('Active', 'Inactive', 'Dropped'));

ALTER TABLE [dbo].[Sessions] ADD CONSTRAINT [CK_Sessions_Status]
CHECK ([status] IN ('Scheduled', 'Completed', 'Cancelled'));

ALTER TABLE [dbo].[Attendance] ADD CONSTRAINT [CK_Attendance_Status]
CHECK ([status] IN ('Present', 'Absent', 'Late', 'Excused'));

ALTER TABLE [dbo].[Payments] ADD CONSTRAINT [CK_Payments_Method]
CHECK ([payment_method] IN ('Cash', 'Bank Transfer', 'Credit Card', 'Check'));

ALTER TABLE [dbo].[Payments] ADD CONSTRAINT [CK_Payments_Status]
CHECK ([payment_status] IN ('Pending', 'Completed', 'Failed', 'Refunded'));

ALTER TABLE [dbo].[Payments] ADD CONSTRAINT [CK_Payments_Amount]
CHECK ([amount] > 0);

ALTER TABLE [dbo].[Exams] ADD CONSTRAINT [CK_Exams_Status]
CHECK ([status] IN ('Scheduled', 'In Progress', 'Completed', 'Cancelled', 'Postponed'));

ALTER TABLE [dbo].[Exams] ADD CONSTRAINT [CK_Exams_ExamType]
CHECK ([exam_type] IN ('Quiz', 'Midterm', 'Final', 'Assignment', 'Project', 'Practical', 'Oral', 'Written', 'Other'));

ALTER TABLE [dbo].[Exams] ADD CONSTRAINT [CK_Exams_Duration]
CHECK ([duration_minutes] > 0 AND [duration_minutes] <= 480);

ALTER TABLE [dbo].[Exams] ADD CONSTRAINT [CK_Exams_TotalMarks]
CHECK ([total_marks] > 0 AND [total_marks] <= 1000);

ALTER TABLE [dbo].[Grades] ADD CONSTRAINT [CK_Grades_Score]
CHECK ([score] >= 0);

-- =============================================
-- CREATE INDEXES FOR PERFORMANCE
-- =============================================

-- Teachers indexes
CREATE NONCLUSTERED INDEX [IX_Teachers_Name] ON [dbo].[Teachers]([teacher_name]);
CREATE NONCLUSTERED INDEX [IX_Teachers_Status] ON [dbo].[Teachers]([status]);

-- Students indexes
CREATE NONCLUSTERED INDEX [IX_Students_Name] ON [dbo].[Students]([student_name]);
CREATE NONCLUSTERED INDEX [IX_Students_Status] ON [dbo].[Students]([status]);

-- Groups indexes
CREATE NONCLUSTERED INDEX [IX_Groups_Teacher] ON [dbo].[Groups]([teacher_id]);
CREATE NONCLUSTERED INDEX [IX_Groups_Day_Time] ON [dbo].[Groups]([day], [time]);
CREATE NONCLUSTERED INDEX [IX_Groups_Status] ON [dbo].[Groups]([status]);

-- Enrollment indexes
CREATE NONCLUSTERED INDEX [IX_Enrollment_Student] ON [dbo].[Enrollment]([student_id]);
CREATE NONCLUSTERED INDEX [IX_Enrollment_Group] ON [dbo].[Enrollment]([group_id]);
CREATE NONCLUSTERED INDEX [IX_Enrollment_Status] ON [dbo].[Enrollment]([status]);

-- Sessions indexes
CREATE NONCLUSTERED INDEX [IX_Sessions_Group] ON [dbo].[Sessions]([group_id]);
CREATE NONCLUSTERED INDEX [IX_Sessions_Date] ON [dbo].[Sessions]([session_date]);

-- Attendance indexes
CREATE NONCLUSTERED INDEX [IX_Attendance_Student] ON [dbo].[Attendance]([student_id]);
CREATE NONCLUSTERED INDEX [IX_Attendance_Session] ON [dbo].[Attendance]([session_id]);

-- Payments indexes
CREATE NONCLUSTERED INDEX [IX_Payments_Student] ON [dbo].[Payments]([student_id]);
CREATE NONCLUSTERED INDEX [IX_Payments_Date] ON [dbo].[Payments]([payment_date]);
CREATE NONCLUSTERED INDEX [IX_Payments_Status] ON [dbo].[Payments]([payment_status]);

-- Exams indexes
CREATE NONCLUSTERED INDEX [IX_Exams_Group] ON [dbo].[Exams]([group_id]);
CREATE NONCLUSTERED INDEX [IX_Exams_Date] ON [dbo].[Exams]([exam_date]);
CREATE NONCLUSTERED INDEX [IX_Exams_Status] ON [dbo].[Exams]([status]);

-- Grades indexes
CREATE NONCLUSTERED INDEX [IX_Grades_Exam] ON [dbo].[Grades]([exam_id]);
CREATE NONCLUSTERED INDEX [IX_Grades_Student] ON [dbo].[Grades]([student_id]);

-- =============================================
-- CREATE VIEWS FOR REPORTING
-- =============================================

-- Student Enrollment View
CREATE VIEW [dbo].[vw_StudentEnrollment] AS
SELECT
    s.student_id,
    s.student_name,
    g.group_id,
    g.group_name,
    g.subject,
    g.day,
    g.time,
    t.teacher_name,
    e.enrollment_date,
    e.status as enrollment_status
FROM Students s
JOIN Enrollment e ON s.student_id = e.student_id
JOIN Groups g ON e.group_id = g.group_id
JOIN Teachers t ON g.teacher_id = t.teacher_id;

-- Attendance Summary View
CREATE VIEW [dbo].[vw_AttendanceSummary] AS
SELECT
    s.student_id,
    s.student_name,
    g.group_id,
    g.group_name,
    g.subject,
    COUNT(a.attendance_id) as total_sessions,
    SUM(CASE WHEN a.status = 'Present' THEN 1 ELSE 0 END) as present_count,
    SUM(CASE WHEN a.status = 'Absent' THEN 1 ELSE 0 END) as absent_count,
    ROUND((SUM(CASE WHEN a.status = 'Present' THEN 1 ELSE 0 END) * 100.0 / NULLIF(COUNT(a.attendance_id), 0)), 2) as attendance_percentage
FROM Students s
JOIN Enrollment e ON s.student_id = e.student_id
JOIN Groups g ON e.group_id = g.group_id
JOIN Sessions sess ON g.group_id = sess.group_id
LEFT JOIN Attendance a ON s.student_id = a.student_id AND sess.session_id = a.session_id
GROUP BY s.student_id, s.student_name, g.group_id, g.group_name, g.subject;

-- Payment Summary View
CREATE VIEW [dbo].[vw_PaymentSummary] AS
SELECT
    s.student_id,
    s.student_name,
    COUNT(p.payment_id) as total_payments,
    SUM(p.amount) as total_paid,
    MAX(p.payment_date) as last_payment_date,
    SUM(CASE WHEN p.payment_status = 'Pending' THEN p.amount ELSE 0 END) as pending_amount
FROM Students s
LEFT JOIN Payments p ON s.student_id = p.student_id
GROUP BY s.student_id, s.student_name;

-- Exam Details View
CREATE VIEW [dbo].[vw_ExamDetails] AS
SELECT
    e.exam_id,
    e.exam_name,
    e.group_id,
    g.group_name,
    g.subject,
    e.exam_date,
    e.duration_minutes,
    e.total_marks,
    e.exam_type,
    ISNULL(e.status, 'Scheduled') as status,
    e.description,
    e.instructions,
    e.created_date,
    e.updated_at,
    COUNT(gr.grade_id) as students_graded,
    AVG(CAST(gr.score AS FLOAT)) as average_grade
FROM Exams e
LEFT JOIN Groups g ON e.group_id = g.group_id
LEFT JOIN Grades gr ON e.exam_id = gr.exam_id
GROUP BY e.exam_id, e.exam_name, e.group_id, g.group_name, g.subject, e.exam_date,
         e.duration_minutes, e.total_marks, e.exam_type, e.status,
         e.description, e.instructions, e.created_date, e.updated_at;

-- Exam Statistics View
CREATE VIEW [dbo].[vw_ExamStatistics] AS
SELECT
    COUNT(*) as total_exams,
    SUM(CASE WHEN ISNULL(status, 'Scheduled') = 'Scheduled' THEN 1 ELSE 0 END) as scheduled_exams,
    SUM(CASE WHEN ISNULL(status, 'Scheduled') = 'Completed' THEN 1 ELSE 0 END) as completed_exams,
    SUM(CASE WHEN ISNULL(status, 'Scheduled') = 'Cancelled' THEN 1 ELSE 0 END) as cancelled_exams,
    SUM(CASE WHEN exam_date > GETDATE() AND ISNULL(status, 'Scheduled') = 'Scheduled' THEN 1 ELSE 0 END) as upcoming_exams,
    SUM(CASE WHEN exam_date < GETDATE() AND ISNULL(status, 'Scheduled') = 'Scheduled' THEN 1 ELSE 0 END) as overdue_exams
FROM Exams;

-- =============================================
-- CREATE STORED PROCEDURES
-- =============================================

-- Get Exam Details
CREATE PROCEDURE [dbo].[sp_GetExamDetails]
    @ExamId INT = NULL,
    @GroupId INT = NULL,
    @Status NVARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM vw_ExamDetails
    WHERE (@ExamId IS NULL OR exam_id = @ExamId)
      AND (@GroupId IS NULL OR group_id = @GroupId)
      AND (@Status IS NULL OR status = @Status)
    ORDER BY exam_date DESC;
END;

-- Get Upcoming Exams
CREATE PROCEDURE [dbo].[sp_GetUpcomingExams]
    @Days INT = 30
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM vw_ExamDetails
    WHERE exam_date BETWEEN CAST(GETDATE() AS DATE) AND DATEADD(DAY, @Days, CAST(GETDATE() AS DATE))
      AND status = 'Scheduled'
    ORDER BY exam_date ASC;
END;

-- Update Exam Status
CREATE PROCEDURE [dbo].[sp_UpdateExamStatus]
    @ExamId INT,
    @NewStatus NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Exams
    SET status = @NewStatus, updated_at = GETDATE()
    WHERE exam_id = @ExamId;

    SELECT @@ROWCOUNT as rows_affected;
END;

-- Cleanup Old Exams
CREATE PROCEDURE [dbo].[sp_CleanupOldExams]
    @DaysOld INT = 365
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @ExamCount INT, @GradeCount INT;

    SELECT @GradeCount = COUNT(*)
    FROM Grades
    WHERE exam_id IN (
        SELECT exam_id FROM Exams
        WHERE status = 'Completed'
        AND exam_date < DATEADD(DAY, -@DaysOld, GETDATE())
    );

    DELETE FROM Grades
    WHERE exam_id IN (
        SELECT exam_id FROM Exams
        WHERE status = 'Completed'
        AND exam_date < DATEADD(DAY, -@DaysOld, GETDATE())
    );

    DELETE FROM Exams
    WHERE status = 'Completed'
    AND exam_date < DATEADD(DAY, -@DaysOld, GETDATE());

    SET @ExamCount = @@ROWCOUNT;
    SELECT @GradeCount AS grades_deleted, @ExamCount AS exams_deleted;
END;

-- =============================================
-- INSERT SAMPLE DATA
-- =============================================

-- Insert Teachers
INSERT INTO [dbo].[Teachers] ([teacher_name], [specialization], [phone_number], [email], [status], [hire_date])
VALUES
    ('Ahmed Hassan', 'Mathematics', '01234567890', 'ahmed.hassan@safwa.edu', 'Active', '2023-01-15'),
    ('Fatima Ali', 'Physics', '01234567891', 'fatima.ali@safwa.edu', 'Active', '2023-02-01'),
    ('Mohamed Salah', 'Chemistry', '01234567892', 'mohamed.salah@safwa.edu', 'Active', '2023-03-10'),
    ('Aisha Omar', 'Biology', '01234567893', 'aisha.omar@safwa.edu', 'Active', '2023-04-05'),
    ('Khaled Mahmoud', 'English', '01234567894', 'khaled.mahmoud@safwa.edu', 'Active', '2023-05-20'),
    ('Nour Ibrahim', 'Arabic', '01234567895', 'nour.ibrahim@safwa.edu', 'Active', '2023-06-15'),
    ('Omar Farouk', 'History', '01234567896', 'omar.farouk@safwa.edu', 'Active', '2023-07-01'),
    ('Maryam Youssef', 'Geography', '01234567897', 'maryam.youssef@safwa.edu', 'Active', '2023-08-10');

-- Insert Students
INSERT INTO [dbo].[Students] ([student_name], [guardian_name], [guardian_phone], [student_phone], [address], [birth_date], [status])
VALUES
    ('Ali Ahmed', 'Ahmed Ali', '01111111111', '01555555551', '123 Main St, Cairo', '2005-03-15', 'Active'),
    ('Sara Mohamed', 'Mohamed Hassan', '01111111112', '01555555552', '456 Oak Ave, Giza', '2005-07-22', 'Active'),
    ('Hassan Omar', 'Omar Hassan', '01111111113', '01555555553', '789 Pine Rd, Alexandria', '2005-11-08', 'Active'),
    ('Nada Khaled', 'Khaled Nour', '01111111114', '01555555554', '321 Elm St, Cairo', '2005-01-30', 'Active'),
    ('Youssef Ibrahim', 'Ibrahim Youssef', '01111111115', '01555555555', '654 Maple Dr, Giza', '2005-09-12', 'Active'),
    ('Layla Farouk', 'Farouk Layla', '01111111116', '01555555556', '987 Cedar Ln, Alexandria', '2005-05-18', 'Active'),
    ('Amr Salah', 'Salah Amr', '01111111117', '01555555557', '147 Birch St, Cairo', '2005-12-03', 'Active'),
    ('Dina Mahmoud', 'Mahmoud Dina', '01111111118', '01555555558', '258 Spruce Ave, Giza', '2005-04-25', 'Active'),
    ('Karim Nasser', 'Nasser Karim', '01111111119', '01555555559', '369 Willow Rd, Alexandria', '2005-08-14', 'Active'),
    ('Rana Tamer', 'Tamer Rana', '01111111120', '01555555560', '741 Poplar Dr, Cairo', '2005-06-07', 'Active');

-- Insert Groups
INSERT INTO [dbo].[Groups] ([group_name], [subject], [day], [time], [teacher_id], [capacity], [room], [start_date], [end_date], [status])
VALUES
    ('Math Grade 10 A', 'Mathematics', 'Sunday', '09:00:00', 1, 25, 'Room 101', '2024-09-01', '2025-06-30', 'Active'),
    ('Physics Grade 11 B', 'Physics', 'Monday', '10:30:00', 2, 20, 'Lab 201', '2024-09-01', '2025-06-30', 'Active'),
    ('Chemistry Grade 12 A', 'Chemistry', 'Tuesday', '08:00:00', 3, 22, 'Lab 301', '2024-09-01', '2025-06-30', 'Active'),
    ('Biology Grade 10 C', 'Biology', 'Wednesday', '11:00:00', 4, 24, 'Lab 401', '2024-09-01', '2025-06-30', 'Active'),
    ('English Grade 11 A', 'English', 'Thursday', '09:30:00', 5, 30, 'Room 501', '2024-09-01', '2025-06-30', 'Active'),
    ('Arabic Grade 12 B', 'Arabic', 'Sunday', '14:00:00', 6, 28, 'Room 601', '2024-09-01', '2025-06-30', 'Active'),
    ('History Grade 10 B', 'History', 'Monday', '15:30:00', 7, 26, 'Room 701', '2024-09-01', '2025-06-30', 'Active'),
    ('Geography Grade 11 C', 'Geography', 'Tuesday', '13:00:00', 8, 23, 'Room 801', '2024-09-01', '2025-06-30', 'Active');

-- Insert Enrollments
INSERT INTO [dbo].[Enrollment] ([student_id], [group_id], [enrollment_date], [status])
VALUES
    (1, 1, '2024-08-15', 'Active'), (1, 5, '2024-08-15', 'Active'),
    (2, 1, '2024-08-16', 'Active'), (2, 6, '2024-08-16', 'Active'),
    (3, 2, '2024-08-17', 'Active'), (3, 7, '2024-08-17', 'Active'),
    (4, 2, '2024-08-18', 'Active'), (4, 8, '2024-08-18', 'Active'),
    (5, 3, '2024-08-19', 'Active'), (5, 5, '2024-08-19', 'Active'),
    (6, 3, '2024-08-20', 'Active'), (6, 6, '2024-08-20', 'Active'),
    (7, 4, '2024-08-21', 'Active'), (7, 7, '2024-08-21', 'Active'),
    (8, 4, '2024-08-22', 'Active'), (8, 8, '2024-08-22', 'Active'),
    (9, 1, '2024-08-23', 'Active'), (9, 5, '2024-08-23', 'Active'),
    (10, 2, '2024-08-24', 'Active'), (10, 6, '2024-08-24', 'Active');

-- Insert Exams
INSERT INTO [dbo].[Exams] ([group_id], [exam_name], [exam_date], [duration_minutes], [total_marks], [exam_type], [status], [description], [instructions])
VALUES
    (1, 'Math Midterm Exam', '2024-12-15 09:00:00', 90, 100.00, 'Midterm', 'Scheduled', 'Algebra and Geometry', 'Bring calculator and ruler'),
    (2, 'Physics Quiz 1', '2024-12-10 10:30:00', 45, 50.00, 'Quiz', 'Scheduled', 'Mechanics and Motion', 'No calculators allowed'),
    (3, 'Chemistry Lab Test', '2024-12-20 08:00:00', 120, 75.00, 'Practical', 'Scheduled', 'Organic Chemistry Lab', 'Lab coats required'),
    (4, 'Biology Final Exam', '2025-01-15 11:00:00', 150, 150.00, 'Final', 'Scheduled', 'Complete Biology Curriculum', 'Comprehensive exam'),
    (5, 'English Essay Test', '2024-12-18 09:30:00', 60, 80.00, 'Written', 'Scheduled', 'Creative Writing', 'Choose one of three topics'),
    (6, 'Arabic Literature Quiz', '2024-12-12 14:00:00', 30, 40.00, 'Quiz', 'Scheduled', 'Classical Arabic Poetry', 'Memorization required'),
    (7, 'History Assignment', '2024-12-25 15:30:00', 90, 60.00, 'Assignment', 'Scheduled', 'World War II Research', 'Submit written report'),
    (8, 'Geography Project', '2025-01-10 13:00:00', 120, 100.00, 'Project', 'Scheduled', 'Climate Change Study', 'Group presentation');

-- Insert Sample Sessions
INSERT INTO [dbo].[Sessions] ([group_id], [session_date], [session_time], [duration], [location], [status])
VALUES
    (1, '2024-12-01', '09:00:00', 60, 'Room 101', 'Completed'),
    (1, '2024-12-08', '09:00:00', 60, 'Room 101', 'Completed'),
    (2, '2024-12-02', '10:30:00', 60, 'Lab 201', 'Completed'),
    (2, '2024-12-09', '10:30:00', 60, 'Lab 201', 'Completed'),
    (3, '2024-12-03', '08:00:00', 60, 'Lab 301', 'Completed'),
    (3, '2024-12-10', '08:00:00', 60, 'Lab 301', 'Scheduled'),
    (4, '2024-12-04', '11:00:00', 60, 'Lab 401', 'Completed'),
    (4, '2024-12-11', '11:00:00', 60, 'Lab 401', 'Scheduled');

-- Insert Sample Attendance
INSERT INTO [dbo].[Attendance] ([student_id], [session_id], [status])
VALUES
    (1, 1, 'Present'), (2, 1, 'Present'), (9, 1, 'Absent'),
    (1, 2, 'Present'), (2, 2, 'Late'), (9, 2, 'Present'),
    (3, 3, 'Present'), (4, 3, 'Present'), (10, 3, 'Present'),
    (3, 4, 'Absent'), (4, 4, 'Present'), (10, 4, 'Present'),
    (5, 5, 'Present'), (6, 5, 'Present'),
    (7, 7, 'Present'), (8, 7, 'Present');

-- Insert Sample Payments
INSERT INTO [dbo].[Payments] ([student_id], [amount], [payment_date], [payment_method], [payment_status], [description], [receipt_number])
VALUES
    (1, 500.00, '2024-09-01', 'Cash', 'Completed', 'September Tuition', 'REC001'),
    (2, 500.00, '2024-09-02', 'Bank Transfer', 'Completed', 'September Tuition', 'REC002'),
    (3, 500.00, '2024-09-03', 'Cash', 'Completed', 'September Tuition', 'REC003'),
    (4, 500.00, '2024-09-04', 'Credit Card', 'Completed', 'September Tuition', 'REC004'),
    (5, 500.00, '2024-09-05', 'Cash', 'Completed', 'September Tuition', 'REC005'),
    (1, 500.00, '2024-10-01', 'Cash', 'Completed', 'October Tuition', 'REC006'),
    (2, 500.00, '2024-10-02', 'Bank Transfer', 'Completed', 'October Tuition', 'REC007'),
    (3, 500.00, '2024-10-03', 'Cash', 'Pending', 'October Tuition', 'REC008'),
    (4, 500.00, '2024-10-04', 'Credit Card', 'Completed', 'October Tuition', 'REC009'),
    (5, 500.00, '2024-10-05', 'Cash', 'Completed', 'October Tuition', 'REC010');

-- Insert Sample Grades
INSERT INTO [dbo].[Grades] ([exam_id], [student_id], [score], [grade_letter])
VALUES
    (2, 3, 42.50, 'B+'), (2, 4, 38.00, 'B'), (2, 10, 45.00, 'A-'),
    (6, 2, 35.00, 'B+'), (6, 6, 32.00, 'B'), (6, 10, 38.00, 'A-');

PRINT 'Database setup completed successfully!';
PRINT 'Sample data inserted for testing.';
PRINT 'You can now run the Safwa Management System application.';
