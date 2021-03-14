Imports MySql.Data.MySqlClient
Public Class payment_discount_gohome
    Dim con As New Mysql
    Public typedis As String = "all"
    Private Sub add_dis_only_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles add_dis_only.Click
        If typedis = "all" Then
            Dim t As String = ""
            If radio_dis_only1.Checked = True Then
                t = radio_dis_only1.Text
            End If
            If radio_dis_only2.Checked = True Then
                t = radio_dis_only2.Text
            End If
            payment_gohome.txt_dis_all.Text = txt_dis_only.Text
            payment_gohome.Label_ShowAllDisType.Text = "( " & t & " )"
            payment_gohome.Label_ShowAllDisType.Tag = t
            payment_gohome.cal_list_price()
        Else
            Dim ds1 As Double = 0.0
            If payment_gohome.ListView1.Items.Count > 0 Then
                If payment_gohome.ListView1.SelectedIndices.Count > 0 Then
                    If radio_dis_only1.Checked = True Then
                        If payment_gohome.ListView1.Items(payment_gohome.ListView1.SelectedIndices(0)).SubItems(0).Text() <> "void" Then
                            payment_gohome.ListView1.SelectedItems.Item(0).SubItems(12).Text = "-" & FormatNumber(CDbl(txt_dis_only.Text), 2)
                            payment_gohome.ListView1.SelectedItems.Item(0).SubItems(13).Text = FormatNumber(CDbl(txt_dis_only.Text), 2)
                            payment_gohome.ListView1.SelectedItems.Item(0).SubItems(14).Text = "บาท"
                            payment_gohome.ListView1.SelectedItems.Item(0).SubItems(15).Text = FormatNumber(CDbl(payment_gohome.ListView1.Items(payment_gohome.ListView1.SelectedIndices(0)).SubItems(11).Text()) - CDbl(txt_dis_only.Text), 2)

                        End If
                    End If
                    If radio_dis_only2.Checked = True Then
                        If payment_gohome.ListView1.Items(payment_gohome.ListView1.SelectedIndices(0)).SubItems(0).Text() <> "void" Then
                            Dim disV As Double = (CDbl(payment_gohome.ListView1.Items(payment_gohome.ListView1.SelectedIndices(0)).SubItems(11).Text()) * CDbl(txt_dis_only.Text) / 100)
                            Dim disS As Double = CDbl(payment_gohome.ListView1.Items(payment_gohome.ListView1.SelectedIndices(0)).SubItems(11).Text()) - CDbl(disV)
                            payment_gohome.ListView1.Items(payment_gohome.ListView1.SelectedIndices(0)).SubItems(12).Text = "-" & FormatNumber(CDbl(txt_dis_only.Text), 2)
                            payment_gohome.ListView1.Items(payment_gohome.ListView1.SelectedIndices(0)).SubItems(13).Text = disV
                            payment_gohome.ListView1.Items(payment_gohome.ListView1.SelectedIndices(0)).SubItems(14).Text = "%"
                            payment_gohome.ListView1.Items(payment_gohome.ListView1.SelectedIndices(0)).SubItems(15).Text = FormatNumber(disS, 2)
                        End If
                    End If
                End If
            End If
            payment_gohome.cal_list_price()
        End If
        Me.Close()
    End Sub

    Private Sub minus_dis_all_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    Private Sub minus_dis_only_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles minus_dis_only.Click
        If typedis = "all" Then
            payment_gohome.txt_sum_discount.Text = "0.0"
            payment_gohome.txt_dis_all.Text = "0.0"
            payment_gohome.cal_list_price()
        End If
        Me.Close()
    End Sub

    Private Sub txt_dis_only_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_dis_only.Click
        keyborad_number.text1 = "discount_only_gh"
        keyborad_number.ShowDialog()
    End Sub

End Class