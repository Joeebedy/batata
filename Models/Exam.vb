Public Class Exam
    Public Property ExamId As Integer
    Public Property GroupId As Integer
    Public Property ExamName As String
    Public Property ExamType As String
    Public Property ExamDate As Date
    Public Property StartTime As TimeSpan
    Public Property DurationMinutes As Integer
    Public Property TotalMarks As Decimal
    Public Property Instructions As String
    Public Property Status As String
    Public Property CreatedAt As DateTime
    Public Property UpdatedAt As DateTime

    ' Additional properties for joined data
    Public Property GroupName As String
    Public Property Subject As String

    Public Sub New()
        ExamId = 0
        GroupId = 0
        ExamName = String.Empty
        ExamType = "Quiz"
        ExamDate = Date.Today
        StartTime = TimeSpan.Zero
        DurationMinutes = 60
        TotalMarks = 100
        Instructions = String.Empty
        Status = "Scheduled"
        CreatedAt = DateTime.Now
        UpdatedAt = DateTime.Now
        GroupName = String.Empty
        Subject = String.Empty
    End Sub

    Public Sub New(examId As Integer, groupId As Integer, examName As String, examType As String, 
                   examDate As Date, startTime As TimeSpan, durationMinutes As Integer, 
                   totalMarks As Decimal, instructions As String, status As String, 
                   createdAt As DateTime, updatedAt As DateTime)
        Me.ExamId = examId
        Me.GroupId = groupId
        Me.ExamName = examName
        Me.ExamType = examType
        Me.ExamDate = examDate
        Me.StartTime = startTime
        Me.DurationMinutes = durationMinutes
        Me.TotalMarks = totalMarks
        Me.Instructions = instructions
        Me.Status = status
        Me.CreatedAt = createdAt
        Me.UpdatedAt = updatedAt
        Me.GroupName = String.Empty
        Me.Subject = String.Empty
    End Sub

    Public Function IsValid() As Boolean
        Return GroupId > 0 AndAlso 
               Not String.IsNullOrWhiteSpace(ExamName) AndAlso 
               ExamDate <> Date.MinValue AndAlso 
               DurationMinutes > 0 AndAlso 
               TotalMarks > 0
    End Function

    Public Function GetEndTime() As TimeSpan
        Return StartTime.Add(TimeSpan.FromMinutes(DurationMinutes))
    End Function

    Public Function GetDurationFormatted() As String
        Dim hours As Integer = DurationMinutes \ 60
        Dim minutes As Integer = DurationMinutes Mod 60
        
        If hours > 0 Then
            Return hours.ToString() & "h " & minutes.ToString() & "m"
        Else
            Return minutes.ToString() & " minutes"
        End If
    End Function

    Public Function IsScheduled() As Boolean
        Return Status.Equals("Scheduled", StringComparison.OrdinalIgnoreCase)
    End Function

    Public Function IsInProgress() As Boolean
        Return Status.Equals("In Progress", StringComparison.OrdinalIgnoreCase)
    End Function

    Public Function IsCompleted() As Boolean
        Return Status.Equals("Completed", StringComparison.OrdinalIgnoreCase)
    End Function

    Public Function IsCancelled() As Boolean
        Return Status.Equals("Cancelled", StringComparison.OrdinalIgnoreCase)
    End Function

    Public Function GetDisplayInfo() As String
        Dim info As String = ExamName & " (" & ExamType & ")"
        If Not String.IsNullOrEmpty(GroupName) Then
            info &= " - " & GroupName
        End If
        info &= " - " & ExamDate.ToShortDateString()
        Return info
    End Function

    Public Overrides Function ToString() As String
        Return ExamName
    End Function
End Class
