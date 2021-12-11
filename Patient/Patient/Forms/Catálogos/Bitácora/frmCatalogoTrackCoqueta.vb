Public Class frmCatalogoTrackCoqueta

    'mreyes 23/Febrero/2012 02:23 p.m. 

    Dim Sql As String
    Public Accion As Integer  '' 1  = nuevo, 2 = edicion , 3 = eliminar , 4 = consultar 
    Public Sw_Registro As Boolean = False
    Private objDataSet As Data.DataSet
    Private objDataSetFiltro As Data.DataSet
    Dim Costo As Decimal = 0
    Public Sw_PedidoNuevo As Boolean = False

    Dim FechaInib As String
    Dim FechaFinb As String

    Dim intPosicion As Integer = 0
    Dim intTotalRows As Integer = 0

    Public Opcion As Integer
    Public Guardo As Boolean = False

    Private Sub Txt_Marca_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Marca.GotFocus
        Txt_Marca.SelectAll()
    End Sub

    Private Sub Txt_Marca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Marca.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Function ValidarEdicion() As Boolean
        'mreyes 03/Marzo/2012 11:23 a.m. 
        ValidarEdicion = False
        Try
            If Txt_Marca.Text.Length = 0 Then
                MsgBox("Debe especificar una marca para el Estilo.", MsgBoxStyle.Critical, "Validación")
                Txt_Marca.Focus()
                Exit Function
            End If

            If Txt_Estilof.Text.Length = 0 Then
                MsgBox("Debe especificar el estilo de fábrica para el Estilo.", MsgBoxStyle.Critical, "Validación")
                Txt_Estilof.Focus()
                Exit Function
            End If

            ValidarEdicion = True
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Function

    Private Sub DGrid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub frmCatalogoEstilos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'GLB_CatEsiloCancelado = True
    End Sub

    Private Sub frmCatalogoEstilos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' GLB_CatEsiloCancelado = True
    End Sub

    Private Sub frmCatalogoEstilos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then
                Me.Dispose()
                Me.Close()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmCatalogoEstilos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            If Accion = 1 Then
                ' LimpiarDatos()
                If Sw_PedidoNuevo = True Then
                    ' traer el estilo anterior, 
                    'If ya existe el estilo de fábrica

                    Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
                        Try

                            If Txt_Estilof.Text.Length > 0 Then
                                objDataSet = objMySqlGral.usp_TraerDescripcion("EN", Txt_Marca.Text, Txt_Estilof.Text)

                                If objDataSet.Tables(0).Rows.Count > 0 Then


                                End If
                            End If
                            Call Txt_Marca_LostFocus(sender, e)
                        Catch ExceptionErr As Exception
                            MessageBox.Show(ExceptionErr.Message.ToString)
                        End Try
                    End Using
                End If
            End If
            Call GenerarToolTip()
            Call usp_TraerEstilo()
            'Call RellendaGridsInfoArticulo()

            Txt_Estilof.Enabled = False
            If Opcion = 1 Then
                Me.Text = "Trac Estilos"
                ComponentesDinamicos()
            End If
            If Opcion = 2 Then
                Me.Text = "Nuevos Registros Trac"
                DGrid.ReadOnly = False
                RellenaMedidas()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub usp_TraerEstilo()
        Dim objDataSetEstilo As Data.DataSet
        Using objCatalogoEstilos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
            Try

                objDataSetEstilo = Nothing
                objDataSetEstilo = objCatalogoEstilos.usp_TraerEstilo(0, Txt_Marca.Text, Txt_Estilon.Text, Txt_Estilof.Text, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "")

                If objDataSetEstilo.Tables(0).Rows.Count > 0 Then
                    Txt_Marca.Text = objDataSetEstilo.Tables(0).Rows(0).Item("marca").ToString
                    Txt_DescripMarca.Text = objDataSetEstilo.Tables(0).Rows(0).Item("descripmarca").ToString
                    Txt_Estilon.Text = objDataSetEstilo.Tables(0).Rows(0).Item("estilon").ToString
                    Txt_Estilof.Text = objDataSetEstilo.Tables(0).Rows(0).Item("estilof").ToString

                    If Sw_PedidoNuevo = False Then

                    Else

                        Txt_Estilof.Text = ""
                        Txt_Estilon.Text = ""

                        'DGrid2.DataSource = Nothing
                        'DGrid3.DataSource = Nothing

                        'For i As Integer = 0 To DGrid2.Rows.Count - 2
                        '    DGrid2.Rows.Remove(DGrid2.Rows(DGrid2.Rows.Count - 2))
                        'Next

                        'DGrid2.Columns.Remove(DGrid2.Columns("Total"))

                        'For i As Integer = 0 To DGrid3.Columns.Count - 1
                        '    DGrid3.Columns.Remove(DGrid3.Columns(0))
                        'Next

                        Txt_Estilon.Select()
                    End If
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub ComponentesDinamicos()
        Dim objDataSetAux As New DataSet
        Dim x As Integer = 15
        Dim y As Integer = 0
        Dim xl As Integer = 15
        Dim yl As Integer = -15
        Using objCorrida As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
            objDataSet = objCorrida.usp_TraerCorrida("", Txt_Marca.Text, Txt_Estilon.Text, "", "")
        End Using
        If objDataSet.Tables(0).Rows.Count > 0 Then
            For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                y += 40
                x = 15
                yl += 40
                xl = 15
                Dim Corr As String = objDataSet.Tables(0).Rows(i).Item("corrida").ToString.Trim
                Using objCorrida As New BCL.BCLTrackCoqueta(GLB_ConStringCipSis)
                    objDataSetAux = objCorrida.usp_TraerTrackCta(Txt_Marca.Text, Txt_Estilon.Text, Corr)
                End Using
                If objDataSetAux.Tables(0).Rows.Count > 0 Then
                    For j As Integer = 0 To objDataSetAux.Tables(0).Rows.Count - 1
                        Dim chkBox As New CheckBox
                        Dim lblMed As New Label
                        Dim Medida As String = objDataSetAux.Tables(0).Rows(j).Item("medida").ToString
                        lblMed.Text = Medida
                        chkBox.Name = Medida
                        chkBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8)
                        chkBox.Checked = CBool(objDataSetAux.Tables(0).Rows(j).Item("estatus").ToString)
                        chkBox.Text = objDataSetAux.Tables(0).Rows(j).Item("sku").ToString.Trim
                        Panel1.Controls.Add(chkBox)
                        Panel1.Controls.Add(lblMed)
                        chkBox.Location = New System.Drawing.Point(x, y)
                        lblMed.Location = New System.Drawing.Point(xl, yl)
                        x += 110
                        xl += 110
                    Next
                End If
            Next
        End If

    End Sub

    Private Sub RellenaMedidas()
        Using objCorrida As New BCL.BCLTrackCoqueta(GLB_ConStringCipSis)
            objDataSet = objCorrida.usp_TraerCantidadCorridas(Txt_Marca.Text, Txt_Estilon.Text, "")
        End Using
        If objDataSet.Tables(0).Rows.Count > 0 Then
            For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                DGrid.Rows.Add()
                DGrid.Rows(i).Cells("colMedida").Value = objDataSet.Tables(0).Rows(i).Item("medida").ToString
            Next
            DGrid.Columns(0).ReadOnly = True
            DGrid.AllowUserToAddRows = False
        End If
    End Sub

    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Aceptar, "Guardar")
            ToolTip.SetToolTip(Btn_Salir, "Salir")
            ToolTip.SetToolTip(Btn_Check, "Seleccionar Todos")
            ToolTip.SetToolTip(Btn_Uncheck, "Desmarcar Marcas")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub LimpiarDatos()
        Try
            Txt_Marca.Text = ""
            Txt_Estilon.Text = ""
            Txt_Estilof.Text = ""
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub


    Private Sub Txt_Marca_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Marca.LostFocus

        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
            If Txt_Marca.Text.Length = 0 Then Exit Sub

            Try
                Call TxtLostfocus(Txt_Marca, Txt_DescripMarca, "M")
                If Accion = 1 Then
                    objDataSet = objMySqlGral.usp_TraerFolio("EN", Txt_Marca.Text)
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Txt_Estilon.Text = Val(objDataSet.Tables(0).Rows(0).Item("campo").ToString) + 1
                        Txt_Estilon.Text = Txt_Estilon.Text.PadLeft(7)
                    Else
                        Txt_Estilon.Text = "      1"
                    End If
                End If
                Using objMarca As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
                    Dim objDataSet As Data.DataSet

                    objDataSet = objMarca.usp_TraerMarca(Txt_Marca.Text, "")


                End Using
                If Txt_Marca.Text = "OZO" Or Txt_Marca.Text = "OZA" Or Txt_Marca.Text = "FFF" Then

                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using



    End Sub

    Private Sub Txt_Estilon_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Estilon.GotFocus
        Txt_Estilon.SelectAll()
    End Sub

    Private Sub Txt_Estilon_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Estilon.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Estilof_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Estilof.GotFocus
        Txt_Estilof.SelectAll()
    End Sub

    Private Sub Txt_Estilof_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Estilof.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Estilof_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Estilof.LostFocus
        If Accion <> 2 Then
            If Sw_PedidoNuevo = False Then
                Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
                    Try
                        Dim estilof As String = ""
                        estilof = Replace(Txt_Estilof.Text, "-", "")

                        If Txt_Estilof.Text.Length = 0 Then Exit Sub
                        objDataSet = objMySqlGral.usp_TraerDescripcion("EN", Txt_Marca.Text, estilof)

                        If objDataSet.Tables(0).Rows.Count > 0 Then
                            MsgBox("El estilo de fábrica '" & estilof & "' para a marca '" & Txt_Marca.Text & "' ya se encuentra registrado con el estilo nuestro '" & objDataSet.Tables(0).Rows(0).Item("campo").ToString & "'. Con la descripción '" & objDataSet.Tables(0).Rows(0).Item("descripc").ToString & ".", MsgBoxStyle.Information, "Aviso")

                        End If


                    Catch ExceptionErr As Exception
                        MessageBox.Show(ExceptionErr.Message.ToString)
                    End Try
                End Using
            End If
        End If
    End Sub

  
    Private Sub TxtLostfocus(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
        Dim myForm As New frmConsulta
        If Txt_Campo.Text.Length = 0 Then Exit Sub
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
            Try

                objDataSet = objMySqlGral.usp_TraerDescripcion(Tipo, Txt_Campo.Text, "")

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_Campo1.Text = objDataSet.Tables(0).Rows(0).Item("campo").ToString
                Else
                    Txt_Campo.Text = ""
                    myForm.Tipo = Tipo
                    myForm.ShowDialog()
                    Txt_Campo.Text = myForm.Campo
                    Txt_Campo1.Text = myForm.Campo1
                    If Txt_Campo.Text.Length = 0 Then
                        Txt_Campo.Focus()
                    End If
                End If


            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub


    Private Sub Txt_Marca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Marca.TextChanged
        If Txt_Marca.Text.Length = 3 Then
            Txt_Estilof.Focus()
        End If
    End Sub

    Private Sub Txt_Estilon_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Estilon.TextChanged

    End Sub

 

    Private Sub Pnl_Edicion_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Edicion.Paint

    End Sub

    Private Sub usp_TraerEstiloN()
        Try
            Using objCatalogoEstilosC As New BCL.BCLCatalogoEstilosClasif(GLB_ConStringCipSis)
                objDataSet = objCatalogoEstilosC.usp_TraerEstiloN(Txt_Marca.Text, Txt_Estilon.Text)
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub LimpiaComponentes()
        'Txt_Marca.Text = ""
        Txt_DescripMarca.Text = ""
        'Txt_Estilon.Text = ""
        Txt_Estilof.Text = ""
    End Sub

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Try
            Me.Close()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        Try
            If MessageBox.Show("Esta seguro que desea guardar los cambios?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then Exit Sub
            If Opcion = 1 Then
                Dim objDataSetChk As New DataSet
                objDataSetChk.Tables.Clear()
                objDataSetChk.Tables.Add()
                objDataSetChk.Tables(0).Columns.Add("medida")
                objDataSetChk.Tables(0).Columns.Add("estatus")
                Dim contador As Integer = 0
                For Each ctr As Control In Panel1.Controls
                    If TypeOf (ctr) Is CheckBox Then
                        objDataSetChk.Tables(0).Rows.Add()
                        objDataSetChk.Tables(0).Rows(contador).Item("medida") = ctr.Name
                        objDataSetChk.Tables(0).Rows(contador).Item("estatus") = CInt(CType(ctr, CheckBox).Checked) * -1
                        contador += 1
                    End If
                Next
                Dim num As Integer = 16
                Dim Medida As String
                Dim Estatus As String
                Dim blnActualizo As Boolean
                Dim ContGuardados As Integer = 0
                For i As Integer = 0 To objDataSetChk.Tables(0).Rows.Count - 1
                    Medida = objDataSetChk.Tables(0).Rows(i).Item("medida").ToString.Trim
                    Estatus = objDataSetChk.Tables(0).Rows(i).Item("estatus").ToString.Trim
                    Using objCorrida As New BCL.BCLTrackCoqueta(GLB_ConStringCipSis)
                        blnActualizo = objCorrida.usp_ActualizarTrackCta(Txt_Estilon.Text, "", Medida, Estatus)
                    End Using
                    If blnActualizo = True Then
                        ContGuardados += 1
                    End If
                Next
                If ContGuardados > 0 Then
                    MessageBox.Show("Datos Guardados Correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("No se realizo ningun cambio", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
            If Opcion = 2 Then
                Dim SKU As String
                For i As Integer = 0 To DGrid.Rows.Count - 1
                    SKU = ""
                    If DGrid.Rows(i).Cells(1).Value Is Nothing Then
                        MessageBox.Show("Se deben llenar todas las medidas", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                    SKU = CStr(DGrid.Rows(i).Cells(1).Value)
                    If SKU.Trim = "" Then
                        MessageBox.Show("Se deben llenar todas las medidas", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                Next

                Dim Marca As String = Txt_Marca.Text.Trim
                Dim Estilon As String = Txt_Estilon.Text
                Dim Estilof As String = Txt_Estilof.Text
                SKU = ""
                Dim Medida As String = ""
                Dim Estatus As String = ""
                Dim blnGuardo As Boolean = False
                Dim cont As Integer
                For i As Integer = 0 To DGrid.Rows.Count - 1
                    SKU = DGrid.Rows(i).Cells(1).Value.ToString.Trim
                    Medida = DGrid.Rows(i).Cells(0).Value.ToString.Trim
                    Estatus = CInt(DGrid.Rows(i).Cells(2).Value).ToString * -1
                    Using objCatalogoEstilosC As New BCL.BCLTrackCoqueta(GLB_ConStringCipSis)
                        blnGuardo = objCatalogoEstilosC.usp_CapturaTrackCta(SKU, Estilon, Estilof, Medida, Estatus)
                    End Using
                    If blnGuardo = True Then
                        cont += 1
                    End If
                Next
                If cont > 0 Then
                    MessageBox.Show("Trac guardado correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Guardo = True
                    Me.Close()
                Else
                    MessageBox.Show("No se realizo ningun cambio", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellEndEdit
        Try
            If e.ColumnIndex <> 1 Then Exit Sub
            If DGrid.CurrentCell.Value Is Nothing Then Exit Sub
            Dim SKU As String = DGrid.CurrentCell.Value.ToString.Trim
            If SKU = "" Then Exit Sub
            If SKU.Length <> 13 Then
                MessageBox.Show("El codigo SKU debe ser de 13 caracteres", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                DGrid.CurrentCell.Value = ""
            End If
            Using objCatalogoEstilosC As New BCL.BCLTrackCoqueta(GLB_ConStringCipSis)
                objDataSet = objCatalogoEstilosC.usp_TraerSKU(SKU)
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                MessageBox.Show("El codigo SKU ya existe", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                DGrid.CurrentCell.Value = ""
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Check_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Check.Click
        Try
            If Opcion = 1 Then
                For Each ctr As Control In Panel1.Controls
                    If TypeOf (ctr) Is CheckBox Then
                        CType(ctr, CheckBox).Checked = True
                    End If
                Next
            End If
            If Opcion = 2 Then
                For i As Integer = 0 To DGrid.Rows.Count - 1
                    DGrid.Rows(i).Cells(2).Value = True
                Next
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Uncheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Uncheck.Click
        Try
            If Opcion = 1 Then
                For Each ctr As Control In Panel1.Controls
                    If TypeOf (ctr) Is CheckBox Then
                        CType(ctr, CheckBox).Checked = False
                    End If
                Next
            End If
            If Opcion = 2 Then
                For i As Integer = 0 To DGrid.Rows.Count - 1
                    DGrid.Rows(i).Cells(2).Value = False
                Next
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
End Class
