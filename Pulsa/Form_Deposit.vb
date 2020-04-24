Imports System.Data.SqlClient
Public Class Form_Deposit
    Dim ngetik As Boolean = False
    Dim MenuTerbuka As Boolean = False
    Sub ResetData()
        PanelMenu.Width = 0
        Label4.Text = username
        PictureBox8.Image = My.Resources.uknown
        ComboBox2.SelectedIndex = -1
        ComboBox1.SelectedIndex = -1
        LBLNomor.Text = ""
        TextBox2.Text = ""
        Button8.Enabled = False
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
            Button7.Show()
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
            Button7.Hide()
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Form_Transaksi.Show()
        ResetData()
    End Sub

    Private Sub Timer1_Tick_1(sender As Object, e As EventArgs) Handles Timer1.Tick
        If type = "VIP" Then
            PictureBox10.Visible = True
            Label11.Show()
        Else
            PictureBox10.Visible = False
            Label11.Hide()
        End If
        Label4.Text = username
        LBLSaldo.Text = "Rp " + Convert.ToString(saldo)
        If ComboBox1.Text = "OVO" Then
            LBLNomor.Text = "OVO"
            PictureBox8.Image = My.Resources.icon_ovo
            ngetik = True
        ElseIf ComboBox1.Text = "DANA" Then
            LBLNomor.Text = "DANA"
            PictureBox8.Image = My.Resources.icon_dana
            ngetik = True
        ElseIf ComboBox1.Text = "GOPAY" Then
            LBLNomor.Text = "GOPAY"
            PictureBox8.Image = My.Resources.icon_gopay
            ngetik = True
        Else
            LBLNomor.Text = ""
            PictureBox8.Image = My.Resources.uknown
            ngetik = False
        End If
        If Not TextBox2.TextLength >= 11 Then
            Button8.Enabled = False
        Else
            Button8.Enabled = True
        End If
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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        MenuTerbuka = False
        iconMenu()
        For i = 306 To 0 Step -6
            PanelMenu.Width = i
        Next
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

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Hide()
        Form_Bug_Report.Show()
        ResetData()
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9" Or e.KeyChar = Chr(13)) Or e.KeyChar = vbBack) Then
            e.Handled = True
        ElseIf Not ComboBox2.SelectedIndex = "" Then
            ComboBox1.Enabled = True
        End If
    End Sub


    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If TextBox2.TextLength > 10 And Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
            Button8.Enabled = True
        Else
            Button8.Enabled = False
            If ngetik = True Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If ComboBox2.SelectedIndex = -1 Then
            MsgBox("Harap isi jumlah deposit terlebih dahulu")
        ElseIf ComboBox1.SelectedIndex = -1 Then
            MsgBox("Harap isi metode pembayaran terlebih dahulu")
        ElseIf TextBox2.Text = "" Then
            MsgBox("Harap isi nomor tujuan " + LBLNomor.Text + " anda")
        Else
            Koneksi()
            Cmd = New SqlCommand("select limit_tagihan from tbl_member where user_id='" & user_id & "'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Rd.HasRows Then
                Dim a As Decimal = Convert.ToDecimal(ComboBox2.Text)
                Dim b As Decimal = Convert.ToDecimal(Rd!limit_tagihan)
                If Val(a) > Val(b) Then
                    MsgBox("Limit tagihan deposit anda Rp " + b.ToString() + vbCrLf + "Telah melebihi limit yang telah di tentukan" + vbCrLf + "Beli VIPMEMBER untuk menambah jumlah limit anda!")
                Else
                    Form_Konfirmasi_Deposit.LBLTotalDeposit.Text = ComboBox2.Text
                    Form_Konfirmasi_Deposit.LBLNomor.Text = LBLNomor.Text
                    Form_Konfirmasi_Deposit.LBLNomorS.Text = TextBox2.Text
                    Me.Hide()
                    Form_Konfirmasi_Deposit.Show()
                End If
            End If
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        ComboBox1.Enabled = True
    End Sub

End Class