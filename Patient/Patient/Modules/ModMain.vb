

Imports System.Data
Imports System.Data.SqlClient

Module ModMain
    

    Sub Main()
        If CheckDatabaseConnection() = True Then
            ' ''Dim f1 As New SplashScreen1
            ' ''f1.ShowDialog()
            ' ''f1.Dispose()

            Dim facceso As New frmLogin
            If facceso.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                facceso.Close()
                facceso.Dispose()
                BitacoraMain.ShowDialog()
                BitacoraMain.Dispose()
            End If

        Else
            MessageBox.Show("No es posible conectarse a la Base de Datos! ", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If


    End Sub

    'Sub Main2()
    '    Dim idchecador As Integer
    '    Dim Direccion_IP As String
    '    Dim Puerto As Integer
    '    Dim dwEnrollNumber As Integer
    '    Dim dwVerifyMode As Integer
    '    Dim dwInOutMode As Integer
    '    Dim timeStr As String
    '    Dim bconn As Boolean
    '    Dim icount As Integer
    '    Dim ireg As Integer
    '    Dim CZKEM1 As New zkemkeeper.CZKEM


    '    DataSet1 = New DataSet
    '    Connection = New SqlConnection("Data Source=10.10.1.1;Initial Catalog=bonos;Persist Security Info=True;User ID=bonos;Password=bonos")
    '    SQLSelect = "SELECT idchecador, direccion_ip, puerto, descripcion FROM tbl_checador ORDER BY idchecador"
    '    SQLInsert = "usp_registroshuella"
    '    If Command Is Nothing Then
    '        Try
    '            Command = New SqlCommand(SQLSelect, Connection)
    '            DataAdapter = New SqlDataAdapter
    '            DataAdapter.SelectCommand = Command
    '            DataAdapter.Fill(DataSet1, "relojes")

    '        Catch SQLExceptionErr As SqlException
    '            Throw New System.Exception(SQLExceptionErr.Message, _
    '                SQLExceptionErr.InnerException)
    '        End Try
    '    End If

    '    For Each theRow As DataRow In DataSet1.Tables(0).Rows
    '        idchecador = theRow.Item("idchecador").ToString.Trim
    '        Direccion_IP = theRow.Item("direccion_ip").ToString.Trim
    '        Puerto = theRow.Item("puerto").ToString.Trim

    '        bconn = CZKEM1.Connect_Net(Direccion_IP, Puerto)
    '        If bconn Then
    '            If CZKEM1.ReadGeneralLogData(1) Then
    '                While CZKEM1.GetGeneralLogDataStr(1, dwEnrollNumber, dwVerifyMode, dwInOutMode, timeStr)
    '                    ireg = ireg + 1
    '                    If InsCommand Is Nothing Then
    '                        Try
    '                            InsCommand = New SqlCommand(SQLInsert, Connection)
    '                            InsCommand.CommandType = CommandType.StoredProcedure
    '                            InsCommand.Parameters.Add("@idchecador", SqlDbType.Int, 16).Value = idchecador
    '                            InsCommand.Parameters.Add("@Fecha", SqlDbType.NChar, 10).Value = Mid(timeStr, 1, 10)
    '                            InsCommand.Parameters.Add("@Emp_ID", SqlDbType.NChar, 10).Value = Format(dwEnrollNumber, "0000")
    '                            InsCommand.Parameters.Add("@Registro", SqlDbType.NChar, 10).Value = Mid(timeStr, 12)

    '                            Connection.Open()
    '                            InsCommand.ExecuteNonQuery()
    '                            icount = icount + 1
    '                            InsCommand.Dispose()
    '                            InsCommand = Nothing
    '                            Connection.Close()

    '                        Catch SQLExceptionErr As SqlException
    '                            'Throw New System.Exception(SQLExceptionErr.Message, SQLExceptionErr.InnerException)
    '                            Connection.Close()
    '                            CZKEM1.Disconnect()

    '                            Throw New Exception("Falló Lectura de Reloj " & _
    '                                                theRow.Item("descripcion ") & _
    '                                                SQLExceptionErr.Message)
    '                        Finally

    '                        End Try
    '                    End If

    '                End While
    '            End If
    '        End If
    '        'se insertó el mismo numero de registros que se leyeron
    '        If ireg > 0 And ireg = icount Then
    '            CZKEM1.ClearData(1, 1)
    '        End If
    '        CZKEM1.Disconnect()
    '    Next

    '    Connection.Close()
    '    Connection.Dispose()

    'End Sub

    Function CheckDatabaseConnection() As Boolean

        Try

            ' ''G_ConString = New String(My.Settings.ConnectionStringBonos)
            GLB_ConStringMicrosip = New String(My.Settings.ConnectionStringMicrosip)
            Glb_ConStringCipSis = New String(My.Settings.ConnectionStringCipsis)
            GLB_ConStringPerSis = New String(My.Settings.ConnectionStringPerSis)
            GLB_ConStringNomSis = New String(My.Settings.ConnectionStringNomSis)
            GLB_ConStringDWH = New String(My.Settings.ConnectionStringDwh)
            GLB_ConStringCrvSis = New String(My.Settings.ConnectionStringCrvSis)
            GLB_ConStringCredito = New String(My.Settings.ConnectionStringCredito)
            ' ''Glb_ConStringPerSis = New String(My.Settings.ConnectionStringPerSis)

            '' ''ObjCon = New SqlConnection(G_ConString)

            '' ObjCon.Open()

            '' QUITAR POR MIENTRAS mreyes   16/11/2015  10:00 a.m.
            '' GLB_ConStringNomSisSQL = New String(My.Settings.ConnectionStringNomsisSql)

            GLB_ConStringSirCoSQL = New String(My.Settings.ConnectionStringSirCoSql)
            GLB_ConStringDwhSQL = New String(My.Settings.ConnectionStringDwhSql)
            GLB_ConStringCreditoSQL = New String(My.Settings.ConnectionStringCreditoSql)

            GLB_ConStringSirCoAppSQL = New String(My.Settings.ConnectionStringAPPSql)
            GLB_ConStringSircoControlSQL = New String(My.Settings.ConnectionStringControlSql)
            GLB_ConStringSirCoVentaEnLineaSQL = New String(My.Settings.ConnectionStringVentaEnLineaSql)

            GLB_ConStringNominaSQL = New String(My.Settings.ConnectionStringNominaSql)
            GLB_ConStringSirCoPVSQL = New String(My.Settings.ConnectionStringPVSql)

            GLB_ConStringSirCoTEMPSQL = New String(My.Settings.ConnectionStringTEMPSql)
            CheckDatabaseConnection = True
        Catch ex As Exception
            CheckDatabaseConnection = False
        End Try
    End Function
End Module
