Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows.Forms
Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Text
Imports System.Collections.Generic
Public Class Admin_ReportInputParameter2
    Dim cryRpt As New ReportDocument
    Dim con As New Mysql
    Public NameFileReport As String = ""
    Public ServerPathFile As String = ""
    Dim TextLine() As String
    Dim TextLine_Server() As String
    Dim nameF As String = ""
    Dim serverfile As String = ""
    Dim nameCompany As String = ""
    Private Sub Admin_ReportInputParameter2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextLine = NameFileReport.ToString.Split("=")
        TextLine_Server = ServerPathFile.Split("=")
        nameF = TextLine(0).ToString
        serverfile = TextLine_Server(0).ToString()
        loadDataTreeview()
    End Sub
    Public Sub loadDataTreeview()
        TreeView1.Nodes.Clear()
        'TreeView1.Nodes.Add("Node0", "All")
        Dim strQuery As String = "SELECT * FROM pos_catprd where id_status_sales<>'2' ORDER BY id ASC "
        ShowDataTreeviewCat(strQuery, "SELECT_CAT")
    End Sub
    Public Sub ShowDataTreeviewCat(ByRef SQLStatement As String, ByRef TypeIN As String)
        If TypeIN = "SELECT_CAT" Then
            Dim reader As MySqlDataReader = con.mysql_query(SQLStatement)
            Dim childnodes() As TreeNode
            Dim str As New List(Of String)()
            Dim i As Integer = 0
            Dim str_name As String
            Dim Nodes(5) As TreeNode
            While reader.Read()
                Dim id As String = reader.GetString("id")
                childnodes = TreeView1.Nodes.Find("Node0", True)

                If reader.GetString("namecat_th") <> "" Then
                    str_name = reader.GetString("namecat_th") & " (" & reader.GetString("namecat_en") & ")"
                Else
                    str_name = reader.GetString("namecat_en") & " (" & reader.GetString("namecat_th") & ")"
                End If

                ' TreeView1.Nodes.Add("All").Nodes.Add(reader.GetString("id"), str_name, reader.GetString("id"))
                TreeView1.Nodes.Add(id, reader.GetString("id_cat") & "-" & str_name, reader.GetString("id"), reader.GetString("id"))

                'add sub childnodes
                str.Add(id)
                i += 1
            End While
            reader.Close()

            For j = 0 To i - 1
                loadSubNotes(str(j))
            Next
        End If
        TreeView1.ExpandAll()
    End Sub
    Public Sub loadSubNotes(ByVal NodesID As Integer)
        Dim reader_sub As MySqlDataReader = con.mysql_query("SELECT * FROM pos_catsubprd WHERE ref_id_cat='" & NodesID & "' and id_status_sales<>'2' ORDER BY id ASC")
        Dim subchildnodes1(2) As TreeNode
        Dim str_name As String
        Dim i As Integer = 0
        While reader_sub.Read()
            If reader_sub.GetString("id") <> "" Then
                subchildnodes1 = TreeView1.Nodes.Find(NodesID, True)
                If reader_sub.GetString("name_th") <> "" Then
                    str_name = reader_sub.GetString("name_th") & " (" & reader_sub.GetString("name_en") & ")"
                Else
                    str_name = reader_sub.GetString("name_en") & " (" & reader_sub.GetString("name_th") & ")"
                End If
                subchildnodes1(0).Nodes.Add(reader_sub.GetString("id"), reader_sub.GetString("id_subcat") & "-" & str_name, reader_sub.GetString("id"), reader_sub.GetString("id"))
            End If
        End While
    End Sub

    Private Sub btn_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ok.Click
        Dim date_st As String = ""
        If CInt(DateTimePicker_Start.Value.ToString("yyyy")) > 2450 Then
            date_st = CInt(DateTimePicker_Start.Value.ToString("yyyy")) - 543 & DateTimePicker_Start.Value.ToString("-MM-dd")
        Else
            date_st = DateTimePicker_Start.Value.ToString("yyyy-MM-dd")
        End If

        Dim date_ed As String = ""
        If CInt(DateTimePicker_End.Value.ToString("yyyy")) > 2450 Then
            date_ed = CInt(DateTimePicker_End.Value.ToString("yyyy")) - 543 & DateTimePicker_End.Value.ToString("-MM-dd")
        Else
            date_ed = DateTimePicker_End.Value.ToString("yyyy-MM-dd")
        End If
        If Admin_Report.openReport = True Then
            cryRpt.Close()
        End If
        For Each filepath As String In Directory.GetFiles("temp\")
            File.Delete(filepath)
        Next
        FileCopy(Login.pathreport & "\" & nameF & ".rpt", "temp\" & nameF & ".rpt")
        cryRpt.Load("temp\" & nameF & ".rpt")
        cryRpt.SetParameterValue("DateStart", date_st)
        cryRpt.SetParameterValue("DateEnd", date_ed)
        'cryRpt.SetParameterValue("id_subgroup", New ParameterDiscreteValue("64,99"))
        cryRpt.SetParameterValue("UserName", Login.username)


        'สร้างส่งค่า value parameter หลายๆค่า
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue
        crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields
        crParameterFieldDefinition = crParameterFieldDefinitions.Item("id_subgroup")
        crParameterValues = crParameterFieldDefinition.CurrentValues
        For Each cn As TreeNode In TreeView1.Nodes
            'If cn.Checked Then
            For Each childNodeLevel2 As TreeNode In cn.Nodes
                If childNodeLevel2.Checked Then
                    crParameterDiscreteValue = New ParameterDiscreteValue()
                    crParameterDiscreteValue.Value = childNodeLevel2.SelectedImageKey().ToString
                    crParameterValues.Add(crParameterDiscreteValue)
                End If
            Next
            'End If
        Next


        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
        'crParameterValues.Clear()
        'crParameterValues.Add(crParameterDiscreteValue)
        'crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        Admin_Report.CrystalReportViewer1.ReportSource = cryRpt
        Admin_Report.CrystalReportViewer1.Refresh()
        Admin_Report.openReport = True
        Me.Close()
    End Sub


    Private Sub TreeView1_AfterCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterCheck
        '  MsgBox(e.Node.FirstNode Is Nothing)
        If e.Node.Checked Then
            If e.Node.FirstNode Is Nothing = False Then
                If e.Action <> TreeViewAction.Unknown Then
                    If e.Node.Nodes.Count > 0 Then
                        ' Calls the CheckAllChildNodes method, passing in the current 
                        ' Checked value of the TreeNode whose checked state changed. 
                        Me.CheckAllChildNodes(e.Node, e.Node.Checked)
                    End If
                End If
            End If
        Else
            'MsgBox("no")
            Me.CheckAllChildNodes(e.Node, False)
        End If
        'If e.Node.Checked Then
        '    If e.Node.Parent Is Nothing = False Then
        '        Dim allChecked As Boolean = True

        '        For Each node As TreeNode In e.Node.Parent.Nodes
        '            If Not node.Checked Then
        '                allChecked = False
        '            End If
        '        Next

        '        If allChecked Then
        '            e.Node.Parent.Checked = True
        '        End If

        '    End If
        'Else
        '    If e.Node.Parent Is Nothing = False Then
        '        e.Node.Parent.Checked = False
        '    End If
        'End If
    End Sub

    Private Sub CheckAllChildNodes(ByVal treeNode As TreeNode, ByVal nodeChecked As Boolean)
        Dim node As TreeNode
        For Each node In treeNode.Nodes
            node.Checked = nodeChecked
            If node.Nodes.Count > 0 Then
                ' If the current node has child nodes, call the CheckAllChildsNodes method recursively.
                Me.CheckAllChildNodes(node, nodeChecked)
            End If
        Next node

    End Sub

    Private Sub btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancel.Click
        Me.Close()
    End Sub


End Class