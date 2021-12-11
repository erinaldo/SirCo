Public Class frmConsultaArticulos

    Public Tipo As String    'M = MARCA, F = FAMILIA, L = LINEA, P = PROVEEDOR , TA = TIPOARTICULO, C = CATEGORIA
    'E = ESTILO
    Public Campo As String = "" '' valor de regreso para el primer texto
    Public Campo1 As String = "" ''valor de regreso para el segundo texto
    Public Campo2 As String = "" ''valor de regreso para el tercer texto en departamentos.

    Public Sw_Nomina As Boolean = False
    Public idDepto As Integer = 0
    Dim SqlBuscar As String

    Private objDataSet As Data.DataSet
    'mreyes 09/Febrero/2012 12:42 a.m.
    'Forma que busca en varias tablas, por lo general un id y descripción

    Private Sub TraerEstilosCoqueta()
        Using ObjCatalogoEstilos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
            Try
                Me.Text = "Consulta Articulos Coqueta"
                If Txt_Buscar.Text.Length Then
                    objDataSet = ObjCatalogoEstilos.usp_TraerEstilo(0, "CTA", "", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "%" & Txt_Buscar.Text & "%")
                Else
                    objDataSet = ObjCatalogoEstilos.usp_TraerEstilo(0, "CTA", "", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "")
                End If
                DGrid.ReadOnly = True
                DGrid.DataSource = Nothing
                DGrid.DataSource = objDataSet.Tables(0)
                InicializaGrid()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub RellenaGrid()
        Try
            Call TraerEstilosCoqueta()
            Exit Sub
            'Populate the Project Details section


            InicializaGrid()


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Sub InicializaGrid()
        DGrid.RowHeadersVisible = False
        ''DGrid.AllowUserToResizeColumns = True
        DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        DGrid.Columns(0).HeaderText = "Marca"
        DGrid.Columns(1).HeaderText = "Descripcion Marca"
        DGrid.Columns(2).HeaderText = "EstiloN"
        DGrid.Columns(3).HeaderText = "EstiloF"
        DGrid.Columns(4).HeaderText = "Descripcion"
        For i As Integer = 0 To DGrid.Columns.Count - 1
            If i <= 4 Then
                DGrid.Columns(i).Visible = True
            Else
                DGrid.Columns(i).Visible = False
            End If
        Next
    End Sub

    Private Sub frmConsulta_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        glb_formconsulta = False
    End Sub

    Private Sub frmConsulta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            glb_formconsulta = True
            Me.Close()
        End If
    End Sub

    Private Sub frmConsulta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            glb_formconsulta = True
            Call RellenaGrid()
            Call GenerarToolTip()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
            ToolTip.SetToolTip(Txt_Buscar, "Escriba lo que pretende buscar")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Buscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Buscar.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Buscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Buscar.TextChanged
        Try
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellDoubleClick


    End Sub

    Private Sub DGrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DGrid.KeyPress
        Try
            If e.KeyChar = ChrW(Keys.Enter) Then
                Campo = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells(0).Value.ToString.Trim()
                Campo1 = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells(1).Value.ToString.Trim()
                Campo2 = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells(2).Value.ToString.Trim()
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

    Private Sub DGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick
        Try
            Campo = DGrid.Rows(DGrid.CurrentRow.Index).Cells(2).Value.ToString.Trim()
            Campo1 = DGrid.Rows(DGrid.CurrentRow.Index).Cells(3).Value.ToString.Trim()
            Campo2 = DGrid.Rows(DGrid.CurrentRow.Index).Cells(4).Value.ToString.Trim()

            Me.Close()
            Me.Dispose()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

End Class