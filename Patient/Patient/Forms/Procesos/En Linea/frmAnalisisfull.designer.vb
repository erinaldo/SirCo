<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAnalisisfull
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_mard = New System.Windows.Forms.Label()
        Me.dtp_FechaFin = New System.Windows.Forms.DateTimePicker()
        Me.dtp_FechaIni = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_filtro = New System.Windows.Forms.Button()
        Me.btn_salir = New System.Windows.Forms.Button()
        Me.lbl_FechaFin = New System.Windows.Forms.Label()
        Me.lbl_FechaIni = New System.Windows.Forms.Label()
        Me.btn_refrescar = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.idAmazon = New System.Windows.Forms.LinkLabel()
        Me.idML = New System.Windows.Forms.LinkLabel()
        Me.Descrip = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Estilof = New System.Windows.Forms.Label()
        Me.lbl_modelo = New System.Windows.Forms.Label()
        Me.lbl_marca = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.grido = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.lbl_mard)
        Me.Panel1.Controls.Add(Me.dtp_FechaFin)
        Me.Panel1.Controls.Add(Me.dtp_FechaIni)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btn_filtro)
        Me.Panel1.Controls.Add(Me.btn_salir)
        Me.Panel1.Controls.Add(Me.lbl_FechaFin)
        Me.Panel1.Controls.Add(Me.lbl_FechaIni)
        Me.Panel1.Controls.Add(Me.btn_refrescar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 489)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1054, 53)
        Me.Panel1.TabIndex = 0
        '
        'lbl_mard
        '
        Me.lbl_mard.AutoSize = True
        Me.lbl_mard.Location = New System.Drawing.Point(324, 24)
        Me.lbl_mard.Name = "lbl_mard"
        Me.lbl_mard.Size = New System.Drawing.Size(0, 13)
        Me.lbl_mard.TabIndex = 106
        Me.lbl_mard.Visible = False
        '
        'dtp_FechaFin
        '
        Me.dtp_FechaFin.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtp_FechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_FechaFin.Location = New System.Drawing.Point(179, 19)
        Me.dtp_FechaFin.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.dtp_FechaFin.Name = "dtp_FechaFin"
        Me.dtp_FechaFin.Size = New System.Drawing.Size(99, 20)
        Me.dtp_FechaFin.TabIndex = 105
        Me.dtp_FechaFin.Value = New Date(2020, 11, 10, 0, 0, 0, 0)
        Me.dtp_FechaFin.Visible = False
        '
        'dtp_FechaIni
        '
        Me.dtp_FechaIni.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtp_FechaIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_FechaIni.Location = New System.Drawing.Point(45, 19)
        Me.dtp_FechaIni.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.dtp_FechaIni.Name = "dtp_FechaIni"
        Me.dtp_FechaIni.Size = New System.Drawing.Size(99, 20)
        Me.dtp_FechaIni.TabIndex = 104
        Me.dtp_FechaIni.Value = New Date(2020, 11, 10, 0, 0, 0, 0)
        Me.dtp_FechaIni.Visible = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(759, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 103
        Me.Label2.Text = "Fecha Final"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(615, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 102
        Me.Label1.Text = "Fecha Inicial"
        '
        'btn_filtro
        '
        Me.btn_filtro.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_filtro.Image = Global.SIRCO.My.Resources.Resources.magnifier_zoom_in
        Me.btn_filtro.Location = New System.Drawing.Point(899, 0)
        Me.btn_filtro.Name = "btn_filtro"
        Me.btn_filtro.Size = New System.Drawing.Size(50, 50)
        Me.btn_filtro.TabIndex = 101
        Me.btn_filtro.UseVisualStyleBackColor = True
        '
        'btn_salir
        '
        Me.btn_salir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_salir.Image = Global.SIRCO.My.Resources.Resources.door_out
        Me.btn_salir.Location = New System.Drawing.Point(999, 0)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(50, 50)
        Me.btn_salir.TabIndex = 0
        Me.btn_salir.UseVisualStyleBackColor = True
        '
        'lbl_FechaFin
        '
        Me.lbl_FechaFin.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_FechaFin.AutoSize = True
        Me.lbl_FechaFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_FechaFin.Location = New System.Drawing.Point(749, 26)
        Me.lbl_FechaFin.Name = "lbl_FechaFin"
        Me.lbl_FechaFin.Size = New System.Drawing.Size(92, 17)
        Me.lbl_FechaFin.TabIndex = 100
        Me.lbl_FechaFin.Text = "29-12-2020"
        '
        'lbl_FechaIni
        '
        Me.lbl_FechaIni.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_FechaIni.AutoSize = True
        Me.lbl_FechaIni.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_FechaIni.Location = New System.Drawing.Point(607, 26)
        Me.lbl_FechaIni.Name = "lbl_FechaIni"
        Me.lbl_FechaIni.Size = New System.Drawing.Size(92, 17)
        Me.lbl_FechaIni.TabIndex = 100
        Me.lbl_FechaIni.Text = "29-12-2020"
        '
        'btn_refrescar
        '
        Me.btn_refrescar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_refrescar.Image = Global.SIRCO.My.Resources.Resources.database_refresh
        Me.btn_refrescar.Location = New System.Drawing.Point(949, 0)
        Me.btn_refrescar.Name = "btn_refrescar"
        Me.btn_refrescar.Size = New System.Drawing.Size(50, 50)
        Me.btn_refrescar.TabIndex = 1
        Me.btn_refrescar.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.idAmazon)
        Me.Panel2.Controls.Add(Me.idML)
        Me.Panel2.Controls.Add(Me.Descrip)
        Me.Panel2.Controls.Add(Me.Label34)
        Me.Panel2.Controls.Add(Me.Label33)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Estilof)
        Me.Panel2.Controls.Add(Me.lbl_modelo)
        Me.Panel2.Controls.Add(Me.lbl_marca)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1054, 101)
        Me.Panel2.TabIndex = 1
        '
        'idAmazon
        '
        Me.idAmazon.AutoSize = True
        Me.idAmazon.Location = New System.Drawing.Point(1090, 45)
        Me.idAmazon.Name = "idAmazon"
        Me.idAmazon.Size = New System.Drawing.Size(80, 13)
        Me.idAmazon.TabIndex = 17
        Me.idAmazon.TabStop = True
        Me.idAmazon.Text = "Ver publicación"
        '
        'idML
        '
        Me.idML.AutoSize = True
        Me.idML.Location = New System.Drawing.Point(948, 45)
        Me.idML.Name = "idML"
        Me.idML.Size = New System.Drawing.Size(80, 13)
        Me.idML.TabIndex = 16
        Me.idML.TabStop = True
        Me.idML.Text = "Ver publicación"
        '
        'Descrip
        '
        Me.Descrip.AutoSize = True
        Me.Descrip.Location = New System.Drawing.Point(278, 26)
        Me.Descrip.Name = "Descrip"
        Me.Descrip.Size = New System.Drawing.Size(0, 13)
        Me.Descrip.TabIndex = 15
        '
        'Label34
        '
        Me.Label34.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label34.AutoSize = True
        Me.Label34.ForeColor = System.Drawing.Color.SaddleBrown
        Me.Label34.Location = New System.Drawing.Point(780, 12)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(59, 13)
        Me.Label34.TabIndex = 14
        Me.Label34.Text = "ID Amazon"
        '
        'Label33
        '
        Me.Label33.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label33.AutoSize = True
        Me.Label33.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label33.Location = New System.Drawing.Point(640, 12)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(36, 13)
        Me.Label33.TabIndex = 13
        Me.Label33.Text = "ID ML"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(278, 3)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(91, 13)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "DESCRIPCION"
        '
        'Panel4
        '
        Me.Panel4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Label18)
        Me.Panel4.Controls.Add(Me.Label19)
        Me.Panel4.Controls.Add(Me.Label14)
        Me.Panel4.Controls.Add(Me.Label20)
        Me.Panel4.Location = New System.Drawing.Point(601, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(187, 99)
        Me.Panel4.TabIndex = 11
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(127, 22)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(60, 13)
        Me.Label18.TabIndex = 6
        Me.Label18.Text = "MARGEN"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(62, 22)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(56, 13)
        Me.Label19.TabIndex = 5
        Me.Label19.Text = "OFERTA"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(65, 2)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(55, 17)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "PRIME"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(-1, 22)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(53, 13)
        Me.Label20.TabIndex = 4
        Me.Label20.Text = "PRECIO"
        '
        'Panel3
        '
        Me.Panel3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Panel3.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label17)
        Me.Panel3.Controls.Add(Me.Label16)
        Me.Panel3.Controls.Add(Me.Label15)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Location = New System.Drawing.Point(414, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(187, 99)
        Me.Panel3.TabIndex = 10
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(128, 22)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(60, 13)
        Me.Label17.TabIndex = 3
        Me.Label17.Text = "MARGEN"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(63, 22)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(56, 13)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "OFERTA"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(0, 22)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(53, 13)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "PRECIO"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(70, 2)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(46, 17)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "FULL"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(205, 3)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "COSTO"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(133, 3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "CORRIDA"
        '
        'Estilof
        '
        Me.Estilof.AutoSize = True
        Me.Estilof.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Estilof.Location = New System.Drawing.Point(2, 31)
        Me.Estilof.Name = "Estilof"
        Me.Estilof.Size = New System.Drawing.Size(0, 17)
        Me.Estilof.TabIndex = 3
        '
        'lbl_modelo
        '
        Me.lbl_modelo.AutoSize = True
        Me.lbl_modelo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_modelo.Location = New System.Drawing.Point(42, 10)
        Me.lbl_modelo.Name = "lbl_modelo"
        Me.lbl_modelo.Size = New System.Drawing.Size(44, 17)
        Me.lbl_modelo.TabIndex = 2
        Me.lbl_modelo.Text = "2014"
        '
        'lbl_marca
        '
        Me.lbl_marca.AutoSize = True
        Me.lbl_marca.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_marca.Location = New System.Drawing.Point(3, 10)
        Me.lbl_marca.Name = "lbl_marca"
        Me.lbl_marca.Size = New System.Drawing.Size(33, 17)
        Me.lbl_marca.TabIndex = 1
        Me.lbl_marca.Text = "NIK"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(899, -2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(153, 101)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'grido
        '
        Me.grido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grido.Location = New System.Drawing.Point(0, 101)
        Me.grido.MainView = Me.GridView1
        Me.grido.Name = "grido"
        Me.grido.Size = New System.Drawing.Size(1054, 388)
        Me.grido.TabIndex = 2
        Me.grido.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.grido
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'frmAnalisisfull
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1054, 542)
        Me.Controls.Add(Me.grido)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.Name = "frmAnalisisfull"
        Me.Text = "Analisis FULL"
        Me.TransparencyKey = System.Drawing.Color.Lime
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btn_refrescar As Button
    Friend WithEvents lbl_FechaFin As Label
    Friend WithEvents lbl_FechaIni As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents grido As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Estilof As Label
    Friend WithEvents lbl_modelo As Label
    Friend WithEvents lbl_marca As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label12 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents btn_salir As Button
    Friend WithEvents Descrip As Label
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents idML As LinkLabel
    Friend WithEvents btn_filtro As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents idAmazon As LinkLabel
    Friend WithEvents dtp_FechaFin As DateTimePicker
    Friend WithEvents dtp_FechaIni As DateTimePicker
    Friend WithEvents lbl_mard As Label
End Class
