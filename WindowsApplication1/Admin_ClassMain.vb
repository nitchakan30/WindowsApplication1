Imports MySql.Data.MySqlClient
Public Class Admin_ClassMain
    Dim con As New Mysql
    Public Function dateFormat(ByVal ndate As Date) As String
        Dim newd As String = ndate.ToString("yyyy-MM-dd HH:mm:ss")
        Dim Year As String = newd.Substring(0, 4)
        If Year > 2500 Then
            Year -= 543
        End If
        Return ndate.ToString(Year & "-MM-dd HH:mm:ss")
    End Function

    Public Function RuningInv()
        'Date Time Covers
        Dim dateNew As DateTime
        If CInt(Login.DateData.ToString("yyyy")) > 2450 Then
            dateNew = CInt(Login.DateData.ToString("yyyy")) - 543 & Login.DateData.ToString("-MM-dd")
        Else
            dateNew = Login.DateData.ToString("yyyy-MM-dd")
        End If
        Dim num As String = ""
        Dim str1 As Integer = 0
        Dim f As String = ""
        Dim u As Integer = 0
        Dim res_num As MySqlDataReader = con.mysql_query("select * from pos_num_runing")
        While res_num.Read()
            If res_num.GetString("y_rn_inv_st") = "1" Then
                If res_num.GetString("y_rn_inv_st").Length >= 1 And res_num.GetString("y_rn_inv_st") <= 2 Then
                    num += Login.DateData.ToString("yy")
                Else
                    num += Login.DateData.ToString("yyyy")
                End If
            End If
            If res_num.GetString("m_rn_inv_st") = "1" Then
                num += Login.DateData.ToString("MM")
            End If
            If res_num.GetString("d_rn_inv_st") = "1" Then
                num += Login.DateData.ToString("dd")
            End If
            u = res_num.GetString("num_rn_inv").Length

            Dim res As MySqlDataReader = con.mysql_query("select namber_inv from pos_invoice order by namber_inv desc limit 1")
            While res.Read()
                If res.GetString("namber_inv") <> "" Then
                    str1 = CInt((Microsoft.VisualBasic.Right(res.GetString("namber_inv"), u)))
                Else
                    str1 = 0
                End If
            End While

        End While

        If Login.DateData.ToString("dd") = "01" Then
            Dim numDate As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_invoice where DAY(create_date)='01' and MONTH(create_date)='" & dateNew.ToString("MM") & "' and YEAR(create_date)='" & dateNew.ToString("yyyy") & "' order by namber_inv desc"))
            Dim num_inv As Integer = con.mysql_num_rows(con.mysql_query("select COUNT(*) from pos_invoice where DAY(create_date)='01' and MONTH(create_date)='" & dateNew.ToString("MM") & "' and YEAR(create_date)='" & dateNew.ToString("yyyy") & "' order by namber_inv desc"))
            If numDate = 1 Then
                str1 = str1
            ElseIf numDate = 0 Or num_inv = 0 Then
                str1 = 0
            Else
                str1 = str1
            End If
        Else
            str1 = str1
        End If

        'INVOICE NUMBER
        str1 = str1 + 1
        Dim string1 As String = ""
        For value As Integer = u - 1 To CInt(CStr(str1).Length) Step -1
            f &= "0"
        Next
        f &= str1

        Return num & f
    End Function
    Public Function RuningPOS()
        'Date Time Covers
        Dim dateNew As DateTime
        If CInt(Login.DateData.ToString("yyyy")) > 2450 Then
            dateNew = CInt(Login.DateData.ToString("yyyy")) - 543 & Login.DateData.ToString("-MM-dd")
        Else
            dateNew = Login.DateData.ToString("yyyy-MM-dd")
        End If
        Dim num As String = ""
        Dim str1 As Integer = 0
        Dim f As String = ""
        Dim u As Integer = 0
        Dim res_num As MySqlDataReader = con.mysql_query("select * from pos_num_runing")
        While res_num.Read()
            If res_num.GetString("y_rn_inv_st") = "1" Then
                If res_num.GetString("y_rn_inv_st").Length >= 1 And res_num.GetString("y_rn_inv_st") <= 2 Then
                    num += Login.DateData.ToString("yy")
                Else
                    num += Login.DateData.ToString("yyyy")
                End If
            End If
            If res_num.GetString("m_rn_inv_st") = "1" Then
                num += Login.DateData.ToString("MM")
            End If
            If res_num.GetString("d_rn_inv_st") = "1" Then
                num += Login.DateData.ToString("dd")
            End If
            u = res_num.GetString("num_rn_inv").Length

            Dim res As MySqlDataReader = con.mysql_query("select * from pos_invoice order by id desc limit 1")
            While res.Read()
                If res.GetString("namber_inv") <> "" Then
                    str1 = CInt((Microsoft.VisualBasic.Right(res.GetString("namber_inv"), u)))
                Else
                    str1 = 0
                End If
            End While
        End While
        If Login.DateData.ToString("dd") = "01" Then
            Dim numDate As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_invoice where DAY(create_date)='01' and MONTH(create_date)='" & dateNew.ToString("MM") & "' and YEAR(create_date)='" & dateNew.ToString("yyyy") & "' order by id desc"))
            Dim num_inv As Integer = con.mysql_num_rows(con.mysql_query("select COUNT(*) from pos_invoice where DAY(create_date)='01' and MONTH(create_date)='" & dateNew.ToString("MM") & "' and YEAR(create_date)='" & dateNew.ToString("yyyy") & "' order by id desc"))
            If numDate = 1 Then
                str1 = str1
            ElseIf numDate = 0 Or num_inv = 0 Then
                str1 = 0
            Else
                str1 = str1
            End If
        Else
            str1 = str1
        End If
        'INVOICE NUMBER
        str1 = str1 + 1
        Dim string1 As String = ""
        For value As Integer = u - 1 To CInt(CStr(str1).Length) Step -1
            f &= "0"
        Next
        f &= str1

        Return "PS" & num & f
    End Function
    Public Function RuningRb()
        ' Login.DateData = Date.Now()
        Dim num As String = ""
        Dim str1 As Integer = 0
        Dim f As String = ""
        Dim u As Integer = 0
        Dim res_num As MySqlDataReader = con.mysql_query("select * from pos_num_runing")
        While res_num.Read()
            If res_num.GetString("y_rn_rb_st") = "1" Then
                If res_num.GetString("y_rn_rb_st").Length >= 1 And res_num.GetString("y_rn_rb_st") <= 2 Then
                    num += Login.DateData.ToString("yy")
                Else
                    num += Login.DateData.ToString("yyyy")
                End If
            End If
            If res_num.GetString("m_rn_rb_st") = "1" Then
                num += Login.DateData.ToString("MM")
            End If
            If res_num.GetString("d_rn_rb_st") = "1" Then
                num += Login.DateData.ToString("dd")
            End If
            u = res_num.GetString("num_rn_rb").Length

            Dim res As MySqlDataReader = con.mysql_query("select * from pos_order_list where tryNumber<>'0' and DAY(create_date)='" & Login.DateData.ToString("dd") & "' and MONTH(create_date)='" & Login.DateData.ToString("MM") & "' and YEAR(create_date)='" & Login.DateData.ToString("yyyy") & "' order by tryNumber desc limit 1")
            While res.Read()
                If res.GetString("tryNumber") <> "" And res.GetString("tryNumber") <> "0" Then
                    str1 = CInt((Microsoft.VisualBasic.Right(res.GetString("tryNumber"), u)))
                Else
                    str1 = 0
                End If
            End While

        End While
        'INVOICE NUMBER
        str1 = str1 + 1
        Dim string1 As String = ""
        For value As Integer = u - 1 To CInt(CStr(str1).Length) Step -1
            f &= "0"
        Next
        f &= str1
        Return "RB" & num & f
    End Function
    Public Function RuningGohome()
        'Date Time Covers
        Dim dateNew As DateTime
        If CInt(Login.DateData.ToString("yyyy")) > 2450 Then
            dateNew = CInt(Login.DateData.ToString("yyyy")) - 543 & Login.DateData.ToString("-MM-dd")
        Else
            dateNew = Login.DateData.ToString("yyyy-MM-dd")
        End If
        Dim num As String = ""
        Dim str1 As Integer = 0
        Dim f As String = ""
        Dim u As Integer = 0
        Dim res_num As MySqlDataReader = con.mysql_query("select * from pos_num_runing")
        While res_num.Read()
            If res_num.GetString("y_rn_inv_st") = "1" Then
                If res_num.GetString("y_rn_inv_st").Length >= 1 And res_num.GetString("y_rn_inv_st") <= 2 Then
                    num += Login.DateData.ToString("yy")
                Else
                    num += Login.DateData.ToString("yyyy")
                End If
            End If
            If res_num.GetString("m_rn_inv_st") = "1" Then
                num += Login.DateData.ToString("MM")
            End If
            If res_num.GetString("d_rn_inv_st") = "1" Then
                num += Login.DateData.ToString("dd")
            End If
            u = res_num.GetString("num_rn_inv").Length

            Dim res As MySqlDataReader = con.mysql_query("select * from pos_order_list where status_open='gohome' order by code_gohome desc limit 1")
            While res.Read()
                If res.GetString("code_gohome") <> "" Then
                    str1 = CInt((Microsoft.VisualBasic.Right(res.GetString("code_gohome"), u)))
                Else
                    str1 = 0
                End If
            End While

        End While

        If Login.DateData.ToString("dd") = "01" Then
            Dim numDate As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_order_list where DAY(create_date)='01' and MONTH(create_date)='" & dateNew.ToString("MM") & "' and YEAR(create_date)='" & dateNew.ToString("yyyy") & "' order by id_ord desc"))
            Dim num_inv As Integer = con.mysql_num_rows(con.mysql_query("select COUNT(*) from pos_order_list where DAY(create_date)='01' and MONTH(create_date)='" & dateNew.ToString("MM") & "' and YEAR(create_date)='" & dateNew.ToString("yyyy") & "' order by id_ord desc"))
            If numDate = 1 Then
                str1 = str1
            ElseIf numDate = 0 Or num_inv = 0 Then
                str1 = 0
            Else
                str1 = str1
            End If
        Else
            str1 = str1
        End If

        'INVOICE NUMBER
        str1 = str1 + 1
        Dim string1 As String = ""
        For value As Integer = u - 1 To CInt(CStr(str1).Length) Step -1
            f &= "0"
        Next
        f &= str1

        Return "G" & num & f
    End Function
    Public Function CreateBillOntb(ByVal id_tb)
        Dim isJoinTb As Boolean = False
        Dim b As MySqlDataReader = con.mysql_query("select * from pos_table_system where id='" & id_tb & "'")
        b.Read()
        If CInt(b.GetString("id_join_tb")) > 0 Then
            isJoinTb = True
        End If
        Dim num_inv As String = "0"
        Dim num As Integer = con.mysql_num_rows(con.mysql_query("SELECT invoice_number as invoice_number FROM pos_table_system where id='" & id_tb & "' and status='2' and invoice_number<>'0' "))
        If num > 0 Then
            'Query insert values in parameter
            Dim f As MySqlDataReader = con.mysql_query("SELECT invoice_number as invoice_number FROM pos_table_system where id='" & id_tb & "' and status='2' and invoice_number<>'0' ")
            While f.Read()
                num_inv = f.GetString("invoice_number")
            End While
            f.Close()
        Else
            Dim number_invoice As String = RuningInvTEMP()
            Dim numPos As String = RuningPOSTEMP()
            Dim qty_prd As Integer = 0
            Dim priceAll As Double = 0.0
            Dim rf_payment_type As String = "1"
            Dim des_payment As String = ""

            Dim str_insert As String = ""
            str_insert &= "INSERT INTO pos_invoice_temp (namber_inv,number_pos,qty,price_all,create_by,create_date,rf_payment_type,des_payment,machin_number,price_exclu_vat,vat,serviceCh,discount,discount_des,discount_sum,ref_id_payment_acc,machine_inv,rf_id_card,money_recript,money_ton,close_rop_id_inv,close_rop_name_inv) " _
                 & "VALUES('" & number_invoice & "','" & numPos & "','" & qty_prd & "','" & priceAll & "','" & Login.username & "','" & Login.DateData.ToString("yyyy-MM-dd ") & Date.Now().ToString("HH:mm:ss") & "','" & rf_payment_type & "','" & des_payment & "'," _
                 & "'" & System.Net.Dns.GetHostName() & "','0','0','0','0','0','0','0','" & Login.getMacAddress & "','0','0.0','0','" & Login.Id_RopBill & "','" & Login.Str_Ropbill & "');"
           
            str_insert &= "UPDATE pos_table_system SET invoice_number='" & number_invoice & "' WHERE id='" & id_tb & "' and status='2';"
            Dim insertDb As Boolean = con.mysql_query(str_insert)
            'Query insert values in parameter
            Dim f As MySqlDataReader = con.mysql_query("SELECT invoice_number as invoice_number FROM pos_table_system where id='" & id_tb & "' and status='2' and invoice_number<>'0' ")
            While f.Read()
                num_inv = number_invoice
            End While
            f.Close()
        End If
        Return num_inv
    End Function
    Public Function RuningInvTEMP()
        'Date Time Covers
        Dim dateNew As DateTime
        If CInt(Login.DateData.ToString("yyyy")) > 2450 Then
            dateNew = CInt(Login.DateData.ToString("yyyy")) - 543 & Login.DateData.ToString("-MM-dd")
        Else
            dateNew = Login.DateData.ToString("yyyy-MM-dd")
        End If
        Dim num As String = ""
        Dim str1 As Integer = 0
        Dim f As String = ""
        Dim u As Integer = 0
        Dim res_num As MySqlDataReader = con.mysql_query("select * from pos_num_runing")
        While res_num.Read()
            If res_num.GetString("y_rn_inv_st") = "1" Then
                If res_num.GetString("y_rn_inv_st").Length >= 1 And res_num.GetString("y_rn_inv_st") <= 2 Then
                    num += Login.DateData.ToString("yy")
                Else
                    num += Login.DateData.ToString("yyyy")
                End If
            End If
            If res_num.GetString("m_rn_inv_st") = "1" Then
                num += Login.DateData.ToString("MM")
            End If
            If res_num.GetString("d_rn_inv_st") = "1" Then
                num += Login.DateData.ToString("dd")
            End If
            u = res_num.GetString("num_rn_inv").Length

            Dim res As MySqlDataReader = con.mysql_query("select * from pos_invoice_temp order by id desc limit 1")
            While res.Read()
                If res.GetString("namber_inv") <> "" Then
                    str1 = CInt((Microsoft.VisualBasic.Right(res.GetString("namber_inv"), u)))
                Else
                    str1 = 0
                End If
            End While

        End While

        If Login.DateData.ToString("dd") = "01" Then
            Dim numDate As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_invoice_temp where DAY(create_date)='01' and MONTH(create_date)='" & dateNew.ToString("MM") & "' and YEAR(create_date)='" & dateNew.ToString("yyyy") & "' order by id desc"))
            Dim num_inv As Integer = con.mysql_num_rows(con.mysql_query("select COUNT(*) from pos_invoice_temp where DAY(create_date)='01' and MONTH(create_date)='" & dateNew.ToString("MM") & "' and YEAR(create_date)='" & dateNew.ToString("yyyy") & "' order by id desc"))
            If numDate = 1 Then
                str1 = str1
            ElseIf numDate = 0 Or num_inv = 0 Then
                str1 = 0
            Else
                str1 = str1
            End If
        Else
            str1 = str1
        End If

        'INVOICE NUMBER
        str1 = str1 + 1
        Dim string1 As String = ""
        For value As Integer = u - 1 To CInt(CStr(str1).Length) Step -1
            f &= "0"
        Next
        f &= str1

        Return num & f
    End Function
    Public Function RuningPOSTEMP()
        'Date Time Covers
        Dim dateNew As DateTime
        If CInt(Login.DateData.ToString("yyyy")) > 2450 Then
            dateNew = CInt(Login.DateData.ToString("yyyy")) - 543 & Login.DateData.ToString("-MM-dd")
        Else
            dateNew = Login.DateData.ToString("yyyy-MM-dd")
        End If
        Dim num As String = ""
        Dim str1 As Integer = 0
        Dim f As String = ""
        Dim u As Integer = 0
        Dim res_num As MySqlDataReader = con.mysql_query("select * from pos_num_runing")
        While res_num.Read()
            If res_num.GetString("y_rn_inv_st") = "1" Then
                If res_num.GetString("y_rn_inv_st").Length >= 1 And res_num.GetString("y_rn_inv_st") <= 2 Then
                    num += Login.DateData.ToString("yy")
                Else
                    num += Login.DateData.ToString("yyyy")
                End If
            End If
            If res_num.GetString("m_rn_inv_st") = "1" Then
                num += Login.DateData.ToString("MM")
            End If
            If res_num.GetString("d_rn_inv_st") = "1" Then
                num += Login.DateData.ToString("dd")
            End If
            u = res_num.GetString("num_rn_inv").Length

            Dim res As MySqlDataReader = con.mysql_query("select * from pos_invoice_temp order by id desc limit 1")
            While res.Read()
                If res.GetString("namber_inv") <> "" Then
                    str1 = CInt((Microsoft.VisualBasic.Right(res.GetString("namber_inv"), u)))
                Else
                    str1 = 0
                End If
            End While
        End While
        If Login.DateData.ToString("dd") = "01" Then
            Dim numDate As Integer = con.mysql_num_rows(con.mysql_query("select * from pos_invoice_temp where DAY(create_date)='01' and MONTH(create_date)='" & dateNew.ToString("MM") & "' and YEAR(create_date)='" & dateNew.ToString("yyyy") & "' order by id desc"))
            Dim num_inv As Integer = con.mysql_num_rows(con.mysql_query("select COUNT(*) from pos_invoice_temp where DAY(create_date)='01' and MONTH(create_date)='" & dateNew.ToString("MM") & "' and YEAR(create_date)='" & dateNew.ToString("yyyy") & "' order by id desc"))
            If numDate = 1 Then
                str1 = str1
            ElseIf numDate = 0 Or num_inv = 0 Then
                str1 = 0
            Else
                str1 = str1
            End If
        Else
            str1 = str1
        End If
        'INVOICE NUMBER
        str1 = str1 + 1
        Dim string1 As String = ""
        For value As Integer = u - 1 To CInt(CStr(str1).Length) Step -1
            f &= "0"
        Next
        f &= str1

        Return "PT" & num & f
    End Function
End Class
