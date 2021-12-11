Public Class frmPpalSeguimientos
    'mreyes 07/Marzo/2012 10:03 a.m.
    Private objDataSet As Data.DataSet
    Dim Marcab As String = ""
    Dim Estilonb As String = ""
    Dim Estilofb As String = ""
    Dim Proveedorb As String = ""
    Dim Sucursalb As String = ""
    Dim OrdeCompb As String = ""
    Dim FechaInib As String = "1900-01-01"
    Dim FechaFinb As String = "1900-01-01"
    Public OrdeComInib As String = ""
    Public OrdeComFinb As String = ""

    Public Sw_Load As Boolean = False
    Dim Sw_Boton As Boolean = False
    Dim Opcion As Integer = 1  '' 2 = proveedor , 3 = marca 
    Dim Sw_NoRegistros As Boolean = False




    Private Sub frmPpalSeguimientos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If

        If e.KeyCode = Keys.F5 Then
            Call Btn_Filtro_Click_1(sender, e)
        End If
    End Sub

    Private Sub frmPpalSeguimientos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ''Sw_Load = True
            ' Call LimpiarBusqueda()
            If Sw_Load = True Then
                FechaInib = Format(Now.Date, "yyyy-MM-dd")
                FechaFinb = Format(Now.Date, "yyyy-MM-dd")
            End If
            Call RellenaGrid()
            Call GenerarToolTip()

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


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub RellenaGrid()
        'mreyes 07/Marzo/2012 10:18 a.m.
        Using objBitacora As New BCL.BCLBitacora(GLB_ConStringCipSis)
            Try
                Me.Cursor = Cursors.WaitCursor


                DGrid.ReadOnly = True
                DGrid.DataSource = Nothing
                objDataSet = objBitacora.usp_PpalSeguimientos(Sucursalb, OrdeComInib, OrdeComFinb, Marcab, Estilonb, Estilofb, _
                                                                    Proveedorb, FechaInib, _
                                                                    FechaFinb)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section
                    DGrid.Visible = False
                    DGrid.DataSource = objDataSet.Tables(0)
                    DGrid.Visible = True
                    InicializaGrid()
                    If Opcion = 1 Then
                        BarrerGrid()

                    End If
                    'LimpiarBusqueda()
                    Me.Cursor = Cursors.Default
                    Sw_NoRegistros = True
                Else
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron Seguimientos que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                End If

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using


    End Sub
    Private Sub BarrerGrid()
        'mreyes 07/Marzo/2012 12:33 p.m.

        '' traer fecha de entrega yyyyyyyyyyyyyyyyyyyyyyyyyyyy eliminar columnas de estilon y estilof sino se requiere
        Try
            Dim Sw_QuitarColumnas As Boolean = True
            DGrid.Visible = False
            For i As Integer = 0 To DGrid.RowCount - 2
                If IsDBNull(DGrid.Rows(i).Cells(6).Value) Then
                    Using objBitacora As New BCL.BCLBitacora(GLB_ConStringCipSis)
                        objDataSet = objBitacora.usp_TraerFechaEntrega(DGrid.Rows(i).Cells(2).Value, DGrid.Rows(i).Cells(3).Value)
                        If objDataSet.Tables(0).Rows.Count > 0 Then
                            DGrid.Rows(i).Cells(6).Value = objDataSet.Tables(0).Rows(0).Item("entrega").ToString
                        End If
                    End Using
                End If

                If DGrid.Rows(i).Cells(5).Value <> "" Then
                    Sw_QuitarColumnas = False
                    Using objBitacora As New BCL.BCLBitacora(GLB_ConStringCipSis)
                        objDataSet = objBitacora.usp_TraerEstiloF(DGrid.Rows(i).Cells(0).Value, DGrid.Rows(i).Cells(5).Value)
                        If objDataSet.Tables(0).Rows.Count > 0 Then
                            DGrid.Rows(i).Cells(4).Value = objDataSet.Tables(0).Rows(0).Item("estilof").ToString
                        End If
                    End Using

                End If
            Next
            If Sw_QuitarColumnas = True Then
                DGrid.Columns(4).Visible = False
                DGrid.Columns(5).Visible = False
            End If
            DGrid.Visible = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub LimpiarBusqueda()
        'mreyes 07/Marzo/2012 10:37 a.m.
        Marcab = ""
        Estilonb = ""
        Estilofb = ""
        Proveedorb = ""
        Sucursalb = ""
        OrdeCompb = ""
        FechaInib = "1900-01-01"
        FechaFinb = "1900-01-01"
        OrdeComInib = ""
        OrdeComFinb = ""
    End Sub


    Sub InicializaGrid()

        'mreyes 07/Marzo/2011 10:37 a.m.
        Try
            DGrid.RowHeadersVisible = False

            DGrid.Columns(0).HeaderText = "Marca"
            DGrid.Columns(1).HeaderText = "Proveedor"
            DGrid.Columns(2).HeaderText = "Sucursal"
            DGrid.Columns(3).HeaderText = "OrdeComp"
            DGrid.Columns(4).HeaderText = "Estilo Fábrica"
            DGrid.Columns(5).HeaderText = "Estilo Nuestro"
            DGrid.Columns(6).HeaderText = "Fecha Entrega"
            DGrid.Columns(7).HeaderText = "Fecha Seg"
            DGrid.Columns(8).HeaderText = "Atiende"
            DGrid.Columns(9).HeaderText = "Realiza"
            DGrid.Columns(10).HeaderText = "Motivo"
            DGrid.Columns(11).HeaderText = "Comentarios"
            DGrid.Columns(12).HeaderText = "Id_SegBit"



            'DGrid.Columns(0).Visible = False
            DGrid.Columns(1).Visible = False
            DGrid.Columns(2).Visible = False
            DGrid.Columns(12).Visible = False

            DGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

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

    Private Sub DGrid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellDoubleClick
        'mreyes 02/Marzo/2011 10:14 a.m.
        Try
            If Opcion = 1 Then '' es estilo
                Dim myForm As New frmCatalogoSegBit



                Sw_Boton = True
                myForm.Accion = 4

                myForm.Txt_Sucursal.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells(2).Value.ToString.Trim()
                myForm.Txt_OrdeComp.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells(3).Value.ToString.Trim()
                myForm.Txt_Estilon.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells(5).Value.ToString
                myForm.Txt_Marca.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells(0).Value.ToString
                myForm.Txt_Id_SegBit.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells(12).Value.ToString
                myForm.WindowState = FormWindowState.Normal
                myForm.Refresh()
                myForm.ShowDialog()
            End If


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub Btn_Filtro_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        Dim myForm As New frmFiltrosSeguimientos
        'mreyes 07/Marzo/2012 10:08 p.m.
        Try
            '' mandar datos de consulta 
            myForm.Txt_Marca.Text = Marcab
            myForm.Txt_Estilon.Text = Estilonb
            myForm.Txt_Estilof.Text = Estilofb

            myForm.Txt_OrdeComp1.Text = OrdeComInib
            myForm.Txt_OrdeComp2.Text = OrdeComFinb
            If FechaInib <> "1900-01-01" Then
                myForm.Chk_FechaOrden.Checked = True
                myForm.DTPicker2.Value = FechaInib
                myForm.DTPicker3.Value = FechaFinb
            End If


            myForm.Text = "Filtros Bitácora"
            myForm.ShowDialog()
            Marcab = myForm.Txt_Marca.Text
            Estilonb = myForm.Txt_Estilon.Text
            Estilofb = myForm.Txt_Estilof.Text

            If myForm.Chk_FechaOrden.Checked = True Then
                FechaInib = Format(myForm.DTPicker2.Value, "yyyy-MM-dd")
                FechaFinb = Format(myForm.DTPicker3.Value, "yyyy-MM-dd")
            Else
                FechaInib = "1900-01-01"
                FechaFinb = "1900-01-01"

            End If
            OrdeComInib = myForm.Txt_OrdeComp1.Text
            OrdeComFinb = myForm.Txt_OrdeComp2.Text
            If myForm.Sw_Filtro = True Then
                Call RellenaGrid()
            End If
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
            'myForm.Txt_Sucursal.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells(2).Value.ToString.Trim()
            'myForm.Txt_OrdeComp.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells(3).Value.ToString.Trim()
            'myForm.Txt_Estilon.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells(6).Value.ToString
            'myForm.Txt_Marca.Text = Mid(DGrid.Rows(DGrid.CurrentRow.Index).Cells(0).Value.ToString, 1, 3)
            'myForm.Txt_DescripMarca.Text = Mid(DGrid.Rows(DGrid.CurrentRow.Index).Cells(0).Value.ToString, 7)
            'myForm.Txt_OrdeComp.ReadOnly = True

            myForm.WindowState = FormWindowState.Normal
            myForm.Refresh()
            myForm.ShowDialog()
            'Call RellenaGrid()
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
        'mreyes 01/Marzo/2012 05:37 p.m.
        Dim myForm As New frmCatalogoPedidoNuevo
        If Opcion <> 1 Then Exit Sub

        Sw_Boton = True
        myForm.Accion = 2
        myForm.Txt_Sucursal.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells(2).Value.ToString.Trim()
        myForm.Txt_OrdeComp.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells(3).Value.ToString.Trim()
        myForm.Sw_Bitacora = True
        myForm.MdiParent = BitacoraMain
        myForm.Show()
        ' Call RellenaGrid()
    End Sub



    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub

    Private Sub CMenu_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMenu.Opening
        If Opcion <> 1 Then
            RegistrarSegToolStripMenuItem.Enabled = False

            VerProveedorToolStripMenuItem.Enabled = False

        End If
        If DGrid.Rows(DGrid.CurrentRow.Index).Cells(0).Value.ToString = "" Then
            RegistrarSegToolStripMenuItem.Enabled = False

            VerProveedorToolStripMenuItem.Enabled = False

        End If
    End Sub

    Private Sub Btn_Foto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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

    Private Sub ImagenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
End Class