Public Class ConfirmDialog
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        home1_menu.confirm_dialogvoid = True
        Me.Close()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        home1_menu.confirm_dialogvoid = False
        Me.Close()
    End Sub

    Private Sub ConfirmDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class