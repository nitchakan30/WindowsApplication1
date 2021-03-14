<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_addUser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Admin_addUser))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btn_add = New System.Windows.Forms.ToolStripButton()
        Me.btn_back = New System.Windows.Forms.ToolStripButton()
        Me.btn_edit = New System.Windows.Forms.ToolStripButton()
        Me.btn_del = New System.Windows.Forms.ToolStripButton()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.btn_cancle = New System.Windows.Forms.Button()
        Me.btn_reset = New System.Windows.Forms.Button()
        Me.btn_save = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_numemp = New System.Windows.Forms.TextBox()
        Me.txt_email = New System.Windows.Forms.TextBox()
        Me.txt_tel = New System.Windows.Forms.TextBox()
        Me.txt_password = New System.Windows.Forms.TextBox()
        Me.txt_username = New System.Windows.Forms.TextBox()
        Me.txt_surname = New System.Windows.Forms.TextBox()
        Me.txt_name = New System.Windows.Forms.TextBox()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.id_user = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.NO = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.USERNAME = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FULLNAME = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Telephone = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.active_void = New System.Windows.Forms.CheckBox()
        Me.ToolStrip1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_add, Me.btn_back, Me.btn_edit, Me.btn_del})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(53, 573)
        Me.ToolStrip1.TabIndex = 12
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btn_add
        '
        Me.btn_add.ForeColor = System.Drawing.Color.Black
        Me.btn_add.Image = Global.BeecomePOS.My.Resources.Resources.user_32
        Me.btn_add.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_add.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_add.Name = "btn_add"
        Me.btn_add.Size = New System.Drawing.Size(50, 51)
        Me.btn_add.Text = "เพิ่มใหม่"
        Me.btn_add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btn_back
        '
        Me.btn_back.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btn_back.ForeColor = System.Drawing.Color.Black
        Me.btn_back.Image = Global.BeecomePOS.My.Resources.Resources.leftred_321
        Me.btn_back.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_back.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_back.Name = "btn_back"
        Me.btn_back.Size = New System.Drawing.Size(50, 51)
        Me.btn_back.Text = "ย้อนกลับ"
        Me.btn_back.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btn_edit
        '
        Me.btn_edit.Image = Global.BeecomePOS.My.Resources.Resources.pencil_32
        Me.btn_edit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_edit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_edit.Name = "btn_edit"
        Me.btn_edit.Size = New System.Drawing.Size(50, 51)
        Me.btn_edit.Text = "แก้ไข"
        Me.btn_edit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btn_del
        '
        Me.btn_del.Image = Global.BeecomePOS.My.Resources.Resources.delete_32
        Me.btn_del.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_del.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_del.Name = "btn_del"
        Me.btn_del.Size = New System.Drawing.Size(50, 51)
        Me.btn_del.Text = "ลบ"
        Me.btn_del.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.active_void)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.PictureBox1)
        Me.TabPage1.Controls.Add(Me.RadioButton2)
        Me.TabPage1.Controls.Add(Me.RadioButton1)
        Me.TabPage1.Controls.Add(Me.btn_cancle)
        Me.TabPage1.Controls.Add(Me.btn_reset)
        Me.TabPage1.Controls.Add(Me.btn_save)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.txt_numemp)
        Me.TabPage1.Controls.Add(Me.txt_email)
        Me.TabPage1.Controls.Add(Me.txt_tel)
        Me.TabPage1.Controls.Add(Me.txt_password)
        Me.TabPage1.Controls.Add(Me.txt_username)
        Me.TabPage1.Controls.Add(Me.txt_surname)
        Me.TabPage1.Controls.Add(Me.txt_name)
        Me.TabPage1.Controls.Add(Me.CheckedListBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(451, 547)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "ข้อมูลพนักงาน"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(332, 146)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(99, 23)
        Me.Button1.TabIndex = 22
        Me.Button1.Text = "อัพโหลดรูปประจำตัว"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.DarkGray
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Image = Global.BeecomePOS.My.Resources.Resources.user_32
        Me.PictureBox1.Location = New System.Drawing.Point(323, 26)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(118, 114)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 21
        Me.PictureBox1.TabStop = False
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(197, 2)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(60, 17)
        Me.RadioButton2.TabIndex = 20
        Me.RadioButton2.Text = "Disable"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(129, 3)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(58, 17)
        Me.RadioButton1.TabIndex = 20
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Enable"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'btn_cancle
        '
        Me.btn_cancle.Image = Global.BeecomePOS.My.Resources.Resources.delete_161
        Me.btn_cancle.Location = New System.Drawing.Point(210, 424)
        Me.btn_cancle.Name = "btn_cancle"
        Me.btn_cancle.Size = New System.Drawing.Size(75, 28)
        Me.btn_cancle.TabIndex = 19
        Me.btn_cancle.Text = "Cancle"
        Me.btn_cancle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_cancle.UseVisualStyleBackColor = True
        '
        'btn_reset
        '
        Me.btn_reset.Image = Global.BeecomePOS.My.Resources.Resources.trash_161
        Me.btn_reset.Location = New System.Drawing.Point(129, 424)
        Me.btn_reset.Name = "btn_reset"
        Me.btn_reset.Size = New System.Drawing.Size(75, 28)
        Me.btn_reset.TabIndex = 19
        Me.btn_reset.Text = "Clear"
        Me.btn_reset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_reset.UseVisualStyleBackColor = True
        '
        'btn_save
        '
        Me.btn_save.Image = Global.BeecomePOS.My.Resources.Resources.save_16
        Me.btn_save.Location = New System.Drawing.Point(48, 424)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(75, 28)
        Me.btn_save.TabIndex = 18
        Me.btn_save.Text = "Save"
        Me.btn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(48, 269)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "สิทธิการใช้งาน"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(50, 216)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(113, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "เลขประจำตัวพนักงาน :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(50, 187)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "อีเมล์ :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(50, 157)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "เบอร์โทร :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(50, 127)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "PASSWORD :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(50, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "USERNAME :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(48, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "นามสกุล :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(49, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "ชื่อ :"
        '
        'txt_numemp
        '
        Me.txt_numemp.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txt_numemp.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_numemp.Location = New System.Drawing.Point(128, 232)
        Me.txt_numemp.MaxLength = 15
        Me.txt_numemp.Name = "txt_numemp"
        Me.txt_numemp.Size = New System.Drawing.Size(178, 24)
        Me.txt_numemp.TabIndex = 15
        '
        'txt_email
        '
        Me.txt_email.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txt_email.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_email.Location = New System.Drawing.Point(128, 182)
        Me.txt_email.MaxLength = 50
        Me.txt_email.Name = "txt_email"
        Me.txt_email.Size = New System.Drawing.Size(178, 24)
        Me.txt_email.TabIndex = 15
        '
        'txt_tel
        '
        Me.txt_tel.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txt_tel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_tel.Location = New System.Drawing.Point(128, 152)
        Me.txt_tel.MaxLength = 13
        Me.txt_tel.Name = "txt_tel"
        Me.txt_tel.Size = New System.Drawing.Size(178, 24)
        Me.txt_tel.TabIndex = 15
        '
        'txt_password
        '
        Me.txt_password.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txt_password.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_password.Location = New System.Drawing.Point(128, 122)
        Me.txt_password.MaxLength = 10
        Me.txt_password.Name = "txt_password"
        Me.txt_password.Size = New System.Drawing.Size(178, 24)
        Me.txt_password.TabIndex = 15
        '
        'txt_username
        '
        Me.txt_username.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txt_username.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_username.Location = New System.Drawing.Point(128, 92)
        Me.txt_username.MaxLength = 10
        Me.txt_username.Name = "txt_username"
        Me.txt_username.Size = New System.Drawing.Size(178, 24)
        Me.txt_username.TabIndex = 15
        '
        'txt_surname
        '
        Me.txt_surname.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txt_surname.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_surname.Location = New System.Drawing.Point(129, 56)
        Me.txt_surname.MaxLength = 100
        Me.txt_surname.Name = "txt_surname"
        Me.txt_surname.Size = New System.Drawing.Size(178, 24)
        Me.txt_surname.TabIndex = 15
        '
        'txt_name
        '
        Me.txt_name.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txt_name.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_name.Location = New System.Drawing.Point(129, 26)
        Me.txt_name.MaxLength = 100
        Me.txt_name.Name = "txt_name"
        Me.txt_name.Size = New System.Drawing.Size(178, 24)
        Me.txt_name.TabIndex = 15
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Items.AddRange(New Object() {"POS System", "Closing Bill", "Profile Shop", "Manage Table Food", "Manage Product", "Setting Other", "Report", "Manage User", "Stock"})
        Me.CheckedListBox1.Location = New System.Drawing.Point(128, 269)
        Me.CheckedListBox1.MultiColumn = True
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(235, 124)
        Me.CheckedListBox1.TabIndex = 14
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Left
        Me.TabControl1.Location = New System.Drawing.Point(53, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(459, 573)
        Me.TabControl1.TabIndex = 19
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.id_user, Me.NO, Me.USERNAME, Me.FULLNAME, Me.Telephone})
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(512, 0)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(473, 573)
        Me.ListView1.TabIndex = 20
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'id_user
        '
        Me.id_user.Text = ""
        Me.id_user.Width = 0
        '
        'NO
        '
        Me.NO.Text = "NO."
        '
        'USERNAME
        '
        Me.USERNAME.Text = "USERNAME"
        Me.USERNAME.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.USERNAME.Width = 122
        '
        'FULLNAME
        '
        Me.FULLNAME.Text = "ชื่อ-สกุล"
        Me.FULLNAME.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.FULLNAME.Width = 147
        '
        'Telephone
        '
        Me.Telephone.Text = "เบอร์โทร"
        Me.Telephone.Width = 141
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'active_void
        '
        Me.active_void.AutoSize = True
        Me.active_void.ForeColor = System.Drawing.Color.Red
        Me.active_void.Location = New System.Drawing.Point(129, 399)
        Me.active_void.Name = "active_void"
        Me.active_void.Size = New System.Drawing.Size(96, 17)
        Me.active_void.TabIndex = 23
        Me.active_void.Text = "Active Void Bill"
        Me.active_void.UseVisualStyleBackColor = True
        '
        'Admin_addUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(985, 573)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Admin_addUser"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "จัดการผู้ใช้งาน"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btn_add As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_back As System.Windows.Forms.ToolStripButton
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents CheckedListBox1 As System.Windows.Forms.CheckedListBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_password As System.Windows.Forms.TextBox
    Friend WithEvents txt_username As System.Windows.Forms.TextBox
    Friend WithEvents txt_surname As System.Windows.Forms.TextBox
    Friend WithEvents txt_name As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_email As System.Windows.Forms.TextBox
    Friend WithEvents txt_tel As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_numemp As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btn_reset As System.Windows.Forms.Button
    Friend WithEvents btn_save As System.Windows.Forms.Button
    Friend WithEvents btn_edit As System.Windows.Forms.ToolStripButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents btn_del As System.Windows.Forms.ToolStripButton
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents NO As System.Windows.Forms.ColumnHeader
    Friend WithEvents USERNAME As System.Windows.Forms.ColumnHeader
    Friend WithEvents FULLNAME As System.Windows.Forms.ColumnHeader
    Friend WithEvents Telephone As System.Windows.Forms.ColumnHeader
    Friend WithEvents btn_cancle As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents id_user As System.Windows.Forms.ColumnHeader
    Friend WithEvents active_void As System.Windows.Forms.CheckBox
End Class
