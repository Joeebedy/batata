Public Class Teacher
    Public Property TeacherId As Integer
    Public Property TeacherName As String
    Public Property Specialization As String
    Public Property PhoneNumber As String
    Public Property Email As String
    Public Property Notes As String
    Public Property Status As String
    Public Property HireDate As Date
    Public Property CreatedAt As DateTime
    Public Property UpdatedAt As DateTime

    Public Sub New()
        TeacherId = 0
        TeacherName = String.Empty
        Specialization = String.Empty
        PhoneNumber = String.Empty
        Email = String.Empty
        Notes = String.Empty
        Status = "Active"
        HireDate = Date.Today
        CreatedAt = DateTime.Now
        UpdatedAt = DateTime.Now
    End Sub

    Public Sub New(teacherId As Integer, teacherName As String, specialization As String, 
                   phoneNumber As String, email As String, notes As String, status As String, 
                   hireDate As Date, createdAt As DateTime, updatedAt As DateTime)
        Me.TeacherId = teacherId
        Me.TeacherName = teacherName
        Me.Specialization = specialization
        Me.PhoneNumber = phoneNumber
        Me.Email = email
        Me.Notes = notes
        Me.Status = status
        Me.HireDate = hireDate
        Me.CreatedAt = createdAt
        Me.UpdatedAt = updatedAt
    End Sub

    Public Function IsValid() As Boolean
        Return Not String.IsNullOrWhiteSpace(TeacherName)
    End Function

    Public Function GetDisplayName() As String
        If Not String.IsNullOrWhiteSpace(Specialization) Then
            Return TeacherName & " (" & Specialization & ")"
        Else
            Return TeacherName
        End If
    End Function

    Public Overrides Function ToString() As String
        Return TeacherName
    End Function
End Class
