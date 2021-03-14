Public Class switch_langprint
    Public page As String = ""
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If page = "form_reprint_captain" Then
            form_reprint_captain.LangPrintSendCaptain1 = "TH"
        ElseIf page = "payment" Then
            payment.switch_lang = "TH"
        ElseIf page = "showpay_typeprint" Then
            showpay_typeprint.switch_lang = "TH"
        ElseIf page = "showPay" Then
            showPay.switch_lang = "TH"
        ElseIf page = "opentakehome" Then
            opentakehome.lang_print = "TH"
        ElseIf page = "payment_gohome" Then
            payment_gohome.switch_lang = "TH"
        ElseIf page = "form_reprint_captain_gh" Then
            form_reprint_captain_gh.lang = "TH"
        ElseIf page = "form_reprint_captain" Then
            form_reprint_captain.LangPrintSendCaptain1 = "TH"
        Else
            opentable.LangPrintSendCaptain = "TH"
        End If

        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If page = "form_reprint_captain" Then
            form_reprint_captain.LangPrintSendCaptain1 = "EN"
        ElseIf page = "payment" Then
            payment.switch_lang = "EN"
        ElseIf page = "showpay_typeprint" Then
            showpay_typeprint.switch_lang = "EN"
        ElseIf page = "showPay" Then
            showPay.switch_lang = "EN"
        ElseIf page = "opentakehome" Then
            opentakehome.lang_print = "EN"
        ElseIf page = "payment_gohome" Then
            payment_gohome.switch_lang = "EN"
        ElseIf page = "form_reprint_captain_gh" Then
            form_reprint_captain_gh.lang = "EN"
        ElseIf page = "form_reprint_captain" Then
            form_reprint_captain.LangPrintSendCaptain1 = "EN"
        Else
            opentable.LangPrintSendCaptain = "EN"
        End If
        Me.Close()
    End Sub

    Private Sub switch_langprint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class