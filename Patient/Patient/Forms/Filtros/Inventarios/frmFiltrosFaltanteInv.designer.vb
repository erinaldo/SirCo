<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFiltrosFaltanteInv
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFiltrosFaltanteInv))
        Me.Pnl_Edicion = New System.Windows.Forms.Panel()
        Me.Txt_IdDivision = New System.Windows.Forms.TextBox()
        Me.Txt_DescripDivision = New System.Windows.Forms.TextBox()
        Me.Txt_Division = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Txt_DescripSucurOri = New System.Windows.Forms.TextBox()
        Me.Txt_SucurOri = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Pnl_Botones = New System.Windows.Forms.Panel()
        Me.Btn_Limpiar = New System.Windows.Forms.Button()
        Me.Btn_Cancelar = New System.Windows.Forms.Button()
        Me.Btn_Aceptar = New System.Windows.Forms.Button()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Pnl_Edicion.SuspendLayout()
        Me.Pnl_Botones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pnl_Edicion
        '
        Me.Pnl_Edicion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Edicion.Controls.Add(Me.Txt_IdDivision)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_DescripDivision)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Division)
        Me.Pnl_Edicion.Controls.Add(Me.Label1)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_DescripSucurOri)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_SucurOri)
        Me.Pnl_Edicion.Controls.Add(Me.Label4)
        Me.Pnl_Edicion.Location = New System.Drawing.Point(12, 3)
        Me.Pnl_Edicion.Name = "Pnl_Edicion"
        Me.Pnl_Edicion.Size = New System.Drawing.Size(511, 119)
        Me.Pnl_Edicion.TabIndex = 0
        '
        'Txt_IdDivision
        '
        Me.Txt_IdDivision.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdDivision.Location = New System.Drawing.Point(77, 59)
        Me.Txt_IdDivision.MaxLength = 1
        Me.Txt_IdDivision.Name = "Txt_IdDivision"
        Me.Txt_IdDivision.Size = New System.Drawing.Size(17, 20)
        Me.Txt_IdDivision.TabIndex = 158
        Me.Txt_IdDivision.Visible = False
        '
        'Txt_DescripDivision
        '
        Me.Txt_DescripDivision.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripDivision.Enabled = False
        Me.Txt_DescripDivision.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripDivision.Location = New System.Drawing.Point(144, 59)
        Me.Txt_DescripDivision.Name = "Txt_DescripDivision"
        Me.Txt_DescripDivision.ReadOnly = True
        Me.Txt_DescripDivision.Size = New System.Drawing.Size(358, 20)
        Me.Txt_DescripDivision.TabIndex = 157
        '
        'Txt_Division
        '
        Me.Txt_Division.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Division.Location = New System.Drawing.Point(96, 59)
        Me.Txt_Division.MaxLength = 3
        Me.Txt_Division.Name = "Txt_Division"
        Me.Txt_Division.Size = New System.Drawing.Size(42, 20)
        Me.Txt_Division.TabIndex = 156
        Me.Txt_Division.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Division"
        '
        'Txt_DescripSucurOri
        '
        Me.Txt_DescripSucurOri.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripSucurOri.Enabled = False
        Me.Txt_DescripSucurOri.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripSucurOri.Location = New System.Drawing.Point(144, 33)
        Me.Txt_DescripSucurOri.Name = "Txt_DescripSucurOri"
        Me.Txt_DescripSucurOri.ReadOnly = True
        Me.Txt_DescripSucurOri.Size = New System.Drawing.Size(255, 20)
        Me.Txt_DescripSucurOri.TabIndex = 35
        '
        'Txt_SucurOri
        '
        Me.Txt_SucurOri.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_SucurOri.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_SucurOri.Location = New System.Drawing.Point(96, 33)
        Me.Txt_SucurOri.MaxLength = 2
        Me.Txt_SucurOri.Name = "Txt_SucurOri"
        Me.Txt_SucurOri.Size = New System.Drawing.Size(42, 20)
        Me.Txt_SucurOri.TabIndex = 3
        Me.Txt_SucurOri.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Sucursal"
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Btn_Limpiar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Cancelar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Aceptar)
        Me.Pnl_Botones.Location = New System.Drawing.Point(12, 128)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(511, 56)
        Me.Pnl_Botones.TabIndex = 1
        '
        'Btn_Limpiar
        '
        Me.Btn_Limpiar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Limpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Limpiar.Image = Global.SIRCO.My.Resources.Resources.LIMPIAR_FILTROS
        Me.Btn_Limpiar.Location = New System.Drawing.Point(354, 0)
        Me.Btn_Limpiar.Name = "Btn_Limpiar"
        Me.Btn_Limpiar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Limpiar.TabIndex = 0
        Me.Btn_Limpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Limpiar.UseVisualStyleBackColor = True
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cancelar.Image = Global.SIRCO.My.Resources.Resources.dialog_close
        Me.Btn_Cancelar.Location = New System.Drawing.Point(405, 0)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Cancelar.TabIndex = 1
        Me.Btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Cancelar.UseVisualStyleBackColor = True
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Aceptar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_Aceptar.Location = New System.Drawing.Point(456, 0)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Aceptar.TabIndex = 2
        Me.Btn_Aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Aceptar.UseVisualStyleBackColor = True
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        '
        'frmFiltrosFaltanteInv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(530, 190)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Controls.Add(Me.Pnl_Edicion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFiltrosFaltanteInv"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Faltantes de Iventario"
        Me.Pnl_Edicion.ResumeLayout(False)
        Me.Pnl_Edicion.PerformLayout()
        Me.Pnl_Botones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Edicion As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents Btn_Aceptar As System.Windows.Forms.Button
    ' Friend WithEvents Tbl_asistencia_diariaTableAdapter1 As Bitacora.DataSet1TableAdapters.tbl_asistencia_diariaTableAdapter
    Friend WithEvents Btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip

    'Friend WithEvents Tbl_EmpleadoTableAdapter1 As Bitacora.DataSet1TableAdapters.tbl_EmpleadoTableAdapter
    Friend WithEvents Btn_Limpiar As System.Windows.Forms.Button
    Friend WithEvents Txt_DescripSucurOri As System.Windows.Forms.TextBox
    Friend WithEvents Txt_SucurOri As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Txt_IdDivision As System.Windows.Forms.TextBox
    Friend WithEvents Txt_DescripDivision As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Division As System.Windows.Forms.TextBox
End Class
