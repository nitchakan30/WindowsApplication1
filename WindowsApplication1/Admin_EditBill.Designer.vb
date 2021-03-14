<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_EditBill
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Admin_EditBill))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.id1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.no = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.num = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.price_exc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.discount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.service = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.net_amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.type_pay = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.machin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dmy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rop = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.print1 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.id_ord = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.no_1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.id_prd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.id_prd_con = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.price_ex_1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vat1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vat_st = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.price_unit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.size1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.disc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.disc_t = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.disc_s = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.update_by = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btn_cancel = New System.Windows.Forms.Button()
        Me.txt_sum_price = New System.Windows.Forms.TextBox()
        Me.enter_void = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btn_save = New System.Windows.Forms.Button()
        Me.txt_sum_discount = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_sum_service_chg = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_sum_vat = New System.Windows.Forms.TextBox()
        Me.txt_sum_total = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txt_service_chg = New System.Windows.Forms.TextBox()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.SplitContainer1.Panel1.Controls.Add(Me.DataGridView1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel3)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel2)
        Me.SplitContainer1.Size = New System.Drawing.Size(882, 463)
        Me.SplitContainer1.SplitterDistance = 373
        Me.SplitContainer1.TabIndex = 1
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id1, Me.no, Me.num, Me.qty, Me.price_exc, Me.vat, Me.price, Me.discount, Me.service, Me.net_amount, Me.type_pay, Me.machin, Me.dmy, Me.rop})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.DataGridView1.Location = New System.Drawing.Point(0, 46)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(373, 417)
        Me.DataGridView1.TabIndex = 42
        '
        'id1
        '
        Me.id1.HeaderText = "id_inv"
        Me.id1.MinimumWidth = 2
        Me.id1.Name = "id1"
        Me.id1.ReadOnly = True
        Me.id1.Visible = False
        Me.id1.Width = 2
        '
        'no
        '
        Me.no.HeaderText = "ลำดับ"
        Me.no.Name = "no"
        Me.no.ReadOnly = True
        Me.no.Width = 40
        '
        'num
        '
        Me.num.HeaderText = "เลขที่"
        Me.num.Name = "num"
        Me.num.ReadOnly = True
        '
        'qty
        '
        Me.qty.HeaderText = "จำนวน"
        Me.qty.Name = "qty"
        Me.qty.ReadOnly = True
        Me.qty.Width = 50
        '
        'price_exc
        '
        Me.price_exc.HeaderText = "ราคาถอด vat"
        Me.price_exc.Name = "price_exc"
        Me.price_exc.ReadOnly = True
        Me.price_exc.Visible = False
        '
        'vat
        '
        Me.vat.HeaderText = "รวม vat"
        Me.vat.Name = "vat"
        Me.vat.ReadOnly = True
        Me.vat.Visible = False
        Me.vat.Width = 70
        '
        'price
        '
        Me.price.HeaderText = "ราคารวม"
        Me.price.Name = "price"
        Me.price.ReadOnly = True
        Me.price.Visible = False
        Me.price.Width = 80
        '
        'discount
        '
        Me.discount.HeaderText = "ส่วนลด"
        Me.discount.Name = "discount"
        Me.discount.ReadOnly = True
        Me.discount.Width = 70
        '
        'service
        '
        Me.service.HeaderText = "Service charge"
        Me.service.Name = "service"
        Me.service.ReadOnly = True
        Me.service.Width = 102
        '
        'net_amount
        '
        Me.net_amount.HeaderText = "ราคารวมทั้งสิ้น"
        Me.net_amount.Name = "net_amount"
        Me.net_amount.ReadOnly = True
        '
        'type_pay
        '
        Me.type_pay.HeaderText = "ประเภทจ่าย"
        Me.type_pay.Name = "type_pay"
        Me.type_pay.ReadOnly = True
        Me.type_pay.Width = 150
        '
        'machin
        '
        Me.machin.HeaderText = "หมายเลขเครื่อง"
        Me.machin.Name = "machin"
        Me.machin.ReadOnly = True
        '
        'dmy
        '
        Me.dmy.HeaderText = "วัน/เดือน/ปี"
        Me.dmy.Name = "dmy"
        Me.dmy.ReadOnly = True
        '
        'rop
        '
        Me.rop.HeaderText = "รอบบิล"
        Me.rop.Name = "rop"
        Me.rop.ReadOnly = True
        Me.rop.Width = 140
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.DateTimePicker1)
        Me.Panel3.Controls.Add(Me.Button3)
        Me.Panel3.Controls.Add(Me.print1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(373, 46)
        Me.Panel3.TabIndex = 41
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DateTimePicker1.Location = New System.Drawing.Point(168, 13)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker1.TabIndex = 43
        '
        'Button3
        '
        Me.Button3.Image = Global.BeecomePOS.My.Resources.Resources.arrow_circle
        Me.Button3.Location = New System.Drawing.Point(84, 5)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(52, 35)
        Me.Button3.TabIndex = 41
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button3.UseVisualStyleBackColor = True
        '
        'print1
        '
        Me.print1.Image = Global.BeecomePOS.My.Resources.Resources.printer
        Me.print1.Location = New System.Drawing.Point(3, 5)
        Me.print1.Name = "print1"
        Me.print1.Size = New System.Drawing.Size(78, 35)
        Me.print1.TabIndex = 36
        Me.print1.Text = "Print"
        Me.print1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.print1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.print1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.DataGridView2)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(505, 309)
        Me.Panel1.TabIndex = 53
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id_ord, Me.no_1, Me.id_prd, Me.id_prd_con, Me.DataGridViewTextBoxColumn1, Me.price_ex_1, Me.vat1, Me.vat_st, Me.DataGridViewTextBoxColumn2, Me.price_unit, Me.size1, Me.disc, Me.disc_t, Me.disc_s, Me.DataGridViewTextBoxColumn3, Me.status, Me.update_by})
        Me.DataGridView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView2.Location = New System.Drawing.Point(0, 30)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView2.Size = New System.Drawing.Size(505, 279)
        Me.DataGridView2.TabIndex = 42
        '
        'id_ord
        '
        Me.id_ord.HeaderText = "id_ord"
        Me.id_ord.MinimumWidth = 2
        Me.id_ord.Name = "id_ord"
        Me.id_ord.ReadOnly = True
        Me.id_ord.Visible = False
        Me.id_ord.Width = 2
        '
        'no_1
        '
        Me.no_1.HeaderText = "ลำดับ"
        Me.no_1.Name = "no_1"
        Me.no_1.ReadOnly = True
        Me.no_1.Width = 40
        '
        'id_prd
        '
        Me.id_prd.HeaderText = "id_prd"
        Me.id_prd.MinimumWidth = 2
        Me.id_prd.Name = "id_prd"
        Me.id_prd.ReadOnly = True
        Me.id_prd.Visible = False
        Me.id_prd.Width = 2
        '
        'id_prd_con
        '
        Me.id_prd_con.HeaderText = "id_prd_con"
        Me.id_prd_con.MinimumWidth = 2
        Me.id_prd_con.Name = "id_prd_con"
        Me.id_prd_con.ReadOnly = True
        Me.id_prd_con.Visible = False
        Me.id_prd_con.Width = 2
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "ชื่อสินค้า"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 110
        '
        'price_ex_1
        '
        Me.price_ex_1.HeaderText = "ราคาถอดVat"
        Me.price_ex_1.Name = "price_ex_1"
        Me.price_ex_1.ReadOnly = True
        Me.price_ex_1.Visible = False
        '
        'vat1
        '
        Me.vat1.HeaderText = "vat"
        Me.vat1.Name = "vat1"
        Me.vat1.ReadOnly = True
        Me.vat1.Visible = False
        Me.vat1.Width = 70
        '
        'vat_st
        '
        Me.vat_st.HeaderText = "vat type"
        Me.vat_st.Name = "vat_st"
        Me.vat_st.ReadOnly = True
        Me.vat_st.Visible = False
        Me.vat_st.Width = 50
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "จำนวน"
        Me.DataGridViewTextBoxColumn2.MaxInputLength = 20
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 60
        '
        'price_unit
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.price_unit.DefaultCellStyle = DataGridViewCellStyle1
        Me.price_unit.HeaderText = "ราคา"
        Me.price_unit.Name = "price_unit"
        Me.price_unit.ReadOnly = True
        Me.price_unit.Width = 80
        '
        'size1
        '
        Me.size1.HeaderText = "ขนาด"
        Me.size1.Name = "size1"
        Me.size1.ReadOnly = True
        Me.size1.Width = 60
        '
        'disc
        '
        Me.disc.HeaderText = "ส่วนลด"
        Me.disc.Name = "disc"
        Me.disc.ReadOnly = True
        Me.disc.Width = 60
        '
        'disc_t
        '
        Me.disc_t.HeaderText = "ประเภทส่วนลด"
        Me.disc_t.Name = "disc_t"
        Me.disc_t.ReadOnly = True
        Me.disc_t.Width = 60
        '
        'disc_s
        '
        Me.disc_s.HeaderText = "รวมส่วนลด"
        Me.disc_s.Name = "disc_s"
        Me.disc_s.ReadOnly = True
        Me.disc_s.Width = 70
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "ราคารวม"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'status
        '
        Me.status.HeaderText = "ประเภทซื้อ"
        Me.status.Name = "status"
        Me.status.ReadOnly = True
        Me.status.Visible = False
        '
        'update_by
        '
        Me.update_by.HeaderText = "อัพเดตโดย"
        Me.update_by.Name = "update_by"
        Me.update_by.ReadOnly = True
        Me.update_by.Visible = False
        Me.update_by.Width = 110
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel4.Controls.Add(Me.TextBox1)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(505, 30)
        Me.Panel4.TabIndex = 41
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(254, 4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 3
        Me.TextBox1.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Yellow
        Me.Label3.Location = New System.Drawing.Point(143, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 18)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "No."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Yellow
        Me.Label2.Location = New System.Drawing.Point(123, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(14, 18)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "-"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.Location = New System.Drawing.Point(3, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "รายการสินค้า"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btn_cancel)
        Me.Panel2.Controls.Add(Me.txt_sum_price)
        Me.Panel2.Controls.Add(Me.enter_void)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.btn_save)
        Me.Panel2.Controls.Add(Me.txt_sum_discount)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.txt_sum_service_chg)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.txt_sum_vat)
        Me.Panel2.Controls.Add(Me.txt_sum_total)
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.txt_service_chg)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 309)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(505, 154)
        Me.Panel2.TabIndex = 51
        '
        'btn_cancel
        '
        Me.btn_cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cancel.Location = New System.Drawing.Point(7, 18)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(39, 35)
        Me.btn_cancel.TabIndex = 42
        Me.btn_cancel.Text = "Cancel"
        Me.btn_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_cancel.UseVisualStyleBackColor = True
        Me.btn_cancel.Visible = False
        '
        'txt_sum_price
        '
        Me.txt_sum_price.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_sum_price.BackColor = System.Drawing.Color.Silver
        Me.txt_sum_price.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_sum_price.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_sum_price.ForeColor = System.Drawing.Color.Black
        Me.txt_sum_price.Location = New System.Drawing.Point(415, 6)
        Me.txt_sum_price.MaxLength = 4
        Me.txt_sum_price.Name = "txt_sum_price"
        Me.txt_sum_price.ReadOnly = True
        Me.txt_sum_price.Size = New System.Drawing.Size(83, 24)
        Me.txt_sum_price.TabIndex = 64
        Me.txt_sum_price.Text = "0.0"
        Me.txt_sum_price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'enter_void
        '
        Me.enter_void.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.enter_void.Image = Global.BeecomePOS.My.Resources.Resources.delete_161
        Me.enter_void.Location = New System.Drawing.Point(7, 59)
        Me.enter_void.Name = "enter_void"
        Me.enter_void.Size = New System.Drawing.Size(30, 35)
        Me.enter_void.TabIndex = 3
        Me.enter_void.Text = "Void"
        Me.enter_void.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.enter_void.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.enter_void.UseVisualStyleBackColor = True
        Me.enter_void.Visible = False
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label9.Location = New System.Drawing.Point(265, 10)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(134, 16)
        Me.Label9.TabIndex = 63
        Me.Label9.Text = "ราคาทั้งหมดไม่รวมภาษี"
        '
        'btn_save
        '
        Me.btn_save.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_save.Enabled = False
        Me.btn_save.Image = Global.BeecomePOS.My.Resources.Resources.save_16
        Me.btn_save.Location = New System.Drawing.Point(52, 19)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(39, 35)
        Me.btn_save.TabIndex = 38
        Me.btn_save.Text = "Save"
        Me.btn_save.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_save.UseVisualStyleBackColor = True
        Me.btn_save.Visible = False
        '
        'txt_sum_discount
        '
        Me.txt_sum_discount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_sum_discount.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txt_sum_discount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_sum_discount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_sum_discount.ForeColor = System.Drawing.Color.Black
        Me.txt_sum_discount.Location = New System.Drawing.Point(415, 84)
        Me.txt_sum_discount.MaxLength = 4
        Me.txt_sum_discount.Name = "txt_sum_discount"
        Me.txt_sum_discount.ReadOnly = True
        Me.txt_sum_discount.Size = New System.Drawing.Size(82, 21)
        Me.txt_sum_discount.TabIndex = 62
        Me.txt_sum_discount.Text = "0.0"
        Me.txt_sum_discount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(302, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 13)
        Me.Label6.TabIndex = 53
        Me.Label6.Text = "Vat (ภาษีมูลค่าเพิ่ม)"
        '
        'txt_sum_service_chg
        '
        Me.txt_sum_service_chg.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_sum_service_chg.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txt_sum_service_chg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_sum_service_chg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_sum_service_chg.ForeColor = System.Drawing.Color.Black
        Me.txt_sum_service_chg.Location = New System.Drawing.Point(415, 59)
        Me.txt_sum_service_chg.MaxLength = 4
        Me.txt_sum_service_chg.Name = "txt_sum_service_chg"
        Me.txt_sum_service_chg.ReadOnly = True
        Me.txt_sum_service_chg.Size = New System.Drawing.Size(83, 21)
        Me.txt_sum_service_chg.TabIndex = 61
        Me.txt_sum_service_chg.Text = "0.0"
        Me.txt_sum_service_chg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(237, 68)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 13)
        Me.Label7.TabIndex = 54
        Me.Label7.Text = "Service charge"
        '
        'txt_sum_vat
        '
        Me.txt_sum_vat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_sum_vat.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txt_sum_vat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_sum_vat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_sum_vat.ForeColor = System.Drawing.Color.Black
        Me.txt_sum_vat.Location = New System.Drawing.Point(414, 33)
        Me.txt_sum_vat.MaxLength = 4
        Me.txt_sum_vat.Name = "txt_sum_vat"
        Me.txt_sum_vat.ReadOnly = True
        Me.txt_sum_vat.Size = New System.Drawing.Size(83, 21)
        Me.txt_sum_vat.TabIndex = 60
        Me.txt_sum_vat.Text = "0.0"
        Me.txt_sum_vat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_sum_total
        '
        Me.txt_sum_total.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_sum_total.BackColor = System.Drawing.Color.Black
        Me.txt_sum_total.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_sum_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_sum_total.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txt_sum_total.Location = New System.Drawing.Point(305, 112)
        Me.txt_sum_total.MaxLength = 4
        Me.txt_sum_total.Name = "txt_sum_total"
        Me.txt_sum_total.ReadOnly = True
        Me.txt_sum_total.Size = New System.Drawing.Size(193, 35)
        Me.txt_sum_total.TabIndex = 59
        Me.txt_sum_total.Text = "0.0"
        Me.txt_sum_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(387, 65)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(15, 13)
        Me.Label15.TabIndex = 58
        Me.Label15.Text = "%"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(359, 88)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 13)
        Me.Label8.TabIndex = 55
        Me.Label8.Text = "ส่วนลด"
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label12.Location = New System.Drawing.Point(106, 119)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(191, 25)
        Me.Label12.TabIndex = 57
        Me.Label12.Text = "ยอดรวมชำระทั้งหมด"
        '
        'txt_service_chg
        '
        Me.txt_service_chg.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_service_chg.BackColor = System.Drawing.Color.Silver
        Me.txt_service_chg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_service_chg.Location = New System.Drawing.Point(322, 61)
        Me.txt_service_chg.MaxLength = 2
        Me.txt_service_chg.Name = "txt_service_chg"
        Me.txt_service_chg.ReadOnly = True
        Me.txt_service_chg.Size = New System.Drawing.Size(59, 20)
        Me.txt_service_chg.TabIndex = 56
        Me.txt_service_chg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Admin_EditBill
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(882, 463)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Admin_EditBill"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Management Bill"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents print1 As System.Windows.Forms.Button
    Friend WithEvents enter_void As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txt_sum_price As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_sum_discount As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_sum_service_chg As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_sum_vat As System.Windows.Forms.TextBox
    Friend WithEvents txt_sum_total As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txt_service_chg As System.Windows.Forms.TextBox
    Friend WithEvents btn_save As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents btn_cancel As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents id1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents num As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents price_exc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents price As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents discount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents service As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents net_amount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents type_pay As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents machin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dmy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rop As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents id_ord As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents no_1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents id_prd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents id_prd_con As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents price_ex_1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vat1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vat_st As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents price_unit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents size1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents disc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents disc_t As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents disc_s As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents update_by As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
