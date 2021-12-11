<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCapturaUPCs
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCapturaUPCs))
        Me.Btn_Subir_Excel = New System.Windows.Forms.Button()
        Me.ExcelSubir = New System.Windows.Forms.OpenFileDialog()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Btn_Examinar = New System.Windows.Forms.Button()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Btn_Subir_Excel
        '
        Me.Btn_Subir_Excel.BackColor = System.Drawing.SystemColors.Control
        Me.Btn_Subir_Excel.BackgroundImage = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_Subir_Excel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Btn_Subir_Excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Subir_Excel.Location = New System.Drawing.Point(378, 137)
        Me.Btn_Subir_Excel.Name = "Btn_Subir_Excel"
        Me.Btn_Subir_Excel.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Subir_Excel.TabIndex = 0
        Me.Btn_Subir_Excel.UseVisualStyleBackColor = False
        '
        'ExcelSubir
        '
        Me.ExcelSubir.Filter = "Archivos Excel (*.xls) | *.xlsx"
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Location = New System.Drawing.Point(163, 42)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(218, 20)
        Me.TextBox1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(35, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Ruta del archivo:"
        '
        'Btn_Examinar
        '
        Me.Btn_Examinar.BackgroundImage = Global.SIRCO.My.Resources.Resources.new_20doc
        Me.Btn_Examinar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Btn_Examinar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Examinar.Location = New System.Drawing.Point(321, 137)
        Me.Btn_Examinar.Name = "Btn_Examinar"
        Me.Btn_Examinar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Examinar.TabIndex = 5
        Me.Btn_Examinar.UseVisualStyleBackColor = True
        '
        'Btn_Salir
        '
        Me.Btn_Salir.BackgroundImage = Global.SIRCO.My.Resources.Resources.door_out
        Me.Btn_Salir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Btn_Salir.Location = New System.Drawing.Point(435, 137)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Salir.TabIndex = 6
        Me.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Btn_Salir.UseVisualStyleBackColor = True
        '
        'frmCapturaUPCs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(500, 212)
        Me.Controls.Add(Me.Btn_Salir)
        Me.Controls.Add(Me.Btn_Examinar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Btn_Subir_Excel)
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmCapturaUPCs"
        Me.Text = "Subir Excel UPCs"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Btn_Subir_Excel As Button
    Friend WithEvents ExcelSubir As OpenFileDialog
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Btn_Examinar As Button
    Friend WithEvents Btn_Salir As Button
End Class
