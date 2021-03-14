<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_ConfigTBONOFF
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnOnTBOpen = New System.Windows.Forms.Button()
        Me.btnOnTBOff = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(425, 29)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "ตั้งค่า เปิด - ปิด ใช้งานระบบโต๊ะอาหารทั้งหมด" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnOnTBOpen
        '
        Me.btnOnTBOpen.BackColor = System.Drawing.Color.DarkGray
        Me.btnOnTBOpen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOnTBOpen.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnOnTBOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOnTBOpen.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnOnTBOpen.Location = New System.Drawing.Point(110, 67)
        Me.btnOnTBOpen.Name = "btnOnTBOpen"
        Me.btnOnTBOpen.Size = New System.Drawing.Size(99, 51)
        Me.btnOnTBOpen.TabIndex = 34
        Me.btnOnTBOpen.Text = "เปิด"
        Me.btnOnTBOpen.UseVisualStyleBackColor = False
        '
        'btnOnTBOff
        '
        Me.btnOnTBOff.BackColor = System.Drawing.Color.Red
        Me.btnOnTBOff.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOnTBOff.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnOnTBOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOnTBOff.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnOnTBOff.Location = New System.Drawing.Point(206, 67)
        Me.btnOnTBOff.Name = "btnOnTBOff"
        Me.btnOnTBOff.Size = New System.Drawing.Size(99, 51)
        Me.btnOnTBOff.TabIndex = 35
        Me.btnOnTBOff.Text = "ปิด"
        Me.btnOnTBOff.UseVisualStyleBackColor = False
        '
        'Admin_ConfigTBONOFF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(441, 158)
        Me.Controls.Add(Me.btnOnTBOff)
        Me.Controls.Add(Me.btnOnTBOpen)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Admin_ConfigTBONOFF"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "เปิด ปิด ใช้งานระบบโต๊ะอาหาร"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnOnTBOpen As System.Windows.Forms.Button
    Friend WithEvents btnOnTBOff As System.Windows.Forms.Button
End Class
