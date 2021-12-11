Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Utils
Imports Microsoft.VisualBasic
Public Class frmDistribInfo
    Private objDataSet As Data.DataSet
    Private Sub frmDistribInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim anio As Integer = Now.Year

        Do
            Cb_Año.Items.Add(anio)
            anio -= 1
        Loop Until anio = 2000


        Cb_Año.Text = Now.Year.ToString()
        RellenaGrid()


    End Sub

    Private Sub RellenaGrid()
        InicializaGrid()
        Using objDistrib As New BCL.BCLDistrib(GLB_ConStringCreditoSQL)
            Try
                Me.Cursor = Cursors.WaitCursor
                objDataSet = objDistrib.usp_DistribInfo(Convert.ToInt32(Cb_Año.Text))

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Grido.DataSource = objDataSet.Tables(0)
                    InicializaGrid()
                    Me.Cursor = Cursors.Default
                    GridView1.Columns("Distrib").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                    AgregaPorcentajes()
                    If GridView1.IsNewItemRow(Grido.NewItemRowHandle) Then
                        GridView1.FocusedRowHandle = GridView1.DataRowCount - 1
                    End If
                Else
                    Me.Cursor = Cursors.Default
                    MsgBox("LA INFORMACIÓN SE ESTA ACTUALIZANDO, FAVOR DE INTENTAR EN UNOS MINUTOS", MsgBoxStyle.Critical, "Aviso")
                End If
                Me.Cursor = Cursors.Default
                'LimpiarBusqueda()
                Grido.Visible = True
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub AgregaPorcentajes()
        Try
            GridView1.AddNewRow()
            Dim coltot As Decimal
            For j As Integer = 2 To GridView1.Columns().Count - 1

                Dim nombrecol As String = Replace(GridView1.Columns(j).GetCaption, " ", "")

                Dim Total As Decimal = 0

                For i As Integer = 0 To GridView1.RowCount - 1
                    If GridView1.GetRowCellValue(i, nombrecol) Is DBNull.Value Then
                        Total += 0
                    Else
                        Dim valor As Decimal = GridView1.GetRowCellValue(i, nombrecol)
                        Total += valor
                    End If
                Next

                GridView1.SetRowCellValue(Grido.NewItemRowHandle, GridView1.Columns("Distrib"), "-")
                GridView1.SetRowCellValue(Grido.NewItemRowHandle, GridView1.Columns("Nombre"), "PORCENTAJE")
                'GridView1.Columns(j).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                Dim compar As Boolean = nombrecol Like "resto*"
                Dim compar2 As Boolean = nombrecol Like "abo*"
                Dim compar3 As Boolean = nombrecol = "resto"
                If compar = False And compar2 = False And compar3 = False Then
                    GridView1.SetRowCellValue(Grido.NewItemRowHandle, GridView1.Columns(nombrecol), Total)
                    coltot = Total
                Else
                    If nombrecol Like "resto*" Then
                        Total = Total / coltot
                        GridView1.SetRowCellValue(Grido.NewItemRowHandle, GridView1.Columns(nombrecol), Total)
                    ElseIf nombrecol Like "abo*" Then
                        Total = Total / coltot
                        GridView1.SetRowCellValue(Grido.NewItemRowHandle, GridView1.Columns(nombrecol), Total)
                    End If
                End If
            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub InicializaGrid()
        Try
            For j As Integer = 0 To GridView1.Columns().Count - 1
                GridView1.Columns(j).OptionsColumn.ReadOnly = True
                GridView1.Columns(j).OptionsColumn.AllowEdit = False
                GridView1.Columns(j).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                'GridView1.Columns(j).DisplayFormat.FormatString = "c2"
                GridView1.Columns(j).BestFit()
            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Public Sub ver(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle

        For j As Integer = 0 To GridView1.Columns().Count - 1
            If e.Appearance.GetFont.Bold Then
                GridView1.Columns(j).DisplayFormat.FormatString = "P2"
            Else
                GridView1.Columns(j).DisplayFormat.FormatString = "c2"
            End If
        Next

        If e.Column.FieldName = "resto" Or e.Column.FieldName Like "resto*" Or e.Column.FieldName = "Distrib" Or e.Column.FieldName = "Nombre" Then
            e.Appearance.BackColor = Color.White
            For j As Integer = 0 To GridView1.Columns().Count - 1
            Next
        ElseIf e.Column.FieldName Like "abo*" Then
            e.Appearance.BackColor = Color.LightGreen
            For j As Integer = 0 To GridView1.Columns().Count - 1
            Next
        Else
            e.Appearance.BackColor = Color.LightCyan
            For j As Integer = 0 To GridView1.Columns().Count - 1
                GridView1.Columns(j).DisplayFormat.FormatString = "c2"
            Next
        End If

    End Sub

    Public Sub estilo(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GridView1.RowStyle
        Dim porcentajes As String = GridView1.GetRowCellDisplayText(e.RowHandle, GridView1.Columns("Distrib"))
        If porcentajes = "-" Then
            e.Appearance.Font = New Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold)
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        RellenaGrid()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Cb_Año_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_Año.SelectedIndexChanged
        RellenaGrid()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If SFDRuta.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Grido.ExportToXls(SFDRuta.FileName)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
End Class