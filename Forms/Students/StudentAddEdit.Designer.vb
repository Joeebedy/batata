<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StudentAddEdit
    Inherits System.Windows.Forms.Form

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblStudentName = New System.Windows.Forms.Label()
        Me.txtStudentName = New System.Windows.Forms.TextBox()
        Me.lblGuardianName = New System.Windows.Forms.Label()
        Me.txtGuardianName = New System.Windows.Forms.TextBox()
        Me.lblGuardianPhone = New System.Windows.Forms.Label()
        Me.txtGuardianPhone = New System.Windows.Forms.TextBox()
        Me.lblStudentPhone = New System.Windows.Forms.Label()
        Me.txtStudentPhone = New System.Windows.Forms.TextBox()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.lblBirthDate = New System.Windows.Forms.Label()
        Me.dtpBirthDate = New System.Windows.Forms.DateTimePicker()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblStudentName
        '
        Me.lblStudentName.AutoSize = True
        Me.lblStudentName.Location = New System.Drawing.Point(12, 15)
        Me.lblStudentName.Name = "lblStudentName"
        Me.lblStudentName.Size = New System.Drawing.Size(78, 13)
        Me.lblStudentName.TabIndex = 0
        Me.lblStudentName.Text = "Student Name:"
        '
        'txtStudentName
        '
        Me.txtStudentName.Location = New System.Drawing.Point(120, 12)
        Me.txtStudentName.Name = "txtStudentName"
        Me.txtStudentName.Size = New System.Drawing.Size(200, 20)
        Me.txtStudentName.TabIndex = 1
        '
        'lblGuardianName
        '
        Me.lblGuardianName.AutoSize = True
        Me.lblGuardianName.Location = New System.Drawing.Point(12, 45)
        Me.lblGuardianName.Name = "lblGuardianName"
        Me.lblGuardianName.Size = New System.Drawing.Size(82, 13)
        Me.lblGuardianName.TabIndex = 2
        Me.lblGuardianName.Text = "Guardian Name:"
        '
        'txtGuardianName
        '
        Me.txtGuardianName.Location = New System.Drawing.Point(120, 42)
        Me.txtGuardianName.Name = "txtGuardianName"
        Me.txtGuardianName.Size = New System.Drawing.Size(200, 20)
        Me.txtGuardianName.TabIndex = 3
        '
        'lblGuardianPhone
        '
        Me.lblGuardianPhone.AutoSize = True
        Me.lblGuardianPhone.Location = New System.Drawing.Point(12, 75)
        Me.lblGuardianPhone.Name = "lblGuardianPhone"
        Me.lblGuardianPhone.Size = New System.Drawing.Size(86, 13)
        Me.lblGuardianPhone.TabIndex = 4
        Me.lblGuardianPhone.Text = "Guardian Phone:"
        '
        'txtGuardianPhone
        '
        Me.txtGuardianPhone.Location = New System.Drawing.Point(120, 72)
        Me.txtGuardianPhone.Name = "txtGuardianPhone"
        Me.txtGuardianPhone.Size = New System.Drawing.Size(200, 20)
        Me.txtGuardianPhone.TabIndex = 5
        '
        'lblStudentPhone
        '
        Me.lblStudentPhone.AutoSize = True
        Me.lblStudentPhone.Location = New System.Drawing.Point(12, 105)
        Me.lblStudentPhone.Name = "lblStudentPhone"
        Me.lblStudentPhone.Size = New System.Drawing.Size(82, 13)
        Me.lblStudentPhone.TabIndex = 6
        Me.lblStudentPhone.Text = "Student Phone:"
        '
        'txtStudentPhone
        '
        Me.txtStudentPhone.Location = New System.Drawing.Point(120, 102)
        Me.txtStudentPhone.Name = "txtStudentPhone"
        Me.txtStudentPhone.Size = New System.Drawing.Size(200, 20)
        Me.txtStudentPhone.TabIndex = 7
        '
        'lblAddress
        '
        Me.lblAddress.AutoSize = True
        Me.lblAddress.Location = New System.Drawing.Point(12, 135)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(48, 13)
        Me.lblAddress.TabIndex = 8
        Me.lblAddress.Text = "Address:"
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(120, 132)
        Me.txtAddress.Multiline = True
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(200, 60)
        Me.txtAddress.TabIndex = 9
        '
        'lblBirthDate
        '
        Me.lblBirthDate.AutoSize = True
        Me.lblBirthDate.Location = New System.Drawing.Point(12, 205)
        Me.lblBirthDate.Name = "lblBirthDate"
        Me.lblBirthDate.Size = New System.Drawing.Size(57, 13)
        Me.lblBirthDate.TabIndex = 10
        Me.lblBirthDate.Text = "Birth Date:"
        '
        'dtpBirthDate
        '
        Me.dtpBirthDate.Location = New System.Drawing.Point(120, 202)
        Me.dtpBirthDate.Name = "dtpBirthDate"
        Me.dtpBirthDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpBirthDate.TabIndex = 11
        '
        'lblNotes
        '
        Me.lblNotes.AutoSize = True
        Me.lblNotes.Location = New System.Drawing.Point(12, 235)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(38, 13)
        Me.lblNotes.TabIndex = 12
        Me.lblNotes.Text = "Notes:"
        '
        'txtNotes
        '
        Me.txtNotes.Location = New System.Drawing.Point(120, 232)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(200, 60)
        Me.txtNotes.TabIndex = 13
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(12, 305)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(40, 13)
        Me.lblStatus.TabIndex = 14
        Me.lblStatus.Text = "Status:"
        '
        'cmbStatus
        '
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Items.AddRange(New Object() {"Active", "Inactive", "Graduated", "Dropped"})
        Me.cmbStatus.Location = New System.Drawing.Point(120, 302)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(200, 21)
        Me.cmbStatus.TabIndex = 15
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(120, 340)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 30)
        Me.btnSave.TabIndex = 16
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(245, 340)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 30)
        Me.btnCancel.TabIndex = 17
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'StudentAddEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(350, 385)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.cmbStatus)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.lblNotes)
        Me.Controls.Add(Me.dtpBirthDate)
        Me.Controls.Add(Me.lblBirthDate)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.lblAddress)
        Me.Controls.Add(Me.txtStudentPhone)
        Me.Controls.Add(Me.lblStudentPhone)
        Me.Controls.Add(Me.txtGuardianPhone)
        Me.Controls.Add(Me.lblGuardianPhone)
        Me.Controls.Add(Me.txtGuardianName)
        Me.Controls.Add(Me.lblGuardianName)
        Me.Controls.Add(Me.txtStudentName)
        Me.Controls.Add(Me.lblStudentName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "StudentAddEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Student Add/Edit"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblStudentName As Label
    Friend WithEvents txtStudentName As TextBox
    Friend WithEvents lblGuardianName As Label
    Friend WithEvents txtGuardianName As TextBox
    Friend WithEvents lblGuardianPhone As Label
    Friend WithEvents txtGuardianPhone As TextBox
    Friend WithEvents lblStudentPhone As Label
    Friend WithEvents txtStudentPhone As TextBox
    Friend WithEvents lblAddress As Label
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents lblBirthDate As Label
    Friend WithEvents dtpBirthDate As DateTimePicker
    Friend WithEvents lblNotes As Label
    Friend WithEvents txtNotes As TextBox
    Friend WithEvents lblStatus As Label
    Friend WithEvents cmbStatus As ComboBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
End Class
