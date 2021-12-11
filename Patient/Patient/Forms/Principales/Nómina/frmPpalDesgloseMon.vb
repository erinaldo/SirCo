Public Class frmPpalDesgloseMon
    'Tony Garcia - 18/Sept/2012 - 5:00 p.m.

    Private objDataSet As Data.DataSet

    Dim Sw_NoRegistros As Boolean = False
    Dim idEmpleadoB As Integer = 0
    Dim SucursalB As String = ""
    Dim IdDeptoB As Integer = 0
    Dim IdPuestoB As Integer = 0
    Dim FechaIniB As Date
    Dim FechaFinB As Date

    Dim IdPeriodoB As Integer = pub_TraerUltimoPeriodo(2, "A")
    Dim TipoNomB As String = "B"

    Dim Sw_Pintar As Boolean = False
    Dim Sw_Load As Boolean = True
    Dim Opcion As Integer = 3

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

        If Sw_NoRegistros = False Then Exit Sub
        If Sw_Load = True Then
            Sw_Load = False
            InicializaGrid()
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
                objDataSet1 = objCantArti.usp_TraerUltimoPeriodo(2, "A", IdPeriodoB)

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
            Opcion = 3
            'Call LimpiarBusqueda()
            'Call FechaUltimoPeriodo()
            Call RellenaGrid()
            Call GenerarToolTip()
            Sw_Pintar = True
            Sw_Load = True

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub GenerarToolTip()
        Try

            ToolTip.SetToolTip(Btn_Filtro, "Búsqueda Avanzada")
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")

            ToolTip.SetToolTip(Btn_Salir, "Salir")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub RellenaGrid()
        'mreyes 30/Junio/2012   10:34 a.m.
        Using objRegistro As New BCL.BCLDesgloseMonetario(GLB_ConStringNomSis)

            Try
                Me.Cursor = Cursors.WaitCursor
                DGrid.ReadOnly = True
                DGrid.DataSource = Nothing

                objDataSet = objRegistro.usp_PpalDesgloseMon(idEmpleadoB, IdPeriodoB, TipoNomB, SucursalB, IdDeptoB, IdPuestoB)

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
                    Sw_Pintar = True
                Else
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron nominas que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
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


        '"INSERT INTO periodotemp (idperiodo1) VALUES (4),(5),(6);"
        idEmpleadoB = 0
        'traer ultimo periodo abierto de nómina. 
        IdPeriodoB = pub_TraerUltimoPeriodo(2, "A")
        TipoNomB = ""
        IdDeptoB = 0
        IdPuestoB = 0
        SucursalB = ""
        FechaIniB = "1900-01-01"
        FechaFinB = "1900-01-01"



    End Sub

    Private Sub Btn_Refrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Sub InicializaGrid()
        'mreyes 30/Junio/2012 10:47 a.m.
        Try

            Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)

            Dim row As DataRow = dt.NewRow()

            row(9) = "Total: "
            ' ''row(7) = pub_SumarColumnaGrid(DGrid, 7, DGrid.RowCount - 1)
            ' ''row(8) = pub_SumarColumnaGrid(DGrid, 8, DGrid.RowCount - 1)
            'row(9) = pub_SumarColumnaGrid(DGrid, 9, DGrid.RowCount - 1)
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
            row(22) = pub_SumarColumnaGrid(DGrid, 22, DGrid.RowCount - 1)
            row(23) = pub_SumarColumnaGrid(DGrid, 23, DGrid.RowCount - 1)
            row(24) = pub_SumarColumnaGrid(DGrid, 24, DGrid.RowCount - 1)


            dt.Rows.Add(row)
            DGrid.DataSource = dt
    
            DGrid.RowHeadersVisible = False
            DGrid.Columns(0).HeaderText = "IdPeriodo"
            DGrid.Columns(1).HeaderText = "Fecha Inicio"
            DGrid.Columns(2).HeaderText = "Fecha Fin"
            DGrid.Columns(3).HeaderText = "Tipo Nomina"
            DGrid.Columns(4).HeaderText = "Sucursal"
            DGrid.Columns(5).HeaderText = "IdEmpleado"
            DGrid.Columns(6).HeaderText = "Nombre Completo"
            DGrid.Columns(7).HeaderText = "Departamento"
            DGrid.Columns(8).HeaderText = "IdPuesto"
            DGrid.Columns(9).HeaderText = "Puesto"
            DGrid.Columns(10).HeaderText = "Pago"
            DGrid.Columns(11).HeaderText = "$1000"
            DGrid.Columns(12).HeaderText = "$500"
            DGrid.Columns(13).HeaderText = "$200"
            DGrid.Columns(14).HeaderText = "$100"
            DGrid.Columns(15).HeaderText = "$50"
            DGrid.Columns(16).HeaderText = "$20"
            DGrid.Columns(17).HeaderText = "$10"
            DGrid.Columns(18).HeaderText = "$5"
            DGrid.Columns(19).HeaderText = "$2"
            DGrid.Columns(20).HeaderText = "$1"
            DGrid.Columns(21).HeaderText = "¢.50"
            DGrid.Columns(22).HeaderText = "¢.20"
            DGrid.Columns(23).HeaderText = "¢.10"
            DGrid.Columns(24).HeaderText = "¢.5"

            DGrid.Columns(0).Visible = False
            DGrid.Columns(5).Visible = False

            DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(20).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(21).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(22).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(23).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(24).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
  
            DGrid.Columns(10).DefaultCellStyle.Format = "c"
            DGrid.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
         
            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            'DGrid.Columns("idpuesto").Visible = False
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

    Private Sub Btn_Consultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
        myForm.Txt_TipoNom.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("tiponom").Value
        myForm.Text = myForm.Text & "-" & DGrid.Rows(DGrid.CurrentRow.Index).Cells("tiponom").Value
        myForm.Txt_RFC.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("rfc").Value
        myForm.Txt_NoIMSS.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("noimss").Value
        myForm.Txt_Ingreso.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("ingreso").Value
        myForm.Txt_SDiario.Text = Format(DGrid.Rows(DGrid.CurrentRow.Index).Cells("sdiario").Value, "c")
        myForm.IdFrecPagob = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idfrecpago").Value
        myForm.estatus = DGrid.Rows(DGrid.CurrentRow.Index).Cells("estatus").Value
        'If Mid(DGrid.Rows(DGrid.CurrentRow.Index).Cells("tiponom").Value, 1, 1) = "F" Then
        '    myForm.Txt_SDiario.Visible = False
        '    myForm.Lbl_SDiario.Visible = False
        'End If
        myForm.ShowDialog()
        If GLB_RefrescarPedido = True Then
            Call RellenaGrid()
        End If
    End Sub

    Private Sub Btn_Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Opcion = 2
        Call RellenaGrid()

    End Sub

    Private Sub Btn_Filtro_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        Dim myForm As New frmFiltrosNomina
        Dim Estatus As String = ""
        Dim strUltPer As String = ""

        Dim TipoNomina = ""

        TipoNomina = ""
        If TipoNomB = "F" Then TipoNomina = "FISCAL"
        'If TipoNomB = "A" Then TipoNomina = "AMBAS"
        If TipoNomB = "B" Then TipoNomina = "BONO"


        myForm.Txt_IdEmpleado.Text = idEmpleadoB
        'myForm.Cbo_Periodo.ValueMember = IdPeriodoB
        'myForm.Cbo_TipoNom.Text = TipoNomina

        myForm.Txt_Sucursal.Text = SucursalB
        myForm.Txt_IdDepto.Text = IdDeptoB
        myForm.Txt_IdPuesto.Text = IdPuestoB

        ' myForm.Cbo_Estatus.Text = Estatus
        myForm.ShowDialog()
        idEmpleadoB = Val(myForm.Txt_IdEmpleado.Text)
        'IdPeriodoB = "INSERT INTO periodotemp (idperiodo1) VALUES (" & pub_TraerUltimoPeriodo(2, "A") & ");"
        strUltPer = myForm.Periodo
        If strUltPer.Length > 4 Then
            MsgBox("Debe seleccionar solamente un periodo.", MsgBoxStyle.Exclamation, "Aviso")
            Exit Sub
        ElseIf strUltPer.Length = 0 Then
        Else
            IdPeriodoB = CInt(strUltPer) * -1
        End If

        TipoNomB = Mid(myForm.Cbo_TipoNom.Text, 1, 1)

        ' FechaIniB = myForm.FechaIniB


        SucursalB = myForm.Txt_Sucursal.Text
        IdDeptoB = Val(myForm.Txt_IdDepto.Text)
        IdPuestoB = Val(myForm.Txt_IdPuesto.Text)

        If myForm.Sw_Filtro = True Then
            Call RellenaGrid()
        End If
    End Sub

    Private Sub Btn_Empleado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Opcion = 3
        Call RellenaGrid()
    End Sub

    Private Sub DGrid_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGrid.CellFormatting
        Try

            Dim Sw_NoEntro As Boolean = False

            Dim DiasEntrega As Integer = 0
            If Sw_Pintar = False Then Exit Sub

            If Me.DGrid.Columns(e.ColumnIndex).Name <> "descrippuesto" Then Exit Sub
            ''If Me.DGrid.Columns(e.ColumnIndex).Name <> "fecha" Then Exit Sub
            If e.RowIndex >= DGrid.RowCount - 2 Then
                If Sw_Load = False Then
                    Sw_Pintar = False
                End If
                DGrid.Columns("idpuesto").Visible = False
                Exit Sub

            End If

            If DGrid.Rows(e.RowIndex).Cells("mil").Value > 0 Then
                DGrid.Rows(e.RowIndex).Cells("mil").Style.BackColor = Color.LightGray
                DGrid.Rows(e.RowIndex).Cells("mil").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If

            If DGrid.Rows(e.RowIndex).Cells("quinientos").Value > 0 Then
                DGrid.Rows(e.RowIndex).Cells("quinientos").Style.BackColor = Color.LightGray
                DGrid.Rows(e.RowIndex).Cells("quinientos").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If

            If DGrid.Rows(e.RowIndex).Cells("doscientos").Value > 0 Then
                DGrid.Rows(e.RowIndex).Cells("doscientos").Style.BackColor = Color.LightGray
                DGrid.Rows(e.RowIndex).Cells("doscientos").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If

            If DGrid.Rows(e.RowIndex).Cells("cien").Value > 0 Then
                DGrid.Rows(e.RowIndex).Cells("cien").Style.BackColor = Color.LightGray
                DGrid.Rows(e.RowIndex).Cells("cien").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If

            If DGrid.Rows(e.RowIndex).Cells("cincuenta").Value > 0 Then
                DGrid.Rows(e.RowIndex).Cells("cincuenta").Style.BackColor = Color.LightGray
                DGrid.Rows(e.RowIndex).Cells("cincuenta").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If

            If DGrid.Rows(e.RowIndex).Cells("veinte").Value > 0 Then
                DGrid.Rows(e.RowIndex).Cells("veinte").Style.BackColor = Color.LightGray
                DGrid.Rows(e.RowIndex).Cells("veinte").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If

            If DGrid.Rows(e.RowIndex).Cells("diez").Value > 0 Then
                DGrid.Rows(e.RowIndex).Cells("diez").Style.BackColor = Color.LightGray
                DGrid.Rows(e.RowIndex).Cells("diez").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If

            If DGrid.Rows(e.RowIndex).Cells("cinco").Value > 0 Then
                DGrid.Rows(e.RowIndex).Cells("cinco").Style.BackColor = Color.LightGray
                DGrid.Rows(e.RowIndex).Cells("cinco").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If

            If DGrid.Rows(e.RowIndex).Cells("dos").Value > 0 Then
                DGrid.Rows(e.RowIndex).Cells("dos").Style.BackColor = Color.LightGray
                DGrid.Rows(e.RowIndex).Cells("dos").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If

            If DGrid.Rows(e.RowIndex).Cells("uno").Value > 0 Then
                DGrid.Rows(e.RowIndex).Cells("uno").Style.BackColor = Color.LightGray
                DGrid.Rows(e.RowIndex).Cells("uno").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If

            If DGrid.Rows(e.RowIndex).Cells("cincuentac").Value > 0 Then
                DGrid.Rows(e.RowIndex).Cells("cincuentac").Style.BackColor = Color.LightGray
                DGrid.Rows(e.RowIndex).Cells("cincuentac").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If

            If DGrid.Rows(e.RowIndex).Cells("veintec").Value > 0 Then
                DGrid.Rows(e.RowIndex).Cells("veintec").Style.BackColor = Color.LightGray
                DGrid.Rows(e.RowIndex).Cells("veintec").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If

            If DGrid.Rows(e.RowIndex).Cells("diezc").Value > 0 Then
                DGrid.Rows(e.RowIndex).Cells("diezc").Style.BackColor = Color.LightGray
                DGrid.Rows(e.RowIndex).Cells("diezc").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If

            If DGrid.Rows(e.RowIndex).Cells("cincoc").Value > 0 Then
                DGrid.Rows(e.RowIndex).Cells("cincoc").Style.BackColor = Color.LightGray
                DGrid.Rows(e.RowIndex).Cells("cincoc").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
End Class