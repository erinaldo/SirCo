<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCargarFirmasDistrib
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCargarFirmasDistrib))
        Me.PBar1 = New System.Windows.Forms.ProgressBar()
        Me.Btn_AceptarF = New System.Windows.Forms.Button()
        Me.Txt_RutaOrigen = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.sfdRuta = New System.Windows.Forms.SaveFileDialog()
        Me.SuspendLayout()
        '
        'PBar1
        '
        Me.PBar1.Location = New System.Drawing.Point(23, 106)
        Me.PBar1.Name = "PBar1"
        Me.PBar1.Size = New System.Drawing.Size(388, 23)
        Me.PBar1.TabIndex = 28
        '
        'Btn_AceptarF
        '
        Me.Btn_AceptarF.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_AceptarF.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_AceptarF.Location = New System.Drawing.Point(360, 144)
        Me.Btn_AceptarF.Name = "Btn_AceptarF"
        Me.Btn_AceptarF.Size = New System.Drawing.Size(51, 47)
        Me.Btn_AceptarF.TabIndex = 27
        Me.Btn_AceptarF.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_AceptarF.UseVisualStyleBackColor = True
        '
        'Txt_RutaOrigen
        '
        Me.Txt_RutaOrigen.Location = New System.Drawing.Point(90, 59)
        Me.Txt_RutaOrigen.Name = "Txt_RutaOrigen"
        Me.Txt_RutaOrigen.Size = New System.Drawing.Size(321, 20)
        Me.Txt_RutaOrigen.TabIndex = 26
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Ruta Firmas"
        '
        'sfdRuta
        '
        Me.sfdRuta.Filter = "Archivos Excel | *.xls"
        '
        'frmCargarFirmasDistrib
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(453, 205)
        Me.Controls.Add(Me.PBar1)
        Me.Controls.Add(Me.Btn_AceptarF)
        Me.Controls.Add(Me.Txt_RutaOrigen)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCargarFirmasDistrib"
        Me.Text = "frmCargarFirmasDistrib"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PBar1 As ProgressBar
    Friend WithEvents Btn_AceptarF As Button
    Friend WithEvents Txt_RutaOrigen As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents sfdRuta As SaveFileDialog
End Class
