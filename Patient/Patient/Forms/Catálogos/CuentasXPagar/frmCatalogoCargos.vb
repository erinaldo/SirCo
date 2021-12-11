Public Class frmCatalogoCargos
    'Tony Garcia - 28/Junio/2013 - 12:10 p.m. 

    Dim blnSale As Boolean
    Dim blnActualizaEstatus As Boolean = False
    Public Accion As Integer
    Public Tipo As String
    Public Sw_Registro As Boolean = False
    Public Opcion As Integer
    Private objDataSet As Data.DataSet
    Dim dsctopp As Integer = 0
    Dim Sw_Remision As Boolean = False

    Private Sub frmCatalogoFotos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Call GenerarToolTip()
            Call LLenarComboMotivoBaja()
            Call usp_TraerUltFolioNotaCC(Tipo)

            If Accion = 1 Or Accion = 3 Then
                Me.Text = "Notas de Cargo"
                Lbl_Nota.Text = "Nota de Cargo"
            ElseIf Accion = 2 Or Accion = 4 Then
                Me.Text = "Notas de Crédito"
                Lbl_Nota.Text = "Nota de Crédito"
            End If


            'If GLB_CveSucursal <> "" Then
            '    Lbl_Folio.Text = "Folio " & "S" & GLB_CveSucursal & "-" & Txt_Folio.Text
            'End If

            If Accion = 1 Or Accion = 2 Then
                Cbo_Estatus.Text = "CAPTURA"
                'Cbo_Motivo.Text = ""
            End If
           
            Call Edicion()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Aceptar, "Aceptar la acción requerida por el usuario")
            ToolTip.SetToolTip(Btn_Cancelar, "Cancelar cualquier acción requerida por el usuario")
            'ToolTip.SetToolTip(Btn_Nuevo, "Nueva Cuenta")
            'ToolTip.SetToolTip(Btn_Editar, "Editar Cuenta")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Edicion()
        Try
            Select Case Accion
                Case 1, 2
                    Btn_Aceptar.Enabled = True
                    Btn_Cancelar.Enabled = True
                    Btn_Nuevo.Enabled = True
                    Btn_Editar.Enabled = True

                    Txt_Importe.Enabled = False
                    Txt_ImpTotal.Enabled = False
                    Txt_IVA.Enabled = False
                    Txt_Proveedor.Enabled = False
                    Txt_RazSoc.Enabled = False
                    Txt_Descripcion.Enabled = False
                    Txt_Factprov.Enabled = False
                    Txt_Referenc.Enabled = False
                    Cbo_Estatus.Enabled = False
                    DTFechaNota.Enabled = False

                    'Txt_Importe.BackColor = TextboxBackColor
                    'Txt_ImpTotal.BackColor = TextboxBackColor
                    'Txt_IVA.BackColor = TextboxBackColor
                    'Txt_Proveedor.BackColor = TextboxBackColor
                    'Txt_RazSoc.BackColor = TextboxBackColor

                Case 3, 4
                    Txt_Folio.Enabled = False
                    Txt_Importe.Enabled = False
                    Txt_ImpTotal.Enabled = False
                    Txt_IVA.Enabled = False
                    Txt_Proveedor.Enabled = False
                    Txt_RazSoc.Enabled = False
                    Txt_Descripcion.Enabled = False
                    Txt_Factprov.Enabled = False
                    Txt_Referenc.Enabled = False
                    DTFechaNota.Enabled = False
                    Cbo_Estatus.Enabled = False
                    Cbo_Motivo.Enabled = False

                    Btn_Aceptar.Enabled = True
                    Btn_Cancelar.Enabled = True
                    Btn_Nuevo.Enabled = False
                    Btn_Editar.Enabled = False

                    Call usp_TraerNotaCC()
            End Select
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Folio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Folio.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Folio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Folio.LostFocus
        Try
            Call usp_TraerNotaCCFact(Txt_Folio.Text)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub usp_TraerNotaCCFact(ByVal IdFolioSuc As String)
        If blnSale = True Then Exit Sub

        'Using objNotas As New BCL.BCLNotasCC(GLB_ConStringCipSis)
        '    objDataSet = objNotas.usp_TraerNotaCC(3, IdFolioSuc, 0, Tipo)
        '    If objDataSet.Tables(0).Rows.Count > 0 Then
        '        MessageBox.Show("El Folio de Bulto ya esta pagado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        Txt_Folio.Text = ""
        '        Txt_Folio.Select()
        '        Exit Sub
        '    End If
        'End Using

        Using objNotas As New BCL.BCLNotasCC(GLB_ConStringCipSis)
            Try
                objDataSet = objNotas.usp_TraerNotaCC(Opcion, IdFolioSuc, 0, "")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("pagado").ToString <> 0 And objDataSet.Tables(0).Rows(0).Item("pagado").ToString <> 2 Then
                        MsgBox("No puede registrar una nota, a un folio que no se encuentre PENDIENTE o en STAND BY", MsgBoxStyle.Critical, "ERROR")
                        Exit Sub
                    End If
                    Txt_Proveedor.Text = objDataSet.Tables(0).Rows(0).Item("proveedor").ToString
                    Txt_RazSoc.Text = objDataSet.Tables(0).Rows(0).Item("raz_soc").ToString
                    Txt_Factprov.Text = objDataSet.Tables(0).Rows(0).Item("factprov").ToString
                    Txt_Referenc.Text = objDataSet.Tables(0).Rows(0).Item("referenc").ToString
                    'dsctopp = objDataSet.Tables(0).Rows(0).Item("dsctopp").ToString

                    Txt_Importe.BackColor = TextboxBackColor
                    Txt_ImpTotal.BackColor = TextboxBackColor
                    Txt_IVA.BackColor = TextboxBackColor
                    Txt_Proveedor.BackColor = TextboxBackColor
                    Txt_RazSoc.BackColor = TextboxBackColor
                    Txt_Descripcion.BackColor = TextboxBackColor
                    Txt_Factprov.BackColor = TextboxBackColor
                    Txt_Referenc.BackColor = TextboxBackColor
                    Cbo_Estatus.BackColor = TextboxBackColor

                    'Txt_Importe.Enabled = True
                    Txt_ImpTotal.Enabled = True
                    'Txt_IVA.Enabled = True
                    Txt_Descripcion.Enabled = True

                    'Txt_Descripcion.Select()

                    If GLB_CveSucursal = "00" Or GLB_CveSucursal = "95" Or GLB_CveSucursal = "" Then
                        Lbl_Folio.Text = "Folio " & "A00-" & pub_RellenarIzquierda(Txt_IdFolio.Text, 6)
                    Else
                        Lbl_Folio.Text = "Folio " & "S" & GLB_CveSucursal & "-" & pub_RellenarIzquierda(Txt_IdFolio.Text, 6)
                    End If


                    If Val(objDataSet.Tables(0).Rows(0).Item("rprov").ToString) = 1 Then
                        Txt_IVA.Text = "0"
                        Txt_IVA.Enabled = False
                        sw_remision = True

                    End If






                Else
                    'MessageBox.Show("El Folio de Bulto no existe. Ingrese uno válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Txt_Folio.SelectAll()
                    Txt_Folio.Focus()
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub usp_TraerNotaCC()
        Using objNotas As New BCL.BCLNotasCC(GLB_ConStringCipSis)
            Try
                objDataSet = objNotas.usp_TraerNotaCC(Opcion, "", CInt(Txt_IdFolio.Text), Tipo)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_Folio.Text = objDataSet.Tables(0).Rows(0).Item("idfoliosuc").ToString
                    Txt_Proveedor.Text = objDataSet.Tables(0).Rows(0).Item("proveedor").ToString
                    Txt_RazSoc.Text = objDataSet.Tables(0).Rows(0).Item("raz_soc").ToString
                    Txt_Factprov.Text = objDataSet.Tables(0).Rows(0).Item("factprov").ToString
                    Txt_Referenc.Text = objDataSet.Tables(0).Rows(0).Item("referenc").ToString
                    Txt_Descripcion.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                    DTFechaNota.Value = objDataSet.Tables(0).Rows(0).Item("fecha")
                    Txt_Importe.Text = Format(objDataSet.Tables(0).Rows(0).Item("importe"), "$#,###,##0.00")
                    Txt_IVA.Text = Format(objDataSet.Tables(0).Rows(0).Item("iva"), "$#,###,##0.00")
                    Txt_ImpTotal.Text = Format(objDataSet.Tables(0).Rows(0).Item("imptotal"), "$#,###,##0.00")
                    Cbo_Motivo.SelectedValue = objDataSet.Tables(0).Rows(0).Item("idmotivo")

                    If objDataSet.Tables(0).Rows(0).Item("status") = "CA" Then
                        Cbo_Estatus.Text = "CAPTURA"
                        Cbo_Estatus.Enabled = True
                        Txt_ImpTotal.Enabled = True
                        Txt_Descripcion.Enabled = True
                        Cbo_Motivo.Enabled = True
                        Cbo_Estatus.Enabled = False
                        Cbo_Motivo.Select()
                    ElseIf objDataSet.Tables(0).Rows(0).Item("status") = "AP" Then
                        Cbo_Estatus.Text = "APLICADA"
                    ElseIf objDataSet.Tables(0).Rows(0).Item("status") = "ZC" Then
                        Cbo_Estatus.Text = "CANCELADA"
                    ElseIf objDataSet.Tables(0).Rows(0).Item("status") = "SB" Then
                        Cbo_Estatus.Text = "STAND BY"
                        Cbo_Estatus.Enabled = True
                    End If

                    Txt_Folio.BackColor = TextboxBackColor
                    Txt_Importe.BackColor = TextboxBackColor
                    Txt_ImpTotal.BackColor = TextboxBackColor
                    Txt_IVA.BackColor = TextboxBackColor
                    Txt_Proveedor.BackColor = TextboxBackColor
                    Txt_RazSoc.BackColor = TextboxBackColor
                    Txt_Descripcion.BackColor = TextboxBackColor
                    Txt_Factprov.BackColor = TextboxBackColor
                    Txt_Referenc.BackColor = TextboxBackColor
                    Cbo_Estatus.BackColor = TextboxBackColor
                    Cbo_Motivo.BackColor = TextboxBackColor

                    Dim Suc As String = objDataSet.Tables(0).Rows(0).Item("cvesuc")
                    If Suc = "00" Or Suc = "95" Then
                        Lbl_Folio.Text = "Folio " & "A00-" & pub_RellenarIzquierda(Txt_IdFolio.Text, 6)
                    Else
                        Lbl_Folio.Text = "Folio " & "S" & Suc & "-" & pub_RellenarIzquierda(Txt_IdFolio.Text, 6)
                    End If

                    'Txt_Descripcion.Select()
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub usp_TraerUltFolioNotaCC(ByVal Tipo As String)

        If Accion = 3 Or Accion = 4 Then Exit Sub
        Dim Folio As String
        Using objNotas As New BCL.BCLNotasCC(GLB_ConStringCipSis)
            Try
                objDataSet = objNotas.usp_TraerUltFolioNotaCC(Tipo)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("folio").ToString.Trim = "" Then
                        Txt_IdFolio.Text = 1
                    Else
                        Folio = objDataSet.Tables(0).Rows(0).Item("folio").ToString
                        Folio = Folio + 1
                        Txt_IdFolio.Text = Folio
                    End If
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub


    Private Sub Txt_Proveedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Proveedor.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Descripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Descripcion.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub Txt_IVA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_IVA.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Importe_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Importe.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_ImpTotal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_ImpTotal.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_ImpTotal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_ImpTotal.LostFocus
        Try
            If Val(Txt_ImpTotal.Text) <> 0 Then
                Dim ImporteTot As Decimal
                Dim Importe As Decimal
                Dim IVA As Decimal

                Txt_ImpTotal.Text = Format(Val(Txt_ImpTotal.Text), "$#,###,##0.00")
                ImporteTot = CDec(Txt_ImpTotal.Text)

                Importe = ImporteTot

                If Sw_Remision = False Then
                    Importe = ImporteTot / 1.16
                    IVA = ImporteTot - Importe
                    Txt_IVA.Text = Format(IVA, "$#,###,##0.00")
                End If
                Txt_Importe.Text = Format(Importe, "$#,###,##0.00")
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmCatalogoEstilos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then
                If Accion = 1 Or Accion = 2 Then
                    'blnSale = True
                    If MessageBox.Show("Estas seguro de cancelar el registro ?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                        blnSale = True
                        Me.Dispose()
                        Me.Close()
                    End If
                Else
                    Me.Dispose()
                    Me.Close()
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Function Inserta_Nota() As Boolean
        Dim objDataSet As Data.DataSet
        Dim Estatus As String = ""
        Dim Opcion As Integer = 1
        Using objNotas As New BCL.BCLNotasCC(GLB_ConStringCipSis)
            'Get a new Project DataSet
            Try

                If Cbo_Estatus.Text = "APLICADA" Then
                    Estatus = "AP"
                ElseIf Cbo_Estatus.Text = "CAPTURA" Then
                    Estatus = "CA"
                ElseIf Cbo_Estatus.Text = "CANCELADO" Then
                    Estatus = "ZC"
                ElseIf Cbo_Estatus.Text = "STAND BY" Then
                    Estatus = "SB"
                End If

                If Accion = 3 Or Accion = 4 Then
                    If Estatus = "CA" Then
                        Opcion = 2
                    End If
                End If

                objDataSet = objNotas.Inserta_Nota  'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow

                'Set the values in the DataRow

                objDataRow.Item("folio") = Val(Txt_IdFolio.Text)
                objDataRow.Item("idfoliosuc") = Txt_Folio.Text

                If GLB_CveSucursal = "95" Or GLB_CveSucursal = "" Then
                    objDataRow.Item("cvesuc") = "00"
                Else
                    objDataRow.Item("cvesuc") = GLB_CveSucursal
                End If

                objDataRow.Item("fecha") = DTFechaNota.Value
                objDataRow.Item("tipo") = Tipo
                objDataRow.Item("status") = Estatus

                If Estatus = "CA" Then
                    objDataRow.Item("aplicada") = CDate("1900-01-01")
                End If

                objDataRow.Item("idmotivo") = Cbo_Motivo.SelectedValue
                objDataRow.Item("importe") = CDec(Txt_Importe.Text)
                objDataRow.Item("iva") = CDec(Txt_IVA.Text)
                objDataRow.Item("imptotal") = CDec(Txt_ImpTotal.Text)
                objDataRow.Item("descrip") = Txt_Descripcion.Text
                objDataRow.Item("idusuario") = GLB_Idempleado

                'Add the DataRow to the DataSet
                objDataSet.Tables(0).Rows.Add(objDataRow)

                ''Add the Project
                If Not objNotas.usp_Captura_NotaCC(Opcion, objDataSet) Then
                    Throw New Exception("Falló Inserción de Cuenta")
                Else
                    Inserta_Nota = True
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function


    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click

        Try
            If Accion = 1 Or Accion = 2 Then
                If ValidarEdicion() = False Then Exit Sub
                If MsgBox("Estas Seguro de Grabar la Nota?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    If Inserta_Nota() = True Then

                        MessageBox.Show("Exitosamente Grabada la Nota '" & pub_RellenarIzquierda(Txt_IdFolio.Text, 5) & " !", "Agregando Nota", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Sw_Registro = True
                        Me.Close()
                        '' Me.Dispose()
                    Else
                        MessageBox.Show("Error Grabando !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            ElseIf Accion = 3 Or Accion = 4 Then
                If ValidarEdicion() = False Then Exit Sub

                If MsgBox("Esta Seguro de Actualizar la Nota?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    If Inserta_Nota() = True Then
                        MessageBox.Show("Exitosamente Actualizada la Nota '" & pub_RellenarIzquierda(Txt_IdFolio.Text, 5) & " !", "Agregando Nota", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Sw_Registro = True
                        Me.Close()
                        '' Me.Dispose()
                    Else
                        MessageBox.Show("Error Grabando !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    End If
                Else
                    Me.Close()
                    Me.Dispose()
                End If
            End If '' del if de accion = 1 


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Function ValidarEdicion() As Boolean

        ValidarEdicion = False
        Try
            If Cbo_Motivo.Text.Length = 0 Then
                MsgBox("Debe especificar el motivo de la Nota.", MsgBoxStyle.Critical, "Validación")
                Cbo_Motivo.Focus()
                Exit Function
            End If

            If Txt_Folio.Text.Length = 0 Then
                MsgBox("Debe especificar el Folio de Bulto para la Nota.", MsgBoxStyle.Critical, "Validación")
                Txt_Folio.Focus()
                Exit Function
            End If

            If Txt_Descripcion.Text.Length = 0 Then
                MsgBox("Debe ingresar una descripción del motivo de la Nota.", MsgBoxStyle.Critical, "Validación")
                Txt_Descripcion.Focus()
                Exit Function
            End If

            If Txt_ImpTotal.Text.Length = 0 Then
                MsgBox("Debe especificar el importe a pagar para la Nota.", MsgBoxStyle.Critical, "Validación")
                Txt_ImpTotal.Focus()
                Exit Function
            End If


            ValidarEdicion = True
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Function

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

    'Private Sub ActualizaEstatus()
    '    Dim Estatus As String = ""
    '    Dim InsertaNota As Boolean = False
    '    Try
    '        If Cbo_Estatus.Text = "APLICADA" Then
    '            Estatus = "AP"
    '        ElseIf Cbo_Estatus.Text = "CAPTURA" Then
    '            Estatus = "CA"
    '        ElseIf Cbo_Estatus.Text = "CANCELADA" Then
    '            Estatus = "ZC"
    '        ElseIf Cbo_Estatus.Text = "STAND BY" Then
    '            Estatus = "SB"
    '        End If

    '        'actualiza el estatus de la nota
    '        Using objNotas As New BCL.BCLNotasCC(GLB_ConStringCipSis)
    '            'If Estatus = "SB" Then
    '            If Not objNotas.usp_ActualizaEstatusNotaCC(Txt_IdFolio.Text, Tipo, Estatus, Cbo_Motivo.SelectedValue) Then
    '                Throw New Exception("Error al Actualizar el Estatus de la Nota")
    '            Else
    '                MsgBox("La Nota se actualizó satisfactoriamente.", MsgBoxStyle.Information, "Aviso")
    '                InsertaNota = True
    '            End If
    '        End Using

    '        ''Actualiza cargo o credito en factprov
    '        'If InsertaNota = True AndAlso Estatus = "AP" Then
    '        '    Using objNotas As New BCL.BCLNotasCC(GLB_ConStringCipSis)
    '        '        Dim IdFolioSuc As String = Txt_IdFolio.Text
    '        '        Dim Importe As Decimal = CDec(Txt_ImpTotal.Text)

    '        '        If Not objNotas.usp_ActualizaFacturaNotaCC(IdFolioSuc, Tipo, Importe, 0) Then
    '        '            'Throw New Exception("Error al Actualizar el Estatus de la Nota")
    '        '        Else
    '        '        End If
    '        '    End Using
    '        'End If
    '    Catch ExceptionErr As Exception
    '        MessageBox.Show(ExceptionErr.Message.ToString)
    '    End Try
    'End Sub

    Private Sub Cbo_Estatus_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cbo_Estatus.SelectedValueChanged
        Try
            'If Cbo_Estatus.Text = "STAND BY" Then
            '    If Accion = 3 Or Accion = 4 Then
            '        blnActualizaEstatus = True
            '    End If
            'End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Cbo_Motivo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cbo_Motivo.SelectedValueChanged
        'Try
        '    If Accion = 3 Or Accion = 4 Then
        '        blnActualizaEstatus = True
        '    End If
        'Catch ExceptionErr As Exception
        '    MessageBox.Show(ExceptionErr.Message.ToString)
        'End Try
    End Sub

    Private Sub Txt_Folio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Folio.TextChanged

    End Sub

    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Me.Dispose()
    End Sub
End Class
