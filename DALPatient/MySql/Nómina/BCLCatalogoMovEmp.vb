﻿Public Class BCLCatalogoMovEmp
    ''Tony Garcia 04/Sept/2012 5:30 p.m.
    Implements IDisposable
    Private objDALCatalogoMovEmp As DAL.DALCatalogoMovEmp
    Private disposedValue As Boolean = False        ' To detect redundant calls

#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALCatalogoMovEmp = New DAL.DALCatalogoMovEmp(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALCatalogoMovEmp.Dispose()
            objDALCatalogoMovEmp = Nothing
            ' TODO: free shared unmanaged resources
        End If
        Me.disposedValue = True
    End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
#Region " Public Section Functions "

    Public Function usp_Captura_MovEmp(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'Tony Garcia - 08/Septiembre/2012 - 09:42 a.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALCatalogoMovEmp.usp_Captura_MovEmp(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function Inserta_MovEmp() As DataSet
        'mreyes 18/Junio/2012 05:50 p.m.
        Try
            'Instantiate a new DataSet object
            Inserta_MovEmp = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_MovEmp.Tables.Add("movemp")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn

            objDataColumn = New DataColumn("idempleado", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("tipo", Type.GetType("System.String"))
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fecha", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("estatus", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("baja", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idmotivo", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("comentario", Type.GetType("System.String"))
            objDataColumn.MaxLength = 250
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("usuario", Type.GetType("System.String"))
            objDataColumn.MaxLength = 8
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fum", Type.GetType("System.DateTime"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("usumodif", Type.GetType("System.String"))
            objDataColumn.MaxLength = 8
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fummodif", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)



        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerEmpleado(ByVal IdEmpleado As Integer) As DataSet
        'mreyes 20/Junio/2012 12:32 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerEmpleado = objDALCatalogoMovEmp.usp_TraerEmpleado(IdEmpleado)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerMotivoBaja() As DataSet
        'Tony Garcia - 05/Septiembre/2012 - 12:42 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerMotivoBaja = objDALCatalogoMovEmp.usp_TraerMotivoBaja()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerMovEmp(ByVal IdEmpleado As Integer) As DataSet
        'Tony Garcia - 10/Septiembre/2012 - 12:10 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerMovEmp = objDALCatalogoMovEmp.usp_TraerMovEmp(IdEmpleado)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalMovEmp(ByVal IdMovEmp As Integer, ByVal Clave As String, ByVal IdEmpleado As Integer, _
                                   ByVal Tipo As String, ByVal Fecha As Date, ByVal Sucursal As String, ByVal IdPuesto As Integer) As DataSet
        'miguel perez, tony garcia 31/Agosto/2012 01:42 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALCatalogoMovEmp.usp_PpalMovEmp(IdMovEmp, Clave, IdEmpleado, Tipo, Fecha, Sucursal, IdPuesto)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
