Public Class Session
    Public Property SessionId As Integer
    Public Property GroupId As Integer
    Public Property SessionDate As Date
    Public Property StartTime As TimeSpan
    Public Property EndTime As TimeSpan
    Public Property Topic As String
    Public Property Notes As String
    Public Property Status As String
    Public Property CreatedAt As DateTime
    Public Property UpdatedAt As DateTime

    ' Additional properties for joined data
    Public Property GroupName As String
    Public Property Subject As String

    Public Sub New()
        SessionId = 0
        GroupId = 0
        SessionDate = Date.Today
        StartTime = TimeSpan.Zero
        EndTime = TimeSpan.Zero
        Topic = String.Empty
        Notes = String.Empty
        Status = "Scheduled"
        CreatedAt = DateTime.Now
        UpdatedAt = DateTime.Now
        GroupName = String.Empty
        Subject = String.Empty
    End Sub

    Public Sub New(sessionId As Integer, groupId As Integer, sessionDate As Date, 
                   startTime As TimeSpan, endTime As TimeSpan, topic As String, 
                   notes As String, status As String, createdAt As DateTime, updatedAt As DateTime)
        Me.SessionId = sessionId
        Me.GroupId = groupId
        Me.SessionDate = sessionDate
        Me.StartTime = startTime
        Me.EndTime = endTime
        Me.Topic = topic
        Me.Notes = notes
        Me.Status = status
        Me.CreatedAt = createdAt
        Me.UpdatedAt = updatedAt
        Me.GroupName = String.Empty
        Me.Subject = String.Empty
    End Sub

    Public Function IsValid() As Boolean
        Return GroupId > 0 AndAlso SessionDate <> Date.MinValue
    End Function

    Public Function GetDuration() As TimeSpan
        If EndTime > StartTime Then
            Return EndTime - StartTime
        Else
            Return TimeSpan.Zero
        End If
    End Function

    Public Function GetDisplayInfo() As String
        Dim info As String = SessionDate.ToShortDateString()
        If Not String.IsNullOrEmpty(GroupName) Then
            info &= " - " & GroupName
        End If
        If Not String.IsNullOrEmpty(Topic) Then
            info &= " (" & Topic & ")"
        End If
        Return info
    End Function

    Public Overrides Function ToString() As String
        Return GetDisplayInfo()
    End Function
End Class
