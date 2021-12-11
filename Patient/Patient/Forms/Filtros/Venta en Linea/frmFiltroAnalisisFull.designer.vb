<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFiltroAnalisisFull
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
        Me.txt_estilon = New System.Windows.Forms.TextBox()
        Me.btn_aceptar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_marca = New System.Windows.Forms.TextBox()
        Me.txt_descripmarca = New System.Windows.Forms.TextBox()
        Me.dtp_FechaFin = New System.Windows.Forms.DateTimePicker()
        Me.dtp_FechaIni = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn_cancelar = New System.Windows.Forms.Button()
        Me.btn_limpiar = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Estilon:"
        '
        'txt_estilon
        '
        Me.txt_estilon.Location = New System.Drawing.Point(81, 12)
        Me.txt_estilon.Name = "txt_estilon"
        Me.txt_estilon.Size = New System.Drawing.Size(78, 20)
        Me.txt_estilon.TabIndex = 1
        '
        'btn_aceptar
        '
        Me.btn_aceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_aceptar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.btn_aceptar.Location = New System.Drawing.Point(357, 1)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(50, 50)
        Me.btn_aceptar.TabIndex = 5
        Me.btn_aceptar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Marca:"
        '
        'txt_marca
        '
        Me.txt_marca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_marca.Location = New System.Drawing.Point(81, 50)
        Me.txt_marca.Name = "txt_marca"
        Me.txt_marca.Size = New System.Drawing.Size(78, 20)
        Me.txt_marca.TabIndex = 2
        '
        'txt_descripmarca
        '
        Me.txt_descripmarca.Enabled = False
        Me.txt_descripmarca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_descripmarca.Location = New System.Drawing.Point(164, 50)
        Me.txt_descripmarca.Name = "txt_descripmarca"
        Me.txt_descripmarca.Size = New System.Drawing.Size(165, 20)
        Me.txt_descripmarca.TabIndex = 4
        '
        'dtp_FechaFin
        '
        Me.dtp_FechaFin.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtp_FechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_FechaFin.Location = New System.Drawing.Point(123, 142)
        Me.dtp_FechaFin.Name = "dtp_FechaFin"
        Me.dtp_FechaFin.Size = New System.Drawing.Size(99, 20)
        Me.dtp_FechaFin.TabIndex = 4
        Me.dtp_FechaFin.Value = New Date(2020, 11, 10, 0, 0, 0, 0)
        '
        'dtp_FechaIni
        '
        Me.dtp_FechaIni.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtp_FechaIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_FechaIni.Location = New System.Drawing.Point(123, 95)
        Me.dtp_FechaIni.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.dtp_FechaIni.Name = "dtp_FechaIni"
        Me.dtp_FechaIni.Size = New System.Drawing.Size(99, 20)
        Me.dtp_FechaIni.TabIndex = 3
        Me.dtp_FechaIni.Value = New Date(2020, 11, 10, 0, 0, 0, 0)
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 142)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 17)
        Me.Label3.TabIndex = 103
        Me.Label3.Text = "Fecha Final:"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 17)
        Me.Label4.TabIndex = 104
        Me.Label4.Text = "Fecha Inicial:"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.btn_cancelar)
        Me.Panel1.Controls.Add(Me.btn_limpiar)
        Me.Panel1.Controls.Add(Me.btn_aceptar)
        Me.Panel1.Location = New System.Drawing.Point(3, 209)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(412, 56)
        Me.Panel1.TabIndex = 105
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cancelar.Image = Global.SIRCO.My.Resources.Resources.dialog_close
        Me.btn_cancelar.Location = New System.Drawing.Point(0, 1)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(50, 50)
        Me.btn_cancelar.TabIndex = 7
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'btn_limpiar
        '
        Me.btn_limpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_limpiar.Image = Global.SIRCO.My.Resources.Resources.LIMPIAR_FILTROS
        Me.btn_limpiar.Location = New System.Drawing.Point(307, 1)
        Me.btn_limpiar.Name = "btn_limpiar"
        Me.btn_limpiar.Size = New System.Drawing.Size(50, 50)
        Me.btn_limpiar.TabIndex = 6
        Me.btn_limpiar.UseVisualStyleBackColor = True
        '
        'frmFiltroAnalisisFull
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(418, 270)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dtp_FechaFin)
        Me.Controls.Add(Me.dtp_FechaIni)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_descripmarca)
        Me.Controls.Add(Me.txt_marca)
        Me.Controls.Add(Me.txt_estilon)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(434, 308)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(434, 308)
        Me.Name = "frmFiltroAnalisisFull"
        Me.Text = "Filtro Analisis Full"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txt_estilon As TextBox
    Friend WithEvents btn_aceptar As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txt_marca As TextBox
    Friend WithEvents txt_descripmarca As TextBox
    Friend WithEvents dtp_FechaFin As DateTimePicker
    Friend WithEvents dtp_FechaIni As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btn_cancelar As Button
    Friend WithEvents btn_limpiar As Button
End Class
