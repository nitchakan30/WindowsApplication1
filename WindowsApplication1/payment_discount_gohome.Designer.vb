<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class payment_discount_gohome
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(payment_discount_gohome))
        Me.txt_dis_only = New System.Windows.Forms.TextBox()
        Me.add_dis_only = New System.Windows.Forms.Button()
        Me.minus_dis_only = New System.Windows.Forms.Button()
        Me.radio_dis_only1 = New System.Windows.Forms.RadioButton()
        Me.radio_dis_only2 = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txt_dis_only
        '
        Me.txt_dis_only.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txt_dis_only.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_dis_only.Location = New System.Drawing.Point(1, 55)
        Me.txt_dis_only.MaxLength = 5
        Me.txt_dis_only.Name = "txt_dis_only"
        Me.txt_dis_only.ReadOnly = True
        Me.txt_dis_only.Size = New System.Drawing.Size(325, 49)
        Me.txt_dis_only.TabIndex = 47
        Me.txt_dis_only.Text = "0.0"
        Me.txt_dis_only.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'add_dis_only
        '
        Me.add_dis_only.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.add_dis_only.Image = Global.BeecomePOS.My.Resources.Resources.plus_16
        Me.add_dis_only.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.add_dis_only.Location = New System.Drawing.Point(1, 110)
        Me.add_dis_only.Name = "add_dis_only"
        Me.add_dis_only.Size = New System.Drawing.Size(159, 52)
        Me.add_dis_only.TabIndex = 43
        Me.add_dis_only.Text = "Add Disc."
        Me.add_dis_only.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.add_dis_only.UseVisualStyleBackColor = True
        '
        'minus_dis_only
        '
        Me.minus_dis_only.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.minus_dis_only.Image = Global.BeecomePOS.My.Resources.Resources.delete_16
        Me.minus_dis_only.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.minus_dis_only.Location = New System.Drawing.Point(175, 110)
        Me.minus_dis_only.Name = "minus_dis_only"
        Me.minus_dis_only.Size = New System.Drawing.Size(151, 52)
        Me.minus_dis_only.TabIndex = 44
        Me.minus_dis_only.Text = "Cancel"
        Me.minus_dis_only.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.minus_dis_only.UseVisualStyleBackColor = True
        '
        'radio_dis_only1
        '
        Me.radio_dis_only1.AutoSize = True
        Me.radio_dis_only1.Checked = True
        Me.radio_dis_only1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.radio_dis_only1.Location = New System.Drawing.Point(63, 23)
        Me.radio_dis_only1.Name = "radio_dis_only1"
        Me.radio_dis_only1.Size = New System.Drawing.Size(69, 33)
        Me.radio_dis_only1.TabIndex = 46
        Me.radio_dis_only1.TabStop = True
        Me.radio_dis_only1.Tag = "bath"
        Me.radio_dis_only1.Text = "บาท"
        Me.radio_dis_only1.UseVisualStyleBackColor = True
        '
        'radio_dis_only2
        '
        Me.radio_dis_only2.AutoSize = True
        Me.radio_dis_only2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.radio_dis_only2.Location = New System.Drawing.Point(206, 23)
        Me.radio_dis_only2.Name = "radio_dis_only2"
        Me.radio_dis_only2.Size = New System.Drawing.Size(53, 33)
        Me.radio_dis_only2.TabIndex = 45
        Me.radio_dis_only2.Tag = "percent"
        Me.radio_dis_only2.Text = "%"
        Me.radio_dis_only2.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txt_dis_only)
        Me.GroupBox2.Controls.Add(Me.add_dis_only)
        Me.GroupBox2.Controls.Add(Me.minus_dis_only)
        Me.GroupBox2.Controls.Add(Me.radio_dis_only1)
        Me.GroupBox2.Controls.Add(Me.radio_dis_only2)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(327, 169)
        Me.GroupBox2.TabIndex = 50
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "กรอกส่วนลดสินค้า"
        '
        'payment_discount_gohome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(327, 169)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "payment_discount_gohome"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Discount Gohome"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txt_dis_only As System.Windows.Forms.TextBox
    Friend WithEvents add_dis_only As System.Windows.Forms.Button
    Friend WithEvents minus_dis_only As System.Windows.Forms.Button
    Friend WithEvents radio_dis_only1 As System.Windows.Forms.RadioButton
    Friend WithEvents radio_dis_only2 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
End Class
