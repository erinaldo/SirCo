Public Class frmCatalogoCancelarVentas




    Public opcion As Integer = 0
    Public iDdistrib As Integer = 0
    Private objDataSet As Data.DataSet


    Public Function limpiar()
        Txt_Inicio.Text = ""
        Txt_Fin.Text = ""
        Txt_Folio1.Text = ""
        Txt_Motivo.Text = ""
        Txt_Distri.Text = ""
        Dt_FechaEntrega.Text = ""
    End Function

    Private Sub btn_Limpiar_Click(sender As Object, e As EventArgs) Handles btn_Limpiar.Click
        limpiar()
    End Sub

    Private Sub btn_Cancelar_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click
        Try
            Dim Guardo As Boolean = False
            'If (Txt_Inicio.Text >= Txt_Fin.Text) Then
            If ValidarDatos() = False Then Exit Sub
                GLB_RefrescarPedido = False
            If opcion = 1 Then
                If MsgBox("Estas Seguro de Cancelar esta Valera", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmación") = MsgBoxResult.Ok Then

                    Using objCaptura As New BCL.BCLCancelarVales(GLB_ConStringCreditoSQL)
                        Guardo = objCaptura.usp_CapturaCancelarVales(opcion, Txt_Distri.Text, Txt_Folio1.Text, Txt_Inicio.Text, Txt_Fin.Text, 1, GLB_Idempleado, 0, "1900-01-01")
                    End Using
                    GLB_RefrescarPedido = True
                    MsgBox("Exitosamente Cancelada la Valera", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Cancelada")
                    Me.Close()

                End If

            End If

        Catch ExceptionErr As Exception
            MessageBox.Show("La Valera ya se Encuentra Cancelada")
            Me.Close()
        End Try

    End Sub
    Private Sub Txt_Folio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        ' Ir a buscar que si exista el folio de la valera.

        'Txt_Folio1.Text = Txt_Folio.Text.PadLeft(7)
        'If Txt_Folio.Text = "" Then Exit Sub

        'Using objCapturaA As New BCL.BCLCancelarVales(GLB_ConStringSircoCreditoSQL)
        'Try


        '    objDataSet = objCapturaA.usp_MostrarCancelarVales(0, 0, Txt_Folio.Text, "", "", 0, 0, 0, "")
        '    
        '    If objDataSet.Tables(0).Rows.Count > 0 Then
        '        ' Si lo encontro

        '    Else
        '        MsgBox("Estilo no encontrado, No pertenece a la marca.", MsgBoxStyle.Critical, "Aviso")
        '        Txt_ModeloNuevo.Text = ""
        '        Txt_ModeloNuevo.Focus()
        '    End If
        '    Call CargarFotoNueva()
        'Catch ExceptionErr As Exception
        '    MessageBox.Show(ExceptionErr.Message.ToString)
        'End Try
        'End Using


    End Sub
    Public Function ValidarDatos() As Boolean
        ValidarDatos = False


        If Txt_Inicio.Text = "" Then
            MsgBox("Debe especificar el Inicio de la Valera.", MsgBoxStyle.Critical, "Error")
            Txt_Inicio.Text = ""
            Txt_Inicio.Focus()
            Exit Function
        End If


        If Txt_Fin.Text = "" Then
            MsgBox("Debe especificar el final de la Valera.", MsgBoxStyle.Critical, "Error")
            Txt_Fin.Text = ""
            Txt_Fin.Focus()
            Exit Function
        End If

        If Txt_Folio1.Text = "" Then
            MsgBox("Debe especificar el Folio de la Valera.", MsgBoxStyle.Critical, "Error")
            Txt_Folio1.Text = ""
            Txt_Folio1.Focus()
            Exit Function
        End If

        If Txt_Distri.Text = "" Then
            MsgBox("Debe especificar el Folio de la Valera.", MsgBoxStyle.Critical, "Error")
            Txt_Distri.Text = ""
            Txt_Distri.Focus()
            Exit Function
        End If

        ValidarDatos = True

    End Function
    Private Sub Lbl_AL_Click(sender As Object, e As EventArgs) Handles Lbl_AL.Click

    End Sub

    Private Sub frmCatalogoCancelarVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Txt_Inicio.CanFocus Then
            Me.Txt_Inicio.Focus()
        Else
            Me.Txt_Inicio.Select()
            Me.ActiveControl = Txt_Inicio
        End If
    End Sub

    Private Sub Txt_Motivo_EditValueChanged(sender As Object, e As EventArgs) Handles Txt_Motivo.EditValueChanged

    End Sub
End Class