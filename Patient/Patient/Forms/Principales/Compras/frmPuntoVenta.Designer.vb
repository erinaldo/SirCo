<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPuntoVenta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPuntoVenta))
        Me.Pnl_Pie = New System.Windows.Forms.Panel()
        Me.Pnl_Encabezado1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Txt_Serie = New DevExpress.XtraEditors.TextEdit()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Pnl_Encabezado = New System.Windows.Forms.Panel()
        Me.Lbl_Sucursal = New System.Windows.Forms.Label()
        Me.Lbl_Fum = New System.Windows.Forms.Label()
        Me.Lbl_Cajero = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Lbl_Vendedor = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Pnl_Grid = New System.Windows.Forms.Panel()
        Me.Pnl_AtrasGrid = New System.Windows.Forms.Panel()
        Me.DGrid = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Pnl_Imagen = New System.Windows.Forms.Panel()
        Me.Pnl_Totales = New System.Windows.Forms.Panel()
        Me.Txt_Total = New System.Windows.Forms.TextBox()
        Me.Txt_Descuento = New System.Windows.Forms.TextBox()
        Me.Txt_Subtotal = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Pbox_Articulo = New DevExpress.XtraEditors.PictureEdit()
        Me.TFum = New System.Windows.Forms.Timer(Me.components)
        Me.Btn_Comprar = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.TextEdit1 = New DevExpress.XtraEditors.TextEdit()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.Pnl_Pie.SuspendLayout()
        Me.Pnl_Encabezado1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.Txt_Serie.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_Encabezado.SuspendLayout()
        Me.Pnl_Grid.SuspendLayout()
        Me.Pnl_AtrasGrid.SuspendLayout()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_Imagen.SuspendLayout()
        Me.Pnl_Totales.SuspendLayout()
        CType(Me.Pbox_Articulo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pnl_Pie
        '
        Me.Pnl_Pie.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Pie.Controls.Add(Me.SimpleButton2)
        Me.Pnl_Pie.Controls.Add(Me.TextEdit1)
        Me.Pnl_Pie.Controls.Add(Me.SimpleButton1)
        Me.Pnl_Pie.Controls.Add(Me.Btn_Comprar)
        Me.Pnl_Pie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Pie.Location = New System.Drawing.Point(0, 644)
        Me.Pnl_Pie.Name = "Pnl_Pie"
        Me.Pnl_Pie.Size = New System.Drawing.Size(1177, 82)
        Me.Pnl_Pie.TabIndex = 4
        '
        'Pnl_Encabezado1
        '
        Me.Pnl_Encabezado1.Controls.Add(Me.Panel3)
        Me.Pnl_Encabezado1.Controls.Add(Me.Pnl_Encabezado)
        Me.Pnl_Encabezado1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pnl_Encabezado1.Location = New System.Drawing.Point(0, 0)
        Me.Pnl_Encabezado1.Name = "Pnl_Encabezado1"
        Me.Pnl_Encabezado1.Size = New System.Drawing.Size(1177, 85)
        Me.Pnl_Encabezado1.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Txt_Serie)
        Me.Panel3.Controls.Add(Me.PictureBox1)
        Me.Panel3.Location = New System.Drawing.Point(-1, 1)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(329, 82)
        Me.Panel3.TabIndex = 2
        '
        'Txt_Serie
        '
        Me.Txt_Serie.Location = New System.Drawing.Point(76, 16)
        Me.Txt_Serie.Name = "Txt_Serie"
        Me.Txt_Serie.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Serie.Properties.Appearance.Options.UseFont = True
        Me.Txt_Serie.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.Txt_Serie.Properties.MaxLength = 13
        Me.Txt_Serie.Size = New System.Drawing.Size(238, 32)
        Me.Txt_Serie.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.SIRCO.My.Resources.Resources.barcode
        Me.PictureBox1.Location = New System.Drawing.Point(9, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(61, 45)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Pnl_Encabezado
        '
        Me.Pnl_Encabezado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Encabezado.Controls.Add(Me.Lbl_Sucursal)
        Me.Pnl_Encabezado.Controls.Add(Me.Lbl_Fum)
        Me.Pnl_Encabezado.Controls.Add(Me.Lbl_Cajero)
        Me.Pnl_Encabezado.Controls.Add(Me.Label3)
        Me.Pnl_Encabezado.Controls.Add(Me.Lbl_Vendedor)
        Me.Pnl_Encabezado.Controls.Add(Me.Label1)
        Me.Pnl_Encabezado.Dock = System.Windows.Forms.DockStyle.Right
        Me.Pnl_Encabezado.Location = New System.Drawing.Point(334, 0)
        Me.Pnl_Encabezado.Name = "Pnl_Encabezado"
        Me.Pnl_Encabezado.Size = New System.Drawing.Size(843, 85)
        Me.Pnl_Encabezado.TabIndex = 3
        '
        'Lbl_Sucursal
        '
        Me.Lbl_Sucursal.AutoSize = True
        Me.Lbl_Sucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Sucursal.Location = New System.Drawing.Point(646, 43)
        Me.Lbl_Sucursal.Name = "Lbl_Sucursal"
        Me.Lbl_Sucursal.Size = New System.Drawing.Size(33, 13)
        Me.Lbl_Sucursal.TabIndex = 5
        Me.Lbl_Sucursal.Text = "Suc."
        '
        'Lbl_Fum
        '
        Me.Lbl_Fum.AutoSize = True
        Me.Lbl_Fum.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Fum.Location = New System.Drawing.Point(646, 21)
        Me.Lbl_Fum.Name = "Lbl_Fum"
        Me.Lbl_Fum.Size = New System.Drawing.Size(54, 13)
        Me.Lbl_Fum.TabIndex = 4
        Me.Lbl_Fum.Text = "Lbl_Fum"
        '
        'Lbl_Cajero
        '
        Me.Lbl_Cajero.AutoSize = True
        Me.Lbl_Cajero.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Cajero.Location = New System.Drawing.Point(221, 41)
        Me.Lbl_Cajero.Name = "Lbl_Cajero"
        Me.Lbl_Cajero.Size = New System.Drawing.Size(67, 15)
        Me.Lbl_Cajero.TabIndex = 3
        Me.Lbl_Cajero.Text = "Cajero(a)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(150, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Cajero(a)"
        '
        'Lbl_Vendedor
        '
        Me.Lbl_Vendedor.AutoSize = True
        Me.Lbl_Vendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Vendedor.Location = New System.Drawing.Point(221, 16)
        Me.Lbl_Vendedor.Name = "Lbl_Vendedor"
        Me.Lbl_Vendedor.Size = New System.Drawing.Size(86, 15)
        Me.Lbl_Vendedor.TabIndex = 1
        Me.Lbl_Vendedor.Text = "Vendedor(a)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(150, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Vendedor(a)"
        '
        'Pnl_Grid
        '
        Me.Pnl_Grid.Controls.Add(Me.Pnl_AtrasGrid)
        Me.Pnl_Grid.Controls.Add(Me.Pnl_Imagen)
        Me.Pnl_Grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnl_Grid.Location = New System.Drawing.Point(0, 85)
        Me.Pnl_Grid.Name = "Pnl_Grid"
        Me.Pnl_Grid.Size = New System.Drawing.Size(1177, 559)
        Me.Pnl_Grid.TabIndex = 5
        '
        'Pnl_AtrasGrid
        '
        Me.Pnl_AtrasGrid.Controls.Add(Me.DGrid)
        Me.Pnl_AtrasGrid.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pnl_AtrasGrid.Location = New System.Drawing.Point(0, 0)
        Me.Pnl_AtrasGrid.Name = "Pnl_AtrasGrid"
        Me.Pnl_AtrasGrid.Size = New System.Drawing.Size(770, 546)
        Me.Pnl_AtrasGrid.TabIndex = 7
        '
        'DGrid
        '
        Me.DGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGrid.Location = New System.Drawing.Point(0, 0)
        Me.DGrid.MainView = Me.GridView1
        Me.DGrid.Name = "DGrid"
        Me.DGrid.Size = New System.Drawing.Size(770, 546)
        Me.DGrid.TabIndex = 2
        Me.DGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView1.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.White
        Me.GridView1.Appearance.HorzLine.BackColor2 = System.Drawing.Color.White
        Me.GridView1.Appearance.HorzLine.Options.UseBackColor = True
        Me.GridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.White
        Me.GridView1.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.White
        Me.GridView1.Appearance.SelectedRow.Options.UseForeColor = True
        Me.GridView1.Appearance.VertLine.BackColor = System.Drawing.Color.White
        Me.GridView1.Appearance.VertLine.BackColor2 = System.Drawing.Color.White
        Me.GridView1.Appearance.VertLine.Options.UseBackColor = True
        Me.GridView1.GridControl = Me.DGrid
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.ReadOnly = True
        Me.GridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'Pnl_Imagen
        '
        Me.Pnl_Imagen.Controls.Add(Me.Pnl_Totales)
        Me.Pnl_Imagen.Controls.Add(Me.Pbox_Articulo)
        Me.Pnl_Imagen.Dock = System.Windows.Forms.DockStyle.Right
        Me.Pnl_Imagen.Location = New System.Drawing.Point(770, 0)
        Me.Pnl_Imagen.Name = "Pnl_Imagen"
        Me.Pnl_Imagen.Size = New System.Drawing.Size(407, 559)
        Me.Pnl_Imagen.TabIndex = 6
        '
        'Pnl_Totales
        '
        Me.Pnl_Totales.Controls.Add(Me.Txt_Total)
        Me.Pnl_Totales.Controls.Add(Me.Txt_Descuento)
        Me.Pnl_Totales.Controls.Add(Me.Txt_Subtotal)
        Me.Pnl_Totales.Controls.Add(Me.Label5)
        Me.Pnl_Totales.Controls.Add(Me.Label4)
        Me.Pnl_Totales.Controls.Add(Me.Label2)
        Me.Pnl_Totales.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Totales.Location = New System.Drawing.Point(0, 383)
        Me.Pnl_Totales.Name = "Pnl_Totales"
        Me.Pnl_Totales.Size = New System.Drawing.Size(407, 176)
        Me.Pnl_Totales.TabIndex = 2
        '
        'Txt_Total
        '
        Me.Txt_Total.BackColor = System.Drawing.SystemColors.Control
        Me.Txt_Total.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Total.ForeColor = System.Drawing.Color.Navy
        Me.Txt_Total.Location = New System.Drawing.Point(230, 117)
        Me.Txt_Total.Name = "Txt_Total"
        Me.Txt_Total.Size = New System.Drawing.Size(148, 44)
        Me.Txt_Total.TabIndex = 7
        Me.Txt_Total.Text = "0.0"
        Me.Txt_Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txt_Descuento
        '
        Me.Txt_Descuento.BackColor = System.Drawing.SystemColors.Control
        Me.Txt_Descuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Descuento.Location = New System.Drawing.Point(230, 69)
        Me.Txt_Descuento.Name = "Txt_Descuento"
        Me.Txt_Descuento.Size = New System.Drawing.Size(148, 35)
        Me.Txt_Descuento.TabIndex = 6
        Me.Txt_Descuento.Text = "0.0"
        Me.Txt_Descuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txt_Subtotal
        '
        Me.Txt_Subtotal.BackColor = System.Drawing.SystemColors.Control
        Me.Txt_Subtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Subtotal.Location = New System.Drawing.Point(230, 22)
        Me.Txt_Subtotal.Name = "Txt_Subtotal"
        Me.Txt_Subtotal.Size = New System.Drawing.Size(148, 35)
        Me.Txt_Subtotal.TabIndex = 5
        Me.Txt_Subtotal.Text = "0.0"
        Me.Txt_Subtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Navy
        Me.Label5.Location = New System.Drawing.Point(9, 124)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(127, 37)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "TOTAL"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 29)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "DESC."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(149, 29)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "SUBTOTAL"
        '
        'Pbox_Articulo
        '
        Me.Pbox_Articulo.EditValue = Global.SIRCO.My.Resources.Resources.ZAPATERIA_TORREON
        Me.Pbox_Articulo.Location = New System.Drawing.Point(8, 3)
        Me.Pbox_Articulo.Name = "Pbox_Articulo"
        Me.Pbox_Articulo.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.Pbox_Articulo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.Pbox_Articulo.Size = New System.Drawing.Size(395, 352)
        Me.Pbox_Articulo.TabIndex = 0
        '
        'TFum
        '
        '
        'Btn_Comprar
        '
        Me.Btn_Comprar.ImageOptions.Image = CType(resources.GetObject("Btn_Comprar.ImageOptions.Image"), System.Drawing.Image)
        Me.Btn_Comprar.Location = New System.Drawing.Point(983, 13)
        Me.Btn_Comprar.Name = "Btn_Comprar"
        Me.Btn_Comprar.Size = New System.Drawing.Size(131, 62)
        Me.Btn_Comprar.TabIndex = 9
        '
        'SimpleButton1
        '
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(20, 13)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(74, 62)
        Me.SimpleButton1.TabIndex = 10
        '
        'TextEdit1
        '
        Me.TextEdit1.Location = New System.Drawing.Point(126, 32)
        Me.TextEdit1.Name = "TextEdit1"
        Me.TextEdit1.Size = New System.Drawing.Size(254, 20)
        Me.TextEdit1.TabIndex = 11
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton2.Appearance.Options.UseFont = True
        Me.SimpleButton2.ImageOptions.Image = CType(resources.GetObject("SimpleButton2.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton2.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.SimpleButton2.Location = New System.Drawing.Point(549, 13)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(219, 62)
        Me.SimpleButton2.TabIndex = 12
        Me.SimpleButton2.Text = "Descuento Especial"
        '
        'frmPuntoVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1177, 726)
        Me.Controls.Add(Me.Pnl_Grid)
        Me.Controls.Add(Me.Pnl_Encabezado1)
        Me.Controls.Add(Me.Pnl_Pie)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPuntoVenta"
        Me.Text = "Punto de Venta"
        Me.Pnl_Pie.ResumeLayout(False)
        Me.Pnl_Encabezado1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.Txt_Serie.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_Encabezado.ResumeLayout(False)
        Me.Pnl_Encabezado.PerformLayout()
        Me.Pnl_Grid.ResumeLayout(False)
        Me.Pnl_AtrasGrid.ResumeLayout(False)
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_Imagen.ResumeLayout(False)
        Me.Pnl_Totales.ResumeLayout(False)
        Me.Pnl_Totales.PerformLayout()
        CType(Me.Pbox_Articulo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Pie As Panel
    Friend WithEvents Pnl_Encabezado1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Pnl_Encabezado As Panel
    Friend WithEvents Lbl_Sucursal As Label
    Friend WithEvents Lbl_Fum As Label
    Friend WithEvents Lbl_Cajero As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Lbl_Vendedor As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Pnl_Grid As Panel
    Friend WithEvents Pnl_Imagen As Panel
    Friend WithEvents Pnl_Totales As Panel
    Friend WithEvents Txt_Total As TextBox
    Friend WithEvents Txt_Descuento As TextBox
    Friend WithEvents Txt_Subtotal As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Pbox_Articulo As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents Pnl_AtrasGrid As Panel
    Friend WithEvents TFum As Timer
    Friend WithEvents DGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Txt_Serie As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TextEdit1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_Comprar As DevExpress.XtraEditors.SimpleButton
End Class
