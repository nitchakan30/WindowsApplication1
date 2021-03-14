Public Class plan_add_text
    Public text1 As String = ""
    Public name1 As String = ""
    Public font1 As Font
    Public color As Color
    Dim func As New func

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub plan_add_text_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FontDialog1.ShowEffects = False
        If text1 <> "" Then
            txtName.Text = text1
            lblExample.Font = font1
            lblExample.ForeColor = color
            txtName.Focus()
        Else
            txtName.Text = ""
            lblExample.Font = font1
            lblExample.ForeColor = Drawing.Color.Black
            lblExample.Text = "Example"
            txtName.Focus()
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If txtName.Text <> "" Then
            Admin_ConfigTBCUS.addLbl(txtName.Text, name1, lblExample.ForeColor, lblExample.Font)
            FontDialog1.Reset()
            Me.Close()
        Else
            MsgBox("Text Not Valid!!")
            txtName.Focus()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If FontDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            lblExample.Font = FontDialog1.Font
        End If
    End Sub

    Private Sub txtName_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtName.KeyUp
        If lblExample.Text <> "" Then
            lblExample.Text = txtName.Text
        Else
            lblExample.Text = "Example"
        End If
    End Sub

    Private Sub btnColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColor.Click
        Dim cDialog As New ColorDialog()
        cDialog.Color = lblExample.ForeColor

        If (cDialog.ShowDialog() = DialogResult.OK) Then
            lblExample.ForeColor = cDialog.Color
        End If
    End Sub
End Class