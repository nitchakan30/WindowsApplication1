<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class opentable_voidorder1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(opentable_voidorder1))
        Me.txt_recomment = New System.Windows.Forms.TextBox()
        Me.btn_enter = New System.Windows.Forms.Button()
        Me.txt_number = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txt_recomment
        '
        Me.txt_recomment.BackColor = System.Drawing.Color.White
        Me.txt_recomment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_recomment.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_recomment.Location = New System.Drawing.Point(113, 73)
        Me.txt_recomment.MaxLength = 250
        Me.txt_recomment.Multiline = True
        Me.txt_recomment.Name = "txt_recomment"
        Me.txt_recomment.Size = New System.Drawing.Size(296, 59)
        Me.txt_recomment.TabIndex = 3
        Me.txt_recomment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btn_enter
        '
        Me.btn_enter.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_enter.Location = New System.Drawing.Point(113, 138)
        Me.btn_enter.Name = "btn_enter"
        Me.btn_enter.Size = New System.Drawing.Size(296, 42)
        Me.btn_enter.TabIndex = 2
        Me.btn_enter.Text = "Enter"
        Me.btn_enter.UseVisualStyleBackColor = True
        '
        'txt_number
        '
        Me.txt_number.BackColor = System.Drawing.Color.Lime
        Me.txt_number.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_number.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_number.Location = New System.Drawing.Point(113, 25)
        Me.txt_number.MaxLength = 250
        Me.txt_number.Name = "txt_number"
        Me.txt_number.Size = New System.Drawing.Size(296, 38)
        Me.txt_number.TabIndex = 4
        Me.txt_number.Text = "0"
        Me.txt_number.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 24)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "จำนวนที่ลด"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 24)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "เหตุผล"
        '
        'opentable_voidorder1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(425, 187)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_number)
        Me.Controls.Add(Me.txt_recomment)
        Me.Controls.Add(Me.btn_enter)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "opentable_voidorder1"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "หน้าจอกรอกเหตุผลยกเลิกรายการ"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_recomment As System.Windows.Forms.TextBox
    Friend WithEvents btn_enter As System.Windows.Forms.Button
    Friend WithEvents txt_number As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
