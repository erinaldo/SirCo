<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCargaArchivoTaspaso
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCargaArchivoTaspaso))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Pnl_Edicion = New System.Windows.Forms.Panel
        Me.Btn_Adjuntar = New System.Windows.Forms.Button
        Me.Txt_Archivo = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.DGrid = New System.Windows.Forms.DataGridView
        Me.colCorrectos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDuplicados = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colIlegibles = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Btn_Limpiar = New System.Windows.Forms.Button
        Me.Btn_AgregarSeries = New System.Windows.Forms.Button
        Me.Pnl_Edicion.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pnl_Edicion
        '
        Me.Pnl_Edicion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Edicion.Controls.Add(Me.Btn_Adjuntar)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Archivo)
        Me.Pnl_Edicion.Controls.Add(Me.Label3)
        Me.Pnl_Edicion.Location = New System.Drawing.Point(6, 5)
        Me.Pnl_Edicion.Name = "Pnl_Edicion"
        Me.Pnl_Edicion.Size = New System.Drawing.Size(500, 71)
        Me.Pnl_Edicion.TabIndex = 0
        '
        'Btn_Adjuntar
        '
        Me.Btn_Adjuntar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Btn_Adjuntar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Adjuntar.Image = CType(resources.GetObject("Btn_Adjuntar.Image"), System.Drawing.Image)
        Me.Btn_Adjuntar.Location = New System.Drawing.Point(462, 27)
        Me.Btn_Adjuntar.Name = "Btn_Adjuntar"
        Me.Btn_Adjuntar.Size = New System.Drawing.Size(27, 25)
        Me.Btn_Adjuntar.TabIndex = 112
        Me.Btn_Adjuntar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Adjuntar.UseVisualStyleBackColor = True
        '
        'Txt_Archivo
        '
        Me.Txt_Archivo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Txt_Archivo.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Archivo.Enabled = False
        Me.Txt_Archivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Archivo.Location = New System.Drawing.Point(14, 30)
        Me.Txt_Archivo.Name = "Txt_Archivo"
        Me.Txt_Archivo.ReadOnly = True
        Me.Txt_Archivo.Size = New System.Drawing.Size(441, 20)
        Me.Txt_Archivo.TabIndex = 111
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 13)
        Me.Label3.TabIndex = 113
        Me.Label3.Text = "Seleccionar Archivo"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.DGrid)
        Me.Panel1.Location = New System.Drawing.Point(6, 82)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(500, 318)
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
        Me.DGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCorrectos, Me.colDuplicados, Me.colIlegibles})
        Me.DGrid.Location = New System.Drawing.Point(4, 3)
        Me.DGrid.Name = "DGrid"
        Me.DGrid.ReadOnly = True
        Me.DGrid.RowHeadersVisible = False
        Me.DGrid.Size = New System.Drawing.Size(489, 308)
        Me.DGrid.TabIndex = 3
        '
        'colCorrectos
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colCorrectos.DefaultCellStyle = DataGridViewCellStyle2
        Me.colCorrectos.HeaderText = "Correctos"
        Me.colCorrectos.Name = "colCorrectos"
        Me.colCorrectos.ReadOnly = True
        Me.colCorrectos.Width = 150
        '
        'colDuplicados
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colDuplicados.DefaultCellStyle = DataGridViewCellStyle3
        Me.colDuplicados.HeaderText = "Duplicados"
        Me.colDuplicados.Name = "colDuplicados"
        Me.colDuplicados.ReadOnly = True
        Me.colDuplicados.Width = 150
        '
        'colIlegibles
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colIlegibles.DefaultCellStyle = DataGridViewCellStyle4
        Me.colIlegibles.HeaderText = "Ilegibles"
        Me.colIlegibles.Name = "colIlegibles"
        Me.colIlegibles.ReadOnly = True
        Me.colIlegibles.Width = 150
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.Btn_Limpiar)
        Me.Panel2.Controls.Add(Me.Btn_AgregarSeries)
        Me.Panel2.Location = New System.Drawing.Point(6, 406)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(500, 58)
        Me.Panel2.TabIndex = 2
        '
        'Btn_Limpiar
        '
        Me.Btn_Limpiar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Limpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Limpiar.Image = Global.SIRCO.My.Resources.Resources.LIMPIAR_FILTROS
        Me.Btn_Limpiar.Location = New System.Drawing.Point(394, 0)
        Me.Btn_Limpiar.Name = "Btn_Limpiar"
        Me.Btn_Limpiar.Size = New System.Drawing.Size(51, 54)
        Me.Btn_Limpiar.TabIndex = 2
        Me.Btn_Limpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Limpiar.UseVisualStyleBackColor = True
        '
        'Btn_AgregarSeries
        '
        Me.Btn_AgregarSeries.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_AgregarSeries.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_AgregarSeries.Image = Global.SIRCO.My.Resources.Resources.document_add
        Me.Btn_AgregarSeries.Location = New System.Drawing.Point(445, 0)
        Me.Btn_AgregarSeries.Name = "Btn_AgregarSeries"
        Me.Btn_AgregarSeries.Size = New System.Drawing.Size(51, 54)
        Me.Btn_AgregarSeries.TabIndex = 3
        Me.Btn_AgregarSeries.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_AgregarSeries.UseVisualStyleBackColor = True
        '
        'frmCargaArchivoTaspaso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(513, 476)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Pnl_Edicion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCargaArchivoTaspaso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Importar desde Archivo..."
        Me.Pnl_Edicion.ResumeLayout(False)
        Me.Pnl_Edicion.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Edicion As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Btn_Limpiar As System.Windows.Forms.Button
    Friend WithEvents Btn_AgregarSeries As System.Windows.Forms.Button
    Friend WithEvents DGrid As System.Windows.Forms.DataGridView
    Friend WithEvents colCorrectos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDuplicados As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIlegibles As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Btn_Adjuntar As System.Windows.Forms.Button
    Friend WithEvents Txt_Archivo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
