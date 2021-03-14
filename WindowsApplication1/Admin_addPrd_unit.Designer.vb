<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_addprd_unit
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
        Me.btn_cancle_unit = New System.Windows.Forms.Button()
        Me.btn_select_unit = New System.Windows.Forms.Button()
        Me.CheckedListBox_unit = New System.Windows.Forms.CheckedListBox()
        Me.SuspendLayout()
        '
        'btn_cancle_unit
        '
        Me.btn_cancle_unit.Image = Global.BeecomePOS.My.Resources.Resources.delete_16
        Me.btn_cancle_unit.Location = New System.Drawing.Point(127, 260)
        Me.btn_cancle_unit.Name = "btn_cancle_unit"
        Me.btn_cancle_unit.Size = New System.Drawing.Size(75, 23)
        Me.btn_cancle_unit.TabIndex = 5
        Me.btn_cancle_unit.Text = "Cancel"
        Me.btn_cancle_unit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_cancle_unit.UseVisualStyleBackColor = True
        '
        'btn_select_unit
        '
        Me.btn_select_unit.Image = Global.BeecomePOS.My.Resources.Resources.tick_16
        Me.btn_select_unit.Location = New System.Drawing.Point(46, 260)
        Me.btn_select_unit.Name = "btn_select_unit"
        Me.btn_select_unit.Size = New System.Drawing.Size(75, 23)
        Me.btn_select_unit.TabIndex = 4
        Me.btn_select_unit.Text = "Select"
        Me.btn_select_unit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_select_unit.UseVisualStyleBackColor = True
        '
        'CheckedListBox_unit
        '
        Me.CheckedListBox_unit.Dock = System.Windows.Forms.DockStyle.Top
        Me.CheckedListBox_unit.FormattingEnabled = True
        Me.CheckedListBox_unit.Location = New System.Drawing.Point(0, 0)
        Me.CheckedListBox_unit.Name = "CheckedListBox_unit"
        Me.CheckedListBox_unit.Size = New System.Drawing.Size(236, 109)
        Me.CheckedListBox_unit.TabIndex = 3
        '
        'Admin_addprd_unit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(236, 283)
        Me.Controls.Add(Me.btn_cancle_unit)
        Me.Controls.Add(Me.btn_select_unit)
        Me.Controls.Add(Me.CheckedListBox_unit)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Admin_addprd_unit"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Unit Product"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_cancle_unit As System.Windows.Forms.Button
    Friend WithEvents btn_select_unit As System.Windows.Forms.Button
    Friend WithEvents CheckedListBox_unit As System.Windows.Forms.CheckedListBox
End Class
