Public Class frmCatalogoMarca
    'mreyes 05/Mayo/2012 09:13 a.m. 

    Dim Sql As String
    Public Accion As Integer  '' 1  = nuevo, 2 = edicion , 3 = eliminar , 4 = consultar 
    Public Sw_Registro As Boolean = False
    Private objDataSet As Data.DataSet
    Private objDataSetSuc As Data.DataSet
    Dim Costo As Decimal = 0
    Public Sw_PedidoNuevo As Boolean = False


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

    Function Inserta_Marca() As Boolean
        'mreyes 05/Mayo/2012 09:28 a.m.
        Dim objDataSet As Data.DataSet
        Using objCatalogoMarca As New BCL.BCLCatalogoMarca(GLB_ConStringCipSis)
            'Get a new Project DataSet
            Try
                objDataSet = objCatalogoMarca.Inserta_Marca  'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow

                'Set the values in the DataRow

                objDataRow.Item("marca") = Trim(Txt_Marca.Text)
                objDataRow.Item("DESCRIP") = Trim(Txt_DescripMarca.Text)
                objDataRow.Item("factor") = 0
                objDataRow.Item("resmin") = 0

                'Add the DataRow to the DataSet
                objDataSet.Tables(0).Rows.Add(objDataRow)

                'Add the Project
                objCatalogoMarca.usp_Captura_Marca(Accion, objDataSet)
                'If Not objCatalogoMarca.usp_Captura_Marca(Accion, objDataSet) Then
                '    Throw New Exception("Falló Inserción de Artículo")
                'Else
                Inserta_Marca = True
                'End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    'Function Inserta_CostosxMarca() As Boolean
    '    Try
    '        'mreyes 05/Mayo/2012 10:22 a.m.
    '        Dim Sw_ExisteCorrida As Boolean

    '        Dim Concepto As String
    '        For I As Integer = 0 To DGrid.Rows.Count - 2
    '            If DGrid.Rows(I).Cells(0).Value.ToString.Length = 0 Then Exit Function
    '            Using objCatalogoEstilos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
    '                'Get a new Project DataSet
    '                Try
    '                    Concepto = (DGrid.Rows(I).Cells(0).Value)

    '                    If Accion = 2 Then
    '                        Using objCorrida As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)

    '                            objDataSet = objCorrida.usp_TraerCostosxMarca(Txt_Marca.Text, Concepto)

    '                            If objDataSet.Tables(0).Rows.Count > 0 Then
    '                                Sw_ExisteCorrida = True

    '                            Else
    '                                Sw_ExisteCorrida = False
    '                            End If
    '                        End Using
    '                    End If
    '                    objDataSet = objCatalogoEstilos.Inserta_CostosxMarca  'INSERTA NUEVO DATASET
    '                    Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow


    '                    objDataRow.Item("marca") = Trim(Txt_Marca.Text)
    '                    objDataRow.Item("orden") = pub_RellenarIzquierda(I + 1, 6)
    '                    objDataRow.Item("concepto") = DGrid.Rows(I).Cells(0).Value.ToString
    '                    objDataRow.Item("porcent") = Val(DGrid.Rows(I).Cells(1).Value.ToString)

    '                    'Add the DataRow to the DataSet
    '                    objDataSet.Tables(0).Rows.Add(objDataRow)

    '                    'Add the Project
    '                    If Sw_ExisteCorrida = True Then
    '                        If Not objCatalogoEstilos.usp_Captura_CostosxMarca(2, objDataSet) Then
    '                            If Accion <> 2 Then
    '                                Throw New Exception("Falló Inserción de Costos por marca")
    '                            End If
    '                        End If
    '                    Else
    '                        If Not objCatalogoEstilos.usp_Captura_CostosxMarca(1, objDataSet) Then
    '                            If Accion <> 2 Then
    '                                Throw New Exception("Falló Inserción de Costos por marca")
    '                            End If
    '                        End If
    '                    End If
    '                    objDataSet.Dispose()
    '                    objDataRow.Table.Dispose()


    '                Catch ExceptionErr As Exception
    '                    MessageBox.Show(ExceptionErr.Message.ToString)
    '                End Try
    '            End Using

    '        Next
    '        Inserta_CostosxMarca = True
    '    Catch ExceptionErr As Exception
    '        MessageBox.Show(ExceptionErr.Message.ToString)
    '    End Try
    'End Function

    Private Sub GuardaProvCosto()
        'Tony Garcia - 12/Marzo/2013 11:36 a.m.
        Dim Opcion As Integer = 0

        Try

            If Accion = 1 Then
                Opcion = 1
                For i As Integer = 0 To DGrid2.Rows.Count - 2
                    Dim strProveedor As String = ""
                    Dim strMarca As String = ""
                    Dim decCosto As Decimal = 0

                    strProveedor = DGrid2.Rows(i).Cells("col_Proveedor").Value.ToString
                    strMarca = Txt_Marca.Text
                    decCosto = DGrid2.Rows(i).Cells("col_CostoProm").Value.ToString

                    Using objCatalogoMarca As New BCL.BCLCatalogoMarca(GLB_ConStringCipSis)
                        objCatalogoMarca.usp_Captura_MarcaProvCosto(Opcion, strMarca, strProveedor, decCosto, GLB_Idempleado)
                    End Using
                Next

            ElseIf Accion = 2 Then

                Opcion = 2


                Using objCatalogoMarca As New BCL.BCLCatalogoMarca(GLB_ConStringCipSis)
                    objCatalogoMarca.usp_Captura_MarcaProvCosto(Opcion, Txt_Marca.Text, "", 0, GLB_Idempleado)
                End Using


                Opcion = 1

                For i As Integer = 0 To DGrid2.Rows.Count - 2
                    Dim strProveedor As String = ""
                    Dim strMarca As String = ""
                    Dim decCosto As Decimal = 0

                    strProveedor = DGrid2.Rows(i).Cells("col_Proveedor").Value.ToString
                    strMarca = Txt_Marca.Text
                    decCosto = DGrid2.Rows(i).Cells("col_CostoProm").Value.ToString

                    Using objCatalogoMarca As New BCL.BCLCatalogoMarca(GLB_ConStringCipSis)
                        objCatalogoMarca.usp_Captura_MarcaProvCosto(Opcion, strMarca, strProveedor, decCosto, GLB_Idempleado)
                    End Using
                Next

            End If
            
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    'Private Sub usp_TraerCostosxMarca()
    '    'mreyes 05/Mayo/2012 09:36 a.m.
    '    Dim objDataSet As Data.DataSet
    '    Using objCatalogoEstilos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
    '        Try

    '            objDataSet = objCatalogoEstilos.usp_TraerCostosxMarca(Txt_Marca.Text, "")

    '            If objDataSet.Tables(0).Rows.Count > 0 Then
    '                For I As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1


    '                    DGrid.Rows.Add(objDataSet.Tables(0).Rows(I).Item(2).ToString, _
    '                                     objDataSet.Tables(0).Rows(I).Item(3).ToString)

    '                    Txt_PorcentajeNeto.Text = 100 - (-1 * objDataSet.Tables(0).Rows(I).Item(3).ToString)
    '                Next

    '            End If


    '        Catch ExceptionErr As Exception
    '            MessageBox.Show(ExceptionErr.Message.ToString)
    '        End Try
    '    End Using
    'End Sub

    Private Function ValidarEdicion() As Boolean
        'mreyes 03/Marzo/2012 11:23 a.m. 
        ValidarEdicion = False
        Try
            If Txt_Marca.Text.Length = 0 Then
                MsgBox("Debe especificar una marca para el Estilo.", MsgBoxStyle.Critical, "Validación")
                Txt_Marca.Focus()
                Exit Function
            End If

    
            If Txt_DescripMarca.Text.Length = 0 Then
                MsgBox("Debe especificar una descripción para la Marca.", MsgBoxStyle.Critical, "Validación")
                Txt_DescripMarca.Focus()
                Exit Function
            End If

          

            ' validar corrida 
            'With DGrid
            '    If .Rows(0).Cells(0).Value = "" Then
            '        MsgBox("Debe especificar almenos una condición para la marca.", MsgBoxStyle.Critical, "Validación")
            '        DGrid.Focus()
            '        Exit Function
            '    End If
            'End With

            ValidarEdicion = True
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Function

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click

        Try
            If Accion = 1 Then '''' es un articulo nuevo
                If ValidarEdicion() = False Then Exit Sub
                If MsgBox("Estas Seguro de Grabar la Marca?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    If Inserta_Marca() = True Then
                        'If Inserta_CostosxMarca() = True Then
                        Call GuardarDetalleSucursal()

                        MessageBox.Show("Exitosamente Grabada la Marca '" & Txt_Marca.Text & " !", "Agregando Marca", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Sw_Registro = True
                        Me.Close()
                        '' Me.Dispose()
                    Else
                        MessageBox.Show("Error Grabando !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        'End If
                    End If
                End If
            ElseIf Accion = 2 Then ' es una actualización
                If ValidarEdicion() = False Then Exit Sub
                If MsgBox("Estas Seguro de Actualizar la Marca?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    If Inserta_Marca() = True Then
                        'If Inserta_CostosxMarca() = True Then
                        Call GuardarDetalleSucursal()
                        Sw_Registro = True
                        Call GuardaProvCosto()
                        MessageBox.Show("Exitosamente Grabada la marca '" & Txt_Marca.Text & " !", "Agregando Marca", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Close()
                        ' Me.Dispose()
                    Else
                        MessageBox.Show("Error Grabando !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        'End If
                        GLB_RefrescarPedido = True
                    End If
                End If
            ElseIf Accion = 4 Then
                Me.Close()
                Me.Dispose()
            End If '' del if de accion = 1 

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    'Private Sub validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    '' FUNCION PARA SOLO ESCRIBIR LETRAS EN UN DATAGRID 
    '    Try
    '        ' obtener indice de la columna  
    '        If Accion = 3 Or Accion = 4 Then
    '            e.KeyChar = Chr(0)
    '            Exit Sub
    '        End If
    '        e.KeyChar = UCase(e.KeyChar)
    '        Dim columna As Integer = DGrid.CurrentCell.ColumnIndex
    '        Dim caracter As Char = e.KeyChar
    '        ' comprobar si la celda en edición corresponde a la columna 1 o 3   


    '        If columna >= 1 And columna <= 1 Then

    '            If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False And Not (caracter = ".") And Not (caracter = "-") Then
    '                e.KeyChar = Chr(0)
    '            End If
    '        End If

    '    Catch ExceptionErr As Exception
    '        MessageBox.Show(ExceptionErr.Message.ToString)
    '    End Try
    'End Sub

    Private Sub DGrid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    'Private Sub DGrid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    '    'mreyes 23/Febrero/2012 11:40 a.m.
    '    Try
    '        Dim columna As Integer = DGrid.CurrentCell.ColumnIndex
    '        Dim renglon As Integer = DGrid.CurrentCell.RowIndex


    '    Catch ExceptionErr As Exception
    '        MessageBox.Show(ExceptionErr.Message.ToString)
    '    End Try
    'End Sub


    'Private Sub DGrid_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs)
    '    Dim validar As TextBox = CType(e.Control, TextBox)
    '    Try
    '        ' agregar el controlador de eventos para el KeyPress   

    '        AddHandler validar.KeyPress, AddressOf validar_Keypress
    '    Catch ExceptionErr As Exception
    '        MessageBox.Show(ExceptionErr.Message.ToString)
    '    End Try
    'End Sub

    Private Sub frmCatalogoEstilos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then
                If Accion = 1 Or Accion = 2 Then
                    If MessageBox.Show("Estas seguro de cancelar el registro ?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                        Me.Dispose()
                        Me.Close()

                    End If
                Else
                    Me.Dispose()
                    Me.Close()
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmCatalogoEstilos_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave

    End Sub

    Private Sub frmCatalogoEstilos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Call RellenaGridSuc()
            Call MarcaCeldasGridSuc()
            Call InicializaGridProv()

            If Accion = 1 Then
                ' LimpiarDatos()
            Else
                Call usp_TraerMarca()
                'Call usp_TraerCostosxMarca()
                Call usp_TraerDetSucArtMarca(Txt_Marca.Text)
                Call usp_Traer_MarcaProvCosto(Txt_Marca.Text)
            End If
            Call GenerarToolTip()

            'DGrid.RowHeadersVisible = False
            Call Edicion()

            'For j As Integer = 0 To DgridSuc.Rows.Count - 2

            '    DgridSuc.Rows(j).Cells("Selec").Value = 1

            'Next

            'DgridSucur.Refresh()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Sub InicializaGridProv()
        DGrid2.RowHeadersVisible = False
        ''DGrid.AllowUserToResizeColumns = True


        DGrid2.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGrid2.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DGrid2.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


        DGrid2.Columns(2).DefaultCellStyle.Format = "c"

        'Call AgregarColumna()

        DGrid2.Columns(1).ReadOnly = True

        DGrid2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    End Sub

    Private Sub usp_TraerDetSucArtMarca(ByVal Marca As String)

        Try
            'Tbc_Marca.SelectedIndex = 1
            Using objCatalogoEst As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                objDataSetSuc = objCatalogoEst.usp_TraerDetSucArtMarca(Marca)

                If objDataSetSuc.Tables(0).Rows.Count > 0 Then

                    For i As Integer = 0 To DgridSucur.Rows.Count - 1
                        If DgridSucur.Rows(i).Cells("Selec").Value = True Then
                            DgridSucur.Rows(i).Cells("Selec").Value = False
                        End If
                    Next

                    For i As Integer = 0 To objDataSetSuc.Tables(0).Rows.Count - 1
                        For j As Integer = 0 To DgridSucur.Rows.Count - 1
                            If DgridSucur.Rows(j).Cells("sucursal").Value = objDataSetSuc.Tables(0).Rows(i).Item("sucursal").ToString Then
                                DgridSucur.Rows(j).Cells("Selec").Value = True
                                'DgridSuc.Rows(j).Cells("precio").Value = objDataSetSuc.Tables(0).Rows(i).Item("precio")
                            End If
                        Next
                    Next
                End If


                If Accion = 3 Or Accion = 4 Then
                    DgridSucur.Columns(2).ReadOnly = True
                End If
            End Using

            'Tbc_Marca.SelectedIndex = 0
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub




    Private Sub GuardarDetalleSucursal()
        Dim Opcion As Integer = 0
        Try

            If Accion = 1 Then
                Opcion = 1
                For i As Integer = 0 To DgridSucur.Rows.Count - 1

                    If DgridSucur.Rows(i).Cells("selec").Value = True Then
                        Dim Sucursal As String = DgridSucur.Rows(i).Cells("sucursal").Value.ToString
                        Dim Marca As String = Txt_Marca.Text

                        Using objCatalogoEst As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                            objCatalogoEst.usp_Captura_DetSucArtMarca(Opcion, Sucursal, Marca, "", GLB_Idempleado)
                        End Using

                    End If
                Next

            ElseIf Accion = 2 Then

                Opcion = 2

                Dim Marca As String = Txt_Marca.Text

                'objDataSetSuc = objCatalogoEst.usp_TraerDetSucArtMarca(Marca)
                'If objDataSetSuc.Tables(0).Rows.Count > 0 Then

                For i As Integer = 0 To DgridSucur.Rows.Count - 2
                    If DgridSucur.Rows(i).Cells("Selec").Value = False Then

                        Dim Sucursal As String = DgridSucur.Rows(i).Cells("sucursal").Value.ToString
                        Using objCatalogoEst As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                            objCatalogoEst.usp_Captura_DetSucArtMarca(Opcion, Sucursal, Marca, "", GLB_Idempleado)
                        End Using

                    End If
                Next
                'End If

                Opcion = 1


               

                For i As Integer = 0 To DgridSucur.Rows.Count - 1
                    If DgridSucur.Rows(i).Cells("Selec").Value = True Then

                        Using objCatalogoEst As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)

                            objDataSet = objCatalogoEst.usp_TraerSucMarca(Txt_Marca.Text, DgridSucur.Rows(i).Cells("sucursal").Value)

                            If objDataSet.Tables(0).Rows.Count > 0 Then
                            Else
                                If DgridSucur.Rows(i).Cells("Selec").Value = True Then

                                    Dim Sucursal As String = DgridSucur.Rows(i).Cells("sucursal").Value

                                    objCatalogoEst.usp_Captura_DetSucArtMarca(Opcion, Sucursal, Marca, "", GLB_Idempleado)

                                End If
                            End If
                        End Using
                    End If
                Next
                
               

                'For i As Integer = 0 To DgridSucur.Rows.Count - 1
                '    blnExiste = False
                '    For j As Integer = 0 To objDataSetSuc.Tables(0).Rows.Count - 1

                '        If DgridSucur.Rows(i).Cells("Selec").Value = True Then

                '            If DgridSucur.Rows(i).Cells("sucursal").Value = objDataSetSuc.Tables(0).Rows(j).Item("sucursal") Then
                '                blnExiste = True
                '            End If

                '            If blnExiste = True Then
                '                Continue For
                '            Else
                '                'Dim Sucursal As String = DgridSucur.Rows(i).Cells("sucursal").Value.ToString

                '                'Using objCatalogoEst As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
                '                '    objCatalogoEst.usp_Captura_DetSucArtMarca(Opcion, Sucursal, Marca, "", GLB_Idempleado)
                '                'End Using
                '            End If

                '        End If
                '    Next
                'Next
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub usp_TraerMarca()
        '05/Mayo/2012 09:23 a.m.
        Using objCatalogoEstilos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
            Try


                objDataSet = objCatalogoEstilos.usp_TraerMarca(Txt_Marca.Text, Txt_DescripMarca.Text)

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_Marca.Text = objDataSet.Tables(0).Rows(0).Item("marca").ToString
                    Txt_DescripMarca.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                    'Txt_Factor.Text = objDataSet.Tables(0).Rows(0).Item("factor").ToString
                    'Txt_Resmin.Text = objDataSet.Tables(0).Rows(0).Item("resmin").ToString
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub
    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Aceptar, "Aceptar la acción requerida por el usuario")
            ToolTip.SetToolTip(Btn_Cancelar, "Cancelar cualquier acción requerida por el usuario")
            ToolTip.SetToolTip(Btn_Nuevo, "Nuevo Artículo")
            ToolTip.SetToolTip(Btn_Editar, "Editar Artículo")
            'ToolTip.SetToolTip(DGrid, "Detallado de corridas del Artículo")


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub LimpiarDatos()
        Try
            Txt_Marca.Text = ""
            Txt_DescripMarca.Text = ""
            'Txt_Factor.Text = ""
            'Txt_Resmin.Text = ""
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub


    Private Sub TxtLostfocus(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
        Dim myForm As New frmConsulta
        If Txt_Campo.Text.Length = 0 Then Exit Sub
        Using objMySqlGral As New BCL.BCLMySqlGral(Glb_ConStringCipSis)
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

    Private Sub Edicion()
        Try
            Select Case Accion
                Case 3, 4
                    Btn_Aceptar.Enabled = True
                    Btn_Cancelar.Enabled = True
                    Btn_Nuevo.Enabled = True
                    Btn_Editar.Enabled = True
                    Btn_MarcarTodos.Enabled = False

                    Pnl_Edicion.Enabled = False
                    Panel4.Enabled = False
                    DgridSucur.Columns(2).ReadOnly = True

                    Txt_Marca.BackColor = TextboxBackColor
                    Txt_Marca.BackColor = TextboxBackColor
                    'Txt_Factor.BackColor = TextboxBackColor
                    Txt_DescripMarca.BackColor = TextboxBackColor
                    'Txt_Resmin.BackColor = TextboxBackColor



                Case 1, 2
                    Btn_Aceptar.Enabled = True
                    Btn_Cancelar.Enabled = True
                    Btn_Nuevo.Enabled = False
                    Btn_Editar.Enabled = False

                    'Pnl_Grid.Enabled = True
                    'Pnl_Grid.Enabled = True
                    If Accion = 1 Then
                        Txt_Marca.Focus()
                    ElseIf Accion = 2 Then
                        Txt_DescripMarca.Focus()

                        Txt_Marca.Enabled = False

                    End If
            End Select
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub Btn_Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar.Click
        Accion = 2
        Call Edicion()
    End Sub



    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Try

            If Accion = 1 Or Accion = 2 Then
                If MessageBox.Show("Estas seguro de cancelar el registro ?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                    'Me.Dispose()
                    Me.Close()
                End If
            Else
                Me.Close()
                Me.Dispose()
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub DGrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)


        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Function Eliminar_Medida(ByVal Marca As String, ByVal Estilon As String, ByVal corrida As String) As Boolean
        'mreyes 23/Febrero/2012 03:47 p.m.
        'marca, estilo, medida, corrida
        Using objCatalogoEstilos As New BCL.BCLCatalogoEstilos(Glb_ConStringCipSis)
            Try
                'Get the specific project selected in the ListView control
                Eliminar_Medida = objCatalogoEstilos.usp_EliminarMedida(Marca, Estilon, corrida)
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Private Sub Pnl_Foto_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub Txt_Marca_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Marca.LostFocus
        Try
            If Txt_Marca.Text.Length < 3 Then Exit Sub

            Using objCatalogoEstilos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
                Try
                    objDataSet = objCatalogoEstilos.usp_TraerMarca(Txt_Marca.Text, Txt_DescripMarca.Text)

                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        MessageBox.Show("La clave '" & Txt_Marca.Text & "' para la marca '" & objDataSet.Tables(0).Rows(0).Item("descrip").ToString & "' ya esta registrada.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Hand)

                        Txt_Marca.Text = ""
                        Txt_Marca.Focus()
                    End If
                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub





    Private Sub Txt_Marca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Marca.TextChanged
        If Txt_Marca.Text.Length = 3 Then
            Txt_DescripMarca.Focus()
        End If
    End Sub

    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub Txt_Factor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Txt_DescripMarca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_DescripMarca.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub Txt_DescripMarca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_DescripMarca.TextChanged

    End Sub

    Private Sub RellenaGridSuc()
        Dim SqlWhere As String = ""
        Call TraerSucursales()
    End Sub

    Private Sub MarcaCeldasGridSuc()
        Try
            For i As Integer = 0 To DgridSucur.Rows.Count - 2
                DgridSucur.Rows(i).Cells("Selec").Value = True
            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Sub InicializaGridSucursales()
        DgridSucur.RowHeadersVisible = False
        ''DGrid.AllowUserToResizeColumns = True


        DgridSucur.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DgridSucur.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'DgridSuc.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'DgridSuc.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        'DgridSuc.Columns(3).DefaultCellStyle.Format = "c"

        Call AgregarColumna()

        'DgridSuc.Columns(3).ReadOnly = False
        DgridSucur.Columns(0).ReadOnly = True
        DgridSucur.Columns(1).ReadOnly = True

        DgridSucur.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    End Sub

    Private Sub TraerSucursales()
        Using objSucursal As New BCL.BCLPersis(GLB_ConStringPerSis)
            Try
                'Me.Text = "Buscar Sucursal"

                objDataSetSuc = objSucursal.usp_TraerSucursalSel("")
                'Populate the Project Details section
                'DGrid.ReadOnly = True
                DgridSucur.DataSource = Nothing
                DgridSucur.DataSource = objDataSetSuc.Tables(0)

                'Precio = DGrid.SelectedRows(0).Cells("precio").Value

                'DgridSuc.Columns.Add("corrida", "C")
                'DgridSuc.Columns.Add("precio", "Precio Público")
                'Precio = DGrid.Rows(0).Cells("precio").Value

                InicializaGridSucursales()

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub


    Private Sub AgregarColumna()
        'mreyes 21/Marzo/2012 09:52 a.m.

        Dim colImagen As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        colImagen.Name = "Selec"
        colImagen.HeaderText = "Selec"
        colImagen.DisplayIndex = 2

        colImagen.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        colImagen.CellTemplate = New DataGridViewCheckBoxCell()
        ' añadir columna de imagen a la coleccion del grid 
        DgridSucur.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        ''DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
        'For i As Integer = 0 To DgridSuc.Rows.Count - 1
        Me.DgridSucur.Columns.Add(colImagen)
        'Next
    End Sub

    Private Sub Btn_MarcarTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_MarcarTodos.Click
        Try
            'For i As Integer = 0 To DgridSuc.Rows.Count - 2
            '    If DgridSuc.Rows(i).Cells("Selec").Value = False Then
            '        DgridSuc.Rows(i).Cells("Selec").Value = True
            '    End If
            'Next
            For i As Integer = 0 To DgridSucur.Rows.Count - 2
                If DgridSucur.Rows(i).Cells("Selec").Value = True Then
                    DgridSucur.Rows(i).Cells("Selec").Value = False
                Else
                    DgridSucur.Rows(i).Cells("Selec").Value = True
                End If
            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid2_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid2.CellEndEdit
        Try
            If Accion = 3 Or Accion = 4 Then Exit Sub

            If Me.DGrid2.Columns(e.ColumnIndex).Name = "col_Proveedor" Then

                Dim strProveedor As String = ""


BRINCO:
                If DGrid2.Rows(DGrid2.CurrentRow.Index).Cells("col_Proveedor").Value = Nothing Then Exit Sub
                If DGrid2.Rows(DGrid2.CurrentRow.Index).Cells("col_Proveedor").Value.ToString.Length = 0 Then Exit Sub
                If DGrid2.Rows(DGrid2.CurrentRow.Index).Cells("col_Proveedor").Value.ToString.Length < 3 Then
                    strProveedor = pub_RellenarIzquierda(DGrid2.Rows(DGrid2.CurrentRow.Index).Cells("col_Proveedor").Value.ToString.Trim, 3)
                End If

                strProveedor = DGrid2.Rows(DGrid2.CurrentRow.Index).Cells("col_Proveedor").Value

                Using objProveedores As New BCL.BCLCatalogoProveedores(GLB_ConStringCipSis)

                    If strProveedor.Length > 3 Then
                        DGrid2.Rows(DGrid2.CurrentRow.Index).Cells("col_Proveedor").Value = ""
                        DGrid2.Rows(DGrid2.CurrentRow.Index).Cells("col_Descripcion").Value = ""
                        strProveedor = ""
                        Exit Sub
                    End If

                    objDataSet = objProveedores.usp_TraerProveedorMarca(strProveedor)

                    If objDataSet.Tables(0).Rows.Count > 0 Then

                        If objDataSet.Tables(0).Rows(0).Item("status").ToString = "BA" Then
                            If MsgBox("El proveedor se encuentra dado de BAJA.", MsgBoxStyle.Exclamation, "Datos Proveedor") Then

                                DGrid2.Rows(DGrid2.CurrentRow.Index).Cells("col_Proveedor").Value = ""
                                strProveedor = ""
                                Exit Sub
                            End If
                        End If

                        DGrid2.Rows(DGrid2.CurrentRow.Index).Cells("col_Descripcion").Value = objDataSet.Tables(0).Rows(0).Item("raz_soc").ToString
                        DGrid2.Rows(DGrid2.CurrentRow.Index).Cells("col_CostoProm").Value = 0.0

                        For i As Integer = 0 To DgridSucur.Rows.Count - 2
                            If DgridSucur.Rows(i).Cells("Selec").Value = True Then
                                DgridSucur.Rows(i).Cells("Selec").Value = False
                            Else
                                DgridSucur.Rows(i).Cells("Selec").Value = True
                            End If
                        Next

                    Else
                        Dim myForm As New frmConsulta
                        myForm.Tipo = "P"
                        myForm.ShowDialog()

                        If myForm.Campo <> "" Then
                            DGrid2.Rows(DGrid2.CurrentRow.Index).Cells("col_Proveedor").Value = myForm.Campo

                            DGrid2.Rows(DGrid2.CurrentRow.Index).Cells("col_Descripcion").Value = myForm.Campo1
                            If DGrid2.Rows(DGrid2.CurrentRow.Index).Cells("col_Proveedor").Value.ToString.Length = 0 Then
                                DGrid2.Rows(DGrid2.CurrentRow.Index).Cells("col_Proveedor").Value.Focus()
                            Else
                                GoTo BRINCO
                            End If
                        Else
                            DGrid2.Rows(DGrid2.CurrentRow.Index).Cells("col_Proveedor").Value = ""
                        End If

                    End If
                End Using


            ElseIf Me.DGrid2.Columns(e.ColumnIndex).Name = "col_CostoProm" Then

                DGrid2.CurrentCell.Value = "$" + Format(CDec(DGrid2.CurrentCell.Value), "#,##0.00")

            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub validar_Keypress2(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        '' FUNCION PARA SOLO ESCRIBIR LETRAS EN UN DATAGRID 
        Try
            ' obtener indice de la columna  
            If Accion = 3 Or Accion = 4 Then
                e.KeyChar = Chr(0)
                Exit Sub
            End If
            e.KeyChar = UCase(e.KeyChar)
            Dim columna As Integer = DGrid2.CurrentCell.ColumnIndex
            Dim caracter As Char = e.KeyChar
            ' comprobar si la celda en edición corresponde a la columna 1 o 3   


            If columna = 0 Or columna = 2 Then

                If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False And Not (caracter = ".") Then
                    e.KeyChar = Chr(0)
                End If
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid2_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGrid2.EditingControlShowing
        Dim validar As TextBox = CType(e.Control, TextBox)
        Try
            AddHandler validar.KeyPress, AddressOf validar_Keypress2
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub usp_Traer_MarcaProvCosto(ByVal Marca As String)
        Dim Proveedor As String
        Dim Raz_soc As String
        Dim Costo As Decimal

        Try

            Using objCatalogoMarca As New BCL.BCLCatalogoMarca(GLB_ConStringCipSis)
                objDataSet = objCatalogoMarca.usp_Traer_MarcaProvCosto(Marca)

                If objDataSet.Tables(0).Rows.Count > 0 Then

                    For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                        Proveedor = objDataSet.Tables(0).Rows(i).Item("proveedor")
                        Raz_soc = objDataSet.Tables(0).Rows(i).Item("raz_soc")
                        Costo = Val(objDataSet.Tables(0).Rows(i).Item("costo"))

                        DGrid2.Rows.Add(objDataSet.Tables(0).Rows(i).Item(1).ToString, _
                                        objDataSet.Tables(0).Rows(i).Item(2).ToString, _
                                        Val(objDataSet.Tables(0).Rows(i).Item(3)))

                    Next
                End If
            End Using

            '    objDataSetSuc = objCatalogoEst.usp_TraerDetSucArt(Marca, Estilon, Corrida)

            '    If objDataSetSuc.Tables(0).Rows.Count > 0 Then

            '        For i As Integer = 0 To DgridSuc.Rows.Count - 2
            '            If DgridSuc.Rows(i).Cells("Selec").Value = True Then
            '                DgridSuc.Rows(i).Cells("Selec").Value = False
            '            End If
            '        Next

            '        For i As Integer = 0 To objDataSetSuc.Tables(0).Rows.Count - 1
            '            For j As Integer = 0 To DgridSuc.Rows.Count - 2
            '                If DgridSuc.Rows(j).Cells("sucursal").Value = objDataSetSuc.Tables(0).Rows(i).Item("sucursal").ToString Then
            '                    DgridSuc.Rows(j).Cells("Selec").Value = True
            '                    DgridSuc.Rows(j).Cells("precio").Value = objDataSetSuc.Tables(0).Rows(i).Item("precio")
            '                End If
            '            Next
            '        Next
            '    End If

            'End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub DGrid2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGrid2.KeyDown
        Try
            If (e.KeyCode = Keys.Delete) Then
                If Accion = 1 Or Accion = 2 Then
                    If DGrid2.Rows(DGrid2.CurrentRow.Index).Cells("col_Proveedor").Value <> "" Then
                        If MessageBox.Show("Está seguro de borrar el proveedor?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then

                            DGrid2.Rows().Remove(DGrid2.CurrentRow)

                        End If
                    End If
                Else
                    Me.Dispose()
                    Me.Close()
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    'Private Sub Tbc_Marca_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        If Accion = 1 Or Accion = 2 Then Exit Sub

    '        If Accion = 3 Or Accion = 4 Then
    '            If Tbc_Marca.SelectedIndex = 1 Then
    '                DgridSucur.Columns(2).ReadOnly = True
    '            End If
    '        End If

    '    Catch ExceptionErr As Exception
    '        MessageBox.Show(ExceptionErr.Message.ToString)
    '    End Try
    'End Sub

    'Private Sub Tbc_Marca_TabIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        If Accion = 1 Or Accion = 2 Then Exit Sub

    '        If Accion = 3 Or Accion = 4 Then
    '            If Tbc_Marca.SelectedIndex = 1 Then
    '                DgridSucur.Columns(2).ReadOnly = True
    '            End If
    '        End If

    '    Catch ExceptionErr As Exception
    '        MessageBox.Show(ExceptionErr.Message.ToString)
    '    End Try
    'End Sub

   
    Private Sub DGrid2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid2.CellContentClick

    End Sub
End Class
