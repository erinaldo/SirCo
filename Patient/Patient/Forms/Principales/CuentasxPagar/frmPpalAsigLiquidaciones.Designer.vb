﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class usp_PpalAsigLiquidaciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(usp_PpalAsigLiquidaciones))
        Me.Pnl_Botones = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Txt_Consignacion = New System.Windows.Forms.TextBox()
        Me.Txt_Transferencia = New System.Windows.Forms.TextBox()
        Me.Txt_Factoraje = New System.Windows.Forms.TextBox()
        Me.Btn_Aplicar = New System.Windows.Forms.Button()
        Me.Btn_Refrescar = New System.Windows.Forms.Button()
        Me.Btn_Proveedor = New System.Windows.Forms.Button()
        Me.Btn_Excel = New System.Windows.Forms.Button()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.DGrid1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.sfdRuta = New System.Windows.Forms.SaveFileDialog()
        Me.Pnl_Botones.SuspendLayout()
        CType(Me.DGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Label3)
        Me.Pnl_Botones.Controls.Add(Me.Label2)
        Me.Pnl_Botones.Controls.Add(Me.Label1)
        Me.Pnl_Botones.Controls.Add(Me.Txt_Consignacion)
        Me.Pnl_Botones.Controls.Add(Me.Txt_Transferencia)
        Me.Pnl_Botones.Controls.Add(Me.Txt_Factoraje)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Aplicar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Refrescar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Proveedor)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Excel)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Salir)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 394)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(800, 56)
        Me.Pnl_Botones.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(385, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Consignación"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(214, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Transferencia"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(69, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Factoraje"
        '
        'Txt_Consignacion
        '
        Me.Txt_Consignacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Consignacion.Location = New System.Drawing.Point(367, 22)
        Me.Txt_Consignacion.Name = "Txt_Consignacion"
        Me.Txt_Consignacion.Size = New System.Drawing.Size(114, 22)
        Me.Txt_Consignacion.TabIndex = 16
        Me.Txt_Consignacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Txt_Transferencia
        '
        Me.Txt_Transferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Transferencia.Location = New System.Drawing.Point(197, 22)
        Me.Txt_Transferencia.Name = "Txt_Transferencia"
        Me.Txt_Transferencia.Size = New System.Drawing.Size(115, 22)
        Me.Txt_Transferencia.TabIndex = 15
        Me.Txt_Transferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Txt_Factoraje
        '
        Me.Txt_Factoraje.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Factoraje.Location = New System.Drawing.Point(42, 22)
        Me.Txt_Factoraje.Name = "Txt_Factoraje"
        Me.Txt_Factoraje.Size = New System.Drawing.Size(112, 22)
        Me.Txt_Factoraje.TabIndex = 14
        Me.Txt_Factoraje.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Btn_Aplicar
        '
        Me.Btn_Aplicar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Aplicar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Aplicar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_Aplicar.Location = New System.Drawing.Point(541, 0)
        Me.Btn_Aplicar.Name = "Btn_Aplicar"
        Me.Btn_Aplicar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Aplicar.TabIndex = 13
        Me.Btn_Aplicar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Aplicar.UseVisualStyleBackColor = True
        '
        'Btn_Refrescar
        '
        Me.Btn_Refrescar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Refrescar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Refrescar.Image = Global.SIRCO.My.Resources.Resources.database_refresh
        Me.Btn_Refrescar.Location = New System.Drawing.Point(592, 0)
        Me.Btn_Refrescar.Name = "Btn_Refrescar"
        Me.Btn_Refrescar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Refrescar.TabIndex = 12
        Me.Btn_Refrescar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Refrescar.UseVisualStyleBackColor = True
        '
        'Btn_Proveedor
        '
        Me.Btn_Proveedor.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Proveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Proveedor.Image = Global.SIRCO.My.Resources.Resources.person
        Me.Btn_Proveedor.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Proveedor.Location = New System.Drawing.Point(643, 0)
        Me.Btn_Proveedor.Name = "Btn_Proveedor"
        Me.Btn_Proveedor.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Proveedor.TabIndex = 11
        Me.Btn_Proveedor.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Proveedor.UseVisualStyleBackColor = True
        '
        'Btn_Excel
        '
        Me.Btn_Excel.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Excel.Image = Global.SIRCO.My.Resources.Resources.table_excel
        Me.Btn_Excel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Excel.Location = New System.Drawing.Point(694, 0)
        Me.Btn_Excel.Name = "Btn_Excel"
        Me.Btn_Excel.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Excel.TabIndex = 7
        Me.Btn_Excel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Excel.UseVisualStyleBackColor = True
        '
        'Btn_Salir
        '
        Me.Btn_Salir.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Salir.Image = Global.SIRCO.My.Resources.Resources.door_out
        Me.Btn_Salir.Location = New System.Drawing.Point(745, 0)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Salir.TabIndex = 5
        Me.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Salir.UseVisualStyleBackColor = True
        '
        'DGrid1
        '
        Me.DGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGrid1.Location = New System.Drawing.Point(0, 0)
        Me.DGrid1.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.DGrid1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.DGrid1.MainView = Me.GridView1
        Me.DGrid1.Name = "DGrid1"
        Me.DGrid1.Size = New System.Drawing.Size(800, 394)
        Me.DGrid1.TabIndex = 8
        Me.DGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Appearance.FooterPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView1.Appearance.FooterPanel.Options.UseFont = True
        Me.GridView1.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView1.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridView1.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridView1.GridControl = Me.DGrid1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.ReadOnly = True
        Me.GridView1.OptionsSelection.MultiSelect = True
        Me.GridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.GridView1.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsView.RowAutoHeight = True
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFooter = True
        '
        'sfdRuta
        '
        Me.sfdRuta.Filter = "Archivos Excel | *.xls"
        '
        'usp_PpalAsigLiquidaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.DGrid1)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "usp_PpalAsigLiquidaciones"
        Me.Text = "Asignación de Liquidaciones"
        Me.Pnl_Botones.ResumeLayout(False)
        Me.Pnl_Botones.PerformLayout()
        CType(Me.DGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Botones As Panel
    Friend WithEvents Btn_Refrescar As Button
    Friend WithEvents Btn_Proveedor As Button
    Friend WithEvents Btn_Excel As Button
    Friend WithEvents Btn_Salir As Button
    Friend WithEvents DGrid1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents sfdRuta As SaveFileDialog
    Friend WithEvents Btn_Aplicar As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Txt_Consignacion As TextBox
    Friend WithEvents Txt_Transferencia As TextBox
    Friend WithEvents Txt_Factoraje As TextBox
End Class
