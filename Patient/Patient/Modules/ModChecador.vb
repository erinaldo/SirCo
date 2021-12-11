Module ModChecador
    'mreyes 01/Junio/2012 06:44 p.m.

    Public Function LeeRelojes(ByVal SucursalCh) As Boolean
        Try
            LeeRelojes = False
            Dim iRegRead As Integer
            Dim iRegIns As Integer
            Dim CZKEM1 As zkemkeeper.CZKEM
            Dim objDataSet = New DataSet




            Using objReloj As New BCL.BCLChecador(GLB_ConStringNomSis)
                Try
                    CZKEM1 = New zkemkeeper.CZKEM()
                    objDataSet = objReloj.usp_TraerChecador(0, SucursalCh)
                Catch ExceptionErr As Exception
                    'SaveLog(DateTime.Now.ToString & " Error: " & SQLExceptionErr.Message & " ...", My.Settings.StrPathLogReloj)
                    MessageBox.Show(ExceptionErr.Message.ToString)
                    Exit Function
                End Try

                For Each theRow As DataRow In objDataSet.Tables(0).Rows

                    Dim Sucursal As String = theRow.Item("sucursal").ToString.Trim
                    Dim Reloj As String = pub_TraerNomSucursal(Sucursal)
                    Dim idchecador As Integer = theRow.Item("idchecador").ToString.Trim
                    Dim Direccion_IP As String = theRow.Item("ip").ToString.Trim
                    Dim Puerto As Integer = theRow.Item("puerto").ToString.Trim
                    ' SaveLog(DateTime.Now.ToString & " ***Conectando al Reloj " & Reloj & ", " & Direccion_IP & " ...", My.Settings.StrPathLogReloj)
                    'SaveLog(DateTime.Now.ToString & " ESPERE UN POCO...", My.Settings.StrPathLogReloj)

                    Dim bconn As Boolean = CZKEM1.Connect_Net(Direccion_IP, Puerto)
                    If bconn Then
                        iRegRead = 0
                        iRegIns = 0
                        'Read attendance records and write them into the internal buffer of the PC
                        If CZKEM1.ReadGeneralLogData(1) Then
                            Dim dwEnrollNumber As Integer
                            Dim dwVerifyMode As Integer
                            Dim dwInOutMode As Integer
                            Dim timeStr As String
                            Dim Hora As DateTime
                            Dim HoraAnt As DateTime
                            Dim Dif As Integer
                            While CZKEM1.GetGeneralLogDataStr(1, dwEnrollNumber, dwVerifyMode, dwInOutMode, timeStr)
                                iRegRead = iRegRead + 1

                                Hora = Format(CDate(Mid(timeStr, 12)), "1900-01-01 HH:mm:ss")
                                ' buscar una checada continua
                                'If Mid(timeStr, 1, 10) = "2012-06-08" And dwEnrollNumber = 10 Then
                                '    MsgBox("parar")
                                'End If
                                Using objRegistro As New BCL.BCLChecador(GLB_ConStringNomSis)
                                    Try
                                        objDataSet = objRegistro.usp_TraerChecada(Format(dwEnrollNumber, "0000"), Mid(timeStr, 1, 10))
                                        'If objDataSet.Tables(0).Rows.Count > 0 Then
                                        '    HoraAnt = Format(CDate(objDataSet.Tables(0).Rows(objDataSet.Tables(0).Rows.Count - 1).Item("hora").ToString), "1900-01-01 HH:mm:ss")
                                        '    If Hora < HoraAnt Then
                                        '        Dif = 0
                                        '    Else
                                        '        Dif = System.Math.Abs(DateDiff(DateInterval.Minute, Hora, HoraAnt))
                                        '    End If
                                        'Else
                                        '    Dif = 16
                                        'End If
                                        If objDataSet.Tables(0).Rows.Count > 0 Then
                                            For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                                                HoraAnt = Format(CDate(objDataSet.Tables(0).Rows(i).Item("hora").ToString), "1900-01-01 HH:mm:ss")
                                                Dif = System.Math.Abs(DateDiff(DateInterval.Minute, Hora, HoraAnt))
                                                If Dif >= -15 And Dif <= 15 Then
                                                    Dif = 0
                                                    Exit For
                                                Else
                                                    Dif = 16
                                                End If
                                            Next
                                        Else
                                            Dif = 16
                                        End If


                                    Catch ExceptionErr As Exception
                                        CZKEM1.Disconnect()
                                        'SaveLog(DateTime.Now.ToString & "*Falló Lectura Reloj " & Reloj & " ***...", My.Settings.StrPathLogReloj)
                                        MessageBox.Show(ExceptionErr.Message.ToString)
                                        Exit Function
                                    End Try
                                End Using


                                If Dif > 15 Then

                                    Using objRegistro As New BCL.BCLChecador(GLB_ConStringNomSis)
                                        Try

                                            If dwEnrollNumber <> 77777 Then
                                                objRegistro.usp_Captura_Checada(1, idchecador, Mid(timeStr, 1, 10), Mid(timeStr, 12), Format(dwEnrollNumber, "0000"))
                                                iRegIns = iRegIns + 1
                                            End If

                                        Catch ExceptionErr As Exception
                                            CZKEM1.Disconnect()
                                            'SaveLog(DateTime.Now.ToString & "*Falló Lectura Reloj " & Reloj & " ***...", My.Settings.StrPathLogReloj)
                                            MessageBox.Show(ExceptionErr.Message.ToString)
                                            Exit Function
                                        End Try
                                    End Using
                                End If
                            End While
                        Else
                            'SaveLog(DateTime.Now.ToString & " No se encontraron registros en reloj " & Reloj & " ...", My.Settings.StrPathLogReloj)
                            MsgBox("No se encontraron registros en reloj")
                        End If
                    Else
                        'SaveLog(DateTime.Now.ToString & " Error al Conectarse a reloj " & Reloj & " " & Direccion_IP & " ...", My.Settings.StrPathLogReloj)

                        MsgBox("No se puede conectar al reloj.. " & Direccion_IP)
                    End If
                    'se insertó el mismo numero de registros que se leyeron

                    CZKEM1.Disconnect()

                    ' SaveLog(DateTime.Now.ToString & " Desconexión de Reloj " & Reloj & " ...", My.Settings.StrPathLogReloj)
                    'SaveLog(DateTime.Now.ToString & " ", My.Settings.StrPathLogReloj)
                Next
            End Using

            LeeRelojes = True
        Catch ExceptionErr As Exception

            'SaveLog(DateTime.Now.ToString & "*Falló Lectura Reloj " & Reloj & " ***...", My.Settings.StrPathLogReloj)
            MessageBox.Show(ExceptionErr.Message.ToString)
            Exit Function
        End Try
    End Function

End Module
