<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class opentable_prdother
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
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"1", "#885000234 บุรี่สายฝน", "5", "1,000", "10/10/2557 12:00:00"}, -1)
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"2", "##885000234  น้ำผลไม้กระป็อง", "3", "390", "1/10/2557 09:45:00"}, -1)
        Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"3", "#885000234 กระดาษทิชชู", "1", "250", "2/10/2557 10:00:00"}, -1)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(opentable_prdother))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btn_up = New System.Windows.Forms.Button()
        Me.btn_cal_resv = New System.Windows.Forms.Button()
        Me.btn_drow = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btn_sel_reser = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.btn_up)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btn_drow)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(844, 66)
        Me.Panel1.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(291, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(166, 25)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "รายการสินค้าอื่นๆ"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(561, 19)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(229, 31)
        Me.TextBox1.TabIndex = 14
        Me.TextBox1.Text = "Search...."
        '
        'Button1
        '
        Me.Button1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.Image = Global.BeecomePOS.My.Resources.Resources.search_161
        Me.Button1.Location = New System.Drawing.Point(796, 17)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(45, 34)
        Me.Button1.TabIndex = 15
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.Panel2.Controls.Add(Me.btn_sel_reser)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.btn_cal_resv)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(751, 66)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(93, 422)
        Me.Panel2.TabIndex = 10
        '
        'btn_up
        '
        Me.btn_up.BackgroundImage = Global.BeecomePOS.My.Resources.Resources.btn_up
        Me.btn_up.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_up.FlatAppearance.BorderSize = 0
        Me.btn_up.Location = New System.Drawing.Point(65, 12)
        Me.btn_up.Name = "btn_up"
        Me.btn_up.Size = New System.Drawing.Size(46, 45)
        Me.btn_up.TabIndex = 13
        Me.btn_up.UseVisualStyleBackColor = True
        '
        'btn_cal_resv
        '
        Me.btn_cal_resv.BackColor = System.Drawing.Color.Red
        Me.btn_cal_resv.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_cal_resv.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_cal_resv.FlatAppearance.BorderSize = 0
        Me.btn_cal_resv.Image = Global.BeecomePOS.My.Resources.Resources.cross
        Me.btn_cal_resv.Location = New System.Drawing.Point(8, 6)
        Me.btn_cal_resv.Name = "btn_cal_resv"
        Me.btn_cal_resv.Size = New System.Drawing.Size(71, 55)
        Me.btn_cal_resv.TabIndex = 15
        Me.btn_cal_resv.UseVisualStyleBackColor = False
        '
        'btn_drow
        '
        Me.btn_drow.BackgroundImage = Global.BeecomePOS.My.Resources.Resources.btn_drow
        Me.btn_drow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_drow.FlatAppearance.BorderSize = 0
        Me.btn_drow.Location = New System.Drawing.Point(11, 12)
        Me.btn_drow.Name = "btn_drow"
        Me.btn_drow.Size = New System.Drawing.Size(47, 45)
        Me.btn_drow.TabIndex = 14
        Me.btn_drow.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListView1.CheckBoxes = True
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.ListView1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        ListViewItem1.StateImageIndex = 0
        ListViewItem2.StateImageIndex = 0
        ListViewItem3.StateImageIndex = 0
        Me.ListView1.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2, ListViewItem3})
        Me.ListView1.Location = New System.Drawing.Point(0, 66)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(751, 422)
        Me.ListView1.TabIndex = 11
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ลำดับ"
        Me.ColumnHeader1.Width = 49
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "หัวเรื่อง"
        Me.ColumnHeader2.Width = 292
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "จำนวน"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader3.Width = 79
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "ราคา"
        Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader4.Width = 108
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "วันเวลา"
        Me.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader5.Width = 222
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Button2.Location = New System.Drawing.Point(8, 353)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 57)
        Me.Button2.TabIndex = 17
        Me.Button2.Text = "Enter"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'btn_sel_reser
        '
        Me.btn_sel_reser.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_sel_reser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_sel_reser.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_sel_reser.FlatAppearance.BorderSize = 0
        Me.btn_sel_reser.Image = Global.BeecomePOS.My.Resources.Resources.btn_ok
        Me.btn_sel_reser.Location = New System.Drawing.Point(8, 67)
        Me.btn_sel_reser.Name = "btn_sel_reser"
        Me.btn_sel_reser.Size = New System.Drawing.Size(71, 63)
        Me.btn_sel_reser.TabIndex = 18
        Me.btn_sel_reser.UseVisualStyleBackColor = True
        '
        'opentable_prdother
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(844, 488)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "opentable_prdother"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "หน้าจอสินค้าอื่นๆ"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btn_up As System.Windows.Forms.Button
    Friend WithEvents btn_cal_resv As System.Windows.Forms.Button
    Friend WithEvents btn_drow As System.Windows.Forms.Button
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btn_sel_reser As System.Windows.Forms.Button
End Class
