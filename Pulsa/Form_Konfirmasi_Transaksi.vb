Imports System.Data.SqlClient
Imports System.Text
Imports System.Threading

Public Class Form_Konfirmasi_Transaksi
    Sub Reset()
        LBLNoPembayaran.Text = "Nomor Pembayaran"
        LBLNoTujuan.Text = "Nomor Tujuan"
        LBLStatusPembayaran.Text = "Menunggu Konfirmasi"
        LBLTotalPembayaran.Text = "Total Pembayaran"
    End Sub
    Private Sub Form_Konfirmasi_Transaksi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Muncul()
        Profil()
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
    Sub Muncul()
        Call Koneksi()
        Cmd = New SqlCommand("select * from tbl_info_transaksi where no_transaksi in (select max(no_transaksi) from tbl_info_transaksi)", Conn)
        Dim UrutanKode As String
        Dim Hitung As Double
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Not Rd.HasRows Then
            UrutanKode = "TRS" + Format(Now, "ddMMyy") + "001"
        Else
            Hitung = Microsoft.VisualBasic.Right(Rd.GetString(0), 9) + 1
            UrutanKode = "TRS" + Format(Now, "ddMMyy") + Microsoft.VisualBasic.Right("000" & Hitung, 3)
        End If
        LBLNoPembayaran.Text = UrutanKode.ToString()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        LBLWaktuPembayaran.Text = DateTime.Now.ToString()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ihs As String = LBLTotalPembayaran.Text
        Dim st As StringBuilder = New StringBuilder()
        st.Append(ihs)
        st.Remove(0, 3)
        ihs = st.ToString()
        Dim ih As Decimal = Convert.ToDecimal(ihs)
        Dim a As Decimal = Convert.ToDecimal(saldo)
        If Val(a) < Val(ih) Then
            MsgBox("Saldo anda : Rp " + saldo.ToString() & vbCrLf & "Tidak cukup untuk melakukan pembayaran ini!")
        Else
            Try
                UseWaitCursor = True
                Button1.Text = "Memprosess.."
                Thread.Sleep(3000)
                LBLStatusPembayaran.Text = "Sukses"
                LBLStatusPembayaran.Text = "Sukses"
                Thread.Sleep(3000)
                UseWaitCursor = False
                Koneksi()
                Dim pulsa_server As Decimal
                Cmd = New SqlCommand("select pulsa_server from tbl_pulsa", Conn)
                Rd = Cmd.ExecuteReader
                Rd.Read()
                If Rd.HasRows Then
                    pulsa_server = Convert.ToDecimal(Rd!pulsa_server)
                End If
                Koneksi()
                Dim hasil As Decimal = Val(pulsa_server) - Val(ih)
                Dim strs As String = "update tbl_pulsa set pulsa_server='" & hasil & "', perubahan='" & LBLWaktuPembayaran.Text & "'"
                Cmd = New SqlCommand(strs, Conn)
                Cmd.ExecuteNonQuery()
                Koneksi()
                Dim saldos As Decimal = Val(saldo) - Val(Convert.ToDecimal(ihs))
                Dim su As String = "update tbl_member set saldo_member='" & saldos & "' where user_id='" & user_id.ToString() & "'"
                Cmd = New SqlCommand(su, Conn)
                Cmd.ExecuteNonQuery()
                Koneksi()
                Dim Asf As Decimal = Convert.ToDecimal(ihs)
                Dim str As String = "insert into tbl_transaksi values('" & user_id.ToString() & "','" & LBLWaktuPembayaran.Text & "','" & Asf & "','" & LBLStatusPembayaran.Text.ToString() & "')"
                Cmd = New SqlCommand(str, Conn)
                Cmd.ExecuteNonQuery()
                Dim saldong As Decimal = Val(saldo) - Val(Convert.ToDecimal(ihs))
                Dim str2 As String = "insert into tbl_info_transaksi values('" & LBLNoPembayaran.Text.ToString() & "','" & user_id & "','" & Operators.ToString() & "','" & hasil & "','" & saldong & "')"
                Cmd = New SqlCommand(str2, Conn)
                Cmd.ExecuteNonQuery()
                saldo = Convert.ToDouble(saldong)
            Finally
                MsgBox("Pembayaran Anda Berhasil!")
                Button1.Text = "Konfirmasi"
                Reset()
                Me.Hide()
                Form_Transaksi.Show()
                Form_Transaksi.ResetData()
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Reset()
        Me.Hide()
        Form_Transaksi.Show()
        Form_Transaksi.ResetData()
    End Sub
End Class