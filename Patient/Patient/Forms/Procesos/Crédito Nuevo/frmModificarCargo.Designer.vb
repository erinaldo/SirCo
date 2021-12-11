<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModificarCargo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmModificarCargo))
        Me.Pnl_ = New System.Windows.Forms.Panel()
        Me.Lbl_Status = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_Nota = New DevExpress.XtraEditors.TextEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Txt_Vale = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.Dt_Apagar = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_Importe = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_FechaCompra = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_Cliente = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_Distribuidor = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Txt_ApMaternoClie = New DevExpress.XtraEditors.TextEdit()
        Me.Txt_ApPaternoClie = New DevExpress.XtraEditors.TextEdit()
        Me.Txt_ValeNew = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.Btn_Aceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.DEFechaIni = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_NombreClie = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_DistribNuevo = New DevExpress.XtraEditors.TextEdit()
        Me.Txt_DistribNombre = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.DGridVenta = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.DGridPagos = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Pnl_.SuspendLayout()
        CType(Me.Txt_Nota.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.Txt_Vale.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dt_Apagar.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dt_Apagar.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_Importe.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_FechaCompra.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_Cliente.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_Distribuidor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.Txt_ApMaternoClie.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_ApPaternoClie.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_ValeNew.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFechaIni.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFechaIni.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_NombreClie.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_DistribNuevo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_DistribNombre.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.DGridVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGridPagos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pnl_
        '
        Me.Pnl_.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_.Controls.Add(Me.Lbl_Status)
        Me.Pnl_.Controls.Add(Me.Txt_Nota)
        Me.Pnl_.Controls.Add(Me.Label1)
        Me.Pnl_.Location = New System.Drawing.Point(12, 12)
        Me.Pnl_.Name = "Pnl_"
        Me.Pnl_.Size = New System.Drawing.Size(1095, 60)
        Me.Pnl_.TabIndex = 0
        '
        'Lbl_Status
        '
        Me.Lbl_Status.Appearance.BackColor = System.Drawing.Color.White
        Me.Lbl_Status.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Status.Appearance.ForeColor = System.Drawing.Color.Red
        Me.Lbl_Status.Location = New System.Drawing.Point(420, 23)
        Me.Lbl_Status.Name = "Lbl_Status"
        Me.Lbl_Status.Size = New System.Drawing.Size(0, 19)
        Me.Lbl_Status.TabIndex = 2
        '
        'Txt_Nota
        '
        Me.Txt_Nota.Location = New System.Drawing.Point(78, 17)
        Me.Txt_Nota.Name = "Txt_Nota"
        Me.Txt_Nota.Size = New System.Drawing.Size(111, 20)
        Me.Txt_Nota.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nota:"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Txt_Vale)
        Me.Panel1.Controls.Add(Me.LabelControl9)
        Me.Panel1.Controls.Add(Me.Dt_Apagar)
        Me.Panel1.Controls.Add(Me.LabelControl8)
        Me.Panel1.Controls.Add(Me.Txt_Importe)
        Me.Panel1.Controls.Add(Me.LabelControl4)
        Me.Panel1.Controls.Add(Me.Txt_FechaCompra)
        Me.Panel1.Controls.Add(Me.LabelControl3)
        Me.Panel1.Controls.Add(Me.Txt_Cliente)
        Me.Panel1.Controls.Add(Me.LabelControl2)
        Me.Panel1.Controls.Add(Me.Txt_Distribuidor)
        Me.Panel1.Controls.Add(Me.LabelControl1)
        Me.Panel1.Location = New System.Drawing.Point(12, 78)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1095, 104)
        Me.Panel1.TabIndex = 1
        '
        'Txt_Vale
        '
        Me.Txt_Vale.Location = New System.Drawing.Point(549, 41)
        Me.Txt_Vale.Name = "Txt_Vale"
        Me.Txt_Vale.Properties.ReadOnly = True
        Me.Txt_Vale.Size = New System.Drawing.Size(148, 20)
        Me.Txt_Vale.TabIndex = 50
        '
        'LabelControl9
        '
        Me.LabelControl9.Location = New System.Drawing.Point(460, 43)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(20, 13)
        Me.LabelControl9.TabIndex = 49
        Me.LabelControl9.Text = "Vale"
        '
        'Dt_Apagar
        '
        Me.Dt_Apagar.EditValue = Nothing
        Me.Dt_Apagar.Location = New System.Drawing.Point(549, 15)
        Me.Dt_Apagar.Name = "Dt_Apagar"
        Me.Dt_Apagar.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Dt_Apagar.Properties.ReadOnly = True
        Me.Dt_Apagar.Size = New System.Drawing.Size(148, 20)
        Me.Dt_Apagar.TabIndex = 48
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(464, 18)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(79, 13)
        Me.LabelControl8.TabIndex = 47
        Me.LabelControl8.Text = "Empiece a Pagar"
        '
        'Txt_Importe
        '
        Me.Txt_Importe.Location = New System.Drawing.Point(344, 72)
        Me.Txt_Importe.Name = "Txt_Importe"
        Me.Txt_Importe.Properties.ReadOnly = True
        Me.Txt_Importe.Size = New System.Drawing.Size(96, 20)
        Me.Txt_Importe.TabIndex = 9
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(269, 75)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(38, 13)
        Me.LabelControl4.TabIndex = 8
        Me.LabelControl4.Text = "Importe"
        '
        'Txt_FechaCompra
        '
        Me.Txt_FechaCompra.Location = New System.Drawing.Point(93, 72)
        Me.Txt_FechaCompra.Name = "Txt_FechaCompra"
        Me.Txt_FechaCompra.Properties.ReadOnly = True
        Me.Txt_FechaCompra.Size = New System.Drawing.Size(96, 20)
        Me.Txt_FechaCompra.TabIndex = 7
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(18, 75)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(69, 13)
        Me.LabelControl3.TabIndex = 6
        Me.LabelControl3.Text = "Fecha Compra"
        '
        'Txt_Cliente
        '
        Me.Txt_Cliente.Location = New System.Drawing.Point(78, 41)
        Me.Txt_Cliente.Name = "Txt_Cliente"
        Me.Txt_Cliente.Properties.ReadOnly = True
        Me.Txt_Cliente.Size = New System.Drawing.Size(362, 20)
        Me.Txt_Cliente.TabIndex = 5
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(18, 44)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(33, 13)
        Me.LabelControl2.TabIndex = 4
        Me.LabelControl2.Text = "Cliente"
        '
        'Txt_Distribuidor
        '
        Me.Txt_Distribuidor.Location = New System.Drawing.Point(78, 15)
        Me.Txt_Distribuidor.Name = "Txt_Distribuidor"
        Me.Txt_Distribuidor.Properties.ReadOnly = True
        Me.Txt_Distribuidor.Size = New System.Drawing.Size(362, 20)
        Me.Txt_Distribuidor.TabIndex = 3
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(18, 18)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(54, 13)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Distribuidor"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.Txt_ApMaternoClie)
        Me.Panel2.Controls.Add(Me.Txt_ApPaternoClie)
        Me.Panel2.Controls.Add(Me.Txt_ValeNew)
        Me.Panel2.Controls.Add(Me.LabelControl10)
        Me.Panel2.Controls.Add(Me.Btn_Aceptar)
        Me.Panel2.Controls.Add(Me.DEFechaIni)
        Me.Panel2.Controls.Add(Me.LabelControl7)
        Me.Panel2.Controls.Add(Me.Txt_NombreClie)
        Me.Panel2.Controls.Add(Me.LabelControl6)
        Me.Panel2.Controls.Add(Me.Txt_DistribNuevo)
        Me.Panel2.Controls.Add(Me.Txt_DistribNombre)
        Me.Panel2.Controls.Add(Me.LabelControl5)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New System.Drawing.Point(12, 408)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1090, 114)
        Me.Panel2.TabIndex = 2
        '
        'Txt_ApMaternoClie
        '
        Me.Txt_ApMaternoClie.Location = New System.Drawing.Point(421, 50)
        Me.Txt_ApMaternoClie.Name = "Txt_ApMaternoClie"
        Me.Txt_ApMaternoClie.Size = New System.Drawing.Size(158, 20)
        Me.Txt_ApMaternoClie.TabIndex = 5
        '
        'Txt_ApPaternoClie
        '
        Me.Txt_ApPaternoClie.Location = New System.Drawing.Point(257, 50)
        Me.Txt_ApPaternoClie.Name = "Txt_ApPaternoClie"
        Me.Txt_ApPaternoClie.Size = New System.Drawing.Size(158, 20)
        Me.Txt_ApPaternoClie.TabIndex = 4
        '
        'Txt_ValeNew
        '
        Me.Txt_ValeNew.Location = New System.Drawing.Point(646, 20)
        Me.Txt_ValeNew.Name = "Txt_ValeNew"
        Me.Txt_ValeNew.Size = New System.Drawing.Size(148, 20)
        Me.Txt_ValeNew.TabIndex = 2
        '
        'LabelControl10
        '
        Me.LabelControl10.Location = New System.Drawing.Point(557, 22)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(20, 13)
        Me.LabelControl10.TabIndex = 51
        Me.LabelControl10.Text = "Vale"
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_Aceptar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.Btn_Aceptar.Location = New System.Drawing.Point(1014, 53)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(58, 46)
        Me.Btn_Aceptar.TabIndex = 47
        Me.Btn_Aceptar.ToolTip = "Aplicar Cambios en el Cargo"
        '
        'DEFechaIni
        '
        Me.DEFechaIni.EditValue = Nothing
        Me.DEFechaIni.Location = New System.Drawing.Point(103, 79)
        Me.DEFechaIni.Name = "DEFechaIni"
        Me.DEFechaIni.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFechaIni.Size = New System.Drawing.Size(148, 20)
        Me.DEFechaIni.TabIndex = 6
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(18, 82)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(79, 13)
        Me.LabelControl7.TabIndex = 9
        Me.LabelControl7.Text = "Empiece a Pagar"
        '
        'Txt_NombreClie
        '
        Me.Txt_NombreClie.Location = New System.Drawing.Point(93, 50)
        Me.Txt_NombreClie.Name = "Txt_NombreClie"
        Me.Txt_NombreClie.Size = New System.Drawing.Size(158, 20)
        Me.Txt_NombreClie.TabIndex = 3
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(18, 53)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(33, 13)
        Me.LabelControl6.TabIndex = 7
        Me.LabelControl6.Text = "Cliente"
        '
        'Txt_DistribNuevo
        '
        Me.Txt_DistribNuevo.Location = New System.Drawing.Point(93, 24)
        Me.Txt_DistribNuevo.Name = "Txt_DistribNuevo"
        Me.Txt_DistribNuevo.Size = New System.Drawing.Size(79, 20)
        Me.Txt_DistribNuevo.TabIndex = 1
        '
        'Txt_DistribNombre
        '
        Me.Txt_DistribNombre.Enabled = False
        Me.Txt_DistribNombre.Location = New System.Drawing.Point(178, 24)
        Me.Txt_DistribNombre.Name = "Txt_DistribNombre"
        Me.Txt_DistribNombre.Size = New System.Drawing.Size(362, 20)
        Me.Txt_DistribNombre.TabIndex = 5
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(18, 27)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(54, 13)
        Me.LabelControl5.TabIndex = 4
        Me.LabelControl5.Text = "Distribuidor"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Modificaciones"
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.DGridVenta)
        Me.Panel3.Controls.Add(Me.DGridPagos)
        Me.Panel3.Location = New System.Drawing.Point(12, 188)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1095, 202)
        Me.Panel3.TabIndex = 3
        '
        'DGridVenta
        '
        Me.DGridVenta.Location = New System.Drawing.Point(495, 12)
        Me.DGridVenta.MainView = Me.GridView2
        Me.DGridVenta.Name = "DGridVenta"
        Me.DGridVenta.Size = New System.Drawing.Size(593, 200)
        Me.DGridVenta.TabIndex = 1
        Me.DGridVenta.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.DGridVenta
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsBehavior.ReadOnly = True
        '
        'DGridPagos
        '
        Me.DGridPagos.Location = New System.Drawing.Point(6, 12)
        Me.DGridPagos.MainView = Me.GridView1
        Me.DGridPagos.Name = "DGridPagos"
        Me.DGridPagos.Size = New System.Drawing.Size(449, 200)
        Me.DGridPagos.TabIndex = 0
        Me.DGridPagos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.DGridPagos
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.ReadOnly = True
        '
        'frmModificarCargo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1119, 534)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Pnl_)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmModificarCargo"
        Me.Text = "Modificar Cargo"
        Me.Pnl_.ResumeLayout(False)
        Me.Pnl_.PerformLayout()
        CType(Me.Txt_Nota.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Txt_Vale.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dt_Apagar.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dt_Apagar.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_Importe.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_FechaCompra.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_Cliente.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_Distribuidor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.Txt_ApMaternoClie.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_ApPaternoClie.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_ValeNew.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFechaIni.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFechaIni.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_NombreClie.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_DistribNuevo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_DistribNombre.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        CType(Me.DGridVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGridPagos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Pnl_ As Panel
    Friend WithEvents Txt_Nota As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Txt_Importe As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_FechaCompra As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_Cliente As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_Distribuidor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Txt_DistribNuevo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Txt_DistribNombre As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Label2 As Label
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_NombreClie As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Dt_Apagar As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEFechaIni As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Btn_Aceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Panel3 As Panel
    Friend WithEvents DGridVenta As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents DGridPagos As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Lbl_Status As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_Vale As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_ValeNew As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_ApMaternoClie As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Txt_ApPaternoClie As DevExpress.XtraEditors.TextEdit
End Class
