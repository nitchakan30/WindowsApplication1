<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class stock_cut_prd
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(stock_cut_prd))
        Me.enter_1 = New System.Windows.Forms.Button()
        Me.TextBox_Num = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox_Res = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'enter_1
        '
        Me.enter_1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.enter_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.enter_1.ForeColor = System.Drawing.Color.Snow
        Me.enter_1.Location = New System.Drawing.Point(86, 107)
        Me.enter_1.Name = "enter_1"
        Me.enter_1.Size = New System.Drawing.Size(297, 51)
        Me.enter_1.TabIndex = 0
        Me.enter_1.Text = "ENTER"
        Me.enter_1.UseVisualStyleBackColor = False
        '
        'TextBox_Num
        '
        Me.TextBox_Num.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.TextBox_Num.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox_Num.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TextBox_Num.Location = New System.Drawing.Point(86, 15)
        Me.TextBox_Num.MaxLength = 9
        Me.TextBox_Num.Name = "TextBox_Num"
        Me.TextBox_Num.Size = New System.Drawing.Size(297, 40)
        Me.TextBox_Num.TabIndex = 1
        Me.TextBox_Num.Text = "0"
        Me.TextBox_Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 25)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "จำนวน"
        '
        'TextBox_Res
        '
        Me.TextBox_Res.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.TextBox_Res.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox_Res.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TextBox_Res.Location = New System.Drawing.Point(86, 61)
        Me.TextBox_Res.MaxLength = 255
        Me.TextBox_Res.Multiline = True
        Me.TextBox_Res.Name = "TextBox_Res"
        Me.TextBox_Res.Size = New System.Drawing.Size(297, 40)
        Me.TextBox_Res.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 25)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "เหตุผล"
        '
        'stock_cut_prd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(395, 162)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox_Res)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox_Num)
        Me.Controls.Add(Me.enter_1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "stock_cut_prd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ตัดเบิกสินค้า"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents enter_1 As System.Windows.Forms.Button
    Friend WithEvents TextBox_Num As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox_Res As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
