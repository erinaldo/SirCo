<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPpalMuestras
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPpalMuestras))
        Me.Pnl_Principal = New System.Windows.Forms.Panel()
        Me.Btn_Aceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_NuevoF = New System.Windows.Forms.Button()
        Me.PBox1 = New DevExpress.XtraEditors.PictureEdit()
        Me.Txt_Vendedor = New System.Windows.Forms.TextBox()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_Raz_Social = New System.Windows.Forms.TextBox()
        Me.Txt_Remision = New System.Windows.Forms.TextBox()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_Dscto = New System.Windows.Forms.TextBox()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_Plazo = New System.Windows.Forms.TextBox()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_Marca = New System.Windows.Forms.TextBox()
        Me.Txt_DescripMarca = New System.Windows.Forms.TextBox()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.MuestrasdetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MuestrasDetDataSet = New SIRCO.MuestrasDetDataSet()
        Me.MuestrasdetTableAdapter = New SIRCO.MuestrasDetDataSetTableAdapters.muestrasdetTableAdapter()
        Me.GridControl3 = New DevExpress.XtraGrid.GridControl()
        Me.DSMuestrasDetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSMuestrasDet = New SIRCO.DSMuestrasDet()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colmarca = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colestilof = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coldescrip = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coli = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Cbo_I = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.colmedini = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Cbo_MedIni = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.colmedfin = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Cbo_MedFin = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.colpreciolista = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcosto = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colprecio = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colmargen = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colimagen = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Pbox = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit()
        Me.Txt_MedIni = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.Pnl_Principal.SuspendLayout()
        CType(Me.PBox1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MuestrasdetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MuestrasDetDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSMuestrasDetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSMuestrasDet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cbo_I, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cbo_MedIni, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cbo_MedFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pbox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_MedIni, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pnl_Principal
        '
        Me.Pnl_Principal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Principal.Controls.Add(Me.Btn_Aceptar)
        Me.Pnl_Principal.Controls.Add(Me.Btn_NuevoF)
        Me.Pnl_Principal.Controls.Add(Me.PBox1)
        Me.Pnl_Principal.Controls.Add(Me.Txt_Vendedor)
        Me.Pnl_Principal.Controls.Add(Me.LabelControl6)
        Me.Pnl_Principal.Controls.Add(Me.LabelControl5)
        Me.Pnl_Principal.Controls.Add(Me.Txt_Raz_Social)
        Me.Pnl_Principal.Controls.Add(Me.Txt_Remision)
        Me.Pnl_Principal.Controls.Add(Me.LabelControl4)
        Me.Pnl_Principal.Controls.Add(Me.Txt_Dscto)
        Me.Pnl_Principal.Controls.Add(Me.LabelControl3)
        Me.Pnl_Principal.Controls.Add(Me.Txt_Plazo)
        Me.Pnl_Principal.Controls.Add(Me.LabelControl1)
        Me.Pnl_Principal.Controls.Add(Me.Txt_Marca)
        Me.Pnl_Principal.Controls.Add(Me.Txt_DescripMarca)
        Me.Pnl_Principal.Controls.Add(Me.LabelControl2)
        Me.Pnl_Principal.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pnl_Principal.Location = New System.Drawing.Point(0, 0)
        Me.Pnl_Principal.Name = "Pnl_Principal"
        Me.Pnl_Principal.Size = New System.Drawing.Size(974, 122)
        Me.Pnl_Principal.TabIndex = 0
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Aceptar.Appearance.Options.UseFont = True
        Me.Btn_Aceptar.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.gnome_emblem_photos
        Me.Btn_Aceptar.Location = New System.Drawing.Point(13, 70)
        Me.Btn_Aceptar.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(154, 45)
        Me.Btn_Aceptar.TabIndex = 8
        Me.Btn_Aceptar.Text = "&Generar Muestrario"
        Me.Btn_Aceptar.ToolTip = "Generar el registro de la Muestra"
        '
        'Btn_NuevoF
        '
        Me.Btn_NuevoF.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_NuevoF.Image = Global.SIRCO.My.Resources.Resources.new_20doc
        Me.Btn_NuevoF.Location = New System.Drawing.Point(822, 28)
        Me.Btn_NuevoF.Name = "Btn_NuevoF"
        Me.Btn_NuevoF.Size = New System.Drawing.Size(51, 47)
        Me.Btn_NuevoF.TabIndex = 7
        Me.Btn_NuevoF.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_NuevoF.UseVisualStyleBackColor = True
        '
        'PBox1
        '
        Me.PBox1.EditValue = Global.SIRCO.My.Resources.Resources.sirco1_02_01
        Me.PBox1.Location = New System.Drawing.Point(879, 8)
        Me.PBox1.Name = "PBox1"
        Me.PBox1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.PBox1.Properties.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.PBox1.Properties.LookAndFeel.UseWindowsXPTheme = True
        Me.PBox1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PBox1.Size = New System.Drawing.Size(88, 67)
        Me.PBox1.TabIndex = 218
        '
        'Txt_Vendedor
        '
        Me.Txt_Vendedor.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Vendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Vendedor.Location = New System.Drawing.Point(458, 42)
        Me.Txt_Vendedor.MaxLength = 150
        Me.Txt_Vendedor.Name = "Txt_Vendedor"
        Me.Txt_Vendedor.Size = New System.Drawing.Size(328, 21)
        Me.Txt_Vendedor.TabIndex = 6
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(384, 47)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl6.TabIndex = 216
        Me.LabelControl6.Text = "Vendedor"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(384, 13)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(60, 13)
        Me.LabelControl5.TabIndex = 215
        Me.LabelControl5.Text = "Razón Social"
        '
        'Txt_Raz_Social
        '
        Me.Txt_Raz_Social.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Raz_Social.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Raz_Social.Location = New System.Drawing.Point(458, 8)
        Me.Txt_Raz_Social.MaxLength = 150
        Me.Txt_Raz_Social.Name = "Txt_Raz_Social"
        Me.Txt_Raz_Social.Size = New System.Drawing.Size(328, 21)
        Me.Txt_Raz_Social.TabIndex = 2
        '
        'Txt_Remision
        '
        Me.Txt_Remision.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Remision.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Remision.Location = New System.Drawing.Point(272, 40)
        Me.Txt_Remision.MaxLength = 3
        Me.Txt_Remision.Name = "Txt_Remision"
        Me.Txt_Remision.Size = New System.Drawing.Size(44, 21)
        Me.Txt_Remision.TabIndex = 5
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(210, 47)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(56, 13)
        Me.LabelControl4.TabIndex = 212
        Me.LabelControl4.Text = "% Remisión"
        '
        'Txt_Dscto
        '
        Me.Txt_Dscto.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Dscto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Dscto.Location = New System.Drawing.Point(160, 42)
        Me.Txt_Dscto.MaxLength = 3
        Me.Txt_Dscto.Name = "Txt_Dscto"
        Me.Txt_Dscto.Size = New System.Drawing.Size(44, 21)
        Me.Txt_Dscto.TabIndex = 4
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(107, 47)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(47, 13)
        Me.LabelControl3.TabIndex = 210
        Me.LabelControl3.Text = "% Descto"
        '
        'Txt_Plazo
        '
        Me.Txt_Plazo.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Plazo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Plazo.Location = New System.Drawing.Point(57, 42)
        Me.Txt_Plazo.MaxLength = 3
        Me.Txt_Plazo.Name = "Txt_Plazo"
        Me.Txt_Plazo.Size = New System.Drawing.Size(44, 21)
        Me.Txt_Plazo.TabIndex = 3
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(13, 47)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(25, 13)
        Me.LabelControl1.TabIndex = 207
        Me.LabelControl1.Text = "Plazo"
        '
        'Txt_Marca
        '
        Me.Txt_Marca.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Marca.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Marca.Location = New System.Drawing.Point(57, 12)
        Me.Txt_Marca.MaxLength = 3
        Me.Txt_Marca.Name = "Txt_Marca"
        Me.Txt_Marca.Size = New System.Drawing.Size(44, 21)
        Me.Txt_Marca.TabIndex = 0
        '
        'Txt_DescripMarca
        '
        Me.Txt_DescripMarca.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripMarca.Enabled = False
        Me.Txt_DescripMarca.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripMarca.Location = New System.Drawing.Point(107, 12)
        Me.Txt_DescripMarca.Name = "Txt_DescripMarca"
        Me.Txt_DescripMarca.ReadOnly = True
        Me.Txt_DescripMarca.Size = New System.Drawing.Size(209, 21)
        Me.Txt_DescripMarca.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(13, 17)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(29, 13)
        Me.LabelControl2.TabIndex = 204
        Me.LabelControl2.Text = "Marca"
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
        'GridControl3
        '
        Me.GridControl3.DataMember = "muestrasdet"
        Me.GridControl3.DataSource = Me.DSMuestrasDetBindingSource
        Me.GridControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl3.Enabled = False
        Me.GridControl3.Location = New System.Drawing.Point(0, 122)
        Me.GridControl3.MainView = Me.GridView3
        Me.GridControl3.Name = "GridControl3"
        Me.GridControl3.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.Pbox, Me.Txt_MedIni, Me.Cbo_MedFin, Me.Cbo_I, Me.Cbo_MedIni})
        Me.GridControl3.Size = New System.Drawing.Size(974, 253)
        Me.GridControl3.TabIndex = 9
        Me.GridControl3.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
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
        'GridView3
        '
        Me.GridView3.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridView3.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridView3.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GridView3.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colmarca, Me.colestilof, Me.coldescrip, Me.coli, Me.colmedini, Me.colmedfin, Me.colpreciolista, Me.colcosto, Me.colprecio, Me.colmargen, Me.colimagen})
        Me.GridView3.GridControl = Me.GridControl3
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsView.ColumnAutoWidth = False
        Me.GridView3.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridView3.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.GridView3.RowHeight = 100
        '
        'colmarca
        '
        Me.colmarca.AppearanceCell.Options.UseTextOptions = True
        Me.colmarca.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colmarca.Caption = "Marca"
        Me.colmarca.FieldName = "marca"
        Me.colmarca.Name = "colmarca"
        Me.colmarca.OptionsEditForm.StartNewRow = True
        Me.colmarca.Width = 71
        '
        'colestilof
        '
        Me.colestilof.Caption = "EstiloF"
        Me.colestilof.FieldName = "estilof"
        Me.colestilof.Name = "colestilof"
        Me.colestilof.Visible = True
        Me.colestilof.VisibleIndex = 0
        '
        'coldescrip
        '
        Me.coldescrip.Caption = "Descripción"
        Me.coldescrip.FieldName = "descrip"
        Me.coldescrip.Name = "coldescrip"
        Me.coldescrip.Visible = True
        Me.coldescrip.VisibleIndex = 1
        Me.coldescrip.Width = 215
        '
        'coli
        '
        Me.coli.AppearanceCell.Options.UseTextOptions = True
        Me.coli.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.coli.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.coli.Caption = "I"
        Me.coli.ColumnEdit = Me.Cbo_I
        Me.coli.FieldName = "i"
        Me.coli.Name = "coli"
        Me.coli.Visible = True
        Me.coli.VisibleIndex = 2
        Me.coli.Width = 50
        '
        'Cbo_I
        '
        Me.Cbo_I.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.Cbo_I.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Cbo_I.Items.AddRange(New Object() {"-", "1"})
        Me.Cbo_I.MaxLength = 1
        Me.Cbo_I.Name = "Cbo_I"
        Me.Cbo_I.Sorted = True
        Me.Cbo_I.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'colmedini
        '
        Me.colmedini.AppearanceCell.Options.UseTextOptions = True
        Me.colmedini.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colmedini.Caption = "Med Ini"
        Me.colmedini.ColumnEdit = Me.Cbo_MedIni
        Me.colmedini.FieldName = "medini"
        Me.colmedini.Name = "colmedini"
        Me.colmedini.Visible = True
        Me.colmedini.VisibleIndex = 3
        Me.colmedini.Width = 70
        '
        'Cbo_MedIni
        '
        Me.Cbo_MedIni.AutoHeight = False
        Me.Cbo_MedIni.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.Cbo_MedIni.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Cbo_MedIni.Items.AddRange(New Object() {"01", "01-", "09", "09-", "10", "10-", "11", "11-", "12", "12-", "13", "13-", "14", "14-", "15", "15-", "16", "16-", "17", "17-", "18", "18-", "19", "19-", "20", "20-", "21", "21-", "22", "22-", "23", "23-", "24", "24-", "25", "25-", "26", "26-", "27", "27-", "28", "28-", "29", "29-", "30", "30-", "31", "31-"})
        Me.Cbo_MedIni.MaxLength = 3
        Me.Cbo_MedIni.Name = "Cbo_MedIni"
        Me.Cbo_MedIni.Sorted = True
        Me.Cbo_MedIni.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'colmedfin
        '
        Me.colmedfin.AppearanceCell.Options.UseTextOptions = True
        Me.colmedfin.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colmedfin.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.colmedfin.Caption = "Med Fin"
        Me.colmedfin.ColumnEdit = Me.Cbo_MedFin
        Me.colmedfin.FieldName = "medfin"
        Me.colmedfin.Name = "colmedfin"
        Me.colmedfin.Visible = True
        Me.colmedfin.VisibleIndex = 4
        Me.colmedfin.Width = 70
        '
        'Cbo_MedFin
        '
        Me.Cbo_MedFin.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.Cbo_MedFin.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Cbo_MedFin.Items.AddRange(New Object() {"01", "01-", "09", "09-", "10", "10-", "11", "11-", "12", "12-", "13", "13-", "14", "14-", "15", "15-", "16", "16-", "17", "17-", "18", "18-", "19", "19-", "20", "20-", "21", "21-", "22", "22-", "23", "23-", "24", "24-", "25", "25-", "26", "26-", "27", "27-", "28", "28-", "29", "29-", "30", "30-", "31", "31-"})
        Me.Cbo_MedFin.MaxLength = 3
        Me.Cbo_MedFin.Name = "Cbo_MedFin"
        Me.Cbo_MedFin.Sorted = True
        Me.Cbo_MedFin.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'colpreciolista
        '
        Me.colpreciolista.AppearanceCell.Options.UseTextOptions = True
        Me.colpreciolista.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colpreciolista.Caption = "Precio Lista"
        Me.colpreciolista.DisplayFormat.FormatString = "#,###.##"
        Me.colpreciolista.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colpreciolista.FieldName = "preciolista"
        Me.colpreciolista.Name = "colpreciolista"
        Me.colpreciolista.Visible = True
        Me.colpreciolista.VisibleIndex = 5
        '
        'colcosto
        '
        Me.colcosto.Caption = "Costo"
        Me.colcosto.DisplayFormat.FormatString = "#,###.##"
        Me.colcosto.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colcosto.FieldName = "costo"
        Me.colcosto.Name = "colcosto"
        Me.colcosto.OptionsColumn.ReadOnly = True
        Me.colcosto.Visible = True
        Me.colcosto.VisibleIndex = 6
        '
        'colprecio
        '
        Me.colprecio.AppearanceCell.Options.UseTextOptions = True
        Me.colprecio.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colprecio.Caption = "Precio"
        Me.colprecio.DisplayFormat.FormatString = "#,###.##"
        Me.colprecio.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colprecio.FieldName = "precio"
        Me.colprecio.Name = "colprecio"
        Me.colprecio.Visible = True
        Me.colprecio.VisibleIndex = 7
        '
        'colmargen
        '
        Me.colmargen.AppearanceCell.Options.UseTextOptions = True
        Me.colmargen.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colmargen.Caption = "% Margen"
        Me.colmargen.DisplayFormat.FormatString = "##.#0"
        Me.colmargen.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colmargen.FieldName = "margen"
        Me.colmargen.Name = "colmargen"
        Me.colmargen.OptionsColumn.ReadOnly = True
        Me.colmargen.Visible = True
        Me.colmargen.VisibleIndex = 8
        Me.colmargen.Width = 63
        '
        'colimagen
        '
        Me.colimagen.Caption = "Imagen"
        Me.colimagen.ColumnEdit = Me.Pbox
        Me.colimagen.FieldName = "imagen"
        Me.colimagen.MinWidth = 100
        Me.colimagen.Name = "colimagen"
        Me.colimagen.Visible = True
        Me.colimagen.VisibleIndex = 9
        Me.colimagen.Width = 100
        '
        'Pbox
        '
        Me.Pbox.LookAndFeel.SkinName = "Office 2013"
        Me.Pbox.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.Pbox.Name = "Pbox"
        Me.Pbox.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        '
        'Txt_MedIni
        '
        Me.Txt_MedIni.AutoHeight = False
        Me.Txt_MedIni.Mask.EditMask = "99"
        Me.Txt_MedIni.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Custom
        Me.Txt_MedIni.MaxLength = 3
        Me.Txt_MedIni.Name = "Txt_MedIni"
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'frmPpalMuestras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(974, 375)
        Me.Controls.Add(Me.GridControl3)
        Me.Controls.Add(Me.Pnl_Principal)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmPpalMuestras"
        Me.Text = "Generar Muestrario"
        Me.Pnl_Principal.ResumeLayout(False)
        Me.Pnl_Principal.PerformLayout()
        CType(Me.PBox1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MuestrasdetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MuestrasDetDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSMuestrasDetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSMuestrasDet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cbo_I, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cbo_MedIni, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cbo_MedFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pbox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_MedIni, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Pnl_Principal As Panel
    Friend WithEvents MuestrasDetDataSet As MuestrasDetDataSet
    Friend WithEvents MuestrasdetBindingSource As BindingSource
    Friend WithEvents MuestrasdetTableAdapter As MuestrasDetDataSetTableAdapters.muestrasdetTableAdapter
    Friend WithEvents GridControl3 As DevExpress.XtraGrid.GridControl
    Friend WithEvents DSMuestrasDetBindingSource As BindingSource
    Friend WithEvents DSMuestrasDet As DSMuestrasDet
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colmarca As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colestilof As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coldescrip As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coli As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colmedini As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colmedfin As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colpreciolista As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcosto As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colprecio As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colmargen As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colimagen As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Pbox As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
    Friend WithEvents Txt_Plazo As TextBox
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_Marca As TextBox
    Friend WithEvents Txt_DescripMarca As TextBox
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_Vendedor As TextBox
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_Raz_Social As TextBox
    Friend WithEvents Txt_Remision As TextBox
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_Dscto As TextBox
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Btn_Aceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_NuevoF As Button
    Friend WithEvents PBox1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents OpenFileDialog As OpenFileDialog
    Friend WithEvents Txt_MedIni As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents Cbo_MedFin As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents Cbo_I As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents Cbo_MedIni As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
End Class
