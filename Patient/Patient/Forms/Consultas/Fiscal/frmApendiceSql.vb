Imports LibPrintTicketMatriz.Class1
Public Class frmApendiceSql
    Private objDataSet As Data.DataSet
    Dim opcion As Integer = 0
    Private Sub frmApendiceSql_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2

        If GLB_CveSucursal = "11" Then
            cb_sucursal.Text = "11"
            cb_sucursal.Enabled = False
            GroupBox1.Enabled = False

        End If
    End Sub
    Private Sub imprimir_Tiquete_Apendice(ByVal suc As String, ByVal fecha As Date)
        Try
            '**********************************
            '// La clase "CreaTicket" tiene varios metodos para imprimir con diferentes formatos (izquierda, derecha, centrado, desripcion precio,etc), a
            '   // continuacion se muestra el metodo con ejemplo de parametro que acepta, longitud maxima y un ejemplo de como imprimira, esta clase esta 
            '   // basada en una impresora Epson de matriz de puntos con impresion maxima de 40 caracteres por renglon
            '   // METODO                                      MAX_LONG                        EJEMPLOS
            '   //--------------------------------------------------------------------------------------------------------------------------
            '   // TextoIzquierda("Empleado 1")                    40                      Empleado 1      
            '   // TextoDerecha("Caja 1")                          40                                                        Caja 1
            '   // TextoCentro("Ticket")                           40                                         Ticket   
            '   // TextoExtremos("Fecha 6/1/2011","Hora:13:25")     18 y 18                 Fecha 6/1/2011                Hora:13:25
            '   // EncabezadoVenta()                                n/a                     Articulo        Can    P.Unit    Importe
            '   // LineasGuion()                                    n/a                     ----------------------------------------
            '   // AgregaArticulo("Aspirina","2",45.25,90.5)        16,3,10,11              Aspirina          2    $45.25     $90.50
            '   // LineasTotales()                                  n/a                                                ----------
            '   // AgregaTotales("Subtotal",235.25)                 25 y 15                Subtotal                         $235.25
            '   // LineasAsterisco()                                n/a                     ****************************************
            '   // LineasIgual()                                    n/a                     ========================================
            '   // CortaTicket()
            '   // AbreCajon()

            'MessageBox.Show(Format(fecha, "dd/MM/yyyy"))

            Dim Cant As String = ""
            Dim Descp As String = ""
            Dim Totallinea As String = ""
            Dim Hora As String
            Hora = DateTime.Now.ToString("h:mm:ss")


            Dim Ticket1 As New CreaTicket()
            Dim nomsuc As String = ""

            'Using objDALActivos As New BCL.BCLPersis(GLB_ConStringPerSis)
            Using objDALActivos As New BCL.BCLApendiceSQL(GLB_ConStringDwhSQL)
                Try
                    Me.Cursor = Cursors.WaitCursor
                    'objDataSet = objDALActivos.usp_TraerNomSucursal(suc.ToString)
                    objDataSet = objDALActivos.usp_TraerSucursalTR(suc.ToString)
                    nomsuc = objDataSet.Tables(0).Rows(0)(1).ToString
                    add_this("")
                Catch ExceptionErr As Exception

                End Try
            End Using

            'Ticket1.impresora = "EPSON TM-U220D Receipt" '<-- ---- cambia a nombre de la impresora por un puerto por default
            '''' Ticket1.impresora = "tick" '<-- ---- cambia a nombre de la impresora por un puerto por default
            ' If GLB_CveSucursal = "11" Then
            Ticket1.impresora = "LR2000" '<-- ---- cambia a nombre de la impresora por un puerto por default
            'Else
            'Ticket1.impresora = "tick" '<-- ---- cambia a nombre de la impresora por un puerto por default
            'End If
            Ticket1.AbreCajon()

            '''''''''''''''''''''''''''''''''''''

            Ticket1.TextoIzquierda("ZAPATERIAS TORREON")
            Ticket1.TextoIzquierda("")
            Ticket1.TextoIzquierda("CALZADO DE TORREON S.A. DE C.V.")
            Ticket1.TextoIzquierda("AV. JUAREZ 1015 PTE.")
            Ticket1.TextoIzquierda("CENTRO")
            Ticket1.TextoIzquierda("TORREON")
            Ticket1.TextoIzquierda("COAH 27000")
            Ticket1.TextoIzquierda("R.F.C. CTO-911211JL9")

            Ticket1.TextoIzquierda("")
            Ticket1.TextoIzquierda("* Imprimio: CAJERO: " & GLB_Idempleado)

            If WeekdayName(Weekday(fecha)) <> "domingo" Then
                'modicar hora de corte ficticia
                Ticket1.TextoIzquierda("   " & WeekdayName(Weekday(fecha)) & "    " & Format(fecha, "dd/MM/yyyy") & "   " & "20:" & RandomHoraCierre(30, 50) & ":" & RandomHoraCierre(10, 59))
            Else
                Ticket1.TextoIzquierda("   " & WeekdayName(Weekday(fecha)) & "    " & Format(fecha, "dd/MM/yyyy") & "   " & "16:" & RandomHoraCierre(30, 50) & ":" & RandomHoraCierre(10, 59))

            End If
            'add_this(GLB_FechaHoy)
            Ticket1.TextoIzquierda("")

            Ticket1.TextoIzquierda("Corte de Caja: Suc. " & nomsuc)
            Ticket1.TextoIzquierda("      del " & Format(fecha, "dd/MM/yyyy"))
            If Txt_Cajero.Text <> "" Then
                Ticket1.TextoIzquierda("      del cajero " & Txt_Cajero.Text)
            Else
                Ticket1.TextoIzquierda("      del cajero 01 al 99")
            End If
            Ticket1.TextoIzquierda("VENTAS X TIPO DE ARTICULO-VENDEDOR")
            Ticket1.TextoIzquierda("")
            ''''''''''''''''''''''''''''''''''''''

            Dim m As String = ""

            Dim venta_total As Double = 0
            Dim num_total As Double = 0

            ''''''''''''''''''''''''''''''''''''''''''''
            'For Each p As String In New String() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "L", "M", "P", "S", "T", "X", "Y", "Z"}

            '    Using objDALActivos As New BCL.BCLApendice(GLB_ConStringCipSis)
            '        Try
            '            Me.Cursor = Cursors.WaitCursor
            '            objDataSet = objDALActivos.usp_traer_detalle_ventas_por_articulos(Format(fecha, "yyyy-MM-dd"), suc, p)

            '            Dim myTable As DataTable = objDataSet.Tables(0)
            '            If objDataSet.Tables(0).Rows.Count > 0 Then

            '                ''Ticket1.TextoIzquierda("    Ventas de " & objDataSet.Tables(0).Rows(0)(4) & " : ")
            '                ''Ticket1.TextoIzquierda("")

            '                For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1

            '                    ''Ticket1.TextoIzquierda(objDataSet.Tables(0).Rows(i)(0) & "  " & objDataSet.Tables(0).Rows(i)(1) & "  " & pub_RellenarEspacios(objDataSet.Tables(0).Rows(i)(2), 3) & "  " & pub_RellenarEspaciosIzquierda(Format(objDataSet.Tables(0).Rows(i)(3), "#,##0.00"), 9)) 'objDataSet.Tables(0).Rows(i)(3) & ".00")

            '                    If objDataSet.Tables(0).Rows(i)(0).ToString = "+Vt. " Then

            '                        num_total += CDbl(objDataSet.Tables(0).Rows(i)(2))
            '                        venta_total += CDbl(objDataSet.Tables(0).Rows(i)(3))
            '                    End If

            '                Next
            '            End If

            '            ''Ticket1.TextoIzquierda("")
            '        Catch ExceptionErr As Exception

            '        End Try
            '    End Using
            'Next

            'Ticket1.TextoIzquierda("                         ------  -------")
            'Ticket1.TextoIzquierda("VENTA TOTAL :             " & pub_RellenarEspacios(num_total, 3) & " " & pub_RellenarEspacios(Format(venta_total, "#,##0.00"), 9))
            'Ticket1.TextoIzquierda("")

            Dim total_pagos As Double = 0
            Dim suma_efectivo As Double = 0

            Ticket1.TextoIzquierda("** DESGLOSE POR FORMAS DE PAGO **")
            Ticket1.TextoIzquierda("")

            Using objDALActivos As New BCL.BCLApendiceSQL(GLB_ConStringDwhSQL)
                Try
                    Me.Cursor = Cursors.WaitCursor
                    objDataSet = objDALActivos.usp_traer_forma_pago(Format(fecha, "yyyy-MM-dd"), suc)

                    Dim myTable As DataTable = objDataSet.Tables(0)
                    If objDataSet.Tables(0).Rows.Count > 0 Then

                        For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                            If objDataSet.Tables(0).Rows(i)(0) = "CHEQUE    " Then
                                Ticket1.TextoIzquierda("  " & pub_RellenarEspacios(objDataSet.Tables(0).Rows(i)(0), 10) & "  " & pub_RellenarEspacios(Format(objDataSet.Tables(0).Rows(i)(1), "#,##0.00"), 26) & "   ")
                                total_pagos += CDbl(objDataSet.Tables(0).Rows(i)(1))
                                suma_efectivo += CDbl(objDataSet.Tables(0).Rows(i)(1))
                            End If

                            If objDataSet.Tables(0).Rows(i)(0) = "EFECTIVO  " Then
                                Ticket1.TextoIzquierda("  " & pub_RellenarEspacios(objDataSet.Tables(0).Rows(i)(0), 10) & "  " & pub_RellenarEspacios(Format(objDataSet.Tables(0).Rows(i)(1), "#,##0.00"), 26) & "   ")
                                total_pagos += CDbl(objDataSet.Tables(0).Rows(i)(1))
                                suma_efectivo += CDbl(objDataSet.Tables(0).Rows(i)(1))
                            End If

                            'add_this(objDataSet.Tables(0).Rows(i)(0) & "  " & objDataSet.Tables(0).Rows(i)(1) & "  ")
                            'total_pagos += CDbl(objDataSet.Tables(0).Rows(i)(1))
                        Next

                        Ticket1.TextoIzquierda("")
                        Ticket1.TextoIzquierda("           Deposito:    " & pub_RellenarEspacios(Format(suma_efectivo, "#,##0.00"), 16) & "   ")
                        Ticket1.TextoIzquierda("")

                        For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                            'If objDataSet.Tables(0).Rows(i)(0) = "CHEQUE" Then
                            '    add_this(objDataSet.Tables(0).Rows(i)(0) & "  " & pub_RellenarEspacios(objDataSet.Tables(0).Rows(i)(1), 20) & "  ")
                            '    total_pagos += CDbl(objDataSet.Tables(0).Rows(i)(1))
                            '    suma_efectivo += CDbl(objDataSet.Tables(0).Rows(i)(1))
                            'End If

                            'If objDataSet.Tables(0).Rows(i)(0) = "EFECTIVO" Then
                            '    add_this(objDataSet.Tables(0).Rows(i)(0) & "  " & pub_RellenarEspacios(objDataSet.Tables(0).Rows(i)(1), 20) & "  ")
                            '    total_pagos += CDbl(objDataSet.Tables(0).Rows(i)(1))
                            '    suma_efectivo += CDbl(objDataSet.Tables(0).Rows(i)(1))
                            'End If
                            'add_this("")
                            'add_this("           Deposito:" & pub_RellenarEspacios(suma_efectivo.ToString, 10))
                            If objDataSet.Tables(0).Rows(i)(0) <> "CHEQUE    " Then
                                If objDataSet.Tables(0).Rows(i)(0) <> "EFECTIVO  " Then
                                    Ticket1.TextoIzquierda("  " & pub_RellenarEspacios(objDataSet.Tables(0).Rows(i)(0), 10) & "  " & pub_RellenarEspacios(Format(objDataSet.Tables(0).Rows(i)(1), "#,##0.00"), 26) & "   ")
                                    total_pagos += CDbl(objDataSet.Tables(0).Rows(i)(1))
                                End If
                            End If
                        Next
                    End If

                    Ticket1.TextoIzquierda("")
                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using
            Ticket1.TextoIzquierda("                         " & "      -----------")
            Ticket1.TextoIzquierda("TOTAL DE PAGOS RECIBIDOS:      " & Format(total_pagos, "#,##0.00") & "   ")
            Ticket1.TextoIzquierda("")


            Ticket1.TextoIzquierda("*** CONSECUTIVO DE FOLIOS ***")
            Ticket1.TextoIzquierda("")

            Using objDALActivos As New BCL.BCLApendice(GLB_ConStringCipSis)
                Try
                    Me.Cursor = Cursors.WaitCursor
                    objDataSet = objDALActivos.usp_traer_consecutivo_folio(Format(fecha, "yyyy-MM-dd"), suc)

                    Dim myTable As DataTable = objDataSet.Tables(0)
                    If objDataSet.Tables(0).Rows.Count > 0 Then

                        For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                            Ticket1.TextoIzquierda(objDataSet.Tables(0).Rows(i)(0) & "  " & objDataSet.Tables(0).Rows(i)(1) & "  " & objDataSet.Tables(0).Rows(i)(2) & "  " & objDataSet.Tables(0).Rows(i)(3) & "  ")
                            Ticket1.TextoIzquierda("")
                        Next
                    End If

                    Ticket1.TextoIzquierda("")
                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using

            Ticket1.TextoIzquierda("NO APLICADOS-CANCELADOS-DEVOL/VTAS")
            Ticket1.TextoIzquierda("")
            ''''''''''''''''''''''''''''''''''''''
            Using objDALActivos As New BCL.BCLApendice(GLB_ConStringCipSis)
                Try
                    Me.Cursor = Cursors.WaitCursor
                    objDataSet = objDALActivos.usp_traer_Cancelados_NoAplicados(Format(fecha, "yyyy-MM-dd"), suc)
                    Dim myTable As DataTable = objDataSet.Tables(0)
                    If objDataSet.Tables(0).Rows.Count > 0 Then

                        For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                            Ticket1.TextoIzquierda(objDataSet.Tables(0).Rows(i)(0) & "  " & objDataSet.Tables(0).Rows(i)(1)) ' 
                            Ticket1.TextoIzquierda("")
                        Next
                    End If
                    Ticket1.TextoIzquierda("")
                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using

            Ticket1.TextoIzquierda("Devoluciones Recibidas   :")
            Ticket1.TextoIzquierda("Folio      Fecha      Ctd.     Importe")
            ''''''''''''''''''''''''''''''''''''''
            Dim total_devoluciones As Double = 0
            Dim total_ctd_devoluciones As Double = 0

            Using objDALActivos As New BCL.BCLApendice(GLB_ConStringCipSis)
                Try
                    Me.Cursor = Cursors.WaitCursor
                    objDataSet = objDALActivos.usp_traer_detalle_Devoluciones(Format(fecha, "yyyy-MM-dd"), suc)
                    Dim myTable As DataTable = objDataSet.Tables(0)
                    If objDataSet.Tables(0).Rows.Count > 0 Then

                        For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                            Ticket1.TextoIzquierda(objDataSet.Tables(0).Rows(i)(0) & "  " & objDataSet.Tables(0).Rows(i)(1) & "  " & objDataSet.Tables(0).Rows(i)(2) & "  " & objDataSet.Tables(0).Rows(i)(3)) ' 
                            total_ctd_devoluciones += objDataSet.Tables(0).Rows(i)(2)
                            total_devoluciones += objDataSet.Tables(0).Rows(i)(3)
                        Next
                    End If
                    Ticket1.TextoIzquierda("")
                    Ticket1.TextoIzquierda("                   -----     --------")
                    Ticket1.TextoIzquierda("TOTAL:            " & "    " & total_ctd_devoluciones & "        " & Format(total_devoluciones, "#,##0.00") & "   ")
                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using

            Ticket1.TextoIzquierda("DESGLOSE DE MOVIMIENTOS X ARTICULO")
            Ticket1.TextoIzquierda("Mca Estilon Med Ctd   P.U.  Impte.  T")
            Ticket1.TextoIzquierda("=== ======= === ===   ===== ======  =")
            ''''''''''''''''''''''''''''''''''''''
            Dim total_ctd_ventas As Integer = 0
            Dim total_ventas As Double = 0
            Using objDALActivos As New BCL.BCLApendiceSQL(GLB_ConStringDwhSQL)
                Try
                    Me.Cursor = Cursors.WaitCursor
                    objDataSet = objDALActivos.usp_traer_desglose_movimientos_x_articulo(Format(fecha, "yyyy-MM-dd"), suc)
                    Dim myTable As DataTable = objDataSet.Tables(0)
                    If objDataSet.Tables(0).Rows.Count > 0 Then

                        For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                            Ticket1.TextoIzquierda(objDataSet.Tables(0).Rows(i)(0) & "  " & objDataSet.Tables(0).Rows(i)(1) & "  " & objDataSet.Tables(0).Rows(i)(2) & "  " & objDataSet.Tables(0).Rows(i)(3) & "  " & objDataSet.Tables(0).Rows(i)(5) & "  " & objDataSet.Tables(0).Rows(i)(4) & "  " & "V") ' 
                            total_ctd_ventas += objDataSet.Tables(0).Rows(i)(3)
                            total_ventas += objDataSet.Tables(0).Rows(i)(4)
                        Next
                    End If
                    Ticket1.TextoIzquierda("")
                    Ticket1.TextoIzquierda(pub_RellenarEspacios("-----  --------   ", 41))
                    Ticket1.TextoIzquierda("+ Ventas     :        " & pub_RellenarEspacios(total_ctd_ventas, 3) & "  " & pub_RellenarEspacios(Format(total_ventas, "#,##0.00"), 12))
                    Ticket1.TextoIzquierda("- Devolucione:        " & pub_RellenarEspacios(total_ctd_devoluciones, 3) & "  " & pub_RellenarEspacios(Format(total_devoluciones, "#,##0.00"), 12))
                    Ticket1.TextoIzquierda(pub_RellenarEspacios("=====  =========   ", 41))
                    Ticket1.TextoIzquierda("= Ventas Netas:       " & total_ctd_ventas - total_ctd_devoluciones & "  " & pub_RellenarEspacios(Format(total_ventas - total_devoluciones, "#,##0.00"), 12))

                    Ticket1.TextoIzquierda("")
                    Ticket1.TextoCentro("*    FIN   DEL CORTE    *")
                    Ticket1.CortaTicket()

                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        Finally
        End Try
    End Sub

    Private Sub mostrar_Tiquete_Apendice(ByVal suc As String, ByVal fecha As Date)
        Try
            '**********************************
            '// La clase "CreaTicket" tiene varios metodos para imprimir con diferentes formatos (izquierda, derecha, centrado, desripcion precio,etc), a
            '   // continuacion se muestra el metodo con ejemplo de parametro que acepta, longitud maxima y un ejemplo de como imprimira, esta clase esta 
            '   // basada en una impresora Epson de matriz de puntos con impresion maxima de 40 caracteres por renglon
            '   // METODO                                      MAX_LONG                        EJEMPLOS
            '   //--------------------------------------------------------------------------------------------------------------------------
            '   // TextoIzquierda("Empleado 1")                    40                      Empleado 1      
            '   // TextoDerecha("Caja 1")                          40                                                        Caja 1
            '   // TextoCentro("Ticket")                           40                                         Ticket   
            '   // TextoExtremos("Fecha 6/1/2011","Hora:13:25")     18 y 18                 Fecha 6/1/2011                Hora:13:25
            '   // EncabezadoVenta()                                n/a                     Articulo        Can    P.Unit    Importe
            '   // LineasGuion()                                    n/a                     ----------------------------------------
            '   // AgregaArticulo("Aspirina","2",45.25,90.5)        16,3,10,11              Aspirina          2    $45.25     $90.50
            '   // LineasTotales()                                  n/a                                                ----------
            '   // AgregaTotales("Subtotal",235.25)                 25 y 15                Subtotal                         $235.25
            '   // LineasAsterisco()                                n/a                     ****************************************
            '   // LineasIgual()                                    n/a                     ========================================
            '   // CortaTicket()
            '   // AbreCajon()

            'MessageBox.Show(Format(fecha, "dd/MM/yyyy"))


            Dim Hora As String
            Hora = DateTime.Now.ToString("h:mm:ss")


            Dim Ticket1 As New CreaTicket()
            Dim nomsuc As String = ""

            'Using objDALActivos As New BCL.BCLPersis(GLB_ConStringPerSis)
            Using objDALActivos As New BCL.BCLApendiceSQL(GLB_ConStringDwhSQL)
                Try
                    Me.Cursor = Cursors.WaitCursor
                    objDataSet = objDALActivos.usp_TraerSucursalTR(suc.ToString)
                    nomsuc = objDataSet.Tables(0).Rows(0)(1).ToString
                    add_this("")
                Catch ExceptionErr As Exception

                End Try
            End Using

            Ticket1.impresora = "EPSON TM-U220D Receipt(1)" '<-- ---- cambia a nombre de la impresora por un puerto por default
            Ticket1.AbreCajon()

            '''''''''''''''''''''''''''''''''''''

            add_this("ZAPATERIAS TORREON")
            add_this("")
            add_this("CALZADO DE TORREON S.A. DE C.V.")
            add_this("AV. JUAREZ 1015 PTE.")
            add_this("CENTRO")
            add_this("TORREON")
            add_this("COAH 27000")
            add_this("R.F.C. CTO-911211JL9")

            add_this("")
            add_this("* Imprimio: CAJERO: " & GLB_Idempleado)

            If WeekdayName(Weekday(fecha)) <> "domingo" Then
                'modicar hora de corte ficticia
                add_this("   " & WeekdayName(Weekday(fecha)) & "    " & Format(fecha, "dd/MM/yyyy") & "   " & "20:" & RandomHoraCierre(30, 50) & ":" & RandomHoraCierre(10, 59))
            Else
                add_this("   " & WeekdayName(Weekday(fecha)) & "    " & Format(fecha, "dd/MM/yyyy") & "   " & "16:" & RandomHoraCierre(30, 50) & ":" & RandomHoraCierre(10, 59))

            End If
            'add_this(GLB_FechaHoy)
            add_this("")

            add_this("Corte de Caja: Suc. " & nomsuc)
            add_this("      del " & Format(fecha, "dd/MM/yyyy"))
            add_this("      del cajero 01 al 99")

            add_this("VENTAS X TIPO DE ARTICULO-VENDEDOR")
            add_this("")
            ''''''''''''''''''''''''''''''''''''''

            Dim m As String = ""

            Dim venta_total As Double = 0
            Dim num_total As Double = 0

            '''''''''''''''''''''''''''''''''''''''''''
            For Each p As String In New String() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "L", "M", "P", "S", "T", "X", "Y", "Z"}

                Using objDALActivos As New BCL.BCLApendice(GLB_ConStringCipSis)
                    Try
                        Me.Cursor = Cursors.WaitCursor
                        objDataSet = objDALActivos.usp_traer_detalle_ventas_por_articulos(Format(fecha, "yyyy-MM-dd"), suc, p)

                        Dim myTable As DataTable = objDataSet.Tables(0)
                        If objDataSet.Tables(0).Rows.Count > 0 Then

                            add_this("    Ventas de " & objDataSet.Tables(0).Rows(0)(4) & " : ")
                            add_this("")

                            For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1

                                add_this(objDataSet.Tables(0).Rows(i)(0) & "  " & objDataSet.Tables(0).Rows(i)(1) & "  " & pub_RellenarEspacios(objDataSet.Tables(0).Rows(i)(2), 3) & "  " & pub_RellenarEspacios(objDataSet.Tables(0).Rows(i)(3) & "   ", 9)) 'objDataSet.Tables(0).Rows(i)(3) & ".00")

                                If objDataSet.Tables(0).Rows(i)(0).ToString = "+Vt. " Then

                                    num_total += CDbl(objDataSet.Tables(0).Rows(i)(2))
                                    venta_total += CDbl(objDataSet.Tables(0).Rows(i)(3))
                                End If

                            Next
                        End If

                        add_this("")
                    Catch ExceptionErr As Exception

                    End Try
                End Using
            Next

            add_this("                         ------  -------")
            add_this("VENTA TOTAL :             " & pub_RellenarEspacios(num_total, 3) & " " & pub_RellenarEspacios(venta_total, 9))

            Dim total_pagos As Double = 0
            Dim suma_efectivo As Double = 0
            add_this("** DESGLOSE POR FORMAS DE PAGO **")
            add_this("")

            Using objDALActivos As New BCL.BCLApendice(GLB_ConStringCipSis)
                Try
                    Me.Cursor = Cursors.WaitCursor
                    objDataSet = objDALActivos.usp_traer_forma_pago(Format(fecha, "yyyy-MM-dd"), suc)

                    Dim myTable As DataTable = objDataSet.Tables(0)
                    If objDataSet.Tables(0).Rows.Count > 0 Then

                        For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                            If objDataSet.Tables(0).Rows(i)(0) = "CHEQUE    " Then
                                add_this("  " & pub_RellenarEspacios(objDataSet.Tables(0).Rows(i)(0), 10) & "  " & pub_RellenarEspacios(objDataSet.Tables(0).Rows(i)(1), 20) & "   ")
                                total_pagos += CDbl(objDataSet.Tables(0).Rows(i)(1))
                                suma_efectivo += CDbl(objDataSet.Tables(0).Rows(i)(1))
                            End If

                            If objDataSet.Tables(0).Rows(i)(0) = "EFECTIVO  " Then
                                add_this("  " & pub_RellenarEspacios(objDataSet.Tables(0).Rows(i)(0), 10) & "  " & pub_RellenarEspacios(objDataSet.Tables(0).Rows(i)(1), 20) & "   ")
                                total_pagos += CDbl(objDataSet.Tables(0).Rows(i)(1))
                                suma_efectivo += CDbl(objDataSet.Tables(0).Rows(i)(1))
                            End If

                            'add_this(objDataSet.Tables(0).Rows(i)(0) & "  " & objDataSet.Tables(0).Rows(i)(1) & "  ")
                            'total_pagos += CDbl(objDataSet.Tables(0).Rows(i)(1))
                        Next

                        add_this("")
                        add_this("           Deposito:    " & pub_RellenarEspacios(suma_efectivo.ToString, 10) & "   ")
                        add_this("")

                        For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                            'If objDataSet.Tables(0).Rows(i)(0) = "CHEQUE" Then
                            '    add_this(objDataSet.Tables(0).Rows(i)(0) & "  " & pub_RellenarEspacios(objDataSet.Tables(0).Rows(i)(1), 20) & "  ")
                            '    total_pagos += CDbl(objDataSet.Tables(0).Rows(i)(1))
                            '    suma_efectivo += CDbl(objDataSet.Tables(0).Rows(i)(1))
                            'End If

                            'If objDataSet.Tables(0).Rows(i)(0) = "EFECTIVO" Then
                            '    add_this(objDataSet.Tables(0).Rows(i)(0) & "  " & pub_RellenarEspacios(objDataSet.Tables(0).Rows(i)(1), 20) & "  ")
                            '    total_pagos += CDbl(objDataSet.Tables(0).Rows(i)(1))
                            '    suma_efectivo += CDbl(objDataSet.Tables(0).Rows(i)(1))
                            'End If
                            'add_this("")
                            'add_this("           Deposito:" & pub_RellenarEspacios(suma_efectivo.ToString, 10))
                            If objDataSet.Tables(0).Rows(i)(0) <> "CHEQUE    " Then
                                If objDataSet.Tables(0).Rows(i)(0) <> "EFECTIVO  " Then
                                    add_this("  " & pub_RellenarEspacios(objDataSet.Tables(0).Rows(i)(0), 10) & "  " & pub_RellenarEspacios(objDataSet.Tables(0).Rows(i)(1), 20) & "   ")
                                    total_pagos += CDbl(objDataSet.Tables(0).Rows(i)(1))
                                End If
                            End If
                        Next
                    End If

                    add_this("")
                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using
            add_this("                         " & "-----------")
            add_this("TOTAL DE PAGOS RECIBIDOS:    " & total_pagos & "   ")
            add_this("")


            add_this("*** CONSECUTIVO DE FOLIOS ***")
            add_this("")

            Using objDALActivos As New BCL.BCLApendice(GLB_ConStringCipSis)
                Try
                    Me.Cursor = Cursors.WaitCursor
                    objDataSet = objDALActivos.usp_traer_consecutivo_folio(Format(fecha, "yyyy-MM-dd"), suc)

                    Dim myTable As DataTable = objDataSet.Tables(0)
                    If objDataSet.Tables(0).Rows.Count > 0 Then

                        For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                            add_this(objDataSet.Tables(0).Rows(i)(0) & "  " & objDataSet.Tables(0).Rows(i)(1) & "  " & objDataSet.Tables(0).Rows(i)(2) & "  " & objDataSet.Tables(0).Rows(i)(3) & "  ")
                        Next
                    End If

                    add_this("")
                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using

            add_this("NO APLICADOS-CANCELADOS-DEVOL/VTAS")
            add_this("")
            '''''''''''''''''''''''''''''''''''''
            Using objDALActivos As New BCL.BCLApendice(GLB_ConStringCipSis)
                Try
                    Me.Cursor = Cursors.WaitCursor
                    objDataSet = objDALActivos.usp_traer_Cancelados_NoAplicados(Format(fecha, "yyyy-MM-dd"), suc)
                    Dim myTable As DataTable = objDataSet.Tables(0)
                    If objDataSet.Tables(0).Rows.Count > 0 Then

                        For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                            add_this(objDataSet.Tables(0).Rows(i)(0) & "  " & objDataSet.Tables(0).Rows(i)(1)) ' 
                            add_this("")
                        Next
                    End If
                    add_this("")
                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using

            add_this("Devoluciones Recibidas   :")
            add_this("Folio      Fecha      Ctd.     Importe")
            ''''''''''''''''''''''''''''''''''''''
            Dim total_devoluciones As Double = 0
            Dim total_ctd_devoluciones As Double = 0

            Using objDALActivos As New BCL.BCLApendice(GLB_ConStringCipSis)
                Try
                    Me.Cursor = Cursors.WaitCursor
                    objDataSet = objDALActivos.usp_traer_detalle_Devoluciones(Format(fecha, "yyyy-MM-dd"), suc)
                    Dim myTable As DataTable = objDataSet.Tables(0)
                    If objDataSet.Tables(0).Rows.Count > 0 Then

                        For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                            add_this(objDataSet.Tables(0).Rows(i)(0) & "  " & objDataSet.Tables(0).Rows(i)(1) & "  " & objDataSet.Tables(0).Rows(i)(2) & "  " & objDataSet.Tables(0).Rows(i)(3)) ' 
                            total_ctd_devoluciones += objDataSet.Tables(0).Rows(i)(2)
                            total_devoluciones += objDataSet.Tables(0).Rows(i)(3)
                        Next
                    End If
                    add_this("")
                    add_this("                   -----     --------")
                    add_this("TOTAL:            " & "    " & total_ctd_devoluciones & "        " & total_devoluciones & "   ")
                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using

            add_this("DESGLOSE DE MOVIMIENTOS X ARTICULO")
            add_this("Mca     Estilon    Impte.   T")
            add_this("===     =======    ======   =")
            ''''''''''''''''''''''''''''''''''''''
            Dim total_ctd_ventas As Integer = 0
            Dim total_ventas As Double = 0
            'Using objDALActivos As New BCL.BCLApendice(GLB_ConStringCipSis)
            Using objDALActivos As New BCL.BCLApendiceSQL(GLB_ConStringDwhSQL)
                Try
                    Me.Cursor = Cursors.WaitCursor
                    objDataSet = objDALActivos.usp_traer_desglose_movimientos_x_articulo(Format(fecha, "yyyy-MM-dd"), suc)
                    Dim myTable As DataTable = objDataSet.Tables(0)
                    If objDataSet.Tables(0).Rows.Count > 0 Then

                        For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                            add_this(objDataSet.Tables(0).Rows(i)(0) & "   " & objDataSet.Tables(0).Rows(i)(1) & "    " & objDataSet.Tables(0).Rows(i)(2) & "   " & "V") ' 
                            ' total_ctd_ventas += objDataSet.Tables(0).Rows(i)(3)
                            total_ventas += objDataSet.Tables(0).Rows(i)(2)
                        Next
                        total_ctd_ventas = objDataSet.Tables(0).Rows.Count - 1
                    End If
                    add_this("")
                    add_this("-----  --------   ")
                    add_this("+ Ventas     :        " & total_ctd_ventas & "  " & pub_RellenarEspacios(total_ventas, 6) & "      ")
                    add_this("- Devoluciones:        " & total_ctd_devoluciones & "  " & pub_RellenarEspacios(total_devoluciones, 6) & "      ")
                    add_this("=====  =========   ")
                    add_this("= Ventas Netas:      " & total_ctd_ventas - total_ctd_devoluciones & "  " & pub_RellenarEspacios(total_ventas - total_devoluciones, 6) & "       ")

                    add_this("")
                    Ticket1.TextoCentro("*    FIN   DEL CORTE    *")
                    Ticket1.CortaTicket()

                    write_this(add_text)
                    add_text = ""

                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        Finally
        End Try
    End Sub

    Dim ruta = " C:\Documents and Settings\jesus\Escritorio\pruebas_apendice.txt" 'My.Computer.FileSystem.SpecialDirectories.Desktop & "pruebas_apendice.txt"
    Dim add_text As String = ""
    Private Sub write_this(ByVal text As String)
        If Dir(ruta) = "" Then Kill(ruta)
        My.Computer.FileSystem.WriteAllText(ruta, text, True)
    End Sub

    Private Sub add_this(ByVal text As String)
        add_text += text & vbCrLf
    End Sub
    Public Sub CalcularIntroducirApendice(ByVal opcion As Integer, ByVal sucursal As String, ByVal fechaInicio As String, ByVal fechaFin As String, ByVal Importe As Double, ByVal porcentaje As Integer, ByVal Cajero As String)
        Using objDALActivos As New BCL.BCLApendice(GLB_ConStringCipSis)
            Try
                Me.Cursor = Cursors.WaitCursor
                objDataSet = objDALActivos.usp_Cargar_Apendice(opcion, sucursal, fechaInicio, fechaFin, Importe, porcentaje, Cajero)
                'MessageBox.Show("CARGA COMPLETA")

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub


    Public Function RandomHoraCierre(ByVal min As Integer, ByVal max As Integer) As Integer
        Dim rand As New System.Random(System.DateTime.Now.Millisecond)
        Return rand.Next(min, max)
    End Function
    Public Function pub_RellenarEspacios(ByVal Cadena As String, ByVal iLimit As Integer) As String
        Dim iLength As Integer = Cadena.ToString.Length
        Dim s As String = ""
        Try
            If iLength < iLimit Then
                For i As Integer = 1 To iLimit - iLength
                    s += " "
                Next
                s += Cadena.ToString
            Else
                s = Cadena
            End If

            Return s
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
            Return False
        End Try
    End Function

    Public Function pub_RellenarDerechaEspacios(ByVal Cadena As String, ByVal iLimit As Integer) As String
        Dim iLength As Integer = Cadena.ToString.Length
        Dim s As String = ""
        Try
            If iLength < iLimit Then
                For i As Integer = 1 To iLimit - iLength
                    s += " "
                Next
                s += Cadena.ToString
            Else
                s = Cadena
            End If

            Return s
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
            Return False
        End Try
    End Function

    Private Sub Btn_generar_Click(sender As Object, e As EventArgs) Handles Btn_generar.Click
        If MessageBox.Show("Esta seguro de querer generar el Apéndice.?,", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then Exit Sub

        'Dim obj As String() = {"01", "02", "06", "07", "08"}
        Dim obj As String() = {cb_sucursal.Text.ToString}

        If Format(DTP_Inicio.Value, "yyyy-MM-dd") = Format(DTP_Fin.Value, "yyyy-MM-dd") Then

            For Each suc As String In obj
                CalcularIntroducirApendice(opcion, suc, Format(DTP_Inicio.Value, "yyyy-MM-dd"), Format(DTP_Inicio.Value, "yyyy-MM-dd"), Val(txt_total.Text), Val(txt_porcentaje.Text), Txt_Cajero.Text) ', Format(DTP_Fin.Value, "yyyy-MM-dd"), Val(txt_total.Text), Val(txt_porcentaje.Text))
                'MessageBox.Show("Sucursal " & suc & " " & Format(DTP_Inicio.Value, "yyyy-MM-dd"))
                imprimir_Tiquete_Apendice(suc, DTP_Inicio.Value)
            Next
        Else

            Dim vFecha As Date() = {CDate(DTP_Inicio.Value), CDate(DTP_Inicio.Value)} 'CDate(DTP_Fin.Value)}
            For Each fecha As Date In vFecha
                For Each suc As String In obj
                    MessageBox.Show(suc & Format(fecha, "yyyy-MM-dd"))
                    imprimir_Tiquete_Apendice(suc, DTP_Inicio.Value)
                Next
            Next
        End If

        MsgBox("Proceso Terminado", MsgBoxStyle.Information, "Confirmación")
    End Sub

    Private Sub btn_txt_Click(sender As Object, e As EventArgs) Handles btn_txt.Click
        If MessageBox.Show("Esta seguro de querer generar el corte.?,", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then Exit Sub

        'Dim obj As String() = {"01", "02", "06", "07", "08"}
        Dim obj As String() = {cb_sucursal.Text.ToString}

        If Format(DTP_Inicio.Value, "yyyy-MM-dd") = Format(DTP_Fin.Value, "yyyy-MM-dd") Then

            For Each suc As String In obj
                CalcularIntroducirApendice(opcion, suc, Format(DTP_Inicio.Value, "yyyy-MM-dd"), Format(DTP_Inicio.Value, "yyyy-MM-dd"), Val(txt_total.Text), Val(txt_porcentaje.Text), Txt_Cajero.Text) ', Format(DTP_Fin.Value, "yyyy-MM-dd"), Val(txt_total.Text), Val(txt_porcentaje.Text))
                'MessageBox.Show("Sucursal " & suc & " " & Format(DTP_Inicio.Value, "yyyy-MM-dd"))
                mostrar_Tiquete_Apendice(suc, DTP_Inicio.Value)
            Next
        Else

            Dim vFecha As Date() = {CDate(DTP_Inicio.Value), CDate(DTP_Inicio.Value)} 'CDate(DTP_Fin.Value)}
            For Each fecha As Date In vFecha
                For Each suc As String In obj
                    MessageBox.Show(suc & Format(fecha, "yyyy-MM-dd"))
                    mostrar_Tiquete_Apendice(suc, DTP_Inicio.Value)
                Next
            Next
        End If
        MessageBox.Show("OK")
    End Sub

    Private Sub rb_porcentaje_CheckedChanged(sender As Object, e As EventArgs) Handles rb_porcentaje.CheckedChanged
        If rb_porcentaje.Checked = True Then
            lb_porcentaje.Visible = True
            txt_porcentaje.Visible = True
            txt_porcentaje.Text = ""
            opcion = 1
        Else
            lb_porcentaje.Visible = False
            txt_porcentaje.Visible = False
            txt_porcentaje.Text = ""
        End If
    End Sub

    Private Sub rb_Importe_CheckedChanged(sender As Object, e As EventArgs) Handles rb_Importe.CheckedChanged
        If rb_Importe.Checked = True Then
            lb_total.Visible = True
            txt_total.Visible = True
            txt_total.Text = ""
            opcion = 0
        Else
            lb_total.Visible = False
            txt_total.Visible = False
            txt_total.Text = ""
        End If
    End Sub
End Class