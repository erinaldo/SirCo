Imports DevExpress.XtraGrid.Views.Grid

Imports DevExpress.XtraGrid.Views.Base
Public Class usp_PpalAsigLiquidaciones
    'mreyes 26/Febrero/2020 11:29 a.m.
    Dim Sw_Load As Boolean = True
    Dim Sw_Pintar As Boolean = False
    Dim Sw_NoRegistros As Boolean = False
    Dim SW_PRIMERA As Boolean = True
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
            GridView1.Columns(3).Caption = "Marca"

            GridView1.Columns(4).Caption = "Factura"

            GridView1.Columns(5).Caption = "Fecha Vencimiento"
            GridView1.Columns(6).Caption = "Segmento"
            GridView1.Columns(7).Caption = "Tipo Pago"
            GridView1.Columns(8).Caption = "Descuento"
            GridView1.Columns(9).Caption = "Neto a Pagar"

            GridView1.Columns(10).Caption = "IdFolio"

            GridView1.Columns(11).Caption = "Factoraje"
            GridView1.Columns(12).Caption = "Transferencia"
            GridView1.Columns(13).Caption = "Consignación"

            GridView1.Columns(11).AppearanceCell.BackColor = Color.LightCoral
            GridView1.Columns(12).AppearanceCell.BackColor = Color.GreenYellow
            GridView1.Columns(13).AppearanceCell.BackColor = Color.Yellow



            GridView1.Columns(10).Visible = False



            GridView1.OptionsView.ColumnAutoWidth = False
            GridView1.OptionsView.BestFitMaxRowCount = -1
            GridView1.BestFitColumns()


            For I As Integer = 8 To GridView1.Columns.Count - 1

                GridView1.Columns(I).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                GridView1.Columns(I).DisplayFormat.FormatString = "#,###,##0.00"
                GridView1.Columns(I).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns(I).AppearanceHeader.Font = New Font(GridView1.Columns(I).AppearanceCell.Font, FontStyle.Bold)

                '--- suma
                ' GridView1.Columns(I).SummaryItem.FieldName = "importe"
                GridView1.Columns(I).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                GridView1.Columns(I).SummaryItem.DisplayFormat = "{0:$###,###,##0.00}"

            Next




            ' Call Colorear()
            GridView1.FixedLineWidth = 4
            GridView1.Columns(0).Fixed = 0
            GridView1.Columns(1).Fixed = 1
            GridView1.Columns(2).Fixed = 1
            GridView1.Columns(3).Fixed = 1
            GridView1.Columns(4).Fixed = 1
            GridView1.Columns(5).Fixed = 1




        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub GridView1_RowCellStyle(ByVal sender As Object, ByVal e As RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        Try
            Dim View As GridView = sender

            Dim Pos As Integer = 0
            Dim Pos1 As Integer = 0
            Dim Nombre As String = ""

            Pos = InStr(LCase(e.Column.FieldName), "tipopago")

            Nombre = LCase(e.Column.Name)


            If Pos > 0 Or Pos1 > 0 Then
                Dim TipoPago As String = (View.GetRowCellDisplayText(e.RowHandle, e.Column))
                If TipoPago = "TRANSFERENCIA" Then
                    'e.Appearance.BackColor = Color.Red
                    'e.Appearance.BackColor2 = Color.LightCyan

                    e.Appearance.BackColor = Color.GreenYellow
                    e.Appearance.FontStyleDelta = FontStyle.Bold



                End If

                If TipoPago = "CONSIGNACIÓN" Then
                    'e.Appearance.BackColor = Color.Red
                    'e.Appearance.BackColor2 = Color.LightCyan

                    e.Appearance.BackColor = Color.Yellow
                    e.Appearance.FontStyleDelta = FontStyle.Bold
                End If

                If TipoPago = "FACTORAJE" Then
                    'e.Appearance.BackColor = Color.Red
                    'e.Appearance.BackColor2 = Color.LightCyan

                    e.Appearance.BackColor = Color.LightCoral
                    e.Appearance.FontStyleDelta = FontStyle.Bold
                End If
            End If
            'Dim concepto As String = (View.GetRowCellDisplayText(e.RowHandle, View.Columns("concepto")))
            'If concepto = "UTILIDAD BRUTA" Then
            '    Pos = InStr(LCase(e.Column.FieldName), "precio")
            '    If Pos > 0 Then

            '    End If

            'End If

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

                objDataSet = objTrasp.usp_PpalAsigLiquidaciones(Opcion)


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
            Dim Sw_Guardo As Boolean = False
            Sw_Load = True
            '  Call GenerarToolTip()
            Sw_Pintar = True
            Sw_Load = True

            ' Call LimpiarBusqueda()

            Txt_Transferencia.BackColor = Color.GreenYellow
            Txt_Consignacion.BackColor = Color.Yellow
            Txt_Factoraje.BackColor = Color.LightCoral

            Using objUsuario As New BCL.BCLPasivo(GLB_ConStringSirCoTEMPSQL)
                Sw_Guardo = objUsuario.usp_Captura_PasivoTemp(2, "", "", 0, "", "1900-01-01")
            End Using


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

    Private Sub Btn_Refrescar_Click(sender As Object, e As EventArgs) Handles Btn_Refrescar.Click
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

    Private Sub GridView1_FocusedRowChanged(ByVal sender As System.Object, ByVal e As FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        Try
            Dim view As GridView = sender
            If view Is Nothing Then
                Return
            End If
            If SW_PRIMERA = True Then
                SW_PRIMERA = False
                Exit Sub

            End If

            If GridView1.IsRowSelected(GridView1.FocusedRowHandle) = False Then
                If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "tipopago") = "FACTORAJE" Then
                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "factoraje", GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "total"))

                End If

                If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "tipopago") = "TRANSFERENCIA" Then
                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "transferencia", GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "total"))
                End If


                If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "tipopago") = "CONSIGNACIÓN" Then
                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "consignacion", GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "total"))
                End If
            Else

                If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "tipopago") = "FACTORAJE" Then
                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "factoraje", 0)
                End If

                If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "tipopago") = "TRANSFERENCIA" Then
                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "transferencia", 0)
                End If


                If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "tipopago") = "CONSIGNACIÓN" Then
                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "consignacion", 0)
                End If

            End If


            GridView1.Columns(10).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GridView1.Columns(10).SummaryItem.DisplayFormat = "{0:$###,###,##0.00}"

            GridView1.Columns(11).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GridView1.Columns(11).SummaryItem.DisplayFormat = "{0:$###,###,##0.00}"

            GridView1.Columns(12).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GridView1.Columns(12).SummaryItem.DisplayFormat = "{0:$###,###,##0.00}"


            Txt_Factoraje.Text = Format(GridView1.Columns(11).SummaryItem.SummaryValue, "c")
            Txt_Transferencia.Text = Format(GridView1.Columns(12).SummaryItem.SummaryValue, "c")
            Txt_Consignacion.Text = Format(GridView1.Columns(13).SummaryItem.SummaryValue, "c")




        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    'Private Sub GridView1_(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle

    '    Try
    '        Txt_Transferencia.Text = "0"
    '        Txt_Consignacion.Text = "0"
    '        Txt_Factoraje.Text = "0"
    '        Dim Sw_Guardo As Boolean = False


    '        Using objUsuario As New BCL.BCLPasivo(GLB_ConStringSirCoTEMPSQL)
    '            Sw_Guardo = objUsuario.usp_Captura_PasivoTemp(2, "", "", 0, "", "1900-01-01")
    '        End Using


    '        'borrar temporal

    '        Dim View As GridView = sender
    '        If GridView1.OptionsSelection.MultiSelect = True Then
    '            e.Column.AppearanceHeader.BackColor = Color.LightBlue
    '            'Dim TipoPago As String = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "tipopago").ToString().Trim()
    '            'Dim Apagar As Double = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "total")

    '            Dim TipoPago As String = ""
    '            Dim Apagar As Double = 0




    '            For i As Integer = 0 To GridView1.DataRowCount - 1


    '                If GridView1.IsRowSelected(i) = True Then
    '                    TipoPago = GridView1.GetRowCellValue(i, "tipopago")
    '                    Apagar = GridView1.GetRowCellValue(i, "total")
    '                    Dim Marca As String = GridView1.GetRowCellValue(i, "marca")
    '                    Dim proveedor As String = GridView1.GetRowCellValue(i, "proveedor")
    '                    Dim fecvenc As Date = GridView1.GetRowCellValue(i, "fecvenc")
    '                    Dim IdFolio As Integer = GridView1.GetRowCellValue(i, "idfolio")
    '                    Dim Referenc As String = GridView1.GetRowCellValue(i, "idfoliosuc")


    '                    If TipoPago = "TRANSFERENCIA" Then
    '                        Txt_Transferencia.Text = Format(CDbl(Txt_Transferencia.Text) + Apagar, "c")
    '                    End If


    '                    If TipoPago = "CONSIGNACIÓN" Then
    '                        Txt_Consignacion.Text = Format(CDbl(Txt_Consignacion.Text) + Apagar, "c")
    '                    End If


    '                    If TipoPago = "FACTORAJE" Then
    '                        Txt_Factoraje.Text = Format(CDbl(Txt_Factoraje.Text) + Apagar, "c")
    '                    End If

    '                    'ir grabando la temporal
    '                    Using objUsuario As New BCL.BCLPasivo(GLB_ConStringSirCoTEMPSQL)
    '                        Sw_Guardo = objUsuario.usp_Captura_PasivoTemp(1, proveedor, Marca, IdFolio, Referenc, fecvenc)
    '                    End Using



    '                End If
    '            Next

    '        End If
    '    Catch ExceptionErr As Exception
    '        MessageBox.Show(ExceptionErr.Message.ToString)
    '    End Try
    'End Sub
    'Private Sub DGrid1_Click(sender As Object, e As EventArgs) Handles DGrid1.Click
    '    Try

    '        ' If GridView1.IsRowSelected(GridView1.FocusedRowHandle) = True Then
    '        If GridView1.IsRowSelected(GridView1.FocusedRowHandle) = False Then
    '            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "tipopago") = "FACTORAJE" Then
    '                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "factoraje", GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "total"))

    '            End If

    '            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "tipopago") = "TRANSFERENCIA" Then
    '                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "transferencia", GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "total"))
    '            End If


    '            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "tipopago") = "CONSIGNACIÓN" Then
    '                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "consignacion", GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "total"))
    '            End If

    '        Else
    '            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "tipopago") = "FACTORAJE" Then
    '                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "factoraje", 0)
    '            End If

    '            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "tipopago") = "TRANSFERENCIA" Then
    '                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "transferencia", 0)
    '            End If


    '            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "tipopago") = "CONSIGNACIÓN" Then
    '                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "consignacion", 0)
    '            End If

    '        End If

    '        GridView1.Columns(10).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
    '        GridView1.Columns(10).SummaryItem.DisplayFormat = "{0:$###,###,##0.00}"

    '        GridView1.Columns(11).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
    '        GridView1.Columns(11).SummaryItem.DisplayFormat = "{0:$###,###,##0.00}"

    '        GridView1.Columns(12).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
    '        GridView1.Columns(12).SummaryItem.DisplayFormat = "{0:$###,###,##0.00}"


    '        Txt_Factoraje.Text = GridView1.Columns(11).SummaryItem.SummaryValue
    '        Txt_Transferencia.Text = GridView1.Columns(12).SummaryItem.SummaryValue
    '        Txt_Consignacion.Text = GridView1.Columns(13).SummaryItem.SummaryValue

    '        ' GridView1.Columns(I).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum



    '    Catch ExceptionErr As Exception
    '        MessageBox.Show(ExceptionErr.Message.ToString)
    '    End Try
    'End Sub

    Private Sub Btn_Aplicar_Click(sender As Object, e As EventArgs) Handles Btn_Aplicar.Click
        Try

            If MsgBox("¿Esta usted seguro de realizar las liquidaciones con las facturas seleccionadas.?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Confirmación") = vbNo Then Exit Sub


            Dim Sw_Guardo As Boolean = False
            Dim TipoPago As String = ""
            Dim Apagar As Double = 0

            Using objUsuario As New BCL.BCLPasivo(GLB_ConStringSirCoTEMPSQL)
                Sw_Guardo = objUsuario.usp_Captura_PasivoTemp(2, "", "", 0, "", "1900-01-01")
            End Using

            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    TipoPago = GridView1.GetRowCellValue(rowHandle, "tipopago")
                    Apagar = GridView1.GetRowCellValue(rowHandle, "total")
                    Dim Marca As String = GridView1.GetRowCellValue(rowHandle, "marca")
                    Dim proveedor As String = GridView1.GetRowCellValue(rowHandle, "proveedor")
                    Dim fecvenc As Date = GridView1.GetRowCellValue(rowHandle, "fecvenc")
                    Dim IdFolio As Integer = GridView1.GetRowCellValue(rowHandle, "idfolio")
                    Dim Referenc As String = GridView1.GetRowCellValue(rowHandle, "idfoliosuc")



                    'ir grabando la temporal
                    Using objUsuario As New BCL.BCLPasivo(GLB_ConStringSirCoTEMPSQL)
                        Sw_Guardo = objUsuario.usp_Captura_PasivoTemp(1, proveedor, Marca, IdFolio, Referenc, fecvenc)
                    End Using

                End If
            Next rowHandle




            Using objUsuario As New BCL.BCLPasivo(GLB_ConStringSirCoSQL)
                Sw_Guardo = objUsuario.usp_GeneraLiquidacionesPasivo()
            End Using

            MsgBox("Se han generado las liquidaciones seleccionadas", MsgBoxStyle.Information, "Pasivo")

            Call RellenaGrid()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub Btn_Proveedor_Click(sender As Object, e As EventArgs) Handles Btn_Proveedor.Click

        Try

            Dim Sw_Guardo As Boolean = False
            Dim TipoPago As String = ""
            Dim Apagar As Double = 0

            Using objUsuario As New BCL.BCLPasivo(GLB_ConStringSirCoTEMPSQL)
                Sw_Guardo = objUsuario.usp_Captura_PasivoTemp(2, "", "", 0, "", "1900-01-01")
            End Using

            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    TipoPago = GridView1.GetRowCellValue(rowHandle, "tipopago")
                    Apagar = GridView1.GetRowCellValue(rowHandle, "total")
                    Dim Marca As String = GridView1.GetRowCellValue(rowHandle, "marca")
                    Dim proveedor As String = GridView1.GetRowCellValue(rowHandle, "proveedor")
                    Dim fecvenc As Date = GridView1.GetRowCellValue(rowHandle, "fecvenc")
                    Dim IdFolio As Integer = GridView1.GetRowCellValue(rowHandle, "idfolio")
                    Dim Referenc As String = GridView1.GetRowCellValue(rowHandle, "idfoliosuc")



                    'ir grabando la temporal
                    Using objUsuario As New BCL.BCLPasivo(GLB_ConStringSirCoTEMPSQL)
                        Sw_Guardo = objUsuario.usp_Captura_PasivoTemp(1, proveedor, Marca, IdFolio, Referenc, fecvenc)
                    End Using

                End If
            Next rowHandle



            Dim myForm As New frmPpalAsigLiqProv

            myForm.Txt_Consignacion.Text = Txt_Consignacion.Text
            myForm.Txt_Transferencia.Text = Txt_Transferencia.Text
            myForm.Txt_Factoraje.Text = Txt_Factoraje.Text
            myForm.ShowDialog()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try


    End Sub

    Private Sub GridView1_Click(sender As Object, e As EventArgs) Handles GridView1.RowCellStyle

    End Sub
End Class