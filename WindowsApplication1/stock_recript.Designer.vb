<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class stock_recript
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(stock_recript))
        Me.textbox_barcoce = New System.Windows.Forms.TextBox()
        Me.Label_barcode = New System.Windows.Forms.Label()
        Me.radio_alone = New System.Windows.Forms.RadioButton()
        Me.radio_group = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.textbox_number_recript = New System.Windows.Forms.TextBox()
        Me.btn_cancel = New System.Windows.Forms.Button()
        Me.btn_save = New System.Windows.Forms.Button()
        Me.Label_qty = New System.Windows.Forms.Label()
        Me.textbox_qt = New System.Windows.Forms.TextBox()
        Me.btn_clear = New System.Windows.Forms.Button()
        Me.btn_add = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.id_prd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.id_prd_con = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.id_unit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.num = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.barcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.name_th = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.name_en = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.unit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'textbox_barcoce
        '
        Me.textbox_barcoce.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.textbox_barcoce.Location = New System.Drawing.Point(155, 56)
        Me.textbox_barcoce.Name = "textbox_barcoce"
        Me.textbox_barcoce.Size = New System.Drawing.Size(223, 29)
        Me.textbox_barcoce.TabIndex = 1
        '
        'Label_barcode
        '
        Me.Label_barcode.AutoSize = True
        Me.Label_barcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label_barcode.Location = New System.Drawing.Point(21, 58)
        Me.Label_barcode.Name = "Label_barcode"
        Me.Label_barcode.Size = New System.Drawing.Size(128, 16)
        Me.Label_barcode.TabIndex = 2
        Me.Label_barcode.Text = "Barcode Or Number"
        '
        'radio_alone
        '
        Me.radio_alone.AutoSize = True
        Me.radio_alone.Checked = True
        Me.radio_alone.Location = New System.Drawing.Point(24, 25)
        Me.radio_alone.Name = "radio_alone"
        Me.radio_alone.Size = New System.Drawing.Size(81, 20)
        Me.radio_alone.TabIndex = 3
        Me.radio_alone.TabStop = True
        Me.radio_alone.Text = "รับแบบเดี่ยว"
        Me.radio_alone.UseVisualStyleBackColor = True
        '
        'radio_group
        '
        Me.radio_group.AutoSize = True
        Me.radio_group.Location = New System.Drawing.Point(134, 25)
        Me.radio_group.Name = "radio_group"
        Me.radio_group.Size = New System.Drawing.Size(78, 20)
        Me.radio_group.TabIndex = 4
        Me.radio_group.Text = "รับแบบกลุ่ม"
        Me.radio_group.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.textbox_number_recript)
        Me.GroupBox1.Controls.Add(Me.btn_cancel)
        Me.GroupBox1.Controls.Add(Me.btn_save)
        Me.GroupBox1.Controls.Add(Me.Label_qty)
        Me.GroupBox1.Controls.Add(Me.textbox_qt)
        Me.GroupBox1.Controls.Add(Me.btn_clear)
        Me.GroupBox1.Controls.Add(Me.btn_add)
        Me.GroupBox1.Controls.Add(Me.Label_barcode)
        Me.GroupBox1.Controls.Add(Me.radio_group)
        Me.GroupBox1.Controls.Add(Me.textbox_barcoce)
        Me.GroupBox1.Controls.Add(Me.radio_alone)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(855, 181)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "รับสินค้าเข้าสต๊อก"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 16)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "เลขที่ใบรับของ"
        Me.Label1.Visible = False
        '
        'textbox_number_recript
        '
        Me.textbox_number_recript.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.textbox_number_recript.Location = New System.Drawing.Point(155, 91)
        Me.textbox_number_recript.Name = "textbox_number_recript"
        Me.textbox_number_recript.ReadOnly = True
        Me.textbox_number_recript.Size = New System.Drawing.Size(223, 29)
        Me.textbox_number_recript.TabIndex = 10
        Me.textbox_number_recript.Visible = False
        '
        'btn_cancel
        '
        Me.btn_cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cancel.Image = Global.BeecomePOS.My.Resources.Resources.cross
        Me.btn_cancel.Location = New System.Drawing.Point(661, 91)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(170, 60)
        Me.btn_cancel.TabIndex = 9
        Me.btn_cancel.Text = "Cancel"
        Me.btn_cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_cancel.UseVisualStyleBackColor = True
        '
        'btn_save
        '
        Me.btn_save.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_save.Image = Global.BeecomePOS.My.Resources.Resources.save_32
        Me.btn_save.Location = New System.Drawing.Point(661, 25)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(170, 60)
        Me.btn_save.TabIndex = 8
        Me.btn_save.Text = "Save"
        Me.btn_save.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'Label_qty
        '
        Me.Label_qty.AutoSize = True
        Me.Label_qty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label_qty.Location = New System.Drawing.Point(403, 57)
        Me.Label_qty.Name = "Label_qty"
        Me.Label_qty.Size = New System.Drawing.Size(39, 16)
        Me.Label_qty.TabIndex = 7
        Me.Label_qty.Text = "จำนวน"
        '
        'textbox_qt
        '
        Me.textbox_qt.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.textbox_qt.Location = New System.Drawing.Point(469, 52)
        Me.textbox_qt.MaxLength = 5
        Me.textbox_qt.Name = "textbox_qt"
        Me.textbox_qt.Size = New System.Drawing.Size(150, 29)
        Me.textbox_qt.TabIndex = 2
        Me.textbox_qt.Text = "0"
        Me.textbox_qt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btn_clear
        '
        Me.btn_clear.Image = Global.BeecomePOS.My.Resources.Resources.Trash
        Me.btn_clear.Location = New System.Drawing.Point(259, 126)
        Me.btn_clear.Name = "btn_clear"
        Me.btn_clear.Size = New System.Drawing.Size(102, 48)
        Me.btn_clear.TabIndex = 4
        Me.btn_clear.Text = "Clear"
        Me.btn_clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_clear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_clear.UseVisualStyleBackColor = True
        '
        'btn_add
        '
        Me.btn_add.Image = Global.BeecomePOS.My.Resources.Resources.plus
        Me.btn_add.Location = New System.Drawing.Point(155, 126)
        Me.btn_add.Name = "btn_add"
        Me.btn_add.Size = New System.Drawing.Size(98, 48)
        Me.btn_add.TabIndex = 3
        Me.btn_add.Text = "Enter"
        Me.btn_add.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_add.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id_prd, Me.id_prd_con, Me.id_unit, Me.num, Me.barcode, Me.name_th, Me.name_en, Me.unit, Me.qty})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 199)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(855, 257)
        Me.DataGridView1.TabIndex = 6
        '
        'id_prd
        '
        Me.id_prd.FillWeight = 3.0!
        Me.id_prd.HeaderText = "id_prd"
        Me.id_prd.MinimumWidth = 2
        Me.id_prd.Name = "id_prd"
        Me.id_prd.Visible = False
        Me.id_prd.Width = 2
        '
        'id_prd_con
        '
        Me.id_prd_con.FillWeight = 3.0!
        Me.id_prd_con.HeaderText = "id_prd_con"
        Me.id_prd_con.MinimumWidth = 2
        Me.id_prd_con.Name = "id_prd_con"
        Me.id_prd_con.Visible = False
        Me.id_prd_con.Width = 2
        '
        'id_unit
        '
        Me.id_unit.FillWeight = 3.0!
        Me.id_unit.HeaderText = "id_unit"
        Me.id_unit.MinimumWidth = 2
        Me.id_unit.Name = "id_unit"
        Me.id_unit.Visible = False
        Me.id_unit.Width = 2
        '
        'num
        '
        Me.num.HeaderText = "ลำดับ"
        Me.num.Name = "num"
        Me.num.ReadOnly = True
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
        '
        'stock_recript
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(879, 480)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "stock_recript"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "stock_recript"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_add As System.Windows.Forms.Button
    Friend WithEvents textbox_barcoce As System.Windows.Forms.TextBox
    Friend WithEvents Label_barcode As System.Windows.Forms.Label
    Friend WithEvents radio_alone As System.Windows.Forms.RadioButton
    Friend WithEvents radio_group As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_clear As System.Windows.Forms.Button
    Friend WithEvents Label_qty As System.Windows.Forms.Label
    Friend WithEvents textbox_qt As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btn_save As System.Windows.Forms.Button
    Friend WithEvents btn_cancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents textbox_number_recript As System.Windows.Forms.TextBox
    Friend WithEvents id_prd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents id_prd_con As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents id_unit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents num As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents barcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents name_th As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents name_en As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents unit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qty As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
