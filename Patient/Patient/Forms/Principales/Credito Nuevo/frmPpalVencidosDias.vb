Public Class frmPpalVencidosDias

    Private objDataSet As Data.DataSet
    Private objDataSet1 As Data.DataSet 'Segundo Nivel
    Dim SucurOriB As Integer = 0
    Dim SucurDesB As Integer = 0
    Dim FechaInib As String
    Dim FechaFinb As String

    Dim Sw_Load As Boolean = True
    Dim Sw_NoRegistros As Boolean = False
    Dim Sw_Pintar As Boolean = False
    Public Opcion As Integer = 0   '1 = Enviado,  2 = Por Recibir
    Public OpcionSP As Integer = 0
    Dim MarcaFOTO As String = ""
    Dim EstiloNFOTO As String = ""
    Dim blnEntraDet As Boolean = False

    Dim IdProTrasB As Integer = 0
    Dim EstatusB As String = ""
    Private izquierda As Integer = 0
    Private alto As Integer = 0
    'Dim myFormFiltros As frmFiltrosAparadorReal
    Dim sw_liq As Boolean = False

    '-- filtros
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
    Public IdAgrupacion As Integer = 0
    Private Sub frmPpalVencidosDias_Load(sender As Object, e As EventArgs) Handles Me.Load
        Sw_Load = True
        Call GenerarToolTip()
        Sw_Pintar = True
        Sw_Load = True

        Call LimpiarBusqueda()
        DateEdit1.EditValue = DateAdd("d", -1, GLB_FechaHoy)
        Call RellenaGrid()


    End Sub

    Private Sub Pnl_Botones_Paint(sender As Object, e As PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub
    Private Sub GenerarToolTip()
        Try


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub LimpiarBusqueda()

        If GLB_CveSucursal = "01" Or GLB_CveSucursal = "02" Or GLB_CveSucursal = "06" Or GLB_CveSucursal = "07" Or GLB_CveSucursal = "08" Or GLB_CveSucursal = "11" Then
            If Opcion = 1 Then
                SucurOriB = GLB_CveSucursal
            ElseIf Opcion = 2 Then
                SucurOriB = GLB_CveSucursal
            End If
        Else
            SucurOriB = 0
            SucurDesB = 0
        End If

        FechaInib = "1900-01-01"
        FechaFinb = "1900-01-01"


    End Sub

    Private Sub RellenaGrid()
        'mreyes 19/Julio/2017   05:07 p.m.
        Dim Fecha As Date = "1900-01-01"

        'If DateEdit1.EditValue <> "" Then
        Fecha = DateEdit1.EditValue
        'End If
        DGrid1.Visible = False
        'InicializaGrid()
        Using objTrasp As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                Sw_Load = False
                'DGrid.ReadOnly = True
                ' GridControl.DataSource = Nothing

                objDataSet = objTrasp.usp_PpalVencidoDias(CDate(Fecha))


                'Populate the Project Details section

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section 
                    'DGrid.ColumnCount = objDataSet.Tables(0).Columns.Count
                    '
                    DGrid1.DataSource = objDataSet.Tables(0)

                    InicializaGrid()

                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True
                    Sw_NoRegistros = True
                    Sw_Pintar = True
                Else

                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron registros que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                End If
                Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()
                DGrid1.Visible = True
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Sub InicializaGrid()
        'GridView1
        Try
            GridView1.BestFitColumns()
            If Chk_Direccion.Checked = True Then
                GridView1.Columns(4).Visible = True
                GridView1.Columns(5).Visible = True
                GridView1.Columns(3).Visible = True
                GridView1.Columns(2).Visible = True
            Else

                GridView1.Columns(4).Visible = False

                GridView1.Columns(5).Visible = False
                GridView1.Columns(3).Visible = False
                GridView1.Columns(2).Visible = False
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
        'GridView.BestFitColumns or GridColumn.BestFit 
    End Sub

    Private Sub Btn_Imprimir_Click(sender As Object, e As EventArgs) Handles Btn_Imprimir.Click
        ' DGrid1.ExportToPdf("c:\equis.pdf")
        'DGrid1.ExportToHtml("c:\prueba.htm")

        'mreyes 24/Julio/2017   11:51 a.m.
        Dim myForm1 As New frmReportsBrowser

        myForm1.objDataSetPpalVencidoDias = GenerarReporteVencidoDias()
        myForm1.r_Titulo = "Fecha Vencido :" & Format(DateEdit1.EditValue, "dd/MM/yyyy")
        myForm1.Text = "Listado de Saldos Vencidos con Dirección"
        myForm1.ReportIndex = 6001
        myForm1.Show()

        Dim myForm As New frmReportsBrowser

        myForm.objDataSetPpalVencidoDias = GenerarReporteVencidoDias()
        ' myForm.objDataSetPpalVencidoDireccion = myForm.objDataSetPpalVencidoDias.Copy
        myForm.r_Titulo = "Fecha Vencido :" & Format(DateEdit1.EditValue, "dd/MM/yyyy")
        myForm.Text = "Listado de Saldos Vencidos"
        myForm.ReportIndex = 6000
        myForm.Show()





    End Sub
    Private Function GenerarReporteVencidoDias() As DSVencidoDias
        'mreyes 24/Julio/2017   11:50 a.m.
        Try
            GenerarReporteVencidoDias = New DSVencidoDias
            With GridView1
                For I As Integer = 0 To .RowCount - 1

                    Dim objDataRow As Data.DataRow = GenerarReporteVencidoDias.Tables(0).NewRow()
                    objDataRow.Item("Distrib") = .GetRowCellValue(I, "Distrib").ToString.Trim
                    objDataRow.Item("Nombre") = .GetRowCellValue(I, "Nombre").ToString.Trim
                    objDataRow.Item("status") = .GetRowCellValue(I, "status").ToString.Trim
                    objDataRow.Item("frecuen") = .GetRowCellValue(I, "frecuen").ToString.Trim
                    objDataRow.Item("direccion") = .GetRowCellValue(I, "Direccion").ToString.Trim
                    objDataRow.Item("Telefono1") = .GetRowCellValue(I, "Telefono1").ToString.Trim
                    objDataRow.Item("Aval") = .GetRowCellValue(I, "aval").ToString.Trim
                    objDataRow.Item("Compras") = Val(.GetRowCellValue(I, "compras").ToString)
                    objDataRow.Item("porpagar") = Val(.GetRowCellValue(I, "porpagar").ToString)
                    objDataRow.Item("vencido") = Val(.GetRowCellValue(I, "vencido").ToString)
                    objDataRow.Item("dias_14") = Val(.GetRowCellValue(I, "dias_14").ToString)
                    objDataRow.Item("dias_29") = Val(.GetRowCellValue(I, "dias_29").ToString)
                    objDataRow.Item("dias_44") = Val(.GetRowCellValue(I, "dias_44").ToString)
                    objDataRow.Item("dias_59") = Val(.GetRowCellValue(I, "dias_59").ToString)
                    objDataRow.Item("dias_60") = Val(.GetRowCellValue(I, "dias_60").ToString)
                    objDataRow.Item("ultpago") = Val(.GetRowCellValue(I, "ultpago").ToString)
                    objDataRow.Item("ultfechapago") = Format(CDate(.GetRowCellValue(I, "ultfechapago").ToString.Trim), "dd/MM/yyyy")
                    '        objDataRow.Item("ultfechapago") = .GetRowCellValue(I, "ultfechapago").ToString.Trim
                    objDataRow.Item("campo1") = .GetRowCellValue(I, "Campo1").ToString.Trim
                    objDataRow.Item("campo2") = Val(.GetRowCellValue(I, "Campo2").ToString)
                    objDataRow.Item("campo3") = .GetRowCellValue(I, "Campo3").ToString.Trim
                    objDataRow.Item("campo4") = .GetRowCellValue(I, "Campo4").ToString.Trim
                    objDataRow.Item("campo5") = .GetRowCellValue(I, "Campo5").ToString.Trim




                    GenerarReporteVencidoDias.Tables(0).Rows.Add(objDataRow)
                Next

            End With
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function
    Private Sub Chk_Direccion_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Direccion.CheckedChanged
        If Chk_Direccion.Checked = True Then

            GridView1.Columns(4).Visible = True

            GridView1.Columns(5).Visible = True
            GridView1.Columns(3).Visible = True
            GridView1.Columns(2).Visible = True
        Else

            GridView1.Columns(4).Visible = False

            GridView1.Columns(5).Visible = False
            GridView1.Columns(3).Visible = False
            GridView1.Columns(2).Visible = False
        End If
    End Sub

    Private Sub SaveFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk

    End Sub

    Private Sub Btn_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Excel.Click
        If sfdRuta.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            DGrid1.ExportToXls(sfdRuta.FileName)
        End If
    End Sub

    Private Sub DateEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles DateEdit1.EditValueChanged
        If Sw_Load = False Then
            Call RellenaGrid()
        End If
    End Sub

    Private Sub DateEdit1_LostFocus(sender As Object, e As EventArgs) Handles DateEdit1.LostFocus

    End Sub

    Private Sub Btn_Salir_Click(sender As Object, e As EventArgs) Handles Btn_Salir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub frmPpalVencidosDias_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub DGrid1_Click(sender As Object, e As EventArgs) Handles DGrid1.Click

    End Sub
End Class