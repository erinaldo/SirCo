Public Class frmPpalVentaNomina
    'mreyes 23/Agosto/2012 09:28 p.m.

    Private objDataSet As Data.DataSet



    Dim Sw_NoRegistros As Boolean = False
    Dim idEmpleadoB As Integer = 0
    Dim SucursalB As String = ""
    Dim IdDeptoB As Integer = 0
    Dim IdPuestoB As Integer = 0
    Dim FechaIniB As Date
    Dim FechaFinB As Date

    Dim idPercDeducB As Integer = 0
    Dim IdPeriodoB As String = ""
    Dim TipoNomB As String = ""


    Dim Sw_Pintar As Boolean = False
    Dim Sw_Load As Boolean = True
    Dim Opcion As Integer = 1
    Dim PeriodoUnico As Integer = 0

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

    Private Sub frmPpalVentaNomina_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave

    End Sub
    Private Sub frmPpalProveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            GLB_RefrescarPedido = False
            Opcion = 1
            Call LimpiarBusqueda()
            Call FechaUltimoPeriodo("P")

            Call GenerarToolTip()
            Sw_Pintar = True
            Sw_Load = True
            If GLB_AccesoEmpleado = True Then
                Btn_Excel.Enabled = False
                Btn_Filtro.Enabled = False
                ' cargar ventas.
                Call usp_TraerVentasNetas()
       
            End If
            Call RellenaGrid()
            If GLB_AccesoEmpleado = True Then
                Btn_Excel.Enabled = False
                Btn_Filtro.Enabled = False
            End If
            'If GLB_Idempleado <> 132 Then
            Btn_Refrescar.Visible = False
            'End If
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
                    PBar.Minimum = 0
                    PBar.Maximum = objDatasetE.Tables(0).Rows.Count
                    PBar.Value = 0
                    Dim Cont As Integer = objDatasetE.Tables(0).Rows.Count - 1
                    For Z = 0 To objDatasetE.Tables(0).Rows.Count - 1
                        ' Insertar en Empleados
                        PBar.Value = PBar.Value + 1
                        Txt_Porc.Text = Z & " de " & Cont
                        Application.DoEvents()
                        Call Inserta_VentaNomina(objDatasetE, Z)

                    Next
                End If
            End Using

            Using objMicrosipE As New BCL.BCLNomina(GLB_ConStringCipSis)
                Dim objDatasetE As Data.DataSet


                objDatasetE = objMicrosipE.usp_TraerVentasNetas(GLB_CveSucursal, "1", GLB_FechaHoy, GLB_FechaHoy)
                If objDatasetE.Tables(0).Rows.Count > 0 Then
                    Application.DoEvents()
                    PBar.Minimum = 0
                    PBar.Maximum = objDatasetE.Tables(0).Rows.Count
                    PBar.Value = 0
                    Dim Cont As Integer = objDatasetE.Tables(0).Rows.Count - 1
                    For Z = 0 To objDatasetE.Tables(0).Rows.Count - 1
                        ' Insertar en Empleados
                        PBar.Value = PBar.Value + 1
                        Txt_Porc.Text = Z & " de " & Cont
                        Application.DoEvents()
                        Call Inserta_VentaNomina(objDatasetE, Z)

                    Next
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    'Function Inserta_Venta(ByVal objDataSetE As Data.DataSet, ByVal I As Integer) As Boolean
    '    'mreyes 18/Agosto/2012 01:10 p.m.

    '    Dim Clave As String = ""
    '    Dim objDataSet As Data.DataSet
    '    Dim ClaveSuc As String = ""
    '    Dim IdEmpleado As Integer
    '    Using objCatalogo As New BCL.BCLNomina(GLB_ConStringNomSis)
    '        'Get a new Project DataSet
    '        Try
    '            objDataSet = objCatalogo.Inserta_Venta  'INSERTA NUEVO DATASET
    '            'Initialize a datarow object from the Project DataSet
    '            IdEmpleado = pub_TraerIdEmpleado(objDataSetE.Tables(0).Rows(I).Item("sucursal"), objDataSetE.Tables(0).Rows(I).Item("vendedor"))
    '            If IdEmpleado = 0 Then
    '                IdEmpleado = pub_TraerEncargadoTienda(objDataSetE.Tables(0).Rows(I).Item("sucursal"))
    '                If IdEmpleado = 0 Then
    '                    MsgBox("empleado cero")
    '                End If
    '            End If
    '            Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow

    '            'Falta definir extras en base a departamento

    '            objDataRow.Item("fecha") = objDataSetE.Tables(0).Rows(I).Item("fecha")
    '            objDataRow.Item("sucursal") = objDataSetE.Tables(0).Rows(I).Item("sucursal")
    '            objDataRow.Item("idempleado") = IdEmpleado
    '            objDataRow.Item("vendedor") = objDataSetE.Tables(0).Rows(I).Item("vendedor")
    '            objDataRow.Item("tipoart") = objDataSetE.Tables(0).Rows(I).Item("tipoart")
    '            objDataRow.Item("pares") = objDataSetE.Tables(0).Rows(I).Item("pares")
    '            objDataRow.Item("impvta") = objDataSetE.Tables(0).Rows(I).Item("impvta")
    '            objDataRow.Item("usuario") = GLB_Usuario

    '            'Add the DataRow to the DataSet
    '            objDataSet.Tables(0).Rows.Add(objDataRow)

    '            'Add the Project
    '            If Not objCatalogo.usp_Captura_Venta(objDataSet) Then
    '                'Throw New Exception("Falló Inserción de Proveedor")
    '            Else
    '                Inserta_Venta = True
    '            End If



    '        Catch ExceptionErr As Exception
    '            MessageBox.Show(ExceptionErr.Message.ToString)
    '        End Try
    '    End Using
    'End Function

    Private Sub GenerarToolTip()
        Try
           
            ToolTip.SetToolTip(Btn_Filtro, "Búsqueda Avanzada")
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")

            ToolTip.SetToolTip(Btn_Salir, "Salir")
            ToolTip.SetToolTip(Btn_Refrescar, "Refrescar Información")
         
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub RellenaGrid()
        'mreyes 30/Junio/2012   10:34 a.m.
        Using objRegistro As New BCL.BCLVentaNomina(GLB_ConStringNomSis)

            Try
                Me.Cursor = Cursors.WaitCursor
                DGrid.ReadOnly = True
                DGrid.DataSource = Nothing

                objDataSet = objRegistro.usp_PpalVentaNomina(Opcion, SucursalB, idEmpleadoB, FechaIniB, FechaFinB, IdDeptoB, IdPuestoB)
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
                    MsgBox("No se encontraron Ventas que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
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
        IdPeriodoB = "INSERT INTO periodotemp (idperiodo1) VALUES (" & pub_TraerUltimoPeriodo(2, "P") & ");"
        TipoNomB = ""
        IdDeptoB = 0
        IdPuestoB = 0
        If glb_cvesucursal <> "" Then
            SucursalB = glb_cvesucursal
        Else
            SucursalB = ""
        End If

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

            row(0) = "Total: "
            'row(7) = pub_SumarColumnaGrid(DGrid, 7, DGrid.RowCount - 1)
            'row(8) = pub_SumarColumnaGrid(DGrid, 8, DGrid.RowCount - 1)
            'row(9) = pub_SumarColumnaGrid(DGrid, 9, DGrid.RowCount - 1)
            row(10) = pub_SumarColumnaGrid(DGrid, 10, DGrid.RowCount - 1)
   
            dt.Rows.Add(row)
            DGrid.DataSource = dt


            DGrid.RowHeadersVisible = False
            DGrid.Columns(0).HeaderText = "Sucursal"
            DGrid.Columns(1).HeaderText = "Fecha"
            DGrid.Columns(2).HeaderText = "IdEmpleado"
            DGrid.Columns(3).HeaderText = "Vend."
            DGrid.Columns(4).HeaderText = "Nombre Completo"
            DGrid.Columns(5).HeaderText = "Puesto"
            DGrid.Columns(6).HeaderText = "Grupo"
            DGrid.Columns(7).HeaderText = "Venta Pares"
            DGrid.Columns(8).HeaderText = "Venta Importe"
            DGrid.Columns(9).HeaderText = "Meta"
            DGrid.Columns(10).HeaderText = "Gran Bono"
            DGrid.Columns(11).HeaderText = "IdPuesto"

            DGrid.Columns(11).Visible = True
            DGrid.Columns(12).Visible = False
            DGrid.Columns(13).Visible = False
            DGrid.Columns(14).Visible = False
            DGrid.Columns(15).Visible = False
        
            DGrid.Columns(1).Visible = False

            If Opcion = 1 Then
                '  DGrid.Columns(6).Visible = False
            End If

            DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
          
            DGrid.Columns(8).DefaultCellStyle.Format = "c"
            DGrid.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns(10).DefaultCellStyle.Format = "c"
            DGrid.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            DGrid.Columns("idpuesto").Visible = False
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
        'Dim myForm As New frmFiltrosNomina
        'Dim Estatus As String = ""

        'Dim TipoNomina = ""

        'TipoNomina = ""
        'If TipoNomB = "F" Then TipoNomina = "FISCAL"
        'If TipoNomB = "A" Then TipoNomina = "AMBAS"
        'If TipoNomB = "B" Then TipoNomina = "BONO"


        'myForm.Txt_IdEmpleado.Text = idEmpleadoB
        '' myForm.Cbo_Periodo.ValueMember = IdPeriodoB
        'myForm.Cbo_TipoNom.Text = TipoNomina

        'myForm.Txt_Sucursal.Text = SucursalB
        'myForm.Txt_IdDepto.Text = IdDeptoB
        'myForm.Txt_IdPuesto.Text = IdPuestoB

        '' myForm.Cbo_Estatus.Text = Estatus
        'myForm.ShowDialog()
        'idEmpleadoB = Val(myForm.Txt_IdEmpleado.Text)
        ''IdPeriodoB = "INSERT INTO periodotemp (idperiodo1) VALUES (" & pub_TraerUltimoPeriodo(2) & ");"
        'IdPeriodoB = "INSERT INTO periodotemp (idperiodo1) VALUES " & myForm.Periodo & ";"
        '' FechaIniB = myForm.FechaIniB
        'TipoNomB = Mid(myForm.Cbo_TipoNom.Text, 1, 1)

        'SucursalB = myForm.Txt_Sucursal.Text
        'IdDeptoB = Val(myForm.Txt_IdDepto.Text)
        'IdPuestoB = Val(myForm.Txt_IdPuesto.Text)

        'If myForm.Sw_Filtro = True Then
        '    Call RellenaGrid()
        'End If



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

        myForm.Txt_Sucursal.Text = SucursalB
        myForm.Txt_IdDepto.Text = IdDeptoB
        myForm.Txt_IdPuesto.Text = IdPuestoB

        ' myForm.Cbo_Estatus.Text = Estatus
        myForm.ShowDialog()
        idEmpleadoB = Val(myForm.Txt_IdEmpleado.Text)
        'IdPeriodoB = "INSERT INTO periodotemp (idperiodo1) VALUES (" & pub_TraerUltimoPeriodo(2) & ");"
        ' periodounico = myForm.Periodo
        ' IdPeriodoB = "INSERT INTO periodotemp (idperiodo1) VALUES " & myForm.Periodo & ";"
        'FechaIniB = myForm.FechaIniB
        '        PeriodoUnico = Val(Mid(myForm.Periodo, 2, 2))
        If Len(myForm.Periodo) >= 5 Then
            PeriodoUnico = Val(Mid(myForm.Periodo, 2, 3))
        Else
            PeriodoUnico = Val(Mid(myForm.Periodo, 2, 2))
        End If
        Call FechaUltimoPeriodo("")
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

   
    Private Sub DGrid_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGrid.CellFormatting
        Try

            'mreyes 24/Agosto/2012 12:33 p.m.



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

            If DGrid.Rows(e.RowIndex).Cells("idpuesto").Value = 4 Then
                Sw_NoEntro = True
                DGrid.Rows(e.RowIndex).Cells("descrippuesto").Style.BackColor = Color.LightGray
                DGrid.Rows(e.RowIndex).Cells("descrippuesto").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If

            If DGrid.Rows(e.RowIndex).Cells("idpuesto").Value = 5 Then
                Sw_NoEntro = True
                DGrid.Rows(e.RowIndex).Cells("descrippuesto").Style.BackColor = Color.LightYellow
                DGrid.Rows(e.RowIndex).Cells("descrippuesto").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If

            If DGrid.Rows(e.RowIndex).Cells("idpuesto").Value = 6 Then
                Sw_NoEntro = True
                DGrid.Rows(e.RowIndex).Cells("descrippuesto").Style.BackColor = Color.HotPink
                DGrid.Rows(e.RowIndex).Cells("descrippuesto").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If

            If DGrid.Rows(e.RowIndex).Cells("idpuesto").Value = 7 Then
                Sw_NoEntro = True
                DGrid.Rows(e.RowIndex).Cells("descrippuesto").Style.BackColor = Color.LightGreen
                DGrid.Rows(e.RowIndex).Cells("descrippuesto").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If

            If DGrid.Rows(e.RowIndex).Cells("idpuesto").Value = 8 Then
                Sw_NoEntro = True
                DGrid.Rows(e.RowIndex).Cells("descrippuesto").Style.BackColor = Color.LightSkyBlue
                DGrid.Rows(e.RowIndex).Cells("descrippuesto").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If

            If DGrid.Rows(e.RowIndex).Cells("idpuesto").Value = 9 Then
                Sw_NoEntro = True
                DGrid.Rows(e.RowIndex).Cells("descrippuesto").Style.BackColor = Color.LightSalmon
                DGrid.Rows(e.RowIndex).Cells("descrippuesto").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If

            If Not IsDBNull(DGrid.Rows(e.RowIndex).Cells("metapares").Value) Then
                If Val(DGrid.Rows(e.RowIndex).Cells("pares").Value) >= Val(DGrid.Rows(e.RowIndex).Cells("metapares").Value) Then
                    Sw_NoEntro = True
                    DGrid.Rows(e.RowIndex).Cells("bono").Style.BackColor = Color.Yellow
                    DGrid.Rows(e.RowIndex).Cells("bono").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick

        Try
            'If Opcion = 1 Then  'EMPLEADO
            '    Opcion = 2 'EMPLEADO EN DESGLOSE

            '    If DGrid.Rows(DGrid.CurrentRow.Index).Cells("descripsucursal").Value <> "Total: " Then
            '        idEmpleadoB = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idempleado").Value
            '    End If
            '    Call RellenaGrid()
            '    Exit Sub

            'End If
  
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Refrescar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Refrescar.Click
        If GLB_AccesoEmpleado = True Then
            Btn_Excel.Enabled = False
            Btn_Filtro.Enabled = False
            ' cargar ventas.
            Call usp_TraerVentasNetas()
            Call RellenaGrid()
            If GLB_AccesoEmpleado = True Then
                Btn_Excel.Enabled = False
                Btn_Filtro.Enabled = False
            End If
        End If
    End Sub

    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub

    Private Sub DGrid_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGrid.ColumnHeaderMouseClick
        Sw_Pintar = True
    End Sub
    Public Function GenerarAlcanceMetas() As DSAlcanceMetas

        Try
            Dim cont As Integer = 0
            GenerarAlcanceMetas = New DSAlcanceMetas
            For i As Integer = 0 To DGrid.RowCount - 3

                cont = 0
                Dim objDataRow1 As Data.DataRow = GenerarAlcanceMetas.Tables("Tbl_AlcanceMetas").NewRow()
                objDataRow1.Item("descripsucursal") = DGrid.Rows(i).Cells("descripsucursal").Value.ToString
                objDataRow1.Item("idempleado") = DGrid.Rows(i).Cells("idempleado").Value.ToString
                objDataRow1.Item("vendedor") = DGrid.Rows(i).Cells("vendedor").Value.ToString
                objDataRow1.Item("nomcompleto") = DGrid.Rows(i).Cells("nomcompleto").Value.ToString
                objDataRow1.Item("descrippuesto") = DGrid.Rows(i).Cells("descrippuesto").Value.ToString
                objDataRow1.Item("grupo") = DGrid.Rows(i).Cells("grupo").Value.ToString
                objDataRow1.Item("pares") = DGrid.Rows(i).Cells("pares").Value.ToString
                objDataRow1.Item("impvta") = DGrid.Rows(i).Cells("impvta").Value.ToString
                objDataRow1.Item("metapares") = DGrid.Rows(i).Cells("metapares").Value.ToString
                objDataRow1.Item("bono") = DGrid.Rows(i).Cells("bono").Value.ToString

                GenerarAlcanceMetas.Tables("Tbl_AlcanceMetas").Rows.Add(objDataRow1)

            Next
        Catch exceptionErr As Exception
            MessageBox.Show(exceptionErr.Message.ToString)

        End Try

    End Function
    Private Sub Btn_Imprimir_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Imprimir.Click
        Try
            Dim myFrom As New frmReportsBrowser
            myFrom.objDataSetAlcMetas = GenerarAlcanceMetas()
            myFrom.ReportIndex = 702

            myFrom.Show()



        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)

        End Try
    End Sub
End Class