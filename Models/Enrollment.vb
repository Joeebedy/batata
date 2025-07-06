Public Class Enrollment
    Public Property EnrollmentId As Integer
    Public Property StudentId As Integer
    Public Property GroupId As Integer
    Public Property EnrollmentDate As Date
    Public Property Status As String
    Public Property CreatedAt As DateTime
    Public Property UpdatedAt As DateTime

    ' Additional properties for joined data
    Public Property StudentName As String
    Public Property GroupName As String

    Public Sub New()
        EnrollmentId = 0
        StudentId = 0
        GroupId = 0
        EnrollmentDate = Date.Today
        Status = "Active"
        CreatedAt = DateTime.Now
        UpdatedAt = DateTime.Now
        StudentName = String.Empty
        GroupName = String.Empty
    End Sub

    Public Sub New(enrollmentId As Integer, studentId As Integer, groupId As Integer, 
                   enrollmentDate As Date, status As String, createdAt As DateTime, updatedAt As DateTime)
        Me.EnrollmentId = enrollmentId
        Me.StudentId = studentId
        Me.GroupId = groupId
        Me.EnrollmentDate = enrollmentDate
        Me.Status = status
        Me.CreatedAt = createdAt
        Me.UpdatedAt = updatedAt
        Me.StudentName = String.Empty
        Me.GroupName = String.Empty
    End Sub

    Public Function IsValid() As Boolean
        Return StudentId > 0 AndAlso GroupId > 0
    End Function

    Public Overrides Function ToString() As String
        If Not String.IsNullOrEmpty(StudentName) AndAlso Not String.IsNullOrEmpty(GroupName) Then
            Return StudentName & " - " & GroupName
        Else
            Return "Enrollment " & EnrollmentId.ToString()
        End If
    End Function
End Class
