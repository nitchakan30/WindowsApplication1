Public Class stock_cut_prd
    Public amountold As Integer = 0
    Public barcode As String = ""
    Private Sub enter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles enter_1.Click
        If stock_inventory.cutSTK(barcode, CInt(TextBox_Num.Text), amountold, TextBox_Res.Text) = True Then
            MsgBox("ตัดเบิกสินค้าเรียบร้อยค่ะ")
            stock_inventory.LoadInventory_Today_New()
            Me.Close()
        Else
            stock_inventory.LoadInventory_Today_New()
            MsgBox("ตัดเบิกสินค้าไม่สำเร็จ")
            Me.Close()
        End If
    End Sub
    Private Sub stock_cut_prd_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        stock_inventory.cut_rep = False
    End Sub
End Class