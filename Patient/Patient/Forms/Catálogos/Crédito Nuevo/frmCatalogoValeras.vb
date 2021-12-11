Public Class frmCatalogoValeras
    Public Accion As Integer = 0
    Dim idvalera As String = ""
    Dim iddistrib As Integer
    Dim valeini As String
    Dim valefin As String
    Dim entrega As Date
    Dim recoge As String
    Dim idusuario As Integer = GLB_Idempleado
    Dim idusuariomodif As Integer
    Dim distrib As String
    Dim distribuidor As String
    Dim blnValValera As Boolean = False
    Dim objDataSet As Data.DataSet
    Dim Sql As String
    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click
        If Accion = 1 Or Accion = 2 Then
            If MsgBox("Estas Seguro de sálir ?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                Me.Close()
            End If
        Else
            Me.Close()
        End If
    End Sub

    Private Sub Txt_idDistrib_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_idDistrib.KeyPress
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

        Me.Txt_idDistrib.Text = Trim(Replace(Me.Txt_idDistrib.Text, "  ", " "))
    End Sub

    Private Sub Txt_ValeDe_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_ValeDesde.KeyPress
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

        Me.Txt_ValeDesde.Text = Trim(Replace(Me.Txt_ValeDesde.Text, "  ", " "))
    End Sub

    Private Sub Txt_ValeAl_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_ValeHasta.KeyPress
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

        Me.Txt_ValeHasta.Text = Trim(Replace(Me.Txt_ValeHasta.Text, "  ", " "))
    End Sub

    Private Sub Txt_NombreDistrib_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_NombreDistrib.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If Char.IsLower(e.KeyChar) Then


            Txt_NombreDistrib.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub

    Private Sub frmCatalogoValeras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Accion = 1 Then
            Dt_Entrega.Text = Date.Today
            Txt_Valera.Focus()
        End If
    End Sub

    Function usp_CapturarEntregaDeValeras() As Boolean
        Using objCatalogo As New BCL.BCLValera(GLB_ConStringCreditoSQL)

            Try
                blnValValera = ValidarValera()

                If blnValValera = True Then
                    If Accion = 1 Then
                        idvalera = Txt_Valera.Text
                        valeini = Txt_ValeDesde.Text
                        valefin = Txt_ValeHasta.Text
                        entrega = Dt_Entrega.Text
                        recoge = Txt_Recoge.Text
                        distrib = Txt_idDistrib.Text
                        idusuario = GLB_Idempleado
                        idusuariomodif = 0
                        Application.DoEvents()
                        usp_CapturarEntregaDeValeras = objCatalogo.usp_CapturarEntregaDeValeras(Accion, distrib, idvalera, valeini, valefin, entrega, recoge, idusuario, idusuariomodif)
                        Application.DoEvents()
                    ElseIf Accion = 2 Then
                        idvalera = Txt_Valera.Text
                        valeini = Txt_ValeDesde.Text
                        valefin = Txt_ValeHasta.Text
                        entrega = Dt_Entrega.Text
                        recoge = Txt_Recoge.Text
                        distrib = Txt_idDistrib.Text
                        idusuario = GLB_Idempleado
                        idusuariomodif = GLB_Idempleado
                        Application.DoEvents()
                        usp_CapturarEntregaDeValeras = objCatalogo.usp_CapturarEntregaDeValeras(Accion, distrib, idvalera, valeini, valefin, entrega, recoge, idusuario, idusuariomodif)
                        Application.DoEvents()
                    End If

                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try

        End Using
    End Function


    Private Function ValidarValera() As Boolean
        ValidarValera = True
        Dim BolVal As Boolean = True
        If Txt_Valera.Text = "" Then
            ValidarValera = False
            Txt_Valera.Focus()
            MessageBox.Show("Debe ingresar el Folio de la Valera correctamente.", "ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Function
        End If
        If Txt_idDistrib.Text = "" Then
            ValidarValera = False
            Txt_idDistrib.Focus()
            MessageBox.Show("Debe ingresar el Folio del Distribuidor correctamente.", "ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Function
        End If
        If Txt_NombreDistrib.Text = "" Then
            ValidarValera = False
            Txt_NombreDistrib.Focus()
            MessageBox.Show("Debe ingresar el Nombre del Distribuidor correctamente.", "ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Function
        End If
        If Txt_ValeDesde.Text = "" Then
            ValidarValera = False
            Txt_ValeDesde.Focus()
            MessageBox.Show("Debe ingresar el  Vale Inicial correctamente.", "ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Function
        End If
        If Txt_ValeHasta.Text = "" Then
            ValidarValera = False
            Txt_ValeHasta.Focus()
            MessageBox.Show("Debe ingresar el  Vale Final correctamente.", "ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Function
        End If
        If Dt_Entrega.Text = "" Then
            ValidarValera = False
            Dt_Entrega.Focus()
            MessageBox.Show("Debe ingresar la Fecha de entrega correctamente.", "ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Function
        End If
        If Txt_Recoge.Text = "" Then
            ValidarValera = False
            Txt_Recoge.Focus()
            MessageBox.Show("Debe ingresar quien Recoge  correctamente.", "ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Function
        End If
    End Function
    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click
        Try
            GLB_RefrescarPedido = False
            blnValValera = ValidarValera()
            If Accion = 1 Then '''' es nuevo
                If blnValValera = True Then
                    If MsgBox("Estas Seguro de Grabar la Valera?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                        If usp_CapturarEntregaDeValeras() = True Then
                            GLB_RefrescarPedido = True
                            MessageBox.Show("Exitosamente Grabada la Nueva valera del distibuidor '" & Txt_idDistrib.Text & "' con el folio '" & Txt_ValeDesde.Text & "' Hasta '" & Txt_ValeHasta.Text & " !", "Agregando Valera", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.Close()
                        Else
                            If blnValValera = False Then Exit Sub
                            MessageBox.Show("Error Grabando !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                End If
            ElseIf Accion = 2 Then ' es una actualización
                If blnValValera = True Then
                    If MsgBox("Estas Seguro de Actualizar el Valera?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                        If usp_CapturarEntregaDeValeras() = True Then
                            GLB_RefrescarPedido = True
                            MessageBox.Show("Exitosamente Grabada  valera del distibuidor '" & Txt_idDistrib.Text & "' con el folio '" & Txt_ValeDesde.Text & "' Hasta '" & " !", "Actualizando Valera", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.Close()
                        Else
                            If blnValValera = False Then Exit Sub
                            MessageBox.Show("Error Grabando !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                End If
            ElseIf Accion = 4 Then
                Me.Close()
                Me.Dispose()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Valera_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Valera.KeyPress
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

        Me.Txt_Valera.Text = Trim(Replace(Me.Txt_Valera.Text, "  ", " "))
    End Sub

    Private Sub Txt_Recoge_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Recoge.KeyPress
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


            Txt_Recoge.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub


    Private Sub Txt_idDistrib_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_idDistrib.LostFocus
        ''rellena ceros

        If (Txt_idDistrib.Text <> "") Then
            If Txt_idDistrib.Text.Trim.Length < 6 Then
                Txt_idDistrib.Text = pub_RellenarIzquierda(Txt_idDistrib.Text.Trim, 6)
            End If
            'consulta si existe
            If Txt_idDistrib.Text.Length = 0 Then Exit Sub
            Try
                Call TxtLostfocusDistrib(Txt_idDistrib.Text)
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End If
    End Sub

    Private Sub TxtLostfocusDistrib(ByVal Txt_Campo As String)
        Dim myForm As New frmRelacionConsultas
        Dim objDataDistrib As Data.DataSet
        Dim idDistrib As Integer
        If Txt_Campo.Length = 0 Then Exit Sub
        Using objCatalogo As New BCL.BCLRelacionSQL(GLB_ConStringCreditoSQL)
            Try
                objDataDistrib = objCatalogo.usp_TraeridDistrib(Txt_Campo)
                If objDataDistrib.Tables(0).Rows.Count > 0 Then
                    idDistrib = objDataDistrib.Tables(0).Rows(0).Item("iddistrib").ToString
                    ''--------------------------------------------------------------------
                    objDataSet = objCatalogo.usp_TraerDistrib(idDistrib)
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Txt_idDistrib.Text = objDataSet.Tables(0).Rows(0).Item("distrib").ToString
                        Txt_NombreDistrib.Text = objDataSet.Tables(0).Rows(0).Item("nombrecompleto").ToString
                    End If
                Else
                    Txt_NombreDistrib.Text = ""
                End If
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

    Private Sub Txt_Valera_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Valera.LostFocus
        ''rellena ceros
        Dim ObjDataSetValera As Data.DataSet
        If (Txt_Valera.Text <> "") Then

            'consulta si existe
            If Txt_Valera.Text.Length = 0 Then Exit Sub
            Try
                Using objCatalogo As New BCL.BCLValera(GLB_ConStringCreditoSQL)
                    ObjDataSetValera = objCatalogo.usp_TraerEntregaDeValeras(Txt_Valera.Text)
                    If ObjDataSetValera.Tables(0).Rows.Count > 0 Then
                        MessageBox.Show("Ya existe la valera !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Txt_Valera.Text = ""
                    Else
                        Exit Sub
                    End If
                End Using
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End If
    End Sub



    Private Sub txt_ValeDesde_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_ValeDesde.LostFocus
        If (Txt_ValeDesde.Text <> "") Then
            If Txt_ValeDesde.Text.Trim.Length < 6 Then

                Txt_ValeHasta.Text = Val(Txt_ValeDesde.Text)
                Txt_ValeHasta.Text = Val(Txt_ValeHasta.Text) + 50
                Txt_ValeDesde.Text = pub_RellenarIzquierda(Txt_ValeDesde.Text.Trim, 10)
                Txt_ValeHasta.Text = pub_RellenarIzquierda(Txt_ValeHasta.Text.Trim, 10)
            End If
        End If
    End Sub

    Private Sub Txt_ValeHasta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_ValeHasta.LostFocus
        If (Txt_ValeHasta.Text <> "") Then
            If Txt_ValeHasta.Text.Trim.Length < 10 Then
                Txt_ValeHasta.Text = pub_RellenarIzquierda(Txt_ValeHasta.Text.Trim, 10)
            End If
            If Txt_ValeDesde.Text <> "" Then
                Using objTrasp As New BCL.BCLValera(GLB_ConStringCreditoSQL)
                    objDataSet = objTrasp.usp_TraerEntregaDeValeras(0)
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        ''  objDataSet.Tables(0).Rows(0).Item("distrib").ToString
                    End If
                End Using
            End If
        End If
    End Sub

    Private Sub Txt_ValeDe_EditValueChanged(sender As Object, e As EventArgs) Handles Txt_ValeDesde.EditValueChanged

    End Sub

    Private Sub frmCatalogoValeras_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

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



End Class