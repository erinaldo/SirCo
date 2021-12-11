Imports System.Text.RegularExpressions

Public Class frmAnalisisModelo

    Dim Sw_Consulta As Boolean = False
    Dim Sql As String
    Public Accion As Integer  ' 1 = Administración , 2 = Tiendas 
    Public Sw_Registro As Boolean = False
    Private objDataSet As Data.DataSet
    Private objDataSetFiltro As Data.DataSet
    Private objDataSetModelos As Data.DataSet
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

    Dim intPosicion As Integer = 0
    Dim intTotalRows As Integer = 0

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
    Public Marca As String = ""
    Public Estilon As String = ""
    Public OrdeComp As String = ""
    Public Proveedor As String = ""
    Dim Clasif As String = ""
    Public Fecha As Date = "1900-01-01"
    Dim Sw_Load As Boolean = False
    Public Sw_Menu As Boolean = False
    Dim Intervalo As String = "1"

    Private Sub frmAnalisisModelo_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If usp_BorrarAnaModArticulo() Then

        End If
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

            Me.Text = "Análisis Modelo " & Txt_Marca.Text & " - " & Txt_Modelo.Text
            '''' Using objCatalogoEstilos As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
            '''' objDataSetModelos = objCatalogoEstilos.usp_TraerModelosMarca(0, "")
            If Txt_Modelo.Text.Length > 0 Then
                Call Txt_Modelo_LostFocus(sender, e)
                Exit Sub
            End If

            ''''End Using

            '' ''Using objCatalogoEst As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
            '' ''    objDataSet = objCatalogoEst.usp_TraerIdArticulo(Txt_Marca.Text, Txt_Modelo.Text)
            '' ''    If objDataSet.Tables(0).Rows.Count > 0 Then
            '' ''        Txt_IdArticulo.Text = objDataSet.Tables(0).Rows(0).Item("idarticulo")
            '' ''    End If
            '' ''End Using

            '' ''If objDataSetModelos.Tables(0).Rows.Count > 0 Then
            '' ''    intPosicion = 0
            '' ''    intTotalRows = objDataSetModelos.Tables(0).Rows.Count - 1
            '' ''End If

            '' ''For i As Integer = 0 To objDataSetModelos.Tables(0).Rows.Count - 1
            '' ''    If objDataSet.Tables(0).Rows(0).Item("idarticulo") = objDataSetModelos.Tables(0).Rows(i).Item("idarticulo") Then
            '' ''        intPosicion = i
            '' ''    End If
            '' ''Next



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
                    Btn_Excel.Enabled = False
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
            ToolTip.SetToolTip(DGrid, "Detallado de existencias del Artículo")
            ToolTip.SetToolTip(Btn_ModAnterior, "Consultar Modelo Anterior")
            ToolTip.SetToolTip(Btn_ModSiguiente, "Consultar Modelo Siguiente")
            ToolTip.SetToolTip(Btn_Aceptar, "Consultar el rango de fechas seleccionadas")
            ToolTip.SetToolTip(Btn_Salir, "Salir")
            ToolTip.SetToolTip(Btn_Series, "Consultar Series Activas")
            ToolTip.SetToolTip(Btn_Limpiar, "Limpiar Datos")
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
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
                If usp_BorrarAnaModArticulo() Then

                End If

                Me.Dispose()
                Me.Close()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        Try

            DGrid.DataSource = Nothing
            DGrid.Refresh()
            DGrid.Rows.Clear()

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
            'Obtiene el id del articulo 
            ''If Txt_Marca.Text = "" Then Exit Sub

            ' If Txt_Modelo.Text = "" Then
            'Txt_Modelo.Focus()
            '' Exit Sub
            ' End If




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

                    intervalo = objDataSet.Tables(0).Rows(0).Item("intervalo").ToString
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

                    If Val(objDataSet.Tables(0).Rows(0).Item("idagrupacion")) = 103 Or Val(objDataSet.Tables(0).Rows(0).Item("idagrupacion")) = 108 Or Val(objDataSet.Tables(0).Rows(0).Item("idagrupacion")) = 109 Or Val(objDataSet.Tables(0).Rows(0).Item("idagrupacion")) = 110 Then
                        Lbl_Totales.Text = "PARES UNICOS"
                    ElseIf objDataSet.Tables(0).Rows(0).Item("descripfamilia").ToString = "BASICO" Then
                        Lbl_Totales.Text = "BASICO"
                        If Txt_Marca.Text = "CTA" Then
                            Lbl_Totales.Text = "TRAC"
                        End If
                    Else
                        Lbl_Totales.Text = ""
                    End If


                    ''''Call usp_TraerFechaUltVenta()

                    ''''Call TraerCostoPrecio()

                    Call CargarFotoArticulo()
                    DGrid.Visible = False
                    ''''Call TraerPedido(objDataSet.Tables(0).Rows.Count)
                    Call RellenaGrid()
                    Call TraerCostoPrecio()
                    DGrid.Visible = True

                    Txt_Marca.Enabled = False
                    Txt_Modelo.Enabled = False
                    Txt_Estilof.Enabled = False

                    objDataSet = objCatalogoEst.usp_TraerIdArticulo(Txt_Marca.Text, Txt_Modelo.Text)
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Txt_IdArticulo.Text = objDataSet.Tables(0).Rows(0).Item("idarticulo")
                    End If
                    'End Using

                    ''For i As Integer = 0 To objDataSetModelos.Tables(0).Rows.Count - 1
                    ''    If objDataSet.Tables(0).Rows(0).Item("idarticulo") = objDataSetModelos.Tables(0).Rows(i).Item("idarticulo") Then
                    ''        intPosicion = i
                    ''    End If
                    ''Next
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

    Private Sub Btn_Limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Limpiar.Click
        Try
            If DGrid.Rows.Count >= 1 Then
                DGrid.DataSource = Nothing
                DGrid.Columns.Clear()
                DGrid.Rows.Clear()
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
            Txt_Estilof.Enabled = True


            PBox.Image = Nothing

            Chk_Lerdo.Checked = False

            If usp_BorrarAnaModArticulo() Then

            End If
            Txt_Marca.Select()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Series_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Series.Click
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

            ''If intPosicion <> 0 Then
            ''    intPosicion -= 1
            ''    If intPosicion = 0 Then
            ''        intPosicion = objDataSetModelos.Tables(0).Rows.Count - 1
            ''    End If
            ''ElseIf intPosicion = 0 Then
            ''    intPosicion = objDataSetModelos.Tables(0).Rows.Count - 1
            ''End If

            ''Txt_Marca.Text = objDataSetModelos.Tables(0).Rows(intPosicion).Item("marca").ToString
            ''Txt_Modelo.Text = objDataSetModelos.Tables(0).Rows(intPosicion).Item("modelo").ToString
            If Sw_Consulta = False Then
                Txt_Modelo.Text = Val(Txt_Modelo.Text) - 1
                Txt_Estilof.Text = ""
            Else
                If intPosicion <> 0 Then
                    intPosicion -= 1
                    If intPosicion = 0 Then
                        intPosicion = objDataSetModelos.Tables(0).Rows.Count - 1
                    End If
                ElseIf intPosicion = 0 Then
                    intPosicion = objDataSetModelos.Tables(0).Rows.Count - 1
                End If

                Txt_Marca.Text = objDataSetModelos.Tables(0).Rows(intPosicion).Item("marca").ToString
                Txt_Modelo.Text = objDataSetModelos.Tables(0).Rows(intPosicion).Item("estilon").ToString
                Txt_Estilof.Text = ""

            End If
            Txt_Marca_LostFocus(sender, e)
            Txt_Modelo_LostFocus(sender, e)
            ' Lbl_Totales.Text = intPosicion & " de " & intTotalRows
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_ModSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ModSiguiente.Click
        Try

            ''If intPosicion = intTotalRows Then
            ''    intPosicion = 0
            ''Else
            ''    intPosicion += 1
            ''End If

            'Txt_Marca.Text = objDataSetModelos.Tables(0).Rows(intPosicion).Item("marca").ToString
            'Txt_Modelo.Text = objDataSetModelos.Tables(0).Rows(intPosicion).Item("modelo").ToString
            If Sw_Consulta = False Then
                Txt_Modelo.Text = Val(Txt_Modelo.Text) + 1
                Txt_Estilof.Text = ""
              
            Else
                If intPosicion = intTotalRows Then
                    intPosicion = 0
                Else
                    intPosicion += 1
                End If

                Txt_Marca.Text = objDataSetModelos.Tables(0).Rows(intPosicion).Item("marca").ToString
                Txt_Modelo.Text = objDataSetModelos.Tables(0).Rows(intPosicion).Item("estilon").ToString
                Txt_Estilof.Text = ""
            End If

            Txt_Marca_LostFocus(sender, e)
            Txt_Modelo_LostFocus(sender, e)
            'Lbl_Totales.Text = intPosicion & " de " & intTotalRows

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub CopiarSeleccionToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CopiarSeleccionToolStripMenuItem.Click
        DGrid.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText

        'Me.DGrid.AllowUserToAddRows = False
        'Me.DGrid.Dock = DockStyle.Fill
        'Me.Controls.Add(Me.DGrid)

        If Me.DGrid.GetCellCount(DataGridViewElementStates.Selected) > 0 Then
            Try
                ' Add the selection to the clipboard.
                Clipboard.SetDataObject( _
                    Me.DGrid.GetClipboardContent())

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
    Private Sub TraerPedido(ByVal Conta As Integer)

        Try
            Sucursal = ""
            Me.Cursor = Cursors.WaitCursor
            If DGrid.Rows.Count >= 1 Then

                DGrid.DataSource = Nothing

                DGrid.Columns.Clear()
                DGrid.Rows.Clear()
                'DGrid.Columns.Remove("Total")
                'DGrid.Rows.Add()

                'For i As Integer = 2 To DGrid2.Columns.Count - 1
                '    DGrid2.Columns(i).Visible = False
                'Next

            End If

            'If Sucursal <> "" Then

            Dim objDataSet1 As New DataSet
            objDataSet1.Tables.Add()
            'For x As Integer = 1 To 8
            'Sucursal = pub_RellenarIzquierda(x.ToString, 2)
            Dim objDataSetAuxiliar As New Data.DataSet
            Dim objDataSetSucursales As New Data.DataSet

            Me.Cursor = Cursors.WaitCursor
            'Using objPedidos As New BCL.BCLResurtido(GLB_ConStringCipSis)
            '    objDataSetAuxiliarMod = objPedidos.usp_TraerDatosArticulo(Txt_Marca.Text, Txt_Modelo.Text, Proveedor, Clasif)
            'End Using
            Dim Clasificacion As String = ""
            Dim blnClonoDS As Boolean = False
            Dim Renglon As Integer = 0
            Dim RenglonR As Integer = 0
            'Me.Cursor = Cursors.Default
            Dim c As Integer = 0
            'PB_Analisis.Visible = True
            'PB_Analisis.Value = 0
            'PB_Analisis.Maximum = 10000
            Dim contado As Integer = 0
            Dim contAux = 7000 / Conta
            Dim intConAux As Integer = 0
            Dim a As Integer
            Dim contador As Integer
            Dim MaxMedidas As Integer
            Dim Marca2 As String
            Dim Estilon2 As String
            Dim Medidas As Integer
            Dim Col As Integer
            Dim Ini As String
            Dim Fin As String
            Dim Interval As String
            Dim Medida As String
            Dim MedIni As String
            Dim MedFin As String
            Dim Intervalo As String
            Dim Columna As Integer
            Dim TotalArticulos As Integer
            Dim TotalTodos As Decimal
            Dim contaux2 As Integer
            Dim Total As Integer
            Dim Ma As String
            Dim Es As String
            Dim Su As String
            Dim TotalImporte As Decimal
            Dim Visible As Boolean
            'Dim Articulos As Integer
            'Dim Prov As String
            'Dim Dsctopp As Decimal
            'Dim Diaspp As Decimal
            'Dim Dscto01 As Decimal
            'Dim Dscto02 As Decimal
            'Dim Dscto03 As Decimal
            'Dim Dscto04 As Decimal
            'Dim Dscto05 As Decimal
            'Dim corrida As String
            'Dim Costo As Decimal
            'Dim PComp As Decimal
            'Dim Tot1 As Decimal 
            For m As Integer = 0 To Conta - 1
                Using objPedidos As New BCL.BCLResurtido(GLB_ConStringCipSis)
                    objDataSetSucursales = objPedidos.usp_TraerSucursal("")
                End Using
                'contado = contado + contAux
                intConAux = contAux / objDataSetSucursales.Tables(0).Rows.Count
                For h As Integer = 0 To objDataSetSucursales.Tables(0).Rows.Count - 1
                    contado = contado + intConAux
                    'For m As Integer = 0 To 200 - 1
                    Sucursal = objDataSetSucursales.Tables(0).Rows(h).Item("sucursal").ToString
                    If objDataSetSucursales.Tables(0).Rows(h).Item("visible").ToString = "S" Then
                        Visible = True
                    Else
                        Visible = False
                    End If

                    If Visible = False Then Continue For
                    If Sucursal = "07" AndAlso Chk_Lerdo.Checked = False Then Continue For

                    'If Sucursal = "00" Or Sucursal = "19" Or Sucursal = "20" Or Sucursal = "98" Or Sucursal = "15" Or Sucursal = "34" Or Sucursal = "99" _
                    'Or Sucursal = "03" Or Sucursal = "04" Or Sucursal = "05" Or Sucursal = "33" Then Continue For
                    'Clasificacion = objDataSetAuxiliar.Tables(0).Rows(m).Item("artcat")
                    'If Clasificacion.Trim = "D" Then Continue For
                    Estilon = Txt_Modelo.Text
                    Dim objDataSetOC As New Data.DataSet
                    Dim objDataSetR As New Data.DataSet

                    'Using objPedidos As New BCL.BCLResurtido(GLB_ConStringCipSis)
                    '    objDataSet = objPedidos.usp_TraerVentasMedida(FechaInib, FechaFinb, Sucursal, Marca, "", Estilon, "", "")
                    'End Using

                    Using objCatMod As New BCL.BCLCatalogoModelos(GLB_ConStringDWH)
                        objDataSet = objCatMod.usp_TraerVentasModeloAnalisis(Sucursal, Txt_IdArticulo.Text, CDate(FechaInib), CDate(FechaFinb))
                    End Using

                    objDataSetOC = objDataSet.Clone
                    objDataSetR = objDataSet.Clone
                    Dim dataRowVenta As DataRow = Nothing
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        dataRowVenta = objDataSet.Tables(0).Rows(0)
                    End If

                    Dim objDataSetAux3 As New Data.DataSet
                    Using objPedidos As New BCL.BCLResurtido(GLB_ConStringCipSis)
                        objDataSetAux3 = objPedidos.usp_TraerExistenciaMedida(Sucursal, Txt_Marca.Text, Txt_Modelo.Text, "", "")
                    End Using
                    Dim dataRowExistencia As DataRow = Nothing
                    If objDataSetAux3.Tables(0).Rows.Count > 0 Then
                        dataRowExistencia = objDataSetAux3.Tables(0).Rows(0)
                    End If

                    'If dataRowVenta Is Nothing And dataRowExistencia Is Nothing Then
                    '    Continue For
                    'End If

                    Dim objDataSetAuxC As New Data.DataSet
                    Using objPedidos As New BCL.BCLResurtido(GLB_ConStringCipSis)
                        objDataSetAuxC = objPedidos.usp_TraerDetFPMedida(Sucursal, Txt_Marca.Text, Txt_Modelo.Text, CDate(FechaInib), CDate(FechaFinb))
                    End Using
                    Dim dataRowComp As DataRow = Nothing
                    If objDataSetAuxC.Tables(0).Rows.Count > 0 Then
                        dataRowComp = objDataSetAuxC.Tables(0).Rows(0)
                    End If


                    Dim objDataSetAux4 As New Data.DataSet
                    Using objPedidos As New BCL.BCLResurtido(GLB_ConStringCipSis)
                        objDataSetAux4 = objPedidos.usp_TraerDetOCMedida(Sucursal, "", Txt_Marca.Text, Txt_Modelo.Text, "")
                    End Using
                    Dim dataRowPP As DataRow = Nothing
                    If objDataSetAux4.Tables(0).Rows.Count > 0 Then
                        dataRowPP = objDataSetAux4.Tables(0).Rows(0)
                    End If


                    GenerarSugerido(dataRowVenta, dataRowExistencia, dataRowComp, dataRowPP, objDataSetOC, objDataSetR)


                    If blnClonoDS = False Then
                        objDataSetVtasCero = objDataSetOC.Clone
                        objDataSetResmin = objDataSetR.Clone
                        blnClonoDS = True
                    End If
                    If objDataSetOC.Tables(0).Rows.Count > 0 Then
                        For i As Integer = 0 To objDataSetOC.Tables(0).Rows.Count - 1
                            objDataSetVtasCero.Tables(0).ImportRow(objDataSetOC.Tables(0).Rows(i))
                            Renglon += 1
                        Next
                        objDataSetVtasCero.Tables(0).Rows.Add()
                    End If
                    If objDataSetR.Tables(0).Rows.Count > 0 Then
                        For i As Integer = 0 To objDataSetR.Tables(0).Rows.Count - 1
                            objDataSetResmin.Tables(0).ImportRow(objDataSetR.Tables(0).Rows(i))
                            RenglonR += 1
                        Next
                        objDataSetResmin.Tables(0).Rows.Add()
                    End If
                    Dim nu As Integer = 16
                    c += 1
                    System.GC.Collect()
                    'PB_Analisis.Value = contado
                Next

            Next
            If c = 0 Then
                'MessageBox.Show("No hay datos recientes disponibles para este modelo.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            Dim objDataSetAux2 As New DataSet
            objDataSetVtasCero.Tables(0).Rows.Remove(objDataSetVtasCero.Tables(0).Rows(objDataSetVtasCero.Tables(0).Rows.Count - 1))
            objDataSetPruebas = objDataSetVtasCero.Clone
            objDataSetAux2.Tables.Clear()
            objDataSetAux2.Tables.Add()
            objDataSetAux2.Tables(0).Columns.Add("Sucursal")
            objDataSetAux2.Tables(0).Columns.Add("Marca")
            objDataSetAux2.Tables(0).Columns.Add("Estilon")
            objDataSetAux2.Tables(0).Columns.Add("Estilof")
            objDataSetAux2.Tables(0).Columns.Add("Tipo")

            objDataSet.Tables.Clear()
            objDataSet.Tables.Add()
            objDataSet.Tables(0).Columns.Add("Marca")
            objDataSet.Tables(0).Columns.Add("Estilon")
            a = 0
            contador = 0
            While a <= objDataSetVtasCero.Tables(0).Rows.Count - 1
                objDataSet.Tables(0).Rows.Add()
                objDataSet.Tables(0).Rows(contador).Item("Marca") = objDataSetVtasCero.Tables(0).Rows(a).Item("Marca")
                objDataSet.Tables(0).Rows(contador).Item("Estilon") = objDataSetVtasCero.Tables(0).Rows(a).Item("Estilon")
                contador += 1
                a += 5
            End While
            MaxMedidas = 0
            For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                Marca2 = ""
                Estilon2 = ""
                Marca2 = objDataSet.Tables(0).Rows(i).Item("Marca").ToString
                Estilon2 = objDataSet.Tables(0).Rows(i).Item("Estilon").ToString
                If Marca2 = "CRO" And Estilon2 = "    124" Then
                    MaxMedidas = 17
                    Continue For
                End If
                Using objPedido As New BCL.BCLResurtido(GLB_ConStringCipSis)
                    Medidas = 0
                    Medidas = objPedido.usp_TraerMedida2(Marca2, Estilon2, "").Tables(0).Rows.Count
                    If Medidas > MaxMedidas Then
                        MaxMedidas = Medidas
                    End If
                End Using
            Next
            For i As Integer = 1 To MaxMedidas
                objDataSetAux2.Tables(0).Columns.Add(i.ToString)
            Next
            objDataSetAux2.Tables(0).Rows.Add()
            '
            'Using objPedido As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
            '    objDataSetCorrida = objPedido.usp_TraerCorrida(objDataSetVtasCero.Tables(0).Rows(i + 1).Item("Marca").ToString, objDataSetVtasCero.Tables(0).Rows(i + 1).Item("Estilon").ToString, "", "")
            'End Using
            'AQUI CAMBIE

            Using objPedido As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
                objDataSetCorrida = objPedido.usp_TraerCorridaAgrupado(Txt_Marca.Text, Txt_Modelo.Text, "", "")
            End Using

            For i As Integer = 0 To objDataSetVtasCero.Tables(0).Rows.Count - 1
                objDataSetAux2.Tables(0).Rows.Add()
                If i = 0 Then
                    ''
                    Col = 5
                    For k As Integer = 0 To objDataSetCorrida.Tables(0).Rows.Count - 1
                        Ini = ""
                        Fin = ""
                        Interval = ""
                        Ini = objDataSetCorrida.Tables(0).Rows(k).Item("medini").ToString
                        Fin = objDataSetCorrida.Tables(0).Rows(k).Item("medfin").ToString
                        Interval = objDataSetCorrida.Tables(0).Rows(k).Item("intervalo").ToString
                        If Ini.Length = 1 Then
                            Ini = pub_RellenarIzquierda(Ini, 2)
                        End If
                        If Fin.Length = 1 Then
                            Fin = pub_RellenarIzquierda(Fin, 2)
                        End If
                        For j As Integer = 5 To objDataSetVtasCero.Tables(0).Columns.Count - 1

                            Medida = ""
                            Medida = TraerMedida(objDataSetVtasCero.Tables(0).Columns(j).ColumnName)
                            If Medida = "21" Then
                                Medida = Medida
                            End If
                            If Medida.Length = 3 Then
                                If Interval <> "-" And Medida.Substring(2, 1) = "-" Then
                                    Continue For
                                End If
                            End If
                            If Medida >= Ini And Medida <= Fin Then

                                If Col > objDataSetAux2.Tables(0).Columns.Count - 1 Then
                                    Continue For
                                End If
                                objDataSetAux2.Tables(0).Rows(i).Item(Col) = Medida
                                Col += 1
                            End If
                        Next
                    Next
                End If
                If objDataSetVtasCero.Tables(0).Rows(i).Item(0).ToString.Trim = "" Then
                    'Using objPedido As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
                    '    objDataSet = objPedido.usp_TraerCorrida(objDataSetVtasCero.Tables(0).Rows(i + 1).Item("Marca").ToString, objDataSetVtasCero.Tables(0).Rows(i + 1).Item("Estilon").ToString, "", "")
                    'End Using
                    Col = 5
                    For k As Integer = 0 To objDataSetCorrida.Tables(0).Rows.Count - 1
                        Ini = ""
                        Fin = ""
                        Interval = ""
                        Ini = objDataSetCorrida.Tables(0).Rows(k).Item("medini").ToString
                        Fin = objDataSetCorrida.Tables(0).Rows(k).Item("medfin").ToString
                        Interval = objDataSetCorrida.Tables(0).Rows(k).Item("intervalo").ToString
                        If Ini.Length = 1 Then
                            Ini = pub_RellenarIzquierda(Ini, 2)
                        End If
                        If Fin.Length = 1 Then
                            Fin = pub_RellenarIzquierda(Fin, 2)
                        End If
                        For j As Integer = 5 To objDataSetVtasCero.Tables(0).Columns.Count - 1
                            Medida = ""
                            Medida = TraerMedida(objDataSetVtasCero.Tables(0).Columns(j).ColumnName)
                            If Medida.Length = 3 Then
                                If Interval <> "-" And Medida.Substring(2, 1) = "-" Then
                                    Continue For
                                End If
                            End If
                            If Medida >= Ini And Medida <= Fin Then
                                If Col > objDataSetAux2.Tables(0).Columns.Count - 1 Then
                                    Continue For
                                End If
                                objDataSetAux2.Tables(0).Rows(i + 1).Item(Col) = Medida
                                Col += 1
                            End If
                        Next

                    Next
                    Continue For
                End If
                objDataSetAux2.Tables(0).Rows(i + 1).Item("Sucursal") = objDataSetVtasCero.Tables(0).Rows(i).Item("Sucursal").ToString
                objDataSetAux2.Tables(0).Rows(i + 1).Item("Marca") = objDataSetVtasCero.Tables(0).Rows(i).Item("Marca").ToString
                objDataSetAux2.Tables(0).Rows(i + 1).Item("Estilon") = objDataSetVtasCero.Tables(0).Rows(i).Item("Estilon").ToString
                objDataSetAux2.Tables(0).Rows(i + 1).Item("Estilof") = objDataSetVtasCero.Tables(0).Rows(i).Item("Estilof").ToString
                objDataSetAux2.Tables(0).Rows(i + 1).Item("Tipo") = objDataSetVtasCero.Tables(0).Rows(i).Item("Tipo").ToString
                'Using objPedido As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
                '    objDataSet = objPedido.usp_TraerCorrida(objDataSetVtasCero.Tables(0).Rows(i).Item("Marca").ToString, objDataSetVtasCero.Tables(0).Rows(i).Item("Estilon").ToString, "", "")
                'End Using 
                Columna = 5
                For k As Integer = 0 To objDataSetCorrida.Tables(0).Rows.Count - 1
                    MedIni = ""
                    MedFin = ""
                    Intervalo = ""
                    MedIni = objDataSetCorrida.Tables(0).Rows(k).Item("medini").ToString
                    MedFin = objDataSetCorrida.Tables(0).Rows(k).Item("medfin").ToString
                    Intervalo = objDataSetCorrida.Tables(0).Rows(k).Item("intervalo").ToString
                    If MedIni.Length = 1 Then
                        MedIni = pub_RellenarIzquierda(MedIni, 2)
                    End If
                    If MedFin.Length = 1 Then
                        MedFin = pub_RellenarIzquierda(MedFin, 2)
                    End If
                    For j As Integer = 5 To objDataSetVtasCero.Tables(0).Columns.Count - 1
                        If k = 1 Then
                            k = k
                        End If
                        Medida = ""
                        Medida = TraerMedida(objDataSetVtasCero.Tables(0).Columns(j).ColumnName)
                        If Medida = "21" Then
                            Medida = Medida
                        End If
                        If Medida.Length = 3 Then
                            If Intervalo <> "-" And Medida.Substring(2, 1) = "-" Then
                                Continue For
                            End If
                        End If
                        If Medida >= MedIni And Medida <= MedFin Then
                            If Columna > objDataSetAux2.Tables(0).Columns.Count - 1 Then
                                Continue For
                            End If
                            objDataSetAux2.Tables(0).Rows(i + 1).Item(Columna) = objDataSetVtasCero.Tables(0).Rows(i).Item(j).ToString
                            Columna += 1
                        End If
                    Next
                Next
            Next

            Dim mi As Integer = 16
            objDataSetAux2.Tables(0).Columns.Add("total")
            objDataSetAux2.Tables(0).Columns.Add("ultimo")
            objDataSetAux2.Tables(0).Columns.Add("importe")
            objDataSetAux2.Tables(0).Columns.Add("proveedor")
            TotalArticulos = 0
            TotalTodos = 0
            contaux2 = 0
            contaux2 = contado / objDataSetAux2.Tables(0).Rows.Count
            For i As Integer = 0 To objDataSetAux2.Tables(0).Rows.Count - 1
                Total = 0
                If IsDBNull(objDataSetAux2.Tables(0).Rows(i).Item(0)) Then
                    Continue For
                End If
                Ma = ""
                Es = ""
                Su = ""
                Ma = objDataSetAux2.Tables(0).Rows(i).Item("Marca").ToString
                Es = objDataSetAux2.Tables(0).Rows(i).Item("Estilon").ToString
                Su = objDataSetAux2.Tables(0).Rows(i).Item("Sucursal").ToString
                Clasif = ""
                'Using objPedidoNuevo As New BCL.BCLResurtido(GLB_ConStringCipSis)
                '    objDataSet = objPedidoNuevo.usp_TraerDatosArticulo(Ma, Es, "", Clasif)
                'End Using

                ' para que quiere el proveedor.


                objDataSetAux2.Tables(0).Rows(i).Item("Proveedor") = Txt_Proveedor.Text


                For j As Integer = 5 To objDataSetAux2.Tables(0).Columns.Count - 4
                    If IsDBNull(objDataSetAux2.Tables(0).Rows(i).Item(j)) Then
                        Continue For
                    End If
                    Total += CInt(objDataSetAux2.Tables(0).Rows(i).Item(j).ToString)
                Next
                objDataSetAux2.Tables(0).Rows(i).Item("Total") = Total

                If objDataSetAux2.Tables(0).Rows(i).Item("Tipo").ToString.Trim = "VENTA" Then
                    Using objPedidoNuevo As New BCL.BCLResurtido(GLB_ConStringCipSis)
                        objDataSet = objPedidoNuevo.usp_TraerFecUltVenta(Ma, Es, Su, "", "")
                    End Using
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Dim Fecha As Date
                        Fecha = objDataSet.Tables(0).Rows(0).Item("fecha").ToString
                        objDataSetAux2.Tables(0).Rows(i).Item("Ultimo") = Fecha.ToString("dd/MMM/yyyy").ToUpper
                    End If
                End If
                If objDataSetAux2.Tables(0).Rows(i).Item("Tipo").ToString.Trim = "PEDIDO PENDIENTE" Then
                    Using objPedidoNuevo As New BCL.BCLResurtido(GLB_ConStringCipSis)
                        objDataSet = objPedidoNuevo.usp_TraerFecUltPedido(Ma, Es, Su)
                    End Using
                    If objDataSet.Tables(0).Rows.Count > 1 Then
                        Dim Fecha As Date
                        Fecha = objDataSet.Tables(0).Rows(1).Item("fecha").ToString
                        objDataSetAux2.Tables(0).Rows(i).Item("Ultimo") = Fecha.ToString("dd/MMM/yyyy").ToUpper
                    End If
                End If

                If objDataSetAux2.Tables(0).Rows(i).Item("Tipo").ToString.Trim = "COMPRAS" Then
                    Using objPedidoNuevo As New BCL.BCLResurtido(GLB_ConStringCipSis)
                        objDataSet = objPedidoNuevo.usp_TraerFecUltRecibo(Txt_Marca.Text, Txt_Modelo.Text, Su)
                    End Using
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Dim Fecha As Date

                        If objDataSet.Tables(0).Rows(0).Item("fecha") <> "1900-01-01" Then
                            Fecha = objDataSet.Tables(0).Rows(0).Item("fecha").ToString
                            objDataSetAux2.Tables(0).Rows(i).Item("Ultimo") = Fecha.ToString("dd/MMM/yyyy").ToUpper
                        End If
                    End If
                    TotalImporte = 0

                    TotalTodos += TotalImporte
                    objDataSetAux2.Tables(0).Rows(i).Item("Importe") = TotalImporte
                    TotalArticulos += objDataSetAux2.Tables(0).Rows(i).Item("Total").ToString

                End If
                contado = contado + contaux2
                If contado <= 9500 Then
                    'PB_Analisis.Value = contado
                End If


            Next
            'Txt_Importe.Text = "$" + Format(TotalTodos, "###,##0.00")
            'Txt_Pares.Text = TotalArticulos

            'objDataSet1 = objDataSetAux2.Clone

            For k As Integer = 0 To objDataSetAux2.Tables(0).Rows.Count - 1
                objDataSet1.Tables(0).ImportRow(objDataSetAux2.Tables(0).Rows(k))
            Next

            ' Next
            DGrid.DataSource = Nothing
            For i As Integer = 0 To DGrid.Columns.Count - 1
                DGrid.Columns.Remove(DGrid.Columns(0))
            Next
            DGrid.DataSource = objDataSetAux2.Tables(0)
            objDataSetVtasCero = objDataSetAux2.Clone
            InicializaGridDetAna()
            'PB_Analisis.Value = 9999
            'Me.Cursor = Cursors.Default
            DGrid.Rows(0).Selected = True
            'PB_Analisis.Visible = False


            ' check lote min
            For i As Integer = 0 To DGrid.Rows.Count - 1
                DGrid.Rows(i).Visible = True
            Next

            Me.Cursor = Cursors.Default
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Public Sub GenerarSugerido(ByVal DataRowVentas As DataRow, ByVal DataRowExistencia As DataRow, ByVal DataRowComp As DataRow, ByVal DataRowPP As DataRow, ByRef objDataSetOC As DataSet, ByRef objDataSetResmin As DataSet)
        'Dim DataRowSugerido As DataRow

        If DataRowVentas Is Nothing Then
            DataRowVentas = objDataSetOC.Tables(0).NewRow
            DataRowVentas.Item(0) = Sucursal
            DataRowVentas.Item(1) = Txt_Marca.Text
            DataRowVentas.Item(2) = Txt_Modelo.Text

            'Using objCantArti As New BCL.BCLResurtido(GLB_ConStringCipSis)
            '    objDataSet = objCantArti.usp_TraerDatosArticulo(Txt_Marca.Text, Txt_Modelo.Text, "", "")
            'End Using

            '' ''If objDataSetAuxiliarMod.Tables(0).Rows.Count > 0 Then
            '' ''    DataRowVentas.Item(3) = objDataSetAuxiliarMod.Tables(0).Rows(0).Item("Estilof").ToString
            '' ''Else
            '' ''    DataRowVentas.Item(3) = ""
            '' ''End If
            DataRowVentas.Item(4) = "VENTA"
            For i As Integer = 5 To 104
                DataRowVentas.Item(i) = 0
            Next
        End If

        If DataRowVentas IsNot Nothing And DataRowExistencia IsNot Nothing And DataRowComp IsNot Nothing And DataRowPP IsNot Nothing Then

            objDataSetResmin.Tables(0).LoadDataRow(DataRowVentas.ItemArray, True)
            objDataSetResmin.Tables(0).LoadDataRow(DataRowExistencia.ItemArray, True)
            objDataSetResmin.Tables(0).LoadDataRow(DataRowComp.ItemArray, True)
            objDataSetResmin.Tables(0).LoadDataRow(DataRowPP.ItemArray, True)

            objDataSetOC.Tables(0).LoadDataRow(DataRowVentas.ItemArray, True)
            objDataSetOC.Tables(0).LoadDataRow(DataRowExistencia.ItemArray, True)
            objDataSetOC.Tables(0).LoadDataRow(DataRowComp.ItemArray, True)
            objDataSetOC.Tables(0).LoadDataRow(DataRowPP.ItemArray, True)

        End If

        If DataRowVentas IsNot Nothing And DataRowExistencia IsNot Nothing And DataRowComp IsNot Nothing And DataRowPP Is Nothing Then


            DataRowPP = objDataSetOC.Tables(0).NewRow
            DataRowPP.Item(0) = DataRowVentas.Item(0)
            DataRowPP.Item(1) = DataRowVentas.Item(1)
            DataRowPP.Item(2) = DataRowVentas.Item(2)
            DataRowPP.Item(3) = DataRowVentas.Item(3)
            DataRowPP.Item(4) = "PEDIDO PENDIENTE"
            For i As Integer = 5 To 104
                DataRowPP.Item(i) = 0
            Next

            objDataSetResmin.Tables(0).LoadDataRow(DataRowVentas.ItemArray, True)
            objDataSetResmin.Tables(0).LoadDataRow(DataRowExistencia.ItemArray, True)
            objDataSetResmin.Tables(0).LoadDataRow(DataRowComp.ItemArray, True)
            objDataSetResmin.Tables(0).LoadDataRow(DataRowPP.ItemArray, True)

            objDataSetOC.Tables(0).LoadDataRow(DataRowVentas.ItemArray, True)
            objDataSetOC.Tables(0).LoadDataRow(DataRowExistencia.ItemArray, True)
            objDataSetOC.Tables(0).LoadDataRow(DataRowComp.ItemArray, True)
            objDataSetOC.Tables(0).LoadDataRow(DataRowPP.ItemArray, True)

        End If



        If DataRowVentas IsNot Nothing And DataRowExistencia IsNot Nothing And DataRowComp Is Nothing And DataRowPP IsNot Nothing Then

            DataRowComp = objDataSetOC.Tables(0).NewRow
            DataRowComp.Item(0) = DataRowVentas.Item(0)
            DataRowComp.Item(1) = DataRowVentas.Item(1)
            DataRowComp.Item(2) = DataRowVentas.Item(2)
            DataRowComp.Item(3) = DataRowVentas.Item(3)
            DataRowComp.Item(4) = "COMPRAS"
            For i As Integer = 5 To 104
                DataRowComp.Item(i) = 0
            Next

            objDataSetResmin.Tables(0).LoadDataRow(DataRowVentas.ItemArray, True)
            objDataSetResmin.Tables(0).LoadDataRow(DataRowExistencia.ItemArray, True)
            objDataSetResmin.Tables(0).LoadDataRow(DataRowComp.ItemArray, True)
            objDataSetResmin.Tables(0).LoadDataRow(DataRowPP.ItemArray, True)

            objDataSetOC.Tables(0).LoadDataRow(DataRowVentas.ItemArray, True)
            objDataSetOC.Tables(0).LoadDataRow(DataRowExistencia.ItemArray, True)
            objDataSetOC.Tables(0).LoadDataRow(DataRowComp.ItemArray, True)
            objDataSetOC.Tables(0).LoadDataRow(DataRowPP.ItemArray, True)
        End If


        If DataRowVentas IsNot Nothing And DataRowExistencia Is Nothing And DataRowComp IsNot Nothing And DataRowPP IsNot Nothing Then

            DataRowExistencia = objDataSetOC.Tables(0).NewRow
            DataRowExistencia.Item(0) = DataRowVentas.Item(0)
            DataRowExistencia.Item(1) = DataRowVentas.Item(1)
            DataRowExistencia.Item(2) = DataRowVentas.Item(2)
            DataRowExistencia.Item(3) = DataRowVentas.Item(3)
            DataRowExistencia.Item(4) = "EXISTENCIA"
            For i As Integer = 5 To 104
                DataRowExistencia.Item(i) = 0
            Next
            'If TotalPedido < Resmin And TotalPedido > 0 Then
            objDataSetResmin.Tables(0).LoadDataRow(DataRowVentas.ItemArray, True)
            objDataSetResmin.Tables(0).LoadDataRow(DataRowExistencia.ItemArray, True)
            objDataSetResmin.Tables(0).LoadDataRow(DataRowComp.ItemArray, True)
            objDataSetResmin.Tables(0).LoadDataRow(DataRowPP.ItemArray, True)

            objDataSetOC.Tables(0).LoadDataRow(DataRowVentas.ItemArray, True)
            objDataSetOC.Tables(0).LoadDataRow(DataRowExistencia.ItemArray, True)
            objDataSetOC.Tables(0).LoadDataRow(DataRowComp.ItemArray, True)
            objDataSetOC.Tables(0).LoadDataRow(DataRowPP.ItemArray, True)

        End If

        If DataRowVentas IsNot Nothing And DataRowExistencia Is Nothing And DataRowComp Is Nothing And DataRowPP Is Nothing Then


            DataRowExistencia = objDataSetOC.Tables(0).NewRow
            DataRowExistencia.Item(0) = DataRowVentas.Item(0)
            DataRowExistencia.Item(1) = DataRowVentas.Item(1)
            DataRowExistencia.Item(2) = DataRowVentas.Item(2)
            DataRowExistencia.Item(3) = DataRowVentas.Item(3)
            DataRowExistencia.Item(4) = "EXISTENCIA"
            For i As Integer = 5 To 104
                DataRowExistencia.Item(i) = 0
            Next
            DataRowComp = objDataSetOC.Tables(0).NewRow
            DataRowComp.Item(0) = DataRowVentas.Item(0)
            DataRowComp.Item(1) = DataRowVentas.Item(1)
            DataRowComp.Item(2) = DataRowVentas.Item(2)
            DataRowComp.Item(3) = DataRowVentas.Item(3)
            DataRowComp.Item(4) = "COMPRAS"
            For i As Integer = 5 To 104
                DataRowComp.Item(i) = 0
            Next
            DataRowPP = objDataSetOC.Tables(0).NewRow
            DataRowPP.Item(0) = DataRowVentas.Item(0)
            DataRowPP.Item(1) = DataRowVentas.Item(1)
            DataRowPP.Item(2) = DataRowVentas.Item(2)
            DataRowPP.Item(3) = DataRowVentas.Item(3)
            DataRowPP.Item(4) = "PEDIDO PENDIENTE"
            For i As Integer = 5 To 104
                DataRowPP.Item(i) = 0
            Next
            'If TotalPedido < Resmin And TotalPedido > 0 Then
            objDataSetResmin.Tables(0).LoadDataRow(DataRowVentas.ItemArray, True)
            objDataSetResmin.Tables(0).LoadDataRow(DataRowExistencia.ItemArray, True)
            objDataSetResmin.Tables(0).LoadDataRow(DataRowPP.ItemArray, True)
            objDataSetResmin.Tables(0).LoadDataRow(DataRowComp.ItemArray, True)

            objDataSetOC.Tables(0).LoadDataRow(DataRowVentas.ItemArray, True)
            objDataSetOC.Tables(0).LoadDataRow(DataRowExistencia.ItemArray, True)
            objDataSetOC.Tables(0).LoadDataRow(DataRowComp.ItemArray, True)
            objDataSetOC.Tables(0).LoadDataRow(DataRowPP.ItemArray, True)
        End If




        If DataRowVentas IsNot Nothing And DataRowExistencia IsNot Nothing And DataRowComp Is Nothing And DataRowPP Is Nothing Then


            DataRowComp = objDataSetOC.Tables(0).NewRow
            DataRowComp.Item(0) = DataRowVentas.Item(0)
            DataRowComp.Item(1) = DataRowVentas.Item(1)
            DataRowComp.Item(2) = DataRowVentas.Item(2)
            DataRowComp.Item(3) = DataRowVentas.Item(3)
            DataRowComp.Item(4) = "COMPRAS"
            For i As Integer = 5 To 104
                DataRowComp.Item(i) = 0
            Next
            DataRowPP = objDataSetOC.Tables(0).NewRow
            DataRowPP.Item(0) = DataRowVentas.Item(0)
            DataRowPP.Item(1) = DataRowVentas.Item(1)
            DataRowPP.Item(2) = DataRowVentas.Item(2)
            DataRowPP.Item(3) = DataRowVentas.Item(3)
            DataRowPP.Item(4) = "PEDIDO PENDIENTE"
            For i As Integer = 5 To 104
                DataRowPP.Item(i) = 0
            Next
            'If TotalPedido < Resmin And TotalPedido > 0 Then
            objDataSetResmin.Tables(0).LoadDataRow(DataRowVentas.ItemArray, True)
            objDataSetResmin.Tables(0).LoadDataRow(DataRowExistencia.ItemArray, True)
            objDataSetResmin.Tables(0).LoadDataRow(DataRowPP.ItemArray, True)
            objDataSetResmin.Tables(0).LoadDataRow(DataRowComp.ItemArray, True)

            objDataSetOC.Tables(0).LoadDataRow(DataRowVentas.ItemArray, True)
            objDataSetOC.Tables(0).LoadDataRow(DataRowExistencia.ItemArray, True)
            objDataSetOC.Tables(0).LoadDataRow(DataRowComp.ItemArray, True)
            objDataSetOC.Tables(0).LoadDataRow(DataRowPP.ItemArray, True)
        End If



        If DataRowVentas IsNot Nothing And DataRowExistencia Is Nothing And DataRowComp IsNot Nothing And DataRowPP Is Nothing Then


            DataRowExistencia = objDataSetOC.Tables(0).NewRow
            DataRowExistencia.Item(0) = DataRowVentas.Item(0)
            DataRowExistencia.Item(1) = DataRowVentas.Item(1)
            DataRowExistencia.Item(2) = DataRowVentas.Item(2)
            DataRowExistencia.Item(3) = DataRowVentas.Item(3)
            DataRowExistencia.Item(4) = "EXISTENCIA"
            For i As Integer = 5 To 104
                DataRowExistencia.Item(i) = 0
            Next

            DataRowPP = objDataSetOC.Tables(0).NewRow
            DataRowPP.Item(0) = DataRowVentas.Item(0)
            DataRowPP.Item(1) = DataRowVentas.Item(1)
            DataRowPP.Item(2) = DataRowVentas.Item(2)
            DataRowPP.Item(3) = DataRowVentas.Item(3)
            DataRowPP.Item(4) = "PEDIDO PENDIENTE"
            For i As Integer = 5 To 104
                DataRowPP.Item(i) = 0
            Next
            'If TotalPedido < Resmin And TotalPedido > 0 Then
            objDataSetResmin.Tables(0).LoadDataRow(DataRowVentas.ItemArray, True)
            objDataSetResmin.Tables(0).LoadDataRow(DataRowExistencia.ItemArray, True)
            objDataSetResmin.Tables(0).LoadDataRow(DataRowPP.ItemArray, True)
            objDataSetResmin.Tables(0).LoadDataRow(DataRowComp.ItemArray, True)

            objDataSetOC.Tables(0).LoadDataRow(DataRowVentas.ItemArray, True)
            objDataSetOC.Tables(0).LoadDataRow(DataRowExistencia.ItemArray, True)
            objDataSetOC.Tables(0).LoadDataRow(DataRowComp.ItemArray, True)
            objDataSetOC.Tables(0).LoadDataRow(DataRowPP.ItemArray, True)
        End If


        If DataRowVentas IsNot Nothing And DataRowExistencia Is Nothing And DataRowComp Is Nothing And DataRowPP IsNot Nothing Then


            DataRowExistencia = objDataSetOC.Tables(0).NewRow
            DataRowExistencia.Item(0) = DataRowVentas.Item(0)
            DataRowExistencia.Item(1) = DataRowVentas.Item(1)
            DataRowExistencia.Item(2) = DataRowVentas.Item(2)
            DataRowExistencia.Item(3) = DataRowVentas.Item(3)
            DataRowExistencia.Item(4) = "EXISTENCIA"
            For i As Integer = 5 To 104
                DataRowExistencia.Item(i) = 0
            Next
            DataRowComp = objDataSetOC.Tables(0).NewRow
            DataRowComp.Item(0) = DataRowVentas.Item(0)
            DataRowComp.Item(1) = DataRowVentas.Item(1)
            DataRowComp.Item(2) = DataRowVentas.Item(2)
            DataRowComp.Item(3) = DataRowVentas.Item(3)
            DataRowComp.Item(4) = "COMPRAS"
            For i As Integer = 5 To 104
                DataRowComp.Item(i) = 0
            Next
            'If TotalPedido < Resmin And TotalPedido > 0 Then
            objDataSetResmin.Tables(0).LoadDataRow(DataRowVentas.ItemArray, True)
            objDataSetResmin.Tables(0).LoadDataRow(DataRowExistencia.ItemArray, True)
            objDataSetResmin.Tables(0).LoadDataRow(DataRowPP.ItemArray, True)
            objDataSetResmin.Tables(0).LoadDataRow(DataRowComp.ItemArray, True)

            objDataSetOC.Tables(0).LoadDataRow(DataRowVentas.ItemArray, True)
            objDataSetOC.Tables(0).LoadDataRow(DataRowExistencia.ItemArray, True)
            objDataSetOC.Tables(0).LoadDataRow(DataRowComp.ItemArray, True)
            objDataSetOC.Tables(0).LoadDataRow(DataRowPP.ItemArray, True)
        End If
    End Sub

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

    Sub InicializaGridDetAna()
        '' 
        Try

            DGrid.RowHeadersVisible = False
            DGrid.Columns(0).HeaderText = "Det"
            DGrid.Columns(1).HeaderText = "Marca"
            DGrid.Columns(2).HeaderText = "Modelo"
            DGrid.Columns(3).HeaderText = "Estilo"
            DGrid.Columns(4).HeaderText = "Concepto"
            For i As Integer = 5 To DGrid.Columns.Count - 5
                DGrid.Columns(i).HeaderText = "    "
            Next
            'DGrid.Columns(DGrid.Columns.Count - 2).HeaderText = "Total"
            DGrid.Columns(DGrid.Columns.Count - 4).HeaderText = "Total"
            DGrid.Columns(DGrid.Columns.Count - 3).HeaderText = "Fecha Concepto"
            DGrid.Columns(DGrid.Columns.Count - 2).HeaderText = "Importe"
            DGrid.Columns(DGrid.Columns.Count - 1).HeaderText = "Proveedor"

            'For i As Integer = 0 To DGrid.ColumnCount - 1
            '    DGrid.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'Next
            DGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            'DGrid.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            'DGrid.Columns(0).Visible = False
            'DGrid.Columns(1).Visible = False
            'DGrid.Columns(2).Visible = False
            'DGrid.Columns(3).Visible = False
            DGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            For i As Integer = 5 To DGrid.Columns.Count - 5
                DGrid.Columns(i).Visible = False
            Next

            '''''''''''''''''''''''''''''''''''''''''''''
            DGrid.Columns("Importe").DefaultCellStyle.Format = "c"
            DGrid.Columns("Ultimo").DisplayIndex = 5
            DGrid.Columns("Importe").DisplayIndex = DGrid.Columns.Count - 1
            'VentasToolStripMenuItem.Visible = True
            'UltimoPedidoToolStripMenuItem.Visible = True
            'PedidoToolStripMenuItem.Visible = True
            'AnaliticoToolStripMenuItem.Visible = False

            DGrid.Columns(1).Visible = False
            DGrid.Columns(2).Visible = False
            DGrid.Columns(3).Visible = False
            DGrid.Columns(DGrid.Columns.Count - 2).Visible = False

            DGrid.Columns(0).Frozen = True
            'DGrid.Columns(1).Frozen = True
            'DGrid.Columns(2).Frozen = True
            'DGrid.Columns(3).Frozen = True
            DGrid.Columns(4).Frozen = True
            DGrid.Columns("Ultimo").Frozen = True

            DGrid.Columns("Proveedor").Visible = False

            RellenarCorridasAna()
            AgregarColumna()
            ColorearGrid()
            Dim blnMedidas
            Dim s1 As String
            Dim m1 As String
            Dim e1 As String
            Dim s2 As String
            Dim m2 As String
            Dim e2 As String
            For i As Integer = 0 To DGrid.Rows.Count - 2
                If IsDBNull(DGrid.Rows(i).Cells(0).Value) Then Continue For
                'If DGrid.Rows(i).Cells(0).Value Is Nothing Then Continue For
                blnMedidas = False
                s1 = ""
                m1 = ""
                e1 = ""
                s1 = DGrid.Rows(i).Cells("sucursal").Value
                m1 = DGrid.Rows(i).Cells("marca").Value
                e1 = DGrid.Rows(i).Cells("estilon").Value
                For j As Integer = 0 To objDataSetResmin.Tables(0).Rows.Count - 1
                    s2 = ""
                    m2 = ""
                    e2 = ""
                    s2 = objDataSetResmin.Tables(0).Rows(j).Item("sucursal").ToString
                    m2 = objDataSetResmin.Tables(0).Rows(j).Item("marca").ToString
                    e2 = objDataSetResmin.Tables(0).Rows(j).Item("estilon").ToString
                    If s1 = s2 And m1 = m2 And e1 = e2 Then
                        DGrid.Rows(i).Visible = False
                        If blnMedidas = False Then
                            If i - 1 = 0 Then
                                DGrid.CurrentCell = Nothing
                            End If
                            DGrid.Rows(i - 1).Visible = False
                            blnMedidas = True
                        End If
                    End If
                Next
            Next
            Dim nn As Integer = 16
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub RellenaGrid()
        'mreyes 08/Marzo/2016   06:37 p.m.
        Using objRegistro As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)

            Try
                Me.Cursor = Cursors.WaitCursor
                DGrid.ReadOnly = False
                DGrid.DataSource = Nothing

                ''''''''''''''''''
                FechaInib = DT_FecIni.Value.ToString("yyyy-MM-dd")
                FechaFinb = DT_FecFin.Value.ToString("yyyy-MM-dd")
                DGrid.Visible = False


                If Intervalo = "L" And Mid(MedMin, 1, 1) <> "0" Then
                    objDataSet = objRegistro.usp_TraerAnalisisModeloLetras(Txt_Marca.Text, Txt_Modelo.Text, FechaInib, FechaFinb)
                Else
                    If Chk_ConCeros.Checked = True Then
                        If Chk_Plaza.Checked = False Then
                            objDataSet = objRegistro.usp_TraerAnalisisModelo(Txt_Marca.Text, Txt_Modelo.Text, FechaInib, FechaFinb)
                        Else
                            objDataSet = objRegistro.usp_TraerAnalisisModeloplaza(Txt_Marca.Text, Txt_Modelo.Text, FechaInib, FechaFinb)
                        End If
                    Else
                        objDataSet = objRegistro.usp_TraerAnalisisModeloSinCeros(Txt_Marca.Text, Txt_Modelo.Text, FechaInib, FechaFinb)

                    End If
                End If

                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section

                    DGrid.DataSource = objDataSet.Tables(0)

                    InicializaGrid()

                    'LimpiarBusqueda()
                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True

                Else


                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron movimientos.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False

                End If
                Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()
                Call ColorearGrid()
                DGrid.Visible = True
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using


    End Sub

    Private Sub InicializaGrid()
        Try

            Dim Inicio As Integer
            Dim Fin As Integer
            Dim Sw_EmpiezaMedios As Boolean = False
            Dim Sw_TerminaMedios As Boolean = False


            DGrid.RowHeadersVisible = False
            DGrid.Columns(3).HeaderText = "01"
            DGrid.Columns(4).HeaderText = "01-"
            DGrid.Columns(5).HeaderText = "02"
            DGrid.Columns(6).HeaderText = "02-"
            DGrid.Columns(7).HeaderText = "03"
            DGrid.Columns(8).HeaderText = "03-"
            DGrid.Columns(9).HeaderText = "04"
            DGrid.Columns(10).HeaderText = "04-"
            DGrid.Columns(11).HeaderText = "05"
            DGrid.Columns(12).HeaderText = "05-"
            DGrid.Columns(13).HeaderText = "06"
            DGrid.Columns(14).HeaderText = "06-"
            DGrid.Columns(15).HeaderText = "07"
            DGrid.Columns(16).HeaderText = "07-"
            DGrid.Columns(17).HeaderText = "08"
            DGrid.Columns(18).HeaderText = "08-"
            DGrid.Columns(19).HeaderText = "09"
            DGrid.Columns(20).HeaderText = "09-"
            DGrid.Columns(21).HeaderText = "10"
            DGrid.Columns(22).HeaderText = "10-"


            DGrid.Columns(23).HeaderText = "11"
            DGrid.Columns(24).HeaderText = "11-"
            DGrid.Columns(25).HeaderText = "12"
            DGrid.Columns(26).HeaderText = "12-"
            DGrid.Columns(27).HeaderText = "13"
            DGrid.Columns(28).HeaderText = "13-"
            DGrid.Columns(29).HeaderText = "14"
            DGrid.Columns(30).HeaderText = "14-"
            DGrid.Columns(31).HeaderText = "15"
            DGrid.Columns(32).HeaderText = "15-"
            DGrid.Columns(33).HeaderText = "16"
            DGrid.Columns(34).HeaderText = "16-"
            DGrid.Columns(35).HeaderText = "17"
            DGrid.Columns(36).HeaderText = "17-"
            DGrid.Columns(37).HeaderText = "18"
            DGrid.Columns(38).HeaderText = "18-"
            DGrid.Columns(39).HeaderText = "19"
            DGrid.Columns(40).HeaderText = "19-"
            DGrid.Columns(41).HeaderText = "20"
            DGrid.Columns(42).HeaderText = "20-"


            DGrid.Columns(43).HeaderText = "21"
            DGrid.Columns(44).HeaderText = "21-"
            DGrid.Columns(45).HeaderText = "22"
            DGrid.Columns(46).HeaderText = "22-"
            DGrid.Columns(47).HeaderText = "23"
            DGrid.Columns(48).HeaderText = "23-"
            DGrid.Columns(49).HeaderText = "24"
            DGrid.Columns(50).HeaderText = "24-"
            DGrid.Columns(51).HeaderText = "25"
            DGrid.Columns(52).HeaderText = "25-"
            DGrid.Columns(53).HeaderText = "26"
            DGrid.Columns(54).HeaderText = "26-"
            DGrid.Columns(55).HeaderText = "27"
            DGrid.Columns(56).HeaderText = "27-"
            DGrid.Columns(57).HeaderText = "28"
            DGrid.Columns(58).HeaderText = "28-"
            DGrid.Columns(59).HeaderText = "29"
            DGrid.Columns(60).HeaderText = "29-"
            DGrid.Columns(61).HeaderText = "30"
            DGrid.Columns(62).HeaderText = "30-"

            DGrid.Columns(63).HeaderText = "31"
            DGrid.Columns(64).HeaderText = "31-"
            DGrid.Columns(65).HeaderText = "32"
            DGrid.Columns(66).HeaderText = "32-"
            DGrid.Columns(67).HeaderText = "33"
            DGrid.Columns(68).HeaderText = "33-"
            DGrid.Columns(69).HeaderText = "34"
            DGrid.Columns(70).HeaderText = "34-"
            DGrid.Columns(71).HeaderText = "35"
            DGrid.Columns(72).HeaderText = "35-"
            DGrid.Columns(73).HeaderText = "36"
            DGrid.Columns(74).HeaderText = "36-"
            DGrid.Columns(75).HeaderText = "37"
            DGrid.Columns(76).HeaderText = "37-"
            DGrid.Columns(77).HeaderText = "38"
            DGrid.Columns(78).HeaderText = "38-"
            DGrid.Columns(79).HeaderText = "39"
            DGrid.Columns(80).HeaderText = "39-"
            DGrid.Columns(81).HeaderText = "40"
            DGrid.Columns(82).HeaderText = "40-"


            DGrid.Columns(83).HeaderText = "41"
            DGrid.Columns(84).HeaderText = "41-"
            DGrid.Columns(85).HeaderText = "42"
            DGrid.Columns(86).HeaderText = "42-"
            DGrid.Columns(87).HeaderText = "43"
            DGrid.Columns(88).HeaderText = "43-"
            DGrid.Columns(89).HeaderText = "44"
            DGrid.Columns(90).HeaderText = "44-"
            DGrid.Columns(91).HeaderText = "45"
            DGrid.Columns(92).HeaderText = "45-"
            DGrid.Columns(93).HeaderText = "46"
            DGrid.Columns(94).HeaderText = "46-"
            DGrid.Columns(95).HeaderText = "47"
            DGrid.Columns(96).HeaderText = "47-"
            DGrid.Columns(97).HeaderText = "48"
            DGrid.Columns(98).HeaderText = "48-"
            DGrid.Columns(99).HeaderText = "49"
            DGrid.Columns(100).HeaderText = "49-"
            DGrid.Columns(101).HeaderText = "50"
            DGrid.Columns(102).HeaderText = "50-"



            If Intervalo = "L" And Mid(MedMin, 1, 1) <> "0" Then

                DGrid.Columns(3).HeaderText = "CH"
                DGrid.Columns(4).HeaderText = "CH_"
                DGrid.Columns(4).Visible = False

                DGrid.Columns(5).HeaderText = "MED"
                DGrid.Columns(6).HeaderText = "MED_"
                DGrid.Columns(6).Visible = False
                DGrid.Columns(7).HeaderText = "GDE"
                DGrid.Columns(8).HeaderText = "GDE_"
                DGrid.Columns(8).Visible = False
                DGrid.Columns(9).HeaderText = "XCH"
                DGrid.Columns(10).HeaderText = "XCH_"
                DGrid.Columns(10).Visible = False
                DGrid.Columns(11).HeaderText = "XGE"
                DGrid.Columns(12).HeaderText = "XGE_"
                DGrid.Columns(12).Visible = False
                DGrid.Columns(13).HeaderText = "XX3"
                DGrid.Columns(14).HeaderText = "XX3_"
                DGrid.Columns(14).Visible = False
                DGrid.Columns(15).HeaderText = "XX4"
                DGrid.Columns(16).HeaderText = "XX4_"
                DGrid.Columns(16).Visible = False
                DGrid.Columns(17).HeaderText = "XX5"
                DGrid.Columns(18).HeaderText = "XX5_"
                DGrid.Columns(18).Visible = False
                DGrid.Columns(19).HeaderText = "XXG"
                DGrid.Columns(20).HeaderText = "XXG_"
                DGrid.Columns(20).Visible = False
                DGrid.Columns(21).HeaderText = "XXX"
                DGrid.Columns(22).HeaderText = "XXX_"
                DGrid.Columns(22).Visible = False

                For i As Integer = 22 To DGrid.ColumnCount - 2
                    DGrid.Columns(i).Visible = False

                Next


                DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


                DGrid.Columns(DGrid.ColumnCount - 1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            Else

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

                Inicio = (Inicio + 1) * 2
                If Sw_EmpiezaMedios = True Then
                    Inicio = Inicio - 1
                Else
                    Inicio = Inicio - 1
                End If
                Fin = (Fin + 1) * 2

                For i As Integer = 3 To DGrid.ColumnCount - 2
                    DGrid.Columns(i).Visible = False

                Next


                For i As Integer = Inicio To Fin

                    DGrid.Columns(i).Visible = True
                    If Intervalo = "1" Then
                        If InStr(DGrid.Columns(i).HeaderText, "-") > 0 Then
                            DGrid.Columns(i).Visible = False
                        End If
                    End If
                    DGrid.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Next
                DGrid.Columns(DGrid.ColumnCount - 1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            End If
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
    Private Sub Colores()
        Try
            DGrid.Visible = False
            Dim periodo As Integer = 0
            Dim TipoNom As String = ""
            Dim color1 As System.Drawing.Color
            color1 = Color.SandyBrown

            For J As Integer = 0 To DGrid.RowCount - 1
                If DGrid.Rows(J).Cells("concepto").Value = "VENTA" Then
                    If periodo <> Val(DGrid.Rows(J).Cells("idperiodo").Value) Then
                        If J <> 0 Then
                            If color1 = Color.Salmon Then
                                color1 = Color.SandyBrown
                            Else
                                color1 = Color.Salmon
                            End If
                            DGrid.Rows(J).DefaultCellStyle.BackColor = color1
                        Else
                            color1 = Color.SandyBrown
                            DGrid.Rows(J).DefaultCellStyle.BackColor = color1
                        End If
                        periodo = DGrid.Rows(J).Cells("idperiodo").Value
                    Else

                        DGrid.Rows(J).DefaultCellStyle.BackColor = color1
                        periodo = DGrid.Rows(J).Cells("idperiodo").Value
                    End If
                End If

            Next
            DGrid.Visible = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Public Sub RellenarCorridasAna()
        For i As Integer = 0 To DGrid.Rows.Count - 1
            If IsDBNull(DGrid.Rows(i).Cells("Estilon").Value) Then
                Continue For
            End If
            For j As Integer = 5 To DGrid.Columns.Count - 5
                If Not (IsDBNull(DGrid.Rows(i).Cells(j).Value)) Then
                    DGrid.Columns(j).Visible = True
                    'DGrid.Rows(i).Cells(j).Style.BackColor = Color.Yellow
                    If DGrid.Rows(i).Cells(j).Value = 0 Then
                        DGrid.Rows(i).Cells(j).Value = ""
                    End If
                End If
            Next
        Next
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
        DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        ''DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DGrid.Columns.Add(colImagen)
        DGrid.Columns("selec").Visible = False


    End Sub

    Public Sub ColorearGrid()
        Try
            DGrid.Visible = False

            Dim Col1 As Color
            Col1 = Color.LimeGreen
            Dim Col2 As Color
            Col2 = Color.Gold
            Dim Col3 As Color
            Col3 = Color.SkyBlue
            Dim Col4 As Color
            Col4 = Color.Plum
            Dim Col5 As Color
            If DGrid.DataSource Is Nothing Then Exit Sub
            For i As Integer = 0 To DGrid.Rows.Count - 1
                For j As Integer = 5 To DGrid.Columns.Count - 1
                    If DGrid.Columns(j).Visible = True Then
                        If DGrid.Rows(i).Cells(j).Value = "0" Then

                            If DGrid.Rows(i).Cells("Concepto").Value.ToString.Trim = "VENTA" Then

                                Col5 = Col1
                            ElseIf DGrid.Rows(i).Cells("Concepto").Value.ToString.Trim = "EXISTENCIA" Then
                                Col5 = Col2
                            ElseIf DGrid.Rows(i).Cells("Concepto").Value.ToString.Trim = "COMPRAS" Then
                                Col5 = Col3
                            ElseIf DGrid.Rows(i).Cells("Concepto").Value.ToString.Trim = "PEDIDO PENDIENTE" Then
                                Col5 = Col4
                            ElseIf DGrid.Rows(i).Cells("Concepto").Value.ToString.Trim = "NEGRO" Then
                                Col5 = Color.Black
                            Else
                                Col5 = Color.White
                            End If

                            DGrid.Rows(i).Cells(j).Style.ForeColor = Col5 ' DGrid.Rows(i).DefaultCellStyle.BackColor
                        End If


                    End If

                Next
                If DGrid.Rows(i).Cells("Concepto").Value.ToString.Trim = "VENTA" Then
                    DGrid.Rows(i).DefaultCellStyle.BackColor = Col1
                    
                    Continue For
                End If
                If DGrid.Rows(i).Cells("Concepto").Value.ToString.Trim = "EXISTENCIA" Then
                    DGrid.Rows(i).DefaultCellStyle.BackColor = Col2
                    Continue For
                End If
                If DGrid.Rows(i).Cells("Concepto").Value.ToString.Trim = "COMPRAS" Then
                    DGrid.Rows(i).DefaultCellStyle.BackColor = Col3
                    Continue For
                End If
                If DGrid.Rows(i).Cells("Concepto").Value.ToString.Trim = "PEDIDO PENDIENTE" Then
                    DGrid.Rows(i).DefaultCellStyle.BackColor = Col4
                    Continue For
                End If

                If DGrid.Rows(i).Cells("Concepto").Value.ToString.Trim = "NEGRO" Then
                    DGrid.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                    DGrid.Rows(i).DefaultCellStyle.BackColor = Color.Black

                    Continue For
                End If

               
            Next

           

            DGrid.Visible = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
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



    Private Sub Txt_Estilof_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Estilof.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub Txt_Estilof_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Estilof.LostFocus
        Call Txt_Modelo_LostFocus(sender, e)
    End Sub

    Private Sub Txt_Estilof_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Estilof.TextChanged

    End Sub

    Private Sub DGrid2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub Chk_ConCeros_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_ConCeros.CheckedChanged
        Txt_Estilof.Text = ""
        ' Call Txt_Modelo_LostFocus(sender, e)
    End Sub

    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub

    Private Sub Txt_Modelo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Modelo.TextChanged

    End Sub

    Private Sub DGrid2_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid2.CellContentClick

    End Sub

    Private Sub Chk_Plaza_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_Plaza.CheckedChanged
        Txt_Estilof.Text = ""
        Call Txt_Modelo_LostFocus(sender, e)
    End Sub

    Private Sub Pnl_Gral_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Gral.Paint

    End Sub


    Private Function usp_BorrarAnaModArticulo() As Boolean
        'mreyes 16/Agosto/2016  04:57 p.m.

        Using objCalculo As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
            Try
                'Get the specific project selected in the ListView controlsu
                Dim Marca As String = ""
                Application.DoEvents()



                usp_BorrarAnaModArticulo = objCalculo.usp_GeneraAnaModArticulo(2, Marca, "", "", "", "", "", "", "", "", "", "", "", GLB_Idempleado)

                Application.DoEvents()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function
    Private Sub Btn_Filtro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        Dim myForm As New frmFiltrosTraspasosAutomaticos


        myForm.Sw_Consulta = True
        myForm.WindowState = FormWindowState.Normal

        myForm.StartPosition = FormStartPosition.CenterScreen


        myForm.ShowDialog()

        objDataSetModelos = myForm.objDataSetModelos1.Copy
        sw_consulta = True

        intPosicion = myForm.intposicion
        intTotalRows = myForm.inttotalrows
        Txt_Marca.Text = myForm.Marca
        Txt_Modelo.Text = myForm.Modelo

        '        Lbl_Totales.Text = intPosicion & " de " & intTotalRows




        If Txt_Modelo.Text.Length > 0 Then
            Call Txt_Modelo_LostFocus(sender, e)
            Exit Sub
        End If


    End Sub

    Private Sub Pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub

    Private Sub PBox_Click(sender As Object, e As EventArgs) Handles PBox.Click

    End Sub

    Private Sub Txt_Marca_TextChanged(sender As Object, e As EventArgs) Handles Txt_Marca.TextChanged

    End Sub
End Class
