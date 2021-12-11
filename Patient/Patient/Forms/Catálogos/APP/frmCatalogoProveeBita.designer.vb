<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCatalogoProveeBita
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCatalogoProveeBita))
        Me.Pnl_Botones = New System.Windows.Forms.Panel()
        Me.Btn_Cancelar = New System.Windows.Forms.Button()
        Me.Btn_Aceptar = New System.Windows.Forms.Button()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.Tbc_Proveedores = New System.Windows.Forms.TabControl()
        Me.Tp_Generales = New System.Windows.Forms.TabPage()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_DescripMarca = New System.Windows.Forms.TextBox()
        Me.Txt_provee = New System.Windows.Forms.TextBox()
        Me.Txt_Comentario = New System.Windows.Forms.TextBox()
        Me.Txt_Marc = New System.Windows.Forms.TextBox()
        Me.Txt_NomProvee = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DT_Fecha = New System.Windows.Forms.DateTimePicker()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Pnl_Botones.SuspendLayout()
        Me.Tbc_Proveedores.SuspendLayout()
        Me.Tp_Generales.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Btn_Cancelar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Aceptar)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 502)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(1020, 56)
        Me.Pnl_Botones.TabIndex = 12
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cancelar.Image = Global.SIRCO.My.Resources.Resources.dialog_close
        Me.Btn_Cancelar.Location = New System.Drawing.Point(914, 0)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Cancelar.TabIndex = 11
        Me.Btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Cancelar.UseVisualStyleBackColor = True
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Aceptar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_Aceptar.Location = New System.Drawing.Point(965, 0)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Aceptar.TabIndex = 10
        Me.Btn_Aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Aceptar.UseVisualStyleBackColor = True
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'Tbc_Proveedores
        '
        Me.Tbc_Proveedores.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tbc_Proveedores.Controls.Add(Me.Tp_Generales)
        Me.Tbc_Proveedores.Location = New System.Drawing.Point(6, 6)
        Me.Tbc_Proveedores.Name = "Tbc_Proveedores"
        Me.Tbc_Proveedores.SelectedIndex = 0
        Me.Tbc_Proveedores.Size = New System.Drawing.Size(1012, 495)
        Me.Tbc_Proveedores.TabIndex = 13
        '
        'Tp_Generales
        '
        Me.Tp_Generales.BackColor = System.Drawing.SystemColors.Control
        Me.Tp_Generales.Controls.Add(Me.Label4)
        Me.Tp_Generales.Controls.Add(Me.Label3)
        Me.Tp_Generales.Controls.Add(Me.Label2)
        Me.Tp_Generales.Controls.Add(Me.Label6)
        Me.Tp_Generales.Controls.Add(Me.txt_DescripMarca)
        Me.Tp_Generales.Controls.Add(Me.Txt_provee)
        Me.Tp_Generales.Controls.Add(Me.Txt_Comentario)
        Me.Tp_Generales.Controls.Add(Me.Txt_Marc)
        Me.Tp_Generales.Controls.Add(Me.Txt_NomProvee)
        Me.Tp_Generales.Controls.Add(Me.Label1)
        Me.Tp_Generales.Controls.Add(Me.DT_Fecha)
        Me.Tp_Generales.Controls.Add(Me.Label43)
        Me.Tp_Generales.Controls.Add(Me.Label40)
        Me.Tp_Generales.Controls.Add(Me.Label39)
        Me.Tp_Generales.Location = New System.Drawing.Point(4, 22)
        Me.Tp_Generales.Name = "Tp_Generales"
        Me.Tp_Generales.Padding = New System.Windows.Forms.Padding(3)
        Me.Tp_Generales.Size = New System.Drawing.Size(1004, 469)
        Me.Tp_Generales.TabIndex = 0
        Me.Tp_Generales.Text = "Generales"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(41, 166)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 16)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Comentario"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(41, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 16)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Fecha"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(41, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Marca"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(41, 31)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 16)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Proveedor"
        '
        'txt_DescripMarca
        '
        Me.txt_DescripMarca.BackColor = System.Drawing.SystemColors.Window
        Me.txt_DescripMarca.Enabled = False
        Me.txt_DescripMarca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_DescripMarca.Location = New System.Drawing.Point(206, 70)
        Me.txt_DescripMarca.Name = "txt_DescripMarca"
        Me.txt_DescripMarca.ReadOnly = True
        Me.txt_DescripMarca.Size = New System.Drawing.Size(239, 20)
        Me.txt_DescripMarca.TabIndex = 5
        '
        'Txt_provee
        '
        Me.Txt_provee.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_provee.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_provee.Location = New System.Drawing.Point(152, 30)
        Me.Txt_provee.MaxLength = 3
        Me.Txt_provee.Name = "Txt_provee"
        Me.Txt_provee.Size = New System.Drawing.Size(48, 20)
        Me.Txt_provee.TabIndex = 1
        '
        'Txt_Comentario
        '
        Me.Txt_Comentario.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Txt_Comentario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Comentario.Location = New System.Drawing.Point(152, 166)
        Me.Txt_Comentario.MaxLength = 1000
        Me.Txt_Comentario.Multiline = True
        Me.Txt_Comentario.Name = "Txt_Comentario"
        Me.Txt_Comentario.Size = New System.Drawing.Size(608, 278)
        Me.Txt_Comentario.TabIndex = 9
        '
        'Txt_Marc
        '
        Me.Txt_Marc.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Marc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Marc.Location = New System.Drawing.Point(152, 68)
        Me.Txt_Marc.MaxLength = 3
        Me.Txt_Marc.Name = "Txt_Marc"
        Me.Txt_Marc.Size = New System.Drawing.Size(48, 22)
        Me.Txt_Marc.TabIndex = 4
        '
        'Txt_NomProvee
        '
        Me.Txt_NomProvee.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_NomProvee.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_NomProvee.Location = New System.Drawing.Point(206, 30)
        Me.Txt_NomProvee.MaxLength = 50
        Me.Txt_NomProvee.Name = "Txt_NomProvee"
        Me.Txt_NomProvee.ReadOnly = True
        Me.Txt_NomProvee.Size = New System.Drawing.Size(239, 20)
        Me.Txt_NomProvee.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 3
        '
        'DT_Fecha
        '
        Me.DT_Fecha.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DT_Fecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DT_Fecha.Location = New System.Drawing.Point(152, 124)
        Me.DT_Fecha.Name = "DT_Fecha"
        Me.DT_Fecha.Size = New System.Drawing.Size(209, 20)
        Me.DT_Fecha.TabIndex = 7
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(54, 124)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(0, 16)
        Me.Label43.TabIndex = 16
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(54, 74)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(0, 16)
        Me.Label40.TabIndex = 14
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(54, 34)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(0, 16)
        Me.Label39.TabIndex = 13
        '
        'frmCatalogoProveeBita
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1020, 558)
        Me.Controls.Add(Me.Tbc_Proveedores)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmCatalogoProveeBita"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Proveedores"
        Me.Pnl_Botones.ResumeLayout(False)
        Me.Tbc_Proveedores.ResumeLayout(False)
        Me.Tp_Generales.ResumeLayout(False)
        Me.Tp_Generales.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents Btn_Aceptar As System.Windows.Forms.Button
    ' Friend WithEvents Tbl_asistencia_diariaTableAdapter1 As Bitacora.DataSet1TableAdapters.tbl_asistencia_diariaTableAdapter
    Friend WithEvents Btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Tbc_Proveedores As TabControl
    Friend WithEvents Tp_Generales As TabPage
    Friend WithEvents txt_DescripMarca As TextBox
    Friend WithEvents Txt_provee As TextBox
    Friend WithEvents Txt_Marc As TextBox
    Friend WithEvents Txt_NomProvee As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DT_Fecha As DateTimePicker
    Friend WithEvents Label43 As Label
    Friend WithEvents Label40 As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label6 As Label
    Public WithEvents Txt_Comentario As TextBox
End Class
