Imports MySql.Data.MySqlClient
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Threading
Public Class payment_inputtype
    Dim con As New Mysql
    Public rf_payment_type As String = "1"
    Public page As String = "payment"
    Private Sub payment_inputtype_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_TypeCard()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
       If rf_payment_type = 2 Then
            '===========GET id credit card ปรเภทของcredt card============='
            Dim pp As FlowLayoutPanel
            Dim bb As RadioButton
            Dim str_cre As String = ""
            pp = GroupBox_TC.Controls.Item(GroupBox_TC.Controls.IndexOfKey("FlowLayoutPanel1"))
            For n As Integer = 0 To pp.Controls.Count - 1
                If TypeOf pp.Controls.Item(n) Is RadioButton Then
                    bb = pp.Controls.Item(n)
                    If bb.Checked = True Then
                        str_cre &= bb.Text
                        If page = "payment" Then
                            payment.id_card = CInt(bb.Tag)
                        Else
                            payment_gohome.id_card = CInt(bb.Tag)
                        End If

                    End If
                End If
            Next
            If TextBox_Card1.Text <> "" Then
                If page = "payment" Then
                    payment.des_payment = TextBox_Card1.Text & "  " & TextBox_Exp_M.Text & "/" & TextBox_Exp_Y.Text & ""
                    payment.rf_payment_acc = 0
                    payment.TextBox_TypePay.Text = "Credit Card: " & TextBox_Card1.Text & "  " & TextBox_Exp_M.Text & "/" & TextBox_Exp_Y.Text & ""
                Else
                    payment_gohome.des_payment = TextBox_Card1.Text & "  " & TextBox_Exp_M.Text & "/" & TextBox_Exp_Y.Text & ""
                    payment_gohome.rf_payment_acc = 0
                    payment_gohome.TextBox_TypePay.Text = "Credit Card: " & TextBox_Card1.Text & "  " & TextBox_Exp_M.Text & "/" & TextBox_Exp_Y.Text & ""
                End If
            Else
                If page = "payment" Then
                    payment.des_payment = "Credit Card"
                    payment.TextBox_TypePay.Text = "Credit Card: " & str_cre
                Else
                    payment_gohome.des_payment = "Credit Card"
                    payment_gohome.TextBox_TypePay.Text = "Credit Card: " & str_cre
                End If
            End If
        ElseIf rf_payment_type = 4 Then
            If page = "payment" Then
                payment.des_payment = TextBox_Coupon.Text
                payment.TextBox_TypePay.Text = "Coupon: " & TextBox_Coupon.Text
            Else
                payment_gohome.des_payment = TextBox_Coupon.Text
                payment_gohome.TextBox_TypePay.Text = "Coupon: " & TextBox_Coupon.Text
            End If
        ElseIf rf_payment_type = 5 Then
            If page = "payment" Then
                payment.des_payment = txt_payment_other.Text
                payment.TextBox_TypePay.Text = "Other: " & txt_payment_other.Text
            Else
                payment_gohome.des_payment = txt_payment_other.Text
                payment_gohome.TextBox_TypePay.Text = "Other: " & txt_payment_other.Text
            End If
        Else
            If page = "payment" Then
                payment.des_payment = payment.des_payment
                payment.TextBox_TypePay.Text = payment.des_payment
            Else
                payment_gohome.des_payment = payment.des_payment
                payment_gohome.TextBox_TypePay.Text = payment.des_payment
            End If
        End If
        Me.Close()
    End Sub
    Public Sub load_TypeCard()
        Dim num As Integer = con.mysql_num_rows(con.mysql_query("SELECT * FROM pos_payment_card where active_del='0' order by id_card ASC "))
        If num > 0 Then
            Dim res_t As MySqlDataReader = con.mysql_query("SELECT * FROM pos_payment_card where active_del='0' order by id_card ASC ")
            FlowLayoutPanel1.Controls.Clear()
            Dim h As Integer = 0
            While res_t.Read()
                Dim Radio As New RadioButton
                Radio.Text = res_t.GetString("name_card")
                Radio.Name = res_t.GetString("name_card")
                Radio.Tag = res_t.GetString("id_card")
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

    Private Sub TextBox_Card1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox_Card1.Click
        keyborad_str.text1 = "TextBox_Card1"
        keyborad_str.ShowDialog()
    End Sub

    Private Sub TextBox_Exp_M_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox_Exp_M.Click
        keyborad_str.text1 = "TextBox_Exp_M"
        keyborad_str.ShowDialog()
    End Sub

    Private Sub TextBox_Exp_Y_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox_Exp_Y.Click
        keyborad_str.text1 = "TextBox_Exp_Y"
        keyborad_str.ShowDialog()
    End Sub

    Private Sub TextBox_Coupon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox_Coupon.Click
        'Login.p = Process.GetProcessesByName("osk")
        'If Login.p.Count > 0 Then
        '    ' Process is running
        '    Array.ForEach(Login.p, Sub(p1 As Process) p1.Kill())
        '    System.Diagnostics.Process.Start("osk.exe")
        'Else
        '    ' Process is not running
        '    System.Diagnostics.Process.Start("osk.exe")
        'End If
    End Sub
    Public Sub loadPaymentAcc()
        'Load Payment Acc
        Dim res_acc As MySqlDataReader
        res_acc = con.mysql_query("select * from  pos_payment_acc order by id_acc ASC")
        Dim cboItemsFl As New List(Of cboItem)
        Dim txt As String = ""
        While res_acc.Read
            txt = res_acc.GetString("name_acc")
            cboItemsFl.Add(New cboItem With {.Text = txt, .Value = res_acc.GetString("id_acc")})
        End While
        With Me.ComboBox_Payacc
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .DataSource = cboItemsFl
        End With
        If ComboBox_Payacc.Items.Count > 0 Then
            ComboBox_Payacc.SelectedIndex = 0
        End If
        res_acc.Close()
    End Sub


End Class