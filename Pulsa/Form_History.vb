Imports System.Data.SqlClient
Imports System.Text

Public Class Form_History
    Private Sub Form_History_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        warnaDTG(DataGridView1)
        Try
            Koneksi()
            Dim str As String = "SELECT * FROM [DB_PULSA].[dbo].[TBL_HISTORY_USER] WHERE ID NOT IN ( SELECT MAX(ID) FROM [DB_PULSA].[dbo].[TBL_HISTORY_USER] GROUP BY [nomor_history],[user_id]);"
            Cmd = New SqlCommand(str, Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            Koneksi()
            Dim strs As String = "DELETE FROM [DB_PULSA].[dbo].[TBL_HISTORY_USER] WHERE ID NOT IN (SELECT MAX(ID) AS MaxRecordID FROM [DB_PULSA].[dbo].[TBL_HISTORY_USER] GROUP BY [nomor_history],[user_id]);"
            Cmd = New SqlCommand(strs, Conn)
            Cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
        Muncul()
    End Sub

    Sub Muncul()
        Koneksi()
        Da = New SqlDataAdapter("select nomor_history from tbl_history_user where user_id='" & user_id & "'", Conn)
        Ds = New DataSet
        Ds.Clear()
        Da.Fill(Ds, "History")
        DataGridView1.DataSource = Ds.Tables("History")
        DataGridView1.ReadOnly = True
        Dim dtr = New DataGridViewColumn
        dtr = DataGridView1.Columns.Item(0)
        dtr.HeaderText = "History Nomor Terakhir"
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            Dim index As Integer
            Dim ast As String
            index = e.RowIndex
            Dim selectedrow As DataGridViewRow
            selectedrow = DataGridView1.Rows(index)
            ast = selectedrow.Cells(0).Value.ToString()
            Dim sb As StringBuilder = New StringBuilder()
            sb.Append(ast)
            sb.Insert(0, "0")
            ast = sb.ToString()
            Form_Transaksi.TextBox1.Text = ast
            Form_Transaksi.ComboBox1.Enabled = True
            Form_Transaksi.LBLTotalBayar.Text = "Rp 0"
            Me.Hide()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        warnaDTG(DataGridView1)
        Try
            Koneksi()
            Dim str As String = "SELECT * FROM [DB_PULSA].[dbo].[TBL_HISTORY_USER] WHERE ID NOT IN ( SELECT MAX(ID) FROM [DB_PULSA].[dbo].[TBL_HISTORY_USER] GROUP BY [nomor_history],[user_id]);"
            Cmd = New SqlCommand(str, Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            Dim strs As String = "DELETE FROM [DB_PULSA].[dbo].[TBL_HISTORY_USER] WHERE ID NOT IN (SELECT MAX(ID) AS MaxRecordID FROM [DB_PULSA].[dbo].[TBL_HISTORY_USER] GROUP BY [nomor_history],[user_id]);"
            Cmd = New SqlCommand(strs, Conn)
            Cmd.ExecuteNonQuery(
                )
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub
End Class