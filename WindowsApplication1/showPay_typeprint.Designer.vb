<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class showpay_typeprint
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
        Me.btn_vat = New System.Windows.Forms.Button()
        Me.btn_novat = New System.Windows.Forms.Button()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker2 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker3 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker4 = New System.ComponentModel.BackgroundWorker()
        Me.SuspendLayout()
        '
        'btn_vat
        '
        Me.btn_vat.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_vat.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_vat.Image = Global.BeecomePOS.My.Resources.Resources.print_32
        Me.btn_vat.Location = New System.Drawing.Point(4, 12)
        Me.btn_vat.Name = "btn_vat"
        Me.btn_vat.Size = New System.Drawing.Size(371, 59)
        Me.btn_vat.TabIndex = 4
        Me.btn_vat.Text = "พิมพ์บิลแสดงVat"
        Me.btn_vat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_vat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_vat.UseVisualStyleBackColor = True
        '
        'btn_novat
        '
        Me.btn_novat.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_novat.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_novat.Image = Global.BeecomePOS.My.Resources.Resources.print_32
        Me.btn_novat.Location = New System.Drawing.Point(4, 77)
        Me.btn_novat.Name = "btn_novat"
        Me.btn_novat.Size = New System.Drawing.Size(371, 60)
        Me.btn_novat.TabIndex = 3
        Me.btn_novat.Text = "พิมพ์บิลไม่แสดงVat"
        Me.btn_novat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_novat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_novat.UseVisualStyleBackColor = True
        '
        'BackgroundWorker1
        '
        '
        'BackgroundWorker2
        '
        '
        'BackgroundWorker3
        '
        '
        'showpay_typeprint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(387, 149)
        Me.Controls.Add(Me.btn_vat)
        Me.Controls.Add(Me.btn_novat)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "showpay_typeprint"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "สั่งพิมพ์-PrintBill"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_novat As System.Windows.Forms.Button
    Friend WithEvents btn_vat As System.Windows.Forms.Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorker2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorker3 As System.ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorker4 As System.ComponentModel.BackgroundWorker
End Class
