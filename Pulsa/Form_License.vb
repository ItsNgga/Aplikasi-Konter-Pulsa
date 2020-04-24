Imports System.IO

Public Class Form_License
    Private Sub Form_License_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim str As String
        Using TextReader As New StringReader(My.Resources.LICENSE)
            str = TextReader.ReadToEnd()
        End Using
        RichTextBox1.Text = str
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
    End Sub
End Class