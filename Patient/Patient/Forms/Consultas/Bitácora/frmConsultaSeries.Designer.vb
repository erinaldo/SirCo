﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaSeries
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaSeries))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Pnl_Edicion = New System.Windows.Forms.Panel()
        Me.Btn_Filtro = New System.Windows.Forms.Button()
        Me.Lbl_Leyenda = New System.Windows.Forms.Label()
        Me.PBar1 = New System.Windows.Forms.ProgressBar()
        Me.Btn_Series = New System.Windows.Forms.Button()
        Me.Btn_Cancelar = New System.Windows.Forms.Button()
        Me.Btn_Aceptar = New System.Windows.Forms.Button()
        Me.Btn_Excel = New System.Windows.Forms.Button()
        Me.Txt_Buscar = New System.Windows.Forms.TextBox()
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
        Me.Pnl_Edicion.Controls.Add(Me.Btn_Filtro)
        Me.Pnl_Edicion.Controls.Add(Me.Lbl_Leyenda)
        Me.Pnl_Edicion.Controls.Add(Me.PBar1)
        Me.Pnl_Edicion.Controls.Add(Me.Btn_Series)
        Me.Pnl_Edicion.Controls.Add(Me.Btn_Cancelar)
        Me.Pnl_Edicion.Controls.Add(Me.Btn_Aceptar)
        Me.Pnl_Edicion.Controls.Add(Me.Btn_Excel)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Buscar)
        Me.Pnl_Edicion.Controls.Add(Me.Label1)
        Me.Pnl_Edicion.Location = New System.Drawing.Point(6, 12)
        Me.Pnl_Edicion.Name = "Pnl_Edicion"
        Me.Pnl_Edicion.Size = New System.Drawing.Size(672, 118)
        Me.Pnl_Edicion.TabIndex = 0
        '
        'Btn_Filtro
        '
        Me.Btn_Filtro.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Filtro.Image = Global.SIRCO.My.Resources.Resources.magnifier_zoom_in
        Me.Btn_Filtro.Location = New System.Drawing.Point(362, 3)
        Me.Btn_Filtro.Name = "Btn_Filtro"
        Me.Btn_Filtro.Size = New System.Drawing.Size(50, 47)
        Me.Btn_Filtro.TabIndex = 42
        Me.Btn_Filtro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Filtro.UseVisualStyleBackColor = True
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
        Me.PBar1.Size = New System.Drawing.Size(378, 23)
        Me.PBar1.TabIndex = 40
        '
        'Btn_Series
        '
        Me.Btn_Series.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Series.Image = CType(resources.GetObject("Btn_Series.Image"), System.Drawing.Image)
        Me.Btn_Series.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Series.Location = New System.Drawing.Point(418, 3)
        Me.Btn_Series.Name = "Btn_Series"
        Me.Btn_Series.Size = New System.Drawing.Size(51, 47)
        Me.Btn_Series.TabIndex = 39
        Me.Btn_Series.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip.SetToolTip(Me.Btn_Series, "Series En Aparador")
        Me.Btn_Series.UseVisualStyleBackColor = True
        Me.Btn_Series.Visible = False
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cancelar.Image = Global.SIRCO.My.Resources.Resources.dialog_close
        Me.Btn_Cancelar.Location = New System.Drawing.Point(532, 3)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(51, 47)
        Me.Btn_Cancelar.TabIndex = 24
        Me.Btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Cancelar.UseVisualStyleBackColor = True
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Aceptar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_Aceptar.Location = New System.Drawing.Point(589, 3)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(51, 47)
        Me.Btn_Aceptar.TabIndex = 23
        Me.Btn_Aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Aceptar.UseVisualStyleBackColor = True
        '
        'Btn_Excel
        '
        Me.Btn_Excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Excel.Image = Global.SIRCO.My.Resources.Resources.table_excel
        Me.Btn_Excel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Excel.Location = New System.Drawing.Point(475, 3)
        Me.Btn_Excel.Name = "Btn_Excel"
        Me.Btn_Excel.Size = New System.Drawing.Size(51, 47)
        Me.Btn_Excel.TabIndex = 2
        Me.Btn_Excel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Excel.UseVisualStyleBackColor = True
        '
        'Txt_Buscar
        '
        Me.Txt_Buscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Buscar.Location = New System.Drawing.Point(116, 19)
        Me.Txt_Buscar.MaxLength = 13
        Me.Txt_Buscar.Name = "Txt_Buscar"
        Me.Txt_Buscar.Size = New System.Drawing.Size(172, 20)
        Me.Txt_Buscar.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Buscar Serie"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.DGrid)
        Me.Panel1.Location = New System.Drawing.Point(6, 136)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(672, 533)
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
        Me.DGrid.Location = New System.Drawing.Point(14, 3)
        Me.DGrid.Name = "DGrid"
        Me.DGrid.Size = New System.Drawing.Size(648, 502)
        Me.DGrid.TabIndex = 1
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        '
        'frmConsultaSeries
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
        Me.Name = "frmConsultaSeries"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Búsqueda Detalle Series"
        Me.Pnl_Edicion.ResumeLayout(False)
        Me.Pnl_Edicion.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Edicion As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DGrid As System.Windows.Forms.DataGridView
    Friend WithEvents Txt_Buscar As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Btn_Excel As System.Windows.Forms.Button
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents Btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Btn_Series As System.Windows.Forms.Button
    Friend WithEvents Lbl_Leyenda As System.Windows.Forms.Label
    Friend WithEvents PBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Btn_Filtro As System.Windows.Forms.Button
End Class
