<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_ReportInputParameter4
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node3")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node4")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node5")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node6")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node0", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3, TreeNode4})
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node7")
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node8")
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node9")
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node1", New System.Windows.Forms.TreeNode() {TreeNode6, TreeNode7, TreeNode8})
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node10")
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node11")
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node12")
        Dim TreeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node13")
        Dim TreeNode14 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node2", New System.Windows.Forms.TreeNode() {TreeNode10, TreeNode11, TreeNode12, TreeNode13})
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.btn_cancel = New System.Windows.Forms.Button()
        Me.btn_ok = New System.Windows.Forms.Button()
        Me.DateTimePicker_End = New System.Windows.Forms.DateTimePicker()
        Me.SuspendLayout()
        '
        'TreeView1
        '
        Me.TreeView1.BackColor = System.Drawing.SystemColors.Window
        Me.TreeView1.CheckBoxes = True
        Me.TreeView1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Left
        Me.TreeView1.Location = New System.Drawing.Point(0, 0)
        Me.TreeView1.Name = "TreeView1"
        TreeNode1.Name = "Node3"
        TreeNode1.Text = "Node3"
        TreeNode2.Name = "Node4"
        TreeNode2.Text = "Node4"
        TreeNode3.Name = "Node5"
        TreeNode3.Text = "Node5"
        TreeNode4.Name = "Node6"
        TreeNode4.Text = "Node6"
        TreeNode5.Name = "Node0"
        TreeNode5.Text = "Node0"
        TreeNode6.Name = "Node7"
        TreeNode6.Text = "Node7"
        TreeNode7.Name = "Node8"
        TreeNode7.Text = "Node8"
        TreeNode8.Name = "Node9"
        TreeNode8.Text = "Node9"
        TreeNode9.Name = "Node1"
        TreeNode9.Text = "Node1"
        TreeNode10.Name = "Node10"
        TreeNode10.Text = "Node10"
        TreeNode11.Name = "Node11"
        TreeNode11.Text = "Node11"
        TreeNode12.Name = "Node12"
        TreeNode12.Text = "Node12"
        TreeNode13.Name = "Node13"
        TreeNode13.Text = "Node13"
        TreeNode14.Name = "Node2"
        TreeNode14.Text = "Node2"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode5, TreeNode9, TreeNode14})
        Me.TreeView1.Size = New System.Drawing.Size(288, 404)
        Me.TreeView1.TabIndex = 17
        '
        'btn_cancel
        '
        Me.btn_cancel.Location = New System.Drawing.Point(291, 41)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(86, 23)
        Me.btn_cancel.TabIndex = 15
        Me.btn_cancel.Text = "Cancel"
        Me.btn_cancel.UseVisualStyleBackColor = True
        '
        'btn_ok
        '
        Me.btn_ok.Location = New System.Drawing.Point(291, 12)
        Me.btn_ok.Name = "btn_ok"
        Me.btn_ok.Size = New System.Drawing.Size(86, 23)
        Me.btn_ok.TabIndex = 14
        Me.btn_ok.Text = "OK"
        Me.btn_ok.UseVisualStyleBackColor = True
        '
        'DateTimePicker_End
        '
        Me.DateTimePicker_End.CustomFormat = "dd/MM/yyyy HH:mm:ss"
        Me.DateTimePicker_End.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker_End.Location = New System.Drawing.Point(294, 78)
        Me.DateTimePicker_End.Name = "DateTimePicker_End"
        Me.DateTimePicker_End.Size = New System.Drawing.Size(0, 20)
        Me.DateTimePicker_End.TabIndex = 13
        '
        'Admin_ReportInputParameter4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(382, 404)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.btn_cancel)
        Me.Controls.Add(Me.btn_ok)
        Me.Controls.Add(Me.DateTimePicker_End)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Admin_ReportInputParameter4"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Print Product"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents btn_cancel As System.Windows.Forms.Button
    Friend WithEvents btn_ok As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker_End As System.Windows.Forms.DateTimePicker
End Class
