Imports MySql.Data.MySqlClient
Imports System
Imports System.IO
Imports System.Text
Imports System.Collections.Generic
Imports System.Management
Public Class Admin_ConfigPrint
    Dim con As New Mysql
    Private Sub Admin_ConfigPrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cmbPrinterList.Items.Clear()
        cmbPrinterList2.Items.Clear()
        cmbPrinterList3.Items.Clear()
        cmbPrinterList4.Items.Clear()
        For Each sPrinters In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            cmbPrinterList.Items.Add(sPrinters)
            cmbPrinterList2.Items.Add(sPrinters)
            cmbPrinterList3.Items.Add(sPrinters)
            cmbPrinterList4.Items.Add(sPrinters)
        Next
        Load_detail() 'โหลดข้อมูล Tabspage1
        Load_create_g() 'สร้าง Label และ  Textbox ใน tabspage2
        Load_detail_g() 'โหลดข้อมูล Tabspage2
        Load_create_subg()
        Load_detail_subg()
    End Sub

    Private Sub Load_detail()
        'โหลดข้อมูล Tabspage1
        Dim objReader As New System.IO.StreamReader("printer.txt", Encoding.UTF8)
        Dim TextLine() As String
        Do While objReader.Peek() <> -1
            TextLine = objReader.ReadLine().ToString.Trim.Split("=")
            If TextLine(0).ToString.Trim = "inv" Then
                'TextBox_invoice.Text = TextLine(1).ToString.Trim
                cmbPrinterList.Text = TextLine(1).ToString
            ElseIf TextLine(0).ToString.Trim = "trybill" Then
                ' TextBox_trybill.Text = TextLine(1).ToString.Trim
                cmbPrinterList2.Text = TextLine(1).ToString
            ElseIf TextLine(0).ToString.Trim = "rpt_front" Then
                'TextBox_report.Text = TextLine(1).ToString.Trim
                cmbPrinterList3.Text = TextLine(1).ToString
            ElseIf TextLine(0).ToString.Trim = "rpt_backend" Then
                'TextBox_backend.Text = TextLine(1).ToString.Trim
                cmbPrinterList4.Text = TextLine(1).ToString
            End If
        Loop
        objReader.Close()
    End Sub
    Private Sub Load_detail_g()
        'โหลดข้อมูล Tabspage2
        Dim res1 As MySqlDataReader = con.mysql_query("SELECT * FROM pos_catprd ORDER BY id ASC")
        Dim num As Integer = con.mysql_num_rows(res1)
        If num > 0 Then
            Dim objReader As New System.IO.StreamReader("printer_g.txt", Encoding.UTF8)
            Dim TextLine() As String
            Do While objReader.Peek <> -1
                TextLine = objReader.ReadLine().ToString.Trim.Split("=")
                For j As Integer = 1 To num
                    Dim txt As ComboBox = CType(TableLayoutPanel1.Controls.Item("txt_" & j.ToString()), ComboBox)
                    Dim check_send As CheckBox = CType(TableLayoutPanel1.Controls.Item("checkbox_print" & j.ToString()), CheckBox)
                    Dim checkb_p As CheckBox = CType(TableLayoutPanel1.Controls.Item("checkbox_onoff" & j.ToString()), CheckBox)
                    If txt.Tag = TextLine(0).ToString.Trim Then
                        txt.Text = TextLine(1).ToString
                        If TextLine(3).ToString.Trim = 0 Then
                            checkb_p.Checked = False
                        Else
                            checkb_p.Checked = True
                        End If
                        If TextLine(2).ToString.Trim = 0 Then
                            check_send.Checked = False
                        Else
                            check_send.Checked = True
                        End If
                    End If
                    
                Next
            Loop
            objReader.Close()
            objReader.Dispose()
        End If

    End Sub
    Private Sub Load_detail_subg()
        'โหลดข้อมูล Tabspage2
        Dim res1 As MySqlDataReader = con.mysql_query("SELECT  pos_catsubprd.id as id,pos_catsubprd.name_en as name_en," _
            & "pos_catsubprd.name_th as name_th,pos_catprd.namecat_en as namecat_en,pos_catprd.namecat_th as namecat_th " _
            & "FROM `pos_catsubprd` LEFT JOIN pos_catprd ON pos_catprd.id = pos_catsubprd.ref_id_cat  where pos_catsubprd.id_status_sales='1' ORDER BY pos_catprd.namecat_en ASC")
        Dim num As Integer = con.mysql_num_rows(res1)
        If num > 0 Then
            Dim objReader As New System.IO.StreamReader("printer_sg.txt", Encoding.UTF8)
            Dim TextLine() As String
            Do While objReader.Peek <> -1
                TextLine = objReader.ReadLine().ToString.Trim.Split("=")
                For j As Integer = 1 To num
                    Dim txt As ComboBox = CType(TableLayoutPanel2.Controls.Item("txt_sg" & j.ToString()), ComboBox)
                    Dim check_send As CheckBox = CType(TableLayoutPanel2.Controls.Item("checkbox_print_sg" & j.ToString()), CheckBox)
                    Dim checkb_p As CheckBox = CType(TableLayoutPanel2.Controls.Item("checkbox_onoff_sg" & j.ToString()), CheckBox)
                    If txt.Tag = TextLine(0).ToString.Trim Then
                        txt.Text = TextLine(1).ToString
                        If TextLine(3).ToString.Trim = 0 Then
                            checkb_p.Checked = False
                        Else
                            checkb_p.Checked = True
                        End If
                        If TextLine(2).ToString.Trim = 0 Then
                            check_send.Checked = False
                        Else
                            check_send.Checked = True
                        End If
                    End If

                Next
            Loop
            objReader.Close()
            objReader.Dispose()
        End If

    End Sub
    Private Sub Load_create_g()
        'สร้าง Label และ  Textbox ใน tabspage2
        Dim res As MySqlDataReader = con.mysql_query("SELECT * FROM pos_catprd ORDER BY namecat_en ASC")
        TableLayoutPanel1.Controls.Clear()
        TableLayoutPanel1.RowCount = 0
        Dim i As Integer = 1
        While res.Read()
           
            Dim Label1 As New Label
            Label1.Name = "name" & res.GetString("id")
            If Login.LangG = "EN" Then
                Label1.Text = res.GetString("namecat_en")
            Else
                Label1.Text = res.GetString("namecat_th")
            End If
            Label1.AutoSize = True

            Dim ComboBox As New ComboBox
            ComboBox.DropDownStyle = ComboBoxStyle.DropDownList
            ComboBox.Name = "txt_" & i
            ComboBox.Width = "200"
            ComboBox.Tag = res.GetString("id")
            'ComboBox.Location = New Point(stt_x, edt_y)
            ComboBox.Items.Clear()

            For Each sPrinters In System.Drawing.Printing.PrinterSettings.InstalledPrinters
                ComboBox.Items.Add(sPrinters)
            Next

            Dim checkBox As New CheckBox
            checkBox.Name = "checkbox_print" & i
            checkBox.Width = "200"
            checkBox.Text = "Copy 2 Print Send Captain Order"
            checkBox.Tag = res.GetString("id")
            checkBox.Checked = False

            Dim checkBox_onoff As New CheckBox
            checkBox_onoff.Name = "checkBox_onoff" & i
            checkBox_onoff.Width = "79"
            checkBox_onoff.Text = "Print"
            checkBox_onoff.Tag = res.GetString("id")
            checkBox_onoff.Checked = False

            i += 1
            TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.AutoSize))
            TableLayoutPanel1.RowCount += 1
            TableLayoutPanel1.Controls.Add(Label1, 0, TableLayoutPanel1.RowCount - 0)
            TableLayoutPanel1.Controls.Add(ComboBox, 1, TableLayoutPanel1.RowCount - 0)
            TableLayoutPanel1.Controls.Add(checkBox, 2, TableLayoutPanel1.RowCount - 0)
            TableLayoutPanel1.Controls.Add(checkBox_onoff, 3, TableLayoutPanel1.RowCount - 0)

        End While
    End Sub
    Private Sub Load_create_subg()
        'สร้าง Label และ  Textbox ใน tabspage2
        Dim res As MySqlDataReader = con.mysql_query("SELECT  pos_catsubprd.id as id,pos_catsubprd.name_en as name_en," _
            & "pos_catsubprd.name_th as name_th,pos_catprd.namecat_en as namecat_en,pos_catprd.namecat_th as namecat_th " _
            & "FROM `pos_catsubprd` LEFT JOIN pos_catprd ON pos_catprd.id = pos_catsubprd.ref_id_cat  where pos_catsubprd.id_status_sales='1' ORDER BY pos_catprd.namecat_en ASC")  
        TableLayoutPanel2.Controls.Clear()
        TableLayoutPanel2.RowCount = 0
        Dim i As Integer = 1
        While res.Read()
           
            Dim Label2 As New Label
            Label2.Name = "name_sg" & res.GetString("id")
            If Login.LangG = "EN" Then
                Label2.Text = res.GetString("namecat_en") & " - " & res.GetString("name_en")
            Else
                Label2.Text = res.GetString("namecat_th") & " - " & res.GetString("name_th")
            End If
            Label2.AutoSize = True

            Dim ComboBox2 As New ComboBox
            ComboBox2.DropDownStyle = ComboBoxStyle.DropDownList
            ComboBox2.Name = "txt_sg" & i
            ComboBox2.Width = "200"
            ComboBox2.Tag = res.GetString("id")
            'ComboBox.Location = New Point(stt_x, edt_y)
            ComboBox2.Items.Clear()

            For Each sPrinters In System.Drawing.Printing.PrinterSettings.InstalledPrinters
                ComboBox2.Items.Add(sPrinters)
            Next

            Dim checkBox2 As New CheckBox
            checkBox2.Name = "checkbox_print_sg" & i
            checkBox2.Width = "200"
            checkBox2.Text = "Copy 2 Print Send Captain Order"
            checkBox2.Tag = res.GetString("id")
            checkBox2.Checked = False

            Dim checkBox_onoff2 As New CheckBox
            checkBox_onoff2.Name = "checkBox_onoff_sg" & i
            checkBox_onoff2.Width = "79"
            checkBox_onoff2.Text = "Print"
            checkBox_onoff2.Tag = res.GetString("id")
            checkBox_onoff2.Checked = False

            i += 1
            TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.AutoSize))
            TableLayoutPanel2.RowCount += 1
            TableLayoutPanel2.Controls.Add(Label2, 0, TableLayoutPanel2.RowCount - 0)
            TableLayoutPanel2.Controls.Add(ComboBox2, 1, TableLayoutPanel2.RowCount - 0)
            TableLayoutPanel2.Controls.Add(checkBox2, 2, TableLayoutPanel2.RowCount - 0)
            TableLayoutPanel2.Controls.Add(checkBox_onoff2, 3, TableLayoutPanel2.RowCount - 0)

        End While
    End Sub
    Private Sub btn_save_other_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save_other.Click
        File.WriteAllText("printer.txt", String.Empty)
        Dim FILE_NAME As String = "printer.txt"
        Dim i As Integer
        Dim aryText(3) As String
        aryText(0) = "inv=" & cmbPrinterList.Text
        aryText(1) = "trybill=" & cmbPrinterList2.Text
        aryText(2) = "rpt_front=" & cmbPrinterList3.Text
        aryText(3) = "rpt_backend=" & cmbPrinterList4.Text
        Dim objWriter As New System.IO.StreamWriter(FILE_NAME, True)
        For i = 0 To 3
            objWriter.WriteLine(aryText(i))
        Next
        objWriter.Close()
        MsgBox("บันทึกตั้งค่าเครื่องปริ้นหลักเรียบร้อย")
    End Sub

    Private Sub btn_save_group_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save_group.Click

        Dim res1 As MySqlDataReader = con.mysql_query("SELECT * FROM pos_catprd ORDER BY id ASC")
        Dim num As Integer = con.mysql_num_rows(res1)
        If num > 0 Then
            Dim FILE_NAME As String = "printer_g.txt"
            Dim i As Integer
            Dim aryText(num) As String
            For j As Integer = 1 To num
                Dim c As Integer = 0
                Dim p As Integer = 0
                Dim txt As ComboBox = CType(TableLayoutPanel1.Controls.Item("txt_" & j.ToString()), ComboBox)
                Dim checkbox1 As CheckBox = CType(TableLayoutPanel1.Controls.Item("checkbox_print" & j.ToString()), CheckBox)
                Dim checkbox_p As CheckBox = CType(TableLayoutPanel1.Controls.Item("checkBox_onoff" & j.ToString()), CheckBox)
                If checkbox1.Checked = True Then
                    c = 1
                Else
                    c = 0
                End If
                If checkbox_p.Checked = True Then
                    p = 1
                Else
                    p = 0
                End If
                aryText(j - 1) = txt.Tag & "=" & txt.Text & "=" & c & "=" & p
            Next
            File.WriteAllText("printer_g.txt", String.Empty)
            Dim objWriter As New System.IO.StreamWriter(FILE_NAME, True)
            For i = 0 To num - 1
                objWriter.WriteLine(aryText(i))
            Next
            objWriter.Close()
            objWriter.Dispose()
            MsgBox("บันทึกตั้งค่าเครื่องปริ้นของกลุ่มสินค้าเรียบร้อย")
        End If
    End Sub

    Private Sub btn_save_sg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save_sg.Click
        Dim res1 As MySqlDataReader = con.mysql_query("SELECT  pos_catsubprd.id as id,pos_catsubprd.name_en as name_en," _
            & "pos_catsubprd.name_th as name_th,pos_catprd.namecat_en as namecat_en,pos_catprd.namecat_th as namecat_th " _
            & "FROM `pos_catsubprd` LEFT JOIN pos_catprd ON pos_catprd.id = pos_catsubprd.ref_id_cat  where pos_catsubprd.id_status_sales='1' ORDER BY pos_catprd.namecat_en ASC")
        Dim num As Integer = con.mysql_num_rows(res1)
        If num > 0 Then
            Dim FILE_NAME As String = "printer_sg.txt"
            Dim i As Integer
            Dim aryText(num) As String
            For j As Integer = 1 To num
                Dim c As Integer = 0
                Dim p As Integer = 0
                Dim txt As ComboBox = CType(TableLayoutPanel2.Controls.Item("txt_sg" & j.ToString()), ComboBox)
                Dim checkbox1 As CheckBox = CType(TableLayoutPanel2.Controls.Item("checkbox_print_sg" & j.ToString()), CheckBox)
                Dim checkbox_p As CheckBox = CType(TableLayoutPanel2.Controls.Item("checkBox_onoff_sg" & j.ToString()), CheckBox)
                If checkbox1.Checked = True Then
                    c = 1
                Else
                    c = 0
                End If
                If checkbox_p.Checked = True Then
                    p = 1
                Else
                    p = 0
                End If
                aryText(j - 1) = txt.Tag & "=" & txt.Text & "=" & c & "=" & p
            Next
            File.WriteAllText("printer_sg.txt", String.Empty)
            Dim objWriter As New System.IO.StreamWriter(FILE_NAME, True)
            For i = 0 To num - 1
                objWriter.WriteLine(aryText(i))
            Next
            objWriter.Close()
            objWriter.Dispose()
            MsgBox("บันทึกตั้งค่าเครื่องปริ้นของกลุ่มย่อยสินค้าเรียบร้อย")
        End If
    End Sub
End Class