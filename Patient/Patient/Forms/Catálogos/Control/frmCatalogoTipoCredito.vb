Imports DevExpress.XtraEditors.Repository
Public Class frmCatalogoTipoCredito
    ' vgallegos 20/Enero/2018 09:00 am
    Inherits Form
    Dim IdTipoCredito As Integer = 0
    Private objDataSet As Data.DataSet
    Public Accion As Integer  '' 1  = nuevo, 2 = edición , 3 = consultar 
    Dim blnValCredito As Boolean = False
    Dim FechaIn = "1900-01-01"
    Dim tipocredito As String
    Dim idperiodicidad As Integer
    Dim fechalimpago1 As Integer
    Dim fechalimpago2 As Integer
    Dim diacorte1 As Integer
    Dim diacorte2 As Integer
    Dim carterafresco As Integer
    Dim gastofresco As Integer
    Dim interesfresco As Integer
    Dim carteravencido As Integer
    Dim gastovencido As Integer
    Dim interesvencido As Integer
    Dim gastodemanda As Integer
    Dim observaciones As String
    Dim idusuario As Integer
    Dim fum As Integer
    Dim idusuariomodif As Integer
    Dim fummodif As Integer
    Dim ObjDataSetCombo As Data.DataSet

    Public Sub getRow(ByVal idtipocredito As Integer)
        Me.IdTipoCredito = idtipocredito
    End Sub
    Private Sub GenerarToolTip()
        Try

            ToolTip1.SetToolTip(Btn_Aceptar, "Aceptar")
            ToolTip1.SetToolTip(Btn_Cancelar, "Cancelar")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub rellenalComboPerioricidad()
        Try
            objDataSet = ModCombo.rellenalComboPerioricidad
            If objDataSet.Tables(0).Rows.Count > 0 Then
                Cmb_Periodicidad.Properties.ValueMember = "idperiodicidad"
                Cmb_Periodicidad.Properties.DisplayMember = "periodicidad"
                Cmb_Periodicidad.Properties.DataSource = objDataSet.Tables(0)

                Cmb_Periodicidad.Properties.PopulateColumns()
                Cmb_Periodicidad.Properties.Columns(0).Visible = False
                Cmb_Periodicidad.Properties.Columns(2).Visible = False

                'Cmb_Periodicidad.Properties.Columns("idperiodicidad").Visible = False
                'Cmb_Periodicidad.Properties.Columns("dias").Visible = False
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub
    Private Sub Edicion()
        Try
            Select Case Accion
                Case 3, 4
                    Btn_Aceptar.Enabled = True
                    Btn_Cancelar.Enabled = True
                    Pnl_Ppal.Enabled = False



                Case 1, 2
                    Btn_Aceptar.Enabled = True
                    Btn_Cancelar.Enabled = True


            End Select
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Function InsertaTipoCredito() As Boolean

        Using objCatalogo As New BCL.BCLTipoCredito(GLB_ConStringSircoControlSQL)

            Try
                objDataSet = objCatalogo.InsertarTipoCredito()

                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow
                blnValCredito = ValidarCredito()

                If blnValCredito = True Then

                    If Accion = 1 Then
                        'SI AGREGA UNO NUEVO------------------
                        objDataRow.Item("idtipocredito") = IdTipoCredito
                        objDataRow.Item("tipocredito") = Txt_Tipo.Text
                        objDataRow.Item("observaciones") = Txt_Observaciones.Text
                        objDataRow.Item("idusuario") = GLB_Idempleado
                        objDataRow.Item("fum") = DateTime.Now
                        objDataRow.Item("idusuariomodif") = 0
                        objDataRow.Item("fummodif") = FechaIn
                    ElseIf Accion = 2 Then
                        'SI EDITA UN DATO----------------------
                        objDataRow.Item("idtipocredito") = IdTipoCredito
                        objDataRow.Item("tipocredito") = Txt_Tipo.Text
                        objDataRow.Item("observaciones") = Txt_Observaciones.Text
                        objDataRow.Item("idusuario") = GLB_Idempleado
                        objDataRow.Item("fum") = DateTime.Now
                        objDataRow.Item("idusuariomodif") = GLB_Idempleado
                        objDataRow.Item("fummodif") = DateTime.Now
                    End If


                    'objDataSet.Tables(0).Rows.Add(objDataRow)
                    'If Not objCatalogo.usp_CapturaTipoCredito(Accion, objDataSet) Then

                    'Else
                    '    InsertaTipoCredito = True
                    'End If

                End If

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try

        End Using

    End Function

    Function usp_CapturaTipoCredito() As Boolean

        Using objCatalogo As New BCL.BCLTipoCredito(GLB_ConStringSircoControlSQL)

            Try
                blnValCredito = ValidarCredito()
                If blnValCredito = True Then

                    'Asignar valores-------------------------------------
                    tipocredito = Txt_Tipo.Text
                    idperiodicidad = Cmb_Periodicidad.GetSelectedDataRow("idperiodicidad")
                    fechalimpago1 = Txt_FechaLimPag1.Text
                    fechalimpago2 = Txt_FechaLimPag2.Text
                    diacorte1 = Txt_DiaCorte1.Text
                    diacorte2 = Txt_DiaCorte2.Text
                    carterafresco = Txt_CarteraFresca.Text
                    gastofresco = Txt_GastoCarteraFresca.Text
                    interesfresco = Txt_InteresCarteraFresca.Text
                    carteravencido = Txt_CarteraVencida.Text
                    gastovencido = Txt_GastoCarteraVencida.Text
                    interesvencido = Txt_InteresCarteraVencida.Text
                    gastodemanda = Txt_GastoCarteraVencida.Text
                    observaciones = Txt_Observaciones.Text
                    idusuario = GLB_Idempleado
                    idusuariomodif = 0

                    If Accion = 1 Then
                        Application.DoEvents()
                        usp_CapturaTipoCredito = objCatalogo.usp_CapturaTipoCredito(Accion, IdTipoCredito, tipocredito, idperiodicidad, fechalimpago1, fechalimpago2, diacorte1, diacorte2,
                                                            carterafresco, gastofresco, interesfresco, carteravencido, gastovencido, interesvencido, gastodemanda,
                                                            observaciones, idusuario, idusuariomodif)
                        Application.DoEvents()
                    ElseIf Accion = 2 Then
                        Application.DoEvents()
                        usp_CapturaTipoCredito = objCatalogo.usp_CapturaTipoCredito(Accion, IdTipoCredito, tipocredito, idperiodicidad, fechalimpago1, fechalimpago2, diacorte1, diacorte2,
                                                            carterafresco, gastofresco, interesfresco, carteravencido, gastovencido, interesvencido, gastodemanda,
                                                            observaciones, idusuario, idusuariomodif)
                        Application.DoEvents()
                    End If

                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try

        End Using

    End Function

    '-------------------
    Private Function ValidarCredito() As Boolean
        Try
            ValidarCredito = True

            If Txt_Tipo.Text = "" Or Cmb_Periodicidad.EditValue = 0 Or Txt_FechaLimPag1.Text = "" Or Txt_FechaLimPag2.Text = "" Or Txt_DiaCorte1.Text = "" Or Txt_DiaCorte2.Text = "" Or Txt_CarteraFresca.Text = "" Or Txt_GastoCarteraFresca.Text = "" Or Txt_InteresCarteraFresca.Text = "" Or Txt_CarteraVencida.Text = "" Or Txt_GastoCarteraVencida.Text = "" Or Txt_InteresCarteraVencida.Text = "" Or Txt_GastoDemanda.Text = "" Or Txt_Observaciones.Text = "" Then
                ValidarCredito = False
                MessageBox.Show("Debe ingresar los datos correctamente.", "ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Function
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function


    Private Sub TraerTipoCreditoId()
        'vgallegos 20/Enero/2018 1:17 p.m.
        Dim objDataSet As Data.DataSet
        Using objCatalogo As New BCL.BCLTipoCredito(GLB_ConStringSircoControlSQL)
            Try
                ' Acción es igual a 3--- trae un dato espécifico de acuerdo al id 
                Accion = 3
                objDataSet = objCatalogo.usp_TraerTipoCreditoId(Accion, IdTipoCredito, "", "", 0, "", 0, "")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'LLENAR DATOS DEL TIPO DE CRÉDITO----------------------------------------------
                    Txt_Observaciones.Text = objDataSet.Tables(0).Rows(0).Item("observaciones").ToString()

                    Txt_Tipo.Text = objDataSet.Tables(0).Rows(0).Item("tipocredito").ToString()

                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub Btn_Limpiar_Click(sender As Object, e As EventArgs)
        Txt_Observaciones.Text = ""
        Txt_Tipo.Text = ""
        Cmb_Periodicidad.EditValue = 0
        Txt_FechaLimPag1.Text = ""
        Txt_FechaLimPag2.Text = ""
        Txt_DiaCorte1.Text = ""
        Txt_DiaCorte2.Text = ""
        Txt_CarteraFresca.Text = ""
        Txt_GastoCarteraFresca.Text = ""
        Txt_InteresCarteraFresca.Text = ""
        Txt_CarteraVencida.Text = ""
        Txt_GastoCarteraVencida.Text = ""
        Txt_InteresCarteraVencida.Text = ""
        Txt_GastoDemanda.Text = ""
    End Sub

    Private Sub Btn_Aceptar_Click_1(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click
        Try
            GLB_RefrescarPedido = False
            If Accion = 1 Then '''' es nuevo
                If usp_CapturaTipoCredito() = True Then
                    If MsgBox("Estas Seguro de Grabar Tipo de crédito?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                        GLB_RefrescarPedido = True
                        MessageBox.Show("Exitosamente Grabado Tipo de crédito '" & " !", "Agregando Tipo de crédito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Close()
                    End If
                Else
                    If blnValCredito = False Then Exit Sub
                    MessageBox.Show("Error Grabando !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            ElseIf Accion = 2 Then ' es una actualización
                'If MsgBox("Esta Seguro de Actualizar el Tipo de crédito?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                If usp_CapturaTipoCredito() = True Then
                    If MsgBox("Esta Seguro de Actualizar el Tipo de crédito?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                        GLB_RefrescarPedido = True
                        MessageBox.Show("Exitosamente Grabado el Tipo de crédito  '" & Txt_Tipo.Text & " !", "Actualizando Tipo de crédito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Close()
                    End If
                Else
                    If blnValCredito = False Then Exit Sub
                    MessageBox.Show("Error Grabando !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                'End If
            ElseIf Accion = 4 Then
                Me.Close()
                Me.Dispose()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Cancelar_Click_1(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click
        If Accion = 1 Or Accion = 2 Then
            If MsgBox("Estas Seguro de sálir ?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                Me.Close()
            End If
        Else
            Me.Close()
        End If
    End Sub

    Private Sub frmCatalogoTipoCredito_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Accion = 1 Then
            Cmb_Periodicidad.EditValue = 0
        End If

        Call rellenalComboPerioricidad()
    End Sub

    Private Sub LabelTipo_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub LabelControl8_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Txt_InteresCarteraFresca_EditValueChanged(sender As Object, e As EventArgs) Handles Txt_InteresCarteraFresca.EditValueChanged

    End Sub

    Private Sub Txt_FechaLimPag1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_FechaLimPag1.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        Me.Txt_FechaLimPag1.Text = Trim(Replace(Me.Txt_FechaLimPag1.Text, "  ", " "))
    End Sub

    Private Sub Txt_FechaLimPag2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_FechaLimPag2.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        Me.Txt_FechaLimPag2.Text = Trim(Replace(Me.Txt_FechaLimPag2.Text, "  ", " "))
    End Sub

    Private Sub Txt_DiaCorte1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_DiaCorte1.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        Me.Txt_DiaCorte1.Text = Trim(Replace(Me.Txt_DiaCorte1.Text, "  ", " "))
    End Sub

    Private Sub Txt_DiaCorte2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_DiaCorte2.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        Me.Txt_DiaCorte2.Text = Trim(Replace(Me.Txt_DiaCorte2.Text, "  ", " "))
    End Sub

    Private Sub Txt_CarteraFresca_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_CarteraFresca.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        Me.Txt_CarteraFresca.Text = Trim(Replace(Me.Txt_CarteraFresca.Text, "  ", " "))
    End Sub

    Private Sub Txt_GastoCarteraFresca_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_GastoCarteraFresca.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not Txt_GastoCarteraFresca.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub Txt_InteresCarteraFresca_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_InteresCarteraFresca.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        Me.Txt_InteresCarteraFresca.Text = Trim(Replace(Me.Txt_InteresCarteraFresca.Text, "  ", " "))
    End Sub

    Private Sub Txt_CarteraVencida_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_CarteraVencida.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        Me.Txt_CarteraVencida.Text = Trim(Replace(Me.Txt_CarteraVencida.Text, "  ", " "))
    End Sub

    Private Sub Txt_GastoCarteraVencida_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_GastoCarteraVencida.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not Txt_GastoCarteraVencida.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub Txt_InteresCarteraVencida_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_InteresCarteraVencida.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        Me.Txt_InteresCarteraVencida.Text = Trim(Replace(Me.Txt_InteresCarteraVencida.Text, "  ", " "))
    End Sub

    Private Sub frmCatalogoTipoCredito_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        Dim S As String

        S = UCase(e.KeyChar)

        S = ChrW(Asc(S))

        e.KeyChar = S
    End Sub

    Private Sub Txt_Tipo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Tipo.KeyPress
        pub_SoloLetras(sender, e)
        'If Char.IsLower(e.KeyChar) Then

        '    'Convert to uppercase, and put at the caret position in the TextBox.
        '    Txt_Tipo.SelectedText = Char.ToUpper(e.KeyChar)

        '    e.Handled = True
        'End If
    End Sub

    Private Sub Txt_GastoDemanda_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not Txt_GastoDemanda.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub Txt_Observaciones_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Observaciones.KeyPress
        If Char.IsLower(e.KeyChar) Then
            Txt_Observaciones.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub

    Private Sub frmCatalogoTipoCredito_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            If Accion = 1 Or Accion = 2 Then
                If MsgBox("Estas Seguro de sálir ?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    Me.Close()
                End If
            Else
                Me.Close()
            End If
        End If
    End Sub

    Private Sub PanelControl3_Paint(sender As Object, e As PaintEventArgs) Handles Pnl_Abogado.Paint

    End Sub

    Private Sub Txt_FechaLimPag1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_FechaLimPag1.LostFocus
        If (Txt_FechaLimPag1.Text.Length <> 0) Then
            Txt_FechaLimPag2.Text = Val(Txt_FechaLimPag1.Text) + 5
        End If
    End Sub
End Class