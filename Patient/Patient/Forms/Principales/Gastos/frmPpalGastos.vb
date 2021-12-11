Public Class frmPpalGastos
    'mreyes 09/Junio/2012 01:07 p.m.

    Private objDataSet As Data.DataSet
    Private objDataSetEmp As Data.DataSet
    Dim Sw_NoRegistros As Boolean = False

    Dim idSolicitaB As Integer = 0
    Dim idPercDeducB As Integer = 0
    Dim InicioIniB As String = ""
    Dim InicioFinB As String = ""

    Dim SucursalB As String = ""
    Dim foliosuciniB As String = ""
    Dim foliosucFinB As String = ""
    Dim folioB As Integer = 0
    Dim idgastob As Integer = 0
    Dim cantidadiniB As Double = 0
    Dim cantidadfinB As Double = 0
    Dim fechaIniB As String = "1900-01-01"
    Dim fechaFinB As String = "1900-01-01"
    Dim statusB As String = ""
    Dim Sw_Pintar As Boolean = False
    Dim Sw_Load As Boolean = True

    Private Sub frmPpalRepetitivos_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Sw_Load = True Then
            If Sw_NoRegistros = False Then
                Sw_Load = False
            Else
                Sw_Load = False
                'InicializaGrid()
            End If
        End If
    End Sub

    Private Sub frmPpalGastos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If

        If e.KeyCode = Keys.F5 Then
            'Call Btn_Filtro_Click_1(sender, e)
        End If
    End Sub

    Private Sub frmPpalGastos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Call LimpiarBusqueda()

            'If GLB_AccesoEmpleado = True Then
            '    Btn_Excel.Enabled = False
            '    Btn_Filtro.Enabled = False
            'End If
            Call Edicion()
            Call RellenaGrid()
            'If GLB_AccesoEmpleado = True Then
            '    Btn_Excel.Enabled = False
            '    Btn_Filtro.Enabled = False
            '    Btn_Autorizar.Enabled = False
            '    Btn_Eliminar.Enabled = False
            'End If
            Call GenerarToolTip()
            Sw_Pintar = True
            Sw_Load = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Edicion()

        If GLB_CveSucursal = "97" Then
            Btn_Autorizar.Enabled = False
        ElseIf GLB_CveSucursal = "01" Or GLB_CveSucursal = "02" Or GLB_CveSucursal = "06" Or GLB_CveSucursal = "07" Or GLB_CveSucursal = "08" Or GLB_CveSucursal = "11" Then
            Btn_Autorizar.Visible = False
            Btn_Revisar.Visible = False
            Btn_Editar.Visible = False
            Btn_Eliminar.Visible = False
        ElseIf GLB_CveSucursal = "00" Then
            Btn_Revisar.Enabled = False

        End If

    End Sub

    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Nuevo, "Nuevo Gasto")
            ToolTip.SetToolTip(Btn_Editar, "Editar Gasto")
            ToolTip.SetToolTip(Btn_Eliminar, "Cancelar Gasto")
            ToolTip.SetToolTip(Btn_Consultar, "Consultar Gasto")
            ToolTip.SetToolTip(Btn_Autorizar, "Autorizar Gasto")
            ToolTip.SetToolTip(Btn_Revisar, "Revisar Gasto")
            ToolTip.SetToolTip(Btn_Filtro, "Búsqueda Avanzada")
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
            ToolTip.SetToolTip(Btn_Imprimir, "Imprimir Información")
            ToolTip.SetToolTip(Btn_Salir, "Salir")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub RellenaGrid()
        'mreyes 11/Junio/2012 05:31 p.m.
        Using objGastos As New BCL.BCLCatalogoGastos(GLB_ConStringCipSis)

            Try
                Me.Cursor = Cursors.WaitCursor
                'DGrid.ReadOnly = True
                DGrid.DataSource = Nothing

                If Sw_Load = True Then
                    If Sw_NoRegistros = True Then
                        DGrid.Columns.Remove("Selec")
                    End If
                Else
                    If Sw_NoRegistros = True Then
                        DGrid.Columns.Remove("Selec")
                    End If
                End If
                objDataSet = objGastos.usp_PpalCatalogoGastos(folioB, SucursalB, idgastob, cantidadiniB, cantidadfinB, idSolicitaB, statusB, InicioIniB, InicioFinB, foliosuciniB, foliosucFinB)

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    DGrid.DataSource = Nothing
                    DGrid.DataSource = objDataSet.Tables(0)

                    Dim dtEmpleado As DataTable = TryCast(DGrid.DataSource, DataTable)

                    For Each row As DataRow In dtEmpleado.Rows
                        Using objMySqlGral As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)
                            Try
                                Dim strSolicita1 As String
                                Dim strSolicita2 As String
                                'Dim strAutoriza1 As String
                                'Dim strAutoriza2 As String

                                objDataSetEmp = objMySqlGral.usp_TraerNomEmpleado(row("solicita"), "", "", "", "", 0)
                                If objDataSetEmp.Tables(0).Rows.Count = 1 Then
                                    strSolicita1 = objDataSetEmp.Tables(0).Rows(0).Item("idempleado").ToString
                                    strSolicita2 = objDataSetEmp.Tables(0).Rows(0).Item("nomcompleto").ToString

                                    row("solicitanom") = strSolicita1 & " - " & strSolicita2
                                End If

                                'objDataSetEmp = objMySqlGral.usp_TraerNomEmpleado(row("autoriza"), "", "", "", "", 0)
                                'If objDataSetEmp.Tables(0).Rows.Count = 1 Then
                                '    strAutoriza1 = objDataSetEmp.Tables(0).Rows(0).Item("idempleado").ToString
                                '    strAutoriza2 = objDataSetEmp.Tables(0).Rows(0).Item("nomcompleto").ToString

                                '    row("autorizanom") = strAutoriza1 & " - " & strAutoriza2
                                'End If

                            Catch ExceptionErr As Exception
                                MessageBox.Show(ExceptionErr.Message.ToString)
                            End Try
                        End Using
                    Next
                End If
                

                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then

                    'Populate the Project Details section

                    DGrid.DataSource = objDataSet.Tables(0)
                    InicializaGrid()
                    'LimpiarBusqueda()
                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True
                    'Btn_Editar.Enabled = True
                    Btn_Consultar.Enabled = True
                    Sw_NoRegistros = True
                    Sw_Pintar = True
                Else
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron Gastos que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                    Btn_Editar.Enabled = False
                    Btn_Consultar.Enabled = False
                End If
                Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using


    End Sub
    Private Sub LimpiarBusqueda()


        folioB = 0
        If GLB_CveSucursal = "01" Or GLB_CveSucursal = "02" Or GLB_CveSucursal = "06" Or GLB_CveSucursal = "07" Or GLB_CveSucursal = "08" Or GLB_CveSucursal = "11" Then
            SucursalB = GLB_CveSucursal
        Else
            SucursalB = ""
        End If

        statusB = ""
        'fechaIniB = "1900-01-01"
        'fechaFinB = "1900-01-01"


        fechaIniB = Format(Now.Add(New TimeSpan(-30, 0, 0, 0)), "yyyy-MM-dd")
        fechaFinB = Format(Now.Date, "yyyy-MM-dd")

        InicioIniB = Format(Now.Add(New TimeSpan(-1, 0, 0, 0)), "yyyy-MM-dd")
        InicioFinB = Format(Now.Add(New TimeSpan(-0, 0, 0, 0)), "yyyy-MM-dd")

    End Sub

    Private Sub Btn_Refrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Sub InicializaGrid()
        ''DIBUJA LA TABLA Y LE DA FORMATO A LOS DATOS QUE TRAEMOS
        'RAULR 15/04/2013
        Try

            Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
            Dim row As DataRow = dt.NewRow()
            row(7) = "Total: "

            row(8) = pub_SumarColumnaGrid(DGrid, 8, DGrid.RowCount - 1)

            dt.Rows.Add(row)
            DGrid.DataSource = dt

            DGrid.RowHeadersVisible = False
            DGrid.Columns(0).HeaderText = "Folio"
            DGrid.Columns(1).HeaderText = "Folio"
            DGrid.Columns(2).HeaderText = "Sucursal"
            DGrid.Columns(3).HeaderText = "Fecha"
            DGrid.Columns(4).HeaderText = "Concepto"
            DGrid.Columns(5).HeaderText = "SolicitaId"
            DGrid.Columns(6).HeaderText = "Solicita"
            DGrid.Columns(7).HeaderText = "Comentarios"
            DGrid.Columns(8).HeaderText = "Importe"
            DGrid.Columns(9).HeaderText = "Estatus"


            DGrid.Columns(0).Visible = False

            'ALINEACION DEL TEXTO DE LAS COLUMNAS
            DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid.Columns(5).Visible = False

            'FORMATO PARA CELDA PONER EL SIGNO DE PESOS
            DGrid.Columns(8).DefaultCellStyle.Format = "c"
            DGrid.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'para agregar a la columna del folio ceros..
            DGrid.Columns(0).DefaultCellStyle.Format = "00000"

            'colorea la linea del total
            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

            Call AgregarColumna()

            For i As Integer = 0 To DGrid.Columns.Count - 2
                DGrid.Columns(i).ReadOnly = True
            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub AgregarColumna()

        Dim colImagen As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        colImagen.Name = "Selec"
        colImagen.HeaderText = "Selec"
        colImagen.DisplayIndex = 11
        colImagen.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        colImagen.CellTemplate = New DataGridViewCheckBoxCell()
        ' añadir columna de imagen a la coleccion del grid 
        DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        ''DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DGrid.Columns.Add(colImagen)
        colImagen.ReadOnly = False
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

    Private Sub Btn_Nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Nuevo.Click
        Try
            Dim myForm As New frmCatalogoGastos
            myForm.Accion = 1
            myForm.Cbo_Status.Text = "CAPTURA"
            myForm.ShowDialog()

            If myForm.Sw_Registro = True Then
                Call RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub DGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick
        Try
            Call Btn_Consultar_Click(sender, e)
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
        Try
            If Sw_NoRegistros = False Then Exit Sub
            Dim myForm As New frmCatalogoGastos

            myForm.Accion = 4
            myForm.Txt_Folio.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("folio").Value.ToString.Trim()
            'myForm.Txt_Folio.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells(0).Value.ToString.Trim()
            myForm.Txt_Importe.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells(2).Value.ToString.Trim()
            myForm.Txt_IdEmpleado.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells(3).Value.ToString.Trim()

            myForm.ShowDialog()

            If myForm.Sw_Registro = True Then
                Call RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar.Click
        Try
            If Sw_NoRegistros = False Then Exit Sub
            If DGrid.Rows(DGrid.CurrentRow.Index).Cells("status").Value = "AUTORIZADO" Then
                MsgBox("No puede modificar un Gasto Autorizado", MsgBoxStyle.Critical, "Validación")
                Exit Sub
            ElseIf DGrid.Rows(DGrid.CurrentRow.Index).Cells("status").Value = "CANCELADO" Then
                MsgBox("No puede modificar un Gasto Cancelado", MsgBoxStyle.Critical, "Validación")
                Exit Sub
            ElseIf DGrid.Rows(DGrid.CurrentRow.Index).Cells("status").Value = "REVISADO" Then
                MsgBox("No puede modificar un Gasto Revisado", MsgBoxStyle.Critical, "Validación")
                Exit Sub
            End If
            Dim myForm As New frmCatalogoGastos


            myForm.Accion = 2
            myForm.Txt_Folio.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("folio").Value.ToString.Trim()
            myForm.ShowDialog()

            If myForm.Sw_Registro = True Then
                Call RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub

    Private Sub NuevoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoGastoToolStripMenuItem.Click
        Call Btn_Nuevo_Click(sender, e)
    End Sub

    Private Sub ModificarGastoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarGastoToolStripMenuItem.Click
        Call Btn_Editar_Click(sender, e)
    End Sub

    Private Sub ConsultarGastoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultarGastoToolStripMenuItem.Click
        Call Btn_Consultar_Click(sender, e)
    End Sub

    Private Sub Pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub

    Private Sub DGrid_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGrid.ColumnHeaderMouseClick
        Sw_Pintar = True
    End Sub

    Private Sub Btn_Filtro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        Dim myForm As New frmFiltrosGastos
        Dim Estatus As String = ""

        If statusB = "CA" Then
            Estatus = "CAPTURA"
        ElseIf statusB = "ZC" Then
            Estatus = "CANCELADO"
        ElseIf statusB = "AP" Then
            Estatus = "AUTORIZADO"
        ElseIf statusB = "RV" Then
            Estatus = "REVISADO"
        End If

        If idgastob = 1 Then
            myForm.Cbo_IdGasto.Text = "PASTEL"
        ElseIf idgastob = 2 Then
            myForm.Cbo_IdGasto.Text = "PASAJES"
        ElseIf idgastob = 3 Then
            myForm.Cbo_IdGasto.Text = "COMIDAS"
        ElseIf idgastob = 4 Then
            myForm.Cbo_IdGasto.Text = "ESTACIONAMIENTO"
        ElseIf idgastob = 5 Then
            myForm.Cbo_IdGasto.Text = "MANTENIMIENTO"
        ElseIf idgastob = 6 Then
            myForm.Cbo_IdGasto.Text = "VOLANTEO"
        Else
            myForm.Cbo_IdGasto.Text = ""
        End If


        myForm.Txt_IdFolioSucIni.Text = foliosuciniB
        myForm.Txt_IdFolioSucFin.Text = foliosucFinB

        myForm.Txt_Sucursal.Text = SucursalB

        myForm.Txt_IdEmpleado.Text = IIf(idSolicitaB = 0, "", idSolicitaB)
        'myForm.Txt_IdEmpleado2.Text = IIf(idAutorizaB = 0, "", idAutorizaB)

        If InicioIniB <> "1900-01-01" Then
            myForm.Chk_FechaCaptura.Checked = True
            myForm.DTPicker2.Value = InicioIniB
            myForm.DTPicker3.Value = InicioFinB
        End If

        myForm.Cbo_Estatus.Text = Estatus

        myForm.ShowDialog()
        SucursalB = myForm.Txt_Sucursal.Text

        foliosuciniB = myForm.Txt_IdFolioSucIni.Text
        foliosucFinB = myForm.Txt_IdFolioSucFin.Text

        idSolicitaB = Val(myForm.Txt_IdEmpleado.Text)
        'idAutorizaB = Val(myForm.Txt_IdEmpleado2.Text)

        If myForm.Cbo_Estatus.Text = "CAPTURA" Then
            statusB = "CA"
        ElseIf myForm.Cbo_Estatus.Text = "CANCELADO" Then
            statusB = "ZC"
        ElseIf myForm.Cbo_Estatus.Text = "AUTORIZADO" Then
            statusB = "AP"
        ElseIf myForm.Cbo_Estatus.Text = "REVISADO" Then
            statusB = "RV"
        End If

        If myForm.Chk_FechaCaptura.Checked = True Then
            InicioIniB = Format(myForm.DTPicker2.Value, "yyyy-MM-dd")
            InicioFinB = Format(myForm.DTPicker3.Value, "yyyy-MM-dd")
        Else
            InicioIniB = "1900-01-01"
            InicioFinB = "1900-01-01"
        End If


        If myForm.Cbo_IdGasto.Text = "PASTEL" Then
            idgastob = 1
        ElseIf myForm.Cbo_IdGasto.Text = "PASAJES" Then
            idgastob = 2
        ElseIf myForm.Cbo_IdGasto.Text = "COMIDAS" Then
            idgastob = 3
        ElseIf myForm.Cbo_IdGasto.Text = "ESTACIONAMIENTO" Then
            idgastob = 4
        ElseIf myForm.Cbo_IdGasto.Text = "MANTENIMIENTO" Then
            idgastob = 5
        ElseIf myForm.Cbo_IdGasto.Text = "VOLANTEO" Then
            idgastob = 6
        Else
            idgastob = 0
        End If


        If myForm.Sw_Filtro = True Then
            Call RellenaGrid()
        End If
    End Sub

    Private Sub Btn_Aplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Autorizar.Click
        Dim intContador As Integer = 0
        Dim intContadorEst As Integer = 0
        Dim Opcion = 2
        Try

            For Each row As DataGridViewRow In DGrid.Rows
                If row.Cells("Selec").Value = True Then
                    If row.Cells("status").Value = "AUTORIZADO" Or _
                    row.Cells("status").Value = "CAPTURA" Or _
                    row.Cells("status").Value = "CANCELADO" Then
                        MsgBox("Solo debe seleccionar registros con estatus de REVISADO", MsgBoxStyle.Critical, "Validación")
                        Exit Sub
                    Else
                        intContador += 1
                    End If
                End If
            Next

            If intContador = 0 Then
                MsgBox("No seleccionó ningun registro.", MsgBoxStyle.Critical, "Validación")
                Exit Sub
            End If

            If MsgBox("Esta seguro de AUTORIZAR los registros seleccionados?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub
            For i As Integer = 0 To DGrid.Rows.Count - 1
                If DGrid.Rows(i).Cells("Selec").Value = True And DGrid.Rows(DGrid.CurrentRow.Index).Cells("status").Value = "REVISADO" Then
                    Dim Folio As Integer = DGrid.Rows(i).Cells("folio").Value

                    Using objGastos As New BCL.BCLCatalogoGastos(GLB_ConStringCipSis)
                        objGastos.usp_ActualizarEstatusGastos(Opcion, Folio, "AP", GLB_Idempleado, Date.Now)
                        intContadorEst += 1
                    End Using
                End If
            Next

            If intContadorEst = 1 Then
                MsgBox("El estatus se actualizó correctamente", MsgBoxStyle.Information, "Confirmación")
            ElseIf intContadorEst > 1 Then
                MsgBox("Los registros se aplicaron correctamente", MsgBoxStyle.Information, "Confirmación")
            End If

            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Eliminar.Click
        Dim intContador As Integer = 0
        Dim intContadorEst As Integer = 0
        Dim Opcion As Integer = 3
        Try

            For Each row As DataGridViewRow In DGrid.Rows
                If row.Cells("Selec").Value = True Then
                    If row.Cells("status").Value = "AUTORIZADO" Or _
                       row.Cells("status").Value = "CANCELADO" Then
                        MsgBox("Solo debe seleccionar registros con estatus de CAPTURA ó REVISADO.", MsgBoxStyle.Critical, "Validación")
                        Exit Sub
                    Else
                        intContador += 1
                    End If
                End If
            Next

            If intContador = 0 Then
                MsgBox("No seleccionó ningun registro.", MsgBoxStyle.Critical, "Validación")
                Exit Sub
            End If

            If MsgBox("Esta seguro de CANCELAR los registros seleccionados?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub
            For i As Integer = 0 To DGrid.Rows.Count - 1
                If DGrid.Rows(i).Cells("Selec").Value = True And DGrid.Rows(DGrid.CurrentRow.Index).Cells("status").Value = "CAPTURA" Or _
                DGrid.Rows(i).Cells("Selec").Value = True And DGrid.Rows(DGrid.CurrentRow.Index).Cells("status").Value = "REVISADO" Then
                    Dim Folio As Integer = DGrid.Rows(i).Cells("folio").Value

                    Using objGastos As New BCL.BCLCatalogoGastos(GLB_ConStringCipSis)
                        objGastos.usp_ActualizarEstatusGastos(Opcion, Folio, "ZC", GLB_Idempleado, Date.Now)
                        intContadorEst += 1
                    End Using
                End If
            Next

            If intContadorEst = 1 Then
                MsgBox("El folio se canceló correctamente", MsgBoxStyle.Information, "Confirmación")
            ElseIf intContadorEst > 1 Then
                MsgBox("Los registros se cancelaron correctamente", MsgBoxStyle.Information, "Confirmación")
            End If

            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub CancelarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CancelarToolStripMenuItem.Click
        DGrid.Rows(DGrid.CurrentRow.Index).Cells("Selec").Value = True
        Call Btn_Eliminar_Click(sender, e)
    End Sub

    Private Sub AplicarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AutorizarToolStripMenuItem.Click
        DGrid.Rows(DGrid.CurrentRow.Index).Cells("Selec").Value = True
        Call Btn_Aplicar_Click(sender, e)
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
    Private Sub DGrid_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGrid.CellFormatting
        Try

            'Tony Garcia - 15/Octubre/2012 12:25 p.m.

            Dim Sw_NoEntro As Boolean = False

            If Sw_Pintar = False Then Exit Sub

            If Me.DGrid.Columns(e.ColumnIndex).Name <> "status" Then Exit Sub
            ''If Me.DGrid.Columns(e.ColumnIndex).Name <> "fecha" Then Exit Sub
            If e.RowIndex >= DGrid.RowCount - 2 Then
                If Sw_Load = False Then
                    Sw_Pintar = False
                End If
                Exit Sub
            End If

            If IsDBNull(DGrid.Rows(e.RowIndex).Cells("status").Value) Then Exit Sub

            If DGrid.Rows(e.RowIndex).Cells("status").Value = "CAPTURA" Then
                DGrid.Rows(e.RowIndex).Cells("status").Style.BackColor = Color.Yellow
                DGrid.Rows(e.RowIndex).Cells("status").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If

            If DGrid.Rows(e.RowIndex).Cells("status").Value = "REVISADO" Then
                DGrid.Rows(e.RowIndex).Cells("status").Style.BackColor = Color.RoyalBlue
                DGrid.Rows(e.RowIndex).Cells("status").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If



            If DGrid.Rows(e.RowIndex).Cells("status").Value = "AUTORIZADO" Then
                DGrid.Rows(e.RowIndex).Cells("status").Style.BackColor = Color.YellowGreen
                DGrid.Rows(e.RowIndex).Cells("status").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If

            If DGrid.Rows(e.RowIndex).Cells("status").Value = "CANCELADO" Then
                DGrid.Rows(e.RowIndex).Cells("status").Style.BackColor = Color.Red
                DGrid.Rows(e.RowIndex).Cells("status").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If


            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Revisar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Revisar.Click
        Dim intContador As Integer = 0
        Dim intContadorEst As Integer = 0
        Dim Opcion = 1
        Try

            For Each row As DataGridViewRow In DGrid.Rows
                If row.Cells("Selec").Value = True Then
                    If row.Cells("status").Value = "REVISADO" Or _
                    row.Cells("status").Value = "AUTORIZADO" Or _
                    row.Cells("status").Value = "CANCELADO" Then
                        MsgBox("Solo debe seleccionar registros con estatus de CAPTURA", MsgBoxStyle.Critical, "Validación")
                        Exit Sub
                    Else
                        intContador += 1
                    End If
                End If
            Next

            If intContador = 0 Then
                MsgBox("No seleccionó ningun registro.", MsgBoxStyle.Critical, "Validación")
                Exit Sub
            End If

            If MsgBox("Esta seguro de haber REVISADO los registros seleccionados?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub
            For i As Integer = 0 To DGrid.Rows.Count - 1
                If DGrid.Rows(i).Cells("Selec").Value = True And DGrid.Rows(DGrid.CurrentRow.Index).Cells("status").Value = "CAPTURA" Then
                    Dim Folio As Integer = DGrid.Rows(i).Cells("folio").Value

                    Using objGastos As New BCL.BCLCatalogoGastos(GLB_ConStringCipSis)
                        objGastos.usp_ActualizarEstatusGastos(Opcion, Folio, "RV", GLB_Idempleado, Date.Now)
                        intContadorEst += 1
                    End Using
                End If
            Next

            If intContadorEst = 1 Then
                MsgBox("El estatus se actualizó correctamente", MsgBoxStyle.Information, "Confirmación")
            ElseIf intContadorEst > 1 Then
                MsgBox("Los registros se aplicaron correctamente", MsgBoxStyle.Information, "Confirmación")
            End If

            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Imprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Imprimir.Click
        Try
            Call ImprimirReporte()
            Call ImprimirReporte2()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub ImprimirReporte()
        Try
            Dim myForm As New frmReportsBrowser


            myForm.objDatasetreporteGastos = GenerarReporte()

            myForm.ReportIndex = 29
            myForm.Show()


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub ImprimirReporte2()
        Try
            Dim myForm As New frmReportsBrowser

            myForm.objDatasetreporteGastos = GenerarReporte()
            myForm.ReportIndex = 30
            myForm.Show()


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Function GenerarReporte() As DSPGastos
        'Roberto 04/03/13
        Try

            ' If accion = 1 Then
            GenerarReporte = New DSPGastos
            With DGrid
                'DGrid.DataSource = objDataSet
                For I As Integer = 0 To .RowCount - 3
        
                    Dim objDataRow As Data.DataRow = GenerarReporte.Tables(0).NewRow()

                    objDataRow.Item("foliosuc") = .Rows(I).Cells("foliosuc").Value
                    objDataRow.Item("fecha") = .Rows(I).Cells("fecha").Value
                    objDataRow.Item("descripcion") = .Rows(I).Cells("descrip").Value
                    objDataRow.Item("solicita") = .Rows(I).Cells("solicitanom").Value
                    objDataRow.Item("comentario") = .Rows(I).Cells("comentarios").Value
                    objDataRow.Item("cantidad") = .Rows(I).Cells("cantidad").Value
                    objDataRow.Item("status") = .Rows(I).Cells("status").Value
                    objDataRow.Item("sucursal") = .Rows(I).Cells("sucursal").Value
                    'objDataRow.Item("nompromotor") = objDataSet.Tables(0).Rows(I).Item("nompromotor").ToString
                    GenerarReporte.Tables(0).Rows.Add(objDataRow)
                Next
            End With
            '  End If

            'ext
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function
    Private Sub RrevisarGastoToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RrevisarGastoToolStripMenuItem1.Click
        DGrid.Rows(DGrid.CurrentRow.Index).Cells("Selec").Value = True
        Call Btn_Revisar_Click(sender, e)
    End Sub
End Class
