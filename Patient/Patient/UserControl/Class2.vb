Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Odbc

Public Class DALOdbc

    Implements IDisposable

    'Class level variables that are available to classes that instantiate me
    Public SQL As String

    Public Connection As OdbcConnection
    Public Command As OdbcCommand
    Public DataAdapter As OdbcDataAdapter
    Public DataReader As OdbcDataReader
    Private disposedValue As Boolean = False ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
                If Not DataReader Is Nothing Then
                    DataReader.Close()
                    DataReader = Nothing
                End If
                If Not DataAdapter Is Nothing Then
                    DataAdapter.Dispose()
                    DataAdapter = Nothing
                End If
                If Not Command Is Nothing Then
                    Command.Dispose()
                    Command = Nothing
                End If
                If Not Connection Is Nothing Then
                    Connection.Close()
                    Connection.Dispose()
                    Connection = Nothing
                End If
            End If

            ' TODO: free shared unmanaged resources
        End If
        Me.disposedValue = True
    End Sub

    Public Sub New(ByVal ConString As String)
        'Build the SQL connection string and initialize the Connection object

        Connection = New OdbcConnection(ConString)
    End Sub

#Region " IDisposable Support "
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
    Public Sub OpenConnection()
        Try
            Connection.Open()

        Catch SQLExceptionErr As OdbcException
            Throw New System.Exception(SQLExceptionErr.Message, _
                SQLExceptionErr.InnerException)
        Catch InvalidOperationExceptionErr As InvalidOperationException
            Throw New System.Exception(InvalidOperationExceptionErr.Message, _
                InvalidOperationExceptionErr.InnerException)
        End Try
    End Sub

    Public Sub CloseConnection()
        Connection.Close()

    End Sub

    Public Sub InitializeCommand()
        If Command Is Nothing Then
            Try
                Command = New OdbcCommand(SQL, Connection)

                'See if this is a stored procedure
                If Not SQL.ToUpper.StartsWith("SELECT ") _
                    And Not SQL.ToUpper.StartsWith("INSERT ") _
                    And Not SQL.ToUpper.StartsWith("UPDATE ") _
                    And Not SQL.ToUpper.StartsWith("DELETE ") Then
                    'Command.CommandType = CommandType.StoredProcedure
                    Command.CommandType = CommandType.StoredProcedure
                End If
            Catch SQLExceptionErr As OdbcException
                Throw New System.Exception(SQLExceptionErr.Message, _
                    SQLExceptionErr.InnerException)
            End Try
        End If
    End Sub

    Public Sub AddParameter(ByVal Name As String, ByVal Type As OdbcType, _
        ByVal Size As Integer, ByVal Value As Object)

        Try
            Command.Parameters.Add(Name, Type, Size).Value = Value
        Catch SQLExceptionErr As OdbcException
            Throw New System.Exception(SQLExceptionErr.Message, _
                SQLExceptionErr.InnerException)
        End Try
    End Sub

    Public Sub InitializeDataAdapter()
        Try
            DataAdapter = New OdbcDataAdapter
            DataAdapter.SelectCommand = Command
        Catch SQLExceptionErr As OdbcException
            Throw New System.Exception(SQLExceptionErr.Message, _
            SQLExceptionErr.InnerException)
        End Try
    End Sub

    Public Sub FillDataSet(ByRef oDataSet As DataSet, ByVal TableName As String)
        Try
            InitializeCommand()
            InitializeDataAdapter()
            DataAdapter.Fill(oDataSet, TableName)
        Catch SQLExceptionErr As OdbcException
            Throw New System.Exception(SQLExceptionErr.Message, _
                SQLExceptionErr.InnerException)
        Finally
            Command.Dispose()
            Command = Nothing
            DataAdapter.Dispose()
            DataAdapter = Nothing
        End Try
    End Sub

    Public Sub FillDataTable(ByRef oDataTable As DataTable)
        Try
            InitializeCommand()
            InitializeDataAdapter()
            DataAdapter.Fill(oDataTable)
        Catch SQLExceptionErr As OdbcException
            Throw New System.Exception(SQLExceptionErr.Message, _
                SQLExceptionErr.InnerException)
        Finally
            Command.Dispose()
            Command = Nothing
            DataAdapter.Dispose()
            DataAdapter = Nothing
        End Try
    End Sub

    Public Function ExecuteStoredProcedure() As Integer
        Try
            OpenConnection()
            ExecuteStoredProcedure = Command.ExecuteNonQuery()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        Finally
            CloseConnection()
        End Try
    End Function


