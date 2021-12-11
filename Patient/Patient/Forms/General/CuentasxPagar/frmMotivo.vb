Public Class frmMotivo


    Dim Sql As String
    Public Sw_Filtro As Boolean = False
    Public Sw_Cancelar As Boolean = False

    Public Opcion As Integer

    Private objDataSet As Data.DataSet

    Private Sub frmConsultaEstilo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call GenerarToolTip()
        Call LLenarComboMotivoBaja()

        If Opcion = 4 Then
            Call usp_TraerMotivoSB()
            Cbo_Motivo.Enabled = False
        End If
    End Sub

    Private Sub usp_TraerMotivoSB()
        Try
            Using objFact As New BCL.BCLFacturas(GLB_ConStringCipSis)
                objDataSet = objFact.usp_TraerMotivoSB(Txt_IdFolio.Text, Txt_Folio.Text)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Cbo_Motivo.SelectedValue = objDataSet.Tables(0).Rows(0).Item("idmotivo")
                End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        Try
            If ValidarEdicion() = True Then

                If Opcion = 1 Then
                    ' Actualiza el campo 'pagado' en factprov
                    Using objCatCuentas As New BCL.BCLCatalogoCuentas(GLB_ConStringCipSis)
                        objCatCuentas.usp_ActualizaPagoFactura(1, Txt_Folio.Text, "2", "", 0)
                    End Using

                    ' selected value

                    Using objFacturas As New BCL.BCLFacturas(GLB_ConStringCipSis)
                        If Not objFacturas.usp_CapturaMotivoSB(Txt_IdFolio.Text, Txt_Folio.Text, Cbo_Motivo.SelectedValue, GLB_Idempleado) Then
                            Throw New Exception("No se pudo grabar el motivo.")
                        Else
                            MsgBox("Motivo grabado correctamente.", MsgBoxStyle.Information, "Confirmación")
                            Sw_Filtro = True
                            Me.Dispose()
                            Me.Close()
                        End If
                    End Using

                Else
                    Me.Dispose()
                    Me.Close()
                End If

                
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Function ValidarEdicion() As Boolean
        ValidarEdicion = False
        Try
            If Cbo_Motivo.Text.Length = 0 Then
                MsgBox("Debe seleccionar un Motivo para la pausa del pago de la Remisión.", MsgBoxStyle.Critical, "Validación")
                Cbo_Motivo.Focus()
                Exit Function
            End If

            ValidarEdicion = True
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Function

    Private Sub frmMotivos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then
                Me.Dispose()
                Me.Close()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Descripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
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

   
    Private Sub LLenarComboMotivoBaja()
        Using objFAct As New BCL.BCLFacturas(GLB_ConStringCipSis)
            Try
                objDataSet = objFAct.usp_TraerMotivosRem()
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Cbo_Motivo.DataSource = objDataSet.Tables(0).DefaultView
                    Cbo_Motivo.DisplayMember = "descrip"
                    Cbo_Motivo.ValueMember = "idmotivo"
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub
End Class