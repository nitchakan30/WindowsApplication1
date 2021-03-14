Public Class opentable_voidorder1
    Public Status As String
    Public idPrd As String
    Public idPrdcon As String
    Public namePrd As String
    Public amt_new As Integer = 0
    Public size1 As String
    Public price As Double
    Public recomment As String
    Dim chkamt As Integer
    Private Sub opentable_voidorder1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        chkamt = CHK_NUMCAN()
        txt_number.Text = "0"
    End Sub
    Private Sub btn_enter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_enter.Click
        If chkamt = amt_new Then
            MessageBox.Show("จำนวนที่ใส่มาไม่ถูกต้อง กรุณาทำรายการให้ถูกต้องค่ะ", "Alert Message")
            Me.Close()
        Else
            Dim newp As Double = price / amt_new
            Dim countN = opentable.ListView_ListOrder.Items.Count
            ' MsgBox(txt_number.Text & " == " & newp)
            If amt_new = CInt(txt_number.Text) Then
                amt_new = CInt(txt_number.Text)
            Else
                If CInt(txt_number.Text) < amt_new Then
                    amt_new = CInt(txt_number.Text)
                Else
                    amt_new = amt_new
                End If
            End If
            Dim itmx As New ListViewItem
            itmx = opentable.ListView_ListOrder.Items.Add("cancel", countN - 1)
            itmx.SubItems.Add(idPrd)
            itmx.SubItems.Add(idPrdcon)
            itmx.SubItems.Add(namePrd)
            itmx.SubItems.Add(size1)
            itmx.SubItems.Add(amt_new)
            itmx.SubItems.Add(newp * amt_new)
            itmx.SubItems.Add(recomment)
            opentable.ListView_ListOrder.Items(countN).ForeColor = Color.Red
            opentable.calsum() 'คำนวฯราคาใหม่ แล้วยัดใส่หน้า opentable แสดงข้อมูล
            Me.Close()
        End If
    End Sub

    Public Function CHK_NUMCAN()
        Dim SumAmtNew As Integer = 0
        For u As Integer = 0 To opentable.ListView_ListOrder.Items.Count - 1
            If opentable.ListView_ListOrder.Items(u).SubItems(0).Text = "cancel" Then
                If opentable.ListView_ListOrder.Items(u).SubItems(1).Text = idPrd And opentable.ListView_ListOrder.Items(u).SubItems(2).Text = idPrdcon Then
                    SumAmtNew += opentable.ListView_ListOrder.Items(u).SubItems(5).Text
                End If
            End If
        Next
        Return SumAmtNew
    End Function
    Private Sub txt_recomment_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_recomment.Click
        'System.Diagnostics.Process.Start("osk.exe")
    End Sub

    Private Sub txt_number_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_number.Click
        keyborad_number.text1 = "voidorder"
        keyborad_number.ShowDialog()
    End Sub
    Private Sub opentable_voidorder1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Status = ""
        idPrd = ""
        idPrdcon = ""
        namePrd = ""
        size1 = ""
        amt_new = 0
        price = 0
        recomment = ""
    End Sub

  
End Class