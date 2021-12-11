<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPpalSeguimientoCedis
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.DTPicker1 = New System.Windows.Forms.DateTimePicker()
        Me.DTPicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.Btn_Excel = New System.Windows.Forms.Button()
        Me.Btn_Buscar = New System.Windows.Forms.Button()
        Me.DGrid2 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.sfdRuta = New System.Windows.Forms.SaveFileDialog()
        CType(Me.DGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DTPicker1
        '
        Me.DTPicker1.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPicker1.Location = New System.Drawing.Point(95, 567)
        Me.DTPicker1.Name = "DTPicker1"
        Me.DTPicker1.Size = New System.Drawing.Size(300, 20)
        Me.DTPicker1.TabIndex = 1
        '
        'DTPicker2
        '
        Me.DTPicker2.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPicker2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPicker2.Location = New System.Drawing.Point(517, 567)
        Me.DTPicker2.Name = "DTPicker2"
        Me.DTPicker2.Size = New System.Drawing.Size(300, 20)
        Me.DTPicker2.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 569)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Fecha inicial"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(452, 570)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Fecha final"
        '
        'Btn_Salir
        '
        Me.Btn_Salir.Image = Global.SIRCO.My.Resources.Resources.door_out
        Me.Btn_Salir.Location = New System.Drawing.Point(1301, 554)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Salir.TabIndex = 5
        Me.Btn_Salir.UseVisualStyleBackColor = True
        '
        'Btn_Excel
        '
        Me.Btn_Excel.Image = Global.SIRCO.My.Resources.Resources.table_excel
        Me.Btn_Excel.Location = New System.Drawing.Point(1246, 554)
        Me.Btn_Excel.Name = "Btn_Excel"
        Me.Btn_Excel.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Excel.TabIndex = 6
        Me.Btn_Excel.UseVisualStyleBackColor = True
        '
        'Btn_Buscar
        '
        Me.Btn_Buscar.BackgroundImage = Global.SIRCO.My.Resources.Resources.find
        Me.Btn_Buscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Btn_Buscar.Location = New System.Drawing.Point(1192, 554)
        Me.Btn_Buscar.Name = "Btn_Buscar"
        Me.Btn_Buscar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Buscar.TabIndex = 7
        Me.Btn_Buscar.UseVisualStyleBackColor = True
        '
        'DGrid2
        '
        Me.DGrid2.EmbeddedNavigator.Appearance.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.DGrid2.EmbeddedNavigator.Appearance.Options.UseBackColor = True
        Me.DGrid2.EmbeddedNavigator.Appearance.Options.UseTextOptions = True
        Me.DGrid2.EmbeddedNavigator.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.DGrid2.Location = New System.Drawing.Point(3, 4)
        Me.DGrid2.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.DGrid2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.DGrid2.MainView = Me.GridView1
        Me.DGrid2.Name = "DGrid2"
        Me.DGrid2.Size = New System.Drawing.Size(1357, 544)
        Me.DGrid2.TabIndex = 8
        Me.DGrid2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.DGrid2
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        '
        'sfdRuta
        '
        Me.sfdRuta.Filter = "Archivos Excel | *.xls"
        '
        'frmPpalSeguimientoCedis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1364, 611)
        Me.Controls.Add(Me.DGrid2)
        Me.Controls.Add(Me.Btn_Buscar)
        Me.Controls.Add(Me.Btn_Excel)
        Me.Controls.Add(Me.Btn_Salir)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DTPicker2)
        Me.Controls.Add(Me.DTPicker1)
        Me.KeyPreview = True
        Me.Name = "frmPpalSeguimientoCedis"
        Me.Text = "Seguimiento Recibo Cedis"
        CType(Me.DGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DTPicker1 As DateTimePicker
    Friend WithEvents DTPicker2 As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Btn_Salir As Button
    Friend WithEvents Btn_Excel As Button
    Friend WithEvents Btn_Buscar As Button
    Friend WithEvents DGrid2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents sfdRuta As SaveFileDialog
End Class
