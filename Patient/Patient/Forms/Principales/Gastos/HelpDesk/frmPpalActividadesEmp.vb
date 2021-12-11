Public Class frmPpalActividadesEmp
    ''Tony Garcia  - 13/Octubre/2012 6:00 p.m.
    Private objDataSet As Data.DataSet
    Dim Sw_NoRegistros As Boolean = False
    Dim IdReportaB As Integer = 0
    Dim IdAsignadoB As Integer = 0
    Dim SucursalB As String = ""
    Dim IdDeptoB As Integer = 0
    Dim DeptoB As String = ""
    Dim IdPuestoB As Integer = 0
    Dim FechaIniB As String = ""
    Dim FechaFinB As String = ""
    Dim IdActividadEmp As Integer = 0
    Dim EstatusB As String = ""
    'Dim SucursalN As String = ""
    Dim Solucion As String = ""

    Dim Sw_Pintar As Boolean = False
    Dim Sw_Load As Boolean = True
    Dim Opcion As Integer = 1
    Dim blnSol As Boolean = False
    Public IdActividad As Integer

    Private Sub frmPpalConceptoRep_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Sw_NoRegistros = False Then Exit Sub
        If Sw_Load = True Then
            Sw_Load = False
            InicializaGrid()
            'AgregarColumna()
            '    Call BarrerGrid()
        End If

    End Sub

    Private Sub frmPpalActividadesEmp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If

        If e.KeyCode = Keys.F5 Then
            'Call Btn_Filtro_Click_1(sender, e)
        End If
    End Sub

    Private Sub frmPpalActividadesEmp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            If GLB_CveSucursal <> "" Or GLB_CveSucursal <> "01" Or GLB_CveSucursal <> "02" Or GLB_CveSucursal <> "08" Or GLB_CveSucursal <> "06" Then
                Btn_EnProc.Visible = False
                Btn_Espera.Visible = False
                Btn_Realizado.Visible = False
                Btn_Pausa.Visible = False
                Btn_Cancelar.Visible = False
                Btn_NoAplica.Visible = False
            End If

            FechaIniB = Format(DateSerial(Now.Year, Now.Month, 1), "yyyy-MM-dd")
            Dim fecha1 As Date = DateAdd(DateInterval.Month, 1, Now.Date)
            FechaFinB = Format(DateAdd(DateInterval.Day, -1, DateSerial(fecha1.Year, fecha1.Month, 1)), "yyyy-MM-dd")

            GLB_RefrescarPedido = False
            Opcion = 1
            Call GenerarToolTip()
            Call LimpiarBusqueda()
            Call RellenaGrid()

            Sw_Pintar = True
            Sw_Load = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Nuevo, "Agregar Nuevo Ticket")
            ToolTip.SetToolTip(Btn_Editar, "Modificar Ticket")
            ToolTip.SetToolTip(Btn_Consultar, "Consultar Ticket Seleccionado")
            ToolTip.SetToolTip(Btn_EnProc, "Poner En Proceso los Tickets Seleccionados")
            ToolTip.SetToolTip(Btn_Pausa, "Pausar los Tickets Seleccionados")
            ToolTip.SetToolTip(Btn_Espera, "Poner En Espera los Tickets Seleccionados")
            ToolTip.SetToolTip(Btn_Realizado, "Dar por Realizados los Tickets Seleccionados")
            ToolTip.SetToolTip(Btn_NoAplica, "Definir como no NO APLICABLES los Tickets Seleccionados")
            ToolTip.SetToolTip(Btn_Cancelar, "Cancelar los Tickets Seleccionados")
            ToolTip.SetToolTip(Btn_Filtro, "Búsqueda Avanzada")
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
            ToolTip.SetToolTip(Btn_Salir, "Salir")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub RellenaGrid()
        'Tony Garcia - 15/Octubre/2012 - 10:15 a.m.
        Using objActividadesEmp As New BCL.BCLCatalogoActividades(GLB_ConStringNomSis)

            Try
                Me.Cursor = Cursors.WaitCursor
                'DGrid.ReadOnly = True
                DGrid.DataSource = Nothing
                If Sw_Load = True Then
                    ' Sw_Load = False 
                Else
                    If Sw_NoRegistros = True Then
                        DGrid.Columns.Remove("Selec")
                    End If
                End If

                If GLB_CveSucursal <> "" Then
                    objDataSet = objActividadesEmp.usp_PpalActividadesEmp(IdActividadEmp, IdReportaB, IdAsignadoB, FechaIniB, FechaFinB, GLB_CveSucursal, IdPuestoB, DeptoB, EstatusB.Trim)
                Else
                    objDataSet = objActividadesEmp.usp_PpalActividadesEmp(IdActividadEmp, IdReportaB, IdAsignadoB, FechaIniB, FechaFinB, SucursalB, IdPuestoB, DeptoB, EstatusB.Trim)
                End If

                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section

                    DGrid.DataSource = objDataSet.Tables(0)
                    If Sw_Load = False Then
                        InicializaGrid()
                    End If
                    'LimpiarBusqueda()
                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True
                    Sw_NoRegistros = True
                    Sw_Pintar = True
                    'Call Colores()
                Else
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron registros que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                End If
                Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub LimpiarBusqueda()
        IdActividadEmp = 0
        IdDeptoB = 0
        IdPuestoB = 0
        SucursalB = ""
        'FechaIniB = "1900-01-01"
        'FechaFinB = "1900-01-01"
        IdReportaB = 0
        IdAsignadoB = 0
        EstatusB = ""
    End Sub

    Private Sub Btn_Refrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub InicializaGrid()
        Try

            DGrid.RowHeadersVisible = False
            'DGrid.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, 7, FontStyle.Regular)

            DGrid.Columns(0).HeaderText = "Sucursal"
            DGrid.Columns(1).HeaderText = "Departamento"
            DGrid.Columns(2).HeaderText = "Folio"
            DGrid.Columns(3).HeaderText = "Fecha"
            DGrid.Columns(4).HeaderText = "Id Reporta" 'oculto
            DGrid.Columns(5).HeaderText = "Reporta"
            DGrid.Columns(6).HeaderText = "Id Asignado" 'oculto
            DGrid.Columns(7).HeaderText = "Asignado"
            DGrid.Columns(8).HeaderText = "Puesto"
            DGrid.Columns(9).HeaderText = "En Proceso"
            DGrid.Columns(10).HeaderText = "Finalizado"
            DGrid.Columns(11).HeaderText = "Estatus"
            DGrid.Columns(12).HeaderText = "Sucursal" 'oculto
            DGrid.Columns(13).HeaderText = "IdPuesto" 'oculto
            DGrid.Columns(14).HeaderText = "Descripcion" 'oculto
            DGrid.Columns(15).HeaderText = "Solucion" 'oculto
            DGrid.Columns(16).HeaderText = "Satisfaccion" 'oculto

            DGrid.Columns(4).Visible = False
            DGrid.Columns(6).Visible = False
            DGrid.Columns(12).Visible = False
            DGrid.Columns(13).Visible = False

            'DGrid.Columns(14).Visible = False
            'DGrid.Columns(15).Visible = False
            DGrid.Columns(16).Visible = False

            If blnSol = False Then
                DGrid.Columns(14).Visible = False
                DGrid.Columns(15).Visible = False
            End If

            If blnSol = True Then
                DGrid.Columns(11).DisplayIndex = 14
                DGrid.Columns(14).DisplayIndex = 12
                DGrid.Columns(15).DisplayIndex = 13
            End If
           

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
            DGrid.Columns(12).ReadOnly = True
            DGrid.Columns(13).ReadOnly = True
            DGrid.Columns(14).ReadOnly = True
            DGrid.Columns(15).ReadOnly = True
            DGrid.Columns(16).ReadOnly = True

            DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            AgregarColumna()

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
            DGrid.Columns(14).Visible = True
            DGrid.Columns(15).Visible = True
            DGrid.Columns(16).Visible = True
            If ExportarDGridAExcel(DGrid) = False Then
                MsgBox("Error al exportar a Excel. Intente nuevamente.", MsgBoxStyle.Critical, "Excel")
            End If
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Opcion = 1
        Call RellenaGrid()
    End Sub

    Private Sub DGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick
        Try
            If Sw_NoRegistros = False Then Exit Sub
            Dim myForm As New frmCatalogoActividades

            myForm.Accion = 4
            If DGrid.CurrentRow IsNot Nothing Then
                myForm.IdActividad = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idactividad").Value.ToString.Trim()
                myForm.FechaAlta = DGrid.Rows(DGrid.CurrentRow.Index).Cells("fechaalta").Value
                myForm.FechaProceso = DGrid.Rows(DGrid.CurrentRow.Index).Cells("fechaproc").Value
                myForm.FechaRealizado = DGrid.Rows(DGrid.CurrentRow.Index).Cells("fechafin").Value
                If DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value.ToString.Trim = "EN PROCESO" Then
                    myForm.Estatus = "S"
                ElseIf DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value.ToString.Trim = "REALIZADO" Then
                    myForm.Estatus = "R"
                ElseIf DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value.ToString.Trim = "CANCELADO" Then
                    myForm.Estatus = "X"
                ElseIf DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value.ToString.Trim = "CAPTURA" Then
                    myForm.Estatus = "C"
                ElseIf DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value.ToString.Trim = "PAUSADO" Then
                    myForm.Estatus = "P"
                ElseIf DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value.ToString.Trim = "EN ESPERA" Then
                    myForm.Estatus = "E"
                ElseIf DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value.ToString.Trim = "NO APLICA" Then
                    myForm.Estatus = "N"
                End If
            Else
                MsgBox("Seleccione un Empleado de la lista.", MsgBoxStyle.Exclamation, "ERROR")
                Exit Sub
            End If

                myForm.ShowDialog()
                If GLB_RefrescarPedido = True Then
                    Call RellenaGrid()
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

    Private Sub Btn_Consultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Sw_NoRegistros = False Then Exit Sub
        Dim myForm As New frmCatalogoActividades
        Opcion = 4

        myForm.Accion = 4
        If DGrid.CurrentRow IsNot Nothing Then
            myForm.IdActividad = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idactividad").Value.ToString.Trim()
            myForm.FechaAlta = DGrid.Rows(DGrid.CurrentRow.Index).Cells("fechaalta").Value
            myForm.FechaProceso = DGrid.Rows(DGrid.CurrentRow.Index).Cells("fechaproc").Value
            myForm.FechaRealizado = DGrid.Rows(DGrid.CurrentRow.Index).Cells("fechafin").Value
            If DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value.ToString.Trim = "EN PROCESO" Then
                myForm.Estatus = "S"
            ElseIf DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value.ToString.Trim = "REALIZADO" Then
                myForm.Estatus = "R"
            ElseIf DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value.ToString.Trim = "CANCELADO" Then
                myForm.Estatus = "X"
            ElseIf DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value.ToString.Trim = "CAPTURA" Then
                myForm.Estatus = "C"
            ElseIf DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value.ToString.Trim = "PAUSADO" Then
                myForm.Estatus = "P"
            ElseIf DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value.ToString.Trim = "EN ESPERA" Then
                myForm.Estatus = "E"
            ElseIf DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value.ToString.Trim = "NO APLICA" Then
                myForm.Estatus = "N"
            End If
        Else
            MsgBox("Seleccione un Empleado de la lista.", MsgBoxStyle.Exclamation, "ERROR")
            Exit Sub
        End If
        myForm.ShowDialog()

    End Sub

    Private Sub Btn_Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Sw_NoRegistros = False Then Exit Sub
        Dim myForm As New frmCatalogoActividades
        myForm.Accion = 2

        If DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value = "CANCELADO" Then
            MsgBox("No puede modificar registros con estatus CANCELADO.", MsgBoxStyle.Critical, "Validación")
            Exit Sub
        End If

        If DGrid.CurrentRow IsNot Nothing Then
            myForm.IdActividad = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idactividad").Value.ToString.Trim()
            myForm.FechaAlta = DGrid.Rows(DGrid.CurrentRow.Index).Cells("fechaalta").Value
            myForm.FechaProceso = DGrid.Rows(DGrid.CurrentRow.Index).Cells("fechaproc").Value
            myForm.FechaRealizado = DGrid.Rows(DGrid.CurrentRow.Index).Cells("fechafin").Value
            If DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value.ToString.Trim = "EN PROCESO" Then
                myForm.Estatus = "S"
            ElseIf DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value.ToString.Trim = "REALIZADO" Then
                myForm.Estatus = "R"
            ElseIf DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value.ToString.Trim = "CANCELADO" Then
                myForm.Estatus = "X"
            ElseIf DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value.ToString.Trim = "CAPTURA" Then
                myForm.Estatus = "C"
            ElseIf DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value.ToString.Trim = "PAUSADO" Then
                myForm.Estatus = "P"
            ElseIf DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value.ToString.Trim = "EN ESPERA" Then
                myForm.Estatus = "E"
            ElseIf DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value.ToString.Trim = "NO APLICA" Then
                myForm.Estatus = "N"
            End If
        Else
            MsgBox("Seleccione un Empleado de la lista.", MsgBoxStyle.Exclamation, "ERROR")
            Exit Sub
        End If

        myForm.ShowDialog()
    End Sub

    Private Sub Btn_Filtro_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        Dim myForm As New frmFiltrosActividades


        If GLB_CveSucursal <> "" Then
            myForm.Txt_Folio.Text = IIf(IdActividadEmp = 0, "", IdActividadEmp)
            'myForm.Txt_AreaDescrip.Text = DeptoB
            myForm.Txt_IdReporta.Text = IIf(IdReportaB = 0, "", IdReportaB)
            myForm.Txt_IdAsignado.Text = IIf(IdAsignadoB = 0, "", IdAsignadoB)
            myForm.Txt_IdPuesto.Text = IIf(IdPuestoB = 0, "", IdPuestoB)
            myForm.Txt_IdDepto.Text = IIf(IdDeptoB = 0, "", IdDeptoB)
            myForm.Txt_Sucursal.Text = GLB_CveSucursal
        Else
            myForm.Txt_Folio.Text = IIf(IdActividadEmp = 0, "", IdActividadEmp)
            'myForm.Txt_AreaDescrip.Text = DeptoB
            myForm.Txt_IdReporta.Text = IIf(IdReportaB = 0, "", IdReportaB)
            myForm.Txt_IdAsignado.Text = IIf(IdAsignadoB = 0, "", IdAsignadoB)
            myForm.Txt_IdPuesto.Text = IIf(IdPuestoB = 0, "", IdPuestoB)
            myForm.Txt_IdDepto.Text = IIf(IdDeptoB = 0, "", IdDeptoB)
            myForm.Txt_Sucursal.Text = SucursalB
        End If


        If FechaIniB <> "1900-01-01" Then
            myForm.Chk_Fecha.Checked = True
            myForm.DTFecha1.Value = FechaIniB
            myForm.DTFecha2.Value = FechaFinB
        End If

        myForm.Estatus = EstatusB
        myForm.ShowDialog()

        IdActividadEmp = Val(myForm.Txt_Folio.Text)
        DeptoB = myForm.Txt_AreaDescrip.Text
        'Asigna idreporta a los que no estan en empleados
        If myForm.Txt_IdReporta.Text = "IF" Then
            IdReportaB = "9999"
        ElseIf myForm.Txt_IdReporta.Text = "LF" Then
            IdReportaB = "9998"
        ElseIf myForm.Txt_IdReporta.Text = "IG" Then
            IdReportaB = "9997"
        Else
            IdReportaB = Val(myForm.Txt_IdReporta.Text)
        End If

        'Asigna idasignado a los que no se encuentran en tabla empleados
        If myForm.Txt_IdAsignado.Text = "IF" Then
            IdReportaB = "9999"
        ElseIf myForm.Txt_IdAsignado.Text = "LF" Then
            IdReportaB = "9998"
        ElseIf myForm.Txt_IdAsignado.Text = "IG" Then
            IdReportaB = "9997"
        Else
            IdAsignadoB = Val(myForm.Txt_IdAsignado.Text)
        End If

        IdPuestoB = Val(myForm.Txt_IdPuesto.Text)
        SucursalB = myForm.Txt_Sucursal.Text

        If myForm.Cbo_Estatus.Text = "CAPTURA" Then
            EstatusB = "CAPTURA"
        ElseIf myForm.Cbo_Estatus.Text = "EN PROCESO" Then
            EstatusB = "EN PROCESO"
        ElseIf myForm.Cbo_Estatus.Text = "REALIZADO" Then
            EstatusB = "REALIZADO"
        ElseIf myForm.Cbo_Estatus.Text = "CANCELADO" Then
            EstatusB = "CANCELADO"
        ElseIf myForm.Cbo_Estatus.Text = "PAUSADO" Then
            EstatusB = "PAUSADO"
        ElseIf myForm.Cbo_Estatus.Text = "EN ESPERA" Then
            EstatusB = "EN ESPERA"
        ElseIf myForm.Cbo_Estatus.Text = "NO APLICA" Then
            EstatusB = "NO APLICA"
        Else
            EstatusB = ""
        End If
        If myForm.Chk_Fecha.Checked = True Then
            FechaIniB = Format(myForm.DTFecha1.Value, "yyyy-MM-dd")
            FechaFinB = Format(myForm.DTFecha2.Value, "yyyy-MM-dd")
        Else
            FechaIniB = "1900-01-01"
            FechaFinB = "1900-01-01"
        End If

        If myForm.Sw_Filtro = True Then
            Call RellenaGrid()
        End If
    End Sub

    Private Sub AgregarColumna()
        Dim colImagen As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        colImagen.Name = "Selec"
        colImagen.HeaderText = "Selec"
        colImagen.DisplayIndex = 17
        colImagen.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        colImagen.CellTemplate = New DataGridViewCheckBoxCell()
        ' añadir columna de imagen a la coleccion del grid 
        DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        ''DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DGrid.Columns.Add(colImagen)
    End Sub

    Private Sub Btn_Consultar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Consultar.Click
        Try
            If Sw_NoRegistros = False Then Exit Sub
            Dim myForm As New frmCatalogoActividades

            myForm.Accion = 4
            If DGrid.CurrentRow IsNot Nothing Then
                myForm.IdActividad = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idactividad").Value.ToString.Trim()
                myForm.FechaAlta = DGrid.Rows(DGrid.CurrentRow.Index).Cells("fechaalta").Value
                myForm.FechaProceso = DGrid.Rows(DGrid.CurrentRow.Index).Cells("fechaproc").Value
                myForm.FechaRealizado = DGrid.Rows(DGrid.CurrentRow.Index).Cells("fechafin").Value
                If DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value.ToString.Trim = "EN PROCESO" Then
                    myForm.Estatus = "S"
                ElseIf DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value.ToString.Trim = "REALIZADO" Then
                    myForm.Estatus = "R"
                ElseIf DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value.ToString.Trim = "CANCELADO" Then
                    myForm.Estatus = "X"
                ElseIf DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value.ToString.Trim = "CAPTURA" Then
                    myForm.Estatus = "C"
                ElseIf DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value.ToString.Trim = "PAUSADO" Then
                    myForm.Estatus = "P"
                ElseIf DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value.ToString.Trim = "EN ESPERA" Then
                    myForm.Estatus = "E"
                ElseIf DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value.ToString.Trim = "NO APLICA" Then
                    myForm.Estatus = "N"
                End If
            Else
                MsgBox("Seleccione un Registro de la lista.", MsgBoxStyle.Exclamation, "ERROR")
                Exit Sub
            End If

            myForm.ShowDialog()
            If GLB_RefrescarPedido = True Then
                Call RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Editar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar.Click
        Try
            If DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value = "CANCELADO" 
                MsgBox("No puede modificar registros con estatus CANCELADO.", MsgBoxStyle.Critical, "Validación")
                Exit Sub
            End If

            Dim myForm As New frmCatalogoActividades
            myForm.Accion = 2
            If DGrid.CurrentRow IsNot Nothing Then
                myForm.IdActividad = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idactividad").Value.ToString.Trim()
                myForm.FechaAlta = DGrid.Rows(DGrid.CurrentRow.Index).Cells("fechaalta").Value
                myForm.FechaProceso = DGrid.Rows(DGrid.CurrentRow.Index).Cells("fechaproc").Value
                myForm.FechaRealizado = DGrid.Rows(DGrid.CurrentRow.Index).Cells("fechafin").Value
                If DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value.ToString.Trim = "EN PROCESO" Then
                    myForm.Estatus = "S"
                ElseIf DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value.ToString.Trim = "REALIZADO" Then
                    myForm.Estatus = "R"
                ElseIf DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value.ToString.Trim = "CANCELADO" Then
                    myForm.Estatus = "X"
                ElseIf DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value.ToString.Trim = "CAPTURA" Then
                    myForm.Estatus = "C"
                ElseIf DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value.ToString.Trim = "PAUSADO" Then
                    myForm.Estatus = "P"
                ElseIf DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value.ToString.Trim = "EN ESPERA" Then
                    myForm.Estatus = "E"
                ElseIf DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value.ToString.Trim = "NO APLICA" Then
                    myForm.Estatus = "N"
                End If
            Else
                MsgBox("Seleccione un Registro de la lista.", MsgBoxStyle.Exclamation, "ERROR")
                Exit Sub
            End If

            myForm.ShowDialog()
            If GLB_RefrescarPedido = True Then
                Call RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Nuevo_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Nuevo.Click
        Dim myForm As New frmCatalogoActividades
        Try
            myForm.Accion = 1
            myForm.ShowDialog()
            If GLB_RefrescarPedido = True Then
                Call RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGrid.CellFormatting
        Try

            'Tony Garcia - 15/Octubre/2012 12:25 p.m.

            Dim Sw_NoEntro As Boolean = False

            Dim DiasEntrega As Integer = 0
            If Sw_Pintar = False Then Exit Sub

            If Me.DGrid.Columns(e.ColumnIndex).Name <> "estatus" Then Exit Sub
            ''If Me.DGrid.Columns(e.ColumnIndex).Name <> "fecha" Then Exit Sub
            If e.RowIndex >= DGrid.RowCount - 1 Then
                If Sw_Load = False Then
                    Sw_Pintar = False
                End If
                Exit Sub
            End If

            If DGrid.Rows(e.RowIndex).Cells("estatus").Value = "CAPTURA" Then
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.BackColor = Color.Yellow
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If

            If DGrid.Rows(e.RowIndex).Cells("estatus").Value = "EN PROCESO" Then
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.BackColor = Color.RoyalBlue
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If

            If DGrid.Rows(e.RowIndex).Cells("estatus").Value = "EN ESPERA" Then
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.BackColor = Color.Salmon
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If

            If DGrid.Rows(e.RowIndex).Cells("estatus").Value = "PAUSADO" Then
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.BackColor = Color.Orange
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If

            If DGrid.Rows(e.RowIndex).Cells("estatus").Value = "REALIZADO" Then
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.BackColor = Color.YellowGreen
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If

            If DGrid.Rows(e.RowIndex).Cells("estatus").Value = "CANCELADO" Then
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.BackColor = Color.Red
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If

            If DGrid.Rows(e.RowIndex).Cells("estatus").Value = "NO APLICA" Then
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.BackColor = Color.Gray
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If

            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_EnProc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_EnProc.Click
        'Tony Garcia - 15/Octubre/2012 - 4:10 p.m.
        Dim intContador As Integer = 0
        Dim intContadorAct As Integer = 0
        Dim Opcion As Integer = 1
        Try

            'If GLB_CveSucursal <> "" Then
            '    MsgBox("No tiene permiso para realizar esta Accion.", MsgBoxStyle.Critical, "Aviso")
            '    Exit Sub
            'End If

            'valida que este seleccionado por lo menos un registro
            For Each row As DataGridViewRow In DGrid.Rows
                If row.Cells("Selec").Value = True Then
                    intContador += 1
                End If
            Next
            If intContador = 0 Then
                MsgBox("No se selecciono ningun Registro", MsgBoxStyle.OkOnly, "Aviso")
                Exit Sub
            End If

            If MsgBox("Esta seguro de poner En Proceso los Tickets Seleccionados?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub
            For i As Integer = 0 To DGrid.Rows.Count - 1
                If DGrid.Rows(i).Cells("Selec").Value = True And DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value = "CAPTURA" Or _
                DGrid.Rows(i).Cells("Selec").Value = True And DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value = "PAUSADO" Or _
                DGrid.Rows(i).Cells("Selec").Value = True And DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value = "EN ESPERA" Then
                    Dim IdActividad As Integer = DGrid.Rows(i).Cells("idactividad").Value
                    Dim FechaActual As DateTime = DateTime.Now

                    Using objActEmp As New BCL.BCLCatalogoActividades(GLB_ConStringNomSis)
                        objActEmp.usp_ActualizarEstatusAct(Opcion, IdActividad, "S", FechaActual, "1900-01-01", GLB_Usuario, FechaActual)
                    End Using
                    intContadorAct += 1
                End If
            Next
            If intContadorAct = 0 Then
                MsgBox("No puede poner En Proceso Tickets con estatus REALIZADO ó CANCELADO.", MsgBoxStyle.OkOnly, "Aviso")
                Exit Sub
            Else
                MsgBox("Proceso Terminado", MsgBoxStyle.Information, "Confirmación")
            End If

            Call RellenaGrid()
            Me.Cursor = Cursors.Default
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Realizado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Realizado.Click
        'Tony Garcia - 15/Octubre/2012 - 4:15 p.m.
        Dim intContador As Integer = 0
        Dim intContadorAct As Integer = 0
        Dim Opcion As Integer = 2
        Try

            'If GLB_CveSucursal <> "" Then
            '    MsgBox("No tiene permiso para realizar esta Accion.", MsgBoxStyle.Critical, "Aviso")
            '    Exit Sub
            'End If

            'valida que este seleccionado por lo menos un registro
            For Each row As DataGridViewRow In DGrid.Rows
                If row.Cells("Selec").Value = True Then
                    intContador += 1
                End If
            Next
            If intContador = 0 Then
                MsgBox("No se selecciono ningun Registro", MsgBoxStyle.OkOnly, "Aviso")
                Exit Sub
            End If

            If MsgBox("Esta seguro dar por Realizados los Tickets Seleccionados?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub
            For i As Integer = 0 To DGrid.Rows.Count - 1
                If DGrid.Rows(i).Cells("Selec").Value = True And DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value = "EN PROCESO" And _
                 DGrid.Rows(DGrid.CurrentRow.Index).Cells("resultado").Value <> "" Then
                    Dim IdActividad As Integer = DGrid.Rows(i).Cells("idactividad").Value
                    Dim FechaProc As Date = DGrid.Rows(i).Cells("fechaproc").Value
                    Dim FechaActual As DateTime = DateTime.Now

                    Using objActEmp As New BCL.BCLCatalogoActividades(GLB_ConStringNomSis)
                        objActEmp.usp_ActualizarEstatusAct(Opcion, IdActividad, "R", FechaProc, FechaActual, GLB_Usuario, FechaActual)
                    End Using
                    intContadorAct += 1
                End If
            Next

            If intContadorAct = 0 Then
                MsgBox("Solo puede dar por finalizados los Tickets con estatus EN PROCESO y que tengan una SOLUCION.", MsgBoxStyle.OkOnly, "Aviso")
                Exit Sub
            Else
                MsgBox("Proceso Terminado", MsgBoxStyle.Information, "Confirmación")
            End If

            Call RellenaGrid()
            Me.Cursor = Cursors.Default
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        'Tony Garcia - 15/Octubre/2012 - 4:10 p.m.
        Dim intContador As Integer = 0
        Dim intContadorAct As Integer = 0
        Dim Opcion As Integer = 3
        Try

            'If GLB_CveSucursal <> "" Then
            '    MsgBox("No tiene permiso para realizar esta Accion.", MsgBoxStyle.Critical, "Aviso")
            '    Exit Sub
            'End If

            'valida que este seleccionado por lo menos un registro
            For Each row As DataGridViewRow In DGrid.Rows
                If row.Cells("Selec").Value = True Then
                    intContador += 1
                End If
            Next
            If intContador = 0 Then
                MsgBox("No se selecciono ningun Registro", MsgBoxStyle.OkOnly, "Aviso")
                Exit Sub
            End If

            If MsgBox("Esta seguro de Cancelar los Tickets Seleccionados?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub
            For i As Integer = 0 To DGrid.Rows.Count - 1
                If DGrid.Rows(i).Cells("Selec").Value = True And DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value = "CAPTURA" Then
                    'Dim Tipo As String = CStr(DGrid.Rows(i).Cells("tipo").Value)
                    Dim IdActividad As Integer = DGrid.Rows(i).Cells("idactividad").Value
                    Dim FechaActual As DateTime = DateTime.Now

                    Using objActEmp As New BCL.BCLCatalogoActividades(GLB_ConStringNomSis)
                        objActEmp.usp_ActualizarEstatusAct(Opcion, IdActividad, "X", "1900-01-01", "1900-01-01", GLB_Usuario, FechaActual)
                    End Using
                    intContadorAct += 1
                End If
            Next
            If intContadorAct = 0 Then
                MsgBox("Solo puede cancelar Tickets con estatus de CAPTURA", MsgBoxStyle.OkOnly, "Aviso")
                Exit Sub
            Else
                MsgBox("Proceso Terminado", MsgBoxStyle.Information, "Confirmación")
            End If

            Call RellenaGrid()
            Me.Cursor = Cursors.Default
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ConsultarActEmpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultarActEmpToolStripMenuItem.Click
        Call Btn_Consultar_Click(sender, e)
    End Sub

    Private Sub ModificarActEmpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarActEmpToolStripMenuItem.Click
        Call Btn_Editar_Click(sender, e)
    End Sub

    Private Sub ProcesoActEmpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProcesoActEmpToolStripMenuItem.Click
        DGrid.Rows(DGrid.CurrentRow.Index).Cells("Selec").Value = True
        Call Btn_EnProc_Click(sender, e)
    End Sub

    Private Sub CancelarActEmpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelarActEmpToolStripMenuItem.Click
        DGrid.Rows(DGrid.CurrentRow.Index).Cells("Selec").Value = True
        Call Btn_Cancelar_Click(sender, e)
    End Sub

    Private Sub RealizadoActEmpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RealizadoActEmpToolStripMenuItem.Click
        DGrid.Rows(DGrid.CurrentRow.Index).Cells("Selec").Value = True
        Call Btn_Realizado_Click(sender, e)
    End Sub

    Private Sub DGrid_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DGrid.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With Me.DGrid
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If
    End Sub

    Private Sub Btn_Pausa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Pausa.Click
        'Tony Garcia - 15/Octubre/2012 - 4:10 p.m.
        Dim intContador As Integer = 0
        Dim intContadorAct As Integer = 0
        Dim Opcion As Integer = 2
        Try

            'If GLB_CveSucursal <> "" Then
            '    MsgBox("No tiene permiso para realizar esta Accion.", MsgBoxStyle.Critical, "Aviso")
            '    Exit Sub
            'End If

            'valida que este seleccionado por lo menos un registro
            For Each row As DataGridViewRow In DGrid.Rows
                If row.Cells("Selec").Value = True Then
                    intContador += 1
                End If
            Next
            If intContador = 0 Then
                MsgBox("No se selecciono ningun Registro", MsgBoxStyle.OkOnly, "Aviso")
                Exit Sub
            End If

            If MsgBox("Esta seguro de Pausar los Tickets Seleccionados?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub
            For i As Integer = 0 To DGrid.Rows.Count - 1
                If DGrid.Rows(i).Cells("Selec").Value = True And DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value = "EN PROCESO" Or _
                DGrid.Rows(i).Cells("Selec").Value = True And DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value = "EN ESPERA" Then
                    'Dim Tipo As String = CStr(DGrid.Rows(i).Cells("tipo").Value)
                    Dim IdActividad As Integer = DGrid.Rows(i).Cells("idactividad").Value
                    Dim FechaActual As DateTime = DateTime.Now

                    Using objActEmp As New BCL.BCLCatalogoActividades(GLB_ConStringNomSis)
                        objActEmp.usp_ActualizarEstatusAct(Opcion, IdActividad, "P", "1900-01-01", "1900-01-01", GLB_Usuario, FechaActual)
                    End Using
                    intContadorAct += 1
                End If
            Next
            If intContadorAct = 0 Then
                MsgBox("Solo puede Pausar Tickets con estatus EN PROCESO ó EN ESPERA.", MsgBoxStyle.OkOnly, "Aviso")
                Exit Sub
            Else
                MsgBox("Proceso Terminado", MsgBoxStyle.Information, "Confirmación")
            End If

            Call RellenaGrid()
            Me.Cursor = Cursors.Default
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Espera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Espera.Click
        'Tony Garcia - 15/Octubre/2012 - 4:10 p.m.
        Dim intContador As Integer = 0
        Dim intContadorAct As Integer = 0
        Dim Opcion As Integer = 2
        Try

            'If GLB_CveSucursal <> "" Then
            '    MsgBox("No tiene permiso para realizar esta Accion.", MsgBoxStyle.Critical, "Aviso")
            '    Exit Sub
            'End If

            'valida que este seleccionado por lo menos un registro
            For Each row As DataGridViewRow In DGrid.Rows
                If row.Cells("Selec").Value = True Then
                    intContador += 1
                End If
            Next
            If intContador = 0 Then
                MsgBox("No se selecciono ningun Registro", MsgBoxStyle.OkOnly, "Aviso")
                Exit Sub
            End If

            If MsgBox("Desea poner En Espera los Tickets Seleccionados?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub
            For i As Integer = 0 To DGrid.Rows.Count - 1
                If DGrid.Rows(i).Cells("Selec").Value = True And DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value = "EN PROCESO" Then
                    'Dim Tipo As String = CStr(DGrid.Rows(i).Cells("tipo").Value)
                    Dim IdActividad As Integer = DGrid.Rows(i).Cells("idactividad").Value
                    Dim FechaActual As DateTime = DateTime.Now

                    Using objActEmp As New BCL.BCLCatalogoActividades(GLB_ConStringNomSis)
                        objActEmp.usp_ActualizarEstatusAct(Opcion, IdActividad, "E", "1900-01-01", "1900-01-01", GLB_Usuario, FechaActual)
                    End Using
                    intContadorAct += 1
                End If
            Next
            If intContadorAct = 0 Then
                MsgBox("Solo puede poner EN ESPERA los Tickets con estatus EN PROCESO", MsgBoxStyle.OkOnly, "Aviso")
                Exit Sub
            Else
                MsgBox("Proceso Terminado", MsgBoxStyle.Information, "Confirmación")
            End If

            Call RellenaGrid()
            Me.Cursor = Cursors.Default
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_NoAplica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_NoAplica.Click
        'Tony Garcia - 24/Octubre/2012 - 6:10 p.m.
        Dim intContador As Integer = 0
        Dim intContadorAct As Integer = 0
        Dim Opcion As Integer = 2
        Try

            'If GLB_CveSucursal <> "" Then
            '    MsgBox("No tiene permiso para realizar esta Accion.", MsgBoxStyle.Critical, "Aviso")
            '    Exit Sub
            'End If

            'valida que este seleccionado por lo menos un registro
            For Each row As DataGridViewRow In DGrid.Rows
                If row.Cells("Selec").Value = True Then
                    intContador += 1
                End If
            Next
            If intContador = 0 Then
                MsgBox("No se selecciono ningun Registro", MsgBoxStyle.OkOnly, "Aviso")
                Exit Sub
            End If

            If MsgBox("Desea poner en estatus de NO APLICA los Tickets Seleccionados?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub
            For i As Integer = 0 To DGrid.Rows.Count - 1
                If DGrid.Rows(i).Cells("Selec").Value = True And DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value = "CAPTURA" Then
                    'Dim Tipo As String = CStr(DGrid.Rows(i).Cells("tipo").Value)
                    Dim IdActividad As Integer = DGrid.Rows(i).Cells("idactividad").Value
                    Dim FechaActual As DateTime = DateTime.Now

                    Using objActEmp As New BCL.BCLCatalogoActividades(GLB_ConStringNomSis)
                        objActEmp.usp_ActualizarEstatusAct(Opcion, IdActividad, "N", "1900-01-01", "1900-01-01", GLB_Usuario, FechaActual)
                    End Using
                    intContadorAct += 1
                End If
            Next
            If intContadorAct = 0 Then
                MsgBox("Solo puede realizar esta accion con los Tickets con estatus de CAPTURA", MsgBoxStyle.OkOnly, "Aviso")
                Exit Sub
            Else
                MsgBox("Proceso Terminado", MsgBoxStyle.Information, "Confirmación")
            End If

            Call RellenaGrid()
            Me.Cursor = Cursors.Default
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_ColumnHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGrid.ColumnHeaderMouseClick
        Sw_Pintar = True
    End Sub

    Private Sub Chk_Solucion_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chk_Solucion.CheckedChanged
        If Chk_Solucion.Checked = True Then
            blnSol = True
        ElseIf Chk_Solucion.Checked = False Then
            blnSol = False
        End If

        Call RellenaGrid()
    End Sub

    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub
End Class
