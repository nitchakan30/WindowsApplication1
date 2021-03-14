Public Class process_bar
   
    Private Sub process_bar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ProgressBar1.Value = 100
        'add the progress bar to the form
        ' Me.Controls.Add(ProgressBar1)
    End Sub
End Class