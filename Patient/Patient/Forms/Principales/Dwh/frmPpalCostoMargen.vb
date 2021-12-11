Imports DevExpress.XtraGrid.Views.Grid

Public Class frmPpalCostoMargen


    'mreyes 03/Agosto/2017  04:16 p.m.
    ' el 08 de Agosto se decide que no lleva precios

    Private objDataSet As Data.DataSet
    Private objDataSet1 As Data.DataSet 'Segundo Nivel

    Dim Traspasos As Integer = 0
    Dim FechaFinB As String = "1900-01-01"
    Dim FechaIniB As String = "1900-01-01"
    Private Sub DGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub RellenaGrid()
        'mreyes 02/Agosto/2017 07:08 p.m.

        Using objTrasp As New BCL.BCLCostoMargen(GLB_ConStringDwhSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                DGrid.DataSource = Nothing
                DGrid.Visible = False
                objDataSet = objTrasp.usp_PpalCostoMargenSVenta(DEFechaIni.EditValue, DEFechaFin.EditValue)
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
                DGrid.Visible = True
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Sub InicializaGrid()
        Try
            'view.GetRowCellValue(e.RowHandle1, e.Column)
            ' GridView1.Columns(I).OptionsColumn.AllowMerge = True
            'GridView1.GetRowCellValue(1, 0) '



            GridView1.Columns(0).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(1).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            GridView1.Columns(1).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(1).AppearanceHeader.Font = New Font(GridView1.Columns(1).AppearanceCell.Font, FontStyle.Bold)

            GridView1.Columns(2).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(2).AppearanceHeader.Font = New Font(GridView1.Columns(2).AppearanceCell.Font, FontStyle.Bold)

            GridView1.Columns(0).Visible = False
            GridView1.Columns(1).Caption = "+/-"
            GridView1.Columns(2).Caption = "Concepto"
            GridView1.Columns(3).Caption = "Total Costo"
            GridView1.Columns(4).Caption = "%"
            GridView1.Columns(5).Caption = "Juárez"
            GridView1.Columns(6).Caption = "Hidalgo"
            GridView1.Columns(7).Caption = "Triana"
            GridView1.Columns(8).Caption = "Matriz"
            GridView1.Columns(9).Caption = "Mercado Libre"
            GridView1.Columns(10).Caption = "Cedis"
            GridView1.Columns(11).Caption = "Cargo Inv"
            GridView1.Columns(12).Caption = "Pares Unicos"
            GridView1.Columns(13).Caption = "Devoluciones"
            GridView1.Columns(14).Caption = "Inventario"
            GridView1.Columns(15).Caption = "Custodia Jrz"
            GridView1.Columns(16).Caption = "Custodia Hgo"
            GridView1.Columns(17).Caption = "Custodia Tri"
            GridView1.Columns(18).Caption = "Custodia Mtz"
            For I As Integer = 19 To GridView1.Columns.Count - 1
                GridView1.Columns(I).Visible = False
            Next


            GridView1.OptionsView.ColumnAutoWidth = False
            GridView1.OptionsView.BestFitMaxRowCount = -1
            GridView1.BestFitColumns()
            For I As Integer = 0 To GridView1.Columns.Count - 1
                GridView1.Columns(I).OptionsColumn.ReadOnly = True
                ' GridView1.Columns(I).OptionsColumn.AllowMerge = True
            Next


            For I As Integer = 3 To GridView1.Columns.Count - 1

                GridView1.Columns(I).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                GridView1.Columns(I).DisplayFormat.FormatString = "#,###,###"
                GridView1.Columns(I).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns(I).AppearanceHeader.Font = New Font(GridView1.Columns(I).AppearanceCell.Font, FontStyle.Bold)
            Next


            GridView1.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(4).DisplayFormat.FormatString = "##"
            GridView1.Columns(4).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(4).AppearanceHeader.Font = New Font(GridView1.Columns(4).AppearanceCell.Font, FontStyle.Bold)


            ' Call Colorear()
            GridView1.FixedLineWidth = 4
            GridView1.Columns(0).Fixed = 0
            GridView1.Columns(1).Fixed = 1
            GridView1.Columns(2).Fixed = 1




        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub frmPpalCostoMargen_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            DEFechaIni.EditValue = Format(Now.Add(New TimeSpan(-10, 0, 0, 0)), "yyyy-MM-dd")
            DEFechaFin.EditValue = Format(Now.Date, "yyyy-MM-dd")
            DEFechaIni.EditValue = Format(DateSerial(Now.Year, Now.Month, 1), "yyyy-MM-dd")

            If usp_Traspasos() = False Then
                MsgBox("No se puede visualizar el costo para las fechas '" & DEFechaIni.EditValue & " al " & DEFechaFin.EditValue & "', porque hay '" & Traspasos & "' traspasos en tránsito, pruebe con otras fechas.", MsgBoxStyle.Information, "Aviso Importante")
            Else
                Call RellenaGrid()
            End If


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    'Private Sub Colorear()
    '    For i As Integer = 3 To GridView1.Columns.Count - 1
    '        If Val(GridView1.GetRowCellValue(11, i)) < 0 Then
    '            GridView1.GetRowCellValue(11, i).Columns(1).AppearanceCell.Font = New Font(GridView1.Columns(1).AppearanceCell.Font, FontStyle.Bold)

    '        End If
    '        If Val(GridView1.GetRowCellValue(14, i)) < 0 Then
    '            GridView1.GetRowCellValue(14, i).Columns(1).AppearanceCell.Font = New Font(GridView1.Columns(1).AppearanceCell.Font, FontStyle.Bold)

    '        End If

    '        If Val(GridView1.GetRowCellValue(15, i)) < 0 Then
    '            GridView1.GetRowCellValue(15, i).Columns(1).AppearanceCell.Font = New Font(GridView1.Columns(1).AppearanceCell.Font, FontStyle.Bold)

    '        End If
    '    Next
    'End Sub

    Private Sub Btn_Salir_Click(sender As Object, e As EventArgs) Handles Btn_Salir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub DGrid_Click(sender As Object, e As EventArgs) Handles DGrid.Click

    End Sub

    Private Sub frmPpalCostoMargen_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Excel.Click
        If sfdRuta.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            DGrid.ExportToXls(sfdRuta.FileName)
        End If
    End Sub

    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click
        ' If usp_Traspasos() = False Then
        'MsgBox("No se puede visualizar el costo para las fechas '" & DEFechaIni.EditValue & " al " & DEFechaFin.EditValue & "', porque hay '" & Traspasos & "' traspasos en tránsito, pruebe con otras fechas.", MsgBoxStyle.Information, "Aviso Importante")
        'Else
        Call RellenaGrid()
        'End If
    End Sub


    Private Sub GridView1_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GridView1.RowStyle
        Try
            Dim View As GridView = sender
            If (e.RowHandle >= 0) Then
                Dim concepto As String = (View.GetRowCellDisplayText(e.RowHandle, View.Columns("concepto")))
                If concepto = "" Then
                    ' e.Appearance.BackColor = Color.Aqua
                    e.Appearance.BackColor = Color.SeaShell
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

    Private Sub GridView1_RowCellStyle(ByVal sender As Object, ByVal e As RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        Try
            Dim View As GridView = sender

            Dim Pos As Integer = 0
            Dim Pos1 As Integer = 0
            Dim Nombre As String = ""

            Pos = InStr(LCase(e.Column.FieldName), "precio")
            Pos1 = InStr(LCase(e.Column.FieldName), "costo")
            Nombre = LCase(e.Column.Name)


            If Pos > 0 Or Pos1 > 0 Then
                Dim importe As Decimal = Val(View.GetRowCellDisplayText(e.RowHandle, e.Column))
                If importe < 0 Then
                    'e.Appearance.BackColor = Color.Red
                    'e.Appearance.BackColor2 = Color.LightCyan

                    e.Appearance.ForeColor = Color.Red
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

    Private Function usp_Traspasos() As Boolean
        'mreyes 04/Agosto/2017  12:59 p.m.
        usp_Traspasos = False
        Using objTrasp As New BCL.BCLTraspasosSQL(GLB_ConStringSirCoSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                'DGrid.ReadOnly = True
                DGrid.DataSource = Nothing

                objDataSet = objTrasp.usp_TraerTrasPendRecibo(3, "", "", FechaIniB, FechaFinB)

                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then

                    Traspasos = objDataSet.Tables(0).Rows.Count
                    usp_Traspasos = False

                Else
                    usp_Traspasos = True
                End If
                Me.Cursor = Cursors.Default


            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Private Sub SaveFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk

    End Sub

    Private Sub sfdRuta_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles sfdRuta.FileOk

    End Sub

    Private Sub frmPpalCostoMargen_Invalidated(sender As Object, e As InvalidateEventArgs) Handles Me.Invalidated

    End Sub

    Private Sub DEFechaIni_EditValueChanged(sender As Object, e As EventArgs) Handles DEFechaIni.EditValueChanged

    End Sub

    Private Sub Pnl_Botones_Paint(sender As Object, e As PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub
End Class

