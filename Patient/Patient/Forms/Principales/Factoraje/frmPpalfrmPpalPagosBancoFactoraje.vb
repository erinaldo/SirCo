Public Class frmPpalPagosBancoFactoraje
    'mreyes 29/Julio/2015   11:04 a.m.
    Private objDataSet As Data.DataSet

    Dim Proveedorb As String
    Dim Raz_Socb As String = ""
    Dim Estadob As String = ""
    Dim Ciudadb As String = ""
    Dim Sw_NoRegistros As Boolean = False


    Private Sub frmPpalProveedores_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If

        If e.KeyCode = Keys.F5 Then
            Call Btn_Filtro_Click_1(sender, e)
        End If
    End Sub

    Private Sub frmPpalProveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Call LimpiarBusqueda()
            Call RellenaGrid()
            Call GenerarToolTip()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub GenerarToolTip()
        Try


            ToolTip.SetToolTip(Btn_Nuevo, "Nueva Tarjeta")
            ToolTip.SetToolTip(Btn_Editar, "Editar Tarjeta")
            ToolTip.SetToolTip(Btn_Eliminar, "Eliminar Tarjeta")
            ToolTip.SetToolTip(Btn_Consultar, "Consultar Tarjeta")

            ToolTip.SetToolTip(Btn_Filtro, "Búsqueda Avanzada")

            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
            ToolTip.SetToolTip(Btn_Imprimir, "Imprimir Información")

            ToolTip.SetToolTip(Btn_Salir, "Salir")



        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub RellenaGrid()
        'mreyes 17/Mayo/2012 05:21 p.m.
        Using objTarjetas As New BCL.BCLCatalogoTarjetas(GLB_ConStringCipSis)

            Try
                Me.Cursor = Cursors.WaitCursor
                DGrid.ReadOnly = True
                DGrid.DataSource = Nothing

                objDataSet = objTarjetas.usp_PpalCatalogoBancosFactoraje()
                'Populate the Project Details section
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
                Else
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron Tarjetas que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                    Btn_Editar.Enabled = False
                    Btn_Consultar.Enabled = False
                End If
                Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using


    End Sub
    Private Sub LimpiarBusqueda()

        Proveedorb = ""
        Raz_Socb = ""
        Estadob = ""
        Ciudadb = ""

    End Sub

    Private Sub Btn_Refrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Sub InicializaGrid()
        '' marca, Estilon, Estilof, descripc, familia, linea, proveedor, tipoart, categoria
        'mreyes 31/Octubre/2014 04:18 p.m.
        Try

            DGrid.RowHeadersVisible = False
            'DGrid.Columns(0).HeaderText = "Marca"
            'DGrid.Columns(1).HeaderText = "Descripción"
            'DGrid.Columns(2).HeaderText = "Factor"
            'DGrid.Columns(3).HeaderText = "Resmin"


            '  idbanco, banco, factoraje as comision, dias, limite,
            'saldo, disponible, condicionporc, observaciones, usuario,
            '  claveacceso, idcliente, idusuario

            DGrid.Columns(0).HeaderText = "IdBanco"
            DGrid.Columns(1).HeaderText = "Banco"
            DGrid.Columns(2).HeaderText = "Comisión del Banco"
            DGrid.Columns(3).HeaderText = "Dias"
            DGrid.Columns(4).HeaderText = "Limite"
            DGrid.Columns(5).HeaderText = "Saldo"
            DGrid.Columns(6).HeaderText = "Disponible"
            DGrid.Columns(7).HeaderText = "Condición %"
            DGrid.Columns(8).HeaderText = "Observaciones"
            DGrid.Columns(9).HeaderText = "Usuario"
            DGrid.Columns(10).HeaderText = "Clave Acceso"
            DGrid.Columns(11).HeaderText = "IdCliente"
            DGrid.Columns(12).HeaderText = "IdUsuario"

            DGrid.Columns(9).Visible = False
            DGrid.Columns(10).Visible = False
            DGrid.Columns(11).Visible = False
            DGrid.Columns(12).Visible = False

            DGrid.Columns(4).DefaultCellStyle.Format = "c"
            DGrid.Columns(5).DefaultCellStyle.Format = "c"
            DGrid.Columns(6).DefaultCellStyle.Format = "c"

            DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            DGrid.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


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

    Private Sub Btn_Nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Nuevo.Click
        'Dim myForm As New frmCatalogoTarjetas
        'myForm.Accion = 1
        'myForm.ShowDialog()
        'Call RellenaGrid()
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
        Dim myForm As New frmCatalogoBancosFactoraje

        myForm.Accion = 4
        myForm.IdBancoB = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idbanco").Value.ToString.Trim()
        myForm.Cbo_Banco.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("banco").Value.ToString.Trim()
        myForm.Txt_Comision.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("comision").Value.ToString.Trim()

        myForm.Txt_Dias.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("dias").Value.ToString.Trim()

        myForm.Txt_LimCred.Text = Format(DGrid.Rows(DGrid.CurrentRow.Index).Cells("limite").Value, "c")
        myForm.Txt_Saldo.Text = Format(DGrid.Rows(DGrid.CurrentRow.Index).Cells("saldo").Value, "c")
        myForm.Txt_Disponible.Text = Format(DGrid.Rows(DGrid.CurrentRow.Index).Cells("disponible").Value, "c")


        myForm.Txt_Usuario.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("usuario").Value.ToString.Trim()
        myForm.Txt_ClaveAcceso.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("claveacceso").Value.ToString.Trim()

        myForm.Txt_Observaciones.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("observaciones").Value.ToString.Trim()




        myForm.ShowDialog()
        Call RellenaGrid()
    End Sub

    Private Sub Btn_Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar.Click
        'If Sw_NoRegistros = False Then Exit Sub
        'Dim myForm As New frmCatalogoTarjetas

        'myForm.Accion = 2
        'myForm.Txt_Tarjeta_ID.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells(0).Value.ToString.Trim()
        'myForm.ShowDialog()
        'Call RellenaGrid()
    End Sub

    Private Sub Btn_Filtro_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        Dim myForm As New frmFiltrosProveedor
        myForm.Txt_Raz_Soc.Text = Raz_Socb
        myForm.Cbo_Estado.Text = Estadob
        myForm.Cbo_Ciudad.Text = Ciudadb
        myForm.ShowDialog()
        Raz_Socb = myForm.Txt_Raz_Soc.Text
        Estadob = myForm.Cbo_Estado.Text
        ciudadb = myForm.Cbo_Ciudad.Text

        If myForm.Sw_Filtro = True Then
            Call RellenaGrid()
        End If
    End Sub


    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub

    Private Sub NuevoProveedorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoProveedorToolStripMenuItem.Click
        Call Btn_Nuevo_Click(sender, e)
    End Sub

    Private Sub ModificarProveedorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarProveedorToolStripMenuItem.Click
        Call Btn_Editar_Click(sender, e)
    End Sub

    Private Sub ConsultarProveedorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultarProveedorToolStripMenuItem.Click
        Call Btn_Consultar_Click(sender, e)
    End Sub

    Private Sub Pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub
End Class