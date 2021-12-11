Public Class frmCatalogoFamilia
    'mreyes 04/Junio/2012 11:01 a.m.

    Dim Sql As String
    Public Accion As Integer  '' 1  = nuevo, 2 = edicion , 3 = eliminar , 4 = consultar 
    Public Sw_Registro As Boolean = False
    Private objDataSet As Data.DataSet
    Dim Costo As Decimal = 0
    Public Sw_Load As Boolean = True

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

    Function Inserta_Familia() As Boolean
        'mreyes 04/Junio/2012 11:33 a.m.

        Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
            'Get a new Project DataSet
            Try
                'Add the Project
                If Not objCatalogoDeptos.usp_CapturaEstFamilia(CInt(Txt_IdDivisiones.Text), CInt(Txt_IdDepto.Text), Txt_CveFam.Text, Txt_DescripFam.Text) Then
                    Throw New Exception("Falló Inserción de Departamentos")
                Else
                    Inserta_Familia = True
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Function Actualiza_Familia() As Boolean
        'mreyes 04/Junio/2012 11:33 a.m.

        Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
            'Get a new Project DataSet
            Try
                'Add the Project
                If Not objCatalogoDeptos.usp_ActualizarEstFamilia(CInt(Txt_IdFamilia.Text), CInt(Txt_IdDepto.Text), Txt_CveFam.Text, Txt_DescripFam.Text) Then
                    Throw New Exception("Falló Inserción de Departamentos")
                Else
                    Actualiza_Familia = True
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
            If Txt_DescripDivisiones.Text.Length = 0 Then
                MessageBox.Show("Debe especificar una división", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Txt_CveDivisiones.Focus()
                Exit Function
            End If

            If Txt_DescripDepto.Text.Length = 0 Then
                MessageBox.Show("Debe especificar un departamento", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Txt_Clave.Focus()
                Exit Function
            End If

            If Txt_DescripFam.Text.Length = 0 Then
                MessageBox.Show("Debe especificar una descripción para la Familia", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Txt_DescripFam.Focus()
                Exit Function
            End If

            If usp_ExisteFamilia() = True Then
                MessageBox.Show("La Clave de la Familia ya existe", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Txt_CveFam.Focus()
                Exit Function
            End If


            ValidarEdicion = True
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Function

    Private Function usp_ExisteFamilia() As Boolean
        'mreyes 04/Junio/2012 12:04 p.m.

        Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
            Try
                'If Txt_IdLinea.Text.Trim = "" Then
                '    Txt_IdLinea.Text = 0
                'End If
                objDataSet = objCatalogoDeptos.usp_TraerEstFamilia(0, CInt(Txt_IdDepto.Text), CInt(Txt_IdDivisiones.Text), Txt_CveFam.Text, 1, "")
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
                If MsgBox("Estas Seguro de Grabar la Familia?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    If Inserta_Familia() = True Then

                        MessageBox.Show("Familia guardada correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Sw_Registro = True
                        Me.Close()
                        '' Me.Dispose()
                    Else
                        MessageBox.Show("Error Grabando !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    End If
                End If
            ElseIf Accion = 2 Then ' es una actualización
                If ValidarEdicion() = False Then Exit Sub
                If MsgBox("Estas Seguro de Actualizar la familia?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    If Actualiza_Familia() = True Then

                        Sw_Registro = True
                        MessageBox.Show("Familia guardada correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            Sw_Load = True

            If Accion = 1 Then
                ' LimpiarDatos()
            Else
                Call usp_TraerFamilia()

            End If
            Call GenerarToolTip()


            Call Edicion()
            Sw_Load = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub usp_TraerFamilia()
        'mreyes 04/Junio/2012 12:04 p.m.

        Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
            Try
                If Sw_Load = True Then
                    If Txt_IdFamilia.Text.Trim = "" Then
                        Txt_IdFamilia.Text = 0
                    End If
                Else
                    Txt_IdFamilia.Text = 0
                End If

                objDataSet = objCatalogoDeptos.usp_TraerEstFamilia(CInt(Txt_IdFamilia.Text), 0, 0, Txt_CveFam.Text, 1, "")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If Sw_Load = True Then
                        Txt_IdDivisiones.Text = objDataSet.Tables(0).Rows(0).Item("iddivisiones").ToString
                        Txt_CveDivisiones.Text = objDataSet.Tables(0).Rows(0).Item("cvedivisiones").ToString
                        Txt_DescripDivisiones.Text = objDataSet.Tables(0).Rows(0).Item("divisiones").ToString
                        Txt_IdDepto.Text = objDataSet.Tables(0).Rows(0).Item("iddepto").ToString
                        Txt_Clave.Text = objDataSet.Tables(0).Rows(0).Item("cvedepto").ToString
                        Txt_DescripDepto.Text = objDataSet.Tables(0).Rows(0).Item("depto").ToString
                    End If
                    Txt_IdFamilia.Text = objDataSet.Tables(0).Rows(0).Item("idfamilia").ToString
                    Txt_DescripFam.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                    Txt_CveFam.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    Txt_DescripFam.Enabled = False
                Else
                    Txt_DescripFam.Enabled = True
                    Txt_DescripFam.Text = ""
                    Txt_DescripFam.Focus()
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub usp_TraerDeptos()
        'mreyes 04/Junio/2012 12:04 p.m.

        Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
            Try
                If Txt_IdDepto.Text.Trim = "" Then
                    Txt_IdDepto.Text = 0
                End If
                If Txt_IdDivisiones.Text.Trim = "" Then
                    Txt_IdDivisiones.Text = 0
                End If
                objDataSet = objCatalogoDeptos.usp_TraerEstDepto(CInt(Txt_IdDepto.Text), CInt(Txt_IdDivisiones.Text), Txt_Clave.Text, 1, "")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_DescripDepto.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                    Txt_Clave.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    Txt_IdDepto.Text = objDataSet.Tables(0).Rows(0).Item("iddepto").ToString
                Else
                    Dim myForm As New frmConsultaEstructura
                    myForm.Tipo = "D"
                    myForm.IdSuperior1 = CInt(Txt_IdDivisiones.Text)
                    myForm.ShowDialog()
                    Txt_IdDepto.Text = myForm.IdCampo
                    Txt_Clave.Text = myForm.ClaveCampo
                    Txt_DescripDepto.Text = myForm.DescripCampo
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
                    Txt_IdDepto.BackColor = TextboxBackColor
                    Txt_IdDepto.BackColor = TextboxBackColor
                    Txt_DescripDepto.BackColor = TextboxBackColor
                Case 1, 2
                    Btn_Aceptar.Enabled = True
                    Btn_Cancelar.Enabled = True
                    Btn_Nuevo.Enabled = False
                    Btn_Editar.Enabled = False
                    If Accion = 1 Then
                        Txt_Clave.Focus()
                    ElseIf Accion = 2 Then
                        Txt_Clave.Focus()

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


    'Private Sub Txt_Clave_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Clave.TextChanged

    'End Sub

    Private Sub Txt_Clave_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Clave.KeyPress
        Try
            e.KeyChar = UCase(e.KeyChar)

            If e.KeyChar = ChrW(Keys.Enter) Then
                e.Handled = True
                SendKeys.Send("{TAB}")
            End If
            Txt_IdDepto.Text = ""
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Clave_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Clave.TextChanged
        Try
            Txt_IdFamilia.Text = ""
            Txt_CveFam.Text = ""
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub Pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub



    Private Sub Txt_ClaveDpto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Clave.LostFocus
        Try
            If Txt_Clave.Text.Trim = "" Then Exit Sub
            usp_TraerDeptos()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub Txt_ClaveFamilia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_CveFam.LostFocus
        Try
            If Txt_CveFam.Text.Trim = "" Then Exit Sub
            usp_TraerFamilia()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_CveFamilia_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_CveFam.KeyPress
        Try
            e.KeyChar = UCase(e.KeyChar)

            If e.KeyChar = ChrW(Keys.Enter) Then
                Dim myForm As New frmConsultaEstructura
                myForm.Tipo = "F"
                myForm.IdSuperior1 = 0
                myForm.Opcion = 2
                myForm.ShowDialog()
                Txt_IdFamilia.Text = myForm.IdCampo
                Txt_CveFam.Text = myForm.ClaveCampo
                Txt_DescripFam.Text = myForm.DescripCampo
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_CveDivision_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_CveDivisiones.TextChanged
        Try
            Txt_IdDepto.Text = ""
            Txt_Clave.Text = ""
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_ClaveDivisiones_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_CveDivisiones.LostFocus
        Try
            If Txt_CveDivisiones.Text.Trim = "" Then Exit Sub
            usp_TraerDivision()
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
                    Txt_IdDivisiones.Text = objDataSet.Tables(0).Rows(0).Item("iddivisiones").ToString
                Else
                    Dim myForm As New frmConsultaEstructura
                    myForm.Tipo = "DI"
                    myForm.ShowDialog()
                    Txt_IdDivisiones.Text = myForm.IdCampo
                    Txt_CveDivisiones.Text = myForm.ClaveCampo
                    Txt_DescripDivisiones.Text = myForm.DescripCampo
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub
End Class
