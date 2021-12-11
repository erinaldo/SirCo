Public Class frmCoquetaTrack
    Private objDataSet As Data.DataSet
    Dim CorridaAnterior As String
    Dim IntervaloAnterior As String
    Dim MedIniAnterior As Integer
    Dim MedFinAnterior As Integer
    Dim MedidaEstilo As String = ""
    Dim ColumnaRM As Integer = 23
    Public Accion As Integer
    Private blnColSelec As Boolean = False
#Region "Eventos"
    Private Sub DGrid_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellEndEdit
        Dim columna As Integer = DGrid.CurrentCell.ColumnIndex
        Dim renglon As Integer = DGrid.CurrentCell.RowIndex

        If columna = 0 Then
            Using ObjCatalogoEstilos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
                objDataSet = ObjCatalogoEstilos.usp_TraerEstilo("CTA", "", DGrid.Rows(renglon).Cells(0).Value, "", "", "", "", "", "")

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows.Count = 1 Then
                        DGrid.Rows(renglon).Cells(columna + 1).Value = objDataSet.Tables(0).Rows(0).Item("estilon").ToString
                        DGrid.Rows(renglon).Cells(columna + 2).Value = objDataSet.Tables(0).Rows(0).Item("descripc").ToString
                    Else
                        Dim myForm As New frmConsultaEstilo
                        '' mandar el valor del estilo de fábrica y marca 
                        myForm.Marcab = "CTA"
                        myForm.EstiloFb = DGrid.Rows(renglon).Cells(0).Value
                        myForm.ShowDialog()
                        ' Regresa el valor del estilo nuestro
                        DGrid.Rows(renglon).Cells(columna + 1).Value = myForm.Campo
                        DGrid.Rows(renglon).Cells(columna + 2).Value = myForm.Campo1
                        MedidaEstilo = myForm.Campo2

                        objDataSet = ObjCatalogoEstilos.usp_TraerEstilo("CTA", myForm.Campo, DGrid.Rows(renglon).Cells(0).Value, "", "", "", "", "", "")


                        Using ObjCorrida As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
                            objDataSet = ObjCorrida.usp_TraerCorrida("CTA", DGrid.Rows(renglon).Cells("estilonuestro").Value, "")
                        End Using
                    End If
                Else
                    Dim myForm As New frmConsultaArticulos
                    Dim strEspacios As String = ""
                    myForm.ShowDialog()
                    Espacios(myForm.Campo, strEspacios)
                    DGrid.Rows(renglon).Cells(0).Value = myForm.Campo1
                    DGrid.Rows(renglon).Cells(1).Value = strEspacios + myForm.Campo
                    DGrid.Rows(renglon).Cells(2).Value = myForm.Campo2
                End If
            End Using
        End If
        If columna = 1 Then
            Dim strEspacios As String = ""
            Dim strLetras As String = DGrid.Rows(renglon).Cells(1).Value
            Call Espacios(strLetras, strEspacios)
            Using ObjCatalogoEstilos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
                objDataSet = ObjCatalogoEstilos.usp_TraerEstilo("CTA", strEspacios + DGrid.Rows(renglon).Cells(1).Value, "", "", "", "", "", "", "")
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                DGrid.Rows(renglon).Cells(columna - 1).Value = objDataSet.Tables(0).Rows(0).Item("estilof").ToString
                DGrid.Rows(renglon).Cells(columna).Value = objDataSet.Tables(0).Rows(0).Item("estilon").ToString
                DGrid.Rows(renglon).Cells(columna + 1).Value = objDataSet.Tables(0).Rows(0).Item("descripc").ToString
            Else
                Dim myForm As New frmConsultaArticulos
                strEspacios = ""
                myForm.ShowDialog()
                Espacios(myForm.Campo, strEspacios)
                DGrid.Rows(renglon).Cells(0).Value = myForm.Campo1
                DGrid.Rows(renglon).Cells(1).Value = strEspacios + myForm.Campo
                DGrid.Rows(renglon).Cells(2).Value = myForm.Campo2
            End If
        End If
        If columna = 3 Then
            Call TraerCorrida(renglon, columna, DGrid.Rows(renglon).Cells(3).Value)
        End If
        If blnColSelec = False Then
            'AgregarColumna()
            blnColSelec = True
        End If

    End Sub
#End Region

