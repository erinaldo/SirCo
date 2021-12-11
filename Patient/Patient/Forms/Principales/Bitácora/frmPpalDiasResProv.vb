Public Class frmPpalDiasResProv
    'Tony García - 07/Diciembre/2012 12:35 p.m.

    Private objDataSet As Data.DataSet
    Private FechaInicio As String
    Private FechaFin As String
    Dim ProveedorB As String
    Dim blnBindingOff As Boolean = False
    Dim blnBorrarCad As Boolean = False

    Dim Sw_Load As Boolean = True
    Dim Sw_NoRegistros As Boolean = False
    Dim Sw_Pintar As Boolean = False

    Private Sub frmPpalEstilosSinExist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        Call LimpiarBusqueda()
        Call RellenaGrid()
        Sw_Pintar = True
        'Sw_Load = False 
        Sw_Load = True
    End Sub

    Private Sub frmPpalEstilosSinExist_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Sw_NoRegistros = False Then Exit Sub
        If Sw_Load = True Then
            Sw_Load = False
            InicializaGrid()
            'AgregarColumna()
            '    Call BarrerGrid()
        End If
    End Sub

    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Guardar, "Guardar Cambios")
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
            ToolTip.SetToolTip(Btn_Resurtido, "Ir a Resurtido")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub LimpiarBusqueda()
       
        FechaInicio = "1900-01-01"
        FechaFin = "1900-01-01"
        ProveedorB = ""
    End Sub

    Private Sub RellenaGrid()
        'Tony Garcia - 03/Diciembre/2012 - 5:15 p.m.
        Using objDiasResProv As New BCL.BCLDiasResProv(GLB_ConStringCipSis)

            Try
                Me.Cursor = Cursors.WaitCursor
                'DGrid.ReadOnly = True
                DGrid.DataSource = Nothing

                If Sw_Load = True Then
                    ' Sw_Load = False 
                Else
                    If Sw_NoRegistros = True Then
                        DGrid.Columns.Remove("Selec")
                    End If
                End If

                objDataSet = objDiasResProv.usp_PpalDiasResProv(ProveedorB, FechaInicio, FechaFin)

                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section

                    DGrid.DataSource = objDataSet.Tables(0)
                    If Sw_Load = False Then
                        InicializaGrid()
                    End If
                    'LimpiarBusqueda()
                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True
                    Sw_NoRegistros = True
                    Sw_Pintar = True
                    'Call Colores()
                Else
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    'MsgBox("No se encontraron registros que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                End If
                Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Sub InicializaGrid()
        Try

            DGrid.RowHeadersVisible = False
            DGrid.Columns(0).HeaderText = "Numero Proveedor"
            DGrid.Columns(1).HeaderText = "Razón Social"
            DGrid.Columns(2).HeaderText = "Marca"
            DGrid.Columns(3).HeaderText = "Modelo"
            DGrid.Columns(4).HeaderText = "Dias Respuesta"
            DGrid.Columns(5).HeaderText = "Ultimo Resurtido"
            DGrid.Columns(6).HeaderText = "Dias Resurtido"
            DGrid.Columns(7).HeaderText = "Próximo Resurtido"

            'DGrid.Columns(0).Visible = False

            DGrid.Columns(0).ReadOnly = True
            DGrid.Columns(1).ReadOnly = True
            DGrid.Columns(2).ReadOnly = True
            DGrid.Columns(3).ReadOnly = True
            DGrid.Columns(4).ReadOnly = True
            DGrid.Columns(5).ReadOnly = True
            DGrid.Columns(7).ReadOnly = True
            'DGrid.Columns(8).ReadOnly = True

            For i As Integer = 0 To DGrid.Rows.Count - 2
                DGrid.Rows(i).Cells("ultimoresurtido").Value = CDate(DGrid.Rows(i).Cells("ultimoresurtido").Value).ToString("dd-MMM-yyyy").ToUpper
                DGrid.Rows(i).Cells("proxresurtido").Value = CDate(DGrid.Rows(i).Cells("proxresurtido").Value).ToString("dd-MMM-yyyy").ToUpper
            Next

            'DGrid.Columns(4).DefaultCellStyle.Format = "dd-MMM-yyyy"
            'DGrid.Columns(6).DefaultCellStyle.Format = "dd-MMM-yyyy"

            DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            Call AgregarColumna()

            DGrid.Columns(4).Visible = False
            DGrid.Columns(8).Visible = False

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

    Private Sub frmPpalEstilosSinExist_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub AgregarColumna()
        Dim colSelec As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        colSelec.Name = "Selec"
        colSelec.HeaderText = "Selec"
        colSelec.DisplayIndex = 8
        colSelec.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        colSelec.CellTemplate = New DataGridViewCheckBoxCell()
        ' añadir columna de imagen a la coleccion del grid 
        DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        ''DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DGrid.Columns.Add(colSelec)
    End Sub

    'Private Sub Btn_Resurtido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Resurtido.Click
    '    Try
    '        Dim myForm As New frmPpalResurtidoAut

    '        myForm.MdiParent = BitacoraMain
    '        myForm.WindowState = FormWindowState.Maximized
    '        myForm.Show()
    '    Catch ExceptionErr As Exception
    '        MessageBox.Show(ExceptionErr.Message.ToString)
    '    End Try
    'End Sub

    Private Sub Btn_Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Guardar.Click
        Dim intContador As Integer = 0
        Dim intContadorMovs As Integer = 0
        Try

            For Each row As DataGridViewRow In DGrid.Rows
                If row.Cells("Selec").Value = True Then
                    intContador += 1
                End If
            Next

            If intContador = 0 Then
                MsgBox("No se selecciono ningun Registro para Actualizar", MsgBoxStyle.OkOnly, "Aviso")
                Exit Sub
            End If

            If MsgBox("Desea Modificar los días de Resurtido de los registros seleccionados?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub

            For i As Integer = 0 To DGrid.Rows.Count - 1
                If DGrid.Rows(i).Cells("Selec").Value = True  Then
                    Dim Proveedor As String = DGrid.Rows(i).Cells("proveedor").Value
                    Dim Marca As String = DGrid.Rows(i).Cells("marca").Value
                    Dim Estilon As String = DGrid.Rows(i).Cells("estilon").Value
                    Dim DiasRes As Integer = DGrid.Rows(i).Cells("diasresurtido").Value

                    If DGrid.Rows(i).Cells("estilon").Value = "" Then
                        Marca = ""
                    End If

                    Using objDiasResProv As New BCL.BCLDiasResProv(GLB_ConStringCipSis)
                        objDiasResProv.usp_ActualizaDiasResProv(Proveedor, Marca, Estilon, DiasRes)
                    End Using
                    intContadorMovs += 1
                End If
            Next

            If intContadorMovs = 0 Then
                MsgBox("No se actualizó ningun registro.", MsgBoxStyle.OkOnly, "Aviso")
                Exit Sub
            Else
                MsgBox("Los registros se actualizaron correctamente.", MsgBoxStyle.Information, "Confirmación")
            End If

            Txt_Proveedor.Text = ""
            Txt_RazSoc.Text = ""
            Call RellenaGrid()
          
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellEndEdit
        Dim FechaRes As Date
        Try
            DGrid.CurrentRow.Cells("Selec").Value = True

            If DGrid.CurrentRow.Cells("ultimoresurtido").Value = "01-ENE-1900" Then
                FechaRes = GLB_FechaHoy
                'If IsDBNull(DGrid.CurrentRow.Cells("diasresurtido").Value) Then
                '    DGrid.CurrentRow.Cells("diasresurtido").Value = 0
                'End If
                FechaRes = DateAdd(DateInterval.Day, DGrid.CurrentRow.Cells("diasresurtido").Value, FechaRes)
                DGrid.CurrentRow.Cells("proxresurtido").Value = FechaRes.ToString("dd-MMM-yyyy").ToUpper

                DGrid.Refresh()
            Else

                FechaRes = CDate(DGrid.CurrentRow.Cells("ultimoresurtido").Value)
                FechaRes = DateAdd(DateInterval.Day, DGrid.CurrentRow.Cells("diasresurtido").Value, FechaRes)
                DGrid.CurrentRow.Cells("proxresurtido").Value = FechaRes.ToString("dd-MMM-yyyy").ToUpper

                DGrid.Refresh()
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGrid.CellFormatting
        Try
            'If Me.DGrid.Columns(e.ColumnIndex).Name <> "diasresurtido" Then Exit Sub
            ''If Me.DGrid.Columns(e.ColumnIndex).Name = "diasresurtido" Then

            'If DGrid.Rows(e.RowIndex).Cells("diasresurtido").Value = Nothing Then

            'End If

            ''End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick
        Dim intDiasRes As Integer = 0

        Try
            intDiasRes = DGrid.Rows(DGrid.CurrentRow.Index).Cells("diasresurtido").Value

            'For i As Integer = DGrid.CurrentRow.Index To DGrid.Rows.Count - 2
            '    DGrid.Rows(i).Cells("diasresurtido").Value = intDiasRes
            '    DGrid.Rows(i).Cells("Selec").Value = True

            '    If DGrid.Rows(i).Cells("ultimoresurtido").Value = "01-ENE-1900" Then
            '        FechaRes = GLB_FechaHoy

            '        FechaRes = DateAdd(DateInterval.Day, DGrid.Rows(i).Cells("diasresurtido").Value, FechaRes)
            '        DGrid.Rows(i).Cells("proxresurtido").Value = FechaRes.ToString("yyyy-MM-dd")

            '        DGrid.Refresh()
            '    Else
            '        FechaRes = DateAdd(DateInterval.Day, DGrid.Rows(i).Cells("diasresurtido").Value, FechaRes)
            '        DGrid.Rows(i).Cells("proxresurtido").Value = FechaRes.ToString("yyyy-MM-dd")

            '        DGrid.Refresh()
            '    End If
            'Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles DGrid.EditingControlShowing
        Try
            Dim validar As TextBox = CType(e.Control, TextBox)
            AddHandler validar.KeyPress, AddressOf validar_Keypress

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub




    Private Sub validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ' obtener indice de la columna 
        Dim columna As Integer = DGrid.CurrentCell.ColumnIndex
        ' comprobar si la celda en edicin corresponde a la columna 0 o 1
        Dim caracter As Char = e.KeyChar
        Dim strval As String = DGrid.CurrentCell.EditedFormattedValue.ToString

        Try
            If columna = 5 Then
                If Not Char.IsNumber(caracter) Then
                    e.Handled = True
                Else
                    e.Handled = False
                End If
            End If
            If columna = 5 Then

                'If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False And (caracter = ChrW(Keys.Enter)) = False _
                'And (caracter = ChrW(Keys.Tab)) Then
                If Char.IsNumber(caracter) Or (caracter = ChrW(Keys.Back)) = True Or (caracter = ChrW(Keys.Enter)) = True _
                Or (caracter = ChrW(Keys.Tab)) = True Then
                    'Me.Text =
                    'e.KeyChar = Chr(0)
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub NuevoEstiloToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NuevoEstiloToolStripMenuItem.Click
        Try
            Dim myForm As New frmCatalogoMarcaEstiloDiasRes

            myForm.Accion = 1
            myForm.Txt_Proveedor.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("proveedor").Value.ToString.Trim()
            myForm.Txt_RazSoc.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("raz_soc").Value.ToString.Trim()
            myForm.Txt_Marca.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("marca").Value.ToString.Trim()

            myForm.ShowDialog()

            Txt_Proveedor.Text = ""
            Txt_RazSoc.Text = ""

            If myForm.Sw_Registro = True Then
                Call RellenaGrid()
            End If


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub NuevoEstilo(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call NuevoEstilo(sender, e)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub EliminarEstilo()
        Try
            Call EliminarEstilo()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub EliminarEstiloToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles EliminarEstiloToolStripMenuItem.Click
        Try
            If DGrid.Rows(DGrid.CurrentRow.Index).Cells("estilon").Value = "" Then
                MsgBox("Solo puede eliminar Registros que cuenten con Marca/Modelo.", MsgBoxStyle.Critical, "ERROR")
                Exit Sub
            End If

            If MsgBox("Esta Seguro de Eliminar el Registro?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                Dim Proveedor As String = DGrid.Rows(DGrid.CurrentRow.Index).Cells("proveedor").Value
                Dim Marca As String = DGrid.Rows(DGrid.CurrentRow.Index).Cells("marca").Value
                Dim Estilon As String = DGrid.Rows(DGrid.CurrentRow.Index).Cells("estilon").Value

                Using objDiasResProv As New BCL.BCLDiasResProv(GLB_ConStringCipSis)
                    objDiasResProv.usp_EliminarMarcaEstilonDiasRes(Proveedor, Marca, Estilon)
                End Using

                MsgBox("El registro se eliminó correctamente.", MsgBoxStyle.Information, "Confirmación")

                Txt_Proveedor.Text = ""
                Txt_RazSoc.Text = ""
                Call RellenaGrid()
            Else
                Exit Sub
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DGrid.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With Me.DGrid
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If
    End Sub

    'Filtrar por Id Proveedor
    Private Sub Txt_Proveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Proveedor.TextChanged
        Dim valor As String
        Dim intNumLet As Integer = 0
        Dim cm1 As CurrencyManager
        Try

            If Txt_Proveedor.Text = "" AndAlso Txt_RazSoc.Text <> "" Then Exit Sub

            If Txt_RazSoc.Text <> "" Then
                Txt_RazSoc.Text = ""
            End If

            'If blnBindingOff = False Then
            cm1 = BindingContext(Me.DGrid.DataSource)
            blnBindingOff = True
            'End If

            cm1.SuspendBinding()

            For i As Integer = 0 To DGrid.Rows.Count - 2
                'valor = DGrid.Rows(i).Cells("marca").Value
                intNumLet = Txt_Proveedor.Text.Length
                valor = Txt_Proveedor.Text

                If Mid(DGrid.Rows(i).Cells("proveedor").Value, 1, intNumLet) = valor Then
                    DGrid.Rows(i).Visible = True
                    Continue For
                End If

                If Mid(DGrid.Rows(i).Cells("proveedor").Value, 1, intNumLet) <> valor Then
                    DGrid.Rows(i).Visible = False
                    Continue For
                End If

            Next
            'blnBorrarCad = True

            cm1.ResumeBinding()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    'Filtrar por descripción Proveedor
    Private Sub Txt_RazSoc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_RazSoc.TextChanged
        Dim valor As String
        Dim intNumLet As Integer = 0
        Dim cm1 As CurrencyManager
        Try

            If Txt_RazSoc.Text = "" AndAlso Txt_Proveedor.Text <> "" Then Exit Sub

            If Txt_Proveedor.Text <> "" Then
                Txt_Proveedor.Text = ""
            End If

            'If blnBindingOff = False Then
            cm1 = BindingContext(Me.DGrid.DataSource)
            blnBindingOff = True
            'End If

            cm1.SuspendBinding()

            For i As Integer = 0 To DGrid.Rows.Count - 2
                'valor = DGrid.Rows(i).Cells("marca").Value
                intNumLet = Txt_RazSoc.Text.Length
                valor = Txt_RazSoc.Text

                If Mid(DGrid.Rows(i).Cells("raz_soc").Value, 1, intNumLet) = valor Then
                    DGrid.Rows(i).Visible = True
                    Continue For
                End If

                If Mid(DGrid.Rows(i).Cells("raz_soc").Value, 1, intNumLet) <> valor Then
                    DGrid.Rows(i).Visible = False
                    Continue For
                End If

            Next

            'blnBorrarCad = False
            cm1.ResumeBinding()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Proveedor_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Proveedor.KeyPress
        Call pub_SoloNumeros(sender, e)
    End Sub

    Private Sub Txt_RazSoc_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_RazSoc.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class