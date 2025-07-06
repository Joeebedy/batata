Public Class Attendance
    Public Property AttendanceId As Integer
    Public Property SessionId As Integer
    Public Property StudentId As Integer
    Public Property Status As String
    Public Property Notes As String
    Public Property CreatedAt As DateTime
    Public Property UpdatedAt As DateTime

    ' Additional properties for joined data
    Public Property StudentName As String
    Public Property SessionDate As Date
    Public Property GroupName As String

    Public Sub New()
        AttendanceId = 0
        SessionId = 0
        StudentId = 0
        Status = "Present"
        Notes = String.Empty
        CreatedAt = DateTime.Now
        UpdatedAt = DateTime.Now
        StudentName = String.Empty
        SessionDate = Date.MinValue
        GroupName = String.Empty
    End Sub

    Public Sub New(attendanceId As Integer, sessionId As Integer, studentId As Integer, 
                   status As String, notes As String, createdAt As DateTime, updatedAt As DateTime)
        Me.AttendanceId = attendanceId
        Me.SessionId = sessionId
        Me.StudentId = studentId
        Me.Status = status
        Me.Notes = notes
        Me.CreatedAt = createdAt
        Me.UpdatedAt = updatedAt
        Me.StudentName = String.Empty
        Me.SessionDate = Date.MinValue
        Me.GroupName = String.Empty
    End Sub

    Public Function IsValid() As Boolean
        Return SessionId > 0 AndAlso StudentId > 0 AndAlso Not String.IsNullOrWhiteSpace(Status)
    End Function

    Public Function IsPresent() As Boolean
        Return Status.Equals("Present", StringComparison.OrdinalIgnoreCase)
    End Function

    Public Function IsAbsent() As Boolean
        Return Status.Equals("Absent", StringComparison.OrdinalIgnoreCase)
    End Function

    Public Function IsLate() As Boolean
        Return Status.Equals("Late", StringComparison.OrdinalIgnoreCase)
    End Function

    Public Overrides Function ToString() As String
        If Not String.IsNullOrEmpty(StudentName) Then
            Return StudentName & " - " & Status
        Else
            Return "Attendance " & AttendanceId.ToString()
        End If
    End Function
End Class
