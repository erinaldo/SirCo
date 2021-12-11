Public Class frmPpalInventCedis
    'mreyes 18/Octubre/2012 01:54 p.m.
    Dim MarcaFOTO As String = ""
    Dim EstiloNFOTO As String = ""
    Private objDataSet As Data.DataSet
    Dim Sw_NoRegistros As Boolean = False
    Dim Sw_Pintar As Boolean = False
    Dim Sw_Load As Boolean = True



    Public Sucursal As String = ""
    Public Marca As String = ""
    Public TipoArt As String = ""
    Public DiasIni As Integer = 0
    Public DiasFin As Integer = 0



    Private Sub frmPpalNomina_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

    End Sub

    Private Sub frmPpalProveedores_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then
                Me.Close()
            End If

            If e.KeyCode = Keys.F5 Then
                Call Btn_Filtro_Click_1(sender, e)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub frmPpalProveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub GenerarToolTip()
        Try
            '
            ToolTip.SetToolTip(Btn_Filtro, "Búsqueda Avanzada")
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
            ToolTip.SetToolTip(Btn_Salir, "Salir")
            ToolTip.SetToolTip(Btn_Foto, "Imagen del Producto")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub RellenaGrid()
        'mreyes 30/Junio/2012   10:34 a.m.
        Using objRegistro As New BCL.BCLAntiInvent(GLB_ConStringDWH)

            Try
                Me.Cursor = Cursors.WaitCursor
                If Sucursal = "" Then
                    Sucursal = 15
                End If
                objDataSet = objRegistro.usp_PpalDetAntiInvent(Sucursal, Marca, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, DiasIni, DiasFin)
                DGrid.ReadOnly = True
                DGrid.DataSource = Nothing
                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section

                    DGrid.DataSource = objDataSet.Tables(0)
                    InicializaGrid()
                    'LimpiarBusqueda()
                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True

                    Sw_NoRegistros = True
                    Sw_Pintar = True
                    Sw_Pintar = True
                Else
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontro Información que cumpla con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
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
        'mreyes 30/Junio/2012 10:47 a.m.
        Try



            DGrid.Columns(0).Frozen = True
            DGrid.Columns(1).Frozen = True
            DGrid.Columns(0).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Columns(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            DGrid.Columns(1).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Columns(1).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

            DGrid.RowHeadersVisible = False

            Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)

            Dim row As DataRow = dt.NewRow()

            row(1) = "Total: "

            row(6) = pub_SumarColumnaGrid(DGrid, 6, DGrid.RowCount - 1)
            row(9) = pub_SumarColumnaGrid(DGrid, 9, DGrid.RowCount - 1)
            row(10) = pub_SumarColumnaGrid(DGrid, 10, DGrid.RowCount - 1)
            dt.Rows.InsertAt(row, 0)
            DGrid.DataSource = dt

            DGrid.Columns(0).HeaderText = "Ren"
            DGrid.Columns(1).HeaderText = "Det"
            DGrid.Columns(2).HeaderText = "Sucursal"
            DGrid.Columns(3).HeaderText = "Marca"
            DGrid.Columns(4).HeaderText = "Modelo"
            DGrid.Columns(5).HeaderText = "Descripción"
            DGrid.Columns(6).HeaderText = "PRS"
            DGrid.Columns(7).HeaderText = "Fecha Ult Recibo"
            DGrid.Columns(8).HeaderText = "Días"
            DGrid.Columns(9).HeaderText = "Costo"
            DGrid.Columns(10).HeaderText = "Precio"
            DGrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(9).DefaultCellStyle.Format = "c"
            DGrid.Columns(10).DefaultCellStyle.Format = "c"

            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            DGrid.Rows(0).Frozen = True

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

    Private Sub Btn_Filtro_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        Dim myForm As New frmFiltrosInvenCedis

        myForm.ShowDialog()

        Sucursal = myForm.Txt_Sucursal.Text
        Marca = myForm.Txt_Marca.Text
        TipoArt = myForm.Txt_TipoArt.Text
        If myForm.Txt_DiasIni.Text.Trim = "" Then
            DiasIni = 0
        Else
            DiasIni = myForm.Txt_DiasIni.Text.Trim
        End If
        If myForm.Txt_DiasFin.Text.Trim = "" Then
            DiasFin = 0
        Else
            DiasFin = myForm.Txt_DiasFin.Text.Trim
        End If

        If myForm.Sw_Filtro = True Then
            Call RellenaGrid()
        End If
    End Sub

    Private Sub DGrid_KeyUp_1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGrid.KeyUp
        If IsDBNull(DGrid.Rows(DGrid.CurrentRow.Index).Cells("marca").Value) Then
            Exit Sub
        End If
        CargarFotoArticulo(DGrid.Rows(DGrid.CurrentRow.Index).Cells("marca").Value, DGrid.Rows(DGrid.CurrentRow.Index).Cells("estilon").Value)
    End Sub
    Private Sub CargarFotoArticulo(ByVal Marca, ByVal Estilon)
        'mreyes 14/Marzo/2012 07:06 p.m.
        'Glb_RutaArchivoFotos
        Try
            Dim Archivo As String = ""
            Dim NoFoto As String = "1"

            MarcaFOTO = Marca
            ESTILONFOTO = Estilon
            PBox.Visible = False
            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)

                Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Marca, Estilon, NoFoto)

                If objIO.pub_ExisteArchivo(Archivo) = True Then
                    PBox.Image = New System.Drawing.Bitmap(Archivo)
                    PBox.Visible = True
                    Exit Sub
                End If

                For i As Integer = 0 To 9
                    Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Marca, Estilon, i)
                    If objIO.pub_ExisteArchivo(Archivo) = True Then
                        PBox.Image = New System.Drawing.Bitmap(Archivo)
                        PBox.Visible = True
                        Exit Sub
                    End If
                Next

            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Foto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Foto.Click
        'mreyes 03/Marzo/2012 10:01 a.m.
        Try
            Dim myForm As New frmConsultaImagen
            myForm.Txt_Estilon.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("Estilon").Value.ToString
            myForm.Txt_Marca.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("Marca").Value.ToString.Trim()
            myForm.Txt_NoFoto.Text = "1"
            myForm.ShowDialog()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub DGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.Click
        If IsDBNull(DGrid.Rows(DGrid.CurrentRow.Index).Cells("marca").Value) Then
            Exit Sub
        End If
        CargarFotoArticulo(DGrid.Rows(DGrid.CurrentRow.Index).Cells("marca").Value, DGrid.Rows(DGrid.CurrentRow.Index).Cells("estilon").Value)
    End Sub

End Class