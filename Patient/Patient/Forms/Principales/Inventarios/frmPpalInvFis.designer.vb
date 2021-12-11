<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPpalInvFis
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPpalInvFis))
        Me.Pnl_Grid = New System.Windows.Forms.Panel()
        Me.PBox = New System.Windows.Forms.PictureBox()
        Me.DGrid = New System.Windows.Forms.DataGridView()
        Me.MenuAct = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ModificarActEmpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultarActEmpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProcesoActEmpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CancelarActEmpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RealizadoActEmpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Pnl_Botones = New System.Windows.Forms.Panel()
        Me.Lbl_Leyenda1 = New System.Windows.Forms.Label()
        Me.Btn_Aceptar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Btn_ImprimirRpt = New System.Windows.Forms.Button()
        Me.Btn_Filtro = New System.Windows.Forms.Button()
        Me.Btn_Excel = New System.Windows.Forms.Button()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.Btn_Abrir = New System.Windows.Forms.Button()
        Me.Txt_DescripSucursal = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Txt_Sucursal = New System.Windows.Forms.TextBox()
        Me.P_Bar1 = New System.Windows.Forms.ProgressBar()
        Me.Btn_Layout = New System.Windows.Forms.Button()
        Me.Lbl_Leyenda = New System.Windows.Forms.Label()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Pnl_Grid.SuspendLayout()
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuAct.SuspendLayout()
        Me.Pnl_Botones.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pnl_Grid
        '
        Me.Pnl_Grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Grid.Controls.Add(Me.PBox)
        Me.Pnl_Grid.Controls.Add(Me.DGrid)
        Me.Pnl_Grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnl_Grid.Location = New System.Drawing.Point(0, 0)
        Me.Pnl_Grid.Name = "Pnl_Grid"
        Me.Pnl_Grid.Size = New System.Drawing.Size(830, 410)
        Me.Pnl_Grid.TabIndex = 4
        '
        'PBox
        '
        Me.PBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PBox.Location = New System.Drawing.Point(623, 223)
        Me.PBox.Name = "PBox"
        Me.PBox.Size = New System.Drawing.Size(193, 162)
        Me.PBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBox.TabIndex = 58
        Me.PBox.TabStop = False
        Me.PBox.Visible = False
        '
        'DGrid
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.PowderBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGrid.ContextMenuStrip = Me.MenuAct
        Me.DGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGrid.Location = New System.Drawing.Point(0, 0)
        Me.DGrid.Name = "DGrid"
        Me.DGrid.Size = New System.Drawing.Size(826, 406)
        Me.DGrid.TabIndex = 0
        '
        'MenuAct
        '
        Me.MenuAct.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ModificarActEmpToolStripMenuItem, Me.ConsultarActEmpToolStripMenuItem, Me.ProcesoActEmpToolStripMenuItem, Me.CancelarActEmpToolStripMenuItem, Me.RealizadoActEmpToolStripMenuItem})
        Me.MenuAct.Name = "CMenu1"
        Me.MenuAct.Size = New System.Drawing.Size(220, 114)
        '
        'ModificarActEmpToolStripMenuItem
        '
        Me.ModificarActEmpToolStripMenuItem.Checked = True
        Me.ModificarActEmpToolStripMenuItem.CheckOnClick = True
        Me.ModificarActEmpToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ModificarActEmpToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.Editar
        Me.ModificarActEmpToolStripMenuItem.Name = "ModificarActEmpToolStripMenuItem"
        Me.ModificarActEmpToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.ModificarActEmpToolStripMenuItem.Text = "Modificar Actividad"
        '
        'ConsultarActEmpToolStripMenuItem
        '
        Me.ConsultarActEmpToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.find
        Me.ConsultarActEmpToolStripMenuItem.Name = "ConsultarActEmpToolStripMenuItem"
        Me.ConsultarActEmpToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.ConsultarActEmpToolStripMenuItem.Text = "Consultar Actividad"
        '
        'ProcesoActEmpToolStripMenuItem
        '
        Me.ProcesoActEmpToolStripMenuItem.Image = CType(resources.GetObject("ProcesoActEmpToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ProcesoActEmpToolStripMenuItem.Name = "ProcesoActEmpToolStripMenuItem"
        Me.ProcesoActEmpToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.ProcesoActEmpToolStripMenuItem.Text = "Poner Actividad en Proceso"
        '
        'CancelarActEmpToolStripMenuItem
        '
        Me.CancelarActEmpToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.cancel
        Me.CancelarActEmpToolStripMenuItem.Name = "CancelarActEmpToolStripMenuItem"
        Me.CancelarActEmpToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.CancelarActEmpToolStripMenuItem.Text = "Cancelar Actividad"
        '
        'RealizadoActEmpToolStripMenuItem
        '
        Me.RealizadoActEmpToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.RealizadoActEmpToolStripMenuItem.Name = "RealizadoActEmpToolStripMenuItem"
        Me.RealizadoActEmpToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.RealizadoActEmpToolStripMenuItem.Text = "Finalizar Actividad"
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Lbl_Leyenda1)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Aceptar)
        Me.Pnl_Botones.Controls.Add(Me.Panel1)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Abrir)
        Me.Pnl_Botones.Controls.Add(Me.Txt_DescripSucursal)
        Me.Pnl_Botones.Controls.Add(Me.Label3)
        Me.Pnl_Botones.Controls.Add(Me.Txt_Sucursal)
        Me.Pnl_Botones.Controls.Add(Me.P_Bar1)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Layout)
        Me.Pnl_Botones.Controls.Add(Me.Lbl_Leyenda)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 410)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(830, 106)
        Me.Pnl_Botones.TabIndex = 3
        '
        'Lbl_Leyenda1
        '
        Me.Lbl_Leyenda1.AutoSize = True
        Me.Lbl_Leyenda1.Location = New System.Drawing.Point(14, 84)
        Me.Lbl_Leyenda1.Name = "Lbl_Leyenda1"
        Me.Lbl_Leyenda1.Size = New System.Drawing.Size(0, 13)
        Me.Lbl_Leyenda1.TabIndex = 116
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Enabled = False
        Me.Btn_Aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Aceptar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_Aceptar.Location = New System.Drawing.Point(372, 0)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Aceptar.TabIndex = 115
        Me.Btn_Aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Aceptar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Btn_ImprimirRpt)
        Me.Panel1.Controls.Add(Me.Btn_Filtro)
        Me.Panel1.Controls.Add(Me.Btn_Excel)
        Me.Panel1.Controls.Add(Me.Btn_Salir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(608, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(218, 102)
        Me.Panel1.TabIndex = 114
        '
        'Btn_ImprimirRpt
        '
        Me.Btn_ImprimirRpt.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_ImprimirRpt.Image = Global.SIRCO.My.Resources.Resources.document_print
        Me.Btn_ImprimirRpt.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_ImprimirRpt.Location = New System.Drawing.Point(7, -5)
        Me.Btn_ImprimirRpt.Name = "Btn_ImprimirRpt"
        Me.Btn_ImprimirRpt.Size = New System.Drawing.Size(51, 52)
        Me.Btn_ImprimirRpt.TabIndex = 20
        Me.Btn_ImprimirRpt.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_ImprimirRpt.UseVisualStyleBackColor = True
        '
        'Btn_Filtro
        '
        Me.Btn_Filtro.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Filtro.Image = Global.SIRCO.My.Resources.Resources.magnifier_zoom_in
        Me.Btn_Filtro.Location = New System.Drawing.Point(58, -5)
        Me.Btn_Filtro.Name = "Btn_Filtro"
        Me.Btn_Filtro.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Filtro.TabIndex = 17
        Me.Btn_Filtro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Filtro.UseVisualStyleBackColor = True
        '
        'Btn_Excel
        '
        Me.Btn_Excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Excel.Image = Global.SIRCO.My.Resources.Resources.table_excel
        Me.Btn_Excel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Excel.Location = New System.Drawing.Point(109, -5)
        Me.Btn_Excel.Name = "Btn_Excel"
        Me.Btn_Excel.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Excel.TabIndex = 19
        Me.Btn_Excel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Excel.UseVisualStyleBackColor = True
        '
        'Btn_Salir
        '
        Me.Btn_Salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Salir.Image = Global.SIRCO.My.Resources.Resources.door_out
        Me.Btn_Salir.Location = New System.Drawing.Point(160, -5)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Salir.TabIndex = 18
        Me.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Salir.UseVisualStyleBackColor = True
        '
        'Btn_Abrir
        '
        Me.Btn_Abrir.Enabled = False
        Me.Btn_Abrir.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Abrir.Image = Global.SIRCO.My.Resources.Resources.document_open
        Me.Btn_Abrir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Abrir.Location = New System.Drawing.Point(315, 0)
        Me.Btn_Abrir.Name = "Btn_Abrir"
        Me.Btn_Abrir.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Abrir.TabIndex = 113
        Me.Btn_Abrir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Abrir.UseVisualStyleBackColor = True
        '
        'Txt_DescripSucursal
        '
        Me.Txt_DescripSucursal.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripSucursal.Enabled = False
        Me.Txt_DescripSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripSucursal.Location = New System.Drawing.Point(113, 14)
        Me.Txt_DescripSucursal.MaxLength = 200
        Me.Txt_DescripSucursal.Name = "Txt_DescripSucursal"
        Me.Txt_DescripSucursal.ReadOnly = True
        Me.Txt_DescripSucursal.Size = New System.Drawing.Size(139, 22)
        Me.Txt_DescripSucursal.TabIndex = 111
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 112
        Me.Label3.Text = "Sucursal"
        '
        'Txt_Sucursal
        '
        Me.Txt_Sucursal.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Sucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Sucursal.Location = New System.Drawing.Point(70, 14)
        Me.Txt_Sucursal.MaxLength = 2
        Me.Txt_Sucursal.Name = "Txt_Sucursal"
        Me.Txt_Sucursal.Size = New System.Drawing.Size(37, 22)
        Me.Txt_Sucursal.TabIndex = 110
        '
        'P_Bar1
        '
        Me.P_Bar1.Location = New System.Drawing.Point(10, 54)
        Me.P_Bar1.Name = "P_Bar1"
        Me.P_Bar1.Size = New System.Drawing.Size(465, 23)
        Me.P_Bar1.TabIndex = 19
        '
        'Btn_Layout
        '
        Me.Btn_Layout.Enabled = False
        Me.Btn_Layout.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Layout.Image = Global.SIRCO.My.Resources.Resources.LAYOUTBANCO
        Me.Btn_Layout.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Layout.Location = New System.Drawing.Point(258, 0)
        Me.Btn_Layout.Name = "Btn_Layout"
        Me.Btn_Layout.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Layout.TabIndex = 18
        Me.Btn_Layout.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Layout.UseVisualStyleBackColor = True
        '
        'Lbl_Leyenda
        '
        Me.Lbl_Leyenda.AutoSize = True
        Me.Lbl_Leyenda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Leyenda.Location = New System.Drawing.Point(10, 82)
        Me.Lbl_Leyenda.Name = "Lbl_Leyenda"
        Me.Lbl_Leyenda.Size = New System.Drawing.Size(0, 13)
        Me.Lbl_Leyenda.TabIndex = 17
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        '
        'frmPpalInvFis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(830, 516)
        Me.Controls.Add(Me.Pnl_Grid)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmPpalInvFis"
        Me.Text = "Inventario Físico"
        Me.Pnl_Grid.ResumeLayout(False)
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuAct.ResumeLayout(False)
        Me.Pnl_Botones.ResumeLayout(False)
        Me.Pnl_Botones.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Grid As System.Windows.Forms.Panel
    Friend WithEvents DGrid As System.Windows.Forms.DataGridView
    Friend WithEvents Pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents MenuAct As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ModificarActEmpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultarActEmpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProcesoActEmpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CancelarActEmpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RealizadoActEmpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Lbl_Leyenda As System.Windows.Forms.Label
    Friend WithEvents Btn_Layout As System.Windows.Forms.Button
    Friend WithEvents P_Bar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Txt_DescripSucursal As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Txt_Sucursal As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Btn_ImprimirRpt As System.Windows.Forms.Button
    Friend WithEvents Btn_Filtro As System.Windows.Forms.Button
    Friend WithEvents Btn_Excel As System.Windows.Forms.Button
    Friend WithEvents Btn_Salir As System.Windows.Forms.Button
    Friend WithEvents Btn_Abrir As System.Windows.Forms.Button
    Friend WithEvents Btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents PBox As System.Windows.Forms.PictureBox
    Friend WithEvents Lbl_Leyenda1 As System.Windows.Forms.Label
End Class
