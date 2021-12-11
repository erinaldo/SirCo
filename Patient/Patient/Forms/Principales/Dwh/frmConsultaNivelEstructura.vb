Imports DevExpress.Utils
Imports DevExpress.Utils.Menu
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class frmConsultaNivelEstructura

    Public Tipo As String
    Public Filtro As Boolean
    Public Clave As String
    Public Id As Integer
    Public Descrip As String

#Region "Metodos"

    Private Sub RellenaGrid()
        Dim objDataSet As DataSet
        Using objEstadistica As New BCL.BCLEstadisticaVentas(GLB_ConStringDwhSQL)
            objDataSet = objEstadistica.usp_TraerEstructuraClave(Tipo, "", 0)
        End Using
        gc_NivelEstructura.DataSource = Nothing
        If objDataSet.Tables(0).Rows.Count > 0 Then
            gc_NivelEstructura.DataSource = objDataSet.Tables(0)
            dgv_NivelEstructura.BestFitColumns()
        End If
    End Sub

#End Region

#Region "Eventos"
    Private Sub frmConsultaNivelEstructura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Filtro = False
            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub dgv_NivelEstructura_DoubleClick(sender As Object, e As EventArgs) Handles dgv_NivelEstructura.DoubleClick
        Try
            Dim ea As DXMouseEventArgs = TryCast(e, DXMouseEventArgs)
            Dim view As GridView = TryCast(sender, GridView)
            Dim info As GridHitInfo = view.CalcHitInfo(ea.Location)
            If info.InRow OrElse info.InRowCell Then
                Id = dgv_NivelEstructura.GetRowCellValue(info.RowHandle, "id").ToString.Trim
                Clave = dgv_NivelEstructura.GetRowCellValue(info.RowHandle, "clave").ToString.Trim
                Descrip = dgv_NivelEstructura.GetRowCellValue(info.RowHandle, "descrip").ToString.Trim
                Filtro = True
                Me.Close()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click
        Try
            Id = dgv_NivelEstructura.GetRowCellValue(dgv_NivelEstructura.FocusedRowHandle, "id").ToString.Trim
            Clave = dgv_NivelEstructura.GetRowCellValue(dgv_NivelEstructura.FocusedRowHandle, "clave").ToString.Trim
            Descrip = dgv_NivelEstructura.GetRowCellValue(dgv_NivelEstructura.FocusedRowHandle, "descrip").ToString.Trim
            Filtro = True
            Me.Close()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Cancelar_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        Try
            Id = 0
            Clave = ""
            Descrip = ""
            Filtro = False
            Me.Close()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmConsultaNivelEstructura_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

#End Region
End Class