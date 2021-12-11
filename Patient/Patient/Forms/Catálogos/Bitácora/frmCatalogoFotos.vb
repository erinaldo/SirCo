Imports System
Imports System.IO
Imports System.Collections
Imports System.Drawing.Imaging

Public Class frmCatalogoFotos
    'mreyes 06/Marzo/2012 07:28 p.m. 
    '<BrowsableAttribute(False)>
    Public ReadOnly Property PropertyItems As PropertyItem()
    Dim Sql As String
    Public Accion As Integer  '' 1  = nuevo, 2 = edicion , 3 = eliminar , 4 = consultar 
    Public Sw_Registro As Boolean = False
    Private objDataSet As Data.DataSet





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
        Try
            'Accion = 1


            'If Accion = 1 Then
            '    ' LimpiarDatos()
            'Else
            '    Call usp_TraerEstilo()

            'End If
            'Call GenerarToolTip()
            'Call CargarFotoArticulo()

            Call Edicion()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub usp_TraerEstilo()
        Using objCatalogoEstilos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
            Try


                objDataSet = objCatalogoEstilos.usp_TraerEstilo(0, Txt_Marca.Text, Txt_Estilon.Text, IIf(Txt_Estilon.Text.Length > 0, "", Txt_Estilof.Text), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "")

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_Marca.Text = objDataSet.Tables(0).Rows(0).Item("marca").ToString
                    Txt_DescripMarca.Text = objDataSet.Tables(0).Rows(0).Item("descripmarca").ToString
                    Txt_Estilon.Text = objDataSet.Tables(0).Rows(0).Item("estilon").ToString
                    Txt_Estilof.Text = objDataSet.Tables(0).Rows(0).Item("estilof").ToString
                    Txt_Descripc.Text = objDataSet.Tables(0).Rows(0).Item("descripc").ToString
                    PBox.Image = Nothing
                Else
                    MsgBox("Estilo no encontrado.", MsgBoxStyle.Critical, "Aviso")
                    PBox.Image = Nothing
                    Txt_Estilof.Text = ""
                    Txt_Descripc.Text = ""
                End If
                Call CargarFotoArticulo()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub
    Private Sub GenerarToolTip()
        Try

            ToolTip.SetToolTip(Btn_NuevoF, "Nueva Foto")
            ToolTip.SetToolTip(Btn_EliminarF, "Eliminar Foto")
            ToolTip.SetToolTip(Btn_Ant, "Foto Anterior")
            ToolTip.SetToolTip(Btn_Sig, "Foto Siguiente")
            ToolTip.SetToolTip(Btn_AceptarF, "Guardar Foto")
            ToolTip.SetToolTip(Btn_Limpiar, "Limpiar datos")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub LimpiarDatos()
        Try
            Txt_Marca.Text = ""
            Txt_Estilon.Text = ""
            Txt_Estilof.Text = ""
            Txt_Descripc.Text = ""


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



    Private Sub Txt_Marca_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Marca.LostFocus
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
            If Txt_Marca.Text.Length = 0 Then Exit Sub

            Try
                Call TxtLostfocus(Txt_Marca, Txt_DescripMarca, "M")

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using




    End Sub


    Private Sub Txt_Estilon_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Estilon.GotFocus
        Txt_Estilon.SelectAll()
    End Sub

    Private Sub Txt_Estilon_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Estilon.KeyPress
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
        Call usp_TraerEstilo()
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

    Private Sub Txt_Proveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

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

                    Txt_Marca.BackColor = TextboxBackColor
                    Txt_Marca.BackColor = TextboxBackColor
                    Txt_Estilon.BackColor = TextboxBackColor
                    Txt_Estilof.BackColor = TextboxBackColor
                    Txt_Descripc.BackColor = TextboxBackColor


                    ' no dar de alta fotos 

                    Btn_AceptarF.Enabled = False
                    Btn_EliminarF.Enabled = False
                    Btn_NuevoF.Enabled = False

                Case 1, 2


                    If Accion = 1 Then
                        Txt_Marca.Focus()
                    ElseIf Accion = 2 Then
                        Txt_Marca.Focus()
                        'Txt_Estilon.Enabled = False
                        'Txt_Marca.Enabled = False
                        Txt_Estilon.BackColor = TextboxBackColor
                        Txt_Marca.BackColor = TextboxBackColor
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



    Private Sub DGrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)


        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Function Eliminar_Medida(ByVal Marca As String, ByVal Estilon As String, ByVal corrida As String) As Boolean
        'mreyes 23/Febrero/2012 03:47 p.m.
        'marca, estilo, medida, corrida
        Using objCatalogoEstilos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
            Try
                'Get the specific project selected in the ListView control
                Eliminar_Medida = objCatalogoEstilos.usp_EliminarMedida(Marca, Estilon, corrida)
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function


    Private Sub CargarFotoArticulo()
        'mreyes 02/Marzo/2012 04:12 p.m.
        'Glb_RutaArchivoFotos
        Try
            Dim Archivo As String = ""
            Dim NoFoto As String = "1"
            Dim Sw_NoEncontro As Boolean = False
            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)

                Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Estilon.Text, NoFoto)
                Txt_NoFoto.Text = NoFoto
                If objIO.pub_ExisteArchivo(Archivo) = True Then
                    Sw_NoEncontro = True
                    PBox.Image = New System.Drawing.Bitmap(Archivo)
                    Exit Sub
                End If

                For i As Integer = 0 To 9
                    Txt_NoFoto.Text = i
                    Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Estilon.Text, i)
                    If objIO.pub_ExisteArchivo(Archivo) = True Then
                        Sw_NoEncontro = True
                        PBox.Image = New System.Drawing.Bitmap(Archivo)
                        Exit Sub
                    End If
                Next

                If Sw_NoEncontro = False Then
                    Txt_NoFoto.Text = "1"
                End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub Btn_Sig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Sig.Click
        'mreyes 02/Marzo/2012 04:57 p.m.
        Try
            ''If Val(Txt_NoFoto.Text) < 9 Then
            ''    Txt_NoFoto.Text = Val(Txt_NoFoto.Text) + 1
            ''End If
            ''If TraerFoto(Txt_NoFoto.Text) = False Then
            ''    Txt_NoFoto.Text = Val(Txt_NoFoto.Text) - 1
            ''End If
            If Val(Txt_Estilon.Text) > 0 Then
                Txt_Estilon.Text = Val(Txt_Estilon.Text) + 1
                Txt_Estilof.Text = ""
                Call Txt_Estilon_LostFocus(sender, e)
            End If

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
                Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Estilon.Text, NoFoto)
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

    Private Sub Btn_Ant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ant.Click
        Try
            ''If Val(Txt_NoFoto.Text) <> 1 Then
            ''    If Val(Txt_NoFoto.Text) <= 9 And Val(Txt_NoFoto.Text > 0) Then
            ''        Txt_NoFoto.Text = Val(Txt_NoFoto.Text) - 1
            ''    End If
            ''End If
            ''If TraerFoto(Txt_NoFoto.Text) = False Then
            ''    If Txt_NoFoto.Text <> 1 Then
            ''        Txt_NoFoto.Text = Val(Txt_NoFoto.Text) - 1
            ''    End If

            ''End If

            If Val(Txt_Estilon.Text) > 0 Then
                Txt_Estilon.Text = Val(Txt_Estilon.Text) - 1
                Txt_Estilof.Text = ""
                Call Txt_Estilon_LostFocus(sender, e)
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
                RutaDestino = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Estilon.Text, Txt_NoFoto.Text)

                If objIO.pub_ExisteArchivo(RutaDestino) = True Then
                    '' ya existe 
                    If MsgBox("Esta seguro de querer modificar la foto '" & Txt_NoFoto.Text & "' del estilo '" & Txt_Estilon.Text & " para la marca '" & Txt_Marca.Text & "'?. En caso contrario se registrará como nueva.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.Yes Then
                        ''sobreescribir la que ya existe 
                        objIO.pub_RenombrarArchivo(RutaDestino, objIO.pub_NombreArchivo(objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Estilon.Text, "99")))
                        objIO.pub_EliminarArchivo(objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Estilon.Text, "99"))
                        'CambiarArchivo(RutaOrigen, RutaDestino)
                        objIO.pub_CopiarArchivo(RutaOrigen, RutaDestino)
                        If Inserta_ArtFotos(2) = False Then
                            MsgBox("No se pudo grabar correctamente la imagen.", MsgBoxStyle.Critical, "Aviso")
                        End If
                    Else
                        RutaDestino = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Estilon.Text, BuscarImagenSig)
                        'CambiarArchivo(RutaOrigen, RutaDestino)
                        objIO.pub_CopiarArchivo(RutaOrigen, RutaDestino)
                        If Inserta_ArtFotos(1) = False Then
                            MsgBox("No se pudo grabar correctamente la imagen.", MsgBoxStyle.Critical, "Aviso")
                        End If
                    End If
                Else
                    RutaDestino = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Estilon.Text, BuscarImagenSig)
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
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Function Inserta_ArtFotos(ByVal Opcion As Integer) As Boolean
        'mreyes 26/Marzo/2012 04:10 p.m.

        Using objCatalogoEstilos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
            'Get a new Project DataSet
            Try
                objDataSet = objCatalogoEstilos.Inserta_ArtFotos  'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow

                'Set the values in the DataRow

                objDataRow.Item("marca") = Trim(Txt_Marca.Text)
                objDataRow.Item("estilon") = (Txt_Estilon.Text)
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

    Private Function BuscarImagenSig() As String
        'mreyes 02/Marzo/2012 06:04 p.m.
        Try
            Dim Archivo As String = ""
            BuscarImagenSig = Txt_NoFoto.Text
            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)
                For i As Integer = Val(Txt_NoFoto.Text) To 9

                    Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Estilon.Text, i)
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
            BuscarImagenSig = 1
        End Try
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

            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub PBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBox.Click

    End Sub

    Private Sub PBox_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PBox.DoubleClick
        'mreyes 03/Marzo/2012 10:01 a.m.
        Try
            Dim myForm As New frmConsultaImagen
            myForm.Txt_Estilon.Text = Txt_Estilon.Text
            myForm.Txt_Marca.Text = Txt_Marca.Text
            myForm.Txt_NoFoto.Text = Txt_NoFoto.Text
            myForm.ShowDialog()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub Btn_EliminarF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_EliminarF.Click
        Try
            If MsgBox("Esta seguro de querer eliminar la imagen.?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.Yes Then
                Using objIO As New BCL.BCLio(GLB_ConStringCipSis)
                    PBox.Image = Nothing
                    objIO.pub_EliminarArchivo(objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Estilon.Text, BuscarImagenSig))
                End Using
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Marca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Marca.TextChanged

    End Sub

    Private Sub Txt_Estilon_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Estilon.LostFocus
        Txt_Estilon.Text = Txt_Estilon.Text.PadLeft(7)
        Call usp_TraerEstilo()

    End Sub

    Private Sub Txt_Estilon_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Estilon.TextChanged

    End Sub

    Private Sub Txt_Estilof_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Estilof.TextChanged

    End Sub

    Private Sub Pnl_Edicion_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Edicion.Paint

    End Sub

    Private Sub Btn_Limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Limpiar.Click

        Me.Txt_DescripMarca.Text = ""

        Me.Txt_Estilof.Text = ""
        Me.Txt_Estilon.Text = ""


        Me.Txt_Marca.Text = ""


        Txt_Descripc.Text = ""
        PBox.Image = Nothing
        Txt_Marca.Focus()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim objReader As New StreamReader("c:\PRUEBA.txt")

        Dim sLine As String = ""
        Dim arrText As New ArrayList()
        Dim Distrib As String = ""
        Dim Importe As Decimal = 0
        Dim pos As Integer = 0
        Dim pos1 As Integer = 0
        Dim pos2 As Integer = 0
        Dim pos3 As Integer = 0
        Dim pos4 As Integer = 0
        Dim pos5 As Integer = 0
        Dim pos6 As Integer = 0

        Dim cont As Integer = 0
        Dim i As Integer = 0
        Dim Sw_Encabezados As Boolean = False

        Do
            If Sw_Encabezados = False Then
                Sw_Encabezados = True
            Else

                sLine = objReader.ReadLine()
                If Not sLine Is Nothing Then
                    ' arrText.Add(MID(sLine,41,6)
                    Distrib = (Mid(sLine, 41, 6))

                    'primero
                    pos = InStr(sLine, "|")
                    pos1 = InStr(Mid(sLine, pos + 1), "|")
                    pos1 = pos1 + pos - 1
                    pos2 = InStr(Mid(sLine, pos1 + 4), "|")
                    pos2 = pos2 + pos1 + 4
                    pos3 = InStr(Mid(sLine, pos2 + 1), "|")
                    'pos3 = pos3 + pos2



                    Importe = Mid(sLine, pos2, pos3)



                End If
            End If
        Loop Until sLine Is Nothing
        objReader.Close()

    End Sub


    Private Sub ExtractMetaData(ByVal e As PaintEventArgs)

        Try
            'Create an Image object. 
            Dim theImage As Image = New Bitmap("C:\Users\ZTSISPC01\Desktop\escuelita\DSC01990,jpg")

            'Get the PropertyItems property from image.
            Dim propItems As PropertyItem() = theImage.PropertyItems

            'Set up the display.
            Dim font As New Font("Arial", 10)
            Dim blackBrush As New SolidBrush(Color.Black)
            Dim X As Integer = 0
            Dim Y As Integer = 0

            'For each PropertyItem in the array, display the id, type, and length.
            Dim count As Integer = 0
            Dim propItem As PropertyItem
            For Each propItem In propItems

                e.Graphics.DrawString("Property Item " + count.ToString(),
                   font, blackBrush, X, Y)
                Y += font.Height

                e.Graphics.DrawString("   iD: 0x" & propItem.Id.ToString("x"),
                   font, blackBrush, X, Y)
                Y += font.Height

                e.Graphics.DrawString("   type: " & propItem.Type.ToString(),
                   font, blackBrush, X, Y)
                Y += font.Height

                e.Graphics.DrawString("   length: " & propItem.Len.ToString() &
                    " bytes", font, blackBrush, X, Y)
                Y += font.Height

                count += 1
            Next propItem

            font.Dispose()
        Catch ex As ArgumentException
            MessageBox.Show("There was an error. Make sure the path to the image file is valid.")
        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            'Create an Image object. 
            Dim theImage As Image = New Bitmap("C:\Users\ZTSISPC01\Desktop\escuelita\DSC01990.jpg")

            'Get the PropertyItems property from image.
            Dim propItems As PropertyItem() = theImage.PropertyItems

            'Set up the display.
            Dim font As New Font("Arial", 10)
            Dim blackBrush As New SolidBrush(Color.Black)
            Dim X As Integer = 0
            Dim Y As Integer = 0

            'For each PropertyItem in the array, display the id, type, and length.
            Dim count As Integer = 0
            Dim propItem As PropertyItem

            For Each propItem In propItems
                Txt_Ruta.Text = propItem.Len.ToString()
                count += 1
            Next propItem
            ' propItems.Length.ToString()




            font.Dispose()
        Catch ex As ArgumentException
            MessageBox.Show("There was an error. Make sure the path to the image file is valid.")
        End Try
    End Sub
End Class
