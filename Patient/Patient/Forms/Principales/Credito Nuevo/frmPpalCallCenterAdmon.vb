Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid
Public Class frmPpalCallCenterAdmon

    'mreyes    03/Noviembre/2017    04:03 p.m.
    'Call center nivel administración


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
    Dim FechaIni As String = "1900-01-01"
    Dim FechaFin As String = "1900-01-01"
    Dim FechaPromesadoIni As String = "1900-01-01"
    Dim FechaPromesadoFin As String = "1900-01-01"
    Dim IdEmpleado As Integer = 0

    Private Sub frmPpalVencidosDias_Load(sender As Object, e As EventArgs) Handles Me.Load
        'TODO: esta línea de código carga datos en la tabla 'SirCoCreditoDataSet4.usp_PpalCallCenter' Puede moverla o quitarla según sea necesario.
        ' Me.Usp_PpalCallCenterTableAdapter.Fill(Me.SirCoCreditoDataSet4.usp_PpalCallCenter)
        'TODO: esta línea de código carga datos en la tabla 'Usp_PpalGestoria._usp_PpalGestoria' Puede moverla o quitarla según sea necesario.
        '  Me.Usp_PpalGestoriaTableAdapter.Fill(Me.Usp_PpalGestoria._usp_PpalGestoria)
        Sw_Load = True
        Call GenerarToolTip()
        Sw_Pintar = True
        Sw_Load = True

        Call LimpiarBusqueda()

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
        'mreyes 26/Octubre/2017     04:55 p.m.

        DGrid1.Visible = False
        InicializaGrid()
        Using objTrasp As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                Sw_Load = False
                'DGrid.ReadOnly = True
                ' GridControl.DataSource = Nothing

                objDataSet = objTrasp.usp_PpalCallCenterAdmon(FechaIni, FechaFin, FechaPromesadoIni, FechaPromesadoFin, IdEmpleado)


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
        '  myForm1.r_Titulo = "Fecha Vencido :" & Format(DateEdit1.EditValue, "dd/MM/yyyy")
        myForm1.Text = "Listado de Saldos Vencidos con Dirección"
        myForm1.ReportIndex = 6001
        myForm1.Show()

        Dim myForm As New frmReportsBrowser

        myForm.objDataSetPpalVencidoDias = GenerarReporteVencidoDias()
        ' myForm.objDataSetPpalVencidoDireccion = myForm.objDataSetPpalVencidoDias.Copy
        'myForm.r_Titulo = "Fecha Vencido :" & Format(DateEdit1.EditValue, "dd/MM/yyyy")
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


    Private Sub SaveFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk

    End Sub

    Private Sub Btn_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Excel.Click
        If sfdRuta.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            DGrid1.ExportToXls(sfdRuta.FileName)
        End If
    End Sub

    Private Sub DateEdit1_EditValueChanged(sender As Object, e As EventArgs)
        If Sw_Load = False Then
            Call RellenaGrid()
        End If
    End Sub

    Private Sub DateEdit1_LostFocus(sender As Object, e As EventArgs)

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




    Private Sub Btn_FTP_Click(sender As Object, e As EventArgs)
        My.Computer.Network.UploadFile("c:\gestoria.xls", "ftp://home587140532.1and1-data.host/gestoria.xls", "u81839252-credito", "ZT_Sirco33")
    End Sub



    Private Sub DGrid1_DoubleClick(sender As Object, e As EventArgs) Handles DGrid1.DoubleClick
        Try

            Dim Myform As New frmCatalogoCallCenter
            Dim Renglon As Point = DGrid1.PointToClient(Control.MousePosition)
            Dim info As GridHitInfo = GridView1.CalcHitInfo(Renglon)

            Dim Renglon1 As Integer = info.RowHandle

            Myform.Accion = 4
            Myform.Distrib = GridView1.GetRowCellValue(Renglon1, "distrib")
            Myform.Txt_Adeudo.Text = GridView1.GetRowCellValue(Renglon1, "adeudo")
            Myform.Mem_Comentarios.Text = GridView1.GetRowCellValue(Renglon1, "comentarios")
            Myform.Dt_Promesado.Text = GridView1.GetRowCellValue(Renglon1, "fechapromesado")
            Myform.StartPosition = FormStartPosition.CenterScreen
            Myform.ShowDialog()
            '  Call RellenaGrid()


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    'Private Sub GridView1_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GridView1.RowStyle
    '    Try
    '        Dim View As GridView = sender
    '        If (e.RowHandle >= 0) Then
    '            Dim concepto As Integer = (View.GetRowCellDisplayText(e.RowHandle, View.Columns("Campo2")))
    '            If concepto = 1 Then
    '                '' el concepto 1 es que ya se hablo el dia actual
    '                '' el concepto 2 es que hay que hablarle.

    '                ' e.Appearance.BackColor = Color.Aqua
    '                e.Appearance.BackColor = Color.Gold
    '                e.Appearance.BackColor2 = Color.SeaShell
    '                'e.Appearance.Font = New Font(Font.FontFamily, 2, FontStyle.Bold)
    '                e.Appearance.BorderColor = Color.Red


    '                'New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
    '                ' e.Appearance.BackColor2 = Color.SeaShell
    '            End If

    '            If concepto = 2 Then
    '                '' el concepto 1 es que ya se hablo el dia actual
    '                '' el concepto 2 es que hay que hablarle.

    '                ' e.Appearance.BackColor = Color.Aqua
    '                e.Appearance.BackColor = Color.Red
    '                e.Appearance.BackColor2 = Color.SeaShell
    '                'e.Appearance.Font = New Font(Font.FontFamily, 2, FontStyle.Bold)
    '                e.Appearance.BorderColor = Color.Red


    '                'New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
    '                ' e.Appearance.BackColor2 = Color.SeaShell
    '            End If
    '        End If
    '    Catch ExceptionErr As Exception
    '        MessageBox.Show(ExceptionErr.Message.ToString)
    '    End Try
    'End Sub

    Private Sub DGrid1_Click(sender As Object, e As EventArgs) Handles DGrid1.Click

    End Sub
End Class