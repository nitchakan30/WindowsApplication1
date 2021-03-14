Imports MySql.Data.MySqlClient

Public Class planManageRoom
    Public fl As String = ""
    Dim conn As New Mysql
    Dim res As MySqlDataReader
    Dim res2 As MySqlDataReader

    Private Sub planManageRoom_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadDetail()
    End Sub

    Private Sub loadDetail()
        roomList.Items.Clear()
        res = conn.mysql_query("SELECT * FROM pos_table_system WHERE ref_id_location='" & fl & "' ORDER BY number ASC")

        Dim str(5) As String
        Dim itm As ListViewItem
        Dim i As Integer = 0
        While res.Read
            str(1) = res.GetString("number")
            str(2) = res.GetString("id")
            itm = New ListViewItem(str)
            roomList.Items.Add(itm)

            For j As Integer = 0 To Admin_ConfigTBCUS.roomArr.Count() - 1
                If Admin_ConfigTBCUS.roomArr(j) = res.GetString("id") Then
                    roomList.Items(i).Checked = True
                End If
            Next
            i += 1
        End While
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        For i As Integer = 0 To roomList.Items.Count - 1
            If roomList.Items(i).Checked = True Then
                Dim bl As Boolean = False
                For j As Integer = 0 To Admin_ConfigTBCUS.roomArr.Count - 1
                    If roomList.Items(i).SubItems(2).Text = Admin_ConfigTBCUS.roomArr(j) Then
                        bl = True
                        Exit For
                    End If
                Next

                If bl = False Then
                    Admin_ConfigTBCUS.addRoom(roomList.Items(i).SubItems(1).Text, roomList.Items(i).SubItems(2).Text)
                    Admin_ConfigTBCUS.roomArr.Add(roomList.Items(i).SubItems(2).Text)
                End If
            Else
                Admin_ConfigTBCUS.delRoom(roomList.Items(i).SubItems(2).Text)
                For j As Integer = 0 To Admin_ConfigTBCUS.roomArr.Count - 1
                    If roomList.Items(i).SubItems(2).Text = Admin_ConfigTBCUS.roomArr(j) Then
                        Admin_ConfigTBCUS.roomArr(j) = ""
                    End If
                Next
            End If
        Next

        Me.Close()
    End Sub
End Class