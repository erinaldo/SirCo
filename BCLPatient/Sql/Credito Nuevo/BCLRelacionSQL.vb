﻿Public Class BCLRelacionSQL

    'vgallegos 03/Febrero/2018

    Implements IDisposable
    Private objDALRelacion As DAL.DALRelacionSQL

    Private disposedValue As Boolean = False ' Para detectar llamadas redundantes
#Region "IDisposable Support"

    Public Sub New(ByVal Constring As String)
9:      objDALRelacion = New DAL.DALRelacionSQL(Constring)
    End Sub


    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: elimine el estado administrado (objetos administrados).
            End If

            ' TODO: libere los recursos no administrados (objetos no administrados) y reemplace Finalize() a continuación.
            ' TODO: configure los campos grandes en nulos.
        End If
        disposedValue = True
    End Sub

    ' TODO: reemplace Finalize() solo si el anterior Dispose(disposing As Boolean) tiene código para liberar recursos no administrados.
    'Protected Overrides Sub Finalize()
    '    ' No cambie este código. Coloque el código de limpieza en el anterior Dispose(disposing As Boolean).
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' Visual Basic agrega este código para implementar correctamente el patrón descartable.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' No cambie este código. Coloque el código de limpieza en el anterior Dispose(disposing As Boolean).
        Dispose(True)
        ' TODO: quite la marca de comentario de la siguiente línea si Finalize() se ha reemplazado antes.
        ' GC.SuppressFinalize(Me)
    End Sub
#End Region
#Region " Public Section Functions "


    Public Function usp_TraerDistrib(ByVal iddistrib As Integer) As DataSet

        Try
            Return objDALRelacion.usp_TraerDistrib(iddistrib)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try

    End Function


    Public Function usp_TraeridDistrib(ByVal distrib As String) As DataSet

        Try
            Return objDALRelacion.usp_TraeridDistrib(distrib)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try

    End Function

#End Region

End Class
