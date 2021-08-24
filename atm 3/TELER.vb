Public Class TELER
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

    Private Sub TELER_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        sql = "Select * from tblteller where P_PIN like '%" & TextBox1.Text & "%'"

        dt = New DataTable
        conn.Open()
        Try

            da = New OleDb.OleDbDataAdapter(Sql, conn)
            da.Fill(dt)
            DataGridView1.DataSource = dt

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try
        conn.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        dt = New DataTable

        Try
            sql = "UPDATE tblteller SET P_PIN='" & TextBox5.Text & "',ACCOUNT_TYPE= '" & ComboBox1.Text & "',D_DEPOSIT='" & TextBox4.Text & "' WHERE ID=" & Me.Text

            ' WHERE(studID = " & Me.Text")
            conn.Open()
            With cmd
                .CommandText = sql
                .Connection = conn
            End With

            result = cmd.ExecuteNonQuery
            If result > 0 Then
                MsgBox("NEW DEPOSIT HAS BEEN UPDATED!")
                conn.Close()
                Call TELER_Load(sender, e)
                ' cleartextfields()

            Else
                MsgBox("NO DEPOSIT HASS BEEN UPDATDD!")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()


        End Try
    End Sub
    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Me.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString
        ComboBox1.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString
        ' TextBox1.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
        TextBox5.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
        TextBox3.Text = DataGridView1.CurrentRow.Cells(4).Value.ToString

    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        TextBox4.Text = Val(TextBox2.Text) + Val(TextBox3.Text)
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class