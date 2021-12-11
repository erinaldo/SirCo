Imports DevExpress.XtraGrid.Views.Grid
Public Class frmPpalAsigLiqProv
    'mreyes 29/Febrero/2020 01:49 p.m.
    Dim Sw_Load As Boolean = True
    Dim Sw_Pintar As Boolean = False
    Dim Sw_NoRegistros As Boolean = False
    Dim Opcion = 1


    Sub InicializaGrid()
        'GridView1

        '' GridView1.BestFitColumns()
        Try
            'view.GetRowCellValue(e.RowHandle1, e.Column)
            ' GridView1.Columns(I).OptionsColumn.AllowMerge = True
            'GridView1.GetRowCellValue(1, 0) '

            Dim Anio As Integer = 0
            Dim AnioSig As Integer = 0

            Dim mes As Integer = 0


            mes = Month(GLB_FechaHoy)
            Anio = Year(GLB_FechaHoy)
            AnioSig = Anio + 1

            GridView1.Columns(0).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(1).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            GridView1.Columns(1).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(1).AppearanceHeader.Font = New Font(GridView1.Columns(1).AppearanceCell.Font, FontStyle.Bold)

            GridView1.Columns(2).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(2).AppearanceHeader.Font = New Font(GridView1.Columns(2).AppearanceCell.Font, FontStyle.Bold)

            GridView1.Columns(0).Visible = False
            GridView1.Columns(0).Caption = "IdProveedor"
            ' "Tipo Pago"

            GridView1.Columns(1).Caption = "Proveedor"
            GridView1.Columns(2).Caption = "Razón Social"
            GridView1.Columns(3).Caption = "Tipo Pago"
            GridView1.Columns(4).Caption = "Neto a Pagar"




            GridView1.OptionsView.ColumnAutoWidth = False
            GridView1.OptionsView.BestFitMaxRowCount = -1
            GridView1.BestFitColumns()




            GridView1.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(4).DisplayFormat.FormatString = "#,###,##0.00"
            GridView1.Columns(4).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(4).AppearanceHeader.Font = New Font(GridView1.Columns(4).AppearanceCell.Font, FontStyle.Bold)

            '--- suma
            ' GridView1.Columns(I).SummaryItem.FieldName = "importe"
            GridView1.Columns(4).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GridView1.Columns(4).SummaryItem.DisplayFormat = "{0:$###,###,##0.00}"





        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub



    Private Sub RellenaGrid()
        'mreyes 26/Octubre/2017     04:55 p.m.
        Dim objDataSet As Data.DataSet
        DGrid1.Visible = False

        Using objTrasp As New BCL.BCLPasivo(GLB_ConStringSirCoSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                Sw_Load = False
                'DGrid.ReadOnly = True
                ' GridControl.DataSource = Nothing

                objDataSet = objTrasp.usp_PpalAsigLiquidaciones(2)


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
                    MsgBox("LA INFORMACIÓN SE ESTA ACTUALIZANDO, FAVOR DE INTENTAR EN UNOS MINUTOS", MsgBoxStyle.Critical, "Aviso")
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

    Private Sub frmPpalPasivoProveedores_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Sw_Load = True
            '  Call GenerarToolTip()
            Sw_Pintar = True
            Sw_Load = True

            ' Call LimpiarBusqueda()

            Txt_Transferencia.BackColor = Color.GreenYellow
            Txt_Consignacion.BackColor = Color.Yellow
            Txt_Factoraje.BackColor = Color.LightCoral


            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Excel.Click
        If sfdRuta.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            DGrid1.ExportToXls(sfdRuta.FileName)
        End If
    End Sub

    Private Sub Btn_Refrescar_Click(sender As Object, e As EventArgs)
        Try
            Opcion = 1
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Salir_Click(sender As Object, e As EventArgs) Handles Btn_Salir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub frmPpalPasivoProveedores_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub


End Class