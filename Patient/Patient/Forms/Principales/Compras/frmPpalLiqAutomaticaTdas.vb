Public Class frmPpalLiqAutomaticaTdas
    'mreyes 23/Septiembre/2016  10:45 a.m.

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

    Dim sw_liq As Boolean = False



    Private Sub frmPpalPpalDetFactProv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call GenerarToolTip()
        Sw_Pintar = True
        Sw_Load = True
        ' DT_FecIni.Value = DateAdd("d", 1, GLB_FechaHoy)
        Call LimpiarBusqueda()
        Call RellenaGrid()


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

            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")

            ToolTip.SetToolTip(Btn_Salir, "Salir")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub LimpiarBusqueda()
        If GLB_CveSucursal = "01" Or GLB_CveSucursal = "02" Or GLB_CveSucursal = "06" Or GLB_CveSucursal = "07" Or GLB_CveSucursal = "08" Or GLB_CveSucursal = "11" Then
            If Opcion = 1 Then
                SucurOriB = GLB_CveSucursal
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
        'mreyes 23/Septiembre/2016  10:50 a.m.
        Dim Sucursalb As String = ""

        If GLB_CveSucursal > "20" Then
            Sucursalb = ""
        Else
            Sucursalb = GLB_CveSucursal
        End If
        DGrid.Visible = False
        'InicializaGrid()
        Using objTrasp As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                'DGrid.ReadOnly = True
                DGrid.DataSource = Nothing

                objDataSet = objTrasp.usp_PpalLiqAutomaticaTdas(1, Sucursalb, Format(DT_FecIni.Value, "dd/MM/yyyy"))

                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section 
                    'DGrid.ColumnCount = objDataSet.Tables(0).Columns.Count
                    '
                    DGrid.DataSource = objDataSet.Tables(0)
                    InicializaGrid()
                    'If Sw_Load = False Then
                    ''''
                    'End If
                    'LimpiarBusqueda()
                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True
                    Sw_NoRegistros = True
                    Sw_Pintar = True
                    ''If DGrid.RowCount > 0 Then
                    ''    If OpcionSP = 1 Then
                    ''        Lbl_Trasp.Visible = True
                    ''        Lbl_Trasp.Text = "Número de Traspasos: " & DGrid.RowCount - 1
                    ''    Else
                    ''        ' Lbl_Trasp.Text = "Número de Estilos a Traspasar: " & DGrid.RowCount - 1
                    ''        Lbl_Trasp.Visible = False

                    ''    End If
                    ''End If
                    'Call Colores()
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

    Private Sub AgregarColumna()
        Try
            Dim colImagen As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()

            ' colImagen.Frozen = True
            colImagen.Name = "Liq"
            colImagen.HeaderText = "Liq"
            colImagen.DisplayIndex = 15
            colImagen.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            colImagen.CellTemplate = New DataGridViewCheckBoxCell()

            DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            ''DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
            Me.DGrid.Columns.Add(colImagen)


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Sub InicializaGrid()
        'mreyes 08/Septiembre/2016  04:53 p.m.

        Try



            DGrid.RowHeadersVisible = False
            DGrid.Columns(0).HeaderText = "Det"
            DGrid.Columns(1).HeaderText = "Sucursal"
            DGrid.Columns(2).HeaderText = "Linea"
            DGrid.Columns(3).HeaderText = "L1"
            DGrid.Columns(4).HeaderText = "Marca"
            DGrid.Columns(5).HeaderText = "Modelo"

            DGrid.Columns(6).HeaderText = "Corrida"

            DGrid.Columns(7).HeaderText = "Tipo"

            DGrid.Columns(8).HeaderText = "Promoción"
            DGrid.Columns(9).HeaderText = "Contado"
            DGrid.Columns(10).HeaderText = "Crédito"
            DGrid.Columns(11).HeaderText = "% Directo"
            DGrid.Columns(12).HeaderText = "% D.E."


            'DGrid.Columns(8).DefaultCellStyle.Format = "c"
            'DGrid.Columns(9).DefaultCellStyle.Format = "c"
            DGrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


            DGrid.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid.Columns(0).Frozen = True
            DGrid.Columns(1).Frozen = True

            DGrid.Columns(0).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)


            DGrid.Columns(1).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(1).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)



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

    Private Sub DGrid_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DGrid.CellBeginEdit

    End Sub

    Private Sub DGrid_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGrid.CellFormatting
        Try
            If e.RowIndex = DGrid.RowCount - 1 Then

                Exit Sub
            End If
            If Sw_Pintar = False Then Exit Sub
            If LCase(Me.DGrid.Columns(e.ColumnIndex).Name) = "regaladn" Then
                If Val(DGrid.Rows(e.RowIndex).Cells("regaladn").Value) > 0 Then
                    DGrid.Rows(e.RowIndex).Cells("regaladn").Style.BackColor = Color.Yellow
                    DGrid.Rows(e.RowIndex).Cells("regaladn").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                End If
            End If

            If LCase(Me.DGrid.Columns(e.ColumnIndex).Name) = "contado" Then
                If Val(DGrid.Rows(e.RowIndex).Cells("contado").Value) > 0 Then
                    DGrid.Rows(e.RowIndex).Cells("contado").Style.BackColor = Color.GreenYellow
                    DGrid.Rows(e.RowIndex).Cells("contado").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                    DGrid.Rows(e.RowIndex).Cells("credito").Style.BackColor = Color.Orange
                    DGrid.Rows(e.RowIndex).Cells("credito").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                Else
                    DGrid.Rows(e.RowIndex).Cells("contado").Style.BackColor = Color.White
                    DGrid.Rows(e.RowIndex).Cells("contado").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Regular)

                    DGrid.Rows(e.RowIndex).Cells("credito").Style.BackColor = Color.White
                    DGrid.Rows(e.RowIndex).Cells("credito").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Regular)
                End If
            End If


            If LCase(Me.DGrid.Columns(e.ColumnIndex).Name) = "porc" Then
                If Val(DGrid.Rows(e.RowIndex).Cells("porc").Value) > 0 Then
                    DGrid.Rows(e.RowIndex).Cells("porc").Style.BackColor = Color.Pink
                    DGrid.Rows(e.RowIndex).Cells("porc").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                End If
            End If



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
        Try
            DGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            If IsDBNull(DGrid.Rows(DGrid.CurrentRow.Index).Cells(1).Value) Then
            Else
                CargarFotoArticulo(DGrid.Rows(DGrid.CurrentRow.Index).Cells("Marca").Value, DGrid.Rows(DGrid.CurrentRow.Index).Cells("Estilon").Value)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
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





   
    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub

    Private Sub Btn_Filtro_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.Cursor = Cursors.WaitCursor

            Call RellenaGrid()
            Me.Cursor = Cursors.Default

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Filtro_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Call RellenaGrid()
            Me.Cursor = Cursors.Default

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Imprimir.Click
        'mreyes 23/Septiembre/2016   12:02 p.m.
        Dim myForm As New frmReportsBrowser

        myForm.objDataSetPpalAparador = GenerarReporteAparador()
        myForm.r_Titulo = "Fecha Aplicación :" & Format(DT_FecIni.Value, "dd/MM/yyyy")
        myForm.ReportIndex = 8460
        myForm.Show()
    End Sub

    Private Function GenerarReporteAparador() As DSAparador
        'mreyes 23/Septiembre/2016   11:59 a.m.
        Try
            GenerarReporteAparador = New DSAparador
            With DGrid
                For I As Integer = 0 To .Rows.Count - 2

                    Dim objDataRow As Data.DataRow = GenerarReporteAparador.Tables(0).NewRow()
                    objDataRow.Item("det") = .Rows(I).Cells("sucursal").Value
                    objDataRow.Item("sucursal") = .Rows(I).Cells("descrip").Value
                    objDataRow.Item("marca") = .Rows(I).Cells("marca").Value
                    objDataRow.Item("modelo") = .Rows(I).Cells("estilon").Value
                    objDataRow.Item("estructura") = .Rows(I).Cells("tipo").Value

                    objDataRow.Item("contado") = Format(.Rows(I).Cells("contado").Value, "#0")
                    objDataRow.Item("credito") = Format(.Rows(I).Cells("credito").Value, "#0")
                    objDataRow.Item("tipo_preciero") = .Rows(I).Cells("tipo").Value
                    objDataRow.Item("promocion") = .Rows(I).Cells("promocion").Value
                    objDataRow.Item("corrida") = .Rows(I).Cells("corrida").Value
                    objDataRow.Item("linea") = .Rows(I).Cells("linea").Value
                    objDataRow.Item("l1") = .Rows(I).Cells("l1").Value
                    objDataRow.Item("estructura") = .Rows(I).Cells("linea").Value & "\" & .Rows(I).Cells("l1").Value
                    objDataRow.Item("precio") = .Rows(I).Cells("porc").Value
                    objDataRow.Item("posicion") = .Rows(I).Cells("regaladn").Value

                    GenerarReporteAparador.Tables(0).Rows.Add(objDataRow)
                Next

            End With
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function
End Class

