Public Class frmCatalogoFotosDocs
    Dim Sql As String
    Public Accion As Integer  '' 1  = nuevo, 2 = edicion , 3 = eliminar , 4 = consultar 
    Public Sw_Registro As Boolean = False
    Private objDataSet As Data.DataSet
    Public Tipo As Integer '1 = ife 2 = Comp de Dom, 3 = Predial, 4 = Comp de Ingresos, 5 = Firma, 6 = Firma2 
    'Public Glb_RutaFotosDocs As String = "C:\Imagenes"
    Public ID As Integer
    Public permiitr As Boolean = False
    Public tipo2 As String
    Dim NoFoto As String = "1"

    Private Sub CargarFotoDocs()
        Try
            Dim Archivo As String = ""
            Dim Sw_NoEncontro As Boolean = False
            Dim count As Integer = 0
            Using objFoto As New BCL.BCLio(GLB_ConStringCredito)
                'Glb_RutaFotosDocs = "C:\Imagenes"
                Archivo = objFoto.pub_ArmarNombreFotoDocs(Glb_RutaFotosDocs, ID, Tipo, NoFoto)
                'Txt_NombreFoto.Text = objFoto.pub_ArmarNombreFotoDocs("", ID, Tipo, txt_numFoto.Text).Substring(1)
                Txt_NombreFoto.Text = Archivo
                If objFoto.pub_ExisteArchivo(Archivo) = True Then
                    Sw_NoEncontro = True
                    PBox.Image = New System.Drawing.Bitmap(Archivo)
                    permiitr = True
                    txt_numFoto.Text = NoFoto
                    txt_pertenece.Enabled = False
                    txt_numFoto.Enabled = False
                    Exit Sub
                Else
                    If NoFoto > 1 Then
                        NoFoto = 1
                        CargarFotoDocs()
                        Exit Sub
                    End If
                End If

                For i As Integer = 0 To 9
                    'Txt_NoFoto.Text = i
                    Archivo = objFoto.pub_ArmarNombreFotoDocs(Glb_RutaFotosDocs, ID, Tipo, txt_numFoto.Text)
                    If objFoto.pub_ExisteArchivo(Archivo) = True Then
                        Sw_NoEncontro = True
                        PBox.Image = New System.Drawing.Bitmap(Archivo)
                        Exit Sub
                    End If
                Next

                If Sw_NoEncontro = False Then
                    Txt_NombreFoto.Text = ""
                End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Function TraerFoto(ByVal NoFoto As String) As Boolean
        Try
            TraerFoto = False
            Dim Archivo As String = ""
            Using objFoto As New BCL.BCLio(GLB_ConStringCredito)
                Archivo = objFoto.pub_ArmarNombreFotoDocs(Glb_RutaFotosDocs, ID, Tipo, txt_numFoto.Text)
                If objFoto.pub_ExisteArchivo(Archivo) = True Then
                    PBox.Image = New System.Drawing.Bitmap(Archivo)
                    TraerFoto = True
                    Exit Function
                End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        Try
            Dim RutaOrigen As String = ""
            Dim RutaDestino As String = ""

            '' BUSCAR LA IMAGEN... SI LA ENCUENTRA PREGUNTAR PARA EDITARLA SINO DARLA DE ALTA CON UN NUMERO MAS 

            If MsgBox("Esta seguro de querer guardar el documento.?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub

            Using objFoto As New BCL.BCLio(GLB_ConStringCredito)
                RutaOrigen = Txt_Ruta.Text
                'RutaDestino = "C:\Imagenes"
                RutaDestino = objFoto.pub_ArmarNombreFotoDocs(Glb_RutaFotosDocs, ID, Tipo, txt_numFoto.Text)

                If objFoto.pub_ExisteArchivo(RutaDestino) = True Then
                    '' ya existe 
                    'If MsgBox("Esta seguro de querer modificar el documento'?. En caso contrario se registrará como nueva.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.Yes Then
                    '    ''sobreescribir la que ya existe 
                    '    objFoto.pub_RenombrarArchivo(RutaDestino, objFoto.pub_NombreArchivo(objFoto.pub_ArmarNombreFotoDocs(Glb_RutaFotosDocs, ID, Tipo, txt_numFoto.Text)))
                    '    objFoto.pub_EliminarArchivo(objFoto.pub_ArmarNombreFotoDocs(Glb_RutaFotosDocs, ID, Tipo, txt_numFoto.Text))
                    '    CambiarArchivo(RutaOrigen, RutaDestino)

                    'Else
                    Dim Exi As Boolean = True
                    While Exi = True
                        txt_numFoto.Text = CInt(txt_numFoto.Text) + 1
                        RutaDestino = objFoto.pub_ArmarNombreFotoDocs(Glb_RutaFotosDocs, ID, Tipo, txt_numFoto.Text)
                        If objFoto.pub_ExisteArchivo(RutaDestino) = True Then
                            Exi = True
                        Else
                            Exi = False
                            Exit While
                        End If
                    End While

                    'RutaDestino = objFoto.pub_ArmarNombreFotoDocs(Glb_RutaFotosDocs, ID, Tipo, txt_numFoto.Text)
                    'CambiarArchivo(RutaOrigen, RutaDestino)
                    'If Inserta_DocFotos(1) = False Then
                    '    MsgBox("No se pudo grabar correctamente la imagen.", MsgBoxStyle.Critical, "Aviso")
                    'End If

                    'CambiarArchivo(RutaOrigen, RutaDestino)
                    objFoto.pub_CopiarArchivo(RutaOrigen, RutaDestino)
                    RutaOrigen = Txt_Ruta.Text
                    Txt_Ruta.Text = RutaDestino
                    Txt_NombreFoto.Text = objFoto.pub_ArmarNombreFotoDocs("", ID, Tipo, txt_numFoto.Text).Substring(1)
                    If Inserta_DocFotos(1) = False Then
                        MsgBox("No se pudo grabar correctamente la imagen.", MsgBoxStyle.Critical, "Aviso")
                    End If
                    'End If
                Else
                    RutaDestino = objFoto.pub_ArmarNombreFotoDocs(Glb_RutaFotosDocs, ID, Tipo, txt_numFoto.Text)
                    'CambiarArchivo(RutaOrigen, RutaDestino)
                    objFoto.pub_CopiarArchivo(RutaOrigen, RutaDestino)
                    RutaOrigen = Txt_Ruta.Text
                    Txt_Ruta.Text = RutaDestino
                    Txt_NombreFoto.Text = objFoto.pub_ArmarNombreFotoDocs("", ID, Tipo, txt_numFoto.Text).Substring(1)
                    If Inserta_DocFotos(1) = False Then
                        MsgBox("No se pudo grabar correctamente la imagen.", MsgBoxStyle.Critical, "Aviso")
                    End If
                End If
            End Using
            MsgBox("Archivo correctamente grabado en la ruta '" & RutaDestino & "'", MsgBoxStyle.Information, "Confirmación")
            Me.Close()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Function Inserta_DocFotos(ByVal Opcion As Integer) As Boolean
        'mreyes 26/Marzo/2012 04:10 p.m.

        Using objCatalogoFoto As New BCL.BCLCatalogoProspecto(GLB_ConStringCredito)
            'Get a new Project DataSet
            Try
                objDataSet = objCatalogoFoto.Inserta_DocsFotos  'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow

                'Set the values in the DataRow

                objDataRow.Item("id") = ID
                objDataRow.Item("tipo") = tipo2
                objDataRow.Item("docfoto") = Txt_NombreFoto.Text
                objDataRow.Item("nofoto") = txt_numFoto.Text
                objDataRow.Item("pertenece") = txt_pertenece.Text
                objDataRow.Item("ruta") = Txt_Ruta.Text
                objDataRow.Item("fecha") = Format(Now.Date, "yyyy-MM-dd")
                objDataRow.Item("hora") = Format(Now, "hh:mm:ss")
                'Add the DataRow to the DataSet
                objDataSet.Tables(0).Rows.Add(objDataRow)

                'Add the Project
                If Not objCatalogoFoto.usp_Captura_DocFotos(Opcion, objDataSet) Then
                    Throw New Exception("Falló Inserción de Foto")
                Else
                    Inserta_DocFotos = True
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function
    Private Sub CambiarArchivo(ByVal RutaOrigen As String, ByVal RutaDestino As String)
        Dim Extension As String = ""
        Try
            Dim g As GBITMAPLib.GBitmap
            Using objFoto As New BCL.BCLio(GLB_ConStringCredito)
                Extension = objFoto.pub_ExtensionArchivo(RutaOrigen)
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
        Try
            OpenFileDialog.Filter = "img files (*.jpg)|*.jpg|All files (*.*)|*.*"
            OpenFileDialog.FileName = ""
            OpenFileDialog.ShowDialog()

            If OpenFileDialog.FileName = "" Then Exit Sub
            PBox.Image = New System.Drawing.Bitmap(OpenFileDialog.FileName)
            Txt_Ruta.Text = OpenFileDialog.FileName
            If Txt_Ruta.Text.Length > 0 Then
                Btn_Aceptar.Enabled = True
                permiitr = True
            End If
            txt_pertenece.Enabled = True
            txt_numFoto.Enabled = True
            'Txt_NombreFoto.Enabled = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_EliminarF_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_EliminarF.Click
        Try
            If MsgBox("Esta seguro de querer eliminar la imagen.?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.Yes Then
                Using objFoto As New BCL.BCLio(GLB_ConStringCredito)
                    PBox.Image = Nothing
                    objFoto.pub_EliminarArchivo(objFoto.pub_ArmarNombreFotoDocs(Glb_RutaFotosDocs, ID, Tipo, txt_numFoto.Text))
                End Using
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Limpiar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Limpiar.Click
        PBox.Image = Nothing
    End Sub
    Private Sub frmCatalogoFotosDocs_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub frmCatalogoFotosDocs_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            'Txt_NoFoto.Enabled = False
            'txt_pertenece.Enabled = False
            Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
            Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2
            Call GenerarToolTip()
            Call CargarFotoDocs()
            Call Edicion()
            Btn_Ant.Visible = True
            Btn_Sig.Visible = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub GenerarToolTip()
        Try

            ToolTip.SetToolTip(Btn_NuevoF, "Nueva Foto")
            ToolTip.SetToolTip(Btn_EliminarF, "Eliminar Foto")

            ToolTip.SetToolTip(Btn_Aceptar, "Guardar Foto")
            ToolTip.SetToolTip(Btn_Limpiar, "Limpiar datos")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Edicion()
        Try
            Select Case Accion
                Case 3, 4
                    ' no dar de alta fotos 
                    Btn_Limpiar.Enabled = False
                    Btn_Aceptar.Enabled = False
                    Btn_EliminarF.Enabled = False
                    Btn_NuevoF.Enabled = False

                Case 1, 2



            End Select
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub txt_pertenece_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_pertenece.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_NoFoto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_NombreFoto.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Btn_Sig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Sig.Click
        NoFoto = NoFoto + 1
        If NoFoto = 5 Then
            NoFoto = 1
        End If
        CargarFotoDocs()
    End Sub

    Private Sub Btn_Ant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ant.Click
        NoFoto = NoFoto - 1
        If NoFoto < 1 Then
            NoFoto = 5
        End If
        CargarFotoDocs()
    End Sub
End Class