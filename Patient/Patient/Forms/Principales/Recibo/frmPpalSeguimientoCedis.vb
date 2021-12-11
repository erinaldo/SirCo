Public Class frmPpalSeguimientoCedis
    'josue hernandez 26/Septiembre/2020 9:36 a.m.

    Private objDataSet As Data.DataSet
    Private FechIni As String
    Private FechFin As String

    Private Sub RellenaGrid()
        'josue hernandez 26/Septiembre/2020   9:39 a.m.

        FechIni = Format(DTPicker1.Value, "yyyy-MM-dd")
        FechFin = Format(DTPicker2.Value, "yyyy-MM-dd")
        Using objSeguimiento As New BCL.BCLSeguimientoCedis(GLB_ConStringSirCoSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                'DGrid.ReadOnly = True
                DGrid2.DataSource = Nothing

                objDataSet = objSeguimiento.usp_PpalSeguimientoCedis(FechIni, FechFin)

                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section

                    DGrid2.DataSource = objDataSet.Tables(0)

                    InicializaGrid()

                    'LimpiarBusqueda()
                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True

                    'Call Colores()
                Else

                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron registros que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                End If
                Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Sub InicializaGrid()
        Try
            GridView1.Columns("idfoliosuc").Caption = "Folio Bulto"
            GridView1.Columns("proveedor").Caption = "Proveedor"
            GridView1.Columns("marca").Caption = "Marca"
            GridView1.Columns("nombre").Caption = "Recibe Bulto"
            GridView1.Columns("fumbulto").Caption = "Fum Bulto"
            GridView1.Columns("nomdetalle").Caption = "Recibe Detalle"
            GridView1.Columns("fumdetalle").Caption = "Fum Detalle"
            GridView1.Columns("nomtraspaso").Caption = "Generó Traspaso"
            GridView1.Columns("fumgenerotraspaso").Caption = "Fum Generó Traspaso"
            GridView1.Columns("salida").Caption = "Salida"
            GridView1.Columns("nomsalida").Caption = "Generó Salida"
            GridView1.Columns("fumsalida").Caption = "Fum Salida"
            GridView1.Columns("nomsucursal").Caption = "Recibo en Sucursal"
            GridView1.Columns("fumsucursal").Caption = "Fum Sucursal"
            GridView1.Columns("sucursal").Caption = "Sucursal"

            GridView1.Columns("fumbulto").DisplayFormat.FormatType = 1
            GridView1.Columns("fumdetalle").DisplayFormat.FormatType = 1
            GridView1.Columns("fumgenerotraspaso").DisplayFormat.FormatType = 1
            GridView1.Columns("fumbulto").DisplayFormat.FormatType = 1
            GridView1.Columns("fumsalida").DisplayFormat.FormatType = 1
            GridView1.Columns("fumsucursal").DisplayFormat.FormatType = 1
            GridView1.Columns("salida").Visible = False
            GridView1.OptionsView.ColumnAutoWidth = False
            GridView1.BestFitColumns()

            For I As Integer = 0 To GridView1.Columns.Count - 1

                GridView1.Columns(I).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns(I).AppearanceHeader.Font = New Font(GridView1.Columns(I).AppearanceCell.Font, FontStyle.Bold)
                GridView1.Columns(I).OptionsColumn.ReadOnly = True

            Next

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Excel.Click
        'Try
        ' If ExportarDGridAExcel() = False Then
        'MsgBox("Error al exportar a Excel. Intente nuevamente.", MsgBoxStyle.Critical, "Excel")
        '     End If
        ' Catch ExceptionErr As Exception
        ' MessageBox.Show(ExceptionErr.Message.ToString)
        ' End Try

        Try
            If sfdRuta.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                DGrid2.ExportToXls(sfdRuta.FileName)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Buscar_Click(sender As Object, e As EventArgs) Handles Btn_Buscar.Click
        Call RellenaGrid()
    End Sub

    Private Sub Btn_Salir_Click(sender As Object, e As EventArgs) Handles Btn_Salir.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub frmPpalSeguimientoCedis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DTPicker1.Value = DTPicker2.Value.AddDays(-7)
        Call RellenaGrid()
    End Sub

    Private Sub frmPpalSeguimientoCedis_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then
                Me.Dispose()
                Me.Close()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

End Class