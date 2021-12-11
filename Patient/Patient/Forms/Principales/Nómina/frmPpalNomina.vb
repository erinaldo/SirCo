Public Class frmPpalNomina
    'mreyes 30/Junio/2012 10:20 a.m.

    Private objDataSet As Data.DataSet
    Dim Sw_NoRegistros As Boolean = False
    Dim idEmpleadoB As Integer = 0
    Dim SucursalB As String = ""
    Dim IdDeptoB As Integer = 0
    Dim IdPuestoB As Integer = 0
    Dim FechaIniB As String = ""

    Dim idPercDeducB As Integer = 0
    Dim IdPeriodoB As String = ""
    Public TipoNomB As String = ""


    Dim Sw_Pintar As Boolean = False
    Dim Sw_Load As Boolean = True
    Dim Opcion As Integer = 1
    Dim Periodo As Integer = IIf(TipoNomB = "A", 453, pub_TraerUltimoPeriodo(2, "A"))

    Private Sub frmPpalNomina_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated


        'If Sw_Load = True Then
        '    If Sw_NoRegistros = False Then
        '        Sw_Load = False
        '    Else
        '        Sw_Load = False
        '    End If
        'End If
        If GLB_RefrescarPedido = True Then
            GLB_RefrescarPedido = False
            Call RellenaGrid()
            Me.WindowState = FormWindowState.Maximized
        End If

        'If Sw_NoRegistros = False Then Exit Sub
        'If Sw_Load = True Then
        '    Sw_Load = False
        '    InicializaGrid()
        '    '    Call BarrerGrid()
        'End If

        If Sw_Load = True Then
            If Sw_NoRegistros = False Then
                Sw_Load = False
                'InicializaGrid()

            Else
                If Sw_Load = True Then
                    '  Colores()
                End If
                Sw_Load = False
                If TipoNomB = "A" Then
                    InicializaGrid1()
                Else
                    InicializaGrid()
                End If

                'Sw_NoRegistros = False
            End If
        End If

    End Sub

    Private Sub frmPpalProveedores_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If

        If e.KeyCode = Keys.F5 Then
            Call Btn_Filtro_Click_1(sender, e)
        End If
    End Sub

    Private Sub frmPpalProveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Sw_Load = True
            GLB_RefrescarPedido = False
            Opcion = 3

            Call LimpiarBusqueda()

            Call RellenaGrid()
            Call GenerarToolTip()
            Sw_Pintar = True
            If TipoNomB = "A" Then
                Btn_Filtro.Enabled = False
                Chk_Aguinaldo.Visible = True
                Chk_AguiTemp.Visible = True

            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Nomina, "Indicador por Tipo de Nómina")
            ToolTip.SetToolTip(Btn_Sucursal, "Indicador de Nómina por Sucursal")
            ToolTip.SetToolTip(Btn_Empleado, "Nómina por Empleado")
            ToolTip.SetToolTip(Btn_PercDeduc, "Nómina por tipo de concepto")
            ToolTip.SetToolTip(Btn_Filtro, "Búsqueda Avanzada")
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
            ToolTip.SetToolTip(Btn_Imprimir, "Imprimir Información")
            ToolTip.SetToolTip(Btn_Salir, "Salir")
            ToolTip.SetToolTip(Btn_ImprimirRpt, "Detallado de Nómina GRAN BONO")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Function usp_EliminarNomina(ByVal IdPeriodo As Integer, ByVal TipoNom As String, ByVal Sucursal As String, ByVal IdEmpleado As Integer) As Boolean
        'mreyes 22/Agosto/2012 11:27 p.m.

        Using objNomina As New BCL.BCLNomina(GLB_ConStringNomSis)
            Try
                'Get the specific project selected in the ListView control
                usp_EliminarNomina = objNomina.usp_EliminarNomina(2, IdPeriodo, TipoNom, Sucursal, IdEmpleado)
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    'Private Sub Colores()
    '    Try
    '        Dim periodo As Integer = 0
    '        Dim TipoNom As String = ""
    '        Dim color1 As System.Drawing.Color
    '        color1 = Color.SandyBrown

    '        For J As Integer = 0 To DGrid.RowCount - 3
    '            If Not IsDBNull(DGrid.Rows(J).Cells("idperiodo").Value) Then
    '                If periodo <> Val(DGrid.Rows(J).Cells("idperiodo").Value) Then
    '                    If J <> 0 Then
    '                        If color1 = Color.Salmon Then
    '                            color1 = Color.SandyBrown
    '                        Else
    '                            color1 = Color.Salmon
    '                        End If
    '                        DGrid.Rows(J).DefaultCellStyle.BackColor = color1
    '                    Else
    '                        color1 = Color.SandyBrown
    '                        DGrid.Rows(J).DefaultCellStyle.BackColor = color1
    '                    End If
    '                    periodo = DGrid.Rows(J).Cells("idperiodo").Value
    '                Else
    '                    'If TipoNom <> DGrid.Rows(J).Cells("tiponom").Value Then
    '                    '    If color1 = Color.Salmon Then
    '                    '        color1 = Color.SandyBrown
    '                    '    Else
    '                    '        color1 = Color.Salmon
    '                    '    End If
    '                    'End If
    '                    DGrid.Rows(J).DefaultCellStyle.BackColor = color1
    '                    periodo = DGrid.Rows(J).Cells("idperiodo").Value
    '                End If
    '            End If

    '        Next
    '    Catch ExceptionErr As Exception
    '        MessageBox.Show(ExceptionErr.Message.ToString)
    '    End Try
    'End Sub
    Private Sub RellenaGrid(Optional ByVal BanBajio As Integer = 0)
        'mreyes 30/Junio/2012   10:34 a.m.
        Using objRegistro As New BCL.BCLNomina(GLB_ConStringNomSis)

            Try
                Me.Cursor = Cursors.WaitCursor
                DGrid.ReadOnly = False
                DGrid.DataSource = Nothing
                Dim FechaIniAgui As Date = "1950-01-01"
                Dim FechaFinAgui As Date = "2020-11-30"

                If Sw_Load = True Then
                    ' Sw_Load = False

                Else

                    If Sw_NoRegistros = True Then
                        DGrid.Columns.Remove("Selec")

                    End If

                End If

                If Chk_AguiTemp.Checked = True Then
                    FechaIniAgui = "2020-12-01"
                    FechaFinAgui = "2020-12-31"
                Else
                    FechaIniAgui = "1950-01-01"
                    FechaFinAgui = "2020-11-30"
                End If
                'Modif Miguel Perez, Tony Garcia 29/Ago/2012
                ''''''''''''''''''
                If Opcion = 4 Then
                    objDataSet = objRegistro.usp_PpalNominaPercdeduc(IdPeriodoB, TipoNomB, idEmpleadoB, SucursalB, IdDeptoB, IdPuestoB)
                Else
                    If TipoNomB = "A" Then
                        IdPeriodoB = "INSERT INTO periodotemp (idperiodo1) VALUES (453);"
                        objDataSet = objRegistro.usp_PpalAguinaldo(Opcion, IdPeriodoB, TipoNomB, idEmpleadoB, SucursalB, IdDeptoB, IdPuestoB, 0, FechaIniAgui, FechaFinAgui)
                    Else
                        If TipoNomB = "F" Then
                            objDataSet = objRegistro.usp_PpalNominaFiscal(Opcion, IdPeriodoB, TipoNomB, idEmpleadoB, SucursalB, IdDeptoB, IdPuestoB, BanBajio)
                        Else
                            objDataSet = objRegistro.usp_PpalNominaBono(Opcion, IdPeriodoB, TipoNomB, idEmpleadoB, SucursalB, IdDeptoB, IdPuestoB)
                        End If
                    End If
                End If
                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section

                    DGrid.DataSource = objDataSet.Tables(0)
                    If Sw_Load = False Then
                        If TipoNomB = "A" Then
                            InicializaGrid1()
                        Else
                            InicializaGrid()
                        End If

                    End If
                    'LimpiarBusqueda()
                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True
                    Btn_Sucursal.Enabled = True
                    Btn_PercDeduc.Enabled = True
                    Sw_NoRegistros = True
                    Sw_Pintar = True

                    'Call Colores()

                Else

                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron Nóminas Calculadas que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                    Btn_Sucursal.Enabled = False
                    Btn_PercDeduc.Enabled = False
                    If Sw_Load = True Then Sw_Load = False
                End If
                Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using


    End Sub


    Private Sub RellenaBanBajio()
        'mreyes 15/Julio/2015   10:16 a.m.
        Using objRegistro As New BCL.BCLNomina(GLB_ConStringNomSis)

            Try
                Me.Cursor = Cursors.WaitCursor
                DGrid.ReadOnly = False
                DGrid.DataSource = Nothing
               
                ''''''''''''''''''
                objDataSet = objRegistro.usp_PpalNominaBanBajio(Opcion, IdPeriodoB, TipoNomB, idEmpleadoB, SucursalB, IdDeptoB, IdPuestoB, 1)
                      
                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section

                    DGrid.DataSource = objDataSet.Tables(0)
                   
                    'LimpiarBusqueda()
                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True
                    Btn_Sucursal.Enabled = True
                    Btn_PercDeduc.Enabled = True
                    Sw_NoRegistros = True
                    Sw_Pintar = True


                Else

                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron Nóminas Calculadas que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                    Btn_Sucursal.Enabled = False
                    Btn_PercDeduc.Enabled = False
                    If Sw_Load = True Then Sw_Load = False
                End If
                Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using


    End Sub
    Private Sub LimpiarBusqueda()

        '"INSERT INTO periodotemp (idperiodo1) VALUES (4),(5),(6);"
        idEmpleadoB = 0
        'traer ultimo periodo abierto de nómina. 
        IdPeriodoB = "INSERT INTO periodotemp (idperiodo1) VALUES (" & Periodo & ");"
        'TipoNomB = ""
        IdDeptoB = 0
        IdPuestoB = 0
        SucursalB = ""
        FechaIniB = ""

    End Sub

    Private Sub Btn_Refrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Sub InicializaGrid1()
        'mreyes 30/Junio/2012 10:47 a.m.
        Try



            Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)

            Dim row As DataRow = dt.NewRow()


            row(3) = "Total: "
            If Opcion <> 4 Then
                row(9) = pub_SumarColumnaGrid(DGrid, 9, DGrid.RowCount - 1)
                row(10) = pub_SumarColumnaGrid(DGrid, 10, DGrid.RowCount - 1)
                row(11) = pub_SumarColumnaGrid(DGrid, 11, DGrid.RowCount - 1)
                row(12) = pub_SumarColumnaGrid(DGrid, 12, DGrid.RowCount - 1)

                row(13) = pub_SumarColumnaGrid(DGrid, 13, DGrid.RowCount - 1)
                row(14) = pub_SumarColumnaGrid(DGrid, 14, DGrid.RowCount - 1)
                row(15) = pub_SumarColumnaGrid(DGrid, 15, DGrid.RowCount - 1)
                row(16) = pub_SumarColumnaGrid(DGrid, 16, DGrid.RowCount - 1)
                row(17) = pub_SumarColumnaGrid(DGrid, 17, DGrid.RowCount - 1)
                row(18) = pub_SumarColumnaGrid(DGrid, 18, DGrid.RowCount - 1)
                row(19) = pub_SumarColumnaGrid(DGrid, 19, DGrid.RowCount - 1)
                row(20) = pub_SumarColumnaGrid(DGrid, 20, DGrid.RowCount - 1)
            Else
                row(4) = pub_SumarColumnaGrid(DGrid, 4, DGrid.RowCount - 1)
            End If
            'dt.Rows.Add(row)
            'DGrid.DataSource = dt

            dt.Rows.InsertAt(row, 0)
            DGrid.DataSource = dt


            DGrid.RowHeadersVisible = False
            DGrid.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, 7, FontStyle.Regular)
            'Modif Miguel Perez, Tony Garcia 5:30pm
            ''''''''''''''''''''''''''''''''''''''''''
            If Opcion = 4 Then
                DGrid.Columns(0).HeaderText = "IdPeriodo"
                DGrid.Columns(1).HeaderText = "Fecha Inicio"
                DGrid.Columns(2).HeaderText = "Fecha Fin"
                DGrid.Columns(3).HeaderText = "Concepto"
                DGrid.Columns(4).HeaderText = "Total"
                DGrid.Columns(0).Visible = False

            End If
            '''''''''''''''''''''''''''''''''''''''''''
            If Opcion <> 4 Then
                DGrid.Columns(0).HeaderText = "IdPeriodo"
                DGrid.Columns(1).HeaderText = "Fecha Inicio"
                DGrid.Columns(2).HeaderText = "Fecha Fin"
                DGrid.Columns(3).HeaderText = "Tipo Nómina"
                DGrid.Columns(4).HeaderText = "Sucursal"
                DGrid.Columns(5).HeaderText = "IdEmpleado"
                DGrid.Columns(6).HeaderText = "Nombre Completo"
                DGrid.Columns(7).HeaderText = "Departamento"
                DGrid.Columns(8).HeaderText = "Puesto"
                DGrid.Columns(9).HeaderText = IIf(TipoNomB = "B", "Gran Bono", "Días Trab.")
                DGrid.Columns(10).HeaderText = IIf(TipoNomB = "B", "Prima Dom.", "Falta")

                DGrid.Columns(11).HeaderText = IIf(TipoNomB = "B", "Des. Trab.", "Subsidio")
                DGrid.Columns(12).HeaderText = IIf(TipoNomB = "B", "Festivo", "Seguro")
                DGrid.Columns(13).HeaderText = IIf(TipoNomB = "B", "Extras", "Compras")
                DGrid.Columns(14).HeaderText = IIf(TipoNomB = "B", "Retardo", "Infonavit")
                DGrid.Columns(15).HeaderText = IIf(TipoNomB = "F", "Vac.", "Comp.")
                DGrid.Columns(16).HeaderText = "O.Percep."
                DGrid.Columns(17).HeaderText = "O.Deduc."
                DGrid.Columns(18).HeaderText = IIf(TipoNomB = "B", "Deduc.", "Fonacot")
                DGrid.Columns(19).HeaderText = IIf(TipoNomB = "F", "Prestamo", "Mater.")

                DGrid.Columns(20).HeaderText = "Total"

                DGrid.Columns(21).HeaderText = "Cuenta"
                DGrid.Columns(22).HeaderText = "PagosDec"
                DGrid.Columns(23).HeaderText = "NomLayout"
                DGrid.Columns(24).HeaderText = "FecLayout"
                DGrid.Columns(25).HeaderText = "RFC"
                DGrid.Columns(26).HeaderText = "SDiario"
                DGrid.Columns(27).HeaderText = "Ingreso"
                DGrid.Columns(28).HeaderText = "IMSS"
                DGrid.Columns(29).HeaderText = "FrecPago"
                DGrid.Columns(30).HeaderText = "Sucursal"
                DGrid.Columns(31).HeaderText = "Estatus"

                DGrid.Columns(0).Visible = False
                DGrid.Columns(31).Visible = False

                DGrid.Columns(4).Visible = True
                If Chk_VerDepto.Checked = False Then
                    DGrid.Columns(7).Visible = False
                End If
                If Opcion = 1 Or Opcion = 2 Then
                    If Opcion = 1 Then
                        DGrid.Columns(4).Visible = False
                    End If
                    DGrid.Columns(5).Visible = False
                    DGrid.Columns(6).Visible = False
                    DGrid.Columns(7).Visible = False
                    DGrid.Columns(8).Visible = False
                    ' DGrid.Columns(9).Visible = False
                    ' DGrid.Columns(10).Visible = False
                Else
                    If Chk_IdEmpleado.Checked = True Then
                        DGrid.Columns(5).Visible = True
                    End If
                End If

                If TipoNomB = "A" Then
                    DGrid.Columns(10).Visible = False
                    DGrid.Columns(11).Visible = False
                    DGrid.Columns(12).Visible = False
                    DGrid.Columns(13).Visible = False
                    DGrid.Columns(14).Visible = False
                    DGrid.Columns(15).Visible = False
                    DGrid.Columns(16).Visible = False
                    DGrid.Columns(17).Visible = False
                    DGrid.Columns(18).Visible = False
                    DGrid.Columns(19).Visible = False
                End If

                DGrid.Columns(16).Visible = False
                DGrid.Columns(17).Visible = False

                DGrid.Columns(21).Visible = False
                DGrid.Columns(22).Visible = False
                DGrid.Columns(23).Visible = False
                DGrid.Columns(24).Visible = False
                DGrid.Columns(25).Visible = False
                DGrid.Columns(26).Visible = False
                DGrid.Columns(27).Visible = False
                DGrid.Columns(28).Visible = False
                DGrid.Columns(29).Visible = False
                DGrid.Columns(30).Visible = False

                DGrid.Columns(5).Visible = False

                DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                DGrid.Columns(9).DefaultCellStyle.Format = "c"
                DGrid.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(10).DefaultCellStyle.Format = "c"
                DGrid.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(11).DefaultCellStyle.Format = "c"
                DGrid.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DGrid.Columns(12).DefaultCellStyle.Format = "c"
                DGrid.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(13).DefaultCellStyle.Format = "c"
                DGrid.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(14).DefaultCellStyle.Format = "c"
                DGrid.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(15).DefaultCellStyle.Format = "c"
                DGrid.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(16).DefaultCellStyle.Format = "c"
                DGrid.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(17).DefaultCellStyle.Format = "c"
                DGrid.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(18).DefaultCellStyle.Format = "c"
                DGrid.Columns(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(19).DefaultCellStyle.Format = "c"
                DGrid.Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(20).DefaultCellStyle.Format = "c"
                DGrid.Columns(20).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Else
                DGrid.Columns(4).DefaultCellStyle.Format = "c"
                DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            'DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.BackColor = Color.PowderBlue
            'DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            'DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

            DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)



            Call AgregarColumna()
            For i As Integer = 0 To DGrid.ColumnCount - 1

                DGrid.Columns(i).ReadOnly = True
            Next
            DGrid.Columns("Selec").ReadOnly = False

            If TipoNomB = "F" Then
                'VISTAS
                DGrid.Columns(15).DisplayIndex = 11
                DGrid.Columns(10).DisplayIndex = 16


            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Sub InicializaGrid()
        'mreyes 15/Abril/2015 10:30 a.m.
        Try



            Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)

            Dim row As DataRow = dt.NewRow()


            row(3) = "Total: "
            If Opcion <> 4 Then
                row(9) = pub_SumarColumnaGrid(DGrid, 9, DGrid.RowCount - 1)
                row(10) = pub_SumarColumnaGrid(DGrid, 10, DGrid.RowCount - 1)
                row(11) = pub_SumarColumnaGrid(DGrid, 11, DGrid.RowCount - 1)
                row(12) = pub_SumarColumnaGrid(DGrid, 12, DGrid.RowCount - 1)

                row(13) = pub_SumarColumnaGrid(DGrid, 13, DGrid.RowCount - 1)
                row(14) = pub_SumarColumnaGrid(DGrid, 14, DGrid.RowCount - 1)
                row(15) = pub_SumarColumnaGrid(DGrid, 15, DGrid.RowCount - 1)
                row(16) = pub_SumarColumnaGrid(DGrid, 16, DGrid.RowCount - 1)
                row(17) = pub_SumarColumnaGrid(DGrid, 17, DGrid.RowCount - 1)
                row(18) = pub_SumarColumnaGrid(DGrid, 18, DGrid.RowCount - 1)
                row(19) = pub_SumarColumnaGrid(DGrid, 19, DGrid.RowCount - 1)
                row(20) = pub_SumarColumnaGrid(DGrid, 20, DGrid.RowCount - 1)
                row(21) = pub_SumarColumnaGrid(DGrid, 21, DGrid.RowCount - 1)
                row(26) = pub_SumarColumnaGrid(DGrid, 26, DGrid.RowCount - 1)
                row(38) = pub_SumarColumnaGrid(DGrid, 38, DGrid.RowCount - 1)


                If TipoNomB = "B" Then
                    row(22) = pub_SumarColumnaGrid(DGrid, 22, DGrid.RowCount - 1)
                    row(23) = pub_SumarColumnaGrid(DGrid, 23, DGrid.RowCount - 1)
                    row(24) = pub_SumarColumnaGrid(DGrid, 24, DGrid.RowCount - 1)
                    row(25) = pub_SumarColumnaGrid(DGrid, 25, DGrid.RowCount - 1)

                End If
            Else
                row(4) = pub_SumarColumnaGrid(DGrid, 4, DGrid.RowCount - 1)
            End If
            'dt.Rows.Add(row)
            'DGrid.DataSource = dt

            dt.Rows.InsertAt(row, 0)
            DGrid.DataSource = dt


            DGrid.RowHeadersVisible = False
            DGrid.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, 7, FontStyle.Regular)

            DGrid.Columns(0).Frozen = True
            DGrid.Columns(1).Frozen = True
            DGrid.Columns(2).Frozen = True
            DGrid.Columns(3).Frozen = True
            DGrid.Columns(4).Frozen = True
            DGrid.Columns(5).Frozen = True
            DGrid.Columns(6).Frozen = True
            DGrid.Columns(7).Frozen = True
            DGrid.Columns(8).Frozen = True



            If Opcion = 4 Then
                DGrid.Columns(0).HeaderText = "IdPeriodo"
                DGrid.Columns(1).HeaderText = "Fecha Inicio"
                DGrid.Columns(2).HeaderText = "Fecha Fin"
                DGrid.Columns(3).HeaderText = "Concepto"
                DGrid.Columns(4).HeaderText = "Total"
                DGrid.Columns(0).Visible = False

            End If
            '''''''''''''''''''''''''''''''''''''''''''
            If Opcion <> 4 Then
                DGrid.Columns(0).HeaderText = "IdPeriodo"
                DGrid.Columns(1).HeaderText = "Fecha Inicio"
                DGrid.Columns(2).HeaderText = "Fecha Fin"
                DGrid.Columns(3).HeaderText = "Tipo Nómina"
                DGrid.Columns(4).HeaderText = "Sucursal"
                DGrid.Columns(5).HeaderText = "IdEmpleado"
                DGrid.Columns(6).HeaderText = "Nombre Completo"
                DGrid.Columns(7).HeaderText = "Departamento"
                DGrid.Columns(8).HeaderText = "Puesto"
                DGrid.Columns(9).HeaderText = IIf(TipoNomB = "B", "Gran Bono", "Días Trab.")
                DGrid.Columns(10).HeaderText = IIf(TipoNomB = "B", "Prima Dom.", "Vacaciones")
                'Des. Trab.
                DGrid.Columns(11).HeaderText = IIf(TipoNomB = "B", "Vacaciones", "PVacacional")
                DGrid.Columns(12).HeaderText = IIf(TipoNomB = "B", "PVacacional", "Subsidio")
                DGrid.Columns(13).HeaderText = IIf(TipoNomB = "B", "Des. Trab.", "Compensacion")
                DGrid.Columns(14).HeaderText = IIf(TipoNomB = "B", "Festivo", "Seguro")
                DGrid.Columns(15).HeaderText = IIf(TipoNomB = "F", "Infonavit", "Compensación")
                DGrid.Columns(16).HeaderText = IIf(TipoNomB = "B", "Maternidad", "Fonacot")
                DGrid.Columns(17).HeaderText = IIf(TipoNomB = "B", "Com Gestor", "Compras")
                DGrid.Columns(18).HeaderText = IIf(TipoNomB = "B", "Retardo", "Faltas")
                DGrid.Columns(19).HeaderText = IIf(TipoNomB = "F", "Prestamo", "Sanción")

                DGrid.Columns(20).HeaderText = IIf(TipoNomB = "B", "Compras", "Faltante")
                DGrid.Columns(21).HeaderText = IIf(TipoNomB = "B", "Especie", "Incapacidad")


                If TipoNomB = "F" Then
                    DGrid.Columns(22).Visible = False
                    DGrid.Columns(23).Visible = False
                    DGrid.Columns(24).Visible = False
                    DGrid.Columns(25).Visible = False
                Else
                    DGrid.Columns(22).HeaderText = "Uniformes"
                    DGrid.Columns(23).HeaderText = "Prestamos"
                    DGrid.Columns(24).HeaderText = "Faltante"
                    DGrid.Columns(25).HeaderText = "Inventario"

                End If

                DGrid.Columns(26).HeaderText = "Total"

                DGrid.Columns(27).HeaderText = "Cuenta"
                DGrid.Columns(28).HeaderText = "PagosDec"
                DGrid.Columns(29).HeaderText = "NomLayout"
                DGrid.Columns(30).HeaderText = "FecLayout"
                DGrid.Columns(31).HeaderText = "RFC"
                DGrid.Columns(32).HeaderText = "SDiario"
                DGrid.Columns(33).HeaderText = "Ingreso"
                DGrid.Columns(34).HeaderText = "IMSS"
                DGrid.Columns(35).HeaderText = "FrecPago"
                DGrid.Columns(36).HeaderText = "Sucursal"
                DGrid.Columns(37).HeaderText = "Estatus"


                'PROBAR COLUMNA PARA FISCAL
                DGrid.Columns(38).HeaderText = "Prima Dom."
                If TipoNomB = "F" Then
                    DGrid.Columns(38).DisplayIndex = 10
                    DGrid.Columns(38).DefaultCellStyle.Format = "c"
                    DGrid.Columns(38).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Else
                    DGrid.Columns(38).Visible = False

                End If

                DGrid.Columns(0).Visible = False
                DGrid.Columns(35).Visible = False

                DGrid.Columns(4).Visible = True
                If Chk_VerDepto.Checked = False Then
                    DGrid.Columns(7).Visible = False
                End If
                If Opcion = 1 Or Opcion = 2 Then
                    If Opcion = 1 Then
                        DGrid.Columns(4).Visible = False
                    End If
                    DGrid.Columns(5).Visible = False
                    DGrid.Columns(6).Visible = False
                    DGrid.Columns(7).Visible = False
                    DGrid.Columns(8).Visible = False
                    ' DGrid.Columns(9).Visible = False
                    ' DGrid.Columns(10).Visible = False
                Else
                    If Chk_IdEmpleado.Checked = True Then
                        DGrid.Columns(5).Visible = True
                    End If
                End If

                If TipoNomB = "A" Then
                    DGrid.Columns(10).Visible = False
                    DGrid.Columns(11).Visible = False
                    DGrid.Columns(12).Visible = False
                    DGrid.Columns(13).Visible = False
                    DGrid.Columns(14).Visible = False
                    DGrid.Columns(15).Visible = False
                    DGrid.Columns(16).Visible = False
                    DGrid.Columns(17).Visible = False
                    DGrid.Columns(18).Visible = False
                    DGrid.Columns(19).Visible = False
                End If

                'DGrid.Columns(16).Visible = False
                'DGrid.Columns(17).Visible = False

              
                DGrid.Columns(27).Visible = False
                DGrid.Columns(28).Visible = False
                DGrid.Columns(29).Visible = False
                DGrid.Columns(30).Visible = False
                DGrid.Columns(31).Visible = False
                DGrid.Columns(32).Visible = False
                DGrid.Columns(33).Visible = False
                DGrid.Columns(34).Visible = False
                DGrid.Columns(35).Visible = False
                DGrid.Columns(36).Visible = False
                DGrid.Columns(37).Visible = False


                DGrid.Columns(5).Visible = False

                DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                DGrid.Columns(9).DefaultCellStyle.Format = "c"
                DGrid.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(10).DefaultCellStyle.Format = "c"
                DGrid.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(11).DefaultCellStyle.Format = "c"
                DGrid.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DGrid.Columns(12).DefaultCellStyle.Format = "c"
                DGrid.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(13).DefaultCellStyle.Format = "c"
                DGrid.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(14).DefaultCellStyle.Format = "c"
                DGrid.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(15).DefaultCellStyle.Format = "c"
                DGrid.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(16).DefaultCellStyle.Format = "c"
                DGrid.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(17).DefaultCellStyle.Format = "c"
                DGrid.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(18).DefaultCellStyle.Format = "c"
                DGrid.Columns(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(19).DefaultCellStyle.Format = "c"
                DGrid.Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(20).DefaultCellStyle.Format = "c"
                DGrid.Columns(20).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(21).DefaultCellStyle.Format = "c"
                DGrid.Columns(21).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DGrid.Columns(22).DefaultCellStyle.Format = "c"
                DGrid.Columns(22).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DGrid.Columns(23).DefaultCellStyle.Format = "c"
                DGrid.Columns(23).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(24).DefaultCellStyle.Format = "c"
                DGrid.Columns(24).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(25).DefaultCellStyle.Format = "c"
                DGrid.Columns(25).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(26).DefaultCellStyle.Format = "c"
                DGrid.Columns(26).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                

            Else
                DGrid.Columns(4).DefaultCellStyle.Format = "c"
                DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            'DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.BackColor = Color.PowderBlue
            'DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            'DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

            DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)



            Call AgregarColumna()
            For i As Integer = 0 To DGrid.ColumnCount - 1

                DGrid.Columns(i).ReadOnly = True
            Next
            DGrid.Columns("Selec").ReadOnly = False



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

    Private Sub Btn_Nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Nomina.Click
        Opcion = 1
        Call RellenaGrid()

    End Sub

    Private Sub DGrid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellDoubleClick

    End Sub

    Private Sub DGrid_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGrid.CellFormatting
        Try

            'mreyes 30/Junio/2012 10:59 a.m.
            If Opcion = 4 Then Exit Sub
            Dim Sw_NoEntro As Boolean = False

            Dim DiasEntrega As Integer = 0
            If Sw_Pintar = False Then Exit Sub

            If Me.DGrid.Columns(e.ColumnIndex).Name <> "pago" Then Exit Sub
            ''If Me.DGrid.Columns(e.ColumnIndex).Name <> "fecha" Then Exit Sub
            If e.RowIndex >= DGrid.RowCount - 2 Then
                If Sw_Load = False Then
                    Sw_Pintar = False
                End If
                Exit Sub
            End If


            If DGrid.Rows(e.RowIndex).Cells("pago").Value <= 0 Then
                DGrid.Rows(e.RowIndex).Cells("pago").Style.BackColor = Color.Red
                DGrid.Rows(e.RowIndex).Cells("pago").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If






        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub DGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick
        Try
            If Opcion = 1 Then  'total
                Opcion = 2
                'Opcion, IdPeriodoB, TipoNomB, idEmpleadoB, SucursalB, IdDeptoB, IdPuestoB
                '"INSERT INTO periodotemp (idperiodo1) VALUES " & myForm.Periodo & ";"
                If DGrid.Rows(DGrid.CurrentRow.Index).Cells(3).Value <> "Total: " Then
                    IdPeriodoB = "INSERT INTO periodotemp (idperiodo1) VALUES (" & DGrid.Rows(DGrid.CurrentRow.Index).Cells("idperiodo").Value & ");"
                    TipoNomB = Mid(DGrid.Rows(DGrid.CurrentRow.Index).Cells("tiponom").Value, 1, 1)
                End If
                Call RellenaGrid()
                Exit Sub

            End If
            If Opcion = 2 Then ' sucursal
                Opcion = 3
                If DGrid.Rows(DGrid.CurrentRow.Index).Cells(3).Value <> "Total: " Then
                    IdPeriodoB = "INSERT INTO periodotemp (idperiodo1) VALUES (" & DGrid.Rows(DGrid.CurrentRow.Index).Cells("idperiodo").Value & ");"
                    TipoNomB = Mid(DGrid.Rows(DGrid.CurrentRow.Index).Cells("tiponom").Value, 1, 1)
                    SucursalB = DGrid.Rows(DGrid.CurrentRow.Index).Cells("sucursal").Value
                End If
                Call RellenaGrid() 'empleados 
                Exit Sub

            End If
            If Opcion = 3 Then
                Call Consular(sender, e)
                Exit Sub
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DGrid.KeyPress
        'Try
        '    Call Btn_Consultar_Click(sender, e)
        'Catch ExceptionErr As Exception
        '    MessageBox.Show(ExceptionErr.Message.ToString)
        'End Try
    End Sub

    Private Sub Btn_Consultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_PercDeduc.Click
        Opcion = 4
        Call RellenaGrid()

    End Sub
    Private Sub Consular(ByVal sender, ByVal e)
        If Sw_NoRegistros = False Then Exit Sub

        Dim myForm As New frmPpalNominaDet
        myForm.Txt_idempleado.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idempleado").Value
        myForm.IdPeriodoB = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idperiodo").Value
        myForm.TipoNomB = Mid(DGrid.Rows(DGrid.CurrentRow.Index).Cells("tiponom").Value, 1, 1)
        myForm.Txt_Nomina.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("fechaini").Value & " - " & DGrid.Rows(DGrid.CurrentRow.Index).Cells("fechafin").Value
        If DGrid.Rows(DGrid.CurrentRow.Index).Cells("tiponom").Value = "AGUIBONO" Then
            myForm.Txt_TipoNom.Text = "G"
        Else
            myForm.Txt_TipoNom.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("tiponom").Value
        End If

        myForm.Text = myForm.Text & "-" & DGrid.Rows(DGrid.CurrentRow.Index).Cells("tiponom").Value
        myForm.Txt_RFC.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("rfc").Value
        myForm.Txt_NoIMSS.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("nomimss").Value
        myForm.Txt_Ingreso.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("ingreso").Value
        myForm.Txt_SDiario.Text = Format(DGrid.Rows(DGrid.CurrentRow.Index).Cells("sdiario").Value, "c")
        myForm.IdFrecPagob = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idfrecpago").Value
        myForm.estatus = DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value
        myForm.FechaIniB = DGrid.Rows(DGrid.CurrentRow.Index).Cells("fechaini").Value
        myForm.FechaFinB = DGrid.Rows(DGrid.CurrentRow.Index).Cells("fechafin").Value
        'If Mid(DGrid.Rows(DGrid.CurrentRow.Index).Cells("tiponom").Value, 1, 1) = "F" Then
        '    myForm.Txt_SDiario.Visible = False
        '    myForm.Lbl_SDiario.Visible = False
        'End If
        myForm.ShowDialog()
        If GLB_RefrescarPedido = True Then
            Call RellenaGrid()
        End If
    End Sub
    Private Sub Btn_Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Sucursal.Click
        Opcion = 2
        Call RellenaGrid()

    End Sub

    Private Sub Btn_Filtro_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        Dim myForm As New frmFiltrosNomina
        Dim Estatus As String = ""

        Dim TipoNomina = ""

        TipoNomina = ""
        If TipoNomB = "F" Then TipoNomina = "FISCAL"
        If TipoNomB = "A" Then TipoNomina = "AMBAS"
        If TipoNomB = "B" Then TipoNomina = "BONO"


        myForm.Txt_IdEmpleado.Text = idEmpleadoB
        ' myForm.Cbo_Periodo.ValueMember = IdPeriodoB
        myForm.Cbo_TipoNom.Text = TipoNomina

        myForm.Txt_Sucursal.Text = SUCURSALB
        myForm.Txt_IdDepto.Text = IDDEPTOB
        myForm.Txt_IdPuesto.Text = IDPUESTOB
        ' periodo 
        If Periodo > 0 Then
            myForm.SucSelect(0) = Periodo
            myForm.IntSelect = 1
        Else
            Periodo = 0
        End If
        ' myForm.Cbo_Estatus.Text = Estatus
        myForm.ShowDialog()
        idEmpleadoB = Val(myForm.Txt_IdEmpleado.Text)
        'IdPeriodoB = "INSERT INTO periodotemp (idperiodo1) VALUES (" & pub_TraerUltimoPeriodo(2) & ");"
        IdPeriodoB = "INSERT INTO periodotemp (idperiodo1) VALUES " & myForm.Periodo & ";"
        FechaIniB = myForm.FechaIniB
        TipoNomB = Mid(myForm.Cbo_TipoNom.Text, 1, 1)

        SucursalB = myForm.Txt_Sucursal.Text
        IdDeptoB = Val(myForm.Txt_IdDepto.Text)
        IdPuestoB = Val(myForm.Txt_IdPuesto.Text)



        If myForm.Sw_Filtro = True Then
            Call RellenaGrid()
        End If
    End Sub


    Private Sub NuevoProveedorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoProveedorToolStripMenuItem.Click
        Call Btn_Nuevo_Click(sender, e)
    End Sub

    Private Sub ModificarProveedorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarProveedorToolStripMenuItem.Click
        Call Btn_Editar_Click(sender, e)
    End Sub

    Private Sub ConsultarProveedorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultarProveedorToolStripMenuItem.Click
        Call Btn_Consultar_Click(sender, e)
    End Sub

    Private Sub Pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub

    Private Sub Btn_Layout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Layout.Click
        Try
            'mreyes 07/Julio/2012 10:26 a.m.
            If Opcion <> 3 Then
                MsgBox("No puede generar el layout, sino se encuentra en indicador por empleado.", MsgBoxStyle.Information, "Aviso")
                Exit Sub
            End If
            If TipoNomB = "B" Then
                MsgBox("No puede generar el layout, sino se encuentra en Nómina Fiscal o de Aguinaldo.", MsgBoxStyle.Information, "Aviso")

                Exit Sub
            End If
            If MsgBox("Esta seguro de querer generar el layout para el banco.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmación") = MsgBoxResult.No Then Exit Sub



            Dim Archivo As String = "c:\Layout\Banamex" & Replace(Replace(Format(Date.Now, "yyyy-MM-dd hh:mm:ss"), "-", ""), ":", "") & ".txt"
            Dim Linea As String = ""
            Dim Columna1 As String = "3000101001"
            Dim TTarjeta As String = "03"
            Dim pagosdec As String = ""
            Dim Cuenta As String = ""
            Dim Nombre As String = ""
            Dim FecLayout As String = ""

            Dim CuentaNos As String = "4001"
            Dim SumPago As Double = 0
            Dim SumPagoDec As String = ""
            Dim i As Integer
            Dim Cont As Integer = 0
            Dim FechaNomina = "22 de sep15D01"

            FechaNomina = Format(Date.Now, "dd") & " de " & Format(Date.Now, "MMM") & "15D01"

            '10000033079411209150066Calzado de Torreon SA de CV
            '210010000000000060002340100000000001327696463000118
            GLB_CLayout = pub_TraerParame_Det("CLAYOUT")
            Dim Encabezado As String = "1000003307941" & Format(Now.Date, "yyMMdd") & pub_RellenarIzquierda(GLB_CLayout, 4) & "Calzado de Torreon SA de CV         Nomina del " & FechaNomina
            Dim sw As New System.IO.StreamWriter(Archivo)
            Linea = Encabezado
            sw.WriteLine(Linea)
            Linea = Encabezado

            For i = 0 To DGrid.RowCount - 2
                ' CAST(Taller.cod_taller AS CHAR CHARACTER SET utf8 
                If DGrid.Rows(i).Cells("Selec").Value = True Then
                    If Not IsDBNull(DGrid.Rows(i).Cells("cuenta").Value) Then
                        If DGrid.Rows(i).Cells("cuenta").Value <> "" Then
                            If DGrid.Rows(i).Cells("pago").Value > 0 Then

                                SumPago = DGrid.Rows(i).Cells("pago").Value + SumPago

                                Cont = Cont + 1

                            End If
                        End If
                    End If
                End If
            Next
            SumPagoDec = pub_RellenarIzquierda(Replace(Math.Round(SumPago, 2), ".", ""), 18)
            Encabezado = "21001" & SumPagoDec & "0100000000001327696463000" & pub_RellenarIzquierda(Cont, 3)
            'Encabezado = "210010000000000060002340100000000001327696463000118"
            sw.WriteLine(Encabezado)
            SumPago = 0
            Cont = 0
            For i = 0 To DGrid.RowCount - 2
                ' CAST(Taller.cod_taller AS CHAR CHARACTER SET utf8 
                If DGrid.Rows(i).Cells("Selec").Value = True Then
                    If Not IsDBNull(DGrid.Rows(i).Cells("cuenta").Value) Then
                        If DGrid.Rows(i).Cells("cuenta").Value <> "" Then
                            If DGrid.Rows(i).Cells("pago").Value > 0 Then
                                Cuenta = DGrid.Rows(i).Cells("cuenta").Value & ""
                                Nombre = Replace(Trim(DGrid.Rows(i).Cells("nomlayout").Value & ""), "Ñ", "@")
                                Nombre = Replace(Nombre, ".", " ")
                                FecLayout = DGrid.Rows(i).Cells("feclayout").Value & ""
                                pagosdec = DGrid.Rows(i).Cells("pagosdec").Value & ""
                                SumPago = DGrid.Rows(i).Cells("pago").Value + SumPago
                                Linea = Columna1 & pagosdec & TTarjeta & pub_RellenarIzquierda(Cuenta, 20) & pub_RellenarEspaciosDerecha(Cont + 1, 16) & pub_RellenarEspaciosDerecha(Nombre, 195) & pub_RellenarEspaciosDerecha(FecLayout, 158)
                                '000000000000043683
                                Cont = Cont + 1
                                sw.WriteLine(Linea)
                            End If
                        End If
                    End If
                End If
            Next
            SumPagoDec = pub_RellenarIzquierda(Replace(Math.Round(SumPago, 2), ".", ""), 18)

            Linea = CuentaNos & pub_RellenarIzquierda(Cont, 6) & SumPagoDec & "000001" & SumPagoDec
            sw.WriteLine(Linea)
            sw.Close()
            If ActualizarParameDet("CLAYOUT", pub_RellenarIzquierda(Val(GLB_CLayout) + 1, 4)) Then

            End If

            MsgBox("Archivo creado en '" & Archivo & "')", MsgBoxStyle.Information, "Confirmación")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub GenerarArchivoBanBajio()
        Try
            'mreyes 16/Julio/2015   11:18 a.m.
            If Opcion <> 3 Then
                MsgBox("No puede generar el layout, sino se encuentra en indicador por empleado.", MsgBoxStyle.Information, "Aviso")
                Exit Sub
            End If
            If TipoNomB = "B" Then
                MsgBox("No puede generar el layout, sino se encuentra en Nómina Fiscal o de Aguinaldo.", MsgBoxStyle.Information, "Aviso")

                Exit Sub
            End If
            If MsgBox("Esta seguro de querer generar el layout para el banco.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmación") = MsgBoxResult.No Then Exit Sub



            Dim Archivo As String = "c:\NominaBB\D0s9n010." & Mid(Replace(Replace(Format(Date.Now, "yyyy-MM-dd hh:mm:ss"), "-", ""), ":", ""), Len(Replace(Replace(Format(Date.Now, "yyyy-MM-dd hh:mm:ss"), "-", ""), ":", "")) - 3)

            Dim Linea As String = ""
            Dim Columna1 As String = "3000101001"
            Dim TTarjeta As String = "03"
            Dim pagosdec As String = ""
            Dim Cuenta As String = ""
            Dim Nombre As String = ""
            Dim FecLayout As String = ""

            Dim CuentaNos As String = "4001"
            Dim SumPago As Double = 0
            Dim SumPagoDec As String = ""
            Dim i As Integer
            Dim Cont As Integer = 0
            Dim FechaNomina = "22 de sep15D01"

            FechaNomina = Format(Date.Now, "dd") & " de " & Format(Date.Now, "MMM") & "15D01"

            '10000033079411209150066Calzado de Torreon SA de CV
            '210010000000000060002340100000000001327696463000118
            GLB_CLayout = pub_TraerParame_Det("CLAYOUT")
            Dim Encabezado As String = "010000001030S9000000s9n" & Format(Date.Now, "yyyy") & Format(Date.Now, "mm") & Format(Date.Now, "dd") & "00000000108858790201"
            Dim sw As New System.IO.StreamWriter(Archivo)
            Linea = Encabezado
            sw.WriteLine(Linea)
            Linea = Encabezado

            For i = 0 To DGrid.RowCount - 2
                ' CAST(Taller.cod_taller AS CHAR CHARACTER SET utf8 
                If DGrid.Rows(i).Cells("Selec").Value = True Then
                    If Not IsDBNull(DGrid.Rows(i).Cells("cuenta").Value) Then
                        If DGrid.Rows(i).Cells("cuenta").Value <> "" Then
                            If DGrid.Rows(i).Cells("pago").Value > 0 Then

                                SumPago = DGrid.Rows(i).Cells("pago").Value + SumPago

                                Cont = Cont + 1

                            End If
                        End If
                    End If
                End If
            Next
            SumPagoDec = pub_RellenarIzquierda(Replace(Math.Round(SumPago, 2), ".", ""), 18)
            Encabezado = "21001" & SumPagoDec & "0100000000001327696463000" & pub_RellenarIzquierda(Cont, 3)
            'Encabezado = "210010000000000060002340100000000001327696463000118"
            sw.WriteLine(Encabezado)
            SumPago = 0
            Cont = 0



            For i = 0 To DGrid.RowCount - 2
                ' CAST(Taller.cod_taller AS CHAR CHARACTER SET utf8 
                If DGrid.Rows(i).Cells("Selec").Value = True Then
                    If Not IsDBNull(DGrid.Rows(i).Cells("cuenta").Value) Then
                        If DGrid.Rows(i).Cells("cuenta").Value <> "" Then
                            If DGrid.Rows(i).Cells("pago").Value > 0 Then
                                Cuenta = DGrid.Rows(i).Cells("cuenta").Value & ""
                                Nombre = Replace(Trim(DGrid.Rows(i).Cells("nomlayout").Value & ""), "Ñ", "@")
                                Nombre = Replace(Nombre, ".", " ")
                                FecLayout = DGrid.Rows(i).Cells("feclayout").Value & ""
                                pagosdec = DGrid.Rows(i).Cells("pagosdec").Value & ""
                                SumPago = DGrid.Rows(i).Cells("pago").Value + SumPago
                                Linea = Columna1 & pagosdec & TTarjeta & pub_RellenarIzquierda(Cuenta, 20) & pub_RellenarEspaciosDerecha(Cont + 1, 16) & pub_RellenarEspaciosDerecha(Nombre, 195) & pub_RellenarEspaciosDerecha(FecLayout, 158)
                                '000000000000043683
                                Cont = Cont + 1
                                sw.WriteLine(Linea)
                            End If
                        End If
                    End If
                End If
            Next
            SumPagoDec = pub_RellenarIzquierda(Replace(Math.Round(SumPago, 2), ".", ""), 18)

            Linea = CuentaNos & pub_RellenarIzquierda(Cont, 6) & SumPagoDec & "000001" & SumPagoDec
            sw.WriteLine(Linea)
            sw.Close()
            If ActualizarParameDet("CLAYOUT", pub_RellenarIzquierda(Val(GLB_CLayout) + 1, 4)) Then

            End If

            MsgBox("Archivo creado en '" & Archivo & "')", MsgBoxStyle.Information, "Confirmación")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Function ActualizarParameDet(ByVal Clave As String, ByVal Valor As String) As Boolean
        'mreyes 28/Septiembre/2012 11:23 a.m.

        Using objPedidos As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
            Try
                'Get the specific project selected in the ListView control
                ActualizarParameDet = objPedidos.usp_ActualizarParameDet(Clave, Valor)
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function
    Private Function GenerarDSReciboNomina(ByVal Sw_Todos As Boolean) As DSReciboNomina
        'mreyes 10/Junio/2012 06:23 p.m.
        Dim Deduccion As Decimal = 0
        Dim Percepcion As Decimal = 0
        Try

            GenerarDSReciboNomina = New DSReciboNomina
            With DGrid
                Application.DoEvents()
                Pnl_Bar.Visible = True
                LBL_PORC.Text = ""
                Pbar1.Value = 0
                Pbar1.Minimum = 0
                Pbar1.Maximum = .RowCount - 1
                Application.DoEvents()
                For I As Integer = 0 To .RowCount - 2
                    If (.Rows(I).Cells("Selec").Value = True Or Sw_Todos = True) And .Rows(I).Cells(3).Value <> "Total: " Then
                        'Generar Encabezado... 
                        Deduccion = 0
                        Percepcion = 0
                        If usp_TraerTotalPercDeduc(DGrid.Rows(I).Cells("idperiodo").Value, IIf(DGrid.Rows(I).Cells("tiponom").Value = "AGUIBONO", "G", DGrid.Rows(I).Cells("tiponom").Value), DGrid.Rows(I).Cells("idempleado").Value, Deduccion, Percepcion) = True Then


                            Dim objDataRow1 As Data.DataRow = GenerarDSReciboNomina.Tables("Tbl_Recibo").NewRow

                            objDataRow1.Item("FechaIni") = Format(DGrid.Rows(I).Cells("fechaini").Value, "yyyy-MM-dd")
                            objDataRow1.Item("FechaFin") = Format(DGrid.Rows(I).Cells("fechafin").Value, "yyyy-MM-dd")

                            objDataRow1.Item("idEmpleado") = DGrid.Rows(I).Cells("idempleado").Value
                            objDataRow1.Item("NombreCompleto") = DGrid.Rows(I).Cells("nomcompleto").Value
                            objDataRow1.Item("rfc") = DGrid.Rows(I).Cells("rfc").Value
                            objDataRow1.Item("depto") = DGrid.Rows(I).Cells("descripdepto").Value
                            objDataRow1.Item("puesto") = DGrid.Rows(I).Cells("descrippuesto").Value
                            objDataRow1.Item("sueldo") = Format(DGrid.Rows(I).Cells("sdiario").Value, "c")
                            objDataRow1.Item("tperc") = Format(Percepcion, "n2")
                            objDataRow1.Item("tdeduc") = Format(Deduccion, "n2")
                            objDataRow1.Item("total") = Format(Percepcion - Deduccion, "n2")
                            objDataRow1.Item("ingreso") = Format(DGrid.Rows(I).Cells("ingreso").Value, "yyyy-MM-dd")
                            objDataRow1.Item("noimss") = DGrid.Rows(I).Cells("nomimss").Value
                            objDataRow1.Item("SUCURSAL") = DGrid.Rows(I).Cells("descripsucursal").Value
                            GenerarDSReciboNomina.Tables("Tbl_Recibo").Rows.Add(objDataRow1)
                            'Termina Genera Encabezado.
                            'ir por el detallado de cada empleado, para conocer las percepc


                            Using objPedidos As New BCL.BCLNomina(GLB_ConStringNomSis)

                                Try
                                    objDataSet = objPedidos.usp_ReciboNominaDet(DGrid.Rows(I).Cells("idperiodo").Value, IIf(DGrid.Rows(I).Cells("tiponom").Value = "AGUIBONO", "G", DGrid.Rows(I).Cells("tiponom").Value), DGrid.Rows(I).Cells("idempleado").Value)

                                    If objDataSet.Tables(0).Rows.Count > 0 Then
                                        For j As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                                            Dim objDataRow As Data.DataRow = GenerarDSReciboNomina.Tables("Tbl_ReciboDet").NewRow
                                            objDataRow.Item("idempleado") = objDataSet.Tables(0).Rows(j).Item("idempleado").ToString
                                            objDataRow.Item("ren") = objDataSet.Tables(0).Rows(j).Item("consecutivo").ToString
                                            If objDataSet.Tables(0).Rows(j).Item("uniperc").ToString = "0" Then
                                                objDataRow.Item("uniperc") = ""
                                            Else
                                                objDataRow.Item("uniperc") = objDataSet.Tables(0).Rows(j).Item("uniperc").ToString
                                            End If

                                            If objDataSet.Tables(0).Rows(j).Item("descripperc").ToString = "" Then
                                                objDataRow.Item("DescripcionPerc") = ""
                                                objDataRow.Item("Gravable") = ""
                                                objDataRow.Item("Exento") = ""
                                            Else

                                                objDataRow.Item("DescripcionPerc") = objDataSet.Tables(0).Rows(j).Item("descripperc").ToString
                                                objDataRow.Item("Gravable") = Format(objDataSet.Tables(0).Rows(j).Item("gravable"), "N2")
                                                objDataRow.Item("Exento") = Format(objDataSet.Tables(0).Rows(j).Item("exento"), "N2")
                                            End If

                                            If objDataSet.Tables(0).Rows(j).Item("unideduc").ToString = "0" Then
                                                objDataRow.Item("unideduc") = ""
                                            Else
                                                objDataRow.Item("UniDeduc") = objDataSet.Tables(0).Rows(j).Item("unideduc").ToString
                                            End If

                                            'objDataRow.Item("DescripcionDeduc") = objDataSet.Tables(0).Rows(j).Item("descripdeduc").ToString
                                            'objDataRow.Item("Retencion") = objDataSet.Tables(0).Rows(j).Item("retencion").ToString
                                            'objDataRow.Item("Saldo") = objDataSet.Tables(0).Rows(j).Item("saldo").ToString
                                            If objDataSet.Tables(0).Rows(j).Item("descripdeduc").ToString = "" Then
                                                objDataRow.Item("DescripcionDeduc") = ""
                                                objDataRow.Item("Retencion") = ""
                                                objDataRow.Item("Saldo") = ""
                                            Else
                                                objDataRow.Item("DescripcionDeduc") = objDataSet.Tables(0).Rows(j).Item("descripdeduc").ToString
                                                objDataRow.Item("Retencion") = Format(objDataSet.Tables(0).Rows(j).Item("retencion"), "n2")
                                                'objDataRow.Item("Saldo") = Format(Val(objDataSet.Tables(0).Rows(j).Item("saldo")), "n2")
                                                If Val(objDataSet.Tables(0).Rows(j).Item("IDPERCDEDUC")) = 1 Then
                                                    objDataRow.Item("Saldo") = ""
                                                Else
                                                    objDataRow.Item("Saldo") = Format(objDataSet.Tables(0).Rows(j).Item("saldo"), "N2")
                                                End If
                                            End If
                                            GenerarDSReciboNomina.Tables("Tbl_ReciboDet").Rows.Add(objDataRow)
                                        Next
                                    End If




                                    '''' LLENAR DETALLADO DE ORDE COMP
                                Catch ExceptionErr As Exception
                                    MessageBox.Show(ExceptionErr.Message.ToString)
                                End Try
                            End Using

                        End If
                        Pbar1.Value = Pbar1.Value + 1
                        LBL_PORC.Text = I & " de " & .RowCount - 2
                        Application.DoEvents()
                    End If
                Next
            End With
            Pnl_Bar.Visible = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function
    Private Sub ImprimirReciboNomina(ByVal Sw_todos As Boolean)
        'mreyes 10/Julio/2012 06:22 p.m.
        Try
            Dim myForm As New frmReportsBrowser
            Dim Sw_Mas14 As Boolean = False
            Dim Cont As Integer = 0
            Dim Opcion As Integer = 4


            myForm.objDataSetReciboNomina = GenerarDSReciboNomina(Sw_todos)

            '            myForm.TextoColumna(0) = TextoColumna(0)


            ' termina calcular por orden de compra 

            myForm.ReportIndex = Opcion
            myForm.Show()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Imprimir.Click
        If Opcion <> 3 Then
            MsgBox("No puede emitir recibos, sino se encuentra en indicador por empleado.", MsgBoxStyle.Information, "Aviso")
            Exit Sub
        End If
        If MsgBox("Esta seguro de querer generar los recibos de nómina.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmación") = MsgBoxResult.No Then Exit Sub
        Me.Cursor = Cursors.AppStarting
        If TipoNomB = "F" Then
            Call ImprimirReciboNomina(False)
        ElseIf TipoNomB = "B" Then
            Call ImprimirReciboBono(False)
        Else
            TipoNomB = "G"
            Call ImprimirReciboNomina(False)
            'Call ImprimirReciboNomina(False)
            'Call ImprimirReciboBono(False)
        End If
        Me.Cursor = Cursors.Default

    End Sub
    Private Function GenerarDSReciboBono(ByVal Sw_Todos As Boolean) As DSReciboBono
        'mreyes 01/Septiembre/2012 07:12 p.m.
        Try
            '' Dim objDataSet As New DtReciboBono
            Dim Columna As Integer = 0
            Dim Cont As Integer = 0


            GenerarDSReciboBono = New DSReciboBono


            With DGrid
                Cont = 0

                For I As Integer = 0 To .RowCount - 2
                    If (.Rows(I).Cells("Selec").Value = True Or Sw_Todos = True) And .Rows(I).Cells(3).Value <> "Total:  " Then
                        Dim objDataRow1 As Data.DataRow = GenerarDSReciboBono.Tables("Tbl_ReciboBono").NewRow


                        objDataRow1.Item("Ren") = I
                        objDataRow1.Item("idempleado") = .Rows(I).Cells("idempleado").Value
                        'If .Rows(I).Cells("sucursal").Value <> "00" And .Rows(I).Cells("sucursal").Value <> "96" And .Rows(I).Cells("sucursal").Value <> "98" And .Rows(I).Cells("sucursal").Value <> "97" And .Rows(I).Cells("sucursal").Value <> "99" Then
                        ' objDataRow1.Item("nombrecompleto") = .Rows(I).Cells("nomcompleto").Value & "    Pago 1/2"
                        ' objDataRow1.Item("total") = .Rows(I).Cells("pago").Value * 0.5
                        'Else
                        objDataRow1.Item("nombrecompleto") = .Rows(I).Cells("nomcompleto").Value
                        objDataRow1.Item("total") = .Rows(I).Cells("pago").Value
                        'End If

                        objDataRow1.Item("fechaini") = .Rows(I).Cells("fechaini").Value
                        objDataRow1.Item("fechafin") = .Rows(I).Cells("fechafin").Value
                        objDataRow1.Item("sucursal") = .Rows(I).Cells("descripsucursal").Value

                        GenerarDSReciboBono.Tables("Tbl_ReciboBono").Rows.Add(objDataRow1)

                        '   If .Rows(I).Cells("sucursal").Value <> "00" And .Rows(I).Cells("sucursal").Value <> "96" And .Rows(I).Cells("sucursal").Value <> "98" And .Rows(I).Cells("sucursal").Value <> "97" And .Rows(I).Cells("sucursal").Value <> "99" Then
                        ' Dim objDataRow11 As Data.DataRow = GenerarDSReciboBono.Tables("Tbl_ReciboBono").NewRow
                        ' objDataRow11.Item("Ren") = I + 1
                        ' objDataRow11.Item("idempleado") = .Rows(I).Cells("idempleado").Value
                        ' objDataRow11.Item("nombrecompleto") = .Rows(I).Cells("nomcompleto").Value & "    Pago 2/2"
                        ' objDataRow11.Item("total") = .Rows(I).Cells("pago").Value * 0.5
                        ' objDataRow11.Item("fechaini") = .Rows(I).Cells("fechaini").Value
                        ' objDataRow11.Item("fechafin") = .Rows(I).Cells("fechafin").Value
                        ' objDataRow11.Item("sucursal") = .Rows(I).Cells("descripsucursal").Value
                        '
                        '                        GenerarDSReciboBono.Tables("Tbl_ReciboBono").Rows.Add(objDataRow11)
                        '                    End If
                    End If
                Next




            End With
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function


    Private Function GenerarDSNominaFiscal(ByVal Sw_Todos As Boolean) As DsPpalNomina
        'mreyes 15/Abril/2015   10:57 a.m.
        Try
            '' Dim objDataSet As New DtReciboBono
            Dim Columna As Integer = 0
            Dim Cont As Integer = 0


            GenerarDSNominaFiscal = New DsPpalNomina


            With DGrid
                Cont = 0

                For I As Integer = 0 To .RowCount - 2
                    If (.Rows(I).Cells("Selec").Value = True Or Sw_Todos = True) And .Rows(I).Cells(3).Value <> "Total: " Then
                        Dim objDataRow1 As Data.DataRow = GenerarDSNominaFiscal.Tables("Tbl_NominaBonos").NewRow
                        objDataRow1.Item("fechaini") = .Rows(I).Cells("fechaini").Value
                        objDataRow1.Item("fechafin") = .Rows(I).Cells("fechafin").Value
                        objDataRow1.Item("Ren") = I '+ 1
                        objDataRow1.Item("sucursal") = .Rows(I).Cells("sucursal").Value
                        objDataRow1.Item("descripsucursal") = .Rows(I).Cells("descripsucursal").Value
                        objDataRow1.Item("idempleado") = .Rows(I).Cells("idempleado").Value
                        objDataRow1.Item("nombrecompleto") = .Rows(I).Cells("nomcompleto").Value
                        objDataRow1.Item("descrippuesto") = .Rows(I).Cells("descrippuesto").Value
                        objDataRow1.Item("impdiastrab") = .Rows(I).Cells("impdiastrab").Value
                        'campos nuevos
                        objDataRow1.Item("vacaciones") = .Rows(I).Cells("vacaciones").Value
                        objDataRow1.Item("Pvacacional") = .Rows(I).Cells("Pvacacional").Value
                        objDataRow1.Item("subsidio") = .Rows(I).Cells("subsidio").Value
                        objDataRow1.Item("compensacion") = .Rows(I).Cells("compensacion").Value
                        objDataRow1.Item("seguro") = .Rows(I).Cells("seguro").Value

                        objDataRow1.Item("infonavit") = .Rows(I).Cells("infonavit").Value
                        objDataRow1.Item("fonacot") = .Rows(I).Cells("fonacot").Value

                        objDataRow1.Item("compras") = .Rows(I).Cells("compras").Value
                        objDataRow1.Item("faltas") = .Rows(I).Cells("faltas").Value
                        objDataRow1.Item("prestamos") = .Rows(I).Cells("prestamos").Value

                        objDataRow1.Item("faltante") = .Rows(I).Cells("faltante").Value
                        objDataRow1.Item("incapacidad") = .Rows(I).Cells("incapacidad").Value
                        objDataRow1.Item("pago") = .Rows(I).Cells("pago").Value '* 0.5

                        'mreyes 02/Marzo/2016   06:02 p.m. agregado prima dominical
                        objDataRow1.Item("impprima") = .Rows(I).Cells("impprima").Value

                        GenerarDSNominaFiscal.Tables("Tbl_NominaBonos").Rows.Add(objDataRow1)



                    End If
                Next




            End With
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function


    Private Function GenerarDSNominaBono(ByVal Sw_Todos As Boolean) As DsPpalNomina
        'mreyes 14/Septiembre/2012 11:55 p.m.
        Try
            '' Dim objDataSet As New DtReciboBono
            Dim Columna As Integer = 0
            Dim Cont As Integer = 0


            GenerarDSNominaBono = New DsPpalNomina


            With DGrid
                Cont = 0

                For I As Integer = 0 To .RowCount - 2
                    If (.Rows(I).Cells("Selec").Value = True Or Sw_Todos = True) And .Rows(I).Cells(3).Value <> "Total: " Then
                        If TipoNomB <> "A" Then
                            Dim objDataRow1 As Data.DataRow = GenerarDSNominaBono.Tables("Tbl_NominaBonos").NewRow
                            objDataRow1.Item("fechaini") = .Rows(I).Cells("fechaini").Value
                            objDataRow1.Item("fechafin") = .Rows(I).Cells("fechafin").Value
                            objDataRow1.Item("Ren") = I '+ 1
                            objDataRow1.Item("sucursal") = .Rows(I).Cells("sucursal").Value
                            objDataRow1.Item("descripsucursal") = .Rows(I).Cells("descripsucursal").Value
                            objDataRow1.Item("idempleado") = .Rows(I).Cells("idempleado").Value
                            objDataRow1.Item("nombrecompleto") = .Rows(I).Cells("nomcompleto").Value
                            objDataRow1.Item("descrippuesto") = .Rows(I).Cells("descrippuesto").Value
                            objDataRow1.Item("impdiastrab") = .Rows(I).Cells("impdiastrab").Value

                            objDataRow1.Item("impprima") = .Rows(I).Cells("impprima").Value
                            objDataRow1.Item("vacaciones") = .Rows(I).Cells("vacaciones").Value
                            objDataRow1.Item("pvacacional") = .Rows(I).Cells("pvacacional").Value


                            objDataRow1.Item("impdescanso") = .Rows(I).Cells("impdescanso").Value
                            objDataRow1.Item("festivo") = .Rows(I).Cells("festivo").Value
                            objDataRow1.Item("compensacion") = .Rows(I).Cells("compensacion").Value
                            objDataRow1.Item("mater") = .Rows(I).Cells("maternidad").Value
                            objDataRow1.Item("compensaciones") = .Rows(I).Cells("compensaciones").Value
                            objDataRow1.Item("impretardo") = .Rows(I).Cells("impretardo").Value
                            objDataRow1.Item("faltas") = .Rows(I).Cells("faltas").Value
                            objDataRow1.Item("compras") = .Rows(I).Cells("compras").Value
                            objDataRow1.Item("especie") = .Rows(I).Cells("especie").Value
                            objDataRow1.Item("uniformes") = .Rows(I).Cells("uniformes").Value

                            objDataRow1.Item("prestamos") = .Rows(I).Cells("prestamos").Value

                            objDataRow1.Item("faltante") = .Rows(I).Cells("faltante").Value
                            objDataRow1.Item("inventario") = .Rows(I).Cells("inventario").Value


                            objDataRow1.Item("pago") = .Rows(I).Cells("pago").Value

                            GenerarDSNominaBono.Tables("Tbl_NominaBonos").Rows.Add(objDataRow1)
                        Else


                            Dim objDataRow2 As Data.DataRow = GenerarDSNominaBono.Tables("Tbl_NominaBonos").NewRow

                            objDataRow2.Item("Ren") = I + 1
                            objDataRow2.Item("sucursal") = .Rows(I).Cells("sucursal").Value
                            objDataRow2.Item("descripsucursal") = .Rows(I).Cells("descripsucursal").Value
                            objDataRow2.Item("idempleado") = .Rows(I).Cells("idempleado").Value
                            objDataRow2.Item("nombrecompleto") = .Rows(I).Cells("nomcompleto").Value
                            objDataRow2.Item("descrippuesto") = .Rows(I).Cells("descrippuesto").Value
                            objDataRow2.Item("impdiastrab") = .Rows(I).Cells("impdiastrab").Value
                            objDataRow2.Item("impprima") = .Rows(I).Cells("impprima").Value
                            objDataRow2.Item("impdescanso") = .Rows(I).Cells("impdescanso").Value
                            objDataRow2.Item("impextras") = .Rows(I).Cells("impextras").Value
                            objDataRow2.Item("impretardo") = .Rows(I).Cells("impretardo").Value
                            objDataRow2.Item("compensaciones") = .Rows(I).Cells("compensaciones").Value
                            objDataRow2.Item("impotrasp") = .Rows(I).Cells("impotrasp").Value
                            objDataRow2.Item("impotrasd") = .Rows(I).Cells("impotrasd").Value
                            objDataRow2.Item("pago") = .Rows(I).Cells("pago").Value '* 0.5
                            objDataRow2.Item("fechaini") = .Rows(I).Cells("fechaini").Value
                            objDataRow2.Item("fechafin") = .Rows(I).Cells("fechafin").Value
                            objDataRow2.Item("deduc") = .Rows(I).Cells("deducciones").Value
                            objDataRow2.Item("mater") = .Rows(I).Cells("maternidad").Value
                            objDataRow2.Item("festivo") = .Rows(I).Cells("festivo").Value

                            GenerarDSNominaBono.Tables("Tbl_NominaBonos").Rows.Add(objDataRow2)
                        End If
                    End If
                Next




            End With
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Private Sub ImprimirNominaFiscal(ByVal Sw_todos As Boolean)
        'mreyes 15/Abril/2015 10:56 a.m.
        Try
            Dim myForm As New frmReportsBrowser
            Dim Sw_Mas14 As Boolean = False
            Dim Cont As Integer = 0
            Dim Sw_Imprimir As Boolean = False


            If TipoNomB = "B" Then
                myForm.objDataSetPpalNomina = GenerarDSNominaBono(Sw_todos)
                myForm.ReportIndex = 6
            ElseIf TipoNomB = "F" Then
                myForm.objDataSetPpalNomina = GenerarDSNominaFiscal(Sw_todos)
                myForm.ReportIndex = 7
            Else ' AGUINALDO
                myForm.objDataSetPpalNomina = GenerarDSNominaBono(Sw_todos)
                myForm.ReportIndex = 9
            End If



            myForm.Show()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub


    Private Sub ImprimirNominaBonos(ByVal Sw_todos As Boolean)
        'mreyes 14/Septiembre/2012 11:54 p.m.
        Try
            Dim myForm As New frmReportsBrowser
            Dim Sw_Mas14 As Boolean = False
            Dim Cont As Integer = 0
            Dim Sw_Imprimir As Boolean = False

            myForm.objDataSetPpalNomina = GenerarDSNominaBono(Sw_todos)
            If TipoNomB = "B" Then
                myForm.ReportIndex = 6   'CUANDO SE GENERA LA PRIMERA VEZ nosotros .. el 1 es el proveedor , EL 3 ES EL DE CEDI
            ElseIf TipoNomB = "F" Then
                myForm.ReportIndex = 7
            Else ' AGUINALDO
                myForm.ReportIndex = 9
            End If



            myForm.Show()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub
    Private Sub ImprimirReciboBono(ByVal Sw_Todos As Boolean)
        'mreyes 01/Septiembre/2012 07:12 p.m.
        Try
            Dim myForm As New frmReportsBrowser
            Dim Sw_Mas14 As Boolean = False
            Dim Cont As Integer = 0


            Dim Sw_Imprimir As Boolean = False


            myForm.objDataSetReciboBono = GenerarDSReciboBono(Sw_Todos)


            If TipoNomB = "A" Or TipoNomB = "G" Then
                myForm.ReportIndex = 8
            Else
                myForm.ReportIndex = 5
            End If
            'CUANDO SE GENERA LA PRIMERA VEZ nosotros .. el 1 es el proveedor , EL 3 ES EL DE CEDI


            myForm.Show()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub
    Private Sub AgregarColumna()
        'mreyes 21/Marzo/2012 09:52 a.m.

        Dim colImagen As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        
        colImagen.Frozen = True
        colImagen.Name = "Selec"
        colImagen.HeaderText = "Selec"
        colImagen.DisplayIndex = 0
        colImagen.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        colImagen.CellTemplate = New DataGridViewCheckBoxCell()
        ' añadir columna de imagen a la coleccion del grid 
        DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        ''DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DGrid.Columns.Add(colImagen)


    End Sub

    Private Sub Chk_VerDepto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_VerDepto.CheckedChanged
        If Chk_VerDepto.Checked = False Then
            DGrid.Columns(7).Visible = False
        Else
            DGrid.Columns(7).Visible = True

        End If
    End Sub

    Private Sub Btn_Empleado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Empleado.Click

        Opcion = 3
        Call RellenaGrid()



    End Sub

    Private Sub DGrid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGrid.KeyDown
        'mreyes 24/AGosto/2012 11:13 p.m.
        Try
            If (e.KeyCode = 46) Then
                If Opcion = 3 Then
                    If MessageBox.Show("Estas seguro de eliminar el pago para el empleado '" & DGrid.Rows(DGrid.CurrentCell.RowIndex).Cells("nomcompleto").Value & "'", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then


                        If (DGrid.CurrentCell.RowIndex) <> DGrid.Rows.Count - 1 Then

                            'cancelar pago... 
                            Call usp_EliminarNomina(DGrid.Rows(DGrid.CurrentCell.RowIndex).Cells("idperiodo").Value, Mid(DGrid.Rows(DGrid.CurrentCell.RowIndex).Cells("tiponom").Value, 1, 1), DGrid.Rows(DGrid.CurrentCell.RowIndex).Cells("sucursal").Value, DGrid.Rows(DGrid.CurrentCell.RowIndex).Cells("idempleado").Value)
                            DGrid.Rows.RemoveAt(DGrid.CurrentCell.RowIndex)

                            'End If
                        End If
                        'totalizados
                        DGrid.Rows(DGrid.RowCount - 2).Cells(9).Value = pub_SumarColumnaGrid(DGrid, 9, DGrid.RowCount - 3)
                        DGrid.Rows(DGrid.RowCount - 2).Cells(10).Value = pub_SumarColumnaGrid(DGrid, 10, DGrid.RowCount - 3)
                        DGrid.Rows(DGrid.RowCount - 2).Cells(11).Value = pub_SumarColumnaGrid(DGrid, 11, DGrid.RowCount - 3)
                        DGrid.Rows(DGrid.RowCount - 2).Cells(12).Value = pub_SumarColumnaGrid(DGrid, 12, DGrid.RowCount - 3)
                        DGrid.Rows(DGrid.RowCount - 2).Cells(13).Value = pub_SumarColumnaGrid(DGrid, 13, DGrid.RowCount - 3)
                        DGrid.Rows(DGrid.RowCount - 2).Cells(14).Value = pub_SumarColumnaGrid(DGrid, 14, DGrid.RowCount - 3)
                        DGrid.Rows(DGrid.RowCount - 2).Cells(15).Value = pub_SumarColumnaGrid(DGrid, 15, DGrid.RowCount - 3)
                        DGrid.Rows(DGrid.RowCount - 2).Cells(16).Value = pub_SumarColumnaGrid(DGrid, 16, DGrid.RowCount - 3)
                    End If
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmPpalNomina_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LocationChanged

    End Sub

    Private Sub Chk_IdEmpleado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_IdEmpleado.CheckedChanged
        If Opcion <> 3 Then Exit Sub
        If Chk_IdEmpleado.Checked = True Then
            DGrid.Columns(5).Visible = True
        Else
            DGrid.Columns(5).Visible = False
        End If
    End Sub

    Private Sub Btn_ImprimirRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ImprimirRpt.Click
        'If Opcion <> 3 Then
        '    MsgBox("No puede emitir Reporte de Nómin, sino se encuentra en indicador por empleado.", MsgBoxStyle.Information, "Aviso")
        '    Exit Sub
        'End If
          Me.Cursor = Cursors.AppStarting

        If TipoNomB = "F" Then
            Call ImprimirNominaFiscal(True)
        Else


            Call ImprimirNominaBonos(True)
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Btn_InvertirSeleccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_InvertirSeleccion.Click
        If Sw_NoRegistros = False Then Exit Sub
        Call Factura_Microsip()
    End Sub
    Private Sub Factura_Microsip()
        'mreyes 21/Marzo/2012 11:53 a.m.
        For Each row As DataGridViewRow In DGrid.Rows
            If row.Cells("Selec").Value = True Then
                row.Cells("Selec").Value = False
            Else
                row.Cells("Selec").Value = True
            End If
        Next

    End Sub

    Private Sub Chk_Filtros_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_Filtros.CheckedChanged
        If Chk_Filtros.Checked = True Then


            If Opcion = 1 Then
                TipoNomB = ""
            End If
            If Opcion = 2 Then
                SucursalB = ""
                IdDeptoB = 0
                IdPuestoB = 0
            End If
            If Opcion = 3 Then
                SucursalB = ""
                IdDeptoB = 0
                IdPuestoB = 0
                idEmpleadoB = 0
            End If
            Call RellenaGrid()
        End If
    End Sub

    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub

    Private Sub DGrid_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGrid.ColumnHeaderMouseClick
        Sw_Pintar = True
    End Sub

    Private Sub Chk_Aguinaldo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_Aguinaldo.CheckedChanged

        'mreyes 30/Junio/2012   10:34 a.m.
        If Chk_Aguinaldo.Checked = True Then
            Using objRegistro As New BCL.BCLNomina(GLB_ConStringNomSis)

                Try
                    Dim FechaIniAgui As Date = "2020-12-31"
                    Dim FechaFinAgui As Date = "2020-12-31"
                    Me.Cursor = Cursors.WaitCursor
                    DGrid.ReadOnly = False
                    DGrid.DataSource = Nothing

                    If Sw_Load = True Then
                        ' Sw_Load = False

                    Else

                        If Sw_NoRegistros = True Then
                            DGrid.Columns.Remove("Selec")

                        End If

                    End If
                    If Chk_AguiTemp.Checked = True Then
                        FechaIniAgui = "2020-10-22"
                        FechaFinAgui = "2020-12-31"
                    Else
                        FechaIniAgui = "1950-01-01"
                        FechaFinAgui = "2020-12-21"
                    End If
                    'Modif Miguel Perez, Tony Garcia 29/Ago/2012
                    ''''''''''''''''''
                    If Opcion = 4 Then
                        objDataSet = objRegistro.usp_PpalNominaPercdeduc(IdPeriodoB, TipoNomB, idEmpleadoB, SucursalB, IdDeptoB, IdPuestoB)
                    Else
                        If TipoNomB = "A" Then
                            IdPeriodoB = "INSERT INTO periodotemp (idperiodo1) VALUES (453);"
                            objDataSet = objRegistro.usp_PpalAguinaldo(Opcion, IdPeriodoB, TipoNomB, idEmpleadoB, SucursalB, IdDeptoB, IdPuestoB, 1, FechaIniAgui, FechaFinAgui)
                        Else
                            objDataSet = objRegistro.usp_PpalNomina(Opcion, IdPeriodoB, TipoNomB, idEmpleadoB, SucursalB, IdDeptoB, IdPuestoB)
                        End If
                    End If
                    'Populate the Project Details section
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        'Populate the Project Details section

                        DGrid.DataSource = objDataSet.Tables(0)
                        If Sw_Load = False Then
                            InicializaGrid1()
                        End If
                        'LimpiarBusqueda()
                        Me.Cursor = Cursors.Default
                        Btn_Excel.Enabled = True
                        Btn_Sucursal.Enabled = True
                        Btn_PercDeduc.Enabled = True
                        Sw_NoRegistros = True
                        Sw_Pintar = True

                        ' Call Colores()

                    Else

                        Sw_NoRegistros = False
                        Me.Cursor = Cursors.Default
                        MsgBox("No se encontraron Nóminas Calculadas que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                        Btn_Excel.Enabled = False
                        Btn_Sucursal.Enabled = False
                        Btn_PercDeduc.Enabled = False
                        If Sw_Load = True Then Sw_Load = False
                    End If
                    Me.Cursor = Cursors.Default
                    ' LimpiarBusqueda()

                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using


        Else
            Call RellenaGrid()

        End If
    End Sub

    Private Sub Chk_AguiTemp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_AguiTemp.CheckedChanged
        'mreyes 30/Junio/2012   10:34 a.m.

        If Chk_AguiTemp.Checked = True Then
            Using objRegistro As New BCL.BCLNomina(GLB_ConStringNomSis)

                Try
                    Dim FechaIniAgui As Date = "2020-12-31"
                    Dim FechaFinAgui As Date = "2020-12-31"
                    Me.Cursor = Cursors.WaitCursor
                    DGrid.ReadOnly = False
                    DGrid.DataSource = Nothing

                    If Sw_Load = True Then
                        ' Sw_Load = False

                    Else

                        If Sw_NoRegistros = True Then
                            DGrid.Columns.Remove("Selec")

                        End If

                    End If
                    If Chk_AguiTemp.Checked = True Then
                        FechaIniAgui = "2020-10-22"
                        FechaFinAgui = "2020-12-31"
                    Else
                        FechaIniAgui = "1950-01-01"
                        FechaFinAgui = "2020-10-21"
                    End If
                    'Modif Miguel Perez, Tony Garcia 29/Ago/2012


                    ''''''''''''''''''
                    If Opcion = 4 Then
                        objDataSet = objRegistro.usp_PpalNominaPercdeduc(IdPeriodoB, TipoNomB, idEmpleadoB, SucursalB, IdDeptoB, IdPuestoB)
                    Else
                        If TipoNomB = "A" Then
                            IdPeriodoB = "INSERT INTO periodotemp (idperiodo1) VALUES (453);"
                            objDataSet = objRegistro.usp_PpalAguinaldo(Opcion, IdPeriodoB, TipoNomB, idEmpleadoB, SucursalB, IdDeptoB, IdPuestoB, 0, FechaIniAgui, FechaFinAgui)
                        Else
                            objDataSet = objRegistro.usp_PpalNomina(Opcion, IdPeriodoB, TipoNomB, idEmpleadoB, SucursalB, IdDeptoB, IdPuestoB)
                        End If
                    End If
                    'Populate the Project Details section
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        'Populate the Project Details section

                        DGrid.DataSource = objDataSet.Tables(0)
                        If Sw_Load = False Then
                            InicializaGrid1()
                        End If
                        'LimpiarBusqueda()
                        Me.Cursor = Cursors.Default
                        Btn_Excel.Enabled = True
                        Btn_Sucursal.Enabled = True
                        Btn_PercDeduc.Enabled = True
                        Sw_NoRegistros = True
                        Sw_Pintar = True

                        '  Call Colores()

                    Else

                        Sw_NoRegistros = False
                        Me.Cursor = Cursors.Default
                        MsgBox("No se encontraron Nóminas Calculadas que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                        Btn_Excel.Enabled = False
                        Btn_Sucursal.Enabled = False
                        Btn_PercDeduc.Enabled = False
                        If Sw_Load = True Then Sw_Load = False
                    End If
                    Me.Cursor = Cursors.Default
                    ' LimpiarBusqueda()

                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using


        Else
            Call RellenaGrid()

        End If

    End Sub

    Private Sub Btn_BanBajio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_BanBajio.Click
        'primero 
        Call RellenaBanBajio()
        Try
            If ExportarDGridAExcel(DGrid, False, False, True) = False Then
                MsgBox("Error al exportar a Excel. Intente nuevamente.", MsgBoxStyle.Critical, "Excel")
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
        ' Call RellenaGrid(1)
    End Sub

    Private Sub CopiarSelecciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopiarSelecciónToolStripMenuItem.Click
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
End Class