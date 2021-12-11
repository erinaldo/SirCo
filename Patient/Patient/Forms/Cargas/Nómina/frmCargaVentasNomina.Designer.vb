<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCargaVentasNomina
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCargaVentasNomina))
        Me.Pnl_Botones = New System.Windows.Forms.Panel
        Me.Txt_Porc = New System.Windows.Forms.TextBox
        Me.PBar = New System.Windows.Forms.ProgressBar
        Me.Btn_Cancelar = New System.Windows.Forms.Button
        Me.Btn_Aceptar = New System.Windows.Forms.Button
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.Pnl_Edicion = New System.Windows.Forms.Panel
        Me.Txt_NombreEmpleado = New System.Windows.Forms.TextBox
        Me.Empleado = New System.Windows.Forms.Label
        Me.Txt_IdEmpleado = New System.Windows.Forms.TextBox
        Me.Txt_DescripSucursal = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Txt_Sucursal = New System.Windows.Forms.TextBox
        Me.DTFecha1 = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.DTFecha = New System.Windows.Forms.DateTimePicker
        Me.Txt_Id_SegBit = New System.Windows.Forms.TextBox
        Me.Pnl_Botones.SuspendLayout()
        Me.Pnl_Edicion.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Txt_Porc)
        Me.Pnl_Botones.Controls.Add(Me.PBar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Cancelar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Aceptar)
        Me.Pnl_Botones.Location = New System.Drawing.Point(12, 126)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(602, 56)
        Me.Pnl_Botones.TabIndex = 1
        '
        'Txt_Porc
        '
        Me.Txt_Porc.Enabled = False
        Me.Txt_Porc.Location = New System.Drawing.Point(163, 32)
        Me.Txt_Porc.Name = "Txt_Porc"
        Me.Txt_Porc.ReadOnly = True
        Me.Txt_Porc.Size = New System.Drawing.Size(100, 20)
        Me.Txt_Porc.TabIndex = 86
        Me.Txt_Porc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PBar
        '
        Me.PBar.Location = New System.Drawing.Point(3, 3)
        Me.PBar.Name = "PBar"
        Me.PBar.Size = New System.Drawing.Size(415, 23)
        Me.PBar.TabIndex = 85
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cancelar.Image = Global.SIRCO.My.Resources.Resources.dialog_close
        Me.Btn_Cancelar.Location = New System.Drawing.Point(496, 0)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Cancelar.TabIndex = 7
        Me.Btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Cancelar.UseVisualStyleBackColor = True
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Aceptar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_Aceptar.Location = New System.Drawing.Point(547, 0)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Aceptar.TabIndex = 6
        Me.Btn_Aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Aceptar.UseVisualStyleBackColor = True
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 3
        '
        'Pnl_Edicion
        '
        Me.Pnl_Edicion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Edicion.Controls.Add(Me.Txt_NombreEmpleado)
        Me.Pnl_Edicion.Controls.Add(Me.Empleado)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_IdEmpleado)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_DescripSucursal)
        Me.Pnl_Edicion.Controls.Add(Me.Label3)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Sucursal)
        Me.Pnl_Edicion.Controls.Add(Me.DTFecha1)
        Me.Pnl_Edicion.Controls.Add(Me.Label2)
        Me.Pnl_Edicion.Controls.Add(Me.DTFecha)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Id_SegBit)
        Me.Pnl_Edicion.Controls.Add(Me.Label1)
        Me.Pnl_Edicion.Location = New System.Drawing.Point(12, 3)
        Me.Pnl_Edicion.Name = "Pnl_Edicion"
        Me.Pnl_Edicion.Size = New System.Drawing.Size(602, 117)
        Me.Pnl_Edicion.TabIndex = 0
        '
        'Txt_NombreEmpleado
        '
        Me.Txt_NombreEmpleado.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_NombreEmpleado.Enabled = False
        Me.Txt_NombreEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_NombreEmpleado.Location = New System.Drawing.Point(145, 42)
        Me.Txt_NombreEmpleado.MaxLength = 200
        Me.Txt_NombreEmpleado.Name = "Txt_NombreEmpleado"
        Me.Txt_NombreEmpleado.ReadOnly = True
        Me.Txt_NombreEmpleado.Size = New System.Drawing.Size(330, 20)
        Me.Txt_NombreEmpleado.TabIndex = 3
        '
        'Empleado
        '
        Me.Empleado.AutoSize = True
        Me.Empleado.Location = New System.Drawing.Point(12, 45)
        Me.Empleado.Name = "Empleado"
        Me.Empleado.Size = New System.Drawing.Size(54, 13)
        Me.Empleado.TabIndex = 112
        Me.Empleado.Text = "Empleado"
        '
        'Txt_IdEmpleado
        '
        Me.Txt_IdEmpleado.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_IdEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdEmpleado.Location = New System.Drawing.Point(67, 42)
        Me.Txt_IdEmpleado.MaxLength = 5
        Me.Txt_IdEmpleado.Name = "Txt_IdEmpleado"
        Me.Txt_IdEmpleado.Size = New System.Drawing.Size(70, 20)
        Me.Txt_IdEmpleado.TabIndex = 2
        '
        'Txt_DescripSucursal
        '
        Me.Txt_DescripSucursal.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripSucursal.Enabled = False
        Me.Txt_DescripSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripSucursal.Location = New System.Drawing.Point(145, 68)
        Me.Txt_DescripSucursal.MaxLength = 200
        Me.Txt_DescripSucursal.Name = "Txt_DescripSucursal"
        Me.Txt_DescripSucursal.ReadOnly = True
        Me.Txt_DescripSucursal.Size = New System.Drawing.Size(330, 20)
        Me.Txt_DescripSucursal.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 109
        Me.Label3.Text = "Sucursal"
        '
        'Txt_Sucursal
        '
        Me.Txt_Sucursal.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Sucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Sucursal.Location = New System.Drawing.Point(67, 68)
        Me.Txt_Sucursal.MaxLength = 2
        Me.Txt_Sucursal.Name = "Txt_Sucursal"
        Me.Txt_Sucursal.Size = New System.Drawing.Size(70, 20)
        Me.Txt_Sucursal.TabIndex = 4
        '
        'DTFecha1
        '
        Me.DTFecha1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTFecha1.Location = New System.Drawing.Point(330, 16)
        Me.DTFecha1.Name = "DTFecha1"
        Me.DTFecha1.Size = New System.Drawing.Size(248, 20)
        Me.DTFecha1.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 84
        Me.Label2.Text = "Fecha"
        '
        'DTFecha
        '
        Me.DTFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTFecha.Location = New System.Drawing.Point(67, 16)
        Me.DTFecha.Name = "DTFecha"
        Me.DTFecha.Size = New System.Drawing.Size(248, 20)
        Me.DTFecha.TabIndex = 0
        '
        'Txt_Id_SegBit
        '
        Me.Txt_Id_SegBit.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Id_SegBit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Id_SegBit.Location = New System.Drawing.Point(542, -2)
        Me.Txt_Id_SegBit.MaxLength = 6
        Me.Txt_Id_SegBit.Name = "Txt_Id_SegBit"
        Me.Txt_Id_SegBit.Size = New System.Drawing.Size(10, 20)
        Me.Txt_Id_SegBit.TabIndex = 82
        Me.Txt_Id_SegBit.Visible = False
        '
        'frmCargaVentasNomina
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(626, 191)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Controls.Add(Me.Pnl_Edicion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmCargaVentasNomina"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Carga Base Ventas Nómina"
        Me.Pnl_Botones.ResumeLayout(False)
        Me.Pnl_Botones.PerformLayout()
        Me.Pnl_Edicion.ResumeLayout(False)
        Me.Pnl_Edicion.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents Btn_Aceptar As System.Windows.Forms.Button
    'Friend WithEvents Tbl_asistencia_diariaTableAdapter1 As Bitacora.DataSet1TableAdapters.tbl_asistencia_diariaTableAdapter
    Friend WithEvents Btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Pnl_Edicion As System.Windows.Forms.Panel
    Friend WithEvents Txt_Id_SegBit As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Porc As System.Windows.Forms.TextBox
    Friend WithEvents PBar As System.Windows.Forms.ProgressBar
    Friend WithEvents DTFecha1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DTFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Txt_DescripSucursal As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Txt_Sucursal As System.Windows.Forms.TextBox
    Friend WithEvents Txt_NombreEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents Empleado As System.Windows.Forms.Label
    Friend WithEvents Txt_IdEmpleado As System.Windows.Forms.TextBox
End Class
