Imports System.Data.SqlClient
Public Class Form_Menu
    Dim MenuTerbuka As Boolean = False
    Sub ResetData()
        Label4.Text = ""
        MenuTerbuka = False
        iconMenu()
        For i = 306 To 0 Step -6
            PanelMenu.Width = i
        Next
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
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        potoProfil()
        LBLGood.Text = Good() + ", " + username + "!"
        Label4.Text = username
        LBLSaldo.Text = "Rp " + Convert.ToString(saldo)
        If type = "VIP" Then
            PictureBox10.Visible = True
            Label11.Show()
        Else
            PictureBox10.Visible = False
            Label11.Hide()
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles CloseBox.Click
        Application.Exit()
    End Sub

    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs) Handles PictureBox1.Click
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
    Sub potoProfil()
        Try
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
                    PictureBox8.Image = Image.FromStream(gambars)
                ElseIf IsDBNull(Rd!url_foto) Then
                    PictureBox8.Image = My.Resources.uknown
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString())
        Finally
            Conn.Close()
        End Try
    End Sub

    Private Sub Form_Menu_Load(sender As Object, e As EventArgs)
        iconMenu()
        ResetData()
        Koneksi()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ResetSession()
        ResetData()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Form_User_Profile.Show()
        ResetData()
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

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Hide()
        Form_CS.Show()
        ResetData()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MenuTerbuka = False
        iconMenu()
        For i = 306 To 0 Step -6
            PanelMenu.Width = i
        Next
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Form_Bug_Report.Show()
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

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click, Panel7.Click, PictureBox11.Click, Label6.Click, Label14.Click
        Button8.BringToFront()
        Me.Hide()
        Form_User_Profile.Show()
        Button8.SendToBack()
        ResetData()
    End Sub


    Private Sub Panel9_Click(sender As Object, e As EventArgs) Handles Panel9.Click, PictureBox13.Click, Label7.Click, Label16.Click
        Me.Hide()
        Form_Deposit.Show()
        ResetData()
    End Sub

    Private Sub Panel10_Click(sender As Object, e As EventArgs) Handles Panel10.Click, PictureBox14.Click, Label8.Click, Label17.Click
        Me.Hide()
        Form_Bug_Report.Show()
        ResetData()
    End Sub

    Private Sub Panel11_Click(sender As Object, e As EventArgs) Handles Panel11.Click, PictureBox15.Click, Label18.Click, Label10.Click
        Me.Hide()
        Form_CS.Show()
        ResetData()
    End Sub

    Private Sub Panel12_Click(sender As Object, e As EventArgs) Handles Panel12.Click, PictureBox16.Click, Label19.Click, Label13.Click
        Dim str As String = MsgBox("Apakah anda yakin ingin Logout?", vbYesNo)
        If str = vbYes Then
            ResetSession()
            ResetData()
        Else
        End If
    End Sub

    Private Sub Panel8_Click_1(sender As Object, e As EventArgs) Handles PictureBox12.Click, Panel8.Click, Label5.Click, Label15.Click
        Me.Hide()
        Form_Transaksi.Show()
        ResetData()
    End Sub

End Class