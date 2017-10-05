Imports System.IO
Imports System.Web
Imports ClosedXML.Excel
Imports MySql.Data.MySqlClient
Public Class Form1
    Public conexion As New MySqlConnection("server=192.168.5.100;user id=root;password=654321;")
    Dim exportartodo As Boolean
    Function sendsms(mensaje As String, numsend As String) As Boolean
        mensaje = (HttpUtility.UrlEncode(mensaje)).Replace("%20", "+")
        Dim clientito As Net.WebRequest = Net.WebRequest.Create("http://192.168.5.228/cgi-bin/exec?cmd=api_queue_sms&username=lyric_api&password=adriancito&content=" & mensaje & "&destination=" & numsend & "&api_version=0.08&channel=8")
        clientito.UseDefaultCredentials = False
        Dim cred As New Net.NetworkCredential("admin", "admin")
        clientito.Credentials = cred
        Dim respuesta As Net.WebResponse = clientito.GetResponse
        Dim ds As Stream = respuesta.GetResponseStream
        Dim lector As New StreamReader(ds)
        Dim total As String = lector.ReadToEnd
        total = Mid$(total, 14, 5)
        If total = "true," Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub enviar() Handles enviarbtn.Click
        enviarbtn.Enabled = False
        output.AppendText(Now.ToString("[dd/MM/yyyy HH:mm:ss]: ") & "Obteniendo SMS de la base de datos..." & vbCrLf)
        conexion.Open()
        Dim da As New MySqlDataAdapter("SELECT ID, TELEFONO, MENSAJE FROM test.test1 WHERE ENV='N' AND BORRADO='N'", conexion)
        Dim ds As New DataSet
        da.Fill(ds)
        conexion.Close()
        Dim filas As DataRowCollection = ds.Tables(0).Rows
        output.AppendText(Now.ToString("[dd/MM/yyyy HH:mm:ss]: ") & "Enviando SMS..." & vbCrLf)
        For Each fila As DataRow In filas
            Dim bool As Boolean
            'Try
            If IsDBNull(fila.Item(2)) = False Then
                bool = sendsms(fila.Item(2), fila.Item(1))
            Else
                bool = False
            End If
            'Catch a As Exception
            'End Try
            If bool = True Then
                conexion.Open()
                output.AppendText(Now.ToString("[dd/MM/yyyy HH:mm:ss]: ") & "SMS """ & fila.Item(2) & """ enviado a " & fila.Item(1) & "." & vbCrLf)
                Dim cmd As New MySqlCommand("UPDATE test.test1 SET ENV='Y', ENV_FECHA='" & Now.ToString("yyyy-MM-dd HH:mm:ss") & "' WHERE ID=" & fila.Item(0) & "", conexion)
                cmd.ExecuteNonQuery()
                conexion.Close()
            Else
                output.AppendText(Now.ToString("[dd/MM/yyyy HH:mm:ss]: ") & "El SMS """ & fila.Item(2) & """ para " & fila.Item(1) & " no ha podido ser enviado." & vbCrLf)
            End If
            Threading.Thread.Sleep(20000)
        Next
        leertodo()
        enviarbtn.Enabled = True
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        output.AppendText(Now.ToString("[dd/MM/yyyy HH:mm:ss]: ") & "SMS Massive Sender iniciado." & vbCrLf)
        leertodo(False, True)
    End Sub
    Private Sub importarbtn_Click(sender As Object, e As EventArgs) Handles importarbtn.Click
        importarbtn.Enabled = False
        OpenFileDialog1.Title = "Importar archivo..."
        OpenFileDialog1.Multiselect = False
        OpenFileDialog1.Filter = "Archivo de excel (*.xlsx)|*.xlsx"
        OpenFileDialog1.ShowDialog()
        importarbtn.Enabled = True
    End Sub
    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Dim wb As New XLWorkbook(OpenFileDialog1.FileName)
        Dim ws As IXLWorksheet = wb.Worksheet(1)
        Dim firstRowUsed As IXLRow = ws.FirstRowUsed()
        Dim linea = firstRowUsed.RowUsed
        Dim tabla As New DataTable()
        tabla.Columns().Add("TELEFONO")
        tabla.Columns().Add("MENSAJE")
        linea = linea.RowBelow
        Do While linea.CellsUsed.Count > 0
            tabla.Rows.Add({linea.FirstCellUsed.Value, linea.LastCellUsed.Value})
            linea = linea.RowBelow
        Loop
        conexion.Open()
        For Each row As DataRow In tabla.Rows
            Dim cmd As New MySqlCommand("INSERT INTO test.test1 (TELEFONO, MENSAJE) VALUES ('" & row.Item(0) & "', '" & row.Item(1) & "')", conexion)
            cmd.ExecuteNonQuery()
        Next
        MsgBox("Mensajes importados correctamente.", vbInformation)
        output.AppendText(Now.ToString("[dd/MM/yyyy HH:mm:ss]: ") & "Mensajes importados correctamente." & vbCrLf)
        conexion.Close()
        leertodo()
    End Sub
    Sub importarviejo()
        Dim lines As String() = File.ReadAllLines(OpenFileDialog1.FileName)
        Dim tabla As New DataTable
        Dim cols As String() = lines.First.Split(";"c)
        For Each col As String In cols
            tabla.Columns.Add(New DataColumn(col))
        Next
        For i = 2 To lines.Count
            Dim itemss As String() = lines.ElementAt(i - 1).Split(";"c)
            Dim newrow As DataRow = tabla.Rows.Add()
            newrow.ItemArray = itemss
        Next
        conexion.Open()
        For Each row As DataRow In tabla.Rows
            Dim cmd As New MySqlCommand("INSERT INTO test.test1 (TELEFONO, MENSAJE) VALUES ('" & row.Item(0) & "', '" & row.Item(1) & "')", conexion)
            cmd.ExecuteNonQuery()
        Next
        MsgBox("Mensajes importados correctamente.", vbInformation)
        output.AppendText(Now.ToString("[dd/MM/yyyy HH:mm:ss]: ") & "Mensajes importados correctamente." & vbCrLf)
        conexion.Close()
        leertodo()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.Enabled = False
        MsgBox("El archivo a importar debe ser un archivo de excel (.XLSX) que SOLO contenga las columnas ""NUMERO"" y ""MENSAJE"" TAL CUAL como están escritas y en el MISMO orden.", MsgBoxStyle.OkOnly)
        Button1.Enabled = True
    End Sub
    Sub DataTable2CSV(table As DataTable, filename As String)
        Dim textollano As String = ""
        For i = 0 To table.Columns.Count - 1
            If i = table.Columns.Count - 1 Then
                textollano = textollano & table.Columns(i).ColumnName & vbCrLf
            Else
                textollano = textollano & table.Columns(i).ColumnName & ";"
            End If
        Next
        For k = 0 To table.Rows.Count - 1
            For j = 0 To table.Rows(k).ItemArray.Count - 1
                If j = table.Rows(k).ItemArray.Count - 1 Then
                    textollano = textollano & table.Rows(k).Item(j) & vbCrLf
                Else
                    textollano = textollano & table.Rows(k).Item(j) & ";"
                End If
            Next
        Next
        File.WriteAllText(filename, textollano)
    End Sub
    Private Sub exportarbtn_Click(sender As Object, e As EventArgs) Handles exportarbtn.Click
        exportarbtn.Enabled = False
        SaveFileDialog1.Title = "Exportar archivo..."
        SaveFileDialog1.OverwritePrompt = True
        SaveFileDialog1.Filter = "Archivo de excel (*.xlsx)|*.xlsx"
        SaveFileDialog1.AddExtension = True
        exportartodo = False
        SaveFileDialog1.ShowDialog()
        exportarbtn.Enabled = True
    End Sub
    Private Sub SaveFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk
        conexion.Open()
        Dim da As New MySqlDataAdapter
        If exportartodo Then
            da = New MySqlDataAdapter("SELECT * FROM test.test1 WHERE BORRADO='Y'", conexion)
        Else
            da = New MySqlDataAdapter("SELECT * FROM test.test1 WHERE BORRADO='N'", conexion)
        End If
        Dim ds As New DataSet
        da.Fill(ds)
        'DataTable2CSV(ds.Tables(0), SaveFileDialog1.FileName)
        Dim wb As New XLWorkbook()
        wb.AddWorksheet(ds.Tables(0))
        Dim fs As New FileStream(SaveFileDialog1.FileName, FileMode.Create)
        wb.SaveAs(fs)
        fs.Close()
        conexion.Close()
    End Sub
    Sub leertodo(Optional parseo As Boolean = False, Optional cargando As Boolean = False)
        Cursor = Cursors.AppStarting
        If cargando Then cargandovb.Show()
        output.AppendText(Now.ToString("[dd/MM/yyyy HH:mm:ss]: ") & "Leyendo base de datos..." & vbCrLf)
        Try
            conexion.Open()
            cargandovb.ProgressBar1.PerformStep()
            Dim da As New MySqlDataAdapter("SELECT TELEFONO, MENSAJE, ENV, ENV_FECHA, REC, REC_FECHA, REC_MENSAJE FROM test.test1 WHERE BORRADO='N'", conexion)
            Dim ds As New DataSet
            da.Fill(ds)
            cargandovb.ProgressBar1.PerformStep()
            cargandovb.ProgressBar1.PerformStep()
            cargandovb.ProgressBar1.PerformStep()
            DataGridView1.DataSource = ds.Tables(0)
            cargandovb.ProgressBar1.PerformStep()
            cargandovb.ProgressBar1.PerformStep()
            totaleslbl.Text = DataGridView1.Rows.Count
            da = New MySqlDataAdapter("SELECT TELEFONO FROM test.test1 WHERE ENV='N' AND REC='N' AND BORRADO='N'", conexion)
            ds = New DataSet
            da.Fill(ds)
            pendlbl.Text = ds.Tables(0).Rows.Count
            da = New MySqlDataAdapter("SELECT TELEFONO FROM test.test1 WHERE ENV='Y' AND BORRADO='N'", conexion)
            ds = New DataSet
            da.Fill(ds)
            cargandovb.ProgressBar1.PerformStep()
            envlbl.Text = ds.Tables(0).Rows.Count
            da = New MySqlDataAdapter("SELECT TELEFONO FROM test.test1 WHERE REC<>0 AND BORRADO='N'", conexion)
            ds = New DataSet
            cargandovb.ProgressBar1.PerformStep()
            cargandovb.ProgressBar1.PerformStep()
            da.Fill(ds)
            reclbl.Text = ds.Tables(0).Rows.Count
            output.AppendText(Now.ToString("[dd/MM/yyyy HH:mm:ss]: ") & "Base de datos leida correctamente." & vbCrLf)
        Catch ex As Exception
            output.AppendText(Now.ToString("[dd/MM/yyyy HH:mm:ss]: ") & "Base de datos vacia." & vbCrLf)
            pendlbl.Text = "0"
            envlbl.Text = "0"
            reclbl.Text = "0"
            totaleslbl.Text = "0"
            DataGridView1.DataSource = Nothing
        Finally
            conexion.Close()
            cargandovb.ProgressBar1.PerformStep()
            If cargando Then cargandovb.Close()
            If parseo Then parsear()
            Cursor = Cursors.Default
        End Try
    End Sub
    Sub parsear()
        'Try
        conexion.Open()
        For Each roww As DataGridViewRow In DataGridView1.Rows
            Dim dada As New MySqlDataAdapter("SELECT NUMERO FROM test.testparsed WHERE NUMERO=" & roww.Cells.Item(0).Value, conexion)
            Dim dt As New DataTable
            dada.Fill(dt)
            Dim cmdText As String
            Dim cmd As MySqlCommand
            If dt.Rows.Count = 0 Then
                cmdText = "INSERT INTO test.testparsed (NUMERO) VALUES ('" & roww.Cells.Item(0).Value & "')"
                cmd = New MySqlCommand(cmdText, conexion)
                cmd.ExecuteNonQuery()
            End If
            Dim da As New MySqlDataAdapter("SELECT ID FROM test.testparsed WHERE NUMERO='" & roww.Cells.Item(0).Value & "'", conexion)
            Dim ds As New DataTable
            da.Fill(ds)
            Dim id As Integer = CInt(ds.Rows(0).Item(0))
            If IsDBNull(roww.Cells.Item(6).Value) = False Then
                Dim datasinprocesar As String = roww.Cells.Item(6).Value.Replace("PROG#", "").Replace("INFO#", "").Replace("AVATEC#", "")
                Dim spliteo1 As Object() = datasinprocesar.Split(";"c)
                spliteo1 = limpiar(spliteo1)
                For i = 0 To UBound(spliteo1) - 1
                    Dim spliteo2 As String() = spliteo1(i).Replace(" ", "").Split(":"c)
                    Dim parametro, valor As String
                    If spliteo2.Count = 3 Then
                        parametro = spliteo2(1).Replace(" ", "")
                        valor = spliteo2(2).Replace(" ", "")
                    Else
                        parametro = spliteo2(0).Replace(" ", "")
                        valor = spliteo2(1).Replace(" ", "")
                    End If
                    dada = New MySqlDataAdapter("SELECT * FROM information_schema.COLUMNS WHERE column_name='" & parametro & "' AND table_name='testparsed' AND table_schema='test'", conexion)
                    dt = New DataTable
                    dada.Fill(dt)
                    'no obtiene bien las tablas corregir
                    If dt.Rows.Count = 0 Then
                        cmdText = "ALTER TABLE test.testparsed ADD COLUMN " & parametro & " TINYTEXT"
                        cmd = New MySqlCommand(cmdText, conexion)
                        cmd.ExecuteNonQuery()
                    ElseIf dt.Rows(0).Item(3) <> parametro
                        cmdText = "ALTER TABLE test.testparsed ADD COLUMN " & parametro & " TINYTEXT"
                        cmd = New MySqlCommand(cmdText, conexion)
                        cmd.ExecuteNonQuery()
                    End If
                    cmdText = "UPDATE test.testparsed SET " & parametro & "='" & valor & "' WHERE ID=" & id & ""
                    cmd = New MySqlCommand(cmdText, conexion)
                    cmd.ExecuteNonQuery()
                Next
            End If
        Next
        'conexion.Open()
        'Catch ex As Exception
        '   output.AppendText(Now.ToString("[dd/MM/yyyy HH:mm:ss]: ") & "ERROR." & vbCrLf)
        '  MsgBox(ex.ToString)
        'Finally
        If conexion.State = ConnectionState.Open Then conexion.Close()
        Cursor = Cursors.Default
        ' End Try
    End Sub
    Function limpiar(array As Object()) As Object()
        Dim lista As List(Of Object) = array.ToList
        lista.RemoveAll(Function(str) String.IsNullOrWhiteSpace(str))
        Return lista.ToArray
    End Function
    Private Sub vaciarbtn_Click(sender As Object, e As EventArgs) Handles vaciarbtn.Click
        vaciarbtn.Enabled = False
        Dim mb As MsgBoxResult = MsgBox("Está seguro de querer vaciar la base de datos?", vbOKCancel, "Confirmar vaciado")
        If mb = MsgBoxResult.Ok Then
            Try
                output.AppendText(Now.ToString("[dd/MM/yyyy HH:mm:ss]: ") & "Vaciando base de datos..." & vbCrLf)
                conexion.Open()
                Dim cmd As New MySqlCommand("UPDATE test.test1 SET BORRADO='Y' WHERE BORRADO='N'", conexion)
                cmd.ExecuteNonQuery()
                output.AppendText(Now.ToString("[dd/MM/yyyy HH:mm:ss]: ") & "Base de datos vaciada correctamente." & vbCrLf)
            Catch ex As Exception
                MsgBox("Error al vaciar la base de datos.", vbExclamation, "Error")
            Finally
                conexion.Close()
                leertodo()
            End Try
        End If
        vaciarbtn.Enabled = True
    End Sub
    Private Sub recibirbtn_Click(sender As Object, e As EventArgs) Handles recibirbtn.Click
        recibirbtn.Enabled = False
        Dim clientito As Net.WebRequest = Net.WebRequest.Create("http://192.168.5.228/cgi-bin/exec?cmd=api_get_number_recv_sms&username=lyric_api&password=adriancito&api_version=0.08")
        clientito.UseDefaultCredentials = False
        Dim cred As New Net.NetworkCredential("admin", "admin")
        clientito.Credentials = cred
        Dim respuesta As Net.WebResponse = clientito.GetResponse
        Dim ds As Stream = respuesta.GetResponseStream
        Dim lector As New StreamReader(ds)
        Dim total As String = lector.ReadToEnd
        Dim nummsg As Integer
        If Mid$(total, 14, 4) = "true" Then
            nummsg = CInt(Mid(total, 28, total.Length - 27 - 2))
            If nummsg <> 0 Then
                Dim nummsg2 As Integer = nummsg
                Do While nummsg2 > 0
                    Dim num As Integer
                    If nummsg2 > 10 Then
                        num = 10
                        clientito = Net.WebRequest.Create("http://192.168.5.228/cgi-bin/exec?cmd=api_recv_get_first_n&username=lyric_api&password=adriancito&api_version=0.08&n_regs=10&set_read=1")
                    Else
                        num = nummsg2
                        clientito = Net.WebRequest.Create("http://192.168.5.228/cgi-bin/exec?cmd=api_recv_get_first_n&username=lyric_api&password=adriancito&api_version=0.08&n_regs=" & nummsg2 & "&set_read=1")
                    End If
                    clientito.UseDefaultCredentials = False
                    cred = New Net.NetworkCredential("admin", "admin")
                    clientito.Credentials = cred
                    respuesta = clientito.GetResponse
                    ds = respuesta.GetResponseStream
                    lector = New StreamReader(ds)
                    total = lector.ReadToEnd
                    If Mid$(total, 14, 4) = "true" Then
                        total = Mid(total, total.IndexOf("["), total.LastIndexOf("]") - total.IndexOf("["))
                        output.AppendText(Now.ToString("[dd/MM/yyyy HH:mm:ss]: ") & nummsg & " mensajes recibidos." & vbCrLf)
                        'MsgBox(nummsg)
                        For j = 1 To num
                            Dim numini As Integer = total.IndexOf("{ ""id"": ")
                            Dim numlen As Integer = total.IndexOf(""" }") + 4
                            Dim mensaje As String = Mid$(total, numini, numlen - numini)
                            Dim totaltemp As String = Mid$(mensaje, mensaje.IndexOf("""id""") + 7)
                            Dim id As Integer = Mid$(totaltemp, 1, totaltemp.IndexOf(","))
                            totaltemp = Mid$(mensaje, mensaje.IndexOf("""recv_date""") + 15)
                            Dim recv_date As String = Mid$(totaltemp, 1, totaltemp.IndexOf(""""))
                            totaltemp = Mid$(mensaje, mensaje.IndexOf("""numorig""") + 13)
                            Dim numorig As String = Mid$(totaltemp, 1, totaltemp.IndexOf(""""))
                            totaltemp = Mid$(mensaje, mensaje.IndexOf("""message""") + 13)
                            Dim msg As String = Mid$(totaltemp, 1, totaltemp.IndexOf(""""))
                            totaltemp = Mid$(mensaje, mensaje.IndexOf("""channel""") + 12)
                            Dim channel As Integer = CInt(Strings.Left(totaltemp, 1))
                            If channel = 8 Then
                                buscarymarcar(recv_date, numorig, msg)
                            End If
                            If j < num Then
                                total = total.Remove(numini, (numlen - numini))
                            End If
                            Dim clientito2 As Net.WebRequest = Net.WebRequest.Create("http://192.168.5.228/cgi-bin/exec?cmd=api_sms_delete_by_id&username=lyric_api&password=adriancito&api_version=0.08&sms_dir=in&id=" & id.ToString())
                            clientito2.UseDefaultCredentials = False
                            Dim cred2 As New Net.NetworkCredential("admin", "admin")
                            clientito2.Credentials = cred2
                            Dim respuesta2 As Net.WebResponse = clientito2.GetResponse
                            Dim ds2 As Stream = respuesta2.GetResponseStream
                            Dim lector2 As New StreamReader(ds2)
                            Dim total2 As String = lector2.ReadToEnd
                            total2 = total2
                            'MsgBox(id)
                            'MsgBox(channel)
                            'MsgBox(recv_date)
                            'MsgBox(i)
                            'MsgBox(totaltemp)
                            'MsgBox(msg)
                            'MsgBox(numorig)
                            'MsgBox(mensaje)
                            'MsgBox(total)
                        Next
                        nummsg2 = nummsg2 - num
                    Else
                        output.AppendText(Now.ToString("[dd/MM/yyyy HH: mm:ss]: ") & "Ha ocurrido un error." & vbCrLf)
                    End If
                Loop
            Else
                output.AppendText(Now.ToString("[dd/MM/yyyy HH:mm:ss]: ") & "No hay mensajes nuevos." & vbCrLf)
            End If
        Else
            output.AppendText(Now.ToString("[dd/MM/yyyy HH:mm:ss]: ") & "Ha ocurrido un error." & vbCrLf)
        End If
        leertodo()
        recibirbtn.Enabled = True
    End Sub
    Sub buscarymarcar(recv_date As String, numorig As String, msg As String)
        numorig = numorig.Replace("+", Nothing)
        conexion.Open()
        Dim da As New MySqlDataAdapter("SELECT ID, TELEFONO FROM test.test1 WHERE ENV='Y' AND BORRADO='N'", conexion)
        Dim ds As New DataSet
        da.Fill(ds)
        conexion.Close()
        If ds.Tables(0).Rows.Count <> 0 Then
            Dim numeros(1, -1) As String
            For i = 0 To ds.Tables(0).Rows.Count - 1
                ReDim Preserve numeros(1, UBound(numeros, 2) + 1)
                numeros(1, UBound(numeros, 2)) = ds.Tables(0).Rows(i).Item(1)
                numeros(0, UBound(numeros, 2)) = ds.Tables(0).Rows(i).Item(0)
            Next
            Dim position As Integer = IsInArray(numorig, numeros)
            If position <> Nothing Then
                conexion.Open()
                Dim da2 As New MySqlDataAdapter("SELECT REC FROM test.test1 WHERE BORRADO='N' AND ID=" & position, conexion)
                Dim ds2 As New DataSet
                da2.Fill(ds2)
                Dim rec As Integer = CInt(ds2.Tables(0).Rows(0).Item(0)) + 1
                da2 = New MySqlDataAdapter("SELECT REC_MENSAJE FROM test.test1 WHERE BORRADO='N' AND ID=" & position, conexion)
                ds2 = New DataSet
                da2.Fill(ds2)
                Dim msg1 As String = ds2.Tables(0).Rows(0).Item(0) & msg
                Dim cmd As New MySqlCommand("UPDATE test.test1 SET REC=" & rec & ", REC_FECHA='" & recv_date & "', REC_MENSAJE='" & msg1 & "' WHERE ID=" & position & "", conexion)
                cmd.ExecuteNonQuery()
                conexion.Close()
            Else
                conexion.Open()
                Dim cmd As New MySqlCommand("INSERT INTO test.test1 (TELEFONO, REC, REC_FECHA, REC_MENSAJE) VALUES ('" & numorig.ToString() & "', 1, '" & recv_date & "', '" & msg & "')", conexion)
                cmd.ExecuteNonQuery()
                conexion.Close()
            End If
        Else
            conexion.Open()
            Dim cmd As New MySqlCommand("INSERT INTO test.test1 (TELEFONO, REC, REC_FECHA, REC_MENSAJE) VALUES ('" & numorig.ToString() & "', 1, '" & recv_date & "', '" & msg & "')", conexion)
            cmd.ExecuteNonQuery()
            conexion.Close()
        End If
    End Sub
    Function IsInArray(cadena As String, elarray As Object(,)) As String
        For i = 0 To UBound(elarray, 2)
            If elarray(1, i) = cadena Then Return elarray(0, i)
        Next
        'Return Nothing
        Dim a As Integer = UBound(elarray, 2)
        Return Nothing
    End Function
    Private Sub output_TextChanged(sender As Object, e As EventArgs) Handles output.TextChanged
        output.ScrollToCaret()
    End Sub
    Private Sub agregarbtn_Click(sender As Object, e As EventArgs) Handles agregarbtn.Click
        agregarbtn.Enabled = False
        Dim ventana As New add
        ventana.ShowDialog()
        leertodo()
        agregarbtn.Enabled = True
    End Sub
    Private Sub exportar2_Click(sender As Object, e As EventArgs) Handles exportar2.Click
        exportar2.Enabled = False
        SaveFileDialog1.Title = "Exportar archivo..."
        SaveFileDialog1.OverwritePrompt = True
        SaveFileDialog1.Filter = "Archivo de excel (*.xlsx)|*.xlsx"
        SaveFileDialog1.AddExtension = True
        exportartodo = True
        SaveFileDialog1.ShowDialog()
        exportar2.Enabled = True
    End Sub
    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles enviar20btn.Click
        enviar20btn.Enabled = False
        output.AppendText(Now.ToString("[dd/MM/yyyy HH:mm:ss]: ") & "Obteniendo SMS de la base de datos..." & vbCrLf)
        conexion.Open()
        Dim da As New MySqlDataAdapter("SELECT ID, TELEFONO, MENSAJE FROM test.test1 WHERE ENV='N' AND BORRADO='N' LIMIT 20", conexion)
        Dim ds As New DataSet
        da.Fill(ds)
        conexion.Close()
        Dim filas As DataRowCollection = ds.Tables(0).Rows
        output.AppendText(Now.ToString("[dd/MM/yyyy HH:mm:ss]: ") & "Enviando SMS..." & vbCrLf)
        For Each fila As DataRow In filas
            Dim bool As Boolean
            'Try
            If IsDBNull(fila.Item(2)) = False Then
                bool = sendsms(fila.Item(2), fila.Item(1))
            Else
                bool = False
            End If
            'Catch a As Exception
            'End Try
            If bool = True Then
                conexion.Open()
                output.AppendText(Now.ToString("[dd/MM/yyyy HH:mm:ss]: ") & "SMS """ & fila.Item(2) & """ enviado a " & fila.Item(1) & "." & vbCrLf)
                Dim cmd As New MySqlCommand("UPDATE test.test1 SET ENV='Y', ENV_FECHA='" & Now.ToString("yyyy-MM-dd HH:mm:ss") & "' WHERE ID=" & fila.Item(0) & "", conexion)
                cmd.ExecuteNonQuery()
                conexion.Close()
            Else
                output.AppendText(Now.ToString("[dd/MM/yyyy HH:mm:ss]: ") & "El SMS """ & fila.Item(2) & """ para " & fila.Item(1) & " no ha podido ser enviado." & vbCrLf)
            End If
        Next
        leertodo()
        enviar20btn.Enabled = True
    End Sub
    Private Sub reenviarbtn_Click(sender As Object, e As EventArgs) Handles reenviarbtn.Click
        reenviarbtn.Enabled = False
        conexion.Open()
        Dim cmd As New MySqlCommand("UPDATE test.test1 SET ENV='N', ENV_FECHA=NULL WHERE ENV='Y' AND REC=0", conexion)
        cmd.ExecuteNonQuery()
        conexion.Close()
        leertodo()
        reenviarbtn.Enabled = True
    End Sub
    Private Sub verparsedbtn_Click(sender As Object, e As EventArgs) Handles verparsedbtn.Click
        leertodo(True)
        parsed.ShowDialog()
    End Sub
    Private Sub exportarrecibidosbtn_Click(sender As Object, e As EventArgs) Handles exportarrecibidosbtn.Click
        exportarrecibidosbtn.Enabled = False
        SaveFileDialog2.Title = "Exportar archivo..."
        SaveFileDialog2.OverwritePrompt = True
        SaveFileDialog2.Filter = "Archivo de excel (*.xlsx)|*.xlsx"
        SaveFileDialog2.AddExtension = True
        SaveFileDialog2.ShowDialog()
    End Sub
    Private Sub SaveFileDialog2_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog2.FileOk
        leertodo(True)
        conexion.Open()
        Dim da As New MySqlDataAdapter
        da = New MySqlDataAdapter("SELECT * FROM test.testparsed", conexion)
        Dim ds As New DataSet
        da.Fill(ds)
        Dim wb As New XLWorkbook()
        wb.AddWorksheet(ds.Tables(0))
        Dim fs As New FileStream(SaveFileDialog2.FileName, FileMode.Create)
        wb.SaveAs(fs)
        fs.Close()
        conexion.Close()
        exportarrecibidosbtn.Enabled = True
    End Sub
End Class