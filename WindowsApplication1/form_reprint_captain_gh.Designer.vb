<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_reprint_captain_gh
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btn_tick_left_all = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btn_drow_left = New System.Windows.Forms.Button()
        Me.btn_up_left = New System.Windows.Forms.Button()
        Me.btn_tick_left = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn_print = New System.Windows.Forms.Button()
        Me.btn_close = New System.Windows.Forms.Button()
        Me.Check1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.st_sendcaptain = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.id_ord = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rf_id_prd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rf_id_con = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.name_ord = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Name_EN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.size_n = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.samt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sprice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.remark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ref_cat_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ref_catsubprd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.name_th_cat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.name_en_cat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.name_th_catsubprd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.name_en_catsubprd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ord_vat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ord_vat_st = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.samt_old = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_tick_left_all
        '
        Me.btn_tick_left_all.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_tick_left_all.Location = New System.Drawing.Point(0, 6)
        Me.btn_tick_left_all.Name = "btn_tick_left_all"
        Me.btn_tick_left_all.Size = New System.Drawing.Size(155, 44)
        Me.btn_tick_left_all.TabIndex = 19
        Me.btn_tick_left_all.Text = "Select All"
        Me.btn_tick_left_all.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btn_drow_left)
        Me.Panel2.Controls.Add(Me.btn_tick_left_all)
        Me.Panel2.Controls.Add(Me.btn_up_left)
        Me.Panel2.Controls.Add(Me.btn_tick_left)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(3, 22)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(778, 53)
        Me.Panel2.TabIndex = 20
        '
        'btn_drow_left
        '
        Me.btn_drow_left.Image = Global.BeecomePOS.My.Resources.Resources.arrow_270
        Me.btn_drow_left.Location = New System.Drawing.Point(715, 4)
        Me.btn_drow_left.Name = "btn_drow_left"
        Me.btn_drow_left.Size = New System.Drawing.Size(62, 44)
        Me.btn_drow_left.TabIndex = 14
        Me.btn_drow_left.UseVisualStyleBackColor = True
        '
        'btn_up_left
        '
        Me.btn_up_left.Image = Global.BeecomePOS.My.Resources.Resources.arrow_0901
        Me.btn_up_left.Location = New System.Drawing.Point(649, 4)
        Me.btn_up_left.Name = "btn_up_left"
        Me.btn_up_left.Size = New System.Drawing.Size(61, 44)
        Me.btn_up_left.TabIndex = 13
        Me.btn_up_left.UseVisualStyleBackColor = True
        '
        'btn_tick_left
        '
        Me.btn_tick_left.Image = Global.BeecomePOS.My.Resources.Resources.tick_16
        Me.btn_tick_left.Location = New System.Drawing.Point(164, 6)
        Me.btn_tick_left.Name = "btn_tick_left"
        Me.btn_tick_left.Size = New System.Drawing.Size(67, 44)
        Me.btn_tick_left.TabIndex = 12
        Me.btn_tick_left.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Check1, Me.st_sendcaptain, Me.id_ord, Me.rf_id_prd, Me.rf_id_con, Me.name_ord, Me.Name_EN, Me.size_n, Me.samt, Me.sprice, Me.remark, Me.ref_cat_id, Me.ref_catsubprd, Me.name_th_cat, Me.name_en_cat, Me.name_th_catsubprd, Me.name_en_catsubprd, Me.ord_vat, Me.ord_vat_st, Me.samt_old})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(3, 75)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(778, 325)
        Me.DataGridView1.TabIndex = 21
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DataGridView1)
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 59)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(784, 403)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "รายการสินค้าทั้งหมด"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btn_print)
        Me.Panel1.Controls.Add(Me.btn_close)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(784, 59)
        Me.Panel1.TabIndex = 18
        '
        'btn_print
        '
        Me.btn_print.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_print.Image = Global.BeecomePOS.My.Resources.Resources.print_32
        Me.btn_print.Location = New System.Drawing.Point(3, 6)
        Me.btn_print.Name = "btn_print"
        Me.btn_print.Size = New System.Drawing.Size(180, 50)
        Me.btn_print.TabIndex = 8
        Me.btn_print.Text = "พิมพ์  / Print"
        Me.btn_print.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_print.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_print.UseVisualStyleBackColor = True
        '
        'btn_close
        '
        Me.btn_close.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_close.Image = Global.BeecomePOS.My.Resources.Resources.delete_32
        Me.btn_close.Location = New System.Drawing.Point(639, 4)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.Size = New System.Drawing.Size(141, 50)
        Me.btn_close.TabIndex = 9
        Me.btn_close.Text = "ออก / Exit"
        Me.btn_close.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_close.UseVisualStyleBackColor = True
        '
        'Check1
        '
        Me.Check1.HeaderText = ""
        Me.Check1.Name = "Check1"
        Me.Check1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Check1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Check1.Width = 20
        '
        'st_sendcaptain
        '
        Me.st_sendcaptain.HeaderText = "st_sendcaptain"
        Me.st_sendcaptain.Name = "st_sendcaptain"
        Me.st_sendcaptain.ReadOnly = True
        Me.st_sendcaptain.Visible = False
        Me.st_sendcaptain.Width = 10
        '
        'id_ord
        '
        Me.id_ord.HeaderText = "id_ord"
        Me.id_ord.Name = "id_ord"
        Me.id_ord.ReadOnly = True
        Me.id_ord.Visible = False
        Me.id_ord.Width = 10
        '
        'rf_id_prd
        '
        Me.rf_id_prd.HeaderText = "rf_id_prd"
        Me.rf_id_prd.Name = "rf_id_prd"
        Me.rf_id_prd.ReadOnly = True
        Me.rf_id_prd.Visible = False
        Me.rf_id_prd.Width = 10
        '
        'rf_id_con
        '
        Me.rf_id_con.HeaderText = "rf_id_con"
        Me.rf_id_con.Name = "rf_id_con"
        Me.rf_id_con.ReadOnly = True
        Me.rf_id_con.Visible = False
        Me.rf_id_con.Width = 10
        '
        'name_ord
        '
        Me.name_ord.HeaderText = "Name"
        Me.name_ord.Name = "name_ord"
        Me.name_ord.ReadOnly = True
        Me.name_ord.Width = 170
        '
        'Name_EN
        '
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Name_EN.DefaultCellStyle = DataGridViewCellStyle1
        Me.Name_EN.HeaderText = "Name EN"
        Me.Name_EN.Name = "Name_EN"
        Me.Name_EN.ReadOnly = True
        '
        'size_n
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.size_n.DefaultCellStyle = DataGridViewCellStyle2
        Me.size_n.HeaderText = "Size/Unit"
        Me.size_n.Name = "size_n"
        Me.size_n.ReadOnly = True
        Me.size_n.Width = 70
        '
        'samt
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Red
        Me.samt.DefaultCellStyle = DataGridViewCellStyle3
        Me.samt.HeaderText = "Qty"
        Me.samt.Name = "samt"
        '
        'sprice
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.sprice.DefaultCellStyle = DataGridViewCellStyle4
        Me.sprice.HeaderText = "Price"
        Me.sprice.Name = "sprice"
        Me.sprice.ReadOnly = True
        '
        'remark
        '
        Me.remark.HeaderText = "Remark"
        Me.remark.MaxInputLength = 300
        Me.remark.Name = "remark"
        Me.remark.Width = 170
        '
        'ref_cat_id
        '
        Me.ref_cat_id.HeaderText = "ref_cat_id"
        Me.ref_cat_id.Name = "ref_cat_id"
        Me.ref_cat_id.ReadOnly = True
        Me.ref_cat_id.Visible = False
        Me.ref_cat_id.Width = 10
        '
        'ref_catsubprd
        '
        Me.ref_catsubprd.HeaderText = "ref_catsubprd"
        Me.ref_catsubprd.Name = "ref_catsubprd"
        Me.ref_catsubprd.ReadOnly = True
        Me.ref_catsubprd.Visible = False
        Me.ref_catsubprd.Width = 10
        '
        'name_th_cat
        '
        Me.name_th_cat.HeaderText = "name_th_cat"
        Me.name_th_cat.Name = "name_th_cat"
        Me.name_th_cat.ReadOnly = True
        Me.name_th_cat.Visible = False
        '
        'name_en_cat
        '
        Me.name_en_cat.HeaderText = "name_en_cat"
        Me.name_en_cat.Name = "name_en_cat"
        Me.name_en_cat.ReadOnly = True
        Me.name_en_cat.Visible = False
        '
        'name_th_catsubprd
        '
        Me.name_th_catsubprd.HeaderText = "name_th_catsubprd"
        Me.name_th_catsubprd.Name = "name_th_catsubprd"
        Me.name_th_catsubprd.ReadOnly = True
        Me.name_th_catsubprd.Visible = False
        Me.name_th_catsubprd.Width = 10
        '
        'name_en_catsubprd
        '
        Me.name_en_catsubprd.HeaderText = "name_en_catsubprd"
        Me.name_en_catsubprd.Name = "name_en_catsubprd"
        Me.name_en_catsubprd.ReadOnly = True
        Me.name_en_catsubprd.Visible = False
        Me.name_en_catsubprd.Width = 10
        '
        'ord_vat
        '
        Me.ord_vat.HeaderText = "ord_vat"
        Me.ord_vat.Name = "ord_vat"
        Me.ord_vat.ReadOnly = True
        Me.ord_vat.Visible = False
        Me.ord_vat.Width = 10
        '
        'ord_vat_st
        '
        Me.ord_vat_st.HeaderText = "ord_vat_st"
        Me.ord_vat_st.Name = "ord_vat_st"
        Me.ord_vat_st.ReadOnly = True
        Me.ord_vat_st.Visible = False
        Me.ord_vat_st.Width = 10
        '
        'samt_old
        '
        Me.samt_old.HeaderText = "samt_old"
        Me.samt_old.Name = "samt_old"
        Me.samt_old.ReadOnly = True
        Me.samt_old.Visible = False
        Me.samt_old.Width = 50
        '
        'form_reprint_captain_gh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 462)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "form_reprint_captain_gh"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Reprint captain order"
        Me.Panel2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_close As System.Windows.Forms.Button
    Friend WithEvents btn_drow_left As System.Windows.Forms.Button
    Friend WithEvents btn_tick_left_all As System.Windows.Forms.Button
    Friend WithEvents btn_up_left As System.Windows.Forms.Button
    Friend WithEvents btn_tick_left As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btn_print As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Check1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents st_sendcaptain As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents id_ord As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rf_id_prd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rf_id_con As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents name_ord As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Name_EN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents size_n As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents samt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sprice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents remark As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ref_cat_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ref_catsubprd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents name_th_cat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents name_en_cat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents name_th_catsubprd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents name_en_catsubprd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ord_vat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ord_vat_st As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents samt_old As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
