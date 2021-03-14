<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_ConfigTBCus_OnOff
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
        Me.btnOnTBOff = New System.Windows.Forms.Button()
        Me.btnOnTBOpen = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnOnTBOff
        '
        Me.btnOnTBOff.BackColor = System.Drawing.Color.Red
        Me.btnOnTBOff.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnOnTBOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOnTBOff.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnOnTBOff.Location = New System.Drawing.Point(196, 58)
        Me.btnOnTBOff.Name = "btnOnTBOff"
        Me.btnOnTBOff.Size = New System.Drawing.Size(99, 51)
        Me.btnOnTBOff.TabIndex = 39
        Me.btnOnTBOff.Text = "ปิด"
        Me.btnOnTBOff.UseVisualStyleBackColor = False
        '
        'btnOnTBOpen
        '
        Me.btnOnTBOpen.BackColor = System.Drawing.Color.DarkGray
        Me.btnOnTBOpen.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnOnTBOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOnTBOpen.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnOnTBOpen.Location = New System.Drawing.Point(100, 58)
        Me.btnOnTBOpen.Name = "btnOnTBOpen"
        Me.btnOnTBOpen.Size = New System.Drawing.Size(99, 51)
        Me.btnOnTBOpen.TabIndex = 38
        Me.btnOnTBOpen.Text = "เปิด"
        Me.btnOnTBOpen.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Image = Global.BeecomePOS.My.Resources.Resources.Left
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(335, 142)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 29)
        Me.Button3.TabIndex = 43
        Me.Button3.Text = "ย้อนกลับ"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(21, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(373, 20)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "ตั้งค่า เปิด ปิด ใช้งานระบบโต๊ะอาหาร ในรูปแบบที่ออกแบบเอง"
        '
        'Admin_ConfigTBCus_OnOff
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(415, 183)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnOnTBOff)
        Me.Controls.Add(Me.btnOnTBOpen)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Admin_ConfigTBCus_OnOff"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ON /OFF TABLE USER DESIGN"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOnTBOff As System.Windows.Forms.Button
    Friend WithEvents btnOnTBOpen As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
