<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCatCupones
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCatCupones))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.btn_Cancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_Activar = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_Salir = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_Consultar = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_Modificar = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_Nuevo = New DevExpress.XtraEditors.SimpleButton()
        Me.tc_Cupones = New DevExpress.XtraTab.XtraTabControl()
        Me.tp_Cupones = New DevExpress.XtraTab.XtraTabPage()
        Me.gc_Cupones = New DevExpress.XtraGrid.GridControl()
        Me.dgv_Cupones = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.tp_Detallado = New DevExpress.XtraTab.XtraTabPage()
        Me.gc_CuponesDet = New DevExpress.XtraGrid.GridControl()
        Me.dgv_CuponesDet = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.btn_Regresar = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_EliminarDet = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_AgregarDet = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.pb_Imagen = New DevExpress.XtraEditors.PictureEdit()
        Me.cbo_Tipo = New System.Windows.Forms.ComboBox()
        Me.lbl_Tipo = New DevExpress.XtraEditors.LabelControl()
        Me.btn_Guardar = New DevExpress.XtraEditors.SimpleButton()
        Me.lbl_FUM = New DevExpress.XtraEditors.LabelControl()
        Me.txt_FUM = New DevExpress.XtraEditors.TextEdit()
        Me.txt_IdUsuario = New DevExpress.XtraEditors.TextEdit()
        Me.lbl_Usuario = New DevExpress.XtraEditors.LabelControl()
        Me.dt_FecFin = New DevExpress.XtraEditors.DateEdit()
        Me.lbl_FecFin = New DevExpress.XtraEditors.LabelControl()
        Me.dt_FecIni = New DevExpress.XtraEditors.DateEdit()
        Me.lbl_FecIni = New DevExpress.XtraEditors.LabelControl()
        Me.txt_Restricciones = New DevExpress.XtraEditors.MemoEdit()
        Me.txt_Descripcion = New DevExpress.XtraEditors.MemoEdit()
        Me.lbl_Restricciones = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_Descripcion = New DevExpress.XtraEditors.LabelControl()
        Me.txt_Nombre = New DevExpress.XtraEditors.TextEdit()
        Me.lbl_Nombre = New DevExpress.XtraEditors.LabelControl()
        Me.txt_IdCupon = New DevExpress.XtraEditors.TextEdit()
        Me.lbl_IdCupon = New DevExpress.XtraEditors.LabelControl()
        Me.gc_Restricciones = New DevExpress.XtraEditors.GroupControl()
        Me.gc_Restriccion = New DevExpress.XtraGrid.GridControl()
        Me.dgv_Restriccion = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gc_ImagenRestriccion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_DescripcionRestriccion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_UsuarioRestriccion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_FumRestriccion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_Prioridad = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl11 = New DevExpress.XtraEditors.PanelControl()
        Me.btn_DisminuyePrioridad = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_AumentaPrioridad = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_AgregarRestriccion = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_EliminarRestriccion = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.tc_Cupones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tc_Cupones.SuspendLayout()
        Me.tp_Cupones.SuspendLayout()
        CType(Me.gc_Cupones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_Cupones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tp_Detallado.SuspendLayout()
        CType(Me.gc_CuponesDet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_CuponesDet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.pb_Imagen.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_FUM.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_IdUsuario.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_FecFin.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_FecFin.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_FecIni.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_FecIni.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Restricciones.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Descripcion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Nombre.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_IdCupon.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gc_Restricciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gc_Restricciones.SuspendLayout()
        CType(Me.gc_Restriccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_Restriccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl11.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.btn_Cancelar)
        Me.PanelControl1.Controls.Add(Me.btn_Activar)
        Me.PanelControl1.Controls.Add(Me.btn_Salir)
        Me.PanelControl1.Controls.Add(Me.btn_Consultar)
        Me.PanelControl1.Controls.Add(Me.btn_Modificar)
        Me.PanelControl1.Controls.Add(Me.btn_Nuevo)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 363)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(966, 56)
        Me.PanelControl1.TabIndex = 0
        '
        'btn_Cancelar
        '
        Me.btn_Cancelar.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_Cancelar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Cancelar.ImageOptions.ImageUri.Uri = "Cancel"
        Me.btn_Cancelar.Location = New System.Drawing.Point(210, 2)
        Me.btn_Cancelar.Name = "btn_Cancelar"
        Me.btn_Cancelar.Size = New System.Drawing.Size(52, 52)
        Me.btn_Cancelar.TabIndex = 4
        Me.btn_Cancelar.ToolTip = "Cancelar"
        '
        'btn_Activar
        '
        Me.btn_Activar.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_Activar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Activar.ImageOptions.ImageUri.Uri = "Previous"
        Me.btn_Activar.Location = New System.Drawing.Point(158, 2)
        Me.btn_Activar.Name = "btn_Activar"
        Me.btn_Activar.Size = New System.Drawing.Size(52, 52)
        Me.btn_Activar.TabIndex = 3
        Me.btn_Activar.ToolTip = "Activar"
        '
        'btn_Salir
        '
        Me.btn_Salir.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Salir.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.door_out
        Me.btn_Salir.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Salir.Location = New System.Drawing.Point(916, 2)
        Me.btn_Salir.Name = "btn_Salir"
        Me.btn_Salir.Size = New System.Drawing.Size(48, 52)
        Me.btn_Salir.TabIndex = 5
        Me.btn_Salir.ToolTip = "Salir"
        '
        'btn_Consultar
        '
        Me.btn_Consultar.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_Consultar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Consultar.ImageOptions.ImageUri.Uri = "Preview"
        Me.btn_Consultar.Location = New System.Drawing.Point(106, 2)
        Me.btn_Consultar.Name = "btn_Consultar"
        Me.btn_Consultar.Size = New System.Drawing.Size(52, 52)
        Me.btn_Consultar.TabIndex = 2
        Me.btn_Consultar.ToolTip = "Consultar"
        '
        'btn_Modificar
        '
        Me.btn_Modificar.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_Modificar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Modificar.ImageOptions.ImageUri.Uri = "Edit"
        Me.btn_Modificar.Location = New System.Drawing.Point(54, 2)
        Me.btn_Modificar.Name = "btn_Modificar"
        Me.btn_Modificar.Size = New System.Drawing.Size(52, 52)
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
        Me.btn_Nuevo.Size = New System.Drawing.Size(52, 52)
        Me.btn_Nuevo.TabIndex = 0
        Me.btn_Nuevo.ToolTip = "Nuevo"
        '
        'tc_Cupones
        '
        Me.tc_Cupones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tc_Cupones.Location = New System.Drawing.Point(0, 0)
        Me.tc_Cupones.Name = "tc_Cupones"
        Me.tc_Cupones.SelectedTabPage = Me.tp_Cupones
        Me.tc_Cupones.Size = New System.Drawing.Size(966, 363)
        Me.tc_Cupones.TabIndex = 1
        Me.tc_Cupones.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tp_Cupones, Me.tp_Detallado})
        '
        'tp_Cupones
        '
        Me.tp_Cupones.Controls.Add(Me.gc_Cupones)
        Me.tp_Cupones.Name = "tp_Cupones"
        Me.tp_Cupones.Size = New System.Drawing.Size(960, 247)
        Me.tp_Cupones.Text = "Cupones"
        '
        'gc_Cupones
        '
        Me.gc_Cupones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gc_Cupones.Location = New System.Drawing.Point(0, 0)
        Me.gc_Cupones.MainView = Me.dgv_Cupones
        Me.gc_Cupones.Name = "gc_Cupones"
        Me.gc_Cupones.Size = New System.Drawing.Size(960, 247)
        Me.gc_Cupones.TabIndex = 0
        Me.gc_Cupones.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.dgv_Cupones})
        '
        'dgv_Cupones
        '
        Me.dgv_Cupones.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.MediumTurquoise
        Me.dgv_Cupones.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgv_Cupones.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.dgv_Cupones.AppearancePrint.HeaderPanel.Options.UseFont = True
        Me.dgv_Cupones.GridControl = Me.gc_Cupones
        Me.dgv_Cupones.Name = "dgv_Cupones"
        Me.dgv_Cupones.OptionsBehavior.Editable = False
        '
        'tp_Detallado
        '
        Me.tp_Detallado.Controls.Add(Me.gc_Restricciones)
        Me.tp_Detallado.Controls.Add(Me.gc_CuponesDet)
        Me.tp_Detallado.Controls.Add(Me.PanelControl3)
        Me.tp_Detallado.Controls.Add(Me.PanelControl2)
        Me.tp_Detallado.Name = "tp_Detallado"
        Me.tp_Detallado.Size = New System.Drawing.Size(960, 335)
        Me.tp_Detallado.Text = "Detallado"
        '
        'gc_CuponesDet
        '
        Me.gc_CuponesDet.Dock = System.Windows.Forms.DockStyle.Left
        Me.gc_CuponesDet.Location = New System.Drawing.Point(0, 101)
        Me.gc_CuponesDet.MainView = Me.dgv_CuponesDet
        Me.gc_CuponesDet.Name = "gc_CuponesDet"
        Me.gc_CuponesDet.Size = New System.Drawing.Size(697, 190)
        Me.gc_CuponesDet.TabIndex = 0
        Me.gc_CuponesDet.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.dgv_CuponesDet})
        '
        'dgv_CuponesDet
        '
        Me.dgv_CuponesDet.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.MediumTurquoise
        Me.dgv_CuponesDet.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgv_CuponesDet.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.dgv_CuponesDet.AppearancePrint.HeaderPanel.Options.UseFont = True
        Me.dgv_CuponesDet.GridControl = Me.gc_CuponesDet
        Me.dgv_CuponesDet.Name = "dgv_CuponesDet"
        Me.dgv_CuponesDet.OptionsBehavior.Editable = False
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.btn_Regresar)
        Me.PanelControl3.Controls.Add(Me.btn_EliminarDet)
        Me.PanelControl3.Controls.Add(Me.btn_AgregarDet)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl3.Location = New System.Drawing.Point(0, 291)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(960, 44)
        Me.PanelControl3.TabIndex = 2
        '
        'btn_Regresar
        '
        Me.btn_Regresar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Regresar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Regresar.ImageOptions.ImageUri.Uri = "Reset"
        Me.btn_Regresar.Location = New System.Drawing.Point(901, 2)
        Me.btn_Regresar.Name = "btn_Regresar"
        Me.btn_Regresar.Size = New System.Drawing.Size(57, 40)
        Me.btn_Regresar.TabIndex = 2
        Me.btn_Regresar.ToolTip = "Regresar"
        '
        'btn_EliminarDet
        '
        Me.btn_EliminarDet.Location = New System.Drawing.Point(84, 7)
        Me.btn_EliminarDet.Name = "btn_EliminarDet"
        Me.btn_EliminarDet.Size = New System.Drawing.Size(75, 23)
        Me.btn_EliminarDet.TabIndex = 1
        Me.btn_EliminarDet.Text = "Eliminar"
        '
        'btn_AgregarDet
        '
        Me.btn_AgregarDet.Location = New System.Drawing.Point(3, 7)
        Me.btn_AgregarDet.Name = "btn_AgregarDet"
        Me.btn_AgregarDet.Size = New System.Drawing.Size(75, 23)
        Me.btn_AgregarDet.TabIndex = 0
        Me.btn_AgregarDet.Text = "Agregar"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.pb_Imagen)
        Me.PanelControl2.Controls.Add(Me.cbo_Tipo)
        Me.PanelControl2.Controls.Add(Me.lbl_Tipo)
        Me.PanelControl2.Controls.Add(Me.btn_Guardar)
        Me.PanelControl2.Controls.Add(Me.lbl_FUM)
        Me.PanelControl2.Controls.Add(Me.txt_FUM)
        Me.PanelControl2.Controls.Add(Me.txt_IdUsuario)
        Me.PanelControl2.Controls.Add(Me.lbl_Usuario)
        Me.PanelControl2.Controls.Add(Me.dt_FecFin)
        Me.PanelControl2.Controls.Add(Me.lbl_FecFin)
        Me.PanelControl2.Controls.Add(Me.dt_FecIni)
        Me.PanelControl2.Controls.Add(Me.lbl_FecIni)
        Me.PanelControl2.Controls.Add(Me.txt_Restricciones)
        Me.PanelControl2.Controls.Add(Me.txt_Descripcion)
        Me.PanelControl2.Controls.Add(Me.lbl_Restricciones)
        Me.PanelControl2.Controls.Add(Me.lbl_Descripcion)
        Me.PanelControl2.Controls.Add(Me.txt_Nombre)
        Me.PanelControl2.Controls.Add(Me.lbl_Nombre)
        Me.PanelControl2.Controls.Add(Me.txt_IdCupon)
        Me.PanelControl2.Controls.Add(Me.lbl_IdCupon)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(960, 101)
        Me.PanelControl2.TabIndex = 1
        '
        'pb_Imagen
        '
        Me.pb_Imagen.EditValue = ""
        Me.pb_Imagen.Location = New System.Drawing.Point(781, 11)
        Me.pb_Imagen.Name = "pb_Imagen"
        Me.pb_Imagen.Properties.PictureStoreMode = DevExpress.XtraEditors.Controls.PictureStoreMode.ByteArray
        Me.pb_Imagen.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.pb_Imagen.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.pb_Imagen.Size = New System.Drawing.Size(76, 73)
        Me.pb_Imagen.TabIndex = 8
        '
        'cbo_Tipo
        '
        Me.cbo_Tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_Tipo.FormattingEnabled = True
        Me.cbo_Tipo.Items.AddRange(New Object() {"UNICO", "MULTIPLE"})
        Me.cbo_Tipo.Location = New System.Drawing.Point(657, 11)
        Me.cbo_Tipo.Name = "cbo_Tipo"
        Me.cbo_Tipo.Size = New System.Drawing.Size(118, 21)
        Me.cbo_Tipo.TabIndex = 5
        '
        'lbl_Tipo
        '
        Me.lbl_Tipo.Location = New System.Drawing.Point(631, 15)
        Me.lbl_Tipo.Name = "lbl_Tipo"
        Me.lbl_Tipo.Size = New System.Drawing.Size(20, 13)
        Me.lbl_Tipo.TabIndex = 42
        Me.lbl_Tipo.Text = "Tipo"
        '
        'btn_Guardar
        '
        Me.btn_Guardar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Guardar.ImageOptions.ImageUri.Uri = "Apply"
        Me.btn_Guardar.Location = New System.Drawing.Point(869, 26)
        Me.btn_Guardar.Name = "btn_Guardar"
        Me.btn_Guardar.Size = New System.Drawing.Size(57, 49)
        Me.btn_Guardar.TabIndex = 9
        Me.btn_Guardar.ToolTip = "Guardar"
        '
        'lbl_FUM
        '
        Me.lbl_FUM.Location = New System.Drawing.Point(630, 67)
        Me.lbl_FUM.Name = "lbl_FUM"
        Me.lbl_FUM.Size = New System.Drawing.Size(21, 13)
        Me.lbl_FUM.TabIndex = 40
        Me.lbl_FUM.Text = "FUM"
        '
        'txt_FUM
        '
        Me.txt_FUM.Enabled = False
        Me.txt_FUM.Location = New System.Drawing.Point(657, 64)
        Me.txt_FUM.Name = "txt_FUM"
        Me.txt_FUM.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_FUM.Properties.ReadOnly = True
        Me.txt_FUM.Size = New System.Drawing.Size(118, 20)
        Me.txt_FUM.TabIndex = 7
        '
        'txt_IdUsuario
        '
        Me.txt_IdUsuario.Enabled = False
        Me.txt_IdUsuario.Location = New System.Drawing.Point(657, 38)
        Me.txt_IdUsuario.Name = "txt_IdUsuario"
        Me.txt_IdUsuario.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_IdUsuario.Properties.ReadOnly = True
        Me.txt_IdUsuario.Size = New System.Drawing.Size(118, 20)
        Me.txt_IdUsuario.TabIndex = 6
        '
        'lbl_Usuario
        '
        Me.lbl_Usuario.Location = New System.Drawing.Point(615, 41)
        Me.lbl_Usuario.Name = "lbl_Usuario"
        Me.lbl_Usuario.Size = New System.Drawing.Size(36, 13)
        Me.lbl_Usuario.TabIndex = 38
        Me.lbl_Usuario.Text = "Usuario"
        '
        'dt_FecFin
        '
        Me.dt_FecFin.EditValue = Nothing
        Me.dt_FecFin.Location = New System.Drawing.Point(513, 12)
        Me.dt_FecFin.Name = "dt_FecFin"
        Me.dt_FecFin.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dt_FecFin.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dt_FecFin.Size = New System.Drawing.Size(96, 20)
        Me.dt_FecFin.TabIndex = 2
        '
        'lbl_FecFin
        '
        Me.lbl_FecFin.Location = New System.Drawing.Point(478, 15)
        Me.lbl_FecFin.Name = "lbl_FecFin"
        Me.lbl_FecFin.Size = New System.Drawing.Size(31, 13)
        Me.lbl_FecFin.TabIndex = 12
        Me.lbl_FecFin.Text = "FecFin"
        '
        'dt_FecIni
        '
        Me.dt_FecIni.EditValue = Nothing
        Me.dt_FecIni.Location = New System.Drawing.Point(383, 12)
        Me.dt_FecIni.Name = "dt_FecIni"
        Me.dt_FecIni.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dt_FecIni.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dt_FecIni.Size = New System.Drawing.Size(89, 20)
        Me.dt_FecIni.TabIndex = 1
        '
        'lbl_FecIni
        '
        Me.lbl_FecIni.Location = New System.Drawing.Point(348, 15)
        Me.lbl_FecIni.Name = "lbl_FecIni"
        Me.lbl_FecIni.Size = New System.Drawing.Size(29, 13)
        Me.lbl_FecIni.TabIndex = 10
        Me.lbl_FecIni.Text = "FecIni"
        '
        'txt_Restricciones
        '
        Me.txt_Restricciones.Location = New System.Drawing.Point(383, 38)
        Me.txt_Restricciones.Name = "txt_Restricciones"
        Me.txt_Restricciones.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Restricciones.Size = New System.Drawing.Size(226, 53)
        Me.txt_Restricciones.TabIndex = 4
        '
        'txt_Descripcion
        '
        Me.txt_Descripcion.Location = New System.Drawing.Point(65, 38)
        Me.txt_Descripcion.Name = "txt_Descripcion"
        Me.txt_Descripcion.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Descripcion.Size = New System.Drawing.Size(243, 53)
        Me.txt_Descripcion.TabIndex = 3
        '
        'lbl_Restricciones
        '
        Me.lbl_Restricciones.Location = New System.Drawing.Point(314, 41)
        Me.lbl_Restricciones.Name = "lbl_Restricciones"
        Me.lbl_Restricciones.Size = New System.Drawing.Size(63, 13)
        Me.lbl_Restricciones.TabIndex = 6
        Me.lbl_Restricciones.Text = "Restricciones"
        '
        'lbl_Descripcion
        '
        Me.lbl_Descripcion.Location = New System.Drawing.Point(5, 41)
        Me.lbl_Descripcion.Name = "lbl_Descripcion"
        Me.lbl_Descripcion.Size = New System.Drawing.Size(54, 13)
        Me.lbl_Descripcion.TabIndex = 4
        Me.lbl_Descripcion.Text = "Descripción"
        '
        'txt_Nombre
        '
        Me.txt_Nombre.Location = New System.Drawing.Point(163, 12)
        Me.txt_Nombre.Name = "txt_Nombre"
        Me.txt_Nombre.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Nombre.Size = New System.Drawing.Size(179, 20)
        Me.txt_Nombre.TabIndex = 0
        '
        'lbl_Nombre
        '
        Me.lbl_Nombre.Location = New System.Drawing.Point(120, 15)
        Me.lbl_Nombre.Name = "lbl_Nombre"
        Me.lbl_Nombre.Size = New System.Drawing.Size(37, 13)
        Me.lbl_Nombre.TabIndex = 2
        Me.lbl_Nombre.Text = "Nombre"
        '
        'txt_IdCupon
        '
        Me.txt_IdCupon.Enabled = False
        Me.txt_IdCupon.Location = New System.Drawing.Point(65, 12)
        Me.txt_IdCupon.Name = "txt_IdCupon"
        Me.txt_IdCupon.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_IdCupon.Properties.ReadOnly = True
        Me.txt_IdCupon.Size = New System.Drawing.Size(49, 20)
        Me.txt_IdCupon.TabIndex = 0
        '
        'lbl_IdCupon
        '
        Me.lbl_IdCupon.Location = New System.Drawing.Point(18, 15)
        Me.lbl_IdCupon.Name = "lbl_IdCupon"
        Me.lbl_IdCupon.Size = New System.Drawing.Size(41, 13)
        Me.lbl_IdCupon.TabIndex = 0
        Me.lbl_IdCupon.Text = "IdCupon"
        '
        'gc_Restricciones
        '
        Me.gc_Restricciones.Controls.Add(Me.gc_Restriccion)
        Me.gc_Restricciones.Controls.Add(Me.PanelControl11)
        Me.gc_Restricciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gc_Restricciones.Location = New System.Drawing.Point(697, 101)
        Me.gc_Restricciones.Name = "gc_Restricciones"
        Me.gc_Restricciones.Size = New System.Drawing.Size(263, 190)
        Me.gc_Restricciones.TabIndex = 12
        Me.gc_Restricciones.Text = "Restricciones"
        '
        'gc_Restriccion
        '
        Me.gc_Restriccion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gc_Restriccion.Location = New System.Drawing.Point(2, 20)
        Me.gc_Restriccion.MainView = Me.dgv_Restriccion
        Me.gc_Restriccion.Name = "gc_Restriccion"
        Me.gc_Restriccion.Size = New System.Drawing.Size(199, 168)
        Me.gc_Restriccion.TabIndex = 15
        Me.gc_Restriccion.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.dgv_Restriccion})
        '
        'dgv_Restriccion
        '
        Me.dgv_Restriccion.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gc_ImagenRestriccion, Me.gc_DescripcionRestriccion, Me.gc_UsuarioRestriccion, Me.gc_FumRestriccion, Me.gc_Prioridad})
        Me.dgv_Restriccion.GridControl = Me.gc_Restriccion
        Me.dgv_Restriccion.Name = "dgv_Restriccion"
        Me.dgv_Restriccion.OptionsBehavior.Editable = False
        Me.dgv_Restriccion.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Fast
        Me.dgv_Restriccion.OptionsView.ColumnAutoWidth = False
        '
        'gc_ImagenRestriccion
        '
        Me.gc_ImagenRestriccion.Caption = "Imagen"
        Me.gc_ImagenRestriccion.FieldName = "imagen"
        Me.gc_ImagenRestriccion.Name = "gc_ImagenRestriccion"
        Me.gc_ImagenRestriccion.Visible = True
        Me.gc_ImagenRestriccion.VisibleIndex = 0
        '
        'gc_DescripcionRestriccion
        '
        Me.gc_DescripcionRestriccion.Caption = "Descripción"
        Me.gc_DescripcionRestriccion.FieldName = "descripcion"
        Me.gc_DescripcionRestriccion.Name = "gc_DescripcionRestriccion"
        Me.gc_DescripcionRestriccion.Visible = True
        Me.gc_DescripcionRestriccion.VisibleIndex = 1
        '
        'gc_UsuarioRestriccion
        '
        Me.gc_UsuarioRestriccion.Caption = "Usuario"
        Me.gc_UsuarioRestriccion.FieldName = "idusuario"
        Me.gc_UsuarioRestriccion.Name = "gc_UsuarioRestriccion"
        '
        'gc_FumRestriccion
        '
        Me.gc_FumRestriccion.Caption = "FUM"
        Me.gc_FumRestriccion.FieldName = "FUM"
        Me.gc_FumRestriccion.Name = "gc_FumRestriccion"
        '
        'gc_Prioridad
        '
        Me.gc_Prioridad.Caption = "Prioridad"
        Me.gc_Prioridad.FieldName = "prioridad"
        Me.gc_Prioridad.Name = "gc_Prioridad"
        '
        'PanelControl11
        '
        Me.PanelControl11.Controls.Add(Me.btn_EliminarRestriccion)
        Me.PanelControl11.Controls.Add(Me.btn_DisminuyePrioridad)
        Me.PanelControl11.Controls.Add(Me.btn_AumentaPrioridad)
        Me.PanelControl11.Controls.Add(Me.btn_AgregarRestriccion)
        Me.PanelControl11.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl11.Location = New System.Drawing.Point(201, 20)
        Me.PanelControl11.Name = "PanelControl11"
        Me.PanelControl11.Size = New System.Drawing.Size(60, 168)
        Me.PanelControl11.TabIndex = 14
        '
        'btn_DisminuyePrioridad
        '
        Me.btn_DisminuyePrioridad.ImageOptions.Image = CType(resources.GetObject("btn_DisminuyePrioridad.ImageOptions.Image"), System.Drawing.Image)
        Me.btn_DisminuyePrioridad.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_DisminuyePrioridad.Location = New System.Drawing.Point(13, 126)
        Me.btn_DisminuyePrioridad.Name = "btn_DisminuyePrioridad"
        Me.btn_DisminuyePrioridad.Size = New System.Drawing.Size(33, 30)
        Me.btn_DisminuyePrioridad.TabIndex = 2
        Me.btn_DisminuyePrioridad.ToolTip = "Disminuir Prioridad"
        '
        'btn_AumentaPrioridad
        '
        Me.btn_AumentaPrioridad.ImageOptions.Image = CType(resources.GetObject("btn_AumentaPrioridad.ImageOptions.Image"), System.Drawing.Image)
        Me.btn_AumentaPrioridad.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_AumentaPrioridad.Location = New System.Drawing.Point(13, 90)
        Me.btn_AumentaPrioridad.Name = "btn_AumentaPrioridad"
        Me.btn_AumentaPrioridad.Size = New System.Drawing.Size(33, 30)
        Me.btn_AumentaPrioridad.TabIndex = 1
        Me.btn_AumentaPrioridad.ToolTip = "Aumentar Prioridad"
        '
        'btn_AgregarRestriccion
        '
        Me.btn_AgregarRestriccion.ImageOptions.Image = CType(resources.GetObject("btn_AgregarRestriccion.ImageOptions.Image"), System.Drawing.Image)
        Me.btn_AgregarRestriccion.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_AgregarRestriccion.Location = New System.Drawing.Point(13, 7)
        Me.btn_AgregarRestriccion.Name = "btn_AgregarRestriccion"
        Me.btn_AgregarRestriccion.Size = New System.Drawing.Size(33, 30)
        Me.btn_AgregarRestriccion.TabIndex = 0
        Me.btn_AgregarRestriccion.ToolTip = "Agregar Restriccion"
        '
        'btn_EliminarRestriccion
        '
        Me.btn_EliminarRestriccion.ImageOptions.Image = CType(resources.GetObject("btn_EliminarRestriccion.ImageOptions.Image"), System.Drawing.Image)
        Me.btn_EliminarRestriccion.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_EliminarRestriccion.Location = New System.Drawing.Point(13, 43)
        Me.btn_EliminarRestriccion.Name = "btn_EliminarRestriccion"
        Me.btn_EliminarRestriccion.Size = New System.Drawing.Size(33, 30)
        Me.btn_EliminarRestriccion.TabIndex = 4
        Me.btn_EliminarRestriccion.ToolTip = "Agregar Restriccion"
        '
        'frmCatCupones
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(966, 419)
        Me.Controls.Add(Me.tc_Cupones)
        Me.Controls.Add(Me.PanelControl1)
        Me.KeyPreview = True
        Me.Name = "frmCatCupones"
        Me.Text = "Cupones"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.tc_Cupones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tc_Cupones.ResumeLayout(False)
        Me.tp_Cupones.ResumeLayout(False)
        CType(Me.gc_Cupones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_Cupones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tp_Detallado.ResumeLayout(False)
        CType(Me.gc_CuponesDet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_CuponesDet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.pb_Imagen.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_FUM.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_IdUsuario.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_FecFin.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_FecFin.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_FecIni.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_FecIni.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Restricciones.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Descripcion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Nombre.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_IdCupon.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gc_Restricciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gc_Restricciones.ResumeLayout(False)
        CType(Me.gc_Restriccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_Restriccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl11.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents tc_Cupones As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents tp_Cupones As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents gc_Cupones As DevExpress.XtraGrid.GridControl
    Friend WithEvents dgv_Cupones As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents tp_Detallado As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents gc_CuponesDet As DevExpress.XtraGrid.GridControl
    Friend WithEvents dgv_CuponesDet As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents dt_FecFin As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lbl_FecFin As DevExpress.XtraEditors.LabelControl
    Friend WithEvents dt_FecIni As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lbl_FecIni As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txt_Restricciones As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents txt_Descripcion As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents lbl_Restricciones As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbl_Descripcion As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txt_Nombre As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbl_Nombre As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txt_IdCupon As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbl_IdCupon As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btn_Guardar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lbl_FUM As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txt_FUM As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txt_IdUsuario As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbl_Usuario As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cbo_Tipo As ComboBox
    Friend WithEvents lbl_Tipo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btn_Cancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_Activar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_Salir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_Consultar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_Modificar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_Nuevo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_Regresar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_EliminarDet As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_AgregarDet As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents pb_Imagen As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents gc_Restricciones As DevExpress.XtraEditors.GroupControl
    Friend WithEvents gc_Restriccion As DevExpress.XtraGrid.GridControl
    Friend WithEvents dgv_Restriccion As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gc_ImagenRestriccion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_DescripcionRestriccion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_UsuarioRestriccion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_FumRestriccion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_Prioridad As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl11 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btn_DisminuyePrioridad As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_AumentaPrioridad As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_AgregarRestriccion As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_EliminarRestriccion As DevExpress.XtraEditors.SimpleButton
End Class
