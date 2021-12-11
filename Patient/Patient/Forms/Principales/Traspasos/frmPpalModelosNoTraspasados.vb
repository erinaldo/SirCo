Public Class frmPpalModelosNoTraspasados
    'mreyes 18/Agosto/2016  06:38 p.m.

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

        Call GenerarToolTip()
        Sw_Pintar = True
        Sw_Load = True
        Call LimpiarBusqueda()
        Call RellenaGrid()
        'If GLB_AccesoEmpleado = True Then
        '    Btn_Excel.Enabled = False
        '    Btn_Filtro.Enabled = False
        'End If

        'If Opcion = 1 Then
        '    Me.Text = "Traspasos Pendientes por Recibir"
        'ElseIf Opcion = 2 Then
        '    Me.Text = "Traspasos Pendientes que me Reciban"
        'End If
    End Sub

    Private Sub frmPpalPpalDetFactProv_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Sw_NoRegistros = False Then Exit Sub
        'If Sw_Load = True Then
        '    Sw_Load = False
        'blnPrimero = True
        ' InicializaGrid()
        'AgregarColumna()
        '    Call BarrerGrid()
        'End If
    End Sub

    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Filtro, "Búsqueda Avanzada")
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
            ToolTip.SetToolTip(Btn_Pendientes, "Traspasos Pendientes")
            ToolTip.SetToolTip(Btn_RecibosParciales, "Traspasos Parciales")
            ToolTip.SetToolTip(Btn_RecibosTodos, "Todos los Traspasos")

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
        'mreyes 18/Agosto/2016  07:05 p.m.

        If Val(GLB_CveSucursal) > 20 Then

            SucurOriB = 0
        Else
            SucurOriB = IIf(GLB_CveSucursal = "", 0, GLB_CveSucursal)
        End If
        DGrid.Visible = False
        'InicializaGrid()
        Using objTrasp As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                'DGrid.ReadOnly = True
                DGrid.DataSource = Nothing

                objDataSet = objTrasp.usp_PpalProTraspDetNoAplica(SucurOriB)

                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then

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

            'Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)

            'DGrid.DataSource = dt


            DGrid.RowHeadersVisible = False

            DGrid.Columns(0).HeaderText = "Det"
            DGrid.Columns(1).HeaderText = "Sucursal"
            DGrid.Columns(2).HeaderText = "Fum"
            DGrid.Columns(3).HeaderText = "Serie"
            DGrid.Columns(4).HeaderText = "Marca"
            DGrid.Columns(5).HeaderText = "Modelo"
            DGrid.Columns(6).HeaderText = "Medida"
            DGrid.Columns(7).HeaderText = "Observa"
            DGrid.Columns(8).HeaderText = "Estatus"


            DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
           

            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells


            DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            AgregarColumna()
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

    Private Sub Btn_RecibosParciales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_RecibosParciales.Click
        Try
            OpcionSP = 2
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_RecibosTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_RecibosTodos.Click
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

            If Me.DGrid.Columns(e.ColumnIndex).Name <> "estatus" Then Exit Sub
            If e.RowIndex = DGrid.RowCount - 1 Then

                Exit Sub
            End If

            ' If Val(DGrid.Rows(e.RowIndex).Cells("diferencia").Value) = 0 Then Exit Sub

            If (DGrid.Rows(e.RowIndex).Cells("estatus").Value) = "ACTIVO" Then
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.BackColor = Color.Yellow
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            
            End If

            If (DGrid.Rows(e.RowIndex).Cells("estatus").Value) = "CUSTODIA" Then
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.BackColor = Color.RosyBrown
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If

            If (DGrid.Rows(e.RowIndex).Cells("estatus").Value) = "BAJA" Then
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.BackColor = Color.Red
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
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
            Btn_Regresar.Enabled = True

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Regresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Regresar.Click
        Try
            If Btn_Regresar.Enabled = True Then
                OpcionSP = 1
                RellenaGrid()
                PBox.Image = Nothing
                PBox.Visible = False
                Btn_Regresar.Enabled = False
                blnEntraDet = False
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Pendientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Pendientes.Click
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

        If IsDBNull(DGrid.Rows(DGrid.CurrentRow.Index).Cells(1).Value) Then
        Else
            CargarFotoArticulo(DGrid.Rows(DGrid.CurrentRow.Index).Cells("Marca").Value, DGrid.Rows(DGrid.CurrentRow.Index).Cells("Estilon").Value)
        End If
    End Sub

    Private Sub DGrid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGrid.KeyUp

        If IsDBNull(DGrid.Rows(DGrid.CurrentRow.Index).Cells(1).Value) Then
        Else
            CargarFotoArticulo(DGrid.Rows(DGrid.CurrentRow.Index).Cells("Marca").Value, DGrid.Rows(DGrid.CurrentRow.Index).Cells("Estilon").Value)
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

    End Sub
    Private Sub AgregarColumna()
        Try
            Dim colImagen As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()

            ' colImagen.Frozen = True
            colImagen.Name = "Quitar"
            colImagen.HeaderText = "Quitar"
            colImagen.DisplayIndex = 9
            colImagen.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            colImagen.CellTemplate = New DataGridViewCheckBoxCell()

            DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            ''DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
            Me.DGrid.Columns.Add(colImagen)


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_InvertirSeleccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_InvertirSeleccion.Click
        If Sw_NoRegistros = False Then Exit Sub
        Call Selecciona()
    End Sub

    Private Sub Selecciona()
        'mreyes 09/Septiembre/2016  12:05 p.m.
        Me.Cursor = Cursors.AppStarting
        DGrid.Visible = False
        For Each row As DataGridViewRow In DGrid.Rows
            If row.Cells("quitar").Value = True Then
                row.Cells("quitar").Value = False
            Else
                row.Cells("quitar").Value = True
            End If
        Next
        DGrid.Visible = True
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Btn_NoPropuesta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_NoPropuesta.Click
        'mreyes 24/Octubre/2016 04:07 p.m.
        Try
            If MsgBox("Esta seguro de quitar las series seleccionadas de la lista?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub


            Me.Cursor = Cursors.WaitCursor
            For i As Integer = 0 To DGrid.RowCount - 2
                '' Eliminar de liquidación 
                If DGrid.Rows(i).Cells("Quitar").Value = True Then
                    If usp_Elimina_ProTraspDetNoAplica(DGrid.Rows(i).Cells("serie").Value) Then
                        Sw_Pintar = False
                    End If
                End If
            Next
            DGrid.Columns.Remove("Quitar")

            Call RellenaGrid()
            Sw_Pintar = True
            Me.Cursor = Cursors.Default

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Function usp_Elimina_ProTraspDetNoAplica(ByVal Serie As String) As Boolean
        'mreyes 25/Octubre/2016 04:18 p.m.


        Using objCalculo As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
            Try
                'Get the specific project selected in the ListView controlsu

                Application.DoEvents()

                usp_Elimina_ProTraspDetNoAplica = objCalculo.usp_Elimina_ProTraspDetNoAplica(Serie)




                Application.DoEvents()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Private Sub Btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Imprimir.Click
        Try
            Dim myForm As New frmReportsBrowser
          

            myForm.objDataSetNoSurtir = GenerarNoSurit()

            myForm.ReportIndex = 10000   'CUANDO SE GENERA LA PRIMERA VEZ nosotros .. el 1 es el proveedor , EL 3 ES EL DE CEDI


            myForm.Show()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Function GenerarNoSurit() As DSNoSurtir
        'mreyes 01/Septiembre/2012 07:12 p.m.
        Try
            '' Dim objDataSet As New DtReciboBono
            Dim Columna As Integer = 0
            Dim Cont As Integer = 0
            Dim Facturas As String = ""

            GenerarNoSurit = New DSNoSurtir


            For i As Integer = 0 To DGrid.RowCount - 2
                Cont = 0
                Dim objDataRow1 As Data.DataRow = GenerarNoSurit.Tables("Tbl_NoSurtir").NewRow
                objDataRow1.Item("det") = DGrid.Rows(i).Cells("sucursal").Value.ToString
                objDataRow1.Item("sucursal") = DGrid.Rows(i).Cells("descrip").Value.ToString
                objDataRow1.Item("fum") = DGrid.Rows(i).Cells("fum").Value.ToString
                objDataRow1.Item("serie") = DGrid.Rows(i).Cells("serie").Value.ToString
                objDataRow1.Item("marca") = DGrid.Rows(i).Cells("marca").Value.ToString
                objDataRow1.Item("modelo") = DGrid.Rows(i).Cells("estilon").Value.ToString
                objDataRow1.Item("medida") = DGrid.Rows(i).Cells("medida").Value.ToString
                objDataRow1.Item("observa") = DGrid.Rows(i).Cells("observa").Value.ToString
                objDataRow1.Item("estatus") = DGrid.Rows(i).Cells("estatus").Value

                GenerarNoSurit.Tables("Tbl_NoSurtir").Rows.Add(objDataRow1)

            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function
End Class
