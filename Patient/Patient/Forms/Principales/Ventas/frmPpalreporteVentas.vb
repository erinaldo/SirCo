Public Class frmPpalreporteVentas
    Private objDataSet As Data.DataSet
    Dim Sw_NoRegistros As Boolean = False
    Dim Sw_Pintar As Boolean = False
    Dim Sw_Load As Boolean = True
    Dim fechaA As Date
    Dim fechaB As Date
    Dim fechaA2 As Date
    Dim fechaB2 As Date
    Dim fechaIni As Date
    Dim accion As Integer
    Dim porcent As Double
    Dim renglon As Integer
    Dim renglon2 As Integer
    Dim distrib As String
    Dim distrib2 As String
    Dim sucursalB As String
    Dim ventaB As String
    Dim opcion As Integer
    Dim filtro As Boolean = False
    Dim filtrar As Boolean = False
    Dim MarcaFOTO As String = ""
    Dim EstiloNFOTO As String = ""
    Dim suma As Double
    Dim sumat2 As Double
    Dim suma20 As Double
    Dim suma80 As Double
    Dim Datagrid As Integer = 0
    Dim accionmostrar As Integer = 0 ' opcion para ver si muestra el 80% o el 20 o el total
    Dim promedioT As Double
    Dim promedio20 As Double
    Dim promedio80 As Double
    Dim renglolprom As Integer
    Dim renglon20 As Integer
    Dim empleado As Integer = 0
    Dim ren As Integer
    Dim entrar As Boolean = False
    Dim yano As Boolean = False
    Private Sub frmPpalreporteVentas_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Sw_Load = True Then
            If Sw_NoRegistros = False Then
                Sw_Load = False
            Else
                Sw_Load = False
                InicializaGrid4()
            End If
        End If
    End Sub
    Private Sub frmPpalreporteVentas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub
    Private Sub frmPpalreporteVentas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            'Call LimpiarBusqueda()
            Call RellenaGrid4()
            Call GenerarToolTip()
            Sw_Pintar = True
            Sw_Load = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Salir, "Salir")
            ToolTip.SetToolTip(Btn_Imprimir, "Imprimir")
            ToolTip.SetToolTip(Btn_Filtro, "Filtros")
            ToolTip.SetToolTip(Btn_Excel, "Mostrar en Exel")
            ToolTip.SetToolTip(Btn_Regresar, "Regresar")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub RellenaGrid(ByVal valRow As String)
        'ro
        Btn_CPersonal.Enabled = False
        Btn_Distribs.Enabled = False
        Btn_Filtro.Enabled = False
        If valRow = 1 Then
            accionmostrar = 1

        ElseIf valRow = 2 Then
            accionmostrar = 2
        Else
            accionmostrar = 3
        End If
        Using objVenta As New BCL.BCLReporteVentas(GLB_ConStringCrvSis)
            Panel_Totales.Visible = True
            Btn_Imprimir.Enabled = True
            Datagrid = 1
            'If filtro = False Then
            Btn_Regresar.Enabled = True
            'End If
            Try
                Me.Cursor = Cursors.WaitCursor
                'DGrid.ReadOnly = True
                DGrid.DataSource = Nothing
                Dim _fechaA As String
                Dim _fechaB As String
                _fechaA = Format(fechaA, "yyyy-MM-dd")
                _fechaB = Format(fechaB, "yyyy-MM-dd")
                If empleado = 1 Then
                    If accion = 1 Then
                        objDataSet = objVenta.usp_PpalReporteVentas(4, valRow, _fechaA, _fechaB, "", "", "")
                        Lbl_RangoFechas.Text = "Periodo:  " + Format(CDate(_fechaA), "dd-MMM-yyyy").ToString.ToUpper + "  al  " + Format(CDate(_fechaB), "dd-MMM-yyyy").ToString.ToUpper
                    ElseIf accion = 2 Then
                        objDataSet = objVenta.usp_PpalReporteVentas(4, valRow, _fechaA, _fechaB, "", "", "")
                        Lbl_RangoFechas.Text = "Periodo:  " + Format(CDate(_fechaA), "dd-MMM-yyyy").ToString.ToUpper + "  al  " + Format(CDate(_fechaB), "dd-MMM-yyyy").ToString.ToUpper
                    Else
                        'Using objMaxCargo As New BCL.BCLReporteVentas(GLB_ConStringCrvSis)
                        '    objDataSet = objMaxCargo.usp_TraerMaxFechaCargo()
                        '    fechaIni = objDataSet.Tables(0).Rows(0).Item("fechamax")
                        '    _fechaA = Format(fechaIni, "yyyy-MM-dd")
                        'End Using
                        _fechaA = Date.Now.AddDays(-1)
                        objDataSet = objVenta.usp_PpalReporteVentas(4, valRow, _fechaA, _fechaA, "", "", "")
                        Lbl_RangoFechas.Text = "Periodo:  " + Format(CDate(_fechaA), "dd-MMM-yyyy").ToString.ToUpper + "  al  " + Format(CDate(_fechaA), "dd-MMM-yyyy").ToString.ToUpper
                    End If
                Else
                    If accion = 1 Then
                        objDataSet = objVenta.usp_PpalReporteVentas(1, valRow, _fechaA, _fechaB, "", "", "")
                        Lbl_RangoFechas.Text = "Periodo:  " + Format(CDate(_fechaA), "dd-MMM-yyyy").ToString.ToUpper + "  al  " + Format(CDate(_fechaB), "dd-MMM-yyyy").ToString.ToUpper
                    ElseIf accion = 2 Then
                        objDataSet = objVenta.usp_PpalReporteVentas(1, valRow, _fechaA, _fechaB, "", "", "")
                        Lbl_RangoFechas.Text = "Periodo:  " + Format(CDate(_fechaA), "dd-MMM-yyyy").ToString.ToUpper + "  al  " + Format(CDate(_fechaB), "dd-MMM-yyyy").ToString.ToUpper
                    Else
                        'Using objMaxCargo As New BCL.BCLReporteVentas(GLB_ConStringCrvSis)
                        '    objDataSet = objMaxCargo.usp_TraerMaxFechaCargo()
                        '    fechaIni = objDataSet.Tables(0).Rows(0).Item("fechamax")
                        '    _fechaA = Format(fechaIni, "yyyy-MM-dd")
                        'End Using
                        _fechaA = Date.Now.AddDays(-1)
                        objDataSet = objVenta.usp_PpalReporteVentas(1, valRow, _fechaA, _fechaA, "", "", "")
                        Lbl_RangoFechas.Text = "Periodo:  " + Format(CDate(_fechaA), "dd-MMM-yyyy").ToString.ToUpper + "  al  " + Format(CDate(_fechaA), "dd-MMM-yyyy").ToString.ToUpper
                    End If
                End If
                opcion = 3
                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section
                    DGrid.DataSource = objDataSet.Tables(0)
                    If Sw_Load = False Then
                        InicializaGrid()

                    End If
                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True
                    Sw_NoRegistros = True
                    Sw_Pintar = True
                Else
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron Ventas que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                    opcion = 3
                End If

                Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
            yano = False
        End Using
    End Sub
    Private Sub RellenaGrid2(ByVal valRow As String)
        'ro
        Btn_CPersonal.Enabled = False
        Btn_Distribs.Enabled = False
        Using objVenta As New BCL.BCLReporteVentas(GLB_ConStringCrvSis)
            Btn_Filtro.Enabled = False
            Panel_Totales.Visible = False
            Btn_Regresar.Enabled = True
            Btn_Imprimir.Enabled = False
            Try
                Me.Cursor = Cursors.WaitCursor
                If Sw_Load = True Then
                    ' Sw_Load = False 
                Else
                    If Sw_NoRegistros = True Then
                        'If blnPorc = True Then
                        'DGrid.Columns.Remove("Posic")
                        'DGrid.Columns.Remove("suma")
                    End If
                End If
                'DGrid.ReadOnly = True
                DGrid.DataSource = Nothing
                'Dim _fechaA As String
                'Dim _fechaB As String
                '_fechaA = Format(fechaA, "yyyy-MM-dd")
                '_fechaB = Format(fechaB, "yyyy-MM-dd")
                distrib = valRow
                distrib2 = distrib
                If accion = 1 Then
                    objDataSet = objVenta.usp_PpalReporteVentas(2, valRow, fechaA, fechaB, distrib, "", "")
                Else
                    'Using objMaxCargo As New BCL.BCLReporteVentas(GLB_ConStringCrvSis)
                    '    objDataSet = objMaxCargo.usp_TraerMaxFechaCargo()
                    '    fechaIni = objDataSet.Tables(0).Rows(0).Item("fechamax")
                    '    fechaA = Format(fechaIni, "yyyy-MM-dd")
                    'End Using
                    fechaA = Date.Now.AddDays(-1)
                    objDataSet = objVenta.usp_PpalReporteVentas(2, valRow, fechaA, fechaA, distrib, "", "")
                End If
                opcion = 2
                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section
                    DGrid.DataSource = objDataSet.Tables(0)
                    If Sw_Load = False Then
                        InicializaGrid2()
                    End If
                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True
                    Sw_NoRegistros = True
                    Sw_Pintar = True
                Else
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron Ventas que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                    opcion = 2
                End If
                Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()
                If filtrar = False Then
                    filtro = False
                Else
                    filtro = True
                End If

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
            yano = False
        End Using
    End Sub
    Private Sub RellenaGrid3(ByVal sucursal As String, ByVal venta As String)
        'ro
        yano = True
        Btn_CPersonal.Enabled = False
        Btn_Distribs.Enabled = False
        Using objVenta As New BCL.BCLReporteVentas(GLB_ConStringCipSis)
            Btn_Filtro.Enabled = False
            Panel_Totales.Visible = False
            Btn_Regresar.Enabled = True
            Btn_Imprimir.Enabled = False
            Try
                Me.Cursor = Cursors.WaitCursor

                'DGrid.ReadOnly = True
                DGrid.DataSource = Nothing
                Dim _fechaA As String
                Dim _fechaB As String
                _fechaA = Format(fechaA, "yyyy-MM-dd")
                _fechaB = Format(fechaB, "yyyy-MM-dd")
                sucursalB = sucursal
                ventaB = venta
                If accion = 1 Then
                    objDataSet = objVenta.usp_PpalReporteVentas2(3, _fechaA, _fechaB, distrib, sucursalB, ventaB)
                Else
                    'Using objMaxCargo As New BCL.BCLReporteVentas(GLB_ConStringCrvSis)
                    '    objDataSet = objMaxCargo.usp_TraerMaxFechaCargo()
                    '    fechaIni = objDataSet.Tables(0).Rows(0).Item("fechamax")
                    '    _fechaA = Format(fechaIni, "yyyy-MM-dd")
                    'End Using
                    fechaA = Date.Now.AddDays(-1)
                    objDataSet = objVenta.usp_PpalReporteVentas2(3, _fechaA, _fechaA, distrib, sucursal, venta)
                End If
                opcion = 1
                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section
                    DGrid.DataSource = objDataSet.Tables(0)
                    If Sw_Load = False Then

                        InicializaGrid3()
                    End If
                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True
                    Sw_NoRegistros = True
                    Sw_Pintar = True
                Else
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron Ventas que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                    opcion = 1
                End If
                Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub
    Private Sub RellenaGrid4()
        'ro
        'If Not IsDBNull(DGrid.Rows(DGrid.CurrentRow.Index).Cells("marca").Value) Then
        '    If blnPrimero = True Then
        '        CargarFotoArticulo(DGrid.Rows(DGrid.CurrentRow.Index).Cells(1).Value, DGrid.Rows(DGrid.CurrentRow.Index).Cells(2).Value)
        '    Else
        '        CargarFotoArticulo(DGrid.Rows(DGrid.CurrentRow.Index).Cells(0).Value, DGrid.Rows(DGrid.CurrentRow.Index).Cells(1).Value)
        '    End If
        'End If
        yano = False
        Using objVenta As New BCL.BCLReporteVentas(GLB_ConStringCrvSis)
            Btn_CPersonal.Enabled = True
            Btn_Distribs.Enabled = True
            Btn_Filtro.Enabled = True
            Panel_Totales.Visible = False
            Btn_Imprimir.Enabled = False
            If filtrar = False Then
                filtro = False
            End If
            Datagrid = 2
            Btn_Regresar.Enabled = False
            Try
                Me.Cursor = Cursors.WaitCursor

                'DGrid.ReadOnly = True
                DGrid.DataSource = Nothing
                Dim _fechaA As String
                Dim _fechaB As String
                _fechaA = Format(fechaA, "yyyy-MM-dd")
                _fechaB = Format(fechaB, "yyyy-MM-dd")
                If empleado = 1 Then
                    If accion = 1 Then
                        objDataSet = objVenta.usp_PpalReporteVentas(4, 0, _fechaA, _fechaB, "", "", "")
                        Lbl_RangoFechas.Text = "Periodo:  " + Format(CDate(_fechaA), "dd-MMM-yyyy").ToString.ToUpper + "  al  " + Format(CDate(_fechaB), "dd-MMM-yyyy").ToString.ToUpper
                        'dias = DateDiff(DateInterval.Day, fechaA, fechaB)
                    ElseIf accion = 2 Then
                        objDataSet = objVenta.usp_PpalReporteVentas(4, 0, _fechaA, _fechaB, "", "", "")
                        Lbl_RangoFechas.Text = "Periodo:  " + Format(CDate(_fechaA), "dd-MMM-yyyy").ToString.ToUpper + "  al  " + Format(CDate(_fechaB), "dd-MMM-yyyy").ToString.ToUpper
                        'dias = DateDiff(DateInterval.Day, fechaA, fechaB)
                    Else
                        'Using objMaxCargo As New BCL.BCLReporteVentas(GLB_ConStringCrvSis)
                        '    objDataSet = objMaxCargo.usp_TraerMaxFechaCargo()
                        '    fechaIni = objDataSet.Tables(0).Rows(0).Item("fechamax")
                        '    _fechaA = Format(fechaIni, "yyyy-MM-dd")
                        'End Using
                        _fechaA = Date.Now.AddDays(-1)
                        objDataSet = objVenta.usp_PpalReporteVentas(4, 0, _fechaA, _fechaA, "", "", "")
                        Lbl_RangoFechas.Text = "Periodo:  " + Format(CDate(_fechaA), "dd-MMM-yyyy").ToString.ToUpper + "  al  " + Format(CDate(_fechaA), "dd-MMM-yyyy").ToString.ToUpper
                        'dias = 1
                    End If
                Else
                    If accion = 1 Then
                        objDataSet = objVenta.usp_PpalReporteVentas(1, 0, _fechaA, _fechaB, "", "", "")
                        Lbl_RangoFechas.Text = "Periodo:  " + Format(CDate(_fechaA), "dd-MMM-yyyy").ToString.ToUpper + "  al  " + Format(CDate(_fechaB), "dd-MMM-yyyy").ToString.ToUpper
                        'dias = DateDiff(DateInterval.Day, fechaA, fechaB)
                    ElseIf accion = 2 Then
                        objDataSet = objVenta.usp_PpalReporteVentas(1, 0, _fechaA, _fechaB, "", "", "")
                        Lbl_RangoFechas.Text = "Periodo:  " + Format(CDate(_fechaA), "dd-MMM-yyyy").ToString.ToUpper + "  al  " + Format(CDate(_fechaB), "dd-MMM-yyyy").ToString.ToUpper
                        'dias = DateDiff(DateInterval.Day, fechaA, fechaB)
                    Else
                        'Using objMaxCargo As New BCL.BCLReporteVentas(GLB_ConStringCrvSis)
                        '    objDataSet = objMaxCargo.usp_TraerMaxFechaCargo()
                        '    fechaIni = objDataSet.Tables(0).Rows(0).Item("fechamax")
                        '    _fechaA = Format(fechaIni, "yyyy-MM-dd")
                        'End Using
                        _fechaA = Date.Now.AddDays(-1)
                        objDataSet = objVenta.usp_PpalReporteVentas(1, 0, _fechaA, _fechaA, "", "", "")
                        Lbl_RangoFechas.Text = "Periodo:  " + Format(CDate(_fechaA), "dd-MMM-yyyy").ToString.ToUpper + "  al  " + Format(CDate(_fechaA), "dd-MMM-yyyy").ToString.ToUpper
                        'dias = 1
                    End If
                End If
                opcion = 5
                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section
                    DGrid.DataSource = objDataSet.Tables(0)
                    If Sw_Load = False Then
                        InicializaGrid4()

                    End If
                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True
                    Sw_NoRegistros = True
                    Sw_Pintar = True
                Else
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron Ventas que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                    opcion = 5
                End If

                Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub
    Sub InicializaGrid()
        '' ro 20-3-2013
        Try
            Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
            Dim row As DataRow = dt.NewRow()
            If accionmostrar = 1 Then
                row(4) = CDbl(suma.ToString("C"))
                suma = pub_SumaColumnaGrid2(DGrid, 5, DGrid.RowCount - 1)
                suma = pub_SumaColumnaGrid4(DGrid, 4, DGrid.RowCount - 1)
                txt_suma.Text = suma.ToString("C")
                sumat2 = 0
                txt_suma20.Text = sumat2.ToString("C")
                txt_distrib80.Text = renglon2
                txt_distrib20.Text = 0
                row(5) = "80"
            ElseIf accionmostrar = 2 Then
                row(4) = CDbl(sumat2.ToString("C"))
                suma = pub_SumaColumnaGrid2(DGrid, 5, DGrid.RowCount - 1)
                Call pub_SumaColumnaGrid4(DGrid, 4, DGrid.RowCount - 1)
                suma = 0
                txt_suma.Text = suma.ToString("C")
                sumat2 = pub_SumaColumnaGrid(DGrid, 4, DGrid.RowCount - 1)
                txt_suma20.Text = sumat2.ToString("C")
                txt_distrib20.Text = renglon2
                txt_distrib80.Text = 0
                row(5) = "20"
            Else
                row(4) = pub_SumaColumnaGrid(DGrid, 4, DGrid.RowCount - 1)
                suma = pub_SumaColumnaGrid2(DGrid, 5, DGrid.RowCount - 1)
                suma = pub_SumaColumnaGrid4(DGrid, 4, DGrid.RowCount - 1)
                txt_suma.Text = suma.ToString("C")
                sumat2 = pub_SumaColumnaGrid3(DGrid, 4, DGrid.RowCount - 1)
                txt_suma20.Text = sumat2.ToString("C")
                txt_distrib80.Text = renglon2
                txt_distrib20.Text = renglon20
                row(5) = "100"
            End If
            dt.Rows.InsertAt(row, 0)
            DGrid.DataSource = dt
            Dim total As Integer = 0

            DGrid.RowHeadersVisible = False
            DGrid.Columns(0).HeaderText = "Posición"
            DGrid.Columns(1).HeaderText = "Id Distribuidor"
            DGrid.Columns(2).HeaderText = "Nombre"
            DGrid.Columns(3).HeaderText = "Estatus"
            DGrid.Columns(4).HeaderText = "Importe de Venta"
            DGrid.Columns(5).HeaderText = "      %"
            DGrid.Columns(6).HeaderText = "Transacciones"
            DGrid.Columns(7).HeaderText = "Suma %"
            DGrid.Columns(8).HeaderText = "Venta Promedio"
            DGrid.Columns(9).HeaderText = "Limite de Credito"
            DGrid.Columns(10).HeaderText = "Disponible"
            DGrid.Columns(11).HeaderText = "80"
            DGrid.Columns(12).HeaderText = "20"

            DGrid.Columns(9).DisplayIndex = 4
            DGrid.Columns(10).DisplayIndex = 5
            DGrid.Columns(8).DisplayIndex = 6
            DGrid.Columns(6).DisplayIndex = 10
            DGrid.Columns(0).ReadOnly = True
            DGrid.Columns(1).ReadOnly = True
            DGrid.Columns(2).ReadOnly = True
            DGrid.Columns(3).ReadOnly = True
            DGrid.Columns(4).ReadOnly = True
            DGrid.Columns(5).ReadOnly = True
            DGrid.Columns(6).ReadOnly = True
            DGrid.Columns(7).ReadOnly = True
            DGrid.Columns(8).ReadOnly = True
            DGrid.Columns(9).ReadOnly = True
            DGrid.Columns(10).ReadOnly = True
            DGrid.Columns(11).Visible = False
            DGrid.Columns(12).Visible = False

            DGrid.Columns(4).DefaultCellStyle.Format = "c"
            'DGrid.Columns(7).DefaultCellStyle.Format = "c"
            DGrid.Columns(8).DefaultCellStyle.Format = "c"
            DGrid.Columns(9).DefaultCellStyle.Format = "c"
            DGrid.Columns(10).DefaultCellStyle.Format = "c"
            DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            DGrid.Rows(0).Frozen = True
            DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Sub InicializaGrid2()
        '' ro 20-3-2013
        Try
            Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
            Dim row As DataRow = dt.NewRow()
            'row(1) = "Total: "
            row(9) = pub_SumaColumnaGrid(DGrid, 9, DGrid.RowCount - 1)
            dt.Rows.InsertAt(row, 0)
            DGrid.DataSource = dt

            DGrid.RowHeadersVisible = False
            DGrid.Columns(0).HeaderText = "Sucursal"
            DGrid.Columns(1).HeaderText = "Nota"
            DGrid.Columns(2).HeaderText = "Estatus"
            DGrid.Columns(3).HeaderText = "Negocio"
            DGrid.Columns(4).HeaderText = "Vale"
            DGrid.Columns(5).HeaderText = "Descripción"
            DGrid.Columns(6).HeaderText = "Distribuidor"
            DGrid.Columns(7).HeaderText = "Cliente"
            DGrid.Columns(8).HeaderText = "Fecha de Venta"
            DGrid.Columns(9).HeaderText = "Importe"
            DGrid.Columns(10).HeaderText = "Quincenas"
            DGrid.Columns(11).HeaderText = "Usuario"

            For i As Integer = 1 To DGrid.Rows.Count - 2
                DGrid.Rows(i).Cells("fecha").Value = CDate(DGrid.Rows(i).Cells("fecha").Value).ToString("dd-MMM-yyyy").ToUpper
            Next

            DGrid.Columns(0).ReadOnly = True
            DGrid.Columns(1).ReadOnly = True
            DGrid.Columns(2).ReadOnly = True
            DGrid.Columns(3).ReadOnly = True
            DGrid.Columns(4).ReadOnly = True
            DGrid.Columns(5).ReadOnly = True
            DGrid.Columns(6).ReadOnly = True
            DGrid.Columns(7).ReadOnly = True
            DGrid.Columns(8).ReadOnly = True
            DGrid.Columns(9).ReadOnly = True
            DGrid.Columns(10).ReadOnly = True
            DGrid.Columns(11).ReadOnly = True

            DGrid.Columns(9).DefaultCellStyle.Format = "c"

            DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            DGrid.Rows(0).Frozen = True
            DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Sub InicializaGrid3()
        '' ro 20-3-2013
        Try

            Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
            Dim row As DataRow = dt.NewRow()
            'row(1) = "Total: "
            row(5) = pub_SumaColumnaGrid(DGrid, 5, DGrid.RowCount - 1)
            row(6) = pub_SumaColumnaGrid(DGrid, 6, DGrid.RowCount - 1)
            dt.Rows.InsertAt(row, 0)
            DGrid.DataSource = dt

            DGrid.RowHeadersVisible = False
            DGrid.Columns(0).HeaderText = "Venta"
            DGrid.Columns(1).HeaderText = "Marca"
            DGrid.Columns(2).HeaderText = "Modelo"
            DGrid.Columns(3).HeaderText = "EstiloF"
            DGrid.Columns(4).HeaderText = "Serie"
            DGrid.Columns(5).HeaderText = "Precio"
            DGrid.Columns(6).HeaderText = "Importe"
            DGrid.Columns(7).HeaderText = "Usuario"
            DGrid.Columns(8).HeaderText = "Fecha"
            DGrid.Columns(9).HeaderText = "Hora"

            DGrid.Columns(0).ReadOnly = True
            DGrid.Columns(1).ReadOnly = True
            DGrid.Columns(2).ReadOnly = True
            DGrid.Columns(3).ReadOnly = True
            DGrid.Columns(4).ReadOnly = True
            DGrid.Columns(5).ReadOnly = True
            DGrid.Columns(6).ReadOnly = True
            DGrid.Columns(7).ReadOnly = True
            DGrid.Columns(8).ReadOnly = True
            DGrid.Columns(9).ReadOnly = True

            DGrid.Columns(5).DefaultCellStyle.Format = "c"
            DGrid.Columns(6).DefaultCellStyle.Format = "c"

            DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            DGrid.Rows(0).Frozen = True
            DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Sub InicializaGrid4()
        '' ro 20-3-2013
        Try
            renglon2 = 0
            renglon20 = 0
            renglolprom = 0
            Dim total As Double
            Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
            Dim row As DataRow = dt.NewRow()
            total = pub_SumaColumnaGrid(DGrid, 4, DGrid.RowCount - 1)
            row(4) = total
            suma = pub_SumaColumnaGrid2(DGrid, 5, DGrid.RowCount - 1)
            suma = pub_SumaColumnaGrid4(DGrid, 4, DGrid.RowCount - 1)
            txt_suma.Text = suma.ToString("C")
            sumat2 = pub_SumaColumnaGrid3(DGrid, 4, DGrid.RowCount - 1)
            txt_suma20.Text = sumat2.ToString("C")
            row(5) = "100"
            dt.Rows.InsertAt(row, 0)
            DGrid.DataSource = dt
            promedio80 = suma / renglon2 'dias
            promedio20 = sumat2 / renglon20 'dias
            promedioT = total / renglolprom 'dias

            Using objVenta As New BCL.BCLReporteVentas(GLB_ConStringCrvSis)
                objDataSet = objVenta.usp_PpalReporteVentas(3, 1, fechaA, fechaB, "", "", "")
            End Using
            DGrid.DataSource = objDataSet.Tables(0)
            Dim dt2 As DataTable = TryCast(DGrid.DataSource, DataTable)
            Dim row2 As DataRow = dt2.NewRow()
            Dim row3 As DataRow = dt2.NewRow()
            Dim row4 As DataRow = dt2.NewRow()

            With row2
                .Item(0) = renglolprom
                .Item(1) = total.ToString("C")
                .Item(2) = "100"
                .Item(3) = promedioT.ToString("C")
                '
            End With
            With row3
                .Item(0) = renglon2
                .Item(1) = suma.ToString("C")
                .Item(2) = "80"
                .Item(3) = promedio80.ToString("C")
                '
            End With
            With row4
                .Item(0) = renglon20
                .Item(1) = sumat2.ToString("C")
                .Item(2) = "20"
                .Item(3) = promedio20.ToString("C")
                '
            End With

            dt2.Rows.Add(row2)
            dt2.Rows.Add(row3)
            dt2.Rows.Add(row4)
            DGrid.DataSource = dt2
            DGrid.RowHeadersVisible = False
            renglon2 = 0
            renglon20 = 0
            renglolprom = 0
            DGrid.Columns(0).HeaderText = "No. Distribuidores"
            DGrid.Columns(1).HeaderText = "Importe de Venta"
            DGrid.Columns(2).HeaderText = "      %"
            DGrid.Columns(3).HeaderText = "Venta Promedio"


            DGrid.Columns(0).ReadOnly = True
            DGrid.Columns(1).ReadOnly = True
            DGrid.Columns(2).ReadOnly = True
            DGrid.Columns(3).ReadOnly = True

            DGrid.Columns(0).DefaultCellStyle.Format = "c"
            DGrid.Columns(2).DefaultCellStyle.Format = "c"

            DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub DGrid_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGrid.CellFormatting
        Try
            'If entrar = False Then Exit Sub
            If Datagrid = 2 Then Exit Sub
            If Me.DGrid.Columns(e.ColumnIndex).Name <> "impventa" Then Exit Sub
            If e.RowIndex >= DGrid.RowCount Then
                If Sw_Load = False Then
                    Sw_Pintar = False
                End If
                Exit Sub
            End If
            If DGrid.Rows(e.RowIndex).Index >= 1 Then
                If accionmostrar = 1 Then
                    If DGrid.Rows(e.RowIndex).Cells(5).RowIndex >= 1 Then
                        DGrid.Rows(e.RowIndex).Cells("impventa").Style.BackColor = Color.PowderBlue
                        DGrid.Rows(e.RowIndex).Cells("impventa").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                    End If
                ElseIf accionmostrar = 2 Then

                Else
                    If DGrid.Rows(e.RowIndex).Cells(5).RowIndex >= 1 And DGrid.Rows(e.RowIndex).Cells(5).RowIndex <= renglon2 Then
                        DGrid.Rows(e.RowIndex).Cells("impventa").Style.BackColor = Color.PowderBlue
                        DGrid.Rows(e.RowIndex).Cells("impventa").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                    End If
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub
    Private Sub DGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.Click
        If Not IsDBNull(DGrid.Rows(DGrid.CurrentRow.Index).Cells(0).Value) Then
            CargarFotoArticulo(DGrid.Rows(DGrid.CurrentRow.Index).Cells(1).Value, DGrid.Rows(DGrid.CurrentRow.Index).Cells(2).Value)
        End If

        'CargarFotoArticulo(DGrid.Rows(DGrid.CurrentRow.Index).Cells(1).Value, DGrid.Rows(DGrid.CurrentRow.Index).Cells(2).Value)
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
    Private Sub DGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick
        If yano = False Then
            If opcion = 3 Then
                Call RellenaGrid2(DGrid.Item(1, DGrid.CurrentRow.Index).Value().ToString)
            ElseIf opcion = 2 Then
                Call RellenaGrid3(DGrid.Item(0, DGrid.CurrentRow.Index).Value().ToString, DGrid.Item(1, DGrid.CurrentRow.Index).Value().ToString)
            Else
                Sw_NoRegistros = False
                'If DGrid.CurrentRow.Index = 0 Then
                ren = DGrid.CurrentRow.Index
                Call RellenaGrid(DGrid.CurrentRow.Index)

                'End If

            End If
        End If

    End Sub
    Private Sub CalculaPorcentaje()
        'Dim ctdvales As Integer = 0
        Try
            For i As Integer = 1 To DGrid.Rows.Count - 2
                DGrid.Rows(i).Cells(4).Value = Format(Math.Round((DGrid.Rows(i).Cells(3).Value / DGrid.Rows(0).Cells(3).Value) * 100, 2), "#0.00")
                porcent = pub_SumaColumnaGrid(DGrid, 4, DGrid.RowCount - 1)

                'suma = pub_SumaColumnaGrid(DGrid, 3, DGrid.RowCount - 1)


                If porcent >= 80 Then
                    renglon2 = DGrid.Rows(i).Index
                    suma20 = pub_SumaColumnaGrid3(DGrid, 3, renglon2)
                    txt_suma20.Text = suma20.ToString("C")
                Else
                    renglon = DGrid.Rows(i).Index
                    suma = pub_SumaColumnaGrid2(DGrid, 3, renglon)
                    txt_suma.Text = suma.ToString("C")
                End If
            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Public Function pub_SumaColumnaGrid5(ByVal DGrid As DataGridView, ByVal Columna As Integer, Optional ByVal HastaRenglon As Integer = 0) As Decimal
        'mreyes 14/Febrero/2012 05:08 p.m.
        Try
            ' Dim Col As Integer = DGrid.CurrentCell.ColumnIndex
            pub_SumaColumnaGrid5 = 0
            For renglon As Integer = 1 To IIf(HastaRenglon = 0, DGrid.RowCount, HastaRenglon)  'renglon2 + 1
                'If IsNumeric(DGrid.Rows(renglon).Cells(Columna).Value > 0) Then
                If DGrid.Rows(renglon).Cells(Columna).Value > 0 Then
                    pub_SumaColumnaGrid5 = (DGrid.Rows(renglon).Cells(Columna).Value) + pub_SumaColumnaGrid5
                End If
            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function
    Public Function pub_SumaColumnaGrid(ByVal DGrid As DataGridView, ByVal Columna As Integer, Optional ByVal HastaRenglon As Integer = 0) As Decimal
        'mreyes 14/Febrero/2012 05:08 p.m.
        Try
            Dim Col As Integer = DGrid.CurrentCell.ColumnIndex
            pub_SumaColumnaGrid = 0
            For renglon As Integer = 0 To IIf(HastaRenglon = 0, DGrid.RowCount - 1, HastaRenglon)
                If DGrid.Rows(renglon).Cells(Columna).Value > 0 Then
                    pub_SumaColumnaGrid = (DGrid.Rows(renglon).Cells(Columna).Value) + pub_SumaColumnaGrid
                End If
                If DGrid.Rows(renglon).Cells(Columna).Value < 0 Then
                    pub_SumaColumnaGrid = pub_SumaColumnaGrid + DGrid.Rows(renglon).Cells(Columna).Value
                End If

            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function
    Public Function pub_SumaColumnaGrid2(ByVal DGrid As DataGridView, ByVal Columna As Integer, Optional ByVal HastaRenglon As Integer = 0) As Decimal
        'mreyes 14/Febrero/2012 05:08 p.m.
        Try
            Dim Col As Integer = DGrid.CurrentCell.ColumnIndex
            pub_SumaColumnaGrid2 = 0
            For renglon As Integer = 0 To IIf(HastaRenglon = 0, DGrid.RowCount, HastaRenglon)
                If DGrid.Rows(renglon).Cells(Columna).Value > 0 Then
                    pub_SumaColumnaGrid2 = (DGrid.Rows(renglon).Cells(Columna).Value) + pub_SumaColumnaGrid2
                End If
                If DGrid.Rows(renglon).Cells(Columna).Value < 0 Then
                    pub_SumaColumnaGrid2 = pub_SumaColumnaGrid2 + DGrid.Rows(renglon).Cells(Columna).Value
                End If
                renglolprom = DGrid.Rows(renglon).Index + 1
                If pub_SumaColumnaGrid2 <= 80 Then
                    renglon2 = DGrid.Rows(renglon).Index + 1
                    'renglon2 = renglon2 + 1
                    suma80 = pub_SumaColumnaGrid2
                Else
                    renglon20 = renglon20 + 1
                End If
            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function
    Public Function pub_SumaColumnaGrid4(ByVal DGrid As DataGridView, ByVal Columna As Integer, Optional ByVal HastaRenglon As Integer = 0) As Decimal
        'mreyes 14/Febrero/2012 05:08 p.m.
        Try
            Dim Col As Integer = DGrid.CurrentCell.ColumnIndex
            pub_SumaColumnaGrid4 = 0
            For renglon As Integer = 0 To renglon2 - 1
                'If IsNumeric(DGrid.Rows(renglon).Cells(Columna).Value > 0) Then
                If DGrid.Rows(renglon).Cells(Columna).Value > 0 Then
                    pub_SumaColumnaGrid4 = (DGrid.Rows(renglon).Cells(Columna).Value) + pub_SumaColumnaGrid4
                End If
                If DGrid.Rows(renglon).Cells(Columna).Value < 0 Then
                    pub_SumaColumnaGrid4 = pub_SumaColumnaGrid4 + DGrid.Rows(renglon).Cells(Columna).Value
                End If
                'If pub_SumaColumnaGrid4 <= 80 Then
                '    renglon2 = DGrid.Rows(renglon).Index
                '    suma80 = pub_SumaColumnaGrid4
                'End If
            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function
    Public Function pub_SumaColumnaGrid3(ByVal DGrid As DataGridView, ByVal Columna As Integer, Optional ByVal HastaRenglon As Integer = 0) As Decimal
        'mreyes 14/Febrero/2012 05:08 p.m.
        Try
            Dim Col As Integer = DGrid.CurrentCell.ColumnIndex
            pub_SumaColumnaGrid3 = 0
            For renglon1 As Integer = renglon2 To IIf(HastaRenglon = 0, DGrid.RowCount, HastaRenglon)
                'If IsNumeric(DGrid.Rows(renglon).Cells(Columna).Value > 0) Then
                If DGrid.Rows(renglon1).Cells(Columna).Value > 0 Then
                    pub_SumaColumnaGrid3 = (DGrid.Rows(renglon1).Cells(Columna).Value) + pub_SumaColumnaGrid3
                End If
                If DGrid.Rows(renglon1).Cells(Columna).Value < 0 Then
                    pub_SumaColumnaGrid3 = pub_SumaColumnaGrid3 + DGrid.Rows(renglon1).Cells(Columna).Value
                End If

            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function
    Private Sub Btn_Salir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Me.Close()
        Me.Dispose()
    End Sub
    Private Sub Btn_Excel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Excel.Click
        Try
            If ExportarDGridAExcel(DGrid) = False Then
                MsgBox("Error al exportar a Excel. Intente nuevamente.", MsgBoxStyle.Critical, "Excel")
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Btn_Filtro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        Try
            Dim myform As New frmFiltrosReporteVentas

            myform.ShowDialog()
            filtro = True
            filtrar = True
            fechaA = myform.DTPicker1.Value
            fechaB = myform.DTPicker2.Value
            fechaA2 = fechaA
            fechaB2 = fechaB
            accion = 1
            '----------------------
            If myform.Sw_Filtro = True Then
                If Datagrid = 1 Then
                    Call RellenaGrid(3)
                Else
                    Sw_NoRegistros = False
                    Call RellenaGrid4()
                End If

            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Imprimir.Click
        Try
            Call ImprimirReporteVentas()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub ImprimirReporteVentas()
        Try
            Dim myForm As New frmReportsBrowser
            If opcion = 3 Then
                myForm.objDataSetReporteVentas = GenerarReporte()
                myForm.ReportIndex = 23
                myForm.Show()
            ElseIf opcion = 2 Then
                myForm.objDataSetReporteVentas = GenerarReporte()
                myForm.ReportIndex = 24
                myForm.Show()
            Else
                myForm.objDataSetReporteVentas = GenerarReporte()
                myForm.ReportIndex = 25
                myForm.Show()

            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Function GenerarReporte() As DSPReporteVentas2
        'Roberto 04/03/13
        Try
            If opcion = 3 Then
                GenerarReporte = New DSPReporteVentas2
                With DGrid
                    For I As Integer = 0 To .RowCount - 2
                        Dim objDataRow As Data.DataRow = GenerarReporte.Tables(0).NewRow()
                        objDataRow.Item("contador") = .Rows(I).Cells(0).Value
                        objDataRow.Item("distrib") = .Rows(I).Cells(1).Value
                        objDataRow.Item("nombre") = .Rows(I).Cells(2).Value
                        objDataRow.Item("status") = .Rows(I).Cells(3).Value
                        objDataRow.Item("impventa") = .Rows(I).Cells(4).Value
                        objDataRow.Item("porcent") = .Rows(I).Cells(5).Value
                        objDataRow.Item("notas") = .Rows(I).Cells(6).Value
                        objDataRow.Item("sumaporcent") = .Rows(I).Cells(7).Value
                        objDataRow.Item("promedio") = .Rows(I).Cells(8).Value
                        objDataRow.Item("limcred") = .Rows(I).Cells(9).Value
                        objDataRow.Item("disponible") = .Rows(I).Cells(10).Value
                        GenerarReporte.Tables(0).Rows.Add(objDataRow)
                    Next
                End With
            ElseIf opcion = 2 Then
                GenerarReporte = New DSPReporteVentas2
                With DGrid
                    For I As Integer = 0 To .RowCount - 2
                        Dim objDataRow As Data.DataRow = GenerarReporte.Tables(1).NewRow()

                        objDataRow.Item("fecha") = .Rows(I).Cells(0).Value
                        objDataRow.Item("sucursal") = .Rows(I).Cells(1).Value
                        objDataRow.Item("nota") = .Rows(I).Cells(2).Value
                        objDataRow.Item("cliente") = .Rows(I).Cells(3).Value
                        objDataRow.Item("nombre") = .Rows(I).Cells(4).Value
                        objDataRow.Item("importe") = .Rows(I).Cells(5).Value
                        'objDataRow.Item("nompromotor") = objDataSet.Tables(0).Rows(I).Item("nompromotor").ToString
                        GenerarReporte.Tables(1).Rows.Add(objDataRow)
                    Next
                End With
            Else
                GenerarReporte = New DSPReporteVentas2
                With DGrid
                    For I As Integer = 0 To .RowCount - 2
                        Dim objDataRow As Data.DataRow = GenerarReporte.Tables(2).NewRow()

                        objDataRow.Item("marca") = .Rows(I).Cells(0).Value
                        objDataRow.Item("estilon") = .Rows(I).Cells(1).Value
                        objDataRow.Item("estilof") = .Rows(I).Cells(2).Value
                        objDataRow.Item("serie") = .Rows(I).Cells(3).Value
                        objDataRow.Item("precio") = .Rows(I).Cells(4).Value
                        objDataRow.Item("importe") = .Rows(I).Cells(5).Value
                        'objDataRow.Item("nompromotor") = objDataSet.Tables(0).Rows(I).Item("nompromotor").ToString
                        GenerarReporte.Tables(2).Rows.Add(objDataRow)
                    Next
                End With
            End If

            'ext
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function
 
    Private Sub DGrid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGrid.KeyUp
        CargarFotoArticulo(DGrid.Rows(DGrid.CurrentRow.Index).Cells(1).Value, DGrid.Rows(DGrid.CurrentRow.Index).Cells(2).Value)
    End Sub
    Private Sub Btn_CPersonal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_CPersonal.Click
        empleado = 1
        Call RellenaGrid4()
    End Sub
    Private Sub Btn_Distribs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Distribs.Click
        empleado = 0
        Call RellenaGrid4()
    End Sub

    Private Sub Btn_Regresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Regresar.Click
        If opcion = 1 Then
            Sw_NoRegistros = False
            Call RellenaGrid2(distrib2)
            PBox.Visible = False
        ElseIf opcion = 2 Then
            If filtro = True Then
                accion = 1
                Sw_NoRegistros = False
                fechaA = fechaA2
                fechaB = fechaB2
                Call RellenaGrid(ren)
                'filtro = False
            Else
                accion = 3
                Sw_NoRegistros = False
                Call RellenaGrid(ren)
                filtrar = False
            End If
        ElseIf opcion = 3 Then
            If filtro = True Then
                accion = 1
                'Sw_NoRegistros = False
                fechaA = fechaA2
                fechaB = fechaB2
                Call RellenaGrid4()
                filtro = True
            Else
                accion = 3
                Call RellenaGrid4()
                'filtro = True
                filtrar = False
            End If
        Else
            accion = 3
            Call RellenaGrid(3)
            'filtro = False
            filtrar = False
        End If
    End Sub

    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub

    Private Sub Pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub

    Private Sub PBox_Click(sender As Object, e As EventArgs) Handles PBox.Click

    End Sub
End Class