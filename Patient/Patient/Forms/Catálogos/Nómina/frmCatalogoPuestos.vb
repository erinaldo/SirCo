Public Class frmCatalogoPuestos
    'mreyes 04/Junio/2012 01:22 p.m.

    Dim Sql As String
    Public Accion As Integer  '' 1  = nuevo, 2 = edicion , 3 = eliminar , 4 = consultar 
    Public Sw_Registro As Boolean = False
    Private objDataSet As Data.DataSet
    Dim Costo As Decimal = 0
    Public Sw_PedidoNuevo As Boolean = False

    Private Sub Txt_Marca_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_IdDepto.GotFocus
        Txt_IdDepto.SelectAll()
    End Sub

    Private Sub Txt_Marca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_IdDepto.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Function Inserta_Puestos() As Boolean
        'mreyes 05/Junio/2012 10:22 a.m.

        Using objCatalogoPuestos As New BCL.BCLCatalogoPuestos(GLB_ConStringNomSis)
            'Get a new Project DataSet
            Try
                'Add the Project
                If Not objCatalogoPuestos.usp_Captura_Puesto(Accion, Val(Txt_IdPuesto.Text), Val(Txt_IdDepto.Text), Txt_Clave.Text, Txt_DescripPuesto.Text, IIf(Chk_comision.Checked = True, "S", "N"), IIf(Chk_TVenta.Checked = True, "S", "N")) Then
                    Throw New Exception("Falló Inserción de Puestos")
                Else
                    Inserta_Puestos = True
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


            If Txt_DescripDepto.Text.Length = 0 Then
                MsgBox("Debe especificar una descripción.", MsgBoxStyle.Critical, "Validación")
                Txt_DescripDepto.Focus()
                Exit Function
            End If


            ValidarEdicion = True
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Function
    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        'mreyes 05/Junio/2012 10:14 a.m.
        Try
            If Accion = 1 Then '''' es un articulo nuevo
                If ValidarEdicion() = False Then Exit Sub
                If MsgBox("Estas Seguro de Grabar el Puesto?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    If Inserta_Puestos() = True Then

                        MessageBox.Show("Exitosamente Grabado el Puesto '" & Txt_Clave.Text & " !", "Agregando Puesto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Sw_Registro = True
                        Me.Close()
                        '' Me.Dispose()
                    Else
                        MessageBox.Show("Error Grabando !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    End If
                End If
            ElseIf Accion = 2 Then ' es una actualización
                If ValidarEdicion() = False Then Exit Sub
                If MsgBox("Estas Seguro de Actualizar el Puesto?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    If Inserta_Puestos() = True Then

                        Sw_Registro = True
                        MessageBox.Show("Exitosamente Grabado el Puesto '" & Txt_Clave.Text & " !", "Agregando Puesto", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub frmCatalogoEstilos_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave

    End Sub


    Private Sub frmCatalogoEstilos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try


            If Accion = 1 Then
                ' LimpiarDatos()
            Else
                Call usp_TraerPuestos()

            End If
            Call GenerarToolTip()


            Call Edicion()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub usp_TraerPuestos()
        'mreyes 04/Junio/2012 12:04 p.m.

        Using objCatalogoDeptos As New BCL.BCLCatalogoPuestos(GLB_ConStringNomSis)
            Try

                objDataSet = objCatalogoDeptos.usp_PpalCatalogoPuesto(Val(Txt_IdPuesto.Text), Val(Txt_IdDepto.Text), "", "")
                If objDataSet.Tables(0).Rows.Count > 0 Then

                    Txt_DescripDepto.Text = objDataSet.Tables(0).Rows(0).Item("descripdepto").ToString
                    Txt_DescripPuesto.Text = objDataSet.Tables(0).Rows(0).Item("descrippuesto").ToString
                    Txt_ClaveDepto.Text = objDataSet.Tables(0).Rows(0).Item("clavedepto").ToString
                    Txt_Clave.Text = objDataSet.Tables(0).Rows(0).Item("clavepuesto").ToString
                    If objDataSet.Tables(0).Rows(0).Item("comision").ToString = "S" Then
                        Chk_comision.Checked = True
                    Else
                        Chk_comision.Checked = False
                    End If
                    If objDataSet.Tables(0).Rows(0).Item("tventa").ToString = "S" Then
                        Chk_TVenta.Checked = True
                    Else
                        Chk_TVenta.Checked = False
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
            Txt_IdDepto.Text = ""
            Txt_DescripDepto.Text = ""

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
                    Txt_IdDepto.BackColor = TextboxBackColor
                    Txt_IdDepto.BackColor = TextboxBackColor
                    Txt_DescripDepto.BackColor = TextboxBackColor
                Case 1, 2
                    Btn_Aceptar.Enabled = True
                    Btn_Cancelar.Enabled = True
                    Btn_Nuevo.Enabled = False
                    Btn_Editar.Enabled = False
                    If Accion = 1 Then
                        Txt_IdDepto.Focus()
                    ElseIf Accion = 2 Then
                        Txt_DescripDepto.Focus()

                        Txt_IdDepto.Enabled = False
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



    Private Sub Txt_DescripMarca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_DescripDepto.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub


    Private Sub Btn_Buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Buscar.Click
        'mreyes 05/Junio/2012 10:09 a.m.
        Dim myForm As New frmConsulta
        Try
            Txt_Campo.Text = ""
            myForm.Tipo = "DE"
            myForm.ShowDialog()
            Txt_DescripDepto.Text = myForm.Campo1
            Txt_IdDepto.Text = myForm.Campo
            If Txt_DescripDepto.Text.Length = 0 Then
                Txt_DescripDepto.Focus()
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try


    End Sub


    Private Sub Txt_DescripPuesto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_DescripPuesto.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_DescripDepto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_DescripDepto.TextChanged

    End Sub

    Private Sub Txt_Clave_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Clave.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub CargarFormaConsulta()
        'mreyes 13/Junio/2012 01:28 p.m.

        Dim myForm As New frmConsulta

        Txt_IdDepto.Text = ""
        myForm.Tipo = "DE"
        myForm.ShowDialog()
        Txt_IdDepto.Text = myForm.Campo
        Txt_ClaveDepto.Text = myForm.Campo1
        Txt_DescripDepto.Text = myForm.Campo2
        If Txt_ClaveDepto.Text.Length = 0 Then
            Txt_ClaveDepto.Focus()
        End If
    End Sub

    Private Sub Txt_ClaveDepto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_ClaveDepto.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Txt_ClaveDepto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_ClaveDepto.LostFocus
        'mreyes 13/Junio/2012 07:03 p.m.
        Try
            If Txt_ClaveDepto.Text.Length = 0 Then Exit Sub
            Using objMySqlGral As New BCL.BCLCatalogoDeptos(GLB_ConStringNomSis)
                Try
                    objDataSet = objMySqlGral.usp_PpalCatalogoDepto(0, Txt_ClaveDepto.Text, "")
                    If objDataSet.Tables(0).Rows.Count = 1 Then
                        Txt_IdDepto.Text = objDataSet.Tables(0).Rows(0).Item("iddepto").ToString
                        Txt_DescripDepto.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                        Txt_ClaveDepto.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    Else
                        Call CargarFormaConsulta()
                    End If


                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)

        End Try
    End Sub


    Private Sub Txt_ClaveDepto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_ClaveDepto.TextChanged

    End Sub

    Private Sub Txt_Clave_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Clave.LostFocus

    End Sub

    Private Sub Txt_Clave_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Clave.TextChanged

    End Sub

    Private Sub Txt_DescripPuesto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_DescripPuesto.TextChanged

    End Sub

    Private Sub Pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub

    Private Sub Chk_comision_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_comision.CheckedChanged
        If Chk_comision.Checked = True Then
            Chk_TVenta.Enabled = True
        Else
            Chk_TVenta.Checked = False
            Chk_TVenta.Enabled = False
        End If
    End Sub
End Class
