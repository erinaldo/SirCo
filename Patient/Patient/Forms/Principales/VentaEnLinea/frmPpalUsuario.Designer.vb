<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPpalUsuario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPpalUsuario))
        Me.Pnl_Botones = New System.Windows.Forms.Panel()
        Me.Btn_Refrescar = New System.Windows.Forms.Button()
        Me.Btn_Imprimir = New System.Windows.Forms.Button()
        Me.Btn_Excel = New System.Windows.Forms.Button()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.DGrid1 = New DevExpress.XtraGrid.GridControl()
        Me.UspPpalUsuarioBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Usp_PpalUsuario11 = New SIRCO.usp_PpalUsuario11()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Usuario = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colidempleado = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Nombre = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colfechanacim = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coldamas = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcaballeros = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colninas = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colninos = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colbebes = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colaccesorios = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colpassword = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UspPpalUsuarioBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Usp_PpalUsuario1 = New SIRCO.usp_PpalUsuario1()
        Me.PdfViewer1 = New DevExpress.XtraPdfViewer.PdfViewer()
        Me.sfdRuta = New System.Windows.Forms.SaveFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Usp_PpalUsuarioTableAdapter = New SIRCO.usp_PpalUsuario1TableAdapters.usp_PpalUsuarioTableAdapter()
        Me.Usp_PpalUsuarioTableAdapter1 = New SIRCO.usp_PpalUsuario11TableAdapters.usp_PpalUsuarioTableAdapter()
        Me.Btn_Nuevo = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_Editar = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.Pnl_Botones.SuspendLayout()
        CType(Me.DGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UspPpalUsuarioBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Usp_PpalUsuario11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UspPpalUsuarioBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Usp_PpalUsuario1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.SimpleButton1)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Editar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Nuevo)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Refrescar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Imprimir)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Excel)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Salir)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 526)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(853, 56)
        Me.Pnl_Botones.TabIndex = 4
        '
        'Btn_Refrescar
        '
        Me.Btn_Refrescar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Refrescar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Refrescar.Image = Global.SIRCO.My.Resources.Resources.database_refresh
        Me.Btn_Refrescar.Location = New System.Drawing.Point(645, 0)
        Me.Btn_Refrescar.Name = "Btn_Refrescar"
        Me.Btn_Refrescar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Refrescar.TabIndex = 12
        Me.Btn_Refrescar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Refrescar.UseVisualStyleBackColor = True
        '
        'Btn_Imprimir
        '
        Me.Btn_Imprimir.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Imprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Imprimir.Image = Global.SIRCO.My.Resources.Resources.document_print
        Me.Btn_Imprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Imprimir.Location = New System.Drawing.Point(696, 0)
        Me.Btn_Imprimir.Name = "Btn_Imprimir"
        Me.Btn_Imprimir.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Imprimir.TabIndex = 11
        Me.Btn_Imprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Imprimir.UseVisualStyleBackColor = True
        Me.Btn_Imprimir.Visible = False
        '
        'Btn_Excel
        '
        Me.Btn_Excel.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Excel.Image = Global.SIRCO.My.Resources.Resources.table_excel
        Me.Btn_Excel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Excel.Location = New System.Drawing.Point(747, 0)
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
        Me.Btn_Salir.Location = New System.Drawing.Point(798, 0)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Salir.TabIndex = 5
        Me.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Salir.UseVisualStyleBackColor = True
        '
        'DGrid1
        '
        Me.DGrid1.DataSource = Me.UspPpalUsuarioBindingSource1
        Me.DGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGrid1.Location = New System.Drawing.Point(0, 0)
        Me.DGrid1.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.DGrid1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.DGrid1.MainView = Me.GridView1
        Me.DGrid1.Name = "DGrid1"
        Me.DGrid1.Size = New System.Drawing.Size(853, 526)
        Me.DGrid1.TabIndex = 5
        Me.DGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'UspPpalUsuarioBindingSource1
        '
        Me.UspPpalUsuarioBindingSource1.DataMember = "usp_PpalUsuario"
        Me.UspPpalUsuarioBindingSource1.DataSource = Me.Usp_PpalUsuario11
        '
        'Usp_PpalUsuario11
        '
        Me.Usp_PpalUsuario11.DataSetName = "usp_PpalUsuario11"
        Me.Usp_PpalUsuario11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridView1
        '
        Me.GridView1.Appearance.FooterPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView1.Appearance.FooterPanel.Options.UseFont = True
        Me.GridView1.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView1.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridView1.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Usuario, Me.colidempleado, Me.Nombre, Me.colfechanacim, Me.coldamas, Me.colcaballeros, Me.colninas, Me.colninos, Me.colbebes, Me.colaccesorios, Me.colpassword})
        Me.GridView1.GridControl = Me.DGrid1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowFooter = True
        '
        'Usuario
        '
        Me.Usuario.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Usuario.AppearanceHeader.Options.UseFont = True
        Me.Usuario.AppearanceHeader.Options.UseTextOptions = True
        Me.Usuario.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Usuario.Caption = "Usuario"
        Me.Usuario.FieldName = "usuario"
        Me.Usuario.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.Usuario.Name = "Usuario"
        Me.Usuario.OptionsColumn.ReadOnly = True
        Me.Usuario.Visible = True
        Me.Usuario.VisibleIndex = 0
        '
        'colidempleado
        '
        Me.colidempleado.Caption = "Id Empleado"
        Me.colidempleado.FieldName = "idempleado"
        Me.colidempleado.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colidempleado.Name = "colidempleado"
        Me.colidempleado.OptionsColumn.ReadOnly = True
        Me.colidempleado.Visible = True
        Me.colidempleado.VisibleIndex = 1
        '
        'Nombre
        '
        Me.Nombre.Caption = "Nombre"
        Me.Nombre.FieldName = "nombre"
        Me.Nombre.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.Nombre.Name = "Nombre"
        Me.Nombre.OptionsColumn.ReadOnly = True
        Me.Nombre.Visible = True
        Me.Nombre.VisibleIndex = 2
        '
        'colfechanacim
        '
        Me.colfechanacim.FieldName = "fechanacim"
        Me.colfechanacim.Name = "colfechanacim"
        Me.colfechanacim.OptionsColumn.ReadOnly = True
        '
        'coldamas
        '
        Me.coldamas.Caption = "Damas"
        Me.coldamas.FieldName = "damas"
        Me.coldamas.Name = "coldamas"
        Me.coldamas.OptionsColumn.ReadOnly = True
        Me.coldamas.Visible = True
        Me.coldamas.VisibleIndex = 3
        '
        'colcaballeros
        '
        Me.colcaballeros.Caption = "Caballeros"
        Me.colcaballeros.FieldName = "caballeros"
        Me.colcaballeros.Name = "colcaballeros"
        Me.colcaballeros.OptionsColumn.ReadOnly = True
        Me.colcaballeros.Visible = True
        Me.colcaballeros.VisibleIndex = 4
        '
        'colninas
        '
        Me.colninas.Caption = "Niñas"
        Me.colninas.FieldName = "ninas"
        Me.colninas.Name = "colninas"
        Me.colninas.OptionsColumn.ReadOnly = True
        Me.colninas.Visible = True
        Me.colninas.VisibleIndex = 5
        '
        'colninos
        '
        Me.colninos.Caption = "Niños"
        Me.colninos.FieldName = "ninos"
        Me.colninos.Name = "colninos"
        Me.colninos.OptionsColumn.ReadOnly = True
        Me.colninos.Visible = True
        Me.colninos.VisibleIndex = 6
        '
        'colbebes
        '
        Me.colbebes.Caption = "Bebés"
        Me.colbebes.FieldName = "bebes"
        Me.colbebes.Name = "colbebes"
        Me.colbebes.OptionsColumn.ReadOnly = True
        Me.colbebes.Visible = True
        Me.colbebes.VisibleIndex = 7
        '
        'colaccesorios
        '
        Me.colaccesorios.Caption = "Accesorios"
        Me.colaccesorios.FieldName = "accesorios"
        Me.colaccesorios.Name = "colaccesorios"
        Me.colaccesorios.Visible = True
        Me.colaccesorios.VisibleIndex = 8
        '
        'colpassword
        '
        Me.colpassword.FieldName = "password"
        Me.colpassword.Name = "colpassword"
        '
        'UspPpalUsuarioBindingSource
        '
        Me.UspPpalUsuarioBindingSource.DataMember = "usp_PpalUsuario"
        Me.UspPpalUsuarioBindingSource.DataSource = Me.Usp_PpalUsuario1
        '
        'Usp_PpalUsuario1
        '
        Me.Usp_PpalUsuario1.DataSetName = "usp_PpalUsuario1"
        Me.Usp_PpalUsuario1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PdfViewer1
        '
        Me.PdfViewer1.Location = New System.Drawing.Point(0, 0)
        Me.PdfViewer1.Name = "PdfViewer1"
        Me.PdfViewer1.Size = New System.Drawing.Size(150, 150)
        Me.PdfViewer1.TabIndex = 0
        '
        'sfdRuta
        '
        Me.sfdRuta.Filter = "Archivos Excel | *.xls"
        '
        'SaveFileDialog1
        '
        '
        'Usp_PpalUsuarioTableAdapter
        '
        Me.Usp_PpalUsuarioTableAdapter.ClearBeforeFill = True
        '
        'Usp_PpalUsuarioTableAdapter1
        '
        Me.Usp_PpalUsuarioTableAdapter1.ClearBeforeFill = True
        '
        'Btn_Nuevo
        '
        Me.Btn_Nuevo.Image = Global.SIRCO.My.Resources.Resources.new_20doc
        Me.Btn_Nuevo.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.Btn_Nuevo.Location = New System.Drawing.Point(3, 0)
        Me.Btn_Nuevo.Name = "Btn_Nuevo"
        Me.Btn_Nuevo.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Nuevo.TabIndex = 13
        Me.Btn_Nuevo.Text = "Nuevo Usuario"
        '
        'Btn_Editar
        '
        Me.Btn_Editar.Image = Global.SIRCO.My.Resources.Resources.Editar
        Me.Btn_Editar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.Btn_Editar.Location = New System.Drawing.Point(60, 0)
        Me.Btn_Editar.Name = "Btn_Editar"
        Me.Btn_Editar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Editar.TabIndex = 14
        Me.Btn_Editar.Text = "Editar Usuario"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Image = Global.SIRCO.My.Resources.Resources.find
        Me.SimpleButton1.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.SimpleButton1.Location = New System.Drawing.Point(117, 0)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(51, 52)
        Me.SimpleButton1.TabIndex = 15
        Me.SimpleButton1.Text = "Consultar"
        '
        'frmPpalUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(853, 582)
        Me.Controls.Add(Me.DGrid1)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmPpalUsuario"
        Me.Text = "Usuarios"
        Me.Pnl_Botones.ResumeLayout(False)
        CType(Me.DGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UspPpalUsuarioBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Usp_PpalUsuario11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UspPpalUsuarioBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Usp_PpalUsuario1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Pnl_Botones As Panel
    Friend WithEvents Btn_Imprimir As Button
    Friend WithEvents Btn_Excel As Button
    Friend WithEvents Btn_Salir As Button
    Friend WithEvents DGrid1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Usuario As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Nombre As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PdfViewer1 As DevExpress.XtraPdfViewer.PdfViewer
    Friend WithEvents sfdRuta As SaveFileDialog
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents Btn_Refrescar As Button
    Friend WithEvents colidempleado As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colfechanacim As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Usp_PpalUsuario1 As usp_PpalUsuario1
    Friend WithEvents UspPpalUsuarioBindingSource As BindingSource
    Friend WithEvents Usp_PpalUsuarioTableAdapter As usp_PpalUsuario1TableAdapters.usp_PpalUsuarioTableAdapter
    Friend WithEvents coldamas As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcaballeros As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colninas As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colninos As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colbebes As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Usp_PpalUsuario11 As usp_PpalUsuario11
    Friend WithEvents UspPpalUsuarioBindingSource1 As BindingSource
    Friend WithEvents Usp_PpalUsuarioTableAdapter1 As usp_PpalUsuario11TableAdapters.usp_PpalUsuarioTableAdapter
    Friend WithEvents colaccesorios As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colpassword As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Btn_Editar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_Nuevo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
End Class
