Public Class frmPpalEtiquetasAparador
    'mreyes 26/Agosto/2016   11:54 a.m.

    Private objDataSet As Data.DataSet
    Private objDataSet1 As Data.DataSet 'Segundo Nivel
    Dim SucurOriB As Integer = 0
    Dim SucurDesB As Integer = 0
    Dim FechaInib As String
    Dim FechaFinb As String

    Dim Sw_Load As Boolean = True
    Dim Sw_NoRegistros As Boolean = False
    Dim Sw_Pintar As Boolean = False
    Public Opcion As Integer = 0   '1 = Enviado,  2 = Por Recibir
    Public OpcionSP As Integer = 0
    Dim MarcaFOTO As String = ""
    Dim EstiloNFOTO As String = ""
    Dim blnEntraDet As Boolean = False

    Dim IdProTrasB As Integer = 0
    Dim EstatusB As String = ""
    Private izquierda As Integer = 0
    Private alto As Integer = 0



    Private Sub frmPpalPpalDetFactProv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dia As String = ""
        Call GenerarToolTip()
        Sw_Pintar = True
        Sw_Load = True
        Call LimpiarBusqueda()
        'fecha inicial es 
        dia = Now.Date.ToString("dddd")
        Lbl_PeriodoVentas.Visible = True

        If UCase(dia) = "LUNES" Then
            FechaInib = Format(Now.Add(New TimeSpan(-7, 0, 0, 0)), "yyyy-MM-dd")
            FechaFinb = Format(Now.Add(New TimeSpan(-1, 0, 0, 0)), "yyyy-MM-dd")
        End If

        If UCase(dia) = "MARTES" Then
            FechaInib = Format(Now.Add(New TimeSpan(-8, 0, 0, 0)), "yyyy-MM-dd")
            FechaFinb = Format(Now.Add(New TimeSpan(-2, 0, 0, 0)), "yyyy-MM-dd")
        End If

        If UCase(dia) = "MIÉRCOLES" Then
            FechaInib = Format(Now.Add(New TimeSpan(-9, 0, 0, 0)), "yyyy-MM-dd")
            FechaFinb = Format(Now.Add(New TimeSpan(-3, 0, 0, 0)), "yyyy-MM-dd")
        End If


        If UCase(dia) = "JUEVES" Then
            FechaInib = Format(Now.Add(New TimeSpan(-10, 0, 0, 0)), "yyyy-MM-dd")
            FechaFinb = Format(Now.Add(New TimeSpan(-4, 0, 0, 0)), "yyyy-MM-dd")
        End If

        If UCase(dia) = "VIERNES" Then
            FechaInib = Format(Now.Add(New TimeSpan(-11, 0, 0, 0)), "yyyy-MM-dd")
            FechaFinb = Format(Now.Add(New TimeSpan(-5, 0, 0, 0)), "yyyy-MM-dd")
        End If

        If UCase(dia) = "SÁBADO" Then
            FechaInib = Format(Now.Add(New TimeSpan(-12, 0, 0, 0)), "yyyy-MM-dd")
            FechaFinb = Format(Now.Add(New TimeSpan(-6, 0, 0, 0)), "yyyy-MM-dd")
        End If

        If UCase(dia) = "DOMINGO" Then
            FechaInib = Format(Now.Add(New TimeSpan(-13, 0, 0, 0)), "yyyy-MM-dd")
            FechaFinb = Format(Now.Add(New TimeSpan(-7, 0, 0, 0)), "yyyy-MM-dd")
        End If
        Lbl_PeriodoVentas.Text = "Periodo del " & FechaInib & " al " & FechaFinb
        Call RellenaGrid()



    End Sub

    Private Sub frmPpalPpalDetFactProv_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Sw_NoRegistros = False Then Exit Sub

    End Sub

    Private Sub GenerarToolTip()
        Try

            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")


            ToolTip.SetToolTip(Btn_Salir, "Salir")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub LimpiarBusqueda()
        If GLB_CveSucursal = "01" Or GLB_CveSucursal = "02" Or GLB_CveSucursal = "06" Or GLB_CveSucursal = "07" Or GLB_CveSucursal = "08" Or GLB_CveSucursal = "11" Then
            If Opcion = 1 Then
                SucurDesB = GLB_CveSucursal
            ElseIf Opcion = 2 Then
                SucurOriB = GLB_CveSucursal
            End If
        Else
            SucurOriB = 0
            SucurDesB = 0
        End If

        FechaInib = "1900-01-01"
        FechaFinb = "1900-01-01"


    End Sub

    Private Sub RellenaGrid()
        'mreyes 26/Agosto/2016   12:17 p.m.
        DGrid.Visible = False
        'InicializaGrid()
        If GLB_CveSucursal <> "" Then
            SucurOriB = GLB_CveSucursal
        Else
            SucurOriB = 1
        End If


        Using objTrasp As New BCL.BCLEtiquetasAparador(GLB_ConStringDwhSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                'DGrid.ReadOnly = True
                DGrid.DataSource = Nothing

                objDataSet = objTrasp.usp_PpalEtiquetasAparador(SucurOriB, FechaInib, FechaFinb)

                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section 
                    'DGrid.ColumnCount = objDataSet.Tables(0).Columns.Count
                    '
                    DGrid.DataSource = objDataSet.Tables(0)
                    InicializaGrid()

                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True
                    Sw_NoRegistros = True
                    Sw_Pintar = True

                Else
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron registros que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                End If
                Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()
                DGrid.Visible = True
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Sub InicializaGrid()
        Try


            DGrid.RowHeadersVisible = False
            DGrid.Columns(0).HeaderText = "Posicion"
            DGrid.Columns(1).HeaderText = "Etiqueta"
            DGrid.Columns(2).HeaderText = "Depto"
            DGrid.Columns(3).HeaderText = "Línea"
            DGrid.Columns(4).HeaderText = "L1"
            DGrid.Columns(5).HeaderText = "L3"
            DGrid.Columns(6).HeaderText = "Marca"
            DGrid.Columns(7).HeaderText = "Modelo"



            DGrid.Columns(0).Visible = False


            DGrid.Columns(2).Visible = False


            DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells


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
            Dim myForm As New frmFiltrosTraspasosPendRecibo
            myForm.Opcion = Opcion
            myForm.Txt_SucurOri.Text = SucurOriB
            myForm.Txt_SucurDes.Text = SucurDesB

            If FechaInib <> "1900-01-01" Then
                myForm.Chk_FechaTraspaso.Checked = True
                myForm.DTPicker2.Value = FechaInib
                myForm.DTPicker3.Value = FechaFinb
            End If

            If OpcionSP = 3 Then
                myForm.Cbo_Tipo.Text = "PENDIENTES"
            ElseIf OpcionSP = 2 Then
                myForm.Cbo_Tipo.Text = "PARCIALES"
            ElseIf OpcionSP = 1 Then
                myForm.Cbo_Tipo.Text = "TODOS"
            End If

            myForm.ShowDialog()

            SucurOriB = myForm.Txt_SucurOri.Text
            SucurDesB = myForm.Txt_SucurDes.Text

            If myForm.Chk_FechaTraspaso.Checked = True Then
                FechaInib = Format(myForm.DTPicker2.Value, "yyyy-MM-dd")
                FechaFinb = Format(myForm.DTPicker3.Value, "yyyy-MM-dd")
            Else
                FechaInib = "1900-01-01"
                FechaFinb = "1900-01-01"
            End If

            If myForm.Cbo_Tipo.Text = "PENDIENTES" Then
                OpcionSP = 3
            ElseIf myForm.Cbo_Tipo.Text = "PARCIALES" Then
                OpcionSP = 2
            ElseIf myForm.Cbo_Tipo.Text = "TODOS" Then
                OpcionSP = 1
            End If

            If myForm.Sw_Filtro = True Then
                Call RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_RecibosParciales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            OpcionSP = 2
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_RecibosTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            OpcionSP = 1
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGrid.CellFormatting
        Try
            ' If OpcionSP <> 2 Then Exit Sub

            If Me.DGrid.Columns(e.ColumnIndex).Name <> "ETIQUETA" Then Exit Sub
            'If e.RowIndex = DGrid.RowCount - 1 Then

            '    Exit Sub
            'End If

            ' If Val(DGrid.Rows(e.RowIndex).Cells("diferencia").Value) = 0 Then Exit Sub

            If (DGrid.Rows(e.RowIndex).Cells("ETIQUETA").Value) = "MAS VENDIDOS" Then
                DGrid.Rows(e.RowIndex).Cells("ETIQUETA").Style.BackColor = Color.Pink
                DGrid.Rows(e.RowIndex).Cells("ETIQUETA").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

            End If

            If (DGrid.Rows(e.RowIndex).Cells("ETIQUETA").Value) = "QUITAR NUEVOS" Then
                DGrid.Rows(e.RowIndex).Cells("ETIQUETA").Style.BackColor = Color.GreenYellow
                DGrid.Rows(e.RowIndex).Cells("ETIQUETA").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick
        Dim columna As Integer = DGrid.CurrentCell.ColumnIndex
        Dim Sucursal As String = ""
        Dim Traspaso As String = ""
        Try
            OpcionSP = 2


            IdProTrasB = DGrid.CurrentRow.Cells("idprotras").Value

            Call RellenaGrid()




            blnEntraDet = True

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub Btn_Pendientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            OpcionSP = 1
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
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

    Private Sub DGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.Click
        'If blnEntraDet = False Then Exit Sub
        If IsDBNull(DGrid.Rows(DGrid.CurrentRow.Index).Cells(1).Value) Then
        Else
            CargarFotoArticulo(DGrid.Rows(DGrid.CurrentRow.Index).Cells("Marca").Value, DGrid.Rows(DGrid.CurrentRow.Index).Cells("MODELO").Value)
        End If
    End Sub

    Private Sub DGrid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGrid.KeyUp
        If blnEntraDet = False Then Exit Sub
        If IsDBNull(DGrid.Rows(DGrid.CurrentRow.Index).Cells(1).Value) Then
        Else
            CargarFotoArticulo(DGrid.Rows(DGrid.CurrentRow.Index).Cells("Marca").Value, DGrid.Rows(DGrid.CurrentRow.Index).Cells("MODELO").Value)
        End If
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

    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub

    Private Sub PBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBox.Click

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

    Private Sub Btn_Series_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim myForm As New frmSeriesNoTraspaso

        myForm.ShowDialog()

        Call RellenaGrid()
    End Sub

    Private Sub Pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub

    Private Sub Btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Imprimir.Click
        'mreyes 24/Agosto/2016   16:47 p.m.
        Dim myForm As New frmReportsBrowser

        myForm.objDataSetPpalAparador = GenerarReporteAparador()
        ' myForm.r_Titulo = lbl_Final.Text
        myForm.ReportIndex = 8459
        myForm.Show()
    End Sub
    Private Function GenerarReporteAparador() As DSAparador
        'mreyes 26/Agosto/2015   16:48 p.m.
        Try
            GenerarReporteAparador = New DSAparador
            With DGrid
                For I As Integer = 0 To .Rows.Count - 2

                    Dim objDataRow As Data.DataRow = GenerarReporteAparador.Tables(0).NewRow()
                    objDataRow.Item("det") = GLB_CveSucursal
                    objDataRow.Item("sucursal") = GLB_Sucursal
                    objDataRow.Item("marca") = .Rows(I).Cells("marca").Value
                    objDataRow.Item("modelo") = .Rows(I).Cells("modelo").Value

                    objDataRow.Item("l3") = .Rows(I).Cells("l3").Value
                    objDataRow.Item("l1") = .Rows(I).Cells("l1").Value

                    objDataRow.Item("linea") = .Rows(I).Cells("linea").Value
                    objDataRow.Item("etiqueta") = .Rows(I).Cells("etiqueta").Value
                    objDataRow.Item("posicion") = .Rows(I).Cells("posicion").Value




                    GenerarReporteAparador.Tables(0).Rows.Add(objDataRow)
                Next

            End With
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function
End Class
