Public Class frmCatalogoRepetitivos
    'mreyes 09/Junio/2012 01:16 p.m.

    Dim Sql As String
    Public Accion As Integer  '' 1  = nuevo, 2 = edicion , 3 = eliminar , 4 = consultar 

    Private objDataSet As Data.DataSet
    Dim Sw_LibresProveedores As Boolean = False
    Dim Sw_PermisoSaldo As Boolean = True
    Public Sw_Tienda As String = "N"
    Dim sdiario As Decimal = 0
    Dim bonofijo As Decimal = 0


    Function Validar() As Boolean
        Validar = False
        Try

            Txt_Descrip.Text = Txt_DescripPerceDeduc.Text
            'If DTime.Value = 0 Then
            '    DTime.Value = "00:00:00"
            'End If

            If Txt_Observaciones.TextLength = 0 Then
                MsgBox("Debe indicar alguna observación.", MsgBoxStyle.Critical, "Validación")
                Exit Function
            End If

            If Accion = 1 Then
                'Sacar los valores de importe, cuota, y saldo.
                If Sw_Tienda = "S" Then
                    '    'permiso con goce de sueldo
                    '    txt_cuota =SET bonofijoV = ((asistenciaV ) * bonofijoC) / diasC;
                    Txt_Cuota.Text = "0.0"
                    Txt_Importe.Text = "0.0"
                    Txt_Saldo.Text = "0.0"
                End If

            End If

            Validar = True
        Catch ExceptionErr As Exception
            Validar = False
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Function Inserta_Repetitivo() As Boolean
        'mreyes 11/Junio/2012 10:12 a.m.
        Using objCatalogo As New BCL.BCLCatalogoRepetitivo(GLB_ConStringNomSis)
            'Get a new Project DataSet
            Try
                objDataSet = objCatalogo.Inserta_Repetitivo  'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow

                'Set the values in the DataRow
                Dim Cuota As Decimal = Txt_Cuota.Text
                Dim Saldo As Decimal = Txt_Saldo.Text
                Dim importe As Decimal = Txt_Importe.Text

                objDataRow.Item("idrepetitivo") = Val(Txt_IdRepetitivo.Text)
                objDataRow.Item("idempleado") = Val(Txt_IdEmpleado.Text)
                objDataRow.Item("idpercdeduc") = Val(Txt_IdPercDeduc.Text)
                objDataRow.Item("descrip") = Txt_Descrip.Text
                objDataRow.Item("folio") = Txt_Folio.Text
                objDataRow.Item("importe") = importe
                objDataRow.Item("cuota") = Cuota
                objDataRow.Item("saldo") = Saldo
                objDataRow.Item("inicio") = Format(DtInicio.Value, "yyyy-MM-dd")
                objDataRow.Item("estatus") = Mid(Cbo_Estatus.Text, 1, 1)
                objDataRow.Item("idcuenta") = 0
                objDataRow.Item("usuario") = GLB_Usuario
                objDataRow.Item("usumodif") = GLB_Usuario
                objDataRow.Item("fummodif") = DateTime.Now
                objDataRow.Item("observaciones") = Txt_Observaciones.Text
                objDataRow.Item("hora") = Format(DTime.Value, "HH:mm:ss") 'Txt_Hora.Text
                objDataRow.Item("fin") = Format(DtFin.Value, "yyyy-MM-dd")



                'Add the DataRow to the DataSet
                objDataSet.Tables(0).Rows.Add(objDataRow)

                'Add the Project
                If Not objCatalogo.usp_Captura_Repetitivo(Accion, objDataSet) Then
                    'Throw New Exception("Falló Inserción de Proveedor")
                Else
                    Inserta_Repetitivo = True
                End If

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Private Sub TxtLostfocus(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
        'mreyes 28/Febrero/2012 01:20 p.m.
        Dim myForm As New frmConsulta

        If Txt_Campo.Text.Length = 0 Then Exit Sub
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringNomSis)
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

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        'mreyes 11/Junio/2012 10:10 a.m.
        Try
            If Validar() = False Then Exit Sub
            If Accion = 1 Then '''' es un articulo nuevo
                If MsgBox("Estas Seguro de Grabar el Concepto?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    If Inserta_Repetitivo() = True Then
                        GLB_RefrescarPedido = True
                        MessageBox.Show("Exitosamente Grabado '" & Txt_Clave.Text & "' para el empleado '" & Txt_IdEmpleado.Text & " !", "Agregando", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Close()
                        '' Me.Dispose()
                    Else
                        MessageBox.Show("Error Grabando !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    End If
                End If
            ElseIf Accion = 2 Then ' es una actualización
                If MsgBox("Estas Seguro de Actualizar?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    If Inserta_Repetitivo() = True Then
                        GLB_RefrescarPedido = True
                        MessageBox.Show("Exitosamente Grabado '" & Txt_Clave.Text & "' para el empleado '" & Txt_IdEmpleado.Text & " !", "Actualizando", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Close()
                        ' Me.Dispose()
                    Else
                        MessageBox.Show("Error Grabando !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

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

    Private Sub frmCatalogoProveedores_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then
                If Accion = 1 Or Accion = 2 Then
                    If MessageBox.Show("Estas seguro de cancelar el registro ?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
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

    Private Sub frmCatalogoProveedores_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Accion = 1

            If Accion = 1 Then
                Cbo_Estatus.Text = "VIGENTE"
                Cbo_Estatus.Enabled = False


            Else
                Call usp_TraerRepetitivo()

            End If

            Call GenerarToolTip()

            Call Edicion()

            If Sw_Tienda = "S" Then
                Me.Text = "Pre-Nómina"
                Lbl_Fecha.Text = "Fecha"
                Btn_ModifSaldo.Visible = False
                Txt_Folio.Enabled = False
                Lbl_Hora.Visible = True
                'Txt_Hora.Visible = True
                DTime.Visible = True
                Me.Lbl_Saldo.Visible = False
                Me.Lbl_Cuota.Visible = False
                Me.Lbl_Importe.Visible = False
                Txt_Importe.Visible = False
                Txt_Cuota.Visible = False
                Txt_Saldo.Visible = False
                Lbl_Repetitivo.Text = "Id"
                DtInicio.Enabled = True
            Else
                Lbl_Fecha.Text = "Fecha Inicio"
                Btn_ModifSaldo.Visible = True
                Lbl_Repetitivo.Text = "IdRepetitivo"
                DtInicio.Enabled = False
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub usp_TraerRepetitivo()
        'mreyes 21/Febrero/2012 01:15 p.m.
        Using objCatalogo As New BCL.BCLCatalogoRepetitivo(GLB_ConStringNomSis)
            Try

                objDataSet = objCatalogo.usp_TraerRepetitivo(Txt_IdRepetitivo.Text)
                If objDataSet.Tables(0).Rows.Count > 0 Then

                    Txt_IdRepetitivo.Text = objDataSet.Tables(0).Rows(0).Item("idrepetitivo").ToString
                    Txt_IdEmpleado.Text = objDataSet.Tables(0).Rows(0).Item("idempleado").ToString
                    Txt_IdPercDeduc.Text = objDataSet.Tables(0).Rows(0).Item("idpercdeduc").ToString
                    Txt_NombreEmpleado.Text = objDataSet.Tables(0).Rows(0).Item("nomcompleto").ToString
                    Txt_Clave.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    Txt_DescripPerceDeduc.Text = objDataSet.Tables(0).Rows(0).Item("descrippercdeduc").ToString
                    Txt_Descrip.Text = objDataSet.Tables(0).Rows(0).Item("descriprepetitivo").ToString
                    Txt_Folio.Text = objDataSet.Tables(0).Rows(0).Item("folio").ToString
                    Txt_Importe.Text = Format(Val(objDataSet.Tables(0).Rows(0).Item("importe")), "$#,###,###,##0.00")
                    Txt_Saldo.Text = Format(Val(objDataSet.Tables(0).Rows(0).Item("saldo")), "$#,###,###,##0.00")
                    Txt_Cuota.Text = Format(Val(objDataSet.Tables(0).Rows(0).Item("cuota")), "$#,###,###,##0.00")
                    DtInicio.Value = Format(objDataSet.Tables(0).Rows(0).Item("inicio"), "yyyy-MM-dd")
                    Txt_Observaciones.Text = objDataSet.Tables(0).Rows(0).Item("observaciones").ToString
                    DTime.Text = objDataSet.Tables(0).Rows(0).Item("hora")
                    DtFin.Value = Format(objDataSet.Tables(0).Rows(0).Item("fin"), "yyyy-MM-dd")

                    ' estatus
                    If Accion = 2 Then 'modificar
                        If Val(Txt_Saldo.Text) <> Val(Txt_Importe.Text) Then
                            Txt_Importe.Enabled = False
                            Txt_Importe.ReadOnly = True
                            Txt_Importe.BackColor = TextboxBackColor
                        End If
                    End If

                    Cbo_Estatus.Text = pub_TraerEstatus(objDataSet.Tables(0).Rows(0).Item("estatus"))
                End If
                'GLB_Usuario = "DLANDE"
                'GLB_Usuario = "PAOLA"

                'mreyes 17/Julio/2012 09:26 a.m.
                ' CHECAR SI PUEDE VER COSTOS.. LOS COSTOS NO SE PODRAN VER SI EN PUERTO EL PUERTO DICE 01...
                ''If GLB_Usuario <> "SAPB1988" Then
                ''    'If pub_TienePermisoProceso("ABCREP", "00", "", False) = False Then
                ''    '    Exit Sub
                ''    'Else
                ''    Sw_PermisoSaldo = False
                ''    'End If
                ''End If
                If GLB_IdDeptoEmpleado <> 2 Then
                    Sw_PermisoSaldo = False
                Else
                    Sw_PermisoSaldo = True
                    Txt_Saldo.Enabled = True
                End If

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Aceptar, "Aceptar la acción requerida por el usuario")
            ToolTip.SetToolTip(Btn_Cancelar, "Cancelar cualquier acción requerida por el usuario")
            ToolTip.SetToolTip(Btn_Nuevo, "Nuevo Proveedor")
            ToolTip.SetToolTip(Btn_Editar, "Editar Proveedor")
            ToolTip.SetToolTip(Btn_ModifSaldo, "Modificar el saldo del repetitivo")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub LimpiarDatos()
        Try

            Txt_IdRepetitivo.Text = ""

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub TxtLostfocus(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Sql As String, ByVal Tipo As String)
        Dim myForm As New frmConsulta


        If Txt_Campo.Text.Length = 0 Then Exit Sub
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringNomSis)
            Try


                objDataSet = objMySqlGral.usp_TraerUnCampo(Sql)

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

    Private Sub Btn_Nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Nuevo.Click
        Try
            Accion = 1
            Call Edicion()
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
                    Btn_Nuevo.Enabled = True
                    Btn_Editar.Enabled = True


                    Pnl_Edicion.Enabled = False


                    Txt_IdRepetitivo.BackColor = TextboxBackColor
                    Txt_IdEmpleado.BackColor = TextboxBackColor
                    Txt_IdPercDeduc.BackColor = TextboxBackColor
                    Txt_Descrip.BackColor = TextboxBackColor
                    Txt_Folio.BackColor = TextboxBackColor
                    Txt_Importe.BackColor = TextboxBackColor
                    Txt_Cuota.BackColor = TextboxBackColor
                    Txt_Saldo.BackColor = TextboxBackColor
                    Cbo_Estatus.BackColor = TextboxBackColor



                Case 1, 2
                    Btn_Aceptar.Enabled = True
                    Btn_Cancelar.Enabled = True
                    Btn_Nuevo.Enabled = False
                    Btn_Editar.Enabled = False


                    If Accion = 1 Then
                        Txt_IdRepetitivo.Focus()
                    ElseIf Accion = 2 Then
                        Txt_Descrip.Focus()
                        Txt_IdRepetitivo.Enabled = False
                        Txt_IdEmpleado.Enabled = False
                        Txt_IdPercDeduc.Enabled = False
                        Txt_Clave.Enabled = False
                        Txt_Clave.BackColor = TextboxBackColor
                        Txt_IdRepetitivo.BackColor = TextboxBackColor
                        Txt_IdEmpleado.BackColor = TextboxBackColor
                        Txt_IdPercDeduc.BackColor = TextboxBackColor


                    End If
            End Select
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar.Click
        Accion = 2
        Call Edicion()
    End Sub

    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Try

            If Accion = 1 Or Accion = 2 Then
                If MessageBox.Show("Estas seguro de cancelar el registro ?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                    'Me.Dispose()
                    Me.Close()

                End If
            Else
                Me.Close()
                Me.Dispose()
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Descrip_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Descrip.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_IdEmpleado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_IdEmpleado.KeyPress
        If e.KeyChar.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        'If e.KeyChar = ChrW(Keys.Enter) Then
        '    e.Handled = True
        '    SendKeys.Send("{TAB}")
        'End If
    End Sub

    Private Sub Txt_IdEmpleado_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_IdEmpleado.LostFocus
        Try
            'mreyes 11/Junio/2012 01:28 p.m.
            'checar Sw_Tienda para validar solo los empleados.
            If Txt_IdEmpleado.Text.Length = 0 Then Exit Sub


            Using objMySqlGral As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)
                Try
                    If Val(Txt_IdEmpleado.Text) = 0 Then
                        CargarFormaConsultaEmpleado()
                    Else
                        objDataSet = objMySqlGral.usp_TraerNomEmpleado(Val(Txt_IdEmpleado.Text), "", "", "", "", 0)
                        If objDataSet.Tables(0).Rows.Count = 1 Then
                            Txt_NombreEmpleado.Text = objDataSet.Tables(0).Rows(0).Item("nomcompleto").ToString
                            sdiario = Val(objDataSet.Tables(0).Rows(0).Item("sdiario").ToString)
                            bonofijo = Val(objDataSet.Tables(0).Rows(0).Item("bonofijo").ToString())

                            If GLB_CveSucursal <> "" Then
                                If Mid(objDataSet.Tables(0).Rows(0).Item("clave").ToString, 1, 2) <> GLB_CveSucursal Then
                                    MsgBox("No puede registrar una Pre-Nómina, de un empleado de la sucursal '" & Mid(objDataSet.Tables(0).Rows(0).Item("clave").ToString, 1, 2) & "'.", MsgBoxStyle.Critical, "Error")
                                    Txt_IdEmpleado.Text = ""
                                    Txt_IdEmpleado.Focus()


                                End If
                            End If

                        Else
                            Call CargarFormaConsultaEmpleado()
                        End If

                        End If
                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub CargarFormaConsulta()
        'mreyes 13/Junio/2012 01:28 p.m.

        Dim myForm As New frmConsulta

        myForm.Sw_Tienda = Sw_Tienda

        Txt_DescripPerceDeduc.Text = ""
        myForm.Tipo = "PD"
        myForm.ShowDialog()
        Txt_Clave.Text = myForm.Campo
        Txt_DescripPerceDeduc.Text = myForm.Campo1
        Txt_IdPercDeduc.Text = myForm.Campo2
        If Txt_Clave.Text.Length = 0 Then
            Txt_Clave.Focus()
        End If
    End Sub

    Private Sub CargarFormaConsultaEmpleado()
        'mreyes 11/Junio/2012 06:04 p.m.

        Dim myForm As New frmConsultaEmpleado
        Txt_NombreEmpleado.Text = ""
        myForm.Estatus = ""
        myForm.ShowDialog()
        Txt_IdEmpleado.Text = myForm.Campo
        Txt_NombreEmpleado.Text = myForm.Campo1
        If Txt_IdEmpleado.Text.Length = 0 Then
            Txt_IdEmpleado.Focus()
        End If
    End Sub

    Private Sub Txt_IdEmpleado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_IdEmpleado.TextChanged

    End Sub

    Private Sub Txt_Cuota_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Cuota.LostFocus
        If Val(Txt_Cuota.Text) = 0 Then Exit Sub
        Dim importe As Decimal = Txt_Importe.Text
        Dim cuota As Decimal = Txt_Cuota.Text
        If cuota > importe Then
            MsgBox("La cuota debe ser menor al importe.", MsgBoxStyle.Critical, "Validación")
            Txt_Cuota.Focus()
            Exit Sub
        End If
        Txt_Cuota.Text = Format(Val(Txt_Cuota.Text), "$###,###,##0.00")

    End Sub

    Private Sub Txt_Cuota_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Cuota.TextChanged

    End Sub

    Private Sub Txt_Importe_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Importe.KeyPress

    End Sub

    Private Sub Txt_Importe_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Importe.LostFocus
        Txt_Importe.Text = Format(Val(Txt_Importe.Text), "$###,###,##0.00")
        If Accion = 1 Then
            Txt_Saldo.Text = Txt_Importe.Text
        End If
    End Sub

    Private Sub Txt_Saldo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Saldo.LostFocus
        Txt_Saldo.Text = Format(Val(Txt_Saldo.Text), "$###,###,##0.00")
    End Sub

    Private Sub Txt_Importe_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Importe.TextChanged

    End Sub

    Private Sub Txt_Clave_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Clave.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Clave_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Clave.LostFocus
        Try
            'mreyes 13/Junio/2012 12:15 p.m.
            If Txt_Clave.Text.Length = 0 Then Exit Sub


            Using objMySqlGral As New BCL.BCLCatalogoPercDeduc(GLB_ConStringNomSis)
                Try
                    objDataSet = objMySqlGral.usp_PpalCatalogoPercDeduc(0, Txt_Clave.Text, "", "", "", "", "", "", Sw_Tienda)
                    If objDataSet.Tables(0).Rows.Count = 1 Then
                        Txt_DescripPerceDeduc.Text = objDataSet.Tables(0).Rows(0).Item("DescripC").ToString
                        Txt_Clave.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                        Txt_IdPercDeduc.Text = objDataSet.Tables(0).Rows(0).Item("idpercdeduc").ToString
                    Else
                        Call CargarFormaConsulta()
                    End If


                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Folio_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Folio.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Btn_ModifSaldo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ModifSaldo.Click
        If Sw_PermisoSaldo = False Then
            MsgBox("No tiene permiso para realizar este proceso.", MsgBoxStyle.Critical, "Permisos")
            Exit Sub
        End If
        Txt_Saldo.Enabled = True
    End Sub

    Private Sub Txt_Observaciones_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Observaciones.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub Txt_Clave_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Clave.TextChanged

    End Sub

    Private Sub Txt_Hora_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class