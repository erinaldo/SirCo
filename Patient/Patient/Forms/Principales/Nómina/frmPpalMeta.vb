Public Class frmPpalMeta
    'mreyes 28/Agosto/2012 01:40 p.m.
    Private objDataSet As Data.DataSet
    Public Sw_Registro As Boolean = False
    Public Sw_PedidoNuevo As Boolean = True


    Dim Aniob As Integer = 0
    Dim MesB As Integer = 0
    Dim SucursalB As String = ""
    Dim GrupoArtB As String = ""

    Dim Sw_Load As Boolean = True
    Dim Sw_Boton As Boolean = False
    Dim Sw_NoRegistros As Boolean = False
    Dim FechaUltResurt As Date
    Dim Sw_Pintar As Boolean = False

    Private Sub frmPpalPedidoNuevo_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Sw_Load = True Then
            If Sw_NoRegistros = False Then
                Sw_Load = False
                ''     InicializaGrid()
                'Factura_Microsip()
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
            'Call Btn_Filtro_Click_1(sender, e)
        End If
    End Sub

    Private Sub frmPpalPedidoNuevo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Sw_Load = True
            Sw_Pintar = True
            Call LimpiarBusqueda()
            Call RellenaGrid()
            Call GenerarToolTip()
            Btn_GeneraMetas.Visible = True

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
            ToolTip.SetToolTip(Btn_Salir, "Salir")
            ToolTip.SetToolTip(Btn_GeneraMetas, "Generación de Metas")



        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub RellenaGrid()
        Using objRegistro As New BCL.BCLMeta(GLB_ConStringNomSis)
            Try

                Me.Cursor = Cursors.WaitCursor


                '''' DGrid.ReadOnly = True
                DGrid.DataSource = Nothing
                objDataSet = objRegistro.usp_PpalMeta(aniob, mesb, SucursalB, grupoartb)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section

                    DGrid.DataSource = objDataSet.Tables(0)
                    InicializaGrid()
                    'LimpiarBusqueda()
                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True

                    Sw_NoRegistros = True
                    Sw_Pintar = True
                    DGrid.Rows(0).Selected = True

                Else
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    If Sw_Load = False Then
                        MsgBox("No se encontraron Metas que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    End If
                    Btn_Excel.Enabled = False



                End If

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using


    End Sub
    Private Sub LimpiarBusqueda()
        Aniob = 0
        MesB = 0
        sucursalb = ""
        grupoartb = ""
    End Sub


    Private Sub Btn_Refrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Sub InicializaGrid()
        'mreyes 23/Junio/2012 02:09 p.m.
        Try

            DGrid.RowHeadersVisible = False
            DGrid.Columns(0).HeaderText = "Anio"
            DGrid.Columns(1).HeaderText = "Mes"
            DGrid.Columns(2).HeaderText = "Mes"
            DGrid.Columns(3).HeaderText = "Sucursal"
            DGrid.Columns(4).HeaderText = "Sucursal"

            DGrid.Columns(5).HeaderText = "Grupo"
            DGrid.Columns(6).HeaderText = "Importe Venta"
            DGrid.Columns(7).HeaderText = "Piezas Venta"
            DGrid.Columns(8).HeaderText = "Meta en Piezas"

            DGrid.Columns(1).Visible = False
            DGrid.Columns(3).Visible = False
       
            DGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(7).DefaultCellStyle.Format = "n0"
            DGrid.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns(8).DefaultCellStyle.Format = "n0"
            DGrid.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            DGrid.Columns(6).DefaultCellStyle.Format = "c"
            DGrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


            DGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter




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



    Private Sub DGrid_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGrid.CellFormatting
        Try

            ''mreyes 30/Junio/2012 10:59 a.m.

            'Dim Sw_NoEntro As Boolean = False

            'Dim DiasEntrega As Integer = 0
            'If Sw_Pintar = False Then Exit Sub

            'If Me.DGrid.Columns(e.ColumnIndex).Name <> "Extras" Then Exit Sub
            ' ''If Me.DGrid.Columns(e.ColumnIndex).Name <> "fecha" Then Exit Sub
            'If e.RowIndex >= DGrid.RowCount - 1 Then
            '    If Sw_Load = False Then
            '        Sw_Pintar = False
            '    End If
            '    Exit Sub
            'End If

            'If IsDBNull(DGrid.Rows(e.RowIndex).Cells("Extras").Value) = False Then
            '    If DGrid.Rows(e.RowIndex).Cells("Extras").Value <> "00:00:00" And DGrid.Rows(e.RowIndex).Cells("Extras").Value.ToString.Length > 0 Then
            '        DGrid.Rows(e.RowIndex).Cells("Extras").Style.BackColor = Color.Yellow
            '        DGrid.Rows(e.RowIndex).Cells("Extras").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            '    End If
            'End If
            'If IsDBNull(DGrid.Rows(e.RowIndex).Cells("Retardo").Value) = False Then
            '    If DGrid.Rows(e.RowIndex).Cells("Retardo").Value <> "00:00:00" And DGrid.Rows(e.RowIndex).Cells("Extras").Value.ToString.Length > 0 Then
            '        DGrid.Rows(e.RowIndex).Cells("Retardo").Style.BackColor = Color.Red
            '        DGrid.Rows(e.RowIndex).Cells("Retardo").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            '    End If
            'End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Nuevo_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Nuevo.Click
        Dim myForm As New frmCatalogoMetas
        myForm.Accion = 1
        myForm.ShowDialog()
        If GLB_RefrescarPedido = True Then
            Call RellenaGrid()
        End If
    End Sub

    Private Sub Btn_Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar.Click
        If Sw_NoRegistros = False Then Exit Sub
        Dim myForm As New frmCatalogoMetas

        If DGrid.Rows(DGrid.CurrentRow.Index).Cells("MES").Value <> Month(GLB_FechaHoy) Then
            MsgBox("No puede modificar la meta seleccionada.", MsgBoxStyle.Critical, "Aviso")
            Exit Sub
        Else
            If DGrid.Rows(DGrid.CurrentRow.Index).Cells("anio").Value <> Year(GLB_FechaHoy) Then
                MsgBox("No puede modificar la meta seleccionada.", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If
        End If

        myForm.Accion = 2
        myForm.GrupoB = Mid(DGrid.Rows(DGrid.CurrentRow.Index).Cells("grupo").Value.ToString.Trim(), 1, 1)
        If myForm.GrupoB = "C" Then
            myForm.Txt_Meta.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("pares").Value
        Else
            myForm.Txt_MetaA.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("pares").Value
        End If
        myForm.Txt_Anio.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("anio").Value
        myForm.Cbo_Mes.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("MESLARGO").Value
        myForm.Txt_DescripSucursal.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("descripsucursal").Value
        myForm.Txt_Sucursal.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("sucursal").Value


        myForm.ShowDialog()
        If GLB_RefrescarPedido = True Then
            Call RellenaGrid()
        End If
    End Sub

    Private Sub Btn_Consultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Consultar.Click
        If Sw_NoRegistros = False Then Exit Sub
        Dim myForm As New frmCatalogoMetas
        myForm.Accion = 3
        myForm.GrupoB = Mid(DGrid.Rows(DGrid.CurrentRow.Index).Cells("grupo").Value.ToString.Trim(), 1, 1)
        If myForm.GrupoB = "C" Then
            myForm.Txt_Meta.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("pares").Value
        Else
            myForm.Txt_MetaA.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("pares").Value
        End If
        myForm.Txt_Anio.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("anio").Value
        myForm.Cbo_Mes.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("MESLARGO").Value
        myForm.Txt_DescripSucursal.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("descripsucursal").Value
        myForm.Txt_Sucursal.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("sucursal").Value


        myForm.ShowDialog()
        If GLB_RefrescarPedido = True Then
            Call RellenaGrid()
        End If
    End Sub



    Private Sub DGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick
        Call Btn_Consultar_Click(sender, e)
    End Sub

    Private Sub Pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub

    Private Sub Btn_GeneraMetas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_GeneraMetas.Click
        'mreyes 09/Septiembre/2012 01:51 p.m.
        Dim myForm As New frmCatalogoMetas
        myForm.Sw_CorrerCalculo = True
        myForm.ShowDialog()
        Call RellenaGrid()
    End Sub

    Private Sub Btn_Filtro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        Dim myForm As New frmCatalogoMetas
        myForm.Txt_Anio.Text = IIf(Aniob = 0, "", Aniob)
        myForm.Cbo_Mes.Text = IIf(MesB = 0, "", MesB)

        myForm.ShowDialog()

        Aniob = myForm.Txt_Anio.Text

        Call RellenaGrid()
    End Sub

    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub
End Class