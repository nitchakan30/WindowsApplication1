<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_addCatPrd
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("All")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Admin_addCatPrd))
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnAddCat = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.btnEditCat = New System.Windows.Forms.ToolStripButton()
        Me.btnDelCat = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDesCatEN = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnOnTBOff = New System.Windows.Forms.Button()
        Me.btnOnTBOpen = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnSalesOff = New System.Windows.Forms.Button()
        Me.btnSalesOpen = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnClearText = New System.Windows.Forms.Button()
        Me.btnSaveCat = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtDesCatTH = New System.Windows.Forms.TextBox()
        Me.txtIDCat = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TreeView1
        '
        Me.TreeView1.BackColor = System.Drawing.Color.White
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Left
        Me.TreeView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TreeView1.LineColor = System.Drawing.Color.Maroon
        Me.TreeView1.Location = New System.Drawing.Point(0, 0)
        Me.TreeView1.Name = "TreeView1"
        TreeNode1.Name = "Node0"
        TreeNode1.Text = "All"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1})
        Me.TreeView1.Size = New System.Drawing.Size(217, 518)
        Me.TreeView1.TabIndex = 12
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(217, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(634, 518)
        Me.Panel1.TabIndex = 11
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAddCat, Me.ToolStripButton4, Me.btnEditCat, Me.btnDelCat})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(634, 54)
        Me.ToolStrip1.TabIndex = 11
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnAddCat
        '
        Me.btnAddCat.ForeColor = System.Drawing.Color.Black
        Me.btnAddCat.Image = Global.BeecomePOS.My.Resources.Resources.plus_32
        Me.btnAddCat.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnAddCat.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAddCat.Name = "btnAddCat"
        Me.btnAddCat.Size = New System.Drawing.Size(69, 51)
        Me.btnAddCat.Text = "Add Group"
        Me.btnAddCat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton4.ForeColor = System.Drawing.Color.Black
        Me.ToolStripButton4.Image = Global.BeecomePOS.My.Resources.Resources.delete_16
        Me.ToolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(57, 51)
        Me.ToolStripButton4.Text = "ปิดหน้าจอ"
        Me.ToolStripButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnEditCat
        '
        Me.btnEditCat.ForeColor = System.Drawing.Color.Black
        Me.btnEditCat.Image = Global.BeecomePOS.My.Resources.Resources.pencil_32
        Me.btnEditCat.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnEditCat.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEditCat.Name = "btnEditCat"
        Me.btnEditCat.Size = New System.Drawing.Size(36, 51)
        Me.btnEditCat.Text = "Edit"
        Me.btnEditCat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnDelCat
        '
        Me.btnDelCat.ForeColor = System.Drawing.Color.Black
        Me.btnDelCat.Image = Global.BeecomePOS.My.Resources.Resources.trash_32
        Me.btnDelCat.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnDelCat.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDelCat.Name = "btnDelCat"
        Me.btnDelCat.Size = New System.Drawing.Size(44, 51)
        Me.btnDelCat.Text = "Delete"
        Me.btnDelCat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtDesCatEN)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.btnOnTBOff)
        Me.GroupBox1.Controls.Add(Me.btnOnTBOpen)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnSalesOff)
        Me.GroupBox1.Controls.Add(Me.btnSalesOpen)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.btnCancel)
        Me.GroupBox1.Controls.Add(Me.btnClearText)
        Me.GroupBox1.Controls.Add(Me.btnSaveCat)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtDesCatTH)
        Me.GroupBox1.Controls.Add(Me.txtIDCat)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(217, 57)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(634, 461)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Add Group Food"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(385, 93)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(15, 18)
        Me.Label8.TabIndex = 44
        Me.Label8.Text = "*"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(26, 91)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(124, 18)
        Me.Label6.TabIndex = 42
        Me.Label6.Text = "Name Group [En]"
        '
        'txtDesCatEN
        '
        Me.txtDesCatEN.Enabled = False
        Me.txtDesCatEN.Location = New System.Drawing.Point(190, 91)
        Me.txtDesCatEN.MaxLength = 100
        Me.txtDesCatEN.Name = "txtDesCatEN"
        Me.txtDesCatEN.Size = New System.Drawing.Size(188, 24)
        Me.txtDesCatEN.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(385, 61)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(15, 18)
        Me.Label5.TabIndex = 41
        Me.Label5.Text = "*"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(385, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(15, 18)
        Me.Label4.TabIndex = 40
        Me.Label4.Text = "*"
        '
        'btnOnTBOff
        '
        Me.btnOnTBOff.BackColor = System.Drawing.Color.Red
        Me.btnOnTBOff.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOnTBOff.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.btnOnTBOff.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red
        Me.btnOnTBOff.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.btnOnTBOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOnTBOff.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnOnTBOff.Location = New System.Drawing.Point(245, 163)
        Me.btnOnTBOff.Name = "btnOnTBOff"
        Me.btnOnTBOff.Size = New System.Drawing.Size(60, 28)
        Me.btnOnTBOff.TabIndex = 6
        Me.btnOnTBOff.Text = "ปิด"
        Me.btnOnTBOff.UseVisualStyleBackColor = False
        '
        'btnOnTBOpen
        '
        Me.btnOnTBOpen.BackColor = System.Drawing.Color.DarkGray
        Me.btnOnTBOpen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOnTBOpen.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.btnOnTBOpen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnOnTBOpen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnOnTBOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOnTBOpen.ForeColor = System.Drawing.Color.White
        Me.btnOnTBOpen.Location = New System.Drawing.Point(184, 163)
        Me.btnOnTBOpen.Name = "btnOnTBOpen"
        Me.btnOnTBOpen.Size = New System.Drawing.Size(61, 28)
        Me.btnOnTBOpen.TabIndex = 5
        Me.btnOnTBOpen.Text = "เปิด"
        Me.btnOnTBOpen.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(55, 169)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 18)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Count Stock"
        '
        'btnSalesOff
        '
        Me.btnSalesOff.BackColor = System.Drawing.Color.Red
        Me.btnSalesOff.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSalesOff.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.btnSalesOff.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.btnSalesOff.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.btnSalesOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalesOff.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnSalesOff.Location = New System.Drawing.Point(245, 129)
        Me.btnSalesOff.Name = "btnSalesOff"
        Me.btnSalesOff.Size = New System.Drawing.Size(60, 28)
        Me.btnSalesOff.TabIndex = 4
        Me.btnSalesOff.Text = "ปิด"
        Me.btnSalesOff.UseVisualStyleBackColor = False
        '
        'btnSalesOpen
        '
        Me.btnSalesOpen.BackColor = System.Drawing.Color.DarkGray
        Me.btnSalesOpen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSalesOpen.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.btnSalesOpen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnSalesOpen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver
        Me.btnSalesOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalesOpen.ForeColor = System.Drawing.Color.White
        Me.btnSalesOpen.Location = New System.Drawing.Point(184, 129)
        Me.btnSalesOpen.Name = "btnSalesOpen"
        Me.btnSalesOpen.Size = New System.Drawing.Size(61, 28)
        Me.btnSalesOpen.TabIndex = 3
        Me.btnSalesOpen.Text = "เปิด"
        Me.btnSalesOpen.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(55, 129)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 18)
        Me.Label7.TabIndex = 34
        Me.Label7.Text = "On/Off Sale"
        '
        'btnCancel
        '
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.Enabled = False
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(431, 104)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.btnCancel.Size = New System.Drawing.Size(159, 30)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnClearText
        '
        Me.btnClearText.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClearText.Enabled = False
        Me.btnClearText.ForeColor = System.Drawing.Color.Black
        Me.btnClearText.Image = CType(resources.GetObject("btnClearText.Image"), System.Drawing.Image)
        Me.btnClearText.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClearText.Location = New System.Drawing.Point(431, 71)
        Me.btnClearText.Name = "btnClearText"
        Me.btnClearText.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.btnClearText.Size = New System.Drawing.Size(159, 30)
        Me.btnClearText.TabIndex = 8
        Me.btnClearText.Text = "Reset"
        Me.btnClearText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClearText.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClearText.UseVisualStyleBackColor = True
        '
        'btnSaveCat
        '
        Me.btnSaveCat.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSaveCat.Enabled = False
        Me.btnSaveCat.ForeColor = System.Drawing.Color.Black
        Me.btnSaveCat.Image = Global.BeecomePOS.My.Resources.Resources.save_16
        Me.btnSaveCat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSaveCat.Location = New System.Drawing.Point(431, 29)
        Me.btnSaveCat.Name = "btnSaveCat"
        Me.btnSaveCat.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.btnSaveCat.Size = New System.Drawing.Size(159, 36)
        Me.btnSaveCat.TabIndex = 7
        Me.btnSaveCat.Text = "Save"
        Me.btnSaveCat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSaveCat.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(26, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 18)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Number Group"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(26, 61)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(126, 18)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Name Group [TH]"
        '
        'txtDesCatTH
        '
        Me.txtDesCatTH.Enabled = False
        Me.txtDesCatTH.Location = New System.Drawing.Point(190, 61)
        Me.txtDesCatTH.MaxLength = 100
        Me.txtDesCatTH.Name = "txtDesCatTH"
        Me.txtDesCatTH.Size = New System.Drawing.Size(189, 24)
        Me.txtDesCatTH.TabIndex = 1
        '
        'txtIDCat
        '
        Me.txtIDCat.Enabled = False
        Me.txtIDCat.Location = New System.Drawing.Point(190, 29)
        Me.txtIDCat.Name = "txtIDCat"
        Me.txtIDCat.Size = New System.Drawing.Size(189, 24)
        Me.txtIDCat.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(108, 26)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Image = Global.BeecomePOS.My.Resources.Resources.delete_161
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'Admin_addCatPrd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(851, 518)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TreeView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Admin_addCatPrd"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "จัดการเพิ่มหมวดหมู่สินค้า"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnAddCat As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEditCat As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDelCat As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDesCatEN As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnOnTBOff As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnSalesOff As System.Windows.Forms.Button
    Friend WithEvents btnSalesOpen As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnClearText As System.Windows.Forms.Button
    Friend WithEvents btnSaveCat As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtDesCatTH As System.Windows.Forms.TextBox
    Friend WithEvents txtIDCat As System.Windows.Forms.TextBox
    Friend WithEvents btnOnTBOpen As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
