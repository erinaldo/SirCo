<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFirmaPV
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFirmaPV))
        Me.Txt_Vendedor = New DevExpress.XtraEditors.TextEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txt_NombreVendedor = New DevExpress.XtraEditors.TextEdit()
        Me.Lbl_Cajero = New System.Windows.Forms.Label()
        Me.Txt_Sucursal = New System.Windows.Forms.Label()
        Me.Cmd_Limpiar = New DevExpress.XtraEditors.SimpleButton()
        Me.Cmd_Aceptar = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.Txt_Vendedor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_NombreVendedor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Txt_Vendedor
        '
        Me.Txt_Vendedor.Location = New System.Drawing.Point(113, 36)
        Me.Txt_Vendedor.Name = "Txt_Vendedor"
        Me.Txt_Vendedor.Properties.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Vendedor.Properties.Appearance.Options.UseFont = True
        Me.Txt_Vendedor.Size = New System.Drawing.Size(53, 22)
        Me.Txt_Vendedor.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(29, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Vendedor"
        '
        'Txt_NombreVendedor
        '
        Me.Txt_NombreVendedor.Enabled = False
        Me.Txt_NombreVendedor.Location = New System.Drawing.Point(172, 36)
        Me.Txt_NombreVendedor.Name = "Txt_NombreVendedor"
        Me.Txt_NombreVendedor.Properties.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_NombreVendedor.Properties.Appearance.Options.UseFont = True
        Me.Txt_NombreVendedor.Size = New System.Drawing.Size(243, 22)
        Me.Txt_NombreVendedor.TabIndex = 4
        '
        'Lbl_Cajero
        '
        Me.Lbl_Cajero.AutoSize = True
        Me.Lbl_Cajero.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Cajero.Location = New System.Drawing.Point(29, 96)
        Me.Lbl_Cajero.Name = "Lbl_Cajero"
        Me.Lbl_Cajero.Size = New System.Drawing.Size(24, 20)
        Me.Lbl_Cajero.TabIndex = 6
        Me.Lbl_Cajero.Text = "..."
        '
        'Txt_Sucursal
        '
        Me.Txt_Sucursal.AutoSize = True
        Me.Txt_Sucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Sucursal.Location = New System.Drawing.Point(29, 125)
        Me.Txt_Sucursal.Name = "Txt_Sucursal"
        Me.Txt_Sucursal.Size = New System.Drawing.Size(24, 20)
        Me.Txt_Sucursal.TabIndex = 7
        Me.Txt_Sucursal.Text = "..."
        '
        'Cmd_Limpiar
        '
        Me.Cmd_Limpiar.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.LIMPIAR_FILTROS
        Me.Cmd_Limpiar.Location = New System.Drawing.Point(147, 182)
        Me.Cmd_Limpiar.Name = "Cmd_Limpiar"
        Me.Cmd_Limpiar.Size = New System.Drawing.Size(75, 28)
        Me.Cmd_Limpiar.TabIndex = 8
        Me.Cmd_Limpiar.Text = "&Iniciar"
        Me.Cmd_Limpiar.ToolTip = "Comenzar proceso de Venta"
        '
        'Cmd_Aceptar
        '
        Me.Cmd_Aceptar.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Cmd_Aceptar.Location = New System.Drawing.Point(228, 182)
        Me.Cmd_Aceptar.Name = "Cmd_Aceptar"
        Me.Cmd_Aceptar.Size = New System.Drawing.Size(75, 28)
        Me.Cmd_Aceptar.TabIndex = 5
        Me.Cmd_Aceptar.Text = "&Aceptar"
        Me.Cmd_Aceptar.ToolTip = "Comenzar proceso de Venta"
        '
        'frmFirmaPV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(444, 222)
        Me.Controls.Add(Me.Cmd_Limpiar)
        Me.Controls.Add(Me.Txt_Sucursal)
        Me.Controls.Add(Me.Lbl_Cajero)
        Me.Controls.Add(Me.Cmd_Aceptar)
        Me.Controls.Add(Me.Txt_NombreVendedor)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Txt_Vendedor)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFirmaPV"
        Me.Text = "Venta"
        CType(Me.Txt_Vendedor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_NombreVendedor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Txt_Vendedor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents Txt_NombreVendedor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Cmd_Aceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Lbl_Cajero As Label
    Friend WithEvents Txt_Sucursal As Label
    Friend WithEvents Cmd_Limpiar As DevExpress.XtraEditors.SimpleButton
End Class
