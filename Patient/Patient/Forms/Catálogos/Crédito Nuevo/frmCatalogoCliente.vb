Public Class frmCatalogoCliente

    Public Accion As Integer
    Dim blnValCliente As Boolean = False
    Public idcliente As Integer
    Dim idsucursal As Integer
    Dim cliente As String
    Dim nombre As String
    Dim appaterno As String
    Dim apmaterno As String
    Dim sexo As String
    Public idestado As Integer
    Public idciudad As Integer
    Public idcolonia As Integer
    Public codigopostal As String
    Dim calle As String
    Dim numero As Integer
    Dim celular1 As String
    Dim email As String
    Dim fecalta As Date
    Dim idusuario As Integer = GLB_Idempleado
    Dim idusuariomodif As Integer
    Dim opcionCombo As Integer = 0
    Dim contador As Integer = 0
    Dim ValidarCombo As Boolean = False



    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click
        Try

            GLB_RefrescarPedido = False
            If Accion = 1 Then '-NUEVO
                If usp_CapturaCliente() = True Then
                    If MsgBox("Estas Seguro de Grabar el cliente?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                        GLB_RefrescarPedido = True
                        MessageBox.Show("Exitosamente Grabado el cliente '" & " !", "Agregando cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Close()
                    End If
                Else
                    If blnValCliente = False Then Exit Sub
                    MessageBox.Show("Error Grabando !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            ElseIf Accion = 2 Then '-ACTUALIZACION
                If usp_CapturaCliente() = True Then
                    If MsgBox("Esta Seguro de Actualizar el cliente?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                        GLB_RefrescarPedido = True
                        MessageBox.Show("Exitosamente Grabado el Cliente  '" & Txt_Nombre.Text & "  " & Txt_ApellidoPa.Text & " !", "Actualizando cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Close()
                    End If
                Else
                    If blnValCliente = False Then Exit Sub
                    MessageBox.Show("Error Grabando !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            ElseIf Accion = 4 Then
                Me.Close()
                Me.Dispose()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Function usp_CapturaCliente() As Boolean
        Using objCatalogo As New BCL.BCLCliente(GLB_ConStringCreditoSQL)

            Try
                blnValCliente = ValidarCliente()
                If blnValCliente = True Then

                    nombre = Txt_Nombre.Text
                    appaterno = Txt_ApellidoPa.Text
                    apmaterno = Txt_ApellidoMa.Text
                    sexo = Cmb_Sexo.Text
                    sexo = sexo.Substring(0, 1)
                    idestado = Cmb_Estado.SelectedValue
                    idciudad = Cmb_Ciudad.SelectedValue
                    idcolonia = Cmb_Colonia.SelectedValue
                    '  codigopostal = Txt_CP.Text
                    calle = Txt_Calle.Text
                    numero = Txt_Numero.Text
                    celular1 = Txt_Telef.Text
                    email = Txt_Email.Text
                    idusuario = GLB_Idempleado
                    idusuariomodif = 0


                    If Accion = 1 Then
                        Application.DoEvents()
                        usp_CapturaCliente = objCatalogo.usp_CapturaCliente(Accion, idcliente, nombre, appaterno, apmaterno, sexo, idestado, idciudad, idcolonia,
                                   codigopostal, calle, numero, celular1, email, idusuario, idusuariomodif)
                        Application.DoEvents()
                    ElseIf Accion = 2 Then
                        Application.DoEvents()
                        usp_CapturaCliente = objCatalogo.usp_CapturaCliente(Accion, idcliente, nombre, appaterno, apmaterno, sexo, idestado, idciudad, idcolonia,
                                   codigopostal, calle, numero, celular1, email, idusuario, idusuariomodif)
                        Application.DoEvents()
                    End If

                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try

        End Using
    End Function

    Private Sub rellenalComboEstado()
        Try
            Dim objDataSetEstado As Data.DataSet
            objDataSetEstado = ModDomicilioPart.usp_TraerInformacionCodigosP(1, codigopostal, idestado, idciudad, idcolonia)
            If objDataSetEstado.Tables(0).Rows.Count > 0 Then
                Cmb_Estado.ValueMember = "idestado"
                Cmb_Estado.DisplayMember = "estado"
                Cmb_Estado.DataSource = objDataSetEstado.Tables(0)
            Else
                Cmb_Estado.DataSource = Nothing
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
                Cmb_Ciudad.ValueMember = "idciudad"
                Cmb_Ciudad.DisplayMember = "ciudad"
                Cmb_Ciudad.DataSource = objDataSetCiudad.Tables(0)
            Else
                Cmb_Ciudad.DataSource = Nothing
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
                Cmb_Colonia.ValueMember = "idcolonia"
                Cmb_Colonia.DisplayMember = "colonia"
                Cmb_Colonia.DataSource = objDataSetColonia.Tables(0)
            Else
                Cmb_Colonia.DataSource = Nothing
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
    Private Sub TextEdit3_EditValueChanged(sender As Object, e As EventArgs) Handles Txt_ApellidoPa.EditValueChanged

    End Sub
    Private Function ValidarCliente() As Boolean
        ValidarCliente = True
        Dim BolVal As Boolean = True
        If Txt_Nombre.Text = "" Then
            ValidarCliente = False
            Txt_Nombre.Focus()
            MessageBox.Show("Debe ingresar el Nombre correctamente.", "ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Function
        End If
        If Txt_ApellidoPa.Text = "" Then
            ValidarCliente = False
            Txt_ApellidoPa.Focus()
            MessageBox.Show("Debe ingresar el Apellido Paterno correctamente.", "ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Function
        End If
        If Txt_ApellidoMa.Text = "" Then
            ValidarCliente = False
            Txt_ApellidoMa.Focus()
            MessageBox.Show("Debe ingresar el Apellido Materno correctamente.", "ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Function
        End If
        If Cmb_Sexo.Text = "" Then
            ValidarCliente = False
            Cmb_Sexo.Focus()
            MessageBox.Show("Debe ingresar el Sexo correctamente.", "ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Function
        End If
        If Txt_Calle.Text = "" Then
            ValidarCliente = False
            Txt_Calle.Focus()
            MessageBox.Show("Debe ingresar la Calle correctamente.", "ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Function
        End If
        If Txt_Numero.Text = "" Then
            ValidarCliente = False
            Txt_Numero.Focus()
            MessageBox.Show("Debe ingresar el Número correctamente.", "ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Function
        End If
        'If Txt_CP.Text = "" Then
        '    ValidarCliente = False
        '    Txt_CP.Select()
        '    MessageBox.Show("Debe ingresar el Código Postal correctamente.", "ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Exit Function
        'End If
        If Cmb_Colonia.Text = "" Then
            ValidarCliente = False
            Cmb_Colonia.Focus()
            MessageBox.Show("Debe ingresar la Colonia correctamente.", "ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Function
        End If
        If Cmb_Ciudad.Text = "" Then
            ValidarCliente = False
            Cmb_Ciudad.Focus()
            MessageBox.Show("Debe ingresar la Ciudad correctamente.", "ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Function
        End If
        If Cmb_Estado.Text = "" Then
            ValidarCliente = False
            Cmb_Estado.Focus()
            MessageBox.Show("Debe ingresar el Estado correctamente.", "ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Function
        End If
        If Txt_Telef.Text = "" Then
            ValidarCliente = False
            Txt_Telef.Focus()
            MessageBox.Show("Debe ingresar el Teléfono correctamente.", "ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Function
        End If
        If Txt_Email.Text = "" Then
            ValidarCliente = False
            Txt_Email.Focus()
            MessageBox.Show("Debe ingresar el Email correctamente.", "ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Function
        End If



    End Function

    Private Sub frmCatalogoCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Accion = 2 Or Accion = 3 Then
            Cmb_Estado.SelectedValue = idestado
            Cmb_Ciudad.SelectedValue = idciudad
            Cmb_Colonia.SelectedValue = idcolonia
            Call rellenalComboEstado()
            Call rellenalComboCiudad()
            Call rellenalComboColonia()
            Call rellenalCodigoPostal()
        ElseIf Accion = 1 Then
            codigopostal = ""
            idestado = 0
            idciudad = 0
            idestado = 0
            Call rellenalComboEstado()
        End If

    End Sub

    Private Sub Txt_Nombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Nombre.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If Char.IsLower(e.KeyChar) Then


            Txt_Nombre.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub

    Private Sub Txt_ApellidoPa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_ApellidoPa.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If Char.IsLower(e.KeyChar) Then


            Txt_ApellidoPa.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub

    Private Sub Txt_ApellidoMa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_ApellidoMa.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If Char.IsLower(e.KeyChar) Then


            Txt_ApellidoMa.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub

    Private Sub Txt_Calle_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Calle.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If Char.IsLower(e.KeyChar) Then


            Txt_Calle.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub

    Private Sub Txt_Email_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Email.KeyPress
        If Char.IsLower(e.KeyChar) Then


            Txt_Email.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub

    'Public Class Example
    '    Public Id As Integer  Get Set 
    '    Public Name { Get Set }
    'End Class



    'Private Sub Cmb_Colonia_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles Cmb_Colonia.EditValueChanging
    '    idcolonia = Cmb_Colonia.
    'End Sub

    Private Sub Txt_Telef_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Telef.KeyDown

    End Sub

    Private Sub Txt_Telef_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Telef.KeyPress
        pub_SoloNumeros(sender, e)
    End Sub

    Private Sub Txt_Numero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Numero.KeyPress
        pub_SoloNumeros(sender, e)
    End Sub

    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click
        If Accion = 1 Or Accion = 2 Then
            If MsgBox("Esta Seguro que desea salir?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                Me.Close()
                Me.Dispose()
            End If
        Else
            Me.Close()
            Me.Dispose()
        End If
    End Sub

    Private Sub Btn_Limpiar_Click(sender As Object, e As EventArgs)
        If MsgBox("Esta Seguro que desea limpiar todos los campos?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
            Txt_Nombre.Text = ""
            Txt_ApellidoPa.Text = ""
            Txt_ApellidoMa.Text = ""
            Cmb_Sexo.SelectedIndex = 0
            Txt_Telef.Text = ""
            Txt_Email.Text = ""
            'Txt_CP.Text = ""
            Txt_Calle.Text = ""
            Txt_Numero.Text = ""
        End If
    End Sub

    Private Sub Cmb_Colonia_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles Cmb_Colonia.SelectionChangeCommitted
        'Txt_CP.Text = ""
        idestado = Cmb_Estado.SelectedValue
        idciudad = Cmb_Ciudad.SelectedValue
        idcolonia = Cmb_Colonia.SelectedValue
        codigopostal = ""
        ValidarCombo = True
        Call rellenalCodigoPostal()
    End Sub

    Private Sub Cmb_Estado_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles Cmb_Estado.SelectionChangeCommitted
        idestado = Cmb_Estado.SelectedValue
        idciudad = 0
        idcolonia = 0
        codigopostal = ""
        ValidarCombo = True
        Call rellenalComboCiudad()
        Call rellenalComboColonia()
        Call rellenalCodigoPostal()
    End Sub

    Private Sub Cmb_Ciudad_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles Cmb_Ciudad.SelectionChangeCommitted
        idestado = Cmb_Estado.SelectedValue
        idciudad = Cmb_Ciudad.SelectedValue
        idcolonia = 0
        ValidarCombo = True
        Call rellenalComboColonia()
        Call rellenalCodigoPostal()
    End Sub

    Private Sub PanelControl1_Paint(sender As Object, e As PaintEventArgs) Handles Pnl_DatosGenerales.Paint

    End Sub

    Private Sub frmCatalogoCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            If Accion = 1 Or Accion = 2 Then
                If MsgBox("Esta Seguro que desea salir?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    Me.Close()
                    Me.Dispose()
                End If
            Else
                Me.Close()
                Me.Dispose()
            End If
        End If
    End Sub


    'Private Sub Txt_CP_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If (Txt_CP.Text <> "") Then
    '        If Txt_CP.Text.Trim.Length = 5 Then
    '            codigopostal = Txt_CP.Text
    '            idestado = 0
    '            idcolonia = 0
    '            idciudad = 0
    '            Call rellenalComboEstado()
    '            Cmb_Estado.SelectedIndex = 0
    '            Call rellenalComboCiudad()
    '            Cmb_Ciudad.SelectedIndex = 0
    '            Call rellenalComboColonia()
    '            Cmb_Colonia.SelectedIndex = 0
    '        Else
    '            codigopostal = ""
    '            idestado = 0
    '            idcolonia = 0
    '            idciudad = 0
    '            Txt_CP.Text = ""
    '            Call rellenalComboEstado()
    '            Cmb_Estado.SelectedIndex = 0
    '            Call rellenalComboCiudad()
    '            Cmb_Ciudad.SelectedIndex = 0
    '            Call rellenalComboColonia()
    '            Cmb_Colonia.SelectedIndex = 0
    '        End If
    '    End If
    'End Sub

    Private Sub Txt_ApellidoMa_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_ApellidoMa.LostFocus
        Dim ObjDataValidacion As Data.DataSet
        If Txt_Nombre.Text.Length <> 0 And Txt_ApellidoMa.Text.Length <> 0 And Txt_ApellidoPa.Text.Length <> 0 Then
            Using objCatalogo As New BCL.BCLCliente(GLB_ConStringCreditoSQL)
                ObjDataValidacion = objCatalogo.usp_TraerCliente(2, 0, Txt_Nombre.Text, Txt_ApellidoPa.Text, Txt_ApellidoMa.Text)
                If ObjDataValidacion.Tables(0).Rows.Count > 0 Then
                    nombre = Txt_Nombre.Text
                    appaterno = Txt_ApellidoPa.Text
                    apmaterno = Txt_ApellidoMa.Text
                    Txt_Nombre.Text = ""
                    Txt_ApellidoMa.Text = ""
                    Txt_ApellidoPa.Text = ""
                    MessageBox.Show("Ya existe un Cliente con el Nombre " + nombre + " " + appaterno + " " + apmaterno + " .", "ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Txt_Nombre.Focus()

                    nombre = ""
                    appaterno = ""
                    apmaterno = ""
                End If
            End Using
        End If
    End Sub

    Private Sub Txt_ApellidoPa_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_ApellidoPa.LostFocus
        Dim ObjDataValidacion As Data.DataSet
        If Txt_Nombre.Text.Length <> 0 And Txt_ApellidoMa.Text.Length <> 0 And Txt_ApellidoPa.Text.Length <> 0 Then
            Using objCatalogo As New BCL.BCLCliente(GLB_ConStringCreditoSQL)
                ObjDataValidacion = objCatalogo.usp_TraerCliente(2, 0, Txt_Nombre.Text, Txt_ApellidoPa.Text, Txt_ApellidoMa.Text)
                If ObjDataValidacion.Tables(0).Rows.Count > 0 Then
                    nombre = Txt_Nombre.Text
                    appaterno = Txt_ApellidoPa.Text
                    apmaterno = Txt_ApellidoMa.Text
                    Txt_Nombre.Text = ""
                    Txt_ApellidoMa.Text = ""
                    Txt_ApellidoPa.Text = ""
                    MessageBox.Show("Ya existe un Cliente con el Nombre " + nombre + " " + appaterno + " " + apmaterno + " .", "ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Txt_Nombre.Focus()

                    nombre = ""
                    appaterno = ""
                    apmaterno = ""
                End If
            End Using
        End If
    End Sub

    Private Sub Txt_Nombre_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Nombre.LostFocus
        Dim ObjDataValidacion As Data.DataSet
        If Txt_Nombre.Text.Length <> 0 And Txt_ApellidoMa.Text.Length <> 0 And Txt_ApellidoPa.Text.Length <> 0 Then
            Using objCatalogo As New BCL.BCLCliente(GLB_ConStringCreditoSQL)
                ObjDataValidacion = objCatalogo.usp_TraerCliente(2, 0, Txt_Nombre.Text, Txt_ApellidoPa.Text, Txt_ApellidoMa.Text)
                If ObjDataValidacion.Tables(0).Rows.Count > 0 Then
                    nombre = Txt_Nombre.Text
                    appaterno = Txt_ApellidoPa.Text
                    apmaterno = Txt_ApellidoMa.Text
                    Txt_Nombre.Text = ""
                    Txt_ApellidoMa.Text = ""
                    Txt_ApellidoPa.Text = ""
                    MessageBox.Show("Ya existe un Cliente con el Nombre " + nombre + " " + appaterno + " " + apmaterno + " .", "ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Txt_Nombre.Focus()

                    nombre = ""
                    appaterno = ""
                    apmaterno = ""
                End If
            End Using
        End If
    End Sub


    Private Sub Cmb_CP_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmb_CP.LostFocus
        'If Cmb_CP.Text.Length = 5 Then
        '    idestado = 0
        '    idciudad = 0
        '    idcolonia = 0
        '    codigopostal = Cmb_CP.Text
        '    Call rellenalComboEstado()
        '    Call rellenalComboCiudad()
        '    Call rellenalComboColonia()
        'Else
        '    idestado = 0
        '    idciudad = 0
        '    idestado = 0
        '    Call rellenalComboEstado()
        'End If
    End Sub

    Private Sub Cmb_CP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Cmb_CP.KeyPress
        pub_SoloNumeros(sender, e)
    End Sub

    Private Sub Txt_Sucursal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Sucursal.KeyPress
        pub_SoloNumeros(sender, e)
    End Sub

    Private Sub Txt_Cliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Cliente.KeyPress
        pub_SoloNumeros(sender, e)
    End Sub

    Private Sub Cmb_CP_TextChanged(sender As Object, e As EventArgs) Handles Cmb_CP.TextChanged
        If ValidarCombo = False Then
            codigopostal = Cmb_CP.Text
            If codigopostal.Length > 0 Then
                idestado = 0
                idciudad = 0
                idcolonia = 0
                Call rellenalComboEstado()
                Call rellenalComboCiudad()
                Call rellenalComboColonia()
            ElseIf ValidarCombo = True Then
                Call rellenalComboEstado()
                Cmb_Ciudad.DataSource = Nothing
                Cmb_Colonia.DataSource = Nothing
            Else

            End If
        Else
            ValidarCombo = False
        End If
    End Sub
End Class