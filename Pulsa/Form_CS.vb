Public Class Form_CS
    Dim MenuTerbuka As Boolean = False
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
            Button7.Show()
            Label1.Show()
            Label2.Show()
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
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ResetSession()
        ResetData()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Form_Deposit.Show()
        ResetData()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
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

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Form_Bug_Report.Show()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.Hide()
        Form_Live_Chat.Show()
        ResetData()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim str As String = "https://api.whatsapp.com/send?phone=6281297980063&text=*AnjayUI*%0AHai%20"
        Process.Start(str)
    End Sub

End Class