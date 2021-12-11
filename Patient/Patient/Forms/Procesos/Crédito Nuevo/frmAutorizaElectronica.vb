Public Class frmAutorizaElectronica
    Dim LimiteVAle As Decimal = 0
    Dim Saldo As Decimal = 0
    Dim LimiteCredito As Decimal = 0
    Dim Disponible As Decimal = 0
    Dim Promocion As Integer = 0
    Dim SoloCalzadob As Integer = 0
    Dim Estatus As String = ""
    Private Sub Txt_DistribNuevo_EditValueChanged(sender As Object, e As EventArgs) Handles Txt_DistribNuevo.EditValueChanged

    End Sub

    Private Sub Txt_DistribNuevo_LostFocus(sender As Object, e As EventArgs) Handles Txt_DistribNuevo.LostFocus
        Try
            ''rellena ceros
            If (Txt_DistribNuevo.Text <> "") Then
                If Txt_DistribNuevo.Text.Trim.Length < 6 Then
                    Txt_DistribNuevo.Text = pub_RellenarIzquierda(Txt_DistribNuevo.Text.Trim, 6)
                End If
                'consulta si existe
                Using objMySqlGral As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                    If Txt_DistribNuevo.Text.Length = 0 Then Exit Sub
                    Try
                        Call TxtLostfocusDistrib(Txt_DistribNuevo.Text)
                    Catch ExceptionErr As Exception
                        MessageBox.Show(ExceptionErr.Message.ToString)
                    End Try
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub TxtLostfocusDistrib(ByVal Txt_Campo As String)
        '  Dim myForm As New frmRelacionConsultas
        Dim objDataSet As Data.DataSet
        Dim objDataDistrib As Data.DataSet
        Dim idDistrib As Integer
        If Txt_Campo.Length = 0 Then Exit Sub
        Using objCatalogo As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
            Try
                objDataDistrib = objCatalogo.usp_TraerIdDistrib(Txt_Campo)
                If objDataDistrib.Tables(0).Rows.Count > 0 Then
                    idDistrib = objDataDistrib.Tables(0).Rows(0).Item("iddistrib").ToString

                    ' Txt_idDistrib.Text = objDataSet.Tables(0).Rows(0).Item("distrib").ToString
                    Txt_DistribNombre.Text = objDataDistrib.Tables(0).Rows(0).Item("nombrecompleto").ToString & ""
                    Dt_FecAlta.Text = Format(CDate(objDataDistrib.Tables(0).Rows(0).Item("fecalta").ToString), "dd/MM/yyyy")


                    If objDataDistrib.Tables(0).Rows(0).Item("solocalzado") = 1 Then
                        Opt_Acepta.Checked = False
                        Opt_NoAcepta.Checked = True
                        SoloCalzadob = 1
                    Else
                        Opt_Acepta.Checked = True
                        Opt_NoAcepta.Checked = False
                        SoloCalzadob = 0
                    End If

                Else
                    Txt_DistribNombre.Text = ""
                End If


                If objDataDistrib.Tables(0).Rows(0).Item("promocion") = 1 Then
                    Opt_SiPromo.Checked = True
                    Opt_NoPromo.Checked = False
                    Promocion = 1
                Else
                    Opt_SiPromo.Checked = False
                    Opt_NoPromo.Checked = True
                    Promocion = 2
                End If

                Txt_Saldo.Text = Format(objDataDistrib.Tables(0).Rows(0).Item("saldo"), "c")
                Txt_LimiteCredito.Text = Format(objDataDistrib.Tables(0).Rows(0).Item("limitecredito"), "c")
                Txt_LimiteVale.Text = Format(objDataDistrib.Tables(0).Rows(0).Item("limitevale"), "c")
                Txt_Disponible.Text = Format(objDataDistrib.Tables(0).Rows(0).Item("disponible"), "c")

                Saldo = objDataDistrib.Tables(0).Rows(0).Item("saldo")
                LimiteCredito = objDataDistrib.Tables(0).Rows(0).Item("LimiteCredito")
                disponible = objDataDistrib.Tables(0).Rows(0).Item("disponible")

                Cbo_Estatus.Text = objDataDistrib.Tables(0).Rows(0).Item("estatus").ToString
                Estatus = objDataDistrib.Tables(0).Rows(0).Item("estatus").ToString
                'objDataSet = objCatalogo.usp_TraerDistrib(Txt_Campo)

                'If objDataSet.Tables(0).Rows.Count > 0 Then
                '    Txt_idDistrib.Text = objDataSet.Tables(0).Rows(0).Item("distrib").ToString
                '    Txt_NombreDistrib.Text = objDataSet.Tables(0).Rows(0).Item("nombrecompleto").ToString
                ' Else
                '    Txt_Campo = ""
                '    myForm.Tipo = "D"
                '    myForm.ShowDialog()
                '    If Txt_Campo.Length = 0 Then
                '        Txt_idDistrib.Focus()
                '    End If
                ' End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click
        Try
            Dim SoloCalzado As Integer = 0
            Dim SiPromo As Integer = 0

            If Txt_DistribNuevo.Text.Length = 0 Then Exit Sub

            If Opt_Acepta.Checked = True Then
                SoloCalzado = 0
            Else
                SoloCalzado = 1
            End If

            If Opt_SiPromo.Checked = True Then
                sIpROMO = 1
            Else
                sIpROMO = 0
            End If

            If MsgBox("Esta seguro actualizar la Información para el Distribuidor ?  ... ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub
            Me.Cursor = Cursors.WaitCursor

            '@que fue lo que cambio 


            'Using objTrasp As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
            '    If objTrasp.usp_ModificarSoloCalzado(Txt_DistribNuevo.Text, SoloCalzado) Then
            '        '  MsgBox("Error, no se pudo actualizar", MsgBoxStyle.Critical, "Error")
            '    End If
            'End Using

            If SoloCalzado <> SoloCalzadob Then
                Using objTrasp As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                    If objTrasp.usp_MovimientosDistrib(1, Txt_DistribNuevo.Text, SoloCalzado, 0, CDbl(Txt_LimiteValeNuevo.Text), CDbl(Txt_LimiteCreditoNuevo.Text), Cbo_Estatus.Text) Then
                        '  MsgBox("Error, no se pudo actualizar", MsgBoxStyle.Critical, "Error")

                    End If
                End Using
            End If

            If CDbl(Txt_LimiteVale.Text) <> Val(Txt_LimiteValeNuevo.Text) And CDbl(Txt_LimiteValeNuevo.Text) > 0 Then
                ' opción 2
                Using objTrasp As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                    If objTrasp.usp_MovimientosDistrib(2, Txt_DistribNuevo.Text, 0, 0, CDbl(Txt_LimiteValeNuevo.Text), 0, Cbo_Estatus.Text) Then
                        '  MsgBox("Error, no se pudo actualizar", MsgBoxStyle.Critical, "Error")

                    End If
                End Using
            End If


            If CDbl(Txt_LimiteCredito.Text) <> CDbl(Txt_LimiteCreditoNuevo.Text) And CDbl(Txt_LimiteCreditoNuevo.Text) > 0 Then
                ' opción 2
                Using objTrasp As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                    If objTrasp.usp_MovimientosDistrib(3, Txt_DistribNuevo.Text, 0, 0, CDbl(Txt_LimiteValeNuevo.Text), CDbl(Txt_LimiteCreditoNuevo.Text), Cbo_Estatus.Text) Then
                        '  MsgBox("Error, no se pudo actualizar", MsgBoxStyle.Critical, "Error")

                    End If
                End Using
            End If

            Me.Cursor = Cursors.Default

            If Promocion <> SiPromo Then
                Using objTrasp As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                    If objTrasp.usp_MovimientosDistrib(4, Txt_DistribNuevo.Text, 0, 0, CDbl(Txt_LimiteValeNuevo.Text), CDbl(Txt_LimiteCreditoNuevo.Text), Cbo_Estatus.Text) Then
                        '  MsgBox("Error, no se pudo actualizar", MsgBoxStyle.Critical, "Error")

                    End If
                End Using
            End If


            If Cbo_Estatus.Text <> Estatus Then
                Using objTrasp As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                    If objTrasp.usp_MovimientosDistrib(5, Txt_DistribNuevo.Text, 0, 0, CDbl(Txt_LimiteValeNuevo.Text), CDbl(Txt_LimiteCreditoNuevo.Text), Cbo_Estatus.Text) Then
                        '  MsgBox("Error, no se pudo actualizar", MsgBoxStyle.Critical, "Error")

                    End If
                End Using
            End If
            MsgBox("Información Actualizada", MsgBoxStyle.Information, "Aviso")


            Me.Dispose()
            Me.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub frmAutorizaElectronica_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then
                Me.Dispose()
                Me.Close()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Dt_FecAlta_EditValueChanged(sender As Object, e As EventArgs) Handles Dt_FecAlta.EditValueChanged

    End Sub

    Private Sub Txt_LimiteCreditoNuevo_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs)

    End Sub


    Private Sub Txt_LimiteValeNuevo_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs)

    End Sub


    Private Sub Txt_LimiteCreditoNuevo_TextChanged(sender As Object, e As EventArgs) Handles Txt_LimiteCreditoNuevo.TextChanged

    End Sub

    Private Sub Txt_LimiteCreditoNuevo_MouseDown(sender As Object, e As MouseEventArgs) Handles Txt_LimiteCreditoNuevo.MouseDown

    End Sub

    Private Sub Txt_LimiteCreditoNuevo_LostFocus(sender As Object, e As EventArgs) Handles Txt_LimiteCreditoNuevo.LostFocus
        Dim LimiteCreditoNuevo As Decimal = 0
        Dim DisponibleNuevo As Decimal = 0
        LimiteCreditoNuevo = Val(Txt_LimiteCreditoNuevo.Text)
        DisponibleNuevo = LimiteCreditoNuevo - Saldo

        Txt_LimiteCreditoNuevo.Text = Format(CDbl(LimiteCreditoNuevo), "$#,##0.00")
        Txt_DisponibleNuevo.Text = Format(CDbl(DisponibleNuevo), "$#,##0.00")




    End Sub

    Private Sub Txt_LimiteValeNuevo_TextChanged(sender As Object, e As EventArgs) Handles Txt_LimiteValeNuevo.TextChanged

    End Sub

    Private Sub Txt_LimiteValeNuevo_LostFocus(sender As Object, e As EventArgs) Handles Txt_LimiteValeNuevo.LostFocus
        Dim LimiteValeNuevo As Decimal = 0
        LimiteValeNuevo = Val(Txt_LimiteValeNuevo.Text)
        Txt_LimiteValeNuevo.Text = Format(CDbl(LimiteValeNuevo), "$#,##0.00")
    End Sub
End Class