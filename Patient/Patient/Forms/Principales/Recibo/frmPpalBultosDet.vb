Public Class frmPpalBultosDet
    'Tony Garcia - 24/Enero/2013 - 12:20 p.m.

    Private objDataSet As Data.DataSet
    Private objDataSet1 As Data.DataSet
    Private objDataSetEmp As Data.DataSet
   
    Private SucursalB As String
    Private FechaRecIniB As String
    Private FechaRecFinB As String
    Private FechaAsigIniB As String
    Private FechaAsigFinB As String
    Private ProveedorB As String
    Private RecibeB As Integer
    Private AsignaB As Integer
    Private FolioB As Integer
    Private NoGuiaB As String

    Dim StatusB As String = ""
    Dim TipoB As String = ""
   
    Public Opcion As Integer = 0
    Private OpcionSP As Integer = 0
    Dim Sw_NoRegistros As Boolean = False
    Dim Sw_Pintar As Boolean = False
    Dim Sw_Load As Boolean = True
    Private Sub AgregarColumna()
        'mreyes 21/Marzo/2012 09:52 a.m.

        Dim colImagen As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        colImagen.Name = "Selec"
        colImagen.HeaderText = "Selec"
        colImagen.DisplayIndex = 0
        colImagen.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        colImagen.CellTemplate = New DataGridViewCheckBoxCell()
        ' añadir columna de imagen a la coleccion del grid 
        DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        ''DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DGrid.Columns.Add(colImagen)


    End Sub
    Private Sub frmPpalBultosDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'Btn_Eliminar

            If Opcion = 2 Then
                Btn_Marca.Visible = False
                Btn_Proveedor.Visible = False
                Btn_Sucursal.Visible = False
                Me.Text = "Recibo de Bultos"
            End If
            OpcionSP = 1
            GenerarToolTip()
            Call LimpiarBusqueda()
            Sw_Pintar = True
            Sw_Load = True

            If GLB_IdDeptoEmpleado = 2 Or GLB_IdDeptoEmpleado = 1 Or GLB_IdDeptoEmpleado = 8 Then
                Btn_Eliminar.Visible = True
            Else
                Btn_Eliminar.Visible = False

            End If

            Call RellenaGrid()
            'InicializaGrid()
            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmPpalBultosDet_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            If Sw_NoRegistros = False Then Exit Sub
            If Sw_Load = True Then
                Sw_Load = False
                InicializaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub LimpiarBusqueda()
        SucursalB = ""
        FechaRecIniB = "1900-01-01"
        FechaRecFinB = "1900-01-01"
        FechaAsigIniB = "1900-01-01"
        FechaAsigFinB = "1900-01-01"
        ProveedorB = ""
        RecibeB = 0
        AsignaB = 0
        FolioB = 0
        NoGuiaB = ""
        TipoB = ""
        StatusB = ""
    End Sub

    Private Sub RellenaGrid()
        'Tony Garcia - 24/Enero/2013 - 3:15 p.m.
        Using objBultos As New BCL.BCLBulto(GLB_ConStringCipSis)
            Try

                Me.Cursor = Cursors.WaitCursor


                If Sw_Load = True Then
                    ' Sw_Load = False
                    StatusB = "CA"
                Else

                    If Sw_NoRegistros = True Then
                        DGrid.Columns.Remove("Selec")

                    End If

                End If
                DGrid.ReadOnly = False

                'DGrid.ReadOnly = True
                DGrid.DataSource = Nothing
                objDataSet = Nothing
                objDataSet1 = Nothing

                If Opcion = 1 Then

                    If OpcionSP = 1 Then
                        objDataSet = objBultos.usp_PpalBultosDetallado(OpcionSP, SucursalB)
                    Else
                        objDataSet = objBultos.usp_PpalBultosDetallado(OpcionSP, SucursalB)
                    End If

                    Btn_Regresar.Enabled = False

                ElseIf Opcion = 2 Then

                    objDataSet = objBultos.usp_PpalBultosDetalladoDet(OpcionSP, SucursalB, ProveedorB, NoGuiaB, FolioB, RecibeB, AsignaB, _
                                                                      FechaRecIniB, FechaRecFinB, FechaAsigIniB, FechaAsigFinB, GLB_CveSucursal, StatusB, TipoB)
                    'Btn_Regresar.Enabled = False

                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Opcion = 2
                        DGrid.DataSource = Nothing
                        DGrid.DataSource = objDataSet.Tables(0)

                        Dim dtEmpleado As DataTable = TryCast(DGrid.DataSource, DataTable)

                        For Each row As DataRow In dtEmpleado.Rows
                            Using objMySqlGral As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)
                                Try
                                    Dim strRecibe1 As String
                                    Dim strRecibe2 As String
                                    Dim strAsigna1 As String
                                    Dim strAsigna2 As String

                                    objDataSetEmp = objMySqlGral.usp_TraerNomEmpleado(row("recibe"), "", "", "", "", 0)
                                    If objDataSetEmp.Tables(0).Rows.Count = 1 Then
                                        strRecibe1 = objDataSetEmp.Tables(0).Rows(0).Item("idempleado").ToString
                                        strRecibe2 = objDataSetEmp.Tables(0).Rows(0).Item("nomcompleto").ToString

                                        row("recibenom") = strRecibe1 & " - " & strRecibe2
                                    End If

                                    objDataSetEmp = objMySqlGral.usp_TraerNomEmpleado(row("asigna"), "", "", "", "", 0)
                                    If objDataSetEmp.Tables(0).Rows.Count = 1 Then
                                        strAsigna1 = objDataSetEmp.Tables(0).Rows(0).Item("idempleado").ToString
                                        strAsigna2 = objDataSetEmp.Tables(0).Rows(0).Item("nomcompleto").ToString

                                        row("asignanom") = strAsigna1 & " - " & strAsigna2
                                    End If

                                Catch ExceptionErr As Exception
                                    MessageBox.Show(ExceptionErr.Message.ToString)
                                End Try
                            End Using
                        Next

                        'InicializaGrid()

                    End If
                End If

                If objDataSet.Tables(0).Rows.Count > 0 Then

                    DGrid.DataSource = objDataSet.Tables(0)

                    If Sw_Load = False Then
                        InicializaGrid()
                    End If
                    'LimpiarBusqueda()
                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True

                    Sw_NoRegistros = True
                    Sw_Pintar = True
                Else
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontro Información que cumpla con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                End If

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub
    'Private Sub RellenaGrid()
    '    'Tony Garcia - 24/Enero/2013 - 3:15 p.m.
    '    Using objBultos As New BCL.BCLBulto(GLB_ConStringCipSis)
    '        Try

    '            Me.Cursor = Cursors.WaitCursor
    '            DGrid.ReadOnly = True
    '            DGrid.DataSource = Nothing
    '            objDataSet = Nothing
    '            objDataSet1 = Nothing

    '            If Opcion = 1 Then

    '                If OpcionSP = 1 Then
    '                    objDataSet = objBultos.usp_PpalBultosDetallado(OpcionSP, SucursalB)
    '                ElseIf OpcionSP = 2 Then
    '                    objDataSet = objBultos.usp_PpalBultosDetallado(OpcionSP, SucursalB)
    '                End If

    '                Btn_Regresar.Enabled = False

    '            ElseIf Opcion = 2 Then

    '                objDataSet = objBultos.usp_PpalBultosDetalladoDet(OpcionSP, SucursalB, ProveedorB, NoGuiaB, FolioB, RecibeB, AsignaB, _
    '                                                                  FechaRecIniB, FechaRecFinB, FechaAsigIniB, FechaAsigFinB)
    '                'Btn_Regresar.Enabled = False

    '                If objDataSet.Tables(0).Rows.Count > 0 Then
    '                    Opcion = 2
    '                    DGrid.DataSource = Nothing
    '                    DGrid.DataSource = objDataSet.Tables(0)

    '                    Dim dtEmpleado As DataTable = TryCast(DGrid.DataSource, DataTable)

    '                    For Each row As DataRow In dtEmpleado.Rows
    '                        Using objMySqlGral As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)
    '                            Try
    '                                Dim strRecibe1 As String
    '                                Dim strRecibe2 As String
    '                                Dim strAsigna1 As String
    '                                Dim strAsigna2 As String

    '                                objDataSetEmp = objMySqlGral.usp_TraerNomEmpleado(row("recibe"), "", "", "", "")
    '                                If objDataSetEmp.Tables(0).Rows.Count = 1 Then
    '                                    strRecibe1 = objDataSetEmp.Tables(0).Rows(0).Item("idempleado").ToString
    '                                    strRecibe2 = objDataSetEmp.Tables(0).Rows(0).Item("nomcompleto").ToString

    '                                    row("recibenom") = strRecibe1 & " - " & strRecibe2
    '                                End If

    '                                objDataSetEmp = objMySqlGral.usp_TraerNomEmpleado(row("asigna"), "", "", "", "")
    '                                If objDataSetEmp.Tables(0).Rows.Count = 1 Then
    '                                    strAsigna1 = objDataSetEmp.Tables(0).Rows(0).Item("idempleado").ToString
    '                                    strAsigna2 = objDataSetEmp.Tables(0).Rows(0).Item("nomcompleto").ToString

    '                                    row("asignanom") = strAsigna1 & " - " & strAsigna2
    '                                End If

    '                            Catch ExceptionErr As Exception
    '                                MessageBox.Show(ExceptionErr.Message.ToString)
    '                            End Try
    '                        End Using
    '                    Next

    '                    'InicializaGrid()

    '                End If
    '            End If

    '            If objDataSet.Tables(0).Rows.Count > 0 Then

    '                DGrid.DataSource = objDataSet.Tables(0)

    '                If Sw_Load = False Then
    '                    InicializaGrid()
    '                End If
    '                'LimpiarBusqueda()
    '                Me.Cursor = Cursors.Default
    '                Btn_Excel.Enabled = True

    '                Sw_NoRegistros = True
    '                Sw_Pintar = True
    '            Else
    '                Sw_NoRegistros = False
    '                Me.Cursor = Cursors.Default
    '                MsgBox("No se encontro Información que cumpla con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
    '                Btn_Excel.Enabled = False
    '            End If

    '        Catch ExceptionErr As Exception
    '            MessageBox.Show(ExceptionErr.Message.ToString)
    '        End Try
    '    End Using
    'End Sub

    Sub InicializaGrid()
        

        Try

            If Opcion = 1 Then

                DGrid.Columns(0).Frozen = True
                DGrid.Columns(1).Frozen = True
                DGrid.Columns(0).DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Columns(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                DGrid.Columns(1).DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Columns(1).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)


                If OpcionSP = 1 Then
                    Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)

                    Dim row As DataRow = dt.NewRow()

                    row(1) = "Total: "
                    row(22) = pub_SumarColumnaGrid(DGrid, 22, DGrid.RowCount - 1)
                    row(23) = pub_SumarColumnaGrid(DGrid, 23, DGrid.RowCount - 1)
                    row(2) = pub_SumarColumnaGrid(DGrid, 2, DGrid.RowCount - 1)
                    'row(3) = pub_SumarColumnaGrid(DGrid, 3, DGrid.RowCount - 1)
                    row(3) = row(2) / row(22) * 100
                    row(4) = pub_SumarColumnaGrid(DGrid, 4, DGrid.RowCount - 1)
                    row(5) = row(4) / row(22) * 100
                    'row(5) = pub_SumarColumnaGrid(DGrid, 5, DGrid.RowCount - 1)
                    row(6) = pub_SumarColumnaGrid(DGrid, 6, DGrid.RowCount - 1)
                    row(7) = row(6) / row(22) * 100
                    'row(7) = pub_SumarColumnaGrid(DGrid, 7, DGrid.RowCount - 1)
                    row(8) = pub_SumarColumnaGrid(DGrid, 8, DGrid.RowCount - 1)
                    row(9) = row(8) / row(22) * 100
                    'row(9) = pub_SumarColumnaGrid(DGrid, 9, DGrid.RowCount - 1)
                    row(10) = pub_SumarColumnaGrid(DGrid, 10, DGrid.RowCount - 1)
                    row(11) = row(10) / row(22) * 100
                    'row(11) = pub_SumarColumnaGrid(DGrid, 11, DGrid.RowCount - 1)
                    row(12) = pub_SumarColumnaGrid(DGrid, 12, DGrid.RowCount - 1)
                    row(13) = row(12) / row(22) * 100
                    'row(13) = pub_SumarColumnaGrid(DGrid, 13, DGrid.RowCount - 1)
                    row(14) = pub_SumarColumnaGrid(DGrid, 14, DGrid.RowCount - 1)
                    row(15) = row(14) / row(22) * 100
                    'row(15) = pub_SumarColumnaGrid(DGrid, 15, DGrid.RowCount - 1)
                    row(16) = pub_SumarColumnaGrid(DGrid, 16, DGrid.RowCount - 1)
                    row(17) = row(16) / row(22) * 100
                    'row(17) = pub_SumarColumnaGrid(DGrid, 17, DGrid.RowCount - 1)
                    row(18) = pub_SumarColumnaGrid(DGrid, 18, DGrid.RowCount - 1)
                    row(19) = row(18) / row(22) * 100
                    'row(19) = pub_SumarColumnaGrid(DGrid, 19, DGrid.RowCount - 1)
                    row(20) = pub_SumarColumnaGrid(DGrid, 20, DGrid.RowCount - 1)
                    row(21) = row(20) / row(22) * 100
                    'row(21) = pub_SumarColumnaGrid(DGrid, 21, DGrid.RowCount - 1)
                    

                    dt.Rows.Add(row)
                    DGrid.DataSource = dt

                    DGrid.DataSource = dt
                    DGrid.Columns(0).HeaderText = "Det"
                    DGrid.Columns(1).HeaderText = "Sucursal"
                    DGrid.Columns(2).HeaderText = "1"
                    DGrid.Columns(3).HeaderText = "%"
                    DGrid.Columns(4).HeaderText = "2"
                    DGrid.Columns(5).HeaderText = "%"
                    DGrid.Columns(6).HeaderText = "3"
                    DGrid.Columns(7).HeaderText = "%"
                    DGrid.Columns(8).HeaderText = "4"
                    DGrid.Columns(9).HeaderText = "%"
                    DGrid.Columns(10).HeaderText = "5"
                    DGrid.Columns(11).HeaderText = "%"
                    DGrid.Columns(12).HeaderText = "6"
                    DGrid.Columns(13).HeaderText = "%"
                    DGrid.Columns(14).HeaderText = "7"
                    DGrid.Columns(15).HeaderText = "%"
                    DGrid.Columns(16).HeaderText = "8"
                    DGrid.Columns(17).HeaderText = "%"
                    DGrid.Columns(18).HeaderText = "9"
                    DGrid.Columns(19).HeaderText = "%"
                    DGrid.Columns(20).HeaderText = "10+"
                    DGrid.Columns(21).HeaderText = "%"
                    DGrid.Columns(22).HeaderText = "Total"
                    DGrid.Columns(23).HeaderText = "%"

                    DGrid.Columns(22).DefaultCellStyle.BackColor = Color.PowderBlue
                    DGrid.Columns(22).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                    DGrid.Columns(23).DefaultCellStyle.BackColor = Color.PowderBlue
                    DGrid.Columns(23).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                    DGrid.Columns(22).DisplayIndex = 2
                    DGrid.Columns(23).DisplayIndex = 3

                    DGrid.Columns(22).Frozen = True
                    DGrid.Columns(23).Frozen = True

                    For i As Integer = 0 To DGrid.ColumnCount - 1
                        DGrid.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Next


                    '"#0.00"
                    DGrid.Columns(3).DefaultCellStyle.Format = "#0.00"
                    DGrid.Columns(5).DefaultCellStyle.Format = "#0.00"
                    DGrid.Columns(7).DefaultCellStyle.Format = "#0.00"
                    DGrid.Columns(9).DefaultCellStyle.Format = "#0.00"
                    DGrid.Columns(11).DefaultCellStyle.Format = "#0.00"
                    DGrid.Columns(13).DefaultCellStyle.Format = "#0.00"
                    DGrid.Columns(15).DefaultCellStyle.Format = "#0.00"
                    DGrid.Columns(17).DefaultCellStyle.Format = "#0.00"
                    DGrid.Columns(19).DefaultCellStyle.Format = "#0.00"
                    DGrid.Columns(21).DefaultCellStyle.Format = "#0.00"
                    DGrid.Columns(23).DefaultCellStyle.Format = "#0.00"

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

                    DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.BackColor = Color.PowderBlue
                    DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)


                    'Recorre el Grid y pinta de blanco las celdas con valor de cero

                    For i As Integer = 0 To DGrid.Rows.Count - 3
                        For j As Integer = 2 To DGrid.Columns.Count - 1
                            If DGrid.Rows(i).Cells(j).Value.ToString.Trim = 0 Then
                                DGrid.Rows(i).Cells(j).Style.ForeColor = Color.White
                            End If
                        Next
                    Next

                ElseIf OpcionSP = 2 Then

                    Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)

                    Dim row As DataRow = dt.NewRow()

                    row(1) = "Total: "

                    row(2) = pub_SumarColumnaGrid(DGrid, 2, DGrid.RowCount - 1)
                    row(3) = pub_SumarColumnaGrid(DGrid, 3, DGrid.RowCount - 1)
                    row(4) = pub_SumarColumnaGrid(DGrid, 4, DGrid.RowCount - 1)
                    row(5) = pub_SumarColumnaGrid(DGrid, 5, DGrid.RowCount - 1)
                    row(6) = pub_SumarColumnaGrid(DGrid, 6, DGrid.RowCount - 1)
                    row(7) = pub_SumarColumnaGrid(DGrid, 7, DGrid.RowCount - 1)
                    row(8) = pub_SumarColumnaGrid(DGrid, 8, DGrid.RowCount - 1)
                    row(9) = pub_SumarColumnaGrid(DGrid, 9, DGrid.RowCount - 1)
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

                    dt.Rows.Add(row)
                    DGrid.DataSource = dt

                    DGrid.DataSource = dt
                    DGrid.Columns(0).HeaderText = "Proveedor"
                    DGrid.Columns(1).HeaderText = "Razón Social"
                    DGrid.Columns(2).HeaderText = "5"
                    DGrid.Columns(3).HeaderText = "%"
                    DGrid.Columns(4).HeaderText = "10"
                    DGrid.Columns(5).HeaderText = "%"
                    DGrid.Columns(6).HeaderText = "15"
                    DGrid.Columns(7).HeaderText = "%"
                    DGrid.Columns(8).HeaderText = "20"
                    DGrid.Columns(9).HeaderText = "%"
                    DGrid.Columns(10).HeaderText = "25"
                    DGrid.Columns(11).HeaderText = "%"
                    DGrid.Columns(12).HeaderText = "30"
                    DGrid.Columns(13).HeaderText = "%"
                    DGrid.Columns(14).HeaderText = "45"
                    DGrid.Columns(15).HeaderText = "%"
                    DGrid.Columns(16).HeaderText = "60"
                    DGrid.Columns(17).HeaderText = "%"
                    DGrid.Columns(18).HeaderText = "90"
                    DGrid.Columns(19).HeaderText = "%"
                    DGrid.Columns(20).HeaderText = "90+"
                    DGrid.Columns(21).HeaderText = "%"
                    DGrid.Columns(22).HeaderText = "Total"
                    DGrid.Columns(23).HeaderText = "%"

                    DGrid.Columns(22).DefaultCellStyle.BackColor = Color.PowderBlue
                    DGrid.Columns(22).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                    DGrid.Columns(23).DefaultCellStyle.BackColor = Color.PowderBlue
                    DGrid.Columns(23).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                    DGrid.Columns(22).DisplayIndex = 2
                    DGrid.Columns(23).DisplayIndex = 3

                    DGrid.Columns(22).Frozen = True
                    DGrid.Columns(23).Frozen = True

                    For i As Integer = 0 To DGrid.ColumnCount - 1
                        DGrid.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Next


                    '"#0.00"
                    DGrid.Columns(3).DefaultCellStyle.Format = "#0.00"
                    DGrid.Columns(5).DefaultCellStyle.Format = "#0.00"
                    DGrid.Columns(7).DefaultCellStyle.Format = "#0.00"
                    DGrid.Columns(9).DefaultCellStyle.Format = "#0.00"
                    DGrid.Columns(11).DefaultCellStyle.Format = "#0.00"
                    DGrid.Columns(13).DefaultCellStyle.Format = "#0.00"
                    DGrid.Columns(15).DefaultCellStyle.Format = "#0.00"
                    DGrid.Columns(17).DefaultCellStyle.Format = "#0.00"
                    DGrid.Columns(19).DefaultCellStyle.Format = "#0.00"
                    DGrid.Columns(21).DefaultCellStyle.Format = "#0.00"
                    DGrid.Columns(23).DefaultCellStyle.Format = "#0.00"

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

                    DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.BackColor = Color.PowderBlue
                    DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)


                    'Recorre el Grid y pinta de blanco las celdas con valor de cero

                    For i As Integer = 0 To DGrid.Rows.Count - 3
                        For j As Integer = 2 To DGrid.Columns.Count - 1
                            If DGrid.Rows(i).Cells(j).Value.ToString.Trim = 0 Then
                                DGrid.Rows(i).Cells(j).Style.ForeColor = Color.White
                            End If
                        Next
                    Next

                ElseIf OpcionSP = 3 Then

                    Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)

                    Dim row As DataRow = dt.NewRow()

                    row(1) = "Total: "

                    row(2) = pub_SumarColumnaGrid(DGrid, 2, DGrid.RowCount - 1)
                    row(3) = pub_SumarColumnaGrid(DGrid, 3, DGrid.RowCount - 1)
                    row(4) = pub_SumarColumnaGrid(DGrid, 4, DGrid.RowCount - 1)
                    row(5) = pub_SumarColumnaGrid(DGrid, 5, DGrid.RowCount - 1)
                    row(6) = pub_SumarColumnaGrid(DGrid, 6, DGrid.RowCount - 1)
                    row(7) = pub_SumarColumnaGrid(DGrid, 7, DGrid.RowCount - 1)
                    row(8) = pub_SumarColumnaGrid(DGrid, 8, DGrid.RowCount - 1)
                    row(9) = pub_SumarColumnaGrid(DGrid, 9, DGrid.RowCount - 1)
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

                    dt.Rows.Add(row)
                    DGrid.DataSource = dt

                    DGrid.DataSource = dt
                    DGrid.Columns(0).HeaderText = "Marca"
                    DGrid.Columns(1).HeaderText = "Descripción"
                    DGrid.Columns(2).HeaderText = "5"
                    DGrid.Columns(3).HeaderText = "%"
                    DGrid.Columns(4).HeaderText = "10"
                    DGrid.Columns(5).HeaderText = "%"
                    DGrid.Columns(6).HeaderText = "15"
                    DGrid.Columns(7).HeaderText = "%"
                    DGrid.Columns(8).HeaderText = "20"
                    DGrid.Columns(9).HeaderText = "%"
                    DGrid.Columns(10).HeaderText = "25"
                    DGrid.Columns(11).HeaderText = "%"
                    DGrid.Columns(12).HeaderText = "30"
                    DGrid.Columns(13).HeaderText = "%"
                    DGrid.Columns(14).HeaderText = "45"
                    DGrid.Columns(15).HeaderText = "%"
                    DGrid.Columns(16).HeaderText = "60"
                    DGrid.Columns(17).HeaderText = "%"
                    DGrid.Columns(18).HeaderText = "90"
                    DGrid.Columns(19).HeaderText = "%"
                    DGrid.Columns(20).HeaderText = "90+"
                    DGrid.Columns(21).HeaderText = "%"
                    DGrid.Columns(22).HeaderText = "Total"
                    DGrid.Columns(23).HeaderText = "%"

                    DGrid.Columns(22).DefaultCellStyle.BackColor = Color.PowderBlue
                    DGrid.Columns(22).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                    DGrid.Columns(23).DefaultCellStyle.BackColor = Color.PowderBlue
                    DGrid.Columns(23).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                    DGrid.Columns(22).DisplayIndex = 2
                    DGrid.Columns(23).DisplayIndex = 3

                    DGrid.Columns(22).Frozen = True
                    DGrid.Columns(23).Frozen = True

                    For i As Integer = 0 To DGrid.ColumnCount - 1
                        DGrid.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Next


                    '"#0.00"
                    DGrid.Columns(3).DefaultCellStyle.Format = "#0.00"
                    DGrid.Columns(5).DefaultCellStyle.Format = "#0.00"
                    DGrid.Columns(7).DefaultCellStyle.Format = "#0.00"
                    DGrid.Columns(9).DefaultCellStyle.Format = "#0.00"
                    DGrid.Columns(11).DefaultCellStyle.Format = "#0.00"
                    DGrid.Columns(13).DefaultCellStyle.Format = "#0.00"
                    DGrid.Columns(15).DefaultCellStyle.Format = "#0.00"
                    DGrid.Columns(17).DefaultCellStyle.Format = "#0.00"
                    DGrid.Columns(19).DefaultCellStyle.Format = "#0.00"
                    DGrid.Columns(21).DefaultCellStyle.Format = "#0.00"
                    DGrid.Columns(23).DefaultCellStyle.Format = "#0.00"

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

                    DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.BackColor = Color.PowderBlue
                    DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)


                    'Recorre el Grid y pinta de blanco las celdas con valor de cero

                    For i As Integer = 0 To DGrid.Rows.Count - 3
                        For j As Integer = 2 To DGrid.Columns.Count - 1
                            If DGrid.Rows(i).Cells(j).Value.ToString.Trim = 0 Then
                                DGrid.Rows(i).Cells(j).Style.ForeColor = Color.White
                            End If
                        Next
                    Next

                End If



            ElseIf Opcion = 2 Then

                If OpcionSP = 1 Then
                    Dim intFolios As Integer = 0
                    Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)

                    intFolios = DGrid.Rows.Count - 1

                    Dim row As DataRow = dt.NewRow()

                    If intFolios = 1 Then
                        row(9) = "Total " & "(" & intFolios.ToString & " Folio):"
                    Else
                        row(9) = "Total " & "(" & intFolios.ToString & " Folios):"
                    End If


                    row(5) = pub_SumarColumnaGrid(DGrid, 5, DGrid.RowCount - 1)

                    dt.Rows.Add(row)
                    DGrid.DataSource = dt

                    DGrid.Columns(0).HeaderText = "Det"
                    DGrid.Columns(1).HeaderText = "Folio Electrónico"
                    DGrid.Columns(2).HeaderText = "Proveedor"
                    DGrid.Columns(3).HeaderText = "Razón Social"
                    DGrid.Columns(4).HeaderText = "N° Guia"
                    DGrid.Columns(5).HeaderText = "N° Bultos"
                    DGrid.Columns(6).HeaderText = "Recibe" 'oculto
                    DGrid.Columns(7).HeaderText = "Recibe"
                    DGrid.Columns(8).HeaderText = "Asigna" 'oculto
                    DGrid.Columns(9).HeaderText = "Asigna"
                    DGrid.Columns(10).HeaderText = "Fecha Recibo"
                    DGrid.Columns(11).HeaderText = "Folio"
                    DGrid.Columns(12).HeaderText = "Estatus"
                    DGrid.Columns(13).HeaderText = "Tipo"

                    '
                    DGrid.Columns(11).DisplayIndex = 3
                    DGrid.Columns(13).DisplayIndex = 1
                    DGrid.Columns(1).DisplayIndex = 4
                    DGrid.Columns(2).DisplayIndex = 5
                    DGrid.Columns(3).DisplayIndex = 6
                    DGrid.Columns(4).DisplayIndex = 7
                    DGrid.Columns(12).DisplayIndex = 8
                    DGrid.Columns(10).DisplayIndex = 2
                    DGrid.Columns(5).DisplayIndex = 10


                    DGrid.Columns(0).Visible = False
                    DGrid.Columns(1).Visible = False

                    DGrid.Columns(1).DefaultCellStyle.Format = "0000"

                    DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DGrid.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DGrid.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                    DGrid.Columns(6).Visible = False
                    DGrid.Columns(8).Visible = False


                    DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.BackColor = Color.PowderBlue
                    DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                ElseIf OpcionSP = 2 Then

                    Dim intFolios As Integer = 0
                    Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)

                    intFolios = DGrid.Rows.Count - 1

                    Dim row As DataRow = dt.NewRow()

                    If intFolios = 1 Then
                        row(8) = "Total " & "(" & intFolios.ToString & " Folio):"
                    Else
                        row(8) = "Total " & "(" & intFolios.ToString & " Folios):"
                    End If


                    row(4) = pub_SumarColumnaGrid(DGrid, 4, DGrid.RowCount - 1)

                    dt.Rows.Add(row)
                    DGrid.DataSource = dt

                    'DGrid.Columns(0).HeaderText = "Det"
                    DGrid.Columns(0).HeaderText = "Proveedor"
                    DGrid.Columns(1).HeaderText = "Folio"
                    DGrid.Columns(2).HeaderText = "Razón Social"
                    DGrid.Columns(3).HeaderText = "N° Guia"
                    DGrid.Columns(4).HeaderText = "N° Bultos"
                    DGrid.Columns(5).HeaderText = "Recibe" 'oculto
                    DGrid.Columns(6).HeaderText = "Recibe"
                    DGrid.Columns(7).HeaderText = "Asigna" 'oculto
                    DGrid.Columns(8).HeaderText = "Asigna"
                    DGrid.Columns(9).HeaderText = "Fecha Recibo"

                    DGrid.Columns(1).DefaultCellStyle.Format = "0000"

                    DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DGrid.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DGrid.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    'DGrid.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                    DGrid.Columns(5).Visible = False
                    DGrid.Columns(7).Visible = False
                    DGrid.Columns(4).DisplayIndex = 9
                    DGrid.Columns(9).DisplayIndex = 0
                    DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.BackColor = Color.PowderBlue
                    DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)


                ElseIf OpcionSP = 3 Then

                    Dim intFolios As Integer = 0
                    Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)

                    intFolios = DGrid.Rows.Count - 1

                    Dim row As DataRow = dt.NewRow()

                    If intFolios = 1 Then
                        row(8) = "Total " & "(" & intFolios.ToString & " Folio):"
                    Else
                        row(8) = "Total " & "(" & intFolios.ToString & " Folios):"
                    End If


                    row(4) = pub_SumarColumnaGrid(DGrid, 4, DGrid.RowCount - 1)

                    dt.Rows.Add(row)
                    DGrid.DataSource = dt

                    'DGrid.Columns(0).HeaderText = "Det"
                    DGrid.Columns(0).HeaderText = "Marca"
                    DGrid.Columns(1).HeaderText = "Folio Electrónico"
                    DGrid.Columns(2).HeaderText = "Proveedor"
                    DGrid.Columns(3).HeaderText = "N° Guia"
                    DGrid.Columns(4).HeaderText = "N° Bultos"
                    DGrid.Columns(5).HeaderText = "Recibe" 'oculto
                    DGrid.Columns(6).HeaderText = "Recibe"
                    DGrid.Columns(7).HeaderText = "Asigna" 'oculto
                    DGrid.Columns(8).HeaderText = "Asigna"
                    DGrid.Columns(9).HeaderText = "Fecha Recibo"

                    DGrid.Columns(1).DefaultCellStyle.Format = "0000"

                    DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DGrid.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DGrid.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    'DGrid.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                    DGrid.Columns(5).Visible = False
                    DGrid.Columns(7).Visible = False
                    DGrid.Columns(4).DisplayIndex = 9
                    DGrid.Columns(9).DisplayIndex = 0
                    DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.BackColor = Color.PowderBlue
                    DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                End If

            End If

            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            If Opcion <> 1 Then
                Call AgregarColumna()
            End If
            For i As Integer = 0 To DGrid.ColumnCount - 1

                DGrid.Columns(i).ReadOnly = True
            Next
            If Opcion <> 1 Then
                DGrid.Columns("Selec").ReadOnly = False
            End If

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

    Private Sub frmPpalPedidoNuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub DGrid_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick
        Try
            If Opcion = 2 Then
                Try
                    Btn_Consultar_Click(sender, e)
                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
                Exit Sub
            End If

            If OpcionSP = 1 Then
                If IsDBNull(DGrid.Rows(DGrid.CurrentRow.Index).Cells("sucursal").Value) Then
                    SucursalB = ""
                Else
                    SucursalB = DGrid.Rows(DGrid.CurrentRow.Index).Cells("sucursal").Value
                End If
            ElseIf OpcionSP = 2 Then
                If IsDBNull(DGrid.Rows(DGrid.CurrentRow.Index).Cells("sucursal").Value) Then
                    SucursalB = ""
                    ProveedorB = ""
                Else
                    SucursalB = ""
                    ProveedorB = DGrid.Rows(DGrid.CurrentRow.Index).Cells("sucursal").Value
                End If
            ElseIf OpcionSP = 3 Then
                If IsDBNull(DGrid.Rows(DGrid.CurrentRow.Index).Cells("sucursal").Value) Then
                    SucursalB = ""
                    ProveedorB = ""
                Else
                    SucursalB = ""
                    ProveedorB = ""
                End If
            End If

            

            Using objBultos As New BCL.BCLBulto(GLB_ConStringCipSis)
                objDataSet1 = objBultos.usp_PpalBultosDetalladoDet(OpcionSP, SucursalB, ProveedorB, NoGuiaB, FolioB, RecibeB, AsignaB, _
                                                                      FechaRecIniB, FechaRecFinB, FechaAsigIniB, FechaAsigFinB, GLB_CveSucursal, "CA", "")
            End Using

            If objDataSet1.Tables(0).Rows.Count > 0 Then
                Opcion = 2
                DGrid.DataSource = Nothing
                DGrid.DataSource = objDataSet1.Tables(0)

                Dim dtEmpleado As DataTable = TryCast(DGrid.DataSource, DataTable)

                For Each row As DataRow In dtEmpleado.Rows
                    Using objMySqlGral As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)
                        Try
                            Dim strRecibe1 As String
                            Dim strRecibe2 As String
                            Dim strAsigna1 As String
                            Dim strAsigna2 As String

                            objDataSetEmp = objMySqlGral.usp_TraerNomEmpleado(row("recibe"), "", "", "", "", 0)
                            If objDataSetEmp.Tables(0).Rows.Count = 1 Then
                                strRecibe1 = objDataSetEmp.Tables(0).Rows(0).Item("idempleado").ToString
                                strRecibe2 = objDataSetEmp.Tables(0).Rows(0).Item("nomcompleto").ToString

                                row("recibenom") = strRecibe1 & " - " & strRecibe2
                            End If

                            objDataSetEmp = objMySqlGral.usp_TraerNomEmpleado(row("asigna"), "", "", "", "", 0)
                            If objDataSetEmp.Tables(0).Rows.Count = 1 Then
                                strAsigna1 = objDataSetEmp.Tables(0).Rows(0).Item("idempleado").ToString
                                strAsigna2 = objDataSetEmp.Tables(0).Rows(0).Item("nomcompleto").ToString

                                row("asignanom") = strAsigna1 & " - " & strAsigna2
                            End If

                        Catch ExceptionErr As Exception
                            MessageBox.Show(ExceptionErr.Message.ToString)
                        End Try
                    End Using
                Next

                InicializaGrid()
                Btn_Regresar.Enabled = True
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Filtro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        '    Dim Estatus As String = ""
        Try
            Dim myForm As New frmFiltrosAntiBultos

            myForm.Txt_Sucursal.Text = SucursalB

            If RecibeB <> 0 Then
                myForm.Txt_Recibe.Text = RecibeB
            Else
                myForm.Txt_Recibe.Text = ""
            End If

            If AsignaB <> 0 Then
                myForm.Txt_Asigna.Text = AsignaB
            Else
                myForm.Txt_Asigna.Text = ""
            End If

            If FolioB <> 0 Then
                myForm.Txt_Folio.Text = FolioB.ToString("0000")
            Else
                myForm.Txt_Folio.Text = ""
            End If

            If tipob <> "" Then
                If tipob = "R" Then
                    myForm.Cbo_Tipo.Text = "RECIBO"
                Else
                    myForm.Cbo_Tipo.Text = "DEVOLUCIÓN"
                End If
            End If

            If StatusB <> "" Then
                If StatusB = "ZC" Then
                    myForm.Cbo_Estatus.Text = "CANCELADO"

                End If
                If StatusB = "AP" Then
                    myForm.Cbo_Estatus.Text = "APLICADO"

                End If
                If StatusB = "CA" Then
                    myForm.Cbo_Estatus.Text = "CAPTURA"
                End If

            End If


            myForm.Txt_Proveedor.Text = ProveedorB
            myForm.Txt_NoGuia.Text = NoGuiaB

            myForm.ShowDialog()

            If myForm.Sw_Filtro = False Then Exit Sub


            SucursalB = myForm.Txt_Sucursal.Text.Trim
            'FolioB = Val(myForm.Txt_Folio.Text.Trim)
            If myForm.Txt_Folio.Text.Trim <> "" Then
                FolioB = Val(pub_TraerIdFolioBulto(myForm.Txt_Folio.Text.Trim))
            End If
            ProveedorB = myForm.Txt_Proveedor.Text.Trim
            NoGuiaB = myForm.Txt_NoGuia.Text.Trim
            RecibeB = Val(myForm.Txt_Recibe.Text.Trim)
            AsignaB = Val(myForm.Txt_Asigna.Text.Trim)

            If myForm.Chk_FechaRecibo.Checked Then
                FechaRecIniB = Format(myForm.DTFecRecIni.Value, "yyyy-MM-dd")
                FechaRecFinB = Format(myForm.DTFecRecFin.Value, "yyyy-MM-dd")
            Else
                FechaRecIniB = "1900-01-01"
                FechaRecFinB = "1900-01-01"
            End If

            If myForm.Chk_FechaAsigna.Checked Then
                FechaAsigIniB = Format(myForm.DTFecAsigIni.Value, "yyyy-MM-dd")
                FechaAsigFinB = Format(myForm.DTFecAsigFin.Value, "yyyy-MM-dd")
            Else
                FechaAsigIniB = "1900-01-01"
                FechaAsigFinB = "1900-01-01"
            End If

            If myForm.Cbo_Tipo.Text <> "" Then
                If myForm.Cbo_Tipo.Text = "RECIBO" Then
                    TipoB = "R"
                Else
                    TipoB = "D"
                End If
            End If

            If myForm.Cbo_Estatus.Text <> "" Then
                If myForm.Cbo_Estatus.Text = "CANCELADO" Then
                    StatusB = "ZC"

                End If
                If myForm.Cbo_Estatus.Text = "APLICADO" Then
                    StatusB = "AP"

                End If
                If myForm.Cbo_Estatus.Text = "CAPTURA" Then
                    StatusB = "CA"
                End If
            Else
                StatusB = ""
            End If


            Opcion = 2
            Btn_Regresar.Enabled = True
            Call RellenaGrid()



        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")

            ToolTip.SetToolTip(Btn_Salir, "Salir")
            ToolTip.SetToolTip(Btn_Filtro, "Filtros")
            ToolTip.SetToolTip(Btn_Regresar, "Regresar")
            ToolTip.SetToolTip(Btn_Sucursal, "Antigüedad por Sucursal")
            ToolTip.SetToolTip(Btn_Proveedor, "Antigüedad por Proveedor")
            ToolTip.SetToolTip(Btn_Marca, "Antigüedad por Marca")
            ToolTip.SetToolTip(Btn_Eliminar, "Cancelar Bulto")

            ToolTip.SetToolTip(Btn_Regresar, "Regresar a la pantalla anterior")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub Btn_Regresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Regresar.Click
        Try
            If Opcion = 2 Then
                DGrid.DataSource = Nothing
                DGrid.DataSource = objDataSet.Tables(0)
                Opcion = 1
                Call LimpiarBusqueda()

                Call RellenaGrid()

            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Sucursal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Sucursal.Click
        Try
            OpcionSP = 1
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Proveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Proveedor.Click
        Try
            OpcionSP = 2
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Marca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Marca.Click
        Try
            OpcionSP = 3
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar.Click
        Try
            Dim myForm As New frmCatalogoReciboBultos
            myForm.Accion = 2
            myForm.Folio = DGrid.CurrentRow.Cells("idFolio").Value.ToString
            myForm.FolioB = DGrid.CurrentRow.Cells("idFolio").Value.ToString
            myForm.Txt_Folio.Text = DGrid.CurrentRow.Cells("idFoliosuc").Value.ToString

            myForm.ShowDialog()
            Call RellenaGrid()
            If myForm.Guardo = True Then
                Call RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Nuevo.Click
        Dim myForm As New frmCatalogoReciboBultos
        Try
            Dim Sucursal As String
            If GLB_Idempleado = 132Then
                Sucursal = InputBox("Especifique la tienda para el bulto", "Validación", "01")

                If (Sucursal <> "01" And Sucursal <> "02" And Sucursal <> "06" And Sucursal <> "08" And Sucursal <> "15") Then
                    MsgBox("Debe especificar una sucursal válida.", MsgBoxStyle.Critical, "Error")
                    Exit Sub
                Else
                    GLB_CveSucursal = Sucursal
                End If


            End If


            myForm.Accion = 1
            myForm.ShowDialog()
            If myForm.Guardo = True Then
                Call RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub
    Private Sub Factura_Microsip()
        'mreyes 21/Marzo/2012 11:53 a.m.
        For Each row As DataGridViewRow In DGrid.Rows
            If row.Cells("Selec").Value = True Then
                row.Cells("Selec").Value = False
            Else
                row.Cells("Selec").Value = True
            End If
        Next

    End Sub
    Private Sub Pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub

    Private Sub Btn_InvertirSeleccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_InvertirSeleccion.Click
        If Sw_NoRegistros = False Then Exit Sub
        Call Factura_Microsip()
    End Sub

    Private Sub Btn_Eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Eliminar.Click

        'mreyes 10/Febrero/2014 11:58 a.m.
        If Sw_NoRegistros = False Then Exit Sub
        '' PRIMERO TIENE QUE GENERAR EL ID DOCTO PARA GRABAR EN DOCTOS_CP
        Dim Guardo As Boolean = False
        Try


            If MsgBox("Esta seguro de querer CANCELAR los bultos seleccionados?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub
            Me.Cursor = Cursors.WaitCursor

            Dim Cont As Integer = 0
            Dim OrdeComp As String = ""
            Dim Sucursal As String = ""

            For Each row As DataGridViewRow In DGrid.Rows
                If Not IsDBNull((row.Cells("status").Value)) Then
                    If row.Cells("Selec").Value = True And row.Cells("status").Value = "CAPTURA" Then
                        Using objBultos As New BCL.BCLBulto(GLB_ConStringCipSis)
                            Guardo = objBultos.usp_Captura_Bulto(9, row.Cells("idfolio").Value, "", "", "", "", 0, 0, "", 0, "1900-01-01", 0, "1900-01-01", "", "1900-01-01", "", "1900-01-01", 0, "1900-01-01", 0, 0, 0, 0, "", "ZC", "", 0, "")
                        End Using
                        Cont = Cont + 1

                    End If ' del select  
                End If
            Next
            Me.Cursor = Cursors.Default
            MsgBox("Se han Cancelado '" & Cont & "' Bultos.", MsgBoxStyle.Information, "Confirmación")
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Consultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Consultar.Click
        Try
            Dim myForm As New frmCatalogoReciboBultos
            myForm.Accion = 3
            myForm.Folio = DGrid.CurrentRow.Cells("idFolio").Value.ToString
            myForm.FolioB = DGrid.CurrentRow.Cells("idFolio").Value.ToString
            myForm.Txt_Folio.Text = DGrid.CurrentRow.Cells("idFoliosuc").Value.ToString

            myForm.ShowDialog()
            If myForm.Guardo = True Then
                Call RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
End Class