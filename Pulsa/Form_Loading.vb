Public Class Form_Loading
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Form_Login.Hide()
        Dim i As Double
        Static ictr As Integer
        For i = 1 To 100
            Label2.Text = ProgressBar1.Value & "%"
        Next
        If ictr <= 100 Then
            ProgressBar1.Value = ictr
            ictr = ictr + 6
        Else
            Form_Menu.potoProfil()
            Form_Menu.LBLGood.Text = Good() + ", " + username + "!"
            Form_Menu.Label4.Text = username
            Form_Menu.LBLSaldo.Text = "Rp " + Convert.ToString(saldo)
            Form_Menu.Show()
            Me.Close()
        End If
    End Sub

    Private Sub Form_Loading_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form_Login.Hide()
    End Sub
End Class