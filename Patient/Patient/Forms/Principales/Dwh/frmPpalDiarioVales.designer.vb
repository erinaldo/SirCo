<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPpalDiarioVales
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPpalDiarioVales))
        Me.Pnl_Grid = New System.Windows.Forms.Panel()
        Me.Pnl_Bar = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LBL_PORC = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Pbar1 = New System.Windows.Forms.ProgressBar()
        Me.Gridview = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.CMenu1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NuevoProveedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificarProveedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultarProveedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Pnl_Botones = New System.Windows.Forms.Panel()
        Me.Btn_Filtro = New System.Windows.Forms.Button()
        Me.Btn_Imprimir = New System.Windows.Forms.Button()
        Me.Lbl_Sucursal = New System.Windows.Forms.Label()
        Me.Cbo_Sucursal = New System.Windows.Forms.ComboBox()
        Me.Bot_Aceptar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dt_Fin = New System.Windows.Forms.DateTimePicker()
        Me.lbl_Al = New System.Windows.Forms.Label()
        Me.dt_Inicio = New System.Windows.Forms.DateTimePicker()
        Me.lbl_del = New System.Windows.Forms.Label()
        Me.Btn_Excel = New System.Windows.Forms.Button()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.sfdRuta = New System.Windows.Forms.SaveFileDialog()
        Me.Pnl_Grid.SuspendLayout()
        Me.Pnl_Bar.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gridview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMenu1.SuspendLayout()
        Me.Pnl_Botones.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pnl_Grid
        '
        Me.Pnl_Grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Grid.Controls.Add(Me.Pnl_Bar)
        Me.Pnl_Grid.Controls.Add(Me.Gridview)
        Me.Pnl_Grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnl_Grid.Location = New System.Drawing.Point(0, 0)
        Me.Pnl_Grid.Name = "Pnl_Grid"
        Me.Pnl_Grid.Size = New System.Drawing.Size(1028, 460)
        Me.Pnl_Grid.TabIndex = 4
        '
        'Pnl_Bar
        '
        Me.Pnl_Bar.Controls.Add(Me.PictureBox1)
        Me.Pnl_Bar.Controls.Add(Me.LBL_PORC)
        Me.Pnl_Bar.Controls.Add(Me.Label1)
        Me.Pnl_Bar.Controls.Add(Me.Pbar1)
        Me.Pnl_Bar.Location = New System.Drawing.Point(418, 76)
        Me.Pnl_Bar.Name = "Pnl_Bar"
        Me.Pnl_Bar.Size = New System.Drawing.Size(473, 98)
        Me.Pnl_Bar.TabIndex = 1
        Me.Pnl_Bar.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.SIRCO.My.Resources.Resources.ordenador04
        Me.PictureBox1.Location = New System.Drawing.Point(6, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(87, 80)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'LBL_PORC
        '
        Me.LBL_PORC.AutoSize = True
        Me.LBL_PORC.Location = New System.Drawing.Point(245, 69)
        Me.LBL_PORC.Name = "LBL_PORC"
        Me.LBL_PORC.Size = New System.Drawing.Size(39, 13)
        Me.LBL_PORC.TabIndex = 3
        Me.LBL_PORC.Text = "Label2"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(110, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(263, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Espere mientras procesamos la información..."
        '
        'Pbar1
        '
        Me.Pbar1.Location = New System.Drawing.Point(99, 34)
        Me.Pbar1.Name = "Pbar1"
        Me.Pbar1.Size = New System.Drawing.Size(349, 22)
        Me.Pbar1.TabIndex = 1
        '
        'Gridview
        '
        Me.Gridview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Gridview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Gridview.Location = New System.Drawing.Point(0, 0)
        Me.Gridview.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.Gridview.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Gridview.MainView = Me.GridView1
        Me.Gridview.Name = "Gridview"
        Me.Gridview.Size = New System.Drawing.Size(1024, 456)
        Me.Gridview.TabIndex = 2
        Me.Gridview.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1, Me.GridView2})
        '
        'GridView1
        '
        Me.GridView1.AppearancePrint.FilterPanel.BackColor = System.Drawing.Color.White
        Me.GridView1.AppearancePrint.FilterPanel.Options.UseBackColor = True
        Me.GridView1.AppearancePrint.FooterPanel.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GridView1.AppearancePrint.FooterPanel.Options.UseBackColor = True
        Me.GridView1.GridControl = Me.Gridview
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowFooter = True
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.Gridview
        Me.GridView2.Name = "GridView2"
        '
        'CMenu1
        '
        Me.CMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoProveedorToolStripMenuItem, Me.ModificarProveedorToolStripMenuItem, Me.ConsultarProveedorToolStripMenuItem})
        Me.CMenu1.Name = "CMenu1"
        Me.CMenu1.Size = New System.Drawing.Size(183, 70)
        '
        'NuevoProveedorToolStripMenuItem
        '
        Me.NuevoProveedorToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.new_20doc
        Me.NuevoProveedorToolStripMenuItem.Name = "NuevoProveedorToolStripMenuItem"
        Me.NuevoProveedorToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.NuevoProveedorToolStripMenuItem.Text = "Nuevo Proveedor"
        '
        'ModificarProveedorToolStripMenuItem
        '
        Me.ModificarProveedorToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.Editar
        Me.ModificarProveedorToolStripMenuItem.Name = "ModificarProveedorToolStripMenuItem"
        Me.ModificarProveedorToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.ModificarProveedorToolStripMenuItem.Text = "Modificar Proveedor"
        '
        'ConsultarProveedorToolStripMenuItem
        '
        Me.ConsultarProveedorToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.find
        Me.ConsultarProveedorToolStripMenuItem.Name = "ConsultarProveedorToolStripMenuItem"
        Me.ConsultarProveedorToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.ConsultarProveedorToolStripMenuItem.Text = "Consultar Proveedor"
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Btn_Filtro)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Imprimir)
        Me.Pnl_Botones.Controls.Add(Me.Lbl_Sucursal)
        Me.Pnl_Botones.Controls.Add(Me.Cbo_Sucursal)
        Me.Pnl_Botones.Controls.Add(Me.Bot_Aceptar)
        Me.Pnl_Botones.Controls.Add(Me.GroupBox1)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Excel)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Salir)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 460)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(1028, 56)
        Me.Pnl_Botones.TabIndex = 3
        '
        'Btn_Filtro
        '
        Me.Btn_Filtro.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Filtro.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Filtro.Image = Global.SIRCO.My.Resources.Resources.magnifier_zoom_in
        Me.Btn_Filtro.Location = New System.Drawing.Point(820, 0)
        Me.Btn_Filtro.Name = "Btn_Filtro"
        Me.Btn_Filtro.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Filtro.TabIndex = 13
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
        Me.Btn_Imprimir.Location = New System.Drawing.Point(871, 0)
        Me.Btn_Imprimir.Name = "Btn_Imprimir"
        Me.Btn_Imprimir.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Imprimir.TabIndex = 12
        Me.Btn_Imprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Imprimir.UseVisualStyleBackColor = True
        '
        'Lbl_Sucursal
        '
        Me.Lbl_Sucursal.AutoSize = True
        Me.Lbl_Sucursal.Location = New System.Drawing.Point(573, 24)
        Me.Lbl_Sucursal.Name = "Lbl_Sucursal"
        Me.Lbl_Sucursal.Size = New System.Drawing.Size(48, 13)
        Me.Lbl_Sucursal.TabIndex = 10
        Me.Lbl_Sucursal.Text = "Sucursal"
        '
        'Cbo_Sucursal
        '
        Me.Cbo_Sucursal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.Cbo_Sucursal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cbo_Sucursal.FormattingEnabled = True
        Me.Cbo_Sucursal.Items.AddRange(New Object() {"00 - TODAS", "01 - JUAREZ", "02 - HIDALGO", "03 - VICTORIA", "04 - HAMBURGO", "05 - 4 CAMINOS", "06 - TRIANA", "07 - LERDO", "08 - MATRIZ", "33 - CAPA DE OZONO", "34 - OZONO 4 CAMINOS"})
        Me.Cbo_Sucursal.Location = New System.Drawing.Point(627, 21)
        Me.Cbo_Sucursal.MaxDropDownItems = 11
        Me.Cbo_Sucursal.Name = "Cbo_Sucursal"
        Me.Cbo_Sucursal.Size = New System.Drawing.Size(148, 21)
        Me.Cbo_Sucursal.TabIndex = 9
        '
        'Bot_Aceptar
        '
        Me.Bot_Aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bot_Aceptar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Bot_Aceptar.Location = New System.Drawing.Point(497, 1)
        Me.Bot_Aceptar.Name = "Bot_Aceptar"
        Me.Bot_Aceptar.Size = New System.Drawing.Size(51, 52)
        Me.Bot_Aceptar.TabIndex = 1
        Me.Bot_Aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Bot_Aceptar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dt_Fin)
        Me.GroupBox1.Controls.Add(Me.lbl_Al)
        Me.GroupBox1.Controls.Add(Me.dt_Inicio)
        Me.GroupBox1.Controls.Add(Me.lbl_del)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(487, 52)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fechas"
        '
        'dt_Fin
        '
        Me.dt_Fin.Location = New System.Drawing.Point(268, 20)
        Me.dt_Fin.Name = "dt_Fin"
        Me.dt_Fin.Size = New System.Drawing.Size(209, 20)
        Me.dt_Fin.TabIndex = 1
        '
        'lbl_Al
        '
        Me.lbl_Al.AutoSize = True
        Me.lbl_Al.Location = New System.Drawing.Point(247, 24)
        Me.lbl_Al.Name = "lbl_Al"
        Me.lbl_Al.Size = New System.Drawing.Size(18, 13)
        Me.lbl_Al.TabIndex = 11
        Me.lbl_Al.Text = "al:"
        '
        'dt_Inicio
        '
        Me.dt_Inicio.Location = New System.Drawing.Point(36, 20)
        Me.dt_Inicio.Name = "dt_Inicio"
        Me.dt_Inicio.Size = New System.Drawing.Size(209, 20)
        Me.dt_Inicio.TabIndex = 0
        '
        'lbl_del
        '
        Me.lbl_del.AutoSize = True
        Me.lbl_del.Location = New System.Drawing.Point(10, 24)
        Me.lbl_del.Name = "lbl_del"
        Me.lbl_del.Size = New System.Drawing.Size(26, 13)
        Me.lbl_del.TabIndex = 9
        Me.lbl_del.Text = "Del:"
        '
        'Btn_Excel
        '
        Me.Btn_Excel.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Excel.Image = Global.SIRCO.My.Resources.Resources.table_excel
        Me.Btn_Excel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Excel.Location = New System.Drawing.Point(922, 0)
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
        Me.Btn_Salir.Location = New System.Drawing.Point(973, 0)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Salir.TabIndex = 5
        Me.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Salir.UseVisualStyleBackColor = True
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        '
        'sfdRuta
        '
        Me.sfdRuta.Filter = "Archivos Excel | *.xls"
        '
        'frmPpalDiarioVales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 516)
        Me.Controls.Add(Me.Pnl_Grid)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmPpalDiarioVales"
        Me.Text = "Diario de Vales"
        Me.Pnl_Grid.ResumeLayout(False)
        Me.Pnl_Bar.ResumeLayout(False)
        Me.Pnl_Bar.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gridview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMenu1.ResumeLayout(False)
        Me.Pnl_Botones.ResumeLayout(False)
        Me.Pnl_Botones.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Grid As System.Windows.Forms.Panel
    Friend WithEvents Pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents Btn_Salir As System.Windows.Forms.Button
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents CMenu1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NuevoProveedorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ModificarProveedorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultarProveedorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Pnl_Bar As System.Windows.Forms.Panel
    Friend WithEvents LBL_PORC As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Pbar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dt_Fin As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_Al As System.Windows.Forms.Label
    Friend WithEvents dt_Inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_del As System.Windows.Forms.Label
    Friend WithEvents Bot_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Lbl_Sucursal As System.Windows.Forms.Label
    Friend WithEvents Cbo_Sucursal As System.Windows.Forms.ComboBox
    Friend WithEvents Btn_Excel As System.Windows.Forms.Button
    Friend WithEvents Btn_Filtro As System.Windows.Forms.Button
    Friend WithEvents Btn_Imprimir As System.Windows.Forms.Button
    Friend WithEvents Gridview As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents sfdRuta As SaveFileDialog
End Class
