Imports System.IO

Public Class frmCatalogoFirmasDistrib

    'Tony Garcia - 23/03/2013 - 09:30 a.m.

    Dim Sql As String
    'Public Accion As Integer  '' 1  = nuevo, 2 = edicion , 3 = eliminar , 4 = consultar 
    Public Sw_Registro As Boolean = False
    Private objDataSet As Data.DataSet
    Dim Costo As Decimal = 0
    Public Sw_PedidoNuevo As Boolean = False
    Dim TotalFirmas As Integer = 1


    Private Sub Txt_Marca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub



    Private Function ValidarEdicion() As Boolean
        'mreyes 03/Marzo/2012 11:23 a.m. 
        ValidarEdicion = False
        Try


            ValidarEdicion = True
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Function

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click

        Try

            If MsgBox("Desea actualizar la firma del distribuidor " + Txt_IdDistrib.Text + " ?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                ActualizaFirma()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub



    Private Sub ActualizaFirma()
        'Tony Garcia - 23/Marzo/2013 - 11:03 a.m.
        Dim Contador As Integer = 0
        Dim RutaOrigen As String = ""
        Dim RutaDestino As String = ""
        Dim NomFoto As String = ""

        Try

            For i As Integer = 0 To 3

                NomFoto = Txt_IdDistrib.Text + "f" + Contador.ToString + ".JPG"

                Using objIO As New BCL.BCLio(GLB_ConStringCipSis)
                    RutaOrigen = "\\10.10.1.1\sistema$\CV\Firmas\" + NomFoto
                    RutaDestino = ""
                    RutaDestino = objIO.pub_ArmarNombreFirmaDistribuidor("C:\LOCAL\Datos\Firmas", NomFoto)


                    If objIO.pub_ExisteArchivo(RutaOrigen) = True Then
                        If objIO.pub_ExisteArchivo(RutaDestino) = True Then
                            'CambiarArchivo(RutaOrigen, RutaDestino)
                            objIO.pub_CopiarArchivo(RutaOrigen, RutaDestino)
                        Else
                            'CambiarArchivo(RutaOrigen, RutaDestino)
                            objIO.pub_CopiarArchivo(RutaOrigen, RutaDestino)
                        End If
                    End If



                    'RutaOrigen = Txt_Ruta.Text
                    Contador += 1


                    ' objIO.pub_CopiarArchivo(RutaOrigen, RutaDestino)
                End Using

            Next

            MsgBox("Las firmas del Distribuidor '" + Txt_IdDistrib.Text + " se actualizaron correctamente.", MsgBoxStyle.Information, "Confirmación")

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

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

    Private Sub frmCatalogoEstilos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then
                'If Accion = 1 Or Accion = 2 Then
                If MessageBox.Show("Desea salir de la aplicación ?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                    Me.Dispose()
                    Me.Close()

                End If
                'Else
                '    Me.Dispose()
                '    Me.Close()
                'End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmCatalogoEstilos_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave

    End Sub


    Private Sub frmCatalogoEstilos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try


            Call GenerarToolTip()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Aceptar, "Aceptar la acción requerida por el usuario")
            ToolTip.SetToolTip(Btn_Cancelar, "Cancelar cualquier acción requerida por el usuario")


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub LimpiarDatos()
        Try

            Txt_IdDistrib.Text = ""
            Txt_DescripDistrib.Text = ""
            Txt_NoFoto.Text = ""
            PBox.Image = SIRCO.My.Resources.Resources.ZAPATERIA_TORREON

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub


    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Try


            If MessageBox.Show("Desea salir de la aplicación?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                'Me.Dispose()
                Me.Close()
            End If


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub Pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub Txt_IdDistrib_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_IdDistrib.KeyPress
        Call pub_SoloNumeros(sender, e)
    End Sub

    Private Sub Txt_IdDistrib_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_IdDistrib.LostFocus

        If Txt_IdDistrib.Text.Trim.Length < 6 Then
            Txt_IdDistrib.Text = pub_RellenarIzquierda(Txt_IdDistrib.Text.Trim, 6)
        End If

        Call CargarFotoFirma()

        Using objDistribuidores As New BCL.BCLValesPorNegocio(GLB_ConStringCrvSis)
            Try

                objDataSet = objDistribuidores.usp_TraerNombreDistribuidor(Txt_IdDistrib.Text)

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_DescripDistrib.Text = objDataSet.Tables(0).Rows(0).Item("nombre")
                    TotalFirmas = objDataSet.Tables(0).Rows(0).Item("firmas")

                Else
                    Txt_IdDistrib.Text = ""
                    Txt_DescripDistrib.Text = ""
                    TotalFirmas = 1
                End If


            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub CargarFotoFirma()
        'Tony Garcia -  23/Marzo/2013 12:12 p.m.
        'Glb_RutaArchivoFotos
        If Txt_NoFoto.Text.Length = 0 Then Txt_NoFoto.Text = "1"
        Dim NomFoto As String = Txt_NoFoto.Text
        Try
            Dim Archivo As String = ""
            Dim NoFoto As String = Txt_NoFoto.Text
            Dim Sw_NoEncontro As Boolean = False
            NomFoto = Txt_IdDistrib.Text + "f" + NoFoto + ".JPG"
            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)

                Archivo = objIO.pub_ArmarNombreFirmaDistribuidor("\\10.10.1.1\sistema\CV\Firmas", NomFoto)
                Txt_NoFoto.Text = NoFoto
                If objIO.pub_ExisteArchivo(Archivo) = True Then
                    Sw_NoEncontro = True
                    PBox.Image = New System.Drawing.Bitmap(Archivo)
                    Exit Sub
                Else
                    PBox.Image = SIRCO.My.Resources.Resources.ZAPATERIA_TORREON
                End If

                For i As Integer = 0 To 3
                    Txt_NoFoto.Text = i
                    NomFoto = Txt_IdDistrib.Text + "f" + NoFoto + ".JPG"
                    Archivo = objIO.pub_ArmarNombreFirmaDistribuidor("\\10.10.1.1\sistema\CV\Firmas", NomFoto)
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

    Private Sub Btn_Limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Limpiar.Click
        Call LimpiarDatos()
    End Sub

    Private Sub Btn_Ant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ant.Click
        Try
            If TotalFirmas > 1 And Val(Txt_NoFoto.Text) <= TotalFirmas And Val(Txt_NoFoto.Text) <> 1 Then
                Txt_NoFoto.Text = Val(Txt_NoFoto.Text) - 1
                CargarFotoFirma()
                Exit Sub
            Else
                Txt_NoFoto.Text = "1"

            End If

            If Val(Txt_IdDistrib.Text) > 0 Then
                Txt_IdDistrib.Text = Val(Txt_IdDistrib.Text) - 1
                Call Txt_IdDistrib_LostFocus(sender, e)
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Sig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Sig.Click
        Try

            If TotalFirmas > 1 And Val(Txt_NoFoto.Text) < TotalFirmas Then
                Txt_NoFoto.Text = Val(Txt_NoFoto.Text) + 1
                CargarFotoFirma()
                Exit Sub
            Else
                Txt_NoFoto.Text = "1"
            End If


            If Val(Txt_IdDistrib.Text) > 0 Then
                Txt_IdDistrib.Text = Val(Txt_IdDistrib.Text) + 1
                Call Txt_IdDistrib_LostFocus(sender, e)
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
            myForm.Txt_Estilon.Text = Txt_DescripDistrib.Text
            myForm.Txt_Marca.Text = Txt_IdDistrib.Text
            myForm.Txt_NoFoto.Text = Txt_NoFoto.Text
            myForm.Sw_Firma = True
            myForm.ShowDialog()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_IdDistrib_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_IdDistrib.TextChanged

    End Sub
End Class
