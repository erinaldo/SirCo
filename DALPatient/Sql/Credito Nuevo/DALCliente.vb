Public Class DALCliente

    Inherits DALBase
#Region "Constructor And Destructor"

    Sub New(ByVal ConString As String)
        MyBase.New(ConString)
    End Sub

    Public Shadows Sub Dispose()
        MyBase.Dispose()
    End Sub
#End Region

#Region " Public Role Functions "

    Public Function usp_CapturaCliente(ByVal opcion As Integer, ByVal idcliente As Integer, ByVal nombre As String, ByVal appaterno As String,
                                       ByVal apmaterno As String, ByVal sexo As String, ByVal idestado As Integer, ByVal idciudad As Integer,
                                       ByVal idcolonia As Integer, ByVal codigopostal As String, ByVal calle As String, ByVal numero As Integer,
                                       ByVal celular1 As String, ByVal email As String, ByVal idusuario As Integer, ByVal idusuariomodif As Integer) As Boolean
        'vgallegos 19/Enero/2018  12:09 p.m.
        Try
            MyBase.SQL = "usp_CapturaCliente"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", SqlDbType.Int, 4, opcion)
            MyBase.AddParameter("@idcliente", SqlDbType.Int, 4, idcliente)
            MyBase.AddParameter("@nombre", SqlDbType.VarChar, 100, nombre)
            MyBase.AddParameter("@appaterno", SqlDbType.VarChar, 100, appaterno)
            MyBase.AddParameter("@apmaterno", SqlDbType.VarChar, 100, apmaterno)
            MyBase.AddParameter("@sexo", SqlDbType.VarChar, 1, sexo)
            MyBase.AddParameter("@idestado", SqlDbType.Int, 4, idestado)
            MyBase.AddParameter("@idciudad", SqlDbType.Int, 4, idciudad)
            MyBase.AddParameter("@idcolonia", SqlDbType.Int, 4, idcolonia)
            MyBase.AddParameter("@codigopostal", SqlDbType.VarChar, 5, codigopostal)
            MyBase.AddParameter("@calle", SqlDbType.VarChar, 250, calle)
            MyBase.AddParameter("@numero", SqlDbType.SmallInt, 2, numero)
            MyBase.AddParameter("@celular1", SqlDbType.VarChar, 10, celular1)
            MyBase.AddParameter("@email", SqlDbType.VarChar, 150, email)
            MyBase.AddParameter("@idusuario", SqlDbType.Int, 4, idusuario)
            MyBase.AddParameter("@idusuariomodif", SqlDbType.Int, 4, idusuariomodif)

            usp_CapturaCliente = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerCliente(ByVal opcion As Integer, ByVal idcliente As Integer, ByVal nombre As String, ByVal appaterno As String, ByVal apmaterno As String) As DataSet
        'vgallegos 03/Febrero/2018  11:51 p.m.
        Try
            usp_TraerCliente = New DataSet
            MyBase.SQL = "usp_TraerCliente"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", SqlDbType.Int, 4, opcion)
            MyBase.AddParameter("@idcliente", SqlDbType.Int, 4, idcliente)
            MyBase.AddParameter("@nombre", SqlDbType.VarChar, 39, nombre)
            MyBase.AddParameter("@appaterno", SqlDbType.VarChar, 30, appaterno)
            MyBase.AddParameter("@apmaterno", SqlDbType.VarChar, 30, apmaterno)

            MyBase.FillDataSet(usp_TraerCliente, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_ValidarCliente(ByVal nombre As String, ByVal appaterno As String, ByVal apmaterno As String) As DataSet
        'vgallegos 03/Febrero/2018  11:51 p.m.
        Try
            usp_ValidarCliente = New DataSet
            MyBase.SQL = "SELECT idcliente FROM cliente WHERE nombre='" + nombre + "' AND appaterno='" + appaterno + "' AND apmaterno='" + apmaterno + "'"

            MyBase.InitializeCommand()

            MyBase.FillDataSet(usp_ValidarCliente, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
