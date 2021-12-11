Public Class frmPpalEmpleados
    'mreyes 15/Junio/2012 04:44 p.m.

    Private objDataSet As Data.DataSet
    Dim Sw_NoRegistros As Boolean = False
    Dim idEmpleadoB As Integer = 0
    Dim idPercDeducB As Integer = 0
    Dim InicioIniB As String = ""
    Dim InicioFinB As String = ""
    Dim BajaIniB As String = ""
    Dim BajaFinB As String = ""
    Dim NacimIniB As STRING = "" 
    Dim NacimFinB As String = ""

    Dim EstatusB As String = False
    Dim IdDeptoB As Integer = 0
    Dim IdPuestoB As Integer = 0
    Dim SucursalB As String = ""

    Dim Sw_Pintar As Boolean = False
    Dim Sw_Load As Boolean = True

    Private Sub frmPpalRepetitivos_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated


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
            ToolTip.SetToolTip(Btn_Nuevo, "Nuevo Empleado")
            ToolTip.SetToolTip(Btn_Editar, "Editar Empleado")
            ToolTip.SetToolTip(Btn_Eliminar, "Eliminar Empleado")
            ToolTip.SetToolTip(Btn_Consultar, "Consultar Empleado")
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
        Using objRepetitivo As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)

            Try
                Me.Cursor = Cursors.WaitCursor
                DGrid.ReadOnly = True
                DGrid.DataSource = Nothing



                objDataSet = objRepetitivo.usp_PpalCatalogoEmpleado(idEmpleadoB, SucursalB, IdDeptoB, IdPuestoB, EstatusB, InicioIniB, InicioFinB, BajaIniB, BajaFinB, NacimIniB, NacimFinB)
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
                    MsgBox("No se encontraron Empleados que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
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
        SucursalB = ""
        EstatusB = ""
        IdDeptoB = 0
        IdPuestoB = 0
        InicioIniB = "1900-01-01"
        InicioFinB = "1900-01-01"
        BajaIniB = "1900-01-01"
        BajaFinB = "1900-01-01"

        NacimIniB = "1900-01-01"
        NacimFinB = "1900-01-01"

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
            DGrid.Columns(0).HeaderText = "Sucursal"
            DGrid.Columns(1).HeaderText = "IdEmpleado"
            DGrid.Columns(2).HeaderText = "Clave"
            DGrid.Columns(3).HeaderText = "Nombre Completo"
            DGrid.Columns(4).HeaderText = "IdDepto"
            DGrid.Columns(5).HeaderText = "Departamento"
            DGrid.Columns(6).HeaderText = "IdPuesto"
            DGrid.Columns(7).HeaderText = "Puesto"
            DGrid.Columns(8).HeaderText = "Fecha Ingreso"
            DGrid.Columns(9).HeaderText = "Fecha Baja"
            DGrid.Columns(10).HeaderText = "Estatus"

            DGrid.Columns(4).Visible = False
            DGrid.Columns(6).Visible = False
            DGrid.Columns(2).Visible = False


            DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


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
        Dim myForm As New frmCatalogoEmpleados
        myForm.Accion = 1
        myForm.ShowDialog()
        If GLB_RefrescarPedido = True Then
            Call RellenaGrid()
        End If
    End Sub

    Private Sub DGrid_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGrid.CellFormatting
        Try

            'mreyes 15/Junio/2012 05:09 p.m.

            Dim Sw_NoEntro As Boolean = False

            Dim DiasEntrega As Integer = 0
            If Sw_Pintar = False Then Exit Sub

            If Me.DGrid.Columns(e.ColumnIndex).Name <> "estatus" Then Exit Sub
            ''If Me.DGrid.Columns(e.ColumnIndex).Name <> "fecha" Then Exit Sub
            If e.RowIndex >= DGrid.RowCount - 2 Then
                If Sw_Load = False Then
                    Sw_Pintar = False
                End If
                Exit Sub
            End If

            If DGrid.Rows(e.RowIndex).Cells("estatus").Value = "BAJA" Then
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.BackColor = Color.Red
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

            End If
            If DGrid.Rows(e.RowIndex).Cells("estatus").Value = "ACTIVO" Then
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.BackColor = Color.GreenYellow
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If
            If DGrid.Rows(e.RowIndex).Cells("estatus").Value = "INACTIVO" Then
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.BackColor = Color.Yellow
                DGrid.Rows(e.RowIndex).Cells("estatus").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
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
        Dim myForm As New frmCatalogoEmpleados

        myForm.Accion = 4
        myForm.Txt_idempleado.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idempleado").Value.ToString.Trim()

        myForm.ShowDialog()
        If GLB_RefrescarPedido = True Then
            Call RellenaGrid()
        End If
    End Sub

    Private Sub Btn_Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar.Click
        If Sw_NoRegistros = False Then Exit Sub
        If DGrid.Rows(DGrid.CurrentRow.Index).Cells("Estatus").Value = "CANCELADO" Then
            MsgBox("No puede modificar un Movimiento Repetitivo Cancelado", MsgBoxStyle.Critical, "Validación")
            Exit Sub
        End If
        Dim myForm As New frmCatalogoEmpleados


        myForm.Accion = 2
        myForm.Txt_idempleado.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idempleado").Value.ToString.Trim()
        myForm.ShowDialog()
        If GLB_RefrescarPedido = True Then
            Call RellenaGrid()
        End If
    End Sub

    Private Sub Btn_Filtro_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        Dim myForm As New frmFiltrosEmpleados
        Dim Estatus As String = ""

        If EstatusB = "B" Then Estatus = "BAJA"
        If EstatusB = "I" Then Estatus = "INACTIVO"
        If EstatusB = "A" Then Estatus = "ACTIVO"

        myForm.Txt_IdEmpleado.Text = IIf(idEmpleadoB = 0, "", idEmpleadoB)
        myForm.Txt_IdPuesto.Text = IIf(IdPuestoB = 0, "", IdPuestoB)
        myForm.Txt_IdDepto.Text = IIf(IdDeptoB = 0, "", IdDeptoB)
        If InicioIniB <> "1900-01-01" Then
            myForm.Chk_FechaIngreso.Checked = True
            myForm.DTPicker2.Value = InicioIniB
            myForm.DTPicker3.Value = InicioFinB
        End If
        If BajaInib <> "1900-01-01" Then
            myForm.Chk_FechaBaja.Checked = True
            myForm.DTPicker6.Value = bajainib
            myForm.DTPicker7.Value = bajafinb
        End If
        If NacimIniB <> "1900-01-01" Then
            myForm.Chk_Nacim.Checked = True
            myForm.DTPicker8.Value = NacimIniB
            myForm.DTPicker9.Value = NacimfinB
        End If

        myForm.Cbo_Estatus.Text = Estatus
        myForm.Txt_Sucursal.Text = SucursalB
 
        myForm.ShowDialog()

        idEmpleadoB = Val(myForm.Txt_IdEmpleado.Text)
        SucursalB = myForm.Txt_Sucursal.Text
        EstatusB = Mid(myForm.Cbo_Estatus.Text, 1, 1)
        idpuestob = Val(myForm.Txt_IdPuesto.Text)
        iddeptob = Val(myForm.Txt_IdDepto.Text)
      
        If myForm.Chk_FechaIngreso.Checked = True Then
            InicioIniB = Format(myForm.DTPicker2.Value, "yyyy-MM-dd")
            InicioFinB = Format(myForm.DTPicker3.Value, "yyyy-MM-dd")
        Else
            InicioIniB = "1900-01-01"
            InicioFinB = "1900-01-01"

        End If


        If myForm.Chk_FechaBaja.Checked = True Then
            BajaIniB = Format(myForm.DTPicker6.Value, "yyyy-MM-dd")
            BajaFinB = Format(myForm.DTPicker7.Value, "yyyy-MM-dd")
        Else
            BajaIniB = "1900-01-01"
            BajaFinB = "1900-01-01"

        End If

        If myForm.Chk_Nacim.Checked = True Then
            NacimIniB = Format(myForm.DTPicker8.Value, "yyyy-MM-dd")
            NacimFinB = Format(myForm.DTPicker9.Value, "yyyy-MM-dd")
        Else
            NacimIniB = "1900-01-01"
            NacimFinB = "1900-01-01"

        End If
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

    Private Sub Btn_Eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Eliminar.Click

    End Sub

    Private Sub Pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub
End Class