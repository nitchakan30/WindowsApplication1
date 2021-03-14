Public Class form_voidbill_reson

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text <> "" Then
            form_voidbill.reson_void = TextBox1.Text
            Me.Close()
        Else
            MsgBox("กรุณากรอกเหตุผลการยกเลิกบิลด้วยค่ะ")
            TextBox1.Focus()
        End If

    End Sub

End Class