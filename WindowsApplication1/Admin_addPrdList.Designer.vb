<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_addPrdList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Admin_addPrdList))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ListView_PRD = New System.Windows.Forms.ListView()
        Me.id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Select1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.no = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Group = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SubGroup = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.NumberProduct = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Name_TH = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Name_EN = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Unit = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Price = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Status = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.OnTable = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ToolStrip_Menu = New System.Windows.Forms.ToolStrip()
        Me.btn_edit = New System.Windows.Forms.ToolStripButton()
        Me.btn_del = New System.Windows.Forms.ToolStripButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.subgroup_filter = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btn_filter = New System.Windows.Forms.Button()
        Me.status_filter = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ontb_filter = New System.Windows.Forms.ComboBox()
        Me.category_filter = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.text_filter = New System.Windows.Forms.TextBox()
        Me.btn_addprd = New System.Windows.Forms.Button()
        Me.btn_close = New System.Windows.Forms.Button()
        Me.btn_reload = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip_Menu.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Location = New System.Drawing.Point(0, 35)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(6)
        Me.Panel1.Size = New System.Drawing.Size(1112, 529)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ListView_PRD)
        Me.GroupBox1.Controls.Add(Me.ToolStrip_Menu)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 102)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(6)
        Me.GroupBox1.Size = New System.Drawing.Size(1100, 421)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Product List"
        '
        'ListView_PRD
        '
        Me.ListView_PRD.BackColor = System.Drawing.Color.White
        Me.ListView_PRD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListView_PRD.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.id, Me.Select1, Me.no, Me.Group, Me.SubGroup, Me.NumberProduct, Me.Name_TH, Me.Name_EN, Me.Unit, Me.Price, Me.Status, Me.OnTable})
        Me.ListView_PRD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView_PRD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.ListView_PRD.FullRowSelect = True
        Me.ListView_PRD.GridLines = True
        Me.ListView_PRD.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListView_PRD.Location = New System.Drawing.Point(6, 48)
        Me.ListView_PRD.Name = "ListView_PRD"
        Me.ListView_PRD.Size = New System.Drawing.Size(1088, 367)
        Me.ListView_PRD.TabIndex = 3
        Me.ListView_PRD.UseCompatibleStateImageBehavior = False
        Me.ListView_PRD.View = System.Windows.Forms.View.Details
        '
        'id
        '
        Me.id.Text = "id"
        Me.id.Width = 0
        '
        'Select1
        '
        Me.Select1.Text = "Select"
        Me.Select1.Width = 0
        '
        'no
        '
        Me.no.Text = "No."
        Me.no.Width = 40
        '
        'Group
        '
        Me.Group.Text = "Group"
        Me.Group.Width = 100
        '
        'SubGroup
        '
        Me.SubGroup.Text = "Sub Group"
        Me.SubGroup.Width = 120
        '
        'NumberProduct
        '
        Me.NumberProduct.Text = "Number Product"
        Me.NumberProduct.Width = 120
        '
        'Name_TH
        '
        Me.Name_TH.Text = "Name (TH)"
        Me.Name_TH.Width = 150
        '
        'Name_EN
        '
        Me.Name_EN.Text = "Name (EN)"
        Me.Name_EN.Width = 150
        '
        'Unit
        '
        Me.Unit.Text = "Unit"
        Me.Unit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Price
        '
        Me.Price.Text = "Price (Bath)"
        Me.Price.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Price.Width = 70
        '
        'Status
        '
        Me.Status.Text = "Status"
        Me.Status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Status.Width = 70
        '
        'OnTable
        '
        Me.OnTable.Text = "OnTable"
        Me.OnTable.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OnTable.Width = 70
        '
        'ToolStrip_Menu
        '
        Me.ToolStrip_Menu.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStrip_Menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip_Menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_edit, Me.btn_del})
        Me.ToolStrip_Menu.Location = New System.Drawing.Point(6, 23)
        Me.ToolStrip_Menu.Name = "ToolStrip_Menu"
        Me.ToolStrip_Menu.Size = New System.Drawing.Size(1088, 25)
        Me.ToolStrip_Menu.TabIndex = 2
        Me.ToolStrip_Menu.Text = "ToolStrip1"
        '
        'btn_edit
        '
        Me.btn_edit.Image = Global.BeecomePOS.My.Resources.Resources.pencil_16
        Me.btn_edit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_edit.Name = "btn_edit"
        Me.btn_edit.Size = New System.Drawing.Size(47, 22)
        Me.btn_edit.Text = "Edit"
        '
        'btn_del
        '
        Me.btn_del.BackColor = System.Drawing.SystemColors.Control
        Me.btn_del.Image = Global.BeecomePOS.My.Resources.Resources.trash_16
        Me.btn_del.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_del.Name = "btn_del"
        Me.btn_del.Size = New System.Drawing.Size(60, 22)
        Me.btn_del.Text = "Delete"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.btn_addprd)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(6, 6)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(6, 6, 0, 6)
        Me.Panel2.Size = New System.Drawing.Size(1100, 96)
        Me.Panel2.TabIndex = 4
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.Control
        Me.Panel3.Controls.Add(Me.GroupBox2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(161, 6)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(12, 0, 0, 0)
        Me.Panel3.Size = New System.Drawing.Size(939, 84)
        Me.Panel3.TabIndex = 4
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox2.Controls.Add(Me.subgroup_filter)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.btn_filter)
        Me.GroupBox2.Controls.Add(Me.status_filter)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.ontb_filter)
        Me.GroupBox2.Controls.Add(Me.category_filter)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.text_filter)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(12, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(927, 84)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Search Product"
        '
        'subgroup_filter
        '
        Me.subgroup_filter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.subgroup_filter.FormattingEnabled = True
        Me.subgroup_filter.Location = New System.Drawing.Point(250, 54)
        Me.subgroup_filter.Name = "subgroup_filter"
        Me.subgroup_filter.Size = New System.Drawing.Size(218, 23)
        Me.subgroup_filter.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(177, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 15)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Sub Group"
        '
        'btn_filter
        '
        Me.btn_filter.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_filter.Image = Global.BeecomePOS.My.Resources.Resources.search_16
        Me.btn_filter.Location = New System.Drawing.Point(679, 16)
        Me.btn_filter.Name = "btn_filter"
        Me.btn_filter.Size = New System.Drawing.Size(114, 59)
        Me.btn_filter.TabIndex = 8
        Me.btn_filter.Text = "ค้นหา"
        Me.btn_filter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_filter.UseVisualStyleBackColor = True
        '
        'status_filter
        '
        Me.status_filter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.status_filter.FormattingEnabled = True
        Me.status_filter.Location = New System.Drawing.Point(553, 52)
        Me.status_filter.Name = "status_filter"
        Me.status_filter.Size = New System.Drawing.Size(108, 23)
        Me.status_filter.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(474, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 15)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Status Sales"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(494, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 15)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "On table"
        '
        'ontb_filter
        '
        Me.ontb_filter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ontb_filter.FormattingEnabled = True
        Me.ontb_filter.Location = New System.Drawing.Point(553, 17)
        Me.ontb_filter.Name = "ontb_filter"
        Me.ontb_filter.Size = New System.Drawing.Size(105, 23)
        Me.ontb_filter.TabIndex = 4
        '
        'category_filter
        '
        Me.category_filter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.category_filter.FormattingEnabled = True
        Me.category_filter.Location = New System.Drawing.Point(250, 20)
        Me.category_filter.Name = "category_filter"
        Me.category_filter.Size = New System.Drawing.Size(218, 23)
        Me.category_filter.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(203, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Group"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Name"
        '
        'text_filter
        '
        Me.text_filter.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.text_filter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.text_filter.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.text_filter.Location = New System.Drawing.Point(17, 38)
        Me.text_filter.Name = "text_filter"
        Me.text_filter.Size = New System.Drawing.Size(154, 26)
        Me.text_filter.TabIndex = 0
        '
        'btn_addprd
        '
        Me.btn_addprd.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btn_addprd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_addprd.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_addprd.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_addprd.ForeColor = System.Drawing.Color.White
        Me.btn_addprd.Image = Global.BeecomePOS.My.Resources.Resources.plus
        Me.btn_addprd.Location = New System.Drawing.Point(6, 6)
        Me.btn_addprd.Margin = New System.Windows.Forms.Padding(3, 3, 23, 3)
        Me.btn_addprd.Name = "btn_addprd"
        Me.btn_addprd.Size = New System.Drawing.Size(155, 84)
        Me.btn_addprd.TabIndex = 3
        Me.btn_addprd.Text = "Add Product"
        Me.btn_addprd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_addprd.UseVisualStyleBackColor = False
        '
        'btn_close
        '
        Me.btn_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_close.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_close.Image = Global.BeecomePOS.My.Resources.Resources.delete_16
        Me.btn_close.Location = New System.Drawing.Point(1071, 0)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.Size = New System.Drawing.Size(37, 33)
        Me.btn_close.TabIndex = 9
        Me.btn_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_close.UseVisualStyleBackColor = True
        '
        'btn_reload
        '
        Me.btn_reload.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_reload.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_reload.Image = Global.BeecomePOS.My.Resources.Resources.arrow_circle
        Me.btn_reload.Location = New System.Drawing.Point(1029, 0)
        Me.btn_reload.Name = "btn_reload"
        Me.btn_reload.Size = New System.Drawing.Size(37, 33)
        Me.btn_reload.TabIndex = 9
        Me.btn_reload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_reload.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Button1.Image = Global.BeecomePOS.My.Resources.Resources.print_32
        Me.Button1.Location = New System.Drawing.Point(5, 1)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(161, 39)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Print"
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Admin_addPrdList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(1112, 564)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btn_close)
        Me.Controls.Add(Me.btn_reload)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(869, 602)
        Me.Name = "Admin_addPrdList"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Product List"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip_Menu.ResumeLayout(False)
        Me.ToolStrip_Menu.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btn_addprd As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents status_filter As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ontb_filter As System.Windows.Forms.ComboBox
    Friend WithEvents category_filter As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents text_filter As System.Windows.Forms.TextBox
    Friend WithEvents btn_filter As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_reload As System.Windows.Forms.Button
    Friend WithEvents btn_close As System.Windows.Forms.Button
    Friend WithEvents ToolStrip_Menu As System.Windows.Forms.ToolStrip
    Friend WithEvents btn_del As System.Windows.Forms.ToolStripButton
    Friend WithEvents ListView_PRD As System.Windows.Forms.ListView
    Friend WithEvents id As System.Windows.Forms.ColumnHeader
    Friend WithEvents no As System.Windows.Forms.ColumnHeader
    Friend WithEvents Group As System.Windows.Forms.ColumnHeader
    Friend WithEvents SubGroup As System.Windows.Forms.ColumnHeader
    Friend WithEvents NumberProduct As System.Windows.Forms.ColumnHeader
    Friend WithEvents Name_TH As System.Windows.Forms.ColumnHeader
    Friend WithEvents Name_EN As System.Windows.Forms.ColumnHeader
    Friend WithEvents Unit As System.Windows.Forms.ColumnHeader
    Friend WithEvents Price As System.Windows.Forms.ColumnHeader
    Friend WithEvents Status As System.Windows.Forms.ColumnHeader
    Friend WithEvents OnTable As System.Windows.Forms.ColumnHeader
    Friend WithEvents Select1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btn_edit As System.Windows.Forms.ToolStripButton
    Friend WithEvents subgroup_filter As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
