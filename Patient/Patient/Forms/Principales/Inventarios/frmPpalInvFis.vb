Imports System.IO
Public Class frmPpalInvFis
    'Mreyes 17/Junio/2015   10:13 a.m.
    Private objDataSet As Data.DataSet
    Dim Sw_NoRegistros As Boolean = False
    Dim IdReportaB As Integer = 0
    Dim IdAsignadoB As Integer = 0
    Dim SucursalB As String = ""
    Dim IdDeptoB As Integer = 0
    Dim DeptoB As String = ""
    Dim IdPuestoB As Integer = 0
    Dim IdActividadEmp As Integer = 0
    Dim EstatusB As String = ""
    'Dim SucursalN As String = ""


    Dim CveSucursalB As String = ""
    Dim FechaIniB As String = "1900-01-01"
    Dim FechaFinb As String = "1900-01-01"

    Dim Sw_Pintar As Boolean = False
    Dim Sw_Load As Boolean = True
    Public Opcion As Integer = 1
    Public IdActividad As Integer
    Dim NumIfB As Integer
    Dim FolioB As String = ""
    Dim MarcaFOTO As String = ""
    Dim EstiloNFOTO As String = ""
    Private izquierda As Integer = 0
    Private alto As Integer = 0

    Private Sub frmPpalConceptoRep_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Sw_NoRegistros = False Then Exit Sub
        If Sw_Load = True Then

            RellenaGrid(0)
            Sw_Load = False
            'AgregarColumna()
            '    Call BarrerGrid()
        End If


    End Sub



    Private Sub frmPpalActividadesEmp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then
                Me.Dispose()
                Me.Close()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmPpalActividadesEmp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            GenerarToolTip()
            If GLB_IdDeptoEmpleado <> 1 Then

                CveSucursalB = ""
            Else
                CveSucursalB = GLB_CveSucursal

            End If
            FechaFinb = Format(Now.Add(New TimeSpan(-1, 0, 0, 0)), "yyyy-MM-dd")
            FechaIniB = Format(Now.Add(New TimeSpan(-1, 0, 0, 0)), "yyyy-MM-dd")


            'Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub RellenaGrid(ByVal GeneradoB As Integer)
        'mreyes 17/Junio/2015   10:20 a.m.
        Try

            Using objBulto As New BCL.BCLInventarios(GLB_ConStringCipSis)
                objDataSet = objBulto.usp_PpalSubirInv(Txt_Sucursal.Text, NumIfB, GeneradoB)
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                DGrid.DataSource = Nothing
                DGrid.DataSource = objDataSet.Tables(0)
                Sw_NoRegistros = True
                InicializaGrid()
                'Colores()

            Else
                Sw_NoRegistros = False
                MessageBox.Show("No se cargo ninguna informacion.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub RellenaGridInvFis()
        'mreyes 23/Junio/2015  12:20 p.m.
        Try

            Using objBulto As New BCL.BCLInventarios(GLB_ConStringCipSis)
                objDataSet = objBulto.usp_PpalInvFis(Opcion, Txt_Sucursal.Text, FolioB, NumIfB, "1900-01-01")
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                DGrid.DataSource = Nothing
                DGrid.DataSource = objDataSet.Tables(0)
                Sw_NoRegistros = True

                InicializaGridInvFis()
                'Colores()

            Else
                Sw_NoRegistros = False
                MessageBox.Show("No se cargo ninguna informacion.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Filtro, "Búsqueda Avanzada")
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
            ToolTip.SetToolTip(Btn_Salir, "Salir")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub




    Private Sub InicializaGrid()
        Try

            'Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
            'Dim row As DataRow = dt.NewRow()
            'row(2) = "Total: "
            'row(4) = pub_SumarColumnaGrid(DGrid, 4, DGrid.RowCount - 1)
            'dt.Rows.Add(row)
            'DGrid.DataSource = dt


            DGrid.RowHeadersVisible = False
            'DGrid.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, 7, FontStyle.Regular)
            DGrid.Columns(0).HeaderText = "NúmIF"
            DGrid.Columns(1).HeaderText = "Archivo"
            DGrid.Columns(2).HeaderText = "Marca"
            DGrid.Columns(3).HeaderText = "Modelo"
            DGrid.Columns(4).HeaderText = "Corrida"
            DGrid.Columns(5).HeaderText = "Medida"
            DGrid.Columns(6).HeaderText = "Serie"
            DGrid.Columns(7).HeaderText = "Costo"
            DGrid.Columns(8).HeaderText = "Precio"

            DGrid.Columns(9).HeaderText = "Usuario"
            DGrid.Columns(10).HeaderText = "Fum"


            DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            DGrid.Columns(4).Visible = False
            DGrid.Columns(7).Visible = False
            DGrid.Columns(8).Visible = False


            'DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.BackColor = Color.PowderBlue
            'DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            'DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Btn_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If ExportarDGridAExcel(DGrid) = False Then
                MsgBox("Error al exportar a Excel. Intente nuevamente.", MsgBoxStyle.Critical, "Excel")
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.Click
        Try
            If Opcion = 2 Then
                If IsDBNull(DGrid.Rows(DGrid.CurrentRow.Index).Cells("marca").Value) Then
                    Exit Sub
                End If
                CargarFotoArticulo(DGrid.CurrentRow.Cells("marca").Value, DGrid.CurrentRow.Cells("estilon").Value)
            End If
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
            ESTILONFOTO = Estilon
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

    Private Sub DGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick
        Try
            If Opcion = 1 Then  'total
                Opcion = 2
  
                foliob = DGrid.Rows(DGrid.CurrentRow.Index).Cells("folio").Value

                Call RellenaGridInvFis()


            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub





    Private Sub Btn_Filtro_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim myForm As New frmFiltrosCorteFolios

            myForm.Txt_Sucursal.Text = CveSucursalB
            myForm.DTPicker2.Value = FechaIniB
            myForm.DTPicker3.Value = FechaFinb



            myForm.ShowDialog()

            If myForm.Sw_Filtro = False Then Exit Sub


            SucursalB = myForm.Txt_Sucursal.Text.Trim


            FechaIniB = Format(myForm.DTPicker2.Value, "yyyy-MM-dd")
            FechaFinb = Format(myForm.DTPicker3.Value, "yyyy-MM-dd")



            Call RellenaGrid(0)

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub AgregarColumna()
        Dim colImagen As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        colImagen.Name = "Selec"
        colImagen.HeaderText = "Selec"
        colImagen.DisplayIndex = 12
        colImagen.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        colImagen.CellTemplate = New DataGridViewCheckBoxCell()
        ' añadir columna de imagen a la coleccion del grid 
        DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        ''DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DGrid.Columns.Add(colImagen)
    End Sub



    Private Sub Btn_Editar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim myForm As New frmCatalogoReciboBultos
            myForm.Accion = 2
            myForm.Folio = DGrid.CurrentRow.Cells("Folio").Value.ToString
            myForm.FolioB = DGrid.CurrentRow.Cells("Folio").Value.ToString
            myForm.Txt_Folio.Text = DGrid.CurrentRow.Cells("idfoliosuc").Value.ToString

            myForm.ShowDialog()
            'If myForm.Guardo = True Then
            '    frmPpalActividadesEmp_Load(sender, e)
            'End If
            Call RellenaGrid(0)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Nuevo_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim myForm As New frmCatalogoReciboBultos
        Try
            myForm.Accion = 1
            myForm.ShowDialog()
            If myForm.Guardo = True Then
                frmPpalActividadesEmp_Load(sender, e)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    'Private Sub DGrid_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGrid.CellFormatting
    '    Try

    '        'Tony Garcia - 15/Octubre/2012 12:25 p.m.

    '        Dim Sw_NoEntro As Boolean = False

    '        Dim DiasEntrega As Integer = 0
    '        If Sw_Pintar = False Then Exit Sub

    '        If Me.DGrid.Columns(e.ColumnIndex).Name <> "estatus" Then Exit Sub
    '        ''If Me.DGrid.Columns(e.ColumnIndex).Name <> "fecha" Then Exit Sub
    '        If e.RowIndex >= DGrid.RowCount - 1 Then
    '            If Sw_Load = False Then
    '                Sw_Pintar = False
    '            End If
    '            Exit Sub
    '        End If

    '        If DGrid.Rows(e.RowIndex).Cells("estatus").Value = "CAPTURA" Then
    '            DGrid.Rows(e.RowIndex).Cells("estatus").Style.BackColor = Color.Yellow
    '            DGrid.Rows(e.RowIndex).Cells("estatus").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
    '        End If

    '        If DGrid.Rows(e.RowIndex).Cells("estatus").Value = "EN PROCESO" Then
    '            DGrid.Rows(e.RowIndex).Cells("estatus").Style.BackColor = Color.RoyalBlue
    '            DGrid.Rows(e.RowIndex).Cells("estatus").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
    '        End If

    '        If DGrid.Rows(e.RowIndex).Cells("estatus").Value = "EN ESPERA" Then
    '            DGrid.Rows(e.RowIndex).Cells("estatus").Style.BackColor = Color.Salmon
    '            DGrid.Rows(e.RowIndex).Cells("estatus").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
    '        End If

    '        If DGrid.Rows(e.RowIndex).Cells("estatus").Value = "PAUSADO" Then
    '            DGrid.Rows(e.RowIndex).Cells("estatus").Style.BackColor = Color.Orange
    '            DGrid.Rows(e.RowIndex).Cells("estatus").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
    '        End If

    '        If DGrid.Rows(e.RowIndex).Cells("estatus").Value = "REALIZADO" Then
    '            DGrid.Rows(e.RowIndex).Cells("estatus").Style.BackColor = Color.YellowGreen
    '            DGrid.Rows(e.RowIndex).Cells("estatus").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
    '        End If

    '        If DGrid.Rows(e.RowIndex).Cells("estatus").Value = "CANCELADO" Then
    '            DGrid.Rows(e.RowIndex).Cells("estatus").Style.BackColor = Color.Red
    '            DGrid.Rows(e.RowIndex).Cells("estatus").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
    '        End If

    '        If DGrid.Rows(e.RowIndex).Cells("estatus").Value = "NO APLICA" Then
    '            DGrid.Rows(e.RowIndex).Cells("estatus").Style.BackColor = Color.Gray
    '            DGrid.Rows(e.RowIndex).Cells("estatus").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
    '        End If

    '        DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    '    Catch ExceptionErr As Exception
    '        MessageBox.Show(ExceptionErr.Message.ToString)
    '    End Try
    'End Sub


    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub
    Private Sub TraerSucursal()

        If Txt_Sucursal.Text.Length = 0 Then Exit Sub

        Try
            'Get the specific project selected in the ListView control
            If Txt_Sucursal.Text.Trim.Length < 2 Then
                Txt_Sucursal.Text = pub_RellenarIzquierda(Txt_Sucursal.Text.Trim, 2)
            End If

            Call TxtLostfocusPersis(Txt_Sucursal, Txt_DescripSucursal, "S")


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub TxtLostfocusPersis(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
        'mreyes 28/Febrero/2012 01:30
        Dim myForm As New frmConsulta
        If Txt_Campo.Text.Length = 0 Then Exit Sub
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringPerSis)
            Try

                objDataSet = objMySqlGral.usp_TraerDescripcion(Tipo, Txt_Campo.Text.Trim, "")

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_Campo1.Text = objDataSet.Tables(0).Rows(0).Item("campo").ToString
                Else
                    Txt_Campo.Text = ""
                    myForm.Tipo = Tipo
                    myForm.ShowDialog()
                    Txt_Campo.Text = myForm.Campo
                    Txt_Campo1.Text = myForm.Campo1
                    If Txt_Campo.Text.Length = 0 Then
                        Txt_Campo.Focus()
                    End If
                End If


            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub Btn_ImprimirRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.AppStarting



        Call Imprimir()


        Me.Cursor = Cursors.Default
    End Sub


    Private Sub Imprimir()
        'mreyes 18/Junio/2015   09:58.
        Try
            Dim myForm As New frmReportsBrowser
            Dim Sw_Mas14 As Boolean = False
            Dim Cont As Integer = 0
            Dim Sw_Imprimir As Boolean = False

            myForm.objDataSetPpalCorteFolios = GenerarDSCortefolios()
            myForm.r_Titulo = Lbl_Leyenda.Text
            myForm.ReportIndex = 8456   'CUANDO SE GENERA LA PRIMERA VEZ nosotros .. el 1 es el proveedor , EL 3 ES EL DE CEDI



            myForm.Show()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub



    Private Function GenerarDSCortefolios() As DSPpalCorteFolios
        'mreyes 18/Junio/2015   10:16 a.m.
        Try
            '' Dim objDataSet As New DtReciboBono
            Dim Columna As Integer = 0
            Dim Cont As Integer = 0


            GenerarDSCortefolios = New DSPpalCorteFolios


            With DGrid
                Cont = 0

                For I As Integer = 0 To .RowCount - 2

                    Dim objDataRow1 As Data.DataRow = GenerarDSCortefolios.Tables("Tbl_CorteFolios").NewRow
                    objDataRow1.Item("sucursal") = .Rows(I).Cells("sucursal").Value
                    objDataRow1.Item("descrip") = .Rows(I).Cells("descrip").Value

                    objDataRow1.Item("tipo") = .Rows(I).Cells("tipo").Value
                    objDataRow1.Item("folioini") = .Rows(I).Cells("folioini").Value
                    objDataRow1.Item("foliofin") = .Rows(I).Cells("foliofin").Value

                    GenerarDSCortefolios.Tables("Tbl_CorteFolios").Rows.Add(objDataRow1)


                Next




            End With
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Private Sub Btn_Layout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Layout.Click
        Try
            If MsgBox("Está seguro de que ya escaneo todas las zonas y procederá a subir los archivos a sistema.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = vbNo Then Exit Sub

            Call usp_LeerArchivos()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub usp_LeerArchivos()
        Try
            Dim Sw_Inv As Boolean
            ' Dim folder As New DirectoryInfo("C:\Inventarios\")
            Dim folder As New DirectoryInfo(GLB_DireInv & Txt_DescripSucursal.Text & NumIfB & "\")

            Dim myStream As StreamReader = Nothing
            Dim NomArch As String

            Dim Archivo As String = ""
            P_Bar1.Minimum = 0



            For Each file As FileInfo In folder.GetFiles()
                Archivo = String.Concat(folder, file.Name)
                myStream = New StreamReader(Archivo)
                NomArch = myStream.ReadToEnd()
                Dim Series() As String = Split(NomArch, vbNewLine)
                P_Bar1.Minimum = 0
                P_Bar1.Maximum = Series.Length
                P_Bar1.Value = 0
                For i As Integer = 0 To Series.Length - 1
                    Dim Serie As String = Series(i).Trim
                    Lbl_Leyenda.Text = Archivo & "-" & Serie
                    If Serie <> "" Then
                        'GRABAR LA SERIE 
                        Using objInv As New BCL.BCLInventarios(GLB_ConStringCipSis)
                            'opcion int, NumIfB int, ArchivoB char(100), SerieB Char(13), IdusuarioB int
                            Sw_Inv = objInv.usp_CapturaLeerSeriesInv(1, Txt_Sucursal.Text, NumIfB, Archivo, Serie, GLB_Idempleado)
                        End Using
                    End If
                    P_Bar1.Value = P_Bar1.Value + 1
                    Lbl_Leyenda1.Text = i
                    Application.DoEvents()
                Next



            Next

            '''' hacer un select para mostrar en pantalla..

            Call RellenaGrid(0)

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try


    End Sub

    Private Sub Txt_Sucursal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Sucursal.LostFocus
        Try
            Call TraerSucursal()
            ' ir a buscar última referencia de inventario.

            Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringPerSis)
                Try


                    objDataSet = objMySqlGral.usp_TraerSucursalInv(Txt_Sucursal.Text)

                    If objDataSet.Tables(0).Rows.Count > 0 Then

                        If objDataSet.Tables(0).Rows(0).Item("stainv") <> "I" Then
                            MsgBox("No puede cargar archivos a una sucursal que no se encuentra en Inventario.", MsgBoxStyle.Critical, "Aviso")
                            Txt_Sucursal.Focus()
                            Exit Sub

                        End If
                        NumIfB = objDataSet.Tables(0).Rows(0).Item("numif")
                        Call RellenaGridInvFis()
                    End If


                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using
            If Txt_Sucursal.TextLength > 0 Then Txt_Sucursal.Enabled = False
            Btn_Layout.Enabled = True
            Btn_Abrir.Enabled = True
            Btn_Aceptar.Enabled = True


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub Txt_Sucursal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Sucursal.TextChanged

    End Sub

    Private Sub Pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub


    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        'mreyes 22/Junio/2015   06:53 p.m.
        Try
            Dim ArchivoAnt As String = ""
            Dim Sw_Inv As Boolean = False
            Dim FolioB As String = ""
            Dim MarcaB As String = ""
            Dim EstilonB As String = ""
            Dim CorridaB As String = ""
            Dim MedidaB As String = ""
            Dim SerieB As String = ""
            Dim CtdB As Integer = 0
            Dim CostoB As Decimal = 0
            Dim PrecioB As Decimal = 0
            Dim cont As Integer = 0
            Dim blnActualizo As Boolean = False

            If MsgBox("Esta seguro de querer generar los folios de lectura de Inventario, con los archivos cargados previamente.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub

            P_Bar1.Value = 0
            P_Bar1.Minimum = 0
            P_Bar1.Maximum = DGrid.RowCount
           
            For i As Integer = 0 To DGrid.RowCount - 1
                ' Archivo antes nuevo
                '
                If ArchivoAnt <> DGrid.Rows(i).Cells("archivo").Value Or ArchivoAnt = "" Then
                    ' Genera folio nuevo
                    cont = cont + 1
                    FolioB = fn_TraerFolioOrdeComp(10, Txt_Sucursal.Text, 1)
                    FolioB = pub_RellenarIzquierda(FolioB, 6)
                    If Actualiza_FolioOrdeComp(9, Txt_Sucursal.Text, 1) = False Then
                        MsgBox("Error")
                        Exit Sub
                    End If

                    Using objInv As New BCL.BCLInventarios(GLB_ConStringCipSis)
                        'opcion int, NumIfB int, ArchivoB char(100), SerieB Char(13), IdusuarioB int
                        Sw_Inv = objInv.usp_CapturaInvFis(1, Txt_Sucursal.Text, FolioB, NumIfB, "AP", GLB_FechaHoy.ToString("yyyy-MM-dd"), Now.TimeOfDay.ToString, DGrid.Rows(i).Cells("archivo").Value, GLB_Usuario, GLB_Idempleado)
                    End Using

                    

                End If
                ' INSERTA DETALLADO
                '
                MarcaB = DGrid.Rows(i).Cells("marca").Value
                EstilonB = DGrid.Rows(i).Cells("estilon").Value
                CorridaB = DGrid.Rows(i).Cells("corrida").Value
                MedidaB = DGrid.Rows(i).Cells("medida").Value
                SerieB = DGrid.Rows(i).Cells("serie").Value
                CtdB = 1
                CostoB = DGrid.Rows(i).Cells("costoini").Value
                PrecioB = DGrid.Rows(i).Cells("precioini").Value



                Using objInv As New BCL.BCLInventarios(GLB_ConStringCipSis)

                    Sw_Inv = objInv.usp_CapturaDet_If(1, Txt_Sucursal.Text, FolioB, marcab, estilonb, corridab, medidab, serieb, ctdb, costob, preciob)

                End Using

               
                'update a serie a if 

                'Using objTraspasos As New BCL.BCLTraspasos(GLB_ConStringCipSis)
                '    blnActualizo = objTraspasos.usp_ActualizarSerie(SerieB, Txt_Sucursal.Text, "IF", Txt_Sucursal.Text)
                'End Using



                ArchivoAnt = DGrid.Rows(i).Cells("archivo").Value

                P_Bar1.Value = P_Bar1.Value + 1
                Lbl_Leyenda.Text = ArchivoAnt
                Application.DoEvents()

            Next

            MsgBox("Se han generado " & cont & " de inventario.", MsgBoxStyle.Information, "Aviso")
            'Refrescar nuevas lecturas.


            Call RellenaGridInvFis 


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub InicializaGridInvFis()
        'mreyes 24/Junio/2015   01:04 p.m.
        Try

            'Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
            'Dim row As DataRow = dt.NewRow()
            'row(2) = "Total: "
            'row(4) = pub_SumarColumnaGrid(DGrid, 4, DGrid.RowCount - 1)
            'dt.Rows.Add(row)
            'DGrid.DataSource = dt


            DGrid.RowHeadersVisible = False
            'DGrid.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, 7, FontStyle.Regular)
            'sucursal, folio, numif, status, fecha, hora, observa, usuario , idusuario, fum
            If Opcion = 1 Then
                DGrid.Columns(0).HeaderText = "Det"
                DGrid.Columns(1).HeaderText = "Folio"
                DGrid.Columns(2).HeaderText = "NumIf"
                DGrid.Columns(3).HeaderText = "Estatus"
                DGrid.Columns(4).HeaderText = "Fecha"
                DGrid.Columns(5).HeaderText = "Hora"
                DGrid.Columns(6).HeaderText = "Observaciones"
                DGrid.Columns(7).HeaderText = "Usuario"
                DGrid.Columns(8).HeaderText = "IdUsuario"
                DGrid.Columns(9).HeaderText = "Fum"


                DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Else
                DGrid.Columns(0).HeaderText = "Det"
                DGrid.Columns(1).HeaderText = "Folio"
                DGrid.Columns(2).HeaderText = "Marca"
                DGrid.Columns(3).HeaderText = "Modelo"
                DGrid.Columns(4).HeaderText = "Corrida"
                DGrid.Columns(5).HeaderText = "Medida"
                DGrid.Columns(6).HeaderText = "Serie"
                DGrid.Columns(7).HeaderText = "Ctd"
                DGrid.Columns(8).HeaderText = "Costo"
                DGrid.Columns(9).HeaderText = "Precio"
                DGrid.Columns(10).HeaderText = "Fum"
                ' d.sucursal, d.folio, d.marca, d.estilon, d.corrida, d.medida, d.serie, d.ctd,
                ' d.costo, d.precio, d.fum

                DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            End If


            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells




            'DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.BackColor = Color.PowderBlue
            'DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            'DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Btn_ImprimirRpt_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ImprimirRpt.Click

    End Sub

    Private Sub DGrid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGrid.KeyUp
        Try
            If Opcion = 2 Then
                If IsDBNull(DGrid.Rows(DGrid.CurrentRow.Index).Cells("marca").Value) Then
                    Exit Sub
                End If
                CargarFotoArticulo(DGrid.CurrentRow.Cells("marca").Value, DGrid.CurrentRow.Cells("estilon").Value)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub PBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBox.Click
        
    End Sub

    Private Sub PBox_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PBox.DoubleClick
        'Try
        '    Btn_Foto_Click(sender, e)
        'Catch ExceptionErr As Exception
        '    MessageBox.Show(ExceptionErr.Message.ToString)
        'End Try
    End Sub

    Private Sub DGrid_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DGrid.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With Me.DGrid
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If
    End Sub

    Private Sub PBox_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PBox.MouseDown
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                izquierda = e.X
                alto = e.Y
                PBox.Cursor = Cursors.SizeAll
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub PBox_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PBox.MouseMove
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                PBox.Location = New Point(PBox.Left + e.X - izquierda, PBox.Top + e.Y - alto)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub PBox_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PBox.MouseUp
        Try
            PBox.Cursor = Cursors.Default
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Salir_Click_1(sender As Object, e As EventArgs) Handles Btn_Salir.Click
        Me.Dispose()
        Me.Close()
    End Sub
End Class
