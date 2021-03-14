<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class stock_index
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(stock_index))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.recript = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.hit_recript = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.stock_card = New System.Windows.Forms.ToolStripButton()
        Me.logout = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip2 = New System.Windows.Forms.StatusStrip()
        Me.db_name = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.company_name = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.user_show = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.recript, Me.ToolStripSeparator1, Me.hit_recript, Me.ToolStripSeparator2, Me.stock_card, Me.logout})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(754, 57)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'recript
        '
        Me.recript.Image = Global.BeecomePOS.My.Resources.Resources.btn_sel1
        Me.recript.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.recript.Margin = New System.Windows.Forms.Padding(10, 1, 0, 2)
        Me.recript.Name = "recript"
        Me.recript.Size = New System.Drawing.Size(73, 54)
        Me.recript.Text = "รับของเข้า"
        Me.recript.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 57)
        '
        'hit_recript
        '
        Me.hit_recript.Image = Global.BeecomePOS.My.Resources.Resources.clipboard_32
        Me.hit_recript.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.hit_recript.Name = "hit_recript"
        Me.hit_recript.Size = New System.Drawing.Size(112, 54)
        Me.hit_recript.Text = "ประวัติการรับของ"
        Me.hit_recript.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ToolStripSeparator2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 57)
        '
        'stock_card
        '
        Me.stock_card.Image = Global.BeecomePOS.My.Resources.Resources.flag_32
        Me.stock_card.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.stock_card.Name = "stock_card"
        Me.stock_card.Size = New System.Drawing.Size(53, 54)
        Me.stock_card.Text = "คงคลัง"
        Me.stock_card.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'logout
        '
        Me.logout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.logout.Image = Global.BeecomePOS.My.Resources.Resources.m_logout
        Me.logout.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.logout.Name = "logout"
        Me.logout.Size = New System.Drawing.Size(94, 54)
        Me.logout.Text = "ออกจากระบบ"
        Me.logout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'StatusStrip2
        '
        Me.StatusStrip2.BackColor = System.Drawing.SystemColors.Control
        Me.StatusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.db_name, Me.ToolStripStatusLabel4, Me.company_name, Me.ToolStripStatusLabel5, Me.user_show, Me.ToolStripStatusLabel1})
        Me.StatusStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.StatusStrip2.Location = New System.Drawing.Point(0, 442)
        Me.StatusStrip2.Name = "StatusStrip2"
        Me.StatusStrip2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StatusStrip2.Size = New System.Drawing.Size(754, 22)
        Me.StatusStrip2.TabIndex = 11
        Me.StatusStrip2.Text = "StatusStrip2"
        '
        'db_name
        '
        Me.db_name.Image = Global.BeecomePOS.My.Resources.Resources.Datbase_Lock
        Me.db_name.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.db_name.Name = "db_name"
        Me.db_name.Size = New System.Drawing.Size(116, 17)
        Me.db_name.Text = "DB.Name : DEMO"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(10, 17)
        Me.ToolStripStatusLabel4.Text = "|"
        '
        'company_name
        '
        Me.company_name.Image = Global.BeecomePOS.My.Resources.Resources.Computer_Add
        Me.company_name.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.company_name.Name = "company_name"
        Me.company_name.Size = New System.Drawing.Size(182, 17)
        Me.company_name.Text = "Company Name :  DEMO .,Ltd"
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(11, 17)
        Me.ToolStripStatusLabel5.Text = "|"
        '
        'user_show
        '
        Me.user_show.Image = Global.BeecomePOS.My.Resources.Resources.User__2_
        Me.user_show.Name = "user_show"
        Me.user_show.Size = New System.Drawing.Size(202, 17)
        Me.user_show.Text = "Username : TESTTER (Login 00:15)"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolStripStatusLabel1.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        '
        'stock_index
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(754, 464)
        Me.Controls.Add(Me.StatusStrip2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "stock_index"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Management Stock"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip2.ResumeLayout(False)
        Me.StatusStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents recript As System.Windows.Forms.ToolStripButton
    Friend WithEvents hit_recript As System.Windows.Forms.ToolStripButton
    Friend WithEvents stock_card As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents logout As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStrip2 As System.Windows.Forms.StatusStrip
    Friend WithEvents db_name As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents company_name As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel5 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents user_show As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
End Class
