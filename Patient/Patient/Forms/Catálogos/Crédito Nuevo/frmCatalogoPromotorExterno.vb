Public Class frmCatalogoPromotorExterno
    'lvillegas 09/02/2018 11:47 a.m.
    Private objDataSet As Data.DataSet
    Public opcion As Integer
    Public idPromotorExterno As Integer = 0
    Public idestado As Integer = 0
    Public idciudad As Integer = 0
    Public idcolonia As Integer = 0
    Public CodigoPostal As String
    Public opcionCombo As Integer
    Dim blanvalAbogado As Boolean = False
    Dim fechaInicio As Date = "1900-01-01"


    Function usp_CapturaPromotorExterno() As Boolean
        Using objCaptura As New BCL.BCLPromotorExterno(GLB_ConStringCreditoSQL)

            Try
                blanvalAbogado = ValidarDatos()
                If blanvalAbogado = False Then
                    Exit Function
                End If
                If opcion = 1 Then
                    Application.DoEvents()
                    usp_CapturaPromotorExterno = objCaptura.usp_CapturaPromotorExterno(opcion, idPromotorExterno, Txt_NomPromotor.Text, Txt_Appaterno.Text, Txt_ApMaterno.Text, Cmb_Estado.SelectedValue, Cmb_Ciudad.SelectedValue, Cmb_Colonia.SelectedValue, Cmb_CP.Text, Txt_Calle.Text, Txt_Numero.Text, Txt_Tel1.Text, Txt_Tel2.Text, Txt_Cel1.Text, Txt_Cel2.Text, Txt_Email.Text, GLB_Idempleado, 0, fechaInicio)
                    Application.DoEvents()
                ElseIf opcion = 2 Then
                    Application.DoEvents()
                    usp_CapturaPromotorExterno = objCaptura.usp_CapturaPromotorExterno(opcion, idPromotorExterno, Txt_NomPromotor.Text, Txt_Appaterno.Text, Txt_ApMaterno.Text, Cmb_Estado.SelectedValue, Cmb_Ciudad.SelectedValue, Cmb_Colonia.SelectedValue, Cmb_CP.Text, Txt_Calle.Text, Txt_Numero.Text, Txt_Tel1.Text, Txt_Tel2.Text, Txt_Cel1.Text, Txt_Cel2.Text, Txt_Email.Text, GLB_Idempleado, GLB_Idempleado, DateTime.Now)
                    Application.DoEvents()
                End If



            Catch ExceptionErr As Exception

            End Try

        End Using
    End Function
    Private Sub LabelControl3_Click(sender As Object, e As EventArgs) Handles LabelControl3.Click

    End Sub

    Private Sub btn_Cancelar_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btn_Limpiar_Click(sender As Object, e As EventArgs) Handles btn_Limpiar.Click
        Call limpiar()
    End Sub

    Public Function limpiar()
        Txt_NomPromotor.Text = ""
        Txt_ApMaterno.Text = ""
        Txt_ApMaterno.Text = ""
        Txt_Calle.Text = ""
        Txt_Numero.Text = ""
        Cmb_CP.Text = ""
        Cmb_Estado.Text = ""
        Cmb_Ciudad.Text = ""
        Cmb_Colonia.Text = ""
        Txt_Tel1.Text = ""
        Txt_Tel2.Text = ""
        Txt_Cel1.Text = ""
        Txt_Cel2.Text = ""
        Txt_Email.Text = ""
    End Function

    Private Sub frmCatalogoPromotorExterno_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Txt_NomPromotor.CanFocus Then
            Me.Txt_NomPromotor.Focus()
        Else
            Me.Txt_NomPromotor.Select()
            Me.ActiveControl = Txt_NomPromotor
        End If

        If opcion = 2 Or opcion = 3 Then
            Cmb_Estado.SelectedValue = idestado
            Cmb_Ciudad.SelectedValue = idciudad
            Cmb_Colonia.SelectedValue = idcolonia

            Call rellenalComboEstado()
            Call rellenalComboCiudad()
            Call rellenalComboColonia()
            Call rellenalCodigoPostal()

        ElseIf opcion = 1 Then
            CodigoPostal = ""
            idestado = 0 '' Coahuila de Zaragoza
            idciudad = 0
            idcolonia = 0
            Call rellenalComboEstado()
        End If


    End Sub

    Public Sub getRow(idpromotorexterno As Integer)
        Me.idPromotorExterno = idpromotorexterno
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

    Public Sub getRowCP(cp As Integer)
        Me.CodigoPostal = cp
    End Sub

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click

        Try
            GLB_RefrescarPedido = False

            If ValidarDatos() = False Then
                Exit Sub
            End If

            If opcion = 1 Then ''Es un nuevo registro 

                If MsgBox("Estas Seguro de guardar este Nuevo Promotor Externo?.", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Guardar") = MsgBoxResult.Ok Then
                    If usp_CapturaPromotorExterno() = True Then
                        GLB_RefrescarPedido = True
                        MsgBox("El Promotor " & Txt_NomPromotor.Text & " ha sido exitosamente Guardado.", MsgBoxStyle.Information, "Guardado")
                        Me.Close()

                    Else


                        MessageBox.Show("Error Grabando la información.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If

            ElseIf opcion = 2 Then 'Es una Actualizacion 
                If MsgBox("Estas seguro de Actualizar este Promotor?. ", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    If usp_CapturaPromotorExterno() = True Then
                        GLB_RefrescarPedido = True
                        MsgBox("El promotor ha sido exitosamente Actualizado.", MsgBoxStyle.Information, "Actualizado")
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

    Public Function ValidarDatos()
        ValidarDatos = False

        If Txt_NomPromotor.Text = "" Then
            MsgBox("Debe especificar el Nombre del Promotor.", MsgBoxStyle.Critical, "Error")
            Txt_NomPromotor.Text = ""
            Txt_NomPromotor.Focus()
            Exit Function
        End If



        If Txt_Appaterno.Text = "" Then
            MsgBox("Debe especificar el Apellido Paterno del Promotor.", MsgBoxStyle.Critical, "Error")
            Txt_Appaterno.Text = ""
            Txt_Appaterno.Focus()
            Exit Function
        End If

        If Txt_ApMaterno.Text = "" Then
            MsgBox("Debe especificar el Apellido Materno del Promotor.", MsgBoxStyle.Critical, "Error")
            Txt_ApMaterno.Text = ""
            Txt_ApMaterno.Focus()
            Exit Function

        End If

        If Txt_Calle.Text = "" Then
            MsgBox("Debe especificar la Calle.", MsgBoxStyle.Critical, "Error")
            Txt_Calle.Text = ""
            Txt_Calle.Focus()
            Exit Function
        End If

        If Txt_Numero.Text = "" Then
            MsgBox("Debe especificar el Numero.", MsgBoxStyle.Critical, "Error")
            Txt_Numero.Text = ""
            Txt_Numero.Focus()
            Exit Function
        End If

        If Cmb_CP.Text = "" Then
            MsgBox("Debe especificar el Código Postal", MsgBoxStyle.Critical, "Error")
            Cmb_CP.Text = ""
            Cmb_CP.Focus()
            Exit Function
        End If

        If Cmb_Estado.Text = "" Then
            MsgBox("Debe especificar el Estado.", MsgBoxStyle.Critical, "Error")
            Cmb_Estado.Text = ""
            Cmb_Estado.Focus()
            Exit Function
        End If

        If Cmb_Ciudad.Text = "" Then
            MsgBox("Debe especificar la Ciudad.", MsgBoxStyle.Critical, "Error")
            Cmb_Ciudad.Text = ""
            Cmb_Ciudad.Focus()
            Exit Function
        End If

        If Cmb_Colonia.Text = "" Then
            MsgBox("Debe especificar la Colonia.", MsgBoxStyle.Critical, "Error")
            Cmb_Colonia.Text = ""
            Cmb_Colonia.Focus()
            Exit Function
        End If

        If Txt_Tel1.Text = "" Then
            MsgBox("Debe especificar el primer número de Telefono", MsgBoxStyle.Critical, "Error")
            Txt_Tel1.Text = ""
            Txt_Tel1.Focus()
            Exit Function
        End If

        If Txt_Tel2.Text = "" Then
            MsgBox("Debe especificar el segundo Número de Telefono", MsgBoxStyle.Critical, "Error")
            Txt_Tel2.Text = ""
            Txt_Tel2.Focus()
            Exit Function
        End If

        If Txt_Cel1.Text = "" Then
            MsgBox("Debe especificar el primer número de celular", MsgBoxStyle.Critical, "Error")
            Txt_Cel1.Text = ""
            Txt_Cel1.Focus()
            Exit Function
        End If

        If Txt_Cel2.Text = "" Then
            MsgBox("Debe especificar el segundo número de celular", MsgBoxStyle.Critical, "Error")
            Txt_Cel2.Text = ""
            Txt_Cel2.Focus()
            Exit Function
        End If

        If Txt_Email.Text = "" Then
            MsgBox("Debe de especificar el email del promotor", MsgBoxStyle.Critical, "Error")
            Txt_Email.Text = ""
            Txt_Email.Focus()
            Exit Function
        End If

        ValidarDatos = True
    End Function

    Private Sub Txt_NomPromotor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_NomPromotor.KeyPress
        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If


        If Char.IsLower(e.KeyChar) Then

            'Convert to uppercase, and put at the caret position in the TextBox.
            Txt_NomPromotor.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
        'SOLO LETRAS 

    End Sub

    Private Sub Txt_Appaterno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Appaterno.KeyPress
        'SOLO LETRAS 
        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        If Char.IsLower(e.KeyChar) Then

            'Convert to uppercase, and put at the caret position in the TextBox.
            Txt_Appaterno.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If

    End Sub

    Private Sub Txt_ApMaterno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_ApMaterno.KeyPress
        'SOLO LETRAS 
        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        If Char.IsLower(e.KeyChar) Then

            'Convert to uppercase, and put at the caret position in the TextBox.
            Txt_ApMaterno.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If

    End Sub

    Private Sub Txt_Calle_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Calle.KeyPress
        'SOLO LETRAS 
        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        If Char.IsLower(e.KeyChar) Then

            'Convert to uppercase, and put at the caret position in the TextBox.
            Txt_Calle.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If

    End Sub

    Private Sub Txt_Numero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Numero.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub Txt_CP_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub Txt_Tel1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Tel1.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub Txt_Tel2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Tel2.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub



    Private Sub Txt_Cel1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Cel1.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub Txt_Cel2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Cel2.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub rellenalComboEstado()
        Try
            Dim objDataSetEstado As Data.DataSet
            objDataSetEstado = ModDomicilioPart.usp_TraerInformacionCodigosP(1, CodigoPostal, idestado, idciudad, idcolonia)
            If objDataSetEstado.Tables(0).Rows.Count > 0 Then
                Cmb_Estado.ValueMember = "idestado"
                Cmb_Estado.DisplayMember = "estado"
                Cmb_Estado.DataSource = objDataSetEstado.Tables(0)

            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub rellenalComboCiudad()
        Try
            opcionCombo = 2

            Dim objDataSetCiudad As Data.DataSet
            objDataSetCiudad = ModDomicilioPart.usp_TraerInformacionCodigosP(2, CodigoPostal, idestado, idciudad, idcolonia)
            If objDataSetCiudad.Tables(0).Rows.Count > 0 Then
                Cmb_Ciudad.ValueMember = "idciudad"
                Cmb_Ciudad.DisplayMember = "ciudad"
                Cmb_Ciudad.DataSource = objDataSetCiudad.Tables(0)
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
            objDataSetColonia = ModDomicilioPart.usp_TraerInformacionCodigosP(3, CodigoPostal, idestado, idciudad, idcolonia)
            If objDataSetColonia.Tables(0).Rows.Count > 0 Then
                Cmb_Colonia.ValueMember = "idcolonia"
                Cmb_Colonia.DisplayMember = "colonia"
                Cmb_Colonia.DataSource = objDataSetColonia.Tables(0)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub rellenalCodigoPostal()
        Try
            Dim objDataSetCodigoPost As Data.DataSet
            objDataSetCodigoPost = ModDomicilioPart.usp_TraerInformacionCodigosP(4, CodigoPostal, idestado, idciudad, idcolonia)
            If objDataSetCodigoPost.Tables(0).Rows.Count > 0 Then
                Cmb_CP.ValueMember = "codigopostal"
                Cmb_CP.DisplayMember = "codigopostal"
                Cmb_CP.DataSource = objDataSetCodigoPost.Tables(0)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub Cmb_Colonia_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles Cmb_Colonia.SelectionChangeCommitted
        idestado = Cmb_Estado.SelectedValue
        idciudad = Cmb_Ciudad.SelectedValue
        idcolonia = Cmb_Colonia.SelectedValue
        Call rellenalComboColonia()
    End Sub

    Private Sub Cmb_Ciudad_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles Cmb_Ciudad.SelectionChangeCommitted
        idestado = Cmb_Estado.SelectedValue
        idciudad = Cmb_Ciudad.SelectedValue
        idcolonia = 0
        Call rellenalComboColonia()
    End Sub

    Private Sub Cmb_Estado_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles Cmb_Estado.SelectionChangeCommitted
        idestado = Cmb_Estado.SelectedValue
        idciudad = 0
        idcolonia = 0
        Call rellenalComboCiudad()
        Call rellenalComboColonia()
    End Sub

    Private Sub Cmb_CP_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmb_CP.LostFocus
        If Cmb_CP.Text.Length = 5 Then
            opcionCombo = 4
            idestado = 0
            idciudad = 0
            idcolonia = 0
            CodigoPostal = Cmb_CP.Text
            Call rellenalComboEstado()
            Call rellenalComboCiudad()
            Call rellenalComboColonia()
        End If
    End Sub
End Class