Public Class frmCatalogoGastos
    'mreyes 09/Junio/2012 01:16 p.m.

    Dim Sql As String
    Dim foliob As Integer = 0
    Private UltimoFolio As Integer = 0
    Public Accion As Integer  '' 1  = nuevo, 2 = edicion , 3 = eliminar , 4 = consultar 
    Public Sw_Registro As Boolean = False

    Private objDataSet As Data.DataSet
    
    Private Sub frmCatalogoGastos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            
            Call LLenarComboGastos()
            Cbo_IdGasto.Text = ""
            'aqui le agrega 1 al ultimo folio para irlo incrementando
            If Accion = 1 Then

                Txt_Folio.Enabled = False
                If GLB_CveSucursal = "01" Or GLB_CveSucursal = "02" Or GLB_CveSucursal = "06" Or GLB_CveSucursal = "07" Or GLB_CveSucursal = "08" Or GLB_CveSucursal = "11" Then
                Else
                    GLB_CveSucursal = "00"
                End If
                Using objEmpleado As New BCL.BCLCatalogoGastos(GLB_ConStringCipSis)
                    objDataSet = objEmpleado.usp_TraerIdFolioGasto(GLB_CveSucursal)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_Folio.Text = objDataSet.Tables(0).Rows(0).Item("foliosuc").ToString
                    'foliob = objDataSet.Tables(0).Rows(0).Item("folio").ToString
                    If Txt_Folio.Text.Length = 0 Then
                        Txt_Folio.Text = GLB_CveSucursal & pub_RellenarIzquierda("1", 6)
                    Else
                        Txt_Folio.Text = GLB_CveSucursal & pub_RellenarIzquierda(Txt_Folio.Text, 6)
                    End If
                    'foliob = pub_RellenarIzquierda(foliob, 6)

                Else
                    Txt_Folio.Text = GLB_CveSucursal & pub_RellenarIzquierda("1", 6)
                End If


                Call usp_TraerUltimoFolioGastos()
                UltimoFolio = UltimoFolio + 1
                'Txt_Folio.Text = pub_RellenarIzquierda(UltimoFolio.ToString, 6)
                'pub_RellenarIzquierda(Txt_Folio.Text, 6)
            Else
                Call usp_TraerGastos()
            End If

            Call Edicion()

        Catch ex As Exception


        End Try
    End Sub

    Private Function ValidarEdicion() As Boolean

        ValidarEdicion = False
        Try
            If Cbo_IdGasto.Text.Length = 0 Then
                MsgBox("Debe especificar el tipo de Gasto.", MsgBoxStyle.Critical, "Validación")
                Cbo_IdGasto.Focus()
                Exit Function
            End If

            If Txt_IdEmpleado.Text.Length = 0 Then
                MsgBox("Debe especificar quién solicita el Gasto.", MsgBoxStyle.Critical, "Validación")
                Txt_IdEmpleado.Focus()
                Exit Function
            End If

            If Txt_Importe.Text.Length = 0 Then
                MsgBox("Debe especificar el importe del Gasto.", MsgBoxStyle.Critical, "Validación")
                Txt_Importe.Focus()
                Exit Function
            End If

            If CDec(Txt_Importe.Text) = 0.0 Then
                MsgBox("Debe especificar el importe del Gasto.", MsgBoxStyle.Critical, "Validación")
                Txt_Importe.Focus()
                Exit Function
            End If

            ValidarEdicion = True
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Function

    Function insertaGasto() As Boolean
        'raulr 18/04/2013
        Using objCatalogo As New BCL.BCLCatalogoGastos(GLB_ConStringCipSis)
            'Get a new Project DataSet
            Try
                objDataSet = objCatalogo.Inserta_Gastos  'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow

                'Set the values in the DataRow
                
                'AQUI INSERTAS / MODIFICAR LOS DATOS RAUL REYES
                ' esta variable creada (ingresomen) es para convertir lo del campo importe a variable double
                'Dim ingresomen As Double = Txt_Importe.Text

                If Accion = 1 Then
                    objDataRow.Item("Folio") = Val(UltimoFolio)
                ElseIf Accion = 2 Then
                    objDataRow.Item("Folio") = foliob
                End If

                objDataRow.Item("cantidad") = CDbl(Txt_Importe.Text)


                If Accion = 1 Then 'si es una captura nueva
                    If GLB_CveSucursal <> "" Then ' si es tienda la que registra 
                        objDataRow.Item("sucursal") = GLB_CveSucursal
                    Else ' si es administracion
                        objDataRow.Item("sucursal") = "00"
                    End If
                ElseIf Accion = 2 Then 'si es modificacion ( solo administracion )
                    objDataRow.Item("sucursal") = Mid(Txt_Folio.Text, 1, 2) 'obtiene la sucursal del foliosuc
                End If
                

                objDataRow.Item("fecha") = Format(DtFecha.Value, "yyyy-MM-dd")
                objDataRow.Item("idgasto") = Cbo_IdGasto.SelectedValue
                objDataRow.Item("solicita") = Val(Txt_IdEmpleado.Text)
                objDataRow.Item("status") = "CA"
                objDataRow.Item("comentarios") = Txt_Descrip.Text
                objDataRow.Item("usuario") = GLB_Idempleado
                objDataRow.Item("fum") = DateTime.Now
                objDataRow.Item("foliosuc") = Txt_Folio.Text
                'objDataRow.Item("usumodif") = GLB_Idempleado
                'objDataRow.Item("fummodif") = DateTime.Now

                'Add the DataRow to the DataSet
                objDataSet.Tables(0).Rows.Add(objDataRow)

                'Add the Project
                If Not objCatalogo.usp_Captura_Gastos(Accion, objDataSet) Then
                    'Throw New Exception("Falló Inserción de Gasto")
                Else
                    insertaGasto = True
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
            If Accion = 1 Then '''' es un articulo nuevo
                If ValidarEdicion() = False Then Exit Sub
                If MsgBox("Estas Seguro de Grabar el Concepto Gasto Nuevo?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    If insertaGasto() = True Then
                        GLB_RefrescarPedido = True
                        MessageBox.Show("Exitosamente Grabado el Folio de Gasto'" & pub_RellenarIzquierda(Txt_Folio.Text, 6) & " '!", "Agregando Gasto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Sw_Registro = True
                        Me.Close()
                        '' Me.Dispose()
                    Else
                        MessageBox.Show("Error Grabando !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    End If
                End If
            ElseIf Accion = 2 Then ' es una actualización
                If ValidarEdicion() = False Then Exit Sub
                If MsgBox("Estas Seguro de Actualizar el Gasto?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    If insertaGasto() = True Then
                        MessageBox.Show("Exitosamente Actualizado el Folio de Gasto'" & pub_RellenarIzquierda(Txt_Folio.Text, 6) & " '!", "Agregando Gasto", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Sw_Registro = True
                        Me.Close()
                        ' Me.Dispose()
                    Else
                        MessageBox.Show("Error Al Grabar !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

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

    Private Sub usp_TraerGastos()
        'raulr 18/04/2013 mandar traer los datos ya guardados en la pantalla de catalogo de gastos captura/edicion
        Using objCatalogo As New BCL.BCLCatalogoGastos(GLB_ConStringCipSis)
            Try

                objDataSet = objCatalogo.usp_TraerGastos(Txt_Folio.Text)
                If objDataSet.Tables(0).Rows.Count > 0 Then

                    foliob = objDataSet.Tables(0).Rows(0).Item("folio")
                    Txt_Folio.Text = objDataSet.Tables(0).Rows(0).Item("foliosuc")
                    DtFecha.Value = objDataSet.Tables(0).Rows(0).Item("fecha")
                    Txt_Importe.Text = Format(Val(objDataSet.Tables(0).Rows(0).Item("cantidad")), "$#,###,###,##0.00")
                    Txt_IdEmpleado.Text = objDataSet.Tables(0).Rows(0).Item("solicita").ToString
                    Txt_Descrip.Text = objDataSet.Tables(0).Rows(0).Item("comentarios").ToString
                    Cbo_IdGasto.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString



                    'RELLENAR EL ESTATUS
                    If (objDataSet.Tables(0).Rows(0).Item("status")) = "CA" Then
                        Cbo_Status.Text = "CAPTURA"
                    ElseIf (objDataSet.Tables(0).Rows(0).Item("status")) = "AP" Then
                        Cbo_Status.Text = "AUTORIZADO"
                    ElseIf (objDataSet.Tables(0).Rows(0).Item("status")) = "ZC" Then
                        Cbo_Status.Text = "CANCELADO"
                    ElseIf (objDataSet.Tables(0).Rows(0).Item("status")) = "RV" Then
                        Cbo_Status.Text = "REVISADO"
                    End If

                    Call TraerEmpleado()
                    'Call TraerEmpleado2()

                    ''RELLENAR LA DESCRIPCION DEL  CONCEPTO 
                    'If (objDataSet.Tables(0).Rows(0).Item("idgasto")) = "1" Then
                    '    Cbo_IdGasto.DisplayMember = "PASTEL"
                    '    Cbo_IdGasto.ValueMember = "Idgasto"

                    'ElseIf objDataSet.Tables(0).Rows(0).Item("idgasto") = "2" Then
                    '    Cbo_IdGasto.DisplayMember = "PASAJE"
                    '    Cbo_IdGasto.ValueMember = "Idgasto"


                    'ElseIf objDataSet.Tables(0).Rows(0).Item("idgasto") = "3" Then
                    '    Cbo_IdGasto.DisplayMember = "COMIDAS"
                    '    Cbo_IdGasto.ValueMember = "Idgasto"


                    'ElseIf objDataSet.Tables(0).Rows(0).Item("idgasto") = "4" Then
                    '    Cbo_IdGasto.DisplayMember = "ESTACIONAMIENTO"
                    '    Cbo_IdGasto.ValueMember = "Idgasto"


                    'Else
                    '    Cbo_IdGasto.DisplayMember = "COMPRAS VARIOS"
                    '    Cbo_IdGasto.ValueMember = "5"


                    'End If
                    'If Accion = 2 Then 'modificar
                    '    Txt_Importe.Enabled = False
                    '    Txt_Importe.ReadOnly = True
                    '    Txt_Importe.BackColor = TextboxBackColor
                    'End If
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
            ToolTip.SetToolTip(Btn_Editar, "Editar Gasto")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub LimpiarDatos()
        Try

            Txt_Folio.Text = ""

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

    Private Sub Btn_Nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
                    'Btn_Nuevo.Enabled = True
                    Btn_Editar.Enabled = True

                    Pnl_Edicion.Enabled = False

                    Txt_IdEmpleado.BackColor = TextboxBackColor
                    Txt_Descrip.BackColor = TextboxBackColor
                    Txt_Importe.BackColor = TextboxBackColor
                    Cbo_IdGasto.BackColor = TextboxBackColor
                Case 1, 2
                    Btn_Aceptar.Enabled = True
                    Btn_Cancelar.Enabled = True
                    'Btn_Nuevo.Enabled = False
                    Btn_Editar.Enabled = False


                    If Accion = 1 Then
                    ElseIf Accion = 2 Then
                        Txt_Descrip.Focus()
                        Txt_IdEmpleado.BackColor = TextboxBackColor
                        Txt_IdEmpleado.BackColor = TextboxBackColor
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

    Private Sub Txt_IdEmpleado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_IdEmpleado_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_IdEmpleado.LostFocus
        If Txt_IdEmpleado.Text.Length = 0 Then Exit Sub
        Call TraerEmpleado()
    End Sub

    Private Sub TraerEmpleado()
        If Txt_IdEmpleado.Text.Length = 0 Then Txt_DescripEmpleado.Text = "" : Exit Sub


        Using objMySqlGral As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)
            Try
                If Val(Txt_IdEmpleado.Text) = 0 Then
                    CargarFormaConsultaEmpleado()
                Else
                    objDataSet = objMySqlGral.usp_TraerNomEmpleadosuc(Val(Txt_IdEmpleado.Text), "", "", "", "", 0, "")
                    If objDataSet.Tables(0).Rows.Count = 1 Then
                        Txt_DescripEmpleado.Text = objDataSet.Tables(0).Rows(0).Item("nomcompleto").ToString
                    Else
                        Call CargarFormaConsultaEmpleado()
                    End If

                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub
    Private Sub CargarFormaConsultaEmpleado()
        'mreyes 11/Junio/2012 06:04 p.m.

        Dim myForm As New frmConsultaEmpleado
        'Txt_NombreEmpleado.Text = ""
        myForm.Estatus = ""
        myForm.CatGastos = True
        myForm.ShowDialog()
        Txt_IdEmpleado.Text = myForm.Campo
        Txt_DescripEmpleado.Text = myForm.Campo1
        If Txt_IdEmpleado.Text.Length = 0 Then
            Txt_IdEmpleado.Focus()
        End If
    End Sub

    Private Sub Txt_IdEmpleado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

  

    Private Sub Txt_Cuota_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Txt_Importe_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Importe.KeyPress

    End Sub

    Private Sub Txt_Importe_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Importe.LostFocus
        Txt_Importe.Text = Format(Val(Txt_Importe.Text), "$###,###,##0.00")
        If Accion = 1 Then
            'Txt_Saldo.Text = Txt_Importe.Text
        End If
    End Sub

    Private Sub Txt_Importe_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Importe.TextChanged

    End Sub

    Private Sub Txt_Clave_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_IdEmpleado.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub LLenarComboGastos()
        Dim objDataSet As Data.DataSet
        Using objCatalogo As New BCL.BCLCatalogoGastos(GLB_ConStringCipSis)
            Try
                objDataSet = objCatalogo.usp_TraerDetGastos()
                If objDataSet.Tables(0).Rows.Count > 0 Then

                    Cbo_IdGasto.DataSource = objDataSet.Tables(0).DefaultView
                    Cbo_IdGasto.DisplayMember = "descrip"
                    Cbo_IdGasto.ValueMember = "Idgasto"
                End If
            Catch ex As Exception
            End Try
        End Using
    End Sub

    Private Sub usp_TraerUltimoFolioGastos()
        'Tony Garcia - 15/Octubre - 11:00 a.m.
        Dim objDataSet As Data.DataSet
        Using objActividadesEmp As New BCL.BCLCatalogoGastos(GLB_ConStringCipSis)
            Try
                objDataSet = objActividadesEmp.usp_TraerUltimoFolioGastos()
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("ultimofolio").ToString.Trim = "" Then
                        UltimoFolio = 0
                    Else
                        UltimoFolio = objDataSet.Tables(0).Rows(0).Item("ultimofolio")
                    End If
                End If
            Catch ex As Exception
            End Try
        End Using
    End Sub
    Private Sub Txt_Folio_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'Private Sub Btn_ModifSaldo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    'If Sw_PermisoSaldo = False Then
    '    MsgBox("No tiene permiso para realizar este proceso.", MsgBoxStyle.Critical, "Permisos")
    '    Exit Sub
    '    'End If
    '    'Txt_Saldo.Enabled = True
    'End Sub

    Private Sub Pnl_Edicion_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Edicion.Paint

    End Sub

    Private Sub Cbo_Status_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo_Status.SelectedIndexChanged

    End Sub

    Private Sub Cbo_IdGasto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo_IdGasto.SelectedIndexChanged

    End Sub

    Private Sub Txt_IdEmpleado_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_IdEmpleado.TextChanged

    End Sub

   

    Private Sub DtFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtFecha.ValueChanged

    End Sub

    Private Sub Txt_DescripEmpleado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_DescripEmpleado.TextChanged

    End Sub

    Private Sub Txt_IdEmpleado2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class