<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class showPay
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(showPay))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_ton = New System.Windows.Forms.TextBox()
        Me.btn_close = New System.Windows.Forms.Button()
        Me.btn_print = New System.Windows.Forms.Button()
        Me.txt_total = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_recript = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.shv = New System.Windows.Forms.RadioButton()
        Me.shv_not = New System.Windows.Forms.RadioButton()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker2 = New System.ComponentModel.BackgroundWorker()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(156, 232)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 55)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "ทอน"
        '
        'txt_ton
        '
        Me.txt_ton.BackColor = System.Drawing.Color.Yellow
        Me.txt_ton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ton.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_ton.Location = New System.Drawing.Point(15, 284)
        Me.txt_ton.MaxLength = 20
        Me.txt_ton.Name = "txt_ton"
        Me.txt_ton.ReadOnly = True
        Me.txt_ton.Size = New System.Drawing.Size(392, 80)
        Me.txt_ton.TabIndex = 3
        Me.txt_ton.Text = "0.00"
        Me.txt_ton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btn_close
        '
        Me.btn_close.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_close.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_close.Image = Global.BeecomePOS.My.Resources.Resources.delete_32
        Me.btn_close.Location = New System.Drawing.Point(297, 241)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.Size = New System.Drawing.Size(109, 39)
        Me.btn_close.TabIndex = 9
        Me.btn_close.Text = "Close"
        Me.btn_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_close.UseVisualStyleBackColor = True
        Me.btn_close.Visible = False
        '
        'btn_print
        '
        Me.btn_print.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_print.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_print.Image = Global.BeecomePOS.My.Resources.Resources.print_32
        Me.btn_print.Location = New System.Drawing.Point(16, 398)
        Me.btn_print.Name = "btn_print"
        Me.btn_print.Size = New System.Drawing.Size(391, 59)
        Me.btn_print.TabIndex = 2
        Me.btn_print.Text = "พิมพ์บิล"
        Me.btn_print.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_print.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_print.UseVisualStyleBackColor = True
        '
        'txt_total
        '
        Me.txt_total.BackColor = System.Drawing.Color.Black
        Me.txt_total.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_total.ForeColor = System.Drawing.Color.Lime
        Me.txt_total.Location = New System.Drawing.Point(15, 63)
        Me.txt_total.Name = "txt_total"
        Me.txt_total.ReadOnly = True
        Me.txt_total.Size = New System.Drawing.Size(391, 62)
        Me.txt_total.TabIndex = 5
        Me.txt_total.Text = "0.00"
        Me.txt_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(159, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 42)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Total"
        '
        'txt_recript
        '
        Me.txt_recript.BackColor = System.Drawing.Color.White
        Me.txt_recript.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_recript.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_recript.ForeColor = System.Drawing.Color.Black
        Me.txt_recript.Location = New System.Drawing.Point(16, 173)
        Me.txt_recript.Name = "txt_recript"
        Me.txt_recript.ReadOnly = True
        Me.txt_recript.Size = New System.Drawing.Size(391, 62)
        Me.txt_recript.TabIndex = 4
        Me.txt_recript.Text = "0.00"
        Me.txt_recript.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.Location = New System.Drawing.Point(159, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 42)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "รับมา"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(10, 474)
        Me.Panel1.TabIndex = 8
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.Location = New System.Drawing.Point(414, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(10, 474)
        Me.Panel2.TabIndex = 9
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Black
        Me.Panel3.Location = New System.Drawing.Point(7, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(409, 10)
        Me.Panel3.TabIndex = 10
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Black
        Me.Panel4.Location = New System.Drawing.Point(7, 463)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(417, 11)
        Me.Panel4.TabIndex = 11
        '
        'shv
        '
        Me.shv.AutoSize = True
        Me.shv.Checked = True
        Me.shv.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.shv.Location = New System.Drawing.Point(88, 368)
        Me.shv.Name = "shv"
        Me.shv.Size = New System.Drawing.Size(117, 29)
        Me.shv.TabIndex = 0
        Me.shv.TabStop = True
        Me.shv.Text = "แสดง vat"
        Me.shv.UseVisualStyleBackColor = True
        '
        'shv_not
        '
        Me.shv_not.AutoSize = True
        Me.shv_not.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.shv_not.Location = New System.Drawing.Point(231, 369)
        Me.shv_not.Name = "shv_not"
        Me.shv_not.Size = New System.Drawing.Size(141, 29)
        Me.shv_not.TabIndex = 1
        Me.shv_not.Text = "ไม่แสดง vat"
        Me.shv_not.UseVisualStyleBackColor = True
        '
        'BackgroundWorker1
        '
        '
        'BackgroundWorker2
        '
        '
        'showPay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(424, 474)
        Me.ControlBox = False
        Me.Controls.Add(Me.shv_not)
        Me.Controls.Add(Me.shv)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txt_recript)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_total)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btn_close)
        Me.Controls.Add(Me.btn_print)
        Me.Controls.Add(Me.txt_ton)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "showPay"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Payment Alert"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_ton As System.Windows.Forms.TextBox
    Friend WithEvents btn_print As System.Windows.Forms.Button
    Friend WithEvents btn_close As System.Windows.Forms.Button
    Friend WithEvents txt_total As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_recript As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents shv As System.Windows.Forms.RadioButton
    Friend WithEvents shv_not As System.Windows.Forms.RadioButton
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorker2 As System.ComponentModel.BackgroundWorker
End Class
