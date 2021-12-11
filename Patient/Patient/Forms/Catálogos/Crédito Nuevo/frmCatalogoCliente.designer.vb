<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCatalogoCliente
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
        Me.Pnl_Botones = New DevExpress.XtraEditors.PanelControl()
        Me.Btn_Cancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_Aceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.Pnl_DatosGenerales = New DevExpress.XtraEditors.PanelControl()
        Me.Cmb_Sexo = New System.Windows.Forms.ComboBox()
        Me.Lbl_Nombre = New DevExpress.XtraEditors.LabelControl()
        Me.Lbl_ApllidoM = New DevExpress.XtraEditors.LabelControl()
        Me.Lbl_ApellidoP = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_Nombre = New DevExpress.XtraEditors.TextEdit()
        Me.Txt_ApellidoMa = New DevExpress.XtraEditors.TextEdit()
        Me.Txt_ApellidoPa = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.Lbl_Sucursal = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_Cliente = New DevExpress.XtraEditors.TextEdit()
        Me.Lbl_Cliente = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_Sucursal = New DevExpress.XtraEditors.TextEdit()
        Me.Txt_Email = New DevExpress.XtraEditors.TextEdit()
        Me.Lbl_Email = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_Telef = New DevExpress.XtraEditors.TextEdit()
        Me.Lbl_Movil = New DevExpress.XtraEditors.LabelControl()
        Me.Lbl_Estado = New DevExpress.XtraEditors.LabelControl()
        Me.Lbl_Ciudad = New DevExpress.XtraEditors.LabelControl()
        Me.Lbl_Colonia = New DevExpress.XtraEditors.LabelControl()
        Me.Lbl_CP = New DevExpress.XtraEditors.LabelControl()
        Me.Lbl_Calle = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_Calle = New DevExpress.XtraEditors.TextEdit()
        Me.Lbl_Numero = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_Numero = New DevExpress.XtraEditors.TextEdit()
        Me.Pnl_DomicilioPart = New DevExpress.XtraEditors.PanelControl()
        Me.Cmb_CP = New System.Windows.Forms.ComboBox()
        Me.Cmb_Estado = New System.Windows.Forms.ComboBox()
        Me.Cmb_Ciudad = New System.Windows.Forms.ComboBox()
        Me.Cmb_Colonia = New System.Windows.Forms.ComboBox()
        Me.Pnl_Contacto = New DevExpress.XtraEditors.PanelControl()
        CType(Me.Pnl_Botones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_Botones.SuspendLayout()
        CType(Me.Pnl_DatosGenerales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_DatosGenerales.SuspendLayout()
        CType(Me.Txt_Nombre.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_ApellidoMa.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_ApellidoPa.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_Cliente.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_Sucursal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_Email.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_Telef.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_Calle.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_Numero.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pnl_DomicilioPart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_DomicilioPart.SuspendLayout()
        CType(Me.Pnl_Contacto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_Contacto.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.AutoSize = True
        Me.Pnl_Botones.Controls.Add(Me.Btn_Cancelar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Aceptar)
        Me.Pnl_Botones.Location = New System.Drawing.Point(6, 176)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(1062, 58)
        Me.Pnl_Botones.TabIndex = 13
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Cancelar.Image = Global.SIRCO.My.Resources.Resources.dialog_close
        Me.Btn_Cancelar.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.Btn_Cancelar.Location = New System.Drawing.Point(958, 2)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(51, 54)
        Me.Btn_Cancelar.TabIndex = 14
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Aceptar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_Aceptar.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.Btn_Aceptar.Location = New System.Drawing.Point(1009, 2)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(51, 54)
        Me.Btn_Aceptar.TabIndex = 15
        '
        'Pnl_DatosGenerales
        '
        Me.Pnl_DatosGenerales.AutoSize = True
        Me.Pnl_DatosGenerales.Controls.Add(Me.Cmb_Sexo)
        Me.Pnl_DatosGenerales.Controls.Add(Me.Lbl_Nombre)
        Me.Pnl_DatosGenerales.Controls.Add(Me.Lbl_ApllidoM)
        Me.Pnl_DatosGenerales.Controls.Add(Me.Lbl_ApellidoP)
        Me.Pnl_DatosGenerales.Controls.Add(Me.Txt_Nombre)
        Me.Pnl_DatosGenerales.Controls.Add(Me.Txt_ApellidoMa)
        Me.Pnl_DatosGenerales.Controls.Add(Me.Txt_ApellidoPa)
        Me.Pnl_DatosGenerales.Controls.Add(Me.LabelControl1)
        Me.Pnl_DatosGenerales.Location = New System.Drawing.Point(6, 32)
        Me.Pnl_DatosGenerales.Name = "Pnl_DatosGenerales"
        Me.Pnl_DatosGenerales.Size = New System.Drawing.Size(1062, 51)
        Me.Pnl_DatosGenerales.TabIndex = 1
        '
        'Cmb_Sexo
        '
        Me.Cmb_Sexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Sexo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Sexo.FormattingEnabled = True
        Me.Cmb_Sexo.Items.AddRange(New Object() {"FEMENINO", "MASCULINO"})
        Me.Cmb_Sexo.Location = New System.Drawing.Point(881, 6)
        Me.Cmb_Sexo.Name = "Cmb_Sexo"
        Me.Cmb_Sexo.Size = New System.Drawing.Size(145, 21)
        Me.Cmb_Sexo.TabIndex = 4
        '
        'Lbl_Nombre
        '
        Me.Lbl_Nombre.Location = New System.Drawing.Point(5, 9)
        Me.Lbl_Nombre.Name = "Lbl_Nombre"
        Me.Lbl_Nombre.Size = New System.Drawing.Size(37, 13)
        Me.Lbl_Nombre.TabIndex = 1
        Me.Lbl_Nombre.Text = "Nombre"
        '
        'Lbl_ApllidoM
        '
        Me.Lbl_ApllidoM.Location = New System.Drawing.Point(557, 9)
        Me.Lbl_ApllidoM.Name = "Lbl_ApllidoM"
        Me.Lbl_ApllidoM.Size = New System.Drawing.Size(80, 13)
        Me.Lbl_ApllidoM.TabIndex = 3
        Me.Lbl_ApllidoM.Text = "Apellido Materno"
        '
        'Lbl_ApellidoP
        '
        Me.Lbl_ApellidoP.Location = New System.Drawing.Point(262, 11)
        Me.Lbl_ApellidoP.Name = "Lbl_ApellidoP"
        Me.Lbl_ApellidoP.Size = New System.Drawing.Size(78, 13)
        Me.Lbl_ApellidoP.TabIndex = 2
        Me.Lbl_ApellidoP.Text = "Apellido Paterno"
        '
        'Txt_Nombre
        '
        Me.Txt_Nombre.Location = New System.Drawing.Point(53, 6)
        Me.Txt_Nombre.Name = "Txt_Nombre"
        Me.Txt_Nombre.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Nombre.Properties.Appearance.Options.UseFont = True
        Me.Txt_Nombre.Properties.MaxLength = 100
        Me.Txt_Nombre.Size = New System.Drawing.Size(188, 20)
        Me.Txt_Nombre.TabIndex = 1
        '
        'Txt_ApellidoMa
        '
        Me.Txt_ApellidoMa.Location = New System.Drawing.Point(643, 6)
        Me.Txt_ApellidoMa.Name = "Txt_ApellidoMa"
        Me.Txt_ApellidoMa.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ApellidoMa.Properties.Appearance.Options.UseFont = True
        Me.Txt_ApellidoMa.Properties.MaxLength = 100
        Me.Txt_ApellidoMa.Size = New System.Drawing.Size(188, 20)
        Me.Txt_ApellidoMa.TabIndex = 3
        '
        'Txt_ApellidoPa
        '
        Me.Txt_ApellidoPa.Location = New System.Drawing.Point(346, 6)
        Me.Txt_ApellidoPa.Name = "Txt_ApellidoPa"
        Me.Txt_ApellidoPa.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ApellidoPa.Properties.Appearance.Options.UseFont = True
        Me.Txt_ApellidoPa.Properties.MaxLength = 100
        Me.Txt_ApellidoPa.Size = New System.Drawing.Size(188, 20)
        Me.Txt_ApellidoPa.TabIndex = 2
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(851, 9)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl1.TabIndex = 4
        Me.LabelControl1.Text = "Sexo"
        '
        'Lbl_Sucursal
        '
        Me.Lbl_Sucursal.Location = New System.Drawing.Point(11, 9)
        Me.Lbl_Sucursal.Name = "Lbl_Sucursal"
        Me.Lbl_Sucursal.Size = New System.Drawing.Size(40, 13)
        Me.Lbl_Sucursal.TabIndex = 7
        Me.Lbl_Sucursal.Text = "Sucursal"
        '
        'Txt_Cliente
        '
        Me.Txt_Cliente.Location = New System.Drawing.Point(187, 6)
        Me.Txt_Cliente.Name = "Txt_Cliente"
        Me.Txt_Cliente.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Cliente.Properties.Appearance.Options.UseFont = True
        Me.Txt_Cliente.Properties.MaxLength = 100
        Me.Txt_Cliente.Size = New System.Drawing.Size(66, 20)
        Me.Txt_Cliente.TabIndex = 6
        '
        'Lbl_Cliente
        '
        Me.Lbl_Cliente.Location = New System.Drawing.Point(148, 9)
        Me.Lbl_Cliente.Name = "Lbl_Cliente"
        Me.Lbl_Cliente.Size = New System.Drawing.Size(33, 13)
        Me.Lbl_Cliente.TabIndex = 5
        Me.Lbl_Cliente.Text = "Cliente"
        '
        'Txt_Sucursal
        '
        Me.Txt_Sucursal.Location = New System.Drawing.Point(59, 6)
        Me.Txt_Sucursal.Name = "Txt_Sucursal"
        Me.Txt_Sucursal.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Sucursal.Properties.Appearance.Options.UseFont = True
        Me.Txt_Sucursal.Properties.MaxLength = 100
        Me.Txt_Sucursal.Size = New System.Drawing.Size(82, 20)
        Me.Txt_Sucursal.TabIndex = 8
        '
        'Txt_Email
        '
        Me.Txt_Email.Location = New System.Drawing.Point(52, 48)
        Me.Txt_Email.Name = "Txt_Email"
        Me.Txt_Email.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Txt_Email.Properties.Appearance.Options.UseFont = True
        Me.Txt_Email.Properties.MaxLength = 150
        Me.Txt_Email.Size = New System.Drawing.Size(225, 20)
        Me.Txt_Email.TabIndex = 12
        '
        'Lbl_Email
        '
        Me.Lbl_Email.Location = New System.Drawing.Point(5, 51)
        Me.Lbl_Email.Name = "Lbl_Email"
        Me.Lbl_Email.Size = New System.Drawing.Size(24, 13)
        Me.Lbl_Email.TabIndex = 12
        Me.Lbl_Email.Text = "Email"
        '
        'Txt_Telef
        '
        Me.Txt_Telef.Location = New System.Drawing.Point(52, 13)
        Me.Txt_Telef.Name = "Txt_Telef"
        Me.Txt_Telef.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Txt_Telef.Properties.Appearance.Options.UseFont = True
        Me.Txt_Telef.Properties.MaxLength = 10
        Me.Txt_Telef.Size = New System.Drawing.Size(151, 20)
        Me.Txt_Telef.TabIndex = 11
        '
        'Lbl_Movil
        '
        Me.Lbl_Movil.Location = New System.Drawing.Point(5, 16)
        Me.Lbl_Movil.Name = "Lbl_Movil"
        Me.Lbl_Movil.Size = New System.Drawing.Size(41, 13)
        Me.Lbl_Movil.TabIndex = 11
        Me.Lbl_Movil.Text = "Tel Móvil"
        '
        'Lbl_Estado
        '
        Me.Lbl_Estado.Location = New System.Drawing.Point(492, 42)
        Me.Lbl_Estado.Name = "Lbl_Estado"
        Me.Lbl_Estado.Size = New System.Drawing.Size(33, 13)
        Me.Lbl_Estado.TabIndex = 10
        Me.Lbl_Estado.Text = "Estado"
        '
        'Lbl_Ciudad
        '
        Me.Lbl_Ciudad.Location = New System.Drawing.Point(253, 43)
        Me.Lbl_Ciudad.Name = "Lbl_Ciudad"
        Me.Lbl_Ciudad.Size = New System.Drawing.Size(33, 13)
        Me.Lbl_Ciudad.TabIndex = 9
        Me.Lbl_Ciudad.Text = "Ciudad"
        '
        'Lbl_Colonia
        '
        Me.Lbl_Colonia.Location = New System.Drawing.Point(10, 42)
        Me.Lbl_Colonia.Name = "Lbl_Colonia"
        Me.Lbl_Colonia.Size = New System.Drawing.Size(35, 13)
        Me.Lbl_Colonia.TabIndex = 8
        Me.Lbl_Colonia.Text = "Colonia"
        '
        'Lbl_CP
        '
        Me.Lbl_CP.Location = New System.Drawing.Point(516, 16)
        Me.Lbl_CP.Name = "Lbl_CP"
        Me.Lbl_CP.Size = New System.Drawing.Size(65, 13)
        Me.Lbl_CP.TabIndex = 7
        Me.Lbl_CP.Text = "Código Postal"
        '
        'Lbl_Calle
        '
        Me.Lbl_Calle.Location = New System.Drawing.Point(10, 16)
        Me.Lbl_Calle.Name = "Lbl_Calle"
        Me.Lbl_Calle.Size = New System.Drawing.Size(23, 13)
        Me.Lbl_Calle.TabIndex = 5
        Me.Lbl_Calle.Text = "Calle"
        '
        'Txt_Calle
        '
        Me.Txt_Calle.Location = New System.Drawing.Point(53, 13)
        Me.Txt_Calle.Name = "Txt_Calle"
        Me.Txt_Calle.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Txt_Calle.Properties.Appearance.Options.UseFont = True
        Me.Txt_Calle.Size = New System.Drawing.Size(344, 20)
        Me.Txt_Calle.TabIndex = 5
        '
        'Lbl_Numero
        '
        Me.Lbl_Numero.Location = New System.Drawing.Point(403, 16)
        Me.Lbl_Numero.Name = "Lbl_Numero"
        Me.Lbl_Numero.Size = New System.Drawing.Size(37, 13)
        Me.Lbl_Numero.TabIndex = 6
        Me.Lbl_Numero.Text = "Número"
        '
        'Txt_Numero
        '
        Me.Txt_Numero.Location = New System.Drawing.Point(446, 13)
        Me.Txt_Numero.Name = "Txt_Numero"
        Me.Txt_Numero.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Txt_Numero.Properties.Appearance.Options.UseFont = True
        Me.Txt_Numero.Properties.MaxLength = 2
        Me.Txt_Numero.Size = New System.Drawing.Size(59, 20)
        Me.Txt_Numero.TabIndex = 6
        '
        'Pnl_DomicilioPart
        '
        Me.Pnl_DomicilioPart.AutoSize = True
        Me.Pnl_DomicilioPart.Controls.Add(Me.Cmb_CP)
        Me.Pnl_DomicilioPart.Controls.Add(Me.Cmb_Estado)
        Me.Pnl_DomicilioPart.Controls.Add(Me.Cmb_Ciudad)
        Me.Pnl_DomicilioPart.Controls.Add(Me.Cmb_Colonia)
        Me.Pnl_DomicilioPart.Controls.Add(Me.Lbl_Calle)
        Me.Pnl_DomicilioPart.Controls.Add(Me.Lbl_CP)
        Me.Pnl_DomicilioPart.Controls.Add(Me.Lbl_Colonia)
        Me.Pnl_DomicilioPart.Controls.Add(Me.Lbl_Numero)
        Me.Pnl_DomicilioPart.Controls.Add(Me.Lbl_Ciudad)
        Me.Pnl_DomicilioPart.Controls.Add(Me.Txt_Numero)
        Me.Pnl_DomicilioPart.Controls.Add(Me.Lbl_Estado)
        Me.Pnl_DomicilioPart.Controls.Add(Me.Txt_Calle)
        Me.Pnl_DomicilioPart.Location = New System.Drawing.Point(6, 87)
        Me.Pnl_DomicilioPart.Name = "Pnl_DomicilioPart"
        Me.Pnl_DomicilioPart.Size = New System.Drawing.Size(743, 83)
        Me.Pnl_DomicilioPart.TabIndex = 5
        '
        'Cmb_CP
        '
        Me.Cmb_CP.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_CP.FormattingEnabled = True
        Me.Cmb_CP.Location = New System.Drawing.Point(593, 13)
        Me.Cmb_CP.MaxLength = 5
        Me.Cmb_CP.Name = "Cmb_CP"
        Me.Cmb_CP.Size = New System.Drawing.Size(132, 21)
        Me.Cmb_CP.TabIndex = 7
        '
        'Cmb_Estado
        '
        Me.Cmb_Estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Estado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Estado.FormattingEnabled = True
        Me.Cmb_Estado.Location = New System.Drawing.Point(531, 39)
        Me.Cmb_Estado.Name = "Cmb_Estado"
        Me.Cmb_Estado.Size = New System.Drawing.Size(194, 21)
        Me.Cmb_Estado.TabIndex = 10
        '
        'Cmb_Ciudad
        '
        Me.Cmb_Ciudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Ciudad.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Ciudad.FormattingEnabled = True
        Me.Cmb_Ciudad.Location = New System.Drawing.Point(292, 39)
        Me.Cmb_Ciudad.Name = "Cmb_Ciudad"
        Me.Cmb_Ciudad.Size = New System.Drawing.Size(194, 21)
        Me.Cmb_Ciudad.TabIndex = 9
        '
        'Cmb_Colonia
        '
        Me.Cmb_Colonia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Colonia.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Colonia.FormattingEnabled = True
        Me.Cmb_Colonia.Location = New System.Drawing.Point(53, 39)
        Me.Cmb_Colonia.Name = "Cmb_Colonia"
        Me.Cmb_Colonia.Size = New System.Drawing.Size(194, 21)
        Me.Cmb_Colonia.TabIndex = 8
        '
        'Pnl_Contacto
        '
        Me.Pnl_Contacto.AutoSize = True
        Me.Pnl_Contacto.Controls.Add(Me.Txt_Telef)
        Me.Pnl_Contacto.Controls.Add(Me.Lbl_Movil)
        Me.Pnl_Contacto.Controls.Add(Me.Txt_Email)
        Me.Pnl_Contacto.Controls.Add(Me.Lbl_Email)
        Me.Pnl_Contacto.Location = New System.Drawing.Point(755, 87)
        Me.Pnl_Contacto.Name = "Pnl_Contacto"
        Me.Pnl_Contacto.Size = New System.Drawing.Size(313, 83)
        Me.Pnl_Contacto.TabIndex = 11
        '
        'frmCatalogoCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1071, 246)
        Me.Controls.Add(Me.Pnl_Contacto)
        Me.Controls.Add(Me.Lbl_Sucursal)
        Me.Controls.Add(Me.Pnl_DomicilioPart)
        Me.Controls.Add(Me.Pnl_DatosGenerales)
        Me.Controls.Add(Me.Txt_Cliente)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Controls.Add(Me.Txt_Sucursal)
        Me.Controls.Add(Me.Lbl_Cliente)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCatalogoCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catálogo Clientes"
        CType(Me.Pnl_Botones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_Botones.ResumeLayout(False)
        CType(Me.Pnl_DatosGenerales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_DatosGenerales.ResumeLayout(False)
        Me.Pnl_DatosGenerales.PerformLayout()
        CType(Me.Txt_Nombre.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_ApellidoMa.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_ApellidoPa.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_Cliente.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_Sucursal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_Email.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_Telef.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_Calle.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_Numero.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pnl_DomicilioPart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_DomicilioPart.ResumeLayout(False)
        Me.Pnl_DomicilioPart.PerformLayout()
        CType(Me.Pnl_Contacto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_Contacto.ResumeLayout(False)
        Me.Pnl_Contacto.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Pnl_Botones As DevExpress.XtraEditors.PanelControl
    Friend WithEvents Btn_Cancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_Aceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Pnl_DatosGenerales As DevExpress.XtraEditors.PanelControl
    Friend WithEvents Txt_ApellidoPa As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Txt_ApellidoMa As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Txt_Nombre As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Lbl_ApellidoP As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Lbl_ApllidoM As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Lbl_Nombre As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_Numero As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Lbl_Numero As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_Calle As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Lbl_Calle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Lbl_CP As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Lbl_Estado As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Lbl_Ciudad As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Lbl_Colonia As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_Email As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Lbl_Email As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_Telef As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Lbl_Movil As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Pnl_DomicilioPart As DevExpress.XtraEditors.PanelControl
    Friend WithEvents Pnl_Contacto As DevExpress.XtraEditors.PanelControl
    Friend WithEvents Cmb_Estado As ComboBox
    Friend WithEvents Cmb_Ciudad As ComboBox
    Friend WithEvents Cmb_Colonia As ComboBox
    Friend WithEvents Lbl_Sucursal As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_Sucursal As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Lbl_Cliente As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_Cliente As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Cmb_Sexo As ComboBox
    Friend WithEvents Cmb_CP As ComboBox
End Class
