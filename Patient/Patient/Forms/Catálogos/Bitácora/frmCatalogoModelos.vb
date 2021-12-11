Public Class frmCatalogoModelos
    'mreyes 23/Febrero/2012 02:23 p.m. 

    'Catálogo de Modelos  
    'mreyes 07/Febrero/2012 05:37 p.m.
    'Modif. Tony García - Abril 2013 (Nueva Estructura)

#Region "Variables"
    Dim Sql As String
    Public Accion As Integer  '' 1  = nuevo, 2 = edicion , 3 = eliminar , 4 = consultar, 5 = Nueva Est Captura 
    Public Sw_Registro As Boolean = False
    Private objDataSet As Data.DataSet
    Private objDataSetEstAnt As Data.DataSet
    Private objDataSetSuc As Data.DataSet
    Private objDataSetModelos As Data.DataSet
    Dim Costo As Decimal = 0
    Public Sw_PedidoNuevo As Boolean = False
    Public OpcionC As Integer
    Dim Sw_Entro As Boolean = False
    Dim aModelo As String = ""

    Dim blnCambiaCorrida As Boolean = False
    Dim intPosicion As Integer = 0
    Dim intTotalRows As Integer = 0

    Dim Precio As Decimal
    Dim Corrida As String = ""
    Dim Proveedor As String = ""
    Dim Sw_RegistroCorrida = False
    Dim ProveedorB As String = ""
    Dim CorridaB As String = ""

#End Region
#Region "Load de la Forma"

    Private Sub frmCatalogoEstilos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Accion = 2
            Call RellenaCombos(Cbo_Medida, "MEDIDA", "", GLB_ConStringCipSis, False)
            Call InicializaGridProv()

            If Accion = 1 Then
                ' LimpiarDatos()


                If Sw_PedidoNuevo = True Then
                    ' traer el estilo anterior, 
                    'If ya existe el estilo de fábrica

                    Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
                        Try

                            If Txt_Estilof.Text.Length > 0 Then
                                objDataSet = objMySqlGral.usp_TraerDescripcion("EN", Txt_Marca.Text, "315")

                                If objDataSet.Tables(0).Rows.Count > 0 Then
                                    Call usp_TraerCorrida(Txt_Modelo.Text)

                                    Call Txt_Division_LostFocus(sender, e)
                                    Call Txt_Depto_LostFocus(sender, e)
                                    Call Txt_Familia_LostFocus(sender, e)
                                    Call Txt_Linea_LostFocus(sender, e)
                                    Call Txt_L1_LostFocus(sender, e)
                                    Call Txt_L2_LostFocus(sender, e)
                                    Call Txt_L3_LostFocus(sender, e)
                                    Call Txt_L4_LostFocus(sender, e)
                                    Call Txt_L5_LostFocus(sender, e)
                                    Call Txt_L6_LostFocus(sender, e)
                                    Call Txt_Proveedor_LostFocus(sender, e)
                                    Call Txt_Agrupacion_LostFocus(sender, e)
                                    'Call Txt_Categoria_LostFocus(sender, e)
                                    'Call RellenaGridSuc()
                                    Call usp_Traer_MarcaProvCosto(Txt_Marca.Text)

                                    Txt_Descripc.Focus()
                                    Call RellenaGridSuc()
                                End If
                                Call RellenaGridSuc()
                            End If
                            Call Txt_Marca_LostFocus(sender, e)
                        Catch ExceptionErr As Exception
                            MessageBox.Show(ExceptionErr.Message.ToString)
                        End Try
                    End Using

                Else
                    Call RellenaGridSuc()
                    Call MarcaCeldasGridSuc()
                    Call usp_Traer_MarcaProvCosto(Txt_Marca.Text)
                    Call usp_TraerDetSucArt(Txt_Marca.Text, Txt_Modelo.Text)
                End If

            ElseIf Accion = 2 Then
                Call usp_TraerModelo("", "")
                Call usp_TraerEstructura()
                Call usp_Traer_MarcaProvCosto(Txt_Marca.Text)
                Call usp_TraerCorrida(Txt_Modelo.Text)
                Call usp_TraerDetSucArt(Txt_Marca.Text, Txt_Modelo.Text)
                Call usp_TraerCategoria(Txt_Marca.Text, Txt_Modelo.Text)
                Using objCatalogoEst As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                    objDataSet = objCatalogoEst.usp_TraerIdArticulo(Txt_Marca.Text, Txt_Modelo.Text)
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Txt_IdArticulo.Text = objDataSet.Tables(0).Rows(0).Item("idarticulo")
                    End If
                End Using
                Call usp_TraerAtributosModelo(CInt(Txt_IdArticulo.Text))
                'Call CargarFotoArticulo()

            End If

            If Accion = 5 Or Accion = 4 Then
                Using objCatalogoEstilos As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                    objDataSetModelos = objCatalogoEstilos.usp_TraerModelosMarca(0, "")
                End Using

                If objDataSetModelos.Tables(0).Rows.Count > 0 Then
                    intPosicion = 0
                    intTotalRows = objDataSetModelos.Tables(0).Rows.Count - 1
                End If

                Using objCatalogoEst As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                    objDataSet = objCatalogoEst.usp_TraerIdArticulo(Txt_Marca.Text, Txt_Modelo.Text)
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Txt_IdArticulo.Text = objDataSet.Tables(0).Rows(0).Item("idarticulo")
                    End If
                End Using

                Call usp_TraerModelo("", "")
                Call usp_TraerEstructura()
                Call usp_Traer_MarcaProvCosto(Txt_Marca.Text)
                Call usp_TraerCorrida(Txt_Modelo.Text)
                Call usp_TraerDetSucArt(Txt_Marca.Text, Txt_Modelo.Text)
                Call usp_TraerCategoria(Txt_Marca.Text, Txt_Modelo.Text)
                Call usp_TraerAtributosModelo(CInt(Txt_IdArticulo.Text))

                Txt_Marca.Select()
            End If

            Call GenerarToolTip()
            Call CargarFotoArticulo()
            DGrid.RowHeadersVisible = False
            Call Edicion()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

