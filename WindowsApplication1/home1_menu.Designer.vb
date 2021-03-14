<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class home1_menu
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
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_sendagain = New System.Windows.Forms.Button()
        Me.btn_void = New System.Windows.Forms.Button()
        Me.btn_jointb = New System.Windows.Forms.Button()
        Me.btn_supptb = New System.Windows.Forms.Button()
        Me.btn_changTb = New System.Windows.Forms.Button()
        Me.btn_cancel_order = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_sendagain)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_void)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_jointb)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_supptb)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_changTb)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_cancel_order)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(385, 252)
        Me.FlowLayoutPanel1.TabIndex = 31
        '
        'btn_sendagain
        '
        Me.btn_sendagain.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_sendagain.BackColor = System.Drawing.Color.Lime
        Me.btn_sendagain.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_sendagain.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btn_sendagain.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.btn_sendagain.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btn_sendagain.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_sendagain.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_sendagain.ForeColor = System.Drawing.Color.Black
        Me.btn_sendagain.Image = Global.BeecomePOS.My.Resources.Resources.printer
        Me.btn_sendagain.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_sendagain.Location = New System.Drawing.Point(3, 3)
        Me.btn_sendagain.Name = "btn_sendagain"
        Me.btn_sendagain.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btn_sendagain.Size = New System.Drawing.Size(194, 76)
        Me.btn_sendagain.TabIndex = 28
        Me.btn_sendagain.Text = "พิมพ์ส่งครัวใหม่"
        Me.btn_sendagain.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_sendagain.UseVisualStyleBackColor = False
        '
        'btn_void
        '
        Me.btn_void.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_void.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btn_void.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_void.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btn_void.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.btn_void.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btn_void.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_void.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_void.ForeColor = System.Drawing.Color.Black
        Me.btn_void.Image = Global.BeecomePOS.My.Resources.Resources.cross
        Me.btn_void.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_void.Location = New System.Drawing.Point(203, 3)
        Me.btn_void.Name = "btn_void"
        Me.btn_void.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btn_void.Size = New System.Drawing.Size(178, 76)
        Me.btn_void.TabIndex = 9
        Me.btn_void.Text = "ยกเลิกโต๊ะ"
        Me.btn_void.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_void.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_void.UseVisualStyleBackColor = False
        '
        'btn_jointb
        '
        Me.btn_jointb.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_jointb.BackColor = System.Drawing.Color.Cyan
        Me.btn_jointb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_jointb.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btn_jointb.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.btn_jointb.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btn_jointb.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_jointb.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_jointb.ForeColor = System.Drawing.Color.Black
        Me.btn_jointb.Image = Global.BeecomePOS.My.Resources.Resources.arrow_circle_double_135
        Me.btn_jointb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_jointb.Location = New System.Drawing.Point(3, 85)
        Me.btn_jointb.Name = "btn_jointb"
        Me.btn_jointb.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btn_jointb.Size = New System.Drawing.Size(194, 76)
        Me.btn_jointb.TabIndex = 27
        Me.btn_jointb.Text = "รวมโต๊ะ"
        Me.btn_jointb.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_jointb.UseVisualStyleBackColor = True
        '
        'btn_supptb
        '
        Me.btn_supptb.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_supptb.BackColor = System.Drawing.Color.Yellow
        Me.btn_supptb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_supptb.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btn_supptb.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.btn_supptb.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btn_supptb.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_supptb.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_supptb.ForeColor = System.Drawing.Color.Black
        Me.btn_supptb.Image = Global.BeecomePOS.My.Resources.Resources.Left
        Me.btn_supptb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_supptb.Location = New System.Drawing.Point(203, 85)
        Me.btn_supptb.Name = "btn_supptb"
        Me.btn_supptb.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btn_supptb.Size = New System.Drawing.Size(178, 76)
        Me.btn_supptb.TabIndex = 29
        Me.btn_supptb.Text = "แยกโต๊ะ"
        Me.btn_supptb.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_supptb.UseVisualStyleBackColor = True
        '
        'btn_changTb
        '
        Me.btn_changTb.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_changTb.BackColor = System.Drawing.Color.Magenta
        Me.btn_changTb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_changTb.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btn_changTb.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.btn_changTb.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btn_changTb.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_changTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_changTb.ForeColor = System.Drawing.Color.Black
        Me.btn_changTb.Image = Global.BeecomePOS.My.Resources.Resources.arrow_curve
        Me.btn_changTb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_changTb.Location = New System.Drawing.Point(3, 167)
        Me.btn_changTb.Name = "btn_changTb"
        Me.btn_changTb.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btn_changTb.Size = New System.Drawing.Size(194, 76)
        Me.btn_changTb.TabIndex = 7
        Me.btn_changTb.Text = "ย้ายโต๊ะ/Move"
        Me.btn_changTb.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_changTb.UseVisualStyleBackColor = True
        '
        'btn_cancel_order
        '
        Me.btn_cancel_order.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cancel_order.BackColor = System.Drawing.Color.Red
        Me.btn_cancel_order.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_cancel_order.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.btn_cancel_order.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btn_cancel_order.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_cancel_order.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_cancel_order.ForeColor = System.Drawing.Color.White
        Me.btn_cancel_order.Image = Global.BeecomePOS.My.Resources.Resources.Doc_Del
        Me.btn_cancel_order.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_cancel_order.Location = New System.Drawing.Point(203, 167)
        Me.btn_cancel_order.Name = "btn_cancel_order"
        Me.btn_cancel_order.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btn_cancel_order.Size = New System.Drawing.Size(178, 76)
        Me.btn_cancel_order.TabIndex = 30
        Me.btn_cancel_order.Text = "ยกเลิกรายการ"
        Me.btn_cancel_order.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_cancel_order.UseVisualStyleBackColor = True
        '
        'home1_menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(385, 252)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "home1_menu"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu-เมนู"
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btn_sendagain As System.Windows.Forms.Button
    Friend WithEvents btn_void As System.Windows.Forms.Button
    Friend WithEvents btn_jointb As System.Windows.Forms.Button
    Friend WithEvents btn_supptb As System.Windows.Forms.Button
    Friend WithEvents btn_changTb As System.Windows.Forms.Button
    Friend WithEvents btn_cancel_order As System.Windows.Forms.Button
End Class
