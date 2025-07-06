<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainDashboard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblConnectionStatus = New System.Windows.Forms.Label()
        Me.btnStudents = New System.Windows.Forms.Button()
        Me.btnTeachers = New System.Windows.Forms.Button()
        Me.btnGroups = New System.Windows.Forms.Button()
        Me.btnAttendance = New System.Windows.Forms.Button()
        Me.btnPayments = New System.Windows.Forms.Button()
        Me.btnExams = New System.Windows.Forms.Button()
        Me.btnReports = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.lblStudentCount = New System.Windows.Forms.Label()
        Me.lblTeacherCount = New System.Windows.Forms.Label()
        Me.lblGroupCount = New System.Windows.Forms.Label()
        Me.dgvUpcomingExams = New System.Windows.Forms.DataGridView()
        Me.lblStudentsLabel = New System.Windows.Forms.Label()
        Me.lblTeachersLabel = New System.Windows.Forms.Label()
        Me.lblGroupsLabel = New System.Windows.Forms.Label()
        Me.lblUpcomingExamsLabel = New System.Windows.Forms.Label()
        Me.panelStats = New System.Windows.Forms.Panel()
        Me.panelMenu = New System.Windows.Forms.Panel()
        CType(Me.dgvUpcomingExams, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelStats.SuspendLayout()
        Me.panelMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(12, 9)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(318, 29)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Safwa Management System"
        '
        'lblConnectionStatus
        '
        Me.lblConnectionStatus.AutoSize = True
        Me.lblConnectionStatus.Location = New System.Drawing.Point(14, 47)
        Me.lblConnectionStatus.Name = "lblConnectionStatus"
        Me.lblConnectionStatus.Size = New System.Drawing.Size(73, 13)
        Me.lblConnectionStatus.TabIndex = 1
        Me.lblConnectionStatus.Text = "Connecting..."
        '
        'btnStudents
        '
        Me.btnStudents.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStudents.Location = New System.Drawing.Point(10, 10)
        Me.btnStudents.Name = "btnStudents"
        Me.btnStudents.Size = New System.Drawing.Size(120, 50)
        Me.btnStudents.TabIndex = 2
        Me.btnStudents.Text = "Students"
        Me.btnStudents.UseVisualStyleBackColor = True
        '
        'btnTeachers
        '
        Me.btnTeachers.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTeachers.Location = New System.Drawing.Point(140, 10)
        Me.btnTeachers.Name = "btnTeachers"
        Me.btnTeachers.Size = New System.Drawing.Size(120, 50)
        Me.btnTeachers.TabIndex = 3
        Me.btnTeachers.Text = "Teachers"
        Me.btnTeachers.UseVisualStyleBackColor = True
        '
        'btnGroups
        '
        Me.btnGroups.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGroups.Location = New System.Drawing.Point(270, 10)
        Me.btnGroups.Name = "btnGroups"
        Me.btnGroups.Size = New System.Drawing.Size(120, 50)
        Me.btnGroups.TabIndex = 4
        Me.btnGroups.Text = "Groups"
        Me.btnGroups.UseVisualStyleBackColor = True
        '
        'btnAttendance
        '
        Me.btnAttendance.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAttendance.Location = New System.Drawing.Point(400, 10)
        Me.btnAttendance.Name = "btnAttendance"
        Me.btnAttendance.Size = New System.Drawing.Size(120, 50)
        Me.btnAttendance.TabIndex = 5
        Me.btnAttendance.Text = "Attendance"
        Me.btnAttendance.UseVisualStyleBackColor = True
        '
        'btnPayments
        '
        Me.btnPayments.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPayments.Location = New System.Drawing.Point(10, 70)
        Me.btnPayments.Name = "btnPayments"
        Me.btnPayments.Size = New System.Drawing.Size(120, 50)
        Me.btnPayments.TabIndex = 6
        Me.btnPayments.Text = "Payments"
        Me.btnPayments.UseVisualStyleBackColor = True
        '
        'btnExams
        '
        Me.btnExams.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExams.Location = New System.Drawing.Point(140, 70)
        Me.btnExams.Name = "btnExams"
        Me.btnExams.Size = New System.Drawing.Size(120, 50)
        Me.btnExams.TabIndex = 7
        Me.btnExams.Text = "Exams"
        Me.btnExams.UseVisualStyleBackColor = True
        '
        'btnReports
        '
        Me.btnReports.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReports.Location = New System.Drawing.Point(270, 70)
        Me.btnReports.Name = "btnReports"
        Me.btnReports.Size = New System.Drawing.Size(120, 50)
        Me.btnReports.TabIndex = 8
        Me.btnReports.Text = "Reports"
        Me.btnReports.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.Location = New System.Drawing.Point(400, 70)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(120, 50)
        Me.btnRefresh.TabIndex = 9
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'lblStudentCount
        '
        Me.lblStudentCount.AutoSize = True
        Me.lblStudentCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStudentCount.Location = New System.Drawing.Point(10, 30)
        Me.lblStudentCount.Name = "lblStudentCount"
        Me.lblStudentCount.Size = New System.Drawing.Size(21, 24)
        Me.lblStudentCount.TabIndex = 10
        Me.lblStudentCount.Text = "0"
        '
        'lblTeacherCount
        '
        Me.lblTeacherCount.AutoSize = True
        Me.lblTeacherCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTeacherCount.Location = New System.Drawing.Point(140, 30)
        Me.lblTeacherCount.Name = "lblTeacherCount"
        Me.lblTeacherCount.Size = New System.Drawing.Size(21, 24)
        Me.lblTeacherCount.TabIndex = 11
        Me.lblTeacherCount.Text = "0"
        '
        'lblGroupCount
        '
        Me.lblGroupCount.AutoSize = True
        Me.lblGroupCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGroupCount.Location = New System.Drawing.Point(270, 30)
        Me.lblGroupCount.Name = "lblGroupCount"
        Me.lblGroupCount.Size = New System.Drawing.Size(21, 24)
        Me.lblGroupCount.TabIndex = 12
        Me.lblGroupCount.Text = "0"
        '
        'dgvUpcomingExams
        '
        Me.dgvUpcomingExams.AllowUserToAddRows = False
        Me.dgvUpcomingExams.AllowUserToDeleteRows = False
        Me.dgvUpcomingExams.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvUpcomingExams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUpcomingExams.Location = New System.Drawing.Point(17, 380)
        Me.dgvUpcomingExams.Name = "dgvUpcomingExams"
        Me.dgvUpcomingExams.ReadOnly = True
        Me.dgvUpcomingExams.Size = New System.Drawing.Size(530, 150)
        Me.dgvUpcomingExams.TabIndex = 13
        '
        'lblStudentsLabel
        '
        Me.lblStudentsLabel.AutoSize = True
        Me.lblStudentsLabel.Location = New System.Drawing.Point(10, 10)
        Me.lblStudentsLabel.Name = "lblStudentsLabel"
        Me.lblStudentsLabel.Size = New System.Drawing.Size(49, 13)
        Me.lblStudentsLabel.TabIndex = 14
        Me.lblStudentsLabel.Text = "Students"
        '
        'lblTeachersLabel
        '
        Me.lblTeachersLabel.AutoSize = True
        Me.lblTeachersLabel.Location = New System.Drawing.Point(140, 10)
        Me.lblTeachersLabel.Name = "lblTeachersLabel"
        Me.lblTeachersLabel.Size = New System.Drawing.Size(52, 13)
        Me.lblTeachersLabel.TabIndex = 15
        Me.lblTeachersLabel.Text = "Teachers"
        '
        'lblGroupsLabel
        '
        Me.lblGroupsLabel.AutoSize = True
        Me.lblGroupsLabel.Location = New System.Drawing.Point(270, 10)
        Me.lblGroupsLabel.Name = "lblGroupsLabel"
        Me.lblGroupsLabel.Size = New System.Drawing.Size(39, 13)
        Me.lblGroupsLabel.TabIndex = 16
        Me.lblGroupsLabel.Text = "Groups"
        '
        'lblUpcomingExamsLabel
        '
        Me.lblUpcomingExamsLabel.AutoSize = True
        Me.lblUpcomingExamsLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUpcomingExamsLabel.Location = New System.Drawing.Point(17, 357)
        Me.lblUpcomingExamsLabel.Name = "lblUpcomingExamsLabel"
        Me.lblUpcomingExamsLabel.Size = New System.Drawing.Size(142, 20)
        Me.lblUpcomingExamsLabel.TabIndex = 17
        Me.lblUpcomingExamsLabel.Text = "Upcoming Exams"
        '
        'panelStats
        '
        Me.panelStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelStats.Controls.Add(Me.lblStudentsLabel)
        Me.panelStats.Controls.Add(Me.lblStudentCount)
        Me.panelStats.Controls.Add(Me.lblTeachersLabel)
        Me.panelStats.Controls.Add(Me.lblTeacherCount)
        Me.panelStats.Controls.Add(Me.lblGroupsLabel)
        Me.panelStats.Controls.Add(Me.lblGroupCount)
        Me.panelStats.Location = New System.Drawing.Point(17, 220)
        Me.panelStats.Name = "panelStats"
        Me.panelStats.Size = New System.Drawing.Size(530, 70)
        Me.panelStats.TabIndex = 18
        '
        'panelMenu
        '
        Me.panelMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelMenu.Controls.Add(Me.btnStudents)
        Me.panelMenu.Controls.Add(Me.btnTeachers)
        Me.panelMenu.Controls.Add(Me.btnGroups)
        Me.panelMenu.Controls.Add(Me.btnAttendance)
        Me.panelMenu.Controls.Add(Me.btnPayments)
        Me.panelMenu.Controls.Add(Me.btnExams)
        Me.panelMenu.Controls.Add(Me.btnReports)
        Me.panelMenu.Controls.Add(Me.btnRefresh)
        Me.panelMenu.Location = New System.Drawing.Point(17, 80)
        Me.panelMenu.Name = "panelMenu"
        Me.panelMenu.Size = New System.Drawing.Size(530, 130)
        Me.panelMenu.TabIndex = 19
        '
        'MainDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(564, 542)
        Me.Controls.Add(Me.panelMenu)
        Me.Controls.Add(Me.panelStats)
        Me.Controls.Add(Me.lblUpcomingExamsLabel)
        Me.Controls.Add(Me.dgvUpcomingExams)
        Me.Controls.Add(Me.lblConnectionStatus)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "MainDashboard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Safwa Management System - Dashboard"
        CType(Me.dgvUpcomingExams, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelStats.ResumeLayout(False)
        Me.panelStats.PerformLayout()
        Me.panelMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents lblConnectionStatus As Label
    Friend WithEvents btnStudents As Button
    Friend WithEvents btnTeachers As Button
    Friend WithEvents btnGroups As Button
    Friend WithEvents btnAttendance As Button
    Friend WithEvents btnPayments As Button
    Friend WithEvents btnExams As Button
    Friend WithEvents btnReports As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents lblStudentCount As Label
    Friend WithEvents lblTeacherCount As Label
    Friend WithEvents lblGroupCount As Label
    Friend WithEvents dgvUpcomingExams As DataGridView
    Friend WithEvents lblStudentsLabel As Label
    Friend WithEvents lblTeachersLabel As Label
    Friend WithEvents lblGroupsLabel As Label
    Friend WithEvents lblUpcomingExamsLabel As Label
    Friend WithEvents panelStats As Panel
    Friend WithEvents panelMenu As Panel
End Class
