Public Class stock_index
    Private Sub recript_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles recript.Click
        stock_recript.MdiParent = Me
        stock_recript.Show()
        stock_recript.WindowState = FormWindowState.Minimized
        stock_recript.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub hit_recript_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hit_recript.Click
        stock_recript_history.MdiParent = Me
        stock_recript_history.Show()
        stock_recript_history.WindowState = FormWindowState.Minimized
        stock_recript_history.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub stock_card_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stock_card.Click
        stock_inventory.MdiParent = Me
        stock_inventory.Show()
        stock_inventory.WindowState = FormWindowState.Minimized
        stock_inventory.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub logout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles logout.Click
        stock_form_previewprint.Close()
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
        Login.id_rop = 0
        Login.KillLogin()
        Me.Dispose()
        Me.Close()
        Login.Show()
    End Sub

    Private Sub stock_index_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        stock_form_previewprint.Close()
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
        Login.id_rop = 0
        Login.KillLogin()
        Me.Dispose()
        Me.Close()
        Login.Show()
    End Sub

    Private Sub stock_index_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class