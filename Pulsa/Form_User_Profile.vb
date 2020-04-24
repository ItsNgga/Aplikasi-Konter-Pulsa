Imports System.Data.SqlClient
Imports System.Security.Policy
Imports Microsoft.VisualBasic.ApplicationServices
Imports System.IO

Public Class Form_User_Profile
    Dim MenuTerbuka As Boolean = False
    Dim urlFoto As String
    Sub ResetData()
        PanelMenu.Width = 0
        Label4.Text = username
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
            Button9.Show()
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
            Button9.Hide()
            Label1.Hide()
            Label2.Hide()
            Panel2.Hide()
        End If
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        iconMenu()
        Dim i As Integer
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Form_Transaksi.Show()
        ResetData()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Form_Deposit.Show()
        ResetData()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ResetSession()
        ResetData()
    End Sub

    Private Sub Timer1_Tick_1(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label4.Text = username
        LBLSaldo.Text = "Rp " + Convert.ToString(saldo)
        If type = "VIP" Then
            PictureBox10.Visible = True
            Label14.Show()
        Else
            PictureBox10.Visible = False
            Label14.Hide()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Hide()
        Form_CS.Show()
        ResetData()
    End Sub
    Sub Profil()
        Call Koneksi()
        Cmd = New SqlCommand("select * from TBL_MEMBER where user_id='" & user_id & "'", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Rd.HasRows Then
            TextBox1.Text = Rd!user_id
            TextBox2.Text = Rd!username
            TextBox3.Text = Rd!nama
            TextBox4.Text = Decrypt(Rd!url_foto.ToString())
            urlFoto = Rd!url_foto.ToString()
            PictureBox8.ImageLocation = TextBox4.Text
            RichTextBox1.Text = Rd!alamat_kios
            TextBox5.Text = Convert.ToString(Rd!limit_tagihan)
            If Not IsDBNull(Rd!binary_foto) Then
                Call Koneksi()
                Dim str As String = "select binary_foto from tbl_member where user_id='" & user_id & "'"
                Da = New SqlDataAdapter(str, Conn)
                Dim CmdB As New SqlCommandBuilder(Da)
                Da.Fill(Dt)
                Dim gambAr() As Byte = Dt.Rows(0).Item("binary_foto")
                Dim gambars As New MemoryStream(gambAr)
                PictureBox8.Image = Image.FromStream(gambars)
            ElseIf IsDBNull(Rd!url_foto) Then
                PictureBox8.Image = My.Resources.uknown
            End If
        End If
    End Sub

    Private Sub Form_Profile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Profil()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        OpenFileDialog1.Filter = "File Gambar|*.jpg;*.png;*.gif;"
        OpenFileDialog1.FileName = "File Gambar"
        If OpenFileDialog1.ShowDialog <> DialogResult.Cancel And DialogResult.Abort And DialogResult.No Then
            TextBox4.Text = OpenFileDialog1.FileName
            PictureBox8.ImageLocation = TextBox4.Text
            urlFoto = TextBox4.Text
        Else
            TextBox4.Text = Decrypt(urlFoto)
            PictureBox8.ImageLocation = TextBox4.Text
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or RichTextBox1.Text = "" Then
            MsgBox("Silahkan Isi Dengan Benar!")
        Else
            Try
                Koneksi()
                Dim str As String = "update tbl_member set username='" & TextBox2.Text & "', nama='" & TextBox3.Text & "', url_foto='" & Encrypt(TextBox4.Text) & "', binary_foto=@gambar, alamat_kios='" & RichTextBox1.Text & "' where user_id='" & user_id & "'"
                Cmd = New SqlCommand(str, Conn)
                Dim ms As New MemoryStream
                PictureBox8.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                Dim Gambar As Byte() = ms.GetBuffer
                Cmd.Parameters.AddWithValue("@gambar", Gambar)
                Cmd.ExecuteNonQuery()
                Gambar = Nothing
                str = "update tbl_login set username='" & TextBox2.Text & "' where user_id='" & user_id & "'"
                Cmd = New SqlCommand(str, Conn)
                Cmd.ExecuteNonQuery()
                MsgBox("Edit Sukses!")
                Button8.Text = "Edit"
                Profil()
            Catch ex As Exception
                MsgBox(ex.ToString())
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
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

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Me.Hide()
        Form_Bug_Report.Show()
        ResetData()
    End Sub

End Class