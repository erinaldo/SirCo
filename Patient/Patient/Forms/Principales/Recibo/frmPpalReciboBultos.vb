Public Class frmPpalReciboBultos
    ''Tony Garcia  - 13/Octubre/2012 6:00 p.m.
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
            Call RellenaGrid()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub RellenaGrid()
        Try

            Using objBulto As New BCL.BCLBulto(GLB_ConStringCipSis)
                objDataSet = objBulto.usp_PpalBulto("", "", GLB_CveSucursal, "", "", "")
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                DGrid.DataSource = Nothing
                DGrid.DataSource = objDataSet.Tables(0)
                Sw_NoRegistros = True
                InicializaGrid()
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
            ToolTip.SetToolTip(Btn_Nuevo, "Nuevo")
            ToolTip.SetToolTip(Btn_Editar, "Modificar")
            ToolTip.SetToolTip(Btn_Filtro, "Búsqueda Avanzada")
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
            ToolTip.SetToolTip(Btn_Salir, "Salir")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub




    Private Sub InicializaGrid()
        Try

            Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
            Dim row As DataRow = dt.NewRow()
            row(2) = "Total: "
            row(4) = pub_SumarColumnaGrid(DGrid, 4, DGrid.RowCount - 1)
            dt.Rows.Add(row)
            DGrid.DataSource = dt


            DGrid.RowHeadersVisible = False
            'DGrid.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, 7, FontStyle.Regular)


            DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid.Columns(5).Visible = False
            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)


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
        Dim myForm As New frmFiltrosBultos


        If GLB_CveSucursal <> "" Then
            myForm.Txt_Sucursal.Text = GLB_CveSucursal
            myForm.Txt_Sucursal.Enabled = False
        End If
        myForm.ShowDialog()
        If myForm.Sw_Filtro = True Then
            Dim FechaIni As String
            Dim FechaFin As String
            If myForm.Chk_FechaOrden.Checked = True Then
                FechaIni = Format(myForm.DTPicker2.Value, "yyyy-MM-dd")
                FechaFin = Format(myForm.DTPicker3.Value, "yyyy-MM-dd")
            Else
                FechaIni = ""
                FechaFin = ""
            End If
            Dim FolioA As String = myForm.Txt_OrdeComp1.Text.Trim
            Dim FolioB As String = myForm.Txt_OrdeComp2.Text.Trim
            Dim Sucursal As String = myForm.Txt_Sucursal.Text.Trim
            Dim Proveedor As String = myForm.Txt_Proveedor.Text.Trim
            Using objActividadesEmp As New BCL.BCLBulto(GLB_ConStringCipSis)
                objDataSet = objActividadesEmp.usp_PpalBulto(FolioA, FolioB, Sucursal, Proveedor, FechaIni, FechaFin)
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                DGrid.DataSource = Nothing
                DGrid.DataSource = objDataSet.Tables(0)
                InicializaGrid()
            Else
                DGrid.DataSource = Nothing
                MessageBox.Show("No se encontro informacion con los filtros seleccionados", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If

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

    

    Private Sub Btn_Editar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar.Click
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

    Private Sub Btn_Nuevo_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Nuevo.Click
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

    Private Sub DGrid_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGrid.CellFormatting
        Try

            'Tony Garcia - 15/Octubre/2012 12:25 p.m.

            Dim Sw_NoEntro As Boolean = False

            Dim DiasEntrega As Integer = 0
            If Sw_Pintar = False Then Exit Sub

            If Me.DGrid.Columns(e.ColumnIndex).Name <> "estatus" Then Exit Sub
            ''If Me.DGrid.Columns(e.ColumnIndex).Name <> "fecha" Then Exit Sub
            If e.RowIndex >= DGrid.RowCount - 1 Then
                If Sw_Load = False Then
                    Sw_Pintar = False
                End If
                Exit Sub
            End If

            If DGrid.Rows(e.RowIndex).Cells("estatus").Value = "CAPTURA" Then
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.BackColor = Color.Yellow
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If

            If DGrid.Rows(e.RowIndex).Cells("estatus").Value = "EN PROCESO" Then
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.BackColor = Color.RoyalBlue
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If

            If DGrid.Rows(e.RowIndex).Cells("estatus").Value = "EN ESPERA" Then
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.BackColor = Color.Salmon
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If

            If DGrid.Rows(e.RowIndex).Cells("estatus").Value = "PAUSADO" Then
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.BackColor = Color.Orange
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If

            If DGrid.Rows(e.RowIndex).Cells("estatus").Value = "REALIZADO" Then
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.BackColor = Color.YellowGreen
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If

            If DGrid.Rows(e.RowIndex).Cells("estatus").Value = "CANCELADO" Then
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.BackColor = Color.Red
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If

            If DGrid.Rows(e.RowIndex).Cells("estatus").Value = "NO APLICA" Then
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.BackColor = Color.Gray
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If

            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

   
    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub
End Class
