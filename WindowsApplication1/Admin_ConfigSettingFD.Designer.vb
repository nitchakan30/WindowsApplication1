<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_ConfigSettingFD
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.ListView_Ingre = New System.Windows.Forms.ListView()
        Me.id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btn_del_ingre = New System.Windows.Forms.Button()
        Me.btn_edit_ingre = New System.Windows.Forms.Button()
        Me.btn_add_ingre = New System.Windows.Forms.Button()
        Me.btn_auto_Id_Ingre = New System.Windows.Forms.PictureBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_code_ingre = New System.Windows.Forms.TextBox()
        Me.btn_save_ingre = New System.Windows.Forms.Button()
        Me.btn_cancle_ingre = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_nameEN_ingre = New System.Windows.Forms.TextBox()
        Me.txt_nameTH_ingre = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.ListView_size = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.id_1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btn_del_size = New System.Windows.Forms.Button()
        Me.btn_edit_size = New System.Windows.Forms.Button()
        Me.btn_add_size = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_nameEN_size = New System.Windows.Forms.TextBox()
        Me.txt_nameTH_size = New System.Windows.Forms.TextBox()
        Me.btn_auto_Id_Size = New System.Windows.Forms.PictureBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_code_size = New System.Windows.Forms.TextBox()
        Me.btn_save_size = New System.Windows.Forms.Button()
        Me.btn_cancle_size = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.btn_auto_Id_Ingre, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.btn_auto_Id_Size, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(534, 491)
        Me.TabControl1.TabIndex = 67
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.ListView_Ingre)
        Me.TabPage1.Controls.Add(Me.btn_del_ingre)
        Me.TabPage1.Controls.Add(Me.btn_edit_ingre)
        Me.TabPage1.Controls.Add(Me.btn_add_ingre)
        Me.TabPage1.Controls.Add(Me.btn_auto_Id_Ingre)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.txt_code_ingre)
        Me.TabPage1.Controls.Add(Me.btn_save_ingre)
        Me.TabPage1.Controls.Add(Me.btn_cancle_ingre)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txt_nameEN_ingre)
        Me.TabPage1.Controls.Add(Me.txt_nameTH_ingre)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(526, 465)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Ingredients Food"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'ListView_Ingre
        '
        Me.ListView_Ingre.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.ListView_Ingre.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView_Ingre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListView_Ingre.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.id, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.ListView_Ingre.FullRowSelect = True
        Me.ListView_Ingre.GridLines = True
        Me.ListView_Ingre.Location = New System.Drawing.Point(-1, 146)
        Me.ListView_Ingre.MultiSelect = False
        Me.ListView_Ingre.Name = "ListView_Ingre"
        Me.ListView_Ingre.Size = New System.Drawing.Size(527, 318)
        Me.ListView_Ingre.TabIndex = 88
        Me.ListView_Ingre.UseCompatibleStateImageBehavior = False
        Me.ListView_Ingre.View = System.Windows.Forms.View.Details
        '
        'id
        '
        Me.id.Text = "id"
        Me.id.Width = 0
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "No."
        Me.ColumnHeader5.Width = 45
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "CODE"
        Me.ColumnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader6.Width = 80
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "UNIT Name [TH]"
        Me.ColumnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader7.Width = 150
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "UNIT Name [EN]"
        Me.ColumnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader8.Width = 150
        '
        'btn_del_ingre
        '
        Me.btn_del_ingre.BackColor = System.Drawing.SystemColors.Control
        Me.btn_del_ingre.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_del_ingre.Enabled = False
        Me.btn_del_ingre.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_del_ingre.Image = Global.BeecomePOS.My.Resources.Resources.minus1
        Me.btn_del_ingre.Location = New System.Drawing.Point(166, 100)
        Me.btn_del_ingre.Name = "btn_del_ingre"
        Me.btn_del_ingre.Size = New System.Drawing.Size(71, 33)
        Me.btn_del_ingre.TabIndex = 86
        Me.btn_del_ingre.Text = "Delete"
        Me.btn_del_ingre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_del_ingre.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_del_ingre.UseVisualStyleBackColor = False
        '
        'btn_edit_ingre
        '
        Me.btn_edit_ingre.BackColor = System.Drawing.SystemColors.Control
        Me.btn_edit_ingre.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_edit_ingre.Enabled = False
        Me.btn_edit_ingre.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_edit_ingre.Image = Global.BeecomePOS.My.Resources.Resources.pencil_16
        Me.btn_edit_ingre.Location = New System.Drawing.Point(89, 100)
        Me.btn_edit_ingre.Name = "btn_edit_ingre"
        Me.btn_edit_ingre.Size = New System.Drawing.Size(71, 33)
        Me.btn_edit_ingre.TabIndex = 87
        Me.btn_edit_ingre.Text = "Edit"
        Me.btn_edit_ingre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_edit_ingre.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_edit_ingre.UseVisualStyleBackColor = False
        '
        'btn_add_ingre
        '
        Me.btn_add_ingre.BackColor = System.Drawing.SystemColors.Control
        Me.btn_add_ingre.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_add_ingre.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_add_ingre.Image = Global.BeecomePOS.My.Resources.Resources.plus_16
        Me.btn_add_ingre.Location = New System.Drawing.Point(5, 100)
        Me.btn_add_ingre.Name = "btn_add_ingre"
        Me.btn_add_ingre.Size = New System.Drawing.Size(78, 33)
        Me.btn_add_ingre.TabIndex = 85
        Me.btn_add_ingre.Text = "New"
        Me.btn_add_ingre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_add_ingre.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_add_ingre.UseVisualStyleBackColor = False
        '
        'btn_auto_Id_Ingre
        '
        Me.btn_auto_Id_Ingre.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_auto_Id_Ingre.Image = Global.BeecomePOS.My.Resources.Resources.Ok
        Me.btn_auto_Id_Ingre.Location = New System.Drawing.Point(116, 23)
        Me.btn_auto_Id_Ingre.Name = "btn_auto_Id_Ingre"
        Me.btn_auto_Id_Ingre.Size = New System.Drawing.Size(16, 18)
        Me.btn_auto_Id_Ingre.TabIndex = 79
        Me.btn_auto_Id_Ingre.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 78
        Me.Label7.Text = "CODE :"
        '
        'txt_code_ingre
        '
        Me.txt_code_ingre.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txt_code_ingre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_code_ingre.Location = New System.Drawing.Point(51, 22)
        Me.txt_code_ingre.MaxLength = 8
        Me.txt_code_ingre.Name = "txt_code_ingre"
        Me.txt_code_ingre.Size = New System.Drawing.Size(60, 20)
        Me.txt_code_ingre.TabIndex = 77
        '
        'btn_save_ingre
        '
        Me.btn_save_ingre.BackColor = System.Drawing.SystemColors.Control
        Me.btn_save_ingre.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_save_ingre.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_save_ingre.Image = Global.BeecomePOS.My.Resources.Resources.save_16
        Me.btn_save_ingre.Location = New System.Drawing.Point(440, 15)
        Me.btn_save_ingre.Name = "btn_save_ingre"
        Me.btn_save_ingre.Size = New System.Drawing.Size(78, 33)
        Me.btn_save_ingre.TabIndex = 73
        Me.btn_save_ingre.Text = "Save"
        Me.btn_save_ingre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_save_ingre.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_save_ingre.UseVisualStyleBackColor = False
        '
        'btn_cancle_ingre
        '
        Me.btn_cancle_ingre.BackColor = System.Drawing.SystemColors.Control
        Me.btn_cancle_ingre.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_cancle_ingre.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_cancle_ingre.Image = Global.BeecomePOS.My.Resources.Resources.delete_16
        Me.btn_cancle_ingre.Location = New System.Drawing.Point(440, 54)
        Me.btn_cancle_ingre.Name = "btn_cancle_ingre"
        Me.btn_cancle_ingre.Size = New System.Drawing.Size(78, 33)
        Me.btn_cancle_ingre.TabIndex = 72
        Me.btn_cancle_ingre.Text = "Cancle"
        Me.btn_cancle_ingre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_cancle_ingre.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_cancle_ingre.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(145, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 13)
        Me.Label3.TabIndex = 70
        Me.Label3.Text = "Unit Name [ EN ] :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(145, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 71
        Me.Label2.Text = "Unit Name [ TH ] :"
        '
        'txt_nameEN_ingre
        '
        Me.txt_nameEN_ingre.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txt_nameEN_ingre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_nameEN_ingre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_nameEN_ingre.Location = New System.Drawing.Point(243, 52)
        Me.txt_nameEN_ingre.MaxLength = 100
        Me.txt_nameEN_ingre.Name = "txt_nameEN_ingre"
        Me.txt_nameEN_ingre.Size = New System.Drawing.Size(191, 22)
        Me.txt_nameEN_ingre.TabIndex = 68
        '
        'txt_nameTH_ingre
        '
        Me.txt_nameTH_ingre.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txt_nameTH_ingre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_nameTH_ingre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_nameTH_ingre.Location = New System.Drawing.Point(243, 23)
        Me.txt_nameTH_ingre.MaxLength = 100
        Me.txt_nameTH_ingre.Name = "txt_nameTH_ingre"
        Me.txt_nameTH_ingre.Size = New System.Drawing.Size(191, 22)
        Me.txt_nameTH_ingre.TabIndex = 69
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.ListView_size)
        Me.TabPage2.Controls.Add(Me.btn_del_size)
        Me.TabPage2.Controls.Add(Me.btn_edit_size)
        Me.TabPage2.Controls.Add(Me.btn_add_size)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.txt_nameEN_size)
        Me.TabPage2.Controls.Add(Me.txt_nameTH_size)
        Me.TabPage2.Controls.Add(Me.btn_auto_Id_Size)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.txt_code_size)
        Me.TabPage2.Controls.Add(Me.btn_save_size)
        Me.TabPage2.Controls.Add(Me.btn_cancle_size)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(526, 465)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Size Food"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'ListView_size
        '
        Me.ListView_size.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.ListView_size.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView_size.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListView_size.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.id_1, Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.ListView_size.FullRowSelect = True
        Me.ListView_size.GridLines = True
        Me.ListView_size.Location = New System.Drawing.Point(0, 147)
        Me.ListView_size.MultiSelect = False
        Me.ListView_size.Name = "ListView_size"
        Me.ListView_size.Size = New System.Drawing.Size(526, 318)
        Me.ListView_size.TabIndex = 85
        Me.ListView_size.UseCompatibleStateImageBehavior = False
        Me.ListView_size.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.DisplayIndex = 1
        Me.ColumnHeader1.Text = "No."
        Me.ColumnHeader1.Width = 45
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.DisplayIndex = 2
        Me.ColumnHeader2.Text = "Code Size"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader2.Width = 80
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.DisplayIndex = 3
        Me.ColumnHeader3.Text = "Size Name [TH]"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader3.Width = 150
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Size Name [EN]"
        Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader4.Width = 150
        '
        'id_1
        '
        Me.id_1.Text = "id"
        Me.id_1.Width = 0
        '
        'btn_del_size
        '
        Me.btn_del_size.BackColor = System.Drawing.SystemColors.Control
        Me.btn_del_size.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_del_size.Enabled = False
        Me.btn_del_size.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_del_size.Image = Global.BeecomePOS.My.Resources.Resources.minus1
        Me.btn_del_size.Location = New System.Drawing.Point(163, 104)
        Me.btn_del_size.Name = "btn_del_size"
        Me.btn_del_size.Size = New System.Drawing.Size(71, 33)
        Me.btn_del_size.TabIndex = 83
        Me.btn_del_size.Text = "Delete"
        Me.btn_del_size.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_del_size.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_del_size.UseVisualStyleBackColor = False
        '
        'btn_edit_size
        '
        Me.btn_edit_size.BackColor = System.Drawing.SystemColors.Control
        Me.btn_edit_size.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_edit_size.Enabled = False
        Me.btn_edit_size.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_edit_size.Image = Global.BeecomePOS.My.Resources.Resources.pencil_16
        Me.btn_edit_size.Location = New System.Drawing.Point(86, 104)
        Me.btn_edit_size.Name = "btn_edit_size"
        Me.btn_edit_size.Size = New System.Drawing.Size(71, 33)
        Me.btn_edit_size.TabIndex = 84
        Me.btn_edit_size.Text = "Edit"
        Me.btn_edit_size.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_edit_size.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_edit_size.UseVisualStyleBackColor = False
        '
        'btn_add_size
        '
        Me.btn_add_size.BackColor = System.Drawing.SystemColors.Control
        Me.btn_add_size.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_add_size.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_add_size.Image = Global.BeecomePOS.My.Resources.Resources.plus_16
        Me.btn_add_size.Location = New System.Drawing.Point(2, 104)
        Me.btn_add_size.Name = "btn_add_size"
        Me.btn_add_size.Size = New System.Drawing.Size(78, 33)
        Me.btn_add_size.TabIndex = 82
        Me.btn_add_size.Text = "New"
        Me.btn_add_size.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_add_size.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_add_size.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(133, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 13)
        Me.Label4.TabIndex = 81
        Me.Label4.Text = "Size Name [ EN ] :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(133, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 13)
        Me.Label5.TabIndex = 80
        Me.Label5.Text = "Size Name [ TH ] :"
        '
        'txt_nameEN_size
        '
        Me.txt_nameEN_size.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txt_nameEN_size.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_nameEN_size.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_nameEN_size.Location = New System.Drawing.Point(233, 51)
        Me.txt_nameEN_size.MaxLength = 100
        Me.txt_nameEN_size.Name = "txt_nameEN_size"
        Me.txt_nameEN_size.Size = New System.Drawing.Size(190, 22)
        Me.txt_nameEN_size.TabIndex = 77
        '
        'txt_nameTH_size
        '
        Me.txt_nameTH_size.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txt_nameTH_size.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_nameTH_size.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_nameTH_size.Location = New System.Drawing.Point(233, 22)
        Me.txt_nameTH_size.MaxLength = 100
        Me.txt_nameTH_size.Name = "txt_nameTH_size"
        Me.txt_nameTH_size.Size = New System.Drawing.Size(190, 22)
        Me.txt_nameTH_size.TabIndex = 78
        '
        'btn_auto_Id_Size
        '
        Me.btn_auto_Id_Size.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_auto_Id_Size.Image = Global.BeecomePOS.My.Resources.Resources.Ok
        Me.btn_auto_Id_Size.Location = New System.Drawing.Point(111, 24)
        Me.btn_auto_Id_Size.Name = "btn_auto_Id_Size"
        Me.btn_auto_Id_Size.Size = New System.Drawing.Size(16, 18)
        Me.btn_auto_Id_Size.TabIndex = 76
        Me.btn_auto_Id_Size.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 75
        Me.Label6.Text = "CODE :"
        '
        'txt_code_size
        '
        Me.txt_code_size.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txt_code_size.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_code_size.Location = New System.Drawing.Point(46, 22)
        Me.txt_code_size.MaxLength = 8
        Me.txt_code_size.Name = "txt_code_size"
        Me.txt_code_size.Size = New System.Drawing.Size(60, 20)
        Me.txt_code_size.TabIndex = 74
        '
        'btn_save_size
        '
        Me.btn_save_size.BackColor = System.Drawing.SystemColors.Control
        Me.btn_save_size.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_save_size.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_save_size.Image = Global.BeecomePOS.My.Resources.Resources.save_16
        Me.btn_save_size.Location = New System.Drawing.Point(429, 22)
        Me.btn_save_size.Name = "btn_save_size"
        Me.btn_save_size.Size = New System.Drawing.Size(78, 33)
        Me.btn_save_size.TabIndex = 66
        Me.btn_save_size.Text = "Save"
        Me.btn_save_size.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_save_size.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_save_size.UseVisualStyleBackColor = False
        '
        'btn_cancle_size
        '
        Me.btn_cancle_size.BackColor = System.Drawing.SystemColors.Control
        Me.btn_cancle_size.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_cancle_size.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_cancle_size.Image = Global.BeecomePOS.My.Resources.Resources.delete_16
        Me.btn_cancle_size.Location = New System.Drawing.Point(429, 61)
        Me.btn_cancle_size.Name = "btn_cancle_size"
        Me.btn_cancle_size.Size = New System.Drawing.Size(78, 33)
        Me.btn_cancle_size.TabIndex = 65
        Me.btn_cancle_size.Text = "Cancle"
        Me.btn_cancle_size.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_cancle_size.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_cancle_size.UseVisualStyleBackColor = False
        '
        'Admin_ConfigSettingFD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(534, 491)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Admin_ConfigSettingFD"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Setting ingredients and size "
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.btn_auto_Id_Ingre, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.btn_auto_Id_Size, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents btn_cancle_size As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_nameEN_ingre As System.Windows.Forms.TextBox
    Friend WithEvents txt_nameTH_ingre As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_nameEN_size As System.Windows.Forms.TextBox
    Friend WithEvents txt_nameTH_size As System.Windows.Forms.TextBox
    Friend WithEvents btn_auto_Id_Size As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_code_size As System.Windows.Forms.TextBox
    Friend WithEvents btn_save_size As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btn_del_size As System.Windows.Forms.Button
    Friend WithEvents btn_edit_size As System.Windows.Forms.Button
    Friend WithEvents btn_add_size As System.Windows.Forms.Button
    Friend WithEvents ListView_size As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ListView_Ingre As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btn_del_ingre As System.Windows.Forms.Button
    Friend WithEvents btn_edit_ingre As System.Windows.Forms.Button
    Friend WithEvents btn_add_ingre As System.Windows.Forms.Button
    Friend WithEvents btn_auto_Id_Ingre As System.Windows.Forms.PictureBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_code_ingre As System.Windows.Forms.TextBox
    Friend WithEvents btn_save_ingre As System.Windows.Forms.Button
    Friend WithEvents btn_cancle_ingre As System.Windows.Forms.Button
    Friend WithEvents id As System.Windows.Forms.ColumnHeader
    Friend WithEvents id_1 As System.Windows.Forms.ColumnHeader
End Class
