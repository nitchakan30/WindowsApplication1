Public Class showpay_alert
    Public page As String = "payment"
    Private Sub btn_confirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_confirm.Click
        If page = "payment" Then
            payment.page_confirm_pay = True
        Else
            payment_gohome.page_confirm_pay = True
        End If
        Me.Close()
    End Sub
    Private Sub btn_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_close.Click
        If page = "payment" Then
            payment.page_confirm_pay = False
        Else
            payment_gohome.page_confirm_pay = False
        End If
        Me.Close()
    End Sub
End Class