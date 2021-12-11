Public Class frmppalproveeBita

    Private objDataSet As Data.DataSet

    Dim Idusuariob As Integer = 0
    Dim Proveedorb As String = ""
    Dim Raz_Socb As String = ""
    Dim marcab As String = ""
    Dim comentariob As String = ""
    Dim fecha As String = "1900-01-01"
    Dim Sw_NoRegistros As Boolean = False
    Dim blnCondiciones As Boolean = False
    Dim TipoB As String = ""
    Dim AceptaFactorajeb As Integer = 0
    Dim FactRemB As Integer = 0

    Private Sub frmPpalProveedores_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If

        If e.KeyCode = Keys.F5 Then
            'Call Btn_Filtro_Click_1(sender, e)
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


            ToolTip.SetToolTip(Btn_Nuevo, "Nuevo Proveedor")
            ToolTip.SetToolTip(Btn_Editar, "Editar Proveedor")
            ToolTip.SetToolTip(Btn_Eliminar, "Eliminar Proveedor")
            ToolTip.SetToolTip(Btn_Consultar, "Consultar Proveedor")

            ToolTip.SetToolTip(Btn_Filtro, "Búsqueda Avanzada")

            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")


            ToolTip.SetToolTip(Btn_Salir, "Salir")



        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub RellenaGrid()
        'mreyes 28/Febrero/2012 01:41 p.m.
        Using objProveedores As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoAppSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                DGrid.ReadOnly = True
                DGrid.DataSource = Nothing

                objDataSet = objProveedores.usp_PpalCatalogoProveeBita(0, Proveedorb, marcab, fecha, comentariob, Idusuariob)
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
                    MsgBox("No se encontraron Proveedores que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
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

        'Proveedorb = ""
        'Raz_Socb = ""
        'comentariob = ""
        'marcab = ""

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
        'mreyes 17/Febrero/2011 11:02 p.m.
        Try

            DGrid.RowHeadersVisible = False
            DGrid.Columns(0).HeaderText = "Proveedor"
            DGrid.Columns(1).HeaderText = "Raz_suc"
            DGrid.Columns(2).HeaderText = "Marca"
            DGrid.Columns(3).HeaderText = "Fecha"
            DGrid.Columns(4).HeaderText = "Comentario"
            DGrid.Columns(5).HeaderText = "Id_Usuario"


            DGrid.Columns(5).Visible = False
            DGrid.Columns(1).Visible = False



            ' For i As Integer = 0 To DGrid.Columns.Count - 1
            'DGrid.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            ' Next
            DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.

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
        Dim myForm As New frmCatalogoProveeBita
        myForm.Accion = 1
        myForm.fecha = myForm.DT_Fecha.Value
        myForm.MdiParent = BitacoraMain
        myForm.Show()
        ' myForm.ShowDialog()
        'If myForm.Sw_Registro = True Then
        Call RellenaGrid()
        'End If
    End Sub

    Private Sub DGrid_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGrid.CellFormatting

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

    Private Sub Btn_Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar.Click
        If Sw_NoRegistros = False Then Exit Sub
        Dim myForm As New frmCatalogoProveeBita

        myForm.Accion = 2
        myForm.Txt_provee.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("proveedor").Value.ToString.Trim()
        myForm.Txt_Marc.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("marca").Value.ToString.Trim()
        myForm.fecha = DGrid.Rows(DGrid.CurrentRow.Index).Cells("fecha").Value.ToString.Trim()

        myForm.MdiParent = BitacoraMain
        myForm.Show()
        'myForm.ShowDialog()
        If myForm.Sw_Registro = True Then
            Call RellenaGrid()
        End If
    End Sub
    'Private Sub Btn_Filtro_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
    '    Dim myForm As New frmFiltrosProveedor
    '    myForm.Txt_Proveedor.Text = Proveedorb
    '    myForm.Txt_Raz_Soc.Text = Raz_Socb
    '    myForm.Cbo_Estado.Text = Estadob
    '    myForm.Cbo_Ciudad.Text = Ciudadb
    '    myForm.Txt_Marca.Text = MarcaB

    '    myForm.Cbo_Tipo.Text = TipoB

    '    If EstatusB = "AC" Then
    '        myForm.Cbo_Estatus.Text = "ACTIVO"
    '    ElseIf EstatusB = "BA" Then
    '        myForm.Cbo_Estatus.Text = "BAJA"
    '    ElseIf EstatusB = "SU" Then
    '        myForm.Cbo_Estatus.Text = "SUSPENDIDO"
    '    Else
    '        myForm.Cbo_Estatus.Text = ""
    '    End If

    '    If AceptaFactorajeb = 0 Then
    '        myForm.Chk_Factoraje.Checked = False
    '    Else
    '        myForm.Chk_Factoraje.Checked = True
    '    End If

    '    If FactRemB = 0 Then
    '        myForm.Chk_FactRem.Checked = False
    '    Else
    '        myForm.Chk_FactRem.Checked = True
    '    End If
    '    myForm.ShowDialog()
    '    Proveedorb = myForm.Txt_Proveedor.Text
    '    Raz_Socb = myForm.Txt_Raz_Soc.Text
    '    Estadob = myForm.Cbo_Estado.Text
    '    Ciudadb = myForm.Cbo_Ciudad.Text
    '    MarcaB = myForm.Txt_Marca.Text
    '    TipoB = myForm.Cbo_Tipo.Text

    '    EstatusB = Mid(myForm.Cbo_Estatus.Text, 1, 2)


    '    If myForm.Chk_Factoraje.Checked = False Then
    '        AceptaFactorajeb = 0
    '    Else
    '        AceptaFactorajeb = 1
    '    End If

    '    If myForm.Chk_FactRem.Checked = False Then
    '        FactRemB = 0
    '    Else
    '        FactRemB = 1
    '    End If


    '    If myForm.Sw_Filtro = True Then
    '        Call RellenaGrid()
    '    End If
    'End Sub
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
    'Private Sub Chk_Condiciones_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Chk_Condiciones.Checked = True Then
    '        blnCondiciones = True
    '    ElseIf Chk_Condiciones.Checked = False Then
    '        blnCondiciones = False
    '    End If

    '    Call RellenaGrid()
    'End Sub

    'Private Sub DGrid_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DGrid.MouseDown
    '    Try
    '        If e.Button = Windows.Forms.MouseButtons.Right Then
    '            With Me.DGrid
    '                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
    '                If Hitest.Type = DataGridViewHitTestType.Cell Then
    '                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
    '                End If
    '            End With
    '        End If
    '    Catch ExceptionErr As Exception
    '        MessageBox.Show(ExceptionErr.Message.ToString)
    '    End Try
    'End Sub

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click

    End Sub

    Private Sub Btn_Filtro_Click(sender As Object, e As EventArgs) Handles Btn_Filtro.Click

    End Sub

    Private Sub Btn_Consultar_Click(sender As Object, e As EventArgs) Handles Btn_Consultar.Click
        If Sw_NoRegistros = False Then Exit Sub
        Dim myForm As New frmCatalogoProveeBita

        myForm.Accion = 4
        myForm.Txt_provee.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("proveedor").Value.ToString.Trim()
        myForm.Txt_Marc.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("marca").Value.ToString.Trim()
        myForm.DT_Fecha.Value = DGrid.Rows(DGrid.CurrentRow.Index).Cells("fecha").Value.ToString.Trim()
        myForm.fecha = myForm.DT_Fecha.Value
        myForm.MdiParent = BitacoraMain
        myForm.Show()
        'myForm.ShowDialog()

        If myForm.Sw_Registro = True Then
            Call RellenaGrid()
        End If
    End Sub

    Private Sub DGrid_MouseHover(sender As Object, e As EventArgs) Handles DGrid.MouseHover

    End Sub

    Private Sub Btn_Imprimir_Click(sender As Object, e As EventArgs)

    End Sub
End Class