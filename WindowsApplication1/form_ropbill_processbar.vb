Imports System.Reflection
Imports System.Threading
Imports System.Text
Imports MySql.Data.MySqlClient
Public Class form_ropbill_processbar
    Friend id1 As String = ""
    Friend name1 As String = ""
    Friend Money_CloseRop As String = ""
    Private MonitorThread As Thread
    Private WorkerThread As Thread
    Private W As worker_closebill
    Private Delegate Sub UpdateUIDelegate(ByVal run As Integer, ByVal msg As String)
    Private Delegate Sub WorkerDoneDelegate()
    Dim con As New Mysql
    Private MonitorThreadZ As Thread
    Private WorkerThreadZ As Thread
    Private Z As worker_closeDay
    Private Delegate Sub UpdateUIZDelegate(ByVal run As Integer, ByVal msg As String)
    Private Delegate Sub WorkerDoneZDelegate()
    Dim print As New printClass

    Private Sub Monitor()
        Try
            Do While WorkerThread.ThreadState <> ThreadState.Stopped    'Loop until the Worker thread (and thus the Worker object's Start() method) is done
                'Me.ProgressBar.Maximum = W.MaxRuns
                UpdateUI(W.run, W.msg)                                      'Update the progress bar with the current value
                Thread.Sleep(10)                                       'Sleep the monitor thread otherwise we'll be wasting CPU cycles updating the progress bar a million times a second
            Loop
            WorkerDone()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try                                    'If we're here, the worker object is done, call a method to do some cleanup
    End Sub

    Private Sub UpdateUI(ByVal run As Integer, ByVal msg As String)
        If Me.InvokeRequired Then                                                           'See if we need to cross threads
            Me.Invoke(New UpdateUIDelegate(AddressOf UpdateUI), New Object() {run, msg})    'If so, have the UI thread call this method for us
        Else
            Me.ProgressBar1.Value = run                                                'Otherwise just update the progress bar
            Label1.Text = "Status : " & msg
        End If
    End Sub

    Private Sub WorkerDone()
        If Me.InvokeRequired Then                                                           'See if we need to cross threads
            Me.Invoke(New WorkerDoneDelegate(AddressOf WorkerDone))                         'If so, have the UI thread call this method for us
        Else
            Me.ProgressBar1.Value = 0
            Label1.Text = "Success."
            Dim result2 As DialogResult = MessageBox.Show("คุณต้องการที่จะปิดวัน " & Login.DateData.ToString("dd/MM/yyyy") & " เลยหรือไม?", _
           "ยืนยันการปิดรอบวัน", _
           MessageBoxButtons.YesNo, _
           MessageBoxIcon.Question)
            If result2 = DialogResult.Yes Then
                Dim check_close_sale As Integer = con.mysql_num_rows(con.mysql_query("SELECT * FROM pos_order_list where status_pay='no' and status_sd_captain<>'void' and DAY(create_date)='" & Login.DateData.ToString("dd") & "' and MONTH(create_date)='" & Login.DateData.ToString("MM") & "' and YEAR(create_date)='" & Login.DateData.ToString("yyyy") & "';"))
                If check_close_sale > 0 Then
                    MessageBox.Show("ไม่สามารถปิดรอบได้ มียอดยังค้างชำระ กรุณาตรวจสอบด้วยค่ะ.!", "Message Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    con.mysql_query("UPDATE pos_audit SET type_aud='0',action_by_aud='" & form_ropbill_audit_close.txt_user.Text & "' WHERE id_aud='" & id1 & "'") 'SET UPDATE ROPBIL
                    Me.Close()
                Else
                    startCloseDay()
                End If
            Else
                OpenLoginNew()
                Me.Close()
        End If
        End If
    End Sub

    Private Sub form_ropbill_processbar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        W = New worker_closebill()
        W.id = id1
        W.name = name1
        W.Money_CloseRop = Money_CloseRop
        W.setdate = Login.DateData
        W.user = Login.username
        W.getMacAddress = Login.getMacAddress
        Me.ProgressBar1.Value = 0
        Me.ProgressBar1.Maximum = 3
        WorkerThread = New Thread(AddressOf W.Start)    'Create our Worker thread and tell it that when we start it it should call our Worker's Start() method
        MonitorThread = New Thread(AddressOf Monitor)
        WorkerThread.Start()
        MonitorThread.Start()

    End Sub

    Public Sub OpenLoginNew()
        Login.permiss_pos_system = False
        Login.permiss_closing_bill = False
        Login.permiss_profile_shop = False
        Login.permiss_manage_tb = False
        Login.permiss_manage_prd = False
        Login.permiss_setting_other = False
        Login.permiss_report = False
        Login.permiss_user = False
        Login.permiss_stock = False
        Login.audit_cash = False
        Login.SelectDate = False
        Login.id_rop = 0
        index.Dispose()
        Me.Close()
        Login.Show()
        Login.KillP()
        Login.KillLogin()
    End Sub

    Private Sub startCloseDay()
        Z = New worker_closeDay()
        Z.id = id1
        Z.name = name1
        Z.setdate = Login.DateData
        Z.user = Login.username
        Me.ProgressBar1.Value = 0
        Me.ProgressBar1.Maximum = 6
        WorkerThreadZ = New Thread(AddressOf Z.Start)    'Create our Worker thread and tell it that when we start it it should call our Worker's Start() method
        MonitorThreadZ = New Thread(AddressOf MonitorZ)
        WorkerThreadZ.Start()
        MonitorThreadZ.Start()
    End Sub

    Private Sub MonitorZ()
        Try
            Do While WorkerThreadZ.ThreadState <> ThreadState.Stopped    'Loop until the Worker thread (and thus the Worker object's Start() method) is done
                'Me.ProgressBar.Maximum = W.MaxRuns
                UpdateUIZ(Z.run, Z.msg)                                      'Update the progress bar with the current value
                Thread.Sleep(100)                                       'Sleep the monitor thread otherwise we'll be wasting CPU cycles updating the progress bar a million times a second
            Loop
            WorkerDoneZ()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try                                    'If we're here, the worker object is done, call a method to do some cleanup
    End Sub

    Private Sub UpdateUIZ(ByVal run As Integer, ByVal msg As String)
        If Me.InvokeRequired Then                                                           'See if we need to cross threads
            Me.Invoke(New UpdateUIDelegate(AddressOf UpdateUIZ), New Object() {run, msg})    'If so, have the UI thread call this method for us
        Else
            Me.ProgressBar1.Value = run                                                'Otherwise just update the progress bar
            Label1.Text = "Status : " & msg
        End If
    End Sub

    Private Sub WorkerDoneZ()
        If Me.InvokeRequired Then                                                           'See if we need to cross threads
            Me.Invoke(New WorkerDoneDelegate(AddressOf WorkerDoneZ))                         'If so, have the UI thread call this method for us
        Else
            Label1.Text = "Success."
            OpenLoginNew()
            Me.Close()
        End If
    End Sub
End Class