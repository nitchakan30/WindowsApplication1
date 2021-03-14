<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class showpay_alert
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
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txt_recript = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_total = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_ton = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_close = New System.Windows.Forms.Button()
        Me.btn_confirm = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Black
        Me.Panel4.Location = New System.Drawing.Point(6, 436)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(417, 11)
        Me.Panel4.TabIndex = 26
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Black
        Me.Panel3.Location = New System.Drawing.Point(6, 1)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(409, 10)
        Me.Panel3.TabIndex = 25
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.Location = New System.Drawing.Point(413, 1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(10, 474)
        Me.Panel2.TabIndex = 24
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(-1, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(10, 474)
        Me.Panel1.TabIndex = 21
        '
        'txt_recript
        '
        Me.txt_recript.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txt_recript.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_recript.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_recript.ForeColor = System.Drawing.Color.Black
        Me.txt_recript.Location = New System.Drawing.Point(15, 174)
        Me.txt_recript.Name = "txt_recript"
        Me.txt_recript.ReadOnly = True
        Me.txt_recript.Size = New System.Drawing.Size(391, 62)
        Me.txt_recript.TabIndex = 17
        Me.txt_recript.Text = "0.00"
        Me.txt_recript.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.Location = New System.Drawing.Point(136, 129)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(153, 42)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "รับเงินมา"
        '
        'txt_total
        '
        Me.txt_total.BackColor = System.Drawing.Color.Black
        Me.txt_total.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_total.ForeColor = System.Drawing.Color.Lime
        Me.txt_total.Location = New System.Drawing.Point(14, 64)
        Me.txt_total.Name = "txt_total"
        Me.txt_total.ReadOnly = True
        Me.txt_total.Size = New System.Drawing.Size(391, 62)
        Me.txt_total.TabIndex = 18
        Me.txt_total.Text = "0.00"
        Me.txt_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(105, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(217, 42)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "ยอดรวมชำระ"
        '
        'txt_ton
        '
        Me.txt_ton.BackColor = System.Drawing.Color.Yellow
        Me.txt_ton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ton.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_ton.Location = New System.Drawing.Point(14, 285)
        Me.txt_ton.MaxLength = 20
        Me.txt_ton.Name = "txt_ton"
        Me.txt_ton.ReadOnly = True
        Me.txt_ton.Size = New System.Drawing.Size(392, 80)
        Me.txt_ton.TabIndex = 16
        Me.txt_ton.Text = "0.00"
        Me.txt_ton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(155, 233)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 55)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "ทอน"
        '
        'btn_close
        '
        Me.btn_close.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_close.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_close.Image = Global.BeecomePOS.My.Resources.Resources.delete_32
        Me.btn_close.Location = New System.Drawing.Point(231, 371)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.Size = New System.Drawing.Size(175, 59)
        Me.btn_close.TabIndex = 23
        Me.btn_close.Text = "ยกเลิก"
        Me.btn_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_close.UseVisualStyleBackColor = True
        '
        'btn_confirm
        '
        Me.btn_confirm.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_confirm.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_confirm.Image = Global.BeecomePOS.My.Resources.Resources.m_walking
        Me.btn_confirm.Location = New System.Drawing.Point(16, 371)
        Me.btn_confirm.Name = "btn_confirm"
        Me.btn_confirm.Size = New System.Drawing.Size(209, 59)
        Me.btn_confirm.TabIndex = 15
        Me.btn_confirm.Text = "ยืนยัน"
        Me.btn_confirm.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_confirm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_confirm.UseVisualStyleBackColor = True
        '
        'showpay_alert
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(420, 449)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txt_recript)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_total)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btn_close)
        Me.Controls.Add(Me.btn_confirm)
        Me.Controls.Add(Me.txt_ton)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "showpay_alert"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "showpay_alert"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txt_recript As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_total As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_close As System.Windows.Forms.Button
    Friend WithEvents btn_confirm As System.Windows.Forms.Button
    Friend WithEvents txt_ton As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
