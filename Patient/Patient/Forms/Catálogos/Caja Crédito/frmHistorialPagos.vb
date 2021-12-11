Public Class frmHistorialPagos

#Region "VARIABLES"
    Dim objDataSet As New DataSet
    Public Distribuidor As String = ""
#End Region

#Region "EVENTOS"

#Region "FORMA"

    Private Sub frmHistorialPagos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

#End Region

#Region "BOTON"

    Private Sub btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Aceptar.Click
        Try
            Me.Close()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

#End Region

#End Region

#Region "METODOS"


    Private Sub RellenaGrid()
        Try
            Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                objDataSet = objCajaCredito.usp_TraerHistorialPagos(Distribuidor)
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                DGridCobrado.DataSource = objDataSet.Tables(0)
                InicializaGrid()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        Finally
        End Try
    End Sub

    Private Sub InicializaGrid()
        Try
            DGridCobrado.RowHeadersVisible = False
            DGridCobrado.Columns("distrib").HeaderText = "Distribuidor"
            DGridCobrado.Columns("fecha").HeaderText = "Fecha"
            DGridCobrado.Columns("sucursal").HeaderText = "Det"
            DGridCobrado.Columns("folio").HeaderText = "Folio"
            DGridCobrado.Columns("status").HeaderText = "Estatus"
            DGridCobrado.Columns("subtotal").HeaderText = "Subtotal"
            DGridCobrado.Columns("descuento").HeaderText = "Descuento"
            DGridCobrado.Columns("importe").HeaderText = "Importe"
            DGridCobrado.Columns("distrib").Visible = False
            DGridCobrado.Columns("fecha").DefaultCellStyle.Format = "dd/MM/yyyy"
            DGridCobrado.Columns("subtotal").DefaultCellStyle.Format = "c"
            DGridCobrado.Columns("descuento").DefaultCellStyle.Format = "c"
            DGridCobrado.Columns("importe").DefaultCellStyle.Format = "c"

            DGridCobrado.Columns("subtotal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGridCobrado.Columns("descuento").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGridCobrado.Columns("importe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGridCobrado.Columns("status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGridCobrado.Columns("folio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGridCobrado.Columns("fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGridCobrado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DGridCobrado.ReadOnly = True

            DGridCobrado.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGridCobrado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            'DGridCobrado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            'DGrid.Columns("fechacorte").DefaultCellStyle.Format = "dd/MM/yyyy"

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        Finally
        End Try
    End Sub

#End Region

End Class