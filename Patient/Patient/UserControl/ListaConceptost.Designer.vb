<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DoctorList
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.mnuDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuCancel = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuPrint = New System.Windows.Forms.ToolStripMenuItem
        Me.Label1 = New System.Windows.Forms.Label
        Me.csmDoctor = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuNew = New System.Windows.Forms.ToolStripMenuItem
        Me.dgDoctor = New System.Windows.Forms.DataGridView
        Me.csmDoctor.SuspendLayout()
        CType(Me.dgDoctor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mnuDelete
        '
        Me.mnuDelete.Name = "mnuDelete"
        Me.mnuDelete.Size = New System.Drawing.Size(164, 22)
        Me.mnuDelete.Text = "&Eliminar Puesto"
        '
        'mnuEdit
        '
        Me.mnuEdit.Name = "mnuEdit"
        Me.mnuEdit.Size = New System.Drawing.Size(164, 22)
        Me.mnuEdit.Text = "&Modificar Puesto"
        '
        'mnuCancel
        '
        Me.mnuCancel.Name = "mnuCancel"
        Me.mnuCancel.Size = New System.Drawing.Size(164, 22)
        Me.mnuCancel.Text = "&Cancelar"
        '
        'mnuPrint
        '
        Me.mnuPrint.Name = "mnuPrint"
        Me.mnuPrint.Size = New System.Drawing.Size(164, 22)
        Me.mnuPrint.Text = "&Imprimir"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label1.Location = New System.Drawing.Point(9, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(261, 25)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Información de Puestos"
        '
        'csmDoctor
        '
        Me.csmDoctor.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuNew, Me.mnuEdit, Me.mnuDelete, Me.mnuPrint, Me.mnuCancel})
        Me.csmDoctor.Name = "csmStaff"
        Me.csmDoctor.Size = New System.Drawing.Size(165, 136)
        '
        'mnuNew
        '
        Me.mnuNew.Name = "mnuNew"
        Me.mnuNew.Size = New System.Drawing.Size(164, 22)
        Me.mnuNew.Text = "&Nuevo Puesto"
        '
        'dgDoctor
        '
        Me.dgDoctor.AllowUserToAddRows = False
        Me.dgDoctor.AllowUserToDeleteRows = False
        Me.dgDoctor.AllowUserToResizeColumns = False
        Me.dgDoctor.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgDoctor.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgDoctor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgDoctor.BackgroundColor = System.Drawing.Color.DarkSeaGreen
        Me.dgDoctor.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.dgDoctor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDoctor.ContextMenuStrip = Me.csmDoctor
        Me.dgDoctor.Location = New System.Drawing.Point(14, 64)
        Me.dgDoctor.Name = "dgDoctor"
        Me.dgDoctor.ReadOnly = True
        Me.dgDoctor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgDoctor.Size = New System.Drawing.Size(669, 379)
        Me.dgDoctor.TabIndex = 11
        '
        'DoctorList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.dgDoctor)
        Me.Controls.Add(Me.Label1)
        Me.Name = "DoctorList"
        Me.Size = New System.Drawing.Size(694, 458)
        Me.csmDoctor.ResumeLayout(False)
        CType(Me.dgDoctor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents csmDoctor As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgDoctor As System.Windows.Forms.DataGridView

End Class
