Public Class voidReson
    Dim myProcess As Process
    Dim p() As Process
    Public EnterT As Boolean = False
    Public PageProcess As String = ""
    Private Sub voidReson_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EnterT = False
        TextBox1.Text = ""

    End Sub
    Private Sub TextBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.Click
        ' myProcess = System.Diagnostics.Process.Start("osk.exe")
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'p = Process.GetProcessesByName("osk.exe")
        'If p.Count > 0 Then
        '    myProcess.CloseMainWindow()
        'End If
        EnterT = True
        home1_menu.void_remark = TextBox1.Text
        gohome_list.void_remark = TextBox1.Text
        Me.Close()
    End Sub
End Class