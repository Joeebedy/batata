Imports System.Windows.Forms

Public Class MainDashboard
    Private Sub MainDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Test database connection on startup
            If DatabaseManager.TestConnection() Then
                lblConnectionStatus.Text = "Database Connected"
                lblConnectionStatus.ForeColor = Color.Green
                LoadDashboardData()
            Else
                lblConnectionStatus.Text = "Database Connection Failed"
                lblConnectionStatus.ForeColor = Color.Red
                MessageBox.Show("Unable to connect to the database. Please check your connection settings.", 
                              "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error initializing application: " & ex.Message, 
                          "Initialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadDashboardData()
        Try
            ' Load summary statistics
            LoadStudentCount()
            LoadTeacherCount()
            LoadGroupCount()
            LoadUpcomingExams()
        Catch ex As Exception
            MessageBox.Show("Error loading dashboard data: " & ex.Message, 
                          "Data Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub LoadStudentCount()
        Try
            Dim dt As DataTable = DatabaseManager.ExecuteQuery("SELECT COUNT(*) FROM Students WHERE status = 'Active'")
            If dt.Rows.Count > 0 Then
                lblStudentCount.Text = dt.Rows(0)(0).ToString()
            End If
        Catch ex As Exception
            lblStudentCount.Text = "Error"
        End Try
    End Sub

    Private Sub LoadTeacherCount()
        Try
            Dim dt As DataTable = DatabaseManager.ExecuteQuery("SELECT COUNT(*) FROM Teachers WHERE status = 'Active'")
            If dt.Rows.Count > 0 Then
                lblTeacherCount.Text = dt.Rows(0)(0).ToString()
            End If
        Catch ex As Exception
            lblTeacherCount.Text = "Error"
        End Try
    End Sub

    Private Sub LoadGroupCount()
        Try
            Dim dt As DataTable = DatabaseManager.ExecuteQuery("SELECT COUNT(*) FROM Groups WHERE status = 'Active'")
            If dt.Rows.Count > 0 Then
                lblGroupCount.Text = dt.Rows(0)(0).ToString()
            End If
        Catch ex As Exception
            lblGroupCount.Text = "Error"
        End Try
    End Sub

    Private Sub LoadUpcomingExams()
        Try
            Dim query As String = "SELECT TOP 5 e.exam_name, e.exam_date, g.group_name " &
                                 "FROM Exams e " &
                                 "INNER JOIN Groups g ON e.group_id = g.group_id " &
                                 "WHERE e.exam_date >= CAST(GETDATE() AS DATE) AND e.status = 'Scheduled' " &
                                 "ORDER BY e.exam_date ASC"
            Dim dt As DataTable = DatabaseManager.ExecuteQuery(query)
            dgvUpcomingExams.DataSource = dt
        Catch ex As Exception
            ' Handle error silently for dashboard
        End Try
    End Sub

    ' Menu Event Handlers
    Private Sub btnStudents_Click(sender As Object, e As EventArgs) Handles btnStudents.Click
        Try
            Dim studentForm As New StudentManagement()
            studentForm.ShowDialog()
            LoadDashboardData() ' Refresh data after returning
        Catch ex As Exception
            MessageBox.Show("Error opening Student Management: " & ex.Message, 
                          "Navigation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnTeachers_Click(sender As Object, e As EventArgs) Handles btnTeachers.Click
        Try
            Dim teacherForm As New TeacherManagement()
            teacherForm.ShowDialog()
            LoadDashboardData() ' Refresh data after returning
        Catch ex As Exception
            MessageBox.Show("Error opening Teacher Management: " & ex.Message, 
                          "Navigation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnGroups_Click(sender As Object, e As EventArgs) Handles btnGroups.Click
        Try
            Dim groupForm As New GroupManagement()
            groupForm.ShowDialog()
            LoadDashboardData() ' Refresh data after returning
        Catch ex As Exception
            MessageBox.Show("Error opening Group Management: " & ex.Message, 
                          "Navigation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAttendance_Click(sender As Object, e As EventArgs) Handles btnAttendance.Click
        Try
            Dim attendanceForm As New AttendanceManagement()
            attendanceForm.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("Error opening Attendance Management: " & ex.Message, 
                          "Navigation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnPayments_Click(sender As Object, e As EventArgs) Handles btnPayments.Click
        Try
            Dim paymentForm As New PaymentManagement()
            paymentForm.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("Error opening Payment Management: " & ex.Message, 
                          "Navigation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnExams_Click(sender As Object, e As EventArgs) Handles btnExams.Click
        Try
            Dim examForm As New ExamManagement()
            examForm.ShowDialog()
            LoadDashboardData() ' Refresh data after returning
        Catch ex As Exception
            MessageBox.Show("Error opening Exam Management: " & ex.Message, 
                          "Navigation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnReports_Click(sender As Object, e As EventArgs) Handles btnReports.Click
        Try
            Dim reportForm As New ReportsMain()
            reportForm.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("Error opening Reports: " & ex.Message, 
                          "Navigation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadDashboardData()
    End Sub

    Private Sub MainDashboard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to exit the Safwa Management System?", 
                                                    "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then
            e.Cancel = True
        End If
    End Sub
End Class
