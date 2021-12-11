Imports System.Data.Odbc


Public Class DALEstructura
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

    Public Function usp_TraerEstDivisiones(ByVal Id As Integer, ByVal Clave As String) As DataSet
        'miguel pérez 24/Septiembre/2012 5:30 p.m.
        Try
            usp_TraerEstDivisiones = New DataSet
            MyBase.SQL = "CALL usp_TraerEstDivisiones(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdB", OdbcType.Int, 16, Id)
            MyBase.AddParameter("@ClaveB", OdbcType.Char, 3, Clave)
            MyBase.FillDataSet(usp_TraerEstDivisiones, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaEstDivisiones(ByVal Clave As String, ByVal Descrip As String) As Boolean
        'miguel pérez 27/Septiembre/2012 5:07 p.m.
        Try
            MyBase.SQL = "CALL usp_CapturaEstDivisiones(?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@ClaveB", OdbcType.Char, 3, Clave)
            MyBase.AddParameter("@DescripB", OdbcType.Char, 30, Descrip)

            usp_CapturaEstDivisiones = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerEstDepto(ByVal IdDepto As Integer, ByVal IdDivisiones As Integer, ByVal Clave As String, ByVal Opcion As Integer, ByVal Descripcion As String) As DataSet
        'miguel pérez 24/Septiembre/2012 5:30 p.m.
        Try
            usp_TraerEstDepto = New DataSet
            MyBase.SQL = "CALL usp_TraerEstDepto(?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdDeptoB", OdbcType.Int, 16, IdDepto)
            MyBase.AddParameter("@IdDivisionesB", OdbcType.Int, 16, IdDivisiones)
            MyBase.AddParameter("@ClaveB", OdbcType.Char, 3, Clave)
            MyBase.AddParameter("@Opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@DescripB", OdbcType.Char, 30, Descripcion)
            MyBase.FillDataSet(usp_TraerEstDepto, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaEstDepto(ByVal idDivisiones As Integer, ByVal Clave As String, ByVal Descrip As String) As Boolean
        'miguel pérez 27/Septiembre/2012 5:07 p.m.
        Try
            MyBase.SQL = "CALL usp_CapturaEstDepto(?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@IdDivisionesB", OdbcType.Int, 16, idDivisiones)
            MyBase.AddParameter("@ClaveB", OdbcType.Char, 3, Clave)
            MyBase.AddParameter("@DescripB", OdbcType.Char, 30, Descrip)

            usp_CapturaEstDepto = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarEstDepto(ByVal Id As Integer, ByVal Clave As String, ByVal Descrip As String) As Boolean
        'miguel pérez 12/Septiembre/2012 12:07 p.m.
        Try
            MyBase.SQL = "CALL usp_ActualizarEstDepto(?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@IdB", OdbcType.Int, 16, Id)
            MyBase.AddParameter("@ClaveB", OdbcType.Char, 3, Clave)
            MyBase.AddParameter("@DescripB", OdbcType.Char, 30, Descrip)

            usp_ActualizarEstDepto = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerEstFamilia(ByVal IdFamilia As Integer, ByVal idDepto As Integer, ByVal idDivisiones As Integer, ByVal Clave As String, ByVal Opcion As Integer, ByVal Descrip As String) As DataSet
        'miguel pérez 24/Septiembre/2012 5:30 p.m.
        Try
            usp_TraerEstFamilia = New DataSet
            MyBase.SQL = "CALL usp_TraerEstFamilia(?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdFamiliaB", OdbcType.Int, 16, IdFamilia)
            MyBase.AddParameter("@IdDeptoB", OdbcType.Int, 16, idDepto)
            MyBase.AddParameter("@IdDivisionesB", OdbcType.Int, 16, idDivisiones)
            MyBase.AddParameter("@ClaveB", OdbcType.Char, 3, Clave)
            MyBase.AddParameter("@Opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@DescripB", OdbcType.Char, 30, Descrip)
            MyBase.FillDataSet(usp_TraerEstFamilia, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    
    Public Function usp_CapturaEstFamilia(ByVal idDivisiones As Integer, ByVal idDepto As Integer, ByVal Clave As String, ByVal Descrip As String) As Boolean
        'miguel pérez 27/Septiembre/2012 5:07 p.m.
        Try
            MyBase.SQL = "CALL usp_CapturaEstFamilia(?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@idDivisionesB", OdbcType.Int, 16, idDivisiones)
            MyBase.AddParameter("@idDeptoB", OdbcType.Int, 16, idDepto)
            MyBase.AddParameter("@ClaveB", OdbcType.Char, 3, Clave)
            MyBase.AddParameter("@DescripB", OdbcType.Char, 30, Descrip)

            usp_CapturaEstFamilia = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarEstFamilia(ByVal IdFamilia As Integer, ByVal IdDepto As Integer, ByVal Clave As String, ByVal Descrip As String) As Boolean
        'miguel pérez 12/Septiembre/2012 12:07 p.m.
        Try
            MyBase.SQL = "CALL usp_ActualizarEstFamilia(?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@IdFamiliaB", OdbcType.Int, 16, IdFamilia)
            MyBase.AddParameter("@IdDeptoB", OdbcType.Int, 16, IdDepto)
            MyBase.AddParameter("@ClaveB", OdbcType.Char, 3, Clave)
            MyBase.AddParameter("@DescripB", OdbcType.Char, 30, Descrip)

            usp_ActualizarEstFamilia = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerEstLinea(ByVal IdLinea As Integer, ByVal IdFamilia As Integer, ByVal idDepto As Integer, ByVal idDivisiones As Integer, ByVal Clave As String, ByVal Opcion As Integer, ByVal Descrip As String) As DataSet
        'miguel pérez 24/Septiembre/2012 5:30 p.m.
        Try
            usp_TraerEstLinea = New DataSet
            MyBase.SQL = "CALL usp_TraerEstLinea(?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdLineaB", OdbcType.Int, 16, IdLinea)
            MyBase.AddParameter("@IdFamiliaB", OdbcType.Int, 16, IdFamilia)
            MyBase.AddParameter("@IdDeptoB", OdbcType.Int, 16, idDepto)
            MyBase.AddParameter("@IdDivisionesB", OdbcType.Int, 16, idDivisiones)
            MyBase.AddParameter("@ClaveB", OdbcType.Char, 3, Clave)
            MyBase.AddParameter("@Opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@DescripB", OdbcType.Char, 30, Descrip)
            MyBase.FillDataSet(usp_TraerEstLinea, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaEstLinea(ByVal idDivisiones As Integer, ByVal idDepto As Integer, ByVal idFamilia As Integer, ByVal Clave As String, ByVal Descrip As String) As Boolean
        'miguel pérez 27/Septiembre/2012 5:07 p.m.
        Try
            MyBase.SQL = "CALL usp_CapturaEstLinea(?,?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@idDivisionesB", OdbcType.Int, 16, idDivisiones)
            MyBase.AddParameter("@idDeptoB", OdbcType.Int, 16, idDepto)
            MyBase.AddParameter("@idFamiliaB", OdbcType.Int, 16, idFamilia)
            MyBase.AddParameter("@ClaveB", OdbcType.Char, 3, Clave)
            MyBase.AddParameter("@DescripB", OdbcType.Char, 30, Descrip)

            usp_CapturaEstLinea = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarEstLinea(ByVal IdLinea As Integer, ByVal IdFamilia As Integer, ByVal IdDepto As Integer, ByVal Clave As String, ByVal Descrip As String) As Boolean
        'miguel pérez 12/Septiembre/2012 12:07 p.m.
        Try
            MyBase.SQL = "CALL usp_ActualizarEstLinea(?,?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@IdLineaB", OdbcType.Int, 16, IdLinea)
            MyBase.AddParameter("@IdFamiliaB", OdbcType.Int, 16, IdFamilia)
            MyBase.AddParameter("@IdDeptoB", OdbcType.Int, 16, IdDepto)
            MyBase.AddParameter("@ClaveB", OdbcType.Char, 3, Clave)
            MyBase.AddParameter("@DescripB", OdbcType.Char, 30, Descrip)

            usp_ActualizarEstLinea = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerEstl1(ByVal Idl1 As Integer, ByVal IdLinea As Integer, ByVal IdFamilia As Integer, ByVal idDepto As Integer, ByVal idDivisiones As Integer, ByVal Clave As String, ByVal Opcion As Integer, ByVal Descrip As String) As DataSet
        'miguel pérez 24/Septiembre/2012 5:30 p.m.
        Try
            usp_TraerEstl1 = New DataSet
            MyBase.SQL = "CALL usp_TraerEstl1(?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Idl1B", OdbcType.Int, 16, Idl1)
            MyBase.AddParameter("@IdLineaB", OdbcType.Int, 16, IdLinea)
            MyBase.AddParameter("@IdFamiliaB", OdbcType.Int, 16, IdFamilia)
            MyBase.AddParameter("@IdDeptoB", OdbcType.Int, 16, idDepto)
            MyBase.AddParameter("@IdDivisionesB", OdbcType.Int, 16, idDivisiones)
            MyBase.AddParameter("@ClaveB", OdbcType.Char, 3, Clave)
            MyBase.AddParameter("@Opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@DescripB", OdbcType.Char, 30, Descrip)
            MyBase.FillDataSet(usp_TraerEstl1, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaEstl1(ByVal idDivisiones As Integer, ByVal idDepto As Integer, ByVal idFamilia As Integer, ByVal idLinea As Integer, ByVal Clave As String, ByVal Descrip As String) As Boolean
        'miguel pérez 27/Septiembre/2012 5:07 p.m.
        Try
            MyBase.SQL = "CALL usp_CapturaEstl1(?,?,?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@idDivisionesB", OdbcType.Int, 16, idDivisiones)
            MyBase.AddParameter("@idDeptoB", OdbcType.Int, 16, idDepto)
            MyBase.AddParameter("@idFamiliaB", OdbcType.Int, 16, idFamilia)
            MyBase.AddParameter("@idLineaB", OdbcType.Int, 16, idLinea)
            MyBase.AddParameter("@ClaveB", OdbcType.Char, 3, Clave)
            MyBase.AddParameter("@DescripB", OdbcType.Char, 30, Descrip)

            usp_CapturaEstl1 = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    'Public Function usp_ActualizarEstSubLinea(ByVal IdSubLinea As Integer, ByVal IdLinea As Integer, ByVal IdFamilia As Integer, ByVal IdDepto As Integer, ByVal Clave As String, ByVal Descrip As String) As Boolean
    '    'miguel pérez 12/Septiembre/2012 12:07 p.m.
    '    Try
    '        MyBase.SQL = "CALL usp_ActualizarEstSubLinea(?,?,?,?,?,?)"
    '        'Initialize the Command object
    '        MyBase.InitializeCommand()

    '        MyBase.AddParameter("@IdSubLineaB", OdbcType.Int, 16, IdSubLinea)
    '        MyBase.AddParameter("@IdLineaB", OdbcType.Int, 16, IdLinea)
    '        MyBase.AddParameter("@IdFamiliaB", OdbcType.Int, 16, IdFamilia)
    '        MyBase.AddParameter("@IdDeptoB", OdbcType.Int, 16, IdDepto)
    '        MyBase.AddParameter("@ClaveB", OdbcType.Char, 3, Clave)
    '        MyBase.AddParameter("@DescripB", OdbcType.Char, 30, Descrip)

    '        usp_ActualizarEstSubLinea = ExecuteStoredProcedure()
    '    Catch ExceptionErr As Exception
    '        Throw New System.Exception(ExceptionErr.Message, _
    '        ExceptionErr.InnerException)
    '    End Try
    'End Function


    Public Function usp_TraerEstl2(ByVal Idl2 As Integer, ByVal Idl1 As Integer, ByVal IdLinea As Integer, ByVal IdFamilia As Integer, ByVal idDepto As Integer, ByVal idDivisiones As Integer, ByVal Clave As String, ByVal Opcion As Integer, ByVal Descrip As String) As DataSet
        'miguel pérez 24/Septiembre/2012 5:30 p.m.
        Try
            usp_TraerEstl2 = New DataSet
            MyBase.SQL = "CALL usp_TraerEstl2(?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Idl2B", OdbcType.Int, 16, Idl2)
            MyBase.AddParameter("@Idl1B", OdbcType.Int, 16, Idl1)
            MyBase.AddParameter("@IdLineaB", OdbcType.Int, 16, IdLinea)
            MyBase.AddParameter("@IdFamiliaB", OdbcType.Int, 16, IdFamilia)
            MyBase.AddParameter("@IdDeptoB", OdbcType.Int, 16, idDepto)
            MyBase.AddParameter("@IdDivisionesB", OdbcType.Int, 16, idDivisiones)
            MyBase.AddParameter("@ClaveB", OdbcType.Char, 3, Clave)
            MyBase.AddParameter("@Opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@DescripB", OdbcType.Char, 30, Descrip)
            MyBase.FillDataSet(usp_TraerEstl2, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaEstl2(ByVal idDivisiones As Integer, ByVal idDepto As Integer, ByVal idFamilia As Integer, ByVal idLinea As Integer, ByVal idl1 As Integer, ByVal Clave As String, ByVal Descrip As String) As Boolean
        'miguel pérez 27/Septiembre/2012 5:07 p.m.
        Try
            MyBase.SQL = "CALL usp_CapturaEstl2(?,?,?,?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@idDivisionesB", OdbcType.Int, 16, idDivisiones)
            MyBase.AddParameter("@idDeptoB", OdbcType.Int, 16, idDepto)
            MyBase.AddParameter("@idFamiliaB", OdbcType.Int, 16, idFamilia)
            MyBase.AddParameter("@idLineaB", OdbcType.Int, 16, idLinea)
            MyBase.AddParameter("@idl1B", OdbcType.Int, 16, idl1)
            MyBase.AddParameter("@ClaveB", OdbcType.Char, 3, Clave)
            MyBase.AddParameter("@DescripB", OdbcType.Char, 30, Descrip)

            usp_CapturaEstl2 = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    'Public Function usp_ActualizarEstSubSubLinea(ByVal IdSubSubLinea As Integer, ByVal IdSubLinea As Integer, ByVal IdLinea As Integer, ByVal IdFamilia As Integer, ByVal IdDepto As Integer, ByVal Clave As String, ByVal Descrip As String) As Boolean
    '    'miguel pérez 12/Septiembre/2012 12:07 p.m.
    '    Try
    '        MyBase.SQL = "CALL usp_ActualizarEstSubSubLinea(?,?,?,?,?,?,?)"
    '        'Initialize the Command object
    '        MyBase.InitializeCommand()

    '        MyBase.AddParameter("@IdSubSubLineaB", OdbcType.Int, 16, IdSubSubLinea)
    '        MyBase.AddParameter("@IdSubLineaB", OdbcType.Int, 16, IdSubLinea)
    '        MyBase.AddParameter("@IdLineaB", OdbcType.Int, 16, IdLinea)
    '        MyBase.AddParameter("@IdFamiliaB", OdbcType.Int, 16, IdFamilia)
    '        MyBase.AddParameter("@IdDeptoB", OdbcType.Int, 16, IdDepto)
    '        MyBase.AddParameter("@ClaveB", OdbcType.Char, 3, Clave)
    '        MyBase.AddParameter("@DescripB", OdbcType.Char, 30, Descrip)

    '        usp_ActualizarEstSubSubLinea = ExecuteStoredProcedure()
    '    Catch ExceptionErr As Exception
    '        Throw New System.Exception(ExceptionErr.Message, _
    '        ExceptionErr.InnerException)
    '    End Try
    'End Function


    Public Function usp_TraerEstl3(ByVal idl3 As Integer, ByVal Idl2 As Integer, ByVal Idl1 As Integer, ByVal IdLinea As Integer, ByVal IdFamilia As Integer, ByVal idDepto As Integer, ByVal idDivisiones As Integer, ByVal Clave As String, ByVal Opcion As Integer, ByVal Descrip As String) As DataSet
        'miguel pérez 24/Septiembre/2012 5:30 p.m.
        Try
            usp_TraerEstl3 = New DataSet
            MyBase.SQL = "CALL usp_TraerEstl3(?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Idl3B", OdbcType.Int, 16, idl3)
            MyBase.AddParameter("@Idl2B", OdbcType.Int, 16, Idl2)
            MyBase.AddParameter("@Idl1B", OdbcType.Int, 16, Idl1)
            MyBase.AddParameter("@IdLineaB", OdbcType.Int, 16, IdLinea)
            MyBase.AddParameter("@IdFamiliaB", OdbcType.Int, 16, IdFamilia)
            MyBase.AddParameter("@IdDeptoB", OdbcType.Int, 16, idDepto)
            MyBase.AddParameter("@IdDivisionesB", OdbcType.Int, 16, idDivisiones)
            MyBase.AddParameter("@ClaveB", OdbcType.Char, 3, Clave)
            MyBase.AddParameter("@Opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@DescripB", OdbcType.Char, 30, Descrip)
            MyBase.FillDataSet(usp_TraerEstl3, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_CapturaEstl3(ByVal idDivisiones As Integer, ByVal idDepto As Integer, ByVal idFamilia As Integer, ByVal idLinea As Integer, ByVal idl1 As Integer, ByVal idl2 As Integer, ByVal Clave As String, ByVal Descrip As String) As Boolean
        'miguel pérez 27/Septiembre/2012 5:07 p.m.
        Try
            MyBase.SQL = "CALL usp_CapturaEstl3(?,?,?,?,?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@idDivisionesB", OdbcType.Int, 16, idDivisiones)
            MyBase.AddParameter("@idDeptoB", OdbcType.Int, 16, idDepto)
            MyBase.AddParameter("@idFamiliaB", OdbcType.Int, 16, idFamilia)
            MyBase.AddParameter("@idLineaB", OdbcType.Int, 16, idLinea)
            MyBase.AddParameter("@idl1B", OdbcType.Int, 16, idl1)
            MyBase.AddParameter("@idl2B", OdbcType.Int, 16, idl2)
            MyBase.AddParameter("@ClaveB", OdbcType.Char, 3, Clave)
            MyBase.AddParameter("@DescripB", OdbcType.Char, 30, Descrip)

            usp_CapturaEstl3 = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerEstEstructura(ByVal idSubSubSubLinea As Integer, ByVal IdSubSubLinea As Integer, ByVal IdSubLinea As Integer, ByVal IdLinea As Integer, ByVal IdFamilia As Integer, ByVal idDepto As Integer, ByVal idDivisiones As Integer) As DataSet
        'miguel pérez 24/Septiembre/2012 5:30 p.m.
        Try
            usp_TraerEstEstructura = New DataSet
            MyBase.SQL = "CALL usp_TraerEstEstructura(?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdSubSubSubLineaB", OdbcType.Int, 16, idSubSubSubLinea)
            MyBase.AddParameter("@IdSubSubLineaB", OdbcType.Int, 16, IdSubSubLinea)
            MyBase.AddParameter("@IdSubLineaB", OdbcType.Int, 16, IdSubLinea)
            MyBase.AddParameter("@IdLineaB", OdbcType.Int, 16, IdLinea)
            MyBase.AddParameter("@IdFamiliaB", OdbcType.Int, 16, IdFamilia)
            MyBase.AddParameter("@IdDeptoB", OdbcType.Int, 16, idDepto)
            MyBase.AddParameter("@IdDivisionesB", OdbcType.Int, 16, idDivisiones)
            MyBase.FillDataSet(usp_TraerEstEstructura, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerEstl4(ByVal idl4 As Integer, ByVal idl3 As Integer, ByVal Idl2 As Integer, ByVal Idl1 As Integer, ByVal IdLinea As Integer, ByVal IdFamilia As Integer, ByVal idDepto As Integer, ByVal idDivisiones As Integer, ByVal Clave As String, ByVal Opcion As Integer, ByVal Descrip As String) As DataSet
        'miguel pérez 24/Septiembre/2012 5:30 p.m.
        Try
            usp_TraerEstl4 = New DataSet
            MyBase.SQL = "CALL usp_TraerEstl4(?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Idl4B", OdbcType.Int, 16, idl4)
            MyBase.AddParameter("@Idl3B", OdbcType.Int, 16, idl3)
            MyBase.AddParameter("@Idl2B", OdbcType.Int, 16, Idl2)
            MyBase.AddParameter("@Idl1B", OdbcType.Int, 16, Idl1)
            MyBase.AddParameter("@IdLineaB", OdbcType.Int, 16, IdLinea)
            MyBase.AddParameter("@IdFamiliaB", OdbcType.Int, 16, IdFamilia)
            MyBase.AddParameter("@IdDeptoB", OdbcType.Int, 16, idDepto)
            MyBase.AddParameter("@IdDivisionesB", OdbcType.Int, 16, idDivisiones)
            MyBase.AddParameter("@ClaveB", OdbcType.Char, 3, Clave)
            MyBase.AddParameter("@Opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@DescripB", OdbcType.Char, 30, Descrip)
            MyBase.FillDataSet(usp_TraerEstl4, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaEstl4(ByVal idDivisiones As Integer, ByVal idDepto As Integer, ByVal idFamilia As Integer, ByVal idLinea As Integer, ByVal idl1 As Integer, ByVal idl2 As Integer, ByVal idl3 As Integer, ByVal Clave As String, ByVal Descrip As String) As Boolean
        'miguel pérez 27/Septiembre/2012 5:07 p.m.
        Try
            MyBase.SQL = "CALL usp_CapturaEstl4(?,?,?,?,?,?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@idDivisionesB", OdbcType.Int, 16, idDivisiones)
            MyBase.AddParameter("@idDeptoB", OdbcType.Int, 16, idDepto)
            MyBase.AddParameter("@idFamiliaB", OdbcType.Int, 16, idFamilia)
            MyBase.AddParameter("@idLineaB", OdbcType.Int, 16, idLinea)
            MyBase.AddParameter("@idl1B", OdbcType.Int, 16, idl1)
            MyBase.AddParameter("@idl2B", OdbcType.Int, 16, idl2)
            MyBase.AddParameter("@idl3B", OdbcType.Int, 16, idl3)
            MyBase.AddParameter("@ClaveB", OdbcType.Char, 3, Clave)
            MyBase.AddParameter("@DescripB", OdbcType.Char, 30, Descrip)

            usp_CapturaEstl4 = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerEstl5(ByVal idl5 As Integer, ByVal idl4 As Integer, ByVal idl3 As Integer, ByVal Idl2 As Integer, ByVal Idl1 As Integer, ByVal IdLinea As Integer, ByVal IdFamilia As Integer, ByVal idDepto As Integer, ByVal idDivisiones As Integer, ByVal Clave As String, ByVal Opcion As Integer, ByVal Descrip As String) As DataSet
        'miguel pérez 24/Septiembre/2012 5:30 p.m.
        Try
            usp_TraerEstl5 = New DataSet
            MyBase.SQL = "CALL usp_TraerEstl5(?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Idl5B", OdbcType.Int, 16, idl5)
            MyBase.AddParameter("@Idl4B", OdbcType.Int, 16, idl4)
            MyBase.AddParameter("@Idl3B", OdbcType.Int, 16, idl3)
            MyBase.AddParameter("@Idl2B", OdbcType.Int, 16, Idl2)
            MyBase.AddParameter("@Idl1B", OdbcType.Int, 16, Idl1)
            MyBase.AddParameter("@IdLineaB", OdbcType.Int, 16, IdLinea)
            MyBase.AddParameter("@IdFamiliaB", OdbcType.Int, 16, IdFamilia)
            MyBase.AddParameter("@IdDeptoB", OdbcType.Int, 16, idDepto)
            MyBase.AddParameter("@IdDivisionesB", OdbcType.Int, 16, idDivisiones)
            MyBase.AddParameter("@ClaveB", OdbcType.Char, 3, Clave)
            MyBase.AddParameter("@Opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@DescripB", OdbcType.Char, 30, Descrip)
            MyBase.FillDataSet(usp_TraerEstl5, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaEstl5(ByVal idDivisiones As Integer, ByVal idDepto As Integer, ByVal idFamilia As Integer, ByVal idLinea As Integer, ByVal idl1 As Integer, ByVal idl2 As Integer, ByVal idl3 As Integer, ByVal idl4 As Integer, ByVal Clave As String, ByVal Descrip As String) As Boolean
        'miguel pérez 27/Septiembre/2012 5:07 p.m.
        Try
            MyBase.SQL = "CALL usp_CapturaEstl5(?,?,?,?,?,?,?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@idDivisionesB", OdbcType.Int, 16, idDivisiones)
            MyBase.AddParameter("@idDeptoB", OdbcType.Int, 16, idDepto)
            MyBase.AddParameter("@idFamiliaB", OdbcType.Int, 16, idFamilia)
            MyBase.AddParameter("@idLineaB", OdbcType.Int, 16, idLinea)
            MyBase.AddParameter("@idl1B", OdbcType.Int, 16, idl1)
            MyBase.AddParameter("@idl2B", OdbcType.Int, 16, idl2)
            MyBase.AddParameter("@idl3B", OdbcType.Int, 16, idl3)
            MyBase.AddParameter("@idl4B", OdbcType.Int, 16, idl4)
            MyBase.AddParameter("@ClaveB", OdbcType.Char, 3, Clave)
            MyBase.AddParameter("@DescripB", OdbcType.Char, 30, Descrip)

            usp_CapturaEstl5 = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerEstl6(ByVal idl6 As Integer, ByVal idl5 As Integer, ByVal idl4 As Integer, ByVal idl3 As Integer, ByVal Idl2 As Integer, ByVal Idl1 As Integer, ByVal IdLinea As Integer, ByVal IdFamilia As Integer, ByVal idDepto As Integer, ByVal idDivisiones As Integer, ByVal Clave As String, ByVal Opcion As Integer, ByVal Descrip As String) As DataSet
        'miguel pérez 24/Septiembre/2012 5:30 p.m.
        Try
            usp_TraerEstl6 = New DataSet
            MyBase.SQL = "CALL usp_TraerEstl6(?,?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Idl6B", OdbcType.Int, 16, idl6)
            MyBase.AddParameter("@Idl5B", OdbcType.Int, 16, idl5)
            MyBase.AddParameter("@Idl4B", OdbcType.Int, 16, idl4)
            MyBase.AddParameter("@Idl3B", OdbcType.Int, 16, idl3)
            MyBase.AddParameter("@Idl2B", OdbcType.Int, 16, Idl2)
            MyBase.AddParameter("@Idl1B", OdbcType.Int, 16, Idl1)
            MyBase.AddParameter("@IdLineaB", OdbcType.Int, 16, IdLinea)
            MyBase.AddParameter("@IdFamiliaB", OdbcType.Int, 16, IdFamilia)
            MyBase.AddParameter("@IdDeptoB", OdbcType.Int, 16, idDepto)
            MyBase.AddParameter("@IdDivisionesB", OdbcType.Int, 16, idDivisiones)
            MyBase.AddParameter("@ClaveB", OdbcType.Char, 3, Clave)
            MyBase.AddParameter("@Opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@DescripB", OdbcType.Char, 30, Descrip)
            MyBase.FillDataSet(usp_TraerEstl6, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaEstl6(ByVal idDivisiones As Integer, ByVal idDepto As Integer, ByVal idFamilia As Integer, ByVal idLinea As Integer, ByVal idl1 As Integer, ByVal idl2 As Integer, ByVal idl3 As Integer, ByVal idl4 As Integer, ByVal idl5 As Integer, ByVal Clave As String, ByVal Descrip As String) As Boolean
        'miguel pérez 27/Septiembre/2012 5:07 p.m.
        Try
            MyBase.SQL = "CALL usp_CapturaEstl6(?,?,?,?,?,?,?,?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@idDivisionesB", OdbcType.Int, 16, idDivisiones)
            MyBase.AddParameter("@idDeptoB", OdbcType.Int, 16, idDepto)
            MyBase.AddParameter("@idFamiliaB", OdbcType.Int, 16, idFamilia)
            MyBase.AddParameter("@idLineaB", OdbcType.Int, 16, idLinea)
            MyBase.AddParameter("@idl1B", OdbcType.Int, 16, idl1)
            MyBase.AddParameter("@idl2B", OdbcType.Int, 16, idl2)
            MyBase.AddParameter("@idl3B", OdbcType.Int, 16, idl3)
            MyBase.AddParameter("@idl4B", OdbcType.Int, 16, idl4)
            MyBase.AddParameter("@idl5B", OdbcType.Int, 16, idl5)
            MyBase.AddParameter("@ClaveB", OdbcType.Char, 3, Clave)
            MyBase.AddParameter("@DescripB", OdbcType.Char, 30, Descrip)

            usp_CapturaEstl6 = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
