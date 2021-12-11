Public Class frmFichaRemision

    Dim Sql As String
    Public Accion As Integer  '' 1  = nuevo, 2 = edicion , 3 = eliminar , 4 = consultar 
    Public Sw_Registro As Boolean = False
    Public Prov As String
    Public ImpTotal As Decimal
    Private objDataSet As Data.DataSet

    Public arrRemisiones() As String
    Public arrProv() As String
    Public arrImporte() As Decimal
    Public arrIdFolio() As Integer

    Private Anio As String
    Private Mes As String

    Public referencias() As String
    Public strreferenc As String = ""
    Public entro As Boolean = False

    Private Sub frmCatalogoFotos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub frmCatalogoFotos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strFolios As String = "Fichas de Depósito - "
        Try

            If Accion = 0 Then

                Call usp_TraerUltFolioFichaRem()

                If referencias.Length <= 8 Then
                    For i As Integer = 0 To referencias.Length - 1
                        strreferenc = strreferenc + referencias(i) + ", "
                    Next
                Else
                    strreferenc = referencias.Length.ToString & " Remisiones"

                End If

                If arrRemisiones.Length = 1 Then
                    Me.Text = "Ficha de Depósito - " & arrRemisiones(0)
                ElseIf arrRemisiones.Length <= 4 Then
                    For i As Integer = 0 To arrRemisiones.Length - 1
                        'strFolios = strFolios + """" + arrRemisiones(i) + ""","
                        strFolios = strFolios + arrRemisiones(i) + ", "
                    Next
                    If strFolios <> "" Then
                        strFolios = Mid(strFolios, 1, strFolios.Length - 2)
                    End If

                    Me.Text = strFolios

                ElseIf arrRemisiones.Length >= 5 Then
                    Me.Text = "Ficha de Depósito - " & arrRemisiones.Length.ToString & " Folios"
                End If

                Call SumaImportes()
            End If

            If Accion = 4 Then
                Call usp_Traer_FichaRem()
                Call TraerFoto("")
            End If

            Call Edicion()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub usp_TraerUltFolioFichaRem()
        If Accion = 3 Or Accion = 4 Then Exit Sub
        Dim Folio As String
        Using objFAct As New BCL.BCLFacturas(GLB_ConStringCipSis)
            Try
                objDataSet = objFAct.usp_TraerUltFolioFichaRem()
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("foliof").ToString.Trim = "" Then
                        Txt_FolioF.Text = 1
                    Else
                        Folio = objDataSet.Tables(0).Rows(0).Item("foliof").ToString
                        Folio = Folio + 1
                        Txt_FolioF.Text = Folio
                    End If
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub SumaImportes()
        Dim ImporteTotal As Decimal = 0
        If arrImporte.Length > 0 Then
            For i As Integer = 0 To arrImporte.Length - 1
                ImporteTotal = ImporteTotal + arrImporte(i)
            Next

            Txt_Importe.Text = Format(ImporteTotal, "$#,###,##0.00")

        End If
    End Sub

    Private Sub usp_Traer_FichaRem()
        Try
            Using objFact As New BCL.BCLFacturas(GLB_ConStringCipSis)
                objDataSet = objFact.usp_Traer_FichaRem(Txt_Folio.Text, CInt(Txt_IdFolio.Text))
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_Importe.Text = Format(Val(objDataSet.Tables(0).Rows(0).Item("importe")), "$#,###,##0.00")
                    DTFicha.Value = CDate(objDataSet.Tables(0).Rows(0).Item("fecha"))

                    Accion = 4

                    Anio = DTFicha.Value.Year
                    Mes = DTFicha.Value.ToString("MMMM").ToUpper
                End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_NuevoF, "Nueva Ficha")
            ToolTip.SetToolTip(Btn_EliminarF, "Eliminar Ficha")
            ToolTip.SetToolTip(Btn_AceptarF, "Guardar Foto")
            ToolTip.SetToolTip(Btn_Limpiar, "Limpiar datos")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub LimpiarDatos()
        Try
            'Txt_Marca.Text = ""
            'Txt_Estilon.Text = ""
            'Txt_Estilof.Text = ""
            'Txt_Descripc.Text = ""

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

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

                    Pnl_Edicion.Enabled = False

                    Txt_Importe.BackColor = TextboxBackColor
                    DTFicha.BackColor = TextboxBackColor
                    ' no dar de alta fotos 

                    Btn_AceptarF.Enabled = False
                    Btn_EliminarF.Enabled = False
                    Btn_NuevoF.Enabled = False
                    Btn_Limpiar.Enabled = False

                    Label4.Visible = True

                Case 1, 2
                    If Accion = 1 Then
                        DTFicha.Focus()
                    ElseIf Accion = 2 Then
                        Txt_Importe.Focus()
                        'Txt_Estilon.Enabled = False
                        'Txt_Marca.Enabled = False
                        'Txt_Estilon.BackColor = TextboxBackColor
                        'Txt_Marca.BackColor = TextboxBackColor
                    End If
            End Select
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Accion = 2
        Call Edicion()
    End Sub

    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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

    Private Sub CargarFotoFicha()
        'mreyes 02/Marzo/2012 04:12 p.m.
        'Glb_RutaArchivoFotos
        Try
            Dim Archivo As String = ""
            'Dim NoFoto As String = "1"
            Dim Sw_NoEncontro As Boolean = False
            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)

                Archivo = GLB_RutaArchivoFotoFichaRem & "\" & Anio & "\" & Mes & "\" & Prov & "\" & Txt_Folio.Text & ".jpg"
                'Txt_NoFoto.Text = NoFoto
                If objIO.pub_ExisteArchivo(Archivo) = True Then
                    Sw_NoEncontro = True
                    PBox.Image = New System.Drawing.Bitmap(Archivo)
                    Exit Sub
                End If

            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Function TraerFoto(ByVal NoFoto As String) As Boolean
        'mreyes 02/Marzo/2012 04:57 p.m.
        Try
            TraerFoto = False
            Dim Archivo As String = ""
            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)
                Archivo = GLB_RutaArchivoFotoFichaRem & "\" & Anio & "\" & Mes & "\" & Prov & "\" & Txt_Folio.Text & ".jpg"
                If objIO.pub_ExisteArchivo(Archivo) = True Then
                    PBox.Image = New System.Drawing.Bitmap(Archivo)
                    TraerFoto = True
                    Exit Function
                End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Private Sub Btn_AceptarF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_AceptarF.Click
        Dim Anio As String
        Dim Mes As String

        Anio = DTFicha.Value.Year
        Mes = DTFicha.Value.ToString("MMMM").ToUpper

        Try
            Dim RutaOrigen As String = ""
            Dim RutaDestino As String = ""

            '' BUSCAR LA IMAGEN... SI LA ENCUENTRA PREGUNTAR PARA EDITARLA SINO DARLA DE ALTA CON UN NUMERO MAS 

            If MsgBox("Esta seguro de guardar la ficha de depósito?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub

            If ValidarEdicion() = True Then

                For i As Integer = 0 To arrRemisiones.Length - 1

                    If Inserta_FichaRem(arrIdFolio(i), arrRemisiones(i)) = True Then

                        ' Actualiza el campo 'pagado' en factprov
                        Using objCatCuentas As New BCL.BCLCatalogoCuentas(GLB_ConStringCipSis)
                            objCatCuentas.usp_ActualizaPagoFactura(1, arrRemisiones(i), "1", "", 0)
                        End Using

                        'Crea el directorio por año, mes y proveedor
                        Using objIO As New BCL.BCLio(GLB_ConStringCipSis)
                            If objIO.pub_CrearDirectorioRemisionProv(GLB_RutaArchivoFotoFichaRem, Anio, Mes, arrProv(i)) = False Then
                                MsgBox("No se pudo generar la carpeta '" & arrProv(i) & "'", MsgBoxStyle.Critical, "Error")
                                Exit Sub
                            End If
                        End Using

                        Using objIO As New BCL.BCLio(GLB_ConStringCipSis)
                            RutaOrigen = Txt_Ruta.Text
                            RutaDestino = ""
                            'RutaDestino = objIO.pub_ArmarNombreFotoFicha(GLB_RutaArchivoFotoFichaRem, Txt_Folio.Text)
                            RutaDestino = GLB_RutaArchivoFotoFichaRem & "\" & Anio & "\" & Mes & "\" & arrProv(i) & "\" & arrRemisiones(i) & ".jpg"

                            If objIO.pub_ExisteArchivo(RutaDestino) = True Then
                                '' ya existe 
                                If MsgBox("Esta seguro de modificar la ficha de depósito '" & Txt_Folio.Text & "'?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.Yes Then
                                    ''sobreescribir la que ya existe 
                                    objIO.pub_RenombrarArchivo(RutaDestino, GLB_RutaArchivoFotoFichaRem & "\" & Anio & "\" & Mes & "\" & arrProv(i) & "\" & arrRemisiones(i) & ".jpg")
                                    objIO.pub_EliminarArchivo(GLB_RutaArchivoFotoFichaRem & "\" & Anio & "\" & Mes & "\" & arrProv(i) & "\" & arrRemisiones(i) & ".jpg")
                                    'CambiarArchivo(RutaOrigen, RutaDestino)
                                    objIO.pub_CopiarArchivo(RutaOrigen, RutaDestino)
                                Else
                                    RutaDestino = GLB_RutaArchivoFotoFichaRem & "\" & Anio & "\" & Mes & "\" & arrProv(i) & "\" & arrRemisiones(i) & ".jpg"
                                    'CambiarArchivo(RutaOrigen, RutaDestino)
                                    objIO.pub_CopiarArchivo(RutaOrigen, RutaDestino)
                                End If
                            Else
                                RutaDestino = GLB_RutaArchivoFotoFichaRem & "\" & Anio & "\" & Mes & "\" & arrProv(i) & "\" & arrRemisiones(i) & ".jpg"
                                ' CambiarArchivo(RutaOrigen, RutaDestino)
                                objIO.pub_CopiarArchivo(RutaOrigen, RutaDestino)
                            End If
                            RutaOrigen = Txt_Ruta.Text

                            ' objIO.pub_CopiarArchivo(RutaOrigen, RutaDestino)
                        End Using
                    End If
                Next
                entro = True
                MsgBox("Archivo correctamente grabado en la ruta '" & RutaDestino & "'", MsgBoxStyle.Information, "Confirmación")
                Btn_AceptarF.Enabled = False
                Sw_Registro = True
                'Me.Dispose()
                Me.Close()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Function Inserta_FichaRem(ByVal IdFolio As Integer, ByVal IdFolioSuc As String) As Boolean

        Dim objDataSet As Data.DataSet
        'Dim IdCuenta As Integer
        Using objFact As New BCL.BCLFacturas(GLB_ConStringCipSis)
            'Get a new Project DataSet
            Try

                objDataSet = objFact.Inserta_FichaRem  'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow

                'Set the values in the DataRow

                'For i As Integer = 0 To arrRemisiones.Length - 1

                objDataRow.Item("foliof") = Val(Txt_FolioF.Text)
                objDataRow.Item("fecha") = DTFicha.Value
                objDataRow.Item("idfolio") = IdFolio
                objDataRow.Item("idfoliosuc") = IdFolioSuc
                objDataRow.Item("importe") = CDec(Txt_Importe.Text)
                objDataRow.Item("idusuario") = GLB_Idempleado

                'Add the DataRow to the DataSet
                objDataSet.Tables(0).Rows.Add(objDataRow)

                'Add the Project

                'objFact.usp_Captura_FichaRem(2, objDataSet)

                If Not objFact.usp_Captura_FichaRem(1, objDataSet) Then
                    Throw New Exception("Falló Inserción de la Ficha de Depósito. ")
                Else
                    Inserta_FichaRem = True
                End If
                'Next

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

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
                Btn_EliminarF.Enabled = True
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub PBox_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PBox.DoubleClick
        'mreyes 03/Marzo/2012 10:01 a.m.
        Try
            Dim myForm As New frmConsultaImagen
            myForm.SW_Ficha = True
            myForm.Txt_Marca.Text = Txt_Folio.Text
            myForm.Anio = Anio
            myForm.Mes = Mes
            myForm.Prov = Prov
            myForm.ShowDialog()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_EliminarF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_EliminarF.Click

        Dim Archivo As String = ""
        Try
            If MsgBox("Esta seguro de querer eliminar la imagen.?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.Yes Then
                Using objIO As New BCL.BCLio(GLB_ConStringCipSis)
                    PBox.Image = Nothing
                    Archivo = objIO.pub_EliminarArchivo(objIO.pub_ArmarNombreFotoFicha(GLB_RutaArchivoFotos, Txt_Folio.Text))
                    Archivo = objIO.pub_ArmarNombreFotoFicha(GLB_RutaArchivoFotoFichaRem, Txt_Folio.Text)
                    objIO.pub_EliminarArchivo(Archivo)
                End Using

                Using objFact As New BCL.BCLFacturas(GLB_ConStringCipSis)

                    objDataSet = objFact.Inserta_FichaRem  'INSERTA NUEVO DATASET
                    'Initialize a datarow object from the Project DataSet
                    Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow

                    'Set the values in the DataRow

                    objDataRow.Item("foliof") = Val(Txt_Folio.Text)
                    objDataRow.Item("fecha") = DTFicha.Value
                    objDataRow.Item("idfolio") = 0
                    objDataRow.Item("idfoliosuc") = ""
                    objDataRow.Item("importe") = CDec(Txt_Importe.Text)
                    objDataRow.Item("idusuario") = GLB_Idempleado

                    'Add the DataRow to the DataSet
                    objDataSet.Tables(0).Rows.Add(objDataRow)

                    'Add the Project

                    objFact.usp_Captura_FichaRem(2, objDataSet)

                    Btn_AceptarF.Enabled = False
                    Btn_EliminarF.Enabled = False
                End Using
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Limpiar.Click

        'Me.Txt_DescripMarca.Text = ""

        'Me.Txt_Estilof.Text = ""
        'Me.Txt_Estilon.Text = ""


        'Me.Txt_Marca.Text = ""


        'Txt_Descripc.Text = ""
        'PBox.Image = Nothing
        'Txt_Marca.Focus()
    End Sub

    Private Sub Txt_Referencia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Importe_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Importe.KeyPress
        pub_SoloNumeros(sender, e)
    End Sub

    Private Sub Txt_Importe_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Importe.LostFocus
        Txt_Importe.Text = Format(Val(Txt_Importe.Text), "$#,###,##0.00")
    End Sub

    Private Function ValidarEdicion() As Boolean
        ValidarEdicion = False
        Try
            If Txt_Importe.Text.Length = 0 Then
                MsgBox("Debe especificar el Importe del pago.", MsgBoxStyle.Critical, "Validación")
                Txt_Importe.Focus()
                Exit Function
            End If

            'If CDec(Txt_Importe.Text) <> ImpTotal Then
            '    MsgBox("El importe ingresado no coincide con el importe de la Factura.", MsgBoxStyle.Critical, "Validación")
            '    Txt_Importe.Focus()
            '    Exit Function
            'End If

            ValidarEdicion = True
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Function
End Class
