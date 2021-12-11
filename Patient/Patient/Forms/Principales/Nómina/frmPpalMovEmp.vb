Public Class frmPpalMovEmp
    ''Tony Garcia  - 11/Sept/2012 4:00 p.m.
    Private objDataSet As Data.DataSet
    Dim Sw_NoRegistros As Boolean = False
    Dim idEmpleadoB As Integer = 0
    Dim SucursalB As String = ""
    Dim IdDeptoB As Integer = 0
    Dim IdPuestoB As Integer = 0
    Dim FechaIniB As String = ""
    Dim FechaFinB As String = ""
    Dim IdMovEmp As Integer = 0

    Dim ClaveB As String = ""
    Dim TipoB As String = ""
    Dim EstatusB As String = ""
    Dim SucursalN As String = ""

    Dim Sw_Pintar As Boolean = False
    Dim Sw_Load As Boolean = True
    Dim Opcion As Integer = 1

    Private Sub frmPpalConceptoRep_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
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
    Private Sub FechaUltimoPeriodo()
        'mreyes 23/Agosto/2012 06:43 p.m.
        Try
            Dim objDataSet1 As Data.DataSet
            Using objCantArti As New BCL.BCLMySqlGral(GLB_ConStringNomSis)
                objDataSet1 = objCantArti.usp_TraerUltimoPeriodo(2, "P", 0)

                If objDataSet1.Tables(0).Rows.Count > 0 Then

                    FechaIniB = Format(objDataSet1.Tables(0).Rows(0).Item("fechaini"), "yyyy-MM-dd")
                    FechaFinB = Format(objDataSet1.Tables(0).Rows(0).Item("fechafin"), "yyyy-MM-dd")


                End If


            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub frmPpalProveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            GLB_RefrescarPedido = False
            Opcion = 1
            Call GenerarToolTip()
            Call LimpiarBusqueda()
            Call FechaUltimoPeriodo()

            Call RellenaGrid()

            Sw_Pintar = True
            Sw_Load = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Nuevo, "Agregar un Movimiento Nuevo")
            ToolTip.SetToolTip(Btn_Editar, "Modificar un movimiento")
            ToolTip.SetToolTip(Btn_Consultar, "Consultar el Movimiento Seleccionado")
            ToolTip.SetToolTip(Btn_Actualizar, "Actualizar los Movimientos Seleccionados")
            ToolTip.SetToolTip(Btn_Filtro, "Búsqueda Avanzada")
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
            ToolTip.SetToolTip(Btn_Cancelar, "Cancelar los Movimientos Seleccionados")

            ToolTip.SetToolTip(Btn_Salir, "Salir")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    'Private Function usp_EliminarNomina(ByVal IdPeriodo As Integer, ByVal TipoNom As String, ByVal Sucursal As String, ByVal IdEmpleado As Integer) As Boolean
    '    'mreyes 22/Agosto/2012 11:27 p.m.

    '    Using objNomina As New BCL.BCLNomina(GLB_ConStringNomSis)
    '        Try
    '            'Get the specific project selected in the ListView control
    '            usp_EliminarNomina = objNomina.usp_EliminarNomina(IdPeriodo, TipoNom, Sucursal, IdEmpleado)
    '        Catch ExceptionErr As Exception
    '            MessageBox.Show(ExceptionErr.Message.ToString)
    '        End Try
    '    End Using
    'End Function

    Private Sub Colores()
        Try
            Dim periodo As Integer = 0
            Dim TipoNom As String = ""
            Dim color1 As System.Drawing.Color
            color1 = Color.SandyBrown

            For J As Integer = 0 To DGrid.RowCount - 2
                If periodo <> DGrid.Rows(J).Cells("idperiodo").Value Then
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
                    'If TipoNom <> DGrid.Rows(J).Cells("tiponom").Value Then
                    '    If color1 = Color.Salmon Then
                    '        color1 = Color.SandyBrown
                    '    Else
                    '        color1 = Color.Salmon
                    '    End If
                    'End If
                    DGrid.Rows(J).DefaultCellStyle.BackColor = color1
                    periodo = DGrid.Rows(J).Cells("idperiodo").Value
                End If


            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub RellenaGrid()
        'Tony Garcia 11/Sept/2012   10:34 a.m.
         Using objMovEmp As New BCL.BCLCatalogoMovEmp(GLB_ConStringNomSis)

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
                'Tony Garcia 11/Sept/2012
                ''''''''''''''''''
                objDataSet = objMovEmp.usp_PpalMovEmp(IdMovEmp, ClaveB, idEmpleadoB, TipoB, FechaIniB, FechaFinB, SucursalB, IdPuestoB, EstatusB)

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
                    MsgBox("No se encontro informacion del empleado que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
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
        idEmpleadoB = 0
        IdMovEmp = 0
        'TipoNomB = ""
        IdDeptoB = 0
        IdPuestoB = 0
        ' CveConcepto = ""
        SucursalB = ""
        FechaIniB = "1900-01-01"
        FechaFinB = "1900-01-01"
        TipoB = ""
        ClaveB = ""
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

            DGrid.Columns(0).HeaderText = "Id Movimiento" 'oculto
            DGrid.Columns(1).HeaderText = "Clave"  'oculto
            DGrid.Columns(2).HeaderText = "Fecha"
            DGrid.Columns(3).HeaderText = "Sucursal"
            DGrid.Columns(4).HeaderText = "IdEmpleado"
            DGrid.Columns(5).HeaderText = "Nombre Completo"
            DGrid.Columns(6).HeaderText = "Puesto"
            DGrid.Columns(7).HeaderText = "Tipo"
            DGrid.Columns(8).HeaderText = "Baja"
            DGrid.Columns(9).HeaderText = "VendNuevo"
            DGrid.Columns(10).HeaderText = "SucNueva"
            DGrid.Columns(11).HeaderText = "Estatus"
            DGrid.Columns(12).HeaderText = "Fecha Baja"


            DGrid.Columns(13).HeaderText = "IdDepto"
            DGrid.Columns(14).HeaderText = "IdDeptoNuevo"

            DGrid.Columns(15).HeaderText = "IdPuesto"
            DGrid.Columns(16).HeaderText = "IdPuestoNuevo"



            DGrid.Columns(13).Visible = False
            DGrid.Columns(14).Visible = False
            DGrid.Columns(15).Visible = False
            DGrid.Columns(16).Visible = False

            DGrid.Columns(12).Visible = False
            DGrid.Columns(0).Visible = False
            DGrid.Columns(1).Visible = False
            DGrid.Columns(8).Visible = False
            DGrid.Columns(9).Visible = False
            DGrid.Columns(10).Visible = False


            DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

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

    Private Sub Btn_Nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Opcion = 1
        Call RellenaGrid()

    End Sub

    Private Sub DGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick
        Try
            If Sw_NoRegistros = False Then Exit Sub
            Dim myForm As New frmCatalogoMovEmp

            myForm.Accion = 4
            If DGrid.CurrentRow IsNot Nothing Then
                myForm.Txt_idempleado.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idempleado").Value.ToString.Trim()
                myForm.Txt_FechaMov.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("fecha").Value.ToString.Trim()
                myForm.TipoMov = DGrid.Rows(DGrid.CurrentRow.Index).Cells("tipo").Value.ToString.Trim()
                myForm.IdMovEmp = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idmovemp").Value
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
        Dim myForm As New frmCatalogoMovEmp
        Opcion = 4

        myForm.Accion = 4
        If DGrid.CurrentRow IsNot Nothing Then
            myForm.Txt_idempleado.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idempleado").Value.ToString.Trim()
            myForm.Txt_FechaMov.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("fecha").Value.ToString.Trim()
            myForm.TipoMov = DGrid.Rows(DGrid.CurrentRow.Index).Cells("tipo").Value.ToString.Trim()
            myForm.IdMovEmp = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idmovemp").Value
        Else
            MsgBox("Seleccione un Empleado de la lista.", MsgBoxStyle.Exclamation, "ERROR")
            Exit Sub
        End If
        myForm.ShowDialog()
        
    End Sub

    Private Sub Btn_Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Sw_NoRegistros = False Then Exit Sub
        Dim myForm As New frmCatalogoMovEmp
        myForm.Accion = 2

        If DGrid.Rows(DGrid.CurrentRow.Index).Cells("Estatus").Value = "CANCELADO" Or _
              DGrid.Rows(DGrid.CurrentRow.Index).Cells("Estatus").Value = "ACTUALIZADO" Then
            MsgBox("Solo puede modificar un Movimiento con estatus de Captura", MsgBoxStyle.Critical, "Validación")
            Exit Sub
        End If

        If DGrid.CurrentRow IsNot Nothing Then
            myForm.Txt_idempleado.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idempleado").Value.ToString.Trim()
            myForm.Txt_FechaMov.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("fecha").Value.ToString.Trim()
            myForm.TipoMov = DGrid.Rows(DGrid.CurrentRow.Index).Cells("tipo").Value.ToString.Trim()
            myForm.IdMovEmp = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idmovemp").Value
        Else
            MsgBox("Seleccione un Empleado de la lista.", MsgBoxStyle.Exclamation, "ERROR")
            Exit Sub
        End If

        myForm.ShowDialog()
    End Sub

    Private Sub Btn_Filtro_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        Dim myForm As New frmFiltrosMovEmp

        myForm.Txt_IdEmpleado.Text = IIf(idEmpleadoB = 0, "", idEmpleadoB)
        myForm.Txt_IdPuesto.Text = IIf(IdPuestoB = 0, "", IdPuestoB)
        myForm.Txt_IdDepto.Text = IIf(IdDeptoB = 0, "", IdDeptoB)
        myForm.Txt_Sucursal.Text = SucursalB
        myForm.Txt_TipoMov.Text = TipoB
        If FechaIniB <> "1900-01-01" Then
            myForm.Chk_Fecha.Checked = True
            myForm.DTPicker2.Value = FechaIniB
            myForm.DTPicker3.Value = FechaFinB
        End If
        myForm.ShowDialog()
        idEmpleadoB = Val(myForm.Txt_IdEmpleado.Text)
        IdPuestoB = Val(myForm.Txt_IdPuesto.Text)
        IdDeptoB = Val(myForm.Txt_IdDepto.Text)
        SucursalB = myForm.Txt_Sucursal.Text
        If myForm.Chk_Fecha.Checked = True Then
            FechaIniB = Format(myForm.DTPicker2.Value, "yyyy-MM-dd")
            FechaFinB = Format(myForm.DTPicker3.Value, "yyyy-MM-dd")
        Else
            FechaIniB = "1900-01-01"
            FechaFinB = "1900-01-01"

        End If

        If myForm.Sw_Filtro = True Then
            Call RellenaGrid()
        End If
    End Sub

    Private Sub AgregarColumna()
        'mreyes 21/Marzo/2012 09:52 a.m.

        Dim colImagen As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        colImagen.Name = "Selec"
        colImagen.HeaderText = "Selec"
        colImagen.DisplayIndex = 13
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
            Dim myForm As New frmCatalogoMovEmp

            myForm.Accion = 4
            If DGrid.CurrentRow IsNot Nothing Then
                myForm.Txt_idempleado.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idempleado").Value.ToString.Trim()
                myForm.Txt_FechaMov.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("fecha").Value.ToString.Trim()
                myForm.TipoMov = DGrid.Rows(DGrid.CurrentRow.Index).Cells("tipo").Value.ToString.Trim()
                myForm.IdMovEmp = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idmovemp").Value
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

    Private Sub Btn_Editar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar.Click
        Try
            If Sw_NoRegistros = False Then Exit Sub
            If DGrid.Rows(DGrid.CurrentRow.Index).Cells("Estatus").Value = "CANCELADO" Or _
              DGrid.Rows(DGrid.CurrentRow.Index).Cells("Estatus").Value = "ACTUALIZADO" Then
                MsgBox("Solo puede modificar un Movimiento con estatus de Captura", MsgBoxStyle.Critical, "Validación")
                Exit Sub
            End If

            Dim myForm As New frmCatalogoMovEmp
            myForm.Accion = 2
            If DGrid.CurrentRow IsNot Nothing Then
                myForm.Txt_idempleado.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idempleado").Value.ToString.Trim()
                myForm.Txt_FechaMov.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("fecha").Value.ToString.Trim()
                myForm.TipoMov = DGrid.Rows(DGrid.CurrentRow.Index).Cells("tipo").Value.ToString.Trim()
                myForm.IdMovEmp = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idmovemp").Value
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

    Private Sub Btn_Nuevo_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Nuevo.Click
        Dim myForm As New frmCatalogoMovEmp
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

            'Tony Garcia 12/Sept/2012 05:09 p.m.

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
            If DGrid.Rows(e.RowIndex).Cells("estatus").Value = "ACTUALIZADO" Then
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.BackColor = Color.GreenYellow
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If

            If DGrid.Rows(e.RowIndex).Cells("estatus").Value = "CANCELADO" Then
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.BackColor = Color.Red
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Actualizar.Click
        'Tony Garcia - 17/Sept/2012 - 12:15 p.m.
        Dim intContador As Integer = 0
        Dim intContadorMov As Integer = 0
        Dim dtsMovimientos As Data.DataSet
        Dim dtsEmpleados As Data.DataSet

        If Sw_NoRegistros = False Then Exit Sub
        Try

            For Each row As DataGridViewRow In DGrid.Rows
                If row.Cells("Selec").Value = True Then
                    intContador += 1
                End If
            Next
            If intContador = 0 Then
                MsgBox("No se selecciono ningun Registro", MsgBoxStyle.OkOnly, "Aviso")
                Exit Sub
            End If

            If MsgBox("Esta seguro de Actualizar los Movimientos de LOS REGISTROS SELECCIONADOS?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub
            For i As Integer = 0 To DGrid.Rows.Count - 1

                If DGrid.Rows(i).Cells("Selec").Value = True And DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value = "CAPTURA" Then

                    intContadorMov += 1
                    Dim Tipo As String = CStr(DGrid.Rows(i).Cells("tipo").Value)
                    Dim IdEmpleado As String = CStr(DGrid.Rows(i).Cells("idempleado").Value)
                    Dim FechaMov As String = CDate(DGrid.Rows(i).Cells("fecha").Value)
                    Dim FechaBaja As String = CDate(DGrid.Rows(i).Cells("baja").Value)
                    Dim VendedorN As String = CStr(DGrid.Rows(i).Cells("vendnuevo").Value)
                    Dim SucursalN As String = CStr(DGrid.Rows(i).Cells("sucnueva").Value)

                    Using objActualiza As New BCL.BCLCatalogoMovEmp(GLB_ConStringNomSis)
                        dtsEmpleados = objActualiza.usp_TraerEmpleado(IdEmpleado)
                        dtsMovimientos = objActualiza.Actualiza_Emp
                        Dim objDataRow As Data.DataRow = dtsMovimientos.Tables(0).NewRow

                        objDataRow.Item("idempleado") = IdEmpleado
                        If Tipo = "SUC" Then
                            SucursalN = CStr(DGrid.Rows(DGrid.CurrentRow.Index).Cells("sucnueva").Value) & pub_TraerConsecutivoEmp(CStr(DGrid.Rows(DGrid.CurrentRow.Index).Cells("sucnueva").Value))
                            objDataRow.Item("clave") = SucursalN
                        Else
                            objDataRow.Item("clave") = dtsEmpleados.Tables(0).Rows(0).Item("clave")
                        End If

                        If Tipo = "DEP" Then

                            objDataRow.Item("iddepto") = DGrid.Rows(DGrid.CurrentRow.Index).Cells("iddeptonuevo").Value
                            objDataRow.Item("idpuesto") = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idpuestonuevo").Value

                        Else
                            objDataRow.Item("iddepto") = dtsEmpleados.Tables(0).Rows(0).Item("iddepto")
                            objDataRow.Item("idpuesto") = dtsEmpleados.Tables(0).Rows(0).Item("idpuesto")

                        End If

                       

                        'objDataRow.Item("iddepto") = dtsEmpleados.Tables(0).Rows(0).Item("iddepto")
                        'objDataRow.Item("idpuesto") = dtsEmpleados.Tables(0).Rows(0).Item("idpuesto")

                        If Tipo = "VEN" Then
                            objDataRow.Item("vendedor") = VendedorN
                        Else
                            objDataRow.Item("vendedor") = dtsEmpleados.Tables(0).Rows(0).Item("vendedor")
                        End If

                        objDataRow.Item("idfrecpago") = dtsEmpleados.Tables(0).Rows(0).Item("idfrecpago")

                        If Tipo = "BAJ" Then
                            objDataRow.Item("baja") = FechaBaja
                            objDataRow.Item("estatus") = "B"
                        Else
                            objDataRow.Item("baja") = dtsEmpleados.Tables(0).Rows(0).Item("baja")
                            objDataRow.Item("estatus") = dtsEmpleados.Tables(0).Rows(0).Item("estatus")
                        End If


                        If Tipo = "REI" Then

                            objDataRow.Item("iddepto") = DGrid.Rows(DGrid.CurrentRow.Index).Cells("iddeptonuevo").Value
                            objDataRow.Item("idpuesto") = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idpuestonuevo").Value
                            objDataRow.Item("baja") = FechaMov
                            objDataRow.Item("estatus") = "A"

                       

                        End If

                        objDataRow.Item("ingreso") = dtsEmpleados.Tables(0).Rows(0).Item("ingreso")
                        objDataRow.Item("bonofijo") = dtsEmpleados.Tables(0).Rows(0).Item("bonofijo")
                        objDataRow.Item("bono") = dtsEmpleados.Tables(0).Rows(0).Item("bono")
                        objDataRow.Item("usumodif") = GLB_Usuario
                        objDataRow.Item("fummodif") = DateTime.Now

                        dtsMovimientos.Tables(0).Rows.Add(objDataRow)

                        If Not objActualiza.usp_UpdateEmpleadoMov(Tipo, dtsMovimientos) Then
                            'Throw New Exception("Falló Inserción de Proveedor")
                        Else
                        End If
                    End Using
                End If
            Next

            If intContadorMov = 0 Then
                MsgBox("Solo puede actualizar movimientos con estatus de CAPTURA", MsgBoxStyle.OkOnly, "Aviso")
                Exit Sub
            Else
                MsgBox("Movimientos Actualizados", MsgBoxStyle.Information, "Confirmación")
            End If
            'MsgBox("Proceso Terminado", MsgBoxStyle.Information, "Confirmación")
            Call RellenaGrid()
            Me.Cursor = Cursors.Default
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        'Tony Garcia - 26/Sept/2012 - 4:30 p.m.
        Dim intContador As Integer = 0
        Dim intContadorMov As Integer = 0
        Try
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


            If MsgBox("Esta seguro de Cancelar los Movimientos de LOS REGISTROS SELECCIONADOS?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub
            For i As Integer = 0 To DGrid.Rows.Count - 1
                If DGrid.Rows(i).Cells("Selec").Value = True And DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value = "CAPTURA" Then
                    Dim Tipo As String = CStr(DGrid.Rows(i).Cells("tipo").Value)
                    Dim IdEmpleado As String = CStr(DGrid.Rows(i).Cells("idempleado").Value)
                    Dim IdMovimiento As Integer = DGrid.Rows(i).Cells("idmovemp").Value
                    Dim FechaActual As DateTime = DateTime.Now

                    Using objCancelar As New BCL.BCLCatalogoMovEmp(GLB_ConStringNomSis)
                        objCancelar.usp_CancelarMovEmp(Tipo, IdEmpleado, IdMovimiento, GLB_Usuario, FechaActual)
                    End Using
                    intContadorMov += 1
                End If
            Next
            If intContadorMov = 0 Then
                MsgBox("Solo puede cancelar movimientos con estatus de CAPTURA", MsgBoxStyle.OkOnly, "Aviso")
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


    Private Sub ConsultarMovEmpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultarMovEmpToolStripMenuItem.Click
        Call Btn_Consultar_Click(sender, e)
    End Sub

    Private Sub ModificarMovEmpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarMovEmpToolStripMenuItem.Click
        Call Btn_Editar_Click(sender, e)
    End Sub

    Private Sub ActualizarMovEmpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActualizarMovEmpToolStripMenuItem.Click
        DGrid.Rows(DGrid.CurrentRow.Index).Cells("Selec").Value = True
        Call Btn_Actualizar_Click(sender, e)
    End Sub

    Private Sub CancelarMovEmpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelarMovEmpToolStripMenuItem.Click
        DGrid.Rows(DGrid.CurrentRow.Index).Cells("Selec").Value = True
        Call Btn_Cancelar_Click(sender, e)
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

    Private Sub DGrid_ColumnHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGrid.ColumnHeaderMouseClick
        Sw_Pintar = True
    End Sub

    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub

    Private Sub Pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub
End Class
