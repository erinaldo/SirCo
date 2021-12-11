<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCatalogoMuestras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCatalogoMuestras))
        Me.Pnl_Principal = New DevExpress.XtraEditors.PanelControl()
        Me.PBox = New DevExpress.XtraEditors.PictureEdit()
        Me.Txt_Porc = New System.Windows.Forms.TextBox()
        Me.PBar = New System.Windows.Forms.ProgressBar()
        Me.Txt_Marca = New System.Windows.Forms.TextBox()
        Me.Txt_DescripMarca = New System.Windows.Forms.TextBox()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.Btn_AceptarF = New System.Windows.Forms.Button()
        Me.Pnl_Img = New System.Windows.Forms.Panel()
        CType(Me.Pnl_Principal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_Principal.SuspendLayout()
        CType(Me.PBox.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pnl_Principal
        '
        Me.Pnl_Principal.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.Pnl_Principal.Controls.Add(Me.PBox)
        Me.Pnl_Principal.Controls.Add(Me.Txt_Porc)
        Me.Pnl_Principal.Controls.Add(Me.PBar)
        Me.Pnl_Principal.Controls.Add(Me.Txt_Marca)
        Me.Pnl_Principal.Controls.Add(Me.Txt_DescripMarca)
        Me.Pnl_Principal.Controls.Add(Me.LabelControl2)
        Me.Pnl_Principal.Controls.Add(Me.Btn_AceptarF)
        Me.Pnl_Principal.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Principal.Location = New System.Drawing.Point(0, 380)
        Me.Pnl_Principal.Name = "Pnl_Principal"
        Me.Pnl_Principal.Size = New System.Drawing.Size(894, 74)
        Me.Pnl_Principal.TabIndex = 1
        '
        'PBox
        '
        Me.PBox.EditValue = Global.SIRCO.My.Resources.Resources.sirco1_02_01
        Me.PBox.Location = New System.Drawing.Point(443, 1)
        Me.PBox.Name = "PBox"
        Me.PBox.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.PBox.Properties.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.PBox.Properties.LookAndFeel.UseWindowsXPTheme = True
        Me.PBox.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PBox.Size = New System.Drawing.Size(88, 67)
        Me.PBox.TabIndex = 254
        Me.PBox.Visible = False
        '
        'Txt_Porc
        '
        Me.Txt_Porc.Enabled = False
        Me.Txt_Porc.Location = New System.Drawing.Point(705, 30)
        Me.Txt_Porc.Name = "Txt_Porc"
        Me.Txt_Porc.ReadOnly = True
        Me.Txt_Porc.Size = New System.Drawing.Size(61, 21)
        Me.Txt_Porc.TabIndex = 253
        Me.Txt_Porc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Txt_Porc.Visible = False
        '
        'PBar
        '
        Me.PBar.Location = New System.Drawing.Point(597, 5)
        Me.PBar.Name = "PBar"
        Me.PBar.Size = New System.Drawing.Size(267, 19)
        Me.PBar.TabIndex = 252
        Me.PBar.Visible = False
        '
        'Txt_Marca
        '
        Me.Txt_Marca.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Marca.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Marca.Location = New System.Drawing.Point(97, 12)
        Me.Txt_Marca.MaxLength = 3
        Me.Txt_Marca.Name = "Txt_Marca"
        Me.Txt_Marca.Size = New System.Drawing.Size(44, 22)
        Me.Txt_Marca.TabIndex = 202
        '
        'Txt_DescripMarca
        '
        Me.Txt_DescripMarca.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripMarca.Enabled = False
        Me.Txt_DescripMarca.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripMarca.Location = New System.Drawing.Point(143, 12)
        Me.Txt_DescripMarca.Name = "Txt_DescripMarca"
        Me.Txt_DescripMarca.ReadOnly = True
        Me.Txt_DescripMarca.Size = New System.Drawing.Size(197, 22)
        Me.Txt_DescripMarca.TabIndex = 203
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(13, 19)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(29, 13)
        Me.LabelControl2.TabIndex = 23
        Me.LabelControl2.Text = "Marca"
        '
        'Btn_AceptarF
        '
        Me.Btn_AceptarF.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_AceptarF.Image = Global.SIRCO.My.Resources.Resources.magnifier_zoom_in
        Me.Btn_AceptarF.Location = New System.Drawing.Point(361, 5)
        Me.Btn_AceptarF.Name = "Btn_AceptarF"
        Me.Btn_AceptarF.Size = New System.Drawing.Size(51, 47)
        Me.Btn_AceptarF.TabIndex = 22
        Me.Btn_AceptarF.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_AceptarF.UseVisualStyleBackColor = True
        '
        'Pnl_Img
        '
        Me.Pnl_Img.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Img.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnl_Img.Location = New System.Drawing.Point(0, 0)
        Me.Pnl_Img.Name = "Pnl_Img"
        Me.Pnl_Img.Size = New System.Drawing.Size(894, 380)
        Me.Pnl_Img.TabIndex = 4
        '
        'frmCatalogoMuestras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(894, 454)
        Me.Controls.Add(Me.Pnl_Img)
        Me.Controls.Add(Me.Pnl_Principal)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmCatalogoMuestras"
        Me.Text = "Muestras Incompletas"
        CType(Me.Pnl_Principal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_Principal.ResumeLayout(False)
        Me.Pnl_Principal.PerformLayout()
        CType(Me.PBox.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Principal As DevExpress.XtraEditors.PanelControl
    Friend WithEvents Btn_AceptarF As Button
    Friend WithEvents Pnl_Img As Panel
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_Marca As TextBox
    Friend WithEvents Txt_DescripMarca As TextBox
    Friend WithEvents Txt_Porc As TextBox
    Friend WithEvents PBar As ProgressBar
    Friend WithEvents PBox As DevExpress.XtraEditors.PictureEdit
End Class
