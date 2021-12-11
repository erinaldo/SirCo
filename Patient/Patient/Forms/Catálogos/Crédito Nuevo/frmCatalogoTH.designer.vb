<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCatalogoTH
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
        Me.components = New System.ComponentModel.Container()
        Me.Cbo_Negocio = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RepositoryItemPictureEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit()
        Me.DSMuestrasDetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSMuestrasDet = New SIRCO.DSMuestrasDet()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.txt_Pagaree = New System.Windows.Forms.TextBox()
        Me.chk_pagare = New System.Windows.Forms.CheckBox()
        Me.Label153 = New System.Windows.Forms.Label()
        Me.Pnl_Edicion = New DevExpress.XtraEditors.PanelControl()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_Guardar = New DevExpress.XtraEditors.SimpleButton()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.MuestrasdetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MuestrasDetDataSet = New SIRCO.MuestrasDetDataSet()
        Me.MuestrasdetTableAdapter = New SIRCO.MuestrasDetDataSetTableAdapters.muestrasdetTableAdapter()
        Me.TFirmasDocumentos = New System.Windows.Forms.TabPage()
        Me.GridControl3 = New DevExpress.XtraGrid.GridControl()
        Me.UspTraerDistribDocumentosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Usp_TraerDistribDocumentos = New SIRCO.usp_TraerDistribDocumentos()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.col_marca = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coldescrip = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coli = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.colimagen = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemPictureEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit()
        Me.colimagen1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemPictureEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit()
        Me.Pbox = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemComboBox3 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RepositoryItemComboBox2 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.TReferencias = New System.Windows.Forms.TabPage()
        Me.PanelControl14 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl13 = New DevExpress.XtraEditors.PanelControl()
        Me.Txt_CelAmigo = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl86 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_TelAmigo = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl89 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_DireccionAmigo = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl90 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_NombreAmigo = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl92 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl12 = New DevExpress.XtraEditors.PanelControl()
        Me.Txt_TelPadres2 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl79 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_CelPadres = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl80 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_TelPadres1 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl81 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_TelPadres = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl82 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_DireccionPadres = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl83 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_NombrePadre = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl84 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_NombreMadre = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl87 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl11 = New DevExpress.XtraEditors.PanelControl()
        Me.Txt_CelConyuge = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl76 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_TelConyuge = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl78 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_IngresoConyuge = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl47 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_AntiguedadConyuge = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl46 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_PuestoConyuge = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl44 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_EmpresaConyuge = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl45 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_ApMaternoConyuge = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl51 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_ApPaternoConyuge = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl74 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_NombreConyuge = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl75 = New DevExpress.XtraEditors.LabelControl()
        Me.TGenerales = New System.Windows.Forms.TabPage()
        Me.PanelControl5 = New DevExpress.XtraEditors.PanelControl()
        Me.Cbo_Periodicidad = New System.Windows.Forms.ComboBox()
        Me.Cbo_TipoCredito = New System.Windows.Forms.ComboBox()
        Me.LabelControl43 = New DevExpress.XtraEditors.LabelControl()
        Me.Cbo_Promocion = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LabelControl42 = New DevExpress.XtraEditors.LabelControl()
        Me.Cbo_NegExt = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LabelControl41 = New DevExpress.XtraEditors.LabelControl()
        Me.Cbo_ContraVale = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.Txt_LimiteVale = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl38 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl40 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl39 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_Disponible = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl35 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_Saldo = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl36 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_LimiteCredito = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl37 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl()
        Me.Txt_IngresoTotal = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl34 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_OtrosIngresos = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl33 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_IngresoMensual = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl32 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_AntiguedadEmpresa = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl31 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_Puesto = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl30 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_DireccionEmpresa = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl29 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_Empresa = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl28 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.Txt_Email = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl27 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_Celular2 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl26 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_Celular1 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl25 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_TelOtro = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl24 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_TelCasa = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl23 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.Cbo_TipoVivienda = New System.Windows.Forms.ComboBox()
        Me.Cbo_Estado = New System.Windows.Forms.ComboBox()
        Me.Cbo_Ciudad = New System.Windows.Forms.ComboBox()
        Me.Cbo_Colonia = New System.Windows.Forms.ComboBox()
        Me.Cbo_CodigoPostal = New System.Windows.Forms.ComboBox()
        Me.Txt_ValorAutos = New DevExpress.XtraEditors.TextEdit()
        Me.Lbl_ValorEstimadoAutos = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_ValorCasa = New DevExpress.XtraEditors.TextEdit()
        Me.Lbl_ValorEstimadoCasa = New DevExpress.XtraEditors.LabelControl()
        Me.Btn_Google = New DevExpress.XtraEditors.SimpleButton()
        Me.Txt_AntiguedadVivienda = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl20 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl19 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_EntreCalles = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl17 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl16 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl15 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl14 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_Numero = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_Calle = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl18 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.Cbo_Sexo = New System.Windows.Forms.ComboBox()
        Me.Cbo_EstadoCivil = New System.Windows.Forms.ComboBox()
        Me.Txt_Dependientes = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.Dt_FechaNacim = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_Apmaterno = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_Appaterno = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_Nombre = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.Pnl_Nombre = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_NombreCompleto = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_TarjetaHabiente = New DevExpress.XtraEditors.TextEdit()
        Me.Txt_IdDistrib = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TabDistribR = New System.Windows.Forms.TabControl()
        Me.TComerciales = New System.Windows.Forms.TabPage()
        Me.GridReferencias = New DevExpress.XtraGrid.GridControl()
        Me.UspTraerDistribComercialesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Usp_TraerDistribComerciales = New SIRCO.usp_TraerDistribComerciales()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colmarca = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colnegocio = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTarjeta = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLimite = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coledocuenta = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coledocuenta1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemPictureEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Usp_TraerDistribComercialesTableAdapter = New SIRCO.usp_TraerDistribComercialesTableAdapters.usp_TraerDistribComercialesTableAdapter()
        Me.Usp_TraerDistribDocumentosTableAdapter = New SIRCO.usp_TraerDistribDocumentosTableAdapters.usp_TraerDistribDocumentosTableAdapter()
        CType(Me.Cbo_Negocio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemPictureEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSMuestrasDetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSMuestrasDet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        CType(Me.Pnl_Edicion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_Edicion.SuspendLayout()
        CType(Me.MuestrasdetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MuestrasDetDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TFirmasDocumentos.SuspendLayout()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UspTraerDistribDocumentosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Usp_TraerDistribDocumentos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemPictureEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemPictureEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pbox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TReferencias.SuspendLayout()
        CType(Me.PanelControl14, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl14.SuspendLayout()
        CType(Me.PanelControl13, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl13.SuspendLayout()
        CType(Me.Txt_CelAmigo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_TelAmigo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_DireccionAmigo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_NombreAmigo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl12, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl12.SuspendLayout()
        CType(Me.Txt_TelPadres2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_CelPadres.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_TelPadres1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_TelPadres.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_DireccionPadres.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_NombrePadre.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_NombreMadre.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl11.SuspendLayout()
        CType(Me.Txt_CelConyuge.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_TelConyuge.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_IngresoConyuge.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_AntiguedadConyuge.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_PuestoConyuge.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_EmpresaConyuge.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_ApMaternoConyuge.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_ApPaternoConyuge.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_NombreConyuge.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TGenerales.SuspendLayout()
        CType(Me.PanelControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl5.SuspendLayout()
        CType(Me.Cbo_Promocion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cbo_NegExt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cbo_ContraVale.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_LimiteVale.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_Disponible.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_Saldo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_LimiteCredito.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        CType(Me.Txt_IngresoTotal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_OtrosIngresos.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_IngresoMensual.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_AntiguedadEmpresa.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_Puesto.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_DireccionEmpresa.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_Empresa.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.Txt_Email.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_Celular2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_Celular1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_TelOtro.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_TelCasa.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.Txt_ValorAutos.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_ValorCasa.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_AntiguedadVivienda.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_EntreCalles.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_Numero.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_Calle.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.Txt_Dependientes.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dt_FechaNacim.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dt_FechaNacim.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_Apmaterno.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_Appaterno.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_Nombre.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pnl_Nombre, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_Nombre.SuspendLayout()
        CType(Me.Txt_NombreCompleto.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_TarjetaHabiente.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_IdDistrib.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabDistribR.SuspendLayout()
        Me.TComerciales.SuspendLayout()
        CType(Me.GridReferencias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UspTraerDistribComercialesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Usp_TraerDistribComerciales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemPictureEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Cbo_Negocio
        '
        Me.Cbo_Negocio.AutoHeight = False
        Me.Cbo_Negocio.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Cbo_Negocio.Items.AddRange(New Object() {"CIMACO", "LIVERPOOL", "SEARS", "SANBORNS", "C&A"})
        Me.Cbo_Negocio.MaxLength = 17
        Me.Cbo_Negocio.Name = "Cbo_Negocio"
        '
        'RepositoryItemPictureEdit1
        '
        Me.RepositoryItemPictureEdit1.Name = "RepositoryItemPictureEdit1"
        Me.RepositoryItemPictureEdit1.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        '
        'DSMuestrasDetBindingSource
        '
        Me.DSMuestrasDetBindingSource.DataSource = Me.DSMuestrasDet
        Me.DSMuestrasDetBindingSource.Position = 0
        '
        'DSMuestrasDet
        '
        Me.DSMuestrasDet.DataSetName = "DSMuestrasDet"
        Me.DSMuestrasDet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.txt_Pagaree)
        Me.GroupBox7.Controls.Add(Me.chk_pagare)
        Me.GroupBox7.Controls.Add(Me.Label153)
        Me.GroupBox7.Location = New System.Drawing.Point(5, 5)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(332, 79)
        Me.GroupBox7.TabIndex = 46
        Me.GroupBox7.TabStop = False
        '
        'txt_Pagaree
        '
        Me.txt_Pagaree.Location = New System.Drawing.Point(10, 52)
        Me.txt_Pagaree.Name = "txt_Pagaree"
        Me.txt_Pagaree.Size = New System.Drawing.Size(104, 21)
        Me.txt_Pagaree.TabIndex = 109
        Me.txt_Pagaree.Text = "$0.00"
        '
        'chk_pagare
        '
        Me.chk_pagare.AutoSize = True
        Me.chk_pagare.Location = New System.Drawing.Point(6, 16)
        Me.chk_pagare.Name = "chk_pagare"
        Me.chk_pagare.Size = New System.Drawing.Size(109, 17)
        Me.chk_pagare.TabIndex = 108
        Me.chk_pagare.Text = "Pagare en blanco"
        Me.chk_pagare.UseVisualStyleBackColor = True
        '
        'Label153
        '
        Me.Label153.AutoSize = True
        Me.Label153.Location = New System.Drawing.Point(9, 36)
        Me.Label153.Name = "Label153"
        Me.Label153.Size = New System.Drawing.Size(101, 13)
        Me.Label153.TabIndex = 14
        Me.Label153.Text = "Pagare Firmado Por"
        '
        'Pnl_Edicion
        '
        Me.Pnl_Edicion.Controls.Add(Me.SimpleButton2)
        Me.Pnl_Edicion.Controls.Add(Me.Btn_Guardar)
        Me.Pnl_Edicion.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Edicion.Location = New System.Drawing.Point(0, 446)
        Me.Pnl_Edicion.Name = "Pnl_Edicion"
        Me.Pnl_Edicion.Size = New System.Drawing.Size(1084, 54)
        Me.Pnl_Edicion.TabIndex = 91
        '
        'SimpleButton2
        '
        Me.SimpleButton2.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.cancel1
        Me.SimpleButton2.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.SimpleButton2.Location = New System.Drawing.Point(957, 4)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(51, 50)
        Me.SimpleButton2.TabIndex = 5
        '
        'Btn_Guardar
        '
        Me.Btn_Guardar.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_Guardar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.Btn_Guardar.Location = New System.Drawing.Point(1014, 4)
        Me.Btn_Guardar.Name = "Btn_Guardar"
        Me.Btn_Guardar.Size = New System.Drawing.Size(51, 50)
        Me.Btn_Guardar.TabIndex = 4
        Me.Btn_Guardar.Text = "----"
        Me.Btn_Guardar.ToolTip = "Registrar llamada Call Center"
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'MuestrasdetBindingSource
        '
        Me.MuestrasdetBindingSource.DataMember = "muestrasdet"
        Me.MuestrasdetBindingSource.DataSource = Me.MuestrasDetDataSet
        '
        'MuestrasDetDataSet
        '
        Me.MuestrasDetDataSet.DataSetName = "MuestrasDetDataSet"
        Me.MuestrasDetDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'MuestrasdetTableAdapter
        '
        Me.MuestrasdetTableAdapter.ClearBeforeFill = True
        '
        'TFirmasDocumentos
        '
        Me.TFirmasDocumentos.Controls.Add(Me.GridControl3)
        Me.TFirmasDocumentos.Location = New System.Drawing.Point(4, 22)
        Me.TFirmasDocumentos.Name = "TFirmasDocumentos"
        Me.TFirmasDocumentos.Size = New System.Drawing.Size(1067, 410)
        Me.TFirmasDocumentos.TabIndex = 3
        Me.TFirmasDocumentos.Text = "Firmas y Documentos"
        Me.TFirmasDocumentos.UseVisualStyleBackColor = True
        '
        'GridControl3
        '
        Me.GridControl3.DataSource = Me.UspTraerDistribDocumentosBindingSource
        Me.GridControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl3.Location = New System.Drawing.Point(0, 0)
        Me.GridControl3.MainView = Me.GridView1
        Me.GridControl3.Name = "GridControl3"
        Me.GridControl3.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.Pbox, Me.RepositoryItemTextEdit1, Me.RepositoryItemComboBox3, Me.RepositoryItemComboBox1, Me.RepositoryItemComboBox2, Me.RepositoryItemPictureEdit3, Me.RepositoryItemPictureEdit4})
        Me.GridControl3.Size = New System.Drawing.Size(1067, 410)
        Me.GridControl3.TabIndex = 11
        Me.GridControl3.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'UspTraerDistribDocumentosBindingSource
        '
        Me.UspTraerDistribDocumentosBindingSource.DataMember = "usp_TraerDistribDocumentos"
        Me.UspTraerDistribDocumentosBindingSource.DataSource = Me.Usp_TraerDistribDocumentos
        '
        'Usp_TraerDistribDocumentos
        '
        Me.Usp_TraerDistribDocumentos.DataSetName = "usp_TraerDistribDocumentos"
        Me.Usp_TraerDistribDocumentos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridView1
        '
        Me.GridView1.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridView1.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridView1.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.col_marca, Me.coldescrip, Me.coli, Me.colimagen, Me.colimagen1})
        Me.GridView1.GridControl = Me.GridControl3
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.GridView1.RowHeight = 100
        '
        'col_marca
        '
        Me.col_marca.AppearanceCell.Options.UseTextOptions = True
        Me.col_marca.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.col_marca.Caption = "Marca"
        Me.col_marca.FieldName = "medini"
        Me.col_marca.Name = "col_marca"
        Me.col_marca.OptionsEditForm.StartNewRow = True
        Me.col_marca.Width = 71
        '
        'coldescrip
        '
        Me.coldescrip.Caption = "Pertenece"
        Me.coldescrip.FieldName = "descrip"
        Me.coldescrip.Name = "coldescrip"
        Me.coldescrip.Width = 230
        '
        'coli
        '
        Me.coli.AppearanceCell.Options.UseTextOptions = True
        Me.coli.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.coli.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.coli.Caption = "Tipo Documento"
        Me.coli.ColumnEdit = Me.RepositoryItemComboBox1
        Me.coli.FieldName = "documento"
        Me.coli.Name = "coli"
        Me.coli.Visible = True
        Me.coli.VisibleIndex = 0
        Me.coli.Width = 150
        '
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.Items.AddRange(New Object() {"FIRMA", "CASA", "EDO. DE CUENTA", "INE", "INGRESOS", "COMPROBANTE", "PAGARE", "DISTRIBUIDOR", "CROQUIS"})
        Me.RepositoryItemComboBox1.MaxLength = 15
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        Me.RepositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'colimagen
        '
        Me.colimagen.Caption = "Imagen"
        Me.colimagen.ColumnEdit = Me.RepositoryItemPictureEdit3
        Me.colimagen.FieldName = "imagen"
        Me.colimagen.MinWidth = 100
        Me.colimagen.Name = "colimagen"
        Me.colimagen.Visible = True
        Me.colimagen.VisibleIndex = 1
        Me.colimagen.Width = 120
        '
        'RepositoryItemPictureEdit3
        '
        Me.RepositoryItemPictureEdit3.Name = "RepositoryItemPictureEdit3"
        Me.RepositoryItemPictureEdit3.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        '
        'colimagen1
        '
        Me.colimagen1.Caption = "Imagen"
        Me.colimagen1.ColumnEdit = Me.RepositoryItemPictureEdit4
        Me.colimagen1.FieldName = "imagen1"
        Me.colimagen1.Name = "colimagen1"
        Me.colimagen1.Visible = True
        Me.colimagen1.VisibleIndex = 2
        Me.colimagen1.Width = 120
        '
        'RepositoryItemPictureEdit4
        '
        Me.RepositoryItemPictureEdit4.Name = "RepositoryItemPictureEdit4"
        Me.RepositoryItemPictureEdit4.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        '
        'Pbox
        '
        Me.Pbox.LookAndFeel.SkinName = "Office 2013"
        Me.Pbox.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.Pbox.Name = "Pbox"
        Me.Pbox.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.Mask.EditMask = "99"
        Me.RepositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Custom
        Me.RepositoryItemTextEdit1.MaxLength = 3
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'RepositoryItemComboBox3
        '
        Me.RepositoryItemComboBox3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.RepositoryItemComboBox3.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox3.Items.AddRange(New Object() {"01", "01-", "09", "09-", "10", "10-", "11", "11-", "12", "12-", "13", "13-", "14", "14-", "15", "15-", "16", "16-", "17", "17-", "18", "18-", "19", "19-", "20", "20-", "21", "21-", "22", "22-", "23", "23-", "24", "24-", "25", "25-", "26", "26-", "27", "27-", "28", "28-", "29", "29-", "30", "30-", "31", "31-"})
        Me.RepositoryItemComboBox3.MaxLength = 3
        Me.RepositoryItemComboBox3.Name = "RepositoryItemComboBox3"
        Me.RepositoryItemComboBox3.Sorted = True
        Me.RepositoryItemComboBox3.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'RepositoryItemComboBox2
        '
        Me.RepositoryItemComboBox2.AutoHeight = False
        Me.RepositoryItemComboBox2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.RepositoryItemComboBox2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox2.Items.AddRange(New Object() {"01", "01-", "09", "09-", "10", "10-", "11", "11-", "12", "12-", "13", "13-", "14", "14-", "15", "15-", "16", "16-", "17", "17-", "18", "18-", "19", "19-", "20", "20-", "21", "21-", "22", "22-", "23", "23-", "24", "24-", "25", "25-", "26", "26-", "27", "27-", "28", "28-", "29", "29-", "30", "30-", "31", "31-"})
        Me.RepositoryItemComboBox2.MaxLength = 3
        Me.RepositoryItemComboBox2.Name = "RepositoryItemComboBox2"
        Me.RepositoryItemComboBox2.Sorted = True
        Me.RepositoryItemComboBox2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'TReferencias
        '
        Me.TReferencias.Controls.Add(Me.PanelControl14)
        Me.TReferencias.Controls.Add(Me.PanelControl13)
        Me.TReferencias.Controls.Add(Me.PanelControl12)
        Me.TReferencias.Controls.Add(Me.PanelControl11)
        Me.TReferencias.Location = New System.Drawing.Point(4, 22)
        Me.TReferencias.Name = "TReferencias"
        Me.TReferencias.Size = New System.Drawing.Size(1067, 410)
        Me.TReferencias.TabIndex = 2
        Me.TReferencias.Text = "Referencias"
        Me.TReferencias.UseVisualStyleBackColor = True
        '
        'PanelControl14
        '
        Me.PanelControl14.Controls.Add(Me.GroupBox7)
        Me.PanelControl14.Location = New System.Drawing.Point(1, 280)
        Me.PanelControl14.Name = "PanelControl14"
        Me.PanelControl14.Size = New System.Drawing.Size(1063, 127)
        Me.PanelControl14.TabIndex = 91
        '
        'PanelControl13
        '
        Me.PanelControl13.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D
        Me.PanelControl13.Controls.Add(Me.Txt_CelAmigo)
        Me.PanelControl13.Controls.Add(Me.LabelControl86)
        Me.PanelControl13.Controls.Add(Me.Txt_TelAmigo)
        Me.PanelControl13.Controls.Add(Me.LabelControl89)
        Me.PanelControl13.Controls.Add(Me.Txt_DireccionAmigo)
        Me.PanelControl13.Controls.Add(Me.LabelControl90)
        Me.PanelControl13.Controls.Add(Me.Txt_NombreAmigo)
        Me.PanelControl13.Controls.Add(Me.LabelControl92)
        Me.PanelControl13.Location = New System.Drawing.Point(3, 214)
        Me.PanelControl13.Name = "PanelControl13"
        Me.PanelControl13.Size = New System.Drawing.Size(1061, 60)
        Me.PanelControl13.TabIndex = 98
        '
        'Txt_CelAmigo
        '
        Me.Txt_CelAmigo.Location = New System.Drawing.Point(663, 32)
        Me.Txt_CelAmigo.Name = "Txt_CelAmigo"
        Me.Txt_CelAmigo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_CelAmigo.Properties.Appearance.Options.UseFont = True
        Me.Txt_CelAmigo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_CelAmigo.Properties.MaxLength = 10
        Me.Txt_CelAmigo.Size = New System.Drawing.Size(120, 20)
        Me.Txt_CelAmigo.TabIndex = 59
        Me.Txt_CelAmigo.ToolTip = "Nombre"
        '
        'LabelControl86
        '
        Me.LabelControl86.Location = New System.Drawing.Point(588, 35)
        Me.LabelControl86.Name = "LabelControl86"
        Me.LabelControl86.Size = New System.Drawing.Size(42, 13)
        Me.LabelControl86.TabIndex = 21
        Me.LabelControl86.Text = "Celular 1"
        '
        'Txt_TelAmigo
        '
        Me.Txt_TelAmigo.Location = New System.Drawing.Point(663, 5)
        Me.Txt_TelAmigo.Name = "Txt_TelAmigo"
        Me.Txt_TelAmigo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_TelAmigo.Properties.Appearance.Options.UseFont = True
        Me.Txt_TelAmigo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_TelAmigo.Properties.MaxLength = 10
        Me.Txt_TelAmigo.Size = New System.Drawing.Size(120, 20)
        Me.Txt_TelAmigo.TabIndex = 58
        Me.Txt_TelAmigo.ToolTip = "Nombre"
        '
        'LabelControl89
        '
        Me.LabelControl89.Location = New System.Drawing.Point(588, 8)
        Me.LabelControl89.Name = "LabelControl89"
        Me.LabelControl89.Size = New System.Drawing.Size(69, 13)
        Me.LabelControl89.TabIndex = 17
        Me.LabelControl89.Text = "Teléfono Casa"
        '
        'Txt_DireccionAmigo
        '
        Me.Txt_DireccionAmigo.Location = New System.Drawing.Point(107, 31)
        Me.Txt_DireccionAmigo.Name = "Txt_DireccionAmigo"
        Me.Txt_DireccionAmigo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DireccionAmigo.Properties.Appearance.Options.UseFont = True
        Me.Txt_DireccionAmigo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_DireccionAmigo.Properties.MaxLength = 50
        Me.Txt_DireccionAmigo.Size = New System.Drawing.Size(420, 20)
        Me.Txt_DireccionAmigo.TabIndex = 57
        Me.Txt_DireccionAmigo.ToolTip = "Nombre"
        '
        'LabelControl90
        '
        Me.LabelControl90.Location = New System.Drawing.Point(5, 34)
        Me.LabelControl90.Name = "LabelControl90"
        Me.LabelControl90.Size = New System.Drawing.Size(40, 13)
        Me.LabelControl90.TabIndex = 15
        Me.LabelControl90.Text = "Domicilio"
        '
        'Txt_NombreAmigo
        '
        Me.Txt_NombreAmigo.Location = New System.Drawing.Point(107, 5)
        Me.Txt_NombreAmigo.Name = "Txt_NombreAmigo"
        Me.Txt_NombreAmigo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_NombreAmigo.Properties.Appearance.Options.UseFont = True
        Me.Txt_NombreAmigo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_NombreAmigo.Properties.MaxLength = 100
        Me.Txt_NombreAmigo.Size = New System.Drawing.Size(420, 20)
        Me.Txt_NombreAmigo.TabIndex = 56
        Me.Txt_NombreAmigo.ToolTip = "Nombre"
        '
        'LabelControl92
        '
        Me.LabelControl92.Location = New System.Drawing.Point(5, 8)
        Me.LabelControl92.Name = "LabelControl92"
        Me.LabelControl92.Size = New System.Drawing.Size(29, 13)
        Me.LabelControl92.TabIndex = 6
        Me.LabelControl92.Text = "Amigo"
        '
        'PanelControl12
        '
        Me.PanelControl12.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D
        Me.PanelControl12.Controls.Add(Me.Txt_TelPadres2)
        Me.PanelControl12.Controls.Add(Me.LabelControl79)
        Me.PanelControl12.Controls.Add(Me.Txt_CelPadres)
        Me.PanelControl12.Controls.Add(Me.LabelControl80)
        Me.PanelControl12.Controls.Add(Me.Txt_TelPadres1)
        Me.PanelControl12.Controls.Add(Me.LabelControl81)
        Me.PanelControl12.Controls.Add(Me.Txt_TelPadres)
        Me.PanelControl12.Controls.Add(Me.LabelControl82)
        Me.PanelControl12.Controls.Add(Me.Txt_DireccionPadres)
        Me.PanelControl12.Controls.Add(Me.LabelControl83)
        Me.PanelControl12.Controls.Add(Me.Txt_NombrePadre)
        Me.PanelControl12.Controls.Add(Me.LabelControl84)
        Me.PanelControl12.Controls.Add(Me.Txt_NombreMadre)
        Me.PanelControl12.Controls.Add(Me.LabelControl87)
        Me.PanelControl12.Location = New System.Drawing.Point(3, 117)
        Me.PanelControl12.Name = "PanelControl12"
        Me.PanelControl12.Size = New System.Drawing.Size(1061, 91)
        Me.PanelControl12.TabIndex = 97
        '
        'Txt_TelPadres2
        '
        Me.Txt_TelPadres2.Location = New System.Drawing.Point(880, 5)
        Me.Txt_TelPadres2.Name = "Txt_TelPadres2"
        Me.Txt_TelPadres2.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_TelPadres2.Properties.Appearance.Options.UseFont = True
        Me.Txt_TelPadres2.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_TelPadres2.Properties.MaxLength = 10
        Me.Txt_TelPadres2.Size = New System.Drawing.Size(120, 20)
        Me.Txt_TelPadres2.TabIndex = 55
        Me.Txt_TelPadres2.ToolTip = "Nombre"
        '
        'LabelControl79
        '
        Me.LabelControl79.Location = New System.Drawing.Point(805, 8)
        Me.LabelControl79.Name = "LabelControl79"
        Me.LabelControl79.Size = New System.Drawing.Size(42, 13)
        Me.LabelControl79.TabIndex = 23
        Me.LabelControl79.Text = "Celular 2"
        '
        'Txt_CelPadres
        '
        Me.Txt_CelPadres.Location = New System.Drawing.Point(663, 57)
        Me.Txt_CelPadres.Name = "Txt_CelPadres"
        Me.Txt_CelPadres.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_CelPadres.Properties.Appearance.Options.UseFont = True
        Me.Txt_CelPadres.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_CelPadres.Properties.MaxLength = 10
        Me.Txt_CelPadres.Size = New System.Drawing.Size(120, 20)
        Me.Txt_CelPadres.TabIndex = 54
        Me.Txt_CelPadres.ToolTip = "Nombre"
        '
        'LabelControl80
        '
        Me.LabelControl80.Location = New System.Drawing.Point(588, 60)
        Me.LabelControl80.Name = "LabelControl80"
        Me.LabelControl80.Size = New System.Drawing.Size(42, 13)
        Me.LabelControl80.TabIndex = 21
        Me.LabelControl80.Text = "Celular 1"
        '
        'Txt_TelPadres1
        '
        Me.Txt_TelPadres1.Location = New System.Drawing.Point(663, 31)
        Me.Txt_TelPadres1.Name = "Txt_TelPadres1"
        Me.Txt_TelPadres1.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_TelPadres1.Properties.Appearance.Options.UseFont = True
        Me.Txt_TelPadres1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_TelPadres1.Properties.MaxLength = 10
        Me.Txt_TelPadres1.Size = New System.Drawing.Size(120, 20)
        Me.Txt_TelPadres1.TabIndex = 53
        Me.Txt_TelPadres1.ToolTip = "Nombre"
        '
        'LabelControl81
        '
        Me.LabelControl81.Location = New System.Drawing.Point(588, 34)
        Me.LabelControl81.Name = "LabelControl81"
        Me.LabelControl81.Size = New System.Drawing.Size(67, 13)
        Me.LabelControl81.TabIndex = 19
        Me.LabelControl81.Text = "Teléfono Otro"
        '
        'Txt_TelPadres
        '
        Me.Txt_TelPadres.Location = New System.Drawing.Point(663, 5)
        Me.Txt_TelPadres.Name = "Txt_TelPadres"
        Me.Txt_TelPadres.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_TelPadres.Properties.Appearance.Options.UseFont = True
        Me.Txt_TelPadres.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_TelPadres.Properties.MaxLength = 10
        Me.Txt_TelPadres.Size = New System.Drawing.Size(120, 20)
        Me.Txt_TelPadres.TabIndex = 52
        Me.Txt_TelPadres.ToolTip = "Nombre"
        '
        'LabelControl82
        '
        Me.LabelControl82.Location = New System.Drawing.Point(588, 8)
        Me.LabelControl82.Name = "LabelControl82"
        Me.LabelControl82.Size = New System.Drawing.Size(69, 13)
        Me.LabelControl82.TabIndex = 17
        Me.LabelControl82.Text = "Teléfono Casa"
        '
        'Txt_DireccionPadres
        '
        Me.Txt_DireccionPadres.Location = New System.Drawing.Point(107, 56)
        Me.Txt_DireccionPadres.Name = "Txt_DireccionPadres"
        Me.Txt_DireccionPadres.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DireccionPadres.Properties.Appearance.Options.UseFont = True
        Me.Txt_DireccionPadres.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_DireccionPadres.Properties.MaxLength = 50
        Me.Txt_DireccionPadres.Size = New System.Drawing.Size(420, 20)
        Me.Txt_DireccionPadres.TabIndex = 51
        Me.Txt_DireccionPadres.ToolTip = "Nombre"
        '
        'LabelControl83
        '
        Me.LabelControl83.Location = New System.Drawing.Point(5, 59)
        Me.LabelControl83.Name = "LabelControl83"
        Me.LabelControl83.Size = New System.Drawing.Size(40, 13)
        Me.LabelControl83.TabIndex = 15
        Me.LabelControl83.Text = "Domicilio"
        '
        'Txt_NombrePadre
        '
        Me.Txt_NombrePadre.Location = New System.Drawing.Point(107, 31)
        Me.Txt_NombrePadre.Name = "Txt_NombrePadre"
        Me.Txt_NombrePadre.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_NombrePadre.Properties.Appearance.Options.UseFont = True
        Me.Txt_NombrePadre.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_NombrePadre.Properties.MaxLength = 150
        Me.Txt_NombrePadre.Size = New System.Drawing.Size(420, 20)
        Me.Txt_NombrePadre.TabIndex = 50
        Me.Txt_NombrePadre.ToolTip = "Nombre"
        '
        'LabelControl84
        '
        Me.LabelControl84.Location = New System.Drawing.Point(5, 34)
        Me.LabelControl84.Name = "LabelControl84"
        Me.LabelControl84.Size = New System.Drawing.Size(85, 13)
        Me.LabelControl84.TabIndex = 13
        Me.LabelControl84.Text = "Nombre del Padre"
        '
        'Txt_NombreMadre
        '
        Me.Txt_NombreMadre.Location = New System.Drawing.Point(107, 5)
        Me.Txt_NombreMadre.Name = "Txt_NombreMadre"
        Me.Txt_NombreMadre.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_NombreMadre.Properties.Appearance.Options.UseFont = True
        Me.Txt_NombreMadre.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_NombreMadre.Properties.MaxLength = 100
        Me.Txt_NombreMadre.Size = New System.Drawing.Size(420, 20)
        Me.Txt_NombreMadre.TabIndex = 49
        Me.Txt_NombreMadre.ToolTip = "Nombre"
        '
        'LabelControl87
        '
        Me.LabelControl87.Location = New System.Drawing.Point(5, 8)
        Me.LabelControl87.Name = "LabelControl87"
        Me.LabelControl87.Size = New System.Drawing.Size(96, 13)
        Me.LabelControl87.TabIndex = 6
        Me.LabelControl87.Text = "Nombre de la Madre"
        '
        'PanelControl11
        '
        Me.PanelControl11.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D
        Me.PanelControl11.Controls.Add(Me.Txt_CelConyuge)
        Me.PanelControl11.Controls.Add(Me.LabelControl76)
        Me.PanelControl11.Controls.Add(Me.Txt_TelConyuge)
        Me.PanelControl11.Controls.Add(Me.LabelControl78)
        Me.PanelControl11.Controls.Add(Me.Txt_IngresoConyuge)
        Me.PanelControl11.Controls.Add(Me.LabelControl47)
        Me.PanelControl11.Controls.Add(Me.Txt_AntiguedadConyuge)
        Me.PanelControl11.Controls.Add(Me.LabelControl46)
        Me.PanelControl11.Controls.Add(Me.Txt_PuestoConyuge)
        Me.PanelControl11.Controls.Add(Me.LabelControl44)
        Me.PanelControl11.Controls.Add(Me.Txt_EmpresaConyuge)
        Me.PanelControl11.Controls.Add(Me.LabelControl45)
        Me.PanelControl11.Controls.Add(Me.Txt_ApMaternoConyuge)
        Me.PanelControl11.Controls.Add(Me.LabelControl51)
        Me.PanelControl11.Controls.Add(Me.Txt_ApPaternoConyuge)
        Me.PanelControl11.Controls.Add(Me.LabelControl74)
        Me.PanelControl11.Controls.Add(Me.Txt_NombreConyuge)
        Me.PanelControl11.Controls.Add(Me.LabelControl75)
        Me.PanelControl11.Location = New System.Drawing.Point(3, 3)
        Me.PanelControl11.Name = "PanelControl11"
        Me.PanelControl11.Size = New System.Drawing.Size(1061, 108)
        Me.PanelControl11.TabIndex = 96
        '
        'Txt_CelConyuge
        '
        Me.Txt_CelConyuge.Location = New System.Drawing.Point(525, 82)
        Me.Txt_CelConyuge.Name = "Txt_CelConyuge"
        Me.Txt_CelConyuge.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_CelConyuge.Properties.Appearance.Options.UseFont = True
        Me.Txt_CelConyuge.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_CelConyuge.Properties.MaxLength = 10
        Me.Txt_CelConyuge.Size = New System.Drawing.Size(120, 20)
        Me.Txt_CelConyuge.TabIndex = 48
        Me.Txt_CelConyuge.ToolTip = "Nombre"
        '
        'LabelControl76
        '
        Me.LabelControl76.Location = New System.Drawing.Point(431, 86)
        Me.LabelControl76.Name = "LabelControl76"
        Me.LabelControl76.Size = New System.Drawing.Size(42, 13)
        Me.LabelControl76.TabIndex = 44
        Me.LabelControl76.Text = "Celular 1"
        '
        'Txt_TelConyuge
        '
        Me.Txt_TelConyuge.Location = New System.Drawing.Point(525, 31)
        Me.Txt_TelConyuge.Name = "Txt_TelConyuge"
        Me.Txt_TelConyuge.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_TelConyuge.Properties.Appearance.Options.UseFont = True
        Me.Txt_TelConyuge.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_TelConyuge.Properties.MaxLength = 10
        Me.Txt_TelConyuge.Size = New System.Drawing.Size(120, 20)
        Me.Txt_TelConyuge.TabIndex = 44
        Me.Txt_TelConyuge.ToolTip = "Nombre"
        '
        'LabelControl78
        '
        Me.LabelControl78.Location = New System.Drawing.Point(431, 34)
        Me.LabelControl78.Name = "LabelControl78"
        Me.LabelControl78.Size = New System.Drawing.Size(69, 13)
        Me.LabelControl78.TabIndex = 42
        Me.LabelControl78.Text = "Teléfono Casa"
        '
        'Txt_IngresoConyuge
        '
        Me.Txt_IngresoConyuge.Location = New System.Drawing.Point(525, 56)
        Me.Txt_IngresoConyuge.Name = "Txt_IngresoConyuge"
        Me.Txt_IngresoConyuge.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IngresoConyuge.Properties.Appearance.Options.UseFont = True
        Me.Txt_IngresoConyuge.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_IngresoConyuge.Properties.MaxLength = 250
        Me.Txt_IngresoConyuge.Size = New System.Drawing.Size(120, 20)
        Me.Txt_IngresoConyuge.TabIndex = 47
        Me.Txt_IngresoConyuge.ToolTip = "Nombre"
        '
        'LabelControl47
        '
        Me.LabelControl47.Location = New System.Drawing.Point(428, 59)
        Me.LabelControl47.Name = "LabelControl47"
        Me.LabelControl47.Size = New System.Drawing.Size(79, 13)
        Me.LabelControl47.TabIndex = 40
        Me.LabelControl47.Text = "Ingreso Mensual"
        '
        'Txt_AntiguedadConyuge
        '
        Me.Txt_AntiguedadConyuge.Location = New System.Drawing.Point(352, 56)
        Me.Txt_AntiguedadConyuge.Name = "Txt_AntiguedadConyuge"
        Me.Txt_AntiguedadConyuge.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_AntiguedadConyuge.Properties.Appearance.Options.UseFont = True
        Me.Txt_AntiguedadConyuge.Properties.MaxLength = 3
        Me.Txt_AntiguedadConyuge.Size = New System.Drawing.Size(54, 20)
        Me.Txt_AntiguedadConyuge.TabIndex = 46
        Me.Txt_AntiguedadConyuge.ToolTip = "Nombre"
        '
        'LabelControl46
        '
        Me.LabelControl46.Location = New System.Drawing.Point(291, 59)
        Me.LabelControl46.Name = "LabelControl46"
        Me.LabelControl46.Size = New System.Drawing.Size(55, 13)
        Me.LabelControl46.TabIndex = 37
        Me.LabelControl46.Text = "Antigüedad"
        '
        'Txt_PuestoConyuge
        '
        Me.Txt_PuestoConyuge.Location = New System.Drawing.Point(52, 56)
        Me.Txt_PuestoConyuge.Name = "Txt_PuestoConyuge"
        Me.Txt_PuestoConyuge.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_PuestoConyuge.Properties.Appearance.Options.UseFont = True
        Me.Txt_PuestoConyuge.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_PuestoConyuge.Properties.MaxLength = 50
        Me.Txt_PuestoConyuge.Size = New System.Drawing.Size(218, 20)
        Me.Txt_PuestoConyuge.TabIndex = 45
        Me.Txt_PuestoConyuge.ToolTip = "Nombre"
        '
        'LabelControl44
        '
        Me.LabelControl44.Location = New System.Drawing.Point(5, 59)
        Me.LabelControl44.Name = "LabelControl44"
        Me.LabelControl44.Size = New System.Drawing.Size(33, 13)
        Me.LabelControl44.TabIndex = 15
        Me.LabelControl44.Text = "Puesto"
        '
        'Txt_EmpresaConyuge
        '
        Me.Txt_EmpresaConyuge.Location = New System.Drawing.Point(52, 31)
        Me.Txt_EmpresaConyuge.Name = "Txt_EmpresaConyuge"
        Me.Txt_EmpresaConyuge.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_EmpresaConyuge.Properties.Appearance.Options.UseFont = True
        Me.Txt_EmpresaConyuge.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_EmpresaConyuge.Properties.MaxLength = 150
        Me.Txt_EmpresaConyuge.Size = New System.Drawing.Size(354, 20)
        Me.Txt_EmpresaConyuge.TabIndex = 43
        Me.Txt_EmpresaConyuge.ToolTip = "Nombre"
        '
        'LabelControl45
        '
        Me.LabelControl45.Location = New System.Drawing.Point(5, 34)
        Me.LabelControl45.Name = "LabelControl45"
        Me.LabelControl45.Size = New System.Drawing.Size(41, 13)
        Me.LabelControl45.TabIndex = 13
        Me.LabelControl45.Text = "Empresa"
        '
        'Txt_ApMaternoConyuge
        '
        Me.Txt_ApMaternoConyuge.Location = New System.Drawing.Point(663, 5)
        Me.Txt_ApMaternoConyuge.Name = "Txt_ApMaternoConyuge"
        Me.Txt_ApMaternoConyuge.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ApMaternoConyuge.Properties.Appearance.Options.UseFont = True
        Me.Txt_ApMaternoConyuge.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_ApMaternoConyuge.Properties.MaxLength = 100
        Me.Txt_ApMaternoConyuge.Size = New System.Drawing.Size(195, 20)
        Me.Txt_ApMaternoConyuge.TabIndex = 42
        Me.Txt_ApMaternoConyuge.ToolTip = "Nombre"
        '
        'LabelControl51
        '
        Me.LabelControl51.Location = New System.Drawing.Point(573, 8)
        Me.LabelControl51.Name = "LabelControl51"
        Me.LabelControl51.Size = New System.Drawing.Size(80, 13)
        Me.LabelControl51.TabIndex = 10
        Me.LabelControl51.Text = "Apellido Materno"
        '
        'Txt_ApPaternoConyuge
        '
        Me.Txt_ApPaternoConyuge.Location = New System.Drawing.Point(367, 5)
        Me.Txt_ApPaternoConyuge.Name = "Txt_ApPaternoConyuge"
        Me.Txt_ApPaternoConyuge.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ApPaternoConyuge.Properties.Appearance.Options.UseFont = True
        Me.Txt_ApPaternoConyuge.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_ApPaternoConyuge.Properties.MaxLength = 100
        Me.Txt_ApPaternoConyuge.Size = New System.Drawing.Size(195, 20)
        Me.Txt_ApPaternoConyuge.TabIndex = 41
        Me.Txt_ApPaternoConyuge.ToolTip = "Nombre"
        '
        'LabelControl74
        '
        Me.LabelControl74.Location = New System.Drawing.Point(277, 8)
        Me.LabelControl74.Name = "LabelControl74"
        Me.LabelControl74.Size = New System.Drawing.Size(78, 13)
        Me.LabelControl74.TabIndex = 8
        Me.LabelControl74.Text = "Apellido Paterno"
        '
        'Txt_NombreConyuge
        '
        Me.Txt_NombreConyuge.Location = New System.Drawing.Point(94, 5)
        Me.Txt_NombreConyuge.Name = "Txt_NombreConyuge"
        Me.Txt_NombreConyuge.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_NombreConyuge.Properties.Appearance.Options.UseFont = True
        Me.Txt_NombreConyuge.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_NombreConyuge.Properties.MaxLength = 100
        Me.Txt_NombreConyuge.Size = New System.Drawing.Size(166, 20)
        Me.Txt_NombreConyuge.TabIndex = 40
        Me.Txt_NombreConyuge.ToolTip = "Nombre"
        '
        'LabelControl75
        '
        Me.LabelControl75.Location = New System.Drawing.Point(5, 8)
        Me.LabelControl75.Name = "LabelControl75"
        Me.LabelControl75.Size = New System.Drawing.Size(83, 13)
        Me.LabelControl75.TabIndex = 6
        Me.LabelControl75.Text = "Nombre Conyuge"
        '
        'TGenerales
        '
        Me.TGenerales.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TGenerales.Controls.Add(Me.PanelControl5)
        Me.TGenerales.Controls.Add(Me.PanelControl4)
        Me.TGenerales.Controls.Add(Me.PanelControl3)
        Me.TGenerales.Controls.Add(Me.PanelControl2)
        Me.TGenerales.Controls.Add(Me.PanelControl1)
        Me.TGenerales.Controls.Add(Me.Pnl_Nombre)
        Me.TGenerales.Location = New System.Drawing.Point(4, 22)
        Me.TGenerales.Name = "TGenerales"
        Me.TGenerales.Padding = New System.Windows.Forms.Padding(3)
        Me.TGenerales.Size = New System.Drawing.Size(1067, 410)
        Me.TGenerales.TabIndex = 0
        Me.TGenerales.Text = "Generales"
        Me.TGenerales.UseVisualStyleBackColor = True
        '
        'PanelControl5
        '
        Me.PanelControl5.Controls.Add(Me.Cbo_Periodicidad)
        Me.PanelControl5.Controls.Add(Me.Cbo_TipoCredito)
        Me.PanelControl5.Controls.Add(Me.LabelControl43)
        Me.PanelControl5.Controls.Add(Me.Cbo_Promocion)
        Me.PanelControl5.Controls.Add(Me.LabelControl42)
        Me.PanelControl5.Controls.Add(Me.Cbo_NegExt)
        Me.PanelControl5.Controls.Add(Me.LabelControl41)
        Me.PanelControl5.Controls.Add(Me.Cbo_ContraVale)
        Me.PanelControl5.Controls.Add(Me.Txt_LimiteVale)
        Me.PanelControl5.Controls.Add(Me.LabelControl38)
        Me.PanelControl5.Controls.Add(Me.LabelControl40)
        Me.PanelControl5.Controls.Add(Me.LabelControl39)
        Me.PanelControl5.Controls.Add(Me.Txt_Disponible)
        Me.PanelControl5.Controls.Add(Me.LabelControl35)
        Me.PanelControl5.Controls.Add(Me.Txt_Saldo)
        Me.PanelControl5.Controls.Add(Me.LabelControl36)
        Me.PanelControl5.Controls.Add(Me.Txt_LimiteCredito)
        Me.PanelControl5.Controls.Add(Me.LabelControl37)
        Me.PanelControl5.Location = New System.Drawing.Point(459, 257)
        Me.PanelControl5.Name = "PanelControl5"
        Me.PanelControl5.Size = New System.Drawing.Size(603, 148)
        Me.PanelControl5.TabIndex = 94
        '
        'Cbo_Periodicidad
        '
        Me.Cbo_Periodicidad.Enabled = False
        Me.Cbo_Periodicidad.FormattingEnabled = True
        Me.Cbo_Periodicidad.Items.AddRange(New Object() {"SEMANAL", "QUINCENAL", "MENSUAL"})
        Me.Cbo_Periodicidad.Location = New System.Drawing.Point(102, 32)
        Me.Cbo_Periodicidad.Name = "Cbo_Periodicidad"
        Me.Cbo_Periodicidad.Size = New System.Drawing.Size(119, 21)
        Me.Cbo_Periodicidad.TabIndex = 34
        Me.Cbo_Periodicidad.Text = "MENSUAL"
        '
        'Cbo_TipoCredito
        '
        Me.Cbo_TipoCredito.Enabled = False
        Me.Cbo_TipoCredito.FormattingEnabled = True
        Me.Cbo_TipoCredito.Items.AddRange(New Object() {"DISTRIBUIDOR", "TARJETAHABIENTE"})
        Me.Cbo_TipoCredito.Location = New System.Drawing.Point(102, 5)
        Me.Cbo_TipoCredito.Name = "Cbo_TipoCredito"
        Me.Cbo_TipoCredito.Size = New System.Drawing.Size(119, 21)
        Me.Cbo_TipoCredito.TabIndex = 32
        Me.Cbo_TipoCredito.Text = "TARJETAHABIENTE"
        '
        'LabelControl43
        '
        Me.LabelControl43.Location = New System.Drawing.Point(243, 83)
        Me.LabelControl43.Name = "LabelControl43"
        Me.LabelControl43.Size = New System.Drawing.Size(49, 13)
        Me.LabelControl43.TabIndex = 55
        Me.LabelControl43.Text = "Promoción"
        Me.LabelControl43.Visible = False
        '
        'Cbo_Promocion
        '
        Me.Cbo_Promocion.Location = New System.Drawing.Point(307, 80)
        Me.Cbo_Promocion.Name = "Cbo_Promocion"
        Me.Cbo_Promocion.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Cbo_Promocion.Size = New System.Drawing.Size(122, 20)
        Me.Cbo_Promocion.TabIndex = 39
        Me.Cbo_Promocion.ToolTip = "Sexo"
        Me.Cbo_Promocion.Visible = False
        '
        'LabelControl42
        '
        Me.LabelControl42.Location = New System.Drawing.Point(243, 60)
        Me.LabelControl42.Name = "LabelControl42"
        Me.LabelControl42.Size = New System.Drawing.Size(61, 13)
        Me.LabelControl42.TabIndex = 53
        Me.LabelControl42.Text = "Negocio Ext."
        Me.LabelControl42.Visible = False
        '
        'Cbo_NegExt
        '
        Me.Cbo_NegExt.Location = New System.Drawing.Point(307, 57)
        Me.Cbo_NegExt.Name = "Cbo_NegExt"
        Me.Cbo_NegExt.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Cbo_NegExt.Size = New System.Drawing.Size(122, 20)
        Me.Cbo_NegExt.TabIndex = 37
        Me.Cbo_NegExt.ToolTip = "Sexo"
        Me.Cbo_NegExt.Visible = False
        '
        'LabelControl41
        '
        Me.LabelControl41.Location = New System.Drawing.Point(243, 34)
        Me.LabelControl41.Name = "LabelControl41"
        Me.LabelControl41.Size = New System.Drawing.Size(53, 13)
        Me.LabelControl41.TabIndex = 51
        Me.LabelControl41.Text = "ContraVale"
        Me.LabelControl41.Visible = False
        '
        'Cbo_ContraVale
        '
        Me.Cbo_ContraVale.Location = New System.Drawing.Point(307, 31)
        Me.Cbo_ContraVale.Name = "Cbo_ContraVale"
        Me.Cbo_ContraVale.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Cbo_ContraVale.Size = New System.Drawing.Size(122, 20)
        Me.Cbo_ContraVale.TabIndex = 35
        Me.Cbo_ContraVale.ToolTip = "Sexo"
        Me.Cbo_ContraVale.Visible = False
        '
        'Txt_LimiteVale
        '
        Me.Txt_LimiteVale.Location = New System.Drawing.Point(307, 5)
        Me.Txt_LimiteVale.Name = "Txt_LimiteVale"
        Me.Txt_LimiteVale.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_LimiteVale.Properties.Appearance.Options.UseFont = True
        Me.Txt_LimiteVale.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_LimiteVale.Properties.MaxLength = 250
        Me.Txt_LimiteVale.Size = New System.Drawing.Size(119, 20)
        Me.Txt_LimiteVale.TabIndex = 33
        Me.Txt_LimiteVale.ToolTip = "Nombre"
        Me.Txt_LimiteVale.Visible = False
        '
        'LabelControl38
        '
        Me.LabelControl38.Location = New System.Drawing.Point(243, 5)
        Me.LabelControl38.Name = "LabelControl38"
        Me.LabelControl38.Size = New System.Drawing.Size(50, 13)
        Me.LabelControl38.TabIndex = 48
        Me.LabelControl38.Text = "Limite Vale"
        Me.LabelControl38.Visible = False
        '
        'LabelControl40
        '
        Me.LabelControl40.Location = New System.Drawing.Point(9, 34)
        Me.LabelControl40.Name = "LabelControl40"
        Me.LabelControl40.Size = New System.Drawing.Size(57, 13)
        Me.LabelControl40.TabIndex = 47
        Me.LabelControl40.Text = "Periodicidad"
        '
        'LabelControl39
        '
        Me.LabelControl39.Location = New System.Drawing.Point(9, 8)
        Me.LabelControl39.Name = "LabelControl39"
        Me.LabelControl39.Size = New System.Drawing.Size(58, 13)
        Me.LabelControl39.TabIndex = 45
        Me.LabelControl39.Text = "Tipo Crédito"
        '
        'Txt_Disponible
        '
        Me.Txt_Disponible.Enabled = False
        Me.Txt_Disponible.Location = New System.Drawing.Point(102, 105)
        Me.Txt_Disponible.Name = "Txt_Disponible"
        Me.Txt_Disponible.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Disponible.Properties.Appearance.Options.UseFont = True
        Me.Txt_Disponible.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Disponible.Properties.MaxLength = 250
        Me.Txt_Disponible.Size = New System.Drawing.Size(119, 20)
        Me.Txt_Disponible.TabIndex = 40
        Me.Txt_Disponible.ToolTip = "Nombre"
        '
        'LabelControl35
        '
        Me.LabelControl35.Location = New System.Drawing.Point(9, 108)
        Me.LabelControl35.Name = "LabelControl35"
        Me.LabelControl35.Size = New System.Drawing.Size(48, 13)
        Me.LabelControl35.TabIndex = 42
        Me.LabelControl35.Text = "Disponible"
        '
        'Txt_Saldo
        '
        Me.Txt_Saldo.Enabled = False
        Me.Txt_Saldo.Location = New System.Drawing.Point(102, 80)
        Me.Txt_Saldo.Name = "Txt_Saldo"
        Me.Txt_Saldo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Saldo.Properties.Appearance.Options.UseFont = True
        Me.Txt_Saldo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Saldo.Properties.MaxLength = 250
        Me.Txt_Saldo.Size = New System.Drawing.Size(119, 20)
        Me.Txt_Saldo.TabIndex = 38
        Me.Txt_Saldo.ToolTip = "Nombre"
        '
        'LabelControl36
        '
        Me.LabelControl36.Location = New System.Drawing.Point(9, 83)
        Me.LabelControl36.Name = "LabelControl36"
        Me.LabelControl36.Size = New System.Drawing.Size(26, 13)
        Me.LabelControl36.TabIndex = 40
        Me.LabelControl36.Text = "Saldo"
        '
        'Txt_LimiteCredito
        '
        Me.Txt_LimiteCredito.Location = New System.Drawing.Point(102, 57)
        Me.Txt_LimiteCredito.Name = "Txt_LimiteCredito"
        Me.Txt_LimiteCredito.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_LimiteCredito.Properties.Appearance.Options.UseFont = True
        Me.Txt_LimiteCredito.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_LimiteCredito.Properties.MaxLength = 250
        Me.Txt_LimiteCredito.Size = New System.Drawing.Size(119, 20)
        Me.Txt_LimiteCredito.TabIndex = 36
        Me.Txt_LimiteCredito.ToolTip = "Nombre"
        '
        'LabelControl37
        '
        Me.LabelControl37.Location = New System.Drawing.Point(9, 57)
        Me.LabelControl37.Name = "LabelControl37"
        Me.LabelControl37.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl37.TabIndex = 38
        Me.LabelControl37.Text = "Limite Crédito"
        '
        'PanelControl4
        '
        Me.PanelControl4.Controls.Add(Me.Txt_IngresoTotal)
        Me.PanelControl4.Controls.Add(Me.LabelControl34)
        Me.PanelControl4.Controls.Add(Me.Txt_OtrosIngresos)
        Me.PanelControl4.Controls.Add(Me.LabelControl33)
        Me.PanelControl4.Controls.Add(Me.Txt_IngresoMensual)
        Me.PanelControl4.Controls.Add(Me.LabelControl32)
        Me.PanelControl4.Controls.Add(Me.Txt_AntiguedadEmpresa)
        Me.PanelControl4.Controls.Add(Me.LabelControl31)
        Me.PanelControl4.Controls.Add(Me.Txt_Puesto)
        Me.PanelControl4.Controls.Add(Me.LabelControl30)
        Me.PanelControl4.Controls.Add(Me.Txt_DireccionEmpresa)
        Me.PanelControl4.Controls.Add(Me.LabelControl29)
        Me.PanelControl4.Controls.Add(Me.Txt_Empresa)
        Me.PanelControl4.Controls.Add(Me.LabelControl28)
        Me.PanelControl4.Location = New System.Drawing.Point(1, 257)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(452, 148)
        Me.PanelControl4.TabIndex = 93
        '
        'Txt_IngresoTotal
        '
        Me.Txt_IngresoTotal.Location = New System.Drawing.Point(318, 83)
        Me.Txt_IngresoTotal.Name = "Txt_IngresoTotal"
        Me.Txt_IngresoTotal.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IngresoTotal.Properties.Appearance.Options.UseFont = True
        Me.Txt_IngresoTotal.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_IngresoTotal.Properties.MaxLength = 250
        Me.Txt_IngresoTotal.Size = New System.Drawing.Size(101, 20)
        Me.Txt_IngresoTotal.TabIndex = 31
        Me.Txt_IngresoTotal.ToolTip = "Nombre"
        '
        'LabelControl34
        '
        Me.LabelControl34.Location = New System.Drawing.Point(221, 86)
        Me.LabelControl34.Name = "LabelControl34"
        Me.LabelControl34.Size = New System.Drawing.Size(64, 13)
        Me.LabelControl34.TabIndex = 42
        Me.LabelControl34.Text = "Ingreso Total"
        '
        'Txt_OtrosIngresos
        '
        Me.Txt_OtrosIngresos.Location = New System.Drawing.Point(102, 109)
        Me.Txt_OtrosIngresos.Name = "Txt_OtrosIngresos"
        Me.Txt_OtrosIngresos.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_OtrosIngresos.Properties.Appearance.Options.UseFont = True
        Me.Txt_OtrosIngresos.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_OtrosIngresos.Properties.MaxLength = 250
        Me.Txt_OtrosIngresos.Size = New System.Drawing.Size(101, 20)
        Me.Txt_OtrosIngresos.TabIndex = 30
        Me.Txt_OtrosIngresos.ToolTip = "Nombre"
        '
        'LabelControl33
        '
        Me.LabelControl33.Location = New System.Drawing.Point(5, 112)
        Me.LabelControl33.Name = "LabelControl33"
        Me.LabelControl33.Size = New System.Drawing.Size(72, 13)
        Me.LabelControl33.TabIndex = 40
        Me.LabelControl33.Text = "Otros Ingresos"
        '
        'Txt_IngresoMensual
        '
        Me.Txt_IngresoMensual.Location = New System.Drawing.Point(102, 83)
        Me.Txt_IngresoMensual.Name = "Txt_IngresoMensual"
        Me.Txt_IngresoMensual.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IngresoMensual.Properties.Appearance.Options.UseFont = True
        Me.Txt_IngresoMensual.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_IngresoMensual.Properties.MaxLength = 250
        Me.Txt_IngresoMensual.Size = New System.Drawing.Size(101, 20)
        Me.Txt_IngresoMensual.TabIndex = 29
        Me.Txt_IngresoMensual.ToolTip = "Nombre"
        '
        'LabelControl32
        '
        Me.LabelControl32.Location = New System.Drawing.Point(5, 86)
        Me.LabelControl32.Name = "LabelControl32"
        Me.LabelControl32.Size = New System.Drawing.Size(79, 13)
        Me.LabelControl32.TabIndex = 38
        Me.LabelControl32.Text = "Ingreso Mensual"
        '
        'Txt_AntiguedadEmpresa
        '
        Me.Txt_AntiguedadEmpresa.Location = New System.Drawing.Point(365, 57)
        Me.Txt_AntiguedadEmpresa.Name = "Txt_AntiguedadEmpresa"
        Me.Txt_AntiguedadEmpresa.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_AntiguedadEmpresa.Properties.Appearance.Options.UseFont = True
        Me.Txt_AntiguedadEmpresa.Properties.MaxLength = 3
        Me.Txt_AntiguedadEmpresa.Size = New System.Drawing.Size(54, 20)
        Me.Txt_AntiguedadEmpresa.TabIndex = 28
        Me.Txt_AntiguedadEmpresa.ToolTip = "Nombre"
        '
        'LabelControl31
        '
        Me.LabelControl31.Location = New System.Drawing.Point(304, 60)
        Me.LabelControl31.Name = "LabelControl31"
        Me.LabelControl31.Size = New System.Drawing.Size(55, 13)
        Me.LabelControl31.TabIndex = 35
        Me.LabelControl31.Text = "Antigüedad"
        '
        'Txt_Puesto
        '
        Me.Txt_Puesto.Location = New System.Drawing.Point(65, 57)
        Me.Txt_Puesto.Name = "Txt_Puesto"
        Me.Txt_Puesto.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Puesto.Properties.Appearance.Options.UseFont = True
        Me.Txt_Puesto.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Puesto.Properties.MaxLength = 50
        Me.Txt_Puesto.Size = New System.Drawing.Size(218, 20)
        Me.Txt_Puesto.TabIndex = 27
        Me.Txt_Puesto.ToolTip = "Nombre"
        '
        'LabelControl30
        '
        Me.LabelControl30.Location = New System.Drawing.Point(5, 57)
        Me.LabelControl30.Name = "LabelControl30"
        Me.LabelControl30.Size = New System.Drawing.Size(33, 13)
        Me.LabelControl30.TabIndex = 11
        Me.LabelControl30.Text = "Puesto"
        '
        'Txt_DireccionEmpresa
        '
        Me.Txt_DireccionEmpresa.Location = New System.Drawing.Point(65, 31)
        Me.Txt_DireccionEmpresa.Name = "Txt_DireccionEmpresa"
        Me.Txt_DireccionEmpresa.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DireccionEmpresa.Properties.Appearance.Options.UseFont = True
        Me.Txt_DireccionEmpresa.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_DireccionEmpresa.Properties.MaxLength = 250
        Me.Txt_DireccionEmpresa.Size = New System.Drawing.Size(354, 20)
        Me.Txt_DireccionEmpresa.TabIndex = 26
        Me.Txt_DireccionEmpresa.ToolTip = "Nombre"
        '
        'LabelControl29
        '
        Me.LabelControl29.Location = New System.Drawing.Point(5, 31)
        Me.LabelControl29.Name = "LabelControl29"
        Me.LabelControl29.Size = New System.Drawing.Size(40, 13)
        Me.LabelControl29.TabIndex = 9
        Me.LabelControl29.Text = "Domicilio"
        '
        'Txt_Empresa
        '
        Me.Txt_Empresa.Location = New System.Drawing.Point(65, 5)
        Me.Txt_Empresa.Name = "Txt_Empresa"
        Me.Txt_Empresa.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Empresa.Properties.Appearance.Options.UseFont = True
        Me.Txt_Empresa.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Empresa.Properties.MaxLength = 150
        Me.Txt_Empresa.Size = New System.Drawing.Size(354, 20)
        Me.Txt_Empresa.TabIndex = 25
        Me.Txt_Empresa.ToolTip = "Nombre"
        '
        'LabelControl28
        '
        Me.LabelControl28.Location = New System.Drawing.Point(5, 5)
        Me.LabelControl28.Name = "LabelControl28"
        Me.LabelControl28.Size = New System.Drawing.Size(41, 13)
        Me.LabelControl28.TabIndex = 7
        Me.LabelControl28.Text = "Empresa"
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.Txt_Email)
        Me.PanelControl3.Controls.Add(Me.LabelControl27)
        Me.PanelControl3.Controls.Add(Me.Txt_Celular2)
        Me.PanelControl3.Controls.Add(Me.LabelControl26)
        Me.PanelControl3.Controls.Add(Me.Txt_Celular1)
        Me.PanelControl3.Controls.Add(Me.LabelControl25)
        Me.PanelControl3.Controls.Add(Me.Txt_TelOtro)
        Me.PanelControl3.Controls.Add(Me.LabelControl24)
        Me.PanelControl3.Controls.Add(Me.Txt_TelCasa)
        Me.PanelControl3.Controls.Add(Me.LabelControl23)
        Me.PanelControl3.Location = New System.Drawing.Point(645, 107)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(417, 144)
        Me.PanelControl3.TabIndex = 92
        '
        'Txt_Email
        '
        Me.Txt_Email.Location = New System.Drawing.Point(94, 109)
        Me.Txt_Email.Name = "Txt_Email"
        Me.Txt_Email.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Email.Properties.Appearance.Options.UseFont = True
        Me.Txt_Email.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Email.Properties.MaxLength = 150
        Me.Txt_Email.Size = New System.Drawing.Size(195, 20)
        Me.Txt_Email.TabIndex = 24
        Me.Txt_Email.ToolTip = "Nombre"
        '
        'LabelControl27
        '
        Me.LabelControl27.Location = New System.Drawing.Point(19, 112)
        Me.LabelControl27.Name = "LabelControl27"
        Me.LabelControl27.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl27.TabIndex = 15
        Me.LabelControl27.Text = "Email"
        '
        'Txt_Celular2
        '
        Me.Txt_Celular2.Location = New System.Drawing.Point(94, 83)
        Me.Txt_Celular2.Name = "Txt_Celular2"
        Me.Txt_Celular2.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Celular2.Properties.Appearance.Options.UseFont = True
        Me.Txt_Celular2.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Celular2.Properties.MaxLength = 10
        Me.Txt_Celular2.Size = New System.Drawing.Size(120, 20)
        Me.Txt_Celular2.TabIndex = 23
        Me.Txt_Celular2.ToolTip = "Nombre"
        '
        'LabelControl26
        '
        Me.LabelControl26.Location = New System.Drawing.Point(19, 86)
        Me.LabelControl26.Name = "LabelControl26"
        Me.LabelControl26.Size = New System.Drawing.Size(42, 13)
        Me.LabelControl26.TabIndex = 13
        Me.LabelControl26.Text = "Celular 2"
        '
        'Txt_Celular1
        '
        Me.Txt_Celular1.Location = New System.Drawing.Point(94, 57)
        Me.Txt_Celular1.Name = "Txt_Celular1"
        Me.Txt_Celular1.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Celular1.Properties.Appearance.Options.UseFont = True
        Me.Txt_Celular1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Celular1.Properties.MaxLength = 10
        Me.Txt_Celular1.Size = New System.Drawing.Size(120, 20)
        Me.Txt_Celular1.TabIndex = 22
        Me.Txt_Celular1.ToolTip = "Celular1"
        '
        'LabelControl25
        '
        Me.LabelControl25.Location = New System.Drawing.Point(19, 60)
        Me.LabelControl25.Name = "LabelControl25"
        Me.LabelControl25.Size = New System.Drawing.Size(42, 13)
        Me.LabelControl25.TabIndex = 11
        Me.LabelControl25.Text = "Celular 1"
        '
        'Txt_TelOtro
        '
        Me.Txt_TelOtro.Location = New System.Drawing.Point(94, 31)
        Me.Txt_TelOtro.Name = "Txt_TelOtro"
        Me.Txt_TelOtro.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_TelOtro.Properties.Appearance.Options.UseFont = True
        Me.Txt_TelOtro.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_TelOtro.Properties.MaxLength = 10
        Me.Txt_TelOtro.Size = New System.Drawing.Size(120, 20)
        Me.Txt_TelOtro.TabIndex = 21
        Me.Txt_TelOtro.ToolTip = "Nombre"
        '
        'LabelControl24
        '
        Me.LabelControl24.Location = New System.Drawing.Point(19, 34)
        Me.LabelControl24.Name = "LabelControl24"
        Me.LabelControl24.Size = New System.Drawing.Size(67, 13)
        Me.LabelControl24.TabIndex = 9
        Me.LabelControl24.Text = "Teléfono Otro"
        '
        'Txt_TelCasa
        '
        Me.Txt_TelCasa.Location = New System.Drawing.Point(94, 5)
        Me.Txt_TelCasa.Name = "Txt_TelCasa"
        Me.Txt_TelCasa.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_TelCasa.Properties.Appearance.Options.UseFont = True
        Me.Txt_TelCasa.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_TelCasa.Properties.MaxLength = 10
        Me.Txt_TelCasa.Size = New System.Drawing.Size(120, 20)
        Me.Txt_TelCasa.TabIndex = 20
        Me.Txt_TelCasa.ToolTip = "Nombre"
        '
        'LabelControl23
        '
        Me.LabelControl23.Location = New System.Drawing.Point(19, 8)
        Me.LabelControl23.Name = "LabelControl23"
        Me.LabelControl23.Size = New System.Drawing.Size(69, 13)
        Me.LabelControl23.TabIndex = 7
        Me.LabelControl23.Text = "Teléfono Casa"
        '
        'PanelControl2
        '
        Me.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D
        Me.PanelControl2.Controls.Add(Me.Cbo_TipoVivienda)
        Me.PanelControl2.Controls.Add(Me.Cbo_Estado)
        Me.PanelControl2.Controls.Add(Me.Cbo_Ciudad)
        Me.PanelControl2.Controls.Add(Me.Cbo_Colonia)
        Me.PanelControl2.Controls.Add(Me.Cbo_CodigoPostal)
        Me.PanelControl2.Controls.Add(Me.Txt_ValorAutos)
        Me.PanelControl2.Controls.Add(Me.Lbl_ValorEstimadoAutos)
        Me.PanelControl2.Controls.Add(Me.Txt_ValorCasa)
        Me.PanelControl2.Controls.Add(Me.Lbl_ValorEstimadoCasa)
        Me.PanelControl2.Controls.Add(Me.Btn_Google)
        Me.PanelControl2.Controls.Add(Me.Txt_AntiguedadVivienda)
        Me.PanelControl2.Controls.Add(Me.LabelControl20)
        Me.PanelControl2.Controls.Add(Me.LabelControl19)
        Me.PanelControl2.Controls.Add(Me.Txt_EntreCalles)
        Me.PanelControl2.Controls.Add(Me.LabelControl17)
        Me.PanelControl2.Controls.Add(Me.LabelControl16)
        Me.PanelControl2.Controls.Add(Me.LabelControl15)
        Me.PanelControl2.Controls.Add(Me.LabelControl14)
        Me.PanelControl2.Controls.Add(Me.LabelControl13)
        Me.PanelControl2.Controls.Add(Me.Txt_Numero)
        Me.PanelControl2.Controls.Add(Me.LabelControl12)
        Me.PanelControl2.Controls.Add(Me.Txt_Calle)
        Me.PanelControl2.Controls.Add(Me.LabelControl18)
        Me.PanelControl2.Location = New System.Drawing.Point(1, 107)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(638, 144)
        Me.PanelControl2.TabIndex = 6
        '
        'Cbo_TipoVivienda
        '
        Me.Cbo_TipoVivienda.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Cbo_TipoVivienda.FormattingEnabled = True
        Me.Cbo_TipoVivienda.Items.AddRange(New Object() {"CASA", "DEPARTAMENTO"})
        Me.Cbo_TipoVivienda.Location = New System.Drawing.Point(65, 83)
        Me.Cbo_TipoVivienda.Name = "Cbo_TipoVivienda"
        Me.Cbo_TipoVivienda.Size = New System.Drawing.Size(148, 21)
        Me.Cbo_TipoVivienda.TabIndex = 16
        '
        'Cbo_Estado
        '
        Me.Cbo_Estado.FormattingEnabled = True
        Me.Cbo_Estado.Location = New System.Drawing.Point(478, 30)
        Me.Cbo_Estado.Name = "Cbo_Estado"
        Me.Cbo_Estado.Size = New System.Drawing.Size(148, 21)
        Me.Cbo_Estado.TabIndex = 14
        '
        'Cbo_Ciudad
        '
        Me.Cbo_Ciudad.FormattingEnabled = True
        Me.Cbo_Ciudad.Location = New System.Drawing.Point(271, 31)
        Me.Cbo_Ciudad.Name = "Cbo_Ciudad"
        Me.Cbo_Ciudad.Size = New System.Drawing.Size(148, 21)
        Me.Cbo_Ciudad.TabIndex = 13
        '
        'Cbo_Colonia
        '
        Me.Cbo_Colonia.FormattingEnabled = True
        Me.Cbo_Colonia.Location = New System.Drawing.Point(65, 30)
        Me.Cbo_Colonia.Name = "Cbo_Colonia"
        Me.Cbo_Colonia.Size = New System.Drawing.Size(148, 21)
        Me.Cbo_Colonia.TabIndex = 12
        '
        'Cbo_CodigoPostal
        '
        Me.Cbo_CodigoPostal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbo_CodigoPostal.FormattingEnabled = True
        Me.Cbo_CodigoPostal.Location = New System.Drawing.Point(505, 5)
        Me.Cbo_CodigoPostal.Name = "Cbo_CodigoPostal"
        Me.Cbo_CodigoPostal.Size = New System.Drawing.Size(121, 21)
        Me.Cbo_CodigoPostal.TabIndex = 11
        '
        'Txt_ValorAutos
        '
        Me.Txt_ValorAutos.Location = New System.Drawing.Point(338, 109)
        Me.Txt_ValorAutos.Name = "Txt_ValorAutos"
        Me.Txt_ValorAutos.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ValorAutos.Properties.Appearance.Options.UseFont = True
        Me.Txt_ValorAutos.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_ValorAutos.Properties.MaxLength = 250
        Me.Txt_ValorAutos.Size = New System.Drawing.Size(101, 20)
        Me.Txt_ValorAutos.TabIndex = 19
        Me.Txt_ValorAutos.ToolTip = "Nombre"
        Me.Txt_ValorAutos.Visible = False
        '
        'Lbl_ValorEstimadoAutos
        '
        Me.Lbl_ValorEstimadoAutos.Location = New System.Drawing.Point(231, 112)
        Me.Lbl_ValorEstimadoAutos.Name = "Lbl_ValorEstimadoAutos"
        Me.Lbl_ValorEstimadoAutos.Size = New System.Drawing.Size(101, 13)
        Me.Lbl_ValorEstimadoAutos.TabIndex = 38
        Me.Lbl_ValorEstimadoAutos.Text = "Valor Estimado Autos"
        Me.Lbl_ValorEstimadoAutos.Visible = False
        '
        'Txt_ValorCasa
        '
        Me.Txt_ValorCasa.Location = New System.Drawing.Point(112, 109)
        Me.Txt_ValorCasa.Name = "Txt_ValorCasa"
        Me.Txt_ValorCasa.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ValorCasa.Properties.Appearance.Options.UseFont = True
        Me.Txt_ValorCasa.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_ValorCasa.Properties.MaxLength = 250
        Me.Txt_ValorCasa.Size = New System.Drawing.Size(101, 20)
        Me.Txt_ValorCasa.TabIndex = 18
        Me.Txt_ValorCasa.ToolTip = "Nombre"
        Me.Txt_ValorCasa.Visible = False
        '
        'Lbl_ValorEstimadoCasa
        '
        Me.Lbl_ValorEstimadoCasa.Location = New System.Drawing.Point(5, 112)
        Me.Lbl_ValorEstimadoCasa.Name = "Lbl_ValorEstimadoCasa"
        Me.Lbl_ValorEstimadoCasa.Size = New System.Drawing.Size(97, 13)
        Me.Lbl_ValorEstimadoCasa.TabIndex = 36
        Me.Lbl_ValorEstimadoCasa.Text = "Valor Estimado Casa"
        Me.Lbl_ValorEstimadoCasa.Visible = False
        '
        'Btn_Google
        '
        Me.Btn_Google.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.icono
        Me.Btn_Google.Location = New System.Drawing.Point(554, 62)
        Me.Btn_Google.Name = "Btn_Google"
        Me.Btn_Google.Size = New System.Drawing.Size(67, 52)
        Me.Btn_Google.TabIndex = 22
        '
        'Txt_AntiguedadVivienda
        '
        Me.Txt_AntiguedadVivienda.Location = New System.Drawing.Point(289, 83)
        Me.Txt_AntiguedadVivienda.Name = "Txt_AntiguedadVivienda"
        Me.Txt_AntiguedadVivienda.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_AntiguedadVivienda.Properties.Appearance.Options.UseFont = True
        Me.Txt_AntiguedadVivienda.Properties.MaxLength = 3
        Me.Txt_AntiguedadVivienda.Size = New System.Drawing.Size(54, 20)
        Me.Txt_AntiguedadVivienda.TabIndex = 17
        Me.Txt_AntiguedadVivienda.ToolTip = "Nombre"
        '
        'LabelControl20
        '
        Me.LabelControl20.Location = New System.Drawing.Point(228, 86)
        Me.LabelControl20.Name = "LabelControl20"
        Me.LabelControl20.Size = New System.Drawing.Size(55, 13)
        Me.LabelControl20.TabIndex = 33
        Me.LabelControl20.Text = "Antigüedad"
        '
        'LabelControl19
        '
        Me.LabelControl19.Location = New System.Drawing.Point(5, 86)
        Me.LabelControl19.Name = "LabelControl19"
        Me.LabelControl19.Size = New System.Drawing.Size(40, 13)
        Me.LabelControl19.TabIndex = 31
        Me.LabelControl19.Text = "Vivienda"
        '
        'Txt_EntreCalles
        '
        Me.Txt_EntreCalles.EnterMoveNextControl = True
        Me.Txt_EntreCalles.Location = New System.Drawing.Point(65, 57)
        Me.Txt_EntreCalles.Name = "Txt_EntreCalles"
        Me.Txt_EntreCalles.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_EntreCalles.Properties.Appearance.Options.UseFont = True
        Me.Txt_EntreCalles.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_EntreCalles.Properties.MaxLength = 250
        Me.Txt_EntreCalles.Size = New System.Drawing.Size(412, 20)
        Me.Txt_EntreCalles.TabIndex = 15
        Me.Txt_EntreCalles.ToolTip = "Nombre"
        '
        'LabelControl17
        '
        Me.LabelControl17.Location = New System.Drawing.Point(5, 62)
        Me.LabelControl17.Name = "LabelControl17"
        Me.LabelControl17.Size = New System.Drawing.Size(57, 13)
        Me.LabelControl17.TabIndex = 29
        Me.LabelControl17.Text = "Entre Calles"
        '
        'LabelControl16
        '
        Me.LabelControl16.Location = New System.Drawing.Point(434, 34)
        Me.LabelControl16.Name = "LabelControl16"
        Me.LabelControl16.Size = New System.Drawing.Size(33, 13)
        Me.LabelControl16.TabIndex = 28
        Me.LabelControl16.Text = "Estado"
        '
        'LabelControl15
        '
        Me.LabelControl15.Location = New System.Drawing.Point(225, 34)
        Me.LabelControl15.Name = "LabelControl15"
        Me.LabelControl15.Size = New System.Drawing.Size(33, 13)
        Me.LabelControl15.TabIndex = 25
        Me.LabelControl15.Text = "Ciudad"
        '
        'LabelControl14
        '
        Me.LabelControl14.Location = New System.Drawing.Point(5, 34)
        Me.LabelControl14.Name = "LabelControl14"
        Me.LabelControl14.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl14.TabIndex = 24
        Me.LabelControl14.Text = "Colonia"
        '
        'LabelControl13
        '
        Me.LabelControl13.Location = New System.Drawing.Point(434, 8)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl13.TabIndex = 22
        Me.LabelControl13.Text = "Código Postal"
        '
        'Txt_Numero
        '
        Me.Txt_Numero.Location = New System.Drawing.Point(365, 5)
        Me.Txt_Numero.Name = "Txt_Numero"
        Me.Txt_Numero.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Numero.Properties.Appearance.Options.UseFont = True
        Me.Txt_Numero.Properties.MaxLength = 4
        Me.Txt_Numero.Size = New System.Drawing.Size(54, 20)
        Me.Txt_Numero.TabIndex = 10
        Me.Txt_Numero.ToolTip = "Nombre"
        '
        'LabelControl12
        '
        Me.LabelControl12.Location = New System.Drawing.Point(322, 8)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl12.TabIndex = 16
        Me.LabelControl12.Text = "Número"
        '
        'Txt_Calle
        '
        Me.Txt_Calle.Location = New System.Drawing.Point(65, 5)
        Me.Txt_Calle.Name = "Txt_Calle"
        Me.Txt_Calle.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Calle.Properties.Appearance.Options.UseFont = True
        Me.Txt_Calle.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Calle.Properties.MaxLength = 250
        Me.Txt_Calle.Size = New System.Drawing.Size(251, 20)
        Me.Txt_Calle.TabIndex = 9
        Me.Txt_Calle.ToolTip = "Nombre"
        '
        'LabelControl18
        '
        Me.LabelControl18.Location = New System.Drawing.Point(5, 8)
        Me.LabelControl18.Name = "LabelControl18"
        Me.LabelControl18.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl18.TabIndex = 6
        Me.LabelControl18.Text = "Calle"
        '
        'PanelControl1
        '
        Me.PanelControl1.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PanelControl1.Appearance.Options.UseBackColor = True
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D
        Me.PanelControl1.Controls.Add(Me.Cbo_Sexo)
        Me.PanelControl1.Controls.Add(Me.Cbo_EstadoCivil)
        Me.PanelControl1.Controls.Add(Me.Txt_Dependientes)
        Me.PanelControl1.Controls.Add(Me.LabelControl11)
        Me.PanelControl1.Controls.Add(Me.LabelControl10)
        Me.PanelControl1.Controls.Add(Me.LabelControl9)
        Me.PanelControl1.Controls.Add(Me.Dt_FechaNacim)
        Me.PanelControl1.Controls.Add(Me.LabelControl7)
        Me.PanelControl1.Controls.Add(Me.Txt_Apmaterno)
        Me.PanelControl1.Controls.Add(Me.LabelControl6)
        Me.PanelControl1.Controls.Add(Me.Txt_Appaterno)
        Me.PanelControl1.Controls.Add(Me.LabelControl5)
        Me.PanelControl1.Controls.Add(Me.Txt_Nombre)
        Me.PanelControl1.Controls.Add(Me.LabelControl8)
        Me.PanelControl1.Location = New System.Drawing.Point(1, 29)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1061, 72)
        Me.PanelControl1.TabIndex = 5
        '
        'Cbo_Sexo
        '
        Me.Cbo_Sexo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbo_Sexo.FormattingEnabled = True
        Me.Cbo_Sexo.Items.AddRange(New Object() {"FEMENINO", "MASCULINO"})
        Me.Cbo_Sexo.Location = New System.Drawing.Point(910, 4)
        Me.Cbo_Sexo.Name = "Cbo_Sexo"
        Me.Cbo_Sexo.Size = New System.Drawing.Size(121, 21)
        Me.Cbo_Sexo.TabIndex = 5
        '
        'Cbo_EstadoCivil
        '
        Me.Cbo_EstadoCivil.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Cbo_EstadoCivil.FormattingEnabled = True
        Me.Cbo_EstadoCivil.Items.AddRange(New Object() {"CASADO", "SOLTERO", "VIUDO", "UNION LIBRE"})
        Me.Cbo_EstadoCivil.Location = New System.Drawing.Point(367, 30)
        Me.Cbo_EstadoCivil.Name = "Cbo_EstadoCivil"
        Me.Cbo_EstadoCivil.Size = New System.Drawing.Size(121, 21)
        Me.Cbo_EstadoCivil.TabIndex = 7
        '
        'Txt_Dependientes
        '
        Me.Txt_Dependientes.Location = New System.Drawing.Point(599, 31)
        Me.Txt_Dependientes.Name = "Txt_Dependientes"
        Me.Txt_Dependientes.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Dependientes.Properties.Appearance.Options.UseFont = True
        Me.Txt_Dependientes.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.Txt_Dependientes.Properties.MaxLength = 3
        Me.Txt_Dependientes.Size = New System.Drawing.Size(54, 20)
        Me.Txt_Dependientes.TabIndex = 8
        Me.Txt_Dependientes.ToolTip = "Nombre"
        '
        'LabelControl11
        '
        Me.LabelControl11.Location = New System.Drawing.Point(527, 34)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(66, 13)
        Me.LabelControl11.TabIndex = 18
        Me.LabelControl11.Text = "Dependientes"
        '
        'LabelControl10
        '
        Me.LabelControl10.Location = New System.Drawing.Point(277, 34)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(55, 13)
        Me.LabelControl10.TabIndex = 17
        Me.LabelControl10.Text = "Estado Civil"
        '
        'LabelControl9
        '
        Me.LabelControl9.Location = New System.Drawing.Point(5, 34)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(52, 13)
        Me.LabelControl9.TabIndex = 15
        Me.LabelControl9.Text = "Nacimiento"
        '
        'Dt_FechaNacim
        '
        Me.Dt_FechaNacim.EditValue = New Date(2021, 11, 29, 0, 0, 0, 0)
        Me.Dt_FechaNacim.EnterMoveNextControl = True
        Me.Dt_FechaNacim.Location = New System.Drawing.Point(65, 31)
        Me.Dt_FechaNacim.Name = "Dt_FechaNacim"
        Me.Dt_FechaNacim.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Dt_FechaNacim.Properties.Appearance.Options.UseFont = True
        Me.Dt_FechaNacim.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.Dt_FechaNacim.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Dt_FechaNacim.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Dt_FechaNacim.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "d"
        Me.Dt_FechaNacim.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.Dt_FechaNacim.Size = New System.Drawing.Size(148, 20)
        Me.Dt_FechaNacim.TabIndex = 6
        Me.Dt_FechaNacim.ToolTip = "Fecha de Nacimiento"
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(880, 8)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl7.TabIndex = 13
        Me.LabelControl7.Text = "Sexo"
        '
        'Txt_Apmaterno
        '
        Me.Txt_Apmaterno.Location = New System.Drawing.Point(663, 5)
        Me.Txt_Apmaterno.Name = "Txt_Apmaterno"
        Me.Txt_Apmaterno.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Apmaterno.Properties.Appearance.Options.UseFont = True
        Me.Txt_Apmaterno.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Apmaterno.Properties.MaxLength = 100
        Me.Txt_Apmaterno.Size = New System.Drawing.Size(195, 20)
        Me.Txt_Apmaterno.TabIndex = 4
        Me.Txt_Apmaterno.ToolTip = "Nombre"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(573, 8)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(80, 13)
        Me.LabelControl6.TabIndex = 10
        Me.LabelControl6.Text = "Apellido Materno"
        '
        'Txt_Appaterno
        '
        Me.Txt_Appaterno.Location = New System.Drawing.Point(367, 5)
        Me.Txt_Appaterno.Name = "Txt_Appaterno"
        Me.Txt_Appaterno.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Appaterno.Properties.Appearance.Options.UseFont = True
        Me.Txt_Appaterno.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Appaterno.Properties.MaxLength = 100
        Me.Txt_Appaterno.Size = New System.Drawing.Size(195, 20)
        Me.Txt_Appaterno.TabIndex = 3
        Me.Txt_Appaterno.ToolTip = "Nombre"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(277, 8)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(78, 13)
        Me.LabelControl5.TabIndex = 8
        Me.LabelControl5.Text = "Apellido Paterno"
        '
        'Txt_Nombre
        '
        Me.Txt_Nombre.Location = New System.Drawing.Point(65, 5)
        Me.Txt_Nombre.Name = "Txt_Nombre"
        Me.Txt_Nombre.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Nombre.Properties.Appearance.Options.UseFont = True
        Me.Txt_Nombre.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Nombre.Properties.MaxLength = 100
        Me.Txt_Nombre.Size = New System.Drawing.Size(195, 20)
        Me.Txt_Nombre.TabIndex = 2
        Me.Txt_Nombre.ToolTip = "Nombre"
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(5, 8)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl8.TabIndex = 6
        Me.LabelControl8.Text = "Nombre"
        '
        'Pnl_Nombre
        '
        Me.Pnl_Nombre.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D
        Me.Pnl_Nombre.Controls.Add(Me.LabelControl3)
        Me.Pnl_Nombre.Controls.Add(Me.Txt_NombreCompleto)
        Me.Pnl_Nombre.Controls.Add(Me.LabelControl2)
        Me.Pnl_Nombre.Controls.Add(Me.Txt_TarjetaHabiente)
        Me.Pnl_Nombre.Controls.Add(Me.Txt_IdDistrib)
        Me.Pnl_Nombre.Controls.Add(Me.LabelControl1)
        Me.Pnl_Nombre.Location = New System.Drawing.Point(1, -2)
        Me.Pnl_Nombre.Name = "Pnl_Nombre"
        Me.Pnl_Nombre.Size = New System.Drawing.Size(1061, 33)
        Me.Pnl_Nombre.TabIndex = 4
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(451, 8)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(85, 13)
        Me.LabelControl3.TabIndex = 10
        Me.LabelControl3.Text = "Nombre Completo"
        '
        'Txt_NombreCompleto
        '
        Me.Txt_NombreCompleto.Enabled = False
        Me.Txt_NombreCompleto.Location = New System.Drawing.Point(560, 5)
        Me.Txt_NombreCompleto.Name = "Txt_NombreCompleto"
        Me.Txt_NombreCompleto.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_NombreCompleto.Properties.Appearance.Options.UseFont = True
        Me.Txt_NombreCompleto.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_NombreCompleto.Properties.MaxLength = 100
        Me.Txt_NombreCompleto.Size = New System.Drawing.Size(298, 20)
        Me.Txt_NombreCompleto.TabIndex = 9
        Me.Txt_NombreCompleto.ToolTip = "Nombre"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(185, 8)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl2.TabIndex = 8
        Me.LabelControl2.Text = "Tarjeta"
        '
        'Txt_TarjetaHabiente
        '
        Me.Txt_TarjetaHabiente.EditValue = ""
        Me.Txt_TarjetaHabiente.Location = New System.Drawing.Point(231, 3)
        Me.Txt_TarjetaHabiente.Name = "Txt_TarjetaHabiente"
        Me.Txt_TarjetaHabiente.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_TarjetaHabiente.Properties.Appearance.Options.UseFont = True
        Me.Txt_TarjetaHabiente.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Txt_TarjetaHabiente.Size = New System.Drawing.Size(166, 26)
        Me.Txt_TarjetaHabiente.TabIndex = 1
        '
        'Txt_IdDistrib
        '
        Me.Txt_IdDistrib.Location = New System.Drawing.Point(65, 5)
        Me.Txt_IdDistrib.Name = "Txt_IdDistrib"
        Me.Txt_IdDistrib.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdDistrib.Properties.Appearance.Options.UseFont = True
        Me.Txt_IdDistrib.Size = New System.Drawing.Size(100, 20)
        Me.Txt_IdDistrib.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(5, 8)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(55, 13)
        Me.LabelControl1.TabIndex = 6
        Me.LabelControl1.Text = "No. Cuenta"
        '
        'TabDistribR
        '
        Me.TabDistribR.Controls.Add(Me.TGenerales)
        Me.TabDistribR.Controls.Add(Me.TReferencias)
        Me.TabDistribR.Controls.Add(Me.TComerciales)
        Me.TabDistribR.Controls.Add(Me.TFirmasDocumentos)
        Me.TabDistribR.Location = New System.Drawing.Point(8, 8)
        Me.TabDistribR.Name = "TabDistribR"
        Me.TabDistribR.SelectedIndex = 0
        Me.TabDistribR.Size = New System.Drawing.Size(1075, 436)
        Me.TabDistribR.TabIndex = 93
        '
        'TComerciales
        '
        Me.TComerciales.Controls.Add(Me.GridReferencias)
        Me.TComerciales.Location = New System.Drawing.Point(4, 22)
        Me.TComerciales.Name = "TComerciales"
        Me.TComerciales.Size = New System.Drawing.Size(1067, 410)
        Me.TComerciales.TabIndex = 4
        Me.TComerciales.Text = "Referencias comerciales"
        Me.TComerciales.UseVisualStyleBackColor = True
        '
        'GridReferencias
        '
        Me.GridReferencias.DataSource = Me.UspTraerDistribComercialesBindingSource
        Me.GridReferencias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridReferencias.Location = New System.Drawing.Point(0, 0)
        Me.GridReferencias.MainView = Me.GridView3
        Me.GridReferencias.Name = "GridReferencias"
        Me.GridReferencias.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemPictureEdit2})
        Me.GridReferencias.Size = New System.Drawing.Size(1067, 410)
        Me.GridReferencias.TabIndex = 11
        Me.GridReferencias.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3, Me.GridView2})
        '
        'UspTraerDistribComercialesBindingSource
        '
        Me.UspTraerDistribComercialesBindingSource.DataMember = "usp_TraerDistribComerciales"
        Me.UspTraerDistribComercialesBindingSource.DataSource = Me.Usp_TraerDistribComerciales
        '
        'Usp_TraerDistribComerciales
        '
        Me.Usp_TraerDistribComerciales.DataSetName = "usp_TraerDistribComerciales"
        Me.Usp_TraerDistribComerciales.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridView3
        '
        Me.GridView3.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridView3.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridView3.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GridView3.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colmarca, Me.colnegocio, Me.colTarjeta, Me.colLimite, Me.coledocuenta, Me.coledocuenta1})
        Me.GridView3.GridControl = Me.GridReferencias
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsView.ColumnAutoWidth = False
        Me.GridView3.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridView3.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.GridView3.OptionsView.ShowGroupPanel = False
        Me.GridView3.RowHeight = 100
        '
        'colmarca
        '
        Me.colmarca.AppearanceCell.Options.UseTextOptions = True
        Me.colmarca.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colmarca.Caption = "Marca"
        Me.colmarca.Name = "colmarca"
        Me.colmarca.OptionsEditForm.StartNewRow = True
        Me.colmarca.Width = 71
        '
        'colnegocio
        '
        Me.colnegocio.Caption = "Negocio"
        Me.colnegocio.ColumnEdit = Me.Cbo_Negocio
        Me.colnegocio.FieldName = "comercial"
        Me.colnegocio.Name = "colnegocio"
        Me.colnegocio.Visible = True
        Me.colnegocio.VisibleIndex = 0
        '
        'colTarjeta
        '
        Me.colTarjeta.Caption = "# Cuenta"
        Me.colTarjeta.FieldName = "nocuenta"
        Me.colTarjeta.Name = "colTarjeta"
        Me.colTarjeta.Visible = True
        Me.colTarjeta.VisibleIndex = 1
        Me.colTarjeta.Width = 215
        '
        'colLimite
        '
        Me.colLimite.Caption = "Límite Crédito"
        Me.colLimite.DisplayFormat.FormatString = "#,###.##"
        Me.colLimite.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colLimite.FieldName = "limite"
        Me.colLimite.Name = "colLimite"
        Me.colLimite.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value
        Me.colLimite.Visible = True
        Me.colLimite.VisibleIndex = 2
        '
        'coledocuenta
        '
        Me.coledocuenta.Caption = "Edo Cuenta"
        Me.coledocuenta.ColumnEdit = Me.RepositoryItemPictureEdit1
        Me.coledocuenta.FieldName = "edocuenta"
        Me.coledocuenta.MinWidth = 100
        Me.coledocuenta.Name = "coledocuenta"
        Me.coledocuenta.Visible = True
        Me.coledocuenta.VisibleIndex = 3
        Me.coledocuenta.Width = 120
        '
        'coledocuenta1
        '
        Me.coledocuenta1.Caption = "Edo Cuenta"
        Me.coledocuenta1.ColumnEdit = Me.RepositoryItemPictureEdit2
        Me.coledocuenta1.FieldName = "edocuenta1"
        Me.coledocuenta1.Name = "coledocuenta1"
        Me.coledocuenta1.Visible = True
        Me.coledocuenta1.VisibleIndex = 4
        Me.coledocuenta1.Width = 120
        '
        'RepositoryItemPictureEdit2
        '
        Me.RepositoryItemPictureEdit2.Name = "RepositoryItemPictureEdit2"
        Me.RepositoryItemPictureEdit2.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GridReferencias
        Me.GridView2.Name = "GridView2"
        '
        'Usp_TraerDistribComercialesTableAdapter
        '
        Me.Usp_TraerDistribComercialesTableAdapter.ClearBeforeFill = True
        '
        'Usp_TraerDistribDocumentosTableAdapter
        '
        Me.Usp_TraerDistribDocumentosTableAdapter.ClearBeforeFill = True
        '
        'frmCatalogoTH
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1084, 500)
        Me.Controls.Add(Me.Pnl_Edicion)
        Me.Controls.Add(Me.TabDistribR)
        Me.Name = "frmCatalogoTH"
        Me.Text = "Catálogo Tarjetahabiente"
        CType(Me.Cbo_Negocio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemPictureEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSMuestrasDetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSMuestrasDet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        CType(Me.Pnl_Edicion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_Edicion.ResumeLayout(False)
        CType(Me.MuestrasdetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MuestrasDetDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TFirmasDocumentos.ResumeLayout(False)
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UspTraerDistribDocumentosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Usp_TraerDistribDocumentos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemPictureEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemPictureEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pbox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TReferencias.ResumeLayout(False)
        CType(Me.PanelControl14, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl14.ResumeLayout(False)
        CType(Me.PanelControl13, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl13.ResumeLayout(False)
        Me.PanelControl13.PerformLayout()
        CType(Me.Txt_CelAmigo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_TelAmigo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_DireccionAmigo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_NombreAmigo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl12, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl12.ResumeLayout(False)
        Me.PanelControl12.PerformLayout()
        CType(Me.Txt_TelPadres2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_CelPadres.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_TelPadres1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_TelPadres.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_DireccionPadres.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_NombrePadre.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_NombreMadre.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl11.ResumeLayout(False)
        Me.PanelControl11.PerformLayout()
        CType(Me.Txt_CelConyuge.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_TelConyuge.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_IngresoConyuge.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_AntiguedadConyuge.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_PuestoConyuge.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_EmpresaConyuge.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_ApMaternoConyuge.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_ApPaternoConyuge.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_NombreConyuge.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TGenerales.ResumeLayout(False)
        CType(Me.PanelControl5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl5.ResumeLayout(False)
        Me.PanelControl5.PerformLayout()
        CType(Me.Cbo_Promocion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cbo_NegExt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cbo_ContraVale.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_LimiteVale.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_Disponible.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_Saldo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_LimiteCredito.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl4.ResumeLayout(False)
        Me.PanelControl4.PerformLayout()
        CType(Me.Txt_IngresoTotal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_OtrosIngresos.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_IngresoMensual.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_AntiguedadEmpresa.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_Puesto.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_DireccionEmpresa.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_Empresa.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.PanelControl3.PerformLayout()
        CType(Me.Txt_Email.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_Celular2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_Celular1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_TelOtro.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_TelCasa.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.Txt_ValorAutos.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_ValorCasa.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_AntiguedadVivienda.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_EntreCalles.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_Numero.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_Calle.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.Txt_Dependientes.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dt_FechaNacim.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dt_FechaNacim.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_Apmaterno.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_Appaterno.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_Nombre.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pnl_Nombre, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_Nombre.ResumeLayout(False)
        Me.Pnl_Nombre.PerformLayout()
        CType(Me.Txt_NombreCompleto.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_TarjetaHabiente.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_IdDistrib.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabDistribR.ResumeLayout(False)
        Me.TComerciales.ResumeLayout(False)
        CType(Me.GridReferencias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UspTraerDistribComercialesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Usp_TraerDistribComerciales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemPictureEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Edicion As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_Guardar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents txt_Pagaree As TextBox
    Friend WithEvents chk_pagare As CheckBox
    Friend WithEvents Label153 As Label
    Friend WithEvents OpenFileDialog As OpenFileDialog
    Friend WithEvents MuestrasdetBindingSource As BindingSource
    Friend WithEvents MuestrasDetDataSet As MuestrasDetDataSet
    Friend WithEvents DSMuestrasDetBindingSource As BindingSource
    Friend WithEvents DSMuestrasDet As DSMuestrasDet
    Friend WithEvents MuestrasdetTableAdapter As MuestrasDetDataSetTableAdapters.muestrasdetTableAdapter
    Friend WithEvents TFirmasDocumentos As TabPage
    Friend WithEvents GridControl3 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents col_marca As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coldescrip As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coli As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents colimagen As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Pbox As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemComboBox3 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RepositoryItemComboBox2 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents TReferencias As TabPage
    Friend WithEvents PanelControl14 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl13 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents Txt_CelAmigo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl86 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_TelAmigo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl89 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_DireccionAmigo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl90 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_NombreAmigo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl92 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl12 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents Txt_TelPadres2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl79 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_CelPadres As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl80 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_TelPadres1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl81 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_TelPadres As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl82 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_DireccionPadres As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl83 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_NombrePadre As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl84 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_NombreMadre As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl87 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl11 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents Txt_CelConyuge As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl76 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_TelConyuge As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl78 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_IngresoConyuge As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl47 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_AntiguedadConyuge As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl46 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_PuestoConyuge As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl44 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_EmpresaConyuge As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl45 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_ApMaternoConyuge As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl51 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_ApPaternoConyuge As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl74 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_NombreConyuge As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl75 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TGenerales As TabPage
    Friend WithEvents PanelControl5 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents Cbo_Periodicidad As ComboBox
    Friend WithEvents Cbo_TipoCredito As ComboBox
    Friend WithEvents LabelControl43 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Cbo_Promocion As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LabelControl42 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Cbo_NegExt As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LabelControl41 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Cbo_ContraVale As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents Txt_LimiteVale As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl38 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl40 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl39 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_Disponible As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl35 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_Saldo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl36 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_LimiteCredito As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl37 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents Txt_IngresoTotal As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl34 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_OtrosIngresos As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl33 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_IngresoMensual As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl32 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_AntiguedadEmpresa As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl31 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_Puesto As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl30 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_DireccionEmpresa As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl29 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_Empresa As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl28 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents Txt_Email As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl27 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_Celular2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl26 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_Celular1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl25 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_TelOtro As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl24 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_TelCasa As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl23 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents Cbo_TipoVivienda As ComboBox
    Friend WithEvents Cbo_Estado As ComboBox
    Friend WithEvents Cbo_Ciudad As ComboBox
    Friend WithEvents Cbo_Colonia As ComboBox
    Friend WithEvents Cbo_CodigoPostal As ComboBox
    Friend WithEvents Txt_ValorAutos As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Lbl_ValorEstimadoAutos As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_ValorCasa As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Lbl_ValorEstimadoCasa As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Btn_Google As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Txt_AntiguedadVivienda As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl20 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl19 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_EntreCalles As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl17 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl16 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl15 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl14 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_Numero As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_Calle As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl18 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents Cbo_Sexo As ComboBox
    Friend WithEvents Cbo_EstadoCivil As ComboBox
    Friend WithEvents Txt_Dependientes As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Dt_FechaNacim As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_Apmaterno As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_Appaterno As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_Nombre As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Pnl_Nombre As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_NombreCompleto As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_TarjetaHabiente As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Txt_IdDistrib As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TabDistribR As TabControl
    Friend WithEvents Cbo_Negocio As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RepositoryItemPictureEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
    Friend WithEvents TComerciales As TabPage
    Friend WithEvents GridReferencias As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colmarca As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colnegocio As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTarjeta As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLimite As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coledocuenta As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents coledocuenta1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemPictureEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
    Friend WithEvents RepositoryItemPictureEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
    Friend WithEvents colimagen1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemPictureEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
    Friend WithEvents UspTraerDistribComercialesBindingSource As BindingSource
    Friend WithEvents Usp_TraerDistribComerciales As usp_TraerDistribComerciales
    Friend WithEvents Usp_TraerDistribComercialesTableAdapter As usp_TraerDistribComercialesTableAdapters.usp_TraerDistribComercialesTableAdapter
    Friend WithEvents UspTraerDistribDocumentosBindingSource As BindingSource
    Friend WithEvents Usp_TraerDistribDocumentos As usp_TraerDistribDocumentos
    Friend WithEvents Usp_TraerDistribDocumentosTableAdapter As usp_TraerDistribDocumentosTableAdapters.usp_TraerDistribDocumentosTableAdapter
End Class
