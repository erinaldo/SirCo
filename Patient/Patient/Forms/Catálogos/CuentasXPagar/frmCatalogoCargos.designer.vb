<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCatalogoCargos
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCatalogoCargos))
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.Lbl_Nota = New System.Windows.Forms.Label
        Me.DTFechaNota = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Txt_Proveedor = New System.Windows.Forms.TextBox
        Me.Txt_RazSoc = New System.Windows.Forms.TextBox
        Me.Txt_Descripcion = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Cbo_Motivo = New System.Windows.Forms.ComboBox
        Me.Lbl_Motivo = New System.Windows.Forms.Label
        Me.Lbl_Folio = New System.Windows.Forms.Label
        Me.Txt_IdFolio = New System.Windows.Forms.TextBox
        Me.Cbo_Estatus = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Txt_Referenc = New System.Windows.Forms.TextBox
        Me.Txt_Factprov = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Txt_Folio = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Txt_ImpTotal = New System.Windows.Forms.TextBox
        Me.Txt_IVA = New System.Windows.Forms.TextBox
        Me.Txt_Importe = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Pnl_Botones = New System.Windows.Forms.Panel
        Me.Btn_Eliminar = New System.Windows.Forms.Button
        Me.Btn_Cancelar = New System.Windows.Forms.Button
        Me.Btn_Aceptar = New System.Windows.Forms.Button
        Me.Btn_Editar = New System.Windows.Forms.Button
        Me.Btn_Nuevo = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.Pnl_Botones.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'Lbl_Nota
        '
        Me.Lbl_Nota.AutoSize = True
        Me.Lbl_Nota.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Nota.Location = New System.Drawing.Point(13, 11)
        Me.Lbl_Nota.Name = "Lbl_Nota"
        Me.Lbl_Nota.Size = New System.Drawing.Size(53, 24)
        Me.Lbl_Nota.TabIndex = 0
        Me.Lbl_Nota.Text = "Nota"
        '
        'DTFechaNota
        '
        Me.DTFechaNota.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTFechaNota.Location = New System.Drawing.Point(536, 15)
        Me.DTFechaNota.Name = "DTFechaNota"
        Me.DTFechaNota.Size = New System.Drawing.Size(236, 20)
        Me.DTFechaNota.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(493, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Fecha"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Proveedor"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 137)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Descripción"
        '
        'Txt_Proveedor
        '
        Me.Txt_Proveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Proveedor.Location = New System.Drawing.Point(85, 81)
        Me.Txt_Proveedor.MaxLength = 3
        Me.Txt_Proveedor.Name = "Txt_Proveedor"
        Me.Txt_Proveedor.Size = New System.Drawing.Size(76, 20)
        Me.Txt_Proveedor.TabIndex = 3
        Me.Txt_Proveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Txt_RazSoc
        '
        Me.Txt_RazSoc.Enabled = False
        Me.Txt_RazSoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_RazSoc.Location = New System.Drawing.Point(167, 81)
        Me.Txt_RazSoc.Name = "Txt_RazSoc"
        Me.Txt_RazSoc.Size = New System.Drawing.Size(311, 20)
        Me.Txt_RazSoc.TabIndex = 4
        '
        'Txt_Descripcion
        '
        Me.Txt_Descripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Descripcion.Location = New System.Drawing.Point(85, 134)
        Me.Txt_Descripcion.MaxLength = 150
        Me.Txt_Descripcion.Multiline = True
        Me.Txt_Descripcion.Name = "Txt_Descripcion"
        Me.Txt_Descripcion.Size = New System.Drawing.Size(393, 47)
        Me.Txt_Descripcion.TabIndex = 6
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Cbo_Motivo)
        Me.Panel1.Controls.Add(Me.Lbl_Motivo)
        Me.Panel1.Controls.Add(Me.Lbl_Folio)
        Me.Panel1.Controls.Add(Me.Txt_IdFolio)
        Me.Panel1.Controls.Add(Me.Cbo_Estatus)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Txt_Referenc)
        Me.Panel1.Controls.Add(Me.Txt_Factprov)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Txt_Folio)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Txt_ImpTotal)
        Me.Panel1.Controls.Add(Me.Txt_IVA)
        Me.Panel1.Controls.Add(Me.Txt_Importe)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.DTFechaNota)
        Me.Panel1.Controls.Add(Me.Txt_Descripcion)
        Me.Panel1.Controls.Add(Me.Lbl_Nota)
        Me.Panel1.Controls.Add(Me.Txt_RazSoc)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Txt_Proveedor)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(12, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(804, 204)
        Me.Panel1.TabIndex = 9
        '
        'Cbo_Motivo
        '
        Me.Cbo_Motivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbo_Motivo.FormattingEnabled = True
        Me.Cbo_Motivo.Items.AddRange(New Object() {"CAPTURA", "APLICADO"})
        Me.Cbo_Motivo.Location = New System.Drawing.Point(85, 107)
        Me.Cbo_Motivo.Name = "Cbo_Motivo"
        Me.Cbo_Motivo.Size = New System.Drawing.Size(228, 21)
        Me.Cbo_Motivo.TabIndex = 5
        '
        'Lbl_Motivo
        '
        Me.Lbl_Motivo.AutoSize = True
        Me.Lbl_Motivo.Location = New System.Drawing.Point(13, 110)
        Me.Lbl_Motivo.Name = "Lbl_Motivo"
        Me.Lbl_Motivo.Size = New System.Drawing.Size(39, 13)
        Me.Lbl_Motivo.TabIndex = 24
        Me.Lbl_Motivo.Text = "Motivo"
        '
        'Lbl_Folio
        '
        Me.Lbl_Folio.AutoSize = True
        Me.Lbl_Folio.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Folio.Location = New System.Drawing.Point(210, 11)
        Me.Lbl_Folio.Name = "Lbl_Folio"
        Me.Lbl_Folio.Size = New System.Drawing.Size(57, 24)
        Me.Lbl_Folio.TabIndex = 23
        Me.Lbl_Folio.Text = "Folio"
        '
        'Txt_IdFolio
        '
        Me.Txt_IdFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdFolio.Location = New System.Drawing.Point(446, 16)
        Me.Txt_IdFolio.MaxLength = 3
        Me.Txt_IdFolio.Name = "Txt_IdFolio"
        Me.Txt_IdFolio.Size = New System.Drawing.Size(32, 20)
        Me.Txt_IdFolio.TabIndex = 22
        Me.Txt_IdFolio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Txt_IdFolio.Visible = False
        '
        'Cbo_Estatus
        '
        Me.Cbo_Estatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbo_Estatus.FormattingEnabled = True
        Me.Cbo_Estatus.Items.AddRange(New Object() {"CAPTURA", "APLICADA", "STAND BY"})
        Me.Cbo_Estatus.Location = New System.Drawing.Point(536, 55)
        Me.Cbo_Estatus.Name = "Cbo_Estatus"
        Me.Cbo_Estatus.Size = New System.Drawing.Size(108, 21)
        Me.Cbo_Estatus.TabIndex = 3
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(493, 58)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 13)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Estatus"
        '
        'Txt_Referenc
        '
        Me.Txt_Referenc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Referenc.Location = New System.Drawing.Point(379, 55)
        Me.Txt_Referenc.MaxLength = 3
        Me.Txt_Referenc.Name = "Txt_Referenc"
        Me.Txt_Referenc.Size = New System.Drawing.Size(99, 20)
        Me.Txt_Referenc.TabIndex = 2
        Me.Txt_Referenc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Txt_Factprov
        '
        Me.Txt_Factprov.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Factprov.Location = New System.Drawing.Point(214, 55)
        Me.Txt_Factprov.MaxLength = 3
        Me.Txt_Factprov.Name = "Txt_Factprov"
        Me.Txt_Factprov.Size = New System.Drawing.Size(99, 20)
        Me.Txt_Factprov.TabIndex = 1
        Me.Txt_Factprov.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(316, 58)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Referencia"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(168, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Factura"
        '
        'Txt_Folio
        '
        Me.Txt_Folio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Folio.Location = New System.Drawing.Point(85, 55)
        Me.Txt_Folio.MaxLength = 8
        Me.Txt_Folio.Name = "Txt_Folio"
        Me.Txt_Folio.Size = New System.Drawing.Size(76, 20)
        Me.Txt_Folio.TabIndex = 0
        Me.Txt_Folio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 58)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Folio Bulto"
        '
        'Txt_ImpTotal
        '
        Me.Txt_ImpTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ImpTotal.Location = New System.Drawing.Point(536, 134)
        Me.Txt_ImpTotal.MaxLength = 20
        Me.Txt_ImpTotal.Name = "Txt_ImpTotal"
        Me.Txt_ImpTotal.Size = New System.Drawing.Size(108, 20)
        Me.Txt_ImpTotal.TabIndex = 7
        Me.Txt_ImpTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txt_IVA
        '
        Me.Txt_IVA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IVA.Location = New System.Drawing.Point(536, 108)
        Me.Txt_IVA.MaxLength = 7
        Me.Txt_IVA.Name = "Txt_IVA"
        Me.Txt_IVA.Size = New System.Drawing.Size(108, 20)
        Me.Txt_IVA.TabIndex = 5
        Me.Txt_IVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txt_Importe
        '
        Me.Txt_Importe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Importe.Location = New System.Drawing.Point(536, 82)
        Me.Txt_Importe.MaxLength = 7
        Me.Txt_Importe.Name = "Txt_Importe"
        Me.Txt_Importe.Size = New System.Drawing.Size(108, 20)
        Me.Txt_Importe.TabIndex = 4
        Me.Txt_Importe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(493, 137)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Total"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(493, 111)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(24, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "IVA"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(493, 85)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Importe"
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Btn_Eliminar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Cancelar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Aceptar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Editar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Nuevo)
        Me.Pnl_Botones.Location = New System.Drawing.Point(12, 216)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(804, 56)
        Me.Pnl_Botones.TabIndex = 10
        '
        'Btn_Eliminar
        '
        Me.Btn_Eliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Eliminar.Image = Global.SIRCO.My.Resources.Resources.document_delete
        Me.Btn_Eliminar.Location = New System.Drawing.Point(131, 3)
        Me.Btn_Eliminar.Name = "Btn_Eliminar"
        Me.Btn_Eliminar.Size = New System.Drawing.Size(51, 47)
        Me.Btn_Eliminar.TabIndex = 2
        Me.Btn_Eliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Eliminar.UseVisualStyleBackColor = True
        Me.Btn_Eliminar.Visible = False
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cancelar.Image = Global.SIRCO.My.Resources.Resources.dialog_close
        Me.Btn_Cancelar.Location = New System.Drawing.Point(698, 0)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Cancelar.TabIndex = 3
        Me.Btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Cancelar.UseVisualStyleBackColor = True
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Aceptar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_Aceptar.Location = New System.Drawing.Point(749, 0)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Aceptar.TabIndex = 4
        Me.Btn_Aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Aceptar.UseVisualStyleBackColor = True
        '
        'Btn_Editar
        '
        Me.Btn_Editar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Editar.Image = Global.SIRCO.My.Resources.Resources.Editar
        Me.Btn_Editar.Location = New System.Drawing.Point(74, 3)
        Me.Btn_Editar.Name = "Btn_Editar"
        Me.Btn_Editar.Size = New System.Drawing.Size(51, 47)
        Me.Btn_Editar.TabIndex = 1
        Me.Btn_Editar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Editar.UseVisualStyleBackColor = True
        Me.Btn_Editar.Visible = False
        '
        'Btn_Nuevo
        '
        Me.Btn_Nuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Nuevo.Image = Global.SIRCO.My.Resources.Resources.new_20doc
        Me.Btn_Nuevo.Location = New System.Drawing.Point(17, 3)
        Me.Btn_Nuevo.Name = "Btn_Nuevo"
        Me.Btn_Nuevo.Size = New System.Drawing.Size(51, 47)
        Me.Btn_Nuevo.TabIndex = 0
        Me.Btn_Nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Nuevo.UseVisualStyleBackColor = True
        Me.Btn_Nuevo.Visible = False
        '
        'frmCatalogoCargos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(828, 284)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmCatalogoCargos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catálogo de Cargos"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Pnl_Botones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    '  Friend WithEvents Tbl_asistencia_diariaTableAdapter1 As Bitacora.DataSet1TableAdapters.tbl_asistencia_diariaTableAdapter
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Lbl_Nota As System.Windows.Forms.Label
    Friend WithEvents DTFechaNota As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Txt_Proveedor As System.Windows.Forms.TextBox
    Friend WithEvents Txt_RazSoc As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Descripcion As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Txt_ImpTotal As System.Windows.Forms.TextBox
    Friend WithEvents Txt_IVA As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Importe As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents Btn_Eliminar As System.Windows.Forms.Button
    Friend WithEvents Btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Btn_Editar As System.Windows.Forms.Button
    Friend WithEvents Btn_Nuevo As System.Windows.Forms.Button
    Friend WithEvents Txt_Folio As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Txt_Referenc As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Factprov As System.Windows.Forms.TextBox
    Friend WithEvents Cbo_Estatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Txt_IdFolio As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_Folio As System.Windows.Forms.Label
    Friend WithEvents Cbo_Motivo As System.Windows.Forms.ComboBox
    Friend WithEvents Lbl_Motivo As System.Windows.Forms.Label
End Class
