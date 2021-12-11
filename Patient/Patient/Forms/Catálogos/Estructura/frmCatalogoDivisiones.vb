Public Class frmCatalogoDivisiones
    'mreyes 04/Junio/2012 11:01 a.m.

    Dim Sql As String
    Public Accion As Integer  '' 1  = nuevo, 2 = edicion , 3 = eliminar , 4 = consultar 
    Public Sw_Registro As Boolean = False
    Private objDataSet As Data.DataSet
    Dim Costo As Decimal = 0
    Public Sw_PedidoNuevo As Boolean = False

    Private Sub Txt_Marca_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Txt_IdDivisiones.SelectAll()
    End Sub

    Private Sub Txt_Marca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Function Inserta_Deptos() As Boolean
        'mreyes 04/Junio/2012 11:33 a.m.

        Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
            'Get a new Project DataSet
            Try
                'Add the Project
                If Not objCatalogoDeptos.usp_CapturaEstDivisiones(Txt_CveDivisiones.Text, Txt_DescripDivisiones.Text) Then
                    Throw New Exception("Falló Inserción de Departamentos")
                Else
                    Inserta_Deptos = True
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    'Function Actualiza_Deptos() As Boolean
    '    'mreyes 04/Junio/2012 11:33 a.m.

    '    Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
    '        'Get a new Project DataSet
    '        Try
    '            'Add the Project
    '            If Not objCatalogoDeptos.usp_ActualizarEstDepto(CInt(Txt_IdDepto.Text), Txt_Clave.Text, Txt_DescripDepto.Text) Then
    '                Throw New Exception("Falló Inserción de Departamentos")
    '            Else
    '                Actualiza_Deptos = True
    '            End If
    '        Catch ExceptionErr As Exception
    '            MessageBox.Show(ExceptionErr.Message.ToString)
    '        End Try
    '    End Using
    'End Function

    Private Function ValidarEdicion() As Boolean
        'mreyes 03/Marzo/2012 11:23 a.m. 
        ValidarEdicion = False
        Try


            If Txt_DescripDivisiones.Text.Length = 0 Then
                MsgBox("Debe especificar una descripción para la división.", MsgBoxStyle.Critical, "Validación")
                Txt_DescripDivisiones.Focus()
                Exit Function
            End If

            If usp_ExisteDivision() = True Then
                MessageBox.Show("La Clave del Departamento ya existe", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Txt_CveDivisiones.Focus()
                Exit Function
            End If


            ValidarEdicion = True
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Function

    Private Function usp_ExisteDivision() As Boolean
        'mreyes 04/Junio/2012 12:04 p.m.

        Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
            Try
                'If Txt_IdLinea.Text.Trim = "" Then
                '    Txt_IdLinea.Text = 0
                'End If
                objDataSet = objCatalogoDeptos.usp_TraerEstDivisiones(0, Txt_CveDivisiones.Text)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function
    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click

        Try
            If Accion = 1 Then '''' es un articulo nuevo
                If ValidarEdicion() = False Then Exit Sub
                If MsgBox("Estas Seguro de Grabar la División?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    If Inserta_Deptos() = True Then

                        MessageBox.Show("División guardada correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Sw_Registro = True
                        Me.Close()
                        '' Me.Dispose()
                    Else
                        MessageBox.Show("Error Grabando !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    End If
                End If
            ElseIf Accion = 2 Then ' es una actualización
                If ValidarEdicion() = False Then Exit Sub
                If MsgBox("Estas Seguro de Actualizar el departamento?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    'If Actualiza_Deptos() = True Then

                    '    Sw_Registro = True
                    '    MessageBox.Show("Departamento guardado correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '    Me.Close()
                    '    ' Me.Dispose()
                    'Else
                    '    MessageBox.Show("Error Grabando !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    '    GLB_RefrescarPedido = True
                    'End If
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
                Call usp_TraerDivision()

            End If
            Call GenerarToolTip()


            Call Edicion()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub usp_TraerDivision()
        'mreyes 04/Junio/2012 12:04 p.m.

        Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
            Try

                objDataSet = objCatalogoDeptos.usp_TraerEstDivisiones(0, Txt_CveDivisiones.Text)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_DescripDivisiones.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                    Txt_CveDivisiones.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
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
            Txt_IdDivisiones.Text = ""
            Txt_DescripDivisiones.Text = ""

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub



    Private Sub TxtLostfocus(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
        Dim myForm As New frmConsulta
        If Txt_Campo.Text.Length = 0 Then Exit Sub
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringNomSis)
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
                    Pnl_Edicion.Enabled = False
                    Txt_IdDivisiones.BackColor = TextboxBackColor
                    Txt_DescripDivisiones.BackColor = TextboxBackColor
                Case 1, 2
                    Btn_Aceptar.Enabled = True
                    Btn_Cancelar.Enabled = True
                    Btn_Nuevo.Enabled = False
                    Btn_Editar.Enabled = False
                    If Accion = 1 Then
                        Txt_CveDivisiones.Focus()
                    ElseIf Accion = 2 Then
                        Txt_CveDivisiones.Focus()

                        Txt_IdDivisiones.Enabled = False
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



    Private Sub Txt_DescripMarca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub


    Private Sub Txt_DescripDepto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Txt_Clave_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Clave_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub
End Class
