Imports System.Net
Public Class frmMostrarIP

    'mreyes 07/Junio/2016    12:30 p.m.

    Public FolioB As Integer = 0


    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        ' si existe el foliio
        Dim LocalHostName As String = Dns.GetHostName
        Dim LocalIP As IPHostEntry = Dns.GetHostEntry(LocalHostName)
        Txt_NoBulto.Text = LocalIP.AddressList(6).ToString

    End Sub



    'Private Function dameIP() As String

    '    Dim ip As Net.Dns
    '    Dim nombrePC As String
    '    Dim entradasIP As Net.IPHostEntry

    '    nombrePC = Dns.GetHostName

    '    entradasIP = Dns.GetHostByName(nombrePC)

    '    Dim direccion_Ip As String = entradasIP.AddressList(0).ToString

    '    Return direccion_Ip

    'End Function

End Class