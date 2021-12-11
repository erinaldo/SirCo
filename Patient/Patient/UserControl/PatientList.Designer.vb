<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PatientList
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnAll = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboSearchBy = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.btnSearch = New System.Windows.Forms.Button
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.csmPatient = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuNew = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuPrint = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuCancel = New System.Windows.Forms.ToolStripMenuItem
        Me.dgPatient = New System.Windows.Forms.DataGridView
        Me.Panel1.SuspendLayout()
        Me.csmPatient.SuspendLayout()
        CType(Me.dgPatient, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label1.Location = New System.Drawing.Point(-2, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(292, 25)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Informacion de Empleados"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.btnAll)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cboSearchBy)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.txtSearch)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(3, 47)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(695, 82)
        Me.Panel1.TabIndex = 9
        '
        'btnAll
        '
        Me.btnAll.BackColor = System.Drawing.SystemColors.Control
        Me.btnAll.Location = New System.Drawing.Point(613, 40)
        Me.btnAll.Name = "btnAll"
        Me.btnAll.Size = New System.Drawing.Size(62, 21)
        Me.btnAll.TabIndex = 81
        Me.btnAll.Text = "&Todos"
        Me.btnAll.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.Location = New System.Drawing.Point(4, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(144, 19)
        Me.Label2.TabIndex = 80
        Me.Label2.Text = "Forma Busqueda"
        '
        'cboSearchBy
        '
        Me.cboSearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearchBy.FormattingEnabled = True
        Me.cboSearchBy.Items.AddRange(New Object() {"--Seleccione", "Empleado ID", "Nombre", "Departamento"})
        Me.cboSearchBy.Location = New System.Drawing.Point(73, 40)
        Me.cboSearchBy.Name = "cboSearchBy"
        Me.cboSearchBy.Size = New System.Drawing.Size(148, 21)
        Me.cboSearchBy.TabIndex = 78
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(5, 42)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 79
        Me.Label7.Text = "Buscar Por:"
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.SystemColors.Control
        Me.btnSearch.Location = New System.Drawing.Point(545, 40)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(62, 21)
        Me.btnSearch.TabIndex = 77
        Me.btnSearch.Text = "&Buscar"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'txtSearch
        '
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.Location = New System.Drawing.Point(344, 40)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(195, 20)
        Me.txtSearch.TabIndex = 75
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(262, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 76
        Me.Label4.Text = "Palabra Clave:"
        '
        'csmPatient
        '
        Me.csmPatient.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuNew, Me.mnuEdit, Me.mnuDelete, Me.mnuPrint, Me.mnuCancel})
        Me.csmPatient.Name = "csmStaff"
        Me.csmPatient.Size = New System.Drawing.Size(178, 114)
        '
        'mnuNew
        '
        Me.mnuNew.Name = "mnuNew"
        Me.mnuNew.Size = New System.Drawing.Size(177, 22)
        Me.mnuNew.Text = "&Nuevo Empleado"
        '
        'mnuEdit
        '
        Me.mnuEdit.Name = "mnuEdit"
        Me.mnuEdit.Size = New System.Drawing.Size(177, 22)
        Me.mnuEdit.Text = "&Modificar Empleado"
        '
        'mnuDelete
        '
        Me.mnuDelete.Name = "mnuDelete"
        Me.mnuDelete.Size = New System.Drawing.Size(177, 22)
        Me.mnuDelete.Text = "&Eliminar Empleado"
        '
        'mnuPrint
        '
        Me.mnuPrint.Name = "mnuPrint"
        Me.mnuPrint.Size = New System.Drawing.Size(177, 22)
        Me.mnuPrint.Text = "&Imprimir"
        '
        'mnuCancel
        '
        Me.mnuCancel.Name = "mnuCancel"
        Me.mnuCancel.Size = New System.Drawing.Size(177, 22)
        Me.mnuCancel.Text = "&Cancelar"
        '
        'dgPatient
        '
        Me.dgPatient.AllowUserToAddRows = False
        Me.dgPatient.AllowUserToDeleteRows = False
        Me.dgPatient.AllowUserToResizeColumns = False
        Me.dgPatient.AllowUserToResizeRows = False
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgPatient.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgPatient.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgPatient.BackgroundColor = System.Drawing.Color.DarkSeaGreen
        Me.dgPatient.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.dgPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgPatient.ContextMenuStrip = Me.csmPatient
        Me.dgPatient.Location = New System.Drawing.Point(3, 135)
        Me.dgPatient.Name = "dgPatient"
        Me.dgPatient.ReadOnly = True
        Me.dgPatient.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgPatient.Size = New System.Drawing.Size(693, 336)
        Me.dgPatient.TabIndex = 10
        '
        'PatientList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.Controls.Add(Me.dgPatient)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "PatientList"
        Me.Size = New System.Drawing.Size(714, 477)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.csmPatient.ResumeLayout(False)
        CType(Me.dgPatient, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboSearchBy As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents csmPatient As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgPatient As System.Windows.Forms.DataGridView
    Friend WithEvents btnAll As System.Windows.Forms.Button

End Class
