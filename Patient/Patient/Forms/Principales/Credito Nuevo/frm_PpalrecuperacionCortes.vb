Imports DevExpress.DashboardCommon
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Columns.GridColumn
Public Class frm_PpalrecuperacionCortes
    Private objDataSet As DataSet
    Private objDataSet1 As DataSet
    Dim Año As Integer
    Private Sub frm_PpalrecuperacionCortes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim anio As Integer = Now.Year
        CB_año.Text = Now.Year.ToString()
        Do
            CB_año.Items.Add(anio)
            anio -= 1
        Loop Until anio = 2000

        Call RellenarGrido()


        Call GenerarToolTip()
        P1.BackColor = Color.FromArgb(255, 230, 153)
        P2.BackColor = Color.FromArgb(253, 161, 154)
    End Sub
    Private Sub GenerarToolTip()
        Try
            ToolTip1.SetToolTip(Btn_rf, "Refrescar")
            ToolTip1.SetToolTip(Btn_ex, "Exportar a Excel")
            ToolTip1.SetToolTip(Btn_Salir, "Salir")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Public Sub ver(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        Dim view As GridView = sender
        If view.IsDataRow(e.RowHandle) Then
            If e.CellValue.ToString Like "*[%]" And e.Column.Caption = " 1 Corte " Or e.CellValue.ToString Like "*[%]" And e.Column.Caption = " 2 Cortes " Or e.CellValue.ToString Like "*[%]" And e.Column.Caption = " 3 Cortes " Or e.CellValue.ToString Like "*[%]" And e.Column.Caption = " 4 Cortes " Or e.CellValue.ToString Like "*[%]" And e.Column.Caption = " 5 Cortes " Or e.CellValue.ToString Like "*[%]" And e.Column.Caption = " 6 Cortes " Then
                e.Appearance.BackColor = Color.FromArgb(255, 242, 204)

                e.Appearance.Font = New Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold)
            End If
            If e.CellValue.ToString Like "*[%]" And e.Column.Caption = " 3 Cortes " Or e.CellValue.ToString Like "*[%]" And e.Column.Caption = " 4 Cortes " Or e.CellValue.ToString Like "*[%]" And e.Column.Caption = " 5 Cortes " Or e.CellValue.ToString Like "*[%]" And e.Column.Caption = " 6 Cortes " Then
                e.Appearance.BackColor = Color.FromArgb(255, 230, 153)

                e.Appearance.Font = New Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold)
            End If
            If e.CellValue.ToString Like "*[%]" And e.Column.Caption = " Hasta 1 dia antes " Then
                e.Appearance.BackColor = Color.FromArgb(169, 208, 142)
                e.Appearance.Font = New Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold)
            End If
            If e.CellValue.ToString Like "*[%]" And e.Column.Caption = " Al dia de pago " Then
                e.Appearance.BackColor = Color.FromArgb(198, 224, 180)
                e.Appearance.Font = New Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold)
            End If
            If e.CellValue.ToString Like "*[%]" And e.Column.Caption = " 7 Cortes " Or e.CellValue.ToString Like "*[%]" And e.Column.Caption = " 8 Cortes " Or e.CellValue.ToString Like "*[%]" And e.Column.Caption = " 9 Cortes " Or e.CellValue.ToString Like "*[%]" And e.Column.Caption = " 10 Cortes " Or e.CellValue.ToString Like "*[%]" And e.Column.Caption = " +10 Cortes " Then
                e.Appearance.BackColor = Color.FromArgb(253, 161, 154)
                e.Appearance.Font = New Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold)
            End If
            If e.Column.Caption = " Valor de corte " Then
                e.Appearance.Font = New Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold)
            End If
            If e.CellValue.ToString = "RECUPERACIÓN" Then
                e.Appearance.Font = New Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold)
            End If
        End If
    End Sub
    Private Sub RellenarGrido()
        'Rafael Saucedo - 04/Agosto/2020 - 7:37 p.m.
        Using objTrasp As New BCL.BCLRecuperacionCortes(GLB_ConStringCreditoSQL)
            Try
                Año = CB_año.Text
                Grido.DataSource = Nothing
                Me.Cursor = Cursors.WaitCursor
                objDataSet = objTrasp.usp_Ppalrecuperacioncortes(Año)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Grido.DataSource = objDataSet.Tables(0)
                    Me.Cursor = Cursors.Default
                    'Para evitar que el indice sea negativo, solo crea una condicion que verifique la cantidad de columnas de la tabla
                    If GridView1.Columns.Count > 0 Then
                        InicializarGrido()
                        Me.Cursor = Cursors.Default
                    End If
                End If
                Me.Cursor = Cursors.Default
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub
    Private Sub InicializarGrido()
        Try
            'Agregar formato 'Money'  las columnas
            GridView1.Columns(0).Caption = " Fecha de Pago "
            GridView1.Columns(1).Caption = " Valor de corte "
            GridView1.Columns(2).Caption = " Hasta 1 dia antes "
            GridView1.Columns(3).Caption = " Al dia de pago "
            GridView1.Columns(4).Caption = " 1 Corte "
            GridView1.Columns(5).Caption = " 2 Cortes "
            GridView1.Columns(6).Caption = " 3 Cortes "
            GridView1.Columns(7).Caption = " 4 Cortes "
            GridView1.Columns(8).Caption = " 5 Cortes "
            GridView1.Columns(9).Caption = " 6 Cortes "
            GridView1.Columns(10).Caption = " 7 Cortes "
            GridView1.Columns(11).Caption = " 8 Cortes "
            GridView1.Columns(12).Caption = " 9 Cortes "
            GridView1.Columns(13).Caption = " 10 Cortes "
            GridView1.Columns(14).Caption = " +10 Cortes "
            GridView1.BestFitColumns()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Btn_ex.Click
        Try
            If SFdRuta.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Grido.ExportToXls(SFdRuta.FileName)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Btn_rf.Click
        Call RellenarGrido()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Btn_Salir.Click
        Me.Close()
    End Sub
    Private Sub frm_PpalrecuperacionCortes_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Grido_Click(sender As Object, e As EventArgs) Handles Grido.Click

    End Sub

    Private Sub CB_año_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles CB_año.SelectedIndexChanged
        RellenarGrido()
    End Sub
End Class