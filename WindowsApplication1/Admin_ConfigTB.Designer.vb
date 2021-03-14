<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_ConfigTB
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Admin_ConfigTB))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.zone_id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.num = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.number = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.zone = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.status = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ComboBox_zone = New System.Windows.Forms.ComboBox()
        Me.btn_new = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button_Save = New System.Windows.Forms.Button()
        Me.ComboBox_status = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActiveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DelItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(506, 457)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "เพิ่มจำนวนโต๊ะอาหาร"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ListView1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(4, 126)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(498, 327)
        Me.Panel2.TabIndex = 14
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.id, Me.zone_id, Me.num, Me.number, Me.zone, Me.status})
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(0, 0)
        Me.ListView1.Margin = New System.Windows.Forms.Padding(4)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(498, 327)
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'id
        '
        Me.id.Width = 0
        '
        'zone_id
        '
        Me.zone_id.DisplayIndex = 5
        Me.zone_id.Width = 0
        '
        'num
        '
        Me.num.DisplayIndex = 1
        Me.num.Text = "ลำดับ"
        '
        'number
        '
        Me.number.DisplayIndex = 2
        Me.number.Text = "เลขที่โต๊ะ"
        Me.number.Width = 146
        '
        'zone
        '
        Me.zone.DisplayIndex = 3
        Me.zone.Text = "โซน"
        Me.zone.Width = 157
        '
        'status
        '
        Me.status.DisplayIndex = 4
        Me.status.Text = "สถานะ"
        Me.status.Width = 92
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ComboBox_zone)
        Me.Panel1.Controls.Add(Me.btn_new)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.Button_Save)
        Me.Panel1.Controls.Add(Me.ComboBox_status)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(4, 26)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(498, 100)
        Me.Panel1.TabIndex = 13
        '
        'ComboBox_zone
        '
        Me.ComboBox_zone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_zone.Enabled = False
        Me.ComboBox_zone.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.ComboBox_zone.FormattingEnabled = True
        Me.ComboBox_zone.Location = New System.Drawing.Point(59, 48)
        Me.ComboBox_zone.Name = "ComboBox_zone"
        Me.ComboBox_zone.Size = New System.Drawing.Size(190, 26)
        Me.ComboBox_zone.TabIndex = 7
        '
        'btn_new
        '
        Me.btn_new.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_new.Image = Global.BeecomePOS.My.Resources.Resources.plus_16
        Me.btn_new.Location = New System.Drawing.Point(351, 4)
        Me.btn_new.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_new.Name = "btn_new"
        Me.btn_new.Size = New System.Drawing.Size(100, 28)
        Me.btn_new.TabIndex = 12
        Me.btn_new.Text = "New"
        Me.btn_new.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_new.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_new.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Button2.Image = Global.BeecomePOS.My.Resources.Resources.Forbidden
        Me.Button2.Location = New System.Drawing.Point(351, 65)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(100, 28)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Clear"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(61, 12)
        Me.TextBox1.MaxLength = 5
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(91, 24)
        Me.TextBox1.TabIndex = 3
        '
        'Button_Save
        '
        Me.Button_Save.Enabled = False
        Me.Button_Save.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Button_Save.Image = Global.BeecomePOS.My.Resources.Resources.save_16
        Me.Button_Save.Location = New System.Drawing.Point(351, 35)
        Me.Button_Save.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_Save.Name = "Button_Save"
        Me.Button_Save.Size = New System.Drawing.Size(100, 28)
        Me.Button_Save.TabIndex = 1
        Me.Button_Save.Text = "Save"
        Me.Button_Save.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button_Save.UseVisualStyleBackColor = True
        '
        'ComboBox_status
        '
        Me.ComboBox_status.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ComboBox_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_status.Enabled = False
        Me.ComboBox_status.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.ComboBox_status.FormattingEnabled = True
        Me.ComboBox_status.Items.AddRange(New Object() {"ปิด", "เปิด"})
        Me.ComboBox_status.Location = New System.Drawing.Point(231, 9)
        Me.ComboBox_status.Name = "ComboBox_status"
        Me.ComboBox_status.Size = New System.Drawing.Size(104, 26)
        Me.ComboBox_status.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 18)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "เลขโต๊ะ"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.Location = New System.Drawing.Point(173, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 18)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "สถานะ"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(21, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 18)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "โซน"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditItem, Me.ActiveToolStripMenuItem, Me.DelItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(131, 70)
        '
        'EditItem
        '
        Me.EditItem.Image = Global.BeecomePOS.My.Resources.Resources.pencil_16
        Me.EditItem.Name = "EditItem"
        Me.EditItem.Size = New System.Drawing.Size(130, 22)
        Me.EditItem.Text = "Edit"
        '
        'ActiveToolStripMenuItem
        '
        Me.ActiveToolStripMenuItem.Image = Global.BeecomePOS.My.Resources.Resources.tick_16
        Me.ActiveToolStripMenuItem.Name = "ActiveToolStripMenuItem"
        Me.ActiveToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.ActiveToolStripMenuItem.Text = "Active"
        Me.ActiveToolStripMenuItem.Visible = False
        '
        'DelItem
        '
        Me.DelItem.Image = Global.BeecomePOS.My.Resources.Resources.Forbidden
        Me.DelItem.Name = "DelItem"
        Me.DelItem.Size = New System.Drawing.Size(130, 22)
        Me.DelItem.Text = "Not Active"
        Me.DelItem.Visible = False
        '
        'Admin_ConfigTB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(506, 457)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Admin_ConfigTB"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "เพิ่มโต๊ะอาหาร"
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button_Save As System.Windows.Forms.Button
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents id As System.Windows.Forms.ColumnHeader
    Friend WithEvents number As System.Windows.Forms.ColumnHeader
    Friend WithEvents zone As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBox_zone As System.Windows.Forms.ComboBox
    Friend WithEvents num As System.Windows.Forms.ColumnHeader
    Friend WithEvents ComboBox_status As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents status As System.Windows.Forms.ColumnHeader
    Friend WithEvents zone_id As System.Windows.Forms.ColumnHeader
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DelItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn_new As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ActiveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
