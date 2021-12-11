<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPpalVentasDevExpess
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPpalVentasDevExpess))
        Me.Pnl_Botones = New System.Windows.Forms.Panel()
        Me.Chk_AnioAnterior1 = New System.Windows.Forms.CheckBox()
        Me.lbl_Suma = New System.Windows.Forms.Label()
        Me.Chk_AnioAnterior = New System.Windows.Forms.CheckBox()
        Me.Btn_Actualizar = New System.Windows.Forms.Button()
        Me.Chk_Lerdo = New System.Windows.Forms.CheckBox()
        Me.lbl_Final = New System.Windows.Forms.Label()
        Me.Btn_Filtros = New System.Windows.Forms.Button()
        Me.Lbl_FecFin = New System.Windows.Forms.Label()
        Me.Lbl_FecIni = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Chk_Miles = New System.Windows.Forms.CheckBox()
        Me.Btn_Regresar = New System.Windows.Forms.Button()
        Me.Btn_Excel = New System.Windows.Forms.Button()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.GridControl = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Pnl_Botones.SuspendLayout()
        CType(Me.GridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Chk_AnioAnterior1)
        Me.Pnl_Botones.Controls.Add(Me.lbl_Suma)
        Me.Pnl_Botones.Controls.Add(Me.Chk_AnioAnterior)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Actualizar)
        Me.Pnl_Botones.Controls.Add(Me.Chk_Lerdo)
        Me.Pnl_Botones.Controls.Add(Me.lbl_Final)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Filtros)
        Me.Pnl_Botones.Controls.Add(Me.Lbl_FecFin)
        Me.Pnl_Botones.Controls.Add(Me.Lbl_FecIni)
        Me.Pnl_Botones.Controls.Add(Me.Label2)
        Me.Pnl_Botones.Controls.Add(Me.Chk_Miles)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Regresar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Excel)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Salir)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 276)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(1246, 76)
        Me.Pnl_Botones.TabIndex = 4
        '
        'Chk_AnioAnterior1
        '
        Me.Chk_AnioAnterior1.AutoSize = True
        Me.Chk_AnioAnterior1.Location = New System.Drawing.Point(264, 51)
        Me.Chk_AnioAnterior1.Name = "Chk_AnioAnterior1"
        Me.Chk_AnioAnterior1.Size = New System.Drawing.Size(155, 17)
        Me.Chk_AnioAnterior1.TabIndex = 43
        Me.Chk_AnioAnterior1.Text = "Año Anterior Fecha del Día"
        Me.Chk_AnioAnterior1.UseVisualStyleBackColor = True
        '
        'lbl_Suma
        '
        Me.lbl_Suma.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_Suma.AutoSize = True
        Me.lbl_Suma.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Suma.Location = New System.Drawing.Point(765, 43)
        Me.lbl_Suma.Name = "lbl_Suma"
        Me.lbl_Suma.Size = New System.Drawing.Size(16, 15)
        Me.lbl_Suma.TabIndex = 42
        Me.lbl_Suma.Text = "B"
        '
        'Chk_AnioAnterior
        '
        Me.Chk_AnioAnterior.AutoSize = True
        Me.Chk_AnioAnterior.Location = New System.Drawing.Point(81, 52)
        Me.Chk_AnioAnterior.Name = "Chk_AnioAnterior"
        Me.Chk_AnioAnterior.Size = New System.Drawing.Size(173, 17)
        Me.Chk_AnioAnterior.TabIndex = 41
        Me.Chk_AnioAnterior.Text = "Año Anterior Día de la Semana"
        Me.Chk_AnioAnterior.UseVisualStyleBackColor = True
        '
        'Btn_Actualizar
        '
        Me.Btn_Actualizar.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Btn_Actualizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Actualizar.Image = CType(resources.GetObject("Btn_Actualizar.Image"), System.Drawing.Image)
        Me.Btn_Actualizar.Location = New System.Drawing.Point(987, 10)
        Me.Btn_Actualizar.Name = "Btn_Actualizar"
        Me.Btn_Actualizar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Actualizar.TabIndex = 40
        Me.Btn_Actualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Actualizar.UseVisualStyleBackColor = True
        Me.Btn_Actualizar.Visible = False
        '
        'Chk_Lerdo
        '
        Me.Chk_Lerdo.AutoSize = True
        Me.Chk_Lerdo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_Lerdo.Location = New System.Drawing.Point(3, 34)
        Me.Chk_Lerdo.Name = "Chk_Lerdo"
        Me.Chk_Lerdo.Size = New System.Drawing.Size(127, 17)
        Me.Chk_Lerdo.TabIndex = 39
        Me.Chk_Lerdo.Text = "Todas Sucursales"
        Me.Chk_Lerdo.UseVisualStyleBackColor = True
        '
        'lbl_Final
        '
        Me.lbl_Final.AutoSize = True
        Me.lbl_Final.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Final.Location = New System.Drawing.Point(3, 6)
        Me.lbl_Final.Name = "lbl_Final"
        Me.lbl_Final.Size = New System.Drawing.Size(15, 13)
        Me.lbl_Final.TabIndex = 38
        Me.lbl_Final.Text = "A"
        '
        'Btn_Filtros
        '
        Me.Btn_Filtros.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Btn_Filtros.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Filtros.Image = Global.SIRCO.My.Resources.Resources.magnifier_zoom_in
        Me.Btn_Filtros.Location = New System.Drawing.Point(1038, 10)
        Me.Btn_Filtros.Name = "Btn_Filtros"
        Me.Btn_Filtros.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Filtros.TabIndex = 22
        Me.Btn_Filtros.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Filtros.UseVisualStyleBackColor = True
        '
        'Lbl_FecFin
        '
        Me.Lbl_FecFin.AutoSize = True
        Me.Lbl_FecFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_FecFin.Location = New System.Drawing.Point(549, 33)
        Me.Lbl_FecFin.Name = "Lbl_FecFin"
        Me.Lbl_FecFin.Size = New System.Drawing.Size(16, 15)
        Me.Lbl_FecFin.TabIndex = 19
        Me.Lbl_FecFin.Text = "B"
        '
        'Lbl_FecIni
        '
        Me.Lbl_FecIni.AutoSize = True
        Me.Lbl_FecIni.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_FecIni.Location = New System.Drawing.Point(369, 33)
        Me.Lbl_FecIni.Name = "Lbl_FecIni"
        Me.Lbl_FecIni.Size = New System.Drawing.Size(15, 15)
        Me.Lbl_FecIni.TabIndex = 18
        Me.Lbl_FecIni.Text = "A"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(243, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 15)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "PERIODO ACTUAL:"
        '
        'Chk_Miles
        '
        Me.Chk_Miles.AutoSize = True
        Me.Chk_Miles.Location = New System.Drawing.Point(3, 52)
        Me.Chk_Miles.Name = "Chk_Miles"
        Me.Chk_Miles.Size = New System.Drawing.Size(66, 17)
        Me.Chk_Miles.TabIndex = 16
        Me.Chk_Miles.Text = "En Miles"
        Me.Chk_Miles.UseVisualStyleBackColor = True
        '
        'Btn_Regresar
        '
        Me.Btn_Regresar.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Btn_Regresar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Regresar.Image = CType(resources.GetObject("Btn_Regresar.Image"), System.Drawing.Image)
        Me.Btn_Regresar.Location = New System.Drawing.Point(1089, 10)
        Me.Btn_Regresar.Name = "Btn_Regresar"
        Me.Btn_Regresar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Regresar.TabIndex = 13
        Me.Btn_Regresar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Regresar.UseVisualStyleBackColor = True
        '
        'Btn_Excel
        '
        Me.Btn_Excel.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Btn_Excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Excel.Image = Global.SIRCO.My.Resources.Resources.table_excel
        Me.Btn_Excel.Location = New System.Drawing.Point(1140, 10)
        Me.Btn_Excel.Name = "Btn_Excel"
        Me.Btn_Excel.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Excel.TabIndex = 7
        Me.Btn_Excel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Excel.UseVisualStyleBackColor = True
        '
        'Btn_Salir
        '
        Me.Btn_Salir.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Btn_Salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Salir.Image = Global.SIRCO.My.Resources.Resources.door_out
        Me.Btn_Salir.Location = New System.Drawing.Point(1191, 10)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Salir.TabIndex = 5
        Me.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Salir.UseVisualStyleBackColor = True
        '
        'GridControl
        '
        Me.GridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl.Location = New System.Drawing.Point(0, 0)
        Me.GridControl.MainView = Me.GridView1
        Me.GridControl.Name = "GridControl"
        Me.GridControl.Size = New System.Drawing.Size(1246, 276)
        Me.GridControl.TabIndex = 5
        Me.GridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl
        Me.GridView1.Name = "GridView1"
        '
        'frmPpalVentasDevExpess
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1246, 352)
        Me.Controls.Add(Me.GridControl)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Name = "frmPpalVentasDevExpess"
        Me.Text = "frmPpalVentasDevExpess"
        Me.Pnl_Botones.ResumeLayout(False)
        Me.Pnl_Botones.PerformLayout()
        CType(Me.GridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Pnl_Botones As Panel
    Friend WithEvents Chk_AnioAnterior1 As CheckBox
    Friend WithEvents lbl_Suma As Label
    Friend WithEvents Chk_AnioAnterior As CheckBox
    Friend WithEvents Btn_Actualizar As Button
    Friend WithEvents Chk_Lerdo As CheckBox
    Friend WithEvents lbl_Final As Label
    Friend WithEvents Btn_Filtros As Button
    Friend WithEvents Lbl_FecFin As Label
    Friend WithEvents Lbl_FecIni As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Chk_Miles As CheckBox
    Friend WithEvents Btn_Regresar As Button
    Friend WithEvents Btn_Excel As Button
    Friend WithEvents Btn_Salir As Button
    Friend WithEvents GridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
