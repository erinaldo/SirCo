<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCatalogoPuestos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCatalogoPuestos))
        Me.Pnl_Edicion = New System.Windows.Forms.Panel
        Me.Txt_ClaveDepto = New System.Windows.Forms.TextBox
        Me.Txt_Clave = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Txt_IdPuesto = New System.Windows.Forms.TextBox
        Me.Btn_Buscar = New System.Windows.Forms.Button
        Me.Txt_DescripPuesto = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Txt_Campo1 = New System.Windows.Forms.TextBox
        Me.Txt_Campo = New System.Windows.Forms.TextBox
        Me.Txt_DescripDepto = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Txt_IdDepto = New System.Windows.Forms.TextBox
        Me.Lbl_Marca = New System.Windows.Forms.Label
        Me.Pnl_Botones = New System.Windows.Forms.Panel
        Me.Btn_Eliminar = New System.Windows.Forms.Button
        Me.Btn_Cancelar = New System.Windows.Forms.Button
        Me.Btn_Aceptar = New System.Windows.Forms.Button
        Me.Btn_Editar = New System.Windows.Forms.Button
        Me.Btn_Nuevo = New System.Windows.Forms.Button
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.Chk_comision = New System.Windows.Forms.CheckBox
        Me.Chk_TVenta = New System.Windows.Forms.CheckBox
        Me.Pnl_Edicion.SuspendLayout()
        Me.Pnl_Botones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pnl_Edicion
        '
        Me.Pnl_Edicion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Edicion.Controls.Add(Me.Chk_TVenta)
        Me.Pnl_Edicion.Controls.Add(Me.Chk_comision)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_ClaveDepto)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Clave)
        Me.Pnl_Edicion.Controls.Add(Me.Label3)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_IdPuesto)
        Me.Pnl_Edicion.Controls.Add(Me.Btn_Buscar)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_DescripPuesto)
        Me.Pnl_Edicion.Controls.Add(Me.Label2)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Campo1)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Campo)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_DescripDepto)
        Me.Pnl_Edicion.Controls.Add(Me.Label1)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_IdDepto)
        Me.Pnl_Edicion.Controls.Add(Me.Lbl_Marca)
        Me.Pnl_Edicion.Location = New System.Drawing.Point(12, 3)
        Me.Pnl_Edicion.Name = "Pnl_Edicion"
        Me.Pnl_Edicion.Size = New System.Drawing.Size(559, 130)
        Me.Pnl_Edicion.TabIndex = 0
        '
        'Txt_ClaveDepto
        '
        Me.Txt_ClaveDepto.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_ClaveDepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ClaveDepto.Location = New System.Drawing.Point(94, 10)
        Me.Txt_ClaveDepto.MaxLength = 3
        Me.Txt_ClaveDepto.Name = "Txt_ClaveDepto"
        Me.Txt_ClaveDepto.Size = New System.Drawing.Size(42, 20)
        Me.Txt_ClaveDepto.TabIndex = 0
        '
        'Txt_Clave
        '
        Me.Txt_Clave.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Clave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Clave.Location = New System.Drawing.Point(94, 33)
        Me.Txt_Clave.MaxLength = 3
        Me.Txt_Clave.Name = "Txt_Clave"
        Me.Txt_Clave.Size = New System.Drawing.Size(42, 20)
        Me.Txt_Clave.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(434, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 58
        Me.Label3.Text = "IdPuesto"
        Me.Label3.Visible = False
        '
        'Txt_IdPuesto
        '
        Me.Txt_IdPuesto.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_IdPuesto.Enabled = False
        Me.Txt_IdPuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdPuesto.Location = New System.Drawing.Point(504, -2)
        Me.Txt_IdPuesto.MaxLength = 6
        Me.Txt_IdPuesto.Name = "Txt_IdPuesto"
        Me.Txt_IdPuesto.ReadOnly = True
        Me.Txt_IdPuesto.Size = New System.Drawing.Size(42, 20)
        Me.Txt_IdPuesto.TabIndex = 57
        Me.Txt_IdPuesto.Visible = False
        '
        'Btn_Buscar
        '
        Me.Btn_Buscar.Image = Global.SIRCO.My.Resources.Resources.find
        Me.Btn_Buscar.Location = New System.Drawing.Point(390, 56)
        Me.Btn_Buscar.Name = "Btn_Buscar"
        Me.Btn_Buscar.Size = New System.Drawing.Size(48, 23)
        Me.Btn_Buscar.TabIndex = 2
        Me.Btn_Buscar.UseVisualStyleBackColor = True
        Me.Btn_Buscar.Visible = False
        '
        'Txt_DescripPuesto
        '
        Me.Txt_DescripPuesto.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripPuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripPuesto.Location = New System.Drawing.Point(149, 33)
        Me.Txt_DescripPuesto.MaxLength = 30
        Me.Txt_DescripPuesto.Name = "Txt_DescripPuesto"
        Me.Txt_DescripPuesto.Size = New System.Drawing.Size(235, 20)
        Me.Txt_DescripPuesto.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "Puesto"
        '
        'Txt_Campo1
        '
        Me.Txt_Campo1.Location = New System.Drawing.Point(488, 47)
        Me.Txt_Campo1.Name = "Txt_Campo1"
        Me.Txt_Campo1.Size = New System.Drawing.Size(32, 20)
        Me.Txt_Campo1.TabIndex = 53
        Me.Txt_Campo1.Visible = False
        '
        'Txt_Campo
        '
        Me.Txt_Campo.Location = New System.Drawing.Point(437, 47)
        Me.Txt_Campo.Name = "Txt_Campo"
        Me.Txt_Campo.Size = New System.Drawing.Size(32, 20)
        Me.Txt_Campo.TabIndex = 52
        Me.Txt_Campo.Visible = False
        '
        'Txt_DescripDepto
        '
        Me.Txt_DescripDepto.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripDepto.Enabled = False
        Me.Txt_DescripDepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripDepto.Location = New System.Drawing.Point(149, 10)
        Me.Txt_DescripDepto.MaxLength = 30
        Me.Txt_DescripDepto.Name = "Txt_DescripDepto"
        Me.Txt_DescripDepto.ReadOnly = True
        Me.Txt_DescripDepto.Size = New System.Drawing.Size(235, 20)
        Me.Txt_DescripDepto.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(288, -2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "IdDepto"
        Me.Label1.Visible = False
        '
        'Txt_IdDepto
        '
        Me.Txt_IdDepto.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_IdDepto.Enabled = False
        Me.Txt_IdDepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdDepto.Location = New System.Drawing.Point(94, 7)
        Me.Txt_IdDepto.MaxLength = 6
        Me.Txt_IdDepto.Name = "Txt_IdDepto"
        Me.Txt_IdDepto.ReadOnly = True
        Me.Txt_IdDepto.Size = New System.Drawing.Size(42, 20)
        Me.Txt_IdDepto.TabIndex = 0
        Me.Txt_IdDepto.Visible = False
        '
        'Lbl_Marca
        '
        Me.Lbl_Marca.AutoSize = True
        Me.Lbl_Marca.Location = New System.Drawing.Point(14, 12)
        Me.Lbl_Marca.Name = "Lbl_Marca"
        Me.Lbl_Marca.Size = New System.Drawing.Size(74, 13)
        Me.Lbl_Marca.TabIndex = 0
        Me.Lbl_Marca.Text = "Departamento"
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Btn_Eliminar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Cancelar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Aceptar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Editar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Nuevo)
        Me.Pnl_Botones.Location = New System.Drawing.Point(12, 139)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(559, 56)
        Me.Pnl_Botones.TabIndex = 1
        '
        'Btn_Eliminar
        '
        Me.Btn_Eliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Eliminar.Image = Global.SIRCO.My.Resources.Resources.document_delete
        Me.Btn_Eliminar.Location = New System.Drawing.Point(131, 3)
        Me.Btn_Eliminar.Name = "Btn_Eliminar"
        Me.Btn_Eliminar.Size = New System.Drawing.Size(51, 47)
        Me.Btn_Eliminar.TabIndex = 6
        Me.Btn_Eliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Eliminar.UseVisualStyleBackColor = True
        Me.Btn_Eliminar.Visible = False
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cancelar.Image = Global.SIRCO.My.Resources.Resources.dialog_close
        Me.Btn_Cancelar.Location = New System.Drawing.Point(453, 0)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Cancelar.TabIndex = 5
        Me.Btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Cancelar.UseVisualStyleBackColor = True
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Aceptar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_Aceptar.Location = New System.Drawing.Point(504, 0)
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
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'Chk_comision
        '
        Me.Chk_comision.AutoSize = True
        Me.Chk_comision.Location = New System.Drawing.Point(17, 62)
        Me.Chk_comision.Name = "Chk_comision"
        Me.Chk_comision.Size = New System.Drawing.Size(68, 17)
        Me.Chk_comision.TabIndex = 59
        Me.Chk_comision.Text = "Comisión"
        Me.Chk_comision.UseVisualStyleBackColor = True
        '
        'Chk_TVenta
        '
        Me.Chk_TVenta.AutoSize = True
        Me.Chk_TVenta.Enabled = False
        Me.Chk_TVenta.Location = New System.Drawing.Point(18, 85)
        Me.Chk_TVenta.Name = "Chk_TVenta"
        Me.Chk_TVenta.Size = New System.Drawing.Size(107, 17)
        Me.Chk_TVenta.TabIndex = 60
        Me.Chk_TVenta.Text = "Total de la Venta"
        Me.Chk_TVenta.UseVisualStyleBackColor = True
        '
        'frmCatalogoPuestos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(582, 207)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Controls.Add(Me.Pnl_Edicion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmCatalogoPuestos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Catálogo de Puestos"
        Me.Pnl_Edicion.ResumeLayout(False)
        Me.Pnl_Edicion.PerformLayout()
        Me.Pnl_Botones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Edicion As System.Windows.Forms.Panel
    Friend WithEvents Txt_IdDepto As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_Marca As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Txt_DescripDepto As System.Windows.Forms.TextBox
    Friend WithEvents Pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents Btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Btn_Editar As System.Windows.Forms.Button
    Friend WithEvents Btn_Nuevo As System.Windows.Forms.Button
    ' Friend WithEvents Tbl_asistencia_diariaTableAdapter1 As Bitacora.DataSet1TableAdapters.tbl_asistencia_diariaTableAdapter
    Friend WithEvents Btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents Btn_Eliminar As System.Windows.Forms.Button
    Friend WithEvents Txt_Campo1 As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Campo As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Txt_IdPuesto As System.Windows.Forms.TextBox
    Friend WithEvents Btn_Buscar As System.Windows.Forms.Button
    Friend WithEvents Txt_DescripPuesto As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Txt_Clave As System.Windows.Forms.TextBox
    Friend WithEvents Txt_ClaveDepto As System.Windows.Forms.TextBox
    Friend WithEvents Chk_TVenta As System.Windows.Forms.CheckBox
    Friend WithEvents Chk_comision As System.Windows.Forms.CheckBox
End Class
