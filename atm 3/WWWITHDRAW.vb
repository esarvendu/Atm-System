Public Class WWWITHDRAW
    Dim cmd As New OleDb.OleDbCommand
    Dim sql As String
    Dim da As New OleDb.OleDbDataAdapter
    Dim dt As New DataTable
    Dim result As Integer

    Dim conn As OleDb.OleDbConnection = Myconnection()
    Public Function Myconnection() As OleDb.OleDbConnection
        Return New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\atm3.accdb")
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        conn.Open()
        Try

            sql = "UPDATE tblteller SET D_DEPOSIT = D_DEPOSIT - " & Val(TextBox1.Text) & " WHERE P_PIN = " & Label3.Text
            'MsgBox(sql)
            da = New OleDb.OleDbDataAdapter(Sql, conn)
            dt = New DataTable
            da.Fill(dt)

            MsgBox(" amount of ₱" & TextBox1.Text)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
        Label3.Text = MMENU.Label3.Text

    End Sub
End Class