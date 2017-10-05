<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.enviarbtn = New System.Windows.Forms.Button()
        Me.recibirbtn = New System.Windows.Forms.Button()
        Me.importarbtn = New System.Windows.Forms.Button()
        Me.exportarbtn = New System.Windows.Forms.Button()
        Me.agregarbtn = New System.Windows.Forms.Button()
        Me.output = New System.Windows.Forms.RichTextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.vaciarbtn = New System.Windows.Forms.Button()
        Me.exportar2 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pendlbl = New System.Windows.Forms.Label()
        Me.envlbl = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.reclbl = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.enviar20btn = New System.Windows.Forms.Button()
        Me.totaleslbl = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.reenviarbtn = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.OpenFileDialog2 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog2 = New System.Windows.Forms.SaveFileDialog()
        Me.verparsedbtn = New System.Windows.Forms.Button()
        Me.exportarrecibidosbtn = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'enviarbtn
        '
        Me.enviarbtn.Location = New System.Drawing.Point(12, 12)
        Me.enviarbtn.Name = "enviarbtn"
        Me.enviarbtn.Size = New System.Drawing.Size(75, 23)
        Me.enviarbtn.TabIndex = 0
        Me.enviarbtn.Text = "ENVIAR"
        Me.enviarbtn.UseVisualStyleBackColor = True
        '
        'recibirbtn
        '
        Me.recibirbtn.Location = New System.Drawing.Point(181, 12)
        Me.recibirbtn.Name = "recibirbtn"
        Me.recibirbtn.Size = New System.Drawing.Size(75, 23)
        Me.recibirbtn.TabIndex = 1
        Me.recibirbtn.Text = "RECIBIR"
        Me.recibirbtn.UseVisualStyleBackColor = True
        '
        'importarbtn
        '
        Me.importarbtn.Location = New System.Drawing.Point(880, 325)
        Me.importarbtn.Name = "importarbtn"
        Me.importarbtn.Size = New System.Drawing.Size(126, 23)
        Me.importarbtn.TabIndex = 2
        Me.importarbtn.Text = "IMPORTAR"
        Me.importarbtn.UseVisualStyleBackColor = True
        '
        'exportarbtn
        '
        Me.exportarbtn.Location = New System.Drawing.Point(880, 354)
        Me.exportarbtn.Name = "exportarbtn"
        Me.exportarbtn.Size = New System.Drawing.Size(148, 23)
        Me.exportarbtn.TabIndex = 3
        Me.exportarbtn.Text = "EXPORTAR"
        Me.exportarbtn.UseVisualStyleBackColor = True
        '
        'agregarbtn
        '
        Me.agregarbtn.Location = New System.Drawing.Point(429, 12)
        Me.agregarbtn.Name = "agregarbtn"
        Me.agregarbtn.Size = New System.Drawing.Size(75, 23)
        Me.agregarbtn.TabIndex = 4
        Me.agregarbtn.Text = "AGREGAR"
        Me.agregarbtn.UseVisualStyleBackColor = True
        '
        'output
        '
        Me.output.BackColor = System.Drawing.Color.Black
        Me.output.ForeColor = System.Drawing.Color.White
        Me.output.Location = New System.Drawing.Point(12, 325)
        Me.output.Name = "output"
        Me.output.ReadOnly = True
        Me.output.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.output.Size = New System.Drawing.Size(862, 206)
        Me.output.TabIndex = 5
        Me.output.Text = ""
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'SaveFileDialog1
        '
        '
        'vaciarbtn
        '
        Me.vaciarbtn.Location = New System.Drawing.Point(880, 383)
        Me.vaciarbtn.Name = "vaciarbtn"
        Me.vaciarbtn.Size = New System.Drawing.Size(148, 23)
        Me.vaciarbtn.TabIndex = 8
        Me.vaciarbtn.Text = "VACIAR DB"
        Me.vaciarbtn.UseVisualStyleBackColor = True
        '
        'exportar2
        '
        Me.exportar2.Location = New System.Drawing.Point(880, 412)
        Me.exportar2.Name = "exportar2"
        Me.exportar2.Size = New System.Drawing.Size(148, 23)
        Me.exportar2.TabIndex = 9
        Me.exportar2.Text = "EXPORTAR HISTORICO"
        Me.exportar2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(510, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "PENDIENTES:"
        '
        'pendlbl
        '
        Me.pendlbl.AutoSize = True
        Me.pendlbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pendlbl.Location = New System.Drawing.Point(587, 15)
        Me.pendlbl.Name = "pendlbl"
        Me.pendlbl.Size = New System.Drawing.Size(51, 17)
        Me.pendlbl.TabIndex = 11
        Me.pendlbl.Text = "Label2"
        '
        'envlbl
        '
        Me.envlbl.AutoSize = True
        Me.envlbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.envlbl.Location = New System.Drawing.Point(715, 15)
        Me.envlbl.Name = "envlbl"
        Me.envlbl.Size = New System.Drawing.Size(51, 17)
        Me.envlbl.TabIndex = 13
        Me.envlbl.Text = "Label2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(652, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "ENVIADOS:"
        '
        'reclbl
        '
        Me.reclbl.AutoSize = True
        Me.reclbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reclbl.Location = New System.Drawing.Point(846, 15)
        Me.reclbl.Name = "reclbl"
        Me.reclbl.Size = New System.Drawing.Size(51, 17)
        Me.reclbl.TabIndex = 15
        Me.reclbl.Text = "Label2"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(780, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "RECIBIDOS:"
        '
        'enviar20btn
        '
        Me.enviar20btn.Location = New System.Drawing.Point(93, 12)
        Me.enviar20btn.Name = "enviar20btn"
        Me.enviar20btn.Size = New System.Drawing.Size(82, 23)
        Me.enviar20btn.TabIndex = 16
        Me.enviar20btn.Text = "ENVIAR 20"
        Me.enviar20btn.UseVisualStyleBackColor = True
        '
        'totaleslbl
        '
        Me.totaleslbl.AutoSize = True
        Me.totaleslbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totaleslbl.Location = New System.Drawing.Point(968, 15)
        Me.totaleslbl.Name = "totaleslbl"
        Me.totaleslbl.Size = New System.Drawing.Size(51, 17)
        Me.totaleslbl.TabIndex = 18
        Me.totaleslbl.Text = "Label2"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(911, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "TOTALES:"
        '
        'reenviarbtn
        '
        Me.reenviarbtn.Location = New System.Drawing.Point(262, 12)
        Me.reenviarbtn.Name = "reenviarbtn"
        Me.reenviarbtn.Size = New System.Drawing.Size(161, 23)
        Me.reenviarbtn.TabIndex = 19
        Me.reenviarbtn.Text = "REENVIAR SIN RESPUESTA"
        Me.reenviarbtn.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.Location = New System.Drawing.Point(12, 41)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(1016, 278)
        Me.DataGridView1.TabIndex = 7
        '
        'OpenFileDialog2
        '
        Me.OpenFileDialog2.FileName = "OpenFileDialog2"
        '
        'SaveFileDialog2
        '
        '
        'verparsedbtn
        '
        Me.verparsedbtn.Location = New System.Drawing.Point(880, 441)
        Me.verparsedbtn.Name = "verparsedbtn"
        Me.verparsedbtn.Size = New System.Drawing.Size(148, 46)
        Me.verparsedbtn.TabIndex = 20
        Me.verparsedbtn.Text = "VER RECIBIDOS CLASIFICADOS"
        Me.verparsedbtn.UseVisualStyleBackColor = True
        '
        'exportarrecibidosbtn
        '
        Me.exportarrecibidosbtn.Location = New System.Drawing.Point(880, 493)
        Me.exportarrecibidosbtn.Name = "exportarrecibidosbtn"
        Me.exportarrecibidosbtn.Size = New System.Drawing.Size(148, 38)
        Me.exportarrecibidosbtn.TabIndex = 21
        Me.exportarrecibidosbtn.Text = "EXPORTAR RECIBIDOS CLASIFICADOS"
        Me.exportarrecibidosbtn.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.SMS_Massive_Sender.My.Resources.Resources.help
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button1.Location = New System.Drawing.Point(1005, 325)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(23, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1033, 543)
        Me.Controls.Add(Me.exportarrecibidosbtn)
        Me.Controls.Add(Me.verparsedbtn)
        Me.Controls.Add(Me.reenviarbtn)
        Me.Controls.Add(Me.totaleslbl)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.enviar20btn)
        Me.Controls.Add(Me.reclbl)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.envlbl)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.pendlbl)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.exportar2)
        Me.Controls.Add(Me.vaciarbtn)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.output)
        Me.Controls.Add(Me.agregarbtn)
        Me.Controls.Add(Me.exportarbtn)
        Me.Controls.Add(Me.importarbtn)
        Me.Controls.Add(Me.recibirbtn)
        Me.Controls.Add(Me.enviarbtn)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.ShowIcon = False
        Me.Text = "SMS Massive Sender"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents enviarbtn As Button
    Friend WithEvents recibirbtn As Button
    Friend WithEvents importarbtn As Button
    Friend WithEvents exportarbtn As Button
    Friend WithEvents agregarbtn As Button
    Friend WithEvents output As RichTextBox
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents Button1 As Button
    Friend WithEvents vaciarbtn As Button
    Friend WithEvents exportar2 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents pendlbl As Label
    Friend WithEvents envlbl As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents reclbl As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents enviar20btn As Button
    Friend WithEvents totaleslbl As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents reenviarbtn As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents OpenFileDialog2 As OpenFileDialog
    Friend WithEvents SaveFileDialog2 As SaveFileDialog
    Friend WithEvents verparsedbtn As Button
    Friend WithEvents exportarrecibidosbtn As Button
End Class
