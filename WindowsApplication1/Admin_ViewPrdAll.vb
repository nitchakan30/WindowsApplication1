Public Class Admin_ViewPrdAll

    Private Sub ToolStripTextBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripTextBox1.Click
        ToolStripTextBox1.Text = ""
    End Sub

    Private Sub ToolStripTextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripTextBox1.LostFocus
        ToolStripTextBox1.Text = "กรอกคำค้นหา"
    End Sub

    Private Sub ListView4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView4.SelectedIndexChanged
        GroupBox1.Show()
    End Sub

    Private Sub Admin_ViewPrdAll_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GroupBox1.Hide()
    End Sub
End Class