Imports DevExpress.XtraGrid.Views.Grid
Public Class frmPpalPasivoProveedores
    'mreyes 20/Febrero/2020 12:31 p.m.
    Dim Sw_Load As Boolean = True
    Dim Sw_Pintar As Boolean = False
    Dim Sw_NoRegistros As Boolean = False

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


            GridView1.Columns(1).Caption = "Proveedor"
            GridView1.Columns(2).Caption = "Razón Social"
            GridView1.Columns(3).Caption = "Tipo Pago"
            GridView1.Columns(4).Caption = "Marca"
            GridView1.Columns(5).Caption = "Pasivo Total"
            GridView1.Columns(6).Caption = "Vencido"
            GridView1.Columns(7).Caption = "Por Vencer"
            GridView1.Columns(8).Caption = "Ene-" & Anio
            GridView1.Columns(9).Caption = "Feb-" & Anio
            GridView1.Columns(10).Caption = "Mar-" & Anio
            GridView1.Columns(11).Caption = "Abr-" & Anio
            GridView1.Columns(12).Caption = "May-" & Anio
            GridView1.Columns(13).Caption = "Jun-" & Anio
            GridView1.Columns(14).Caption = "Jul-" & Anio
            GridView1.Columns(15).Caption = "Ago-" & Anio
            GridView1.Columns(16).Caption = "Sep-" & Anio
            GridView1.Columns(17).Caption = "Oct-" & Anio
            GridView1.Columns(18).Caption = "Nov-" & Anio
            GridView1.Columns(19).Caption = "Dic-" & Anio

            GridView1.Columns(20).Caption = "Ene-" & AnioSig
            GridView1.Columns(21).Caption = "Feb-" & AnioSig
            GridView1.Columns(22).Caption = "Mar-" & AnioSig
            GridView1.Columns(23).Caption = "Abr-" & AnioSig
            GridView1.Columns(24).Caption = "May-" & AnioSig
            GridView1.Columns(25).Caption = "Jun-" & AnioSig
            GridView1.Columns(26).Caption = "Jul-" & AnioSig
            GridView1.Columns(27).Caption = "Ago-" & AnioSig
            GridView1.Columns(28).Caption = "Sep-" & AnioSig
            GridView1.Columns(29).Caption = "Oct-" & AnioSig
            GridView1.Columns(30).Caption = "Nov-" & AnioSig
            GridView1.Columns(31).Caption = "Dic-" & AnioSig



            'For I As Integer = 19 To GridView1.Columns.Count - 1
            '    GridView1.Columns(I).Visible = False
            'Next


            GridView1.OptionsView.ColumnAutoWidth = False
            GridView1.OptionsView.BestFitMaxRowCount = -1
            GridView1.BestFitColumns()


            For I As Integer = 5 To GridView1.Columns.Count - 1

                GridView1.Columns(I).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                GridView1.Columns(I).DisplayFormat.FormatString = "#,###,###"
                GridView1.Columns(I).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns(I).AppearanceHeader.Font = New Font(GridView1.Columns(I).AppearanceCell.Font, FontStyle.Bold)

                '--- suma
                ' GridView1.Columns(I).SummaryItem.FieldName = "importe"
                GridView1.Columns(I).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                GridView1.Columns(I).SummaryItem.DisplayFormat = "{0:$###,###,##0.00}"


                If GridView1.Columns(I).SummaryItem.SummaryValue = 0 Then
                    GridView1.Columns(I).Visible = False
                End If


            Next

            If mes = 2 Then
                GridView1.Columns("enero").Visible = False
            End If
            If mes = 3 Then
                GridView1.Columns("enero").Visible = False
                GridView1.Columns("febrero").Visible = False
            End If

            If mes = 4 Then
                GridView1.Columns("enero").Visible = False
                GridView1.Columns("febrero").Visible = False
                GridView1.Columns("marzo").Visible = False
            End If

            If mes = 5 Then
                GridView1.Columns("enero").Visible = False
                GridView1.Columns("febrero").Visible = False
                GridView1.Columns("marzo").Visible = False
                GridView1.Columns("abril").Visible = False
            End If


            If mes = 6 Then
                GridView1.Columns("enero").Visible = False
                GridView1.Columns("febrero").Visible = False
                GridView1.Columns("marzo").Visible = False
                GridView1.Columns("abril").Visible = False
                GridView1.Columns("mayo").Visible = False
            End If

            If mes = 7 Then
                GridView1.Columns("enero").Visible = False
                GridView1.Columns("febrero").Visible = False
                GridView1.Columns("marzo").Visible = False
                GridView1.Columns("abril").Visible = False
                GridView1.Columns("mayo").Visible = False
                GridView1.Columns("junio").Visible = False

            End If

            If mes = 8 Then
                GridView1.Columns("enero").Visible = False
                GridView1.Columns("febrero").Visible = False
                GridView1.Columns("marzo").Visible = False
                GridView1.Columns("abril").Visible = False
                GridView1.Columns("mayo").Visible = False
                GridView1.Columns("junio").Visible = False
                GridView1.Columns("julio").Visible = False

            End If


            If mes = 9 Then
                GridView1.Columns("enero").Visible = False
                GridView1.Columns("febrero").Visible = False
                GridView1.Columns("marzo").Visible = False
                GridView1.Columns("abril").Visible = False
                GridView1.Columns("mayo").Visible = False
                GridView1.Columns("junio").Visible = False
                GridView1.Columns("julio").Visible = False
                GridView1.Columns("agosto").Visible = False
            End If

            If mes = 10 Then
                GridView1.Columns("enero").Visible = False
                GridView1.Columns("febrero").Visible = False
                GridView1.Columns("marzo").Visible = False
                GridView1.Columns("abril").Visible = False
                GridView1.Columns("mayo").Visible = False
                GridView1.Columns("junio").Visible = False
                GridView1.Columns("julio").Visible = False
                GridView1.Columns("agosto").Visible = False
                GridView1.Columns("septiembre").Visible = False
            End If

            If mes = 11 Then
                GridView1.Columns("enero").Visible = False
                GridView1.Columns("febrero").Visible = False
                GridView1.Columns("marzo").Visible = False
                GridView1.Columns("abril").Visible = False
                GridView1.Columns("mayo").Visible = False
                GridView1.Columns("junio").Visible = False
                GridView1.Columns("julio").Visible = False
                GridView1.Columns("agosto").Visible = False
                GridView1.Columns("septiembre").Visible = False
                GridView1.Columns("octubre").Visible = False
            End If

            If mes = 12 Then
                GridView1.Columns("enero").Visible = False
                GridView1.Columns("febrero").Visible = False
                GridView1.Columns("marzo").Visible = False
                GridView1.Columns("abril").Visible = False
                GridView1.Columns("mayo").Visible = False
                GridView1.Columns("junio").Visible = False
                GridView1.Columns("julio").Visible = False
                GridView1.Columns("agosto").Visible = False
                GridView1.Columns("septiembre").Visible = False
                GridView1.Columns("noviembre").Visible = False
            End If



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

                objDataSet = objTrasp.usp_PpalPasivoProveedores()


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