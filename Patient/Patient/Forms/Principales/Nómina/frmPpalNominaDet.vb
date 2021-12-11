Public Class frmPpalNominaDet
    'mreyes 18/Julio/2012 09:58 a.m.

    Private objDataSet As Data.DataSet
    Dim Sw_NoRegistro As Boolean = False
    Dim Sw_NoRegistro1 As Boolean = False
    Dim idEmpleadoB As Integer = 0
    Dim SucursalB As String = ""
    Dim IdDeptoB As Integer = 0
    Dim IdPuestoB As Integer = 0
    Dim NaturalezaB As String = ""
    Dim PagoB As Decimal = 0
    Dim idPercDeducB As Integer = 0
    Public IdPeriodoB As Integer = 0
    Public FechaIniB As Date = "1900-01-01"
    Public FechaFinB As Date = "1900-01-01"
    Public TipoNomB As String = ""
    Public IdFrecPagob As Integer = 0

    Dim Sw_Pintar As Boolean = False
    Dim Sw_Load As Boolean = True
    Dim IdDepto As Integer = 0
    Dim IdPuesto As Integer = 0
    Dim Total As Decimal = 0
    Public Estatus As String = ""
    Dim Sw_Editar As Boolean = False



    Private Sub frmPpalProveedores_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            GLB_RefrescarPedido = False
            Me.Close()
        End If


    End Sub

    Private Sub frmPpalNominaDet_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave

    End Sub

    Private Sub frmPpalProveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            GLB_RefrescarPedido = False
            idEmpleadoB = Txt_idempleado.Text
            Call usp_TraerEmpleado()
           
            Call ups_TraerNominaDet(1, DGrid, "P", 0)
            Call ups_TraerNominaDet(1, DGrid1, "D", 1)
            InicializaGrid()
            InicializaGrid1()
            Call GenerarToolTip()
            Sw_Pintar = True
            Sw_Load = True
            If Estatus <> "A" Then
                Btn_Editar.Enabled = False
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub GenerarToolTip()
        Try

            ToolTip.SetToolTip(Btn_Editar, "Editar Nómina Empleado")
            ToolTip.SetToolTip(Btn_Imprimir, "Imprimir Información")
            ToolTip.SetToolTip(Btn_Salir, "Salir")
            ToolTip.SetToolTip(Btn_Marcaje, "Ver Marcaje")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub




    Private Sub ups_TraerNominaDet(ByVal Accion As Integer, ByVal Dgrid As System.Windows.Forms.DataGridView, ByVal NaturalezaB As String, ByVal Opcion As Integer)
        'mreyes 18/Julio/2012 11:02 a.m. 
        Using objRegistro As New BCL.BCLNomina(GLB_ConStringNomSis)

            Try
                Me.Cursor = Cursors.WaitCursor
                If Sw_Editar = False Then
                    Dgrid.ReadOnly = True
                End If
                Dgrid.DataSource = Nothing

                objDataSet = objRegistro.usp_TraerNominaDet(Accion, IdPeriodoB, TipoNomB, idEmpleadoB, NaturalezaB, 0, 0)
                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section

                    Dgrid.DataSource = objDataSet.Tables(0)

                    'LimpiarBusqueda()
                    Me.Cursor = Cursors.Default

                    Btn_Editar.Enabled = True
                    If Opcion = 0 Then
                        Sw_NoRegistro = True

                    End If

                    If Opcion = 1 Then
                        Sw_NoRegistro1 = True
                    End If
                    Sw_Pintar = True
                Else
                    If Opcion = 0 Then
                        Sw_NoRegistro = False

                    End If

                    If Opcion = 1 Then
                        Sw_NoRegistro1 = False
                    End If
                    Me.Cursor = Cursors.Default
                    If Sw_NoRegistro1 = True Or Sw_NoRegistro = True Then
                        Btn_Editar.Enabled = True
                    Else
                        Btn_Editar.Enabled = False
                    End If


                End If
                Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using


    End Sub


    Private Function ups_ExisteNominaDet(ByVal IdPercDeduc As Integer, ByVal IdRepetitivo As Integer) As Boolean
        'mreyes 19/Julio/2012 11:19 a.m.
        Dim objDataSet As Data.DataSet

        Using objRegistro As New BCL.BCLNomina(GLB_ConStringNomSis)

            Try
                objDataSet = objRegistro.usp_TraerNominaDet(1, IdPeriodoB, TipoNomB, idEmpleadoB, NaturalezaB, IdRepetitivo, IdPercDeduc)
                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section
                    ups_ExisteNominaDet = True
                Else
                    ups_ExisteNominaDet = False
                End If
                
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using


    End Function
    Private Sub LimpiarBusqueda()


        idEmpleadoB = 0
        IdPeriodoB = 3
        TipoNomB = ""
        IdDeptoB = 0
        IdPuestoB = 0
        SucursalB = ""

    End Sub




    Sub InicializaGrid()
        'mreyes 18/Julio/2012 12:30 p.m.
        Try
            If Sw_NoRegistro = False Then Exit Sub
            Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
            Dim row As DataRow = dt.NewRow()
            row(4) = "Total: "
            row(5) = pub_SumarColumnaGrid(DGrid, 5, DGrid.RowCount - 1)
            row(6) = pub_SumarColumnaGrid(DGrid, 6, DGrid.RowCount - 1)
            Total = row(5) + row(6)
            Lbl_Total.Text = "TOTAL: " & Format(Total, "c")
            pagob = Total
            dt.Rows.Add(row)
            DGrid.DataSource = dt


            DGrid.RowHeadersVisible = False

            DGrid.Columns(0).HeaderText = "IdPercDeduc"
            DGrid.Columns(1).HeaderText = "IdRepetitivo"
            DGrid.Columns(2).HeaderText = "Cve"
            DGrid.Columns(3).HeaderText = "Días/Hrs"
            DGrid.Columns(4).HeaderText = "Descripción"
            DGrid.Columns(5).HeaderText = "Imp. Gravable"
            DGrid.Columns(6).HeaderText = "Imp. Exento"
            DGrid.Columns(7).HeaderText = "Saldo"

            DGrid.Columns(0).Visible = False
            DGrid.Columns(1).Visible = False
            DGrid.Columns(7).Visible = False


            DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


            DGrid.Columns(5).DefaultCellStyle.Format = "c"
            DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns(6).DefaultCellStyle.Format = "c"
            DGrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns(7).DefaultCellStyle.Format = "c"
            DGrid.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Sub InicializaGrid1()
        'mreyes 18/Julio/2012 12:30 p.m.
        Try
            If Sw_NoRegistro1 = False Then Exit Sub
            If sw_Editar = False Then
                Dim dt As DataTable = TryCast(DGrid1.DataSource, DataTable)
                Dim row As DataRow = dt.NewRow()
                row(4) = "Total: "
                row(5) = pub_SumarColumnaGrid(DGrid1, 5, DGrid1.RowCount - 1)
                row(6) = pub_SumarColumnaGrid(DGrid1, 6, DGrid1.RowCount - 1)
                Total = Total - row(5) - row(6)
                Lbl_Total.Text = "TOTAL: " & Format(Total, "c")
                PagoB = Total
                dt.Rows.Add(row)
                DGrid1.DataSource = dt
            End If
            DGrid1.RowHeadersVisible = False

            DGrid1.Columns(0).HeaderText = "IdPercDeduc"
            DGrid1.Columns(1).HeaderText = "IdRepetitivo"
            DGrid1.Columns(2).HeaderText = "Cve"
            DGrid1.Columns(3).HeaderText = "Días/Hrs"
            DGrid1.Columns(4).HeaderText = "Descripción"
            DGrid1.Columns(5).HeaderText = "Retención"
            DGrid1.Columns(6).HeaderText = "Retención"
            DGrid1.Columns(7).HeaderText = "Saldo"

            DGrid1.Columns(0).Visible = False
            DGrid1.Columns(1).Visible = False

            DGrid1.Columns(5).Visible = False


            DGrid1.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


            DGrid1.Columns(5).DefaultCellStyle.Format = "c"
            DGrid1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid1.Columns(6).DefaultCellStyle.Format = "c"
            DGrid1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            DGrid1.Columns(7).DefaultCellStyle.Format = "c"
            DGrid1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            DGrid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            If Sw_Editar = False Then
                DGrid1.Rows(DGrid1.RowCount - 2).DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid1.Rows(DGrid1.RowCount - 2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                DGrid1.Rows(DGrid1.RowCount - 2).DefaultCellStyle.Font = New Font(DGrid1.DefaultCellStyle.Font.FontFamily, DGrid1.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        GLB_RefrescarPedido = False
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Btn_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If ExportarDGridAExcel(DGrid) = False Then
                MsgBox("Error al exportar a Excel. Intente nuevamente.", MsgBoxStyle.Critical, "Excel")
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub CargarFormaConsulta(ByVal Renglon As Integer)


        Dim myForm As New frmConsulta


        myForm.Tipo = "PD"
        myForm.ShowDialog()
        Txt_Clave.Text = myForm.Campo
        DGrid.Rows(Renglon).Cells("descripc").Value = myForm.Campo1
        DGrid.Rows(Renglon).Cells("clave").Value = myForm.Campo
        DGrid.Rows(Renglon).Cells("idpercdeduc").Value = myForm.Campo2

       
    End Sub

    Private Sub DGrid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellEndEdit
        Try
            'mreyes 19/Julio/2012 11:32 a.m.

            Dim columna As Integer = DGrid.CurrentCell.ColumnIndex
            Dim renglon As Integer = DGrid.CurrentCell.RowIndex


            If columna = 2 Then


                Using objMySqlGral As New BCL.BCLCatalogoPercDeduc(GLB_ConStringNomSis)
                    Try
                        objDataSet = objMySqlGral.usp_PpalCatalogoPercDeduc(0, DGrid.Rows(renglon).Cells("clave").Value, "", "", "", "", "", "", "")
                        If objDataSet.Tables(0).Rows.Count > 0 Then
                            DGrid.Rows(renglon).Cells("descripc").Value = objDataSet.Tables(0).Rows(0).Item("DescripC").ToString
                            DGrid.Rows(renglon).Cells("clave").Value = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                            DGrid.Rows(renglon).Cells("idpercdeduc").Value = objDataSet.Tables(0).Rows(0).Item("idpercdeduc").ToString
                            DGrid.Rows(renglon).Cells("idrepetitivo").Value = "0"
                            DGrid.Rows(renglon).Cells("impgrav").Value = "0"
                            DGrid.Rows(renglon).Cells("impexento").Value = "0"
                        Else
                            Call CargarFormaConsulta(renglon)
                        End If


                    Catch ExceptionErr As Exception
                        MessageBox.Show(ExceptionErr.Message.ToString)
                    End Try
                End Using
            End If

            If columna = 3 Then  ' es importe el que hay que calcular.

                '' el idpercde3duc 2 es la asistencia. 
                'no se puede modificar un 4 que es subsidio.. 
                '2 es salario minimo

                If DGrid.Rows(renglon).Cells("idpercdeduc").Value = 19 Then
                    DGrid.Rows(renglon).Cells("impexento").Value = DGrid.Rows(renglon).Cells(3).Value * Txt_SDiario.Text
                    '' prima vacacional. 
                    'DGrid.Rows.Add()
                    'DGrid.Rows(renglon + 1).Cells(0).Value = "20"
                    'DGrid.Rows(renglon + 1).Cells(1).Value = ""
                    'DGrid.Rows(renglon + 1).Cells(2).Value = "PVA"
                    'DGrid.Rows(renglon + 1).Cells(3).Value = "1"
                    'DGrid.Rows(renglon + 1).Cells(4).Value = "PRIMA DOMINICAL"
                    'DGrid.Rows(renglon + 1).Cells(5).Value = ""
                    'DGrid.Rows(renglon + 1).Cells(6).Value = (DGrid.Rows(renglon).Cells(3).Value * Txt_SDiario.Text) * 0.25

                    Exit Sub
                End If

                If DGrid.Rows(renglon).Cells("idpercdeduc").Value = 20 Then
                    For j As Integer = 0 To DGrid.RowCount - 1

                        If DGrid.Rows(j).Cells("idpercdeduc").Value = 19 Then
                            DGrid.Rows(renglon).Cells("impexento").Value = (DGrid.Rows(j).Cells(3).Value * Txt_SDiario.Text) * 0.25
                            Exit For
                        End If
                    Next


                    Exit Sub
                End If

                If DGrid.Rows(renglon).Cells("idpercdeduc").Value = 4 Then
                    MsgBox("No puede modificar un subsidio.", MsgBoxStyle.Critical, "Aviso")
                    Exit Sub
                End If

                If DGrid.Rows(renglon).Cells("idpercdeduc").Value = 9 Then
                    'extras(sdiarioC / jornadaC) * (ExtrasV * 2)
                    DGrid.Rows(renglon).Cells("impexento").Value = Txt_SDiario.Text / Val(Txt_Jornada.Text) * (DGrid.Rows(renglon).Cells(3).Value) * 2
                End If

                If DGrid.Rows(renglon).Cells("idpercdeduc").Value = 15 Then  'bono de desempeño
                    '' 
                    MsgBox("No puede modificar una unidad del bono de desempeño.", MsgBoxStyle.Critical, "Error")
                    Exit Sub

                End If

                If DGrid.Rows(renglon).Cells("idpercdeduc").Value = 2 Then   ''SEULDO NORMAL
                    ' DIAS A MODIFICAR..
                    Dim Asistencia As Integer = 0
                    Dim Falta As Integer = 0
                    Dim BonoFijo As Decimal = 0
                    For J As Integer = 0 To DGrid1.RowCount - 1
                        If DGrid1.Rows(J).Cells("idpercdeduc").Value = 7 Then
                            Falta = 7 - DGrid.Rows(renglon).Cells(3).Value
                            DGrid1.Rows(J).Cells(3).Value = 7 - DGrid.Rows(renglon).Cells(3).Value  'cambiar 7 fijo, checando el sql, de inicio.
                            Exit For
                        End If
                    Next
                    Asistencia = DGrid.Rows(renglon).Cells(3).Value * Txt_SDiario.Text
                    DGrid.Rows(renglon).Cells("impgrav").Value = Asistencia
                    'calcular subsidio
                    For j As Integer = 0 To DGrid.RowCount - 1

                        If DGrid.Rows(j).Cells("idpercdeduc").Value = 4 Then
                            DGrid.Rows(j).Cells("impexento").Value = usp_TraerCalculaSubsidio(7 - Falta)
                            Exit For
                        End If
                    Next
                End If
                If DGrid.Rows(renglon).Cells("idpercdeduc").Value = 8 Then 'BONOFIJO

                    Dim Asistencia As Integer = 0
                    Dim Falta As Integer = 0
                    Dim BonoFijo As Decimal = 0
                    For J As Integer = 0 To DGrid.RowCount - 1
                        If DGrid.Rows(J).Cells("idpercdeduc").Value = 15 Or DGrid.Rows(J).Cells("idpercdeduc").Value = 8 Then
                            Asistencia = DGrid.Rows(J).Cells(3).Value
                            Exit For
                        End If
                    Next
                    For J As Integer = 0 To DGrid1.RowCount - 1
                        If DGrid1.Rows(J).Cells("idpercdeduc").Value = 7 Then
                            Falta = DGrid1.Rows(J).Cells(3).Value
                            Exit For
                        End If
                    Next
                    BonoFijo = (Asistencia * Txt_BonoFijo.Text) / 7
                    DGrid.Rows(renglon).Cells("impexento").Value = BonoFijo
                    ' calcular retardo
                    'sdiarioC * 10/100*(asistenciaV - FaltaV)
                    For J As Integer = 0 To DGrid1.RowCount - 1
                        If DGrid1.Rows(J).Cells("idpercdeduc").Value = 10 Then
                            DGrid1.Rows(J).Cells("impexento").Value = Txt_SDiario.Text * 10 / 100 * (Asistencia - Falta)
                            Exit For
                        End If
                    Next
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Function usp_TraerCalculaSubsidio(ByVal Asistencia As Decimal) As Decimal
        'mreyes 03/Agosto/2012 04:54 p.m.
        Dim Subsidio As Decimal = 0
        Using objMySqlGral As New BCL.BCLNomina(GLB_ConStringNomSis)
            Try
                objDataSet = objMySqlGral.usp_TraerCalculaSubsidio(IdFrecPagob, Asistencia * Txt_SDiario.Text)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    usp_TraerCalculaSubsidio = objDataSet.Tables(0).Rows(0).Item("SubsidioB").ToString
                Else
                    usp_TraerCalculaSubsidio = 0
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function
    Private Sub Totalizados()
        Dim Total As Decimal = 0
        Total = pub_SumarColumnaGrid(DGrid, 4, DGrid.RowCount - 1) + pub_SumarColumnaGrid(DGrid, 5, DGrid.RowCount - 1)
        Total = Total + pub_SumarColumnaGrid(DGrid1, 4, DGrid.RowCount - 1)
        Lbl_Total.Text = "TOTAL: " & Format(Total, "c")
        pagob = Total
    End Sub




    Private Sub Btn_Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar.Click
        'mreyes 18/Julio/2012 05:06 p.m.
        Dim sw_entro As Boolean = False
        Try
            If MsgBox("Esta usted seguro de querer modificar los datos del calculo de la nómina para el empleado.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmación") = MsgBoxResult.No Then Exit Sub
            sw_Editar = True
            DGrid.BackgroundColor = Color.Beige
            DGrid1.BackgroundColor = Color.Beige
            Btn_Imprimir.Enabled = False
            DGrid.ReadOnly = False
            DGrid1.ReadOnly = False
            DGrid.Columns("descripc").ReadOnly = False
            If DGrid1.RowCount > 0 Then
                DGrid1.Columns("descripc").ReadOnly = False
                DGrid1.Columns("saldo").ReadOnly = False
            Else
                '  DGrid1.RowCount = 2

                DGrid1.ReadOnly = False
                Call ups_TraerNominaDet(2, DGrid1, "D", 1)
                Call InicializaGrid1()
                DGrid1.Columns("descripc").ReadOnly = False
                DGrid1.Columns("saldo").ReadOnly = False
                sw_entro = True
            End If

            Btn_Aceptar.Enabled = True
            If Sw_NoRegistro = True Then DGrid.Rows.RemoveAt(DGrid.RowCount - 2)
            If sw_entro = False Then
                If Sw_NoRegistro1 = True Then DGrid1.Rows.RemoveAt(DGrid1.RowCount - 2)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub ModificarProveedorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarProveedorToolStripMenuItem.Click
        Call Btn_Editar_Click(sender, e)
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
    Public Function usp_TraerTotalPercDeduc(ByVal IdPeriodo As Integer, ByVal TipoNom As String, _
             ByVal IdEmpleado As Integer, ByRef Deduccion As Decimal, ByRef Percepcion As Decimal) As Boolean
        'mreyes 11/Septiembre/2012 04:08 p.m.
        Using obj As New BCL.BCLNomina(GLB_ConStringNomSis)
            Try
                Dim Entro As Boolean = False
                objDataSet = obj.usp_TraerTotalPercDeduc(IdPeriodo, TipoNom, IdEmpleado)

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Entro = True
                    Deduccion = objDataSet.Tables(0).Rows(0).Item("deduccion").ToString
                    Percepcion = objDataSet.Tables(0).Rows(0).Item("percepcion").ToString
                Else
                    usp_TraerTotalPercDeduc = 0.0
                End If
                usp_TraerTotalPercDeduc = True
            Catch ExceptionErr As Exception
                usp_TraerTotalPercDeduc = 0
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function
    Private Function GenerarDSReciboNomina() As DSReciboNomina
        'mreyes 10/Junio/2012 06:23 p.m.
        Dim Deduccion As Decimal = 0
        Dim Percepcion As Decimal = 0
        Try
            If usp_TraerTotalPercDeduc(IdPeriodoB, TipoNomB, idEmpleadoB, Deduccion, Percepcion) = True Then

                GenerarDSReciboNomina = New DSReciboNomina
                'Generar Encabezado... 
                Dim objDataRow1 As Data.DataRow = GenerarDSReciboNomina.Tables("Tbl_Recibo").NewRow
                objDataRow1.Item("FechaIni") = Format(FechaIniB, "yyyy-MM-dd")
                objDataRow1.Item("FechaFin") = Format(FechaFinB, "yyyy-MM-dd")
                objDataRow1.Item("idEmpleado") = Txt_idempleado.Text
                objDataRow1.Item("NombreCompleto") = Txt_Nombre.Text
                objDataRow1.Item("rfc") = Txt_RFC.Text
                objDataRow1.Item("depto") = Txt_DescripDepto.Text
                objDataRow1.Item("puesto") = Txt_DescripPuesto.Text
                objDataRow1.Item("sueldo") = Txt_SDiario.Text
                objDataRow1.Item("tperc") = Percepcion
                objDataRow1.Item("tdeduc") = Deduccion
                objDataRow1.Item("total") = Format(Percepcion - Deduccion, "n2")
                objDataRow1.Item("ingreso") = Txt_Ingreso.Text
                objDataRow1.Item("noimss") = Txt_NoIMSS.Text
                objDataRow1.Item("SUCURSAL") = Txt_DescripSucursal.Text
                GenerarDSReciboNomina.Tables("Tbl_Recibo").Rows.Add(objDataRow1)
                'Termina Genera Encabezado.
                'ir por el detallado de cada empleado, para conocer las percepc


                Using objRegistro As New BCL.BCLNomina(GLB_ConStringNomSis)
                    Dim objDataSet As Data.DataSet
                    Try
                        objDataSet = objRegistro.usp_ReciboNominaDet(IdPeriodoB, TipoNomB, Txt_idempleado.Text)

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

                                If objDataSet.Tables(0).Rows(j).Item("descripperc").ToString = "" Then
                                    objDataRow.Item("DescripcionPerc") = ""
                                    objDataRow.Item("Gravable") = ""
                                    objDataRow.Item("Exento") = ""
                                Else

                                    objDataRow.Item("DescripcionPerc") = objDataSet.Tables(0).Rows(j).Item("descripperc").ToString
                                    objDataRow.Item("Gravable") = Format(objDataSet.Tables(0).Rows(j).Item("gravable"), "N2")
                                    objDataRow.Item("Exento") = Format(objDataSet.Tables(0).Rows(j).Item("exento"), "N2")
                                End If

                                If objDataSet.Tables(0).Rows(j).Item("unideduc").ToString = "0" Then
                                    objDataRow.Item("unideduc") = ""
                                Else
                                    objDataRow.Item("UniDeduc") = objDataSet.Tables(0).Rows(j).Item("unideduc").ToString
                                End If

                                If objDataSet.Tables(0).Rows(j).Item("descripdeduc").ToString = "" Then
                                    objDataRow.Item("DescripcionDeduc") = ""
                                    objDataRow.Item("Retencion") = ""
                                    objDataRow.Item("Saldo") = ""
                                Else
                                    objDataRow.Item("DescripcionDeduc") = objDataSet.Tables(0).Rows(j).Item("descripdeduc").ToString
                                    objDataRow.Item("Retencion") = Format(objDataSet.Tables(0).Rows(j).Item("retencion"), "N2")
                                    If Val(objDataSet.Tables(0).Rows(j).Item("idpercdeduc")) = 1 Then
                                        objDataRow.Item("Saldo") = ""
                                    Else
                                        objDataRow.Item("Saldo") = Format(objDataSet.Tables(0).Rows(j).Item("saldo"), "N2")
                                    End If


                                End If
                        GenerarDSReciboNomina.Tables("Tbl_ReciboDet").Rows.Add(objDataRow)
                            Next
                        End If
                        '''' LLENAR DETALLADO DE ORDE COMP
                    Catch ExceptionErr As Exception
                        MessageBox.Show(ExceptionErr.Message.ToString)
                    End Try
                End Using

                Pnl_Bar.Visible = False
            Else
                MsgBox("No se puede emitir el reporte. No hay pagos", MsgBoxStyle.Critical, "Aviso")
            End If
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
        If TipoNomB = "B" Then
            Call ImprimirReciboBono()
        Else
            Call ImprimirReciboNomina()
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub usp_TraerEmpleado()
        'mreyes 20/Junio/2012 12:31 p.m.
        Dim objDataSet As Data.DataSet
        Using objCatalogo As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)
            Try

                objDataSet = objCatalogo.usp_TraerEmpleado(Txt_idempleado.Text)
                If objDataSet.Tables(0).Rows.Count > 0 Then

                    Txt_Clave.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    Txt_Nombre.Text = objDataSet.Tables(0).Rows(0).Item("nomcompleto").ToString
                    IdDepto = objDataSet.Tables(0).Rows(0).Item("iddepto")
                    Txt_ClaveDepto.Text = objDataSet.Tables(0).Rows(0).Item("clavedepto")
                    Txt_DescripDepto.Text = objDataSet.Tables(0).Rows(0).Item("descripdepto")
                    IdPuesto = objDataSet.Tables(0).Rows(0).Item("idpuesto")
                    Txt_ClavePuesto.Text = objDataSet.Tables(0).Rows(0).Item("clavepuesto")
                    Txt_DescripPuesto.Text = objDataSet.Tables(0).Rows(0).Item("descrippuesto")
                    Txt_Sucursal.Text = Mid(Txt_Clave.Text, 1, 2)
                    Txt_DescripSucursal.Text = objDataSet.Tables(0).Rows(0).Item("descripsucursal")
                    Txt_Jornada.Text = objDataSet.Tables(0).Rows(0).Item("jornada")
                    Txt_Comida.Text = objDataSet.Tables(0).Rows(0).Item("comida")
                    Txt_Descanso.Text = pub_TraerDiaLargoDescanso(objDataSet.Tables(0).Rows(0).Item("descanso"))
                    Txt_BonoFijo.Text = Format(objDataSet.Tables(0).Rows(0).Item("bonofijo"), "c")
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub



    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        'mreyes 18/Julio/2012 04:45 p.m.
        If MsgBox("Esta seguro de guardar los cambios efectuados", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmación") = MsgBoxResult.No Then Exit Sub


        If Inserta_NominaDet() = True Then
            If usp_GeneraNomina(IdPeriodoB, TipoNomB, Txt_Sucursal.Text, idEmpleadoB) = True Then
                GLB_RefrescarPedido = True
                MessageBox.Show("Exitosamente Grabado el detallado de nómina!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Me.Close()
                '' Me.Dispose()
            Else
                MsgBox("No se pudo generar Nómina. Reportelo a sistemas", MsgBoxStyle.Critical, "Error")
                Exit Sub
            End If
          
        Else
            MessageBox.Show("Error Grabando !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If
    End Sub

    Function Inserta_NominaDet() As Boolean
        'mreyes 19/Julio/2012 10:07 a.m.
        Dim objDataSet As Data.DataSet
        Dim Accion As Integer = 0
        For i As Integer = 0 To DGrid.RowCount - 1
            Using objCatalogo As New BCL.BCLNomina(GLB_ConStringNomSis)
                'Get a new Project DataSet
                Try
                    '' Buscar si existe ya el registro.. 
                    If Val(DGrid.Rows(i).Cells("idpercdeduc").Value) <> 0 Then
                        If ups_ExisteNominaDet(Val(DGrid.Rows(i).Cells("idpercdeduc").Value), Val(DGrid.Rows(i).Cells("idrepetitivo").Value)) = True Then
                            Accion = 2
                        Else
                            Accion = 1
                        End If

                        objDataSet = objCatalogo.Inserta_NominaDet  'INSERTA NUEVO DATASET
                        'Initialize a datarow object from the Project DataSet
                        Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow
                        objDataRow.Item("idperiodo") = IdPeriodoB
                        objDataRow.Item("tiponom") = TipoNomB
                        objDataRow.Item("idempleado") = idEmpleadoB
                        objDataRow.Item("idpercdeduc") = DGrid.Rows(i).Cells("idpercdeduc").Value
                        objDataRow.Item("idrepetitivo") = DGrid.Rows(i).Cells("idrepetitivo").Value
                        objDataRow.Item("unidades") = DGrid.Rows(i).Cells("unidades").Value
                        objDataRow.Item("impgrav") = DGrid.Rows(i).Cells("impgrav").Value
                        objDataRow.Item("impexento") = DGrid.Rows(i).Cells("impexento").Value
                        objDataRow.Item("usuario") = GLB_Usuario
                        objDataRow.Item("usumodif") = GLB_Usuario
                        objDataRow.Item("fummodif") = Date.Now

                        'Add the DataRow to the DataSet
                        objDataSet.Tables(0).Rows.Add(objDataRow)

                        'Add the Project
                        If Not objCatalogo.usp_Captura_NominaDet(Accion, objDataSet) Then
                            Throw New Exception("Falló Inserción de Detalle de Nómina")
                        Else
                            Inserta_NominaDet = True
                        End If
                    End If
                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using
        Next


        For i As Integer = 0 To DGrid1.RowCount - 1
            Using objCatalogo As New BCL.BCLNomina(GLB_ConStringNomSis)
                'Get a new Project DataSet
                Try
                    '' Buscar si existe ya el registro.. 
                    If Val(DGrid1.Rows(i).Cells("idpercdeduc").Value) <> 0 Then
                        If ups_ExisteNominaDet(DGrid1.Rows(i).Cells("idpercdeduc").Value, DGrid1.Rows(i).Cells("idrepetitivo").Value) = True Then
                            Accion = 2
                        Else
                            Accion = 1
                        End If

                        objDataSet = objCatalogo.Inserta_NominaDet  'INSERTA NUEVO DATASET
                        'Initialize a datarow object from the Project DataSet
                        Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow
                        objDataRow.Item("idperiodo") = IdPeriodoB
                        objDataRow.Item("tiponom") = TipoNomB
                        objDataRow.Item("idempleado") = idEmpleadoB
                        objDataRow.Item("idpercdeduc") = DGrid1.Rows(i).Cells("idpercdeduc").Value
                        objDataRow.Item("idrepetitivo") = DGrid1.Rows(i).Cells("idrepetitivo").Value
                        objDataRow.Item("unidades") = DGrid1.Rows(i).Cells("unidades").Value
                        objDataRow.Item("impgrav") = DGrid1.Rows(i).Cells("impgrav").Value
                        objDataRow.Item("impexento") = DGrid1.Rows(i).Cells("impexento").Value
                        objDataRow.Item("usuario") = GLB_Usuario
                        objDataRow.Item("usumodif") = GLB_Usuario
                        objDataRow.Item("fummodif") = Date.Now

                        'Add the DataRow to the DataSet
                        objDataSet.Tables(0).Rows.Add(objDataRow)

                        'Add the Project
                        If Not objCatalogo.usp_Captura_NominaDet(Accion, objDataSet) Then
                            Throw New Exception("Falló Inserción de Detalle de Nómina")
                        Else
                            Inserta_NominaDet = True
                        End If
                    End If
                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using
        Next
    End Function

    Private Sub DGrid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGrid.KeyDown

        Try
            If Not (Estatus <> "A" And Btn_Aceptar.Enabled = False) Then Exit Sub


            If (e.KeyCode = 46) Then

                If MessageBox.Show("Estas seguro de eliminar el registro del detalle de nómina ?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                    If (DGrid.CurrentCell.RowIndex) <> DGrid.Rows.Count - 1 Then
                        Call usp_EliminarNominaDet(IdPeriodoB, Mid(Txt_TipoNom.Text, 1, 1), idEmpleadoB, DGrid.Rows(DGrid.CurrentCell.RowIndex).Cells("idpercdeduc").Value)
                        DGrid.Rows.RemoveAt(DGrid.CurrentCell.RowIndex)
                        Call Totalizado(DGrid, DGrid1)
                    End If
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ImprimirReciboBono()
        'mreyes 01/Septiembre/2012 07:12 p.m.
        Try
            Dim myForm As New frmReportsBrowser
            Dim Sw_Mas14 As Boolean = False
            Dim Cont As Integer = 0


            Dim Sw_Imprimir As Boolean = False


            myForm.objDataSetReciboBono = GenerarDSReciboBono()



            myForm.ReportIndex = 5   'CUANDO SE GENERA LA PRIMERA VEZ nosotros .. el 1 es el proveedor , EL 3 ES EL DE CEDI


            myForm.Show()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub DGrid1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid1.CellEndEdit
        Try
            'mreyes 19/Julio/2012 11:32 a.m.

            Dim columna As Integer = DGrid1.CurrentCell.ColumnIndex
            Dim renglon As Integer = DGrid1.CurrentCell.RowIndex


            If columna = 2 Then


                Using objMySqlGral As New BCL.BCLCatalogoPercDeduc(GLB_ConStringNomSis)
                    Try
                        objDataSet = objMySqlGral.usp_PpalCatalogoPercDeduc(0, DGrid1.Rows(renglon).Cells("clave").Value, "", "", "", "", "", "", "")
                        If objDataSet.Tables(0).Rows.Count > 0 Then
                            DGrid1.Rows(renglon).Cells("descripc").Value = objDataSet.Tables(0).Rows(0).Item("DescripC").ToString
                            DGrid1.Rows(renglon).Cells("clave").Value = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                            DGrid1.Rows(renglon).Cells("idpercdeduc").Value = objDataSet.Tables(0).Rows(0).Item("idpercdeduc").ToString
                            DGrid1.Rows(renglon).Cells("idrepetitivo").Value = "0"
                            DGrid1.Rows(renglon).Cells("impgrav").Value = "0"
                            DGrid1.Rows(renglon).Cells("impexento").Value = "0"
                        Else
                            Call CargarFormaConsulta(renglon)
                        End If


                    Catch ExceptionErr As Exception
                        MessageBox.Show(ExceptionErr.Message.ToString)
                    End Try
                End Using
            End If
            If columna = 3 Then
                '' el idpercde3duc 2 es la asistencia. 
                'no se puede modificar un 4 que es subsidio.. 
                '2 es salario minimo
                '7 es falta 

                If DGrid1.Rows(renglon).Cells("idpercdeduc").Value = 7 Then

                    '' Calcular subsidio del empleado


                    For j As Integer = 0 To DGrid.RowCount - 1

                        If DGrid.Rows(j).Cells("idpercdeduc").Value = 4 Then
                            DGrid.Rows(j).Cells("impexento").Value = usp_TraerCalculaSubsidio(7 - DGrid1.Rows(renglon).Cells(3).Value)
                            Exit For
                        End If
                    Next
                    DGrid1.Rows(renglon).Cells("impexento").Value = Txt_SDiario.Text * DGrid1.Rows(renglon).Cells(3).Value
                End If
                If DGrid1.Rows(renglon).Cells("idpercdeduc").Value = 10 Then
                    ' sdiarioC * 10/100*(asistenciaV - FaltaV);
                    ''' ES RETARDO
                    Dim Asistencia As Integer = 0
                    Dim Falta As Integer = 0
                    For J As Integer = 0 To DGrid.RowCount - 1
                        If DGrid.Rows(J).Cells("idpercdeduc").Value = 15 Or DGrid.Rows(J).Cells("idpercdeduc").Value = 8 Then
                            Asistencia = DGrid.Rows(J).Cells(3).Value
                            Exit For
                        End If
                    Next
                    For J As Integer = 0 To DGrid1.RowCount - 1
                        If DGrid1.Rows(J).Cells("idpercdeduc").Value = 7 Then
                            Falta = DGrid1.Rows(J).Cells(3).Value
                            Exit For
                        End If
                    Next
                    DGrid1.Rows(renglon).Cells("impexento").Value = Format(Txt_SDiario.Text * 10 / 100 * (Asistencia - Falta), "n2")
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Function GenerarDSReciboBono() As DSReciboBono
        'mreyes 01/Septiembre/2012 07:12 p.m.
        Try
            '' Dim objDataSet As New DtReciboBono
            Dim Columna As Integer = 0
            Dim Cont As Integer = 0


            GenerarDSReciboBono = New DSReciboBono


            With DGrid
                Cont = 0



                Dim objDataRow1 As Data.DataRow = GenerarDSReciboBono.Tables("Tbl_ReciboBono").NewRow


                objDataRow1.Item("Ren") = 1
                objDataRow1.Item("idempleado") = idEmpleadoB
                objDataRow1.Item("nombrecompleto") = Txt_Nombre.Text
                objDataRow1.Item("total") = pagob
                objDataRow1.Item("fechaini") = FechaIniB
                objDataRow1.Item("fechafin") = FechaFinB
                objDataRow1.Item("sucursal") = Txt_DescripSucursal.Text

                GenerarDSReciboBono.Tables("Tbl_ReciboBono").Rows.Add(objDataRow1)

            End With
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function
    Private Function usp_EliminarNominaDet(ByVal IdPeriodo As Integer, ByVal TipoNom As String, ByVal IdEmpleado As Integer, ByVal IdPerceDeduc As Integer) As Boolean
        'mreyes 03/Septiembre/2012 05:39 p.m.

        Using objNomina As New BCL.BCLNomina(GLB_ConStringNomSis)
            Try
                'Get the specific project selected in the ListView control
                usp_EliminarNominaDet = objNomina.usp_EliminarNominaDet(IdPeriodo, TipoNom, IdEmpleado, IdPerceDeduc)
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

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
    Private Sub DGrid1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGrid1.KeyDown
        Try
            If Not (Estatus <> "A" And Btn_Aceptar.Enabled = False) Then Exit Sub
            If (e.KeyCode = 46) Then

                If MessageBox.Show("Estas seguro de eliminar el registro del detalle de nómina ?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then

                    If (DGrid1.CurrentCell.RowIndex) <> DGrid1.Rows.Count - 1 Then
                        Call usp_EliminarNominaDet(IdPeriodoB, Mid(Txt_TipoNom.Text, 1, 1), idEmpleadoB, DGrid1.Rows(DGrid1.CurrentCell.RowIndex).Cells("idpercdeduc").Value)
                        DGrid1.Rows.RemoveAt(DGrid1.CurrentCell.RowIndex)
                        Call Totalizado(DGrid, DGrid1)

                    End If


                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Totalizado(ByVal DGrid As DataGridView, ByVal DGrid1 As DataGridView)
        Dim Total As Decimal = 0
        If DGrid.RowCount <> 1 Then
            Total = pub_SumarColumnaGrid(DGrid, 5, DGrid.RowCount - 1)
            Total = Total + pub_SumarColumnaGrid(DGrid, 6, DGrid.RowCount - 1)
        End If
        If DGrid1.RowCount <> 1 Then
            Total = Total + pub_SumarColumnaGrid(DGrid1, 5, DGrid1.RowCount - 1)
            Total = Total + pub_SumarColumnaGrid(DGrid1, 6, DGrid1.RowCount - 1)
        End If
        Lbl_Total.Text = "TOTAL: " & Format(Total, "c")
        pagob = Total
    End Sub

    Private Sub DGrid_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellValueChanged

    End Sub

    Private Sub Btn_Marcaje_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Marcaje.Click
        If pub_TienePermiso("MARCAJE") = False Then Exit Sub
        Dim myForm As New frmPpalMarcajes
        myForm.Sw_NoLimpiar = False
        myForm.IdEmpleadoB = idEmpleadoB
        myForm.SucursalB = Txt_Sucursal.Text
        myForm.FechaIniB = FechaIniB
        myForm.FechaFinB = FechaFinB
        '  myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub


    Private Sub DGrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DGrid.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub DGrid1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DGrid1.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub DGrid1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid1.CellContentClick

    End Sub

    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub

    Private Sub Pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub

    Private Sub Btn_PreNomina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_PreNomina.Click
        'If pub_TienePermiso("MARCAJE") = False Then Exit Sub
        Dim myForm As New frmPpalPreNomina
        'myForm.Sw_NoLimpiar = False
        myForm.IdEmpleadoB = idEmpleadoB
        myForm.SucursalB = Txt_Sucursal.Text
        myForm.InicioIniB = FechaIniB
        myForm.InicioFinB = FechaFinB
        '  myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub
End Class