#Region "Metodos"
    Private Sub TraerCorrida(ByVal Renglon As Integer, ByVal Columna As Integer, ByVal Corrida As String)
        'mreyes 15/Febrero/2012 11:04 a.m.
        Try
            Using objCatalogoEstilos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
                Dim OrdenIni As String = ""
                Dim OrdenFin As String = ""

                Dim objDataSet As Data.DataSet

                'Txt_Campo.Text = DGrid.Rows(Renglon).Cells(Columna).Value

                objDataSet = objCatalogoEstilos.usp_TraerCorrida("CTA", DGrid.Rows(Renglon).Cells(1).Value, Corrida)

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    '' si existe estilo, traerlo.
                    ' 13 corrida, 14 intervalo, 15 medini, 16 medfin
                    DGrid.Rows(Renglon).Cells("c").Value = objDataSet.Tables(0).Rows(0).Item("corrida").ToString
                    DGrid.Rows(Renglon).Cells("i").Value = objDataSet.Tables(0).Rows(0).Item("intervalo").ToString
                    DGrid.Rows(Renglon).Cells("de").Value = objDataSet.Tables(0).Rows(0).Item("medini").ToString
                    DGrid.Rows(Renglon).Cells("a").Value = objDataSet.Tables(0).Rows(0).Item("medfin").ToString
                    ' calcular costo
                    CorridaAnterior = DGrid.Rows(Renglon).Cells(Columna).Value
                    IntervaloAnterior = objDataSet.Tables(0).Rows(0).Item("intervalo").ToString
                    MedIniAnterior = Val(objDataSet.Tables(0).Rows(0).Item("medini"))
                    MedFinAnterior = Val(objDataSet.Tables(0).Rows(0).Item("medfin"))
                    
                Call TraerCorridasSelect(Renglon)
                DGrid.Rows(Renglon).Cells("c").ReadOnly = True

                '''CHECAR  TRAER VARIAS SUCURSALES

                Else
                MsgBox("La corrida '" & DGrid.Rows(Renglon).Cells(3).Value & "' no se encuentra registrada para el estilo.", MsgBoxStyle.Critical, "Aviso")
                DGrid.Rows(Renglon).Cells(Columna).Value = ""
                ''DGrid.CurrentCell = DGrid.Rows(renglon).Cells(columna)
                ''SendKeys.Send("{UP}")
                DGrid.Rows(Renglon).Selected = True
                DGrid.Columns(Columna).Selected = True
                DGrid.CurrentCell = DGrid.Rows(Renglon).Cells(Columna)

                DGrid.CurrentCell = DGrid.Item(Columna, Renglon)
                DGrid.Rows(Renglon).Selected = True
                DGrid.Columns(Columna).Selected = True

                DGrid.CurrentCell = DGrid.Rows(Renglon).Cells(Columna)

                End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub RellenarCorrida(ByVal Renglon As Integer, ByVal MedIni As Integer, ByVal Intervalo As Integer, Optional ByVal Cantidad As Double = 0)
        'mreyes 18/Febrero/2012 10:18 a.m.
        Try
            For MedIniAnterior = Val(MedIni) To MedFinAnterior

                Call RellenarColumnasCorrida(Renglon, MedIniAnterior, Cantidad)
                MedIniAnterior = MedIniAnterior + IIf(IntervaloAnterior = "-" Or IntervaloAnterior = "L", 1, IntervaloAnterior) - 1
            Next

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub RellenarMedidas(ByVal Renglon As Integer, ByVal OrdeIni As String, ByVal OrdeFin As String, ByVal Estilon As String, ByVal Corrida As String, ByVal Intervalo As String, ByVal Sw_Traspaso As Boolean)
        'mreyes 23/Febrero/2012 06:13 a.m.
        Using objCatalogoEstilos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)

            Try
                Dim Sw_Encontro As Boolean = False
                Dim Medida As String = ""

                Dim objDataSet As Data.DataSet

                objDataSet = objCatalogoEstilos.usp_TraerLetrasIniFin("01", "99", MedidaEstilo)

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    For z As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                        Medida = objDataSet.Tables(0).Rows(z).Item("medida").ToString
                        With DGrid
                            ' buscar la medida en el grid 

                            For k As Integer = 24 To 123
                                With DGrid
                                    If .Columns(k).HeaderText = pub_RellenarIzquierda(Medida, 2) Then
                                        Sw_Encontro = True
                                        ' probar
                                        ColumnaRM = ColumnaRM + 1

                                        Exit For
                                    Else
                                        Sw_Encontro = False
                                    End If

                                End With

                            Next
                            If Sw_Encontro = False Then
                                With DGrid
                                    ColumnaRM = ColumnaRM + 1
                                    .Columns(ColumnaRM).HeaderText = Medida
                                    z = z + IIf(Intervalo = "-" Or Intervalo = "L", 1, Intervalo) - 1
                                End With
                            Else
                                If Intervalo <> "L" Then
                                    z = z + IIf(Intervalo = "-" Or Intervalo = "L", 1, Intervalo) - 1

                                End If

                            End If

                            ''ColumnaRM = ColumnaRM + 1
                            ''.Columns(ColumnaRM).HeaderText = Medida

                        End With

                    Next
                    'if a buscar la cantidad a det_oc por cada medida 

                    Call GeneraColumnasMedida(Renglon, OrdeIni, OrdeFin, Estilon, Corrida, Sw_Traspaso)
                Else
                    '' checar es NUMERICO
                    If MedidaEstilo = "N" Then
                        '' el ordefin necesito saber exactamente 

                        '' checar si ya existe la medida en el grid



                        For z As Integer = OrdeIni To OrdeFin
                            For k As Integer = 24 To 123
                                Medida = z

                                With DGrid
                                    If .Columns(k).HeaderText = pub_RellenarIzquierda(Medida, 2) Then
                                        Sw_Encontro = True
                                        Exit For
                                    Else
                                        Sw_Encontro = False
                                    End If

                                End With

                            Next
                            If Sw_Encontro = False Then
                                With DGrid
                                    ColumnaRM = ColumnaRM + 1
                                    .Columns(ColumnaRM).HeaderText = Medida
                                    z = z + IIf(Intervalo = "-" Or Intervalo = "L", 1, Intervalo) - 1
                                End With
                            Else
                                'z = z + IIf(Intervalo = "-", 1, Intervalo) - 1
                                z = z + IIf(Intervalo = "-" Or Intervalo = "L", 1, Intervalo) - 1

                            End If
                        Next
                        'if a buscar la cantidad a det_oc por cada medida 

                        Call GeneraColumnasMedidaNumeros(Renglon, OrdeIni, OrdeFin, Estilon, Corrida)

                    End If
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub GeneraColumnasMedidaNumeros(ByVal Renglon As Integer, ByVal OrdeIni As String, ByVal OrdeFin As String, ByVal Estilon As String, ByVal Corrida As String) ' en el 24 comienza la medida 
        'mreyes 08/Marzo/2012 03:36 a.m.
        Try
            Dim Medida As String = ""
            Dim Cantidad As Integer = 0

            Dim objDataSet1 As Data.DataSet
            Dim Pcomp As Decimal
            Dim Costo As Decimal
            Dim Entrega As Date


            'primero generar todas las columnas según la corrida que podria ser ... 



            For I As Integer = 24 To 123
                For z As Integer = OrdeIni To OrdeFin
                    Medida = pub_RellenarIzquierda(z, 2)
                    Entrega = DGrid.Rows(Renglon).Cells("FechaEntrega").Value
                    With DGrid

                        If DGrid.Columns(I).HeaderText = Medida Then
                            .Columns(I).Visible = True
                            DGrid.Rows(Renglon).Cells(I).Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                ' ir por cantidad usp_TraerCantidadesDet_Oc

                                Using objCantidadesDet_Oc As New BCL.BCLPedidos(GLB_ConStringCipSis)
                                    'If Chk_VerPendientexRecibir.Checked = False Then
                                    '    'objDataSet1 = objCantidadesDet_Oc.usp_TraerCantidadesDet_Oc(Txt_Sucursal.Text, Txt_OrdeComp.Text, Txt_Marca.Text, Estilon, Corrida, Medida, Entrega)
                                    'Else
                                    '    'objDataSet1 = objCantidadesDet_Oc.usp_TraerCantidadesSXRecDet_Oc(Txt_Sucursal.Text, Txt_OrdeComp.Text, Txt_Marca.Text, Estilon, Corrida, Medida, Entrega)
                                    'End If
                                    If objDataSet1.Tables(0).Rows.Count > 0 Then
                                        Cantidad = Val(objDataSet1.Tables(0).Rows(0).Item("ctd"))
                                        Costo = Val(objDataSet1.Tables(0).Rows(0).Item("costo"))
                                        Pcomp = Val(objDataSet1.Tables(0).Rows(0).Item("costdesc"))


                                    Else
                                        Pcomp = 0
                                        Costo = 0

                                        Cantidad = 0

                                    End If
                                    'DGrid.Rows(Renglon).Cells("pcomp").Value = Format(Val(Pcomp), "#,##0.00")
                                    'DGrid.Rows(Renglon).Cells("costo").Value = Format(Val(Costo), "#,##0.00")

                                    DGrid.Rows(Renglon).Cells(I).Value = Format(Val(Cantidad), "#,##0")

                                End Using
                            End If
                        End If

                    End With
                Next
            Next



        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub RellenarColumnasCorrida(ByVal Renglon As Integer, ByVal Medida As Integer, Optional ByVal Cantidad As Integer = 0)
        'mreyes 24/Febrero/2012 04:58 p.m.
        Try

            If Medida = 1 Then

                DGrid.Columns("M1").Visible = True
                DGrid.Rows(Renglon).Cells("M1").Style.BackColor = Color.Yellow
                If Accion <> 1 Then
                    DGrid.Rows(Renglon).Cells("M1").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M1_").Visible = True
                    DGrid.Rows(Renglon).Cells("M1_").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M1_").Value = Cantidad
                    End If
                End If
            End If

            If Medida = 2 Then

                DGrid.Columns("M2").Visible = True
                DGrid.Rows(Renglon).Cells("M2").Style.BackColor = Color.Yellow
                If Accion <> 2 Then
                    DGrid.Rows(Renglon).Cells("M2").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M2_").Visible = True
                    DGrid.Rows(Renglon).Cells("M2_").Style.BackColor = Color.Yellow
                    If Accion <> 2 Then
                        DGrid.Rows(Renglon).Cells("M2_").Value = Cantidad
                    End If
                End If
            End If

            If Medida = 3 Then

                DGrid.Columns("M3").Visible = True
                DGrid.Rows(Renglon).Cells("M3").Style.BackColor = Color.Yellow
                If Accion <> 3 Then
                    DGrid.Rows(Renglon).Cells("M3").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M3_").Visible = True
                    DGrid.Rows(Renglon).Cells("M3_").Style.BackColor = Color.Yellow
                    If Accion <> 3 Then
                        DGrid.Rows(Renglon).Cells("M3_").Value = Cantidad
                    End If
                End If
            End If

            If Medida = 4 Then

                DGrid.Columns("M4").Visible = True
                DGrid.Rows(Renglon).Cells("M4").Style.BackColor = Color.Yellow
                If Accion <> 4 Then
                    DGrid.Rows(Renglon).Cells("M4").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M4_").Visible = True
                    DGrid.Rows(Renglon).Cells("M4_").Style.BackColor = Color.Yellow
                    If Accion <> 4 Then
                        DGrid.Rows(Renglon).Cells("M4_").Value = Cantidad
                    End If
                End If
            End If

            If Medida = 5 Then

                DGrid.Columns("M5").Visible = True
                DGrid.Rows(Renglon).Cells("M5").Style.BackColor = Color.Yellow
                If Accion <> 5 Then
                    DGrid.Rows(Renglon).Cells("M5").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M5_").Visible = True
                    DGrid.Rows(Renglon).Cells("M5_").Style.BackColor = Color.Yellow
                    If Accion <> 5 Then
                        DGrid.Rows(Renglon).Cells("M5_").Value = Cantidad
                    End If
                End If
            End If

            If Medida = 6 Then

                DGrid.Columns("M6").Visible = True
                DGrid.Rows(Renglon).Cells("M6").Style.BackColor = Color.Yellow
                If Accion <> 6 Then
                    DGrid.Rows(Renglon).Cells("M6").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M6_").Visible = True
                    DGrid.Rows(Renglon).Cells("M6_").Style.BackColor = Color.Yellow
                    If Accion <> 6 Then
                        DGrid.Rows(Renglon).Cells("M6_").Value = Cantidad
                    End If
                End If
            End If

            If Medida = 7 Then

                DGrid.Columns("M7").Visible = True
                DGrid.Rows(Renglon).Cells("M7").Style.BackColor = Color.Yellow
                If Accion <> 7 Then
                    DGrid.Rows(Renglon).Cells("M7").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M7_").Visible = True
                    DGrid.Rows(Renglon).Cells("M7_").Style.BackColor = Color.Yellow
                    If Accion <> 7 Then
                        DGrid.Rows(Renglon).Cells("M7_").Value = Cantidad
                    End If
                End If
            End If

            If Medida = 8 Then

                DGrid.Columns("M8").Visible = True
                DGrid.Rows(Renglon).Cells("M8").Style.BackColor = Color.Yellow
                If Accion <> 8 Then
                    DGrid.Rows(Renglon).Cells("M8").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M8_").Visible = True
                    DGrid.Rows(Renglon).Cells("M8_").Style.BackColor = Color.Yellow
                    If Accion <> 8 Then
                        DGrid.Rows(Renglon).Cells("M8_").Value = Cantidad
                    End If
                End If
            End If

            If Medida = 9 Then

                DGrid.Columns("M9").Visible = True
                DGrid.Rows(Renglon).Cells("M9").Style.BackColor = Color.Yellow
                If Accion <> 1 Then
                    DGrid.Rows(Renglon).Cells("M9").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M9_").Visible = True
                    DGrid.Rows(Renglon).Cells("M9_").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M9_").Value = Cantidad
                    End If
                End If
            End If

            If Medida = 10 Then
                DGrid.Columns("M10").Visible = True
                DGrid.Rows(Renglon).Cells("M10").Style.BackColor = Color.Yellow
                If Accion <> 1 Then
                    DGrid.Rows(Renglon).Cells("M10").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M10_").Visible = True
                    DGrid.Rows(Renglon).Cells("M10_").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M10_").Value = Cantidad
                    End If
                End If
            End If

            If Medida = 11 Then
                DGrid.Columns("M11").Visible = True
                DGrid.Rows(Renglon).Cells("M11").Style.BackColor = Color.Yellow
                If Accion <> 1 Then
                    DGrid.Rows(Renglon).Cells("M11").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M11_").Visible = True
                    DGrid.Rows(Renglon).Cells("M11_").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M11_").Value = Cantidad
                    End If
                End If
            End If

            If Medida = 12 Then
                DGrid.Columns("M12").Visible = True
                DGrid.Rows(Renglon).Cells("M12").Style.BackColor = Color.Yellow
                If Accion <> 1 Then
                    DGrid.Rows(Renglon).Cells("M12").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M12_").Visible = True
                    DGrid.Rows(Renglon).Cells("M12_").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M12_").Value = Cantidad
                    End If
                End If
            End If


            If Medida = 13 Then
                DGrid.Columns("M13").Visible = True
                DGrid.Rows(Renglon).Cells("M13").Style.BackColor = Color.Yellow
                If Accion <> 1 Then
                    DGrid.Rows(Renglon).Cells("M13").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M13_").Visible = True
                    DGrid.Rows(Renglon).Cells("M13_").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M13_").Value = Cantidad
                    End If
                End If
            End If

            If Medida = 14 Then
                DGrid.Columns("M14").Visible = True
                DGrid.Rows(Renglon).Cells("M14").Style.BackColor = Color.Yellow
                If Accion <> 1 Then
                    DGrid.Rows(Renglon).Cells("M14").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M14_").Visible = True
                    DGrid.Rows(Renglon).Cells("M14_").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M14_").Value = Cantidad
                    End If
                End If
            End If

            If Medida = 15 Then
                DGrid.Columns("M15").Visible = True
                DGrid.Rows(Renglon).Cells("M15").Style.BackColor = Color.Yellow
                If Accion <> 1 Then
                    DGrid.Rows(Renglon).Cells("M15").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M15_").Visible = True
                    DGrid.Rows(Renglon).Cells("M15_").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M15_").Value = Cantidad
                    End If
                End If
            End If

            If Medida = 16 Then
                DGrid.Columns("M16").Visible = True
                DGrid.Rows(Renglon).Cells("M16").Style.BackColor = Color.Yellow
                If Accion <> 1 Then
                    DGrid.Rows(Renglon).Cells("M16").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M16_").Visible = True
                    DGrid.Rows(Renglon).Cells("M16_").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M16_").Value = Cantidad
                    End If
                End If
            End If

            If Medida = 17 Then
                DGrid.Columns("M17").Visible = True
                DGrid.Rows(Renglon).Cells("M17").Style.BackColor = Color.Yellow
                If Accion <> 1 Then
                    DGrid.Rows(Renglon).Cells("M17").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M17_").Visible = True
                    DGrid.Rows(Renglon).Cells("M17_").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M17_").Value = Cantidad
                    End If
                End If
            End If

            If Medida = 18 Then
                DGrid.Columns("M18").Visible = True
                DGrid.Rows(Renglon).Cells("M18").Style.BackColor = Color.Yellow
                If Accion <> 1 Then
                    DGrid.Rows(Renglon).Cells("M18").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M18_").Visible = True
                    DGrid.Rows(Renglon).Cells("M18_").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M18_").Value = Cantidad
                    End If
                End If
            End If

            If Medida = 19 Then
                DGrid.Columns("M19").Visible = True
                DGrid.Rows(Renglon).Cells("M19").Style.BackColor = Color.Yellow
                If Accion <> 1 Then
                    DGrid.Rows(Renglon).Cells("M19").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M19_").Visible = True
                    DGrid.Rows(Renglon).Cells("M19_").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M19_").Value = Cantidad
                    End If
                End If
            End If

            If Medida = 20 Then
                DGrid.Columns("M20").Visible = True
                DGrid.Rows(Renglon).Cells("M20").Style.BackColor = Color.Yellow
                If Accion <> 1 Then
                    DGrid.Rows(Renglon).Cells("M20").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M20_").Visible = True
                    DGrid.Rows(Renglon).Cells("M20_").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M20_").Value = Cantidad
                    End If
                End If
            End If

            If Medida = 21 Then
                DGrid.Columns("M21").Visible = True
                DGrid.Rows(Renglon).Cells("M21").Style.BackColor = Color.Yellow
                If Accion <> 1 Then
                    DGrid.Rows(Renglon).Cells("M21").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M21_").Visible = True
                    DGrid.Rows(Renglon).Cells("M21_").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M21_").Value = Cantidad
                    End If
                End If
            End If


            If Medida = 22 Then
                DGrid.Columns("M22").Visible = True
                DGrid.Rows(Renglon).Cells("M22").Style.BackColor = Color.Yellow
                If Accion <> 1 Then
                    DGrid.Rows(Renglon).Cells("M22").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M22_").Visible = True
                    DGrid.Rows(Renglon).Cells("M22_").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M22_").Value = Cantidad
                    End If
                End If
            End If



            If Medida = 23 Then
                DGrid.Columns("M23").Visible = True
                DGrid.Rows(Renglon).Cells("M23").Style.BackColor = Color.Yellow
                If Accion <> 1 Then
                    DGrid.Rows(Renglon).Cells("M23").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M23_").Visible = True
                    DGrid.Rows(Renglon).Cells("M23_").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M23_").Value = Cantidad
                    End If
                End If
            End If

            If Medida = 24 Then
                DGrid.Columns("M24").Visible = True
                DGrid.Rows(Renglon).Cells("M24").Style.BackColor = Color.Yellow
                If Accion <> 1 Then
                    DGrid.Rows(Renglon).Cells("M24").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M24_").Visible = True
                    DGrid.Rows(Renglon).Cells("M24_").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M24_").Value = Cantidad
                    End If
                End If
            End If


            If Medida = 25 Then
                DGrid.Columns("M25").Visible = True
                DGrid.Rows(Renglon).Cells("M25").Style.BackColor = Color.Yellow
                If Accion <> 1 Then
                    DGrid.Rows(Renglon).Cells("M25").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M25_").Visible = True
                    DGrid.Rows(Renglon).Cells("M25_").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M25_").Value = Cantidad
                    End If
                End If
            End If

            If Medida = 26 Then
                DGrid.Columns("M26").Visible = True
                DGrid.Rows(Renglon).Cells("M26").Style.BackColor = Color.Yellow
                If Accion <> 1 Then
                    DGrid.Rows(Renglon).Cells("M26").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M26_").Visible = True
                    DGrid.Rows(Renglon).Cells("M26_").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M26_").Value = Cantidad
                    End If
                End If
            End If

            If Medida = 27 Then
                DGrid.Columns("M27").Visible = True
                DGrid.Rows(Renglon).Cells("M27").Style.BackColor = Color.Yellow
                If Accion <> 1 Then
                    DGrid.Rows(Renglon).Cells("M27").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M27_").Visible = True
                    DGrid.Rows(Renglon).Cells("M27_").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M27_").Value = Cantidad
                    End If
                End If
            End If

            If Medida = 28 Then
                DGrid.Columns("M28").Visible = True
                DGrid.Rows(Renglon).Cells("M28").Style.BackColor = Color.Yellow
                If Accion <> 1 Then
                    DGrid.Rows(Renglon).Cells("M28").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M28_").Visible = True
                    DGrid.Rows(Renglon).Cells("M28_").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M28_").Value = Cantidad
                    End If
                End If
            End If

            If Medida = 29 Then
                DGrid.Columns("M29").Visible = True
                DGrid.Rows(Renglon).Cells("M29").Style.BackColor = Color.Yellow
                If Accion <> 1 Then
                    DGrid.Rows(Renglon).Cells("M29").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M29_").Visible = True
                    DGrid.Rows(Renglon).Cells("M29_").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M29_").Value = Cantidad
                    End If
                End If
            End If

            If Medida = 30 Then
                DGrid.Columns("M30").Visible = True
                DGrid.Rows(Renglon).Cells("M30").Style.BackColor = Color.Yellow
                If Accion <> 1 Then
                    DGrid.Rows(Renglon).Cells("M30").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M30_").Visible = True
                    DGrid.Rows(Renglon).Cells("M30_").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M30_").Value = Cantidad
                    End If
                End If
            End If

            If Medida = 31 Then
                DGrid.Columns("M31").Visible = True
                DGrid.Rows(Renglon).Cells("M31").Style.BackColor = Color.Yellow
                If Accion <> 1 Then
                    DGrid.Rows(Renglon).Cells("M31").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M31_").Visible = True
                    DGrid.Rows(Renglon).Cells("M31_").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M31_").Value = Cantidad
                    End If
                End If
            End If

            If Medida = 32 Then
                DGrid.Columns("M32").Visible = True
                DGrid.Rows(Renglon).Cells("M32").Style.BackColor = Color.Yellow
                If Accion <> 1 Then
                    DGrid.Rows(Renglon).Cells("M32").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M32_").Visible = True
                    DGrid.Rows(Renglon).Cells("M32_").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M32_").Value = Cantidad
                    End If
                End If
            End If

            If Medida = 33 Then
                DGrid.Columns("M33").Visible = True
                DGrid.Rows(Renglon).Cells("M33").Style.BackColor = Color.Yellow
                If Accion <> 1 Then
                    DGrid.Rows(Renglon).Cells("M33").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M33_").Visible = True
                    DGrid.Rows(Renglon).Cells("M33_").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M33_").Value = Cantidad
                    End If
                End If
            End If

            If Medida = 34 Then
                DGrid.Columns("M34").Visible = True
                DGrid.Rows(Renglon).Cells("M34").Style.BackColor = Color.Yellow
                If Accion <> 1 Then
                    DGrid.Rows(Renglon).Cells("M34").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M34_").Visible = True
                    DGrid.Rows(Renglon).Cells("M34_").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M34_").Value = Cantidad
                    End If
                End If
            End If

            If Medida = 35 Then
                DGrid.Columns("M35").Visible = True
                DGrid.Rows(Renglon).Cells("M35").Style.BackColor = Color.Yellow
                If Accion <> 1 Then
                    DGrid.Rows(Renglon).Cells("M35").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M35_").Visible = True
                    DGrid.Rows(Renglon).Cells("M35_").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M35_").Value = Cantidad
                    End If
                End If
            End If

            If Medida = 36 Then
                DGrid.Columns("M36").Visible = True
                DGrid.Rows(Renglon).Cells("M36").Style.BackColor = Color.Yellow
                If Accion <> 1 Then
                    DGrid.Rows(Renglon).Cells("M36").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M36_").Visible = True
                    DGrid.Rows(Renglon).Cells("M36_").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M36_").Value = Cantidad
                    End If
                End If
            End If

            If Medida = 37 Then
                DGrid.Columns("M37").Visible = True
                DGrid.Rows(Renglon).Cells("M37").Style.BackColor = Color.Yellow
                If Accion <> 1 Then
                    DGrid.Rows(Renglon).Cells("M37").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M37_").Visible = True
                    DGrid.Rows(Renglon).Cells("M37_").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M37_").Value = Cantidad
                    End If
                End If
            End If

            If Medida = 38 Then
                DGrid.Columns("M38").Visible = True
                DGrid.Rows(Renglon).Cells("M38").Style.BackColor = Color.Yellow
                If Accion <> 1 Then
                    DGrid.Rows(Renglon).Cells("M38").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M38_").Visible = True
                    DGrid.Rows(Renglon).Cells("M38_").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M38_").Value = Cantidad
                    End If
                End If
            End If

            If Medida = 39 Then
                DGrid.Columns("M39").Visible = True
                DGrid.Rows(Renglon).Cells("M39").Style.BackColor = Color.Yellow
                If Accion <> 1 Then
                    DGrid.Rows(Renglon).Cells("M39").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M39_").Visible = True
                    DGrid.Rows(Renglon).Cells("M39_").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M39_").Value = Cantidad
                    End If
                End If
            End If

            If Medida = 40 Then
                DGrid.Columns("M40").Visible = True
                DGrid.Rows(Renglon).Cells("M40").Style.BackColor = Color.Yellow
                If Accion <> 1 Then
                    DGrid.Rows(Renglon).Cells("M40").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M40_").Visible = True
                    DGrid.Rows(Renglon).Cells("M40_").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M40_").Value = Cantidad
                    End If
                End If
            End If

            If Medida = 41 Then
                DGrid.Columns("M41").Visible = True
                DGrid.Rows(Renglon).Cells("M41").Style.BackColor = Color.Yellow
                If Accion <> 1 Then
                    DGrid.Rows(Renglon).Cells("M41").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M41_").Visible = True
                    DGrid.Rows(Renglon).Cells("M41_").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M41_").Value = Cantidad
                    End If
                End If
            End If

            If Medida = 42 Then
                DGrid.Columns("M42").Visible = True
                DGrid.Rows(Renglon).Cells("M42").Style.BackColor = Color.Yellow
                If Accion <> 1 Then
                    DGrid.Rows(Renglon).Cells("M42").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M42_").Visible = True
                    DGrid.Rows(Renglon).Cells("M42_").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M42_").Value = Cantidad
                    End If
                End If
            End If

            If Medida = 43 Then
                DGrid.Columns("M43").Visible = True
                DGrid.Rows(Renglon).Cells("M43").Style.BackColor = Color.Yellow
                If Accion <> 1 Then
                    DGrid.Rows(Renglon).Cells("M43").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M43_").Visible = True
                    DGrid.Rows(Renglon).Cells("M43_").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M43_").Value = Cantidad
                    End If
                End If
            End If

            If Medida = 44 Then
                DGrid.Columns("M44").Visible = True
                DGrid.Rows(Renglon).Cells("M44").Style.BackColor = Color.Yellow
                If Accion <> 1 Then
                    DGrid.Rows(Renglon).Cells("M44").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M44_").Visible = True
                    DGrid.Rows(Renglon).Cells("M44_").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M44_").Value = Cantidad
                    End If
                End If
            End If

            If Medida = 45 Then
                DGrid.Columns("M45").Visible = True
                DGrid.Rows(Renglon).Cells("M45").Style.BackColor = Color.Yellow
                If Accion <> 1 Then
                    DGrid.Rows(Renglon).Cells("M45").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M45_").Visible = True
                    DGrid.Rows(Renglon).Cells("M45_").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M45_").Value = Cantidad
                    End If
                End If
            End If

            If Medida = 46 Then
                DGrid.Columns("M46").Visible = True
                DGrid.Rows(Renglon).Cells("M46").Style.BackColor = Color.Yellow
                If Accion <> 1 Then
                    DGrid.Rows(Renglon).Cells("M46").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M46_").Visible = True
                    DGrid.Rows(Renglon).Cells("M46_").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M46_").Value = Cantidad
                    End If
                End If
            End If

            If Medida = 47 Then
                DGrid.Columns("M47").Visible = True
                DGrid.Rows(Renglon).Cells("M47").Style.BackColor = Color.Yellow
                If Accion <> 1 Then
                    DGrid.Rows(Renglon).Cells("M47").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M47_").Visible = True
                    DGrid.Rows(Renglon).Cells("M47_").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M47_").Value = Cantidad
                    End If
                End If
            End If

            If Medida = 48 Then
                DGrid.Columns("M48").Visible = True
                DGrid.Rows(Renglon).Cells("M48").Style.BackColor = Color.Yellow
                If Accion <> 1 Then
                    DGrid.Rows(Renglon).Cells("M48").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M48_").Visible = True
                    DGrid.Rows(Renglon).Cells("M48_").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M48_").Value = Cantidad
                    End If
                End If
            End If

            If Medida = 49 Then
                DGrid.Columns("M49").Visible = True
                DGrid.Rows(Renglon).Cells("M49").Style.BackColor = Color.Yellow
                If Accion <> 1 Then
                    DGrid.Rows(Renglon).Cells("M49").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M49_").Visible = True
                    DGrid.Rows(Renglon).Cells("M49_").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M49_").Value = Cantidad
                    End If
                End If
            End If

            If Medida = 50 Then
                DGrid.Columns("M50").Visible = True
                DGrid.Rows(Renglon).Cells("M50").Style.BackColor = Color.Yellow
                If Accion <> 1 Then
                    DGrid.Rows(Renglon).Cells("M50").Value = Cantidad
                End If
                If IntervaloAnterior = "-" Then
                    DGrid.Columns("M50_").Visible = True
                    DGrid.Rows(Renglon).Cells("M50_").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M50_").Value = Cantidad
                    End If
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub GeneraColumnasMedida(ByVal Renglon As Integer, ByVal OrdeIni As String, ByVal OrdeFin As String, ByVal Estilon As String, ByVal Corrida As String, ByVal Sw_Traspaso As Boolean) ' en el 24 comienza la medida 
        'mreyes 23/Febrero/2012 06:13 a.m.
        Try
            Dim Medida As String = ""
            Dim Cantidad As Integer = 0
            Dim objDataSet As Data.DataSet
            Dim objDataSet1 As Data.DataSet
            Dim Pcomp As Decimal
            Dim Costo As Decimal
            Dim Entrega As Date

            'primero generar todas las columnas según la corrida que podria ser ... 

            Using objCatalogoEstilos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)

                objDataSet = objCatalogoEstilos.usp_TraerLetrasIniFin(OrdeIni, OrdeFin, MedidaEstilo)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    For I As Integer = 24 To 123
                        For z As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                            Medida = objDataSet.Tables(0).Rows(z).Item("medida").ToString
                            Entrega = "1900-01-01"
                            With DGrid

                                If DGrid.Columns(I).HeaderText = Medida Then
                                    .Columns(I).Visible = True
                                    DGrid.Rows(Renglon).Cells(I).Style.BackColor = Color.Yellow
                                    If Accion <> 1 Then
                                        ' ir por cantidad usp_TraerCantidadesDet_Oc


                                        Using objCantidadesDet_Oc As New BCL.BCLPedidos(GLB_ConStringCipSis)
                                            'If Chk_VerPendientexRecibir.Checked = False Then
                                            '    'objDataSet1 = objCantidadesDet_Oc.usp_TraerCantidadesDet_Oc(Txt_Sucursal.Text, Txt_OrdeComp.Text, Txt_Marca.Text, Estilon, Corrida, Medida, Entrega)
                                            'Else
                                            '    'objDataSet1 = objCantidadesDet_Oc.usp_TraerCantidadesSXRecDet_Oc(Txt_Sucursal.Text, Txt_OrdeComp.Text, Txt_Marca.Text, Estilon, Corrida, Medida, Entrega)
                                            'End If
                                            If objDataSet1.Tables(0).Rows.Count > 0 Then
                                                Cantidad = Val(objDataSet1.Tables(0).Rows(0).Item("ctd"))
                                                Costo = Val(objDataSet1.Tables(0).Rows(0).Item("costo"))
                                                Pcomp = Val(objDataSet1.Tables(0).Rows(0).Item("costdesc"))


                                            Else
                                                Pcomp = 0
                                                Costo = 0

                                                Cantidad = 0

                                            End If
                                            'checar
                                            ' DGrid.Rows(Renglon).Cells("pcomp").Value = Format(Val(Pcomp), "#,##0.00")
                                            ' DGrid.Rows(Renglon).Cells("costo").Value = Format(Val(Costo), "#,##0.00")
                                            ''''
                                            DGrid.Rows(Renglon).Cells(I).Value = Format(Val(Cantidad), "#,##0")

                                        End Using
                                    Else
                                        ' ES ALTA PERO HAY QUE CHECAR SI ES SW_TRASPASO = TRUE 
                                        If Sw_Traspaso = True Then

                                            Using objCantidadesDet_Oc As New BCL.BCLPedidos(GLB_ConStringCipSis)
                                                'objDataSet1 = objCantidadesDet_Oc.usp_TraerCantArtSolicitados(Txt_Marca.Text, Txt_Proveedor.Text, Estilon, Corrida, Medida)
                                                If objDataSet1.Tables(0).Rows.Count > 0 Then
                                                    Cantidad = Val(objDataSet1.Tables(0).Rows(0).Item("ctd"))
                                                    Costo = Val(objDataSet1.Tables(0).Rows(0).Item("costo"))
                                                    Pcomp = Val(objDataSet1.Tables(0).Rows(0).Item("costdesc"))


                                                Else
                                                    Pcomp = 0
                                                    Costo = 0

                                                    Cantidad = 0
                                                End If
                                                '    DGrid.Rows(Renglon).Cells("pcomp").Value = Format(Val(Pcomp), "#,##0.00")
                                                '   DGrid.Rows(Renglon).Cells("costo").Value = Format(Val(Costo), "#,##0.00")

                                                DGrid.Rows(Renglon).Cells(I).Value = Format(Val(Cantidad), "#,##0")
                                            End Using
                                        Else
                                            Using objCantidadesDet_Oc As New BCL.BCLPedidos(GLB_ConStringCipSis)
                                                'objDataSet1 = objCantidadesDet_Oc.usp_TraerCantidadesDet_FP(Txt_Sucursal.Text, Txt_OrdeComp.Text, Txt_Marca.Text, Estilon, Corrida, Medida)
                                                If objDataSet1.Tables(0).Rows.Count > 0 Then
                                                    Cantidad = Val(objDataSet1.Tables(0).Rows(0).Item("ctd"))
                                                    Costo = Val(objDataSet1.Tables(0).Rows(0).Item("costo"))
                                                    Pcomp = Val(objDataSet1.Tables(0).Rows(0).Item("costdesc"))


                                                Else
                                                    Pcomp = 0
                                                    Costo = 0

                                                    Cantidad = 0
                                                End If
                                                '  DGrid.Rows(Renglon).Cells("pcomp").Value = Format(Val(Pcomp), "#,##0.00")
                                                ' DGrid.Rows(Renglon).Cells("costo").Value = Format(Val(Costo), "#,##0.00")

                                                DGrid.Rows(Renglon).Cells(I).Value = Format(Val(Cantidad), "#,##0")
                                            End Using
                                        End If
                                    End If
                                End If


                            End With
                        Next
                    Next
                End If
            End Using

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub TraerCorridasSelect(ByVal Renglon As Integer)
        'miguel perez 11/Septiembre/2012 01:15 p.m.

        Try
            Dim i As Integer = 0
            Dim Cont As Integer = 1
            Dim Renglon1 As Integer = 0
            Dim intCantidad As Integer = 0
            'Colores = Colores + 1

            'Residuo = Colores Mod 2

            'DGrid.Rows(Renglon).Cells("csuc").Value = SucSelect(0)
            'DGrid.Rows(Renglon).Cells("sucdescrip").Value = pub_TraerNomSucursal(SucSelect(0))
            Renglon1 = Renglon
            Using objTrack As New BCL.BCLTrackCoqueta(GLB_ConStringCipSis)
                objDataSet = objTrack.usp_TraerCantidadCorridas("CTA", DGrid.Rows(Renglon).Cells(1).Value, DGrid.Rows(Renglon).Cells(3).Value)
            End Using
            intCantidad = CInt(objDataSet.Tables(0).Rows.Count)
            For i = 1 To intCantidad - 1

                If i = 1 Then
                    Dim objDataSet1 As New Data.DataSet
                    Using objTrack2 As New BCL.BCLTrackCoqueta(GLB_ConStringCipSis)
                        objDataSet1 = objTrack2.usp_TraerTrackCta(DGrid.Rows(Renglon).Cells("estilonuestro").Value, _
                                                   DGrid.Rows(Renglon).Cells("estilofabrica").Value, _
                                                   objDataSet.Tables(0).Rows(Cont - 1).Item("Medida").ToString)
                    End Using
                    If objDataSet1.Tables(0).Rows.Count > 0 Then
                        If Renglon = 0 Then
                            DGrid.Rows(Renglon).Cells("SKU").Value = objDataSet1.Tables(0).Rows(0).Item("SKU").ToString
                            DGrid.Rows(Renglon).Cells("Selec").Value = CBool(objDataSet1.Tables(0).Rows(0).Item("Estatus").ToString)
                            DGrid.Rows(Renglon).Cells("Track").Value = 1
                        End If
                    Else
                        DGrid.Rows(Renglon).Cells("Track").Value = 0
                    End If
                End If

                If i = 1 And Renglon <> 0 Then
                    'agregar renglon 
                    'copiar el renglon al siguiente... 
                    DGrid.Rows.Add()

                    DGrid.Rows(Renglon).ReadOnly = False
                    DGrid.Rows(Renglon).DefaultCellStyle.BackColor = Color.PowderBlue
                    Renglon = Renglon + 1
                    ' copiar 
                    'DGrid.Rows(Renglon).Cells("ta").Value = DGrid.Rows(Renglon - 1).Cells("ta").Value
                    'DGrid.Rows(Renglon).Cells("fam").Value = DGrid.Rows(Renglon - 1).Cells("fam").Value
                    'DGrid.Rows(Renglon).Cells("cat").Value = DGrid.Rows(Renglon - 1).Cells("cat").Value
                    'DGrid.Rows(Renglon).Cells("lin").Value = DGrid.Rows(Renglon - 1).Cells("lin").Value
                    DGrid.Rows(Renglon).Cells("descripcion").Value = DGrid.Rows(Renglon - 1).Cells("descripcion").Value
                    DGrid.Rows(Renglon).Cells("estilonuestro").Value = DGrid.Rows(Renglon - 1).Cells("estilonuestro").Value
                    DGrid.Rows(Renglon).Cells("estilofabrica").Value = DGrid.Rows(Renglon - 1).Cells("estilofabrica").Value
                    'DGrid.Rows(Renglon).Cells("csuc").Value = SucSelect(i - 1)
                    'DGrid.Rows(Renglon).Cells("sucdescrip").Value = pub_TraerNomSucursal(SucSelect(i - 1))
                    DGrid.Rows(Renglon).Cells("c").Value = DGrid.Rows(Renglon - 1).Cells("c").Value
                    DGrid.Rows(Renglon).Cells("i").Value = DGrid.Rows(Renglon - 1).Cells("i").Value

                    DGrid.Rows(Renglon).Cells("de").Value = objDataSet.Tables(0).Rows(Cont - 1).Item("Medida").ToString

                    Dim objDataSet3 As New Data.DataSet
                    Using objTrack3 As New BCL.BCLTrackCoqueta(GLB_ConStringCipSis)
                        objDataSet3 = objTrack3.usp_TraerTrackCta(DGrid.Rows(Renglon - 1).Cells("estilonuestro").Value, _
                                                   DGrid.Rows(Renglon - 1).Cells("estilofabrica").Value, _
                                                   objDataSet.Tables(0).Rows(Cont - 1).Item("Medida").ToString)
                    End Using
                    If objDataSet3.Tables(0).Rows.Count > 0 Then
                        DGrid.Rows(Renglon).Cells("SKU").Value = objDataSet3.Tables(0).Rows(0).Item("SKU").ToString
                        DGrid.Rows(Renglon).Cells("Selec").Value = CBool(objDataSet3.Tables(0).Rows(0).Item("Estatus").ToString)
                        DGrid.Rows(Renglon).Cells("Track").Value = 1
                    Else
                        DGrid.Rows(Renglon).Cells("Track").Value = 0
                    End If
                    'DGrid.Rows(Renglon).Cells("de").Value = DGrid.Rows(Renglon - 1).Cells("de").Value
                    'DGrid.Rows(Renglon).Cells("a").Value = DGrid.Rows(Renglon - 1).Cells("a").Value

                    'DGrid.Rows(Renglon).Cells("pcomp").Value = DGrid.Rows(Renglon - 1).Cells("pcomp").Value
                    'DGrid.Rows(Renglon).Cells("precio").Value = DGrid.Rows(Renglon - 1).Cells("precio").Value
                    'DGrid.Rows(Renglon).Cells("costo").Value = DGrid.Rows(Renglon - 1).Cells("costo").Value
                    'DGrid.Rows(Renglon).Cells("porc").Value = DGrid.Rows(Renglon - 1).Cells("porc").Value

                    'For j As Integer = 24 To 123
                    '    DGrid.Rows(Renglon).Cells(j).Style.BackColor = DGrid.Rows(Renglon - 1).Cells(j).Style.BackColor
                    '    DGrid.Rows(Renglon - 1).Cells(j).Style.BackColor = Color.PowderBlue
                    'Next

                    'DGrid.Rows(Renglon - 1).Cells("ta").Value = ""
                    'DGrid.Rows(Renglon - 1).Cells("fam").Value = ""
                    'DGrid.Rows(Renglon - 1).Cells("cat").Value = ""
                    'DGrid.Rows(Renglon - 1).Cells("lin").Value = ""
                    DGrid.Rows(Renglon - 1).Cells("descripcion").Value = ""
                    DGrid.Rows(Renglon - 1).Cells("estilonuestro").Value = ""
                    DGrid.Rows(Renglon - 1).Cells("estilofabrica").Value = ""
                    'DGrid.Rows(Renglon - 1).Cells("csuc").Value = ""
                    'DGrid.Rows(Renglon - 1).Cells("sucdescrip").Value = ""
                    DGrid.Rows(Renglon - 1).Cells("c").Value = ""
                    DGrid.Rows(Renglon - 1).Cells("i").Value = ""

                    DGrid.Rows(Renglon - 1).Cells("de").Value = ""
                    DGrid.Rows(Renglon - 1).Cells("Track").Value = ""
                    'DGrid.Rows(Renglon - 1).Cells("a").Value = ""
                    'DGrid.Rows(Renglon - 1).Cells("pcomp").Value = ""
                    'DGrid.Rows(Renglon - 1).Cells("precio").Value = ""
                    'DGrid.Rows(Renglon - 1).Cells("costo").Value = ""
                    'DGrid.Rows(Renglon - 1).Cells("porc").Value = ""
                    DGrid.Rows(Renglon - 1).ReadOnly = False
                    'DGrid.Rows(Renglon - 1).DefaultCellStyle.BackColor = Color.PowderBlue
                End If
                DGrid.Rows.Add()
                'DGrid.Rows(Renglon + Cont).Cells("ta").Value = DGrid.Rows(Renglon).Cells("ta").Value
                'DGrid.Rows(Renglon + Cont).Cells("fam").Value = DGrid.Rows(Renglon).Cells("fam").Value
                'DGrid.Rows(Renglon + Cont).Cells("cat").Value = DGrid.Rows(Renglon).Cells("cat").Value
                'DGrid.Rows(Renglon + Cont).Cells("lin").Value = DGrid.Rows(Renglon).Cells("lin").Value
                DGrid.Rows(Renglon + Cont).Cells("descripcion").Value = DGrid.Rows(Renglon).Cells("descripcion").Value
                DGrid.Rows(Renglon + Cont).Cells("estilonuestro").Value = DGrid.Rows(Renglon).Cells("estilonuestro").Value
                DGrid.Rows(Renglon + Cont).Cells("estilofabrica").Value = DGrid.Rows(Renglon).Cells("estilofabrica").Value
                'DGrid.Rows(Renglon + Cont).Cells("csuc").Value = SucSelect(i)
                'DGrid.Rows(Renglon + Cont).Cells("sucdescrip").Value = pub_TraerNomSucursal(SucSelect(i))
                DGrid.Rows(Renglon + Cont).Cells("c").Value = DGrid.Rows(Renglon).Cells("c").Value
                DGrid.Rows(Renglon + Cont).Cells("i").Value = DGrid.Rows(Renglon).Cells("i").Value

                DGrid.Rows(Renglon + Cont).Cells("de").Value = objDataSet.Tables(0).Rows(Cont).Item("Medida").ToString
                Dim objDataSet2 As New Data.DataSet
                Using objTrack2 As New BCL.BCLTrackCoqueta(GLB_ConStringCipSis)
                    objDataSet2 = objTrack2.usp_TraerTrackCta(DGrid.Rows(Renglon).Cells("estilonuestro").Value, _
                                               DGrid.Rows(Renglon).Cells("estilofabrica").Value, _
                                               objDataSet.Tables(0).Rows(Cont).Item("Medida").ToString)
                End Using
                If objDataSet2.Tables(0).Rows.Count > 0 Then
                    DGrid.Rows(Renglon + Cont).Cells("SKU").Value = objDataSet2.Tables(0).Rows(0).Item("SKU").ToString
                    DGrid.Rows(Renglon + Cont).Cells("Selec").Value = CBool(objDataSet2.Tables(0).Rows(0).Item("Estatus").ToString)
                    DGrid.Rows(Renglon + Cont).Cells("Track").Value = 1
                Else
                    DGrid.Rows(Renglon + Cont).Cells("Track").Value = 0
                End If
                'DGrid.Rows(Renglon + Cont).Cells("de").Value = DGrid.Rows(Renglon).Cells("de").Value
                'DGrid.Rows(Renglon + Cont).Cells("a").Value = DGrid.Rows(Renglon).Cells("a").Value
                'DGrid.Rows(Renglon + Cont).Cells("pcomp").Value = DGrid.Rows(Renglon).Cells("pcomp").Value
                'DGrid.Rows(Renglon + Cont).Cells("precio").Value = DGrid.Rows(Renglon).Cells("precio").Value
                'DGrid.Rows(Renglon + Cont).Cells("costo").Value = DGrid.Rows(Renglon).Cells("costo").Value
                'DGrid.Rows(Renglon + Cont).Cells("porc").Value = DGrid.Rows(Renglon).Cells("porc").Value

                'For j As Integer = 24 To 123
                '    DGrid.Rows(Renglon + Cont).Cells(j).Style.BackColor = DGrid.Rows(Renglon).Cells(j).Style.BackColor
                'Next


                '' si residuo es 1 es impar sino es par 
                'For J As Integer = 0 To 20
                '    ' Color.Bisque  Color.Beige
                '    DGrid.Rows(Renglon).Cells(J).Style.BackColor = IIf(Residuo = 1, Color.Salmon, Color.SandyBrown)
                '    DGrid.Rows(Renglon + Cont).Cells(J).Style.BackColor = IIf(Residuo = 1, Color.Salmon, Color.SandyBrown)
                'Next
                'For J As Integer = 125 To 126
                '    DGrid.Rows(Renglon).Cells(J).Style.BackColor = IIf(Residuo = 1, Color.Salmon, Color.SandyBrown)
                '    DGrid.Rows(Renglon + Cont).Cells(J).Style.BackColor = IIf(Residuo = 1, Color.Salmon, Color.SandyBrown)
                'Next

                Cont = Cont + 1
            Next

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub AgregarColumna()
        'mreyes 21/Marzo/2012 09:52 a.m.
        Try
            Dim colImagen As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
            colImagen.Name = "Selec"
            colImagen.HeaderText = "Selec"
            colImagen.DisplayIndex = 15
            colImagen.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            colImagen.CellTemplate = New DataGridViewCheckBoxCell()
            ' añadir columna de imagen a la coleccion del grid 
            DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            ''DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
            Me.DGrid.Columns.Add(colImagen)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Espacios(ByVal strLetras As String, ByRef strEspacios As String)
        'miguel pérez 11/septiembre/2012 6:00 p.m.
        Try
            If strLetras.Length = 1 Then
                strEspacios = "      "
            ElseIf strLetras.Length = 2 Then
                strEspacios = "     "
            ElseIf strLetras.Length = 3 Then
                strEspacios = "    "
            ElseIf strLetras.Length = 4 Then
                strEspacios = "   "
            ElseIf strLetras.Length = 5 Then
                strEspacios = "  "
            ElseIf strLetras.Length = 6 Then
                strEspacios = " "
            ElseIf strLetras.Length = 7 Then
                strEspacios = ""
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
#End Region

    Private Sub DGrid_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DGrid.KeyPress
        Try
            e.KeyChar = UCase(e.KeyChar)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        Dim sku As String
        Dim EstiloN As String
        Dim EstiloF As String
        Dim Medida As String
        Dim Estatus As String
        Dim blnCorrecto As Boolean = False
        Dim intCon As Integer = 0
        Try
            Dim objDataSet3 As New Data.DataSet
            If MessageBox.Show("Esta seguro de realizar los cambios?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            Else
                For j As Integer = 0 To DGrid.Rows.Count - 2
                    blnCorrecto = False
                    sku = ""
                    EstiloN = ""
                    EstiloF = ""
                    Medida = ""
                    Estatus = ""
                    If DGrid.Rows(j).Cells("Track").Value.ToString <> "" Then
                        If DGrid.Rows(j).Cells("Track").Value = 1 Then
                            'Es cuando el estilo y la medida existe en el track
                            sku = DGrid.Rows(j).Cells("SKU").Value
                            EstiloN = DGrid.Rows(j).Cells("estilonuestro").Value
                            EstiloF = DGrid.Rows(j).Cells("estilofabrica").Value
                            Medida = DGrid.Rows(j).Cells("de").Value
                            Estatus = CInt(DGrid.Rows(j).Cells("selec").Value) * -1
                            If sku = "" Then
                                MessageBox.Show("El campo SKU esta vacio en la medida " + Medida.Trim + " y no se guardo", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Else
                                Using objTrack As New BCL.BCLTrackCoqueta(GLB_ConStringCipSis)
                                    objDataSet3 = objTrack.usp_TraerSKU(sku)
                                End Using
                                If objDataSet3.Tables(0).Rows.Count > 0 Then
                                    If objDataSet3.Tables(0).Rows(0).Item("estilon").ToString = EstiloN And _
                                    objDataSet3.Tables(0).Rows(0).Item("medida").ToString.Trim = Medida And _
                                    objDataSet3.Tables(0).Rows(0).Item("sku").ToString.Trim = sku Then
                                        Using objTrack As New BCL.BCLTrackCoqueta(GLB_ConStringCipSis)
                                            blnCorrecto = objTrack.usp_ActualizarTrackCta(sku, EstiloN, EstiloF, Medida, Estatus)
                                            If blnCorrecto = True Then
                                                intCon += 1
                                            End If
                                        End Using
                                    Else
                                        MessageBox.Show("El SKU insertado para el EstiloN " + EstiloN.Trim + ", y la medida " + Medida.Trim + " ya existe y no se modifico", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    End If
                                Else
                                    Using objTrack As New BCL.BCLTrackCoqueta(GLB_ConStringCipSis)
                                        blnCorrecto = objTrack.usp_ActualizarTrackCta(sku, EstiloN, EstiloF, Medida, Estatus)
                                        If blnCorrecto = True Then
                                            intCon += 1
                                        End If
                                    End Using
                                End If
                            End If
                        Else
                            'Es cuando el estilo o la medida no existe en el track
                            If DGrid.Rows(j).Cells("SKU").Value = "" And DGrid.Rows(j).Cells("estilonuestro").Value = "" And _
                            DGrid.Rows(j).Cells("estilofabrica").Value = "" And DGrid.Rows(j).Cells("de").Value = "" Then
                            Else
                                sku = DGrid.Rows(j).Cells("SKU").Value
                                EstiloN = DGrid.Rows(j).Cells("estilonuestro").Value
                                EstiloF = DGrid.Rows(j).Cells("estilofabrica").Value
                                Medida = DGrid.Rows(j).Cells("de").Value
                                Estatus = CInt(DGrid.Rows(j).Cells("selec").Value) * -1
                                If sku = "" Then
                                    MessageBox.Show("El campo SKU esta vacio en la medida " + Medida.Trim + " y NO se guardo", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Else
                                    Using objTrack As New BCL.BCLTrackCoqueta(GLB_ConStringCipSis)
                                        objDataSet3 = objTrack.usp_TraerSKU(sku)
                                    End Using
                                    If objDataSet3.Tables(0).Rows.Count > 0 Then
                                        MessageBox.Show("El SKU insertado para el EstiloN " + EstiloN.Trim + ", y la medida " + Medida.Trim + " ya existe, por favor elige otro", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Else
                                        Using objTrack As New BCL.BCLTrackCoqueta(GLB_ConStringCipSis)
                                            blnCorrecto = objTrack.usp_CapturaTrackCta(sku, EstiloN, EstiloF, Medida, Estatus)
                                            If blnCorrecto = True Then
                                                intCon += 1
                                            End If
                                            DGrid.Rows(j).Cells("Track").Value = 1
                                        End Using
                                    End If
                                End If
                            End If
                        End If
                    End If
                Next
                If intCon > 0 Then
                    MessageBox.Show("Track guardado correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("No se realizo ningun cambio", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGrid.EditingControlShowing
        Dim validar As TextBox = CType(e.Control, TextBox)
        Try
            ' agregar el controlador de eventos para el KeyPress   
            AddHandler validar.KeyPress, AddressOf validar_Keypress
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Try
            e.KeyChar = UCase(e.KeyChar)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Invertir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Invertir.Click
        Try
            For Each row As DataGridViewRow In DGrid.Rows
                If row.Cells("Selec").Value = True Then
                    row.Cells("Selec").Value = False
                Else
                    row.Cells("Selec").Value = True
                End If
            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Try
            If MessageBox.Show("Estas seguro de cancelar los cambios ?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                Me.Dispose()
                Me.Close()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Excel.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            If ExportarDGridAExcel(DGrid) = False Then
                MsgBox("Error al exportar a Excel. Intente nuevamente.", MsgBoxStyle.Critical, "Excel")
            End If
            Me.Cursor = Cursors.Default
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmCoquetaTrack_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim objDataSet1 As Data.DataSet
        Try
            DGrid.RowHeadersVisible = False
            Using objTrack2 As New BCL.BCLTrackCoqueta(GLB_ConStringCipSis)
                objDataSet1 = objTrack2.usp_TraerDescripTrackCTA()
            End Using
            AgregarColumna()
            For j As Integer = 0 To objDataSet1.Tables(0).Rows.Count - 1
                DGrid.Rows.Add()
                DGrid.Rows(j).Cells("estilofabrica").Value = objDataSet1.Tables(0).Rows(j).Item("EstiloFabrica")
                DGrid.Rows(j).Cells("estilonuestro").Value = objDataSet1.Tables(0).Rows(j).Item("EstiloNuestro")
                DGrid.Rows(j).Cells("Descripcion").Value = objDataSet1.Tables(0).Rows(j).Item("Descripcion")
                DGrid.Rows(j).Cells("C").Value = objDataSet1.Tables(0).Rows(j).Item("C")
                DGrid.Rows(j).Cells("De").Value = objDataSet1.Tables(0).Rows(j).Item("Medida")
                DGrid.Rows(j).Cells("SKU").Value = objDataSet1.Tables(0).Rows(j).Item("SKU")
                DGrid.Rows(j).Cells("Track").Value = 1
                DGrid.Rows(j).Cells("Selec").Value = CBool(objDataSet1.Tables(0).Rows(j).Item("Estatus"))
            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmCoquetaTrack_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Foto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Foto.Click
        Try
            Dim myForm As New frmConsultaImagen
            myForm.Txt_Estilon.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("estilonuestro").Value.ToString
            myForm.Txt_Marca.Text = "CTA"
            myForm.Txt_NoFoto.Text = "1"
            myForm.ShowDialog()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick
        Try
            'Btn_Foto_Click(sender, e)
            Dim myForm As New frmCatalogoEstilos
            myForm.Accion = 4
            myForm.Txt_Marca.Text = "CTA"
            myForm.Txt_Estilon.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("estilonuestro").Value.ToString
            myForm.ShowDialog()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Bot_Layout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bot_Layout.Click
        Dim objDataSet1 As Data.DataSet
        Try
            If MsgBox("Esta seguro de querer generar el layout para todas las sucursales?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmación") = MsgBoxResult.No Then Exit Sub

            Dim Archivo As String = ""
            Dim Linea As String = ""
            Dim strSKU As String = ""
            Dim strPares As String = ""
            Dim strCliente As String = ""
            Dim strSucursalCTA As String = ""
            Dim FecLayout As String = ""
            Dim strFecha As String = ""
            Dim strFechaTitulo As String = ""
            Dim Sucursal As String = ""
            strFecha = Now.Date.ToString("yyyy-MM-dd")
            strFechaTitulo = strFecha.Substring(0, 4)
            strFechaTitulo += strFecha.Substring(5, 2)
            strFechaTitulo += strFecha.Substring(8, 2)
            Using objTrack As New BCL.BCLTrackCoqueta(GLB_ConStringCipSis)
                objDataSet1 = objTrack.usp_TiendasCTA()
            End Using
            Dim contador As Integer = 0
            For j As Integer = 0 To objDataSet1.Tables(0).Rows.Count - 1
                Sucursal = objDataSet1.Tables(0).Rows(j).Item("sucursal")
                strSucursalCTA = objDataSet1.Tables(0).Rows(j).Item("tienda")
                Using objTrack As New BCL.BCLTrackCoqueta(GLB_ConStringCipSis)
                    objDataSet = objTrack.usp_TraerLayoutCTA(strFecha, Sucursal)
                End Using

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Archivo = "C:\V" & strFechaTitulo.Trim & strSucursalCTA & ".txt"
                    Dim sw As New System.IO.StreamWriter(Archivo)
                    For i As Integer = 1 To objDataSet.Tables(0).Rows.Count
                        strSKU = objDataSet.Tables(0).Rows(i - 1).Item("SKU").ToString & ","
                        strPares = objDataSet.Tables(0).Rows(i - 1).Item("Pares").ToString & ","
                        strCliente = "3934" & ","
                        Linea = strSKU & strPares & strCliente & strSucursalCTA
                        sw.WriteLine(Linea)
                    Next
                    sw.Close()
                    Dim NombreArchivo As String = Archivo.Substring(3, 19)
                    'My.Computer.Network.UploadFile(Archivo, "ftp://ftp.coqueta.com.mx/" & NombreArchivo, "ctorreon", "clte3934@93", True, 500)
                    contador += 1
                End If
            Next

            MessageBox.Show("Layout Generado para " + contador.ToString + " sucursal(es)", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub
End Class