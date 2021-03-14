<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_Configpaymentdialog_oc
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
        Me.TextBox_Name = New System.Windows.Forms.TextBox()
        Me.TextBox_Credit = New System.Windows.Forms.TextBox()
        Me.TextBox_FixCredit = New System.Windows.Forms.TextBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ComboBox_TypeOc = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextBox_Depart = New System.Windows.Forms.TextBox()
        Me.TextBox_Position = New System.Windows.Forms.TextBox()
        Me.TextBox_EmpID = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextBox_Remark = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ComboBox_PayType = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.btn_minus = New System.Windows.Forms.Button()
        Me.btn_plus = New System.Windows.Forms.Button()
        Me.btn_cancel = New System.Windows.Forms.Button()
        Me.btn_save = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TextBox_Name
        '
        Me.TextBox_Name.Location = New System.Drawing.Point(122, 29)
        Me.TextBox_Name.MaxLength = 255
        Me.TextBox_Name.Name = "TextBox_Name"
        Me.TextBox_Name.Size = New System.Drawing.Size(194, 20)
        Me.TextBox_Name.TabIndex = 0
        '
        'TextBox_Credit
        '
        Me.TextBox_Credit.Location = New System.Drawing.Point(122, 129)
        Me.TextBox_Credit.MaxLength = 20
        Me.TextBox_Credit.Name = "TextBox_Credit"
        Me.TextBox_Credit.Size = New System.Drawing.Size(89, 20)
        Me.TextBox_Credit.TabIndex = 1
        Me.TextBox_Credit.Text = "0.00"
        '
        'TextBox_FixCredit
        '
        Me.TextBox_FixCredit.Location = New System.Drawing.Point(121, 155)
        Me.TextBox_FixCredit.MaxLength = 20
        Me.TextBox_FixCredit.Name = "TextBox_FixCredit"
        Me.TextBox_FixCredit.Size = New System.Drawing.Size(89, 20)
        Me.TextBox_FixCredit.TabIndex = 2
        Me.TextBox_FixCredit.Text = "0.00"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(124, 209)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(153, 20)
        Me.DateTimePicker1.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "ชื่อ-Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 129)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "เครดิต-Credit"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 155)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "ฟิกเครดิต-Fix Credit"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 212)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "หมดอายุ-Duedate"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(215, 132)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(15, 18)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "*"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(216, 154)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(15, 18)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "*"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(322, 29)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(15, 18)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "*"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 182)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(114, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "ประเภทการเพิ่มเครดิต"
        '
        'ComboBox_TypeOc
        '
        Me.ComboBox_TypeOc.FormattingEnabled = True
        Me.ComboBox_TypeOc.Location = New System.Drawing.Point(137, 182)
        Me.ComboBox_TypeOc.Name = "ComboBox_TypeOc"
        Me.ComboBox_TypeOc.Size = New System.Drawing.Size(138, 21)
        Me.ComboBox_TypeOc.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 54)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "แผนก"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 77)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 13)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "ตำแหน่ง"
        '
        'TextBox_Depart
        '
        Me.TextBox_Depart.Location = New System.Drawing.Point(122, 54)
        Me.TextBox_Depart.MaxLength = 255
        Me.TextBox_Depart.Name = "TextBox_Depart"
        Me.TextBox_Depart.Size = New System.Drawing.Size(194, 20)
        Me.TextBox_Depart.TabIndex = 18
        '
        'TextBox_Position
        '
        Me.TextBox_Position.Location = New System.Drawing.Point(122, 78)
        Me.TextBox_Position.MaxLength = 255
        Me.TextBox_Position.Name = "TextBox_Position"
        Me.TextBox_Position.Size = New System.Drawing.Size(194, 20)
        Me.TextBox_Position.TabIndex = 19
        '
        'TextBox_EmpID
        '
        Me.TextBox_EmpID.Location = New System.Drawing.Point(121, 103)
        Me.TextBox_EmpID.MaxLength = 255
        Me.TextBox_EmpID.Name = "TextBox_EmpID"
        Me.TextBox_EmpID.Size = New System.Drawing.Size(194, 20)
        Me.TextBox_EmpID.TabIndex = 21
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(15, 102)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 13)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "รหัสพนักงาน"
        '
        'TextBox_Remark
        '
        Me.TextBox_Remark.Location = New System.Drawing.Point(122, 235)
        Me.TextBox_Remark.MaxLength = 255
        Me.TextBox_Remark.Name = "TextBox_Remark"
        Me.TextBox_Remark.Size = New System.Drawing.Size(194, 20)
        Me.TextBox_Remark.TabIndex = 22
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(15, 242)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(46, 13)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "เพิ่มเติม"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(281, 182)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(15, 18)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "*"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Red
        Me.Label14.Location = New System.Drawing.Point(283, 211)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(15, 18)
        Me.Label14.TabIndex = 25
        Me.Label14.Text = "*"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(15, 263)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(105, 13)
        Me.Label15.TabIndex = 26
        Me.Label15.Text = "เชื่อมประเภทการจ่าย"
        '
        'ComboBox_PayType
        '
        Me.ComboBox_PayType.FormattingEnabled = True
        Me.ComboBox_PayType.Location = New System.Drawing.Point(124, 263)
        Me.ComboBox_PayType.Name = "ComboBox_PayType"
        Me.ComboBox_PayType.Size = New System.Drawing.Size(192, 21)
        Me.ComboBox_PayType.TabIndex = 27
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Red
        Me.Label16.Location = New System.Drawing.Point(322, 263)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(15, 18)
        Me.Label16.TabIndex = 28
        Me.Label16.Text = "*"
        '
        'btn_minus
        '
        Me.btn_minus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_minus.Image = Global.BeecomePOS.My.Resources.Resources.m_mini
        Me.btn_minus.Location = New System.Drawing.Point(272, 129)
        Me.btn_minus.Name = "btn_minus"
        Me.btn_minus.Size = New System.Drawing.Size(35, 23)
        Me.btn_minus.TabIndex = 8
        Me.btn_minus.UseVisualStyleBackColor = True
        '
        'btn_plus
        '
        Me.btn_plus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_plus.Image = Global.BeecomePOS.My.Resources.Resources.plus_16
        Me.btn_plus.Location = New System.Drawing.Point(231, 129)
        Me.btn_plus.Name = "btn_plus"
        Me.btn_plus.Size = New System.Drawing.Size(35, 23)
        Me.btn_plus.TabIndex = 7
        Me.btn_plus.UseVisualStyleBackColor = True
        '
        'btn_cancel
        '
        Me.btn_cancel.Image = Global.BeecomePOS.My.Resources.Resources.delete_161
        Me.btn_cancel.Location = New System.Drawing.Point(202, 303)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(75, 31)
        Me.btn_cancel.TabIndex = 6
        Me.btn_cancel.Text = "Cancel"
        Me.btn_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_cancel.UseVisualStyleBackColor = True
        '
        'btn_save
        '
        Me.btn_save.Image = Global.BeecomePOS.My.Resources.Resources.save_16
        Me.btn_save.Location = New System.Drawing.Point(121, 303)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(75, 31)
        Me.btn_save.TabIndex = 5
        Me.btn_save.Text = "Save"
        Me.btn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'Admin_Configpaymentdialog_oc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(354, 344)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.ComboBox_PayType)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TextBox_Remark)
        Me.Controls.Add(Me.TextBox_EmpID)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TextBox_Position)
        Me.Controls.Add(Me.TextBox_Depart)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.ComboBox_TypeOc)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btn_minus)
        Me.Controls.Add(Me.btn_plus)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.TextBox_FixCredit)
        Me.Controls.Add(Me.TextBox_Credit)
        Me.Controls.Add(Me.TextBox_Name)
        Me.Controls.Add(Me.btn_cancel)
        Me.Controls.Add(Me.btn_save)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Admin_Configpaymentdialog_oc"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "แบบฟอร์มเพิ่มข้อมูล OC"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox_Name As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_Credit As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_FixCredit As System.Windows.Forms.TextBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_save As System.Windows.Forms.Button
    Friend WithEvents btn_cancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btn_plus As System.Windows.Forms.Button
    Friend WithEvents btn_minus As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ComboBox_TypeOc As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextBox_Depart As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_Position As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_EmpID As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextBox_Remark As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ComboBox_PayType As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
End Class
