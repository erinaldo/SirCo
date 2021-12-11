Public Class frmPpalDetFactProv
    'Tony García - 03/Diciembre/2012 04:35 p.m.

    Private objDataSet As Data.DataSet
    'Private FechaInicio As String
    'Private FechaFin As String
    Dim SucursalB As String
    Dim FactProvB As String
    Dim SerieIniB As String
    Dim SerieFinB As String
    'Dim Marcab As String
    'Dim Estilonb As String 

    Dim Sw_Load As Boolean = True
    Dim Sw_NoRegistros As Boolean = False
    Dim Sw_Pintar As Boolean = False

    Private Sub frmPpalPpalDetFactProv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        Call LimpiarBusqueda()
        Call usp_TraerUltimaFactProv()
        Call RellenaGrid()
        Sw_Pintar = True
        'Sw_Load = False 
    End Sub

    Private Sub frmPpalPpalDetFactProv_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Sw_NoRegistros = False Then Exit Sub
        'If Sw_Load = True Then
        '    Sw_Load = False
        'blnPrimero = True
        InicializaGrid()
        'AgregarColumna()
        '    Call BarrerGrid()
        'End If
    End Sub

    Private Sub LimpiarBusqueda()
        SucursalB = "15"
        FactProvB = ""
        SerieIniB = ""
        SerieFinB = ""
    End Sub

    Private Sub usp_TraerUltimaFactProv()
        Dim dtsUltFactProv As Data.DataSet
        Try
            Using objFactProv As New BCL.BCLDetFactProv(GLB_ConStringCipSis)
                dtsUltFactProv = objFactProv.ups_TraerUltimaFactProv(SucursalB)
                FactProvB = dtsUltFactProv.Tables(0).Rows(0).Item("factprov")
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub RellenaGrid()
        'Tony Garcia - 04/Diciembre/2012 - 5:15 p.m.
        Using objFactProv As New BCL.BCLDetFactProv(GLB_ConStringCipSis)

            Try
                Me.Cursor = Cursors.WaitCursor
                'DGrid.ReadOnly = True
                DGrid.DataSource = Nothing

                objDataSet = objFactProv.usp_PpalDetFactProv(SucursalB, FactProvB, SerieIniB, SerieFinB)

                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section 

                    DGrid.DataSource = objDataSet.Tables(0)
                    'If Sw_Load = False Then
                    InicializaGrid()
                    'End If
                    'LimpiarBusqueda()
                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True
                    Sw_NoRegistros = True
                    Sw_Pintar = True
                    'Call Colores()
                Else
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron registros que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                End If
                Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Sub InicializaGrid()

        Try

            Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)

            DGrid.DataSource = dt

            DGrid.RowHeadersVisible = False
            DGrid.Columns(0).HeaderText = "Sucursal" 'oculto
            DGrid.Columns(1).HeaderText = "Factura"
            DGrid.Columns(2).HeaderText = "Marca"
            DGrid.Columns(3).HeaderText = "Estilo Nuestro"
            DGrid.Columns(4).HeaderText = "Corrida"
            DGrid.Columns(5).HeaderText = "Medida"
            DGrid.Columns(6).HeaderText = "Serie"
            DGrid.Columns(7).HeaderText = "Cant."
            DGrid.Columns(8).HeaderText = "Costo"
            DGrid.Columns(9).HeaderText = "Costo Desc."
            DGrid.Columns(10).HeaderText = "Sucursal O.C."
            DGrid.Columns(11).HeaderText = "Orden Compra"
            DGrid.Columns(12).HeaderText = "Descripción"
            DGrid.Columns(13).HeaderText = "Est. Fabrica"

            DGrid.Columns(0).Visible = False

            If GLB_Sucursal <> "" Then
                DGrid.Columns(8).Visible = False
                DGrid.Columns(9).Visible = False
            End If

            DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            DGrid.Columns(8).DefaultCellStyle.Format = "c"
            DGrid.Columns(9).DefaultCellStyle.Format = "c"

            DGrid.Columns(12).DisplayIndex = 4
            DGrid.Columns(13).DisplayIndex = 5

            For i As Integer = 0 To DGrid.Rows.Count - 1
                For j As Integer = 0 To DGrid.Columns.Count - 1
                    DGrid.Columns(j).ReadOnly = True
                Next
            Next

            'DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.BackColor = Color.PowderBlue
            'DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            'DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Me.Close()
        Me.Dispose()
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

    Private Sub frmPpalPpalDetFactProv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Filtro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        Dim myForm As New frmFiltrosFactProv
        myForm.Txt_Sucursal.Text = SucursalB
        myForm.Txt_DescripSucursal.Text = "CEDIS"
        myForm.Txt_NumFact.Text = FactProvB
        myForm.Txt_SerieIni.Text = SerieIniB
        myForm.Txt_SerieFin.Text = SerieFinB

        myForm.ShowDialog()

        SucursalB = myForm.Txt_Sucursal.Text
        FactProvB = myForm.Txt_NumFact.Text
        SerieIniB = myForm.Txt_SerieIni.Text
        SerieFinB = myForm.Txt_SerieFin.Text

        If myForm.Sw_Filtro = True Then
            Call RellenaGrid()
        End If
    End Sub
End Class