Imports MySql.Data.MySqlClient
Public Class form_ropbill_audit_close
    Dim con As New Mysql
    Public not_countMoney As Boolean = False
    Private Sub btn_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clear.Click
        form_ropbill.close_chk = False
        form_ropbill.id_ropclose = 0
        form_ropbill.Money_CloseRop = 0.0
        Me.Close()
    End Sub
    Private Sub btn_enter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_enter.Click
        Dim date1 As DateTime
        If CInt(Login.DateData.ToString("yyyy")) > 2450 Then
            date1 = CInt(Login.DateData.ToString("yyyy")) - 543 & Login.DateData.ToString("-MM-dd HH:mm:ss")
        Else
            date1 = Login.DateData.ToString("yyyy-MM-dd HH:mm:ss")
        End If
        If txt_user.Text <> "" And txt_pwd.Text <> "" And (CInt(txt_money.Text) > 0 Or CInt(txt_money.Text) = 0) Then
            If not_countMoney = False Then
                If (CInt(txt_money.Text) >= 0) Then
                Else
                    End
                End If
            End If
            Dim num_user As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_user where username='" & txt_user.Text & "' and password='" & txt_pwd.Text & "' LIMIT 1"))
            If num_user > 0 Then
                Dim res_user As MySqlDataReader = con.mysql_query("select * from pos_user where username='" & txt_user.Text & "' and password='" & txt_pwd.Text & "' LIMIT 1")
                res_user.Read()
                Dim res_p As MySqlDataReader = con.mysql_query("select * from pos_user_permission_match where id_user='" & res_user.GetString("id") & "'")
                res_p.Read()
                If CInt(res_p.GetString("closing_bill")) = 1 Then
                    If not_countMoney = True Then
                        form_ropbill.close_chk = True
                        form_ropbill.id_ropclose = 0
                        not_countMoney = False
                        GroupBox1.Visible = True
                        Me.Close()
                    Else
                        'เงื่อนไขการนับเงินในลิ้นชัก
                        'คำนวณหาเงินในลิ้นชัก

                        Dim res_t As MySqlDataReader = con.mysql_query("select * from pos_audit where id_aud='" & form_ropbill.id_ropclose & "' and type_aud='0' ")
                        res_t.Read()

                        'คำนวณหารายได้ที่ขายได้
                        'Dim res_inv As MySqlDataReader = con.mysql_query("SELECT * FROM pos_invoice " _
                        '& "INNER JOIN pos_closebilldetail ON  pos_closebilldetail.crf_id_invoice=pos_invoice.id " _
                        '& " WHERE pos_closebilldetail.rf_id_closebill='" & form_ropbill.id_ropclose & "' and pos_closebilldetail.cstatus<>'void' and pos_closebilldetail.crf_id_invoice<>'0' and pos_invoice.void='0' and pos_invoice.rf_payment_type='1' and " _
                        '& " DAY(pos_closebilldetail.ccreate_date)='" & date1.ToString("dd") & "' and MONTH(pos_closebilldetail.ccreate_date)='" & date1.ToString("MM") & "' and YEAR(pos_closebilldetail.ccreate_date)='" & date1.ToString("yyyy") & "' and pos_invoice.close_rop_id_inv='" & form_ropbill.id_ropclose & "' GROUP BY  pos_invoice.id")

                        '   Dim res_inv As MySqlDataReader = con.mysql_query("SELECT * FROM pos_invoice " _
                        '  & "INNER JOIN pos_closebilldetail ON  pos_closebilldetail.crf_id_invoice=pos_invoice.id " _
                        '  & " WHERE pos_closebilldetail.rf_id_closebill='" & form_ropbill.id_ropclose & "' and pos_closebilldetail.cstatus<>'void' and pos_closebilldetail.crf_id_invoice<>'0' and pos_invoice.void='0' and pos_invoice.rf_payment_type='1' and " _
                        '  & " DAY(pos_closebilldetail.ccreate_date)='" & date1.ToString("dd") & "' and MONTH(pos_closebilldetail.ccreate_date)='" & date1.ToString("MM") & "' and YEAR(pos_closebilldetail.ccreate_date)='" & date1.ToString("yyyy") & "' and pos_invoice.close_rop_id_inv='" & form_ropbill.id_ropclose & "' GROUP BY  pos_invoice.id")

                        Dim res_inv As MySqlDataReader = con.mysql_query("SELECT * FROM pos_invoice where close_rop_id_inv='" & form_ropbill.id_ropclose & "' and pos_invoice.void='0' and pos_invoice.rf_payment_type='1' ;")
                        Dim sum As Double = 0.0
                        While res_inv.Read()
                            If CDbl(res_inv.GetString("price_all")) > 0 Then
                                sum += CDbl(res_inv.GetString("price_all"))
                            End If
                        End While
                        sum = (sum + CDbl(res_t.GetString("money_aud")))
                        If form_ropbill.CheckInputcash_balance = True Then
                            If FormatNumber(sum, 2) = FormatNumber(CDbl(txt_money.Text), 2) Then
                                form_ropbill.close_chk = True
                                form_ropbill.id_ropclose = 0
                                form_ropbill.Money_CloseRop = FormatNumber(CDbl(txt_money.Text), 2)
                                Me.Close()
                            ElseIf CDbl(txt_money.Text) < sum Then
                                Label1.Text = "ยอดเงินขาดกรุณาตรวจสอบอีกครั้งค่ะ (-" & FormatNumber(CDbl(txt_money.Text) - sum, 2) & ")"
                                Label1.Visible = True
                            ElseIf CDbl(txt_money.Text) > sum Then
                                Label1.Text = "ยอดเงินเกินกรุณาตรวจสอบอีกครั้งค่ะ (+" & FormatNumber(CDbl(txt_money.Text) - sum, 2) & ")"
                                Label1.Visible = True
                            End If
                        Else
                            form_ropbill.close_chk = True
                            form_ropbill.id_ropclose = 0
                            form_ropbill.Money_CloseRop = FormatNumber(CDbl(txt_money.Text), 2)
                            Me.Close()
                        End If
                    End If
                Else
                    MessageBox.Show("คุณไม่มีสิทธิในการยินยันระบบนี้ ติดต่อ Support Program", "Message Show", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("username หรือ password ไม่ถูกต้องกรุณาตรวจสอบอีกครั้ง", "Message Show", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txt_pwd.Focus()
            End If
        Else
            MessageBox.Show("กรุณากรอกข้อมูลให้ครบด้วยค่ะ", "Message Show", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

 
    Private Sub form_ropbill_audit_close_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If not_countMoney = True Then
            GroupBox1.Visible = False
        Else
            GroupBox1.Visible = True
        End If
        txt_user.Focus()
        txt_user.Text = ""
        txt_pwd.Text = ""
        txt_money.Text = "0.0"
    End Sub

    Private Sub txt_money_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_money.Click
        keyborad_number.text1 = "txt_money"
        keyborad_number.ShowDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txt_user.Text = ""
        txt_pwd.Text = ""
        txt_money.Text = "0.0"
    End Sub

    Private Sub txt_pwd_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_pwd.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            Dim date1 As DateTime
            If CInt(Login.DateData.ToString("yyyy")) > 2450 Then
                date1 = CInt(Login.DateData.ToString("yyyy")) - 543 & Login.DateData.ToString("-MM-dd HH:mm:ss")
            Else
                date1 = Login.DateData.ToString("yyyy-MM-dd HH:mm:ss")
            End If
            If txt_user.Text <> "" And txt_pwd.Text <> "" And CInt(txt_money.Text) > 0 Then
                If not_countMoney = False Then
                    If (CInt(txt_money.Text) > 0) Then
                    Else
                        End
                    End If
                End If
                Dim num_user As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_user where username='" & txt_user.Text & "' and password='" & txt_pwd.Text & "' LIMIT 1"))
                If num_user > 0 Then
                    Dim res_user As MySqlDataReader = con.mysql_query("select * from pos_user where username='" & txt_user.Text & "' and password='" & txt_pwd.Text & "' LIMIT 1")
                    res_user.Read()
                    Dim res_p As MySqlDataReader = con.mysql_query("select * from pos_user_permission_match where id_user='" & res_user.GetString("id") & "'")
                    res_p.Read()
                    If CInt(res_p.GetString("closing_bill")) = 1 Then
                        If not_countMoney = True Then
                            form_ropbill.close_chk = True
                            form_ropbill.id_ropclose = 0
                            not_countMoney = False
                            GroupBox1.Visible = True
                            Me.Close()
                        Else
                            'เงื่อนไขการนับเงินในลิ้นชัก
                            'คำนวณหาเงินในลิ้นชัก

                            Dim res_t As MySqlDataReader = con.mysql_query("select * from pos_audit where id_aud='" & form_ropbill.id_ropclose & "' and type_aud='0' ")
                            res_t.Read()

                            'คำนวณหารายได้ที่ขายได้
                            Dim res_inv As MySqlDataReader = con.mysql_query("SELECT * FROM pos_invoice " _
                            & "INNER JOIN pos_closebilldetail ON  pos_closebilldetail.crf_id_invoice=pos_invoice.id " _
                            & " WHERE pos_closebilldetail.rf_id_closebill='" & form_ropbill.id_ropclose & "' and pos_closebilldetail.cstatus<>'void' and pos_closebilldetail.crf_id_invoice<>'0' and pos_invoice.void='0' and pos_invoice.rf_payment_type='1' and " _
                            & " DAY(pos_closebilldetail.ccreate_date)='" & date1.ToString("dd") & "' and MONTH(pos_closebilldetail.ccreate_date)='" & date1.ToString("MM") & "' and YEAR(pos_closebilldetail.ccreate_date)='" & date1.ToString("yyyy") & "' and pos_invoice.close_rop_id_inv='" & form_ropbill.id_ropclose & "' GROUP BY  pos_invoice.id")
                            Dim sum As Double = 0.0
                            While res_inv.Read()
                                If CDbl(res_inv.GetString("price_all")) > 0 Then
                                    sum += CDbl(res_inv.GetString("price_all"))
                                End If
                            End While
                            sum = (sum + CDbl(res_t.GetString("money_aud")))
                            If sum = CDbl(txt_money.Text) Then
                                form_ropbill.close_chk = True
                                form_ropbill.id_ropclose = 0
                                Me.Close()
                            ElseIf CDbl(txt_money.Text) < sum Then
                                Label1.Text = "ยอดเงินขาดกรุณาตรวจสอบอีกครั้งค่ะ (-" & CDbl(txt_money.Text) - sum & ")"
                                Label1.Visible = True
                            ElseIf CDbl(txt_money.Text) > sum Then
                                Label1.Text = "ยอดเงินเกินกรุณาตรวจสอบอีกครั้งค่ะ (+" & CDbl(txt_money.Text) - sum & ")"
                                Label1.Visible = True
                            End If
                        End If
                    Else
                        MessageBox.Show("คุณไม่มีสิทธิในการยินยันระบบนี้ ติดต่อ Support Program", "Message Show", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("username หรือ password ไม่ถูกต้องกรุณาตรวจสอบอีกครั้ง", "Message Show", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txt_pwd.Focus()
                End If
            Else
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบด้วยค่ะ", "Message Show", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub
End Class