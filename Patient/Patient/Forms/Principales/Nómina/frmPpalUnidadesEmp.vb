Public Class frmPpalUnidadesEmp
    'miguel perez 04/septiembre/2012 01:20 p.m.

    Private objDataSet As Data.DataSet
    Dim Sw_NoRegistros As Boolean = False
    Dim idEmpleadoB As Integer = 0
    Dim SucursalB As String = ""
    Dim IdDeptoB As Integer = 0
    Dim IdPuestoB As Integer = 0
    Dim FechaIniB As String = ""

    Dim idPercDeducB As Integer = 0
    Dim IdPeriodoB As String = ""
    Dim TipoNomB As String = ""
    Dim CveConcepto As String = ""

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

    Private Sub frmPpalProveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            GLB_RefrescarPedido = False
            Opcion = 1
            Call LimpiarBusqueda()
            Call RellenaGrid()

            Sw_Pintar = True
            Sw_Load = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    'Private Sub GenerarToolTip()
    '    Try
    '        ToolTip.SetToolTip(Btn_Nomina, "Indicador por Tipo de Nómina")
    '        ToolTip.SetToolTip(Btn_Sucursal, "Indicador de Nómina por Sucursal")
    '        ToolTip.SetToolTip(Btn_Empleado, "Nómina por Empleado")
    '        ToolTip.SetToolTip(Btn_PercDeduc, "Nómina por tipo de concepto")
    '        ToolTip.SetToolTip(Btn_Filtro, "Búsqueda Avanzada")
    '        ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
    '        ToolTip.SetToolTip(Btn_Imprimir, "Imprimir Información")
    '        ToolTip.SetToolTip(Btn_Salir, "Salir")
    '        ToolTip.SetToolTip(Btn_Layout, "Generación Layout Banamex")

    '    Catch ExceptionErr As Exception
    '        MessageBox.Show(ExceptionErr.Message.ToString)
    '    End Try
    'End Sub

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
        'mreyes 30/Junio/2012   10:34 a.m.
        Using objRegistro As New BCL.BCLConceptoRep(GLB_ConStringNomSis)

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
                'Modif Miguel Perez, Tony Garcia 29/Ago/2012
                ''''''''''''''''''
                objDataSet = objRegistro.usp_PpalConceptoReporte(IdPeriodoB, TipoNomB, idEmpleadoB, _
                                     SucursalB, IdDeptoB, IdPuestoB, CveConcepto)

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

        '"INSERT INTO periodotemp (idperiodo1) VALUES (4),(5),(6);"
        idEmpleadoB = 0
        'traer ultimo periodo abierto de nómina. 
        IdPeriodoB = "INSERT INTO periodotemp (idperiodo1) VALUES (" & pub_TraerUltimoPeriodo(2, "A") & ");"
        TipoNomB = ""
        IdDeptoB = 0
        IdPuestoB = 0
        CveConcepto = ""
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


    Sub InicializaGrid()

        Try


            Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
            Dim row As DataRow = dt.NewRow()
            row(8) = "Total: "
            row(12) = pub_SumarColumnaGrid(DGrid, 12, DGrid.RowCount - 1)
            dt.Rows.Add(row)

            DGrid.DataSource = dt

            DGrid.RowHeadersVisible = False
            DGrid.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, 7, FontStyle.Regular)

            DGrid.Columns(0).HeaderText = "IdPeriodo"
            DGrid.Columns(1).HeaderText = "Fecha Inicio"
            DGrid.Columns(2).HeaderText = "Fecha Fin"
            DGrid.Columns(3).HeaderText = "Tipo Nomina"
            DGrid.Columns(4).HeaderText = "Clave SUC"
            DGrid.Columns(5).HeaderText = "Sucursal"
            DGrid.Columns(6).HeaderText = "IdEmpleado"
            DGrid.Columns(7).HeaderText = "Empleado"
            DGrid.Columns(8).HeaderText = "Puesto"
            DGrid.Columns(9).HeaderText = "Id Percdeduc"
            DGrid.Columns(10).HeaderText = "Concepto"
            DGrid.Columns(11).HeaderText = "Unidades"
            DGrid.Columns(12).HeaderText = "Total"

            DGrid.Columns(0).Visible = False
            'DGrid.Columns(1).Visible = False
            'DGrid.Columns(2).Visible = False
            ' DGrid.Columns(3).Visible = False
            DGrid.Columns(4).Visible = False
            DGrid.Columns(6).Visible = False
            DGrid.Columns(9).Visible = False

            DGrid.Columns(6).ReadOnly = True
            DGrid.Columns(8).ReadOnly = True
            DGrid.Columns(9).ReadOnly = True
            DGrid.Columns(10).ReadOnly = True

            DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid.Columns(12).DefaultCellStyle.Format = "c"
            DGrid.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

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

    Private Sub DGrid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellDoubleClick

    End Sub

    Private Sub DGrid_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGrid.CellFormatting
        Try

            'mreyes 30/Junio/2012 10:59 a.m.
            If Opcion = 4 Then Exit Sub
            Dim Sw_NoEntro As Boolean = False

            Dim DiasEntrega As Integer = 0
            If Sw_Pintar = False Then Exit Sub

            If Me.DGrid.Columns(e.ColumnIndex).Name <> "Total" Then Exit Sub
            ''If Me.DGrid.Columns(e.ColumnIndex).Name <> "fecha" Then Exit Sub
            If e.RowIndex >= DGrid.RowCount - 2 Then
                If Sw_Load = False Then
                    Sw_Pintar = False
                End If
                Exit Sub
            End If


            If DGrid.Rows(e.RowIndex).Cells("Total").Value <= 0 Then
                DGrid.Rows(e.RowIndex).Cells("Total").Style.BackColor = Color.Red
                DGrid.Rows(e.RowIndex).Cells("Total").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
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
        myForm.sw = True
        Dim TipoNomina = ""

        TipoNomina = ""
        If TipoNomB = "F" Then TipoNomina = "FISCAL"
        If TipoNomB = "A" Then TipoNomina = "AMBAS"
        If TipoNomB = "B" Then TipoNomina = "BONO"


        myForm.Txt_IdEmpleado.Text = idEmpleadoB
        'myForm.Cbo_Periodo.ValueMember = IdPeriodoB
        myForm.Cbo_TipoNom.Text = TipoNomina

        myForm.Txt_Sucursal.Text = SUCURSALB
        myForm.Txt_IdDepto.Text = IDDEPTOB
        myForm.Txt_IdPuesto.Text = IdPuestoB
        myForm.Txt_IdConcepto.Text = CveConcepto

        ' myForm.Cbo_Estatus.Text = Estatus
        myForm.ShowDialog()
        idEmpleadoB = Val(myForm.Txt_IdEmpleado.Text)
        'IdPeriodoB = "INSERT INTO periodotemp (idperiodo1) VALUES (" & pub_TraerUltimoPeriodo(2) & ");"
        IdPeriodoB = "INSERT INTO periodotemp (idperiodo1) VALUES " & myForm.Periodo & ";"
        fechainib = myForm.FechaIniB
        TipoNomB = Mid(myForm.Cbo_TipoNom.Text, 1, 1)

        SucursalB = myForm.Txt_Sucursal.Text
        IdDeptoB = Val(myForm.Txt_IdDepto.Text)
        IdPuestoB = Val(myForm.Txt_IdPuesto.Text)
        CveConcepto = myForm.Txt_IdConcepto.Text


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


    Private Sub Btn_Nomina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Nomina.Click
        'miguel pérez 06/septiembre/2012 09:24 a.m.
        Dim intContador As Integer = 0
        Dim intperiodo As Integer
        Dim strTipoNomina As String
        Dim intIdEmp As Integer
        Dim intIdPerc As Integer

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

            If MsgBox("Esta seguro de querer eliminar de la nomina TODOS LOS REGISTROS SELECCIONADOS?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub
            For i As Integer = 0 To DGrid.Rows.Count - 1
                intperiodo = 0
                strTipoNomina = ""
                intIdEmp = 0
                intIdPerc = 0
                Using objRegistro As New BCL.BCLNomina(GLB_ConStringNomSis)
                    If DGrid.Rows(i).Cells("Selec").Value = True Then
                        intperiodo = CInt(DGrid.Rows(i).Cells("idperiodo").Value)
                        strTipoNomina = CStr(DGrid.Rows(i).Cells("tiponom").Value)
                        intIdEmp = CInt(DGrid.Rows(i).Cells("idempleado").Value)
                        intIdPerc = CInt(DGrid.Rows(i).Cells("idpercdeduc").Value)
                        If objRegistro.usp_EliminarNominaDet(intperiodo, strTipoNomina, intIdEmp, intIdPerc) = False Then
                            MsgBox("Error")
                        End If
                        If usp_GeneraNomina(intperiodo, Mid(strTipoNomina, 1, 1), "", intIdEmp) = False Then
                            MsgBox("No se pudo actualizar la Nómina", MsgBoxStyle.Critical, "Aviso")
                        End If
                    End If
                End Using

            Next
            MsgBox("Proceso Terminado", MsgBoxStyle.Information, "Confirmación")
            Call RellenaGrid()
            Me.Cursor = Cursors.Default
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Function usp_GeneraNomina(ByVal IdPeriodo As Integer, ByVal TipoNom As String, ByVal Sucursal As String, ByVal IdEmpleado As Integer) As Boolean
        'mreyes 12/Septiembre/2012 10:36 p.m.

        Using objNomina As New BCL.BCLNomina(GLB_ConStringNomSis)
            Try
                'Get the specific project selected in the ListView control
                usp_GeneraNomina = objNomina.usp_GeneraNomina(IdPeriodo, TipoNom, Sucursal, IdEmpleado, GLB_Usuario)
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function
End Class
'Using objRegistro As New BCL.BCLConceptoRep(GLB_ConStringNomSis)

'            Try
'                Me.Cursor = Cursors.WaitCursor
''DGrid.ReadOnly = True
'                DGrid.DataSource = Nothing

''Modif Miguel Perez, Tony Garcia 29/Ago/2012
'''''''''''''''''''
'                objDataSet = objRegistro.usp_PpalConceptoReporte(IdPeriodoB, TipoNomB, idEmpleadoB, _
'                                     SucursalB, IdDeptoB, IdPuestoB, CveConcepto)