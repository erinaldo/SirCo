<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPpalVentasenLinea
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
        Me.PBox = New System.Windows.Forms.PictureBox()
        Me.Pnl_Botones = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Txt_Serie = New System.Windows.Forms.TextBox()
        Me.Btn_PDF = New System.Windows.Forms.Button()
        Me.Btn_Refrescar = New System.Windows.Forms.Button()
        Me.Btn_Excel = New System.Windows.Forms.Button()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.Usp_SirCoEnLineaDataSet = New SIRCO.usp_SirCoEnLineaDataSet()
        Me.UspPpalVentasENLineaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Usp_PpalVentasENLineaTableAdapter = New SIRCO.usp_SirCoEnLineaDataSetTableAdapters.usp_PpalVentasENLineaTableAdapter()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.DGrid1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colidventa = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colfum = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colidpedido = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcantidad = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colnombrecliente = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcanal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNoTraspaso = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNoVenta = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colmarca = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colestilon = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.medida = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Serie = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colguia_pdf = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.sfdRuta = New System.Windows.Forms.SaveFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_Botones.SuspendLayout()
        CType(Me.Usp_SirCoEnLineaDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UspPpalVentasENLineaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PBox
        '
        Me.PBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PBox.Location = New System.Drawing.Point(330, 210)
        Me.PBox.Name = "PBox"
        Me.PBox.Size = New System.Drawing.Size(193, 162)
        Me.PBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBox.TabIndex = 9
        Me.PBox.TabStop = False
        Me.PBox.Visible = False
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Label7)
        Me.Pnl_Botones.Controls.Add(Me.Txt_Serie)
        Me.Pnl_Botones.Controls.Add(Me.Btn_PDF)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Refrescar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Excel)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Salir)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 394)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(800, 56)
        Me.Pnl_Botones.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(32, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 18)
        Me.Label7.TabIndex = 111
        Me.Label7.Text = "Serie"
        '
        'Txt_Serie
        '
        Me.Txt_Serie.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Txt_Serie.BackColor = System.Drawing.Color.PowderBlue
        Me.Txt_Serie.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Serie.Location = New System.Drawing.Point(85, 13)
        Me.Txt_Serie.MaxLength = 13
        Me.Txt_Serie.Name = "Txt_Serie"
        Me.Txt_Serie.Size = New System.Drawing.Size(174, 29)
        Me.Txt_Serie.TabIndex = 14
        Me.Txt_Serie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Btn_PDF
        '
        Me.Btn_PDF.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_PDF.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_PDF.Image = Global.SIRCO.My.Resources.Resources.pdf
        Me.Btn_PDF.Location = New System.Drawing.Point(592, 0)
        Me.Btn_PDF.Name = "Btn_PDF"
        Me.Btn_PDF.Size = New System.Drawing.Size(51, 52)
        Me.Btn_PDF.TabIndex = 13
        Me.Btn_PDF.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_PDF.UseVisualStyleBackColor = True
        '
        'Btn_Refrescar
        '
        Me.Btn_Refrescar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Refrescar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Refrescar.Image = Global.SIRCO.My.Resources.Resources.database_refresh
        Me.Btn_Refrescar.Location = New System.Drawing.Point(643, 0)
        Me.Btn_Refrescar.Name = "Btn_Refrescar"
        Me.Btn_Refrescar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Refrescar.TabIndex = 12
        Me.Btn_Refrescar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Refrescar.UseVisualStyleBackColor = True
        '
        'Btn_Excel
        '
        Me.Btn_Excel.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Excel.Image = Global.SIRCO.My.Resources.Resources.table_excel
        Me.Btn_Excel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Excel.Location = New System.Drawing.Point(694, 0)
        Me.Btn_Excel.Name = "Btn_Excel"
        Me.Btn_Excel.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Excel.TabIndex = 7
        Me.Btn_Excel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Excel.UseVisualStyleBackColor = True
        '
        'Btn_Salir
        '
        Me.Btn_Salir.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Salir.Image = Global.SIRCO.My.Resources.Resources.door_out
        Me.Btn_Salir.Location = New System.Drawing.Point(745, 0)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Salir.TabIndex = 5
        Me.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Salir.UseVisualStyleBackColor = True
        '
        'Usp_SirCoEnLineaDataSet
        '
        Me.Usp_SirCoEnLineaDataSet.DataSetName = "usp_SirCoEnLineaDataSet"
        Me.Usp_SirCoEnLineaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'UspPpalVentasENLineaBindingSource
        '
        Me.UspPpalVentasENLineaBindingSource.DataMember = "usp_PpalVentasENLinea"
        Me.UspPpalVentasENLineaBindingSource.DataSource = Me.Usp_SirCoEnLineaDataSet
        '
        'Usp_PpalVentasENLineaTableAdapter
        '
        Me.Usp_PpalVentasENLineaTableAdapter.ClearBeforeFill = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Location = New System.Drawing.Point(330, 210)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(193, 162)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'DGrid1
        '
        Me.DGrid1.DataSource = Me.UspPpalVentasENLineaBindingSource
        Me.DGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGrid1.Location = New System.Drawing.Point(0, 0)
        Me.DGrid1.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.DGrid1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.DGrid1.MainView = Me.GridView1
        Me.DGrid1.Name = "DGrid1"
        Me.DGrid1.Size = New System.Drawing.Size(800, 394)
        Me.DGrid1.TabIndex = 11
        Me.DGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Appearance.FooterPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView1.Appearance.FooterPanel.Options.UseFont = True
        Me.GridView1.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView1.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridView1.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colidventa, Me.colfum, Me.colidpedido, Me.colcantidad, Me.colnombrecliente, Me.colcanal, Me.colNoTraspaso, Me.colNoVenta, Me.colmarca, Me.colestilon, Me.medida, Me.Serie, Me.colguia_pdf})
        Me.GridView1.GridControl = Me.DGrid1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.ReadOnly = True
        Me.GridView1.OptionsSelection.MultiSelect = True
        Me.GridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFooter = True
        '
        'colidventa
        '
        Me.colidventa.Caption = "IdVenta"
        Me.colidventa.FieldName = "idventa"
        Me.colidventa.Name = "colidventa"
        '
        'colfum
        '
        Me.colfum.Caption = "Fum"
        Me.colfum.DisplayFormat.FormatString = "G"
        Me.colfum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colfum.FieldName = "fum"
        Me.colfum.Name = "colfum"
        Me.colfum.Visible = True
        Me.colfum.VisibleIndex = 1
        '
        'colidpedido
        '
        Me.colidpedido.Caption = "IdPedido"
        Me.colidpedido.FieldName = "idpedido"
        Me.colidpedido.Name = "colidpedido"
        Me.colidpedido.Visible = True
        Me.colidpedido.VisibleIndex = 2
        '
        'colcantidad
        '
        Me.colcantidad.AppearanceCell.Options.UseTextOptions = True
        Me.colcantidad.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colcantidad.Caption = "Ctd"
        Me.colcantidad.FieldName = "cantidad"
        Me.colcantidad.Name = "colcantidad"
        Me.colcantidad.Visible = True
        Me.colcantidad.VisibleIndex = 3
        '
        'colnombrecliente
        '
        Me.colnombrecliente.Caption = "Nombre Cliente"
        Me.colnombrecliente.FieldName = "nombrecliente"
        Me.colnombrecliente.Name = "colnombrecliente"
        Me.colnombrecliente.Visible = True
        Me.colnombrecliente.VisibleIndex = 4
        '
        'colcanal
        '
        Me.colcanal.Caption = "Canal"
        Me.colcanal.FieldName = "canal"
        Me.colcanal.Name = "colcanal"
        Me.colcanal.Visible = True
        Me.colcanal.VisibleIndex = 5
        '
        'colNoTraspaso
        '
        Me.colNoTraspaso.Caption = "No. Traspaso"
        Me.colNoTraspaso.FieldName = "NoTraspaso"
        Me.colNoTraspaso.Name = "colNoTraspaso"
        Me.colNoTraspaso.Visible = True
        Me.colNoTraspaso.VisibleIndex = 6
        '
        'colNoVenta
        '
        Me.colNoVenta.Caption = "No. Venta"
        Me.colNoVenta.FieldName = "NoVenta"
        Me.colNoVenta.Name = "colNoVenta"
        Me.colNoVenta.Visible = True
        Me.colNoVenta.VisibleIndex = 7
        '
        'colmarca
        '
        Me.colmarca.AppearanceCell.Options.UseTextOptions = True
        Me.colmarca.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colmarca.Caption = "Marca"
        Me.colmarca.FieldName = "marca"
        Me.colmarca.Name = "colmarca"
        Me.colmarca.Visible = True
        Me.colmarca.VisibleIndex = 8
        '
        'colestilon
        '
        Me.colestilon.Caption = "Modelo"
        Me.colestilon.FieldName = "estilon"
        Me.colestilon.Name = "colestilon"
        Me.colestilon.Visible = True
        Me.colestilon.VisibleIndex = 9
        '
        'medida
        '
        Me.medida.AppearanceCell.Options.UseTextOptions = True
        Me.medida.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.medida.Caption = "Medida"
        Me.medida.FieldName = "medida"
        Me.medida.Name = "medida"
        Me.medida.Visible = True
        Me.medida.VisibleIndex = 10
        '
        'Serie
        '
        Me.Serie.AppearanceCell.Options.UseTextOptions = True
        Me.Serie.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Serie.Caption = "Serie"
        Me.Serie.FieldName = "serie"
        Me.Serie.Name = "Serie"
        Me.Serie.Visible = True
        Me.Serie.VisibleIndex = 11
        '
        'colguia_pdf
        '
        Me.colguia_pdf.Caption = "Guia"
        Me.colguia_pdf.FieldName = "guia_pdf"
        Me.colguia_pdf.Name = "colguia_pdf"
        Me.colguia_pdf.Visible = True
        Me.colguia_pdf.VisibleIndex = 12
        '
        'sfdRuta
        '
        Me.sfdRuta.Filter = "Archivos Excel | *.xls"
        '
        'frmPpalVentasenLinea
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.DGrid1)
        Me.Controls.Add(Me.PBox)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.KeyPreview = True
        Me.Name = "frmPpalVentasenLinea"
        Me.Text = "Ventas en Línea"
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_Botones.ResumeLayout(False)
        Me.Pnl_Botones.PerformLayout()
        CType(Me.Usp_SirCoEnLineaDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UspPpalVentasENLineaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PBox As PictureBox
    Friend WithEvents Pnl_Botones As Panel
    Friend WithEvents Btn_Refrescar As Button
    Friend WithEvents Btn_Excel As Button
    Friend WithEvents Btn_Salir As Button
    Friend WithEvents Usp_SirCoEnLineaDataSet As usp_SirCoEnLineaDataSet
    Friend WithEvents UspPpalVentasENLineaBindingSource As BindingSource
    Friend WithEvents Usp_PpalVentasENLineaTableAdapter As usp_SirCoEnLineaDataSetTableAdapters.usp_PpalVentasENLineaTableAdapter
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents DGrid1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colidventa As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colfum As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colidpedido As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcantidad As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colnombrecliente As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcanal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNoTraspaso As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNoVenta As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colmarca As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colestilon As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colguia_pdf As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents sfdRuta As SaveFileDialog
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents Serie As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Btn_PDF As Button
    Friend WithEvents medida As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Txt_Serie As TextBox
    Friend WithEvents Label7 As Label
End Class
