<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_Report
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Admin_Report))
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.Panel_Rpt = New System.Windows.Forms.Panel()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btn_print = New System.Windows.Forms.Button()
        Me.btn_export = New System.Windows.Forms.Button()
        Me.btn_refrese = New System.Windows.Forms.Button()
        Me.nimi_s = New System.Windows.Forms.Button()
        Me.max_s = New System.Windows.Forms.Button()
        Me.btn_close = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Panel_Rpt.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TreeView1
        '
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView1.Location = New System.Drawing.Point(0, 0)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(208, 481)
        Me.TreeView1.TabIndex = 0
        '
        'Panel_Rpt
        '
        Me.Panel_Rpt.Controls.Add(Me.CrystalReportViewer1)
        Me.Panel_Rpt.Controls.Add(Me.Panel3)
        Me.Panel_Rpt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_Rpt.Location = New System.Drawing.Point(0, 0)
        Me.Panel_Rpt.Name = "Panel_Rpt"
        Me.Panel_Rpt.Size = New System.Drawing.Size(617, 481)
        Me.Panel_Rpt.TabIndex = 1
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 47)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(617, 434)
        Me.CrystalReportViewer1.TabIndex = 2
        Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btn_print)
        Me.Panel3.Controls.Add(Me.btn_export)
        Me.Panel3.Controls.Add(Me.btn_refrese)
        Me.Panel3.Controls.Add(Me.nimi_s)
        Me.Panel3.Controls.Add(Me.max_s)
        Me.Panel3.Controls.Add(Me.btn_close)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(617, 47)
        Me.Panel3.TabIndex = 1
        '
        'btn_print
        '
        Me.btn_print.Image = Global.BeecomePOS.My.Resources.Resources.print_32
        Me.btn_print.Location = New System.Drawing.Point(172, 4)
        Me.btn_print.Name = "btn_print"
        Me.btn_print.Size = New System.Drawing.Size(98, 39)
        Me.btn_print.TabIndex = 5
        Me.btn_print.Text = "พิมพ์"
        Me.btn_print.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_print.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_print.UseVisualStyleBackColor = True
        '
        'btn_export
        '
        Me.btn_export.Image = Global.BeecomePOS.My.Resources.Resources.arrow_curve
        Me.btn_export.Location = New System.Drawing.Point(92, 5)
        Me.btn_export.Name = "btn_export"
        Me.btn_export.Size = New System.Drawing.Size(75, 39)
        Me.btn_export.TabIndex = 4
        Me.btn_export.Text = "ส่งออก"
        Me.btn_export.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_export.UseVisualStyleBackColor = True
        '
        'btn_refrese
        '
        Me.btn_refrese.Image = Global.BeecomePOS.My.Resources.Resources.arrow_circle_double_135
        Me.btn_refrese.Location = New System.Drawing.Point(4, 5)
        Me.btn_refrese.Name = "btn_refrese"
        Me.btn_refrese.Size = New System.Drawing.Size(85, 39)
        Me.btn_refrese.TabIndex = 3
        Me.btn_refrese.Text = "รีเฟรช"
        Me.btn_refrese.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_refrese.UseVisualStyleBackColor = True
        '
        'nimi_s
        '
        Me.nimi_s.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nimi_s.FlatAppearance.BorderSize = 0
        Me.nimi_s.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.nimi_s.Image = Global.BeecomePOS.My.Resources.Resources.m_mini
        Me.nimi_s.Location = New System.Drawing.Point(521, 4)
        Me.nimi_s.Name = "nimi_s"
        Me.nimi_s.Size = New System.Drawing.Size(28, 30)
        Me.nimi_s.TabIndex = 2
        Me.nimi_s.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.nimi_s.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.nimi_s.UseVisualStyleBackColor = True
        '
        'max_s
        '
        Me.max_s.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.max_s.FlatAppearance.BorderSize = 0
        Me.max_s.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.max_s.Image = Global.BeecomePOS.My.Resources.Resources.m_maxsize
        Me.max_s.Location = New System.Drawing.Point(551, 5)
        Me.max_s.Name = "max_s"
        Me.max_s.Size = New System.Drawing.Size(28, 30)
        Me.max_s.TabIndex = 1
        Me.max_s.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.max_s.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.max_s.UseVisualStyleBackColor = True
        '
        'btn_close
        '
        Me.btn_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_close.FlatAppearance.BorderSize = 0
        Me.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_close.Image = Global.BeecomePOS.My.Resources.Resources.m_close
        Me.btn_close.Location = New System.Drawing.Point(580, 4)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.Size = New System.Drawing.Size(33, 30)
        Me.btn_close.TabIndex = 0
        Me.btn_close.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_close.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TreeView1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel_Rpt)
        Me.SplitContainer1.Size = New System.Drawing.Size(829, 481)
        Me.SplitContainer1.SplitterDistance = 208
        Me.SplitContainer1.TabIndex = 2
        '
        'Admin_Report
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(829, 481)
        Me.ControlBox = False
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Admin_Report"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "รายงานต่างๆ"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel_Rpt.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel_Rpt As System.Windows.Forms.Panel
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btn_close As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents nimi_s As System.Windows.Forms.Button
    Friend WithEvents max_s As System.Windows.Forms.Button
    Friend WithEvents btn_print As System.Windows.Forms.Button
    Friend WithEvents btn_export As System.Windows.Forms.Button
    Friend WithEvents btn_refrese As System.Windows.Forms.Button
    Public WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
