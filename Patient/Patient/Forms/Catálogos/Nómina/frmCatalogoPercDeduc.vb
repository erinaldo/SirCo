Public Class frmCatalogoPercDeduc
    'mreyes 06/Junio/2012 04:33 p.m.

    Dim Sql As String
    Public Accion As Integer  '' 1  = nuevo, 2 = edicion , 3 = eliminar , 4 = consultar 
    Public Sw_Registro As Boolean = False
    Private objDataSet As Data.DataSet
    Dim Costo As Decimal = 0
    Public Sw_PedidoNuevo As Boolean = False

    Private Sub Txt_Marca_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_IdPercdeduc.GotFocus
        Txt_IdPercdeduc.SelectAll()
    End Sub

    Private Sub Txt_Marca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_IdPercdeduc.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Function Inserta_PercDeduc() As Boolean
        'mreyes 06/Junio/2012 10:50 a.m.

        Using objCatalogoPercDeduc As New BCL.BCLCatalogoPercDeduc(GLB_ConStringNomSis)
            'Get a new Project DataSet
            Try
                Dim Naturaleza As String
                Dim Repetitivo As String
                Dim Activo As Integer
                Dim Tienda As String = ""
                If Opt_Deduccion.Checked = True Then
                    Naturaleza = "D"
                Else
                    Naturaleza = "P"
                End If

                Activo = 1
                If Chk_Repetitivo.Checked = True Then
                    repetitivo = "S"
                Else
                    repetitivo = "N"
                End If

                If Chk_Tienda.Checked = True Then
                    Tienda = "S"
                Else
                    Tienda = "N"
                End If

                'Add the Project
                If Not objCatalogoPercDeduc.usp_Captura_Percdeduc(Accion, Val(Txt_IdPercdeduc.Text), Txt_Clave.Text, Naturaleza, Txt_DescripC.Text, Txt_DescripL.Text, Repetitivo, Mid(Cbo_TipoNom.Text, 1, 1), Mid(Cbo_Estatus.Text, 1, 1), Tienda) Then
                    Throw New Exception("Falló Inserción de Conceptos")
                Else
                    Inserta_PercDeduc = True
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


            If Txt_Clave.Text.Length = 0 Then
                MsgBox("Debe especificar una Clave.", MsgBoxStyle.Critical, "Validación")
                Txt_Clave.Focus()
                Exit Function
            End If


            If Txt_DescripC.Text.Length = 0 Then
                MsgBox("Debe especificar una Descripción corta.", MsgBoxStyle.Critical, "Validación")
                Txt_DescripC.Focus()
                Exit Function
            End If

            If Txt_DescripL.Text.Length = 0 Then
                MsgBox("Debe especificar una Descripción Larga.", MsgBoxStyle.Critical, "Validación")
                Txt_DescripL.Focus()
                Exit Function
            End If

            ValidarEdicion = True
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Function
    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        'mreyes 06/Junio/2012 10:14 a.m.
        Try
            If Accion = 1 Then '''' es un articulo nuevo
                If ValidarEdicion() = False Then Exit Sub
                If MsgBox("Estas Seguro de Grabar el Concepto?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    If Inserta_PercDeduc() = True Then

                        MessageBox.Show("Exitosamente Grabado el Concepto '" & Txt_DescripC.Text & " !", "Agregando Concepto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Sw_Registro = True
                        Me.Close()
                        '' Me.Dispose()
                    Else
                        MessageBox.Show("Error Grabando !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    End If
                End If
            ElseIf Accion = 2 Then ' es una actualización
                If ValidarEdicion() = False Then Exit Sub
                If MsgBox("Estas Seguro de Actualizar el Concepto?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    If Inserta_PercDeduc() = True Then

                        Sw_Registro = True
                        MessageBox.Show("Exitosamente Grabado el Puesto '" & Txt_DescripC.Text & " !", "Agregando Concepto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Close()
                        ' Me.Dispose()
                    Else
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




    Private Sub frmCatalogoPercDeduc_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try


            If Accion = 1 Then
                ' LimpiarDatos()
                Cbo_Estatus.Text = "ACTIVO"
                Cbo_Estatus.Enabled = False


            Else
                Call usp_TraerPercDeduc()

            End If
            Call GenerarToolTip()


            Call Edicion()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub usp_TraerPercDeduc()
        'mreyes 04/Junio/2012 12:04 p.m.

        Using objCatalogoDeptos As New BCL.BCLCatalogoPercDeduc(GLB_ConStringNomSis)
            Try

                objDataSet = objCatalogoDeptos.usp_PpalCatalogoPercDeduc(Val(Txt_IdPercdeduc.Text), Txt_Clave.Text, "", Txt_DescripC.Text, Txt_DescripL.Text, "", "", "", "")
                If objDataSet.Tables(0).Rows.Count > 0 Then

                    Txt_IdPercdeduc.Text = objDataSet.Tables(0).Rows(0).Item("idpercdeduc").ToString
                    Txt_Clave.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    Txt_DescripC.Text = objDataSet.Tables(0).Rows(0).Item("descripc").ToString
                    Txt_DescripL.Text = objDataSet.Tables(0).Rows(0).Item("descripl").ToString

                    If Mid(objDataSet.Tables(0).Rows(0).Item("naturaleza"), 1, 1) = "D" Then
                        Opt_Deduccion.Checked = True
                    Else
                        Opt_Percepcion.Checked = True
                    End If

                    If Mid(objDataSet.Tables(0).Rows(0).Item("repetitivo"), 1, 1) = "S" Then
                        Chk_Repetitivo.Checked = True
                    Else
                        Chk_Repetitivo.Checked = False
                    End If

                    If Mid(objDataSet.Tables(0).Rows(0).Item("tienda"), 1, 1) = "S" Then
                        Chk_Tienda.Checked = True
                    Else
                        Chk_Tienda.Checked = False
                    End If

                    If Mid(objDataSet.Tables(0).Rows(0).Item("estatus"), 1, 1) = "A" Then
                        Cbo_Estatus.Text = "ACTIVO"
                    Else
                        Cbo_Estatus.Text = "INACTIVO"
                    End If

                    If Mid(objDataSet.Tables(0).Rows(0).Item("tiponom"), 1, 1) = "F" Then
                        Cbo_TipoNom.Text = "FISCAL"
                    ElseIf Mid(objDataSet.Tables(0).Rows(0).Item("tiponom"), 1, 1) = "B" Then
                        Cbo_TipoNom.Text = "BONO"
                    Else
                        Cbo_TipoNom.Text = "AMBAS"
                    End If
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
            Txt_IdPercdeduc.Text = ""
            Txt_Clave.Text = ""
            Cbo_Estatus.Text = ""
            Cbo_TipoNom.Text = ""
            Chk_Repetitivo.Checked = False


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
                    Txt_IdPercdeduc.BackColor = TextboxBackColor
                    Txt_IdPercdeduc.BackColor = TextboxBackColor
                    Txt_Clave.BackColor = TextboxBackColor
                Case 1, 2
                    Btn_Aceptar.Enabled = True
                    Btn_Cancelar.Enabled = True
                    Btn_Nuevo.Enabled = False
                    Btn_Editar.Enabled = False
                    If Accion = 1 Then
                        Txt_IdPercdeduc.Focus()
                    ElseIf Accion = 2 Then
                        Txt_Clave.Focus()

                        Txt_IdPercdeduc.Enabled = False
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





    Private Sub Btn_Buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'mreyes 05/Junio/2012 10:09 a.m.
        Dim myForm As New frmConsulta
        Try
            Txt_Campo.Text = ""
            myForm.Tipo = "DE"
            myForm.ShowDialog()
            Txt_Clave.Text = myForm.Campo1
            Txt_IdPercdeduc.Text = myForm.Campo
            If Txt_Clave.Text.Length = 0 Then
                Txt_Clave.Focus()
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try


    End Sub


    Private Sub Txt_DescripPuesto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_DescripC.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_DescripL.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Clave_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Clave.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

End Class