End Class

Public Class DALVta
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

    Public Function ObtenVentas(ByVal fecini As String, ByVal fecfin As String) As DataSet
        Try
            ObtenVentas = New DataSet
            MyBase.SQL = "CALL SPSel_Ventas('','',? ,?)"

            MyBase.InitializeCommand()
            'MyBase.AddParameter("@sucursal", OdbcType.Char, 2, "")
            'MyBase.AddParameter("@vendedor", OdbcType.Char, 2, "")
            MyBase.AddParameter("@fecini", OdbcType.Date, 8, fecini)
            MyBase.AddParameter("@fecfin", OdbcType.Date, 8, fecfin)

            'Fill the DataSet
            MyBase.FillDataSet(ObtenVentas, "ventas")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function ObtenDevoluciones(ByVal fecini As String, ByVal fecfin As String) As DataSet
        Try
            ObtenDevoluciones = New DataSet
            MyBase.SQL = "CALL SPSel_DevolVtas('','',? ,?)"

            MyBase.InitializeCommand()
            'MyBase.AddParameter("@sucursal", OdbcType.Char, 2, "")
            'MyBase.AddParameter("@vendedor", OdbcType.Char, 2, "")
            MyBase.AddParameter("@fecini", OdbcType.Date, 8, fecini)
            MyBase.AddParameter("@fecfin", OdbcType.Date, 8, fecfin)

            'Fill the DataSet
            MyBase.FillDataSet(ObtenDevoluciones, "devoluciones")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function ObtenVentasporSucursal(ByVal fecini As String, ByVal fecfin As String, _
                                           ByVal sucursal As String) As DataSet
        Try
            ObtenVentasporSucursal = New DataSet
            MyBase.SQL = "CALL SPSel_Ventas(?,'',? ,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@sucursal", OdbcType.Char, 2, sucursal)
            'MyBase.AddParameter("@vendedor", OdbcType.Char, 2, "")
            MyBase.AddParameter("@fecini", OdbcType.Date, 8, fecini)
            MyBase.AddParameter("@fecfin", OdbcType.Date, 8, fecfin)

            'Fill the DataSet
            MyBase.FillDataSet(ObtenVentasporSucursal, "ventas")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function ObtenDevolucionesporSucursal(ByVal fecini As String, ByVal fecfin As String, _
                                           ByVal sucursal As String) As DataSet
        Try
            ObtenDevolucionesporSucursal = New DataSet
            MyBase.SQL = "CALL SPSel_DevolVtas(?,'',? ,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@sucursal", OdbcType.Char, 2, sucursal)
            'MyBase.AddParameter("@vendedor", OdbcType.Char, 2, "")
            MyBase.AddParameter("@fecini", OdbcType.Date, 8, fecini)
            MyBase.AddParameter("@fecfin", OdbcType.Date, 8, fecfin)

            'Fill the DataSet
            MyBase.FillDataSet(ObtenDevolucionesporSucursal, "devoluciones")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function ObtenVentasporVendedor(ByVal fecini As String, ByVal fecfin As String, _
                                           ByVal vendedor As String) As DataSet
        Try
            ObtenVentasporVendedor = New DataSet
            MyBase.SQL = "CALL SPSel_Ventas('',?,?,?)"

            MyBase.InitializeCommand()
            'MyBase.AddParameter("@sucursal", OdbcType.Char, 2, "")
            MyBase.AddParameter("@vendedor", OdbcType.Char, 2, vendedor)
            MyBase.AddParameter("@fecini", OdbcType.Date, 8, fecini)
            MyBase.AddParameter("@fecfin", OdbcType.Date, 8, fecfin)

            'Fill the DataSet
            MyBase.FillDataSet(ObtenVentasporVendedor, "ventas")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function ObtenDevolucionesporVendedor(ByVal fecini As String, ByVal fecfin As String, _
                                           ByVal vendedor As String) As DataSet
        Try
            ObtenDevolucionesporVendedor = New DataSet
            MyBase.SQL = "CALL SPSel_DevolVtas('',?,?,?)"

            MyBase.InitializeCommand()
            'MyBase.AddParameter("@sucursal", OdbcType.Char, 2, "")
            MyBase.AddParameter("@vendedor", OdbcType.Char, 2, vendedor)
            MyBase.AddParameter("@fecini", OdbcType.Date, 8, fecini)
            MyBase.AddParameter("@fecfin", OdbcType.Date, 8, fecfin)

            'Fill the DataSet
            MyBase.FillDataSet(ObtenDevolucionesporVendedor, "devoluciones")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function ObtenVendedor() As DataSet
        Try
            ObtenVendedor = New DataSet
            MyBase.SQL = "CALL SPSel_Vendedor('','')"
            MyBase.InitializeCommand()

            'Fill the DataSet
            MyBase.FillDataSet(ObtenVendedor, "vendedor")

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try

    End Function


    Public Function ObtenVendedorporID(ByVal Id As String) As DataSet
        Try
            ObtenVendedorporID = New DataSet
            MyBase.SQL = "CALL SPSel_Vendedor(?,?)"
            MyBase.InitializeCommand()

            MyBase.AddParameter("@vendedor", OdbcType.Char, 2, Id)
            MyBase.AddParameter("@nombre", OdbcType.Char, 10, "")

            'Fill the DataSet
            MyBase.FillDataSet(ObtenVendedorporID, "vendedor")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function ObtenVendedorporNombre(ByVal Nombre As String) As DataSet
        Try
            ObtenVendedorporNombre = New DataSet
            MyBase.SQL = "CALL SPSel_Vendedor(?,?)"
            MyBase.InitializeCommand()

            MyBase.AddParameter("@vendedor", OdbcType.Char, 2, "")
            MyBase.AddParameter("@nombre", OdbcType.Char, 10, Nombre)

            'Fill the DataSet
            MyBase.FillDataSet(ObtenVendedorporNombre, "vendedor")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function ObtenCajero() As DataSet
        Try
            ObtenCajero = New DataSet
            MyBase.SQL = "CALL SPSel_Cajero('','')"
            MyBase.InitializeCommand()

            'Fill the DataSet
            MyBase.FillDataSet(ObtenCajero, "cajero")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try

    End Function

    Public Function ObtenCajeroporID(ByVal ID As String) As DataSet
        Try
            ObtenCajeroporID = New DataSet
            MyBase.SQL = "CALL SPSel_Cajero(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@cajero", OdbcType.Char, 2, ID)
            MyBase.AddParameter("@nombre", OdbcType.Char, 10, "")
            'Fill the DataSet
            MyBase.FillDataSet(ObtenCajeroporID, "cajero")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function


    Public Function ObtenCajeroporNombre(ByVal Nombre As String) As DataSet
        Try
            ObtenCajeroporNombre = New DataSet
            MyBase.SQL = "CALL SPSel_Cajero(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@cajero", OdbcType.Char, 2, "")
            MyBase.AddParameter("@nombre", OdbcType.Char, 10, Nombre)
            'Fill the DataSet
            MyBase.FillDataSet(ObtenCajeroporNombre, "cajero")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class

