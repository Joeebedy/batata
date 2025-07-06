Public Class Group
    Public Property GroupId As Integer
    Public Property GroupName As String
    Public Property Subject As String
    Public Property Day As String
    Public Property Time As TimeSpan
    Public Property TeacherId As Integer
    Public Property TeacherName As String
    Public Property Capacity As Integer
    Public Property Room As String
    Public Property StartDate As Date
    Public Property EndDate As Date
    Public Property Status As String
    Public Property CreatedAt As DateTime
    Public Property UpdatedAt As DateTime

    Public Sub New()
        GroupId = 0
        GroupName = String.Empty
        Subject = String.Empty
        Day = String.Empty
        Time = TimeSpan.Zero
        TeacherId = 0
        TeacherName = String.Empty
        Capacity = 30
        Room = String.Empty
        StartDate = Date.MinValue
        EndDate = Date.MinValue
        Status = "Active"
        CreatedAt = DateTime.Now
        UpdatedAt = DateTime.Now
    End Sub

    Public Sub New(groupId As Integer, groupName As String, subject As String, day As String, 
                   time As TimeSpan, teacherId As Integer, teacherName As String, capacity As Integer, 
                   room As String, startDate As Date, endDate As Date, status As String, 
                   createdAt As DateTime, updatedAt As DateTime)
        Me.GroupId = groupId
        Me.GroupName = groupName
        Me.Subject = subject
        Me.Day = day
        Me.Time = time
        Me.TeacherId = teacherId
        Me.TeacherName = teacherName
        Me.Capacity = capacity
        Me.Room = room
        Me.StartDate = startDate
        Me.EndDate = endDate
        Me.Status = status
        Me.CreatedAt = createdAt
        Me.UpdatedAt = updatedAt
    End Sub

    Public Function IsValid() As Boolean
        Return Not String.IsNullOrWhiteSpace(GroupName) AndAlso 
               Not String.IsNullOrWhiteSpace(Subject) AndAlso 
               Not String.IsNullOrWhiteSpace(Day) AndAlso 
               TeacherId > 0
    End Function

    Public Function GetDisplayName() As String
        Return GroupName & " - " & Subject
    End Function

    Public Function GetScheduleInfo() As String
        Return Day & " at " & Time.ToString("hh\:mm")
    End Function

    Public Overrides Function ToString() As String
        Return GroupName
    End Function
End Class
