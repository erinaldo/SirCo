Public Class frmCatalogoProveeBita
    'Tony Garcia 28/Enero/2014 10:02 a.m. 

#Region "Variables"
    Dim Sql As String
    Public Accion As Integer  '' 1  = nuevo, 2 = edicion , 3 = eliminar , 4 = consultar 
    Public Sw_Registro As Boolean = False

    Private objDataSet As Data.DataSet
    Dim Sw_LibresProveedores As Boolean = False
    Dim blnPrimero As Boolean = False
    Dim blnFueClic As Boolean = False
    Public fecha As String = "1900-01-01"

    Dim numRenCond As Integer = 0
    Dim numRenCuentas As Integer = 0
    Dim numRenContactos As Integer = 0


    Dim MarcaSeleccionada As String = ""

    Dim IdBancoFactoraje As Integer = 0
    Dim Sw_Condiciones As Boolean = False
    Dim IdProveedorB As Integer

#End Region
#Region "Load de la Forma"
    Private Sub frmCatalogoProveedores_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Accion = 1
            If Accion = 1 Then
                Txt_provee.Focus()
            End If
            Call GenerarToolTip()
            Call Traer_datos()
            Call LimpiarDatos()
            Sw_Registro = True

            Txt_provee.Focus()


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
#End Region
#Region "Botones"

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click

        Try
            If Accion = 1 Then '''' es un proveedor nuevo
                If ValidarEdicion() = False Then Exit Sub
                If MsgBox("Estas Seguro de Grabar la Bitácora de  Proveedor?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    Incertar_y_Modificar()
                    GLB_RefrescarPedido = True
                    MessageBox.Show("Guardando Bitácora '" & Txt_provee.Text & "' con razón social '" & Txt_NomProvee.Text & " !", "Agregando Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Sw_Registro = True
                    Me.Close()
                    ' Me.Dispose()
                Else
                    MessageBox.Show("Error Grabando !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    End If

            ElseIf Accion = 2 Then ' es una actualización
                If ValidarEdicion() = False Then Exit Sub
                If MsgBox("Estas Seguro de Actualizar la Bitácora?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then

                    Incertar_y_Modificar()

                    GLB_RefrescarPedido = True
                    MessageBox.Show("La Bitácora del Proveedor '" & Txt_provee.Text & "' con razón social '" & Txt_NomProvee.Text & " se Guardo con Exito!", "Actualizando Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Sw_Registro = True
                    Me.Close()
                    '  Me.Dispose()
                Else
                    MessageBox.Show("Error Grabando !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    End If

            ElseIf Accion = 4 Then
                Me.Close()
                ' Me.Dispose()
            End If '' del if de accion = 1 



        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub


    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click
        Try
            If Accion = 1 Or Accion = 2 Then
                If MessageBox.Show("Estas seguro de cancelar el registro ?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                    Me.Dispose()
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
#End Region
#Region "Funciones"
    Function Traer_datos() As Boolean

        Using objProveedores As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoAppSQL)

            Try


                objDataSet = objProveedores.usp_PpalCatalogoProveeBita(4, Txt_provee.Text, Txt_Marc.Text, fecha, Txt_Comentario.Text, 0)
                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then

                    If Accion = 4 Then
                        ' Call TxtLostfocus(Txt_Marc, txt_DescripMarca, "M")

                        Txt_NomProvee.Enabled = False
                        Txt_provee.Enabled = False
                        DT_Fecha.Enabled = False
                        Txt_Comentario.Enabled = False
                        Txt_Marc.Enabled = False
                        Txt_Comentario.Text = objDataSet.Tables(0).Rows(0).Item("comentario").ToString
                        Txt_NomProvee.Text = objDataSet.Tables(0).Rows(0).Item("nombre").ToString
                        Call TxtLostfocus(Txt_Marc, txt_DescripMarca, "M")

                    End If

                    If Accion = 2 Then
                        Txt_Comentario.Focus()
                        ' Call TxtLostfocus(Txt_Marc, txt_DescripMarca, "M")

                        Txt_NomProvee.Enabled = False
                        Txt_provee.Enabled = False
                        DT_Fecha.Enabled = False
                        Txt_Marc.Enabled = False
                        Txt_NomProvee.Text = objDataSet.Tables(0).Rows(0).Item("nombre").ToString
                        Call TxtLostfocus(Txt_Marc, txt_DescripMarca, "M")


                    End If

                    If Accion = 1 Then

                        DT_Fecha.Enabled = False
                        Txt_NomProvee.Enabled = False
                    End If
                End If


            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using

    End Function

    Function Incertar_y_Modificar() As Boolean

        'Using objCatalogoProveedores As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoAppSQL)
        Using objProveedores As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoAppSQL)

                Try

                    If Accion = 1 Or Accion = 2 Then
                    objDataSet = objProveedores.usp_PpalCatalogoProveeBita(Accion, Txt_provee.Text, Txt_Marc.Text, fecha, Txt_Comentario.Text, GLB_Idempleado)
                End If


            Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Private Function ValidarEdicion() As Boolean
        ValidarEdicion = False
        Try


            If Txt_provee.Text.Length = 0 Or Txt_provee.Text.Length > 3 Then
                MsgBox("Compruebe el Campo Proveedor", MsgBoxStyle.Critical, "Validación")
                Tbc_Proveedores.SelectedIndex = 0
                Txt_provee.Focus()
                Exit Function
            End If

            If Txt_Marc.Text.Length = 0 Or Txt_Marc.Text.Length > 3 Then
                MsgBox("Compruebe el Campo Marca", MsgBoxStyle.Critical, "Validación")
                Tbc_Proveedores.SelectedIndex = 0
                Txt_Marc.Focus()
                Exit Function
            End If

            If Txt_Comentario.Text.Length = 0 Then
                MsgBox("Escriba un comentario.", MsgBoxStyle.Critical, "Validación")
                Tbc_Proveedores.SelectedIndex = 0
                Txt_Comentario.Focus()
                Exit Function
            End If










            ValidarEdicion = True
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Function

    Private Sub Txt_provee_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_provee.LostFocus
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
            If Txt_provee.Text.Length = 0 Then
                Txt_NomProvee.Text = ""
                Exit Sub
            End If
            Try
                'Get the specific project selected in the ListView control
                If Txt_provee.Text.Trim.Length < 3 Then
                    Txt_provee.Text = pub_RellenarIzquierda(Txt_provee.Text.Trim, 3)
                End If
                Call TxtLostfocus(Txt_provee, Txt_NomProvee, "P")

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub
    Private Sub Txt_Marc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Marc.LostFocus
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
            If Txt_Marc.Text.Length = 0 Then
                txt_DescripMarca.Text = ""
                Exit Sub
            End If
            Try
                'Get the specific project selected in the ListView control
                If Txt_Marc.Text.Trim.Length < 3 Then
                    Txt_Marc.Text = pub_RellenarIzquierda(Txt_Marc.Text.Trim, 3)
                End If
                Call TxtLostfocus(Txt_Marc, txt_DescripMarca, "M")

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub TxtLostfocus(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
        'mreyes 28/Febrero/2012 10:25 a.m.
        Dim myForm As New frmConsulta
        If Txt_Campo.Text.Length = 0 Then Exit Sub
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
            Try
                objDataSet = objMySqlGral.usp_TraerDescripcion(Tipo, Txt_Campo.Text, "")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_Campo1.Text = objDataSet.Tables(0).Rows(0).Item("campo").ToString
                    If Tipo = "P" Then
                        IdProveedorB = Val(objDataSet.Tables(0).Rows(0).Item("campo1").ToString)
                    End If
                Else
                    Txt_Campo.Text = ""
                    myForm.Tipo = Tipo
                    myForm.IdProveedorB = idproveedorb
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

    Private Sub Txt_provee_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_provee.TextChanged
        Try
            If Txt_provee.Text.Length = 3 Then
                Txt_Marc.Focus()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Marc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Marc.TextChanged
        Try
            If Txt_Marc.Text.Length = 3 Then
                Txt_Comentario.Focus()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Comentario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Comentario.TextChanged
        Try
            If Txt_Comentario.Text.Length = 1000 Then
                Btn_Aceptar.Focus()
            End If


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
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

            ' Txt_provee.Text = ""

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub Txt_provee_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_provee.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Txt_Marc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Marc.KeyPress
        If IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If

        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If


        'If Char.IsLetter(e.KeyChar) Then
        '    e.Handled = False
        'ElseIf Char.IsControl(e.KeyChar) Then
        '    e.Handled = False
        'Else
        '    e.Handled = True
        'End If
    End Sub

    Private Sub Txt_Comentario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Comentario.KeyPress

        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Tp_Generales_Click(sender As Object, e As EventArgs) Handles Tp_Generales.Click

    End Sub

    Private Sub frmCatalogoProveeBita_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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


#End Region
End Class