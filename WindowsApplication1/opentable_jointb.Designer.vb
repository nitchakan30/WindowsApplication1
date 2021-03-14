<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class opentable_jointb
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(opentable_jointb))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnclose = New System.Windows.Forms.Button()
        Me.btn_jointb = New System.Windows.Forms.Button()
        Me.btn_select = New System.Windows.Forms.Button()
        Me.btn_drow = New System.Windows.Forms.Button()
        Me.btn_up = New System.Windows.Forms.Button()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.GroupBox2.Controls.Add(Me.btnclose)
        Me.GroupBox2.Controls.Add(Me.btn_jointb)
        Me.GroupBox2.Controls.Add(Me.btn_select)
        Me.GroupBox2.Controls.Add(Me.btn_drow)
        Me.GroupBox2.Controls.Add(Me.btn_up)
        Me.GroupBox2.Controls.Add(Me.TabControl2)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(604, 510)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Selected Table Sec (เลือกโต๊ะรอง)"
        '
        'btnclose
        '
        Me.btnclose.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnclose.Image = Global.BeecomePOS.My.Resources.Resources.cross
        Me.btnclose.Location = New System.Drawing.Point(322, 445)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(273, 61)
        Me.btnclose.TabIndex = 14
        Me.btnclose.Text = "Close (ปิดหน้าจอ)"
        Me.btnclose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnclose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnclose.UseVisualStyleBackColor = True
        '
        'btn_jointb
        '
        Me.btn_jointb.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_jointb.Image = Global.BeecomePOS.My.Resources.Resources.tb23
        Me.btn_jointb.Location = New System.Drawing.Point(322, 349)
        Me.btn_jointb.Name = "btn_jointb"
        Me.btn_jointb.Size = New System.Drawing.Size(273, 90)
        Me.btn_jointb.TabIndex = 13
        Me.btn_jointb.Text = "Join Table (รวมโต๊ะ)"
        Me.btn_jointb.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_jointb.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_jointb.UseVisualStyleBackColor = True
        '
        'btn_select
        '
        Me.btn_select.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_select.Image = Global.BeecomePOS.My.Resources.Resources.btn_ok
        Me.btn_select.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_select.Location = New System.Drawing.Point(326, 148)
        Me.btn_select.Name = "btn_select"
        Me.btn_select.Size = New System.Drawing.Size(273, 42)
        Me.btn_select.TabIndex = 11
        Me.btn_select.Text = "Selected"
        Me.btn_select.UseVisualStyleBackColor = True
        '
        'btn_drow
        '
        Me.btn_drow.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_drow.Image = Global.BeecomePOS.My.Resources.Resources.arrow_270
        Me.btn_drow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_drow.Location = New System.Drawing.Point(326, 95)
        Me.btn_drow.Name = "btn_drow"
        Me.btn_drow.Size = New System.Drawing.Size(273, 42)
        Me.btn_drow.TabIndex = 10
        Me.btn_drow.Text = "DOWN"
        Me.btn_drow.UseVisualStyleBackColor = True
        '
        'btn_up
        '
        Me.btn_up.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_up.Image = Global.BeecomePOS.My.Resources.Resources.arrow_0901
        Me.btn_up.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_up.Location = New System.Drawing.Point(326, 43)
        Me.btn_up.Name = "btn_up"
        Me.btn_up.Size = New System.Drawing.Size(273, 42)
        Me.btn_up.TabIndex = 9
        Me.btn_up.Text = "UP"
        Me.btn_up.UseVisualStyleBackColor = True
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.TabPage3)
        Me.TabControl2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TabControl2.Location = New System.Drawing.Point(3, 20)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(317, 487)
        Me.TabControl2.TabIndex = 1
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.CheckedListBox1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 29)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(309, 454)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.Tag = "All"
        Me.TabPage3.Text = "All"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Location = New System.Drawing.Point(3, 3)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(303, 448)
        Me.CheckedListBox1.TabIndex = 0
        '
        'opentable_jointb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(604, 510)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "opentable_jointb"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "หน้าจอการรวมโต๊ะอาหาร"
        Me.GroupBox2.ResumeLayout(False)
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents btn_jointb As System.Windows.Forms.Button
    Friend WithEvents btn_select As System.Windows.Forms.Button
    Friend WithEvents btn_drow As System.Windows.Forms.Button
    Friend WithEvents btn_up As System.Windows.Forms.Button
    Friend WithEvents btnclose As System.Windows.Forms.Button
    Friend WithEvents CheckedListBox1 As System.Windows.Forms.CheckedListBox
End Class
