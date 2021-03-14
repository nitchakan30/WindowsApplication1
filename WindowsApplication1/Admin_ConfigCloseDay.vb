Imports MySql.Data.MySqlClient
Imports System
Imports System.IO
Imports System.Text
Imports System.Collections.Generic
Imports System.Management
Public Class Admin_ConfigCloseDay
    Dim con As New Mysql

    Private Sub Admin_ConfigCloseDay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Load_dt()
    End Sub
    Private Sub Load_dt()
        'โหลดข้อมูล Tabspage1
        Dim objReader As New System.IO.StreamReader("setting_closeday.bat", Encoding.UTF8)
        Dim TextLine() As String
        Do While objReader.Peek() <> -1
            TextLine = objReader.ReadLine().ToString.Trim.Split("=")
            If TextLine(0).ToString.Trim = "inputcash_balance" Then
                If TextLine(1).ToString.Trim = 0 Then
                    CheckBox_Check_Balance.Checked = False
                Else
                    CheckBox_Check_Balance.Checked = True
                End If
            ElseIf TextLine(0).ToString.Trim = "printcloseday" Then
                If TextLine(1).ToString.Trim = 0 Then
                    CheckBox_Print_N1.Checked = False
                Else
                    CheckBox_Print_N1.Checked = True
                End If
            ElseIf TextLine(0).ToString.Trim = "printclosedaysummary" Then
                If TextLine(1).ToString.Trim = 0 Then
                    CheckBox_Print_N0.Checked = False
                Else
                    CheckBox_Print_N0.Checked = True
                End If
            ElseIf TextLine(0).ToString.Trim = "printcloserop" Then
                If TextLine(1).ToString.Trim = 0 Then
                    CheckBox_Print_N0_1.Checked = False
                Else
                    CheckBox_Print_N0_1.Checked = True
                End If
            ElseIf TextLine(0).ToString.Trim = "printcloseropsummary" Then
                If TextLine(1).ToString.Trim = 0 Then
                    CheckBox_Print_N1_1.Checked = False
                Else
                    CheckBox_Print_N1_1.Checked = True
                End If
            ElseIf TextLine(0).ToString.Trim = "printinventory" Then
                If TextLine(1).ToString.Trim = 0 Then
                    CheckBox_Print_inventory.Checked = False
                Else
                    CheckBox_Print_inventory.Checked = True
                End If
            ElseIf TextLine(0).ToString.Trim = "alertsendcaptain" Then
                If TextLine(1).ToString.Trim = 0 Then
                    onoff_alertsendcaptain.Checked = False
                Else
                    onoff_alertsendcaptain.Checked = True
                End If
            ElseIf TextLine(0).ToString.Trim = "dialogLangCaptain" Then
                If TextLine(1).ToString.Trim = 0 Then
                    lang_sendcaptain.Checked = False
                Else
                    lang_sendcaptain.Checked = True
                End If
            ElseIf TextLine(0).ToString.Trim = "dialogLangTrybill" Then
                If TextLine(1).ToString.Trim = 0 Then
                    lang_trybill.Checked = False
                Else
                    lang_trybill.Checked = True
                End If
            ElseIf TextLine(0).ToString.Trim = "dialogLangPayment" Then
                If TextLine(1).ToString.Trim = 0 Then
                    lang_payment.Checked = False
                Else
                    lang_payment.Checked = True
                End If
            End If
        Loop
        objReader.Dispose()
        objReader.Close()
    End Sub
    Private Sub save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles save.Click
        Dim inputcash_balance As Integer
        Dim printcloseday As Integer
        Dim printclosedaysummary As Integer
        Dim printcloserop As Integer
        Dim printcloseropsummary As Integer
        Dim printinventory As Integer
        Dim alertsend_c As Integer
        Dim vallang_sendcaptain As Integer
        Dim vallang_trybill As Integer
        Dim vallang_payment As Integer
        If CheckBox_Print_N0.Checked = True Then
            printclosedaysummary = 1
        Else
            printclosedaysummary = 0
        End If
        If CheckBox_Print_N1.Checked = True Then
            printcloseday = 1
        Else
            printcloseday = 0
        End If
        If CheckBox_Check_Balance.Checked = True Then
            inputcash_balance = 1
        Else
            inputcash_balance = 0
        End If
        If CheckBox_Print_N0_1.Checked = True Then
            printcloserop = 1
        Else
            printcloserop = 0
        End If

        If CheckBox_Print_N1_1.Checked = True Then
            printcloseropsummary = 1
        Else
            printcloseropsummary = 0
        End If

        If CheckBox_Print_inventory.Checked = True Then
            printinventory = 1
        Else
            printinventory = 0
        End If
        If onoff_alertsendcaptain.Checked = True Then
            alertsend_c = 1
        Else
            alertsend_c = 0
        End If
        If lang_sendcaptain.Checked = True Then
            vallang_sendcaptain = 1
        Else
            vallang_sendcaptain = 0
        End If
        If lang_trybill.Checked = True Then
            vallang_trybill = 1
        Else
            vallang_trybill = 0
        End If
        If lang_payment.Checked = True Then
            vallang_payment = 1
        Else
            vallang_payment = 0
        End If
        File.WriteAllText("setting_closeday.bat", String.Empty)
        Dim FILE_NAME As String = "setting_closeday.bat"
        Dim i As Integer
        Dim aryText(9) As String
        aryText(0) = "inputcash_balance=" & inputcash_balance
        aryText(1) = "printcloseday=" & printcloseday
        aryText(2) = "printclosedaysummary=" & printclosedaysummary
        aryText(3) = "printcloserop=" & printcloserop
        aryText(4) = "printcloseropsummary=" & printcloseropsummary
        aryText(5) = "printinventory=" & printinventory
        aryText(6) = "alertsendcaptain=" & alertsend_c
        aryText(7) = "dialogLangCaptain=" & vallang_sendcaptain
        aryText(8) = "dialogLangTrybill=" & vallang_trybill
        aryText(9) = "dialogLangPayment=" & vallang_payment
        Dim objWriter As New System.IO.StreamWriter(FILE_NAME, True)
        For i = 0 To 9
            objWriter.WriteLine(aryText(i))
        Next
        objWriter.Close()
        objWriter.Dispose()
        MsgBox("บันทึกเรียบร้อย", MsgBoxStyle.Information)
        Me.Close()
    End Sub

End Class