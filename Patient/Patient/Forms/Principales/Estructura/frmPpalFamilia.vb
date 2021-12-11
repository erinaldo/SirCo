Public Class frmPpalFamilia
    'mreyes 05/Junio/2012 09:59 a.m.
    Private objDataSet As Data.DataSet

    Dim Proveedorb As String
    Dim Raz_Socb As String = ""
    Dim Estadob As String = ""
    Dim Ciudadb As String = ""
    Dim Sw_NoRegistros As Boolean = False
    Dim CveFamilia As String
    Dim Superior1 As Integer
    Dim Superior2 As Integer


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
            CveFamilia = ""
            Superior1 = 0
            Superior2 = 0
            Call LimpiarBusqueda()
            Call RellenaGrid()
            Call GenerarToolTip()
            NuevoProveedorToolStripMenuItem.Text = "Agregar Linea"
            ConsultarProveedorToolStripMenuItem.Text = "Consultar Familia"
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub GenerarToolTip()
        Try


            ToolTip.SetToolTip(Btn_Nuevo, "Nuevo Departamento")
            ToolTip.SetToolTip(Btn_Editar, "Editar Departamento")
            ToolTip.SetToolTip(Btn_Eliminar, "Eliminar Departamento")
            ToolTip.SetToolTip(Btn_Consultar, "Consultar Departamento")

            ToolTip.SetToolTip(Btn_Filtro, "Búsqueda Avanzada")

            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
            ToolTip.SetToolTip(Btn_Imprimir, "Imprimir Información")

            ToolTip.SetToolTip(Btn_Salir, "Salir")



        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub RellenaGrid()
        'mreyes 04/Junio/2012 10:56 a.m.
        Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)

            Try
                Me.Cursor = Cursors.WaitCursor
                DGrid.ReadOnly = True
                DGrid.DataSource = Nothing

                objDataSet = objCatalogoDeptos.usp_TraerEstFamilia(0, Superior1, Superior2, CveFamilia, 1, "")
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
                    MsgBox("No se encontraron Departamento que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
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
            DGrid.Columns(0).HeaderText = "IdFamilia"
            DGrid.Columns(1).HeaderText = "IdDivisiones"
            DGrid.Columns(2).HeaderText = "CveDivisión"
            DGrid.Columns(3).HeaderText = "División"
            DGrid.Columns(4).HeaderText = "IdDepto"
            DGrid.Columns(5).HeaderText = "CveDepto"
            DGrid.Columns(6).HeaderText = "Depto"
            DGrid.Columns(7).HeaderText = "CveFamilia"
            DGrid.Columns(8).HeaderText = "Familia"

            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            DGrid.Columns(0).Visible = False
            DGrid.Columns(1).Visible = False
            DGrid.Columns(4).Visible = False
            DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

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
        Try
            Dim myForm As New frmCatalogoFamilia
            myForm.Accion = 1
            myForm.ShowDialog()
            Call RellenaGrid()
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
        Try
            If Sw_NoRegistros = False Then Exit Sub
            Dim myForm As New frmCatalogoFamilia

            myForm.Accion = 4
            myForm.Txt_IdFamilia.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idfamilia").Value.ToString.Trim()

            myForm.ShowDialog()
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar.Click
        Try
            If Sw_NoRegistros = False Then Exit Sub
            Dim myForm As New frmCatalogoFamilia

            myForm.Accion = 2
            myForm.Txt_IdFamilia.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idfamilia").Value.ToString.Trim()
            myForm.ShowDialog()
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Filtro_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        Try
            Dim myForm As New frmFiltrosEstructura
            myForm.Txt_CveLinea.Visible = False
            myForm.Txt_CveSubLinea.Visible = False
            myForm.Txt_CveSubSubLinea.Visible = False
            myForm.Txt_CveSubSubSubLinea.Visible = False
            myForm.Txt_DescripLinea.Visible = False
            myForm.Txt_DescripSubLinea.Visible = False
            myForm.Txt_DescripSubSubSubLinea.Visible = False
            myForm.Label4.Visible = False
            myForm.Label3.Visible = False
            myForm.Label6.Visible = False
            myForm.Label5.Visible = False
            myForm.ShowDialog()
            If myForm.Txt_IdDepto.Text.Trim <> "" Then
                Superior1 = CInt(myForm.Txt_IdDepto.Text)
            Else
                Superior1 = 0
            End If
            If myForm.Txt_IdDivisiones.Text.Trim <> "" Then
                Superior2 = CInt(myForm.Txt_IdDivisiones.Text)
            Else
                Superior2 = 0
            End If
            CveFamilia = myForm.Txt_CveFamilia.Text
            If myForm.Sw_Filtro = True Then
                RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub

    Private Sub NuevoProveedorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoProveedorToolStripMenuItem.Click
        Try
            Dim myForm As New frmCatalogoLinea
            myForm.Txt_IdDivisiones.Text = DGrid.CurrentRow.Cells("iddivisiones").Value
            myForm.Txt_CveDivisiones.Text = DGrid.CurrentRow.Cells("cvedivisiones").Value
            myForm.Txt_DescripDivisiones.Text = DGrid.CurrentRow.Cells("divisiones").Value
            myForm.Txt_IdDivisiones.Enabled = False
            myForm.Txt_CveDivisiones.Enabled = False
            myForm.Txt_DescripDivisiones.Enabled = False
            myForm.Txt_IdDepto.Text = DGrid.CurrentRow.Cells("iddepto").Value
            myForm.Txt_Clave.Text = DGrid.CurrentRow.Cells("cvedepto").Value
            myForm.Txt_DescripDepto.Text = DGrid.CurrentRow.Cells("depto").Value
            myForm.Txt_IdDepto.Enabled = False
            myForm.Txt_Clave.Enabled = False
            myForm.Txt_DescripDepto.Enabled = False
            myForm.Txt_IdFamilia.Text = DGrid.CurrentRow.Cells("idfamilia").Value
            myForm.Txt_CveFam.Text = DGrid.CurrentRow.Cells("clave").Value
            myForm.Txt_DescripFam.Text = DGrid.CurrentRow.Cells("descrip").Value
            myForm.Txt_IdFamilia.Enabled = False
            myForm.Txt_CveFam.Enabled = False
            myForm.Txt_DescripFam.Enabled = False
            myForm.Accion = 1
            myForm.Show()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

   

    Private Sub ConsultarProveedorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultarProveedorToolStripMenuItem.Click
        Try
            Call Btn_Consultar_Click(sender, e)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub

    Private Sub DGrid_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DGrid.MouseDown
        Try
            If e.Button = Windows.Forms.MouseButtons.Right Then
                With Me.DGrid
                    Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                    If Hitest.Type = DataGridViewHitTestType.Cell Then
                        .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    End If
                End With
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
End Class