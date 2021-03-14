<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_ConfigNumRuning
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Admin_ConfigNumRuning))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txt_num_inv = New System.Windows.Forms.TextBox()
        Me.txt_day_inv = New System.Windows.Forms.TextBox()
        Me.CheckBox_Dinv = New System.Windows.Forms.CheckBox()
        Me.txt_month_inv = New System.Windows.Forms.TextBox()
        Me.CheckBox_Minv = New System.Windows.Forms.CheckBox()
        Me.txt_year_inv = New System.Windows.Forms.TextBox()
        Me.CheckBox_Yinv = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txt_num_rb = New System.Windows.Forms.TextBox()
        Me.txt_day_rb = New System.Windows.Forms.TextBox()
        Me.CheckBox_Drb = New System.Windows.Forms.CheckBox()
        Me.txt_month_rb = New System.Windows.Forms.TextBox()
        Me.CheckBox_Mrb = New System.Windows.Forms.CheckBox()
        Me.txt_year_rb = New System.Windows.Forms.TextBox()
        Me.CheckBox_Yrb = New System.Windows.Forms.CheckBox()
        Me.cancel = New System.Windows.Forms.Button()
        Me.save = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txt_num_inv)
        Me.GroupBox1.Controls.Add(Me.txt_day_inv)
        Me.GroupBox1.Controls.Add(Me.CheckBox_Dinv)
        Me.GroupBox1.Controls.Add(Me.txt_month_inv)
        Me.GroupBox1.Controls.Add(Me.CheckBox_Minv)
        Me.GroupBox1.Controls.Add(Me.txt_year_inv)
        Me.GroupBox1.Controls.Add(Me.CheckBox_Yinv)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(378, 79)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ใบเสร็จ"
        '
        'txt_num_inv
        '
        Me.txt_num_inv.Location = New System.Drawing.Point(236, 19)
        Me.txt_num_inv.MaxLength = 7
        Me.txt_num_inv.Name = "txt_num_inv"
        Me.txt_num_inv.Size = New System.Drawing.Size(119, 20)
        Me.txt_num_inv.TabIndex = 7
        Me.txt_num_inv.Text = "xxxxx"
        Me.txt_num_inv.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_day_inv
        '
        Me.txt_day_inv.Location = New System.Drawing.Point(150, 19)
        Me.txt_day_inv.MaxLength = 2
        Me.txt_day_inv.Name = "txt_day_inv"
        Me.txt_day_inv.Size = New System.Drawing.Size(48, 20)
        Me.txt_day_inv.TabIndex = 5
        Me.txt_day_inv.Text = "xx"
        Me.txt_day_inv.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CheckBox_Dinv
        '
        Me.CheckBox_Dinv.AutoSize = True
        Me.CheckBox_Dinv.Location = New System.Drawing.Point(150, 45)
        Me.CheckBox_Dinv.Name = "CheckBox_Dinv"
        Me.CheckBox_Dinv.Size = New System.Drawing.Size(48, 17)
        Me.CheckBox_Dinv.TabIndex = 4
        Me.CheckBox_Dinv.Text = "DAY"
        Me.CheckBox_Dinv.UseVisualStyleBackColor = True
        '
        'txt_month_inv
        '
        Me.txt_month_inv.Location = New System.Drawing.Point(78, 19)
        Me.txt_month_inv.MaxLength = 2
        Me.txt_month_inv.Name = "txt_month_inv"
        Me.txt_month_inv.Size = New System.Drawing.Size(66, 20)
        Me.txt_month_inv.TabIndex = 3
        Me.txt_month_inv.Text = "xx"
        Me.txt_month_inv.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CheckBox_Minv
        '
        Me.CheckBox_Minv.AutoSize = True
        Me.CheckBox_Minv.Location = New System.Drawing.Point(78, 45)
        Me.CheckBox_Minv.Name = "CheckBox_Minv"
        Me.CheckBox_Minv.Size = New System.Drawing.Size(66, 17)
        Me.CheckBox_Minv.TabIndex = 2
        Me.CheckBox_Minv.Text = "MONTH"
        Me.CheckBox_Minv.UseVisualStyleBackColor = True
        '
        'txt_year_inv
        '
        Me.txt_year_inv.Location = New System.Drawing.Point(17, 19)
        Me.txt_year_inv.MaxLength = 4
        Me.txt_year_inv.Name = "txt_year_inv"
        Me.txt_year_inv.Size = New System.Drawing.Size(55, 20)
        Me.txt_year_inv.TabIndex = 1
        Me.txt_year_inv.Text = "xxxx"
        Me.txt_year_inv.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CheckBox_Yinv
        '
        Me.CheckBox_Yinv.AutoSize = True
        Me.CheckBox_Yinv.Location = New System.Drawing.Point(17, 45)
        Me.CheckBox_Yinv.Name = "CheckBox_Yinv"
        Me.CheckBox_Yinv.Size = New System.Drawing.Size(55, 17)
        Me.CheckBox_Yinv.TabIndex = 0
        Me.CheckBox_Yinv.Text = "YEAR"
        Me.CheckBox_Yinv.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txt_num_rb)
        Me.GroupBox2.Controls.Add(Me.txt_day_rb)
        Me.GroupBox2.Controls.Add(Me.CheckBox_Drb)
        Me.GroupBox2.Controls.Add(Me.txt_month_rb)
        Me.GroupBox2.Controls.Add(Me.CheckBox_Mrb)
        Me.GroupBox2.Controls.Add(Me.txt_year_rb)
        Me.GroupBox2.Controls.Add(Me.CheckBox_Yrb)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 98)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(378, 81)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "รองบิล"
        '
        'txt_num_rb
        '
        Me.txt_num_rb.Location = New System.Drawing.Point(236, 19)
        Me.txt_num_rb.MaxLength = 7
        Me.txt_num_rb.Name = "txt_num_rb"
        Me.txt_num_rb.Size = New System.Drawing.Size(119, 20)
        Me.txt_num_rb.TabIndex = 7
        Me.txt_num_rb.Text = "xxxxx"
        Me.txt_num_rb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_day_rb
        '
        Me.txt_day_rb.Location = New System.Drawing.Point(150, 19)
        Me.txt_day_rb.MaxLength = 2
        Me.txt_day_rb.Name = "txt_day_rb"
        Me.txt_day_rb.Size = New System.Drawing.Size(48, 20)
        Me.txt_day_rb.TabIndex = 5
        Me.txt_day_rb.Text = "xx"
        Me.txt_day_rb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CheckBox_Drb
        '
        Me.CheckBox_Drb.AutoSize = True
        Me.CheckBox_Drb.Location = New System.Drawing.Point(150, 45)
        Me.CheckBox_Drb.Name = "CheckBox_Drb"
        Me.CheckBox_Drb.Size = New System.Drawing.Size(48, 17)
        Me.CheckBox_Drb.TabIndex = 4
        Me.CheckBox_Drb.Text = "DAY"
        Me.CheckBox_Drb.UseVisualStyleBackColor = True
        '
        'txt_month_rb
        '
        Me.txt_month_rb.Location = New System.Drawing.Point(78, 19)
        Me.txt_month_rb.MaxLength = 2
        Me.txt_month_rb.Name = "txt_month_rb"
        Me.txt_month_rb.Size = New System.Drawing.Size(66, 20)
        Me.txt_month_rb.TabIndex = 3
        Me.txt_month_rb.Text = "xx"
        Me.txt_month_rb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CheckBox_Mrb
        '
        Me.CheckBox_Mrb.AutoSize = True
        Me.CheckBox_Mrb.Location = New System.Drawing.Point(78, 45)
        Me.CheckBox_Mrb.Name = "CheckBox_Mrb"
        Me.CheckBox_Mrb.Size = New System.Drawing.Size(66, 17)
        Me.CheckBox_Mrb.TabIndex = 2
        Me.CheckBox_Mrb.Text = "MONTH"
        Me.CheckBox_Mrb.UseVisualStyleBackColor = True
        '
        'txt_year_rb
        '
        Me.txt_year_rb.Location = New System.Drawing.Point(17, 19)
        Me.txt_year_rb.MaxLength = 4
        Me.txt_year_rb.Name = "txt_year_rb"
        Me.txt_year_rb.Size = New System.Drawing.Size(55, 20)
        Me.txt_year_rb.TabIndex = 1
        Me.txt_year_rb.Text = "xxxx"
        Me.txt_year_rb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CheckBox_Yrb
        '
        Me.CheckBox_Yrb.AutoSize = True
        Me.CheckBox_Yrb.Location = New System.Drawing.Point(17, 45)
        Me.CheckBox_Yrb.Name = "CheckBox_Yrb"
        Me.CheckBox_Yrb.Size = New System.Drawing.Size(55, 17)
        Me.CheckBox_Yrb.TabIndex = 0
        Me.CheckBox_Yrb.Text = "YEAR"
        Me.CheckBox_Yrb.UseVisualStyleBackColor = True
        '
        'cancel
        '
        Me.cancel.Image = Global.BeecomePOS.My.Resources.Resources.delete_16
        Me.cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cancel.Location = New System.Drawing.Point(210, 185)
        Me.cancel.Name = "cancel"
        Me.cancel.Size = New System.Drawing.Size(75, 30)
        Me.cancel.TabIndex = 10
        Me.cancel.Text = "Cancel"
        Me.cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cancel.UseVisualStyleBackColor = True
        '
        'save
        '
        Me.save.Image = Global.BeecomePOS.My.Resources.Resources.save_16
        Me.save.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.save.Location = New System.Drawing.Point(129, 185)
        Me.save.Name = "save"
        Me.save.Size = New System.Drawing.Size(75, 30)
        Me.save.TabIndex = 9
        Me.save.Text = "Save"
        Me.save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.save.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(235, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "NUMBER RUNING"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(233, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "NUMBER RUNING"
        '
        'Admin_ConfigNumRuning
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(407, 227)
        Me.Controls.Add(Me.cancel)
        Me.Controls.Add(Me.save)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Admin_ConfigNumRuning"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "กำหนดรันเลขที่บิลต่างๆ"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_num_inv As System.Windows.Forms.TextBox
    Friend WithEvents txt_day_inv As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox_Dinv As System.Windows.Forms.CheckBox
    Friend WithEvents txt_month_inv As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox_Minv As System.Windows.Forms.CheckBox
    Friend WithEvents txt_year_inv As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox_Yinv As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_num_rb As System.Windows.Forms.TextBox
    Friend WithEvents txt_day_rb As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox_Drb As System.Windows.Forms.CheckBox
    Friend WithEvents txt_month_rb As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox_Mrb As System.Windows.Forms.CheckBox
    Friend WithEvents txt_year_rb As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox_Yrb As System.Windows.Forms.CheckBox
    Friend WithEvents save As System.Windows.Forms.Button
    Friend WithEvents cancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
