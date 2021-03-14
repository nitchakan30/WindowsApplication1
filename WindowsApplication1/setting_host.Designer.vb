<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class setting_host
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(setting_host))
        Me.save = New System.Windows.Forms.Button()
        Me.cancel = New System.Windows.Forms.Button()
        Me.server = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.user_id = New System.Windows.Forms.TextBox()
        Me.password = New System.Windows.Forms.TextBox()
        Me.port = New System.Windows.Forms.TextBox()
        Me.databaase = New System.Windows.Forms.TextBox()
        Me.avatar = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.img_system = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.img_product = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.file_export = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.databaase_f = New System.Windows.Forms.TextBox()
        Me.port_f = New System.Windows.Forms.TextBox()
        Me.password_f = New System.Windows.Forms.TextBox()
        Me.user_id_f = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.server_f = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.File_Update = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Server_Report = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'save
        '
        Me.save.Image = Global.BeecomePOS.My.Resources.Resources.Web_info
        Me.save.Location = New System.Drawing.Point(238, 353)
        Me.save.Name = "save"
        Me.save.Size = New System.Drawing.Size(75, 33)
        Me.save.TabIndex = 0
        Me.save.Text = "Connect"
        Me.save.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.save.UseVisualStyleBackColor = True
        '
        'cancel
        '
        Me.cancel.Image = Global.BeecomePOS.My.Resources.Resources.delete_161
        Me.cancel.Location = New System.Drawing.Point(329, 353)
        Me.cancel.Name = "cancel"
        Me.cancel.Size = New System.Drawing.Size(75, 33)
        Me.cancel.TabIndex = 1
        Me.cancel.Text = "Cancel"
        Me.cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cancel.UseVisualStyleBackColor = True
        '
        'server
        '
        Me.server.Location = New System.Drawing.Point(72, 15)
        Me.server.Name = "server"
        Me.server.Size = New System.Drawing.Size(112, 20)
        Me.server.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Server"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "User Id"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 127)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Password"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Port"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Database"
        '
        'user_id
        '
        Me.user_id.Location = New System.Drawing.Point(72, 101)
        Me.user_id.Name = "user_id"
        Me.user_id.Size = New System.Drawing.Size(112, 20)
        Me.user_id.TabIndex = 8
        '
        'password
        '
        Me.password.Location = New System.Drawing.Point(72, 127)
        Me.password.Name = "password"
        Me.password.Size = New System.Drawing.Size(112, 20)
        Me.password.TabIndex = 9
        '
        'port
        '
        Me.port.Location = New System.Drawing.Point(72, 44)
        Me.port.Name = "port"
        Me.port.Size = New System.Drawing.Size(112, 20)
        Me.port.TabIndex = 10
        '
        'databaase
        '
        Me.databaase.Location = New System.Drawing.Point(72, 70)
        Me.databaase.Name = "databaase"
        Me.databaase.Size = New System.Drawing.Size(112, 20)
        Me.databaase.TabIndex = 11
        '
        'avatar
        '
        Me.avatar.Location = New System.Drawing.Point(94, 24)
        Me.avatar.Name = "avatar"
        Me.avatar.Size = New System.Drawing.Size(257, 20)
        Me.avatar.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(49, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Avatar"
        '
        'img_system
        '
        Me.img_system.Location = New System.Drawing.Point(94, 50)
        Me.img_system.Name = "img_system"
        Me.img_system.Size = New System.Drawing.Size(257, 20)
        Me.img_system.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Images System"
        '
        'img_product
        '
        Me.img_product.Location = New System.Drawing.Point(94, 73)
        Me.img_product.Name = "img_product"
        Me.img_product.Size = New System.Drawing.Size(257, 20)
        Me.img_product.TabIndex = 17
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 76)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Images Product"
        '
        'file_export
        '
        Me.file_export.Location = New System.Drawing.Point(94, 99)
        Me.file_export.Name = "file_export"
        Me.file_export.Size = New System.Drawing.Size(257, 20)
        Me.file_export.TabIndex = 19
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(2, 102)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Flie Export Excel"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button6)
        Me.GroupBox1.Controls.Add(Me.Server_Report)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Button5)
        Me.GroupBox1.Controls.Add(Me.File_Update)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.img_product)
        Me.GroupBox1.Controls.Add(Me.file_export)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.avatar)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.img_system)
        Me.GroupBox1.Location = New System.Drawing.Point(222, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(445, 335)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Setting Folder"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(356, 99)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 23
        Me.Button4.Text = "Broswer"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(357, 74)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 22
        Me.Button3.Text = "Broswer"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(357, 48)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 21
        Me.Button2.Text = "Broswer"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(358, 23)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 20
        Me.Button1.Text = "Broswer"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.databaase_f)
        Me.GroupBox2.Controls.Add(Me.port_f)
        Me.GroupBox2.Controls.Add(Me.password_f)
        Me.GroupBox2.Controls.Add(Me.user_id_f)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.server_f)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 187)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(207, 160)
        Me.GroupBox2.TabIndex = 21
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Connect Front"
        '
        'databaase_f
        '
        Me.databaase_f.Location = New System.Drawing.Point(84, 71)
        Me.databaase_f.Name = "databaase_f"
        Me.databaase_f.Size = New System.Drawing.Size(112, 20)
        Me.databaase_f.TabIndex = 21
        '
        'port_f
        '
        Me.port_f.Location = New System.Drawing.Point(84, 45)
        Me.port_f.Name = "port_f"
        Me.port_f.Size = New System.Drawing.Size(112, 20)
        Me.port_f.TabIndex = 20
        '
        'password_f
        '
        Me.password_f.Location = New System.Drawing.Point(84, 123)
        Me.password_f.Name = "password_f"
        Me.password_f.Size = New System.Drawing.Size(112, 20)
        Me.password_f.TabIndex = 19
        '
        'user_id_f
        '
        Me.user_id_f.Location = New System.Drawing.Point(84, 97)
        Me.user_id_f.Name = "user_id_f"
        Me.user_id_f.Size = New System.Drawing.Size(112, 20)
        Me.user_id_f.TabIndex = 18
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(20, 71)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 13)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Database"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(20, 45)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(26, 13)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "Port"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(20, 123)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 13)
        Me.Label12.TabIndex = 15
        Me.Label12.Text = "Password"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(20, 97)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(41, 13)
        Me.Label13.TabIndex = 14
        Me.Label13.Text = "User Id"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(20, 19)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(38, 13)
        Me.Label14.TabIndex = 13
        Me.Label14.Text = "Server"
        '
        'server_f
        '
        Me.server_f.Location = New System.Drawing.Point(84, 16)
        Me.server_f.Name = "server_f"
        Me.server_f.Size = New System.Drawing.Size(112, 20)
        Me.server_f.TabIndex = 12
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.databaase)
        Me.GroupBox3.Controls.Add(Me.server)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.port)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.password)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.user_id)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 11)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(204, 170)
        Me.GroupBox3.TabIndex = 22
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "POS"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(356, 125)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 26
        Me.Button5.Text = "Broswer"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'File_Update
        '
        Me.File_Update.Location = New System.Drawing.Point(94, 125)
        Me.File_Update.Name = "File_Update"
        Me.File_Update.Size = New System.Drawing.Size(257, 20)
        Me.File_Update.TabIndex = 25
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(2, 128)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(93, 13)
        Me.Label15.TabIndex = 24
        Me.Label15.Text = "Folder File Update"
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(356, 151)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 23)
        Me.Button6.TabIndex = 29
        Me.Button6.Text = "Broswer"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Server_Report
        '
        Me.Server_Report.Location = New System.Drawing.Point(94, 151)
        Me.Server_Report.Name = "Server_Report"
        Me.Server_Report.Size = New System.Drawing.Size(257, 20)
        Me.Server_Report.TabIndex = 28
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(13, 154)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(73, 13)
        Me.Label16.TabIndex = 27
        Me.Label16.Text = "Server Report"
        '
        'setting_host
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(677, 398)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cancel)
        Me.Controls.Add(Me.save)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "setting_host"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Config Host"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents save As System.Windows.Forms.Button
    Friend WithEvents cancel As System.Windows.Forms.Button
    Friend WithEvents server As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents user_id As System.Windows.Forms.TextBox
    Friend WithEvents password As System.Windows.Forms.TextBox
    Friend WithEvents port As System.Windows.Forms.TextBox
    Friend WithEvents databaase As System.Windows.Forms.TextBox
    Friend WithEvents avatar As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents img_system As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents img_product As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents file_export As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents databaase_f As System.Windows.Forms.TextBox
    Friend WithEvents port_f As System.Windows.Forms.TextBox
    Friend WithEvents password_f As System.Windows.Forms.TextBox
    Friend WithEvents user_id_f As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents server_f As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Server_Report As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents File_Update As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
End Class
