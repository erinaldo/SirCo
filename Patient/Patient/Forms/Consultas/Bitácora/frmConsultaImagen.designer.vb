<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaImagen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaImagen))
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.PBox = New System.Windows.Forms.PictureBox
        Me.Txt_Estilon = New System.Windows.Forms.TextBox
        Me.Txt_Marca = New System.Windows.Forms.TextBox
        Me.Txt_NoFoto = New System.Windows.Forms.TextBox
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        '
        'PBox
        '
        Me.PBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PBox.Location = New System.Drawing.Point(0, 0)
        Me.PBox.Name = "PBox"
        Me.PBox.Size = New System.Drawing.Size(826, 525)
        Me.PBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBox.TabIndex = 0
        Me.PBox.TabStop = False
        '
        'Txt_Estilon
        '
        Me.Txt_Estilon.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Estilon.Location = New System.Drawing.Point(403, 252)
        Me.Txt_Estilon.MaxLength = 7
        Me.Txt_Estilon.Name = "Txt_Estilon"
        Me.Txt_Estilon.Size = New System.Drawing.Size(60, 20)
        Me.Txt_Estilon.TabIndex = 4
        Me.Txt_Estilon.Visible = False
        '
        'Txt_Marca
        '
        Me.Txt_Marca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Marca.Location = New System.Drawing.Point(363, 252)
        Me.Txt_Marca.MaxLength = 3
        Me.Txt_Marca.Name = "Txt_Marca"
        Me.Txt_Marca.Size = New System.Drawing.Size(34, 20)
        Me.Txt_Marca.TabIndex = 3
        Me.Txt_Marca.Visible = False
        '
        'Txt_NoFoto
        '
        Me.Txt_NoFoto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_NoFoto.Location = New System.Drawing.Point(469, 252)
        Me.Txt_NoFoto.MaxLength = 3
        Me.Txt_NoFoto.Name = "Txt_NoFoto"
        Me.Txt_NoFoto.Size = New System.Drawing.Size(34, 20)
        Me.Txt_NoFoto.TabIndex = 16
        Me.Txt_NoFoto.Visible = False
        '
        'frmConsultaImagen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(826, 525)
        Me.Controls.Add(Me.Txt_NoFoto)
        Me.Controls.Add(Me.Txt_Estilon)
        Me.Controls.Add(Me.Txt_Marca)
        Me.Controls.Add(Me.PBox)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConsultaImagen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Imagen"
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents PBox As System.Windows.Forms.PictureBox
    Friend WithEvents Txt_Estilon As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Marca As System.Windows.Forms.TextBox
    Friend WithEvents Txt_NoFoto As System.Windows.Forms.TextBox
End Class
