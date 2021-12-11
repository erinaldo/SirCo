Imports System.Text.RegularExpressions

Public Class frmAnalisisPropuestaTraspasos
    'mreyes 18/Julio/2016   11:20 a.m.
    Dim Agrupacionb As Integer = 0
    Dim blnAbortar As Boolean = False

    Dim Sql As String
    Public Accion As Integer  ' 1 = Administración , 2 = Tiendas 
    Public Sw_Registro As Boolean = False
    Private objDataSet As Data.DataSet
    Private objDataSetFiltro As Data.DataSet
    Public objDataSetModelos As Data.DataSet
    Private objDataSetModelos1 As Data.DataSet
    Private objDataSetCorrida As Data.DataSet
    Private objDataSetAuxiliarMod As New Data.DataSet
    Dim objDataSetResmin As New Data.DataSet
    Dim objDataSetVtasCero As DataSet
    Dim objDataSetPruebas As DataSet
    Dim Costo As Decimal = 0
    Public Sw_PedidoNuevo As Boolean = False
    'Dim blnEsPrimero As Boolean = True

    Public FechaInib As String
    Public FechaFinb As String

    Dim PeriodoIni As Date
    Dim PeriodoFin As Date

    Public intPosicion As Integer = 0
    Public intTotalRows As Integer = 0

    Dim DesctoPP As String = ""
    Dim Dscto01 As String = ""
    Dim Dscto02 As String = ""
    Dim Dscto03 As String = ""
    Dim Dscto04 As String = ""
    Dim Dscto05 As String = ""
    Dim Iva As String = ""
    Dim MedMax As String = ""
    Dim MedMin As String = ""

    Public Sucursal As String = ""

    Public Estilon As String = ""
    Public OrdeComp As String = ""
    Public Proveedor As String = ""
    Dim Clasif As String = ""
    Public Fecha As Date = "1900-01-01"
    Dim Sw_Load As Boolean = False
    Public Sw_Menu As Boolean = False

    Public Marca As String = ""

    Public IdDivisiones As Integer
    Public Division As String = ""
    Public IdDepto As Integer
    Public Depto As String = ""
    Public Linea As String = ""
    Public IdFamilia As String = ""
    Public IdLinea As String = ""
    Public IdL1 As String = ""
    Public L1 As String = ""
    Public IdL2 As String = ""
    Public IdL3 As String = ""
    Public IdL4 As String = ""
    Public IdL5 As String = ""
    Public IdL6 As String = ""
    Public IdAgrupacion As Integer

    Dim Sw_Entro As Boolean = False
    Dim Inicio As Integer
    Dim Fin As Integer

    Dim Sw_Limpiar As Boolean = False

    Dim Sw_MalTotal As Boolean = False

    Private Sub frmAnalisisPropuestaTraspasos_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            If Sw_Load = True Then

                ColorearGrid(DGridVentas)
                ColorearGrid(DGridExistencia)
                ColorearGrid(DGridPropuesta)


                For i As Integer = 4 To DGridPropuesta.Rows.Count - 1
                    If DGridPropuesta.Rows(i).Cells(0).Value >= 86 And DGridPropuesta.Rows(i).Cells(0).Value <= 89 Then
                        For j As Integer = 0 To DGridPropuesta.Columns.Count - 1
                            If DGridPropuesta.Columns(j).Visible = True Then
                                If DGridPropuesta.Rows(i).Cells(j).Value = "0" Then
                                    If j <> 3 Then
                                        DGridPropuesta.Rows(i).Cells(j).Style.ForeColor = Color.Beige
                                        DGridPropuesta.Rows(i).Cells(j).Style.BackColor = Color.Beige
                                    Else
                                        DGridPropuesta.Rows(i).Cells(j).Style.BackColor = Color.Beige
                                    End If
                                Else

                                    DGridPropuesta.Rows(i).Cells(j).Style.ForeColor = Color.Black
                                    DGridPropuesta.Rows(i).Cells(j).Style.BackColor = Color.Beige
                                End If
                            End If
                        Next
                    End If
                Next
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub frmCatalogoEstilos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'FechaInib = Format(Now.Add(New TimeSpan(-90, 0, 0, 0)), "yyyyMMdd")
            'FechaFinb = Format(Now.Date, "yyyyMMdd")
            sw_load = True
            If FechaInib Is Nothing Then
                FechaInib = Format(Now.Add(New TimeSpan(-60, 0, 0, 0)), "yyyy-MM-dd")
                FechaFinb = Format(Now.Date, "yyyy-MM-dd")

                PeriodoIni = Format(Now.Add(New TimeSpan(-60, 0, 0, 0)), "yyyy-MM-dd")
                PeriodoFin = Format(Now.Date, "yyyy-MM-dd")
            Else
                PeriodoIni = Format(CDate(FechaInib))
                PeriodoFin = Format(CDate(FechaFinb))
            End If

            DT_FecIni.Value = PeriodoIni
            DT_FecFin.Value = PeriodoFin

            'Traer todos los protrasparticulo

            Lbl_PeriodoVentas.Text = "Periodo de Ventas del " & DT_FecIni.Value & " al " & DT_FecFin.Value
            Me.Text = "Propueta Traspasos Automáticos " & Txt_Marca.Text & " - " & Txt_Modelo.Text
            '''' Using objCatalogoEstilos As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
            '''' objDataSetModelos = objCatalogoEstilos.usp_TraerModelosMarca(0, "")


            Using objCatalogoEst As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
                objDataSetModelos1 = objCatalogoEst.usp_TraerProTraspArticulo(Marca, Estilon, IdDivisiones, IdDepto, IdFamilia, IdLinea, IdL1, IdL2, IdL3, IdL4, IdL5, IdL6, IdAgrupacion, 1)
                If objDataSetModelos1.Tables(0).Rows.Count > 0 Then
                    Txt_IdArticulo.Text = objDataSetModelos1.Tables(0).Rows(0).Item("renglon")
                    intPosicion = objDataSetModelos1.Tables(0).Rows(0).Item("renglon")
                    ''intTotalRows = objDataSetModelos.Tables(0).Rows.Count - 1
                    Txt_Marca.Text = objDataSetModelos1.Tables(0).Rows(0).Item("marca")
                    Txt_Modelo.Text = objDataSetModelos1.Tables(0).Rows(0).Item("estilon")
                    Lbl_Totales.Text = intPosicion & " de " & intTotalRows

                End If
            End Using




            If Txt_Modelo.Text.Length > 0 Then
                Call Txt_Modelo_LostFocus(sender, e)
                Exit Sub
            End If

            Txt_Marca.Select()
            Call GenerarToolTip()
            Call Edicion()

            'blnEsPrimero = False

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub TraerCostoPrecio()
        Try
            'Dim objDataSetAux As DataSet
            'Dim Dsctos As Integer = 0
            'Dim precdesc As String = ""

            'Dim Margen As Decimal
            'Dim PComp As Decimal
            'Dim Precio As Decimal

            ''trae las diferentes corridas del modelo
            'Using objCorrida As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
            '    objDataSetAux = objCorrida.usp_TraerPreciosAnalisisModelo(Txt_Marca.Text, Txt_Modelo.Text)
            'End Using
            'Dim Corridas As String = ""


            ''Puede ver los costos de modelo
            ''If GLB_Sw_Costos = True Then

            'If objDataSetAux.Tables(0).Rows.Count > 0 Then
            '    'Populate the Project Details section 

            '    DGrid2.DataSource = objDataSetAux.Tables(0)
            '    'If Sw_Load = False Then
            '    InicializaGrid2()
            '    'End If
            '    'LimpiarBusqueda()
            '    Me.Cursor = Cursors.Default

            'Else

            '    Me.Cursor = Cursors.Default
            '    MsgBox("No se encontraron registros que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
            '    Btn_Excel.Enabled = False
            'End If
            'Me.Cursor = Cursors.Default



            'For i As Integer = 0 To DGrid2.RowCount - 1
            '    If DGrid2.Rows(i).Cells(0).Value = "TORREÓN" Then
            '        DGrid2.Rows(i).DefaultCellStyle.BackColor = Color.Bisque
            '    Else
            '        DGrid2.Rows(i).DefaultCellStyle.BackColor = Color.Beige
            '    End If

            'Next
            Try
                Dim objDataSetAux As DataSet
                Dim Dsctos As Integer = 0
                Dim precdesc As String = ""



                'trae las diferentes corridas del modelo
                Using objCorrida As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                    objDataSetAux = objCorrida.usp_TraerPrecios(2, IIf(GLB_CveSucursal = "11", "11", "99"), Txt_Marca.Text, Txt_Modelo.Text)
                End Using
                Dim Corridas As String = ""


                'Puede ver los costos de modelo
                'If GLB_Sw_Costos = True Then

                If objDataSetAux.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section 

                    DGrid2.DataSource = objDataSetAux.Tables(0)
                    'If Sw_Load = False Then
                    InicializaGrid2()
                    'End If
                    'LimpiarBusqueda()
                    Me.Cursor = Cursors.Default

                Else

                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron PRECIOS que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    'Btn_Excel.Enabled = False
                End If
                Me.Cursor = Cursors.Default



                For i As Integer = 0 To DGrid2.RowCount - 1
                    If DGrid2.Rows(i).Cells(0).Value = "TORREÓN" Then
                        DGrid2.Rows(i).DefaultCellStyle.BackColor = Color.Bisque
                    Else
                        DGrid2.Rows(i).DefaultCellStyle.BackColor = Color.Beige
                    End If

                Next

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub InicializaGrid2()
        Try



            'DGrid2.RowHeadersVisible = False
            ''DGrid.Columns(0).HeaderText = "Det"
            ''DGrid.Columns(1).HeaderText = "Marca"
            ''DGrid.Columns(2).HeaderText = "Modelo"
            ''DGrid.Columns(3).HeaderText = "Estilo"
            ''DGrid.Columns(4).HeaderText = "Concepto"
            'DGrid2.Columns(0).Frozen = True

            'DGrid2.Columns("Costo").DefaultCellStyle.Format = "c"
            'DGrid2.Columns("venta").DefaultCellStyle.Format = "c"
            'DGrid2.Columns("aparador").DefaultCellStyle.Format = "c"
            'DGrid2.Columns("margen").DefaultCellStyle.Format = "0#.#0"

            'DGrid2.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            'DGrid2.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'DGrid2.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'DGrid2.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'DGrid2.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter



            'DGrid2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            'DGrid2.Columns(1).Visible = False
            'DGrid2.Columns(2).Visible = False
            'DGrid2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            DGrid2.RowHeadersVisible = False
            'DGrid.Columns(0).HeaderText = "Det"
            'DGrid.Columns(1).HeaderText = "Marca"
            'DGrid.Columns(2).HeaderText = "Modelo"
            'DGrid.Columns(3).HeaderText = "Estilo"
            'DGrid.Columns(4).HeaderText = "Concepto"
            DGrid2.Columns(0).Frozen = True

            DGrid2.Columns("Costo").DefaultCellStyle.Format = "c"
            DGrid2.Columns("venta").DefaultCellStyle.Format = "c"
            DGrid2.Columns("perciero").DefaultCellStyle.Format = "c"
            DGrid2.Columns("contado").DefaultCellStyle.Format = "c"
            DGrid2.Columns("credito").DefaultCellStyle.Format = "c"
            DGrid2.Columns("final").DefaultCellStyle.Format = "c"
            DGrid2.Columns("margen1").DefaultCellStyle.Format = "0#.#0"
            DGrid2.Columns("margen2").DefaultCellStyle.Format = "0#.#0"

            'If GLB_CveSucursal = "11" Then
            '    dgrid2.Columns("credito").Visible = False
            'End If

            'dgrid2.Columns("prov").Visible = False
            'dgrid2.Columns("costo").Visible = False
            'dgrid2.Columns("margen").Visible = False


            DGrid2.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid2.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid2.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid2.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid2.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid2.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid2.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid2.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid2.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter



            DGrid2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid2.Columns(1).Visible = False
            DGrid2.Columns(2).Visible = False
            DGrid2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub




    Private Sub usp_TraerEstructura()
        Using objCatalogoEstilos As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
            Try
                objDataSet = objCatalogoEstilos.usp_TraerEstructura(Val(Txt_IdArticulo.Text), Txt_Marca.Text, Txt_Modelo.Text)

                If objDataSet.Tables(0).Rows.Count > 0 Then


                    Lbl_Estructura.Text = objDataSet.Tables(0).Rows(0).Item("descripdivision").ToString & " \ " & _
                    objDataSet.Tables(0).Rows(0).Item("descripdepto").ToString & " \ " & _
                    objDataSet.Tables(0).Rows(0).Item("descripfamilia").ToString & " \ " & _
                    objDataSet.Tables(0).Rows(0).Item("descriplinea").ToString '& " \ " & _


                    If Not IsDBNull(objDataSet.Tables(0).Rows(0).Item("descripl1")) Then
                        Lbl_Estructura.Text = Lbl_Estructura.Text & " \ " & objDataSet.Tables(0).Rows(0).Item("descripl1").ToString
                    End If

                    If Not IsDBNull(objDataSet.Tables(0).Rows(0).Item("descripl2")) Then
                        Lbl_Estructura.Text = Lbl_Estructura.Text & " \ " & objDataSet.Tables(0).Rows(0).Item("descripl2").ToString
                    End If

                    If Not IsDBNull(objDataSet.Tables(0).Rows(0).Item("descripl3")) Then
                        Lbl_Estructura.Text = Lbl_Estructura.Text & " \ " & objDataSet.Tables(0).Rows(0).Item("descripl3").ToString
                    End If

                    If Not IsDBNull(objDataSet.Tables(0).Rows(0).Item("descripl4")) Then
                        Lbl_Estructura.Text = Lbl_Estructura.Text & " \ " & objDataSet.Tables(0).Rows(0).Item("descripl4").ToString
                    End If

                    If Not IsDBNull(objDataSet.Tables(0).Rows(0).Item("descripl5")) Then
                        Lbl_Estructura.Text = Lbl_Estructura.Text & " \ " & objDataSet.Tables(0).Rows(0).Item("descripl5").ToString
                    End If

                    If Not IsDBNull(objDataSet.Tables(0).Rows(0).Item("descripl6")) Then
                        Lbl_Estructura.Text = Lbl_Estructura.Text & " \ " & objDataSet.Tables(0).Rows(0).Item("descripl6").ToString
                    End If


                Else

                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(DGridVentas, "Detallado de existencias del Artículo")
            ToolTip.SetToolTip(Btn_ModAnterior, "Consultar Modelo Anterior")
            ToolTip.SetToolTip(Btn_ModSiguiente, "Consultar Modelo Siguiente")
            ToolTip.SetToolTip(Btn_Aceptar, "Consultar el rango de fechas seleccionadas")
            ToolTip.SetToolTip(Btn_Salir, "Salir")

            ToolTip.SetToolTip(Btn_Limpiar, "Limpiar Datos")
            ' ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Edicion()
        Try
            Select Case Accion
                Case 1

                    'Pnl_Edicion.Enabled = False

                    Txt_Marca.BackColor = TextboxBackColor
                    Txt_Modelo.BackColor = TextboxBackColor
                    Txt_Estilof.BackColor = TextboxBackColor
                    Txt_Descripc.BackColor = TextboxBackColor
                    Txt_DescripMarca.BackColor = TextboxBackColor
                    'Txt_Division.BackColor = TextboxBackColor
                    'Txt_Depto.BackColor = TextboxBackColor
                    'Txt_Familia.BackColor = TextboxBackColor
                    'Txt_Linea.BackColor = TextboxBackColor
                    'Txt_L1.BackColor = TextboxBackColor
                    'Txt_L2.BackColor = TextboxBackColor
                    'Txt_L3.BackColor = TextboxBackColor
                    'Txt_L4.BackColor = TextboxBackColor
                    'Txt_L5.BackColor = TextboxBackColor
                    'Txt_L6.BackColor = TextboxBackColor
                    Txt_Proveedor.BackColor = TextboxBackColor

                    'Lbl_FechaUltVta.Text = ""
                    'Lbl_UltEntrada.Text = ""
                    'Lbl_Costo.Text = ""
                    'Lbl_Precio.Text = ""

                    'Lbl_PD.Visible = False
                    'Lbl_Descto.Visible = False

                    'If GLB_Sw_Costos = False Then
                    '    Lbl_C.Visible = False
                    '    Lbl_Costo.Visible = False
                    'End If

                    'Btn_ModAnterior.Visible = False
                    'Btn_ModSiguiente.Visible = False
                    Btn_Limpiar.Visible = False


                Case 2
                    Txt_Marca.Enabled = True
                    Txt_Modelo.Enabled = True
                    Txt_Marca.ReadOnly = False
                    Txt_Modelo.ReadOnly = False

                    ''''Lbl_FechaUltVta.Text = ""

                    Btn_Limpiar.Visible = True
                    'Lbl_Costo.Text = ""
                    'Lbl_Precio.Text = ""

                    'Lbl_PD.Visible = False
                    'Lbl_Descto.Visible = False

                    Btn_ModAnterior.Visible = True
                    Btn_ModSiguiente.Visible = True

                    'If GLB_Sw_Costos = False Then
                    '    Lbl_C.Visible = False
                    '    Lbl_Costo.Visible = False
                    'End If

            End Select
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmCatalogoExistenciaEstilos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then
                Me.Dispose()
                Me.Close()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        Try

            DGridVentas.DataSource = Nothing
            DGridVentas.Refresh()
            DGridVentas.Rows.Clear()

            DGrid2.DataSource = Nothing
            DGrid2.Refresh()
            DGrid2.Rows.Clear()

            FechaInib = DT_FecIni.Value.ToString("yyyy-MM-dd")
            FechaFinb = DT_FecFin.Value.ToString("yyyy-MM-dd")
            PeriodoIni = DT_FecIni.Value
            PeriodoFin = DT_FecFin.Value



            If Txt_Marca.Text.Length = 3 AndAlso Txt_Descripc.Text <> "" Then
                Sucursal = ""
                Txt_Estilof.Text = ""
                Call Txt_Modelo_LostFocus(sender, e)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub CargarFotoArticulo()
        'mreyes 02/Marzo/2012 04:12 p.m.
        'Glb_RutaArchivoFotos
        Try
            Dim Archivo As String = ""
            Dim NoFoto As String = "1"

            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)

                System.GC.Collect()

                Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Modelo.Text, NoFoto)

                If objIO.pub_ExisteArchivo(Archivo) = True Then
                    PBox.Image = New System.Drawing.Bitmap(Archivo)
                    Exit Sub
                End If

                For i As Integer = 0 To 9

                    Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Modelo.Text, i)
                    If objIO.pub_ExisteArchivo(Archivo) = True Then
                        PBox.Image = New System.Drawing.Bitmap(Archivo)
                        Exit Sub
                    Else
                        Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Modelo.Text, i)
                        If objIO.pub_ExisteArchivo(Archivo) = True Then
                            PBox.Image = New System.Drawing.Bitmap(Archivo)
                            Exit Sub
                        End If
                    End If
                Next

                PBox.Image = SIRCO.My.Resources.ZAPATERIA_TORREON
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub PBox_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PBox.DoubleClick
        'mreyes 03/Marzo/2012 10:01 a.m.
        Try
            Dim myForm As New frmConsultaImagen
            myForm.Txt_Estilon.Text = Txt_Modelo.Text
            myForm.Txt_Marca.Text = Txt_Marca.Text
            myForm.ShowDialog()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Marca_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Marca.LostFocus

        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
            If Txt_Marca.Text.Length = 0 Then Exit Sub

            Try
                Call TxtLostfocus(Txt_Marca, Txt_DescripMarca, "M")

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using

    End Sub

    Private Sub TxtLostfocus(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
        Dim myForm As New frmConsulta
        If Txt_Campo.Text.Length = 0 Then Exit Sub
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
            Try

                objDataSet = objMySqlGral.usp_TraerDescripcion(Tipo, Txt_Campo.Text, "")

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

    Private Sub Txt_Modelo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Modelo.LostFocus
        Try
            Dim ObjDataSet1 As Data.DataSet
            If Sw_Load = True Then
                Txt_IdArticulo.Text = ""
            End If





            If Txt_Modelo.Text.Length > 0 Then
                Txt_Modelo.Text = Txt_Modelo.Text.PadLeft(7)
            End If
            If Txt_Modelo.Text.Length = 0 And Txt_Marca.Text.Length = 0 And Txt_Estilof.Text.Length = 0 Then
                MsgBox("Debe especificar un estilo a buscar.", MsgBoxStyle.Critical, "Error")
                Txt_Marca.Focus()
                Exit Sub
            End If
            If Txt_Modelo.Text.Length > 0 And Txt_Marca.Text.Length > 0 And Txt_Estilof.Text.Length > 0 Then

                Exit Sub
            End If

            If Txt_Modelo.Text.Length = 0 And Txt_Estilof.Text.Length = 0 Then

                Txt_Estilof.Focus()
                Exit Sub
            End If

            ''BUSCA SI TIENE VARIOS ESTILOS DE FABRICA
            If Txt_Estilof.Text.Length > 0 Then
                Using ObjCatalogoEstilos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
                    ObjDataSet1 = ObjCatalogoEstilos.usp_TraerEstilo(0, Txt_Marca.Text, "", Txt_Estilof.Text, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "")

                    If ObjDataSet1.Tables(0).Rows.Count > 1 Then
                        '''' LO ENCONTRO VARIAS VECES
                        Dim myForm As New frmConsultaEstilo
                        '' mandar el valor del estilo de fábrica y marca 
                        myForm.Marcab = Txt_Marca.Text
                        myForm.EstiloFb = Txt_Estilof.Text
                        myForm.ShowDialog()
                        ' Regresa el valor del estilo nuestro

                        Txt_Modelo.Text = myForm.Campo


                    End If
                End Using
            End If


            Using objCatalogoEst As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                objDataSet = objCatalogoEst.usp_TraerModelo(Val(Txt_IdArticulo.Text), Txt_Marca.Text, Txt_Modelo.Text, Txt_Estilof.Text, _
                                                               0, 0, 0, 0, 0, "")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_IdArticulo.Text = objDataSet.Tables(0).Rows(0).Item("idarticulo")


                    Txt_Marca.Text = objDataSet.Tables(0).Rows(0).Item("marca").ToString
                    Txt_DescripMarca.Text = objDataSet.Tables(0).Rows(0).Item("descripmarca").ToString
                    Txt_Modelo.Text = objDataSet.Tables(0).Rows(0).Item("modelo").ToString
                    Txt_Estilof.Text = objDataSet.Tables(0).Rows(0).Item("estilof").ToString
                    Txt_Descripc.Text = objDataSet.Tables(0).Rows(0).Item("descripc").ToString
                    Txt_Proveedor.Text = objDataSet.Tables(0).Rows(0).Item("proveedor").ToString
                    Txt_Raz_Soc.Text = objDataSet.Tables(0).Rows(0).Item("raz_soc").ToString
                    Txt_IdArticulo.Text = objDataSet.Tables(0).Rows(0).Item("idarticulo")

                    MedMax = objDataSet.Tables(0).Rows(0).Item("medmax")
                    MedMin = objDataSet.Tables(0).Rows(0).Item("medmin")

                    DesctoPP = objDataSet.Tables(0).Rows(0).Item("dsctopp").ToString
                    Dscto01 = objDataSet.Tables(0).Rows(0).Item("dscto01").ToString
                    Dscto02 = objDataSet.Tables(0).Rows(0).Item("dscto02").ToString
                    Dscto03 = objDataSet.Tables(0).Rows(0).Item("dscto03").ToString
                    Dscto04 = objDataSet.Tables(0).Rows(0).Item("dscto04").ToString
                    Dscto05 = objDataSet.Tables(0).Rows(0).Item("dscto05").ToString
                    If objDataSet.Tables(0).Rows(0).Item("proveedor").ToString <> "191" Then
                        Iva = "16"
                    Else
                        Iva = "0"
                    End If


                    Division = objDataSet.Tables(0).Rows(0).Item("descripdivision").ToString
                    Depto = objDataSet.Tables(0).Rows(0).Item("descripdepto").ToString
                    Linea = objDataSet.Tables(0).Rows(0).Item("descriplinea").ToString
                    L1 = objDataSet.Tables(0).Rows(0).Item("descripl1") & ""


                    Lbl_Estructura.Text = objDataSet.Tables(0).Rows(0).Item("descripdivision").ToString & " \ " & _
                   objDataSet.Tables(0).Rows(0).Item("descripdepto").ToString & " \ " & _
                   objDataSet.Tables(0).Rows(0).Item("descripfamilia").ToString & " \ " & _
                   objDataSet.Tables(0).Rows(0).Item("descriplinea").ToString '& " \ " & _


                    If Not IsDBNull(objDataSet.Tables(0).Rows(0).Item("descripl1")) Then
                        Lbl_Estructura.Text = Lbl_Estructura.Text & " \ " & objDataSet.Tables(0).Rows(0).Item("descripl1").ToString
                    End If

                    If Not IsDBNull(objDataSet.Tables(0).Rows(0).Item("descripl2")) Then
                        Lbl_Estructura.Text = Lbl_Estructura.Text & " \ " & objDataSet.Tables(0).Rows(0).Item("descripl2").ToString
                    End If

                    If Not IsDBNull(objDataSet.Tables(0).Rows(0).Item("descripl3")) Then
                        Lbl_Estructura.Text = Lbl_Estructura.Text & " \ " & objDataSet.Tables(0).Rows(0).Item("descripl3").ToString
                    End If

                    If Not IsDBNull(objDataSet.Tables(0).Rows(0).Item("descripl4")) Then
                        Lbl_Estructura.Text = Lbl_Estructura.Text & " \ " & objDataSet.Tables(0).Rows(0).Item("descripl4").ToString
                    End If

                    If Not IsDBNull(objDataSet.Tables(0).Rows(0).Item("descripl5")) Then
                        Lbl_Estructura.Text = Lbl_Estructura.Text & " \ " & objDataSet.Tables(0).Rows(0).Item("descripl5").ToString
                    End If

                    If Not IsDBNull(objDataSet.Tables(0).Rows(0).Item("descripl6")) Then
                        Lbl_Estructura.Text = Lbl_Estructura.Text & " \ " & objDataSet.Tables(0).Rows(0).Item("descripl6").ToString
                    End If



                    Agrupacionb = objDataSet.Tables(0).Rows(0).Item("idagrupacion").ToString
                    Lbl_Agrupacion.Text = "Agrupación : " & objDataSet.Tables(0).Rows(0).Item("idagrupacion").ToString & " - " & objDataSet.Tables(0).Rows(0).Item("agrupacion").ToString

                    If Agrupacionb = 0 Then
                        Lbl_Agrupacion.Visible = False
                    Else
                        Lbl_Agrupacion.Visible = True
                    End If
                    ''''Call usp_TraerFechaUltVenta()

                    ''''Call TraerCostoPrecio()

                    Call CargarFotoArticulo()
                    DGridVentas.Visible = False
                    ''''Call TraerPedido(objDataSet.Tables(0).Rows.Count)

                    Call RellenaGrid(0) '' checar si 
                    Call TraerCostoPrecio()
                    DGridVentas.Visible = True

                    Txt_Marca.Enabled = False
                    Txt_Modelo.Enabled = False
                    Txt_Estilof.Enabled = False


                    'PRUEBA
                    If Sw_Limpiar = True Then
                        Using objCatalogoEst1 As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
                            objDataSetModelos1 = objCatalogoEst1.usp_TraerProTraspArticulo(Txt_Marca.Text, Txt_Modelo.Text, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1)
                            If objDataSetModelos1.Tables(0).Rows.Count > 0 Then
                                Txt_IdArticulo.Text = objDataSetModelos1.Tables(0).Rows(0).Item("renglon")
                                intPosicion = objDataSetModelos1.Tables(0).Rows(0).Item("renglon")
                                ''intTotalRows = objDataSetModelos.Tables(0).Rows.Count - 1
                                Txt_Marca.Text = objDataSetModelos1.Tables(0).Rows(0).Item("marca")
                                Txt_Modelo.Text = objDataSetModelos1.Tables(0).Rows(0).Item("estilon")
                                Lbl_Totales.Text = intPosicion & " de " & intTotalRows
                            Else
                                'MsgBox("Producto no perteneciente a la estructura de traspaso.", MsgBoxStyle.Information, "Aviso")

                            End If
                        End Using
                        Sw_Limpiar = False
                        Call usp_GeneraProTraspArticulo()

                    End If

                    'PRUEBA 



                    objDataSet = objCatalogoEst.usp_TraerIdArticulo(Txt_Marca.Text, Txt_Modelo.Text)
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Txt_IdArticulo.Text = objDataSet.Tables(0).Rows(0).Item("idarticulo")
                    End If

                Else
                    MsgBox("El modelo ingresado no existe.", MsgBoxStyle.Exclamation, "Aviso")
                    Txt_Marca.Text = ""
                    Txt_Modelo.Text = ""
                    Txt_DescripMarca.Text = ""
                    Txt_Marca.Select()
                    Lbl_Estructura.Text = ""
                    'Lbl_Periodo.Text = ""
                End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Function usp_GeneraProTraspArticulo() As Boolean
        'mreyes 23/Febrero/2012 03:47 p.m.

        Using objCalculo As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
            Try
                'Get the specific project selected in the ListView controlsu
                Dim Marca As String = ""
                Application.DoEvents()

       
                Marca = IIf(Txt_Marca.Text = "", "0", Txt_Marca.Text)

                usp_GeneraProTraspArticulo = objCalculo.usp_GeneraProTraspArticulo(Marca, Txt_Modelo.Text, "0", "0", "", "", "", "", "", "", "", "", "0", GLB_Idempleado, 0)

                Application.DoEvents()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Private Sub Txt_Marca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Marca.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub Txt_Estilon_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Modelo.KeyPress
        pub_SoloNumeros(sender, e)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    '' ''Private Sub Btn_Limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Limpiar.Click
    '' ''    Try
    '' ''        If DGridVentas.Rows.Count >= 1 Then
    '' ''            DGridVentas.DataSource = Nothing
    '' ''            DGridVentas.Columns.Clear()
    '' ''            DGridVentas.Rows.Clear()
    '' ''            Sucursal = ""
    '' ''        End If

    '' ''        If DGridExistencia.Rows.Count >= 1 Then
    '' ''            DGridExistencia.DataSource = Nothing
    '' ''            DGridExistencia.Columns.Clear()
    '' ''            DGridExistencia.Rows.Clear()
    '' ''            Sucursal = ""
    '' ''        End If

    '' ''        If DGridPropuesta.Rows.Count >= 1 Then
    '' ''            DGridPropuesta.DataSource = Nothing
    '' ''            DGridPropuesta.Columns.Clear()
    '' ''            DGridPropuesta.Rows.Clear()
    '' ''            Sucursal = ""
    '' ''        End If

    '' ''        If DGrid2.Rows.Count >= 1 Then
    '' ''            DGrid2.DataSource = Nothing
    '' ''            DGrid2.Columns.Clear()
    '' ''            DGrid2.Rows.Clear()
    '' ''            Sucursal = ""
    '' ''        End If

    '' ''        Txt_Marca.Text = ""
    '' ''        Txt_Modelo.Text = ""
    '' ''        Txt_IdArticulo.Text = ""
    '' ''        Txt_Estilof.Text = ""
    '' ''        Txt_Proveedor.Text = ""
    '' ''        Txt_DescripMarca.Text = ""
    '' ''        Txt_Raz_Soc.Text = ""
    '' ''        Txt_Descripc.Text = ""
    '' ''        'Lbl_Periodo.Text = ""
    '' ''        Lbl_Estructura.Text = ""


    '' ''        Txt_Marca.Enabled = True
    '' ''        Txt_Modelo.Enabled = True
    '' ''        Txt_Marca.ReadOnly = False
    '' ''        Txt_Modelo.ReadOnly = False
    '' ''        Txt_Estilof.Enabled = True


    '' ''        PBox.Image = Nothing
    '' ''        Sw_Limpiar = True

    '' ''        Txt_Marca.Select()
    '' ''    Catch ExceptionErr As Exception
    '' ''        MessageBox.Show(ExceptionErr.Message.ToString)
    '' ''    End Try
    '' ''End Sub

    Private Sub Btn_Series_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim myForm As New frmConsultaSeries
            'If Sw_Factura = True Then
            '    myForm.Tipo = "F"
            'Else
            '    myForm.Tipo = "D"
            'End If
            myForm.Tipo = "M"
            myForm.Marca = Txt_Marca.Text
            myForm.Modelo = Txt_Modelo.Text
            If GLB_CveSucursal = "01" Or GLB_CveSucursal = "02" Or GLB_CveSucursal = "06" Or GLB_CveSucursal = "07" Or GLB_CveSucursal = "08" Or GLB_CveSucursal = "11" Then
                myForm.Sucursal = GLB_CveSucursal
            End If

            myForm.ShowDialog()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Try
            Me.Close()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_ModAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ModAnterior.Click
        Try
            If Sw_MalTotal = True Then
                MsgBox("No puede continuar, ya que la existencia no cuadra. Verifique por favor.", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If


            'If Sw_Entro = True Then
            If GuardarPropuesta() Then

                'End If
            End If


            If intPosicion <> 0 Then
                intPosicion -= 1
                If intPosicion = 0 Then
                    intPosicion = objDataSetModelos.Tables(0).Rows.Count - 1
                End If
            ElseIf intPosicion = 0 Then
                intPosicion = objDataSetModelos.Tables(0).Rows.Count - 1
            End If

            Txt_Marca.Text = objDataSetModelos.Tables(0).Rows(intPosicion).Item("marca").ToString
            Txt_Modelo.Text = objDataSetModelos.Tables(0).Rows(intPosicion).Item("ESTILON").ToString
            Txt_Estilof.Text = ""
            Lbl_Totales.Text = intPosicion & " de " & intTotalRows
            Txt_Marca_LostFocus(sender, e)
            Txt_Modelo_LostFocus(sender, e)


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Function GuardarPropuesta() As Boolean
        'mreyes 25/Julio/20106  01:34 p.m.
        Try
            Dim Guardo As Boolean
            Dim Medida As String = ""
            Dim SucurDes As Integer = 0
            Dim CtdPropuesta As Integer = 0
            Dim Ctd1 As Integer = 0
            Dim CtdExi As Integer = 0
            Dim sucurori As Integer = 0
            Dim SucurOriAnt As Integer = 0
            Dim CtdTotal As Integer = 0
            'Borrar propuesta 

            'PRIMERO CHECAR SI LA TIENDA TIENE LA MISMA EXISTENCIA, ENTONCES SE QUEDA .. DONDE MISMO.. 
            blnAbortar = False

            'DGridPropuesta.Visible = False
            'DGridExistencia.Visible = False
            'DGridVentas.Visible = False
            'Application.DoEvents()

            Using objBultos As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
                Guardo = objBultos.usp_Captura_ProtraspPropuesto(2, Txt_Marca.Text, Txt_Modelo.Text, Medida, sucurori, SucurDes, CtdPropuesta, GLB_Idempleado)
            End Using

            '' PRIMERO IR A BUSCAR SI ES LA MISMA SUCURSAL... 

            ' POR CADA COLUMNA

            PBar_1.Maximum = Fin + 1
            PBar_1.Minimum = Inicio
            PBar_1.Value = Inicio

            For j As Integer = Inicio To Fin
                Application.DoEvents()
                PBar_1.Value = PBar_1.Value + 1
                ' POR CADA RENGLON. 
                If blnAbortar = True Then Exit Function
                For I As Integer = 1 To DGridPropuesta.Rows.Count - 1
                    'SucurDes = DGridPropuesta.Columns(I).HeaderText
                    If blnAbortar = True Then Exit Function
                    '' IF PARA VER SI TIENE PROPUESTA... 
                    If DGridPropuesta.Rows(I).Cells(j).Value > 0 Then

                        If blnAbortar = True Then Exit Function
                        SucurDes = DGridPropuesta.Rows(I).Cells(0).Value
                        Medida = DGridPropuesta.Columns(j).HeaderText
                        CtdPropuesta = DGridPropuesta.Rows(I).Cells(j).Value
                        'CtdExi = DGridExistencia.Rows(0).Cells(j).Value
                        CtdTotal = 0
                        'While CtdTotal < CtdPropuesta

                        For x As Integer = 1 To DGridExistencia.Rows.Count - 1
                            If blnAbortar = True Then Exit Function
                            sucurori = DGridExistencia.Rows(x).Cells(0).Value
                            If SucurDes = sucurori Then
                                If blnAbortar = True Then Exit Function

                                CtdExi = DGridExistencia.Rows(x).Cells(j).Value


                                If CtdExi > 0 Then
                                    If blnAbortar = True Then Exit Function
                                    If CtdPropuesta <= CtdExi Then

                                        Ctd1 = CtdPropuesta
                                        CtdExi = CtdExi - Ctd1
                                        DGridExistencia.Rows(x).Cells(j).Value = Val(DGridExistencia.Rows(x).Cells(j).Value) - Ctd1
                                        DGridPropuesta.Rows(I).Cells(j).Value = DGridPropuesta.Rows(I).Cells(j).Value - Ctd1
                                        Using objBultos As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
                                            Guardo = objBultos.usp_Captura_ProtraspPropuesto(1, Txt_Marca.Text, Txt_Modelo.Text, Medida, sucurori, SucurDes, Ctd1, GLB_Idempleado)
                                            SucurOriAnt = sucurori
                                        End Using
                                    Else
                                        Ctd1 = CtdExi
                                        CtdExi = CtdExi - Ctd1
                                        DGridExistencia.Rows(x).Cells(j).Value = Val(DGridExistencia.Rows(x).Cells(j).Value) - Ctd1
                                        DGridPropuesta.Rows(I).Cells(j).Value = DGridPropuesta.Rows(I).Cells(j).Value - Ctd1
                                        Using objBultos As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
                                            Guardo = objBultos.usp_Captura_ProtraspPropuesto(1, Txt_Marca.Text, Txt_Modelo.Text, Medida, sucurori, SucurDes, Ctd1, GLB_Idempleado)
                                            SucurOriAnt = sucurori
                                        End Using
                                    End If
                                    CtdTotal = CtdTotal + Ctd1
                                    CtdPropuesta = CtdPropuesta - Ctd1  '''a prueba
                                End If

                                'If CtdTotal = CtdPropuesta Then
                                ''Exit For
                                'End If
                            End If
                        Next
                        ' End While

                    End If
                Next


            Next

            '' POR LAS DEMAS SUCURSALES 
            If blnAbortar = True Then Exit Function
            ''Application.DoEvents()

            PBar_1.Value = Inicio
            PBar_1.Maximum = Fin + 1
            PBar_1.Minimum = Inicio
            For j As Integer = Inicio To Fin
                Application.DoEvents()
                PBar_1.Value = PBar_1.Value + 1
                ' POR CADA RENGLON. 
                If blnAbortar = True Then Exit Function
                For I As Integer = 1 To DGridPropuesta.Rows.Count - 1
                    'SucurDes = DGridPropuesta.Columns(I).HeaderText
                    If blnAbortar = True Then Exit Function
                    '' IF PARA VER SI TIENE PROPUESTA... 
                    If DGridPropuesta.Rows(I).Cells(j).Value > 0 Then

                        If blnAbortar = True Then Exit Function
                        SucurDes = DGridPropuesta.Rows(I).Cells(0).Value
                        Medida = DGridPropuesta.Columns(j).HeaderText
                        CtdPropuesta = DGridPropuesta.Rows(I).Cells(j).Value
                        'CtdExi = DGridExistencia.Rows(0).Cells(j).Value
                        CtdTotal = 0
                        While CtdTotal < CtdPropuesta 'cambio
                            If blnAbortar = True Then Exit Function
                            For x As Integer = 1 To DGridExistencia.Rows.Count - 1
                                If blnAbortar = True Then Exit Function
                                sucurori = DGridExistencia.Rows(x).Cells(0).Value
                                If SucurDes <> sucurori Then
                                    If blnAbortar = True Then Exit Function

                                    CtdExi = DGridExistencia.Rows(x).Cells(j).Value


                                    If CtdExi > 0 Then
                                        If CtdPropuesta <= CtdExi Then   '3 < 2 

                                            Ctd1 = CtdPropuesta
                                            CtdExi = CtdExi - Ctd1
                                            DGridExistencia.Rows(x).Cells(j).Value = Val(DGridExistencia.Rows(x).Cells(j).Value) - Ctd1
                                            DGridPropuesta.Rows(I).Cells(j).Value = DGridPropuesta.Rows(I).Cells(j).Value - Ctd1
                                            Using objBultos As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
                                                Guardo = objBultos.usp_Captura_ProtraspPropuesto(1, Txt_Marca.Text, Txt_Modelo.Text, Medida, sucurori, SucurDes, Ctd1, GLB_Idempleado)
                                                SucurOriAnt = sucurori
                                            End Using
                                        Else
                                            Ctd1 = CtdExi
                                            CtdExi = CtdExi - Ctd1
                                            DGridExistencia.Rows(x).Cells(j).Value = Val(DGridExistencia.Rows(x).Cells(j).Value) - Ctd1
                                            DGridPropuesta.Rows(I).Cells(j).Value = DGridPropuesta.Rows(I).Cells(j).Value - Ctd1
                                            Using objBultos As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
                                                Guardo = objBultos.usp_Captura_ProtraspPropuesto(1, Txt_Marca.Text, Txt_Modelo.Text, Medida, sucurori, SucurDes, Ctd1, GLB_Idempleado)
                                                SucurOriAnt = sucurori
                                            End Using
                                        End If
                                        CtdTotal = CtdTotal + Ctd1
                                        CtdPropuesta = CtdPropuesta - Ctd1
                                    End If

                                    'If CtdTotal = CtdPropuesta Then   'cambio ctdtotal = ctdpropuesta mreyes 30/Mayo/2017
                                    '    Exit For
                                    'End If
                                End If
                            Next
                        End While

                    End If
                Next


            Next

            'DGridPropuesta.Visible = True
            'DGridExistencia.Visible = True
            'DGridVentas.Visible = True
            'Application.DoEvents()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function
    Private Sub Btn_ModSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ModSiguiente.Click
        Try
            Dim Guardo As Boolean = False
            'Guardar propuesta antes de ir al siguiente.. 
            'Using objBultos As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
            '    Guardo = objBultos.usp_Captura_ProtraspPropuesto(2, Txt_Marca.Text, Txt_Modelo.Text, "", 0, 0)
            'End Using
            If Sw_MalTotal = True Then
                MsgBox("No puede continuar, ya que la existencia no cuadra. Verifique por favor.", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If
            ' If Sw_Entro = True Then
            If GuardarPropuesta() Then

            End If
            ' End If

            '' ir al siguiente 
            If intPosicion = intTotalRows Then


                intPosicion = 0
            Else
                intPosicion += 1
            End If



            Txt_Marca.Text = objDataSetModelos.Tables(0).Rows(intPosicion).Item("marca").ToString
            Txt_Modelo.Text = objDataSetModelos.Tables(0).Rows(intPosicion).Item("estilon").ToString
            ' '' ''Txt_Modelo.Text = Val(Txt_Modelo.Text) + 1


            Txt_Estilof.Text = ""
            Lbl_Totales.Text = intPosicion & " de " & intTotalRows
            Txt_Marca_LostFocus(sender, e)
            Txt_Modelo_LostFocus(sender, e)
            Sw_Entro = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub CopiarSeleccionToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CopiarSeleccionToolStripMenuItem.Click
        DGridExistencia.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText

        'Me.DGrid.AllowUserToAddRows = False
        'Me.DGrid.Dock = DockStyle.Fill
        'Me.Controls.Add(Me.DGrid)

        If Me.DGridExistencia.GetCellCount(DataGridViewElementStates.Selected) > 0 Then
            Try
                ' Add the selection to the clipboard.
                Clipboard.SetDataObject( _
                    Me.DGridExistencia.GetClipboardContent())

                ' Replace the text box contents with the clipboard text.
                ' Me.TextBox1.Text = Clipboard.GetText()

            Catch ex As System.Runtime.InteropServices.ExternalException

            End Try
        End If
    End Sub

    'Private Sub TraerPedido()

    '    Try
    '        Sucursal = ""
    '        Me.Cursor = Cursors.WaitCursor
    '        If DGrid.Rows.Count >= 1 Then

    '            DGrid.DataSource = Nothing

    '            DGrid.Columns.Clear()
    '            DGrid.Rows.Clear()
    '            'DGrid.Columns.Remove("Total")
    '            'DGrid.Rows.Add()

    '            'For i As Integer = 2 To DGrid2.Columns.Count - 1
    '            '    DGrid2.Columns(i).Visible = False
    '            'Next

    '        End If

    '        'If Sucursal <> "" Then

    '        Dim objDataSet1 As New DataSet
    '        objDataSet1.Tables.Add()
    '        'For x As Integer = 1 To 8
    '        'Sucursal = pub_RellenarIzquierda(x.ToString, 2)
    '        Dim objDataSetAuxiliar As New Data.DataSet
    '        Dim objDataSetSucursales As New Data.DataSet

    '        Me.Cursor = Cursors.WaitCursor
    '        'Using objPedidos As New BCL.BCLResurtido(GLB_ConStringCipSis)
    '        '    objDataSetAuxiliarMod = objPedidos.usp_TraerDatosArticulo(Txt_Marca.Text, Txt_Modelo.Text, Proveedor, Clasif)
    '        'End Using
    '        Dim Clasificacion As String = ""
    '        Dim blnClonoDS As Boolean = False
    '        Dim Renglon As Integer = 0
    '        Dim RenglonR As Integer = 0
    '        'Me.Cursor = Cursors.Default
    '        Dim c As Integer = 0
    '        'PB_Analisis.Visible = True
    '        'PB_Analisis.Value = 0
    '        'PB_Analisis.Maximum = 10000
    '        Dim contado As Integer = 0
    '        Dim contAux = 7000 / objDataSetAuxiliarMod.Tables(0).Rows.Count
    '        Dim intConAux As Integer = 0
    '        Dim a As Integer
    '        Dim contador As Integer
    '        Dim MaxMedidas As Integer
    '        Dim Marca2 As String
    '        Dim Estilon2 As String
    '        Dim Medidas As Integer
    '        Dim Col As Integer
    '        Dim Ini As String
    '        Dim Fin As String
    '        Dim Interval As String
    '        Dim Medida As String
    '        Dim MedIni As String
    '        Dim MedFin As String
    '        Dim Intervalo As String
    '        Dim Columna As Integer
    '        Dim TotalArticulos As Integer
    '        Dim TotalTodos As Decimal
    '        Dim contaux2 As Integer
    '        Dim Total As Integer
    '        Dim Ma As String
    '        Dim Es As String
    '        Dim Su As String
    '        Dim TotalImporte As Decimal
    '        Dim Visible As Boolean
    '        'Dim Articulos As Integer
    '        'Dim Prov As String
    '        'Dim Dsctopp As Decimal
    '        'Dim Diaspp As Decimal
    '        'Dim Dscto01 As Decimal
    '        'Dim Dscto02 As Decimal
    '        'Dim Dscto03 As Decimal
    '        'Dim Dscto04 As Decimal
    '        'Dim Dscto05 As Decimal
    '        'Dim corrida As String
    '        'Dim Costo As Decimal
    '        'Dim PComp As Decimal
    '        'Dim Tot1 As Decimal 
    '        For m As Integer = 0 To objDataSetAuxiliarMod.Tables(0).Rows.Count - 1
    '            Using objPedidos As New BCL.BCLResurtido(GLB_ConStringCipSis)
    '                objDataSetSucursales = objPedidos.usp_TraerSucursal("")
    '            End Using
    '            'contado = contado + contAux
    '            intConAux = contAux / objDataSetSucursales.Tables(0).Rows.Count
    '            For h As Integer = 0 To objDataSetSucursales.Tables(0).Rows.Count - 1
    '                contado = contado + intConAux
    '                'For m As Integer = 0 To 200 - 1
    '                Sucursal = objDataSetSucursales.Tables(0).Rows(h).Item("sucursal").ToString
    '                If objDataSetSucursales.Tables(0).Rows(h).Item("visible").ToString = "S" Then
    '                    Visible = True
    '                Else
    '                    Visible = False
    '                End If

    '                If Visible = False Then Continue For
    '                If Sucursal = "07" AndAlso Chk_Lerdo.Checked = False Then Continue For

    '                'If Sucursal = "00" Or Sucursal = "19" Or Sucursal = "20" Or Sucursal = "98" Or Sucursal = "15" Or Sucursal = "34" Or Sucursal = "99" _
    '                'Or Sucursal = "03" Or Sucursal = "04" Or Sucursal = "05" Or Sucursal = "33" Then Continue For
    '                'Clasificacion = objDataSetAuxiliar.Tables(0).Rows(m).Item("artcat")
    '                'If Clasificacion.Trim = "D" Then Continue For
    '                Estilon = objDataSetAuxiliarMod.Tables(0).Rows(m).Item("Modelo")
    '                Dim objDataSetOC As New Data.DataSet
    '                Dim objDataSetR As New Data.DataSet

    '                'Using objPedidos As New BCL.BCLResurtido(GLB_ConStringCipSis)
    '                '    objDataSet = objPedidos.usp_TraerVentasMedida(FechaInib, FechaFinb, Sucursal, Marca, "", Estilon, "", "")
    '                'End Using

    '                Using objCatMod As New BCL.BCLCatalogoModelos(GLB_ConStringDWH)
    '                    objDataSet = objCatMod.usp_TraerVentasModeloAnalisis(Sucursal, Txt_IdArticulo.Text, CDate(FechaInib), CDate(FechaFinb))
    '                End Using

    '                objDataSetOC = objDataSet.Clone
    '                objDataSetR = objDataSet.Clone
    '                Dim dataRowVenta As DataRow = Nothing
    '                If objDataSet.Tables(0).Rows.Count > 0 Then
    '                    dataRowVenta = objDataSet.Tables(0).Rows(0)
    '                End If

    '                Dim objDataSetAux3 As New Data.DataSet
    '                Using objPedidos As New BCL.BCLResurtido(GLB_ConStringCipSis)
    '                    objDataSetAux3 = objPedidos.usp_TraerExistenciaMedida(Sucursal, Txt_Marca.Text, Txt_Modelo.Text, "", "")
    '                End Using
    '                Dim dataRowExistencia As DataRow = Nothing
    '                If objDataSetAux3.Tables(0).Rows.Count > 0 Then
    '                    dataRowExistencia = objDataSetAux3.Tables(0).Rows(0)
    '                End If

    '                'If dataRowVenta Is Nothing And dataRowExistencia Is Nothing Then
    '                '    Continue For
    '                'End If

    '                Dim objDataSetAuxC As New Data.DataSet
    '                Using objPedidos As New BCL.BCLResurtido(GLB_ConStringCipSis)
    '                    objDataSetAuxC = objPedidos.usp_TraerDetFPMedida(Sucursal, Txt_Marca.Text, Txt_Modelo.Text, CDate(FechaInib), CDate(FechaFinb))
    '                End Using
    '                Dim dataRowComp As DataRow = Nothing
    '                If objDataSetAuxC.Tables(0).Rows.Count > 0 Then
    '                    dataRowComp = objDataSetAuxC.Tables(0).Rows(0)
    '                End If


    '                Dim objDataSetAux4 As New Data.DataSet
    '                Using objPedidos As New BCL.BCLResurtido(GLB_ConStringCipSis)
    '                    objDataSetAux4 = objPedidos.usp_TraerDetOCMedida(Sucursal, "", Txt_Marca.Text, Txt_Modelo.Text, "")
    '                End Using
    '                Dim dataRowPP As DataRow = Nothing
    '                If objDataSetAux4.Tables(0).Rows.Count > 0 Then
    '                    dataRowPP = objDataSetAux4.Tables(0).Rows(0)
    '                End If


    '                GenerarSugerido(dataRowVenta, dataRowExistencia, dataRowComp, dataRowPP, objDataSetOC, objDataSetR)


    '                If blnClonoDS = False Then
    '                    objDataSetVtasCero = objDataSetOC.Clone
    '                    objDataSetResmin = objDataSetR.Clone
    '                    blnClonoDS = True
    '                End If
    '                If objDataSetOC.Tables(0).Rows.Count > 0 Then
    '                    For i As Integer = 0 To objDataSetOC.Tables(0).Rows.Count - 1
    '                        objDataSetVtasCero.Tables(0).ImportRow(objDataSetOC.Tables(0).Rows(i))
    '                        Renglon += 1
    '                    Next
    '                    objDataSetVtasCero.Tables(0).Rows.Add()
    '                End If
    '                If objDataSetR.Tables(0).Rows.Count > 0 Then
    '                    For i As Integer = 0 To objDataSetR.Tables(0).Rows.Count - 1
    '                        objDataSetResmin.Tables(0).ImportRow(objDataSetR.Tables(0).Rows(i))
    '                        RenglonR += 1
    '                    Next
    '                    objDataSetResmin.Tables(0).Rows.Add()
    '                End If
    '                Dim nu As Integer = 16
    '                c += 1
    '                System.GC.Collect()
    '                'PB_Analisis.Value = contado
    '            Next

    '        Next
    '        If c = 0 Then
    '            'MessageBox.Show("No hay datos recientes disponibles para este modelo.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            Me.Cursor = Cursors.Default
    '            Exit Sub
    '        End If
    '        Dim objDataSetAux2 As New DataSet
    '        objDataSetVtasCero.Tables(0).Rows.Remove(objDataSetVtasCero.Tables(0).Rows(objDataSetVtasCero.Tables(0).Rows.Count - 1))
    '        objDataSetPruebas = objDataSetVtasCero.Clone
    '        objDataSetAux2.Tables.Clear()
    '        objDataSetAux2.Tables.Add()
    '        objDataSetAux2.Tables(0).Columns.Add("Sucursal")
    '        objDataSetAux2.Tables(0).Columns.Add("Marca")
    '        objDataSetAux2.Tables(0).Columns.Add("Estilon")
    '        objDataSetAux2.Tables(0).Columns.Add("Estilof")
    '        objDataSetAux2.Tables(0).Columns.Add("Tipo")

    '        objDataSet.Tables.Clear()
    '        objDataSet.Tables.Add()
    '        objDataSet.Tables(0).Columns.Add("Marca")
    '        objDataSet.Tables(0).Columns.Add("Estilon")
    '        a = 0
    '        contador = 0
    '        While a <= objDataSetVtasCero.Tables(0).Rows.Count - 1
    '            objDataSet.Tables(0).Rows.Add()
    '            objDataSet.Tables(0).Rows(contador).Item("Marca") = objDataSetVtasCero.Tables(0).Rows(a).Item("Marca")
    '            objDataSet.Tables(0).Rows(contador).Item("Estilon") = objDataSetVtasCero.Tables(0).Rows(a).Item("Estilon")
    '            contador += 1
    '            a += 5
    '        End While
    '        MaxMedidas = 0
    '        For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
    '            Marca2 = ""
    '            Estilon2 = ""
    '            Marca2 = objDataSet.Tables(0).Rows(i).Item("Marca").ToString
    '            Estilon2 = objDataSet.Tables(0).Rows(i).Item("Estilon").ToString
    '            If Marca2 = "CRO" And Estilon2 = "    124" Then
    '                MaxMedidas = 17
    '                Continue For
    '            End If
    '            Using objPedido As New BCL.BCLResurtido(GLB_ConStringCipSis)
    '                Medidas = 0
    '                Medidas = objPedido.usp_TraerMedida2(Marca2, Estilon2, "").Tables(0).Rows.Count
    '                If Medidas > MaxMedidas Then
    '                    MaxMedidas = Medidas
    '                End If
    '            End Using
    '        Next
    '        For i As Integer = 1 To MaxMedidas
    '            objDataSetAux2.Tables(0).Columns.Add(i.ToString)
    '        Next
    '        objDataSetAux2.Tables(0).Rows.Add()
    '        '
    '        'Using objPedido As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
    '        '    objDataSetCorrida = objPedido.usp_TraerCorrida(objDataSetVtasCero.Tables(0).Rows(i + 1).Item("Marca").ToString, objDataSetVtasCero.Tables(0).Rows(i + 1).Item("Estilon").ToString, "", "")
    '        'End Using
    '        Using objPedido As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
    '            objDataSetCorrida = objPedido.usp_TraerCorrida(Txt_Marca.Text, Txt_Modelo.Text, "", "")
    '        End Using

    '        For i As Integer = 0 To objDataSetVtasCero.Tables(0).Rows.Count - 1
    '            objDataSetAux2.Tables(0).Rows.Add()
    '            If i = 0 Then
    '                ''
    '                Col = 5
    '                For k As Integer = 0 To objDataSetCorrida.Tables(0).Rows.Count - 1
    '                    Ini = ""
    '                    Fin = ""
    '                    Interval = ""
    '                    Ini = objDataSetCorrida.Tables(0).Rows(k).Item("medini").ToString
    '                    Fin = objDataSetCorrida.Tables(0).Rows(k).Item("medfin").ToString
    '                    Interval = objDataSetCorrida.Tables(0).Rows(k).Item("intervalo").ToString
    '                    If Ini.Length = 1 Then
    '                        Ini = pub_RellenarIzquierda(Ini, 2)
    '                    End If
    '                    If Fin.Length = 1 Then
    '                        Fin = pub_RellenarIzquierda(Fin, 2)
    '                    End If
    '                    For j As Integer = 5 To objDataSetVtasCero.Tables(0).Columns.Count - 1
    '                        Medida = ""
    '                        Medida = TraerMedida(objDataSetVtasCero.Tables(0).Columns(j).ColumnName)
    '                        If Medida.Length = 3 Then
    '                            If Interval <> "-" And Medida.Substring(2, 1) = "-" Then
    '                                Continue For
    '                            End If
    '                        End If
    '                        If Medida >= Ini And Medida <= Fin Then
    '                            objDataSetAux2.Tables(0).Rows(i).Item(Col) = Medida
    '                            Col += 1
    '                        End If
    '                    Next
    '                Next
    '            End If
    '            If objDataSetVtasCero.Tables(0).Rows(i).Item(0).ToString.Trim = "" Then
    '                'Using objPedido As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
    '                '    objDataSet = objPedido.usp_TraerCorrida(objDataSetVtasCero.Tables(0).Rows(i + 1).Item("Marca").ToString, objDataSetVtasCero.Tables(0).Rows(i + 1).Item("Estilon").ToString, "", "")
    '                'End Using
    '                Col = 5
    '                For k As Integer = 0 To objDataSetCorrida.Tables(0).Rows.Count - 1
    '                    Ini = ""
    '                    Fin = ""
    '                    Interval = ""
    '                    Ini = objDataSetCorrida.Tables(0).Rows(k).Item("medini").ToString
    '                    Fin = objDataSetCorrida.Tables(0).Rows(k).Item("medfin").ToString
    '                    Interval = objDataSetCorrida.Tables(0).Rows(k).Item("intervalo").ToString
    '                    If Ini.Length = 1 Then
    '                        Ini = pub_RellenarIzquierda(Ini, 2)
    '                    End If
    '                    If Fin.Length = 1 Then
    '                        Fin = pub_RellenarIzquierda(Fin, 2)
    '                    End If
    '                    For j As Integer = 5 To objDataSetVtasCero.Tables(0).Columns.Count - 1
    '                        Medida = ""
    '                        Medida = TraerMedida(objDataSetVtasCero.Tables(0).Columns(j).ColumnName)
    '                        If Medida.Length = 3 Then
    '                            If Interval <> "-" And Medida.Substring(2, 1) = "-" Then
    '                                Continue For
    '                            End If
    '                        End If
    '                        If Medida >= Ini And Medida <= Fin Then
    '                            objDataSetAux2.Tables(0).Rows(i + 1).Item(Col) = Medida
    '                            Col += 1
    '                        End If
    '                    Next

    '                Next
    '                Continue For
    '            End If
    '            objDataSetAux2.Tables(0).Rows(i + 1).Item("Sucursal") = objDataSetVtasCero.Tables(0).Rows(i).Item("Sucursal").ToString
    '            objDataSetAux2.Tables(0).Rows(i + 1).Item("Marca") = objDataSetVtasCero.Tables(0).Rows(i).Item("Marca").ToString
    '            objDataSetAux2.Tables(0).Rows(i + 1).Item("Estilon") = objDataSetVtasCero.Tables(0).Rows(i).Item("Estilon").ToString
    '            objDataSetAux2.Tables(0).Rows(i + 1).Item("Estilof") = objDataSetVtasCero.Tables(0).Rows(i).Item("Estilof").ToString
    '            objDataSetAux2.Tables(0).Rows(i + 1).Item("Tipo") = objDataSetVtasCero.Tables(0).Rows(i).Item("Tipo").ToString
    '            'Using objPedido As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
    '            '    objDataSet = objPedido.usp_TraerCorrida(objDataSetVtasCero.Tables(0).Rows(i).Item("Marca").ToString, objDataSetVtasCero.Tables(0).Rows(i).Item("Estilon").ToString, "", "")
    '            'End Using 
    '            Columna = 5
    '            For k As Integer = 0 To objDataSetCorrida.Tables(0).Rows.Count - 1
    '                MedIni = ""
    '                MedFin = ""
    '                Intervalo = ""
    '                MedIni = objDataSetCorrida.Tables(0).Rows(k).Item("medini").ToString
    '                MedFin = objDataSetCorrida.Tables(0).Rows(k).Item("medfin").ToString
    '                Intervalo = objDataSetCorrida.Tables(0).Rows(k).Item("intervalo").ToString
    '                If MedIni.Length = 1 Then
    '                    MedIni = pub_RellenarIzquierda(MedIni, 2)
    '                End If
    '                If MedFin.Length = 1 Then
    '                    MedFin = pub_RellenarIzquierda(MedFin, 2)
    '                End If
    '                For j As Integer = 5 To objDataSetVtasCero.Tables(0).Columns.Count - 1
    '                    Medida = ""
    '                    Medida = TraerMedida(objDataSetVtasCero.Tables(0).Columns(j).ColumnName)
    '                    If Medida.Length = 3 Then
    '                        If Intervalo <> "-" And Medida.Substring(2, 1) = "-" Then
    '                            Continue For
    '                        End If
    '                    End If
    '                    If Medida >= MedIni And Medida <= MedFin Then
    '                        objDataSetAux2.Tables(0).Rows(i + 1).Item(Columna) = objDataSetVtasCero.Tables(0).Rows(i).Item(j).ToString
    '                        Columna += 1
    '                    End If
    '                Next
    '            Next
    '        Next

    '        Dim mi As Integer = 16
    '        objDataSetAux2.Tables(0).Columns.Add("total")
    '        objDataSetAux2.Tables(0).Columns.Add("ultimo")
    '        objDataSetAux2.Tables(0).Columns.Add("importe")
    '        objDataSetAux2.Tables(0).Columns.Add("proveedor")
    '        TotalArticulos = 0
    '        TotalTodos = 0
    '        contaux2 = 0
    '        contaux2 = contado / objDataSetAux2.Tables(0).Rows.Count
    '        For i As Integer = 0 To objDataSetAux2.Tables(0).Rows.Count - 1
    '            Total = 0
    '            If IsDBNull(objDataSetAux2.Tables(0).Rows(i).Item(0)) Then
    '                Continue For
    '            End If
    '            Ma = ""
    '            Es = ""
    '            Su = ""
    '            Ma = objDataSetAux2.Tables(0).Rows(i).Item("Marca").ToString
    '            Es = objDataSetAux2.Tables(0).Rows(i).Item("Estilon").ToString
    '            Su = objDataSetAux2.Tables(0).Rows(i).Item("Sucursal").ToString
    '            Clasif = ""
    '            'Using objPedidoNuevo As New BCL.BCLResurtido(GLB_ConStringCipSis)
    '            '    objDataSet = objPedidoNuevo.usp_TraerDatosArticulo(Ma, Es, "", Clasif)
    '            'End Using
    '            If objDataSetAuxiliarMod.Tables(0).Rows.Count > 0 Then
    '                objDataSetAux2.Tables(0).Rows(i).Item("Proveedor") = objDataSetAuxiliarMod.Tables(0).Rows(0).Item("proveedor").ToString
    '            End If

    '            For j As Integer = 5 To objDataSetAux2.Tables(0).Columns.Count - 4
    '                If IsDBNull(objDataSetAux2.Tables(0).Rows(i).Item(j)) Then
    '                    Continue For
    '                End If
    '                Total += CInt(objDataSetAux2.Tables(0).Rows(i).Item(j).ToString)
    '            Next
    '            objDataSetAux2.Tables(0).Rows(i).Item("Total") = Total

    '            If objDataSetAux2.Tables(0).Rows(i).Item("Tipo").ToString.Trim = "VENTA" Then
    '                Using objPedidoNuevo As New BCL.BCLResurtido(GLB_ConStringCipSis)
    '                    objDataSet = objPedidoNuevo.usp_TraerFecUltVenta(Ma, Es, Su, "", "")
    '                End Using
    '                If objDataSet.Tables(0).Rows.Count > 0 Then
    '                    Dim Fecha As Date
    '                    Fecha = objDataSet.Tables(0).Rows(0).Item("fecha").ToString
    '                    objDataSetAux2.Tables(0).Rows(i).Item("Ultimo") = Fecha.ToString("dd/MMM/yyyy").ToUpper
    '                End If
    '            End If
    '            If objDataSetAux2.Tables(0).Rows(i).Item("Tipo").ToString.Trim = "PEDIDO PENDIENTE" Then
    '                Using objPedidoNuevo As New BCL.BCLResurtido(GLB_ConStringCipSis)
    '                    objDataSet = objPedidoNuevo.usp_TraerFecUltPedido(Ma, Es, "")
    '                End Using
    '                If objDataSet.Tables(0).Rows.Count > 1 Then
    '                    Dim Fecha As Date
    '                    Fecha = objDataSet.Tables(0).Rows(1).Item("fecha").ToString
    '                    objDataSetAux2.Tables(0).Rows(i).Item("Ultimo") = Fecha.ToString("dd/MMM/yyyy").ToUpper
    '                End If
    '            End If

    '            If objDataSetAux2.Tables(0).Rows(i).Item("Tipo").ToString.Trim = "COMPRAS" Then
    '                'Using objPedidoNuevo As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
    '                '    objDataSet = objPedidoNuevo.usp_TraerFechaUltReciboEstilo(Txt_Marca.Text, Txt_Modelo.Text)
    '                'End Using
    '                If objDataSetAuxiliarMod.Tables(0).Rows.Count > 0 Then
    '                    Dim Fecha As Date
    '                    If objDataSetAuxiliarMod.Tables(0).Rows(0).Item("fecreci") <> "1900-01-01" Then
    '                        Fecha = objDataSetAuxiliarMod.Tables(0).Rows(0).Item("fecreci").ToString
    '                        objDataSetAux2.Tables(0).Rows(i).Item("Ultimo") = Fecha.ToString("dd/MMM/yyyy").ToUpper
    '                    End If
    '                End If
    '                TotalImporte = 0

    '                TotalTodos += TotalImporte
    '                objDataSetAux2.Tables(0).Rows(i).Item("Importe") = TotalImporte
    '                TotalArticulos += objDataSetAux2.Tables(0).Rows(i).Item("Total").ToString

    '            End If
    '            contado = contado + contaux2
    '            If contado <= 9500 Then
    '                'PB_Analisis.Value = contado
    '            End If


    '        Next
    '        'Txt_Importe.Text = "$" + Format(TotalTodos, "###,##0.00")
    '        'Txt_Pares.Text = TotalArticulos

    '        'objDataSet1 = objDataSetAux2.Clone

    '        For k As Integer = 0 To objDataSetAux2.Tables(0).Rows.Count - 1
    '            objDataSet1.Tables(0).ImportRow(objDataSetAux2.Tables(0).Rows(k))
    '        Next

    '        ' Next
    '        DGrid.DataSource = Nothing
    '        For i As Integer = 0 To DGrid.Columns.Count - 1
    '            DGrid.Columns.Remove(DGrid.Columns(0))
    '        Next
    '        DGrid.DataSource = objDataSetAux2.Tables(0)
    '        objDataSetVtasCero = objDataSetAux2.Clone
    '        InicializaGridDetAna()
    '        'PB_Analisis.Value = 9999
    '        'Me.Cursor = Cursors.Default
    '        DGrid.Rows(0).Selected = True
    '        'PB_Analisis.Visible = False


    '        ' check lote min
    '        For i As Integer = 0 To DGrid.Rows.Count - 1
    '            DGrid.Rows(i).Visible = True
    '        Next

    '        Me.Cursor = Cursors.Default
    '    Catch ExceptionErr As Exception
    '        MessageBox.Show(ExceptionErr.Message.ToString)
    '    End Try 
    'End Sub


    Public Function TraerMedida(ByVal NombreColumna As String) As String
        If NombreColumna.ToUpper = "M1" Then
            Return "01"
        ElseIf NombreColumna.ToUpper = "M1_" Then
            Return "01-"
        ElseIf NombreColumna.ToUpper = "M2" Then
            Return "02"
        ElseIf NombreColumna.ToUpper = "M2_" Then
            Return "02-"
        ElseIf NombreColumna.ToUpper = "M3" Then
            Return "03"
        ElseIf NombreColumna.ToUpper = "M3_" Then
            Return "03-"
        ElseIf NombreColumna.ToUpper = "M4" Then
            Return "04"
        ElseIf NombreColumna.ToUpper = "M4_" Then
            Return "04-"
        ElseIf NombreColumna.ToUpper = "M5" Then
            Return "05"
        ElseIf NombreColumna.ToUpper = "M5_" Then
            Return "05-"
        ElseIf NombreColumna.ToUpper = "M6" Then
            Return "06"
        ElseIf NombreColumna.ToUpper = "M6_" Then
            Return "06-"
        ElseIf NombreColumna.ToUpper = "M7" Then
            Return "07"
        ElseIf NombreColumna.ToUpper = "M7_" Then
            Return "07-"
        ElseIf NombreColumna.ToUpper = "M8" Then
            Return "08"
        ElseIf NombreColumna.ToUpper = "M8_" Then
            Return "08-"
        ElseIf NombreColumna.ToUpper = "M9" Then
            Return "09"
        ElseIf NombreColumna.ToUpper = "M9_" Then
            Return "09-"
        ElseIf NombreColumna.ToUpper = "M10" Then
            Return "10"
        ElseIf NombreColumna.ToUpper = "M10_" Then
            Return "10-"
        ElseIf NombreColumna.ToUpper = "M11" Then
            Return "11"
        ElseIf NombreColumna.ToUpper = "M11_" Then
            Return "11-"
        ElseIf NombreColumna.ToUpper = "M12" Then
            Return "12"
        ElseIf NombreColumna.ToUpper = "M12_" Then
            Return "12-"
        ElseIf NombreColumna.ToUpper = "M13" Then
            Return "13"
        ElseIf NombreColumna.ToUpper = "M13_" Then
            Return "13-"
        ElseIf NombreColumna.ToUpper = "M14" Then
            Return "14"
        ElseIf NombreColumna.ToUpper = "M14_" Then
            Return "14-"
        ElseIf NombreColumna.ToUpper = "M15" Then
            Return "15"
        ElseIf NombreColumna.ToUpper = "M15_" Then
            Return "15-"
        ElseIf NombreColumna.ToUpper = "M16" Then
            Return "16"
        ElseIf NombreColumna.ToUpper = "M16_" Then
            Return "16-"
        ElseIf NombreColumna.ToUpper = "M17" Then
            Return "17"
        ElseIf NombreColumna.ToUpper = "M17_" Then
            Return "17-"
        ElseIf NombreColumna.ToUpper = "M18" Then
            Return "18"
        ElseIf NombreColumna.ToUpper = "M18_" Then
            Return "18-"
        ElseIf NombreColumna.ToUpper = "M19" Then
            Return "19"
        ElseIf NombreColumna.ToUpper = "M19_" Then
            Return "19-"
        ElseIf NombreColumna.ToUpper = "M20" Then
            Return "20"
        ElseIf NombreColumna.ToUpper = "M20_" Then
            Return "20-"
        ElseIf NombreColumna.ToUpper = "M21" Then
            Return "21"
        ElseIf NombreColumna.ToUpper = "M21_" Then
            Return "21-"
        ElseIf NombreColumna.ToUpper = "M22" Then
            Return "22"
        ElseIf NombreColumna.ToUpper = "M22_" Then
            Return "22-"
        ElseIf NombreColumna.ToUpper = "M23" Then
            Return "23"
        ElseIf NombreColumna.ToUpper = "M23_" Then
            Return "23-"
        ElseIf NombreColumna.ToUpper = "M24" Then
            Return "24"
        ElseIf NombreColumna.ToUpper = "M24_" Then
            Return "24-"
        ElseIf NombreColumna.ToUpper = "M25" Then
            Return "25"
        ElseIf NombreColumna.ToUpper = "M25_" Then
            Return "25-"
        ElseIf NombreColumna.ToUpper = "M26" Then
            Return "26"
        ElseIf NombreColumna.ToUpper = "M26_" Then
            Return "26-"
        ElseIf NombreColumna.ToUpper = "M27" Then
            Return "27"
        ElseIf NombreColumna.ToUpper = "M27_" Then
            Return "27-"
        ElseIf NombreColumna.ToUpper = "M28" Then
            Return "28"
        ElseIf NombreColumna.ToUpper = "M28_" Then
            Return "28-"
        ElseIf NombreColumna.ToUpper = "M29" Then
            Return "29"
        ElseIf NombreColumna.ToUpper = "M29_" Then
            Return "29-"
        ElseIf NombreColumna.ToUpper = "M30" Then
            Return "30"
        ElseIf NombreColumna.ToUpper = "M30_" Then
            Return "30-"
        ElseIf NombreColumna.ToUpper = "M31" Then
            Return "31"
        ElseIf NombreColumna.ToUpper = "M31_" Then
            Return "31-"
        ElseIf NombreColumna.ToUpper = "M32" Then
            Return "32"
        ElseIf NombreColumna.ToUpper = "M32_" Then
            Return "32-"
        ElseIf NombreColumna.ToUpper = "M33" Then
            Return "33"
        ElseIf NombreColumna.ToUpper = "M33_" Then
            Return "33-"
        ElseIf NombreColumna.ToUpper = "M34" Then
            Return "34"
        ElseIf NombreColumna.ToUpper = "M34_" Then
            Return "34-"
        ElseIf NombreColumna.ToUpper = "M35" Then
            Return "35"
        ElseIf NombreColumna.ToUpper = "M35_" Then
            Return "35-"
        ElseIf NombreColumna.ToUpper = "M36" Then
            Return "36"
        ElseIf NombreColumna.ToUpper = "M36_" Then
            Return "36-"
        ElseIf NombreColumna.ToUpper = "M37" Then
            Return "37"
        ElseIf NombreColumna.ToUpper = "M37_" Then
            Return "37-"
        ElseIf NombreColumna.ToUpper = "M38" Then
            Return "38"
        ElseIf NombreColumna.ToUpper = "M38_" Then
            Return "38-"
        ElseIf NombreColumna.ToUpper = "M39" Then
            Return "39"
        ElseIf NombreColumna.ToUpper = "M39_" Then
            Return "39-"
        ElseIf NombreColumna.ToUpper = "M40" Then
            Return "40"
        ElseIf NombreColumna.ToUpper = "M40_" Then
            Return "40-"
        ElseIf NombreColumna.ToUpper = "M41" Then
            Return "41"
        ElseIf NombreColumna.ToUpper = "M41_" Then
            Return "41-"
        ElseIf NombreColumna.ToUpper = "M42" Then
            Return "42"
        ElseIf NombreColumna.ToUpper = "M42_" Then
            Return "42-"
        ElseIf NombreColumna.ToUpper = "M43" Then
            Return "43"
        ElseIf NombreColumna.ToUpper = "M43_" Then
            Return "43-"
        ElseIf NombreColumna.ToUpper = "M44" Then
            Return "44"
        ElseIf NombreColumna.ToUpper = "M44_" Then
            Return "44-"
        ElseIf NombreColumna.ToUpper = "M45" Then
            Return "45"
        ElseIf NombreColumna.ToUpper = "M45_" Then
            Return "45-"
        ElseIf NombreColumna.ToUpper = "M46" Then
            Return "46"
        ElseIf NombreColumna.ToUpper = "M46_" Then
            Return "46-"
        ElseIf NombreColumna.ToUpper = "M47" Then
            Return "47"
        ElseIf NombreColumna.ToUpper = "M47_" Then
            Return "47-"
        ElseIf NombreColumna.ToUpper = "M48" Then
            Return "48"
        ElseIf NombreColumna.ToUpper = "M48_" Then
            Return "48-"
        ElseIf NombreColumna.ToUpper = "M49" Then
            Return "49"
        ElseIf NombreColumna.ToUpper = "M49_" Then
            Return "49-"
        ElseIf NombreColumna.ToUpper = "M50" Then
            Return "50"
        ElseIf NombreColumna.ToUpper = "M50_" Then
            Return "50-"
        Else
            Return ""
        End If
    End Function



    Private Sub RellenaGrid(ByVal Sw_Generar As Integer)
        'mreyes 18/Julio/2016   04:22 p.m.
        Using objRegistro As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                Sw_Entro = False
                DGridVentas.ReadOnly = False
                DGridVentas.DataSource = Nothing

                ''''''''''''''''''
                FechaInib = DT_FecIni.Value.ToString("yyyyMMdd")
                FechaFinb = DT_FecFin.Value.ToString("yyyyMMdd")
                DGridVentas.Visible = False
                DGridPropuesta.Visible = False
                DGridExistencia.Visible = False

                objDataSet = objRegistro.usp_GeneraPropuestaTraspasos(Txt_Marca.Text, Txt_Modelo.Text, FechaInib, FechaFinb, Division, Linea, L1, Agrupacionb, Sw_Generar, GLB_Idempleado)


                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section

                    DGridVentas.DataSource = objDataSet.Tables(0)
                    DGridExistencia.DataSource = objDataSet.Tables(1)
                    DGridPropuesta.DataSource = objDataSet.Tables(2)

                    InicializaGrid(DGridVentas)
                    InicializaGrid(DGridExistencia)
                    InicializaGrid(DGridPropuesta)
                    ColorearGrid(DGridVentas)
                    ColorearGrid(DGridExistencia)
                    ColorearGrid(DGridPropuesta)

                    '' PROPUESTA COLOR 
                    For i As Integer = 4 To DGridPropuesta.Rows.Count - 1
                        If DGridPropuesta.Rows(i).Cells(0).Value >= 86 And DGridPropuesta.Rows(i).Cells(0).Value <= 89 Then
                            For j As Integer = 0 To DGridPropuesta.Columns.Count - 1
                                If DGridPropuesta.Columns(j).Visible = True Then
                                    If DGridPropuesta.Rows(i).Cells(j).Value = "0" Then
                                        If j <> 3 Then
                                            DGridPropuesta.Rows(i).Cells(j).Style.ForeColor = Color.Beige
                                            DGridPropuesta.Rows(i).Cells(j).Style.BackColor = Color.Beige
                                        Else
                                            DGridPropuesta.Rows(i).Cells(j).Style.BackColor = Color.Beige
                                        End If
                                    Else

                                        DGridPropuesta.Rows(i).Cells(j).Style.ForeColor = Color.Black
                                        DGridPropuesta.Rows(i).Cells(j).Style.BackColor = Color.Beige
                                    End If
                                End If
                            Next
                        End If
                    Next

                    'LimpiarBusqueda()
                    Me.Cursor = Cursors.Default
                    'Btn_Excel.Enabled = True

                Else


                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron movimientos.", MsgBoxStyle.Critical, "Aviso")
                    'Btn_Excel.Enabled = False

                End If
                            Me.Cursor = Cursors.Default
                            ' LimpiarBusqueda()
                            'Call ColorearGrid()
                            DGridVentas.Visible = True
                            DGridPropuesta.Visible = True
                            DGridExistencia.Visible = True

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using


    End Sub

    Private Sub InicializaGrid(ByVal DGridFormato As DataGridView)
        'mreyes 18/Julio/2016   04:27 p.m.
        Try


            Dim Sw_EmpiezaMedios As Boolean = False
            Dim Sw_TerminaMedios As Boolean = False
            Dim dt As DataTable = TryCast(DGridFormato.DataSource, DataTable)
            Dim row As DataRow = dt.NewRow()



            row(1) = "TOTAL: "

            DGridFormato.Columns(0).Frozen = True
            DGridFormato.Columns(1).Frozen = True
            DGridFormato.Columns(2).Frozen = True
            DGridFormato.Columns(3).Frozen = True

            DGridFormato.RowHeadersVisible = False
            'DGridFormato.Columns(2).Visible = False
            DGridFormato.Columns(4).HeaderText = "01"
            DGridFormato.Columns(5).HeaderText = "01-"
            DGridFormato.Columns(6).HeaderText = "02"
            DGridFormato.Columns(7).HeaderText = "02-"
            DGridFormato.Columns(8).HeaderText = "03"
            DGridFormato.Columns(9).HeaderText = "03-"
            DGridFormato.Columns(10).HeaderText = "04"
            DGridFormato.Columns(11).HeaderText = "04-"
            DGridFormato.Columns(12).HeaderText = "05"
            DGridFormato.Columns(13).HeaderText = "05-"
            DGridFormato.Columns(14).HeaderText = "06"
            DGridFormato.Columns(15).HeaderText = "06-"
            DGridFormato.Columns(16).HeaderText = "07"
            DGridFormato.Columns(17).HeaderText = "07-"
            DGridFormato.Columns(18).HeaderText = "08"
            DGridFormato.Columns(19).HeaderText = "08-"
            DGridFormato.Columns(20).HeaderText = "09"
            DGridFormato.Columns(21).HeaderText = "09-"
            DGridFormato.Columns(22).HeaderText = "10"
            DGridFormato.Columns(23).HeaderText = "10-"


            DGridFormato.Columns(24).HeaderText = "11"
            DGridFormato.Columns(25).HeaderText = "11-"
            DGridFormato.Columns(26).HeaderText = "12"
            DGridFormato.Columns(27).HeaderText = "12-"
            DGridFormato.Columns(28).HeaderText = "13"
            DGridFormato.Columns(29).HeaderText = "13-"
            DGridFormato.Columns(30).HeaderText = "14"
            DGridFormato.Columns(31).HeaderText = "14-"
            DGridFormato.Columns(32).HeaderText = "15"
            DGridFormato.Columns(33).HeaderText = "15-"
            DGridFormato.Columns(34).HeaderText = "16"
            DGridFormato.Columns(35).HeaderText = "16-"
            DGridFormato.Columns(36).HeaderText = "17"
            DGridFormato.Columns(37).HeaderText = "17-"
            DGridFormato.Columns(38).HeaderText = "18"
            DGridFormato.Columns(39).HeaderText = "18-"
            DGridFormato.Columns(40).HeaderText = "19"
            DGridFormato.Columns(41).HeaderText = "19-"
            DGridFormato.Columns(42).HeaderText = "20"
            DGridFormato.Columns(43).HeaderText = "20-"


            DGridFormato.Columns(44).HeaderText = "21"
            DGridFormato.Columns(45).HeaderText = "21-"
            DGridFormato.Columns(46).HeaderText = "22"
            DGridFormato.Columns(47).HeaderText = "22-"
            DGridFormato.Columns(48).HeaderText = "23"
            DGridFormato.Columns(49).HeaderText = "23-"
            DGridFormato.Columns(50).HeaderText = "24"
            DGridFormato.Columns(51).HeaderText = "24-"
            DGridFormato.Columns(52).HeaderText = "25"
            DGridFormato.Columns(53).HeaderText = "25-"
            DGridFormato.Columns(54).HeaderText = "26"
            DGridFormato.Columns(55).HeaderText = "26-"
            DGridFormato.Columns(56).HeaderText = "27"
            DGridFormato.Columns(57).HeaderText = "27-"
            DGridFormato.Columns(58).HeaderText = "28"
            DGridFormato.Columns(59).HeaderText = "28-"
            DGridFormato.Columns(60).HeaderText = "29"
            DGridFormato.Columns(61).HeaderText = "29-"
            DGridFormato.Columns(62).HeaderText = "30"
            DGridFormato.Columns(63).HeaderText = "30-"
            DGridFormato.Columns(64).HeaderText = "31"
            DGridFormato.Columns(65).HeaderText = "31-"


            Sw_EmpiezaMedios = False

            If InStr(MedMin, "-") > 0 Then
                ' empieza en medios.
                Sw_EmpiezaMedios = True
                Inicio = Mid(MedMin, 1, 2)
            Else
                Inicio = MedMin

            End If

            If InStr(MedMax, "-") > 0 Then
                Sw_TerminaMedios = True
                Fin = Mid(MedMax, 1, 2)
            Else
                Fin = MedMax
            End If


            Inicio = (Inicio + 2) * 2
            If Sw_EmpiezaMedios = True Then
                Inicio = Inicio - 2
            Else
                Inicio = Inicio - 2
            End If

            Fin = (Fin + 2) * 2

            'If Sw_TerminaMedios Then   'nueva programa
            Fin = Fin - 1
            'End If

            For i As Integer = 4 To DGridFormato.ColumnCount - 1 ''  eran primero 3 y luego eran dos
                DGridFormato.Columns(i).Visible = False

            Next
            ' Medida = DGridPropuesta.Columns(j).HeaderText
            '  row(3) = pub_SumarColumnaGrid(DGridFormato, 3, DGridFormato.RowCount - 1)
            DGridFormato.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            For i As Integer = Inicio To Fin
                ' sumar
                row(i) = pub_SumarColumnaGrid(DGridFormato, i, DGridFormato.RowCount - 1)

                DGridFormato.Columns(i).Visible = True
                DGridFormato.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                '' ''If Sw_EmpiezaMedios = False Then
                '' ''    'quitar medios 
                '' ''    If InStr(DGridFormato.Columns(i).HeaderText, "-") > 0 Then
                '' ''        DGridFormato.Columns(i).Visible = False
                '' ''    End If
                '' ''End If
            Next

            row("total") = pub_SumarColumnaGrid(DGridFormato, 3, DGridFormato.RowCount - 1)

            dt.Rows.InsertAt(row, 0)
            DGridFormato.DataSource = dt

            DGridFormato.Columns(DGridFormato.ColumnCount - 1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGridFormato.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells


            DGridFormato.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
            DGridFormato.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGridFormato.Rows(0).DefaultCellStyle.Font = New Font(DGridFormato.DefaultCellStyle.Font.FontFamily, DGridFormato.DefaultCellStyle.Font.Size, FontStyle.Bold)




        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub




    Private Sub AgregarColumna()
        'mreyes 28/Abril/2012 10:40 a.m.

        Dim colImagen As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        colImagen.Name = "Selec"
        colImagen.HeaderText = "Selec"
        colImagen.DisplayIndex = 200
        colImagen.ReadOnly = False
        colImagen.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        colImagen.CellTemplate = New DataGridViewCheckBoxCell()
        ' añadir columna de imagen a la coleccion del grid 
        DGridVentas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        ''DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DGridVentas.Columns.Add(colImagen)
        DGridVentas.Columns("selec").Visible = False


    End Sub

    Public Sub ColorearGrid(ByVal DGridFormato As DataGridView)
        Try
            DGridFormato.Visible = False

            Dim Col1 As Color
            Col1 = Color.LimeGreen
            Dim Col2 As Color
            Col2 = Color.Gold
            Dim Col3 As Color
            Col3 = Color.SkyBlue
            Dim Col4 As Color
            Col4 = Color.Plum
            Dim Col5 As Color
            If DGridFormato.DataSource Is Nothing Then Exit Sub
            For i As Integer = 1 To DGridFormato.Rows.Count - 1
                For j As Integer = 5 To DGridFormato.Columns.Count - 1
                    If DGridFormato.Columns(j).Visible = True Then
                        If DGridFormato.Rows(i).Cells(j).Value = "0" Then

                            If DGridFormato.Rows(i).Cells("Concepto").Value.ToString.Trim = "VENTA" Then

                                Col5 = Col1
                            ElseIf DGridFormato.Rows(i).Cells("Concepto").Value.ToString.Trim = "EXISTENCIA" Then
                                Col5 = Col2
                            ElseIf DGridFormato.Rows(i).Cells("Concepto").Value.ToString.Trim = "PROPUESTA" Then
                                Col5 = Col3
                            ElseIf DGridFormato.Rows(i).Cells("Concepto").Value.ToString.Trim = "PEDIDO PENDIENTE" Then
                                Col5 = Col4
                            ElseIf DGridFormato.Rows(i).Cells("Concepto").Value.ToString.Trim = "NEGRO" Then
                                Col5 = Color.Black
                            Else
                                Col5 = Color.White
                            End If

                            DGridFormato.Rows(i).Cells(j).Style.ForeColor = Col5 ' DGrid.Rows(i).DefaultCellStyle.BackColor
                        End If


                    End If

                Next
                If DGridFormato.Rows(i).Cells("Concepto").Value.ToString.Trim = "VENTA" Then
                    DGridFormato.Rows(i).DefaultCellStyle.BackColor = Col1

                    Continue For
                End If
                If DGridFormato.Rows(i).Cells("Concepto").Value.ToString.Trim = "EXISTENCIA" Then
                    DGridFormato.Rows(i).DefaultCellStyle.BackColor = Col2
                    Continue For
                End If
                If DGridFormato.Rows(i).Cells("Concepto").Value.ToString.Trim = "PROPUESTA" Then
                    DGridFormato.Rows(i).DefaultCellStyle.BackColor = Col3

       
                    Continue For
                End If
                If DGridFormato.Rows(i).Cells("Concepto").Value.ToString.Trim = "PEDIDO PENDIENTE" Then
                    DGridFormato.Rows(i).DefaultCellStyle.BackColor = Col4
                    Continue For
                End If

                If DGridFormato.Rows(i).Cells("Concepto").Value.ToString.Trim = "NEGRO" Then
                    DGridFormato.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                    DGridFormato.Rows(i).DefaultCellStyle.BackColor = Color.Black

                    Continue For
                End If


            Next


            '' CHECAR PROPUESTA PARA COLOR

            DGridFormato.Visible = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ResumenTraspasos.Click
        'mreyes 07/Octubre/2016 11:46 a.m.


        Try
            Dim myForm As New frmPpalResumenTraspasos

            myForm.StartPosition = FormStartPosition.CenterParent
            myForm.ShowDialog()



        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub Txt_Estilof_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Estilof.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub Txt_Estilof_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Estilof.LostFocus
        Call Txt_Modelo_LostFocus(sender, e)
    End Sub




    Private Sub Chk_ConCeros_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Txt_Estilof.Text = ""
        ' Call Txt_Modelo_LostFocus(sender, e)
    End Sub




    Private Sub Chk_Plaza_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Txt_Estilof.Text = ""
        Call Txt_Modelo_LostFocus(sender, e)
    End Sub




    Private Sub DGridPropuesta_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Try
            Dim columna As Integer = DGridPropuesta.CurrentCell.ColumnIndex
            Dim renglon As Integer = DGridPropuesta.CurrentCell.RowIndex


            DGridPropuesta.Rows(0).Cells(columna).Value = pub_SumarColumnaGridSTotal(DGridPropuesta, columna, DGridPropuesta.RowCount - 1)

            Sw_Entro = True

        Catch ExceptionErr As Exception


            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub Btn_GuardarPropuesta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_LiberarBD.Click
        Try
            If Sw_MalTotal = True Then
                MsgBox("No puede continuar, ya que la existencia no cuadra. Verifique por favor.", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If
            ' If Sw_Entro = True Then
            If GuardarPropuesta() Then

            End If
            Call RellenaGrid(0)
        Catch ExceptionErr As Exception


            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub DGridPropuesta_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub Btn_Propuesta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Propuesta.Click
        'mreyes 25/Julio/2016   05:15 p.m.

        If MsgBox("Esta seguro de volver a generar la propuesta para este modelo.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmación") = MsgBoxResult.No Then Exit Sub


        Call RellenaGrid(1)


    End Sub

    Private Sub Txt_Modelo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Modelo.TextChanged

    End Sub

    Private Sub DGrid2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid2.CellContentClick

    End Sub

    Private Sub Pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub

    Private Sub DGridPropuesta_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DGridPropuesta.CellBeginEdit
        Try
            Dim columna As Integer = DGridPropuesta.CurrentCell.ColumnIndex
            Dim renglon As Integer = DGridPropuesta.CurrentCell.RowIndex


            DGridPropuesta.Rows(renglon).Cells(columna).Style.ForeColor = Color.Black



        Catch ExceptionErr As Exception


            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGridPropuesta_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGridPropuesta.CellContentClick

    End Sub

    Private Sub DGridPropuesta_CellEndEdit1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGridPropuesta.CellEndEdit
        Try
            Dim columna As Integer = DGridPropuesta.CurrentCell.ColumnIndex
            Dim renglon As Integer = DGridPropuesta.CurrentCell.RowIndex

            Dim TotalExi As Integer = 0


            Dim TotalTotalExi As Integer = 0


            TotalExi = DGridExistencia.Rows(0).Cells(columna).Value
            TotalTotalExi = DGridExistencia.Rows(0).Cells(3).Value

            Sw_MalTotal = False


            DGridPropuesta.Rows(0).Cells(columna).Value = pub_SumarColumnaGridSTotal(DGridPropuesta, columna, DGridPropuesta.RowCount - 1)

            DGridPropuesta.Rows(renglon).Cells(3).Value = pub_SumarRenglonGridSTotal(DGridPropuesta, renglon, Inicio, Fin)

            DGridPropuesta.Rows(0).Cells(3).Value = pub_SumarColumnaGridSTotal(DGridPropuesta, 3, DGridPropuesta.RowCount - 1)


            DGridPropuesta.Rows(renglon).Cells(columna).Style.ForeColor = Color.Black


            If DGridPropuesta.Rows(0).Cells(3).Value <> TotalTotalExi Then
                Sw_MalTotal = True
                DGridPropuesta.Rows(0).Cells(3).Style.ForeColor = Color.White
                DGridPropuesta.Rows(0).Cells(3).Style.BackColor = Color.Red

            Else
                Sw_MalTotal = False
                DGridPropuesta.Rows(0).Cells(3).Style.ForeColor = Color.Black
                DGridPropuesta.Rows(0).Cells(3).Style.BackColor = Color.PowderBlue

            End If

            If DGridPropuesta.Rows(0).Cells(columna).Value <> TotalExi Then
                Sw_MalTotal = True
                DGridPropuesta.Rows(0).Cells(columna).Style.ForeColor = Color.White
                DGridPropuesta.Rows(0).Cells(columna).Style.BackColor = Color.Red

            Else
                Sw_MalTotal = False
                DGridPropuesta.Rows(0).Cells(columna).Style.ForeColor = Color.Black
                DGridPropuesta.Rows(0).Cells(columna).Style.BackColor = Color.PowderBlue

            End If
            Sw_Entro = True

        Catch ExceptionErr As Exception


            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'mreyes 13/Febrero/2011 11:25 a.m.
        'Función para validar la escritura en cada una de las columnas del detalle de pedido
        Try
            ' obtener indice de la columna  
            Dim columna As Integer = DGridPropuesta.CurrentCell.ColumnIndex
            Dim renglon As Integer = DGridPropuesta.CurrentCell.RowIndex
            Dim caracter As Char = e.KeyChar

            If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
                e.KeyChar = Chr(0)
            End If

            If DGridExistencia.Rows(0).Cells(columna).Value = 0 Then


                e.KeyChar = Chr(0)
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGridPropuesta_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGridPropuesta.EditingControlShowing
        Dim validar As TextBox = CType(e.Control, TextBox)
        Try
            ' agregar el controlador de eventos para el KeyPress   
            AddHandler validar.KeyPress, AddressOf validar_Keypress
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Filtro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        '' ''Dim myForm As New frmAnalisisPropuestaTraspasos
        '' ''myForm.Sw_Menu = True
        '' ''myForm.WindowState = FormWindowState.Maximized
        '' ''myForm.Accion = 2

        '' ''myForm.Show()
        ' ''Me.Close()
        ' ''Me.Dispose()

        ' ''Dim myForm As New frmFiltrosTraspasosAutomaticos

        ' ''myForm.WindowState = FormWindowState.Normal

        ' ''myForm.StartPosition = FormStartPosition.CenterScreen


        ' ''myForm.Show()

        Try
            If DGridVentas.Rows.Count >= 1 Then
                DGridVentas.DataSource = Nothing
                DGridVentas.Columns.Clear()
                DGridVentas.Rows.Clear()
                Sucursal = ""
            End If

            If DGridExistencia.Rows.Count >= 1 Then
                DGridExistencia.DataSource = Nothing
                DGridExistencia.Columns.Clear()
                DGridExistencia.Rows.Clear()
                Sucursal = ""
            End If

            If DGridPropuesta.Rows.Count >= 1 Then
                DGridPropuesta.DataSource = Nothing
                DGridPropuesta.Columns.Clear()
                DGridPropuesta.Rows.Clear()
                Sucursal = ""
            End If

            If DGrid2.Rows.Count >= 1 Then
                DGrid2.DataSource = Nothing
                DGrid2.Columns.Clear()
                DGrid2.Rows.Clear()
                Sucursal = ""
            End If

            Txt_Marca.Text = ""
            Txt_Modelo.Text = ""
            Txt_IdArticulo.Text = ""
            Txt_Estilof.Text = ""
            Txt_Proveedor.Text = ""
            Txt_DescripMarca.Text = ""
            Txt_Raz_Soc.Text = ""
            Txt_Descripc.Text = ""
            'Lbl_Periodo.Text = ""
            Lbl_Estructura.Text = ""


            Txt_Marca.Enabled = True
            Txt_Modelo.Enabled = True
            Txt_Marca.ReadOnly = False
            Txt_Modelo.ReadOnly = False
            Txt_Estilof.Enabled = True


            PBox.Image = Nothing
            Sw_Limpiar = True

            Txt_Marca.Select()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_ConfirmarTraspaso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ConfirmarTraspaso.Click
        'mreyes 29/Julio/2016   11:37 a.m.
        Try
            If MsgBox("Se generará la petición de traspaso, con la información propuesta.", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub

            If usp_GeneraPeticionTraspaso() = False Then

            End If

            Me.Close()
            Me.Dispose()
            Dim myForm As New frmPpaPendientesRealizar

            myForm.MdiParent = BitacoraMain
            myForm.WindowState = FormWindowState.Maximized
            myForm.Opcion = 1
            myForm.OpcionSP = 1
            myForm.Show()
            myForm.Refresh()


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub


    Private Function usp_GeneraPeticionTraspaso() As Boolean
        'mreyes 29/Julio/2016   12:12 p.m.


        Using objCalculo As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
            Try
                'Get the specific project selected in the ListView controlsu

                Application.DoEvents()

                usp_GeneraPeticionTraspaso = objCalculo.usp_GeneraPeticionTraspaso(Marca, IdDivisiones, IdDepto, IdFamilia, IdLinea, IdL1, IdL2, IdL3, IdL4, IdL5, IdL6, IdAgrupacion, GLB_Idempleado)




                Application.DoEvents()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Private Function usp_GeneraPeticionTraspasoTodos() As Boolean
        'mreyes 07/Octubre/2016   05:17 p.m.


        Using objCalculo As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
            Try
                'Get the specific project selected in the ListView controlsu

                Application.DoEvents()

                usp_GeneraPeticionTraspasoTodos = objCalculo.usp_GeneraPeticionTraspaso("", 0, 0, "", "", "", "", "", "", "", "", 0, GLB_Idempleado)




                Application.DoEvents()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Private Sub PegarSelecciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PegarSelecciónToolStripMenuItem.Click
        Dim data As IDataObject = Clipboard.GetDataObject
        Dim i As Integer = 0
        Dim j As Integer = 0

        If Not data.GetDataPresent("CSV", False) Then Return

        Try
            'Obtenemos el texto almacenado en el portapapales 
            Dim s As String = Clipboard.GetText

            'hacemos un split para organizar la informacion por lineas 
            'Dim lines As String() = s.Split(New Char(1) {ControlChars.Cr, _ ControlChars.Lf}, StringSplitOptions.RemoveEmptyEntries) 
            Dim lines As String() = s.Split(New Char(1) {ControlChars.Cr, ControlChars.Lf}, StringSplitOptions.RemoveEmptyEntries)
            Dim TotalExi As Integer = 0

            Clipboard.GetText()
            Dim columna As Integer = DGridPropuesta.CurrentCell.ColumnIndex
            Dim renglon As Integer = DGridPropuesta.CurrentCell.RowIndex
            Dim Renglon1 As Integer = renglon
            Dim Tot As Integer = 0
            'If DGrid.Rows(renglon).Cells(columna).Visible = True And DGrid.Rows(renglon).Cells(columna).Style.BackColor = Color.Yellow Then
            '' DGridPropuesta.Rows(renglon).Cells(columna).Value = Clipboard.GetText()
            For Each line As String In lines
                'Creamos una fila referenciando a la tabla datasource del DataGridView 

                'Obtenemos las celdas que el usuario copia 
                Dim cells As String() = line.Split(ControlChars.Tab)

                j = columna
                'Burbuja para asignar cada uno de los datos de cada columna copia 
                For Each cell As String In cells
                    'If DGrid.Rows(Renglon1).Cells(j).Visible = True And DGrid.Rows(Renglon1).Cells(j).Style.BackColor = Color.Yellow Then
                    If DGridPropuesta.Rows(Renglon1).Cells(j).Visible Then
                        DGridPropuesta.Rows(Renglon1).Cells(j).Value = cell
                        DGridPropuesta.Rows(Renglon1).Cells(j).Style.ForeColor = Color.Black
                        If DGridPropuesta.Rows(Renglon1).Cells(0).Value > 86 And DGridPropuesta.Rows(Renglon1).Cells(0).Value < 89 Then
                            DGridPropuesta.Rows(Renglon1).Cells(j).Style.BackColor = Color.Beige
                        Else
                            DGridPropuesta.Rows(Renglon1).Cells(j).Style.BackColor = Color.SkyBlue
                        End If


                        DGridPropuesta.Rows(0).Cells(j).Value = pub_SumarColumnaGridSTotal(DGridPropuesta, j, DGridPropuesta.RowCount - 1)
                        DGridPropuesta.Rows(renglon).Cells(j).Style.ForeColor = Color.Black

                        DGridPropuesta.Rows(renglon).Cells(3).Value = pub_SumarRenglonGridSTotal(DGridPropuesta, renglon, Inicio, Fin)
                        If DGridPropuesta.Rows(0).Cells(j).Value <> TotalExi Then
                            Sw_MalTotal = True
                            DGridPropuesta.Rows(0).Cells(j).Style.ForeColor = Color.White
                            DGridPropuesta.Rows(0).Cells(j).Style.BackColor = Color.Red

                        Else
                            Sw_MalTotal = False
                            DGridPropuesta.Rows(0).Cells(j).Style.ForeColor = Color.Black
                            DGridPropuesta.Rows(0).Cells(j).Style.BackColor = Color.SkyBlue

                        End If

                        j = j + 1
                        Tot = Tot + 1
                    Else
                        j = j + 1
                        If Tot = 0 Then
                            DGridPropuesta.Rows(renglon).Cells(columna).Value = ""
                            GoTo No
                        End If
                        For X As Integer = Inicio To Fin
                            ' j = j + 1
                            If DGridPropuesta.Rows(Renglon1).Cells(X).Visible = True Then
                                DGridPropuesta.Rows(Renglon1).Cells(X).Value = cell
                                Tot = Tot + 1
                                TotalExi = DGridExistencia.Rows(0).Cells(X).Value

                                DGridPropuesta.Rows(0).Cells(X).Value = pub_SumarColumnaGridSTotal(DGridPropuesta, X, DGridPropuesta.RowCount - 1)
                                DGridPropuesta.Rows(renglon).Cells(X).Style.ForeColor = Color.Black

                                DGridPropuesta.Rows(renglon).Cells(3).Value = pub_SumarRenglonGridSTotal(DGridPropuesta, renglon, Inicio, Fin)

                                If DGridPropuesta.Rows(0).Cells(X).Value <> TotalExi Then
                                    Sw_MalTotal = True
                                    DGridPropuesta.Rows(0).Cells(X).Style.ForeColor = Color.White
                                    DGridPropuesta.Rows(0).Cells(X).Style.BackColor = Color.Red

                                Else
                                    Sw_MalTotal = False
                                    DGridPropuesta.Rows(0).Cells(X).Style.ForeColor = Color.Black
                                    DGridPropuesta.Rows(0).Cells(X).Style.BackColor = Color.PowderBlue

                                End If

                                j = j + 1
                                Exit For
                            End If
                        Next
                    End If
                Next
                i = i + 1
                j = 0
                'Agregamos la fila a la tabla 
                Renglon1 = Renglon1 + 1
            Next
No:






            Sw_Entro = True

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGridExistencia_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGridExistencia.CellContentClick

    End Sub

    Private Sub DGridVentas_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGridVentas.CellContentClick

    End Sub

    Private Sub DGridVentas_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles DGridVentas.Scroll
        DGridPropuesta.HorizontalScrollingOffset = e.NewValue
        DGridExistencia.HorizontalScrollingOffset = e.NewValue
    End Sub

    Private Sub DGridPropuesta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGridPropuesta.KeyDown
        Try
            Dim selectedCellCount As Integer = DGridPropuesta.GetCellCount(DataGridViewElementStates.Selected)
            Dim TotalExi As Integer = 0


            If (e.KeyCode = 46) Then
                Dim renglon As Integer = DGridPropuesta.CurrentCell.RowIndex
                If selectedCellCount > 0 Then



                    For i As Integer = 0 To selectedCellCount - 1

                        DGridPropuesta.SelectedCells(i).Value = "0"



                    Next
                End If

                ''' CHECAR TOTRALES
                ''' 


                For COLUMNA As Integer = Inicio To Fin
                    TotalExi = DGridExistencia.Rows(0).Cells(COLUMNA).Value
                    Sw_MalTotal = False


                    DGridPropuesta.Rows(0).Cells(COLUMNA).Value = pub_SumarColumnaGridSTotal(DGridPropuesta, COLUMNA, DGridPropuesta.RowCount - 1)
                    DGridPropuesta.Rows(renglon).Cells(3).Value = pub_SumarRenglonGridSTotal(DGridPropuesta, renglon, Inicio, Fin)

                    If DGridPropuesta.Rows(0).Cells(COLUMNA).Value <> TotalExi Then
                        Sw_MalTotal = True
                        DGridPropuesta.Rows(0).Cells(COLUMNA).Style.ForeColor = Color.White
                        DGridPropuesta.Rows(0).Cells(COLUMNA).Style.BackColor = Color.Red

                    Else
                        Sw_MalTotal = False
                        DGridPropuesta.Rows(0).Cells(COLUMNA).Style.ForeColor = Color.Black
                        DGridPropuesta.Rows(0).Cells(COLUMNA).Style.BackColor = Color.PowderBlue

                    End If
                    Sw_Entro = True
                Next
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGridPropuesta_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles DGridPropuesta.Scroll
        DGridVentas.HorizontalScrollingOffset = e.NewValue
        DGridExistencia.HorizontalScrollingOffset = e.NewValue
    End Sub

    Private Sub DGridExistencia_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles DGridExistencia.Scroll
        DGridVentas.HorizontalScrollingOffset = e.NewValue
        DGridPropuesta.HorizontalScrollingOffset = e.NewValue
    End Sub

    Private Sub Btn_NoPropuesta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_NoPropuesta.Click
        'mreyes 09/Agosto/2016  01:30 p.m.
        Try
            Dim Guardo As Boolean = False
            Using objBultos As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
                Guardo = objBultos.usp_Captura_ProtraspPropuesto(2, Txt_Marca.Text, Txt_Modelo.Text, "", 0, 0, 0, GLB_Idempleado)
            End Using

            '' ir al siguiente 
            If intPosicion = intTotalRows Then
                intPosicion = 0
            Else
                intPosicion += 1
            End If



            Txt_Marca.Text = objDataSetModelos.Tables(0).Rows(intPosicion).Item("marca").ToString
            Txt_Modelo.Text = objDataSetModelos.Tables(0).Rows(intPosicion).Item("estilon").ToString
            ' '' ''Txt_Modelo.Text = Val(Txt_Modelo.Text) + 1


            Txt_Estilof.Text = ""
            Lbl_Totales.Text = intPosicion & " de " & intTotalRows
            Txt_Marca_LostFocus(sender, e)
            Txt_Modelo_LostFocus(sender, e)
            Sw_Entro = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_DetenerProceso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_DetenerProceso.Click
        Try
            blnAbortar = True

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Limpiar.Click
        'mreyes 29/Julio/2016   11:37 a.m.
        Try
            ' If MsgBox("Se generará la petición de traspaso, de todas las propuestas pendientes .", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub

            'If usp_GeneraPeticionTraspasoTodos() = False Then

            'End If

            Dim myForm As New frmPpalResumenUsuarios

            myForm.StartPosition = FormStartPosition.CenterParent
            myForm.ShowDialog()


            Me.Close()
            Me.Dispose()
            'Dim myForm As New frmPpaPendientesRealizar

            'myForm.MdiParent = BitacoraMain
            'myForm.WindowState = FormWindowState.Maximized
            'myForm.Opcion = 1
            'myForm.OpcionSP = 1
            'myForm.Show()
            'myForm.Refresh()


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Pnl_Edicion_Paint(sender As Object, e As PaintEventArgs) Handles Pnl_Edicion.Paint

    End Sub
End Class
