<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_addPrdCon
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Admin_addPrdCon))
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.ComboBox_Unit = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtBox_priceCon = New System.Windows.Forms.TextBox()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btn_search_indre = New System.Windows.Forms.Button()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.amount = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.barcode = New System.Windows.Forms.TextBox()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel11.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.ComboBox_Unit)
        Me.Panel11.Controls.Add(Me.Label14)
        Me.Panel11.Controls.Add(Me.Label15)
        Me.Panel11.Controls.Add(Me.txtBox_priceCon)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel11.Location = New System.Drawing.Point(0, 0)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(288, 71)
        Me.Panel11.TabIndex = 21
        '
        'ComboBox_Unit
        '
        Me.ComboBox_Unit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox_Unit.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ComboBox_Unit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ComboBox_Unit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Unit.FormattingEnabled = True
        Me.ComboBox_Unit.Location = New System.Drawing.Point(91, 11)
        Me.ComboBox_Unit.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBox_Unit.Name = "ComboBox_Unit"
        Me.ComboBox_Unit.Size = New System.Drawing.Size(184, 21)
        Me.ComboBox_Unit.TabIndex = 13
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(7, 12)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(67, 13)
        Me.Label14.TabIndex = 10
        Me.Label14.Text = "Size Product"
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(7, 40)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(55, 13)
        Me.Label15.TabIndex = 11
        Me.Label15.Text = "Price Sale"
        '
        'txtBox_priceCon
        '
        Me.txtBox_priceCon.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBox_priceCon.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtBox_priceCon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBox_priceCon.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtBox_priceCon.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtBox_priceCon.Location = New System.Drawing.Point(91, 40)
        Me.txtBox_priceCon.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBox_priceCon.MaxLength = 9
        Me.txtBox_priceCon.Name = "txtBox_priceCon"
        Me.txtBox_priceCon.Size = New System.Drawing.Size(184, 22)
        Me.txtBox_priceCon.TabIndex = 12
        Me.txtBox_priceCon.Text = "0"
        Me.txtBox_priceCon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel12
        '
        Me.Panel12.Controls.Add(Me.CheckedListBox1)
        Me.Panel12.Controls.Add(Me.Label13)
        Me.Panel12.Controls.Add(Me.btn_search_indre)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel12.Location = New System.Drawing.Point(0, 71)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(288, 197)
        Me.Panel12.TabIndex = 23
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckedListBox1.BackColor = System.Drawing.Color.White
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Location = New System.Drawing.Point(85, 7)
        Me.CheckedListBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(184, 184)
        Me.CheckedListBox1.TabIndex = 14
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(15, 5)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(54, 13)
        Me.Label13.TabIndex = 9
        Me.Label13.Text = "Ingredient"
        '
        'btn_search_indre
        '
        Me.btn_search_indre.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_search_indre.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_search_indre.Image = Global.BeecomePOS.My.Resources.Resources.search_161
        Me.btn_search_indre.Location = New System.Drawing.Point(44, 21)
        Me.btn_search_indre.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_search_indre.Name = "btn_search_indre"
        Me.btn_search_indre.Size = New System.Drawing.Size(34, 30)
        Me.btn_search_indre.TabIndex = 15
        Me.btn_search_indre.UseVisualStyleBackColor = True
        '
        'Panel13
        '
        Me.Panel13.Controls.Add(Me.Label2)
        Me.Panel13.Controls.Add(Me.amount)
        Me.Panel13.Controls.Add(Me.Label1)
        Me.Panel13.Controls.Add(Me.barcode)
        Me.Panel13.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel13.Location = New System.Drawing.Point(0, 268)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(288, 72)
        Me.Panel13.TabIndex = 24
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 47)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Amount"
        Me.Label2.Visible = False
        '
        'amount
        '
        Me.amount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.amount.BackColor = System.Drawing.Color.Yellow
        Me.amount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.amount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.amount.Location = New System.Drawing.Point(91, 43)
        Me.amount.Margin = New System.Windows.Forms.Padding(4)
        Me.amount.MaxLength = 5
        Me.amount.Name = "amount"
        Me.amount.Size = New System.Drawing.Size(184, 22)
        Me.amount.TabIndex = 16
        Me.amount.Text = "0"
        Me.amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.amount.Visible = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 17)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Barcode"
        '
        'barcode
        '
        Me.barcode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.barcode.BackColor = System.Drawing.Color.Yellow
        Me.barcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.barcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.barcode.Location = New System.Drawing.Point(91, 13)
        Me.barcode.Margin = New System.Windows.Forms.Padding(4)
        Me.barcode.MaxLength = 25
        Me.barcode.Name = "barcode"
        Me.barcode.Size = New System.Drawing.Size(184, 22)
        Me.barcode.TabIndex = 14
        Me.barcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel14
        '
        Me.Panel14.Controls.Add(Me.Button1)
        Me.Panel14.Controls.Add(Me.Button2)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel14.Location = New System.Drawing.Point(0, 340)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(288, 36)
        Me.Panel14.TabIndex = 25
        '
        'Button1
        '
        Me.Button1.Image = Global.BeecomePOS.My.Resources.Resources.save_16
        Me.Button1.Location = New System.Drawing.Point(58, 1)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 33)
        Me.Button1.TabIndex = 16
        Me.Button1.Text = "Add"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Image = Global.BeecomePOS.My.Resources.Resources.trash_16
        Me.Button2.Location = New System.Drawing.Point(139, 1)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 33)
        Me.Button2.TabIndex = 17
        Me.Button2.Text = "Clear"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Admin_addPrdCon
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(288, 378)
        Me.Controls.Add(Me.Panel14)
        Me.Controls.Add(Me.Panel13)
        Me.Controls.Add(Me.Panel12)
        Me.Controls.Add(Me.Panel11)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Admin_addPrdCon"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Condition Price"
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.Panel12.ResumeLayout(False)
        Me.Panel12.PerformLayout()
        Me.Panel13.ResumeLayout(False)
        Me.Panel13.PerformLayout()
        Me.Panel14.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents ComboBox_Unit As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtBox_priceCon As System.Windows.Forms.TextBox
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents CheckedListBox1 As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btn_search_indre As System.Windows.Forms.Button
    Friend WithEvents Panel13 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents barcode As System.Windows.Forms.TextBox
    Friend WithEvents Panel14 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents amount As System.Windows.Forms.TextBox
End Class
