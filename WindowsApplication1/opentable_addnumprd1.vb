Public Class opentable_addnumprd1
    Public CHK_Close As Boolean = True
    Dim myProcess As Process
    Private Sub opentable_addnumprd1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CHK_Close = True
    End Sub
    Private Sub btn_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_close.Click
        CHK_Close = True
        ' myProcess.CloseMainWindow()
        Me.Close()
    End Sub
    Private Sub btn_enter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_enter.Click
        CHK_Close = False
        'myProcess.CloseMainWindow()
        Me.Close()
    End Sub
    Private Sub txt_numprd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_numprd.Click
        keyborad_number.text1 = "txt_numprd_addCart"
        keyborad_number.ShowDialog()
    End Sub
    Private Sub txt_numprd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_numprd.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            CHK_Close = False
            Me.Close()
        End If
    End Sub
    Private Sub txt_recomment_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_recomment.Click
        '  myProcess = System.Diagnostics.Process.Start("osk.exe")
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox_NamePrd.TextChanged

    End Sub
End Class