<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPpalBitacora
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPpalBitacora))
        Me.Pnl_Grid = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Grido = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PBox = New System.Windows.Forms.PictureBox()
        Me.DGrid = New System.Windows.Forms.DataGridView()
        Me.CMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RegistrarSegToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerSeguimientoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerProveedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultaOrdenDeCompraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificarFechasOrdendeCompra = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImagenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnalisisToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CatalogoModToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Pnl_Botones = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Btn_OrdeComp = New System.Windows.Forms.Button()
        Me.PBar = New System.Windows.Forms.ProgressBar()
        Me.Btn_Foto = New System.Windows.Forms.Button()
        Me.Btn_Fechas = New System.Windows.Forms.Button()
        Me.Btn_Seguimiento = New System.Windows.Forms.Button()
        Me.Btn_Filtro = New System.Windows.Forms.Button()
        Me.Btn_Imprimir = New System.Windows.Forms.Button()
        Me.Btn_Excel = New System.Windows.Forms.Button()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.sfdRuta = New System.Windows.Forms.SaveFileDialog()
        Me.Pnl_Grid.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMenu.SuspendLayout()
        Me.Pnl_Botones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pnl_Grid
        '
        Me.Pnl_Grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Grid.Controls.Add(Me.PictureBox1)
        Me.Pnl_Grid.Controls.Add(Me.Grido)
        Me.Pnl_Grid.Controls.Add(Me.PBox)
        Me.Pnl_Grid.Controls.Add(Me.DGrid)
        Me.Pnl_Grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnl_Grid.Location = New System.Drawing.Point(0, 0)
        Me.Pnl_Grid.Name = "Pnl_Grid"
        Me.Pnl_Grid.Size = New System.Drawing.Size(1362, 636)
        Me.Pnl_Grid.TabIndex = 4
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(1103, 337)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(229, 224)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Grido
        '
        Me.Grido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grido.Location = New System.Drawing.Point(0, 0)
        Me.Grido.MainView = Me.GridView1
        Me.Grido.Name = "Grido"
        Me.Grido.Size = New System.Drawing.Size(1358, 632)
        Me.Grido.TabIndex = 4
        Me.Grido.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.Grido
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'PBox
        '
        Me.PBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PBox.Location = New System.Drawing.Point(1162, 466)
        Me.PBox.Name = "PBox"
        Me.PBox.Size = New System.Drawing.Size(193, 162)
        Me.PBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBox.TabIndex = 3
        Me.PBox.TabStop = False
        Me.PBox.Visible = False
        '
        'DGrid
        '
        Me.DGrid.AllowUserToResizeColumns = False
        Me.DGrid.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.PowderBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGrid.ContextMenuStrip = Me.CMenu
        Me.DGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGrid.Location = New System.Drawing.Point(0, 0)
        Me.DGrid.Name = "DGrid"
        Me.DGrid.ReadOnly = True
        Me.DGrid.Size = New System.Drawing.Size(1358, 632)
        Me.DGrid.TabIndex = 0
        '
        'CMenu
        '
        Me.CMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegistrarSegToolStripMenuItem, Me.VerSeguimientoToolStripMenuItem, Me.VerProveedorToolStripMenuItem, Me.ConsultaOrdenDeCompraToolStripMenuItem, Me.ModificarFechasOrdendeCompra, Me.ImagenToolStripMenuItem, Me.AnalisisToolStripMenuItem, Me.CatalogoModToolStripMenuItem})
        Me.CMenu.Name = "CMenu"
        Me.CMenu.Size = New System.Drawing.Size(279, 180)
        '
        'RegistrarSegToolStripMenuItem
        '
        Me.RegistrarSegToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.LOG
        Me.RegistrarSegToolStripMenuItem.Name = "RegistrarSegToolStripMenuItem"
        Me.RegistrarSegToolStripMenuItem.Size = New System.Drawing.Size(278, 22)
        Me.RegistrarSegToolStripMenuItem.Text = "Registrar Seguimiento"
        '
        'VerSeguimientoToolStripMenuItem
        '
        Me.VerSeguimientoToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.monitoreo
        Me.VerSeguimientoToolStripMenuItem.Name = "VerSeguimientoToolStripMenuItem"
        Me.VerSeguimientoToolStripMenuItem.Size = New System.Drawing.Size(278, 22)
        Me.VerSeguimientoToolStripMenuItem.Text = "Reporte Seguimiento"
        '
        'VerProveedorToolStripMenuItem
        '
        Me.VerProveedorToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.proveedor
        Me.VerProveedorToolStripMenuItem.Name = "VerProveedorToolStripMenuItem"
        Me.VerProveedorToolStripMenuItem.Size = New System.Drawing.Size(278, 22)
        Me.VerProveedorToolStripMenuItem.Text = "Consulta Proveedor"
        '
        'ConsultaOrdenDeCompraToolStripMenuItem
        '
        Me.ConsultaOrdenDeCompraToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.ORDEN_DE_COMPRA
        Me.ConsultaOrdenDeCompraToolStripMenuItem.Name = "ConsultaOrdenDeCompraToolStripMenuItem"
        Me.ConsultaOrdenDeCompraToolStripMenuItem.Size = New System.Drawing.Size(278, 22)
        Me.ConsultaOrdenDeCompraToolStripMenuItem.Text = "Consulta Orden de Compra"
        '
        'ModificarFechasOrdendeCompra
        '
        Me.ModificarFechasOrdendeCompra.Image = Global.SIRCO.My.Resources.Resources.fechas
        Me.ModificarFechasOrdendeCompra.Name = "ModificarFechasOrdendeCompra"
        Me.ModificarFechasOrdendeCompra.Size = New System.Drawing.Size(278, 22)
        Me.ModificarFechasOrdendeCompra.Text = "Modificar Fechas de Orden de Compra"
        '
        'ImagenToolStripMenuItem
        '
        Me.ImagenToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.camara
        Me.ImagenToolStripMenuItem.Name = "ImagenToolStripMenuItem"
        Me.ImagenToolStripMenuItem.Size = New System.Drawing.Size(278, 22)
        Me.ImagenToolStripMenuItem.Text = "Imagen"
        '
        'AnalisisToolStripMenuItem
        '
        Me.AnalisisToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.monitoreo
        Me.AnalisisToolStripMenuItem.Name = "AnalisisToolStripMenuItem"
        Me.AnalisisToolStripMenuItem.Size = New System.Drawing.Size(278, 22)
        Me.AnalisisToolStripMenuItem.Text = "Análisis de Modelos"
        '
        'CatalogoModToolStripMenuItem
        '
        Me.CatalogoModToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.document_add
        Me.CatalogoModToolStripMenuItem.Name = "CatalogoModToolStripMenuItem"
        Me.CatalogoModToolStripMenuItem.Size = New System.Drawing.Size(278, 22)
        Me.CatalogoModToolStripMenuItem.Text = "Catálogo de Modelos"
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Label5)
        Me.Pnl_Botones.Controls.Add(Me.Label4)
        Me.Pnl_Botones.Controls.Add(Me.Label3)
        Me.Pnl_Botones.Controls.Add(Me.Label2)
        Me.Pnl_Botones.Controls.Add(Me.Label1)
        Me.Pnl_Botones.Controls.Add(Me.Btn_OrdeComp)
        Me.Pnl_Botones.Controls.Add(Me.PBar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Foto)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Fechas)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Seguimiento)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Filtro)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Imprimir)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Excel)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Salir)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 636)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(1362, 56)
        Me.Pnl_Botones.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.PowderBlue
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(369, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(177, 16)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "En tiempo, SIN seguimiento."
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.YellowGreen
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(369, 1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(177, 16)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "En tiempo, CON seguimiento."
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Yellow
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(159, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(264, 16)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "En proceso de seguimiento, SIN seguimiento."
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Red
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(159, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(264, 16)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Fuera de Tiempo, SIN seguimiento."
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Orange
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(159, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(264, 16)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Fuera de Tiempo, CON seguimiento."
        '
        'Btn_OrdeComp
        '
        Me.Btn_OrdeComp.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_OrdeComp.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_OrdeComp.Image = Global.SIRCO.My.Resources.Resources.orden_de_compra1
        Me.Btn_OrdeComp.Location = New System.Drawing.Point(102, 0)
        Me.Btn_OrdeComp.Name = "Btn_OrdeComp"
        Me.Btn_OrdeComp.Size = New System.Drawing.Size(51, 52)
        Me.Btn_OrdeComp.TabIndex = 12
        Me.Btn_OrdeComp.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_OrdeComp.UseVisualStyleBackColor = True
        '
        'PBar
        '
        Me.PBar.Location = New System.Drawing.Point(372, 19)
        Me.PBar.Name = "PBar"
        Me.PBar.Size = New System.Drawing.Size(111, 14)
        Me.PBar.TabIndex = 14
        Me.PBar.Visible = False
        '
        'Btn_Foto
        '
        Me.Btn_Foto.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Foto.Enabled = False
        Me.Btn_Foto.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Foto.Image = Global.SIRCO.My.Resources.Resources.camara
        Me.Btn_Foto.Location = New System.Drawing.Point(1103, 0)
        Me.Btn_Foto.Name = "Btn_Foto"
        Me.Btn_Foto.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Foto.TabIndex = 13
        Me.Btn_Foto.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Foto.UseVisualStyleBackColor = True
        '
        'Btn_Fechas
        '
        Me.Btn_Fechas.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Fechas.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Fechas.Image = Global.SIRCO.My.Resources.Resources.fechas
        Me.Btn_Fechas.Location = New System.Drawing.Point(51, 0)
        Me.Btn_Fechas.Name = "Btn_Fechas"
        Me.Btn_Fechas.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Fechas.TabIndex = 15
        Me.Btn_Fechas.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Fechas.UseVisualStyleBackColor = True
        '
        'Btn_Seguimiento
        '
        Me.Btn_Seguimiento.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Seguimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Seguimiento.Image = Global.SIRCO.My.Resources.Resources.LOG
        Me.Btn_Seguimiento.Location = New System.Drawing.Point(0, 0)
        Me.Btn_Seguimiento.Name = "Btn_Seguimiento"
        Me.Btn_Seguimiento.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Seguimiento.TabIndex = 11
        Me.Btn_Seguimiento.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Seguimiento.UseVisualStyleBackColor = True
        '
        'Btn_Filtro
        '
        Me.Btn_Filtro.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Filtro.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Filtro.Image = Global.SIRCO.My.Resources.Resources.magnifier_zoom_in
        Me.Btn_Filtro.Location = New System.Drawing.Point(1154, 0)
        Me.Btn_Filtro.Name = "Btn_Filtro"
        Me.Btn_Filtro.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Filtro.TabIndex = 4
        Me.Btn_Filtro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Filtro.UseVisualStyleBackColor = True
        '
        'Btn_Imprimir
        '
        Me.Btn_Imprimir.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Imprimir.Enabled = False
        Me.Btn_Imprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Imprimir.Image = Global.SIRCO.My.Resources.Resources.document_print
        Me.Btn_Imprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Imprimir.Location = New System.Drawing.Point(1205, 0)
        Me.Btn_Imprimir.Name = "Btn_Imprimir"
        Me.Btn_Imprimir.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Imprimir.TabIndex = 6
        Me.Btn_Imprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Imprimir.UseVisualStyleBackColor = True
        '
        'Btn_Excel
        '
        Me.Btn_Excel.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Excel.Image = Global.SIRCO.My.Resources.Resources.table_excel
        Me.Btn_Excel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Excel.Location = New System.Drawing.Point(1256, 0)
        Me.Btn_Excel.Name = "Btn_Excel"
        Me.Btn_Excel.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Excel.TabIndex = 5
        Me.Btn_Excel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Excel.UseVisualStyleBackColor = True
        '
        'Btn_Salir
        '
        Me.Btn_Salir.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Salir.Image = Global.SIRCO.My.Resources.Resources.door_out
        Me.Btn_Salir.Location = New System.Drawing.Point(1307, 0)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Salir.TabIndex = 7
        Me.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Salir.UseVisualStyleBackColor = True
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        '
        'sfdRuta
        '
        Me.sfdRuta.Filter = "Archivos Excel | .xls"
        '
        'frmPpalBitacora
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1362, 692)
        Me.Controls.Add(Me.Pnl_Grid)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmPpalBitacora"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Bitácora"
        Me.Pnl_Grid.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMenu.ResumeLayout(False)
        Me.Pnl_Botones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Grid As System.Windows.Forms.Panel
    Friend WithEvents DGrid As System.Windows.Forms.DataGridView
    Friend WithEvents Pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents Btn_Salir As System.Windows.Forms.Button
    Friend WithEvents Btn_Excel As System.Windows.Forms.Button
    Friend WithEvents Btn_Imprimir As System.Windows.Forms.Button
    Friend WithEvents Btn_Filtro As System.Windows.Forms.Button
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents Btn_Seguimiento As System.Windows.Forms.Button
    Friend WithEvents CMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RegistrarSegToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VerSeguimientoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Btn_Fechas As System.Windows.Forms.Button
    Friend WithEvents VerProveedorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Btn_Foto As System.Windows.Forms.Button
    Friend WithEvents ImagenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultaOrdenDeCompraToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PBar As System.Windows.Forms.ProgressBar
    Friend WithEvents Btn_OrdeComp As System.Windows.Forms.Button
    Friend WithEvents ModificarFechasOrdendeCompra As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents AnalisisToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CatalogoModToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Grido As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PBox As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents sfdRuta As SaveFileDialog
End Class
