<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class gohome_list_void_orderlist
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(gohome_list_void_orderlist))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn_drow = New System.Windows.Forms.Button()
        Me.btn_up = New System.Windows.Forms.Button()
        Me.btn_close = New System.Windows.Forms.Button()
        Me.btn_cut = New System.Windows.Forms.Button()
        Me.btn_re = New System.Windows.Forms.Button()
        Me.btn_save = New System.Windows.Forms.Button()
        Me.ListView_GHF = New System.Windows.Forms.ListView()
        Me.id_ord = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.status_sendC = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.id_prd = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.id_prd_con = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.name_prd = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.size_prd = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.amt_prd = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.price_prd = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.remark = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.disc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.disc_t = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.disc_sum = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.netamount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.id_cat = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.id_subcat = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.name_cat_en = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.name_cat_th = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.name_subcat_en = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.name_subcat_th = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ord_vat = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ord_vat_st = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.name_prd_en = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btn_drow)
        Me.Panel1.Controls.Add(Me.btn_up)
        Me.Panel1.Controls.Add(Me.btn_close)
        Me.Panel1.Controls.Add(Me.btn_cut)
        Me.Panel1.Controls.Add(Me.btn_re)
        Me.Panel1.Controls.Add(Me.btn_save)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(706, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(87, 494)
        Me.Panel1.TabIndex = 25
        '
        'btn_drow
        '
        Me.btn_drow.Image = Global.BeecomePOS.My.Resources.Resources.arrow_270
        Me.btn_drow.Location = New System.Drawing.Point(6, 62)
        Me.btn_drow.Name = "btn_drow"
        Me.btn_drow.Size = New System.Drawing.Size(75, 54)
        Me.btn_drow.TabIndex = 5
        Me.btn_drow.Text = "ลง"
        Me.btn_drow.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_drow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_drow.UseVisualStyleBackColor = True
        '
        'btn_up
        '
        Me.btn_up.Image = Global.BeecomePOS.My.Resources.Resources.arrow_0901
        Me.btn_up.Location = New System.Drawing.Point(6, 3)
        Me.btn_up.Name = "btn_up"
        Me.btn_up.Size = New System.Drawing.Size(75, 54)
        Me.btn_up.TabIndex = 4
        Me.btn_up.Text = "ขึ้น"
        Me.btn_up.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_up.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_up.UseVisualStyleBackColor = True
        '
        'btn_close
        '
        Me.btn_close.Image = Global.BeecomePOS.My.Resources.Resources.delete_16
        Me.btn_close.Location = New System.Drawing.Point(6, 437)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.Size = New System.Drawing.Size(75, 54)
        Me.btn_close.TabIndex = 3
        Me.btn_close.Text = "Close"
        Me.btn_close.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_close.UseVisualStyleBackColor = True
        '
        'btn_cut
        '
        Me.btn_cut.Enabled = False
        Me.btn_cut.Image = Global.BeecomePOS.My.Resources.Resources.arrow_curve
        Me.btn_cut.Location = New System.Drawing.Point(6, 124)
        Me.btn_cut.Name = "btn_cut"
        Me.btn_cut.Size = New System.Drawing.Size(75, 54)
        Me.btn_cut.TabIndex = 0
        Me.btn_cut.Text = "ตัดออก"
        Me.btn_cut.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_cut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_cut.UseVisualStyleBackColor = True
        '
        'btn_re
        '
        Me.btn_re.Enabled = False
        Me.btn_re.Image = Global.BeecomePOS.My.Resources.Resources.arrow_curve_1801
        Me.btn_re.Location = New System.Drawing.Point(6, 184)
        Me.btn_re.Name = "btn_re"
        Me.btn_re.Size = New System.Drawing.Size(75, 54)
        Me.btn_re.TabIndex = 1
        Me.btn_re.Text = "คืนค่า"
        Me.btn_re.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_re.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_re.UseVisualStyleBackColor = True
        '
        'btn_save
        '
        Me.btn_save.Image = Global.BeecomePOS.My.Resources.Resources.save_16
        Me.btn_save.Location = New System.Drawing.Point(6, 377)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(75, 54)
        Me.btn_save.TabIndex = 2
        Me.btn_save.Text = "Save"
        Me.btn_save.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'ListView_GHF
        '
        Me.ListView_GHF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListView_GHF.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.id_ord, Me.status_sendC, Me.id_prd, Me.id_prd_con, Me.name_prd, Me.name_prd_en, Me.size_prd, Me.amt_prd, Me.price_prd, Me.remark, Me.disc, Me.disc_t, Me.disc_sum, Me.netamount, Me.id_cat, Me.id_subcat, Me.name_cat_en, Me.name_cat_th, Me.name_subcat_en, Me.name_subcat_th, Me.ord_vat, Me.ord_vat_st})
        Me.ListView_GHF.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ListView_GHF.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView_GHF.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.ListView_GHF.FullRowSelect = True
        Me.ListView_GHF.GridLines = True
        Me.ListView_GHF.Location = New System.Drawing.Point(0, 0)
        Me.ListView_GHF.MultiSelect = False
        Me.ListView_GHF.Name = "ListView_GHF"
        Me.ListView_GHF.Size = New System.Drawing.Size(706, 494)
        Me.ListView_GHF.TabIndex = 26
        Me.ListView_GHF.UseCompatibleStateImageBehavior = False
        Me.ListView_GHF.View = System.Windows.Forms.View.Details
        '
        'id_ord
        '
        Me.id_ord.Text = "id_ord"
        Me.id_ord.Width = 0
        '
        'status_sendC
        '
        Me.status_sendC.Text = "status_sendC"
        Me.status_sendC.Width = 0
        '
        'id_prd
        '
        Me.id_prd.Text = "id_prd"
        Me.id_prd.Width = 0
        '
        'id_prd_con
        '
        Me.id_prd_con.Text = "id_prd_con"
        Me.id_prd_con.Width = 0
        '
        'name_prd
        '
        Me.name_prd.Text = "ชื่อรายการ"
        Me.name_prd.Width = 120
        '
        'size_prd
        '
        Me.size_prd.Text = "ขนาด"
        Me.size_prd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'amt_prd
        '
        Me.amt_prd.Text = "จำนวน"
        Me.amt_prd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.amt_prd.Width = 50
        '
        'price_prd
        '
        Me.price_prd.Text = "ราคา"
        Me.price_prd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.price_prd.Width = 70
        '
        'remark
        '
        Me.remark.Text = "เพิ่มเติม"
        Me.remark.Width = 80
        '
        'disc
        '
        Me.disc.Text = "Disc."
        Me.disc.Width = 50
        '
        'disc_t
        '
        Me.disc_t.Text = "Disc T."
        Me.disc_t.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'disc_sum
        '
        Me.disc_sum.Text = "Disc Sum."
        Me.disc_sum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.disc_sum.Width = 0
        '
        'netamount
        '
        Me.netamount.Text = "Net Amount"
        Me.netamount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.netamount.Width = 80
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
        'name_prd_en
        '
        Me.name_prd_en.Text = "Name EN"
        Me.name_prd_en.Width = 80
        '
        'gohome_list_void_orderlist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(793, 494)
        Me.Controls.Add(Me.ListView_GHF)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "gohome_list_void_orderlist"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TakeHome Void Order List"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btn_cut As System.Windows.Forms.Button
    Friend WithEvents btn_re As System.Windows.Forms.Button
    Friend WithEvents btn_save As System.Windows.Forms.Button
    Friend WithEvents ListView_GHF As System.Windows.Forms.ListView
    Friend WithEvents id_ord As System.Windows.Forms.ColumnHeader
    Friend WithEvents status_sendC As System.Windows.Forms.ColumnHeader
    Friend WithEvents id_prd As System.Windows.Forms.ColumnHeader
    Friend WithEvents id_prd_con As System.Windows.Forms.ColumnHeader
    Friend WithEvents name_prd As System.Windows.Forms.ColumnHeader
    Friend WithEvents size_prd As System.Windows.Forms.ColumnHeader
    Friend WithEvents amt_prd As System.Windows.Forms.ColumnHeader
    Friend WithEvents price_prd As System.Windows.Forms.ColumnHeader
    Friend WithEvents remark As System.Windows.Forms.ColumnHeader
    Friend WithEvents disc As System.Windows.Forms.ColumnHeader
    Friend WithEvents disc_t As System.Windows.Forms.ColumnHeader
    Friend WithEvents disc_sum As System.Windows.Forms.ColumnHeader
    Friend WithEvents netamount As System.Windows.Forms.ColumnHeader
    Friend WithEvents id_cat As System.Windows.Forms.ColumnHeader
    Friend WithEvents id_subcat As System.Windows.Forms.ColumnHeader
    Friend WithEvents name_cat_en As System.Windows.Forms.ColumnHeader
    Friend WithEvents name_cat_th As System.Windows.Forms.ColumnHeader
    Friend WithEvents name_subcat_en As System.Windows.Forms.ColumnHeader
    Friend WithEvents name_subcat_th As System.Windows.Forms.ColumnHeader
    Friend WithEvents ord_vat As System.Windows.Forms.ColumnHeader
    Friend WithEvents ord_vat_st As System.Windows.Forms.ColumnHeader
    Friend WithEvents btn_close As System.Windows.Forms.Button
    Friend WithEvents btn_drow As System.Windows.Forms.Button
    Friend WithEvents btn_up As System.Windows.Forms.Button
    Friend WithEvents name_prd_en As System.Windows.Forms.ColumnHeader
End Class
