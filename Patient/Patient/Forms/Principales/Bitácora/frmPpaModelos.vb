Public Class frmPpalModelos
    'mreyes 10/Febrero/2012 02:00 p.m.
    'Modif. Tony García 25/Abril/2013 9:50 a.m.
    Private objDataSet As Data.DataSet
    Dim IdArticulob As Integer
    Dim Marcab As String
    Dim ModeloB As String
    Dim Estilofb As String
    'Dim IdDivisionb As Integer
    'Dim IdDepartamentob As Integer
    'Dim IdFamiliab As Integer
    'Dim IdLineab As Integer
    'Dim IdL1b As Integer
    'Dim IdL2b As Integer
    'Dim IdL3b As Integer
    'Dim IdL4b As Integer
    'Dim IdL5b As Integer
    'Dim IdL6b As Integer

    Dim IdDivisionb As String
    Dim IdDepartamentob As String
    Dim IdFamiliab As String
    Dim IdLineab As String
    Dim IdL1b As String
    Dim IdL2b As String
    Dim IdL3b As String
    Dim IdL4b As String
    Dim IdL5b As String
    Dim IdL6b As String


    Dim cveDivisionb As String = ""
    Dim cveDepartamentob As String = ""
    Dim cveFamiliab As String = ""
    Dim cveLineab As String = ""
    Dim cveL1b As String = ""
    Dim cveL2b As String = ""
    Dim cveL3b As String = ""
    Dim cveL4b As String = ""
    Dim cveL5b As String = ""
    Dim cveL6b As String = ""

    Dim FecRecA As String = ""
    Dim FecRecB As String = ""

    Dim Proveedorb As String
    Dim FechaInib As String
    Dim FechaFinb As String
    Dim blnMostrarEstruct As Boolean = False
    'Dim blnPrimero As Boolean = True

    Dim Sw_Load As Boolean = False
    Dim MarcaFOTO As String = ""
    Dim EstiloNFOTO As String = ""
    Dim Sw_NoRegistros As Boolean = False

    Private Sub frmPpalEstilos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If

        If e.KeyCode = Keys.F5 Then
            Call Btn_Filtro_Click_1(sender, e)
        End If
    End Sub
    Private Sub frmPpalEstilos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Sw_Load = True
            Lbl_Msje.Text = ""
            Call LimpiarBusqueda()
            Call RellenaGrid()
            Call GenerarToolTip()
            PBox.Location = New Point(Me.Width - 400, -3)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub GenerarToolTip()
        Try

            ToolTip.SetToolTip(Btn_Nuevo, "Nuevo Artículo")
            ToolTip.SetToolTip(Btn_Editar, "Editar Artículo")
            ToolTip.SetToolTip(Btn_Eliminar, "Eliminar Artículo")
            ToolTip.SetToolTip(Btn_Consultar, "Consultar Artículo")

            ToolTip.SetToolTip(Btn_Filtro, "Búsqueda Avanzada")
            'ToolTip.SetToolTip(Btn_Refrescar, "Refrescar Información")
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
            ToolTip.SetToolTip(Btn_Imprimir, "Imprimir Información")
            'ToolTip.SetToolTip(Btn_Pdf, "Generar Información en PDF")
            ToolTip.SetToolTip(Btn_Salir, "Salir")
            ToolTip.SetToolTip(Btn_Foto, "Foto Estilo")
            ToolTip.SetToolTip(Btn_CapturarCorrida, "Capturar Corrida")


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub RellenaGrid()
        Using objCatalogoModelos As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
            Try
                Me.Cursor = Cursors.WaitCursor
                DGrid.ReadOnly = True
                DGrid.DataSource = Nothing

                If Sw_Load = True Then
                    Sw_Load = False
                Else
                    If Chk_VerImagen.Checked = True Then
                        DGrid.Columns.Remove("Imagen")
                    End If
                End If

                'DGrid.Columns.Clear()
                'DGrid.Rows.Clear()
                'DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells


                objDataSet = objCatalogoModelos.usp_PpalCatalogoModelos(IdArticulob, Marcab, ModeloB, Estilofb, IdDivisionb, IdDepartamentob, _
                                                                    IdFamiliab, IdLineab, IdL1b, IdL2b, IdL3b, IdL4b, IdL5b, IdL6b, _
                                                                    Proveedorb, FechaInib, FechaFinb, FecRecA, FecRecB)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section
                    Lbl_Total.Text = objDataSet.Tables(0).Rows.Count.ToString + " Artículos Encontrados"
                    Lbl_Msje.Text = "Espere un momento por favor... cargando información..."
                    DGrid.Visible = False
                    DGrid.Refresh()
                    Application.DoEvents()
                    DGrid.DataSource = objDataSet.Tables(0)
                    InicializaGrid()
                    Me.Cursor = Cursors.Default
                    'LimpiarBusqueda()
                    Btn_Excel.Enabled = True
                    Btn_Editar.Enabled = True
                    Btn_Consultar.Enabled = True
                    Btn_Foto.Enabled = True
                    DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                    DGrid.Sort(DGrid.Columns("marca"), System.ComponentModel.ListSortDirection.Ascending)

                    DGrid.Visible = True
                    DGrid.Refresh()
                    Application.DoEvents()
                    'Dim myForm As New frmProgressBar
                    'myForm.Minimo = 0
                    'myForm.Maximo = DGrid.RowCount - 1
                    'myForm.Txt_Maximo.Text = DGrid.RowCount - 1
                    'myForm.Txt_Minimo.Text = 0
                    'frmProgressBar.ShowDialog()

                    Sw_NoRegistros = True
                Else
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    Lbl_Total.Text = "Ningún Artículo Encontrado"
                    MsgBox("No se encontraron Modelos que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")

                    Btn_Excel.Enabled = False
                    Btn_Editar.Enabled = False
                    Btn_Consultar.Enabled = False
                    Btn_Foto.Enabled = False
                End If

                Lbl_Msje.Text = ""

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using


    End Sub
    Private Sub LimpiarBusqueda()
        IdArticulob = 0
        Marcab = ""
        ModeloB = ""
        Estilofb = ""
        IdDivisionb = ""
        IdDepartamentob = ""
        IdFamiliab = ""
        IdLineab = ""
        IdL1b = ""
        IdL2b = ""
        IdL3b = ""
        IdL4b = ""
        IdL5b = ""
        IdL6b = ""
        Proveedorb = ""
        FechaInib = Format(Now.Add(New TimeSpan(-7, 0, 0, 0)), "yyyyMMdd")
        FechaFinb = Format(Now.Date, "yyyyMMdd")
    End Sub
    Private Sub Pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub
    Private Sub Btn_Refrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub CargarFotoArticulo(ByVal Marca, ByVal Estilon)
        'mreyes 14/Marzo/2012 07:06 p.m.
        'Glb_RutaArchivoFotos
        Try
            Dim Archivo As String = ""
            Dim NoFoto As String = "1"

            MarcaFOTO = Marca
            EstiloNFOTO = Estilon
            PBox.Visible = False
            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)

                Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Marca, Estilon, NoFoto)

                If objIO.pub_ExisteArchivo(Archivo) = True Then
                    PBox.Image = New System.Drawing.Bitmap(Archivo)
                    PBox.Visible = True
                    Exit Sub
                End If

                For i As Integer = 0 To 9
                    Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Marca, Estilon, i)
                    If objIO.pub_ExisteArchivo(Archivo) = True Then
                        PBox.Image = New System.Drawing.Bitmap(Archivo)
                        PBox.Visible = True
                        Exit Sub
                    End If
                Next

            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Sub InicializaGrid()
     
        Try

            DGrid.RowHeadersVisible = False
            DGrid.Columns(0).HeaderText = "IdArticulo" 'oculto
            DGrid.Columns(1).HeaderText = "Marca"
            DGrid.Columns(2).HeaderText = "Modelo"
            DGrid.Columns(3).HeaderText = "Estilo Fábrica"
            DGrid.Columns(4).HeaderText = "Descripción"
            DGrid.Columns(5).HeaderText = "División"
            DGrid.Columns(6).HeaderText = "Departamento"
            DGrid.Columns(7).HeaderText = "Familia"
            DGrid.Columns(8).HeaderText = "Línea"
            DGrid.Columns(9).HeaderText = "L1"
            DGrid.Columns(10).HeaderText = "L2"
            DGrid.Columns(11).HeaderText = "L3"
            DGrid.Columns(12).HeaderText = "L4"
            DGrid.Columns(13).HeaderText = "L5"
            DGrid.Columns(14).HeaderText = "L6"
            DGrid.Columns(15).HeaderText = "Proveedor"
            DGrid.Columns(16).HeaderText = "Med."
            'DGrid.Columns(13).HeaderText = "Clasificación"

            DGrid.Columns(0).Visible = False

            DGrid.Columns(0).Frozen = True
            DGrid.Columns(1).Frozen = True
            DGrid.Columns(2).Frozen = True

            DGrid.Columns(1).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Columns(1).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            DGrid.Columns(2).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Columns(2).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

            If blnMostrarEstruct = False Then
                DGrid.Columns(5).Visible = False
                DGrid.Columns(6).Visible = False
                DGrid.Columns(7).Visible = False
                DGrid.Columns(8).Visible = False
                DGrid.Columns(9).Visible = False
                DGrid.Columns(10).Visible = False
                DGrid.Columns(11).Visible = False
                DGrid.Columns(12).Visible = False
                DGrid.Columns(13).Visible = False
                DGrid.Columns(14).Visible = False
            ElseIf blnMostrarEstruct = True Then
                DGrid.Columns(5).Visible = True
                DGrid.Columns(6).Visible = True
                DGrid.Columns(7).Visible = True
                DGrid.Columns(8).Visible = True
                DGrid.Columns(9).Visible = True
                DGrid.Columns(10).Visible = True
                DGrid.Columns(11).Visible = True
                DGrid.Columns(12).Visible = True
                DGrid.Columns(13).Visible = True
                DGrid.Columns(14).Visible = True
            End If

            DGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells


            DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            '  DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

            'AgregarColumna()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    'Private Sub AgregarColumna()
    '    If Chk_VerImagen.Checked = True Then

    '        Dim colImagen As DataGridViewImageColumn = New DataGridViewImageColumn()
    '        colImagen.Name = "Imagen"
    '        colImagen.HeaderText = "Imagen"
    '        colImagen.DisplayIndex = 10
    '        colImagen.ImageLayout = DataGridViewImageCellLayout.Stretch
    '        colImagen.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

    '        ' añadir columna de imagen a la coleccion del grid 
    '        DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
    '        ''DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
    '        Me.DGrid.Columns.Add(colImagen)

    '    End If
    'End Sub
    Private Function ArchivoFotoArticulo(ByVal Marca As String, ByVal Estilon As String) As String
        'mreyes 07/Marzo/2012 06:49 p.m.
        'Glb_RutaArchivoFotos
        Try
            Dim Archivo As String = ""
            Dim NoFoto As String = "1"
            ArchivoFotoArticulo = ""
            Using objIO As New BCL.BCLio(Glb_ConStringCipSis)

                Archivo = objIO.pub_ArmarNombreFotoEstilo(Glb_RutaArchivoFotos, Marca, Estilon, NoFoto)

                If objIO.pub_ExisteArchivo(Archivo) = True Then
                    ArchivoFotoArticulo = Archivo
                    Exit Function
                End If

                For i As Integer = 0 To 9

                    Archivo = objIO.pub_ArmarNombreFotoEstilo(Glb_RutaArchivoFotos, Marca, Estilon, i)
                    If objIO.pub_ExisteArchivo(Archivo) = True Then
                        ArchivoFotoArticulo = Archivo
                        Exit Function
                    End If
                Next

            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
            ArchivoFotoArticulo = ""
        End Try
    End Function
    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Me.Close()
        Me.Dispose()
    End Sub
    Private Sub Btn_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Excel.Click
        Try
            If ExportarDGridAExcel(DGrid) = False Then
                MsgBox("Error al exportar a Excel. Intente nuevamente.", MsgBoxStyle.Critical, "Excel")
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Btn_Nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Nuevo.Click
        Dim myForm As New frmCatalogoModelos

        myForm.Accion = 1
        myForm.Txt_IdDivision.Text = 0
        myForm.Txt_IdDepto.Text = 0
        myForm.Txt_IdFamilia.Text = 0
        myForm.Txt_IdLinea.Text = 0
        myForm.Txt_IdL1.Text = 0
        myForm.Txt_IdL2.Text = 0
        myForm.Txt_IdL3.Text = 0
        myForm.Txt_IdL4.Text = 0
        myForm.ShowDialog()
        If myForm.Sw_Registro = True Then
            Call RellenaGrid()
        End If
    End Sub
    Private Sub DGrid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellDoubleClick


    End Sub
    Private Sub DGrid_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellEnter

    End Sub
    Private Sub DGrid_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGrid.CellFormatting

        Try
            If Chk_VerImagen.Checked = False Then Exit Sub
            Dim Marca As String = ""
            Dim Estilon As String = ""
            Dim Archivo As String = "d:\fotos\CRO_____32F1.jpg"

            If e.RowIndex = DGrid.RowCount - 1 Then Exit Sub
            '

            If Me.DGrid.Columns(e.ColumnIndex).Name = "Imagen" Then ' And e.ColumnIndex = 10 Then
                Me.Cursor = Cursors.WaitCursor

                Marca = DGrid.Rows(e.RowIndex).Cells("Marca").Value
                Estilon = DGrid.Rows(e.RowIndex).Cells("modelo").Value

                ' MsgBox(Marca & Estilon)
                If Marca <> "" And Estilon <> "" Then
                    Archivo = ArchivoFotoArticulo(Marca, Estilon)
                End If
                If Archivo <> "" Then

                    e.Value = New Bitmap(Archivo).GetThumbnailImage(70, 70, Nothing, System.IntPtr.Zero)

                    DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

                    Application.DoEvents()


                End If
                Me.Cursor = Cursors.Default
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub DGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.Click
        Try
            If Not IsDBNull(DGrid.Rows(DGrid.CurrentRow.Index).Cells("marca").Value) Then
                CargarFotoArticulo(DGrid.Rows(DGrid.CurrentRow.Index).Cells(1).Value, DGrid.Rows(DGrid.CurrentRow.Index).Cells(2).Value)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub DGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick
        Try

            If DGrid.Columns(DGrid.CurrentCell.ColumnIndex).Name = "Imagen" Then
                Btn_Foto_Click(sender, e)

            Else
                Call Btn_Consultar_Click(sender, e)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub DGrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DGrid.KeyPress
        Try
            Call Btn_Consultar_Click(sender, e)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Btn_Consultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Consultar.Click
        If Sw_NoRegistros = False Then Exit Sub
        Dim myForm As New frmCatalogoModelos

        myForm.Accion = 4
        myForm.Txt_IdArticulo.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idarticulo").Value.ToString.Trim()
        myForm.Txt_Marca.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("Marca").Value.ToString.Trim()
        myForm.Txt_Modelo.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("modelo").Value.ToString
        myForm.ShowDialog()

    End Sub
    Private Sub Btn_Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar.Click
        If Sw_NoRegistros = False Then Exit Sub
        Dim myForm As New frmCatalogoModelos

        myForm.Accion = 2
        myForm.Txt_IdArticulo.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idarticulo").Value.ToString.Trim()
        myForm.Txt_Marca.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("Marca").Value.ToString.Trim()
        myForm.Txt_Modelo.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("modelo").Value.ToString
        myForm.ShowDialog()
        If myForm.Sw_Registro = True Then
            Call RellenaGrid()
        End If
    End Sub
    Private Sub Btn_Filtro_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        'mreyes 28/Febrero/2012 10:08 a.m.
        'Modif. Tony Garcia - 26/Abril/2013 - 12:09 p.m.

        Dim myForm As New frmFiltrosModelos
        myForm.Txt_Marca.Text = Marcab
        myForm.Txt_Modelo.Text = ModeloB
        myForm.Txt_Estilof.Text = Estilofb
        myForm.Txt_DescripDivision.Text = IdDivisionb
        myForm.Txt_DescripDepto.Text = IdDepartamentob
        myForm.Txt_DescripFamilia.Text = IdFamiliab
        myForm.Txt_DescripLinea.Text = IdLineab
        myForm.Txt_DescripL1.Text = IdL1b
        myForm.Txt_DescripL2.Text = IdL2b
        myForm.Txt_DescripL3.Text = IdL3b
        myForm.Txt_DescripL4.Text = IdL4b
        myForm.Txt_DescripL5.Text = IdL5b
        myForm.Txt_DescripL6.Text = IdL6b
        myForm.Txt_Proveedor.Text = Proveedorb

        myForm.Txt_Division.Text = cveDivisionb
        myForm.Txt_Depto.Text = cveDepartamentob
        myForm.Txt_Familia.Text = cveFamiliab
        myForm.Txt_Linea.Text = cveLineab
        myForm.Txt_L1.Text = cveL1b
        myForm.Txt_L2.Text = cveL2b
        myForm.Txt_L3.Text = cveL3b
        myForm.Txt_L4.Text = cveL4b
        myForm.Txt_L5.Text = cveL5b
        myForm.Txt_L6.Text = cveL6b

        If FechaInib <> "1900-01-01" Then
            myForm.Chk_Fecha.Checked = True
            myForm.DTPicker2.Value = Mid(FechaInib, 7, 2) & "/" & Mid(FechaInib, 5, 2) & "/" & Mid(FechaInib, 1, 4)
            myForm.DTPicker3.Value = Mid(FechaFinb, 7, 2) & "/" & Mid(FechaFinb, 5, 2) & "/" & Mid(FechaFinb, 1, 4)
        End If

        myForm.ShowDialog()

        Marcab = myForm.Txt_Marca.Text
        ModeloB = myForm.Txt_Modelo.Text
        Estilofb = myForm.Txt_Estilof.Text


        IdDivisionb = myForm.Txt_DescripDivision.Text
        IdDepartamentob = myForm.Txt_DescripDepto.Text
        IdFamiliab = myForm.Txt_DescripFamilia.Text
        IdLineab = myForm.Txt_DescripLinea.Text
        IdL1b = myForm.Txt_DescripL1.Text
        IdL2b = myForm.Txt_DescripL2.Text
        IdL3b = myForm.Txt_DescripL3.Text
        IdL4b = myForm.Txt_DescripL4.Text
        IdL5b = myForm.Txt_DescripL5.Text
        IdL6b = myForm.Txt_DescripL6.Text


        cveDivisionb = myForm.Txt_Division.Text
        cveDepartamentob = myForm.Txt_Depto.Text
        cveFamiliab = myForm.Txt_Familia.Text
        cveLineab = myForm.Txt_Linea.Text
        cveL1b = myForm.Txt_L1.Text
        cveL2b = myForm.Txt_L2.Text
        cveL3b = myForm.Txt_L3.Text
        cveL4b = myForm.Txt_L4.Text
        cveL5b = myForm.Txt_L5.Text
        cveL6b = myForm.Txt_L6.Text

        
        Proveedorb = myForm.Txt_Proveedor.Text

        If myForm.Chk_Fecha.Checked = True Then
            FechaInib = Format(myForm.DTPicker2.Value, "yyyyMMdd")
            FechaFinb = Format(myForm.DTPicker3.Value, "yyyyMMdd")
        Else
            FechaInib = "1900-01-01"
            FechaFinb = "1900-01-01"

        End If

        If myForm.Chk_UltRecibo.Checked Then
            FecRecA = myForm.DT_RecIni.Value.ToString("yyyy-MM-dd")
            FecRecB = myForm.DT_RecFin.Value.ToString("yyyy-MM-dd")
        Else
            FecRecA = "1900-01-01"
            FecRecB = "1900-01-01"
        End If

        If myForm.Sw_Filtro = True Then
            Call RellenaGrid()
        End If
    End Sub
    Private Sub Btn_Filtro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub Btn_Foto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Foto.Click
        'mreyes 03/Marzo/2012 10:01 a.m.
        Try
            Dim myForm As New frmConsultaImagen
            myForm.Txt_Estilon.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("modelo").Value.ToString
            myForm.Txt_Marca.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("Marca").Value.ToString.Trim()
            myForm.Txt_NoFoto.Text = "1"
            myForm.ShowDialog()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub ImagenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImagenToolStripMenuItem.Click
        Call Btn_Foto_Click(sender, e)
    End Sub
    Private Sub NuevoEstiloToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoEstiloToolStripMenuItem.Click
        Call Btn_Nuevo_Click(sender, e)
    End Sub
    Private Sub EditarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditarToolStripMenuItem.Click
        Call Btn_Editar_Click(sender, e)
    End Sub
    Private Sub Btn_Eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Eliminar.Click
        If Sw_NoRegistros = False Then Exit Sub
    End Sub
    Private Sub Chk_VerImagen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_VerImagen.CheckedChanged
        ''If Sw_Load = True Then Exit Sub
        If Chk_VerImagen.Checked = False Then
            DGrid.Columns.Remove("Imagen")
            ''Else
            ''    AgregarColumna()
        End If
    End Sub
    Private Sub DGrid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGrid.KeyUp
        Try
            If Not IsDBNull(DGrid.Rows(DGrid.CurrentRow.Index).Cells("marca").Value) Then
                CargarFotoArticulo(DGrid.Rows(DGrid.CurrentRow.Index).Cells(1).Value, DGrid.Rows(DGrid.CurrentRow.Index).Cells(2).Value)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub PBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub PBox_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PBox.DoubleClick
        'mreyes 03/Marzo/2012 10:01 a.m.
        Try
            Dim myForm As New frmConsultaImagen
            myForm.Txt_Estilon.Text = EstiloNFOTO
            myForm.Txt_Marca.Text = MarcaFOTO
            myForm.Txt_NoFoto.Text = 1
            myForm.ShowDialog()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub
    Private Sub Chk_VerEstructura_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chk_VerEstructura.CheckedChanged
        Try
            If Chk_VerEstructura.Checked = True Then
                blnMostrarEstruct = True
            ElseIf Chk_VerEstructura.Checked = False Then
                blnMostrarEstruct = False
            End If

            Call InicializaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub DGrid_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DGrid.MouseDown
        Try
            If e.Button = Windows.Forms.MouseButtons.Right Then
                With Me.DGrid
                    Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                    If Hitest.Type = DataGridViewHitTestType.Cell Then
                        .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    End If
                End With
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Btn_CapturarCorrida.Click
        If MarcaFOTO <> "" Then
            Dim myForm As New frmCatalogoCorrida
            myForm.Marca = MarcaFOTO
            myForm.Modelo = EstiloNFOTO
            myForm.Estilof = DGrid.Rows(DGrid.CurrentRow.Index).Cells("estilof").Value
            myForm.Archivo = PBox.Image
            myForm.Color = DGrid.Rows(DGrid.CurrentRow.Index).Cells("descripc").Value
            myForm.StartPosition = FormStartPosition.CenterScreen
            myForm.ShowDialog()
        Else
            MsgBox("Debe de seleccionar un articulo valido", MsgBoxStyle.Information, "AVISO")
        End If
    End Sub

    Private Sub PBox_Click_1(sender As Object, e As EventArgs) Handles PBox.Click

    End Sub

    Private Sub ToolTip_Popup(sender As Object, e As PopupEventArgs) Handles ToolTip.Popup

    End Sub
End Class