﻿Public Class frmPpalPedBodega
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
        'mreyes 19/Abril/2017   01:38 p.m.


        Using objTrasp As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                DGrid.DataSource = Nothing
                DGrid.Visible = False
                objDataSet = objTrasp.usp_PpalPedSinVenta(FechaIniB, FechaFinB, Division, Depto, Familia, Linea, L1, L2, L3, L4, L5, L6, Marca, Modelo, idagrupacion)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    DGrid.DataSource = objDataSet.Tables(0)
                    InicializaGrid()

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
                Else
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron registros que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                End If


                Me.Cursor = Cursors.Default
                DGrid.Visible = True
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Sub InicializaGrid()
        Try
            Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
            Dim row As DataRow = dt.NewRow()

            Dim Total As Decimal = 0.0

            Total = DGrid.Rows(0).Cells("total").Value

            row(0) = ""
            row(1) = "%"
            For i As Integer = 4 To DGrid.ColumnCount - 1 ''  eran primero 3 y luego eran dos
                row(i) = Math.Round(DGrid.Rows(0).Cells(i).Value / Total, 2) * 100

            Next
            DGrid.Rows(0).Cells(2).Value = pub_SumarColumnaGrid(DGrid, 2, DGrid.RowCount - 1)

            dt.Rows.InsertAt(row, 1)
            DGrid.DataSource = dt
            'DGrid.Rows(1).DefaultCellStyle.Format = "#0.00"
            'Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
            'Dim row As DataRow = dt.NewRow()
            'row(0) = "TOTAL: "

            DGrid.RowHeadersVisible = False



            DGrid.Columns("marca").HeaderText = "Marca"
            DGrid.Columns("estilo").HeaderText = "Modelo"
            DGrid.Columns("sucursal").HeaderText = "Venta"
            DGrid.Columns("total").HeaderText = "Total"

            DGrid.Columns("sucursal").Visible = True


            DGrid.Columns("marca").Frozen = True
            DGrid.Columns("estilo").Frozen = True
            DGrid.Columns("sucursal").Frozen = True
            DGrid.Columns("total").Frozen = True


            ' DGrid.Columns(3).HeaderText = "Vta"
            DGrid.Columns(4).HeaderText = "01"
            DGrid.Columns(5).HeaderText = "01-"
            DGrid.Columns(6).HeaderText = "02"
            DGrid.Columns(7).HeaderText = "02-"
            DGrid.Columns(8).HeaderText = "03"
            DGrid.Columns(9).HeaderText = "03-"
            DGrid.Columns(10).HeaderText = "04"
            DGrid.Columns(11).HeaderText = "04-"
            DGrid.Columns(12).HeaderText = "05"
            DGrid.Columns(13).HeaderText = "05-"
            DGrid.Columns(14).HeaderText = "06"
            DGrid.Columns(15).HeaderText = "06-"
            DGrid.Columns(16).HeaderText = "07"
            DGrid.Columns(17).HeaderText = "07-"
            DGrid.Columns(18).HeaderText = "08"
            DGrid.Columns(19).HeaderText = "08-"
            DGrid.Columns(20).HeaderText = "09"
            DGrid.Columns(21).HeaderText = "09-"
            DGrid.Columns(22).HeaderText = "10"
            DGrid.Columns(23).HeaderText = "10-"


            DGrid.Columns(24).HeaderText = "11"
            DGrid.Columns(25).HeaderText = "11-"
            DGrid.Columns(26).HeaderText = "12"
            DGrid.Columns(27).HeaderText = "12-"
            DGrid.Columns(28).HeaderText = "13"
            DGrid.Columns(29).HeaderText = "13-"
            DGrid.Columns(30).HeaderText = "14"
            DGrid.Columns(31).HeaderText = "14-"
            DGrid.Columns(32).HeaderText = "15"
            DGrid.Columns(33).HeaderText = "15-"
            DGrid.Columns(34).HeaderText = "16"
            DGrid.Columns(35).HeaderText = "16-"
            DGrid.Columns(36).HeaderText = "17"
            DGrid.Columns(37).HeaderText = "17-"
            DGrid.Columns(38).HeaderText = "18"
            DGrid.Columns(39).HeaderText = "18-"
            DGrid.Columns(40).HeaderText = "19"
            DGrid.Columns(41).HeaderText = "19-"
            DGrid.Columns(42).HeaderText = "20"
            DGrid.Columns(43).HeaderText = "20-"


            DGrid.Columns(44).HeaderText = "21"
            DGrid.Columns(45).HeaderText = "21-"
            DGrid.Columns(46).HeaderText = "22"
            DGrid.Columns(47).HeaderText = "22-"
            DGrid.Columns(48).HeaderText = "23"
            DGrid.Columns(49).HeaderText = "23-"
            DGrid.Columns(50).HeaderText = "24"
            DGrid.Columns(51).HeaderText = "24-"
            DGrid.Columns(52).HeaderText = "25"
            DGrid.Columns(53).HeaderText = "25-"
            DGrid.Columns(54).HeaderText = "26"
            DGrid.Columns(55).HeaderText = "26-"
            DGrid.Columns(56).HeaderText = "27"
            DGrid.Columns(57).HeaderText = "27-"
            DGrid.Columns(58).HeaderText = "28"
            DGrid.Columns(59).HeaderText = "28-"
            DGrid.Columns(60).HeaderText = "29"
            DGrid.Columns(61).HeaderText = "29-"
            DGrid.Columns(62).HeaderText = "30"
            DGrid.Columns(63).HeaderText = "30-"
            DGrid.Columns(64).HeaderText = "31"
            DGrid.Columns(65).HeaderText = "31-"

            DGrid.Columns("total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns("marca").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns("sucursal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns("estilo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


            For i As Integer = 4 To DGrid.ColumnCount - 1 ''  eran primero 3 y luego eran dos
                DGrid.Columns(i).Visible = False

            Next
            For i As Integer = 4 To DGrid.ColumnCount - 1
                ' sumar
                ''row(i) = pub_SumarColumnaGrid(DGrid, i, DGrid.RowCount - 1)
                If DGrid.Rows(0).Cells(i).Value <> 0 Then

                    DGrid.Columns(i).Visible = True
                    DGrid.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End If

            Next
            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)


            DGrid.Rows(1).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Rows(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Rows(1).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

            DGrid.Columns("marca").DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Columns("estilo").DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Columns(2).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Columns(3).DefaultCellStyle.BackColor = Color.PowderBlue

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

    Private Sub DGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick

        CargarFotoArticulo(DGrid.Rows(DGrid.CurrentRow.Index).Cells("marca").Value, DGrid.Rows(DGrid.CurrentRow.Index).Cells("estilo").Value)

    End Sub

    Private Sub CargarFotoArticulo(ByVal Marca, ByVal Estilon)
        'mreyes 14/Marzo/2012 07:06 p.m.
        'Glb_RutaArchivoFotos
        Try
            Dim Archivo As String = ""
            Dim NoFoto As String = "1"

            MarcaFOTO = Marca
            EstiloNFOTO = Estilon

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

    Private Sub DGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.Click

        CargarFotoArticulo(DGrid.Rows(DGrid.CurrentRow.Index).Cells("marca").Value, DGrid.Rows(DGrid.CurrentRow.Index).Cells("estilo").Value)

    End Sub

    Private Sub DGrid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGrid.KeyUp

        CargarFotoArticulo(DGrid.Rows(DGrid.CurrentRow.Index).Cells("marca").Value, DGrid.Rows(DGrid.CurrentRow.Index).Cells("estilo").Value)

    End Sub

    Private Sub PBox_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PBox.DoubleClick
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
            Division = "CALZADO"
            Lbl_Leyenda.Text = Division & "\" & Depto & "\" & Familia & "\" & Linea & "\" & L1 & "\" & L2 & "\" & L3 & "\" & L4 & "\" & L5 & "\" & L6 & " Fechas : " & FechaIniB & "-" & FechaFinB
            Call RellenaGrid()
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
    Private Sub PBox_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PBox.MouseDown
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                izquierda = e.X
                alto = e.Y
                PBox.Cursor = Cursors.SizeAll
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub PBox_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PBox.MouseMove
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                PBox.Location = New Point(PBox.Left + e.X - izquierda, PBox.Top + e.Y - alto)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub PBox_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PBox.MouseUp
        Try
            PBox.Cursor = Cursors.Default
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmPpalNegBodega_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If Sw_Active = False Then
            DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            DGrid.Rows(1).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Rows(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Rows(1).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)


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
            DGrid.Columns("marca").DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Columns("estilo").DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Columns(2).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Columns(3).DefaultCellStyle.BackColor = Color.PowderBlue
            Sw_Active = True
        End If

    End Sub

    Private Sub DGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub

    Private Sub PBox_Click(sender As Object, e As EventArgs) Handles PBox.Click

    End Sub
End Class