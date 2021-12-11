Public Class frmFichaDeposito

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
            If Accion = 1 Then
                Dim RutaCarpeta As String = pub_TraerParame_Det("FICHADEP")
                Anio = Dt_Fecha.Value.ToString("yyyy")
                Mes = Dt_Fecha.Value.ToString("MMMM").ToUpper
                Using objIO As New BCL.BCLio(GLB_ConStringCipSis)
                    If objIO.pub_ExisteArchivo(RutaCarpeta & "\" & Anio & "\" & Mes & "\" & Txt_Proveedor.Text & "\" & Txt_Liquidacion.Text & "\" & Txt_Banco.Text & "-" & Txt_NoCheque.Text & ".jpg") = True Then
                        PBox.Image = New System.Drawing.Bitmap(RutaCarpeta & "\" & Anio & "\" & Mes & "\" & Txt_Proveedor.Text & "\" & Txt_Liquidacion.Text & "\" & Txt_Banco.Text & "-" & Txt_NoCheque.Text & ".jpg")
                    Else
                        MessageBox.Show("Archivo no encontrado", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.Close()
                    End If
                End Using
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
                    Else
                        Folio = objDataSet.Tables(0).Rows(0).Item("foliof").ToString
                        Folio = Folio + 1
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


        End If
    End Sub

    Private Sub usp_Traer_FichaRem()
        Try
            Using objFact As New BCL.BCLFacturas(GLB_ConStringCipSis)
                If objDataSet.Tables(0).Rows.Count > 0 Then

                    Accion = 4

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
                    ' no dar de alta fotos 

                    Btn_AceptarF.Enabled = False
                    Btn_EliminarF.Enabled = False
                    Btn_NuevoF.Enabled = False
                    Btn_Limpiar.Enabled = False


                Case 1, 2
                    If Accion = 1 Then
                    ElseIf Accion = 2 Then
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
        Dim RutaCarpeta As String = pub_TraerParame_Det("FICHADEP")

        Try
            Dim RutaOrigen As String = ""
            Dim RutaDestino As String = ""

            '' BUSCAR LA IMAGEN... SI LA ENCUENTRA PREGUNTAR PARA EDITARLA SINO DARLA DE ALTA CON UN NUMERO MAS 

            If MsgBox("Esta seguro de guardar la ficha de depósito?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub

            Anio = Dt_Fecha.Value.ToString("yyyy")
            Mes = Dt_Fecha.Value.ToString("MMMM").ToUpper

            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)
                If objIO.pub_CrearDirectorioChequesLiquidacion(RutaCarpeta, Anio, Mes, Txt_Proveedor.Text, Txt_Liquidacion.Text) = False Then
                    MsgBox("No se pudo generar la carpeta", MsgBoxStyle.Critical, "Error")
                    Exit Sub
                End If
            End Using

            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)
                RutaOrigen = Txt_Ruta.Text
                RutaDestino = ""
                'RutaDestino = objIO.pub_ArmarNombreFotoFicha(GLB_RutaArchivoFotoFichaRem, Txt_Folio.Text)
                RutaDestino = RutaCarpeta & "\" & Anio & "\" & Mes & "\" & Txt_Proveedor.Text & "\" & Txt_Liquidacion.Text & "\" & Txt_Banco.Text & "-" & Txt_NoCheque.Text & ".jpg"

                If objIO.pub_ExisteArchivo(RutaDestino) = True Then
                    '' ya existe 
                    If MsgBox("Esta seguro de modificar la ficha de depósito '" & Txt_Banco.Text & "-" & Txt_NoCheque.Text & "'?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.Yes Then
                        '    '    ''sobreescribir la que ya existe 
                        '    objIO.pub_RenombrarArchivo(RutaDestino, GLB_RutaArchivoFotoFichaRem & "\" & Anio & "\" & Mes & "\" & arrProv(i) & "\" & arrRemisiones(i) & ".jpg"
                        objIO.pub_EliminarArchivo(RutaCarpeta & "\" & Anio & "\" & Mes & "\" & Txt_Proveedor.Text & "\" & Txt_Liquidacion.Text & "\" & Txt_Banco.Text & "-" & Txt_NoCheque.Text & ".jpg")
                        'CambiarArchivo(RutaOrigen, RutaDestino)
                        objIO.pub_CopiarArchivo(RutaOrigen, RutaDestino)
                        'Else
                        '    RutaDestino = GLB_RutaArchivoFotoFichaRem & "\" & Anio & "\" & Mes & "\" & arrProv(i) & "\" & arrRemisiones(i) & ".jpg"
                        '    CambiarArchivo(RutaOrigen, RutaDestino)
                    End If
                Else
                    RutaDestino = RutaCarpeta & "\" & Anio & "\" & Mes & "\" & Txt_Proveedor.Text & "\" & Txt_Liquidacion.Text & "\" & Txt_Banco.Text & "-" & Txt_NoCheque.Text & ".jpg"
                    '                    CambiarArchivo(RutaOrigen, RutaDestino)
                    objIO.pub_CopiarArchivo(RutaOrigen, RutaDestino)
                End If

            End Using
            'End If
            'Next
            entro = True
            MsgBox("Archivo correctamente grabado en la ruta '" & RutaDestino & "'", MsgBoxStyle.Information, "Confirmación")
            Btn_AceptarF.Enabled = False
            Sw_Registro = True
            'Me.Dispose()
            Me.Close()
            'End If
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

                objDataRow.Item("idfolio") = IdFolio
                objDataRow.Item("idfoliosuc") = IdFolioSuc
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
            myForm.SW_FichaDeposito = True
            myForm.Txt_Marca.Text = Txt_Banco.Text + "-" + Txt_NoCheque.Text
            myForm.PBox.Image = PBox.Image
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
                    objIO.pub_EliminarArchivo(Archivo)
                End Using

                Using objFact As New BCL.BCLFacturas(GLB_ConStringCipSis)

                    objDataSet = objFact.Inserta_FichaRem  'INSERTA NUEVO DATASET
                    'Initialize a datarow object from the Project DataSet
                    Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow

                    'Set the values in the DataRow

                    objDataRow.Item("idfolio") = 0
                    objDataRow.Item("idfoliosuc") = ""
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

    Private Sub Txt_Importe_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        pub_SoloNumeros(sender, e)
    End Sub


    Private Function ValidarEdicion() As Boolean
        ValidarEdicion = False
        Try

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
