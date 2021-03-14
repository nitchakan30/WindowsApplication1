<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_ropbill_close
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(form_ropbill_close))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btn_clear = New System.Windows.Forms.Button()
        Me.btn_enter = New System.Windows.Forms.Button()
        Me.Label_Show = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_user = New System.Windows.Forms.TextBox()
        Me.txt_pwd = New System.Windows.Forms.TextBox()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Button1.Image = Global.BeecomePOS.My.Resources.Resources.trash_16
        Me.Button1.Location = New System.Drawing.Point(109, 121)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(74, 37)
        Me.Button1.TabIndex = 22
        Me.Button1.Text = "Clear"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btn_clear
        '
        Me.btn_clear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_clear.Image = Global.BeecomePOS.My.Resources.Resources.delete_16
        Me.btn_clear.Location = New System.Drawing.Point(188, 121)
        Me.btn_clear.Name = "btn_clear"
        Me.btn_clear.Size = New System.Drawing.Size(95, 37)
        Me.btn_clear.TabIndex = 18
        Me.btn_clear.Text = "Cancel"
        Me.btn_clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_clear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_clear.UseVisualStyleBackColor = True
        '
        'btn_enter
        '
        Me.btn_enter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_enter.Image = Global.BeecomePOS.My.Resources.Resources.save_16
        Me.btn_enter.Location = New System.Drawing.Point(8, 121)
        Me.btn_enter.Name = "btn_enter"
        Me.btn_enter.Size = New System.Drawing.Size(97, 37)
        Me.btn_enter.TabIndex = 17
        Me.btn_enter.Text = "Enter"
        Me.btn_enter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_enter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_enter.UseVisualStyleBackColor = True
        '
        'Label_Show
        '
        Me.Label_Show.AutoSize = True
        Me.Label_Show.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label_Show.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label_Show.Location = New System.Drawing.Point(0, 0)
        Me.Label_Show.Margin = New System.Windows.Forms.Padding(3, 5, 3, 10)
        Me.Label_Show.Name = "Label_Show"
        Me.Label_Show.Size = New System.Drawing.Size(96, 25)
        Me.Label_Show.TabIndex = 23
        Me.Label_Show.Text = "ปิดรอบเช้า"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txt_user)
        Me.GroupBox2.Controls.Add(Me.txt_pwd)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(0, 25)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(289, 90)
        Me.GroupBox2.TabIndex = 24
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "รหัสผู้ดูแล"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 16)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Password"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 16)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Username"
        '
        'txt_user
        '
        Me.txt_user.Location = New System.Drawing.Point(109, 26)
        Me.txt_user.MaxLength = 15
        Me.txt_user.Name = "txt_user"
        Me.txt_user.Size = New System.Drawing.Size(156, 22)
        Me.txt_user.TabIndex = 7
        '
        'txt_pwd
        '
        Me.txt_pwd.Location = New System.Drawing.Point(109, 52)
        Me.txt_pwd.MaxLength = 15
        Me.txt_pwd.Name = "txt_pwd"
        Me.txt_pwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_pwd.Size = New System.Drawing.Size(156, 22)
        Me.txt_pwd.TabIndex = 8
        '
        'form_ropbill_close
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(289, 163)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label_Show)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btn_clear)
        Me.Controls.Add(Me.btn_enter)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "form_ropbill_close"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ปิดรอบกะ"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btn_clear As System.Windows.Forms.Button
    Friend WithEvents btn_enter As System.Windows.Forms.Button
    Friend WithEvents Label_Show As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_user As System.Windows.Forms.TextBox
    Friend WithEvents txt_pwd As System.Windows.Forms.TextBox
End Class
