<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class putLicense
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(putLicense))
        Me.txtLicense6 = New System.Windows.Forms.TextBox()
        Me.txtLicense5 = New System.Windows.Forms.TextBox()
        Me.txtLicense4 = New System.Windows.Forms.TextBox()
        Me.txtLicense3 = New System.Windows.Forms.TextBox()
        Me.txtLicense2 = New System.Windows.Forms.TextBox()
        Me.txtLicense1 = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtpStart = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtHotalname = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnConfirm = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnApply = New System.Windows.Forms.Button()
        Me.lblMaxUser = New System.Windows.Forms.Label()
        Me.lblMaxRoom = New System.Windows.Forms.Label()
        Me.lblExpireDate = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtLicense6
        '
        Me.txtLicense6.BackColor = System.Drawing.Color.White
        Me.txtLicense6.Location = New System.Drawing.Point(352, 43)
        Me.txtLicense6.MaxLength = 5
        Me.txtLicense6.Name = "txtLicense6"
        Me.txtLicense6.Size = New System.Drawing.Size(49, 20)
        Me.txtLicense6.TabIndex = 29
        Me.txtLicense6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLicense5
        '
        Me.txtLicense5.BackColor = System.Drawing.Color.White
        Me.txtLicense5.Location = New System.Drawing.Point(297, 43)
        Me.txtLicense5.MaxLength = 5
        Me.txtLicense5.Name = "txtLicense5"
        Me.txtLicense5.Size = New System.Drawing.Size(49, 20)
        Me.txtLicense5.TabIndex = 28
        Me.txtLicense5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLicense4
        '
        Me.txtLicense4.BackColor = System.Drawing.Color.White
        Me.txtLicense4.Location = New System.Drawing.Point(242, 43)
        Me.txtLicense4.MaxLength = 5
        Me.txtLicense4.Name = "txtLicense4"
        Me.txtLicense4.Size = New System.Drawing.Size(49, 20)
        Me.txtLicense4.TabIndex = 27
        Me.txtLicense4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLicense3
        '
        Me.txtLicense3.BackColor = System.Drawing.Color.White
        Me.txtLicense3.Location = New System.Drawing.Point(187, 43)
        Me.txtLicense3.MaxLength = 5
        Me.txtLicense3.Name = "txtLicense3"
        Me.txtLicense3.Size = New System.Drawing.Size(49, 20)
        Me.txtLicense3.TabIndex = 26
        Me.txtLicense3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLicense2
        '
        Me.txtLicense2.BackColor = System.Drawing.Color.White
        Me.txtLicense2.Location = New System.Drawing.Point(132, 43)
        Me.txtLicense2.MaxLength = 5
        Me.txtLicense2.Name = "txtLicense2"
        Me.txtLicense2.Size = New System.Drawing.Size(49, 20)
        Me.txtLicense2.TabIndex = 25
        Me.txtLicense2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLicense1
        '
        Me.txtLicense1.BackColor = System.Drawing.Color.White
        Me.txtLicense1.Location = New System.Drawing.Point(77, 43)
        Me.txtLicense1.MaxLength = 5
        Me.txtLicense1.Name = "txtLicense1"
        Me.txtLicense1.Size = New System.Drawing.Size(49, 20)
        Me.txtLicense1.TabIndex = 24
        Me.txtLicense1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtpStart)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtHotalname)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnConfirm)
        Me.GroupBox1.Controls.Add(Me.txtLicense1)
        Me.GroupBox1.Controls.Add(Me.txtLicense6)
        Me.GroupBox1.Controls.Add(Me.txtLicense2)
        Me.GroupBox1.Controls.Add(Me.txtLicense5)
        Me.GroupBox1.Controls.Add(Me.txtLicense3)
        Me.GroupBox1.Controls.Add(Me.txtLicense4)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(491, 72)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Input license"
        '
        'dtpStart
        '
        Me.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStart.Location = New System.Drawing.Point(379, 17)
        Me.dtpStart.Name = "dtpStart"
        Me.dtpStart.Size = New System.Drawing.Size(103, 20)
        Me.dtpStart.TabIndex = 35
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(318, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 13)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "Start Date"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(27, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "License"
        '
        'txtHotalname
        '
        Me.txtHotalname.Location = New System.Drawing.Point(77, 17)
        Me.txtHotalname.Name = "txtHotalname"
        Me.txtHotalname.Size = New System.Drawing.Size(235, 20)
        Me.txtHotalname.TabIndex = 32
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Hotal Name"
        '
        'btnConfirm
        '
        Me.btnConfirm.Location = New System.Drawing.Point(407, 41)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(75, 23)
        Me.btnConfirm.TabIndex = 30
        Me.btnConfirm.Text = "Confirm"
        Me.btnConfirm.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnCancel)
        Me.GroupBox2.Controls.Add(Me.btnApply)
        Me.GroupBox2.Controls.Add(Me.lblMaxUser)
        Me.GroupBox2.Controls.Add(Me.lblMaxRoom)
        Me.GroupBox2.Controls.Add(Me.lblExpireDate)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Location = New System.Drawing.Point(10, 90)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(491, 45)
        Me.GroupBox2.TabIndex = 32
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detail"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(407, 14)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 35
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(326, 14)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(75, 23)
        Me.btnApply.TabIndex = 34
        Me.btnApply.Text = "Apply"
        Me.btnApply.UseVisualStyleBackColor = True
        '
        'lblMaxUser
        '
        Me.lblMaxUser.AutoSize = True
        Me.lblMaxUser.ForeColor = System.Drawing.Color.Navy
        Me.lblMaxUser.Location = New System.Drawing.Point(301, 19)
        Me.lblMaxUser.Name = "lblMaxUser"
        Me.lblMaxUser.Size = New System.Drawing.Size(10, 13)
        Me.lblMaxUser.TabIndex = 25
        Me.lblMaxUser.Text = "-"
        '
        'lblMaxRoom
        '
        Me.lblMaxRoom.AutoSize = True
        Me.lblMaxRoom.BackColor = System.Drawing.Color.Transparent
        Me.lblMaxRoom.ForeColor = System.Drawing.Color.Navy
        Me.lblMaxRoom.Location = New System.Drawing.Point(187, 19)
        Me.lblMaxRoom.Name = "lblMaxRoom"
        Me.lblMaxRoom.Size = New System.Drawing.Size(10, 13)
        Me.lblMaxRoom.TabIndex = 24
        Me.lblMaxRoom.Text = "-"
        '
        'lblExpireDate
        '
        Me.lblExpireDate.AutoSize = True
        Me.lblExpireDate.BackColor = System.Drawing.Color.Transparent
        Me.lblExpireDate.ForeColor = System.Drawing.Color.Navy
        Me.lblExpireDate.Location = New System.Drawing.Point(84, 19)
        Me.lblExpireDate.Name = "lblExpireDate"
        Me.lblExpireDate.Size = New System.Drawing.Size(10, 13)
        Me.lblExpireDate.TabIndex = 23
        Me.lblExpireDate.Text = "-"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(221, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 13)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Max User Use"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(123, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Max Table"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(16, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Expire Date"
        '
        'putLicense
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(510, 147)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "putLicense"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "License"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtLicense6 As System.Windows.Forms.TextBox
    Friend WithEvents txtLicense5 As System.Windows.Forms.TextBox
    Friend WithEvents txtLicense4 As System.Windows.Forms.TextBox
    Friend WithEvents txtLicense3 As System.Windows.Forms.TextBox
    Friend WithEvents txtLicense2 As System.Windows.Forms.TextBox
    Friend WithEvents txtLicense1 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnConfirm As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblMaxUser As System.Windows.Forms.Label
    Friend WithEvents lblMaxRoom As System.Windows.Forms.Label
    Friend WithEvents lblExpireDate As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtHotalname As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnApply As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents dtpStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
