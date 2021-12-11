<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPpalRotacion
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.chk_SucVenta = New DevExpress.XtraEditors.CheckEdit()
        Me.lbl_TextoFecha = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_Texto = New DevExpress.XtraEditors.LabelControl()
        Me.btn_Filtros = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_Regresar = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_Excel = New DevExpress.XtraEditors.SimpleButton()
        Me.chk_Miles = New DevExpress.XtraEditors.CheckEdit()
        Me.btn_Salir = New DevExpress.XtraEditors.SimpleButton()
        Me.gb_AñoAnt = New DevExpress.XtraEditors.GroupControl()
        Me.chk_DiaMes = New DevExpress.XtraEditors.CheckEdit()
        Me.chk_DiaSemana = New DevExpress.XtraEditors.CheckEdit()
        Me.sfdRuta = New System.Windows.Forms.SaveFileDialog()
        Me.PBox = New System.Windows.Forms.PictureBox()
        Me.gc_Reporte = New DevExpress.XtraGrid.GridControl()
        Me.dgv_Reporte = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gc_Renglon = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_IdEstructura = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_Estructura = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_Estilo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_DescripArt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_CtdNeta = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.rp_Importe = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.gc_PorcPart = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Numeric = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.gc_Existencia = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_CtdNormal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_CtdDescto = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_CtdRegalo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_PorcNormal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_PorcDescto = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_PorcRegalo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_Costo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_Venta = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_Margen = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_PorcMargen = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_PorcImpPart = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_ImpNormal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_ImpDescto = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_ImpReg = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_PorcImpNormal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_PorcImpDescto = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_PorcImpReg = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_CtdNetaAnt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_PorcPartAnt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_CtdNormalAnt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_CtdDesctoAnt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_CtdRegaloAnt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_PorcNormalAnt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_PorcDesctoAnt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_PorcRegAnt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_CostoAnt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_VentaAnt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_MargenAnt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_PorcMargenAnt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_PorcImpPartAnt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_ImpNormalAnt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_ImpDesctoAnt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_ImpRegAnt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_PorcImpNormalAnt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_PorcImpDesctoAnt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_PorcImpRegAnt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_PorcPares = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_PorcImporte = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ImpReg = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.chk_SucVenta.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chk_Miles.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gb_AñoAnt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_AñoAnt.SuspendLayout()
        CType(Me.chk_DiaMes.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chk_DiaSemana.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gc_Reporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_Reporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rp_Importe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Numeric, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.chk_SucVenta)
        Me.PanelControl1.Controls.Add(Me.lbl_TextoFecha)
        Me.PanelControl1.Controls.Add(Me.lbl_Texto)
        Me.PanelControl1.Controls.Add(Me.btn_Filtros)
        Me.PanelControl1.Controls.Add(Me.btn_Regresar)
        Me.PanelControl1.Controls.Add(Me.btn_Excel)
        Me.PanelControl1.Controls.Add(Me.chk_Miles)
        Me.PanelControl1.Controls.Add(Me.btn_Salir)
        Me.PanelControl1.Controls.Add(Me.gb_AñoAnt)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 362)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(719, 70)
        Me.PanelControl1.TabIndex = 0
        '
        'chk_SucVenta
        '
        Me.chk_SucVenta.EditValue = True
        Me.chk_SucVenta.Location = New System.Drawing.Point(125, 6)
        Me.chk_SucVenta.Name = "chk_SucVenta"
        Me.chk_SucVenta.Properties.Caption = "Solo Suc Venta"
        Me.chk_SucVenta.Size = New System.Drawing.Size(97, 19)
        Me.chk_SucVenta.TabIndex = 12
        '
        'lbl_TextoFecha
        '
        Me.lbl_TextoFecha.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_TextoFecha.Appearance.Options.UseFont = True
        Me.lbl_TextoFecha.Location = New System.Drawing.Point(228, 5)
        Me.lbl_TextoFecha.Name = "lbl_TextoFecha"
        Me.lbl_TextoFecha.Size = New System.Drawing.Size(0, 14)
        Me.lbl_TextoFecha.TabIndex = 11
        '
        'lbl_Texto
        '
        Me.lbl_Texto.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Texto.Appearance.Options.UseFont = True
        Me.lbl_Texto.Location = New System.Drawing.Point(216, 33)
        Me.lbl_Texto.Name = "lbl_Texto"
        Me.lbl_Texto.Size = New System.Drawing.Size(0, 14)
        Me.lbl_Texto.TabIndex = 10
        '
        'btn_Filtros
        '
        Me.btn_Filtros.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Filtros.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.magnifier_zoom_in
        Me.btn_Filtros.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Filtros.Location = New System.Drawing.Point(461, 2)
        Me.btn_Filtros.Name = "btn_Filtros"
        Me.btn_Filtros.Size = New System.Drawing.Size(64, 66)
        Me.btn_Filtros.TabIndex = 9
        '
        'btn_Regresar
        '
        Me.btn_Regresar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Regresar.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.arrow_left
        Me.btn_Regresar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Regresar.Location = New System.Drawing.Point(525, 2)
        Me.btn_Regresar.Name = "btn_Regresar"
        Me.btn_Regresar.Size = New System.Drawing.Size(64, 66)
        Me.btn_Regresar.TabIndex = 8
        '
        'btn_Excel
        '
        Me.btn_Excel.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Excel.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.table_excel
        Me.btn_Excel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Excel.Location = New System.Drawing.Point(589, 2)
        Me.btn_Excel.Name = "btn_Excel"
        Me.btn_Excel.Size = New System.Drawing.Size(64, 66)
        Me.btn_Excel.TabIndex = 7
        '
        'chk_Miles
        '
        Me.chk_Miles.Location = New System.Drawing.Point(125, 39)
        Me.chk_Miles.Name = "chk_Miles"
        Me.chk_Miles.Properties.Caption = "En Miles"
        Me.chk_Miles.Size = New System.Drawing.Size(75, 19)
        Me.chk_Miles.TabIndex = 6
        '
        'btn_Salir
        '
        Me.btn_Salir.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Salir.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.door_out
        Me.btn_Salir.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Salir.Location = New System.Drawing.Point(653, 2)
        Me.btn_Salir.Name = "btn_Salir"
        Me.btn_Salir.Size = New System.Drawing.Size(64, 66)
        Me.btn_Salir.TabIndex = 1
        '
        'gb_AñoAnt
        '
        Me.gb_AñoAnt.Controls.Add(Me.chk_DiaMes)
        Me.gb_AñoAnt.Controls.Add(Me.chk_DiaSemana)
        Me.gb_AñoAnt.Dock = System.Windows.Forms.DockStyle.Left
        Me.gb_AñoAnt.Location = New System.Drawing.Point(2, 2)
        Me.gb_AñoAnt.Name = "gb_AñoAnt"
        Me.gb_AñoAnt.Size = New System.Drawing.Size(117, 66)
        Me.gb_AñoAnt.TabIndex = 0
        Me.gb_AñoAnt.Text = "Año Anterior"
        '
        'chk_DiaMes
        '
        Me.chk_DiaMes.Location = New System.Drawing.Point(6, 49)
        Me.chk_DiaMes.Name = "chk_DiaMes"
        Me.chk_DiaMes.Properties.Caption = "Día del mes"
        Me.chk_DiaMes.Size = New System.Drawing.Size(75, 19)
        Me.chk_DiaMes.TabIndex = 1
        '
        'chk_DiaSemana
        '
        Me.chk_DiaSemana.Location = New System.Drawing.Point(6, 24)
        Me.chk_DiaSemana.Name = "chk_DiaSemana"
        Me.chk_DiaSemana.Properties.Caption = "Día de la semana"
        Me.chk_DiaSemana.Size = New System.Drawing.Size(105, 19)
        Me.chk_DiaSemana.TabIndex = 0
        '
        'PBox
        '
        Me.PBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PBox.Location = New System.Drawing.Point(567, 202)
        Me.PBox.Name = "PBox"
        Me.PBox.Size = New System.Drawing.Size(140, 122)
        Me.PBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBox.TabIndex = 2
        Me.PBox.TabStop = False
        Me.PBox.Visible = False
        '
        'gc_Reporte
        '
        Me.gc_Reporte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gc_Reporte.Location = New System.Drawing.Point(0, 0)
        Me.gc_Reporte.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.gc_Reporte.LookAndFeel.UseWindowsXPTheme = True
        Me.gc_Reporte.MainView = Me.dgv_Reporte
        Me.gc_Reporte.Name = "gc_Reporte"
        Me.gc_Reporte.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.Numeric, Me.rp_Importe})
        Me.gc_Reporte.Size = New System.Drawing.Size(719, 362)
        Me.gc_Reporte.TabIndex = 3
        Me.gc_Reporte.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.dgv_Reporte})
        '
        'dgv_Reporte
        '
        Me.dgv_Reporte.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgv_Reporte.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgv_Reporte.Appearance.HeaderPanel.Options.UseBackColor = True
        Me.dgv_Reporte.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.dgv_Reporte.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.dgv_Reporte.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.dgv_Reporte.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gc_Renglon, Me.gc_IdEstructura, Me.gc_Estructura, Me.gc_Estilo, Me.gc_DescripArt, Me.gc_CtdNeta, Me.gc_PorcPart, Me.gc_Existencia, Me.gc_CtdNormal, Me.gc_CtdDescto, Me.gc_CtdRegalo, Me.gc_PorcNormal, Me.gc_PorcDescto, Me.gc_PorcRegalo, Me.gc_Costo, Me.gc_Venta, Me.gc_Margen, Me.gc_PorcMargen, Me.gc_PorcImpPart, Me.gc_ImpNormal, Me.gc_ImpDescto, Me.gc_ImpReg, Me.gc_PorcImpNormal, Me.gc_PorcImpDescto, Me.gc_PorcImpReg, Me.gc_CtdNetaAnt, Me.gc_PorcPartAnt, Me.gc_CtdNormalAnt, Me.gc_CtdDesctoAnt, Me.gc_CtdRegaloAnt, Me.gc_PorcNormalAnt, Me.gc_PorcDesctoAnt, Me.gc_PorcRegAnt, Me.gc_CostoAnt, Me.gc_VentaAnt, Me.gc_MargenAnt, Me.gc_PorcMargenAnt, Me.gc_PorcImpPartAnt, Me.gc_ImpNormalAnt, Me.gc_ImpDesctoAnt, Me.gc_ImpRegAnt, Me.gc_PorcImpNormalAnt, Me.gc_PorcImpDesctoAnt, Me.gc_PorcImpRegAnt, Me.gc_PorcPares, Me.gc_PorcImporte, Me.ImpReg})
        Me.dgv_Reporte.GridControl = Me.gc_Reporte
        Me.dgv_Reporte.Name = "dgv_Reporte"
        Me.dgv_Reporte.OptionsBehavior.Editable = False
        Me.dgv_Reporte.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Fast
        Me.dgv_Reporte.OptionsView.ColumnAutoWidth = False
        '
        'gc_Renglon
        '
        Me.gc_Renglon.AppearanceCell.BackColor = System.Drawing.Color.PowderBlue
        Me.gc_Renglon.AppearanceCell.BackColor2 = System.Drawing.Color.PowderBlue
        Me.gc_Renglon.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_Renglon.AppearanceCell.Options.UseBackColor = True
        Me.gc_Renglon.AppearanceCell.Options.UseFont = True
        Me.gc_Renglon.AppearanceCell.Options.UseTextOptions = True
        Me.gc_Renglon.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gc_Renglon.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gc_Renglon.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_Renglon.AppearanceHeader.Options.UseFont = True
        Me.gc_Renglon.Caption = "Renglon"
        Me.gc_Renglon.FieldName = "renglon"
        Me.gc_Renglon.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.gc_Renglon.Name = "gc_Renglon"
        Me.gc_Renglon.Visible = True
        Me.gc_Renglon.VisibleIndex = 0
        '
        'gc_IdEstructura
        '
        Me.gc_IdEstructura.AppearanceCell.BackColor = System.Drawing.Color.PowderBlue
        Me.gc_IdEstructura.AppearanceCell.BackColor2 = System.Drawing.Color.PowderBlue
        Me.gc_IdEstructura.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_IdEstructura.AppearanceCell.Options.UseBackColor = True
        Me.gc_IdEstructura.AppearanceCell.Options.UseFont = True
        Me.gc_IdEstructura.AppearanceCell.Options.UseTextOptions = True
        Me.gc_IdEstructura.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gc_IdEstructura.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gc_IdEstructura.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_IdEstructura.AppearanceHeader.Options.UseFont = True
        Me.gc_IdEstructura.Caption = "IdEstructura"
        Me.gc_IdEstructura.FieldName = "idestructura"
        Me.gc_IdEstructura.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.gc_IdEstructura.Name = "gc_IdEstructura"
        Me.gc_IdEstructura.Visible = True
        Me.gc_IdEstructura.VisibleIndex = 1
        '
        'gc_Estructura
        '
        Me.gc_Estructura.AppearanceCell.BackColor = System.Drawing.Color.PowderBlue
        Me.gc_Estructura.AppearanceCell.BackColor2 = System.Drawing.Color.PowderBlue
        Me.gc_Estructura.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_Estructura.AppearanceCell.Options.UseBackColor = True
        Me.gc_Estructura.AppearanceCell.Options.UseFont = True
        Me.gc_Estructura.AppearanceCell.Options.UseTextOptions = True
        Me.gc_Estructura.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gc_Estructura.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gc_Estructura.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_Estructura.AppearanceHeader.Options.UseFont = True
        Me.gc_Estructura.Caption = "Estructura"
        Me.gc_Estructura.FieldName = "estructura"
        Me.gc_Estructura.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.gc_Estructura.Name = "gc_Estructura"
        Me.gc_Estructura.Visible = True
        Me.gc_Estructura.VisibleIndex = 2
        '
        'gc_Estilo
        '
        Me.gc_Estilo.AppearanceCell.BackColor = System.Drawing.Color.PowderBlue
        Me.gc_Estilo.AppearanceCell.BackColor2 = System.Drawing.Color.PowderBlue
        Me.gc_Estilo.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_Estilo.AppearanceCell.Options.UseBackColor = True
        Me.gc_Estilo.AppearanceCell.Options.UseFont = True
        Me.gc_Estilo.AppearanceCell.Options.UseTextOptions = True
        Me.gc_Estilo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gc_Estilo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gc_Estilo.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_Estilo.AppearanceHeader.Options.UseFont = True
        Me.gc_Estilo.Caption = "Estilo"
        Me.gc_Estilo.FieldName = "estilo"
        Me.gc_Estilo.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.gc_Estilo.Name = "gc_Estilo"
        Me.gc_Estilo.Visible = True
        Me.gc_Estilo.VisibleIndex = 3
        '
        'gc_DescripArt
        '
        Me.gc_DescripArt.AppearanceCell.BackColor = System.Drawing.Color.PowderBlue
        Me.gc_DescripArt.AppearanceCell.BackColor2 = System.Drawing.Color.PowderBlue
        Me.gc_DescripArt.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_DescripArt.AppearanceCell.Options.UseBackColor = True
        Me.gc_DescripArt.AppearanceCell.Options.UseFont = True
        Me.gc_DescripArt.AppearanceCell.Options.UseTextOptions = True
        Me.gc_DescripArt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gc_DescripArt.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gc_DescripArt.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_DescripArt.AppearanceHeader.Options.UseFont = True
        Me.gc_DescripArt.Caption = "Descripción"
        Me.gc_DescripArt.FieldName = "descripcionart"
        Me.gc_DescripArt.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.gc_DescripArt.Name = "gc_DescripArt"
        Me.gc_DescripArt.Visible = True
        Me.gc_DescripArt.VisibleIndex = 4
        '
        'gc_CtdNeta
        '
        Me.gc_CtdNeta.AppearanceCell.BackColor = System.Drawing.Color.Wheat
        Me.gc_CtdNeta.AppearanceCell.BackColor2 = System.Drawing.Color.Wheat
        Me.gc_CtdNeta.AppearanceCell.Options.UseBackColor = True
        Me.gc_CtdNeta.AppearanceCell.Options.UseTextOptions = True
        Me.gc_CtdNeta.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gc_CtdNeta.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gc_CtdNeta.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_CtdNeta.AppearanceHeader.Options.UseFont = True
        Me.gc_CtdNeta.Caption = "Vta Unid"
        Me.gc_CtdNeta.ColumnEdit = Me.rp_Importe
        Me.gc_CtdNeta.FieldName = "ctdneta"
        Me.gc_CtdNeta.Name = "gc_CtdNeta"
        Me.gc_CtdNeta.Visible = True
        Me.gc_CtdNeta.VisibleIndex = 5
        '
        'rp_Importe
        '
        Me.rp_Importe.AutoHeight = False
        Me.rp_Importe.DisplayFormat.FormatString = "###,###,##0"
        Me.rp_Importe.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.rp_Importe.EditFormat.FormatString = "###,###,##0"
        Me.rp_Importe.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.rp_Importe.Mask.EditMask = "n0"
        Me.rp_Importe.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.rp_Importe.Name = "rp_Importe"
        '
        'gc_PorcPart
        '
        Me.gc_PorcPart.AppearanceCell.BackColor = System.Drawing.Color.Wheat
        Me.gc_PorcPart.AppearanceCell.BackColor2 = System.Drawing.Color.Wheat
        Me.gc_PorcPart.AppearanceCell.Options.UseBackColor = True
        Me.gc_PorcPart.AppearanceCell.Options.UseTextOptions = True
        Me.gc_PorcPart.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gc_PorcPart.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gc_PorcPart.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_PorcPart.AppearanceHeader.Options.UseFont = True
        Me.gc_PorcPart.Caption = "% Part"
        Me.gc_PorcPart.ColumnEdit = Me.Numeric
        Me.gc_PorcPart.FieldName = "porcpart"
        Me.gc_PorcPart.Name = "gc_PorcPart"
        Me.gc_PorcPart.Visible = True
        Me.gc_PorcPart.VisibleIndex = 6
        '
        'Numeric
        '
        Me.Numeric.AutoHeight = False
        Me.Numeric.DisplayFormat.FormatString = "#0%"
        Me.Numeric.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.Numeric.EditFormat.FormatString = "#0%"
        Me.Numeric.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.Numeric.Mask.EditMask = "p"
        Me.Numeric.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.Numeric.Name = "Numeric"
        '
        'gc_Existencia
        '
        Me.gc_Existencia.AppearanceCell.BackColor = System.Drawing.Color.Wheat
        Me.gc_Existencia.AppearanceCell.BackColor2 = System.Drawing.Color.Wheat
        Me.gc_Existencia.AppearanceCell.Options.UseBackColor = True
        Me.gc_Existencia.AppearanceCell.Options.UseTextOptions = True
        Me.gc_Existencia.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gc_Existencia.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gc_Existencia.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_Existencia.AppearanceHeader.Options.UseFont = True
        Me.gc_Existencia.Caption = "Existencia"
        Me.gc_Existencia.ColumnEdit = Me.rp_Importe
        Me.gc_Existencia.FieldName = "existencia"
        Me.gc_Existencia.Name = "gc_Existencia"
        Me.gc_Existencia.Visible = True
        Me.gc_Existencia.VisibleIndex = 7
        '
        'gc_CtdNormal
        '
        Me.gc_CtdNormal.AppearanceCell.BackColor = System.Drawing.Color.Wheat
        Me.gc_CtdNormal.AppearanceCell.BackColor2 = System.Drawing.Color.Wheat
        Me.gc_CtdNormal.AppearanceCell.Options.UseBackColor = True
        Me.gc_CtdNormal.AppearanceCell.Options.UseTextOptions = True
        Me.gc_CtdNormal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gc_CtdNormal.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gc_CtdNormal.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_CtdNormal.AppearanceHeader.Options.UseFont = True
        Me.gc_CtdNormal.Caption = "Vta Unid Normal"
        Me.gc_CtdNormal.ColumnEdit = Me.rp_Importe
        Me.gc_CtdNormal.FieldName = "ctdnormalneta"
        Me.gc_CtdNormal.Name = "gc_CtdNormal"
        Me.gc_CtdNormal.Visible = True
        Me.gc_CtdNormal.VisibleIndex = 8
        '
        'gc_CtdDescto
        '
        Me.gc_CtdDescto.AppearanceCell.BackColor = System.Drawing.Color.Wheat
        Me.gc_CtdDescto.AppearanceCell.BackColor2 = System.Drawing.Color.Wheat
        Me.gc_CtdDescto.AppearanceCell.Options.UseBackColor = True
        Me.gc_CtdDescto.AppearanceCell.Options.UseTextOptions = True
        Me.gc_CtdDescto.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gc_CtdDescto.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gc_CtdDescto.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_CtdDescto.AppearanceHeader.Options.UseFont = True
        Me.gc_CtdDescto.Caption = "Vta Unid Descto"
        Me.gc_CtdDescto.ColumnEdit = Me.rp_Importe
        Me.gc_CtdDescto.FieldName = "ctddesctoneta"
        Me.gc_CtdDescto.Name = "gc_CtdDescto"
        Me.gc_CtdDescto.Visible = True
        Me.gc_CtdDescto.VisibleIndex = 9
        '
        'gc_CtdRegalo
        '
        Me.gc_CtdRegalo.AppearanceCell.BackColor = System.Drawing.Color.Wheat
        Me.gc_CtdRegalo.AppearanceCell.BackColor2 = System.Drawing.Color.Wheat
        Me.gc_CtdRegalo.AppearanceCell.Options.UseBackColor = True
        Me.gc_CtdRegalo.AppearanceCell.Options.UseTextOptions = True
        Me.gc_CtdRegalo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gc_CtdRegalo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gc_CtdRegalo.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_CtdRegalo.AppearanceHeader.Options.UseFont = True
        Me.gc_CtdRegalo.Caption = "Vta Unid Regalo"
        Me.gc_CtdRegalo.ColumnEdit = Me.rp_Importe
        Me.gc_CtdRegalo.FieldName = "ctdregneta"
        Me.gc_CtdRegalo.Name = "gc_CtdRegalo"
        Me.gc_CtdRegalo.Visible = True
        Me.gc_CtdRegalo.VisibleIndex = 10
        '
        'gc_PorcNormal
        '
        Me.gc_PorcNormal.AppearanceCell.BackColor = System.Drawing.Color.Wheat
        Me.gc_PorcNormal.AppearanceCell.BackColor2 = System.Drawing.Color.Wheat
        Me.gc_PorcNormal.AppearanceCell.Options.UseBackColor = True
        Me.gc_PorcNormal.AppearanceCell.Options.UseTextOptions = True
        Me.gc_PorcNormal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gc_PorcNormal.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gc_PorcNormal.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_PorcNormal.AppearanceHeader.Options.UseFont = True
        Me.gc_PorcNormal.Caption = "% Normal"
        Me.gc_PorcNormal.ColumnEdit = Me.Numeric
        Me.gc_PorcNormal.FieldName = "porcnormal"
        Me.gc_PorcNormal.Name = "gc_PorcNormal"
        Me.gc_PorcNormal.Visible = True
        Me.gc_PorcNormal.VisibleIndex = 11
        '
        'gc_PorcDescto
        '
        Me.gc_PorcDescto.AppearanceCell.BackColor = System.Drawing.Color.Wheat
        Me.gc_PorcDescto.AppearanceCell.BackColor2 = System.Drawing.Color.Wheat
        Me.gc_PorcDescto.AppearanceCell.Options.UseBackColor = True
        Me.gc_PorcDescto.AppearanceCell.Options.UseTextOptions = True
        Me.gc_PorcDescto.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gc_PorcDescto.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gc_PorcDescto.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_PorcDescto.AppearanceHeader.Options.UseFont = True
        Me.gc_PorcDescto.Caption = "% Descto"
        Me.gc_PorcDescto.ColumnEdit = Me.Numeric
        Me.gc_PorcDescto.FieldName = "porcdescto"
        Me.gc_PorcDescto.Name = "gc_PorcDescto"
        Me.gc_PorcDescto.Visible = True
        Me.gc_PorcDescto.VisibleIndex = 12
        '
        'gc_PorcRegalo
        '
        Me.gc_PorcRegalo.AppearanceCell.BackColor = System.Drawing.Color.Wheat
        Me.gc_PorcRegalo.AppearanceCell.BackColor2 = System.Drawing.Color.Wheat
        Me.gc_PorcRegalo.AppearanceCell.Options.UseBackColor = True
        Me.gc_PorcRegalo.AppearanceCell.Options.UseTextOptions = True
        Me.gc_PorcRegalo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gc_PorcRegalo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gc_PorcRegalo.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_PorcRegalo.AppearanceHeader.Options.UseFont = True
        Me.gc_PorcRegalo.Caption = "% Regalo"
        Me.gc_PorcRegalo.ColumnEdit = Me.Numeric
        Me.gc_PorcRegalo.FieldName = "porcregalo"
        Me.gc_PorcRegalo.Name = "gc_PorcRegalo"
        Me.gc_PorcRegalo.Visible = True
        Me.gc_PorcRegalo.VisibleIndex = 13
        '
        'gc_Costo
        '
        Me.gc_Costo.AppearanceCell.BackColor = System.Drawing.Color.White
        Me.gc_Costo.AppearanceCell.BackColor2 = System.Drawing.Color.White
        Me.gc_Costo.AppearanceCell.Options.UseBackColor = True
        Me.gc_Costo.AppearanceCell.Options.UseTextOptions = True
        Me.gc_Costo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gc_Costo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gc_Costo.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_Costo.AppearanceHeader.Options.UseFont = True
        Me.gc_Costo.Caption = "Costo"
        Me.gc_Costo.ColumnEdit = Me.rp_Importe
        Me.gc_Costo.FieldName = "costo"
        Me.gc_Costo.Name = "gc_Costo"
        Me.gc_Costo.Visible = True
        Me.gc_Costo.VisibleIndex = 14
        '
        'gc_Venta
        '
        Me.gc_Venta.AppearanceCell.BackColor = System.Drawing.Color.White
        Me.gc_Venta.AppearanceCell.BackColor2 = System.Drawing.Color.White
        Me.gc_Venta.AppearanceCell.Options.UseBackColor = True
        Me.gc_Venta.AppearanceCell.Options.UseTextOptions = True
        Me.gc_Venta.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gc_Venta.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gc_Venta.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_Venta.AppearanceHeader.Options.UseFont = True
        Me.gc_Venta.Caption = "$ Venta"
        Me.gc_Venta.ColumnEdit = Me.rp_Importe
        Me.gc_Venta.FieldName = "venta"
        Me.gc_Venta.Name = "gc_Venta"
        Me.gc_Venta.Visible = True
        Me.gc_Venta.VisibleIndex = 15
        '
        'gc_Margen
        '
        Me.gc_Margen.AppearanceCell.BackColor = System.Drawing.Color.White
        Me.gc_Margen.AppearanceCell.BackColor2 = System.Drawing.Color.White
        Me.gc_Margen.AppearanceCell.Options.UseBackColor = True
        Me.gc_Margen.AppearanceCell.Options.UseTextOptions = True
        Me.gc_Margen.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gc_Margen.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gc_Margen.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_Margen.AppearanceHeader.Options.UseFont = True
        Me.gc_Margen.Caption = "$ Margen"
        Me.gc_Margen.ColumnEdit = Me.rp_Importe
        Me.gc_Margen.FieldName = "margen"
        Me.gc_Margen.Name = "gc_Margen"
        Me.gc_Margen.Visible = True
        Me.gc_Margen.VisibleIndex = 16
        '
        'gc_PorcMargen
        '
        Me.gc_PorcMargen.AppearanceCell.BackColor = System.Drawing.Color.White
        Me.gc_PorcMargen.AppearanceCell.BackColor2 = System.Drawing.Color.White
        Me.gc_PorcMargen.AppearanceCell.Options.UseBackColor = True
        Me.gc_PorcMargen.AppearanceCell.Options.UseTextOptions = True
        Me.gc_PorcMargen.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gc_PorcMargen.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gc_PorcMargen.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_PorcMargen.AppearanceHeader.Options.UseFont = True
        Me.gc_PorcMargen.Caption = "% Margen"
        Me.gc_PorcMargen.ColumnEdit = Me.Numeric
        Me.gc_PorcMargen.FieldName = "porcmargen"
        Me.gc_PorcMargen.Name = "gc_PorcMargen"
        Me.gc_PorcMargen.Visible = True
        Me.gc_PorcMargen.VisibleIndex = 17
        '
        'gc_PorcImpPart
        '
        Me.gc_PorcImpPart.AppearanceCell.BackColor = System.Drawing.Color.White
        Me.gc_PorcImpPart.AppearanceCell.BackColor2 = System.Drawing.Color.White
        Me.gc_PorcImpPart.AppearanceCell.Options.UseBackColor = True
        Me.gc_PorcImpPart.AppearanceCell.Options.UseTextOptions = True
        Me.gc_PorcImpPart.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gc_PorcImpPart.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gc_PorcImpPart.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_PorcImpPart.AppearanceHeader.Options.UseFont = True
        Me.gc_PorcImpPart.Caption = "% Part Vta"
        Me.gc_PorcImpPart.ColumnEdit = Me.Numeric
        Me.gc_PorcImpPart.FieldName = "porcimppart"
        Me.gc_PorcImpPart.Name = "gc_PorcImpPart"
        Me.gc_PorcImpPart.Visible = True
        Me.gc_PorcImpPart.VisibleIndex = 18
        '
        'gc_ImpNormal
        '
        Me.gc_ImpNormal.AppearanceCell.BackColor = System.Drawing.Color.White
        Me.gc_ImpNormal.AppearanceCell.BackColor2 = System.Drawing.Color.White
        Me.gc_ImpNormal.AppearanceCell.Options.UseBackColor = True
        Me.gc_ImpNormal.AppearanceCell.Options.UseTextOptions = True
        Me.gc_ImpNormal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gc_ImpNormal.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gc_ImpNormal.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_ImpNormal.AppearanceHeader.Options.UseFont = True
        Me.gc_ImpNormal.Caption = "$ Vta Normal"
        Me.gc_ImpNormal.ColumnEdit = Me.rp_Importe
        Me.gc_ImpNormal.FieldName = "impnormalneto"
        Me.gc_ImpNormal.Name = "gc_ImpNormal"
        Me.gc_ImpNormal.Visible = True
        Me.gc_ImpNormal.VisibleIndex = 19
        '
        'gc_ImpDescto
        '
        Me.gc_ImpDescto.AppearanceCell.BackColor = System.Drawing.Color.White
        Me.gc_ImpDescto.AppearanceCell.BackColor2 = System.Drawing.Color.White
        Me.gc_ImpDescto.AppearanceCell.Options.UseBackColor = True
        Me.gc_ImpDescto.AppearanceCell.Options.UseTextOptions = True
        Me.gc_ImpDescto.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gc_ImpDescto.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gc_ImpDescto.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_ImpDescto.AppearanceHeader.Options.UseFont = True
        Me.gc_ImpDescto.Caption = "$ Vta Descto "
        Me.gc_ImpDescto.ColumnEdit = Me.rp_Importe
        Me.gc_ImpDescto.FieldName = "impdesctoneto"
        Me.gc_ImpDescto.Name = "gc_ImpDescto"
        Me.gc_ImpDescto.Visible = True
        Me.gc_ImpDescto.VisibleIndex = 20
        '
        'gc_ImpReg
        '
        Me.gc_ImpReg.AppearanceCell.BackColor = System.Drawing.Color.White
        Me.gc_ImpReg.AppearanceCell.BackColor2 = System.Drawing.Color.White
        Me.gc_ImpReg.AppearanceCell.Options.UseBackColor = True
        Me.gc_ImpReg.AppearanceCell.Options.UseTextOptions = True
        Me.gc_ImpReg.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gc_ImpReg.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gc_ImpReg.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_ImpReg.AppearanceHeader.Options.UseFont = True
        Me.gc_ImpReg.Caption = "INV.PROM.(COSTO)"
        Me.gc_ImpReg.ColumnEdit = Me.rp_Importe
        Me.gc_ImpReg.FieldName = "impregneto"
        Me.gc_ImpReg.Name = "gc_ImpReg"
        Me.gc_ImpReg.Visible = True
        Me.gc_ImpReg.VisibleIndex = 21
        '
        'gc_PorcImpNormal
        '
        Me.gc_PorcImpNormal.AppearanceCell.BackColor = System.Drawing.Color.White
        Me.gc_PorcImpNormal.AppearanceCell.BackColor2 = System.Drawing.Color.White
        Me.gc_PorcImpNormal.AppearanceCell.Options.UseBackColor = True
        Me.gc_PorcImpNormal.AppearanceCell.Options.UseTextOptions = True
        Me.gc_PorcImpNormal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gc_PorcImpNormal.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gc_PorcImpNormal.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_PorcImpNormal.AppearanceHeader.Options.UseFont = True
        Me.gc_PorcImpNormal.Caption = "% Normal"
        Me.gc_PorcImpNormal.ColumnEdit = Me.Numeric
        Me.gc_PorcImpNormal.FieldName = "porcimpnormal"
        Me.gc_PorcImpNormal.Name = "gc_PorcImpNormal"
        Me.gc_PorcImpNormal.Visible = True
        Me.gc_PorcImpNormal.VisibleIndex = 22
        '
        'gc_PorcImpDescto
        '
        Me.gc_PorcImpDescto.AppearanceCell.BackColor = System.Drawing.Color.White
        Me.gc_PorcImpDescto.AppearanceCell.BackColor2 = System.Drawing.Color.White
        Me.gc_PorcImpDescto.AppearanceCell.Options.UseBackColor = True
        Me.gc_PorcImpDescto.AppearanceCell.Options.UseTextOptions = True
        Me.gc_PorcImpDescto.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gc_PorcImpDescto.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gc_PorcImpDescto.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_PorcImpDescto.AppearanceHeader.Options.UseFont = True
        Me.gc_PorcImpDescto.Caption = "% Descto"
        Me.gc_PorcImpDescto.ColumnEdit = Me.Numeric
        Me.gc_PorcImpDescto.FieldName = "porcimpdescto"
        Me.gc_PorcImpDescto.Name = "gc_PorcImpDescto"
        Me.gc_PorcImpDescto.Visible = True
        Me.gc_PorcImpDescto.VisibleIndex = 23
        '
        'gc_PorcImpReg
        '
        Me.gc_PorcImpReg.AppearanceCell.BackColor = System.Drawing.Color.White
        Me.gc_PorcImpReg.AppearanceCell.BackColor2 = System.Drawing.Color.White
        Me.gc_PorcImpReg.AppearanceCell.Options.UseBackColor = True
        Me.gc_PorcImpReg.AppearanceCell.Options.UseTextOptions = True
        Me.gc_PorcImpReg.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gc_PorcImpReg.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gc_PorcImpReg.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_PorcImpReg.AppearanceHeader.Options.UseFont = True
        Me.gc_PorcImpReg.Caption = "IR Anualizado"
        Me.gc_PorcImpReg.ColumnEdit = Me.Numeric
        Me.gc_PorcImpReg.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.gc_PorcImpReg.FieldName = "porcimpreg"
        Me.gc_PorcImpReg.Name = "gc_PorcImpReg"
        Me.gc_PorcImpReg.Visible = True
        Me.gc_PorcImpReg.VisibleIndex = 24
        '
        'gc_CtdNetaAnt
        '
        Me.gc_CtdNetaAnt.AppearanceCell.BackColor = System.Drawing.Color.Wheat
        Me.gc_CtdNetaAnt.AppearanceCell.BackColor2 = System.Drawing.Color.Wheat
        Me.gc_CtdNetaAnt.AppearanceCell.Options.UseBackColor = True
        Me.gc_CtdNetaAnt.AppearanceCell.Options.UseTextOptions = True
        Me.gc_CtdNetaAnt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gc_CtdNetaAnt.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gc_CtdNetaAnt.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_CtdNetaAnt.AppearanceHeader.Options.UseFont = True
        Me.gc_CtdNetaAnt.Caption = "Vta Unid Ant"
        Me.gc_CtdNetaAnt.ColumnEdit = Me.rp_Importe
        Me.gc_CtdNetaAnt.FieldName = "ctdnetaant"
        Me.gc_CtdNetaAnt.Name = "gc_CtdNetaAnt"
        Me.gc_CtdNetaAnt.Visible = True
        Me.gc_CtdNetaAnt.VisibleIndex = 25
        '
        'gc_PorcPartAnt
        '
        Me.gc_PorcPartAnt.AppearanceCell.BackColor = System.Drawing.Color.Wheat
        Me.gc_PorcPartAnt.AppearanceCell.BackColor2 = System.Drawing.Color.Wheat
        Me.gc_PorcPartAnt.AppearanceCell.Options.UseBackColor = True
        Me.gc_PorcPartAnt.AppearanceCell.Options.UseTextOptions = True
        Me.gc_PorcPartAnt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gc_PorcPartAnt.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gc_PorcPartAnt.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_PorcPartAnt.AppearanceHeader.Options.UseFont = True
        Me.gc_PorcPartAnt.Caption = "% Part Ant"
        Me.gc_PorcPartAnt.ColumnEdit = Me.Numeric
        Me.gc_PorcPartAnt.FieldName = "porcpartant"
        Me.gc_PorcPartAnt.Name = "gc_PorcPartAnt"
        Me.gc_PorcPartAnt.Visible = True
        Me.gc_PorcPartAnt.VisibleIndex = 26
        '
        'gc_CtdNormalAnt
        '
        Me.gc_CtdNormalAnt.AppearanceCell.BackColor = System.Drawing.Color.Wheat
        Me.gc_CtdNormalAnt.AppearanceCell.BackColor2 = System.Drawing.Color.Wheat
        Me.gc_CtdNormalAnt.AppearanceCell.Options.UseBackColor = True
        Me.gc_CtdNormalAnt.AppearanceCell.Options.UseTextOptions = True
        Me.gc_CtdNormalAnt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gc_CtdNormalAnt.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gc_CtdNormalAnt.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_CtdNormalAnt.AppearanceHeader.Options.UseFont = True
        Me.gc_CtdNormalAnt.Caption = "Vta Unid Normal Ant"
        Me.gc_CtdNormalAnt.ColumnEdit = Me.rp_Importe
        Me.gc_CtdNormalAnt.FieldName = "ctdnormalnetaant"
        Me.gc_CtdNormalAnt.Name = "gc_CtdNormalAnt"
        Me.gc_CtdNormalAnt.Visible = True
        Me.gc_CtdNormalAnt.VisibleIndex = 27
        '
        'gc_CtdDesctoAnt
        '
        Me.gc_CtdDesctoAnt.AppearanceCell.BackColor = System.Drawing.Color.Wheat
        Me.gc_CtdDesctoAnt.AppearanceCell.BackColor2 = System.Drawing.Color.Wheat
        Me.gc_CtdDesctoAnt.AppearanceCell.Options.UseBackColor = True
        Me.gc_CtdDesctoAnt.AppearanceCell.Options.UseTextOptions = True
        Me.gc_CtdDesctoAnt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gc_CtdDesctoAnt.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gc_CtdDesctoAnt.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_CtdDesctoAnt.AppearanceHeader.Options.UseFont = True
        Me.gc_CtdDesctoAnt.Caption = "Vta  Unid Descto Ant"
        Me.gc_CtdDesctoAnt.ColumnEdit = Me.rp_Importe
        Me.gc_CtdDesctoAnt.FieldName = "ctddesctonetaant"
        Me.gc_CtdDesctoAnt.Name = "gc_CtdDesctoAnt"
        Me.gc_CtdDesctoAnt.Visible = True
        Me.gc_CtdDesctoAnt.VisibleIndex = 28
        '
        'gc_CtdRegaloAnt
        '
        Me.gc_CtdRegaloAnt.AppearanceCell.BackColor = System.Drawing.Color.Wheat
        Me.gc_CtdRegaloAnt.AppearanceCell.BackColor2 = System.Drawing.Color.Wheat
        Me.gc_CtdRegaloAnt.AppearanceCell.Options.UseBackColor = True
        Me.gc_CtdRegaloAnt.AppearanceCell.Options.UseTextOptions = True
        Me.gc_CtdRegaloAnt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gc_CtdRegaloAnt.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gc_CtdRegaloAnt.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_CtdRegaloAnt.AppearanceHeader.Options.UseFont = True
        Me.gc_CtdRegaloAnt.Caption = "Vta Unid Regalo Ant"
        Me.gc_CtdRegaloAnt.ColumnEdit = Me.rp_Importe
        Me.gc_CtdRegaloAnt.FieldName = "ctdregnetaant"
        Me.gc_CtdRegaloAnt.Name = "gc_CtdRegaloAnt"
        Me.gc_CtdRegaloAnt.Visible = True
        Me.gc_CtdRegaloAnt.VisibleIndex = 29
        '
        'gc_PorcNormalAnt
        '
        Me.gc_PorcNormalAnt.AppearanceCell.BackColor = System.Drawing.Color.Wheat
        Me.gc_PorcNormalAnt.AppearanceCell.BackColor2 = System.Drawing.Color.Wheat
        Me.gc_PorcNormalAnt.AppearanceCell.Options.UseBackColor = True
        Me.gc_PorcNormalAnt.AppearanceCell.Options.UseTextOptions = True
        Me.gc_PorcNormalAnt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gc_PorcNormalAnt.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gc_PorcNormalAnt.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_PorcNormalAnt.AppearanceHeader.Options.UseFont = True
        Me.gc_PorcNormalAnt.Caption = "% Normal Ant"
        Me.gc_PorcNormalAnt.ColumnEdit = Me.Numeric
        Me.gc_PorcNormalAnt.FieldName = "porcnormalant"
        Me.gc_PorcNormalAnt.Name = "gc_PorcNormalAnt"
        Me.gc_PorcNormalAnt.Visible = True
        Me.gc_PorcNormalAnt.VisibleIndex = 30
        '
        'gc_PorcDesctoAnt
        '
        Me.gc_PorcDesctoAnt.AppearanceCell.BackColor = System.Drawing.Color.Wheat
        Me.gc_PorcDesctoAnt.AppearanceCell.BackColor2 = System.Drawing.Color.Wheat
        Me.gc_PorcDesctoAnt.AppearanceCell.Options.UseBackColor = True
        Me.gc_PorcDesctoAnt.AppearanceCell.Options.UseTextOptions = True
        Me.gc_PorcDesctoAnt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gc_PorcDesctoAnt.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gc_PorcDesctoAnt.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_PorcDesctoAnt.AppearanceHeader.Options.UseFont = True
        Me.gc_PorcDesctoAnt.Caption = "% Descto Ant"
        Me.gc_PorcDesctoAnt.ColumnEdit = Me.Numeric
        Me.gc_PorcDesctoAnt.FieldName = "porcdesctoant"
        Me.gc_PorcDesctoAnt.Name = "gc_PorcDesctoAnt"
        Me.gc_PorcDesctoAnt.Visible = True
        Me.gc_PorcDesctoAnt.VisibleIndex = 31
        '
        'gc_PorcRegAnt
        '
        Me.gc_PorcRegAnt.AppearanceCell.BackColor = System.Drawing.Color.Wheat
        Me.gc_PorcRegAnt.AppearanceCell.BackColor2 = System.Drawing.Color.Wheat
        Me.gc_PorcRegAnt.AppearanceCell.Options.UseBackColor = True
        Me.gc_PorcRegAnt.AppearanceCell.Options.UseTextOptions = True
        Me.gc_PorcRegAnt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gc_PorcRegAnt.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gc_PorcRegAnt.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_PorcRegAnt.AppearanceHeader.Options.UseFont = True
        Me.gc_PorcRegAnt.Caption = "% Regalo Ant"
        Me.gc_PorcRegAnt.ColumnEdit = Me.Numeric
        Me.gc_PorcRegAnt.FieldName = "porcregaloant"
        Me.gc_PorcRegAnt.Name = "gc_PorcRegAnt"
        Me.gc_PorcRegAnt.Visible = True
        Me.gc_PorcRegAnt.VisibleIndex = 32
        '
        'gc_CostoAnt
        '
        Me.gc_CostoAnt.AppearanceCell.BackColor = System.Drawing.Color.White
        Me.gc_CostoAnt.AppearanceCell.BackColor2 = System.Drawing.Color.White
        Me.gc_CostoAnt.AppearanceCell.Options.UseBackColor = True
        Me.gc_CostoAnt.AppearanceCell.Options.UseTextOptions = True
        Me.gc_CostoAnt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gc_CostoAnt.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gc_CostoAnt.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_CostoAnt.AppearanceHeader.Options.UseFont = True
        Me.gc_CostoAnt.Caption = "Costo Ant"
        Me.gc_CostoAnt.ColumnEdit = Me.rp_Importe
        Me.gc_CostoAnt.FieldName = "costoant"
        Me.gc_CostoAnt.Name = "gc_CostoAnt"
        Me.gc_CostoAnt.Visible = True
        Me.gc_CostoAnt.VisibleIndex = 33
        '
        'gc_VentaAnt
        '
        Me.gc_VentaAnt.AppearanceCell.BackColor = System.Drawing.Color.White
        Me.gc_VentaAnt.AppearanceCell.BackColor2 = System.Drawing.Color.White
        Me.gc_VentaAnt.AppearanceCell.Options.UseBackColor = True
        Me.gc_VentaAnt.AppearanceCell.Options.UseTextOptions = True
        Me.gc_VentaAnt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gc_VentaAnt.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gc_VentaAnt.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_VentaAnt.AppearanceHeader.Options.UseFont = True
        Me.gc_VentaAnt.Caption = "$ Venta Ant"
        Me.gc_VentaAnt.ColumnEdit = Me.rp_Importe
        Me.gc_VentaAnt.FieldName = "ventaant"
        Me.gc_VentaAnt.Name = "gc_VentaAnt"
        Me.gc_VentaAnt.Visible = True
        Me.gc_VentaAnt.VisibleIndex = 34
        '
        'gc_MargenAnt
        '
        Me.gc_MargenAnt.AppearanceCell.BackColor = System.Drawing.Color.White
        Me.gc_MargenAnt.AppearanceCell.BackColor2 = System.Drawing.Color.White
        Me.gc_MargenAnt.AppearanceCell.Options.UseBackColor = True
        Me.gc_MargenAnt.AppearanceCell.Options.UseTextOptions = True
        Me.gc_MargenAnt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gc_MargenAnt.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gc_MargenAnt.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_MargenAnt.AppearanceHeader.Options.UseFont = True
        Me.gc_MargenAnt.Caption = "$ Margen Ant"
        Me.gc_MargenAnt.ColumnEdit = Me.rp_Importe
        Me.gc_MargenAnt.FieldName = "margenant"
        Me.gc_MargenAnt.Name = "gc_MargenAnt"
        Me.gc_MargenAnt.Visible = True
        Me.gc_MargenAnt.VisibleIndex = 35
        '
        'gc_PorcMargenAnt
        '
        Me.gc_PorcMargenAnt.AppearanceCell.BackColor = System.Drawing.Color.White
        Me.gc_PorcMargenAnt.AppearanceCell.BackColor2 = System.Drawing.Color.White
        Me.gc_PorcMargenAnt.AppearanceCell.Options.UseBackColor = True
        Me.gc_PorcMargenAnt.AppearanceCell.Options.UseTextOptions = True
        Me.gc_PorcMargenAnt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gc_PorcMargenAnt.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gc_PorcMargenAnt.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_PorcMargenAnt.AppearanceHeader.Options.UseFont = True
        Me.gc_PorcMargenAnt.Caption = "% Margen Ant"
        Me.gc_PorcMargenAnt.ColumnEdit = Me.Numeric
        Me.gc_PorcMargenAnt.FieldName = "porcMargenAnt"
        Me.gc_PorcMargenAnt.Name = "gc_PorcMargenAnt"
        Me.gc_PorcMargenAnt.Visible = True
        Me.gc_PorcMargenAnt.VisibleIndex = 36
        '
        'gc_PorcImpPartAnt
        '
        Me.gc_PorcImpPartAnt.AppearanceCell.BackColor = System.Drawing.Color.White
        Me.gc_PorcImpPartAnt.AppearanceCell.BackColor2 = System.Drawing.Color.White
        Me.gc_PorcImpPartAnt.AppearanceCell.Options.UseBackColor = True
        Me.gc_PorcImpPartAnt.AppearanceCell.Options.UseTextOptions = True
        Me.gc_PorcImpPartAnt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gc_PorcImpPartAnt.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gc_PorcImpPartAnt.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_PorcImpPartAnt.AppearanceHeader.Options.UseFont = True
        Me.gc_PorcImpPartAnt.Caption = "% Part Vta Ant"
        Me.gc_PorcImpPartAnt.ColumnEdit = Me.Numeric
        Me.gc_PorcImpPartAnt.FieldName = "porcimppartant"
        Me.gc_PorcImpPartAnt.Name = "gc_PorcImpPartAnt"
        Me.gc_PorcImpPartAnt.Visible = True
        Me.gc_PorcImpPartAnt.VisibleIndex = 37
        '
        'gc_ImpNormalAnt
        '
        Me.gc_ImpNormalAnt.AppearanceCell.BackColor = System.Drawing.Color.White
        Me.gc_ImpNormalAnt.AppearanceCell.BackColor2 = System.Drawing.Color.White
        Me.gc_ImpNormalAnt.AppearanceCell.Options.UseBackColor = True
        Me.gc_ImpNormalAnt.AppearanceCell.Options.UseTextOptions = True
        Me.gc_ImpNormalAnt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gc_ImpNormalAnt.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gc_ImpNormalAnt.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_ImpNormalAnt.AppearanceHeader.Options.UseFont = True
        Me.gc_ImpNormalAnt.Caption = "$ Vta Normal Ant"
        Me.gc_ImpNormalAnt.ColumnEdit = Me.rp_Importe
        Me.gc_ImpNormalAnt.FieldName = "impnormalnetoant"
        Me.gc_ImpNormalAnt.Name = "gc_ImpNormalAnt"
        Me.gc_ImpNormalAnt.Visible = True
        Me.gc_ImpNormalAnt.VisibleIndex = 38
        '
        'gc_ImpDesctoAnt
        '
        Me.gc_ImpDesctoAnt.AppearanceCell.BackColor = System.Drawing.Color.White
        Me.gc_ImpDesctoAnt.AppearanceCell.BackColor2 = System.Drawing.Color.White
        Me.gc_ImpDesctoAnt.AppearanceCell.Options.UseBackColor = True
        Me.gc_ImpDesctoAnt.AppearanceCell.Options.UseTextOptions = True
        Me.gc_ImpDesctoAnt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gc_ImpDesctoAnt.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gc_ImpDesctoAnt.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_ImpDesctoAnt.AppearanceHeader.Options.UseFont = True
        Me.gc_ImpDesctoAnt.Caption = "$ Vta Descto Ant"
        Me.gc_ImpDesctoAnt.ColumnEdit = Me.rp_Importe
        Me.gc_ImpDesctoAnt.FieldName = "impdesctonetoant"
        Me.gc_ImpDesctoAnt.Name = "gc_ImpDesctoAnt"
        Me.gc_ImpDesctoAnt.Visible = True
        Me.gc_ImpDesctoAnt.VisibleIndex = 39
        '
        'gc_ImpRegAnt
        '
        Me.gc_ImpRegAnt.AppearanceCell.BackColor = System.Drawing.Color.White
        Me.gc_ImpRegAnt.AppearanceCell.BackColor2 = System.Drawing.Color.White
        Me.gc_ImpRegAnt.AppearanceCell.Options.UseBackColor = True
        Me.gc_ImpRegAnt.AppearanceCell.Options.UseTextOptions = True
        Me.gc_ImpRegAnt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gc_ImpRegAnt.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gc_ImpRegAnt.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_ImpRegAnt.AppearanceHeader.Options.UseFont = True
        Me.gc_ImpRegAnt.Caption = "$ Vta Regalo Ant"
        Me.gc_ImpRegAnt.ColumnEdit = Me.rp_Importe
        Me.gc_ImpRegAnt.FieldName = "impregnetoant"
        Me.gc_ImpRegAnt.Name = "gc_ImpRegAnt"
        Me.gc_ImpRegAnt.Visible = True
        Me.gc_ImpRegAnt.VisibleIndex = 40
        '
        'gc_PorcImpNormalAnt
        '
        Me.gc_PorcImpNormalAnt.AppearanceCell.BackColor = System.Drawing.Color.White
        Me.gc_PorcImpNormalAnt.AppearanceCell.BackColor2 = System.Drawing.Color.White
        Me.gc_PorcImpNormalAnt.AppearanceCell.Options.UseBackColor = True
        Me.gc_PorcImpNormalAnt.AppearanceCell.Options.UseTextOptions = True
        Me.gc_PorcImpNormalAnt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gc_PorcImpNormalAnt.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gc_PorcImpNormalAnt.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_PorcImpNormalAnt.AppearanceHeader.Options.UseFont = True
        Me.gc_PorcImpNormalAnt.Caption = "% Normal Ant"
        Me.gc_PorcImpNormalAnt.ColumnEdit = Me.Numeric
        Me.gc_PorcImpNormalAnt.FieldName = "porcimpnormalant"
        Me.gc_PorcImpNormalAnt.Name = "gc_PorcImpNormalAnt"
        Me.gc_PorcImpNormalAnt.Visible = True
        Me.gc_PorcImpNormalAnt.VisibleIndex = 41
        '
        'gc_PorcImpDesctoAnt
        '
        Me.gc_PorcImpDesctoAnt.AppearanceCell.BackColor = System.Drawing.Color.White
        Me.gc_PorcImpDesctoAnt.AppearanceCell.BackColor2 = System.Drawing.Color.White
        Me.gc_PorcImpDesctoAnt.AppearanceCell.Options.UseBackColor = True
        Me.gc_PorcImpDesctoAnt.AppearanceCell.Options.UseTextOptions = True
        Me.gc_PorcImpDesctoAnt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gc_PorcImpDesctoAnt.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gc_PorcImpDesctoAnt.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_PorcImpDesctoAnt.AppearanceHeader.Options.UseFont = True
        Me.gc_PorcImpDesctoAnt.Caption = "% Descto Ant"
        Me.gc_PorcImpDesctoAnt.ColumnEdit = Me.Numeric
        Me.gc_PorcImpDesctoAnt.FieldName = "porcimpdesctoant"
        Me.gc_PorcImpDesctoAnt.Name = "gc_PorcImpDesctoAnt"
        Me.gc_PorcImpDesctoAnt.Visible = True
        Me.gc_PorcImpDesctoAnt.VisibleIndex = 42
        '
        'gc_PorcImpRegAnt
        '
        Me.gc_PorcImpRegAnt.AppearanceCell.BackColor = System.Drawing.Color.White
        Me.gc_PorcImpRegAnt.AppearanceCell.BackColor2 = System.Drawing.Color.White
        Me.gc_PorcImpRegAnt.AppearanceCell.Options.UseBackColor = True
        Me.gc_PorcImpRegAnt.AppearanceCell.Options.UseTextOptions = True
        Me.gc_PorcImpRegAnt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gc_PorcImpRegAnt.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gc_PorcImpRegAnt.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_PorcImpRegAnt.AppearanceHeader.Options.UseFont = True
        Me.gc_PorcImpRegAnt.Caption = "% Regalo Ant"
        Me.gc_PorcImpRegAnt.ColumnEdit = Me.Numeric
        Me.gc_PorcImpRegAnt.FieldName = "porcimpregant"
        Me.gc_PorcImpRegAnt.Name = "gc_PorcImpRegAnt"
        Me.gc_PorcImpRegAnt.Visible = True
        Me.gc_PorcImpRegAnt.VisibleIndex = 43
        '
        'gc_PorcPares
        '
        Me.gc_PorcPares.AppearanceCell.BackColor = System.Drawing.Color.PowderBlue
        Me.gc_PorcPares.AppearanceCell.BackColor2 = System.Drawing.Color.PowderBlue
        Me.gc_PorcPares.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_PorcPares.AppearanceCell.Options.UseBackColor = True
        Me.gc_PorcPares.AppearanceCell.Options.UseFont = True
        Me.gc_PorcPares.AppearanceCell.Options.UseTextOptions = True
        Me.gc_PorcPares.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gc_PorcPares.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gc_PorcPares.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_PorcPares.AppearanceHeader.Options.UseFont = True
        Me.gc_PorcPares.Caption = "% Inc Pares"
        Me.gc_PorcPares.ColumnEdit = Me.Numeric
        Me.gc_PorcPares.FieldName = "porcpares"
        Me.gc_PorcPares.Name = "gc_PorcPares"
        Me.gc_PorcPares.Visible = True
        Me.gc_PorcPares.VisibleIndex = 44
        '
        'gc_PorcImporte
        '
        Me.gc_PorcImporte.AppearanceCell.BackColor = System.Drawing.Color.MediumAquamarine
        Me.gc_PorcImporte.AppearanceCell.BackColor2 = System.Drawing.Color.MediumAquamarine
        Me.gc_PorcImporte.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_PorcImporte.AppearanceCell.Options.UseBackColor = True
        Me.gc_PorcImporte.AppearanceCell.Options.UseFont = True
        Me.gc_PorcImporte.AppearanceCell.Options.UseTextOptions = True
        Me.gc_PorcImporte.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gc_PorcImporte.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.gc_PorcImporte.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_PorcImporte.AppearanceHeader.Options.UseFont = True
        Me.gc_PorcImporte.Caption = "% Inc Importe"
        Me.gc_PorcImporte.ColumnEdit = Me.Numeric
        Me.gc_PorcImporte.FieldName = "porcimporte"
        Me.gc_PorcImporte.Name = "gc_PorcImporte"
        Me.gc_PorcImporte.Visible = True
        Me.gc_PorcImporte.VisibleIndex = 45
        '
        'ImpReg
        '
        Me.ImpReg.Caption = "INV.PROM.(COSTO)"
        Me.ImpReg.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ImpReg.Name = "ImpReg"
        Me.ImpReg.Visible = True
        Me.ImpReg.VisibleIndex = 46
        '
        'frmPpalRotacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(719, 432)
        Me.Controls.Add(Me.gc_Reporte)
        Me.Controls.Add(Me.PBox)
        Me.Controls.Add(Me.PanelControl1)
        Me.KeyPreview = True
        Me.Name = "frmPpalRotacion"
        Me.Text = "Rotación...."
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.chk_SucVenta.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chk_Miles.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gb_AñoAnt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_AñoAnt.ResumeLayout(False)
        CType(Me.chk_DiaMes.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chk_DiaSemana.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gc_Reporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_Reporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rp_Importe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Numeric, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents gb_AñoAnt As DevExpress.XtraEditors.GroupControl
    Friend WithEvents chk_DiaMes As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chk_DiaSemana As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents btn_Salir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_Filtros As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_Regresar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_Excel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chk_Miles As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents sfdRuta As SaveFileDialog
    Friend WithEvents lbl_Texto As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbl_TextoFecha As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PBox As PictureBox
    Friend WithEvents chk_SucVenta As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents gc_Reporte As DevExpress.XtraGrid.GridControl
    Friend WithEvents dgv_Reporte As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gc_Renglon As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_IdEstructura As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_Estructura As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_Estilo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_DescripArt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_CtdNeta As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents rp_Importe As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents gc_PorcPart As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Numeric As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents gc_Existencia As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_CtdNormal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_CtdDescto As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_CtdRegalo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_PorcNormal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_PorcDescto As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_PorcRegalo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_Costo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_Venta As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_Margen As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_PorcMargen As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_PorcImpPart As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_ImpNormal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_ImpDescto As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_ImpReg As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_PorcImpNormal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_PorcImpDescto As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_PorcImpReg As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_CtdNetaAnt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_PorcPartAnt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_CtdNormalAnt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_CtdDesctoAnt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_CtdRegaloAnt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_PorcNormalAnt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_PorcDesctoAnt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_PorcRegAnt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_CostoAnt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_VentaAnt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_MargenAnt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_PorcMargenAnt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_PorcImpPartAnt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_ImpNormalAnt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_ImpDesctoAnt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_ImpRegAnt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_PorcImpNormalAnt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_PorcImpDesctoAnt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_PorcImpRegAnt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_PorcPares As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_PorcImporte As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ImpReg As DevExpress.XtraGrid.Columns.GridColumn
End Class
