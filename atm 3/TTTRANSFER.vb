Public Class TTTRANSFER
    Dim cmd As New OleDb.OleDbCommand
    Dim sql As String
    Dim da As New OleDb.OleDbDataAdapter
    Dim dt As New DataTable
    Dim result As Integer

    Dim conn As OleDb.OleDbConnection = Myconnection()
    Public Function Myconnection() As OleDb.OleDbConnection
        Return New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\atm3.accdb")
    End Function

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        conn.Open()
        Try

            sql = "UPDATE tblteller SET D_DEPOSIT = D_DEPOSIT - " & Val(TextBox1.Text) & " WHERE P_PIN = " & P_PIN
            da = New OleDb.OleDbDataAdapter(sql, conn)
            dt = New DataTable
            da.Fill(dt)

            MsgBox("Successfully transferred money to: " & Val(Label2.Text) & " and amount of ₱" & TextBox1.Text)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()

        conn.Open()
        Try
            sql = "UPDATE tblteller SET D_DEPOSIT = D_DEPOSIT + " & Val(TextBox1.Text) & " WHERE P_PIN = " & Val(Label2.Text)
            da = New OleDb.OleDbDataAdapter(sql, conn)
            dt = New DataTable
            da.Fill(dt)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class