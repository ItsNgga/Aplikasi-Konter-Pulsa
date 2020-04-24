Imports System.Linq.Expressions
Imports System.Data.SqlClient
Imports System.Text
Imports System.Threading

Public Class Form_Transaksi
    Dim Pajak As String
    Dim nominal As String
    Dim hasil As Double
    Dim Total As Decimal
    Dim MenuTerbuka As Boolean = False
    Sub ResetData()
        PanelMenu.Width = 0
        Label4.Text = username
        Operators = "uknown"
        TextBox1.Text = ""
        ComboBox1.Items.Clear()
        ComboBox1.Enabled = False
        ComboBox1.Text = ""
        LBLOperator.Text = "Tidak Di Ketahui"
        LBLPajak.Text = "Rp 0"
        LBLTotalBayar.Text = "Rp 0"
        MenuTerbuka = False
        iconMenu()
        For i = 306 To 0 Step -6
            PanelMenu.Width = i
        Next
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form_Menu.Show()
        ResetData()
    End Sub

    Private Sub CloseBox_Click(sender As Object, e As EventArgs) Handles CloseBox.Click
        Application.Exit()
    End Sub
    Sub iconMenu()
        If MenuTerbuka = True Then
            Button1.Show()
            Button2.Show()
            Button3.Show()
            Button4.Show()
            Button5.Show()
            Button6.Show()
            Button11.Show()
            Label1.Show()
            Label2.Show()
            Panel2.Show()
        Else
            Button1.Hide()
            Button2.Hide()
            Button3.Hide()
            Button4.Hide()
            Button5.Hide()
            Button6.Hide()
            Button11.Hide()
            Label1.Hide()
            Label2.Hide()
            Panel2.Hide()
        End If
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        iconMenu()
        If MenuTerbuka = True Then
            MenuTerbuka = False
            iconMenu()
            For i = 306 To 0 Step -6
                PanelMenu.Width = i
            Next
        Else
            MenuTerbuka = True
            For i = 0 To 306 Step 2
                PanelMenu.Width = i
            Next
            iconMenu()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Form_User_Profile.Show()
        ResetData()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Form_Deposit.Show()
        ResetData()
    End Sub

    Private Sub Timer1_Tick_1(sender As Object, e As EventArgs) Handles Timer1.Tick
        If type = "VIP" Then
            PictureBox10.Visible = True
            Label13.Show()
        Else
            PictureBox10.Visible = False
            Label13.Hide()
        End If
        If LBLTotalBayar.Text = "Rp 0" Then
            Button8.Enabled = False
            Button9.Enabled = False
        End If
        Label4.Text = username
        LBLSaldo.Text = "Rp " + Convert.ToString(saldo)
        Select Case Operators
            Case "Telkomsel"
                LBLOperator.Text = "Telkomsel"
                PictureBox8.Image = My.Resources.icon_telkomsel
            Case "XL"
                LBLOperator.Text = "XL"
                PictureBox8.Image = My.Resources.icon_xl
            Case "Indosat"
                LBLOperator.Text = "Indosat"
                PictureBox8.Image = My.Resources.icon_indosat
            Case "Smartfren"
                LBLOperator.Text = "Smartfren"
                PictureBox8.Image = My.Resources.icon_smartfren
            Case "Three"
                LBLOperator.Text = "Three"
                PictureBox8.Image = My.Resources.icon_three
            Case "Axis"
                LBLOperator.Text = "Axis"
                PictureBox8.Image = My.Resources.icon_axis
            Case Else
                LBLOperator.Text = "Tidak Di Ketahui"
                PictureBox8.Image = My.Resources.uknown
        End Select
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ResetSession()
        ResetData()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Hide()
        Form_CS.Show()
        ResetData()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MenuTerbuka = False
        iconMenu()
        For i = 306 To 0 Step -6
            PanelMenu.Width = i
        Next
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Form_Operator.Show()
    End Sub
    Sub Combo()

    End Sub
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
        If e.KeyChar = Chr(13) Then
            If TextBox1.Text = "" Then
                MsgBox("Harap isi nomor tujuan!")
            ElseIf Operators = "uknown" Or LBLOperator.Text = "Tidak Di Ketahui" Then
                MsgBox("Harap pilih operator terlebih dahulu!")
            Else
                Dim teks As String = TextBox1.Text
                Dim sket As String = teks.Substring(0, 2)
                If teks.Length = 11 Or teks.Length = 12 Or teks.Length = 13 Then
                    If sket = "08" Then
                        Koneksi()
                        Dim strs As String = "insert into tbl_history_user values('" & user_id.ToString() & "','" & Convert.ToDecimal(teks) & "')"
                        Cmd = New SqlCommand(strs, Conn)
                        Cmd.ExecuteNonQuery()
                        ComboBox1.Enabled = True
                        Koneksi()
                        Cmd = New SqlCommand("select * from tbl_nominal_operator where nama_operator='" & Operators & "'", Conn)
                        Rd = Cmd.ExecuteReader()
                        Rd.Read()
                        If Rd.HasRows Then
                            Try
                                ComboBox1.Items.Clear()
                                Dim str As String
                                Dim ins As Integer = 1
                                For ins = 1 To 15 Step 1
                                    str = "nominal_" & ins
                                    If Not IsDBNull(Rd(str)) Then
                                        ComboBox1.Items.Add(Format(Rd(str)))
                                    End If
                                Next
                            Catch ex As Exception
                                MsgBox(ex.ToString())
                            End Try
                            LBLPajak.Text = "Rp " + Rd!pajak.ToString()
                        End If
                    Else
                        MsgBox("Nomor awalan harus 08!")
                    End If
                Else
                    MsgBox("Minimal digit nomor adalah 11, maksimal adalah 13!")
                End If
            End If
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim lol As String = TextBox1.Text
        Dim lols As String
        lols = lol.Substring(1, 3)
        If lols.Length = 3 Then
            Koneksi()
            Cmd = New SqlCommand("select * from tbl_nomor_operator where digit_nomor='" & Convert.ToDecimal(lols) & "'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            Dim los As String = Rd!nama_operator
            Dim anjay As String = Trim(los)
            If Rd.HasRows And anjay = Operators Then
                Button9.Enabled = True
            Else
                MsgBox("Awalan nomor tidak sesuai dengan Operator " + LBLOperator.Text)
            End If
        End If
        nominal = ComboBox1.Text
        hasil = Convert.ToDouble(nominal) + Convert.ToDouble(Pajak)
        LBLTotalBayar.Text = "Rp " + hasil.ToString()
        Total = Convert.ToDecimal(hasil)
        Button8.Enabled = True
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Operators = "uknown"
        TextBox1.Text = ""
        ComboBox1.Items.Clear()
        ComboBox1.Enabled = False
        ComboBox1.Text = ""
        LBLOperator.Text = "Tidak Di Ketahui"
        LBLPajak.Text = "Rp 0"
        LBLTotalBayar.Text = "Rp 0"
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If LBLTotalBayar.Text = "Rp 0" Then
            MsgBox("Harap masukan jumlah pulsa sebelum melakukan pembayaran!")
        Else
            Dim a As Decimal = Convert.ToDecimal(saldo)
            Dim b As Decimal = Total
            If Val(a) < Val(b) Then
                MsgBox("Saldo anda : Rp " + saldo.ToString() & vbCrLf & "Tidak cukup untuk melakukan pembayaran ini!")
            ElseIf Val(a) > Val(b) Then
                Dim str As String = MsgBox("Apakah Nomor " + TextBox1.Text + " Adalah Nomor Yang benar?", vbYesNo)
                If str = vbYes Then
                    Form_Konfirmasi_Transaksi.LBLNoTujuan.Text = TextBox1.Text
                    Form_Konfirmasi_Transaksi.LBLTotalPembayaran.Text = LBLTotalBayar.Text
                    Me.Hide()
                    Form_Konfirmasi_Transaksi.Show()
                End If
            End If
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim lol As String = TextBox1.Text
        Dim lols As String
        If lol.Length > 3 Then
            lols = lol.Substring(1, 3)
            If lols.Length = 3 Then
                Koneksi()
                Cmd = New SqlCommand("select * from tbl_nomor_operator where digit_nomor='" & Convert.ToDecimal(lols) & "'", Conn)
                Rd = Cmd.ExecuteReader
                Rd.Read()
                If Rd.HasRows Then
                    Dim los As String = Rd!nama_operator
                    Dim anjay As String = Trim(los)
                    Operators = anjay
                    Cmd = New SqlCommand("select * from tbl_nominal_operator where nama_operator='" & Operators & "'", Conn)
                    Rd = Cmd.ExecuteReader()
                    Rd.Read()
                    If Rd.HasRows Then
                        Try
                            ComboBox1.Items.Clear()
                            Dim str As String
                            Dim ins As Integer = 1
                            For ins = 1 To 15 Step 1
                                str = "nominal_" & ins
                                If Not IsDBNull(Rd(str)) Then
                                    ComboBox1.Items.Add(Format(Rd(str)))
                                End If
                            Next
                        Catch ex As Exception
                            MsgBox(ex.ToString())
                        End Try
                        LBLPajak.Text = "Rp " + Format(Rd!pajak)
                        Pajak = Rd!pajak.ToString()
                    End If
                End If
            End If
        Else
            Operators = "uknown"
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Form_History.Muncul()
        Form_History.Show()
    End Sub
    Private Sub Panel6_Click(sender As Object, e As EventArgs) Handles Panel6.Click
        If MenuTerbuka = True Then
            MenuTerbuka = False
            iconMenu()
            For i = 306 To 0 Step -6
                PanelMenu.Width = i
            Next
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Me.Hide()
        Form_Bug_Report.Show()
        ResetData()
    End Sub

End Class