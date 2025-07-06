Public Class Grade
    Public Property GradeId As Integer
    Public Property ExamId As Integer
    Public Property StudentId As Integer
    Public Property Score As Decimal
    Public Property Feedback As String
    Public Property CreatedAt As DateTime
    Public Property UpdatedAt As DateTime

    ' Additional properties for joined data
    Public Property StudentName As String
    Public Property ExamName As String
    Public Property TotalMarks As Decimal

    Public Sub New()
        GradeId = 0
        ExamId = 0
        StudentId = 0
        Score = 0
        Feedback = String.Empty
        CreatedAt = DateTime.Now
        UpdatedAt = DateTime.Now
        StudentName = String.Empty
        ExamName = String.Empty
        TotalMarks = 0
    End Sub

    Public Sub New(gradeId As Integer, examId As Integer, studentId As Integer, 
                   score As Decimal, feedback As String, createdAt As DateTime, updatedAt As DateTime)
        Me.GradeId = gradeId
        Me.ExamId = examId
        Me.StudentId = studentId
        Me.Score = score
        Me.Feedback = feedback
        Me.CreatedAt = createdAt
        Me.UpdatedAt = updatedAt
        Me.StudentName = String.Empty
        Me.ExamName = String.Empty
        Me.TotalMarks = 0
    End Sub

    Public Function IsValid() As Boolean
        Return ExamId > 0 AndAlso StudentId > 0 AndAlso Score >= 0
    End Function

    Public Function GetPercentage() As Decimal
        If TotalMarks > 0 Then
            Return (Score / TotalMarks) * 100
        Else
            Return 0
        End If
    End Function

    Public Function GetLetterGrade() As String
        Dim percentage As Decimal = GetPercentage()
        
        If percentage >= 90 Then
            Return "A"
        ElseIf percentage >= 80 Then
            Return "B"
        ElseIf percentage >= 70 Then
            Return "C"
        ElseIf percentage >= 60 Then
            Return "D"
        Else
            Return "F"
        End If
    End Function

    Public Function GetGradeStatus() As String
        Dim percentage As Decimal = GetPercentage()
        
        If percentage >= 60 Then
            Return "Pass"
        Else
            Return "Fail"
        End If
    End Function

    Public Function GetFormattedScore() As String
        If TotalMarks > 0 Then
            Return Score.ToString("0.##") & "/" & TotalMarks.ToString("0.##") & " (" & GetPercentage().ToString("0.#") & "%)"
        Else
            Return Score.ToString("0.##")
        End If
    End Function

    Public Overrides Function ToString() As String
        Dim info As String = GetFormattedScore()
        If Not String.IsNullOrEmpty(StudentName) AndAlso Not String.IsNullOrEmpty(ExamName) Then
            info = StudentName & " - " & ExamName & " - " & info
        End If
        Return info
    End Function
End Class
