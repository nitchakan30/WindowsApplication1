Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Text
Imports System
Public Class Admin_ConfigFormcomment
    Dim con As New Mysql
    Private Sub Admin_ConfigFormcomment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadData()
        Load_create_group_takehome()
        Load_detail_g()
    End Sub
    Private Sub ComboBox_St_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox_St.SelectedIndexChanged
        Dim ist As Integer = 0
        If ComboBox_St.Text.ToString = "ปิด" Then
            ist = 0
        Else
            ist = 1
        End If
        Dim query As Boolean = con.mysql_query("UPDATE pos_shop SET config_frm_commentord='" & ist & "'")
       
    End Sub
    Private Sub LoadData()
        Dim res As MySqlDataReader = con.mysql_query("select config_frm_commentord,config_frm_commentord_gh,send_captain_takehome from pos_shop")
        res.Read()
        If CInt(res.GetString("config_frm_commentord")) = 1 Then
            ComboBox_St.SelectedIndex = 1
        Else
            ComboBox_St.SelectedIndex = 0
        End If

        If CInt(res.GetString("config_frm_commentord_gh")) = 1 Then
            ComboBox1.SelectedIndex = 1
        Else
            ComboBox1.SelectedIndex = 0
        End If
        If CInt(res.GetString("send_captain_takehome")) = 1 Then
            ComboBox_stk.SelectedIndex = 1
        Else
            ComboBox_stk.SelectedIndex = 0
        End If
    End Sub

    
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim ist As Integer = 0
        If ComboBox1.Text.ToString = "ปิด" Then
            ist = 0
        Else
            ist = 1
        End If
        Dim query As Boolean = con.mysql_query("UPDATE pos_shop SET config_frm_commentord_gh='" & ist & "'")
        
    End Sub

    Private Sub ComboBox_stk_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox_stk.SelectedIndexChanged
        Dim ist As Integer = 0
        If ComboBox_stk.Text.ToString = "ปิด" Then
            ist = 0
        Else
            ist = 1
        End If
        Dim query As Boolean = con.mysql_query("UPDATE pos_shop SET send_captain_takehome='" & ist & "'")
     
    End Sub
    Private Sub Load_detail_g()
        'โหลดข้อมูล Tabspage2
        Dim res1 As MySqlDataReader = con.mysql_query("SELECT * FROM pos_catprd ORDER BY id ASC")
        Dim num As Integer = con.mysql_num_rows(res1)
        If num > 0 Then
            Dim objReader As New System.IO.StreamReader("setting_grouptakehome.bat", Encoding.UTF8)
            Dim TextLine() As String
            Do While objReader.Peek <> -1
                TextLine = objReader.ReadLine().ToString.Trim.Split("=")

                For j As Integer = 1 To num
                    Dim txt As Label = CType(TableLayoutPanel1.Controls.Item("txt_" & j.ToString()), Label)
                    Dim checkb_p As CheckBox = CType(TableLayoutPanel1.Controls.Item("checkbox_onoff" & j.ToString()), CheckBox)
                    If txt.Tag = TextLine(0).ToString.Trim Then

                        If TextLine(1).ToString.Trim = 0 Then
                            checkb_p.Checked = False
                        Else
                            checkb_p.Checked = True
                        End If

                    End If

                Next


            Loop
            objReader.Close()
            objReader.Dispose()
        End If

    End Sub
    Private Sub Load_create_group_takehome()
        'สร้าง Label และ  Textbox ใน tabspage2
        Dim res As MySqlDataReader = con.mysql_query("SELECT * FROM pos_catprd ORDER BY namecat_en ASC")
        Dim st_x As Integer = 10
        Dim ed_y As Integer = 15
        Dim stt_x As Integer = 160
        Dim edt_y As Integer = 10
        Dim stt1_x As Integer = 380
        TableLayoutPanel1.Controls.Clear()
        Dim i As Integer = 1
        While res.Read()
            Dim Label1 As New Label
            Label1.Name = "txt_" & i
            Label1.Text = res.GetString("namecat_th")
            Label1.Tag = res.GetString("id")
            Label1.AutoSize = True


            Dim checkBox_onoff As New CheckBox
            checkBox_onoff.Name = "checkBox_onoff" & i
            checkBox_onoff.Width = "100"
            checkBox_onoff.Text = "Show In Page"
            checkBox_onoff.Tag = res.GetString("id")
            checkBox_onoff.Checked = False

            i += 1
            TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.AutoSize))
            TableLayoutPanel1.RowCount += 1
            TableLayoutPanel1.Controls.Add(Label1, 0, TableLayoutPanel1.RowCount - 0)
            TableLayoutPanel1.Controls.Add(checkBox_onoff, 1, TableLayoutPanel1.RowCount - 0)


        End While
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim res1 As MySqlDataReader = con.mysql_query("SELECT * FROM pos_catprd ORDER BY id ASC")
        Dim num As Integer = con.mysql_num_rows(res1)
        If num > 0 Then
            Dim aryText(num) As String
            For j As Integer = 1 To num
                Dim p As Integer = 0
                Dim txt As Label = CType(TableLayoutPanel1.Controls.Item("txt_" & j.ToString()), Label)
                Dim checkbox_p As CheckBox = CType(TableLayoutPanel1.Controls.Item("checkBox_onoff" & j.ToString()), CheckBox)
                '  MsgBox(checkbox_p.Checked)
                If checkbox_p.Checked = True Then
                    p = 1
                Else
                    p = 0
                End If
                aryText(j - 1) = txt.Tag & "=" & p

            Next
            File.WriteAllText("setting_grouptakehome.bat", String.Empty)
            Dim objWriter As New System.IO.StreamWriter("setting_grouptakehome.bat", True)
            For i As Integer = 0 To num

                objWriter.WriteLine(aryText(i))
            Next
            objWriter.Close()
            objWriter.Dispose()

            MsgBox("บันทึกเรียบร้อย")
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class