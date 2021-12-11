Public Class frmPpalPercDeduc
    'mreyes 08/Junio/2012 12:18 p.m.
    Private objDataSet As Data.DataSet

    Dim Proveedorb As String
    Dim Raz_Socb As String = ""
    Dim Estadob As String = ""
    Dim Ciudadb As String = ""
    Dim Sw_NoRegistros As Boolean = False
    Dim Sw_Load As Boolean = True
    Dim Sw_Pintar As Boolean = False

    Private Sub frmPpalPercDeduc_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Sw_Load = True Then
            If Sw_NoRegistros = False Then
                Sw_Load = False
            Else
                Sw_Load = False
            End If
        End If
    End Sub

    Private Sub frmPpalPercDeduc_BackgroundImageChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.BackgroundImageChanged

    End Sub


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
            Sw_Pintar = True
            Sw_Load = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub GenerarToolTip()
        Try

            ToolTip.SetToolTip(Btn_Nuevo, "Nuevo Concepto")
            ToolTip.SetToolTip(Btn_Editar, "Editar Concepto")
            ToolTip.SetToolTip(Btn_Eliminar, "Eliminar Concepto")
            ToolTip.SetToolTip(Btn_Consultar, "Consultar Concepto")
            ToolTip.SetToolTip(Btn_Filtro, "Búsqueda Avanzada")
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
            ToolTip.SetToolTip(Btn_Imprimir, "Imprimir Información")
            ToolTip.SetToolTip(Btn_Salir, "Salir")



        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub RellenaGrid()
        'mreyes 05/Junio/2012 12:08 p.m.
        Using objCatalogo As New BCL.BCLCatalogoPercDeduc(GLB_ConStringNomSis)

            Try
                Me.Cursor = Cursors.WaitCursor
                DGrid.ReadOnly = True
                DGrid.DataSource = Nothing

                objDataSet = objCatalogo.usp_PpalCatalogoPercDeduc(0, "", "", "", "", "", "", "", "")
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
                    Sw_Pintar = True
                Else
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron Conceptos que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
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
        'mreyes 17/Febrero/2011 11:02 p.m.
        Try

            DGrid.RowHeadersVisible = False
            DGrid.Columns(0).HeaderText = "IdPercDeduc"
            DGrid.Columns(1).HeaderText = "Clave"
            DGrid.Columns(2).HeaderText = "Naturaleza"
            DGrid.Columns(3).HeaderText = "Descripción Corta "
            DGrid.Columns(4).HeaderText = "Descripción Larga"
            DGrid.Columns(5).HeaderText = "Rep"
            DGrid.Columns(6).HeaderText = "TipoNom"
            DGrid.Columns(7).HeaderText = "Estatus"
            DGrid.Columns(8).HeaderText = "Tienda"


            DGrid.Columns(0).Visible = False

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
        Dim myForm As New frmCatalogoPercDeduc
        myForm.Accion = 1
        myForm.ShowDialog()
        Call RellenaGrid()
    End Sub

    Private Sub DGrid_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGrid.CellFormatting
        Try

            'mreyes 15/Junio/2012 05:09 p.m.

            Dim Sw_NoEntro As Boolean = False

            Dim DiasEntrega As Integer = 0
            If Sw_Pintar = False Then Exit Sub

            If Me.DGrid.Columns(e.ColumnIndex).Name <> "naturaleza" Then Exit Sub
            ''If Me.DGrid.Columns(e.ColumnIndex).Name <> "fecha" Then Exit Sub
            If e.RowIndex >= DGrid.RowCount - 1 Then
                If Sw_Load = False Then
                    Sw_Pintar = False
                End If
                Exit Sub
            End If

            If DGrid.Rows(e.RowIndex).Cells("naturaleza").Value = "PERCEPCIÓN" Then
                DGrid.Rows(e.RowIndex).Cells("naturaleza").Style.BackColor = Color.Yellow
                DGrid.Rows(e.RowIndex).Cells("naturaleza").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

            End If
            If DGrid.Rows(e.RowIndex).Cells("naturaleza").Value = "DEDUCCIÓN" Then
                DGrid.Rows(e.RowIndex).Cells("naturaleza").Style.BackColor = Color.Red
                DGrid.Rows(e.RowIndex).Cells("naturaleza").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

            End If
  

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
        Dim myForm As New frmCatalogoPercDeduc

        myForm.Accion = 4
        myForm.Txt_IdPercdeduc.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells(0).Value.ToString.Trim()

        myForm.ShowDialog()
        Call RellenaGrid()
    End Sub

    Private Sub Btn_Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar.Click
        If Sw_NoRegistros = False Then Exit Sub
        Dim myForm As New frmCatalogoPercDeduc

        myForm.Accion = 2
        myForm.Txt_IdPercdeduc.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells(0).Value.ToString.Trim()
        myForm.ShowDialog()
        Call RellenaGrid()
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