#End Region
#Region "Botones"

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click

        Try
            If Accion = 1 Then '''' es un articulo nuevo
                If ValidarEdicion() = False Then Exit Sub
                'mreyes 29/marzo/2021   06:42 p.m.

                Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
                    If Txt_Marca.Text.Length = 0 Then Exit Sub

                    Try

                        If Accion = 1 Then
                            objDataSet = objMySqlGral.usp_TraerFolio("EN", Txt_Marca.Text)
                            If objDataSet.Tables(0).Rows.Count > 0 Then
                                Txt_Modelo.Text = Val(objDataSet.Tables(0).Rows(0).Item("campo").ToString) + 1
                                Txt_Modelo.Text = Txt_Modelo.Text.PadLeft(7)
                            Else
                                Txt_Modelo.Text = "      1"
                            End If
                        End If

                    Catch ExceptionErr As Exception
                        MessageBox.Show(ExceptionErr.Message.ToString)
                    End Try
                End Using



                'mreyes 29/marzo2021    06:42 p.m.



                If MsgBox("Estas Seguro de Grabar el Artículo?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    If Inserta_EstArticulo() = True Then
                        If Inserta_Articulo() = True Then
                            If Inserta_Corrida() = True Then
                                If Accion <> 5 Then
                                    Call GuardarDetalleSucursal()
                                End If
                                Call GuardarAtributosModelo()
                                MessageBox.Show("Exitosamente Grabado el estilo '" & Txt_Modelo.Text & "' para la marca '" & Txt_Marca.Text & " !", "Agregando Arículo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Sw_Registro = True
                                GLB_CatEsiloCancelado = False
                                Me.Close()
                                '' Me.Dispose()
                            Else
                                MessageBox.Show("Error Grabando !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        End If
                    End If
                End If
            ElseIf Accion = 2 Or Accion = 5 Then 'es una actualización
                If ValidarEdicion() = False Then Exit Sub
                If ProveedorB = "" Then
                    MsgBox("Debe seleccionar un proveedor.", MsgBoxStyle.Critical, "Error")
                    Exit Sub
                End If
                If MsgBox("Estas Seguro de Actualizar el Modelo '" & Txt_Modelo.Text & "' para la marca '" & Txt_Marca.Text & " ?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    If Inserta_EstArticulo() = True Then
                        If Inserta_Articulo() = True Then
                            If Inserta_Corrida() = True Then
                                If Accion <> 5 Then
                                    Call GuardarDetalleSucursal()
                                End If
                                Call GuardarAtributosModelo()
                                Call ActualizarCategoria()
                                Sw_Registro = True
                                MessageBox.Show("Exitosamente Grabado el Modelo '" & Txt_Modelo.Text & "' para la marca '" & Txt_Marca.Text & " !", "Agregando Arículo", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                If Accion = 5 Then
                                    Call SiguienteEstilo(sender, e)
                                Else
                                    Me.Close()
                                    Me.Dispose()
                                End If
                            Else
                                MessageBox.Show("Error Grabando !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                            GLB_RefrescarPedido = True
                        End If
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
            GLB_CatEsiloCancelado = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Btn_Sig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Sig.Click
        'mreyes 02/Marzo/2012 04:57 p.m.
        Try
            If Val(Txt_NoFoto.Text) < 9 Then
                Txt_NoFoto.Text = Val(Txt_NoFoto.Text) + 1
            End If
            If TraerFoto(Txt_NoFoto.Text) = False Then
                Txt_NoFoto.Text = Val(Txt_NoFoto.Text) - 1
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Btn_Ant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ant.Click
        Try
            If Val(Txt_NoFoto.Text) <> 1 Then
                If Val(Txt_NoFoto.Text) <= 9 And Val(Txt_NoFoto.Text > 0) Then
                    Txt_NoFoto.Text = Val(Txt_NoFoto.Text) - 1
                End If
            End If
            If TraerFoto(Txt_NoFoto.Text) = False Then
                If Txt_NoFoto.Text <> 1 Then
                    Txt_NoFoto.Text = Val(Txt_NoFoto.Text) - 1
                End If

            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Btn_AceptarF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_AceptarF.Click
        'mreyes 02/Marzo/2012 05:32 p.m.
        Try
            Dim RutaOrigen As String = ""
            Dim RutaDestino As String = ""

            '' BUSCAR LA IMAGEN... SI LA ENCUENTRA PREGUNTAR PARA EDITARLA SINO DARLA DE ALTA CON UN NUMERO MAS 

            If MsgBox("Esta seguro de querer guardar la imagen para el estilo.?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub


            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)
                RutaOrigen = Txt_Ruta.Text
                RutaDestino = ""
                RutaDestino = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Modelo.Text, Txt_NoFoto.Text)

                If objIO.pub_ExisteArchivo(RutaDestino) = True Then
                    '' ya existe 
                    If MsgBox("Esta seguro de querer modificar la foto '" & Txt_NoFoto.Text & "' del estilo '" & Txt_Modelo.Text & " para la marca '" & Txt_Marca.Text & "'?. En caso contrario se registrará como nueva.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.Yes Then
                        ''sobreescribir la que ya existe 
                        objIO.pub_RenombrarArchivo(RutaDestino, objIO.pub_NombreArchivo(objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Modelo.Text, "99")))
                        objIO.pub_EliminarArchivo(objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Modelo.Text, "99"))
                        ' CambiarArchivo(RutaOrigen, RutaDestino)
                        objIO.pub_CopiarArchivo(RutaOrigen, RutaDestino)

                        If Inserta_ArtFotos(2) = False Then
                            MsgBox("No se pudo grabar correctamente la imagen.", MsgBoxStyle.Critical, "Aviso")
                        End If
                    Else
                        RutaDestino = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Modelo.Text, BuscarImagenSig)
                        'CambiarArchivo(RutaOrigen, RutaDestino)
                        objIO.pub_CopiarArchivo(RutaOrigen, RutaDestino)
                        If Inserta_ArtFotos(1) = False Then
                            MsgBox("No se pudo grabar correctamente la imagen.", MsgBoxStyle.Critical, "Aviso")
                        End If
                    End If
                Else
                    RutaDestino = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Modelo.Text, BuscarImagenSig)
                    'CambiarArchivo(RutaOrigen, RutaDestino)
                    objIO.pub_CopiarArchivo(RutaOrigen, RutaDestino)
                    If Inserta_ArtFotos(1) = False Then
                        MsgBox("No se pudo grabar correctamente la imagen.", MsgBoxStyle.Critical, "Aviso")
                    End If
                End If
                RutaOrigen = Txt_Ruta.Text



                ' objIO.pub_CopiarArchivo(RutaOrigen, RutaDestino)
            End Using

            MsgBox("Archivo correctamente grabado en la ruta '" & RutaDestino & "'", MsgBoxStyle.Information, "Confirmación")
            ''  Btn_Aceptar.Enabled = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Btn_NuevoF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_NuevoF.Click
        'mreyes 02/Marzo/2012 05:38 p.m.
        Try
            OpenFileDialog.Filter = "img files (*.jpg)|*.jpg|All files (*.*)|*.*"
            OpenFileDialog.FileName = ""
            OpenFileDialog.ShowDialog()
            If OpenFileDialog.FileName = "" Then Exit Sub
            PBox.Image = New System.Drawing.Bitmap(OpenFileDialog.FileName)
            Txt_Ruta.Text = OpenFileDialog.FileName
            If Txt_Ruta.Text.Length > 0 Then
                Btn_AceptarF.Enabled = True

            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub
    Private Sub Btn_EliminarF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_EliminarF.Click
        'Try
        '    If MsgBox("Esta seguro de querer eliminar la imagen.?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.Yes Then
        '        Using objIO As New BCL.BCLio(GLB_ConStringCipSis)
        '            PBox.Image = Nothing
        '            '  objIO.pub_EliminarArchivo(objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Modelo.Text, Txt_NoFoto.Text))
        '            ' objIO.pub_RenombrarArchivo(objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Modelo.Text, Txt_NoFoto.Text), "ELIMINAR" + Txt_Marca.Text + Txt_Modelo.Text + Txt_NoFoto.Text)
        '            objIO.pub_CopiarArchivo(objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Modelo.Text, Txt_NoFoto.Text), objIO.pub_ArmarNombreFotoEstilo("c:\", Txt_Marca.Text, Txt_Modelo.Text, Txt_NoFoto.Text))
        '        End Using

        '        'System.OutOfMemoryException = Nothing

        '        Using objIO As New BCL.BCLio(GLB_ConStringCipSis)
        '            objIO.pub_EliminarArchivo(objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Modelo.Text, Txt_NoFoto.Text))

        '        End Using
        '    End If
        'Catch ExceptionErr As Exception
        '    MessageBox.Show(ExceptionErr.Message.ToString)
        'End Try
        Try
            If MsgBox("Esta seguro de querer eliminar la imagen.?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.Yes Then
                PBox.Image.Dispose()
                PBox2.Image.Dispose()
                PBox.Image = Nothing
                PBox2.Image = Nothing
                Using objIO As New BCL.BCLio(GLB_ConStringCipSis)

                    objIO.pub_EliminarArchivo(objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Modelo.Text, Txt_NoFoto.Text))
                End Using
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try


    End Sub
    Private Sub Btn_MarcarTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_MarcarTodos.Click
        Try

            For i As Integer = 0 To DgridSuc.Rows.Count - 2
                If DgridSuc.Rows(i).Cells("Selec").Value = True Then
                    DgridSuc.Rows(i).Cells("Selec").Value = False
                Else
                    DgridSuc.Rows(i).Cells("Selec").Value = True
                End If
            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Btn_AgregarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_AgregarProveedor.Click
        Dim myForm As New frmCatalogoMarca
        Try

            myForm.Txt_Marca.Text = Txt_Marca.Text
            myForm.Accion = 2

            myForm.ShowDialog()

            DGrid2.Rows.Clear()
            Call usp_Traer_MarcaProvCosto(Txt_Marca.Text)

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Btn_AgregarM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_AgregarM.Click
        Dim Opcion As Integer = 0
        Try

            If Txt_BuscarMaterial.Text = "" Then Exit Sub

            Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
                objDataSet = objMySqlGral.usp_TraerDescripcion("AM", Txt_BuscarMaterial.Text, "M")

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    DGridMat.Rows.Add(objDataSet.Tables(0).Rows(0).Item("idatributo").ToString, _
                                        objDataSet.Tables(0).Rows(0).Item("campo").ToString)

                Else

                    Opcion = 1

                    Using objCatalogoEst As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                        objCatalogoEst.usp_Captura_Atributo(Opcion, Txt_BuscarMaterial.Text, "M")
                    End Using

                    objDataSet = objMySqlGral.usp_TraerDescripcion("AM", Txt_BuscarMaterial.Text, "M")

                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        DGridMat.Rows.Add(objDataSet.Tables(0).Rows(0).Item("idatributo").ToString, _
                                            objDataSet.Tables(0).Rows(0).Item("campo").ToString)

                    End If
                End If
            End Using

            Txt_BuscarMaterial.Text = ""

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Btn_AgregarC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_AgregarC.Click
        Dim Opcion As Integer = 0
        Try

            If Txt_BuscarColor.Text = "" Then Exit Sub

            Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
                objDataSet = objMySqlGral.usp_TraerDescripcion("AC", Txt_BuscarColor.Text, "C")

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    DGridColor.Rows.Add(objDataSet.Tables(0).Rows(0).Item("idatributo").ToString, _
                                        objDataSet.Tables(0).Rows(0).Item("campo").ToString)

                Else

                    Opcion = 1

                    Using objCatalogoEst As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                        objCatalogoEst.usp_Captura_Atributo(Opcion, Txt_BuscarColor.Text, "C")
                    End Using

                    objDataSet = objMySqlGral.usp_TraerDescripcion("AC", Txt_BuscarColor.Text, "C")

                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        DGridColor.Rows.Add(objDataSet.Tables(0).Rows(0).Item("idatributo").ToString, _
                                            objDataSet.Tables(0).Rows(0).Item("campo").ToString)

                    End If
                End If
            End Using

            Txt_BuscarColor.Text = ""

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Btn_ModAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ModAnterior.Click
        Try
            Tbc_Modelo.SelectedIndex = 0

            If intPosicion <> 0 Then
                intPosicion -= 1
                If intPosicion = 0 Then
                    intPosicion = objDataSetModelos.Tables(0).Rows.Count - 1
                End If
            ElseIf intPosicion = 0 Then
                intPosicion = objDataSetModelos.Tables(0).Rows.Count - 1
            End If

            Txt_Marca.Text = objDataSetModelos.Tables(0).Rows(intPosicion).Item("marca").ToString
            Txt_Modelo.Text = objDataSetModelos.Tables(0).Rows(intPosicion).Item("modelo").ToString

            Txt_Marca_LostFocus(sender, e)
            Txt_Modelo_LostFocus(sender, e)

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Btn_ModSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ModSiguiente.Click
        Try

            Tbc_Modelo.SelectedIndex = 0

            If intPosicion = intTotalRows Then
                intPosicion = 0
            Else
                intPosicion += 1
            End If

            Txt_Marca.Text = objDataSetModelos.Tables(0).Rows(intPosicion).Item("marca").ToString
            Txt_Modelo.Text = objDataSetModelos.Tables(0).Rows(intPosicion).Item("modelo").ToString

            Txt_Marca_LostFocus(sender, e)
            Txt_Modelo_LostFocus(sender, e)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

#End Region
#Region "Funciones"
    Function Inserta_Articulo() As Boolean
        Dim AccionT As Integer = 0
        Using objCatalogoEstilos As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
            'Get a new Project DataSet
            Try

                If Accion = 1 Then
                    AccionT = 1
                ElseIf Accion = 2 Or Accion = 5 Then
                    AccionT = 2
                End If

                objDataSet = objCatalogoEstilos.Inserta_Articulo  'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow

                'Set the values in the DataRow

                objDataRow.Item("marca") = Trim(Txt_Marca.Text)
                objDataRow.Item("estilon") = (Txt_Modelo.Text)
                objDataRow.Item("estilof") = Trim(Txt_Estilof.Text)
                objDataRow.Item("descripc") = Trim(Txt_Descripc.Text)

                objDataSetEstAnt = objCatalogoEstilos.usp_TraerEstConcepto("DE", Txt_Depto.Text, "", "")
                If objDataSetEstAnt.Tables(0).Rows.Count > 0 Then
                    objDataRow.Item("familia") = Trim(objDataSetEstAnt.Tables(0).Rows(0).Item("cveant").ToString)
                Else
                    objDataSetEstAnt = objCatalogoEstilos.usp_TraerEstConcepto("L", Txt_Linea.Text, "", "")
                    If objDataSetEstAnt.Tables(0).Rows.Count > 0 Then
                        objDataRow.Item("familia") = Trim(objDataSetEstAnt.Tables(0).Rows(0).Item("cveant").ToString)
                    Else
                        objDataRow.Item("familia") = "015"
                    End If
                End If

                objDataSetEstAnt = objCatalogoEstilos.usp_TraerEstConcepto("DI", "", "L", Txt_DescripDivision.Text)
                If objDataSetEstAnt.Tables(0).Rows.Count > 0 Then
                    objDataRow.Item("linea") = Trim(objDataSetEstAnt.Tables(0).Rows(0).Item("cveant").ToString)
                Else
                    objDataSetEstAnt = objCatalogoEstilos.usp_TraerEstConcepto("DE", "", "L", Txt_DescripDepto.Text)
                    If objDataSetEstAnt.Tables(0).Rows.Count > 0 Then
                        objDataRow.Item("linea") = Trim(objDataSetEstAnt.Tables(0).Rows(0).Item("cveant").ToString)
                    Else
                        objDataSetEstAnt = objCatalogoEstilos.usp_TraerEstConcepto("F", "", "L", Txt_DescripFamilia.Text)
                        If objDataSetEstAnt.Tables(0).Rows.Count > 0 Then
                            objDataRow.Item("linea") = Trim(objDataSetEstAnt.Tables(0).Rows(0).Item("cveant").ToString)
                        Else
                            objDataSetEstAnt = objCatalogoEstilos.usp_TraerEstConcepto("L", "", "L", Txt_DescripLinea.Text)
                            If objDataSetEstAnt.Tables(0).Rows.Count > 0 Then
                                objDataRow.Item("linea") = Trim(objDataSetEstAnt.Tables(0).Rows(0).Item("cveant").ToString)
                            Else
                                objDataSetEstAnt = objCatalogoEstilos.usp_TraerEstConcepto("S", "", "L", Txt_DescripL1.Text)
                                If objDataSetEstAnt.Tables(0).Rows.Count > 0 Then
                                    objDataRow.Item("linea") = Trim(objDataSetEstAnt.Tables(0).Rows(0).Item("cveant").ToString)
                                Else
                                    objDataSetEstAnt = objCatalogoEstilos.usp_TraerEstConcepto("SS", "", "L", Txt_DescripL2.Text)
                                    If objDataSetEstAnt.Tables(0).Rows.Count > 0 Then
                                        objDataRow.Item("linea") = Trim(objDataSetEstAnt.Tables(0).Rows(0).Item("cveant").ToString)
                                    Else
                                        objDataRow.Item("linea") = "001"
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If

                objDataRow.Item("proveedor") = Trim(Txt_Proveedor.Text)

                objDataSetEstAnt = objCatalogoEstilos.usp_TraerEstConcepto("DI", Txt_Division.Text, "", "")
                If objDataSetEstAnt.Tables(0).Rows.Count > 0 Then
                    objDataRow.Item("tipoart") = Trim(objDataSetEstAnt.Tables(0).Rows(0).Item("cveant").ToString)
                End If

                objDataRow.Item("categoria") = "099"
                objDataRow.Item("descripl") = Trim(Txt_DescripL.Text)
                objDataRow.Item("medida") = Mid(Cbo_Medida.Text, 1, 1)
                objDataRow.Item("acepdevo") = Mid(Cbo_AcepDevo.Text, 1, 1)
                objDataRow.Item("fecha") = Format(Now, "yyyyMMdd") ' Ver
                objDataRow.Item("hora") = Format(Now, "hh:mm:ss")
                objDataRow.Item("resmin") = Val(Txt_Resmin.Text)


                objDataSetEstAnt = objCatalogoEstilos.usp_TraerEstConcepto("F", Txt_Familia.Text, "", "")
                If objDataSetEstAnt.Tables(0).Rows.Count > 0 Then
                    objDataRow.Item("artcat") = Mid(objDataSetEstAnt.Tables(0).Rows(0).Item("cveant").ToString, 1, 1)
                Else
                    objDataRow.Item("artcat") = "D"
                End If


                objDataRow.Item("usumodartcat") = GLB_Usuario
                objDataRow.Item("fummodartcat") = DateTime.Now

                objDataRow.Item("diasinvideal") = Val(Txt_DiasInvIdeal.Text)
                'Add the DataRow to the DataSet
                objDataSet.Tables(0).Rows.Add(objDataRow)

                'Add the Project
                If Not objCatalogoEstilos.usp_Captura_Articulo(AccionT, objDataSet) Then
                    '    Throw New Exception("Falló Inserción de Artículo")
                Else
                    Inserta_Articulo = True
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function
    Function Inserta_EstArticulo() As Boolean
        Dim AccionT As Integer = 0
        Using objCatalogoEstilos As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
            'Get a new Project DataSet
            Try

                If Accion = 1 Then
                    AccionT = 1
                ElseIf Accion = 2 Or Accion = 5 Then
                    AccionT = 2
                End If

                objDataSet = objCatalogoEstilos.Inserta_EstArticulo  'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow

                'Set the values in the DataRow

                objDataRow.Item("idarticulo") = Val(Txt_IdArticulo.Text)
                objDataRow.Item("marca") = Trim(Txt_Marca.Text)
                objDataRow.Item("modelo") = (Txt_Modelo.Text)
                objDataRow.Item("estilof") = Trim(Txt_Estilof.Text)
                objDataRow.Item("descripc") = Trim(Txt_Descripc.Text)
                objDataRow.Item("descripap") = Trim(Txt_Descripap.Text)
                objDataRow.Item("iddivisiones") = Val(Txt_IdDivision.Text)
                objDataRow.Item("iddepto") = Val(Txt_IdDepto.Text)
                objDataRow.Item("idfamilia") = Val(Txt_IdFamilia.Text)
                objDataRow.Item("idlinea") = Val(Txt_IdLinea.Text)
                objDataRow.Item("idl1") = Val(Txt_IdL1.Text)
                objDataRow.Item("idl2") = Val(Txt_IdL2.Text)
                objDataRow.Item("idl3") = Val(Txt_IdL3.Text)
                objDataRow.Item("idl4") = Val(Txt_IdL4.Text)
                objDataRow.Item("idl5") = Val(Txt_IdL5.Text)
                objDataRow.Item("idl6") = Val(Txt_IdL6.Text)
                objDataRow.Item("proveedor") = Trim(Txt_Proveedor.Text)
                objDataRow.Item("idestatributo") = Val(Txt_IdEstAtrib.Text)
                objDataRow.Item("descripl") = Trim(Txt_DescripL.Text)
                objDataRow.Item("medida") = Mid(Cbo_Medida.Text, 1, 1)
                objDataRow.Item("acepdevo") = Mid(Cbo_AcepDevo.Text, 1, 1)
                objDataRow.Item("fecha") = Format(Now, "yyyyMMdd")
                objDataRow.Item("hora") = Format(Now, "hh:mm:ss")
                objDataRow.Item("resmin") = Val(Txt_Resmin.Text)

                objDataRow.Item("diasinvideal") = Val(Txt_DiasInvIdeal.Text)
                objDataRow.Item("vigenciaa") = Format(DT_FecIni.Value, "dd/MM/yyyy")
                If Chk_VentaEnLinea.Checked = True Then
                    objDataRow.Item("ventaenlinea") = 1
                Else
                    objDataRow.Item("ventaenlinea") = 0
                End If


                'Add the DataRow to the DataSet
                objDataSet.Tables(0).Rows.Add(objDataRow)

                'Add the Project
                If Not objCatalogoEstilos.usp_Captura_EstArticulo(AccionT, objDataSet) Then
                    Throw New Exception("Falló Inserción de Artículo")
                Else
                    Inserta_EstArticulo = True
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function
    Function Inserta_Corrida() As Boolean
        Try
            'mreyes 10/Febrero/2012 10:04 a.m.
            Dim Sw_ExisteCorrida As Boolean
            Dim TipoCrr As String = ""
            Dim Margen As Decimal = 0
            Dim TipoCrrBus As String = ""
            Dim CambPrec As String = ""
            Dim PrecioValor As Decimal = 0
            For I As Integer = 0 To DGrid.Rows.Count - 2
                If DGrid.Rows(I).Cells(0).Value.ToString.Length = 0 Then Exit Function
                Using objCatalogoEstilos As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                    'Get a new Project DataSet
                    Try
                        PrecioValor = (DGrid.Rows(I).Cells(6).Value)

                        If Accion = 2 Or Accion = 5 Then
                            Using objCorrida As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)

                                objDataSet = objCorrida.usp_TraerCorrida2(Txt_Marca.Text, Txt_Modelo.Text, Proveedor, DGrid.Rows(I).Cells(0).Value.ToString)

                                If objDataSet.Tables(0).Rows.Count > 0 Then
                                    Sw_ExisteCorrida = True

                                    ' checar los precios 
                                    ''If PrecioValor <> (DGrid.Rows(I).Cells(13).Value) Then 'cambio el precio
                                    ''    If MsgBox("El sistema ha detectado un cambio de precio para la corrida '" & DGrid.Rows(I).Cells(0).Value.ToString & ", Es correcto.?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación Cambio de Precio") = MsgBoxResult.Yes Then

                                    ''        CambPrec = fn_TraerFolioCambPrec("99") 'sucursal de cambio de precio
                                    ''        CambPrec = pub_RellenarIzquierda(CambPrec, 6)

                                    ''        If Inserta_OrdeComp(OrdeComp) = False Then
                                    ''            Throw New Exception("Falló Inserción de Corrida")
                                    ''            Exit Function
                                    ''        End If

                                    ''        If Actualiza_FolioCambPrec("") = False Then
                                    ''            Throw New Exception("Falló Inserción de Corrida")
                                    ''            Exit Function
                                    ''        End If
                                    ''    Else
                                    ''        PrecioValor = (DGrid.Rows(I).Cells(13).Value)
                                    ''    End If
                                    ''End If
                                Else
                                    Sw_ExisteCorrida = False
                                End If
                            End Using
                        End If
                        Margen = DGrid.Rows(I).Cells(6).Value
                        TipoCrrBus = IIf(IsNothing(DGrid.Rows(I).Cells(12).Value), "", DGrid.Rows(I).Cells(12).Value)
                        TipoCrr = CalcularTipoCrr(DGrid.Rows(I).Cells(0).Value.ToString, TipoCrrBus, Margen)

                        Using objCatalogoEst As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                            objDataSet = objCatalogoEst.usp_TraerIdArticulo(Txt_Marca.Text, Txt_Modelo.Text)
                            If objDataSet.Tables(0).Rows.Count > 0 Then
                                Txt_IdArticulo.Text = objDataSet.Tables(0).Rows(0).Item("idarticulo")
                            End If
                        End Using
                        objDataSet = objCatalogoEstilos.Inserta_Corrida  'INSERTA NUEVO DATASET
                        Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow

                        objDataRow.Item("idarticulo") = Val(Txt_IdArticulo.Text)
                        objDataRow.Item("marca") = Trim(Txt_Marca.Text)
                        objDataRow.Item("proveedor") = Proveedor 'Trim(Txt_Proveedor.Text)
                        objDataRow.Item("estilon") = (Txt_Modelo.Text)
                        objDataRow.Item("corrida") = DGrid.Rows(I).Cells(0).Value.ToString
                        objDataRow.Item("iddivisiones") = Val(Txt_IdDivision.Text)
                        If Accion <> 1 Then

                            If DGridC.Rows.Count = DGrid.Rows.Count - 1 Then
                                If DGridC.Rows(I).Cells("col_IdDepto").Value = "" Then
                                    objDataRow.Item("iddepto") = Val(Txt_IdDepto.Text)
                                Else
                                    objDataRow.Item("iddepto") = DGridC.Rows(I).Cells("col_IdDepto").Value
                                End If
                            Else
                                objDataRow.Item("iddepto") = Val(Txt_IdDepto.Text)
                            End If

                        Else
                            objDataRow.Item("iddepto") = Val(Txt_IdDepto.Text)
                        End If
                        objDataRow.Item("idfamilia") = Val(Txt_IdFamilia.Text)
                        objDataRow.Item("idlinea") = Val(Txt_IdLinea.Text)
                        objDataRow.Item("idl1") = Val(Txt_IdL1.Text)
                        objDataRow.Item("idl2") = Val(Txt_IdL2.Text)
                        objDataRow.Item("idl3") = Val(Txt_IdL3.Text)
                        objDataRow.Item("idl4") = Val(Txt_IdL4.Text)
                        objDataRow.Item("idl5") = Val(Txt_IdL5.Text)
                        objDataRow.Item("idl6") = Val(Txt_IdL6.Text)
                        objDataRow.Item("intervalo") = DGrid.Rows(I).Cells(1).Value.ToString
                        objDataRow.Item("medini") = DGrid.Rows(I).Cells(2).Value.ToString
                        objDataRow.Item("medfin") = DGrid.Rows(I).Cells(3).Value.ToString
                        objDataRow.Item("costo") = (DGrid.Rows(I).Cells(4).Value)
                        '                        objDataRow.Item("precio") = (DGrid.Rows(I).Cells(5).Value)
                        objDataRow.Item("precio") = PrecioValor
                        ' NO SE GRABAN SI ES UNA MODIFICACIÓN
                        objDataRow.Item("ult_cmp") = "01-01-1995"
                        objDataRow.Item("ult_vta") = "01-01-1995"
                        objDataRow.Item("blofer") = ""
                        objDataRow.Item("tipocrr") = TipoCrr

                        '' objDataRow.Item("fechor") = Format(Now, "YYYY-MM-DD HH:MM:SS") ' Ver como se graba en la base de datos mysql

                        'Add the DataRow to the DataSet
                        objDataSet.Tables(0).Rows.Add(objDataRow)

                        'Add the Project
                        If Sw_ExisteCorrida = True Then
                            If Not objCatalogoEstilos.usp_Captura_Corrida(2, objDataSet) Then
                                If Accion <> 2 And Accion <> 5 Then
                                    Throw New Exception("Falló Inserción de Corrida")
                                End If
                            End If
                        Else
                            If Not objCatalogoEstilos.usp_Captura_Corrida(1, objDataSet) Then
                                If Accion <> 2 Then
                                    Throw New Exception("Falló Inserción de Corrida")
                                End If
                            End If
                        End If
                        objDataSet.Dispose()
                        objDataRow.Table.Dispose()


                    Catch ExceptionErr As Exception
                        MessageBox.Show(ExceptionErr.Message.ToString)
                    End Try
                End Using
                If Accion = 2 Or Accion = 5 Then
                    If Eliminar_Medida(Trim(Txt_Marca.Text), (Txt_Modelo.Text), DGrid.Rows(I).Cells(0).Value.ToString) = False Then
                        'pensar que poner
                    End If
                End If
                Call Genera_Medida(DGrid.Rows(I).Cells(2).Value.ToString, DGrid.Rows(I).Cells(3).Value.ToString, I)
            Next
            Inserta_Corrida = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function
    Function Inserta_CambPrec(ByVal CambPrec As String) As Boolean
        'mreyes 26/Abril/2012 06:13 p.m.
        Using objCambPrec As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
            'Get a new Project DataSet
            Try

                objDataSet = objCambPrec.Inserta_CambPrec  'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow


                'Set the values in the DataRow

                objDataRow.Item("sucursal") = "99"
                objDataRow.Item("cambprec") = Trim(CambPrec)
                objDataRow.Item("status") = "PA"
                objDataRow.Item("fecha") = Now.Date
                objDataRow.Item("nivel") = "A"
                objDataRow.Item("mlfp") = ""
                objDataRow.Item("porcent") = 0
                objDataRow.Item("observa") = ""
                objDataRow.Item("usuario") = GLB_Usuario
                'Add the DataRow to the DataSet
                objDataSet.Tables(0).Rows.Add(objDataRow)

                'Add the Project
                ''If Not objCambPrec.usp_Captura_OrdeComp(Accion, objDataSet) Then
                ''    '' Throw New Exception("Falló Inserción de OrdeComp")
                ''Else
                ''    Inserta_CambPrec = True
                ''End If
                Inserta_CambPrec = True
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using

    End Function
    Function Inserta_Medida(ByVal Tipo As String, ByVal MedIni As String, ByVal Renglon As Integer) As Boolean
        'mreyes 23/Febrero/2012 01:01 p.m.


        Try
            Using objCatalogoEstilos As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                objDataSet = objCatalogoEstilos.Inserta_Medida  'INSERTA NUEVO DATASET
                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow
                'If Tipo = "N" Then
                '    If Mi < 10 Then
                '        MedIni = pub_RellenarIzquierda(Mi, 2)
                '    End If
                'End If
                objDataRow.Item("idarticulo") = Val(Txt_IdArticulo.Text)
                objDataRow.Item("marca") = Trim(Txt_Marca.Text)
                objDataRow.Item("estilon") = (Txt_Modelo.Text)
                objDataRow.Item("medida") = MedIni
                objDataRow.Item("corrida") = DGrid.Rows(Renglon).Cells(0).Value.ToString
                objDataRow.Item("ctdcri") = 0
                objDataRow.Item("ctdide") = 0
                objDataRow.Item("ctdsol") = 0
                objDataRow.Item("orden") = "00"

                'Add the DataRow to the DataSet
                objDataSet.Tables(0).Rows.Add(objDataRow)


                If Not objCatalogoEstilos.usp_Captura_Medida(1, objDataSet) Then
                    If Accion <> 2 And Accion <> 5 Then
                        Throw New Exception("Falló Inserción de Medida")
                    End If
                End If

            End Using
            Inserta_Medida = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function
    Function Genera_Medida(ByVal MedIni As String, ByVal MedFin As String, ByVal I As Integer) As Boolean
        'mreyes 23/Febrero/2012 12:42 p.m
        '' LA MEDIDA VA A CONSIDERACIÓN DEL INTERVALO... OJO PARA LOS NUMEROS 
        Try
            Dim MI As Integer = 0
            Dim MF As Integer = 0
            Dim Intervalo As String = ""
            Dim Inc As Integer = 0



            Select Case Mid(Cbo_Medida.Text, 1, 1)

                Case "N"
                    '' CASO DE NUMEROS 

                    MI = Val(DGrid.Rows(I).Cells(2).Value)
                    MF = Val(DGrid.Rows(I).Cells(3).Value)
                    Intervalo = DGrid.Rows(I).Cells(1).Value

                    For MI = Val(DGrid.Rows(I).Cells(2).Value) To MF
                        '' tomar en cuenta el intervalo para grabar el valor ...
                        If Intervalo <> "-" Then
                            Inc = Intervalo
                        Else
                            Inc = 1
                        End If
                        '' insertar medida 
                        If MI = Val(MedIni) Then
                            If MedIni.Substring(MedIni.Length - 1, 1) <> "-" Then
                                Call Inserta_Medida("N", pub_RellenarIzquierda(MI, 2), I)
                            End If
                        Else
                            Call Inserta_Medida("N", pub_RellenarIzquierda(MI, 2), I)
                        End If
                        If Intervalo = "-" Then
                            If MedFin = CStr(MI) Then
                                'If MedFin.Substring(MedFin.Length - 1, 1) = "-" Then
                                '    Call Inserta_Medida("N", pub_RellenarIzquierda(MI, 2) + Intervalo, I)
                                'End If
                            Else
                                Call Inserta_Medida("N", pub_RellenarIzquierda(MI, 2) + Intervalo, I)
                            End If
                        End If
                        MI = MI + Inc - 1

                    Next
                Case Else
                    ' LETRS O SIN NADA 

                    Using objCatalogoEstilos As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                        Try

                            Dim Medida As String = ""
                            Dim OrdeIni As String = DGrid.Rows(I).Cells("ORDENFIN").Value
                            Dim OrdeFin As String = DGrid.Rows(I).Cells("ORDENFIN").Value

                            Dim objDataSet = objCatalogoEstilos.usp_TraerLetrasIniFin(OrdeIni, OrdeFin, Mid(Cbo_Medida.Text, 1, 1))

                            If objDataSet.Tables(0).Rows.Count > 0 Then
                                For z As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                                    Medida = objDataSet.Tables(0).rows(z).item("medida").ToString
                                    Call Inserta_Medida(Mid(Cbo_Medida.Text, 1, 1), Medida, I)
                                Next
                            End If
                        Catch ExceptionErr As Exception
                            MessageBox.Show(ExceptionErr.Message.ToString)
                        End Try
                    End Using


            End Select
            Genera_Medida = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function
    Private Function ValidarEdicion() As Boolean
        'mreyes 03/Marzo/2012 11:23 a.m. 
        ValidarEdicion = False
        Try
            If Txt_Marca.Text.Length = 0 Then
                MsgBox("Debe especificar una marca para el Modelo.", MsgBoxStyle.Critical, "Validación")
                Tbc_Modelo.SelectedIndex = 0
                Txt_Marca.Focus()
                Exit Function
            End If

            If Txt_Estilof.Text.Length = 0 Then
                MsgBox("Debe especificar el estilo de fábrica para el Modelo.", MsgBoxStyle.Critical, "Validación")
                Tbc_Modelo.SelectedIndex = 0
                Txt_Estilof.Focus()
                Exit Function
            End If

            If Txt_Descripc.Text.Length = 0 Then
                MsgBox("Debe especificar una descripción corta para el Modelo.", MsgBoxStyle.Critical, "Validación")
                Tbc_Modelo.SelectedIndex = 0
                Txt_Descripc.Focus()
                Exit Function
            End If

            'If Txt_Descripap.Text.Length = 0 Then
            '    MsgBox("Debe especificar una descripción de aparador para el Modelo.", MsgBoxStyle.Critical, "Validación")
            '    Tbc_Modelo.SelectedIndex = 0
            '    Txt_Descripc.Focus()
            '    Exit Function
            'End If

            If Txt_Division.Text.Length = 0 Then
                MsgBox("Debe especificar una Division para el Modelo.", MsgBoxStyle.Critical, "Validación")
                Tbc_Modelo.SelectedIndex = 0
                Txt_Descripc.Focus()
                Exit Function
            End If

            If Txt_Depto.Text.Length = 0 Then
                MsgBox("Debe especificar una Departamento para el Modelo.", MsgBoxStyle.Critical, "Validación")
                Tbc_Modelo.SelectedIndex = 0
                Txt_Descripc.Focus()
                Exit Function
            End If

            'If Txt_Familia.Text.Length = 0 Then
            '    MsgBox("Debe especificar una Familia para el Modelo.", MsgBoxStyle.Critical, "Validación")
            '    Tbc_Modelo.SelectedIndex = 0
            '    Txt_Familia.Focus()
            '    Exit Function
            'End If

            'If Txt_Linea.Text.Length = 0 Then
            '    MsgBox("Debe especificar una Línea para el Modelo.", MsgBoxStyle.Critical, "Validación")
            '    Tbc_Modelo.SelectedIndex = 0
            '    Txt_Linea.Focus()
            '    Exit Function
            'End If

            'If Txt_SubLinea.Text.Length = 0 Then
            '    MsgBox("Debe especificar una SubLínea para el Modelo.", MsgBoxStyle.Critical, "Validación")
            '    Tbc_Modelo.SelectedIndex = 0
            '    Txt_Linea.Focus()
            '    Exit Function
            'End If

            'If Txt_SSubLinea.Text.Length = 0 Then
            '    MsgBox("Debe especificar una Sub - SubLínea para el Modelo.", MsgBoxStyle.Critical, "Validación")
            '    Tbc_Modelo.SelectedIndex = 0
            '    Txt_Linea.Focus()
            '    Exit Function
            'End If

            'If Txt_SSSubLinea.Text.Length = 0 Then
            '    MsgBox("Debe especificar una Sub - SubSubLínea para el Modelo.", MsgBoxStyle.Critical, "Validación")
            '    Tbc_Modelo.SelectedIndex = 0
            '    Txt_Linea.Focus()
            '    Exit Function
            'End If


            If Txt_Proveedor.Text.Length = 0 Then
                MsgBox("Debe especificar un Proveedor para el Modelo.", MsgBoxStyle.Critical, "Validación")
                Tbc_Modelo.SelectedIndex = 0
                Txt_L1.Focus()
                Exit Function
            End If

            If Cbo_Medida.Text.Length = 0 Then
                MsgBox("Debe especificar una medida para el Modelo.", MsgBoxStyle.Critical, "Validación")
                Tbc_Modelo.SelectedIndex = 0
                Cbo_Medida.Focus()
                Exit Function
            End If

            If Cbo_AcepDevo.Text.Length = 0 Then
                MsgBox("Debe especificar si acepta o no devoluciones para el Modelo.", MsgBoxStyle.Critical, "Validación")
                Tbc_Modelo.SelectedIndex = 0
                Cbo_AcepDevo.Focus()
                Exit Function
            End If

            If Txt_Resmin.Text.Length = 0 Then
                MsgBox("Debe especificar el ResMin para el Modelo.", MsgBoxStyle.Critical, "Validación")
                Tbc_Modelo.SelectedIndex = 0
                Txt_Resmin.Focus()
                Exit Function
            End If

            'If Cbo_Clasif.Text.Length = 0 Then
            '    MsgBox("Debe especificar una Clasificación para el Modelo.", MsgBoxStyle.Critical, "Validación")
            '    Tbc_Modelo.SelectedIndex = 0
            '    Cbo_AcepDevo.Focus()
            '    Exit Function
            'End If

            '' validar corrida 

            If Sw_RegistroCorrida = True Then
                If ProveedorB = "" Then
                    MsgBox("Debe seleccionar un proveedor para asignar las corridas.", MsgBoxStyle.Critical, "Validación")
                    Exit Function
                End If
            End If


            If ProveedorB <> "" Then
                Proveedor = ProveedorB

            ElseIf Proveedor = "" Then
                Proveedor = Txt_Proveedor.Text
            End If

            With DGrid
                If .Rows(0).Cells(0).Value = "" Then
                    MsgBox("Debe especificar al menos una corrida para el Modelo.", MsgBoxStyle.Critical, "Validación")
                    Tbc_Modelo.SelectedIndex = 2
                    DGrid.Focus()
                    Exit Function
                End If
            End With

            'If Accion = 2 Then
            '    If Corrida = "" Then
            '        MsgBox("Debe especificar al menos una corrida para el Modelo.", MsgBoxStyle.Critical, "Validación")
            '        Tbc_Modelo.SelectedIndex = 2
            '        DGrid.Focus()
            '        Exit Function
            '    End If
            'End If


            'If DGridMat.Rows.Count < 2 AndAlso DGridColor.Rows.Count < 2 Then
            '    MsgBox("Debe agregar por lo menos un atributo para el Modelo.", MsgBoxStyle.Critical, "Validación")
            '    Tbc_Modelo.SelectedIndex = 1
            '    Txt_BuscarMaterial.Focus()
            '    Exit Function
            'End If


            With DGrid2
                If .Rows(0).Cells(0).Value = "" Then
                    MsgBox("Debe seleccionar el proveedor del Modelo.", MsgBoxStyle.Critical, "Validación")
                    Tbc_Modelo.SelectedIndex = 2
                    DGrid.Focus()
                    Exit Function
                End If
            End With

            With DGridC
                If .Rows.Count > 0 Then
                    If .Rows(0).Cells("col_depto").Value = "" Then
                        MsgBox("Debe asignar un departamento a cada corrida del Modelo.", MsgBoxStyle.Critical, "Validación")
                        Tbc_Modelo.SelectedIndex = 0
                        DGridC.Focus()
                        Exit Function
                    End If
                End If
            End With


            With DgridSuc
                If .Rows.Count > 0 Then
                    If .Rows(0).Cells("corrida").Value Is Nothing Then
                        MsgBox("Debe seleccionar una corrida para el detalle de sucursal del Modelo.", MsgBoxStyle.Critical, "Validación")
                        Tbc_Modelo.SelectedIndex = 2
                        DGrid.Focus()
                        Exit Function
                    Else
                        Corrida = DgridSuc.Rows(DgridSuc.CurrentRow.Index).Cells("corrida").Value.ToString
                    End If
                End If
            End With

            'If DgridSuc.Rows(DgridSuc.CurrentRow.Index).Cells("corrida").Value Is Nothing Then
            '    MsgBox("Debe seleccionar una corrida para el detalle de sucursal del Modelo.", MsgBoxStyle.Critical, "Validación")
            '    Tbc_Modelo.SelectedIndex = 2
            '    DGrid.Focus()
            '    Exit Function
            'Else
            '    Corrida = DgridSuc.Rows(DgridSuc.CurrentRow.Index).Cells("corrida").Value.ToString
            'End If


            If IsDBNull(DgridSuc.Rows(DgridSuc.CurrentRow.Index).Cells("precio").Value) Then
                MsgBox("Debe seleccionar una corrida para el detalle de sucursal del Modelo.", MsgBoxStyle.Critical, "Validación")
                Tbc_Modelo.SelectedIndex = 2
                DGrid.Focus()
                Exit Function
            Else
                Precio = DgridSuc.Rows(DgridSuc.CurrentRow.Index).Cells("precio").Value.ToString
            End If
            'With DgridSuc
            '    If .Rows(0).Cells("precio").Value = Nothing Then
            '        MsgBox("Debe especificar una corrida para guardar el detalle de sucursales para el Modelo.", MsgBoxStyle.Critical, "Validación")
            '        Tbc_Modelo.SelectedIndex = 2
            '        DgridSuc.Focus()
            '        Exit Function
            '    End If
            'End With


            If blnCambiaCorrida = True Then
                Using objCatalogoModelos As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                    Try
                        objDataSet = objCatalogoModelos.usp_TraerPedidoPendienteModelo(Txt_Marca.Text, Txt_Modelo.Text, Date.Now)
                        If objDataSet.Tables(0).Rows.Count > 0 Then
                            MsgBox("No puede modificar la corrida del Modelo, ya que cuenta con Pedidos Pendientes.", MsgBoxStyle.Critical, "Validación")
                            Exit Function
                        End If
                    Catch ExceptionErr As Exception
                        MessageBox.Show(ExceptionErr.Message.ToString)
                    End Try
                End Using
            End If
            'checar dias de inventario ideal
            If Val(Txt_DiasInvIdeal.Text) = 0 Then

                If Txt_DescripDepto.Text = "DAMAS" Then
                    If Txt_DescripL1.Text = "BOTA" Or Txt_DescripL1.Text = "BOTIN" Or Txt_DescripL1.Text = "SANDALIA" Or Txt_DescripL1.Text = "TENIS" Or Txt_DescripL1.Text = "VALERINA" Then
                        Txt_DiasInvIdeal.Text = "60"
                    End If

                    If Txt_DescripL1.Text = "CLINICO" Then
                        Txt_DiasInvIdeal.Text = "0"
                    End If

                    If Txt_DescripL1.Text = "CONFORT" Then
                        Txt_DiasInvIdeal.Text = "120"
                    End If

                    If Txt_DescripL1.Text = "ESCOLAR" Then
                        Txt_DiasInvIdeal.Text = "180"
                    End If
                    If Txt_DescripL1.Text = "ZAPATILLA" Then
                        Txt_DiasInvIdeal.Text = "90"
                    End If

                End If


                If Txt_DescripDepto.Text = "INFANTIL" And Txt_DescripLinea.Text = "NIÑA" Then
                    If Txt_DescripL1.Text = "BOTA" Or Txt_DescripL1.Text = "BOTIN" Or Txt_DescripL1.Text = "CASUAL" Or Txt_DescripL1.Text = "VESTIR" Or Txt_DescripL1.Text = "CONFORT" Or Txt_DescripL1.Text = "TENIS" Or Txt_DescripL1.Text = "VALERINA" Then
                        Txt_DiasInvIdeal.Text = "75"
                    End If

                    If Txt_DescripL1.Text = "CLINICO" Then
                        Txt_DiasInvIdeal.Text = "0"
                    End If

                    If Txt_DescripL1.Text = "ESCOLAR" Then
                        Txt_DiasInvIdeal.Text = "180"
                    End If
       
                    If Txt_DescripL1.Text = "SANDALIA" Then
                        Txt_DiasInvIdeal.Text = "60"
                    End If

                End If



                If Txt_DescripDepto.Text = "CABALLEROS" Then
                    If Txt_DescripL1.Text = "BOTIN" Or Txt_DescripL1.Text = "TENIS" Or Txt_DescripL1.Text = "VESTIR" Then
                        Txt_DiasInvIdeal.Text = "90"
                    End If

                    If Txt_DescripL1.Text = "CASUAL" Then
                        Txt_DiasInvIdeal.Text = "60"
                    End If
                    If Txt_DescripL1.Text = "CLINICO" Then
                        Txt_DiasInvIdeal.Text = "0"
                    End If
                    If Txt_DescripL1.Text = "CONFORT" Then
                        Txt_DiasInvIdeal.Text = "120"
                    End If
                    If Txt_DescripL1.Text = "SANDALIA" Then
                        Txt_DiasInvIdeal.Text = "75"
                    End If
                End If



                If Txt_DescripDepto.Text = "INFANTIL" And Txt_DescripLinea.Text = "NIÑO" Then
                    If Txt_DescripL1.Text = "CASUAL" Then
                        Txt_DiasInvIdeal.Text = "75"
                    End If

                    If Txt_DescripL1.Text = "CLINICO" Then
                        Txt_DiasInvIdeal.Text = "0"
                    End If

                    If Txt_DescripL1.Text = "CONFORT" Or Txt_DescripL1.Text = "SANDALIA" Or Txt_DescripL1.Text = "TENIS" Then
                        Txt_DiasInvIdeal.Text = "60"
                    End If

                    If Txt_DescripL1.Text = "ESCOLAR" Then
                        Txt_DiasInvIdeal.Text = "180"
                    End If


                End If

                If Txt_DescripDepto.Text = "BEBES" Then



                    If Txt_DescripL1.Text = "BOTA" Or Txt_DescripL1.Text = "CASUAL" Or Txt_DescripL1.Text = "CEREMONIA" Or Txt_DescripL1.Text = "SANDALIA" Or Txt_DescripL1.Text = "TENIS" Then
                        Txt_DiasInvIdeal.Text = "180"
                    End If

  


                End If




            End If





            '' termina dias de inventario ideal 

            ValidarEdicion = True
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Function
    Private Function Eliminar_Medida(ByVal Marca As String, ByVal Estilon As String, ByVal corrida As String) As Boolean
        'mreyes 23/Febrero/2012 03:47 p.m.
        'marca, estilo, medida, corrida
        Using objCatalogoEstilos As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
            Try
                'Get the specific project selected in the ListView control
                Eliminar_Medida = objCatalogoEstilos.usp_EliminarMedida(Marca, Estilon, corrida)
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function
    Private Function TraerFoto(ByVal NoFoto As String) As Boolean
        'mreyes 02/Marzo/2012 04:57 p.m.
        Try
            TraerFoto = False
            Dim Archivo As String = ""
            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)
                Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Modelo.Text, NoFoto)
                If objIO.pub_ExisteArchivo(Archivo) = True Then
                    PBox.Image = New System.Drawing.Bitmap(Archivo)
                    PBox2.Image = New System.Drawing.Bitmap(Archivo)
                    TraerFoto = True
                    Exit Function
                End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function
    Private Function BuscarImagenSig() As String
        'mreyes 02/Marzo/2012 06:04 p.m.
        Try
            Dim Archivo As String = ""
            BuscarImagenSig = Txt_NoFoto.Text
            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)
                For i As Integer = Val(Txt_NoFoto.Text) To 9

                    Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Modelo.Text, i)
                    If objIO.pub_ExisteArchivo(Archivo) = False Then

                        BuscarImagenSig = i
                        Txt_NoFoto.Text = BuscarImagenSig
                        Exit Function
                    End If
                Next
            End Using
            BuscarImagenSig = 1
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function
    Function Inserta_ArtFotos(ByVal Opcion As Integer) As Boolean
        'mreyes 26/Marzo/2012 04:10 p.m.

        Using objCatalogoEstilos As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
            'Get a new Project DataSet
            Try
                objDataSet = objCatalogoEstilos.Inserta_ArtFotos  'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow

                'Set the values in the DataRow

                objDataRow.Item("marca") = Trim(Txt_Marca.Text)
                objDataRow.Item("estilon") = (Txt_Modelo.Text)
                objDataRow.Item("fotoart") = Txt_NoFoto.Text
                objDataRow.Item("fecha") = Format(Now.Date, "yyyyMMdd")
                objDataRow.Item("hora") = Format(Now, "hh:mm:ss")
                'Add the DataRow to the DataSet
                objDataSet.Tables(0).Rows.Add(objDataRow)

                'Add the Project
                If Not objCatalogoEstilos.usp_Captura_ArtFotos(Opcion, objDataSet) Then
                    Throw New Exception("Falló Inserción de Artículo")
                Else
                    Inserta_ArtFotos = True
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function
    Private Function CalcularTipoCrr(ByVal Corrida As String, ByVal TipoCrr As String, ByVal Margen As Decimal) As String
        'mreyes 13/Abril/2012 11:47 a.m.
        Using objPedidos As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
            Try
                Dim objDataSet As Data.DataSet

                CalcularTipoCrr = ""

                Dim pTipo As String = ""
                Dim ptcr As String = ""
                objDataSet = objPedidos.usp_TraerClasifMargen
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    For I As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                        If "7" <= TipoCrr And TipoCrr <= "9" Then
                            pTipo = "7"
                        ElseIf "4" <= TipoCrr And TipoCrr <= "6" Then
                            pTipo = "4"
                        ElseIf TipoCrr = "" Then
                            pTipo = "7"
                        Else
                            pTipo = "1"
                        End If
                        ptcr = Trim(Str(pTipo + (3 - Val(objDataSet.Tables(0).Rows(0).Item("orden")))))
                        If Margen >= objDataSet.Tables(0).Rows(0).Item("porcent") And ptcr <> TipoCrr Then
                            CalcularTipoCrr = ptcr
                            Exit Function
                        End If
                    Next
                End If




            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
                CalcularTipoCrr = ""
            End Try
        End Using
    End Function
#End Region
#Region "Métodos"

    Private Sub usp_TraerCorrida(ByVal EstiloN As String)
        Using objCatalogoEstilos As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
            Try
                Dim Margen As Decimal
                Dim PComp As Decimal
                Dim Precio As Decimal

                'Corrida = DGrid.Rows(0).Cells("col1").Value
                Proveedor = Txt_Proveedor.Text

                If Proveedor = Nothing Then
                    Proveedor = ""
                End If

                objDataSet = objCatalogoEstilos.usp_TraerCorrida2(Txt_Marca.Text, EstiloN, Txt_Proveedor.Text, "")

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    For I As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                        Costo = pub_CalcularCostoPedido((objDataSet.Tables(0).Rows(I).Item(8)), Val(Txt_Dsctopp.Text), Val(Txt_Dscto01.Text), Val(Txt_Dscto02.Text), Val(Txt_Dscto03.Text), Val(Txt_Dscto04.Text), Val(Txt_Dscto05.Text), Val(Txt_Iva.Text))
                        Precio = Val(objDataSet.Tables(0).Rows(I).Item("precio"))
                        PComp = Val(objDataSet.Tables(0).Rows(I).Item("costo"))
                        Margen = pub_CalcularMargenPedido(Precio, Costo)

                        DGrid.Rows.Add(objDataSet.Tables(0).Rows(I).Item("corrida").ToString, _
                                         objDataSet.Tables(0).Rows(I).Item("intervalo").ToString, _
                                         objDataSet.Tables(0).Rows(I).Item("medini").ToString, _
                                         objDataSet.Tables(0).Rows(I).Item("medfin").ToString, _
                                         Val(objDataSet.Tables(0).Rows(I).Item("costo")), _
                                         Costo, _
                                         Val(objDataSet.Tables(0).Rows(I).Item("precio")), _
                                         Margen, _
                                         objDataSet.Tables(0).Rows(I).Item("precdesc").ToString, _
                                         "", "", _
                                        objDataSet.Tables(0).Rows(I).Item("ordenini").ToString, _
                                        objDataSet.Tables(0).Rows(I).Item("ordenfin").ToString, _
                                        objDataSet.Tables(0).Rows(I).Item("tipocrr").ToString, _
                                        Val(objDataSet.Tables(0).Rows(I).Item("precio")))

                        DGridC.Rows.Add(objDataSet.Tables(0).Rows(I).Item(2).ToString, _
                                         objDataSet.Tables(0).Rows(I).Item(5).ToString, _
                                         objDataSet.Tables(0).Rows(I).Item(6).ToString, _
                                         objDataSet.Tables(0).Rows(I).Item(7).ToString, _
                                         objDataSet.Tables(0).Rows(I).Item(3).ToString, _
                                          objDataSet.Tables(0).Rows(I).Item(4).ToString)

                    Next

                    For j As Integer = 0 To DgridSuc.Rows.Count - 2
                        DgridSuc.Rows(j).Cells("precio").Value = objDataSet.Tables(0).Rows(0).Item("precio")
                        DgridSuc.Rows(j).Cells("corrida").Value = objDataSet.Tables(0).Rows(0).Item("corrida")
                    Next

                End If

                'Corrida = DGrid.Rows(0).Cells("col1").Value

                If Accion <> 5 Then
                    Call RellenaGridSuc()
                End If

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub
    Private Sub validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        '' FUNCION PARA SOLO ESCRIBIR LETRAS EN UN DATAGRID 
        Try
            ' obtener indice de la columna  
            If Accion = 3 Or Accion = 4 Then
                e.KeyChar = Chr(0)
                Exit Sub
            End If
            e.KeyChar = UCase(e.KeyChar)
            Dim columna As Integer = DGrid.CurrentCell.ColumnIndex
            Dim caracter As Char = e.KeyChar
            ' comprobar si la celda en edición corresponde a la columna 1 o 3   

            If columna = 0 Then ''columna de corrida

                ' Obtener caracter   


                ' comprobar si el caracter es un número o el retroceso   
                If Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
                    'Me.Text = e.KeyChar   
                    e.KeyChar = Chr(0)
                Else
                    If caracter = "A" Or caracter = "B" Or caracter = "C" Or caracter = "D" Or caracter = "E" Or caracter = "F" Then
                        e.KeyChar = UCase(caracter)
                    Else
                        e.KeyChar = Chr(0)
                    End If
                End If

                'If Accion = 2 Then
                '    blnCambiaCorrida = True
                'End If
            End If

            If columna = 1 Then '' columna de i
                If Mid(Cbo_Medida.Text, 1, 1) = "N" Then
                    If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False And Not caracter = "-" Then
                        e.KeyChar = Chr(0)
                    End If
                End If

                'If Accion = 2 Then
                '    blnCambiaCorrida = True
                'End If
            End If

            ''If Accion <> 1 Then
            ''    If columna = 5 Then
            ''        e.KeyChar = Chr(0)
            ''    End If
            ''End If

            If columna >= 4 And columna <= 5 Then

                If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False And Not (caracter = ".") Then
                    e.KeyChar = Chr(0)
                End If

                'If Accion = 2 Then
                '    blnCambiaCorrida = True
                'End If
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub validar_Keypress2(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Try
            ' obtener indice de la columna  
            If Accion = 3 Or Accion = 4 Then
                e.KeyChar = Chr(0)
                Exit Sub
            End If
            e.KeyChar = UCase(e.KeyChar)
            Dim columna As Integer = DGridC.CurrentCell.ColumnIndex
            Dim caracter As Char = e.KeyChar
            ' comprobar si la celda en edición corresponde a la columna 1 o 3   

            If columna = 0 Then ''columna de corrida

                ' Obtener caracter   


                ' comprobar si el caracter es un número o el retroceso   
                If Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
                    'Me.Text = e.KeyChar   
                    e.KeyChar = Chr(0)
                Else
                    'If caracter = "A" Or caracter = "B" Or caracter = "C" Or caracter = "D" Or caracter = "E" Or caracter = "F" Then
                    '    e.KeyChar = UCase(caracter)
                    'Else
                    '    e.KeyChar = Chr(0)
                    'End If
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub InicializaGridProv()
        DGrid2.RowHeadersVisible = False
        ''DGrid.AllowUserToResizeColumns = True


        DGrid2.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGrid2.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DGrid2.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


        DGrid2.Columns(2).DefaultCellStyle.Format = "c"

        'Call AgregarColumna()

        DGrid2.Columns(1).ReadOnly = True

        DGrid2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    End Sub
    Private Sub usp_Traer_MarcaProvCosto(ByVal Marca As String)
        Dim Proveedor As String
        Dim Raz_soc As String
        Dim Costo As Decimal

        Try

            Using objCatalogoMarca As New BCL.BCLCatalogoMarca(GLB_ConStringCipSis)
                objDataSet = objCatalogoMarca.usp_Traer_MarcaProvCosto(Marca)

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_Proveedor.Text = objDataSet.Tables(0).Rows(0).Item("proveedor")
                    If objDataSet.Tables(0).Rows.Count = 1 Then
                        ProveedorB = objDataSet.Tables(0).Rows(0).Item("proveedor")
                    Else
                        ProveedorB = ""
                    End If

                    For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                        Proveedor = objDataSet.Tables(0).Rows(i).Item("proveedor")
                        Raz_soc = objDataSet.Tables(0).Rows(i).Item("raz_soc")
                        Costo = Val(objDataSet.Tables(0).Rows(i).Item("costo"))

                        DGrid2.Rows.Add(objDataSet.Tables(0).Rows(i).Item(1).ToString, _
                                        objDataSet.Tables(0).Rows(i).Item(2).ToString, _
                                        Val(objDataSet.Tables(0).Rows(i).Item(3)))

                    Next

                    Call MarcaProveedorCorrida()

                End If


            End Using

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub MarcaProveedorCorrida()
        Try
            Using objCatalogoEst As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                For row As Integer = 0 To DGrid2.Rows.Count - 1
                    objDataSet = objCatalogoEst.usp_TraerCorrida2(Txt_Marca.Text, Txt_Modelo.Text, DGrid2.Rows(row).Cells("col_Proveedor").Value, "")

                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        DGrid2.Rows(row).DefaultCellStyle.BackColor = Color.Yellow
                        DGrid2.CurrentCell = DGrid2.Rows(row).Cells("col_proveedor")
                    End If
                Next
            End Using


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub usp_TraerDetSucArt(ByVal Marca As String, ByVal Estilon As String)
        'Dim Corrida As String = ""
        'Dim Proveedor As String = ""
        Try

            'Tbc_Modelo.SelectedIndex = 2
            'Proveedor = DGrid2.CurrentRow.Cells("col_Proveedor").Value
            'Corrida = DGrid.Rows(DGrid.CurrentRow.Index).Cells("Columna1").Value

            Using objCatalogoEst As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                objDataSetSuc = objCatalogoEst.usp_TraerDetSucArt(Marca, Proveedor, Estilon, Corrida)

                If objDataSetSuc.Tables(0).Rows.Count > 0 Then

                    If DgridSuc.Rows.Count <> 0 Then
                        For i As Integer = 0 To DgridSuc.Rows.Count - 2
                            If DgridSuc.Rows(i).Cells("Selec").Value = True Then
                                DgridSuc.Rows(i).Cells("Selec").Value = False
                            End If
                        Next

                        For i As Integer = 0 To objDataSetSuc.Tables(0).Rows.Count - 1
                            For j As Integer = 0 To DgridSuc.Rows.Count - 2
                                If DgridSuc.Rows(j).Cells("sucursal").Value = objDataSetSuc.Tables(0).Rows(i).Item("sucursal").ToString Then
                                    DgridSuc.Rows(j).Cells("Selec").Value = True
                                    DgridSuc.Rows(j).Cells("precio").Value = objDataSetSuc.Tables(0).Rows(i).Item("precio")
                                End If
                            Next
                        Next
                    End If

                Else

                    objDataSetSuc = objCatalogoEst.usp_TraerDetSucArt(Marca, "", "", "")

                    If objDataSetSuc.Tables(0).Rows.Count > 0 Then
                        For i As Integer = 0 To DgridSuc.Rows.Count - 2
                            If DgridSuc.Rows(i).Cells("Selec").Value = True Then
                                DgridSuc.Rows(i).Cells("Selec").Value = False
                            End If
                        Next

                        For i As Integer = 0 To objDataSetSuc.Tables(0).Rows.Count - 1
                            For j As Integer = 0 To DgridSuc.Rows.Count - 2
                                If DgridSuc.Rows(j).Cells("sucursal").Value = objDataSetSuc.Tables(0).Rows(i).Item("sucursal").ToString Then
                                    DgridSuc.Rows(j).Cells("Selec").Value = True
                                    DgridSuc.Rows(j).Cells("precio").Value = objDataSetSuc.Tables(0).Rows(i).Item("precio")
                                End If
                            Next
                        Next
                    End If

                End If

                'Tbc_Modelo.SelectedIndex = 0
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub usp_TraerAtributosModelo(ByVal IdArticulo As Integer)
        Try

            'Tbc_Modelo.SelectedIndex = 1

            Using objCatalogoEst As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                objDataSet = objCatalogoEst.usp_TraerAtributosModelo(IdArticulo)
                If objDataSet.Tables(0).Rows.Count > 0 Then

                    DGridMat.ReadOnly = True

                    For I As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                        If objDataSet.Tables(0).Rows(I).Item(3).ToString = "M" Then
                            DGridMat.Rows.Add(objDataSet.Tables(0).Rows(I).Item(0).ToString, _
                                                 objDataSet.Tables(0).Rows(I).Item(1).ToString)
                        ElseIf objDataSet.Tables(0).Rows(I).Item(3).ToString = "C" Then
                            DGridColor.Rows.Add(objDataSet.Tables(0).Rows(I).Item(0).ToString, _
                                                 objDataSet.Tables(0).Rows(I).Item(1).ToString)
                        End If
                    Next

                    Txt_IdEstAtrib.Text = objDataSet.Tables(0).Rows(0).Item(2).ToString
                End If

                'Tbc_Modelo.SelectedIndex = 0
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub GuardarDetalleSucursal()
        Dim Opcion As Integer = 0
        Dim Guardo As Boolean = False
        Try

            If Accion = 1 Then
                Opcion = 1
                For i As Integer = 0 To DgridSuc.Rows.Count - 1

                    If DgridSuc.Rows(i).Cells("selec").Value = True Then
                        Dim Sucursal As String = DgridSuc.Rows(i).Cells("sucursal").Value.ToString
                        Dim Marca As String = Txt_Marca.Text
                        Dim Proveedor As String = DGrid2.Rows(DGrid2.CurrentRow.Index).Cells("col_Proveedor").Value.ToString
                        Dim Estilon As String = Txt_Modelo.Text
                        Dim Corrida As String = DgridSuc.Rows(DgridSuc.CurrentRow.Index).Cells("corrida").Value.ToString
                        Dim Precio As Decimal = DgridSuc.Rows(DgridSuc.CurrentRow.Index).Cells("precio").Value.ToString

                        Using objCatalogoEst As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                            objCatalogoEst.usp_Captura_DetSucArt(Opcion, Sucursal, Marca, Proveedor, Estilon, Corrida, Precio, GLB_Idempleado)
                        End Using

                    End If
                Next

            ElseIf Accion = 2 Or Accion = 5 Then

                Opcion = 2

                Dim Marca As String = Txt_Marca.Text
                Dim Proveedor As String = DGrid2.Rows(DGrid2.CurrentRow.Index).Cells("col_Proveedor").Value.ToString
                Dim Estilon As String = Txt_Modelo.Text
                Dim Corrida As String = DgridSuc.Rows(DgridSuc.CurrentRow.Index).Cells("corrida").Value.ToString
                Dim Precio As Decimal = DgridSuc.Rows(DgridSuc.CurrentRow.Index).Cells("precio").Value.ToString

                'If DgridSuc.Rows(DgridSuc.CurrentRow.Index).Cells("corrida").Value Is Nothing Then
                '    MsgBox("Debe seleccionar una corrida para el detalle de sucursal del Modelo.", MsgBoxStyle.Critical, "Validación")
                '    Tbc_Modelo.SelectedIndex = 2
                '    DGrid.Focus()
                '    Exit Sub
                'Else
                '    Corrida = DgridSuc.Rows(DgridSuc.CurrentRow.Index).Cells("corrida").Value.ToString
                'End If


                'If IsDBNull(DgridSuc.Rows(DgridSuc.CurrentRow.Index).Cells("precio").Value) Then
                '    MsgBox("Debe seleccionar una corrida para el detalle de sucursal del Modelo.", MsgBoxStyle.Critical, "Validación")
                '    Tbc_Modelo.SelectedIndex = 2
                '    DGrid.Focus()
                '    Exit Sub
                'Else
                '    Precio = DgridSuc.Rows(DgridSuc.CurrentRow.Index).Cells("precio").Value.ToString
                'End If

                Using objCatalogoEst As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                    'objDataSetSuc = objCatalogoEst.usp_TraerDetSucArt(Marca, Proveedor, Estilon, Corrida)

                    'If objDataSetSuc.Tables(0).Rows.Count > 0 Then
                    'objCatalogoEst.usp_Captura_DetSucArt(Opcion, "", Marca, Proveedor, Estilon, Corrida, 0, GLB_Idempleado)
                    'End If

                    '''For j As Integer = 0 To DGrid.Rows.Count - 2
                    'Corrida = DGrid.Rows(j).Cells("Columna1").Value.ToString
                    '''Corrida = DgridSuc.Rows(j).Cells(0).Value.ToString
                    objCatalogoEst.usp_Captura_DetSucArt(Opcion, "", Marca, Proveedor, Estilon, Corrida, 0, GLB_Idempleado)
                    ''''Next

                End Using

                Opcion = 1

                For i As Integer = 0 To DgridSuc.Rows.Count - 1

                    If DgridSuc.Rows(i).Cells("Selec").Value = True Then

                        '' For j As Integer = 0 To DGrid.Rows.Count - 2
                        Dim Sucursal As String = DgridSuc.Rows(i).Cells("sucursal").Value.ToString
                        'Corrida = DGrid.Rows(j).Cells("Columna1").Value.ToString  'cambie la j por i
                        'Precio = DGrid.Rows(j).Cells("Columna6").Value.ToString

                        ' Corrida = DgridSuc.Rows(i).Cells(0).Value.ToString  'cambie la j por i
                        ' Precio = DgridSuc.Rows(i).Cells(1).Value.ToString

                        Corrida = DgridSuc.Rows(i).Cells(2).Value.ToString  'cambie la j por i
                        Precio = DgridSuc.Rows(i).Cells(3).Value.ToString

                        Using objCatalogoEst As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                            Guardo = objCatalogoEst.usp_Captura_DetSucArt(Opcion, Sucursal, Marca, Proveedor, Estilon, Corrida, Precio, GLB_Idempleado)
                            If Guardo = False Then
                                MsgBox("no guardo corrida")
                            End If
                        End Using
                        '' Next

                        'Dim Sucursal As String = DgridSuc.Rows(i).Cells("sucursal").Value.ToString
                        'Corrida = DgridSuc.Rows(i).Cells("corrida").Value.ToString
                        'Precio = DgridSuc.Rows(i).Cells("precio").Value.ToString

                        'Using objCatalogoEst As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                        '    objCatalogoEst.usp_Captura_DetSucArt(Opcion, Sucursal, Marca, Proveedor, Estilon, Corrida, Precio, GLB_Idempleado)
                        'End Using

            End If
                Next

            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub RellenaGridSuc()
        Dim SqlWhere As String = ""
        Call TraerSucursales()
    End Sub
    Private Sub MarcaCeldasGridSuc()
        Try
            For i As Integer = 0 To DgridSuc.Rows.Count - 2
                DgridSuc.Rows(i).Cells("Selec").Value = True
            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub InicializaGridSucursales()
        DgridSuc.RowHeadersVisible = False
        ''DGrid.AllowUserToResizeColumns = True


        DgridSuc.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DgridSuc.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DgridSuc.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DgridSuc.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        DgridSuc.Columns(3).DefaultCellStyle.Format = "c"

        Call AgregarColumna()

        DgridSuc.Columns(3).ReadOnly = False
        DgridSuc.Columns(0).ReadOnly = True
        DgridSuc.Columns(1).ReadOnly = True

        DgridSuc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    End Sub
    Private Sub TraerSucursales()
        Using objSucursal As New BCL.BCLPersis(GLB_ConStringPerSis)
            Try
                'Me.Text = "Buscar Sucursal"

                objDataSetSuc = objSucursal.usp_TraerSucursalSel("")
                'Populate the Project Details section
                'DGrid.ReadOnly = True
                DgridSuc.DataSource = Nothing
                DgridSuc.DataSource = objDataSetSuc.Tables(0)

                'Precio = DGrid.SelectedRows(0).Cells("precio").Value

                DgridSuc.Columns.Add("corrida", "C")
                DgridSuc.Columns.Add("precio", "Precio Público")
                'Precio = DGrid.Rows(0).Cells("precio").Value

                InicializaGridSucursales()

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub
    Private Sub AgregarColumna()
        'mreyes 21/Marzo/2012 09:52 a.m.

        Dim colImagen As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        colImagen.Name = "Selec"
        colImagen.HeaderText = "Selec"
        colImagen.DisplayIndex = 4

        colImagen.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        colImagen.CellTemplate = New DataGridViewCheckBoxCell()
        ' añadir columna de imagen a la coleccion del grid 
        DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        ''DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
        'For i As Integer = 0 To DgridSuc.Rows.Count - 1
        Me.DgridSuc.Columns.Add(colImagen)
        'Next
    End Sub

    Private Sub usp_TraerModelo(ByVal Proveedor As String, ByVal Corrida As String)
        Dim objDataSet As Data.DataSet
        Using objCatalogoEstilos As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
            Try

                objDataSet = objCatalogoEstilos.usp_TraerModelo(Val(Txt_IdArticulo.Text), Txt_Marca.Text, Txt_Modelo.Text, "", _
                                                               0, 0, 0, 0, 0, "")

                'objDataSet = objCatalogoEstilos.usp_TraerModeloCATALOGO(Val(Txt_IdArticulo.Text), Txt_Marca.Text, Txt_Modelo.Text, Txt_Estilof.Text, _
                '                                                Val(Txt_Depto.Text), Txt_Familia.Text, Txt_Linea.Text, Txt_SubLinea.Text, Txt_SSubLinea.Text, Txt_TipoArt.Text, "")

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_Marca.Text = objDataSet.Tables(0).Rows(0).Item("marca").ToString
                    Txt_DescripMarca.Text = objDataSet.Tables(0).Rows(0).Item("descripmarca").ToString
                    Txt_Modelo.Text = objDataSet.Tables(0).Rows(0).Item("modelo").ToString
                    Txt_Estilof.Text = objDataSet.Tables(0).Rows(0).Item("estilof").ToString
                    Txt_Descripc.Text = objDataSet.Tables(0).Rows(0).Item("descripc").ToString
                    Txt_Descripap.Text = objDataSet.Tables(0).Rows(0).Item("descripap").ToString
                    Txt_Proveedor.Text = objDataSet.Tables(0).Rows(0).Item("proveedor").ToString
                    Txt_Raz_Soc.Text = objDataSet.Tables(0).Rows(0).Item("raz_soc").ToString
                    Txt_DescripL.Text = objDataSet.Tables(0).Rows(0).Item("descripl").ToString
                    If Sw_PedidoNuevo = False Then
                        Txt_Dsctopp.Text = objDataSet.Tables(0).Rows(0).Item("dsctopp").ToString
                        Txt_Dscto01.Text = objDataSet.Tables(0).Rows(0).Item("dscto01").ToString
                        Txt_Dscto02.Text = objDataSet.Tables(0).Rows(0).Item("dscto02").ToString
                        Txt_Dscto03.Text = objDataSet.Tables(0).Rows(0).Item("dscto03").ToString
                        Txt_Dscto04.Text = objDataSet.Tables(0).Rows(0).Item("dscto04").ToString
                        Txt_Dscto05.Text = objDataSet.Tables(0).Rows(0).Item("dscto05").ToString
                        Txt_Iva.Text = "16"
                        If objDataSet.Tables(0).Rows(0).Item("rprov") = 0 Then
                            Txt_Iva.Text = "16"
                        Else
                            Txt_Iva.Text = "0"
                        End If
                    End If
                    Txt_Factor.Text = objDataSet.Tables(0).Rows(0).Item("factor").ToString


                    If objDataSet.Tables(0).Rows(0).Item("medida").ToString = "N" Then
                        Cbo_Medida.Text = "NÚMEROS"
                    ElseIf objDataSet.Tables(0).Rows(0).Item("medida").ToString = "L" Then
                        Cbo_Medida.Text = "LETRAS"
                    Else
                        Cbo_Medida.Text = "SIN MEDIDA"
                    End If

                    If objDataSet.Tables(0).Rows(0).Item("acepdevo").ToString = "S" Then
                        Cbo_AcepDevo.Text = "SI"
                    Else
                        Cbo_AcepDevo.Text = "NO"
                    End If


                    'If objDataSet.Tables(0).Rows(0).Item("artcat").ToString = "B" Then
                    '    Cbo_Clasif.Text = "BASICOS"
                    'ElseIf objDataSet.Tables(0).Rows(0).Item("artcat").ToString = "T" Then
                    '    Cbo_Clasif.Text = "TEMPORADA"
                    'ElseIf objDataSet.Tables(0).Rows(0).Item("artcat").ToString = "D" Then
                    '    Cbo_Clasif.Text = "DESCONTINUADOS"
                    'ElseIf objDataSet.Tables(0).Rows(0).Item("artcat").ToString = "P" Then
                    '    Cbo_Clasif.Text = "PRUEBA"
                    'End If

                    Txt_Resmin.Text = objDataSet.Tables(0).Rows(0).Item("resmin").ToString
                    Txt_DiasInvIdeal.Text = objDataSet.Tables(0).Rows(0).Item("diasinvideal").ToString
                    DT_FecIni.Value = objDataSet.Tables(0).Rows(0).Item("vigenciaa").ToString

                    If objDataSet.Tables(0).Rows(0).Item("ventaenlinea").ToString = 0 Then
                        Chk_VentaEnLinea.Checked = False
                    Else
                        Chk_VentaEnLinea.Checked = True
                    End If

                End If

                If Accion = 5 Or Accion = 4 Then
                    For i As Integer = 0 To objDataSetModelos.Tables(0).Rows.Count - 1
                        If objDataSet.Tables(0).Rows(0).Item("idarticulo") = objDataSetModelos.Tables(0).Rows(i).Item("idarticulo") Then
                            intPosicion = i
                        End If
                    Next
                End If

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub usp_TraerModeloCATALOGO(ByVal Proveedor As String, ByVal Corrida As String)
        Dim objDataSet As Data.DataSet

        Using objCatalogoEstilos As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
            Try

                objDataSet = objCatalogoEstilos.usp_TraerModeloCATALOGO(Val(Txt_IdArticulo.Text), Txt_Marca.Text, Txt_Modelo.Text, "", _
                                                               0, 0, 0, 0, 0, "", Proveedor, Corrida)

                'objDataSet = objCatalogoEstilos.usp_TraerModeloCATALOGO(Val(Txt_IdArticulo.Text), Txt_Marca.Text, Txt_Modelo.Text, Txt_Estilof.Text, _
                '                                                Val(Txt_Depto.Text), Txt_Familia.Text, Txt_Linea.Text, Txt_SubLinea.Text, Txt_SSubLinea.Text, Txt_TipoArt.Text, "")

                If objDataSet.Tables(0).Rows.Count > 0 Then

                    If Sw_PedidoNuevo = False Then
                        Txt_Dsctopp.Text = objDataSet.Tables(0).Rows(0).Item("dsctopp").ToString
                        Txt_Dscto01.Text = objDataSet.Tables(0).Rows(0).Item("dscto01").ToString
                        Txt_Dscto02.Text = objDataSet.Tables(0).Rows(0).Item("dscto02").ToString
                        Txt_Dscto03.Text = objDataSet.Tables(0).Rows(0).Item("dscto03").ToString
                        Txt_Dscto04.Text = objDataSet.Tables(0).Rows(0).Item("dscto04").ToString
                        Txt_Dscto05.Text = objDataSet.Tables(0).Rows(0).Item("dscto05").ToString
                        Txt_Iva.Text = "16"
                        If objDataSet.Tables(0).Rows(0).Item("rprov") = 0 Then
                            Txt_Iva.Text = "16"
                        Else
                            Txt_Iva.Text = "0"
                        End If
                    End If



                    If objDataSet.Tables(0).Rows(0).Item("medida").ToString = "N" Then
                        Cbo_Medida.Text = "NÚMEROS"
                    ElseIf objDataSet.Tables(0).Rows(0).Item("medida").ToString = "L" Then
                        Cbo_Medida.Text = "LETRAS"
                    Else
                        Cbo_Medida.Text = "SIN MEDIDA"
                    End If

                    If objDataSet.Tables(0).Rows(0).Item("acepdevo").ToString = "S" Then
                        Cbo_AcepDevo.Text = "SI"
                    Else
                        Cbo_AcepDevo.Text = "NO"
                    End If


                    'If objDataSet.Tables(0).Rows(0).Item("artcat").ToString = "B" Then
                    '    Cbo_Clasif.Text = "BASICOS"
                    'ElseIf objDataSet.Tables(0).Rows(0).Item("artcat").ToString = "T" Then
                    '    Cbo_Clasif.Text = "TEMPORADA"
                    'ElseIf objDataSet.Tables(0).Rows(0).Item("artcat").ToString = "D" Then
                    '    Cbo_Clasif.Text = "DESCONTINUADOS"
                    'ElseIf objDataSet.Tables(0).Rows(0).Item("artcat").ToString = "P" Then
                    '    Cbo_Clasif.Text = "PRUEBA"
                    'End If
                    If objDataSet.Tables(0).Rows(0).Item("resmin").ToString = Txt_Resmin.Text Then
                        Txt_Resmin.Text = objDataSet.Tables(0).Rows(0).Item("resmin").ToString
                    End If
                End If

                    If Accion = 5 Or Accion = 4 Then
                    For i As Integer = 0 To objDataSetModelos.Tables(0).Rows.Count - 1
                        If objDataSet.Tables(0).Rows(0).Item("idarticulo") = objDataSetModelos.Tables(0).Rows(i).Item("idarticulo") Then
                            intPosicion = i
                        End If
                    Next
                End If

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub
    Private Sub usp_TraerEstructura()
        Using objCatalogoEstilos As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
            Try

                objDataSet = objCatalogoEstilos.usp_TraerEstructura(Val(Txt_IdArticulo.Text), Txt_Marca.Text, Txt_Modelo.Text)

                If objDataSet.Tables(0).Rows.Count > 0 Then

                    Txt_IdDivision.Text = objDataSet.Tables(0).Rows(0).Item("iddivisiones").ToString
                    Txt_Division.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    Txt_DescripDivision.Text = objDataSet.Tables(0).Rows(0).Item("descripdivision").ToString
                    Txt_IdDepto.Text = objDataSet.Tables(0).Rows(0).Item("iddepto").ToString
                    Txt_Depto.Text = objDataSet.Tables(0).Rows(0).Item("clave1").ToString
                    Txt_DescripDepto.Text = objDataSet.Tables(0).Rows(0).Item("descripdepto").ToString
                    Txt_IdFamilia.Text = objDataSet.Tables(0).Rows(0).Item("idfamilia").ToString
                    Txt_Familia.Text = objDataSet.Tables(0).Rows(0).Item("clave2").ToString
                    Txt_DescripFamilia.Text = objDataSet.Tables(0).Rows(0).Item("descripfamilia").ToString
                    Txt_IdLinea.Text = objDataSet.Tables(0).Rows(0).Item("idlinea").ToString
                    Txt_Linea.Text = objDataSet.Tables(0).Rows(0).Item("clave3").ToString
                    Txt_DescripLinea.Text = objDataSet.Tables(0).Rows(0).Item("descriplinea").ToString
                    Txt_IdL1.Text = objDataSet.Tables(0).Rows(0).Item("idl1").ToString
                    Txt_L1.Text = objDataSet.Tables(0).Rows(0).Item("clave4").ToString
                    Txt_DescripL1.Text = objDataSet.Tables(0).Rows(0).Item("descripl1").ToString
                    Txt_IdL2.Text = objDataSet.Tables(0).Rows(0).Item("idl2").ToString
                    Txt_L2.Text = objDataSet.Tables(0).Rows(0).Item("clave5").ToString
                    Txt_DescripL2.Text = objDataSet.Tables(0).Rows(0).Item("descripl2").ToString
                    Txt_IdL3.Text = objDataSet.Tables(0).Rows(0).Item("idl3").ToString
                    Txt_L3.Text = objDataSet.Tables(0).Rows(0).Item("clave6").ToString
                    Txt_DescripL3.Text = objDataSet.Tables(0).Rows(0).Item("descripl3").ToString
                    Txt_IdL4.Text = objDataSet.Tables(0).Rows(0).Item("idl4").ToString
                    Txt_L4.Text = objDataSet.Tables(0).Rows(0).Item("clave7").ToString
                    Txt_DescripL4.Text = objDataSet.Tables(0).Rows(0).Item("descripl4").ToString
                    Txt_IdL5.Text = objDataSet.Tables(0).Rows(0).Item("idl5").ToString
                    Txt_L5.Text = objDataSet.Tables(0).Rows(0).Item("clave8").ToString
                    Txt_DescripL5.Text = objDataSet.Tables(0).Rows(0).Item("descripl5").ToString
                    Txt_IdL6.Text = objDataSet.Tables(0).Rows(0).Item("idl6").ToString
                    Txt_L6.Text = objDataSet.Tables(0).Rows(0).Item("clave9").ToString
                    Txt_DescripL6.Text = objDataSet.Tables(0).Rows(0).Item("descripl6").ToString


                Else

                    Txt_IdDivision.Text = ""
                    Txt_Division.Text = ""
                    Txt_DescripDivision.Text = ""
                    Txt_IdDepto.Text = ""
                    Txt_Depto.Text = ""
                    Txt_DescripDepto.Text = ""
                    Txt_IdFamilia.Text = ""
                    Txt_Familia.Text = ""
                    Txt_DescripFamilia.Text = ""
                    Txt_IdLinea.Text = ""
                    Txt_Linea.Text = ""
                    Txt_DescripLinea.Text = ""
                    Txt_IdL1.Text = ""
                    Txt_L1.Text = ""
                    Txt_DescripL1.Text = ""
                    Txt_IdL2.Text = ""
                    Txt_L2.Text = ""
                    Txt_DescripL2.Text = ""
                    Txt_IdL3.Text = ""
                    Txt_L3.Text = ""
                    Txt_DescripL3.Text = ""
                    Txt_IdL4.Text = ""
                    Txt_L4.Text = ""
                    Txt_DescripL4.Text = ""
                    Txt_IdL5.Text = ""
                    Txt_L5.Text = ""
                    Txt_DescripL5.Text = ""
                    Txt_IdL6.Text = ""
                    Txt_L6.Text = ""
                    Txt_DescripL6.Text = ""
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
            ToolTip.SetToolTip(Btn_Nuevo, "Nuevo Artículo")
            ToolTip.SetToolTip(Btn_Editar, "Editar Artículo")
            ToolTip.SetToolTip(DGrid, "Detallado de corridas del Artículo")
            ToolTip.SetToolTip(Btn_NuevoF, "Nueva Foto")
            ToolTip.SetToolTip(Btn_EliminarF, "Eliminar Foto")
            ToolTip.SetToolTip(Btn_Ant, "Foto Anterior")
            ToolTip.SetToolTip(Btn_Sig, "Foto Siguiente")
            ToolTip.SetToolTip(Btn_AceptarF, "Guardar Foto")
            ToolTip.SetToolTip(Btn_ModAnterior, "Modelo Anterior")
            ToolTip.SetToolTip(Btn_ModSiguiente, "Modelo Siguiente")
            ToolTip.SetToolTip(Btn_AgregarM, "Agregar Material")
            ToolTip.SetToolTip(Btn_AgregarC, "Agregar Color")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub LimpiarDatos()
        Try
            Txt_IdArticulo.Text = ""
            Txt_Marca.Text = ""
            Txt_DescripMarca.Text = ""
            Txt_Modelo.Text = ""
            Txt_Estilof.Text = ""
            Txt_Descripc.Text = ""
            Txt_Descripap.Text = ""
            Me.Txt_IdDivision.Text = ""
            Me.Txt_Division.Text = ""
            Me.Txt_DescripDivision.Text = ""
            Me.Txt_IdDepto.Text = ""
            Me.Txt_Depto.Text = ""
            Me.Txt_DescripDepto.Text = ""
            Me.Txt_IdFamilia.Text = ""
            Me.Txt_Familia.Text = ""
            Me.Txt_DescripFamilia.Text = ""
            Me.Txt_IdLinea.Text = ""
            Me.Txt_Linea.Text = ""
            Me.Txt_DescripLinea.Text = ""
            Me.Txt_IdL1.Text = ""
            Me.Txt_L1.Text = ""
            Me.Txt_DescripL1.Text = ""
            Me.Txt_IdL2.Text = ""
            Me.Txt_L2.Text = ""
            Me.Txt_DescripL2.Text = ""
            Me.Txt_IdL3.Text = ""
            Me.Txt_L3.Text = ""
            Me.Txt_DescripL3.Text = ""
            Me.Txt_IdL4.Text = ""
            Me.Txt_L4.Text = ""
            Me.Txt_DescripL4.Text = ""
            Me.Txt_IdL5.Text = ""
            Me.Txt_L5.Text = ""
            Me.Txt_DescripL5.Text = ""
            Me.Txt_IdL6.Text = ""
            Me.Txt_L6.Text = ""
            Me.Txt_DescripL6.Text = ""
            Me.Txt_Proveedor.Text = ""
            Me.Txt_Raz_Soc.Text = ""
            Txt_Agrupacion.Text = ""
            Txt_DescripL.Text = ""
            Cbo_Medida.Text = ""
            Cbo_AcepDevo.Text = ""
            Txt_Resmin.Text = ""


            If DGridC.Rows.Count >= 1 Then
                DGridC.Rows.Clear()
            End If

            If DGrid2.Rows.Count > 1 Then
                DGrid2.Rows.Clear()
            End If

            If DGrid.Rows.Count > 1 Then
                DGrid.Rows.Clear()
            End If

            If DGridMat.Rows.Count > 1 Then
                DGridMat.Rows.Clear()
            End If

            If DGridColor.Rows.Count > 1 Then
                DGridColor.Rows.Clear()
            End If


            PBox.Image = SIRCO.My.Resources.ZAPATERIA_TORREON
            PBox2.Image = SIRCO.My.Resources.ZAPATERIA_TORREON
            'If DgridSuc.Rows.Count > 1 Then
            '    DgridSuc.Rows.Clear()
            'End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub
    Private Sub TxtLostfocus(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
        Dim myForm As New frmConsulta
        If Txt_Campo.Text.Length = 0 Then Exit Sub
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
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
    Private Sub Edicion()
        Try
            Select Case Accion
                Case 3, 4
                    Btn_Aceptar.Enabled = True
                    Btn_Cancelar.Enabled = True
                    Btn_Nuevo.Enabled = True
                    Btn_Editar.Enabled = True

                    Pnl_Edicion.Enabled = False

                    'DgridSuc.Columns(3).ReadOnly = True
                    'DgridSuc.Columns(4).ReadOnly = True

                    Txt_Marca.BackColor = TextboxBackColor
                    Txt_Modelo.BackColor = TextboxBackColor
                    Txt_Estilof.BackColor = TextboxBackColor
                    Txt_Descripc.BackColor = TextboxBackColor
                    Txt_Descripap.BackColor = TextboxBackColor
                    Txt_Division.BackColor = TextboxBackColor
                    Txt_Depto.BackColor = TextboxBackColor
                    Txt_Familia.BackColor = TextboxBackColor
                    Txt_Linea.BackColor = TextboxBackColor
                    Txt_L1.BackColor = TextboxBackColor
                    Txt_L2.BackColor = TextboxBackColor
                    Txt_L3.BackColor = TextboxBackColor
                    Txt_L4.BackColor = TextboxBackColor
                    Txt_L5.BackColor = TextboxBackColor
                    Txt_L6.BackColor = TextboxBackColor
                    Txt_Proveedor.BackColor = TextboxBackColor
                    Txt_Agrupacion.BackColor = TextboxBackColor
                    'Txt_CveColor.BackColor = TextboxBackColor
                    'Txt_CveMaterial.BackColor = TextboxBackColor
                    Txt_DescripL.BackColor = TextboxBackColor
                    Cbo_Medida.BackColor = TextboxBackColor
                    Cbo_AcepDevo.BackColor = TextboxBackColor
                    Cbo_Clasif.BackColor = TextboxBackColor
                    Txt_Resmin.BackColor = TextboxBackColor
                    Txt_Categoria.BackColor = TextboxBackColor

                    Txt_Categoria.Visible = True
                    Txt_DescripCategoria.Visible = True
                    Lbl_Categoria.Visible = True
                    Txt_Categoria.Enabled = False

                    ' no dar de alta fotos 

                    Btn_AceptarF.Enabled = False
                    Btn_EliminarF.Enabled = False
                    Btn_NuevoF.Enabled = False

                Case 1, 2, 5
                    Btn_Aceptar.Enabled = True
                    Btn_Cancelar.Enabled = True
                    Btn_Nuevo.Enabled = False
                    Btn_Editar.Enabled = False
                    Txt_Iva.Text = "16"

                    Pnl_Grid.Enabled = True
                    Pnl_Grid.Enabled = True
                    If Accion = 1 Then
                        If Sw_PedidoNuevo = True Then
                            Txt_Descripc.Focus()
                            Txt_Modelo.Enabled = False
                            Txt_Marca.Enabled = False
                            Txt_Modelo.BackColor = TextboxBackColor
                            Txt_Marca.BackColor = TextboxBackColor
                            Txt_Estilof.Enabled = True
                            Txt_Estilof.BackColor = TextboxBackColor
                        Else
                            Txt_Marca.Focus()
                        End If
                        Btn_ModAnterior.Visible = False
                        Btn_ModSiguiente.Visible = False
                        Panel7.Visible = False

                    ElseIf Accion = 2 Then
                        Txt_Descripc.Focus()
                        Txt_Modelo.Enabled = False
                        Txt_Marca.Enabled = False
                        Txt_Modelo.BackColor = TextboxBackColor
                        Txt_Marca.BackColor = TextboxBackColor
                        Txt_Estilof.Enabled = True
                        Txt_Estilof.BackColor = TextboxBackColor
                        Btn_ModAnterior.Visible = False
                        Btn_ModSiguiente.Visible = False
                        Txt_Categoria.Visible = True
                        Txt_DescripCategoria.Visible = True
                        Lbl_Categoria.Visible = True
                    ElseIf Accion = 5 Then
                        Txt_Marca.Focus()
                        Txt_Modelo.Enabled = True
                        Txt_Modelo.BackColor = TextboxBackColor
                        Txt_Marca.BackColor = TextboxBackColor
                        Txt_Estilof.Enabled = True
                        Txt_Estilof.BackColor = TextboxBackColor
                        Txt_Proveedor.Enabled = False
                        Txt_Proveedor.BackColor = TextboxBackColor
                        Pnl_GridSuc.Visible = False

                        'oculta tabpage Costos, no afecta los controles de la pantalla
                        Me.Tbc_Modelo.TabPages.Remove(Tp_Costos)
                    End If
            End Select
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub CargarFotoArticulo()
        'mreyes 02/Marzo/2012 04:12 p.m.
        'Glb_RutaArchivoFotos
        Try
            Dim Archivo As String = ""
            Dim NoFoto As String = "1"

            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)

                System.GC.Collect()

                Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Modelo.Text, NoFoto)
                Txt_NoFoto.Text = NoFoto
                If objIO.pub_ExisteArchivo(Archivo) = True Then
                    PBox.Image = New System.Drawing.Bitmap(Archivo)
                    PBox2.Image = New System.Drawing.Bitmap(Archivo)
                    Exit Sub
                End If

                For i As Integer = 0 To 9
                    Txt_NoFoto.Text = i
                    Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Modelo.Text, i)
                    If objIO.pub_ExisteArchivo(Archivo) = True Then
                        PBox.Image = New System.Drawing.Bitmap(Archivo)
                        PBox2.Image = New System.Drawing.Bitmap(Archivo)
                        Exit Sub
                    End If
                Next

                PBox.Image = SIRCO.My.Resources.ZAPATERIA_TORREON
                PBox2.Image = SIRCO.My.Resources.ZAPATERIA_TORREON

                Txt_NoFoto.Text = 1
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub CambiarArchivo(ByVal RutaOrigen As String, ByVal RutaDestino As String)
        'mreyes 03/Marzo/2012 09:17 a.m.
        ' Extraer primero el tipo de extención para agrandar la imagen
        'InStrRev()
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
    Private Sub CalcularMargen1(ByVal Corrida As String, ByVal PComp As Decimal, ByVal Precio As Decimal, ByVal TipoCrr As String)
        'mreyes 13/Abril/2012 09:48 a.m.
        Using objPedidos As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
            Try
                Dim objDataSet As Data.DataSet
                Dim Costo As Decimal = 0
                Dim Porcent As Decimal = 0
                Dim Fecha As Date = Format(Now.Date, "yyyy-MM-dd")
                Dim Pporce As Decimal = 0
                Dim pmgn As Decimal = 0
                objDataSet = objPedidos.usp_TraerCostosxMarca(Txt_Marca.Text, "")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    For I As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                        Costo = Costo * (100 + objDataSet.Tables(0).Rows(0).Item("porcent")) / 100
                    Next
                End If

                objDataSet = objPedidos.usp_TraerCostosGrales(Txt_Marca.Text)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    For I As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                        Costo = Costo * (100 + objDataSet.Tables(0).Rows(0).Item("porcent")) / 100
                    Next
                End If

                'CALCULO DEL PRECIO TOMANDO BOLETINES DE OFERTA VIGENTES'
                objDataSet = objPedidos.usp_TraerPorcenBoletin(Txt_Marca.Text, Txt_Modelo.Text, Corrida, Fecha)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("porcent") > Pporce Then
                        Pporce = objDataSet.Tables(0).Rows(0).Item("porcent")
                    End If
                End If

                '' POR TODOS LOS BOLETINES 

                objDataSet = objPedidos.usp_TraerPorcenBoletinNivel(Txt_Marca.Text, Txt_Modelo.Text, Corrida, Fecha, "M")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("porcent") > Pporce Then
                        Pporce = objDataSet.Tables(0).Rows(0).Item("porcent")

                    End If
                End If
                objDataSet = objPedidos.usp_TraerPorcenBoletinNivel(Txt_Marca.Text, Txt_Modelo.Text, Corrida, Fecha, "F")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("porcent") > Pporce Then
                        Pporce = objDataSet.Tables(0).Rows(0).Item("porcent")
                    End If
                End If
                objDataSet = objPedidos.usp_TraerPorcenBoletinNivel(Txt_Marca.Text, Txt_Modelo.Text, Corrida, Fecha, "L")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("porcent") > Pporce Then
                        Pporce = objDataSet.Tables(0).Rows(0).Item("porcent")
                    End If
                End If
                objDataSet = objPedidos.usp_TraerPorcenBoletinNivel(Txt_Marca.Text, Txt_Modelo.Text, Corrida, Fecha, "P")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("porcent") > Pporce Then
                        Pporce = objDataSet.Tables(0).Rows(0).Item("porcent")
                    End If
                End If

                objDataSet = objPedidos.usp_TraerPorcenBoletinNivel(Txt_Marca.Text, Txt_Modelo.Text, Corrida, Fecha, "T")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("porcent") > Pporce Then
                        Pporce = objDataSet.Tables(0).Rows(0).Item("porcent")
                    End If
                End If
                objDataSet = objPedidos.usp_TraerPorcenBoletinNivel(Txt_Marca.Text, Txt_Modelo.Text, Corrida, Fecha, "C")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("porcent") > Pporce Then
                        Pporce = objDataSet.Tables(0).Rows(0).Item("porcent")
                    End If
                End If

                ''''CALCULO DEL PRECIO TOMANDO DINERO ELECTRONICO 

                objDataSet = objPedidos.usp_TraerPorcenDinero(Txt_Marca.Text, Txt_Modelo.Text, Corrida, Fecha)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("porcent") > Pporce Then
                        Pporce = objDataSet.Tables(0).Rows(0).Item("porcent")
                    End If
                End If

                objDataSet = objPedidos.usp_TraerPorcenDineroNivel(Txt_Marca.Text, Txt_Modelo.Text, Corrida, Fecha, "M")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("porcent") > Pporce Then
                        Pporce = objDataSet.Tables(0).Rows(0).Item("porcent")

                    End If
                End If
                objDataSet = objPedidos.usp_TraerPorcenDineroNivel(Txt_Marca.Text, Txt_Modelo.Text, Corrida, Fecha, "F")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("porcent") > Pporce Then
                        Pporce = objDataSet.Tables(0).Rows(0).Item("porcent")
                    End If
                End If
                objDataSet = objPedidos.usp_TraerPorcenDineroNivel(Txt_Marca.Text, Txt_Modelo.Text, Corrida, Fecha, "L")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("porcent") > Pporce Then
                        Pporce = objDataSet.Tables(0).Rows(0).Item("porcent")
                    End If
                End If
                objDataSet = objPedidos.usp_TraerPorcenDineroNivel(Txt_Marca.Text, Txt_Modelo.Text, Corrida, Fecha, "P")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("porcent") > Pporce Then
                        Pporce = objDataSet.Tables(0).Rows(0).Item("porcent")
                    End If
                End If

                objDataSet = objPedidos.usp_TraerPorcenDineroNivel(Txt_Marca.Text, Txt_Modelo.Text, Corrida, Fecha, "T")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("porcent") > Pporce Then
                        Pporce = objDataSet.Tables(0).Rows(0).Item("porcent")
                    End If
                End If
                objDataSet = objPedidos.usp_TraerPorcenDineroNivel(Txt_Marca.Text, Txt_Modelo.Text, Corrida, Fecha, "C")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("porcent") > Pporce Then
                        Pporce = objDataSet.Tables(0).Rows(0).Item("porcent")
                    End If
                End If

                PComp = Costo * PComp / 100


                If Pporce > 0 Then
                    Precio = (Precio * (1 - Pporce / 100))
                End If
                If Precio > 0 And Precio >= Costo Then

                    pmgn = (100 * (1 - Costo / Precio))
                Else
                    pmgn = 0
                End If
                Dim pTipo As String = ""
                Dim ptcr As String = ""
                objDataSet = objPedidos.usp_TraerClasifMargen
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    For I As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                        If "7" <= TipoCrr And TipoCrr <= "9" Then
                            pTipo = "7"
                        ElseIf "4" <= TipoCrr And TipoCrr <= "6" Then
                            pTipo = "4"
                        Else
                            pTipo = "1"
                        End If
                    Next
                End If

                ptcr = (Str(pTipo + (3 - Val(objDataSet.Tables(0).Rows(0).Item("orden")))))
                If pmgn >= objDataSet.Tables(0).Rows(0).Item("porcent") And ptcr <> TipoCrr Then

                End If

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub
    Private Sub CargarFormaConsulta(ByVal TipoC As String, ByVal Opcion As Integer)
        Try
            Dim myForm As New frmConsulta

            If Opcion = 1 Then 'division
                If Txt_IdDivision.Text = "" Then
                    Txt_IdDivision.Text = 0
                End If
            End If

            If Opcion = 2 Then 'depto
                Txt_IdDepto.Text = ""

                If Txt_IdDivision.Text = "" Then
                    Txt_IdDivision.Text = 0
                End If

                If Txt_IdDepto.Text = "" Then
                    Txt_IdDepto.Text = 0
                End If

                myForm.IdSuperior1 = CInt(Txt_IdDivision.Text)
                myForm.Opcion = 1
            End If

            If Opcion = 3 Then 'familia
                If Txt_IdFamilia.Text = "" Then
                    Txt_IdFamilia.Text = 0
                End If

                If Txt_IdDivision.Text = "" Then
                    Txt_IdDivision.Text = 0
                End If

                If Txt_IdDepto.Text = "" Then
                    Txt_IdDepto.Text = 0
                End If

                myForm.IdSuperior1 = CInt(Txt_IdDepto.Text)
                myForm.IdSuperior2 = CInt(Txt_IdDivision.Text)
                myForm.Opcion = 1
            End If
            If Opcion = 4 Then 'linea
                If Txt_IdFamilia.Text = "" Then
                    Txt_IdFamilia.Text = 0
                End If

                If Txt_IdDivision.Text = "" Then
                    Txt_IdDivision.Text = 0
                End If

                If Txt_IdDepto.Text = "" Then
                    Txt_IdDepto.Text = 0
                End If

                If Txt_IdLinea.Text = "" Then
                    Txt_IdLinea.Text = 0
                End If
                myForm.IdSuperior1 = CInt(Txt_IdFamilia.Text)
                myForm.IdSuperior2 = CInt(Txt_IdDepto.Text)
                myForm.IdSuperior3 = CInt(Txt_IdDivision.Text)
                myForm.Opcion = 1
            End If
            If Opcion = 5 Then 'L1
                If Txt_IdFamilia.Text = "" Then
                    Txt_IdFamilia.Text = 0
                End If

                If Txt_IdDivision.Text = "" Then
                    Txt_IdDivision.Text = 0
                End If

                If Txt_IdDepto.Text = "" Then
                    Txt_IdDepto.Text = 0
                End If

                If Txt_IdLinea.Text = "" Then
                    Txt_IdLinea.Text = 0
                End If

                If Txt_IdL1.Text = "" Then
                    Txt_IdL1.Text = 0
                End If
                myForm.IdSuperior1 = CInt(Txt_IdLinea.Text)
                myForm.IdSuperior2 = CInt(Txt_IdFamilia.Text)
                myForm.IdSuperior3 = CInt(Txt_IdDepto.Text)
                myForm.IdSuperior4 = CInt(Txt_IdDivision.Text)
                myForm.Opcion = 1
            End If

            If Opcion = 6 Then 'L2
                If Txt_L2.Text.Trim.Length < 3 Then
                    Txt_L2.Text = pub_RellenarIzquierda(Txt_L2.Text.Trim, 3)
                End If

                If Txt_IdFamilia.Text = "" Then
                    Txt_IdFamilia.Text = 0
                End If

                If Txt_IdDivision.Text = "" Then
                    Txt_IdDivision.Text = 0
                End If

                If Txt_IdDepto.Text = "" Then
                    Txt_IdDepto.Text = 0
                End If

                If Txt_IdLinea.Text = "" Then
                    Txt_IdLinea.Text = 0
                End If

                If Txt_IdL1.Text = "" Then
                    Txt_IdL1.Text = 0
                End If

                If Txt_IdL2.Text = "" Then
                    Txt_IdL2.Text = 0
                End If
                myForm.IdSuperior1 = CInt(Txt_IdL1.Text)
                myForm.IdSuperior2 = CInt(Txt_IdLinea.Text)
                myForm.IdSuperior3 = CInt(Txt_IdFamilia.Text)
                myForm.IdSuperior4 = CInt(Txt_IdDepto.Text)
                myForm.IdSuperior5 = CInt(Txt_IdDivision.Text)
                myForm.Opcion = 1
            End If

            If Opcion = 7 Then 'L3
                If Txt_L3.Text.Trim.Length < 3 Then
                    Txt_L3.Text = pub_RellenarIzquierda(Txt_L3.Text.Trim, 3)
                End If

                If Txt_IdFamilia.Text = "" Then
                    Txt_IdFamilia.Text = 0
                End If

                If Txt_IdDivision.Text = "" Then
                    Txt_IdDivision.Text = 0
                End If

                If Txt_IdDepto.Text = "" Then
                    Txt_IdDepto.Text = 0
                End If

                If Txt_IdLinea.Text = "" Then
                    Txt_IdLinea.Text = 0
                End If

                If Txt_IdL1.Text = "" Then
                    Txt_IdL1.Text = 0
                End If

                If Txt_IdL2.Text = "" Then
                    Txt_IdL2.Text = 0
                End If

                If Txt_IdL3.Text = "" Then
                    Txt_IdL3.Text = 0
                End If

                myForm.IdSuperior1 = CInt(Txt_IdL2.Text)
                myForm.IdSuperior2 = CInt(Txt_IdL1.Text)
                myForm.IdSuperior3 = CInt(Txt_IdLinea.Text)
                myForm.IdSuperior4 = CInt(Txt_IdFamilia.Text)
                myForm.IdSuperior5 = CInt(Txt_IdDepto.Text)
                myForm.IdSuperior6 = CInt(Txt_IdDivision.Text)
                myForm.Opcion = 1
            End If

            If Opcion = 8 Then

            End If

            If Opcion = 10 Then

                If Txt_IdDivision.Text = "" Then
                    Txt_IdDivision.Text = 0
                End If

                myForm.IdSuperior1 = CInt(Txt_IdDivision.Text)
                myForm.Opcion = 1
            End If

            If Opcion = 11 Then 'L4
                If Txt_L4.Text.Trim.Length < 3 Then
                    Txt_L4.Text = pub_RellenarIzquierda(Txt_L4.Text.Trim, 3)
                End If

                If Txt_IdFamilia.Text = "" Then
                    Txt_IdFamilia.Text = 0
                End If

                If Txt_IdDivision.Text = "" Then
                    Txt_IdDivision.Text = 0
                End If

                If Txt_IdDepto.Text = "" Then
                    Txt_IdDepto.Text = 0
                End If

                If Txt_IdLinea.Text = "" Then
                    Txt_IdLinea.Text = 0
                End If

                If Txt_IdL1.Text = "" Then
                    Txt_IdL1.Text = 0
                End If

                If Txt_IdL2.Text = "" Then
                    Txt_IdL2.Text = 0
                End If

                If Txt_IdL3.Text = "" Then
                    Txt_IdL3.Text = 0
                End If

                If Txt_IdL4.Text = "" Then
                    Txt_IdL4.Text = 0
                End If

                myForm.IdSuperior1 = CInt(Txt_IdL3.Text)
                myForm.IdSuperior2 = CInt(Txt_IdL2.Text)
                myForm.IdSuperior3 = CInt(Txt_IdL1.Text)
                myForm.IdSuperior4 = CInt(Txt_IdLinea.Text)
                myForm.IdSuperior5 = CInt(Txt_IdFamilia.Text)
                myForm.IdSuperior6 = CInt(Txt_IdDepto.Text)
                myForm.IdSuperior7 = CInt(Txt_IdDivision.Text)
                myForm.Opcion = 1
            End If

            If Opcion = 12 Then 'L5
                If Txt_L5.Text.Trim.Length < 3 Then
                    Txt_L5.Text = pub_RellenarIzquierda(Txt_L5.Text.Trim, 3)
                End If

                If Txt_IdFamilia.Text = "" Then
                    Txt_IdFamilia.Text = 0
                End If

                If Txt_IdDivision.Text = "" Then
                    Txt_IdDivision.Text = 0
                End If

                If Txt_IdDepto.Text = "" Then
                    Txt_IdDepto.Text = 0
                End If

                If Txt_IdLinea.Text = "" Then
                    Txt_IdLinea.Text = 0
                End If

                If Txt_IdL1.Text = "" Then
                    Txt_IdL1.Text = 0
                End If

                If Txt_IdL2.Text = "" Then
                    Txt_IdL2.Text = 0
                End If

                If Txt_IdL3.Text = "" Then
                    Txt_IdL3.Text = 0
                End If

                If Txt_IdL4.Text = "" Then
                    Txt_IdL4.Text = 0
                End If

                If Txt_IdL5.Text = "" Then
                    Txt_IdL5.Text = 0
                End If

                myForm.IdSuperior1 = CInt(Txt_IdL4.Text)
                myForm.IdSuperior2 = CInt(Txt_IdL3.Text)
                myForm.IdSuperior3 = CInt(Txt_IdL2.Text)
                myForm.IdSuperior4 = CInt(Txt_IdL1.Text)
                myForm.IdSuperior5 = CInt(Txt_IdLinea.Text)
                myForm.IdSuperior6 = CInt(Txt_IdFamilia.Text)
                myForm.IdSuperior7 = CInt(Txt_IdDepto.Text)
                myForm.IdSuperior8 = CInt(Txt_IdDivision.Text)
                myForm.Opcion = 1
            End If

            If Opcion = 13 Then 'L6
                If Txt_L6.Text.Trim.Length < 3 Then
                    Txt_L6.Text = pub_RellenarIzquierda(Txt_L6.Text.Trim, 3)
                End If

                If Txt_IdFamilia.Text = "" Then
                    Txt_IdFamilia.Text = 0
                End If

                If Txt_IdDivision.Text = "" Then
                    Txt_IdDivision.Text = 0
                End If

                If Txt_IdDepto.Text = "" Then
                    Txt_IdDepto.Text = 0
                End If

                If Txt_IdLinea.Text = "" Then
                    Txt_IdLinea.Text = 0
                End If

                If Txt_IdL1.Text = "" Then
                    Txt_IdL1.Text = 0
                End If

                If Txt_IdL2.Text = "" Then
                    Txt_IdL2.Text = 0
                End If

                If Txt_IdL3.Text = "" Then
                    Txt_IdL3.Text = 0
                End If

                If Txt_IdL4.Text = "" Then
                    Txt_IdL4.Text = 0
                End If

                If Txt_IdL5.Text = "" Then
                    Txt_IdL5.Text = 0
                End If

                If Txt_IdL6.Text = "" Then
                    Txt_IdL6.Text = 0
                End If

                myForm.IdSuperior1 = CInt(Txt_IdL5.Text)
                myForm.IdSuperior2 = CInt(Txt_IdL4.Text)
                myForm.IdSuperior3 = CInt(Txt_IdL3.Text)
                myForm.IdSuperior4 = CInt(Txt_IdL2.Text)
                myForm.IdSuperior5 = CInt(Txt_IdL1.Text)
                myForm.IdSuperior6 = CInt(Txt_IdLinea.Text)
                myForm.IdSuperior7 = CInt(Txt_IdFamilia.Text)
                myForm.IdSuperior8 = CInt(Txt_IdDepto.Text)
                myForm.IdSuperior9 = CInt(Txt_IdDivision.Text)
                myForm.Opcion = 1
            End If


            myForm.Tipo = TipoC
            myForm.ShowDialog()


            If Opcion = 1 Then 'DIVISION
                Txt_IdDivision.Text = myForm.Campo
                Txt_Division.Text = myForm.Campo1
                Txt_DescripDivision.Text = myForm.Campo2
                If Txt_Division.Text.Length = 0 Then
                    Txt_Division.Focus()
                End If
            End If

            If Opcion = 2 Then 'DEPARTAMENTO
                Txt_IdDepto.Text = myForm.Campo
                Txt_Depto.Text = myForm.Campo1
                Txt_DescripDepto.Text = myForm.Campo2
                If Txt_Depto.Text.Length = 0 Then
                    Txt_Depto.Focus()
                End If

                If DGridC.Rows.Count = 1 Then
                    DGridC.CurrentRow.Cells.Item("col_idDepto").Value = myForm.Campo
                    DGridC.CurrentRow.Cells.Item("col_Depto").Value = myForm.Campo2
                End If
            End If

            If Opcion = 3 Then 'FAMILIA
                Txt_IdFamilia.Text = myForm.Campo
                Txt_Familia.Text = myForm.Campo1
                Txt_DescripFamilia.Text = myForm.Campo2
                If Txt_Familia.Text.Length = 0 Then
                    Txt_Familia.Focus()
                End If
            End If

            If Opcion = 4 Then 'LINEA
                Txt_IdLinea.Text = myForm.Campo
                Txt_Linea.Text = myForm.Campo1
                Txt_DescripLinea.Text = myForm.Campo2
                If myForm.blnVacio = True Then
                    MsgBox("La Familia " + Txt_DescripFamilia.Text + " no cuenta con Líneas.", MsgBoxStyle.Critical, "Validación")
                End If
                If Txt_Linea.Text.Length = 0 Then
                    Txt_Linea.Focus()
                End If
            End If

            If Opcion = 5 Then 'L1
                Txt_IdL1.Text = myForm.Campo
                Txt_L1.Text = myForm.Campo1
                Txt_DescripL1.Text = myForm.Campo2

                If myForm.blnVacio = True Then
                    MsgBox("La Línea " + Txt_DescripLinea.Text + " no cuenta con L1.", MsgBoxStyle.Critical, "Validación")
                End If

                If Txt_L1.Text.Length = 0 Then
                    Txt_L1.Focus()
                End If
            End If

            If Opcion = 6 Then 'L2
                Txt_IdL2.Text = myForm.Campo
                Txt_L2.Text = myForm.Campo1
                Txt_DescripL2.Text = myForm.Campo2

                If myForm.blnVacio = True Then
                    MsgBox("La L1 " + Txt_DescripL1.Text + " no cuenta con L2.", MsgBoxStyle.Critical, "Validación")
                End If

                If Txt_L2.Text.Length = 0 Then
                    Txt_L2.Focus()
                End If
            End If


            If Opcion = 7 Then 'L3
                Txt_IdL3.Text = myForm.Campo
                Txt_L3.Text = myForm.Campo1
                Txt_DescripL3.Text = myForm.Campo2

                If myForm.blnVacio = True Then
                    MsgBox("La L2 " + Txt_DescripL2.Text + " no cuenta con L3.", MsgBoxStyle.Critical, "Validación")
                End If

                If Txt_L3.Text.Length = 0 Then
                    Txt_L3.Focus()
                End If
            End If

            If Opcion = 8 Then ''MATERIAL
                Txt_BuscarMaterial.Text = myForm.Campo1

                If Txt_BuscarMaterial.Text.Length = 0 Then
                    Txt_BuscarMaterial.Focus()
                End If
            End If

            If Opcion = 9 Then 'COLOR
                Txt_BuscarColor.Text = myForm.Campo1

                If Txt_BuscarColor.Text.Length = 0 Then
                    Txt_BuscarColor.Focus()
                End If
            End If

            If Opcion = 10 Then
                DGridC.CurrentRow.Cells.Item("col_IdDepto").Value = myForm.Campo
                DGridC.CurrentRow.Cells.Item("col_depto").Value = myForm.Campo2
            End If

            If Opcion = 11 Then 'L4
                Txt_IdL4.Text = myForm.Campo
                Txt_L4.Text = myForm.Campo1
                Txt_DescripL4.Text = myForm.Campo2

                If myForm.blnVacio = True Then
                    MsgBox("La L3 " + Txt_DescripL3.Text + " no cuenta con L4.", MsgBoxStyle.Critical, "Validación")
                End If

                If Txt_L4.Text.Length = 0 Then
                    Txt_L4.Focus()
                End If
            End If

            If Opcion = 12 Then 'L5
                Txt_IdL5.Text = myForm.Campo
                Txt_L5.Text = myForm.Campo1
                Txt_DescripL5.Text = myForm.Campo2

                If myForm.blnVacio = True Then
                    MsgBox("La L4 " + Txt_DescripL4.Text + " no cuenta con L5.", MsgBoxStyle.Critical, "Validación")
                End If

                If Txt_L5.Text.Length = 0 Then
                    Txt_L5.Focus()
                End If
            End If

            If Opcion = 13 Then 'L6
                Txt_IdL6.Text = myForm.Campo
                Txt_L6.Text = myForm.Campo1
                Txt_DescripL6.Text = myForm.Campo2

                If myForm.blnVacio = True Then
                    MsgBox("La L5 " + Txt_DescripL5.Text + " no cuenta con L6.", MsgBoxStyle.Critical, "Validación")
                End If

                If Txt_L6.Text.Length = 0 Then
                    Txt_L6.Focus()
                End If
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub GuardarAtributosModelo()
        Dim Opcion As Integer = 0
        Try

            If Accion = 1 Then
                Opcion = 1

                'Obtiene el id del articulo grabado en esta misma operacion
                Using objCatalogoEst As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                    objDataSet = objCatalogoEst.usp_TraerIdArticulo(Txt_Marca.Text, Txt_Modelo.Text)
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Txt_IdArticulo.Text = objDataSet.Tables(0).Rows(0).Item("idarticulo")
                    End If
                End Using

                'Inserta encabezado de atributos para el modelo
                Using objCatalogoEst As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                    objCatalogoEst.usp_Captura_EstAtributo(Opcion, CInt(Txt_IdArticulo.Text))
                End Using

                'Consulta la tabla de encabezado para obtener el folio
                Using objCatalogoEst As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                    objDataSet = objCatalogoEst.usp_TraerEstAtributo(CInt(Txt_IdArticulo.Text))
                End Using

                'Inserta detallado de atributos para el modelo
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    With DGridMat
                        For i As Integer = 0 To DGridMat.Rows.Count - 2
                            Using objCatalogoEst As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                                objCatalogoEst.usp_Captura_DetEstAtributo(Opcion, objDataSet.Tables(0).Rows(0).Item("idestatributo"), DGridMat.Rows(i).Cells("idatrib").Value)
                            End Using
                        Next
                    End With

                    With DGridColor
                        For i As Integer = 0 To DGridColor.Rows.Count - 2
                            Using objCatalogoEst As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                                objCatalogoEst.usp_Captura_DetEstAtributo(Opcion, objDataSet.Tables(0).Rows(0).Item("idestatributo"), DGridMat.Rows(i).Cells("idatribc").Value)
                            End Using
                        Next
                    End With
                End If

            ElseIf Accion = 2 Or Accion = 5 Then

                Opcion = 2

                'Consulta si existe encabezado de atributos para el modelo
                Using objCatalogoEst As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                    objDataSet = objCatalogoEst.usp_TraerEstAtributo(CInt(Txt_IdArticulo.Text))
                End Using

                'Elimina el detallado de atributos par actualizar
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Using objCatalogoEst As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                        objCatalogoEst.usp_Captura_DetEstAtributo(Opcion, objDataSet.Tables(0).Rows(0).Item("idestatributo"), 0)
                    End Using
                End If

                Opcion = 1

                'Consulta si existe encabezado de atributos para el modelo
                Using objCatalogoEst As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                    objDataSet = objCatalogoEst.usp_TraerEstAtributo(CInt(Txt_IdArticulo.Text))
                End Using

                'Inserta detallado de atributos para el modelo
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    With DGridMat
                        For i As Integer = 0 To DGridMat.Rows.Count - 2
                            Using objCatalogoEst As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                                objCatalogoEst.usp_Captura_DetEstAtributo(Opcion, objDataSet.Tables(0).Rows(0).Item("idestatributo"), DGridMat.Rows(i).Cells("idatrib").Value)
                            End Using
                        Next
                    End With

                    With DGridColor
                        For i As Integer = 0 To DGridColor.Rows.Count - 2
                            Using objCatalogoEst As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                                objCatalogoEst.usp_Captura_DetEstAtributo(Opcion, objDataSet.Tables(0).Rows(0).Item("idestatributo"), DGridColor.Rows(i).Cells("idatribc").Value)
                            End Using
                        Next
                    End With
                Else

                    'Inserta encabezado de atributos para el modelo
                    Using objCatalogoEst As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                        objCatalogoEst.usp_Captura_EstAtributo(Opcion, CInt(Txt_IdArticulo.Text))
                    End Using

                    'Consulta la tabla de encabezado para obtener el folio
                    Using objCatalogoEst As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                        objDataSet = objCatalogoEst.usp_TraerEstAtributo(CInt(Txt_IdArticulo.Text))
                    End Using

                    'Inserta detallado de atributos para el modelo
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        With DGridMat
                            For i As Integer = 0 To DGridMat.Rows.Count - 2
                                Using objCatalogoEst As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                                    objCatalogoEst.usp_Captura_DetEstAtributo(Opcion, objDataSet.Tables(0).Rows(0).Item("idestatributo"), DGridMat.Rows(i).Cells("idatrib").Value)
                                End Using
                            Next
                        End With

                        With DGridColor
                            For i As Integer = 0 To DGridColor.Rows.Count - 2
                                Using objCatalogoEst As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                                    objCatalogoEst.usp_Captura_DetEstAtributo(Opcion, objDataSet.Tables(0).Rows(0).Item("idestatributo"), DGridColor.Rows(i).Cells("idatribc").Value)
                                End Using
                            Next
                        End With
                    End If
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub SiguienteEstilo(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If intPosicion = intTotalRows Then
            intPosicion = 0
        Else
            intPosicion += 1
        End If

        Txt_Marca.Text = objDataSetModelos.Tables(0).Rows(intPosicion).Item("marca").ToString
        Txt_Modelo.Text = objDataSetModelos.Tables(0).Rows(intPosicion).Item("modelo").ToString

        System.GC.Collect()

        Txt_Marca_LostFocus(sender, e)
        Txt_Modelo_LostFocus(sender, e)
    End Sub
    Private Sub usp_TraerCategoria(ByVal Marca As String, ByVal Estilon As String)
        Try
            Using objCatalogoEstilos As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                objDataSet = objCatalogoEstilos.usp_TraerCategoria(Marca, Estilon)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_Categoria.Text = objDataSet.Tables(0).Rows(0).Item("categoria").ToString
                    Txt_DescripCategoria.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub ActualizarCategoria()
        Try
            Using objCatalogoEstilos As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                If Not objCatalogoEstilos.usp_ActualizarCategoria(Txt_Marca.Text, Txt_Modelo.Text, Txt_Categoria.Text) Then
                    'Throw New Exception("No se pudo actualizar la Categoría del Modelo.")
                End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

#End Region
#Region "Eventos de la Forma"

    Private Sub Txt_Marca_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Marca.GotFocus
        Txt_Marca.SelectAll()
    End Sub
    Private Sub Txt_Marca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Marca.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub
    Private Sub DGrid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellDoubleClick
        Dim Marca As String = ""
        Dim EStilon As String = ""
        Dim Corrida As String = ""


        Marca = Txt_Marca.Text
        EStilon = Txt_Modelo.Text

        Corrida = DGrid.Rows(e.RowIndex).Cells("columna1").Value
        Dim myForm As New frmCatalogoCorrida
        myForm.Marca = Marca
        myForm.Modelo = EStilon
        myForm.Corrida = Corrida
        myForm.Estilof = Txt_Estilof.Text
        myForm.Archivo = PBox.Image
        myForm.Color = Txt_Descripc.Text
        myForm.StartPosition = FormStartPosition.CenterScreen
        myForm.ShowDialog()

    End Sub
    Private Sub frmCatalogoEstilos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'GLB_CatEsiloCancelado = True
    End Sub
    Private Sub frmCatalogoEstilos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' GLB_CatEsiloCancelado = True
    End Sub
    Private Sub frmCatalogoEstilos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then
                If Accion = 1 Or Accion = 2 Or Accion = 5 Then
                    If MessageBox.Show("Estas seguro de cancelar el registro ?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                        Me.Dispose()
                        Me.Close()
                        GLB_CatEsiloCancelado = True
                    End If
                Else
                    Me.Dispose()
                    Me.Close()
                    GLB_CatEsiloCancelado = True
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Txt_Descripc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Descripc.GotFocus
        ''  Me.Txt_Descripc.SelectionStart = 0
        '' Me.Txt_Descripc.SelectionLength = Len(Me.Txt_Descripc.Text.Length)
        Txt_Descripc.SelectAll()
    End Sub
    Private Sub Txt_Descripc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Descripc.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        End If
    End Sub
    Private Sub Txt_Descripc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Descripc.LostFocus
        Txt_DescripL.Text = Txt_Descripc.Text
    End Sub
    Private Sub Txt_Descripc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Descripc.TextChanged
        ''If Txt_Descripc.Text.Length = 30 Then
        ''    Txt_Familia.Focus()
        ''End If
    End Sub
    Private Sub Txt_Marca_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Marca.LostFocus

        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
            If Txt_Marca.Text.Length = 0 Then Exit Sub

            Try
                Call TxtLostfocus(Txt_Marca, Txt_DescripMarca, "M")
                If Accion = 1 Then
                    objDataSet = objMySqlGral.usp_TraerFolio("EN", Txt_Marca.Text)
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Txt_Modelo.Text = Val(objDataSet.Tables(0).Rows(0).Item("campo").ToString) + 1
                        Txt_Modelo.Text = Txt_Modelo.Text.PadLeft(7)
                    Else
                        Txt_Modelo.Text = "      1"
                    End If
                End If
                Using objMarca As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                    Dim objDataSet As Data.DataSet

                    objDataSet = objMarca.usp_TraerMarca(Txt_Marca.Text, "")

                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Txt_Factor.Text = objDataSet.Tables(0).Rows(0).Item("factor").ToString
                    Else
                        Txt_Factor.Text = "0"
                    End If
                End Using
                'If Txt_Marca.Text = "OZO" Or Txt_Marca.Text = "OZA" Or Txt_Marca.Text = "FFF" Then
                '    Txt_Resmin.Text = "1"
                'End If

                If Accion = 5 Then
                    Txt_Modelo.Focus()
                End If
                If DGrid2.Rows.Count > 1 Then
                    DGrid2.Rows.Clear()
                End If
                'If DGridC.Rows.Count >= 1 Then
                '    DGridC.Rows.Clear()
                'End If
                Call usp_Traer_MarcaProvCosto(Txt_Marca.Text)
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using

    End Sub
    Private Sub Txt_Estilon_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Modelo.GotFocus
        Txt_Modelo.SelectAll()
    End Sub
    Private Sub Txt_Estilon_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Modelo.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Txt_Estilof_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Estilof.GotFocus
        Txt_Estilof.SelectAll()
    End Sub
    Private Sub Txt_Estilof_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_Estilof.KeyDown

    End Sub
    Private Sub Txt_Estilof_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Estilof.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Txt_Estilof_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Estilof.LostFocus
        If Accion <> 2 Then

            If Accion = 5 Then Exit Sub
            If Sw_PedidoNuevo = False Then
                Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
                    Try
                        Dim estilof As String = ""
                        '                        estilof = Replace(Txt_Estilof.Text, "-", "")
                        estilof = Txt_Estilof.Text

                        If Txt_Estilof.Text.Length = 0 Then Exit Sub
                        objDataSet = objMySqlGral.usp_TraerDescripcion("EN", Txt_Marca.Text, estilof)

                        If objDataSet.Tables(0).Rows.Count > 0 Then
                            MsgBox("El estilo de fábrica '" & estilof & "' para a marca '" & Txt_Marca.Text & "' ya se encuentra registrado con el estilo nuestro '" & objDataSet.Tables(0).Rows(0).Item("campo").ToString & "'. Con la descripción '" & objDataSet.Tables(0).Rows(0).Item("descripc").ToString & ".", MsgBoxStyle.Information, "Aviso")

                        End If


                    Catch ExceptionErr As Exception
                        MessageBox.Show(ExceptionErr.Message.ToString)
                    End Try
                End Using
            End If
        End If
    End Sub
    Private Sub Txt_Estilof_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Estilof.TextChanged
        If Accion <> 2 Then
            Txt_Descripc.Text = Txt_Estilof.Text
        End If
        If Txt_Estilof.Text.Length = 14 Then
            Txt_Descripc.Focus()
        End If
    End Sub
    Private Sub Txt_Proveedor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Proveedor.GotFocus
        Txt_L1.SelectAll()
    End Sub
    Private Sub Txt_Proveedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Proveedor.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If


        If Txt_Proveedor.Text.Length = 3 Then
            Txt_Agrupacion.Focus()
        End If
    End Sub
    Private Sub Txt_Proveedor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Proveedor.LostFocus
        ''Try
        ''    If Txt_Proveedor.Text.Length = 0 Then Exit Sub

        ''    If Txt_Proveedor.Text.Trim.Length < 3 Then
        ''        Txt_Proveedor.Text = pub_RellenarIzquierda(Txt_Proveedor.Text.Trim, 3)
        ''    End If
        ''    Call TxtLostfocus(Txt_Proveedor, Txt_Raz_Soc, "P")
        ''Catch ExceptionErr As Exception
        ''    MessageBox.Show(ExceptionErr.Message.ToString)
        ''End Try
        'mreyes 09/Marzo/2012 07:13 p.m.

        Try
BRINCO:
            If Txt_Proveedor.Text.Length = 0 Then Exit Sub
            If Txt_Proveedor.Text.Trim.Length < 3 Then
                Txt_Proveedor.Text = pub_RellenarIzquierda(Txt_Proveedor.Text.Trim, 3)
            End If

            'prueba
            ''Using objProveedores As New BCL.BCLCatalogoProveedores(GLB_ConStringCipSis)
            ''    objDataSet = objProveedores.usp_TraerProveedorMarca(Txt_Proveedor.Text)

            ''    If objDataSet.Tables(0).Rows.Count > 0 Then

            ''        If objDataSet.Tables(0).Rows(0).Item("status").ToString = "BA" Then
            ''            If MsgBox("El proveedor se encuentra dado de BAJA.", MsgBoxStyle.Exclamation, "Datos Proveedor") Then
            ''                Txt_Proveedor.Clear()
            ''                Exit Sub
            ''            End If
            ''        End If

            ''        Txt_Raz_Soc.Text = objDataSet.Tables(0).Rows(0).Item("raz_soc").ToString
            ''        If Sw_PedidoNuevo = False Then
            ''            Txt_Dsctopp.Text = Val(objDataSet.Tables(0).Rows(0).Item("dsctopp"))
            ''            Txt_Diaspp.Text = Val(objDataSet.Tables(0).Rows(0).Item("diaspp"))
            ''            Txt_Dscto01.Text = Val(objDataSet.Tables(0).Rows(0).Item("dscto01"))
            ''            Txt_Dscto02.Text = Val(objDataSet.Tables(0).Rows(0).Item("dscto02"))
            ''            Txt_Dscto03.Text = Val(objDataSet.Tables(0).Rows(0).Item("dscto03"))
            ''            Txt_Dscto04.Text = Val(objDataSet.Tables(0).Rows(0).Item("dscto04"))
            ''            Txt_Dscto05.Text = Val(objDataSet.Tables(0).Rows(0).Item("dscto05"))
            ''        End If

            ''    Else
            ''        Dim myForm As New frmConsulta
            ''        myForm.Tipo = "P"
            ''        myForm.ShowDialog()
            ''        Txt_Proveedor.Text = myForm.Campo

            ''        Txt_Raz_Soc.Text = myForm.Campo1
            ''        If Txt_Proveedor.Text.Length = 0 Then
            ''            Txt_Proveedor.Focus()
            ''        Else
            ''            GoTo BRINCO
            ''        End If
            ''    End If

            'Call usp_TraerModeloCATALOGO()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Txt_Agrupacion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Agrupacion.GotFocus
        Txt_Agrupacion.SelectAll()
    End Sub
    Private Sub Txt_Agrupacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Agrupacion.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Txt_Agrupacion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Agrupacion.LostFocus
        'mreyes 23/Febrero/2012 12:07 p.m.
        Try
            'If Txt_TipoArt.Text.Length = 0 Then Exit Sub
            'Call TxtLostfocus(Txt_TipoArt, Txt_DescripTipoArt, "TA")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub
    Private Sub Txt_DescripL_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_DescripL.GotFocus
        Txt_DescripL.SelectAll()
    End Sub
    Private Sub Txt_DescripL_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_DescripL.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Txt_Resmin_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Resmin.GotFocus
        Txt_Resmin.SelectAll()
    End Sub
    Private Sub Txt_Marca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Marca.TextChanged
        If Txt_Marca.Text.Length = 3 Then
            Txt_Estilof.Focus()
        End If
    End Sub
    '
    Private Sub Txt_Modelo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Modelo.LostFocus
        Try

            If aModelo <> Txt_Modelo.Text Then Sw_Entro = False
            If Sw_Entro = True Then Exit Sub

            If Sw_Entro = False Then
                Sw_Entro = True

                aModelo = Txt_Modelo.Text

                If Txt_Modelo.Text = "" Then Exit Sub

                If Txt_Modelo.Text.Length > 0 Then
                    Txt_Modelo.Text = Txt_Modelo.Text.PadLeft(7)
                End If

                If DGridC.Rows.Count >= 1 Then
                    DGridC.Rows.Clear()
                End If

                If DGrid2.Rows.Count > 1 Then
                    DGrid2.Rows.Clear()
                End If

                If DGrid.Rows.Count > 1 Then
                    DGrid.Rows.Clear()
                End If

                If DGridMat.Rows.Count > 1 Then
                    DGridMat.Rows.Clear()
                End If

                If DGridColor.Rows.Count > 1 Then
                    DGridColor.Rows.Clear()
                End If

                'DgridSuc.Rows.Clear()
                'DgridSuc.Columns.Clear()
                'Call RellenaGridSuc()
                'Call MarcaCeldasGridSuc()

                'Obtiene el id del articulo 
                Using objCatalogoEst As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                    objDataSet = objCatalogoEst.usp_TraerIdArticulo(Txt_Marca.Text, Txt_Modelo.Text)
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Txt_IdArticulo.Text = objDataSet.Tables(0).Rows(0).Item("idarticulo")

                        Call usp_TraerModelo("", "")
                        Call usp_TraerEstructura()
                        Call usp_Traer_MarcaProvCosto(Txt_Marca.Text)
                        Call usp_TraerCorrida(Txt_Modelo.Text)
                        'Call usp_TraerDetSucArt(Txt_Marca.Text, Txt_Modelo.Text)
                        Call usp_TraerAtributosModelo(CInt(Txt_IdArticulo.Text))
                        Call CargarFotoArticulo()
                    Else
                        Call LimpiarDatos()
                        Txt_Marca.Select()
                    End If
                End Using

                'If aModelo = Txt_Modelo.Text Then
                '    Sw_Entro = False
                'End If
            End If



        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Txt_Estilon_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Modelo.TextChanged

    End Sub
    Private Sub Txt_TipoArt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Agrupacion.TextChanged
        If Txt_Agrupacion.Text.Length = 1 Then
            'Txt_Categoria.Focus()
        End If
    End Sub
    Private Sub Txt_Division_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Division.GotFocus
        Txt_Division.SelectAll()
    End Sub
    Private Sub Txt_Division_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Division.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
        Txt_IdDivision.Text = ""
        'If Txt_Division.Text.Length = 3 Then
        '    Txt_Depto.Focus()
        'End If
    End Sub
    Private Sub Txt_Division_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Division.LostFocus
        Try
            If Txt_Division.Text.Length = 0 Then Exit Sub
            If Txt_Division.Text.Trim.Length < 3 Then
                Txt_Division.Text = pub_RellenarIzquierda(Txt_Division.Text.Trim, 3)
            End If


            Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
                objDataSet = objMySqlGral.usp_TraerDescripcion("EDI", Txt_Division.Text, "")

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_DescripDivision.Text = objDataSet.Tables(0).Rows(0).Item("campo").ToString
                    Txt_IdDivision.Text = objDataSet.Tables(0).Rows(0).Item("iddivisiones").ToString
                Else
                    Call CargarFormaConsulta("EDI", 1)
                End If
            End Using

            'Call TxtLostfocus(Txt_Depto, Txt_DescripDepto, "ED")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Txt_Depto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Depto.GotFocus
        Txt_Depto.SelectAll()
    End Sub
    Private Sub Txt_Depto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Depto.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
        Txt_IdDepto.Text = ""

        'If Txt_Depto.Text.Length = 3 Then
        '    Txt_Familia.Focus()
        'End If
    End Sub
    Private Sub Txt_Depto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Depto.LostFocus
        Try
            If Txt_Depto.Text.Length = 0 Then Exit Sub
            If Txt_Depto.Text.Trim.Length < 3 Then
                Txt_Depto.Text = pub_RellenarIzquierda(Txt_Depto.Text.Trim, 3)
            End If

            If Txt_Division.Text = "" AndAlso Txt_DescripDivision.Text = "" Then
                MsgBox("Debe especificar una División para el Modelo.", MsgBoxStyle.Critical, "Validación")
                Txt_Depto.Text = ""
                Txt_Division.Focus()
                Exit Sub
            End If

            Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
                objDataSet = objMySqlGral.usp_TraerDescripcion("ED", Txt_Depto.Text, "")

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_DescripDepto.Text = objDataSet.Tables(0).Rows(0).Item("campo").ToString
                    Txt_IdDepto.Text = objDataSet.Tables(0).Rows(0).Item("iddepto").ToString

                    If DGridC.Rows.Count = 1 Then
                        DGridC.CurrentRow.Cells.Item("col_idDepto").Value = objDataSet.Tables(0).Rows(0).Item("iddepto").ToString
                        DGridC.CurrentRow.Cells.Item("col_Depto").Value = objDataSet.Tables(0).Rows(0).Item("campo").ToString
                    End If
                Else
                    If Txt_Division.Text = "" AndAlso Txt_DescripDivision.Text = "" Then
                        MsgBox("Debe especificar una División para el Modelo.", MsgBoxStyle.Critical, "Validación")
                        Txt_Depto.Text = ""
                        Txt_Division.Focus()
                    Else
                        Call CargarFormaConsulta("ED", 2)
                    End If
                End If
            End Using

            'Call TxtLostfocus(Txt_Depto, Txt_DescripDepto, "ED")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Txt_Familia_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Familia.GotFocus
        Txt_Familia.SelectAll()
    End Sub
    Private Sub Txt_Familia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Familia.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
        Txt_IdFamilia.Text = ""

        'If Txt_Familia.Text.Length = 3 Then
        '    Txt_Linea.Focus()
        'End If
    End Sub
    Private Sub Txt_Familia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Familia.LostFocus
        Try
            If Txt_Familia.Text.Length = 0 Then Exit Sub
            If Txt_Familia.Text.Trim.Length < 3 Then
                Txt_Familia.Text = pub_RellenarIzquierda(Txt_Familia.Text.Trim, 3)
            End If


            Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
                objDataSet = objMySqlGral.usp_TraerDescripcion("EF", Txt_Familia.Text, Val(Txt_IdDepto.Text))

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_DescripFamilia.Text = objDataSet.Tables(0).Rows(0).Item("campo").ToString
                    Txt_IdFamilia.Text = objDataSet.Tables(0).Rows(0).Item("idfamilia").ToString
                Else
                    If Txt_Depto.Text = "" AndAlso Txt_DescripDepto.Text = "" Then
                        MsgBox("Debe especificar un Departamento para el Modelo.", MsgBoxStyle.Critical, "Validación")
                        Txt_Familia.Text = ""
                        Txt_Depto.Focus()
                    Else
                        Call CargarFormaConsulta("EF", 3)
                    End If

                End If
            End Using


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Txt_Linea_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Linea.GotFocus
        Txt_Linea.SelectAll()
    End Sub
    Private Sub Txt_Linea_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Linea.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
        Txt_IdLinea.Text = ""

        'If Txt_Linea.Text.Length = 3 Then
        '    Txt_SubLinea.Focus()
        'End If
    End Sub
    Private Sub Txt_Linea_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Linea.LostFocus
        Try

            If Txt_Linea.Text.Length = 0 Then Exit Sub
            If Txt_Linea.Text.Trim.Length < 3 Then
                Txt_Linea.Text = pub_RellenarIzquierda(Txt_Linea.Text.Trim, 3)
            End If


            Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
                objDataSet = objMySqlGral.usp_TraerDescripcion("EL", Txt_Linea.Text, Val(Txt_IdFamilia.Text))

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_DescripLinea.Text = objDataSet.Tables(0).Rows(0).Item("campo").ToString
                    Txt_IdLinea.Text = objDataSet.Tables(0).Rows(0).Item("idlinea").ToString
                Else
                    If Txt_Familia.Text = "" AndAlso Txt_DescripFamilia.Text = "" Then
                        MsgBox("Debe especificar una Familia para el Modelo.", MsgBoxStyle.Critical, "Validación")
                        Txt_Linea.Text = ""
                        Txt_Familia.Focus()
                    Else
                        Call CargarFormaConsulta("EL", 4)
                    End If

                End If
            End Using


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Txt_L1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_L1.GotFocus
        Txt_L1.SelectAll()
    End Sub
    Private Sub Txt_L1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_L1.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
        Txt_IdL1.Text = ""

        'If Txt_SubLinea.Text.Length = 3 Then
        '    Txt_SSubLinea.Focus()
        'End If
    End Sub
    Private Sub Txt_L1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_L1.LostFocus
        Try
            If Txt_L1.Text.Length = 0 Then Exit Sub
            If Txt_L1.Text.Trim.Length < 3 Then
                Txt_L1.Text = pub_RellenarIzquierda(Txt_L1.Text.Trim, 3)
            End If


            Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
                objDataSet = objMySqlGral.usp_TraerDescripcion("L1", Txt_L1.Text, Val(Txt_IdLinea.Text))

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_DescripL1.Text = objDataSet.Tables(0).Rows(0).Item("campo").ToString
                    Txt_IdL1.Text = objDataSet.Tables(0).Rows(0).Item("idl1").ToString
                Else
                    If Sw_PedidoNuevo <> True Then
                        If Txt_Linea.Text = "" AndAlso Txt_DescripLinea.Text = "" Then
                            MsgBox("Debe especificar una Linea para el Modelo.", MsgBoxStyle.Critical, "Validación")
                            Txt_L1.Text = ""
                            Txt_Linea.Focus()
                        Else
                            Call CargarFormaConsulta("L1", 5)
                        End If
                    Else
                        Call CargarFormaConsulta("L1", 5)
                        'Txt_L1.Text = ""
                        'Txt_Linea.Focus()
                    End If
                End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Txt_L2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_L2.GotFocus
        Txt_L2.SelectAll()
    End Sub
    Private Sub Txt_L2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_L2.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
        Txt_IdL2.Text = ""
        'If Txt_SSubLinea.Text.Length = 3 Then
        '    Txt_SSSubLinea.Focus()
        'End If
    End Sub
    Private Sub Txt_L2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_L2.LostFocus
        Try
            If Txt_L2.Text.Length = 0 Then Exit Sub
            If Txt_L2.Text.Trim.Length < 3 Then
                Txt_L2.Text = pub_RellenarIzquierda(Txt_L2.Text.Trim, 3)
            End If


            Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
                objDataSet = objMySqlGral.usp_TraerDescripcion("L2", Txt_L2.Text, Val(Txt_IdL1.Text))

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_DescripL2.Text = objDataSet.Tables(0).Rows(0).Item("campo").ToString
                    Txt_IdL2.Text = objDataSet.Tables(0).Rows(0).Item("idl2").ToString
                Else
                    If Sw_PedidoNuevo <> True Then
                        If Txt_L1.Text = "" AndAlso Txt_DescripL1.Text = "" Then
                            MsgBox("Debe especificar L1 para el Modelo.", MsgBoxStyle.Critical, "Validación")
                            Txt_L2.Text = ""
                            Txt_L1.Focus()
                        Else
                            Call CargarFormaConsulta("L2", 6)
                        End If
                    Else
                        Call CargarFormaConsulta("L2", 6)
                        'Txt_L2.Text = ""
                        'Txt_L1.Focus()
                    End If
                End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Txt_L3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_L3.GotFocus
        Txt_L3.SelectAll()
    End Sub
    Private Sub Txt_L3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_L3.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
        Txt_IdL3.Text = ""
        'If Txt_SSSubLinea.Text.Length = 3 Then
        '    Txt_Proveedor.Focus()
        'End If
    End Sub
    Private Sub Txt_L3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_L3.LostFocus
        Try
            If Txt_L3.Text.Length = 0 Then Exit Sub
            If Txt_L3.Text.Trim.Length < 3 Then
                Txt_L3.Text = pub_RellenarIzquierda(Txt_L3.Text.Trim, 3)
            End If


            Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
                objDataSet = objMySqlGral.usp_TraerDescripcion("L3", Txt_L3.Text, Val(Txt_IdL2.Text))

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_DescripL3.Text = objDataSet.Tables(0).Rows(0).Item("campo").ToString
                    Txt_IdL3.Text = objDataSet.Tables(0).Rows(0).Item("idl3").ToString
                Else
                    If Sw_PedidoNuevo <> True Then
                        If Txt_L2.Text = "" AndAlso Txt_DescripL2.Text = "" Then
                            MsgBox("Debe especificar L2 para el Modelo.", MsgBoxStyle.Critical, "Validación")
                            Txt_L3.Text = ""
                            Txt_L2.Focus()
                        Else
                            Call CargarFormaConsulta("L3", 7)
                        End If
                    Else
                        Call CargarFormaConsulta("L3", 7)
                        'Txt_L3.Text = ""
                        'Txt_L2.Focus()
                    End If
                End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Txt_L4_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_L4.GotFocus
        Txt_L4.SelectAll()
    End Sub
    Private Sub Txt_L4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_L4.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
        Txt_IdL4.Text = ""
        'If Txt_SSSubLinea.Text.Length = 3 Then
        '    Txt_Proveedor.Focus()
        'End If
    End Sub
    Private Sub Txt_L4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_L4.LostFocus
        Try
            If Txt_L4.Text.Length = 0 Then Exit Sub
            If Txt_L4.Text.Trim.Length < 3 Then
                Txt_L4.Text = pub_RellenarIzquierda(Txt_L4.Text.Trim, 3)
            End If


            Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
                objDataSet = objMySqlGral.usp_TraerDescripcion("L4", Txt_L4.Text, Val(Txt_IdL3.Text))

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_DescripL4.Text = objDataSet.Tables(0).Rows(0).Item("campo").ToString
                    Txt_IdL4.Text = objDataSet.Tables(0).Rows(0).Item("idl4").ToString
                Else
                    If Sw_PedidoNuevo <> 0 Then
                        If Txt_L3.Text = "" AndAlso Txt_DescripL3.Text = "" Then
                            MsgBox("Debe especificar L3 para el Modelo.", MsgBoxStyle.Critical, "Validación")
                            Txt_L4.Text = ""
                            Txt_L3.Focus()
                        Else
                            Call CargarFormaConsulta("L4", 11)
                        End If
                    Else
                        Call CargarFormaConsulta("L4", 11)
                        'Txt_L4.Text = ""
                        'Txt_L3.Focus()
                    End If
                End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Txt_L5_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_L5.GotFocus
        Txt_L5.SelectAll()
    End Sub
    Private Sub Txt_L5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_L5.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
        Txt_IdL5.Text = ""
        'If Txt_SSSubLinea.Text.Length = 3 Then
        '    Txt_Proveedor.Focus()
        'End If
    End Sub
    Private Sub Txt_L5_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_L5.LostFocus
        Try
            If Txt_L5.Text.Length = 0 Then Exit Sub
            If Txt_L5.Text.Trim.Length < 3 Then
                Txt_L5.Text = pub_RellenarIzquierda(Txt_L5.Text.Trim, 3)
            End If


            Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
                objDataSet = objMySqlGral.usp_TraerDescripcion("L5", Txt_L5.Text, Val(Txt_IdL4.Text))

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_DescripL5.Text = objDataSet.Tables(0).Rows(0).Item("campo").ToString
                    Txt_IdL5.Text = objDataSet.Tables(0).Rows(0).Item("idl5").ToString
                Else
                    If Sw_PedidoNuevo <> True Then
                        If Txt_L4.Text = "" AndAlso Txt_DescripL4.Text = "" Then
                            MsgBox("Debe especificar L4 para el Modelo.", MsgBoxStyle.Critical, "Validación")
                            Txt_L5.Text = ""
                            Txt_L4.Focus()
                        Else
                            Call CargarFormaConsulta("L5", 12)
                        End If
                    Else
                        Call CargarFormaConsulta("L5", 12)
                        'Txt_L5.Text = ""
                        'Txt_L4.Focus()
                    End If


                End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Txt_L6_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_L6.GotFocus
        Txt_L6.SelectAll()
    End Sub
    Private Sub Txt_L6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_L6.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
        Txt_IdL6.Text = ""
        'If Txt_SSSubLinea.Text.Length = 3 Then
        '    Txt_Proveedor.Focus()
        'End If
    End Sub
    Private Sub Txt_L6_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_L6.LostFocus
        Try
            If Txt_L6.Text.Length = 0 Then Exit Sub
            If Txt_L6.Text.Trim.Length < 3 Then
                Txt_L6.Text = pub_RellenarIzquierda(Txt_L6.Text.Trim, 3)
            End If


            Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
                objDataSet = objMySqlGral.usp_TraerDescripcion("L6", Txt_L6.Text, Val(Txt_IdL5.Text))

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_DescripL6.Text = objDataSet.Tables(0).Rows(0).Item("campo").ToString
                    Txt_IdL6.Text = objDataSet.Tables(0).Rows(0).Item("idl6").ToString
                Else
                    If Sw_PedidoNuevo <> 0 Then
                        If Txt_L5.Text = "" AndAlso Txt_DescripL5.Text = "" Then
                            MsgBox("Debe especificar L5 para el Modelo.", MsgBoxStyle.Critical, "Validación")
                            Txt_L6.Text = ""
                            Txt_L5.Focus()
                        Else
                            Call CargarFormaConsulta("L6", 13)
                        End If
                    Else
                        Call CargarFormaConsulta("L6", 13)
                        'Txt_L6.Text = ""
                        'Txt_L5.Focus()
                    End If
                End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Txt_Depto_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Depto.TextChanged
        Txt_IdFamilia.Text = ""
        Txt_Familia.Text = ""
        Txt_DescripFamilia.Text = ""
    End Sub
    Private Sub Txt_BuscarMaterial_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_BuscarMaterial.GotFocus
        Txt_BuscarMaterial.SelectAll()
    End Sub
    Private Sub Txt_BuscarMaterial_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_BuscarMaterial.KeyDown
        If e.KeyCode = 112 Then
            Call CargarFormaConsulta("ATM", 8)
        End If
    End Sub
    Private Sub Txt_BuscarMaterial_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_BuscarMaterial.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Txt_BuscarMaterial_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_BuscarMaterial.LostFocus
        Dim Opcion As Integer = 0
        Try
            If Txt_BuscarMaterial.Text.Length = 0 Then Exit Sub

            'Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
            '    objDataSet = objMySqlGral.usp_TraerDescripcion("AT", Txt_BuscarAtrib.Text, "")

            '    If objDataSet.Tables(0).Rows.Count > 0 Then
            '        Txt_BuscarAtrib.Text = objDataSet.Tables(0).Rows(0).Item("campo").ToString
            '        'Txt_IdDepto.Text = objDataSet.Tables(0).Rows(0).Item("iddepto").ToString
            '    Else

            '        'Opcion = 1

            '        'Using objCatalogoEst As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
            '        '    objCatalogoEst.usp_Captura_Atributo(Opcion, Txt_BuscarAtrib.Text)
            '        'End Using

            '        Call CargarFormaConsulta("AT", 8)
            '    End If
            'End Using

            'Call TxtLostfocus(Txt_Depto, Txt_DescripDepto, "ED")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Txt_BuscarColor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_BuscarColor.GotFocus
        Txt_BuscarColor.SelectAll()
    End Sub
    Private Sub Txt_BuscarColor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_BuscarColor.KeyDown
        If e.KeyCode = 112 Then
            Call CargarFormaConsulta("ATC", 9)
        End If
    End Sub
    Private Sub Txt_BuscarColor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_BuscarColor.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Txt_Division_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Division.TextChanged
        Txt_IdDepto.Text = ""
        Txt_Depto.Text = ""
        Txt_DescripDepto.Text = ""
    End Sub
    Private Sub Txt_Familia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Familia.TextChanged
        Txt_IdLinea.Text = ""
        Txt_Linea.Text = ""
        Txt_DescripLinea.Text = ""
    End Sub
    Private Sub Txt_Linea_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Linea.TextChanged
        Txt_IdL1.Text = ""
        Txt_L1.Text = ""
        Txt_DescripL1.Text = ""
    End Sub
    Private Sub Txt_L1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_L1.TextChanged
        'If Txt_SubLinea.Text.Length = 3 Then
        '    Txt_TipoArt.Focus()
        'End If
        'If Sw_Load = True Then Exit Sub
        Txt_IdL2.Text = ""
        Txt_L2.Text = ""
        Txt_DescripL2.Text = ""
    End Sub
    Private Sub Txt_L2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_L2.TextChanged
        Txt_IdL3.Text = ""
        Txt_L3.Text = ""
        Txt_DescripL3.Text = ""
    End Sub
    Private Sub Txt_L3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_L3.TextChanged
        Txt_IdL4.Text = ""
        Txt_L4.Text = ""
        Txt_DescripL4.Text = ""
    End Sub
    Private Sub Txt_L4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_L4.TextChanged
        Txt_IdL5.Text = ""
        Txt_L5.Text = ""
        Txt_DescripL5.Text = ""
    End Sub
    Private Sub Txt_L5_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_L5.TextChanged
        Txt_IdL6.Text = ""
        Txt_L6.Text = ""
        Txt_DescripL6.Text = ""
    End Sub
    Private Sub Txt_Descripap_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Descripap.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub PBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBox.Click

    End Sub
    Private Sub PBox_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PBox.DoubleClick
        'mreyes 03/Marzo/2012 10:01 a.m.
        Try
            Dim myForm As New frmConsultaImagen
            myForm.Txt_Estilon.Text = Txt_Modelo.Text
            myForm.Txt_Marca.Text = Txt_Marca.Text
            myForm.Txt_NoFoto.Text = Txt_NoFoto.Text
            myForm.ShowDialog()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub PBox2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PBox2.DoubleClick
        'mreyes 03/Marzo/2012 10:01 a.m.
        Try
            Dim myForm As New frmConsultaImagen
            myForm.Txt_Estilon.Text = Txt_Modelo.Text
            myForm.Txt_Marca.Text = Txt_Marca.Text
            myForm.Txt_NoFoto.Text = Txt_NoFoto.Text
            myForm.ShowDialog()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub
    Private Sub Txt_Categoria_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Categoria.LostFocus
        Try
            If Txt_Categoria.Text.Length = 0 Then Exit Sub

            If Txt_Categoria.Text.Trim.Length < 3 Then
                Txt_Categoria.Text = pub_RellenarIzquierda(Txt_Categoria.Text.Trim, 3)
            End If
            Call TxtLostfocus(Txt_Categoria, Txt_DescripCategoria, "C")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Txt_Categoria_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Categoria.GotFocus
        Txt_Categoria.SelectAll()
    End Sub

    Private Sub Txt_Categoria_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Categoria.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

#End Region
#Region "Eventos Grid Corrida"

    Private Sub DGrid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellEndEdit
        'mreyes 23/Febrero/2012 11:40 a.m.
        Try
            Dim columna As Integer = DGrid.CurrentCell.ColumnIndex
            Dim renglon As Integer = DGrid.CurrentCell.RowIndex

            Sw_RegistroCorrida = True
            If columna = 1 Then
                If Mid(Cbo_Medida.Text, 1, 1) <> "N" Then
                    If DGrid.Rows(renglon).Cells(columna).Value <> "L" Then
                        MsgBox("El intervalo en la medida '" & Cbo_Medida.Text & "' es L.", MsgBoxStyle.Critical, "Validación")
                        DGrid.Rows(renglon).Cells(columna).Value = "L"
                    End If
                End If
            End If

            If columna = 2 Or columna = 3 Then
                '' VALIDAR LO QUE SE ESTA ESCRIBIENDO SI

                If Mid(Cbo_Medida.Text, 1, 1) = "N" Then
                    If Not IsNumeric(DGrid.Rows(renglon).Cells(columna).Value) Then
                        MsgBox("Debe especificar un número valido para la corrida.", MsgBoxStyle.Critical, "Validación")
                    End If
                    DGrid.Rows(renglon).Cells(columna).Value = pub_RellenarIzquierda(DGrid.Rows(renglon).Cells(columna).Value, 2)
                End If

                If Mid(Cbo_Medida.Text, 1, 1) <> "N" Then
                    If IsNumeric(DGrid.Rows(renglon).Cells(columna).Value) And Mid(Cbo_Medida.Text, 1, 1) = "L" Then
                        MsgBox("Debe especificar una letra válido para la corrida.", MsgBoxStyle.Critical, "Validación")
                    Else
                        Txt_Campo.Text = DGrid.Rows(renglon).Cells(columna).Value
                        Txt_Campo1.Text = Mid(Cbo_Medida.Text, 1, 1)
                        Call TxtGrid(Txt_Campo1, Txt_Campo, "LT")
                        DGrid.Rows(renglon).Cells(columna).Value = Txt_Campo.Text
                        If columna = 2 Then
                            DGrid.Rows(renglon).Cells("ordenini").Value = Txt_Campo.Text
                        Else
                            DGrid.Rows(renglon).Cells("ordenfin").Value = Txt_Campo.Text
                        End If

                    End If
                End If
            End If

            If columna = 4 Then
                '' calcular el costo
                DGrid.Rows(renglon).Cells(6).Value = pub_CalcularPrecioVenta(DGrid.Rows(renglon).Cells(5).Value, Val(Txt_Factor.Text))
                Costo = pub_CalcularCostoPedido(DGrid.Rows(renglon).Cells(4).Value, Val(Txt_Dsctopp.Text), Val(Txt_Dscto01.Text), Val(Txt_Dscto02.Text), Val(Txt_Dscto03.Text), Val(Txt_Dscto04.Text), Val(Txt_Dscto05.Text), Val(Txt_Iva.Text))
                DGrid.Rows(renglon).Cells(5).Value = Costo
                DGrid.Rows(renglon).Cells(7).Value = pub_CalcularMargenPedido((DGrid.Rows(renglon).Cells(6).Value), Costo)
            End If
            If columna = 6 Then
                Costo = DGrid.Rows(renglon).Cells(5).Value

                DGrid.Rows(renglon).Cells(7).Value = pub_CalcularMargenPedido((DGrid.Rows(renglon).Cells(6).Value), Costo)
            End If

            If columna = 7 Then
                DGrid.Rows(renglon).Cells(6).Value = pub_CalcularPrecioVentaMargen(DGrid.Rows(renglon).Cells(5).Value / (1 - DGrid.Rows(renglon).Cells(7).Value / 100))


            End If

            If Accion = 1 Then
                MarcaCeldasGridSuc()
            End If

            'If Accion = 2 Then
            '    blnCambiaCorrida = True
            'End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub TxtGrid(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
        'mreyes 23/Febrero/2012 11:50 a.m.
        Dim myForm As New frmConsulta
        If Txt_Campo.Text.Length = 0 Then Exit Sub
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
            Try
                objDataSet = objMySqlGral.usp_TraerDescripcion(Tipo, Txt_Campo.Text, Txt_Campo1.Text)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_Campo1.Text = objDataSet.Tables(0).Rows(0).Item("campo").ToString
                Else
                    Txt_Campo.Text = ""
                    If Tipo <> "E" Then
                        myForm.Campo1 = Txt_Campo1.Text
                        myForm.Tipo = Tipo
                        myForm.ShowDialog()
                        Txt_Campo.Text = myForm.Campo
                        Txt_Campo1.Text = myForm.Campo1
                        ''If Txt_Campo.Text.Length = 0 Then
                        ''    Txt_Campo.Focus()
                        ''End If

                    End If
                End If


            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub
    Private Sub DGrid_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.CurrentCellDirtyStateChanged
        'mreyes 17/Febrero/2012 05:32 p.m.
        Try

            Dim columna As Integer = DGrid.CurrentCell.ColumnIndex
            Dim renglon As Integer = DGrid.CurrentCell.RowIndex
            Dim Importe As Double

            If columna = 4 Or columna = 6 Then
                If DGrid.Rows(renglon).Cells(4).Value <> 0 And DGrid.Rows(renglon).Cells(5).Value <> 0 Then
                    Importe = DGrid.Rows(renglon).Cells(4).Value
                    DGrid.Rows(renglon).Cells(4).Value = Format(Importe, "#,##0.00")
                    Importe = DGrid.Rows(renglon).Cells(5).Value
                    DGrid.Rows(renglon).Cells(5).Value = Format(Importe, "#,##0.00")
                    'Costo = pub_CalcularCostoPedido(DGrid.Rows(renglon).Cells(4).Value, Val(Txt_Dsctopp.Text), Val(Txt_Dscto01.Text), Val(Txt_Dscto02.Text), Val(Txt_Dscto03.Text), Val(Txt_Dscto04.Text), Val(Txt_Dscto05.Text), Val(Txt_Iva.Text))
                    Costo = Importe

                    DGrid.Rows(renglon).Cells(7).Value = Format(pub_CalcularMargenPedido((DGrid.Rows(renglon).Cells(6).Value), Costo), "#0.00")
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub DGrid_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGrid.EditingControlShowing
        Dim validar As TextBox = CType(e.Control, TextBox)
        Try
            ' agregar el controlador de eventos para el KeyPress   

            AddHandler validar.KeyPress, AddressOf validar_Keypress
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub DGrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DGrid.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub
    Private Sub DGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.Click
        Dim Precio As Decimal
        Dim Corrida As String = ""
        Dim Proveedor As String = ""
        Try

            If DGrid2.Rows(0).Cells("col_Proveedor").Value = "" Then Exit Sub

            'Proveedor = DGrid2.Rows(DGrid2.CurrentRow.Index).Cells("col_Proveedor").Value
            Proveedor = ProveedorB
            Corrida = DGrid.Rows(DGrid.CurrentRow.Index).Cells("Columna1").Value
            Precio = DGrid.Rows(DGrid.CurrentRow.Index).Cells("Columna6").Value

            If Corrida = "" AndAlso Precio = 0 Then Exit Sub

            For j As Integer = 0 To DgridSuc.Rows.Count - 2
                DgridSuc.Rows(j).Cells("precio").Value = Precio
                DgridSuc.Rows(j).Cells("corrida").Value = Corrida
            Next

            Using objCatalogoEst As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                objDataSetSuc = objCatalogoEst.usp_TraerDetSucArt(Txt_Marca.Text, Proveedor, Txt_Modelo.Text, Corrida)

                If objDataSetSuc.Tables(0).Rows.Count > 0 Then

                    If DgridSuc.Rows.Count <> 0 Then
                        For i As Integer = 0 To DgridSuc.Rows.Count - 2
                            If DgridSuc.Rows(i).Cells("Selec").Value = True Then
                                DgridSuc.Rows(i).Cells("Selec").Value = False
                            End If
                        Next

                        For i As Integer = 0 To objDataSetSuc.Tables(0).Rows.Count - 1
                            For j As Integer = 0 To DgridSuc.Rows.Count - 2
                                'If Precio <> objDataSetSuc.Tables(0).Rows(i).Item("precio") Then Continue For
                                If DgridSuc.Rows(j).Cells("sucursal").Value = objDataSetSuc.Tables(0).Rows(i).Item("sucursal").ToString Then
                                    DgridSuc.Rows(j).Cells("Selec").Value = True
                                    DgridSuc.Rows(j).Cells("precio").Value = objDataSetSuc.Tables(0).Rows(i).Item("precio")
                                End If
                            Next
                        Next
                    End If

                Else

                    If DgridSuc.Rows.Count <> 0 Then
                        For i As Integer = 0 To DgridSuc.Rows.Count - 2
                            If DgridSuc.Rows(i).Cells("Selec").Value = True Then
                                DgridSuc.Rows(i).Cells("Selec").Value = False
                            End If
                        Next
                    End If

                End If

            End Using

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub DGrid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGrid.KeyUp
        Dim Precio As Decimal
        Dim Corrida As String = ""
        Dim Proveedor As String = ""
        Try
            Try

                If DGrid2.Rows(0).Cells("col_Proveedor").Value = "" Then Exit Sub

                Proveedor = DGrid2.Rows(DGrid2.CurrentRow.Index).Cells("col_Proveedor").Value
                Corrida = DGrid.Rows(DGrid.CurrentRow.Index).Cells("Columna1").Value
                Precio = DGrid.Rows(DGrid.CurrentRow.Index).Cells("Columna6").Value

                If Corrida = "" AndAlso Precio = 0 Then Exit Sub

                For j As Integer = 0 To DgridSuc.Rows.Count - 2
                    DgridSuc.Rows(j).Cells("precio").Value = Precio
                    DgridSuc.Rows(j).Cells("corrida").Value = Corrida
                Next

                Using objCatalogoEst As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                    objDataSetSuc = objCatalogoEst.usp_TraerDetSucArt(Txt_Marca.Text, Txt_Proveedor.Text, Txt_Modelo.Text, Corrida)

                    If objDataSetSuc.Tables(0).Rows.Count > 0 Then

                        If DgridSuc.Rows.Count <> 0 Then
                            For i As Integer = 0 To DgridSuc.Rows.Count - 2
                                If DgridSuc.Rows(i).Cells("Selec").Value = True Then
                                    DgridSuc.Rows(i).Cells("Selec").Value = False
                                End If
                            Next

                            For i As Integer = 0 To objDataSetSuc.Tables(0).Rows.Count - 1
                                For j As Integer = 0 To DgridSuc.Rows.Count - 2
                                    If Precio <> objDataSetSuc.Tables(0).Rows(i).Item("precio") Then Continue For
                                    If DgridSuc.Rows(j).Cells("sucursal").Value = objDataSetSuc.Tables(0).Rows(i).Item("sucursal").ToString Then
                                        DgridSuc.Rows(j).Cells("Selec").Value = True
                                        DgridSuc.Rows(j).Cells("precio").Value = objDataSetSuc.Tables(0).Rows(i).Item("precio")
                                    End If
                                Next
                            Next
                        End If

                    Else

                        'If DgridSuc.Rows.Count <> 0 Then
                        '    For i As Integer = 0 To DgridSuc.Rows.Count - 2
                        '        If DgridSuc.Rows(i).Cells("Selec").Value = True Then
                        '            DgridSuc.Rows(i).Cells("Selec").Value = False
                        '        End If
                        '    Next
                        'End If

                    End If

                End Using

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

#End Region
#Region "Eventos Grid Atributos"
    Private Sub DGridMaterial_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGridMat.KeyDown
        Try
            If (e.KeyCode = Keys.Delete) Then
                If Accion = 1 Or Accion = 2 Then
                    If DGridMat.Rows(DGridMat.CurrentRow.Index).Cells("idatrib").Value <> "" Then
                        DGridMat.Rows().Remove(DGridMat.CurrentRow)
                    End If
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub DGridColor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGridColor.KeyDown
        Try
            If (e.KeyCode = Keys.Delete) Then
                If Accion = 1 Or Accion = 2 Then
                    If DGridMat.Rows(DGridMat.CurrentRow.Index).Cells("idatrib").Value <> "" Then
                        DGridMat.Rows().Remove(DGridMat.CurrentRow)
                    End If
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
#End Region
#Region "Eventos Grid Proveedor"
    Private Sub DGrid2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid2.Click
        'Dim Proveedor As String = ""

        Dim Margen As Decimal
        Dim PComp As Decimal
        Dim Precio As Decimal

        Try
            If DGrid2.Rows(DGrid2.CurrentRow.Index).Cells("col_Proveedor").Value = Nothing Then Exit Sub

            ProveedorB = DGrid2.Rows(DGrid2.CurrentRow.Index).Cells("col_Proveedor").Value


            If ProveedorB = Nothing Then
                ProveedorB = ""
            End If


            Using objCatalogoEst As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                objDataSet = objCatalogoEst.usp_TraerCorrida2(Txt_Marca.Text, Txt_Modelo.Text, ProveedorB, "")

                If objDataSet.Tables(0).Rows.Count > 0 Then

                    DGrid.Rows.Clear()
                    'DgridSuc.Dispose()
                    'probar
                    Call usp_TraerModeloCATALOGO(ProveedorB, objDataSet.Tables(0).Rows(0).Item(2).ToString)

                    For I As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                        Costo = pub_CalcularCostoPedido((objDataSet.Tables(0).Rows(I).Item(8)), Val(Txt_Dsctopp.Text), Val(Txt_Dscto01.Text), Val(Txt_Dscto02.Text), Val(Txt_Dscto03.Text), Val(Txt_Dscto04.Text), Val(Txt_Dscto05.Text), Val(Txt_Iva.Text))
                        Precio = Val(objDataSet.Tables(0).Rows(I).Item("precio"))
                        PComp = Val(objDataSet.Tables(0).Rows(I).Item("costo"))
                        Margen = pub_CalcularMargenPedido(Precio, Costo)




                        DGrid.Rows.Add(objDataSet.Tables(0).Rows(I).Item(2).ToString, _
                                         objDataSet.Tables(0).Rows(I).Item(5).ToString, _
                                         objDataSet.Tables(0).Rows(I).Item(6).ToString, _
                                         objDataSet.Tables(0).Rows(I).Item(7).ToString, _
                                         Val(objDataSet.Tables(0).Rows(I).Item(8)), _
                                         Costo, _
                                         Val(objDataSet.Tables(0).Rows(I).Item(9)), _
                                         Margen, _
                                         objDataSet.Tables(0).Rows(I).Item(12).ToString, _
                                         "", "", _
                                        objDataSet.Tables(0).Rows(I).Item(14).ToString, _
                                        objDataSet.Tables(0).Rows(I).Item(15).ToString, _
                                        objDataSet.Tables(0).Rows(I).Item(13).ToString, _
                                        Val(objDataSet.Tables(0).Rows(I).Item("precio")))

                    Next

                    For j As Integer = 0 To DgridSuc.Rows.Count - 2
                        DgridSuc.Rows(j).Cells("precio").Value = objDataSet.Tables(0).Rows(0).Item("precio")
                        DgridSuc.Rows(j).Cells("corrida").Value = objDataSet.Tables(0).Rows(0).Item("corrida")
                    Next

                    Corrida = DGrid.Rows(0).Cells("Columna1").Value
                    CorridaB = DGrid.Rows(0).Cells("Columna1").Value
                    Proveedor = DGrid2.Rows(0).Cells("col_Proveedor").Value

                    For i As Integer = 0 To DgridSuc.Columns.Count - 1
                        DgridSuc.Columns.Remove(DgridSuc.Columns(0))
                    Next

                    Call RellenaGridSuc()

                Else
                    DGrid.Rows.Clear()
                    DGrid.Rows.Add()

                    For i As Integer = 0 To DgridSuc.Columns.Count - 1
                        DgridSuc.Columns.Remove(DgridSuc.Columns(0))
                    Next

                    Call RellenaGridSuc()

                End If
            End Using
           

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub DGrid2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGrid2.KeyUp

        Dim Margen As Decimal
        Dim PComp As Decimal
        Dim Precio As Decimal

        Try

            If DGrid2.Rows(DGrid2.CurrentRow.Index).Cells("col_Proveedor").Value = Nothing Then Exit Sub
            ProveedorB = DGrid2.Rows(DGrid2.CurrentRow.Index).Cells("col_Proveedor").Value

            If ProveedorB = Nothing Then
                ProveedorB = ""
            End If

            Lbl_Proveedor.Text = "Proveedor Seleccionado : " & ProveedorB

            Using objCatalogoEst As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                objDataSet = objCatalogoEst.usp_TraerCorrida2(Txt_Marca.Text, Txt_Modelo.Text, ProveedorB, "")

                If objDataSet.Tables(0).Rows.Count > 0 Then

                    DGrid.Rows.Clear()
                    'DgridSuc.Dispose()

                    For I As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                        Costo = pub_CalcularCostoPedido((objDataSet.Tables(0).Rows(I).Item(6)), Val(Txt_Dsctopp.Text), Val(Txt_Dscto01.Text), Val(Txt_Dscto02.Text), Val(Txt_Dscto03.Text), Val(Txt_Dscto04.Text), Val(Txt_Dscto05.Text), Val(Txt_Iva.Text))
                        Precio = Val(objDataSet.Tables(0).Rows(I).Item("precio"))
                        PComp = Val(objDataSet.Tables(0).Rows(I).Item("costo"))
                        Margen = pub_CalcularMargenPedido(Precio, Costo)

                        DGrid.Rows.Add(objDataSet.Tables(0).Rows(I).Item(2).ToString, _
                                         objDataSet.Tables(0).Rows(I).Item(5).ToString, _
                                         objDataSet.Tables(0).Rows(I).Item(6).ToString, _
                                         objDataSet.Tables(0).Rows(I).Item(7).ToString, _
                                         Val(objDataSet.Tables(0).Rows(I).Item(8)), _
                                         Val(objDataSet.Tables(0).Rows(I).Item(9)), _
                                         Margen, _
                                         objDataSet.Tables(0).Rows(I).Item(12).ToString, _
                                         "", "", _
                                        objDataSet.Tables(0).Rows(I).Item(14).ToString, _
                                        objDataSet.Tables(0).Rows(I).Item(15).ToString, _
                                        objDataSet.Tables(0).Rows(I).Item(13).ToString, _
                                        Val(objDataSet.Tables(0).Rows(I).Item("precio")))
                    Next

                    For i As Integer = 0 To DgridSuc.Columns.Count - 1
                        DgridSuc.Columns.Remove(DgridSuc.Columns(0))
                    Next

                    Call RellenaGridSuc()

                Else
                    DGrid.Rows.Clear()
                    DGrid.Rows.Add()

                    For i As Integer = 0 To DgridSuc.Columns.Count - 1
                        DgridSuc.Columns.Remove(DgridSuc.Columns(0))
                    Next

                    Call RellenaGridSuc()

                End If
            End Using


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
#End Region
#Region "Eventos Grid Sucursales"
    Private Sub DgridSuc_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgridSuc.CellEndEdit
        Try
            If Me.DgridSuc.Columns(e.ColumnIndex).Name <> "precio" Then Exit Sub

            DgridSuc.CurrentCell.Value = "$" + Format(CDec(DgridSuc.CurrentCell.Value), "#,##0.00")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
#End Region
#Region "Eventos Grid Corrida Depto"
    Private Sub DGridC_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGridC.CellEndEdit
        Try
            If Me.DGridC.Columns(e.ColumnIndex).Name <> "col_depto" Then Exit Sub



        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub DGridC_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGridC.EditingControlShowing
        Dim validar As TextBox = CType(e.Control, TextBox)
        Try
            ' agregar el controlador de eventos para el KeyPress   

            AddHandler validar.KeyPress, AddressOf validar_Keypress2
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub DGridC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGridC.KeyDown
        Dim columna As Integer
        'Dim nRenglon As Int32 = DGridC.CurrentRow.Index

        'Dim caracter As Char = e.KeyChar
        Try

            'If DGridC.CurrentRow Is Nothing Then
            '    DGridC.CurrentCell = Me.DGridC(0, nRenglon + 1)
            'End If
            columna = DGridC.CurrentCell.ColumnIndex

            If Accion = 3 Or Accion = 4 Then
                Exit Sub
            End If

            If columna = 5 Then
                If e.KeyCode = 112 Or e.KeyCode = 13 Then
                    Call CargarFormaConsulta("ED", 10)
                End If
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub DGridC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DGridC.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub
#End Region

    Private Sub Txt_Proveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Proveedor.TextChanged

    End Sub

    Private Sub DGrid2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid2.CellContentClick

    End Sub

    Private Sub Tp_Costos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tp_Costos.Click

    End Sub

    Private Sub Panel3_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub Pnl_Edicion_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Edicion.Paint

    End Sub
End Class

