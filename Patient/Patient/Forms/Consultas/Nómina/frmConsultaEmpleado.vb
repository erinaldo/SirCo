Public Class frmConsultaEmpleado '(SIMPLE)
    'mreyes 11/Junio/2012 04:46 p.m.
    Public Tipo As String
    Public Campo As String = "" '' valor de regreso para el primer texto
    Public Campo1 As String = "" ''valor de regreso para el segundo texto
    Public Estatus As String = ""
    Public IdDepto As Integer = 0
    Public IdPuesto As Integer = 0
    Dim SqlBuscar As String
    Public CatGastos As Boolean = False

    Private objDataSet As Data.DataSet

    Private Sub RellenaGrid()
        Dim Sucursal As String = ""
        'mreyes 11/Junio/2012 05:05 p.m.

        Using objMySqlGral As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)
            Try
                Dim ApPaterno As String = ""
                Dim ApMaterno As String = ""
                Dim Nombre As String = ""

                If Txt_ApPaterno.Text.Length > 0 Then
                    ApPaterno = "%" & Txt_ApPaterno.Text & "%"
                End If

                If Txt_ApMaterno.Text.Length > 0 Then
                    ApMaterno = "%" & Txt_ApMaterno.Text & "%"
                End If

                If Txt_Nombre.Text.Length > 0 Then
                    Nombre = "%" & Txt_Nombre.Text & "%"
                End If

                
                If CatGastos = True Then
                    If GLB_CveSucursal = "01" Or GLB_CveSucursal = "02" Or GLB_CveSucursal = "06" Or GLB_CveSucursal = "07" Or GLB_CveSucursal = "08" Or GLB_CveSucursal = "11" Then
                        Sucursal = GLB_CveSucursal
                    Else
                        Sucursal = ""
                    End If
                    objDataSet = objMySqlGral.usp_TraerNomEmpleadosuc(0, ApPaterno, ApMaterno, Nombre, "A", IdDepto, Sucursal)
                Else
                    objDataSet = objMySqlGral.usp_TraerNomEmpleado(0, ApPaterno, ApMaterno, Nombre, Estatus, IdDepto)
                End If


                'Populate the Project Details section
                DGrid.ReadOnly = True
                DGrid.DataSource = Nothing
                DGrid.DataSource = objDataSet.Tables(0)

                InicializaGrid()


            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Sub InicializaGrid()
        DGrid.RowHeadersVisible = False
        
        DGrid.Columns(0).HeaderText = "IdEmpleado"
        DGrid.Columns(1).HeaderText = "Nombre Completo"
        DGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGrid.Columns(2).Visible = False
        DGrid.Columns(3).Visible = False
        DGrid.Columns(4).Visible = False
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
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
            ToolTip.SetToolTip(Txt_ApPaterno, "Escriba lo que pretende buscar")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Txt_Buscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_ApPaterno.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Buscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_ApPaterno.TextChanged
        Try
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub DGrid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellDoubleClick


        Campo = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells(0).Value.ToString.Trim()
        Campo1 = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells(1).Value.ToString.Trim()

        Me.Close()
        Me.Dispose()

    End Sub


    Private Sub DGrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DGrid.KeyPress
        Try
            If e.KeyChar = ChrW(Keys.Enter) Then
                Campo = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells(0).Value.ToString.Trim()
                Campo1 = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells(1).Value.ToString.Trim()

                Me.Close()
                Me.Dispose()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub Btn_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Excel.Click
        Try
            If ExportarDGridAExcel(DGrid) = False Then
                MsgBox("Error al exportar a Excel. Intente nuevamente.", MsgBoxStyle.Critical, "Excel")
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub

    Private Sub DGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick
        Try
            Campo = DGrid.Rows(DGrid.CurrentRow.Index).Cells(0).Value.ToString.Trim()
            Campo1 = DGrid.Rows(DGrid.CurrentRow.Index).Cells(1).Value.ToString.Trim()
            GLB_RefrescarPedido = True
            Me.Close()
            Me.Dispose()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmConsulta_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LocationChanged

    End Sub

    Private Sub Txt_ApMaterno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_ApMaterno.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_ApMaterno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_ApMaterno.TextChanged
        Try
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Nombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Nombre.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Nombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Nombre.TextChanged
        Try
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_ApPaterno_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_ApPaterno.Validated

    End Sub
End Class