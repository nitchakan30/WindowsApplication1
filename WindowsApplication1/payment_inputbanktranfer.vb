Imports MySql.Data.MySqlClient
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Threading
Public Class payment_inputbanktranfer
    Dim con As New Mysql
    Public rf_payment_type As String = "1"
    Public page As String = "payment"
    Private Sub payment_inputbanktranfer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_TypeBankAcc()
    End Sub
    Public Sub load_TypeBankAcc()
        Dim num As Integer = con.mysql_num_rows(con.mysql_query("SELECT * FROM pos_payment_acc where active_acc='1'  order by id_acc ASC "))
        If num > 0 Then
            Dim res_t As MySqlDataReader = con.mysql_query("SELECT * FROM pos_payment_acc  where active_acc='1' order by id_acc ASC ")
            FlowLayoutPanel1.Controls.Clear()
            Dim h As Integer = 0
            While res_t.Read()
                Dim Radio As New RadioButton
                Radio.Text = res_t.GetString("name_acc")
                Radio.Name = res_t.GetString("name_acc")
                Radio.Tag = res_t.GetString("id_acc")
                If h = 0 Then
                    Radio.Checked = True
                Else
                    Radio.Checked = False
                End If
                FlowLayoutPanel1.Controls.Add(Radio)
                h += 1
            End While
            res_t.Close()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If rf_payment_type = 99 Then
            '===========GET id credit card ปรเภทของcredt card============='
            Dim pp As FlowLayoutPanel
            Dim bb As RadioButton
            Dim str_cre As String = ""
            Dim id_acc As Integer = 0
            pp = GroupBox_TC.Controls.Item(GroupBox_TC.Controls.IndexOfKey("FlowLayoutPanel1"))
            For n As Integer = 0 To pp.Controls.Count - 1
                If TypeOf pp.Controls.Item(n) Is RadioButton Then
                    bb = pp.Controls.Item(n)
                    If bb.Checked = True Then
                        str_cre = bb.Text
                        id_acc = CInt(bb.Tag)
                        If page = "payment" Then
                            payment.rf_payment_acc = CInt(bb.Tag)
                        Else
                            payment_gohome.rf_payment_acc = CInt(bb.Tag)
                        End If

                    End If
                End If
            Next
            If TextBox_BankTran.Text <> "" Then
                If page = "payment" Then
                    payment.des_payment = TextBox_BankTran.Text
                    payment.rf_payment_acc = id_acc
                    payment.TextBox_TypePay.Text = "Bank Tansfer:" & str_cre & "," & TextBox_BankTran.Text
                Else
                    payment_gohome.des_payment = TextBox_BankTran.Text
                    payment_gohome.rf_payment_acc = id_acc
                    payment_gohome.TextBox_TypePay.Text = "Bank Tansfer:" & str_cre & "," & TextBox_BankTran.Text
                End If
            Else
                If page = "payment" Then
                    payment.des_payment = "Bank Transfer Number None."
                    payment.rf_payment_acc = id_acc
                    payment.TextBox_TypePay.Text = "Bank Tansfer: " & str_cre
                Else
                    payment_gohome.des_payment = "Bank Transfer Number None."
                    payment.rf_payment_acc = id_acc
                    payment_gohome.TextBox_TypePay.Text = "Bank Tansfer: " & str_cre
                End If
            End If
        End If
        Me.Close()
    End Sub

End Class