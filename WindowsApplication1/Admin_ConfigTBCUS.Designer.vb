<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_ConfigTBCUS
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
        Me.components = New System.ComponentModel.Container()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.DeleteBTN = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DelBtn = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeletePIC = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PicDel = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.TabControl_Locat = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FontSettingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.manageTB = New System.Windows.Forms.ToolStripButton()
        Me.addText = New System.Windows.Forms.ToolStripButton()
        Me.addPicture = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.btnSaveLayout = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1.SuspendLayout()
        Me.DeleteBTN.SuspendLayout()
        Me.DeletePIC.SuspendLayout()
        Me.TabControl_Locat.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(45, 45)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.manageTB, Me.addText, Me.addPicture, Me.ToolStripButton4, Me.btnSaveLayout})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(73, 553)
        Me.ToolStrip1.TabIndex = 7
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'DeleteBTN
        '
        Me.DeleteBTN.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FontSettingToolStripMenuItem, Me.ColorToolStripMenuItem, Me.DelBtn})
        Me.DeleteBTN.Name = "DeleteBTN"
        Me.DeleteBTN.Size = New System.Drawing.Size(108, 70)
        '
        'DelBtn
        '
        Me.DelBtn.Name = "DelBtn"
        Me.DelBtn.Size = New System.Drawing.Size(107, 22)
        Me.DelBtn.Text = "Delete"
        '
        'DeletePIC
        '
        Me.DeletePIC.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicDel})
        Me.DeletePIC.Name = "DeletePIC"
        Me.DeletePIC.Size = New System.Drawing.Size(108, 26)
        '
        'PicDel
        '
        Me.PicDel.Name = "PicDel"
        Me.PicDel.Size = New System.Drawing.Size(107, 22)
        Me.PicDel.Text = "Delete"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.AutoSize = False
        Me.ToolStrip2.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.Left
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.Location = New System.Drawing.Point(73, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(209, 553)
        Me.ToolStrip2.TabIndex = 9
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'TabControl_Locat
        '
        Me.TabControl_Locat.Controls.Add(Me.TabPage1)
        Me.TabControl_Locat.Controls.Add(Me.TabPage2)
        Me.TabControl_Locat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl_Locat.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TabControl_Locat.Location = New System.Drawing.Point(282, 0)
        Me.TabControl_Locat.Margin = New System.Windows.Forms.Padding(5)
        Me.TabControl_Locat.Name = "TabControl_Locat"
        Me.TabControl_Locat.Padding = New System.Drawing.Point(10, 5)
        Me.TabControl_Locat.SelectedIndex = 0
        Me.TabControl_Locat.Size = New System.Drawing.Size(638, 553)
        Me.TabControl_Locat.TabIndex = 10
        '
        'TabPage1
        '
        Me.TabPage1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 31)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(630, 518)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "พื้นที่ด้านใน"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 31)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(442, 518)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "ริมสระน้ำ"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(85, 254)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(189, 33)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Blank Space"
        '
        'FontSettingToolStripMenuItem
        '
        Me.FontSettingToolStripMenuItem.Name = "FontSettingToolStripMenuItem"
        Me.FontSettingToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.FontSettingToolStripMenuItem.Text = "Font"
        '
        'ColorToolStripMenuItem
        '
        Me.ColorToolStripMenuItem.Name = "ColorToolStripMenuItem"
        Me.ColorToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.ColorToolStripMenuItem.Text = "Color"
        '
        'manageTB
        '
        Me.manageTB.Image = Global.BeecomePOS.My.Resources.Resources.tb22
        Me.manageTB.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.manageTB.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.manageTB.Name = "manageTB"
        Me.manageTB.Size = New System.Drawing.Size(70, 51)
        Me.manageTB.Text = "เพิ่มโต๊ะ"
        Me.manageTB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'addText
        '
        Me.addText.Image = Global.BeecomePOS.My.Resources.Resources.pencil_321
        Me.addText.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.addText.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.addText.Name = "addText"
        Me.addText.Size = New System.Drawing.Size(70, 51)
        Me.addText.Text = "เพิ่ม ข้อความ"
        Me.addText.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'addPicture
        '
        Me.addPicture.Image = Global.BeecomePOS.My.Resources.Resources.iphoto
        Me.addPicture.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.addPicture.Name = "addPicture"
        Me.addPicture.Size = New System.Drawing.Size(70, 64)
        Me.addPicture.Text = "เพิ่มรูป"
        Me.addPicture.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.addPicture.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton4.Image = Global.BeecomePOS.My.Resources.Resources.delete_32
        Me.ToolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(70, 51)
        Me.ToolStripButton4.Text = "ยกเลิก"
        Me.ToolStripButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnSaveLayout
        '
        Me.btnSaveLayout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnSaveLayout.Image = Global.BeecomePOS.My.Resources.Resources.save_32
        Me.btnSaveLayout.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnSaveLayout.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSaveLayout.Name = "btnSaveLayout"
        Me.btnSaveLayout.Size = New System.Drawing.Size(70, 51)
        Me.btnSaveLayout.Text = "บันทึก"
        Me.btnSaveLayout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Admin_ConfigTBCUS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(920, 553)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TabControl_Locat)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Admin_ConfigTBCUS"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "จัดการออกแบบโต๊ะอาหารเอง"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.DeleteBTN.ResumeLayout(False)
        Me.DeletePIC.ResumeLayout(False)
        Me.TabControl_Locat.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents manageTB As System.Windows.Forms.ToolStripButton
    Friend WithEvents addText As System.Windows.Forms.ToolStripButton
    Friend WithEvents addPicture As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSaveLayout As System.Windows.Forms.ToolStripButton
    Friend WithEvents DeleteBTN As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DelBtn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeletePIC As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents PicDel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents TabControl_Locat As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FontSettingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
End Class
