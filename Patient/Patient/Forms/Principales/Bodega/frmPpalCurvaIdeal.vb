Public Class frmPpalCurvaIdeal
    'mreyes 25/Abril/2017   10:46 a.m.

    Private objDataSet As Data.DataSet
    Private objDataSet1 As Data.DataSet 'Segundo Nivel


    Dim FechaFinB As String = "1900-01-01"
    Dim FechaIniB As String = "1900-01-01"
    Dim SucursalB As String = ""




    Dim EstatusB As String = "1900-01-01"
    Dim TraspasoIniB As String = "1900-01-01"
    Dim TraspasoFinB As String = "1900-01-01"
    Dim Opcion As Integer

    Dim MarcaFOTO As String = ""
    Dim EstiloNFOTO As String = ""
    Dim blnEntraDet As Boolean = False

    Private izquierda As Integer = 0
    Private alto As Integer = 0
    Dim Sw_Load As Boolean = False
    Dim Sw_Active As Boolean = False

    Public Sucursal As String = ""
    Public Division As String = ""

    Public Depto As String = ""
    Public Familia As String = ""
    Public Linea As String = ""
    Public L1 As String = ""
    Public L2 As String = ""
    Public L3 As String = ""
    Public L4 As String = ""
    Public L5 As String = ""
    Public L6 As String = ""
    Public Marca As String = ""
    Public Modelo As String = ""
    Dim idagrupacion As Integer = 0
    Dim Sw_NoRegistros As Boolean = False

    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Filtro, "Búsqueda Avanzada")
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel ko")

            ToolTip.SetToolTip(Btn_Salir, "Salir")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub RellenaGrid()
        'mreyes 12/Abril/2017   06:48 p.m.

        Using objTrasp As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                DGrid.DataSource = Nothing
                DGrid.Visible = False
                DGrid2.Visible = False
                DGrid2.DataSource = Nothing
                Panel1.Visible = True
                PictureBox2.Visible = True


                Application.DoEvents()

                objDataSet = objTrasp.usp_PpalCurvaIdeal(Sucursal, FechaIniB, FechaFinB, Division, Depto, Familia, Linea, L1, L2, L3, L4, L5, L6, Marca, Modelo, idagrupacion)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    DGrid.DataSource = objDataSet.Tables(0)
                    InicializaGrid(DGrid)
                    DGrid2.DataSource = objDataSet.Tables(1)
                    InicializaGrid(DGrid2)

                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True
                    For i As Integer = 2 To DGrid.Rows.Count - 1
                        For j As Integer = 4 To DGrid.Columns.Count - 1
                            If DGrid.Columns(j).Visible = True Then
                                If DGrid.Rows(i).Cells(j).Value = 0 Then
                                    DGrid.Rows(i).Cells(j).Style.ForeColor = Color.White
                                    DGrid.Rows(i).DefaultCellStyle.BackColor = Color.White
                                End If
                            End If
                        Next
                    Next
                    sw_noregistros = True
                Else
                    Me.Cursor = Cursors.Default
                    Sw_NoRegistros = False
                    MsgBox("No se encontraron registros que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False

                End If


                Me.Cursor = Cursors.Default
                Panel1.Visible = False
                DGrid.Visible = True
                DGrid2.Visible = True
                Application.DoEvents()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Sub InicializaGrid(dgridformato As DataGridView)
        Try
            'Dim dt As DataTable = TryCast(dgridformato.DataSource, DataTable)
            'Dim row As DataRow = dt.NewRow()
            'Dim Total As Decimal = 0.0

            'Total = dgridformato.Rows(0).Cells("total").Value

            'row(0) = ""
            'row(1) = "%"
            'For i As Integer = 4 To dgridformato.ColumnCount - 1 ''  eran primero 3 y luego eran dos
            '    row(i) = Math.Round(dgridformato.Rows(0).Cells(i).Value / Total, 2) * 100

            'Next


            'dt.Rows.InsertAt(row, 1)
            'dgridformato.DataSource = dt

            dgridformato.RowHeadersVisible = False



            dgridformato.Columns("marca").HeaderText = "Marca"
            dgridformato.Columns("estilo").HeaderText = ""
            dgridformato.Columns("sucursal").HeaderText = "Det"
            dgridformato.Columns("total").HeaderText = "Total"

            dgridformato.Columns("sucursal").Visible = False


            dgridformato.Columns("marca").Frozen = True
            dgridformato.Columns("estilo").Frozen = True
            dgridformato.Columns("sucursal").Frozen = True
            dgridformato.Columns("total").Frozen = True

            dgridformato.Columns("marca").Visible = False


            dgridformato.Columns(4).HeaderText = "01"
            dgridformato.Columns(5).HeaderText = "01-"
            dgridformato.Columns(6).HeaderText = "02"
            dgridformato.Columns(7).HeaderText = "02-"
            dgridformato.Columns(8).HeaderText = "03"
            dgridformato.Columns(9).HeaderText = "03-"
            dgridformato.Columns(10).HeaderText = "04"
            dgridformato.Columns(11).HeaderText = "04-"
            dgridformato.Columns(12).HeaderText = "05"
            dgridformato.Columns(13).HeaderText = "05-"
            dgridformato.Columns(14).HeaderText = "06"
            dgridformato.Columns(15).HeaderText = "06-"
            dgridformato.Columns(16).HeaderText = "07"
            dgridformato.Columns(17).HeaderText = "07-"
            dgridformato.Columns(18).HeaderText = "08"
            dgridformato.Columns(19).HeaderText = "08-"
            dgridformato.Columns(20).HeaderText = "09"
            dgridformato.Columns(21).HeaderText = "09-"
            dgridformato.Columns(22).HeaderText = "10"
            dgridformato.Columns(23).HeaderText = "10-"


            dgridformato.Columns(24).HeaderText = "11"
            dgridformato.Columns(25).HeaderText = "11-"
            dgridformato.Columns(26).HeaderText = "12"
            dgridformato.Columns(27).HeaderText = "12-"
            dgridformato.Columns(28).HeaderText = "13"
            dgridformato.Columns(29).HeaderText = "13-"
            dgridformato.Columns(30).HeaderText = "14"
            dgridformato.Columns(31).HeaderText = "14-"
            dgridformato.Columns(32).HeaderText = "15"
            dgridformato.Columns(33).HeaderText = "15-"
            dgridformato.Columns(34).HeaderText = "16"
            dgridformato.Columns(35).HeaderText = "16-"
            dgridformato.Columns(36).HeaderText = "17"
            dgridformato.Columns(37).HeaderText = "17-"
            dgridformato.Columns(38).HeaderText = "18"
            dgridformato.Columns(39).HeaderText = "18-"
            dgridformato.Columns(40).HeaderText = "19"
            dgridformato.Columns(41).HeaderText = "19-"
            dgridformato.Columns(42).HeaderText = "20"
            dgridformato.Columns(43).HeaderText = "20-"


            dgridformato.Columns(44).HeaderText = "21"
            dgridformato.Columns(45).HeaderText = "21-"
            dgridformato.Columns(46).HeaderText = "22"
            dgridformato.Columns(47).HeaderText = "22-"
            dgridformato.Columns(48).HeaderText = "23"
            dgridformato.Columns(49).HeaderText = "23-"
            dgridformato.Columns(50).HeaderText = "24"
            dgridformato.Columns(51).HeaderText = "24-"
            dgridformato.Columns(52).HeaderText = "25"
            dgridformato.Columns(53).HeaderText = "25-"
            dgridformato.Columns(54).HeaderText = "26"
            dgridformato.Columns(55).HeaderText = "26-"
            dgridformato.Columns(56).HeaderText = "27"
            dgridformato.Columns(57).HeaderText = "27-"
            dgridformato.Columns(58).HeaderText = "28"
            dgridformato.Columns(59).HeaderText = "28-"
            dgridformato.Columns(60).HeaderText = "29"
            dgridformato.Columns(61).HeaderText = "29-"
            dgridformato.Columns(62).HeaderText = "30"
            dgridformato.Columns(63).HeaderText = "30-"
            dgridformato.Columns(64).HeaderText = "31"
            dgridformato.Columns(65).HeaderText = "31-"

            dgridformato.Columns("total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgridformato.Columns("marca").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgridformato.Columns("estilo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


            For i As Integer = 4 To dgridformato.ColumnCount - 1 ''  eran primero 3 y luego eran dos
                dgridformato.Columns(i).Visible = False

            Next
            For i As Integer = 4 To dgridformato.ColumnCount - 1
                ' sumar
                ''row(i) = pub_SumarColumnaGrid(dgridformato, i, dgridformato.RowCount - 1)
                If dgridformato.Rows(0).Cells(i).Value <> 0 Then

                    dgridformato.Columns(i).Visible = True
                    dgridformato.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End If

            Next
            dgridformato.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            dgridformato.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
            dgridformato.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgridformato.Rows(0).DefaultCellStyle.Font = New Font(dgridformato.DefaultCellStyle.Font.FontFamily, dgridformato.DefaultCellStyle.Font.Size, FontStyle.Bold)



            dgridformato.Columns("marca").DefaultCellStyle.BackColor = Color.PowderBlue
            dgridformato.Columns("estilo").DefaultCellStyle.BackColor = Color.PowderBlue
            dgridformato.Columns(2).DefaultCellStyle.BackColor = Color.PowderBlue
            dgridformato.Columns(3).DefaultCellStyle.BackColor = Color.PowderBlue

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

    Private Sub Btn_Filtro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        Try
            Dim myFormFiltros As New frmFiltrosNegBodega

            myFormFiltros.StartPosition = FormStartPosition.CenterParent
            myFormFiltros.Sw_Filtro = False


            'myFormFiltros.CB_Sucursal.Visible = False
            myFormFiltros.Suc = Sucursal
            'myFormFiltros.Label4.Visible = False

            Division = "CALZADO"
            If Division <> "" Then
                If Division = "CALZADO" Then
                    myFormFiltros.Txt_Division.Text = "001"
                ElseIf Division = "ACCESORIOS" Then
                    myFormFiltros.Txt_Division.Text = "002"
                ElseIf Division = "ELECTRONICA" Then
                    myFormFiltros.Txt_Division.Text = "003"
                ElseIf Division = "GENERAL" Then
                    myFormFiltros.Txt_Division.Text = "999"
                End If
                myFormFiltros.Txt_DescripDivision.Text = Division
            Else
                myFormFiltros.Txt_DescripDivision.Text = ""
                myFormFiltros.Txt_Division.Text = ""
            End If
            If Depto <> "" Then
                myFormFiltros.Txt_IdDepto.Text = Depto
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstDepto(0, 0, "", 0, Depto)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_DescripDepto.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                    myFormFiltros.Txt_Depto.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                End If
            End If
            If Familia <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstFamilia(0, 0, 0, "", 3, Familia)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_Familia.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripFamilia.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If Linea <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstLinea(0, 0, 0, 0, "", 3, Linea)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_Linea.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripLinea.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L1 <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl1(0, 0, 0, 0, 0, "", 3, L1)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_L1.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripL1.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L2 <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl2(0, 0, 0, 0, 0, 0, "", 3, L2)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_L2.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripL2.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L3 <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl3(0, 0, 0, 0, 0, 0, 0, "", 3, L3)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_L3.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripL3.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L4 <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl4(0, 0, 0, 0, 0, 0, 0, 0, "", 3, L4)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_L4.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripL4.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L5 <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl5(0, 0, 0, 0, 0, 0, 0, 0, 0, "", 3, L5)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_L5.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripL5.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L6 <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl6(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", 3, L6)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_L6.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripL6.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If Marca <> "" Then
                myFormFiltros.Txt_Marca.Text = Marca
            End If

            If FechaIniB <> "1900-01-01" Then
                myFormFiltros.Chk_FechaTraspaso.Checked = True
                myFormFiltros.DTPicker2.Value = FechaIniB
                myFormFiltros.DTPicker3.Value = FechaFinB
            End If

            If idagrupacion <> 0 Then
                myFormFiltros.Txt_Agrupacion.Text = idagrupacion
            End If
            myFormFiltros.ShowDialog()

            If myFormFiltros.Sw_Filtro = True Then
                DGrid.DataSource = Nothing
                DGrid.Refresh()
                DGrid.Rows.Clear()

                'If CInt(myFormFiltros.CB_Sucursal.SelectedValue.ToString) = 0 Then
                '    Sucursal = ""
                'Else
                '    Sucursal = pub_RellenarIzquierda(myFormFiltros.CB_Sucursal.SelectedValue.ToString, 2)
                '    DescripSucursal = myFormFiltros.CB_Sucursal.Text
                'End If

                ' fecha ultimo recibo
                If Val(myFormFiltros.Txt_Agrupacion.Text) > 0 Then
                    idagrupacion = Val(myFormFiltros.Txt_Agrupacion.Text)
                End If

                Marca = myFormFiltros.Txt_Marca.Text


                If myFormFiltros.Txt_DescripDivision.Text.Trim = "" Then
                    Division = ""
                Else
                    Division = myFormFiltros.Txt_DescripDivision.Text
                End If
                If myFormFiltros.Txt_DescripDepto.Text.Trim = "" Then
                    Depto = ""
                Else
                    Depto = myFormFiltros.Txt_DescripDepto.Text
                End If
                If myFormFiltros.Txt_DescripFamilia.Text = "" Then
                    Familia = ""
                Else
                    Familia = myFormFiltros.Txt_DescripFamilia.Text
                End If
                If myFormFiltros.Txt_DescripLinea.Text = "" Then
                    Linea = ""
                Else
                    Linea = myFormFiltros.Txt_DescripLinea.Text
                End If
                If myFormFiltros.Txt_DescripL1.Text = "" Then
                    L1 = ""
                Else
                    L1 = myFormFiltros.Txt_DescripL1.Text
                End If
                If myFormFiltros.Txt_DescripL2.Text = "" Then
                    L2 = ""
                Else
                    L2 = myFormFiltros.Txt_DescripL2.Text
                End If
                If myFormFiltros.Txt_DescripL3.Text = "" Then
                    L3 = ""
                Else
                    L3 = myFormFiltros.Txt_DescripL3.Text
                End If
                If myFormFiltros.Txt_DescripL4.Text = "" Then
                    L4 = ""
                Else
                    L4 = myFormFiltros.Txt_DescripL4.Text
                End If
                If myFormFiltros.Txt_DescripL5.Text = "" Then
                    L5 = ""
                Else
                    L5 = myFormFiltros.Txt_DescripL5.Text
                End If
                If myFormFiltros.Txt_DescripL6.Text = "" Then
                    L6 = ""
                Else
                    L6 = myFormFiltros.Txt_DescripL6.Text
                End If

                If myFormFiltros.Chk_FechaTraspaso.Checked = True Then
                    FechaIniB = Format(myFormFiltros.DTPicker2.Value, "yyyy-MM-dd")
                    FechaFinB = Format(myFormFiltros.DTPicker3.Value, "yyyy-MM-dd")
                Else
                    FechaIniB = "1900-01-01"
                    FechaFinB = "1900-01-01"

                End If

                Lbl_Leyenda.Text = Division & "\" & Depto & "\" & Familia & "\" & Linea & "\" & L1 & "\" & L2 & "\" & L3 & "\" & L4 & "\" & L5 & "\" & L6 & " Fechas : " & FechaIniB & "-" & FechaFinB

                Call RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub PBox_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        'mreyes 03/Marzo/2012 10:01 a.m.
        Try
            Dim myForm As New frmConsultaImagen
            myForm.Txt_Estilon.Text = EstiloNFOTO
            myForm.Txt_Marca.Text = MarcaFOTO
            myForm.Txt_NoFoto.Text = 1
            myForm.ShowDialog()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmPpalPpalTraspasosAutomatico_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Sw_Load = True
            Call GenerarToolTip()
            Call LimpiarBusqueda()
            '  Call RellenaGrid()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim myForm As New frmReportsBrowser

            myForm.objDataSetPediNegados = GenerarPedNegados()
            myForm.ReportIndex = 5518
            myForm.Show()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)

        End Try
    End Sub

    Public Function GenerarPedNegados() As DSPedidosNegados
        Try
            Dim cont As Integer = 0
            GenerarPedNegados = New DSPedidosNegados

            For i As Integer = 0 To DGrid.RowCount - 2

                cont = 0
                Dim objDataRow1 As Data.DataRow = GenerarPedNegados.Tables("Tbl_PedidosNegados").NewRow()
                objDataRow1.Item("descrip") = DGrid.Rows(i).Cells("descrip").Value.ToString
                objDataRow1.Item("fecha") = DGrid.Rows(i).Cells("fecha").Value.ToString
                objDataRow1.Item("marca") = DGrid.Rows(i).Cells("marca").Value.ToString
                objDataRow1.Item("estilo") = DGrid.Rows(i).Cells("estilo").Value.ToString
                objDataRow1.Item("medida") = DGrid.Rows(i).Cells("medida").Value.ToString

                GenerarPedNegados.Tables("Tbl_PedidosNegados").Rows.Add(objDataRow1)

                'Val(objDataRow1.Item("")=DGrid.Rows(i).Cells("").Value)

            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)

        End Try
    End Function

    Private Sub LimpiarBusqueda()
        If GLB_CveSucursal = "01" Or GLB_CveSucursal = "02" Or GLB_CveSucursal = "06" Or GLB_CveSucursal = "07" Or GLB_CveSucursal = "08" Or GLB_CveSucursal = "11" Or GLB_CveSucursal = "15" Then
            SucursalB = GLB_CveSucursal
        Else
            SucursalB = ""
        End If



        FechaIniB = Format(Now.Add(New TimeSpan(-1, 0, 0, 0)), "yyyy-MM-dd")
        FechaFinB = Format(Now.Add(New TimeSpan(-1, 0, 0, 0)), "yyyy-MM-dd")

    End Sub


    Private Sub frmPpalNegBodega_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        'If Sw_Active = False Then
        '    'DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
        '    'DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        '    'DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
        '    'DGrid.Rows(1).DefaultCellStyle.BackColor = Color.PowderBlue
        '    'DGrid.Rows(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        '    'DGrid.Rows(1).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)


        '    'For i As Integer = 2 To DGrid.Rows.Count - 1
        '    '    For j As Integer = 4 To DGrid.Columns.Count - 1
        '    '        If DGrid.Columns(j).Visible = True Then
        '    '            If DGrid.Rows(i).Cells(j).Value = 0 Then
        '    '                DGrid.Rows(i).Cells(j).Style.ForeColor = Color.White
        '    '                DGrid.Rows(i).DefaultCellStyle.BackColor = Color.White
        '    '            End If
        '    '        End If
        '    '    Next
        '    'Next
        '    DGrid.Columns("marca").DefaultCellStyle.BackColor = Color.PowderBlue
        '    DGrid.Columns("estilo").DefaultCellStyle.BackColor = Color.PowderBlue
        '    DGrid.Columns(2).DefaultCellStyle.BackColor = Color.PowderBlue
        '    DGrid.Columns(3).DefaultCellStyle.BackColor = Color.PowderBlue
        '    Sw_Active = True
        'End If

        If Sw_NoRegistros = True Then
            DGrid.Columns("marca").DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Columns("estilo").DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Columns(2).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Columns(3).DefaultCellStyle.BackColor = Color.PowderBlue
        End If

    End Sub

    Private Sub DGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub

    Private Sub frmPpalCurvaIdeal_ForeColorChanged(sender As Object, e As EventArgs) Handles Me.ForeColorChanged

    End Sub

    Private Sub Txt_Leyenda_TextChanged(sender As Object, e As EventArgs) Handles Txt_Leyenda.TextChanged

    End Sub

    Private Sub Pnl_Botones_Paint(sender As Object, e As PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub
End Class