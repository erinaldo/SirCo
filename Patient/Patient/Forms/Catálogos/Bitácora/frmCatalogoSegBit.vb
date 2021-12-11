Public Class frmCatalogoSegBit
    'mreyes 29/Febrero/2012 07:15 p.m.

    Dim Sql As String
    Public Accion As Integer  '' 1  = nuevo, 2 = edicion , 3 = eliminar , 4 = consultar 
    Public Sw_Registro As Boolean = False
    Public Id_SegBit As Integer = 0
    Private objDataSet As Data.DataSet



    Function Inserta_SigBit() As Boolean
        'mreyes 29/Febrero/2012 10:43 a.m.

        Using objSigBit As New BCL.BCLBitacora(Glb_ConStringCipSis)
            'Get a new Project DataSet
            Try
                objDataSet = objSigBit.Inserta_SigBit
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow

                'Set the values in the DataRow
                objDataRow.Item("sucursal") = Txt_Sucursal.Text.ToString.Trim
                objDataRow.Item("ordecomp") = Trim(Txt_OrdeComp.Text)
                objDataRow.Item("marca") = Trim(Txt_Marca.Text)
                objDataRow.Item("estilon") = (Txt_Estilon.Text)
                objDataRow.Item("fecha") = DTPicker.Value
                objDataRow.Item("atiende") = Trim(Txt_Atiende.Text)
                objDataRow.Item("realiza") = Trim(Txt_Realiza.Text)
                objDataRow.Item("motivo") = Trim(Cbo_Motivo.Text)
                objDataRow.Item("comentarios") = Trim(Txt_Comentarios.Text)

                'Add the DataRow to the DataSet
                objDataSet.Tables(0).Rows.Add(objDataRow)

                'Add the Project
                If Not objSigBit.usp_Captura_SegBit(Accion, objDataSet) Then
                    Throw New Exception("Falló Inserción de Proveedor")
                Else
                    Inserta_SigBit = True
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Private Function ValidarEdicion() As Boolean
        'mreyes 03/Marzo/2012 11:23 a.m. 
        ValidarEdicion = False
        Try
            If Txt_OrdeComp.Text.Length = 0 Then
                MsgBox("Debe especificar una Orden de Compra para el seguimiento.", MsgBoxStyle.Critical, "Validación")
                Txt_OrdeComp.Focus()
                Exit Function
            End If

            If Txt_Atiende.Text.Length = 0 Then
                MsgBox("Debe especificar quien atiende.", MsgBoxStyle.Critical, "Validación")
                Txt_Atiende.Focus()
                Exit Function
            End If

            If Txt_Realiza.Text.Length = 0 Then
                MsgBox("Debe especificar quien realiza.", MsgBoxStyle.Critical, "Validación")
                Txt_Realiza.Focus()
                Exit Function
            End If

            If Cbo_Motivo.Text.Length = 0 Then
                MsgBox("Debe especificar el motivo.", MsgBoxStyle.Critical, "Validación")
                Cbo_Motivo.Focus()
                Exit Function
            End If

            If Txt_Comentarios.Text.Length = 0 Then
                MsgBox("Debe especificar el comentario para el seguimiento.", MsgBoxStyle.Critical, "Validación")
                Txt_Comentarios.Focus()
                Exit Function
            End If

            ValidarEdicion = True
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Function
    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        'mreyes 29/Febrero/2012 10:40 a.m.
        Try
            If Accion = 1 Then '''' es un articulo nuevo
                If ValidarEdicion() = False Then Exit Sub
                If MsgBox("Estas Seguro de Grabar el Seguimiento ?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    If Inserta_SigBit() = True Then

                        MessageBox.Show("Exitosamente Grabado!", "Agregando Seguimiento", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Sw_Registro = True
                        Me.Close()
                        '' Me.Dispose()
                    Else
                        MessageBox.Show("Error Grabando !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    End If
                End If
            ElseIf Accion = 2 Then ' es una actualización
                If ValidarEdicion() = False Then Exit Sub
                If MsgBox("Estas Seguro de Actualizar el Seguimiento?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    If Inserta_SigBit() = True Then

                        MessageBox.Show("Exitosamente Grabado!", "Actualizando Seguimiento", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Close()
                        ' Me.Dispose()
                    Else
                        MessageBox.Show("Error Grabando !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

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



    Private Sub frmCatalogoSegBit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then
                If Accion = 1 Or Accion = 2 Then
                    If MessageBox.Show("Estas seguro de cancelar el registro ?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                        Sw_Registro = False
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


    Private Sub frmCatalogoSegBit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'TODO: esta línea de código carga datos en la tabla 'SirCoDataSet1.motsegpedido' Puede moverla o quitarla según sea necesario.
        Me.MotsegpedidoTableAdapter.Fill(Me.SirCoDataSet1.motsegpedido)
        Try
            'Accion = 1
            If Accion = 1 Then

            Else
                Call usp_TraerSegBit()

            End If
            Call GenerarToolTip()
            Call Edicion()

            'Using objMySqlGral As New BCL.BCLMySqlGral(Glb_ConStringPerSis)
            '    If Txt_Sucursal.Text.Length = 0 Then Exit Sub

            '    Try
            '        'Get the specific project selected in the ListView control
            '        If Txt_Sucursal.Text.Trim.Length < 2 Then
            '            Txt_Sucursal.Text = pub_RellenarIzquierda(Txt_Sucursal.Text.Trim, 2)
            '        End If

            '        Call TxtLostfocusPersis(Txt_Sucursal, Txt_DescripSucursal, "S")


            '    Catch ExceptionErr As Exception
            '        MessageBox.Show(ExceptionErr.Message.ToString)
            '    End Try
            'End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub usp_TraerSegBit()
        'mreyes 29/Febrero/2012 07:29 p.m.
        Using objSegBit As New BCL.BCLBitacora(Glb_ConStringCipSis)
            Try

                objDataSet = objSegBit.usp_TraerSegBit(Val(Txt_Id_SegBit.Text), Txt_OrdeComp.Text, Txt_Marca.Text, Txt_Estilon.Text)
                If objDataSet.Tables(0).Rows.Count > 0 Then

                    Txt_Id_SegBit.Text = objDataSet.Tables(0).Rows(0).Item("id_segbit").ToString
                    Txt_OrdeComp.Text = objDataSet.Tables(0).Rows(0).Item("ordecomp").ToString
                    DTPicker.Value = objDataSet.Tables(0).Rows(0).Item("fecha")
                    Txt_Atiende.Text = objDataSet.Tables(0).Rows(0).Item("atiende").ToString
                    Txt_Realiza.Text = objDataSet.Tables(0).Rows(0).Item("realiza").ToString
                    Cbo_Motivo.Text = objDataSet.Tables(0).Rows(0).Item("motivo").ToString
                    Txt_Comentarios.Text = objDataSet.Tables(0).Rows(0).Item("comentarios").ToString
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


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub LimpiarDatos()
        Try

            Txt_OrdeComp.Text = ""

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub






    Private Sub Btn_Nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Accion = 1
            Call Edicion()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub
    Private Sub Edicion()
        Try
            Select Case Accion
                Case 3, 4
                    Btn_Aceptar.Enabled = True
                    Btn_Cancelar.Enabled = True
                    Pnl_Edicion.Enabled = False
                    Pnl_Edicion.Enabled = False

                    Call CambiaBackcolor()

                Case 1, 2
                    Btn_Aceptar.Enabled = True
                    Btn_Cancelar.Enabled = True
                    If Accion = 1 Then
                        Txt_OrdeComp.Focus()
                    ElseIf Accion = 2 Then
                        Txt_Atiende.Focus()
                        Txt_OrdeComp.Enabled = False

                        Call CambiaBackcolor()

                    End If
            End Select
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub CambiaBackcolor()
        Try
            'mreyes 02/Marzo/2012 10:25 a.m.
            Txt_OrdeComp.BackColor = TextboxBackColor
            Txt_Atiende.BackColor = TextboxBackColor
            Txt_Realiza.BackColor = TextboxBackColor
            Txt_Comentarios.BackColor = TextboxBackColor
            Txt_Marca.BackColor = TextboxBackColor
            Txt_Estilon.BackColor = TextboxBackColor
            Txt_DescripMarca.BackColor = TextboxBackColor
            Txt_Sucursal.BackColor = TextboxBackColor
            'Txt_DescripSucursal.BackColor = TextboxBackColor
            Txt_Estilon.BackColor = TextboxBackColor

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Btn_Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Accion = 2
        Call Edicion()
    End Sub


    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Try

            If Accion = 1 Or Accion = 2 Then
                If MessageBox.Show("Estas seguro de cancelar el registro ?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                    'Me.Dispose()
                    Me.Close()
                    Sw_Registro = False
                End If
            Else
                Me.Close()
                Me.Dispose()
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Agente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Atiende_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Atiende.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub




    Private Sub Txt_Realiza_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Realiza.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub



    Private Sub Txt_Motivo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Comentarios_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Comentarios.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

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

    Private Sub Txt_Marca_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Marca.LostFocus
        Using objMySqlGral As New BCL.BCLMySqlGral(Glb_ConStringCipSis)
            If Txt_Marca.Text.Length = 0 Then Exit Sub

            Try
                Call TxtLostfocus(Txt_Marca, Txt_DescripMarca, "M")
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub Txt_Marca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Marca.TextChanged

    End Sub
    Private Sub TxtLostfocusPersis(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
        'mreyes 28/Febrero/2012 01:30
        Dim myForm As New frmConsulta
        If Txt_Campo.Text.Length = 0 Then Exit Sub
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringPerSis)
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

    Private Sub Pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Botones.Paint

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

    Private Sub Txt_Sucursal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Sucursal.KeyPress
        Call pub_SoloNumeros(sender, e)
    End Sub

    Private Sub Txt_Sucursal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Sucursal.LostFocus
        'Using objMySqlGral As New BCL.BCLMySqlGral(Glb_ConStringPerSis)
        '    If Txt_Sucursal.Text.Length = 0 Then Exit Sub

        '    Try
        '        'Get the specific project selected in the ListView control
        '        If Txt_Sucursal.Text.Trim.Length < 2 Then
        '            Txt_Sucursal.Text = pub_RellenarIzquierda(Txt_Sucursal.Text.Trim, 2)
        '        End If

        '        Call TxtLostfocusPersis(Txt_Sucursal, Txt_DescripSucursal, "S")


        '    Catch ExceptionErr As Exception
        '        MessageBox.Show(ExceptionErr.Message.ToString)
        '    End Try
        'End Using
    End Sub
    Private Sub usp_TraerOrdeComp()
        'mreyes 01/Marzo/2012 05:26 p.m.
        Using objPedidos As New BCL.BCLPedidos(Glb_ConStringCipSis)
            Try
                objDataSet = objPedidos.usp_TraerOrdeComp(Txt_Sucursal.Text, Txt_OrdeComp.Text)

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_Marca.Text = objDataSet.Tables(0).Rows(0).Item("marca").ToString
                    Txt_DescripMarca.Text = objDataSet.Tables(0).Rows(0).Item("descripmarca").ToString
                    Txt_Sucursal.Text = objDataSet.Tables(0).Rows(0).Item("sucursal").ToString
                    'Txt_DescripSucursal.Text = objDataSet.Tables(0).Rows(0).Item("descripsucursal").ToString
                End If



                ' LLENAR DETALLADO DE ORDE COMP
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub Txt_OrdeComp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_OrdeComp.KeyPress



    End Sub

    Private Sub Txt_OrdeComp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_OrdeComp.LostFocus
        If Txt_OrdeComp.Text.Length = 0 Then Exit Sub
        Txt_OrdeComp.Text.PadLeft(6)
        Call usp_TraerOrdeComp()
    End Sub

    Private Sub Txt_OrdeComp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_OrdeComp.TextChanged

    End Sub

    Private Sub Txt_Estilon_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Estilon.LostFocus
        Txt_Estilon.Text = Txt_Estilon.Text.PadLeft(7)
    End Sub

    Private Sub Txt_Estilon_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Estilon.TextChanged

    End Sub
End Class