Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Text
Public Class func
    Dim con As New Mysql
    Public Sub getColor(ByRef comp)
        Dim cDialog As New ColorDialog()
        cDialog.Color = comp.BackColor

        If (cDialog.ShowDialog() = DialogResult.OK) Then
            comp.BackColor = cDialog.Color
        End If
    End Sub

    Public Sub setColor(ByRef comp As Button, ByVal bcolor As String, ByVal fcolor As String)
        Dim c(3) As String
        If bcolor <> "" Then
            c = bcolor.Split(",")
            comp.BackColor = Color.FromArgb(255, c(0), c(1), c(2))
        End If
        If fcolor <> "" Then
            c = fcolor.Split(",")
            comp.ForeColor = Color.FromArgb(255, c(0), c(1), c(2))
        End If
    End Sub

    Public Sub setColor(ByRef comp As TextBox, ByVal bcolor As String, ByVal fcolor As String)
        Dim c(3) As String
        If bcolor <> "" Then
            c = bcolor.Split(",")
            comp.BackColor = Color.FromArgb(255, c(0), c(1), c(2))
        End If
        If fcolor <> "" Then
            c = fcolor.Split(",")
            comp.ForeColor = Color.FromArgb(255, c(0), c(1), c(2))
        End If
    End Sub

    Public Sub setColor(ByRef comp As Panel, ByVal bcolor As String, ByVal fcolor As String)
        Dim c(3) As String
        If bcolor <> "" Then
            c = bcolor.Split(",")
            comp.BackColor = Color.FromArgb(255, c(0), c(1), c(2))
        End If
        If fcolor <> "" Then
            c = fcolor.Split(",")
            comp.ForeColor = Color.FromArgb(255, c(0), c(1), c(2))
        End If
    End Sub

    Public Sub setFontIB(ByRef obj As Button, ByVal ita As Boolean, ByVal bold As Boolean)
        If ita = True And bold = True Then
            obj.Font = New Font(obj.Font.FontFamily, obj.Font.Size, FontStyle.Italic Or FontStyle.Bold)
        ElseIf ita = True And bold = False Then
            obj.Font = New Font(obj.Font.FontFamily, obj.Font.Size, FontStyle.Italic)
        ElseIf ita = False And bold = True Then
            obj.Font = New Font(obj.Font.FontFamily, obj.Font.Size, FontStyle.Bold)
        Else
            obj.Font = New Font(obj.Font.FontFamily, obj.Font.Size, FontStyle.Regular)
        End If
    End Sub

    Public Sub setFontIB(ByRef obj As TextBox, ByVal ita As Boolean, ByVal bold As Boolean)
        If ita = True And bold = True Then
            obj.Font = New Font(obj.Font.FontFamily, obj.Font.Size, FontStyle.Italic Or FontStyle.Bold)
        ElseIf ita = True And bold = False Then
            obj.Font = New Font(obj.Font.FontFamily, obj.Font.Size, FontStyle.Italic)
        ElseIf ita = False And bold = True Then
            obj.Font = New Font(obj.Font.FontFamily, obj.Font.Size, FontStyle.Bold)
        Else
            obj.Font = New Font(obj.Font.FontFamily, obj.Font.Size, FontStyle.Regular)
        End If
    End Sub

    Public Sub setFontIB(ByRef obj As Label, ByVal ita As Boolean, ByVal bold As Boolean)
        If ita = True And bold = True Then
            obj.Font = New Font(obj.Font.FontFamily, obj.Font.Size, FontStyle.Italic Or FontStyle.Bold)
        ElseIf ita = True And bold = False Then
            obj.Font = New Font(obj.Font.FontFamily, obj.Font.Size, FontStyle.Italic)
        ElseIf ita = False And bold = True Then
            obj.Font = New Font(obj.Font.FontFamily, obj.Font.Size, FontStyle.Bold)
        Else
            obj.Font = New Font(obj.Font.FontFamily, obj.Font.Size, FontStyle.Regular)
        End If
    End Sub

    Public Sub setCombobox(ByRef cbo1 As ComboBox, ByRef cbo2 As ComboBox, ByRef cbo3 As ComboBox, ByRef cbo4 As ComboBox, ByVal res As MySqlDataReader)
        Dim cboItemsFl As New List(Of cboItem)
        While res.Read
            cboItemsFl.Add(New cboItem With {.Text = res.GetString(1), .Value = res.GetString(0)})
        End While

        cbo1.DataSource = Nothing
        cbo1.Items.Clear()
        With cbo1
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .DataSource = cboItemsFl
        End With
        If cbo1.Items.Count > 0 Then
            cbo1.SelectedIndex = 0
        End If

        cbo2.DataSource = Nothing
        cbo2.Items.Clear()
        With cbo2
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .DataSource = cboItemsFl
        End With
        If cbo2.Items.Count > 0 Then
            cbo2.SelectedIndex = 0
        End If

        cbo3.DataSource = Nothing
        cbo3.Items.Clear()
        With cbo3
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .DataSource = cboItemsFl
        End With
        If cbo3.Items.Count > 0 Then
            cbo3.SelectedIndex = 0
        End If

        cbo4.DataSource = Nothing
        cbo4.Items.Clear()
        With cbo4
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .DataSource = cboItemsFl
        End With
        If cbo4.Items.Count > 0 Then
            cbo4.SelectedIndex = 0
        End If
    End Sub

    Public Function versionConverse(ByVal version As String) As Integer
        Try
            Dim v As Integer = 0
            Dim str() As String = version.ToString.Split(".")
            Dim s As String = ""
            For i As Integer = 0 To str.Length - 1
                If i = 1 Then
                    For j As Integer = 1 To (3 - str(i).Length)
                        str(i) = "0" & str(i)
                    Next
                ElseIf i = 2 Then
                    For j As Integer = 1 To (5 - str(i).Length)
                        str(i) = "0" & str(i)
                    Next
                End If
            Next
            For k As Integer = 0 To str.Length - 1
                s &= str(k)
            Next
            v = CInt(s)
            Return v
        Catch ex As Exception
            MsgBox(ex.Message)
            Return 0
        End Try
    End Function
    Friend version As String = "1.0.58"
    Public Sub CheckVersion()
        My.Settings.version = "1.0.58"
        Login.Label7.Text = "Version " & My.Settings.version
        '========== check version for update ======'
        Dim h As MySqlDataReader = con.mysql_query("select system_db_version from main_system")
        h.Read()
        Dim func As New func
        If func.versionConverse(h.GetString("system_db_version")) > func.versionConverse(version) Then
            Process.Start(Directory.GetCurrentDirectory() & "\POS_Autoupdate.exe", h.GetString("system_db_version"))
        End If
        '===== update db server เป็น version ใหม่
        Dim vs As Integer = func.versionConverse(h.GetString("system_db_version"))
        If func.versionConverse("1.0.35") > vs Then
            'update db code
            con.mysql_query("UPDATE main_system SET system_db_version='1.0.35';")
        End If
        If func.versionConverse("1.0.36") > vs Then
            'update db code
            Dim SSTR As String = ""
            SSTR += "DROP TABLE pos_disc_detail;"
            SSTR += "CREATE TABLE `pos_disc_detail` (`no` int(11) NOT NULL auto_increment,`id` varchar(11) NOT NULL,"
            SSTR += "`ref_invoice` varchar(11) NOT NULL,`net_amount` double(12,2) NOT NULL,`name_tb` varchar(100) NOT NULL default '-',"
            SSTR += "`action` varchar(150) NOT NULL default '-',"
            SSTR += "`prs` int(5) NOT NULL default '0',"
            SSTR += "PRIMARY KEY(`no`)) CHARSET=utf8 AUTO_INCREMENT=0 ;"
            SSTR += "UPDATE main_system SET system_db_version='1.0.36';"
            con.mysql_query(SSTR)
        End If
        If func.versionConverse("1.0.37") > vs Then
            'update db code
            Dim SSTR As String = ""
            If Admin_Report.Check_Key = "2001E-2C517-9051A-07B3D-616A3-1C7EE" Then
                SSTR += "UPDATE pos_closebilldetail SET cprd_type_dis_th='อาหาร',cprd_type_dis_en='Food',cprd_type_dis_id='1'  where  c_id_subcat in (1,2,3,4,6,7,16,17,18,19,20,21,22,23,24,25,26,27,28,38,39,44,49);"
                SSTR += "UPDATE pos_closebilldetail SET cprd_type_dis_th='เครื่องดื่ม',cprd_type_dis_en='Beverage',cprd_type_dis_id='2'  where  c_id_subcat not in (1,2,3,4,6,7,16,17,18,19,20,21,22,23,24,25,26,27,28,38,39,44,49);"
            End If
            SSTR += "INSERT INTO  `pos`.`pos_report` (`id_rpt` ,`name_rpt` ,`title_rpt` ,`url_rpt` ,`open_rpt` ,`id_node0`)"
            SSTR += "VALUES (NULL ,  'Discount',  'ข้อมูลรายการส่วนลด',  'report\\',  '1',  '0'), (NULL ,  'CL',  'ข้อมูลการชำระโดยประเภท CL (City Ledger)',  'report\\',  '1',  '0');"
            SSTR += "INSERT INTO  `pos`.`pos_report` (`id_rpt` ,`name_rpt` ,`title_rpt` ,`url_rpt`,`open_rpt` ,`id_node0`)"
            SSTR += "VALUES (NULL ,  'Coupon',  'ข้อมูลการรับชำระโดย Coupon',  'report\\',  '1',  '0'), (NULL ,  'INROOM',  'ข้อมูลการรับชำระโดย INROOM ',  'report\\',  '1',  '0');"
            SSTR += "INSERT INTO  `pos`.`pos_report` (`id_rpt` ,`name_rpt` ,`title_rpt` ,`url_rpt` ,`open_rpt` ,`id_node0`)"
            SSTR += "VALUES (NULL ,  'INROOM_Detail',  'ข้อมูลการรับชำระโดย INROOM แบบแสดงรายการ',  'report\\',  '1',  '0'), (NULL ,  'sort_order',  'รายงานจัดอันดับสินค้าขายดี',  'report\\',  '1',  '0');"
            SSTR += "UPDATE main_system SET system_db_version='1.0.37';"
            con.mysql_query(SSTR)
        End If
        If func.versionConverse("1.0.38") > vs Then
            'update db code
            Dim SSTR As String = ""
            SSTR += "UPDATE main_system SET system_db_version='1.0.38';"
            con.mysql_query(SSTR)
        End If
        If func.versionConverse("1.0.39") > vs Then
            'update db code
            Dim SSTR As String = ""
            SSTR += "INSERT INTO pos_report (id_rpt,name_rpt,title_rpt,url_rpt,open_rpt,id_node0) VALUES('','sort_order_time','รายงานจัดอันดับสินค้าขายดี ตามช่วงเวลา','report\\','1','0');"
            SSTR += "UPDATE main_system SET system_db_version='1.0.39';"
            con.mysql_query(SSTR)
        End If
        If func.versionConverse("1.0.40") > vs Then
            'update db code
            Dim SSTR As String = ""
            SSTR += "ALTER TABLE  `pos_invoice` ADD  `remark` VARCHAR( 255 ) NULL DEFAULT  '-' AFTER  `cover` ;"
            SSTR += "UPDATE main_system SET system_db_version='1.0.40';"
            con.mysql_query(SSTR)
        End If
        If func.versionConverse("1.0.41") > vs Then
            'update db code
            Dim SSTR As String = ""
            SSTR += "UPDATE main_system SET system_db_version='1.0.41';"
            con.mysql_query(SSTR)
        End If
        If func.versionConverse("1.0.42") > vs Then
            'update db code
            '-===== แก้โค้ดรายงานในส่วน รายงานสรุปยอดรวม===='
            Dim SSTR As String = ""
            SSTR += "UPDATE main_system SET system_db_version='1.0.42';"
            con.mysql_query(SSTR)
        End If
        If func.versionConverse("1.0.43") > vs Then
            'update db code
            '-===== แก้โค้ดรายงานในส่วน รายงานสรุปยอดรวม===='
            Dim SSTR As String = ""
            SSTR += "ALTER TABLE  `pos_report` ADD  `status` VARCHAR( 1 ) NULL DEFAULT  '1' COMMENT  '1 open,0 close' AFTER  `id_node0` ;"
            SSTR += "UPDATE main_system SET system_db_version='1.0.43';"
            con.mysql_query(SSTR)
        End If
        If func.versionConverse("1.0.44") > vs Then
            'update db code
            '-===== แก้โค้ดรายงานในส่วน รายงานสรุปยอดรวม===='
            Dim SSTR As String = ""
            SSTR += "UPDATE main_system SET system_db_version='1.0.44';"
            con.mysql_query(SSTR)
        End If
        If func.versionConverse("1.0.45") > vs Then
            'update db code
            '-===== แก้โค้ดรายงานในส่วน รายงานสรุปยอดรวม===='
            Dim SSTR As String = ""
            SSTR += "UPDATE main_system SET system_db_version='1.0.45';"
            con.mysql_query(SSTR)
        End If
        If func.versionConverse("1.0.46") > vs Then
            'update db code
            '-===== แก้โค้ดในส่วนการ insert Inroom ===='

            Dim SSTR As String = ""
            SSTR += "UPDATE main_system SET system_db_version='1.0.46';"
            con.mysql_query(SSTR)
        End If
        If func.versionConverse("1.0.47") > vs Then
            'update db code
            '-===== แก้โค้ดในส่วนการ insert Inroom ที่เกี่ยวข้องกับของปาร์ค ===='

            Dim SSTR As String = ""
            SSTR += "UPDATE main_system SET system_db_version='1.0.47';"
            con.mysql_query(SSTR)
        End If
        If func.versionConverse("1.0.48") > vs Then
            'update db code
            '-===== แก้โค้ดในส่วนการ insert Inroom ที่เกี่ยวข้องกับของปาร์ค ===='

            Dim SSTR As String = ""
            SSTR += "UPDATE main_system SET system_db_version='1.0.48';"
            con.mysql_query(SSTR)
        End If
        If func.versionConverse("1.0.49") > vs Then
            'update db code
            '-===== แก้โค้ดในส่วนการ insert Inroom ที่เกี่ยวข้องกับของปาร์ค ===='

            Dim SSTR As String = ""
            SSTR += "UPDATE main_system SET system_db_version='1.0.49';"
            con.mysql_query(SSTR)
        End If
        If func.versionConverse("1.0.50") > vs Then
            'update db code
            '-===== แก้โค้ดในส่วนการแสดงผลรายการเมนูอาหารตรงแถบคลิกเรื่อยรายการเมนู===='

            Dim SSTR As String = ""
            SSTR += "UPDATE main_system SET system_db_version='1.0.50';"
            con.mysql_query(SSTR)
        End If
        If func.versionConverse("1.0.51") > vs Then
            'update db code
            '-===== แก้โค้ดในส่วนการแสดงผลรายการเมนูอาหารตรงแถบคลิกเรื่อยรายการเมนูในหน้าGohome===='
            '-===== แก้ไข ส่วนหลังบ้าน ตั้งค่การรับเงิน เพิ่ม กรอกรับเอง กับ รับโอนผ่านะนาคาร===='
            '-===== แก้ดาต้าเบสตาราง payment_acc ตามด้านล่าง===='
            '-===== แก้โค้ดในส่วนดารรับชำระเงินINROOM===='


            Dim SSTR As String = ""
            SSTR += "UPDATE main_system SET system_db_version='1.0.51';"
            SSTR += "ALTER TABLE  `pos_payment_acc` ADD  `active_acc` INT( 1 ) NULL DEFAULT  '0' COMMENT  '0 off,1,open' AFTER  `name_acc` ;"
            SSTR += "INSERT INTO `pos`.`pos_payment_type` (`id`, `name`, `remark`, `pay_active`, `iType_1`, `CL`) VALUES ('5', 'OTHER', 'รับเงินรูปแบบอื่นๆ', '1', '2', '0'), ('99', 'Bank Transfer', 'รับโอนจากธนาคาร', '1', '2', '0');"
            con.mysql_query(SSTR)
        End If
        If func.versionConverse("1.0.52") > vs Then
            'update db code
            '-===== เพิ่มชื่อรายการอาหารเป็นภาษาอังกฤษ ไทย เพิ่อให้สามารถเลือกปริ้นได้===='
            '===== เพิ่มfield ชื่อ รายการเป็นภาษาไทย และ ภาษาอังกฤษ 3 ตาราง closebill detail และ order list , tempprint'
            '*****แก้ไขโค้ดหลังบ้านหน้าแสดง รายการสินค้า เลือกปริ้นสินค้า'
            '==== เพิ่มโค้ดการตั้งค้า ปริ้น เลือกภาษา โดยตั้งเปิดปิดหน้าฟอร์ม ไว้ 3 ที่ คือ ส่งครัว รองบิล จ่ายเงิน ให้เลือกตั้งเปิดปิดหน้าจอได้
            '===== แก้ไขโค้ดยกลเลิกรายการสินค้าให้ทำงานได้ง่ายขึ้นโดยไม่ต้องลบสินค้าเก่าทิ้ง แล้วเพิ่มใหม่
            '===== เก็บข้อมูลการยกเลิอกสินค้าไว้ ทั้งแบบยกเลิกบางอันในบิล หรือ ยกเลิกโต๊ะก็เก็บไว้ในtb order void 
            '=== แก้ไข บิล(ส่งตัวแปรเอา) รองบิล(ส่งตัวแปรเอา) ส่งครัวมี2ไฟล์ ให้รับตัวแปรการเลือกภาษาปริ้น เพิ่มรายงาน order void
            '===== แก้ไข view ใน database เอง มี view_order_list,view_order_list_gh,try_bill,print_bill
            '=== view_order_list แก้ไขเพิ่มชื่อสินค้าอังกฤษ และ group by เลขinvoice , group sendcaptain,เอาเงื่อนไข void ออก ประมาณนี้ลองเช็คกับdbที่แก้ไขเอานะ
            '=== view_order_list_gh แก้ไขเพิ่มชื่อสินค้าอังกฤษ และ group by เลขinvoice , group sendcaptain,เอาเงื่อนไข void ออก ประมาณนี้ลองเช็คกับdbที่แก้ไขเอานะ

            Dim SSTR As String = ""
            SSTR += "UPDATE main_system SET system_db_version='1.0.52';"
            SSTR += "ALTER TABLE  `pos_closebilldetail` ADD  `cname_ord_en` VARCHAR( 255 ) NULL DEFAULT  '-' AFTER  `cname_ord` ;"
            SSTR += "ALTER TABLE  `pos_order_list` ADD  `name_ord_en` VARCHAR( 255 ) NULL DEFAULT  '-' AFTER  `name_ord` ;"
            SSTR += "ALTER TABLE  `pos_temp_print` ADD  `name_ord_en` VARCHAR( 255 ) NULL DEFAULT  '-' AFTER  `name_ord` ;"
            SSTR += "DROP TABLE IF EXISTS pos_order_void;"
            SSTR += "CREATE TABLE `pos_order_void` ("
            SSTR += "`idVoid` int(11) NOT NULL auto_increment,"
            SSTR += "`ref_id_tb` int(11) NOT NULL,"
            SSTR += "`rf_id_invoice` int(11) NOT NULL default '0',"
            SSTR += "`rf_id_prd` int(11) NOT NULL,"
            SSTR += "`rf_id_con` int(11) NOT NULL,"
            SSTR += "`code_gohome` varchar(30) collate utf8_bin default NULL,"
            SSTR += "`remark_v` varchar(255) collate utf8_bin default NULL,"
            SSTR += "`name_ord` varchar(100) collate utf8_bin default NULL,"
            SSTR += "`name_ord_en` varchar(255) collate utf8_bin default NULL,"
            SSTR += "`amt_v` int(11) default '0',"
            SSTR += "`price_v` double(12,2) default '0.00',"
            SSTR += "`prs_v` varchar(10) collate utf8_bin default '0',"
            SSTR += "`ref_cat_id_v` int(11) default '0',"
            SSTR += "`ref_catsubprd_v` int(11) default '0',"
            SSTR += "`name_th_cat_v` varchar(255) collate utf8_bin default NULL,"
            SSTR += "`name_en_cat_v` varchar(255) collate utf8_bin default NULL,"
            SSTR += "`name_th_catsubprd_v` varchar(255) collate utf8_bin default NULL,"
            SSTR += "`name_en_catsubprd_v` varchar(255) collate utf8_bin default NULL,"
            SSTR += "`ord_vat_v` int(2) default '0',"
            SSTR += "`ord_vat_st_v` varchar(1) collate utf8_bin default NULL,"
            SSTR += " `prd_type_dis_id_v` int(11) default '0',"
            SSTR += "`prd_type_dis_en_v` varchar(150) collate utf8_bin default '0',"
            SSTR += "`prd_type_dis_th_v` varchar(150) collate utf8_bin default '0',"
            SSTR += "`actionBy` varchar(20) collate utf8_bin default NULL,"
            SSTR += " `date_void` datetime default NULL,"
            SSTR += " PRIMARY KEY  (`idVoid`)"
            SSTR += ") ENGINE=MyISAM AUTO_INCREMENT=1 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;"
            con.mysql_query(SSTR)
        End If
        If func.versionConverse("1.0.53") > vs Then
            'อัพเดตโค้ด insert vat ไม่เข้า ตาราง pos_closebill detail
            Dim SSTR As String = ""
            SSTR += "UPDATE main_system SET system_db_version='1.0.53';"

            con.mysql_query(SSTR)
        End If
        If func.versionConverse("1.0.54") > vs Then
            'อัพเดตโค้ด หน้าจ่ายเงินคำนวณยอดส่วนลดไม่ตรง แลละเช็คvat ไม่เข้าตาราง pos_closebill_detail
            Dim SSTR As String = ""
            SSTR += "UPDATE main_system SET system_db_version='1.0.54';"

            con.mysql_query(SSTR)
        End If
        If func.versionConverse("1.0.55") > vs Then
            'แก้ไขโค้ดสั่งรันเก็บภาษาไทยในการ connect ดาต้าเบส
            Dim SSTR As String = ""
            SSTR += "UPDATE main_system SET system_db_version='1.0.55';"

            con.mysql_query(SSTR)
        End If
        If func.versionConverse("1.0.56") > vs Then
            'อัพเดตโค้ดทำการยกเลิกรายการที่ยกเลิกรายการไม่ตรง 
            Dim SSTR As String = ""
            SSTR += "UPDATE main_system SET system_db_version='1.0.56';"

            con.mysql_query(SSTR)
        End If
        If func.versionConverse("1.0.57") > vs Then
            'อัพเดตโค้ดส่ง INROOM ไม่ให้เอารายการที่ยกเลิกไปด้วย
            Dim SSTR As String = ""
            SSTR += "UPDATE main_system SET system_db_version='1.0.57';"

            con.mysql_query(SSTR)
        End If
        If func.versionConverse("1.0.58") > vs Then
            'cก้ไขโค้ด การจองและเปิดปุ่ม บันทึกให้กดได้อีกครัง และใส่ส่วนตั้งค่าเปิดปิดคีย์บอร์ดเอง
            Dim SSTR As String = ""
            SSTR += "UPDATE main_system SET system_db_version='1.0.58';"

            con.mysql_query(SSTR)
        End If

    End Sub
End Class


