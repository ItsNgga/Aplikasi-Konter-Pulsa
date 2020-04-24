Imports System.IO
Imports System.Text
Imports System.Net
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Security.Cryptography
Imports System.Runtime.Remoting.Messaging
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic.ApplicationServices
Imports System.Globalization

Module Engine
    'Sessions
    Public _username_ As String
    Public username As String
    Public type As String
    Public user_id As String
    Public saldo As Double
    Public Operators As String = "uknown"
    'Public variables
    Public Conn As SqlConnection
    Public Da As SqlDataAdapter
    Public Ds As DataSet
    Public Dt As DataTable = New DataTable()
    Public Rd As SqlDataReader
    Public Cmd As SqlCommand
    Public ConnStr As String
    'Login Session Variables "DO NOT TOUCH!"
    Public ipAddres As String
    Public hostname As String
    Public extIp As String
    'Fungsi Logout
    Public Sub ResetSession()
        Form_Menu.Hide()
        Form_User_Profile.Hide()
        Form_Transaksi.Hide()
        Form_Deposit.Hide()
        Form_CS.Hide()
        Form_Login.TextBox1.Text = ""
        Form_Login.TextBox2.Text = ""
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
        username = ""
        _username_ = ""
        user_id = ""
        Operators = "uknown"
        type = ""
        Form_Login.Show()
    End Sub
    'Connection String bisa di ganti sesuai database
    Public Sub Koneksi()
        'Ganti Value NamaServer dan NamaDB anda sesuai database
        Try
            Dim ServerName As String = "RANGGA\SQLEXPRESS"
            ConnStr = "Data Source=" & ServerName & ";Initial Catalog=DB_PULSA;Integrated Security=True;MultipleActiveResultSets=True;"
            Conn = New SqlConnection(ConnStr)
            If Conn.State = ConnectionState.Closed Then Conn.Open()
        Catch exs As Exception
            If exs.Message = "System.Data.SqlClient.SqlException" Then
                MsgBox("Harap install Sql Server 2019 atau Kebawah dan SSMS 18.4 Kebawah terlebih dahulu untuk menjalankan aplikasi ini!")
            Else
                MsgBox(exs.ToString())
            End If
        End Try
    End Sub
    'Fungsi selamat pagi, siang, dan malam
    Public Function Good() As String
        Dim jam As String = DateTime.Now.ToString("HH")
        Dim hasil As String = "Tidak Ada"
        If jam >= 1 And jam < 11 Then
            hasil = "Pagi"
            Return hasil
        ElseIf jam >= 11 And jam < 15 Then
            hasil = "Siang"
            Return hasil
        ElseIf jam >= 15 And jam < 19 Then
            hasil = "Sore"
            Return hasil
        ElseIf jam >= 19 And jam < 24 Then
            hasil = "Malam"
            Return hasil
        End If
        Return hasil
    End Function
    'Fungsi Masukan Session
    Public Sub InsertSession()
        Try
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
            Koneksi()
            Cmd = New SqlCommand("select username from tbl_session_user where username='" & username & "'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            Dim dt As String = DateTime.Now.ToString("yyyy/MM/dd")
            If Rd.HasRows Then
                Koneksi()
                Dim strz As String = "update tbl_session_user set tanggal='" & DateTime.Parse(dt) & "', waktu_tersisa='" & DateTime.Now.ToString("HH:mm:ss") & "', hostname='" & hostname & "', LocalIP='" & ipAddres & "', ExternalIP='" & extIp & "',username='" & username & "' where username='" & username & "'"
                Cmd = New SqlCommand(strz, Conn)
                Cmd.ExecuteNonQuery()
            Else
                Koneksi()
                Dim str As String = "insert into tbl_session_user values('" & hostname & "','" & ipAddres & "','" & extIp & "','" & username & "','" & DateTime.Parse(dt) & "','" & DateTime.Now.ToString("HH:mm:ss") & "')"
                Cmd = New SqlCommand(str, Conn)
                Cmd.ExecuteNonQuery()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub
    'Fungsi IpAddres
    Sub GetIpAddres()
        Try
            Using sr As New StreamReader(Application.StartupPath + "\settings.ini")
                Dim lines = sr.ReadLine()
                If lines IsNot Nothing Then
                    _username_ = Decrypt(lines)
                End If
            End Using
            hostname = Dns.GetHostName()
                Dim iphe As IPHostEntry = Dns.GetHostEntry(hostname)
                For Each ipheal As IPAddress In iphe.AddressList
                    If ipheal.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
                        ipAddres = ipheal.ToString()
                    End If
                Next
                Dim ExternalIp As String
            ExternalIp = (New WebClient()).DownloadString("http://checkip.dyndns.org/")
            ExternalIp = (New Regex("\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}")) _
                         .Matches(ExternalIp)(0).ToString()
            extIp = ExternalIp
        Catch ex As WebException
            extIp = "0.0.0.0"
        End Try
    End Sub
    'Fungsi enkripsi teks
    Public Function Encrypt(clearText As String) As String
        Dim EncryptionKey As String = "MAKV2SPBNI99212"
        Dim clearBytes As Byte() = Encoding.Unicode.GetBytes(clearText)
        Using encryptor As Aes = Aes.Create()
            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D,
         &H65, &H64, &H76, &H65, &H64, &H65,
         &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write)
                    cs.Write(clearBytes, 0, clearBytes.Length)
                    cs.Close()
                End Using
                clearText = Convert.ToBase64String(ms.ToArray())
            End Using
        End Using
        Return clearText
    End Function
    'Fungsi dekripsi teks
    Public Function Decrypt(cipherText As String) As String
        Dim EncryptionKey As String = "MAKV2SPBNI99212"
        Dim cipherBytes As Byte() = Convert.FromBase64String(cipherText)
        Using encryptor As Aes = Aes.Create()
            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D,
         &H65, &H64, &H76, &H65, &H64, &H65,
         &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write)
                    cs.Write(cipherBytes, 0, cipherBytes.Length)
                    cs.Close()
                End Using
                cipherText = Encoding.Unicode.GetString(ms.ToArray())
            End Using
        End Using
        Return cipherText
    End Function
    'Fungsi cek email teks
    Public Function CekEmail(email As String) As String
        Dim at As Char = "@"
        If Not email.Contains(at) Then
            MsgBox("Email harus berisikan @!")
            Return email = "Salah"
        ElseIf Not email.Contains(at) Or Not email.Contains(".com") Or Not email.Contains(".id") Or Not email.Contains(".co.id") Or Not email.Contains(".co") Then
            MsgBox("Format email anda salah!")
            Return email = "Salah"
        ElseIf email.Length < 10 Then
            MsgBox("Email harus lebih dari 10 karakter!")
            Return email = "Salah"
        Else
            Return email
        End If
        Return email
    End Function
    'Fungsi baca image di database
    Public Function SelectImages(ByVal tabel As String, ByVal user_ids As String) As Image
        Koneksi()
        Dim Str As String = "select binary_foto from '" & tabel & "' where user_id='" & user_ids & "'"
        Da = New SqlDataAdapter(Str, Conn)
        Dim CmdB As New SqlCommandBuilder(Da)
        Da.Fill(Dt)
        Dim gambAr() As Byte = Dt.Rows(0).Item("binary_foto")
        Dim gambars As New MemoryStream(gambAr)
        Conn.Close()
        Return Image.FromStream(gambars)
    End Function
    'Fungsi Warna DataGridView
    Public Sub warnaDTG(ByVal rDataGridView As DataGridView)
        For Each iniRow As DataGridViewRow In rDataGridView.Rows
            For Each iniCell As DataGridViewCell In iniRow.Cells
                If iniRow.Index Mod 2 = 0 Then
                    iniCell.Style.BackColor = Color.AliceBlue
                Else
                    iniCell.Style.BackColor = Color.LightCoral
                End If
            Next
        Next
    End Sub
End Module