Imports System.Data.SqlClient
Public Class Form_Live_Chat
    Dim no_send As Integer = 0
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Hide()
        Form_CS.Show()
    End Sub

    Private Sub Form_Live_Chat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Muncul()
        LBLUser1.Text = username
        LBLUser2.Text = username
        LBLUser3.Text = username
    End Sub
    Sub Muncul()
        Try
            Call Koneksi()
            Cmd = New SqlCommand("select no_live_chat from tbl_live_chat where no_live_chat in (select max(no_live_chat) from tbl_live_chat)", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            Dim substrs As String = Format(Rd!no_live_chat).Substring(4, 6)
            If Not substrs = Format(Now, "ddMMyy") Then
                Rd.Close()
                Call Koneksi()
                Cmd = New SqlCommand("select no_live_chat from tbl_live_chat where no_live_chat in (select max(no_live_chat) from tbl_live_chat)", Conn)
                Dim UrutanKode As String
                Dim Hitung As Double
                Rd = Cmd.ExecuteReader
                Rd.Read()
                If Not Rd.HasRows Then
                    UrutanKode = "LIVE" + Format(Now, "ddMMyy") + "001"
                Else
                    Hitung = Microsoft.VisualBasic.Right(Rd.GetString(0), 9) + 1
                    UrutanKode = "LIVE" + Format(Now, "ddMMyy") + Microsoft.VisualBasic.Right("000" & Hitung, 3)
                End If
                NoLive.Text = UrutanKode.ToString()
                Rd.Close()
                Koneksi()
                Dim Adm As String = "ADM001"
                Dim str As String = "insert into tbl_live_chat (no_live_chat, admin_id, user_id, MsgAdmin1, status_kirim) values('" & UrutanKode & "','" & Adm & "','" & user_id & "','" & MsgAdmin1.Text & "','" & "PENDING" & "')"
                Cmd = New SqlCommand(str, Conn)
                Cmd.ExecuteNonQuery()
                Koneksi()
                Dim strse As String = "update tbl_kirim_pesan set no_live_chat='" & NoLive.Text & "',status_kirim='" & "PENDING" & "', pesan='" & MsgAdmin1.Text & "', nama_pesan='" & "MsgAdmin1" & "', no_send='" & 1 & "'"
                Cmd = New SqlCommand(strse, Conn)
                Cmd.ExecuteNonQuery()
            Else
                NoLive.Text = Rd!no_live_chat
                Rd.Close()
                Call Koneksi()
                Cmd = New SqlCommand("select no_send from tbl_kirim_pesan where no_live_chat='" & NoLive.Text & "'", Conn)
                Rd = Cmd.ExecuteReader
                Rd.Read()
                If Rd.HasRows Then
                    no_send = Rd!no_send
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub
    Sub CekPesan()
        Try
            Koneksi()
            Cmd = New SqlCommand("select * from tbl_live_chat where no_live_chat='" & NoLive.Text & "'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Rd.HasRows Then
                If Not IsDBNull(Rd!MsgUser1) And no_send = 1 Then
                    MsgUser1.Text = Rd!MsgUser1
                End If
                If Not IsDBNull(Rd!MsgUser2) And no_send = 2 Then
                    MsgUser2.Text = Rd!MsgUser2
                End If
                If Not IsDBNull(Rd!MsgUser3) And no_send = 3 Then
                    MsgUser3.Text = Rd!MsgUser3
                End If
                If Not IsDBNull(Rd!MsgAdmin1) Then
                    MsgAdmin1.Text = Rd!MsgAdmin1
                    LBLAdmin1.Visible = True
                    MsgAdmin1.Visible = True
                End If
                If Not IsDBNull(Rd!MsgAdmin2) Then
                    MsgAdmin2.Text = Rd!MsgAdmin2
                    LBLAdmin2.Visible = True
                    MsgAdmin2.Visible = True
                End If
                If Not IsDBNull(Rd!MsgAdmin3) Then
                    MsgAdmin3.Text = Rd!MsgAdmin3
                    LBLAdmin3.Visible = True
                    MsgAdmin3.Visible = True
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        CekPesan()
    End Sub
    Sub kirimPesan(ByVal pesan As String, ByVal nama_pesan As String)
        Koneksi()
        Try
            no_send = no_send + 1
            If no_send = 4 Then
                no_send = 1
            End If
            Dim Str As String = "update tbl_kirim_pesan set no_live_chat='" & NoLive.Text & "', pesan='" & pesan & "', nama_pesan='" & nama_pesan & "', no_send= '" & no_send & "'"
            Cmd = New SqlCommand(Str, Conn)
            Cmd.ExecuteNonQuery()
            Dim strs As String = "update tbl_live_chat set " & nama_pesan & "='" & pesan & "' where no_live_chat='" & NoLive.Text & "'"
            Cmd = New SqlCommand(strs, Conn)
            Cmd.ExecuteNonQuery()
            MsgBox("Kirim Pesan Berhasil!")
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Private Sub TombolKirim_Click(sender As Object, e As EventArgs) Handles TombolKirim.Click
        Koneksi()
        Cmd = New SqlCommand("Select * from tbl_live_chat where no_live_chat='" & NoLive.Text & "'", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Rd.HasRows Then
            If IsDBNull(Rd!MsgUser1) Then
                MsgUser1.Text = MessageBox.Text
                LBLUser1.Visible = True
                MsgUser1.Visible = True
                kirimPesan(MsgUser1.Text, "MsgUser1")
                MessageBox.Text = ""
            ElseIf IsDBNull(Rd!MsgUser2) Then
                MsgUser2.Text = MessageBox.Text
                LBLUser2.Visible = True
                MsgUser2.Visible = True
                kirimPesan(MsgUser2.Text, "MsgUser2")
                MessageBox.Text = ""
            ElseIf IsDBNull(Rd!MsgUser3) Then
                MsgUser3.Text = MessageBox.Text
                LBLUser3.Visible = True
                MsgUser3.Visible = True
                kirimPesan(MsgUser3.Text, "MsgUser3")
                MessageBox.Text = ""
            ElseIf no_send = 1 Then
                MsgUser1.Text = MessageBox.Text
                LBLUser1.Visible = True
                MsgUser1.Visible = True
                LBLUser2.Visible = False
                MsgUser2.Visible = False
                LBLUser3.Visible = False
                MsgUser3.Visible = False
                kirimPesan(MsgUser1.Text, "MsgUser1")
                MessageBox.Text = ""
            ElseIf no_send = 2 Then
                MsgUser2.Text = MessageBox.Text
                LBLUser2.Visible = True
                MsgUser2.Visible = True
                LBLUser3.Visible = False
                MsgUser3.Visible = False
                kirimPesan(MsgUser2.Text, "MsgUser2")
                MessageBox.Text = ""
            ElseIf no_send = 3 Then
                MsgUser3.Text = MessageBox.Text
                LBLUser3.Visible = True
                MsgUser3.Visible = True
                kirimPesan(MsgUser3.Text, "MsgUser3")
                MessageBox.Text = ""
            End If
        End If

    End Sub
End Class