Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows.Forms
Imports System.ComponentModel
Imports System.Threading
Imports Microsoft.Win32
Public Class showpay_typeprint
    Private _worker As BackgroundWorker
    Public invoice_number As String
    Public printer_payment As String = ""
    Public user As String = ""
    Dim con As New Mysql
    Dim print As New printClass
    Public invoice_number_print As String = ""
    Public recript_m_print As String = ""
    Public ton_m_print As String = ""
    Friend page As String = "showpay_again"
    Public switch_lang As String = Login.LangG
    Private Sub showpay_typeprint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub
    Private Sub btn_vat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_vat.Click


        invoice_number_print = invoice_number
        recript_m_print = "0"
        ton_m_print = "0"
        user = Login.username
        printer_payment = Login.printer_payment
        If page = "showpay_again" Then
            switch_langprint.page = "showpay_typeprint"
            switch_langprint.ShowDialog()
            switch_lang = switch_lang
            BackgroundWorker1.RunWorkerAsync()
        Else
            switch_langprint.page = "showpay_typeprint"
            switch_langprint.ShowDialog()
            switch_lang = switch_lang
            BackgroundWorker3.RunWorkerAsync()
        End If
    End Sub
    Private Sub btn_novat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_novat.Click
        invoice_number_print = invoice_number
        recript_m_print = "0"
        ton_m_print = "0"
        user = Login.username
        printer_payment = Login.printer_payment
        If page = "showpay_again" Then
            switch_langprint.page = "showpay_typeprint"
            switch_langprint.ShowDialog()
            switch_lang = switch_lang
            BackgroundWorker2.RunWorkerAsync()
        Else
            switch_langprint.page = "showpay_typeprint"
            switch_langprint.ShowDialog()
            switch_lang = switch_lang
            BackgroundWorker4.RunWorkerAsync()
        End If
    End Sub
    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        print.PrintPaymentAgain(invoice_number, recript_m_print, ton_m_print, user, "payment", printer_payment, switch_lang)
    End Sub
    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Me.Close()
    End Sub

    Private Sub BackgroundWorker2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        print.PrintPaymentAgain(invoice_number_print, recript_m_print, ton_m_print, user, "payment_noShow_vat", printer_payment, switch_lang)
    End Sub
    Private Sub BackgroundWorker2_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted
        Me.Close()
    End Sub

    Private Sub BackgroundWorker3_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker3.DoWork

        print.PrintPayment(invoice_number_print, recript_m_print, ton_m_print, user, "payment", printer_payment, switch_lang)
    End Sub
    Private Sub BackgroundWorker3_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker3.RunWorkerCompleted
        Me.Close()
    End Sub

    Private Sub BackgroundWorker4_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker4.DoWork
        print.PrintPayment(invoice_number_print, recript_m_print, ton_m_print, user, "payment_noShow_vat", printer_payment, switch_lang)
    End Sub
    Private Sub BackgroundWorker4_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker4.RunWorkerCompleted
        Me.Close()
    End Sub
End Class