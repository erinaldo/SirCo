Imports Microsoft.Win32 ' for registry access
Imports System.Text ' for the StringBuilder
Module CreateDSN
    ' This ODBC function allows you to automatically create a DSN
 
    Private Const ODBC_ADD_DSN = 1 ' Nuevo DSN
    Private Const ODBC_CONFIG_DSN = 2 ' Modificar DSN
    Private Const ODBC_REMOVE_DSN = 3 ' Eliminar DSN
    Private Const ODBC_ADD_SYS_DSN = 4 ' Nuevo DSN de sistema
    Private Const ODBC_CONFIG_SYS_DSN = 5 ' Modificar DSN de sistema
    Private Const ODBC_REMOVE_SYS_DSN = 6 ' Eliminar DSN de sistema
    Private Const vbAPINull As Long = 0 ' Null Pointer
    Private Const SQL_SUCCESS As Long = 0
    Private Const SQL_FETCH_NEXT As Long = 1

    Private Declare Function SQLConfigDataSource Lib "ODBCCP32.DLL" (ByVal hwndParent As Long, ByVal fRequest As Long, ByVal lpszDriver As String, ByVal lpszAttributes As String) As Long
    Private Declare Function SQLDataSources Lib "ODBC32.DLL" (ByVal henv As Long, ByVal fDirection As Integer, ByVal szDSN As String, ByVal cbDSNMax As Integer, ByVal pcbDSN As Integer, ByVal szDescription As String, ByVal cbDescriptionMax As Integer, ByVal pcbDescription As Integer) As Integer
    Private Declare Function SQLAllocEnv Lib "ODBC32.DLL" (ByVal Env As Long) As Integer

    'Constantes
    'ruta hasta el servidor (ip/nombre/ruta)
    Private Const C_Cipsis_Server = "10.10.1.3"
    'usuario
    Private Const C_CipSis_User = "root"
    Private Const C_PerSis_User = "root"
    Private Const C_Microsip_User = "SYSDBA"
    'contraseña
    Private Const C_CipSis_Pass = "prueba"
    Private Const C_PerSis_Pass = "prueba"
    Private Const C_Microsip_Pass = "ztpersonalnom"
    'base de datos
    Private Const C_CipSIS_BD = "cipsis"
    Private Const C_PerSIS_BD = "persis"
    Private Const C_Microsip_BD = "\\10.10.1.1\c:\Microsip datos\ZAPATERIAS TORREON.FDB"

    'puerto
    Private Const C_CipSis_Port = 3308
    Private Const C_PerSis_Port = 3306

    'Nombre ODBC de MySql
    Public Const C_MYSQL_ODBC = "MySQL ODBC 5.1 Driver"
    Public Const C_FireBird_ODBC = "Firebird/InterBase(r) driver"

    'Crea el DSN para las conexiones
    '(utiliza las constantes por defecto para conectarse a un servidor MySql)
    'Si deseas personalizarlo o dinamizarlo deberás utilizar el resto de funciones
    Public Function IniciaDSN(ByVal sDSNname As String) As Boolean
        'Comprobamos si existe
        If ExisteDSN(sDSNname) = True Then
            'Si existe lo eliminamos previamente.
            If BorrarDSN(sDSNname, C_MYSQL_ODBC) = False Then
                IniciaDSN = False
                Exit Function
            End If
        End If

        'Creamos el nuevo DSN.
        IniciaDSN = MySQLCrearDSN_CipSis(sDSNname)
    End Function


    'Crea un DSN del sistema.
    Public Function CrearDSN(ByVal sDSN As String, ByVal sDriver As String, ByVal sAtributos As String, Optional ByVal sHwnd As Long = vbAPINull) As Boolean
        'Creamos el DSN (En vez de vbAPINull, empleamos el hwnd del formulario)
        CrearDSN = CBool(SQLConfigDataSource(sHwnd, ODBC_ADD_SYS_DSN, sDriver, sAtributos))
    End Function


    'Crea un DSN MySQL con los atributos bien seteados.
    Public Function MySQLCrearDSN_CipSis(ByVal sDSN As String, _
     Optional ByVal sServer As String = C_Cipsis_Server, Optional ByVal sBD As String = C_CipSIS_BD, _
     Optional ByVal sUser As String = C_CipSis_User, Optional ByVal sPass As String = C_CipSis_Pass, _
     Optional ByVal sPort As Integer = C_CipSis_Port) As Boolean

        Dim sDriver As String
        Dim sAtributos As String

        sDriver = C_MYSQL_ODBC
        sAtributos = "DSN=" & sDSN & Chr(0)
        sAtributos = sAtributos & "SERVER=" & sServer & Chr(0)

        sAtributos = sAtributos & "PORT=" & sPort & Chr(0)

        sAtributos = sAtributos & "DATABASE=" & sBD & Chr(0)

        sAtributos = sAtributos & "USER=" & sUser & Chr(0)

        sAtributos = sAtributos & "PASSWORD=" & sPass & Chr(0)

        sAtributos = sAtributos & "OPTION=3" & Chr(0)

        'Si queremos resetear la conexión de datos, debemos borrarlo antes
        If ExisteDSN(sDSN) Then
            Call BorrarDSN(sDSN, sDriver)
        End If

        MySQLCrearDSN_CipSis = CrearDSN(sDSN, sDriver, sAtributos)

    End Function


    'Elimina un DSN del sistema.
    Public Function BorrarDSN(ByVal sDSN As String, ByVal sDriver As String, Optional ByVal sHwnd As Long = vbAPINull) As Boolean
        Dim sAtributos As String
        ' Borramos el DSN (En vez de vbAPINull, empleamos el hwnd del formulario)
        If ExisteDSN(sDSN) Then
            sAtributos = "DSN=" & sDSN & Chr(0)
            BorrarDSN = CBool(SQLConfigDataSource(sHwnd, ODBC_REMOVE_SYS_DSN, sDriver, sAtributos))
        Else
            'MsgBox(ExIdioma("ModDSN_Contr1"))
            BorrarDSN = False
        End If
    End Function


    'Comprueba si existe un DSN en el sistema.
    Public Function ExisteDSN(ByVal sDSN As String) As Boolean
        Dim I As Integer, j As Integer
        Dim sDSNItem As String
        Dim sDRVItem As String
        Dim sDSNActual As String
        Dim sDRV As String
        Dim iDSNLen As Integer
        Dim iDRVLen As Integer
        Dim lHenv As Long 'controlador del entorno
        Dim DSNLISTA(100)
        ExisteDSN = False
        For j = 1 To 52
            DSNLISTA(j) = ""
        Next j

        j = 1
        If SQLAllocEnv(lHenv) <> -1 Then
            Do Until I <> SQL_SUCCESS
                sDSNItem = Space(1024)
                sDRVItem = Space(1024)
                I = SQLDataSources(lHenv, SQL_FETCH_NEXT, sDSNItem, 1024, iDSNLen, sDRVItem, 1024, iDRVLen)
                sDSNActual = Left(sDSNItem, iDSNLen)
                sDRV = Left(sDRVItem, iDRVLen)
                If sDSN <> Space(iDSNLen) Then
                    DSNLISTA(j) = sDSN
                    If UCase(sDSN) = UCase(sDSNActual) Then
                        ExisteDSN = True
                        Exit Do
                    End If
                End If
            Loop
        End If
    End Function

    Sub CreateDSN()
        Dim iReturn As Integer ' return code forSQLConfigDataSource
        Dim AttrBuilder As New StringBuilder
        Dim Attr As String ' Attributes to be passed toSQLConfigDataSource
        Dim serverName As String ' SQL Server Machine Name.
        Dim DSNName As String ' DSN Name
        Dim driverName As String ' DB Driver
        Dim databaseName As String ' Database
        Dim description As String ' DSN Description
        ' Set up the variables to be passed to SQLConfigDataSource
        ' In this example, we are setting up a DSN to connect to SQLServer
        serverName = "DevSQL" ' CHANGE THIS VALUE TO THE SERVERNAME
        DSNName = "Sample" ' CHANGE THIS VALUE TO WHAT YOUWANT TO CALL THE DSN
        driverName = "SQL Server"
        databaseName = "Bogus" ' CHANGE THIS VALUE TO THE SQLSERVER DB NAME
        description = "Sample DSN" ' CHANGE THIS VALUE TO THE DSNDESCRIPTION
        AttrBuilder.Append("SERVER=")
        AttrBuilder.Append(serverName)
        AttrBuilder.Append(Chr(0))
        AttrBuilder.Append("DSN=")
        AttrBuilder.Append(DSNName)
        AttrBuilder.Append(Chr(0))
        AttrBuilder.Append("DESCRIPTION=")
        AttrBuilder.Append(description)
        AttrBuilder.Append(Chr(0))
        AttrBuilder.Append("DATABASE=")
        AttrBuilder.Append(databaseName)
        AttrBuilder.Append(Chr(0))
        AttrBuilder.Append("TRUSTED_CONNECTION=NO")
        AttrBuilder.Append(Chr(0))
        Attr = AttrBuilder.ToString
        ' ADD the DSN
        ' If the 2nd parameter = 1, add as a User DSN
        ' If the 2nd parameter = 4, add as a System DSN
        ' Leave the 1st parameter as 0


        iReturn = SQLConfigDataSource(0, 4, driverName, Attr)
        If iReturn <> 1 Then ' ERROR!
            Console.WriteLine("ERROR with creating " & DSNName)
        Else ' Update the registry with the user id - can't pass User IDand Password for creating
            ' a SQL Server DSN, so you have to do it through theregistry
            Dim regKey As RegistryKey, regSubKeySW As RegistryKey
            Dim regSubKeyODBC As RegistryKey, regSubKeyODBCINI As RegistryKey
            Dim regSales As RegistryKey
            regKey = Registry.LocalMachine
            regSubKeySW = regKey.OpenSubKey("SOFTWARE")
            regSubKeyODBC = regSubKeySW.OpenSubKey("ODBC")
            regSubKeyODBCINI = regSubKeyODBC.OpenSubKey("ODBC.INI")
            regSales = regSubKeyODBCINI.OpenSubKey(DSNName, True)
            ' CHANGE THE FOLLOWING LINE'S VALUE TO THE USER ID NEEDEDTO CONNECT TO THE SQL DATA SOURCE
            regSales.SetValue("LastUser", "SampleUser")
            Console.WriteLine(DSNName & " created")
        End If
        Console.WriteLine("Press any key to continue....")
        Console.ReadLine()
    End Sub

End Module
