<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class opentable_add_other
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
        Me.btn_add = New System.Windows.Forms.Button()
        Me.btn_close = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ComboBox_Prd_Type = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBox_Group2 = New System.Windows.Forms.ComboBox()
        Me.textbox_remark_prd = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ComboBox_Group1 = New System.Windows.Forms.ComboBox()
        Me.textbox_price_prd = New System.Windows.Forms.TextBox()
        Me.textbox_qty_prd = New System.Windows.Forms.TextBox()
        Me.textbox_name_prd = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.textbox_vat_prd = New System.Windows.Forms.TextBox()
        Me.vat_add = New System.Windows.Forms.RadioButton()
        Me.vat_include = New System.Windows.Forms.RadioButton()
        Me.vat_none = New System.Windows.Forms.RadioButton()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.textbox_name_prd_en = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_add
        '
        Me.btn_add.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_add.Image = Global.BeecomePOS.My.Resources.Resources.Add
        Me.btn_add.Location = New System.Drawing.Point(88, 399)
        Me.btn_add.Name = "btn_add"
        Me.btn_add.Size = New System.Drawing.Size(161, 45)
        Me.btn_add.TabIndex = 9
        Me.btn_add.Text = "Add Order"
        Me.btn_add.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_add.UseVisualStyleBackColor = True
        '
        'btn_close
        '
        Me.btn_close.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_close.Image = Global.BeecomePOS.My.Resources.Resources.delete_16
        Me.btn_close.Location = New System.Drawing.Point(259, 399)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.Size = New System.Drawing.Size(148, 45)
        Me.btn_close.TabIndex = 10
        Me.btn_close.Text = "Cancel"
        Me.btn_close.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_close.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.textbox_name_prd_en)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.ComboBox_Prd_Type)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.ComboBox_Group2)
        Me.GroupBox1.Controls.Add(Me.textbox_remark_prd)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.ComboBox_Group1)
        Me.GroupBox1.Controls.Add(Me.textbox_price_prd)
        Me.GroupBox1.Controls.Add(Me.textbox_qty_prd)
        Me.GroupBox1.Controls.Add(Me.textbox_name_prd)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(13, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(450, 310)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detail Product"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.Red
        Me.Label14.Location = New System.Drawing.Point(400, 264)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(15, 20)
        Me.Label14.TabIndex = 30
        Me.Label14.Text = "*"
        '
        'ComboBox_Prd_Type
        '
        Me.ComboBox_Prd_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Prd_Type.FormattingEnabled = True
        Me.ComboBox_Prd_Type.Location = New System.Drawing.Point(129, 267)
        Me.ComboBox_Prd_Type.Name = "ComboBox_Prd_Type"
        Me.ComboBox_Prd_Type.Size = New System.Drawing.Size(265, 28)
        Me.ComboBox_Prd_Type.TabIndex = 29
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(16, 266)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(90, 20)
        Me.Label13.TabIndex = 28
        Me.Label13.Text = "ประเภทสินค้า"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(18, 69)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(93, 20)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "กลุ่มย่อยสินค้า"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(369, 103)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 20)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "*"
        '
        'ComboBox_Group2
        '
        Me.ComboBox_Group2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Group2.FormattingEnabled = True
        Me.ComboBox_Group2.Location = New System.Drawing.Point(129, 64)
        Me.ComboBox_Group2.Name = "ComboBox_Group2"
        Me.ComboBox_Group2.Size = New System.Drawing.Size(286, 28)
        Me.ComboBox_Group2.TabIndex = 25
        '
        'textbox_remark_prd
        '
        Me.textbox_remark_prd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.textbox_remark_prd.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.textbox_remark_prd.Location = New System.Drawing.Point(129, 232)
        Me.textbox_remark_prd.MaxLength = 300
        Me.textbox_remark_prd.Multiline = True
        Me.textbox_remark_prd.Name = "textbox_remark_prd"
        Me.textbox_remark_prd.Size = New System.Drawing.Size(286, 29)
        Me.textbox_remark_prd.TabIndex = 24
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(16, 234)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(60, 20)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "เพิ่มเติม"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(348, 202)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(15, 20)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "*"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(326, 168)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(15, 20)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "*"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(419, 67)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(15, 20)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "*"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(416, 30)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(15, 20)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "*"
        '
        'ComboBox_Group1
        '
        Me.ComboBox_Group1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Group1.FormattingEnabled = True
        Me.ComboBox_Group1.Location = New System.Drawing.Point(129, 28)
        Me.ComboBox_Group1.Name = "ComboBox_Group1"
        Me.ComboBox_Group1.Size = New System.Drawing.Size(286, 28)
        Me.ComboBox_Group1.TabIndex = 3
        '
        'textbox_price_prd
        '
        Me.textbox_price_prd.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.textbox_price_prd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.textbox_price_prd.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.textbox_price_prd.Location = New System.Drawing.Point(129, 198)
        Me.textbox_price_prd.MaxLength = 15
        Me.textbox_price_prd.Name = "textbox_price_prd"
        Me.textbox_price_prd.Size = New System.Drawing.Size(217, 26)
        Me.textbox_price_prd.TabIndex = 2
        Me.textbox_price_prd.Text = "0.00"
        Me.textbox_price_prd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'textbox_qty_prd
        '
        Me.textbox_qty_prd.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.textbox_qty_prd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.textbox_qty_prd.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.textbox_qty_prd.Location = New System.Drawing.Point(129, 167)
        Me.textbox_qty_prd.MaxLength = 6
        Me.textbox_qty_prd.Name = "textbox_qty_prd"
        Me.textbox_qty_prd.Size = New System.Drawing.Size(191, 26)
        Me.textbox_qty_prd.TabIndex = 1
        Me.textbox_qty_prd.Text = "0"
        Me.textbox_qty_prd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'textbox_name_prd
        '
        Me.textbox_name_prd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.textbox_name_prd.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.textbox_name_prd.Location = New System.Drawing.Point(129, 99)
        Me.textbox_name_prd.MaxLength = 300
        Me.textbox_name_prd.Name = "textbox_name_prd"
        Me.textbox_name_prd.Size = New System.Drawing.Size(234, 26)
        Me.textbox_name_prd.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 204)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 20)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "ราคาต่อหน่วย"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 173)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 20)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "จำนวน"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 20)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "ชื่อสินค้า TH"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "เลือกกลุ่มสินค้า"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.textbox_vat_prd)
        Me.GroupBox2.Controls.Add(Me.vat_add)
        Me.GroupBox2.Controls.Add(Me.vat_include)
        Me.GroupBox2.Controls.Add(Me.vat_none)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(13, 329)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(450, 59)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Vat"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(80, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(21, 18)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "%"
        '
        'textbox_vat_prd
        '
        Me.textbox_vat_prd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.textbox_vat_prd.Location = New System.Drawing.Point(12, 24)
        Me.textbox_vat_prd.MaxLength = 2
        Me.textbox_vat_prd.Name = "textbox_vat_prd"
        Me.textbox_vat_prd.Size = New System.Drawing.Size(64, 24)
        Me.textbox_vat_prd.TabIndex = 5
        Me.textbox_vat_prd.Text = "7"
        Me.textbox_vat_prd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'vat_add
        '
        Me.vat_add.AutoSize = True
        Me.vat_add.Location = New System.Drawing.Point(295, 23)
        Me.vat_add.Name = "vat_add"
        Me.vat_add.Size = New System.Drawing.Size(51, 22)
        Me.vat_add.TabIndex = 8
        Me.vat_add.Text = "Add"
        Me.vat_add.UseVisualStyleBackColor = True
        '
        'vat_include
        '
        Me.vat_include.AutoSize = True
        Me.vat_include.Checked = True
        Me.vat_include.Location = New System.Drawing.Point(195, 25)
        Me.vat_include.Name = "vat_include"
        Me.vat_include.Size = New System.Drawing.Size(72, 22)
        Me.vat_include.TabIndex = 7
        Me.vat_include.TabStop = True
        Me.vat_include.Text = "Include"
        Me.vat_include.UseVisualStyleBackColor = True
        '
        'vat_none
        '
        Me.vat_none.AutoSize = True
        Me.vat_none.Location = New System.Drawing.Point(111, 25)
        Me.vat_none.Name = "vat_none"
        Me.vat_none.Size = New System.Drawing.Size(62, 22)
        Me.vat_none.TabIndex = 6
        Me.vat_none.Text = "None"
        Me.vat_none.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.Red
        Me.Label15.Location = New System.Drawing.Point(367, 135)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(15, 20)
        Me.Label15.TabIndex = 33
        Me.Label15.Text = "*"
        '
        'textbox_name_prd_en
        '
        Me.textbox_name_prd_en.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.textbox_name_prd_en.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.textbox_name_prd_en.Location = New System.Drawing.Point(129, 132)
        Me.textbox_name_prd_en.MaxLength = 300
        Me.textbox_name_prd_en.Name = "textbox_name_prd_en"
        Me.textbox_name_prd_en.Size = New System.Drawing.Size(234, 26)
        Me.textbox_name_prd_en.TabIndex = 31
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(16, 138)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(85, 20)
        Me.Label16.TabIndex = 32
        Me.Label16.Text = "ชื่อสินค้า EN"
        '
        'opentable_add_other
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(475, 464)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btn_close)
        Me.Controls.Add(Me.btn_add)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "opentable_add_other"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Order Other"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_add As System.Windows.Forms.Button
    Friend WithEvents btn_close As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents textbox_price_prd As System.Windows.Forms.TextBox
    Friend WithEvents textbox_qty_prd As System.Windows.Forms.TextBox
    Friend WithEvents textbox_name_prd As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents textbox_vat_prd As System.Windows.Forms.TextBox
    Friend WithEvents vat_add As System.Windows.Forms.RadioButton
    Friend WithEvents vat_include As System.Windows.Forms.RadioButton
    Friend WithEvents vat_none As System.Windows.Forms.RadioButton
    Friend WithEvents ComboBox_Group1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents textbox_remark_prd As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBox_Group2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ComboBox_Prd_Type As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents textbox_name_prd_en As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
End Class
