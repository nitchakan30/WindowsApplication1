<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class home_cancel_order
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
        Me.ListView_food = New System.Windows.Forms.ListView()
        Me.st = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.id_ord = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.id_prd = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.id_con_prd = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.name_ord = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.name_ord_en = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.size1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.qty1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.price1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.comment = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.id_cat = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.id_subcatprd = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.name_cat_en = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.name_cat_th = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.name_subcat_en = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.name_subcat_th = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ord_vat = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ord_vat_st = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.prd_t_id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.prd_t_en = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.prd_t_th = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btn_delOrd = New System.Windows.Forms.Button()
        Me.save_voidlist = New System.Windows.Forms.Button()
        Me.btn_voidOrd = New System.Windows.Forms.Button()
        Me.btn_up = New System.Windows.Forms.Button()
        Me.btn_drow = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ListView_food
        '
        Me.ListView_food.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListView_food.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.st, Me.id_ord, Me.id_prd, Me.id_con_prd, Me.name_ord, Me.name_ord_en, Me.size1, Me.qty1, Me.price1, Me.comment, Me.id_cat, Me.id_subcatprd, Me.name_cat_en, Me.name_cat_th, Me.name_subcat_en, Me.name_subcat_th, Me.ord_vat, Me.ord_vat_st, Me.prd_t_id, Me.prd_t_en, Me.prd_t_th})
        Me.ListView_food.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.ListView_food.FullRowSelect = True
        Me.ListView_food.GridLines = True
        Me.ListView_food.Location = New System.Drawing.Point(3, 1)
        Me.ListView_food.MultiSelect = False
        Me.ListView_food.Name = "ListView_food"
        Me.ListView_food.Size = New System.Drawing.Size(455, 461)
        Me.ListView_food.TabIndex = 4
        Me.ListView_food.UseCompatibleStateImageBehavior = False
        Me.ListView_food.View = System.Windows.Forms.View.Details
        '
        'st
        '
        Me.st.Text = "st"
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
        'name_ord
        '
        Me.name_ord.Text = "ชื่อรายการ"
        Me.name_ord.Width = 100
        '
        'name_ord_en
        '
        Me.name_ord_en.Text = "Name En"
        Me.name_ord_en.Width = 100
        '
        'size1
        '
        Me.size1.Text = "ขนาด"
        '
        'qty1
        '
        Me.qty1.Text = "จำนวน"
        '
        'price1
        '
        Me.price1.Text = "ราคา"
        '
        'comment
        '
        Me.comment.Text = "เพิ่มเติม"
        Me.comment.Width = 80
        '
        'id_cat
        '
        Me.id_cat.Text = "id_cat"
        Me.id_cat.Width = 0
        '
        'id_subcatprd
        '
        Me.id_subcatprd.Text = "id_subcatprd"
        Me.id_subcatprd.Width = 0
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
        'prd_t_id
        '
        Me.prd_t_id.Text = "prd_t_id"
        Me.prd_t_id.Width = 0
        '
        'prd_t_en
        '
        Me.prd_t_en.Text = "prd_t_en"
        Me.prd_t_en.Width = 0
        '
        'prd_t_th
        '
        Me.prd_t_th.Text = "prd_t_th"
        Me.prd_t_th.Width = 0
        '
        'btn_delOrd
        '
        Me.btn_delOrd.BackColor = System.Drawing.Color.Transparent
        Me.btn_delOrd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_delOrd.Enabled = False
        Me.btn_delOrd.FlatAppearance.BorderSize = 0
        Me.btn_delOrd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_delOrd.Image = Global.BeecomePOS.My.Resources.Resources.arrow_curve_180
        Me.btn_delOrd.Location = New System.Drawing.Point(464, 136)
        Me.btn_delOrd.Name = "btn_delOrd"
        Me.btn_delOrd.Size = New System.Drawing.Size(75, 47)
        Me.btn_delOrd.TabIndex = 13
        Me.btn_delOrd.Text = "คืนค่า"
        Me.btn_delOrd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_delOrd.UseVisualStyleBackColor = False
        '
        'save_voidlist
        '
        Me.save_voidlist.BackColor = System.Drawing.Color.Transparent
        Me.save_voidlist.Cursor = System.Windows.Forms.Cursors.Hand
        Me.save_voidlist.Enabled = False
        Me.save_voidlist.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.save_voidlist.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.save_voidlist.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.save_voidlist.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.save_voidlist.ForeColor = System.Drawing.Color.Black
        Me.save_voidlist.Image = Global.BeecomePOS.My.Resources.Resources.save_16
        Me.save_voidlist.Location = New System.Drawing.Point(464, 4)
        Me.save_voidlist.Name = "save_voidlist"
        Me.save_voidlist.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.save_voidlist.Size = New System.Drawing.Size(75, 57)
        Me.save_voidlist.TabIndex = 12
        Me.save_voidlist.Text = "Save"
        Me.save_voidlist.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.save_voidlist.UseVisualStyleBackColor = False
        '
        'btn_voidOrd
        '
        Me.btn_voidOrd.BackColor = System.Drawing.Color.Transparent
        Me.btn_voidOrd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_voidOrd.Enabled = False
        Me.btn_voidOrd.FlatAppearance.BorderSize = 0
        Me.btn_voidOrd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_voidOrd.Image = Global.BeecomePOS.My.Resources.Resources.arrow_curve
        Me.btn_voidOrd.Location = New System.Drawing.Point(464, 77)
        Me.btn_voidOrd.Name = "btn_voidOrd"
        Me.btn_voidOrd.Size = New System.Drawing.Size(75, 52)
        Me.btn_voidOrd.TabIndex = 11
        Me.btn_voidOrd.Text = "ลบ"
        Me.btn_voidOrd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_voidOrd.UseVisualStyleBackColor = False
        '
        'btn_up
        '
        Me.btn_up.BackgroundImage = Global.BeecomePOS.My.Resources.Resources.btn_up
        Me.btn_up.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_up.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_up.FlatAppearance.BorderSize = 0
        Me.btn_up.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_up.Location = New System.Drawing.Point(475, 335)
        Me.btn_up.Name = "btn_up"
        Me.btn_up.Size = New System.Drawing.Size(54, 54)
        Me.btn_up.TabIndex = 14
        Me.btn_up.UseVisualStyleBackColor = True
        '
        'btn_drow
        '
        Me.btn_drow.BackgroundImage = Global.BeecomePOS.My.Resources.Resources.btn_drow
        Me.btn_drow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_drow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_drow.FlatAppearance.BorderSize = 0
        Me.btn_drow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_drow.Location = New System.Drawing.Point(475, 399)
        Me.btn_drow.Name = "btn_drow"
        Me.btn_drow.Size = New System.Drawing.Size(53, 54)
        Me.btn_drow.TabIndex = 15
        Me.btn_drow.UseVisualStyleBackColor = True
        '
        'home_cancel_order
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(551, 462)
        Me.Controls.Add(Me.btn_up)
        Me.Controls.Add(Me.btn_drow)
        Me.Controls.Add(Me.btn_delOrd)
        Me.Controls.Add(Me.save_voidlist)
        Me.Controls.Add(Me.btn_voidOrd)
        Me.Controls.Add(Me.ListView_food)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "home_cancel_order"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Void Order - ยกเลิกรายการสินค้า"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListView_food As System.Windows.Forms.ListView
    Friend WithEvents st As System.Windows.Forms.ColumnHeader
    Friend WithEvents id_ord As System.Windows.Forms.ColumnHeader
    Friend WithEvents id_prd As System.Windows.Forms.ColumnHeader
    Friend WithEvents id_con_prd As System.Windows.Forms.ColumnHeader
    Friend WithEvents name_ord As System.Windows.Forms.ColumnHeader
    Friend WithEvents size1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents qty1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents price1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents comment As System.Windows.Forms.ColumnHeader
    Friend WithEvents id_cat As System.Windows.Forms.ColumnHeader
    Friend WithEvents id_subcatprd As System.Windows.Forms.ColumnHeader
    Friend WithEvents name_cat_en As System.Windows.Forms.ColumnHeader
    Friend WithEvents name_cat_th As System.Windows.Forms.ColumnHeader
    Friend WithEvents name_subcat_en As System.Windows.Forms.ColumnHeader
    Friend WithEvents name_subcat_th As System.Windows.Forms.ColumnHeader
    Friend WithEvents ord_vat As System.Windows.Forms.ColumnHeader
    Friend WithEvents ord_vat_st As System.Windows.Forms.ColumnHeader
    Friend WithEvents btn_delOrd As System.Windows.Forms.Button
    Friend WithEvents save_voidlist As System.Windows.Forms.Button
    Friend WithEvents btn_voidOrd As System.Windows.Forms.Button
    Friend WithEvents btn_up As System.Windows.Forms.Button
    Friend WithEvents btn_drow As System.Windows.Forms.Button
    Friend WithEvents prd_t_id As System.Windows.Forms.ColumnHeader
    Friend WithEvents prd_t_en As System.Windows.Forms.ColumnHeader
    Friend WithEvents prd_t_th As System.Windows.Forms.ColumnHeader
    Friend WithEvents name_ord_en As System.Windows.Forms.ColumnHeader
End Class
