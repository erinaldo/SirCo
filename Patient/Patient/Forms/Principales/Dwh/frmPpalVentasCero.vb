Public Class frmPpalVentasCero

    Private objDataSet As Data.DataSet
    Public Opcion As Integer = 0
    Public OpcionAntMarca As Integer = 0
    Public Sucursal As String = ""
    Public IdDivision As Integer = 0
    Public IdDepto As Integer = 0
    Private FamiliaDescrip As String = ""
    Private LineaDescrip As String = ""
    Private L1Descrip As String = ""
    Private L2Descrip As String = ""
    Private L3Descrip As String = ""
    Private L4Descrip As String = ""
    Private L5Descrip As String = ""
    Private L6Descrip As String = ""

    Private FechaInicio As String = ""
    Private FechaFin As String = ""
    Private FecRecA As String = ""
    Private FecRecB As String = ""
    Public Marca As String = ""
    Public Modelo As String = ""

    Public CtdIni As Integer = 0
    Public CtdFin As Integer = 0

    Public Division As String = ""
    Public Depto As String = ""
    Public Familia As String = ""
    Public Linea As String = ""
    Public L1 As String = ""
    Public L2 As String = ""
    Public L3 As String = ""
    Public L4 As String = ""
    Public L5 As String = ""
    Public L6 As String = ""

    Dim blnCambio As Boolean = False
    Dim blnCambio1 As Boolean = False

    Dim MarcaFOTO As String = ""
    Dim EstiloNFOTO As String = ""
    Dim DescripSucursal As String = ""
    Dim checkInicio As Boolean = False
    Private izquierda As Integer = 0
    Private alto As Integer = 0
    Dim blnBorroCol As Boolean = False
    Dim myFormFiltros As frmFiltrosVentasDWH
    Public Accion As Integer = 0



    Private arreglo(100) As Integer
    Private intArreglo As Integer = 0

    Dim blnPrimero As Boolean = False
    'Accion 1 = Antiguedad ----- Accion 2 = Inventario

    Private Sub frmPpalNomina_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try

            If GLB_CveSucursal >= "00" AndAlso GLB_CveSucursal < "90" Then
                Sucursal = GLB_CveSucursal
            Else
                Sucursal = ""
            End If


            If blnPrimero = False Then
                If Accion = 0 Then
                    Accion = 1
                    If Opcion = 0 Then
                        Opcion = 1
                        Txt_CtdIni.Text = 0
                        Txt_CtdFin.Text = 0
                    End If
                End If

                If Accion = 2 Then
                    If Opcion = 0 Then
                        Opcion = 1
                        Txt_CtdIni.Text = 1
                        Txt_CtdFin.Text = 5
                    End If
                End If

                CtdIni = Val(Txt_CtdIni.Text)
                CtdFin = Val(Txt_CtdFin.Text)

                If GLB_FechaHoy <> pub_TraerFechaHoy() Then
                    GLB_FechaHoy = pub_TraerFechaHoy()
                End If

                FechaInicio = GLB_FechaHoy.AddDays(-1).ToString("yyyy-MM-dd")
                FechaFin = GLB_FechaHoy.AddDays(-1).ToString("yyyy-MM-dd")
                arreglo(100) = New Integer
                Chk_Calzado.Checked = True
                RB_SinLerdo.Checked = True
                myFormFiltros = New frmFiltrosVentasDWH

                If Accion = 1 Then
                    Using objVentasCero As New BCL.BCLVentasCero(GLB_ConStringCipSis)
                        objDataSet = objVentasCero.usp_TraerFecUltBitacora("EXISTENCIAS")
                        If objDataSet.Tables(0).Rows.Count > 0 Then
                            Lbl_UltMod.Text = "Ultima Modificación: " + Format(objDataSet.Tables(0).Rows(0).Item("ultfecha"), "dd-MMM-yyyy hh:mm:ss tt").ToUpper
                            Lbl_UltMod.Visible = True
                        End If
                    End Using
                End If

            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmPpalProveedores_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then
                Me.Close()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmPpalProveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If blnPrimero = True Then
                If Accion = 0 Then Accion = 1
                If Opcion = 0 Then
                    Opcion = 1
                    Txt_CtdIni.Text = 0
                    Txt_CtdFin.Text = 0
                End If

                If Accion = 2 Then
                    If Opcion = 0 Then
                        Opcion = 1
                        Txt_CtdIni.Text = 1
                        Txt_CtdFin.Text = 5
                    End If
                End If

                CtdIni = Val(Txt_CtdIni.Text)
                CtdFin = Val(Txt_CtdFin.Text)

                If GLB_FechaHoy <> pub_TraerFechaHoy() Then
                    GLB_FechaHoy = pub_TraerFechaHoy()
                End If


                FechaInicio = GLB_FechaHoy.AddDays(-1).ToString("yyyy-MM-dd")
                FechaFin = GLB_FechaHoy.AddDays(-1).ToString("yyyy-MM-dd")
                arreglo(100) = New Integer
                myFormFiltros = New frmFiltrosVentasDWH
                Chk_Calzado.Checked = True
                RB_SinLerdo.Checked = True
                'FechaInicio = "2013-12-08"
                'FechaFin = "2013-12-08"
            End If

            If Accion = 1 Or Accion = 0 Then
                Pnl_Pares.Visible = False
                Btn_Actualizar.Visible = False
            ElseIf Accion = 2 Then
                Pnl_Pares.Visible = True
            End If
            Call GenerarToolTip()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub RellenaGrid()
        Dim blnFinalEst As Boolean = False
        Try
            Me.Cursor = Cursors.WaitCursor
            'If Accion = 1 Then
            If Opcion = 1 Then 'Sucursal

                If RB_SinLerdo.Checked = True Then
                    Using objSucursal As New BCL.BCLVentas(GLB_ConStringDWH)
                        blnCambio = objSucursal.usp_ActualizarSucursal("07", "N")
                    End Using
                End If

                Using objVentasCero As New BCL.BCLVentasCero(GLB_ConStringDWH)
                    objDataSet = objVentasCero.usp_PpalSVentas(Sucursal, FechaInicio, FechaFin, IdDivision, IdDepto, FamiliaDescrip, LineaDescrip, _
                                                               L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, Marca, Modelo, FecRecA, FecRecB, CtdIni, CtdFin)

                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        If Sucursal <> "" Then
                            objDataSet.Tables(0).Rows(0).Item("descripsucursal") = "TOTAL:"
                        End If

                        If Accion = 2 Then
                            If objDataSet.Tables(0).Rows(0).Item("modelos") = 0 Then
                                MessageBox.Show("No se encontró información con los parámetros establecidos.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                        End If
                    End If
                End Using
            ElseIf Opcion = 2 Then 'Division
                Using objVentasCero As New BCL.BCLVentasCero(GLB_ConStringDWH)
                    objDataSet = objVentasCero.usp_PpalSVentasDivisiones(Sucursal, FechaInicio, FechaFin, IdDivision, IdDepto, FamiliaDescrip, LineaDescrip, _
                                                               L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, Marca, Modelo, FecRecA, FecRecB, CtdIni, CtdFin)
                End Using
            ElseIf Opcion = 3 Then 'Departamento
                Using objVentasCero As New BCL.BCLVentasCero(GLB_ConStringDWH)
                    objDataSet = objVentasCero.usp_PpalSVentasDepto(Sucursal, FechaInicio, FechaFin, IdDivision, IdDepto, FamiliaDescrip, LineaDescrip, _
                                                               L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, Marca, Modelo, FecRecA, FecRecB, CtdIni, CtdFin)
                End Using
            ElseIf Opcion = 4 Then 'Familia
                Using objVentasCero As New BCL.BCLVentasCero(GLB_ConStringDWH)
                    objDataSet = objVentasCero.usp_PpalSVentasFamilia(Sucursal, FechaInicio, FechaFin, IdDivision, IdDepto, FamiliaDescrip, LineaDescrip, _
                                                               L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, Marca, Modelo, FecRecA, FecRecB, CtdIni, CtdFin)
                End Using
            ElseIf Opcion = 5 Then 'Linea
                Using objVentasCero As New BCL.BCLVentasCero(GLB_ConStringDWH)
                    objDataSet = objVentasCero.usp_PpalSVentasLinea(Sucursal, FechaInicio, FechaFin, IdDivision, IdDepto, FamiliaDescrip, LineaDescrip, _
                                                               L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, Marca, Modelo, FecRecA, FecRecB, CtdIni, CtdFin)
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        If objDataSet.Tables(0).Rows(0).Item("idlinea") = 0 Then
                            blnFinalEst = True
                        End If
                    End If
                End Using
            ElseIf Opcion = 6 Then 'L1
                Using objVentasCero As New BCL.BCLVentasCero(GLB_ConStringDWH)
                    objDataSet = objVentasCero.usp_PpalSVentasL1(Sucursal, FechaInicio, FechaFin, IdDivision, IdDepto, FamiliaDescrip, LineaDescrip, _
                                                               L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, Marca, Modelo, FecRecA, FecRecB, CtdIni, CtdFin)
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        If objDataSet.Tables(0).Rows(0).Item("idl1") = 0 Then
                            blnFinalEst = True
                        End If
                    End If
                End Using
            ElseIf Opcion = 7 Then 'L2
                Using objVentasCero As New BCL.BCLVentasCero(GLB_ConStringDWH)
                    objDataSet = objVentasCero.usp_PpalSVentasL2(Sucursal, FechaInicio, FechaFin, IdDivision, IdDepto, FamiliaDescrip, LineaDescrip, _
                                                               L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, Marca, Modelo, FecRecA, FecRecB, CtdIni, CtdFin)
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        If objDataSet.Tables(0).Rows(0).Item("idl2") = 0 Then
                            blnFinalEst = True
                        End If
                    End If
                End Using
            ElseIf Opcion = 8 Then 'L3
                Using objVentasCero As New BCL.BCLVentasCero(GLB_ConStringDWH)
                    objDataSet = objVentasCero.usp_PpalSVentasL3(Sucursal, FechaInicio, FechaFin, IdDivision, IdDepto, FamiliaDescrip, LineaDescrip, _
                                                               L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, Marca, Modelo, FecRecA, FecRecB, CtdIni, CtdFin)
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        If objDataSet.Tables(0).Rows(0).Item("idl3") = 0 Then
                            blnFinalEst = True
                        End If
                    End If
                End Using
            ElseIf Opcion = 9 Then 'L4
                Using objVentasCero As New BCL.BCLVentasCero(GLB_ConStringDWH)
                    objDataSet = objVentasCero.usp_PpalSVentasL4(Sucursal, FechaInicio, FechaFin, IdDivision, IdDepto, FamiliaDescrip, LineaDescrip, _
                                                               L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, Marca, Modelo, FecRecA, FecRecB, CtdIni, CtdFin)
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        If objDataSet.Tables(0).Rows(0).Item("idl4") = 0 Then
                            blnFinalEst = True
                        End If
                    End If
                End Using
            ElseIf Opcion = 10 Then 'L5
                Using objVentasCero As New BCL.BCLVentasCero(GLB_ConStringDWH)
                    objDataSet = objVentasCero.usp_PpalSVentasL5(Sucursal, FechaInicio, FechaFin, IdDivision, IdDepto, FamiliaDescrip, LineaDescrip, _
                                                               L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, Marca, Modelo, FecRecA, FecRecB, CtdIni, CtdFin)
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        If objDataSet.Tables(0).Rows(0).Item("idl5") = 0 Then
                            blnFinalEst = True
                        End If
                    End If
                End Using
            ElseIf Opcion = 11 Then 'L6
                Using objVentasCero As New BCL.BCLVentasCero(GLB_ConStringDWH)
                    objDataSet = objVentasCero.usp_PpalSVentasL6(Sucursal, FechaInicio, FechaFin, IdDivision, IdDepto, FamiliaDescrip, LineaDescrip, _
                                                               L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, Marca, Modelo, FecRecA, FecRecB, CtdIni, CtdFin)
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        If objDataSet.Tables(0).Rows(0).Item("idl6") = 0 Then
                            blnFinalEst = True
                        End If
                    End If
                End Using
            ElseIf Opcion = 12 Then 'Marca
                Using objVentasCero As New BCL.BCLVentasCero(GLB_ConStringDWH)
                    objDataSet = objVentasCero.usp_PpalSVentasMarca(Sucursal, FechaInicio, FechaFin, IdDivision, IdDepto, FamiliaDescrip, LineaDescrip, _
                                                               L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, Marca, Modelo, FecRecA, FecRecB, CtdIni, CtdFin)
                End Using
            ElseIf Opcion = 13 Then 'Modelo
                Using objVentasCero As New BCL.BCLVentasCero(GLB_ConStringDWH)
                    objDataSet = objVentasCero.usp_PpalSVentasModelo(Sucursal, FechaInicio, FechaFin, IdDivision, IdDepto, FamiliaDescrip, LineaDescrip, _
                                                               L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, Marca, Modelo, FecRecA, FecRecB, CtdIni, CtdFin)
                End Using
            End If


            If objDataSet.Tables(0).Rows.Count > 0 Then

                If Opcion <> 13 Then
                    DGrid.DataSource = Nothing
                    DGrid.DataSource = objDataSet.Tables(0)
                    If blnFinalEst = True Then
                        Using objVentasCero As New BCL.BCLVentasCero(GLB_ConStringDWH)
                            objDataSet = objVentasCero.usp_PpalSVentasMarca(Sucursal, FechaInicio, FechaFin, IdDivision, IdDepto, FamiliaDescrip, LineaDescrip, _
                                                               L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, Marca, Modelo, FecRecA, FecRecB, CtdIni, CtdFin)
                        End Using
                        Opcion = 12
                        DGrid.DataSource = Nothing
                        DGrid.DataSource = objDataSet.Tables(0)
                    End If

                    InicializaGrid()

                    Me.Cursor = Cursors.Default
                    Lbl_Periodo.Text = "Periodo " & " " & CDate(FechaInicio).ToString("dd/MMM/yyyy").ToUpper & " - " & CDate(FechaFin).ToString("dd/MMM/yyyy").ToUpper
                Else
                    Dim objDataSetAux As New DataSet
                    objDataSetAux = objDataSet.Clone()
                    DGrid.DataSource = Nothing
                    DGrid.DataSource = objDataSetAux.Tables(0)
                    If blnBorroCol = True Then
                        DGrid.Columns.Remove(DGrid.Columns("renglon"))
                    End If
                    blnBorroCol = False
                    InicializaGridModelos()
                    'DGrid.DataSource = Nothing
                    DGrid.DataSource = objDataSet.Tables(0)

                    Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)

                    Dim row As DataRow = dt.NewRow()

                    row("modelo") = " "
                    row("descripc") = "TOTAL: "
                    row("existencia") = pub_SumarColumnaGridNombre(DGrid, "existencia", DGrid.RowCount - 1)

                    dt.Rows.InsertAt(row, 0)

                    For i As Integer = 0 To DGrid.Columns.Count - 4
                        DGrid.Columns(i).DefaultCellStyle.BackColor = Color.PowderBlue
                        DGrid.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        DGrid.Columns(i).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                    Next
                    Me.Cursor = Cursors.Default

                    DGrid.Rows(0).Frozen = True
                    DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
                    DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                    'DGrid.Columns(i).DefaultCellStyle.BackColor = Color.PowderBlue
                    'DGrid.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    'DGrid.Columns(i).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                    Lbl_Periodo.Text = "Periodo " & " " & CDate(FechaInicio).ToString("dd/MMM/yyyy").ToUpper & " - " & CDate(FechaFin).ToString("dd/MMM/yyyy").ToUpper
                End If
                Componentes()
                GeneraTexto()
                OcultarToolStrips()

                If blnCambio = True Then
                    Using objSucursal As New BCL.BCLVentas(GLB_ConStringDWH)
                        blnCambio = objSucursal.usp_ActualizarSucursal("07", "S")
                    End Using
                End If


            Else
                OpcionAntMarca = Opcion
                DGrid.DataSource = Nothing
                Me.Cursor = Cursors.Default
                PBox.Image = Nothing
                PBox.Visible = False
                'Opcion = 12
                'Using objRegistro As New BCL.BCLAntiInvent(GLB_ConStringCipSis)
                '    'objDataSet = objRegistro.usp_PpalInventarioTiendasEstructura(Opcion, Sucursales(), Division, Depto, Familia, Linea, L1, L2, L3, L4, L5, L6, Marca, Modelo)
                'End Using
                'If objDataSet.Tables(0).Rows.Count > 0 Then
                '    DGrid.DataSource = Nothing
                '    DGrid.DataSource = objDataSet.Tables(0)
                '    InicializaGrid()
                '    UltimaModificacion()
                '    Componentes()
                '    GeneraTexto()
                '    OcultarToolStrips()
                'Else
                MessageBox.Show("No se encontró la información solicitada", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'End If
            End If
            'End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub GenerarToolTip()
        Try
            '
            ToolTip.SetToolTip(Btn_Filtro, "Búsqueda Avanzada")
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
            ToolTip.SetToolTip(Btn_Salir, "Salir")
            ToolTip.SetToolTip(Btn_Foto, "Imagen del Producto")
            ToolTip.SetToolTip(Btn_Regresar, "Regresar")
            ToolTip.SetToolTip(Btn_Actualizar, "Actualiza la información en base al rango establecido.")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Public Function pub_SumarColumnaGridNombre(ByVal DGrid As DataGridView, ByVal Columna As String, Optional ByVal HastaRenglon As Integer = 0) As Decimal
        'mreyes 14/Febrero/2012 05:08 p.m.
        Try
            Dim Col As Integer = DGrid.CurrentCell.ColumnIndex

            pub_SumarColumnaGridNombre = 0
            For renglon As Integer = 0 To IIf(HastaRenglon = 0, DGrid.RowCount - 2, HastaRenglon)
                If IsNumeric(DGrid.Rows(renglon).Cells(Columna).Value) Then
                    pub_SumarColumnaGridNombre = (DGrid.Rows(renglon).Cells(Columna).Value) + pub_SumarColumnaGridNombre
                End If
            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Sub InicializaGrid()
        Try
            PBox.Visible = False
            Btn_Foto.Enabled = False
            Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)

            Dim row As DataRow = dt.NewRow()
            If Opcion <> 1 Then
                If Opcion = 2 Then
                    row("divisiones") = "TOTAL: "
                    row("modelos") = pub_SumarColumnaGridNombre(DGrid, "modelos", DGrid.RowCount - 1)
                    row("porcdiv") = pub_SumarColumnaGridNombre(DGrid, "porcdiv", DGrid.RowCount - 1)
                    'row("porcrep") = pub_SumarColumnaGridNombre(DGrid, "porcrep", DGrid.RowCount - 1)
                ElseIf Opcion = 3 Then
                    row("depto") = "TOTAL: "
                    row("modelos") = pub_SumarColumnaGridNombre(DGrid, "modelos", DGrid.RowCount - 1)
                    row("porcdep") = pub_SumarColumnaGridNombre(DGrid, "porcdep", DGrid.RowCount - 1)
                    'row("porcrep") = pub_SumarColumnaGridNombre(DGrid, "porcrep", DGrid.RowCount - 1)
                ElseIf Opcion = 4 Then
                    row("familia") = "TOTAL: "
                    row("modelos") = pub_SumarColumnaGridNombre(DGrid, "modelos", DGrid.RowCount - 1)
                    row("porcfam") = pub_SumarColumnaGridNombre(DGrid, "porcfam", DGrid.RowCount - 1)
                    'row("porcrep") = pub_SumarColumnaGridNombre(DGrid, "porcrep", DGrid.RowCount - 1)
                ElseIf Opcion = 5 Then
                    row("linea") = "TOTAL: "
                    row("modelos") = pub_SumarColumnaGridNombre(DGrid, "modelos", DGrid.RowCount - 1)
                    row("porclin") = pub_SumarColumnaGridNombre(DGrid, "porclin", DGrid.RowCount - 1)
                    row("porcrep") = pub_SumarColumnaGridNombre(DGrid, "porcrep", DGrid.RowCount - 1)
                ElseIf Opcion = 6 Then
                    row("l1") = "TOTAL: "
                    row("modelos") = pub_SumarColumnaGridNombre(DGrid, "modelos", DGrid.RowCount - 1)
                    row("porcl1") = pub_SumarColumnaGridNombre(DGrid, "porcl1", DGrid.RowCount - 1)
                    'row("porcrep") = pub_SumarColumnaGridNombre(DGrid, "porcrep", DGrid.RowCount - 1)
                ElseIf Opcion = 7 Then
                    row("l2") = "TOTAL: "
                    row("modelos") = pub_SumarColumnaGridNombre(DGrid, "modelos", DGrid.RowCount - 1)
                    row("porcl2") = pub_SumarColumnaGridNombre(DGrid, "porcl2", DGrid.RowCount - 1)
                    'row("porcrep") = pub_SumarColumnaGridNombre(DGrid, "porcrep", DGrid.RowCount - 1)
                ElseIf Opcion = 8 Then
                    row("l3") = "TOTAL: "
                    row("modelos") = pub_SumarColumnaGridNombre(DGrid, "modelos", DGrid.RowCount - 1)
                    row("porcl3") = pub_SumarColumnaGridNombre(DGrid, "porcl3", DGrid.RowCount - 1)
                    'row("porcrep") = pub_SumarColumnaGridNombre(DGrid, "porcrep", DGrid.RowCount - 1)
                ElseIf Opcion = 9 Then
                    row("l4") = "TOTAL: "
                    row("modelos") = pub_SumarColumnaGridNombre(DGrid, "modelos", DGrid.RowCount - 1)
                    row("porcl4") = pub_SumarColumnaGridNombre(DGrid, "porcl4", DGrid.RowCount - 1)
                    'row("porcrep") = pub_SumarColumnaGridNombre(DGrid, "porcrep", DGrid.RowCount - 1)
                ElseIf Opcion = 10 Then
                    row("l5") = "TOTAL: "
                    row("modelos") = pub_SumarColumnaGridNombre(DGrid, "modelos", DGrid.RowCount - 1)
                    row("porcl5") = pub_SumarColumnaGridNombre(DGrid, "porcl5", DGrid.RowCount - 1)
                    'row("porcrep") = pub_SumarColumnaGridNombre(DGrid, "porcrep", DGrid.RowCount - 1)
                ElseIf Opcion = 11 Then
                    row("l6") = "TOTAL: "
                    row("modelos") = pub_SumarColumnaGridNombre(DGrid, "modelos", DGrid.RowCount - 1)
                    row("porcl6") = pub_SumarColumnaGridNombre(DGrid, "porcl6", DGrid.RowCount - 1)
                    'row("porcrep") = pub_SumarColumnaGridNombre(DGrid, "porcrep", DGrid.RowCount - 1)
                ElseIf Opcion = 12 Then
                    row("marca") = "TOTAL: "
                    row("modelos") = pub_SumarColumnaGridNombre(DGrid, "modelos", DGrid.RowCount - 1)
                    row("porcmarca") = pub_SumarColumnaGridNombre(DGrid, "porcmarca", DGrid.RowCount - 1)
                    'row("porcrep") = pub_SumarColumnaGridNombre(DGrid, "porcrep", DGrid.RowCount - 1)
                End If


                dt.Rows.InsertAt(row, 0)
            End If


            If Opcion = 1 Then 'Sucursal

                DGrid.DataSource = dt

                DGrid.Columns("descripsucursal").HeaderText = "Sucursal"
                DGrid.Columns("modelos").HeaderText = "Modelos"

                DGrid.Columns("sucursal").Visible = False

            ElseIf Opcion = 2 Then 'Divisiones

                DGrid.DataSource = dt

                DGrid.Columns("divisiones").HeaderText = "Division"
                DGrid.Columns("modelos").HeaderText = "Modelos"
                DGrid.Columns("porcdiv").HeaderText = "  %  "
                DGrid.Columns("porcrep").HeaderText = "  %  Representación"

                DGrid.Columns("porcrep").DefaultCellStyle.Format = "#,##0"
                DGrid.Columns("porcdiv").DefaultCellStyle.Format = "#,##0"
                DGrid.Columns("sucursal").Visible = False
                DGrid.Columns("iddivision").Visible = False

            ElseIf Opcion = 3 Then 'Departamento

                DGrid.DataSource = dt


                DGrid.Columns("depto").HeaderText = "Departamento"
                DGrid.Columns("modelos").HeaderText = "Modelos"
                DGrid.Columns("porcdep").HeaderText = "  %  "
                DGrid.Columns("porcrep").HeaderText = "  %  Representación"

                DGrid.Columns("porcrep").DefaultCellStyle.Format = "#,##0"
                DGrid.Columns("porcdep").DefaultCellStyle.Format = "#,##0"
                DGrid.Columns("sucursal").Visible = False
                DGrid.Columns("iddivision").Visible = False
                DGrid.Columns("divisiones").Visible = False
                DGrid.Columns("iddepto").Visible = False

            ElseIf Opcion = 4 Then 'Familia

                DGrid.DataSource = dt

                DGrid.Columns("familia").HeaderText = "Familia"
                DGrid.Columns("modelos").HeaderText = "Modelos"
                DGrid.Columns("porcfam").HeaderText = "  %  "
                DGrid.Columns("porcrep").HeaderText = "  %  Representación"

                DGrid.Columns("porcrep").DefaultCellStyle.Format = "#,##0"
                DGrid.Columns("porcfam").DefaultCellStyle.Format = "#,##0"
                DGrid.Columns("sucursal").Visible = False
                DGrid.Columns("iddivision").Visible = False
                DGrid.Columns("divisiones").Visible = False
                DGrid.Columns("iddepto").Visible = False
                DGrid.Columns("depto").Visible = False
                DGrid.Columns("idfamilia").Visible = False

            ElseIf Opcion = 5 Then 'Linea

                DGrid.DataSource = dt

                DGrid.Columns("linea").HeaderText = "Linea"
                DGrid.Columns("modelos").HeaderText = "Modelos"
                DGrid.Columns("porclin").HeaderText = "  %  "
                DGrid.Columns("porcrep").HeaderText = "  %  Representación"

                DGrid.Columns("porcrep").DefaultCellStyle.Format = "#,##0"
                DGrid.Columns("porclin").DefaultCellStyle.Format = "#,##0"
                DGrid.Columns("sucursal").Visible = False
                DGrid.Columns("iddivision").Visible = False
                DGrid.Columns("divisiones").Visible = False
                DGrid.Columns("iddepto").Visible = False
                DGrid.Columns("depto").Visible = False
                DGrid.Columns("idfamilia").Visible = False
                DGrid.Columns("familia").Visible = False
                DGrid.Columns("idlinea").Visible = False

            ElseIf Opcion = 6 Then 'L1

                DGrid.DataSource = dt

                DGrid.Columns("l1").HeaderText = "L1"
                DGrid.Columns("modelos").HeaderText = "Modelos"
                DGrid.Columns("porcl1").HeaderText = "  %  "
                DGrid.Columns("porcrep").HeaderText = "  %  Representación"

                DGrid.Columns("porcrep").DefaultCellStyle.Format = "#,##0"
                DGrid.Columns("porcl1").DefaultCellStyle.Format = "#,##0"
                DGrid.Columns("sucursal").Visible = False
                DGrid.Columns("iddivision").Visible = False
                DGrid.Columns("divisiones").Visible = False
                DGrid.Columns("iddepto").Visible = False
                DGrid.Columns("depto").Visible = False
                DGrid.Columns("idfamilia").Visible = False
                DGrid.Columns("familia").Visible = False
                DGrid.Columns("idlinea").Visible = False
                DGrid.Columns("linea").Visible = False
                DGrid.Columns("idl1").Visible = False

            ElseIf Opcion = 7 Then 'L2

                DGrid.DataSource = dt

                DGrid.Columns("l2").HeaderText = "L2"
                DGrid.Columns("modelos").HeaderText = "Modelos"
                DGrid.Columns("porcl2").HeaderText = "  %  "
                DGrid.Columns("porcrep").HeaderText = "  %  Representación"

                DGrid.Columns("porcrep").DefaultCellStyle.Format = "#,##0"
                DGrid.Columns("porcl2").DefaultCellStyle.Format = "#,##0"
                DGrid.Columns("sucursal").Visible = False
                DGrid.Columns("iddivision").Visible = False
                DGrid.Columns("divisiones").Visible = False
                DGrid.Columns("iddepto").Visible = False
                DGrid.Columns("depto").Visible = False
                DGrid.Columns("idfamilia").Visible = False
                DGrid.Columns("familia").Visible = False
                DGrid.Columns("idlinea").Visible = False
                DGrid.Columns("linea").Visible = False
                DGrid.Columns("idl1").Visible = False
                DGrid.Columns("l1").Visible = False
                DGrid.Columns("idl2").Visible = False

            ElseIf Opcion = 8 Then 'L3

                DGrid.DataSource = dt

                DGrid.Columns("l3").HeaderText = "L3"
                DGrid.Columns("modelos").HeaderText = "Modelos"
                DGrid.Columns("porcl3").HeaderText = "  %  "
                DGrid.Columns("porcrep").HeaderText = "  %  Representación"

                DGrid.Columns("porcrep").DefaultCellStyle.Format = "#,##0"
                DGrid.Columns("porcl3").DefaultCellStyle.Format = "#,##0"
                DGrid.Columns("sucursal").Visible = False
                DGrid.Columns("iddivision").Visible = False
                DGrid.Columns("divisiones").Visible = False
                DGrid.Columns("iddepto").Visible = False
                DGrid.Columns("depto").Visible = False
                DGrid.Columns("idfamilia").Visible = False
                DGrid.Columns("familia").Visible = False
                DGrid.Columns("idlinea").Visible = False
                DGrid.Columns("linea").Visible = False
                DGrid.Columns("idl1").Visible = False
                DGrid.Columns("l1").Visible = False
                DGrid.Columns("idl2").Visible = False
                DGrid.Columns("l2").Visible = False
                DGrid.Columns("idl3").Visible = False

            ElseIf Opcion = 9 Then 'L4

                DGrid.DataSource = dt

                DGrid.Columns("l4").HeaderText = "L4"
                DGrid.Columns("modelos").HeaderText = "Modelos"
                DGrid.Columns("porcl4").HeaderText = "  %  "
                DGrid.Columns("porcrep").HeaderText = "  %  Representación"

                DGrid.Columns("porcrep").DefaultCellStyle.Format = "#,##0"
                DGrid.Columns("porcl4").DefaultCellStyle.Format = "#,##0"
                DGrid.Columns("sucursal").Visible = False
                DGrid.Columns("iddivision").Visible = False
                DGrid.Columns("divisiones").Visible = False
                DGrid.Columns("iddepto").Visible = False
                DGrid.Columns("depto").Visible = False
                DGrid.Columns("idfamilia").Visible = False
                DGrid.Columns("familia").Visible = False
                DGrid.Columns("idlinea").Visible = False
                DGrid.Columns("linea").Visible = False
                DGrid.Columns("idl1").Visible = False
                DGrid.Columns("l1").Visible = False
                DGrid.Columns("idl2").Visible = False
                DGrid.Columns("l2").Visible = False
                DGrid.Columns("idl3").Visible = False
                DGrid.Columns("l3").Visible = False
                DGrid.Columns("idl4").Visible = False

            ElseIf Opcion = 10 Then 'L5

                DGrid.DataSource = dt

                DGrid.Columns("l5").HeaderText = "L5"
                DGrid.Columns("modelos").HeaderText = "Modelos"
                DGrid.Columns("porcl5").HeaderText = "  %  "
                DGrid.Columns("porcrep").HeaderText = "  %  Representación"

                DGrid.Columns("porcrep").DefaultCellStyle.Format = "#,##0"
                DGrid.Columns("porcl5").DefaultCellStyle.Format = "#,##0"
                DGrid.Columns("sucursal").Visible = False
                DGrid.Columns("iddivision").Visible = False
                DGrid.Columns("divisiones").Visible = False
                DGrid.Columns("iddepto").Visible = False
                DGrid.Columns("depto").Visible = False
                DGrid.Columns("idfamilia").Visible = False
                DGrid.Columns("familia").Visible = False
                DGrid.Columns("idlinea").Visible = False
                DGrid.Columns("linea").Visible = False
                DGrid.Columns("idl1").Visible = False
                DGrid.Columns("l1").Visible = False
                DGrid.Columns("idl2").Visible = False
                DGrid.Columns("l2").Visible = False
                DGrid.Columns("idl3").Visible = False
                DGrid.Columns("l3").Visible = False
                DGrid.Columns("idl4").Visible = False
                DGrid.Columns("l4").Visible = False
                DGrid.Columns("idl5").Visible = False

            ElseIf Opcion = 11 Then 'L6

                DGrid.DataSource = dt

                DGrid.Columns("l6").HeaderText = "L6"
                DGrid.Columns("modelos").HeaderText = "Modelos"
                DGrid.Columns("porcl6").HeaderText = "  %  "
                DGrid.Columns("porcrep").HeaderText = "  %  Representación"

                DGrid.Columns("porcrep").DefaultCellStyle.Format = "#,##0"
                DGrid.Columns("porcl6").DefaultCellStyle.Format = "#,##0"
                DGrid.Columns("sucursal").Visible = False
                DGrid.Columns("iddivision").Visible = False
                DGrid.Columns("divisiones").Visible = False
                DGrid.Columns("iddepto").Visible = False
                DGrid.Columns("depto").Visible = False
                DGrid.Columns("idfamilia").Visible = False
                DGrid.Columns("familia").Visible = False
                DGrid.Columns("idlinea").Visible = False
                DGrid.Columns("linea").Visible = False
                DGrid.Columns("idl1").Visible = False
                DGrid.Columns("l1").Visible = False
                DGrid.Columns("idl2").Visible = False
                DGrid.Columns("l2").Visible = False
                DGrid.Columns("idl3").Visible = False
                DGrid.Columns("l3").Visible = False
                DGrid.Columns("idl4").Visible = False
                DGrid.Columns("l4").Visible = False
                DGrid.Columns("idl5").Visible = False
                DGrid.Columns("l5").Visible = False
                DGrid.Columns("idl6").Visible = False

            ElseIf Opcion = 12 Then 'Marca

                DGrid.DataSource = dt

                DGrid.Columns("marca").HeaderText = "Marca"
                DGrid.Columns("descripmarca").HeaderText = "Marca"
                DGrid.Columns("modelos").HeaderText = "Modelos"
                DGrid.Columns("porcmarca").HeaderText = "  %  "
                DGrid.Columns("porcrep").HeaderText = "  %  Representación"

                DGrid.Columns("porcrep").DefaultCellStyle.Format = "#,##0"
                DGrid.Columns("porcmarca").DefaultCellStyle.Format = "#,##0"
                DGrid.Columns("marca").Visible = False
            End If

            For i As Integer = 0 To DGrid.ColumnCount - 1
                DGrid.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next

            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            DGrid.Rows(0).Frozen = True
            DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)


            'If Opcion <> 1 Then
            If blnBorroCol = True Then
                DGrid.Columns.Remove(DGrid.Columns("renglon"))
            End If
            blnBorroCol = True
            AgregarColumna()
            For i As Integer = 1 To DGrid.Rows.Count - 2
                DGrid.Rows(i).Cells("Renglon").Value = i.ToString
            Next
            'End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub AgregarColumna()
        Try
            Dim colRenglon As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
            colRenglon.Name = "Renglon"
            colRenglon.HeaderText = "Ren"
            colRenglon.Frozen = True
            colRenglon.DefaultCellStyle.BackColor = Color.PowderBlue
            colRenglon.DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            colRenglon.DisplayIndex = 0
            colRenglon.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            colRenglon.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            colRenglon.CellTemplate = New DataGridViewTextBoxCell

            'colPorcentaje.DefaultCellStyle.Format = "%"
            'colPorcentaje.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

            Me.DGrid.Columns.Add(colRenglon)

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Sub InicializaGridModelos()
        Try
            Btn_Foto.Enabled = True

            DGrid.Columns("Renglon").HeaderText = "Ren"
            DGrid.Columns("marca").HeaderText = "Marca"
            DGrid.Columns("modelo").HeaderText = "Modelo"
            DGrid.Columns("estilof").HeaderText = "Estilo"
            DGrid.Columns("descripc").HeaderText = "Descripción"
            DGrid.Columns("fecreci").HeaderText = "Fec. Ult. Recibo"


            If Accion = 1 Then
                DGrid.Columns("existencia").HeaderText = "Existencia"
            ElseIf Accion = 2 Then
                DGrid.Columns("existencia").HeaderText = "Pares Vendidos"
            End If

            If Accion = 1 Then
                DGrid.Columns("ult_vta").HeaderText = "Fec. Ult. Venta"
                DGrid.Columns("ult_vta").DisplayIndex = 6
            End If


            DGrid.RowHeadersVisible = False
            For i As Integer = 0 To DGrid.ColumnCount - 1
                DGrid.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next

            DGrid.Columns("descripc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick
        Try

            If IsDBNull(DGrid.CurrentRow.Cells(DGrid.Columns.Count - 1).Value) Then
                Exit Sub
            End If

            If Opcion = 1 Then 'sucursal 

                If Sucursal <> "" Then
                    If DGrid.CurrentRow.Cells(1).Value = "TOTAL:" Then

                    Else
                        Sucursal = DGrid.CurrentRow.Cells("sucursal").Value
                        DescripSucursal = DGrid.CurrentRow.Cells("DescripSucursal").Value
                    End If
                Else
                    If DGrid.CurrentRow.Cells(1).Value = "TOTAL CADENA" Then
                        Sucursal = ""
                    Else
                        Sucursal = DGrid.CurrentRow.Cells("sucursal").Value
                        DescripSucursal = DGrid.CurrentRow.Cells("DescripSucursal").Value
                    End If
                End If

                arreglo(intArreglo) = Opcion
                intArreglo += 1
                Opcion = 2
                RellenaGrid()
                Exit Sub
            ElseIf Opcion = 2 Then 'division
                If DGrid.CurrentRow.Cells(2).Value = "TOTAL: " Then
                    IdDivision = IdDivision
                Else
                    IdDivision = DGrid.CurrentRow.Cells("iddivision").Value
                End If
                arreglo(intArreglo) = Opcion
                intArreglo += 1
                Opcion = 3
                RellenaGrid()
                Exit Sub
            ElseIf Opcion = 3 Then 'depto
                If DGrid.CurrentRow.Cells(4).Value = "TOTAL: " Then
                    IdDepto = 0
                Else
                    IdDepto = DGrid.CurrentRow.Cells("iddepto").Value
                End If
                arreglo(intArreglo) = Opcion
                intArreglo += 1
                Opcion = 4
                RellenaGrid()
                Exit Sub
            ElseIf Opcion = 4 Then 'familia
                If DGrid.CurrentRow.Cells(6).Value = "TOTAL: " Then
                    FamiliaDescrip = ""
                Else
                    FamiliaDescrip = DGrid.CurrentRow.Cells("familia").Value
                End If
                arreglo(intArreglo) = Opcion
                intArreglo += 1
                Opcion = 5
                RellenaGrid()
                Exit Sub
            ElseIf Opcion = 5 Then 'linea
                If DGrid.CurrentRow.Cells(8).Value = "TOTAL: " Then
                    LineaDescrip = ""
                Else
                    LineaDescrip = DGrid.CurrentRow.Cells("linea").Value
                End If
                arreglo(intArreglo) = Opcion
                intArreglo += 1
                Opcion = 6
                RellenaGrid()
                Exit Sub
            ElseIf Opcion = 6 Then 'l1
                If DGrid.CurrentRow.Cells(10).Value = "TOTAL: " Then
                    L1Descrip = ""
                Else
                    L1Descrip = DGrid.CurrentRow.Cells("l1").Value
                End If
                arreglo(intArreglo) = Opcion
                intArreglo += 1
                Opcion = 7
                RellenaGrid()
                Exit Sub
            ElseIf Opcion = 7 Then 'l2
                If DGrid.CurrentRow.Cells(12).Value = "TOTAL: " Then
                    L2Descrip = ""
                Else
                    L2Descrip = DGrid.CurrentRow.Cells("l2").Value
                End If
                arreglo(intArreglo) = Opcion
                intArreglo += 1
                Opcion = 8
                RellenaGrid()
                Exit Sub
            ElseIf Opcion = 8 Then 'l3
                If DGrid.CurrentRow.Cells(14).Value = "TOTAL: " Then
                    L3Descrip = ""
                Else
                    L3Descrip = DGrid.CurrentRow.Cells("l3").Value
                End If
                arreglo(intArreglo) = Opcion
                intArreglo += 1
                Opcion = 9
                RellenaGrid()
                Exit Sub
            ElseIf Opcion = 9 Then 'l4
                If DGrid.CurrentRow.Cells(16).Value = "TOTAL: " Then
                    L4Descrip = ""
                Else
                    L4Descrip = DGrid.CurrentRow.Cells("l4").Value
                End If
                arreglo(intArreglo) = Opcion
                intArreglo += 1
                Opcion = 10
                RellenaGrid()
                Exit Sub
            ElseIf Opcion = 10 Then 'l5
                If DGrid.CurrentRow.Cells(18).Value = "TOTAL: " Then
                    L5Descrip = ""
                Else
                    L5Descrip = DGrid.CurrentRow.Cells("l5").Value
                End If
                arreglo(intArreglo) = Opcion
                intArreglo += 1
                Opcion = 11
                RellenaGrid()
                Exit Sub
            ElseIf Opcion = 11 Then 'l6
                If DGrid.CurrentRow.Cells(20).Value = "TOTAL: " Then
                    L6Descrip = ""
                Else
                    L6Descrip = DGrid.CurrentRow.Cells("l6").Value
                End If
                arreglo(intArreglo) = Opcion
                intArreglo += 1
                OpcionAntMarca = Opcion
                Opcion = 12
                RellenaGrid()
                Exit Sub
            ElseIf Opcion = 12 Then
                If DGrid.CurrentRow.Cells(0).Value = "TOTAL: " Then
                    Marca = ""
                Else
                    Marca = DGrid.CurrentRow.Cells("marca").Value
                End If
                arreglo(intArreglo) = Opcion
                intArreglo += 1
                Opcion = 13
                RellenaGrid()
                Exit Sub
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub RB_Activas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_Activas.CheckedChanged
        Try
            If RB_Activas.Checked Then
                Sucursal = ""
                RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub RB_SinLerdo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_SinLerdo.CheckedChanged
        Try
            If RB_SinLerdo.Checked Then

                Using objSucursal As New BCL.BCLVentas(GLB_ConStringDWH)
                    blnCambio = objSucursal.usp_ActualizarSucursal("07", "N")
                End Using

                RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Regresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Regresar.Click
        Try
            If Opcion = 13 Then
                'Opcion = 12
                'Opcion = Opcion - 1

                intArreglo -= 1
                Opcion = arreglo(intArreglo)
                Modelo = ""
                Marca = ""
                RellenaGrid()
                Exit Sub
            ElseIf Opcion = 12 Then
                'Opcion = Opcion - 1
                intArreglo -= 1
                Opcion = arreglo(intArreglo)
                RegresarMarca()
                Marca = ""
                RellenaGrid()
                Exit Sub
            ElseIf Opcion = 11 Then
                'Opcion = 10
                intArreglo -= 1
                Opcion = arreglo(intArreglo)
                L5Descrip = ""
                RellenaGrid()
                Exit Sub
            ElseIf Opcion = 10 Then
                'Opcion = 9
                intArreglo -= 1
                Opcion = arreglo(intArreglo)
                L4Descrip = ""
                RellenaGrid()
                Exit Sub
            ElseIf Opcion = 9 Then
                'Opcion = 8
                intArreglo -= 1
                Opcion = arreglo(intArreglo)
                L3Descrip = ""
                RellenaGrid()
                Exit Sub
            ElseIf Opcion = 8 Then
                'Opcion = 7
                intArreglo -= 1
                Opcion = arreglo(intArreglo)
                L2Descrip = ""
                RellenaGrid()
                Exit Sub
            ElseIf Opcion = 7 Then
                'Opcion = 6
                intArreglo -= 1
                Opcion = arreglo(intArreglo)
                L1Descrip = ""
                RellenaGrid()
                Exit Sub
            ElseIf Opcion = 6 Then
                'Opcion = 5
                intArreglo -= 1
                Opcion = arreglo(intArreglo)
                LineaDescrip = ""
                RellenaGrid()
                Exit Sub
            ElseIf Opcion = 5 Then
                'Opcion = 4
                intArreglo -= 1
                Opcion = arreglo(intArreglo)
                FamiliaDescrip = ""
                RellenaGrid()
                Exit Sub
            ElseIf Opcion = 4 Then
                'Opcion = 3
                intArreglo -= 1
                Opcion = arreglo(intArreglo)
                IdDepto = 0
                RellenaGrid()
                Exit Sub
            ElseIf Opcion = 3 Then
                'Opcion = 2
                'IdDivision = 0
                intArreglo -= 1
                Opcion = arreglo(intArreglo)
                RellenaGrid()
                Exit Sub
            ElseIf Opcion = 2 Then
                'Opcion = 1
                intArreglo -= 1
                Opcion = arreglo(intArreglo)
                Sucursal = ""
                RellenaGrid()
                Exit Sub
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub SucursalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemSucursal.Click
        Try
            ClickDerecho()
            Sucursal = ""
            arreglo(intArreglo) = Opcion
            intArreglo += 1
            Opcion = 1

            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DivisionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemDivision.Click
        Try
            ClickDerecho()
            'IdDivision = 0
            arreglo(intArreglo) = Opcion
            intArreglo += 1
            Opcion = 2

            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DepartamentoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemDepto.Click
        Try
            ClickDerecho()
            IdDepto = 0
            arreglo(intArreglo) = Opcion
            intArreglo += 1
            Opcion = 3

            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub FamiliaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemFamilia.Click
        Try
            ClickDerecho()
            FamiliaDescrip = ""
            arreglo(intArreglo) = Opcion
            intArreglo += 1
            Opcion = 4

            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub LineaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemLinea.Click
        Try
            ClickDerecho()
            LineaDescrip = ""
            arreglo(intArreglo) = Opcion
            intArreglo += 1
            Opcion = 5

            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub L1ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemL1.Click
        Try
            ClickDerecho()
            L1Descrip = ""
            arreglo(intArreglo) = Opcion
            intArreglo += 1
            Opcion = 6

            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub L2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemL2.Click
        Try
            ClickDerecho()
            L2Descrip = ""
            arreglo(intArreglo) = Opcion
            intArreglo += 1
            Opcion = 7

            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub L3ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemL3.Click
        Try
            ClickDerecho()
            L3Descrip = ""
            Opcion = 8
            arreglo(intArreglo) = Opcion
            intArreglo += 1
            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub L4ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemL4.Click
        Try
            ClickDerecho()
            L4Descrip = ""
            arreglo(intArreglo) = Opcion
            intArreglo += 1
            Opcion = 9

            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub L5ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemL5.Click
        Try
            ClickDerecho()
            L5Descrip = ""
            arreglo(intArreglo) = Opcion
            intArreglo += 1
            Opcion = 10

            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub L6ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemL6.Click
        Try
            ClickDerecho()
            L6Descrip = ""
            arreglo(intArreglo) = Opcion
            intArreglo += 1
            Opcion = 11

            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub MarcaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemMarca.Click
        Try
            ClickDerecho()
            Marca = ""

            arreglo(intArreglo) = Opcion
            intArreglo += 1

            Opcion = 12

            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ModeloToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemModelo.Click
        Try
            ClickDerecho()
            Modelo = ""

            arreglo(intArreglo) = Opcion
            intArreglo += 1

            Opcion = 13

            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub InicioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemInicio.Click
        Try
            Sucursal = ""
            IdDivision = 1
            IdDepto = 0
            FamiliaDescrip = ""
            LineaDescrip = ""
            L1Descrip = ""
            L2Descrip = ""
            L3Descrip = ""
            L4Descrip = ""
            L5Descrip = ""
            L6Descrip = ""
            Marca = ""
            Modelo = ""
            'If RB_Activas.Checked Then
            '    Opcion = 1
            '    RellenaGrid()
            'Else
            '    RB_Activas.Checked = True
            'End If

            Opcion = 1
            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub CatModeloToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemCatModelo.Click
        Try
            Dim myForm As New frmCatalogoModelos
            myForm.Txt_Marca.Text = DGrid.CurrentRow.Cells("Marca").Value
            myForm.Txt_Modelo.Text = DGrid.CurrentRow.Cells("Modelo").Value
            myForm.Accion = 4
            myForm.Show()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub AnaModeloToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemAnaModelo.Click
        Try
            Dim myForm As New frmAnalisisModelo
            myForm.Txt_Marca.Text = DGrid.CurrentRow.Cells("Marca").Value
            myForm.Txt_Modelo.Text = DGrid.CurrentRow.Cells("Modelo").Value
            myForm.Accion = 1
            myForm.WindowState = FormWindowState.Maximized
            myForm.Show()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ClickDerecho()

        If Opcion = 1 Then
            If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                Sucursal = ""
            Else
                If DGrid.CurrentRow.Cells("sucursal").Value = "00" Then
                    Sucursal = ""
                    DescripSucursal = "NIVEL CADENA"
                Else
                    Sucursal = DGrid.CurrentRow.Cells("sucursal").Value
                    DescripSucursal = DGrid.CurrentRow.Cells("DescripSucursal").Value
                End If

            End If

        ElseIf Opcion = 2 Then
            If DGrid.CurrentRow.Cells("divisiones").Value = "TOTAL: " Then
                IdDivision = 0
            Else
                Division = DGrid.CurrentRow.Cells("iddivision").Value
            End If

        ElseIf Opcion = 3 Then
            If DGrid.CurrentRow.Cells("depto").Value = "TOTAL: " Then
                IdDepto = 0
            Else
                IdDepto = DGrid.CurrentRow.Cells("iddepto").Value
            End If

        ElseIf Opcion = 4 Then
            If DGrid.CurrentRow.Cells("familia").Value = "TOTAL: " Then
                FamiliaDescrip = ""
            Else
                FamiliaDescrip = DGrid.CurrentRow.Cells("familia").Value
            End If

        ElseIf Opcion = 5 Then
            If DGrid.CurrentRow.Cells("linea").Value = "TOTAL: " Then
                LineaDescrip = ""
            Else
                LineaDescrip = DGrid.CurrentRow.Cells("linea").Value
            End If

        ElseIf Opcion = 6 Then
            If DGrid.CurrentRow.Cells("l1").Value = "TOTAL: " Then
                L1Descrip = ""
            Else
                L1Descrip = DGrid.CurrentRow.Cells("l1").Value
            End If

        ElseIf Opcion = 7 Then
            If DGrid.CurrentRow.Cells("l2").Value = "TOTAL: " Then
                L2Descrip = ""
            Else
                L2Descrip = DGrid.CurrentRow.Cells("l2").Value
            End If

        ElseIf Opcion = 8 Then
            If DGrid.CurrentRow.Cells("l3").Value = "TOTAL: " Then
                L3Descrip = ""
            Else
                L3Descrip = DGrid.CurrentRow.Cells("l3").Value
            End If

        ElseIf Opcion = 9 Then
            If DGrid.CurrentRow.Cells("l4").Value = "TOTAL: " Then
                L4Descrip = ""
            Else
                L4Descrip = DGrid.CurrentRow.Cells("l4").Value
            End If

        ElseIf Opcion = 10 Then
            If DGrid.CurrentRow.Cells("l5").Value = "TOTAL: " Then
                L5Descrip = ""
            Else
                L5Descrip = DGrid.CurrentRow.Cells("l5").Value
            End If

        ElseIf Opcion = 11 Then
            If DGrid.CurrentRow.Cells("l6").Value = "TOTAL: " Then
                L6Descrip = ""
            Else
                L6Descrip = DGrid.CurrentRow.Cells("l6").Value
            End If

        ElseIf Opcion = 12 Then
            If DGrid.CurrentRow.Cells(0).Value = "TOTAL: " Then
                Marca = ""
            Else
                Marca = DGrid.CurrentRow.Cells("marca").Value
            End If

        ElseIf Opcion = 13 Then
            If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                Modelo = ""
            Else
                Modelo = DGrid.CurrentRow.Cells("modelo").Value
            End If
        End If
    End Sub

    Private Sub RegresarMarca()
        If Opcion = 1 Then
            Sucursal = ""
        ElseIf Opcion = 2 Then
            If Chk_Calzado.Checked = False Then
                IdDivision = 0
            End If
        ElseIf Opcion = 3 Then
            IdDepto = 0
        ElseIf Opcion = 4 Then
            FamiliaDescrip = ""
        ElseIf Opcion = 5 Then
            LineaDescrip = ""
        ElseIf Opcion = 6 Then
            L1Descrip = ""
        ElseIf Opcion = 7 Then
            L2Descrip = ""
        ElseIf Opcion = 8 Then
            L3Descrip = ""
        ElseIf Opcion = 9 Then
            L4Descrip = ""
        ElseIf Opcion = 10 Then
            L5Descrip = ""
        ElseIf Opcion = 11 Then
            L6Descrip = ""
        End If
    End Sub

    Private Sub Chk_Calzado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_Calzado.CheckedChanged
        Try
            If Chk_Calzado.Checked Then
                Division = "CALZADO"
                IdDivision = 1
            Else
                Division = ""
                IdDivision = 0
            End If
            If checkInicio = True Then
                RellenaGrid()
            End If
            checkInicio = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Componentes()
        If Sucursal.Trim = "" Then
            GB_Sucursales.Enabled = True
        Else
            GB_Sucursales.Enabled = False
        End If
    End Sub

    Private Sub GeneraTexto()
        'SUCURSALES
        If Sucursal = "" Then
            lbl_Sucursal.Text = "TODAS LAS SUCURSALES"
        ElseIf Sucursal = 1 Then
            lbl_Sucursal.Text = "JUAREZ"
        ElseIf Sucursal = 2 Then
            lbl_Sucursal.Text = "HIDALGO"
        ElseIf Sucursal = 6 Then
            lbl_Sucursal.Text = "TRIANA"
        ElseIf Sucursal = 7 Then
            lbl_Sucursal.Text = "LERDO"
        ElseIf Sucursal = 8 Then
            lbl_Sucursal.Text = "MATRIZ"
        End If
        'DIVISIONES
        If IdDivision = 0 Then
            If Opcion = 2 Then
                lbl_Division.Text = "DIVISIONES"
            Else
                lbl_Division.Text = ""
            End If
        Else
            If IdDivision = 1 Then
                lbl_Division.Text = "CALZADO"
            ElseIf IdDivision = 2 Then
                lbl_Division.Text = "ACCESORIOS"
            ElseIf IdDivision = 3 Then
                lbl_Division.Text = "ELECTRONICA"
            ElseIf IdDivision = 4 Then
                lbl_Division.Text = "GENERAL"
            End If
        End If
        'DEPARTAMENTO
        If IdDepto = 0 Then
            If Opcion = 3 Then
                lbl_Depto.Text = "DEPARTAMENTO"
            Else
                lbl_Depto.Text = ""
            End If
        Else
            If IdDepto = 1 Then
                lbl_Depto.Text = "DAMAS"
            ElseIf IdDepto = 2 Then
                lbl_Depto.Text = "CABALLEROS"
            ElseIf IdDepto = 8 Then
                lbl_Depto.Text = "ACCESORIOS CALZADO"
            ElseIf IdDepto = 9 Then
                lbl_Depto.Text = "ACCESORIOS ESCOLARES"
            ElseIf IdDepto = 10 Then
                lbl_Depto.Text = "ACCESORIOS CALCETINES"
            ElseIf IdDepto = 11 Then
                lbl_Depto.Text = "CUIDADO DE CALZADO"
            ElseIf IdDepto = 12 Then
                lbl_Depto.Text = "ACCESORIOS CABALLERO"
            ElseIf IdDepto = 13 Then
                lbl_Depto.Text = "ACCESORIOS DAMA"
            ElseIf IdDepto = 14 Then
                lbl_Depto.Text = "ACCESORIOS DEPORTIVOS"
            ElseIf IdDepto = 15 Then
                lbl_Depto.Text = "INFANTIL"
            ElseIf IdDepto = 16 Then
                lbl_Depto.Text = "BEBES"
            ElseIf IdDepto = 17 Then
                lbl_Depto.Text = "CELULARES"
            ElseIf IdDepto = 18 Then
                lbl_Depto.Text = "GENERAL"
            Else
                lbl_Depto.Text = ""
            End If
        End If
        'FAMILIA
        If FamiliaDescrip = "" Then
            If Opcion = 4 Then
                lbl_Familia.Text = "FAMILIA"
            Else
                lbl_Familia.Text = ""
            End If
        Else
            lbl_Familia.Text = FamiliaDescrip
        End If
        If LineaDescrip = "" Then
            If Opcion = 5 Then
                lbl_Linea.Text = "LINEA"
            Else
                lbl_Linea.Text = ""
            End If
        Else
            lbl_Linea.Text = LineaDescrip
        End If
        If L1Descrip = "" Then
            If Opcion = 6 Then
                lbl_L1.Text = "L1"
            Else
                lbl_L1.Text = ""
            End If
        Else
            lbl_L1.Text = L1Descrip
        End If
        If L2Descrip = "" Then
            If Opcion = 7 Then
                lbl_L2.Text = "L2"
            Else
                lbl_L2.Text = ""
            End If
        Else
            lbl_L2.Text = L2Descrip
        End If
        If L3Descrip = "" Then
            If Opcion = 8 Then
                lbl_L3.Text = "L3"
            Else
                lbl_L3.Text = ""
            End If
        Else
            lbl_L3.Text = L3Descrip
        End If
        If L4Descrip = "" Then
            If Opcion = 9 Then
                lbl_L4.Text = "L4"
            Else
                lbl_L4.Text = ""
            End If
        Else
            lbl_L4.Text = L4Descrip
        End If
        If L5Descrip = "" Then
            If Opcion = 10 Then
                lbl_L5.Text = "L5"
            Else
                lbl_L5.Text = ""
            End If
        Else
            lbl_L5.Text = L5Descrip
        End If
        If L6Descrip = "" Then
            If Opcion = 11 Then
                lbl_L6.Text = "L6"
            Else
                lbl_L6.Text = ""
            End If
        Else
            lbl_L6.Text = L6Descrip
        End If
        If Marca = "" Then
            If Opcion = 12 Then
                lbl_Marca.Text = "MARCAS"
            Else
                lbl_Marca.Text = ""
            End If
        Else
            lbl_Marca.Text = Marca
        End If
        If Modelo = "" Then
            If Opcion = 13 Then
                lbl_Modelo.Text = "MODELOS"
            Else
                lbl_Modelo.Text = ""
            End If
        Else
            lbl_Modelo.Text = Modelo
        End If

        If lbl_Sucursal.Text.Trim <> "" Then
            lbl_Final.Text = lbl_Sucursal.Text
        End If
        If lbl_Division.Text.Trim <> "" Then
            lbl_Final.Text += ", " + lbl_Division.Text
        End If
        If lbl_Depto.Text.Trim <> "" Then
            lbl_Final.Text += ", " + lbl_Depto.Text
        End If
        If lbl_Familia.Text.Trim <> "" Then
            lbl_Final.Text += ", " + lbl_Familia.Text
        End If
        If lbl_Linea.Text.Trim <> "" Then
            lbl_Final.Text += ", " + lbl_Linea.Text
        End If
        If lbl_L1.Text.Trim <> "" Then
            lbl_Final.Text += ", " + lbl_L1.Text
        End If
        If lbl_L2.Text.Trim <> "" Then
            lbl_Final.Text += ", " + lbl_L2.Text
        End If
        If lbl_L3.Text.Trim <> "" Then
            lbl_Final.Text += ", " + lbl_L3.Text
        End If
        If lbl_L4.Text.Trim <> "" Then
            lbl_Final.Text += ", " + lbl_L4.Text
        End If
        If lbl_L5.Text.Trim <> "" Then
            lbl_Final.Text += ", " + lbl_L5.Text
        End If
        If lbl_L6.Text.Trim <> "" Then
            lbl_Final.Text += ", " + lbl_L6.Text
        End If
        If lbl_Marca.Text.Trim <> "" Then
            lbl_Final.Text += ", " + lbl_Marca.Text
        End If
        If lbl_Modelo.Text.Trim <> "" Then
            lbl_Final.Text += ", " + lbl_Modelo.Text
        End If

        If Accion = 1 Then
            Me.Text = "Ventas Cero: " + lbl_Final.Text
        ElseIf Accion = 2 Then
            Me.Text = "Ventas Por Num. Pares: " + lbl_Final.Text
        End If

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

    Private Sub DGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.Click
        Try
            'lbl_Suma.Visible = False
            If Opcion = 13 Then
                If IsDBNull(DGrid.CurrentRow.Cells("Marca").Value) Then
                    PBox.Visible = False
                Else
                    CargarFotoArticulo(DGrid.CurrentRow.Cells("Marca").Value, DGrid.CurrentRow.Cells("Modelo").Value)
                End If
            Else
                PBox.Visible = False
            End If
            If Accion = 1 Then
                Dim Suma As Integer = 0
                Dim Renglon As Integer
                Dim Columna As Integer
                If DGrid.SelectedCells.Count > 1 Then
                    For i As Integer = 0 To DGrid.SelectedCells.Count - 1
                        Columna = DGrid.SelectedCells.Item(i).ColumnIndex
                        Renglon = DGrid.SelectedCells.Item(i).RowIndex
                        If Opcion <> 13 Then
                            If DGrid.Columns(Columna).Name.Substring(0, 4).Trim = "dias" Or _
                            DGrid.Columns(Columna).Name.Substring(0, 5).Trim = "total" Then
                                If Not IsDBNull(DGrid.Rows(Renglon).Cells(Columna).Value) Then
                                    Suma += DGrid.Rows(Renglon).Cells(Columna).Value
                                End If
                            End If
                        Else
                            If DGrid.Columns(Columna).Name.Trim = "total" Then
                                If Not IsDBNull(DGrid.Rows(Renglon).Cells(Columna).Value) Then
                                    Suma += DGrid.Rows(Renglon).Cells(Columna).Value
                                End If
                            End If
                        End If
                    Next
                    If Suma > 0 Then
                        'lbl_Suma.Text = "SUMA: " + Suma.ToString("#,##0")
                        'lbl_Suma.Visible = True
                    End If
                Else
                    'lbl_Suma.Visible = False
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGrid.KeyUp
        Try
            If Opcion = 13 Then
                If IsDBNull(DGrid.CurrentRow.Cells("Marca").Value) Then
                    PBox.Visible = False
                Else
                    CargarFotoArticulo(DGrid.CurrentRow.Cells("Marca").Value, DGrid.CurrentRow.Cells("Modelo").Value)
                End If
            Else
                PBox.Visible = False
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Foto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Foto.Click
        Try
            Dim myForm As New frmConsultaImagen
            myForm.Txt_Estilon.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("Modelo").Value.ToString
            myForm.Txt_Marca.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("Marca").Value.ToString.Trim()
            myForm.Txt_NoFoto.Text = "1"
            myForm.ShowDialog()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub PBox_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBox.DoubleClick
        Try
            Btn_Foto_Click(sender, e)
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

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Me.Close()
    End Sub

    Private Sub PBox_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PBox.MouseDown
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

    Private Sub PBox_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PBox.MouseMove
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                PBox.Location = New Point(PBox.Left + e.X - izquierda, PBox.Top + e.Y - alto)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub PBox_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PBox.MouseUp
        Try
            PBox.Cursor = Cursors.Default
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Filtro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        Try
            myFormFiltros.StartPosition = FormStartPosition.CenterParent
            myFormFiltros.Sw_Filtro = False


            If GLB_CveSucursal >= "00" AndAlso GLB_CveSucursal < "90" Then
                myFormFiltros.CB_Sucursal.Visible = False
            Else
                myFormFiltros.CB_Sucursal.Visible = True
            End If


            'myFormFiltros.Label4.Text = "Fechas:"
            myFormFiltros.Text = "Filtros Ventas Cero"

            myFormFiltros.Txt_Marca.Text = Marca

            'myFormFiltros.Txt_DescripDivision.Text = Division
            'myFormFiltros.Txt_DescripDepto.Text = Depto
            'myFormFiltros.Txt_DescripFamilia.Text = FamiliaDescrip
            'myFormFiltros.Txt_DescripLinea.Text = LineaDescrip
            'myFormFiltros.Txt_DescripL1.Text = L1Descrip
            'myFormFiltros.Txt_DescripL2.Text = L2Descrip
            'myFormFiltros.Txt_DescripL3.Text = L3Descrip
            'myFormFiltros.Txt_DescripL4.Text = L4Descrip
            'myFormFiltros.Txt_DescripL5.Text = L5Descrip
            'myFormFiltros.Txt_DescripL6.Text = L6Descrip


            If IdDivision <> 0 Then
                myFormFiltros.Txt_IdDivision.Text = IdDivision
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstDivisiones(IdDivision, "")
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_DescripDivision.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                    myFormFiltros.Txt_Division.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                End If
            End If
            If IdDepto <> 0 Then
                myFormFiltros.Txt_IdDepto.Text = IdDepto
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstDepto(IdDepto, 0, "", 0, "")
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_DescripDepto.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                    myFormFiltros.Txt_Depto.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                End If
            End If
            If FamiliaDescrip <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstFamilia(0, 0, 0, "", 3, FamiliaDescrip)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_Familia.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripFamilia.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If LineaDescrip <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstLinea(0, 0, 0, 0, "", 3, LineaDescrip)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_Linea.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripLinea.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L1Descrip <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl1(0, 0, 0, 0, 0, "", 3, L1Descrip)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_L1.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripL1.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L2Descrip <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl2(0, 0, 0, 0, 0, 0, "", 3, L2Descrip)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_L2.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripL2.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L3Descrip <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl3(0, 0, 0, 0, 0, 0, 0, "", 3, L3Descrip)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_L3.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripL3.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L4Descrip <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl4(0, 0, 0, 0, 0, 0, 0, 0, "", 3, L4Descrip)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_L4.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripL4.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L5Descrip <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl5(0, 0, 0, 0, 0, 0, 0, 0, 0, "", 3, L5Descrip)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_L5.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripL5.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L6Descrip <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl6(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", 3, L6Descrip)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_L6.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripL6.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If


            myFormFiltros.DT_Inicio.Value = CDate(FechaInicio)
            myFormFiltros.DT_Fin.Value = CDate(FechaFin)

            'myFormFiltros.DT_RecIni.Value = CDate(FecRecA)
            'myFormFiltros.DT_RecFin.Value = CDate(FecRecB)

            myFormFiltros.ShowDialog()
            If myFormFiltros.Sw_Filtro = True Then
                DGrid.DataSource = Nothing
                DGrid.Refresh()
                DGrid.Rows.Clear()

                If myFormFiltros.CB_Sucursal.SelectedValue = 1 Then
                    Sucursal = "01"
                ElseIf myFormFiltros.CB_Sucursal.SelectedValue = 2 Then
                    Sucursal = "02"
                ElseIf myFormFiltros.CB_Sucursal.SelectedValue = 6 Then
                    Sucursal = "06"
                ElseIf myFormFiltros.CB_Sucursal.SelectedValue = 8 Then
                    Sucursal = "08"
                ElseIf myFormFiltros.CB_Sucursal.SelectedValue = 0 Then
                    Sucursal = ""
                End If

                FechaInicio = myFormFiltros.DT_Inicio.Value.ToString("yyyy-MM-dd")
                FechaFin = myFormFiltros.DT_Fin.Value.ToString("yyyy-MM-dd")

                If myFormFiltros.Chk_UltRecibo.Checked Then
                    FecRecA = myFormFiltros.DT_RecIni.Value.ToString("yyyy-MM-dd")
                    FecRecB = myFormFiltros.DT_RecFin.Value.ToString("yyyy-MM-dd")
                Else
                    FecRecA = ""
                    FecRecB = ""
                End If

                Marca = myFormFiltros.Txt_Marca.Text

                If Marca.Trim <> "" Then
                    lbl_Marca.Text = Marca
                End If

                If myFormFiltros.Txt_IdDivision.Text = "" Then
                    If Chk_Calzado.Checked = True Then
                        IdDivision = IdDivision
                    Else
                        IdDivision = 0
                    End If

                Else
                    IdDivision = myFormFiltros.Txt_IdDivision.Text
                End If

                If myFormFiltros.Txt_IdDepto.Text = "" Then
                    IdDepto = 0
                Else
                    IdDepto = myFormFiltros.Txt_IdDepto.Text
                End If

                If myFormFiltros.Txt_DescripFamilia.Text = "" Then
                    FamiliaDescrip = ""
                Else
                    FamiliaDescrip = myFormFiltros.Txt_DescripFamilia.Text
                End If

                If myFormFiltros.Txt_DescripLinea.Text = "" Then
                    LineaDescrip = ""
                Else
                    LineaDescrip = myFormFiltros.Txt_DescripLinea.Text
                End If

                If myFormFiltros.Txt_DescripL1.Text = "" Then
                    L1Descrip = ""
                Else
                    L1Descrip = myFormFiltros.Txt_DescripL1.Text
                End If

                If myFormFiltros.Txt_DescripL2.Text = "" Then
                    L2Descrip = ""
                Else
                    L2Descrip = myFormFiltros.Txt_DescripL2.Text
                End If

                If myFormFiltros.Txt_DescripL3.Text = "" Then
                    L3Descrip = ""
                Else
                    L3Descrip = myFormFiltros.Txt_DescripL3.Text
                End If

                If myFormFiltros.Txt_DescripL4.Text = "" Then
                    L4Descrip = ""
                Else
                    L4Descrip = myFormFiltros.Txt_DescripL4.Text
                End If

                If myFormFiltros.Txt_DescripL5.Text = "" Then
                    L5Descrip = ""
                Else
                    L5Descrip = myFormFiltros.Txt_DescripL5.Text
                End If

                If myFormFiltros.Txt_DescripL6.Text = "" Then
                    L6Descrip = ""
                Else
                    L6Descrip = myFormFiltros.Txt_DescripL6.Text
                End If

                Call RellenaGrid()

            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub OcultarToolStrips()
        If Opcion = 1 Then
            ToolStripMenuItemSucursal.Visible = False
            ToolStripMenuItemDivision.Visible = True
            ToolStripMenuItemDepto.Visible = True
            ToolStripMenuItemFamilia.Visible = True
            ToolStripMenuItemLinea.Visible = True
            ToolStripMenuItemL1.Visible = True
            ToolStripMenuItemL2.Visible = True
            ToolStripMenuItemL3.Visible = True
            ToolStripMenuItemL4.Visible = True
            ToolStripMenuItemL5.Visible = True
            ToolStripMenuItemL6.Visible = True
            ToolStripMenuItemMarca.Visible = True
            ToolStripMenuItemModelo.Visible = True
            ToolStripMenuItemCatModelo.Visible = False
            ToolStripMenuItemAnaModelo.Visible = False
        End If
        If Opcion = 2 Then
            ToolStripMenuItemSucursal.Visible = True
            ToolStripMenuItemDivision.Visible = False
            ToolStripMenuItemDepto.Visible = True
            ToolStripMenuItemFamilia.Visible = True
            ToolStripMenuItemLinea.Visible = True
            ToolStripMenuItemL1.Visible = True
            ToolStripMenuItemL2.Visible = True
            ToolStripMenuItemL3.Visible = True
            ToolStripMenuItemL4.Visible = True
            ToolStripMenuItemL5.Visible = True
            ToolStripMenuItemL6.Visible = True
            ToolStripMenuItemMarca.Visible = True
            ToolStripMenuItemModelo.Visible = True
            ToolStripMenuItemCatModelo.Visible = False
            ToolStripMenuItemAnaModelo.Visible = False
        End If
        If Opcion = 3 Then
            ToolStripMenuItemSucursal.Visible = True
            ToolStripMenuItemDivision.Visible = True
            ToolStripMenuItemDepto.Visible = False
            ToolStripMenuItemFamilia.Visible = True
            ToolStripMenuItemLinea.Visible = True
            ToolStripMenuItemL1.Visible = True
            ToolStripMenuItemL2.Visible = True
            ToolStripMenuItemL3.Visible = True
            ToolStripMenuItemL4.Visible = True
            ToolStripMenuItemL5.Visible = True
            ToolStripMenuItemL6.Visible = True
            ToolStripMenuItemMarca.Visible = True
            ToolStripMenuItemModelo.Visible = True
            ToolStripMenuItemCatModelo.Visible = False
            ToolStripMenuItemAnaModelo.Visible = False
        End If
        If Opcion = 4 Then
            ToolStripMenuItemSucursal.Visible = True
            ToolStripMenuItemDivision.Visible = True
            ToolStripMenuItemDepto.Visible = True
            ToolStripMenuItemFamilia.Visible = False
            ToolStripMenuItemLinea.Visible = True
            ToolStripMenuItemL1.Visible = True
            ToolStripMenuItemL2.Visible = True
            ToolStripMenuItemL3.Visible = True
            ToolStripMenuItemL4.Visible = True
            ToolStripMenuItemL5.Visible = True
            ToolStripMenuItemL6.Visible = True
            ToolStripMenuItemMarca.Visible = True
            ToolStripMenuItemModelo.Visible = True
            ToolStripMenuItemCatModelo.Visible = False
            ToolStripMenuItemAnaModelo.Visible = False
        End If
        If Opcion = 5 Then
            ToolStripMenuItemSucursal.Visible = True
            ToolStripMenuItemDivision.Visible = True
            ToolStripMenuItemDepto.Visible = True
            ToolStripMenuItemFamilia.Visible = True
            ToolStripMenuItemLinea.Visible = False
            ToolStripMenuItemL1.Visible = True
            ToolStripMenuItemL2.Visible = True
            ToolStripMenuItemL3.Visible = True
            ToolStripMenuItemL4.Visible = True
            ToolStripMenuItemL5.Visible = True
            ToolStripMenuItemL6.Visible = True
            ToolStripMenuItemMarca.Visible = True
            ToolStripMenuItemModelo.Visible = True
            ToolStripMenuItemCatModelo.Visible = False
            ToolStripMenuItemAnaModelo.Visible = False
        End If
        If Opcion = 6 Then
            ToolStripMenuItemSucursal.Visible = True
            ToolStripMenuItemDivision.Visible = True
            ToolStripMenuItemDepto.Visible = True
            ToolStripMenuItemFamilia.Visible = True
            ToolStripMenuItemLinea.Visible = True
            ToolStripMenuItemL1.Visible = False
            ToolStripMenuItemL2.Visible = True
            ToolStripMenuItemL3.Visible = True
            ToolStripMenuItemL4.Visible = True
            ToolStripMenuItemL5.Visible = True
            ToolStripMenuItemL6.Visible = True
            ToolStripMenuItemMarca.Visible = True
            ToolStripMenuItemModelo.Visible = True
            ToolStripMenuItemCatModelo.Visible = False
            ToolStripMenuItemAnaModelo.Visible = False
        End If
        If Opcion = 7 Then
            ToolStripMenuItemSucursal.Visible = True
            ToolStripMenuItemDivision.Visible = True
            ToolStripMenuItemDepto.Visible = True
            ToolStripMenuItemFamilia.Visible = True
            ToolStripMenuItemLinea.Visible = True
            ToolStripMenuItemL1.Visible = True
            ToolStripMenuItemL2.Visible = False
            ToolStripMenuItemL3.Visible = True
            ToolStripMenuItemL4.Visible = True
            ToolStripMenuItemL5.Visible = True
            ToolStripMenuItemL6.Visible = True
            ToolStripMenuItemMarca.Visible = True
            ToolStripMenuItemModelo.Visible = True
            ToolStripMenuItemCatModelo.Visible = False
            ToolStripMenuItemAnaModelo.Visible = False
        End If
        If Opcion = 8 Then
            ToolStripMenuItemSucursal.Visible = True
            ToolStripMenuItemDivision.Visible = True
            ToolStripMenuItemDepto.Visible = True
            ToolStripMenuItemFamilia.Visible = True
            ToolStripMenuItemLinea.Visible = True
            ToolStripMenuItemL1.Visible = True
            ToolStripMenuItemL2.Visible = True
            ToolStripMenuItemL3.Visible = False
            ToolStripMenuItemL4.Visible = True
            ToolStripMenuItemL5.Visible = True
            ToolStripMenuItemL6.Visible = True
            ToolStripMenuItemMarca.Visible = True
            ToolStripMenuItemModelo.Visible = True
            ToolStripMenuItemCatModelo.Visible = False
            ToolStripMenuItemAnaModelo.Visible = False
        End If
        If Opcion = 9 Then
            ToolStripMenuItemSucursal.Visible = True
            ToolStripMenuItemDivision.Visible = True
            ToolStripMenuItemDepto.Visible = True
            ToolStripMenuItemFamilia.Visible = True
            ToolStripMenuItemLinea.Visible = True
            ToolStripMenuItemL1.Visible = True
            ToolStripMenuItemL2.Visible = True
            ToolStripMenuItemL3.Visible = True
            ToolStripMenuItemL4.Visible = False
            ToolStripMenuItemL5.Visible = True
            ToolStripMenuItemL6.Visible = True
            ToolStripMenuItemMarca.Visible = True
            ToolStripMenuItemModelo.Visible = True
            ToolStripMenuItemCatModelo.Visible = False
            ToolStripMenuItemAnaModelo.Visible = False
        End If
        If Opcion = 10 Then
            ToolStripMenuItemSucursal.Visible = True
            ToolStripMenuItemDivision.Visible = True
            ToolStripMenuItemDepto.Visible = True
            ToolStripMenuItemFamilia.Visible = True
            ToolStripMenuItemLinea.Visible = True
            ToolStripMenuItemL1.Visible = True
            ToolStripMenuItemL2.Visible = True
            ToolStripMenuItemL3.Visible = True
            ToolStripMenuItemL4.Visible = True
            ToolStripMenuItemL5.Visible = False
            ToolStripMenuItemL6.Visible = True
            ToolStripMenuItemMarca.Visible = True
            ToolStripMenuItemModelo.Visible = True
            ToolStripMenuItemCatModelo.Visible = False
            ToolStripMenuItemAnaModelo.Visible = False
        End If
        If Opcion = 11 Then
            ToolStripMenuItemSucursal.Visible = True
            ToolStripMenuItemDivision.Visible = True
            ToolStripMenuItemDepto.Visible = True
            ToolStripMenuItemFamilia.Visible = True
            ToolStripMenuItemLinea.Visible = True
            ToolStripMenuItemL1.Visible = True
            ToolStripMenuItemL2.Visible = True
            ToolStripMenuItemL3.Visible = True
            ToolStripMenuItemL4.Visible = True
            ToolStripMenuItemL5.Visible = True
            ToolStripMenuItemL6.Visible = False
            ToolStripMenuItemMarca.Visible = True
            ToolStripMenuItemModelo.Visible = True
            ToolStripMenuItemCatModelo.Visible = False
            ToolStripMenuItemAnaModelo.Visible = False
        End If
        If Opcion = 12 Then
            ToolStripMenuItemSucursal.Visible = True
            ToolStripMenuItemDivision.Visible = True
            ToolStripMenuItemDepto.Visible = True
            ToolStripMenuItemFamilia.Visible = True
            ToolStripMenuItemLinea.Visible = True
            ToolStripMenuItemL1.Visible = True
            ToolStripMenuItemL2.Visible = True
            ToolStripMenuItemL3.Visible = True
            ToolStripMenuItemL4.Visible = True
            ToolStripMenuItemL5.Visible = True
            ToolStripMenuItemL6.Visible = True
            ToolStripMenuItemMarca.Visible = False
            ToolStripMenuItemModelo.Visible = True
            ToolStripMenuItemCatModelo.Visible = False
            ToolStripMenuItemAnaModelo.Visible = False
        End If
        If Opcion = 13 Then
            ToolStripMenuItemSucursal.Visible = True
            ToolStripMenuItemDivision.Visible = True
            ToolStripMenuItemDepto.Visible = True
            ToolStripMenuItemFamilia.Visible = True
            ToolStripMenuItemLinea.Visible = True
            ToolStripMenuItemL1.Visible = True
            ToolStripMenuItemL2.Visible = True
            ToolStripMenuItemL3.Visible = True
            ToolStripMenuItemL4.Visible = True
            ToolStripMenuItemL5.Visible = True
            ToolStripMenuItemL6.Visible = True
            ToolStripMenuItemMarca.Visible = True
            ToolStripMenuItemModelo.Visible = False

            If GLB_CveSucursal >= "00" AndAlso GLB_CveSucursal < "90" Then
                ToolStripMenuItemCatModelo.Visible = False
                ToolStripMenuItemAnaModelo.Visible = False
            Else
                ToolStripMenuItemCatModelo.Visible = True
                ToolStripMenuItemAnaModelo.Visible = True
            End If

        End If
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

    Private Sub Txt_CtdFin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_CtdFin.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'Private Sub Txt_CtdFin_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Txt_CtdFin.Validating
    '    Dim ctdi As Integer = 0
    '    Dim ctdf As Integer = 0
    '    Try
    '        If Txt_CtdIni.Text = "" Then
    '            Txt_CtdIni.Focus()
    '            Exit Sub
    '        End If

    '        If CtdIni = Val(Txt_CtdIni.Text) AndAlso CtdFin = Val(Txt_CtdFin.Text) Then
    '            Exit Sub
    '        End If

    '        ctdi = Val(Txt_CtdIni.Text)
    '        ctdf = Val(Txt_CtdFin.Text)

    '        If ctdf < ctdi Then
    '            MessageBox.Show("La cantidad de pares final no puede ser menor a la cantidad inicial.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '            Txt_CtdFin.Text = ""
    '            Txt_CtdIni.Select()
    '            Exit Sub
    '        End If


    '        If ctdf > ctdi Then
    '            CtdIni = ctdi
    '            CtdFin = ctdf
    '            RellenaGrid()
    '        End If

    '    Catch ExceptionErr As Exception
    '        MessageBox.Show(ExceptionErr.Message.ToString)
    '    End Try
    'End Sub

    Private Sub Btn_Actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Actualizar.Click
        Dim ctdi As Integer = 0
        Dim ctdf As Integer = 0
        Try
            If Txt_CtdIni.Text = "" Then
                Txt_CtdIni.Focus()
                Exit Sub
            End If

            If CtdIni = Val(Txt_CtdIni.Text) AndAlso CtdFin = Val(Txt_CtdFin.Text) Then
                Exit Sub
            End If

            ctdi = Val(Txt_CtdIni.Text)
            ctdf = Val(Txt_CtdFin.Text)

            If ctdf < ctdi Then
                MessageBox.Show("La cantidad de pares final no puede ser menor a la cantidad inicial.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Txt_CtdFin.Text = ""
                Txt_CtdIni.Select()
                Exit Sub
            End If


            If ctdf >= ctdi Then
                CtdIni = ctdi
                CtdFin = ctdf
                RellenaGrid()
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
End Class