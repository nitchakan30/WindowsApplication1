<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class index
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(index))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.KkToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.edit_profile = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_home1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.edit_p = New System.Windows.Forms.ToolStripMenuItem()
        Me.reserv1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tk_home1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.VoidBill = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.report1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.close_rop1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.close_day1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_seting = New System.Windows.Forms.ToolStripMenuItem()
        Me.logout1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip2 = New System.Windows.Forms.StatusStrip()
        Me.db_name = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.company_name = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.user_show = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_th = New System.Windows.Forms.Button()
        Me.btn_eng = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label_Rop = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.DMY = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btn_maxsize = New System.Windows.Forms.Button()
        Me.btn_mini = New System.Windows.Forms.Button()
        Me.btn_close = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintPreviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip2.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(60, 91)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.KkToolStripMenuItem, Me.btn_home1, Me.edit_p, Me.reserv1, Me.tk_home1, Me.VoidBill, Me.ToolStripMenuItem1, Me.report1, Me.close_rop1, Me.close_day1, Me.btn_seting, Me.logout1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 37)
        Me.MenuStrip1.Margin = New System.Windows.Forms.Padding(0, 0, 0, 200)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1024, 93)
        Me.MenuStrip1.TabIndex = 7
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'KkToolStripMenuItem
        '
        Me.KkToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.edit_profile})
        Me.KkToolStripMenuItem.Image = Global.BeecomePOS.My.Resources.Resources.menu_bar1
        Me.KkToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.KkToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.KkToolStripMenuItem.Name = "KkToolStripMenuItem"
        Me.KkToolStripMenuItem.Padding = New System.Windows.Forms.Padding(0)
        Me.KkToolStripMenuItem.Size = New System.Drawing.Size(58, 91)
        '
        'edit_profile
        '
        Me.edit_profile.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.edit_profile.Image = Global.BeecomePOS.My.Resources.Resources.User__2_
        Me.edit_profile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.edit_profile.Name = "edit_profile"
        Me.edit_profile.Size = New System.Drawing.Size(142, 22)
        Me.edit_profile.Text = "Edit Profile"
        '
        'btn_home1
        '
        Me.btn_home1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_home1.Image = Global.BeecomePOS.My.Resources.Resources.hm
        Me.btn_home1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_home1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_home1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.btn_home1.Name = "btn_home1"
        Me.btn_home1.Padding = New System.Windows.Forms.Padding(0)
        Me.btn_home1.Size = New System.Drawing.Size(49, 91)
        Me.btn_home1.Text = "Home"
        Me.btn_home1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_home1.ToolTipText = "หน้าแรก"
        '
        'edit_p
        '
        Me.edit_p.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.edit_p.Image = Global.BeecomePOS.My.Resources.Resources.total_user11
        Me.edit_p.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.edit_p.Margin = New System.Windows.Forms.Padding(10, 8, 5, 0)
        Me.edit_p.Name = "edit_p"
        Me.edit_p.Size = New System.Drawing.Size(58, 83)
        Me.edit_p.Text = "Profile"
        Me.edit_p.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'reserv1
        '
        Me.reserv1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reserv1.Image = Global.BeecomePOS.My.Resources.Resources.m_reserv
        Me.reserv1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.reserv1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.reserv1.Name = "reserv1"
        Me.reserv1.Padding = New System.Windows.Forms.Padding(0)
        Me.reserv1.Size = New System.Drawing.Size(99, 91)
        Me.reserv1.Text = " Reservation "
        Me.reserv1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tk_home1
        '
        Me.tk_home1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tk_home1.Image = Global.BeecomePOS.My.Resources.Resources.tankehome1
        Me.tk_home1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.tk_home1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tk_home1.Name = "tk_home1"
        Me.tk_home1.Padding = New System.Windows.Forms.Padding(0)
        Me.tk_home1.Size = New System.Drawing.Size(105, 91)
        Me.tk_home1.Text = "Take To Home "
        Me.tk_home1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'VoidBill
        '
        Me.VoidBill.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VoidBill.Image = Global.BeecomePOS.My.Resources.Resources.viewbill1
        Me.VoidBill.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.VoidBill.Margin = New System.Windows.Forms.Padding(0, 10, 0, 0)
        Me.VoidBill.Name = "VoidBill"
        Me.VoidBill.Size = New System.Drawing.Size(80, 81)
        Me.VoidBill.Text = " View Bill "
        Me.VoidBill.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Font = New System.Drawing.Font("Tahoma", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripMenuItem1.ForeColor = System.Drawing.Color.Gray
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Padding = New System.Windows.Forms.Padding(0)
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(47, 91)
        Me.ToolStripMenuItem1.Text = "|"
        '
        'report1
        '
        Me.report1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.report1.Image = Global.BeecomePOS.My.Resources.Resources.m_report
        Me.report1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.report1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.report1.Name = "report1"
        Me.report1.Size = New System.Drawing.Size(73, 91)
        Me.report1.Text = " Report "
        Me.report1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'close_rop1
        '
        Me.close_rop1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.close_rop1.Image = Global.BeecomePOS.My.Resources.Resources.m_closerop
        Me.close_rop1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.close_rop1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.close_rop1.Name = "close_rop1"
        Me.close_rop1.Padding = New System.Windows.Forms.Padding(0)
        Me.close_rop1.Size = New System.Drawing.Size(101, 91)
        Me.close_rop1.Text = " Billing Period "
        Me.close_rop1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'close_day1
        '
        Me.close_day1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.close_day1.Image = Global.BeecomePOS.My.Resources.Resources.m_closerop
        Me.close_day1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.close_day1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.close_day1.Name = "close_day1"
        Me.close_day1.Padding = New System.Windows.Forms.Padding(0)
        Me.close_day1.Size = New System.Drawing.Size(110, 91)
        Me.close_day1.Text = "Summary Sales"
        Me.close_day1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.close_day1.ToolTipText = "ยอดขายรอบวัน"
        '
        'btn_seting
        '
        Me.btn_seting.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_seting.Image = Global.BeecomePOS.My.Resources.Resources.gear_32
        Me.btn_seting.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_seting.Margin = New System.Windows.Forms.Padding(0, 13, 0, 0)
        Me.btn_seting.Name = "btn_seting"
        Me.btn_seting.Padding = New System.Windows.Forms.Padding(0)
        Me.btn_seting.Size = New System.Drawing.Size(63, 78)
        Me.btn_seting.Text = " Setting"
        Me.btn_seting.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_seting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_seting.ToolTipText = "ตั้งค่าสินค้าต่างๆ"
        '
        'logout1
        '
        Me.logout1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.logout1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.logout1.Image = Global.BeecomePOS.My.Resources.Resources.m_logout
        Me.logout1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.logout1.Name = "logout1"
        Me.logout1.Size = New System.Drawing.Size(65, 91)
        Me.logout1.Text = "Logout"
        Me.logout1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.logout1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.logout1.ToolTipText = "ออกจากระบบ"
        '
        'StatusStrip2
        '
        Me.StatusStrip2.BackColor = System.Drawing.SystemColors.Control
        Me.StatusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.db_name, Me.ToolStripStatusLabel4, Me.company_name, Me.ToolStripStatusLabel5, Me.user_show, Me.ToolStripStatusLabel1})
        Me.StatusStrip2.Location = New System.Drawing.Point(0, 736)
        Me.StatusStrip2.Name = "StatusStrip2"
        Me.StatusStrip2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StatusStrip2.Size = New System.Drawing.Size(1024, 22)
        Me.StatusStrip2.TabIndex = 8
        Me.StatusStrip2.Text = "StatusStrip2"
        '
        'db_name
        '
        Me.db_name.Image = Global.BeecomePOS.My.Resources.Resources.Datbase_Lock
        Me.db_name.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.db_name.Name = "db_name"
        Me.db_name.Size = New System.Drawing.Size(116, 17)
        Me.db_name.Text = "DB.Name : DEMO"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(10, 17)
        Me.ToolStripStatusLabel4.Text = "|"
        '
        'company_name
        '
        Me.company_name.Image = Global.BeecomePOS.My.Resources.Resources.Computer_Add
        Me.company_name.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.company_name.Name = "company_name"
        Me.company_name.Size = New System.Drawing.Size(182, 17)
        Me.company_name.Text = "Company Name :  DEMO .,Ltd"
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(11, 17)
        Me.ToolStripStatusLabel5.Text = "|"
        '
        'user_show
        '
        Me.user_show.Image = Global.BeecomePOS.My.Resources.Resources.User__2_
        Me.user_show.Name = "user_show"
        Me.user_show.Size = New System.Drawing.Size(202, 17)
        Me.user_show.Text = "Username : TESTTER (Login 00:15)"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(488, 17)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolStripStatusLabel1.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(143, 6)
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.SaveAsToolStripMenuItem.Text = "Save &As"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(143, 6)
        '
        'toolStripSeparator2
        '
        Me.toolStripSeparator2.Name = "toolStripSeparator2"
        Me.toolStripSeparator2.Size = New System.Drawing.Size(143, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_th)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_eng)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(855, 37)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(77, 93)
        Me.FlowLayoutPanel1.TabIndex = 10
        '
        'btn_th
        '
        Me.btn_th.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_th.Image = Global.BeecomePOS.My.Resources.Resources.th
        Me.btn_th.Location = New System.Drawing.Point(3, 8)
        Me.btn_th.Name = "btn_th"
        Me.btn_th.Size = New System.Drawing.Size(71, 34)
        Me.btn_th.TabIndex = 0
        Me.btn_th.Text = "ไทย"
        Me.btn_th.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_th.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_th.UseVisualStyleBackColor = True
        '
        'btn_eng
        '
        Me.btn_eng.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_eng.Image = Global.BeecomePOS.My.Resources.Resources.English_Flag__1_
        Me.btn_eng.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_eng.Location = New System.Drawing.Point(3, 48)
        Me.btn_eng.Name = "btn_eng"
        Me.btn_eng.Size = New System.Drawing.Size(71, 34)
        Me.btn_eng.TabIndex = 1
        Me.btn_eng.Text = "ENG"
        Me.btn_eng.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_eng.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.BeecomePOS.My.Resources.Resources.title_bar_bg
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1024, 37)
        Me.Panel1.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.AutoSize = True
        Me.Panel5.BackColor = System.Drawing.Color.Transparent
        Me.Panel5.Controls.Add(Me.Label_Rop)
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel5.Location = New System.Drawing.Point(411, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(129, 37)
        Me.Panel5.TabIndex = 15
        '
        'Label_Rop
        '
        Me.Label_Rop.AutoSize = True
        Me.Label_Rop.BackColor = System.Drawing.Color.Transparent
        Me.Label_Rop.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label_Rop.ForeColor = System.Drawing.Color.Lime
        Me.Label_Rop.Location = New System.Drawing.Point(25, 1)
        Me.Label_Rop.Name = "Label_Rop"
        Me.Label_Rop.Size = New System.Drawing.Size(101, 31)
        Me.Label_Rop.TabIndex = 7
        Me.Label_Rop.Text = "รอบที่ 1"
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(6, 4)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(17, 24)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "-"
        '
        'Panel4
        '
        Me.Panel4.AutoSize = True
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.Controls.Add(Me.DMY)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel4.Location = New System.Drawing.Point(208, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(203, 37)
        Me.Panel4.TabIndex = 14
        '
        'DMY
        '
        Me.DMY.AutoSize = True
        Me.DMY.BackColor = System.Drawing.Color.Transparent
        Me.DMY.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.DMY.ForeColor = System.Drawing.Color.Yellow
        Me.DMY.Location = New System.Drawing.Point(18, 5)
        Me.DMY.Name = "DMY"
        Me.DMY.Size = New System.Drawing.Size(182, 25)
        Me.DMY.TabIndex = 6
        Me.DMY.Text = "วันที่  01/11/2557"
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(5, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(17, 24)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "-"
        '
        'Panel3
        '
        Me.Panel3.AutoSize = True
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(42, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(166, 37)
        Me.Panel3.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(160, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "BEECOME POS"
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = Global.BeecomePOS.My.Resources.Resources.menu_right
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.btn_maxsize)
        Me.Panel2.Controls.Add(Me.btn_mini)
        Me.Panel2.Controls.Add(Me.btn_close)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(847, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(177, 37)
        Me.Panel2.TabIndex = 5
        '
        'btn_maxsize
        '
        Me.btn_maxsize.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_maxsize.BackColor = System.Drawing.Color.Transparent
        Me.btn_maxsize.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_maxsize.FlatAppearance.BorderSize = 0
        Me.btn_maxsize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btn_maxsize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btn_maxsize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_maxsize.Image = Global.BeecomePOS.My.Resources.Resources.m_maxsize
        Me.btn_maxsize.Location = New System.Drawing.Point(109, 9)
        Me.btn_maxsize.Name = "btn_maxsize"
        Me.btn_maxsize.Size = New System.Drawing.Size(27, 23)
        Me.btn_maxsize.TabIndex = 3
        Me.btn_maxsize.UseVisualStyleBackColor = False
        '
        'btn_mini
        '
        Me.btn_mini.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_mini.BackColor = System.Drawing.Color.Transparent
        Me.btn_mini.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_mini.FlatAppearance.BorderSize = 0
        Me.btn_mini.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btn_mini.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btn_mini.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_mini.Image = Global.BeecomePOS.My.Resources.Resources.m_mini
        Me.btn_mini.Location = New System.Drawing.Point(84, 13)
        Me.btn_mini.Name = "btn_mini"
        Me.btn_mini.Size = New System.Drawing.Size(19, 21)
        Me.btn_mini.TabIndex = 3
        Me.btn_mini.UseVisualStyleBackColor = False
        '
        'btn_close
        '
        Me.btn_close.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_close.BackColor = System.Drawing.Color.Transparent
        Me.btn_close.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_close.FlatAppearance.BorderSize = 0
        Me.btn_close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btn_close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_close.Image = Global.BeecomePOS.My.Resources.Resources.m_close
        Me.btn_close.Location = New System.Drawing.Point(142, 8)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.Size = New System.Drawing.Size(21, 22)
        Me.btn_close.TabIndex = 3
        Me.btn_close.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox1.Image = Global.BeecomePOS.My.Resources.Resources.logo_menu
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(42, 37)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Image = CType(resources.GetObject("NewToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.NewToolStripMenuItem.Text = "&New"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Image = CType(resources.GetObject("OpenToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OpenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.OpenToolStripMenuItem.Text = "&Open"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Image = CType(resources.GetObject("SaveToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SaveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.SaveToolStripMenuItem.Text = "&Save"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Image = CType(resources.GetObject("PrintToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PrintToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.PrintToolStripMenuItem.Text = "&Print"
        '
        'PrintPreviewToolStripMenuItem
        '
        Me.PrintPreviewToolStripMenuItem.Image = CType(resources.GetObject("PrintPreviewToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PrintPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintPreviewToolStripMenuItem.Name = "PrintPreviewToolStripMenuItem"
        Me.PrintPreviewToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.PrintPreviewToolStripMenuItem.Text = "Print Pre&view"
        '
        'Timer2
        '
        Me.Timer2.Interval = 1000
        '
        'index
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1024, 758)
        Me.ControlBox = False
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.StatusStrip2)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "index"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form2"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip2.ResumeLayout(False)
        Me.StatusStrip2.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_mini As System.Windows.Forms.Button
    Friend WithEvents btn_close As System.Windows.Forms.Button
    Friend WithEvents btn_maxsize As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents StatusStrip2 As System.Windows.Forms.StatusStrip
    Friend WithEvents db_name As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents company_name As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel5 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents user_show As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents KkToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn_home1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents reserv1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tk_home1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents report1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents close_rop1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents close_day1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn_seting As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents logout1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintPreviewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btn_th As System.Windows.Forms.Button
    Friend WithEvents btn_eng As System.Windows.Forms.Button
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VoidBill As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents edit_profile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents edit_p As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label_Rop As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents DMY As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
End Class
