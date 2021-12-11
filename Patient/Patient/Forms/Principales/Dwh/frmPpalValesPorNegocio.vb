Public Class frmPpalValesPorNegocio
    'Tony García - 20/Noviembre/2012 12:20 p.m.

    Private objDataSet As Data.DataSet
    Private FechaInicio As String
    Private FechaFin As String

    Dim Sw_Load As Boolean = True
    Dim Sw_NoRegistros As Boolean = False
    Dim Sw_Pintar As Boolean = False
    Dim blnPorc As Boolean = False
    Dim blnRefrescar As Boolean = False
    Dim blnPrimero As Boolean = False
    Dim SucursalB
    Dim SucursalB2
    Dim NotaB As String
    Dim EstatusB As String
    Dim ValeB As String
    Dim DistribuidorB As String
    Dim ClienteB As String


    Dim Opcion As Integer = 0

    Private Sub frmPpalNumValesPorNegocio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dt_Inicio.MinDate = CDate("1995-01-01")
        dt_Fin.MinDate = CDate("1995-01-01")
        dt_Inicio.MaxDate = Now.Date
        dt_Fin.MaxDate = Now.Date
        Cbo_Sucursal.Text = "00 - TODAS"
        DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        Call LimpiarBusqueda()
        Call RellenaGrid(Opcion)
        Sw_Pintar = True
        'Sw_Load = False 
    End Sub

    Private Sub frmPpalConceptoRep_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Sw_NoRegistros = False Then Exit Sub
        'If Sw_Load = True Then
        '    Sw_Load = False
        blnPrimero = True
        InicializaGrid()
        'AgregarColumna()
        '    Call BarrerGrid()
        'End If
    End Sub

    Private Sub LimpiarBusqueda()
        FechaInicio = Date.Now
        FechaFin = Date.Now
        SucursalB = ""
    End Sub

    Private Sub ObtenerSucursal()
        If Cbo_Sucursal.Text = "00 - TODAS" Then
            SucursalB = ""
        ElseIf Cbo_Sucursal.Text = "01 - JUAREZ" Then
            SucursalB = "01"
        ElseIf Cbo_Sucursal.Text = "02 - HIDALGO" Then
            SucursalB = "02"
        ElseIf Cbo_Sucursal.Text = "03 - VICTORIA" Then
            SucursalB = "03"
        ElseIf Cbo_Sucursal.Text = "04 - HAMBURGO" Then
            SucursalB = "04"
        ElseIf Cbo_Sucursal.Text = "05 - 4 CAMINOS" Then
            SucursalB = "05"
        ElseIf Cbo_Sucursal.Text = "06 - TRIANA" Then
            SucursalB = "06"
        ElseIf Cbo_Sucursal.Text = "07 - LERDO" Then
            SucursalB = "07"
        ElseIf Cbo_Sucursal.Text = "08 - MATRIZ" Then
            SucursalB = "08"
        ElseIf Cbo_Sucursal.Text = "33 - CAPA DE OZONO" Then
            SucursalB = "33"
        ElseIf Cbo_Sucursal.Text = "34 - OZONO 4 CAMINOS" Then
            SucursalB = "34"
        End If
    End Sub

    Private Sub AgregarColumna()
        Try
            Dim colPorcentaje As DataGridViewColumn = New DataGridViewColumn()
            colPorcentaje.Name = "Porc"
            colPorcentaje.HeaderText = "%"
            colPorcentaje.DisplayIndex = 3
            colPorcentaje.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            colPorcentaje.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            colPorcentaje.CellTemplate = DGrid.Columns(0).CellTemplate


            'colPorcentaje.DefaultCellStyle.Format = "%"
            'colPorcentaje.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

            Me.DGrid.Columns.Add(colPorcentaje)

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub CalculaPorcentaje()
        'Dim ctdvales As Integer = 0
        Try
            For i As Integer = 0 To DGrid.Rows.Count - 2
                DGrid.Rows(i).Cells(3).Value = Format(Math.Round((DGrid.Rows(i).Cells(2).Value / DGrid.Rows(DGrid.Rows.Count - 2).Cells(2).Value) * 100, 2), "#0.00")
                'DGrid.Rows(i).Cells(3).Value = Math.Round((DGrid.Rows(i).Cells(2).Value / DGrid.Rows(DGrid.Rows.Count - 2).Cells(2).Value) * 100, 2)
            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub RellenaGrid(ByVal Opcion As Integer)
        'Tony Garcia - 20/Octubre/2012 
        Using objValesPorNEgocio As New BCL.BCLValesPorNegocio(GLB_ConStringCrvSis)

            Try
                Me.Cursor = Cursors.WaitCursor
                'DGrid.ReadOnly = True

                DGrid.DataSource = Nothing
                If Opcion = 2 Then

                    If GLB_CveSucursal <> "" Then
                        objDataSet = objValesPorNEgocio.usp_PpalDiarioVales(GLB_CveSucursal, NotaB, EstatusB, ValeB, DistribuidorB, ClienteB, FechaInicio, FechaFin)
                    Else
                        objDataSet = objValesPorNEgocio.usp_PpalDiarioVales(SucursalB, "", "", "", "", "", FechaInicio, FechaFin)
                    End If

                ElseIf Opcion = 1 Then
                    objDataSet = objValesPorNEgocio.usp_TraerCtdValesPorNegocio(SucursalB, FechaInicio, FechaFin)
                ElseIf Opcion = 0 Then
                    objDataSet = objValesPorNEgocio.usp_TraerCtdValesPorSucursal(SucursalB, FechaInicio, FechaFin)
                End If


                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section

                    DGrid.DataSource = objDataSet.Tables(0)
                    'If Sw_Load = False Then
                    InicializaGrid()
                    'End If
                    'LimpiarBusqueda()
                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True
                    Sw_NoRegistros = True
                    Sw_Pintar = True
                    'Call Colores()
                Else
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    'MsgBox("No se encontraron registros que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                End If
                Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Sub InicializaGrid()

        Try
            If blnPorc = True And Sw_NoRegistros = True Then
                DGrid.Columns.Remove("Porc")
            End If
            'If blnRefrescar = False Then
            Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)


            If blnPrimero = False Then
                If Opcion <> 2 Then
                    'Dim row As DataRow = dt.NewRow()
                    Dim row As DataRow = dt.NewRow()

                    row(1) = "Total: "
                    ' ''row(7) = pub_SumarColumnaGrid(DGrid, 7, DGrid.RowCount - 1)
                    ' ''row(8) = pub_SumarColumnaGrid(DGrid, 8, DGrid.RowCount - 1)
                    'row(9) = pub_SumarColumnaGrid(DGrid, 9, DGrid.RowCount - 1)
                    row(2) = pub_SumarColumnaGrid(DGrid, 2, DGrid.RowCount - 1)


                    'dt.Rows.InsertAt(row, 0)
                    'DGrid.DataSource = dt
                    dt.Rows.Add(row)
                    DGrid.DataSource = dt
                    'End If


                    'Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
                    'Dim row As DataRow = dt.NewRow()

                    'row(0) = ""

                    'row(2) = pub_SumaColumnaGrid(DGrid, 2, DGrid.RowCount - 1)
                    'row(3) = pub_SumaColumnaGrid(DGrid, 3, DGrid.RowCount - 1)
                    'row(4) = pub_SumaColumnaGrid(DGrid, 4, DGrid.RowCount - 1)
                    'row(6) = pub_SumaColumnaGrid(DGrid, 6, DGrid.RowCount - 1)
                    'row(7) = pub_SumaColumnaGrid(DGrid, 7, DGrid.RowCount - 1)
                    'row(8) = pub_SumaColumnaGrid(DGrid, 8, DGrid.RowCount - 1)
                    'row(9) = pub_SumaColumnaGrid(DGrid, 9, DGrid.RowCount - 1)

                    'dt.Rows.InsertAt(row, 0)
                    'DGrid.DataSource = dt

                End If
            End If

            DGrid.RowHeadersVisible = False
            If Opcion = 0 Then
                DGrid.Columns(0).HeaderText = "Det"
            ElseIf Opcion = 1 Then
                DGrid.Columns(0).HeaderText = "Id Negocio"
            End If
            If Opcion <> 2 Then
                DGrid.Columns(1).HeaderText = "Descripción"
                DGrid.Columns(2).HeaderText = "N° Vales"
            End If
            'DGrid.Columns(0).Visible = False

            DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            If Opcion = 2 Then
                DGrid.Columns(8).DefaultCellStyle.Format = "c"
                DGrid.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If

            If Opcion = 0 Or Opcion = 1 Then
                DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            Else
                DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.BackColor = Color.White
                DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Regular)

            End If
            'If blnPorc = False Then
            If Opcion <> 2 Then
                Call AgregarColumna()
                blnPorc = True
                'End If 
                Call CalculaPorcentaje()

                For i As Integer = 0 To DGrid.Rows.Count - 1
                    For j As Integer = 0 To DGrid.Columns.Count - 1
                        DGrid.Columns(j).ReadOnly = True
                    Next

                Next
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

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

    Private Sub frmPpalPedidoNuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Bot_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bot_Aceptar.Click
        Try
            blnPrimero = False
            blnPorc = True
            SucursalB = ""
            DGrid.DataSource = Nothing
            DGrid.Refresh()
            DGrid.Rows.Clear()
            Opcion = 0


            FechaInicio = dt_Inicio.Value.Date.ToString("yyyy-MM-dd")
            FechaFin = dt_Fin.Value.ToString("yyyy-MM-dd")

            If FechaFin > Now.Date.ToString("yyyy-MM-dd") Then
                MessageBox.Show("La fecha final no debe ser mayor al dia de hoy", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dt_Fin.Focus()
                Exit Sub
            End If
            If FechaInicio > FechaFin Then
                MessageBox.Show("La fecha de inicio debe ser menor a la fecha final", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dt_Inicio.Focus()
                Exit Sub
            End If
            'blnRefrescar = True
            Call RellenaGrid(Opcion)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Cbo_Sucursal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo_Sucursal.SelectedIndexChanged
        Try
            Call ObtenerSucursal()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Cbo_Sucursal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cbo_Sucursal.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DGrid_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick
        Try
            If Opcion < 2 Then
                Opcion = Opcion + 1
                If Opcion = 1 Then
                    blnPrimero = False
                    SucursalB = DGrid.Item(0, DGrid.CurrentRow.Index).Value().ToString()
                    SucursalB2 = SucursalB
                    ValeB = ""
                    'blnPorc = False
                Else
                    SucursalB = SucursalB2
                    ValeB = DGrid.Item(0, DGrid.CurrentRow.Index).Value().ToString()
                    blnPorc = False
                End If
                RellenaGrid(Opcion)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub btn_volver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_volver.Click
        Try
            Opcion = 0
            blnPorc = True
            SucursalB = ""
            blnPrimero = False

            DGrid.DataSource = Nothing
            DGrid.Refresh()
            DGrid.Rows.Clear()


            FechaInicio = dt_Inicio.Value.Date.ToString("yyyy-MM-dd")
            FechaFin = dt_Fin.Value.ToString("yyyy-MM-dd")

            If FechaFin > Now.Date.ToString("yyyy-MM-dd") Then
                MessageBox.Show("La fecha final no debe ser mayor al dia de hoy", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dt_Fin.Focus()
                Exit Sub
            End If
            If FechaInicio > FechaFin Then
                MessageBox.Show("La fecha de inicio debe ser menor a la fecha final", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dt_Inicio.Focus()
                Exit Sub
            End If
            'blnRefrescar = True
            Call RellenaGrid(Opcion)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
End Class