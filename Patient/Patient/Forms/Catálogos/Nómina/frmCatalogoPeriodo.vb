Public Class frmCatalogoPeriodo
    'mreyes 13/Julio/2012 09:58 a.m.
    Dim Sql As String
    Public Sw_Filtro As Boolean = False
    Public Sw_Cancelar As Boolean = False
    Public Accion As Integer = 0
    Private objDataSet As Data.DataSet
    Dim IdPeriodo As Integer = 0



    Private Sub Txt_Marca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub
    Function Inserta_Periodo() As Boolean
        'mreyes 13/Julio/2012 10:23 a.m.

        Using objCatalogoPeriodo As New BCL.BCLNomina(GLB_ConStringNomSis)
            'Get a new Project DataSet
            Try
                Dim Estatus As String = ""
                If Accion = 1 Then Estatus = "A" Else Estatus = "C"
                'Add the Project
                If Not objCatalogoPeriodo.usp_Captura_Periodo(Accion, IdPeriodo, Txt_IdFrecPago.Text, DTPicker2.Value, DTPicker3.Value, Estatus, GLB_Usuario, GLB_Usuario, Now.Date) Then
                    Throw New Exception("Falló Inserción de PERIODO")
                Else
                    Inserta_Periodo = True
                End If
                'MsgBox("Periodo de Nómina ABIERTO", MsgBoxStyle.Information, "Confirmación")

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        'mreyes 13/Julio/2012 10:13 a.m.


        Try
            If Accion = 1 Then

                If MsgBox("Esta seguro de querer abrir el periodo de nómina?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Yes Then
                    If Inserta_Periodo() = True Then

                        MessageBox.Show("Exitosamente Abierto el Perido '" & DTPicker2.Value & "-" & DTPicker3.Value & " !", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        Me.Close()
                        '' Me.Dispose()
                    Else
                        MessageBox.Show("Error Grabando !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    End If
                End If
            ElseIf Accion = 2 Then ' es una actualización

                If MsgBox("Estas Seguro de Cerrar el Periodo?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Yes Then
                    If Inserta_Periodo() = True Then


                        MessageBox.Show("Exitosamente Cerrado el Periodo '" & DTPicker2.Value & "-" & DTPicker3.Value & " !", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
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



    Private Sub TxtLostfocus(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
        'mreyes 28/Febrero/2012 10:25 a.m.

        Dim myForm As New frmConsulta
        If Txt_Campo.Text.Length = 0 Then Exit Sub
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
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


    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Try
            '' Me.Dispose()
            Sw_Cancelar = True
            Sw_Filtro = False
            Me.Close()
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

    Private Sub DGrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub frmFiltrosFacturas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Sw_Filtro = False
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub frmConsultaEstilo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call GenerarToolTip()
        Accion = 1
        Txt_ClaveFrecPago.Text = "SEM"
        Call Txt_ClaveFrecPago_LostFocus(sender, e)
    End Sub

    Private Sub TxtLostfocusPersis(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
        Dim myForm As New frmConsulta


        If Txt_Campo.Text.Length = 0 Then Exit Sub
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringPerSis)
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






    Private Sub Txt_Sucursal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub CargarFormaConsulta(ByVal TipoC As String, ByVal Opcion As Integer)
        'mreyes 13/Junio/2012 01:28 p.m.
        Try
            Dim myForm As New frmConsulta
            
            If Opcion = 3 Then
                Txt_IdFrecPago.Text = 0
            End If

            myForm.Tipo = TipoC
            myForm.ShowDialog()
           
            If Opcion = 3 Then
                Txt_IdFrecPago.Text = Val(myForm.Campo)
                Txt_ClaveFrecPago.Text = myForm.Campo1
                Txt_DescripFrecPago.Text = myForm.Campo2
                If Txt_ClaveFrecPago.Text.Length = 0 Then
                    Txt_ClaveFrecPago.Focus()
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)

        End Try
    End Sub

    Private Sub Txt_ClaveFrecPago_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_ClaveFrecPago.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_ClaveFrecPago_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_ClaveFrecPago.LostFocus
        'mreyes 13/Junio/2012 07:03 p.m.
        Try
            If Txt_ClaveFrecPago.Text.Length = 0 Then Exit Sub
            Using objMySqlGral As New BCL.BCLCatalogoFrecPago(GLB_ConStringNomSis)
                Try
                    objDataSet = objMySqlGral.usp_PpalCatalogoFrecPago(Txt_ClaveFrecPago.Text)
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Txt_DescripFrecPago.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                        Txt_ClaveFrecPago.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                        Txt_IdFrecPago.Text = objDataSet.Tables(0).Rows(0).Item("idfrecpago").ToString
                    Else
                        Call CargarFormaConsulta("FP", 3)
                    End If


                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)

        End Try
    End Sub

    Private Sub Txt_ClaveFrecPago_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_ClaveFrecPago.TextChanged

    End Sub
End Class