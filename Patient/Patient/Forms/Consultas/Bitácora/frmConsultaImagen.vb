Public Class frmConsultaImagen
    Public Sw_Firma As Boolean = False
    Public SW_Ficha As Boolean = False

    Public Anio As String
    Public Mes As String
    Public Prov As String
    Public SW_FichaDeposito As Boolean = False
    Public SW_ContratoAdProv As Boolean = False
    Public Sw_Pbox As Boolean = False

    Private Sub frmConsultaImagen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub
    'mreyes 03/Marzo0/2012 09:51 a.m.

    Private Sub frmConsultaImagen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Sw_Pbox = False Then
            If Sw_Firma = True Then
                CargarFotoFirma()
                Me.Text = "Distribuidor: " & Txt_Marca.Text & "-" & Txt_Estilon.Text
            ElseIf SW_Ficha = True Then
                CargarFotoFicha()
                Me.Text = "Ficha Depósito: " & Txt_Marca.Text
            ElseIf SW_FichaDeposito = True Then
                Me.Text = "Ficha Depósito: " & Txt_Marca.Text
                Exit Sub
            ElseIf SW_ContratoAdProv = True Then
                CargarFotoContratoAdProv()
                Me.Text = "Contrato Adicional Proveedor: " & Txt_Marca.Text
                Exit Sub
            Else
                Call CargarFotoArticulo()
                Me.Text = "Marca: " & Txt_Marca.Text & " EstiloN: " & Txt_Estilon.Text
            End If
        End If
    End Sub
    Private Sub CargarFotoFirma()
        'Tony Garcia -  23/Marzo/2013 12:12 p.m.
        'Glb_RutaArchivoFotos
        Dim NomFoto As String = ""
        Try
            Dim Archivo As String = ""
            Dim NoFoto As String = "1"
            Dim Sw_NoEncontro As Boolean = False
            NomFoto = Txt_Marca.Text + "f" + NoFoto + ".JPG"
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
                    NomFoto = Txt_Marca.Text + "f" + NoFoto + ".JPG"
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
    Private Sub CargarFotoArticulo()
        'mreyes 02/Marzo/2012 04:12 p.m.
        'Glb_RutaArchivoFotos
        Try
            Dim Archivo As String = ""
            Dim NoFoto As String = Txt_NoFoto.Text

            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)
                Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Estilon.Text, NoFoto)
                If objIO.pub_ExisteArchivo(Archivo) = True Then
                    PBox.Image = New System.Drawing.Bitmap(Archivo)
                    Exit Sub
                End If

                For i As Integer = 0 To 9
                    Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Estilon.Text, i)
                    If objIO.pub_ExisteArchivo(Archivo) = True Then
                        PBox.Image = New System.Drawing.Bitmap(Archivo)
                        Exit Sub
                    End If
                Next

            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub CargarFotoFicha()
        'Tony Garcia -  27/Junio/2013 10:12 a.m.
        Try
            Dim Archivo As String = ""
            'Dim NoFoto As String = Txt_NoFoto.Text

            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)
                Archivo = GLB_RutaArchivoFotoFichaRem & "\" & Anio & "\" & Mes & "\" & Prov & "\" & Txt_Marca.Text & ".jpg"
                If objIO.pub_ExisteArchivo(Archivo) = True Then
                    PBox.Image = New System.Drawing.Bitmap(Archivo)
                    Exit Sub
                End If

            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub CargarFotoContratoAdProv()
        'Tony Garcia -  07/FEb/2014 04:12 p.m.
        Try
            Dim Archivo As String = ""
            'Dim NoFoto As String = Txt_NoFoto.Text

            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)
                Archivo = GLB_RutaContratoAdicionalProv & "\" & Txt_Marca.Text & ".jpg"
                If objIO.pub_ExisteArchivo(Archivo) = True Then
                    PBox.Image = New System.Drawing.Bitmap(Archivo)
                    Exit Sub
                End If

            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub PBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBox.Click

    End Sub
End Class