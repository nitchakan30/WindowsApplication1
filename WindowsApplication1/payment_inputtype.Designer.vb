<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class payment_inputtype
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
        Me.GroupBox_Coupon = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox_Coupon = New System.Windows.Forms.TextBox()
        Me.GroupBox_Credit = New System.Windows.Forms.GroupBox()
        Me.GroupBox_TC = New System.Windows.Forms.GroupBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.ComboBox_Payacc = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox_Exp_Y = New System.Windows.Forms.TextBox()
        Me.TextBox_Exp_M = New System.Windows.Forms.TextBox()
        Me.TextBox_Card1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox_BankTranfer = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox_NumberRoom = New System.Windows.Forms.TextBox()
        Me.GroupBox_Other = New System.Windows.Forms.GroupBox()
        Me.txt_payment_other = New System.Windows.Forms.TextBox()
        Me.btn_add_pyother = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox_Coupon.SuspendLayout()
        Me.GroupBox_Credit.SuspendLayout()
        Me.GroupBox_TC.SuspendLayout()
        Me.GroupBox_BankTranfer.SuspendLayout()
        Me.GroupBox_Other.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox_Coupon
        '
        Me.GroupBox_Coupon.AutoSize = True
        Me.GroupBox_Coupon.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox_Coupon.Controls.Add(Me.Label1)
        Me.GroupBox_Coupon.Controls.Add(Me.TextBox_Coupon)
        Me.GroupBox_Coupon.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox_Coupon.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GroupBox_Coupon.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox_Coupon.Name = "GroupBox_Coupon"
        Me.GroupBox_Coupon.Size = New System.Drawing.Size(346, 94)
        Me.GroupBox_Coupon.TabIndex = 32
        Me.GroupBox_Coupon.TabStop = False
        Me.GroupBox_Coupon.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 16)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Coupon Number"
        '
        'TextBox_Coupon
        '
        Me.TextBox_Coupon.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextBox_Coupon.Location = New System.Drawing.Point(19, 37)
        Me.TextBox_Coupon.Name = "TextBox_Coupon"
        Me.TextBox_Coupon.Size = New System.Drawing.Size(315, 29)
        Me.TextBox_Coupon.TabIndex = 12
        '
        'GroupBox_Credit
        '
        Me.GroupBox_Credit.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox_Credit.Controls.Add(Me.GroupBox_TC)
        Me.GroupBox_Credit.Controls.Add(Me.ComboBox_Payacc)
        Me.GroupBox_Credit.Controls.Add(Me.Label4)
        Me.GroupBox_Credit.Controls.Add(Me.Label3)
        Me.GroupBox_Credit.Controls.Add(Me.TextBox_Exp_Y)
        Me.GroupBox_Credit.Controls.Add(Me.TextBox_Exp_M)
        Me.GroupBox_Credit.Controls.Add(Me.TextBox_Card1)
        Me.GroupBox_Credit.Controls.Add(Me.Label2)
        Me.GroupBox_Credit.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox_Credit.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GroupBox_Credit.Location = New System.Drawing.Point(0, 94)
        Me.GroupBox_Credit.Name = "GroupBox_Credit"
        Me.GroupBox_Credit.Size = New System.Drawing.Size(346, 228)
        Me.GroupBox_Credit.TabIndex = 33
        Me.GroupBox_Credit.TabStop = False
        '
        'GroupBox_TC
        '
        Me.GroupBox_TC.Controls.Add(Me.FlowLayoutPanel1)
        Me.GroupBox_TC.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox_TC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GroupBox_TC.Location = New System.Drawing.Point(3, 25)
        Me.GroupBox_TC.Name = "GroupBox_TC"
        Me.GroupBox_TC.Size = New System.Drawing.Size(340, 89)
        Me.GroupBox_TC.TabIndex = 22
        Me.GroupBox_TC.TabStop = False
        Me.GroupBox_TC.Text = "ประเภท Credit Card"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 18)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(334, 68)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'ComboBox_Payacc
        '
        Me.ComboBox_Payacc.FormattingEnabled = True
        Me.ComboBox_Payacc.Location = New System.Drawing.Point(696, 35)
        Me.ComboBox_Payacc.Name = "ComboBox_Payacc"
        Me.ComboBox_Payacc.Size = New System.Drawing.Size(243, 32)
        Me.ComboBox_Payacc.TabIndex = 19
        Me.ComboBox_Payacc.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.Location = New System.Drawing.Point(18, 114)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(126, 16)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Credit Card Number"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(94, 181)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(15, 24)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "/"
        '
        'TextBox_Exp_Y
        '
        Me.TextBox_Exp_Y.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextBox_Exp_Y.Location = New System.Drawing.Point(111, 181)
        Me.TextBox_Exp_Y.MaxLength = 4
        Me.TextBox_Exp_Y.Name = "TextBox_Exp_Y"
        Me.TextBox_Exp_Y.Size = New System.Drawing.Size(70, 29)
        Me.TextBox_Exp_Y.TabIndex = 15
        '
        'TextBox_Exp_M
        '
        Me.TextBox_Exp_M.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextBox_Exp_M.Location = New System.Drawing.Point(19, 181)
        Me.TextBox_Exp_M.MaxLength = 2
        Me.TextBox_Exp_M.Name = "TextBox_Exp_M"
        Me.TextBox_Exp_M.Size = New System.Drawing.Size(70, 29)
        Me.TextBox_Exp_M.TabIndex = 14
        '
        'TextBox_Card1
        '
        Me.TextBox_Card1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextBox_Card1.Location = New System.Drawing.Point(19, 131)
        Me.TextBox_Card1.MaxLength = 16
        Me.TextBox_Card1.Name = "TextBox_Card1"
        Me.TextBox_Card1.Size = New System.Drawing.Size(315, 29)
        Me.TextBox_Card1.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 163)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 16)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Expire Date"
        '
        'GroupBox_BankTranfer
        '
        Me.GroupBox_BankTranfer.AutoSize = True
        Me.GroupBox_BankTranfer.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox_BankTranfer.Controls.Add(Me.Label5)
        Me.GroupBox_BankTranfer.Controls.Add(Me.TextBox_NumberRoom)
        Me.GroupBox_BankTranfer.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox_BankTranfer.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GroupBox_BankTranfer.Location = New System.Drawing.Point(0, 322)
        Me.GroupBox_BankTranfer.Name = "GroupBox_BankTranfer"
        Me.GroupBox_BankTranfer.Size = New System.Drawing.Size(346, 95)
        Me.GroupBox_BankTranfer.TabIndex = 34
        Me.GroupBox_BankTranfer.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(163, 16)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Bank No. / Name Suname"
        '
        'TextBox_NumberRoom
        '
        Me.TextBox_NumberRoom.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextBox_NumberRoom.Location = New System.Drawing.Point(19, 38)
        Me.TextBox_NumberRoom.Name = "TextBox_NumberRoom"
        Me.TextBox_NumberRoom.Size = New System.Drawing.Size(158, 29)
        Me.TextBox_NumberRoom.TabIndex = 12
        '
        'GroupBox_Other
        '
        Me.GroupBox_Other.Controls.Add(Me.txt_payment_other)
        Me.GroupBox_Other.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox_Other.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GroupBox_Other.Location = New System.Drawing.Point(0, 417)
        Me.GroupBox_Other.Name = "GroupBox_Other"
        Me.GroupBox_Other.Size = New System.Drawing.Size(346, 62)
        Me.GroupBox_Other.TabIndex = 35
        Me.GroupBox_Other.TabStop = False
        Me.GroupBox_Other.Text = "รับชำระรูปแบบอื่นๆ"
        Me.GroupBox_Other.Visible = False
        '
        'txt_payment_other
        '
        Me.txt_payment_other.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txt_payment_other.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_payment_other.ForeColor = System.Drawing.SystemColors.InfoText
        Me.txt_payment_other.Location = New System.Drawing.Point(9, 20)
        Me.txt_payment_other.Name = "txt_payment_other"
        Me.txt_payment_other.Size = New System.Drawing.Size(325, 29)
        Me.txt_payment_other.TabIndex = 0
        '
        'btn_add_pyother
        '
        Me.btn_add_pyother.Location = New System.Drawing.Point(272, 553)
        Me.btn_add_pyother.Name = "btn_add_pyother"
        Me.btn_add_pyother.Size = New System.Drawing.Size(62, 29)
        Me.btn_add_pyother.TabIndex = 1
        Me.btn_add_pyother.Text = "Add"
        Me.btn_add_pyother.UseVisualStyleBackColor = True
        Me.btn_add_pyother.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 479)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(346, 34)
        Me.Panel1.TabIndex = 36
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Button1.Location = New System.Drawing.Point(111, 1)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(101, 32)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "OK"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'payment_inputtype
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(346, 439)
        Me.ControlBox = False
        Me.Controls.Add(Me.btn_add_pyother)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox_Other)
        Me.Controls.Add(Me.GroupBox_BankTranfer)
        Me.Controls.Add(Me.GroupBox_Credit)
        Me.Controls.Add(Me.GroupBox_Coupon)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "payment_inputtype"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Payment Type"
        Me.GroupBox_Coupon.ResumeLayout(False)
        Me.GroupBox_Coupon.PerformLayout()
        Me.GroupBox_Credit.ResumeLayout(False)
        Me.GroupBox_Credit.PerformLayout()
        Me.GroupBox_TC.ResumeLayout(False)
        Me.GroupBox_BankTranfer.ResumeLayout(False)
        Me.GroupBox_BankTranfer.PerformLayout()
        Me.GroupBox_Other.ResumeLayout(False)
        Me.GroupBox_Other.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox_Coupon As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox_Coupon As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox_Credit As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox_TC As System.Windows.Forms.GroupBox
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents ComboBox_Payacc As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox_Exp_Y As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_Exp_M As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_Card1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox_BankTranfer As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBox_NumberRoom As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox_Other As System.Windows.Forms.GroupBox
    Friend WithEvents btn_add_pyother As System.Windows.Forms.Button
    Friend WithEvents txt_payment_other As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
