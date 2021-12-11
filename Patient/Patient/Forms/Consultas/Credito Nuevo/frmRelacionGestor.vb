Public Class frmRelacionGestor
    Dim objDataSet As Data.DataSet
    Public Nombre As String = "" '' valor de regreso para el primer texto
    Public appaterno As String = "" ''valor de regreso para el segundo texto
    Public apmaterno As String = "" ''valor de regreso para el tercer texto en departamentos.
    Public tipo As String = ""
    Private Sub frmRelacionGestor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call RellenaGrid()
    End Sub


    Private Sub RellenaGrid()

        Using objTrasp As New BCL.BCLGestoresDeCartera(GLB_ConStringCreditoSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                DGrid.DataSource = Nothing


                objDataSet = objTrasp.usp_TraerGestoresDeCartera(2, Txt_Id.Text)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    DGrid.DataSource = objDataSet.Tables(0)
                    InicializaGrid()
                    GridView1.BestFitColumns()

                    Me.Cursor = Cursors.Default
                Else
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron registros que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                End If

                Me.Cursor = Cursors.Default

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Sub InicializaGrid()
        Try
            GridView1.Columns("idgestor").Caption = "idGestor"
            GridView1.Columns("nombre").Caption = "Nombre"
            GridView1.Columns("appaterno").Caption = "Apellido Paterno"
            GridView1.Columns("apmaterno").Caption = "Apellido Materno"
            GridView1.Columns("tipo").Caption = "Tipo"


            GridView1.OptionsView.ColumnAutoWidth = False

            GridView1.Columns("idgestor").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center


            For I As Integer = 0 To GridView1.Columns.Count - 1

                GridView1.Columns(I).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns(I).AppearanceHeader.Font = New Font(GridView1.Columns(I).AppearanceCell.Font, FontStyle.Bold)
                GridView1.Columns(I).OptionsColumn.ReadOnly = True

            Next

            GridView1.Columns("idgestor").Visible = False


            GridView1.BestFitColumns()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_DoubleClick(sender As Object, e As EventArgs) Handles DGrid.DoubleClick
        Try

            For i As Integer = 0 To GridView1.RowCount - 1


                If GridView1.IsRowSelected(i) = True Then
                    Nombre = GridView1.GetRowCellValue(i, "nombre")
                    appaterno = GridView1.GetRowCellValue(i, "appaterno")
                    apmaterno = GridView1.GetRowCellValue(i, "apmaterno")
                    tipo = GridView1.GetRowCellValue(i, "tipo")
                End If
            Next

            Me.Close()
            Me.Dispose()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmRelacionGestor_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            If MsgBox("Estas Seguro de sálir ?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                Me.Close()
                Me.Dispose()
            End If
        End If
    End Sub

End Class