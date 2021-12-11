Public Class frmCatalogoAbogados
    Private ObjDataSet As Data.DataSet
    Public opcion As Integer   'opcion 1 para insertar, 2 modificar y 3 traer datos
    Public idAbogado As Integer = 0
    Dim blanvalAbogado As Boolean
    Dim fechaInicio As Date = "1900-01-01"
    Dim nombre As String = ""
    Dim appaterno As String = ""
    Dim apmaterno As String = ""

    Dim opcionCombo As Integer = 0
    Public codigopostal As String = ""
    Public idestado As Integer = 0
    Public idciudad As Integer = 0
    Public idcolonia As Integer = 0


    Public idestado1 As Integer = 0
    Public idciudad1 As Integer = 0
    Public idcolonia1 As Integer = 0
    Public CodigoPostal1 As String


    Function usp_CapturaAbogado() As Boolean
        Using objCaptura As New BCL.BCLAbogados(GLB_ConStringCreditoSQL)

            Try
                blanvalAbogado = ValidarDatos()
                If blanvalAbogado = False Then
                    Exit Function
                End If
                If opcion = 1 Then
                    Application.DoEvents()
                    usp_CapturaAbogado = objCaptura.usp_CapturaAbogado(opcion, idAbogado, Txt_nomAbogado.Text, Txt_Appaterno.Text, Txt_ApMaterno.Text, Txt_Cedula.Text, Cmb_EstadoDomicilio.SelectedValue, Cmb_CiudadDomicilio.SelectedValue, Cmb_CiudadDomicilio.SelectedValue, Cmb_CP.Text, Txt_CalleDomicilio.Text, Txt_NumeroDomicilio.Text, Txt_Tel1contacto.Text, Txt_Tel2contacto.Text, Txt_Cel1contacto.Text, Txt_Cel2contacto.Text, Txt_Emailcontacto.Text, Txt_NombreDespacho.Text, Cmb_EstadoDespacho.SelectedValue, Cmb_CiudadDespacho.SelectedValue, Cmb_ColoniaDespacho.SelectedValue, Cmb_CP.Text, Txt_CalleDespacho.Text, Txt_EntrecallesDespacho.Text, Txt_NumeroDespacho.Text, GLB_Idempleado, Dt_FechaAsignacion.Text, 0, fechaInicio)
                    Application.DoEvents()
                ElseIf opcion = 2 Then
                    Application.DoEvents()
                    usp_CapturaAbogado = objCaptura.usp_CapturaAbogado(opcion, idAbogado, Txt_nomAbogado.Text, Txt_Appaterno.Text, Txt_ApMaterno.Text, Txt_Cedula.Text, Cmb_EstadoDomicilio.SelectedValue, Cmb_CiudadDomicilio.SelectedValue, Cmb_ColoniaDomicilio.SelectedValue, Cmb_CP.Text, Txt_CalleDomicilio.Text, Txt_NumeroDomicilio.Text, Txt_Tel1contacto.Text, Txt_Tel2contacto.Text, Txt_Cel1contacto.Text, Txt_Cel2contacto.Text, Txt_Emailcontacto.Text, Txt_NombreDespacho.Text, Cmb_EstadoDespacho.SelectedValue, Cmb_CiudadDespacho.SelectedValue, Cmb_ColoniaDespacho.SelectedValue, Cmb_CP1.Text, Txt_CalleDespacho.Text, Txt_EntrecallesDespacho.Text, Txt_NumeroDespacho.Text, GLB_Idempleado, Dt_FechaAsignacion.Text, GLB_Idempleado, Dt_FechaAsignacion.Text)
                    Application.DoEvents()
                End If



            Catch ExceptionErr As Exception

            End Try

        End Using
    End Function

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click

        Try
            GLB_RefrescarPedido = False

            If ValidarDatos() = False Then
                Exit Sub
            End If

            If opcion = 1 Then ''Es un nuevo registro 

                If MsgBox("Estas Seguro de guardar este Nuevo Abogado?.", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Guardar") = MsgBoxResult.Ok Then
                    If usp_CapturaAbogado() = True Then
                        GLB_RefrescarPedido = True
                        MsgBox("El Abogado " & Txt_nomAbogado.Text & " ha sido exitosamente Guardado.", MsgBoxStyle.Information, "Guardado")
                        Me.Close()

                    Else


                        MessageBox.Show("Error Grabando la información.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If

            ElseIf opcion = 2 Then 'Es una Actualizacion 
                If MsgBox("Estas seguro de Actualizar este Abogado?. ", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    If usp_CapturaAbogado() = True Then
                        GLB_RefrescarPedido = True
                        MsgBox("El Abogado ha sido actualizado exitosamente.", MsgBoxStyle.Information, "Actualizado")
                        Me.Close()

                    Else
                        MessageBox.Show("Error Grabando !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    End If
                End If

            End If



        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub Txt_nomAbogado_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_nomAbogado.LostFocus
        ' Ir a buscar que si exista el modelo con la marca.

        'Txt_nomAbogado.Text = Txt_nomAbogado.Text.PadLeft(7)
        'If Txt_nomAbogado.Text = "" Then Exit Sub

        'Using objCatalogoAbogado As New BCL.BCLAbogados(GLB_ConStringSircoCreditoSQL)
        '    Try


        '        ObjDataSet = objCatalogoAbogado.usp_traerNombreAbogado(1, Txt_nomAbogado.Text, Txt_Appaterno.Text, Txt_ApMaterno.Text)

        '        If ObjDataSet.Tables(0).Rows.Count > 0 Then
        '            nombre = ObjDataSet.Tables(0).Rows(0).Item("nombre").ToString
        '            appaterno = ObjDataSet.Tables(0).Rows(0).Item("appaterno").ToString
        '            apmaterno = ObjDataSet.Tables(0).Rows(0).Item("apmaterno").ToString
        '            MsgBox("Abogado no encontrado, No pertenece a la marca.", MsgBoxStyle.Critical, "Aviso")
        '        End If
        '        '    ' Si lo encontro

        '        'Else
        '        '    MsgBox("Abogado no encontrado, No pertenece a la marca.", MsgBoxStyle.Critical, "Aviso")
        '        '    Txt_nomAbogado.Text = ""
        '        '    Txt_nomAbogado.Focus()
        '        'End If
        '        'Call CargarFotoNueva()
        '    Catch ExceptionErr As Exception
        '        MessageBox.Show(ExceptionErr.Message.ToString)
        '    End Try
        'End Using


    End Sub
    Public Function limpiar()
        Txt_nomAbogado.Text = ""
        Txt_Appaterno.Text = ""
        Txt_ApMaterno.Text = ""
        Txt_Cedula.Text = ""
        Cmb_ColoniaDomicilio.Text = ""
        Cmb_CiudadDomicilio.Text = ""
        Cmb_EstadoDomicilio.Text = ""

        Txt_CalleDomicilio.Text = ""
        Txt_NumeroDomicilio.Text = ""
        Cmb_CP.Text = ""

        Txt_NombreDespacho.Text = ""
        Txt_CalleDespacho.Text = ""
        Txt_NumeroDespacho.Text = ""
        Cmb_CP1.Text = ""
        Cmb_ColoniaDespacho.Text = ""
        Cmb_CiudadDespacho.Text = ""
        Cmb_EstadoDespacho.Text = ""
        Txt_EntrecallesDespacho.Text = ""
        Dt_FechaAsignacion.Text = ""

        Txt_Tel1contacto.Text = ""
        Txt_Tel2contacto.Text = ""
        Txt_Cel1contacto.Text = ""
        Txt_Cel2contacto.Text = ""
        Txt_Emailcontacto.Text = ""
    End Function

    'Public Function ValidarTextBoxCp() As Boolean
    '    If Txt_CPdomicilio.Text = "" Then
    '        MsgBox("Debe especificar el Código Postal del Domicilio.", MsgBoxStyle.Critical, "Error")
    '        Txt_CPdomicilio.Text = ""
    '        Txt_CPdomicilio.Focus()
    '        Exit Function
    '    End If
    'End Function
    Public Function ValidarDatos() As Boolean
        ValidarDatos = False

        If Txt_nomAbogado.Text = "" Then
            MsgBox("Debe especificar el Nombre del Abogado.", MsgBoxStyle.Critical, "Error")
            Txt_NombreAbogado.Text = ""
            Txt_NombreAbogado.Focus()
            Exit Function
        End If



        If Txt_Appaterno.Text = "" Then
            MsgBox("Debe especificar el Apellido Paterno del Abogado.", MsgBoxStyle.Critical, "Error")
            Txt_ApePaternoAbogado.Text = ""
            Txt_ApePaternoAbogado.Focus()
            Exit Function
        End If



        If Txt_ApMaterno.Text = "" Then
            MsgBox("Debe especificar el Apellido Materno del Abogado.", MsgBoxStyle.Critical, "Error")
            Txt_ApeMaternoAbogado.Text = ""
            Txt_ApeMaternoAbogado.Focus()
            Exit Function
        End If



        If Txt_Cedula.Text = "" Then
            MsgBox("Debe especificar la Cédula del Abogado.", MsgBoxStyle.Critical, "Error")
            Txt_CedulaAbogado.Text = ""
            Txt_CedulaAbogado.Focus()
            Exit Function
        End If



        If Txt_CalleDomicilio.Text = "" Then
            MsgBox("Debe especificar la calle del Domicilio Particular.", MsgBoxStyle.Critical, "Error")
            Txt_CalleDomicilio.Text = ""
            Txt_CalleDomicilio.Focus()
            Exit Function
        End If



        If Txt_NumeroDomicilio.Text = "" Then
            MsgBox("Debe especificar el Número del Domicilio Particular.", MsgBoxStyle.Critical, "Error")
            Txt_NumeroDomicilio.Text = ""
            Txt_NumeroDomicilio.Focus()
            Exit Function
        End If



        If Cmb_CP.Text = "" Then
            MsgBox("Debe especificar el Código Postal del Domicilio Particular.", MsgBoxStyle.Critical, "Error")
            Cmb_CP.Text = ""
            Cmb_CP.Focus()
            Exit Function
        End If


        If Cmb_ColoniaDomicilio.Text = "" Then
            MsgBox("Debe especificar La Colonia del Domicilio.", MsgBoxStyle.Critical, "Error")
            Cmb_ColoniaDomicilio.Text = ""
            Cmb_ColoniaDomicilio.Focus()
            Exit Function
        End If


        If Cmb_CiudadDomicilio.Text = "" Then
            MsgBox("Debe especificar La Ciudad en la que se encuentra el Domicilio.", MsgBoxStyle.Critical, "Error")
            Cmb_CiudadDomicilio.Text = ""
            Cmb_CiudadDomicilio.Focus()
            Exit Function
        End If



        If Cmb_EstadoDomicilio.Text = "" Then
            MsgBox("Debe especificar el estado en el que se encuentra el Domicilio.", MsgBoxStyle.Critical, "Error")
            Cmb_EstadoDomicilio.Text = ""
            Cmb_EstadoDomicilio.Focus()
            Exit Function
        End If



        If Txt_NombreDespacho.Text = "" Then
            MsgBox("Debe especificar el nombre del Despacho del Abogado.", MsgBoxStyle.Critical, "Error")
            Txt_NombreDespacho.Text = ""
            Txt_NombreDespacho.Focus()
            Exit Function
        End If



        If Txt_CalleDespacho.Text = "" Then
            MsgBox("Debe especificar la calle en donde se ubica el despacho.", MsgBoxStyle.Critical, "Error")
            Txt_CalleDespacho.Text = ""
            Txt_CalleDespacho.Focus()
            Exit Function
        End If



        If Txt_NumeroDespacho.Text = "" Then
            MsgBox("Debe especificar el número del Despacho.", MsgBoxStyle.Critical, "Error")
            Txt_NumeroDespacho.Text = ""
            Txt_NumeroDespacho.Focus()
            Exit Function
        End If



        If Cmb_CP1.Text = "" Then
            MsgBox("Debe especificar el Código Postal del Despacho.", MsgBoxStyle.Critical, "Error")
            Cmb_CP1.Text = ""
            Cmb_CP1.Focus()
            Exit Function
        End If




        If Cmb_ColoniaDespacho.Text = "" Then
            MsgBox("Debe especificar la colonia en donde se encuentra el Despacho.", MsgBoxStyle.Critical, "Error")
            Cmb_ColoniaDespacho.Text = ""
            Cmb_ColoniaDespacho.Focus()
            Exit Function
        End If




        If Cmb_CiudadDespacho.Text = "" Then
            MsgBox("Debe especificar la ciudad en donde se encuentra el Despacho.", MsgBoxStyle.Critical, "Error")
            Cmb_CiudadDespacho.Text = ""
            Cmb_CiudadDespacho.Focus()
            Exit Function
        End If




        If Cmb_EstadoDespacho.Text = "" Then
            MsgBox("Debe especificar el estado en donde se encuentra el Despacho.", MsgBoxStyle.Critical, "Error")
            Cmb_EstadoDespacho.Text = ""
            Cmb_EstadoDespacho.Focus()
            Exit Function
        End If


        If Txt_EntrecallesDespacho.Text = "" Then
            MsgBox("Debe especificar entre que calles se encuentra el Despacho.", MsgBoxStyle.Critical, "Error")
            Txt_EntrecallesDespacho.Text = ""
            Txt_EntrecallesDespacho.Focus()
            Exit Function
        End If


        If Dt_FechaAsignacion.Text = "" Then
            MsgBox("Debe especificar la Fecha de Asignacion del Abogado.", MsgBoxStyle.Critical, "Error")
            Dt_FechaAsignacion.Text = ""
            Dt_FechaAsignacion.Focus()
            Exit Function
        End If


        If Txt_Tel1contacto.Text = "" Then
            MsgBox("Debe especificar el 1er Telefono del Domicilio.", MsgBoxStyle.Critical, "Error")
            Txt_Tel1contacto.Text = ""
            Txt_Tel1contacto.Focus()
            Exit Function
        End If


        If Txt_Tel2contacto.Text = "" Then
            MsgBox("Debe especificar el 2do Telefono del Domicilio.", MsgBoxStyle.Critical, "Error")
            Txt_Tel2contacto.Text = ""
            Txt_Tel2contacto.Focus()
            Exit Function
        End If



        If Txt_Cel1contacto.Text = "" Then
            MsgBox("Debe especificar el 1er Número de Celular.", MsgBoxStyle.Critical, "Error")
            Txt_Cel1contacto.Text = ""
            Txt_Cel1contacto.Focus()
            Exit Function
        End If



        If Txt_Cel2contacto.Text = "" Then
            MsgBox("Debe especificar el 2do Número de Celular.", MsgBoxStyle.Critical, "Error")
            Txt_Cel2contacto.Text = ""
            Txt_Cel2contacto.Focus()
            Exit Function
        End If


        If Txt_Emailcontacto.Text = "" Then
            MsgBox("Debe especificar el email.", MsgBoxStyle.Critical, "Error")
            Txt_Emailcontacto.Text = ""
            Txt_Emailcontacto.Focus()
            Exit Function
        End If


        ValidarDatos = True

    End Function

    Public Sub getRow(idabogado As Integer)
        Me.idAbogado = idabogado
    End Sub

    Public Sub getRowCP(CodigoPostal As Integer)
        Me.codigopostal = CodigoPostal
    End Sub
    Public Sub getRowEstado(idestado As Integer)
        Me.idestado = idestado
    End Sub
    Public Sub getRowCiudad(idciudad As Integer)
        Me.idciudad = idciudad
    End Sub

    Public Sub getRowColonia(idcolonia As Integer)
        Me.idcolonia = idcolonia
    End Sub

    Public Sub getRowEstado1(idestado1 As Integer)
        Me.idestado1 = idestado1
    End Sub

    Public Sub getRowCiudad1(idciudad1 As Integer)
        Me.idciudad1 = idciudad1
    End Sub

    Public Sub getRowColonia1(idcolonia1 As Integer)
        Me.idcolonia1 = idcolonia1
    End Sub
    Public Sub getRowCodigoPostal1(CodigoPostal1 As Integer)
        Me.CodigoPostal1 = CodigoPostal1
    End Sub
    Private Sub btn_Salir_Click(sender As Object, e As EventArgs)
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles btn_Limpiar.Click
        limpiar()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        Me.Close()
        Me.Dispose()
    End Sub



    Private Sub txt_numeroDomicilio_KeyPress(sender As Object, e As KeyPressEventArgs)
        Call pub_SoloNumeros(sender, e)
    End Sub

    Private Sub txt_CPdomicilio_KeyPress(sender As Object, e As KeyPressEventArgs)
        Call pub_SoloNumeros(sender, e)
    End Sub

    Private Sub txt_CPdespacho_KeyPress(sender As Object, e As KeyPressEventArgs)
        Call pub_SoloNumeros(sender, e)
    End Sub

    Private Sub txt_numeroDespacho_KeyPress(sender As Object, e As KeyPressEventArgs)
        Call pub_SoloNumeros(sender, e)
    End Sub

    Private Sub txt_nombreAbogado_KeyPress(sender As Object, e As KeyPressEventArgs)

        'If Char.IsLetter(e.KeyChar) Then
        '    e.Handled = False
        'ElseIf Char.IsControl(e.KeyChar) Then
        '    e.Handled = False
        'Else
        '    e.Handled = True
        'End If
    End Sub

    Private Sub Txt_NumeroDomicilio_KeyPress_1(sender As Object, e As KeyPressEventArgs) Handles Txt_NumeroDomicilio.KeyPress
        Call pub_SoloNumeros(sender, e)
    End Sub



    Private Sub Txt_Tel1contacto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Tel1contacto.KeyPress
        Call pub_SoloNumeros(sender, e)
    End Sub

    Private Sub Txt_Tel2contacto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Tel2contacto.KeyPress
        Call pub_SoloNumeros(sender, e)
    End Sub

    Private Sub Txt_Cel1contacto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Cel1contacto.KeyPress
        Call pub_SoloNumeros(sender, e)
    End Sub

    Private Sub Txt_Cel2contacto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Cel2contacto.KeyPress
        Call pub_SoloNumeros(sender, e)
    End Sub

    Private Sub Txt_NumeroDespacho_KeyPress_1(sender As Object, e As KeyPressEventArgs) Handles Txt_NumeroDespacho.KeyPress
        Call pub_SoloNumeros(sender, e)
    End Sub

    Private Sub Txt_CPdespacho_KeyPress_1(sender As Object, e As KeyPressEventArgs)
        Call pub_SoloNumeros(sender, e)
    End Sub

    Private Sub Txt_CPdomicilio_KeyPress_1(sender As Object, e As KeyPressEventArgs)
        Call pub_SoloNumeros(sender, e)
    End Sub

    Private Sub frmCatalogoAbogados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Txt_nomAbogado.CanFocus Then
            Me.Txt_nomAbogado.Focus()
        Else
            Me.Txt_nomAbogado.Select()
            Me.ActiveControl = Txt_nomAbogado
        End If


        If opcion = 2 Or opcion = 3 Then
            Cmb_EstadoDomicilio.SelectedValue = idestado
            Cmb_CiudadDomicilio.SelectedValue = idciudad
            Cmb_ColoniaDomicilio.SelectedValue = idcolonia

            Call rellenalComboEstado()
            Call rellenalComboCiudad()
            Call rellenalComboColonia()
            Call rellenalCodigoPostal()

        ElseIf opcion = 1 Then
            codigopostal = ""
            idestado = 0
            idciudad = 0
            idcolonia = 0
            Call rellenalComboEstado()
        End If

        If opcion = 2 Or opcion = 3 Then
            Cmb_EstadoDespacho.SelectedValue = idestado1
            Cmb_CiudadDespacho.SelectedValue = idciudad1
            Cmb_ColoniaDespacho.SelectedValue = idcolonia1

            Call rellenalComboEstado1()
            Call rellenalComboCiudad1()
            Call rellenalComboColonia1()
            Call rellenalCodigoPostal1()

        ElseIf opcion = 1 Then
            CodigoPostal1 = ""
            idestado1 = 0
            idciudad1 = 0
            idcolonia1 = 0
            Call rellenalComboEstado1()
        End If


    End Sub

    Private Sub Txt_nomAbogado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_nomAbogado.KeyPress
        If Char.IsLower(e.KeyChar) Then

            'Convert to uppercase, and put at the caret position in the TextBox.
            Txt_nomAbogado.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub

    Private Sub Txt_Appaterno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Appaterno.KeyPress
        If Char.IsLower(e.KeyChar) Then

            'Convert to uppercase, and put at the caret position in the TextBox.
            Txt_Appaterno.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub

    Private Sub Txt_ApMaterno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_ApMaterno.KeyPress
        If Char.IsLower(e.KeyChar) Then

            'Convert to uppercase, and put at the caret position in the TextBox.
            Txt_ApMaterno.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If


    End Sub

    Private Sub Txt_Cedula_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Cedula.KeyPress
        If Char.IsLower(e.KeyChar) Then

            'Convert to uppercase, and put at the caret position in the TextBox.
            Txt_Cedula.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub

    Private Sub Txt_CalleDomicilio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_CalleDomicilio.KeyPress
        If Char.IsLower(e.KeyChar) Then

            'Convert to uppercase, and put at the caret position in the TextBox.
            Txt_CalleDomicilio.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub

    Private Sub Cmb_ColoniaDomicilio_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Char.IsLower(e.KeyChar) Then

            'Convert to uppercase, and put at the caret position in the TextBox.
            Cmb_ColoniaDomicilio.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub

    Private Sub Cmb_CiudadDomicilio_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Char.IsLower(e.KeyChar) Then

            'Convert to uppercase, and put at the caret position in the TextBox.
            Cmb_CiudadDomicilio.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub

    Private Sub Cmb_EstadoDomicilio_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Char.IsLower(e.KeyChar) Then

            'Convert to uppercase, and put at the caret position in the TextBox.
            Cmb_EstadoDomicilio.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub

    Private Sub Txt_NombreDespacho_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_NombreDespacho.KeyPress
        If Char.IsLower(e.KeyChar) Then

            'Convert to uppercase, and put at the caret position in the TextBox.
            Txt_NombreDespacho.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub

    Private Sub Txt_CalleDespacho_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_CalleDespacho.KeyPress
        If Char.IsLower(e.KeyChar) Then

            'Convert to uppercase, and put at the caret position in the TextBox.
            Txt_CalleDespacho.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub

    Private Sub Cmb_ColoniaDespacho_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Char.IsLower(e.KeyChar) Then

            'Convert to uppercase, and put at the caret position in the TextBox.
            Cmb_ColoniaDespacho.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub

    Private Sub Cmb_CiudadDespacho_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Char.IsLower(e.KeyChar) Then

            'Convert to uppercase, and put at the caret position in the TextBox.
            Cmb_CiudadDespacho.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub

    Private Sub Cmb_EstadoDespacho_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Char.IsLower(e.KeyChar) Then

            'Convert to uppercase, and put at the caret position in the TextBox.
            Cmb_EstadoDespacho.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub

    Private Sub Txt_EntrecallesDespacho_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_EntrecallesDespacho.KeyPress
        If Char.IsLower(e.KeyChar) Then

            'Convert to uppercase, and put at the caret position in the TextBox.
            Txt_EntrecallesDespacho.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub



    Private Sub Cmb_EstadoDomicilio_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles Cmb_EstadoDomicilio.SelectionChangeCommitted
        idestado = Cmb_EstadoDomicilio.SelectedValue
        idciudad = 0
        idcolonia = 0
        Call rellenalComboCiudad()
        Call rellenalComboColonia()
    End Sub

    Private Sub rellenalComboEstado()
        Try
            Dim objDataSetEstado As Data.DataSet
            objDataSetEstado = ModDomicilioPart.usp_TraerInformacionCodigosP(1, codigopostal, idestado, idciudad, idcolonia)
            If objDataSetEstado.Tables(0).Rows.Count > 0 Then
                Cmb_EstadoDomicilio.ValueMember = "idestado"
                Cmb_EstadoDomicilio.DisplayMember = "estado"
                Cmb_EstadoDomicilio.DataSource = objDataSetEstado.Tables(0)

            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub rellenalComboCiudad()
        Try
            opcionCombo = 2

            Dim objDataSetCiudad As Data.DataSet
            objDataSetCiudad = ModDomicilioPart.usp_TraerInformacionCodigosP(2, codigopostal, idestado, idciudad, idcolonia)
            If objDataSetCiudad.Tables(0).Rows.Count > 0 Then
                Cmb_CiudadDomicilio.ValueMember = "idciudad"
                Cmb_CiudadDomicilio.DisplayMember = "ciudad"
                Cmb_CiudadDomicilio.DataSource = objDataSetCiudad.Tables(0)
                'Cmb_Ciudad.SelectedValue = idciudad
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub rellenalComboColonia()
        Try
            opcionCombo = 3
            Dim objDataSetColonia As Data.DataSet
            objDataSetColonia = ModDomicilioPart.usp_TraerInformacionCodigosP(3, codigopostal, idestado, idciudad, idcolonia)
            If objDataSetColonia.Tables(0).Rows.Count > 0 Then
                Cmb_ColoniaDomicilio.ValueMember = "idcolonia"
                Cmb_ColoniaDomicilio.DisplayMember = "colonia"
                Cmb_ColoniaDomicilio.DataSource = objDataSetColonia.Tables(0)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub rellenalCodigoPostal()
        Try
            Dim objDataSetCodigoPost As Data.DataSet
            objDataSetCodigoPost = ModDomicilioPart.usp_TraerInformacionCodigosP(4, codigopostal, idestado, idciudad, idcolonia)
            If objDataSetCodigoPost.Tables(0).Rows.Count > 0 Then
                Cmb_CP.ValueMember = "codigopostal"
                Cmb_CP.DisplayMember = "codigopostal"
                Cmb_CP.DataSource = objDataSetCodigoPost.Tables(0)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    'Rellenar los combos de Estado, Ciudad y colonia para la parte de el DESPACHO del Abogado
    Private Sub rellenalComboEstado1()
        Try
            Dim objDataSetEstado As Data.DataSet
            objDataSetEstado = ModDomicilioPart.usp_TraerInformacionCodigosP(1, codigopostal, idestado, idciudad, idcolonia)
            If objDataSetEstado.Tables(0).Rows.Count > 0 Then
                Cmb_EstadoDespacho.ValueMember = "idestado"
                Cmb_EstadoDespacho.DisplayMember = "estado"
                Cmb_EstadoDespacho.DataSource = objDataSetEstado.Tables(0)

            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub rellenalComboCiudad1()
        Try
            opcionCombo = 2

            Dim objDataSetCiudad As Data.DataSet
            objDataSetCiudad = ModDomicilioPart.usp_TraerInformacionCodigosP(2, codigopostal, idestado, idciudad, idcolonia)
            If objDataSetCiudad.Tables(0).Rows.Count > 0 Then
                Cmb_CiudadDespacho.ValueMember = "idciudad"
                Cmb_CiudadDespacho.DisplayMember = "ciudad"
                Cmb_CiudadDespacho.DataSource = objDataSetCiudad.Tables(0)
                'Cmb_Ciudad.SelectedValue = idciudad
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub rellenalComboColonia1()
        Try
            opcionCombo = 3
            Dim objDataSetColonia As Data.DataSet
            objDataSetColonia = ModDomicilioPart.usp_TraerInformacionCodigosP(3, codigopostal, idestado, idciudad, idcolonia)
            If objDataSetColonia.Tables(0).Rows.Count > 0 Then
                Cmb_ColoniaDespacho.ValueMember = "idcolonia"
                Cmb_ColoniaDespacho.DisplayMember = "colonia"
                Cmb_ColoniaDespacho.DataSource = objDataSetColonia.Tables(0)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub rellenalCodigoPostal1()
        Try
            Dim objDataSetCodigoPost As Data.DataSet
            objDataSetCodigoPost = ModDomicilioPart.usp_TraerInformacionCodigosP(4, codigopostal, idestado, idciudad, idcolonia)
            If objDataSetCodigoPost.Tables(0).Rows.Count > 0 Then
                Cmb_CP1.ValueMember = "codigopostal"
                Cmb_CP1.DisplayMember = "codigopostal"
                Cmb_CP1.DataSource = objDataSetCodigoPost.Tables(0)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Cmb_CiudadDomicilio_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles Cmb_CiudadDomicilio.SelectionChangeCommitted
        idestado = Cmb_CiudadDomicilio.SelectedValue
        idciudad = Cmb_CiudadDomicilio.SelectedValue
        idcolonia = 0
        Call rellenalComboColonia()
    End Sub

    Private Sub Cmb_ColoniaDomicilio_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles Cmb_ColoniaDomicilio.SelectionChangeCommitted
        idestado = Cmb_ColoniaDomicilio.SelectedValue
        idciudad = Cmb_ColoniaDomicilio.SelectedValue
        idcolonia = Cmb_ColoniaDomicilio.SelectedValue
        Call rellenalComboColonia()
    End Sub

    Private Sub Cmb_EstadoDespacho_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles Cmb_EstadoDespacho.SelectionChangeCommitted
        idestado = Cmb_EstadoDespacho.SelectedValue
        idciudad = 0
        idcolonia = 0
        Call rellenalComboCiudad1()
        Call rellenalComboColonia1()
    End Sub

    Private Sub Cmb_CiudadDespacho_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles Cmb_CiudadDespacho.SelectionChangeCommitted
        idestado = Cmb_CiudadDespacho.SelectedValue
        idciudad = Cmb_CiudadDespacho.SelectedValue
        idcolonia = 0
        Call rellenalComboColonia1()
    End Sub

    Private Sub Cmb_ColoniaDespacho_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles Cmb_ColoniaDespacho.SelectionChangeCommitted
        idestado = Cmb_ColoniaDespacho.SelectedValue
        idciudad = Cmb_ColoniaDespacho.SelectedValue
        idcolonia = Cmb_ColoniaDespacho.SelectedValue
        Call rellenalComboColonia1()
    End Sub

    Private Sub Cmb_CP_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmb_CP.LostFocus
        If Cmb_CP.Text.Length = 5 Then
            opcionCombo = 4
            idestado = 0
            idciudad = 0
            idcolonia = 0
            codigopostal = Cmb_CP.Text
            Call rellenalComboEstado()
            Call rellenalComboCiudad()
            Call rellenalComboColonia()
        End If
    End Sub

    Private Sub Cmb_CP1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmb_CP1.LostFocus
        If Cmb_CP.Text.Length = 5 Then
            opcionCombo = 4
            idestado = 0
            idciudad = 0
            idcolonia = 0
            codigopostal = Cmb_CP.Text
            Call rellenalComboEstado1()
            Call rellenalComboCiudad1()
            Call rellenalComboColonia1()
        End If
    End Sub

    Private Sub Cmb_CP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_CP.SelectedIndexChanged

    End Sub

    Private Sub Cmb_CP_Resize(sender As Object, e As EventArgs) Handles Cmb_CP.Resize

    End Sub
End Class