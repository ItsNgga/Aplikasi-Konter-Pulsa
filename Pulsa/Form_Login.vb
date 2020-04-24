Imports System.Data.SqlClient
Imports System.Text
Imports System.IO
Imports System.Globalization

Public Class Form_Login
    Protected _username As String
    Protected _password_ As String
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = "rangga"
        TextBox2.Text = "123"
        TextBox2.UseSystemPasswordChar = True
        GetIpAddres()
        cekSession()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Application.Exit()
    End Sub
    Sub Saldos()
        Koneksi()
        Cmd = New SqlCommand("Select * from tbl_member where user_id='" & user_id & "'", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Rd.HasRows() Then
            saldo = Convert.ToDouble(Rd!saldo_member)
        End If
    End Sub
    Sub cekSession()
        Me.SendToBack()
        Koneksi()
        Cmd = New SqlCommand("select * from tbl_session_user where username='" & _username_ & "'", Conn)
        Rd = Cmd.ExecuteReader()
        Rd.Read()
        If Rd.HasRows Then
            'DO NOT TOUCH!'
            Dim a As Integer = CInt(DateTime.Now().ToString("HH"))
            Dim dt As String = Rd!waktu_tersisa.ToString()
            Dim b As Integer = CInt(dt.Substring(0, 2))
            Dim c As String = DateTime.Now.ToString("yyyy/MM/dd")
            Dim ds As String = Format(Rd!tanggal, "yyyy/MM/dd")
            Dim d As String = ds.Substring(0, 10)
            If c = d And a = b Then
                Dim timeAwl As TimeSpan = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"))
                Dim timeAkh As TimeSpan = DirectCast(Rd!waktu_tersisa, TimeSpan)
                Dim hasil As TimeSpan = timeAwl.Subtract(timeAkh)
                Dim hasils As Integer = CInt(hasil.Minutes)
                'SUSAH GANTINYA!'
                If hasils <= 5 Then
                    _username = Rd!username.ToString()
                    Rd.Close()
                    Koneksi()
                    Cmd = New SqlCommand("select password from tbl_login where username='" & _username_ & "'", Conn)
                    Rd = Cmd.ExecuteReader
                    Rd.Read()
                    If Rd.HasRows Then
                        _password_ = Rd!password
                        MsgBox("Anda berhasil login dari session sebelumnya!")
                        LoginSession()
                    End If
                End If
            End If
        End If
    End Sub
    Protected Sub LoginSession()
        Call Koneksi()
        Cmd = New SqlCommand("select * from tbl_login where username='" & _username & "' and password= @password", Conn)
        Cmd.Parameters.AddWithValue("@password", _password_)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Rd.HasRows() Then
            If Rd!Type = "MEMBER" Then
                username = _username_
                user_id = Rd!user_id
                Dim pathstr As String = Application.StartupPath() + "\settings.ini"
                If Not File.Exists(pathstr) Then
                    File.Create(pathstr).Dispose()
                Else
                    File.AppendAllText(pathstr, "")
                    Dim appPath = New FileInfo(Application.StartupPath() + "\settings.ini")
                    Using sw As New StreamWriter(appPath.Open(FileMode.Truncate))
                        sw.WriteLine(Encrypt(username))
                    End Using
                End If
                Saldos()
                Form_Loading.ProgressBar1.Value = 0
                Form_Loading.Show()
                Rd.Close()
                Koneksi()
                Cmd = New SqlCommand("select isVIP from tbl_member where user_id='" & user_id & "'", Conn)
                Rd = Cmd.ExecuteReader
                Rd.Read()
                If Rd.HasRows Then
                    If Rd!isVIP.ToString() = "YES" Then
                        type = "VIP"
                    Else
                        type = "NoNVIP"
                    End If
                End If
                Me.Hide()
            End If
        Else
            MsgBox("Password atau Username salah!")
        End If
    End Sub
    Protected Sub Login()
        If Not TextBox1.Text = "" And Not TextBox2.Text = "" Then
            Call Koneksi()
            Cmd = New SqlCommand("select * from tbl_login where username='" & TextBox1.Text & "' and password= @password", Conn)
            Cmd.Parameters.AddWithValue("@password", Encrypt(TextBox2.Text))
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Rd.HasRows() Then
                If Rd!Type = "MEMBER" Then
                    username = TextBox1.Text
                    user_id = Rd!user_id
                    InsertSession()
                    Saldos()
                    Form_Loading.ProgressBar1.Value = 0
                    Form_Loading.Show()
                    Koneksi()
                    Cmd = New SqlCommand("select isVIP from tbl_member where user_id='" & user_id & "'", Conn)
                    Rd = Cmd.ExecuteReader
                    Rd.Read()
                    If Rd.HasRows Then
                        If Rd!isVIP.ToString() = "YES" Then
                            type = "VIP"
                        Else
                            type = "NoNVIP"
                        End If
                    End If
                    Me.Hide()
                End If
            Else
                MsgBox("Password atau Username salah!")
            End If
        Else
            MsgBox("Harap isi kedua bidang!")
        End If
    End Sub
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Login()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Application.Exit()
    End Sub

    Private Sub CloseBox_Click(sender As Object, e As EventArgs) Handles CloseBox.Click
        Application.Exit()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.CheckState = CheckState.Checked Then
            TextBox2.UseSystemPasswordChar = False
        Else
            TextBox2.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Hide()
        Form_Register.Show()
    End Sub

End Class
