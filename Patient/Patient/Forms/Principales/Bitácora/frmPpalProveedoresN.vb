Public Class frmppalproveedoresn
    Dim Sw_Pintar As Boolean = False
    Private objDataSet As Data.DataSet
    Dim Sw_Load As Boolean = True

    Dim IdProveedor As Integer = 0
    Dim Proveedorb As String = ""
    Dim Raz_Socb As String = ""
    Dim Estadob As String = ""
    Dim Ciudadb As String = ""
    Dim EstatusB As String = ""
    Dim MarcaB As String = ""
    Dim Sw_NoRegistros As Boolean = False
    Dim blnCondiciones As Boolean = False
    Dim TipoB As String = ""
    Dim AceptaFactorajeb As Integer = 0
    Dim FactRemB As integer = 0 

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


            ToolTip.SetToolTip(Btn_Nuevo, "Nuevo Proveedor")
            ToolTip.SetToolTip(Btn_Editar, "Editar Proveedor")
            ToolTip.SetToolTip(Btn_Eliminar, "Eliminar Proveedor")
            ToolTip.SetToolTip(Btn_Consultar, "Consultar Proveedor")

            ToolTip.SetToolTip(Btn_Filtro, "Búsqueda Avanzada")

            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
            ToolTip.SetToolTip(Btn_Imprimir, "Imprimir Información")

            ToolTip.SetToolTip(Btn_Salir, "Salir")



        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub RellenaGrid()
        'mreyes 28/Febrero/2012 01:41 p.m.
        Using objProveedores As New BCL.BCLCatalogoProveedoresN(GLB_ConStringCipSis)

            Try
                Me.Cursor = Cursors.WaitCursor
                DGrid.ReadOnly = True
                DGrid.DataSource = Nothing

                objDataSet = objProveedores.usp_PpalCatalogoProveedoresN(IdProveedor, "%" & Raz_Socb & "%", Estadob, Ciudadb, EstatusB, MarcaB, TipoB, AceptaFactorajeb, factremb)
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
    Private Sub DGrid_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGrid.ColumnHeaderMouseClick
        Sw_Pintar = True
    End Sub
    Private Sub LimpiarBusqueda()

        Proveedorb = ""
        Raz_Socb = ""
        Estadob = ""
        Ciudadb = ""
        EstatusB = "AC"
        MarcaB = ""

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
            DGrid.Columns(0).HeaderText = "IdProv"
            DGrid.Columns(1).HeaderText = "Prov"
            DGrid.Columns(2).HeaderText = "Razon Social"
            DGrid.Columns(3).HeaderText = "RFC"

            DGrid.Columns(4).HeaderText = "Tipo"


            DGrid.Columns(5).HeaderText = "Calle"
            DGrid.Columns(6).HeaderText = "Colonia"
            DGrid.Columns(7).HeaderText = "Ciudad"
            DGrid.Columns(8).HeaderText = "Estado"
            DGrid.Columns(9).HeaderText = "CodPos"
            DGrid.Columns(10).HeaderText = "Teléfono 1"
            DGrid.Columns(11).HeaderText = "Teléfono 2"
            DGrid.Columns(12).HeaderText = "Desc. PP" 'oculto
            DGrid.Columns(13).HeaderText = "Plazo" 'oculto
            DGrid.Columns(14).HeaderText = "Dscto 01" 'oculto
            DGrid.Columns(15).HeaderText = "Dscto 02" 'oculto
            DGrid.Columns(16).HeaderText = "Dscto 03" 'oculto
            DGrid.Columns(17).HeaderText = "Dscto 04" 'oculto
            DGrid.Columns(18).HeaderText = "Dscto 05" 'oculto
            DGrid.Columns(19).HeaderText = "Estatus"
            DGrid.Columns(20).HeaderText = "Acepta Factoraje"
            DGrid.Columns(21).HeaderText = "Factura y Remisiona"


            DGrid.Columns("tipopago").HeaderText = "Tipo Pago"

            DGrid.Columns(0).Visible = False
            If blnCondiciones = False Then
                DGrid.Columns(12).Visible = False
                DGrid.Columns(13).Visible = False
                DGrid.Columns(14).Visible = False
                DGrid.Columns(15).Visible = False
                DGrid.Columns(16).Visible = False
                DGrid.Columns(17).Visible = False
                DGrid.Columns(18).Visible = False
            End If

            DGrid.Columns(5).Visible = False
            DGrid.Columns(6).Visible = False
            DGrid.Columns(7).Visible = False
            DGrid.Columns(8).Visible = False
            DGrid.Columns(9).Visible = False

            ' For i As Integer = 0 To DGrid.Columns.Count - 1
            'DGrid.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            ' Next
            DGrid.Columns(20).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(21).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid.Columns("tipopago").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

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
        Dim myForm As New frmCatalogoProveedoresN
        myForm.Accion = 1
        myForm.MdiParent = BitacoraMain
        myForm.Show()
        'myForm.ShowDialog()
        If myForm.Sw_Registro = True Then
            Call RellenaGrid()
        End If
    End Sub

    Private Sub DGrid_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGrid.CellFormatting
        Try



            Dim Sw_NoEntro As Boolean = False

            If Sw_Pintar = False Then Exit Sub

            If Me.DGrid.Columns(e.ColumnIndex).Name <> "tipopago" Then Exit Sub
            ''If Me.DGrid.Columns(e.ColumnIndex).Name <> "fecha" Then Exit Sub
            If e.RowIndex >= DGrid.RowCount - 2 Then
                If Sw_Load = False Then
                    Sw_Pintar = False
                End If
                Exit Sub
                End If

                If IsDBNull(DGrid.Rows(e.RowIndex).Cells("tipopago").Value) Then Exit Sub

            If DGrid.Rows(e.RowIndex).Cells("tipopago").Value = "FACTORAJE" Then
                DGrid.Rows(e.RowIndex).Cells("tipopago").Style.BackColor = Color.Yellow
                DGrid.Rows(e.RowIndex).Cells("tipopago").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If

            If DGrid.Rows(e.RowIndex).Cells("tipopago").Value = "CONSIGNACIÓN" Then
                DGrid.Rows(e.RowIndex).Cells("tipopago").Style.BackColor = Color.Aquamarine
                DGrid.Rows(e.RowIndex).Cells("tipopago").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If



            If DGrid.Rows(e.RowIndex).Cells("tipopago").Value = "TRANSFERENCIA" Then
                DGrid.Rows(e.RowIndex).Cells("tipopago").Style.BackColor = Color.MistyRose
                DGrid.Rows(e.RowIndex).Cells("tipopago").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If




            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
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
        Dim myForm As New frmCatalogoProveedoresN

        myForm.Accion = 4
        myForm.Txt_IdProveedor.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idproveedor").Value.ToString.Trim()
        myForm.Txt_Proveedor.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("proveedor").Value.ToString.Trim()

        myForm.MdiParent = BitacoraMain
        myForm.Show()
        'myForm.ShowDialog()

        If myForm.Sw_Registro = True Then
            Call RellenaGrid()
        End If
    End Sub
    Private Sub Btn_Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar.Click
        Try
            If Sw_NoRegistros = False Then Exit Sub
            Dim myForm As New frmCatalogoProveedoresN

            myForm.Accion = 2
            myForm.Txt_IdProveedor.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idproveedor").Value.ToString.Trim()
            myForm.Txt_Proveedor.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("proveedor").Value.ToString.Trim()
            'myForm.MdiParent = BitacoraMain

            'myForm.Show()
            myForm.ShowDialog()

            Call RellenaGrid()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Btn_Filtro_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        Try
            Dim myForm As New frmFiltrosProveedor
            myForm.Txt_Proveedor.Text = Proveedorb
            myForm.Txt_Raz_Soc.Text = Raz_Socb
            myForm.Cbo_Estado.Text = Estadob
            myForm.Cbo_Ciudad.Text = Ciudadb
            myForm.Txt_Marca.Text = MarcaB

            myForm.Cbo_Tipo.Text = TipoB

            If EstatusB = "AC" Then
                myForm.Cbo_Estatus.Text = "ACTIVO"
            ElseIf EstatusB = "BA" Then
                myForm.Cbo_Estatus.Text = "BAJA"
            ElseIf EstatusB = "SU" Then
                myForm.Cbo_Estatus.Text = "SUSPENDIDO"
            Else
                myForm.Cbo_Estatus.Text = ""
            End If

            If AceptaFactorajeb = 0 Then
                myForm.Chk_Factoraje.Checked = False
            Else
                myForm.Chk_Factoraje.Checked = True
            End If

            If FactRemB = 0 Then
                myForm.Chk_FactRem.Checked = False
            Else
                myForm.Chk_FactRem.Checked = True
            End If
            myForm.ShowDialog()
            Proveedorb = myForm.Txt_Proveedor.Text
            Raz_Socb = myForm.Txt_Raz_Soc.Text
            Estadob = myForm.Cbo_Estado.Text
            Ciudadb = myForm.Cbo_Ciudad.Text
            MarcaB = myForm.Txt_Marca.Text
            TipoB = myForm.Cbo_Tipo.Text

            EstatusB = Mid(myForm.Cbo_Estatus.Text, 1, 2)


            If myForm.Chk_Factoraje.Checked = False Then
                AceptaFactorajeb = 0
            Else
                AceptaFactorajeb = 1
            End If

            If myForm.Chk_FactRem.Checked = False Then
                FactRemB = 0
            Else
                FactRemB = 1
            End If


            If myForm.Sw_Filtro = True Then
                Call RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
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
    Private Sub Chk_Condiciones_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_Condiciones.CheckedChanged
        If Chk_Condiciones.Checked = True Then
            blnCondiciones = True
        ElseIf Chk_Condiciones.Checked = False Then
            blnCondiciones = False
        End If

        Call RellenaGrid()
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

    Private Sub frmppalproveedoresn_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If Sw_Load = True Then
            If Sw_NoRegistros = False Then
                Sw_Load = False
            Else
                Sw_Load = False
                'InicializaGrid()
            End If
        End If
    End Sub
End Class