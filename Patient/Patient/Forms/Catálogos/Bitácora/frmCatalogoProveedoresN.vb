Public Class frmCatalogoProveedoresN
    'Tony Garcia 28/Enero/2014 10:02 a.m. 

#Region "Variables"
    Dim Sql As String
    Public Accion As Integer  '' 1  = nuevo, 2 = edicion , 3 = eliminar , 4 = consultar 
    Public Sw_Registro As Boolean = False

    Private objDataSet As Data.DataSet
    Dim Sw_LibresProveedores As Boolean = False
    Dim Marca As String = ""
    Dim blnPrimero As Boolean = False
    Dim blnFueClic As Boolean = False

    Dim numRenCond As Integer = 0
    Dim numRenCuentas As Integer = 0
    Dim numRenContactos As Integer = 0


    Dim MarcaSeleccionada As String = ""

    Dim IdBancoFactoraje As Integer = 0
    Dim Sw_Condiciones As Boolean = False

#End Region
#Region "Load de la Forma"
    Private Sub frmCatalogoProveedores_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Accion = 1
            Call RellenaCombos(Cbo_Estado, "ESTADO", "", GLB_ConStringPerSis, True)
            Call RellenaCombos(Cbo_EstadoD, "ESTADO", "", GLB_ConStringPerSis, True)
            Call RellenaCombos(Cbo_Paqueteria, "TRANSPORTE", "", GLB_ConStringCipSis, True)
            Call RellenaCombos(Cbo_PaqueteriaDev, "TRANSPORTE", "", GLB_ConStringCipSis, True)

            Call RellenaCombos(Cbo_BancoFactoraje, "BANCOFACTORAJE", "", GLB_ConStringCipSis, True)

            'Traer datos de factoraje.


            Using objMySqlGral As New BCL.BCLCatalogoProveedoresN(GLB_ConStringCipSis)
                objDataSet = objMySqlGral.usp_TraerBancoFactoraje(Cbo_BancoFactoraje.Text)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_Proveedor.Text = Val(objDataSet.Tables(0).Rows(0).Item("campo").ToString) + 1
                    IdBancoFactoraje = Val(objDataSet.Tables(0).Rows(0).Item("idbanco"))
                Else
                    IdBancoFactoraje = 0
                End If
            End Using


            If Accion = 1 Then
                
                'Call usp_TraerPaqueterias()

                Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
                    objDataSet = objMySqlGral.usp_TraerFolio("P", "")
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Txt_Proveedor.Text = Val(objDataSet.Tables(0).Rows(0).Item("campo").ToString) + 1
                        'Txt_Proveedor.Text = Txt_Proveedor.Text.PadLeft(3)
                        Txt_Proveedor.Text = pub_RellenarIzquierda(Txt_Proveedor.Text, 3)
                    Else
                        Txt_Proveedor.Text = "  1"
                    End If
                End Using


                Cbo_Estatus.Text = "ACTIVO"
            Else

               
                Call usp_TraerProveedor()
                Call usp_TraerCondicionesProv()
                Call usp_TraerCuentasProv()
                Call usp_TraerDevolucionesProv()
                Call usp_TraerContactosProv()


                'If Accion = 2 Then
                '    numRenCond = DGridCond.Rows.Count
                'End If

                numRenCond = DGridCond.Rows.Count
                numRenContactos = DGridContactos.Rows.Count
                numRenCuentas = DGridCuentas.Rows.Count
            End If

            Call GenerarToolTip()
            Call Edicion()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
