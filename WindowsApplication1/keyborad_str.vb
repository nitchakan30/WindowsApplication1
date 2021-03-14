Public Class keyborad_str
    Public text1 As String
    Private Sub keyborad_str_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn1.Click
        InputNum(1)
    End Sub

    Private Sub Btn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn2.Click
        InputNum(2)
    End Sub

    Private Sub Btn3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn3.Click
        InputNum(3)
    End Sub

    Private Sub Btn4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn4.Click
        InputNum(4)
    End Sub

    Private Sub Btn5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn5.Click
        InputNum(5)
    End Sub

    Private Sub Btn6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn6.Click
        InputNum(6)
    End Sub

    Private Sub Btn7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn7.Click
        InputNum(7)
    End Sub

    Private Sub Btn8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn8.Click
        InputNum(8)
    End Sub

    Private Sub Btn9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn9.Click
        InputNum(9)
    End Sub

    Private Sub Btn0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn0.Click
        InputNum(0)
    End Sub

    Private Sub BtnDemin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        InputNum(".")
    End Sub
    Dim dot As Boolean = True
    Public Sub InputNum(ByVal Num As String)
        TextBox_InputC.Text &= Num

    End Sub

    Private Sub Btn_backS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_backS.Click
        If TextBox_InputC.TextLength > 0 Then
            TextBox_InputC.Text = TextBox_InputC.Text.Substring(0, TextBox_InputC.TextLength - 1)
        End If
    End Sub
    Private Sub Btn_Reload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Reload.Click
        TextBox_InputC.Text = "0"
        dot = True
    End Sub
    Public Sub EnterNumber(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Enter.Click
        If CDbl(TextBox_InputC.Text) > 0 And TextBox_InputC.Text <> "" Then
            If text1 = "TextBox_Card1" Then
                payment_inputtype.TextBox_Card1.Text = TextBox_InputC.Text
                Me.Close()
                TextBox_InputC.Text = "0"
            ElseIf text1 = "TextBox_Exp_M" Then
                payment_inputtype.TextBox_Exp_M.Text = TextBox_InputC.Text
                Me.Close()
                TextBox_InputC.Text = "0"
            ElseIf text1 = "TextBox_Exp_Y" Then
                payment_inputtype.TextBox_Exp_Y.Text = TextBox_InputC.Text
                Me.Close()
                TextBox_InputC.Text = "0"
            ElseIf text1 = "Edit_QTY" Then
                payment_subp_dialog.qty_subp = TextBox_InputC.Text
                Me.Close()
                TextBox_InputC.Text = "0"
            ElseIf text1 = "Edit_QTY_GH" Then
                payment_gohome_subp_dialog.qty_subp = TextBox_InputC.Text
                Me.Close()
                TextBox_InputC.Text = "0"
            End If
        End If
    End Sub
End Class