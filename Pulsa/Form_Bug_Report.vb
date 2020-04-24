Imports System.Data.SqlClient
Imports System.IO
Public Class Form_Bug_Report
    Dim strDir As String
    Dim noLaporan As String
    Dim emailS As String
    Sub Reset()
        TextBox1.Text = ""
        TextBox2.Text = ""
        RichTextBox1.Text = ""
        CheckBox1.CheckState = CheckState.Unchecked
        Button1.Enabled = False
        strDir = ""
        noLaporan = ""
        PictureBox2.Image = My.Resources.uknown
    End Sub
    Sub Muncul()
        Call Koneksi()
        Cmd = New SqlCommand("select no_laporan from tbl_laporan_bugs where no_laporan in (select max(no_laporan) from tbl_laporan_bugs)", Conn)
        Dim UrutanKode As String
        Dim Hitung As Integer
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Not Rd.HasRows Then
            UrutanKode = "BUG" + Format(Now, "ddMMyy") + "001"
        Else
            Hitung = Microsoft.VisualBasic.Right(Rd.GetString(0), 9) + 1
            UrutanKode = "BUG" + Format(Now, "ddMMyy") + Microsoft.VisualBasic.Right("000" & Hitung, 3)
        End If
        noLaporan = UrutanKode
        LBLLaporan.Text = UrutanKode.ToString()
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Hide()
        Form_Menu.Show()
        Reset()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.CheckState = CheckState.Checked Then
            Button1.Enabled = True
        Else
            Button1.Enabled = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.Filter = "File Gambar|*.jpg;*.png;*.gif;"
        OpenFileDialog1.FileName = "File Gambar"
        If OpenFileDialog1.ShowDialog <> DialogResult.Cancel And DialogResult.Abort And DialogResult.No Then
            strDir = OpenFileDialog1.FileName
            PictureBox2.ImageLocation = OpenFileDialog1.FileName
        Else
            PictureBox2.Image = My.Resources.uknown
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        emailS = TextBox2.Text
        emailS = CekEmail(emailS)
        If emailS = "False" Then

        Else
            If TextBox1.Text = "" Then
                MsgBox("Harap isi subjek laporan anda!")
            ElseIf RichTextBox1.Text = "" Then
                MsgBox("Harap isi deskirpsi laporan anda!")
            ElseIf TextBox2.Text = "" Then
                MsgBox("Harap isi email anda!")
            ElseIf Not emailS = "False" Then
                Try
                    If strDir = "" Then
                        strDir = "Tidak Memberikan SS"
                    End If
                    Koneksi()
                    Dim str As String = "insert into tbl_laporan_bugs values('" & LBLLaporan.Text.ToString() & "','" & user_id & "','" & TextBox1.Text & "','" & RichTextBox1.Text & "','" & strDir & "', @gambar,'" & TextBox2.Text & "','" & DateTime.Now & "')"
                    Cmd = New SqlCommand(str, Conn)
                    Dim ms As New MemoryStream
                    PictureBox2.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                    Dim Gambar As Byte() = ms.GetBuffer
                    Cmd.Parameters.AddWithValue("@gambar", Gambar)
                    Cmd.ExecuteNonQuery()
                    Gambar = Nothing
                    MsgBox("Laporan Anda Sukses Dikirim!")
                    Muncul()
                    Reset()
                    Me.Hide()
                Catch ex As Exception
                    MsgBox(ex.ToString())
                End Try
            End If
        End If
    End Sub

    Private Sub Form_Bug_Report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Muncul()
        Reset()
    End Sub
End Class