Imports System.Data.Odbc
'mreyes 26/Febrero/2012 10:21 a.m.

Public Class DALBitacora
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



   

    Public Function usp_PpalBitacora(ByVal Accion As Integer, ByVal Opcion As Integer, ByVal Sucursal As String, ByVal OrdeComIni As String, ByVal OrdeComFin As String, ByVal Marca As String, _
                                           ByVal Modelo As String, ByVal EstiloF As String, ByVal IdDivision As String, ByVal IdDepto As String, ByVal IdFamilia As String, ByVal IdLinea As String, _
                                        ByVal IdL1 As String, ByVal IdL2 As String, ByVal IdL3 As String, ByVal IdL4 As String, ByVal IdL5 As String, _
                                        ByVal IdL6 As String, ByVal Proveedor As String, ByVal Status As String, _
                                           ByVal FechaIni As String, ByVal Fechafin As String, ByVal EntregaIni As String, ByVal EntregaFin As String) As DataSet
        'mreyes 26/Febrero/2012 10:27 p.m.


        Try
            usp_PpalBitacora = New DataSet
            MyBase.SQL = "CALL usp_PpalBitacora(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"


            MyBase.InitializeCommand()
            MyBase.AddParameter("@accion", OdbcType.Int, 16, Accion)
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@OrdeComIniB", OdbcType.Char, 6, OrdeComIni)
            MyBase.AddParameter("@OrdeComFinB", OdbcType.Char, 6, OrdeComFin)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@ModeloB", OdbcType.Char, 7, Modelo)
            MyBase.AddParameter("@EstiloFB", OdbcType.Char, 14, EstiloF)
            MyBase.AddParameter("@idDivisionb", OdbcType.Char, 30, IdDivision)
            MyBase.AddParameter("@idDeptob", OdbcType.Char, 30, IdDepto)
            MyBase.AddParameter("@FamiliaB", OdbcType.Char, 30, IdFamilia)
            MyBase.AddParameter("@idLineaB", OdbcType.Char, 30, IdLinea)
            MyBase.AddParameter("@idL1B", OdbcType.Char, 30, IdL1)
            MyBase.AddParameter("@idL2B", OdbcType.Char, 30, IdL2)
            MyBase.AddParameter("@idL3B", OdbcType.Char, 30, IdL3)
            MyBase.AddParameter("@idL4B", OdbcType.Char, 30, IdL4)
            MyBase.AddParameter("@idL5B", OdbcType.Char, 30, IdL5)
            MyBase.AddParameter("@idL6B", OdbcType.Char, 30, IdL6)
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@StatusB", OdbcType.Char, 2, Status)
            MyBase.AddParameter("@FechaIniB", OdbcType.Date, 8, FechaIni)
            MyBase.AddParameter("@FechaFinB", OdbcType.Date, 8, Fechafin)
            MyBase.AddParameter("@EntregaIni", OdbcType.Date, 8, EntregaIni)
            MyBase.AddParameter("@EntregaFin", OdbcType.Date, 8, EntregaFin)


            MyBase.FillDataSet(usp_PpalBitacora, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function



    Public Function usp_PpalBitacoraRecibida(ByVal Accion As Integer, ByVal Opcion As Integer, ByVal Sucursal As String, ByVal OrdeComIni As String, ByVal OrdeComFin As String, ByVal Marca As String, _
                                    ByVal Modelo As String, ByVal EstiloF As String, ByVal IdDivision As Integer, ByVal IdDepto As Integer, ByVal IdFamilia As Integer, ByVal IdLinea As Integer, _
                                    ByVal IdL1 As Integer, ByVal IdL2 As Integer, ByVal IdL3 As Integer, ByVal IdL4 As Integer, ByVal IdL5 As Integer, _
                                    ByVal IdL6 As Integer, ByVal Proveedor As String, ByVal Status As String, _
                                    ByVal FechaIni As String, ByVal Fechafin As String, ByVal EntregaIni As String, ByVal EntregaFin As String) As DataSet
        'mreyes 13/Abril/2012 07:03 a.m.


        Try
            usp_PpalBitacoraRecibida = New DataSet
            MyBase.SQL = "CALL usp_PpalBitacoraRecibida(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"


            MyBase.InitializeCommand()
            MyBase.AddParameter("@accion", OdbcType.Int, 16, Accion)
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@OrdeComIniB", OdbcType.Char, 6, OrdeComIni)
            MyBase.AddParameter("@OrdeComFinB", OdbcType.Char, 6, OrdeComFin)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@ModeloB", OdbcType.Char, 7, Modelo)
            MyBase.AddParameter("@EstiloFB", OdbcType.Char, 14, EstiloF)
            MyBase.AddParameter("@idDivisionb", OdbcType.Int, 16, IdDivision)
            MyBase.AddParameter("@idDeptob", OdbcType.Int, 16, IdDepto)
            MyBase.AddParameter("@FamiliaB", OdbcType.Int, 16, IdFamilia)
            MyBase.AddParameter("@idLineaB", OdbcType.Int, 16, IdLinea)
            MyBase.AddParameter("@idL1B", OdbcType.Int, 16, IdL1)
            MyBase.AddParameter("@idL2B", OdbcType.Int, 16, IdL2)
            MyBase.AddParameter("@idL3B", OdbcType.Int, 16, IdL3)
            MyBase.AddParameter("@idL4B", OdbcType.Int, 16, IdL4)
            MyBase.AddParameter("@idL5B", OdbcType.Int, 16, IdL5)
            MyBase.AddParameter("@idL6B", OdbcType.Int, 16, IdL6)
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@StatusB", OdbcType.Char, 2, Status)
            MyBase.AddParameter("@FechaIniB", OdbcType.Char, 10, FechaIni)
            MyBase.AddParameter("@FechaFinB", OdbcType.Char, 10, Fechafin)
            MyBase.AddParameter("@EntregaIni", OdbcType.Char, 10, EntregaIni)
            MyBase.AddParameter("@EntregaFin", OdbcType.Char, 10, EntregaFin)


            MyBase.FillDataSet(usp_PpalBitacoraRecibida, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalSeguimientos(ByVal Sucursal As String, ByVal OrdeComIni As String, ByVal OrdeComFin As String, ByVal Marca As String, _
                                    ByVal Estilon As String, ByVal EstiloF As String, _
                                    ByVal Proveedor As String, _
                                    ByVal FechaIni As String, ByVal Fechafin As String) As DataSet
        'mreyes 07/Marzo/2012 10:32 a.m.


        Try
            usp_PpalSeguimientos = New DataSet
            MyBase.SQL = "CALL usp_PpalSeguimientos(?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@OrdeComIniB", OdbcType.Char, 6, OrdeComIni)
            MyBase.AddParameter("@OrdeComFinB", OdbcType.Char, 6, OrdeComFin)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@EstiloFB", OdbcType.Char, 14, EstiloF)
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)

            MyBase.AddParameter("@FechaIniB", OdbcType.Char, 10, FechaIni)
            MyBase.AddParameter("@FechaFinB", OdbcType.Char, 10, Fechafin)
            

            MyBase.FillDataSet(usp_PpalSeguimientos, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Captura_SegBit(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            'mreyes 29/Febrero/2012 10:54 a.m.
            MyBase.SQL = "CALL usp_Captura_SegBit(?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@sucursal", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("sucursal"))
            MyBase.AddParameter("@ordecomp", OdbcType.Char, 6, Section.Tables(0).Rows(0).Item("ordecomp"))
            MyBase.AddParameter("@marca", OdbcType.Char, 6, Section.Tables(0).Rows(0).Item("marca"))
            MyBase.AddParameter("@estilon", OdbcType.Char, 7, Section.Tables(0).Rows(0).Item("estilon"))
            MyBase.AddParameter("@fecha", OdbcType.Date, 8, Section.Tables(0).Rows(0).Item("fecha"))
            MyBase.AddParameter("@atiende", OdbcType.Char, 100, Section.Tables(0).Rows(0).Item("atiende"))
            MyBase.AddParameter("@realiza", OdbcType.Char, 100, Section.Tables(0).Rows(0).Item("realiza"))
            MyBase.AddParameter("@motivo", OdbcType.Char, 100, Section.Tables(0).Rows(0).Item("motivo"))
            MyBase.AddParameter("@comentarios", OdbcType.Char, 150, Section.Tables(0).Rows(0).Item("comentarios"))


            usp_Captura_SegBit = ExecuteStoredProcedure()

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerSegBit(ByVal Id_SegBit As Integer, ByVal OrdeComp As String, ByVal Marca As String, ByVal Estilon As String) As DataSet
        'mreyes 29/Febrero/2012 07:27 p.m.
        Try
            usp_TraerSegBit = New DataSet
            MyBase.SQL = "CALL usp_TraerSegBit(?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Id_SegBit", OdbcType.Int, 16, Id_SegBit)
            MyBase.AddParameter("@OrdeComp", OdbcType.Char, 6, OrdeComp)
            MyBase.AddParameter("@Marca", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@Estilon", OdbcType.Char, 7, Estilon)

            MyBase.FillDataSet(usp_TraerSegBit, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerFechaEntrega(ByVal Sucursal As String, ByVal OrdeComp As String) As DataSet
        'mreyes 07/Marzo/2012 12:30 p.m.
        Try
            usp_TraerFechaEntrega = New DataSet
            MyBase.SQL = "CALL usp_TraerFechaEntrega(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@sucursal", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@OrdeComp", OdbcType.Char, 6, OrdeComp)

            MyBase.FillDataSet(usp_TraerFechaEntrega, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerEstiloF(ByVal Marca As String, ByVal EstiloF As String) As DataSet
        'mreyes 07/Marzo/2012 01:07 p.m.
        Try
            usp_TraerEstiloF = New DataSet
            MyBase.SQL = "CALL usp_TraerEstiloF(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Marca", OdbcType.Char, 2, Marca)
            MyBase.AddParameter("@EstiloF", OdbcType.Char, 14, EstiloF)

            MyBase.FillDataSet(usp_TraerEstiloF, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
