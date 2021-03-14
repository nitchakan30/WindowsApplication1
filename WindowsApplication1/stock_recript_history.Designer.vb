<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class stock_recript_history
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(stock_recript_history))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_search = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.btn_edit = New System.Windows.Forms.Button()
        Me.btn_save = New System.Windows.Forms.Button()
        Me.btn_cancel = New System.Windows.Forms.Button()
        Me.Panel_Edit = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.id_r = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.id_prd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.id_prd_con = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.id_unit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.num = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.barcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.name_th = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.name_en = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.unit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.date1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.create_by = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.update_by = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.num_recript = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel_Edit.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ToolStrip1)
        Me.Panel2.Controls.Add(Me.btn_search)
        Me.Panel2.Controls.Add(Me.DateTimePicker1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(809, 46)
        Me.Panel2.TabIndex = 9
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2, Me.ToolStripSeparator1, Me.ToolStripButton1, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 3)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(232, 39)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Image = Global.BeecomePOS.My.Resources.Resources.print32
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(79, 36)
        Me.ToolStripButton2.Text = "Print"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = Global.BeecomePOS.My.Resources.Resources.pre_print
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(138, 36)
        Me.ToolStripButton1.Text = "Preview Print"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'btn_search
        '
        Me.btn_search.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_search.Location = New System.Drawing.Point(734, 10)
        Me.btn_search.Name = "btn_search"
        Me.btn_search.Size = New System.Drawing.Size(66, 23)
        Me.btn_search.TabIndex = 2
        Me.btn_search.Text = "Search"
        Me.btn_search.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DateTimePicker1.Location = New System.Drawing.Point(569, 12)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(156, 20)
        Me.DateTimePicker1.TabIndex = 1
        '
        'btn_edit
        '
        Me.btn_edit.Location = New System.Drawing.Point(3, 3)
        Me.btn_edit.Name = "btn_edit"
        Me.btn_edit.Size = New System.Drawing.Size(75, 23)
        Me.btn_edit.TabIndex = 11
        Me.btn_edit.Text = "Edit"
        Me.btn_edit.UseVisualStyleBackColor = True
        '
        'btn_save
        '
        Me.btn_save.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_save.Enabled = False
        Me.btn_save.Location = New System.Drawing.Point(643, 3)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(75, 23)
        Me.btn_save.TabIndex = 13
        Me.btn_save.Text = "Save"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'btn_cancel
        '
        Me.btn_cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cancel.Enabled = False
        Me.btn_cancel.Location = New System.Drawing.Point(724, 3)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_cancel.TabIndex = 14
        Me.btn_cancel.Text = "Cancel"
        Me.btn_cancel.UseVisualStyleBackColor = True
        '
        'Panel_Edit
        '
        Me.Panel_Edit.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel_Edit.Controls.Add(Me.btn_cancel)
        Me.Panel_Edit.Controls.Add(Me.btn_edit)
        Me.Panel_Edit.Controls.Add(Me.btn_save)
        Me.Panel_Edit.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel_Edit.Location = New System.Drawing.Point(0, 46)
        Me.Panel_Edit.Name = "Panel_Edit"
        Me.Panel_Edit.Size = New System.Drawing.Size(809, 30)
        Me.Panel_Edit.TabIndex = 15
        Me.Panel_Edit.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.DataGridView1)
        Me.Panel1.Controls.Add(Me.DataGridView2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 76)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(809, 403)
        Me.Panel1.TabIndex = 16
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id_r, Me.id_prd, Me.id_prd_con, Me.id_unit, Me.num, Me.barcode, Me.name_th, Me.name_en, Me.unit, Me.qty, Me.date1, Me.create_by, Me.update_by})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(244, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(565, 403)
        Me.DataGridView1.TabIndex = 9
        '
        'id_r
        '
        Me.id_r.FillWeight = 10.0!
        Me.id_r.HeaderText = "id_r"
        Me.id_r.Name = "id_r"
        Me.id_r.ReadOnly = True
        Me.id_r.Visible = False
        '
        'id_prd
        '
        Me.id_prd.FillWeight = 5.0!
        Me.id_prd.HeaderText = "id_prd"
        Me.id_prd.MinimumWidth = 2
        Me.id_prd.Name = "id_prd"
        Me.id_prd.ReadOnly = True
        Me.id_prd.Visible = False
        Me.id_prd.Width = 2
        '
        'id_prd_con
        '
        Me.id_prd_con.FillWeight = 5.0!
        Me.id_prd_con.HeaderText = "id_prd_con"
        Me.id_prd_con.MinimumWidth = 2
        Me.id_prd_con.Name = "id_prd_con"
        Me.id_prd_con.ReadOnly = True
        Me.id_prd_con.Visible = False
        Me.id_prd_con.Width = 2
        '
        'id_unit
        '
        Me.id_unit.FillWeight = 5.0!
        Me.id_unit.HeaderText = "id_unit"
        Me.id_unit.MinimumWidth = 2
        Me.id_unit.Name = "id_unit"
        Me.id_unit.ReadOnly = True
        Me.id_unit.Visible = False
        Me.id_unit.Width = 2
        '
        'num
        '
        Me.num.HeaderText = "ลำดับ"
        Me.num.Name = "num"
        Me.num.ReadOnly = True
        Me.num.Width = 50
        '
        'barcode
        '
        Me.barcode.HeaderText = "Barcode Or Number"
        Me.barcode.Name = "barcode"
        Me.barcode.ReadOnly = True
        Me.barcode.Width = 150
        '
        'name_th
        '
        Me.name_th.HeaderText = "ชื่อสินค้า ไทย"
        Me.name_th.Name = "name_th"
        Me.name_th.ReadOnly = True
        Me.name_th.Width = 130
        '
        'name_en
        '
        Me.name_en.HeaderText = "ชื่อสินค้า อังกฤษ"
        Me.name_en.Name = "name_en"
        Me.name_en.ReadOnly = True
        Me.name_en.Width = 130
        '
        'unit
        '
        Me.unit.HeaderText = "หน่วยสินค้า"
        Me.unit.Name = "unit"
        Me.unit.ReadOnly = True
        Me.unit.Width = 110
        '
        'qty
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Red
        Me.qty.DefaultCellStyle = DataGridViewCellStyle1
        Me.qty.HeaderText = "จำนวน"
        Me.qty.MaxInputLength = 10
        Me.qty.Name = "qty"
        Me.qty.ReadOnly = True
        '
        'date1
        '
        Me.date1.HeaderText = "ว/ด/ป"
        Me.date1.Name = "date1"
        Me.date1.ReadOnly = True
        '
        'create_by
        '
        Me.create_by.HeaderText = "สร้างโดย"
        Me.create_by.Name = "create_by"
        Me.create_by.ReadOnly = True
        '
        'update_by
        '
        Me.update_by.HeaderText = "อัพเดตโดย"
        Me.update_by.Name = "update_by"
        Me.update_by.ReadOnly = True
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.num_recript, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6})
        Me.DataGridView2.Dock = System.Windows.Forms.DockStyle.Left
        Me.DataGridView2.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView2.Size = New System.Drawing.Size(244, 403)
        Me.DataGridView2.TabIndex = 8
        '
        'num_recript
        '
        Me.num_recript.HeaderText = "num_recript"
        Me.num_recript.Name = "num_recript"
        Me.num_recript.ReadOnly = True
        Me.num_recript.Visible = False
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "ลำดับ"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 50
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "เลขที่ใบรับของ"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 150
        '
        'stock_recript_history
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(809, 479)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel_Edit)
        Me.Controls.Add(Me.Panel2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "stock_recript_history"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock recript history"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel_Edit.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_search As System.Windows.Forms.Button
    Friend WithEvents btn_edit As System.Windows.Forms.Button
    Friend WithEvents btn_save As System.Windows.Forms.Button
    Friend WithEvents btn_cancel As System.Windows.Forms.Button
    Friend WithEvents Panel_Edit As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents num_recript As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents id_r As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents id_prd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents id_prd_con As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents id_unit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents num As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents barcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents name_th As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents name_en As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents unit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents date1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents create_by As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents update_by As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
