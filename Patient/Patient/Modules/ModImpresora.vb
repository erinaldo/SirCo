Imports System.Drawing.Printing

Module ModImpresora

    Public Function usp_CargarPrinter() As String
        'mreyes 02/Junio/2014   04:59 p.m.

        Dim instance As New Printing.PrinterSettings

        Dim impresosaPredt As String = instance.PrinterName

        usp_CargarPrinter = impresosaPredt

    End Function

End Module