#End Region
#Region "Botones"
    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click

        Try
            If Accion = 1 Then '''' es un proveedor nuevo
                If ValidarEdicion() = False Then Exit Sub
                If MsgBox("Estas Seguro de Grabar el Proveedor?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    If Inserta_Proveedor() = True Then
                        Inserta_Condicion()
                        Inserta_Cuentas()
                        Inserta_Devolucion()
                        Inserta_Contactos()
                        GLB_RefrescarPedido = True
                        MessageBox.Show("Exitosamente Grabado el proveedor '" & Txt_Proveedor.Text & "' con razón social '" & Txt_Raz_Soc.Text & " !", "Agregando Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Sw_Registro = True
                        Me.Close()
                        '' Me.Dispose()
                    Else
                        MessageBox.Show("Error Grabando !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    End If
                End If
            ElseIf Accion = 2 Then ' es una actualización
                If ValidarEdicion() = False Then Exit Sub
                If MsgBox("Estas Seguro de Actualizar el Proveedor?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    If Inserta_Proveedor() = True Then
                        'Inserta_ProveedorAnt()
                        If Sw_Condiciones = True Then
                            Inserta_Condicion()
                        End If
                        Inserta_Cuentas()
                        Inserta_Devolucion()
                        Inserta_Contactos()
                        GLB_RefrescarPedido = True
                        MessageBox.Show("Exitosamente Grabado el proveedor '" & Txt_Proveedor.Text & "' con razón social '" & Txt_Raz_Soc.Text & " !", "Actualizando Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Sw_Registro = True
                        Me.Close()
                        Me.Dispose()
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
    Private Sub Btn_Nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Nuevo.Click
        Try
            Accion = 1
            Call Edicion()
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
    Private Sub Btn_Adjuntar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Adjuntar.Click
        Dim RutaOrigen As String = ""
        Dim RutaDestino As String = ""
        Try
            OpenFileDialog.Filter = "img files (*.jpg)|*.jpg|All files (*.*)|*.*"
            OpenFileDialog.FileName = ""
            OpenFileDialog.ShowDialog()

            If OpenFileDialog.FileName = "" Then Exit Sub
            Txt_Archivo.Text = OpenFileDialog.FileName

            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)
                RutaOrigen = Txt_Archivo.Text
                RutaDestino = ""

                RutaDestino = GLB_RutaContratoAdicionalProv & "\" & Txt_Proveedor.Text & ".jpg"

                If objIO.pub_ExisteArchivo(RutaDestino) = True Then
                    '' ya existe 
                    If MsgBox("El archivo ya existe, desea reemplazar el contrato adicional del proveedor'" & Txt_Proveedor.Text & "'?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.Yes Then

                        objIO.pub_EliminarArchivo(GLB_RutaContratoAdicionalProv & "\" & Txt_Proveedor.Text & ".jpg")
                        'CambiarArchivo(RutaOrigen, RutaDestino)
                        objIO.pub_CopiarArchivo(RutaOrigen, RutaDestino)

                        If objIO.pub_ExisteArchivo(RutaDestino) = True Then
                            MsgBox("Archivo correctamente grabado en la ruta '" & RutaDestino & "'", MsgBoxStyle.Information, "Confirmación")
                        End If
                    Else
                        'RutaDestino = GLB_RutaContratoAdicionalProv & "\" & Txt_Proveedor.Text & ".jpg"
                        'CambiarArchivo(RutaOrigen, RutaDestino)
                    End If
                Else
                    RutaDestino = GLB_RutaContratoAdicionalProv & "\" & Txt_Proveedor.Text & ".jpg"
                    '                    CambiarArchivo(RutaOrigen, RutaDestino)
                    objIO.pub_CopiarArchivo(RutaOrigen, RutaDestino)
                    If objIO.pub_ExisteArchivo(RutaDestino) = True Then
                        MsgBox("Archivo correctamente grabado en la ruta '" & RutaDestino & "'", MsgBoxStyle.Information, "Confirmación")
                    End If
                End If
                RutaOrigen = Txt_Archivo.Text
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Btn_Consultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Consultar.Click
        Try
            Dim myForm As New frmConsultaImagen
            myForm.SW_ContratoAdProv = True
            myForm.Txt_Marca.Text = Txt_Proveedor.Text
            myForm.ShowDialog()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
#End Region
#Region "Funciones"
    Function Inserta_Proveedor() As Boolean
        Using objCatalogoProveedores As New BCL.BCLCatalogoProveedoresN(GLB_ConStringCipSis)
            'Get a new Project DataSet
            Try
                objDataSet = objCatalogoProveedores.Inserta_Proveedor  'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow

                'Set the values in the DataRow
                objDataRow.Item("idproveedor") = Val(Txt_IdProveedor.Text)
                objDataRow.Item("proveedor") = Trim(Txt_Proveedor.Text)
                objDataRow.Item("raz_soc") = Trim(Txt_Raz_Soc.Text)
                objDataRow.Item("rfc") = Trim(Txt_RFC.Text)
                objDataRow.Item("calle") = Trim(Txt_Calle.Text)
                objDataRow.Item("colonia") = Trim(Cbo_Colonia.Text)
                objDataRow.Item("ciudad") = Trim(Cbo_Ciudad.Text)
                objDataRow.Item("estado") = Trim(Cbo_Estado.Text)
                objDataRow.Item("codpos") = Trim(Cbo_CodPos.Text)
                objDataRow.Item("telef1") = Trim(Txt_Telef1.Text)
                objDataRow.Item("telef2") = Trim(Txt_Telef2.Text)
                objDataRow.Item("telef3") = Trim(Txt_Telef3.Text)
                objDataRow.Item("web") = Trim(Txt_SitioWeb.Text)
                objDataRow.Item("usuario") = Trim(Txt_Usuario.Text)
                objDataRow.Item("password") = Trim(Txt_Contraseña.Text)
                objDataRow.Item("paqueteria") = Trim(Cbo_Paqueteria.Text)
                objDataRow.Item("convenio") = Trim(Txt_ConvenioGral.Text)

                If Rb_PorCobrar.Checked = True Then
                    objDataRow.Item("porcobrar") = "1"
                    objDataRow.Item("tipopag") = Trim(Cbo_TipoCobro.Text)
                Else
                    objDataRow.Item("porcobrar") = "0"
                    objDataRow.Item("tipopag") = ""
                End If

                If Rb_LibreA.Checked = True Then
                    objDataRow.Item("librea") = "1"
                Else
                    objDataRow.Item("librea") = "0"
                End If

                objDataRow.Item("status") = Mid(Cbo_Estatus.Text, 1, 2)
                objDataRow.Item("motivo") = Trim(Txt_MotivoEstatus.Text)

                If Accion = 1 Then
                    For i As Integer = 0 To 0
                        objDataRow.Item("dsctopp") = DGridCond.Rows(i).Cells("col_dsctopp").Value
                        If DGridCond.Rows(i).Cells("col_diaspp").Value Is Nothing Then
                            objDataRow.Item("diaspp") = 0
                        Else
                            objDataRow.Item("diaspp") = Val(DGridCond.Rows(i).Cells("col_diaspp").Value)
                        End If
                        objDataRow.Item("dscto01") = DGridCond.Rows(i).Cells("col_dscto01").Value
                        objDataRow.Item("dscto02") = DGridCond.Rows(i).Cells("col_dscto02").Value
                        objDataRow.Item("dscto03") = DGridCond.Rows(i).Cells("col_dscto03").Value
                        objDataRow.Item("dscto04") = DGridCond.Rows(i).Cells("col_dscto04").Value
                        objDataRow.Item("dscto05") = DGridCond.Rows(i).Cells("col_dscto05").Value
                    Next
                ElseIf Accion = 2 Then
                    objDataRow.Item("dsctopp") = Txt_Dsctopp.Text
                    objDataRow.Item("diaspp") = Val(Txt_Diaspp.Text)
                    objDataRow.Item("dscto01") = Txt_Dscto01.Text
                    objDataRow.Item("dscto02") = Txt_Dscto02.Text
                    objDataRow.Item("dscto03") = Txt_Dscto03.Text
                    objDataRow.Item("dscto04") = Txt_Dscto04.Text
                    objDataRow.Item("dscto05") = Txt_Dscto05.Text
                End If

                objDataRow.Item("idusuario") = GLB_Idempleado

                objDataRow.Item("tipo") = Cbo_Tipo.Text
                If Chk_Factoraje.Checked = True Then
                    objDataRow.Item("aceptafactoraje") = 1
                    objDataRow.Item("fechafactoraje") = Txt_FechaFactoraje.Text

                    objDataRow.Item("idbancofactoraje") = IdBancoFactoraje

                Else
                    objDataRow.Item("aceptafactoraje") = 0
                    objDataRow.Item("fechafactoraje") = "1900-01-01"

                    objDataRow.Item("idbancofactoraje") = 0

                End If

                objDataRow.Item("tipopago") = Cbo_TipoPago.Text


                'Add the DataRow to the DataSet
                objDataSet.Tables(0).Rows.Add(objDataRow)

                'Add the Project
                If Not objCatalogoProveedores.usp_Captura_ProveedorN(Accion, objDataSet) Then
                    'Throw New Exception("Falló Inserción de Proveedor")
                Else
                    Inserta_Proveedor = True
                End If

                Call usp_TraerIdProveedor()
                Inserta_Proveedor = True
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function
    Function Inserta_ProveedorAnt() As Boolean
        'mreyes 17/Febrero/2012 10:02 a.m.
        Dim Proveedor_Id As Integer
        Dim Cond_Pago_Id As Integer = 0
        Using objCatalogoProveedores As New BCL.BCLCatalogoProveedores(GLB_ConStringCipSis)
            'Get a new Project DataSet
            Try
                objDataSet = objCatalogoProveedores.Inserta_Proveedor  'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow

                'Set the values in the DataRow

                objDataRow.Item("proveedor") = Trim(Txt_Proveedor.Text)
                objDataRow.Item("raz_soc") = Trim(Txt_Raz_Soc.Text)
                objDataRow.Item("rfc") = Trim(Txt_RFC.Text)
                objDataRow.Item("calle") = Trim(Txt_Calle.Text)
                objDataRow.Item("colonia") = Trim(Cbo_Colonia.Text)
                objDataRow.Item("ciudad") = Trim(Cbo_Ciudad.Text)
                objDataRow.Item("estado") = Trim(Cbo_Estado.Text)
                objDataRow.Item("codpos") = Trim(Cbo_CodPos.Text)
                objDataRow.Item("telef1") = Trim(Txt_Telef1.Text)
                objDataRow.Item("telef2") = Trim(Txt_Telef2.Text)
                objDataRow.Item("fax") = Trim(Txt_Telef2.Text)
                objDataRow.Item("contact1") = ""
                objDataRow.Item("contact2") = ""
                objDataRow.Item("condic") = ""
                objDataRow.Item("transp") = ""
                objDataRow.Item("agente") = ""


                objDataRow.Item("dsctopp") = Txt_Dsctopp.Text
                objDataRow.Item("diaspp") = Val(Txt_Diaspp.Text)
                objDataRow.Item("dscto01") = Txt_Dscto01.Text
                objDataRow.Item("dscto02") = Txt_Dscto02.Text
                objDataRow.Item("dscto03") = Txt_Dscto03.Text
                objDataRow.Item("dscto04") = Txt_Dscto04.Text
                objDataRow.Item("dscto05") = Txt_Dscto05.Text

                'For i As Integer = 0 To 0
                '    objDataRow.Item("dsctopp") = DGridCond.Rows(i).Cells("col_dsctopp").Value
                '    objDataRow.Item("diaspp") = DGridCond.Rows(i).Cells("col_diaspp").Value
                '    objDataRow.Item("dscto01") = DGridCond.Rows(i).Cells("col_dscto01").Value
                '    objDataRow.Item("dscto02") = DGridCond.Rows(i).Cells("col_dscto02").Value
                '    objDataRow.Item("dscto03") = DGridCond.Rows(i).Cells("col_dscto03").Value
                '    objDataRow.Item("dscto04") = DGridCond.Rows(i).Cells("col_dscto04").Value
                '    objDataRow.Item("dscto05") = DGridCond.Rows(i).Cells("col_dscto05").Value
                'Next
                objDataRow.Item("email01") = ""
                objDataRow.Item("email02") = ""
                objDataRow.Item("status") = Mid(Cbo_Estatus.Text, 1, 2)


                objDataRow.Item("remision") = "0"
                objDataRow.Item("adicional") = 0
                objDataRow.Item("pquincenal") = "0"
                objDataRow.Item("numpagos") = 0
                objDataRow.Item("consignacion") = "0"
                objDataRow.Item("dsctofact") = "0"
                objDataRow.Item("devoluciones") = "0"
                objDataRow.Item("contactopago") = ""
                objDataRow.Item("emailcp01") = ""
                objDataRow.Item("emailcp02") = ""

                'Add the DataRow to the DataSet
                objDataSet.Tables(0).Rows.Add(objDataRow)

                'Add the Project
                If Not objCatalogoProveedores.usp_Captura_Proveedor(Accion, objDataSet) Then
                    'Throw New Exception("Falló Inserción de Proveedor")
                Else
                    Inserta_ProveedorAnt = True
                End If

                '' insertar proveedor de microsip 
                If GLB_Microsip = True Then
                    Using objMicrosipE As New BCL.BCLMicrosip(GLB_ConStringMicrosip)
                        Dim objDatasetE As Data.DataSet

                        objDatasetE = objMicrosipE.usp_Traer_Proveedor(0, Txt_Raz_Soc.Text)
                        If objDatasetE.Tables(0).Rows.Count > 0 Then
                            ' ya existe 
                            Proveedor_Id = Val(objDatasetE.Tables(0).Rows(0).Item("proveedor_idb").ToString)
                            Cond_Pago_Id = Val(objDatasetE.Tables(0).Rows(0).Item("cond_pago_idb").ToString)

                        End If
                    End Using

                    '' buscar condicion de pago
                    If Cond_Pago_Id = 0 Then
                        Using objMicrosipE As New BCL.BCLMicrosip(GLB_ConStringMicrosip)
                            Dim objDatasetE As Data.DataSet

                            objDatasetE = objMicrosipE.usp_Traer_Condicion_Pago_CP(DGridCond.Rows(0).Cells("col_dsctopp").Value, DGridCond.Rows(0).Cells("col_diaspp").Value)
                            If objDatasetE.Tables(0).Rows.Count > 0 Then
                                ' ya existe 
                                Cond_Pago_Id = Val(objDatasetE.Tables(0).Rows(0).Item("cond_pago_idb").ToString)

                            End If
                        End Using
                    End If
                    ' traer condicion de pago del proveedor

                    'x()
                    If Cond_Pago_Id = 0 And Proveedor_Id > 0 Then

                        Using objMicrosipE As New BCL.BCLMicrosip(GLB_ConStringMicrosip)
                            Dim objDatasetE As Data.DataSet

                            objDatasetE = objMicrosipE.usp_Traer_Proveedor(Proveedor_Id, "")
                            If objDatasetE.Tables(0).Rows.Count > 0 Then
                                Cond_Pago_Id = Val(objDatasetE.Tables(0).Rows(0).Item("Cond_Pago_IdB").ToString)

                            End If
                        End Using
                    End If


                    If Proveedor_Id = 0 Then
                        If Inserta_ProveedoresMicrosip(1, Proveedor_Id, Cond_Pago_Id) = False Then
                            Inserta_ProveedorAnt = False
                        End If
                        If Inserta_Libres_ProveedoresMicrosip(1, Proveedor_Id) Then

                        End If
                    Else
                        If Inserta_ProveedoresMicrosip(2, Proveedor_Id, Cond_Pago_Id) = False Then
                            MsgBox("No se pudo actualizar Proveedor en Microsip, Reportelo a Sistemas.", MsgBoxStyle.Critical, "Error")
                        End If
                        '' BUSCAR LIBRES PROVEEDORS SINO ESTA ENTONCES DARLOS DE ALTA

                        If Inserta_Libres_ProveedoresMicrosip(IIf(Sw_LibresProveedores = True, 2, 1), Proveedor_Id) = False Then
                            MsgBox("No se pudo actualizar Marca en Microsip, Reportelo a Sistemas.", MsgBoxStyle.Critical, "Error")

                        End If
                    End If

                    '' ACTUALIZAR O GRABAR EN LIBRES_PROVEEDOR


                End If
                Inserta_ProveedorAnt = True
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function
    Function Inserta_Condicion() As Boolean
        Dim objDataSetC As Data.DataSet
        Dim Opcion As Integer = Accion
        Dim numRenNuevo As Integer = 0
        'Get a new Project DataSet
        Try
            If Accion = 2 Then

                numRenNuevo = DGridCond.Rows.Count


                If numRenNuevo = numRenCond Then

                    For i As Integer = 0 To DGridCond.Rows.Count - 2

                        If Marca = DGridCond.Rows(i).Cells("col_marca").Value.ToString Then
                            Using objCatalogoProveedores As New BCL.BCLCatalogoProveedoresN(GLB_ConStringCipSis)
                                objDataSetC = objCatalogoProveedores.Inserta_Condicion  'INSERTA NUEVO DATASET
                                'Initialize a datarow object from the Project DataSet
                                Dim objDataRow As Data.DataRow = objDataSetC.Tables(0).NewRow

                                'Set the values in the DataRow
                                If DGridCond.Rows(i).Cells("col_idcondicion").Value Is Nothing Then
                                    Opcion = 1
                                Else
                                    Opcion = 2
                                End If

                                If Opcion = 1 Then
                                    objDataRow.Item("idcondicion") = 0
                                Else
                                    objDataRow.Item("idcondicion") = Val(DGridCond.Rows(i).Cells("col_idcondicion").Value)
                                End If

                                objDataRow.Item("idproveedor") = Val(Txt_IdProveedor.Text)
                                objDataRow.Item("proveedor") = Trim(Txt_Proveedor.Text)

                                If RB_FecReci.Checked = True AndAlso RB_FecFact.Checked = False Then
                                    objDataRow.Item("basevenc") = "R"
                                ElseIf RB_FecReci.Checked = False AndAlso RB_FecFact.Checked = True Then
                                    objDataRow.Item("basevenc") = "F"
                                End If

                                'If i <> 0 Then
                                objDataRow.Item("marca") = DGridCond.Rows(i).Cells("col_marca").Value.ToString
                                objDataRow.Item("factorc") = DGridCond.Rows(i).Cells("col_factor").Value

                                If DGridCond.Rows(i).Cells("col_tipop").Value.ToString = "QUINCENAL" Then
                                    objDataRow.Item("tipopago") = "Q"
                                ElseIf DGridCond.Rows(i).Cells("col_tipop").Value.ToString = "SEMANAL" Then
                                    objDataRow.Item("tipopago") = "S"
                                ElseIf DGridCond.Rows(i).Cells("col_tipop").Value.ToString = "UNA SOLA EXHIBICION" Then
                                    objDataRow.Item("tipopago") = "U"
                                End If



                                objDataRow.Item("numpagos") = DGridCond.Rows(i).Cells("col_numpagos").Value

                             

                                objDataRow.Item("dsctopp") = DGridCond.Rows(i).Cells("col_dsctopp").Value
                                objDataRow.Item("diaspp") = Val(DGridCond.Rows(i).Cells("col_diaspp").Value)
                                'objDataRow.Item("plazoporc") = DGridCond.Rows(i).Cells("col_plazoporc").Value
                                objDataRow.Item("dscto01") = DGridCond.Rows(i).Cells("col_dscto01").Value
                                objDataRow.Item("dscto02") = DGridCond.Rows(i).Cells("col_dscto02").Value
                                objDataRow.Item("dscto03") = DGridCond.Rows(i).Cells("col_dscto03").Value
                                objDataRow.Item("dscto04") = DGridCond.Rows(i).Cells("col_dscto04").Value
                                objDataRow.Item("dscto05") = DGridCond.Rows(i).Cells("col_dscto05").Value
                                'objDataRow.Item("lotemin") = DGridCond.Rows(i).Cells("col_lote").Value
                                'objDataRow.Item("univta") = DGridCond.Rows(i).Cells("col_univta").Value

                                If Chk_DesctoFact.Checked = True Then
                                    objDataRow.Item("dsctofact") = "1"
                                Else
                                    objDataRow.Item("dsctofact") = "0"
                                End If

                                If Chk_RProv.Checked = True Then
                                    objDataRow.Item("rprov") = "1"
                                Else
                                    objDataRow.Item("rprov") = "0"
                                End If

                                If DGridCond.Rows(i).Cells("provisionales").Value = True Then
                                    objDataRow.Item("rprov") = "1"
                                Else
                                    objDataRow.Item("rprov") = "0"
                                End If


                                If Chk_AceptaDev.Checked = True Then
                                    objDataRow.Item("aceptadev") = "1"
                                Else
                                    objDataRow.Item("aceptadev") = "0"
                                End If


                                If Chk_Costeo.Checked = True Then
                                    objDataRow.Item("costeopv") = "1"
                                    'objDataRow.Item("costeomargen") = CInt(Txt_MargenCosteo.Text)
                                Else
                                    objDataRow.Item("costeopv") = "0"
                                    'objDataRow.Item("costeomargen") = 0
                                End If

                                If Chk_Consignacion.Checked = True Then
                                    objDataRow.Item("consignacion") = "1"
                                    objDataRow.Item("plazo") = Val(Txt_PlazoC.Text)
                                    objDataRow.Item("condicion") = CDec(Txt_Condicion.Text)
                                Else
                                    objDataRow.Item("consignacion") = "0"
                                    objDataRow.Item("plazo") = 0
                                    objDataRow.Item("condicion") = 0.0
                                End If

                                objDataRow.Item("cpdias") = 0
                                objDataRow.Item("cpporc") = 0.0
                                objDataRow.Item("idusuario") = GLB_Idempleado
                                objDataRow.Item("VIGENCIA") = DGridCond.Rows(i).Cells("vigencia").Value



                                If DGridCond.Rows(i).Cells("factrem").Value = True Then
                                    objDataRow.Item("factrem") = "1"
                                Else
                                    objDataRow.Item("factrem") = "0"
                                End If


                                'Add the DataRow to the DataSet
                                objDataSetC.Tables(0).Rows.Add(objDataRow)

                                'Add the Project
                                If Not objCatalogoProveedores.usp_Captura_CondicionesProv(Opcion, objDataSetC) Then
                                    'Throw New Exception("Falló Inserción de Proveedor")
                                Else
                                    Inserta_Condicion = True
                                End If
                            End Using
                        End If
                    Next
                    Inserta_Condicion = True
                Else

                    Using objCatalogoProveedores As New BCL.BCLCatalogoProveedoresN(GLB_ConStringCipSis)
                        objDataSetC = objCatalogoProveedores.Inserta_Condicion  'INSERTA NUEVO DATASET
                        'Initialize a datarow object from the Project DataSet
                        Dim objDataRow As Data.DataRow = objDataSetC.Tables(0).NewRow

                        'Set the values in the DataRow
                        If DGridCond.Rows(DGridCond.Rows.Count - 1).Cells("col_idcondicion").Value Is Nothing Then
                            Opcion = 1
                        Else
                            Opcion = 2
                        End If

                        If Opcion = 1 Then
                            objDataRow.Item("idcondicion") = 0
                        Else
                            objDataRow.Item("idcondicion") = Val(DGridCond.Rows(DGridCond.Rows.Count - 2).Cells("col_idcondicion").Value)
                        End If

                        objDataRow.Item("idproveedor") = Val(Txt_IdProveedor.Text)
                        objDataRow.Item("proveedor") = Trim(Txt_Proveedor.Text)

                        If RB_FecReci.Checked = True AndAlso RB_FecFact.Checked = False Then
                            objDataRow.Item("basevenc") = "R"
                        ElseIf RB_FecReci.Checked = False AndAlso RB_FecFact.Checked = True Then
                            objDataRow.Item("basevenc") = "F"
                        End If

                        'If i <> 0 Then
                        objDataRow.Item("marca") = DGridCond.Rows(DGridCond.Rows.Count - 2).Cells("col_marca").Value.ToString
                        objDataRow.Item("factorc") = DGridCond.Rows(DGridCond.Rows.Count - 2).Cells("col_factor").Value

                        If DGridCond.Rows(DGridCond.Rows.Count - 2).Cells("col_tipop").Value.ToString = "QUINCENAL" Then
                            objDataRow.Item("tipopago") = "Q"
                        ElseIf DGridCond.Rows(DGridCond.Rows.Count - 2).Cells("col_tipop").Value.ToString = "SEMANAL" Then
                            objDataRow.Item("tipopago") = "S"
                        ElseIf DGridCond.Rows(DGridCond.Rows.Count - 2).Cells("col_tipop").Value.ToString = "UNA SOLA EXHIBICION" Then
                            objDataRow.Item("tipopago") = "U"
                        End If

                        objDataRow.Item("numpagos") = DGridCond.Rows(DGridCond.Rows.Count - 2).Cells("col_numpagos").Value
                       

                        objDataRow.Item("dsctopp") = DGridCond.Rows(DGridCond.Rows.Count - 2).Cells("col_dsctopp").Value
                        objDataRow.Item("diaspp") = Val(DGridCond.Rows(DGridCond.Rows.Count - 2).Cells("col_diaspp").Value)
                        'objDataRow.Item("plazoporc") = DGridCond.Rows(DGridCond.Rows.Count - 2).Cells("col_plazoporc").Value
                        objDataRow.Item("dscto01") = DGridCond.Rows(DGridCond.Rows.Count - 2).Cells("col_dscto01").Value
                        objDataRow.Item("dscto02") = DGridCond.Rows(DGridCond.Rows.Count - 2).Cells("col_dscto02").Value
                        objDataRow.Item("dscto03") = DGridCond.Rows(DGridCond.Rows.Count - 2).Cells("col_dscto03").Value
                        objDataRow.Item("dscto04") = DGridCond.Rows(DGridCond.Rows.Count - 2).Cells("col_dscto04").Value
                        objDataRow.Item("dscto05") = DGridCond.Rows(DGridCond.Rows.Count - 2).Cells("col_dscto05").Value
                        'objDataRow.Item("lotemin") = DGridCond.Rows(DGridCond.Rows.Count - 2).Cells("col_lote").Value
                        'objDataRow.Item("univta") = DGridCond.Rows(DGridCond.Rows.Count - 2).Cells("col_univta").Value

                        If Chk_DesctoFact.Checked = True Then
                            objDataRow.Item("dsctofact") = "1"
                        Else
                            objDataRow.Item("dsctofact") = "0"
                        End If

                        If Chk_RProv.Checked = True Then
                            objDataRow.Item("rprov") = "1"
                        Else
                            objDataRow.Item("rprov") = "0"
                        End If

                        If Chk_AceptaDev.Checked = True Then
                            objDataRow.Item("aceptadev") = "1"
                        Else
                            objDataRow.Item("aceptadev") = "0"
                        End If

                        If Chk_Costeo.Checked = True Then
                            objDataRow.Item("costeopv") = "1"
                            'objDataRow.Item("costeomargen") = CInt(Txt_MargenCosteo.Text)
                        Else
                            objDataRow.Item("costeopv") = "0"
                            'objDataRow.Item("costeomargen") = 0
                        End If

                        If Chk_Consignacion.Checked = True Then
                            objDataRow.Item("consignacion") = "1"
                            objDataRow.Item("plazo") = Val(Txt_PlazoC.Text)
                            objDataRow.Item("condicion") = CDec(Txt_Condicion.Text)
                        Else
                            objDataRow.Item("consignacion") = "0"
                            objDataRow.Item("plazo") = 0
                            objDataRow.Item("condicion") = 0.0
                        End If

                        objDataRow.Item("cpdias") = 0
                        objDataRow.Item("cpporc") = 0.0
                        objDataRow.Item("idusuario") = GLB_Idempleado
                        objDataRow.Item("VIGENCIA") = DGridCond.Rows(DGridCond.Rows.Count - 2).Cells("vigencia").Value

                        If DGridCond.Rows(DGridCond.Rows.Count - 2).Cells("factrem").Value = True Then
                            objDataRow.Item("factrem") = "1"
                        Else
                            objDataRow.Item("factrem") = "0"
                        End If

                        'Add the DataRow to the DataSet
                        objDataSetC.Tables(0).Rows.Add(objDataRow)

                        'Add the Project
                        If Not objCatalogoProveedores.usp_Captura_CondicionesProv(Opcion, objDataSetC) Then
                            'Throw New Exception("Falló Inserción de Proveedor")
                        Else
                            Inserta_Condicion = True
                        End If
                    End Using
                    Inserta_Condicion = True

                End If

                
            ElseIf Accion = 1 Then
                For i As Integer = 0 To DGridCond.Rows.Count - 2
                    Using objCatalogoProveedores As New BCL.BCLCatalogoProveedoresN(GLB_ConStringCipSis)

                        objDataSet = objCatalogoProveedores.Inserta_Condicion  'INSERTA NUEVO DATASET
                        'Initialize a datarow object from the Project DataSet
                        Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow

                        'Set the values in the DataRow

                        If Accion = 1 Then
                            objDataRow.Item("idcondicion") = 0
                        Else
                            objDataRow.Item("idcondicion") = Val(DGridCond.Rows(i).Cells("col_idcondicion").Value)

                        End If

                        objDataRow.Item("idproveedor") = Val(Txt_IdProveedor.Text)
                        objDataRow.Item("proveedor") = Trim(Txt_Proveedor.Text)

                        If RB_FecReci.Checked = True AndAlso RB_FecFact.Checked = False Then
                            objDataRow.Item("basevenc") = "R"
                        ElseIf RB_FecReci.Checked = False AndAlso RB_FecFact.Checked = True Then
                            objDataRow.Item("basevenc") = "F"
                        End If

                        'If i <> 0 Then
                        objDataRow.Item("marca") = DGridCond.Rows(i).Cells("col_marca").Value.ToString
                        objDataRow.Item("factorc") = DGridCond.Rows(i).Cells("col_factor").Value

                        If DGridCond.Rows(i).Cells("col_tipop").Value.ToString = "QUINCENAL" Then
                            objDataRow.Item("tipopago") = "Q"
                        ElseIf DGridCond.Rows(i).Cells("col_tipop").Value.ToString = "SEMANAL" Then
                            objDataRow.Item("tipopago") = "S"
                        ElseIf DGridCond.Rows(i).Cells("col_tipop").Value.ToString = "UNA SOLA EXHIBICION" Then
                            objDataRow.Item("tipopago") = "U"
                        End If


                        objDataRow.Item("numpagos") = DGridCond.Rows(i).Cells("col_numpagos").Value
                      

                        objDataRow.Item("dsctopp") = DGridCond.Rows(i).Cells("col_dsctopp").Value
                        objDataRow.Item("diaspp") = Val(DGridCond.Rows(i).Cells("col_diaspp").Value)
                        objDataRow.Item("dscto01") = DGridCond.Rows(i).Cells("col_dscto01").Value
                        objDataRow.Item("dscto02") = DGridCond.Rows(i).Cells("col_dscto02").Value
                        objDataRow.Item("dscto03") = DGridCond.Rows(i).Cells("col_dscto03").Value
                        objDataRow.Item("dscto04") = DGridCond.Rows(i).Cells("col_dscto04").Value
                        objDataRow.Item("dscto05") = DGridCond.Rows(i).Cells("col_dscto05").Value

                        If Chk_DesctoFact.Checked = True Then
                            objDataRow.Item("dsctofact") = "1"
                        Else
                            objDataRow.Item("dsctofact") = "0"
                        End If

                        If Chk_RProv.Checked = True Then
                            objDataRow.Item("rprov") = "1"
                        Else
                            objDataRow.Item("rprov") = "0"
                        End If

                        If Chk_AceptaDev.Checked = True Then
                            objDataRow.Item("aceptadev") = "1"
                        Else
                            objDataRow.Item("aceptadev") = "0"
                        End If

                        If Chk_Costeo.Checked = True Then
                            objDataRow.Item("costeopv") = "1"
                            'objDataRow.Item("costeomargen") = CInt(Txt_MargenCosteo.Text)
                        Else
                            objDataRow.Item("costeopv") = "0"
                            'objDataRow.Item("costeomargen") = 0
                        End If

                        If Chk_Consignacion.Checked = True Then
                            objDataRow.Item("consignacion") = "1"
                            objDataRow.Item("plazo") = Val(Txt_PlazoC.Text)
                            objDataRow.Item("condicion") = CDec(Txt_Condicion.Text)
                        Else
                            objDataRow.Item("consignacion") = "0"
                            objDataRow.Item("plazo") = 0
                            objDataRow.Item("condicion") = 0.0
                        End If

                        objDataRow.Item("cpdias") = 0
                        objDataRow.Item("cpporc") = 0.0
                        objDataRow.Item("idusuario") = GLB_Idempleado

                        objDataRow.Item("VIGENCIA") = DGridCond.Rows(i).Cells("vigencia").Value
                        'Add the DataRow to the DataSet

                        If DGridCond.Rows(i).Cells("factrem").Value = True Then
                            objDataRow.Item("factrem") = "1"
                        Else
                            objDataRow.Item("factrem") = "0"
                        End If


                        objDataSet.Tables(0).Rows.Add(objDataRow)

                        'Add the Project
                        If Not objCatalogoProveedores.usp_Captura_CondicionesProv(Opcion, objDataSet) Then
                            'Throw New Exception("Falló Inserción de Proveedor")
                        Else
                            Inserta_Condicion = True
                        End If

                        Inserta_Condicion = True
                    End Using
                Next
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function
    Function Inserta_Devolucion() As Boolean
        Dim Opcion As Integer = 0
        Try
            If Chk_AceptaDev.Checked = True Then

                Using objCatalogoProveedores As New BCL.BCLCatalogoProveedoresN(GLB_ConStringCipSis)
                    objDataSet = objCatalogoProveedores.usp_TraerDevolucionesProv(Val(Txt_IdProveedor.Text), Marca)
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Opcion = 2
                    Else
                        Opcion = 1
                    End If
                End Using

                Using objCatalogoProveedores As New BCL.BCLCatalogoProveedoresN(GLB_ConStringCipSis)
                    objDataSet = objCatalogoProveedores.Inserta_Devolucion  'INSERTA NUEVO DATASET

                    Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow

                    objDataRow.Item("iddevolprov") = 0
                    objDataRow.Item("idproveedor") = Val(Txt_IdProveedor.Text)
                    objDataRow.Item("proveedor") = Trim(Txt_Proveedor.Text)

                    If Opcion = 1 Then
                        objDataRow.Item("marca") = DGridCond.Rows(DGridCond.CurrentRow.Index).Cells("col_marca").Value
                    Else
                        objDataRow.Item("marca") = Marca
                    End If

                    If RB_Saldo.Checked = True AndAlso RB_Factura.Checked = False Then
                        objDataRow.Item("tipodev") = "S"
                    ElseIf RB_Saldo.Checked = False AndAlso RB_Factura.Checked = True Then
                        objDataRow.Item("tipodev") = "F"
                    End If

                    objDataRow.Item("paresmin") = Val(Txt_ParMin.Text)
                    If Txt_ImpMin.Text <> "" Then
                        objDataRow.Item("impmin") = CDec(Txt_ImpMin.Text)
                    Else
                        objDataRow.Item("impmin") = 0.0
                    End If

                    objDataRow.Item("plazo") = Val(Txt_PlazoDev.Text)
                    objDataRow.Item("procedimd") = Trim(Txt_ProcedimDev.Text)
                    objDataRow.Item("contacto") = Trim(Txt_ContactoDev.Text)
                    objDataRow.Item("calle") = Trim(Txt_CalleDev.Text)
                    objDataRow.Item("colonia") = Trim(Cbo_ColoniaD.Text)
                    objDataRow.Item("ciudad") = Trim(Cbo_CiudadD.Text)
                    objDataRow.Item("estado") = Trim(Cbo_EstadoD.Text)
                    objDataRow.Item("codpos") = Trim(Cbo_CodPosD.Text)
                    objDataRow.Item("telef1") = Trim(Txt_Tel1Dev.Text)
                    objDataRow.Item("telef2") = Trim(Txt_Tel2Dev.Text)
                    objDataRow.Item("email") = Trim(Txt_CorreoDev.Text)

                    If Chk_DevCorreo.Checked = True Then
                        objDataRow.Item("viaemail") = "S"
                    Else
                        objDataRow.Item("viaemail") = "N"
                    End If

                    objDataRow.Item("paqueteria") = Trim(Cbo_PaqueteriaDev.Text)
                    objDataRow.Item("convenio") = Trim(Txt_ConvenioDev.Text)

                    If Rb_PorCobrarDev.Checked = True Then
                        objDataRow.Item("porcobrar") = "1"
                        objDataRow.Item("tipopag") = Trim(Cbo_TipoCobroDev.Text)
                    Else
                        objDataRow.Item("porcobrar") = "0"
                        objDataRow.Item("tipopag") = ""
                    End If

                    If Rb_LibreADev.Checked = True Then
                        objDataRow.Item("librea") = "1"
                    Else
                        objDataRow.Item("librea") = "0"
                    End If

                    objDataRow.Item("procedimp") = Trim(Txt_ProcedimPaq.Text)
                    objDataRow.Item("idusuario") = GLB_Idempleado

                    'Add the DataRow to the DataSet
                    objDataSet.Tables(0).Rows.Add(objDataRow)

                    'Add the Project
                    If Not objCatalogoProveedores.usp_Captura_DevolucionesProv(Opcion, objDataSet) Then
                        'Throw New Exception("Falló Inserción de Proveedor")
                    Else
                        Inserta_Devolucion = True
                    End If
                End Using
            End If

            Inserta_Devolucion = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Function
    Function Inserta_Cuentas() As Boolean
        Dim objDataSetC As Data.DataSet
        Dim objDataRow As Data.DataRow
        Dim Opcion As Integer = Accion
        Dim Sw_ExisteCuenta As Boolean

        'Get a new Project DataSet
        Try
            If Accion = 2 Then
                'objDataSetC = objCatalogoProveedores.usp_TraerCantidadDetProv("CT", Txt_Proveedor.Text)
                'If objDataSetC.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To DGridCuentas.Rows.Count - 2

                    Using objCatalogoProveedores As New BCL.BCLCatalogoProveedoresN(GLB_ConStringCipSis)
                        If DGridCuentas.Rows(i).Cells("col_idcuenta").Value Is Nothing Then
                            'Opcion = 1
                            Sw_ExisteCuenta = False
                        Else
                            If DGridCuentas.Rows(i).Cells("col_idcuenta").Value.ToString.Trim = "" Then
                                Sw_ExisteCuenta = False
                            Else
                                Sw_ExisteCuenta = True
                            End If
                        End If
                        
                        objDataSetC = New Data.DataSet

                        objDataSetC = objCatalogoProveedores.Inserta_Cuentas  'INSERTA NUEVO DATASET
                        'Initialize a datarow object from the Project DataSet
                        objDataRow = objDataSetC.Tables(0).NewRow


                        If Opcion = 1 Then
                            objDataRow.Item("idcuenta") = 0
                            objDataRow.Item("idproveedor") = Val(Txt_IdProveedor.Text)
                        Else
                            objDataRow.Item("idcuenta") = Val(DGridCuentas.Rows(i).Cells("col_idcuenta").Value)
                            objDataRow.Item("idproveedor") = Val(Txt_IdProveedor.Text)
                        End If


                        objDataRow.Item("proveedor") = Trim(Txt_Proveedor.Text)
                        objDataRow.Item("plaza") = DGridCuentas.Rows(i).Cells("col_plaza").Value.ToString
                        objDataRow.Item("banco") = DGridCuentas.Rows(i).Cells("col_banco").Value.ToString
                        objDataRow.Item("sucursal") = DGridCuentas.Rows(i).Cells("col_sucursal").Value.ToString
                        objDataRow.Item("clabe") = DGridCuentas.Rows(i).Cells("col_clabe").Value.ToString
                        objDataRow.Item("referencia") = DGridCuentas.Rows(i).Cells("col_ref").Value.ToString
                        objDataRow.Item("cuenta") = DGridCuentas.Rows(i).Cells("col_cuenta").Value.ToString
                        objDataRow.Item("idusuario") = GLB_Idempleado

                        'Add the DataRow to the DataSet
                        objDataSetC.Tables(0).Rows.Add(objDataRow)

                        'Add the Project
                        If Sw_ExisteCuenta = True Then
                            If Not objCatalogoProveedores.usp_Captura_CuentasProv(2, objDataSetC) Then
                                'Throw New Exception("Falló Inserción de Proveedor")
                            Else
                                Inserta_Cuentas = True
                            End If
                        Else
                            If Not objCatalogoProveedores.usp_Captura_CuentasProv(1, objDataSetC) Then
                                'Throw New Exception("Falló Inserción de Proveedor")
                            Else
                                Inserta_Cuentas = True
                            End If
                        End If

                        objDataSetC.Dispose()
                        objDataRow.Table.Dispose()

                        Inserta_Cuentas = True

                    End Using
                Next
                'End If
            ElseIf Accion = 1 Then
                For i As Integer = 0 To DGridCuentas.Rows.Count - 2
                    Using objCatalogoProveedores As New BCL.BCLCatalogoProveedoresN(GLB_ConStringCipSis)
                        objDataSet = objCatalogoProveedores.Inserta_Cuentas  'INSERTA NUEVO DATASET
                        'Initialize a datarow object from the Project DataSet
                        'Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow
                        objDataRow = objDataSet.Tables(0).NewRow

                        If Opcion = 1 Then
                            objDataRow.Item("idcuenta") = 0
                        Else
                            objDataRow.Item("idcuenta") = Val(DGridCuentas.Rows(i).Cells("col_idcuenta").Value)
                        End If

                        objDataRow.Item("idproveedor") = Val(Txt_IdProveedor.Text)
                        objDataRow.Item("proveedor") = Trim(Txt_Proveedor.Text)
                        objDataRow.Item("plaza") = DGridCuentas.Rows(i).Cells("col_plaza").Value.ToString
                        objDataRow.Item("banco") = DGridCuentas.Rows(i).Cells("col_banco").Value.ToString
                        objDataRow.Item("sucursal") = DGridCuentas.Rows(i).Cells("col_sucursal").Value.ToString
                        objDataRow.Item("clabe") = DGridCuentas.Rows(i).Cells("col_clabe").Value.ToString
                        objDataRow.Item("referencia") = DGridCuentas.Rows(i).Cells("col_ref").Value.ToString
                        objDataRow.Item("cuenta") = DGridCuentas.Rows(i).Cells("col_cuenta").Value.ToString
                        objDataRow.Item("idusuario") = GLB_Idempleado

                        'Add the DataRow to the DataSet
                        objDataSet.Tables(0).Rows.Add(objDataRow)

                        'Add the Project
                        If Not objCatalogoProveedores.usp_Captura_CuentasProv(Opcion, objDataSet) Then
                            'Throw New Exception("Falló Inserción de Proveedor")
                        Else
                            Inserta_Cuentas = True
                        End If

                        objDataSet.Dispose()
                        objDataRow.Table.Dispose()

                        Inserta_Cuentas = True
                    End Using
                Next
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function
    Function Inserta_Contactos() As Boolean

        Dim objDataSetC As Data.DataSet
        Dim Opcion As Integer = Accion

        Dim indexGrid As Integer = 0

        Try
            If Accion = 2 Then




                If DGridContactos.Rows.Count <> numRenContactos Then

                    Dim cantNuevos As Integer = 0
                    For n As Integer = numRenContactos To DGridContactos.Rows.Count - 1
                        cantNuevos += 1
                    Next

                    For l As Integer = 0 To DGridContactos.Rows.Count - 1
                        Using objCatalogoProveedores As New BCL.BCLCatalogoProveedoresN(GLB_ConStringCipSis)

                            If DGridContactos.Rows(l).Cells("col_idcontacto").Value = " " Then
                                Opcion = 1
                            Else
                                Opcion = 2
                            End If
                            objDataSetC = New Data.DataSet
                            objDataSetC = objCatalogoProveedores.Inserta_Contactos  'INSERTA NUEVO DATASET
                            'Initialize a datarow object from the Project DataSet
                            Dim objDataRow As Data.DataRow = objDataSetC.Tables(0).NewRow

                            'Set the values in the DataRow
                            If Opcion = 1 Then
                                objDataRow.Item("idcontacto") = 0
                            Else
                                objDataRow.Item("idcontacto") = Val(DGridContactos.Rows(l).Cells("col_idcontacto").Value)
                            End If

                            objDataRow.Item("idproveedor") = Val(Txt_IdProveedor.Text)
                            objDataRow.Item("proveedor") = Trim(Txt_Proveedor.Text)

                            objDataRow.Item("marca") = Marca

                            objDataRow.Item("nombre") = DGridContactos.Rows(l).Cells("col_nombre").Value.ToString
                            objDataRow.Item("puesto") = DGridContactos.Rows(l).Cells("col_puesto").Value.ToString
                            objDataRow.Item("email") = DGridContactos.Rows(l).Cells("col_email").Value.ToString
                            objDataRow.Item("telefono") = DGridContactos.Rows(l).Cells("col_telefono").Value.ToString
                            objDataRow.Item("extension") = DGridContactos.Rows(l).Cells("col_ext").Value.ToString
                            objDataRow.Item("celular") = DGridContactos.Rows(l).Cells("col_movil").Value.ToString
                            objDataRow.Item("nextel") = DGridContactos.Rows(l).Cells("col_nextel").Value.ToString
                            objDataRow.Item("ubicacion") = DGridContactos.Rows(l).Cells("col_ubicacion").Value.ToString
                            objDataRow.Item("idusuario") = GLB_Idempleado

                            'Add the DataRow to the DataSet
                            objDataSetC.Tables(0).Rows.Add(objDataRow)

                            'Add the Project
                            If Not objCatalogoProveedores.usp_Captura_ContactosProv(Opcion, objDataSetC) Then
                                'Throw New Exception("Falló Inserción de Proveedor")
                            Else
                                Inserta_Contactos = True
                            End If
                            objDataSetC.Dispose()
                            objDataRow.Table.Dispose()
                            Inserta_Contactos = True
                        End Using
                    Next
                Else

                    For i As Integer = 0 To DGridContactos.Rows.Count - 2
                        Using objCatalogoProveedores As New BCL.BCLCatalogoProveedoresN(GLB_ConStringCipSis)
                            If DGridContactos.Rows(i).Cells("col_idcontacto").Value Is Nothing Then
                                Opcion = 1
                            Else
                                Opcion = 2
                            End If
                            objDataSetC = New Data.DataSet
                            objDataSetC = objCatalogoProveedores.Inserta_Contactos  'INSERTA NUEVO DATASET
                            'Initialize a datarow object from the Project DataSet
                            Dim objDataRow As Data.DataRow = objDataSetC.Tables(0).NewRow

                            'Set the values in the DataRow
                            If Opcion = 1 Then
                                objDataRow.Item("idcontacto") = 0
                            Else
                                objDataRow.Item("idcontacto") = Val(DGridContactos.Rows(i).Cells("col_idcontacto").Value)
                            End If

                            objDataRow.Item("idproveedor") = Val(Txt_IdProveedor.Text)
                            objDataRow.Item("proveedor") = Trim(Txt_Proveedor.Text)
                            If Opcion = 1 Then
                                objDataRow.Item("marca") = DGridCond.Rows(0).Cells("col_marca").Value
                            Else
                                objDataRow.Item("marca") = Marca
                            End If
                            objDataRow.Item("nombre") = DGridContactos.Rows(i).Cells("col_nombre").Value.ToString
                            objDataRow.Item("puesto") = DGridContactos.Rows(i).Cells("col_puesto").Value.ToString
                            objDataRow.Item("email") = DGridContactos.Rows(i).Cells("col_email").Value.ToString
                            objDataRow.Item("telefono") = DGridContactos.Rows(i).Cells("col_telefono").Value.ToString
                            objDataRow.Item("extension") = DGridContactos.Rows(i).Cells("col_ext").Value.ToString
                            objDataRow.Item("celular") = DGridContactos.Rows(i).Cells("col_movil").Value.ToString
                            objDataRow.Item("nextel") = DGridContactos.Rows(i).Cells("col_nextel").Value.ToString
                            objDataRow.Item("ubicacion") = DGridContactos.Rows(i).Cells("col_ubicacion").Value.ToString
                            objDataRow.Item("idusuario") = GLB_Idempleado

                            'Add the DataRow to the DataSet
                            objDataSetC.Tables(0).Rows.Add(objDataRow)

                            'Add the Project
                            If Not objCatalogoProveedores.usp_Captura_ContactosProv(Opcion, objDataSetC) Then
                                'Throw New Exception("Falló Inserción de Proveedor")
                            Else
                                Inserta_Contactos = True
                            End If
                            objDataSetC.Dispose()
                            objDataRow.Table.Dispose()
                            Inserta_Contactos = True
                        End Using
                    Next
                End If
            ElseIf Accion = 1 Then
                For i As Integer = 0 To DGridContactos.Rows.Count - 2
                    Using objCatalogoProveedores As New BCL.BCLCatalogoProveedoresN(GLB_ConStringCipSis)
                        objDataSet = New Data.DataSet
                        objDataSet = objCatalogoProveedores.Inserta_Contactos  'INSERTA NUEVO DATASET
                        'Initialize a datarow object from the Project DataSet
                        Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow

                        'Set the values in the DataRow
                        If Opcion = 1 Then
                            objDataRow.Item("idcontacto") = 0
                        Else
                            objDataRow.Item("idcontacto") = Val(DGridContactos.Rows(i).Cells("col_idcontacto").Value)
                        End If

                        objDataRow.Item("idproveedor") = Val(Txt_IdProveedor.Text)
                        objDataRow.Item("proveedor") = Trim(Txt_Proveedor.Text)
                        If Opcion = 1 Then
                            objDataRow.Item("marca") = DGridCond.Rows(0).Cells("col_marca").Value
                        Else
                            objDataRow.Item("marca") = Marca
                        End If
                        objDataRow.Item("nombre") = DGridContactos.Rows(i).Cells("col_nombre").Value.ToString
                        objDataRow.Item("puesto") = DGridContactos.Rows(i).Cells("col_puesto").Value.ToString
                        objDataRow.Item("email") = DGridContactos.Rows(i).Cells("col_email").Value.ToString
                        objDataRow.Item("telefono") = DGridContactos.Rows(i).Cells("col_telefono").Value.ToString
                        objDataRow.Item("extension") = DGridContactos.Rows(i).Cells("col_ext").Value.ToString
                        objDataRow.Item("celular") = DGridContactos.Rows(i).Cells("col_movil").Value.ToString
                        objDataRow.Item("nextel") = DGridContactos.Rows(i).Cells("col_nextel").Value.ToString
                        objDataRow.Item("ubicacion") = DGridContactos.Rows(i).Cells("col_ubicacion").Value.ToString
                        objDataRow.Item("idusuario") = GLB_Idempleado

                        'Add the DataRow to the DataSet
                        objDataSet.Tables(0).Rows.Add(objDataRow)

                        'Add the Project
                        If Not objCatalogoProveedores.usp_Captura_ContactosProv(Opcion, objDataSet) Then
                            'Throw New Exception("Falló Inserción de Proveedor")
                        Else
                            Inserta_Contactos = True
                        End If
                        objDataSet.Dispose()
                        objDataRow.Table.Dispose()
                        Inserta_Contactos = True
                    End Using
                Next
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function
    Private Function ValidarEdicion() As Boolean
        ValidarEdicion = False
        Try

            If Txt_RFC.Text.Length = 0 Then
                MsgBox("Debe especificar el RFC del Proveedor.", MsgBoxStyle.Critical, "Validación")
                Tbc_Proveedores.SelectedIndex = 0
                Txt_RFC.Focus()
                Exit Function
            End If

            If Cbo_TipoPago.Text.Length = 0 Then
                MsgBox("Debe especificar el TIPO DE PAGO del Proveedor.", MsgBoxStyle.Critical, "Validación")
                Tbc_Proveedores.SelectedIndex = 0
                Cbo_TipoPago.Focus()
                Exit Function
            End If



            If Txt_Raz_Soc.Text.Length = 0 Then
                MsgBox("Debe especificar la Razón Social del Proveedor.", MsgBoxStyle.Critical, "Validación")
                Tbc_Proveedores.SelectedIndex = 0
                Txt_Raz_Soc.Focus()
                Exit Function
            End If

            '' si se dejan vacias las columnas de descuentos en condiciones les asigna cero
            For i As Integer = 0 To DGridCond.Rows.Count - 1
                For n As Integer = 0 To DGridCond.Columns.Count - 1
                    If n = 4 Then
                        If DGridCond.Rows(i).Cells(n).Value Is Nothing Then
                            DGridCond.Rows(i).Cells(n).Value = 1
                        End If
                    End If
                    If n >= 6 Then
                        If DGridCond.Rows(i).Cells(n).Value Is Nothing Then
                            DGridCond.Rows(i).Cells(n).Value = 0
                        End If
                    End If
                Next
            Next

            '' valida que si el dsctopp es igual a cero, los demas no sean mayores a cero
            For i As Integer = 0 To DGridCond.Rows.Count - 1
                For n As Integer = 0 To DGridCond.Columns.Count - 1
                    If n = 6 Then
                        If DGridCond.Rows(i).Cells(n).Value = 0 Then
                            For k As Integer = i To i
                                For j As Integer = 6 To DGridCond.Columns.Count - 1
                                    If DGridCond.Rows(k).Cells(j).Value <> 0 Then
                                        MsgBox("No puede asignar descuentos en escala si el DsctoPP es igual a cero.", MsgBoxStyle.Critical, "Validación")
                                        Tbc_Proveedores.SelectedIndex = 1
                                        DGridCond.Focus()
                                        Exit Function
                                    End If
                                Next
                            Next
                        End If
                    End If
                Next
            Next


            If DGridContactos.Rows.Count - 1 >= 1 Then
                For i As Integer = 0 To DGridContactos.Rows.Count - 1
                    For n As Integer = 0 To DGridContactos.Columns.Count - 1
                        If DGridContactos.Rows(i).Cells(n).Value Is Nothing Then
                            DGridContactos.Rows(i).Cells(n).Value = " "
                        End If
                    Next
                Next

            End If



            For i As Integer = 0 To DGridCuentas.Rows.Count - 1
                For n As Integer = 0 To DGridCuentas.Columns.Count - 1
                    If DGridCuentas.Rows(i).Cells(n).Value Is Nothing Then
                        DGridCuentas.Rows(i).Cells(n).Value = " "
                    End If
                Next
            Next




            If DGridContactos.Rows.Count = 0 Then
                MsgBox("Debe ingresar al menos un contacto de proveedor.", MsgBoxStyle.Critical, "Validación")
                Tbc_Proveedores.SelectedIndex = 3
                DGridContactos.Focus()
                Exit Function
            End If

            ValidarEdicion = True
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Function

    ''Funciones Microsip
    Function Inserta_ProveedoresMicrosip(ByVal Opcion As Integer, ByVal Proveedor_Id As Integer, ByVal Cond_Pago_Id As Integer) As Boolean
        'mreyes 05/Marzo/2012 05:37 a.m.

        Using objMicrosip As New BCL.BCLMicrosip(GLB_ConStringMicrosip)
            'Get a new Project DataSet
            Try
                Dim objDataset As Data.DataSet
                Dim Estado_id As Integer = 0
                Dim Ciudad_id As Integer = 0


                Dim NombreEstado As String = ""
                Using objMicrosipE As New BCL.BCLMySqlGral(GLB_ConStringPerSis)
                    Dim objDatasetE As Data.DataSet
                    objDatasetE = objMicrosipE.usp_TraerDescripcion("E", Cbo_Estado.Text, "")
                    If objDatasetE.Tables(0).Rows.Count > 0 Then
                        ' ya existe 
                        NombreEstado = (objDatasetE.Tables(0).Rows(0).Item("campo").ToString)

                    End If
                End Using

                ' ir a buscar el valor de ciudad_id 
                Using objMicrosipE As New BCL.BCLMicrosip(GLB_ConStringMicrosip)
                    Dim objDatasetE As Data.DataSet
                    objDatasetE = objMicrosipE.usp_Traer_Estado(NombreEstado, Cbo_Estado.Text)
                    If objDatasetE.Tables(0).Rows.Count > 0 Then
                        ' ya existe 
                        Estado_id = Val(objDatasetE.Tables(0).Rows(0).Item(0).ToString)
                        If Estado_id = 0 Then
                            Estado_id = Gen_Id_Catalogos()
                            If Inserta_Estados(Estado_id, NombreEstado) = False Then

                            End If
                        End If
                    Else
                        '' dar de alta el estado... 
                        Estado_id = Gen_Id_Catalogos()
                        If Inserta_Estados(Estado_id, NombreEstado) = False Then

                        End If


                    End If
                End Using

                Using objMicrosipE As New BCL.BCLMicrosip(GLB_ConStringMicrosip)
                    Dim objDatasetE As Data.DataSet
                    objDatasetE = objMicrosipE.usp_Traer_Ciudad(Cbo_Ciudad.Text)
                    If objDatasetE.Tables(0).Rows.Count > 0 Then
                        ' ya existe 
                        Ciudad_id = Val(objDatasetE.Tables(0).Rows(0).Item(0).ToString)
                        If Ciudad_id = 0 Then
                            Ciudad_id = Gen_Id_Catalogos()
                            If Inserta_Ciudad(Ciudad_id, Estado_id) = False Then

                            End If
                        End If

                    Else
                        '' dar de alta el estado... 
                        Ciudad_id = Gen_Id_Catalogos()
                        If Inserta_Ciudad(Ciudad_id, Estado_id) = False Then

                        End If
                    End If
                End Using
                'Set the values in the DataRo
                objDataset = objMicrosip.Inserta_Proveedores    'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataset.Tables(0).NewRow

                If Proveedor_Id = 0 Then
                    Proveedor_Id = Gen_Id_Catalogos()
                End If

                If Cond_Pago_Id = 0 Then
                    Using objMicrosipE As New BCL.BCLMicrosip(GLB_ConStringMicrosip)
                        Dim objDatasetE As Data.DataSet

                        objDatasetE = objMicrosipE.usp_Traer_Condicion_Pago_CP(DGridCond.Rows(0).Cells("col_dsctopp").Value, DGridCond.Rows(0).Cells("col_diaspp").Value)
                        If objDatasetE.Tables(0).Rows.Count > 0 Then
                            ' ya existe 
                            Cond_Pago_Id = Val(objDatasetE.Tables(0).Rows(0).Item("cond_pago_idb").ToString)

                        End If
                    End Using
                End If
                If Cond_Pago_Id = 0 Then Cond_Pago_Id = 2931
                objDataRow.Item("proveedor_id") = Proveedor_Id
                objDataRow.Item("nombre") = Mid(Txt_Raz_Soc.Text, 1, 100)
                objDataRow.Item("contacto1") = ""
                objDataRow.Item("contacto2") = ""
                objDataRow.Item("calle") = Mid(Txt_Calle.Text, 1, 100)
                objDataRow.Item("nombre_calle") = Mid(Txt_Calle.Text, 1, 50)
                objDataRow.Item("num_exterior") = "0"
                objDataRow.Item("num_interior") = "0"
                objDataRow.Item("colonia") = Mid(Cbo_Colonia.Text, 1, 50)
                objDataRow.Item("referencia") = ""
                objDataRow.Item("ciudad_id") = Ciudad_id
                objDataRow.Item("estado_id") = Estado_id
                objDataRow.Item("codigo_postal") = Cbo_CodPos.Text
                objDataRow.Item("pais_id") = 316
                objDataRow.Item("telefono1") = Txt_Telef1.Text
                objDataRow.Item("telefono2") = Txt_Telef2.Text
                objDataRow.Item("fax") = Txt_Telef3.Text
                objDataRow.Item("email") = ""
                objDataRow.Item("rfc_curp") = Txt_RFC.Text
                objDataRow.Item("estatus") = "D"
                objDataRow.Item("causa_susp") = ""
                objDataRow.Item("carga_impuestos") = "S"
                objDataRow.Item("retener_impuestos") = "N"
                objDataRow.Item("extranjero") = "N"
                objDataRow.Item("limite_credito") = 50000
                objDataRow.Item("moneda_id") = 1
                objDataRow.Item("cond_pago_id") = Cond_Pago_Id
                objDataRow.Item("notas") = ""
                objDataRow.Item("cuenta_cxp") = "2101"
                objDataRow.Item("formatos_email") = ""
                objDataRow.Item("actividad_principal") = "85"
                objDataRow.Item("usuario_creador") = GLB_Usuario

                'Add the DataRow to the DataSet
                objDataset.Tables(0).Rows.Add(objDataRow)

                'Add the Project
                If Not objMicrosip.usp_Inserta_Proveedores(Opcion, objDataset) Then
                    ' Throw New Exception("Falló Inserción de Proveedores a Microsip")
                Else
                    Inserta_ProveedoresMicrosip = True
                End If

                If Opcion = 1 Then
                    If Inserta_Claves_Proveedores(Proveedor_Id) = False Then
                        Inserta_ProveedoresMicrosip = False
                    End If
                End If
                Inserta_ProveedoresMicrosip = True
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function
    Function Inserta_Libres_ProveedoresMicrosip(ByVal Opcion As Integer, ByVal Proveedor_Id As Integer) As Boolean
        'mreyes 05/Marzo/2012 05:37 a.m.

        Using objMicrosip As New BCL.BCLMicrosip(GLB_ConStringMicrosip)
            'Get a new Project DataSet
            Try
                Dim objDataset As Data.DataSet


                'Set the values in the DataRo
                objDataset = objMicrosip.Inserta_Libres_Proveedores     'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataset.Tables(0).NewRow

                objDataRow.Item("proveedor_id") = Proveedor_Id
                objDataRow.Item("marca") = Mid(DGridCond.Rows(0).Cells("col_marca").Value, 1, 20)
                'Add the DataRow to the DataSet
                objDataset.Tables(0).Rows.Add(objDataRow)

                'Add the Project
                If Not objMicrosip.usp_Inserta_Libres_Proveedores(Opcion, objDataset) Then
                    ' Throw New Exception("Falló Inserción de Proveedores a Microsip")
                Else
                    Inserta_Libres_ProveedoresMicrosip = True
                End If


                Inserta_Libres_ProveedoresMicrosip = True
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function
    Function Inserta_Estados(ByVal Estado_Id As Integer, ByVal NombreEstado As String) As Boolean
        'mreyes 05/Marzo/2012 06:22 p.m.

        Using objMicrosip As New BCL.BCLMicrosip(GLB_ConStringMicrosip)
            'Get a new Project DataSet
            Try
                Dim objDataset As Data.DataSet


                objDataset = objMicrosip.Inserta_Estados   'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataset.Tables(0).NewRow

                'Set the values in the DataRow
                objDataRow.Item("estado_id") = Estado_Id
                objDataRow.Item("nombre") = NombreEstado
                objDataRow.Item("nombre_abrev") = Cbo_Estado.Text
                objDataRow.Item("es_predet") = "N"
                objDataRow.Item("pais_id") = 316 'PAIS MÉXICO
                objDataRow.Item("usuario_creador") = GLB_Usuario

                'Add the DataRow to the DataSet
                objDataset.Tables(0).Rows.Add(objDataRow)

                'Add the Project
                If Not objMicrosip.usp_Inserta_Estados(1, objDataset) Then
                    '  Throw New Exception("Falló Inserción de Estados")
                Else
                    Inserta_Estados = True
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function
    Function Inserta_Ciudad(ByVal Ciudad_Id As Integer, ByVal Estado_Id As Integer) As Boolean
        'mreyes 05/Marzo/2012 06:34 p.m.

        Using objMicrosip As New BCL.BCLMicrosip(GLB_ConStringMicrosip)
            'Get a new Project DataSet
            Try
                Dim objDataset As Data.DataSet

                objDataset = objMicrosip.Inserta_Ciudad     'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataset.Tables(0).NewRow

                'Set the values in the DataRow
                objDataRow.Item("ciudad_id") = Ciudad_Id
                objDataRow.Item("nombre") = Cbo_Ciudad.Text
                objDataRow.Item("es_predet") = "N"
                objDataRow.Item("estado_id") = Estado_Id
                objDataRow.Item("usuario_creador") = GLB_Usuario
                'Add the DataRow to the DataSet
                objDataset.Tables(0).Rows.Add(objDataRow)

                'Add the Project
                If Not objMicrosip.usp_Inserta_Ciudades(1, objDataset) Then
                    ' Throw New Exception("Falló Inserción de Estados")
                Else
                    Inserta_Ciudad = True
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function
    Function Inserta_Claves_Proveedores(ByVal Proveedor_Id As Integer) As Boolean
        'mreyes 05/Marzo/2012 07:24 p.m.

        Using objMicrosip As New BCL.BCLMicrosip(GLB_ConStringMicrosip)
            'Get a new Project DataSet
            Try
                Dim objDataset As Data.DataSet

                objDataset = objMicrosip.Inserta_Claves_Proveedores     'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataset.Tables(0).NewRow
                '' ir a traer clave_prov_id 

                'Set the values in the DataRow
                objDataRow.Item("clave_prov_id") = Gen_Id_Catalogos()
                objDataRow.Item("clave_prov") = Txt_Proveedor.Text
                objDataRow.Item("proveedor_id") = Proveedor_Id
                objDataRow.Item("ROL_CLAVE_PROV_ID") = 49
                'Add the DataRow to the DataSet
                objDataset.Tables(0).Rows.Add(objDataRow)

                'Add the Project
                If Not objMicrosip.usp_Inserta_Claves_Proveedores(1, objDataset) Then
                    'Throw New Exception("Falló Inserción de Estados")
                Else
                    Inserta_Claves_Proveedores = True
                End If
                Inserta_Claves_Proveedores = True
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function
    Private Function Gen_Id_Catalogos() As Integer
        'mreyes 05/Marzo/2012 11:32 a.m.
        Try
            Dim objDataset As Data.DataSet
            Gen_Id_Catalogos = 0
            Using objMicrosip As New BCL.BCLMicrosip(GLB_ConStringMicrosip)
                objDataset = objMicrosip.usp_Gen_Catalogo_Id()
                If objDataset.Tables(0).Rows.Count > 0 Then
                    Gen_Id_Catalogos = Val(objDataset.Tables(0).Rows(0).Item(0).ToString)

                Else
                    Gen_Id_Catalogos = 1
                End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function
    ''
#End Region
#Region "Métodos"
    Private Sub CambiarArchivo(ByVal RutaOrigen As String, ByVal RutaDestino As String)
        Dim Extension As String = ""
        Try
            Dim g As GBITMAPLib.GBitmap
            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)
                Extension = objIO.pub_ExtensionArchivo(RutaOrigen)
                g = New GBITMAPLib.GBitmap
                If UCase(Extension) = ".BMP" Then
                    g.LoadFileBmp(RutaOrigen)
                Else
                    g.LoadFileJpg(RutaOrigen, 360)
                End If
                'g.Resize(320, 240)
                g.SaveFileJpg(RutaDestino)
                g = Nothing
            End Using
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

                    Txt_Proveedor.BackColor = TextboxBackColor

                    EdicionComponentesReadOnly()

                    Btn_Adjuntar.Enabled = False

                    Cbo_PaqueteriaDev.Enabled = False
                    Rb_LibreADev.Enabled = False
                    Rb_PorCobrarDev.Enabled = False

                    DGridCond.AllowUserToAddRows = False
                    DGridCuentas.AllowUserToAddRows = False
                    DGridContactos.AllowUserToAddRows = False

                Case 1, 2
                    Btn_Aceptar.Enabled = True
                    Btn_Cancelar.Enabled = True
                    Btn_Nuevo.Enabled = False
                    Btn_Editar.Enabled = False

                    If Accion = 1 Then
                        Txt_Proveedor.Focus()
                        Pnl_Ed3.Enabled = False
                        Cbo_EstadoD.Text = ""
                        'DGridCond.AllowUserToAddRows = False
                    ElseIf Accion = 2 Then
                        Txt_Raz_Soc.Focus()
                        Txt_Proveedor.Enabled = False
                        Txt_Raz_Soc.Enabled = False
                        Txt_Proveedor.BackColor = TextboxBackColor
                        Txt_Raz_Soc.BackColor = TextboxBackColor
                    End If
            End Select
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub EdicionComponentesReadOnly()

        For Each obj As Object In Pnl_Ed1.Controls
            Dim tb As New TextBox
            Dim cb As New ComboBox
            Dim ch As New CheckBox
            Dim rb As New RadioButton
            If obj.GetType Is tb.GetType Then
                tb = obj
                tb.ReadOnly = True
                tb.BackColor = TextboxBackColor
            End If
            If obj.GetType Is cb.GetType Then
                cb = obj
                cb.Enabled = False
                cb.BackColor = TextboxBackColor
            End If
        Next

        For Each obj As Object In Pnl_Ed2.Controls
            Dim tb As New TextBox
            Dim cb As New ComboBox
            Dim ch As New CheckBox
            Dim rb As New RadioButton
            If obj.GetType Is tb.GetType Then
                tb = obj
                tb.ReadOnly = True
                tb.BackColor = TextboxBackColor
            End If
            'If obj.GetType Is cb.GetType Then
            '    cb = obj
            '    cb.Enabled = False
            '    cb.BackColor = TextboxBackColor
            'End If
            If obj.GetType Is ch.GetType Then
                ch = obj
                ch.Enabled = False
                ch.BackColor = TextboxBackColor
            End If
            If obj.GetType Is rb.GetType Then
                rb = obj
                rb.Enabled = False
            End If
        Next

        For Each obj As Object In GB_Transporte.Controls
            Dim tb As New TextBox
            Dim rb As New RadioButton
            Dim cb As New ComboBox
            If obj.GetType Is tb.GetType Then
                tb = obj
                tb.ReadOnly = True
                tb.BackColor = TextboxBackColor
            End If

            If obj.GetType Is cb.GetType Then
                cb = obj
                cb.Enabled = False
                cb.BackColor = TextboxBackColor
            End If

            If obj.GetType Is rb.GetType Then
                rb = obj
                rb.Enabled = False
            End If
        Next

        For Each obj As Object In Tp_Condiciones.Controls
            Dim tb As New TextBox
            Dim gr As New DataGridView
            Dim ch As New CheckBox
            Dim rb As New RadioButton
            If obj.GetType Is tb.GetType Then
                tb = obj
                tb.ReadOnly = True
                tb.BackColor = TextboxBackColor
            End If

            If obj.GetType Is rb.GetType Then
                rb = obj
                rb.Enabled = False
            End If

            If obj.GetType Is gr.GetType Then
                gr = obj
                gr.ReadOnly = True
            End If

            If obj.GetType Is ch.GetType Then
                ch = obj
                ch.Enabled = False
                ch.BackColor = TextboxBackColor
            End If
        Next

        For Each obj As Object In GB_TransporteD.Controls
            Dim tb As New TextBox
            If obj.GetType Is tb.GetType Then
                tb = obj
                tb.ReadOnly = True
                tb.BackColor = TextboxBackColor
            End If
        Next

        For Each obj As Object In GB_CondicionesGrales.Controls
            Dim tb As New TextBox
            If obj.GetType Is tb.GetType Then
                tb = obj
                tb.ReadOnly = True
                tb.BackColor = TextboxBackColor
            End If
        Next

        For Each obj As Object In GB_Condiciones.Controls
            Dim tb As New TextBox
            If obj.GetType Is tb.GetType Then
                tb = obj
                tb.ReadOnly = True
                tb.BackColor = TextboxBackColor
            End If
        Next

        For Each obj As Object In GB_Contacto.Controls
            Dim tb As New TextBox
            Dim ch As New CheckBox
            Dim cb As New ComboBox
            If obj.GetType Is tb.GetType Then
                tb = obj
                tb.ReadOnly = True
                tb.BackColor = TextboxBackColor
            End If

            If obj.GetType Is cb.GetType Then
                cb = obj
                cb.Enabled = False
                cb.BackColor = TextboxBackColor
            End If

            If obj.GetType Is ch.GetType Then
                ch = obj
                ch.Enabled = False
            End If
        Next

        For Each obj As Object In GB_Cuentas.Controls
            Dim gr As New DataGridView
            If obj.GetType Is gr.GetType Then
                gr = obj
                gr.ReadOnly = True
            End If
        Next

        For Each obj As Object In Pnl_Ed4.Controls
            Dim gr As New DataGridView
            If obj.GetType Is gr.GetType Then
                gr = obj
                gr.ReadOnly = True
            End If
        Next

        For Each obj As Object In Pnl_Ed3.Controls
            Dim rb As New RadioButton
            If obj.GetType Is rb.GetType Then
                rb = obj
                rb.Enabled = False
            End If
        Next
    End Sub
    Private Sub CargaComboMarcas(ByVal Num As Integer)
        Try
            Cbo_MarcaCond.Items.Clear()
            Cbo_MarcaCont.Items.Clear()
            Cbo_MarcaDev.Items.Clear()
            'Cbo_MarcaCond.Items.Add("SELECCIONAR...")

            Dim Marca(Num - 1) As String

            For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                Marca(i) = objDataSet.Tables(0).Rows(i).Item("descrip")
            Next

            'Array.Sort(Marca)
            Cbo_MarcaCond.Items.AddRange(Marca)
            Cbo_MarcaCont.Items.AddRange(Marca)
            Cbo_MarcaDev.Items.AddRange(Marca)
            'Cbo_TipoAct.SelectedIndex = 0
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub usp_TraerIdProveedor()
        Using objCatalogoProveedores As New BCL.BCLCatalogoProveedoresN(GLB_ConStringCipSis)
            Try
                objDataSet = objCatalogoProveedores.usp_TraerIdProveedor(Txt_Proveedor.Text)

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_IdProveedor.Text = objDataSet.Tables(0).Rows(0).Item("idproveedor").ToString
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub
    Private Sub usp_TraerProveedor()
        Using objCatalogoProveedores As New BCL.BCLCatalogoProveedoresN(GLB_ConStringCipSis)
            Try

                objDataSet = objCatalogoProveedores.usp_TraerProveedorN(Val(Txt_IdProveedor.Text))
                If objDataSet.Tables(0).Rows.Count > 0 Then

                    Txt_Proveedor.Text = objDataSet.Tables(0).Rows(0).Item("proveedor").ToString
                    Txt_Raz_Soc.Text = objDataSet.Tables(0).Rows(0).Item("raz_soc").ToString
                    Txt_RFC.Text = objDataSet.Tables(0).Rows(0).Item("rfc").ToString
                    Txt_Calle.Text = objDataSet.Tables(0).Rows(0).Item("calle").ToString
                    Cbo_Colonia.Text = objDataSet.Tables(0).Rows(0).Item("colonia").ToString
                    Cbo_Ciudad.Text = objDataSet.Tables(0).Rows(0).Item("ciudad").ToString
                    Cbo_Estado.Text = objDataSet.Tables(0).Rows(0).Item("estado").ToString
                    Cbo_CodPos.Text = objDataSet.Tables(0).Rows(0).Item("codpos").ToString
                    Txt_Telef1.Text = objDataSet.Tables(0).Rows(0).Item("telef1").ToString
                    Txt_Telef2.Text = objDataSet.Tables(0).Rows(0).Item("telef2").ToString
                    Txt_Telef3.Text = objDataSet.Tables(0).Rows(0).Item("telef3").ToString
                    Txt_SitioWeb.Text = objDataSet.Tables(0).Rows(0).Item("web").ToString
                    Txt_Usuario.Text = objDataSet.Tables(0).Rows(0).Item("usuario").ToString
                    Txt_Contraseña.Text = objDataSet.Tables(0).Rows(0).Item("password").ToString
                    Cbo_Paqueteria.Text = objDataSet.Tables(0).Rows(0).Item("paqueteria").ToString
                    Txt_ConvenioGral.Text = objDataSet.Tables(0).Rows(0).Item("convenio").ToString

                    Cbo_TipoCobro.Text = objDataSet.Tables(0).Rows(0).Item("tipopag").ToString

                    If objDataSet.Tables(0).Rows(0).Item("porcobrar") = "1" Then
                        Rb_PorCobrar.Checked = True
                        Cbo_TipoCobro.Text = objDataSet.Tables(0).Rows(0).Item("tipopag").ToString
                    ElseIf objDataSet.Tables(0).Rows(0).Item("librea") = "1" Then
                        Rb_LibreA.Checked = True
                    End If

                    If objDataSet.Tables(0).Rows(0).Item("status").ToString = "AC" Then
                        Cbo_Estatus.Text = "ACTIVO"
                    ElseIf objDataSet.Tables(0).Rows(0).Item("status").ToString = "BA" Then
                        Cbo_Estatus.Text = "BAJA"
                    ElseIf objDataSet.Tables(0).Rows(0).Item("status").ToString = "SU" Then
                        Cbo_Estatus.Text = "SUSPENDIDO"
                    End If

                    Txt_MotivoEstatus.Text = objDataSet.Tables(0).Rows(0).Item("motivo").ToString


                    Txt_Dsctopp.Text = objDataSet.Tables(0).Rows(0).Item("dsctopp").ToString
                    Txt_Diaspp.Text = Val(objDataSet.Tables(0).Rows(0).Item("diaspp").ToString)
                    Txt_Dscto01.Text = objDataSet.Tables(0).Rows(0).Item("dscto01").ToString
                    Txt_Dscto02.Text = objDataSet.Tables(0).Rows(0).Item("dscto02").ToString
                    Txt_Dscto03.Text = objDataSet.Tables(0).Rows(0).Item("dscto03").ToString
                    Txt_Dscto04.Text = objDataSet.Tables(0).Rows(0).Item("dscto04").ToString
                    Txt_Dscto05.Text = objDataSet.Tables(0).Rows(0).Item("dscto05").ToString

                    Cbo_Tipo.Text = objDataSet.Tables(0).Rows(0).Item("tipo").ToString
                    Cbo_TipoPago.Text = objDataSet.Tables(0).Rows(0).Item("tipopago").ToString

                    If objDataSet.Tables(0).Rows(0).Item("aceptafactoraje").ToString = 1 Then
                        Chk_Factoraje.Checked = True
                        Pnl_Factoraje.Enabled = True

                    Else
                        Chk_Factoraje.Checked = False
                        Pnl_Factoraje.Enabled = False
                    End If

                    Txt_FechaFactoraje.Text = Format(objDataSet.Tables(0).Rows(0).Item("fechafactoraje"), "dd-MMM-yyyy")

                    Cbo_BancoFactoraje.Text = objDataSet.Tables(0).Rows(0).Item("bancofactoraje").ToString
                    idbancofactoraje = objDataSet.Tables(0).Rows(0).Item("idbancofactoraje")

                    'For I As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1

                    '    DGridCond.Rows.Add("", "", "", "", objDataSet.Tables(0).Rows(I).Item("diaspp").ToString, _
                    '                       objDataSet.Tables(0).Rows(I).Item("dsctopp").ToString, _
                    '                     objDataSet.Tables(0).Rows(I).Item("dscto01").ToString, _
                    '                     objDataSet.Tables(0).Rows(I).Item("dscto02").ToString, _
                    '                     objDataSet.Tables(0).Rows(I).Item("dscto03").ToString, _
                    '                     objDataSet.Tables(0).Rows(I).Item("dscto04").ToString, _
                    '                     objDataSet.Tables(0).Rows(I).Item("dscto05"))
                    'Next

                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub
    Private Sub usp_TraerCondicionesProv()
        Dim TipoPago As String = ""
        Dim NumMarcas As Integer = 0
        Using objCatalogoProveedores As New BCL.BCLCatalogoProveedoresN(GLB_ConStringCipSis)
            Try

                If blnPrimero = False Then
                    objDataSet = objCatalogoProveedores.usp_TraerCondicionesProv(Val(Txt_IdProveedor.Text), "")
                Else
                    objDataSet = objCatalogoProveedores.usp_TraerCondicionesProv(Val(Txt_IdProveedor.Text), Marca)
                End If

                If objDataSet.Tables(0).Rows.Count > 0 Then


                    If blnPrimero = False Then
                        Marca = objDataSet.Tables(0).Rows(0).Item("marca")
                        MarcaSeleccionada = Marca

                        NumMarcas = objDataSet.Tables(0).Rows.Count
                        If NumMarcas > 0 Then
                            Call CargaComboMarcas(NumMarcas)
                        End If


                        Cbo_MarcaCond.SelectedIndex = 0
                        Cbo_MarcaCont.SelectedIndex = 0
                        Cbo_MarcaDev.SelectedIndex = 0
                        'Lbl_MarcaC.Text = "Marca: " + Marca
                        'Lbl_MarcaD.Text = "Marca: " + Marca
                        'Lbl_MarcaCont.Text = "Marca: " + Marca

                    End If


                    If objDataSet.Tables(0).Rows(0).Item("basevenc") = "R" Then
                        RB_FecReci.Checked = True
                    ElseIf objDataSet.Tables(0).Rows(0).Item("basevenc") = "F" Then
                        RB_FecFact.Checked = True
                    End If

                    If objDataSet.Tables(0).Rows(0).Item("dsctofact") = "1" Then
                        Chk_DesctoFact.Checked = True
                    Else
                        Chk_DesctoFact.Checked = False
                    End If


                    If objDataSet.Tables(0).Rows(0).Item("rprov") = "1" Then
                        Chk_RProv.Checked = True
                    Else
                        Chk_RProv.Checked = False
                    End If

                    If objDataSet.Tables(0).Rows(0).Item("costeopv") = "1" Then
                        Chk_Costeo.Checked = True
                    Else
                        Chk_Costeo.Checked = False
                    End If

                    If objDataSet.Tables(0).Rows(0).Item("aceptadev") = "1" Then
                        Chk_AceptaDev.Checked = True
                    Else
                        Pnl_Ed3.Enabled = False
                    End If


                    If objDataSet.Tables(0).Rows(0).Item("consignacion") = "1" Then
                        Chk_Consignacion.Checked = True
                        Txt_PlazoC.Visible = True
                        Lbl_Plazo.Visible = True
                        Txt_Condicion.Visible = True
                        Lbl_Condicion.Visible = True
                        Txt_PlazoC.Text = objDataSet.Tables(0).Rows(0).Item("plazo").ToString
                        Txt_Condicion.Text = objDataSet.Tables(0).Rows(0).Item("condicion").ToString
                    End If

                    For I As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                        If objDataSet.Tables(0).Rows(I).Item("marca").ToString <> "" Then
                            If objDataSet.Tables(0).Rows(I).Item("tipopago").ToString = "Q" Then
                                TipoPago = "QUINCENAL"
                            ElseIf objDataSet.Tables(0).Rows(I).Item("tipopago").ToString = "S" Then
                                TipoPago = "SEMANAL"
                            ElseIf objDataSet.Tables(0).Rows(I).Item("tipopago").ToString = "U" Then
                                TipoPago = "UNA SOLA EXHIBICION"
                            End If


                            If blnPrimero = False Then
                                DGridCond.Rows.Add(objDataSet.Tables(0).Rows(I).Item("idcondicion").ToString, _
                                               objDataSet.Tables(0).Rows(I).Item("marca").ToString, _
                                               objDataSet.Tables(0).Rows(I).Item("factorc").ToString, _
                                               TipoPago, _
                                               Format(objDataSet.Tables(0).Rows(I).Item("vigencia"), "dd-MMM-yyyy"), _
                                               objDataSet.Tables(0).Rows(I).Item("numpagos").ToString, _
                                               objDataSet.Tables(0).Rows(I).Item("diaspp").ToString, _
                                               objDataSet.Tables(0).Rows(I).Item("dsctopp").ToString, _
                                             objDataSet.Tables(0).Rows(I).Item("dscto01").ToString, _
                                             objDataSet.Tables(0).Rows(I).Item("dscto02").ToString, _
                                             objDataSet.Tables(0).Rows(I).Item("dscto03").ToString, _
                                             objDataSet.Tables(0).Rows(I).Item("dscto04").ToString, _
                                             objDataSet.Tables(0).Rows(I).Item("dscto05").ToString, _
                                IIf(objDataSet.Tables(0).Rows(I).Item("rprov") = "1", True, False), _
                                IIf(objDataSet.Tables(0).Rows(I).Item("factrem") = "1", True, False))

                            End If

                        End If
                    Next
                    blnPrimero = True
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub
    Private Sub usp_TraerCuentasProv()
        Using objCatalogoProveedores As New BCL.BCLCatalogoProveedoresN(GLB_ConStringCipSis)
            Try

                objDataSet = objCatalogoProveedores.usp_TraerCuentasProv(Val(Txt_IdProveedor.Text))

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    For I As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1

                        DGridCuentas.Rows.Add(objDataSet.Tables(0).Rows(I).Item("idcuenta").ToString, _
                                              objDataSet.Tables(0).Rows(I).Item("plaza").ToString, _
                                         objDataSet.Tables(0).Rows(I).Item("banco").ToString, _
                                         objDataSet.Tables(0).Rows(I).Item("sucursal").ToString, _
                                         objDataSet.Tables(0).Rows(I).Item("clabe").ToString, _
                                         objDataSet.Tables(0).Rows(I).Item("referencia").ToString, _
                                         objDataSet.Tables(0).Rows(I).Item("cuenta"))
                    Next
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub
    Private Sub usp_TraerDevolucionesProv()
        Using objCatalogoProveedores As New BCL.BCLCatalogoProveedoresN(GLB_ConStringCipSis)
            Try

                If Chk_AceptaDev.Checked = True Then
                    objDataSet = objCatalogoProveedores.usp_TraerDevolucionesProv(Val(Txt_IdProveedor.Text), Marca)
                    If objDataSet.Tables(0).Rows.Count > 0 Then

                        If objDataSet.Tables(0).Rows(0).Item("tipodev") = "S" Then
                            RB_Saldo.Checked = True
                        ElseIf objDataSet.Tables(0).Rows(0).Item("tipodev") = "F" Then
                            RB_Factura.Checked = True
                        End If

                        Txt_PlazoDev.Text = objDataSet.Tables(0).Rows(0).Item("plazo").ToString
                        Txt_ParMin.Text = objDataSet.Tables(0).Rows(0).Item("paresmin").ToString
                        Txt_ImpMin.Text = Format(Val(objDataSet.Tables(0).Rows(0).Item("impmin")), "$###,##0.00")
                        Txt_ProcedimDev.Text = objDataSet.Tables(0).Rows(0).Item("procedimd").ToString
                        Txt_ContactoDev.Text = objDataSet.Tables(0).Rows(0).Item("contacto").ToString
                        Txt_CalleDev.Text = objDataSet.Tables(0).Rows(0).Item("calle").ToString
                        Cbo_ColoniaD.Text = objDataSet.Tables(0).Rows(0).Item("colonia").ToString
                        Cbo_CiudadD.Text = objDataSet.Tables(0).Rows(0).Item("ciudad").ToString
                        Cbo_EstadoD.Text = objDataSet.Tables(0).Rows(0).Item("estado").ToString
                        Cbo_CodPosD.Text = objDataSet.Tables(0).Rows(0).Item("codpos").ToString
                        Txt_Tel1Dev.Text = objDataSet.Tables(0).Rows(0).Item("telef1").ToString
                        Txt_Tel2Dev.Text = objDataSet.Tables(0).Rows(0).Item("telef2").ToString
                        Txt_CorreoDev.Text = objDataSet.Tables(0).Rows(0).Item("email").ToString

                        If objDataSet.Tables(0).Rows(0).Item("viaemail") = "S" Then
                            Chk_DevCorreo.Checked = True
                        ElseIf objDataSet.Tables(0).Rows(0).Item("tipodev") = "N" Then
                            Chk_DevCorreo.Checked = False
                        End If

                        Cbo_PaqueteriaDev.Text = objDataSet.Tables(0).Rows(0).Item("paqueteria").ToString
                        Txt_ConvenioDev.Text = objDataSet.Tables(0).Rows(0).Item("convenio").ToString
                        Cbo_TipoCobroDev.Text = objDataSet.Tables(0).Rows(0).Item("tipopag").ToString

                        If objDataSet.Tables(0).Rows(0).Item("porcobrar") = "1" Then
                            Rb_PorCobrarDev.Checked = True
                            Cbo_TipoCobroDev.Text = objDataSet.Tables(0).Rows(0).Item("tipopag").ToString
                        ElseIf objDataSet.Tables(0).Rows(0).Item("librea") = "1" Then
                            Rb_LibreADev.Checked = True
                        End If
                        Txt_ProcedimPaq.Text = objDataSet.Tables(0).Rows(0).Item("procedimp").ToString
                    End If
                End If
                
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub
    Private Sub usp_TraerContactosProv()
        Using objCatalogoProveedores As New BCL.BCLCatalogoProveedoresN(GLB_ConStringCipSis)
            Try
                objDataSet = objCatalogoProveedores.usp_TraerContactosProv(Val(Txt_IdProveedor.Text), Marca)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    For I As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1

                        DGridContactos.Rows.Add(objDataSet.Tables(0).Rows(I).Item("idcontacto").ToString, _
                                        objDataSet.Tables(0).Rows(I).Item("nombre").ToString, _
                                         objDataSet.Tables(0).Rows(I).Item("puesto").ToString, _
                                         objDataSet.Tables(0).Rows(I).Item("email").ToString, _
                                         objDataSet.Tables(0).Rows(I).Item("telefono").ToString, _
                                         objDataSet.Tables(0).Rows(I).Item("extension").ToString, _
                                         objDataSet.Tables(0).Rows(I).Item("celular"), _
                                         objDataSet.Tables(0).Rows(I).Item("nextel").ToString, _
                                         objDataSet.Tables(0).Rows(I).Item("ubicacion"))
                    Next
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub
    Private Sub usp_TraerPaqueterias()
        Using objCatalogoProveedores As New BCL.BCLCatalogoProveedoresN(GLB_ConStringCipSis)
            Try
                objDataSet = objCatalogoProveedores.usp_TraerPaqueterias()
                If objDataSet.Tables(0).Rows.Count > 0 Then

                    Cbo_Paqueteria.DataSource = objDataSet.Tables(0).DefaultView
                    Cbo_PaqueteriaDev.DataSource = objDataSet.Tables(0).DefaultView

                    Cbo_Paqueteria.DisplayMember = "transporte"
                    Cbo_Paqueteria.ValueMember = "transporte"

                    Cbo_PaqueteriaDev.DisplayMember = "transporte"
                    Cbo_PaqueteriaDev.ValueMember = "transporte"

                    Cbo_Paqueteria.Text = ""
                    Cbo_PaqueteriaDev.Text = ""
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

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub LimpiarDatos()
        Try

            Txt_Proveedor.Text = ""

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub
    Private Sub TxtLostfocus(ByVal Txt_Campo As String, ByVal Tipo As String)
        Dim myForm As New frmConsulta

        'If Txt_Campo.Length = 0 Then Exit Sub

        Try
            Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
                objDataSet = objMySqlGral.usp_TraerDescripcion(Tipo, Txt_Campo, "")
            End Using

            If objDataSet.Tables(0).Rows.Count > 0 Then
                'Txt_Campo = objDataSet.Tables(0).Rows(0).Item("campo").ToString

                Using objMarca As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                    Dim objDataSet As Data.DataSet

                    objDataSet = objMarca.usp_TraerMarca(Txt_Campo, "")

                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        DGridCond.CurrentRow.Cells.Item("col_factor").Value = objDataSet.Tables(0).Rows(0).Item("factor").ToString
                    Else
                        DGridCond.CurrentRow.Cells.Item("col_factor").Value = "0"
                    End If
                End Using
            Else
                Txt_Campo = ""
                myForm.Tipo = Tipo
                myForm.ShowDialog()
                Txt_Campo = myForm.Campo

                If Txt_Campo.Length = 0 Then
                Else
                    DGridCond.CurrentRow.Cells.Item("col_marca").Value = myForm.Campo

                    Using objMarca As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                        Dim objDataSet As Data.DataSet

                        objDataSet = objMarca.usp_TraerMarca(Txt_Campo, "")

                        If objDataSet.Tables(0).Rows.Count > 0 Then
                            DGridCond.CurrentRow.Cells.Item("col_factor").Value = objDataSet.Tables(0).Rows(0).Item("factor").ToString
                        Else
                            DGridCond.CurrentRow.Cells.Item("col_factor").Value = "0"
                        End If
                    End Using

                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub TxtLostfocus(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Sql As String, ByVal Tipo As String)
        Dim myForm As New frmConsulta

        If Txt_Campo.Text.Length = 0 Then Exit Sub
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
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
    Private Sub validar_KeypressCond(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        '' FUNCION PARA SOLO ESCRIBIR LETRAS EN UN DATAGRID 
        Try
            ' obtener indice de la columna  
            If Accion = 3 Or Accion = 4 Then
                e.KeyChar = Chr(0)
                Exit Sub
            End If

            e.KeyChar = UCase(e.KeyChar)
            Dim columna As Integer = DGridCond.CurrentCell.ColumnIndex
            Dim renglon As Integer = DGridCond.CurrentRow.Index

            Dim caracter As Char = e.KeyChar
            ' comprobar si la celda en edición corresponde a la columna 1 o 3   


            'If renglon = 0 AndAlso columna = 1 Then
            '    e.KeyChar = Chr(0)
            '    Exit Sub
            'End If
            'If renglon = 0 AndAlso columna = 2 Then
            '    e.KeyChar = Chr(0)
            '    Exit Sub
            'End If
            'If renglon = 0 AndAlso columna = 3 Then
            '    e.KeyChar = Chr(0)
            '    Exit Sub
            'End If

            If columna = 1 Then
                e.KeyChar = UCase(caracter)
            End If

            If columna = 3 Then

                If DGridCond.CurrentCell.Value <> Nothing Then
                    'If DGridCond.CurrentCell.Value.ToString.Length = 0 Then
                    If caracter = "Q" Then
                        DGridCond.CurrentCell.Value = "QUINCENAL"
                    ElseIf caracter = "S" Then
                        DGridCond.CurrentCell.Value = "SEMANAL"
                    ElseIf caracter = "U" Then
                        DGridCond.CurrentCell.Value = "UNA SOLA EXHIBICION"
                    End If
                    'e.KeyChar = UCase(caracter)
                    'End If

                Else

                    If caracter = "Q" Then
                        DGridCond.CurrentCell.Value = "QUINCENAL"
                    ElseIf caracter = "S" Then
                        DGridCond.CurrentCell.Value = "SEMANAL"
                    ElseIf caracter = "U" Then
                        DGridCond.CurrentCell.Value = "UNA SOLA EXHIBICION"
                    End If
                    'e.KeyChar = UCase(caracter)

                End If


            End If

            If columna = 2 Then
                If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False And Not (caracter = ".") Then
                    e.KeyChar = Chr(0)
                End If
            End If

            If columna >= 5 Then
                If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False And Not (caracter = ".") Then
                    e.KeyChar = Chr(0)
                End If
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub validar_KeypressCuentas(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        '' FUNCION PARA SOLO ESCRIBIR LETRAS EN UN DATAGRID 
        Try
            ' obtener indice de la columna  
            If Accion = 3 Or Accion = 4 Then
                e.KeyChar = Chr(0)
                Exit Sub
            End If
            'e.KeyChar = UCase(e.KeyChar)
            Dim columna As Integer = DGridCuentas.CurrentCell.ColumnIndex
            Dim caracter As Char = e.KeyChar
            ' comprobar si la celda en edición corresponde a la columna 1 o 3   

            If columna = 1 Or columna = 2 Or columna = 3 Or columna = 5 Then
                e.KeyChar = UCase(caracter)
            End If


            If columna = 4 Or columna = 6 Then

                If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False And Not (caracter = ".") Then
                    e.KeyChar = Chr(0)
                End If
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub validar_KeypressContactos(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        '' FUNCION PARA SOLO ESCRIBIR LETRAS EN UN DATAGRID 
        Try
            ' obtener indice de la columna  
            If Accion = 3 Or Accion = 4 Then
                e.KeyChar = Chr(0)
                Exit Sub
            End If
            'e.KeyChar = UCase(e.KeyChar)
            Dim columna As Integer = DGridContactos.CurrentCell.ColumnIndex
            Dim caracter As Char = e.KeyChar


            If columna = 1 Or columna = 2 Or columna = 6 Then
                e.KeyChar = UCase(caracter)
            End If


            If columna >= 4 And columna <= 5 Then

                If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False And Not (caracter = ".") Then
                    e.KeyChar = Chr(0)
                End If
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub LimpiarControlesNuevaMarca()
        ''condiciones
        Chk_AceptaDev.Checked = False
        Chk_Consignacion.Checked = False
        Chk_DesctoFact.Checked = False
        Chk_RProv.Checked = False
        Chk_Costeo.Checked = False
        Txt_PlazoC.Text = ""
        Txt_Condicion.Text = ""

        'devoluciones
        
        Txt_ParMin.Text = ""
        Txt_ImpMin.Text = ""
        Txt_PlazoDev.Text = ""
        Txt_ProcedimDev.Text = ""
        Txt_ContactoDev.Text = ""
        Txt_Tel1Dev.Text = ""
        Txt_Tel2Dev.Text = ""
        Cbo_EstadoD.Text = ""
        Cbo_CiudadD.Text = ""
        Cbo_CodPosD.Text = ""
        Cbo_ColoniaD.Text = ""
        Txt_CalleDev.Text = ""
        Chk_DevCorreo.Checked = False
        Txt_CorreoDev.Text = ""
        Cbo_PaqueteriaDev.Text = ""
        Txt_ConvenioDev.Text = ""
        Cbo_TipoCobroDev.Text = ""
        Rb_PorCobrarDev.Checked = False
        Rb_LibreADev.Checked = False
        Txt_ProcedimPaq.Text = ""

        Pnl_Ed3.Enabled = False

        'contactos
        DGridContactos.Rows.Clear()


    End Sub
#End Region
#Region "Eventos de la Forma"
    Private Sub Txt_RFC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_RFC.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Txt_RFC_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_RFC.LostFocus
        If Txt_RFC.Text = "" Then Exit Sub
        Try

            If Accion = 1 Then
                Using objProv As New BCL.BCLCatalogoProveedores(GLB_ConStringCipSis)
                    objDataSet = objProv.usp_ExisteProveedor("", Txt_RFC.Text)
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        MessageBox.Show("El proveedor con el RFC '" & Txt_RFC.Text & "' ya existe con la Razón Social '" & objDataSet.Tables(0).Rows(0).Item("raz_soc").ToString & "'!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Txt_Raz_Soc.Text = ""
                        Txt_RFC.Text = ""
                        Txt_RFC.Focus()
                    End If
                End Using
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Txt_Raz_Soc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Raz_Soc.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Txt_Raz_Soc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Raz_Soc.LostFocus
        If Txt_Raz_Soc.Text = "" Then Exit Sub
        Try
            If Accion = 1 Then
                Using objProv As New BCL.BCLCatalogoProveedores(GLB_ConStringCipSis)
                    objDataSet = objProv.usp_ExisteProveedor(Txt_Raz_Soc.Text, "")
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        MessageBox.Show("El proveedor con la Razón Social '" & Txt_Raz_Soc.Text & "' ya existe!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Txt_Raz_Soc.Text = ""
                        Txt_RFC.Text = ""
                        Txt_Raz_Soc.Focus()
                    End If
                End Using
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Cbo_Estado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cbo_Estado.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Cbo_Estado_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cbo_Estado.LostFocus
        Call RellenaCombos(Cbo_Ciudad, "CIUDAD", " WHERE estado = '" & Cbo_Estado.Text & "'", GLB_ConStringPerSis, True)
    End Sub
    Private Sub Cbo_EstadoD_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cbo_EstadoD.LostFocus
        Call RellenaCombos(Cbo_CiudadD, "CIUDAD", " WHERE estado = '" & Cbo_EstadoD.Text & "'", GLB_ConStringPerSis, True)
    End Sub
    Private Sub Cbo_Estado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo_Estado.SelectedIndexChanged

    End Sub
    Private Sub Cbo_Ciudad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cbo_Ciudad.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Cbo_CiudadD_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cbo_CiudadD.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Cbo_Ciudad_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cbo_Ciudad.LostFocus
        Call RellenaCombos(Cbo_CodPos, "CPOSTAL", " WHERE ciudad = '" & Cbo_Ciudad.Text & "'", GLB_ConStringPerSis, True)
    End Sub
    Private Sub Cbo_CiudadD_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cbo_CiudadD.LostFocus
        Call RellenaCombos(Cbo_CodPosD, "CPOSTAL", " WHERE ciudad = '" & Cbo_CiudadD.Text & "'", GLB_ConStringPerSis, True)
    End Sub
    Private Sub Cbo_CodPos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cbo_CodPos.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Cbo_CodPosD_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cbo_CodPosD.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Cbo_CodPos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cbo_CodPos.LostFocus
        Call RellenaCombos(Cbo_Colonia, "COLONIA", " WHERE codpos = '" & Cbo_CodPos.Text & "'", GLB_ConStringPerSis, True)
    End Sub
    Private Sub Cbo_CodPosD_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cbo_CodPosD.LostFocus
        Call RellenaCombos(Cbo_ColoniaD, "COLONIA", " WHERE codpos = '" & Cbo_CodPosD.Text & "'", GLB_ConStringPerSis, True)
    End Sub
    Private Sub Cbo_Colonia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cbo_Colonia.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Cbo_ColoniaD_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cbo_ColoniaD.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Txt_Calle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Calle.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Txt_Telef1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Telef1.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Txt_Telef2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Telef2.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Txt_Fax_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Telef3.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Rb_PorCobrar_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rb_PorCobrar.CheckedChanged
        Try
            If Rb_PorCobrar.Checked = True Then
                Cbo_TipoCobro.Visible = False
            Else
                Cbo_TipoCobro.Visible = False
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Rb_PorCobrarDev_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rb_PorCobrarDev.CheckedChanged
        Try
            If Rb_PorCobrarDev.Checked = True Then
                Cbo_TipoCobroDev.Visible = False
            Else
                Cbo_TipoCobroDev.Visible = False
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Chk_Consignacion_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chk_Consignacion.CheckedChanged
        Try
            If Chk_Consignacion.Checked = True Then
                Lbl_Plazo.Visible = True
                Txt_PlazoC.Visible = True
                Lbl_Condicion.Visible = True
                Txt_Condicion.Visible = True
            Else
                Lbl_Plazo.Visible = False
                Txt_PlazoC.Visible = False
                Lbl_Condicion.Visible = False
                Txt_Condicion.Visible = False
                Txt_Condicion.Text = ""
                Txt_PlazoC.Text = ""
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Chk_Costeo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chk_Costeo.CheckedChanged
        Try
            'If Chk_Costeo.Checked = True Then
            '    Lbl_MargenCosteo.Visible = True
            '    Txt_MargenCosteo.Visible = True
            'Else
            '    Lbl_MargenCosteo.Visible = False
            '    Txt_MargenCosteo.Visible = False
            '    Txt_MargenCosteo.Text = ""
            'End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Chk_DevCorreo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chk_DevCorreo.CheckedChanged
        'Try
        '    If Chk_DevCorreo.Checked = True Then
        '        Txt_CorreoDev.Visible = True
        '    Else
        '        Txt_CorreoDev.Visible = False
        '        Txt_CorreoDev.Text = ""
        '    End If
        'Catch ExceptionErr As Exception
        '    MessageBox.Show(ExceptionErr.Message.ToString)
        'End Try
    End Sub
    Private Sub Chk_AceptaDev_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chk_AceptaDev.CheckedChanged
        Try
            If Chk_AceptaDev.Checked = True Then
                Pnl_Ed3.Enabled = True
                Cbo_EstadoD.Text = ""
            Else
                Pnl_Ed3.Enabled = False
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Txt_Proveedor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Proveedor.GotFocus
        Txt_Proveedor.SelectAll()
    End Sub
    Private Sub Txt_Proveedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Proveedor.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
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
    Private Sub Txt_Paqueteria_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Cbo_Paqueteria_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cbo_Paqueteria.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Cbo_PaqueteriaDev_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cbo_PaqueteriaDev.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Cbo_TipoCobroDev_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cbo_TipoCobroDev.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Cbo_TipoCobro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cbo_TipoCobro.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Txt_MotivoEstatus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_MotivoEstatus.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Cbo_Estatus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cbo_Estatus.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Txt_PlazoDev_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_PlazoDev.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Txt_ParMin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_ParMin.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Txt_ImpMin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_ImpMin.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Txt_ProcedimPaq_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_ProcedimPaq.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Txt_ProcedimDev_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_ProcedimDev.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Txt_ContactoDev_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_ContactoDev.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Txt_Tel1Dev_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Tel1Dev.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Txt_Tel2Dev_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Tel2Dev.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Txt_CalleDev_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_CalleDev.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Txt_PaqueteriaDev_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Txt_Convenio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_ConvenioDev.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Txt_ConvenioGral_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_ConvenioGral.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Txt_Diaspp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Diaspp.KeyPress
        Call pub_SoloNumeros(sender, e)
    End Sub
    Private Sub Txt_Dscto01_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Dscto01.KeyPress
        Call pub_SoloNumeros(sender, e)
    End Sub
    Private Sub Txt_Dscto02_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Dscto02.KeyPress
        Call pub_SoloNumeros(sender, e)
    End Sub
    Private Sub Txt_Dscto03_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Dscto03.KeyPress
        Call pub_SoloNumeros(sender, e)
    End Sub
    Private Sub Txt_Dscto04_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Dscto04.KeyPress
        Call pub_SoloNumeros(sender, e)
    End Sub
    Private Sub Txt_Dscto05_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Dscto05.KeyPress
        Call pub_SoloNumeros(sender, e)
    End Sub
#End Region
#Region "Eventos Grid Condiciones"

    Private Sub DGridCond_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DGridCond.CellBeginEdit
        Sw_Condiciones = True
    End Sub

    Private Sub DGridCond_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGridCond.CellEndEdit
        Try
            Dim columna As Integer = DGridCond.CurrentCell.ColumnIndex
            Dim renglon As Integer = DGridCond.CurrentCell.RowIndex
            If Accion = 2 Then

                If DGridCond.CurrentRow.Cells("col_marca").Value <> Marca Then
                    Marca = DGridCond.CurrentRow.Cells("col_marca").Value
                    LimpiarControlesNuevaMarca()
                    'Exit Sub
                End If
            End If

            If DGridCond.AllowUserToAddRows = True Then
                If DGridCond.CurrentRow.Cells("col_marca").Value = "" Then

                    DGridCond.AllowUserToAddRows = False
                    Marca = DGridCond.CurrentRow.Cells("col_marca").Value

                Else
                    Call TxtLostfocus(DGridCond.CurrentRow.Cells("col_marca").Value, "M")

                End If
            End If
            'If columna = 3 Then

            '    If IsDate(DGridCond.Rows(renglon).Cells(columna).Value) Then
            '        If IsDate(DGridCond.Rows(renglon).Cells(columna).Value) = True Then
            '            ' validar formato
            '            DGridCond.Rows(renglon).Cells(columna).Value = Format(CDate(DGridCond.Rows(renglon).Cells(columna).Value), "Short Date")
            '        Else
            '            MsgBox("Fecha invalida", vbOKOnly + vbCritical, "Validación")
            '            DGridCond.Rows(renglon).Cells(columna).Value = ""

            '            sender.Focus()
            '            Exit Sub
            '        End If
            '    Else
            '        MsgBox("Fecha invalida", vbOKOnly + vbCritical, "Validación")
            '        DGridCond.Rows(renglon).Cells(columna).Value = ""
            '        sender.Focus()
            '        Exit Sub
            '    End If


            'End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub DGridCond_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGridCond.Click
        Dim marcaN As String = ""
        Try
            If DGridCond.CurrentRow.Cells("col_marca").Value Is Nothing Then Exit Sub
            marcaN = DGridCond.CurrentRow.Cells("col_marca").Value
            If Accion = 2 Or Accion = 4 Then
                If marcaN <> Marca Then
                    Marca = DGridCond.CurrentRow.Cells("col_marca").Value
                    MarcaSeleccionada = Marca
                    blnPrimero = True

                    blnFueClic = True
                    Cbo_MarcaCond.SelectedIndex = DGridCond.CurrentRow.Index
                    Cbo_MarcaCont.SelectedIndex = DGridCond.CurrentRow.Index
                    Cbo_MarcaDev.SelectedIndex = DGridCond.CurrentRow.Index
                    blnFueClic = False
                    'Lbl_MarcaC.Text = "Marca: " + Marca
                    'Lbl_MarcaD.Text = "Marca: " + Marca
                    'Lbl_MarcaCont.Text = "Marca: " + Marca

                    DGridContactos.Rows.Clear()
                    LimpiarControlesNuevaMarca()
                    Call usp_TraerCondicionesProv()
                    Call usp_TraerDevolucionesProv()
                    Call usp_TraerContactosProv()
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGridCond_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGridCond.DoubleClick
        Dim columna As Integer = DGridCond.CurrentCell.ColumnIndex
        Dim myForm As New frmPlazoPorcCondiciones
        'If columna <> Then Exit Sub
        Try

            myForm.IdProveedor = Val(Txt_IdProveedor.Text)
            myForm.Proveedor = Trim(Txt_Proveedor.Text)
            myForm.IdCondicion = Val(DGridCond.Rows(DGridCond.CurrentRow.Index).Cells("col_idcondicion").Value)
            myForm.Marca = DGridCond.Rows(DGridCond.CurrentRow.Index).Cells("col_marca").Value.ToString
            myForm.DescripMarca = Cbo_MarcaCond.Text
            myForm.Accion = Accion

            myForm.ShowDialog()


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub DGridCond_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGridCond.EditingControlShowing
        Dim columna As Integer = DGridCond.CurrentCell.ColumnIndex
        If columna = 3 Then Exit Sub

        Try
            Dim validar As TextBox = CType(e.Control, TextBox)
            ' agregar el controlador de eventos para el KeyPress   

            AddHandler validar.KeyPress, AddressOf validar_KeypressCond
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub DGridCond_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGridCond.KeyDown

        Try
            If (e.KeyCode = Keys.Escape) Then
                Exit Sub
            End If
            Dim columna As Integer
            Dim renglon As Integer = DGridCond.CurrentRow.Index
            Dim marca As String = ""
            columna = DGridCond.CurrentCell.ColumnIndex

            If Accion = 3 Or Accion = 4 Then
                Exit Sub
            End If

            'If renglon <> 0 Then
            If columna = 1 Then
                If e.KeyCode = 112 Or e.KeyCode = 13 Then
                    If DGridCond.CurrentRow.Cells.Item("col_marca").Value = Nothing Then
                        marca = ""
                    Else
                        marca = DGridCond.CurrentRow.Cells.Item("col_marca").Value
                    End If
                    Call TxtLostfocus(marca, "M")
                End If
            End If

            If (e.KeyCode = Keys.Delete) Then
                If renglon <> 0 Then
                    If Accion = 2 Then
                        If DGridCond.Rows(DGridCond.CurrentRow.Index).Cells("col_marca").Value <> "" Then
                            If MessageBox.Show("Está seguro de eliminar esta condición?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then

                                DGridCond.Rows().Remove(DGridCond.CurrentRow)

                            End If
                        End If
                    Else
                    End If
                End If
            End If
            'End If



        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub DGridCond_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DGridCond.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub
#End Region
#Region "Eventos Grid Cuentas"
    Private Sub DGridCuentas_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGridCuentas.EditingControlShowing
        Dim validar As TextBox = CType(e.Control, TextBox)
        Try
            ' agregar el controlador de eventos para el KeyPress   

            AddHandler validar.KeyPress, AddressOf validar_KeypressCuentas
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub DGridCuentas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGridCuentas.KeyDown
        If (e.KeyCode = Keys.Delete) Then
            If Accion = 2 Then
                If DGridCuentas.Rows(DGridCuentas.CurrentRow.Index).Cells("col_idcuenta").Value <> 0 Then
                    Dim Tipo As String = "CT"
                    Dim Proveedor As String = Txt_Proveedor.Text
                    Dim Id As Integer = DGridCuentas.Rows(DGridCuentas.CurrentRow.Index).Cells("col_idcuenta").Value

                    If MessageBox.Show("Está seguro de eliminar la cuenta?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then

                        DGridCuentas.Rows().Remove(DGridCuentas.CurrentRow)
                        Using objCatalogoProveedores As New BCL.BCLCatalogoProveedoresN(GLB_ConStringCipSis)
                            objCatalogoProveedores.usp_ActualizaEstatusDetProv(Tipo, Proveedor, Id, GLB_Idempleado)
                        End Using
                    End If
                End If
            ElseIf Accion = 1 Then
                DGridCuentas.Rows().Remove(DGridCuentas.CurrentRow)
            End If
        End If
    End Sub
    Private Sub DGridCuentas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DGridCuentas.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub
#End Region
#Region "Eventos Grid Contactos"
    Private Sub GB_Contacto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles GB_Contacto.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub
    Private Sub DGridContactos_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGridContactos.EditingControlShowing
        Dim validar As TextBox = CType(e.Control, TextBox)
        Try
            ' agregar el controlador de eventos para el KeyPress   

            AddHandler validar.KeyPress, AddressOf validar_KeypressContactos
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub DGridContactos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGridContactos.KeyDown
        If (e.KeyCode = Keys.Delete) Then
            If Accion = 2 Then
                If DGridContactos.Rows(DGridContactos.CurrentRow.Index).Cells("col_idcontacto").Value <> 0 Then
                    If MessageBox.Show("Está seguro de eliminar el contacto?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                        Dim Tipo As String = "CN"
                        Dim Proveedor As String = Txt_Proveedor.Text
                        Dim Id As Integer = DGridContactos.Rows(DGridContactos.CurrentRow.Index).Cells("col_idcontacto").Value

                        DGridContactos.Rows().Remove(DGridContactos.CurrentRow)
                        Using objCatalogoProveedores As New BCL.BCLCatalogoProveedoresN(GLB_ConStringCipSis)
                            objCatalogoProveedores.usp_ActualizaEstatusDetProv(Tipo, Proveedor, Id, GLB_Idempleado)
                        End Using

                    End If
                End If
            ElseIf Accion = 1 Then
                DGridContactos.Rows().Remove(DGridContactos.CurrentRow)
            End If
        End If
    End Sub
#End Region

    Private Sub Cbo_MarcaCond_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cbo_MarcaCond.SelectedIndexChanged
        Dim IndexCb As Integer = 0
        Dim marcaN As String = ""
        Try

            If blnPrimero = False Then Exit Sub

            IndexCb = Cbo_MarcaCond.SelectedIndex

            Cbo_MarcaCont.SelectedIndex = IndexCb
            Cbo_MarcaDev.SelectedIndex = IndexCb
            DGridCond.ClearSelection()
            DGridCond.Rows(IndexCb).Cells("col_marca").Selected = True

            If blnFueClic = True Then Exit Sub

            
            DGridCond_Click(sender, e)

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Cbo_MarcaCont_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cbo_MarcaCont.SelectedIndexChanged
        Dim IndexCb As Integer = 0
        Try
            If blnPrimero = False Then Exit Sub
            IndexCb = Cbo_MarcaCont.SelectedIndex

            Cbo_MarcaCond.SelectedIndex = IndexCb
            Cbo_MarcaDev.SelectedIndex = IndexCb

            If blnFueClic = True Then Exit Sub

            DGridCond.ClearSelection()
            DGridCond.Rows(IndexCb).Cells("col_marca").Selected = True
            DGridCond_Click(sender, e)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Cbo_MarcaDev_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cbo_MarcaDev.SelectedIndexChanged
        Dim IndexCb As Integer = 0
        Try
            If blnPrimero = False Then Exit Sub
            IndexCb = Cbo_MarcaDev.SelectedIndex

            Cbo_MarcaCont.SelectedIndex = IndexCb
            Cbo_MarcaCond.SelectedIndex = IndexCb

            If blnFueClic = True Then Exit Sub

            DGridCond.ClearSelection()
            DGridCond.Rows(IndexCb).Cells("col_marca").Selected = True
            DGridCond_Click(sender, e)

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGridCond_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGridCond.CellContentClick

    End Sub

    Private Sub Chk_Factoraje_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_Factoraje.CheckedChanged
        If Chk_Factoraje.Checked = True Then
            Pnl_Factoraje.Enabled = True
        Else
            Pnl_Factoraje.Enabled = False

        End If
    End Sub

    Private Sub Pnl_Ed1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Ed1.Paint

    End Sub

    Private Sub RB_FecFact_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_FecFact.CheckedChanged
        Sw_Condiciones = True
    End Sub

    Private Sub RB_FecReci_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_FecReci.CheckedChanged
        Sw_Condiciones = True
    End Sub

    Private Sub Cbo_Paqueteria_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo_Paqueteria.SelectedIndexChanged

    End Sub

    Private Sub Tp_Generales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tp_Generales.Click

    End Sub

    Private Sub Pnl_Botones_Paint(sender As Object, e As PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub
End Class