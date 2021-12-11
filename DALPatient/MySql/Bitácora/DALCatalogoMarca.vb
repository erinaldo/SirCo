Imports System.Data.Odbc


Public Class DALCatalogoMarca
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


    Public Function usp_PpalCatalogoMarca(ByVal Marca As String, ByVal Estatus As String) As DataSet
        'mreyes 04/Mayo/2012 07:44 p.m.
        Try
            usp_PpalCatalogoMarca = New DataSet
            MyBase.SQL = "CALL usp_PpalCatalogoMarca(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Marcab", OdbcType.Char, 50, Marca)
            MyBase.AddParameter("@Estatusb", OdbcType.Char, 1, Estatus)


            MyBase.FillDataSet(usp_PpalCatalogoMarca, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Captura_Marca(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 05/Mayo/2012 09:33 a.m.
        Try
            MyBase.SQL = "CALL usp_Captura_Marca(?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@marca", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("marca"))
            MyBase.AddParameter("@descrip", OdbcType.Char, 30, Section.Tables(0).Rows(0).Item("descrip"))
            MyBase.AddParameter("@factor", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("factor"))
            MyBase.AddParameter("@resmin", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("resmin"))




            usp_Captura_Marca = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_MarcaProvCosto(ByVal Opcion As Integer, ByVal Marca As String, ByVal Proveedor As String, _
                                      ByVal Costo As Decimal, ByVal IdUsuario As Integer) As Boolean
        'Tony Garcia - 12/Marzo/2013 - 11:33 a.m.
        Try
            MyBase.SQL = "CALL usp_Captura_MarcaProvCosto(?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@marcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@costoB", OdbcType.Double, 9, Costo)
            MyBase.AddParameter("@idusuarioB", OdbcType.Int, 4, IdUsuario)


            usp_Captura_MarcaProvCosto = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Traer_MarcaProvCosto(ByVal Marca As String) As DataSet
        'Tony Garcia - 13/Marzo/2013 - 12:33 p.m.
        Try
            usp_Traer_MarcaProvCosto = New DataSet
            MyBase.SQL = "CALL usp_TraerMarcaProvCosto(?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()


            MyBase.AddParameter("@marcaB", OdbcType.Char, 3, Marca)


            MyBase.FillDataSet(usp_Traer_MarcaProvCosto, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerEmpleadoCompras() As DataSet
        Try
            usp_TraerEmpleadoCompras = New DataSet
            MyBase.SQL = "CALL usp_TraerEmpleadoCompras()" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.FillDataSet(usp_TraerEmpleadoCompras, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_AsignarMarca(ByVal Marca As String, ByVal IdEmpleado As Integer) As Boolean
        'mreyes 05/Mayo/2012 09:33 a.m.
        Try
            MyBase.SQL = "CALL usp_AsignarMarca(?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@marcab", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@idempleadob", OdbcType.SmallInt, 4, IdEmpleado)


            usp_AsignarMarca = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_ActualizarEstatusMarca(ByVal Marca As String, ByVal Estatus As String) As Boolean
        'mreyes 05/Mayo/2012 09:33 a.m.
        Try
            MyBase.SQL = "CALL usp_ActualizarEstatusMarca(?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@marcab", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@estatusb", OdbcType.Char, 1, Estatus)


            usp_ActualizarEstatusMarca = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
