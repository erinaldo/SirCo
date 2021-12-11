<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPpalPrevioVentaAnual
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPpalPrevioVentaAnual))
        Me.Pnl_Botones = New System.Windows.Forms.Panel()
        Me.Btn_Refrescar = New System.Windows.Forms.Button()
        Me.Btn_Excel = New System.Windows.Forms.Button()
        Me.Lbl_Leyenda = New System.Windows.Forms.Label()
        Me.Btn_Filtro = New System.Windows.Forms.Button()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.PBox = New System.Windows.Forms.PictureBox()
        Me.SirCoDataSet2 = New SIRCO.SirCoDataSet2()
        Me.Dgrid = New DevExpress.XtraGrid.GridControl()
        Me.UspPpalPrevioVentaAnualFotoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Usp_PpalPrevioVentaAnualFoto = New SIRCO.usp_PpalPrevioVentaAnualFoto()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.sfdRuta = New System.Windows.Forms.SaveFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Pnl_Botones.SuspendLayout()
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SirCoDataSet2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dgrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UspPpalPrevioVentaAnualFotoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Usp_PpalPrevioVentaAnualFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Button1)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Refrescar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Excel)
        Me.Pnl_Botones.Controls.Add(Me.Lbl_Leyenda)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Filtro)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Salir)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 394)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(800, 56)
        Me.Pnl_Botones.TabIndex = 5
        '
        'Btn_Refrescar
        '
        Me.Btn_Refrescar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Refrescar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Refrescar.Image = Global.SIRCO.My.Resources.Resources.database_refresh
        Me.Btn_Refrescar.Location = New System.Drawing.Point(592, 0)
        Me.Btn_Refrescar.Name = "Btn_Refrescar"
        Me.Btn_Refrescar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Refrescar.TabIndex = 40
        Me.Btn_Refrescar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Refrescar.UseVisualStyleBackColor = True
        Me.Btn_Refrescar.Visible = False
        '
        'Btn_Excel
        '
        Me.Btn_Excel.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Excel.Image = Global.SIRCO.My.Resources.Resources.table_excel
        Me.Btn_Excel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Excel.Location = New System.Drawing.Point(643, 0)
        Me.Btn_Excel.Name = "Btn_Excel"
        Me.Btn_Excel.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Excel.TabIndex = 39
        Me.Btn_Excel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Excel.UseVisualStyleBackColor = True
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
        'Btn_Filtro
        '
        Me.Btn_Filtro.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Filtro.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Filtro.Image = Global.SIRCO.My.Resources.Resources.magnifier_zoom_in
        Me.Btn_Filtro.Location = New System.Drawing.Point(694, 0)
        Me.Btn_Filtro.Name = "Btn_Filtro"
        Me.Btn_Filtro.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Filtro.TabIndex = 10
        Me.Btn_Filtro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Filtro.UseVisualStyleBackColor = True
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
        'PBox
        '
        Me.PBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PBox.Location = New System.Drawing.Point(304, 144)
        Me.PBox.Name = "PBox"
        Me.PBox.Size = New System.Drawing.Size(193, 162)
        Me.PBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBox.TabIndex = 7
        Me.PBox.TabStop = False
        Me.PBox.Visible = False
        '
        'SirCoDataSet2
        '
        Me.SirCoDataSet2.DataSetName = "SirCoDataSet2"
        Me.SirCoDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Dgrid
        '
        Me.Dgrid.DataSource = Me.UspPpalPrevioVentaAnualFotoBindingSource
        Me.Dgrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgrid.Location = New System.Drawing.Point(0, 0)
        Me.Dgrid.MainView = Me.GridView1
        Me.Dgrid.Name = "Dgrid"
        Me.Dgrid.Size = New System.Drawing.Size(800, 450)
        Me.Dgrid.TabIndex = 8
        Me.Dgrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'UspPpalPrevioVentaAnualFotoBindingSource
        '
        Me.UspPpalPrevioVentaAnualFotoBindingSource.DataSource = Me.Usp_PpalPrevioVentaAnualFoto
        Me.UspPpalPrevioVentaAnualFotoBindingSource.Position = 0
        '
        'Usp_PpalPrevioVentaAnualFoto
        '
        Me.Usp_PpalPrevioVentaAnualFoto.DataSetName = "usp_PpalPrevioVentaAnualFoto"
        Me.Usp_PpalPrevioVentaAnualFoto.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.Dgrid
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click
        Me.GridView1.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'sfdRuta
        '
        Me.sfdRuta.Filter = "Archivos Excel | *.xls"
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = Global.SIRCO.My.Resources.Resources.report_check
        Me.Button1.Location = New System.Drawing.Point(541, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(51, 52)
        Me.Button1.TabIndex = 41
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmPpalPrevioVentaAnual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.PBox)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Controls.Add(Me.Dgrid)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPpalPrevioVentaAnual"
        Me.Text = "Previo para Listado Venta Anual"
        Me.Pnl_Botones.ResumeLayout(False)
        Me.Pnl_Botones.PerformLayout()
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SirCoDataSet2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dgrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UspPpalPrevioVentaAnualFotoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Usp_PpalPrevioVentaAnualFoto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Pnl_Botones As Panel
    Friend WithEvents Lbl_Leyenda As Label
    Friend WithEvents Btn_Filtro As Button
    Friend WithEvents Btn_Salir As Button
    Friend WithEvents PBox As PictureBox
    Friend WithEvents SirCoDataSet2 As SirCoDataSet2
    Friend WithEvents Dgrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents UspPpalPrevioVentaAnualFotoBindingSource As BindingSource
    Friend WithEvents Usp_PpalPrevioVentaAnualFoto As usp_PpalPrevioVentaAnualFoto
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Btn_Refrescar As Button
    Friend WithEvents Btn_Excel As Button
    Friend WithEvents sfdRuta As SaveFileDialog
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents Button1 As Button
End Class
