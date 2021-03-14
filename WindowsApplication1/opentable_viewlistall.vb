Public Class opentable_viewlistall
    Public Pr_Page As String = ""
    Private Sub opentable_viewlistall_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadShowData() 'Load Show Data onListView
    End Sub
    Public Sub loadShowData()
        ListOrder_View.Items.Clear()
        If Pr_Page = "opentable" Then
            If opentable.ListView_ListOrder.Items.Count > 0 Then
                Dim itmx As New ListViewItem
                For j As Integer = 0 To opentable.ListView_ListOrder.Items.Count - 1
                    itmx = ListOrder_View.Items.Add(opentable.ListView_ListOrder.Items(j).SubItems(1).Text(), j)
                    itmx.SubItems.Add(opentable.ListView_ListOrder.Items(j).SubItems(2).Text())
                    itmx.SubItems.Add(opentable.ListView_ListOrder.Items(j).SubItems(3).Text())
                    itmx.SubItems.Add(opentable.ListView_ListOrder.Items(j).SubItems(4).Text())
                    itmx.SubItems.Add(opentable.ListView_ListOrder.Items(j).SubItems(5).Text())
                    itmx.SubItems.Add(opentable.ListView_ListOrder.Items(j).SubItems(6).Text())
                    itmx.SubItems.Add(opentable.ListView_ListOrder.Items(j).SubItems(7).Text())
                    itmx.SubItems.Add(opentable.ListView_ListOrder.Items(j).SubItems(8).Text())

                Next
            End If
        ElseIf Pr_Page = "home1" Then
            If home1.ListView_food.Items.Count > 0 Then
                Dim itmx1 As New ListViewItem
                For i As Integer = 0 To home1.ListView_food.Items.Count - 1
                    itmx1 = ListOrder_View.Items.Add("", i)
                    itmx1.SubItems.Add(home1.ListView_food.Items(i).SubItems(1).Text())
                    itmx1.SubItems.Add(home1.ListView_food.Items(i).SubItems(2).Text())
                    itmx1.SubItems.Add(home1.ListView_food.Items(i).SubItems(3).Text())
                    itmx1.SubItems.Add(home1.ListView_food.Items(i).SubItems(4).Text())
                    itmx1.SubItems.Add(home1.ListView_food.Items(i).SubItems(5).Text())
                    itmx1.SubItems.Add(home1.ListView_food.Items(i).SubItems(6).Text())
                    'itmx1.SubItems.Add(home1.ListView_food.Items(i).SubItems(6).Text())

                Next

            End If
        End If


    End Sub
End Class