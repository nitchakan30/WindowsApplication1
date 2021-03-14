<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class payment_gohome_subp_dialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(payment_gohome_subp_dialog))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.btn_up_sel = New System.Windows.Forms.Button()
        Me.btn_drow_sel = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.st = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.id_ord = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.id_prd = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.id_con_prd = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.prd_name = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.size1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.vat_s = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.qty1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.price1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.vat_cal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.balance = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.disc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.disc_sum = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.discT = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.netamount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.remark = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.id_cat = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.id_subcat = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.name_cat_en = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.name_cat_th = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.name_subcat_en = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.name_subcat_th = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ord_vat = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ord_vat_st = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.qty_old = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.total_old = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.rf_id_table = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.rf_id_join = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.prd_name_en = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button6)
        Me.Panel1.Controls.Add(Me.btn_up_sel)
        Me.Panel1.Controls.Add(Me.btn_drow_sel)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(673, 61)
        Me.Panel1.TabIndex = 43
        '
        'Button6
        '
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Button6.Image = Global.BeecomePOS.My.Resources.Resources.Doc_Edit
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button6.Location = New System.Drawing.Point(245, 4)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(185, 51)
        Me.Button6.TabIndex = 39
        Me.Button6.Text = "แก้ไขจำนวน / Edit Qty"
        Me.Button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button6.UseVisualStyleBackColor = True
        '
        'btn_up_sel
        '
        Me.btn_up_sel.Image = Global.BeecomePOS.My.Resources.Resources.arrow_0901
        Me.btn_up_sel.Location = New System.Drawing.Point(4, 3)
        Me.btn_up_sel.Name = "btn_up_sel"
        Me.btn_up_sel.Size = New System.Drawing.Size(56, 51)
        Me.btn_up_sel.TabIndex = 37
        Me.btn_up_sel.UseVisualStyleBackColor = True
        '
        'btn_drow_sel
        '
        Me.btn_drow_sel.Image = Global.BeecomePOS.My.Resources.Resources.arrow_270
        Me.btn_drow_sel.Location = New System.Drawing.Point(66, 4)
        Me.btn_drow_sel.Name = "btn_drow_sel"
        Me.btn_drow_sel.Size = New System.Drawing.Size(56, 51)
        Me.btn_drow_sel.TabIndex = 38
        Me.btn_drow_sel.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.Button1)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 315)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(673, 65)
        Me.FlowLayoutPanel1.TabIndex = 42
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button1.Location = New System.Drawing.Point(3, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(128, 55)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.ListView1.BackColor = System.Drawing.Color.White
        Me.ListView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.st, Me.id_ord, Me.id_prd, Me.id_con_prd, Me.prd_name, Me.prd_name_en, Me.size1, Me.vat_s, Me.qty1, Me.price1, Me.vat_cal, Me.balance, Me.disc, Me.disc_sum, Me.discT, Me.netamount, Me.remark, Me.id_cat, Me.id_subcat, Me.name_cat_en, Me.name_cat_th, Me.name_subcat_en, Me.name_subcat_th, Me.ord_vat, Me.ord_vat_st, Me.qty_old, Me.total_old, Me.rf_id_table, Me.rf_id_join})
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.HideSelection = False
        Me.ListView1.HotTracking = True
        Me.ListView1.HoverSelection = True
        Me.ListView1.Location = New System.Drawing.Point(0, 61)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(673, 254)
        Me.ListView1.TabIndex = 45
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'st
        '
        Me.st.Text = ""
        Me.st.Width = 0
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
        Me.prd_name.Text = "Name"
        Me.prd_name.Width = 128
        '
        'size1
        '
        Me.size1.Text = "Size"
        Me.size1.Width = 70
        '
        'vat_s
        '
        Me.vat_s.Text = "vat s"
        Me.vat_s.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.vat_s.Width = 0
        '
        'qty1
        '
        Me.qty1.Text = "Qty"
        Me.qty1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.qty1.Width = 70
        '
        'price1
        '
        Me.price1.Text = "Price"
        Me.price1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.price1.Width = 0
        '
        'vat_cal
        '
        Me.vat_cal.Text = "Vat"
        Me.vat_cal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.vat_cal.Width = 0
        '
        'balance
        '
        Me.balance.Text = "Total"
        Me.balance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.balance.Width = 85
        '
        'disc
        '
        Me.disc.Text = "Disc"
        Me.disc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.disc.Width = 71
        '
        'disc_sum
        '
        Me.disc_sum.Text = "Disc S. "
        Me.disc_sum.Width = 0
        '
        'discT
        '
        Me.discT.Text = "Disc T."
        Me.discT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.discT.Width = 67
        '
        'netamount
        '
        Me.netamount.Text = "Net Amount"
        Me.netamount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.netamount.Width = 80
        '
        'remark
        '
        Me.remark.Text = "Remark"
        Me.remark.Width = 90
        '
        'id_cat
        '
        Me.id_cat.Text = "id_cat"
        Me.id_cat.Width = 0
        '
        'id_subcat
        '
        Me.id_subcat.Text = "id_subcat"
        Me.id_subcat.Width = 0
        '
        'name_cat_en
        '
        Me.name_cat_en.Text = "name_cat_en"
        Me.name_cat_en.Width = 0
        '
        'name_cat_th
        '
        Me.name_cat_th.Text = "name_cat_th"
        Me.name_cat_th.Width = 0
        '
        'name_subcat_en
        '
        Me.name_subcat_en.Text = "name_subcat_en"
        Me.name_subcat_en.Width = 0
        '
        'name_subcat_th
        '
        Me.name_subcat_th.Text = "name_subcat_th"
        Me.name_subcat_th.Width = 0
        '
        'ord_vat
        '
        Me.ord_vat.Text = "ord_vat"
        Me.ord_vat.Width = 0
        '
        'ord_vat_st
        '
        Me.ord_vat_st.Text = "ord_vat_st"
        Me.ord_vat_st.Width = 0
        '
        'qty_old
        '
        Me.qty_old.Text = "qty_old"
        Me.qty_old.Width = 0
        '
        'total_old
        '
        Me.total_old.Text = "total_old"
        Me.total_old.Width = 0
        '
        'rf_id_table
        '
        Me.rf_id_table.Text = "rf_id_table"
        Me.rf_id_table.Width = 0
        '
        'rf_id_join
        '
        Me.rf_id_join.Text = "rf_id_join"
        Me.rf_id_join.Width = 0
        '
        'prd_name_en
        '
        Me.prd_name_en.Text = "Name EN"
        Me.prd_name_en.Width = 100
        '
        'payment_gohome_subp_dialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(673, 380)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "payment_gohome_subp_dialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Move Bill"
        Me.Panel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents btn_up_sel As System.Windows.Forms.Button
    Friend WithEvents btn_drow_sel As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents st As System.Windows.Forms.ColumnHeader
    Friend WithEvents id_ord As System.Windows.Forms.ColumnHeader
    Friend WithEvents id_prd As System.Windows.Forms.ColumnHeader
    Friend WithEvents id_con_prd As System.Windows.Forms.ColumnHeader
    Friend WithEvents prd_name As System.Windows.Forms.ColumnHeader
    Friend WithEvents size1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents vat_s As System.Windows.Forms.ColumnHeader
    Friend WithEvents qty1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents price1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents vat_cal As System.Windows.Forms.ColumnHeader
    Friend WithEvents balance As System.Windows.Forms.ColumnHeader
    Friend WithEvents disc As System.Windows.Forms.ColumnHeader
    Friend WithEvents disc_sum As System.Windows.Forms.ColumnHeader
    Friend WithEvents discT As System.Windows.Forms.ColumnHeader
    Friend WithEvents netamount As System.Windows.Forms.ColumnHeader
    Friend WithEvents remark As System.Windows.Forms.ColumnHeader
    Friend WithEvents id_cat As System.Windows.Forms.ColumnHeader
    Friend WithEvents id_subcat As System.Windows.Forms.ColumnHeader
    Friend WithEvents name_cat_en As System.Windows.Forms.ColumnHeader
    Friend WithEvents name_cat_th As System.Windows.Forms.ColumnHeader
    Friend WithEvents name_subcat_en As System.Windows.Forms.ColumnHeader
    Friend WithEvents name_subcat_th As System.Windows.Forms.ColumnHeader
    Friend WithEvents ord_vat As System.Windows.Forms.ColumnHeader
    Friend WithEvents ord_vat_st As System.Windows.Forms.ColumnHeader
    Friend WithEvents qty_old As System.Windows.Forms.ColumnHeader
    Friend WithEvents total_old As System.Windows.Forms.ColumnHeader
    Friend WithEvents rf_id_table As System.Windows.Forms.ColumnHeader
    Friend WithEvents rf_id_join As System.Windows.Forms.ColumnHeader
    Friend WithEvents prd_name_en As System.Windows.Forms.ColumnHeader
End Class
