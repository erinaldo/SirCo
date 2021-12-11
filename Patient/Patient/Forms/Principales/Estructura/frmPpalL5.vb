Public Class frmPpalL5
    'mreyes 05/Junio/2012 09:59 a.m.
    Private objDataSet As Data.DataSet

    Dim Proveedorb As String
    Dim Raz_Socb As String = ""
    Dim Estadob As String = ""
    Dim Ciudadb As String = ""
    Dim Sw_NoRegistros As Boolean = False
    Dim CveSubSubSubSubSubLinea As String
    Dim Superior1 As Integer
    Dim Superior2 As Integer
    Dim Superior3 As Integer
    Dim Superior4 As Integer
    Dim Superior5 As Integer
    Dim Superior6 As Integer
    Dim Superior7 As Integer
    Dim Superior8 As Integer

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
            CveSubSubSubSubSubLinea = ""
            Superior1 = 0
            Superior2 = 0
            Superior3 = 0
            Superior4 = 0
            Superior5 = 0
            Superior6 = 0
            Superior7 = 0
            Superior8 = 0
            Call LimpiarBusqueda()
            Call RellenaGrid()
            Call GenerarToolTip()
            ConsultarProveedorToolStripMenuItem.Text = "Consultar L5"
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

                objDataSet = objCatalogoDeptos.usp_TraerEstl5(0, Superior1, Superior2, Superior3, Superior4, Superior5, Superior6, Superior7, Superior8, CveSubSubSubSubSubLinea, 1, "")
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
            DGrid.Columns(0).HeaderText = "IdL5"
            DGrid.Columns(1).HeaderText = "IdDivisiones"
            DGrid.Columns(2).HeaderText = "CveDivisión"
            DGrid.Columns(3).HeaderText = "División"
            DGrid.Columns(4).HeaderText = "IdDepto"
            DGrid.Columns(5).HeaderText = "CveDepto"
            DGrid.Columns(6).HeaderText = "Depto"
            DGrid.Columns(7).HeaderText = "IdFamilia"
            DGrid.Columns(8).HeaderText = "CveFamilia"
            DGrid.Columns(9).HeaderText = "Familia"
            DGrid.Columns(10).HeaderText = "IdLinea"
            DGrid.Columns(11).HeaderText = "CveLinea"
            DGrid.Columns(12).HeaderText = "Linea"
            DGrid.Columns(13).HeaderText = "IdL1"
            DGrid.Columns(14).HeaderText = "CveL1"
            DGrid.Columns(15).HeaderText = "L1"
            DGrid.Columns(16).HeaderText = "IdL2"
            DGrid.Columns(17).HeaderText = "CveL2"
            DGrid.Columns(18).HeaderText = "L2"
            DGrid.Columns(19).HeaderText = "IdL3"
            DGrid.Columns(20).HeaderText = "CveL3"
            DGrid.Columns(21).HeaderText = "L3"
            DGrid.Columns(22).HeaderText = "IdL4"
            DGrid.Columns(23).HeaderText = "CveL4"
            DGrid.Columns(24).HeaderText = "L4"
            DGrid.Columns(25).HeaderText = "CveL5"
            DGrid.Columns(26).HeaderText = "L5"

            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            DGrid.Columns(0).Visible = False
            DGrid.Columns(1).Visible = False
            DGrid.Columns(4).Visible = False
            DGrid.Columns(7).Visible = False
            DGrid.Columns(10).Visible = False
            DGrid.Columns(13).Visible = False
            DGrid.Columns(16).Visible = False
            DGrid.Columns(19).Visible = False
            DGrid.Columns(22).Visible = False
            DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(20).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(23).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(25).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
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
            Dim myForm As New frmCatalogoL5
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
            Dim myForm As New frmCatalogoL5

            myForm.Accion = 4
            myForm.Txt_IdL5.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idl5").Value.ToString.Trim()

            myForm.ShowDialog()
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar.Click
        Try
            If Sw_NoRegistros = False Then Exit Sub
            Dim myForm As New frmCatalogoL5

            myForm.Accion = 2
            myForm.Txt_IdL5.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idl5").Value.ToString.Trim()
            myForm.ShowDialog()
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Filtro_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        Try
            Dim myForm As New frmFiltrosEstructura
            myForm.ShowDialog()
            If myForm.Txt_IdSubSubSubSubLinea.Text.Trim <> "" Then
                Superior1 = CInt(myForm.Txt_IdSubSubSubSubLinea.Text)
            Else
                Superior1 = 0
            End If
            If myForm.Txt_IdSubSubSubLinea.Text.Trim <> "" Then
                Superior2 = CInt(myForm.Txt_IdSubSubSubLinea.Text)
            Else
                Superior2 = 0
            End If
            If myForm.Txt_IdSubSubLinea.Text.Trim <> "" Then
                Superior3 = CInt(myForm.Txt_IdSubSubLinea.Text)
            Else
                Superior3 = 0
            End If
            If myForm.Txt_IdSubLinea.Text.Trim <> "" Then
                Superior4 = CInt(myForm.Txt_IdSubLinea.Text)
            Else
                Superior4 = 0
            End If
            If myForm.Txt_IdLinea.Text.Trim <> "" Then
                Superior5 = CInt(myForm.Txt_IdLinea.Text)
            Else
                Superior5 = 0
            End If
            If myForm.Txt_IdFamilia.Text.Trim <> "" Then
                Superior6 = CInt(myForm.Txt_IdFamilia.Text)
            Else
                Superior6 = 0
            End If
            If myForm.Txt_IdDepto.Text.Trim <> "" Then
                Superior7 = CInt(myForm.Txt_IdDepto.Text)
            Else
                Superior7 = 0
            End If
            If myForm.Txt_IdDivisiones.Text.Trim <> "" Then
                Superior8 = CInt(myForm.Txt_IdDivisiones.Text)
            Else
                Superior8 = 0
            End If
            CveSubSubSubSubSubLinea = myForm.Txt_CveSubSubSubSubSubLinea.Text
            If myForm.Sw_Filtro = True Then
                RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

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