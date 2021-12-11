Public Class frmCatalogosNegExternos
    Private ObjDataSet As Data.DataSet
    Public opcion As Integer = 0
    Public IDnegexterno As Integer = 0
    Dim blanvalAbogado As Boolean
    Dim fechaInicio As Date = "1900-01-01"

    Function usp_CapturaNegocioExterno() As Boolean
        Using objCaptura As New BCL.BCLNegociosExternos(GLB_ConStringSircoControlSQL)

            Try
                blanvalAbogado = ValidarDatos()
                If blanvalAbogado = False Then
                    Exit Function
                End If
                If opcion = 1 Then
                    Application.DoEvents()
                    usp_CapturaNegocioExterno = objCaptura.usp_CapturaNegocioExterno(opcion, IDnegexterno, Txt_Negocio1.Text, Txt_Descripcion1.Text, GLB_Idempleado, 0, fechaInicio)
                    Application.DoEvents()
                ElseIf opcion = 2 Then
                    Application.DoEvents()
                    usp_CapturaNegocioExterno = objCaptura.usp_CapturaNegocioExterno(opcion, IDnegexterno, Txt_Negocio1.Text, Txt_Descripcion1.Text, GLB_Idempleado, GLB_Idempleado, DateTime.Now)
                    Application.DoEvents()
                End If



            Catch ExceptionErr As Exception

            End Try

        End Using
    End Function

    Public Function ValidarDatos() As Boolean
        ValidarDatos = False


        If Txt_Negocio1.Text = "" Then
            MsgBox("Debe especificar el Negocio.", MsgBoxStyle.Critical, "Error")
            Txt_Negocio1.Text = ""
            Txt_Negocio1.Focus()
            Exit Function
        End If





        If Txt_Descripcion1.Text = "" Then
            MsgBox("Debe especificar una Descripción del Negocio.", MsgBoxStyle.Critical, "Error")
            Txt_Descripcion1.Text = ""
            Txt_Descripcion1.Focus()
            Exit Function
        End If


        ValidarDatos = True

    End Function
    Friend Sub getRow(idnegexterno As Integer)
        Me.IDnegexterno = idnegexterno
    End Sub



    Public Function limpiar()
        Txt_Negocio1.Text = ""
        Txt_Descripcion1.Text = ""
    End Function

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles Btn_Limpia.Click
        limpiar()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Txt_Negocio_KeyPress(sender As Object, e As KeyPressEventArgs)



        'If Char.IsLetter(e.KeyChar) Then 'para traer el form principal con un ENTER 
        '    Dim myForm As New frmPpalNegExternos
        '    myForm.ShowDialog()
        '    Txt_Negocio.Focus()
        'End If
    End Sub







    Private Sub Btn_Acepta_Click(sender As Object, e As EventArgs) Handles Btn_Acepta.Click

        Try
            GLB_RefrescarPedido = False

            If ValidarDatos() = False Then
                Exit Sub
            End If

            If opcion = 1 Then ''Es un nuevo registro 

                If MsgBox("Estas Seguro de guardar este Nuevo Negocio Externo?.", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Guardar") = MsgBoxResult.Ok Then
                    If usp_CapturaNegocioExterno() = True Then
                        GLB_RefrescarPedido = True
                        MsgBox("El Negocio Externo " & Txt_Negocio1.Text & " ha sido exitosamente Guardado.", MsgBoxStyle.Information, "Guardado")
                        Me.Close()

                    Else


                        MessageBox.Show("Error Grabando la información.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If

            ElseIf opcion = 2 Then 'Es una Actualizacion 
                If MsgBox("Estas seguro de Actualizar este Negocio Externo?. ", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    If usp_CapturaNegocioExterno() = True Then
                        GLB_RefrescarPedido = True
                        MsgBox("El Negocio Externo ha sido actualizado exitosamente.", MsgBoxStyle.Information, "Actualizado")
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

    Private Sub Txt_Negocio1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Negocio1.KeyPress
        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        If Char.IsLower(e.KeyChar) Then

            'Convert to uppercase, and put at the caret position in the TextBox.
            Txt_Negocio1.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub

    Private Sub Txt_Descripcion1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Descripcion1.KeyPress

        If Char.IsLower(e.KeyChar) Then

            'Convert to uppercase, and put at the caret position in the TextBox.
            Txt_Descripcion1.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub

    Private Sub frmCatalogosNegExternos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Txt_Negocio1.CanFocus Then
            Me.Txt_Negocio1.Focus()
        Else
            Me.Txt_Negocio1.Select()
            Me.ActiveControl = Txt_Negocio1
        End If
    End Sub
End Class