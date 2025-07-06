Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class StudentManagement
    Private Sub StudentManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadStudents()
        SetupDataGridView()
    End Sub

    Private Sub SetupDataGridView()
        With dgvStudents
            .AutoGenerateColumns = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End With
    End Sub

    Private Sub LoadStudents()
        Try
            Dim dt As DataTable = DatabaseManager.GetAllStudents()
            dgvStudents.DataSource = dt
            
            ' Update record count
            lblRecordCount.Text = "Total Students: " & dt.Rows.Count.ToString()
            
            ' Hide ID column if it exists
            If dgvStudents.Columns.Contains("student_id") Then
                dgvStudents.Columns("student_id").Visible = False
            End If
            
            ' Set column headers
            If dgvStudents.Columns.Contains("student_name") Then
                dgvStudents.Columns("student_name").HeaderText = "Student Name"
            End If
            If dgvStudents.Columns.Contains("guardian_name") Then
                dgvStudents.Columns("guardian_name").HeaderText = "Guardian Name"
            End If
            If dgvStudents.Columns.Contains("guardian_phone") Then
                dgvStudents.Columns("guardian_phone").HeaderText = "Guardian Phone"
            End If
            If dgvStudents.Columns.Contains("student_phone") Then
                dgvStudents.Columns("student_phone").HeaderText = "Student Phone"
            End If
            If dgvStudents.Columns.Contains("birth_date") Then
                dgvStudents.Columns("birth_date").HeaderText = "Birth Date"
            End If
            If dgvStudents.Columns.Contains("status") Then
                dgvStudents.Columns("status").HeaderText = "Status"
            End If
            
        Catch ex As Exception
            MessageBox.Show("Error loading students: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            Dim addForm As New StudentAddEdit()
            If addForm.ShowDialog() = DialogResult.OK Then
                LoadStudents()
            End If
        Catch ex As Exception
            MessageBox.Show("Error opening add student form: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgvStudents.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a student to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            Dim selectedRow As DataGridViewRow = dgvStudents.SelectedRows(0)
            Dim studentId As Integer = Convert.ToInt32(selectedRow.Cells("student_id").Value)
            
            Dim editForm As New StudentAddEdit(studentId)
            If editForm.ShowDialog() = DialogResult.OK Then
                LoadStudents()
            End If
        Catch ex As Exception
            MessageBox.Show("Error opening edit student form: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvStudents.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a student to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            Dim selectedRow As DataGridViewRow = dgvStudents.SelectedRows(0)
            Dim studentId As Integer = Convert.ToInt32(selectedRow.Cells("student_id").Value)
            Dim studentName As String = selectedRow.Cells("student_name").Value.ToString()
            
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete student '" & studentName & "'?" & vbCrLf & 
                                                       "This will mark the student as inactive.", 
                                                       "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            
            If result = DialogResult.Yes Then
                DatabaseManager.DeleteStudent(studentId)
                MessageBox.Show("Student deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadStudents()
            End If
        Catch ex As Exception
            MessageBox.Show("Error deleting student: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadStudents()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim searchTerm As String = txtSearch.Text.Trim()
        
        If String.IsNullOrEmpty(searchTerm) Then
            LoadStudents()
            Return
        End If

        Try
            Dim query As String = "SELECT * FROM Students WHERE " &
                                 "student_name LIKE @SearchTerm OR " &
                                 "guardian_name LIKE @SearchTerm OR " &
                                 "guardian_phone LIKE @SearchTerm OR " &
                                 "student_phone LIKE @SearchTerm " &
                                 "ORDER BY student_name"
            
            Dim parameters() As SqlParameter = {
                New SqlParameter("@SearchTerm", "%" & searchTerm & "%")
            }
            
            Dim dt As DataTable = DatabaseManager.ExecuteQuery(query, parameters)
            dgvStudents.DataSource = dt
            lblRecordCount.Text = "Search Results: " & dt.Rows.Count.ToString()
            
        Catch ex As Exception
            MessageBox.Show("Error searching students: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearch.KeyPress
        If e.KeyChar = Chr(13) Then ' Enter key
            btnSearch_Click(sender, e)
        End If
    End Sub

    Private Sub dgvStudents_DoubleClick(sender As Object, e As EventArgs) Handles dgvStudents.DoubleClick
        btnEdit_Click(sender, e)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class
