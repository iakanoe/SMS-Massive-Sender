Imports System.Data.OleDb
Imports MySql.Data.MySqlClient
Public Class add
    Dim conexion As New MySqlConnection("server=192.168.5.100;user id=bykom;password=bykom;")
    Private Sub agregarbtn_Click(sender As Object, e As EventArgs) Handles agregarbtn.Click
        Dim cmd As New MySqlCommand("INSERT INTO test.test1 (TELEFONO, MENSAJE) VALUES ('" & telefonotxt.Text & "', '" & mensajetxt.Text & "')", conexion)
        Try
            conexion.Open()
            cmd.ExecuteNonQuery()
            MsgBox("Mensaje agregado a la base de datos.", vbInformation, "Exito")
        Catch ex As Exception
            MsgBox(ex.Message, vbExclamation, "Error")
        Finally
            conexion.Close()
            Me.Close()
        End Try
    End Sub
    Private Sub cancelarbtn_Click(sender As Object, e As EventArgs) Handles cancelarbtn.Click
        Me.Close()
    End Sub
    Private Sub infobtn_Click(sender As Object, e As EventArgs) Handles infobtn.Click
        mensajetxt.Text = "INFO#" & clavetxt.Text & "#"
    End Sub
    Private Sub progbtn_Click(sender As Object, e As EventArgs) Handles progbtn.Click
        mensajetxt.Text = "PROG#" & clavetxt.Text & "#"
    End Sub
    Private Sub programabtn_Click(sender As Object, e As EventArgs) Handles programabtn.Click
        mensajetxt.Text = "PROG#" & clavetxt.Text & "#;server1:" & s1txt.Text & ";port1:" & p1txt.Text & ";server2:" & s2txt.Text & ";port2:" & p2txt.Text & ";uid:" & abonadotxt.Text & ";"
    End Sub
End Class