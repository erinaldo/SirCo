<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPpalDespacho
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txt_Serie = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Grido = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Btn_Filtro = New System.Windows.Forms.Button()
        Me.Btn_Excel = New System.Windows.Forms.Button()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.Txt_OperationId = New System.Windows.Forms.TextBox()
        Me.Lbl_CodigoBarras = New System.Windows.Forms.Label()
        Me.Txt_Traspaso = New System.Windows.Forms.TextBox()
        Me.Lbl_Traspaso = New System.Windows.Forms.Label()
        Me.Btn_PDF = New System.Windows.Forms.Button()
        Me.Btn_Aceptar = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.Grido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Txt_OperationId)
        Me.Panel1.Controls.Add(Me.Lbl_CodigoBarras)
        Me.Panel1.Controls.Add(Me.Txt_Traspaso)
        Me.Panel1.Controls.Add(Me.Lbl_Traspaso)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Txt_Serie)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Location = New System.Drawing.Point(8, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(789, 103)
        Me.Panel1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(310, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(287, 20)
        Me.Label2.TabIndex = 113
        Me.Label2.Text = "Siempre tenga lista la impresora... "
        '
        'Txt_Serie
        '
        Me.Txt_Serie.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Txt_Serie.BackColor = System.Drawing.Color.PowderBlue
        Me.Txt_Serie.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Serie.Location = New System.Drawing.Point(86, 15)
        Me.Txt_Serie.MaxLength = 13
        Me.Txt_Serie.Name = "Txt_Serie"
        Me.Txt_Serie.Size = New System.Drawing.Size(174, 29)
        Me.Txt_Serie.TabIndex = 111
        Me.Txt_Serie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(31, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 18)
        Me.Label7.TabIndex = 112
        Me.Label7.Text = "Serie"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Grido)
        Me.Panel2.Location = New System.Drawing.Point(8, 107)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(789, 314)
        Me.Panel2.TabIndex = 1
        '
        'Grido
        '
        Me.Grido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grido.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Grido.Location = New System.Drawing.Point(0, 0)
        Me.Grido.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.Grido.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Grido.MainView = Me.GridView1
        Me.Grido.Name = "Grido"
        Me.Grido.Size = New System.Drawing.Size(787, 312)
        Me.Grido.TabIndex = 8
        Me.Grido.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7})
        Me.GridView1.GridControl = Me.Grido
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click
        Me.GridView1.OptionsBehavior.ReadOnly = True
        Me.GridView1.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.RowAutoHeight = True
        '
        'GridColumn1
        '
        Me.GridColumn1.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridColumn1.AppearanceCell.Options.UseFont = True
        Me.GridColumn1.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridColumn1.AppearanceHeader.Options.UseFont = True
        Me.GridColumn1.Caption = "Marca"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 14.25!)
        Me.GridColumn2.AppearanceCell.Options.UseFont = True
        Me.GridColumn2.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumn2.AppearanceHeader.Options.UseFont = True
        Me.GridColumn2.Caption = "Modelo"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        '
        'GridColumn3
        '
        Me.GridColumn3.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 14.25!)
        Me.GridColumn3.AppearanceCell.Options.UseFont = True
        Me.GridColumn3.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumn3.AppearanceHeader.Options.UseFont = True
        Me.GridColumn3.Caption = "Medida"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        '
        'GridColumn4
        '
        Me.GridColumn4.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 14.25!)
        Me.GridColumn4.AppearanceCell.Options.UseFont = True
        Me.GridColumn4.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumn4.AppearanceHeader.Options.UseFont = True
        Me.GridColumn4.Caption = "Serie"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 3
        '
        'GridColumn5
        '
        Me.GridColumn5.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 14.25!)
        Me.GridColumn5.AppearanceCell.Options.UseFont = True
        Me.GridColumn5.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumn5.AppearanceHeader.Options.UseFont = True
        Me.GridColumn5.Caption = "Canal"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 4
        '
        'GridColumn6
        '
        Me.GridColumn6.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 14.25!)
        Me.GridColumn6.AppearanceCell.Options.UseFont = True
        Me.GridColumn6.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumn6.AppearanceHeader.Options.UseFont = True
        Me.GridColumn6.Caption = "Id Pedido"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 5
        '
        'GridColumn7
        '
        Me.GridColumn7.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 14.25!)
        Me.GridColumn7.AppearanceCell.Options.UseFont = True
        Me.GridColumn7.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumn7.AppearanceHeader.Options.UseFont = True
        Me.GridColumn7.Caption = "Venta Nuestra"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 6
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Btn_PDF)
        Me.Panel3.Controls.Add(Me.Btn_Aceptar)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.Btn_Filtro)
        Me.Panel3.Controls.Add(Me.Btn_Excel)
        Me.Panel3.Controls.Add(Me.Btn_Salir)
        Me.Panel3.Location = New System.Drawing.Point(8, 427)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(786, 55)
        Me.Panel3.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.MediumVioletRed
        Me.Label1.Location = New System.Drawing.Point(33, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(423, 20)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Empaque con cuidado el producto y pegue la guía..."
        '
        'Btn_Filtro
        '
        Me.Btn_Filtro.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Filtro.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Filtro.Image = Global.SIRCO.My.Resources.Resources.magnifier_zoom_in
        Me.Btn_Filtro.Location = New System.Drawing.Point(631, 0)
        Me.Btn_Filtro.Name = "Btn_Filtro"
        Me.Btn_Filtro.Size = New System.Drawing.Size(51, 53)
        Me.Btn_Filtro.TabIndex = 16
        Me.Btn_Filtro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Filtro.UseVisualStyleBackColor = True
        '
        'Btn_Excel
        '
        Me.Btn_Excel.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Excel.Image = Global.SIRCO.My.Resources.Resources.table_excel
        Me.Btn_Excel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Excel.Location = New System.Drawing.Point(682, 0)
        Me.Btn_Excel.Name = "Btn_Excel"
        Me.Btn_Excel.Size = New System.Drawing.Size(51, 53)
        Me.Btn_Excel.TabIndex = 15
        Me.Btn_Excel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Excel.UseVisualStyleBackColor = True
        '
        'Btn_Salir
        '
        Me.Btn_Salir.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Salir.Image = Global.SIRCO.My.Resources.Resources.door_out
        Me.Btn_Salir.Location = New System.Drawing.Point(733, 0)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(51, 53)
        Me.Btn_Salir.TabIndex = 14
        Me.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Salir.UseVisualStyleBackColor = True
        '
        'Txt_OperationId
        '
        Me.Txt_OperationId.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Txt_OperationId.BackColor = System.Drawing.Color.MistyRose
        Me.Txt_OperationId.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_OperationId.Location = New System.Drawing.Point(595, 3)
        Me.Txt_OperationId.MaxLength = 8
        Me.Txt_OperationId.Name = "Txt_OperationId"
        Me.Txt_OperationId.Size = New System.Drawing.Size(189, 26)
        Me.Txt_OperationId.TabIndex = 144
        Me.Txt_OperationId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Txt_OperationId.Visible = False
        '
        'Lbl_CodigoBarras
        '
        Me.Lbl_CodigoBarras.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Lbl_CodigoBarras.AutoSize = True
        Me.Lbl_CodigoBarras.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_CodigoBarras.Location = New System.Drawing.Point(472, 6)
        Me.Lbl_CodigoBarras.Name = "Lbl_CodigoBarras"
        Me.Lbl_CodigoBarras.Size = New System.Drawing.Size(117, 20)
        Me.Lbl_CodigoBarras.TabIndex = 147
        Me.Lbl_CodigoBarras.Text = "Pedido Venta"
        Me.Lbl_CodigoBarras.Visible = False
        '
        'Txt_Traspaso
        '
        Me.Txt_Traspaso.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Txt_Traspaso.BackColor = System.Drawing.Color.PowderBlue
        Me.Txt_Traspaso.Enabled = False
        Me.Txt_Traspaso.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Traspaso.Location = New System.Drawing.Point(595, 36)
        Me.Txt_Traspaso.MaxLength = 2
        Me.Txt_Traspaso.Name = "Txt_Traspaso"
        Me.Txt_Traspaso.ReadOnly = True
        Me.Txt_Traspaso.Size = New System.Drawing.Size(189, 26)
        Me.Txt_Traspaso.TabIndex = 145
        Me.Txt_Traspaso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Lbl_Traspaso
        '
        Me.Lbl_Traspaso.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Lbl_Traspaso.AutoSize = True
        Me.Lbl_Traspaso.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Traspaso.Location = New System.Drawing.Point(471, 39)
        Me.Lbl_Traspaso.Name = "Lbl_Traspaso"
        Me.Lbl_Traspaso.Size = New System.Drawing.Size(107, 20)
        Me.Lbl_Traspaso.TabIndex = 146
        Me.Lbl_Traspaso.Text = "Marketplace"
        '
        'Btn_PDF
        '
        Me.Btn_PDF.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_PDF.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_PDF.Image = Global.SIRCO.My.Resources.Resources.pdf
        Me.Btn_PDF.Location = New System.Drawing.Point(529, 0)
        Me.Btn_PDF.Name = "Btn_PDF"
        Me.Btn_PDF.Size = New System.Drawing.Size(51, 53)
        Me.Btn_PDF.TabIndex = 19
        Me.Btn_PDF.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_PDF.UseVisualStyleBackColor = True
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Aceptar.Image = Global.SIRCO.My.Resources.Resources.carrito
        Me.Btn_Aceptar.Location = New System.Drawing.Point(580, 0)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(51, 53)
        Me.Btn_Aceptar.TabIndex = 18
        Me.Btn_Aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Aceptar.UseVisualStyleBackColor = True
        '
        'frmPpalDespacho
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(806, 494)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmPpalDespacho"
        Me.Text = "Modulo de Salida"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.Grido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Txt_Serie As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Btn_Filtro As Button
    Friend WithEvents Btn_Excel As Button
    Friend WithEvents Btn_Salir As Button
    Friend WithEvents Grido As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Txt_OperationId As TextBox
    Friend WithEvents Lbl_CodigoBarras As Label
    Friend WithEvents Txt_Traspaso As TextBox
    Friend WithEvents Lbl_Traspaso As Label
    Friend WithEvents Btn_PDF As Button
    Friend WithEvents Btn_Aceptar As Button
End Class
