<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPpalreporteVentas
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

    Private Const V As String = "Reporte de Ventas 80/20....."

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPpalreporteVentas))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Pnl_Botones = New System.Windows.Forms.Panel()
        Me.Btn_Regresar = New System.Windows.Forms.Button()
        Me.Btn_Distribs = New System.Windows.Forms.Button()
        Me.Btn_CPersonal = New System.Windows.Forms.Button()
        Me.Lbl_RangoFechas = New System.Windows.Forms.Label()
        Me.Panel_Totales = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_distrib20 = New System.Windows.Forms.TextBox()
        Me.txt_distrib80 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_suma20 = New System.Windows.Forms.TextBox()
        Me.txt_suma = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Btn_Filtro = New System.Windows.Forms.Button()
        Me.Btn_Imprimir = New System.Windows.Forms.Button()
        Me.Btn_Excel = New System.Windows.Forms.Button()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.Pnl_Grid = New System.Windows.Forms.Panel()
        Me.PBox = New System.Windows.Forms.PictureBox()
        Me.DGrid = New System.Windows.Forms.DataGridView()
        Me.CMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NuevoProspectoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificarProspectoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HacerloDistribuidorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsulataProspectoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Pnl_Botones.SuspendLayout()
        Me.Panel_Totales.SuspendLayout()
        Me.Pnl_Grid.SuspendLayout()
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Btn_Regresar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Distribs)
        Me.Pnl_Botones.Controls.Add(Me.Btn_CPersonal)
        Me.Pnl_Botones.Controls.Add(Me.Lbl_RangoFechas)
        Me.Pnl_Botones.Controls.Add(Me.Panel_Totales)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Filtro)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Imprimir)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Excel)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Salir)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 383)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(1109, 56)
        Me.Pnl_Botones.TabIndex = 7
        '
        'Btn_Regresar
        '
        Me.Btn_Regresar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Regresar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Regresar.Image = CType(resources.GetObject("Btn_Regresar.Image"), System.Drawing.Image)
        Me.Btn_Regresar.Location = New System.Drawing.Point(850, 0)
        Me.Btn_Regresar.Name = "Btn_Regresar"
        Me.Btn_Regresar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Regresar.TabIndex = 37
        Me.Btn_Regresar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Regresar.UseVisualStyleBackColor = True
        '
        'Btn_Distribs
        '
        Me.Btn_Distribs.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Distribs.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Distribs.Image = Global.SIRCO.My.Resources.Resources.índice
        Me.Btn_Distribs.Location = New System.Drawing.Point(55, 0)
        Me.Btn_Distribs.Name = "Btn_Distribs"
        Me.Btn_Distribs.Size = New System.Drawing.Size(55, 52)
        Me.Btn_Distribs.TabIndex = 31
        Me.Btn_Distribs.Text = "Distribs"
        Me.Btn_Distribs.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Distribs.UseVisualStyleBackColor = True
        '
        'Btn_CPersonal
        '
        Me.Btn_CPersonal.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_CPersonal.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_CPersonal.Image = Global.SIRCO.My.Resources.Resources.imagess
        Me.Btn_CPersonal.Location = New System.Drawing.Point(0, 0)
        Me.Btn_CPersonal.Name = "Btn_CPersonal"
        Me.Btn_CPersonal.Size = New System.Drawing.Size(55, 52)
        Me.Btn_CPersonal.TabIndex = 30
        Me.Btn_CPersonal.Text = "Empleado"
        Me.Btn_CPersonal.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_CPersonal.UseVisualStyleBackColor = True
        '
        'Lbl_RangoFechas
        '
        Me.Lbl_RangoFechas.AutoSize = True
        Me.Lbl_RangoFechas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_RangoFechas.Location = New System.Drawing.Point(129, 20)
        Me.Lbl_RangoFechas.Name = "Lbl_RangoFechas"
        Me.Lbl_RangoFechas.Size = New System.Drawing.Size(55, 16)
        Me.Lbl_RangoFechas.TabIndex = 29
        Me.Lbl_RangoFechas.Text = "Label3"
        '
        'Panel_Totales
        '
        Me.Panel_Totales.Controls.Add(Me.Label3)
        Me.Panel_Totales.Controls.Add(Me.txt_distrib20)
        Me.Panel_Totales.Controls.Add(Me.txt_distrib80)
        Me.Panel_Totales.Controls.Add(Me.Label4)
        Me.Panel_Totales.Controls.Add(Me.Label2)
        Me.Panel_Totales.Controls.Add(Me.txt_suma20)
        Me.Panel_Totales.Controls.Add(Me.txt_suma)
        Me.Panel_Totales.Controls.Add(Me.Label1)
        Me.Panel_Totales.Location = New System.Drawing.Point(423, 2)
        Me.Panel_Totales.Name = "Panel_Totales"
        Me.Panel_Totales.Size = New System.Drawing.Size(412, 50)
        Me.Panel_Totales.TabIndex = 28
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(223, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 13)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "No. Distribs."
        '
        'txt_distrib20
        '
        Me.txt_distrib20.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txt_distrib20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_distrib20.Location = New System.Drawing.Point(315, 25)
        Me.txt_distrib20.Name = "txt_distrib20"
        Me.txt_distrib20.ReadOnly = True
        Me.txt_distrib20.Size = New System.Drawing.Size(92, 20)
        Me.txt_distrib20.TabIndex = 30
        '
        'txt_distrib80
        '
        Me.txt_distrib80.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txt_distrib80.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_distrib80.Location = New System.Drawing.Point(96, 25)
        Me.txt_distrib80.Name = "txt_distrib80"
        Me.txt_distrib80.ReadOnly = True
        Me.txt_distrib80.Size = New System.Drawing.Size(92, 20)
        Me.txt_distrib80.TabIndex = 28
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(4, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "No. Distribs:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(223, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Suma del 20%"
        '
        'txt_suma20
        '
        Me.txt_suma20.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txt_suma20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_suma20.Location = New System.Drawing.Point(315, 2)
        Me.txt_suma20.Name = "txt_suma20"
        Me.txt_suma20.ReadOnly = True
        Me.txt_suma20.Size = New System.Drawing.Size(92, 20)
        Me.txt_suma20.TabIndex = 26
        Me.txt_suma20.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_suma
        '
        Me.txt_suma.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txt_suma.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_suma.Location = New System.Drawing.Point(96, 2)
        Me.txt_suma.Name = "txt_suma"
        Me.txt_suma.ReadOnly = True
        Me.txt_suma.Size = New System.Drawing.Size(92, 20)
        Me.txt_suma.TabIndex = 24
        Me.txt_suma.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 13)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Suma del 80%"
        '
        'Btn_Filtro
        '
        Me.Btn_Filtro.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Filtro.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Filtro.Image = Global.SIRCO.My.Resources.Resources.magnifier_zoom_in
        Me.Btn_Filtro.Location = New System.Drawing.Point(901, 0)
        Me.Btn_Filtro.Name = "Btn_Filtro"
        Me.Btn_Filtro.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Filtro.TabIndex = 9
        Me.Btn_Filtro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Filtro.UseVisualStyleBackColor = True
        '
        'Btn_Imprimir
        '
        Me.Btn_Imprimir.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Imprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Imprimir.Image = Global.SIRCO.My.Resources.Resources.document_print
        Me.Btn_Imprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Imprimir.Location = New System.Drawing.Point(952, 0)
        Me.Btn_Imprimir.Name = "Btn_Imprimir"
        Me.Btn_Imprimir.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Imprimir.TabIndex = 8
        Me.Btn_Imprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Imprimir.UseVisualStyleBackColor = True
        '
        'Btn_Excel
        '
        Me.Btn_Excel.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Excel.Image = Global.SIRCO.My.Resources.Resources.table_excel
        Me.Btn_Excel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Excel.Location = New System.Drawing.Point(1003, 0)
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
        Me.Btn_Salir.Location = New System.Drawing.Point(1054, 0)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Salir.TabIndex = 5
        Me.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Salir.UseVisualStyleBackColor = True
        '
        'Pnl_Grid
        '
        Me.Pnl_Grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Grid.Controls.Add(Me.PBox)
        Me.Pnl_Grid.Controls.Add(Me.DGrid)
        Me.Pnl_Grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnl_Grid.Location = New System.Drawing.Point(0, 0)
        Me.Pnl_Grid.Name = "Pnl_Grid"
        Me.Pnl_Grid.Size = New System.Drawing.Size(1109, 383)
        Me.Pnl_Grid.TabIndex = 8
        '
        'PBox
        '
        Me.PBox.InitialImage = Nothing
        Me.PBox.Location = New System.Drawing.Point(721, 0)
        Me.PBox.Name = "PBox"
        Me.PBox.Size = New System.Drawing.Size(264, 220)
        Me.PBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBox.TabIndex = 5
        Me.PBox.TabStop = False
        Me.PBox.Visible = False
        '
        'DGrid
        '
        Me.DGrid.AllowUserToAddRows = False
        Me.DGrid.AllowUserToDeleteRows = False
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
        Me.DGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGrid.Location = New System.Drawing.Point(0, 0)
        Me.DGrid.Name = "DGrid"
        Me.DGrid.ReadOnly = True
        Me.DGrid.Size = New System.Drawing.Size(1105, 379)
        Me.DGrid.TabIndex = 0
        '
        'CMenuStrip1
        '
        Me.CMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoProspectoToolStripMenuItem, Me.ModificarProspectoToolStripMenuItem, Me.HacerloDistribuidorToolStripMenuItem, Me.ConsulataProspectoToolStripMenuItem})
        Me.CMenuStrip1.Name = "ContextMenuStrip1"
        Me.CMenuStrip1.Size = New System.Drawing.Size(184, 92)
        '
        'NuevoProspectoToolStripMenuItem
        '
        Me.NuevoProspectoToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.new_20doc
        Me.NuevoProspectoToolStripMenuItem.Name = "NuevoProspectoToolStripMenuItem"
        Me.NuevoProspectoToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.NuevoProspectoToolStripMenuItem.Text = "Nuevo Prospecto"
        '
        'ModificarProspectoToolStripMenuItem
        '
        Me.ModificarProspectoToolStripMenuItem.CheckOnClick = True
        Me.ModificarProspectoToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.mime_txt
        Me.ModificarProspectoToolStripMenuItem.Name = "ModificarProspectoToolStripMenuItem"
        Me.ModificarProspectoToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.ModificarProspectoToolStripMenuItem.Text = "Modificar Prospecto"
        '
        'HacerloDistribuidorToolStripMenuItem
        '
        Me.HacerloDistribuidorToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.invertir
        Me.HacerloDistribuidorToolStripMenuItem.Name = "HacerloDistribuidorToolStripMenuItem"
        Me.HacerloDistribuidorToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.HacerloDistribuidorToolStripMenuItem.Text = "Hacerlo Distribuidor"
        '
        'ConsulataProspectoToolStripMenuItem
        '
        Me.ConsulataProspectoToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.find
        Me.ConsulataProspectoToolStripMenuItem.Name = "ConsulataProspectoToolStripMenuItem"
        Me.ConsulataProspectoToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.ConsulataProspectoToolStripMenuItem.Text = "Consulata Prospecto"
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        '
        'frmPpalreporteVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1109, 439)
        Me.Controls.Add(Me.Pnl_Grid)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.KeyPreview = True
        Me.Name = "frmPpalreporteVentas"
        Me.Text = V
        Me.Pnl_Botones.ResumeLayout(False)
        Me.Pnl_Botones.PerformLayout()
        Me.Panel_Totales.ResumeLayout(False)
        Me.Panel_Totales.PerformLayout()
        Me.Pnl_Grid.ResumeLayout(False)
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents Btn_Filtro As System.Windows.Forms.Button
    Friend WithEvents Btn_Imprimir As System.Windows.Forms.Button
    Friend WithEvents Btn_Excel As System.Windows.Forms.Button
    Friend WithEvents Btn_Salir As System.Windows.Forms.Button
    Friend WithEvents Pnl_Grid As System.Windows.Forms.Panel
    Friend WithEvents DGrid As System.Windows.Forms.DataGridView
    Friend WithEvents CMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NuevoProspectoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ModificarProspectoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HacerloDistribuidorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsulataProspectoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents PBox As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_suma As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_suma20 As System.Windows.Forms.TextBox
    Friend WithEvents Panel_Totales As System.Windows.Forms.Panel
    Friend WithEvents Lbl_RangoFechas As System.Windows.Forms.Label
    Friend WithEvents Btn_Distribs As System.Windows.Forms.Button
    Friend WithEvents Btn_CPersonal As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_distrib20 As System.Windows.Forms.TextBox
    Friend WithEvents txt_distrib80 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Btn_Regresar As System.Windows.Forms.Button
End Class
