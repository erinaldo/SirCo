Public Class frmPpalRepetitivos
    'mreyes 09/Junio/2012 01:07 p.m.

    Private objDataSet As Data.DataSet
    Dim Sw_NoRegistros As Boolean = False
    Dim idEmpleadoB As Integer = 0
    Dim idPercDeducB As Integer = 0
    Dim InicioIniB As Date = "1900-01-01"
    Dim InicioFinB As Date = "1900-01-01"
    Dim EstatusB As String = ""
    Dim Sw_Pintar As Boolean = False
    Dim Sw_Load As Boolean = True

    Private Sub frmPpalRepetitivos_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Sw_NoRegistros = True Then
            DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
        End If

        If Sw_Load = True Then
            If Sw_NoRegistros = False Then
                Sw_Load = False
            Else
                Sw_Load = False
            End If
        End If
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
            EstatusB = "V"
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
            ToolTip.SetToolTip(Btn_Nuevo, "Nuevo Repetitivo")
            ToolTip.SetToolTip(Btn_Editar, "Editar Repetitivo")
            ToolTip.SetToolTip(Btn_Eliminar, "Eliminar Repetitivo")
            ToolTip.SetToolTip(Btn_Consultar, "Consultar Repetitivo")
            ToolTip.SetToolTip(Btn_Filtro, "Búsqueda Avanzada")
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
            ToolTip.SetToolTip(Btn_Imprimir, "Imprimir Información")
            ToolTip.SetToolTip(Btn_Salir, "Salir")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub RellenaGrid()
        'mreyes 11/Junio/2012 05:31 p.m.
        Using objRepetitivo As New BCL.BCLCatalogoRepetitivo(GLB_ConStringNomSis)

            Try
                Me.Cursor = Cursors.WaitCursor
                DGrid.ReadOnly = True
                DGrid.DataSource = Nothing

                objDataSet = objRepetitivo.usp_PpalCatalogoRepetitivo(idEmpleadoB, idPercDeducB, EstatusB, InicioIniB, InicioFinB, "")
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
                    MsgBox("No se encontraron Repetitivos que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
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

     
        idEmpleadoB = 0
        idPercDeducB = 0
        EstatusB = ""
        InicioIniB = "1900-01-01"
        InicioFinB = "1900-01-01"
        
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

            Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
            Dim row As DataRow = dt.NewRow()
            row(5) = "Total: "

            row(7) = pub_SumarColumnaGrid(DGrid, 7, DGrid.RowCount - 1)
            row(8) = pub_SumarColumnaGrid(DGrid, 8, DGrid.RowCount - 1)
            row(9) = pub_SumarColumnaGrid(DGrid, 9, DGrid.RowCount - 1)

            dt.Rows.Add(row)
            DGrid.DataSource = dt

            DGrid.RowHeadersVisible = False
            DGrid.Columns(0).HeaderText = "IdRep"
            DGrid.Columns(1).HeaderText = "IdEmpleado"
            DGrid.Columns(2).HeaderText = "Nombre Completo"
            DGrid.Columns(3).HeaderText = "IdPercDeduc"
            DGrid.Columns(4).HeaderText = "Clave"
            DGrid.Columns(5).HeaderText = "Descripción"
            DGrid.Columns(6).HeaderText = "Fecha Inicio"
            DGrid.Columns(7).HeaderText = "Folio"
            DGrid.Columns(8).HeaderText = "Importe"
            DGrid.Columns(9).HeaderText = "Cuota"
            DGrid.Columns(10).HeaderText = "Saldo"
            DGrid.Columns(11).HeaderText = "Estatus"

            DGrid.Columns(3).Visible = False
            DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid.Columns(8).DefaultCellStyle.Format = "c"
            DGrid.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns(9).DefaultCellStyle.Format = "c"
            DGrid.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns(10).DefaultCellStyle.Format = "c"
            DGrid.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            
            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)


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
        Dim myForm As New frmCatalogoRepetitivos
        myForm.Accion = 1
        myForm.ShowDialog()
        Call RellenaGrid()
    End Sub

    Private Sub DGrid_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGrid.CellFormatting
        Try
            '' If Sw_PedidoNuevo = True Then Exit Sub

            Dim Sw_NoEntro As Boolean = False


            Dim DiasEntrega As Integer = 0
            If Sw_Pintar = False Then Exit Sub

            If Me.DGrid.Columns(e.ColumnIndex).Name <> "Estatus" Then Exit Sub
            ''If Me.DGrid.Columns(e.ColumnIndex).Name <> "fecha" Then Exit Sub
            If e.RowIndex >= DGrid.RowCount - 2 Then
                If Sw_Load = False Then
                    Sw_Pintar = False
                End If
                Exit Sub
            End If

            If DGrid.Rows(e.RowIndex).Cells("Estatus").Value = "CANCELADO" Then
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.BackColor = Color.Red
            End If
            If DGrid.Rows(e.RowIndex).Cells("Estatus").Value = "VIGENTE" Then
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.BackColor = Color.GreenYellow
            End If
            If DGrid.Rows(e.RowIndex).Cells("Estatus").Value = "SUSPENDIDO" Then
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.BackColor = Color.Yellow
            End If

            If DGrid.Rows(e.RowIndex).Cells("Estatus").Value = "FINALIZADO" Then
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.BackColor = Color.BlueViolet
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
        Dim myForm As New frmCatalogoRepetitivos

        myForm.Accion = 4
        myForm.Txt_IdRepetitivo.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells(0).Value.ToString.Trim()

        myForm.ShowDialog()
        Call RellenaGrid()
    End Sub

    Private Sub Btn_Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar.Click
        If Sw_NoRegistros = False Then Exit Sub
        If DGrid.Rows(DGrid.CurrentRow.Index).Cells("Estatus").Value = "CANCELADO" Then
            MsgBox("No puede modificar un Movimiento Repetitivo Cancelado", MsgBoxStyle.Critical, "Validación")
            Exit Sub
        End If

        If DGrid.Rows(DGrid.CurrentRow.Index).Cells("Estatus").Value = "FINALIZADO" Then
            MsgBox("No puede modificar un Movimiento Repetitivo Finalizado", MsgBoxStyle.Critical, "Validación")
            Exit Sub
        End If

        Dim myForm As New frmCatalogoRepetitivos


        myForm.Accion = 2
        myForm.Txt_IdRepetitivo.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells(0).Value.ToString.Trim()
        myForm.ShowDialog()
        Call RellenaGrid()
    End Sub

    Private Sub Btn_Filtro_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        Dim myForm As New frmFiltrosRepetitivos
        Dim Estatus As String = ""

        If EstatusB = "S" Then Estatus = "SUSPENDIDO"
        If EstatusB = "V" Then Estatus = "VIGENTE"
        If EstatusB = "C" Then Estatus = "CANCELADO"
        If EstatusB = "F" Then Estatus = "FINALIZADO"

        myForm.Txt_IdEmpleado.Text = idEmpleadoB
        myForm.Txt_IdEmpleado.Text = ""
        myForm.Txt_IdPercDeduc.Text = idPercDeducB
        myForm.Cbo_Estatus.Text = Estatus
        myForm.ShowDialog()
        idEmpleadoB = Val(myForm.Txt_IdEmpleado.Text)
        idPercDeducB = Val(myForm.Txt_IdPercDeduc.Text)
        EstatusB = Mid(myForm.Cbo_Estatus.Text, 1, 1)


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

    Private Sub DGrid_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGrid.ColumnHeaderMouseClick
        Sw_Pintar = True
    End Sub
End Class