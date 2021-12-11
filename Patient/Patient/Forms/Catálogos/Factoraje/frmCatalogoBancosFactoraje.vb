Public Class frmCatalogoBancosFactoraje
    'mreyes 31/Octubre/2014 04:36 p.m. 

    Dim Sql As String
    Public Accion As Integer  '' 1  = nuevo, 2 = edicion , 3 = eliminar , 4 = consultar 
    Public Sw_Registro As Boolean = False
    Private objDataSet As Data.DataSet
    Dim Costo As Decimal = 0
    Public IdBancoB As Integer = 0



    Private Sub Txt_Marca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Function Inserta_Tarjetas() As Boolean
        'mreyes 17/Mayo/2012 06:09 p.m.
        Dim objDataSet As Data.DataSet
        Using objCatalogoTarjetas As New BCL.BCLCatalogoTarjetas(GLB_ConStringCipSis)
            'Get a new Project DataSet
            Try
                objDataSet = objCatalogoTarjetas.Inserta_Tarjetas  'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow

                'Set the values in the DataRow

                objDataRow.Item("banco") = Cbo_Banco.Text



                objDataRow.Item("limcred") = Val(Txt_LimCred.Text)
                objDataRow.Item("saldo") = Val(Txt_Saldo.Text)
                
                objDataRow.Item("prioridad") = Val(Txt_Prioridad.Text)

                'Add the DataRow to the DataSet
                objDataSet.Tables(0).Rows.Add(objDataRow)

                'Add the Project
                If Not objCatalogoTarjetas.usp_Captura_Tarjetas(Accion, objDataSet) Then
                    Throw New Exception("Falló Inserción de Tarjetas")
                Else
                    Inserta_Tarjetas = True
                End If
                ' traer el tarjeta_id

                If Accion = 1 Then
                    Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
                        Dim ObjDataSet1 As Data.DataSet
                        ObjDataSet1 = objMySqlGral.usp_TraerFolio("TAR", "")
                        If ObjDataSet1.Tables(0).Rows.Count > 0 Then
                            Txt_Tarjeta_ID.Text = Val(ObjDataSet1.Tables(0).Rows(0).Item("campo").ToString)

                        Else
                            Txt_Tarjeta_ID.Text = "1"
                        End If
                    End Using
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function
    



    Private Function ValidarEdicion() As Boolean
        'mreyes 17/Mayo/2012 06:41 p.m. 
        ValidarEdicion = False
        Try
            If Cbo_Banco.Text.Length = 0 Then
                MsgBox("Debe especificar un Banco.", MsgBoxStyle.Critical, "Validación")
                Cbo_Banco.Focus()
                Exit Function
            End If


           
            If Val(Txt_LimCred.Text.Length) = 0 Then
                MsgBox("Debe especificar un límite de crédito.", MsgBoxStyle.Critical, "Validación")
                Txt_LimCred.Focus()
                Exit Function
            End If




            ValidarEdicion = True
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Function
    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click

        Try
            If Accion = 1 Then '''' es un articulo nuevo
                If ValidarEdicion() = False Then Exit Sub
                If MsgBox("Estas Seguro de Grabar la Tarjeta?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    If Inserta_Tarjetas() = True Then
                       
                    Else
                        MessageBox.Show("Error Grabando !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    End If
                End If
            ElseIf Accion = 2 Then ' es una actualización
                If ValidarEdicion() = False Then Exit Sub
                If MsgBox("Estas Seguro de Actualizar la Tarjeta?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    If Inserta_Tarjetas() = True Then
                       
                        MessageBox.Show("Error Grabando !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

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


    Private Sub DGrid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub






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

    Private Sub frmCatalogoEstilos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try


            If Accion = 1 Then
                ' LimpiarDatos()
            Else
                'Call usp_TraerTarjeta()
                'Call usp_TraerTarjetas_Det()
            End If
            Call GenerarToolTip()


            Call Edicion()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub usp_TraerTarjeta()
        '17/Mayo/2012 10:08 a.m.
        Using objCatalogoTarjetas As New BCL.BCLCatalogoTarjetas(GLB_ConStringCipSis)
            Try
                objDataSet = objCatalogoTarjetas.usp_TraerTarjetas(Txt_Tarjeta_ID.Text, Cbo_Banco.Text)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Cbo_Banco.Text = objDataSet.Tables(0).Rows(0).Item("banco").ToString
                   
                    Txt_LimCred.Text = objDataSet.Tables(0).Rows(0).Item("limcred")
                    Txt_Saldo.Text = objDataSet.Tables(0).Rows(0).Item("saldo")
                   
                    Txt_Prioridad.Text = objDataSet.Tables(0).Rows(0).Item("prioridad")
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



        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub LimpiarDatos()
        Try
            Cbo_Banco.Text = ""
           
            Txt_LimCred.Text = "0.00"
            Txt_Saldo.Text = "0.00"
           
            Txt_Prioridad.Text = ""
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
                    Btn_Nuevo.Enabled = True
                    Btn_Editar.Enabled = True

                    Pnl_Edicion.Enabled = False
                    Pnl1.Enabled = False
                    Cbo_Banco.BackColor = TextboxBackColor
                   
                    Txt_LimCred.BackColor = TextboxBackColor
                    Txt_Saldo.BackColor = TextboxBackColor
                   
                    Txt_Prioridad.BackColor = TextboxBackColor


                Case 1, 2
                    Btn_Aceptar.Enabled = True
                    Btn_Cancelar.Enabled = True
                    Btn_Nuevo.Enabled = False
                    Btn_Editar.Enabled = False

                    If Accion = 1 Then
                        Cbo_Banco.Focus()

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





    Private Sub Txt_Titular_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        End If
    End Sub


    Private Sub Txt_Titular_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Txt_Tipo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        End If
    End Sub

    Private Sub Txt_Tipo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Txt_LimCred_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_LimCred.KeyPress
        Call pub_SoloNumeros(sender, e)
    End Sub

    Private Sub Txt_LimCred_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_LimCred.LostFocus
        Txt_LimCred.Text = Format(Val(Txt_LimCred.Text), "$#,###,##0.00")

    End Sub

    Private Sub Txt_LimCred_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_LimCred.TextChanged

    End Sub

    Private Sub Txt_Saldo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Saldo.KeyPress
        Call pub_SoloNumeros(sender, e)
    End Sub

    Private Sub Txt_Saldo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Saldo.LostFocus
        Txt_Saldo.Text = Format(Val(Txt_Saldo.Text), "$#,###,##0.00")
    End Sub

    Private Sub Txt_DiaCorte_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Call pub_SoloNumeros(sender, e)
    End Sub

    Private Sub Txt_DiaCorte_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs)

    End Sub

    Private Sub Txt_DiaPago_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Call pub_SoloNumeros(sender, e)
    End Sub

    Private Sub Txt_DiaPago_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Txt_DiaPago_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs)

    End Sub

    Private Sub Txt_Observaciones_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Observaciones.TextChanged

    End Sub
End Class
