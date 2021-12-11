Public Class frmCapturaTipoVivienda
    'lvillegas 22/01/2018 9:50 a.m.
    Dim Sql As String 'conexion Base de Datos
    Private ObjDataSet As Data.DataSet
    Dim blanvalTipoVivienda As Boolean
    Public idtipovivienda As Integer = 0
    Dim fechaInicio As Date = "1900-01-01"
    Public Opcionn As Integer  '' 1  = nuevo, 2 = eliminar(no usar) , 3 = editar , 4 = consultar 

    Function usp_capturaTipoVivienda() As Boolean
        Using objCaptura As New BCL.BCLTipoVivienda(GLB_ConStringSircoControlSQL)

            Try
                blanvalTipoVivienda = Validar()
                If blanvalTipoVivienda = True Then
                    If Opcionn = 1 Then
                        Application.DoEvents()
                        usp_capturaTipoVivienda = objCaptura.usp_capturaTipoVivienda(Opcionn, idtipovivienda, Txt_tipovivienda.Text, Txt_Observaciones.Text, GLB_Idempleado, 0, fechaInicio)
                        Application.DoEvents()
                    ElseIf Opcionn = 3 Then
                        Application.DoEvents()
                        usp_capturaTipoVivienda = objCaptura.usp_capturaTipoVivienda(Opcionn, idtipovivienda, Txt_tipovivienda.Text, Txt_Observaciones.Text, GLB_Idempleado, GLB_Idempleado, DateTime.Now)
                        Application.DoEvents()
                    End If

                End If

            Catch ExceptionErr As Exception

            End Try

        End Using
    End Function


    Private Function Validar() As Boolean

        Validar = False


        If Txt_tipovivienda.Text = "" Then
            MsgBox("Debe especificar el Tipo Vivienda.", MsgBoxStyle.Critical, "Error")
            Txt_tipovivienda.Text = ""
            Txt_tipovivienda.Focus()
            Exit Function
        End If

        If Txt_Observaciones.Text = "" Then
            MsgBox("Debe especificar las Observaciones.", MsgBoxStyle.Critical, "Error")
            Txt_Observaciones.Text = ""
            Txt_Observaciones.Focus()
            Exit Function
        End If

        Validar = True
    End Function


    Private Sub Btn_Excel_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Btn_Consultar_Click(sender As Object, e As EventArgs)
        Dim myform = New frmPpalTipoVivenda
    End Sub

    Private Sub Btn_Salir_Click_1(sender As Object, e As EventArgs)
        Me.Close()
        Me.Dispose()
    End Sub

    Public Sub limpiarCampos()
        Txt_tipovivienda.Text = ""
        Txt_Observaciones.Text = ""
    End Sub

    Private Sub Btn_LimpiarCampos_Click(sender As Object, e As EventArgs) Handles Btn_LimpiarCampos.Click
        Call limpiarCampos()
    End Sub

    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click
        Try
            GLB_RefrescarPedido = False

            If Validar() = False Then
                Exit Sub
            End If

            If Opcionn = 1 Then ''Es un nuevo registro en tipoVivienda

                If MsgBox("Estas Seguro de guardar este registro de vivienda?. ", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Guardar") = MsgBoxResult.Ok Then
                    If usp_capturaTipoVivienda() = True Then
                        GLB_RefrescarPedido = True
                        MessageBox.Show("Exitosamente Guardado el Tipo de Vivienda: " & Txt_tipovivienda.Text & " con la Siguiente Observacion: " & Txt_Observaciones.Text & ".")

                        Me.Close()

                    Else


                        MessageBox.Show("Error Grabando la información", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If

            ElseIf Opcionn = 3 Then 'Es una Actualizacion 
                If MsgBox("Estas seguro de Actualizar el Tipo de Vivienda?. ", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    If usp_capturaTipoVivienda() = True Then
                        MessageBox.Show("Exitosamente Guardado")
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

    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs)
        If Opcionn = 1 Or Opcionn = 3 Then
            If MessageBox.Show("Estas seguro de cancelar el registro ?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                'Me.Dispose()
                Me.Close()

            End If
        Else
            Me.Close()
            Me.Dispose()
        End If
    End Sub

    Private Sub Txt_tipovivienda_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_tipovivienda.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Observaciones_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Observaciones.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Friend Sub getRow(idtipovivienda As Integer)
        Me.idtipovivienda = idtipovivienda
    End Sub

    Private Sub Btn_Cancelar_Click_1(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub frmCapturaTipoVivienda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Txt_tipovivienda.CanFocus Then
            Me.Txt_tipovivienda.Focus()
        Else
            Me.Txt_tipovivienda.Select()
            Me.ActiveControl = Txt_tipovivienda
        End If
    End Sub
End Class