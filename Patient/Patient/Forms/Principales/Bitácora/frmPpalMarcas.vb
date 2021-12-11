Public Class frmPpalMarcas
    'mreyes 04/Mayo/2012 07:05 p.m.
    Private objDataSet As Data.DataSet
    Private objDataSetEmp As Data.DataSet

    Dim Proveedorb As String
    Dim Raz_Socb As String = ""
    Dim Estadob As String = ""
    Dim Ciudadb As String = ""
    Dim Sw_NoRegistros As Boolean = False
    Dim Sw_Load As Boolean = True
    Dim ASignaMarca As Integer = 0
    Dim Estatus As String = ""

    Private Sub frmPpalMarcas_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Sw_NoRegistros = False Then Exit Sub
        If Sw_Load = True Then
            Sw_Load = False
            InicializaGrid()
            'AgregarColumna()
            '    Call BarrerGrid()
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
            Call LimpiarBusqueda()
            'Call RellenaGrid()
            Chk_Activas.Checked = True
            Call GenerarToolTip()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub GenerarToolTip()
        Try


            ToolTip.SetToolTip(Btn_Nuevo, "Nueva Marca")
            ToolTip.SetToolTip(Btn_Editar, "Editar Marca")
            ToolTip.SetToolTip(Btn_Eliminar, "Eliminar Marca")
            ToolTip.SetToolTip(Btn_Consultar, "Consultar Marca")
            ToolTip.SetToolTip(Btn_Asignar, "Seleccionar empleado para asignar marcas seleccionadas")

            ToolTip.SetToolTip(Btn_Filtro, "Búsqueda Avanzada")

            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
            ToolTip.SetToolTip(Btn_Imprimir, "Imprimir Información")

            ToolTip.SetToolTip(Btn_Salir, "Salir")



        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub RellenaGrid()
        'mreyes 28/Febrero/2012 01:41 p.m.
        Using objMarca As New BCL.BCLCatalogoMarca(GLB_ConStringCipSis)

            Try
                Me.Cursor = Cursors.WaitCursor
                DGrid.DataSource = Nothing

                If Sw_Load = True Then
                    ' Sw_Load = False
                Else
                    If Sw_NoRegistros = True Then
                        DGrid.Columns.Remove("Selec")

                    End If
                End If
                objDataSet = objMarca.usp_PpalCatalogoMarca("", Estatus)
                'Populate the Project Details section

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    DGrid.DataSource = Nothing
                    DGrid.DataSource = objDataSet.Tables(0)

                    Dim dtEmpleado As DataTable = TryCast(DGrid.DataSource, DataTable)

                    For Each row As DataRow In dtEmpleado.Rows
                        Using objMySqlGral As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)
                            Try
                                Dim strAsigna1 As String
                                Dim strAsigna2 As String

                                If row("asignado") = "NO ASIGNADO" Then Continue For
                                objDataSetEmp = objMySqlGral.usp_TraerNomEmpleado(row("asignado"), "", "", "", "", 0)
                                If objDataSetEmp.Tables(0).Rows.Count = 1 Then
                                    strAsigna1 = objDataSetEmp.Tables(0).Rows(0).Item("idempleado").ToString
                                    strAsigna2 = objDataSetEmp.Tables(0).Rows(0).Item("nomcompleto").ToString

                                    row("asignado") = strAsigna1 & " - " & strAsigna2
                                End If

                            Catch ExceptionErr As Exception
                                MessageBox.Show(ExceptionErr.Message.ToString)
                            End Try
                        End Using
                    Next

                    'InicializaGrid()

                End If



                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section

                    DGrid.DataSource = objDataSet.Tables(0)
                    If Sw_Load = False Then
                        InicializaGrid()
                    End If
                    'LimpiarBusqueda()
                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True
                    Btn_Editar.Enabled = True
                    Btn_Consultar.Enabled = True
                    Sw_NoRegistros = True
                Else
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron Marcas que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
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

        Proveedorb = ""
        Raz_Socb = ""
        Estadob = ""
        Ciudadb = ""
        Estatus = "1"

    End Sub

    Private Sub Btn_Refrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Sub InicializaGrid()
        '' marca, Estilon, Estilof, descripc, familia, linea, proveedor, tipoart, categoria
        'mreyes 17/Febrero/2011 11:02 p.m.
        Try

            DGrid.RowHeadersVisible = False
            DGrid.Columns(0).HeaderText = "Marca"
            DGrid.Columns(1).HeaderText = "Descripción"
            DGrid.Columns(2).HeaderText = "Factor"
            DGrid.Columns(3).HeaderText = "Resmin"
            DGrid.Columns(4).HeaderText = "Estatus"
            DGrid.Columns(5).HeaderText = "Asignado"


            DGrid.Columns(2).Visible = False
            DGrid.Columns(3).Visible = False

            For i As Integer = 0 To DGrid.Columns.Count - 1
                DGrid.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            For i As Integer = 0 To DGrid.Rows.Count - 1
                For j As Integer = 0 To DGrid.Columns.Count - 1
                    DGrid.Columns(j).ReadOnly = True
                Next
            Next

            AgregarColumna()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub AgregarColumna()
        Dim colImagen As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        colImagen.Name = "Selec"
        colImagen.HeaderText = "Selec"
        colImagen.DisplayIndex = 7
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

    Private Sub Btn_Nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Nuevo.Click
        Dim myForm As New frmCatalogoMarca
        myForm.Accion = 1
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
            'Call Btn_Consultar_Click(sender, e)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Consultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Consultar.Click
        If Sw_NoRegistros = False Then Exit Sub
        Dim myForm As New frmCatalogoMarca

        myForm.Accion = 4
        myForm.Txt_Marca.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("marca").Value.ToString.Trim()

        myForm.ShowDialog()
        'Call RellenaGrid()
    End Sub

    Private Sub Btn_Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar.Click
        If Sw_NoRegistros = False Then Exit Sub
        Dim myForm As New frmCatalogoMarca

        myForm.Accion = 2
        myForm.Txt_Marca.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells(0).Value.ToString.Trim()
        myForm.ShowDialog()
        If myForm.Sw_Registro = True Then
            Call RellenaGrid()
        End If
    End Sub

    Private Sub Btn_Filtro_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        Dim myForm As New frmFiltrosProveedor
        myForm.Txt_Raz_Soc.Text = Raz_Socb
        myForm.Cbo_Estado.Text = Estadob
        myForm.Cbo_Ciudad.Text = Ciudadb
        myForm.ShowDialog()
        Raz_Socb = myForm.Txt_Raz_Soc.Text
        Estadob = myForm.Cbo_Estado.Text
        ciudadb = myForm.Cbo_Ciudad.Text

        If myForm.Sw_Filtro = True Then
            Call RellenaGrid()
        End If
    End Sub

    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

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

    Private Sub ActivaToolStripMenuItem2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ActivaToolStripMenuItem2.Click
        DGrid.Rows(DGrid.CurrentRow.Index).Cells("Selec").Value = True
        Call Btn_Activas_Click(sender, e)
    End Sub

    Private Sub InactivaToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles InactivaToolStripMenuItem1.Click
        DGrid.Rows(DGrid.CurrentRow.Index).Cells("Selec").Value = True
        Call Btn_Inactivas_Click(sender, e)
    End Sub

    Private Sub Btn_Asignar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Asignar.Click
        Dim intContador As Integer = 0
        Dim intContadorB As Integer = 0
        Dim myForm As New frmAsignarMarca
        Try

            For Each row As DataGridViewRow In DGrid.Rows
                If row.Cells("Selec").Value = True Then
                    intContador += 1
                End If
            Next
            If intContador = 0 Then
                MsgBox("No se selecciono ninguna Marca.", MsgBoxStyle.OkOnly, "Aviso")
                Exit Sub
            End If




            myForm.ShowDialog()

            ASignaMarca = myForm.IdEmpleado

            If ASignaMarca <> 0 Then
                For i As Integer = 0 To DGrid.Rows.Count - 1
                    If DGrid.Rows(i).Cells("Selec").Value = True  Then
                        Dim Marca As String = DGrid.Rows(i).Cells("marca").Value

                        Using objMarca As New BCL.BCLCatalogoMarca(GLB_ConStringCipSis)
                            objMarca.usp_AsignarMarca(Marca, ASignaMarca)
                        End Using
                        intContadorB += 1
                    End If
                Next


                If intContadorB = 0 Then
                    MsgBox("Proceso Terminado. No se encontraron registros que actualizar.", MsgBoxStyle.OkOnly, "Aviso")
                    Exit Sub
                Else
                    MsgBox("Proceso Terminado", MsgBoxStyle.Information, "Confirmación")
                End If

            Else
                MsgBox("No seleccionó ningún Empleado.", MsgBoxStyle.OkOnly, "Aviso")
                Exit Sub
            End If

            RellenaGrid()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Chk_Activas_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chk_Activas.CheckedChanged
        Try
            If Chk_Activas.Checked = True Then
                Estatus = "1"
                RellenaGrid()
            ElseIf Chk_Activas.Checked = False Then
                Estatus = ""
                RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
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

    Private Sub Btn_Activas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Activas.Click
        Dim intContador As Integer = 0
        Dim intContadorB As Integer = 0

        Try

            For Each row As DataGridViewRow In DGrid.Rows
                If row.Cells("Selec").Value = True Then
                    intContador += 1
                End If
            Next
            If intContador = 0 Then
                MsgBox("No se selecciono ninguna Marca.", MsgBoxStyle.OkOnly, "Aviso")
                Exit Sub
            End If


            If intContador <> 0 Then
                If MsgBox("Está seguro de cambiar a Activas las marcas Seleccionadas?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub
                For i As Integer = 0 To DGrid.Rows.Count - 1
                    If DGrid.Rows(i).Cells("Selec").Value = True Then
                        Dim Marca As String = DGrid.Rows(i).Cells("marca").Value

                        Using objMarca As New BCL.BCLCatalogoMarca(GLB_ConStringCipSis)
                            objMarca.usp_ActualizarEstatusMarca(Marca, "1")
                        End Using
                        intContadorB += 1
                    End If
                Next


                If intContadorB = 0 Then
                    MsgBox("Proceso Terminado. No se encontraron registros que actualizar.", MsgBoxStyle.OkOnly, "Aviso")
                    Exit Sub
                Else
                    MsgBox("Proceso Terminado", MsgBoxStyle.Information, "Confirmación")
                End If

            Else
                MsgBox("No seleccionó ninguna Marca.", MsgBoxStyle.OkOnly, "Aviso")
                Exit Sub
            End If

            RellenaGrid()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Inactivas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Inactivas.Click
        Dim intContador As Integer = 0
        Dim intContadorB As Integer = 0

        Try

            For Each row As DataGridViewRow In DGrid.Rows
                If row.Cells("Selec").Value = True Then
                    intContador += 1
                End If
            Next
            If intContador = 0 Then
                MsgBox("No se selecciono ninguna Marca.", MsgBoxStyle.OkOnly, "Aviso")
                Exit Sub
            End If


            If intContador <> 0 Then
                If MsgBox("Está seguro de cambiar a Inactivas las marcas Seleccionadas?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub
                For i As Integer = 0 To DGrid.Rows.Count - 1
                    If DGrid.Rows(i).Cells("Selec").Value = True Then
                        Dim Marca As String = DGrid.Rows(i).Cells("marca").Value

                        Using objMarca As New BCL.BCLCatalogoMarca(GLB_ConStringCipSis)
                            objMarca.usp_ActualizarEstatusMarca(Marca, "0")
                        End Using
                        intContadorB += 1
                    End If
                Next


                If intContadorB = 0 Then
                    MsgBox("Proceso Terminado. No se encontraron registros que actualizar.", MsgBoxStyle.OkOnly, "Aviso")
                    Exit Sub
                Else
                    MsgBox("Proceso Terminado", MsgBoxStyle.Information, "Confirmación")
                End If

            Else
                MsgBox("No seleccionó ninguna Marca.", MsgBoxStyle.OkOnly, "Aviso")
                Exit Sub
            End If

            RellenaGrid()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

   
End Class