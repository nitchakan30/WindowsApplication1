<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_Report_InputParameter1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Admin_Report_InputParameter1))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Radio_Day = New System.Windows.Forms.RadioButton()
        Me.Radio_Bill = New System.Windows.Forms.RadioButton()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ComboBox_Bill = New System.Windows.Forms.ComboBox()
        Me.title = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Image = Global.BeecomePOS.My.Resources.Resources.tick_16
        Me.Button1.Location = New System.Drawing.Point(54, 232)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 33)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Enter"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(36, 111)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker1.TabIndex = 1
        '
        'Radio_Day
        '
        Me.Radio_Day.AutoSize = True
        Me.Radio_Day.Checked = True
        Me.Radio_Day.Location = New System.Drawing.Point(44, 57)
        Me.Radio_Day.Name = "Radio_Day"
        Me.Radio_Day.Size = New System.Drawing.Size(57, 17)
        Me.Radio_Day.TabIndex = 2
        Me.Radio_Day.TabStop = True
        Me.Radio_Day.Text = "รายวัน"
        Me.Radio_Day.UseVisualStyleBackColor = True
        '
        'Radio_Bill
        '
        Me.Radio_Bill.AutoSize = True
        Me.Radio_Bill.Location = New System.Drawing.Point(162, 57)
        Me.Radio_Bill.Name = "Radio_Bill"
        Me.Radio_Bill.Size = New System.Drawing.Size(74, 17)
        Me.Radio_Bill.TabIndex = 3
        Me.Radio_Bill.Text = "รายรอบกะ"
        Me.Radio_Bill.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Image = Global.BeecomePOS.My.Resources.Resources.delete_16
        Me.Button2.Location = New System.Drawing.Point(140, 232)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 33)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Cancel"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "เลือก วัน/เดือน/ปี"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ComboBox_Bill)
        Me.GroupBox1.Location = New System.Drawing.Point(36, 151)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(212, 66)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "เลือกรอบกะ"
        '
        'ComboBox_Bill
        '
        Me.ComboBox_Bill.FormattingEnabled = True
        Me.ComboBox_Bill.Location = New System.Drawing.Point(6, 28)
        Me.ComboBox_Bill.Name = "ComboBox_Bill"
        Me.ComboBox_Bill.Size = New System.Drawing.Size(194, 21)
        Me.ComboBox_Bill.TabIndex = 0
        '
        'title
        '
        Me.title.AutoSize = True
        Me.title.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.title.Location = New System.Drawing.Point(10, 16)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(49, 16)
        Me.title.TabIndex = 7
        Me.title.Text = "Label2"
        '
        'Admin_Report_InputParameter1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(276, 273)
        Me.Controls.Add(Me.title)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Radio_Bill)
        Me.Controls.Add(Me.Radio_Day)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Button1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Admin_Report_InputParameter1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "แบบฟอร์มรับค่าสั่งพิมพ์"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Radio_Day As System.Windows.Forms.RadioButton
    Friend WithEvents Radio_Bill As System.Windows.Forms.RadioButton
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ComboBox_Bill As System.Windows.Forms.ComboBox
    Friend WithEvents title As System.Windows.Forms.Label
End Class
