Public Class frmPpalBitacoraRecibida
    'mreyes 13/Abril/2012 06:42 p.m.
    Private objDataSet As Data.DataSet
    Dim Marcab As String
    Dim Modelob As String
    Dim Estilofb As String
    Dim IdDivisionb As Integer
    Dim IdDepartamentob As Integer
    Dim IdFamiliab As Integer
    Dim IdLineab As Integer
    Dim IdL1b As Integer
    Dim IdL2b As Integer
    Dim IdL3b As Integer
    Dim IdL4b As Integer
    Dim IdL5b As Integer
    Dim IdL6b As Integer
    Dim Proveedorb As String

    Dim Sucursalb As String
    Dim OrdeCompb As String
    Dim FechaInib As String
    Dim FechaFinb As String
    Dim Statusb As String
    Dim FechaEInib As String
    Dim FechaEFinb As String
    Dim OrdeComInib As String
    Dim OrdeComFinb As String

    Dim Sw_Load As Boolean = False
    Dim Sw_Boton As Boolean = False
    Dim Sw_NoRegistros As Boolean = False
    Dim Opcion As Integer = 1

    Private Sub frmPpalBitacoraRecibida_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Sw_Load = True Then
            Sw_Load = False
            InicializaGrid()
            '    Call BarrerGrid()
        End If


        If GLB_RefrescarPedido = True Then
            GLB_RefrescarPedido = False
            Call RellenaGrid()
            Me.WindowState = FormWindowState.Maximized
        End If
    End Sub  '' 2 = proveedor , 3 = marca 



    Private Sub frmPpalBitacoraRecibida_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
        If e.KeyCode = Keys.F5 Then
            Call Btn_Filtro_Click_1(sender, e)
        End If
    End Sub

    Private Sub frmPpalBitacoraRecibida_Layout(ByVal sender As Object, ByVal e As System.Windows.Forms.LayoutEventArgs) Handles Me.Layout

    End Sub

    Private Sub frmPpalBitacoraRecibida_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Sw_Load = True
            Call LimpiarBusqueda()
            'FechaInib = Now.Date
            'FechaFinb = Now.Date
            '"1900-01-01"

            '' ''FechaEInib = Format(Now.Add(New TimeSpan(+30, 0, 0, 0)), "yyyy-MM-dd")
            '' ''FechaEFinb = Format(Now.Date, "yyyy-MM-dd")

            FechaEInib = Format(Now.Add(New TimeSpan(-30, 0, 0, 0)), "yyyy-MM-dd")
            FechaEFinb = Format(Now.Date, "yyyy-MM-dd")


            Call GenerarToolTip()
            Call RellenaGrid()


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub GenerarToolTip()
        Try

            ToolTip.SetToolTip(Btn_Filtro, "Búsqueda Avanzada")
            'ToolTip.SetToolTip(Btn_Refrescar, "Refrescar Información")
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
            ToolTip.SetToolTip(Btn_Imprimir, "Imprimir Información")
            ' ToolTip.SetToolTip(Btn_Pdf, "Generar Información en PDF")
            ToolTip.SetToolTip(Btn_Salir, "Salir")

            ToolTip.SetToolTip(Btn_Proveedor, "Bitácora por Proveedor")
            ToolTip.SetToolTip(Btn_Estilos, "Bitácora por Estilos")
            ToolTip.SetToolTip(Btn_Marca, "Bitácora por Marca")
   
            ToolTip.SetToolTip(Btn_OrdeComp, "Bitácora por Orden de Compra")


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub RellenaGrid()
        'mreyes 27/Febrero/2012 10:44 a.m.
        Using objBitacora As New BCL.BCLBitacora(GLB_ConStringCipSis)
            Try
                Me.Cursor = Cursors.WaitCursor
                Dim accion As Integer

                DGrid.ReadOnly = True
                DGrid.DataSource = Nothing
                If Sw_Load = True Then
                    accion = 1
                    ''''Sw_Load = False
                Else
                    Accion = 2
                End If
                objDataSet = objBitacora.usp_PpalBitacoraRecibida(accion, Opcion, Sucursalb, OrdeComInib, OrdeComFinb, Marcab, Modelob, Estilofb, _
                                                                    IdDivisionb, IdDepartamentob, IdFamiliab, IdLineab, IdL1b, IdL2b, IdL3b, _
                                                                    IdL4b, IdL5b, IdL6b, Proveedorb, Statusb, FechaInib, _
                                                                    FechaFinb, FechaEInib, FechaEFinb)
                If objDataSet.Tables(0).Rows.Count > 1 Then

                    'DGrid.Visible = False
                    'DGrid.Refresh()
                    'Application.DoEvents()
                    DGrid.DataSource = objDataSet.Tables(0)
                    InicializaGrid()
                    If Opcion = 1 Then
                        ''''  BarrerGrid()
                        'Application.DoEvents()
                        'Me.Refresh()
                        Btn_Foto.Enabled = True
                    End If
                    'LimpiarBusqueda()
                    ' Agregar totalizado

                    Me.Cursor = Cursors.Default
                    Btn_Estilos.Enabled = True
                    Btn_Marca.Enabled = True
                    Btn_Proveedor.Enabled = True

                    Btn_Excel.Enabled = True
                    'DGrid.Visible = True
                    'DGrid.Refresh()
                    'Application.DoEvents()
                    Sw_NoRegistros = True
                Else
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron Pedidos que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Estilos.Enabled = False
                    Btn_Marca.Enabled = False
                    Btn_Proveedor.Enabled = False

                    Btn_Excel.Enabled = False
                End If

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using


    End Sub
    Private Sub BarrerGrid()
        'mreyes 01/Marzo/2012 09:58 a.m.
        ' FechaInib = Format(Now.Add(New TimeSpan(-30, 0, 0, 0)), "yyyyMMdd")

        Try
            If Sw_Load = True Then Exit Sub
            Dim Entrega As Date
            Dim Fecha As Date
            Dim DiasEntrega As Integer = 0
            DGrid.Visible = False
            PBar.Minimum = 0
            PBar.Value = 0
            PBar.Maximum = DGrid.RowCount
            For Each row As DataGridViewRow In DGrid.Rows
                PBar.Value = PBar.Value + 1
                PBar.Refresh()
                If row.Cells(12).Value = "" Or row.Cells(12).Value = Nothing Then Exit For
                Entrega = row.Cells(12).Value
                Fecha = Entrega.Add(New TimeSpan(-15, 0, 0, 0))
                ''If row.Cells(14).Value <> 0 Then
                ''    row.Cells(3).Style.BackColor = Color.GreenYellow
                ''    row.Cells(3).Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                ''End If
                If Not IsDBNull(row.Cells(14).Value) Then
                    row.Cells(3).Style.BackColor = Color.GreenYellow
                    row.Cells(3).Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)


                End If
                DiasEntrega = DateDiff(DateInterval.Day, Now.Date, Entrega)
                If DiasEntrega <= 7 Then
                    row.Cells(3).Style.BackColor = Color.Red
                    row.Cells(3).Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                    'DGrid.Refresh()
                End If

                If DateDiff(DateInterval.Day, Now.Date, Entrega) > 7 And DateDiff(DateInterval.Day, Now.Date, Entrega) <= 30 Then
                    row.Cells(3).Style.BackColor = Color.Yellow
                    row.Cells(3).Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                End If
            Next
            DGrid.Visible = True
            DGrid.Refresh()
            Me.Refresh()
            Application.DoEvents()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub LimpiarBusqueda()
        Marcab = ""
        Modelob = ""
        Estilofb = ""
        IdDivisionb = 0
        IdDepartamentob = 0
        IdFamiliab = 0
        IdLineab = 0
        IdL1b = 0
        IdL2b = 0
        IdL3b = 0
        IdL4b = 0
        IdL5b = 0
        IdL6b = 0
        Proveedorb = ""

        Sucursalb = ""
        OrdeCompb = ""

        Statusb = ""

        FechaEInib = "1900-01-01"
        FechaEFinb = "1900-01-01"
        FechaInib = "1900-01-01"
        FechaFinb = "1900-01-01"
        OrdeComInib = ""
        OrdeComFinb = ""
    End Sub


    Sub InicializaGrid()

        'mreyes 27/Febrero/2011 10:40 a.m.
        Try
            'Agregar Totalizado
            If Sw_Load = False Then
                Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)

                Dim row As DataRow = dt.NewRow()

                row(0) = "Total: "
                row(1) = "Total: "
                row(7) = Format(pub_SumarColumnaGrid(DGrid, 7, DGrid.RowCount - 1), "#,##0")
                row(8) = Format(pub_SumarColumnaGrid(DGrid, 8, DGrid.RowCount - 1), "#,##0")
                row(9) = Format(pub_SumarColumnaGrid(DGrid, 9, DGrid.RowCount - 1), "#,##0")
                row(11) = Format(pub_SumarColumnaGrid(DGrid, 11, DGrid.RowCount - 1), "$#,###,##0.00")
                dt.Rows.Add(row)
                DGrid.DataSource = dt
            End If

            DGrid.RowHeadersVisible = False

            DGrid.Columns(0).HeaderText = "Marca"
            DGrid.Columns(1).HeaderText = "Proveedor"
            DGrid.Columns(2).HeaderText = "Sucursal"
            DGrid.Columns(3).HeaderText = "OrdeComp"
            DGrid.Columns(4).HeaderText = "N/R"
            DGrid.Columns(5).HeaderText = "Estilo Fábrica"
            DGrid.Columns(6).HeaderText = "Modelo"
            DGrid.Columns(7).HeaderText = "Ped"
            DGrid.Columns(8).HeaderText = "Rec"
            DGrid.Columns(9).HeaderText = "Pend"
            DGrid.Columns(10).HeaderText = "Precio"
            DGrid.Columns(11).HeaderText = "Importe"
            DGrid.Columns(12).HeaderText = "Fecha Entrega"
            DGrid.Columns(13).HeaderText = "Fecha Cancela"
            DGrid.Columns(14).HeaderText = "Fecha Seg"

            DGrid.Columns(1).Visible = False
            DGrid.Columns(2).Visible = False
            '''' DGrid.Columns(8).Visible = False
            '''' DGrid.Columns(9).Visible = False
            ''  DGrid.Columns(14).Visible = False

            If Opcion = 2 Then 'PROVEEDOR
                DGrid.Columns(0).Visible = False
                DGrid.Columns(1).Visible = True
                DGrid.Columns(3).Visible = False
                DGrid.Columns(4).Visible = False
                DGrid.Columns(5).Visible = False
                DGrid.Columns(6).Visible = False
                DGrid.Columns(10).Visible = False
                DGrid.Columns(12).Visible = False
                DGrid.Columns(13).Visible = False
                DGrid.Columns(14).Visible = False
            End If
            If Opcion = 3 Then
                DGrid.Columns(0).Visible = True
                DGrid.Columns(1).Visible = False
                DGrid.Columns(3).Visible = False
                DGrid.Columns(4).Visible = False
                DGrid.Columns(5).Visible = False
                DGrid.Columns(6).Visible = False
                DGrid.Columns(10).Visible = False
                DGrid.Columns(12).Visible = False
                DGrid.Columns(13).Visible = False
                DGrid.Columns(14).Visible = False
            End If

            If Opcion = 4 Then  'orden  compra 
                DGrid.Columns(0).Visible = True
                DGrid.Columns(1).Visible = True
                DGrid.Columns(3).Visible = True
                DGrid.Columns(4).Visible = False
                DGrid.Columns(5).Visible = False
                DGrid.Columns(6).Visible = False
                DGrid.Columns(10).Visible = False
                DGrid.Columns(12).Visible = False
                DGrid.Columns(13).Visible = False
                DGrid.Columns(14).Visible = False
            End If


            DGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            DGrid.Columns(7).DefaultCellStyle.Format = "#,##0"
            DGrid.Columns(8).DefaultCellStyle.Format = "#,##0"
            DGrid.Columns(9).DefaultCellStyle.Format = "#,##0"

            'DGrid.Columns(10).DefaultCellStyle.Format = "#,##0.00"
            'DGrid.Columns(11).DefaultCellStyle.Format = "#,##0.00"


            DGrid.Columns(10).DefaultCellStyle.Format = "c"
            DGrid.Columns(11).DefaultCellStyle.Format = "c"



            DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


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

    Private Sub Btn_Nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim myForm As New frmCatalogoPedidoNuevo

            Sw_Boton = True
            myForm.Accion = 1
            myForm.Txt_OrdeComp.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells(0).Value.ToString.Trim()
            myForm.MdiParent = BitacoraMain
            myForm.Show()
            'Call RellenaGrid()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub Btn_Filtro_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        Dim myForm As New frmFiltrosPedidoNuevo
        'mreyes 27/Febrero/2012 04:48 p.m.
        Try
            '' mandar datos de consulta 
            myForm.Txt_Marca.Text = Marcab
            myForm.Txt_Estilon.Text = Modelob
            myForm.Txt_Estilof.Text = Estilofb
            myForm.Txt_IdDivision.Text = IdDivisionb
            myForm.Txt_IdDepto.Text = IdDepartamentob
            myForm.Txt_IdFamilia.Text = IdFamiliab
            myForm.Txt_IdLinea.Text = IdLineab
            myForm.Txt_IdL1.Text = IdL1b
            myForm.Txt_IdL2.Text = IdL2b
            myForm.Txt_IdL3.Text = IdL3b
            myForm.Txt_IdL4.Text = IdL4b
            myForm.Txt_IdL5.Text = IdL5b
            myForm.Txt_IdL6.Text = IdL6b
            myForm.Txt_Proveedor.Text = Proveedorb
            myForm.Txt_Sucursal.Text = Sucursalb
            myForm.Cbo_Estatus.Text = Statusb
            myForm.Txt_OrdeComp1.Text = OrdeComInib
            myForm.Txt_OrdeComp2.Text = OrdeComFinb
            If FechaInib <> "1900-01-01" Then
                myForm.Chk_FechaOrden.Checked = True
                myForm.DTPicker2.Value = FechaInib
                myForm.DTPicker3.Value = FechaFinb
            End If
            If FechaEInib <> "1900-01-01" Then
                myForm.Chk_FechaEntrega.Checked = True
                myForm.DTPicker4.Value = FechaEInib
                myForm.DTPicker5.Value = FechaEFinb
            End If

            myForm.Text = "Filtros Bitácora"

            myForm.ShowDialog()

            Marcab = myForm.Txt_Marca.Text
            Modelob = myForm.Txt_Estilon.Text
            Estilofb = myForm.Txt_Estilof.Text
            If myForm.Txt_IdDivision.Text <> "" Then
                IdDivisionb = CInt(myForm.Txt_IdDivision.Text)
            End If
            If myForm.Txt_IdDepto.Text <> "" Then
                IdDepartamentob = CInt(myForm.Txt_IdDepto.Text)
            End If
            If myForm.Txt_IdFamilia.Text <> "" Then
                IdFamiliab = CInt(myForm.Txt_IdFamilia.Text)
            End If
            If myForm.Txt_IdLinea.Text <> "" Then
                IdLineab = CInt(myForm.Txt_IdLinea.Text)
            End If
            If myForm.Txt_IdL1.Text <> "" Then
                IdL1b = CInt(myForm.Txt_IdL1.Text)
            End If
            If myForm.Txt_IdL2.Text <> "" Then
                IdL2b = CInt(myForm.Txt_IdL2.Text)
            End If
            If myForm.Txt_IdL3.Text <> "" Then
                IdL3b = CInt(myForm.Txt_IdL3.Text)
            End If
            If myForm.Txt_IdL4.Text <> "" Then
                IdL4b = CInt(myForm.Txt_IdL4.Text)
            End If
            If myForm.Txt_IdL5.Text <> "" Then
                IdL5b = CInt(myForm.Txt_IdL5.Text)
            End If
            If myForm.Txt_IdL6.Text <> "" Then
                IdL6b = CInt(myForm.Txt_IdL6.Text)
            End If
            Proveedorb = myForm.Txt_Proveedor.Text
            If myForm.Chk_FechaOrden.Checked = True Then
                FechaInib = Format(myForm.DTPicker2.Value, "yyyy-MM-dd")
                FechaFinb = Format(myForm.DTPicker3.Value, "yyyy-MM-dd")
            Else
                FechaInib = "1900-01-01"
                FechaFinb = "1900-01-01"

            End If
            If myForm.Chk_FechaEntrega.Checked = True Then
                FechaEInib = Format(myForm.DTPicker4.Value, "yyyy-MM-dd")
                FechaEFinb = Format(myForm.DTPicker5.Value, "yyyy-MM-dd")
            Else
                FechaEInib = "1900-01-01"
                FechaEFinb = "1900-01-01"

            End If
            Sucursalb = myForm.Txt_Sucursal.Text
            Statusb = myForm.Cbo_Estatus.Text
            OrdeComInib = myForm.Txt_OrdeComp1.Text
            OrdeComFinb = myForm.Txt_OrdeComp2.Text
            If myForm.Sw_Filtro = True Then
                Call RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub Btn_Proveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Proveedor.Click
        'mreyes 27/Febrero/2012 12:35 p.m.
        Try
            Opcion = 2
            Call RellenaGrid()
            Btn_Foto.Enabled = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub

    Private Sub Btn_Estilos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Estilos.Click
        'mreyes 27/Febrero/2012 12:52 p.m.
        Try
            Opcion = 1
            Btn_Foto.Enabled = True
            Call RellenaGrid()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Marca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Marca.Click
        'mreyes 27/Febrero/2012 12:52 p.m.
        Try
            Opcion = 3
            Call RellenaGrid()
            Btn_Foto.Enabled = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub RegistrarSegToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistrarSegToolStripMenuItem.Click
        'mreyes 01/Marzo/2012 09:29
        Try
            Dim myForm As New frmCatalogoSegBit

            Sw_Boton = True
            myForm.Accion = 1
            myForm.Txt_Sucursal.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells(2).Value.ToString.Trim()
            myForm.Txt_OrdeComp.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells(3).Value.ToString.Trim()
            myForm.Txt_Estilon.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells(6).Value.ToString
            myForm.Txt_Marca.Text = Mid(DGrid.Rows(DGrid.CurrentRow.Index).Cells(0).Value.ToString, 1, 3)
            myForm.Txt_DescripMarca.Text = Mid(DGrid.Rows(DGrid.CurrentRow.Index).Cells(0).Value.ToString, 7)
            myForm.Txt_OrdeComp.ReadOnly = True

            myForm.WindowState = FormWindowState.Normal
            myForm.Refresh()
            myForm.ShowDialog()
            If myForm.Sw_Registro = True Then
                Call RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Seguimiento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'mreyes 01/Marzo/2012 05:16

        Dim myForm As New frmCatalogoSegBit

        Sw_Boton = True
        myForm.Accion = 1



        myForm.Txt_OrdeComp.ReadOnly = False
        myForm.Txt_Sucursal.Enabled = True

        myForm.WindowState = FormWindowState.Normal
        myForm.Refresh()
        myForm.ShowDialog()
        If myForm.Sw_Registro = True Then
            Call RellenaGrid()
        End If
    End Sub

    Private Sub Btn_Fechas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call Consultar_OrdenCompra(2)
    End Sub
    Private Sub Consultar_OrdenCompra(ByVal Accion As Integer)
        'mreyes 01/Marzo/2012 05:37 p.m.
        If Accion = 2 Then ' modificación
            ' checar permiso
            If pub_TienePermisoProceso("BITACORA", "00", "", True) = False Then Exit Sub
            ' traer la forma para pedir el permiso

            If GLB_Usuario <> "SISTEMAS" And GLB_Usuario <> "MREYES" Or GLB_Usuario <> "FELIX" Or GLB_Usuario <> "FELIXJ" Or GLB_Usuario <> "LORIS" Then
                Dim myFpermiso As New frmPermisoProceso
                myFpermiso.ShowDialog()
                If GLB_PermisoProceso = False Then Exit Sub
            End If
        End If
        If Opcion <> 1 And Opcion <> 4 Then Exit Sub
        Dim myForm As New frmCatalogoPedidoNuevo
        Sw_Boton = True
        myForm.Accion = Accion
        myForm.Txt_Sucursal.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells(2).Value.ToString.Trim()
        myForm.Txt_OrdeComp.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells(3).Value.ToString.Trim()
        myForm.Sw_Bitacora = True
        myForm.MdiParent = BitacoraMain
        myForm.Show()
        ' Call RellenaGrid()
    End Sub




    Private Sub CMenu_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMenu.Opening
        If Opcion <> 1 And Opcion <> 4 Then
            RegistrarSegToolStripMenuItem.Enabled = False
            VerSeguimientoToolStripMenuItem.Enabled = False

            ImagenToolStripMenuItem.Enabled = False
        End If
        If DGrid.Rows(DGrid.CurrentRow.Index).Cells(0).Value.ToString = "" Then
            RegistrarSegToolStripMenuItem.Enabled = False
            VerSeguimientoToolStripMenuItem.Enabled = False

            ImagenToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub Btn_Foto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Foto.Click
        'mreyes 03/Marzo/2012 10:01 a.m.
        Try
            If Opcion = 1 Then
                Dim myForm As New frmConsultaImagen
                myForm.Txt_Estilon.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells(6).Value.ToString
                myForm.Txt_Marca.Text = Mid(DGrid.Rows(DGrid.CurrentRow.Index).Cells(0).Value.ToString.Trim(), 1, 3)
                myForm.Txt_NoFoto.Text = "1"
                myForm.ShowDialog()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ImagenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImagenToolStripMenuItem.Click
        'mreyes 03/Marzo/2012 10:01 a.m.
        Try
            If Opcion = 1 Then
                Dim myForm As New frmConsultaImagen
                myForm.Txt_Estilon.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells(6).Value.ToString
                myForm.Txt_Marca.Text = Mid(DGrid.Rows(DGrid.CurrentRow.Index).Cells(0).Value.ToString.Trim(), 1, 3)
                myForm.Txt_NoFoto.Text = "1"
                myForm.ShowDialog()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Imprimir.Click

    End Sub

    Private Sub VerSeguimientoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerSeguimientoToolStripMenuItem.Click


        'mreyes 07/Marzo/2012 11:07 a.m.
        Try
            Dim myForm As New frmPpalSeguimientos

            Sw_Boton = True

            myForm.OrdeComInib = DGrid.Rows(DGrid.CurrentRow.Index).Cells(3).Value.ToString.Trim()
            myForm.OrdeComFinb = DGrid.Rows(DGrid.CurrentRow.Index).Cells(3).Value.ToString.Trim()

            myForm.WindowState = FormWindowState.Normal
            myForm.Refresh()
            myForm.ShowDialog()
            'If myForm.Sw_Registro = True Then
            'Call RellenaGrid()
            'End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ConsultaOrdenDeCompraToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultaOrdenDeCompraToolStripMenuItem.Click
        Consultar_OrdenCompra(4)
    End Sub



    Private Sub Btn_OrdeComp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_OrdeComp.Click
        'mreyes 09/Marzo/2012 07:39 p.m.
        Try
            Opcion = 4
            Call RellenaGrid()
            Btn_Foto.Enabled = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub




    Private Sub DGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick
        'mreyes 02/Marzo/2011 10:14 a.m.
        Try
            If Opcion = 1 Then '' es estilo
                Dim myForm As New frmCatalogoSegBit

                If DGrid.Rows(DGrid.CurrentRow.Index).Cells(14).Value.ToString = "" Then Exit Sub

                Sw_Boton = True
                myForm.Accion = 4
                myForm.Txt_Sucursal.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells(2).Value.ToString.Trim()
                myForm.Txt_OrdeComp.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells(3).Value.ToString.Trim()
                myForm.Txt_Estilon.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells(6).Value.ToString
                myForm.Txt_Marca.Text = Mid(DGrid.Rows(DGrid.CurrentRow.Index).Cells(0).Value.ToString, 1, 3)
                myForm.Txt_DescripMarca.Text = Mid(DGrid.Rows(DGrid.CurrentRow.Index).Cells(0).Value.ToString, 7)

                myForm.WindowState = FormWindowState.Normal
                myForm.Refresh()
                myForm.ShowDialog()
            End If

            If Opcion = 2 Then
                If UCase(Mid(DGrid.Rows(DGrid.CurrentRow.Index).Cells(1).Value.ToString, 1, 3)) = "TOT" Then
                    Proveedorb = ""
                Else
                    Proveedorb = Mid(DGrid.Rows(DGrid.CurrentRow.Index).Cells(1).Value.ToString, 1, 3)
                End If
                Opcion = 3
                Call RellenaGrid()
            End If

            If Opcion = 4 Then
                If UCase(Mid(DGrid.Rows(DGrid.CurrentRow.Index).Cells(1).Value.ToString, 1, 3)) = "TOT" Then
                    Proveedorb = ""
                Else
                    Proveedorb = Mid(DGrid.Rows(DGrid.CurrentRow.Index).Cells(1).Value.ToString, 1, 3)
                End If
                If UCase(Mid(DGrid.Rows(DGrid.CurrentRow.Index).Cells(0).Value.ToString, 1, 3)) = "TOT" Then
                    Marcab = ""
                Else
                    Marcab = Mid(DGrid.Rows(DGrid.CurrentRow.Index).Cells(0).Value.ToString, 1, 3)
                End If
                Sucursalb = DGrid.Rows(DGrid.CurrentRow.Index).Cells(2).Value.ToString.Trim()
                OrdeComInib = DGrid.Rows(DGrid.CurrentRow.Index).Cells(3).Value.ToString.Trim()
                OrdeComFinb = DGrid.Rows(DGrid.CurrentRow.Index).Cells(3).Value.ToString.Trim()
                Opcion = 1
                Call RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub

    Private Sub ModificarFechasOrdendeCompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarFechasOrdendeCompra.Click
        Call Btn_Fechas_Click(sender, e)
    End Sub
End Class