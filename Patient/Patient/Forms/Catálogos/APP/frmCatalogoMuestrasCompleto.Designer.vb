<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCatalogoMuestrasCompleto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCatalogoMuestrasCompleto))
        Me.Pnl_Principal = New DevExpress.XtraEditors.PanelControl()
        Me.Lbl_Leyenda = New System.Windows.Forms.Label()
        Me.PBox = New DevExpress.XtraEditors.PictureEdit()
        Me.Txt_Porc = New System.Windows.Forms.TextBox()
        Me.PBar = New System.Windows.Forms.ProgressBar()
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
        Me.Pnl_Principal.Controls.Add(Me.Lbl_Leyenda)
        Me.Pnl_Principal.Controls.Add(Me.PBox)
        Me.Pnl_Principal.Controls.Add(Me.Txt_Porc)
        Me.Pnl_Principal.Controls.Add(Me.PBar)
        Me.Pnl_Principal.Controls.Add(Me.Btn_AceptarF)
        Me.Pnl_Principal.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Principal.Location = New System.Drawing.Point(0, 380)
        Me.Pnl_Principal.Name = "Pnl_Principal"
        Me.Pnl_Principal.Size = New System.Drawing.Size(894, 74)
        Me.Pnl_Principal.TabIndex = 1
        '
        'Lbl_Leyenda
        '
        Me.Lbl_Leyenda.AutoSize = True
        Me.Lbl_Leyenda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Leyenda.Location = New System.Drawing.Point(47, 31)
        Me.Lbl_Leyenda.Name = "Lbl_Leyenda"
        Me.Lbl_Leyenda.Size = New System.Drawing.Size(0, 13)
        Me.Lbl_Leyenda.TabIndex = 255
        '
        'PBox
        '
        Me.PBox.EditValue = Global.SIRCO.My.Resources.Resources.sirco1_02_01
        Me.PBox.Location = New System.Drawing.Point(801, 2)
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
        Me.Txt_Porc.Location = New System.Drawing.Point(285, 41)
        Me.Txt_Porc.Name = "Txt_Porc"
        Me.Txt_Porc.ReadOnly = True
        Me.Txt_Porc.Size = New System.Drawing.Size(61, 21)
        Me.Txt_Porc.TabIndex = 253
        Me.Txt_Porc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Txt_Porc.Visible = False
        '
        'PBar
        '
        Me.PBar.Location = New System.Drawing.Point(12, 43)
        Me.PBar.Name = "PBar"
        Me.PBar.Size = New System.Drawing.Size(267, 19)
        Me.PBar.TabIndex = 252
        Me.PBar.Visible = False
        '
        'Btn_AceptarF
        '
        Me.Btn_AceptarF.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_AceptarF.Image = Global.SIRCO.My.Resources.Resources.magnifier_zoom_in
        Me.Btn_AceptarF.Location = New System.Drawing.Point(735, 14)
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
        'frmCatalogoMuestrasCompleto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(894, 454)
        Me.Controls.Add(Me.Pnl_Img)
        Me.Controls.Add(Me.Pnl_Principal)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmCatalogoMuestrasCompleto"
        Me.Text = "Muestras Completas"
        CType(Me.Pnl_Principal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_Principal.ResumeLayout(False)
        Me.Pnl_Principal.PerformLayout()
        CType(Me.PBox.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Principal As DevExpress.XtraEditors.PanelControl
    Friend WithEvents Btn_AceptarF As Button
    Friend WithEvents Pnl_Img As Panel
    Friend WithEvents Txt_Porc As TextBox
    Friend WithEvents PBar As ProgressBar
    Friend WithEvents PBox As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents Lbl_Leyenda As Label
End Class
