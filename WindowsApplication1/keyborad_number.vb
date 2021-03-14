Public Class keyborad_number
    Public text1 As String
    Private Sub keyborad_number_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox_InputC.Text = "0.00"
        dot = True
        InputNum("1")
    End Sub
    Private Sub Btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn1.Click
        InputNum("1")
    End Sub

    Private Sub Btn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn2.Click
        InputNum("2")
    End Sub

    Private Sub Btn3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn3.Click
        InputNum("3")
    End Sub

    Private Sub Btn4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn4.Click
        InputNum("4")
    End Sub

    Private Sub Btn5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn5.Click
        InputNum("5")
    End Sub

    Private Sub Btn6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn6.Click
        InputNum("6")
    End Sub

    Private Sub Btn7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn7.Click
        InputNum("7")
    End Sub

    Private Sub Btn8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn8.Click
        InputNum("8")
    End Sub

    Private Sub Btn9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn9.Click
        InputNum("9")
    End Sub

    Private Sub Btn0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn0.Click
        InputNum("0")
    End Sub

    Private Sub BtnDemin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDemin.Click
        InputNum(".")
    End Sub
    Dim dot As Boolean = True
    Public Sub InputNum(ByRef Num As String)

        If Num = "." Then
            If dot = False Then
                TextBox_InputC.Text &= Num
                dot = True
            End If

        Else
            If TextBox_InputC.Text <> "" Then
                If CDbl(TextBox_InputC.Text) = 0 Or TextBox_InputC.Text = "" Then
                    TextBox_InputC.Clear()
                    dot = False
                End If
            End If
            If dot = True Then
                Dim words As String() = TextBox_InputC.Text.ToString.Split(New Char() {"."c})
                If words(1).Length <= 1 Then
                    TextBox_InputC.Text &= Num
                End If
            Else
                TextBox_InputC.Text &= Num
            End If
        End If
    End Sub

    Private Sub Btn_backS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_backS.Click
        If TextBox_InputC.TextLength > 0 Then
            If TextBox_InputC.Text.IndexOf(".") = TextBox_InputC.TextLength - 1 Then
                dot = False
            End If
            TextBox_InputC.Text = TextBox_InputC.Text.Substring(0, TextBox_InputC.TextLength - 1)
        End If
    End Sub
    Private Sub Btn_Reload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Reload.Click
        TextBox_InputC.Text = "0.00"
        dot = True
    End Sub
    Public Sub EnterNumber(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Enter.Click
        If TextBox_InputC.Text <> "" Then


            If CDbl(TextBox_InputC.Text) >= 0 Then
                If text1 = "TextBox_Prs" Then
                    opentable.TextBox_Prs.Text = TextBox_InputC.Text
                    opentable.txt_cover.Text = CInt(opentable.txt_child.Text) + CInt(TextBox_InputC.Text)
                    Me.Close()
                    TextBox_InputC.Text = "0.00"
                ElseIf text1 = "txt_child" Then
                    opentable.txt_child.Text = TextBox_InputC.Text
                    opentable.txt_cover.Text = CInt(opentable.TextBox_Prs.Text) + CInt(TextBox_InputC.Text)
                    Me.Close()
                    TextBox_InputC.Text = "0.00"
                ElseIf text1 = "txt_adult_home" Then
                    home1.txt_adult.Text = TextBox_InputC.Text
                    home1.txt_cover.Text = CInt(home1.txt_child.Text) + CInt(TextBox_InputC.Text)
                    Me.Close()
                    TextBox_InputC.Text = "0.00"
                ElseIf text1 = "txt_child_home" Then
                    home1.txt_child.Text = TextBox_InputC.Text
                    home1.txt_cover.Text = CInt(home1.txt_adult.Text) + CInt(TextBox_InputC.Text)
                    Me.Close()
                    TextBox_InputC.Text = "0.00"
                ElseIf text1 = "txt_adult_payment" Then
                    payment.txt_show_adult.Text = TextBox_InputC.Text
                    payment.txt_show_cover.Text = CInt(payment.txt_show_child.Text) + CInt(TextBox_InputC.Text)
                    Me.Close()
                    TextBox_InputC.Text = "0.00"
                ElseIf text1 = "txt_child_payment" Then
                    payment.txt_show_child.Text = TextBox_InputC.Text
                    payment.txt_show_cover.Text = CInt(payment.txt_show_adult.Text) + CInt(TextBox_InputC.Text)
                    Me.Close()
                    TextBox_InputC.Text = "0.00"
                ElseIf text1 = "TextBox_Prs_Reserv" Then
                    home1.TextBox_Prs.Text = TextBox_InputC.Text
                    Me.Close()
                    TextBox_InputC.Text = "0.00"
                ElseIf text1 = "txt_numprd_addCart" Then
                    opentable_addnumprd1.txt_numprd.Text = TextBox_InputC.Text
                    Me.Close()
                    TextBox_InputC.Text = "0.00"
                ElseIf text1 = "voidorder" Then
                    opentable_voidorder1.txt_number.Text = TextBox_InputC.Text
                    Me.Close()
                    TextBox_InputC.Text = "0.00"
                ElseIf text1 = "voidorderlist" Then
                    void_orderlist.TextBox1.Text = TextBox_InputC.Text
                    Me.Close()
                    TextBox_InputC.Text = "0"
                ElseIf text1 = "Textbox_typepay" Then
                    'payment_type.TextBox_Amount.Text = TextBox_InputC.Text
                    Me.Close()
                    TextBox_InputC.Text = "0"
                ElseIf text1 = "txt_money" Then
                    form_ropbill_audit_close.txt_money.Text = TextBox_InputC.Text
                    Me.Close()
                    TextBox_InputC.Text = "0"
                ElseIf text1 = "txt_money_delf" Then
                    form_ropbill_audit_default.txt_money.Text = TextBox_InputC.Text
                    Me.Close()
                    TextBox_InputC.Text = "0"
                ElseIf text1 = "discount_all" Then
                    payment.txt_dis_all.Text = TextBox_InputC.Text
                    Me.Close()
                    TextBox_InputC.Text = "0"
                ElseIf text1 = "discount_only" Then
                    payment_discount.txt_dis_only.Text = TextBox_InputC.Text
                    Me.Close()
                    TextBox_InputC.Text = "0"
                ElseIf text1 = "discount_all_gh" Then
                    payment_gohome.txt_dis_all.Text = TextBox_InputC.Text
                    Me.Close()
                    TextBox_InputC.Text = "0"
                ElseIf text1 = "discount_only_gh" Then
                    payment_discount_gohome.txt_dis_only.Text = TextBox_InputC.Text
                    Me.Close()
                    TextBox_InputC.Text = "0"
                End If
            End If
        End If
    End Sub
End Class