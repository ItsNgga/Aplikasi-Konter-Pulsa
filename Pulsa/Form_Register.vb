Imports System.Data.SqlClient
Public Class Form_Register
    Dim urlFoto As String
    Dim pass As String
    Dim noUsr As String
    Dim noKios As String
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
        Form_Login.Show()
        Reset()
    End Sub
    Sub Reset()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        PictureBox8.Image = My.Resources.icon_user_putih
        RichTextBox1.Text = ""
        CheckBox1.CheckState = CheckState.Unchecked
        MunculKios()
        Muncul()
    End Sub
    Sub Muncul()
        Call Koneksi()
        Cmd = New SqlCommand("select user_id from tbl_member where user_id in (select max(user_id) from tbl_member)", Conn)
        Dim UrutanKode As String
        Dim Hitung As Double
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Not Rd.HasRows Then
            UrutanKode = "USR" + "001"
        Else
            Hitung = Microsoft.VisualBasic.Right(Rd.GetString(0), 3) + 1
            UrutanKode = "USR" + Microsoft.VisualBasic.Right("000" & Hitung, 3)
        End If
        noUsr = UrutanKode.ToString()
        LBLNoUser.Text = UrutanKode
    End Sub
    Sub MunculKios()
        Call Koneksi()
        Cmd = New SqlCommand("select no_kios from tbl_member where no_kios in (select max(no_kios) from tbl_member)", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        Dim UrutanKodes As String
        Dim Hitungs As Double
        If Not Rd.HasRows Then
            UrutanKodes = "KIOS" + "001"
        Else
            Hitungs = Microsoft.VisualBasic.Right(Rd.GetString(0), 3) + 1
            UrutanKodes = "KIOS" + Microsoft.VisualBasic.Right("000" & Hitungs, 3)
        End If
        noKios = UrutanKodes.ToString()
        LBLNoKios.Text = UrutanKodes
    End Sub
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Form_License.Show()
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

    Private Sub Form_Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Muncul()
        MunculKios()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox("Harap isi username untuk Login!")
        ElseIf TextBox2.Text = "" Then
            MsgBox("Harap isi password untuk Login!")
        ElseIf TextBox3.Text = "" Then
            MsgBox("Harap isi nama anda!")
        ElseIf TextBox4.Text = "" Then
            MsgBox("Harap isi foto anda!")
        ElseIf RichTextBox1.Text = "" Then
            MsgBox("Harap isi alamat kios anda!")
        ElseIf Not CheckBox1.CheckState = CheckState.Checked Then
            MsgBox("Harap membaca dan menyetujui Licensi kami!")
        Else
            Try
                Koneksi()
                Dim str As String = "insert into tbl_login values('" & TextBox1.Text & "','" & Encrypt(TextBox2.Text) & "','" & noUsr & "','" & "MEMBER" & "')"
                Cmd = New SqlCommand(str, Conn)
                Cmd.ExecuteNonQuery()
                Dim strs As String = "insert into tbl_member values('" & noUsr & "','" & TextBox1.Text & "','" & "NoNVIP" & "','" & TextBox3.Text & "','" & Encrypt(TextBox4.Text) & "',@gambar,'" & RichTextBox1.Text & "','" & noKios & "','" & 500000 & "','" & 0 & "')"
                Cmd = New SqlCommand(strs, Conn)
                Dim ms As New System.IO.MemoryStream
                PictureBox8.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                Dim Gambar As Byte() = ms.GetBuffer
                Cmd.Parameters.AddWithValue("@gambar", Gambar)
                Cmd.ExecuteNonQuery()
                MsgBox("Register Berhasil!")
                Reset()
                Me.Hide()
                Form_Login.TextBox1.Text = TextBox1.Text
                Form_Login.TextBox2.Text = TextBox2.Text
                Form_Login.Show()
            Catch ex As SqlException
                If ex.Number = 2601 Then
                    MsgBox("Nama Username telah terdaftar!")
                Else
                    MsgBox(ex.ToString())
                End If
            End Try
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.CheckState = CheckState.Checked Then
            Form_License.Show()
        End If
    End Sub
End Class