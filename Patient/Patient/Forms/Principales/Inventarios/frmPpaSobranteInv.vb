Public Class frmPpalSobranteInv
    Dim Sql As String
    Private objDataSet As Data.DataSet
    Private objDataSet1 As Data.DataSet 'Segundo Nivel
    Dim SucurOriB As String = ""
    Dim SucurDesB As String = ""
    Dim Sucursal As String = ""
    Dim division As String = ""
    Dim marca As String = ""
    Dim estatus As String = ""

    Dim FechaFinB As String = "1900-01-01"
    Dim FechaIniB As String = "1900-01-01"
    Dim SucursalB As String = ""
    Dim IdDivisionb As String = ""

    Dim EstatusB As String = "1900-01-01"
    Dim TraspasoIniB As String = "1900-01-01"
    Dim TraspasoFinB As String = "1900-01-01"
    Dim Opcion As Integer

    Dim MarcaFOTO As String = ""
    Dim EstiloNFOTO As String = ""
    Dim blnEntraDet As Boolean = False

    Dim NumIfB As Integer
    Public Sw_Filtro As Boolean = False
    Private izquierda As Integer = 0
    Private alto As Integer = 0

    Private Sub GenerarToolTip()
        Try
            'ToolTip.SetToolTip(Btn_Filtro, "Búsqueda Avanzada")
            ToolTip.SetToolTip(Btn_Aceptar, "Aceptar la acción requerida por el usuario")
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel ko")
            ToolTip.SetToolTip(Btn_Imprimir, "Imprimir Reporte")

            ToolTip.SetToolTip(Btn_Salir, "Salir")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub RellenaGrid()

        Using objFalt As New BCL.BCLSobranteInv(GLB_ConStringCipSis)

            Try
                'Me.Cursor = Cursors.WaitCursor
                DGrid.DataSource = Nothing
                objDataSet = objFalt.usp_PpalSobranteInv(Sucursal)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    DGrid.DataSource = objDataSet.Tables(0)
                    InicializaGrid()

                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True

                Else
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron registros que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                End If
                Me.Cursor = Cursors.Default
                Call LimpiarBusqueda()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Sub InicializaGrid()
        Try
            Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
            Dim row As DataRow = dt.NewRow()

            'row(4) = "TOTAL: "
            'row("total") = pub_SumarColumnaGrid(DGrid, 6, DGrid.RowCount - 1)
            'dt.Rows.InsertAt(row, 0)
            'DGrid.DataSource = dt

            DGrid.RowHeadersVisible = False
            DGrid.Columns("rank").HeaderText = "N°"
            DGrid.Columns("marca").HeaderText = "Marca"
            DGrid.Columns("estilon").HeaderText = "Modelo"
            DGrid.Columns("medida").HeaderText = "Medida"
            DGrid.Columns("serie").HeaderText = "Serie"
            DGrid.Columns("precioini").HeaderText = "Precio"

            DGrid.Columns("rank").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns("marca").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns("estilon").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns("medida").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns("serie").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns("precioini").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells


            DGrid.Columns("precioini").DefaultCellStyle.Format = "c"
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

    Private Sub Btn_Filtro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            Dim myForm As New frmFiltrosFaltanteInv
            myForm.Txt_SucurOri.Text = Sucursal

            myForm.Txt_DescripDivision.Text = IdDivisionb
            myForm.Txt_Division.Text = division




            myForm.ShowDialog()




            Sucursal = myForm.Txt_SucurOri.Text
            IdDivisionb = myForm.Txt_DescripDivision.Text
            division = myForm.Txt_Division.Text

            'SucurOriB = myForm.Txt_DescripSucurOri.Text


            If myForm.Sw_Filtro = True Then

                RellenaGrid()

            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick

        CargarFotoArticulo(DGrid.Rows(DGrid.CurrentRow.Index).Cells("marca").Value, DGrid.Rows(DGrid.CurrentRow.Index).Cells("estilon").Value)

    End Sub

    Private Sub CargarFotoArticulo(ByVal Marca, ByVal Estilon)
        'mreyes 14/Marzo/2012 07:06 p.m.
        'Glb_RutaArchivoFotos
        Try
            Dim Archivo As String = ""
            Dim NoFoto As String = "1"

            MarcaFOTO = Marca
            EstiloNFOTO = Estilon

            PBox.Visible = False
            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)

                Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Marca, Estilon, NoFoto)

                If objIO.pub_ExisteArchivo(Archivo) = True Then
                    PBox.Image = New System.Drawing.Bitmap(Archivo)
                    PBox.Visible = True
                    Exit Sub
                End If

                For i As Integer = 0 To 9
                    'GLB_RutaArchivoFotos = "C:\Users\Sistemas\Pictures\Sample Pictures\"
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

    Private Sub DGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.Click

        CargarFotoArticulo(DGrid.Rows(DGrid.CurrentRow.Index).Cells("marca").Value, DGrid.Rows(DGrid.CurrentRow.Index).Cells("estilon").Value)

    End Sub

    Private Sub DGrid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGrid.KeyUp

        CargarFotoArticulo(DGrid.Rows(DGrid.CurrentRow.Index).Cells("marca").Value, DGrid.Rows(DGrid.CurrentRow.Index).Cells("estilon").Value)

    End Sub

    Private Sub PBox_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PBox.DoubleClick
        'mreyes 03/Marzo/2012 10:01 a.m.
        Try
            Dim myForm As New frmConsultaImagen
            myForm.Txt_Estilon.Text = EstiloNFOTO
            myForm.Txt_Marca.Text = MarcaFOTO
            myForm.Txt_NoFoto.Text = 1
            myForm.ShowDialog()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmPpalPpalTraspasosAutomatico_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call GenerarToolTip()
        Call LimpiarBusqueda()

    End Sub

    Private Sub Btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Imprimir.Click
        Try
            Dim myForm As New frmReportsBrowser
            myForm.objDataSetSobranteInv = GenerarSobranteInv()
            myForm.ReportIndex = 5524
            myForm.Show()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)

        End Try
    End Sub

    Public Function GenerarSobranteInv() As DSSobranteInv
        Try
            Dim cont As Integer = 0
            GenerarSobranteInv = New DSSobranteInv

            For i As Integer = 0 To DGrid.RowCount - 2

                cont = 0
                Dim objDataRow1 As Data.DataRow = GenerarSobranteInv.Tables("Tbl_SobranteInv").NewRow()
                objDataRow1.Item("rank") = DGrid.Rows(i).Cells("rank").Value.ToString
                objDataRow1.Item("marca") = DGrid.Rows(i).Cells("marca").Value.ToString
                objDataRow1.Item("estilo") = DGrid.Rows(i).Cells("estilon").Value.ToString
                objDataRow1.Item("medida") = DGrid.Rows(i).Cells("medida").Value.ToString
                objDataRow1.Item("serie") = DGrid.Rows(i).Cells("serie").Value.ToString
                objDataRow1.Item("precio") = DGrid.Rows(i).Cells("PRECIOINI").Value.ToString



                GenerarSobranteInv.Tables("Tbl_SobranteInv").Rows.Add(objDataRow1)

                'Val(objDataRow1.Item("")=DGrid.Rows(i).Cells("").Value)

            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)

        End Try
    End Function

    Private Sub LimpiarBusqueda()
        If GLB_CveSucursal = "01" Or GLB_CveSucursal = "02" Or GLB_CveSucursal = "06" Or GLB_CveSucursal = "07" Or GLB_CveSucursal = "08" Or GLB_CveSucursal = "11" Or GLB_CveSucursal = "15" Then
            SucursalB = GLB_CveSucursal
        Else
            SucursalB = ""
        End If


        PBox.Visible = False
        'IdDivisionb = ""

        'FechaInib = Format(Now.Add(New TimeSpan(-2, 0, 0, 0)), "yyyy-MM-dd")
        'FechaFinb = Format(Now.Date, "yyyy-MM-dd")

    End Sub
    Private Sub PBox_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PBox.MouseDown
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                izquierda = e.X
                alto = e.Y
                PBox.Cursor = Cursors.SizeAll
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub PBox_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PBox.MouseMove
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                PBox.Location = New Point(PBox.Left + e.X - izquierda, PBox.Top + e.Y - alto)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub PBox_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PBox.MouseUp
        Try
            PBox.Cursor = Cursors.Default
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click
        Try
            Sucursal = Txt_SucurOri.Text
            RellenaGrid()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_SucurOri_TextChanged(sender As Object, e As EventArgs) Handles Txt_SucurOri.TextChanged

    End Sub
    Private Sub TraerSucursal()

        If Txt_SucurOri.Text.Length = 0 Then Exit Sub

        Try
            'Get the specific project selected in the ListView control
            If Txt_SucurOri.Text.Trim.Length < 2 Then
                Txt_SucurOri.Text = pub_RellenarIzquierda(Txt_SucurOri.Text.Trim, 2)
            End If

            Call TxtLostfocusPersis(Txt_SucurOri, Txt_DescripSucurOri, "S")


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub
    Private Sub Txt_Sucursal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_SucurOri.LostFocus
        Try
            Call TraerSucursal()
            ' ir a buscar última referencia de inventario.

            Using objMySqlGral As New BCL.BCLSobranteInv(GLB_ConStringPerSis)
                Try
                    objDataSet = objMySqlGral.usp_PpalSucursalEnInventario(Txt_SucurOri.Text)

                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Txt_SucurOri.Focus()
                        Exit Sub


                    End If


                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using
   


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub
    Private Sub TxtLostfocusPersis(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
        'Dim myForm As New frmConsulta


        If Txt_Campo.Text.Length = 0 Then Exit Sub
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringPerSis)
            Try

                objDataSet = objMySqlGral.usp_TraerDescripcion(Tipo, Txt_Campo.Text, "")

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_Campo1.Text = objDataSet.Tables(0).Rows(0).Item("campo").ToString
                Else
                    Txt_Campo.Text = ""
                    'myForm.Tipo = Tipo
                    'myForm.Sw_Nomina = False
                    'myForm.ShowDialog()
                    'Txt_Campo.Text = myForm.Campo
                    'Txt_Campo1.Text = myForm.Campo1
                    If Txt_Campo.Text.Length = 0 Then
                        Txt_Campo.Focus()
                    End If
                End If

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub
End Class