Public Class frmConsultaEstilo
    'mreyes 15/Febrero/2012 09:50 a.m.

    Public Tipo As String    'M = MARCA, F = FAMILIA, L = LINEA, P = PROVEEDOR , TA = TIPOARTICULO, C = CATEGORIA
    'E = ESTILO
    Public Campo As String '' valor de regreso para el primer texto
    Public Campo1 As String ''valor de regreso para el segundo texto
    Public Campo2 As String = ""

    Dim SqlBuscar As String
    Public Marcab As String
    Public EstiloFb As String

    Private objDataSet As Data.DataSet

    'Forma que busca en varias tablas, por lo general un id y descripción


    Private Sub RellenaGrid()
        Using objEstilos As New BCL.BCLCatalogoEstilos(Glb_ConStringCipSis)
            Try

                objDataSet = objEstilos.usp_TraerEstilo(0, Marcab, "", EstiloFb, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "%" & Txt_Buscar.Text & "%")
                'Populate the Project Details section
                DGrid.ReadOnly = True
                DGrid.DataSource = Nothing

                DGrid.DataSource = objDataSet.Tables(0)

                Call InicializaGrid()

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using


    End Sub



    Sub InicializaGrid()
        '' marca, Estilon, Estilof, descripc, familia, linea, proveedor, tipoart, categoria
        'mreyes 15/Febrero/2011 09:52 p.m.
        Try
            DGrid.RowHeadersVisible = False

            ''DGrid.Columns(0).HeaderText = "Marca"
            ''DGrid.Columns(1).HeaderText = "Estilo Nuestro"
            ''DGrid.Columns(2).HeaderText = "Estilo Fábrica"
            ''DGrid.Columns(3).HeaderText = "Descripción"
            ''DGrid.Columns(4).HeaderText = "Familia"
            ''DGrid.Columns(5).HeaderText = "Línea"
            ''DGrid.Columns(6).HeaderText = "Proveedor"
            ''DGrid.Columns(7).HeaderText = "TipoArt"
            ''DGrid.Columns(8).HeaderText = "Categoría"
            ''DGrid.Columns(0).Width = 100
            ''DGrid.Columns(1).Width = 100
            ''DGrid.Columns(2).Width = 100
            ''DGrid.Columns(3).Width = 300
            ''DGrid.Columns(4).Width = 80
            ''DGrid.Columns(5).Width = 80
            ''DGrid.Columns(6).Width = 80
            ''DGrid.Columns(7).Width = 80
            ''DGrid.Columns(8).Width = 80

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmConsulta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If

    End Sub

    Private Sub frmConsulta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
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
                Campo = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("estilon").Value.ToString
                Campo1 = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("descripc").Value.ToString
                Campo2 = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("medida").Value.ToString
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

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub DGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick
        Try
            Campo = DGrid.Rows(DGrid.CurrentRow.Index).Cells("estilon").Value.ToString
            Campo1 = DGrid.Rows(DGrid.CurrentRow.Index).Cells("descripc").Value.ToString
            Campo2 = DGrid.Rows(DGrid.CurrentRow.Index).Cells("medida").Value.ToString

            Me.Close()
            Me.Dispose()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
End Class