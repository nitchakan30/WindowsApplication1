Imports MySql.Data.MySqlClient
Public Class Admin_ConfigNumRuning
    Dim con As New Mysql
    Private Sub Admin_ConfigNumRuning_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadData()
    End Sub
    Private Sub loadData()
        Dim res As MySqlDataReader = con.mysql_query("select * from pos_num_runing")
        While res.Read()
            Dim y_rn_inv As String = ""
            If res.GetString("y_rn_inv").Length > 1 And res.GetString("y_rn_inv").Length <= 2 Then
                y_rn_inv = "xx"
            ElseIf res.GetString("y_rn_inv").Length > 2 And res.GetString("y_rn_inv").Length <= 4 Then
                y_rn_inv = "xxxx"
            Else
                y_rn_inv = "xxxx"
            End If

            Dim m_rn_inv As String = ""
            If res.GetString("m_rn_inv").Length > 1 And res.GetString("m_rn_inv").Length <= 2 Then
                m_rn_inv = "xx"
            End If
            Dim d_rn_inv As String = ""
            If res.GetString("d_rn_inv").Length > 1 And res.GetString("d_rn_inv").Length <= 2 Then
                d_rn_inv = "xx"
            End If

            Dim num_rn_inv As String = ""
            If res.GetString("num_rn_inv").Length > 1 And res.GetString("num_rn_inv").Length <= 7 Then
                For i As Integer = 0 To res.GetString("num_rn_inv").Length - 1
                    num_rn_inv += "x"
                Next
            End If

            Dim y_rn_rb As String = ""
            If res.GetString("y_rn_rb").Length > 1 And res.GetString("y_rn_rb").Length <= 2 Then
                y_rn_rb = "xx"
            ElseIf res.GetString("y_rn_rb").Length > 2 And res.GetString("y_rn_rb").Length <= 4 Then
                y_rn_rb = "xxxx"
            Else
                y_rn_rb = "xxxx"
            End If

            Dim m_rn_rb As String = ""
            If res.GetString("m_rn_inv").Length > 1 And res.GetString("m_rn_rb").Length <= 2 Then
                m_rn_rb = "xx"
            End If
            Dim d_rn_rb As String = ""
            If res.GetString("d_rn_inv").Length > 1 And res.GetString("d_rn_rb").Length <= 2 Then
                d_rn_rb = "xx"
            End If

            Dim num_rn_rb As String = ""
            If res.GetString("num_rn_rb").Length > 1 And res.GetString("num_rn_rb").Length <= 7 Then
                For i As Integer = 0 To res.GetString("num_rn_rb").Length - 1
                    num_rn_rb += "x"
                Next
            End If
            txt_year_inv.Text = y_rn_inv
            txt_month_inv.Text = m_rn_inv
            txt_day_inv.Text = d_rn_inv
            txt_num_inv.Text = num_rn_inv
            txt_year_rb.Text = y_rn_rb
            txt_month_rb.Text = m_rn_rb
            txt_day_rb.Text = d_rn_rb
            txt_num_rb.Text = num_rn_rb

            '-------- Check Box INv------'
            If res.GetString("y_rn_inv_st") = "1" Then
                CheckBox_Yinv.CheckState = CheckState.Checked
            Else
                CheckBox_Yinv.CheckState = CheckState.Unchecked
            End If

            If res.GetString("m_rn_inv_st") = "1" Then
                CheckBox_Minv.CheckState = CheckState.Checked
            Else
                CheckBox_Minv.CheckState = CheckState.Unchecked
            End If
            If res.GetString("d_rn_inv_st") = "1" Then
                CheckBox_Dinv.CheckState = CheckState.Checked
            Else
                CheckBox_Dinv.CheckState = CheckState.Unchecked
            End If

            '------------- RB -------------'
            If res.GetString("y_rn_rb_st") = "1" Then
                CheckBox_Yrb.CheckState = CheckState.Checked
            Else
                CheckBox_Yrb.CheckState = CheckState.Unchecked
            End If

            If res.GetString("m_rn_rb_st") = "1" Then
                CheckBox_Mrb.CheckState = CheckState.Checked
            Else
                CheckBox_Mrb.CheckState = CheckState.Unchecked
            End If
            If res.GetString("d_rn_rb_st") = "1" Then
                CheckBox_Drb.CheckState = CheckState.Checked
            Else
                CheckBox_Drb.CheckState = CheckState.Unchecked
            End If

        End While
    End Sub

    Private Sub save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles save.Click
        Try
            ' Login.DateData = Date.Now
            Dim date1 As Date
            If CInt(Login.DateData.ToString("yyyy")) > 2450 Then
                date1 = CInt(Login.DateData.ToString("yyyy")) - 543 & Login.DateData.ToString("-MM-dd")
            Else
                date1 = CInt(Login.DateData.ToString("yyyy")) & Login.DateData.ToString("-MM-dd")
            End If

            Dim year_inv As String = ""
            If txt_year_inv.TextLength >= 1 And txt_year_inv.TextLength <= 2 Then
                year_inv = date1.ToString("yy")

            ElseIf txt_year_inv.TextLength > 2 And txt_year_inv.TextLength <= 4 Then
                year_inv = date1.ToString("yyyy")
            End If

            Dim month_inv As String = ""
            If txt_month_inv.TextLength > 1 And txt_month_inv.TextLength <= 2 Then
                month_inv = date1.ToString("MM")
            End If
            Dim day_inv As String = ""
            If txt_day_inv.TextLength > 1 And txt_day_inv.TextLength <= 2 Then
                day_inv = date1.ToString("dd")
            End If


            Dim year_rb As String = ""
            If txt_year_rb.TextLength >= 1 And txt_year_rb.TextLength <= 2 Then
                year_rb = date1.ToString("yy")

            ElseIf txt_year_rb.TextLength > 2 And txt_year_rb.TextLength <= 4 Then
                year_rb = date1.ToString("yyyy")
            End If
            Dim month_rb As String = ""
            If txt_month_rb.TextLength > 1 And txt_month_rb.TextLength <= 2 Then
                month_rb = date1.ToString("MM")
            End If
            Dim day_rb As String = ""
            If txt_day_rb.TextLength > 1 And txt_day_rb.TextLength <= 2 Then
                day_rb = date1.ToString("dd")
            End If

            '-------- Check Box INv------'
            Dim CheckYinv As Integer = 0
            If CheckBox_Yinv.Checked = True Then
                CheckYinv = 1
            Else
                CheckYinv = 0
            End If

            Dim CheckMinv As Integer = 0
            If CheckBox_Minv.Checked = True Then
                CheckMinv = 1
            Else
                CheckMinv = 0
            End If

            Dim CheckDinv As Integer = 0
            If CheckBox_Dinv.Checked = True Then
                CheckDinv = 1
            Else
                CheckDinv = 0
            End If

            '------------- RB -------------'
            Dim CheckYrb As Integer = 0
            If CheckBox_Yrb.Checked = True Then
                CheckYrb = 1
            Else
                CheckYrb = 0
            End If
            Dim CheckMrb As Integer = 0
            If CheckBox_Mrb.Checked = True Then
                CheckMrb = 1
            Else
                CheckMrb = 0
            End If
            Dim CheckDrb As Integer = 0
            If CheckBox_Drb.Checked = True Then
                CheckDrb = 1
            Else
                CheckDrb = 0
            End If

            con.mysql_query("DELETE FROM pos_num_runing")
            Dim qy As Boolean = con.mysql_query("INSERT INTO pos_num_runing (y_rn_inv,m_rn_inv,d_rn_inv,num_rn_inv," _
        & "y_rn_rb,m_rn_rb,d_rn_rb,num_rn_rb,y_rn_inv_st,m_rn_inv_st,d_rn_inv_st,y_rn_rb_st,m_rn_rb_st,d_rn_rb_st) VALUES('" & year_inv & "'," _
        & "'" & month_inv & "','" & day_inv & "','" & txt_num_inv.Text & "','" & year_rb & "'," _
        & "'" & month_rb & "','" & day_rb & "','" & txt_num_rb.Text & "','" & CheckYinv & "','" & CheckMinv & "','" & CheckDinv & "'," _
        & "'" & CheckYrb & "','" & CheckMrb & "','" & CheckDrb & "')")
           
            If qy = True Then
                MsgBox("Save Complete", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancel.Click
        Me.Close()
    End Sub
End Class