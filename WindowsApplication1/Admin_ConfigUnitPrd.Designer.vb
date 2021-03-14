<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_ConfigUnitPrd
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
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btn_autoID = New System.Windows.Forms.PictureBox()
        Me.btn_save = New System.Windows.Forms.Button()
        Me.btn_cancle = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_name_en = New System.Windows.Forms.TextBox()
        Me.txt_name_th = New System.Windows.Forms.TextBox()
        Me.txt_code = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.btn_edit = New System.Windows.Forms.Button()
        Me.btn_add = New System.Windows.Forms.Button()
        Me.btn_del = New System.Windows.Forms.Button()
        Me.id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage1.SuspendLayout()
        CType(Me.btn_autoID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.ListView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.id, Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(0, 163)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(657, 343)
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.DisplayIndex = 0
        Me.ColumnHeader1.Text = "No."
        Me.ColumnHeader1.Width = 45
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.DisplayIndex = 1
        Me.ColumnHeader2.Text = "CODE"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader2.Width = 80
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.DisplayIndex = 2
        Me.ColumnHeader3.Text = "UNIT Name [TH]"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader3.Width = 150
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.DisplayIndex = 3
        Me.ColumnHeader4.Text = "UNIT Name [EN]"
        Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader4.Width = 150
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btn_autoID)
        Me.TabPage1.Controls.Add(Me.btn_save)
        Me.TabPage1.Controls.Add(Me.btn_cancle)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.txt_name_en)
        Me.TabPage1.Controls.Add(Me.txt_name_th)
        Me.TabPage1.Controls.Add(Me.txt_code)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(649, 92)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Add Unit Product"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btn_autoID
        '
        Me.btn_autoID.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_autoID.Image = Global.BeecomePOS.My.Resources.Resources.Ok
        Me.btn_autoID.Location = New System.Drawing.Point(112, 18)
        Me.btn_autoID.Name = "btn_autoID"
        Me.btn_autoID.Size = New System.Drawing.Size(16, 18)
        Me.btn_autoID.TabIndex = 63
        Me.btn_autoID.TabStop = False
        '
        'btn_save
        '
        Me.btn_save.BackColor = System.Drawing.SystemColors.Control
        Me.btn_save.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_save.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_save.Image = Global.BeecomePOS.My.Resources.Resources.save_16
        Me.btn_save.Location = New System.Drawing.Point(562, 8)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(78, 33)
        Me.btn_save.TabIndex = 62
        Me.btn_save.Text = "Save"
        Me.btn_save.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_save.UseVisualStyleBackColor = False
        '
        'btn_cancle
        '
        Me.btn_cancle.BackColor = System.Drawing.SystemColors.Control
        Me.btn_cancle.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_cancle.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_cancle.Image = Global.BeecomePOS.My.Resources.Resources.delete_16
        Me.btn_cancle.Location = New System.Drawing.Point(562, 47)
        Me.btn_cancle.Name = "btn_cancle"
        Me.btn_cancle.Size = New System.Drawing.Size(78, 33)
        Me.btn_cancle.TabIndex = 61
        Me.btn_cancle.Text = "Cancle"
        Me.btn_cancle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_cancle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_cancle.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(134, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Unit Name [ EN ] :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(134, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Unit Name [ TH ] :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "CODE :"
        '
        'txt_name_en
        '
        Me.txt_name_en.BackColor = System.Drawing.Color.White
        Me.txt_name_en.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_name_en.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_name_en.Location = New System.Drawing.Point(227, 43)
        Me.txt_name_en.MaxLength = 30
        Me.txt_name_en.Name = "txt_name_en"
        Me.txt_name_en.Size = New System.Drawing.Size(283, 22)
        Me.txt_name_en.TabIndex = 1
        '
        'txt_name_th
        '
        Me.txt_name_th.BackColor = System.Drawing.Color.White
        Me.txt_name_th.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_name_th.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_name_th.Location = New System.Drawing.Point(227, 14)
        Me.txt_name_th.MaxLength = 30
        Me.txt_name_th.Name = "txt_name_th"
        Me.txt_name_th.Size = New System.Drawing.Size(283, 22)
        Me.txt_name_th.TabIndex = 1
        '
        'txt_code
        '
        Me.txt_code.BackColor = System.Drawing.Color.White
        Me.txt_code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_code.Location = New System.Drawing.Point(47, 16)
        Me.txt_code.MaxLength = 6
        Me.txt_code.Name = "txt_code"
        Me.txt_code.Size = New System.Drawing.Size(60, 20)
        Me.txt_code.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(657, 118)
        Me.TabControl1.TabIndex = 1
        '
        'btn_edit
        '
        Me.btn_edit.BackColor = System.Drawing.SystemColors.Control
        Me.btn_edit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_edit.Enabled = False
        Me.btn_edit.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_edit.Image = Global.BeecomePOS.My.Resources.Resources.pencil_16
        Me.btn_edit.Location = New System.Drawing.Point(87, 124)
        Me.btn_edit.Name = "btn_edit"
        Me.btn_edit.Size = New System.Drawing.Size(71, 33)
        Me.btn_edit.TabIndex = 62
        Me.btn_edit.Text = "Edit"
        Me.btn_edit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_edit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_edit.UseVisualStyleBackColor = False
        '
        'btn_add
        '
        Me.btn_add.BackColor = System.Drawing.SystemColors.Control
        Me.btn_add.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_add.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_add.Image = Global.BeecomePOS.My.Resources.Resources.plus_16
        Me.btn_add.Location = New System.Drawing.Point(3, 124)
        Me.btn_add.Name = "btn_add"
        Me.btn_add.Size = New System.Drawing.Size(78, 33)
        Me.btn_add.TabIndex = 60
        Me.btn_add.Text = "New"
        Me.btn_add.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_add.UseVisualStyleBackColor = False
        '
        'btn_del
        '
        Me.btn_del.BackColor = System.Drawing.SystemColors.Control
        Me.btn_del.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_del.Enabled = False
        Me.btn_del.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_del.Image = Global.BeecomePOS.My.Resources.Resources.minus1
        Me.btn_del.Location = New System.Drawing.Point(164, 124)
        Me.btn_del.Name = "btn_del"
        Me.btn_del.Size = New System.Drawing.Size(71, 33)
        Me.btn_del.TabIndex = 62
        Me.btn_del.Text = "Delete"
        Me.btn_del.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_del.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_del.UseVisualStyleBackColor = False
        '
        'id
        '
        Me.id.DisplayIndex = 4
        Me.id.Text = "id"
        Me.id.Width = 0
        '
        'Admin_ConfigUnitPrd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(657, 504)
        Me.Controls.Add(Me.btn_del)
        Me.Controls.Add(Me.btn_edit)
        Me.Controls.Add(Me.btn_add)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ListView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Admin_ConfigUnitPrd"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Setup Unit Product"
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.btn_autoID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents btn_edit As System.Windows.Forms.Button
    Friend WithEvents btn_add As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_name_en As System.Windows.Forms.TextBox
    Friend WithEvents txt_name_th As System.Windows.Forms.TextBox
    Friend WithEvents txt_code As System.Windows.Forms.TextBox
    Friend WithEvents btn_save As System.Windows.Forms.Button
    Friend WithEvents btn_cancle As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btn_autoID As System.Windows.Forms.PictureBox
    Friend WithEvents btn_del As System.Windows.Forms.Button
    Friend WithEvents id As System.Windows.Forms.ColumnHeader
End Class
