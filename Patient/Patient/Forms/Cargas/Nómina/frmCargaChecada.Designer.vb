<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCargaChecada
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCargaChecada))
        Me.Pnl_Botones = New System.Windows.Forms.Panel()
        Me.Btn_Cancelar = New System.Windows.Forms.Button()
        Me.Btn_Aceptar = New System.Windows.Forms.Button()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Pnl_Edicion = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Txt_DescripSucursal = New System.Windows.Forms.TextBox()
        Me.Txt_Sucursal = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Txt_Id_SegBit = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DTPicker = New System.Windows.Forms.DateTimePicker()
        Me.Pnl_Botones.SuspendLayout()
        Me.Pnl_Edicion.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.Controls.Add(Me.Btn_Cancelar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Aceptar)
        Me.Pnl_Botones.Location = New System.Drawing.Point(13, 178)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(559, 56)
        Me.Pnl_Botones.TabIndex = 1
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cancelar.Image = Global.SIRCO.My.Resources.Resources.dialog_close
        Me.Btn_Cancelar.Location = New System.Drawing.Point(453, 0)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Cancelar.TabIndex = 26
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
        Me.Btn_Aceptar.TabIndex = 25
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
        Me.Pnl_Edicion.Controls.Add(Me.Label3)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_DescripSucursal)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Sucursal)
        Me.Pnl_Edicion.Controls.Add(Me.Label16)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Id_SegBit)
        Me.Pnl_Edicion.Controls.Add(Me.Label2)
        Me.Pnl_Edicion.Controls.Add(Me.DTPicker)
        Me.Pnl_Edicion.Controls.Add(Me.Label1)
        Me.Pnl_Edicion.Location = New System.Drawing.Point(12, 3)
        Me.Pnl_Edicion.Name = "Pnl_Edicion"
        Me.Pnl_Edicion.Size = New System.Drawing.Size(559, 169)
        Me.Pnl_Edicion.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(22, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(506, 13)
        Me.Label3.TabIndex = 91
        Me.Label3.Text = "IMPORTANTE: El sistema se puede tornar lento. NO APAGUE NI CIERRE EL SISTEMA."
        '
        'Txt_DescripSucursal
        '
        Me.Txt_DescripSucursal.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripSucursal.Enabled = False
        Me.Txt_DescripSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripSucursal.Location = New System.Drawing.Point(151, 13)
        Me.Txt_DescripSucursal.Name = "Txt_DescripSucursal"
        Me.Txt_DescripSucursal.ReadOnly = True
        Me.Txt_DescripSucursal.Size = New System.Drawing.Size(127, 20)
        Me.Txt_DescripSucursal.TabIndex = 1
        '
        'Txt_Sucursal
        '
        Me.Txt_Sucursal.Enabled = False
        Me.Txt_Sucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Sucursal.Location = New System.Drawing.Point(110, 13)
        Me.Txt_Sucursal.MaxLength = 3
        Me.Txt_Sucursal.Name = "Txt_Sucursal"
        Me.Txt_Sucursal.Size = New System.Drawing.Size(34, 20)
        Me.Txt_Sucursal.TabIndex = 0
        Me.Txt_Sucursal.Text = "02"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(22, 16)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(48, 13)
        Me.Label16.TabIndex = 90
        Me.Label16.Text = "Sucursal"
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 73
        Me.Label2.Text = "Fecha"
        '
        'DTPicker
        '
        Me.DTPicker.Enabled = False
        Me.DTPicker.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPicker.Location = New System.Drawing.Point(110, 50)
        Me.DTPicker.Name = "DTPicker"
        Me.DTPicker.Size = New System.Drawing.Size(248, 20)
        Me.DTPicker.TabIndex = 6
        '
        'frmCargaChecada
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 243)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Controls.Add(Me.Pnl_Edicion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmCargaChecada"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Carga Checadas."
        Me.Pnl_Botones.ResumeLayout(False)
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DTPicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents Txt_Id_SegBit As System.Windows.Forms.TextBox
    Friend WithEvents Txt_DescripSucursal As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Sucursal As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
