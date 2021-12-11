<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImprimirSeries
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImprimirSeries))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Pnl_Edicion = New System.Windows.Forms.Panel()
        Me.Btn_SeriesM = New System.Windows.Forms.Button()
        Me.Btn_Limpiar = New System.Windows.Forms.Button()
        Me.Txt_IdFolioBulto = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Btn_Filtro = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txt_Serie2 = New System.Windows.Forms.TextBox()
        Me.Lbl_Leyenda = New System.Windows.Forms.Label()
        Me.PBar1 = New System.Windows.Forms.ProgressBar()
        Me.Btn_Series = New System.Windows.Forms.Button()
        Me.Btn_Cancelar = New System.Windows.Forms.Button()
        Me.Btn_Excel = New System.Windows.Forms.Button()
        Me.Txt_Serie1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DGrid = New System.Windows.Forms.DataGridView()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Pnl_Edicion.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pnl_Edicion
        '
        Me.Pnl_Edicion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Edicion.Controls.Add(Me.Btn_SeriesM)
        Me.Pnl_Edicion.Controls.Add(Me.Btn_Limpiar)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_IdFolioBulto)
        Me.Pnl_Edicion.Controls.Add(Me.Label3)
        Me.Pnl_Edicion.Controls.Add(Me.Btn_Filtro)
        Me.Pnl_Edicion.Controls.Add(Me.Label2)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Serie2)
        Me.Pnl_Edicion.Controls.Add(Me.Lbl_Leyenda)
        Me.Pnl_Edicion.Controls.Add(Me.PBar1)
        Me.Pnl_Edicion.Controls.Add(Me.Btn_Series)
        Me.Pnl_Edicion.Controls.Add(Me.Btn_Cancelar)
        Me.Pnl_Edicion.Controls.Add(Me.Btn_Excel)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Serie1)
        Me.Pnl_Edicion.Controls.Add(Me.Label1)
        Me.Pnl_Edicion.Location = New System.Drawing.Point(6, 12)
        Me.Pnl_Edicion.Name = "Pnl_Edicion"
        Me.Pnl_Edicion.Size = New System.Drawing.Size(672, 95)
        Me.Pnl_Edicion.TabIndex = 0
        '
        'Btn_SeriesM
        '
        Me.Btn_SeriesM.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_SeriesM.Image = CType(resources.GetObject("Btn_SeriesM.Image"), System.Drawing.Image)
        Me.Btn_SeriesM.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_SeriesM.Location = New System.Drawing.Point(591, 59)
        Me.Btn_SeriesM.Name = "Btn_SeriesM"
        Me.Btn_SeriesM.Size = New System.Drawing.Size(51, 52)
        Me.Btn_SeriesM.TabIndex = 47
        Me.Btn_SeriesM.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip.SetToolTip(Me.Btn_SeriesM, "Imprimir Serie")
        Me.Btn_SeriesM.UseVisualStyleBackColor = True
        Me.Btn_SeriesM.Visible = False
        '
        'Btn_Limpiar
        '
        Me.Btn_Limpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Limpiar.Image = Global.SIRCO.My.Resources.Resources.LIMPIAR_FILTROS
        Me.Btn_Limpiar.Location = New System.Drawing.Point(382, 6)
        Me.Btn_Limpiar.Name = "Btn_Limpiar"
        Me.Btn_Limpiar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Limpiar.TabIndex = 46
        Me.Btn_Limpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip.SetToolTip(Me.Btn_Limpiar, "Limpiar Datos")
        Me.Btn_Limpiar.UseVisualStyleBackColor = True
        '
        'Txt_IdFolioBulto
        '
        Me.Txt_IdFolioBulto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdFolioBulto.Location = New System.Drawing.Point(88, 34)
        Me.Txt_IdFolioBulto.MaxLength = 8
        Me.Txt_IdFolioBulto.Name = "Txt_IdFolioBulto"
        Me.Txt_IdFolioBulto.Size = New System.Drawing.Size(100, 20)
        Me.Txt_IdFolioBulto.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "Folio de Bulto"
        '
        'Btn_Filtro
        '
        Me.Btn_Filtro.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Filtro.Image = Global.SIRCO.My.Resources.Resources.magnifier_zoom_in
        Me.Btn_Filtro.Location = New System.Drawing.Point(438, 6)
        Me.Btn_Filtro.Name = "Btn_Filtro"
        Me.Btn_Filtro.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Filtro.TabIndex = 3
        Me.Btn_Filtro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip.SetToolTip(Me.Btn_Filtro, "Buscar Serie")
        Me.Btn_Filtro.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(171, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 43
        Me.Label2.Text = "A Serie"
        '
        'Txt_Serie2
        '
        Me.Txt_Serie2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Serie2.Location = New System.Drawing.Point(218, 3)
        Me.Txt_Serie2.MaxLength = 13
        Me.Txt_Serie2.Name = "Txt_Serie2"
        Me.Txt_Serie2.Size = New System.Drawing.Size(138, 20)
        Me.Txt_Serie2.TabIndex = 1
        '
        'Lbl_Leyenda
        '
        Me.Lbl_Leyenda.AutoSize = True
        Me.Lbl_Leyenda.Location = New System.Drawing.Point(138, 85)
        Me.Lbl_Leyenda.Name = "Lbl_Leyenda"
        Me.Lbl_Leyenda.Size = New System.Drawing.Size(0, 13)
        Me.Lbl_Leyenda.TabIndex = 41
        '
        'PBar1
        '
        Me.PBar1.Location = New System.Drawing.Point(14, 59)
        Me.PBar1.Name = "PBar1"
        Me.PBar1.Size = New System.Drawing.Size(342, 23)
        Me.PBar1.TabIndex = 40
        '
        'Btn_Series
        '
        Me.Btn_Series.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Series.Image = CType(resources.GetObject("Btn_Series.Image"), System.Drawing.Image)
        Me.Btn_Series.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Series.Location = New System.Drawing.Point(495, 6)
        Me.Btn_Series.Name = "Btn_Series"
        Me.Btn_Series.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Series.TabIndex = 4
        Me.Btn_Series.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip.SetToolTip(Me.Btn_Series, "Imprimir Serie")
        Me.Btn_Series.UseVisualStyleBackColor = True
        Me.Btn_Series.Visible = False
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cancelar.Image = Global.SIRCO.My.Resources.Resources.dialog_close
        Me.Btn_Cancelar.Location = New System.Drawing.Point(609, 6)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Cancelar.TabIndex = 6
        Me.Btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip.SetToolTip(Me.Btn_Cancelar, "Cerrar Opción")
        Me.Btn_Cancelar.UseVisualStyleBackColor = True
        '
        'Btn_Excel
        '
        Me.Btn_Excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Excel.Image = Global.SIRCO.My.Resources.Resources.table_excel
        Me.Btn_Excel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Excel.Location = New System.Drawing.Point(552, 6)
        Me.Btn_Excel.Name = "Btn_Excel"
        Me.Btn_Excel.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Excel.TabIndex = 5
        Me.Btn_Excel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip.SetToolTip(Me.Btn_Excel, "Exportar Series")
        Me.Btn_Excel.UseVisualStyleBackColor = True
        '
        'Txt_Serie1
        '
        Me.Txt_Serie1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Serie1.Location = New System.Drawing.Point(65, 3)
        Me.Txt_Serie1.MaxLength = 13
        Me.Txt_Serie1.Name = "Txt_Serie1"
        Me.Txt_Serie1.Size = New System.Drawing.Size(100, 20)
        Me.Txt_Serie1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "De Serie"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.DGrid)
        Me.Panel1.Location = New System.Drawing.Point(6, 113)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(672, 556)
        Me.Panel1.TabIndex = 1
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
        Me.DGrid.Location = New System.Drawing.Point(4, 3)
        Me.DGrid.Name = "DGrid"
        Me.DGrid.Size = New System.Drawing.Size(648, 519)
        Me.DGrid.TabIndex = 1
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        '
        'frmImprimirSeries
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(685, 672)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Pnl_Edicion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmImprimirSeries"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Imprimir Detalle Series"
        Me.Pnl_Edicion.ResumeLayout(False)
        Me.Pnl_Edicion.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Edicion As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DGrid As System.Windows.Forms.DataGridView
    Friend WithEvents Txt_Serie1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Btn_Excel As System.Windows.Forms.Button
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents Btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Btn_Series As System.Windows.Forms.Button
    Friend WithEvents Lbl_Leyenda As System.Windows.Forms.Label
    Friend WithEvents PBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Txt_Serie2 As System.Windows.Forms.TextBox
    Friend WithEvents Txt_IdFolioBulto As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Btn_Filtro As System.Windows.Forms.Button
    Friend WithEvents Btn_Limpiar As System.Windows.Forms.Button
    Friend WithEvents Btn_SeriesM As System.Windows.Forms.Button
End Class
