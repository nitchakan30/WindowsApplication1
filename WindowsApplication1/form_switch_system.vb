Public Class form_switch_system
    Private Sub form_switch_system_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btn_sale.Enabled = Login.permiss_pos_system
        btn_config.Enabled = Login.permiss_stock
        btn_setting_back.Enabled = Login.permiss_setting_other
    End Sub
    Private Sub btn_sale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sale.Click
        Login.select_page = "pos_system"
        Me.Close()
    End Sub
    Private Sub btn_config_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_config.Click
        stock_index.Show()
        Login.select_page = "stock"
        Me.Close()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Login.permiss_pos_system = False
        Login.permiss_closing_bill = False
        Login.permiss_profile_shop = False
        Login.permiss_manage_tb = False
        Login.permiss_manage_prd = False
        Login.permiss_setting_other = False
        Login.permiss_report = False
        Login.permiss_user = False
        Login.audit_cash = False
        Login.permiss_stock = False
        Login.select_page = "pos_system"
        Login.id_rop = 0
        Login.KillLogin()
        Me.Dispose()
        Me.Close()
        Login.Show()
    End Sub

    Private Sub btn_setting_back_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_setting_back.Click
        Login.select_page = "back_system"
        Me.Close()
    End Sub
End Class