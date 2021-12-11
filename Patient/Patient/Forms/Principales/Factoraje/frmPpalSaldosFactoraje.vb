Public Class frmPpalSaldosFactoraje
    'mreyes 22/Octubre/2014 06:13
    ' 1 = Saldos en factoraje.
    ' 2 = Saldos proveedor sin factoraje, pero que estan en factoraje.
    ' 3 = Saldos factoraje por banco



    Public Opcion As Integer = 0
    Dim NombreCol As String = ""
    Private objDataSet As Data.DataSet

    Dim ProveedorB As String
    Dim MarcaB As String
    Dim EjercicioB As Integer
    Dim ImportadosB As String

    Dim FecIni As Date = "1900-01-01"
    Dim FecFin As Date = "1900-01-01"

    Dim OpcionAnt As Integer = 0
    Dim Sw_Load As Boolean = True
    Dim Sw_NoRegistros As Boolean = False
    Dim Sw_Pintar As Boolean = False
    Public Sw_Reporte As Integer = 1
    Dim MesB As Integer = 0
    Dim AnioB As Integer = 0
    Dim IdBancoFactorajeB As Integer = 0
    Public TipoB As String = ""

 

    Private Sub frmPpalSaldoProveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        ' 1 = Saldos en factoraje.
        ' 2 = Saldos proveedor sin factoraje, pero que estan en factoraje.
        ' 3 = Saldos factoraje por banco

        If Sw_Reporte = 1 Then
            Me.Text = "Saldos Factoraje por Proveedor"
        ElseIf Sw_Reporte = 2 Then
            Me.Text = "Saldos Condición Proveedor,"
        ElseIf Sw_Reporte = 3 Then
            Me.Text = "Saldo Ejercido Factoraje"
            Lbl_Leyenda.Text = "Saldo Ejercido Factoraje\"
        ElseIf Sw_Reporte = 4 Then
            If TipoB = "" Then
                Me.Text = "Saldo Total por Proveedor"
                Me.Lbl_Leyenda.Text = "Saldo Total por Proveedor\"
            ElseIf TipoB = "PAGOUNICO" Then
                Me.Text = "Saldo Total por Proveedor PAGO UNICO"
                Me.Lbl_Leyenda.Text = "Saldo Total por Proveedor PAGO UNICO\"
            Else
                Me.Text = "Saldo Total por Proveedor PAGO DIFERIDO"
                Me.Lbl_Leyenda.Text = "Saldo Total por Proveedor PAGO DIFERIDO\"
            End If
        ElseIf Sw_Reporte = 5 Then
            Me.Text = "Proyección de Pagos Factoraje"
            Lbl_Leyenda.Text = "Proyección de Pagos Factoraje\"
        End If

        Txt_Ejercicio.Text = Year(GLB_FechaHoy) - 1
        AnioB = CInt(Txt_Ejercicio.Text)

        Call LimpiarBusqueda()

        Sw_Pintar = True
        Call RellenaGrid()
        'Sw_Load = False 
    End Sub

    Private Sub frmPpalSaldoProveedores_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Sw_NoRegistros = False Then Exit Sub
        'If Sw_Load = True Then
        '    Sw_Load = False
        'blnPrimero = True
        'InicializaGrid()
        'AgregarColumna()
        '    Call BarrerGrid()
        'End If
    End Sub

    Private Sub LimpiarBusqueda()
        ProveedorB = ""
        MarcaB = ""
        EjercicioB = CInt(Txt_Ejercicio.Text)
        ImportadosB = "0"
    End Sub

    Private Sub RellenaGrid()
        'mreyes 22/Octubre/2014 06:13 p.m.
        Using objSaldosProv As New BCL.BCLSaldosProv(GLB_ConStringCipSis)

            Try
                Me.Cursor = Cursors.WaitCursor
                DGrid.ReadOnly = True
                DGrid.DataSource = Nothing
                'Reporte 4, es proveedores totales.
                ' 3 y cinco son casi iguales solo por totalizado de factoraje

                If Opcion = 1 Or Opcion = 2 Then
                    If Sw_Reporte = 1 Then
                        objDataSet = objSaldosProv.usp_PpalSaldosFactoraje(Opcion, ProveedorB, MarcaB, EjercicioB)
                    ElseIf Sw_Reporte = 2 Then
                        objDataSet = objSaldosProv.usp_PpalSaldosFactorajeORI(Opcion, ProveedorB, MarcaB, EjercicioB)
                    ElseIf Sw_Reporte = 3 Then
                        objDataSet = objSaldosProv.usp_PpalSaldosFactorajeBANCOEjercido(Opcion, ProveedorB, MarcaB, EjercicioB)
                    ElseIf Sw_Reporte = 5 Then
                        objDataSet = objSaldosProv.usp_PpalSaldosFactorajeBANCO(Opcion, ProveedorB, MarcaB, EjercicioB)
                    ElseIf Sw_Reporte = 4 Then
                        
                        objDataSet = objSaldosProv.usp_PpalSaldosProvORI(Opcion, ProveedorB, MarcaB, EjercicioB, TipoB)


                    End If


                ElseIf Opcion = 3 Then 'dia
                    If Sw_Reporte = 3 Then
                        ' Es de banco
                        objDataSet = objSaldosProv.usp_PpalSaldosFactorajeDIAEjercido(FecIni, FecFin, IdBancoFactorajeB, ProveedorB, MarcaB, EjercicioB)
                    ElseIf Sw_Reporte = 5 Then
                        objDataSet = objSaldosProv.usp_PpalSaldosFactorajeDIA(FecIni, FecFin, IdBancoFactorajeB, ProveedorB, MarcaB, EjercicioB)
                    ElseIf Sw_Reporte = 4 Then

                        If TipoB = "PAGODIF" Then
                            objDataSet = objSaldosProv.usp_PpalSaldosProvDIAdIFERIDOS(FecIni, FecFin, IdBancoFactorajeB, ProveedorB, MarcaB, EjercicioB, TipoB)
                        Else
                            objDataSet = objSaldosProv.usp_PpalSaldosProvDIA(FecIni, FecFin, IdBancoFactorajeB, ProveedorB, MarcaB, EjercicioB, TipoB)
                        End If
                    Else
                        objDataSet = objSaldosProv.usp_TraerFactSaldosFactoraje(1, ProveedorB, MarcaB, FecIni, FecFin, ImportadosB)
                    End If
                ElseIf Opcion = 4 Then
                    If Sw_Reporte = 4 Then
                        If TipoB = "PAGODIF" Then
                            objDataSet = objSaldosProv.usp_TraerFactSaldosProvORIDiferidos(1, ProveedorB, MarcaB, FecIni, FecFin, "", TipoB)
                        Else

                            objDataSet = objSaldosProv.usp_TraerFactSaldosProvORI(1, ProveedorB, MarcaB, FecIni, FecFin, "", TipoB)
                        End If
                    ElseIf Sw_Reporte = 3 Then

                        objDataSet = objSaldosProv.usp_TraerFactSaldosFactorajeEjercido(1, ProveedorB, MarcaB, FecIni, FecFin, ImportadosB)
                    ElseIf Sw_Reporte = 5 Then
                        objDataSet = objSaldosProv.usp_TraerFactSaldosFactoraje(1, ProveedorB, MarcaB, FecIni, FecFin, ImportadosB)
                    End If

                    ElseIf Opcion = 5 Then

                    If Sw_Reporte = 4 Then
                        If TipoB = "PAGODIF" Then
                            objDataSet = objSaldosProv.usp_TraerFactSaldosProvORIDiferidos(2, ProveedorB, MarcaB, FecIni, FecFin, "", TipoB)
                        ElseIf TipoB = "PAGOUNICO" Then
                            objDataSet = objSaldosProv.usp_TraerFactSaldosProvORI(2, ProveedorB, MarcaB, FecIni, FecFin, "", TipoB)
                        End If
                    ElseIf Sw_Reporte = 3 Then

                        objDataSet = objSaldosProv.usp_TraerFactSaldosFactorajeEjercido(2, ProveedorB, MarcaB, FecIni, FecFin, ImportadosB)
                    ElseIf Sw_Reporte = 5 Then
                        objDataSet = objSaldosProv.usp_TraerFactSaldosFactoraje(2, ProveedorB, MarcaB, FecIni, FecFin, ImportadosB)
                    End If

                    End If


                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section 

                    DGrid.DataSource = objDataSet.Tables(0)
                    'If Sw_Load = False Then
                    InicializaGrid()
                    'End If
                    'LimpiarBusqueda()
                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True
                    Sw_NoRegistros = True
                    Sw_Pintar = True
                    'Call Colores()
                Else
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron registros para el Ejercicio ingresado. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                    'Txt_Ejercicio.Text = ""
                    Txt_Ejercicio.Focus()
                End If
                Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Sub InicializaGrid()
        'mreyes 22/OCtubre/2014 06:14 p.m.
        Try


            If Opcion = 1 Then 'proveedor

                Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
                Dim row As DataRow = dt.NewRow()

                row("raz_soc") = "TOTAL: "
                row("ejercicio") = pub_SumarColumnaGrid(DGrid, 3, DGrid.RowCount - 1)
                row("saldoact") = pub_SumarColumnaGrid(DGrid, 4, DGrid.RowCount - 1)
                row("enero") = pub_SumarColumnaGrid(DGrid, 5, DGrid.RowCount - 1)
                row("febrero") = pub_SumarColumnaGrid(DGrid, 6, DGrid.RowCount - 1)
                row("marzo") = pub_SumarColumnaGrid(DGrid, 7, DGrid.RowCount - 1)
                row("abril") = pub_SumarColumnaGrid(DGrid, 8, DGrid.RowCount - 1)
                row("mayo") = pub_SumarColumnaGrid(DGrid, 9, DGrid.RowCount - 1)
                row("junio") = pub_SumarColumnaGrid(DGrid, 10, DGrid.RowCount - 1)
                row("julio") = pub_SumarColumnaGrid(DGrid, 11, DGrid.RowCount - 1)
                row("agosto") = pub_SumarColumnaGrid(DGrid, 12, DGrid.RowCount - 1)
                row("septiembre") = pub_SumarColumnaGrid(DGrid, 13, DGrid.RowCount - 1)
                row("octubre") = pub_SumarColumnaGrid(DGrid, 14, DGrid.RowCount - 1)
                row("noviembre") = pub_SumarColumnaGrid(DGrid, 15, DGrid.RowCount - 1)
                row("diciembre") = pub_SumarColumnaGrid(DGrid, 16, DGrid.RowCount - 1)

                row("enero1") = pub_SumarColumnaGrid(DGrid, 17, DGrid.RowCount - 1)
                row("febrero1") = pub_SumarColumnaGrid(DGrid, 18, DGrid.RowCount - 1)
                row("marzo1") = pub_SumarColumnaGrid(DGrid, 19, DGrid.RowCount - 1)
                row("abril1") = pub_SumarColumnaGrid(DGrid, 20, DGrid.RowCount - 1)
                row("mayo1") = pub_SumarColumnaGrid(DGrid, 21, DGrid.RowCount - 1)
                row("junio1") = pub_SumarColumnaGrid(DGrid, 22, DGrid.RowCount - 1)
                row("julio1") = pub_SumarColumnaGrid(DGrid, 23, DGrid.RowCount - 1)
                row("agosto1") = pub_SumarColumnaGrid(DGrid, 24, DGrid.RowCount - 1)
                row("septiembre1") = pub_SumarColumnaGrid(DGrid, 25, DGrid.RowCount - 1)
                row("octubre1") = pub_SumarColumnaGrid(DGrid, 26, DGrid.RowCount - 1)
                row("noviembre1") = pub_SumarColumnaGrid(DGrid, 27, DGrid.RowCount - 1)
                row("diciembre1") = pub_SumarColumnaGrid(DGrid, 28, DGrid.RowCount - 1)

                row("enero2") = pub_SumarColumnaGrid(DGrid, 29, DGrid.RowCount - 1)
                row("febrero2") = pub_SumarColumnaGrid(DGrid, 30, DGrid.RowCount - 1)
                row("marzo2") = pub_SumarColumnaGrid(DGrid, 31, DGrid.RowCount - 1)
                row("abril2") = pub_SumarColumnaGrid(DGrid, 32, DGrid.RowCount - 1)
                row("mayo2") = pub_SumarColumnaGrid(DGrid, 33, DGrid.RowCount - 1)
                row("junio2") = pub_SumarColumnaGrid(DGrid, 34, DGrid.RowCount - 1)
                row("julio2") = pub_SumarColumnaGrid(DGrid, 35, DGrid.RowCount - 1)
                row("agosto2") = pub_SumarColumnaGrid(DGrid, 36, DGrid.RowCount - 1)
                row("septiembre2") = pub_SumarColumnaGrid(DGrid, 37, DGrid.RowCount - 1)
                row("octubre2") = pub_SumarColumnaGrid(DGrid, 38, DGrid.RowCount - 1)
                row("noviembre2") = pub_SumarColumnaGrid(DGrid, 39, DGrid.RowCount - 1)
                row("diciembre2") = pub_SumarColumnaGrid(DGrid, 40, DGrid.RowCount - 1)



                dt.Rows.InsertAt(row, 0)
                DGrid.DataSource = dt

                DGrid.RowHeadersVisible = False
                DGrid.Columns("idproveedor").HeaderText = "IdProv" 'oculto
                DGrid.Columns("proveedor").HeaderText = "Proveedor"
                DGrid.Columns("raz_soc").HeaderText = "Razón Social"
                DGrid.Columns("ejercicio").HeaderText = "Disponible" 'oculto
                If Sw_Reporte = 3 Then
                    DGrid.Columns("saldoact").HeaderText = "Ejercido"
                Else
                    DGrid.Columns("saldoact").HeaderText = "Saldo Actual"
                End If

                AnioB = CInt(Txt_Ejercicio.Text)


                DGrid.Columns("enero").HeaderText = "Enero" & AnioB
                DGrid.Columns("febrero").HeaderText = "Febrero" & AnioB
                DGrid.Columns("marzo").HeaderText = "Marzo" & AnioB
                DGrid.Columns("abril").HeaderText = "Abril" & AnioB
                DGrid.Columns("mayo").HeaderText = "Mayo" & AnioB
                DGrid.Columns("junio").HeaderText = "Junio" & AnioB
                DGrid.Columns("julio").HeaderText = "Julio" & AnioB
                DGrid.Columns("agosto").HeaderText = "Agosto" & AnioB
                DGrid.Columns("septiembre").HeaderText = "Septiembre" & AnioB
                DGrid.Columns("octubre").HeaderText = "Octubre" & AnioB
                DGrid.Columns("noviembre").HeaderText = "Noviembre" & AnioB
                DGrid.Columns("diciembre").HeaderText = "Diciembre" & AnioB



                '''''

                DGrid.Columns("enero1").HeaderText = "Enero" & AnioB + 1
                DGrid.Columns("febrero1").HeaderText = "Febrero" & AnioB + 1
                DGrid.Columns("marzo1").HeaderText = "Marzo" & AnioB + 1
                DGrid.Columns("abril1").HeaderText = "Abril" & AnioB + 1
                DGrid.Columns("mayo1").HeaderText = "Mayo" & AnioB + 1
                DGrid.Columns("junio1").HeaderText = "Junio" & AnioB + 1
                DGrid.Columns("julio1").HeaderText = "Julio" & AnioB + 1
                DGrid.Columns("agosto1").HeaderText = "Agosto" & AnioB + 1
                DGrid.Columns("septiembre1").HeaderText = "Septiembre" & AnioB + 1
                DGrid.Columns("octubre1").HeaderText = "Octubre" & AnioB + 1
                DGrid.Columns("noviembre1").HeaderText = "Noviembre" & AnioB + 1
                DGrid.Columns("diciembre1").HeaderText = "Diciembre" & AnioB + 1



                '''''

                DGrid.Columns("enero2").HeaderText = "Enero" & AnioB + 2
                DGrid.Columns("febrero2").HeaderText = "Febrero" & AnioB + 2
                DGrid.Columns("marzo2").HeaderText = "Marzo" & AnioB + 2
                DGrid.Columns("abril2").HeaderText = "Abril" & AnioB + 2
                DGrid.Columns("mayo2").HeaderText = "Mayo" & AnioB + 2
                DGrid.Columns("junio2").HeaderText = "Junio" & AnioB + 2
                DGrid.Columns("julio2").HeaderText = "Julio" & AnioB + 2
                DGrid.Columns("agosto2").HeaderText = "Agosto" & AnioB + 2
                DGrid.Columns("septiembre2").HeaderText = "Septiembre" & AnioB + 2
                DGrid.Columns("octubre2").HeaderText = "Octubre" & AnioB + 2
                DGrid.Columns("noviembre2").HeaderText = "Noviembre" & AnioB + 2
                DGrid.Columns("diciembre2").HeaderText = "Diciembre" & AnioB + 2



                DGrid.Columns("proveedor").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                DGrid.Columns("raz_soc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                DGrid.Columns("ejercicio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("saldoact").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DGrid.Columns("enero").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("febrero").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("marzo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("abril").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("mayo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("junio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("julio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("agosto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("septiembre").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("octubre").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("noviembre").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("diciembre").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


                DGrid.Columns("enero1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("febrero1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("marzo1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("abril1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("mayo1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("junio1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("julio1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("agosto1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("septiembre1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("octubre1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("noviembre1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("diciembre1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


                DGrid.Columns("enero2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("febrero2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("marzo2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("abril2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("mayo2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("junio2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("julio2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("agosto2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("septiembre2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("octubre2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("noviembre2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("diciembre2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight



                DGrid.Columns("ejercicio").DefaultCellStyle.Format = "c"
                DGrid.Columns("saldoact").DefaultCellStyle.Format = "c"

                DGrid.Columns("enero").DefaultCellStyle.Format = "c"
                DGrid.Columns("febrero").DefaultCellStyle.Format = "c"
                DGrid.Columns("marzo").DefaultCellStyle.Format = "c"
                DGrid.Columns("abril").DefaultCellStyle.Format = "c"
                DGrid.Columns("mayo").DefaultCellStyle.Format = "c"
                DGrid.Columns("junio").DefaultCellStyle.Format = "c"
                DGrid.Columns("julio").DefaultCellStyle.Format = "c"
                DGrid.Columns("agosto").DefaultCellStyle.Format = "c"
                DGrid.Columns("septiembre").DefaultCellStyle.Format = "c"
                DGrid.Columns("octubre").DefaultCellStyle.Format = "c"
                DGrid.Columns("noviembre").DefaultCellStyle.Format = "c"
                DGrid.Columns("diciembre").DefaultCellStyle.Format = "c"


                DGrid.Columns("enero1").DefaultCellStyle.Format = "c"
                DGrid.Columns("febrero1").DefaultCellStyle.Format = "c"
                DGrid.Columns("marzo1").DefaultCellStyle.Format = "c"
                DGrid.Columns("abril1").DefaultCellStyle.Format = "c"
                DGrid.Columns("mayo1").DefaultCellStyle.Format = "c"
                DGrid.Columns("junio1").DefaultCellStyle.Format = "c"
                DGrid.Columns("julio1").DefaultCellStyle.Format = "c"
                DGrid.Columns("agosto1").DefaultCellStyle.Format = "c"
                DGrid.Columns("septiembre1").DefaultCellStyle.Format = "c"
                DGrid.Columns("octubre1").DefaultCellStyle.Format = "c"
                DGrid.Columns("noviembre1").DefaultCellStyle.Format = "c"
                DGrid.Columns("diciembre1").DefaultCellStyle.Format = "c"



                DGrid.Columns("enero2").DefaultCellStyle.Format = "c"
                DGrid.Columns("febrero2").DefaultCellStyle.Format = "c"
                DGrid.Columns("marzo2").DefaultCellStyle.Format = "c"
                DGrid.Columns("abril2").DefaultCellStyle.Format = "c"
                DGrid.Columns("mayo2").DefaultCellStyle.Format = "c"
                DGrid.Columns("junio2").DefaultCellStyle.Format = "c"
                DGrid.Columns("julio2").DefaultCellStyle.Format = "c"
                DGrid.Columns("agosto2").DefaultCellStyle.Format = "c"
                DGrid.Columns("septiembre2").DefaultCellStyle.Format = "c"
                DGrid.Columns("octubre2").DefaultCellStyle.Format = "c"
                DGrid.Columns("noviembre2").DefaultCellStyle.Format = "c"
                DGrid.Columns("diciembre2").DefaultCellStyle.Format = "c"

                DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

                'For i As Integer = 0 To 4
                '    DGrid.Columns(i).DefaultCellStyle.BackColor = Color.PowderBlue
                '    DGrid.Columns(i).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                'Next

                DGrid.Columns("saldoact").Frozen = True
                DGrid.Columns("idproveedor").Visible = False
                'DGrid.Columns("ejercicio").Visible = False

                'DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
                'DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                If Sw_Reporte = 1 Then
                    'Factoraje
                    For i As Integer = 0 To 4
                        DGrid.Columns(i).DefaultCellStyle.BackColor = Color.LightGreen
                        DGrid.Columns(i).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                    Next
                    DGrid.Rows(0).DefaultCellStyle.BackColor = Color.LightGreen
                    DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)


                    DGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGreen
                ElseIf Sw_Reporte = 2 Then
                    For i As Integer = 0 To 4
                        DGrid.Columns(i).DefaultCellStyle.BackColor = Color.HotPink
                        DGrid.Columns(i).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                    Next
                    DGrid.Rows(0).DefaultCellStyle.BackColor = Color.HotPink
                    DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                    DGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.HotPink
                    DGrid.Columns("ejercicio").Visible = False
                ElseIf Sw_Reporte = 4 Then
                    If TipoB = "" Then
                        For i As Integer = 0 To 4
                            DGrid.Columns(i).DefaultCellStyle.BackColor = Color.Orange
                            DGrid.Columns(i).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                        Next
                        DGrid.Rows(0).DefaultCellStyle.BackColor = Color.Orange
                        DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                        DGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange
                        DGrid.Columns("ejercicio").Visible = False
                    ElseIf TipoB = "PAGOUNICO" Then
                        For i As Integer = 0 To 4
                            DGrid.Columns(i).DefaultCellStyle.BackColor = Color.Lavender
                            DGrid.Columns(i).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                        Next
                        DGrid.Rows(0).DefaultCellStyle.BackColor = Color.Lavender
                        DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                        DGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender
                        DGrid.Columns("ejercicio").Visible = False
                    ElseIf TipoB = "PAGODIF" Then
                        For i As Integer = 0 To 4
                            DGrid.Columns(i).DefaultCellStyle.BackColor = Color.Bisque
                            DGrid.Columns(i).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                        Next
                        DGrid.Rows(0).DefaultCellStyle.BackColor = Color.Bisque
                        DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                        DGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.Bisque
                        DGrid.Columns("ejercicio").Visible = False
                    End If

                    ElseIf Sw_Reporte = 3 Or Sw_Reporte = 5 Then
                        For i As Integer = 0 To 4
                            DGrid.Columns(i).DefaultCellStyle.BackColor = Color.LightYellow
                            DGrid.Columns(i).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                        Next
                        DGrid.Rows(0).DefaultCellStyle.BackColor = Color.LightYellow
                        DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                        DGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.LightYellow
                        DGrid.Columns("idproveedor").Visible = False
                        DGrid.Columns("proveedor").Visible = False
                        DGrid.Columns("raz_soc").HeaderText = "Banco"


                    End If

                    For i As Integer = 5 To DGrid.ColumnCount - 1
                        If DGrid.Rows(0).Cells(i).Value = 0 Then
                            DGrid.Columns(i).Visible = False
                        End If
                    Next

                ElseIf Opcion = 2 Then 'marca


                    Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
                    Dim row As DataRow = dt.NewRow()

                    row("raz_soc") = "TOTAL: "
                    row("saldoact") = pub_SumarColumnaGrid(DGrid, 5, DGrid.RowCount - 1)
                    row("saldoant") = pub_SumarColumnaGrid(DGrid, 6, DGrid.RowCount - 1)
                    row("enero") = pub_SumarColumnaGrid(DGrid, 7, DGrid.RowCount - 1)
                    row("febrero") = pub_SumarColumnaGrid(DGrid, 8, DGrid.RowCount - 1)
                    row("marzo") = pub_SumarColumnaGrid(DGrid, 9, DGrid.RowCount - 1)
                    row("abril") = pub_SumarColumnaGrid(DGrid, 10, DGrid.RowCount - 1)
                    row("mayo") = pub_SumarColumnaGrid(DGrid, 11, DGrid.RowCount - 1)
                    row("junio") = pub_SumarColumnaGrid(DGrid, 12, DGrid.RowCount - 1)
                    row("julio") = pub_SumarColumnaGrid(DGrid, 13, DGrid.RowCount - 1)
                    row("agosto") = pub_SumarColumnaGrid(DGrid, 14, DGrid.RowCount - 1)
                    row("septiembre") = pub_SumarColumnaGrid(DGrid, 15, DGrid.RowCount - 1)
                    row("octubre") = pub_SumarColumnaGrid(DGrid, 16, DGrid.RowCount - 1)
                    row("noviembre") = pub_SumarColumnaGrid(DGrid, 17, DGrid.RowCount - 1)
                    row("diciembre") = pub_SumarColumnaGrid(DGrid, 18, DGrid.RowCount - 1)
                    row("saldopos") = pub_SumarColumnaGrid(DGrid, 19, DGrid.RowCount - 1)

                    dt.Rows.InsertAt(row, 0)
                    DGrid.DataSource = dt

                    DGrid.RowHeadersVisible = False
                    DGrid.Columns("idproveedor").HeaderText = "IdProv" 'oculto
                    DGrid.Columns("proveedor").HeaderText = "Proveedor"
                    DGrid.Columns("raz_soc").HeaderText = "Razón Social"
                    DGrid.Columns("marca").HeaderText = "Marca"
                    DGrid.Columns("ejercicio").HeaderText = "Ejercicio" 'oculto
                    DGrid.Columns("saldoact").HeaderText = "Saldo"
                    DGrid.Columns("saldoant").HeaderText = "Antes de Enero"
                    DGrid.Columns("enero").HeaderText = "Enero"
                    DGrid.Columns("febrero").HeaderText = "Febrero"
                    DGrid.Columns("marzo").HeaderText = "Marzo"
                    DGrid.Columns("abril").HeaderText = "Abril"
                    DGrid.Columns("mayo").HeaderText = "Mayo"
                    DGrid.Columns("junio").HeaderText = "Junio"
                    DGrid.Columns("julio").HeaderText = "Julio"
                    DGrid.Columns("agosto").HeaderText = "Agosto"
                    DGrid.Columns("septiembre").HeaderText = "Septiembre"
                    DGrid.Columns("octubre").HeaderText = "Octubre"
                    DGrid.Columns("noviembre").HeaderText = "Noviembre"
                    DGrid.Columns("diciembre").HeaderText = "Diciembre"
                    DGrid.Columns("saldopos").HeaderText = "Después de Diciembre"

                    DGrid.Columns("proveedor").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns("raz_soc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DGrid.Columns("marca").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                    DGrid.Columns("saldoact").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGrid.Columns("saldoant").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGrid.Columns("enero").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGrid.Columns("febrero").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGrid.Columns("marzo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGrid.Columns("abril").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGrid.Columns("mayo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGrid.Columns("junio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGrid.Columns("julio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGrid.Columns("agosto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGrid.Columns("septiembre").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGrid.Columns("octubre").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGrid.Columns("noviembre").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGrid.Columns("diciembre").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGrid.Columns("saldopos").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    DGrid.Columns("saldoact").DefaultCellStyle.Format = "c"
                    DGrid.Columns("saldoant").DefaultCellStyle.Format = "c"
                    DGrid.Columns("enero").DefaultCellStyle.Format = "c"
                    DGrid.Columns("febrero").DefaultCellStyle.Format = "c"
                    DGrid.Columns("marzo").DefaultCellStyle.Format = "c"
                    DGrid.Columns("abril").DefaultCellStyle.Format = "c"
                    DGrid.Columns("mayo").DefaultCellStyle.Format = "c"
                    DGrid.Columns("junio").DefaultCellStyle.Format = "c"
                    DGrid.Columns("julio").DefaultCellStyle.Format = "c"
                    DGrid.Columns("agosto").DefaultCellStyle.Format = "c"
                    DGrid.Columns("septiembre").DefaultCellStyle.Format = "c"
                    DGrid.Columns("octubre").DefaultCellStyle.Format = "c"
                    DGrid.Columns("noviembre").DefaultCellStyle.Format = "c"
                    DGrid.Columns("diciembre").DefaultCellStyle.Format = "c"
                    DGrid.Columns("saldopos").DefaultCellStyle.Format = "c"

                    DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

                    For i As Integer = 0 To 5
                        DGrid.Columns(i).DefaultCellStyle.BackColor = Color.PowderBlue
                        DGrid.Columns(i).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                    Next

                    DGrid.Columns("saldoact").Frozen = True
                    DGrid.Columns("idproveedor").Visible = False
                    DGrid.Columns("ejercicio").Visible = False

                    DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
                    DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)


                ElseIf Opcion = 3 Then
                ' POR DIA
                '

                    Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
                    Dim row As DataRow = dt.NewRow()

                    row("dia") = "TOTAL: "
                    row("TOTAL") = pub_SumarColumnaGrid(DGrid, 2, DGrid.RowCount - 1)
                    dt.Rows.InsertAt(row, 0)
                    DGrid.DataSource = dt
                    DGrid.Columns("fecha").HeaderText = "Vence Banco" 'oculto
                    DGrid.Columns("dia").HeaderText = "Día Semana"
                    DGrid.Columns("total").HeaderText = "Total Factoraje" 'oculto

                    DGrid.Columns("total").DefaultCellStyle.Format = "c"
                    DGrid.Columns("total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


                    If Sw_Reporte = 1 Then
                    ElseIf Sw_Reporte = 2 Then
                    ElseIf Sw_Reporte = 3 Or Sw_Reporte = 5 Then
                        'LightYellow
                        DGrid.Rows(0).DefaultCellStyle.BackColor = Color.LightYellow
                        DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                        DGrid.Columns(0).DefaultCellStyle.BackColor = Color.LightYellow
                        DGrid.Columns(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                ElseIf Sw_Reporte = 4 Then
                    If TipoB = "" Then
                        'LightYellow
                        DGrid.Rows(0).DefaultCellStyle.BackColor = Color.Orange
                        DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                        DGrid.Columns(0).DefaultCellStyle.BackColor = Color.Orange
                        DGrid.Columns(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                    ElseIf TipoB = "PAGOUNICO" Then
                        'LightYellow
                        DGrid.Rows(0).DefaultCellStyle.BackColor = Color.Lavender
                        DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                        DGrid.Columns(0).DefaultCellStyle.BackColor = Color.Lavender
                        DGrid.Columns(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                    ElseIf TipoB = "PAGODIF" Then
                        'LightYellow
                        DGrid.Rows(0).DefaultCellStyle.BackColor = Color.Bisque
                        DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                        DGrid.Columns(0).DefaultCellStyle.BackColor = Color.Bisque
                        DGrid.Columns(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                    End If


                    End If
                ElseIf Opcion = 4 Then
                    ' POR PROVEEDOR
                    Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
                    Dim row As DataRow = dt.NewRow()

                    row("proveedor") = "TOTAL: "
                    row("pares") = pub_SumarColumnaGrid(DGrid, 13, DGrid.RowCount - 1)
                    row("subtotal") = pub_SumarColumnaGrid(DGrid, 14, DGrid.RowCount - 1)
                    row("gastos") = pub_SumarColumnaGrid(DGrid, 15, DGrid.RowCount - 1)
                    row("impuesto") = pub_SumarColumnaGrid(DGrid, 16, DGrid.RowCount - 1)
                    row("cargo") = pub_SumarColumnaGrid(DGrid, 17, DGrid.RowCount - 1)
                    row("credito") = pub_SumarColumnaGrid(DGrid, 18, DGrid.RowCount - 1)
                    row("descuento") = pub_SumarColumnaGrid(DGrid, 19, DGrid.RowCount - 1)
                    row("aportaciones") = pub_SumarColumnaGrid(DGrid, 20, DGrid.RowCount - 1)
                    row("importe") = pub_SumarColumnaGrid(DGrid, 21, DGrid.RowCount - 1)
                    row("tiiefactoraje") = pub_SumarColumnaGrid(DGrid, 22, DGrid.RowCount - 1)
                    row("totalfactoraje") = pub_SumarColumnaGrid(DGrid, 23, DGrid.RowCount - 1)


                    dt.Rows.InsertAt(row, 0)
                    DGrid.DataSource = dt

                    DGrid.RowHeadersVisible = False

                    DGrid.Columns("status").Visible = False
                    DGrid.Columns("dias").Visible = False
                    DGrid.Columns("dev").Visible = False

                    DGrid.Columns("sucursal").HeaderText = "Sucursal" 'oculto
                    DGrid.Columns("factprov").HeaderText = "FactProv"
                    DGrid.Columns("idfolio").HeaderText = "IdFolio" 'oculto
                    DGrid.Columns("idfoliosuc").HeaderText = "Folio Bulto"
                    DGrid.Columns("marca").HeaderText = "Marca"
                    DGrid.Columns("referenc").HeaderText = "Referenc"
                    DGrid.Columns("status").HeaderText = "Estatus"
                    DGrid.Columns("fecha").HeaderText = "Fecha Factura"
                    DGrid.Columns("dias").HeaderText = "Días por Vencer"
                    DGrid.Columns("fecvenc").HeaderText = "Vence Proveedor"
                    DGrid.Columns("fecvencfact").HeaderText = "Vence Banco"

                    DGrid.Columns("dev").HeaderText = "Folio Devolución"
                    DGrid.Columns("proveedor").HeaderText = "Proveedor"
                    DGrid.Columns("pares").HeaderText = "Pares"
                    DGrid.Columns("subtotal").HeaderText = "SubTotal"
                    DGrid.Columns("gastos").HeaderText = "Gastos"
                    DGrid.Columns("impuesto").HeaderText = "Impuesto"
                    DGrid.Columns("cargo").HeaderText = "NCargo"
                    DGrid.Columns("credito").HeaderText = "NCredito"
                    DGrid.Columns("descuento").HeaderText = "Dscto"
                    DGrid.Columns("aportaciones").HeaderText = "Aportaciones"

                    DGrid.Columns("importe").HeaderText = "Total Factura"
                    DGrid.Columns("tiiefactoraje").HeaderText = "Interés"
                    DGrid.Columns("totalfactoraje").HeaderText = "Total Factoraje"


                    DGrid.Columns("sucursal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns("factprov").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns("marca").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns("referenc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns("idfolio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns("idfoliosuc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns("status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns("fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns("dias").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns("fecvenc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns("dev").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns("proveedor").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DGrid.Columns("pares").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns("subtotal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGrid.Columns("gastos").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGrid.Columns("impuesto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGrid.Columns("cargo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGrid.Columns("credito").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGrid.Columns("descuento").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGrid.Columns("aportaciones").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGrid.Columns("importe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    DGrid.Columns("tiiefactoraje").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGrid.Columns("totalfactoraje").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    DGrid.Columns("subtotal").DefaultCellStyle.Format = "c"
                    DGrid.Columns("gastos").DefaultCellStyle.Format = "c"
                    DGrid.Columns("impuesto").DefaultCellStyle.Format = "c"
                    DGrid.Columns("cargo").DefaultCellStyle.Format = "c"
                    DGrid.Columns("credito").DefaultCellStyle.Format = "c"
                    DGrid.Columns("descuento").DefaultCellStyle.Format = "c"
                    DGrid.Columns("aportaciones").DefaultCellStyle.Format = "c"
                    DGrid.Columns("importe").DefaultCellStyle.Format = "c"
                    DGrid.Columns("tiiefactoraje").DefaultCellStyle.Format = "c"
                    DGrid.Columns("totalfactoraje").DefaultCellStyle.Format = "c"


                DGrid.Columns("sucursal").Visible = False
                    DGrid.Columns("idfolio").Visible = False
                DGrid.Columns("idfoliosuc").Visible = False
                DGrid.Columns("referenc").Visible = False
                    DGrid.Columns("marca").Visible = False
                    DGrid.Columns("fecvenc").Visible = False
                    DGrid.Columns("fecha").Visible = False
                    DGrid.Columns("factprov").Visible = False
                    DGrid.Columns("fecvencfact").Visible = False



                    DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells



                    If Sw_Reporte = 1 Then
                    ElseIf Sw_Reporte = 2 Then
                    ElseIf Sw_Reporte = 3 Or Sw_Reporte = 5 Then
                        'LightYellow
                        For i As Integer = 0 To 3
                            DGrid.Columns(i).DefaultCellStyle.BackColor = Color.LightYellow
                            DGrid.Columns(i).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                        Next

                        DGrid.Rows(0).DefaultCellStyle.BackColor = Color.LightYellow
                        DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                    ElseIf Sw_Reporte = 4 Then

                        DGrid.Columns("totalfactoraje").Visible = False
                        DGrid.Columns("tiiefactoraje").Visible = False

                    End If
                ElseIf Opcion = 5 Then

                    Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
                    Dim row As DataRow = dt.NewRow()

                    row("proveedor") = "TOTAL: "
                    row("pares") = pub_SumarColumnaGrid(DGrid, 13, DGrid.RowCount - 1)
                    row("subtotal") = pub_SumarColumnaGrid(DGrid, 14, DGrid.RowCount - 1)
                    row("gastos") = pub_SumarColumnaGrid(DGrid, 15, DGrid.RowCount - 1)
                    row("impuesto") = pub_SumarColumnaGrid(DGrid, 16, DGrid.RowCount - 1)
                    row("cargo") = pub_SumarColumnaGrid(DGrid, 17, DGrid.RowCount - 1)
                    row("credito") = pub_SumarColumnaGrid(DGrid, 18, DGrid.RowCount - 1)
                    row("descuento") = pub_SumarColumnaGrid(DGrid, 19, DGrid.RowCount - 1)
                    row("aportaciones") = pub_SumarColumnaGrid(DGrid, 20, DGrid.RowCount - 1)
                    row("importe") = pub_SumarColumnaGrid(DGrid, 21, DGrid.RowCount - 1)
                    row("tiiefactoraje") = pub_SumarColumnaGrid(DGrid, 22, DGrid.RowCount - 1)
                    row("totalfactoraje") = pub_SumarColumnaGrid(DGrid, 23, DGrid.RowCount - 1)


                    dt.Rows.InsertAt(row, 0)
                    DGrid.DataSource = dt

                    DGrid.RowHeadersVisible = False

                'DGrid.Columns("status").Visible = False
                    DGrid.Columns("dias").Visible = False
                    DGrid.Columns("dev").Visible = False

                    DGrid.Columns("sucursal").HeaderText = "Sucursal" 'oculto
                    DGrid.Columns("factprov").HeaderText = "FactProv"
                    DGrid.Columns("idfolio").HeaderText = "IdFolio" 'oculto
                    DGrid.Columns("idfoliosuc").HeaderText = "Folio Bulto"
                    DGrid.Columns("marca").HeaderText = "Marca"
                    DGrid.Columns("referenc").HeaderText = "Referenc"
                    DGrid.Columns("status").HeaderText = "Estatus"
                    DGrid.Columns("fecha").HeaderText = "Fecha Factura"
                    DGrid.Columns("dias").HeaderText = "Días por Vencer"
                    DGrid.Columns("fecvenc").HeaderText = "Vence Proveedor"
                    DGrid.Columns("fecvencfact").HeaderText = "Vence Banco"

                    DGrid.Columns("dev").HeaderText = "Folio Devolución"
                    DGrid.Columns("proveedor").HeaderText = "Proveedor"
                    DGrid.Columns("pares").HeaderText = "Pares"
                    DGrid.Columns("subtotal").HeaderText = "SubTotal"
                    DGrid.Columns("gastos").HeaderText = "Gastos"
                    DGrid.Columns("impuesto").HeaderText = "Impuesto"
                    DGrid.Columns("cargo").HeaderText = "NCargo"
                    DGrid.Columns("credito").HeaderText = "NCredito"
                    DGrid.Columns("descuento").HeaderText = "Dscto"
                    DGrid.Columns("aportaciones").HeaderText = "Aportaciones"

                    DGrid.Columns("importe").HeaderText = "Total Factura"
                    DGrid.Columns("tiiefactoraje").HeaderText = "Interés"
                    DGrid.Columns("totalfactoraje").HeaderText = "Total Factoraje"


                    DGrid.Columns("sucursal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns("factprov").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns("marca").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns("referenc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns("idfolio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns("idfoliosuc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns("status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns("fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns("dias").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns("fecvenc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns("dev").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns("proveedor").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DGrid.Columns("pares").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns("subtotal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGrid.Columns("gastos").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGrid.Columns("impuesto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGrid.Columns("cargo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGrid.Columns("credito").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGrid.Columns("descuento").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGrid.Columns("aportaciones").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGrid.Columns("importe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    DGrid.Columns("tiiefactoraje").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGrid.Columns("totalfactoraje").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    DGrid.Columns("subtotal").DefaultCellStyle.Format = "c"
                    DGrid.Columns("gastos").DefaultCellStyle.Format = "c"
                    DGrid.Columns("impuesto").DefaultCellStyle.Format = "c"
                    DGrid.Columns("cargo").DefaultCellStyle.Format = "c"
                    DGrid.Columns("credito").DefaultCellStyle.Format = "c"
                    DGrid.Columns("descuento").DefaultCellStyle.Format = "c"
                    DGrid.Columns("aportaciones").DefaultCellStyle.Format = "c"
                    DGrid.Columns("importe").DefaultCellStyle.Format = "c"
                    DGrid.Columns("tiiefactoraje").DefaultCellStyle.Format = "c"
                    DGrid.Columns("totalfactoraje").DefaultCellStyle.Format = "c"


                '  DGrid.Columns("sucursal").Visible = False
                    DGrid.Columns("idfolio").Visible = False
                'DGrid.Columns("referenc").Visible = False
                    DGrid.Columns("idfolio").Visible = False
                'DGrid.Columns("idfoliosuc").Visible = False
                    DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells



                    If Sw_Reporte = 1 Then
                    ElseIf Sw_Reporte = 2 Then
                    ElseIf Sw_Reporte = 3 Or Sw_Reporte = 5 Then
                        'LightYellow
                        For i As Integer = 0 To 3
                            DGrid.Columns(i).DefaultCellStyle.BackColor = Color.LightYellow
                            DGrid.Columns(i).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                        Next

                        DGrid.Rows(0).DefaultCellStyle.BackColor = Color.LightYellow
                        DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                    ElseIf Sw_Reporte = 4 Then

                        DGrid.Columns("totalfactoraje").Visible = False
                        DGrid.Columns("tiiefactoraje").Visible = False
                        DGrid.Columns("fecvencfact").Visible = False
                    End If

                End If

                'COLORES




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

    Private Sub frmPpalPpalDetFactProv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub DGrid_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGrid.CellFormatting
        Try
            'Dim Sw_NoEntro As Boolean = False
            'If Opcion <> 3 Then Exit Sub

            'Dim DiasEntrega As Integer = 0
            'If Sw_Pintar = False Then Exit Sub
            ''If Opcion <> 1 Then Exit Sub

            'If Me.DGrid.Columns(e.ColumnIndex).Name <> "dias" Then Exit Sub
            'If e.RowIndex = DGrid.RowCount - 1 Then
            '    If Sw_Load = False Then
            '        Sw_Pintar = False
            '    End If
            '    Exit Sub
            'End If

            'If IsNothing(DGrid.Rows(e.RowIndex).Cells("dias").Value) Then Exit Sub
            'If IsDBNull(DGrid.Rows(e.RowIndex).Cells("dias").Value) Then Exit Sub


            'If DGrid.Rows(e.RowIndex).Cells("dias").Value < 0 Then
            '    DGrid.Rows(e.RowIndex).Cells("dias").Style.BackColor = Color.Red
            '    DGrid.Rows(e.RowIndex).Cells("dias").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            'End If

            'If DGrid.Rows(e.RowIndex).Cells("dev").Value <> "" Then
            '    DGrid.Rows(e.RowIndex).Cells("dev").Style.BackColor = Color.Yellow
            '    DGrid.Rows(e.RowIndex).Cells("dev").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            '    If DGrid.Rows(e.RowIndex).Cells("cargo").Value = 0 Then
            '        DGrid.Rows(e.RowIndex).Cells("dev").Style.BackColor = Color.Red
            '        DGrid.Rows(e.RowIndex).Cells("dev").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

            '    End If

            'End If


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick
        Try
            Dim columna As Integer = DGrid.CurrentCell.ColumnIndex
                If IsDBNull(DGrid.CurrentRow.Cells(DGrid.Columns.Count - 1).Value) Then
                Exit Sub
            End If

                
            'If columna <= 2 Then
            If Opcion = 1 Then 'proveedor 

               



                If ProveedorB <> "" Then
                    If DGrid.CurrentRow.Cells("raz_soc").Value = "TOTAL:" Then

                    Else
                        ProveedorB = DGrid.CurrentRow.Cells("proveedor").Value
                    End If
                Else
                    If DGrid.CurrentRow.Cells("raz_soc").Value = "TOTAL: " Then
                        ProveedorB = ""
                    Else
                        ProveedorB = DGrid.CurrentRow.Cells("proveedor").Value
                    End If
                End If

                IdBancoFactorajeB = IIf(IsDBNull((DGrid.CurrentRow.Cells("idproveedor").Value)), 0, DGrid.CurrentRow.Cells("idproveedor").Value)
                If IdBancoFactorajeB <> 0 Then
                    Lbl_Leyenda.Text = Lbl_Leyenda.Text & "\" & Mid(DGrid.CurrentRow.Cells("raz_soc").Value, 1, 3)

                End If
                If OpcionAnt = Opcion And Opcion <> 1 Then
                    Exit Sub
                Else
                    OpcionAnt = Opcion
                End If


                NombreCol = Me.DGrid.Columns(columna).Name
                If NombreCol = "SALDOACT" Then
                    MsgBox("Por el momento, no se encuentra habilitada esta opcion.", MsgBoxStyle.Critical, "Error")
                    Exit Sub
                End If
                'GeneraFechas(Mid(NombreCol, 1, Len(NombreCol) - 1))

                MesB = GenerarMes(NombreCol)
                If InStr(NombreCol, 1) > 0 Then
                    AnioB = CInt(Txt_Ejercicio.Text) + 1
                Else
                    AnioB = CInt(Txt_Ejercicio.Text)
                End If
                GeneraFechas(Mid(NombreCol, 1, Len(NombreCol) - 1))
                If IdBancoFactorajeB <> 0 Then
                    Lbl_Leyenda.Text = Lbl_Leyenda.Text & "\" & _
                                    "Ejercicio: " & AnioB & "\" & "Mes: " & MesB

                End If

                OpcionAnt = Opcion
                Opcion = 3

                RellenaGrid()
                Btn_Regresar.Enabled = True
                Exit Sub

            ElseIf Opcion = 2 Then
                Dim NombreCol As String = ""
                If ProveedorB <> "" Then
                    If DGrid.CurrentRow.Cells("raz_soc").Value = "TOTAL:" Then

                    Else
                        ProveedorB = DGrid.CurrentRow.Cells("proveedor").Value
                    End If
                Else
                    If DGrid.CurrentRow.Cells("raz_soc").Value = "TOTAL: " Then
                        ProveedorB = ""
                    Else
                        ProveedorB = DGrid.CurrentRow.Cells("proveedor").Value
                    End If
                End If

                If OpcionAnt = Opcion Then
                    Exit Sub
                Else
                    OpcionAnt = Opcion
                End If

                NombreCol = Me.DGrid.Columns(columna).Name
                GeneraFechas(NombreCol)
                OpcionAnt = Opcion
                Opcion = 3

                RellenaGrid()
                Btn_Regresar.Enabled = True
                Exit Sub
            ElseIf Opcion = 3 Then
                Dim NombreCol As String = ""

                If DGrid.CurrentRow.Cells("dia").Value = "TOTAL: " Then
                    'mes completo
                    'FecIni = DGrid.CurrentRow.Cells("fecha").Value
                    'FecFin = DGrid.CurrentRow.Cells("fecha").Value
                    ' GeneraFechas(NombreCol)
                Else
                    FecIni = DGrid.CurrentRow.Cells("fecha").Value
                    FecFin = DGrid.CurrentRow.Cells("fecha").Value
                End If


                If OpcionAnt = Opcion Then
                    Exit Sub
                Else
                    OpcionAnt = Opcion
                End If

                Lbl_Leyenda.Text = Lbl_Leyenda.Text & "\FechaIni: " & FecIni & "\FechaFin: " & FecFin
              
                OpcionAnt = Opcion
                Opcion = 4

                RellenaGrid()
                Btn_Regresar.Enabled = True

            ElseIf Opcion = 4 Then
                Dim NombreCol As String = ""



                
                If ProveedorB <> "" Then
                    If DGrid.CurrentRow.Cells("proveedor").Value = "TOTAL: " Then

                    Else
                        ProveedorB = DGrid.CurrentRow.Cells("proveedor").Value
                    End If
                Else
                    If DGrid.CurrentRow.Cells("proveedor").Value = "TOTAL: " Then
                        ProveedorB = ""
                    Else
                        ProveedorB = Mid(DGrid.CurrentRow.Cells("proveedor").Value, 1, 3)
                        Lbl_Leyenda.Text = Lbl_Leyenda.Text & "\" & DGrid.CurrentRow.Cells("proveedor").Value
                    End If
                End If


                If OpcionAnt = Opcion Then
                    Exit Sub
                Else

                    OpcionAnt = Opcion
                End If


                OpcionAnt = Opcion
                Opcion = 5

                RellenaGrid()
                Btn_Regresar.Enabled = True
            ElseIf Opcion = 5 Then
                Dim myForm As New frmCatalogoPedidoNuevo

                myForm.Accion = 4
                myForm.Sw_FacturaNueva = False
                myForm.Txt_Sucursal.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("sucursal").Value.ToString.Trim()
                myForm.Txt_OrdeComp.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("factprov").Value.ToString.Trim()
                myForm.FolioB = DGrid.Rows(DGrid.CurrentRow.Index).Cells("IDFOLIO").Value.ToString.Trim()
                myForm.Txt_NoBulto.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idfoliosuc").Value.ToString.Trim()
                myForm.Txt_Proveedor.Text = Mid(DGrid.Rows(DGrid.CurrentRow.Index).Cells("proveedor").Value.ToString.Trim(), 1, 3)

                myForm.Txt_NotaCargo.Text = Val(DGrid.Rows(DGrid.CurrentRow.Index).Cells("cargo").Value.ToString)
                myForm.Txt_NotaCredito.Text = Val(DGrid.Rows(DGrid.CurrentRow.Index).Cells("credito").Value.ToString)



                myForm.Sw_Factura = True
                    

                myForm.MdiParent = BitacoraMain
                myForm.Show()
            End If

            '' VER EL DETALLADO DE LA FACTURA.



        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Function GenerarMes(ByVal Mes As String) As Integer

        If UCase(Mes) = "ENERO" Or UCase(Mes) = "ENERO1" Then GenerarMes = 1
        If UCase(Mes) = "FEBRERO" Or UCase(Mes) = "FEBRERO1" Then GenerarMes = 2
        If UCase(Mes) = "MARZO" Or UCase(Mes) = "MARZO1" Then GenerarMes = 3
        If UCase(Mes) = "ABRIL" Or UCase(Mes) = "ABRIL1" Then GenerarMes = 4
        If UCase(Mes) = "MAYO" Or UCase(Mes) = "MAYO1" Then GenerarMes = 5
        If UCase(Mes) = "JUNIO" Or UCase(Mes) = "JUNIO1" Then GenerarMes = 6
        If UCase(Mes) = "JULIO" Or UCase(Mes) = "JULIO1" Then GenerarMes = 7
        If UCase(Mes) = "AGOSTO" Or UCase(Mes) = "AGOSTO1" Then GenerarMes = 8
        If UCase(Mes) = "SEPTIEMBRE" Or UCase(Mes) = "SEPTIEMBRE1" Then GenerarMes = 9
        If UCase(Mes) = "OCTUBRE" Or UCase(Mes) = "OCTUBRE1" Then GenerarMes = 10
        If UCase(Mes) = "NOVIEMBRE" Or UCase(Mes) = "NOVIEMBRE1" Then GenerarMes = 11
        If UCase(Mes) = "DICIEMBRE" Or UCase(Mes) = "DICIEMBRE1" Then GenerarMes = 12


        Return GenerarMes

    End Function
    Private Sub GeneraFechas(ByVal NomCol As String)
        Dim Anio As Integer = AnioB
        Dim Mes As Integer = 0
        Dim DiaIni As Integer = 1
        Dim DiaFin As Integer = 0
        Try
            'If InStr(NomCol, 1) >= 0 Then
            'Anio = CInt(Txt_Ejercicio.Text)
            'Else
            'Anio = CInt(Txt_Ejercicio.Text) + 1
            'End If

            If NomCol = "saldoact" Or NomCol = "saldoac" Then

                FecIni = New Date(Anio, 1, 1)
                FecFin = New Date(Anio, 12, 31)
                FecFin = DateAdd(DateInterval.Day, -1, FecFin)

            ElseIf NomCol = "saldoant" Or NomCol = "saldoan" Then

                FecIni = "1900-01-01"
                FecFin = New Date(Anio, 1, 1)
                FecFin = DateAdd(DateInterval.Day, -1, FecFin)

            ElseIf NomCol = "enero" Or NomCol = "ener" Then
                Mes = 1
                DiaFin = 31

                FecIni = New Date(Anio, Mes, DiaIni)
                FecFin = New Date(Anio, Mes, DiaFin)

            ElseIf NomCol = "febrero" Or NomCol = "febrer" Then
                Dim FEcFeb As Date
                Mes = 2
                FEcFeb = DateSerial(Anio, Mes + 1, 0)
                DiaFin = FEcFeb.Day

                FecIni = New Date(Anio, Mes, DiaIni)
                FecFin = New Date(Anio, Mes, DiaFin)

            ElseIf NomCol = "marzo" Or NomCol = "marz" Then
                Mes = 3
                DiaFin = 31

                FecIni = New Date(Anio, Mes, DiaIni)
                FecFin = New Date(Anio, Mes, DiaFin)

            ElseIf NomCol = "abril" Or NomCol = "abri" Then
                Mes = 4
                DiaFin = 30

                FecIni = New Date(Anio, Mes, DiaIni)
                FecFin = New Date(Anio, Mes, DiaFin)

            ElseIf NomCol = "mayo" Or NomCol = "may" Then
                Mes = 5
                DiaFin = 31

                FecIni = New Date(Anio, Mes, DiaIni)
                FecFin = New Date(Anio, Mes, DiaFin)

            ElseIf NomCol = "junio" Or NomCol = "juni" Then
                Mes = 6
                DiaFin = 30

                FecIni = New Date(Anio, Mes, DiaIni)
                FecFin = New Date(Anio, Mes, DiaFin)

            ElseIf NomCol = "julio" Or NomCol = "juli" Then
                Mes = 7
                DiaFin = 31

                FecIni = New Date(Anio, Mes, DiaIni)
                FecFin = New Date(Anio, Mes, DiaFin)

            ElseIf NomCol = "agosto" Or NomCol = "agost" Then
                Mes = 8
                DiaFin = 31

                FecIni = New Date(Anio, Mes, DiaIni)
                FecFin = New Date(Anio, Mes, DiaFin)

            ElseIf NomCol = "septiembre" Or NomCol = "septiembr" Then
                Mes = 9
                DiaFin = 30

                FecIni = New Date(Anio, Mes, DiaIni)
                FecFin = New Date(Anio, Mes, DiaFin)

            ElseIf NomCol = "octubre" Or NomCol = "octubr" Then
                Mes = 10
                DiaFin = 31

                FecIni = New Date(Anio, Mes, DiaIni)
                FecFin = New Date(Anio, Mes, DiaFin)

            ElseIf NomCol = "noviembre" Or NomCol = "noviembr" Then
                Mes = 11
                DiaFin = 30

                FecIni = New Date(Anio, Mes, DiaIni)
                FecFin = New Date(Anio, Mes, DiaFin)

            ElseIf NomCol = "diciembre" Or NomCol = "diciembr" Then
                Mes = 12
                DiaFin = 31

                FecIni = New Date(Anio, Mes, DiaIni)
                FecFin = New Date(Anio, Mes, DiaFin)

            ElseIf NomCol = "saldopos" Or NomCol = "saldopo" Then

                FecIni = New Date(Anio, 12, 31)
                FecIni = DateAdd(DateInterval.Day, 1, FecIni)
                FecFin = "2050-12-31"

            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Regresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Regresar.Click
        Try
            Lbl_Leyenda.Text = ""
            If Opcion = 5 Then
                Opcion = OpcionAnt

                Opcion = 4

                MarcaB = ""
                'ProveedorB = ""

                RellenaGrid()

                If Opcion = 1 Then
                    Btn_Regresar.Enabled = False
                End If
            ElseIf Opcion = 4 Then
                Opcion = OpcionAnt
                Opcion = 3


                GeneraFechas(Mid(NombreCol, 1, Len(NombreCol) - 1))


                MarcaB = ""
                'ProveedorB = ""

                RellenaGrid()

                If Opcion = 1 Then
                    Btn_Regresar.Enabled = False
                End If
            ElseIf Opcion = 5 Then
                Opcion = OpcionAnt
                Opcion = 4

                MarcaB = ""
                ProveedorB = ""

                RellenaGrid()

                If Opcion = 1 Then
                    Btn_Regresar.Enabled = False
                End If
            ElseIf Opcion = 3 Then
                Opcion = OpcionAnt
                Opcion = 1

                MarcaB = ""
                ProveedorB = ""

                RellenaGrid()

                If Opcion = 1 Then
                    Btn_Regresar.Enabled = False
                End If

            ElseIf Opcion = 2 Then

                If Opcion = OpcionAnt Then
                    Opcion = 1
                Else
                    Opcion = OpcionAnt
                End If
                MarcaB = ""
                ProveedorB = ""

                RellenaGrid()

                If Opcion = 1 Then
                    Btn_Regresar.Enabled = False
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

   

    Private Sub Txt_Ejercicio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Ejercicio.KeyPress
        pub_SoloNumeros(sender, e)
    End Sub

    Private Sub Btn_Aceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        Try
            Dim Anio As Integer = 0

            If Txt_Ejercicio.Text.Length < 4 Then Exit Sub
            Anio = CInt(Txt_Ejercicio.Text)

            If Txt_Ejercicio.Text.Length = 4 Then
                EjercicioB = CInt(Txt_Ejercicio.Text)
            Else
                MessageBox.Show("Ingrese un año válido")
                Exit Sub
            End If

            RellenaGrid()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub

    Private Sub Pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub

    Private Sub Btn_Filtro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        'mreyes 27/Octubre/2014 05:15 p.m.
        Try
            Dim myForm As New frmFiltrosSaldosFactoraje
            ' myForm.Txt_Marca.Text = MarcaB

            myForm.Txt_Proveedor.Text = ProveedorB

           
            If FecIni <> "1900-01-01" Then
                myForm.Chk_FechaEntrega.Checked = True
                myForm.DTPicker4.Value = FecIni
                myForm.DTPicker5.Value = FecFin
            End If
            

            myForm.ShowDialog()
            ' MarcaB = myForm.Txt_Marca.Text

            ProveedorB = myForm.Txt_Proveedor.Text

           
            If myForm.Chk_FechaEntrega.Checked = True Then
                FecIni = Format(myForm.DTPicker4.Value, "yyyy-MM-dd")
                FecFin = Format(myForm.DTPicker5.Value, "yyyy-MM-dd")
            Else
                FecIni = "1900-01-01"
                FecFin = "1900-01-01"
            End If

           



            If myForm.Sw_Filtro = True Then
                Call RellenaGrid()
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
End Class