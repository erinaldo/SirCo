Public Class frmCatalogoIncapacidad
    'mreyes 07/Agosto/2012  10:07 a.m.

    Dim Sql As String
    Public Accion As Integer  '' 1  = nuevo, 2 = edicion , 3 = eliminar , 4 = consultar 
    Public Sw_Registro As Boolean = False
    Public Id_SegBit As Integer = 0
    Private objDataSet As Data.DataSet



    Function Inserta_Incapacidad() As Boolean
        'mreyes 07/Agosto/2012 05:00 p.m.

        Using objSigBit As New BCL.BCLCatalogoIncapacidad(GLB_ConStringNomSis)
            'Get a new Project DataSet
            Try
                objDataSet = objSigBit.Inserta_Incapacidad
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow

                'Set the values in the DataRow
                objDataRow.Item("idincapacidad") = Val(Txt_IdINCAPACIDAD.Text)
                objDataRow.Item("idempleado") = Txt_IdEmpleado.Text
                objDataRow.Item("fecha") = DTPicker.Value
                objDataRow.Item("tipo") = Mid(Cbo_Tipo.Text, 1, 1)
                If Cbo_Riesgo.Text = "ACCIDENTE DE TRABAJO" Then
                    objDataRow.Item("riesgo") = "1"
                ElseIf Cbo_Riesgo.Text = "ACCIDENTE DE TRAYECTO" Then
                    objDataRow.Item("riesgo") = "2"
                Else
                    If Cbo_Tipo.Text = "ENFERMEDAD" Or Cbo_Tipo.Text = "MATERNIDAD" Then
                        objDataRow.Item("riesgo") = "1"
                    Else
                        objDataRow.Item("riesgo") = "3"
                    End If

                End If

                If Cbo_Dictamen.Text = "INCAPACIDAD TEMPORAL" Then
                    objDataRow.Item("dictamen") = "T"
                ElseIf Cbo_Dictamen.Text = "INCAPACIDAD PERMANENTE" Then
                    objDataRow.Item("dictamen") = "P"
                Else
                    objDataRow.Item("dictamen") = "D"
                End If

                objDataRow.Item("certificado") = Txt_Certificado.Text
                objDataRow.Item("dias") = Val(Txt_Dias.Text)

                If Cbo_Caso.Text = "INICIAL" Then
                    objDataRow.Item("caso") = "I"
                ElseIf Cbo_Caso.Text = "CONTINUACIÓN" Then
                    objDataRow.Item("caso") = "C"
                Else
                    objDataRow.Item("caso") = "R"
                End If
                objDataRow.Item("descripcion") = Txt_Descripcion.Text
                objDataRow.Item("estatus") = "C"
                objDataRow.Item("usuario") = GLB_Usuario
                objDataRow.Item("usumodif") = GLB_Usuario
                objDataRow.Item("fummodif") = Date.Now

                'Add the DataRow to the DataSet
                objDataSet.Tables(0).Rows.Add(objDataRow)

                'Add the Project
                If Not objSigBit.usp_Captura_Incapacidad(Accion, objDataSet) Then
                    Throw New Exception("Falló Inserción de Incapacidad")
                Else
                    Inserta_Incapacidad = True
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Private Function ValidarEdicion() As Boolean
        'mreyes 07/Agosto/2012 05:39 p.m.
        ValidarEdicion = False
        Try
            If Txt_IdEmpleado.Text.Length = 0 Then
                MsgBox("Debe especificar un empleado.", MsgBoxStyle.Critical, "Validación")
                Txt_IdEmpleado.Focus()
                Exit Function
            End If

            If Txt_Certificado.Text.Length = 0 Then
                MsgBox("Debe especificar el certificado.", MsgBoxStyle.Critical, "Validación")
                Txt_Certificado.Focus()
                Exit Function
            End If

            If txt_descripcion.Text.Length = 0 Then
                MsgBox("Debe especificar algún comentario o descripcion.", MsgBoxStyle.Critical, "Validación")
                Txt_Descripcion.Focus()
                Exit Function
            End If

            If Cbo_Tipo.Text.Length = 0 Then
                MsgBox("Debe especificar el Tipo de Incapacidad.", MsgBoxStyle.Critical, "Validación")
                Cbo_Tipo.Focus()
                Exit Function
            End If

            If Cbo_Riesgo.Text.Length = 0 And Cbo_Riesgo.Enabled = True Then

                MsgBox("Debe especificar el Riesgo de Incapacidad.", MsgBoxStyle.Critical, "Validación")
                Cbo_Tipo.Focus()
                Exit Function
            End If

            If Cbo_Dictamen.Text.Length = 0 Then
                MsgBox("Debe especificar el Tipo de Dictamen.", MsgBoxStyle.Critical, "Validación")
                Cbo_Tipo.Focus()
                Exit Function
            End If

            If Txt_Dias.Text.Length = 0 Then
                MsgBox("Debe especificar los días de Incapacidad.", MsgBoxStyle.Critical, "Validación")
                Txt_Dias.Focus()
                Exit Function
            End If

            ValidarEdicion = True
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Function
    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        'mreyes 07/Agosto/2012 10:51 a.m.
        Try
            If Accion = 1 Then '''' es un articulo nuevo
                If ValidarEdicion() = False Then Exit Sub
                If MsgBox("Estas Seguro de Grabar la Incapacidad ?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    If Inserta_Incapacidad() = True Then

                        MessageBox.Show("Exitosamente Grabado!", "Agregando Incapacidad", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Sw_Registro = True
                        Me.Close()
                        '' Me.Dispose()
                    Else
                        MessageBox.Show("Error Grabando !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    End If
                End If
            ElseIf Accion = 2 Then ' es una actualización
                If ValidarEdicion() = False Then Exit Sub
                If MsgBox("Estas Seguro de Actualizar la Incapacidad?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    If Inserta_Incapacidad() = True Then

                        MessageBox.Show("Exitosamente Grabado!", "Actualizando Incapacidad", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        Try
            'Accion = 1
            If Accion = 1 Then

            Else
                Call usp_TraerIncapacidad()

            End If
            Call GenerarToolTip()
            Call Edicion()

          
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub usp_TraerIncapacidad()
        'mreyes 08/Agosto/2012 11:06 a.m.
        Using objSegBit As New BCL.BCLCatalogoIncapacidad(GLB_ConStringNomSis)
            Try

                objDataSet = objSegBit.usp_TraerIncapacidad(Val(Txt_IdINCAPACIDAD.Text))
                If objDataSet.Tables(0).Rows.Count > 0 Then


                    Txt_IdEmpleado.Text = objDataSet.Tables(0).Rows(0).Item("idempleado").ToString
                    Txt_NombreEmpleado.Text = objDataSet.Tables(0).Rows(0).Item("nomcompleto").ToString
                    DTPicker.Value = objDataSet.Tables(0).Rows(0).Item("fecha")
                    Cbo_Tipo.Text = objDataSet.Tables(0).Rows(0).Item("tipo").ToString
                    Cbo_Riesgo.Text = objDataSet.Tables(0).Rows(0).Item("riesgo").ToString
                    Cbo_Dictamen.Text = objDataSet.Tables(0).Rows(0).Item("dictamen").ToString
                    Txt_Certificado.Text = objDataSet.Tables(0).Rows(0).Item("certificado").ToString
                    Txt_Dias.Text = objDataSet.Tables(0).Rows(0).Item("dias").ToString
                    Txt_Descripcion.Text = objDataSet.Tables(0).Rows(0).Item("descripcion").ToString
                    Cbo_Caso.Text = objDataSet.Tables(0).Rows(0).Item("caso").ToString

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
                        Txt_IdEmpleado.Focus()
                    ElseIf Accion = 2 Then

                        Txt_IdEmpleado.Enabled = False
                        Txt_Certificado.Focus()
                        Call CambiaBackcolor()

                    End If
            End Select
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub CambiaBackcolor()
        Try

            Txt_IdEmpleado.BackColor = TextboxBackColor
            Txt_Certificado.BackColor = TextboxBackColor
            Txt_NombreEmpleado.BackColor = TextboxBackColor
            Txt_Descripcion.BackColor = TextboxBackColor
            Cbo_Caso.BackColor = TextboxBackColor
            Cbo_Dictamen.BackColor = TextboxBackColor
            Cbo_Riesgo.BackColor = TextboxBackColor
            Cbo_Tipo.BackColor = TextboxBackColor

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

    Private Sub Txt_Atiende_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Certificado.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub




    Private Sub Txt_Realiza_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

    Private Sub Txt_Comentarios_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Descripcion.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
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



    Private Sub CargarFormaConsultaEmpleado()
        'mreyes 11/Junio/2012 06:04 p.m.

        Dim myForm As New frmConsultaEmpleado
        Txt_NombreEmpleado.Text = ""
        myForm.Estatus = ""
        myForm.ShowDialog()
        Txt_IdEmpleado.Text = myForm.Campo
        Txt_NombreEmpleado.Text = myForm.Campo1
        If Txt_IdEmpleado.Text.Length = 0 Then
            Txt_IdEmpleado.Focus()
        End If
    End Sub
    Private Sub Txt_IdEmpleado_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_IdEmpleado.LostFocus
        Try
            'mreyes 11/Junio/2012 01:28 p.m.
            If Txt_IdEmpleado.Text.Length = 0 Then Exit Sub


            Using objMySqlGral As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)
                Try
                    If Val(Txt_IdEmpleado.Text) = 0 Then
                        CargarFormaConsultaEmpleado()
                    Else
                        objDataSet = objMySqlGral.usp_TraerNomEmpleado(Val(Txt_IdEmpleado.Text), "", "", "", "", 0)
                        If objDataSet.Tables(0).Rows.Count = 1 Then
                            Txt_NombreEmpleado.Text = objDataSet.Tables(0).Rows(0).Item("nomcompleto").ToString
                        Else
                            Call CargarFormaConsultaEmpleado()
                        End If

                    End If
                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_IdEmpleado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_IdEmpleado.TextChanged

    End Sub

    Private Sub Cbo_Tipo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cbo_Tipo.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Cbo_Tipo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cbo_Tipo.LostFocus
        If Cbo_Tipo.Text = "ENFERMEDAD" Or Cbo_Tipo.Text = "MATERNIDAD" Then
            Cbo_Riesgo.Text = ""
            Cbo_Riesgo.Enabled = False
        Else
            Cbo_Riesgo.Enabled = True
        End If
    End Sub

    Private Sub Cbo_Tipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo_Tipo.SelectedIndexChanged

    End Sub

    Private Sub Txt_Descripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Descripcion.TextChanged

    End Sub

    Private Sub Cbo_Riesgo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cbo_Riesgo.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Cbo_Riesgo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo_Riesgo.SelectedIndexChanged

    End Sub

    Private Sub Cbo_Caso_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cbo_Caso.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Cbo_Caso_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo_Caso.SelectedIndexChanged

    End Sub

    Private Sub Txt_Dias_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Dias.KeyPress
        Call pub_SoloNumeros(sender, e)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Dias_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Dias.TextChanged

    End Sub
End Class