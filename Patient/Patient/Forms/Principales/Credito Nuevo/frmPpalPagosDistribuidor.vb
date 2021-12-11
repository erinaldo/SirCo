Imports DevExpress.XtraEditors.TextEdit
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmPpalPagosDistribuidor
    Private objDataSet As Data.DataSet
    Dim FechaFin As String
    Dim FechaIni As String
    Public Opcion As Integer
    Private Sub RellenaGrid()

        Using objTrasp As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)

            Try

                Me.Cursor = Cursors.WaitCursor
                DGrid2.DataSource = Nothing
                objDataSet = objTrasp.usp_PpalPagosDistribuidorXCorte(oPCION, FechaIni, FechaFin, Txt_Distrib.Text.Trim())

                If objDataSet.Tables(0).Rows.Count > 0 Then

                    DGrid2.DataSource = objDataSet.Tables(0)

                    Me.Cursor = Cursors.Default
                    InicializaGrid()
                Else

                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron registros que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")

                End If
                Me.Cursor = Cursors.Default

                GridView2.BestFitColumns()
            Catch ExceptionErr As Exception

                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub
    Function usp_ValidarDistrib(distrib As String) As Boolean

        Using objTrasp As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)

            Try
                If objTrasp.usp_ValidarDistrib(distrib).Tables(0).Rows.Count > 0 Then

                    usp_ValidarDistrib = True
                Else
                    usp_ValidarDistrib = False
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click

        RellenaGrid()


    End Sub

    Private Sub DGrid2_KeyDown(sender As Object, e As KeyEventArgs)
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub frmPpalPagosDistribuidor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' RellenaGrid()
        FechaFin = "1900-01-01"
        FechaIni = "1900-01-01"
    End Sub


    Private Sub Btn_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Excel.Click
        If sfdRuta.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            DGrid2.ExportToXls(sfdRuta.FileName)
        End If
    End Sub

    Private Sub Btn_Salir_Click(sender As Object, e As EventArgs) Handles Btn_Salir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Txt_Distrib_EditValueChanged(sender As Object, e As EventArgs) Handles Txt_Distrib.EditValueChanged

    End Sub
    Private Sub TxtLostfocusDistrib(ByVal Txt_Campo As DevExpress.XtraEditors.TextEdit, ByVal Txt_Campo1 As DevExpress.XtraEditors.TextEdit, ByVal Tipo As String)
        Try
            'Dim myForm As New frmRelacionConsulta
            'If Txt_Campo.Text.Length = 0 Then Exit Sub
            '' Using objMySqlGral As New BCL.BCLRecibo(GLB_ConStringCredito)
            'Using objMySqlGral As New BCL.BCLRecibo(GLB_ConStringCredito)
            '    Try
            '        objDataSet = objMySqlGral.usp_TraerDistribuidor(Txt_Campo.Text)

            '        If objDataSet.Tables(0).Rows.Count > 0 Then
            '            Txt_NomDistrib.Text = objDataSet.Tables(0).Rows(0).Item("Nombre").ToString
            '            Txt_Campo1.Text = objDataSet.Tables(0).Rows(0).Item("Nombre").ToString
            '            'Frecuencia = objDataSet.Tables(0).Rows(0).Item("Frecuen").ToString
            '            'Sucursal = objDataSet.Tables(0).Rows(0).Item("Sucursal").ToString
            '        Else
            '            Txt_Campo.Text = ""
            '            myForm.Sw_Nomina = True
            '            myForm.Tipo = "D"
            '            myForm.ShowDialog()
            '            Txt_Campo.Text = myForm.Campo
            '            Txt_Campo1.Text = myForm.Campo1
            '            If Txt_Campo.Text.Length = 0 Then
            '                Txt_Campo.Focus()
            '            End If
            '        End If


            '    Catch ExceptionErr As Exception
            '        MessageBox.Show(ExceptionErr.Message.ToString)
            '    End Try
            ' End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub
    Private Sub Txt_Distrib_LostFocus(sender As Object, e As EventArgs) Handles Txt_Distrib.LostFocus
        Try
            ''rellena ceros
            If (Txt_Distrib.Text <> "") Then
                If Txt_Distrib.Text.Trim.Length < 6 Then
                    Txt_Distrib.Text = pub_RellenarIzquierda(Txt_Distrib.Text.Trim, 6)
                End If
                'consulta si existe
                'Using objMySqlGral As New BCL.BCLRelacion(GLB_ConStringCredito)
                '    If Txt_Distrib.Text.Length = 0 Then Exit Sub
                '    Try
                '        Call TxtLostfocusDistrib(Txt_Distrib, Txt_NomDistrib, "D")
                '    Catch ExceptionErr As Exception
                '        MessageBox.Show(ExceptionErr.Message.ToString)
                '    End Try
                'End Using
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Imprimir_Click(sender As Object, e As EventArgs)
        RellenaGrid()

    End Sub

    Private Sub Btn_Refrescar_Click(sender As Object, e As EventArgs) Handles Btn_Refrescar.Click
        RellenaGrid()
    End Sub

    Private Sub DGrid2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub frmPpalPagosDistribuidor_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub DEFechaIni_EditValueChanged(sender As Object, e As EventArgs) Handles DEFechaIni.EditValueChanged
        FechaIni = DEFechaIni.EditValue
    End Sub

    Private Sub DEFechaFin_EditValueChanged(sender As Object, e As EventArgs) Handles DEFechaFin.EditValueChanged
        FechaFin = DEFechaFin.EditValue
    End Sub

    Private Sub GridView2_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs)
        Dim View As GridView = sender
        If (e.RowHandle >= 0) Then
            Dim status = View.GetRowCellDisplayText(e.RowHandle, View.Columns("STATUS"))
            If status = "CANCELADO" Then
                e.Appearance.BackColor = Color.Red
                'e.Appearance.BackColor2 = Color.SeaShell
                e.Appearance.BorderColor = Color.Red
            End If

        End If
    End Sub

    Sub InicializaGrid()
        Try
            'view.GetRowCellValue(e.RowHandle1, e.Column)
            ' GridView2.Columns(I).OptionsColumn.AllowMerge = True
            'GridView2.GetRowCellValue(1, 0) '

            ''GridView2.OptionsView.ColumnAutoWidth = False
            ''GridView2.OptionsView.BestFitMaxRowCount = -1
            ''GridView2.BestFitColumns()


            GridView2.Columns(0).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView2.Columns(0).AppearanceHeader.Font = New Font(GridView2.Columns(0).AppearanceCell.Font, FontStyle.Bold)

            GridView2.Columns(1).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView2.Columns(1).AppearanceHeader.Font = New Font(GridView2.Columns(1).AppearanceCell.Font, FontStyle.Bold)

            GridView2.Columns(2).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView2.Columns(2).AppearanceHeader.Font = New Font(GridView2.Columns(2).AppearanceCell.Font, FontStyle.Bold)

            GridView2.Columns(3).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView2.Columns(3).AppearanceHeader.Font = New Font(GridView2.Columns(3).AppearanceCell.Font, FontStyle.Bold)
            GridView2.Columns(4).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView2.Columns(4).AppearanceHeader.Font = New Font(GridView2.Columns(4).AppearanceCell.Font, FontStyle.Bold)
            GridView2.Columns(5).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView2.Columns(5).AppearanceHeader.Font = New Font(GridView2.Columns(5).AppearanceCell.Font, FontStyle.Bold)
            GridView2.Columns(6).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView2.Columns(6).AppearanceHeader.Font = New Font(GridView2.Columns(6).AppearanceCell.Font, FontStyle.Bold)
            GridView2.Columns(7).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView2.Columns(7).AppearanceHeader.Font = New Font(GridView2.Columns(7).AppearanceCell.Font, FontStyle.Bold)
            GridView2.Columns(8).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView2.Columns(8).AppearanceHeader.Font = New Font(GridView2.Columns(8).AppearanceCell.Font, FontStyle.Bold)
            GridView2.Columns(9).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView2.Columns(9).AppearanceHeader.Font = New Font(GridView2.Columns(9).AppearanceCell.Font, FontStyle.Bold)
            GridView2.Columns(10).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView2.Columns(10).AppearanceHeader.Font = New Font(GridView2.Columns(10).AppearanceCell.Font, FontStyle.Bold)

            GridView2.Columns(11).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView2.Columns(11).AppearanceHeader.Font = New Font(GridView2.Columns(11).AppearanceCell.Font, FontStyle.Bold)

            GridView2.Columns(12).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView2.Columns(12).AppearanceHeader.Font = New Font(GridView2.Columns(12).AppearanceCell.Font, FontStyle.Bold)

            GridView2.Columns(13).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView2.Columns(13).AppearanceHeader.Font = New Font(GridView2.Columns(13).AppearanceCell.Font, FontStyle.Bold)


            GridView2.Columns(0).Caption = "Distrib"
            GridView2.Columns(1).Caption = "Nombre"
            GridView2.Columns(2).Caption = "Fecha"
            GridView2.Columns(3).Caption = "Hora"
            GridView2.Columns(4).Caption = "Bruto"
            GridView2.Columns(5).Caption = "Descto"
            GridView2.Columns(6).Caption = "Neto"
            GridView2.Columns(7).Caption = "% Porc"
            GridView2.Columns(8).Caption = "Cortes"
            GridView2.Columns(9).Caption = "Cajero"
            GridView2.Columns(10).Caption = "Cajero Cancela"
            GridView2.Columns(11).Caption = "Sucursal"
            GridView2.Columns(12).Caption = "Folio"
            GridView2.Columns(13).Caption = "Estatus"
            GridView2.Columns(14).Caption = "Campo 1"
            GridView2.Columns(15).Caption = "Campo 2"
            GridView2.Columns(16).Caption = "Campo 3"
            GridView2.Columns(17).Caption = "Campo 4"
            GridView2.Columns(18).Caption = "Campo 5"


            GridView2.Columns(14).Visible = False
            GridView2.Columns(15).Visible = False
            GridView2.Columns(16).Visible = False
            GridView2.Columns(17).Visible = False
            GridView2.Columns(18).Visible = False

            If Opcion = 1 Then

                GridView2.Columns(8).Visible = False
            Else
                GridView2.Columns(8).Visible = True

                GridView2.Columns(8).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            End If



            GridView2.Columns(2).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            GridView2.Columns(4).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            GridView2.Columns(5).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            GridView2.Columns(6).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            GridView2.Columns(7).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

            GridView2.Columns(8).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView2.Columns(9).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView2.Columns(10).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView2.Columns(11).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView2.Columns(12).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView2.Columns(13).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView2.Columns(14).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView2.Columns(15).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            '   GridView2.Columns(5).AppearanceCell.BackColor = Color.Pink
            '   GridView2.Columns(5).AppearanceCell.BackColor2 = Color.White




            GridView2.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView2.Columns(4).DisplayFormat.FormatString = "#,###,###.00"

            GridView2.Columns(5).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView2.Columns(5).DisplayFormat.FormatString = "#,###,###.00"

            GridView2.Columns(6).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView2.Columns(6).DisplayFormat.FormatString = "#,###,###.00"

            GridView2.Columns(7).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView2.Columns(7).DisplayFormat.FormatString = "#0.00"



            GridView2.Columns("BRUTO").SummaryItem.FieldName = "BRUTO"
            GridView2.Columns("BRUTO").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GridView2.Columns("BRUTO").SummaryItem.DisplayFormat = "{0:$###,###,##0.00}"

            GridView2.Columns("DSCTO").SummaryItem.FieldName = "DSCTO"
            GridView2.Columns("DSCTO").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GridView2.Columns("DSCTO").SummaryItem.DisplayFormat = "{0:$###,###,##0.00}"


            GridView2.Columns("NETO").SummaryItem.FieldName = "NETO"
            GridView2.Columns("NETO").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GridView2.Columns("NETO").SummaryItem.DisplayFormat = "{0:$###,###,##0.00}"


            'GridView2.OptionsView.ColumnAutoWidth = False
            'GridView2.OptionsView.BestFitMaxRowCount = -1
            'GridView2.BestFitColumns()


            ' Call Colorear()
            GridView2.FixedLineWidth = 2
            GridView2.Columns(0).Fixed = 1
            GridView2.Columns(1).Fixed = 1
            GridView2.Columns(2).Fixed = 1
            GridView2.Columns(3).Fixed = 1
            GridView2.Columns(4).Fixed = 1
            GridView2.Columns(5).Fixed = 1
            GridView2.Columns(6).Fixed = 1
            GridView2.Columns(7).Fixed = 1


            GridView2.Columns(0).OptionsColumn.ReadOnly = True
            GridView2.Columns(1).OptionsColumn.ReadOnly = True
            GridView2.Columns(2).OptionsColumn.ReadOnly = True
            GridView2.Columns(3).OptionsColumn.ReadOnly = True
            GridView2.Columns(4).OptionsColumn.ReadOnly = True
            GridView2.Columns(5).OptionsColumn.ReadOnly = True
            GridView2.Columns(6).OptionsColumn.ReadOnly = True
            GridView2.Columns(7).OptionsColumn.ReadOnly = True
            GridView2.Columns(8).OptionsColumn.ReadOnly = True

            GridView2.Columns(9).OptionsColumn.ReadOnly = True

            GridView2.Columns(10).OptionsColumn.ReadOnly = True
            GridView2.Columns(11).OptionsColumn.ReadOnly = True
            GridView2.Columns(12).OptionsColumn.ReadOnly = True
            GridView2.Columns(13).OptionsColumn.ReadOnly = True
            GridView2.Columns(14).OptionsColumn.ReadOnly = True
            GridView2.Columns(15).OptionsColumn.ReadOnly = True





            GridView2.BestFitColumns()

            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("VS2010")
            GridView2.OptionsView.ColumnAutoWidth = False
            GridView2.OptionsView.BestFitMaxRowCount = -1
            GridView2.BestFitColumns()



        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid2_Click_1(sender As Object, e As EventArgs) Handles DGrid2.Click

    End Sub
End Class
