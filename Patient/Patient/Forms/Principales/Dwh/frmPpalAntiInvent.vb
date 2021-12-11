Public Class frmPpalAntiInvent
    'mreyes 18/Octubre/2012 01:54 p.m.
    Dim MarcaFOTO As String = ""
    Dim EstiloNFOTO As String = ""
    Private objDataSet As Data.DataSet
    Dim Sw_NoRegistros As Boolean = False
    Dim idEmpleadoB As Integer = 0
    Dim SucursalB As String = ""
    'Dim IdDeptoB As Integer = 0
    Dim IdPuestoB As Integer = 0
    Dim FechaIniB As Date
    Dim FechaFinB As Date
    Dim idPercDeducB As Integer = 0
    Dim IdPeriodoB As String = ""
    Dim TipoNomB As String = ""
    Dim Sw_Pintar As Boolean = False
    Dim Sw_Load As Boolean = True
    Public Opcion As Integer = 1
    Dim PeriodoUnico As Integer = 0
    Dim DiasIni As Integer = 0
    Dim DiasFin As Integer = 0

    Dim Marcab As String
    Dim Modelob As String
    Dim Estilofb As String
    Dim IdDivisionb As Integer
    Dim IdDepartamentob As Integer
    Dim IdFamiliab As Integer
    Dim IdLineab As Integer
    Dim IdL1b As Integer
    Dim IdL2b As Integer
    Dim IdL3b As Integer
    Dim IdL4b As Integer
    Dim IdL5b As Integer
    Dim IdL6b As Integer
    Dim Proveedorb As String

    Dim FecHora As Date

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
        Try
            If (e.KeyCode = Keys.Escape) Then
                Me.Close()
            End If

            If e.KeyCode = Keys.F5 Then
                Call Btn_Filtro_Click_1(sender, e)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub FechaUltimoPeriodo(ByVal Estatus As String)
        'mreyes 23/Agosto/2012 06:43 p.m.
        Try
            Dim objDataSet1 As Data.DataSet
            Using objCantArti As New BCL.BCLMySqlGral(GLB_ConStringNomSis)
                objDataSet1 = objCantArti.usp_TraerUltimoPeriodo(2, Estatus, PeriodoUnico)

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
            Call LimpiarBusqueda()

            Call GenerarToolTip()
            Sw_Pintar = True
            Sw_Load = True
            Lbl_FUM.Text = ""
            Call RellenaGrid()
            NuevoProveedorToolStripMenuItem.Visible = False
            ModificarProveedorToolStripMenuItem.Visible = True
            ConsultarProveedorToolStripMenuItem.Visible = True
            EstiloToolStripMenuItem.Visible = True
            'Call RellenaGrid2()
            
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub usp_TraerVentasNetas()
        Dim Vendedor As String = ""
        Dim Z As Integer = 0
        'mreyes 19/Septiembre/2012 09:58 a.m.
        Try
            Using objMySqlGral As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)
                Try

                    objDataSet = objMySqlGral.usp_TraerVendedor(0)
                    If objDataSet.Tables(0).Rows.Count = 1 Then
                        Vendedor = objDataSet.Tables(0).Rows(0).Item("vendedor").ToString
                    Else
                        Vendedor = ""
                    End If


                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using

            ' Borrar Ventas 
            Using objElimina As New BCL.BCLNomina(GLB_ConStringNomSis)
                Try
                    'Get the specific project selected in the ListView control
                    If objElimina.usp_EliminaVenta(GLB_CveSucursal, 0, GLB_FechaHoy, GLB_FechaHoy) = False Then

                    End If
                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using


            Using objMicrosipE As New BCL.BCLNomina(GLB_ConStringCipSis)
                Dim objDatasetE As Data.DataSet


                objDatasetE = objMicrosipE.usp_TraerVentasNetas(GLB_CveSucursal, Vendedor, GLB_FechaHoy, GLB_FechaHoy)
                If objDatasetE.Tables(0).Rows.Count > 0 Then
                    Application.DoEvents()

                    Dim Cont As Integer = objDatasetE.Tables(0).Rows.Count - 1
                    For Z = 0 To objDatasetE.Tables(0).Rows.Count - 1
                        ' Insertar en Empleados

                        Application.DoEvents()
                        Call Inserta_VentaNomina(objDatasetE, Z)

                    Next
                End If
            End Using


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
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
            ToolTip.SetToolTip(Btn_Marca, "Antigüedad por Marca")
            ToolTip.SetToolTip(Btn_Estilos, "Antigüedad por Estilo")
            ToolTip.SetToolTip(Btn_Sucursal, "Antigüedad por Sucursal")
            'ToolTip.SetToolTip(Btn_FamiliaLinea, "Antigüedad por Familia/Linea")
            ToolTip.SetToolTip(Btn_Guardar, "Guardar")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub RellenaGrid()
        'mreyes 30/Junio/2012   10:34 a.m.
        Dim objDataSetFum As Data.DataSet
        Using objRegistro As New BCL.BCLAntiInvent(GLB_ConStringDWH)

            Try
                Lbl_Filtros.Text = ""
                Me.Cursor = Cursors.WaitCursor
                DGrid.ReadOnly = True
                DGrid.DataSource = Nothing

                If Opcion = 1 Or Opcion = 5 Then
                    'If Chk_Excluir.Checked = True Then
                    '    If chk_Desglosado.Checked = True Then
                    '        If Chk_Calzado.Checked Then
                    '            'objDataSet = objRegistro.usp_PpalInventarioTiendasSinOzo(SucursalB, "C")
                    '        Else
                    '            'objDataSet = objRegistro.usp_PpalInventarioTiendasSinOzo(SucursalB, TipoArtb)
                    '        End If
                    '    Else
                    '        Opcion = 5
                    '        If Chk_Calzado.Checked Then
                    '            'objDataSet = objRegistro.usp_PpalInventarioTiendasSinOzoResumen(SucursalB, "C")
                    '        Else
                    '            'objDataSet = objRegistro.usp_PpalInventarioTiendasSinOzoResumen(SucursalB, TipoArtb)
                    '        End If
                    '    End If
                    If chk_Desglosado.Checked = True Then
                        If Chk_Calzado.Checked Then
                            objDataSet = objRegistro.usp_PpalInventarioTiendas(SucursalB, 1, IdDepartamentob, _
                                                                                         IdFamiliab, IdLineab, IdL1b, IdL2b, IdL3b, IdL4b, IdL5b, IdL6b)
                        Else
                            objDataSet = objRegistro.usp_PpalInventarioTiendas(SucursalB, IdDivisionb, IdDepartamentob, _
                                                                                         IdFamiliab, IdLineab, IdL1b, IdL2b, IdL3b, IdL4b, IdL5b, IdL6b)
                        End If
                    Else
                        Opcion = 5
                        If Chk_Calzado.Checked Then
                            objDataSet = objRegistro.usp_PpalInventarioTiendasDesglosado(SucursalB, Marcab, Modelob, Estilofb, 1, IdDepartamentob, _
                                                                                         IdFamiliab, IdLineab, IdL1b, IdL2b, IdL3b, IdL4b, IdL5b, IdL6b, Proveedorb)
                        Else
                            objDataSet = objRegistro.usp_PpalInventarioTiendasDesglosado(SucursalB, Marcab, Modelob, Estilofb, IdDivisionb, IdDepartamentob, _
                                                                                         IdFamiliab, IdLineab, IdL1b, IdL2b, IdL3b, IdL4b, IdL5b, IdL6b, Proveedorb)
                        End If
                    End If
                    Btn_Foto.Enabled = False
                    'Btn_Regresar.Enabled = False
                    'DGrid.Visible = True
                    'DGrid.Dock = DockStyle.None
                    'DGrid.Dock = DockStyle.None

                ElseIf Opcion = 2 Then
                    'If Chk_Excluir.Checked = True Then
                    'If Chk_Calzado.Checked Then
                    'objDataSet = objRegistro.usp_PpalDetAntiInventSinOzo(SucursalB, Marcab, "C", DiasIni, DiasFin)
                    'Else
                    'objDataSet = objRegistro.usp_PpalDetAntiInventSinOzo(SucursalB, Marcab, TipoArtb, DiasIni, DiasFin)
                    'End If
                    'Else
                    If Chk_Calzado.Checked Then
                        objDataSet = objRegistro.usp_PpalDetAntiInvent(SucursalB, Marcab, 1, IdDepartamentob, _
                                                                    IdFamiliab, IdLineab, IdL1b, IdL2b, IdL3b, IdL4b, IdL5b, IdL6b, DiasIni, DiasFin)
                    Else
                        objDataSet = objRegistro.usp_PpalDetAntiInvent(SucursalB, Marcab, IdDivisionb, IdDepartamentob, _
                                                                    IdFamiliab, IdLineab, IdL1b, IdL2b, IdL3b, IdL4b, IdL5b, IdL6b, DiasIni, DiasFin)
                    End If
                    'End If

                    Btn_Foto.Enabled = True
                    Btn_Regresar.Enabled = True
                    'DGrid.Dock = DockStyle.Fill
                    'DGrid.Visible = False
                ElseIf Opcion = 3 Then
                    'If Chk_Excluir.Checked = True Then
                    If Chk_Calzado.Checked Then
                        objDataSet = objRegistro.usp_PpalInventarioMarcas(SucursalB, 1, IdDepartamentob, _
                                                                    IdFamiliab, IdLineab, IdL1b, IdL2b, IdL3b, IdL4b, IdL5b, IdL6b, Marcab)
                    Else
                        objDataSet = objRegistro.usp_PpalInventarioMarcas(SucursalB, IdDivisionb, IdDepartamentob, _
                                                                    IdFamiliab, IdLineab, IdL1b, IdL2b, IdL3b, IdL4b, IdL5b, IdL6b, Marcab)
                    End If
                    'Else
                    ' If Chk_Calzado.Checked Then
                    'objDataSet = objRegistro.usp_PpalInventarioMarcas(SucursalB, "C", Marcab)
                    '  Else
                    'objDataSet = objRegistro.usp_PpalInventarioMarcas(SucursalB, TipoArtb, Marcab)
                    '   End If
                    'End If

                    Btn_Foto.Enabled = False
                    'Btn_Regresar.Enabled = False

                ElseIf Opcion = 6 Then
                    'If Chk_Excluir.Checked = True Then
                    If Chk_Calzado.Checked Then
                        'objDataSet = objRegistro.usp_PpalInventarioFamLineaSinOzonoResumen(SucursalB, "C")
                    Else
                        'objDataSet = objRegistro.usp_PpalInventarioFamLineaSinOzonoResumen(SucursalB, TipoArtb)
                    End If
                    'Else
                    '    If Chk_Calzado.Checked Then
                    '        'objDataSet = objRegistro.usp_PpalInventarioFamLineaResumen(SucursalB, "C")
                    '    Else
                    '        'objDataSet = objRegistro.usp_PpalInventarioFamLineaResumen(SucursalB, TipoArtb)
                    '    End If
                    'End If
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

                    Using objFUM As New BCL.BCLAntiInvent(GLB_ConStringDWH)
                        objDataSetFum = objFUM.usp_TraerFecUltMod(1)
                    End Using
                    If objDataSetFum.Tables(0).Rows.Count > 0 Then
                        FecHora = CDate(objDataSetFum.Tables(0).Rows(0).Item("fum"))
                        Lbl_FUM.Text = "Ultima Modificación: " & FecHora.ToString("dd-MMM-yyyy hh:mm:ss tt").ToUpper
                    End If

                    If Opcion = 1 Then
                        Using objGrid2 As New BCL.BCLAntiInvent(GLB_ConStringDWH)
                            'objDataSetFum = objGrid2.usp_PpalInventarioPorcDias(SucursalB, TipoArtb)
                        End Using
                        If objDataSetFum.Tables(0).Rows.Count > 0 Then
                            DGrid2.DataSource = objDataSetFum.Tables(0)
                            InicializaGrid3()
                        End If
                    End If

                    Sw_NoRegistros = True
                    Sw_Pintar = True
                    Sw_Pintar = True
                Else
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontro Información que cumpla con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False

                End If
                Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using


    End Sub

    Private Sub RellenaGrid2()
        'mreyes 30/Junio/2012   10:34 a.m.
        'Using objRegistro As New BCL.BCLAntiInvent(GLB_ConStringDWH)

        '    Try
        '        Me.Cursor = Cursors.WaitCursor
        '        DGrid2.ReadOnly = True
        '        DGrid2.DataSource = Nothing

        '        If Opcion = 1 Then
        '            If Chk_Excluir.Checked = True Then
        '                'objDataSet = objRegistro.usp_PpalInventarioResumenTiendasSinOzo(SucursalB, TipoArtb)
        '            Else
        '                'objDataSet = objRegistro.usp_PpalInventarioResumenTiendas(SucursalB, TipoArtb)
        '            End If

        '            Btn_Foto.Enabled = False
        '            ' Btn_Regresar.Enabled = False


        '        End If
        '        'Populate the Project Details section
        '        If objDataSet.Tables(0).Rows.Count > 0 Then
        '            'Populate the Project Details section

        '            DGrid2.DataSource = objDataSet.Tables(0)

        '            InicializaGrid2()


        '        End If
        '        Me.Cursor = Cursors.Default
        '        ' LimpiarBusqueda()

        '    Catch ExceptionErr As Exception
        '        MessageBox.Show(ExceptionErr.Message.ToString)
        '    End Try
        'End Using


    End Sub
    Private Sub LimpiarBusqueda()


        '"INSERT INTO periodotemp (idperiodo1) VALUES (4),(5),(6);"
        Marcab = ""
        Modelob = ""
        Estilofb = ""
        IdDivisionb = 0
        IdDepartamentob = 0
        IdFamiliab = 0
        IdLineab = 0
        IdL1b = 0
        IdL2b = 0
        IdL3b = 0
        IdL4b = 0
        IdL5b = 0
        IdL6b = 0
        Proveedorb = ""
        SucursalB = ""



    End Sub

    Private Sub Btn_Refrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call RellenaGrid()
            'If Opcion = 1 Then
            '    Call RellenaGrid2()
            'End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Sub InicializaGrid()
        'mreyes 30/Junio/2012 10:47 a.m.
        Try

            DGrid.Columns(0).Frozen = True
            DGrid.Columns(1).Frozen = True
            DGrid.Columns(0).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Columns(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            DGrid.Columns(1).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Columns(1).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

            DGrid.RowHeadersVisible = False
            If Opcion = 2 Then
                Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)

                Dim row As DataRow = dt.NewRow()

                row(1) = "Total: "

                row(6) = pub_SumarColumnaGrid(DGrid, 6, DGrid.RowCount - 1)
                row(9) = pub_SumarColumnaGrid(DGrid, 9, DGrid.RowCount - 1)
                row(10) = pub_SumarColumnaGrid(DGrid, 10, DGrid.RowCount - 1)
                dt.Rows.InsertAt(row, 0)
                DGrid.DataSource = dt

                DGrid.Columns(0).HeaderText = "Ren"
                DGrid.Columns(1).HeaderText = "Cve"
                DGrid.Columns(2).HeaderText = "Sucursal"
                DGrid.Columns(3).HeaderText = "Marca"
                DGrid.Columns(4).HeaderText = "Modelo"
                DGrid.Columns(5).HeaderText = "Descripción"
                DGrid.Columns(6).HeaderText = "Ctd"
                DGrid.Columns(7).HeaderText = "Fecha Ult Recibo"
                DGrid.Columns(8).HeaderText = "Días"
                DGrid.Columns(9).HeaderText = "Costo"
                DGrid.Columns(10).HeaderText = "Venta"
                DGrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(9).DefaultCellStyle.Format = "c"
                DGrid.Columns(10).DefaultCellStyle.Format = "c"
            End If
            If Opcion = 1 Or Opcion = 3 Then

                Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)

                Dim row As DataRow = dt.NewRow()

                row(1) = "Total: "

                row(2) = pub_SumarColumnaGrid(DGrid, 2, DGrid.RowCount - 1)
                row(4) = pub_SumarColumnaGrid(DGrid, 4, DGrid.RowCount - 1)
                row(6) = pub_SumarColumnaGrid(DGrid, 6, DGrid.RowCount - 1)
                row(8) = pub_SumarColumnaGrid(DGrid, 8, DGrid.RowCount - 1)
                row(10) = pub_SumarColumnaGrid(DGrid, 10, DGrid.RowCount - 1)
                row(12) = pub_SumarColumnaGrid(DGrid, 12, DGrid.RowCount - 1)
                row(14) = pub_SumarColumnaGrid(DGrid, 14, DGrid.RowCount - 1)
                row(16) = pub_SumarColumnaGrid(DGrid, 16, DGrid.RowCount - 1)
                row(18) = pub_SumarColumnaGrid(DGrid, 18, DGrid.RowCount - 1)
                row(20) = pub_SumarColumnaGrid(DGrid, 20, DGrid.RowCount - 1)
                row(22) = pub_SumarColumnaGrid(DGrid, 22, DGrid.RowCount - 1)
                row(24) = pub_SumarColumnaGrid(DGrid, 24, DGrid.RowCount - 1)
                row(26) = pub_SumarColumnaGrid(DGrid, 26, DGrid.RowCount - 1)
                row(28) = pub_SumarColumnaGrid(DGrid, 28, DGrid.RowCount - 1)
                row(30) = pub_SumarColumnaGrid(DGrid, 30, DGrid.RowCount - 1)
                row(32) = pub_SumarColumnaGrid(DGrid, 32, DGrid.RowCount - 1)
                row(34) = pub_SumarColumnaGrid(DGrid, 34, DGrid.RowCount - 1)
                row(36) = pub_SumarColumnaGrid(DGrid, 36, DGrid.RowCount - 1)
                row(38) = pub_SumarColumnaGrid(DGrid, 38, DGrid.RowCount - 1)
                row(40) = pub_SumarColumnaGrid(DGrid, 40, DGrid.RowCount - 1)
                row(42) = pub_SumarColumnaGrid(DGrid, 42, DGrid.RowCount - 1)
                row(44) = pub_SumarColumnaGrid(DGrid, 44, DGrid.RowCount - 1)

                dt.Rows.InsertAt(row, 0)
                DGrid.DataSource = dt
                If Opcion = 1 Then
                    DGrid.Columns(0).HeaderText = "Cve"
                    DGrid.Columns(1).HeaderText = "Sucursal"
                Else
                    DGrid.Columns(0).HeaderText = "Cve"
                    DGrid.Columns(1).HeaderText = "Marca"
                    DGrid.Columns(0).Frozen = False
                    DGrid.Columns(1).Frozen = False
                End If
                DGrid.Columns(2).HeaderText = "15"
                DGrid.Columns(3).HeaderText = "%"
                DGrid.Columns(4).HeaderText = "30"
                DGrid.Columns(5).HeaderText = "%"
                DGrid.Columns(6).HeaderText = "45"
                DGrid.Columns(7).HeaderText = "%"
                DGrid.Columns(8).HeaderText = "60"
                DGrid.Columns(9).HeaderText = "%"
                DGrid.Columns(10).HeaderText = "90"
                DGrid.Columns(11).HeaderText = "%"
                DGrid.Columns(12).HeaderText = "120"
                DGrid.Columns(13).HeaderText = "%"
                DGrid.Columns(14).HeaderText = "140"
                DGrid.Columns(15).HeaderText = "%"
                DGrid.Columns(16).HeaderText = "160"
                DGrid.Columns(17).HeaderText = "%"
                DGrid.Columns(18).HeaderText = "200"
                DGrid.Columns(19).HeaderText = "%"
                DGrid.Columns(20).HeaderText = "250"
                DGrid.Columns(21).HeaderText = "%"
                DGrid.Columns(22).HeaderText = "300"
                DGrid.Columns(23).HeaderText = "%"
                DGrid.Columns(24).HeaderText = "350"
                DGrid.Columns(25).HeaderText = "%"
                DGrid.Columns(26).HeaderText = "450"
                DGrid.Columns(27).HeaderText = "%"
                DGrid.Columns(28).HeaderText = "550"
                DGrid.Columns(29).HeaderText = "%"
                DGrid.Columns(30).HeaderText = "650"
                DGrid.Columns(31).HeaderText = "%"
                DGrid.Columns(32).HeaderText = "750"
                DGrid.Columns(33).HeaderText = "%"
                DGrid.Columns(34).HeaderText = "850"
                DGrid.Columns(35).HeaderText = "%"
                DGrid.Columns(36).HeaderText = "1000"
                DGrid.Columns(37).HeaderText = "%"
                DGrid.Columns(38).HeaderText = "1500"
                DGrid.Columns(39).HeaderText = "%"
                DGrid.Columns(40).HeaderText = "2000"
                DGrid.Columns(41).HeaderText = "%"
                DGrid.Columns(42).HeaderText = "+2001"
                DGrid.Columns(43).HeaderText = "%"
                DGrid.Columns(44).HeaderText = "Total"
                DGrid.Columns(45).HeaderText = "%"
                DGrid.Columns(44).DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Columns(44).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                DGrid.Columns(45).DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Columns(45).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                If Opcion = 3 Then
                    DGrid.Columns(46).DisplayIndex = 0
                    DGrid.Columns(46).Frozen = True
                    DGrid.Columns(46).DefaultCellStyle.BackColor = Color.PowderBlue
                    DGrid.Columns(46).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                End If

                DGrid.Columns(44).DisplayIndex = 3
                DGrid.Columns(45).DisplayIndex = 4

                DGrid.Columns(44).Frozen = True
                DGrid.Columns(45).Frozen = True

                For i As Integer = 0 To DGrid.ColumnCount - 1
                    DGrid.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Next

                DGrid.Columns(3).DefaultCellStyle.Format = "#,##0"
                DGrid.Columns(5).DefaultCellStyle.Format = "#,##0"
                DGrid.Columns(7).DefaultCellStyle.Format = "#,##0"
                DGrid.Columns(9).DefaultCellStyle.Format = "#,##0"
                DGrid.Columns(11).DefaultCellStyle.Format = "#,##0"
                DGrid.Columns(13).DefaultCellStyle.Format = "#,##0"
                DGrid.Columns(15).DefaultCellStyle.Format = "#,##0"
                DGrid.Columns(17).DefaultCellStyle.Format = "#,##0"
                DGrid.Columns(19).DefaultCellStyle.Format = "#,##0"
                DGrid.Columns(21).DefaultCellStyle.Format = "#,##0"
                DGrid.Columns(23).DefaultCellStyle.Format = "#,##0"
                DGrid.Columns(25).DefaultCellStyle.Format = "#,##0"
                DGrid.Columns(27).DefaultCellStyle.Format = "#,##0"
                DGrid.Columns(29).DefaultCellStyle.Format = "#,##0"
                DGrid.Columns(31).DefaultCellStyle.Format = "#,##0"
                DGrid.Columns(33).DefaultCellStyle.Format = "#,##0"
                DGrid.Columns(35).DefaultCellStyle.Format = "#,##0"
                DGrid.Columns(37).DefaultCellStyle.Format = "#,##0"
                DGrid.Columns(39).DefaultCellStyle.Format = "#,##0"
                DGrid.Columns(41).DefaultCellStyle.Format = "#,##0"
                DGrid.Columns(43).DefaultCellStyle.Format = "#,##0"
                DGrid.Columns(45).DefaultCellStyle.Format = "#,##0"


                DGrid.Columns(2).DefaultCellStyle.Format = "#,##0"
                DGrid.Columns(4).DefaultCellStyle.Format = "#,##0"
                DGrid.Columns(6).DefaultCellStyle.Format = "#,##0"
                DGrid.Columns(8).DefaultCellStyle.Format = "#,##0"
                DGrid.Columns(10).DefaultCellStyle.Format = "#,##0"
                DGrid.Columns(12).DefaultCellStyle.Format = "#,##0"
                DGrid.Columns(14).DefaultCellStyle.Format = "#,##0"
                DGrid.Columns(16).DefaultCellStyle.Format = "#,##0"
                DGrid.Columns(18).DefaultCellStyle.Format = "#,##0"
                DGrid.Columns(20).DefaultCellStyle.Format = "#,##0"
                DGrid.Columns(22).DefaultCellStyle.Format = "#,##0"
                DGrid.Columns(24).DefaultCellStyle.Format = "#,##0"
                DGrid.Columns(26).DefaultCellStyle.Format = "#,##0"
                DGrid.Columns(28).DefaultCellStyle.Format = "#,##0"
                DGrid.Columns(30).DefaultCellStyle.Format = "#,##0"
                DGrid.Columns(32).DefaultCellStyle.Format = "#,##0"
                DGrid.Columns(34).DefaultCellStyle.Format = "#,##0"
                DGrid.Columns(36).DefaultCellStyle.Format = "#,##0"
                DGrid.Columns(38).DefaultCellStyle.Format = "#,##0"
                DGrid.Columns(40).DefaultCellStyle.Format = "#,##0"
                DGrid.Columns(42).DefaultCellStyle.Format = "#,##0"
                DGrid.Columns(44).DefaultCellStyle.Format = "#,##0"
              


            End If

            If Opcion = 5 Then
                If chk_Desglosado.Checked = True Then
                    Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)

                    Dim row As DataRow = dt.NewRow()

                    row(1) = "Total: "

                    row(2) = pub_SumarColumnaGrid(DGrid, 2, DGrid.RowCount - 1)
                    row(4) = pub_SumarColumnaGrid(DGrid, 4, DGrid.RowCount - 1)
                    row(6) = pub_SumarColumnaGrid(DGrid, 6, DGrid.RowCount - 1)
                    row(8) = pub_SumarColumnaGrid(DGrid, 8, DGrid.RowCount - 1)
                    row(10) = pub_SumarColumnaGrid(DGrid, 10, DGrid.RowCount - 1)
                    row(12) = pub_SumarColumnaGrid(DGrid, 12, DGrid.RowCount - 1)
                    row(14) = pub_SumarColumnaGrid(DGrid, 14, DGrid.RowCount - 1)
                    row(16) = pub_SumarColumnaGrid(DGrid, 16, DGrid.RowCount - 1)
                    row(18) = pub_SumarColumnaGrid(DGrid, 18, DGrid.RowCount - 1)
                    row(20) = pub_SumarColumnaGrid(DGrid, 20, DGrid.RowCount - 1)
                    row(22) = pub_SumarColumnaGrid(DGrid, 22, DGrid.RowCount - 1)
                    row(24) = pub_SumarColumnaGrid(DGrid, 24, DGrid.RowCount - 1)
                    row(26) = pub_SumarColumnaGrid(DGrid, 26, DGrid.RowCount - 1)
                    row(28) = pub_SumarColumnaGrid(DGrid, 28, DGrid.RowCount - 1)
                    row(30) = pub_SumarColumnaGrid(DGrid, 30, DGrid.RowCount - 1)
                    row(32) = pub_SumarColumnaGrid(DGrid, 32, DGrid.RowCount - 1)
                    row(34) = pub_SumarColumnaGrid(DGrid, 34, DGrid.RowCount - 1)
                    row(36) = pub_SumarColumnaGrid(DGrid, 36, DGrid.RowCount - 1)
                    row(38) = pub_SumarColumnaGrid(DGrid, 38, DGrid.RowCount - 1)
                    row(40) = pub_SumarColumnaGrid(DGrid, 40, DGrid.RowCount - 1)
                    row(42) = pub_SumarColumnaGrid(DGrid, 42, DGrid.RowCount - 1)
                    row(44) = pub_SumarColumnaGrid(DGrid, 44, DGrid.RowCount - 1)

                    dt.Rows.InsertAt(row, 0)
                    DGrid.DataSource = dt
                    DGrid.Columns(0).HeaderText = "Cve"
                    DGrid.Columns(1).HeaderText = "Sucursal"
                    DGrid.Columns(2).HeaderText = "15"
                    DGrid.Columns(3).HeaderText = "%"
                    DGrid.Columns(4).HeaderText = "30"
                    DGrid.Columns(5).HeaderText = "%"
                    DGrid.Columns(6).HeaderText = "45"
                    DGrid.Columns(7).HeaderText = "%"
                    DGrid.Columns(8).HeaderText = "60"
                    DGrid.Columns(9).HeaderText = "%"
                    DGrid.Columns(10).HeaderText = "90"
                    DGrid.Columns(11).HeaderText = "%"
                    DGrid.Columns(12).HeaderText = "120"
                    DGrid.Columns(13).HeaderText = "%"
                    DGrid.Columns(14).HeaderText = "140"
                    DGrid.Columns(15).HeaderText = "%"
                    DGrid.Columns(16).HeaderText = "160"
                    DGrid.Columns(17).HeaderText = "%"
                    DGrid.Columns(18).HeaderText = "200"
                    DGrid.Columns(19).HeaderText = "%"
                    DGrid.Columns(20).HeaderText = "250"
                    DGrid.Columns(21).HeaderText = "%"
                    DGrid.Columns(22).HeaderText = "300"
                    DGrid.Columns(23).HeaderText = "%"
                    DGrid.Columns(24).HeaderText = "350"
                    DGrid.Columns(25).HeaderText = "%"
                    DGrid.Columns(26).HeaderText = "450"
                    DGrid.Columns(27).HeaderText = "%"
                    DGrid.Columns(28).HeaderText = "550"
                    DGrid.Columns(29).HeaderText = "%"
                    DGrid.Columns(30).HeaderText = "650"
                    DGrid.Columns(31).HeaderText = "%"
                    DGrid.Columns(32).HeaderText = "750"
                    DGrid.Columns(33).HeaderText = "%"
                    DGrid.Columns(34).HeaderText = "850"
                    DGrid.Columns(35).HeaderText = "%"
                    DGrid.Columns(36).HeaderText = "1000"
                    DGrid.Columns(37).HeaderText = "%"
                    DGrid.Columns(38).HeaderText = "1500"
                    DGrid.Columns(39).HeaderText = "%"
                    DGrid.Columns(40).HeaderText = "2000"
                    DGrid.Columns(41).HeaderText = "%"
                    DGrid.Columns(42).HeaderText = "2000+"
                    DGrid.Columns(43).HeaderText = "%"
                    DGrid.Columns(44).HeaderText = "Total"
                    DGrid.Columns(45).HeaderText = "%"

                    DGrid.Columns(44).DefaultCellStyle.BackColor = Color.PowderBlue
                    DGrid.Columns(44).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                    DGrid.Columns(45).DefaultCellStyle.BackColor = Color.PowderBlue
                    DGrid.Columns(45).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                    DGrid.Columns(44).DisplayIndex = 2
                    DGrid.Columns(45).DisplayIndex = 3


                    DGrid.Columns(44).Frozen = True
                    DGrid.Columns(45).Frozen = True

                    For i As Integer = 0 To DGrid.ColumnCount - 1
                        DGrid.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Next

                    DGrid.Columns(3).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(5).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(7).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(9).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(11).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(13).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(15).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(17).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(19).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(21).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(23).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(25).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(27).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(29).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(31).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(33).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(35).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(37).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(39).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(41).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(43).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(45).DefaultCellStyle.Format = "#,##0"


                    DGrid.Columns(2).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(4).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(6).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(8).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(10).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(12).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(14).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(16).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(18).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(20).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(22).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(24).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(26).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(28).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(30).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(32).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(34).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(36).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(38).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(40).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(42).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(44).DefaultCellStyle.Format = "#,##0"
                Else
                    Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)

                    Dim row As DataRow = dt.NewRow()

                    row(1) = "Total: "

                    row(2) = pub_SumarColumnaGrid(DGrid, 2, DGrid.RowCount - 1)
                    row(4) = pub_SumarColumnaGrid(DGrid, 4, DGrid.RowCount - 1)
                    row(6) = pub_SumarColumnaGrid(DGrid, 6, DGrid.RowCount - 1)
                    row(8) = pub_SumarColumnaGrid(DGrid, 8, DGrid.RowCount - 1)
                    row(10) = pub_SumarColumnaGrid(DGrid, 10, DGrid.RowCount - 1)
                    row(12) = pub_SumarColumnaGrid(DGrid, 12, DGrid.RowCount - 1)
                    row(14) = pub_SumarColumnaGrid(DGrid, 14, DGrid.RowCount - 1)
                    row(16) = pub_SumarColumnaGrid(DGrid, 16, DGrid.RowCount - 1)
                    row(18) = pub_SumarColumnaGrid(DGrid, 18, DGrid.RowCount - 1)
                    row(20) = pub_SumarColumnaGrid(DGrid, 20, DGrid.RowCount - 1)
                    row(22) = pub_SumarColumnaGrid(DGrid, 22, DGrid.RowCount - 1)
                    row(24) = pub_SumarColumnaGrid(DGrid, 24, DGrid.RowCount - 1)

                    dt.Rows.InsertAt(row, 0)
                    DGrid.DataSource = dt
                    DGrid.Columns(0).HeaderText = "Cve"
                    DGrid.Columns(1).HeaderText = "Sucursal"
                    DGrid.Columns(2).HeaderText = "15"
                    DGrid.Columns(3).HeaderText = "%"
                    DGrid.Columns(4).HeaderText = "30"
                    DGrid.Columns(5).HeaderText = "%"
                    DGrid.Columns(6).HeaderText = "45"
                    DGrid.Columns(7).HeaderText = "%"
                    DGrid.Columns(8).HeaderText = "60"
                    DGrid.Columns(9).HeaderText = "%"
                    DGrid.Columns(10).HeaderText = "90"
                    DGrid.Columns(11).HeaderText = "%"
                    DGrid.Columns(12).HeaderText = "120"
                    DGrid.Columns(13).HeaderText = "%"
                    DGrid.Columns(14).HeaderText = "140"
                    DGrid.Columns(15).HeaderText = "%"
                    DGrid.Columns(16).HeaderText = "160"
                    DGrid.Columns(17).HeaderText = "%"
                    DGrid.Columns(18).HeaderText = "350"
                    DGrid.Columns(19).HeaderText = "%"
                    DGrid.Columns(20).HeaderText = "750"
                    DGrid.Columns(21).HeaderText = "%"
                    DGrid.Columns(22).HeaderText = "750+"
                    DGrid.Columns(23).HeaderText = "%"
                    DGrid.Columns(24).HeaderText = "Total"
                    DGrid.Columns(25).HeaderText = "%"
                    DGrid.Columns(24).DefaultCellStyle.BackColor = Color.PowderBlue
                    DGrid.Columns(24).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                    DGrid.Columns(25).DefaultCellStyle.BackColor = Color.PowderBlue
                    DGrid.Columns(25).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                    DGrid.Columns(24).DisplayIndex = 2
                    DGrid.Columns(25).DisplayIndex = 3


                    DGrid.Columns(24).Frozen = True
                    DGrid.Columns(25).Frozen = True

                    For i As Integer = 0 To DGrid.ColumnCount - 1
                        DGrid.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Next

                    DGrid.Columns(3).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(5).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(7).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(9).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(11).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(13).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(15).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(17).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(19).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(21).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(23).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(25).DefaultCellStyle.Format = "#,##0"



                    DGrid.Columns(2).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(4).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(6).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(8).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(10).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(12).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(14).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(16).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(18).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(20).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(22).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(24).DefaultCellStyle.Format = "#,##0"

                End If

            End If


                If Opcion = 6 Then

                    DGrid.Columns(0).Frozen = False
                    DGrid.Columns(1).Frozen = False

                    DGrid.Columns(2).DefaultCellStyle.BackColor = Color.PowderBlue
                    DGrid.Columns(2).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                    DGrid.Columns(3).DefaultCellStyle.BackColor = Color.PowderBlue
                    DGrid.Columns(3).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                    DGrid.Columns(26).DefaultCellStyle.BackColor = Color.PowderBlue
                    DGrid.Columns(26).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                    DGrid.Columns(27).DefaultCellStyle.BackColor = Color.PowderBlue
                    DGrid.Columns(27).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)


                    Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)

                    Dim row As DataRow = dt.NewRow()

                    row(1) = "Total: "


                    row(4) = pub_SumarColumnaGrid(DGrid, 4, DGrid.RowCount - 1)
                    row(6) = pub_SumarColumnaGrid(DGrid, 6, DGrid.RowCount - 1)
                    row(8) = pub_SumarColumnaGrid(DGrid, 8, DGrid.RowCount - 1)
                    row(10) = pub_SumarColumnaGrid(DGrid, 10, DGrid.RowCount - 1)
                    row(12) = pub_SumarColumnaGrid(DGrid, 12, DGrid.RowCount - 1)
                    row(14) = pub_SumarColumnaGrid(DGrid, 14, DGrid.RowCount - 1)
                    row(16) = pub_SumarColumnaGrid(DGrid, 16, DGrid.RowCount - 1)
                    row(18) = pub_SumarColumnaGrid(DGrid, 18, DGrid.RowCount - 1)
                    row(20) = pub_SumarColumnaGrid(DGrid, 20, DGrid.RowCount - 1)
                    row(22) = pub_SumarColumnaGrid(DGrid, 22, DGrid.RowCount - 1)
                    row(24) = pub_SumarColumnaGrid(DGrid, 24, DGrid.RowCount - 1)
                    row(26) = pub_SumarColumnaGrid(DGrid, 26, DGrid.RowCount - 1)

                    dt.Rows.InsertAt(row, 0)
                    DGrid.DataSource = dt
                    DGrid.Columns(0).HeaderText = "Familia"
                    DGrid.Columns(1).HeaderText = "Descripción"
                    DGrid.Columns(2).HeaderText = "Linea"
                    DGrid.Columns(3).HeaderText = "Descripción"
                    DGrid.Columns(4).HeaderText = "15"
                    DGrid.Columns(5).HeaderText = "%"
                    DGrid.Columns(6).HeaderText = "30"
                    DGrid.Columns(7).HeaderText = "%"
                    DGrid.Columns(8).HeaderText = "45"
                    DGrid.Columns(9).HeaderText = "%"
                    DGrid.Columns(10).HeaderText = "60"
                    DGrid.Columns(11).HeaderText = "%"
                    DGrid.Columns(12).HeaderText = "90"
                    DGrid.Columns(13).HeaderText = "%"
                    DGrid.Columns(14).HeaderText = "120"
                    DGrid.Columns(15).HeaderText = "%"
                    DGrid.Columns(16).HeaderText = "140"
                    DGrid.Columns(17).HeaderText = "%"
                    DGrid.Columns(18).HeaderText = "160"
                    DGrid.Columns(19).HeaderText = "%"
                    DGrid.Columns(20).HeaderText = "350"
                    DGrid.Columns(21).HeaderText = "%"
                    DGrid.Columns(22).HeaderText = "750"
                    DGrid.Columns(23).HeaderText = "%"
                    DGrid.Columns(24).HeaderText = "750+"
                    DGrid.Columns(25).HeaderText = "%"
                    DGrid.Columns(26).HeaderText = "Total"
                    DGrid.Columns(27).HeaderText = "%"

                    DGrid.Columns(26).DisplayIndex = 4
                    DGrid.Columns(27).DisplayIndex = 5
                    DGrid.Columns(28).DisplayIndex = 0
                    DGrid.Columns(28).Frozen = True
                    DGrid.Columns(0).Frozen = True
                    DGrid.Columns(1).Frozen = True
                    DGrid.Columns(2).Frozen = True
                    DGrid.Columns(3).Frozen = True
                    DGrid.Columns(26).Frozen = True
                    DGrid.Columns(27).Frozen = True
                    DGrid.Columns(28).DefaultCellStyle.BackColor = Color.PowderBlue
                    DGrid.Columns(28).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                    For i As Integer = 0 To DGrid.ColumnCount - 1
                        DGrid.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Next


                    DGrid.Columns(5).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(7).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(9).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(11).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(13).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(15).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(17).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(19).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(21).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(23).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(25).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(27).DefaultCellStyle.Format = "#,##0"




                    DGrid.Columns(4).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(6).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(8).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(10).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(12).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(14).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(16).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(18).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(20).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(22).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(24).DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns(26).DefaultCellStyle.Format = "#,##0"
                End If

                DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                DGrid.Rows(0).Frozen = True

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Sub InicializaGrid2()
        'mreyes 19/Octubre/2012 09:34 a.m.
        Try
            DGrid2.RowHeadersVisible = False
            If Opcion = 2 Then
                DGrid2.Columns(0).HeaderText = "Cve"
                DGrid2.Columns(1).HeaderText = "Sucursal"
                DGrid2.Columns(2).HeaderText = "Marca"
                DGrid2.Columns(3).HeaderText = "EstiloN"
                DGrid2.Columns(4).HeaderText = "Descripción"
                DGrid2.Columns(5).HeaderText = "Cat"
                DGrid2.Columns(6).HeaderText = "Ctd"
                DGrid2.Columns(7).HeaderText = "Fecha Ult Recibo"
                DGrid2.Columns(8).HeaderText = "Días"
            End If
            If Opcion = 1 Then

                Dim dt As DataTable = TryCast(DGrid2.DataSource, DataTable)

                Dim row As DataRow = dt.NewRow()

                row(1) = "Total: "

                row(2) = pub_SumarColumnaGrid(DGrid2, 2, DGrid2.RowCount - 1)
                row(4) = pub_SumarColumnaGrid(DGrid2, 4, DGrid2.RowCount - 1)
                row(6) = pub_SumarColumnaGrid(DGrid2, 6, DGrid2.RowCount - 1)
                row(8) = pub_SumarColumnaGrid(DGrid2, 8, DGrid2.RowCount - 1)
                row(10) = pub_SumarColumnaGrid(DGrid2, 10, DGrid2.RowCount - 1)
                row(12) = pub_SumarColumnaGrid(DGrid2, 12, DGrid2.RowCount - 1)
                row(14) = pub_SumarColumnaGrid(DGrid2, 14, DGrid2.RowCount - 1)
                row(16) = pub_SumarColumnaGrid(DGrid2, 16, DGrid2.RowCount - 1)
                row(18) = pub_SumarColumnaGrid(DGrid2, 18, DGrid2.RowCount - 1)
                row(20) = pub_SumarColumnaGrid(DGrid2, 20, DGrid2.RowCount - 1)
                row(22) = pub_SumarColumnaGrid(DGrid2, 22, DGrid2.RowCount - 1)
                row(24) = pub_SumarColumnaGrid(DGrid2, 24, DGrid2.RowCount - 1)
                row(26) = pub_SumarColumnaGrid(DGrid2, 26, DGrid2.RowCount - 1)
                row(28) = pub_SumarColumnaGrid(DGrid2, 28, DGrid2.RowCount - 1)
                row(30) = pub_SumarColumnaGrid(DGrid2, 30, DGrid2.RowCount - 1)
                row(32) = pub_SumarColumnaGrid(DGrid2, 32, DGrid2.RowCount - 1)
                row(34) = pub_SumarColumnaGrid(DGrid2, 34, DGrid2.RowCount - 1)
                row(36) = pub_SumarColumnaGrid(DGrid2, 36, DGrid2.RowCount - 1)
                row(38) = pub_SumarColumnaGrid(DGrid2, 38, DGrid2.RowCount - 1)
                row(40) = pub_SumarColumnaGrid(DGrid2, 40, DGrid2.RowCount - 1)
                row(42) = pub_SumarColumnaGrid(DGrid2, 42, DGrid2.RowCount - 1)
                row(44) = pub_SumarColumnaGrid(DGrid2, 44, DGrid2.RowCount - 1)

                dt.Rows.Add(row)
                DGrid2.DataSource = dt

                DGrid2.Columns(0).HeaderText = "Cve"
                DGrid2.Columns(1).HeaderText = "Sucursal"
                DGrid2.Columns(2).Visible = False
                DGrid2.Columns(3).Visible = False
                DGrid2.Columns(4).Visible = False
                DGrid2.Columns(5).Visible = False
                DGrid2.Columns(6).HeaderText = "45"
                DGrid2.Columns(7).HeaderText = "%"
                DGrid2.Columns(8).Visible = False
                DGrid2.Columns(9).Visible = False
                DGrid2.Columns(10).Visible = False
                DGrid2.Columns(11).Visible = False
                DGrid2.Columns(12).HeaderText = "120"
                DGrid2.Columns(13).HeaderText = "%"
                DGrid2.Columns(14).Visible = False
                DGrid2.Columns(15).Visible = False
                DGrid2.Columns(16).Visible = False
                DGrid2.Columns(17).Visible = False
                DGrid2.Columns(18).HeaderText = "200"
                DGrid2.Columns(19).HeaderText = "%"
                DGrid2.Columns(20).Visible = False
                DGrid2.Columns(21).Visible = False
                DGrid2.Columns(22).Visible = False
                DGrid2.Columns(23).Visible = False
                DGrid2.Columns(24).HeaderText = "350"
                DGrid2.Columns(25).HeaderText = "%"
                DGrid2.Columns(26).HeaderText = "450"
                DGrid2.Columns(27).HeaderText = "%"
                DGrid2.Columns(28).Visible = False
                DGrid2.Columns(29).Visible = False
                DGrid2.Columns(30).Visible = False
                DGrid2.Columns(31).Visible = False
                DGrid2.Columns(32).Visible = False
                DGrid2.Columns(33).Visible = False
                DGrid2.Columns(34).Visible = False
                DGrid2.Columns(35).Visible = False
                DGrid2.Columns(36).HeaderText = "1000"
                DGrid2.Columns(37).HeaderText = "%"
                DGrid2.Columns(38).Visible = False
                DGrid2.Columns(39).Visible = False
                DGrid2.Columns(40).Visible = False
                DGrid2.Columns(41).Visible = False
                DGrid2.Columns(42).HeaderText = "+2001"
                DGrid2.Columns(43).HeaderText = "%"
                DGrid2.Columns(44).HeaderText = "Total"
                DGrid2.Columns(45).HeaderText = "%"
                For i As Integer = 0 To DGrid2.ColumnCount - 1
                    DGrid2.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Next

                DGrid2.Columns(3).DefaultCellStyle.Format = "#,##0"
                DGrid2.Columns(5).DefaultCellStyle.Format = "#,##0"
                DGrid2.Columns(7).DefaultCellStyle.Format = "#,##0"
                DGrid2.Columns(9).DefaultCellStyle.Format = "#,##0"
                DGrid2.Columns(11).DefaultCellStyle.Format = "#,##0"
                DGrid2.Columns(13).DefaultCellStyle.Format = "#,##0"
                DGrid2.Columns(15).DefaultCellStyle.Format = "#,##0"
                DGrid2.Columns(17).DefaultCellStyle.Format = "#,##0"
                DGrid2.Columns(19).DefaultCellStyle.Format = "#,##0"
                DGrid2.Columns(21).DefaultCellStyle.Format = "#,##0"
                DGrid2.Columns(23).DefaultCellStyle.Format = "#,##0"
                DGrid2.Columns(25).DefaultCellStyle.Format = "#,##0"
                DGrid2.Columns(27).DefaultCellStyle.Format = "#,##0"
                DGrid2.Columns(29).DefaultCellStyle.Format = "#,##0"
                DGrid2.Columns(31).DefaultCellStyle.Format = "#,##0"
                DGrid2.Columns(33).DefaultCellStyle.Format = "#,##0"
                DGrid2.Columns(35).DefaultCellStyle.Format = "#,##0"
                DGrid2.Columns(37).DefaultCellStyle.Format = "#,##0"
                DGrid2.Columns(39).DefaultCellStyle.Format = "#,##0"
                DGrid2.Columns(41).DefaultCellStyle.Format = "#,##0"
                DGrid2.Columns(43).DefaultCellStyle.Format = "#,##0"
                DGrid2.Columns(45).DefaultCellStyle.Format = "#,##0"
                DGrid2.Rows(DGrid2.RowCount - 2).DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid2.Rows(DGrid2.RowCount - 2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid2.Rows(DGrid2.RowCount - 2).DefaultCellStyle.Font = New Font(DGrid2.DefaultCellStyle.Font.FontFamily, DGrid2.DefaultCellStyle.Font.Size, FontStyle.Bold)



            End If

            DGrid2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Sub InicializaGrid3()
        'miguel pérez 20/Octubre/2012 11:18 a.m.
        Try


            '  Dim dt As DataTable = TryCast(DGrid2.DataSource, DataTable)

            'Dim row As DataRow = dt.NewRow()
            ''row(0) = "Total: "
            'row(1) = pub_SumarColumnaGrid(DGrid2, 1, DGrid2.RowCount - 1)
            'dt.Rows.Add(row)
            'DGrid2.DataSource = dt

            DGrid2.RowHeadersVisible = False

            DGrid2.Columns(0).HeaderText = "Días"
            DGrid2.Columns(1).HeaderText = "Unidades"
            DGrid2.Columns(2).HeaderText = "%"

            'DGrid2.Columns(2).DefaultCellStyle.Format = "p"
            DGrid2.Columns(2).DefaultCellStyle.Format = "#,##0"
            'Dim dt As DataTable = TryCast(DGrid2.DataSource, DataTable)

            'Dim row As DataRow = dt.NewRow()

            ''row(0) = "Total: "

            'row(1) = pub_SumarColumnaGrid(DGrid2, 1, DGrid.RowCount - 2)
            'dt.Rows.Add(row)
            'DGrid2.DataSource = dt

            DGrid2.Columns(0).DefaultCellStyle.BackColor = Color.PowderBlue

            For i As Integer = 0 To DGrid2.ColumnCount - 1
                DGrid2.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next

            
            'DGrid2.Rows(DGrid2.RowCount - 2).DefaultCellStyle.BackColor = Color.PowderBlue
            'DGrid2.Rows(DGrid2.RowCount - 2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'DGrid2.Rows(DGrid2.RowCount - 2).DefaultCellStyle.Font = New Font(DGrid2.DefaultCellStyle.Font.FontFamily, DGrid2.DefaultCellStyle.Font.Size, FontStyle.Bold)




            DGrid2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells


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
            If TabControl1.SelectedIndex = 0 Then
                If ExportarDGridAExcel(DGrid) = False Then
                    MsgBox("Error al exportar a Excel. Intente nuevamente.", MsgBoxStyle.Critical, "Excel")
                End If
            End If
            If TabControl1.SelectedIndex = 1 Then
                If ExportarDGridAExcel(DGrid2) = False Then
                    MsgBox("Error al exportar a Excel. Intente nuevamente.", MsgBoxStyle.Critical, "Excel")
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Opcion = 1
        Call RellenaGrid()

    End Sub

    Private Sub DGrid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

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
        'Dim NomSucursal As String = ""
        'Dim NomMarca As String = ""
        'Dim Estilon As String = ""
        'Dim NomFamilia As String = ""
        'Dim NomLinea As String = ""
        'Dim NomProveedor As String = ""
        'Dim NomTipoArt As String = ""
        'Dim NomCategoria As String = ""

        Dim myForm As New frmFiltrosInventario
        myForm.Txt_Marca.Text = Marcab
        myForm.Txt_Estilon.Text = Modelob
        myForm.Txt_Estilof.Text = Estilofb
        myForm.Txt_IdDivision.Text = IdDivisionb
        myForm.Txt_IdDepto.Text = IdDepartamentob
        myForm.Txt_IdFamilia.Text = IdFamiliab
        myForm.Txt_IdLinea.Text = IdLineab
        myForm.Txt_IdL1.Text = IdL1b
        myForm.Txt_IdL2.Text = IdL2b
        myForm.Txt_IdL3.Text = IdL3b
        myForm.Txt_IdL4.Text = IdL4b
        myForm.Txt_IdL5.Text = IdL5b
        myForm.Txt_IdL6.Text = IdL6b
        myForm.Txt_Proveedor.Text = Proveedorb

        myForm.ShowDialog()

        SucursalB = myForm.Txt_Sucursal.Text
        Marcab = myForm.Txt_Marca.Text
        Modelob = myForm.Txt_Estilon.Text
        Estilofb = myForm.Txt_Estilof.Text
        If myForm.Txt_IdDivision.Text <> "" Then
            IdDivisionb = CInt(myForm.Txt_IdDivision.Text)
        End If
        If myForm.Txt_IdDepto.Text <> "" Then
            IdDepartamentob = CInt(myForm.Txt_IdDepto.Text)
        End If
        If myForm.Txt_IdFamilia.Text <> "" Then
            IdFamiliab = CInt(myForm.Txt_IdFamilia.Text)
        End If
        If myForm.Txt_IdLinea.Text <> "" Then
            IdLineab = CInt(myForm.Txt_IdLinea.Text)
        End If
        If myForm.Txt_IdL1.Text <> "" Then
            IdL1b = CInt(myForm.Txt_IdL1.Text)
        End If
        If myForm.Txt_IdL2.Text <> "" Then
            IdL2b = CInt(myForm.Txt_IdL2.Text)
        End If
        If myForm.Txt_IdL3.Text <> "" Then
            IdL3b = CInt(myForm.Txt_IdL3.Text)
        End If
        If myForm.Txt_IdL4.Text <> "" Then
            IdL4b = CInt(myForm.Txt_IdL4.Text)
        End If
        If myForm.Txt_IdL5.Text <> "" Then
            IdL5b = CInt(myForm.Txt_IdL5.Text)
        End If
        If myForm.Txt_IdL6.Text <> "" Then
            IdL6b = CInt(myForm.Txt_IdL6.Text)
        End If
        Proveedorb = myForm.Txt_Proveedor.Text

        'If myForm.Txt_DescripSucursal.Text.Trim = "" Then
        '    NomSucursal = ""
        'Else
        '    NomSucursal = myForm.Txt_DescripSucursal.Text.Trim + " "
        'End If

        'If myForm.Txt_DescripMarca.Text.Trim = "" Then
        '    NomMarca = ""
        'Else
        '    NomMarca = myForm.Txt_DescripMarca.Text.Trim + " "
        'End If

        'If myForm.Txt_Estilon.Text.Trim = "" Then
        '    Estilon = ""
        'Else
        '    Estilon = myForm.Txt_Estilon.Text.Trim + " "
        'End If

        'If myForm.Txt_DescripFamilia.Text.Trim = "" Then
        '    NomFamilia = ""
        'Else
        '    NomFamilia = myForm.Txt_DescripFamilia.Text.Trim + " "
        'End If

        'If myForm.Txt_DescripLinea.Text.Trim = "" Then
        '    NomLinea = ""
        'Else
        '    NomLinea = myForm.Txt_DescripLinea.Text.Trim + " "
        'End If

        'If myForm.Txt_Raz_Soc.Text.Trim = "" Then
        '    NomProveedor = ""
        'Else
        '    NomProveedor = myForm.Txt_Raz_Soc.Text.Trim + " "
        'End If

        'If myForm.Txt_DescripTipoArt.Text.Trim = "" Then
        '    NomTipoArt = ""
        'Else
        '    NomTipoArt = myForm.Txt_DescripTipoArt.Text.Trim + " "
        'End If

        'If myForm.Txt_DescripCategoria.Text.Trim = "" Then
        '    NomCategoria = ""
        'Else
        '    NomCategoria = myForm.Txt_DescripCategoria.Text.Trim + " "
        'End If

        If myForm.Sw_Filtro = True Then
            Call RellenaGrid()
            'Lbl_Filtros.Text = "Información: " + NomSucursal + NomMarca + Estilon + NomFamilia + NomLinea + NomProveedor + NomTipoArt + NomCategoria
            'If Opcion = 1 Then
            ' Call RellenaGrid2()
            'End If
        End If


    End Sub

    Dim strLabel As String = ""
    Private Sub NuevoProveedorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoProveedorToolStripMenuItem.Click
        Try
            If Opcion = 3 Then
                Marcab = DGrid.CurrentRow.Cells("sucursal").Value
                strLabel += " " + Marcab.Trim
                Label2.Text = strLabel
            ElseIf Opcion = 2 Then
                SucursalB = DGrid.CurrentRow.Cells("Sucursal").Value
                Marcab = DGrid.CurrentRow.Cells("Marca").Value
                strLabel += " " + SucursalB.Trim + " " + Marcab.Trim
                Label2.Text = strLabel
            ElseIf Opcion = 6 Then
                SucursalB = ""
            End If
            Call Btn_Sucursal_Click(sender, e)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ModificarProveedorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarProveedorToolStripMenuItem.Click
        Try
            If Opcion = 1 Or Opcion = 5 Then
                SucursalB = DGrid.CurrentRow.Cells("Sucursal").Value
                strLabel = ""
                strLabel = SucursalB.Trim
                Label2.Text = strLabel
            ElseIf Opcion = 2 Then
                SucursalB = DGrid.CurrentRow.Cells("Sucursal").Value
                Marcab = DGrid.CurrentRow.Cells("Marca").Value
                strLabel += " " + SucursalB.Trim + " " + Marcab.Trim
                Label2.Text = strLabel
            End If
            Call Btn_Marca_Click(sender, e)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ConsultarProveedorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultarProveedorToolStripMenuItem.Click
        Try
            If Opcion = 1 Or Opcion = 5 Then
                SucursalB = DGrid.CurrentRow.Cells("Sucursal").Value
                strLabel = ""
                strLabel = SucursalB.Trim
                Label2.Text = strLabel
            ElseIf Opcion = 3 Then
                Marcab = DGrid.CurrentRow.Cells("sucursal").Value
                strLabel += " " + Marcab.Trim
                Label2.Text = strLabel
            ElseIf Opcion = 2 Then
                SucursalB = DGrid.CurrentRow.Cells("Sucursal").Value
                Marcab = DGrid.CurrentRow.Cells("Marca").Value
                strLabel += " " + SucursalB.Trim + " " + Marcab.Trim
                Label2.Text = strLabel
            End If
            Call Bot_FamiliaLinea_Click(sender, e)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub EstiloToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstiloToolStripMenuItem.Click
        Try
            If Opcion = 1 Or Opcion = 5 Then
                SucursalB = DGrid.CurrentRow.Cells("Sucursal").Value
                strLabel = ""
                strLabel = SucursalB.Trim
                Label2.Text = strLabel
            ElseIf Opcion = 3 Then
                Marcab = DGrid.CurrentRow.Cells("sucursal").Value
                strLabel += " " + Marcab
                Label2.Text = strLabel
            End If
            Call Btn_Estilos_Click(sender, e)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub

    Private Sub Btn_Layout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'mreyes 07/Julio/2012 10:26 a.m.
        Const Archivo As String = "c:Prueba.txt"
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
        Dim Encabezado As String = "1000003307941" & Format(Now.Date, "yyMMdd") & "0055" & "Calzado de Torreon SA de CV         Nomina del " & "28 junio 15D01"
        Dim sw As New System.IO.StreamWriter(Archivo)
        Linea = Encabezado
        sw.WriteLine(Linea)

        For i = 0 To DGrid.RowCount - 2
            ' CAST(Taller.cod_taller AS CHAR CHARACTER SET utf8 

            Cuenta = DGrid.Rows(i).Cells("cuenta").Value & ""
            Nombre = Trim(DGrid.Rows(i).Cells("nomlayout").Value & "")
            FecLayout = DGrid.Rows(i).Cells("feclayout").Value & ""
            pagosdec = DGrid.Rows(i).Cells("pagosdec").Value & ""
            SumPago = DGrid.Rows(i).Cells("pago").Value + SumPago
            Linea = Columna1 & pagosdec & TTarjeta & Cuenta & pub_RellenarEspaciosDerecha(i + 1, 16) & pub_RellenarEspaciosDerecha(Nombre, 195) & FecLayout
            '000000000000043683
            sw.WriteLine(Linea)

        Next
        SumPagoDec = pub_RellenarIzquierda(Replace(Math.Round(SumPago, 2), ".", ""), 18)

        Linea = CuentaNos & pub_RellenarIzquierda(i, 6) & SumPagoDec & "000001" & SumPagoDec
        sw.WriteLine(Linea)
        sw.Close()
        MsgBox("Archivo creado ")

    End Sub

    Private Function GenerarDSReciboNomina() As DSReciboNomina
        'mreyes 10/Junio/2012 06:23 p.m.
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
                    'Generar Encabezado... 
                    Dim objDataRow1 As Data.DataRow = GenerarDSReciboNomina.Tables("Tbl_Recibo").NewRow
                    objDataRow1.Item("idEmpleado") = DGrid.Rows(I).Cells("idempleado").Value
                    objDataRow1.Item("NombreCompleto") = DGrid.Rows(I).Cells("nomcompleto").Value
                    objDataRow1.Item("rfc") = DGrid.Rows(I).Cells("rfc").Value
                    objDataRow1.Item("depto") = DGrid.Rows(I).Cells("descripdepto").Value
                    objDataRow1.Item("puesto") = DGrid.Rows(I).Cells("descrippuesto").Value
                    objDataRow1.Item("sueldo") = DGrid.Rows(I).Cells("sdiario").Value
                    objDataRow1.Item("tperc") = "0.0"
                    objDataRow1.Item("tdeduc") = "0.0"
                    objDataRow1.Item("total") = DGrid.Rows(I).Cells("pago").Value
                    objDataRow1.Item("ingreso") = DGrid.Rows(I).Cells("ingreso").Value
                    objDataRow1.Item("noimss") = DGrid.Rows(I).Cells("noimss").Value

                    GenerarDSReciboNomina.Tables("Tbl_Recibo").Rows.Add(objDataRow1)
                    'Termina Genera Encabezado.
                    'ir por el detallado de cada empleado, para conocer las percepc
                    'checar aqui 23 de agosto

                    Using objPedidos As New BCL.BCLNomina(GLB_ConStringNomSis)
                        Dim objDataSet As Data.DataSet
                        Try
                            objDataSet = objPedidos.usp_ReciboNominaDet(DGrid.Rows(I).Cells("idperiodo").Value, DGrid.Rows(I).Cells("tiponom").Value, DGrid.Rows(I).Cells("idempleado").Value)

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

                                    objDataRow.Item("DescripcionPerc") = objDataSet.Tables(0).Rows(j).Item("descripperc").ToString
                                    objDataRow.Item("Gravable") = objDataSet.Tables(0).Rows(j).Item("gravable").ToString
                                    objDataRow.Item("Exento") = objDataSet.Tables(0).Rows(j).Item("exento").ToString
                                    objDataRow.Item("UniDeduc") = objDataSet.Tables(0).Rows(j).Item("unideduc").ToString
                                    objDataRow.Item("DescripcionDeduc") = objDataSet.Tables(0).Rows(j).Item("descripdeduc").ToString
                                    objDataRow.Item("Retencion") = objDataSet.Tables(0).Rows(j).Item("retencion").ToString
                                    objDataRow.Item("Saldo") = objDataSet.Tables(0).Rows(j).Item("saldo").ToString
                                    GenerarDSReciboNomina.Tables("Tbl_ReciboDet").Rows.Add(objDataRow)
                                Next
                            End If




                            '''' LLENAR DETALLADO DE ORDE COMP
                        Catch ExceptionErr As Exception
                            MessageBox.Show(ExceptionErr.Message.ToString)
                        End Try
                    End Using


                    Pbar1.Value = Pbar1.Value + 1
                    LBL_PORC.Text = I & " de " & .RowCount - 2
                    Application.DoEvents()
                Next
            End With
            Pnl_Bar.Visible = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function
    Private Sub ImprimirReciboNomina()
        'mreyes 10/Julio/2012 06:22 p.m.
        Try
            Dim myForm As New frmReportsBrowser
            Dim Sw_Mas14 As Boolean = False
            Dim Cont As Integer = 0
            Dim Opcion As Integer = 4


            myForm.objDataSetReciboNomina = GenerarDSReciboNomina()

            '            myForm.TextoColumna(0) = TextoColumna(0)


            ' termina calcular por orden de compra 

            myForm.ReportIndex = Opcion
            myForm.Show()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If MsgBox("Esta seguro de querer generar los recibos de nómina.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmación") = MsgBoxResult.No Then Exit Sub
        Me.Cursor = Cursors.AppStarting
        Call ImprimirReciboNomina()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Btn_Empleado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Opcion = 3
        Call RellenaGrid()
    End Sub

   

    Private Sub DGrid_DoubleClick_1(ByVal sender As Object, ByVal e As System.EventArgs)

        Try
            Dim columna As Integer = DGrid.CurrentCell.ColumnIndex
            Dim renglon As Integer = DGrid.CurrentCell.RowIndex

            If Opcion = 3 Then '' marca 
                Opcion = 2
                Call RellenaGrid()
                Exit Sub
            End If

            If Opcion = 1 Then  'detallado
                Opcion = 2 'EMPLEADO EN DESGLOSE

                If DGrid.Rows(DGrid.CurrentRow.Index).Cells("descrip").Value <> "Total: " Then
                    SucursalB = DGrid.Rows(DGrid.CurrentRow.Index).Cells("sucursal").Value
                End If
                If columna >= 2 And columna <= 3 Then '15
                    DiasIni = 0
                    DiasFin = 15
                End If

                If columna >= 4 And columna <= 5 Then '30
                    DiasIni = 16
                    DiasFin = 30
                End If

                If columna >= 6 And columna <= 7 Then '45
                    DiasIni = 31
                    DiasFin = 45
                End If

                If columna >= 8 And columna <= 9 Then '60
                    DiasIni = 46
                    DiasFin = 60
                End If

                If columna >= 10 And columna <= 11 Then '90
                    DiasIni = 61
                    DiasFin = 90
                End If


                If columna >= 12 And columna <= 13 Then '120
                    DiasIni = 91
                    DiasFin = 120
                End If

                If columna >= 14 And columna <= 15 Then '120
                    DiasIni = 121
                    DiasFin = 140
                End If


                If columna >= 16 And columna <= 17 Then '120
                    DiasIni = 141
                    DiasFin = 160
                End If

                If columna >= 18 And columna <= 19 Then '120
                    DiasIni = 161
                    DiasFin = 200
                End If

                If columna >= 20 And columna <= 21 Then '120
                    DiasIni = 201
                    DiasFin = 250
                End If

                If columna >= 22 And columna <= 23 Then '120
                    DiasIni = 251
                    DiasFin = 300
                End If

                If columna >= 24 And columna <= 25 Then '120
                    DiasIni = 301
                    DiasFin = 350
                End If

                If columna >= 26 And columna <= 27 Then '120
                    DiasIni = 351
                    DiasFin = 450
                End If

                If columna >= 28 And columna <= 29 Then '120
                    DiasIni = 451
                    DiasFin = 550
                End If

                If columna >= 30 And columna <= 31 Then '120
                    DiasIni = 551
                    DiasFin = 650
                End If

                If columna >= 32 And columna <= 33 Then '120
                    DiasIni = 651
                    DiasFin = 750
                End If

                If columna >= 34 And columna <= 35 Then '120
                    DiasIni = 751
                    DiasFin = 850
                End If

                If columna >= 36 And columna <= 37 Then '120
                    DiasIni = 851
                    DiasFin = 1000
                End If

                If columna >= 38 And columna <= 39 Then '120
                    DiasIni = 1001
                    DiasFin = 1500
                End If

                If columna >= 40 And columna <= 41 Then '120
                    DiasIni = 1501
                    DiasFin = 2000
                End If
                If columna >= 42 And columna <= 43 Then '120
                    DiasIni = 2001
                    DiasFin = 5000
                End If
                Call RellenaGrid()
                Exit Sub

            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Refrescar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If GLB_AccesoEmpleado = True Then
            Btn_Excel.Enabled = False
            Btn_Filtro.Enabled = False
            ' cargar ventas.
            Call usp_TraerVentasNetas()
            Call RellenaGrid()
        End If
    End Sub

    Private Sub DGrid_KeyUp_1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If Opcion = 2 Then
            CargarFotoArticulo(DGrid.Rows(DGrid.CurrentRow.Index).Cells("marca").Value, DGrid.Rows(DGrid.CurrentRow.Index).Cells("estilon").Value)
        End If
    End Sub
    Private Sub CargarFotoArticulo(ByVal Marca, ByVal Estilon)
        'mreyes 14/Marzo/2012 07:06 p.m.
        'Glb_RutaArchivoFotos
        Try
            Dim Archivo As String = ""
            Dim NoFoto As String = "1"

            MarcaFOTO = Marca
            ESTILONFOTO = Estilon
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

    Private Sub Btn_Foto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Foto.Click
        'mreyes 03/Marzo/2012 10:01 a.m.
        Try
            Dim myForm As New frmConsultaImagen
            myForm.Txt_Estilon.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("Estilon").Value.ToString
            myForm.Txt_Marca.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("Marca").Value.ToString.Trim()
            myForm.Txt_NoFoto.Text = "1"
            myForm.ShowDialog()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Regresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Regresar.Click
        Opcion = 1
        PBox.Visible = False
        SucursalB = ""
        Call RellenaGrid()
        'Call RellenaGrid2()
    End Sub

    Private Sub DGrid_Click_1(ByVal sender As Object, ByVal e As System.EventArgs)
        If Opcion = 2 Then
            CargarFotoArticulo(DGrid.Rows(DGrid.CurrentRow.Index).Cells("marca").Value, DGrid.Rows(DGrid.CurrentRow.Index).Cells("estilon").Value)
        End If
    End Sub

    Private Sub Btn_Marca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Marca.Click
        NuevoProveedorToolStripMenuItem.Visible = True
        ModificarProveedorToolStripMenuItem.Visible = False
        ConsultarProveedorToolStripMenuItem.Visible = True
        EstiloToolStripMenuItem.Visible = True
        Opcion = 3
        Call RellenaGrid()
    End Sub

    Private Sub Btn_Sucursal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Sucursal.Click
        NuevoProveedorToolStripMenuItem.Visible = False
        ModificarProveedorToolStripMenuItem.Visible = True
        ConsultarProveedorToolStripMenuItem.Visible = True
        EstiloToolStripMenuItem.Visible = True
        Opcion = 1
        SucursalB = ""
        Call RellenaGrid()
    End Sub

    Private Sub Btn_Estilos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Estilos.Click
        NuevoProveedorToolStripMenuItem.Visible = True
        ModificarProveedorToolStripMenuItem.Visible = True
        ConsultarProveedorToolStripMenuItem.Visible = True
        EstiloToolStripMenuItem.Visible = False
        Opcion = 2
        Call RellenaGrid()
    End Sub

    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub DGrid_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub

    Private Sub DGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.Click
        If Opcion = 2 Then
            CargarFotoArticulo(DGrid.Rows(DGrid.CurrentRow.Index).Cells("marca").Value, DGrid.Rows(DGrid.CurrentRow.Index).Cells("estilon").Value)
        End If
    End Sub

    Private Sub DGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick

        Try
            Dim columna As Integer = DGrid.CurrentCell.ColumnIndex
            Dim renglon As Integer = DGrid.CurrentCell.RowIndex

            If Opcion = 3 Then '' marca 
                Opcion = 2
                Marcab = DGrid.Rows(DGrid.CurrentRow.Index).Cells("sucursal").Value
                Call RellenaGrid()
                Exit Sub
            End If

            If Opcion = 6 Then
                Opcion = 2
                Marcab = ""
                Call RellenaGrid()
                Exit Sub
            End If

            If Opcion = 1 Or Opcion = 5 Then  'detallado
                Opcion = 2 'EMPLEADO EN DESGLOSE

                If DGrid.Rows(DGrid.CurrentRow.Index).Cells("descrip").Value <> "Total: " Then
                    SucursalB = DGrid.Rows(DGrid.CurrentRow.Index).Cells("sucursal").Value
                End If
                If columna >= 2 And columna <= 3 Then '15
                    DiasIni = 0
                    DiasFin = 15
                End If

                If columna >= 4 And columna <= 5 Then '30
                    DiasIni = 16
                    DiasFin = 30
                End If

                If columna >= 6 And columna <= 7 Then '45
                    DiasIni = 31
                    DiasFin = 45
                End If

                If columna >= 8 And columna <= 9 Then '60
                    DiasIni = 46
                    DiasFin = 60
                End If

                If columna >= 10 And columna <= 11 Then '90
                    DiasIni = 61
                    DiasFin = 90
                End If


                If columna >= 12 And columna <= 13 Then '120
                    DiasIni = 91
                    DiasFin = 120
                End If

                If columna >= 14 And columna <= 15 Then '120
                    DiasIni = 121
                    DiasFin = 140
                End If


                If columna >= 16 And columna <= 17 Then '120
                    DiasIni = 141
                    DiasFin = 160
                End If

                If Opcion = 1 Then
                    If columna >= 18 And columna <= 19 Then '120
                        DiasIni = 161
                        DiasFin = 200
                    End If
                Else
                    If columna >= 18 And columna <= 19 Then '120
                        DiasIni = 161
                        DiasFin = 350
                    End If
                End If

                If Opcion = 1 Then
                    If columna >= 20 And columna <= 21 Then '120
                        DiasIni = 201
                        DiasFin = 250
                    End If
                Else
                    If columna >= 20 And columna <= 21 Then '120
                        DiasIni = 351
                        DiasFin = 750
                    End If
                End If
                If Opcion = 1 Then

                    If columna >= 22 And columna <= 23 Then '120
                        DiasIni = 251
                        DiasFin = 300
                    End If
                Else
                    If columna >= 22 And columna <= 23 Then '120
                        DiasIni = 751
                        DiasFin = 5000
                    End If


                End If

                If columna >= 24 And columna <= 25 Then '120
                    DiasIni = 301
                    DiasFin = 350
                End If

                If columna >= 26 And columna <= 27 Then '120
                    DiasIni = 351
                    DiasFin = 450
                End If

                If columna >= 28 And columna <= 29 Then '120
                    DiasIni = 451
                    DiasFin = 550
                End If

                If columna >= 30 And columna <= 31 Then '120
                    DiasIni = 551
                    DiasFin = 650
                End If

                If columna >= 32 And columna <= 33 Then '120
                    DiasIni = 651
                    DiasFin = 750
                End If

                If columna >= 34 And columna <= 35 Then '120
                    DiasIni = 751
                    DiasFin = 850
                End If

                If columna >= 36 And columna <= 37 Then '120
                    DiasIni = 851
                    DiasFin = 1000
                End If

                If columna >= 38 And columna <= 39 Then '120
                    DiasIni = 1001
                    DiasFin = 1500
                End If

                If columna >= 40 And columna <= 41 Then '120
                    DiasIni = 1501
                    DiasFin = 2000
                End If
                If columna >= 42 And columna <= 43 Then '120
                    DiasIni = 2001
                    DiasFin = 5000
                End If
                Call RellenaGrid()
                Exit Sub

            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGrid.KeyUp
        Try
            If Opcion = 2 Then
                CargarFotoArticulo(DGrid.Rows(DGrid.CurrentRow.Index).Cells("marca").Value, DGrid.Rows(DGrid.CurrentRow.Index).Cells("estilon").Value)
            End If
            'If (e.KeyCode = Keys.Home) Then
            '    Dim columna As Integer = DGrid.CurrentCell.ColumnIndex
            '    DGrid.FirstDisplayedScrollingColumnIndex = columna
            'End If

            If (e.KeyCode = Keys.End) Then
                Dim columna As Integer = DGrid.CurrentCell.ColumnIndex
                DGrid.FirstDisplayedScrollingColumnIndex = columna
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Chk_Excluir_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call RellenaGrid()
        'Call RellenaGrid2()
    End Sub

    Private Sub chk_Desglosado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Opcion = 1
        Call RellenaGrid()
        'Call RellenaGrid2()
    End Sub

    Private Sub Bot_FamiliaLinea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        NuevoProveedorToolStripMenuItem.Visible = True
        ModificarProveedorToolStripMenuItem.Visible = True
        ConsultarProveedorToolStripMenuItem.Visible = False
        EstiloToolStripMenuItem.Visible = True
        Opcion = 6
        Call RellenaGrid()
    End Sub

    Private Sub Btn_Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Guardar.Click
        Try
            'If Opcion <> 1 Or Opcion <> 5 Or Opcion <> 6 Then Exit Sub
            Dim Folio As String = ""
            'Traer el ultimo folio disponible y sumarle 1
            Dim Fecha As String = ""
            Dim Hora As String = ""
            'Traer la fecha y la hora de la ultima modificacion
            'Guardar el encabezado
            Dim objDataSetAux As Data.DataSet
            
            'Traer la fecha y la hora de la ultima modificacion
            Fecha = FecHora.ToString("yyyy-MM-dd")
            Hora = FecHora.ToString("HH:mm:ss")
            
            If Opcion = 5 Then
                'Traer el ultimo folio disponible y sumarle 1
                If MessageBox.Show("Esta seguro de guardar la informacion?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
                Using objRegistro As New BCL.BCLAntiInvent(GLB_ConStringDWH)
                    objDataSet = objRegistro.usp_TraerFecHora("1", Fecha, Hora)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    MessageBox.Show("Los datos ya estan almacenados en la BD", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                Using objRegistro As New BCL.BCLAntiInvent(GLB_ConStringDWH)
                    objDataSet = objRegistro.usp_TraerFolioInvent("1")
                End Using
                Folio = (CInt(objDataSet.Tables(0).Rows(0).Item("folio")) + 1).ToString
                'Guardar el encabezado
                Using objRegistro As New BCL.BCLAntiInvent(GLB_ConStringDWH)
                    objRegistro.usp_InsertaInventario("1", Folio, Fecha, Hora)
                End Using
                For i As Integer = 0 To DGrid.Rows.Count - 3
                    objDataSetAux = Inserta_Actividad()
                    Dim objDataRow As Data.DataRow = objDataSetAux.Tables(0).NewRow
                    objDataRow.Item("folio") = Folio
                    objDataRow.Item("sucursal") = DGrid.Rows(i).Cells("Sucursal").Value.ToString
                    objDataRow.Item("descripsuc") = DGrid.Rows(i).Cells("descrip").Value.ToString
                    objDataRow.Item("familia") = ""
                    objDataRow.Item("descripfamilia") = ""
                    objDataRow.Item("linea") = ""
                    objDataRow.Item("descriplinea") = ""
                    objDataRow.Item("dias_15") = DGrid.Rows(i).Cells("dias_15").Value.ToString
                    objDataRow.Item("porc_15") = DGrid.Rows(i).Cells("porc_15").Value.ToString
                    objDataRow.Item("dias_30") = DGrid.Rows(i).Cells("dias_30").Value.ToString
                    objDataRow.Item("porc_30") = DGrid.Rows(i).Cells("porc_30").Value.ToString
                    objDataRow.Item("dias_45") = DGrid.Rows(i).Cells("dias_45").Value.ToString
                    objDataRow.Item("porc_45") = DGrid.Rows(i).Cells("porc_45").Value.ToString
                    objDataRow.Item("dias_60") = DGrid.Rows(i).Cells("dias_60").Value.ToString
                    objDataRow.Item("porc_60") = DGrid.Rows(i).Cells("porc_60").Value.ToString
                    objDataRow.Item("dias_90") = DGrid.Rows(i).Cells("dias_90").Value.ToString
                    objDataRow.Item("porc_90") = DGrid.Rows(i).Cells("porc_90").Value.ToString
                    objDataRow.Item("dias_120") = DGrid.Rows(i).Cells("dias_120").Value.ToString
                    objDataRow.Item("porc_120") = DGrid.Rows(i).Cells("porc_120").Value.ToString
                    objDataRow.Item("dias_140") = DGrid.Rows(i).Cells("dias_140").Value.ToString
                    objDataRow.Item("porc_140") = DGrid.Rows(i).Cells("porc_140").Value.ToString
                    objDataRow.Item("dias_160") = DGrid.Rows(i).Cells("dias_160").Value.ToString
                    objDataRow.Item("porc_160") = DGrid.Rows(i).Cells("porc_160").Value.ToString
                    objDataRow.Item("dias_350") = DGrid.Rows(i).Cells("dias_350").Value.ToString
                    objDataRow.Item("porc_350") = DGrid.Rows(i).Cells("porc_350").Value.ToString
                    objDataRow.Item("dias_750") = DGrid.Rows(i).Cells("dias_750").Value.ToString
                    objDataRow.Item("porc_750") = DGrid.Rows(i).Cells("porc_750").Value.ToString
                    objDataRow.Item("dias_751") = DGrid.Rows(i).Cells("dias_751").Value.ToString
                    objDataRow.Item("porc_751") = DGrid.Rows(i).Cells("porc_751").Value.ToString
                    objDataRow.Item("total") = DGrid.Rows(i).Cells("total").Value.ToString
                    objDataRow.Item("porc_tot") = DGrid.Rows(i).Cells("porc_tot").Value.ToString
                    objDataSetAux.Tables(0).Rows.Add(objDataRow)
                    'Guardar el detallado
                    Using objRegistro As New BCL.BCLAntiInvent(GLB_ConStringDWH)
                        objRegistro.usp_InsertaDetInventario("1", objDataSetAux)
                    End Using
                Next
                MessageBox.Show("Información guardada correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf Opcion = 6 Then
                If MessageBox.Show("Esta seguro de guardar la informacion?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
                Using objRegistro As New BCL.BCLAntiInvent(GLB_ConStringDWH)
                    objDataSet = objRegistro.usp_TraerFecHora("1", Fecha, Hora)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    MessageBox.Show("Los datos ya estan almacenados en la BD", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                Using objRegistro As New BCL.BCLAntiInvent(GLB_ConStringDWH)
                    objDataSet = objRegistro.usp_TraerFolioInvent("2")
                End Using
                Folio = (CInt(objDataSet.Tables(0).Rows(0).Item("folio")) + 1).ToString
                'Guardar el encabezado
                Using objRegistro As New BCL.BCLAntiInvent(GLB_ConStringDWH)
                    objRegistro.usp_InsertaInventario("2", Folio, Fecha, Hora)
                End Using
                For i As Integer = 0 To DGrid.Rows.Count - 3
                    objDataSetAux = Inserta_Actividad()
                    Dim objDataRow As Data.DataRow = objDataSetAux.Tables(0).NewRow
                    objDataRow.Item("folio") = Folio
                    objDataRow.Item("sucursal") = ""
                    objDataRow.Item("descripsuc") = ""
                    objDataRow.Item("familia") = DGrid.Rows(i).Cells("familia").Value.ToString
                    objDataRow.Item("descripfamilia") = DGrid.Rows(i).Cells("descrip").Value.ToString
                    objDataRow.Item("linea") = DGrid.Rows(i).Cells("linea").Value.ToString
                    objDataRow.Item("descriplinea") = DGrid.Rows(i).Cells("descrip1").Value.ToString
                    objDataRow.Item("dias_15") = DGrid.Rows(i).Cells("dias_15").Value.ToString
                    objDataRow.Item("porc_15") = DGrid.Rows(i).Cells("porc_15").Value.ToString
                    objDataRow.Item("dias_30") = DGrid.Rows(i).Cells("dias_30").Value.ToString
                    objDataRow.Item("porc_30") = DGrid.Rows(i).Cells("porc_30").Value.ToString
                    objDataRow.Item("dias_45") = DGrid.Rows(i).Cells("dias_45").Value.ToString
                    objDataRow.Item("porc_45") = DGrid.Rows(i).Cells("porc_45").Value.ToString
                    objDataRow.Item("dias_60") = DGrid.Rows(i).Cells("dias_60").Value.ToString
                    objDataRow.Item("porc_60") = DGrid.Rows(i).Cells("porc_60").Value.ToString
                    objDataRow.Item("dias_90") = DGrid.Rows(i).Cells("dias_90").Value.ToString
                    objDataRow.Item("porc_90") = DGrid.Rows(i).Cells("porc_90").Value.ToString
                    objDataRow.Item("dias_120") = DGrid.Rows(i).Cells("dias_120").Value.ToString
                    objDataRow.Item("porc_120") = DGrid.Rows(i).Cells("porc_120").Value.ToString
                    objDataRow.Item("dias_140") = DGrid.Rows(i).Cells("dias_140").Value.ToString
                    objDataRow.Item("porc_140") = DGrid.Rows(i).Cells("porc_140").Value.ToString
                    objDataRow.Item("dias_160") = DGrid.Rows(i).Cells("dias_160").Value.ToString
                    objDataRow.Item("porc_160") = DGrid.Rows(i).Cells("porc_160").Value.ToString
                    objDataRow.Item("dias_350") = DGrid.Rows(i).Cells("dias_350").Value.ToString
                    objDataRow.Item("porc_350") = DGrid.Rows(i).Cells("porc_350").Value.ToString
                    objDataRow.Item("dias_750") = DGrid.Rows(i).Cells("dias_750").Value.ToString
                    objDataRow.Item("porc_750") = DGrid.Rows(i).Cells("porc_750").Value.ToString
                    objDataRow.Item("dias_751") = DGrid.Rows(i).Cells("dias_751").Value.ToString
                    objDataRow.Item("porc_751") = DGrid.Rows(i).Cells("porc_751").Value.ToString
                    objDataRow.Item("total") = DGrid.Rows(i).Cells("total").Value.ToString
                    objDataRow.Item("porc_tot") = DGrid.Rows(i).Cells("porc_tot").Value.ToString
                    objDataSetAux.Tables(0).Rows.Add(objDataRow)
                    'Guardar el detallado
                    Using objRegistro As New BCL.BCLAntiInvent(GLB_ConStringDWH)
                        objRegistro.usp_InsertaDetInventario("2", objDataSetAux)
                    End Using
                Next
                MessageBox.Show("Información guardada correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Public Function Inserta_Actividad() As DataSet
        'Miguel Pérez - 24/Noviembre/2012 09:42 a.m.
        Try
            'Instantiate a new DataSet object
            Inserta_Actividad = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_Actividad.Tables.Add("actividades")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn

            objDataColumn = New DataColumn("folio", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("sucursal", Type.GetType("System.String"))
            objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("descripsuc", Type.GetType("System.String"))
            objDataColumn.MaxLength = 20
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("familia", Type.GetType("System.String"))
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("descripfamilia", Type.GetType("System.String"))
            objDataColumn.MaxLength = 20
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("linea", Type.GetType("System.String"))
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("descriplinea", Type.GetType("System.String"))
            objDataColumn.MaxLength = 20
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dias_15", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("porc_15", Type.GetType("System.Double"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dias_30", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("porc_30", Type.GetType("System.Double"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dias_45", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("porc_45", Type.GetType("System.Double"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dias_60", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("porc_60", Type.GetType("System.Double"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dias_90", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("porc_90", Type.GetType("System.Double"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dias_120", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("porc_120", Type.GetType("System.Double"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dias_140", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("porc_140", Type.GetType("System.Double"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dias_160", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("porc_160", Type.GetType("System.Double"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dias_350", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("porc_350", Type.GetType("System.Double"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dias_750", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("porc_750", Type.GetType("System.Double"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dias_751", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("porc_751", Type.GetType("System.Double"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("total", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("porc_tot", Type.GetType("System.Double"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Private Sub Chk_Calzado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_Calzado.CheckedChanged
        RellenaGrid()
    End Sub
End Class