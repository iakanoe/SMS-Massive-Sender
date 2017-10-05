Imports MySql.Data.MySqlClient
Public Class parsed
    Dim conexion As New MySqlConnection("server=192.168.5.100;user id=bykom;password=bykom;")
    Private Sub parsed_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim estadoconexionanterior As ConnectionState = Form1.conexion.State
        Try
            If estadoconexionanterior = ConnectionState.Open Then
                Dim da As New MySqlDataAdapter("SELECT * FROM test.testparsed", Form1.conexion)
                Dim dt As New DataTable
                da.Fill(dt)
                DataGridView1.DataSource = dt
            Else
                conexion.Open()
                Dim da As New MySqlDataAdapter("SELECT * FROM test.testparsed", conexion)
                Dim dt As New DataTable
                da.Fill(dt)
                DataGridView1.DataSource = dt
                conexion.Close()
            End If
        Catch ex As Exception
            MsgBox("Ha ocurrido un error.", vbExclamation, "ERROR")
        Me.Close()
        End Try
    End Sub
End Class