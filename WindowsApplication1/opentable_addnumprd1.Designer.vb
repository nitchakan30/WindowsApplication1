<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class opentable_addnumprd1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(opentable_addnumprd1))
        Me.txt_recomment = New System.Windows.Forms.TextBox()
        Me.Label_Recom = New System.Windows.Forms.Label()
        Me.Label_Num = New System.Windows.Forms.Label()
        Me.btn_close = New System.Windows.Forms.Button()
        Me.txt_numprd = New System.Windows.Forms.TextBox()
        Me.btn_enter = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox_NamePrd = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txt_recomment
        '
        Me.txt_recomment.BackColor = System.Drawing.Color.White
        Me.txt_recomment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_recomment.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_recomment.Location = New System.Drawing.Point(92, 134)
        Me.txt_recomment.MaxLength = 300
        Me.txt_recomment.Multiline = True
        Me.txt_recomment.Name = "txt_recomment"
        Me.txt_recomment.Size = New System.Drawing.Size(302, 59)
        Me.txt_recomment.TabIndex = 16
        '
        'Label_Recom
        '
        Me.Label_Recom.AutoSize = True
        Me.Label_Recom.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label_Recom.Location = New System.Drawing.Point(9, 137)
        Me.Label_Recom.Name = "Label_Recom"
        Me.Label_Recom.Size = New System.Drawing.Size(80, 25)
        Me.Label_Recom.TabIndex = 15
        Me.Label_Recom.Text = "เพิ่มเติม"
        '
        'Label_Num
        '
        Me.Label_Num.AutoSize = True
        Me.Label_Num.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label_Num.Location = New System.Drawing.Point(9, 69)
        Me.Label_Num.Name = "Label_Num"
        Me.Label_Num.Size = New System.Drawing.Size(72, 25)
        Me.Label_Num.TabIndex = 14
        Me.Label_Num.Text = "จำนวน"
        '
        'btn_close
        '
        Me.btn_close.BackColor = System.Drawing.Color.Transparent
        Me.btn_close.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_close.Location = New System.Drawing.Point(262, 202)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.Size = New System.Drawing.Size(132, 46)
        Me.btn_close.TabIndex = 13
        Me.btn_close.Text = "Close"
        Me.btn_close.UseVisualStyleBackColor = False
        '
        'txt_numprd
        '
        Me.txt_numprd.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_numprd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_numprd.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_numprd.Location = New System.Drawing.Point(92, 66)
        Me.txt_numprd.MaxLength = 4
        Me.txt_numprd.Name = "txt_numprd"
        Me.txt_numprd.Size = New System.Drawing.Size(302, 62)
        Me.txt_numprd.TabIndex = 12
        Me.txt_numprd.Text = "0"
        Me.txt_numprd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btn_enter
        '
        Me.btn_enter.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btn_enter.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_enter.Location = New System.Drawing.Point(92, 202)
        Me.btn_enter.Name = "btn_enter"
        Me.btn_enter.Size = New System.Drawing.Size(164, 46)
        Me.btn_enter.TabIndex = 11
        Me.btn_enter.Text = "Enter"
        Me.btn_enter.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 25)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "ชื่อ"
        '
        'TextBox_NamePrd
        '
        Me.TextBox_NamePrd.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TextBox_NamePrd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox_NamePrd.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TextBox_NamePrd.Location = New System.Drawing.Point(92, 12)
        Me.TextBox_NamePrd.MaxLength = 4
        Me.TextBox_NamePrd.Multiline = True
        Me.TextBox_NamePrd.Name = "TextBox_NamePrd"
        Me.TextBox_NamePrd.ReadOnly = True
        Me.TextBox_NamePrd.Size = New System.Drawing.Size(302, 48)
        Me.TextBox_NamePrd.TabIndex = 19
        Me.TextBox_NamePrd.Text = "..."
        Me.TextBox_NamePrd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'opentable_addnumprd1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(415, 267)
        Me.Controls.Add(Me.TextBox_NamePrd)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_recomment)
        Me.Controls.Add(Me.Label_Recom)
        Me.Controls.Add(Me.Label_Num)
        Me.Controls.Add(Me.btn_close)
        Me.Controls.Add(Me.txt_numprd)
        Me.Controls.Add(Me.btn_enter)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "opentable_addnumprd1"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "หน้าจอเพิ่มจำนวนสินค้า"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_recomment As System.Windows.Forms.TextBox
    Friend WithEvents Label_Recom As System.Windows.Forms.Label
    Friend WithEvents Label_Num As System.Windows.Forms.Label
    Friend WithEvents btn_close As System.Windows.Forms.Button
    Friend WithEvents txt_numprd As System.Windows.Forms.TextBox
    Friend WithEvents btn_enter As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox_NamePrd As System.Windows.Forms.TextBox
End Class
