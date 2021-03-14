Public Class dialog_confirm
    Public Page As String = ""
    Private Sub btn_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ok.Click
        If Page = "opentable" Then
            opentable.Confirm_sendOrder = True
        ElseIf Page = "opentakehome" Then
            opentakehome.Confirm_sendOrder = True
        End If
        Me.Close()
    End Sub

    Private Sub btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancel.Click
        If Page = "opentable" Then
            opentable.Confirm_sendOrder = False
        ElseIf Page = "opentakehome" Then
            opentakehome.Confirm_sendOrder = False
        End If
        Me.Close()
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Page = "opentable" Then
            opentable.Confirm_sendOrder = False
        ElseIf Page = "opentakehome" Then
            opentakehome.Confirm_sendOrder = False
        End If
        Me.Close()
    End Sub

    Private Sub btn_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_close.Click
        If Page = "opentable" Then
            opentable.Confirm_sendOrder = False
        ElseIf Page = "opentakehome" Then
            opentakehome.Confirm_sendOrder = False
        End If
        Me.Close()
    End Sub
End Class