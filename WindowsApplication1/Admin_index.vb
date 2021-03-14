Imports MySql.Data.MySqlClient
Public Class Admin_index
    Dim con As New Mysql
    Public indexOnOff As String 'ตั้งไว้เอาไปเช้คอ้างอิงตัวแปรในการเปิดไฟล์ Admin_ConfigTBCus_OnOff.vb
    Dim date1 As Date = Date.Now
    Public switch_page As Boolean = False
    Private Sub Admin_index_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Login.Close()
        Login.KillLogin()
        Login.KillP()
    End Sub
    Private Sub Admin_index_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        db_name.Text = "DB.Name : " & con.database
        user_show.Text = "Username : " & Login.username & " (Login :" & date1.ToString("hh:mm") & ")"
        company_name.Text = "Coompany Name : " & index.loadCompany()
        profile_shop.Enabled = Login.permiss_profile_shop
        cf_user1.Enabled = Login.permiss_user
        cf_tb.Enabled = Login.permiss_manage_tb
        cf_product.Enabled = Login.permiss_manage_prd
        cf_setting.Enabled = Login.permiss_setting_other
    End Sub
    Private Sub ออกจากระบบToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ออกจากระบบToolStripMenuItem.Click
        Dim result As Integer = MessageBox.Show("Exit Program ?", "Exit Program", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If result = DialogResult.OK Then
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
            Login.id_rop = 0
            Login.KillLogin()
            Me.Dispose()
            Me.Close()
            Login.Show()
        End If
    End Sub

    Private Sub ออกจากระบบToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Login.Close()
        Me.Close()
    End Sub

    Private Sub เพมหมวดหมToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        openCloseMenu(Admin_addCatPrd)
    End Sub

    Private Sub เพมสนคาToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        openCloseMenu(Admin_addPrdList)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        openCloseMenu(Admin_addCatPrd)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        openCloseMenu(Admin_addPrdList)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        openCloseMenu(Admin_ViewPrdAll)
    End Sub

    Private Sub เปลยนรหสผานToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles เปลยนรหสผานToolStripMenuItem.Click
        Admin_forgetPwd.ShowDialog()
    End Sub
    Public Sub openCloseMenu(ByVal page)
        page.MdiParent = Me
        page.Show()
        page.WindowState = FormWindowState.Minimized
        page.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub จดโตะแบบกำจดจำนวนToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Admin_ConfigTB.MdiParent = Me
        Admin_ConfigTB.Show()
        Admin_ConfigTB.WindowState = FormWindowState.Minimized
        Admin_ConfigTB.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub จดวางโตะอาหารToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Admin_ConfigTBCUS.MdiParent = Me
        Admin_ConfigTBCUS.Show()
        Admin_ConfigTBCUS.WindowState = FormWindowState.Minimized
        Admin_ConfigTBCUS.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ตงคาเปดปดระบบใชโตะToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Admin_ConfigTBONOFF.MdiParent = Me
        Admin_ConfigTBONOFF.Show()
        Admin_ConfigTBONOFF.WindowState = FormWindowState.Minimized
        Admin_ConfigTBONOFF.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ตงคาเครองปรนToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Admin_ConfigPrint.MdiParent = Me
        Admin_ConfigPrint.Show()
        Admin_ConfigPrint.WindowState = FormWindowState.Minimized
        Admin_ConfigPrint.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub หมวดหมสนคาToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Admin_addCatPrd.MdiParent = Me
        Admin_addCatPrd.Show()
        Admin_addCatPrd.WindowState = FormWindowState.Minimized
        Admin_addCatPrd.WindowState = FormWindowState.Maximized
    End Sub


    Private Sub cf_tb_number_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cf_tb_number.Click
        Admin_ConfigTB.MdiParent = Me
        Admin_ConfigTB.Show()
        Admin_ConfigTB.WindowState = FormWindowState.Minimized
        Admin_ConfigTB.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub cf_onoff_tb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cf_onoff_tb.Click
        Admin_ConfigTBONOFF.ShowDialog()
    End Sub

    Private Sub profile_shop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles profile_shop.Click
        Admin_profile_shop.MdiParent = Me 
        Admin_profile_shop.Show()
        Admin_profile_shop.WindowState = FormWindowState.Minimized
        Admin_profile_shop.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub cf_cat_prd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cf_cat_prd.Click
        'Admin_addCatPrd.MdiParent = Me
        'Admin_addCatPrd.Show()
        'Admin_addCatPrd.WindowState = FormWindowState.Minimized
        'Admin_addCatPrd.WindowState = FormWindowState.Maximized
        Admin_addCatPrd.ShowDialog()
    End Sub

    Private Sub cf_prd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cf_prd.Click
        Admin_addPrdList.MdiParent = Me
        Admin_addPrdList.Show()
        Admin_addPrdList.WindowState = FormWindowState.Minimized
        Admin_addPrdList.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub cf_tb_design_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cf_tb_design.Click
        Admin_ConfigTBCUS.MdiParent = Me
        Admin_ConfigTBCUS.Show()
        Admin_ConfigTBCUS.WindowState = FormWindowState.Minimized
        Admin_ConfigTBCUS.WindowState = FormWindowState.Maximized
    End Sub


    Private Sub cf_user1_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cf_user1.Click
        Admin_addUser.MdiParent = Me
        Admin_addUser.Show()
        Admin_addUser.WindowState = FormWindowState.Minimized
        Admin_addUser.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub เพมพนทToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Admin_ConfigTBCus_AddLocation.ShowDialog()
    End Sub

    Private Sub Onoff_system_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        indexOnOff = "system"
        Admin_ConfigTBCus_OnOff.ShowDialog()
    End Sub

    Private Sub Onoff_design_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        indexOnOff = "design"
        Admin_ConfigTBCus_OnOff.ShowDialog()
    End Sub

    Private Sub cf_setting_print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cf_setting_print.Click
        Admin_ConfigPrint.ShowDialog()
    End Sub

    Private Sub cf_addunit_prd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cf_addunit_prd.Click
        Admin_ConfigUnitPrd.ShowDialog()
    End Sub

    Private Sub cf_setting_other_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cf_setting_other.Click
        Admin_ConfigSettingFD.ShowDialog()
    End Sub

    Private Sub front_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles front.Click
        form_switch_system.Show()
        Me.Close()
    End Sub

    Private Sub เพมโซนรานอาหารToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles เพมโซนรานอาหารToolStripMenuItem.Click
        Admin_ConfigTBCus_AddLocation.ShowDialog()
    End Sub

    Private Sub set_payment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles set_payment.Click
        Admin_Configpayment.ShowDialog()
    End Sub

    Private Sub setting_color_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles setting_color.Click
        Admin_ConfigTBColor.ShowDialog()
    End Sub

    Private Sub btn_set_audit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_set_audit.Click
        Admin_ConfigpaymentSet.ShowDialog()
    End Sub

    Private Sub cf_report_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub config_runingnum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles config_runingnum.Click
        Admin.TextBox1.Text = ""
        Admin.Str = "runing"
        Admin.ShowDialog()
    End Sub
    Private Sub cf_report1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cf_report1.Click
        Admin_Report.MdiParent = Me
        Admin_Report.Show()
        Admin_Report.WindowState = FormWindowState.Minimized
        Admin_Report.WindowState = FormWindowState.Maximized
    End Sub
    
    Private Sub on_off_formcomment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles on_off_formcomment.Click
        Admin_ConfigFormcomment.ShowDialog()
    End Sub
    Private Sub btn_bill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_bill.Click
        Admin_EditBill.MdiParent = Me
        Admin_EditBill.Show()
        Admin_EditBill.WindowState = FormWindowState.Minimized
        Admin_EditBill.WindowState = FormWindowState.Maximized
    End Sub
    Private Sub cf_tb_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cf_tb.ButtonClick
        cf_tb.ShowDropDown()
    End Sub

    Private Sub cf_product_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cf_product.ButtonClick
        cf_product.ShowDropDown()
    End Sub

    Private Sub cf_setting_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cf_setting.ButtonClick
        cf_setting.ShowDropDown()
    End Sub

    Private Sub หนาแรกToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles หนาแรกToolStripMenuItem.Click

    End Sub
    Private Sub ConfigCloseDayToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigCloseDayToolStripMenuItem.Click
        Admin.TextBox1.Text = ""
        Admin.Str = "set_print_close"
        Admin.ShowDialog()
    End Sub

    Private Sub แกไขชอสนคาในInventoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles แกไขชอสนคาในInventoryToolStripMenuItem.Click
        Admin.TextBox1.Text = ""
        Admin.Str = "inventory_edit"
        Admin.ShowDialog()
    End Sub

    Private Sub ConfigSystemOtherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigSystemOtherToolStripMenuItem.Click
        Admin.TextBox1.Text = ""
        Admin.Str = "config_system"
        Admin.ShowDialog()
    End Sub

    Private Sub ExportExcelToServerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportExcelToServerToolStripMenuItem.Click
        Export.ShowDialog()
    End Sub

    Private Sub ConfigCalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigCalToolStripMenuItem.Click
        Admin.TextBox1.Text = ""
        Admin.Str = "calculator_payment"
        Admin.ShowDialog()
    End Sub
End Class