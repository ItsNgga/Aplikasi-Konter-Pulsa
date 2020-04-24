Imports System.Data.SqlClient
Imports System.Threading
Public Class Form_Konfirmasi_Deposit
    Private Sub Form_Konfirmasi_Deposit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Profil()
        Muncul()
    End Sub
    Sub Reset()
        LBLNoDeposit.Text = ""
        LBLNomor.Text = 0
        LBLNomorS.Text = ""
        LBLStatusDeposit.Text = "Menunggu Konfirmasi"
        LBLTotalDeposit.Text = 0
        LBLWaktuPembayaran.Text = ""
    End Sub
    Sub Muncul()
        Call Koneksi()
        Cmd = New SqlCommand("select no_deposit from tbl_info_deposit where no_deposit in (select max(no_deposit) from tbl_info_deposit)", Conn)
        Dim UrutanKode As String
        Dim Hitung As Double
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Not Rd.HasRows Then
            UrutanKode = "DPT" + Format(Now, "ddMMyy") + "001"
        Else
            Hitung = Microsoft.VisualBasic.Right(Rd.GetString(0), 9) + 1
            UrutanKode = "DPT" + Format(Now, "ddMMyy") + Microsoft.VisualBasic.Right("000" & Hitung, 3)
        End If
        LBLNoDeposit.Text = UrutanKode.ToString()
    End Sub
    Sub Profil()
        Call Koneksi()
        Cmd = New SqlCommand("select * from TBL_MEMBER where user_id='" & user_id & "'", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Rd.HasRows Then
            If Not IsDBNull(Rd!binary_foto) Then
                Call Koneksi()
                Dim str As String = "select binary_foto from tbl_member where user_id='" & user_id & "'"
                Da = New SqlDataAdapter(str, Conn)
                Dim CmdB As New SqlCommandBuilder(Da)
                Da.Fill(Dt)
                Dim gambAr() As Byte = Dt.Rows(0).Item("binary_foto")
                Dim gambars As New System.IO.MemoryStream(gambAr)
                PictureBox1.Image = Image.FromStream(gambars)
            ElseIf IsDBNull(Rd!url_foto) Then
                PictureBox1.Image = My.Resources.uknown
            End If
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        LBLWaktuPembayaran.Text = Format(DateTime.Now)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form_Deposit.ResetData()
        Form_Deposit.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            UseWaitCursor = True
            Button1.Text = "Memprosess.."
            Thread.Sleep(3000)
            LBLStatusDeposit.Text = "Sukses"
            Thread.Sleep(3000)
            Koneksi()
            Dim a As Decimal = Convert.ToDecimal(LBLTotalDeposit.Text)
            Dim b As Decimal = Convert.ToDecimal(saldo)
            Dim hasil As Decimal = Val(a) + Val(b)
            saldo = hasil
            Dim str As String = "update tbl_member set saldo_member='" & hasil & "' where user_id='" & user_id & "'"
            Cmd = New SqlCommand(str, Conn)
            Cmd.ExecuteNonQuery()
            Koneksi()
            Dim strs As String = "insert into tbl_deposit values('" & user_id & "','" & a & "','" & LBLStatusDeposit.Text & "','" & LBLNomor.Text & "','" & LBLNoDeposit.Text & "')"
            Cmd = New SqlCommand(strs, Conn)
            Cmd.ExecuteNonQuery()
            Dim pulsa_server As Decimal
            Koneksi()
            Cmd = New SqlCommand("select pulsa_server from tbl_pulsa", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Rd.HasRows Then
                pulsa_server = Convert.ToDecimal(Rd!pulsa_server)
            End If
            Koneksi()
            Dim hasils As Decimal = Val(pulsa_server) + Val(a)
            Dim ster As String = "update tbl_pulsa set pulsa_server='" & hasils & "', perubahan='" & LBLWaktuPembayaran.Text & "'"
            Cmd = New SqlCommand(strs, Conn)
            Cmd.ExecuteNonQuery()
            Koneksi()
            Dim stress As String = "insert into tbl_info_deposit values('" & LBLNoDeposit.Text & "','" & user_id & "','" & DateTime.Now & "','" & pulsa_server & "','" & Convert.ToDecimal(saldo) & "')"
            Cmd = New SqlCommand(stress, Conn)
            Cmd.ExecuteNonQuery()
            MsgBox("Pembayaran Sukses!")
            Form_Deposit.ResetData()
            Me.Hide()
            Form_Deposit.Show()
            Button1.Text = "Konfirmasi"
            UseWaitCursor = False
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub
End Class