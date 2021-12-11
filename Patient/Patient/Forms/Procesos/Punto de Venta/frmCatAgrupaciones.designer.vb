<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCatAgrupaciones
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.gc_Agrupaciones = New DevExpress.XtraGrid.GridControl()
        Me.dgv_Agrupaciones = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.btn_Salir = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_Consultar = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_Modificar = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_Nuevo = New DevExpress.XtraEditors.SimpleButton()
        Me.tc_Agrupaciones = New DevExpress.XtraTab.XtraTabControl()
        Me.tp_Agrupaciones = New DevExpress.XtraTab.XtraTabPage()
        Me.tp_Detallado = New DevExpress.XtraTab.XtraTabPage()
        Me.gc_AgrupacionesDet = New DevExpress.XtraGrid.GridControl()
        Me.dgv_AgrupacionesDet = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.btn_EliminarDet = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_Excel = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_Regresar = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_ConsultarDet = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_ModificarDet = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_AgregarDet = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.btn_Guardar = New DevExpress.XtraEditors.SimpleButton()
        Me.dt_Fecha = New DevExpress.XtraEditors.DateEdit()
        Me.lbl_FechaAgrupacion = New DevExpress.XtraEditors.LabelControl()
        Me.txt_NombreAgrupacion = New DevExpress.XtraEditors.TextEdit()
        Me.lbl_NombreAgrupacion = New DevExpress.XtraEditors.LabelControl()
        Me.txt_Agrupacion = New DevExpress.XtraEditors.TextEdit()
        Me.lbl_FUM = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_IdAgrupacion = New DevExpress.XtraEditors.LabelControl()
        Me.txt_FUM = New DevExpress.XtraEditors.TextEdit()
        Me.txt_IdUsuario = New DevExpress.XtraEditors.TextEdit()
        Me.lbl_Usuario = New DevExpress.XtraEditors.LabelControl()
        CType(Me.gc_Agrupaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_Agrupaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.tc_Agrupaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tc_Agrupaciones.SuspendLayout()
        Me.tp_Agrupaciones.SuspendLayout()
        Me.tp_Detallado.SuspendLayout()
        CType(Me.gc_AgrupacionesDet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_AgrupacionesDet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.dt_Fecha.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_Fecha.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_NombreAgrupacion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Agrupacion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_FUM.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_IdUsuario.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gc_Agrupaciones
        '
        Me.gc_Agrupaciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gc_Agrupaciones.Location = New System.Drawing.Point(0, 0)
        Me.gc_Agrupaciones.MainView = Me.dgv_Agrupaciones
        Me.gc_Agrupaciones.Name = "gc_Agrupaciones"
        Me.gc_Agrupaciones.Size = New System.Drawing.Size(854, 249)
        Me.gc_Agrupaciones.TabIndex = 0
        Me.gc_Agrupaciones.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.dgv_Agrupaciones})
        '
        'dgv_Agrupaciones
        '
        Me.dgv_Agrupaciones.Appearance.HeaderPanel.BackColor = System.Drawing.Color.MediumTurquoise
        Me.dgv_Agrupaciones.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgv_Agrupaciones.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black
        Me.dgv_Agrupaciones.Appearance.HeaderPanel.Options.UseBackColor = True
        Me.dgv_Agrupaciones.Appearance.HeaderPanel.Options.UseFont = True
        Me.dgv_Agrupaciones.Appearance.HeaderPanel.Options.UseForeColor = True
        Me.dgv_Agrupaciones.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgv_Agrupaciones.AppearancePrint.EvenRow.Options.UseFont = True
        Me.dgv_Agrupaciones.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.MediumTurquoise
        Me.dgv_Agrupaciones.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgv_Agrupaciones.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.dgv_Agrupaciones.AppearancePrint.HeaderPanel.Options.UseFont = True
        Me.dgv_Agrupaciones.GridControl = Me.gc_Agrupaciones
        Me.dgv_Agrupaciones.Name = "dgv_Agrupaciones"
        Me.dgv_Agrupaciones.OptionsBehavior.Editable = False
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.btn_Salir)
        Me.PanelControl1.Controls.Add(Me.btn_Consultar)
        Me.PanelControl1.Controls.Add(Me.btn_Modificar)
        Me.PanelControl1.Controls.Add(Me.btn_Nuevo)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 277)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(860, 58)
        Me.PanelControl1.TabIndex = 1
        '
        'btn_Salir
        '
        Me.btn_Salir.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Salir.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.door_out
        Me.btn_Salir.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Salir.Location = New System.Drawing.Point(809, 2)
        Me.btn_Salir.Name = "btn_Salir"
        Me.btn_Salir.Size = New System.Drawing.Size(49, 54)
        Me.btn_Salir.TabIndex = 3
        Me.btn_Salir.ToolTip = "Salir"
        '
        'btn_Consultar
        '
        Me.btn_Consultar.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_Consultar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Consultar.ImageOptions.ImageUri.Uri = "Preview"
        Me.btn_Consultar.Location = New System.Drawing.Point(114, 2)
        Me.btn_Consultar.Name = "btn_Consultar"
        Me.btn_Consultar.Size = New System.Drawing.Size(56, 54)
        Me.btn_Consultar.TabIndex = 2
        Me.btn_Consultar.ToolTip = "Consultar"
        '
        'btn_Modificar
        '
        Me.btn_Modificar.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_Modificar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Modificar.ImageOptions.ImageUri.Uri = "Edit"
        Me.btn_Modificar.Location = New System.Drawing.Point(58, 2)
        Me.btn_Modificar.Name = "btn_Modificar"
        Me.btn_Modificar.Size = New System.Drawing.Size(56, 54)
        Me.btn_Modificar.TabIndex = 1
        Me.btn_Modificar.ToolTip = "Editar"
        '
        'btn_Nuevo
        '
        Me.btn_Nuevo.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_Nuevo.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.new_20doc
        Me.btn_Nuevo.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Nuevo.ImageOptions.ImageUri.Uri = "AddItem"
        Me.btn_Nuevo.Location = New System.Drawing.Point(2, 2)
        Me.btn_Nuevo.Name = "btn_Nuevo"
        Me.btn_Nuevo.Size = New System.Drawing.Size(56, 54)
        Me.btn_Nuevo.TabIndex = 0
        Me.btn_Nuevo.ToolTip = "Nuevo"
        '
        'tc_Agrupaciones
        '
        Me.tc_Agrupaciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tc_Agrupaciones.Location = New System.Drawing.Point(0, 0)
        Me.tc_Agrupaciones.Name = "tc_Agrupaciones"
        Me.tc_Agrupaciones.SelectedTabPage = Me.tp_Agrupaciones
        Me.tc_Agrupaciones.Size = New System.Drawing.Size(860, 277)
        Me.tc_Agrupaciones.TabIndex = 0
        Me.tc_Agrupaciones.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tp_Agrupaciones, Me.tp_Detallado})
        '
        'tp_Agrupaciones
        '
        Me.tp_Agrupaciones.Controls.Add(Me.gc_Agrupaciones)
        Me.tp_Agrupaciones.Name = "tp_Agrupaciones"
        Me.tp_Agrupaciones.Size = New System.Drawing.Size(854, 249)
        Me.tp_Agrupaciones.Text = "Agrupaciones"
        '
        'tp_Detallado
        '
        Me.tp_Detallado.Controls.Add(Me.gc_AgrupacionesDet)
        Me.tp_Detallado.Controls.Add(Me.PanelControl3)
        Me.tp_Detallado.Controls.Add(Me.PanelControl2)
        Me.tp_Detallado.Name = "tp_Detallado"
        Me.tp_Detallado.Size = New System.Drawing.Size(854, 249)
        Me.tp_Detallado.Text = "Detallado"
        '
        'gc_AgrupacionesDet
        '
        Me.gc_AgrupacionesDet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gc_AgrupacionesDet.Location = New System.Drawing.Point(0, 79)
        Me.gc_AgrupacionesDet.MainView = Me.dgv_AgrupacionesDet
        Me.gc_AgrupacionesDet.Name = "gc_AgrupacionesDet"
        Me.gc_AgrupacionesDet.Size = New System.Drawing.Size(854, 130)
        Me.gc_AgrupacionesDet.TabIndex = 0
        Me.gc_AgrupacionesDet.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.dgv_AgrupacionesDet})
        '
        'dgv_AgrupacionesDet
        '
        Me.dgv_AgrupacionesDet.Appearance.HeaderPanel.BackColor = System.Drawing.Color.PaleTurquoise
        Me.dgv_AgrupacionesDet.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgv_AgrupacionesDet.Appearance.HeaderPanel.Options.UseBackColor = True
        Me.dgv_AgrupacionesDet.Appearance.HeaderPanel.Options.UseFont = True
        Me.dgv_AgrupacionesDet.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.LightSeaGreen
        Me.dgv_AgrupacionesDet.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgv_AgrupacionesDet.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.dgv_AgrupacionesDet.AppearancePrint.HeaderPanel.Options.UseFont = True
        Me.dgv_AgrupacionesDet.AppearancePrint.Lines.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgv_AgrupacionesDet.AppearancePrint.Lines.Options.UseFont = True
        Me.dgv_AgrupacionesDet.AppearancePrint.Row.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgv_AgrupacionesDet.AppearancePrint.Row.Options.UseFont = True
        Me.dgv_AgrupacionesDet.GridControl = Me.gc_AgrupacionesDet
        Me.dgv_AgrupacionesDet.Name = "dgv_AgrupacionesDet"
        Me.dgv_AgrupacionesDet.OptionsBehavior.Editable = False
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.btn_EliminarDet)
        Me.PanelControl3.Controls.Add(Me.btn_Excel)
        Me.PanelControl3.Controls.Add(Me.btn_Regresar)
        Me.PanelControl3.Controls.Add(Me.btn_ConsultarDet)
        Me.PanelControl3.Controls.Add(Me.btn_ModificarDet)
        Me.PanelControl3.Controls.Add(Me.btn_AgregarDet)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl3.Location = New System.Drawing.Point(0, 209)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(854, 40)
        Me.PanelControl3.TabIndex = 33
        '
        'btn_EliminarDet
        '
        Me.btn_EliminarDet.Location = New System.Drawing.Point(247, 7)
        Me.btn_EliminarDet.Name = "btn_EliminarDet"
        Me.btn_EliminarDet.Size = New System.Drawing.Size(75, 23)
        Me.btn_EliminarDet.TabIndex = 3
        Me.btn_EliminarDet.Text = "Eliminar"
        Me.btn_EliminarDet.ToolTip = "Consultar estructura"
        '
        'btn_Excel
        '
        Me.btn_Excel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_Excel.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Excel.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.table_excel
        Me.btn_Excel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Excel.Location = New System.Drawing.Point(738, 2)
        Me.btn_Excel.Name = "btn_Excel"
        Me.btn_Excel.Size = New System.Drawing.Size(57, 36)
        Me.btn_Excel.TabIndex = 4
        Me.btn_Excel.ToolTip = "Importar Excel"
        '
        'btn_Regresar
        '
        Me.btn_Regresar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Regresar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Regresar.ImageOptions.ImageUri.Uri = "Reset"
        Me.btn_Regresar.Location = New System.Drawing.Point(795, 2)
        Me.btn_Regresar.Name = "btn_Regresar"
        Me.btn_Regresar.Size = New System.Drawing.Size(57, 36)
        Me.btn_Regresar.TabIndex = 5
        Me.btn_Regresar.ToolTip = "Regresar"
        '
        'btn_ConsultarDet
        '
        Me.btn_ConsultarDet.Location = New System.Drawing.Point(166, 7)
        Me.btn_ConsultarDet.Name = "btn_ConsultarDet"
        Me.btn_ConsultarDet.Size = New System.Drawing.Size(75, 23)
        Me.btn_ConsultarDet.TabIndex = 2
        Me.btn_ConsultarDet.Text = "Consultar"
        Me.btn_ConsultarDet.ToolTip = "Consultar estructura"
        '
        'btn_ModificarDet
        '
        Me.btn_ModificarDet.Location = New System.Drawing.Point(85, 7)
        Me.btn_ModificarDet.Name = "btn_ModificarDet"
        Me.btn_ModificarDet.Size = New System.Drawing.Size(75, 23)
        Me.btn_ModificarDet.TabIndex = 1
        Me.btn_ModificarDet.Text = "Modificar"
        Me.btn_ModificarDet.ToolTip = "Modificar estructura"
        '
        'btn_AgregarDet
        '
        Me.btn_AgregarDet.Location = New System.Drawing.Point(4, 7)
        Me.btn_AgregarDet.Name = "btn_AgregarDet"
        Me.btn_AgregarDet.Size = New System.Drawing.Size(75, 23)
        Me.btn_AgregarDet.TabIndex = 0
        Me.btn_AgregarDet.Text = "Agregar"
        Me.btn_AgregarDet.ToolTip = "Agregar nueva estructura"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.btn_Guardar)
        Me.PanelControl2.Controls.Add(Me.dt_Fecha)
        Me.PanelControl2.Controls.Add(Me.lbl_FechaAgrupacion)
        Me.PanelControl2.Controls.Add(Me.txt_NombreAgrupacion)
        Me.PanelControl2.Controls.Add(Me.lbl_NombreAgrupacion)
        Me.PanelControl2.Controls.Add(Me.txt_Agrupacion)
        Me.PanelControl2.Controls.Add(Me.lbl_FUM)
        Me.PanelControl2.Controls.Add(Me.lbl_IdAgrupacion)
        Me.PanelControl2.Controls.Add(Me.txt_FUM)
        Me.PanelControl2.Controls.Add(Me.txt_IdUsuario)
        Me.PanelControl2.Controls.Add(Me.lbl_Usuario)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(854, 79)
        Me.PanelControl2.TabIndex = 32
        '
        'btn_Guardar
        '
        Me.btn_Guardar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Guardar.ImageOptions.ImageUri.Uri = "Apply"
        Me.btn_Guardar.Location = New System.Drawing.Point(523, 17)
        Me.btn_Guardar.Name = "btn_Guardar"
        Me.btn_Guardar.Size = New System.Drawing.Size(51, 44)
        Me.btn_Guardar.TabIndex = 5
        Me.btn_Guardar.ToolTip = "Guardar"
        '
        'dt_Fecha
        '
        Me.dt_Fecha.EditValue = Nothing
        Me.dt_Fecha.Location = New System.Drawing.Point(222, 14)
        Me.dt_Fecha.Name = "dt_Fecha"
        Me.dt_Fecha.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dt_Fecha.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dt_Fecha.Size = New System.Drawing.Size(129, 20)
        Me.dt_Fecha.TabIndex = 2
        '
        'lbl_FechaAgrupacion
        '
        Me.lbl_FechaAgrupacion.Location = New System.Drawing.Point(186, 18)
        Me.lbl_FechaAgrupacion.Name = "lbl_FechaAgrupacion"
        Me.lbl_FechaAgrupacion.Size = New System.Drawing.Size(29, 13)
        Me.lbl_FechaAgrupacion.TabIndex = 34
        Me.lbl_FechaAgrupacion.Text = "Fecha"
        '
        'txt_NombreAgrupacion
        '
        Me.txt_NombreAgrupacion.Location = New System.Drawing.Point(80, 41)
        Me.txt_NombreAgrupacion.Name = "txt_NombreAgrupacion"
        Me.txt_NombreAgrupacion.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_NombreAgrupacion.Properties.MaxLength = 30
        Me.txt_NombreAgrupacion.Size = New System.Drawing.Size(271, 20)
        Me.txt_NombreAgrupacion.TabIndex = 1
        '
        'lbl_NombreAgrupacion
        '
        Me.lbl_NombreAgrupacion.Location = New System.Drawing.Point(37, 44)
        Me.lbl_NombreAgrupacion.Name = "lbl_NombreAgrupacion"
        Me.lbl_NombreAgrupacion.Size = New System.Drawing.Size(37, 13)
        Me.lbl_NombreAgrupacion.TabIndex = 33
        Me.lbl_NombreAgrupacion.Text = "Nombre"
        '
        'txt_Agrupacion
        '
        Me.txt_Agrupacion.Enabled = False
        Me.txt_Agrupacion.Location = New System.Drawing.Point(80, 15)
        Me.txt_Agrupacion.Name = "txt_Agrupacion"
        Me.txt_Agrupacion.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Agrupacion.Size = New System.Drawing.Size(100, 20)
        Me.txt_Agrupacion.TabIndex = 0
        '
        'lbl_FUM
        '
        Me.lbl_FUM.Location = New System.Drawing.Point(372, 44)
        Me.lbl_FUM.Name = "lbl_FUM"
        Me.lbl_FUM.Size = New System.Drawing.Size(21, 13)
        Me.lbl_FUM.TabIndex = 31
        Me.lbl_FUM.Text = "FUM"
        '
        'lbl_IdAgrupacion
        '
        Me.lbl_IdAgrupacion.Location = New System.Drawing.Point(10, 18)
        Me.lbl_IdAgrupacion.Name = "lbl_IdAgrupacion"
        Me.lbl_IdAgrupacion.Size = New System.Drawing.Size(64, 13)
        Me.lbl_IdAgrupacion.TabIndex = 15
        Me.lbl_IdAgrupacion.Text = "IdAgrupacion"
        '
        'txt_FUM
        '
        Me.txt_FUM.Enabled = False
        Me.txt_FUM.Location = New System.Drawing.Point(399, 41)
        Me.txt_FUM.Name = "txt_FUM"
        Me.txt_FUM.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White
        Me.txt_FUM.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
        Me.txt_FUM.Properties.AppearanceDisabled.Options.UseBackColor = True
        Me.txt_FUM.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txt_FUM.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_FUM.Size = New System.Drawing.Size(118, 20)
        Me.txt_FUM.TabIndex = 4
        '
        'txt_IdUsuario
        '
        Me.txt_IdUsuario.Enabled = False
        Me.txt_IdUsuario.Location = New System.Drawing.Point(399, 15)
        Me.txt_IdUsuario.Name = "txt_IdUsuario"
        Me.txt_IdUsuario.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White
        Me.txt_IdUsuario.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
        Me.txt_IdUsuario.Properties.AppearanceDisabled.Options.UseBackColor = True
        Me.txt_IdUsuario.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.txt_IdUsuario.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_IdUsuario.Size = New System.Drawing.Size(118, 20)
        Me.txt_IdUsuario.TabIndex = 3
        '
        'lbl_Usuario
        '
        Me.lbl_Usuario.Location = New System.Drawing.Point(357, 18)
        Me.lbl_Usuario.Name = "lbl_Usuario"
        Me.lbl_Usuario.Size = New System.Drawing.Size(36, 13)
        Me.lbl_Usuario.TabIndex = 29
        Me.lbl_Usuario.Text = "Usuario"
        '
        'frmCatAgrupaciones
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(860, 335)
        Me.Controls.Add(Me.tc_Agrupaciones)
        Me.Controls.Add(Me.PanelControl1)
        Me.KeyPreview = True
        Me.Name = "frmCatAgrupaciones"
        Me.Text = "Agrupaciones"
        CType(Me.gc_Agrupaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_Agrupaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.tc_Agrupaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tc_Agrupaciones.ResumeLayout(False)
        Me.tp_Agrupaciones.ResumeLayout(False)
        Me.tp_Detallado.ResumeLayout(False)
        CType(Me.gc_AgrupacionesDet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_AgrupacionesDet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.dt_Fecha.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_Fecha.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_NombreAgrupacion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Agrupacion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_FUM.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_IdUsuario.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gc_Agrupaciones As DevExpress.XtraGrid.GridControl
    Friend WithEvents dgv_Agrupaciones As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents tc_Agrupaciones As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents tp_Agrupaciones As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tp_Detallado As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents lbl_FUM As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txt_FUM As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbl_Usuario As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txt_IdUsuario As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbl_IdAgrupacion As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txt_Agrupacion As DevExpress.XtraEditors.TextEdit
    Friend WithEvents gc_AgrupacionesDet As DevExpress.XtraGrid.GridControl
    Friend WithEvents dgv_AgrupacionesDet As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btn_ConsultarDet As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_AgregarDet As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btn_Guardar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents dt_Fecha As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lbl_FechaAgrupacion As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txt_NombreAgrupacion As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbl_NombreAgrupacion As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btn_Salir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_Consultar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_Modificar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_Nuevo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_Regresar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_Excel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_ModificarDet As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_EliminarDet As DevExpress.XtraEditors.SimpleButton
End Class
