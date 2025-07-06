Public Class StudentAddEdit
    Private _studentId As Integer = 0
    Private _isEditMode As Boolean = False

    Public Sub New()
        InitializeComponent()
        _isEditMode = False
        Me.Text = "Add Student"
    End Sub

    Public Sub New(studentId As Integer)
        InitializeComponent()
        _studentId = studentId
        _isEditMode = True
        Me.Text = "Edit Student"
    End Sub

    Private Sub StudentAddEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _isEditMode Then
            LoadStudentData()
        End If
    End Sub

    Private Sub LoadStudentData()
        Try
            Dim dt As DataTable = DatabaseManager.GetStudentById(_studentId)
            If dt.Rows.Count > 0 Then
                Dim row As DataRow = dt.Rows(0)
                txtStudentName.Text = row("student_name").ToString()
                txtGuardianName.Text = row("guardian_name").ToString()
                txtGuardianPhone.Text = row("guardian_phone").ToString()
                txtStudentPhone.Text = row("student_phone").ToString()
                txtAddress.Text = row("address").ToString()
                txtNotes.Text = row("notes").ToString()
                cmbStatus.Text = row("status").ToString()
                
                If Not IsDBNull(row("birth_date")) Then
                    dtpBirthDate.Value = Convert.ToDateTime(row("birth_date"))
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading student data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not ValidateInput() Then
            Return
        End If

        Try
            If _isEditMode Then
                DatabaseManager.UpdateStudent(_studentId, txtStudentName.Text, txtGuardianName.Text, 
                                            txtGuardianPhone.Text, txtStudentPhone.Text, txtAddress.Text, 
                                            dtpBirthDate.Value, txtNotes.Text, cmbStatus.Text)
                MessageBox.Show("Student updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                DatabaseManager.AddStudent(txtStudentName.Text, txtGuardianName.Text, 
                                         txtGuardianPhone.Text, txtStudentPhone.Text, txtAddress.Text, 
                                         dtpBirthDate.Value, txtNotes.Text)
                MessageBox.Show("Student added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error saving student: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateInput() As Boolean
        If String.IsNullOrWhiteSpace(txtStudentName.Text) Then
            MessageBox.Show("Student name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtStudentName.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class
