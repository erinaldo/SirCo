Public Class frmCatalogoFotosEmp
    'miguel perez 03/Septiembre/2012 12:50 p.m. 

    Dim Sql As String
    Public Accion As Integer  '' 1  = nuevo, 2 = edicion , 3 = eliminar , 4 = consultar 
    Public Sw_Registro As Boolean = False
    Private objDataSet As Data.DataSet





    Private Sub Txt_Marca_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Empleado.GotFocus
        Txt_Empleado.SelectAll()
    End Sub

    Private Sub Txt_Empleado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Empleado.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub




    Private Sub TxtGrid(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
        'miguel pérez 03/Septiembre/2012 01:25 p.m.
        Call TraerEmpleado()
        Call CargarFotoEmpleado()
    End Sub
    Private Sub CargarFormaConsultaEmpleado()
        'mreyes 11/Junio/2012 06:04 p.m.

        Dim myForm As New frmConsultaEmpleado
        Txt_Nombre.Text = ""
        myForm.Estatus = ""
        myForm.ShowDialog()
        Txt_Empleado.Text = myForm.Campo
        Txt_Nombre.Text = myForm.Campo1
        If Txt_Empleado.Text.Length = 0 Then
            Txt_Empleado.Focus()
        End If
    End Sub
    Private Sub TraerEmpleado()
        If Txt_Empleado.Text.Length = 0 Then Txt_Nombre.Text = "" : Exit Sub


        Using objMySqlGral As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)
            Try
                If Val(Txt_Empleado.Text) = 0 Then
                    CargarFormaConsultaEmpleado()
                Else
                    objDataSet = objMySqlGral.usp_TraerNomEmpleado(Val(Txt_Empleado.Text), "", "", "", "", 0)
                    If objDataSet.Tables(0).Rows.Count = 1 Then
                        Txt_Nombre.Text = objDataSet.Tables(0).Rows(0).Item("nomcompleto").ToString
                    Else
                        Call CargarFormaConsultaEmpleado()
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
            Call Edicion()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
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
            Txt_Empleado.Text = ""
            Txt_Nombre.Text = ""
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

                    Txt_Empleado.BackColor = TextboxBackColor
                    Txt_Empleado.BackColor = TextboxBackColor


                    ' no dar de alta fotos 

                    Btn_AceptarF.Enabled = False
                    Btn_EliminarF.Enabled = False
                    Btn_NuevoF.Enabled = False

                Case 1, 2


                    If Accion = 1 Then
                        Txt_Empleado.Focus()
                    ElseIf Accion = 2 Then
                        Txt_Empleado.Focus()
                        Txt_Empleado.BackColor = TextboxBackColor
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

    Private Sub CargarFotoEmpleado()
        'miguel pérez 03/septiembre/2012 04:12 p.m.
        'Glb_RutaArchivoFotos
        Try
            Dim Archivo As String = ""
            Dim NoFoto As String = "1"
            Dim Sw_NoEncontro As Boolean = False
            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)

                Archivo = objIO.pub_ArmarNombreFotoEmpleado(GLB_RutaFotoEmpleado, Txt_Empleado.Text)
                If objIO.pub_ExisteArchivo(Archivo) = True Then
                    Sw_NoEncontro = True
                    PBox.Image = New System.Drawing.Bitmap(Archivo)
                    Exit Sub
                Else
                    PBox.Image = Nothing
                End If

                For i As Integer = 0 To 9
                    Archivo = objIO.pub_ArmarNombreFotoEmpleado(GLB_RutaArchivoFotos, Txt_Empleado.Text)
                    If objIO.pub_ExisteArchivo(Archivo) = True Then
                        Sw_NoEncontro = True
                        PBox.Image = New System.Drawing.Bitmap(Archivo)
                        Exit Sub
                    End If
                Next
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub Btn_Sig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Sig.Click
        'miguel pérez 03/Septiembre/2012 04:57 p.m.
        Try
            If Val(Txt_Empleado.Text) > 0 Then
                PBox.Image = Nothing
                Txt_Empleado.Text = Val(Txt_Empleado.Text) + 1
                Call TxtGrid(Txt_Empleado, Txt_Nombre, "E")
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Function TraerFoto(ByVal NoFoto As String) As Boolean
        'miguel pérez 03/Septiembre/2012 04:57 p.m.
        Try
            TraerFoto = False
            Dim Archivo As String = ""
            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)
                Archivo = objIO.pub_ArmarNombreFotoEmpleado(GLB_RutaArchivoFotos, Txt_Empleado.Text)
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

            If Val(Txt_Empleado.Text) > 0 Then
                PBox.Image = Nothing
                Txt_Empleado.Text = Val(Txt_Empleado.Text) - 1
                Call TxtGrid(Txt_Empleado, Txt_Nombre, "E")
            End If


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub





    Private Sub Btn_AceptarF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_AceptarF.Click
        'miguel pérez 04/Septiembre/2012 09:32 a.m.
        Try
            Dim RutaOrigen As String = ""
            Dim RutaDestino As String = ""

            '' BUSCAR LA IMAGEN... SI LA ENCUENTRA PREGUNTAR PARA EDITARLA SINO DARLA DE ALTA CON UN NUMERO MAS 

            If MsgBox("Esta seguro de querer guardar la imagen para el empleado.?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub


            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)
                RutaOrigen = Txt_Ruta.Text
                RutaDestino = ""
                RutaDestino = objIO.pub_ArmarNombreFotoEmpleado(GLB_RutaFotoEmpleado, Txt_Empleado.Text)

                If objIO.pub_ExisteArchivo(RutaDestino) = True Then
                    '' ya existe 
                    If MsgBox("Esta seguro de querer modificar la foto del empleado '" & Txt_Nombre.Text & "?. En caso contrario se registrará como nueva.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.Yes Then
                        ''sobreescribir la que ya existe 
                        objIO.pub_RenombrarArchivo(RutaDestino, objIO.pub_NombreArchivo(objIO.pub_ArmarNombreFotoEmpleado(GLB_RutaArchivoFotos, Txt_Empleado.Text)))
                        objIO.pub_EliminarArchivo(objIO.pub_ArmarNombreFotoEmpleado(GLB_RutaArchivoFotos, Txt_Empleado.Text))
                        'CambiarArchivo(RutaOrigen, RutaDestino)
                        objIO.pub_CopiarArchivo(RutaOrigen, RutaDestino)
                    Else
                        RutaDestino = objIO.pub_ArmarNombreFotoEmpleado(GLB_RutaFotoEmpleado, Txt_Empleado.Text)
                        'CambiarArchivo(RutaOrigen, RutaDestino)
                        objIO.pub_CopiarArchivo(RutaOrigen, RutaDestino)
                    End If
                Else
                    RutaDestino = objIO.pub_ArmarNombreFotoEmpleado(GLB_RutaFotoEmpleado, Txt_Empleado.Text)
                    'CambiarArchivo(RutaOrigen, RutaDestino)
                    objIO.pub_CopiarArchivo(RutaOrigen, RutaDestino)
                End If
                RutaOrigen = Txt_Ruta.Text




                ' objIO.pub_CopiarArchivo(RutaOrigen, RutaDestino)
            End Using

            MsgBox("Archivo correctamente grabado en la ruta '" & RutaDestino & "'", MsgBoxStyle.Information, "Confirmación")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub CambiarArchivo(ByVal RutaOrigen As String, ByVal RutaDestino As String)
        'miguel pérez 03/septiembre/2012 06:17 p.m.
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
        'miguel pérez 03/Septiembre/2012 05:38 p.m.
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

    Private Sub PBox_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PBox.DoubleClick
        'miguel pérez 03/Septiembre/2012 07:01 p.m.
        Try
            Dim myForm As New frmConsultaImagenEmpleado
            myForm.Txt_Empleado.Text = Txt_Empleado.Text
            myForm.Txt_Nombre.Text = Txt_Nombre.Text
            myForm.ShowDialog()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_EliminarF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_EliminarF.Click
        Try
            If MsgBox("Esta seguro de querer eliminar la imagen.?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.Yes Then
                Using objIO As New BCL.BCLio(Glb_ConStringCipSis)
                    PBox.Image = Nothing
                    objIO.pub_EliminarArchivo(objIO.pub_ArmarNombreFotoEmpleado(GLB_RutaFotoEmpleado, Txt_Empleado.Text))
                End Using
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Limpiar.Click

        Me.Txt_Nombre.Text = ""

        Me.Txt_Empleado.Text = ""

        PBox.Image = Nothing
        Txt_Empleado.Focus()
    End Sub

    Private Sub Txt_Empleado_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Empleado.LostFocus
        Call TraerEmpleado()
        Call CargarFotoEmpleado()
    End Sub

    Private Sub Txt_Empleado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Empleado.TextChanged

    End Sub
End Class
