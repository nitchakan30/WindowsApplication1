<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox_Username = New System.Windows.Forms.TextBox()
        Me.TextBox_Pwd = New System.Windows.Forms.TextBox()
        Me.btn_login = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label_alert = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pic_user = New System.Windows.Forms.PictureBox()
        Me.Label_name = New System.Windows.Forms.Label()
        Me.pic_setting = New System.Windows.Forms.PictureBox()
        Me.btn_backend = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic_user, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic_setting, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btn_backend, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(195, 101)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Username"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(199, 137)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 19)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Password"
        '
        'TextBox_Username
        '
        Me.TextBox_Username.BackColor = System.Drawing.Color.White
        Me.TextBox_Username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox_Username.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TextBox_Username.Location = New System.Drawing.Point(287, 96)
        Me.TextBox_Username.MaxLength = 10
        Me.TextBox_Username.Name = "TextBox_Username"
        Me.TextBox_Username.Size = New System.Drawing.Size(198, 29)
        Me.TextBox_Username.TabIndex = 2
        '
        'TextBox_Pwd
        '
        Me.TextBox_Pwd.BackColor = System.Drawing.Color.White
        Me.TextBox_Pwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox_Pwd.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TextBox_Pwd.Location = New System.Drawing.Point(287, 132)
        Me.TextBox_Pwd.MaxLength = 10
        Me.TextBox_Pwd.Name = "TextBox_Pwd"
        Me.TextBox_Pwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox_Pwd.Size = New System.Drawing.Size(198, 29)
        Me.TextBox_Pwd.TabIndex = 3
        '
        'btn_login
        '
        Me.btn_login.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.btn_login.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_login.FlatAppearance.BorderSize = 0
        Me.btn_login.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray
        Me.btn_login.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray
        Me.btn_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_login.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_login.ForeColor = System.Drawing.Color.White
        Me.btn_login.Location = New System.Drawing.Point(491, 96)
        Me.btn_login.Name = "btn_login"
        Me.btn_login.Size = New System.Drawing.Size(106, 65)
        Me.btn_login.TabIndex = 4
        Me.btn_login.Text = "LOGIN"
        Me.btn_login.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(579, 57)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 25)
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'Label_alert
        '
        Me.Label_alert.AutoSize = True
        Me.Label_alert.BackColor = System.Drawing.Color.Transparent
        Me.Label_alert.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label_alert.ForeColor = System.Drawing.Color.Yellow
        Me.Label_alert.Location = New System.Drawing.Point(200, 168)
        Me.Label_alert.Name = "Label_alert"
        Me.Label_alert.Size = New System.Drawing.Size(28, 16)
        Me.Label_alert.TabIndex = 7
        Me.Label_alert.Text = "text"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(374, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(199, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "© 2014 Beecomeplus. All rights reserved"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(475, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 16)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Version 1.0.1"
        '
        'pic_user
        '
        Me.pic_user.BackColor = System.Drawing.Color.Transparent
        Me.pic_user.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pic_user.Location = New System.Drawing.Point(22, 68)
        Me.pic_user.Name = "pic_user"
        Me.pic_user.Size = New System.Drawing.Size(152, 152)
        Me.pic_user.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pic_user.TabIndex = 12
        Me.pic_user.TabStop = False
        '
        'Label_name
        '
        Me.Label_name.BackColor = System.Drawing.Color.Transparent
        Me.Label_name.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label_name.ForeColor = System.Drawing.Color.Black
        Me.Label_name.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label_name.Location = New System.Drawing.Point(178, 191)
        Me.Label_name.Name = "Label_name"
        Me.Label_name.Size = New System.Drawing.Size(357, 43)
        Me.Label_name.TabIndex = 13
        Me.Label_name.Text = "Name Surname"
        Me.Label_name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pic_setting
        '
        Me.pic_setting.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pic_setting.BackColor = System.Drawing.Color.Transparent
        Me.pic_setting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pic_setting.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pic_setting.Image = Global.BeecomePOS.My.Resources.Resources.Wizard
        Me.pic_setting.Location = New System.Drawing.Point(573, 202)
        Me.pic_setting.Name = "pic_setting"
        Me.pic_setting.Size = New System.Drawing.Size(24, 25)
        Me.pic_setting.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pic_setting.TabIndex = 14
        Me.pic_setting.TabStop = False
        '
        'btn_backend
        '
        Me.btn_backend.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_backend.BackColor = System.Drawing.Color.Transparent
        Me.btn_backend.BackgroundImage = Global.BeecomePOS.My.Resources.Resources.gear
        Me.btn_backend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_backend.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_backend.Image = CType(resources.GetObject("btn_backend.Image"), System.Drawing.Image)
        Me.btn_backend.Location = New System.Drawing.Point(541, 202)
        Me.btn_backend.Name = "btn_backend"
        Me.btn_backend.Size = New System.Drawing.Size(24, 25)
        Me.btn_backend.TabIndex = 15
        Me.btn_backend.TabStop = False
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BackgroundImage = Global.BeecomePOS.My.Resources.Resources.bg_new
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(609, 239)
        Me.ControlBox = False
        Me.Controls.Add(Me.btn_backend)
        Me.Controls.Add(Me.pic_setting)
        Me.Controls.Add(Me.Label_name)
        Me.Controls.Add(Me.pic_user)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label_alert)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btn_login)
        Me.Controls.Add(Me.TextBox_Pwd)
        Me.Controls.Add(Me.TextBox_Username)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Beecome POS"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic_user, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic_setting, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btn_backend, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox_Username As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_Pwd As System.Windows.Forms.TextBox
    Friend WithEvents btn_login As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label_alert As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents pic_user As System.Windows.Forms.PictureBox
    Friend WithEvents Label_name As System.Windows.Forms.Label
    Friend WithEvents pic_setting As System.Windows.Forms.PictureBox
    Friend WithEvents btn_backend As System.Windows.Forms.PictureBox

End Class
