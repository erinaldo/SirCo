Imports System.Data.Odbc
'mreyes 10/Febrero/2012 11:51 a.m.

Public Class DALFacturas
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

    Public Function usp_PpalArchivoFactoraje(ByVal Opcion As Integer, ByVal FactNueva As Integer, ByVal Sucursal As String, ByVal FactIni As String, ByVal FactFin As String, ByVal Marca As String, _
                                           ByVal Proveedor As String, ByVal Status As String, _
                                           ByVal FechaIni As String, ByVal Fechafin As String, ByVal VenceIni As String, ByVal VenceFin As String, _
                                           ByVal FechaRecIni As String, ByVal FechaRecFin As String, ByVal FechaPagoIni As String, ByVal FechaPagoFin As String, ByVal FactProvIni As String, _
                                           ByVal FactProvFin As String, ByVal IdFolioIni As String, ByVal IdFolioFin As String, ByVal Tipo As String) As DataSet

        'mreyes 15/Marzo/2012 04:26 p.m.

        Try
            usp_PpalArchivoFactoraje = New DataSet
            MyBase.SQL = "CALL usp_PpalArchivoFactoraje(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@FactNueva", OdbcType.Int, 16, FactNueva)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@FactIniB", OdbcType.Char, 10, FactIni)
            MyBase.AddParameter("@FactFinB", OdbcType.Char, 10, FactFin)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)


            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)

            MyBase.AddParameter("@StatusB", OdbcType.Char, 2, Status)
            MyBase.AddParameter("@FechaIniB", OdbcType.Date, 8, FechaIni)
            MyBase.AddParameter("@FechaFinB", OdbcType.Date, 8, Fechafin)
            MyBase.AddParameter("@VenceIniB", OdbcType.Date, 8, VenceIni)
            MyBase.AddParameter("@VenceFinB", OdbcType.Date, 8, VenceFin)
            MyBase.AddParameter("@FechaRecIniB", OdbcType.Date, 8, FechaRecIni)
            MyBase.AddParameter("@FechaRecFinB", OdbcType.Date, 8, FechaRecFin)
            MyBase.AddParameter("@FechaPagIniB", OdbcType.Date, 8, FechaPagoIni)
            MyBase.AddParameter("@FechaPagFinB", OdbcType.Date, 8, FechaPagoFin)
            MyBase.AddParameter("@FactProvIniB", OdbcType.Char, 10, FactProvIni)
            MyBase.AddParameter("@FactProvFinB", OdbcType.Char, 10, FactProvFin)

            MyBase.AddParameter("@IdFolioIni", OdbcType.Char, 10, IdFolioIni)
            MyBase.AddParameter("@IdFolioFin", OdbcType.Char, 10, IdFolioFin)
            MyBase.AddParameter("@tipo", OdbcType.Char, 1, Tipo)


            MyBase.FillDataSet(usp_PpalArchivoFactoraje, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalCancelaFactoraje(ByVal Opcion As Integer, ByVal FactNueva As Integer, ByVal Sucursal As String, ByVal FactIni As String, ByVal FactFin As String, ByVal Marca As String, _
                                          ByVal Proveedor As String, ByVal Status As String, _
                                          ByVal FechaIni As String, ByVal Fechafin As String, ByVal VenceIni As String, ByVal VenceFin As String, _
                                          ByVal FechaRecIni As String, ByVal FechaRecFin As String, ByVal FechaPagoIni As String, ByVal FechaPagoFin As String, ByVal FactProvIni As String, _
                                          ByVal FactProvFin As String, ByVal IdFolioIni As String, ByVal IdFolioFin As String, ByVal Tipo As String) As DataSet

        'mreyes 15/Marzo/2012 04:26 p.m.

        Try
            usp_PpalCancelaFactoraje = New DataSet
            MyBase.SQL = "CALL usp_PpalCancelaFactoraje(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@FactNueva", OdbcType.Int, 16, FactNueva)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@FactIniB", OdbcType.Char, 10, FactIni)
            MyBase.AddParameter("@FactFinB", OdbcType.Char, 10, FactFin)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)


            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)

            MyBase.AddParameter("@StatusB", OdbcType.Char, 2, Status)
            MyBase.AddParameter("@FechaIniB", OdbcType.Date, 8, FechaIni)
            MyBase.AddParameter("@FechaFinB", OdbcType.Date, 8, Fechafin)
            MyBase.AddParameter("@VenceIniB", OdbcType.Date, 8, VenceIni)
            MyBase.AddParameter("@VenceFinB", OdbcType.Date, 8, VenceFin)
            MyBase.AddParameter("@FechaRecIniB", OdbcType.Date, 8, FechaRecIni)
            MyBase.AddParameter("@FechaRecFinB", OdbcType.Date, 8, FechaRecFin)
            MyBase.AddParameter("@FechaPagIniB", OdbcType.Date, 8, FechaPagoIni)
            MyBase.AddParameter("@FechaPagFinB", OdbcType.Date, 8, FechaPagoFin)
            MyBase.AddParameter("@FactProvIniB", OdbcType.Char, 10, FactProvIni)
            MyBase.AddParameter("@FactProvFinB", OdbcType.Char, 10, FactProvFin)

            MyBase.AddParameter("@IdFolioIni", OdbcType.Char, 10, IdFolioIni)
            MyBase.AddParameter("@IdFolioFin", OdbcType.Char, 10, IdFolioFin)
            MyBase.AddParameter("@tipo", OdbcType.Char, 1, Tipo)


            MyBase.FillDataSet(usp_PpalCancelaFactoraje, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalFacturas(ByVal Opcion As Integer, ByVal FactNueva As Integer, ByVal Sucursal As String, ByVal FactIni As String, ByVal FactFin As String, ByVal Marca As String, _
                                            ByVal Proveedor As String, ByVal Status As String, _
                                            ByVal FechaIni As String, ByVal Fechafin As String, ByVal VenceIni As String, ByVal VenceFin As String, _
                                            ByVal FechaRecIni As String, ByVal FechaRecFin As String, ByVal FechaPagoIni As String, ByVal FechaPagoFin As String, ByVal FactProvIni As String, _
                                            ByVal FactProvFin As String, ByVal IdFolioIni As String, ByVal IdFolioFin As String, ByVal Tipo As String) As DataSet

        'mreyes 15/Marzo/2012 04:26 p.m.

        Try
            usp_PpalFacturas = New DataSet
            MyBase.SQL = "CALL usp_PpalFacturas(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@FactNueva", OdbcType.Int, 16, FactNueva)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@FactIniB", OdbcType.Char, 10, FactIni)
            MyBase.AddParameter("@FactFinB", OdbcType.Char, 10, FactFin)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)


            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)

            MyBase.AddParameter("@StatusB", OdbcType.Char, 2, Status)
            MyBase.AddParameter("@FechaIniB", OdbcType.Date, 8, FechaIni)
            MyBase.AddParameter("@FechaFinB", OdbcType.Date, 8, Fechafin)
            MyBase.AddParameter("@VenceIniB", OdbcType.Date, 8, VenceIni)
            MyBase.AddParameter("@VenceFinB", OdbcType.Date, 8, VenceFin)
            MyBase.AddParameter("@FechaRecIniB", OdbcType.Date, 8, FechaRecIni)
            MyBase.AddParameter("@FechaRecFinB", OdbcType.Date, 8, FechaRecFin)
            MyBase.AddParameter("@FechaPagIniB", OdbcType.Date, 8, FechaPagoIni)
            MyBase.AddParameter("@FechaPagFinB", OdbcType.Date, 8, FechaPagoFin)
            MyBase.AddParameter("@FactProvIniB", OdbcType.Char, 10, FactProvIni)
            MyBase.AddParameter("@FactProvFinB", OdbcType.Char, 10, FactProvFin)

            MyBase.AddParameter("@IdFolioIni", OdbcType.Char, 10, IdFolioIni)
            MyBase.AddParameter("@IdFolioFin", OdbcType.Char, 10, IdFolioFin)
            MyBase.AddParameter("@tipo", OdbcType.Char, 1, Tipo)


            MyBase.FillDataSet(usp_PpalFacturas, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalFacturasDIFERIDOS(ByVal Opcion As Integer, ByVal FactNueva As Integer, ByVal Sucursal As String, ByVal FactIni As String, ByVal FactFin As String, ByVal Marca As String, _
                                        ByVal Proveedor As String, ByVal Status As String, _
                                        ByVal FechaIni As String, ByVal Fechafin As String, ByVal VenceIni As String, ByVal VenceFin As String, _
                                        ByVal FechaRecIni As String, ByVal FechaRecFin As String, ByVal FechaPagoIni As String, ByVal FechaPagoFin As String, ByVal FactProvIni As String, _
                                        ByVal FactProvFin As String, ByVal IdFolioIni As String, ByVal IdFolioFin As String, ByVal Tipo As String) As DataSet

        'mreyes 15/Marzo/2012 04:26 p.m.

        Try
            usp_PpalFacturasDIFERIDOS = New DataSet
            MyBase.SQL = "CALL usp_PpalFacturasDIFERIDOS(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@FactNueva", OdbcType.Int, 16, FactNueva)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@FactIniB", OdbcType.Char, 10, FactIni)
            MyBase.AddParameter("@FactFinB", OdbcType.Char, 10, FactFin)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)


            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)

            MyBase.AddParameter("@StatusB", OdbcType.Char, 2, Status)
            MyBase.AddParameter("@FechaIniB", OdbcType.Date, 8, FechaIni)
            MyBase.AddParameter("@FechaFinB", OdbcType.Date, 8, Fechafin)
            MyBase.AddParameter("@VenceIniB", OdbcType.Date, 8, VenceIni)
            MyBase.AddParameter("@VenceFinB", OdbcType.Date, 8, VenceFin)
            MyBase.AddParameter("@FechaRecIniB", OdbcType.Date, 8, FechaRecIni)
            MyBase.AddParameter("@FechaRecFinB", OdbcType.Date, 8, FechaRecFin)
            MyBase.AddParameter("@FechaPagIniB", OdbcType.Date, 8, FechaPagoIni)
            MyBase.AddParameter("@FechaPagFinB", OdbcType.Date, 8, FechaPagoFin)
            MyBase.AddParameter("@FactProvIniB", OdbcType.Char, 10, FactProvIni)
            MyBase.AddParameter("@FactProvFinB", OdbcType.Char, 10, FactProvFin)

            MyBase.AddParameter("@IdFolioIni", OdbcType.Char, 10, IdFolioIni)
            MyBase.AddParameter("@IdFolioFin", OdbcType.Char, 10, IdFolioFin)
            MyBase.AddParameter("@tipo", OdbcType.Char, 1, Tipo)


            MyBase.FillDataSet(usp_PpalFacturasDIFERIDOS, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalFacturas554(ByVal Opcion As Integer, ByVal FactNueva As Integer, ByVal Sucursal As String, ByVal FactIni As String, ByVal FactFin As String, ByVal Marca As String, _
                                        ByVal Proveedor As String, ByVal Status As String, _
                                        ByVal FechaIni As String, ByVal Fechafin As String, ByVal VenceIni As String, ByVal VenceFin As String, _
                                        ByVal FechaRecIni As String, ByVal FechaRecFin As String, ByVal FechaPagoIni As String, ByVal FechaPagoFin As String, ByVal FactProvIni As String, _
                                        ByVal FactProvFin As String, ByVal IdFolioIni As String, ByVal IdFolioFin As String, ByVal Tipo As String) As DataSet

        'mreyes 15/Marzo/2012 04:26 p.m.

        Try
            usp_PpalFacturas554 = New DataSet
            MyBase.SQL = "CALL usp_PpalFacturas554(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@FactNueva", OdbcType.Int, 16, FactNueva)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@FactIniB", OdbcType.Char, 10, FactIni)
            MyBase.AddParameter("@FactFinB", OdbcType.Char, 10, FactFin)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)


            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)

            MyBase.AddParameter("@StatusB", OdbcType.Char, 2, Status)
            MyBase.AddParameter("@FechaIniB", OdbcType.Date, 8, FechaIni)
            MyBase.AddParameter("@FechaFinB", OdbcType.Date, 8, Fechafin)
            MyBase.AddParameter("@VenceIniB", OdbcType.Date, 8, VenceIni)
            MyBase.AddParameter("@VenceFinB", OdbcType.Date, 8, VenceFin)
            MyBase.AddParameter("@FechaRecIniB", OdbcType.Date, 8, FechaRecIni)
            MyBase.AddParameter("@FechaRecFinB", OdbcType.Date, 8, FechaRecFin)
            MyBase.AddParameter("@FechaPagIniB", OdbcType.Date, 8, FechaPagoIni)
            MyBase.AddParameter("@FechaPagFinB", OdbcType.Date, 8, FechaPagoFin)
            MyBase.AddParameter("@FactProvIniB", OdbcType.Char, 10, FactProvIni)
            MyBase.AddParameter("@FactProvFinB", OdbcType.Char, 10, FactProvFin)

            MyBase.AddParameter("@IdFolioIni", OdbcType.Char, 10, IdFolioIni)
            MyBase.AddParameter("@IdFolioFin", OdbcType.Char, 10, IdFolioFin)
            MyBase.AddParameter("@tipo", OdbcType.Char, 1, Tipo)


            MyBase.FillDataSet(usp_PpalFacturas554, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalFacturasPendPago(ByVal Opcion As Integer, ByVal FactNueva As Integer, ByVal Sucursal As String, ByVal FactIni As String, ByVal FactFin As String, ByVal Marca As String, _
                                         ByVal Proveedor As String, ByVal Status As String, _
                                         ByVal FechaIni As String, ByVal Fechafin As String, ByVal VenceIni As String, ByVal VenceFin As String, _
                                         ByVal FechaRecIni As String, ByVal FechaRecFin As String, ByVal FechaPagoIni As String, ByVal FechaPagoFin As String, ByVal FactProvIni As String, _
                                         ByVal FactProvFin As String, ByVal IdFolioIni As String, ByVal IdFolioFin As String, ByVal Tipo As String) As DataSet

        'mreyes 11/Agosto/2015  06:27 p.m.

        Try
            usp_PpalFacturasPendPago = New DataSet
            MyBase.SQL = "CALL usp_PpalFacturasPendPago(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@FactNueva", OdbcType.Int, 16, FactNueva)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@FactIniB", OdbcType.Char, 10, FactIni)
            MyBase.AddParameter("@FactFinB", OdbcType.Char, 10, FactFin)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)


            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)

            MyBase.AddParameter("@StatusB", OdbcType.Char, 2, Status)
            MyBase.AddParameter("@FechaIniB", OdbcType.Date, 8, FechaIni)
            MyBase.AddParameter("@FechaFinB", OdbcType.Date, 8, Fechafin)
            MyBase.AddParameter("@VenceIniB", OdbcType.Date, 8, VenceIni)
            MyBase.AddParameter("@VenceFinB", OdbcType.Date, 8, VenceFin)
            MyBase.AddParameter("@FechaRecIniB", OdbcType.Date, 8, FechaRecIni)
            MyBase.AddParameter("@FechaRecFinB", OdbcType.Date, 8, FechaRecFin)
            MyBase.AddParameter("@FechaPagIniB", OdbcType.Date, 8, FechaPagoIni)
            MyBase.AddParameter("@FechaPagFinB", OdbcType.Date, 8, FechaPagoFin)
            MyBase.AddParameter("@FactProvIniB", OdbcType.Char, 10, FactProvIni)
            MyBase.AddParameter("@FactProvFinB", OdbcType.Char, 10, FactProvFin)

            MyBase.AddParameter("@IdFolioIni", OdbcType.Char, 10, IdFolioIni)
            MyBase.AddParameter("@IdFolioFin", OdbcType.Char, 10, IdFolioFin)
            MyBase.AddParameter("@tipo", OdbcType.Char, 1, Tipo)


            MyBase.FillDataSet(usp_PpalFacturasPendPago, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalFacturasINI(ByVal Opcion As Integer, ByVal FactNueva As Integer, ByVal Sucursal As String, ByVal FactIni As String, ByVal FactFin As String, ByVal Marca As String, _
                                            ByVal Proveedor As String, ByVal Status As String, _
                                            ByVal FechaIni As String, ByVal Fechafin As String, ByVal VenceIni As String, ByVal VenceFin As String, _
                                            ByVal FechaRecIni As String, ByVal FechaRecFin As String, ByVal FechaPagoIni As String, ByVal FechaPagoFin As String, ByVal FactProvIni As String, _
                                            ByVal FactProvFin As String, ByVal IdFolioIni As String, ByVal IdFolioFin As String, ByVal Tipo As String) As DataSet

        'mreyes 15/Marzo/2012 04:26 p.m.

        Try
            usp_PpalFacturasINI = New DataSet
            MyBase.SQL = "CALL usp_PpalFacturasINI(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@FactNueva", OdbcType.Int, 16, FactNueva)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@FactIniB", OdbcType.Char, 10, FactIni)
            MyBase.AddParameter("@FactFinB", OdbcType.Char, 10, FactFin)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)


            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)

            MyBase.AddParameter("@StatusB", OdbcType.Char, 2, Status)
            MyBase.AddParameter("@FechaIniB", OdbcType.Date, 8, FechaIni)
            MyBase.AddParameter("@FechaFinB", OdbcType.Date, 8, Fechafin)
            MyBase.AddParameter("@VenceIniB", OdbcType.Date, 8, VenceIni)
            MyBase.AddParameter("@VenceFinB", OdbcType.Date, 8, VenceFin)
            MyBase.AddParameter("@FechaRecIniB", OdbcType.Date, 8, FechaRecIni)
            MyBase.AddParameter("@FechaRecFinB", OdbcType.Date, 8, FechaRecFin)
            MyBase.AddParameter("@FechaPagIniB", OdbcType.Date, 8, FechaPagoIni)
            MyBase.AddParameter("@FechaPagFinB", OdbcType.Date, 8, FechaPagoFin)
            MyBase.AddParameter("@FactProvIniB", OdbcType.Char, 10, FactProvIni)
            MyBase.AddParameter("@FactProvFinB", OdbcType.Char, 10, FactProvFin)

            MyBase.AddParameter("@IdFolioIni", OdbcType.Char, 10, IdFolioIni)
            MyBase.AddParameter("@IdFolioFin", OdbcType.Char, 10, IdFolioFin)
            MyBase.AddParameter("@tipo", OdbcType.Char, 1, Tipo)


            MyBase.FillDataSet(usp_PpalFacturasINI, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function



    Public Function usp_PpalFacturasINIPagoUnico(ByVal Opcion As Integer, ByVal FactNueva As Integer, ByVal Sucursal As String, ByVal FactIni As String, ByVal FactFin As String, ByVal Marca As String, _
                                           ByVal Proveedor As String, ByVal Status As String, _
                                           ByVal FechaIni As String, ByVal Fechafin As String, ByVal VenceIni As String, ByVal VenceFin As String, _
                                           ByVal FechaRecIni As String, ByVal FechaRecFin As String, ByVal FechaPagoIni As String, ByVal FechaPagoFin As String, ByVal FactProvIni As String, _
                                           ByVal FactProvFin As String, ByVal IdFolioIni As String, ByVal IdFolioFin As String, ByVal Tipo As String) As DataSet

        'mreyes 09/Diciembre/2014   10:18 a.m.

        Try
            usp_PpalFacturasINIPagoUnico = New DataSet
            MyBase.SQL = "CALL usp_PpalFacturasINIPagoUnico(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@FactNueva", OdbcType.Int, 16, FactNueva)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@FactIniB", OdbcType.Char, 10, FactIni)
            MyBase.AddParameter("@FactFinB", OdbcType.Char, 10, FactFin)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)


            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)

            MyBase.AddParameter("@StatusB", OdbcType.Char, 2, Status)
            MyBase.AddParameter("@FechaIniB", OdbcType.Date, 8, FechaIni)
            MyBase.AddParameter("@FechaFinB", OdbcType.Date, 8, Fechafin)
            MyBase.AddParameter("@VenceIniB", OdbcType.Date, 8, VenceIni)
            MyBase.AddParameter("@VenceFinB", OdbcType.Date, 8, VenceFin)
            MyBase.AddParameter("@FechaRecIniB", OdbcType.Date, 8, FechaRecIni)
            MyBase.AddParameter("@FechaRecFinB", OdbcType.Date, 8, FechaRecFin)
            MyBase.AddParameter("@FechaPagIniB", OdbcType.Date, 8, FechaPagoIni)
            MyBase.AddParameter("@FechaPagFinB", OdbcType.Date, 8, FechaPagoFin)
            MyBase.AddParameter("@FactProvIniB", OdbcType.Char, 10, FactProvIni)
            MyBase.AddParameter("@FactProvFinB", OdbcType.Char, 10, FactProvFin)

            MyBase.AddParameter("@IdFolioIni", OdbcType.Char, 10, IdFolioIni)
            MyBase.AddParameter("@IdFolioFin", OdbcType.Char, 10, IdFolioFin)
            MyBase.AddParameter("@tipo", OdbcType.Char, 1, Tipo)



            MyBase.FillDataSet(usp_PpalFacturasINIPagoUnico, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalFacturasAFACTORAJE(ByVal Opcion As Integer, ByVal FactNueva As Integer, ByVal Sucursal As String, ByVal FactIni As String, ByVal FactFin As String, ByVal Marca As String, _
                                            ByVal Proveedor As String, ByVal Status As String, _
                                            ByVal FechaIni As String, ByVal Fechafin As String, ByVal VenceIni As String, ByVal VenceFin As String, _
                                            ByVal FechaRecIni As String, ByVal FechaRecFin As String, ByVal FechaPagoIni As String, ByVal FechaPagoFin As String, ByVal FactProvIni As String, _
                                            ByVal FactProvFin As String, ByVal IdFolioIni As String, ByVal IdFolioFin As String, ByVal Tipo As String) As DataSet

        'mreyes 07/Noviembre/2014   12:46 p.m.

        Try
            usp_PpalFacturasAFACTORAJE = New DataSet
            MyBase.SQL = "CALL usp_PpalFacturasAFACTORAJE(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@FactNueva", OdbcType.Int, 16, FactNueva)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@FactIniB", OdbcType.Char, 10, FactIni)
            MyBase.AddParameter("@FactFinB", OdbcType.Char, 10, FactFin)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)


            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)

            MyBase.AddParameter("@StatusB", OdbcType.Char, 2, Status)
            MyBase.AddParameter("@FechaIniB", OdbcType.Date, 8, FechaIni)
            MyBase.AddParameter("@FechaFinB", OdbcType.Date, 8, Fechafin)
            MyBase.AddParameter("@VenceIniB", OdbcType.Date, 8, VenceIni)
            MyBase.AddParameter("@VenceFinB", OdbcType.Date, 8, VenceFin)
            MyBase.AddParameter("@FechaRecIniB", OdbcType.Date, 8, FechaRecIni)
            MyBase.AddParameter("@FechaRecFinB", OdbcType.Date, 8, FechaRecFin)
            MyBase.AddParameter("@FechaPagIniB", OdbcType.Date, 8, FechaPagoIni)
            MyBase.AddParameter("@FechaPagFinB", OdbcType.Date, 8, FechaPagoFin)
            MyBase.AddParameter("@FactProvIniB", OdbcType.Char, 10, FactProvIni)
            MyBase.AddParameter("@FactProvFinB", OdbcType.Char, 10, FactProvFin)

            MyBase.AddParameter("@IdFolioIni", OdbcType.Char, 10, IdFolioIni)
            MyBase.AddParameter("@IdFolioFin", OdbcType.Char, 10, IdFolioFin)
            MyBase.AddParameter("@tipo", OdbcType.Char, 1, Tipo)


            MyBase.FillDataSet(usp_PpalFacturasAFACTORAJE, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalFacturasDet(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal Marca As String, _
                                           ByVal Proveedor As String, _
                                                   ByVal FechaRecIni As String, ByVal FechaRecFin As String) As DataSet

        'mreyes 06/Diciembre/2013 10:19 a.m.

        Try
            usp_PpalFacturasDet = New DataSet
            MyBase.SQL = "CALL usp_PpalFacturasDet(?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@FechaRecIniB", OdbcType.Date, 8, FechaRecIni)
            MyBase.AddParameter("@FechaRecFinB", OdbcType.Date, 8, FechaRecFin)
            
            MyBase.FillDataSet(usp_PpalFacturasDet, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizarFacturas(ByVal Proveedor As String, ByVal Referenc As String, ByVal Fecha As Date, ByVal FecVencB As Date) As Boolean
        'mreyes 23/Abril/2013 09:50 a.m.
        Try
            MyBase.SQL = "CALL usp_ActualizarFacturas(?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@ReferencB", OdbcType.Char, 10, Referenc)
            MyBase.AddParameter("@FechaB", OdbcType.Date, 8, Fecha)
            MyBase.AddParameter("@FecVencB", OdbcType.Date, 8, FecVencB)

            'Execute the stored procedure
            usp_ActualizarFacturas = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try


    End Function

    Public Function usp_GeneraDet_FPP(ByVal Proveedor As String, ByVal IdFolioB As Integer) As Boolean
        'mreyes 23/Abril/2013 09:50 a.m.
        Try
            MyBase.SQL = "CALL usp_GeneraDet_FPP(?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@idfoliob", OdbcType.Int, 8, IdFolioB)
            

            'Execute the stored procedure
            usp_GeneraDet_FPP = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try


    End Function
    Public Function usp_Captura_FactProv(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            'mreyes 22/Mayo/2012 04:29 p.m.
            MyBase.SQL = "CALL usp_Captura_FactProv(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@sucursal", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("sucursal"))
            MyBase.AddParameter("@factprov", OdbcType.Char, 6, Section.Tables(0).Rows(0).Item("factprov"))
            MyBase.AddParameter("@idfolio", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idfolio"))
            MyBase.AddParameter("@status", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("status"))
            MyBase.AddParameter("@fecha", OdbcType.Date, 8, Section.Tables(0).Rows(0).Item("fecha"))
            MyBase.AddParameter("@hora", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("hora"))
            MyBase.AddParameter("@marca", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("marca"))
            MyBase.AddParameter("@proveedor", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("proveedor"))
            MyBase.AddParameter("@fecreci", OdbcType.Date, 8, Section.Tables(0).Rows(0).Item("fecreci"))
            MyBase.AddParameter("@fecvenc", OdbcType.Date, 8, Section.Tables(0).Rows(0).Item("fecvenc"))
            MyBase.AddParameter("@referenc", OdbcType.Char, 10, Section.Tables(0).Rows(0).Item("referenc"))
            MyBase.AddParameter("@gastos", OdbcType.Double, 10, Section.Tables(0).Rows(0).Item("gastos"))
            MyBase.AddParameter("@descuento", OdbcType.Double, 10, Section.Tables(0).Rows(0).Item("descuento"))
            MyBase.AddParameter("@observa", OdbcType.Char, 60, Section.Tables(0).Rows(0).Item("observa"))
            MyBase.AddParameter("@usuario", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("usuario"))

            MyBase.AddParameter("@dsctopp", OdbcType.Double, 10, Section.Tables(0).Rows(0).Item("dsctopp"))
            MyBase.AddParameter("@diaspp", OdbcType.SmallInt, 3, Section.Tables(0).Rows(0).Item("diaspp"))
            MyBase.AddParameter("@dscto01", OdbcType.Double, 10, Section.Tables(0).Rows(0).Item("dscto01"))
            MyBase.AddParameter("@dscto02", OdbcType.Double, 10, Section.Tables(0).Rows(0).Item("dscto02"))
            MyBase.AddParameter("@dscto03", OdbcType.Double, 10, Section.Tables(0).Rows(0).Item("dscto03"))
            MyBase.AddParameter("@dscto04", OdbcType.Double, 10, Section.Tables(0).Rows(0).Item("dscto04"))
            MyBase.AddParameter("@dscto05", OdbcType.Double, 10, Section.Tables(0).Rows(0).Item("dscto05"))
            MyBase.AddParameter("@iva", OdbcType.SmallInt, 3, Section.Tables(0).Rows(0).Item("iva"))

            MyBase.AddParameter("@subtotal", OdbcType.Double, 10, Section.Tables(0).Rows(0).Item("subtotal"))
            MyBase.AddParameter("@impuesto", OdbcType.Double, 10, Section.Tables(0).Rows(0).Item("impuesto"))
            MyBase.AddParameter("@total", OdbcType.Double, 10, Section.Tables(0).Rows(0).Item("total"))
            MyBase.AddParameter("@apagar", OdbcType.Double, 10, Section.Tables(0).Rows(0).Item("apagar"))
            MyBase.AddParameter("@pares", OdbcType.Int, 8, Section.Tables(0).Rows(0).Item("pares"))
            MyBase.AddParameter("@idusuario", OdbcType.Int, 8, Section.Tables(0).Rows(0).Item("idusuario"))
            MyBase.AddParameter("@idusuariomodif", OdbcType.Int, 8, Section.Tables(0).Rows(0).Item("idusuariomodif"))
            MyBase.AddParameter("@idusuariocancela", OdbcType.Int, 8, Section.Tables(0).Rows(0).Item("idusuariocancela"))

            MyBase.AddParameter("@entregavence", OdbcType.Date, 8, Section.Tables(0).Rows(0).Item("entregavence"))

            MyBase.AddParameter("@improcedenteb", OdbcType.Double, 10, Section.Tables(0).Rows(0).Item("improcedente"))

            usp_Captura_FactProv = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Captura_DevoProv(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            'mreyes 12/Junio/2013 04:30 p.m.
            MyBase.SQL = "CALL usp_Captura_DevoProv(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@sucursal", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("sucursal"))
            MyBase.AddParameter("@devoprov", OdbcType.Char, 6, Section.Tables(0).Rows(0).Item("devoprov"))
            MyBase.AddParameter("@idfolio", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idfolio"))
            MyBase.AddParameter("@status", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("status"))
            MyBase.AddParameter("@fecha", OdbcType.Date, 8, Section.Tables(0).Rows(0).Item("fecha"))
            MyBase.AddParameter("@hora", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("hora"))
            MyBase.AddParameter("@marca", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("marca"))
            MyBase.AddParameter("@proveedor", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("proveedor"))
            MyBase.AddParameter("@referenc", OdbcType.Char, 10, Section.Tables(0).Rows(0).Item("referenc"))
            MyBase.AddParameter("@gastos", OdbcType.Double, 10, Section.Tables(0).Rows(0).Item("gastos"))
            MyBase.AddParameter("@sucurfpr", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("sucurfpr"))
            MyBase.AddParameter("@factprov", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("factprov"))
            MyBase.AddParameter("@observa", OdbcType.Char, 60, Section.Tables(0).Rows(0).Item("observa"))
            MyBase.AddParameter("@usuario", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("usuario"))
            MyBase.AddParameter("@iva", OdbcType.SmallInt, 3, Section.Tables(0).Rows(0).Item("iva"))

            usp_Captura_DevoProv = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_Det_fp(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            'mreyes 22/Mayo/2012 05:22 p.m.
            MyBase.SQL = "CALL usp_Captura_Det_fp(?,?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add the Parameters to the Parameters collection
            'User_Name Text 15

            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@sucursal", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("sucursal"))
            MyBase.AddParameter("@factprov", OdbcType.Char, 6, Section.Tables(0).Rows(0).Item("factprov"))
            MyBase.AddParameter("@marca", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("marca"))
            MyBase.AddParameter("@estilon", OdbcType.Char, 7, Section.Tables(0).Rows(0).Item("estilon"))
            MyBase.AddParameter("@corrida", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("corrida"))
            MyBase.AddParameter("@medida", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("medida"))
            MyBase.AddParameter("@serie", OdbcType.Char, 13, Section.Tables(0).Rows(0).Item("serie"))
            MyBase.AddParameter("@ctd", OdbcType.SmallInt, 3, Section.Tables(0).Rows(0).Item("ctd"))
            MyBase.AddParameter("@costo", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("costo"))
            MyBase.AddParameter("@costdesc", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("costdesc"))
            MyBase.AddParameter("@precio", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("precio"))
            MyBase.AddParameter("@sucurorcb", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("sucurorc"))
            MyBase.AddParameter("@ordecomp", OdbcType.Char, 6, Section.Tables(0).Rows(0).Item("ordecomp"))

            usp_Captura_Det_fp = ExecuteStoredProcedure()

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Captura_PedidoTemp(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            'mreyes 25/Marzo/2014   10:36 a.m.

            MyBase.SQL = "CALL usp_Captura_PedidoTemp(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add the Parameters to the Parameters collection
            'User_Name Text 15

            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@sucursal", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("sucursal"))
            MyBase.AddParameter("@ordecomp", OdbcType.Char, 6, Section.Tables(0).Rows(0).Item("ordecomp"))
            MyBase.AddParameter("@estatus", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("estatus"))
            MyBase.AddParameter("@fecha", OdbcType.Date, 8, Section.Tables(0).Rows(0).Item("fecha"))
            MyBase.AddParameter("@marca", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("marca"))
            MyBase.AddParameter("@proveedor", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("proveedor"))
            MyBase.AddParameter("@ta", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("ta"))
            MyBase.AddParameter("@fam", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("fam"))
            MyBase.AddParameter("@lin", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("lin"))

            MyBase.AddParameter("@cat", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("cat"))
            MyBase.AddParameter("@estilofabrica", OdbcType.Char, 14, Section.Tables(0).Rows(0).Item("estilofabrica"))
            MyBase.AddParameter("@estilonuestro", OdbcType.Char, 7, Section.Tables(0).Rows(0).Item("estilonuestro"))
            MyBase.AddParameter("@descripcion", OdbcType.Char, 70, Section.Tables(0).Rows(0).Item("descripcion"))
            MyBase.AddParameter("@c", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("c"))
            MyBase.AddParameter("@i", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("i"))
            MyBase.AddParameter("@de", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("de"))
            MyBase.AddParameter("@a", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("a"))
            MyBase.AddParameter("@pcomp", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("pcomp"))
            MyBase.AddParameter("@costo", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("costo"))

            MyBase.AddParameter("@precio", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("precio"))
            MyBase.AddParameter("@porc", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("porc"))
            MyBase.AddParameter("@csuc", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("csuc"))
            MyBase.AddParameter("@sucdescrip", OdbcType.Char, 45, Section.Tables(0).Rows(0).Item("sucdescrip"))
            MyBase.AddParameter("@prs", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("prs"))
            MyBase.AddParameter("@m1", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m1"))
            MyBase.AddParameter("@m1_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m1_"))
            MyBase.AddParameter("@m2", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m2"))
            MyBase.AddParameter("@m2_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m2_"))

            MyBase.AddParameter("@m3", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m3"))
            MyBase.AddParameter("@m3_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m3_"))

            MyBase.AddParameter("@m4", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m4"))
            MyBase.AddParameter("@m4_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m4_"))

            MyBase.AddParameter("@m5", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m5"))
            MyBase.AddParameter("@m5_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m5_"))

            MyBase.AddParameter("@m6", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m6"))
            MyBase.AddParameter("@m6_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m6_"))

            MyBase.AddParameter("@m7", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m7"))
            MyBase.AddParameter("@m7_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m7_"))

            MyBase.AddParameter("@m8", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m8"))
            MyBase.AddParameter("@m8_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m8_"))

            MyBase.AddParameter("@m9", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m9"))
            MyBase.AddParameter("@m9_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m9_"))

            MyBase.AddParameter("@m10", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m10"))
            MyBase.AddParameter("@m10_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m10_"))


            MyBase.AddParameter("@m11", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m11"))
            MyBase.AddParameter("@m11_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m11_"))

            MyBase.AddParameter("@m12", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m12"))
            MyBase.AddParameter("@m12_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m12_"))


            MyBase.AddParameter("@m13", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m13"))
            MyBase.AddParameter("@m13_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m13_"))


            MyBase.AddParameter("@m14", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m14"))
            MyBase.AddParameter("@m14_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m14_"))


            MyBase.AddParameter("@m15", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m15"))
            MyBase.AddParameter("@m15_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m15_"))


            MyBase.AddParameter("@m16", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m16"))
            MyBase.AddParameter("@m16_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m16_"))


            MyBase.AddParameter("@m17", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m17"))
            MyBase.AddParameter("@m17_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m17_"))


            MyBase.AddParameter("@m18", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m18"))
            MyBase.AddParameter("@m18_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m18_"))


            MyBase.AddParameter("@m19", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m19"))
            MyBase.AddParameter("@m19_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m19_"))


            MyBase.AddParameter("@m20", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m20"))
            MyBase.AddParameter("@m20_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m20_"))


            MyBase.AddParameter("@m21", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m21"))
            MyBase.AddParameter("@m21_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m21_"))


            MyBase.AddParameter("@m22", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m22"))
            MyBase.AddParameter("@m22_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m22_"))

            MyBase.AddParameter("@m23", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m23"))
            MyBase.AddParameter("@m23_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m23_"))

            MyBase.AddParameter("@m24", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m24"))
            MyBase.AddParameter("@m24_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m24_"))

            MyBase.AddParameter("@m25", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m25"))
            MyBase.AddParameter("@m25_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m25_"))

            MyBase.AddParameter("@m26", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m26"))
            MyBase.AddParameter("@m26_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m26_"))

            MyBase.AddParameter("@m27", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m27"))
            MyBase.AddParameter("@m27_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m27_"))

            MyBase.AddParameter("@m28", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m28"))
            MyBase.AddParameter("@m28_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m28_"))

            MyBase.AddParameter("@m29", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m29"))
            MyBase.AddParameter("@m29_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m29_"))

            MyBase.AddParameter("@m30", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m30"))
            MyBase.AddParameter("@m30_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m30_"))

            MyBase.AddParameter("@m31", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m31"))
            MyBase.AddParameter("@m31_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m31_"))

            MyBase.AddParameter("@m32", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m32"))
            MyBase.AddParameter("@m32_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m32_"))

            MyBase.AddParameter("@m33", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m33"))
            MyBase.AddParameter("@m33_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m33_"))

            MyBase.AddParameter("@m34", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m34"))
            MyBase.AddParameter("@m34_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m34_"))

            MyBase.AddParameter("@m35", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m35"))
            MyBase.AddParameter("@m35_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m35_"))

            MyBase.AddParameter("@m36", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m36"))
            MyBase.AddParameter("@m36_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m36_"))

            MyBase.AddParameter("@m37", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m37"))
            MyBase.AddParameter("@m37_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m37_"))

            MyBase.AddParameter("@m38", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m38"))
            MyBase.AddParameter("@m38_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m38_"))

            MyBase.AddParameter("@m39", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m39"))
            MyBase.AddParameter("@m39_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m39_"))

            MyBase.AddParameter("@m40", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m40"))
            MyBase.AddParameter("@m40_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m40_"))

            MyBase.AddParameter("@m41", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m41"))
            MyBase.AddParameter("@m41_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m41_"))

            MyBase.AddParameter("@m42", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m42"))
            MyBase.AddParameter("@m42_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m42_"))

            MyBase.AddParameter("@m43", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m43"))
            MyBase.AddParameter("@m43_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m43_"))

            MyBase.AddParameter("@m44", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m44"))
            MyBase.AddParameter("@m44_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m44_"))

            MyBase.AddParameter("@m45", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m45"))
            MyBase.AddParameter("@m45_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m45_"))

            MyBase.AddParameter("@m46", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m46"))
            MyBase.AddParameter("@m46_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m46_"))

            MyBase.AddParameter("@m47", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m47"))
            MyBase.AddParameter("@m47_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m47_"))

            MyBase.AddParameter("@m48", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m48"))
            MyBase.AddParameter("@m48_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m48_"))

            MyBase.AddParameter("@m49", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m49"))
            MyBase.AddParameter("@m49_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m49_"))

            MyBase.AddParameter("@m50", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m50"))
            MyBase.AddParameter("@m50_", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("m50_"))

            MyBase.AddParameter("@importe", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("importe"))

            MyBase.AddParameter("@fechaentrega", OdbcType.Date, 8, Section.Tables(0).Rows(0).Item("fechaentrega"))
            MyBase.AddParameter("@fechacancela", OdbcType.Date, 8, Section.Tables(0).Rows(0).Item("fechacancela"))

            MyBase.AddParameter("@l1", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("l1"))
            MyBase.AddParameter("@l2", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("l2"))
            MyBase.AddParameter("@l3", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("l3"))
            MyBase.AddParameter("@l4", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("l4"))
            MyBase.AddParameter("@l5", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("l5"))
            MyBase.AddParameter("@l6", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("l6"))
            MyBase.AddParameter("@estructura", OdbcType.Char, 250, Section.Tables(0).Rows(0).Item("estructura"))
            MyBase.AddParameter("@serie", OdbcType.Char, 13, Section.Tables(0).Rows(0).Item("serie"))
            MyBase.AddParameter("@idarticulo", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idarticulo"))




            usp_Captura_PedidoTemp = ExecuteStoredProcedure()

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Captura_Det_Dp(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            'mreyes 22/Mayo/2012 05:22 p.m.
            MyBase.SQL = "CALL usp_Captura_Det_Dp(?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add the Parameters to the Parameters collection
            'User_Name Text 15

            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@sucursal", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("sucursal"))
            MyBase.AddParameter("@devoprov", OdbcType.Char, 6, Section.Tables(0).Rows(0).Item("devoprov"))
            MyBase.AddParameter("@marca", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("marca"))
            MyBase.AddParameter("@estilon", OdbcType.Char, 7, Section.Tables(0).Rows(0).Item("estilon"))
            MyBase.AddParameter("@corrida", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("corrida"))
            MyBase.AddParameter("@medida", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("medida"))
            MyBase.AddParameter("@serie", OdbcType.Char, 13, Section.Tables(0).Rows(0).Item("serie"))
            MyBase.AddParameter("@ctd", OdbcType.SmallInt, 3, Section.Tables(0).Rows(0).Item("ctd"))
            MyBase.AddParameter("@costo", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("costo"))
            MyBase.AddParameter("@costdesc", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("costdesc"))

            usp_Captura_Det_Dp = ExecuteStoredProcedure()

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function




    Public Function usp_Captura_Serie(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            'mreyes 22/Mayo/2012 06:25 p.m.
            MyBase.SQL = "CALL usp_Captura_Serie(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add the Parameters to the Parameters collection
            'User_Name Text 15

            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@serie", OdbcType.Char, 13, Section.Tables(0).Rows(0).Item("serie"))
            MyBase.AddParameter("@sucursal", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("sucursal"))
            MyBase.AddParameter("@status", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("status"))
            MyBase.AddParameter("@marca", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("marca"))
            MyBase.AddParameter("@estilon", OdbcType.Char, 7, Section.Tables(0).Rows(0).Item("estilon"))
            MyBase.AddParameter("@medida", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("medida"))
            MyBase.AddParameter("@sucurdes", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("sucurdes"))
            MyBase.AddParameter("@idfolio", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idfolio"))

            MyBase.AddParameter("@idarticulo", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idarticulo"))
            MyBase.AddParameter("@precioini", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("precioini"))
            MyBase.AddParameter("@costoini", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("costoini"))
            MyBase.AddParameter("@preciovta", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("preciovta"))
            MyBase.AddParameter("@ultcosto", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("ultcosto"))
            MyBase.AddParameter("@proveedors", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("proveedors"))


            usp_Captura_Serie = ExecuteStoredProcedure()

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Captura_FichaRem(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            'Tony Garcia 27/Junio/2013 11:30 a.m.
            MyBase.SQL = "CALL usp_Captura_FichaRem(?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@foliof", OdbcType.Int, 10, Section.Tables(0).Rows(0).Item("foliof"))
            MyBase.AddParameter("@fecha", OdbcType.DateTime, 10, Section.Tables(0).Rows(0).Item("fecha"))
            MyBase.AddParameter("@idfolio", OdbcType.Int, 10, Section.Tables(0).Rows(0).Item("idfolio"))
            MyBase.AddParameter("@idfoliosuc", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("idfoliosuc"))
            MyBase.AddParameter("@importe", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("importe"))
            MyBase.AddParameter("@idusuario", OdbcType.Int, 10, Section.Tables(0).Rows(0).Item("idusuario"))

            usp_Captura_FichaRem = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function




    Public Function usp_Traer_FichaRem(ByVal IdFolioSuc As String, ByVal IdFolio As Integer) As DataSet
        'Tony Garcia 27/Junio/2013 12:10 p.m.
        Try
            usp_Traer_FichaRem = New DataSet
            MyBase.SQL = "CALL usp_Traer_FichaRem(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idfoliosuc", OdbcType.Char, 10, IdFolioSuc)
            MyBase.AddParameter("@idfoliob", OdbcType.Int, 10, IdFolio)

            MyBase.FillDataSet(usp_Traer_FichaRem, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerMotivosRem() As DataSet
        'Tony Garcia 04/Julio/2013 05:10 p.m.
        Try
            usp_TraerMotivosRem = New DataSet
            MyBase.SQL = "CALL usp_TraerMotivosRem()"

            MyBase.InitializeCommand()

            MyBase.FillDataSet(usp_TraerMotivosRem, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaMotivoSB(ByVal IdFolio As Integer, ByVal IdFolioSuc As String, ByVal IdMotivo As Integer, ByVal IdUsuario As Integer) As Boolean
        Try
            'Tony Garcia 06/Julio/2013 11:30 a.m.
            MyBase.SQL = "CALL usp_CapturaMotivoSB(?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()

            'idfoliob int, idfoliosucb char(8), idmotivob int, idusuario int)
            MyBase.AddParameter("@idfoliob", OdbcType.Int, 10, IdFolio)
            MyBase.AddParameter("@idfoliosucb", OdbcType.Char, 8, IdFolioSuc)
            MyBase.AddParameter("@idmotivo", OdbcType.Int, 10, IdMotivo)
            MyBase.AddParameter("@idusuario", OdbcType.Int, 10, IdUsuario)

            usp_CapturaMotivoSB = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerMotivoSB(ByVal IdFolio As Integer, ByVal IdFolioSuc As String) As DataSet
        'Tony Garcia 04/Julio/2013 05:10 p.m.
        Try
            usp_TraerMotivoSB = New DataSet
            MyBase.SQL = "CALL usp_TraerMotivoSB(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idfoliob", OdbcType.Int, 10, IdFolio)
            MyBase.AddParameter("@idfoliosucb", OdbcType.Char, 8, IdFolioSuc)

            MyBase.FillDataSet(usp_TraerMotivoSB, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ImprimirMasUno(ByVal sucursal As String, ByVal referenc As String) As DataSet
        'Roberto
        Try
            usp_ImprimirMasUno = New DataSet
            MyBase.SQL = "CALL usp_ImprimirMasUno(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@sucursalB", OdbcType.Char, 2, sucursal)
            MyBase.AddParameter("@referencB", OdbcType.Char, 15, referenc)
            'MyBase.AddParameter("@factprovB", OdbcType.Char, 6, referencia)

            MyBase.FillDataSet(usp_ImprimirMasUno, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerUltFolioFichaRem() As DataSet
        Try
            usp_TraerUltFolioFichaRem = New DataSet
            MyBase.SQL = "CALL usp_TraerUltFolioFichaRem()"

            MyBase.InitializeCommand()

            MyBase.FillDataSet(usp_TraerUltFolioFichaRem, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDet_FPP(ByVal Opcion As Integer, ByVal IdFolioB As Integer) As DataSet
        Try
            usp_TraerDet_FPP = New DataSet
            MyBase.SQL = "CALL usp_TraerDet_FPP(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.Int, 8, Opcion)
            MyBase.AddParameter("@idfoliob", OdbcType.Int, 8, IdFolioB)
            MyBase.FillDataSet(usp_TraerDet_FPP, "cipsis")




        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
