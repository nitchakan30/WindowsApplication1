<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_voidbill
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.btn_reload = New System.Windows.Forms.Button()
        Me.print1 = New System.Windows.Forms.Button()
        Me.dw = New System.Windows.Forms.Button()
        Me.up = New System.Windows.Forms.Button()
        Me.enter_void = New System.Windows.Forms.Button()
        Me.ListView_Inv = New System.Windows.Forms.ListView()
        Me.id_inv = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.num_run = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.number_inv = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.qty_inv = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.price_inv = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.date_inv = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.pay_type = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.close_rop = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.name_com = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.disc_inv = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.discT_inv = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.discS_inv = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ListView_Inv1 = New System.Windows.Forms.ListView()
        Me.st = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.num_run1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.id_ord = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.id_prd = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.id_con_prd = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.prd_name = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.size1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.vat_s = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.qty1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.price1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.disc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.discT = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.discS = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.total = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.remark = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btn_tickall = New System.Windows.Forms.Button()
        Me.btn_close = New System.Windows.Forms.Button()
        Me.dw1 = New System.Windows.Forms.Button()
        Me.up1 = New System.Windows.Forms.Button()
        Me.btn_tick = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txt_sum_price = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
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
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.SplitContainer1.Panel1.Controls.Add(Me.btn_reload)
        Me.SplitContainer1.Panel1.Controls.Add(Me.print1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dw)
        Me.SplitContainer1.Panel1.Controls.Add(Me.up)
        Me.SplitContainer1.Panel1.Controls.Add(Me.enter_void)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ListView_Inv)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel3)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel2)
        Me.SplitContainer1.Size = New System.Drawing.Size(836, 528)
        Me.SplitContainer1.SplitterDistance = 424
        Me.SplitContainer1.TabIndex = 0
        '
        'btn_reload
        '
        Me.btn_reload.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_reload.Image = Global.BeecomePOS.My.Resources.Resources.arrow_circle
        Me.btn_reload.Location = New System.Drawing.Point(268, 5)
        Me.btn_reload.Name = "btn_reload"
        Me.btn_reload.Size = New System.Drawing.Size(50, 47)
        Me.btn_reload.TabIndex = 38
        Me.btn_reload.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_reload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_reload.UseVisualStyleBackColor = True
        '
        'print1
        '
        Me.print1.Image = Global.BeecomePOS.My.Resources.Resources.print_32
        Me.print1.Location = New System.Drawing.Point(6, 4)
        Me.print1.Name = "print1"
        Me.print1.Size = New System.Drawing.Size(123, 48)
        Me.print1.TabIndex = 36
        Me.print1.Text = "Print Bill Again"
        Me.print1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.print1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.print1.UseVisualStyleBackColor = True
        '
        'dw
        '
        Me.dw.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dw.Image = Global.BeecomePOS.My.Resources.Resources.arrow_270
        Me.dw.Location = New System.Drawing.Point(321, 5)
        Me.dw.Name = "dw"
        Me.dw.Size = New System.Drawing.Size(47, 48)
        Me.dw.TabIndex = 35
        Me.dw.UseVisualStyleBackColor = True
        '
        'up
        '
        Me.up.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.up.Image = Global.BeecomePOS.My.Resources.Resources.arrow_0901
        Me.up.Location = New System.Drawing.Point(371, 5)
        Me.up.Name = "up"
        Me.up.Size = New System.Drawing.Size(50, 48)
        Me.up.TabIndex = 34
        Me.up.UseVisualStyleBackColor = True
        '
        'enter_void
        '
        Me.enter_void.Image = Global.BeecomePOS.My.Resources.Resources.Forbidden1
        Me.enter_void.Location = New System.Drawing.Point(135, 5)
        Me.enter_void.Name = "enter_void"
        Me.enter_void.Size = New System.Drawing.Size(106, 48)
        Me.enter_void.TabIndex = 3
        Me.enter_void.Text = "Enter Void"
        Me.enter_void.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.enter_void.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.enter_void.UseVisualStyleBackColor = True
        '
        'ListView_Inv
        '
        Me.ListView_Inv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView_Inv.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.id_inv, Me.num_run, Me.number_inv, Me.qty_inv, Me.price_inv, Me.date_inv, Me.pay_type, Me.close_rop, Me.name_com, Me.disc_inv, Me.discT_inv, Me.discS_inv})
        Me.ListView_Inv.FullRowSelect = True
        Me.ListView_Inv.GridLines = True
        Me.ListView_Inv.HideSelection = False
        Me.ListView_Inv.Location = New System.Drawing.Point(3, 60)
        Me.ListView_Inv.MultiSelect = False
        Me.ListView_Inv.Name = "ListView_Inv"
        Me.ListView_Inv.Size = New System.Drawing.Size(418, 465)
        Me.ListView_Inv.TabIndex = 0
        Me.ListView_Inv.UseCompatibleStateImageBehavior = False
        Me.ListView_Inv.View = System.Windows.Forms.View.Details
        '
        'id_inv
        '
        Me.id_inv.Text = "invoice"
        Me.id_inv.Width = 0
        '
        'num_run
        '
        Me.num_run.Text = "ลำดับ"
        Me.num_run.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'number_inv
        '
        Me.number_inv.Text = "เลขที่"
        Me.number_inv.Width = 100
        '
        'qty_inv
        '
        Me.qty_inv.Text = "จำนวน"
        Me.qty_inv.Width = 76
        '
        'price_inv
        '
        Me.price_inv.Text = "ราคา"
        Me.price_inv.Width = 79
        '
        'date_inv
        '
        Me.date_inv.Text = "วัน/เดือน/ปี"
        Me.date_inv.Width = 110
        '
        'pay_type
        '
        Me.pay_type.DisplayIndex = 7
        Me.pay_type.Text = "Pay Type"
        '
        'close_rop
        '
        Me.close_rop.DisplayIndex = 6
        Me.close_rop.Text = "รอบบิล"
        Me.close_rop.Width = 120
        '
        'name_com
        '
        Me.name_com.Text = "Machine name"
        Me.name_com.Width = 100
        '
        'disc_inv
        '
        Me.disc_inv.Text = "Disc."
        Me.disc_inv.Width = 0
        '
        'discT_inv
        '
        Me.discT_inv.Text = "Disc T."
        Me.discT_inv.Width = 0
        '
        'discS_inv
        '
        Me.discS_inv.Text = "Disc S."
        Me.discS_inv.Width = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ListView_Inv1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 58)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(408, 318)
        Me.Panel1.TabIndex = 53
        '
        'ListView_Inv1
        '
        Me.ListView_Inv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListView_Inv1.CheckBoxes = True
        Me.ListView_Inv1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.st, Me.num_run1, Me.id_ord, Me.id_prd, Me.id_con_prd, Me.prd_name, Me.size1, Me.vat_s, Me.qty1, Me.price1, Me.disc, Me.discT, Me.discS, Me.total, Me.remark})
        Me.ListView_Inv1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView_Inv1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.ListView_Inv1.FullRowSelect = True
        Me.ListView_Inv1.GridLines = True
        Me.ListView_Inv1.Location = New System.Drawing.Point(0, 0)
        Me.ListView_Inv1.MultiSelect = False
        Me.ListView_Inv1.Name = "ListView_Inv1"
        Me.ListView_Inv1.Size = New System.Drawing.Size(408, 318)
        Me.ListView_Inv1.TabIndex = 32
        Me.ListView_Inv1.UseCompatibleStateImageBehavior = False
        Me.ListView_Inv1.View = System.Windows.Forms.View.Details
        '
        'st
        '
        Me.st.Text = "Sel"
        Me.st.Width = 0
        '
        'num_run1
        '
        Me.num_run1.Text = "ลำดับ"
        Me.num_run1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.num_run1.Width = 50
        '
        'id_ord
        '
        Me.id_ord.Text = "id_ord"
        Me.id_ord.Width = 0
        '
        'id_prd
        '
        Me.id_prd.Text = "id_prd"
        Me.id_prd.Width = 0
        '
        'id_con_prd
        '
        Me.id_con_prd.Text = "id_con_prd"
        Me.id_con_prd.Width = 0
        '
        'prd_name
        '
        Me.prd_name.Text = "ชื่อรายการ"
        Me.prd_name.Width = 130
        '
        'size1
        '
        Me.size1.Text = "ขนาด"
        Me.size1.Width = 80
        '
        'vat_s
        '
        Me.vat_s.Text = "Vat /S"
        Me.vat_s.Width = 0
        '
        'qty1
        '
        Me.qty1.Text = "จำนวน"
        Me.qty1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'price1
        '
        Me.price1.Text = "ราคา"
        Me.price1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.price1.Width = 80
        '
        'disc
        '
        Me.disc.Text = "Disc."
        Me.disc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'discT
        '
        Me.discT.Text = "Disc T."
        Me.discT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'discS
        '
        Me.discS.Text = "Disc Sum"
        Me.discS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.discS.Width = 0
        '
        'total
        '
        Me.total.Text = "Total"
        Me.total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.total.Width = 80
        '
        'remark
        '
        Me.remark.Text = "Remark"
        Me.remark.Width = 100
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.Panel3.Controls.Add(Me.btn_tickall)
        Me.Panel3.Controls.Add(Me.btn_close)
        Me.Panel3.Controls.Add(Me.dw1)
        Me.Panel3.Controls.Add(Me.up1)
        Me.Panel3.Controls.Add(Me.btn_tick)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(408, 58)
        Me.Panel3.TabIndex = 52
        '
        'btn_tickall
        '
        Me.btn_tickall.Enabled = False
        Me.btn_tickall.Image = Global.BeecomePOS.My.Resources.Resources.tick_16
        Me.btn_tickall.Location = New System.Drawing.Point(88, 6)
        Me.btn_tickall.Name = "btn_tickall"
        Me.btn_tickall.Size = New System.Drawing.Size(83, 47)
        Me.btn_tickall.TabIndex = 35
        Me.btn_tickall.Text = "Tick All"
        Me.btn_tickall.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_tickall.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_tickall.UseVisualStyleBackColor = True
        Me.btn_tickall.Visible = False
        '
        'btn_close
        '
        Me.btn_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_close.Image = Global.BeecomePOS.My.Resources.Resources.delete_16
        Me.btn_close.Location = New System.Drawing.Point(315, 6)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.Size = New System.Drawing.Size(89, 48)
        Me.btn_close.TabIndex = 37
        Me.btn_close.Text = "Close"
        Me.btn_close.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_close.UseVisualStyleBackColor = True
        '
        'dw1
        '
        Me.dw1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dw1.Image = Global.BeecomePOS.My.Resources.Resources.arrow_270
        Me.dw1.Location = New System.Drawing.Point(228, 6)
        Me.dw1.Name = "dw1"
        Me.dw1.Size = New System.Drawing.Size(46, 49)
        Me.dw1.TabIndex = 33
        Me.dw1.UseVisualStyleBackColor = True
        Me.dw1.Visible = False
        '
        'up1
        '
        Me.up1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.up1.Image = Global.BeecomePOS.My.Resources.Resources.arrow_0901
        Me.up1.Location = New System.Drawing.Point(173, 6)
        Me.up1.Name = "up1"
        Me.up1.Size = New System.Drawing.Size(46, 49)
        Me.up1.TabIndex = 32
        Me.up1.UseVisualStyleBackColor = True
        Me.up1.Visible = False
        '
        'btn_tick
        '
        Me.btn_tick.Enabled = False
        Me.btn_tick.Image = Global.BeecomePOS.My.Resources.Resources.tick_16
        Me.btn_tick.Location = New System.Drawing.Point(3, 6)
        Me.btn_tick.Name = "btn_tick"
        Me.btn_tick.Size = New System.Drawing.Size(83, 47)
        Me.btn_tick.TabIndex = 34
        Me.btn_tick.Text = "Tick"
        Me.btn_tick.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_tick.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_tick.UseVisualStyleBackColor = True
        Me.btn_tick.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txt_sum_price)
        Me.Panel2.Controls.Add(Me.Label9)
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
        Me.Panel2.Location = New System.Drawing.Point(0, 376)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(408, 152)
        Me.Panel2.TabIndex = 51
        '
        'txt_sum_price
        '
        Me.txt_sum_price.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_sum_price.BackColor = System.Drawing.Color.Gray
        Me.txt_sum_price.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_sum_price.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_sum_price.ForeColor = System.Drawing.Color.Black
        Me.txt_sum_price.Location = New System.Drawing.Point(288, 6)
        Me.txt_sum_price.MaxLength = 4
        Me.txt_sum_price.Name = "txt_sum_price"
        Me.txt_sum_price.ReadOnly = True
        Me.txt_sum_price.Size = New System.Drawing.Size(113, 24)
        Me.txt_sum_price.TabIndex = 64
        Me.txt_sum_price.Text = "0.0"
        Me.txt_sum_price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(148, 10)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(134, 16)
        Me.Label9.TabIndex = 63
        Me.Label9.Text = "ราคาทั้งหมดไม่รวมภาษี"
        '
        'txt_sum_discount
        '
        Me.txt_sum_discount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_sum_discount.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txt_sum_discount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_sum_discount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_sum_discount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txt_sum_discount.Location = New System.Drawing.Point(288, 84)
        Me.txt_sum_discount.MaxLength = 4
        Me.txt_sum_discount.Name = "txt_sum_discount"
        Me.txt_sum_discount.ReadOnly = True
        Me.txt_sum_discount.Size = New System.Drawing.Size(112, 21)
        Me.txt_sum_discount.TabIndex = 62
        Me.txt_sum_discount.Text = "0.0"
        Me.txt_sum_discount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(185, 40)
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
        Me.txt_sum_service_chg.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txt_sum_service_chg.Location = New System.Drawing.Point(288, 59)
        Me.txt_sum_service_chg.MaxLength = 4
        Me.txt_sum_service_chg.Name = "txt_sum_service_chg"
        Me.txt_sum_service_chg.ReadOnly = True
        Me.txt_sum_service_chg.Size = New System.Drawing.Size(113, 21)
        Me.txt_sum_service_chg.TabIndex = 61
        Me.txt_sum_service_chg.Text = "0.0"
        Me.txt_sum_service_chg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(120, 68)
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
        Me.txt_sum_vat.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txt_sum_vat.Location = New System.Drawing.Point(288, 32)
        Me.txt_sum_vat.MaxLength = 4
        Me.txt_sum_vat.Name = "txt_sum_vat"
        Me.txt_sum_vat.ReadOnly = True
        Me.txt_sum_vat.Size = New System.Drawing.Size(113, 21)
        Me.txt_sum_vat.TabIndex = 60
        Me.txt_sum_vat.Text = "0.0"
        Me.txt_sum_vat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_sum_total
        '
        Me.txt_sum_total.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_sum_total.BackColor = System.Drawing.Color.Black
        Me.txt_sum_total.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_sum_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_sum_total.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txt_sum_total.Location = New System.Drawing.Point(208, 109)
        Me.txt_sum_total.MaxLength = 4
        Me.txt_sum_total.Name = "txt_sum_total"
        Me.txt_sum_total.ReadOnly = True
        Me.txt_sum_total.Size = New System.Drawing.Size(193, 40)
        Me.txt_sum_total.TabIndex = 59
        Me.txt_sum_total.Text = "0.0"
        Me.txt_sum_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(270, 65)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(15, 13)
        Me.Label15.TabIndex = 58
        Me.Label15.Text = "%"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(242, 88)
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
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(10, 114)
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
        Me.txt_service_chg.ForeColor = System.Drawing.Color.Red
        Me.txt_service_chg.Location = New System.Drawing.Point(205, 61)
        Me.txt_service_chg.MaxLength = 2
        Me.txt_service_chg.Name = "txt_service_chg"
        Me.txt_service_chg.ReadOnly = True
        Me.txt_service_chg.Size = New System.Drawing.Size(59, 20)
        Me.txt_service_chg.TabIndex = 56
        Me.txt_service_chg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'form_voidbill
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(836, 528)
        Me.ControlBox = False
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "form_voidbill"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Void Bill"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents enter_void As System.Windows.Forms.Button
    Friend WithEvents ListView_Inv As System.Windows.Forms.ListView
    Friend WithEvents id_inv As System.Windows.Forms.ColumnHeader
    Friend WithEvents number_inv As System.Windows.Forms.ColumnHeader
    Friend WithEvents qty_inv As System.Windows.Forms.ColumnHeader
    Friend WithEvents price_inv As System.Windows.Forms.ColumnHeader
    Friend WithEvents date_inv As System.Windows.Forms.ColumnHeader
    Friend WithEvents dw1 As System.Windows.Forms.Button
    Friend WithEvents up1 As System.Windows.Forms.Button
    Friend WithEvents dw As System.Windows.Forms.Button
    Friend WithEvents up As System.Windows.Forms.Button
    Friend WithEvents btn_tick As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ListView_Inv1 As System.Windows.Forms.ListView
    Friend WithEvents st As System.Windows.Forms.ColumnHeader
    Friend WithEvents id_ord As System.Windows.Forms.ColumnHeader
    Friend WithEvents id_prd As System.Windows.Forms.ColumnHeader
    Friend WithEvents id_con_prd As System.Windows.Forms.ColumnHeader
    Friend WithEvents prd_name As System.Windows.Forms.ColumnHeader
    Friend WithEvents size1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents vat_s As System.Windows.Forms.ColumnHeader
    Friend WithEvents qty1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents price1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
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
    Friend WithEvents print1 As System.Windows.Forms.Button
    Friend WithEvents btn_close As System.Windows.Forms.Button
    Friend WithEvents btn_tickall As System.Windows.Forms.Button
    Friend WithEvents pay_type As System.Windows.Forms.ColumnHeader
    Friend WithEvents close_rop As System.Windows.Forms.ColumnHeader
    Friend WithEvents name_com As System.Windows.Forms.ColumnHeader
    Friend WithEvents btn_reload As System.Windows.Forms.Button
    Friend WithEvents disc As System.Windows.Forms.ColumnHeader
    Friend WithEvents discT As System.Windows.Forms.ColumnHeader
    Friend WithEvents discS As System.Windows.Forms.ColumnHeader
    Friend WithEvents remark As System.Windows.Forms.ColumnHeader
    Friend WithEvents total As System.Windows.Forms.ColumnHeader
    Friend WithEvents disc_inv As System.Windows.Forms.ColumnHeader
    Friend WithEvents discT_inv As System.Windows.Forms.ColumnHeader
    Friend WithEvents discS_inv As System.Windows.Forms.ColumnHeader
    Friend WithEvents num_run As System.Windows.Forms.ColumnHeader
    Friend WithEvents num_run1 As System.Windows.Forms.ColumnHeader
End Class
