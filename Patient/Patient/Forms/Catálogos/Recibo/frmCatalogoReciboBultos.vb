Public Class frmCatalogoReciboBultos


    'Tony Garcia - 13/Octubre/2012 - 12:10 p.m.
    Private documentos As Integer = 0
    Private objDataSet As Data.DataSet
    Private UltimoFolio As Integer = 0
    Private blnValida = False

    Public Accion As Integer  '' 1  = nuevo, 2 = edicion , 4 = consulta
    'Dim IdDepto As Integer = 0
    'Dim IdPuesto As Integer = 0
    Dim ContadorMov As Integer = 0
    Public Estatus As String = ""
    Dim EstatusB As String = ""
    Public IdActividad As Integer
    Public FechaAlta As Date
    Public FechaProceso As Date
    Public FechaRealizado As Date
    Public Guardo As Boolean = False
    Public Sucursal As String = ""
    Public Folio As String = ""
    Public FolioB As String = ""
    Dim IdProveedorB As Integer = 0
    Dim sw_pedido = False
    Dim Sw_NoValidar = True



    Private Sub frmCatalogoMovEmp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        DGrid.RowHeadersVisible = False

       

        Try
     

            If Accion = 1 Then
                Call RellenaCombos(Cbo_Paqueteria, "TRANSPORTE", "", GLB_ConStringCipSis, True)

                Txt_Folio.Enabled = False

                Using objEmpleado As New BCL.BCLOperaciones(GLB_ConStringCipSis)
                    objDataSet = objEmpleado.usp_TraerIdFolioBulto(GLB_CveSucursal)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_Folio.Text = objDataSet.Tables(0).Rows(0).Item("idfoliosuc").ToString
                    FolioB = objDataSet.Tables(0).Rows(0).Item("idfolio").ToString
                    If Txt_Folio.Text.Length = 0 Then
                        Txt_Folio.Text = GLB_CveSucursal & pub_RellenarIzquierda("1", 6)
                    Else
                        Txt_Folio.Text = GLB_CveSucursal & pub_RellenarIzquierda(Txt_Folio.Text, 6)
                    End If
                    FolioB = pub_RellenarIzquierda(FolioB, 6)

                Else
                    Txt_Folio.Text = GLB_CveSucursal & pub_RellenarIzquierda("1", 6)
                End If
                '' Traer valor de quien recibe.
                Txt_Recibe.Text = GLB_Idempleado
                Txt_DescripRecibe.Text = GLB_NomUsuario


            End If
            If Accion = 2 Or Accion = 3 Then
                Pnl_Detalle.Visible = True
                Using objEmpleado As New BCL.BCLBulto(GLB_ConStringCipSis)
                    objDataSet = objEmpleado.usp_TraerBulto(FolioB, Txt_Folio.Text)
                End Using
                Txt_Folio.Enabled = False

                Txt_Folio.Text = objDataSet.Tables(0).Rows(0).Item("idfolioSUC").ToString
                FolioB = objDataSet.Tables(0).Rows(0).Item("idfolio").ToString
                'Call TxtLostfocusPersis(Txt_Sucursal, Txt_DescripSucursal, "S")
                Txt_Proveedor.Text = objDataSet.Tables(0).Rows(0).Item("proveedor").ToString
                Call TxtLostfocus(Txt_Proveedor, Txt_Raz_Soc, "P")
                Txt_NoGuia.Text = objDataSet.Tables(0).Rows(0).Item("noguia").ToString
                Txt_Transporta.Text = objDataSet.Tables(0).Rows(0).Item("transporta").ToString
                Cbo_Paqueteria.Text = objDataSet.Tables(0).Rows(0).Item("paqueteria").ToString
                Txt_NoBultos.Text = objDataSet.Tables(0).Rows(0).Item("nobultos").ToString
                Txt_Recibe.Text = objDataSet.Tables(0).Rows(0).Item("recibe").ToString
                Txt_DescripRecibe.Text = usp_TraerNomEmpleado(objDataSet.Tables(0).Rows(0).Item("recibe"), 0)
                Txt_IdEmpleado.Text = objDataSet.Tables(0).Rows(0).Item("asigna").ToString
                If objDataSet.Tables(0).Rows(0).Item("tipo").ToString = "R" Then
                    Opt_Recibo.Checked = True
                Else
                    Opt_Devolucion.Checked = True
                End If
                EstatusB = objDataSet.Tables(0).Rows(0).Item("status").ToString

                If Val(Txt_IdEmpleado.Text) > 0 Then
                    Txt_NombreEmpleado.Text = usp_TraerNomEmpleado(objDataSet.Tables(0).Rows(0).Item("asigna"), 0)
                End If

                If objDataSet.Tables(0).Rows(0).Item("sf").ToString = 1 Then
                    Chk_SinFactura.Checked = True
                Else
                    Chk_SinFactura.Checked = False
                End If

                Txt_Comentarios.Text = objDataSet.Tables(0).Rows(0).Item("comentarios").ToString

                DateTimePicker1.Value = CDate(objDataSet.Tables(0).Rows(0).Item("fecrecibe").ToString)

                Txt_Marca.Text = objDataSet.Tables(0).Rows(0).Item("marca").ToString
                Txt_DescripMarca.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString


                ' Traer detallado. 


                If Accion = 3 Then ' es consulta
                    Panel1.Enabled = False
                    Call usp_TraerDetBulto()
                ElseIf Accion = 2 Then
                    'DGrid.ReadOnly = False
                    Panel1.Enabled = False
                    Txt_Marca.Enabled = True
                    Txt_DescripMarca.Text = ""
                    DGrid.ReadOnly = False
                    DGrid.Enabled = True
                    Txt_Marca.Focus()

                End If
            End If
            'If GLB_CveSucursal <> "" And GLB_CveSucursal <> "15" Then
            ' DGrid.Columns("suc").Visible = False
            ' DGrid.Columns("nombre").Visible = False

            'End If
            If Opt_Devolucion.Checked = True Then
                Btn_Condiciones.Visible = True
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub usp_TraerDetBulto()
        Using objCatalogoBulto As New BCL.BCLBulto(GLB_ConStringCipSis)
            Try
                Dim Margen As Decimal = 0
                Dim PComp As Decimal = 0
                Dim Precio As Decimal = 0
                objDataSet = objCatalogoBulto.usp_TraerDetBulto(FolioB, "", "")

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    For I As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1



                        DGrid.Rows.Add(objDataSet.Tables(0).Rows(I).Item(0).ToString, _
                                         objDataSet.Tables(0).Rows(I).Item(1).ToString, _
                                         objDataSet.Tables(0).Rows(I).Item(2).ToString, _
                                         objDataSet.Tables(0).Rows(I).Item(3).ToString, _
                                         objDataSet.Tables(0).Rows(I).Item(4).ToString, _
                                         Format(objDataSet.Tables(0).Rows(I).Item(5), "yyyy-MM-dd"))




                    Next

                End If


            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub
    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Aceptar, "Guardar")
            ToolTip.SetToolTip(Btn_Cancelar, "Cancelar")

            ToolTip.SetToolTip(Btn_IFE, "Imagen IFE")
            ToolTip.SetToolTip(Btn_Factura, "Imagen Factura")
            ToolTip.SetToolTip(Btn_Talon, "Imagen Talon")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub usp_TraerEmpleadoRep()
        'Tony Gracia - 13/Octubre/2012 - 01:20 p.m.
        Dim objDataSet As Data.DataSet
        Using objEmpleado As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)
            Try
                If Txt_Recibe.Text.Length = 0 Then Exit Sub
                objDataSet = objEmpleado.usp_TraerNomEmpleado(Val(Txt_Recibe.Text), "", "", "", "", 0)
                If objDataSet.Tables(0).Rows.Count > 0 Then

                    Txt_DescripRecibe.Text = objDataSet.Tables(0).Rows(0).Item("nomcompleto").ToString
                Else
                    Call CargarFormaConsultaEmpleadoR()
                    ''MessageBox.Show("El empleado no existe, ingrese un ID valido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    'Private Sub usp_TraerEmpleadoAsig()
    '    'Tony Gracia - 13/Octubre/2012 - 01:20 p.m.
    '    Dim objDataSet As Data.DataSet
    '    Using objEmpleado As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)
    '        Try
    '            If Txt_Entrega.Text.Length = 0 Then Exit Sub
    '            objDataSet = objEmpleado.usp_TraerNomEmpleado(Val(Txt_Entrega.Text), "", "", "", "")
    '            If objDataSet.Tables(0).Rows.Count > 0 Then

    '                Txt_DescripEntrega.Text = objDataSet.Tables(0).Rows(0).Item("nomcompleto").ToString
    '            Else
    '                Call CargarFormaConsultaEmpleadoA()
    '                ''MessageBox.Show("El empleado no existe, ingrese un ID valido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '            End If
    '        Catch ExceptionErr As Exception
    '            MessageBox.Show(ExceptionErr.Message.ToString)
    '        End Try
    '    End Using
    'End Sub

    Private Sub HabilitaControles(ByVal blnEnabled As Boolean)
        Try
            ' Txt_Entrega.Enabled = blnEnabled
            Txt_Recibe.Enabled = blnEnabled
            Txt_Comentarios.Enabled = blnEnabled
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub Txt_Folio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Folio.LostFocus
        Try
            If Txt_Folio.Text.Length = 0 Then Exit Sub
            If Txt_Folio.Text.Trim.Length < 6 Then
                Txt_Folio.Text = pub_RellenarIzquierda(Txt_Folio.Text.Trim, 6)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub TxtLostfocusPersis(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
        Dim myForm As New frmConsulta


        If Txt_Campo.Text.Length = 0 Then Exit Sub
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringPerSis)
            Try

                Dim objDataSet1 As DataSet
                objDataSet1 = objMySqlGral.usp_TraerDescripcion(Tipo, Txt_Campo.Text, "")

                If objDataSet1.Tables(0).Rows.Count > 0 Then
                    Txt_Campo1.Text = objDataSet1.Tables(0).Rows(0).Item("campo").ToString
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

    Private Sub Txt_Proveedor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Proveedor.LostFocus
        Try
            If Txt_Proveedor.Text.Length = 0 Then Exit Sub
            If Txt_Proveedor.Text.Trim.Length < 3 Then
                Txt_Proveedor.Text = pub_RellenarIzquierda(Txt_Proveedor.Text.Trim, 3)
            End If
            Call TxtLostfocus(Txt_Proveedor, Txt_Raz_Soc, "P")

            Call ValidarMarcaProv()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub TxtLostfocus(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
        'mreyes 28/Febrero/2012 10:49 a.m.
        Dim myForm As New frmConsulta


        If Txt_Campo.Text.Length = 0 Then Exit Sub
        Using objMySqlGral As New BCL.BCLMySqlGral(Glb_ConStringCipSis)
            Try
                Dim objDataSet1 As DataSet
                objDataSet1 = objMySqlGral.usp_TraerDescripcion(Tipo, Txt_Campo.Text, "")
                If objDataSet1.Tables(0).Rows.Count > 0 Then
                    Txt_Campo1.Text = objDataSet1.Tables(0).Rows(0).Item("campo").ToString
                    If Tipo = "P" Then
                        idproveedorb = Val(objDataSet1.Tables(0).Rows(0).Item("campo1").ToString)
                    End If
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
        'mreyes 20/Enero/2012 10:27 a.m.
        Try
            Dim FolioSuc As String = ""
            Dim Sucursal As String = ""
            Dim Proveedor As String = ""
            Dim NoGuia As String = ""
            Dim Transporta As String = ""
            Dim NoBultos As Double = 0
            Dim Recibe As Integer = 0
            Dim FecRecibe As Date = "1900-01-01"
            Dim NombreRec As String = ""
            Dim Entrega As Integer = 0
            Dim NombreEnt As String = ""
            Dim Factura As String = ""
            Dim Comentarios As String = ""

            Dim Usuario As String = ""
            Dim NoSucursal As Integer = 0
            Dim Asigna As Integer = 0
            Dim FecAsigna As Date = "1900-01-01"
            Dim objDataSet2 As DataSet
            Dim Tipo As String = "R"
            Dim status As String = "CA"
            Dim SF As Integer = 1

            If Chk_SinFactura.Checked = True Then
                SF = 1
            Else
                SF = 0
            End If
            If Accion = 1 Then
                If ValidaCampos() = False Then Exit Sub
                If MessageBox.Show("Esta seguro que desea generar el folio'" & Txt_Folio.Text & "', con la información proporcionada.", "CONFIRMACIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then Exit Sub


                Using objEmpleado As New BCL.BCLOperaciones(GLB_ConStringCipSis)
                    objDataSet = objEmpleado.usp_TraerIdFolioBulto(GLB_CveSucursal)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_Folio.Text = objDataSet.Tables(0).Rows(0).Item("idfoliosuc").ToString
                    FolioB = objDataSet.Tables(0).Rows(0).Item("idfolio").ToString
                    If Txt_Folio.Text.Length = 0 Then
                        Txt_Folio.Text = GLB_CveSucursal & pub_RellenarIzquierda("1", 6)
                    Else
                        Txt_Folio.Text = GLB_CveSucursal & pub_RellenarIzquierda(Txt_Folio.Text, 6)
                    End If
                    FolioB = pub_RellenarIzquierda(FolioB, 6)

                Else
                    Txt_Folio.Text = GLB_CveSucursal & pub_RellenarIzquierda("1", 6)
                End If


                FolioSuc = Txt_Folio.Text
                Proveedor = Txt_Proveedor.Text
                NoGuia = Txt_NoGuia.Text
                Transporta = Txt_Transporta.Text
                NoBultos = Val(Txt_NoBultos.Text)
                Recibe = CInt(Txt_Recibe.Text)
                NombreRec = Txt_DescripRecibe.Text
                Comentarios = Txt_Comentarios.Text
                FecRecibe = GLB_FechaHoy.ToString("yyyy-MM-dd")
                Usuario = GLB_Usuario
                Asigna = CInt(Txt_Recibe.Text)
                FecAsigna = GLB_FechaHoy.ToString("yyyy-MM-dd")
                If Opt_Recibo.Checked = True Then
                    Tipo = "R"
                    status = "CA"
                Else
                    Tipo = "D"
                    status = "AP"
                End If
            
                Using objBultos As New BCL.BCLBulto(GLB_ConStringCipSis)
                    Guardo = objBultos.usp_Captura_Bulto(1, 0, Proveedor, Txt_Marca.Text, NoGuia, Transporta, NoBultos, NoSucursal, Comentarios, Recibe, FecRecibe, Asigna, FecAsigna, GLB_Usuario, "1900-01-01 00:00:00", "", "1900-01-01 00:00:00", 0, "1900-01-01 00:00:00", 0, 0, 0, 0, FolioSuc, status, Tipo, SF, Cbo_Paqueteria.Text)
                End Using

                ''Traer EL FOLIO QUE LE TOCO 

                Using objEmpleado As New BCL.BCLOperaciones(GLB_ConStringCipSis)
                    objDataSet2 = objEmpleado.usp_TraerIdFolio(Txt_Folio.Text)
                End Using
                If objDataSet2.Tables(0).Rows.Count > 0 Then
                    FolioB = objDataSet2.Tables(0).Rows(0).Item("idfolio").ToString
                End If

                ' Guardar detallado
                If Inserta_DetBulto() = False Then
                    Guardo = False
                End If
                If Guardo = True Then
                
                    MessageBox.Show("Datos del folio '" & Txt_Folio.Text & "' guardados correctamente", "CONFIRMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ImprimirReciboBono()
                    Me.Close()
                    Me.Dispose()

                Else
                    MessageBox.Show("Error al guardar, por favor intente de nuevo", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
            If Accion = 2 Then
                If ValidaCampos() = False Then Exit Sub
                If MessageBox.Show("Esta seguro que desea modificar la información", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then Exit Sub

                FolioSuc = Txt_Folio.Text
                Proveedor = Txt_Proveedor.Text
                NoGuia = Txt_NoGuia.Text
                Transporta = Txt_Transporta.Text
                NoBultos = Val(Txt_NoBultos.Text)
                Recibe = CInt(Txt_Recibe.Text)
                NombreRec = Txt_DescripRecibe.Text

                Comentarios = Txt_Comentarios.Text
                If Opt_Recibo.Checked = True Then
                    Tipo = "R"
                Else
                    Tipo = "D"
                End If

                Using objBultos As New BCL.BCLBulto(GLB_ConStringCipSis)
                    Guardo = objBultos.usp_Captura_Bulto(8, FolioB, Proveedor, Txt_Marca.Text, NoGuia, Transporta, NoBultos, NoSucursal, Comentarios, Recibe, FecRecibe, Asigna, FecAsigna, GLB_Usuario, "1900-01-01 00:00:00", "", "1900-01-01 00:00:00", 0, "1900-01-01 00:00:00", 0, 0, 0, 0, Txt_Folio.Text, status, Tipo, SF, Cbo_Paqueteria.Text)
                End Using
                If Inserta_DetBulto() = False Then
                    Guardo = False
                Else
                    Guardo = True
                End If
                If Guardo = True Then
                    MessageBox.Show("Folio '" & Txt_Folio.Text & "' registrado correctamente", "CONFIRMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                    Me.Dispose()
                Else
                    MessageBox.Show("Error al guardar, por favor intente de nuevo", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Function Inserta_DetBulto() As Boolean
        Try
            'mreyes 20/Enero/2012 12:55 p.m.

            Dim Sw_ExisteSucusal As Boolean
            Dim TipoCrr As String = ""
            Dim Margen As Decimal = 0
            Dim TipoCrrBus As String = ""
            Dim CambPrec As String = ""
            Dim PrecioValor As Decimal = 0
            Dim objDataSet As Data.DataSet


            If Accion = 2 Then
                Using objDetBulto As New BCL.BCLBulto(GLB_ConStringCipSis)

                    objDataSet = objDetBulto.usp_EliminarDetBulto(FolioB)


                    Sw_ExisteSucusal = False

                End Using
            End If

            For I As Integer = 0 To DGrid.Rows.Count - 2
                If DGrid.Rows(I).Cells(0).Value.ToString.Length = 0 Then Exit Function
                Using objBultos As New BCL.BCLBulto(GLB_ConStringCipSis)
                    'Get a new Project DataSet
                    Try
                        ' PrecioValor = (DGrid.Rows(I).Cells(5).Value)

                       
                        '' borrar el detallado.



                        objDataSet = objBultos.Inserta_DetBulto  'INSERTA NUEVO DATASET
                        Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow

                        objDataRow.Item("idfolio") = Val(FolioB)
                        objDataRow.Item("sucursal") = DGrid.Rows(I).Cells(0).Value.ToString
                        objDataRow.Item("nobultos") = DGrid.Rows(I).Cells(3).Value.ToString
                        objDataRow.Item("sucurorc") = Mid(DGrid.Rows(I).Cells(2).Value.ToString, 1, 2)
                        objDataRow.Item("ordecomp") = Mid(DGrid.Rows(I).Cells(2).Value.ToString, 3, 6)
                        objDataRow.Item("factura") = DGrid.Rows(I).Cells(4).Value.ToString
                        objDataRow.Item("fecfactura") = DGrid.Rows(I).Cells(5).Value

                        objDataSet.Tables(0).Rows.Add(objDataRow)

                        'Add the Project
                        If Sw_ExisteSucusal = True Then
                            If Not objBultos.usp_Captura_DetBulto(2, objDataSet) Then
                                If Accion <> 2 Then
                                    Throw New Exception("Falló Inserción de Detallado de Bulto, Intente nuevamente")
                                End If
                            End If
                        Else
                            If Not objBultos.usp_Captura_DetBulto(1, objDataSet) Then
                                If Accion <> 2 Then
                                    Throw New Exception("Falló Inserción de Detallado de Bulto, Intente nuevamente")
                                End If
                            End If
                        End If
                        objDataSet.Dispose()
                        objDataRow.Table.Dispose()


                    Catch ExceptionErr As Exception
                        MessageBox.Show(ExceptionErr.Message.ToString)
                    End Try
                End Using

            Next
            Inserta_DetBulto = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function
    Public Function ValidaCampos() As Boolean
        Try
            If Txt_Folio.Text.Trim = "" Then
                MessageBox.Show("Por favor ingrese un folio", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Txt_Folio.Focus()
                Return False
            End If

   

            If Txt_Proveedor.Text.Trim = "" Then
                MessageBox.Show("Por favor ingrese un proveedor", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Txt_Proveedor.Focus()
                Return False
            End If

            If Txt_NoGuia.Text.Trim = "" Then
                MessageBox.Show("Por favor ingrese un numero de guía", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Txt_NoGuia.Focus()
                Return False
            End If

            If Txt_Transporta.Text.Trim = "" Then
                MessageBox.Show("Por favor ingrese quien transporta", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Txt_Transporta.Focus()
                Return False
            End If

            If Txt_Recibe.Text.Trim = "" Then
                MessageBox.Show("Por favor ingrese un empleado que recibe la mercancia", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Txt_Recibe.Focus()
                Return False
            End If

            If Txt_Comentarios.Text.Trim = "" Then
                MessageBox.Show("Por favor ingrese un comentario al folio electrónico.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Txt_Comentarios.Focus()
                Return False
            End If

            If Accion <> 1 Then
                If DGrid.RowCount = 1 Then
                    MessageBox.Show("Por favor ingrese el detallado del bulto", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    DGrid.Focus()
                    Return False
                End If


                If Accion <> 2 Then
                    If sw_pedido = False Then
                        MessageBox.Show("El sistema no pudo validar el pedido, hagalo nuevamente.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        DGrid.Focus()
                        Return False
                    End If
                End If

            End If

            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Function

    Private Sub Txt_Reporta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Recibe.LostFocus
        Try
            Call usp_TraerEmpleadoRep()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Asignado_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            ' Call usp_TraerEmpleadoAsig()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    'Private Sub CargarFormaConsultaEmpleadoA()
    '    Dim myForm As New frmConsultaEmpleado
    '    Txt_DescripEntrega.Text = ""
    '    myForm.Estatus = ""
    '    myForm.ShowDialog()
    '    Txt_Entrega.Text = myForm.Campo
    '    Txt_DescripEntrega.Text = myForm.Campo1
    '    If Txt_Entrega.Text.Length = 0 Then
    '        Txt_Entrega.Focus()
    '    End If
    'End Sub

    Private Sub CargarFormaConsultaEmpleadoR()
        Dim myForm As New frmConsultaEmpleado
        Txt_DescripRecibe.Text = ""
        myForm.Estatus = ""
        myForm.ShowDialog()
        Txt_Recibe.Text = myForm.Campo
        Txt_DescripRecibe.Text = myForm.Campo1
        If Txt_Recibe.Text.Length = 0 Then
            Txt_Recibe.Focus()
        End If
    End Sub

    Private Sub Txt_Asignado_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'Call pub_SoloNumeros(sender, e)
    End Sub

    Private Sub Txt_Descripcion_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Comentarios.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Try
            If Accion = 1 Or Accion = 2 Then
                If MessageBox.Show("Esta seguro de Cancelar el Registro?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
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

    Private Sub frmPpalCatalogoActividades_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub


    Private Sub ImprimirReciboBono()
        'mreyes 01/Septiembre/2012 07:12 p.m.
        Try
            Dim myForm As New frmReportsBrowser
            Dim Sw_Mas14 As Boolean = False
            Dim Cont As Integer = 0
            Dim Tipo As String = ""

            Dim Sw_Imprimir As Boolean = False

            If Opt_Recibo.Checked = True Then
                Tipo = "RECIBO"
            Else
                Tipo = "DEVOLUCIÓN"
            End If
            myForm.objDataSetBulto = GenerarDTBulto()
            myForm.TipoRecibo = Tipo
            If Chk_SinFactura.Checked = True Then
                myForm.r_Titulo = "SIN FACTURA"

            End If


            If EstatusB <> "" Then
                If EstatusB = "ZC" Then
                    myForm.CanceladoRecibo = "CANCELADO"
                End If
            End If
            myForm.ReportIndex = 10   'CUANDO SE GENERA LA PRIMERA VEZ nosotros .. el 1 es el proveedor , EL 3 ES EL DE CEDI


            myForm.Show()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try



    End Sub

    Private Function GenerarDTBulto() As DTBulto
        'mreyes 01/Septiembre/2012 07:12 p.m.
        Try
            '' Dim objDataSet As New DtReciboBono
            Dim Columna As Integer = 0
            Dim Cont As Integer = 0
            Dim Facturas As String = ""

            GenerarDTBulto = New DTBulto


            With DGrid
                Cont = 0



                Dim objDataRow1 As Data.DataRow = GenerarDTBulto.Tables("Tbl_Bulto").NewRow


                objDataRow1.Item("Idfolio") = Txt_Folio.Text
                objDataRow1.Item("nobultos") = Txt_NoBultos.Text
                objDataRow1.Item("fecrecibe") = Format(DateTimePicker1.Value, "yyyy-MM-dd")
                objDataRow1.Item("proveedor") = Txt_Proveedor.Text
                objDataRow1.Item("raz_soc") = Txt_Raz_Soc.Text
                objDataRow1.Item("comentarios") = Txt_Comentarios.Text
                objDataRow1.Item("marca") = Txt_Marca.Text
                objDataRow1.Item("descripmarca") = Txt_DescripMarca.Text
                objDataRow1.Item("Transporta") = Txt_Transporta.Text
                objDataRow1.Item("paqueteria") = Cbo_Paqueteria.Text





                Facturas = ""
                For I As Integer = 0 To DGrid.Rows.Count - 2
                    Facturas = Facturas & DGrid.Rows(I).Cells(4).Value.ToString & " , "
                Next
                objDataRow1.Item("facturas") = Facturas
                GenerarDTBulto.Tables("Tbl_Bulto").Rows.Add(objDataRow1)

            End With
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function
    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub

    Private Sub Txt_NoBultos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_NoBultos.LostFocus
        If Val(Txt_NoBultos.Text) > 0 Then
            DGrid.ReadOnly = False

        End If
    End Sub

    Private Sub Txt_NoBultos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_NoBultos.TextChanged

    End Sub

    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub

    Private Sub DGrid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellEndEdit
        'mreyes 20/Enero/2012 12:37 p.m.

        Dim columna As Integer = DGrid.CurrentCell.ColumnIndex
        Dim renglon As Integer = DGrid.CurrentCell.RowIndex
        Dim Pedido As String = ""
        Try
            'If GLB_CveSucursal <> "" And GLB_CveSucursal <> "15" Then
            '    DGrid.Rows(renglon).Cells(0).Value = GLB_CveSucursal
            'End If

            If Chk_SinFactura.Checked = True Then
                DGrid.Rows(renglon).Cells(4).Value = "SIN FACTURA"
            End If


            If columna = 0 Then 'sucursal
                Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringPerSis)
                    Dim Sucursal As String = DGrid.Rows(renglon).Cells(columna).Value

                    Try
                        'Get the specific project selected in the ListView control
                        If Sucursal.Length < 2 Then

                            DGrid.Rows(renglon).Cells(1).Value = pub_RellenarIzquierda(Sucursal, 2)
                        End If

                        If GLB_OPedido = "NO" Then
                            If Sucursal <> Mid(Txt_Folio.Text, 1, 2) Then
                                MsgBox("No puede recibir un pedido que no pertenece a su sucursal.", MsgBoxStyle.Information, "Validación")
                                DGrid.Rows(renglon).Cells(columna).Value = ""

                                Exit Sub
                            End If
                        End If

                        Call TraerSucursal(Sucursal, renglon, columna)


                    Catch ExceptionErr As Exception
                        MessageBox.Show(ExceptionErr.Message.ToString)
                    End Try
                End Using
            End If

            If columna = 2 Then 'pedido

                Pedido = Mid(DGrid.Rows(renglon).Cells(2).Value, 3, 6)
                Sucursal = Mid(DGrid.Rows(renglon).Cells(2).Value, 1, 2)
                If Sucursal <> Mid(DGrid.Rows(renglon).Cells(0).Value, 1, 2) Then
                    If Sw_NoValidar = True Then
                        MsgBox("Debe especificar un pedido para la sucursal correcto.", MsgBoxStyle.Critical, "Validación")
                        DGrid.Rows(renglon).Cells(2).Value = ""
                        Exit Sub
                    End If
                End If
                ' Buscar el pedido.
                If Sw_NoValidar = True Then
                    If usp_TraerOrdeComp(Sucursal, Pedido) = False Then
                        DGrid.Rows(renglon).Cells(2).Value = ""
                    End If
                End If
                sw_pedido = True

            End If

            If columna = 5 Then

                If IsDate(DGrid.Rows(renglon).Cells(columna).Value) Then
                    If IsDate(DGrid.Rows(renglon).Cells(columna).Value) = True Then
                        ' validar formato
                        DGrid.Rows(renglon).Cells(columna).Value = Format(CDate(DGrid.Rows(renglon).Cells(columna).Value), "Short Date")
                    Else
                        MsgBox("Fecha invalida", vbOKOnly + vbCritical, "Validación")
                        DGrid.Rows(renglon).Cells(columna).Value = ""

                        sender.Focus()
                        Exit Sub
                    End If
                Else
                    MsgBox("Fecha invalida", vbOKOnly + vbCritical, "Validación")
                    DGrid.Rows(renglon).Cells(columna).Value = ""
                    sender.Focus()
                    Exit Sub
                End If

                If CDate(DGrid.Rows(renglon).Cells(columna).Value) < Now Then
                    MsgBox("Estas recibiendo una factura con fecha menor al día de hoy, avisa a RECIBO.", vbOKOnly + vbCritical, "Validación")

                End If


            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Function usp_TraerOrdeComp(ByVal Sucursal As String, ByVal OrdeComp As String) As Boolean
        Using objPedidos As New BCL.BCLPedidos(GLB_ConStringCipSis)
            Dim objDataSet As Data.DataSet
            Try
                usp_TraerOrdeComp = False
                objDataSet = objPedidos.usp_TraerOrdeComp(Sucursal, OrdeComp)

                If objDataSet.Tables(0).Rows.Count > 0 Then



                    If Txt_Proveedor.Text <> "" Then
                        If objDataSet.Tables(0).Rows(0).Item("proveedor").ToString <> Txt_Proveedor.Text Then
                            MsgBox("El pedido no corresponde al proveedor.", MsgBoxStyle.Critical, "Error")
                            Exit Function
                        End If
                    End If
                    Txt_Proveedor.Text = objDataSet.Tables(0).Rows(0).Item("proveedor").ToString
                    If objDataSet.Tables(0).Rows(0).Item("status").ToString = "ZC" Then
                        MsgBox("El pedido esta cancelado, ya no puede recibirlo.", MsgBoxStyle.Critical, "Error")
                        Exit Function
                    End If


                    If Txt_Marca.Text <> "" Then
                        If objDataSet.Tables(0).Rows(0).Item("marca").ToString <> Txt_Marca.Text Then
                            MsgBox("El pedido NO corresponde a la marca.", MsgBoxStyle.Critical, "Error")
                            Exit Function
                        End If
                    End If
                    Txt_Marca.Text = objDataSet.Tables(0).Rows(0).Item("marca").ToString
                    IdProveedorB = objDataSet.Tables(0).Rows(0).Item("idproveedor").ToString
                    Txt_Raz_Soc.Text = objDataSet.Tables(0).Rows(0).Item("raz_soc").ToString
                    Call ValidarMarcaProv()

                Else

                    MsgBox("El pedido no existe, Verifique por favor.", MsgBoxStyle.Critical, "Error")
                    Exit Function
                End If


                usp_TraerOrdeComp = True

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function
    Private Sub DGrid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGrid.KeyDown
        'mreyes 14/Febrero/2012 04:20 p.m.
        Try
            If (e.KeyCode = 46) Then
                If Accion = 1 Or Accion = 2 Then
                   

                    If MessageBox.Show("Estas seguro de eliminar el pedido del folio de bulto?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then


                        If (DGrid.CurrentCell.RowIndex) <> DGrid.Rows.Count - 1 Then
                            DGrid.Rows.RemoveAt(DGrid.CurrentCell.RowIndex)
                            'End If
                        End If

                    End If
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub TraerSucursal(ByVal Sucursal As String, ByVal Renglon As Integer, ByVal Columna As Integer)
        'mreyes 28/Febrero/2012 01:30

        Dim objDataSet As Data.DataSet
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringPerSis)
            Try

                objDataSet = objMySqlGral.usp_TraerDescripcion("S", Sucursal, "")

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    DGrid.Rows(Renglon).Cells(Columna + 1).Value = objDataSet.Tables(0).Rows(0).Item("campo").ToString
                Else
                    Dim myForm As New frmConsulta
                    Txt_Campo.Text = ""
                    myForm.Tipo = "S"
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
    Private Sub Txt_NoGuia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_NoGuia.TextChanged

    End Sub

    Private Sub Btn_IFE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_IFE.Click

        Dim myForm As New frmCatalogoFotosBultos
        myForm.Accion = 2
        myForm.WindowState = FormWindowState.Normal
        myForm.Text = myForm.Text & " IFE"
        myForm.Tipo = 1
        myForm.idfolio = Val(Txt_Folio.Text)

        myForm.Show()
    End Sub

    Private Sub Btn_Factura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Factura.Click
        Dim myForm As New frmCatalogoFotosBultos
        myForm.Accion = 2
        myForm.WindowState = FormWindowState.Normal
        myForm.Text = myForm.Text & " FACTURA"
        myForm.Tipo = 2
        myForm.idfolio = Val(Txt_Folio.Text)

        myForm.Show()
    End Sub

    Private Sub Btn_Talon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Talon.Click
        Dim myForm As New frmCatalogoFotosBultos
        myForm.Accion = 2
        myForm.WindowState = FormWindowState.Normal
        myForm.Text = myForm.Text & " TALON"
        myForm.Tipo = 3
        myForm.idfolio = Val(Txt_Folio.Text)

        myForm.Show()
    End Sub

    Private Sub Btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Imprimir.Click
        Call ImprimirReciboBono()
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
    Private Sub Txt_IdEmpleado_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_IdEmpleado.LostFocus
        If Txt_IdEmpleado.Text.Length = 0 Then Txt_NombreEmpleado.Text = "" : Exit Sub


        Using objMySqlGral As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)
            Try
                If Val(Txt_IdEmpleado.Text) = 0 Then
                    CargarFormaConsultaEmpleado()
                Else
                    objDataSet = objMySqlGral.usp_TraerNomEmpleado(Val(Txt_IdEmpleado.Text), "", "", "", "", 0)
                    If objDataSet.Tables(0).Rows.Count = 1 Then
                        Txt_NombreEmpleado.Text = objDataSet.Tables(0).Rows(0).Item("nomcompleto").ToString
                    Else
                        Call CargarFormaConsultaEmpleado()
                    End If

                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub Txt_IdEmpleado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_IdEmpleado.TextChanged

    End Sub

    Private Sub Txt_Folio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Folio.TextChanged

    End Sub

    Private Sub Txt_Proveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Proveedor.TextChanged

    End Sub

    Private Sub Txt_Marca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Marca.KeyPress
        '  Txt_Marca.CharacterCasing = CharacterCasing.Upper
    End Sub

    Private Sub Txt_Marca_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Marca.LostFocus
        Call ValidarMarcaProv()
    End Sub

    Private Sub ValidarMarcaProv()
        'mreyes 11/03/2014 12:01 p.m.
        If Txt_Marca.TextLength <> 3 Then Exit Sub
        Using objMySqlGral As New BCL.BCLCatalogoProveedoresN(GLB_ConStringCipSis)
            Try
                objDataSet = objMySqlGral.usp_TraerCondicionesProv(IdProveedorB, Txt_Marca.Text)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Traer nombre de la marca, 
                    Txt_DescripMarca.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                Else
                    'solo traer asiganados al proveedor. 
                    Txt_Marca.Text = ""
                    Dim myForm As New frmConsulta
                    myForm.IdProveedorB = IdProveedorB
                    Txt_Campo.Text = ""
                    myForm.Tipo = "M"
                    myForm.ShowDialog()
                    Txt_Marca.Text = myForm.Campo
                    Txt_DescripMarca.Text = myForm.Campo1
                    If Txt_Marca.Text.Length = 0 Then
                        Txt_Marca.Focus()
                    End If
                End If



            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using

        If Opt_Devolucion.Checked = True Then
            Using objMySqlGral As New BCL.BCLCatalogoProveedoresN(GLB_ConStringCipSis)
                Try
                    objDataSet = objMySqlGral.usp_TraerDevolucionesProv(IdProveedorB, Txt_Marca.Text)
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        'Traer nombre de la marca, 
                        'Txt_DescripMarca.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                        Btn_Condiciones.Visible = True
                    Else
                        'solo traer asiganados al proveedor. 
                        MsgBox("No se puede generar una devolución, ya que las condiciones del proveedor no lo permiten.", MsgBoxStyle.Critical, "Validación")
                        Txt_Marca.Text = ""
                        Txt_Marca.Focus()

                    End If



                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using
        End If

    End Sub


    Private Sub Btn_Condiciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Condiciones.Click
        If GLB_Sw_Costos = True Then
            Dim myForm As New frmCatalogoProveedoresN

            myForm.Accion = 4
            myForm.Txt_IdProveedor.Text = IdProveedorB
            myForm.Txt_Proveedor.Text = Txt_Proveedor.Text

            myForm.ShowDialog()
        Else
            MsgBox("No tiene permiso para esta opción.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub Opt_Recibo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Opt_Recibo.CheckedChanged
        If Opt_Recibo.Checked = True Then
            Btn_Condiciones.Visible = False


        End If
    End Sub

    Private Sub Opt_Devolucion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Opt_Devolucion.CheckedChanged
        If Opt_Devolucion.Checked = True Then
            Btn_Condiciones.Visible = False


        End If
    End Sub

    Private Sub Pnl_Grid_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Grid.Paint

    End Sub

    Private Sub Txt_Marca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Marca.TextChanged
        'Txt_Marca.Text = UCase(Txt_Marca.Text)
        Txt_Marca.CharacterCasing = CharacterCasing.Upper
    End Sub

    Private Sub Txt_Transporta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Transporta.TextChanged
        Txt_Transporta.CharacterCasing = CharacterCasing.Upper
    End Sub

    Private Sub Txt_Comentarios_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Comentarios.TextChanged

    End Sub
End Class