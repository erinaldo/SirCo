<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPromocionesCupones
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.btn_Salir = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.gc_Disponibles = New DevExpress.XtraGrid.GridControl()
        Me.dgv_Disponibles = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gc_IdCupon = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_Nombre = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.gc_Agregados = New DevExpress.XtraGrid.GridControl()
        Me.dgv_Agregados = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gc_IdCuponA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_NombreA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.btn_Agregar = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_Quitar = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.gc_Disponibles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_Disponibles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.gc_Agregados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_Agregados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.btn_Salir)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 252)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(468, 56)
        Me.PanelControl1.TabIndex = 4
        '
        'btn_Salir
        '
        Me.btn_Salir.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Salir.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.door_out
        Me.btn_Salir.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Salir.Location = New System.Drawing.Point(419, 2)
        Me.btn_Salir.Name = "btn_Salir"
        Me.btn_Salir.Size = New System.Drawing.Size(47, 52)
        Me.btn_Salir.TabIndex = 0
        Me.btn_Salir.ToolTip = "Salir"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.gc_Disponibles)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(184, 252)
        Me.PanelControl2.TabIndex = 2
        '
        'gc_Disponibles
        '
        Me.gc_Disponibles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gc_Disponibles.Location = New System.Drawing.Point(2, 2)
        Me.gc_Disponibles.MainView = Me.dgv_Disponibles
        Me.gc_Disponibles.Name = "gc_Disponibles"
        Me.gc_Disponibles.Size = New System.Drawing.Size(180, 248)
        Me.gc_Disponibles.TabIndex = 0
        Me.gc_Disponibles.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.dgv_Disponibles})
        '
        'dgv_Disponibles
        '
        Me.dgv_Disponibles.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gc_IdCupon, Me.gc_Nombre})
        Me.dgv_Disponibles.GridControl = Me.gc_Disponibles
        Me.dgv_Disponibles.Name = "dgv_Disponibles"
        Me.dgv_Disponibles.OptionsBehavior.Editable = False
        '
        'gc_IdCupon
        '
        Me.gc_IdCupon.Caption = "IdCupon"
        Me.gc_IdCupon.FieldName = "idcupon"
        Me.gc_IdCupon.Name = "gc_IdCupon"
        '
        'gc_Nombre
        '
        Me.gc_Nombre.Caption = "Nombre"
        Me.gc_Nombre.FieldName = "nombre"
        Me.gc_Nombre.Name = "gc_Nombre"
        Me.gc_Nombre.Visible = True
        Me.gc_Nombre.VisibleIndex = 0
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.gc_Agregados)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl3.Location = New System.Drawing.Point(272, 0)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(196, 252)
        Me.PanelControl3.TabIndex = 3
        '
        'gc_Agregados
        '
        Me.gc_Agregados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gc_Agregados.Location = New System.Drawing.Point(2, 2)
        Me.gc_Agregados.MainView = Me.dgv_Agregados
        Me.gc_Agregados.Name = "gc_Agregados"
        Me.gc_Agregados.Size = New System.Drawing.Size(192, 248)
        Me.gc_Agregados.TabIndex = 0
        Me.gc_Agregados.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.dgv_Agregados})
        '
        'dgv_Agregados
        '
        Me.dgv_Agregados.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gc_IdCuponA, Me.gc_NombreA})
        Me.dgv_Agregados.GridControl = Me.gc_Agregados
        Me.dgv_Agregados.Name = "dgv_Agregados"
        Me.dgv_Agregados.OptionsBehavior.Editable = False
        '
        'gc_IdCuponA
        '
        Me.gc_IdCuponA.Caption = "IdCupon"
        Me.gc_IdCuponA.FieldName = "idcupon"
        Me.gc_IdCuponA.Name = "gc_IdCuponA"
        '
        'gc_NombreA
        '
        Me.gc_NombreA.Caption = "Nombre"
        Me.gc_NombreA.FieldName = "nombre"
        Me.gc_NombreA.Name = "gc_NombreA"
        Me.gc_NombreA.Visible = True
        Me.gc_NombreA.VisibleIndex = 0
        '
        'btn_Agregar
        '
        Me.btn_Agregar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Agregar.ImageOptions.ImageUri.Uri = "Forward"
        Me.btn_Agregar.Location = New System.Drawing.Point(211, 74)
        Me.btn_Agregar.Name = "btn_Agregar"
        Me.btn_Agregar.Size = New System.Drawing.Size(40, 36)
        Me.btn_Agregar.TabIndex = 2
        Me.btn_Agregar.ToolTip = "Agregar"
        '
        'btn_Quitar
        '
        Me.btn_Quitar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Quitar.ImageOptions.ImageUri.Uri = "Backward"
        Me.btn_Quitar.Location = New System.Drawing.Point(211, 129)
        Me.btn_Quitar.Name = "btn_Quitar"
        Me.btn_Quitar.Size = New System.Drawing.Size(40, 36)
        Me.btn_Quitar.TabIndex = 3
        Me.btn_Quitar.ToolTip = "Quitar"
        '
        'frmPromocionesCupones
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(468, 308)
        Me.Controls.Add(Me.btn_Quitar)
        Me.Controls.Add(Me.btn_Agregar)
        Me.Controls.Add(Me.PanelControl3)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmPromocionesCupones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Cupones"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.gc_Disponibles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_Disponibles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.gc_Agregados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_Agregados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btn_Salir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btn_Agregar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_Quitar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents gc_Disponibles As DevExpress.XtraGrid.GridControl
    Friend WithEvents dgv_Disponibles As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gc_IdCupon As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_Nombre As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_Agregados As DevExpress.XtraGrid.GridControl
    Friend WithEvents dgv_Agregados As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gc_IdCuponA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_NombreA As DevExpress.XtraGrid.Columns.GridColumn
End Class
