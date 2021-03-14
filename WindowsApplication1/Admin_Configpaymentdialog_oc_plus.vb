Imports MySql.Data.MySqlClient
Public Class Admin_Configpaymentdialog_oc_plus
    Dim con As New Mysql
    Public ref_id_oc As Integer = 0
    Public ref_name_oc As String = ""
    Public pay_add As Boolean = False
    Public amount_fix As Double = 0.0
    Private Sub Admin_Configpaymentdialog_oc_plus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        checkIsNumeric(TextBox1.Text, TextBox1)
    End Sub
    Private Sub checkIsNumeric(ByVal num, ByVal param)
        If IsNumeric(num) = False Then
            param.Focus()
            param.text = "0.00"
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim str As String = ""
        Dim text_remark As String = ""
        Dim qry As MySqlDataReader = con.mysql_query("select * from pos_payment_oc where id_oc='" & ref_id_oc & "';")
        qry.Read()

        If pay_add = True Then
            If (CDbl(TextBox1.Text) + qry.GetDouble("credit_oc")) <= amount_fix Then
                text_remark = "Plus Credit"
                str &= "UPDATE pos_payment_oc SET credit_oc = credit_oc + " & CDbl(TextBox1.Text) & " WHERE id_oc='" & ref_id_oc & "';"
            End If

        Else
            text_remark = "Minus Credit"
            str &= "UPDATE pos_payment_oc SET credit_oc = credit_oc - " & CDbl(TextBox1.Text) & " WHERE id_oc='" & ref_id_oc & "';"
        End If
        str &= "INSERT INTO pos_payment_oc_history (ref_id_oc,ref_name_oc,amount_oc_his,remark_oc_his,create_oc_his) VALUES (" _
        & "'" & ref_id_oc & "','" & ref_name_oc & "','" & CDbl(TextBox1.Text) & "','" & text_remark & "','" & Login.username & "');"

        If str <> "" Then
            Dim x As Boolean = con.mysql_query(str)
            If x = True Then
                If pay_add = True Then
                    If (CDbl(TextBox1.Text) + qry.GetDouble("credit_oc")) <= amount_fix Then
                        Admin_Configpaymentdialog_oc.TextBox_Credit.Text = FormatNumber(CDbl(Admin_Configpaymentdialog_oc.TextBox_Credit.Text) + CDbl(TextBox1.Text), 2)
                    End If
                Else
                    Admin_Configpaymentdialog_oc.TextBox_Credit.Text = FormatNumber(CDbl(Admin_Configpaymentdialog_oc.TextBox_Credit.Text) - CDbl(TextBox1.Text), 2)
                End If
                ' MsgBox("Add Credit Complete.")
                ref_id_oc = 0
                ref_name_oc = ""
                Admin_Configpayment.load_paymentOc()
                Me.Close()
            End If
        End If
    End Sub

End Class