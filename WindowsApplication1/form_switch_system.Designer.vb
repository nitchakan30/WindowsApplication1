<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_switch_system
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(form_switch_system))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btn_config = New System.Windows.Forms.Button()
        Me.btn_sale = New System.Windows.Forms.Button()
        Me.btn_setting_back = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Image = Global.BeecomePOS.My.Resources.Resources.delete_161
        Me.Button1.Location = New System.Drawing.Point(98, 273)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(160, 46)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "close"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btn_config
        '
        Me.btn_config.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_config.Image = Global.BeecomePOS.My.Resources.Resources.inven45
        Me.btn_config.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_config.Location = New System.Drawing.Point(12, 99)
        Me.btn_config.Name = "btn_config"
        Me.btn_config.Size = New System.Drawing.Size(332, 82)
        Me.btn_config.TabIndex = 1
        Me.btn_config.Text = "คลังสินค้า / Inventory"
        Me.btn_config.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_config.UseVisualStyleBackColor = True
        '
        'btn_sale
        '
        Me.btn_sale.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_sale.Image = Global.BeecomePOS.My.Resources.Resources.buy_32
        Me.btn_sale.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_sale.Location = New System.Drawing.Point(12, 12)
        Me.btn_sale.Name = "btn_sale"
        Me.btn_sale.Size = New System.Drawing.Size(332, 81)
        Me.btn_sale.TabIndex = 0
        Me.btn_sale.Text = "ระบบขายหน้าร้าน / POS"
        Me.btn_sale.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_sale.UseVisualStyleBackColor = True
        '
        'btn_setting_back
        '
        Me.btn_setting_back.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_setting_back.Image = Global.BeecomePOS.My.Resources.Resources.gear_32
        Me.btn_setting_back.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_setting_back.Location = New System.Drawing.Point(12, 187)
        Me.btn_setting_back.Name = "btn_setting_back"
        Me.btn_setting_back.Size = New System.Drawing.Size(332, 82)
        Me.btn_setting_back.TabIndex = 2
        Me.btn_setting_back.Text = "ตั้งค่าระบบ / Setting"
        Me.btn_setting_back.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_setting_back.UseVisualStyleBackColor = True
        '
        'form_switch_system
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(356, 322)
        Me.ControlBox = False
        Me.Controls.Add(Me.btn_setting_back)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btn_config)
        Me.Controls.Add(Me.btn_sale)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "form_switch_system"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Selected System"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_sale As System.Windows.Forms.Button
    Friend WithEvents btn_config As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btn_setting_back As System.Windows.Forms.Button
End Class
