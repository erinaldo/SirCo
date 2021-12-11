Module ModGral


    'mreyes 10/Febrero/2012 11:17 a.m.
    'Funciones generales de todo
    Public GLB_Ip
    Public GLB_Sw_Plaza As Boolean
    Public G_ConString As String 'Global Variable For Connection String
    'Variables de Conexión
    Public GLB_ConStringMicrosip As String 'Global Variable For Connection String
    Public GLB_ConStringCipSis As String 'Global Variable For Connection String
    Public GLB_ConStringSirCoSQL As String 'Global Variable For Connection String
    Public GLB_ConStringDwhSQL As String 'Global Variable For Connection String
    Public GLB_ConStringNominaSQL As String 'Global Variable For Connection String
    Public GLB_ConStringCreditoSQL As String 'Global Variable For Connection String

    Public GLB_ConStringSirCoAppSQL As String 'GLOBAL VARIABLE PARA APP
    Public GLB_ConStringSirCoVentaEnLineaSQL As String 'GLOBAL VARIABLE PARA APP


    Public GLB_ConStringSirCoPVSQL As String 'GLOBAL VARIABLE PARA PV
    Public GLB_ConStringSirCoTEMPSQL As String 'GLOBAL VARIABLE PARA TEMPORAL

    Public GLB_ConStringSircoControlSQL As String 'GLOBAL VARIABLE PARA APP
    Public GLB_ConStringPerSis As String 'Global Variable For Connection String
    Public GLB_ConStringNomSis As String 'Global Variable For Connection String
    Public GLB_ConStringDWH As String 'Global Variable For Connection String
    Public GLB_ConStringCrvSis As String '= "Driver={MySQL ODBC 5.1 Driver};server=localhost;uid=root;pwd=prueba;database=crvsis;port=3306;no_bigint=1" 'Global Variable For Connection String
    Public GLB_ConStringCredito As String '= "Driver={MySQL ODBC 5.1 Driver};server=localhost;uid=root;pwd=prueba;database=credito;port=3306;no_bigint=1"
    Public GLB_TraspasosRecibidos As String
    Public GLB_ConStringCrvSis2 As String '= "Driver={MySQL ODBC 5.1 Driver};server=localhost;uid=root;pwd=prueba;database=crvsis2;port=3306;no_bigint=1" 'Global de Credito
    Public GLB_ConStringCrvSisLocal As String '= "Driver={MySQL ODBC 5.1 Driver};server=localhost;uid=root;pwd=prueba;database=crvsis;port=3306;no_bigint=1" 'Global de Credito
    Public GLB_ConStringNomSisLocal As String '= "Driver={MySQL ODBC 5.1 Driver};server=localhost;uid=root;pwd=prueba;database=carganomina;port=3306;no_bigint=1"
    Public GLB_RutaTxtOzono As String = ""
    Public GLB_RutaTxtCoqueta As String = ""
    Public GLB_TiempoHD As Integer
    Public GLB_DireInv As String = ""
    Public GLB_OPedido As String = ""


    Public GLB_ConStringNomSisSQL As String
    Public GLB_ImpresoraPredeterminada As String = ""
    Public GLB_ImpresoraTicket As String = ""


    'CONEXIONES HISTORICAS
    Public GLB_ConStringCipsisHis As String = ""

    Public GLB_RutaContratoAdicionalProv As String = ""

    Public Glb_RutaFotosDocs As String = ""

    Public GLB_Emergente As Boolean = False
    Public GLB_OpcionEme As Integer = 0
    Public G_TempVariableString As String
    Public G_Date As Date
    Public GLB_Usuario As String
    Public GLB_NomUsuario As String = ""

    Public GLB_Vendedor As Integer = 0
    Public GLB_NomVendedor As String = ""

    Public GLB_ImpresoraMovs As String = ""
    Public GLB_ImpresoraRELACION As String = ""
    Public GLB_Sucursal As String = ""
    Public GLB_CveSucursal As String = ""
    Public GLB_Programa As String = ""
    Public GLB_Proceso As String = ""
    Public GLB_Idempleado As Integer = 0
    Public GLB_PermisoProceso As Boolean = False
    Public GLB_AccesoEmpleado As Boolean = False
    Public GLB_Sw_Costos As Boolean = True
    Public GLB_Sw_Venta As Boolean = True
   
    Public GLB_RefrescarPedido As Boolean = False
    Public GLB_FormConsulta As Boolean = False
    Public GLB_FormPedidoBodega As Boolean = False
    Public GLB_FormPuntoVenta As Boolean = False

    '' Variables Globales de Parametros
    Public GLB_RutaArchivoDigitalPedidos As String = ""
    ''Public Glb_RutaArchivoFotos As String = "\\10.10.1.1\sistema$\ZT\Fotos"
    Public GLB_RutaArchivoFotos As String = ""
    Public GLB_RutaArchivoFotosLocal As String = ""
    Public GLB_RutaArchivoFotosREC As String = ""
    Public GLB_CorreoCompras As String = ""
    Public GLB_PassCorreoCompras As String = ""

    Public GLB_CorreoResurtidoCompras As String = ""
    Public GLB_PassCorreoResurtidoCompras As String = ""


    Public GLB_CorreoHelpDesk As String = ""
    Public GLB_PassCorreoHelpDesk As String = ""

    Public GLB_CorreoEmpleado As String = ""
    Public GLB_PassCorreoEmpleado As String = ""
    Public GLB_IdDeptoEmpleado As Integer = 0
    Public GLB_IdPuestoEmpleado As Integer = 0

    Public GLB_RutaFotoEmpleado As String = ""
    Public GLB_RutaArchivoFotoFichaRem As String = ""
    Public GLB_CLayout As String = ""
    Public GLB_SmtpClient As String = ""
    Public GLB_Microsip As Boolean
    Public GLB_VariasOC As Boolean
    Public GLB_OcXSuc As Boolean
    Public GLB_ComEmp As Decimal = 0
    Public GLB_ProvDif As String = ""
    Public GLB_PedidoExcel As Boolean = False

    Public GLB_CatEsiloCancelado As Boolean = False
    Public GLB_FechaHoy As Date = "1900-01-01"
    Dim StrCnn = My.Settings.ConnectionStringBonos
    Dim StrSQL As String
    Private DataSet1 As DataSet
    Public TextboxBackColor As Color = SystemColors.Window

    'Impresión de etiqeutas.


    Public Glb_ModeloEtiqueta As String = ""
    Public Glb_CorridaEtiqueta As String = ""
    Public Glb_SerieEtiqueta As String = ""
    Public Glb_DescripCEtiqueta As String = ""
    Public Glb_MedidaEtiqueta As String = ""
    Public Glb_MarcaEtiqueta As String = ""

    '' Credito
    Public Glb_TipoCambio As Double = 0
    Public Glb_porcComision As Integer = 0
    Public Glb_FTP As String = ""

    Public Glb_Mensaje As String = ""
    Public Glb_Mensaje1 As String = ""
    Public Glb_Mensaje2 As String = ""
    Public Glb_Mensaje3 As String = ""
    Public Glb_Mensaje4 As String = ""
    Public Glb_Mensaje5 As String = ""

    Public Sub pub_NumDecimales(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'GarJur 03/Septiembre/2012

        If Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 46 Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Public Function pub_RellenarIzquierda(ByVal Cadena As String, ByVal iLimit As Integer) As String
        'mreyes 16/Febrero/2012 11:06 a.m.
        Dim iLength As Integer = Cadena.ToString.Length
        Dim s As String = ""

        Try

            If iLength < iLimit Then
                For i As Integer = 1 To iLimit - iLength
                    s += "0"
                Next
                s += Cadena.ToString
            Else
                s = Cadena
            End If

            Return s
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
            Return False
        End Try
            End Function

    Public Function pub_RellenarEspaciosIzquierda(ByVal Cadena As String, ByVal iLimit As Integer) As String
        'mreyes 07/Julio/2012 11:27 a.m.
        Dim iLength As Integer = Cadena.ToString.Length
        Dim s As String = ""

        Try

            If iLength < iLimit Then
                For i As Integer = 1 To iLimit - iLength
                    s += " "
                Next
                s += Cadena.ToString
            Else
                s = Cadena
            End If

            Return s
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
            Return False
        End Try
    End Function

    Public Function pub_RellenarEspaciosDerecha(ByVal Cadena As String, ByVal iLimit As Integer) As String
        'mreyes 10/Julio/2012 04:27 p.m.
        Dim iLength As Integer = Cadena.ToString.Length
        Dim s As String = ""

        Try

            If iLength < iLimit Then
                For i As Integer = 1 To iLimit - iLength
                    s += " "
                Next
                s = Cadena.ToString + s
            Else
                s = Cadena
            End If

            Return s
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
            Return False
        End Try
    End Function

    Public Function pub_CalcularCostoPedido(ByVal PComp As Double, ByVal DescuentoPP As Double, ByVal Dscto01 As Double, ByVal Dscto02 As Double, ByVal Dscto03 As Double, ByVal Dscto04 As Double, ByVal Dscto05 As Double, ByVal Iva As Double) As Double
        'mreyes 13/Febrero/2012 04:59 p.m.
        Try
            Dim Importe As Double = 0
            pub_CalcularCostoPedido = 0
            If Iva <> 0 Then
                Importe = PComp * (1 + (Iva / 100)) * (1 - (DescuentoPP / 100))
                ' Importe = PComp * (1 + (Iva / 100))
                ' Importe = PComp - (PComp * (1 - (DescuentoPP / 100)))
                If Dscto01 <> 0 Then
                    ' Importe = (Importe * (1 + (Iva / 100)) * (1 - (Dscto01 / 100)))
                    Importe = (Importe * (1 - (Dscto01 / 100)))
                End If
                If Dscto02 <> 0 Then
                    Importe = (Importe * (1 - (Dscto02 / 100)))
                End If
                If Dscto03 <> 0 Then
                    Importe = (Importe * (1 - (Dscto03 / 100)))
                End If
                If Dscto04 <> 0 Then
                    Importe = (Importe * (1 - (Dscto04 / 100)))
                End If
                If Dscto05 <> 0 Then
                    Importe = (Importe * (1 - (Dscto05 / 100)))
                End If
            Else
                Importe = PComp * (1 - (DescuentoPP / 100))
            End If

            'If Dscto01 > 0 Then
            '    Importe = PComp * (1 - (DescuentoPP / 100))
            '    Importe = Importe * (1 - (Dscto01 / 100))
            'End If

            pub_CalcularCostoPedido = Importe
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
            Return False
        End Try

    End Function
    Public Function pub_CalcularPrecioVentaMargen(ByVal Importe As Double) As Double
        'mreyes 03/Junio/2015   05:20 p.m.
        Try

            Dim Ult As Integer = 0

            Importe = CInt(Importe)

            Ult = Mid(CStr(Importe), Len(CStr(Importe)), 1)

            If Ult <> 9 Then
                If 9 - Ult > 6 Then
                    Importe = Importe - (Ult + 1)
                Else
                    Importe = Importe + (9 - Ult)
                End If
            End If

            pub_CalcularPrecioVentaMargen = Importe
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
            Return False
        End Try

    End Function

    Public Function pub_CalcularPrecioVenta(ByVal PComp As Double, ByVal Factor As Double) As Double
        'mreyes 12/Marzo/2012 12:09 p.m.
        Try
            Dim Importe As Integer = 0
            Dim Ult As Integer = 0

            Importe = (Val(PComp)) * (1 + Val(Factor) / 100)

            Ult = Mid(CStr(Importe), Len(CStr(Importe)), 1)

            If Ult <> 9 Then
                If 9 - Ult > 6 Then
                    Importe = Importe - (Ult + 1)
                Else
                    Importe = Importe + (9 - Ult)
                End If
            End If

            pub_CalcularPrecioVenta = Importe
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
            Return False
        End Try

    End Function

    Public Function pub_CalcularMargenPedido(ByVal Precio As Double, ByVal Costo As Double) As Double
        'mreyes 13/Febrero/2012 04:59 p.m.
        Try
            pub_CalcularMargenPedido = 0

            pub_CalcularMargenPedido = 100 * ((Precio - Costo) / Precio)
            If Precio = 0 Then pub_CalcularMargenPedido = 0
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
            Return False
        End Try

    End Function
    Public Sub pub_SoloLetras(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'mreyes 10/Noviembre/2016   01:24 p.m.

        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Public Sub pub_SoloNumeros(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'mreyes 21/Febrero/2012 11:32 a.m.

        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

 
    Public Function pub_FechaVence(ByVal FechaFactura As Date, ByVal Dias As Integer) As Date
        'mreyes 22/Mayo/2012 04:59 p.m.
        Try
            Dim FechaVence As Date
            FechaVence = DateAdd(DateInterval.Day, Dias, FechaFactura)
            Return FechaVence

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Calcular Fecha de Vencimiento")
            Return "1900/01/01"
        End Try

    End Function

    Public Function pub_TraerEstatus(ByVal Estatus As String) As String
        'mreyes 13/Junio/2012 10:58 a.m.
        Try
            pub_TraerEstatus = ""

            If Estatus = "C" Then
                pub_TraerEstatus = "CANCELADO"
            ElseIf Estatus = "V" Then
                pub_TraerEstatus = "VIGENTE"
            ElseIf Estatus = "S" Then
                pub_TraerEstatus = "SUSPENDIDO"
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
            Return False
        End Try

    End Function

    Public Function pub_TraerDiaDescanso(ByVal Descanso As String) As Integer
        'mreyes 26/Julio/2012 p.m.
        Try
            Dim DiaDescanso As Integer = 7


            If Descanso = "LUNES" Then DiaDescanso = 1
            If Descanso = "MARTES" Then DiaDescanso = 2
            If Descanso = "MIÉRCOLES" Then DiaDescanso = 3
            If Descanso = "JUEVES" Then DiaDescanso = 4
            If Descanso = "VIERNES" Then DiaDescanso = 5
            If Descanso = "SÁBADO" Then DiaDescanso = 6
            If Descanso = "DOMINGO" Then DiaDescanso = 7


            pub_TraerDiaDescanso = DiaDescanso

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
            Return False
        End Try

    End Function

    Public Function pub_TraerMes(ByVal Mes As String) As Integer
        'mreyes 26/Julio/2012 p.m.
        Try
            Dim NumMes As Integer = 7

            If Mes = "ENERO" Then NumMes = 1
            If Mes = "FEBRERO" Then NumMes = 2
            If Mes = "MARZO" Then NumMes = 3
            If Mes = "ABRIL" Then NumMes = 4
            If Mes = "MAYO" Then NumMes = 5
            If Mes = "JUNIO" Then NumMes = 6
            If Mes = "JULIO" Then NumMes = 7
            If Mes = "AGOSTO" Then NumMes = 8
            If Mes = "SEPTIEMBRE" Then NumMes = 9
            If Mes = "OCTUBRE" Then NumMes = 10
            If Mes = "NOVIEMBRE" Then NumMes = 11
            If Mes = "DICIEMBRE" Then NumMes = 12

            pub_TraerMes = NumMes

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
            Return False
        End Try

    End Function


    Public Function pub_TraerDiaLargoDescanso(ByVal Descanso As long) As String
        'mreyes 23/Agosto/2012 06:09 p.m.
        Try
            Dim DiaDescanso As String = ""


            If Descanso = 1 Then DiaDescanso = "LUNES"
            If Descanso = 2 Then DiaDescanso = "MARTES"
            If Descanso = 3 Then DiaDescanso = "MIÉRCOLES"
            If Descanso = 4 Then DiaDescanso = "JUEVES"
            If Descanso = 5 Then DiaDescanso = "VIERNES"
            If Descanso = 6 Then DiaDescanso = "SÁBADO"
            If Descanso = 7 Then DiaDescanso = "DOMINGO"


            pub_TraerDiaLargoDescanso = DiaDescanso

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
            Return False
        End Try

    End Function
End Module