Public Class BCLVta
    Implements IDisposable
    Private objDALVentas As DALVta
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"

    Public Sub New(ByVal Constring As String)
9:      objDALVentas = New DALVta(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALVentas.Dispose()
            objDALVentas = Nothing
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
#Region " Public Functions "

    Public Function ObtenVentas(ByVal fecini As Date, ByVal fecfin As Date) As DataSet
        Try
            'Call the data component to get all groups
            ObtenVentas = objDALVentas.ObtenVentas(fecini, fecfin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function ObtenDevoluciones(ByVal fecini As Date, ByVal fecfin As Date) As DataSet
        Try
            'Call the data component to get all groups
            ObtenDevoluciones = objDALVentas.ObtenDevoluciones(fecini, fecfin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function ObtenVentasporSucursal(ByVal fecini As Date, ByVal fecfin As Date, ByVal Sucursal As String) As DataSet
        Try
            'Call the data component to get all groups
            ObtenVentasporSucursal = objDALVentas.ObtenVentasporSucursal(fecini, fecfin, Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function ObtenDevolucionesporSucursal(ByVal fecini As Date, ByVal fecfin As Date, ByVal Sucursal As String) As DataSet
        Try
            'Call the data component to get all groups
            ObtenDevolucionesporSucursal = objDALVentas.ObtenDevolucionesporSucursal(fecini, fecfin, Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function ObtenVentasporVendedor(ByVal fecini As Date, ByVal fecfin As Date, ByVal vendedor As String) As DataSet
        Try
            'Call the data component to get all groups
            ObtenVentasporVendedor = objDALVentas.ObtenVentasporVendedor(fecini, fecfin, vendedor)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function ObtenDevolucionesporVendedor(ByVal fecini As Date, ByVal fecfin As Date, ByVal vendedor As String) As DataSet
        Try
            'Call the data component to get all groups
            ObtenDevolucionesporVendedor = objDALVentas.ObtenDevolucionesporVendedor(fecini, fecfin, vendedor)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function ObtenVendedorporId(ByVal id As String) As DataSet
        Try
            'Call the data component to get all groups
            ObtenVendedorporId = objDALVentas.ObtenVendedorporID(id)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function ObtenCajeroporId(ByVal id As String) As DataSet
        Try
            'Call the data component to get all groups
            ObtenCajeroporId = objDALVentas.ObtenCajeroporID(id)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class

Public Class DALBase1
    Implements IDisposable

    'Class level variables that are available to classes that instantiate me
    Public SQL As String

    Public Connection As SqlConnection
    Public Command As SqlCommand
    Public DataAdapter As SqlDataAdapter
    Public DataReader As SqlDataReader
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
                If Not DataReader Is Nothing Then
                    DataReader.Close()
                    DataReader = Nothing
                End If
                If Not DataAdapter Is Nothing Then
                    DataAdapter.Dispose()
                    DataAdapter = Nothing
                End If
                If Not Command Is Nothing Then
                    Command.Dispose()
                    Command = Nothing
                End If
                If Not Connection Is Nothing Then
                    Connection.Close()
                    Connection.Dispose()
                    Connection = Nothing
                End If
            End If

            ' TODO: free shared unmanaged resources
        End If
        Me.disposedValue = True
    End Sub

    Public Sub New(ByVal ConString As String)
        'Build the SQL connection string and initialize the Connection object

        Connection = New SqlConnection(ConString)
    End Sub


#Region " IDisposable Support "
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
    Public Sub OpenConnection()
        Try
            Connection.Open()

        Catch SQLExceptionErr As SqlException
            Throw New System.Exception(SQLExceptionErr.Message, _
                SQLExceptionErr.InnerException)
        Catch InvalidOperationExceptionErr As InvalidOperationException
            Throw New System.Exception(InvalidOperationExceptionErr.Message, _
                InvalidOperationExceptionErr.InnerException)
        End Try
    End Sub

    Public Sub CloseConnection()
        Connection.Close()
    End Sub

    Public Sub InitializeCommand()
        If Command Is Nothing Then
            Try
                Command = New SqlCommand(SQL, Connection)
                'See if this is a stored procedure
                If Not SQL.ToUpper.StartsWith("SELECT ") _
                    And Not SQL.ToUpper.StartsWith("INSERT ") _
                    And Not SQL.ToUpper.StartsWith("UPDATE ") _
                    And Not SQL.ToUpper.StartsWith("DELETE ") Then
                    Command.CommandType = CommandType.StoredProcedure
                End If
            Catch SQLExceptionErr As SqlException
                Throw New System.Exception(SQLExceptionErr.Message, _
                    SQLExceptionErr.InnerException)
            End Try
        End If
    End Sub

    Public Sub AddParameter(ByVal Name As String, ByVal Type As SqlDbType, _
        ByVal Size As Integer, ByVal Value As Object)

        Try
            Command.Parameters.Add(Name, Type, Size).Value = Value
        Catch SQLExceptionErr As SqlException
            Throw New System.Exception(SQLExceptionErr.Message, _
                SQLExceptionErr.InnerException)
        End Try
    End Sub

    Public Sub InitializeDataAdapter()
        Try
            DataAdapter = New SqlDataAdapter
            DataAdapter.SelectCommand = Command
        Catch SQLExceptionErr As SqlException
            Throw New System.Exception(SQLExceptionErr.Message, _
            SQLExceptionErr.InnerException)
        End Try
    End Sub

    Public Sub FillDataSet(ByRef oDataSet As DataSet, ByVal TableName As String)
        Try
            InitializeCommand()
            InitializeDataAdapter()
            DataAdapter.Fill(oDataSet, TableName)
        Catch SQLExceptionErr As SqlException
            Throw New System.Exception(SQLExceptionErr.Message, _
                SQLExceptionErr.InnerException)
        Finally
            Command.Dispose()
            Command = Nothing
            DataAdapter.Dispose()
            DataAdapter = Nothing
        End Try
    End Sub

    Public Sub FillDataTable(ByRef oDataTable As DataTable)
        Try
            InitializeCommand()
            InitializeDataAdapter()
            DataAdapter.Fill(oDataTable)
        Catch SQLExceptionErr As SqlException
            Throw New System.Exception(SQLExceptionErr.Message, _
                SQLExceptionErr.InnerException)
        Finally
            Command.Dispose()
            Command = Nothing
            DataAdapter.Dispose()
            DataAdapter = Nothing
        End Try
    End Sub

    Public Function ExecuteStoredProcedure() As Integer
        Try
            OpenConnection()
            'ExecuteStoredProcedure = Command.ExecuteNonQuery()
            ExecuteStoredProcedure = Command.ExecuteNonQuery()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        Finally
            CloseConnection()
        End Try
    End Function


End Class

Public Class DALNom
    Inherits DALBase1
#Region "Constructor And Destructor"
    Sub New(ByVal ConString As String)
        MyBase.New(ConString)
    End Sub

    Public Shadows Sub Dispose()
        MyBase.Dispose()
    End Sub
#End Region

    Public Function GetNominaBonosporID(ByVal Section_Id As Integer) As DataSet
        Try
            GetNominaBonosporID = New DataSet
            MyBase.SQL = "usp_SelNominaBonosporID"
            'MyBase.SQL = "Select * from tbl_Depto where Section_ID=@Section_ID"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@Nomina_ID", SqlDbType.Int, 16, Section_Id)
            'Fill the DataSet
            MyBase.FillDataSet(GetNominaBonosporID, "NominaBonos")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function


End Class


Public Class Conexion
    Implements IDisposable
    Private objDALNomina As DALNom
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
    Public Sub New(ByVal Constring As String)
9:      objDALNomina = New DALNom(Constring)
    End Sub
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALNomina.Dispose()
            objDALNomina = Nothing
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

    Public Function GetNominaBonosporId(ByVal Section_ID As Integer) As DataSet
        Try
            'Call the data component to get a specific group
            GetNominaBonosporId = objDALNomina.GetNominaBonosporID(Section_ID)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
End Class
Public Class Class2

    Private objDataSet As Data.DataSet
    Private objDataSet1 As Data.DataSet
    Private objPatientDataSet As DataSet
    Private objNomina As Conexion
    Private objNominaDet As BCL.BCLNominaBonos
    Private objMicrosip As BCL.BCLMicrosip
    Private objCorrige As BCL.BCLCorrige
    Private objCipSis As BCL.BCLVentas
    Private objPerSis As BCL.BCLPerSis
    Private objNomDet As BCL.BCLNominaDet
    Private objPuesto As BCL.BCLPuesto
    Private objDepto As BCL.BCLSection
    Private objComision As BCL.BCLComision
    Private objBonoDes As BCL.BCLBonoDes
    Private objPrima As BCL.BCLPremios
    Private objFestivo As BCL.BCLDFestivos

    Private Sub CalculaBonoMensual(ByVal Nom_Id As Integer, ByVal Fecha As DateTime)
        Dim Emp_ID As String
        Dim Vta_ID As String
        Dim Num_ID As String
        Dim Suc As String
        Dim Puesto As Integer

        Dim VtaSuc As Double
        Dim VtaEmp As Double
        Dim DevSuc As Double
        Dim DevEmp As Double
        Dim VtaTot As Double
        Dim DevTot As Double
        Dim StrCnn = "Data Source=" & My.Settings.Server.Trim & _
                                       ";Initial Catalog=" & My.Settings.database.Trim & _
                                       ";Persist Security Info=True;" & _
                                       "User ID=bonos;Password=bonos"


        Using objNomina As New Conexion(StrCnn) 'New BCL.BCLNominaBonos(G_ConString)
            Try
                'Get the specific project selected in the ListView control
                objDataSet = objNomina.GetNominaBonosporId(Nom_Id)

                Dim prodView As DataView = New DataView(objDataSet.Tables(0), "", _
                    "Sucursal, [Vta ID]", DataViewRowState.CurrentRows)

                'Generar Calculo para cada empleado de la nomina de bonos
                For Each theRow As DataRow In prodView.Table.Rows

                    Emp_ID = IIf(IsDBNull(theRow.Item("Emp ID").ToString.Trim), "", theRow.Item("Emp ID").ToString.Trim)
                    Vta_ID = IIf(IsDBNull(theRow.Item("Vta ID").ToString.Trim), "", theRow.Item("Vta ID").ToString.Trim)
                    Num_ID = IIf(IsDBNull(theRow.Item("Num ID").ToString.Trim), "", theRow.Item("Num ID").ToString.Trim)
                    Suc = IIf(IsDBNull(theRow.Item("Sucursal").ToString.Trim), "", theRow.Item("Sucursal").ToString.Trim)
                    Puesto = IIf(theRow.Item("Puesto ID").ToString.Trim = "", 0, theRow.Item("Puesto ID").ToString.Trim)
                    If Puesto = 0 Then
                        MsgBox("El empleado " & Emp_ID & " no tiene un puesto asignado", MsgBoxStyle.Exclamation, "Corregir Puesto")
                        Exit Sub

                    End If
                    'Generar Calculos Diarios (tbl_nomina_det)
                    'CalcBonoDiario(NOm_Id, Sucursal, Emp_ID, Vta_ID, FechaIni, FechaFin)
                    'Obtiene Ventas y Devoluciones del Dia
                    VtaSuc = DevSuc = VtaTot = VtaEmp = DevEmp = DevTot = 0

                    If Suc <> "" Then
                        Using objCipSis As New BCLVta(G_ConStringCipSis)
                            Try
                                objDataSet = objCipSis.ObtenVentasporSucursal(Fecha, Fecha, Trim(Suc))
                                VtaSuc = Val(objDataSet.Tables(0).Rows(0).Item("impvta").ToString)

                                objDataSet = objCipSis.ObtenDevolucionesporSucursal(Fecha, Fecha, Trim(Suc))
                                DevSuc = Val(objDataSet.Tables(0).Rows(0).Item("impdev").ToString)

                                objDataSet = objCipSis.ObtenVentas(Fecha, Fecha)
                                VtaTot = Val(objDataSet.Tables(0).Rows(0).Item("impvta").ToString)

                                objDataSet = objCipSis.ObtenVentasporVendedor(Fecha, Fecha, Trim(Vta_ID))
                                VtaEmp = Val(objDataSet.Tables(0).Rows(0).Item("impvta").ToString)

                                objDataSet = objCipSis.ObtenDevolucionesporVendedor(Fecha, Fecha, Trim(Vta_ID))
                                DevEmp = Val(objDataSet.Tables(0).Rows(0).Item("impdev").ToString)

                                objDataSet = objCipSis.ObtenDevoluciones(Fecha, Fecha)
                                DevTot = Val(objDataSet.Tables(0).Rows(0).Item("impdev").ToString)

                            Catch ExceptionErr As Exception
                                MessageBox.Show(ExceptionErr.Message.ToString)
                            End Try
                        End Using

                    End If
                Next


            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub
End Class
