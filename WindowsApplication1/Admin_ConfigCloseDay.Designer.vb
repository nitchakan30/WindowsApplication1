<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_ConfigCloseDay
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Admin_ConfigCloseDay))
        Me.CheckBox_Check_Balance = New System.Windows.Forms.CheckBox()
        Me.CheckBox_Print_N0 = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lang_sendcaptain = New System.Windows.Forms.CheckBox()
        Me.onoff_alertsendcaptain = New System.Windows.Forms.CheckBox()
        Me.CheckBox_Print_inventory = New System.Windows.Forms.CheckBox()
        Me.CheckBox_Print_N1_1 = New System.Windows.Forms.CheckBox()
        Me.CheckBox_Print_N0_1 = New System.Windows.Forms.CheckBox()
        Me.CheckBox_Print_N1 = New System.Windows.Forms.CheckBox()
        Me.save = New System.Windows.Forms.Button()
        Me.lang_trybill = New System.Windows.Forms.CheckBox()
        Me.lang_payment = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CheckBox_Check_Balance
        '
        Me.CheckBox_Check_Balance.AutoSize = True
        Me.CheckBox_Check_Balance.Location = New System.Drawing.Point(18, 115)
        Me.CheckBox_Check_Balance.Name = "CheckBox_Check_Balance"
        Me.CheckBox_Check_Balance.Size = New System.Drawing.Size(228, 17)
        Me.CheckBox_Check_Balance.TabIndex = 2
        Me.CheckBox_Check_Balance.Text = "ปรับให้มีเงื่อนไขเช็คยอดปิดรอบให้ balance"
        Me.CheckBox_Check_Balance.UseVisualStyleBackColor = True
        '
        'CheckBox_Print_N0
        '
        Me.CheckBox_Print_N0.AutoSize = True
        Me.CheckBox_Print_N0.Location = New System.Drawing.Point(18, 69)
        Me.CheckBox_Print_N0.Name = "CheckBox_Print_N0"
        Me.CheckBox_Print_N0.Size = New System.Drawing.Size(121, 17)
        Me.CheckBox_Print_N0.TabIndex = 0
        Me.CheckBox_Print_N0.Text = "ปริ้นสริปสรุป รอบวัน"
        Me.CheckBox_Print_N0.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lang_payment)
        Me.GroupBox1.Controls.Add(Me.lang_trybill)
        Me.GroupBox1.Controls.Add(Me.lang_sendcaptain)
        Me.GroupBox1.Controls.Add(Me.onoff_alertsendcaptain)
        Me.GroupBox1.Controls.Add(Me.CheckBox_Print_inventory)
        Me.GroupBox1.Controls.Add(Me.CheckBox_Print_N1_1)
        Me.GroupBox1.Controls.Add(Me.CheckBox_Print_N0_1)
        Me.GroupBox1.Controls.Add(Me.CheckBox_Print_N1)
        Me.GroupBox1.Controls.Add(Me.CheckBox_Check_Balance)
        Me.GroupBox1.Controls.Add(Me.CheckBox_Print_N0)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(286, 264)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "กำหนดใช้งานระบบปิดรอบวัน"
        '
        'lang_sendcaptain
        '
        Me.lang_sendcaptain.AutoSize = True
        Me.lang_sendcaptain.Location = New System.Drawing.Point(18, 184)
        Me.lang_sendcaptain.Name = "lang_sendcaptain"
        Me.lang_sendcaptain.Size = New System.Drawing.Size(207, 17)
        Me.lang_sendcaptain.TabIndex = 8
        Me.lang_sendcaptain.Text = "เปิด/ปิด Dialogเปลี่ยนภาษาของเข้าครัว"
        Me.lang_sendcaptain.UseVisualStyleBackColor = True
        '
        'onoff_alertsendcaptain
        '
        Me.onoff_alertsendcaptain.AutoSize = True
        Me.onoff_alertsendcaptain.Location = New System.Drawing.Point(18, 161)
        Me.onoff_alertsendcaptain.Name = "onoff_alertsendcaptain"
        Me.onoff_alertsendcaptain.Size = New System.Drawing.Size(186, 17)
        Me.onoff_alertsendcaptain.TabIndex = 7
        Me.onoff_alertsendcaptain.Text = "เปิด/ปิด แจ้งเตือนส่งครัวเรียบร้อย"
        Me.onoff_alertsendcaptain.UseVisualStyleBackColor = True
        '
        'CheckBox_Print_inventory
        '
        Me.CheckBox_Print_inventory.AutoSize = True
        Me.CheckBox_Print_inventory.Location = New System.Drawing.Point(18, 138)
        Me.CheckBox_Print_inventory.Name = "CheckBox_Print_inventory"
        Me.CheckBox_Print_inventory.Size = New System.Drawing.Size(160, 17)
        Me.CheckBox_Print_inventory.TabIndex = 6
        Me.CheckBox_Print_inventory.Text = "สั่งพิมพ์ Inventory รายรอบบิล"
        Me.CheckBox_Print_inventory.UseVisualStyleBackColor = True
        '
        'CheckBox_Print_N1_1
        '
        Me.CheckBox_Print_N1_1.AutoSize = True
        Me.CheckBox_Print_N1_1.Location = New System.Drawing.Point(18, 44)
        Me.CheckBox_Print_N1_1.Name = "CheckBox_Print_N1_1"
        Me.CheckBox_Print_N1_1.Size = New System.Drawing.Size(258, 17)
        Me.CheckBox_Print_N1_1.TabIndex = 5
        Me.CheckBox_Print_N1_1.Text = "ปริ้นสริปยอดขายประจำกะ แบบแจกแจง ปิดรอบกะ"
        Me.CheckBox_Print_N1_1.UseVisualStyleBackColor = True
        '
        'CheckBox_Print_N0_1
        '
        Me.CheckBox_Print_N0_1.AutoSize = True
        Me.CheckBox_Print_N0_1.Location = New System.Drawing.Point(18, 21)
        Me.CheckBox_Print_N0_1.Name = "CheckBox_Print_N0_1"
        Me.CheckBox_Print_N0_1.Size = New System.Drawing.Size(119, 17)
        Me.CheckBox_Print_N0_1.TabIndex = 4
        Me.CheckBox_Print_N0_1.Text = "ปริ้นสริปสรุป รอบกะ"
        Me.CheckBox_Print_N0_1.UseVisualStyleBackColor = True
        '
        'CheckBox_Print_N1
        '
        Me.CheckBox_Print_N1.AutoSize = True
        Me.CheckBox_Print_N1.Location = New System.Drawing.Point(18, 92)
        Me.CheckBox_Print_N1.Name = "CheckBox_Print_N1"
        Me.CheckBox_Print_N1.Size = New System.Drawing.Size(262, 17)
        Me.CheckBox_Print_N1.TabIndex = 3
        Me.CheckBox_Print_N1.Text = "ปริ้นสริปยอดขายประจำวัน แบบแจกแจง ปิดรอบวัน"
        Me.CheckBox_Print_N1.UseVisualStyleBackColor = True
        '
        'save
        '
        Me.save.Image = Global.BeecomePOS.My.Resources.Resources.save_16
        Me.save.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.save.Location = New System.Drawing.Point(78, 282)
        Me.save.Name = "save"
        Me.save.Size = New System.Drawing.Size(148, 30)
        Me.save.TabIndex = 13
        Me.save.Text = "Save"
        Me.save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.save.UseVisualStyleBackColor = True
        '
        'lang_trybill
        '
        Me.lang_trybill.AutoSize = True
        Me.lang_trybill.Location = New System.Drawing.Point(18, 207)
        Me.lang_trybill.Name = "lang_trybill"
        Me.lang_trybill.Size = New System.Drawing.Size(200, 17)
        Me.lang_trybill.TabIndex = 9
        Me.lang_trybill.Text = "เปิด/ปิด Dialogเปลี่ยนภาษาของTryBill"
        Me.lang_trybill.UseVisualStyleBackColor = True
        '
        'lang_payment
        '
        Me.lang_payment.AutoSize = True
        Me.lang_payment.Location = New System.Drawing.Point(18, 230)
        Me.lang_payment.Name = "lang_payment"
        Me.lang_payment.Size = New System.Drawing.Size(229, 17)
        Me.lang_payment.TabIndex = 10
        Me.lang_payment.Text = "เปิด/ปิด Dialogเปลี่ยนภาษาของเข้าPayment"
        Me.lang_payment.UseVisualStyleBackColor = True
        '
        'Admin_ConfigCloseDay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(302, 322)
        Me.Controls.Add(Me.save)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Admin_ConfigCloseDay"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Config Close Day"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents save As System.Windows.Forms.Button
    Friend WithEvents CheckBox_Check_Balance As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox_Print_N0 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBox_Print_N1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox_Print_N1_1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox_Print_N0_1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox_Print_inventory As System.Windows.Forms.CheckBox
    Friend WithEvents onoff_alertsendcaptain As System.Windows.Forms.CheckBox
    Friend WithEvents lang_sendcaptain As System.Windows.Forms.CheckBox
    Friend WithEvents lang_payment As System.Windows.Forms.CheckBox
    Friend WithEvents lang_trybill As System.Windows.Forms.CheckBox
End Class
