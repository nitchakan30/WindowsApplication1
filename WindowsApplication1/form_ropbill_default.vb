Imports MySql.Data.MySqlClient
Public Class form_ropbill_default
    Dim con As New Mysql

    Private Sub form_ropbill_default_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

        txt_user.Focus()
        Dim res_r As MySqlDataReader
        res_r = con.mysql_query("select create_date from pos_closebill order by id_ropbill asc limit 1")
        res_r.Read()
        Dim date_dt As DateTime = res_r.GetString("create_date")
        Dim year As Integer
        If date_dt.ToString("yyyy") > 2485 Then
            year = CInt(date_dt.ToString("yyyy")) - 543
        Else
            year = CInt(date_dt.ToString("yyyy"))
        End If
        date_dt = year & date_dt.ToString("-MM-dd")
        Dim rop As MySqlDataReader = con.mysql_query("select * from pos_audit where rop_date_aud LIKE '%" & date_dt.ToString("yyyy-MM-dd") & "%' and machine_aud='" & Login.getMacAddress() & "' order by id_aud DESC Limit 1 ")
        rop.Read()
        Dim num As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_audit where rop_date_aud LIKE '%" & date_dt.ToString("yyyy-MM-dd") & "%' and machine_aud='" & Login.getMacAddress() & "' "))
        If num > 0 Then
            Label_show.Text = "เปิดรอบที่ " & CInt(rop.GetString("id_ropbill_aud")) + 1 & " วันที่" & date_dt.ToString("dd/MM/yyyy")
        Else
            Label_show.Text = "เปิดรอบที่ 1 วันที่" & date_dt.ToString("dd/MM/yyyy")
        End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btn_enter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_enter.Click
        If txt_user.Text <> "" And txt_pwd.Text <> "" Then
            Dim num_user As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_user where username='" & txt_user.Text & "' and password='" & txt_pwd.Text & "' LIMIT 1"))
            If num_user > 0 Then
                Dim res_user As MySqlDataReader = con.mysql_query("select * from pos_user where username='" & txt_user.Text & "' and password='" & txt_pwd.Text & "' LIMIT 1")
                res_user.Read()
                Dim res_p As MySqlDataReader = con.mysql_query("select * from pos_user_permission_match where id_user='" & res_user.GetString("id") & "'")
                res_p.Read()
                If CInt(res_p.GetString("closing_bill")) = 1 Then
                    Dim res_r As MySqlDataReader
                    res_r = con.mysql_query("select create_date from pos_closebill order by id_ropbill asc limit 1")
                    res_r.Read()
                    Dim date_dt As DateTime = res_r.GetString("create_date")
                    Dim year As Integer
                    If date_dt.ToString("yyyy") > 2485 Then
                        year = CInt(date_dt.ToString("yyyy")) - 543
                    Else
                        year = CInt(date_dt.ToString("yyyy"))
                    End If
                    date_dt = year & date_dt.ToString("-MM-dd")

                    'หาว่ามีรอบนี้ วันนี้ ในระบบหรือยัง เป็น record เงินทอน สถานะเป้น 0
                    Dim str As String = ""
                    Dim id_rop As Integer = 0
                    Dim str_rop As String = ""
                    Dim rop As MySqlDataReader = con.mysql_query("select * from pos_audit where rop_date_aud LIKE '%" & date_dt.ToString("yyyy-MM-dd") & "%' and machine_aud='" & Login.getMacAddress() & "' order by id_aud DESC Limit 1 ")
                    rop.Read()
                    Dim num As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_audit where rop_date_aud LIKE '%" & date_dt.ToString("yyyy-MM-dd") & "%' and machine_aud='" & Login.getMacAddress() & "' "))
                    If num > 0 Then
                        id_rop = CInt(rop.GetString("id_ropbill_aud")) + 1
                        index.Label_Rop.Text = "รอบที่ " & id_rop
                        str_rop = "รอบที่ " & id_rop & " วันที่" & date_dt.ToString("dd/MM/yyyy")
                        str &= "INSERT pos_audit (id_ropbill_aud,name_rop_aud,rop_date_aud,type_aud,money_aud,action_by_aud,machine_aud,counter_money)" _
                               & "VALUES('" & id_rop & "','" & str_rop & "','" & date_dt.ToString("yyyy-MM-dd HH:mm:ss") & "','0','0','" & txt_user.Text & "','" & Login.getMacAddress() & "','close');"
                    Else
                        id_rop = 1
                        index.Label_Rop.Text = "รอบที่ " & id_rop
                        str_rop = "รอบที่ " & id_rop & " วันที่" & date_dt.ToString("dd/MM/yyyy")
                        str &= "INSERT pos_audit (id_ropbill_aud,name_rop_aud,rop_date_aud,type_aud,money_aud,action_by_aud,machine_aud,counter_money)" _
                               & "VALUES('" & id_rop & "','" & str_rop & "','" & date_dt.ToString("yyyy-MM-dd HH:mm:ss") & "','0','0','" & txt_user.Text & "','" & Login.getMacAddress() & "','close');"
                    End If
                    Dim q As Boolean = con.mysql_query(str)
                    If q = True Then
                        Login.query_ok_audit_defalut = True
                        'MessageBox.Show("บันทึกเรียบร้อย", "Message Show", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Close()
                    Else
                        MessageBox.Show("ไม่สามารถเปิดรอบได้ กรุณาติดต่อ Admin", "Message Show", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
    Private Sub btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancel.Click
        txt_pwd.Text = ""
        txt_user.Text = ""
        Login.Show()
        Login.KillLogin()
        Me.Close()
    End Sub
    Private Sub btn_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clear.Click
        txt_pwd.Text = ""
        txt_user.Text = ""
    End Sub
    Private Sub txt_pwd_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_pwd.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            If txt_user.Text <> "" And txt_pwd.Text <> "" Then
                Dim num_user As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_user where username='" & txt_user.Text & "' and password='" & txt_pwd.Text & "' LIMIT 1"))
                If num_user > 0 Then
                    Dim res_user As MySqlDataReader = con.mysql_query("select * from pos_user where username='" & txt_user.Text & "' and password='" & txt_pwd.Text & "' LIMIT 1")
                    res_user.Read()
                    Dim res_p As MySqlDataReader = con.mysql_query("select * from pos_user_permission_match where id_user='" & res_user.GetString("id") & "'")
                    res_p.Read()
                    If CInt(res_p.GetString("closing_bill")) = 1 Then
                        Dim res_r As MySqlDataReader
                        res_r = con.mysql_query("select create_date from pos_closebill order by id_ropbill asc limit 1")
                        res_r.Read()
                        Dim date_dt As DateTime = res_r.GetString("create_date")
                        Dim year As Integer
                        If date_dt.ToString("yyyy") > 2485 Then
                            year = CInt(date_dt.ToString("yyyy")) - 543
                        Else
                            year = CInt(date_dt.ToString("yyyy"))
                        End If
                        date_dt = year & date_dt.ToString("-MM-dd")

                        'หาว่ามีรอบนี้ วันนี้ ในระบบหรือยัง เป็น record เงินทอน สถานะเป้น 0
                        Dim str As String = ""
                        Dim id_rop As Integer = 0
                        Dim str_rop As String = ""
                        Dim rop As MySqlDataReader = con.mysql_query("select * from pos_audit where rop_date_aud LIKE '%" & date_dt.ToString("yyyy-MM-dd") & "%' and machine_aud='" & Login.getMacAddress() & "' order by id_aud DESC Limit 1 ")
                        rop.Read()
                        Dim num As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_audit where rop_date_aud LIKE '%" & date_dt.ToString("yyyy-MM-dd") & "%' and machine_aud='" & Login.getMacAddress() & "' "))
                        If num > 0 Then
                            id_rop = CInt(rop.GetString("id_ropbill_aud")) + 1
                            index.Label_Rop.Text = "รอบที่ " & id_rop
                            str_rop = "รอบที่ " & id_rop & " วันที่" & date_dt.ToString("dd/MM/yyyy")
                            str &= "INSERT pos_audit (id_ropbill_aud,name_rop_aud,rop_date_aud,type_aud,money_aud,action_by_aud,machine_aud,counter_money)" _
                                   & "VALUES('" & id_rop & "','" & str_rop & "','" & date_dt.ToString("yyyy-MM-dd HH:mm:ss") & "','0','0','" & txt_user.Text & "','" & Login.getMacAddress() & "','close');"
                        Else
                            id_rop = 1
                            index.Label_Rop.Text = "รอบที่ " & id_rop
                            str_rop = "รอบที่ " & id_rop & " วันที่" & date_dt.ToString("dd/MM/yyyy")
                            str &= "INSERT pos_audit (id_ropbill_aud,name_rop_aud,rop_date_aud,type_aud,money_aud,action_by_aud,machine_aud,counter_money)" _
                                   & "VALUES('" & id_rop & "','" & str_rop & "','" & date_dt.ToString("yyyy-MM-dd HH:mm:ss") & "','0','0','" & txt_user.Text & "','" & Login.getMacAddress() & "','close');"
                        End If
                        Dim q As Boolean = con.mysql_query(str)
                        If q = True Then
                            Login.query_ok_audit_defalut = True
                            'MessageBox.Show("บันทึกเรียบร้อย", "Message Show", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.Close()
                        Else
                            MessageBox.Show("ไม่สามารถเปิดรอบได้ กรุณาติดต่อ Admin", "Message Show", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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