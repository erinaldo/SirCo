Public Class frmVentasFiscal

    Private objDataSet As Data.DataSet
    Private Sub frmVentasFiscal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
    End Sub

    Private Sub Btn_Limpiar_Click(sender As Object, e As EventArgs) Handles Btn_Limpiar.Click

        Me.Txt_Sucursal.Text = ""
        Me.Txt_Venta.Text = ""

        Txt_Sucursal.Focus()
        DGrid.DataSource = Nothing
        GridView1.Columns.Clear()
    End Sub
    Private Sub InicializaGrid()
        Try
            GridView1.Columns("idarticulo").Caption = "IdArticulo"
            GridView1.Columns("marca").Caption = "Marca"
            GridView1.Columns("modelo").Caption = "Modelo"
            GridView1.Columns("serie").Caption = "Serie"
            GridView1.Columns("Precio").Caption = "Precio"

            'GridView1.Columns("ventau").Visible = False
            'GridView1.Columns("idart").Visible = False

            GridView1.Columns("Precio").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns("Precio").DisplayFormat.FormatString = "###,###,###.00"

            GridView1.BestFitColumns()


            For I As Integer = 0 To GridView1.Columns.Count - 1

                GridView1.Columns(I).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns(I).AppearanceHeader.Font = New Font(GridView1.Columns(I).AppearanceCell.Font, FontStyle.Bold)
                GridView1.Columns(I).OptionsColumn.ReadOnly = True

            Next
            GridView1.OptionsView.ColumnAutoWidth = False
            GridView1.OptionsView.ShowAutoFilterRow = False
            GridView1.OptionsView.ShowFooter = True

            GridView1.Columns("Precio").SummaryItem.FieldName = "Precio"
            GridView1.Columns("Precio").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GridView1.Columns("Precio").SummaryItem.DisplayFormat = "{0:$###,###,##0}"
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub frmVentasFiscal_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Btn_Limpiar_Click(Nothing, Nothing)
            Me.Close()
        End If
    End Sub

    Private Sub TxtLostfocus(ByVal Txt_Campo As DevExpress.XtraEditors.TextEdit, ByVal Txt_Campo1 As DevExpress.XtraEditors.TextEdit)
        Try
            'Dim myForm As New frmRelacionConsulta
            If Txt_Campo.Text.Length = 0 Or Txt_Campo1.Text.Length = 0 Then Exit Sub
            'If focus Then Exit Sub

            Using objMySqlGral As New BCL.BCLTraerVentasFiscal(GLB_ConStringDwhSQL)
                Try
                    objDataSet = objMySqlGral.usp_TraerVentaFiscal(Txt_Campo.Text, Txt_Campo1.Text)

                    If objDataSet.Tables(0).Rows.Count > 0 Then

                        DGrid.DataSource = Nothing
                        objDataSet = objMySqlGral.usp_VentasFiscal(Txt_Campo.Text, Txt_Campo1.Text)
                        DGrid.DataSource = objDataSet.Tables(0)
                        InicializaGrid()

                    Else
                        MsgBox("No se encontraron registros que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")


                    End If
                    'fcus = True

                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Venta_EditValueChanged(sender As Object, e As EventArgs) Handles Txt_Venta.EditValueChanged

    End Sub

    Private Sub Txt_Sucursal_EditValueChanged(sender As Object, e As EventArgs) Handles Txt_Sucursal.EditValueChanged

    End Sub

    Private Sub Txt_Sucursal_LostFocus(sender As Object, e As EventArgs) Handles Txt_Sucursal.LostFocus
        Try
            ''rellena ceros
            If (Txt_Sucursal.Text <> "") Then
                If Txt_Sucursal.Text.Trim.Length < 2 Then
                    Txt_Sucursal.Text = pub_RellenarIzquierda(Txt_Sucursal.Text.Trim, 2)
                End If
                'consulta si existe
                If Txt_Venta.Text.Trim.Length = 6 Then
                    Using objMySqlGral As New BCL.BCLTraerVentasFiscal(GLB_ConStringDwhSQL)
                        If Txt_Sucursal.Text.Length = 0 Then Exit Sub
                        Try
                            Call TxtLostfocus(Txt_Sucursal, Txt_Venta)
                        Catch ExceptionErr As Exception
                            MessageBox.Show(ExceptionErr.Message.ToString)
                        End Try
                    End Using
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Venta_LostFocus(sender As Object, e As EventArgs) Handles Txt_Venta.LostFocus
        Try
            ''rellena ceros
            If (Txt_Sucursal.Text <> "") Then
                If Txt_Sucursal.Text.Trim.Length < 2 Then
                    Txt_Sucursal.Text = pub_RellenarIzquierda(Txt_Sucursal.Text.Trim, 2)
                End If
                'consulta si existe
                If Txt_Venta.Text.Trim.Length = 6 Then
                    Using objMySqlGral As New BCL.BCLTraerVentasFiscal(GLB_ConStringDwhSQL)
                        If Txt_Sucursal.Text.Length = 0 Then Exit Sub
                        Try
                            Call TxtLostfocus(Txt_Sucursal, Txt_Venta)
                        Catch ExceptionErr As Exception
                            MessageBox.Show(ExceptionErr.Message.ToString)
                        End Try
                    End Using
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub
End Class