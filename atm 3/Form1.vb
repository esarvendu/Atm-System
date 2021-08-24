Imports System.Data.OleDb

Public Class Form1

    Dim cmd As New OleDb.OleDbCommand
    Dim sql As String
    Dim da As New OleDb.OleDbDataAdapter
    Dim dt As New DataTable
    Dim result As Integer
    Dim conn As OleDb.OleDbConnection = Myconnection()
    Public Function Myconnection() As OleDb.OleDbConnection
        Return New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\atm3.accdb")
    End Function

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        MMENU.Label3.Text = TextBox1.Text
        WWWITHDRAW.Label3.Text = TextBox1.Text


    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load



    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\atm3.accdb")

        sql = "SELECT * FROM tblteller WHERE P_PIN = " & _
                  Val(TextBox1.Text) & " "
        conn.Open()
        With cmd
            .Connection = conn
            .CommandText = sql

        End With
        da.SelectCommand = cmd
        da.Fill(dt)

        If dt.Rows.Count > 0 Then
            P_PIN = dt.Rows(0).Item(1)

            MsgBox("WELCOME")
            MMENU.Show()

            Me.Hide()


        Else

            MessageBox.Show("Invalid keyword!")
        End If
    End Sub
End Class
