Imports MySql.Data.MySqlClient
Public Class Admin
    Public Str As String = ""
    Dim con As New Mysql
    Private Sub Admin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = ""
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "admin1987" Or TextBox1.Text = "admin1988" Or TextBox1.Text = "nukaiang" Or TextBox1.Text = "nitchakan30" Then
            If Str = "runing" Then
                Admin_ConfigNumRuning.ShowDialog()
                Me.Close()
            ElseIf Str = "set_print_close" Then
                Admin_ConfigCloseDay.ShowDialog()
                Me.Close()
            ElseIf Str = "inventory_edit" Then
                Admin_EditInventory.MdiParent = Admin_index
                Admin_EditInventory.Show()
                Admin_EditInventory.WindowState = FormWindowState.Minimized
                Admin_EditInventory.WindowState = FormWindowState.Maximized
                Me.Close()
            ElseIf Str = "config_system" Then
                Admin_configSystem.ShowDialog()
                Me.Close()
            ElseIf Str = "cut_recript" Then
                stock_inventory.cut_rep = True
                Me.Close()
            ElseIf Str = "calculator_payment" Then
                Admin_configCalPay.ShowDialog()
                Me.Close()
            End If
        Else
            stock_inventory.cut_rep = False
        End If
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            If TextBox1.Text = "admin1987" Or TextBox1.Text = "admin1988" Or TextBox1.Text = "nukaiang" Or TextBox1.Text = "nitchakan30" Then
                If Str = "runing" Then
                    Admin_ConfigNumRuning.ShowDialog()
                    Me.Close()
                ElseIf Str = "set_print_close" Then
                    Admin_ConfigCloseDay.ShowDialog()
                    Me.Close()
                ElseIf Str = "inventory_edit" Then
                    Admin_EditInventory.MdiParent = Admin_index
                    Admin_EditInventory.Show()
                    Admin_EditInventory.WindowState = FormWindowState.Minimized
                    Admin_EditInventory.WindowState = FormWindowState.Maximized
                    Me.Close()
                ElseIf Str = "config_system" Then
                    Admin_configSystem.ShowDialog()
                    Me.Close()
                ElseIf Str = "cut_recript" Then
                    stock_inventory.cut_rep = True
                    Me.Close()
                ElseIf Str = "calculator_payment" Then
                    Admin_configCalPay.ShowDialog()
                    Me.Close()
                End If
            Else
                stock_inventory.cut_rep = False
            End If
        End If
    End Sub


End Class