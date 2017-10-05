<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class add
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.telefonotxt = New System.Windows.Forms.TextBox()
        Me.mensajetxt = New System.Windows.Forms.TextBox()
        Me.agregarbtn = New System.Windows.Forms.Button()
        Me.cancelarbtn = New System.Windows.Forms.Button()
        Me.infobtn = New System.Windows.Forms.Button()
        Me.progbtn = New System.Windows.Forms.Button()
        Me.programabtn = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.clavetxt = New System.Windows.Forms.TextBox()
        Me.abonadotxt = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.s1txt = New System.Windows.Forms.TextBox()
        Me.p1txt = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.s2txt = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.p2txt = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Teléfono"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Mensaje"
        '
        'telefonotxt
        '
        Me.telefonotxt.Location = New System.Drawing.Point(68, 13)
        Me.telefonotxt.Name = "telefonotxt"
        Me.telefonotxt.Size = New System.Drawing.Size(100, 20)
        Me.telefonotxt.TabIndex = 2
        '
        'mensajetxt
        '
        Me.mensajetxt.Location = New System.Drawing.Point(67, 47)
        Me.mensajetxt.Multiline = True
        Me.mensajetxt.Name = "mensajetxt"
        Me.mensajetxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.mensajetxt.Size = New System.Drawing.Size(295, 113)
        Me.mensajetxt.TabIndex = 3
        '
        'agregarbtn
        '
        Me.agregarbtn.Location = New System.Drawing.Point(287, 166)
        Me.agregarbtn.Name = "agregarbtn"
        Me.agregarbtn.Size = New System.Drawing.Size(75, 23)
        Me.agregarbtn.TabIndex = 4
        Me.agregarbtn.Text = "Agregar"
        Me.agregarbtn.UseVisualStyleBackColor = True
        '
        'cancelarbtn
        '
        Me.cancelarbtn.Location = New System.Drawing.Point(206, 166)
        Me.cancelarbtn.Name = "cancelarbtn"
        Me.cancelarbtn.Size = New System.Drawing.Size(75, 23)
        Me.cancelarbtn.TabIndex = 5
        Me.cancelarbtn.Text = "Cancelar"
        Me.cancelarbtn.UseVisualStyleBackColor = True
        '
        'infobtn
        '
        Me.infobtn.Location = New System.Drawing.Point(390, 166)
        Me.infobtn.Name = "infobtn"
        Me.infobtn.Size = New System.Drawing.Size(93, 23)
        Me.infobtn.TabIndex = 6
        Me.infobtn.Text = "INFO"
        Me.infobtn.UseVisualStyleBackColor = True
        '
        'progbtn
        '
        Me.progbtn.Location = New System.Drawing.Point(489, 166)
        Me.progbtn.Name = "progbtn"
        Me.progbtn.Size = New System.Drawing.Size(93, 23)
        Me.progbtn.TabIndex = 7
        Me.progbtn.Text = "PROG"
        Me.progbtn.UseVisualStyleBackColor = True
        '
        'programabtn
        '
        Me.programabtn.Location = New System.Drawing.Point(588, 166)
        Me.programabtn.Name = "programabtn"
        Me.programabtn.Size = New System.Drawing.Size(93, 23)
        Me.programabtn.TabIndex = 8
        Me.programabtn.Text = "PROGRAMAR"
        Me.programabtn.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(369, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Clave"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(489, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Abonado"
        '
        'clavetxt
        '
        Me.clavetxt.Location = New System.Drawing.Point(409, 13)
        Me.clavetxt.MaxLength = 4
        Me.clavetxt.Name = "clavetxt"
        Me.clavetxt.Size = New System.Drawing.Size(46, 20)
        Me.clavetxt.TabIndex = 11
        Me.clavetxt.Text = "7764"
        '
        'abonadotxt
        '
        Me.abonadotxt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.abonadotxt.Location = New System.Drawing.Point(545, 13)
        Me.abonadotxt.MaxLength = 4
        Me.abonadotxt.Name = "abonadotxt"
        Me.abonadotxt.Size = New System.Drawing.Size(47, 20)
        Me.abonadotxt.TabIndex = 12
        Me.abonadotxt.Text = "0000"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(368, 50)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Server 1"
        '
        's1txt
        '
        Me.s1txt.Location = New System.Drawing.Point(421, 47)
        Me.s1txt.Name = "s1txt"
        Me.s1txt.Size = New System.Drawing.Size(259, 20)
        Me.s1txt.TabIndex = 14
        Me.s1txt.Text = "ram.dyndns.ws"
        '
        'p1txt
        '
        Me.p1txt.Location = New System.Drawing.Point(421, 73)
        Me.p1txt.MaxLength = 5
        Me.p1txt.Name = "p1txt"
        Me.p1txt.Size = New System.Drawing.Size(62, 20)
        Me.p1txt.TabIndex = 16
        Me.p1txt.Text = "8033"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(368, 76)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Puerto 1"
        '
        's2txt
        '
        Me.s2txt.Location = New System.Drawing.Point(421, 99)
        Me.s2txt.Name = "s2txt"
        Me.s2txt.Size = New System.Drawing.Size(259, 20)
        Me.s2txt.TabIndex = 18
        Me.s2txt.Text = "rambsasf.dyndns.org"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(368, 102)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Server 2"
        '
        'p2txt
        '
        Me.p2txt.Location = New System.Drawing.Point(421, 128)
        Me.p2txt.MaxLength = 5
        Me.p2txt.Name = "p2txt"
        Me.p2txt.Size = New System.Drawing.Size(62, 20)
        Me.p2txt.TabIndex = 20
        Me.p2txt.Text = "8033"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(368, 131)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Puerto 2"
        '
        'add
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 197)
        Me.Controls.Add(Me.p2txt)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.s2txt)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.p1txt)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.s1txt)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.abonadotxt)
        Me.Controls.Add(Me.clavetxt)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.programabtn)
        Me.Controls.Add(Me.progbtn)
        Me.Controls.Add(Me.infobtn)
        Me.Controls.Add(Me.cancelarbtn)
        Me.Controls.Add(Me.agregarbtn)
        Me.Controls.Add(Me.mensajetxt)
        Me.Controls.Add(Me.telefonotxt)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "add"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Agregar mensaje..."
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents telefonotxt As TextBox
    Friend WithEvents mensajetxt As TextBox
    Friend WithEvents agregarbtn As Button
    Friend WithEvents cancelarbtn As Button
    Friend WithEvents infobtn As Button
    Friend WithEvents progbtn As Button
    Friend WithEvents programabtn As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents clavetxt As TextBox
    Friend WithEvents abonadotxt As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents s1txt As TextBox
    Friend WithEvents p1txt As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents s2txt As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents p2txt As TextBox
    Friend WithEvents Label8 As Label
End Class
