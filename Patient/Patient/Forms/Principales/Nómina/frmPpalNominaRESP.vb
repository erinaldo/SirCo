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
    Dim TipoNomB As String = ""


    Dim Sw_Pintar As Boolean = False
    Dim Sw_Load As Boolean = True
    Dim Opcion As Integer = 1

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

    Private Sub frmPpalProveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            GLB_RefrescarPedido = False
            Opcion = 1
            Call LimpiarBusqueda()
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
            ToolTip.SetToolTip(Btn_Nomina, "Indicador por Tipo de Nómina")
            ToolTip.SetToolTip(Btn_Sucursal, "Indicador de Nómina por Sucursal")
            ToolTip.SetToolTip(Btn_Empleado, "Nómina por Empleado")
            ToolTip.SetToolTip(Btn_PercDeduc, "Nómina por tipo de concepto")
            ToolTip.SetToolTip(Btn_Filtro, "Búsqueda Avanzada")
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
            ToolTip.SetToolTip(Btn_Imprimir, "Imprimir Información")
            ToolTip.SetToolTip(Btn_Salir, "Salir")
            ToolTip.SetToolTip(Btn_Layout, "Generación Layout Banamex")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Function usp_EliminarNomina(ByVal IdPeriodo As Integer, ByVal TipoNom As String, ByVal Sucursal As String, ByVal IdEmpleado As Integer) As Boolean
        'mreyes 22/Agosto/2012 11:27 p.m.

        Using objNomina As New BCL.BCLNomina(GLB_ConStringNomSis)
            Try
                'Get the specific project selected in the ListView control
                usp_EliminarNomina = objNomina.usp_EliminarNomina(IdPeriodo, TipoNom, Sucursal, IdEmpleado)
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Private Sub Colores()
        Try
            Dim periodo As Integer = 0
            Dim TipoNom As String = ""
            Dim color1 As System.Drawing.Color
            color1 = Color.SandyBrown
            For J As Integer = 0 To DGrid.RowCount - 3
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
        Using objRegistro As New BCL.BCLNomina(GLB_ConStringNomSis)

            Try
                Me.Cursor = Cursors.WaitCursor
                DGrid.ReadOnly = True
                DGrid.DataSource = Nothing



                objDataSet = objRegistro.usp_PpalNomina(Opcion, IdPeriodoB, TipoNomB, idEmpleadoB, SucursalB, IdDeptoB, IdPuestoB)
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
                    Btn_Sucursal.Enabled = True
                    Btn_PercDeduc.Enabled = True
                    Sw_NoRegistros = True
                    Sw_Pintar = True
                    Call Colores()
                Else
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron Nóminas Calculadas que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                    Btn_Sucursal.Enabled = False
                    Btn_PercDeduc.Enabled = False
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
        IdPeriodoB = "INSERT INTO periodotemp (idperiodo1) VALUES (" & pub_TraerUltimoPeriodo(2) & ");"
        TipoNomB = ""
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


    Sub InicializaGrid()
        'mreyes 30/Junio/2012 10:47 a.m.
        Try

            Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)

            Dim row As DataRow = dt.NewRow()

            row(3) = "Total: "
            
            row(9) = pub_SumarColumnaGrid(DGrid, 9, DGrid.RowCount - 1)
            row(10) = pub_SumarColumnaGrid(DGrid, 10, DGrid.RowCount - 1)
            row(11) = pub_SumarColumnaGrid(DGrid, 11, DGrid.RowCount - 1)
            row(12) = pub_SumarColumnaGrid(DGrid, 12, DGrid.RowCount - 1)
            row(13) = pub_SumarColumnaGrid(DGrid, 13, DGrid.RowCount - 1)
            row(14) = pub_SumarColumnaGrid(DGrid, 14, DGrid.RowCount - 1)
            row(15) = pub_SumarColumnaGrid(DGrid, 15, DGrid.RowCount - 1)
            row(16) = pub_SumarColumnaGrid(DGrid, 16, DGrid.RowCount - 1)
            dt.Rows.Add(row)
            DGrid.DataSource = dt


            DGrid.RowHeadersVisible = False
            DGrid.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, 7, FontStyle.Regular)
            DGrid.Columns(0).HeaderText = "IdPeriodo"
            DGrid.Columns(1).HeaderText = "Fecha Inicio"
            DGrid.Columns(2).HeaderText = "Fecha Fin"
            DGrid.Columns(3).HeaderText = "Tipo Nómina"
            DGrid.Columns(4).HeaderText = "Sucursal"
            DGrid.Columns(5).HeaderText = "IdEmpleado"
            DGrid.Columns(6).HeaderText = "Nombre Completo"
            DGrid.Columns(7).HeaderText = "Departamento"
            DGrid.Columns(8).HeaderText = "Puesto"
            DGrid.Columns(9).HeaderText = "Días Trab."
            DGrid.Columns(10).HeaderText = "Prima Dom."
            DGrid.Columns(11).HeaderText = "Des. Trab."
            DGrid.Columns(12).HeaderText = "Extras"
            DGrid.Columns(13).HeaderText = "Retardo"
            DGrid.Columns(14).HeaderText = "O.Percep."
            DGrid.Columns(15).HeaderText = "O.Deduc."

            DGrid.Columns(16).HeaderText = "Total"

            DGrid.Columns(17).HeaderText = "Cuenta"
            DGrid.Columns(18).HeaderText = "PagosDec"
            DGrid.Columns(19).HeaderText = "NomLayout"
            DGrid.Columns(20).HeaderText = "FecLayout"
            DGrid.Columns(21).HeaderText = "RFC"
            DGrid.Columns(22).HeaderText = "SDiario"
            DGrid.Columns(23).HeaderText = "Ingreso"
            DGrid.Columns(24).HeaderText = "IMSS"
            DGrid.Columns(25).HeaderText = "FrecPago"
            DGrid.Columns(26).HeaderText = "Sucursal"
            DGrid.Columns(27).HeaderText = "Estatus"

            DGrid.Columns(0).Visible = False
            DGrid.Columns(27).Visible = False

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

            End If




            DGrid.Columns(17).Visible = False
            DGrid.Columns(18).Visible = False
            DGrid.Columns(19).Visible = False
            DGrid.Columns(20).Visible = False
            DGrid.Columns(21).Visible = False
            DGrid.Columns(22).Visible = False
            DGrid.Columns(23).Visible = False
            DGrid.Columns(24).Visible = False
            DGrid.Columns(25).Visible = False
            DGrid.Columns(26).Visible = False

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
            DGrid.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

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

            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

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


                    Using objPedidos As New BCL.BCLNomina(GLB_ConStringNomSis)
                        Dim objDataSet1 As Data.DataSet
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

    Private Sub Btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Imprimir.Click
        If MsgBox("Esta seguro de querer generar los recibos de nómina.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmación") = MsgBoxResult.No Then Exit Sub
        Me.Cursor = Cursors.AppStarting
        Call ImprimirReciboNomina()
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

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

                            '''cancelar pago... 
                            Call usp_EliminarNomina(DGrid.Rows(DGrid.CurrentCell.RowIndex).Cells("idperiodo").Value, Mid(DGrid.Rows(DGrid.CurrentCell.RowIndex).Cells("tiponom").Value, 1, 1), DGrid.Rows(DGrid.CurrentCell.RowIndex).Cells("sucursal").Value, DGrid.Rows(DGrid.CurrentCell.RowIndex).Cells("idempleado").Value)
                            DGrid.Rows.RemoveAt(DGrid.CurrentCell.RowIndex)
                            ''' 
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
End Class