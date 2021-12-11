Public Class frmPpalCargos

    'Tony Garcia - 28/Junio/2013 - 12:35 p.m.
    Private objDataSet As Data.DataSet
    Private objDataSetEmp As Data.DataSet

    Dim FolioB As Integer
    Dim IdFolioSucIniB As String
    Dim IdFolioSucFinB As String
    Dim EstatusB As String
    Dim ProveedorB As String
    Dim FechaIniB As String
    Dim FechaFinB As String

    Private objDataSet2 As Data.DataSet

    Dim motivo As Integer = 0
    Dim descrip As String = ""
    Dim folio As String = ""

    Dim Sw_Load As Boolean = True
    Dim Sw_NoRegistros As Boolean = False

    Public FolioBulto As String = ""
    Public blnConsulta As Boolean = False
    Dim IdfolioB As Integer = 0

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
            Call LimpiarBusqueda()

            FechaIniB = Format(Now.Date, "yyyy-MM-dd")
            FechaFinB = Format(Now.Date, "yyyy-MM-dd")
            Call RellenaGrid()
            Call GenerarToolTip()
            Sw_Load = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub GenerarToolTip()
        Try


            ToolTip.SetToolTip(Btn_NuevoCargo, "Nueva Nota de Cargo")
            ToolTip.SetToolTip(Btn_NuevoCred, "Nueva Nota de Crédito")
            ToolTip.SetToolTip(Btn_Consultar, "Consultar Nota")
            ToolTip.SetToolTip(Btn_AplicarNota, "Aplicar Notas Seleccionadas")

            ToolTip.SetToolTip(Btn_Filtro, "Búsqueda Avanzada")

            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
            ToolTip.SetToolTip(Btn_Imprimir, "Imprimir Información")

            ToolTip.SetToolTip(Btn_Salir, "Salir")



        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub RellenaGrid()
        Using objNotas As New BCL.BCLNotasCC(GLB_ConStringCipSis)

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

                objDataSet = objNotas.usp_PpalNotasCC(FolioB, IdFolioSucIniB, IdFolioSucFinB, EstatusB, ProveedorB, FechaIniB, FechaFinB)
                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section

                    DGrid.DataSource = objDataSet.Tables(0)
                    Dim dtEmpleado As DataTable = TryCast(DGrid.DataSource, DataTable)

                    For Each row As DataRow In dtEmpleado.Rows
                        Using objMySqlGral As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)
                            Try
                                Dim Usuario1 As String
                                Dim Usuario2 As String
                                

                                objDataSetEmp = objMySqlGral.usp_TraerNomEmpleado(row("idusuario"), "", "", "", "", 0)
                                If objDataSetEmp.Tables(0).Rows.Count = 1 Then
                                    Usuario1 = objDataSetEmp.Tables(0).Rows(0).Item("idempleado").ToString
                                    Usuario2 = objDataSetEmp.Tables(0).Rows(0).Item("nomcompleto").ToString

                                    row("nombreusu") = Usuario1 & " - " & Usuario2
                                End If
                            Catch ExceptionErr As Exception
                                MessageBox.Show(ExceptionErr.Message.ToString)
                            End Try
                        End Using
                    Next

                    DGrid.DataSource = objDataSet.Tables(0)

                    InicializaGrid()
                    'LimpiarBusqueda()
                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True
                    Btn_NuevoCred.Enabled = True
                    Btn_Consultar.Enabled = True
                    Sw_NoRegistros = True
                Else
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron Notas que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                    'Btn_NuevoCred.Enabled = False
                    Btn_Consultar.Enabled = False
                End If
                'Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using


    End Sub
    Private Sub LimpiarBusqueda()
        FolioB = 0
        IdFolioSucIniB = ""
        IdFolioSucFinB = ""
        EstatusB = "CA"
        ProveedorB = ""
        FechaIniB = "1900-01-01"
        FechaFinB = "1900-01-01"


        If blnConsulta = True Then
            IdFolioSucIniB = FolioBulto
            IdFolioSucFinB = FolioBulto
            EstatusB = "AP"
        End If
    End Sub

    Private Sub Btn_Refrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Sub InicializaGrid()
        Try
            Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
            Dim row As DataRow = dt.NewRow()
            ' row(3) = "Total: "
            row(5) = "Total: "

            row(6) = pub_SumarColumnaGrid(DGrid, 6, DGrid.RowCount - 1)
            row(7) = pub_SumarColumnaGrid(DGrid, 7, DGrid.RowCount - 1)
            row(8) = pub_SumarColumnaGrid(DGrid, 8, DGrid.RowCount - 1)


            dt.Rows.InsertAt(row, 0)
            DGrid.DataSource = dt

            DGrid.RowHeadersVisible = False




            DGrid.RowHeadersVisible = False
            DGrid.Columns(0).HeaderText = "Folio Nota"
            DGrid.Columns(1).HeaderText = "Folio Bulto"
            DGrid.Columns(2).HeaderText = "Fecha"
            DGrid.Columns(3).HeaderText = "Tipo"
            DGrid.Columns(4).HeaderText = "IdUsuario"
            DGrid.Columns(5).HeaderText = "Usuario"

            DGrid.Columns(6).HeaderText = "Subtotal"
            DGrid.Columns(7).HeaderText = "Impuesto"



            DGrid.Columns(8).HeaderText = "Total"
            DGrid.Columns(9).HeaderText = "Estatus"
            DGrid.Columns(10).HeaderText = "IdMotivo"
            DGrid.Columns(11).HeaderText = "Dsctopp"
            DGrid.Columns(12).HeaderText = "Dscto01"
            DGrid.Columns(13).HeaderText = "Dscto02"
            DGrid.Columns(14).HeaderText = "Dscto03"
            DGrid.Columns(15).HeaderText = "Dscto04"
            DGrid.Columns(16).HeaderText = "Dscto05"
            DGrid.Columns(17).HeaderText = "Aplicada"


            'DGrid.Columns(0).Visible = False
            DGrid.Columns(4).Visible = False
            DGrid.Columns(10).Visible = False
            DGrid.Columns(11).Visible = False
            DGrid.Columns(12).Visible = False
            DGrid.Columns(13).Visible = False
            DGrid.Columns(14).Visible = False
            DGrid.Columns(15).Visible = False
            DGrid.Columns(16).Visible = False


            DGrid.Columns(0).ReadOnly = True
            DGrid.Columns(1).ReadOnly = True
            DGrid.Columns(2).ReadOnly = True
            DGrid.Columns(3).ReadOnly = True
            DGrid.Columns(5).ReadOnly = True

            DGrid.Columns(8).ReadOnly = True  '
            DGrid.Columns(9).ReadOnly = True

            DGrid.Columns(0).DefaultCellStyle.Format = "000000"
            DGrid.Columns(6).DefaultCellStyle.Format = "c"
            DGrid.Columns(7).DefaultCellStyle.Format = "c"
            DGrid.Columns(8).DefaultCellStyle.Format = "c"

            DGrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


            DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            DGrid.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            Call AgregarColumna()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub AgregarColumna()
        Dim colImagen As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        colImagen.Name = "Selec"
        colImagen.HeaderText = "Selec"
        colImagen.DisplayIndex = 18
        colImagen.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        colImagen.CellTemplate = New DataGridViewCheckBoxCell()
        ' añadir columna de imagen a la coleccion del grid 
        DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        ''DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DGrid.Columns.Add(colImagen)
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

    Private Sub Btn_NuevoCargo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_NuevoCargo.Click
        Dim myForm As New frmCatalogoCargos
        myForm.Accion = 1
        myForm.Opcion = 1
        myForm.Tipo = "CA"
        myForm.ShowDialog()
        If myForm.Sw_Registro = True Then
            Call RellenaGrid()
        End If
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
        If Sw_NoRegistros = False Then Exit Sub

        If DGrid.CurrentRow Is Nothing Then Exit Sub

        Dim myForm As New frmCatalogoCargos
        Dim Tipo As String

        Tipo = Mid(DGrid.Rows(DGrid.CurrentRow.Index).Cells("tipo").Value.ToString.Trim(), 1, 2)

        If Tipo = "CA" Then
            myForm.Accion = 3
            myForm.Tipo = Tipo
            myForm.Opcion = 2
        ElseIf Tipo = "CR" Then
            myForm.Accion = 4
            myForm.Tipo = Tipo
            myForm.Opcion = 2
        End If

        myForm.Txt_IdFolio.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("folio").Value.ToString.Trim()

        myForm.ShowDialog()

        If myForm.Sw_Registro = True Then
            Call RellenaGrid()
        End If
    End Sub

    Private Sub Btn_NuevoCred_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_NuevoCred.Click
        Dim myForm As New frmCatalogoCargos

        myForm.Accion = 2
        myForm.Opcion = 1
        myForm.Tipo = "CR"
        myForm.ShowDialog()
        If myForm.Sw_Registro = True Then
            Call RellenaGrid()
        End If
    End Sub

    Private Sub Btn_Filtro_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        Dim myForm As New frmFiltrosNotasCC

        If FechaIniB <> "1900-01-01" Then
            myForm.Chk_Fecha.Checked = True
            myForm.DTPicker2.Value = FechaIniB
            myForm.DTPicker3.Value = FechaFinB
        End If

        If FolioB = 0 Then
            myForm.Txt_Folio.Text = ""
        Else
            myForm.Txt_Folio.Text = FolioB
        End If

        myForm.Txt_IdFolioSucIni.Text = IdFolioSucIniB
        myForm.Txt_IdFolioSucFin.Text = IdFolioSucFinB
        myForm.Cbo_Estatus.Text = EstatusB

        If EstatusB = "CA" Then
            myForm.Cbo_Estatus.Text = "CAPTURA"
        ElseIf EstatusB = "AP" Then
            myForm.Cbo_Estatus.Text = "APLICADA"
        ElseIf EstatusB = "ZC" Then
            myForm.Cbo_Estatus.Text = "CANCELADA"
        ElseIf EstatusB = "SB" Then
            myForm.Cbo_Estatus.Text = "STAND BY"
        End If

        myForm.Txt_Proveedor.Text = ProveedorB
   
        myForm.ShowDialog()

        If myForm.Chk_Fecha.Checked = True Then
            FechaIniB = Format(myForm.DTPicker2.Value, "yyyy-MM-dd")
            FechaFinB = Format(myForm.DTPicker3.Value, "yyyy-MM-dd")
        Else
            FechaIniB = "1900-01-01"
            FechaFinB = "1900-01-01"
        End If

        If myForm.Txt_Folio.Text <> "" Then
            FolioB = CInt(myForm.Txt_Folio.Text)
        Else
            FolioB = 0
        End If

        IdFolioSucIniB = myForm.Txt_IdFolioSucIni.Text
        IdFolioSucFinB = myForm.Txt_IdFolioSucFin.Text


        If myForm.Cbo_Estatus.Text = "APLICADA" Then
            EstatusB = "AP"
        ElseIf myForm.Cbo_Estatus.Text = "CANCELADA" Then
            EstatusB = "ZC"
        ElseIf myForm.Cbo_Estatus.Text = "STAND BY" Then
            EstatusB = "SB"
        ElseIf myForm.Cbo_Estatus.Text = "CAPTURA" Then
            EstatusB = "CA"
        Else
            EstatusB = ""
        End If

        ProveedorB = myForm.Txt_Proveedor.Text
        
        If myForm.Sw_Filtro = True Then
            Call RellenaGrid()
        End If
    End Sub


    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub

    Private Sub CancelarNotaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelarNotaToolStripMenuItem.Click
        Try


            If MsgBox("Esta seguro de Cancelar la Nota seleccionada?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub
            If DGrid.Rows(DGrid.CurrentRow.Index).Cells("status").Value = "CAPTURA" Then

                Using objNotas As New BCL.BCLNotasCC(GLB_ConStringCipSis)
                    Dim IdFolio As String = DGrid.Rows(DGrid.CurrentRow.Index).Cells("folio").Value
                    Dim Tipo As String = DGrid.Rows(DGrid.CurrentRow.Index).Cells("tipo").Value
                    Dim IdMotivo As Integer = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idmotivo").Value

                    If Not objNotas.usp_ActualizaEstatusNotaCC(IdFolio, Tipo, "ZC", CDate("1900-01-01"), IdMotivo) Then
                        Throw New Exception("Error al Actualizar el Estatus de la Nota")
                    Else
                        MsgBox("La Nota se canceló satisfactoriamente.", MsgBoxStyle.Information, "Aviso")
                    End If
                End Using
            Else
                If MsgBox("La nota ya se encuentra aplicada, esta seguro de querer cancelarla.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmación") = MsgBoxResult.No Then Exit Sub
                'Exit Sub
                'mreyes 27/Julio/2015   11:26 a.m.
                'checar que es y generar lo adverso.

                'Tipo
                Dim objDataSet As Data.DataSet
                Dim Estatus As String = ""
                Dim Opcion As Integer = 1
                Using objNotas As New BCL.BCLNotasCC(GLB_ConStringCipSis)
                    'Get a new Project DataSet
                    Try


                        Estatus = "AP"

                        objDataSet = objNotas.Inserta_Nota  'INSERTA NUEVO DATASET
                        'Initialize a datarow object from the Project DataSet
                        Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow

                        'Set the values in the DataRow
                        If DGrid.Rows(DGrid.CurrentRow.Index).Cells("tipo").Value = "CARGO" Then
                            Call usp_TraerUltFolioNotaCC("CA")
                        Else
                            Call usp_TraerUltFolioNotaCC("CR")
                        End If

                        objDataRow.Item("folio") = IdfolioB
                        objDataRow.Item("idfoliosuc") = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idfoliosuc").Value

                        If GLB_CveSucursal = "95" Or GLB_CveSucursal = "" Then
                            objDataRow.Item("cvesuc") = "00"
                        Else
                            objDataRow.Item("cvesuc") = GLB_CveSucursal
                        End If

                        objDataRow.Item("fecha") = Format(Now.Date, "yyyy-MM-dd")

                        If DGrid.Rows(DGrid.CurrentRow.Index).Cells("tipo").Value = "CARGO" Then
                            objDataRow.Item("tipo") = "CR"
                        Else
                            objDataRow.Item("tipo") = "CA"
                        End If

                        objDataRow.Item("status") = Estatus


                        objDataRow.Item("aplicada") = Format(Now.Date, "yyyy-MM-dd")


                        objDataRow.Item("idmotivo") = DGrid.Rows(DGrid.CurrentRow.Index).Cells("IDMOTIVO").Value
                        objDataRow.Item("importe") = DGrid.Rows(DGrid.CurrentRow.Index).Cells("importe").Value
                        objDataRow.Item("iva") = DGrid.Rows(DGrid.CurrentRow.Index).Cells("iva").Value
                        objDataRow.Item("imptotal") = DGrid.Rows(DGrid.CurrentRow.Index).Cells("imptotal").Value
                        objDataRow.Item("descrip") = ""
                        objDataRow.Item("idusuario") = GLB_Idempleado

                        'Add the DataRow to the DataSet
                        objDataSet.Tables(0).Rows.Add(objDataRow)

                        ''Add the Project
                        If Not objNotas.usp_Captura_NotaCC(Opcion, objDataSet) Then

                        End If

                        '' SE AGREGO PARA CANCELAR.


                        If Not objNotas.usp_ActualizaFacturaNotaCC(DGrid.Rows(DGrid.CurrentRow.Index).Cells("idfoliosuc").Value, "CR", 0, 0, 0, 0, 0, 0, 0, 0) Then
                            Throw New Exception("Error al Actualizar el Estatus de la Nota")
                        Else
                            'MsgBox("La Nota se Aplicó satisfactoriamente.", MsgBoxStyle.Information, "Aviso")
                            'InsertaNota = True
                        End If


                        If Not objNotas.usp_ActualizaFacturaNotaCC(DGrid.Rows(DGrid.CurrentRow.Index).Cells("idfoliosuc").Value, "CA", 0, 0, 0, 0, 0, 0, 0, 0) Then
                            Throw New Exception("Error al Actualizar el Estatus de la Nota")
                        Else
                            'MsgBox("La Nota se Aplicó satisfactoriamente.", MsgBoxStyle.Information, "Aviso")
                            'InsertaNota = True
                        End If

                        GoTo SALIR

                    Catch ExceptionErr As Exception
                        MessageBox.Show(ExceptionErr.Message.ToString)
                    End Try
                End Using


                'Using objNotas As New BCL.BCLNotasCC(GLB_ConStringCipSis)
                '    Dim IdFolio As String = DGrid.Rows(DGrid.CurrentRow.Index).Cells("folio").Value
                '    Dim Tipo As String = DGrid.Rows(DGrid.CurrentRow.Index).Cells("tipo").Value
                '    Dim IdMotivo As Integer = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idmotivo").Value

                '    If Not objNotas.usp_ActualizaEstatusNotaCC(IdFolio, Tipo, "AP", GLB_FechaHoy, IdMotivo) Then
                '        Throw New Exception("Error al Actualizar el Estatus de la Nota")
                '    End If
                'End Using


                Using objNotas As New BCL.BCLNotasCC(GLB_ConStringCipSis)
                    Dim IdFolioSuc As String = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idfoliosuc").Value.ToString.Trim()
                    Dim Tipo As String ' = Mid(DGrid.Rows(DGrid.CurrentRow.Index).Cells("tipo").Value.ToString.Trim(), 1, 2)

                    If DGrid.Rows(DGrid.CurrentRow.Index).Cells("tipo").Value = "CARGO" Then
                        Tipo = "CR"
                    Else
                        Tipo = "CA"
                    End If



                    Dim Importe As Decimal = CDec(DGrid.Rows(DGrid.CurrentRow.Index).Cells("imptotal").Value)
                    Dim IdMotivo As Integer = CInt(DGrid.Rows(DGrid.CurrentRow.Index).Cells("idmotivo").Value)
                    Dim dsctopp As Integer = CInt(DGrid.Rows(DGrid.CurrentRow.Index).Cells("dsctopp").Value)
                    Dim dscto01 As Integer = CInt(DGrid.Rows(DGrid.CurrentRow.Index).Cells("dscto01").Value)
                    Dim dscto02 As Integer = CInt(DGrid.Rows(DGrid.CurrentRow.Index).Cells("dscto02").Value)
                    Dim dscto03 As Integer = CInt(DGrid.Rows(DGrid.CurrentRow.Index).Cells("dscto03").Value)
                    Dim dscto04 As Integer = CInt(DGrid.Rows(DGrid.CurrentRow.Index).Cells("dscto04").Value)
                    Dim dscto05 As Integer = CInt(DGrid.Rows(DGrid.CurrentRow.Index).Cells("dscto05").Value)

                    If Not objNotas.usp_ActualizaFacturaNotaCC(IdFolioSuc, Tipo, Importe, IdMotivo, dsctopp, dscto01, dscto02, dscto03, dscto04, dscto05) Then
                        Throw New Exception("Error al Actualizar el Estatus de la Nota")
                    Else
                        'MsgBox("La Nota se Aplicó satisfactoriamente.", MsgBoxStyle.Information, "Aviso")
                        'InsertaNota = True
                    End If
                End Using
SALIR:
                MsgBox("La Nota se canceló satisfactoriamente.", MsgBoxStyle.Information, "Aviso")


            End If
            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Function Inserta_Nota() As Boolean
       
    End Function


    Private Sub AplicarNotaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AplicarNotaToolStripMenuItem.Click
        Try
            DGrid.Rows(DGrid.CurrentRow.Index).Cells("Selec").Value = True
            Call Btn_AplicarNota_Click(sender, e)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ConsultarNotaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultarNotaToolStripMenuItem.Click
        Call Btn_Consultar_Click(sender, e)
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


    Private Sub Btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Imprimir.Click
        Try
            If DGrid.Rows(DGrid.CurrentRow.Index).Cells("status").Value <> "APLICADA" Then
                MsgBox("Solo puede imprimir Notas Aplicadas.", MsgBoxStyle.Critical, "Aviso")
            Else
                Call ImprimirReporte()
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub ImprimirReporte()
        Try
            Dim myForm As New frmReportsBrowser

            myForm.objDataSetCargos = GenerarReporte()
            myForm.ReportIndex = 14
            myForm.Show()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Function GenerarReporte() As DSPReporteCargos
        'Roberto 04/03/13
        Try
            Dim IdFolio As String = DGrid.Rows(DGrid.CurrentRow.Index).Cells("folio").Value
            Dim Tipo As String = DGrid.Rows(DGrid.CurrentRow.Index).Cells("tipo").Value
            Using objFAct As New BCL.BCLNotasCC(GLB_ConStringCipSis)
                objDataSet2 = objFAct.usp_TraerNotaCC(2, "", IdFolio, Tipo)
                motivo = objDataSet2.Tables(0).Rows(0).Item("idmotivo")
                folio = objDataSet2.Tables(0).Rows(0).Item("folio")
            End Using
            Using objtraer As New BCL.BCLNotasCC(GLB_ConStringCipSis)
                objDataSet = objtraer.usp_TraerUnMotivosRem(motivo)
                descrip = objDataSet.Tables(0).Rows(0).Item("descrip")
            End Using
            If GLB_CveSucursal = "00" Or GLB_CveSucursal = "95" Or GLB_CveSucursal = "" Then
                folio = "A00-" & pub_RellenarIzquierda(folio, 6)
            Else
                folio = "S" & GLB_CveSucursal & "-" & pub_RellenarIzquierda(folio, 6)
            End If
            GenerarReporte = New DSPReporteCargos
            With objDataSet2
                For I As Integer = 0 To .Tables(0).Rows.Count - 1
                    Dim objDataRow As Data.DataRow = GenerarReporte.Tables(0).NewRow()
                    objDataRow.Item("idfoliosuc") = .Tables(0).Rows(0).Item("idfoliosuc").ToString
                    objDataRow.Item("proveedor") = .Tables(0).Rows(0).Item("proveedor").ToString
                    objDataRow.Item("raz_soc") = .Tables(0).Rows(0).Item("raz_soc").ToString
                    objDataRow.Item("factprov") = .Tables(0).Rows(0).Item("factprov").ToString
                    objDataRow.Item("referenc") = .Tables(0).Rows(0).Item("referenc").ToString
                    objDataRow.Item("fecha") = .Tables(0).Rows(0).Item("fecha").ToString
                    objDataRow.Item("status") = .Tables(0).Rows(0).Item("status").ToString
                    objDataRow.Item("motivo") = descrip
                    objDataRow.Item("importe") = .Tables(0).Rows(0).Item("importe").ToString
                    'objDataRow.Item("impuesto") = .Rows(I).Cells(11).Value
                    objDataRow.Item("iva") = .Tables(0).Rows(0).Item("iva").ToString
                    objDataRow.Item("imptotal") = .Tables(0).Rows(0).Item("imptotal").ToString
                    objDataRow.Item("descrip") = .Tables(0).Rows(0).Item("descrip").ToString
                    objDataRow.Item("folio") = folio
                    objDataRow.Item("tipo") = Tipo
                    'objDataRow.Item("suma") = suma
                    GenerarReporte.Tables(0).Rows.Add(objDataRow)

                Next

            End With
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Private Sub usp_TraerUltFolioNotaCC(ByVal Tipo As String)


        Dim Folio As String
        Using objNotas As New BCL.BCLNotasCC(GLB_ConStringCipSis)
            Try
                objDataSet = objNotas.usp_TraerUltFolioNotaCC(Tipo)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("folio").ToString.Trim = "" Then
                        IdFolioB = 1
                    Else
                        Folio = objDataSet.Tables(0).Rows(0).Item("folio").ToString
                        Folio = Folio + 1
                        IdFolioB = Folio
                    End If
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub


    Private Sub Btn_AplicarNota_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_AplicarNota.Click
        Dim InsertaNota As Boolean = False
        Dim intContador As Integer = 0
        Try

            For Each row As DataGridViewRow In DGrid.Rows
                If row.Cells("Selec").Value = True Then
                    If row.Cells("status").Value = "CAPTURA" Or _
                    row.Cells("status").Value = "STAND BY" Then
                        intContador += 1
                    Else
                        MsgBox("Solo pueden seleccionar Folios con estatus de CAPTURA o STAND BY.", MsgBoxStyle.Critical, "Aviso")
                        Exit Sub
                    End If
                End If
            Next

            If intContador = 0 Then
                MsgBox("No se selecciono ningun Registro", MsgBoxStyle.OkOnly, "Aviso")
                Exit Sub
            End If

            If MsgBox("Esta seguro de Aplicar las Notas seleccionadas?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub

            For i As Integer = 0 To DGrid.Rows.Count - 1
                If DGrid.Rows(DGrid.CurrentRow.Index).Cells("status").Value = "CAPTURA" Or _
                DGrid.Rows(DGrid.CurrentRow.Index).Cells("status").Value = "STAND BY" Then
                    If DGrid.Rows(i).Cells("Selec").Value = True Then
                        Using objNotas As New BCL.BCLNotasCC(GLB_ConStringCipSis)
                            Dim IdFolio As String = DGrid.Rows(DGrid.CurrentRow.Index).Cells("folio").Value
                            Dim Tipo As String = DGrid.Rows(DGrid.CurrentRow.Index).Cells("tipo").Value
                            Dim IdMotivo As Integer = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idmotivo").Value

                            If Not objNotas.usp_ActualizaEstatusNotaCC(IdFolio, Tipo, "AP", GLB_FechaHoy, IdMotivo) Then
                                Throw New Exception("Error al Actualizar el Estatus de la Nota")
                            Else
                                If intContador > 1 Then
                                    MsgBox("Las Notas se aplicaron satisfactoriamente.", MsgBoxStyle.Information, "Aviso")
                                Else
                                    MsgBox("La Nota de " + Tipo + " '" + pub_RellenarIzquierda(DGrid.Rows(DGrid.CurrentRow.Index).Cells("folio").Value, 6) + "' se aplicó satisfactoriamente.", MsgBoxStyle.Information, "Aviso")
                                End If

                                InsertaNota = True
                            End If
                        End Using

                        If InsertaNota = True Then
                            Using objNotas As New BCL.BCLNotasCC(GLB_ConStringCipSis)
                                Dim IdFolioSuc As String = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idfoliosuc").Value.ToString.Trim()
                                Dim Tipo As String = Mid(DGrid.Rows(DGrid.CurrentRow.Index).Cells("tipo").Value.ToString.Trim(), 1, 2)
                                Dim Importe As Decimal = CDec(DGrid.Rows(DGrid.CurrentRow.Index).Cells("imptotal").Value)
                                Dim IdMotivo As Integer = CInt(DGrid.Rows(DGrid.CurrentRow.Index).Cells("idmotivo").Value)
                                Dim dsctopp As Integer = CInt(DGrid.Rows(DGrid.CurrentRow.Index).Cells("dsctopp").Value)
                                Dim dscto01 As Integer = CInt(DGrid.Rows(DGrid.CurrentRow.Index).Cells("dscto01").Value)
                                Dim dscto02 As Integer = CInt(DGrid.Rows(DGrid.CurrentRow.Index).Cells("dscto02").Value)
                                Dim dscto03 As Integer = CInt(DGrid.Rows(DGrid.CurrentRow.Index).Cells("dscto03").Value)
                                Dim dscto04 As Integer = CInt(DGrid.Rows(DGrid.CurrentRow.Index).Cells("dscto04").Value)
                                Dim dscto05 As Integer = CInt(DGrid.Rows(DGrid.CurrentRow.Index).Cells("dscto05").Value)

                                If Not objNotas.usp_ActualizaFacturaNotaCC(IdFolioSuc, Tipo, Importe, IdMotivo, dsctopp, dscto01, dscto02, dscto03, dscto04, dscto05) Then
                                    'Throw New Exception("Error al Actualizar el Estatus de la Nota")
                                Else
                                    'MsgBox("La Nota se Aplicó satisfactoriamente.", MsgBoxStyle.Information, "Aviso")
                                    'InsertaNota = True
                                End If
                            End Using
                        End If
                    Else
                        'MsgBox("Solo pueden Aplicar Notas con estatus de CAPTURA", MsgBoxStyle.Critical, "Aviso")
                        'Exit Sub
                    End If
                End If
            Next
            RellenaGrid()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub ConsultaBultoToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ConsultaBultoToolStripMenuItem1.Click
        Try
            Dim myForm As New frmCatalogoReciboBultos
            myForm.Accion = 3
            'myForm.Folio = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idfolio").Value.ToString.Trim()
            myForm.Txt_Folio.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idfoliosuc").Value.ToString.Trim()
            myForm.ShowDialog()
            'If myForm.Guardo = True Then
            '    frmPpalActividadesEmp_Load(sender, e)
            'End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
End Class