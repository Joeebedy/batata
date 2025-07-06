Public Class Student
    Public Property StudentId As Integer
    Public Property StudentName As String
    Public Property GuardianName As String
    Public Property GuardianPhone As String
    Public Property StudentPhone As String
    Public Property Address As String
    Public Property BirthDate As Date
    Public Property Notes As String
    Public Property Status As String
    Public Property CreatedAt As DateTime
    Public Property UpdatedAt As DateTime

    Public Sub New()
        StudentId = 0
        StudentName = String.Empty
        GuardianName = String.Empty
        GuardianPhone = String.Empty
        StudentPhone = String.Empty
        Address = String.Empty
        BirthDate = Date.MinValue
        Notes = String.Empty
        Status = "Active"
        CreatedAt = DateTime.Now
        UpdatedAt = DateTime.Now
    End Sub

    Public Sub New(studentId As Integer, studentName As String, guardianName As String, 
                   guardianPhone As String, studentPhone As String, address As String, 
                   birthDate As Date, notes As String, status As String, 
                   createdAt As DateTime, updatedAt As DateTime)
        Me.StudentId = studentId
        Me.StudentName = studentName
        Me.GuardianName = guardianName
        Me.GuardianPhone = guardianPhone
        Me.StudentPhone = studentPhone
        Me.Address = address
        Me.BirthDate = birthDate
        Me.Notes = notes
        Me.Status = status
        Me.CreatedAt = createdAt
        Me.UpdatedAt = updatedAt
    End Sub

    Public Function IsValid() As Boolean
        Return Not String.IsNullOrWhiteSpace(StudentName)
    End Function

    Public Function GetDisplayName() As String
        Return StudentName
    End Function

    Public Function GetAge() As Integer
        If BirthDate = Date.MinValue Then
            Return 0
        End If
        Dim today As Date = Date.Today
        Dim age As Integer = today.Year - BirthDate.Year
        If BirthDate.Date > today.AddYears(-age) Then
            age -= 1
        End If
        Return age
    End Function

    Public Overrides Function ToString() As String
        Return StudentName
    End Function
End Class
