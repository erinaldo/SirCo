Public Class frmBuscarAgrupacion

    Public Selecciono As Boolean
    Public IdAgrupacion As Integer

#Region "Metodos"

    Private Sub TraerAgrupaciones(ByVal Nombre As String)
        Dim objDataSet As DataSet
        Using objAgrupaciones As New BCL.BCLAgrupaciones(GLB_ConStringSirCoPVSQL)
            objDataSet = objAgrupaciones.usp_TraerAgrupaciones(0, Nombre)
        End Using
        gc_Agrupacion.DataSource = Nothing
        If objDataSet.Tables(0).Rows.Count > 0 Then
            gc_Agrupacion.DataSource = objDataSet.Tables(0)
            InicializaGrid
        End If
    End Sub

    Private Sub InicializaGrid()
        dgv_Agrupacion.Columns("fecha").Visible = False
        dgv_Agrupacion.Columns("idusuario").Visible = False
        dgv_Agrupacion.Columns("fum").Visible = False

        dgv_Agrupacion.Columns("idagrupacion").Caption = "IdAgrupacion"
        dgv_Agrupacion.Columns("nombre").Caption = "IdAgrupacion"
    End Sub

#End Region

#Region "Eventos"
    Private Sub frmBuscarAgrupacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            TraerAgrupaciones("")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click
        Try
            IdAgrupacion = CInt(dgv_Agrupacion.GetRowCellValue(dgv_Agrupacion.FocusedRowHandle, "idagrupacion"))
            Selecciono = True
            Me.Close()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Salir_Click(sender As Object, e As EventArgs) Handles btn_Salir.Click
        Selecciono = False
        IdAgrupacion = 0
        Me.Close()
    End Sub



    Private Sub txt_Agrupacion_KeyUp(sender As Object, e As KeyEventArgs) Handles txt_Agrupacion.KeyUp
        Try
            TraerAgrupaciones(txt_Agrupacion.Text)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

#End Region
End Class