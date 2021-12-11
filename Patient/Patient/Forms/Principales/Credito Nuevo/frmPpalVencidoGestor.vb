Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid
Public Class frmPpalVencidoGestor
    'mreyes     29/Noviembre/2017   01:32 p.m.
    ' tabla vencido


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

    Dim blnEntraDet As Boolean = False

    Dim EstatusB As String = ""
    Private izquierda As Integer = 0
    Private alto As Integer = 0
    'Dim myFormFiltros As frmFiltrosAparadorReal
    Dim sw_liq As Boolean = False


    Private Sub frmPpalVencidosDias_Load(sender As Object, e As EventArgs) Handles Me.Load
        'TODO: esta línea de código carga datos en la tabla 'Usp_PpalVencidoxAnio._usp_PpalVencidoxAnio' Puede moverla o quitarla según sea necesario.
        ' Me.Usp_PpalVencidoxAnioTableAdapter.Fill(Me.Usp_PpalVencidoxAnio._usp_PpalVencidoxAnio)
        ''TODO: esta línea de código carga datos en la tabla 'Usp_PpalVencido._usp_PpalVencido' Puede moverla o quitarla según sea necesario.
        'Me.Usp_PpalVencidoTableAdapter.Fill(Me.Usp_PpalVencido._usp_PpalVencido)
        'TODO: esta línea de código carga datos en la tabla 'Usp_PpalGestoria._usp_PpalGestoria' Puede moverla o quitarla según sea necesario.
        '  Me.Usp_PpalGestoriaTableAdapter.Fill(Me.Usp_PpalGestoria._usp_PpalGestoria)
        Sw_Load = True
        Call GenerarToolTip()
        Sw_Pintar = True
        Sw_Load = True

        Lbl_Leyenda.Text = GLB_Idempleado & "-" & GLB_NomUsuario
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
        'mreyes 28/Noviembre/2017   12:12 p.m.

        DGrid1.Visible = False
        InicializaGrid()
        Using objTrasp As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                Sw_Load = False
                'DGrid.ReadOnly = True
                ' GridControl.DataSource = Nothing

                objDataSet = objTrasp.usp_PpalVencidoGestor(GLB_Idempleado)
                'Populate the Project Details section

                If objDataSet.Tables(0).Rows.Count > 0 Then
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
                    MsgBox("La información se esta actualizando, favor de esperar o intentarlo más tarde.", MsgBoxStyle.Critical, "Aviso")
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


    Private Sub Chk_Direccion_CheckedChanged(sender As Object, e As EventArgs)

        GridView1.BestFitColumns()

    End Sub



    Private Sub Btn_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Excel.Click
        If sfdRuta.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            DGrid1.ExportToXls(sfdRuta.FileName)
        End If
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





    Private Sub Btn_Asignar_Click(sender As Object, e As EventArgs) Handles Btn_Asignar.Click
        Try

            Dim Gestor As String = ""


            Gestor = GLB_Idempleado



            Dim Distrib As String = ""


            '''----
            Dim Rows As New ArrayList()
            ' Add the selected rows to the list.
            Dim I As Integer
            For I = 0 To GridView1.SelectedRowsCount() - 1
                If (GridView1.GetSelectedRows()(I) >= 0) Then
                    GridView1.SetRowCellValue(GridView1.GetSelectedRows()(I), "campo1", Gestor)
                    Distrib = GridView1.GetRowCellValue(GridView1.GetSelectedRows()(I), "distrib").ToString.Trim

                    'GridView1.SetRowCellValue(I, "Campo4", Gestor)
                    Using objTrasp As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                        If objTrasp.usp_Captura_RutaGestor(1, GLB_FechaHoy, Distrib, GLB_Idempleado) Then

                        End If
                    End Using



                End If
            Next

            '' Guardar el gestor asignado, por la fecha.
            Call Btn_Imprimir_Click(sender, e)
            GridView1.BestFitColumns()
            Call RellenaGrid()

            ''IMPRIMIR TODOS LOS PAQUETES DE ASIGNACIÓN



        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Refrescar_Click(sender As Object, e As EventArgs) Handles Btn_Refrescar.Click
        Call RellenaGrid()
    End Sub

    Private Sub DGrid1_Click_1(sender As Object, e As EventArgs) Handles DGrid1.Click

    End Sub

    Private Sub Btn_Imprimir_Click(sender As Object, e As EventArgs) Handles Btn_Imprimir.Click
        Dim myForm1 As New frmReportsBrowser

        myForm1.objDataSetPpalVencidoGestor = GenerarReporteVencidoGestor()
        'myForm1.r_Titulo = "Fecha Vencido :" & Format(DateEdit1.EditValue, "dd/MM/yyyy")
        myForm1.Text = "Reporte de Visita Vencido"
        myForm1.ReportIndex = 6002
        myForm1.Show()



    End Sub

    Private Function GenerarReporteVencidoGestor() As usp_PpalVencidoGestor
        'mreyes 08/Diciembre/2017   12:27 p.m.
        Try

            Dim Rows As New ArrayList()
            ' Add the selected rows to the list.
            Dim I As Integer


            GenerarReporteVencidoGestor = New usp_PpalVencidoGestor
            With GridView1
                '    For I As Integer = 0 To .RowCount - 1
                For I = 0 To GridView1.SelectedRowsCount() - 1
                    If (GridView1.GetSelectedRows()(I) >= 0) Then

                        Dim objDataRow As Data.DataRow = GenerarReporteVencidoGestor.Tables(0).NewRow()
                        objDataRow.Item("distrib") = .GetRowCellValue(GridView1.GetSelectedRows()(I), "distrib").ToString.Trim
                        objDataRow.Item("nombre") = .GetRowCellValue(GridView1.GetSelectedRows()(I), "nombre").ToString.Trim
                        objDataRow.Item("status") = .GetRowCellValue(GridView1.GetSelectedRows()(I), "status").ToString.Trim
                        objDataRow.Item("nombre") = .GetRowCellValue(GridView1.GetSelectedRows()(I), "nombre").ToString.Trim
                        objDataRow.Item("fecalta") = Format(CDate(.GetRowCellValue(GridView1.GetSelectedRows()(I), "fecalta").ToString.Trim), "dd/MM/yyyy")

                        objDataRow.Item("saldo") = Val(.GetRowCellValue(GridView1.GetSelectedRows()(I), "saldo").ToString)
                        objDataRow.Item("capital") = Val(.GetRowCellValue(GridView1.GetSelectedRows()(I), "capital").ToString)
                        objDataRow.Item("interes") = Val(.GetRowCellValue(GridView1.GetSelectedRows()(I), "interes").ToString)
                        objDataRow.Item("cobranza") = Val(.GetRowCellValue(GridView1.GetSelectedRows()(I), "cobranza").ToString)
                        objDataRow.Item("ultpago") = Val(.GetRowCellValue(GridView1.GetSelectedRows()(I), "ultpago").ToString)
                        objDataRow.Item("ULTfechapago") = Format(CDate(.GetRowCellValue(GridView1.GetSelectedRows()(I), "ULTfechapago").ToString.Trim), "dd/MM/yyyy")

                        objDataRow.Item("direccion") = .GetRowCellValue(GridView1.GetSelectedRows()(I), "direccion").ToString.Trim
                        objDataRow.Item("Ciudad") = .GetRowCellValue(GridView1.GetSelectedRows()(I), "Ciudad").ToString.Trim
                        objDataRow.Item("colonia") = .GetRowCellValue(GridView1.GetSelectedRows()(I), "colonia").ToString.Trim
                        objDataRow.Item("Telefono1") = .GetRowCellValue(GridView1.GetSelectedRows()(I), "Telefono1").ToString.Trim
                        objDataRow.Item("aval") = .GetRowCellValue(GridView1.GetSelectedRows()(I), "aval").ToString.Trim
                        objDataRow.Item("campo1") = .GetRowCellValue(GridView1.GetSelectedRows()(I), "campo1").ToString.Trim
                        objDataRow.Item("campo2") = .GetRowCellValue(GridView1.GetSelectedRows()(I), "campo2").ToString.Trim
                        objDataRow.Item("campo3") = .GetRowCellValue(GridView1.GetSelectedRows()(I), "campo3").ToString.Trim
                        objDataRow.Item("campo4") = .GetRowCellValue(GridView1.GetSelectedRows()(I), "campo4").ToString.Trim

                        '        objDataRow.Item("ultfechapago") = .GetRowCellValue(I, "ultfechapago").ToString.Trim

                        GenerarReporteVencidoGestor.Tables(0).Rows.Add(objDataRow)
                    End If
                Next

            End With
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Private Sub GridView1_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GridView1.RowStyle
        Try
            Dim View As GridView = sender
            If (e.RowHandle >= 0) Then
                Dim concepto As String = Mid((View.GetRowCellDisplayText(e.RowHandle, View.Columns("campo1"))), 1, 1)
                If Len(concepto) = 0 Then
                    ''''e.Appearance.BackColor = Color.Red
                    ''''e.Appearance.BackColor2 = Color.SeaShell
                    '''''e.Appearance.Font = New Font(Font.FontFamily, 2, FontStyle.Bold)
                    ''''e.Appearance.BorderColor = Color.Red

                Else
                    '0 no se ha asignado.
                    ' e.Appearance.BackColor = Color.Aqua
                    e.Appearance.BackColor = Color.Gold
                    e.Appearance.BackColor2 = Color.SeaShell
                    'e.Appearance.Font = New Font(Font.FontFamily, 2, FontStyle.Bold)
                    e.Appearance.BorderColor = Color.Red


                    'New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                    ' e.Appearance.BackColor2 = Color.SeaShell
                End If

            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


End Class