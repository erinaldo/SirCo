Imports System.Text.RegularExpressions

Public Class frmCatalogoExistenciasTienda

    'mreyes 23/Febrero/2012 02:23 p.m. 
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

    Private Sub frmCatalogoEstilos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'FechaInib = Format(Now.Add(New TimeSpan(-90, 0, 0, 0)), "yyyyMMdd")
            'FechaFinb = Format(Now.Date, "yyyyMMdd")

            FechaInib = Format(Now.Add(New TimeSpan(-90, 0, 0, 0)), "yyyy-MM-dd")
            FechaFinb = Format(Now.Date, "yyyy-MM-dd")

            PeriodoIni = Format(Now.Add(New TimeSpan(-90, 0, 0, 0)), "yyyy-MM-dd")
            PeriodoFin = Format(Now.Date, "yyyy-MM-dd")

            DT_FecIni.Value = PeriodoIni
            DT_FecFin.Value = PeriodoFin

            Lbl_Periodo.Text = "Periodo " & " " & CDate(PeriodoIni).ToString("dd/MMM/yyyy").ToUpper & " - " & CDate(PeriodoFin).ToString("dd/MMM/yyyy").ToUpper

            If GLB_CveSucursal <> "11" Then
                Using objCatalogoEst As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                    objDataSetModelos = objCatalogoEst.usp_TraerModelosMarca(-1, "")
                End Using

                If objDataSetModelos.Tables(0).Rows.Count > 0 Then
                    intPosicion = 0
                    intTotalRows = objDataSetModelos.Tables(0).Rows.Count - 1
                End If
            Else
                Label5.Visible = False
                Lbl_Periodo.Visible = False
                Btn_ModAnterior.Visible = False
                Btn_ModSiguiente.Visible = False
            End If
            Txt_Marca.Select()
            Call GenerarToolTip()
            Call Edicion()

            'blnEsPrimero = False

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub InicializaGrid2()
        Try



            DGrid3.RowHeadersVisible = False
            'DGrid.Columns(0).HeaderText = "Det"
            'DGrid.Columns(1).HeaderText = "Marca"
            'DGrid.Columns(2).HeaderText = "Modelo"
            'DGrid.Columns(3).HeaderText = "Estilo"
            'DGrid.Columns(4).HeaderText = "Concepto"
            DGrid3.Columns(0).Frozen = True

            DGrid3.Columns("Costo").DefaultCellStyle.Format = "c"
            DGrid3.Columns("venta").DefaultCellStyle.Format = "c"
            DGrid3.Columns("preciero").DefaultCellStyle.Format = "c"
            DGrid3.Columns("contado").DefaultCellStyle.Format = "c"
            DGrid3.Columns("credito").DefaultCellStyle.Format = "c"
            DGrid3.Columns("margen1").DefaultCellStyle.Format = "0#.#0"
            DGrid3.Columns("margen2").DefaultCellStyle.Format = "0#.#0"

            If GLB_CveSucursal = "11" Then
                DGrid3.Columns("credito").Visible = False
                DGrid3.Columns("CONTADO").Visible = False
            End If
            DGrid3.Columns("venta").Visible = False
            DGrid3.Columns("prov").Visible = False
            DGrid3.Columns("costo").Visible = False
            DGrid3.Columns("margen1").Visible = False
            DGrid3.Columns("margen2").Visible = False
            DGrid3.Columns("final").Visible = False


            DGrid3.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid3.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid3.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid3.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid3.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid3.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid3.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid3.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


            DGrid3.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid3.Columns(1).Visible = False
            DGrid3.Columns(2).Visible = False
            DGrid3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub TraerCostoPrecio()
        Try
            Dim objDataSetAux As DataSet
            Dim Dsctos As Integer = 0
            Dim precdesc As String = ""

           

            'trae las diferentes corridas del modelo
            Using objCorrida As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                objDataSetAux = objCorrida.usp_TraerPrecios(1, IIf(GLB_CveSucursal = "11", "11", "99"), Txt_Marca.Text, Txt_Modelo.Text)
            End Using
            Dim Corridas As String = ""


            'Puede ver los costos de modelo
            'If GLB_Sw_Costos = True Then

            If objDataSetAux.Tables(0).Rows.Count > 0 Then
                'Populate the Project Details section 

                DGrid3.DataSource = objDataSetAux.Tables(0)
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



            'For i As Integer = 0 To DGrid2.RowCount - 1
            '    If DGrid3.Rows(i).Cells(0).Value = "TORREÓN" Then
            '        DGrid3.Rows(i).DefaultCellStyle.BackColor = Color.Bisque
            '    Else
            '        DGrid3.Rows(i).DefaultCellStyle.BackColor = Color.Beige
            '    End If

            'Next

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Buscar_Coincidencia( _
         ByVal pattern As String, _
         ByVal RichTextBox As RichTextBox, _
         ByVal cColor As Color, _
         ByVal BackColor As Color)


        Dim Resultados As MatchCollection
        Dim Palabra As Match

        Try
            ' PAsar el pattern e indicar que ignore las mayúsculas y minúsculas al mosmento de buscar  
            Dim obj_Expresion As New Regex(pattern.ToString, RegexOptions.IgnoreCase)

            ' Ejecutar el método Matches para buscar la cadena en el texto del control  
            ' y retornar un MatchCollection con los resultados  
            Resultados = obj_Expresion.Matches(RichTextBox.Text)

            ' quitar el coloreado anterior  
            With RichTextBox
                .SelectAll()
                .SelectionColor = Color.Black
            End With

            ' Si se encontraron coincidencias recorre las colección    
            For Each Palabra In Resultados
                With RichTextBox
                    .SelectionStart = Palabra.Index ' comienzo de la selección  
                    .SelectionLength = Palabra.Length ' longitud de la cadena a seleccionar  
                    .SelectionColor = cColor ' color de la selección  
                    .SelectionBackColor = BackColor
                    Debug.Print(Palabra.Value)
                End With
            Next Palabra

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

    End Sub




    'Private Sub usp_TraerCostoPrecioModelo()
    '    Try
    '        Using objCatalogoEstilos As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
    '            objDataSet = objCatalogoEstilos.usp_TraerCostoPrecioModelo(Txt_Marca.Text, Txt_Modelo.Text)
    '            If objDataSet.Tables(0).Rows.Count > 0 Then

    '                If GLB_Sw_Costos = True Then
    '                    Lbl_Costo.Visible = True
    '                    Lbl_Costo.Text = Format(Val(objDataSet.Tables(0).Rows(0).Item("costo").ToString), "$###,##0.00")
    '                End If

    '                Lbl_Precio.Visible = True
    '                Lbl_Precio.Text = Format(Val(objDataSet.Tables(0).Rows(0).Item("precio").ToString), "$###,##0.00")

    '                If Not IsDBNull(objDataSet.Tables(0).Rows(0).Item("precdesc")) Then
    '                    Lbl_Descto.Text = Format(Val(objDataSet.Tables(0).Rows(0).Item("precdesc").ToString), "$###,##0.00")
    '                    Lbl_PD.Visible = True
    '                    Lbl_Descto.Visible = True
    '                    Lbl_PD.BackColor = Color.Yellow
    '                    Lbl_Descto.BackColor = Color.Yellow
    '                Else
    '                    Lbl_PD.Visible = False
    '                    Lbl_Descto.Visible = False
    '                End If
    '            End If
    '        End Using
    '    Catch ExceptionErr As Exception
    '        MessageBox.Show(ExceptionErr.Message.ToString)
    '    End Try
    'End Sub

    Private Sub RellendaGridExistencias()
        'Try
        '    Dim Sucursal As String


        '    If GLB_CveSucursal < "20" Then
        '        Sucursal = GLB_CveSucursal
        '    Else
        '        Sucursal = ""
        '    End If
        '    If DGrid.Rows.Count >= 1 Then
        '        ' DGrid.Columns.Clear()
        '        DGrid.Rows.Clear()
        '        DGrid.Columns.Remove("Total")
        '        'DGrid.Rows.Add()

        '        For i As Integer = 2 To DGrid.Columns.Count - 1
        '            DGrid.Columns(i).Visible = False
        '        Next
        '    End If

        '    Using objCatalogoEstilos As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
        '        objDataSet = objCatalogoEstilos.usp_TraerExistenciaEstilos2(Sucursal, Txt_Marca.Text, Txt_Modelo.Text, "")
        '    End Using

        '    If objDataSet.Tables(0).Rows.Count > 0 Then
        '        Dim blnColor = False

        '        For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
        '            DGrid.Rows.Add()
        '            DGrid.Rows(i).Cells(0).Value = "EXISTENCIAS"
        '            DGrid.Rows(i).Cells(1).Value = objDataSet.Tables(0).Rows(i).Item("descrip").ToString

        '            Dim intContador As Integer = 2
        '            For j As Integer = 4 To objDataSet.Tables(0).Columns.Count - 1
        '                DGrid.Rows(i).Cells(intContador).Value = objDataSet.Tables(0).Rows(i).Item(j).ToString
        '                intContador += 1
        '            Next


        '            '' ''If blnColor = False Then
        '            '' ''    DGrid2.Rows(i).DefaultCellStyle.BackColor = Color.Khaki
        '            '' ''    blnColor = True
        '            '' ''    color = color.Khaki
        '            '' ''Else
        '            '' ''    DGrid2.Rows(i).DefaultCellStyle.BackColor = Color.PeachPuff
        '            '' ''    blnColor = False
        '            '' ''    color = color.PeachPuff
        '            '' ''End If


        '            '' ''For n As Integer = 2 To objDataSet.Tables(0).Columns.Count - 3
        '            '' ''    If DGrid2.Rows(i).Cells(n).Value = 0 Then
        '            '' ''        DGrid2.Rows(i).Cells(n).Style.ForeColor = color
        '            '' ''    End If
        '            '' ''Next

        '            'For n As Integer = 0 To DGrid2.Columns.Count - 1

        '            'Next

        '        Next
        '    Else
        '        DGrid.Rows.Add()
        '        DGrid.Rows(0).Cells(0).Value = "SIN EXISTENCIAS"
        '        ''''  DGrid2.Rows(0).DefaultCellStyle.BackColor = Color.Khaki
        '    End If

        '    DGrid.Rows.Add()
        '    DGrid.Rows(DGrid.Rows.Count - 1).Cells(0).Value = ""
        '    '''' DGrid2.Rows(DGrid2.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Aqua

        '    Dim colImagen As DataGridViewColumn = New DataGridViewColumn()
        '    colImagen.Name = "Total"
        '    colImagen.HeaderText = "Total"
        '    colImagen.DisplayIndex = 202
        '    colImagen.ReadOnly = True
        '    colImagen.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        '    colImagen.CellTemplate = New DataGridViewTextBoxCell
        '    colImagen.Visible = True
        '    ' añadir columna de imagen a la coleccion del grid 
        '    ''DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
        '    Me.DGrid.Columns.Add(colImagen)

        '    For i As Integer = 0 To DGrid.Rows.Count - 2
        '        Dim Total As Integer = 0
        '        For j As Integer = 2 To 101
        '            Total += CInt(DGrid.Rows(i).Cells(j).Value)
        '        Next
        '        DGrid.Rows(i).Cells("Total").Value = Total
        '        DGrid.Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        '        DGrid.Columns("Tipo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        '        DGrid.Columns("Concepto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        '    Next

        '    Dim TotalS As Integer = 0
        '    Dim NomSuc As String = ""

        '    If GLB_CveSucursal = "01" Then
        '        NomSuc = "JUAREZ"
        '    ElseIf GLB_CveSucursal = "02" Then
        '        NomSuc = "HIDALGO"
        '    ElseIf GLB_CveSucursal = "06" Then
        '        NomSuc = "TRIANA"
        '    ElseIf GLB_CveSucursal = "07" Then
        '        NomSuc = "LERDO"
        '    ElseIf GLB_CveSucursal = "08" Then
        '        NomSuc = "MATRIZ"
        '    ElseIf GLB_CveSucursal = "11" Then
        '        NomSuc = "MONTERREY"
        '    End If


        '    If GLB_CveSucursal = "01" Or GLB_CveSucursal = "02" Or GLB_CveSucursal = "06" Or GLB_CveSucursal = "07" Or GLB_CveSucursal = "08" Or GLB_CveSucursal = "11" Then
        '        For j As Integer = 0 To DGrid.Rows.Count - 2
        '            If DGrid.Rows(j).Cells("Tipo").Value Is Nothing Then
        '                DGrid.Rows(j).Cells("Tipo").Value = ""
        '            End If
        '            If DGrid.Rows(j).Cells("Tipo").Value.ToString = NomSuc Then
        '                TotalS = TotalS + DGrid.Rows(j).Cells("Total").Value
        '            End If
        '        Next
        '    Else
        '        For j As Integer = 0 To DGrid.Rows.Count - 1
        '            'For k As Integer = DGrid.Columns.Count - 1 To DGrid.Columns.Count - 1
        '            TotalS = TotalS + DGrid.Rows(j).Cells("Total").Value
        '            'Next
        '        Next
        '    End If



        '    Lbl_TotalS.Text = "Total: " + TotalS.ToString + " series activas"
        '    Lbl_TotalS.Visible = True

        '    Call RellenarCorridas(0)

        'Catch ExceptionErr As Exception
        '    MessageBox.Show(ExceptionErr.Message.ToString)
        'End Try
    End Sub

    Private Sub RellendaGridVentas()
        Dim Sucursal As String = ""

        Try

            If GLB_CveSucursal = "01" Or GLB_CveSucursal = "02" Or GLB_CveSucursal = "06" Or GLB_CveSucursal = "07" Or GLB_CveSucursal = "08" Or GLB_CveSucursal = "11" Then
                Sucursal = GLB_CveSucursal
            End If

            Using objCatalogoEstilos As New BCL.BCLCatalogoModelos(GLB_ConStringDWH)
                objDataSet = objCatalogoEstilos.usp_TraerVentasModeloMed(Sucursal, Txt_IdArticulo.Text, FechaInib, FechaFinb)
            End Using

            'DGrid2.Rows.Add()
            'DGrid2.Rows(0).Cells(0).Value = "EXISTENCIAS"
            'DGrid2.Rows(0).DefaultCellStyle.BackColor = Color.Khaki
            If objDataSet.Tables(0).Rows.Count > 0 Then

                Dim blnColor = False

                For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                    DGrid.Rows.Add()
                    DGrid.Rows(DGrid.Rows.Count - 1).Cells(0).Value = "VENTAS"
                    DGrid.Rows(DGrid.Rows.Count - 1).Cells(1).Value = objDataSet.Tables(0).Rows(i).Item("descrip").ToString


                    Dim intContador As Integer = 2
                    For j As Integer = 4 To objDataSet.Tables(0).Columns.Count - 1
                        DGrid.Rows(DGrid.Rows.Count - 1).Cells(intContador).Value = objDataSet.Tables(0).Rows(i).Item(j).ToString
                        intContador += 1
                    Next

                    '' ''If blnColor = False Then
                    '' ''    DGrid2.Rows(DGrid2.Rows.Count - 1).DefaultCellStyle.BackColor = color.Khaki
                    '' ''    blnColor = True
                    '' ''    color = color.Khaki
                    '' ''Else
                    '' ''    DGrid2.Rows(DGrid2.Rows.Count - 1).DefaultCellStyle.BackColor = color.PeachPuff
                    '' ''    blnColor = False
                    '' ''    color = color.Khaki
                    '' ''End If

                    '' ''For n As Integer = 2 To objDataSet.Tables(0).Columns.Count - 3
                    '' ''    If DGrid2.Rows(DGrid2.Rows.Count - 1).Cells(n).Value = 0 Then
                    '' ''        DGrid2.Rows(DGrid2.Rows.Count - 1).Cells(n).Style.ForeColor = color
                    '' ''    End If
                    '' ''Next
                Next

            Else
                DGrid.Rows.Add()
                DGrid.Rows(DGrid.Rows.Count - 1).Cells(0).Value = "SIN VENTAS"
                'DGrid2.Rows(DGrid2.Rows.Count - 1).DefaultCellStyle.BackColor = color.Khaki
            End If

            'Dim colImagen As DataGridViewColumn = New DataGridViewColumn()
            'colImagen.Name = "Total"
            'colImagen.HeaderText = "Total"
            'colImagen.DisplayIndex = 202
            'colImagen.ReadOnly = True
            'colImagen.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            'colImagen.CellTemplate = New DataGridViewTextBoxCell
            'colImagen.Visible = True
            '' añadir columna de imagen a la coleccion del grid 
            ' ''DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
            'Me.DGrid2.Columns.Add(colImagen)
            If objDataSet.Tables(0).Rows.Count > 0 Then
                For i As Integer = DGrid.Rows.Count - objDataSet.Tables(0).Rows.Count To DGrid.Rows.Count - 1
                    Dim Total As Integer = 0
                    For j As Integer = 2 To 101
                        Total += CInt(DGrid.Rows(i).Cells(j).Value)
                    Next
                    DGrid.Rows(i).Cells("Total").Value = Total
                    DGrid.Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns("Tipo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns("Concepto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Next
            Else
                For i As Integer = DGrid.Rows.Count - 1 To DGrid.Rows.Count - 1
                    Dim Total As Integer = 0
                    For j As Integer = 2 To 101
                        Total += CInt(DGrid.Rows(i).Cells(j).Value)
                    Next
                    DGrid.Rows(i).Cells("Total").Value = Total
                    DGrid.Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns("Tipo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns("Concepto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Next
            End If


            'Call RellenarCorridas2(0)

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Public Sub RellenarCorridas(ByVal Renglon As Integer)
        Dim Marca1 As String = Txt_Marca.Text.Trim
        Dim Estilon1 As String = Txt_Modelo.Text
        Dim MedIni As Integer = 0
        Dim MedFin As Integer = 0
        Dim MI As String = ""
        Dim MF As String = ""
        Dim Intervalo As String = ""
        Dim Inc As Integer = 0
        Using objCorrida As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
            objDataSet = objCorrida.usp_TraerCorrida(Marca1, Estilon1, "", "")
        End Using
        If objDataSet.Tables(0).Rows.Count > 0 Then
            For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                'If IsDBNull(objDataSet.Tables(0).Rows(i).Item("medini")) Then
                '    Continue For
                'End If
                If objDataSet.Tables(0).Rows(i).Item("medini").ToString.Trim = "CH" Or
                    objDataSet.Tables(0).Rows(i).Item("medini").ToString.Trim = "MED" Or
                    objDataSet.Tables(0).Rows(i).Item("medini").ToString.Trim = "GDE" Or
                    objDataSet.Tables(0).Rows(i).Item("medini").ToString.Trim = "XGE" Or
                    objDataSet.Tables(0).Rows(i).Item("medini").ToString.Trim = "XXG" Or
                    objDataSet.Tables(0).Rows(i).Item("medfin").ToString.Trim = "27E" Then
                    Continue For
                End If


                MedIni = Val(objDataSet.Tables(0).Rows(i).Item("medini").ToString)
                MedFin = Val(objDataSet.Tables(0).Rows(i).Item("medfin").ToString)
                MI = objDataSet.Tables(0).Rows(i).Item("medini").ToString
                MF = objDataSet.Tables(0).Rows(i).Item("medfin").ToString

                Intervalo = objDataSet.Tables(0).Rows(i).Item("intervalo").ToString


                For MedIni = Val(objDataSet.Tables(0).Rows(i).Item("medini").ToString) To MedFin
                    Dim NombreColumna As String

                    If Intervalo <> "-" Then
                        If Intervalo = CStr(1) Then
                            Inc = Intervalo
                        Else
                            Inc = 1
                        End If
                    Else
                        Inc = 1
                    End If


                    If MedIni = Val(MI) Then
                        If MI.Substring(MI.Length - 1, 1) <> "-" Then
                            NombreColumna = TraerNombreColumna(MedIni.ToString)
                            DGrid.Columns(NombreColumna).Visible = True
                        End If
                    Else
                        NombreColumna = TraerNombreColumna(MedIni.ToString)
                        DGrid.Columns(NombreColumna).Visible = True

                    End If
                    If Intervalo = "-" Then
                        If MF = CStr(MedIni) Then
                            'If MedFin.Substring(MedFin.Length - 1, 1) = "-" Then
                            '    Call Inserta_Medida("N", pub_RellenarIzquierda(MI, 2) + Intervalo, I)
                            'End If
                        Else
                            NombreColumna = TraerNombreColumna(MedIni.ToString + "-")
                            DGrid.Columns(NombreColumna).Visible = True
                        End If
                    End If
                    MedIni = MedIni + Inc - 1

                Next



            Next
        End If
    End Sub

    Public Function TraerNombreColumna(ByVal Medida As String) As String
        If Medida = "1" Then
            Return "M1"
        ElseIf Medida = "1-" Then
            Return "M1_"
        ElseIf Medida = "2" Then
            Return "M2"
        ElseIf Medida = "2-" Then
            Return "M2_"
        ElseIf Medida = "3" Then
            Return "M3"
        ElseIf Medida = "3-" Then
            Return "M3_"
        ElseIf Medida = "4" Then
            Return "M4"
        ElseIf Medida = "4-" Then
            Return "M4_"
        ElseIf Medida = "5" Then
            Return "M5"
        ElseIf Medida = "5-" Then
            Return "M5_"
        ElseIf Medida = "6" Then
            Return "M6"
        ElseIf Medida = "6-" Then
            Return "M6_"
        ElseIf Medida = "7" Then
            Return "M7"
        ElseIf Medida = "7-" Then
            Return "M7_"
        ElseIf Medida = "8" Then
            Return "M8"
        ElseIf Medida = "8-" Then
            Return "M8_"
        ElseIf Medida = "9" Then
            Return "M9"
        ElseIf Medida = "9-" Then
            Return "M9_"
        ElseIf Medida = "10" Then
            Return "M10"
        ElseIf Medida = "10-" Then
            Return "M10_"
        ElseIf Medida = "11" Then
            Return "M11"
        ElseIf Medida = "11-" Then
            Return "M11_"
        ElseIf Medida = "12" Then
            Return "M12"
        ElseIf Medida = "12-" Then
            Return "M12_"
        ElseIf Medida = "13" Then
            Return "M13"
        ElseIf Medida = "13-" Then
            Return "M13_"
        ElseIf Medida = "14" Then
            Return "M14"
        ElseIf Medida = "14-" Then
            Return "M14_"
        ElseIf Medida = "15" Then
            Return "M15"
        ElseIf Medida = "15-" Then
            Return "M15_"
        ElseIf Medida = "16" Then
            Return "M16"
        ElseIf Medida = "16-" Then
            Return "M16_"
        ElseIf Medida = "17" Then
            Return "M17"
        ElseIf Medida = "17-" Then
            Return "M17_"
        ElseIf Medida = "18" Then
            Return "M18"
        ElseIf Medida = "18-" Then
            Return "M18_"
        ElseIf Medida = "19" Then
            Return "M19"
        ElseIf Medida = "19-" Then
            Return "M19_"
        ElseIf Medida = "20" Then
            Return "M20"
        ElseIf Medida = "20-" Then
            Return "M20_"
        ElseIf Medida = "21" Then
            Return "M21"
        ElseIf Medida = "21-" Then
            Return "M21_"
        ElseIf Medida = "22" Then
            Return "M22"
        ElseIf Medida = "22-" Then
            Return "M22_"
        ElseIf Medida = "23" Then
            Return "M23"
        ElseIf Medida = "23-" Then
            Return "M23_"
        ElseIf Medida = "24" Then
            Return "M24"
        ElseIf Medida = "24-" Then
            Return "M24_"
        ElseIf Medida = "25" Then
            Return "M25"
        ElseIf Medida = "25-" Then
            Return "M25_"
        ElseIf Medida = "26" Then
            Return "M26"
        ElseIf Medida = "26-" Then
            Return "M26_"
        ElseIf Medida = "27" Then
            Return "M27"
        ElseIf Medida = "27-" Then
            Return "M27_"
        ElseIf Medida = "28" Then
            Return "M28"
        ElseIf Medida = "28-" Then
            Return "M28_"
        ElseIf Medida = "29" Then
            Return "M29"
        ElseIf Medida = "29-" Then
            Return "M29_"
        ElseIf Medida = "30" Then
            Return "M30"
        ElseIf Medida = "30-" Then
            Return "M30_"
        ElseIf Medida = "31" Then
            Return "M31"
        ElseIf Medida = "31-" Then
            Return "M31_"
        ElseIf Medida = "32" Then
            Return "M32"
        ElseIf Medida = "32-" Then
            Return "M32_"
        ElseIf Medida = "33" Then
            Return "M33"
        ElseIf Medida = "33-" Then
            Return "M33_"
        ElseIf Medida = "34" Then
            Return "M34"
        ElseIf Medida = "34-" Then
            Return "M34_"
        ElseIf Medida = "35" Then
            Return "M35"
        ElseIf Medida = "35-" Then
            Return "M35_"
        ElseIf Medida = "36" Then
            Return "M36"
        ElseIf Medida = "36-" Then
            Return "M36_"
        ElseIf Medida = "37" Then
            Return "M37"
        ElseIf Medida = "37-" Then
            Return "M37_"
        ElseIf Medida = "38" Then
            Return "M38"
        ElseIf Medida = "38-" Then
            Return "M38_"
        ElseIf Medida = "39" Then
            Return "M39"
        ElseIf Medida = "39-" Then
            Return "M39_"
        ElseIf Medida = "40" Then
            Return "M40"
        ElseIf Medida = "40-" Then
            Return "M40_"
        ElseIf Medida = "41" Then
            Return "M41"
        ElseIf Medida = "41-" Then
            Return "M41_"
        ElseIf Medida = "42" Then
            Return "M42"
        ElseIf Medida = "42-" Then
            Return "M42_"
        ElseIf Medida = "43" Then
            Return "M43"
        ElseIf Medida = "43-" Then
            Return "M43_"
        ElseIf Medida = "44" Then
            Return "M44"
        ElseIf Medida = "44-" Then
            Return "M44_"
        ElseIf Medida = "45" Then
            Return "M45"
        ElseIf Medida = "45-" Then
            Return "M45_"
        ElseIf Medida = "46" Then
            Return "M46"
        ElseIf Medida = "46-" Then
            Return "M46_"
        ElseIf Medida = "47" Then
            Return "M47"
        ElseIf Medida = "47-" Then
            Return "M47_"
        ElseIf Medida = "48" Then
            Return "M48"
        ElseIf Medida = "48-" Then
            Return "M48_"
        ElseIf Medida = "49" Then
            Return "M49"
        ElseIf Medida = "49-" Then
            Return "M49_"
        ElseIf Medida = "50" Then
            Return "M50"
        ElseIf Medida = "50-" Then
            Return "M50_"
        Else
            Return "Tipo"
        End If
    End Function

    Private Sub usp_TraerModelo()
        Using objCatalogoEstilos As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
            Try

                objDataSet = objCatalogoEstilos.usp_TraerModelo(Val(Txt_IdArticulo.Text), Txt_Marca.Text, Txt_Modelo.Text, "",
                                                               0, 0, 0, 0, 0, "")

                'objDataSet = objCatalogoEstilos.usp_TraerModelo(Val(Txt_IdArticulo.Text), Txt_Marca.Text, Txt_Modelo.Text, Txt_Estilof.Text, _
                '                                                Val(Txt_Depto.Text), Txt_Familia.Text, Txt_Linea.Text, Txt_SubLinea.Text, Txt_SSubLinea.Text, Txt_TipoArt.Text, "")

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_Marca.Text = objDataSet.Tables(0).Rows(0).Item("marca").ToString
                    Txt_DescripMarca.Text = objDataSet.Tables(0).Rows(0).Item("descripmarca").ToString
                    Txt_Modelo.Text = objDataSet.Tables(0).Rows(0).Item("modelo").ToString
                    Txt_Estilof.Text = objDataSet.Tables(0).Rows(0).Item("estilof").ToString
                    Txt_Descripc.Text = objDataSet.Tables(0).Rows(0).Item("descripc").ToString
                    Txt_Proveedor.Text = objDataSet.Tables(0).Rows(0).Item("proveedor").ToString
                    Txt_Raz_Soc.Text = objDataSet.Tables(0).Rows(0).Item("raz_soc").ToString

                End If

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub usp_TraerEstructura()
        Using objCatalogoEstilos As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
            Try
                objDataSet = objCatalogoEstilos.usp_TraerEstructura(Val(Txt_IdArticulo.Text), Txt_Marca.Text, Txt_Modelo.Text)

                If objDataSet.Tables(0).Rows.Count > 0 Then


                    Lbl_Estructura.Text = objDataSet.Tables(0).Rows(0).Item("descripdivision").ToString & " \ " &
                    objDataSet.Tables(0).Rows(0).Item("descripdepto").ToString & " \ " &
                    objDataSet.Tables(0).Rows(0).Item("descripfamilia").ToString & " \ " &
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

                    Btn_ModAnterior.Visible = False
                    Btn_ModSiguiente.Visible = False


                Case 2
                    Me.Text = "Consulta de Ventas y Existencias por Modelo"
                    Txt_Marca.Enabled = True
                    Txt_Modelo.Enabled = True
                    Txt_Marca.ReadOnly = False
                    Txt_Modelo.ReadOnly = False


                    'Lbl_Costo.Text = ""
                    'Lbl_Precio.Text = ""

                    'Lbl_PD.Visible = False
                    'Lbl_Descto.Visible = False

                    If GLB_CveSucursal <> "11" Then
                        Btn_ModAnterior.Visible = True
                        Btn_ModSiguiente.Visible = True
                    End If

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

    'Private Sub Cbo_Periodo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cbo_Periodo.SelectedValueChanged
    '    Try
    '        If blnEsPrimero = True Then Exit Sub
    '        If Cbo_Periodo.Text = "90 DIAS" Then
    '            FechaInib = Format(Now.Add(New TimeSpan(-90, 0, 0, 0)), "yyyyMMdd")
    '            FechaFinb = Format(Now.Date, "yyyyMMdd")
    '            PeriodoIni = Format(Now.Add(New TimeSpan(-90, 0, 0, 0)), "yyyy-MM-dd")
    '            PeriodoFin = Format(Now.Date, "yyyy-MM-dd")

    '            Lbl_Periodo.Text = "Periodo " & " " & CDate(PeriodoIni).ToString("dd/MMM/yyyy").ToUpper & " - " & CDate(PeriodoFin).ToString("dd/MMM/yyyy").ToUpper

    '            Call RellendaGridVentas()

    '        ElseIf Cbo_Periodo.Text = "60 DIAS" Then
    '            FechaInib = Format(Now.Add(New TimeSpan(-60, 0, 0, 0)), "yyyyMMdd")
    '            FechaFinb = Format(Now.Date, "yyyyMMdd")
    '            PeriodoIni = Format(Now.Add(New TimeSpan(-60, 0, 0, 0)), "yyyy-MM-dd")
    '            PeriodoFin = Format(Now.Date, "yyyy-MM-dd")

    '            Lbl_Periodo.Text = "Periodo " & " " & CDate(PeriodoIni).ToString("dd/MMM/yyyy").ToUpper & " - " & CDate(PeriodoFin).ToString("dd/MMM/yyyy").ToUpper

    '            Call RellendaGridVentas()
    '        ElseIf Cbo_Periodo.Text = "30 DIAS" Then
    '            FechaInib = Format(Now.Add(New TimeSpan(-30, 0, 0, 0)), "yyyyMMdd")
    '            FechaFinb = Format(Now.Date, "yyyyMMdd")
    '            PeriodoIni = Format(Now.Add(New TimeSpan(-30, 0, 0, 0)), "yyyy-MM-dd")
    '            PeriodoFin = Format(Now.Date, "yyyy-MM-dd")

    '            Lbl_Periodo.Text = "Periodo " & " " & CDate(PeriodoIni).ToString("dd/MMM/yyyy").ToUpper & " - " & CDate(PeriodoFin).ToString("dd/MMM/yyyy").ToUpper

    '            Call RellendaGridVentas()
    '        End If
    '    Catch ExceptionErr As Exception
    '        MessageBox.Show(ExceptionErr.Message.ToString)
    '    End Try
    'End Sub

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        Try
            'FechaInib = DT_FecIni.Value.ToString("yyyyMMdd")
            'FechaFinb = DT_FecFin.Value.ToString("yyyyMMdd")
            FechaInib = DT_FecIni.Value.ToString("yyyy-MM-dd")
            FechaFinb = DT_FecFin.Value.ToString("yyyy-MM-dd")
            PeriodoIni = DT_FecIni.Value
            PeriodoFin = DT_FecFin.Value
            Lbl_Periodo.Text = "Periodo " & " " & CDate(PeriodoIni).ToString("dd/MMM/yyyy").ToUpper & " - " & CDate(PeriodoFin).ToString("dd/MMM/yyyy").ToUpper

            If Txt_Marca.Text.Length = 3 AndAlso Txt_Descripc.Text <> "" Then
                Call RellenaGrid()
                'Call RellendaGridVentas()
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

                Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotosLocal, Txt_Marca.Text, Txt_Modelo.Text, NoFoto)

                If objIO.pub_ExisteArchivo(Archivo) = True Then
                    PBox.Image = New System.Drawing.Bitmap(Archivo)
                    Exit Sub
                End If

                For i As Integer = 0 To 9

                    Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotosLocal, Txt_Marca.Text, Txt_Modelo.Text, i)
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

                If GLB_CveSucursal <> "11" Then
                    PBox.Image = SIRCO.My.Resources.ZAPATERIA_TORREON
                Else
                    PBox.Image = Nothing
                End If
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
            'Obtiene el id del articulo 
            If Txt_Marca.Text = "" Then Exit Sub

            'If Txt_Modelo.Text = "" And Txt_Estilof.Text = "" Then
            '    Txt_Modelo.Focus()
            '    Exit Sub
            'End If

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
                objDataSet = objCatalogoEst.usp_TraerModelo(Val(Txt_IdArticulo.Text), Txt_Marca.Text, Txt_Modelo.Text, Txt_Estilof.Text,
                                                               0, 0, 0, 0, 0, "")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_IdArticulo.Text = objDataSet.Tables(0).Rows(0).Item("idarticulo")

                    Intervalo = objDataSet.Tables(0).Rows(0).Item("intervalo").ToString
                    Txt_Marca.Text = objDataSet.Tables(0).Rows(0).Item("marca").ToString
                    Txt_DescripMarca.Text = objDataSet.Tables(0).Rows(0).Item("descripmarca").ToString
                    Txt_Modelo.Text = objDataSet.Tables(0).Rows(0).Item("modelo").ToString
                    Txt_Estilof.Text = objDataSet.Tables(0).Rows(0).Item("estilof").ToString
                    Txt_Descripc.Text = objDataSet.Tables(0).Rows(0).Item("descripc").ToString
                    Txt_Proveedor.Text = objDataSet.Tables(0).Rows(0).Item("proveedor").ToString
                    Txt_Raz_Soc.Text = objDataSet.Tables(0).Rows(0).Item("raz_soc").ToString
                    Txt_IdArticulo.Text = objDataSet.Tables(0).Rows(0).Item("idarticulo")



                    Lbl_Estructura.Text = objDataSet.Tables(0).Rows(0).Item("descripdivision").ToString & " \ " &
                   objDataSet.Tables(0).Rows(0).Item("descripdepto").ToString & " \ " &
                   objDataSet.Tables(0).Rows(0).Item("descripfamilia").ToString & " \ " &
                   objDataSet.Tables(0).Rows(0).Item("descriplinea").ToString '& " \ " & _

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

                    'Call usp_TraerModelo()
                    'Call usp_TraerEstructura()
                    'Call usp_TraerFechaUltVenta()
                    'Call usp_TraerFechaUltReciboEstilo()
                    Call TraerCostoPrecio()
                    'Call usp_TraerCostoPrecioModelo()
                    Call CargarFotoArticulo()
                    DGrid.Visible = False
                    Call RellendaGridExistencias()
                    'If GLB_CveSucursal <> "11" Then
                    '    Call RellendaGridVentas()
                    'End If
                    Call RellenaGrid()
                    DGrid.Visible = True
                    Txt_Marca.Enabled = False
                    Txt_Modelo.Enabled = False


                    ''Using objCatalogoEstilos As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                    'objDataSetModelos = objCatalogoEst.usp_TraerModelosMarca(0, "")
                    ''End Using

                    'If objDataSetModelos.Tables(0).Rows.Count > 0 Then
                    '    intPosicion = 0
                    '    intTotalRows = objDataSetModelos.Tables(0).Rows.Count - 1
                    'End If

                    'Using objCatalogoEst As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)

                    'End Using

                    If GLB_CveSucursal <> "11" Then

                        objDataSet = objCatalogoEst.usp_TraerIdArticulo(Txt_Marca.Text, Txt_Modelo.Text)
                        If objDataSet.Tables(0).Rows.Count > 0 Then
                            Txt_IdArticulo.Text = objDataSet.Tables(0).Rows(0).Item("idarticulo")
                        End If

                        For i As Integer = 0 To objDataSetModelos.Tables(0).Rows.Count - 1
                            If objDataSet.Tables(0).Rows(0).Item("idarticulo") = objDataSetModelos.Tables(0).Rows(i).Item("idarticulo") Then
                                intPosicion = i
                            End If
                        Next
                    End If
                    Lbl_Periodo.Text = "Periodo " & " " & CDate(PeriodoIni).ToString("dd/MMM/yyyy").ToUpper & " - " & CDate(PeriodoFin).ToString("dd/MMM/yyyy").ToUpper

                    Btn_Limpiar.Select()
                Else
                    MsgBox("El modelo ingresado no existe.", MsgBoxStyle.Exclamation, "Aviso")
                    Txt_Marca.Text = ""
                    Txt_Modelo.Text = ""
                    Txt_DescripMarca.Text = ""
                    Txt_Marca.Select()
                    Lbl_Estructura.Text = ""
                    Lbl_Periodo.Text = ""
                End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub RellenaGrid()
        'mreyes 8 / Marzo / 2016   06:  37 p.m.

        Using objcatalogoestilos As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
            Try
                Me.Cursor = Cursors.WaitCursor
                DGrid.ReadOnly = False
                DGrid.DataSource = Nothing

                '''''''''''''''''
                FechaInib = DT_FecIni.Value.ToString("yyyy-MM-dd")
                FechaFinb = DT_FecFin.Value.ToString("yyyy-MM-dd")


                If GLB_CveSucursal < "20" Then
                    Sucursal = GLB_CveSucursal
                Else
                    Sucursal = ""
                End If


                'objDataSet = objcatalogoestilos.usp_TraerAnalisisModeloLetras(Txt_Marca.Text, Txt_Modelo.Text, FechaInib, FechaFinb)
                objDataSet = objcatalogoestilos.usp_TraerAnalisisModeloLetras(Txt_Marca.Text, Txt_Modelo.Text, FechaInib, FechaFinb)

                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section

                    DGrid.DataSource = objDataSet.Tables(0)
                    InicializaGrid()
                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True
                Else
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron movimientos.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                End If
                Me.Cursor = Cursors.Default
                'LimpiarBusqueda()
                'Call ColorearGrid()
                DGrid.Visible = True

                If DGrid.Columns("Det").HeaderText = "Det" Then
                    DGrid.Columns("Det").HeaderText = "Sucursal"
                End If
                For i As Integer = 0 To DGrid.Rows.Count - 1
                    Dim Total As Integer = 0
                    For j As Integer = 3 To 101 - 1

                        If DGrid.Columns("M50_").HeaderText = "M50_" Then
                            DGrid.Columns("M50_").Visible = False
                        End If
                        If DGrid.Columns("Fecha").HeaderText = "Fecha" Then
                            DGrid.Columns("Fecha").Visible = False
                        End If
                    Next
                Next
                Dim Totals As Integer = 0
                Dim NomSuc As String = ""
                'If DGrid.Rows(1).Cells("Det").Value = "01" Then
                '    DGrid.Rows(1).Cells("Descripcion").Value = "JUAREZ"
                'End If
                'If DGrid.Rows(6).Cells("Det").Value = "02" Then
                '    DGrid.Rows(7).Cells("Descripcion").Value = "HIDALGO"
                'End If
                'If DGrid.Rows(12).Cells("Det").Value = "06" Then
                '    DGrid.Rows(13).Cells("Descripcion").Value = "TRIANA"
                'End If
                'If DGrid.Rows(18).Cells("Det").Value = "08" Then
                '    DGrid.Rows(19).Cells("Descripcion").Value = "MATRIZ"
                'End If
                'If DGrid.Rows(24).Cells("Det").Value = "15" Then
                '    DGrid.Rows(24).Cells("Descripcion").Value = "CEDIS"
                'End If




                For u As Integer = 0 To 6 - 1
                    For o As Integer = 3 To 12 - 1
                        Dim Total As Integer = 0
                        Total += CInt(DGrid.Rows(u).Cells(o).Value)
                        If DGrid.Rows(u).Cells("Concepto").Value = "VENTA" Or DGrid.Rows(u).Cells("Concepto").Value = "COMPRAS" Or DGrid.Rows(u).Cells("Concepto").Value = "PEDIDO PENDIENTE" Or DGrid.Rows(u).Cells("Concepto").Value = "TRASPASOS X RECIBIR" Or DGrid.Rows(u).Cells("Concepto").Value = "NEGRO" Then
                            DGrid.Rows.RemoveAt(u)
                        End If
                    Next
                Next
                If GLB_CveSucursal = "01" Then
                    NomSuc = "JUAREZ"
                ElseIf GLB_CveSucursal = "02" Then
                    NomSuc = "HIDALGO"
                ElseIf GLB_CveSucursal = "06" Then
                    NomSuc = "TRIANA"
                ElseIf GLB_CveSucursal = "07" Then
                    NomSuc = "LERDO"
                ElseIf GLB_CveSucursal = "08" Then
                    NomSuc = "MATRIZ"
                ElseIf GLB_CveSucursal = "11" Then
                    NomSuc = "MERCADO LIBRE"
                End If

                If GLB_CveSucursal = "01" Or GLB_CveSucursal = "02" Or GLB_CveSucursal = "06" Or GLB_CveSucursal = "07" Or GLB_CveSucursal = "08" Or GLB_CveSucursal = "11" Then
                    'For j As Integer = 0 To DGrid.Rows.Count - 2
                    '    'If DGrid.Rows(j).Cells("Tipo").Value Is Nothing Then
                    '    '    DGrid.Rows(j).Cells("Tipo").Value = ""
                    '    'End If
                    '    'If DGrid.Rows(j).Cells("Tipo").Value.ToString = NomSuc Then
                    '    '    TotalS = TotalS + DGrid.Rows(j).Cells("Total").Value
                    '    'End If
                    'Next
                Else
                For j As Integer = 0 To DGrid.Rows.Count - 1
                        'For k As Integer = DGrid.Columns.Count - 1 To DGrid.Columns.Count - 1
                        TotalS = TotalS + DGrid.Rows(j).Cells("Total").Value
                        'Next
                    Next
                End If

                Lbl_TotalS.Text = "Total: " + TotalS.ToString + " series activas"
                Lbl_TotalS.Visible = True

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
                'DGrid.Columns(23).HeaderText = "XXG"
                'DGrid.Columns(24).HeaderText = "XXG_"
                'DGrid.Columns(24).Visible = False


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
                    'empieza en medios.
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
                    Call RellenarCorridas(i)
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
            If DGrid3.Rows.Count >= 1 Then
                DGrid3.DataSource = Nothing
                DGrid3.Columns.Clear()
                DGrid3.Rows.Clear()
                Sucursal = ""
            End If



            If DGrid.Rows.Count >= 1 Then
                ' DGrid.Columns.Clear()
                DGrid.Rows.Clear()
                DGrid.Columns.Remove("Total")
                'DGrid.Rows.Add()

                For i As Integer = 2 To DGrid.Columns.Count - 1
                    DGrid.Columns(i).Visible = False
                Next
            End If

            Txt_Marca.Text = ""
            Txt_Modelo.Text = ""
            Txt_IdArticulo.Text = ""
            Txt_Estilof.Text = ""
            Txt_Proveedor.Text = ""
            Txt_DescripMarca.Text = ""
            Txt_Raz_Soc.Text = ""
            Txt_Descripc.Text = ""
            Lbl_Periodo.Text = ""
            Lbl_Estructura.Text = ""

            Lbl_TotalS.Text = ""

            Txt_Marca.Enabled = True
            Txt_Modelo.Enabled = True

            'Lbl_Costo.Visible = False
            'Lbl_Precio.Visible = False
            'Lbl_PD.Visible = False
            'Lbl_Descto.Visible = False

            PBox.Image = Nothing

            Txt_Marca.Select()
        Catch ex As Exception

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
            If GLB_CveSucursal = "01" Or GLB_CveSucursal = "02" Or GLB_CveSucursal = "06" Or GLB_CveSucursal = "07" Or GLB_CveSucursal = "08" Or GLB_CveSucursal = "11" Or GLB_CveSucursal = "15" Then
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
            Txt_IdArticulo.Text = "0"
            If intPosicion <> 0 Then
                intPosicion -= 1
                If intPosicion = 0 Then
                    intPosicion = objDataSetModelos.Tables(0).Rows.Count - 1
                End If
            ElseIf intPosicion = 0 Then
                intPosicion = objDataSetModelos.Tables(0).Rows.Count - 1
            End If

            Txt_Marca.Text = objDataSetModelos.Tables(0).Rows(intPosicion).Item("marca").ToString
            Txt_Modelo.Text = objDataSetModelos.Tables(0).Rows(intPosicion).Item("modelo").ToString

            Txt_Marca_LostFocus(sender, e)
            Txt_Modelo_LostFocus(sender, e)

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_ModSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ModSiguiente.Click
        Try
            Txt_IdArticulo.Text = "0"
            If intPosicion = intTotalRows Then
                intPosicion = 0
            Else
                intPosicion += 1
            End If

            Txt_Marca.Text = objDataSetModelos.Tables(0).Rows(intPosicion).Item("marca").ToString
            Txt_Modelo.Text = objDataSetModelos.Tables(0).Rows(intPosicion).Item("modelo").ToString

            Txt_Marca_LostFocus(sender, e)
            Txt_Modelo_LostFocus(sender, e)
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
                Clipboard.SetDataObject(
                    Me.DGrid.GetClipboardContent())

                ' Replace the text box contents with the clipboard text.
                ' Me.TextBox1.Text = Clipboard.GetText()

            Catch ex As System.Runtime.InteropServices.ExternalException

            End Try
        End If
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


    Private Sub Txt_Modelo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Modelo.TextChanged

    End Sub

    Private Sub Txt_Modelo_SystemColorsChanged(sender As Object, e As EventArgs) Handles Txt_Modelo.SystemColorsChanged

    End Sub

    Private Sub DGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub

    Private Sub Txt_Estilof_TextChanged(sender As Object, e As EventArgs) Handles Txt_Estilof.TextChanged

    End Sub

    Private Sub Txt_Estilof_LostFocus(sender As Object, e As EventArgs) Handles Txt_Estilof.LostFocus
        Call Txt_Modelo_LostFocus(sender, e)
    End Sub

    Private Sub Txt_Modelo_MouseWheel(sender As Object, e As MouseEventArgs) Handles Txt_Modelo.MouseWheel

    End Sub

    Private Sub Txt_Marca_TextChanged(sender As Object, e As EventArgs) Handles Txt_Marca.TextChanged

    End Sub

    Private Sub Txt_Estilof_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Estilof.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class
