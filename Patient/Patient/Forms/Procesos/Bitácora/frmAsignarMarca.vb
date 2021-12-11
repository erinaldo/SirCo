Public Class frmAsignarMarca

    Dim Sw_NoRegistros As Boolean = False
    Dim SqlBuscar As String
    Private objDataSet As Data.DataSet
    Public IdEmpleado As Integer = 0

    Private Sub usp_TraerEmpleadoCompras()
        Using objMarca As New BCL.BCLCatalogoMarca(GLB_ConStringNomSis)
            Try

                objDataSet = objMarca.usp_TraerEmpleadoCompras()
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    DGrid.DataSource = Nothing
                    DGrid.DataSource = objDataSet.Tables(0)
                    Sw_NoRegistros = True
                    InicializaGrid()
                Else
                    Sw_NoRegistros = False
                End If

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub RellenaGrid()
        Dim SqlWhere As String = ""
        Call usp_TraerEmpleadoCompras()
    End Sub

    Sub InicializaGrid()
        DGrid.RowHeadersVisible = False

        DGrid.Columns(0).HeaderText = "Id Empleado"
        DGrid.Columns(1).HeaderText = "Nombre"

        DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        For i As Integer = 0 To DGrid.Columns.Count - 1
            DGrid.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next

        DGrid.Columns(0).ReadOnly = True
        DGrid.Columns(1).ReadOnly = True
    End Sub

    Private Sub frmConsulta_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GLB_FormConsulta = False
    End Sub

    Private Sub frmConsulta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            GLB_FormConsulta = True
            Me.Close()
        End If
    End Sub

    Private Sub frmConsulta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            GLB_FormConsulta = True
            Call RellenaGrid()
            Call GenerarToolTip()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub GenerarToolTip()
        Try
            'ToolTip.SetToolTip(Btn_Aceptar, "Filtrar marcas seleccionadas")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick
        Try
            IdEmpleado = DGrid.Rows(DGrid.CurrentRow.Index).Cells(IdEmpleado).Value

            Me.Close()
            Me.Dispose()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DGrid.KeyPress
        Try
            If e.KeyChar = ChrW(Keys.Enter) Then

                IdEmpleado = DGrid.Rows(DGrid.CurrentRow.Index).Cells(IdEmpleado).Value

                Me.Close()
                Me.Dispose()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
End Class