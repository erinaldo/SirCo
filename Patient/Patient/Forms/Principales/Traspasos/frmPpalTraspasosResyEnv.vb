Public Class frmPpalTraspasosResyEnv

    Private objDataSet As Data.DataSet
    Private objDataSet1 As Data.DataSet 'Segundo Nivel
    Dim SucurOriB As String = ""
    Dim SucurDesB As String = ""
    Dim Sucursal As String = ""

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
        'Manuel vazquez, Paola Gonzales - 27/Enero/2017 - 10:15 a.m.
        Using objTrasp As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                DGrid.DataSource = Nothing
                objDataSet = objTrasp.usp_PpalTraspasosRecyEnv(FechaIniB, FechaFinB)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    DGrid.DataSource = objDataSet.Tables(0)
                    InicializaGrid()

                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True

                Else
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron registros que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                End If
                Me.Cursor = Cursors.Default
                Call LimpiarBusqueda()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Sub InicializaGrid()
        Try
            Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
            Dim row As DataRow = dt.NewRow()

            row(1) = "Total:"

            row("paresRec") = pub_SumarColumnaGrid(DGrid, 2, DGrid.RowCount - 1)
            row("costo") = pub_SumarColumnaGrid(DGrid, 3, DGrid.RowCount - 1)
            row("precIvaRec") = pub_SumarColumnaGrid(DGrid, 4, DGrid.RowCount - 1)
            row("paresEnv") = pub_SumarColumnaGrid(DGrid, 5, DGrid.RowCount - 1)
            row("costomargen") = pub_SumarColumnaGrid(DGrid, 6, DGrid.RowCount - 1)
            row("precIvaEnv") = pub_SumarColumnaGrid(DGrid, 7, DGrid.RowCount - 1)
            dt.Rows.InsertAt(row, 0)
            DGrid.DataSource = dt

            DGrid.RowHeadersVisible = False
            DGrid.Columns("sucursal").HeaderText = "Det"
            DGrid.Columns("descrip").HeaderText = "Sucursal"
            DGrid.Columns("paresRec").HeaderText = "Enviados"
            DGrid.Columns("costo").HeaderText = "Costo Margen"
            DGrid.Columns("precIvaRec").HeaderText = "Precio C/Iva"
            DGrid.Columns("paresEnv").HeaderText = "Recibidos"
            DGrid.Columns("costomargen").HeaderText = "Costo Margen"
            DGrid.Columns("precIvaEnv").HeaderText = "Precio C/Iva"

            DGrid.Columns("sucursal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns("descrip").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns("paresRec").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns("costo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns("precIvaRec").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns("paresEnv").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns("costomargen").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns("precIvaEnv").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells


            DGrid.Columns("costo").DefaultCellStyle.Format = "c"
            DGrid.Columns("precIvaRec").DefaultCellStyle.Format = "c"
            DGrid.Columns("costomargen").DefaultCellStyle.Format = "c"
            DGrid.Columns("precIvaEnv").DefaultCellStyle.Format = "c"

            DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)


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
            Dim myForm As New frmFiltrosTraspasosRecyEnv

            If Opcion = 0 Then
                Opcion = 1

                myForm.DTPicker2.Value = FechaIniB
                myForm.DTPicker3.Value = FechaFinB
            ElseIf Opcion >= 1 Then

                'If FechaIniB <> "1900-01-01" Then

                myForm.DTPicker2.Value = FechaIniB
                myForm.DTPicker3.Value = FechaFinB
            End If

            myForm.ShowDialog()




            FechaIniB = Format(myForm.DTPicker2.Value, "yyyy-MM-dd")
                FechaFinB = Format(myForm.DTPicker3.Value, "yyyy-MM-dd")


                If myForm.Sw_Filtro = True Then
                RellenaGrid()
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

  

    'Private Sub PBox_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PBox.DoubleClick
    '    'mreyes 03/Marzo/2012 10:01 a.m.
    '    Try
    '        Dim myForm As New frmConsultaImagen
    '        myForm.Txt_Estilon.Text = EstiloNFOTO
    '        myForm.Txt_Marca.Text = MarcaFOTO
    '        myForm.Txt_NoFoto.Text = 1
    '        myForm.ShowDialog()

    '    Catch ExceptionErr As Exception
    '        MessageBox.Show(ExceptionErr.Message.ToString)
    '    End Try
    'End Sub

    Private Sub frmPpalPpalTraspasosAutomatico_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call GenerarToolTip()
        ' Call LimpiarBusqueda()

        'FechaIniB = Format(frmFiltrosTraspasosRecyEnv.DTPicker2.Value, "yyyy-MM-dd")
        'FechaFinB = Format(frmFiltrosTraspasosRecyEnv.DTPicker3.Value, "yyyy-MM-dd")
        FechaIniB = Format(Now.Add(New TimeSpan(-10, 0, 0, 0)), "yyyy-MM-dd")
        FechaFinB = Format(Now.Date, "yyyy-MM-dd")
        FechaIniB = Format(DateSerial(Now.Year, Now.Month, 1), "yyyy-MM-dd")

        FechaFinB = Format(Now.Date, "yyyy-MM-dd")
        Call RellenaGrid()
    End Sub

    Private Sub Btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Imprimir.Click
        Try
            Dim myForm As New frmReportsBrowser
            myForm.objDataSetTraspasosRecYEnv = GenerarTraspasosRecyEnv()
            myForm.r_Titulo = "Información del " & FechaIniB & " al " & FechaFinB & "."
            myForm.ReportIndex = 5529
            myForm.Show()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)

        End Try
    End Sub

    Public Function GenerarTraspasosRecyEnv() As DSTraspasosRecYEnv
        Try
            Dim cont As Integer = 0
            GenerarTraspasosRecyEnv = New DSTraspasosRecYEnv

            For i As Integer = 1 To DGrid.RowCount - 2

                cont = 0
                Dim objDataRow1 As Data.DataRow = GenerarTraspasosRecyEnv.Tables("Tbl_Traspasos").NewRow()
                objDataRow1.Item("sucursal") = DGrid.Rows(i).Cells("sucursal").Value.ToString
                objDataRow1.Item("decrip") = DGrid.Rows(i).Cells("descrip").Value.ToString
                objDataRow1.Item("paresRec") = DGrid.Rows(i).Cells("paresRec").Value.ToString
                objDataRow1.Item("costo") = DGrid.Rows(i).Cells("costo").Value.ToString
                objDataRow1.Item("precInvRec") = DGrid.Rows(i).Cells("precIvaRec").Value.ToString
                objDataRow1.Item("paresEnv") = DGrid.Rows(i).Cells("paresEnv").Value.ToString
                objDataRow1.Item("costomargen") = DGrid.Rows(i).Cells("costomargen").Value.ToString
                objDataRow1.Item("precinvEnv") = DGrid.Rows(i).Cells("precIvaEnv").Value.ToString

                GenerarTraspasosRecyEnv.Tables("Tbl_Traspasos").Rows.Add(objDataRow1)

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

    Private Sub frmPpalTraspasosResyEnv_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp

    End Sub

    Private Sub Pnl_Botones_Paint(sender As Object, e As PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub

    Private Sub DGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub
End Class