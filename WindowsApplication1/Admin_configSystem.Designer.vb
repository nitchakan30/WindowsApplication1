<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_configSystem
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Admin_configSystem))
        Me.onoff_rongbill = New System.Windows.Forms.CheckBox()
        Me.onoff_takehome = New System.Windows.Forms.CheckBox()
        Me.enter_save = New System.Windows.Forms.Button()
        Me.CheckedListBox_Report = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rpt_show_disgroup = New System.Windows.Forms.CheckBox()
        Me.rpt_show_disbill = New System.Windows.Forms.CheckBox()
        Me.rpt_show_service = New System.Windows.Forms.CheckBox()
        Me.rpt_show_vat = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPOSPath = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.CheckBox_1 = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.CheckBox_UseReport = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'onoff_rongbill
        '
        Me.onoff_rongbill.AutoSize = True
        Me.onoff_rongbill.Location = New System.Drawing.Point(12, 45)
        Me.onoff_rongbill.Name = "onoff_rongbill"
        Me.onoff_rongbill.Size = New System.Drawing.Size(126, 17)
        Me.onoff_rongbill.TabIndex = 5
        Me.onoff_rongbill.Text = "เปิดปิดปุ่มพิมพ์รองบิล"
        Me.onoff_rongbill.UseVisualStyleBackColor = True
        '
        'onoff_takehome
        '
        Me.onoff_takehome.AutoSize = True
        Me.onoff_takehome.Location = New System.Drawing.Point(12, 22)
        Me.onoff_takehome.Name = "onoff_takehome"
        Me.onoff_takehome.Size = New System.Drawing.Size(200, 17)
        Me.onoff_takehome.TabIndex = 6
        Me.onoff_takehome.Text = "เปิดปิดใช้งาน Take Home อย่างเดียว"
        Me.onoff_takehome.UseVisualStyleBackColor = True
        '
        'enter_save
        '
        Me.enter_save.Image = Global.BeecomePOS.My.Resources.Resources.save_16
        Me.enter_save.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.enter_save.Location = New System.Drawing.Point(139, 421)
        Me.enter_save.Name = "enter_save"
        Me.enter_save.Size = New System.Drawing.Size(132, 44)
        Me.enter_save.TabIndex = 14
        Me.enter_save.Text = "Save"
        Me.enter_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.enter_save.UseVisualStyleBackColor = True
        '
        'CheckedListBox_Report
        '
        Me.CheckedListBox_Report.FormattingEnabled = True
        Me.CheckedListBox_Report.Location = New System.Drawing.Point(9, 19)
        Me.CheckedListBox_Report.Name = "CheckedListBox_Report"
        Me.CheckedListBox_Report.Size = New System.Drawing.Size(376, 289)
        Me.CheckedListBox_Report.TabIndex = 15
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckBox_UseReport)
        Me.GroupBox1.Controls.Add(Me.CheckedListBox_Report)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 69)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(391, 342)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "เปิด/ปิด ใช้รายงานแบบรายเครื่อง"
        '
        'rpt_show_disgroup
        '
        Me.rpt_show_disgroup.AutoSize = True
        Me.rpt_show_disgroup.Location = New System.Drawing.Point(22, 36)
        Me.rpt_show_disgroup.Name = "rpt_show_disgroup"
        Me.rpt_show_disgroup.Size = New System.Drawing.Size(115, 17)
        Me.rpt_show_disgroup.TabIndex = 21
        Me.rpt_show_disgroup.Text = "โชว์ส่วนลดรายกลุ่ม"
        Me.rpt_show_disgroup.UseVisualStyleBackColor = True
        '
        'rpt_show_disbill
        '
        Me.rpt_show_disbill.AutoSize = True
        Me.rpt_show_disbill.Location = New System.Drawing.Point(22, 59)
        Me.rpt_show_disbill.Name = "rpt_show_disbill"
        Me.rpt_show_disbill.Size = New System.Drawing.Size(108, 17)
        Me.rpt_show_disbill.TabIndex = 22
        Me.rpt_show_disbill.Text = "โชว์ส่วนลดรายบิล"
        Me.rpt_show_disbill.UseVisualStyleBackColor = True
        '
        'rpt_show_service
        '
        Me.rpt_show_service.AutoSize = True
        Me.rpt_show_service.Location = New System.Drawing.Point(143, 59)
        Me.rpt_show_service.Name = "rpt_show_service"
        Me.rpt_show_service.Size = New System.Drawing.Size(120, 17)
        Me.rpt_show_service.TabIndex = 23
        Me.rpt_show_service.Text = "โชว์Service Change"
        Me.rpt_show_service.UseVisualStyleBackColor = True
        '
        'rpt_show_vat
        '
        Me.rpt_show_vat.AutoSize = True
        Me.rpt_show_vat.Location = New System.Drawing.Point(143, 36)
        Me.rpt_show_vat.Name = "rpt_show_vat"
        Me.rpt_show_vat.Size = New System.Drawing.Size(63, 17)
        Me.rpt_show_vat.TabIndex = 24
        Me.rpt_show_vat.Text = "โชว์ Vat"
        Me.rpt_show_vat.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rpt_show_vat)
        Me.GroupBox2.Controls.Add(Me.rpt_show_service)
        Me.GroupBox2.Controls.Add(Me.rpt_show_disbill)
        Me.GroupBox2.Controls.Add(Me.rpt_show_disgroup)
        Me.GroupBox2.Location = New System.Drawing.Point(399, 79)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(291, 94)
        Me.GroupBox2.TabIndex = 19
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "ตั้งโชว์ในรายงานผลรวมยอดขายต่อรอบกะ/รอบวัน แบบแจกแจง"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button2)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.TextBox3)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.TextBox2)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.TextBox1)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.txtPOSPath)
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Location = New System.Drawing.Point(405, 179)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(285, 180)
        Me.GroupBox3.TabIndex = 20
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "COMPORT PRINT"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(176, 145)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(103, 30)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "Test"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 119)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Stop"
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(68, 115)
        Me.TextBox3.MaxLength = 1
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(103, 24)
        Me.TextBox3.TabIndex = 7
        Me.TextBox3.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Write"
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(68, 85)
        Me.TextBox2.MaxLength = 1
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(103, 24)
        Me.TextBox2.TabIndex = 5
        Me.TextBox2.Text = "1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Start"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(68, 55)
        Me.TextBox1.MaxLength = 1
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(103, 24)
        Me.TextBox1.TabIndex = 3
        Me.TextBox1.Text = "1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Name Port"
        '
        'txtPOSPath
        '
        Me.txtPOSPath.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtPOSPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtPOSPath.Location = New System.Drawing.Point(68, 20)
        Me.txtPOSPath.MaxLength = 10
        Me.txtPOSPath.Name = "txtPOSPath"
        Me.txtPOSPath.Size = New System.Drawing.Size(103, 24)
        Me.txtPOSPath.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(68, 145)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(102, 30)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "SAVE"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.CheckBox_1)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.Button3)
        Me.GroupBox4.Location = New System.Drawing.Point(405, 366)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(285, 61)
        Me.GroupBox4.TabIndex = 21
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "โชว์ปริ้นไดอะล๊อคเครื่องปริ้นในหน้ารายงาน"
        '
        'CheckBox_1
        '
        Me.CheckBox_1.AutoSize = True
        Me.CheckBox_1.Location = New System.Drawing.Point(16, 28)
        Me.CheckBox_1.Name = "CheckBox_1"
        Me.CheckBox_1.Size = New System.Drawing.Size(164, 17)
        Me.CheckBox_1.TabIndex = 23
        Me.CheckBox_1.Text = "เปิด กดCheck , ปิด UnCheck"
        Me.CheckBox_1.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(0, 13)
        Me.Label5.TabIndex = 10
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(187, 23)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(70, 26)
        Me.Button3.TabIndex = 1
        Me.Button3.Text = "SAVE"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'CheckBox_UseReport
        '
        Me.CheckBox_UseReport.AutoSize = True
        Me.CheckBox_UseReport.Checked = True
        Me.CheckBox_UseReport.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox_UseReport.Location = New System.Drawing.Point(9, 314)
        Me.CheckBox_UseReport.Name = "CheckBox_UseReport"
        Me.CheckBox_UseReport.Size = New System.Drawing.Size(291, 17)
        Me.CheckBox_UseReport.TabIndex = 24
        Me.CheckBox_UseReport.Text = "Use Report Database / ดึงใช้เมนูรายงานจาก DB Server"
        Me.CheckBox_UseReport.UseVisualStyleBackColor = True
        '
        'Admin_configSystem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(702, 466)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.enter_save)
        Me.Controls.Add(Me.onoff_takehome)
        Me.Controls.Add(Me.onoff_rongbill)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Admin_configSystem"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Admin_configSystem"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents onoff_rongbill As System.Windows.Forms.CheckBox
    Friend WithEvents onoff_takehome As System.Windows.Forms.CheckBox
    Friend WithEvents enter_save As System.Windows.Forms.Button
    Friend WithEvents CheckedListBox_Report As System.Windows.Forms.CheckedListBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rpt_show_disgroup As System.Windows.Forms.CheckBox
    Friend WithEvents rpt_show_disbill As System.Windows.Forms.CheckBox
    Friend WithEvents rpt_show_service As System.Windows.Forms.CheckBox
    Friend WithEvents rpt_show_vat As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPOSPath As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents CheckBox_1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox_UseReport As System.Windows.Forms.CheckBox
End Class
