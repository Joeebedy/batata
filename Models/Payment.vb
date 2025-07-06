Public Class Payment
    Public Property PaymentId As Integer
    Public Property StudentId As Integer
    Public Property Amount As Decimal
    Public Property PaymentDate As Date
    Public Property PaymentMethod As String
    Public Property Notes As String
    Public Property Status As String
    Public Property CreatedAt As DateTime
    Public Property UpdatedAt As DateTime

    ' Additional properties for joined data
    Public Property StudentName As String

    Public Sub New()
        PaymentId = 0
        StudentId = 0
        Amount = 0
        PaymentDate = Date.Today
        PaymentMethod = "Cash"
        Notes = String.Empty
        Status = "Completed"
        CreatedAt = DateTime.Now
        UpdatedAt = DateTime.Now
        StudentName = String.Empty
    End Sub

    Public Sub New(paymentId As Integer, studentId As Integer, amount As Decimal, 
                   paymentDate As Date, paymentMethod As String, notes As String, 
                   status As String, createdAt As DateTime, updatedAt As DateTime)
        Me.PaymentId = paymentId
        Me.StudentId = studentId
        Me.Amount = amount
        Me.PaymentDate = paymentDate
        Me.PaymentMethod = paymentMethod
        Me.Notes = notes
        Me.Status = status
        Me.CreatedAt = createdAt
        Me.UpdatedAt = updatedAt
        Me.StudentName = String.Empty
    End Sub

    Public Function IsValid() As Boolean
        Return StudentId > 0 AndAlso Amount > 0 AndAlso PaymentDate <> Date.MinValue
    End Function

    Public Function GetFormattedAmount() As String
        Return Amount.ToString("C")
    End Function

    Public Function IsCompleted() As Boolean
        Return Status.Equals("Completed", StringComparison.OrdinalIgnoreCase)
    End Function

    Public Function IsPending() As Boolean
        Return Status.Equals("Pending", StringComparison.OrdinalIgnoreCase)
    End Function

    Public Function IsCancelled() As Boolean
        Return Status.Equals("Cancelled", StringComparison.OrdinalIgnoreCase)
    End Function

    Public Overrides Function ToString() As String
        Dim info As String = GetFormattedAmount() & " - " & PaymentDate.ToShortDateString()
        If Not String.IsNullOrEmpty(StudentName) Then
            info = StudentName & " - " & info
        End If
        Return info
    End Function
End Class
