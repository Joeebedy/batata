Imports System.Data.SqlClient
Imports System.Configuration

Public Class DatabaseManager
    Private Shared _connectionString As String = ConfigurationManager.ConnectionStrings("SafwaConnection").ConnectionString

    Public Shared Function GetConnection() As SqlConnection
        Return New SqlConnection(_connectionString)
    End Function

    Public Shared Function ExecuteQuery(query As String, Optional parameters As SqlParameter() = Nothing) As DataTable
        Dim dataTable As New DataTable()
        Try
            Using connection As SqlConnection = GetConnection()
                Using command As New SqlCommand(query, connection)
                    If parameters IsNot Nothing Then
                        command.Parameters.AddRange(parameters)
                    End If
                    connection.Open()
                    Using adapter As New SqlDataAdapter(command)
                        adapter.Fill(dataTable)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Database query error: " & ex.Message, ex)
        End Try
        Return dataTable
    End Function

    Public Shared Function ExecuteNonQuery(query As String, Optional parameters As SqlParameter() = Nothing) As Integer
        Dim rowsAffected As Integer = 0
        Try
            Using connection As SqlConnection = GetConnection()
                Using command As New SqlCommand(query, connection)
                    If parameters IsNot Nothing Then
                        command.Parameters.AddRange(parameters)
                    End If
                    connection.Open()
                    rowsAffected = command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Database execution error: " & ex.Message, ex)
        End Try
        Return rowsAffected
    End Function

    Public Shared Function ExecuteScalar(query As String, Optional parameters As SqlParameter() = Nothing) As Object
        Dim result As Object = Nothing
        Try
            Using connection As SqlConnection = GetConnection()
                Using command As New SqlCommand(query, connection)
                    If parameters IsNot Nothing Then
                        command.Parameters.AddRange(parameters)
                    End If
                    connection.Open()
                    result = command.ExecuteScalar()
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Database scalar query error: " & ex.Message, ex)
        End Try
        Return result
    End Function

    ' Student Management Methods
    Public Shared Function GetAllStudents() As DataTable
        Dim query As String = "SELECT * FROM Students ORDER BY student_name"
        Return ExecuteQuery(query)
    End Function

    Public Shared Function GetStudentById(studentId As Integer) As DataTable
        Dim query As String = "SELECT * FROM Students WHERE student_id = @StudentId"
        Dim parameters() As SqlParameter = {New SqlParameter("@StudentId", studentId)}
        Return ExecuteQuery(query, parameters)
    End Function

    Public Shared Function AddStudent(studentName As String, guardianName As String, guardianPhone As String, 
                                    studentPhone As String, address As String, birthDate As Date, notes As String) As Integer
        Dim query As String = "INSERT INTO Students (student_name, guardian_name, guardian_phone, student_phone, address, birth_date, notes) " &
                             "VALUES (@StudentName, @GuardianName, @GuardianPhone, @StudentPhone, @Address, @BirthDate, @Notes); " &
                             "SELECT SCOPE_IDENTITY();"
        Dim parameters() As SqlParameter = {
            New SqlParameter("@StudentName", studentName),
            New SqlParameter("@GuardianName", If(String.IsNullOrEmpty(guardianName), DBNull.Value, guardianName)),
            New SqlParameter("@GuardianPhone", If(String.IsNullOrEmpty(guardianPhone), DBNull.Value, guardianPhone)),
            New SqlParameter("@StudentPhone", If(String.IsNullOrEmpty(studentPhone), DBNull.Value, studentPhone)),
            New SqlParameter("@Address", If(String.IsNullOrEmpty(address), DBNull.Value, address)),
            New SqlParameter("@BirthDate", If(birthDate = Date.MinValue, DBNull.Value, birthDate)),
            New SqlParameter("@Notes", If(String.IsNullOrEmpty(notes), DBNull.Value, notes))
        }
        Return Convert.ToInt32(ExecuteScalar(query, parameters))
    End Function

    Public Shared Function UpdateStudent(studentId As Integer, studentName As String, guardianName As String, 
                                       guardianPhone As String, studentPhone As String, address As String, 
                                       birthDate As Date, notes As String, status As String) As Integer
        Dim query As String = "UPDATE Students SET student_name = @StudentName, guardian_name = @GuardianName, " &
                             "guardian_phone = @GuardianPhone, student_phone = @StudentPhone, address = @Address, " &
                             "birth_date = @BirthDate, notes = @Notes, status = @Status, updated_at = GETDATE() " &
                             "WHERE student_id = @StudentId"
        Dim parameters() As SqlParameter = {
            New SqlParameter("@StudentId", studentId),
            New SqlParameter("@StudentName", studentName),
            New SqlParameter("@GuardianName", If(String.IsNullOrEmpty(guardianName), DBNull.Value, guardianName)),
            New SqlParameter("@GuardianPhone", If(String.IsNullOrEmpty(guardianPhone), DBNull.Value, guardianPhone)),
            New SqlParameter("@StudentPhone", If(String.IsNullOrEmpty(studentPhone), DBNull.Value, studentPhone)),
            New SqlParameter("@Address", If(String.IsNullOrEmpty(address), DBNull.Value, address)),
            New SqlParameter("@BirthDate", If(birthDate = Date.MinValue, DBNull.Value, birthDate)),
            New SqlParameter("@Notes", If(String.IsNullOrEmpty(notes), DBNull.Value, notes)),
            New SqlParameter("@Status", status)
        }
        Return ExecuteNonQuery(query, parameters)
    End Function

    Public Shared Function DeleteStudent(studentId As Integer) As Integer
        Dim query As String = "UPDATE Students SET status = 'Inactive', updated_at = GETDATE() WHERE student_id = @StudentId"
        Dim parameters() As SqlParameter = {New SqlParameter("@StudentId", studentId)}
        Return ExecuteNonQuery(query, parameters)
    End Function

    ' Teacher Management Methods
    Public Shared Function GetAllTeachers() As DataTable
        Dim query As String = "SELECT * FROM Teachers ORDER BY teacher_name"
        Return ExecuteQuery(query)
    End Function

    Public Shared Function GetTeacherById(teacherId As Integer) As DataTable
        Dim query As String = "SELECT * FROM Teachers WHERE teacher_id = @TeacherId"
        Dim parameters() As SqlParameter = {New SqlParameter("@TeacherId", teacherId)}
        Return ExecuteQuery(query, parameters)
    End Function

    Public Shared Function AddTeacher(teacherName As String, specialization As String, phoneNumber As String, 
                                    email As String, notes As String) As Integer
        Dim query As String = "INSERT INTO Teachers (teacher_name, specialization, phone_number, email, notes) " &
                             "VALUES (@TeacherName, @Specialization, @PhoneNumber, @Email, @Notes); " &
                             "SELECT SCOPE_IDENTITY();"
        Dim parameters() As SqlParameter = {
            New SqlParameter("@TeacherName", teacherName),
            New SqlParameter("@Specialization", If(String.IsNullOrEmpty(specialization), DBNull.Value, specialization)),
            New SqlParameter("@PhoneNumber", If(String.IsNullOrEmpty(phoneNumber), DBNull.Value, phoneNumber)),
            New SqlParameter("@Email", If(String.IsNullOrEmpty(email), DBNull.Value, email)),
            New SqlParameter("@Notes", If(String.IsNullOrEmpty(notes), DBNull.Value, notes))
        }
        Return Convert.ToInt32(ExecuteScalar(query, parameters))
    End Function

    Public Shared Function UpdateTeacher(teacherId As Integer, teacherName As String, specialization As String, 
                                       phoneNumber As String, email As String, notes As String, status As String) As Integer
        Dim query As String = "UPDATE Teachers SET teacher_name = @TeacherName, specialization = @Specialization, " &
                             "phone_number = @PhoneNumber, email = @Email, notes = @Notes, status = @Status, " &
                             "updated_at = GETDATE() WHERE teacher_id = @TeacherId"
        Dim parameters() As SqlParameter = {
            New SqlParameter("@TeacherId", teacherId),
            New SqlParameter("@TeacherName", teacherName),
            New SqlParameter("@Specialization", If(String.IsNullOrEmpty(specialization), DBNull.Value, specialization)),
            New SqlParameter("@PhoneNumber", If(String.IsNullOrEmpty(phoneNumber), DBNull.Value, phoneNumber)),
            New SqlParameter("@Email", If(String.IsNullOrEmpty(email), DBNull.Value, email)),
            New SqlParameter("@Notes", If(String.IsNullOrEmpty(notes), DBNull.Value, notes)),
            New SqlParameter("@Status", status)
        }
        Return ExecuteNonQuery(query, parameters)
    End Function

    Public Shared Function DeleteTeacher(teacherId As Integer) As Integer
        Dim query As String = "UPDATE Teachers SET status = 'Inactive', updated_at = GETDATE() WHERE teacher_id = @TeacherId"
        Dim parameters() As SqlParameter = {New SqlParameter("@TeacherId", teacherId)}
        Return ExecuteNonQuery(query, parameters)
    End Function

    ' Group Management Methods
    Public Shared Function GetAllGroups() As DataTable
        Dim query As String = "SELECT g.*, t.teacher_name FROM Groups g " &
                             "LEFT JOIN Teachers t ON g.teacher_id = t.teacher_id " &
                             "ORDER BY g.group_name"
        Return ExecuteQuery(query)
    End Function

    Public Shared Function GetGroupById(groupId As Integer) As DataTable
        Dim query As String = "SELECT g.*, t.teacher_name FROM Groups g " &
                             "LEFT JOIN Teachers t ON g.teacher_id = t.teacher_id " &
                             "WHERE g.group_id = @GroupId"
        Dim parameters() As SqlParameter = {New SqlParameter("@GroupId", groupId)}
        Return ExecuteQuery(query, parameters)
    End Function

    Public Shared Function AddGroup(groupName As String, subject As String, day As String, time As TimeSpan, 
                                  teacherId As Integer, capacity As Integer, room As String, 
                                  startDate As Date, endDate As Date) As Integer
        Dim query As String = "INSERT INTO Groups (group_name, subject, day, time, teacher_id, capacity, room, start_date, end_date) " &
                             "VALUES (@GroupName, @Subject, @Day, @Time, @TeacherId, @Capacity, @Room, @StartDate, @EndDate); " &
                             "SELECT SCOPE_IDENTITY();"
        Dim parameters() As SqlParameter = {
            New SqlParameter("@GroupName", groupName),
            New SqlParameter("@Subject", subject),
            New SqlParameter("@Day", day),
            New SqlParameter("@Time", time),
            New SqlParameter("@TeacherId", teacherId),
            New SqlParameter("@Capacity", capacity),
            New SqlParameter("@Room", If(String.IsNullOrEmpty(room), DBNull.Value, room)),
            New SqlParameter("@StartDate", If(startDate = Date.MinValue, DBNull.Value, startDate)),
            New SqlParameter("@EndDate", If(endDate = Date.MinValue, DBNull.Value, endDate))
        }
        Return Convert.ToInt32(ExecuteScalar(query, parameters))
    End Function

    ' Test Database Connection
    Public Shared Function TestConnection() As Boolean
        Try
            Using connection As SqlConnection = GetConnection()
                connection.Open()
                Return True
            End Using
        Catch
            Return False
        End Try
    End Function
End Class
