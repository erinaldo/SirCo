Public Class frmPpalCorteFolios
    'Mreyes 17/Junio/2015   10:13 a.m.
    Private objDataSet As Data.DataSet
    Dim Sw_NoRegistros As Boolean = False
    Dim IdReportaB As Integer = 0
    Dim IdAsignadoB As Integer = 0
    Dim SucursalB As String = ""
    Dim IdDeptoB As Integer = 0
    Dim DeptoB As String = ""
    Dim IdPuestoB As Integer = 0
    Dim IdActividadEmp As Integer = 0
    Dim EstatusB As String = ""
    'Dim SucursalN As String = ""


    Dim CveSucursalB As String = ""
    Dim FechaIniB As String = "1900-01-01"
    Dim FechaFinb As String = "1900-01-01"

    Dim Sw_Pintar As Boolean = False
    Dim Sw_Load As Boolean = True
    Public Opcion As Integer = 1
    Public IdActividad As Integer

    Private Sub frmPpalConceptoRep_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Sw_NoRegistros = False Then Exit Sub
        If Sw_Load = True Then

            RellenaGrid()
            Sw_Load = False
            'AgregarColumna()
            '    Call BarrerGrid()
        End If


    End Sub

    Private Sub Colores()
        Try
            Dim sucursal As String = ""
            Dim TipoNom As String = ""
            Dim color1 As System.Drawing.Color
            color1 = Color.SandyBrown

            For J As Integer = 0 To DGrid.RowCount - 2
                If Not IsDBNull(DGrid.Rows(J).Cells("sucursal").Value) Then
                    If sucursal <> (DGrid.Rows(J).Cells("sucursal").Value) Then
                        If J <> 0 Then
                            If color1 = Color.Salmon Then
                                color1 = Color.SandyBrown
                            Else
                                color1 = Color.Salmon
                            End If
                            DGrid.Rows(J).DefaultCellStyle.BackColor = color1
                        Else
                            color1 = Color.SandyBrown
                            DGrid.Rows(J).DefaultCellStyle.BackColor = color1
                        End If
                        sucursal = DGrid.Rows(J).Cells("sucursal").Value
                    Else
                        'If TipoNom <> DGrid.Rows(J).Cells("tiponom").Value Then
                        '    If color1 = Color.Salmon Then
                        '        color1 = Color.SandyBrown
                        '    Else
                        '        color1 = Color.Salmon
                        '    End If
                        'End If
                        DGrid.Rows(J).DefaultCellStyle.BackColor = color1
                        sucursal = DGrid.Rows(J).Cells("sucursal").Value
                    End If
                End If

            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmPpalActividadesEmp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If

        If e.KeyCode = Keys.F5 Then
            'Call Btn_Filtro_Click_1(sender, e)
        End If
    End Sub

    Private Sub frmPpalActividadesEmp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            GenerarToolTip()
            If GLB_IdDeptoEmpleado <> 1 Then

                CveSucursalB = ""
            Else
                CveSucursalB = GLB_CveSucursal

            End If
            FechaFinb = Format(Now.Add(New TimeSpan(-1, 0, 0, 0)), "yyyy-MM-dd")
            FechaIniB = Format(Now.Add(New TimeSpan(-1, 0, 0, 0)), "yyyy-MM-dd")


            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub RellenaGrid()
        'mreyes 17/Junio/2015   10:20 a.m.
        Try

            Using objBulto As New BCL.BCLCorteFolios(GLB_ConStringCipSis)
                objDataSet = objBulto.usp_PpalCorteFolios(CveSucursalB, FechaIniB, FechaFinb)
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                DGrid.DataSource = Nothing
                DGrid.DataSource = objDataSet.Tables(0)
                Sw_NoRegistros = True
                InicializaGrid()
                Colores()
                Lbl_Leyenda.Text = "Información del " & FechaIniB & " al " & FechaFinb
            Else
                Sw_NoRegistros = False
                MessageBox.Show("No se encontro informacion solicitada", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Filtro, "Búsqueda Avanzada")
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
            ToolTip.SetToolTip(Btn_Salir, "Salir")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub




    Private Sub InicializaGrid()
        Try

            'Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
            'Dim row As DataRow = dt.NewRow()
            'row(2) = "Total: "
            'row(4) = pub_SumarColumnaGrid(DGrid, 4, DGrid.RowCount - 1)
            'dt.Rows.Add(row)
            'DGrid.DataSource = dt


            DGrid.RowHeadersVisible = False
            'DGrid.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, 7, FontStyle.Regular)
            DGrid.Columns(0).HeaderText = "Det"
            DGrid.Columns(1).HeaderText = "Sucursal"
            DGrid.Columns(2).HeaderText = "Tipo"
            DGrid.Columns(3).HeaderText = "Folio Inicial"
            DGrid.Columns(4).HeaderText = "Folio Final"
           

            DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

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



    Private Sub DGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick
        Try
            Btn_Editar_Click_1(sender, e)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DGrid.KeyPress
        'Try
        '    Call Btn_Consultar_Click(sender, e)
        'Catch ExceptionErr As Exception
        '    MessageBox.Show(ExceptionErr.Message.ToString)
        'End Try
    End Sub



    Private Sub Btn_Filtro_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        Try
            Dim myForm As New frmFiltrosCorteFolios

            myForm.Txt_Sucursal.Text = CveSucursalB
            myForm.DTPicker2.Value = FechaIniB
            myForm.DTPicker3.Value = FechaFinb



            myForm.ShowDialog()

            If myForm.Sw_Filtro = False Then Exit Sub


            SucursalB = myForm.Txt_Sucursal.Text.Trim


            FechaIniB = Format(myForm.DTPicker2.Value, "yyyy-MM-dd")
            FechaFinb = Format(myForm.DTPicker3.Value, "yyyy-MM-dd")
           


            Call RellenaGrid()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub AgregarColumna()
        Dim colImagen As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        colImagen.Name = "Selec"
        colImagen.HeaderText = "Selec"
        colImagen.DisplayIndex = 12
        colImagen.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        colImagen.CellTemplate = New DataGridViewCheckBoxCell()
        ' añadir columna de imagen a la coleccion del grid 
        DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        ''DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DGrid.Columns.Add(colImagen)
    End Sub



    Private Sub Btn_Editar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim myForm As New frmCatalogoReciboBultos
            myForm.Accion = 2
            myForm.Folio = DGrid.CurrentRow.Cells("Folio").Value.ToString
            myForm.FolioB = DGrid.CurrentRow.Cells("Folio").Value.ToString
            myForm.Txt_Folio.Text = DGrid.CurrentRow.Cells("idfoliosuc").Value.ToString

            myForm.ShowDialog()
            'If myForm.Guardo = True Then
            '    frmPpalActividadesEmp_Load(sender, e)
            'End If
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Nuevo_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim myForm As New frmCatalogoReciboBultos
        Try
            myForm.Accion = 1
            myForm.ShowDialog()
            If myForm.Guardo = True Then
                frmPpalActividadesEmp_Load(sender, e)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    'Private Sub DGrid_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGrid.CellFormatting
    '    Try

    '        'Tony Garcia - 15/Octubre/2012 12:25 p.m.

    '        Dim Sw_NoEntro As Boolean = False

    '        Dim DiasEntrega As Integer = 0
    '        If Sw_Pintar = False Then Exit Sub

    '        If Me.DGrid.Columns(e.ColumnIndex).Name <> "estatus" Then Exit Sub
    '        ''If Me.DGrid.Columns(e.ColumnIndex).Name <> "fecha" Then Exit Sub
    '        If e.RowIndex >= DGrid.RowCount - 1 Then
    '            If Sw_Load = False Then
    '                Sw_Pintar = False
    '            End If
    '            Exit Sub
    '        End If

    '        If DGrid.Rows(e.RowIndex).Cells("estatus").Value = "CAPTURA" Then
    '            DGrid.Rows(e.RowIndex).Cells("estatus").Style.BackColor = Color.Yellow
    '            DGrid.Rows(e.RowIndex).Cells("estatus").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
    '        End If

    '        If DGrid.Rows(e.RowIndex).Cells("estatus").Value = "EN PROCESO" Then
    '            DGrid.Rows(e.RowIndex).Cells("estatus").Style.BackColor = Color.RoyalBlue
    '            DGrid.Rows(e.RowIndex).Cells("estatus").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
    '        End If

    '        If DGrid.Rows(e.RowIndex).Cells("estatus").Value = "EN ESPERA" Then
    '            DGrid.Rows(e.RowIndex).Cells("estatus").Style.BackColor = Color.Salmon
    '            DGrid.Rows(e.RowIndex).Cells("estatus").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
    '        End If

    '        If DGrid.Rows(e.RowIndex).Cells("estatus").Value = "PAUSADO" Then
    '            DGrid.Rows(e.RowIndex).Cells("estatus").Style.BackColor = Color.Orange
    '            DGrid.Rows(e.RowIndex).Cells("estatus").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
    '        End If

    '        If DGrid.Rows(e.RowIndex).Cells("estatus").Value = "REALIZADO" Then
    '            DGrid.Rows(e.RowIndex).Cells("estatus").Style.BackColor = Color.YellowGreen
    '            DGrid.Rows(e.RowIndex).Cells("estatus").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
    '        End If

    '        If DGrid.Rows(e.RowIndex).Cells("estatus").Value = "CANCELADO" Then
    '            DGrid.Rows(e.RowIndex).Cells("estatus").Style.BackColor = Color.Red
    '            DGrid.Rows(e.RowIndex).Cells("estatus").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
    '        End If

    '        If DGrid.Rows(e.RowIndex).Cells("estatus").Value = "NO APLICA" Then
    '            DGrid.Rows(e.RowIndex).Cells("estatus").Style.BackColor = Color.Gray
    '            DGrid.Rows(e.RowIndex).Cells("estatus").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
    '        End If

    '        DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    '    Catch ExceptionErr As Exception
    '        MessageBox.Show(ExceptionErr.Message.ToString)
    '    End Try
    'End Sub


    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub

    Private Sub Btn_ImprimirRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ImprimirRpt.Click
        Me.Cursor = Cursors.AppStarting

        

        Call Imprimir()


        Me.Cursor = Cursors.Default
    End Sub


    Private Sub Imprimir()
        'mreyes 18/Junio/2015   09:58.
        Try
            Dim myForm As New frmReportsBrowser
            Dim Sw_Mas14 As Boolean = False
            Dim Cont As Integer = 0
            Dim Sw_Imprimir As Boolean = False

            myForm.objDataSetPpalCorteFolios = GenerarDSCortefolios()
            myForm.r_Titulo = Lbl_Leyenda.Text
            myForm.ReportIndex = 8456   'CUANDO SE GENERA LA PRIMERA VEZ nosotros .. el 1 es el proveedor , EL 3 ES EL DE CEDI
    


            myForm.Show()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub



    Private Function GenerarDSCortefolios() As DSPpalCorteFolios
        'mreyes 18/Junio/2015   10:16 a.m.
        Try
            '' Dim objDataSet As New DtReciboBono
            Dim Columna As Integer = 0
            Dim Cont As Integer = 0


            GenerarDSCortefolios = New DSPpalCorteFolios


            With DGrid
                Cont = 0

                For I As Integer = 0 To .RowCount - 2

                    Dim objDataRow1 As Data.DataRow = GenerarDSCortefolios.Tables("Tbl_CorteFolios").NewRow
                    objDataRow1.Item("sucursal") = .Rows(I).Cells("sucursal").Value
                    objDataRow1.Item("descrip") = .Rows(I).Cells("descrip").Value

                    objDataRow1.Item("tipo") = .Rows(I).Cells("tipo").Value
                    objDataRow1.Item("folioini") = .Rows(I).Cells("folioini").Value
                    objDataRow1.Item("foliofin") = .Rows(I).Cells("foliofin").Value

                    GenerarDSCortefolios.Tables("Tbl_CorteFolios").Rows.Add(objDataRow1)


                Next




            End With
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function
End Class
