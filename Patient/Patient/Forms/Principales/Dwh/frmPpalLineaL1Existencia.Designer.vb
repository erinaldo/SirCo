<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPpalControlAparador
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPpalControlAparador))
        Me.Pnl_Botones = New System.Windows.Forms.Panel()
        Me.Lbl_Leyenda = New System.Windows.Forms.Label()
        Me.Btn_Regresar = New System.Windows.Forms.Button()
        Me.Btn_Filtro = New System.Windows.Forms.Button()
        Me.Btn_Excel = New System.Windows.Forms.Button()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.lbl_Dias = New System.Windows.Forms.Label()
        Me.lbl_Modelo = New System.Windows.Forms.Label()
        Me.lbl_Marca = New System.Windows.Forms.Label()
        Me.lbl_L6 = New System.Windows.Forms.Label()
        Me.lbl_L5 = New System.Windows.Forms.Label()
        Me.lbl_L4 = New System.Windows.Forms.Label()
        Me.lbl_L3 = New System.Windows.Forms.Label()
        Me.lbl_L2 = New System.Windows.Forms.Label()
        Me.lbl_L1 = New System.Windows.Forms.Label()
        Me.lbl_Linea = New System.Windows.Forms.Label()
        Me.lbl_Familia = New System.Windows.Forms.Label()
        Me.lbl_Depto = New System.Windows.Forms.Label()
        Me.lbl_Division = New System.Windows.Forms.Label()
        Me.lbl_Sucursal = New System.Windows.Forms.Label()
        Me.Usp_PpalLineaL1Existencia = New SIRCO.usp_PpalLineaL1Existencia()
        Me.UspPpalLineaL1ExistenciaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DGrid1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PBox = New System.Windows.Forms.PictureBox()
        Me.DGrid2 = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.DGrid3 = New DevExpress.XtraGrid.GridControl()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PLinqServerModeSource1 = New DevExpress.Data.PLinq.PLinqServerModeSource()
        Me.Pnl_Botones.SuspendLayout()
        CType(Me.Usp_PpalLineaL1Existencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UspPpalLineaL1ExistenciaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGrid3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PLinqServerModeSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Lbl_Leyenda)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Regresar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Filtro)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Excel)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Salir)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 684)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(1124, 56)
        Me.Pnl_Botones.TabIndex = 4
        '
        'Lbl_Leyenda
        '
        Me.Lbl_Leyenda.AutoSize = True
        Me.Lbl_Leyenda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Leyenda.Location = New System.Drawing.Point(36, 22)
        Me.Lbl_Leyenda.Name = "Lbl_Leyenda"
        Me.Lbl_Leyenda.Size = New System.Drawing.Size(0, 13)
        Me.Lbl_Leyenda.TabIndex = 38
        '
        'Btn_Regresar
        '
        Me.Btn_Regresar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Regresar.Enabled = False
        Me.Btn_Regresar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Regresar.Image = CType(resources.GetObject("Btn_Regresar.Image"), System.Drawing.Image)
        Me.Btn_Regresar.Location = New System.Drawing.Point(916, 0)
        Me.Btn_Regresar.Name = "Btn_Regresar"
        Me.Btn_Regresar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Regresar.TabIndex = 37
        Me.Btn_Regresar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Regresar.UseVisualStyleBackColor = True
        Me.Btn_Regresar.Visible = False
        '
        'Btn_Filtro
        '
        Me.Btn_Filtro.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Filtro.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Filtro.Image = Global.SIRCO.My.Resources.Resources.magnifier_zoom_in
        Me.Btn_Filtro.Location = New System.Drawing.Point(967, 0)
        Me.Btn_Filtro.Name = "Btn_Filtro"
        Me.Btn_Filtro.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Filtro.TabIndex = 10
        Me.Btn_Filtro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Filtro.UseVisualStyleBackColor = True
        '
        'Btn_Excel
        '
        Me.Btn_Excel.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Excel.Image = Global.SIRCO.My.Resources.Resources.document_print
        Me.Btn_Excel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Excel.Location = New System.Drawing.Point(1018, 0)
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
        Me.Btn_Salir.Location = New System.Drawing.Point(1069, 0)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Salir.TabIndex = 5
        Me.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Salir.UseVisualStyleBackColor = True
        '
        'lbl_Dias
        '
        Me.lbl_Dias.AutoSize = True
        Me.lbl_Dias.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Dias.Location = New System.Drawing.Point(531, 218)
        Me.lbl_Dias.Name = "lbl_Dias"
        Me.lbl_Dias.Size = New System.Drawing.Size(15, 15)
        Me.lbl_Dias.TabIndex = 72
        Me.lbl_Dias.Text = "A"
        Me.lbl_Dias.Visible = False
        '
        'lbl_Modelo
        '
        Me.lbl_Modelo.AutoSize = True
        Me.lbl_Modelo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Modelo.Location = New System.Drawing.Point(510, 218)
        Me.lbl_Modelo.Name = "lbl_Modelo"
        Me.lbl_Modelo.Size = New System.Drawing.Size(15, 15)
        Me.lbl_Modelo.TabIndex = 71
        Me.lbl_Modelo.Text = "A"
        Me.lbl_Modelo.Visible = False
        '
        'lbl_Marca
        '
        Me.lbl_Marca.AutoSize = True
        Me.lbl_Marca.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Marca.Location = New System.Drawing.Point(489, 218)
        Me.lbl_Marca.Name = "lbl_Marca"
        Me.lbl_Marca.Size = New System.Drawing.Size(15, 15)
        Me.lbl_Marca.TabIndex = 70
        Me.lbl_Marca.Text = "A"
        Me.lbl_Marca.Visible = False
        '
        'lbl_L6
        '
        Me.lbl_L6.AutoSize = True
        Me.lbl_L6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_L6.Location = New System.Drawing.Point(468, 218)
        Me.lbl_L6.Name = "lbl_L6"
        Me.lbl_L6.Size = New System.Drawing.Size(15, 15)
        Me.lbl_L6.TabIndex = 69
        Me.lbl_L6.Text = "A"
        Me.lbl_L6.Visible = False
        '
        'lbl_L5
        '
        Me.lbl_L5.AutoSize = True
        Me.lbl_L5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_L5.Location = New System.Drawing.Point(447, 218)
        Me.lbl_L5.Name = "lbl_L5"
        Me.lbl_L5.Size = New System.Drawing.Size(15, 15)
        Me.lbl_L5.TabIndex = 68
        Me.lbl_L5.Text = "A"
        Me.lbl_L5.Visible = False
        '
        'lbl_L4
        '
        Me.lbl_L4.AutoSize = True
        Me.lbl_L4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_L4.Location = New System.Drawing.Point(426, 218)
        Me.lbl_L4.Name = "lbl_L4"
        Me.lbl_L4.Size = New System.Drawing.Size(15, 15)
        Me.lbl_L4.TabIndex = 67
        Me.lbl_L4.Text = "A"
        Me.lbl_L4.Visible = False
        '
        'lbl_L3
        '
        Me.lbl_L3.AutoSize = True
        Me.lbl_L3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_L3.Location = New System.Drawing.Point(405, 218)
        Me.lbl_L3.Name = "lbl_L3"
        Me.lbl_L3.Size = New System.Drawing.Size(15, 15)
        Me.lbl_L3.TabIndex = 66
        Me.lbl_L3.Text = "A"
        Me.lbl_L3.Visible = False
        '
        'lbl_L2
        '
        Me.lbl_L2.AutoSize = True
        Me.lbl_L2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_L2.Location = New System.Drawing.Point(384, 218)
        Me.lbl_L2.Name = "lbl_L2"
        Me.lbl_L2.Size = New System.Drawing.Size(15, 15)
        Me.lbl_L2.TabIndex = 65
        Me.lbl_L2.Text = "A"
        Me.lbl_L2.Visible = False
        '
        'lbl_L1
        '
        Me.lbl_L1.AutoSize = True
        Me.lbl_L1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_L1.Location = New System.Drawing.Point(363, 218)
        Me.lbl_L1.Name = "lbl_L1"
        Me.lbl_L1.Size = New System.Drawing.Size(15, 15)
        Me.lbl_L1.TabIndex = 64
        Me.lbl_L1.Text = "A"
        Me.lbl_L1.Visible = False
        '
        'lbl_Linea
        '
        Me.lbl_Linea.AutoSize = True
        Me.lbl_Linea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Linea.Location = New System.Drawing.Point(342, 218)
        Me.lbl_Linea.Name = "lbl_Linea"
        Me.lbl_Linea.Size = New System.Drawing.Size(15, 15)
        Me.lbl_Linea.TabIndex = 63
        Me.lbl_Linea.Text = "A"
        Me.lbl_Linea.Visible = False
        '
        'lbl_Familia
        '
        Me.lbl_Familia.AutoSize = True
        Me.lbl_Familia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Familia.Location = New System.Drawing.Point(321, 218)
        Me.lbl_Familia.Name = "lbl_Familia"
        Me.lbl_Familia.Size = New System.Drawing.Size(15, 15)
        Me.lbl_Familia.TabIndex = 62
        Me.lbl_Familia.Text = "A"
        Me.lbl_Familia.Visible = False
        '
        'lbl_Depto
        '
        Me.lbl_Depto.AutoSize = True
        Me.lbl_Depto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Depto.Location = New System.Drawing.Point(300, 218)
        Me.lbl_Depto.Name = "lbl_Depto"
        Me.lbl_Depto.Size = New System.Drawing.Size(15, 15)
        Me.lbl_Depto.TabIndex = 61
        Me.lbl_Depto.Text = "A"
        Me.lbl_Depto.Visible = False
        '
        'lbl_Division
        '
        Me.lbl_Division.AutoSize = True
        Me.lbl_Division.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Division.Location = New System.Drawing.Point(279, 218)
        Me.lbl_Division.Name = "lbl_Division"
        Me.lbl_Division.Size = New System.Drawing.Size(15, 15)
        Me.lbl_Division.TabIndex = 60
        Me.lbl_Division.Text = "A"
        Me.lbl_Division.Visible = False
        '
        'lbl_Sucursal
        '
        Me.lbl_Sucursal.AutoSize = True
        Me.lbl_Sucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Sucursal.Location = New System.Drawing.Point(255, 218)
        Me.lbl_Sucursal.Name = "lbl_Sucursal"
        Me.lbl_Sucursal.Size = New System.Drawing.Size(15, 15)
        Me.lbl_Sucursal.TabIndex = 59
        Me.lbl_Sucursal.Text = "A"
        Me.lbl_Sucursal.Visible = False
        '
        'Usp_PpalLineaL1Existencia
        '
        Me.Usp_PpalLineaL1Existencia.DataSetName = "usp_PpalLineaL1Existencia"
        Me.Usp_PpalLineaL1Existencia.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'UspPpalLineaL1ExistenciaBindingSource
        '
        Me.UspPpalLineaL1ExistenciaBindingSource.DataSource = Me.Usp_PpalLineaL1Existencia
        Me.UspPpalLineaL1ExistenciaBindingSource.Position = 0
        '
        'DGrid1
        '
        Me.DGrid1.Dock = System.Windows.Forms.DockStyle.Top
        Me.DGrid1.Location = New System.Drawing.Point(0, 0)
        Me.DGrid1.MainView = Me.GridView1
        Me.DGrid1.Name = "DGrid1"
        Me.DGrid1.Size = New System.Drawing.Size(1124, 261)
        Me.DGrid1.TabIndex = 73
        Me.DGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.DGrid1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.ReadOnly = True
        Me.GridView1.OptionsPrint.RtfPageFooter = resources.GetString("GridView1.OptionsPrint.RtfPageFooter")
        Me.GridView1.OptionsPrint.RtfPageHeader = resources.GetString("GridView1.OptionsPrint.RtfPageHeader")
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFooter = True
        '
        'PBox
        '
        Me.PBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PBox.Location = New System.Drawing.Point(634, 408)
        Me.PBox.Name = "PBox"
        Me.PBox.Size = New System.Drawing.Size(193, 162)
        Me.PBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBox.TabIndex = 74
        Me.PBox.TabStop = False
        Me.PBox.Visible = False
        '
        'DGrid2
        '
        Me.DGrid2.Dock = System.Windows.Forms.DockStyle.Top
        Me.DGrid2.Location = New System.Drawing.Point(0, 261)
        Me.DGrid2.MainView = Me.GridView2
        Me.DGrid2.Name = "DGrid2"
        Me.DGrid2.Size = New System.Drawing.Size(1124, 206)
        Me.DGrid2.TabIndex = 75
        Me.DGrid2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.DGrid2
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsBehavior.ReadOnly = True
        Me.GridView2.OptionsPrint.RtfPageFooter = resources.GetString("GridView2.OptionsPrint.RtfPageFooter")
        Me.GridView2.OptionsPrint.RtfPageHeader = resources.GetString("GridView2.OptionsPrint.RtfPageHeader")
        Me.GridView2.OptionsView.ColumnAutoWidth = False
        Me.GridView2.OptionsView.ShowAutoFilterRow = True
        Me.GridView2.OptionsView.ShowFooter = True
        '
        'DGrid3
        '
        Me.DGrid3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGrid3.Location = New System.Drawing.Point(0, 467)
        Me.DGrid3.MainView = Me.GridView3
        Me.DGrid3.Name = "DGrid3"
        Me.DGrid3.Size = New System.Drawing.Size(1124, 217)
        Me.DGrid3.TabIndex = 76
        Me.DGrid3.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.DGrid3
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsBehavior.ReadOnly = True
        Me.GridView3.OptionsPrint.RtfPageFooter = resources.GetString("GridView3.OptionsPrint.RtfPageFooter")
        Me.GridView3.OptionsPrint.RtfPageHeader = resources.GetString("GridView3.OptionsPrint.RtfPageHeader")
        Me.GridView3.OptionsView.ColumnAutoWidth = False
        Me.GridView3.OptionsView.ShowAutoFilterRow = True
        Me.GridView3.OptionsView.ShowFooter = True
        '
        'frmPpalControlAparador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1124, 740)
        Me.Controls.Add(Me.PBox)
        Me.Controls.Add(Me.DGrid3)
        Me.Controls.Add(Me.DGrid2)
        Me.Controls.Add(Me.DGrid1)
        Me.Controls.Add(Me.lbl_Dias)
        Me.Controls.Add(Me.lbl_Modelo)
        Me.Controls.Add(Me.lbl_Marca)
        Me.Controls.Add(Me.lbl_L6)
        Me.Controls.Add(Me.lbl_L5)
        Me.Controls.Add(Me.lbl_L4)
        Me.Controls.Add(Me.lbl_L3)
        Me.Controls.Add(Me.lbl_L2)
        Me.Controls.Add(Me.lbl_L1)
        Me.Controls.Add(Me.lbl_Linea)
        Me.Controls.Add(Me.lbl_Familia)
        Me.Controls.Add(Me.lbl_Depto)
        Me.Controls.Add(Me.lbl_Division)
        Me.Controls.Add(Me.lbl_Sucursal)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPpalControlAparador"
        Me.Text = "Control de Aparador"
        Me.Pnl_Botones.ResumeLayout(False)
        Me.Pnl_Botones.PerformLayout()
        CType(Me.Usp_PpalLineaL1Existencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UspPpalLineaL1ExistenciaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGrid3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PLinqServerModeSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Pnl_Botones As Panel
    Friend WithEvents Btn_Regresar As Button
    Friend WithEvents Btn_Filtro As Button
    Friend WithEvents Btn_Excel As Button
    Friend WithEvents Btn_Salir As Button
    Friend WithEvents lbl_Dias As Label
    Friend WithEvents lbl_Modelo As Label
    Friend WithEvents lbl_Marca As Label
    Friend WithEvents lbl_L6 As Label
    Friend WithEvents lbl_L5 As Label
    Friend WithEvents lbl_L4 As Label
    Friend WithEvents lbl_L3 As Label
    Friend WithEvents lbl_L2 As Label
    Friend WithEvents lbl_L1 As Label
    Friend WithEvents lbl_Linea As Label
    Friend WithEvents lbl_Familia As Label
    Friend WithEvents lbl_Depto As Label
    Friend WithEvents lbl_Division As Label
    Friend WithEvents lbl_Sucursal As Label
    Friend WithEvents Usp_PpalLineaL1Existencia As usp_PpalLineaL1Existencia
    Friend WithEvents UspPpalLineaL1ExistenciaBindingSource As BindingSource
    Friend WithEvents DGrid1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Lbl_Leyenda As Label
    Friend WithEvents PBox As PictureBox
    Friend WithEvents DGrid2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents DGrid3 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PLinqServerModeSource1 As DevExpress.Data.PLinq.PLinqServerModeSource
End Class
