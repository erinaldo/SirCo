<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCatPromociones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCatPromociones))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.btn_Pausar = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_Salir = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_Cancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_Activar = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_Consultar = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_Modificar = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_Nuevo = New DevExpress.XtraEditors.SimpleButton()
        Me.tc_Promociones = New DevExpress.XtraTab.XtraTabControl()
        Me.tp_Promociones = New DevExpress.XtraTab.XtraTabPage()
        Me.gc_Promociones = New DevExpress.XtraGrid.GridControl()
        Me.dgv_Promociones = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.tp_Promocion = New DevExpress.XtraTab.XtraTabPage()
        Me.PanelControl9 = New DevExpress.XtraEditors.PanelControl()
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
        Me.gc_Unidades = New DevExpress.XtraGrid.GridControl()
        Me.dgv_Unidades = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PanelControl10 = New DevExpress.XtraEditors.PanelControl()
        Me.btn_Configurar = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_Regresar = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl7 = New DevExpress.XtraEditors.PanelControl()
        Me.gc_Agrupaciones = New DevExpress.XtraGrid.GridControl()
        Me.dgv_Agrupaciones = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.idpromocion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl8 = New DevExpress.XtraEditors.PanelControl()
        Me.gb_Agrupaciones = New DevExpress.XtraEditors.GroupControl()
        Me.btn_EliminarAgrupacion = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_AgregarAgrupacion = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl6 = New DevExpress.XtraEditors.PanelControl()
        Me.gb_Exclusiones = New DevExpress.XtraEditors.GroupControl()
        Me.lv_Exclusiones = New DevExpress.XtraEditors.ListBoxControl()
        Me.btn_AgregarExclusiones = New DevExpress.XtraEditors.SimpleButton()
        Me.gb_Cupones = New DevExpress.XtraEditors.GroupControl()
        Me.lv_Cupones = New DevExpress.XtraEditors.ListBoxControl()
        Me.btn_AgregarCupon = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.gb_Plazas = New DevExpress.XtraEditors.GroupControl()
        Me.lv_Plazas = New DevExpress.XtraEditors.ListBoxControl()
        Me.btn_AgregarPlazas = New DevExpress.XtraEditors.SimpleButton()
        Me.gb_Recurrencia = New DevExpress.XtraEditors.GroupControl()
        Me.lv_Recurrencia = New DevExpress.XtraEditors.ListBoxControl()
        Me.btn_AgregarRecurrencia = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl5 = New DevExpress.XtraEditors.PanelControl()
        Me.pb_Imagen = New DevExpress.XtraEditors.PictureEdit()
        Me.txt_UniPromo = New DevExpress.XtraEditors.TextEdit()
        Me.lbl_UniPromo = New DevExpress.XtraEditors.LabelControl()
        Me.txt_ImpMinimo = New DevExpress.XtraEditors.TextEdit()
        Me.lbl_ImpMin = New DevExpress.XtraEditors.LabelControl()
        Me.txt_UniMin = New DevExpress.XtraEditors.TextEdit()
        Me.lbl_UniMin = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_IdPromocion = New DevExpress.XtraEditors.LabelControl()
        Me.txt_IdPromocion = New DevExpress.XtraEditors.TextEdit()
        Me.cbo_Clasificacion = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lbl_Clasificacion = New DevExpress.XtraEditors.LabelControl()
        Me.chk_Acumulable = New DevExpress.XtraEditors.CheckEdit()
        Me.chk_ClientesNoRegistrados = New DevExpress.XtraEditors.CheckEdit()
        Me.chk_ParesUnicos = New DevExpress.XtraEditors.CheckEdit()
        Me.btn_Guardar = New DevExpress.XtraEditors.SimpleButton()
        Me.cbo_Señalizador = New DevExpress.XtraEditors.LookUpEdit()
        Me.cbo_Preciero = New DevExpress.XtraEditors.LookUpEdit()
        Me.lbl_Señalizador = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_Preciero = New DevExpress.XtraEditors.LabelControl()
        Me.cbo_Estatus = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lbl_Estatus = New DevExpress.XtraEditors.LabelControl()
        Me.gb_Vigencia = New DevExpress.XtraEditors.GroupControl()
        Me.dt_VigenciaFin = New DevExpress.XtraEditors.DateEdit()
        Me.dt_VigenciaIni = New DevExpress.XtraEditors.DateEdit()
        Me.lbl_IniVigencia = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_FinVigencia = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_Nombre = New DevExpress.XtraEditors.LabelControl()
        Me.txt_Nombre = New DevExpress.XtraEditors.TextEdit()
        Me.gb_TipoPromocion = New DevExpress.XtraEditors.GroupControl()
        Me.rb_AxB = New System.Windows.Forms.RadioButton()
        Me.rb_Directa = New System.Windows.Forms.RadioButton()
        Me.btn_EliminarRestriccion = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.tc_Promociones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tc_Promociones.SuspendLayout()
        Me.tp_Promociones.SuspendLayout()
        CType(Me.gc_Promociones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_Promociones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tp_Promocion.SuspendLayout()
        CType(Me.PanelControl9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl9.SuspendLayout()
        CType(Me.gc_Restricciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gc_Restricciones.SuspendLayout()
        CType(Me.gc_Restriccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_Restriccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl11.SuspendLayout()
        CType(Me.gc_Unidades, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_Unidades, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl10.SuspendLayout()
        CType(Me.PanelControl7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl7.SuspendLayout()
        CType(Me.gc_Agrupaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_Agrupaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl8.SuspendLayout()
        CType(Me.gb_Agrupaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_Agrupaciones.SuspendLayout()
        CType(Me.PanelControl6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl6.SuspendLayout()
        CType(Me.gb_Exclusiones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_Exclusiones.SuspendLayout()
        CType(Me.lv_Exclusiones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gb_Cupones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_Cupones.SuspendLayout()
        CType(Me.lv_Cupones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.gb_Plazas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_Plazas.SuspendLayout()
        CType(Me.lv_Plazas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gb_Recurrencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_Recurrencia.SuspendLayout()
        CType(Me.lv_Recurrencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PanelControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl5.SuspendLayout()
        CType(Me.pb_Imagen.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_UniPromo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_ImpMinimo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_UniMin.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_IdPromocion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_Clasificacion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chk_Acumulable.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chk_ClientesNoRegistrados.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chk_ParesUnicos.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_Señalizador.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_Preciero.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_Estatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gb_Vigencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_Vigencia.SuspendLayout()
        CType(Me.dt_VigenciaFin.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_VigenciaFin.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_VigenciaIni.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_VigenciaIni.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Nombre.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gb_TipoPromocion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_TipoPromocion.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.btn_Pausar)
        Me.PanelControl1.Controls.Add(Me.btn_Salir)
        Me.PanelControl1.Controls.Add(Me.btn_Cancelar)
        Me.PanelControl1.Controls.Add(Me.btn_Activar)
        Me.PanelControl1.Controls.Add(Me.btn_Consultar)
        Me.PanelControl1.Controls.Add(Me.btn_Modificar)
        Me.PanelControl1.Controls.Add(Me.btn_Nuevo)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 602)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1026, 48)
        Me.PanelControl1.TabIndex = 0
        '
        'btn_Pausar
        '
        Me.btn_Pausar.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_Pausar.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.bloqueado
        Me.btn_Pausar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Pausar.Location = New System.Drawing.Point(262, 2)
        Me.btn_Pausar.Name = "btn_Pausar"
        Me.btn_Pausar.Size = New System.Drawing.Size(52, 44)
        Me.btn_Pausar.TabIndex = 5
        Me.btn_Pausar.ToolTip = "Pausar Promoción"
        '
        'btn_Salir
        '
        Me.btn_Salir.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Salir.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.door_out
        Me.btn_Salir.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Salir.Location = New System.Drawing.Point(976, 2)
        Me.btn_Salir.Name = "btn_Salir"
        Me.btn_Salir.Size = New System.Drawing.Size(48, 44)
        Me.btn_Salir.TabIndex = 6
        '
        'btn_Cancelar
        '
        Me.btn_Cancelar.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_Cancelar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Cancelar.ImageOptions.ImageUri.Uri = "Cancel"
        Me.btn_Cancelar.Location = New System.Drawing.Point(210, 2)
        Me.btn_Cancelar.Name = "btn_Cancelar"
        Me.btn_Cancelar.Size = New System.Drawing.Size(52, 44)
        Me.btn_Cancelar.TabIndex = 4
        Me.btn_Cancelar.ToolTip = "Cancelar Promoción"
        '
        'btn_Activar
        '
        Me.btn_Activar.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_Activar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Activar.ImageOptions.ImageUri.Uri = "Previous"
        Me.btn_Activar.Location = New System.Drawing.Point(158, 2)
        Me.btn_Activar.Name = "btn_Activar"
        Me.btn_Activar.Size = New System.Drawing.Size(52, 44)
        Me.btn_Activar.TabIndex = 3
        Me.btn_Activar.ToolTip = "Activar Promoción"
        '
        'btn_Consultar
        '
        Me.btn_Consultar.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_Consultar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Consultar.ImageOptions.ImageUri.Uri = "Preview"
        Me.btn_Consultar.Location = New System.Drawing.Point(106, 2)
        Me.btn_Consultar.Name = "btn_Consultar"
        Me.btn_Consultar.Size = New System.Drawing.Size(52, 44)
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
        Me.btn_Modificar.Size = New System.Drawing.Size(52, 44)
        Me.btn_Modificar.TabIndex = 1
        Me.btn_Modificar.ToolTip = "Modificar"
        '
        'btn_Nuevo
        '
        Me.btn_Nuevo.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_Nuevo.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.new_20doc
        Me.btn_Nuevo.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Nuevo.ImageOptions.ImageUri.Uri = "AddItem"
        Me.btn_Nuevo.Location = New System.Drawing.Point(2, 2)
        Me.btn_Nuevo.Name = "btn_Nuevo"
        Me.btn_Nuevo.Size = New System.Drawing.Size(52, 44)
        Me.btn_Nuevo.TabIndex = 0
        Me.btn_Nuevo.ToolTip = "Nuevo"
        '
        'tc_Promociones
        '
        Me.tc_Promociones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tc_Promociones.Location = New System.Drawing.Point(0, 0)
        Me.tc_Promociones.Name = "tc_Promociones"
        Me.tc_Promociones.SelectedTabPage = Me.tp_Promociones
        Me.tc_Promociones.Size = New System.Drawing.Size(1026, 602)
        Me.tc_Promociones.TabIndex = 1
        Me.tc_Promociones.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tp_Promociones, Me.tp_Promocion})
        '
        'tp_Promociones
        '
        Me.tp_Promociones.Controls.Add(Me.gc_Promociones)
        Me.tp_Promociones.Name = "tp_Promociones"
        Me.tp_Promociones.Size = New System.Drawing.Size(1020, 574)
        Me.tp_Promociones.Text = "Promociones"
        '
        'gc_Promociones
        '
        Me.gc_Promociones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gc_Promociones.Location = New System.Drawing.Point(0, 0)
        Me.gc_Promociones.MainView = Me.dgv_Promociones
        Me.gc_Promociones.Name = "gc_Promociones"
        Me.gc_Promociones.Size = New System.Drawing.Size(1020, 574)
        Me.gc_Promociones.TabIndex = 0
        Me.gc_Promociones.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.dgv_Promociones})
        '
        'dgv_Promociones
        '
        Me.dgv_Promociones.GridControl = Me.gc_Promociones
        Me.dgv_Promociones.Name = "dgv_Promociones"
        Me.dgv_Promociones.OptionsBehavior.Editable = False
        '
        'tp_Promocion
        '
        Me.tp_Promocion.Controls.Add(Me.PanelControl9)
        Me.tp_Promocion.Controls.Add(Me.PanelControl7)
        Me.tp_Promocion.Controls.Add(Me.PanelControl6)
        Me.tp_Promocion.Controls.Add(Me.PanelControl3)
        Me.tp_Promocion.Controls.Add(Me.PanelControl2)
        Me.tp_Promocion.Name = "tp_Promocion"
        Me.tp_Promocion.Size = New System.Drawing.Size(1020, 574)
        Me.tp_Promocion.Text = "Promoción"
        '
        'PanelControl9
        '
        Me.PanelControl9.Controls.Add(Me.gc_Restricciones)
        Me.PanelControl9.Controls.Add(Me.gc_Unidades)
        Me.PanelControl9.Controls.Add(Me.PanelControl10)
        Me.PanelControl9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl9.Location = New System.Drawing.Point(0, 310)
        Me.PanelControl9.Name = "PanelControl9"
        Me.PanelControl9.Size = New System.Drawing.Size(760, 264)
        Me.PanelControl9.TabIndex = 8
        '
        'gc_Restricciones
        '
        Me.gc_Restricciones.Controls.Add(Me.gc_Restriccion)
        Me.gc_Restricciones.Controls.Add(Me.PanelControl11)
        Me.gc_Restricciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gc_Restricciones.Location = New System.Drawing.Point(469, 2)
        Me.gc_Restricciones.Name = "gc_Restricciones"
        Me.gc_Restricciones.Size = New System.Drawing.Size(289, 212)
        Me.gc_Restricciones.TabIndex = 11
        Me.gc_Restricciones.Text = "Restricciones"
        '
        'gc_Restriccion
        '
        Me.gc_Restriccion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gc_Restriccion.Location = New System.Drawing.Point(2, 20)
        Me.gc_Restriccion.MainView = Me.dgv_Restriccion
        Me.gc_Restriccion.Name = "gc_Restriccion"
        Me.gc_Restriccion.Size = New System.Drawing.Size(225, 190)
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
        Me.PanelControl11.Location = New System.Drawing.Point(227, 20)
        Me.PanelControl11.Name = "PanelControl11"
        Me.PanelControl11.Size = New System.Drawing.Size(60, 190)
        Me.PanelControl11.TabIndex = 14
        '
        'btn_DisminuyePrioridad
        '
        Me.btn_DisminuyePrioridad.ImageOptions.Image = CType(resources.GetObject("btn_DisminuyePrioridad.ImageOptions.Image"), System.Drawing.Image)
        Me.btn_DisminuyePrioridad.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_DisminuyePrioridad.Location = New System.Drawing.Point(13, 132)
        Me.btn_DisminuyePrioridad.Name = "btn_DisminuyePrioridad"
        Me.btn_DisminuyePrioridad.Size = New System.Drawing.Size(33, 30)
        Me.btn_DisminuyePrioridad.TabIndex = 2
        Me.btn_DisminuyePrioridad.ToolTip = "Disminuir Prioridad"
        '
        'btn_AumentaPrioridad
        '
        Me.btn_AumentaPrioridad.ImageOptions.Image = CType(resources.GetObject("btn_AumentaPrioridad.ImageOptions.Image"), System.Drawing.Image)
        Me.btn_AumentaPrioridad.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_AumentaPrioridad.Location = New System.Drawing.Point(13, 96)
        Me.btn_AumentaPrioridad.Name = "btn_AumentaPrioridad"
        Me.btn_AumentaPrioridad.Size = New System.Drawing.Size(33, 30)
        Me.btn_AumentaPrioridad.TabIndex = 1
        Me.btn_AumentaPrioridad.ToolTip = "Aumentar Prioridad"
        '
        'btn_AgregarRestriccion
        '
        Me.btn_AgregarRestriccion.ImageOptions.Image = CType(resources.GetObject("btn_AgregarRestriccion.ImageOptions.Image"), System.Drawing.Image)
        Me.btn_AgregarRestriccion.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_AgregarRestriccion.Location = New System.Drawing.Point(13, 5)
        Me.btn_AgregarRestriccion.Name = "btn_AgregarRestriccion"
        Me.btn_AgregarRestriccion.Size = New System.Drawing.Size(33, 30)
        Me.btn_AgregarRestriccion.TabIndex = 0
        Me.btn_AgregarRestriccion.ToolTip = "Agregar Restriccion"
        '
        'gc_Unidades
        '
        Me.gc_Unidades.Dock = System.Windows.Forms.DockStyle.Left
        Me.gc_Unidades.Location = New System.Drawing.Point(2, 2)
        Me.gc_Unidades.MainView = Me.dgv_Unidades
        Me.gc_Unidades.Name = "gc_Unidades"
        Me.gc_Unidades.Size = New System.Drawing.Size(467, 212)
        Me.gc_Unidades.TabIndex = 10
        Me.gc_Unidades.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.dgv_Unidades})
        '
        'dgv_Unidades
        '
        Me.dgv_Unidades.GridControl = Me.gc_Unidades
        Me.dgv_Unidades.Name = "dgv_Unidades"
        Me.dgv_Unidades.OptionsBehavior.Editable = False
        '
        'PanelControl10
        '
        Me.PanelControl10.Controls.Add(Me.btn_Configurar)
        Me.PanelControl10.Controls.Add(Me.btn_Regresar)
        Me.PanelControl10.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl10.Location = New System.Drawing.Point(2, 214)
        Me.PanelControl10.Name = "PanelControl10"
        Me.PanelControl10.Size = New System.Drawing.Size(756, 48)
        Me.PanelControl10.TabIndex = 9
        '
        'btn_Configurar
        '
        Me.btn_Configurar.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_Configurar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Configurar.ImageOptions.ImageUri.Uri = "AddNewDataSource"
        Me.btn_Configurar.Location = New System.Drawing.Point(2, 2)
        Me.btn_Configurar.Name = "btn_Configurar"
        Me.btn_Configurar.Size = New System.Drawing.Size(52, 44)
        Me.btn_Configurar.TabIndex = 0
        Me.btn_Configurar.ToolTip = "Configurar la promoción"
        '
        'btn_Regresar
        '
        Me.btn_Regresar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Regresar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Regresar.ImageOptions.ImageUri.Uri = "Reset"
        Me.btn_Regresar.Location = New System.Drawing.Point(707, 2)
        Me.btn_Regresar.Name = "btn_Regresar"
        Me.btn_Regresar.Size = New System.Drawing.Size(47, 44)
        Me.btn_Regresar.TabIndex = 1
        Me.btn_Regresar.ToolTip = "Regresar"
        '
        'PanelControl7
        '
        Me.PanelControl7.Controls.Add(Me.gc_Agrupaciones)
        Me.PanelControl7.Controls.Add(Me.PanelControl8)
        Me.PanelControl7.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl7.Location = New System.Drawing.Point(0, 82)
        Me.PanelControl7.Name = "PanelControl7"
        Me.PanelControl7.Size = New System.Drawing.Size(760, 228)
        Me.PanelControl7.TabIndex = 7
        '
        'gc_Agrupaciones
        '
        Me.gc_Agrupaciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gc_Agrupaciones.Location = New System.Drawing.Point(2, 2)
        Me.gc_Agrupaciones.MainView = Me.dgv_Agrupaciones
        Me.gc_Agrupaciones.Name = "gc_Agrupaciones"
        Me.gc_Agrupaciones.Size = New System.Drawing.Size(756, 158)
        Me.gc_Agrupaciones.TabIndex = 8
        Me.gc_Agrupaciones.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.dgv_Agrupaciones})
        '
        'dgv_Agrupaciones
        '
        Me.dgv_Agrupaciones.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.idpromocion, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn10, Me.GridColumn11})
        Me.dgv_Agrupaciones.GridControl = Me.gc_Agrupaciones
        Me.dgv_Agrupaciones.Name = "dgv_Agrupaciones"
        Me.dgv_Agrupaciones.OptionsBehavior.Editable = False
        '
        'idpromocion
        '
        Me.idpromocion.Caption = "Promoción"
        Me.idpromocion.FieldName = "idpromocion"
        Me.idpromocion.Name = "idpromocion"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "IdAgruComp"
        Me.GridColumn2.FieldName = "idagrupacioncompra"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Agrupación Compra"
        Me.GridColumn3.FieldName = "agrupacioncompra"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 0
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "idagrupromo"
        Me.GridColumn4.FieldName = "idagrupacionpromo"
        Me.GridColumn4.Name = "GridColumn4"
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Agrupación Promo"
        Me.GridColumn5.FieldName = "agrupacionpromo"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 1
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "renglon"
        Me.GridColumn6.FieldName = "renglon"
        Me.GridColumn6.Name = "GridColumn6"
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Usuario"
        Me.GridColumn10.FieldName = "idusuario"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 2
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "FUM"
        Me.GridColumn11.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm"
        Me.GridColumn11.FieldName = "fum"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 3
        '
        'PanelControl8
        '
        Me.PanelControl8.Controls.Add(Me.gb_Agrupaciones)
        Me.PanelControl8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl8.Location = New System.Drawing.Point(2, 160)
        Me.PanelControl8.Name = "PanelControl8"
        Me.PanelControl8.Size = New System.Drawing.Size(756, 66)
        Me.PanelControl8.TabIndex = 0
        '
        'gb_Agrupaciones
        '
        Me.gb_Agrupaciones.Controls.Add(Me.btn_EliminarAgrupacion)
        Me.gb_Agrupaciones.Controls.Add(Me.btn_AgregarAgrupacion)
        Me.gb_Agrupaciones.Dock = System.Windows.Forms.DockStyle.Left
        Me.gb_Agrupaciones.Location = New System.Drawing.Point(2, 2)
        Me.gb_Agrupaciones.Name = "gb_Agrupaciones"
        Me.gb_Agrupaciones.Size = New System.Drawing.Size(180, 62)
        Me.gb_Agrupaciones.TabIndex = 0
        Me.gb_Agrupaciones.Text = "Agrupaciones"
        '
        'btn_EliminarAgrupacion
        '
        Me.btn_EliminarAgrupacion.Location = New System.Drawing.Point(87, 24)
        Me.btn_EliminarAgrupacion.Name = "btn_EliminarAgrupacion"
        Me.btn_EliminarAgrupacion.Size = New System.Drawing.Size(75, 23)
        Me.btn_EliminarAgrupacion.TabIndex = 1
        Me.btn_EliminarAgrupacion.Text = "Eliminar"
        Me.btn_EliminarAgrupacion.ToolTip = "Elimina la agrupación seleccionada"
        '
        'btn_AgregarAgrupacion
        '
        Me.btn_AgregarAgrupacion.Location = New System.Drawing.Point(6, 24)
        Me.btn_AgregarAgrupacion.Name = "btn_AgregarAgrupacion"
        Me.btn_AgregarAgrupacion.Size = New System.Drawing.Size(75, 23)
        Me.btn_AgregarAgrupacion.TabIndex = 0
        Me.btn_AgregarAgrupacion.Text = "Agregar"
        Me.btn_AgregarAgrupacion.ToolTip = "Agregar Agrupación"
        '
        'PanelControl6
        '
        Me.PanelControl6.Controls.Add(Me.gb_Exclusiones)
        Me.PanelControl6.Controls.Add(Me.gb_Cupones)
        Me.PanelControl6.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl6.Location = New System.Drawing.Point(760, 82)
        Me.PanelControl6.Name = "PanelControl6"
        Me.PanelControl6.Size = New System.Drawing.Size(130, 492)
        Me.PanelControl6.TabIndex = 6
        '
        'gb_Exclusiones
        '
        Me.gb_Exclusiones.Controls.Add(Me.lv_Exclusiones)
        Me.gb_Exclusiones.Controls.Add(Me.btn_AgregarExclusiones)
        Me.gb_Exclusiones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gb_Exclusiones.Location = New System.Drawing.Point(2, 228)
        Me.gb_Exclusiones.Name = "gb_Exclusiones"
        Me.gb_Exclusiones.Size = New System.Drawing.Size(126, 262)
        Me.gb_Exclusiones.TabIndex = 1
        Me.gb_Exclusiones.Text = "Exclusiones"
        '
        'lv_Exclusiones
        '
        Me.lv_Exclusiones.AppearanceDisabled.BackColor = System.Drawing.Color.White
        Me.lv_Exclusiones.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
        Me.lv_Exclusiones.AppearanceDisabled.Options.UseBackColor = True
        Me.lv_Exclusiones.AppearanceDisabled.Options.UseForeColor = True
        Me.lv_Exclusiones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lv_Exclusiones.Location = New System.Drawing.Point(2, 67)
        Me.lv_Exclusiones.Name = "lv_Exclusiones"
        Me.lv_Exclusiones.Size = New System.Drawing.Size(122, 193)
        Me.lv_Exclusiones.TabIndex = 23
        '
        'btn_AgregarExclusiones
        '
        Me.btn_AgregarExclusiones.Location = New System.Drawing.Point(94, 4)
        Me.btn_AgregarExclusiones.Name = "btn_AgregarExclusiones"
        Me.btn_AgregarExclusiones.Size = New System.Drawing.Size(27, 22)
        Me.btn_AgregarExclusiones.TabIndex = 0
        Me.btn_AgregarExclusiones.Text = "+"
        Me.btn_AgregarExclusiones.ToolTip = "Agregar/Eliminar exclusión"
        '
        'gb_Cupones
        '
        Me.gb_Cupones.Controls.Add(Me.lv_Cupones)
        Me.gb_Cupones.Controls.Add(Me.btn_AgregarCupon)
        Me.gb_Cupones.Dock = System.Windows.Forms.DockStyle.Top
        Me.gb_Cupones.Location = New System.Drawing.Point(2, 2)
        Me.gb_Cupones.Name = "gb_Cupones"
        Me.gb_Cupones.Size = New System.Drawing.Size(126, 226)
        Me.gb_Cupones.TabIndex = 0
        Me.gb_Cupones.Text = "Cupones"
        '
        'lv_Cupones
        '
        Me.lv_Cupones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lv_Cupones.Location = New System.Drawing.Point(2, 32)
        Me.lv_Cupones.Name = "lv_Cupones"
        Me.lv_Cupones.Size = New System.Drawing.Size(122, 192)
        Me.lv_Cupones.TabIndex = 22
        '
        'btn_AgregarCupon
        '
        Me.btn_AgregarCupon.Location = New System.Drawing.Point(94, 4)
        Me.btn_AgregarCupon.Name = "btn_AgregarCupon"
        Me.btn_AgregarCupon.Size = New System.Drawing.Size(27, 22)
        Me.btn_AgregarCupon.TabIndex = 0
        Me.btn_AgregarCupon.Text = "+"
        Me.btn_AgregarCupon.ToolTip = "Agregar/Eliminar Cupon"
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.gb_Plazas)
        Me.PanelControl3.Controls.Add(Me.gb_Recurrencia)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl3.Location = New System.Drawing.Point(890, 82)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(130, 492)
        Me.PanelControl3.TabIndex = 5
        '
        'gb_Plazas
        '
        Me.gb_Plazas.Controls.Add(Me.lv_Plazas)
        Me.gb_Plazas.Controls.Add(Me.btn_AgregarPlazas)
        Me.gb_Plazas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gb_Plazas.Location = New System.Drawing.Point(2, 228)
        Me.gb_Plazas.Name = "gb_Plazas"
        Me.gb_Plazas.Size = New System.Drawing.Size(126, 262)
        Me.gb_Plazas.TabIndex = 1
        Me.gb_Plazas.Text = "Plazas"
        '
        'lv_Plazas
        '
        Me.lv_Plazas.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lv_Plazas.Location = New System.Drawing.Point(2, 67)
        Me.lv_Plazas.Name = "lv_Plazas"
        Me.lv_Plazas.Size = New System.Drawing.Size(122, 193)
        Me.lv_Plazas.TabIndex = 24
        '
        'btn_AgregarPlazas
        '
        Me.btn_AgregarPlazas.Location = New System.Drawing.Point(94, 4)
        Me.btn_AgregarPlazas.Name = "btn_AgregarPlazas"
        Me.btn_AgregarPlazas.Size = New System.Drawing.Size(27, 22)
        Me.btn_AgregarPlazas.TabIndex = 0
        Me.btn_AgregarPlazas.Text = "+"
        Me.btn_AgregarPlazas.ToolTip = "Agregar/Eliminar plaza"
        '
        'gb_Recurrencia
        '
        Me.gb_Recurrencia.Controls.Add(Me.lv_Recurrencia)
        Me.gb_Recurrencia.Controls.Add(Me.btn_AgregarRecurrencia)
        Me.gb_Recurrencia.Dock = System.Windows.Forms.DockStyle.Top
        Me.gb_Recurrencia.Location = New System.Drawing.Point(2, 2)
        Me.gb_Recurrencia.Name = "gb_Recurrencia"
        Me.gb_Recurrencia.Size = New System.Drawing.Size(126, 226)
        Me.gb_Recurrencia.TabIndex = 0
        Me.gb_Recurrencia.Text = "Recurrencia"
        '
        'lv_Recurrencia
        '
        Me.lv_Recurrencia.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lv_Recurrencia.Location = New System.Drawing.Point(2, 32)
        Me.lv_Recurrencia.Name = "lv_Recurrencia"
        Me.lv_Recurrencia.Size = New System.Drawing.Size(122, 192)
        Me.lv_Recurrencia.TabIndex = 35
        '
        'btn_AgregarRecurrencia
        '
        Me.btn_AgregarRecurrencia.Location = New System.Drawing.Point(94, 4)
        Me.btn_AgregarRecurrencia.Name = "btn_AgregarRecurrencia"
        Me.btn_AgregarRecurrencia.Size = New System.Drawing.Size(27, 22)
        Me.btn_AgregarRecurrencia.TabIndex = 0
        Me.btn_AgregarRecurrencia.Text = "+"
        Me.btn_AgregarRecurrencia.ToolTip = "Agregar/Eliminar recurrencia"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.PanelControl5)
        Me.PanelControl2.Controls.Add(Me.gb_TipoPromocion)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(1020, 82)
        Me.PanelControl2.TabIndex = 3
        '
        'PanelControl5
        '
        Me.PanelControl5.Controls.Add(Me.pb_Imagen)
        Me.PanelControl5.Controls.Add(Me.txt_UniPromo)
        Me.PanelControl5.Controls.Add(Me.lbl_UniPromo)
        Me.PanelControl5.Controls.Add(Me.txt_ImpMinimo)
        Me.PanelControl5.Controls.Add(Me.lbl_ImpMin)
        Me.PanelControl5.Controls.Add(Me.txt_UniMin)
        Me.PanelControl5.Controls.Add(Me.lbl_UniMin)
        Me.PanelControl5.Controls.Add(Me.lbl_IdPromocion)
        Me.PanelControl5.Controls.Add(Me.txt_IdPromocion)
        Me.PanelControl5.Controls.Add(Me.cbo_Clasificacion)
        Me.PanelControl5.Controls.Add(Me.lbl_Clasificacion)
        Me.PanelControl5.Controls.Add(Me.chk_Acumulable)
        Me.PanelControl5.Controls.Add(Me.chk_ClientesNoRegistrados)
        Me.PanelControl5.Controls.Add(Me.chk_ParesUnicos)
        Me.PanelControl5.Controls.Add(Me.btn_Guardar)
        Me.PanelControl5.Controls.Add(Me.cbo_Señalizador)
        Me.PanelControl5.Controls.Add(Me.cbo_Preciero)
        Me.PanelControl5.Controls.Add(Me.lbl_Señalizador)
        Me.PanelControl5.Controls.Add(Me.lbl_Preciero)
        Me.PanelControl5.Controls.Add(Me.cbo_Estatus)
        Me.PanelControl5.Controls.Add(Me.lbl_Estatus)
        Me.PanelControl5.Controls.Add(Me.gb_Vigencia)
        Me.PanelControl5.Controls.Add(Me.lbl_Nombre)
        Me.PanelControl5.Controls.Add(Me.txt_Nombre)
        Me.PanelControl5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl5.Location = New System.Drawing.Point(106, 2)
        Me.PanelControl5.Name = "PanelControl5"
        Me.PanelControl5.Size = New System.Drawing.Size(912, 78)
        Me.PanelControl5.TabIndex = 1
        '
        'pb_Imagen
        '
        Me.pb_Imagen.EditValue = ""
        Me.pb_Imagen.Location = New System.Drawing.Point(758, 7)
        Me.pb_Imagen.Name = "pb_Imagen"
        Me.pb_Imagen.Properties.PictureStoreMode = DevExpress.XtraEditors.Controls.PictureStoreMode.ByteArray
        Me.pb_Imagen.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.pb_Imagen.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.pb_Imagen.Size = New System.Drawing.Size(65, 61)
        Me.pb_Imagen.TabIndex = 13
        '
        'txt_UniPromo
        '
        Me.txt_UniPromo.Location = New System.Drawing.Point(557, 52)
        Me.txt_UniPromo.Name = "txt_UniPromo"
        Me.txt_UniPromo.Size = New System.Drawing.Size(53, 20)
        Me.txt_UniPromo.TabIndex = 9
        '
        'lbl_UniPromo
        '
        Me.lbl_UniPromo.Location = New System.Drawing.Point(504, 55)
        Me.lbl_UniPromo.Name = "lbl_UniPromo"
        Me.lbl_UniPromo.Size = New System.Drawing.Size(48, 13)
        Me.lbl_UniPromo.TabIndex = 32
        Me.lbl_UniPromo.Text = "Uni Promo"
        '
        'txt_ImpMinimo
        '
        Me.txt_ImpMinimo.Location = New System.Drawing.Point(557, 27)
        Me.txt_ImpMinimo.Name = "txt_ImpMinimo"
        Me.txt_ImpMinimo.Properties.Mask.EditMask = "f"
        Me.txt_ImpMinimo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txt_ImpMinimo.Size = New System.Drawing.Size(53, 20)
        Me.txt_ImpMinimo.TabIndex = 8
        '
        'lbl_ImpMin
        '
        Me.lbl_ImpMin.Location = New System.Drawing.Point(495, 30)
        Me.lbl_ImpMin.Name = "lbl_ImpMin"
        Me.lbl_ImpMin.Size = New System.Drawing.Size(57, 13)
        Me.lbl_ImpMin.TabIndex = 30
        Me.lbl_ImpMin.Text = "Importe Min"
        '
        'txt_UniMin
        '
        Me.txt_UniMin.Location = New System.Drawing.Point(557, 3)
        Me.txt_UniMin.Name = "txt_UniMin"
        Me.txt_UniMin.Size = New System.Drawing.Size(53, 20)
        Me.txt_UniMin.TabIndex = 7
        '
        'lbl_UniMin
        '
        Me.lbl_UniMin.Location = New System.Drawing.Point(518, 6)
        Me.lbl_UniMin.Name = "lbl_UniMin"
        Me.lbl_UniMin.Size = New System.Drawing.Size(34, 13)
        Me.lbl_UniMin.TabIndex = 28
        Me.lbl_UniMin.Text = "Uni Min"
        '
        'lbl_IdPromocion
        '
        Me.lbl_IdPromocion.Location = New System.Drawing.Point(6, 6)
        Me.lbl_IdPromocion.Name = "lbl_IdPromocion"
        Me.lbl_IdPromocion.Size = New System.Drawing.Size(59, 13)
        Me.lbl_IdPromocion.TabIndex = 27
        Me.lbl_IdPromocion.Text = "IdPromocion"
        '
        'txt_IdPromocion
        '
        Me.txt_IdPromocion.Location = New System.Drawing.Point(70, 3)
        Me.txt_IdPromocion.Name = "txt_IdPromocion"
        Me.txt_IdPromocion.Properties.ReadOnly = True
        Me.txt_IdPromocion.Size = New System.Drawing.Size(50, 20)
        Me.txt_IdPromocion.TabIndex = 0
        '
        'cbo_Clasificacion
        '
        Me.cbo_Clasificacion.EditValue = "REBAJA"
        Me.cbo_Clasificacion.Location = New System.Drawing.Point(70, 56)
        Me.cbo_Clasificacion.Name = "cbo_Clasificacion"
        Me.cbo_Clasificacion.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbo_Clasificacion.Properties.Items.AddRange(New Object() {"REBAJA", "GASTO"})
        Me.cbo_Clasificacion.Size = New System.Drawing.Size(90, 20)
        Me.cbo_Clasificacion.TabIndex = 3
        '
        'lbl_Clasificacion
        '
        Me.lbl_Clasificacion.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.lbl_Clasificacion.Location = New System.Drawing.Point(7, 59)
        Me.lbl_Clasificacion.Name = "lbl_Clasificacion"
        Me.lbl_Clasificacion.Size = New System.Drawing.Size(58, 13)
        Me.lbl_Clasificacion.TabIndex = 24
        Me.lbl_Clasificacion.Text = "Clasificación"
        '
        'chk_Acumulable
        '
        Me.chk_Acumulable.Location = New System.Drawing.Point(619, 4)
        Me.chk_Acumulable.Name = "chk_Acumulable"
        Me.chk_Acumulable.Properties.Caption = "Acumulable"
        Me.chk_Acumulable.Size = New System.Drawing.Size(75, 19)
        Me.chk_Acumulable.TabIndex = 10
        '
        'chk_ClientesNoRegistrados
        '
        Me.chk_ClientesNoRegistrados.Location = New System.Drawing.Point(619, 52)
        Me.chk_ClientesNoRegistrados.Name = "chk_ClientesNoRegistrados"
        Me.chk_ClientesNoRegistrados.Properties.Caption = "Clientes NO registrados"
        Me.chk_ClientesNoRegistrados.Size = New System.Drawing.Size(135, 19)
        Me.chk_ClientesNoRegistrados.TabIndex = 12
        '
        'chk_ParesUnicos
        '
        Me.chk_ParesUnicos.Location = New System.Drawing.Point(619, 27)
        Me.chk_ParesUnicos.Name = "chk_ParesUnicos"
        Me.chk_ParesUnicos.Properties.Caption = "Pares Unicos"
        Me.chk_ParesUnicos.Size = New System.Drawing.Size(86, 19)
        Me.chk_ParesUnicos.TabIndex = 11
        '
        'btn_Guardar
        '
        Me.btn_Guardar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Guardar.ImageOptions.ImageUri.Uri = "Apply"
        Me.btn_Guardar.Location = New System.Drawing.Point(829, 10)
        Me.btn_Guardar.Name = "btn_Guardar"
        Me.btn_Guardar.Size = New System.Drawing.Size(57, 54)
        Me.btn_Guardar.TabIndex = 14
        Me.btn_Guardar.ToolTip = "Guardar"
        '
        'cbo_Señalizador
        '
        Me.cbo_Señalizador.Location = New System.Drawing.Point(226, 30)
        Me.cbo_Señalizador.Name = "cbo_Señalizador"
        Me.cbo_Señalizador.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbo_Señalizador.Properties.NullText = "Seleccione"
        Me.cbo_Señalizador.Size = New System.Drawing.Size(100, 20)
        Me.cbo_Señalizador.TabIndex = 4
        '
        'cbo_Preciero
        '
        Me.cbo_Preciero.Location = New System.Drawing.Point(226, 56)
        Me.cbo_Preciero.Name = "cbo_Preciero"
        Me.cbo_Preciero.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbo_Preciero.Properties.NullText = "Seleccione"
        Me.cbo_Preciero.Size = New System.Drawing.Size(100, 20)
        Me.cbo_Preciero.TabIndex = 5
        '
        'lbl_Señalizador
        '
        Me.lbl_Señalizador.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.lbl_Señalizador.Location = New System.Drawing.Point(166, 33)
        Me.lbl_Señalizador.Name = "lbl_Señalizador"
        Me.lbl_Señalizador.Size = New System.Drawing.Size(55, 13)
        Me.lbl_Señalizador.TabIndex = 17
        Me.lbl_Señalizador.Text = "Señalizador"
        '
        'lbl_Preciero
        '
        Me.lbl_Preciero.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.lbl_Preciero.Location = New System.Drawing.Point(182, 60)
        Me.lbl_Preciero.Name = "lbl_Preciero"
        Me.lbl_Preciero.Size = New System.Drawing.Size(39, 13)
        Me.lbl_Preciero.TabIndex = 16
        Me.lbl_Preciero.Text = "Preciero"
        '
        'cbo_Estatus
        '
        Me.cbo_Estatus.EditValue = "CAPTURA"
        Me.cbo_Estatus.Location = New System.Drawing.Point(70, 30)
        Me.cbo_Estatus.Name = "cbo_Estatus"
        Me.cbo_Estatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbo_Estatus.Properties.Items.AddRange(New Object() {"CAPTURA", "APLICADO", "EN PAUSA", "CANCELADO"})
        Me.cbo_Estatus.Properties.ReadOnly = True
        Me.cbo_Estatus.Size = New System.Drawing.Size(90, 20)
        Me.cbo_Estatus.TabIndex = 2
        '
        'lbl_Estatus
        '
        Me.lbl_Estatus.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.lbl_Estatus.Location = New System.Drawing.Point(29, 33)
        Me.lbl_Estatus.Name = "lbl_Estatus"
        Me.lbl_Estatus.Size = New System.Drawing.Size(36, 13)
        Me.lbl_Estatus.TabIndex = 14
        Me.lbl_Estatus.Text = "Estatus"
        '
        'gb_Vigencia
        '
        Me.gb_Vigencia.Controls.Add(Me.dt_VigenciaFin)
        Me.gb_Vigencia.Controls.Add(Me.dt_VigenciaIni)
        Me.gb_Vigencia.Controls.Add(Me.lbl_IniVigencia)
        Me.gb_Vigencia.Controls.Add(Me.lbl_FinVigencia)
        Me.gb_Vigencia.Location = New System.Drawing.Point(332, 3)
        Me.gb_Vigencia.Name = "gb_Vigencia"
        Me.gb_Vigencia.Size = New System.Drawing.Size(156, 77)
        Me.gb_Vigencia.TabIndex = 6
        Me.gb_Vigencia.Text = "Vigencia"
        '
        'dt_VigenciaFin
        '
        Me.dt_VigenciaFin.EditValue = Nothing
        Me.dt_VigenciaFin.Location = New System.Drawing.Point(37, 47)
        Me.dt_VigenciaFin.Name = "dt_VigenciaFin"
        Me.dt_VigenciaFin.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dt_VigenciaFin.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dt_VigenciaFin.Size = New System.Drawing.Size(108, 20)
        Me.dt_VigenciaFin.TabIndex = 7
        '
        'dt_VigenciaIni
        '
        Me.dt_VigenciaIni.EditValue = Nothing
        Me.dt_VigenciaIni.Location = New System.Drawing.Point(37, 21)
        Me.dt_VigenciaIni.Name = "dt_VigenciaIni"
        Me.dt_VigenciaIni.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dt_VigenciaIni.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dt_VigenciaIni.Size = New System.Drawing.Size(108, 20)
        Me.dt_VigenciaIni.TabIndex = 1
        '
        'lbl_IniVigencia
        '
        Me.lbl_IniVigencia.Location = New System.Drawing.Point(6, 25)
        Me.lbl_IniVigencia.Name = "lbl_IniVigencia"
        Me.lbl_IniVigencia.Size = New System.Drawing.Size(25, 13)
        Me.lbl_IniVigencia.TabIndex = 4
        Me.lbl_IniVigencia.Text = "Inicio"
        '
        'lbl_FinVigencia
        '
        Me.lbl_FinVigencia.Location = New System.Drawing.Point(17, 50)
        Me.lbl_FinVigencia.Name = "lbl_FinVigencia"
        Me.lbl_FinVigencia.Size = New System.Drawing.Size(14, 13)
        Me.lbl_FinVigencia.TabIndex = 5
        Me.lbl_FinVigencia.Text = "Fin"
        '
        'lbl_Nombre
        '
        Me.lbl_Nombre.Location = New System.Drawing.Point(127, 6)
        Me.lbl_Nombre.Name = "lbl_Nombre"
        Me.lbl_Nombre.Size = New System.Drawing.Size(37, 13)
        Me.lbl_Nombre.TabIndex = 12
        Me.lbl_Nombre.Text = "Nombre"
        '
        'txt_Nombre
        '
        Me.txt_Nombre.Location = New System.Drawing.Point(169, 3)
        Me.txt_Nombre.Name = "txt_Nombre"
        Me.txt_Nombre.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Nombre.Size = New System.Drawing.Size(157, 20)
        Me.txt_Nombre.TabIndex = 1
        '
        'gb_TipoPromocion
        '
        Me.gb_TipoPromocion.Controls.Add(Me.rb_AxB)
        Me.gb_TipoPromocion.Controls.Add(Me.rb_Directa)
        Me.gb_TipoPromocion.Dock = System.Windows.Forms.DockStyle.Left
        Me.gb_TipoPromocion.Location = New System.Drawing.Point(2, 2)
        Me.gb_TipoPromocion.Name = "gb_TipoPromocion"
        Me.gb_TipoPromocion.Size = New System.Drawing.Size(104, 78)
        Me.gb_TipoPromocion.TabIndex = 0
        Me.gb_TipoPromocion.Text = "Tipo Promoción"
        '
        'rb_AxB
        '
        Me.rb_AxB.AutoSize = True
        Me.rb_AxB.Location = New System.Drawing.Point(10, 47)
        Me.rb_AxB.Name = "rb_AxB"
        Me.rb_AxB.Size = New System.Drawing.Size(44, 17)
        Me.rb_AxB.TabIndex = 1
        Me.rb_AxB.Text = "AxB"
        Me.rb_AxB.UseVisualStyleBackColor = True
        '
        'rb_Directa
        '
        Me.rb_Directa.AutoSize = True
        Me.rb_Directa.Checked = True
        Me.rb_Directa.Location = New System.Drawing.Point(10, 24)
        Me.rb_Directa.Name = "rb_Directa"
        Me.rb_Directa.Size = New System.Drawing.Size(69, 17)
        Me.rb_Directa.TabIndex = 0
        Me.rb_Directa.TabStop = True
        Me.rb_Directa.Text = "DIRECTA"
        Me.rb_Directa.UseVisualStyleBackColor = True
        '
        'btn_EliminarRestriccion
        '
        Me.btn_EliminarRestriccion.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.btn_EliminarRestriccion.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_EliminarRestriccion.Location = New System.Drawing.Point(13, 41)
        Me.btn_EliminarRestriccion.Name = "btn_EliminarRestriccion"
        Me.btn_EliminarRestriccion.Size = New System.Drawing.Size(33, 30)
        Me.btn_EliminarRestriccion.TabIndex = 3
        Me.btn_EliminarRestriccion.ToolTip = "Agregar Restriccion"
        '
        'frmCatPromociones
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1026, 650)
        Me.Controls.Add(Me.tc_Promociones)
        Me.Controls.Add(Me.PanelControl1)
        Me.KeyPreview = True
        Me.Name = "frmCatPromociones"
        Me.Text = "Promociones"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.tc_Promociones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tc_Promociones.ResumeLayout(False)
        Me.tp_Promociones.ResumeLayout(False)
        CType(Me.gc_Promociones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_Promociones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tp_Promocion.ResumeLayout(False)
        CType(Me.PanelControl9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl9.ResumeLayout(False)
        CType(Me.gc_Restricciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gc_Restricciones.ResumeLayout(False)
        CType(Me.gc_Restriccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_Restriccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl11.ResumeLayout(False)
        CType(Me.gc_Unidades, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_Unidades, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl10.ResumeLayout(False)
        CType(Me.PanelControl7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl7.ResumeLayout(False)
        CType(Me.gc_Agrupaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_Agrupaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl8.ResumeLayout(False)
        CType(Me.gb_Agrupaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_Agrupaciones.ResumeLayout(False)
        CType(Me.PanelControl6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl6.ResumeLayout(False)
        CType(Me.gb_Exclusiones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_Exclusiones.ResumeLayout(False)
        CType(Me.lv_Exclusiones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gb_Cupones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_Cupones.ResumeLayout(False)
        CType(Me.lv_Cupones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.gb_Plazas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_Plazas.ResumeLayout(False)
        CType(Me.lv_Plazas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gb_Recurrencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_Recurrencia.ResumeLayout(False)
        CType(Me.lv_Recurrencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.PanelControl5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl5.ResumeLayout(False)
        Me.PanelControl5.PerformLayout()
        CType(Me.pb_Imagen.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_UniPromo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_ImpMinimo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_UniMin.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_IdPromocion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_Clasificacion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chk_Acumulable.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chk_ClientesNoRegistrados.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chk_ParesUnicos.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_Señalizador.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_Preciero.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_Estatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gb_Vigencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_Vigencia.ResumeLayout(False)
        Me.gb_Vigencia.PerformLayout()
        CType(Me.dt_VigenciaFin.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_VigenciaFin.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_VigenciaIni.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_VigenciaIni.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Nombre.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gb_TipoPromocion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_TipoPromocion.ResumeLayout(False)
        Me.gb_TipoPromocion.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents tc_Promociones As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents tp_Promociones As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents gc_Promociones As DevExpress.XtraGrid.GridControl
    Friend WithEvents dgv_Promociones As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents tp_Promocion As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl5 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents chk_Acumulable As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chk_ClientesNoRegistrados As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chk_ParesUnicos As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents btn_Guardar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cbo_Señalizador As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cbo_Preciero As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lbl_Señalizador As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbl_Preciero As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cbo_Estatus As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lbl_Estatus As DevExpress.XtraEditors.LabelControl
    Friend WithEvents gb_Vigencia As DevExpress.XtraEditors.GroupControl
    Friend WithEvents dt_VigenciaFin As DevExpress.XtraEditors.DateEdit
    Friend WithEvents dt_VigenciaIni As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lbl_IniVigencia As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbl_FinVigencia As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbl_Nombre As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txt_Nombre As DevExpress.XtraEditors.TextEdit
    Friend WithEvents gb_TipoPromocion As DevExpress.XtraEditors.GroupControl
    Friend WithEvents rb_AxB As RadioButton
    Friend WithEvents rb_Directa As RadioButton
    Friend WithEvents PanelControl6 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents gb_Exclusiones As DevExpress.XtraEditors.GroupControl
    Friend WithEvents btn_AgregarExclusiones As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents gb_Plazas As DevExpress.XtraEditors.GroupControl
    Friend WithEvents btn_AgregarPlazas As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents gb_Cupones As DevExpress.XtraEditors.GroupControl
    Friend WithEvents btn_AgregarCupon As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents gb_Recurrencia As DevExpress.XtraEditors.GroupControl
    Friend WithEvents btn_AgregarRecurrencia As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_Salir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_Cancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_Activar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_Consultar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_Modificar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_Nuevo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cbo_Clasificacion As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lbl_Clasificacion As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btn_Pausar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lbl_IdPromocion As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txt_IdPromocion As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PanelControl9 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl10 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl7 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents gc_Agrupaciones As DevExpress.XtraGrid.GridControl
    Friend WithEvents dgv_Agrupaciones As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents idpromocion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl8 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents gb_Agrupaciones As DevExpress.XtraEditors.GroupControl
    Friend WithEvents btn_EliminarAgrupacion As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_AgregarAgrupacion As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txt_ImpMinimo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbl_ImpMin As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txt_UniMin As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbl_UniMin As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txt_UniPromo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbl_UniPromo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents gc_Unidades As DevExpress.XtraGrid.GridControl
    Friend WithEvents dgv_Unidades As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btn_Regresar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_Configurar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lv_Cupones As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents lv_Recurrencia As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents lv_Exclusiones As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents lv_Plazas As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents pb_Imagen As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents gc_Restricciones As DevExpress.XtraEditors.GroupControl
    Friend WithEvents gc_Restriccion As DevExpress.XtraGrid.GridControl
    Friend WithEvents dgv_Restriccion As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gc_ImagenRestriccion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_DescripcionRestriccion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_UsuarioRestriccion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_FumRestriccion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl11 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btn_DisminuyePrioridad As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_AumentaPrioridad As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_AgregarRestriccion As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents gc_Prioridad As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btn_EliminarRestriccion As DevExpress.XtraEditors.SimpleButton
End Class
