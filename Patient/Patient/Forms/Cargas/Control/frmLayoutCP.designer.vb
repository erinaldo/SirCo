<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLayoutCP
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
        Me.components = New System.ComponentModel.Container()
        Me.Btn_Layout = New DevExpress.XtraEditors.SimpleButton()
        Me.P_Bar = New System.Windows.Forms.ProgressBar()
        Me.Lbl_Leyenda = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.LabelTerminado = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Btn_Layout
        '
        Me.Btn_Layout.Image = Global.SIRCO.My.Resources.Resources.LAYOUTBANCO
        Me.Btn_Layout.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.Btn_Layout.Location = New System.Drawing.Point(358, 39)
        Me.Btn_Layout.Name = "Btn_Layout"
        Me.Btn_Layout.Size = New System.Drawing.Size(48, 52)
        Me.Btn_Layout.TabIndex = 17
        '
        'P_Bar
        '
        Me.P_Bar.Location = New System.Drawing.Point(7, 97)
        Me.P_Bar.Name = "P_Bar"
        Me.P_Bar.Size = New System.Drawing.Size(784, 23)
        Me.P_Bar.TabIndex = 20
        '
        'Lbl_Leyenda
        '
        Me.Lbl_Leyenda.AutoSize = True
        Me.Lbl_Leyenda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Leyenda.Location = New System.Drawing.Point(6, 146)
        Me.Lbl_Leyenda.Name = "Lbl_Leyenda"
        Me.Lbl_Leyenda.Size = New System.Drawing.Size(0, 13)
        Me.Lbl_Leyenda.TabIndex = 21
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'LabelTerminado
        '
        Me.LabelTerminado.AutoSize = True
        Me.LabelTerminado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTerminado.Location = New System.Drawing.Point(6, 180)
        Me.LabelTerminado.Name = "LabelTerminado"
        Me.LabelTerminado.Size = New System.Drawing.Size(0, 13)
        Me.LabelTerminado.TabIndex = 22
        '
        'frmLayoutCP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(803, 200)
        Me.Controls.Add(Me.LabelTerminado)
        Me.Controls.Add(Me.Lbl_Leyenda)
        Me.Controls.Add(Me.P_Bar)
        Me.Controls.Add(Me.Btn_Layout)
        Me.Name = "frmLayoutCP"
        Me.Text = "Layout Códigos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Btn_Layout As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents P_Bar As ProgressBar
    Friend WithEvents Lbl_Leyenda As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents LabelTerminado As Label
End Class
