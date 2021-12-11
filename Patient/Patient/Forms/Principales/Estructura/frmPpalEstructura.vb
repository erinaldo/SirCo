Public Class frmPpalEstructura
    'mreyes 05/Junio/2012 09:59 a.m.
    Private objDataSet As Data.DataSet

    Dim Proveedorb As String
    Dim Raz_Socb As String = ""
    Dim Estadob As String = ""
    Dim Ciudadb As String = ""
    Dim Sw_NoRegistros As Boolean = False
    Dim CveSubSubSubLinea As String
    Dim Superior0 As Integer
    Dim Superior1 As Integer
    Dim Superior2 As Integer
    Dim Superior3 As Integer
    Dim Superior4 As Integer
    Dim Superior5 As Integer
    Dim Superior6 As Integer

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
            CveSubSubSubLinea = ""
            Superior0 = 0
            Superior1 = 0
            Superior2 = 0
            Superior3 = 0
            Superior4 = 0
            Superior5 = 0
            Superior6 = 0
            Call LimpiarBusqueda()
            Call RellenaGrid()
            Call GenerarToolTip()
            ConsultarProveedorToolStripMenuItem.Text = "Consultar Estructura"
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

                objDataSet = objCatalogoDeptos.usp_TraerEstEstructura(Superior0, Superior1, Superior2, Superior3, Superior4, Superior5, Superior6)
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
            DGrid.Columns(1).HeaderText = "CveDivisión"
            DGrid.Columns(2).HeaderText = "División"
            DGrid.Columns(5).HeaderText = "CveDepto"
            DGrid.Columns(6).HeaderText = "Depto"
            DGrid.Columns(10).HeaderText = "CveFamilia"
            DGrid.Columns(11).HeaderText = "Familia"
            DGrid.Columns(17).HeaderText = "CveLinea"
            DGrid.Columns(18).HeaderText = "Linea"
            DGrid.Columns(24).HeaderText = "CveL1"
            DGrid.Columns(25).HeaderText = "L1"
            DGrid.Columns(32).HeaderText = "CveL2"
            DGrid.Columns(33).HeaderText = "L2"
            DGrid.Columns(41).HeaderText = "CveL3"
            DGrid.Columns(42).HeaderText = "L3"
            DGrid.Columns(51).HeaderText = "CveL4"
            DGrid.Columns(52).HeaderText = "L4"
            DGrid.Columns(62).HeaderText = "CveL5"
            DGrid.Columns(63).HeaderText = "L5"
            DGrid.Columns(74).HeaderText = "CveL6"
            DGrid.Columns(75).HeaderText = "L6"

            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            DGrid.Columns(0).Visible = False
            DGrid.Columns(3).Visible = False
            DGrid.Columns(4).Visible = False
            DGrid.Columns(7).Visible = False
            DGrid.Columns(8).Visible = False
            DGrid.Columns(9).Visible = False
            DGrid.Columns(12).Visible = False
            DGrid.Columns(13).Visible = False
            DGrid.Columns(14).Visible = False
            DGrid.Columns(15).Visible = False
            DGrid.Columns(16).Visible = False

            DGrid.Columns(19).Visible = False
            DGrid.Columns(20).Visible = False
            DGrid.Columns(21).Visible = False
            DGrid.Columns(22).Visible = False
            DGrid.Columns(23).Visible = False

            DGrid.Columns(26).Visible = False
            DGrid.Columns(27).Visible = False
            DGrid.Columns(28).Visible = False
            DGrid.Columns(29).Visible = False
            DGrid.Columns(30).Visible = False
            DGrid.Columns(31).Visible = False

            DGrid.Columns(34).Visible = False
            DGrid.Columns(35).Visible = False
            DGrid.Columns(36).Visible = False
            DGrid.Columns(37).Visible = False
            DGrid.Columns(38).Visible = False
            DGrid.Columns(39).Visible = False
            DGrid.Columns(40).Visible = False

            DGrid.Columns(43).Visible = False
            DGrid.Columns(44).Visible = False
            DGrid.Columns(45).Visible = False
            DGrid.Columns(46).Visible = False
            DGrid.Columns(47).Visible = False
            DGrid.Columns(48).Visible = False
            DGrid.Columns(49).Visible = False
            DGrid.Columns(50).Visible = False

            DGrid.Columns(53).Visible = False
            DGrid.Columns(54).Visible = False
            DGrid.Columns(55).Visible = False
            DGrid.Columns(56).Visible = False
            DGrid.Columns(57).Visible = False
            DGrid.Columns(58).Visible = False
            DGrid.Columns(59).Visible = False
            DGrid.Columns(60).Visible = False
            DGrid.Columns(61).Visible = False

            DGrid.Columns(64).Visible = False
            DGrid.Columns(65).Visible = False
            DGrid.Columns(66).Visible = False
            DGrid.Columns(67).Visible = False
            DGrid.Columns(68).Visible = False
            DGrid.Columns(69).Visible = False
            DGrid.Columns(70).Visible = False
            DGrid.Columns(71).Visible = False
            DGrid.Columns(72).Visible = False
            DGrid.Columns(73).Visible = False
            DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(23).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(31).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(40).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(50).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(61).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(73).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
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
            Dim myForm As New frmCatalogoL3
            myForm.Text = "Catalogo de Estructura"
            myForm.Accion = 4
            myForm.Txt_IdL3.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idl3").Value.ToString.Trim()

            myForm.ShowDialog()
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar.Click
        Try
            If Sw_NoRegistros = False Then Exit Sub
            Dim myForm As New frmCatalogoL3

            myForm.Accion = 2
            myForm.Txt_IdL3.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idl3").Value.ToString.Trim()
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
            If myForm.Txt_IdSubSubSubLinea.Text.Trim <> "" Then
                Superior0 = CInt(myForm.Txt_IdSubSubSubLinea.Text)
            Else
                Superior0 = 0
            End If
            If myForm.Txt_IdSubSubLinea.Text.Trim <> "" Then
                Superior1 = CInt(myForm.Txt_IdSubSubLinea.Text)
            Else
                Superior1 = 0
            End If
            If myForm.Txt_IdSubLinea.Text.Trim <> "" Then
                Superior2 = CInt(myForm.Txt_IdSubLinea.Text)
            Else
                Superior2 = 0
            End If
            If myForm.Txt_IdLinea.Text.Trim <> "" Then
                Superior3 = CInt(myForm.Txt_IdLinea.Text)
            Else
                Superior3 = 0
            End If
            If myForm.Txt_IdFamilia.Text.Trim <> "" Then
                Superior4 = CInt(myForm.Txt_IdFamilia.Text)
            Else
                Superior4 = 0
            End If
            If myForm.Txt_IdDepto.Text.Trim <> "" Then
                Superior5 = CInt(myForm.Txt_IdDepto.Text)
            Else
                Superior5 = 0
            End If
            If myForm.Txt_IdDivisiones.Text.Trim <> "" Then
                Superior6 = CInt(myForm.Txt_IdDivisiones.Text)
            Else
                Superior6 = 0
            End If
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