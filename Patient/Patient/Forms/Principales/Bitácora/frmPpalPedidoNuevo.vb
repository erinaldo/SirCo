Public Class frmPpalPedidoNuevo
    'mreyes 11/Febrero/2012 05:43 p.m.
    Private objDataSet As Data.DataSet
    Public Sw_Registro As Boolean = False
    Public Sw_PedidoNuevo As Boolean = True
    Public Sw_Cancelaciones As Boolean = False

    Dim Sw_PedidoMano As Boolean = False
    Dim RutaArchivoCorreo As String = ""
    Dim Marcab As String
    Dim Modelob As String
    Dim Estilofb As String
    'Dim IdDivisionb As Integer
    'Dim IdDepartamentob As Integer
    'Dim IdFamiliab As Integer
    'Dim IdLineab As Integer
    'Dim IdL1b As Integer
    'Dim IdL2b As Integer
    'Dim IdL3b As Integer
    'Dim IdL4b As Integer
    'Dim IdL5b As Integer
    'Dim IdL6b As Integer

    Dim IdDivisionb As String
    Dim IdDepartamentob As String
    Dim IdFamiliab As String
    Dim IdLineab As String
    Dim IdL1b As String
    Dim IdL2b As String
    Dim IdL3b As String
    Dim IdL4b As String
    Dim IdL5b As String
    Dim IdL6b As String


    Dim cveDivisionb As String = ""
    Dim cveDepartamentob As String = ""
    Dim cveFamiliab As String = ""
    Dim cveLineab As String = ""
    Dim cveL1b As String = ""
    Dim cveL2b As String = ""
    Dim cveL3b As String = ""
    Dim cveL4b As String = ""
    Dim cveL5b As String = ""
    Dim cveL6b As String = ""


    Dim Proveedorb As String

    Public Sucursalb As String
    Public OrdeCompb As String
    Dim FechaInib As String
    Dim FechaFinb As String
    Dim Statusb As String
    Dim FechaEInib As String
    Dim FechaEFinb As String
    Dim OrdeComInib As String
    Dim OrdeComFinb As String

    Dim Sw_Load As Boolean = True
    Dim Sw_Boton As Boolean = False
    Dim Sw_NoRegistros As Boolean = False
    Dim FechaUltResurt As Date
    Dim Sw_Pintar As Boolean = False
    Dim Sw_Costos As Boolean = True

    Dim TipoPedidoB As String = ""
    Public ResAutb As Integer = 0

    Private Sub frmPpalPedidoNuevo_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Glb_RefrescarPedido = True Then
            Glb_RefrescarPedido = False
            Call RellenaGrid()
            Me.WindowState = FormWindowState.Maximized
        End If

        If Sw_NoRegistros = True Then
            DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
        End If

        If Sw_Load = True Then
            If Sw_NoRegistros = False Then
                Sw_Load = False
                ''     InicializaGrid()
                Factura_Microsip()
            Else
                Sw_Load = False
                'Sw_NoRegistros = False
            End If
        End If
    End Sub





    Private Sub frmPpalPedidoNuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
        If e.KeyCode = Keys.F5 Then
            Call Btn_Filtro_Click_1(sender, e)
        End If
    End Sub

    Private Sub frmPpalPedidoNuevo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Sw_Load = True
            Sw_Pintar = True
            Call LimpiarBusqueda()
            If Sucursalb = "" Then

                FechaInib = Format(Now.Date, "yyyy-MM-dd")
                FechaFinb = Format(Now.Date, "yyyy-MM-dd")

            End If
            Call RellenaGrid()
            Call GenerarToolTip()
            If Sw_PedidoNuevo = True Then
                Me.Text = "Pedido Nuevo"
            Else
                Me.Text = "Resurtidos"
                'Btn_Transferir.Visible = True
            End If
            If Sw_Cancelaciones = True Then
                Me.Text = "Cancelación de Orden de Compra"
                Btn_Nuevo.Enabled = False
                Btn_Editar.Enabled = False
                Btn_Eliminar.Enabled = True
            End If

            '' traer fecha ultimo resurtido
            Call FechaUltimoResurtido()

            If GLB_Usuario <> "SISTEMAS" And GLB_Usuario <> "MREYES" Or GLB_Usuario <> "FELIX" Or GLB_Usuario <> "FELIXJ" Or GLB_Usuario <> "LORIS" Then
                If pub_TienePermisoProceso("COSBIT", "01", "", False) = False Then
                    Exit Sub
                Else

                    Sw_Costos = False

                End If
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub FechaUltimoResurtido()
        'mreyes 03/Mayo/2012 11:58 a.m.
        Try
            Dim objDataSet1 As Data.DataSet
            Using objCantArti As New BCL.BCLPedidos(GLB_ConStringCipSis)
                objDataSet1 = objCantArti.usp_TraerFechaUltResurt

                If objDataSet1.Tables(0).Rows.Count > 0 Then
                    If IsDBNull(objDataSet1.Tables(0).Rows(0).Item("fecha")) Then
                        FechaUltResurt = "01-01-1900"
                    Else
                        FechaUltResurt = objDataSet1.Tables(0).Rows(0).Item("fecha")
                    End If

                Else
                    FechaUltResurt = "01-01-1900"
                End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub GenerarToolTip()
        Try

            If Sw_PedidoNuevo = True Then
                ToolTip.SetToolTip(Btn_Nuevo, "Nuevo Pedido")
                ToolTip.SetToolTip(Btn_Editar, "Editar Pedido")
                ToolTip.SetToolTip(Btn_Eliminar, "Cancelar Pedido")
                ToolTip.SetToolTip(Btn_Consultar, "Consultar Pedido")
            Else
                ToolTip.SetToolTip(Btn_Nuevo, "Nuevo Resurtido")
                ToolTip.SetToolTip(Btn_Editar, "Editar Resurtido")
                ToolTip.SetToolTip(Btn_Eliminar, "Cancelar Resurtido")
                ToolTip.SetToolTip(Btn_Consultar, "Consultar Resurtido")
                ToolTip.SetToolTip(Btn_Transferir, "Generar Resurtidos Automáticos")
            End If

            ToolTip.SetToolTip(Btn_Filtro, "Búsqueda Avanzada")
            'ToolTip.SetToolTip(Btn_Refrescar, "Refrescar Información")
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
            ToolTip.SetToolTip(Btn_Imprimir, "Imprimir Información")
            ToolTip.SetToolTip(Btn_Pdf, "Generar Información de ordenes de compra seleccionadas en PDF")
            ToolTip.SetToolTip(Btn_Correo, "Enviar ordenes de compra seleccionadas al proveedor.")
            ToolTip.SetToolTip(Btn_Salir, "Salir")
            ToolTip.SetToolTip(Btn_InvertirSeleccion, "Invertir Selección")



        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub RellenaGrid()
        Using objPedidoNuevo As New BCL.BCLPedidos(Glb_ConStringCipSis)
            Try
                Dim ResurtSN As String = IIf(Sw_PedidoNuevo = True, "N", "S")
                Dim Accion As Integer = 0
                Me.Cursor = Cursors.WaitCursor

                If Sw_Load = True Then
                    ' Sw_Load = False
                    Accion = 2
                Else
                    Accion = 2
                    If Sw_NoRegistros = True Then
                        DGrid.Columns.Remove("Selec")

                    End If

                End If

                If Len(GLB_CveSucursal) > 0 Then
                    If Mid(GLB_CveSucursal, 1, 1) <> 9 Then
                        ' Es tienda
                        Accion = 3
                    End If
                End If
                '''' DGrid.ReadOnly = True
                DGrid.DataSource = Nothing
                objDataSet = objPedidoNuevo.usp_PpalPedidoNuevo(Accion, Sucursalb, OrdeComInib, OrdeComFinb, Marcab, Modelob, Estilofb, _
                                                                    IdDivisionb, IdDepartamentob, IdFamiliab, IdLineab, IdL1b, IdL2b, IdL3b, _
                                                                    IdL4b, IdL5b, IdL6b, Proveedorb, Statusb, FechaInib, _
                                                                    FechaFinb, FechaEInib, FechaEFinb, ResurtSN, TipoPedidoB, ResAutb)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section

                    DGrid.DataSource = objDataSet.Tables(0)

                    InicializaGrid()
                    'LimpiarBusqueda()
                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True
                    Btn_Editar.Enabled = True
                    Btn_Consultar.Enabled = True
                    Sw_NoRegistros = True
                    Sw_Pintar = True
                    DGrid.Rows(0).Selected = True

                Else
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    If Sw_Load = False Then
                        MsgBox("No se encontraron Pedidos que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    End If
                    Btn_Excel.Enabled = False
                    Btn_Editar.Enabled = False
                    Btn_Consultar.Enabled = False


                End If

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using


    End Sub
    Private Sub LimpiarBusqueda()
        Marcab = ""
        Modelob = ""
        Estilofb = ""
        IdDivisionb = ""
        IdDepartamentob = ""
        IdFamiliab = ""
        IdLineab = ""
        IdL1b = ""
        IdL2b = ""
        IdL3b = ""
        IdL4b = ""
        IdL5b = ""
        IdL6b = ""
        Proveedorb = ""




        Statusb = ""

        FechaEInib = "1900-01-01"
        FechaEFinb = "1900-01-01"
        FechaInib = "1900-01-01"
        FechaFinb = "1900-01-01"
        OrdeComInib = ""
        OrdeComFinb = ""
        If OrdeCompb <> "" Then
            OrdeComInib = OrdeCompb
            OrdeComFinb = OrdeCompb
        Else
            Sucursalb = ""
        End If
        OrdeCompb = ""

    End Sub


    Private Sub Btn_Refrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Sub InicializaGrid()
        '' 
        'mreyes 12/Febrero/2011 05:37 p.m.
        Try

            Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
            Dim row As DataRow = dt.NewRow()

            row(1) = "Total: "
            row(7) = pub_SumarColumnaGrid(DGrid, 7, DGrid.RowCount - 1)
            row(8) = pub_SumarColumnaGrid(DGrid, 8, DGrid.RowCount - 1)
            'dt.Rows.Add(row)
            dt.Rows.InsertAt(row, 0)
            DGrid.DataSource = dt


            DGrid.Columns(0).Frozen = 1
            DGrid.Columns(1).Frozen = 1
            DGrid.Columns(0).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)


            DGrid.Columns(1).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(1).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)



            DGrid.RowHeadersVisible = False

            DGrid.Columns(0).HeaderText = "Det."
            DGrid.Columns(1).HeaderText = "Pedido"
            DGrid.Columns(2).HeaderText = "Tipo"


            DGrid.Columns(3).HeaderText = "Estatus"
            DGrid.Columns(4).HeaderText = "Fecha"
            DGrid.Columns(5).HeaderText = "Marca"
            DGrid.Columns(6).HeaderText = "Proveedor"
            DGrid.Columns(7).HeaderText = "Pares"
            DGrid.Columns(8).HeaderText = "Importe"
            DGrid.Columns(9).HeaderText = "Email01"
            DGrid.Columns(10).HeaderText = "Email02"
            DGrid.Columns(11).HeaderText = "Observación"
            DGrid.Columns(12).HeaderText = "FCancela"
            DGrid.Columns(13).HeaderText = "Correo"


            DGrid.Columns(0).ReadOnly = True
            DGrid.Columns(1).ReadOnly = True
            DGrid.Columns(2).ReadOnly = True
            DGrid.Columns(3).ReadOnly = True

            DGrid.Columns(4).ReadOnly = True
            DGrid.Columns(5).ReadOnly = True
            DGrid.Columns(6).ReadOnly = True
            DGrid.Columns(7).ReadOnly = True
            DGrid.Columns(8).ReadOnly = True
            DGrid.Columns(10).ReadOnly = True
            DGrid.Columns(11).ReadOnly = True
            DGrid.Columns(12).ReadOnly = True
            DGrid.Columns(13).ReadOnly = True

            'DGrid.Columns(0).Visible = False
            ' DGrid.Columns(8).Visible = False
            DGrid.Columns(10).Visible = False
            DGrid.Columns(11).Visible = False
            DGrid.Columns(12).Visible = False

            DGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid.Columns(8).DefaultCellStyle.Format = "c"
            DGrid.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)


            AgregarColumna()
            DGrid.Columns(14).ReadOnly = False

            '' CHECAR SI PUEDE VER COSTOS.. LOS COSTOS NO SE PODRAN VER SI EN PUERTO EL PUERTO DICE 01... 
            'mreyes 17/Julio/2012 09:26 a.m.
            If GLB_Usuario <> "SISTEMAS" And GLB_Usuario <> "MREYES" Or GLB_Usuario <> "FELIX" Or GLB_Usuario <> "FELIXJ" Or GLB_Usuario <> "LORIS" Then
                If pub_TienePermisoProceso("PEDNUEVO", "01", "", False) = False Then
                    Exit Sub
                Else
                    DGrid.Columns(8).Visible = False
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub AgregarColumna()
        'mreyes 28/Abril/2012 10:40 a.m.

        Dim colImagen As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        colImagen.Name = "Selec"
        colImagen.HeaderText = "Selec"
        colImagen.DisplayIndex = 14
        colImagen.ReadOnly = False
        colImagen.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        colImagen.CellTemplate = New DataGridViewCheckBoxCell()
        ' añadir columna de imagen a la coleccion del grid 
        DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        ''DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DGrid.Columns.Add(colImagen)


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

    Private Sub Btn_Nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Nuevo.Click



        ' checar permiso
        If Sw_Costos = False Then
            MsgBox("No tiene permiso para realizar este proceso.", MsgBoxStyle.Critical, "Permisos")
            Exit Sub
        End If


        Dim myForm As New frmCatalogoPedidoNuevo
        Sw_Boton = True
        myForm.Accion = 1
        myForm.Sw_PedidoNuevo = Sw_PedidoNuevo
        myForm.MdiParent = BitacoraMain
        myForm.Show()
        If myForm.Sw_Registro = True Then
            Call RellenaGrid()
        End If


    End Sub

    Private Sub DGrid_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellEnter

    End Sub

    Private Sub DGrid_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGrid.CellFormatting
        Try
            '' If Sw_PedidoNuevo = True Then Exit Sub

            Dim Sw_NoEntro As Boolean = False
            Dim Entrega As Date

            Dim DiasEntrega As Integer = 0
            If Sw_Pintar = False Then Exit Sub




            If Me.DGrid.Columns(e.ColumnIndex).Name <> "FechaSeg" Then Exit Sub
            ''If Me.DGrid.Columns(e.ColumnIndex).Name <> "fecha" Then Exit Sub
            If e.RowIndex >= DGrid.RowCount - 1 Then
                If Sw_Load = False Then
                    Sw_Pintar = False
                End If
                Exit Sub
            End If


            If Sw_PedidoNuevo = False Then
                If Not IsDBNull(DGrid.Rows(e.RowIndex).Cells("fecha").Value) Then
                    Entrega = DGrid.Rows(e.RowIndex).Cells("fecha").Value
                End If


                If Entrega = FechaUltResurt Then
                    Sw_NoEntro = True
                    DGrid.Rows(e.RowIndex).Cells("ordecomp").Style.BackColor = Color.GreenYellow
                    DGrid.Rows(e.RowIndex).Cells("ordecomp").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                End If

                If Not IsDBNull(DGrid.Rows(e.RowIndex).Cells("Observa").Value) Then
                    If DGrid.Rows(e.RowIndex).Cells("Observa").Value = "RESURTIDO AUTOMÁTICO NOCTURNO" Then
                        DGrid.Rows(e.RowIndex).Cells("ordecomp").Style.BackColor = Color.Pink
                        DGrid.Rows(e.RowIndex).Cells("sucursal").Style.BackColor = Color.Pink

                        DGrid.Rows(e.RowIndex).Cells("TIPOPEDIDO").Style.BackColor = Color.Pink
                        DGrid.Rows(e.RowIndex).Cells("status").Style.BackColor = Color.Pink

                        DGrid.Rows(e.RowIndex).Cells("fecha").Style.BackColor = Color.Pink
                        DGrid.Rows(e.RowIndex).Cells("proveedor").Style.BackColor = Color.Pink

                        DGrid.Rows(e.RowIndex).Cells("pares").Style.BackColor = Color.Pink

                        DGrid.Rows(e.RowIndex).Cells("importe").Style.BackColor = Color.Pink

                        DGrid.Rows(e.RowIndex).Cells("email01").Style.BackColor = Color.Pink

                        DGrid.Rows(e.RowIndex).Cells("observa").Style.BackColor = Color.Pink

                        DGrid.Rows(e.RowIndex).Cells("marca").Style.BackColor = Color.Pink

                        DGrid.Rows(e.RowIndex).Cells("marca").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                        DGrid.Rows(e.RowIndex).Cells("ordecomp").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                        DGrid.Rows(e.RowIndex).Cells("sucursal").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                        DGrid.Rows(e.RowIndex).Cells("TIPOPEDIDO").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                        DGrid.Rows(e.RowIndex).Cells("status").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                        DGrid.Rows(e.RowIndex).Cells("fecha").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                        DGrid.Rows(e.RowIndex).Cells("proveedor").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                        DGrid.Rows(e.RowIndex).Cells("pares").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                        DGrid.Rows(e.RowIndex).Cells("importe").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                        DGrid.Rows(e.RowIndex).Cells("email01").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                        DGrid.Rows(e.RowIndex).Cells("observa").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                    End If

                End If
            End If


            If Not IsNothing(DGrid.Rows(e.RowIndex).Cells("FechaSeg").Value) Then
                If Not IsDBNull(DGrid.Rows(e.RowIndex).Cells("FechaSeg").Value) Then
                    Sw_NoEntro = True
                    DGrid.Rows(e.RowIndex).Cells("FechaSeg").Style.BackColor = Color.Yellow
                    DGrid.Rows(e.RowIndex).Cells("FechaSeg").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                Else
                    DGrid.Rows(e.RowIndex).Cells("FechaSeg").Style.BackColor = Color.Red
                    DGrid.Rows(e.RowIndex).Cells("FechaSeg").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                End If
            Else
                DGrid.Rows(e.RowIndex).Cells("FechaSeg").Style.BackColor = Color.Red
                DGrid.Rows(e.RowIndex).Cells("FechaSeg").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

            End If


            'CHECAR LAS DOS FECHAS Y PONER ALGO EN
            'If Not IsNothing(DGrid.Rows(e.RowIndex).Cells("FCancela").Value) Then
            '    If Not IsDBNull(DGrid.Rows(e.RowIndex).Cells("FCancela").Value) Then
            '        If DGrid.Rows(e.RowIndex).Cells("FCancela").Value = Format(DGrid.Rows(e.RowIndex).Cells("fecha").Value, "yyyy-MM-dd") Then

            '            DGrid.Rows(e.RowIndex).Cells("fecha").Style.BackColor = Color.Aqua
            '            DGrid.Rows(e.RowIndex).Cells("fecha").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

            '        End If
            '    End If
            'End If


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick
        Try
            Call Btn_Consultar_Click(sender, e)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DGrid.KeyPress
        Try
            Call Btn_Consultar_Click(sender, e)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Consultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Consultar.Click
        If Sw_NoRegistros = False Then Exit Sub
        Dim myForm As New frmCatalogoPedidoNuevo
        Sw_Boton = True
        myForm.Accion = 4
        myForm.Txt_Sucursal.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("sucursal").Value.ToString.Trim()
        myForm.Txt_OrdeComp.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("ordecomp").Value.ToString.Trim()
        myForm.MdiParent = BitacoraMain
        myForm.Show()
        Call RellenaGrid()
    End Sub

    Private Sub Btn_Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar.Click
        If Sw_NoRegistros = False Then Exit Sub


        If DGrid.Rows(DGrid.CurrentRow.Index).Cells("STATUS").Value.ToString.Trim() = "ZC" Then
            MsgBox("No se puede editar la orden de compra, puesto que se encuentra CANCELADA.", MsgBoxStyle.Information, "Aviso")
            Exit Sub
        End If

        ' checar permiso
        If Sw_Costos = False Then
            MsgBox("No tiene permiso para realizar este proceso.", MsgBoxStyle.Critical, "Permisos")
            Exit Sub
        End If
        'If DGrid.Rows(DGrid.CurrentRow.Index).Cells("cancela").Value > 0 Then
        '    MsgBox("No se puede editar la orden de compra, puesto que se encuentra EN RECIBO PARCIAL.", MsgBoxStyle.Information, "Aviso")
        '    Exit Sub
        'End If

        If DGrid.Rows(DGrid.CurrentRow.Index).Cells("cancela").Value > 0 Then
            MsgBox("CUIDADO, la orden de compra, se encuentra EN RECIBO PARCIAL.", MsgBoxStyle.Information, "Aviso")

        End If


        Dim myForm As New frmCatalogoPedidoNuevo
        Sw_Boton = True
        myForm.Accion = 2
        myForm.Sw_PedidoNuevo = Sw_PedidoNuevo
        myForm.Txt_Sucursal.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("sucursal").Value.ToString.Trim()
        myForm.Txt_OrdeComp.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("ordecomp").Value.ToString.Trim()

        myForm.MdiParent = BitacoraMain
        myForm.Show()

        Call RellenaGrid()

    End Sub

    Private Sub Btn_Filtro_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        'mreyes 28/Febrero/2012 10:08 a.m.
        Dim myForm As New frmFiltrosPedidoNuevo
        If Sw_PedidoNuevo = False Then
            myForm.Text = "Filtros Resurtido"
        End If

        If TipoPedidoB <> "" Then
            myForm.Chk_TipoPedido.Checked = True
            If TipoPedidoB = "CATALOGO" Then
                myForm.Opt_PedidoCatalogo.Checked = True
            Else
                myForm.Opt_PedidoUnico.Checked = True
            End If
        End If




        myForm.Txt_Marca.Text = Marcab
        myForm.Txt_Estilon.Text = Modelob
        myForm.Txt_Estilof.Text = Estilofb
        myForm.Txt_DescripDivision.Text = IdDivisionb
        myForm.Txt_DescripDepto.Text = IdDepartamentob
        myForm.Txt_DescripFamilia.Text = IdFamiliab
        myForm.Txt_DescripLinea.Text = IdLineab
        myForm.Txt_DescripL1.Text = IdL1b
        myForm.Txt_DescripL2.Text = IdL2b
        myForm.Txt_DescripL3.Text = IdL3b
        myForm.Txt_DescripL4.Text = IdL4b
        myForm.Txt_DescripL5.Text = IdL5b
        myForm.Txt_DescripL6.Text = IdL6b
        myForm.Txt_Proveedor.Text = Proveedorb
        myForm.Txt_Sucursal.Text = Sucursalb
        myForm.Cbo_Estatus.Text = Statusb
        myForm.Txt_OrdeComp1.Text = OrdeComInib
        myForm.Txt_OrdeComp2.Text = OrdeComFinb

        myForm.Txt_Division.Text = cveDivisionb
        myForm.Txt_Depto.Text = cveDepartamentob
        myForm.Txt_Familia.Text = cveFamiliab
        myForm.Txt_Linea.Text = cveLineab
        myForm.Txt_L1.Text = cveL1b
        myForm.Txt_L2.Text = cveL2b
        myForm.Txt_L3.Text = cveL3b
        myForm.Txt_L4.Text = cveL4b
        myForm.Txt_L5.Text = cveL5b
        myForm.Txt_L6.Text = cveL6b

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

        myForm.ShowDialog()
        Marcab = myForm.Txt_Marca.Text
        Modelob = myForm.Txt_Estilon.Text
        Estilofb = myForm.Txt_Estilof.Text

        IdDivisionb = myForm.Txt_DescripDivision.Text
        IdDepartamentob = myForm.Txt_DescripDepto.Text
        IdFamiliab = myForm.Txt_DescripFamilia.Text
        IdLineab = myForm.Txt_DescripLinea.Text
        IdL1b = myForm.Txt_DescripL1.Text
        IdL2b = myForm.Txt_DescripL2.Text
        IdL3b = myForm.Txt_DescripL3.Text
        IdL4b = myForm.Txt_DescripL4.Text
        IdL5b = myForm.Txt_DescripL5.Text
        IdL6b = myForm.Txt_DescripL6.Text


        cveDivisionb = myForm.Txt_Division.Text
        cveDepartamentob = myForm.Txt_Depto.Text
        cveFamiliab = myForm.Txt_Familia.Text
        cveLineab = myForm.Txt_Linea.Text
        cveL1b = myForm.Txt_L1.Text
        cveL2b = myForm.Txt_L2.Text
        cveL3b = myForm.Txt_L3.Text
        cveL4b = myForm.Txt_L4.Text
        cveL5b = myForm.Txt_L5.Text
        cveL6b = myForm.Txt_L6.Text

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


        If myForm.Chk_TipoPedido.Checked = True Then

            If myForm.Opt_PedidoCatalogo.Checked = True Then
                TipoPedidoB = "CATALOGO"
            Else
                TipoPedidoB = "UNICO"
            End If
        Else
            TipoPedidoB = ""
        End If




        If myForm.Sw_Filtro = True Then
            Call RellenaGrid()
        End If
    End Sub



    Private Sub NuevoPDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoPDToolStripMenuItem.Click
        Call Btn_Nuevo_Click(sender, e)
    End Sub

    Private Sub EditarPDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditarPDToolStripMenuItem.Click
        Call Btn_Editar_Click(sender, e)
    End Sub

    Private Sub ConsultarPDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultarPDToolStripMenuItem.Click
        Call Btn_Consultar_Click(sender, e)
    End Sub

    Private Sub Btn_Eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Eliminar.Click

        'mreyes 28/Abril/2012 10:48 a.m.
        If Sw_NoRegistros = False Then Exit Sub
        '' PRIMERO TIENE QUE GENERAR EL ID DOCTO PARA GRABAR EN DOCTOS_CP
        Try
            If MsgBox("Esta seguro de querer cancelar los Pedidos Seleccionados?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub
            Me.Cursor = Cursors.WaitCursor

            Dim Cont As Integer = 0
            Dim OrdeComp As String
            Dim Sucursal As String

            For Each row As DataGridViewRow In DGrid.Rows
                If row.Cells("Selec").Value = True Then
                    OrdeComp = row.Cells("ordecomp").Value
                    Sucursal = row.Cells("sucursal").Value
                    Cont = Cont + 1

                    Using objPedidos As New BCL.BCLPedidos(GLB_ConStringCipSis)
                        Try
                            'Get the specific project selected in the ListView control
                            If objPedidos.usp_ActualizarOrdeComp(Sucursal, OrdeComp) = True Then
                                ' SI SE ACTUALIZO

                            End If
                        Catch ExceptionErr As Exception
                            MessageBox.Show(ExceptionErr.Message.ToString)
                        End Try
                    End Using


                End If ' del select  
            Next
            Me.Cursor = Cursors.Default
            MsgBox("Se han Cancelado '" & Cont & "' Pedidos.", MsgBoxStyle.Information, "Confirmación")
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_InvertirSeleccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_InvertirSeleccion.Click
        If Sw_NoRegistros = False Then Exit Sub
        Call Factura_Microsip()
    End Sub

    Private Sub Factura_Microsip()
        'mreyes 21/Marzo/2012 11:53 a.m.

        For Each row As DataGridViewRow In DGrid.Rows

            If row.Cells("ordecomp").Value = "Total: " Then Exit For

            If row.Cells("Selec").Value = True Then
                row.Cells("Selec").Value = False
            Else
                row.Cells("Selec").Value = True
            End If


        Next
    End Sub



    Private Sub Btn_Pdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Pdf.Click
        'mreyes 16/Marzo/2012 06:24 p.m.
        If Sw_NoRegistros = False Then Exit Sub
        '' PRIMERO TIENE QUE GENERAR EL ID DOCTO PARA GRABAR EN DOCTOS_CP
        Try
            Dim Cont As Integer = 0

            If MsgBox("Esta seguro de querer generar los archivos PDF de los pedidos seleccionados. Este proceso puede durar varios minutos.?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub
            Me.Cursor = Cursors.WaitCursor

            For Each row As DataGridViewRow In DGrid.Rows
                If row.Cells("Selec").Value = True Then
                    If row.Cells("status").Value <> "ZC" Then
                        Cont = Cont + 1
                        Dim myForm As New frmCatalogoPedidoNuevo

                        Sw_Boton = True
                        myForm.Accion = 4
                        myForm.Sw_SoloPasoPDF = True
                        myForm.Sw_PedidoNuevo = Sw_PedidoNuevo
                        myForm.Txt_Sucursal.Text = row.Cells("sucursal").Value.ToString.Trim()
                        myForm.Txt_OrdeComp.Text = row.Cells("ordecomp").Value.ToString.Trim()
                        myForm.MdiParent = BitacoraMain

                        myForm.Show()
                        myForm.Close()
                        myForm.Dispose()
                    End If
                End If ' del microsip 
            Next

            Me.Cursor = Cursors.Default
            MsgBox("Se han creado '" & Cont & "' Archivos de Pedido.", MsgBoxStyle.Information, "Confirmación")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Function Inserta_OrdeComp(ByVal OrdeComp As String, ByVal Sucursal As String, ByVal Marca As String, ByVal Proveedor As String, _
                                    ByVal Dsctopp As Decimal, ByVal diaspp As Decimal, ByVal dscto01 As Decimal, ByVal dscto02 As Decimal, ByVal dscto03 As Decimal, ByVal dscto04 As Decimal, ByVal dscto05 As Decimal, ByVal iva As Decimal) As Boolean
        'mreyes 14/Febrero/2012 01:44 p.m.
        Using objPedidos As New BCL.BCLPedidos(GLB_ConStringCipSis)
            'Get a new Project DataSet
            Try

                objDataSet = objPedidos.Inserta_OrdeComp  'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow


                'Set the values in the DataRow

                objDataRow.Item("sucursal") = Trim(Sucursal)
                objDataRow.Item("ordecomp") = Trim(OrdeComp)
                objDataRow.Item("status") = "AP"
                objDataRow.Item("fecha") = Now.Date
                objDataRow.Item("marca") = Trim(Marca)
                objDataRow.Item("proveedor") = Proveedor
                objDataRow.Item("observa") = "RESURTIDO AUTOMÁTICO"
                objDataRow.Item("usuario") = GLB_Usuario
                objDataRow.Item("resurtsn") = "S"
                objDataRow.Item("dsctopp") = Val(Dsctopp)
                objDataRow.Item("diaspp") = Val(diaspp)
                objDataRow.Item("dscto01") = Val(dscto01)
                objDataRow.Item("dscto02") = Val(dscto02)
                objDataRow.Item("dscto03") = Val(dscto03)
                objDataRow.Item("dscto04") = Val(dscto04)
                objDataRow.Item("dscto05") = Val(dscto05)
                objDataRow.Item("iva") = Val(iva)



                'Add the DataRow to the DataSet
                objDataSet.Tables(0).Rows.Add(objDataRow)

                'Add the Project
                If Not objPedidos.usp_Captura_OrdeComp(1, objDataSet) Then
                    '' Throw New Exception("Falló Inserción de OrdeComp")
                Else
                    Inserta_OrdeComp = True
                End If
                Inserta_OrdeComp = True
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using

    End Function
    Private Function ActualizarCantSolMedida(ByVal Marca As String, ByVal Estilon As String, ByVal Corrida As String, ByVal Medida As String) As Boolean
        'mreyes 21/Marzo/2012 07:19 p.m.

        Using objPedidos As New BCL.BCLPedidos(GLB_ConStringCipSis)
            Try
                'Get the specific project selected in the ListView control
                ActualizarCantSolMedida = objPedidos.usp_ActualizarCantSolMedida(Marca, Estilon, Corrida, Medida)
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function
    Private Sub Btn_Transferir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Transferir.Click
        ' checar permiso
        If GLB_Usuario <> "MREYES" And GLB_Usuario <> "FELIX" And GLB_Usuario <> "FELIXJ" Or GLB_Usuario <> "LORIS" Then
            If pub_TienePermisoProceso("PEDNUEVO", "00", "", True) = False Then Exit Sub


            Dim myFpermiso As New frmPermisoProceso
            myFpermiso.ShowDialog()
            If GLB_PermisoProceso = False Then Exit Sub
        End If

        '' PRIMERO TIENE QUE GENERAR EL ID DOCTO PARA GRABAR EN DOCTOS_CP
        Try
            Dim Cont As Integer = 0
            Dim OrdeComp As String = ""
            Dim objDataSet1 As Data.DataSet


            Dim loteminimo As Integer = 0
            Dim CantidadLote As Integer = 0
            Dim Sw_MarcaCTA As Boolean = False
            Dim Track As Integer = 0

            If MsgBox("Esta seguro de querer generar resurtidos automáticos.? Este proceso puede durar varios minutos.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub
            Me.Cursor = Cursors.WaitCursor





            Using objArticulosSolicitados As New BCL.BCLPedidos(GLB_ConStringCipSis)
                Dim objDataSet As Data.DataSet



                Dim Medida As String = ""
                Dim Corrida As String = ""

                Dim Pcomp As Decimal = 0
                Dim Costo As Decimal = 0
                Dim Proveedor As String = ""
                Dim Marca As String = ""
                Dim Sucursal As String = "15"

                Dim Sw_OrdeComp As Boolean = True
                objDataSet = objArticulosSolicitados.usp_TraerResurtidoAuto()
                PBar1.Value = 0
                PBar1.Minimum = 0
                PBar1.Maximum = 0
                Lbl_Auto.AutoSize = True
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Lbl_Auto.Visible = True
                    PBar1.Visible = True
                    PBar1.Minimum = 0
                    PBar1.Maximum = objDataSet.Tables(0).Rows.Count

                    For I As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                        Lbl_Auto.Text = "Marca : " & objDataSet.Tables(0).Rows(I).Item("marca") & " Proveedor: " & objDataSet.Tables(0).Rows(I).Item("proveedor")
                        Lbl_Auto.Refresh()
                        PBar1.Value = PBar1.Value + 1

                        Track = 0
                        If Marca <> objDataSet.Tables(0).Rows(I).Item("marca") Or Proveedor <> objDataSet.Tables(0).Rows(I).Item("proveedor") Then
                            '' Genera otra orden de compra... 
Marca_Cta:
                            Proveedor = objDataSet.Tables(0).Rows(I).Item("proveedor")
                            Marca = objDataSet.Tables(0).Rows(I).Item("marca")
                            SW_ORDECOMP = True


                            '' generar detallado de orden de compra...
                            Dim objPrueba1 As Data.DataSet
                            Dim Estilon As String = ""
                            Using objPrueba As New BCL.BCLPedidos(GLB_ConStringCipSis)

                                objPrueba1 = objPrueba.usp_TraerArticulosSolicitados(Marca, Proveedor, Track)
                                If objPrueba1.Tables(0).Rows.Count > 0 Then
                                    For z As Integer = 0 To objPrueba1.Tables(0).Rows.Count - 1
                                        Estilon = objPrueba1.Tables(0).Rows(z).Item("estilon")
                                        Corrida = objPrueba1.Tables(0).Rows(z).Item("corrida")
                                        CantidadLote = objPrueba1.Tables(0).Rows(z).Item("CTD")
                                        Using objCantArti As New BCL.BCLPedidos(GLB_ConStringCipSis)
                                            objDataSet1 = objCantArti.usp_TraerMedida(1, Marca, Proveedor, Estilon, Corrida)

                                            If objDataSet1.Tables(0).Rows.Count > 0 Then
                                                '' grabar detallado de orden de compra 
                                                loteminimo = Val(objDataSet1.Tables(0).Rows(0).Item("loteminimo"))
                                                If CantidadLote >= loteminimo Then
                                                    If SW_ORDECOMP = True Then
                                                        ' grabar orden de compra
                                                        Cont = Cont + 1
                                                        SW_ORDECOMP = False
                                                        '' CHECAR LA ORDEN DE COMPRA... 
                                                        OrdeComp = fn_TraerFolioOrdeComp(1, Sucursal, 1)
                                                        OrdeComp = pub_RellenarIzquierda(OrdeComp, 6)
                                                        '
                                                        '' generar folio de orden de compra 
                                                        '''''''''''''''''''''''''''''''''''''''''''''' //Dsctopp, Diaspp, Dscto01, Dscto02, Dscto03, Dscto04, Dscto05, 16.0 AS IVA
                                                        If Sw_MarcaCTA = False Then
                                                            If Inserta_OrdeComp(OrdeComp, Sucursal, Marca, Proveedor, Val(objDataSet.Tables(0).Rows(I).Item("Dsctopp")), Val(objDataSet.Tables(0).Rows(I).Item("diaspp")), Val(objDataSet.Tables(0).Rows(I).Item("dscto01")), Val(objDataSet.Tables(0).Rows(I).Item("dscto02")), Val(objDataSet.Tables(0).Rows(I).Item("dscto03")), Val(objDataSet.Tables(0).Rows(I).Item("dscto04")), Val(objDataSet.Tables(0).Rows(I).Item("dscto05")), Val(objDataSet.Tables(0).Rows(I).Item("iva"))) = False Then
                                                                MsgBox("Error al generar orden de compra '" & OrdeComp & "'", MsgBoxStyle.Critical, "Error")
                                                                Exit Sub
                                                            End If
                                                        Else
                                                            ' es la siguiente de coqueta

                                                            If Inserta_OrdeComp(OrdeComp, Sucursal, Marca, Proveedor, 0, 8, 0, 0, 0, 0, 0, Val(objDataSet.Tables(0).Rows(I).Item("iva"))) = False Then
                                                                MsgBox("Error al generar orden de compra '" & OrdeComp & "'", MsgBoxStyle.Critical, "Error")
                                                                Exit Sub
                                                            End If
                                                        End If
                                                        ' actualizar folio ordecomp
                                                        If Actualiza_FolioOrdeComp(2, Sucursal, 1) = False Then
                                                            MsgBox("Error al generar orden de compra '" & OrdeComp & "'", MsgBoxStyle.Critical, "Error")
                                                            Exit Sub
                                                        End If
                                                    End If ' DE LA GENERACION DE ORDEN COMPRA CABEZA
                                                    ' DETALLADO DE ORDEN DE CMOPRA
                                                    For J As Integer = 0 To objDataSet1.Tables(0).Rows.Count - 1
                                                        '' grabar detallado... de orden de compra
                                                        Costo = objDataSet1.Tables(0).Rows(J).Item("costo")



                                                        If Sw_MarcaCTA = False Then
                                                            Pcomp = pub_CalcularCostoPedido(Val(objDataSet1.Tables(0).Rows(J).Item("costo")), Val(objDataSet.Tables(0).Rows(I).Item("Dsctopp")), Val(objDataSet.Tables(0).Rows(I).Item("Dscto01")), Val(objDataSet.Tables(0).Rows(I).Item("dscto02")), Val(objDataSet.Tables(0).Rows(I).Item("dscto03")), Val(objDataSet.Tables(0).Rows(I).Item("dscto04")), Val(objDataSet.Tables(0).Rows(I).Item("dscto05")), Val(objDataSet.Tables(0).Rows(I).Item("iva")))
                                                        Else
                                                            Pcomp = pub_CalcularCostoPedido(Val(objDataSet1.Tables(0).Rows(J).Item("costo")), 0, 0, 0, 0, 0, 0, Val(objDataSet.Tables(0).Rows(I).Item("iva")))
                                                        End If

                                                        ' si el ctd es mayor que el lote minimo entonces si pida sino no... 


                                                        If Inserta_Det_Oc(Sucursal, OrdeComp, Marca, objDataSet1.Tables(0).Rows(J).Item("estilon"), objDataSet1.Tables(0).Rows(J).Item("corrida"), objDataSet1.Tables(0).Rows(J).Item("medida"), objDataSet1.Tables(0).Rows(J).Item("ctd"), Costo, Pcomp) = True Then

                                                        End If

                                                    Next
                                                End If '' DEL LOTE MINIMO
                                            End If
                                        End Using
                                    Next

                                End If
                            End Using
                        End If
                        If Marca = "CTA" And Sw_MarcaCTA = False Then
                            '''' LOS DEL TRACK CON PLAZO A 8 DIAS.
                            Sw_MarcaCTA = True
                            Track = 1
                            GoTo Marca_Cta

                        End If
                    Next
                Else
                    MsgBox("No se ha generado ninún resurtido automático.", MsgBoxStyle.Information, "Aviso")

                End If
            End Using


            Me.Cursor = Cursors.Default
            MsgBox("Se han creado '" & Cont & "' Ordenes de Compra.", MsgBoxStyle.Information, "Confirmación")
            Call FechaUltimoResurtido()
            Call RellenaGrid()
            PBar1.Visible = False
            Lbl_Auto.Visible = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Function Inserta_Det_Oc(ByVal Sucursal As String, ByVal OrdeComp As String, ByVal Marca As String, ByVal Estilon As String, ByVal Corrida As String, ByVal Medida As String, ByVal Ctd As Integer, _
                                    ByVal Costo As Decimal, ByVal Pcomp As Decimal) As Boolean
        Dim objDataSet As Data.DataSet
        Using objPedidos As New BCL.BCLPedidos(GLB_ConStringCipSis)
            'Get a new Project DataSet
            Try

                objDataSet = objPedidos.Inserta_Det_oc  'INSERTA NUEVO DATASET
                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow


                objDataRow.Item("sucursal") = Sucursal
                objDataRow.Item("ordecomp") = OrdeComp
                objDataRow.Item("marca") = Marca
                objDataRow.Item("estilon") = Estilon
                objDataRow.Item("corrida") = Corrida

                objDataRow.Item("medida") = Medida

                objDataRow.Item("ctd") = Ctd
                ' objDataRow.Item("costo") = DGrid.Rows(Renglon).Cells("pcomp").Value
                'objDataRow.Item("costdesc") = DGrid.Rows(Renglon).Cells("costo").Value
                objDataRow.Item("costo") = Pcomp
                objDataRow.Item("costdesc") = Costo

                objDataRow.Item("entrega") = Now.Date
                objDataRow.Item("cancela") = Now.Date
                'Add the DataRow to the DataSet
                objDataSet.Tables(0).Rows.Add(objDataRow)

                'Add the Project

                If Not objPedidos.usp_Captura_Det_oc(1, objDataSet) Then
                    Throw New Exception("Falló Inserción de Detalle ")
                End If

                If ActualizarCantSolMedida(Marca, Estilon, Corrida, Medida) Then

                    ' Throw New Exception("Fallo actualización de cantidad solicitada")
                End If

                objDataSet.Dispose()
                objDataRow.Table.Dispose()

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Private Sub Btn_Correo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Correo.Click
        'mreyes 16/Marzo/2012 06:24 p.m.
        If Sw_NoRegistros = False Then Exit Sub
        ' checar permiso
        If Sw_Costos = False Then
            MsgBox("No tiene permiso para realizar este proceso.", MsgBoxStyle.Critical, "Permisos")
            Exit Sub
        End If


        '' PRIMERO TIENE QUE GENERAR EL ID DOCTO PARA GRABAR EN DOCTOS_CP
        Try
            Dim Cont As Integer = 0

            If MsgBox("Esta seguro de generar el archivo digital de la orden de compra seleccionada y enviar por correo al proveedor.. Este proceso puede durar varios minutos. ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub
            Me.Cursor = Cursors.WaitCursor
            Dim ResurtSN As String = "S"

            If Sw_PedidoNuevo = True Then
                ResurtSN = "N"
            Else
                ResurtSN = "S"
            End If

            For Each row As DataGridViewRow In DGrid.Rows
                If row.Cells("Selec").Value = True Then
                    If row.Cells("status").Value <> "ZC" And row.Cells("importe").Value > 0 Then

                        Dim myForm As New frmCatalogoPedidoNuevo

                        Sw_Boton = True
                        myForm.Accion = 4
                        myForm.Sw_SoloPasoPDF = True
                        myForm.Txt_Sucursal.Text = row.Cells("sucursal").Value.ToString.Trim()
                        myForm.Txt_OrdeComp.Text = row.Cells("ordecomp").Value.ToString.Trim()


                        myForm.MdiParent = BitacoraMain

                        myForm.Show()
                        myForm.Close()
                        myForm.Dispose()


                        Dim Marca = Mid(row.Cells("marca").Value.ToString, 1, 3)
                        Dim Anio As String = Format(CDate(row.Cells("fecha").Value.ToString.Trim()), "yyyy")
                        Dim Mes As String = Format(CDate(row.Cells("fecha").Value.ToString.Trim()), "MMMM").ToUpper
                        Dim Tipo As String = "Proveedor"
                        Dim NombrePedido As String = Marca & "_" & row.Cells("sucursal").Value.ToString.Trim() & row.Cells("ordecomp").Value.ToString & "_Prov.pdf"
                        Dim IdEmpleadoB As Integer = 0

                        ' Ir a traer de quien es la asignación de la marca, para compras y enviar el correo.
                        Using objMarca As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
                            Dim objDatasetE As Data.DataSet

                            objDatasetE = objMarca.usp_TraerMarca(Marca, "")
                            If objDatasetE.Tables(0).Rows.Count > 0 Then
                                IdEmpleadoB = (objDatasetE.Tables(0).Rows(0).Item("idempleado").ToString)

                            End If
                        End Using

                        Using objPersis As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)

                            Try
                                'Get the specific project selected in the ListView control
                                objDataSet = objPersis.usp_TraerCorreoNomina(IdEmpleadoB)
                                If objDataSet.Tables(0).Rows.Count > 0 Then
                                    GLB_CorreoCompras = objDataSet.Tables(0).Rows(0).Item("email").ToString
                                    GLB_PassCorreoCompras = objDataSet.Tables(0).Rows(0).Item("passemail").ToString

                                End If

                            Catch ExceptionErr As Exception
                                MessageBox.Show(ExceptionErr.Message.ToString)
                            End Try
                        End Using

                        '"RESURTIDO AUTOMÁTICO NOCTURNO"
                        If row.Cells("observa").Value = "RESURTIDO AUTOMÁTICO NOCTURNO" Then
                            GLB_CorreoCompras = GLB_CorreoResurtidoCompras
                            GLB_PassCorreoCompras = GLB_PassCorreoResurtidoCompras
                        End If

                        RutaArchivoCorreo = GLB_RutaArchivoDigitalPedidos & "\" & IIf(ResurtSN = "N", "Nuevos", "Resurtido") & "\" & Marca & "\" & Anio & "\" & Mes & "\" & Tipo & "\" & NombrePedido
                            If EnviarCorreo(row.Cells("ordecomp").Value.ToString, False, row.Cells("email01").Value.ToString, row.Cells("email02").Value.ToString, row.Cells("proveedor").Value.ToString) = False Then
                                ''MsgBox("Correo no enviado.", MsgBoxStyle.Critical, "Error al enviar")
                            Else
                                If Inserta_SigBit("1900-01-01", "1900-01-01", row.Cells("ordecomp").Value.ToString, row.Cells("sucursal").Value.ToString, Marca, row.Cells("email01").Value.ToString) = False Then

                                End If
                                '' Enviar correo a Compras
                                If EnviarCorreo(row.Cells("ordecomp").Value.ToString, True, row.Cells("email01").Value.ToString, row.Cells("email02").Value.ToString, row.Cells("proveedor").Value.ToString) = False Then

                                End If
                                Cont = Cont + 1
                                ''  MsgBox("Correo enviado con éxito.", MsgBoxStyle.Information, "Confirmación")
                            End If
                        End If
                    End If ' del microsip 
            Next

            Me.Cursor = Cursors.Default
            MsgBox("Se han enviado '" & Cont & "' Archivos de Pedido.", MsgBoxStyle.Information, "Confirmación")
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Function EnviarCorreo(ByVal OrdeComp As String, ByVal Sw_Compras As Boolean, ByVal Email01 As String, ByVal Email02 As String, ByVal Proveedor As String) As Boolean
        Try
            'mreyes 28/Febrero/2012 04:45 p.m.
            Dim Correos As String
            Dim Asunto As String
            Dim Mensaje As String

            If Email01.Length = 0 Then
                EnviarCorreo = False

                Exit Function
            End If

            Correos = Email01
            If Email02.Length > 0 Then
                Correos = Correos & "," & Email02
            End If
            Asunto = "Zapaterías Torreón, Orden de Compra '" & OrdeComp & "'"
            If Sw_Compras = False Then
                Mensaje = "SE ADJUNTA ARCHIVO CON INFORMACIÓN DE ORDEN DE COMPRA '" & OrdeComp & "' CUALQUIER DUDA O ACLARACIÓN, ESTAMOS A SUS ORDENES."
            Else
                Mensaje = "SE HA ENVIADO LA ORDEN DE COMPRA '" & OrdeComp & "' AL CORREO '" & Email01 & "' PARA EL PROVEEDOR '" & Proveedor & "'."
                Correos = GLB_CorreoCompras
            End If



            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)
                If Sw_Compras = True Then
                    objIO.pub_EnviarCorreo(GLB_SmtpClient, GLB_CorreoCompras, GLB_PassCorreoCompras, Correos, Asunto, Mensaje, "")

                Else
                    objIO.pub_EnviarCorreo(GLB_SmtpClient, GLB_CorreoCompras, GLB_PassCorreoCompras, Correos, Asunto, Mensaje, RutaArchivoCorreo)
                End If
            End Using

            EnviarCorreo = True

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function
    Function Inserta_SigBit(ByVal FechaEntrega As Date, ByVal FechaEntregaNew As Date, ByVal OrdeComp As String, ByVal Sucursal As String, _
                                ByVal Marca As String, ByVal Email01 As String) As Boolean
        'mreyes 22/Marzo/2012 11:24 a.m.

        Using objSigBit As New BCL.BCLBitacora(GLB_ConStringCipSis)
            'Get a new Project DataSet
            Try
                objDataSet = objSigBit.Inserta_SigBit
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow

                'Set the values in the DataRow
                objDataRow.Item("sucursal") = Sucursal
                objDataRow.Item("ordecomp") = OrdeComp
                objDataRow.Item("marca") = Marca
                objDataRow.Item("estilon") = ""
                objDataRow.Item("fecha") = Format(Now.Date, "dd-MM-yyyy")
                If FechaEntrega <> "1900-01-01" Then
                    objDataRow.Item("atiende") = ""
                Else
                    objDataRow.Item("atiende") = Mid(Email01, 1, 100)
                End If
                objDataRow.Item("realiza") = GLB_NomUsuario
                If FechaEntrega <> "1900-01-01" Then
                    objDataRow.Item("motivo") = UCase("Cambio de Fechas de Entrega")
                    objDataRow.Item("comentarios") = UCase("Se modifico Fecha de Entrega ") & FechaEntrega & " a " & FechaEntregaNew
                Else

                    If Sw_PedidoMano = True Then
                        objDataRow.Item("motivo") = UCase("Entrega en mano.")
                    Else
                        objDataRow.Item("motivo") = UCase("Envío de orden de compra vía email")
                    End If
                    objDataRow.Item("comentarios") = UCase("Orden enviada ") & " " & Date.Now '& " " & DateTime.Now.ToLongTimeString
                End If

                'Add the DataRow to the DataSet
                objDataSet.Tables(0).Rows.Add(objDataRow)

                'Add the Project
                If Not objSigBit.usp_Captura_SegBit(1, objDataSet) Then
                    Throw New Exception("Falló Inserción de Proveedor")
                Else
                    Inserta_SigBit = True
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub



    Private Sub Pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub

    Private Sub DGrid_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGrid.ColumnHeaderMouseClick
        Sw_Pintar = True
    End Sub

    Private Sub Btn_EntregaMano_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_EntregaMano.Click
        'mreyes 16/Marzo/2012 06:24 p.m.
        If Sw_NoRegistros = False Then Exit Sub
        ' checar permiso
        If Sw_Costos = False Then
            MsgBox("No tiene permiso para realizar este proceso.", MsgBoxStyle.Critical, "Permisos")
            Exit Sub
        End If


        '' PRIMERO TIENE QUE GENERAR EL ID DOCTO PARA GRABAR EN DOCTOS_CP
        Try
            Dim Cont As Integer = 0

            If MsgBox("Esta seguro de generar el archivo digital de la orden de compra seleccionada y que entregará dicha orden EN MANO. ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub
            Me.Cursor = Cursors.WaitCursor
            Dim ResurtSN As String = "S"
            Sw_PedidoMano = True
            If Sw_PedidoNuevo = True Then
                ResurtSN = "N"
            Else
                ResurtSN = "S"
            End If

            For Each row As DataGridViewRow In DGrid.Rows
                If row.Cells("Selec").Value = True Then
                    If row.Cells("status").Value <> "ZC" And row.Cells("importe").Value > 0 Then

                        Dim myForm As New frmCatalogoPedidoNuevo

                        Sw_Boton = True
                        myForm.Accion = 4
                        myForm.Sw_SoloPasoPDF = True
                        myForm.Txt_Sucursal.Text = row.Cells("sucursal").Value.ToString.Trim()
                        myForm.Txt_OrdeComp.Text = row.Cells("ordecomp").Value.ToString.Trim()


                        myForm.MdiParent = BitacoraMain

                        myForm.Show()
                        myForm.Close()
                        myForm.Dispose()


                        Dim Marca = Mid(row.Cells("marca").Value.ToString, 1, 3)
                        Dim Anio As String = Format(CDate(row.Cells("fecha").Value.ToString.Trim()), "yyyy")
                        Dim Mes As String = Format(CDate(row.Cells("fecha").Value.ToString.Trim()), "MMMM").ToUpper
                        Dim Tipo As String = "Proveedor"
                        Dim NombrePedido As String = Marca & "_" & row.Cells("sucursal").Value.ToString.Trim() & row.Cells("ordecomp").Value.ToString & "_Prov.pdf"


                        RutaArchivoCorreo = GLB_RutaArchivoDigitalPedidos & "\" & IIf(ResurtSN = "N", "Nuevos", "Resurtido") & "\" & Marca & "\" & Anio & "\" & Mes & "\" & Tipo & "\" & NombrePedido
                        ' If EnviarCorreo(row.Cells("ordecomp").Value.ToString, False, row.Cells("email01").Value.ToString, row.Cells("email02").Value.ToString, row.Cells("proveedor").Value.ToString) = False Then
                        ''MsgBox("Correo no enviado.", MsgBoxStyle.Critical, "Error al enviar")
                        'Else
                        If Inserta_SigBit("1900-01-01", "1900-01-01", row.Cells("ordecomp").Value.ToString, row.Cells("sucursal").Value.ToString, Marca, row.Cells("email01").Value.ToString) = False Then

                        End If
                        '' Enviar correo a Mary
                        'If EnviarCorreo(row.Cells("ordecomp").Value.ToString, True, row.Cells("email01").Value.ToString, row.Cells("email02").Value.ToString, row.Cells("proveedor").Value.ToString) = False Then

                        'End If
                        Cont = Cont + 1
                        ''  MsgBox("Correo enviado con éxito.", MsgBoxStyle.Information, "Confirmación")
                        'End If
                    End If
                End If ' del microsip 
            Next
            Sw_PedidoMano = False
            Me.Cursor = Cursors.Default
            MsgBox("Se han entregado '" & Cont & "' Archivos de Pedido.", MsgBoxStyle.Information, "Confirmación")
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ConsultarPDFOriginalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultarPDFOriginalToolStripMenuItem.Click
        Dim psi As New ProcessStartInfo()
        Dim Fecha As Date = "1900-01-01"
        Dim NombrePedido As String = ""
        Dim RutaDestino As String = ""
        psi.UseShellExecute = True

        'RutaArchivoCorreo = GLB_RutaArchivoDigitalPedidos & "\" & IIf(ResurtSN = "N", "Nuevos", "Resurtido") & "\" & Marca & "\" & Anio & "\" & Mes & "\" & Tipo & "\" & NombrePedido
        NombrePedido = Mid(DGrid.Rows(DGrid.CurrentRow.Index).Cells("marca").Value.ToString.Trim(), 1, 3) & "_" & DGrid.Rows(DGrid.CurrentRow.Index).Cells("sucursal").Value.ToString.Trim() & DGrid.Rows(DGrid.CurrentRow.Index).Cells("ordecomp").Value.ToString.Trim() & "_Completo.pdf"
        Fecha = DGrid.Rows(DGrid.CurrentRow.Index).Cells("fecha").Value.ToString.Trim()


        ' Anio = Format(CDate(Txt_Fecha.Text), "yyyy")
        'Mes = Format(CDate(Txt_Fecha.Text), "MMMM").ToUpper
        RutaDestino = GLB_RutaArchivoDigitalPedidos & "\" & IIf(Sw_PedidoNuevo = True, "Nuevos", "Resurtido") & "\" & Mid(DGrid.Rows(DGrid.CurrentRow.Index).Cells("marca").Value.ToString.Trim(), 1, 3) & "\" & Format(CDate(Fecha), "yyyy") & "\" & Format(CDate(Fecha), "MMMM").ToUpper & "\Completo\" & NombrePedido

        Using objIO As New BCL.BCLio(GLB_ConStringCipSis)
            If objIO.pub_ExisteArchivo(RutaDestino) = True Then
                psi.FileName = RutaDestino
                Process.Start(psi)
            Else
                MsgBox("El archivo PDF, no ha sido creado", MsgBoxStyle.Critical, "Aviso Importante")
            End If

        End Using


    End Sub

    Private Sub Btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Imprimir.Click

    End Sub

    Private Sub GenerarTracCoquetaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenerarTracCoquetaToolStripMenuItem.Click
        'mreyes     19/Abril/2016   06:00 p.m.
        Try


            'DGrid.Rows(DGrid.CurrentRow.Index).Cells("sucursal").Value.ToString.Trim() & DGrid.Rows(DGrid.CurrentRow.Index).Cells("ordecomp").Value.ToString.Trim()

            If Mid(DGrid.Rows(DGrid.CurrentRow.Index).Cells("marca").Value.ToString, 1, 3) <> "CTA" Then
                MsgBox("No selecciono un pedido de COQUETA.", MsgBoxStyle.Critical, "ERROR")
                Exit Sub
            End If
            If MsgBox("Esta seguro de querer generar el archivo .txt para TRAC COQUETA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmación") = MsgBoxResult.No Then Exit Sub

            Dim NomArchivo As String = ""

            Dim Linea As String = ""
            Dim Archivo As String = "" '"c:\Prueba\Banamex" & Replace(Replace(Format(Date.Now, "yyyy-MM-dd hh:mm:ss"), "-", ""), ":", "") & ".txt"

            Dim Sku As String = ""
            Dim Ctd As String = ""
            Dim Matriz As String = "3934"
            Dim Sucursal As String = ""
           


            NomArchivo = Format(CDate(FechaFinb), "yyyyMMdd")

            Using objVtas As New BCL.BCLVentas(GLB_ConStringCipSis)
                objDataSet = objVtas.usp_TraerPedidoTrac(DGrid.Rows(DGrid.CurrentRow.Index).Cells("sucursal").Value.ToString.Trim(), DGrid.Rows(DGrid.CurrentRow.Index).Cells("ordecomp").Value.ToString.Trim())
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                Archivo = GLB_RutaTxtCoqueta & DGrid.Rows(DGrid.CurrentRow.Index).Cells("sucursal").Value.ToString.Trim() & DGrid.Rows(DGrid.CurrentRow.Index).Cells("ordecomp").Value.ToString.Trim() & NomArchivo & ".txt"
                Dim sw As New System.IO.StreamWriter(Archivo)
                For i As Integer = 1 To objDataSet.Tables(0).Rows.Count

                    Sku = objDataSet.Tables(0).Rows(i - 1).Item("sku").ToString & ","
                    Ctd = objDataSet.Tables(0).Rows(i - 1).Item("ctd").ToString & ","
                    Matriz = objDataSet.Tables(0).Rows(i - 1).Item("matriz").ToString & ","
                    Sucursal = objDataSet.Tables(0).Rows(i - 1).Item("coqueta").ToString

                  

                    Linea = Sku & Ctd & Matriz & Sucursal
                    sw.WriteLine(Linea)
                Next
                sw.Close()
            End If

            MsgBox("Archivo creado en '" & Archivo, MsgBoxStyle.Information, "Confirmación")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Chk_Observaciones_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_Observaciones.CheckedChanged
        If Chk_Observaciones.Checked = True Then
            DGrid.Columns("observa").Visible = True
        Else
            DGrid.Columns("observa").Visible = False
        End If
    End Sub

    Private Sub DGrid_CellContextMenuStripNeeded(sender As Object, e As DataGridViewCellContextMenuStripNeededEventArgs) Handles DGrid.CellContextMenuStripNeeded

    End Sub

    Private Sub RegistrarSegToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarSegToolStripMenuItem.Click
        'mreyes 01/Marzo/2012 09:29
        Try


            Dim myForm As New frmCatalogoSegBit

            Sw_Boton = True
            myForm.Accion = 1
            myForm.Txt_Sucursal.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("sucursal").Value.ToString.Trim()
            myForm.Txt_OrdeComp.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("ordecomp").Value.ToString.Trim()
            myForm.Txt_Estilon.Text = ""
            myForm.Txt_Marca.Text = Mid(DGrid.Rows(DGrid.CurrentRow.Index).Cells("marca").Value.ToString, 1, 3)
            myForm.Txt_DescripMarca.Text = Mid(DGrid.Rows(DGrid.CurrentRow.Index).Cells("marca").Value.ToString, 7)
            myForm.Txt_Realiza.Text = GLB_Idempleado & "-" & GLB_NomUsuario


            myForm.Txt_Estilon.Enabled = False
            myForm.Txt_Marca.Enabled = False
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

    Private Sub VerSeguimientoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerSeguimientoToolStripMenuItem.Click


        'mreyes 07/Marzo/2012 11:07 a.m.
        Try
            Dim myForm As New frmPpalSeguimientos

            Sw_Boton = True

            myForm.OrdeComInib = DGrid.Rows(DGrid.CurrentRow.Index).Cells("ordecomp").Value.ToString.Trim()
            myForm.OrdeComFinb = DGrid.Rows(DGrid.CurrentRow.Index).Cells("ordecomp").Value.ToString.Trim()

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
End Class