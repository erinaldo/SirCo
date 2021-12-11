Imports System.Data.Odbc
Imports System.IO
Imports System.Net.Mail
Imports System.Collections

'mreyes 22/Febrero/2012 01:45 p.m.

Public Class Dalio
    Inherits DALOdbc
#Region "Constructor And Destructor"
    Sub New(ByVal ConString As String)
        MyBase.New(ConString)
    End Sub

    Public Shadows Sub Dispose()
        MyBase.Dispose()
    End Sub
#End Region

#Region " Public Role Functions "
    Public Function pub_ArmarNombreFotoDocs(ByVal Ruta As String, ByVal strID As String, ByVal Tipo As Integer, ByVal NoFoto As String) As String

        Try
            Dim Cadena As String = ""
            'prosp
            If Tipo = 1 Then Cadena = "IFE_P"
            If Tipo = 2 Then Cadena = "COMPROBANTE_P"
            If Tipo = 3 Then Cadena = "PREDIAL_P"
            If Tipo = 4 Then Cadena = "INGRESOS_P"
            If Tipo = 11 Then Cadena = "EDOS_CUENTA_P"
            If Tipo = 20 Then Cadena = "FIRMA_P"
            If Tipo = 21 Then Cadena = "FIRMA_PROMOTOR_P"
            If Tipo = 22 Then Cadena = "PAGARE_P"
            If Tipo = 23 Then Cadena = "PAGARE_EN_BLANCO_P"
            If Tipo = 26 Then Cadena = "CATASTRO_P"
            If Tipo = 27 Then Cadena = "FOTO_P"
            If Tipo = 28 Then Cadena = "CASA_P"
            If Tipo = 29 Then Cadena = "CROQUIS_P"
            'distrib
            If Tipo = 5 Then Cadena = "FIRMA"
            'If Tipo = 6 Then Cadena = "FIRMA2_D"
            If Tipo = 12 Then Cadena = "IFE_D"
            If Tipo = 13 Then Cadena = "COMPROBANTE_D"
            If Tipo = 14 Then Cadena = "PREDIAL_D"
            If Tipo = 15 Then Cadena = "EDOS_CUENTA_D"
            If Tipo = 16 Then Cadena = "INGRESOS_D"
            If Tipo = 30 Then Cadena = "PAGARE_D"
            If Tipo = 31 Then Cadena = "FIRMA_PROMOTOR_D"
            If Tipo = 32 Then Cadena = "CATASTRO_D"
            If Tipo = 33 Then Cadena = "FOTO_D"
            If Tipo = 34 Then Cadena = "CASA_D"
            If Tipo = 35 Then Cadena = "CROQUIS_D"

            'aval
            If Tipo = 7 Then Cadena = "IFE_A"
            If Tipo = 8 Then Cadena = "COMPROBANTE_A"
            If Tipo = 9 Then Cadena = "PREDIAL_A"
            If Tipo = 10 Then Cadena = "INGRESOS_A"
            If Tipo = 24 Then Cadena = "PAGARE_A"
            If Tipo = 25 Then Cadena = "PAGARE_EN_BLANCO_A"
            If Tipo = 36 Then Cadena = "CATASTRO_A"
            If Tipo = 37 Then Cadena = "FOTO_A"
            If Tipo = 38 Then Cadena = "CASA_A"
            If Tipo = 39 Then Cadena = "CROQUIS_A"

            'Activos
            If Tipo = 50 Then Cadena = "FACTURA_ACTIVO"
            If Tipo = 51 Then Cadena = "FOTO_ACTIVO"
            pub_ArmarNombreFotoDocs = Ruta & "\" & Replace(Cadena, " ", "_") & strID & "-" & NoFoto & ".jpg"

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function pub_CrearDirectorioChequesLiquidacion(ByVal Ruta As String, ByVal Anio As String, ByVal Mes As String, ByVal Prov As String, ByVal Liquidacion As String) As Boolean
        'Tony Garcia - 28/Junio/2013 11:40 a.m.
        Try
            Dim RutaArchivo As String
            Dim Cadena As String = ""
            pub_CrearDirectorioChequesLiquidacion = False

            Ruta = Ruta & "\" & Cadena

            RutaArchivo = Ruta & "\" & Anio
            If Not Directory.Exists(RutaArchivo) Then
                Directory.CreateDirectory(RutaArchivo)
            End If

            RutaArchivo = Ruta & "\" & Anio & "\" & Mes
            If Not Directory.Exists(RutaArchivo) Then
                Directory.CreateDirectory(RutaArchivo)
            End If

            RutaArchivo = Ruta & "\" & Anio & "\" & Mes & "\" & Prov
            If Not Directory.Exists(RutaArchivo) Then
                Directory.CreateDirectory(RutaArchivo)
            End If

            RutaArchivo = Ruta & "\" & Anio & "\" & Mes & "\" & Prov & "\" & Liquidacion
            If Not Directory.Exists(RutaArchivo) Then
                Directory.CreateDirectory(RutaArchivo)
            End If

            pub_CrearDirectorioChequesLiquidacion = True
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function pub_ArmarNombreFotoFicha(ByVal Ruta As String, ByVal strReferenc As String) As String
        'Tony Garcia - 26/Junio/2013 07:00 p.m.
        Try
            pub_ArmarNombreFotoFicha = Ruta & "\" & strReferenc & ".jpg"

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function pub_ArmarNombreFirmaDistribuidor(ByVal Ruta As String, ByVal strIDDsitrib As String) As String
        'Tony Garcia - 23/Marzo/2012 11:00 a.m.
        Try
            pub_ArmarNombreFirmaDistribuidor = Ruta & "\" & strIDDsitrib

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function pub_EnviarCorreo(ByVal SmtpClient As String, ByVal CorreoCompras As String, ByVal PassCorreoCompras As String, ByVal Correos As String, ByVal Asunto As String, ByVal Mensaje As String, ByVal Archivo As String) As Boolean
        'mreyes 25/Febrero/2012 02:09 p.m.
        Dim smtpCliente As New System.Net.Mail.SmtpClient(SmtpClient, 587)
        'smtp.gmail.com
        'smtpCliente.Host = "smtp.gmail.com"
        ' smtpCliente.Host = "smtp.live.com"
        smtpCliente.Host = "smtp.1and1.mx"
        smtpCliente.Port = 587  '465   '587
        'CorreoCompras = "afavela@zapateriastorreon.com"
        'Correos = "mreyes.tor@hotmail.com"
        'PassCorreoCompras = "ZT_Sirco33"
        smtpCliente.EnableSsl = True
        ' Correos = "giaco.felix@gmail.com, mreyes.tor@hotmail.com"
        'CorreoCompras = "marthar.zaptorreon@gmail.com"
        Dim ELCorreo As New System.Net.Mail.MailMessage(CorreoCompras, Correos, Asunto, Mensaje)
        'Dim ELCorreo As New System.Net.Mail.MailMessage("marthar@zapateriastorreon.com", "mreyes.tor@hotmail.com,majo1979@live.com.mx", asunto, mensaje)
        smtpCliente.Credentials = New System.Net.NetworkCredential(CorreoCompras, PassCorreoCompras)
        'Dim att As New System.Net.Mail.Attachment("c:\crystalExport.pdf")
        If Archivo.Length > 0 Then
            Dim att As New System.Net.Mail.Attachment(Archivo)
            ELCorreo.Attachments.Add(att)
        End If
        smtpCliente.Send(ELCorreo)


    End Function

    Public Function pub_DirectorioExiste(ByVal Ruta As String) As Boolean
        'mreyes 08/Marzo/2012 12:16 p.m.
        Try
            pub_DirectorioExiste = False
            If Directory.Exists(Ruta) Then
                pub_DirectorioExiste = True
            End If

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function pub_CrearDirectorio(ByVal Ruta As String) As Boolean
        'mreyes 29/Septiembre/2014  11:09 a.m.

        Try
            Dim Sw_DirectorioExiste As Boolean = False

            If Directory.Exists(Ruta) Then
                Sw_DirectorioExiste = True
            Else

                Directory.CreateDirectory(Ruta)


            End If
            Sw_DirectorioExiste = True
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try



       

    End Function
    Public Function pub_CrearDirectorioMarca(ByVal Ruta As String, ByVal ResurtSN As String, ByVal Marca As String, ByVal Anio As String, ByVal Mes As String, ByVal Tipo As String) As Boolean
        'mreyes 22/Febrero/2012 01:36 p.m.
        Try
            Dim RutaArchivo As String
            Dim Cadena As String = ""
            pub_CrearDirectorioMarca = False

            If ResurtSN = "N" Then
                Cadena = "Nuevos"
            Else
                cadena = "Resurtido"
            End If

            Ruta = Ruta & "\" & Cadena

            RutaArchivo = Ruta & "\" & Marca
            If Not Directory.Exists(RutaArchivo) Then
                Directory.CreateDirectory(RutaArchivo)
            End If

            RutaArchivo = Ruta & "\" & Marca & "\" & Anio
            If Not Directory.Exists(RutaArchivo) Then
                Directory.CreateDirectory(RutaArchivo)
            End If

            RutaArchivo = Ruta & "\" & Marca & "\" & Anio & "\" & Mes
            If Not Directory.Exists(RutaArchivo) Then
                Directory.CreateDirectory(RutaArchivo)
            End If

            RutaArchivo = Ruta & "\" & Marca & "\" & Anio & "\" & Mes & "\" & Tipo
            If Not Directory.Exists(RutaArchivo) Then
                Directory.CreateDirectory(RutaArchivo)
            End If

            pub_CrearDirectorioMarca = True
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function pub_CrearDirectorioRemisionProv(ByVal Ruta As String, ByVal Anio As String, ByVal Mes As String, ByVal Prov As String) As Boolean
        'Tony Garcia - 28/Junio/2013 11:40 a.m.
        Try
            Dim RutaArchivo As String
            Dim Cadena As String = ""
            pub_CrearDirectorioRemisionProv = False

            Ruta = Ruta & "\" & Cadena

            RutaArchivo = Ruta & "\" & Anio
            If Not Directory.Exists(RutaArchivo) Then
                Directory.CreateDirectory(RutaArchivo)
            End If

            RutaArchivo = Ruta & "\" & Anio & "\" & Mes
            If Not Directory.Exists(RutaArchivo) Then
                Directory.CreateDirectory(RutaArchivo)
            End If

            RutaArchivo = Ruta & "\" & Anio & "\" & Mes & "\" & Prov
            If Not Directory.Exists(RutaArchivo) Then
                Directory.CreateDirectory(RutaArchivo)
            End If

            pub_CrearDirectorioRemisionProv = True
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function pub_ExisteArchivo(ByVal RutaArchivo As String) As Boolean
        'mreyes 02/Marzo/2012 04:28 p.m.
        Try

            pub_ExisteArchivo = False


            If File.Exists(RutaArchivo) = True Then
                pub_ExisteArchivo = True
            End If

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function pub_ArmarNombreFotoEstilo(ByVal Ruta As String, ByVal Marca As String, ByVal Estilon As String, ByVal NoFoto As String) As String
        'mreyes 02/Marzo/2012 04:34 p.m.
        Try
            If Marca.Length < 3 Then Marca = Marca & " "
            pub_ArmarNombreFotoEstilo = Ruta & "\" & Replace(Marca, " ", "_") & Replace(Estilon, " ", "_") & "F" & NoFoto & ".png"

            If pub_ExisteArchivo(pub_ArmarNombreFotoEstilo) = False Then
                pub_ArmarNombreFotoEstilo = Ruta & "\" & Replace(Marca, " ", "_") & Replace(Estilon, " ", "_") & "F" & NoFoto & ".jpg"
            End If

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function pub_ArmarNombreBulto(ByVal Ruta As String, ByVal idFolio As Integer, ByVal Tipo As Integer) As String
        'mreyes 02/Marzo/2012 04:34 p.m.
        Try
            Dim Cadena As String = ""
            If Tipo = 1 Then Cadena = "IFE"
            If Tipo = 2 Then Cadena = "FACTURA"
            If Tipo = 3 Then Cadena = "TALON"
            pub_ArmarNombreBulto = Ruta & "\" & Replace(Cadena, " ", "_") & idFolio & ".jpg"

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function pub_ArmarNombreFotoEmpleado(ByVal Ruta As String, ByVal strIDEmpleado As String) As String
        'miguel pérez 03/Septiembre/2012 06:34 p.m.
        Try
            pub_ArmarNombreFotoEmpleado = Ruta & "\" & strIDEmpleado & ".jpg"

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function pub_CopiarArchivo(ByVal RutaOrigen As String, ByVal RutaDestino As String) As Boolean
        'mreyes 02/Marzo/2012 05:29 p.m.
        Try
            pub_CopiarArchivo = False
            File.Copy(RutaOrigen, RutaDestino)
            pub_CopiarArchivo = True

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function pub_ExtensionArchivo(ByVal Archivo As String) As String
        'mreyes 03/Marzo/2012 09:33 p.m.
        Try
            pub_ExtensionArchivo = Path.GetExtension(Archivo)

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function pub_NombreArchivo(ByVal Archivo As String) As String
        'mreyes 26/Marzo/2012 05:43 p.m.
        Try
            pub_NombreArchivo = Path.GetFileName(Archivo)

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function pub_EliminarArchivo(ByVal Archivo As String) As Boolean
        'mreyes 03/Marzo/2012 11:55 a.m.
        Try
            pub_EliminarArchivo = False

            File.Delete(Archivo)
            If Not File.Exists(Archivo) Then
                pub_EliminarArchivo = True
            End If

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function pub_RenombrarArchivo(ByVal Archivo As String, ByVal NuevoNombre As String) As Boolean
        'mreyes 26/Marzo/2012 05:38 a.m.
        Try
            pub_RenombrarArchivo = False
            My.Computer.FileSystem.RenameFile(Archivo, NuevoNombre)
            pub_RenombrarArchivo = True

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
