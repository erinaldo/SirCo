<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCatalogoVisitaVencido
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
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCatalogoVisitaVencido))
        Me.Pnl_Datos = New DevExpress.XtraEditors.PanelControl()
        Me.Btn_CatalogoDistrib = New DevExpress.XtraEditors.SimpleButton()
        Me.Lbl_Leyenda = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.Txt_Distribuidor = New DevExpress.XtraEditors.TextEdit()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.GridControl3 = New DevExpress.XtraGrid.GridControl()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.fecha = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.monto = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.tipo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Cbo_Tipo = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.Pbox = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit()
        Me.Txt_MedIni = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.Cbo_MedFin = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.Cbo_I = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.Cbo_MedIni = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl17 = New DevExpress.XtraEditors.LabelControl()
        Me.Dt_Promesado = New DevExpress.XtraEditors.DateEdit()
        Me.Mem_Comentarios = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl16 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_Adeudo = New DevExpress.XtraEditors.TextEdit()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_Guardar = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.Pnl_Datos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_Datos.SuspendLayout()
        CType(Me.Txt_Distribuidor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cbo_Tipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pbox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_MedIni, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cbo_MedFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cbo_I, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cbo_MedIni, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dt_Promesado.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dt_Promesado.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Mem_Comentarios.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_Adeudo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pnl_Datos
        '
        Me.Pnl_Datos.Controls.Add(Me.Btn_CatalogoDistrib)
        Me.Pnl_Datos.Controls.Add(Me.Lbl_Leyenda)
        Me.Pnl_Datos.Controls.Add(Me.LabelControl1)
        Me.Pnl_Datos.Controls.Add(Me.SimpleButton3)
        Me.Pnl_Datos.Controls.Add(Me.Txt_Distribuidor)
        Me.Pnl_Datos.Location = New System.Drawing.Point(2, 5)
        Me.Pnl_Datos.Name = "Pnl_Datos"
        Me.Pnl_Datos.Size = New System.Drawing.Size(831, 122)
        Me.Pnl_Datos.TabIndex = 0
        '
        'Btn_CatalogoDistrib
        '
        Me.Btn_CatalogoDistrib.Image = Global.SIRCO.My.Resources.Resources.send_email_user_alternative
        Me.Btn_CatalogoDistrib.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.Btn_CatalogoDistrib.Location = New System.Drawing.Point(10, 50)
        Me.Btn_CatalogoDistrib.Name = "Btn_CatalogoDistrib"
        Me.Btn_CatalogoDistrib.Size = New System.Drawing.Size(51, 50)
        Me.Btn_CatalogoDistrib.TabIndex = 20
        Me.Btn_CatalogoDistrib.ToolTip = "Actualizar Datos del Distribuidor"
        '
        'Lbl_Leyenda
        '
        Me.Lbl_Leyenda.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Leyenda.Appearance.ForeColor = System.Drawing.Color.Red
        Me.Lbl_Leyenda.Location = New System.Drawing.Point(149, 64)
        Me.Lbl_Leyenda.Name = "Lbl_Leyenda"
        Me.Lbl_Leyenda.Size = New System.Drawing.Size(287, 18)
        Me.Lbl_Leyenda.TabIndex = 19
        Me.Lbl_Leyenda.Text = "No se pudo comunicar con Distribuidor"
        Me.Lbl_Leyenda.Visible = False
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(10, 14)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(54, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Distribuidor"
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Image = Global.SIRCO.My.Resources.Resources.telefono
        Me.SimpleButton3.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.SimpleButton3.Location = New System.Drawing.Point(82, 50)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(51, 50)
        Me.SimpleButton3.TabIndex = 3
        Me.SimpleButton3.ToolTip = "No se localizo"
        '
        'Txt_Distribuidor
        '
        Me.Txt_Distribuidor.Enabled = False
        Me.Txt_Distribuidor.Location = New System.Drawing.Point(82, 11)
        Me.Txt_Distribuidor.Name = "Txt_Distribuidor"
        Me.Txt_Distribuidor.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Distribuidor.Properties.Appearance.Options.UseFont = True
        Me.Txt_Distribuidor.Size = New System.Drawing.Size(233, 20)
        Me.Txt_Distribuidor.TabIndex = 0
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.GridControl3)
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.LabelControl17)
        Me.PanelControl1.Controls.Add(Me.Dt_Promesado)
        Me.PanelControl1.Controls.Add(Me.Mem_Comentarios)
        Me.PanelControl1.Controls.Add(Me.LabelControl16)
        Me.PanelControl1.Controls.Add(Me.Txt_Adeudo)
        Me.PanelControl1.Location = New System.Drawing.Point(2, 133)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(831, 318)
        Me.PanelControl1.TabIndex = 1
        '
        'GridControl3
        '
        Me.GridControl3.DataMember = "muestrasdet"
        Me.GridControl3.Enabled = False
        GridLevelNode1.RelationName = "Level1"
        Me.GridControl3.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GridControl3.Location = New System.Drawing.Point(5, 71)
        Me.GridControl3.MainView = Me.GridView3
        Me.GridControl3.Name = "GridControl3"
        Me.GridControl3.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.Pbox, Me.Txt_MedIni, Me.Cbo_MedFin, Me.Cbo_I, Me.Cbo_MedIni, Me.Cbo_Tipo})
        Me.GridControl3.Size = New System.Drawing.Size(817, 150)
        Me.GridControl3.TabIndex = 21
        Me.GridControl3.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
        '
        'GridView3
        '
        Me.GridView3.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridView3.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridView3.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GridView3.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.fecha, Me.monto, Me.tipo})
        Me.GridView3.GridControl = Me.GridControl3
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsView.ColumnAutoWidth = False
        Me.GridView3.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridView3.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.GridView3.RowHeight = 100
        '
        'fecha
        '
        Me.fecha.Caption = "Fecha"
        Me.fecha.Name = "fecha"
        Me.fecha.Visible = True
        Me.fecha.VisibleIndex = 0
        Me.fecha.Width = 215
        '
        'monto
        '
        Me.monto.AppearanceCell.Options.UseTextOptions = True
        Me.monto.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.monto.Caption = "Monto"
        Me.monto.DisplayFormat.FormatString = "#,###.##"
        Me.monto.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.monto.Name = "monto"
        Me.monto.Visible = True
        Me.monto.VisibleIndex = 2
        '
        'tipo
        '
        Me.tipo.Caption = "Tipo"
        Me.tipo.ColumnEdit = Me.Cbo_Tipo
        Me.tipo.Name = "tipo"
        Me.tipo.Visible = True
        Me.tipo.VisibleIndex = 1
        '
        'Cbo_Tipo
        '
        Me.Cbo_Tipo.AutoHeight = False
        Me.Cbo_Tipo.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Cbo_Tipo.Items.AddRange(New Object() {"EFECTIVO", "ARTICULO"})
        Me.Cbo_Tipo.Name = "Cbo_Tipo"
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
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(293, 31)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(78, 13)
        Me.LabelControl3.TabIndex = 20
        Me.LabelControl3.Text = "Monto Solicitado"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(10, 5)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(100, 13)
        Me.LabelControl2.TabIndex = 19
        Me.LabelControl2.Text = "Convenio de Pago"
        '
        'LabelControl17
        '
        Me.LabelControl17.Location = New System.Drawing.Point(10, 31)
        Me.LabelControl17.Name = "LabelControl17"
        Me.LabelControl17.Size = New System.Drawing.Size(85, 13)
        Me.LabelControl17.TabIndex = 18
        Me.LabelControl17.Text = "Fecha Promesado"
        '
        'Dt_Promesado
        '
        Me.Dt_Promesado.EditValue = Nothing
        Me.Dt_Promesado.EnterMoveNextControl = True
        Me.Dt_Promesado.Location = New System.Drawing.Point(121, 28)
        Me.Dt_Promesado.Name = "Dt_Promesado"
        Me.Dt_Promesado.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Dt_Promesado.Properties.Appearance.Options.UseFont = True
        Me.Dt_Promesado.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.Dt_Promesado.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Dt_Promesado.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Dt_Promesado.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "d"
        Me.Dt_Promesado.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.Dt_Promesado.Size = New System.Drawing.Size(148, 20)
        Me.Dt_Promesado.TabIndex = 2
        '
        'Mem_Comentarios
        '
        Me.Mem_Comentarios.EnterMoveNextControl = True
        Me.Mem_Comentarios.Location = New System.Drawing.Point(68, 240)
        Me.Mem_Comentarios.Name = "Mem_Comentarios"
        Me.Mem_Comentarios.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Mem_Comentarios.Properties.Appearance.Options.UseFont = True
        Me.Mem_Comentarios.Size = New System.Drawing.Size(739, 73)
        Me.Mem_Comentarios.TabIndex = 1
        '
        'LabelControl16
        '
        Me.LabelControl16.Location = New System.Drawing.Point(2, 242)
        Me.LabelControl16.Name = "LabelControl16"
        Me.LabelControl16.Size = New System.Drawing.Size(60, 13)
        Me.LabelControl16.TabIndex = 15
        Me.LabelControl16.Text = "Comentarios"
        '
        'Txt_Adeudo
        '
        Me.Txt_Adeudo.Enabled = False
        Me.Txt_Adeudo.EnterMoveNextControl = True
        Me.Txt_Adeudo.Location = New System.Drawing.Point(390, 28)
        Me.Txt_Adeudo.Name = "Txt_Adeudo"
        Me.Txt_Adeudo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Adeudo.Properties.Appearance.Options.UseFont = True
        Me.Txt_Adeudo.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Adeudo.Properties.AppearanceDisabled.Options.UseFont = True
        Me.Txt_Adeudo.Properties.DisplayFormat.FormatString = "$##,###,#0.0"
        Me.Txt_Adeudo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.Txt_Adeudo.Size = New System.Drawing.Size(111, 24)
        Me.Txt_Adeudo.TabIndex = 0
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.SimpleButton2)
        Me.PanelControl3.Controls.Add(Me.Btn_Guardar)
        Me.PanelControl3.Location = New System.Drawing.Point(0, 455)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(828, 54)
        Me.PanelControl3.TabIndex = 3
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Image = Global.SIRCO.My.Resources.Resources.cancel1
        Me.SimpleButton2.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.SimpleButton2.Location = New System.Drawing.Point(715, 2)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(51, 50)
        Me.SimpleButton2.TabIndex = 5
        '
        'Btn_Guardar
        '
        Me.Btn_Guardar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_Guardar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.Btn_Guardar.Location = New System.Drawing.Point(772, 2)
        Me.Btn_Guardar.Name = "Btn_Guardar"
        Me.Btn_Guardar.Size = New System.Drawing.Size(51, 50)
        Me.Btn_Guardar.TabIndex = 4
        Me.Btn_Guardar.ToolTip = "Registrar llamada Call Center"
        '
        'frmCatalogoVisitaVencido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(840, 509)
        Me.Controls.Add(Me.PanelControl3)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.Pnl_Datos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCatalogoVisitaVencido"
        Me.Text = "Resultado de Visita Vencido"
        CType(Me.Pnl_Datos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_Datos.ResumeLayout(False)
        Me.Pnl_Datos.PerformLayout()
        CType(Me.Txt_Distribuidor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cbo_Tipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pbox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_MedIni, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cbo_MedFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cbo_I, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cbo_MedIni, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dt_Promesado.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dt_Promesado.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Mem_Comentarios.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_Adeudo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Pnl_Datos As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_Distribuidor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents Txt_Adeudo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Mem_Comentarios As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl16 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl17 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Dt_Promesado As DevExpress.XtraEditors.DateEdit
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_Guardar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Lbl_Leyenda As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Btn_CatalogoDistrib As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridControl3 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents fecha As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Cbo_I As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents Cbo_MedIni As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents Cbo_MedFin As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents monto As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Pbox As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
    Friend WithEvents Txt_MedIni As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents tipo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Cbo_Tipo As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
End Class
