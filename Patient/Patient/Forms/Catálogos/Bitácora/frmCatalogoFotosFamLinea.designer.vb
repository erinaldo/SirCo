<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCatalogoFotosFamLinea
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCatalogoFotosFamLinea))
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.Pnl_Botones = New System.Windows.Forms.Panel
        Me.Btn_Abortar = New System.Windows.Forms.Button
        Me.Lbl_Filtros = New System.Windows.Forms.Label
        Me.Lbl_Sucursales = New System.Windows.Forms.Label
        Me.Txt_Porc = New System.Windows.Forms.TextBox
        Me.PBar = New System.Windows.Forms.ProgressBar
        Me.Btn_Filtro = New System.Windows.Forms.Button
        Me.Btn_Salir = New System.Windows.Forms.Button
        Me.Pnl_Img = New System.Windows.Forms.Panel
        Me.Pnl_Botones.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Btn_Abortar)
        Me.Pnl_Botones.Controls.Add(Me.Lbl_Filtros)
        Me.Pnl_Botones.Controls.Add(Me.Lbl_Sucursales)
        Me.Pnl_Botones.Controls.Add(Me.Txt_Porc)
        Me.Pnl_Botones.Controls.Add(Me.PBar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Filtro)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Salir)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 574)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(1074, 56)
        Me.Pnl_Botones.TabIndex = 4
        '
        'Btn_Abortar
        '
        Me.Btn_Abortar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Abortar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Abortar.Image = Global.SIRCO.My.Resources.Resources._1328834184_cancel1
        Me.Btn_Abortar.Location = New System.Drawing.Point(917, 0)
        Me.Btn_Abortar.Name = "Btn_Abortar"
        Me.Btn_Abortar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Abortar.TabIndex = 92
        Me.Btn_Abortar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Abortar.UseVisualStyleBackColor = True
        '
        'Lbl_Filtros
        '
        Me.Lbl_Filtros.AutoSize = True
        Me.Lbl_Filtros.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Filtros.Location = New System.Drawing.Point(10, 28)
        Me.Lbl_Filtros.Name = "Lbl_Filtros"
        Me.Lbl_Filtros.Size = New System.Drawing.Size(59, 16)
        Me.Lbl_Filtros.TabIndex = 90
        Me.Lbl_Filtros.Text = "Filtros: "
        '
        'Lbl_Sucursales
        '
        Me.Lbl_Sucursales.AutoSize = True
        Me.Lbl_Sucursales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Sucursales.Location = New System.Drawing.Point(10, 5)
        Me.Lbl_Sucursales.Name = "Lbl_Sucursales"
        Me.Lbl_Sucursales.Size = New System.Drawing.Size(72, 16)
        Me.Lbl_Sucursales.TabIndex = 89
        Me.Lbl_Sucursales.Text = "Sucursal:"
        '
        'Txt_Porc
        '
        Me.Txt_Porc.Enabled = False
        Me.Txt_Porc.Location = New System.Drawing.Point(742, 30)
        Me.Txt_Porc.Name = "Txt_Porc"
        Me.Txt_Porc.ReadOnly = True
        Me.Txt_Porc.Size = New System.Drawing.Size(80, 20)
        Me.Txt_Porc.TabIndex = 88
        Me.Txt_Porc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Txt_Porc.Visible = False
        '
        'PBar
        '
        Me.PBar.Location = New System.Drawing.Point(642, 3)
        Me.PBar.Name = "PBar"
        Me.PBar.Size = New System.Drawing.Size(269, 23)
        Me.PBar.TabIndex = 87
        Me.PBar.Visible = False
        '
        'Btn_Filtro
        '
        Me.Btn_Filtro.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Filtro.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Filtro.Image = Global.SIRCO.My.Resources.Resources.magnifier_zoom_in
        Me.Btn_Filtro.Location = New System.Drawing.Point(968, 0)
        Me.Btn_Filtro.Name = "Btn_Filtro"
        Me.Btn_Filtro.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Filtro.TabIndex = 41
        Me.Btn_Filtro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Filtro.UseVisualStyleBackColor = True
        '
        'Btn_Salir
        '
        Me.Btn_Salir.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Salir.Image = Global.SIRCO.My.Resources.Resources.door_out
        Me.Btn_Salir.Location = New System.Drawing.Point(1019, 0)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Salir.TabIndex = 5
        Me.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Salir.UseVisualStyleBackColor = True
        '
        'Pnl_Img
        '
        Me.Pnl_Img.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnl_Img.Location = New System.Drawing.Point(0, 0)
        Me.Pnl_Img.Name = "Pnl_Img"
        Me.Pnl_Img.Size = New System.Drawing.Size(1074, 574)
        Me.Pnl_Img.TabIndex = 5
        '
        'frmCatalogoFotosFamLinea
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1074, 630)
        Me.Controls.Add(Me.Pnl_Img)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmCatalogoFotosFamLinea"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catálogo de Modelos por Estructura"
        Me.Pnl_Botones.ResumeLayout(False)
        Me.Pnl_Botones.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    '  Friend WithEvents Tbl_asistencia_diariaTableAdapter1 As Bitacora.DataSet1TableAdapters.tbl_asistencia_diariaTableAdapter
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents Btn_Salir As System.Windows.Forms.Button
    Friend WithEvents Btn_Filtro As System.Windows.Forms.Button
    Friend WithEvents Txt_Porc As System.Windows.Forms.TextBox
    Friend WithEvents PBar As System.Windows.Forms.ProgressBar
    Friend WithEvents Lbl_Filtros As System.Windows.Forms.Label
    Friend WithEvents Lbl_Sucursales As System.Windows.Forms.Label
    Friend WithEvents Pnl_Img As System.Windows.Forms.Panel
    Friend WithEvents Btn_Abortar As System.Windows.Forms.Button
End Class
