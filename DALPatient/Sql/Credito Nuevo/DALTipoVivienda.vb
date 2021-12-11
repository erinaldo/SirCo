'lvillegas 19/01/2018 12:33 p.m.
Imports System.Data
Imports System.Data.SqlClient
Public Class DALTipoVivienda


    ''''Inherits DALOdbc
    Inherits DALBase
#Region "Constructor And Destructor"
    Sub New(ByVal ConString As String)
        MyBase.New(ConString)
    End Sub

    Public Shadows Sub Dispose()
        MyBase.Dispose()
    End Sub
#End Region


#Region "Public Function"


    Public Function usp_CapturaAccesos(IdEmpleado As Integer, Usuario As String, Programa As String, Ip As String) As Boolean

        Try




            MyBase.SQL = "usp_CapturaAccesosIP"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@idempleado", SqlDbType.Int, 16, IdEmpleado)

            MyBase.AddParameter("@usuario", SqlDbType.VarChar, 50, Usuario)
            MyBase.AddParameter("@programa", SqlDbType.VarChar, 50, Programa)
            MyBase.AddParameter("@Ip", SqlDbType.VarChar, 250, Ip)


            'Execute stored procedure, Recuerda inserta y elimina son Boolean 
            usp_CapturaAccesos = ExecuteStoredProcedure()

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try


    End Function




    Public Function usp_CapturaAccesosSIRCO(Opcion As Integer, IdEmpleado As Integer, Usuario As String, Ip As String) As Boolean

        Try




            MyBase.SQL = "usp_CapturaAccesosSIRCO"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", SqlDbType.Int, 16, Opcion)
            MyBase.AddParameter("@idempleado", SqlDbType.Int, 16, IdEmpleado)

            MyBase.AddParameter("@usuario", SqlDbType.VarChar, 50, Usuario)
            MyBase.AddParameter("@Ip", SqlDbType.VarChar, 250, Ip)


            'Execute stored procedure, Recuerda inserta y elimina son Boolean 
            usp_CapturaAccesosSIRCO = ExecuteStoredProcedure()

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try


    End Function


    Public Function usp_TraerAccesosSIRCO(Opcion As Integer, IdEmpleado As Integer, Usuario As String, Ip As String) As DataSet
        Try
            usp_TraerAccesosSIRCO = New DataSet
            MyBase.SQL = "usp_CapturaAccesosSIRCO"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", SqlDbType.Int, 16, Opcion)
            MyBase.AddParameter("@IdEmpleado", SqlDbType.Int, 16, IdEmpleado)
            MyBase.AddParameter("@usuario", SqlDbType.VarChar, 50, Usuario)
            MyBase.AddParameter("@Ip", SqlDbType.VarChar, 250, Ip)

            MyBase.FillDataSet(usp_TraerAccesosSIRCO, "Accesos")

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
               ExceptionErr.InnerException)
        End Try

    End Function

    Public Function usp_capturaTipoVivienda(ByVal opcion As Integer,
                                             ByVal idtipovivienda As Integer,
                                             ByVal tipovivienda As String,
                                             ByVal observaciones As String,
                                             ByVal idusuario As Integer,
                                             ByVal idusuariomodif As Integer,
                                             ByVal fummodif As Date) As Boolean

        Try

            'El store procedure no se puede llamar usp_altasetc 
            'comentamos que es usp_catalogoxxx donde xxx es el nombre de la tabla, 
            'los campos en los tipos son iguales a los que tienenes en la tabla, igual los nombres de los parametros

            'iduser, NonSerializedAttribute tengo idea de donde lo sacaste, DALValesPorNegocio ejemplo



            MyBase.SQL = "usp_capturaTipoVivienda"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", SqlDbType.Int, 16, opcion)
            MyBase.AddParameter("@idtipovivienda", SqlDbType.Int, 16, idtipovivienda)
            MyBase.AddParameter("@tipovivienda", SqlDbType.VarChar, 50, tipovivienda)
            MyBase.AddParameter("@observaciones", SqlDbType.VarChar, 150, observaciones)
            MyBase.AddParameter("@idusuario", SqlDbType.Int, 16, idusuario)
            MyBase.AddParameter("@idusuariomodif", SqlDbType.Int, 16, idusuariomodif)
            MyBase.AddParameter("@fummodif", SqlDbType.Date, 10, fummodif)

            'Execute stored procedure, Recuerda inserta y elimina son Boolean 
            usp_capturaTipoVivienda = ExecuteStoredProcedure()

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try


    End Function




    Public Function usp_mostrarTipoVivienda(ByVal opcion As Integer,
                                             ByVal idtipovivienda As Integer,
                                             ByVal tipovivienda As String,
                                             ByVal observaciones As String,
                                             ByVal idusuario As Integer,
                                             ByVal idusuariomodif As Integer,
                                             ByVal fummodif As Date) As DataSet
        Try
            usp_mostrarTipoVivienda = New DataSet
            MyBase.SQL = "usp_capturaTipoVivienda"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", SqlDbType.Int, 16, opcion)
            MyBase.AddParameter("@idtipovivienda", SqlDbType.Int, 16, idtipovivienda)
            MyBase.AddParameter("@tipovivienda", SqlDbType.VarChar, 50, tipovivienda)
            MyBase.AddParameter("@observaciones", SqlDbType.VarChar, 150, observaciones)
            MyBase.AddParameter("@idusuario", SqlDbType.Int, 16, idusuario)
            MyBase.AddParameter("@idusuariomodif", SqlDbType.Int, 16, idusuariomodif)
            MyBase.AddParameter("@fummodif", SqlDbType.Date, 10, fummodif)
            MyBase.FillDataSet(usp_mostrarTipoVivienda, "tipovivienda")

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
               ExceptionErr.InnerException)
        End Try

    End Function
#End Region





End Class
