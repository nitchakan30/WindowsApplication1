<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_addPrd_Condit
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
        Me.CheckedListBox_Con = New System.Windows.Forms.CheckedListBox()
        Me.btn_select_indre = New System.Windows.Forms.Button()
        Me.btn_cancle_indre = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'CheckedListBox_Con
        '
        Me.CheckedListBox_Con.Dock = System.Windows.Forms.DockStyle.Top
        Me.CheckedListBox_Con.FormattingEnabled = True
        Me.CheckedListBox_Con.Location = New System.Drawing.Point(0, 0)
        Me.CheckedListBox_Con.Name = "CheckedListBox_Con"
        Me.CheckedListBox_Con.Size = New System.Drawing.Size(246, 259)
        Me.CheckedListBox_Con.TabIndex = 0
        '
        'btn_select_indre
        '
        Me.btn_select_indre.Image = Global.BeecomePOS.My.Resources.Resources.tick_16
        Me.btn_select_indre.Location = New System.Drawing.Point(46, 265)
        Me.btn_select_indre.Name = "btn_select_indre"
        Me.btn_select_indre.Size = New System.Drawing.Size(75, 23)
        Me.btn_select_indre.TabIndex = 1
        Me.btn_select_indre.Text = "Select"
        Me.btn_select_indre.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_select_indre.UseVisualStyleBackColor = True
        '
        'btn_cancle_indre
        '
        Me.btn_cancle_indre.Image = Global.BeecomePOS.My.Resources.Resources.delete_16
        Me.btn_cancle_indre.Location = New System.Drawing.Point(127, 265)
        Me.btn_cancle_indre.Name = "btn_cancle_indre"
        Me.btn_cancle_indre.Size = New System.Drawing.Size(75, 23)
        Me.btn_cancle_indre.TabIndex = 2
        Me.btn_cancle_indre.Text = "Cancel"
        Me.btn_cancle_indre.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_cancle_indre.UseVisualStyleBackColor = True
        '
        'Admin_addPrd_Condit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(246, 293)
        Me.Controls.Add(Me.btn_cancle_indre)
        Me.Controls.Add(Me.btn_select_indre)
        Me.Controls.Add(Me.CheckedListBox_Con)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Admin_addPrd_Condit"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Ingredients Food"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CheckedListBox_Con As System.Windows.Forms.CheckedListBox
    Friend WithEvents btn_select_indre As System.Windows.Forms.Button
    Friend WithEvents btn_cancle_indre As System.Windows.Forms.Button
End Class
