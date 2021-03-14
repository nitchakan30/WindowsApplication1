<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_configCalPay
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
        Me.use_client = New System.Windows.Forms.CheckBox()
        Me.txt_format_client = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.service_st_client = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.service_val_client = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.vat_val_client = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.vat_st_client = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txt_format_server = New System.Windows.Forms.TextBox()
        Me.vat_st_server = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.service_st_server = New System.Windows.Forms.ComboBox()
        Me.service_val_server = New System.Windows.Forms.TextBox()
        Me.vat_val_server = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btn_save = New System.Windows.Forms.Button()
        Me.btn_close = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'use_client
        '
        Me.use_client.AutoSize = True
        Me.use_client.Location = New System.Drawing.Point(26, 19)
        Me.use_client.Name = "use_client"
        Me.use_client.Size = New System.Drawing.Size(124, 17)
        Me.use_client.TabIndex = 0
        Me.use_client.Text = "Calculator Use Client"
        Me.use_client.UseVisualStyleBackColor = True
        '
        'txt_format_client
        '
        Me.txt_format_client.Location = New System.Drawing.Point(144, 48)
        Me.txt_format_client.MaxLength = 3
        Me.txt_format_client.Name = "txt_format_client"
        Me.txt_format_client.Size = New System.Drawing.Size(68, 20)
        Me.txt_format_client.TabIndex = 1
        Me.txt_format_client.Text = "dvs"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Format Calculator"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Service  charge Status"
        '
        'service_st_client
        '
        Me.service_st_client.FormattingEnabled = True
        Me.service_st_client.Items.AddRange(New Object() {"none", "inc", "exc"})
        Me.service_st_client.Location = New System.Drawing.Point(144, 75)
        Me.service_st_client.Name = "service_st_client"
        Me.service_st_client.Size = New System.Drawing.Size(68, 21)
        Me.service_st_client.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 109)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Service  charge Value"
        '
        'service_val_client
        '
        Me.service_val_client.Location = New System.Drawing.Point(144, 105)
        Me.service_val_client.MaxLength = 3
        Me.service_val_client.Name = "service_val_client"
        Me.service_val_client.Size = New System.Drawing.Size(68, 20)
        Me.service_val_client.TabIndex = 6
        Me.service_val_client.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(218, 109)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(15, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "%"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 135)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Vat Status"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(23, 161)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Vat Value"
        '
        'vat_val_client
        '
        Me.vat_val_client.Location = New System.Drawing.Point(144, 154)
        Me.vat_val_client.MaxLength = 3
        Me.vat_val_client.Name = "vat_val_client"
        Me.vat_val_client.Size = New System.Drawing.Size(68, 20)
        Me.vat_val_client.TabIndex = 11
        Me.vat_val_client.Text = "7"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(218, 158)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(15, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "%"
        '
        'vat_st_client
        '
        Me.vat_st_client.FormattingEnabled = True
        Me.vat_st_client.Items.AddRange(New Object() {"non", "inc", "exc"})
        Me.vat_st_client.Location = New System.Drawing.Point(144, 128)
        Me.vat_st_client.Name = "vat_st_client"
        Me.vat_st_client.Size = New System.Drawing.Size(68, 21)
        Me.vat_st_client.TabIndex = 14
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_format_server)
        Me.GroupBox1.Controls.Add(Me.vat_st_server)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.service_st_server)
        Me.GroupBox1.Controls.Add(Me.service_val_server)
        Me.GroupBox1.Controls.Add(Me.vat_val_server)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Location = New System.Drawing.Point(267, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(235, 197)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Database server"
        '
        'txt_format_server
        '
        Me.txt_format_server.Location = New System.Drawing.Point(138, 49)
        Me.txt_format_server.MaxLength = 3
        Me.txt_format_server.Name = "txt_format_server"
        Me.txt_format_server.Size = New System.Drawing.Size(68, 20)
        Me.txt_format_server.TabIndex = 25
        Me.txt_format_server.Text = "dvs"
        '
        'vat_st_server
        '
        Me.vat_st_server.FormattingEnabled = True
        Me.vat_st_server.Items.AddRange(New Object() {"non", "inc", "exc"})
        Me.vat_st_server.Location = New System.Drawing.Point(138, 129)
        Me.vat_st_server.Name = "vat_st_server"
        Me.vat_st_server.Size = New System.Drawing.Size(68, 21)
        Me.vat_st_server.TabIndex = 31
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(212, 159)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(15, 13)
        Me.Label10.TabIndex = 30
        Me.Label10.Text = "%"
        '
        'service_st_server
        '
        Me.service_st_server.FormattingEnabled = True
        Me.service_st_server.Items.AddRange(New Object() {"none", "inc", "exc"})
        Me.service_st_server.Location = New System.Drawing.Point(138, 76)
        Me.service_st_server.Name = "service_st_server"
        Me.service_st_server.Size = New System.Drawing.Size(68, 21)
        Me.service_st_server.TabIndex = 26
        '
        'service_val_server
        '
        Me.service_val_server.Location = New System.Drawing.Point(138, 106)
        Me.service_val_server.MaxLength = 3
        Me.service_val_server.Name = "service_val_server"
        Me.service_val_server.Size = New System.Drawing.Size(68, 20)
        Me.service_val_server.TabIndex = 27
        Me.service_val_server.Text = "0"
        '
        'vat_val_server
        '
        Me.vat_val_server.Location = New System.Drawing.Point(138, 155)
        Me.vat_val_server.MaxLength = 3
        Me.vat_val_server.Name = "vat_val_server"
        Me.vat_val_server.Size = New System.Drawing.Size(68, 20)
        Me.vat_val_server.TabIndex = 29
        Me.vat_val_server.Text = "7"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(212, 110)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(15, 13)
        Me.Label14.TabIndex = 28
        Me.Label14.Text = "%"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 54)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Format Calculator"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 80)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(115, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Service  charge Status"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(16, 164)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 13)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "Vat Value"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(16, 112)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(112, 13)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "Service  charge Value"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(16, 138)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(56, 13)
        Me.Label13.TabIndex = 22
        Me.Label13.Text = "Vat Status"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txt_format_client)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.use_client)
        Me.GroupBox2.Controls.Add(Me.vat_st_client)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.service_st_client)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.service_val_client)
        Me.GroupBox2.Controls.Add(Me.vat_val_client)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 22)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(249, 197)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Client"
        '
        'btn_save
        '
        Me.btn_save.Location = New System.Drawing.Point(183, 240)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(75, 23)
        Me.btn_save.TabIndex = 17
        Me.btn_save.Text = "save"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'btn_close
        '
        Me.btn_close.Location = New System.Drawing.Point(264, 240)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.Size = New System.Drawing.Size(75, 23)
        Me.btn_close.TabIndex = 18
        Me.btn_close.Text = "close"
        Me.btn_close.UseVisualStyleBackColor = True
        '
        'Admin_configCalPay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(523, 277)
        Me.Controls.Add(Me.btn_close)
        Me.Controls.Add(Me.btn_save)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Admin_configCalPay"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Config Calculator POs"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents use_client As System.Windows.Forms.CheckBox
    Friend WithEvents txt_format_client As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents service_st_client As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents service_val_client As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents vat_val_client As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents vat_st_client As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_save As System.Windows.Forms.Button
    Friend WithEvents btn_close As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txt_format_server As System.Windows.Forms.TextBox
    Friend WithEvents vat_st_server As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents service_st_server As System.Windows.Forms.ComboBox
    Friend WithEvents service_val_server As System.Windows.Forms.TextBox
    Friend WithEvents vat_val_server As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
End Class
