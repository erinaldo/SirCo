Public Class frmPpalAparadorReal
    'mreyes 29/Abril/2015   09:49 a.m.

    Dim Sw_Load As Boolean = False
    Private objDataSet As Data.DataSet
    Public Opcion As Integer = 0
    'Public OpcionAntMarca As Integer = 0
    Public Sucursal As String = ""
    Public Division As String = ""
    Public Depto As String = ""
    Public Familia As String = ""
    Public Linea As String = ""
    Public L1 As String = ""
    Public L2 As String = ""
    Public L3 As String = ""
    Public L4 As String = ""
    Public L5 As String = ""
    Public L6 As String = ""
    Public Marca As String = ""
    Public Modelo As String = ""
    Dim MarcaFOTO As String = ""
    Dim EstiloNFOTO As String = ""
    Dim DescripSucursal As String = ""
    Dim checkInicio As Boolean = False
    Private izquierda As Integer = 0
    Private alto As Integer = 0
    Dim blnBorroCol As Boolean = False
    Dim myFormFiltros As frmFiltrosAparadorReal
    Public Accion As Integer = 0
    'Accion 1 = Antiguedad ----- Accion 2 = Inventario
    Dim blnEntro As Boolean = False
    Public blnActualizando As Boolean = False
    Dim arreglo(100) As Integer
    Dim intPosicion As Integer = 0
    Public DiasIni As Integer = 0
    Public DiasFin As Integer = 0
    Dim blnDias As Boolean = False
    Dim blnEsTotal As Boolean = False
    Dim Marca1 As String = ""
    Dim blnMar As Boolean = False
    Dim blnNoEsTot As Boolean = False
    Dim Opcion2 As Integer = 1

    Dim FecHora As Date
    Dim FechaInv As String = ""
    Dim NomTablaExist As String = ""
    Dim strQueryInv As String = ""
    Public Sw_Mas250 As Boolean = False


    Private Sub frmPpalNomina_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            If blnEntro = False Then
                blnEntro = True
                Chk_Calzado.Checked = True

            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmPpalProveedores_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then
                Me.Close()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmPpalProveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sw_load = True
        If Sw_Mas250 = False Then
            If Accion = 0 Then Accion = 1
            If Opcion = 0 Then
                Opcion = 1
            End If
       

        End If
        Call RellenaGrid()
        myFormFiltros = New frmFiltrosAparadorReal
        'Chk_Calzado.Checked = True
        'RB_SinLerdo.Checked = True
        'myFormFiltros = New frmFiltrosVentasDWH
       
    End Sub

    Private Sub RellenaGrid()
        If Chk_Calzado.Checked Then
            Division = "CALZADO"
        End If
        Me.Cursor = Cursors.WaitCursor
        ''
       
        If Accion = 1 Then
            Using objRegistro As New BCL.BCLAntiInvent(GLB_ConStringCipSis)
                objDataSet = objRegistro.usp_PpalInventarioTiendasEstructura(Opcion, 0, Sucursales(), Division, Depto, Familia, Linea, L1, L2, L3, L4, L5, L6, Marca, Modelo, DiasIni, DiasFin, Opcion2)
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                DGrid.DataSource = Nothing
                DGrid.DataSource = objDataSet.Tables(0)
                If Opcion <> 13 Then
                    InicializaGrid()
                Else
                    InicializaGridModelos()
                End If
                UltimaModificacion()
                'Componentes()
                GeneraTexto()
                OcultarToolStrips()
            Else
                'OpcionAntMarca = Opcion
                Opcion = 12
                Using objRegistro As New BCL.BCLAntiInvent(GLB_ConStringCipSis)
                    objDataSet = objRegistro.usp_PpalInventarioTiendasEstructura(Opcion, 0, Sucursales(), Division, Depto, Familia, Linea, L1, L2, L3, L4, L5, L6, Marca, Modelo, 0, 0, Opcion2)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    DGrid.DataSource = Nothing
                    DGrid.DataSource = objDataSet.Tables(0)
                    InicializaGrid()
                    UltimaModificacion()
                    ' Componentes()
                    GeneraTexto()
                    OcultarToolStrips()
                Else
                    MessageBox.Show("No se encontro la información solicitada", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        End If
        If Accion = 2 Then

            '    Sucursal = GLB_CveSucursal
            Using objRegistro As New BCL.BCLAparador(GLB_ConStringCipSis)
                objDataSet = objRegistro.usp_TraerAparadorReal(Opcion, Sucursales(), Division, Depto, Familia, Linea, L1, L2, L3, L4, L5, L6, Marca, Modelo, strQueryInv)
            End Using
        
            If objDataSet.Tables(0).Rows.Count > 0 Then

                If Opcion <> 14 Then
                    DGrid.DataSource = Nothing
                    DGrid.DataSource = objDataSet.Tables(0)
                    InicializaGridInventario()
                Else

                    If DGrid.CurrentRow.Cells("Marca").Value <> "TOTAL: " Then

                        DGrid.DataSource = Nothing
                        DGrid.DataSource = objDataSet.Tables(0)
                        RellenarCorridas(0, objDataSet)
                    Else

                        Dim objDataSetAux As New DataSet


                        objDataSetAux = objDataSet.Clone()
                        DGrid.DataSource = Nothing
                        DGrid.DataSource = objDataSetAux.Tables(0)


                        RellenarCorridas(0, objDataSet)

                        DGrid.DataSource = objDataSet.Tables(0)

                        For n As Integer = 0 To DGrid.Rows.Count - 1
                            For i As Integer = 5 To 104
                                If DGrid.Rows(n).Cells(i).Value = 0 Then
                                    DGrid.Rows(n).Cells(i).Style.ForeColor = Color.White
                                End If
                            Next
                        Next


                        'For i As Integer = 5 To 104
                        '    If pub_SumarColumnaGridNombre(DGrid, DGrid.Columns(i).Name, DGrid.RowCount - 1) = 0 Then
                        '        DGrid.Columns(i).Visible = False
                        '    End If
                        'Next

                        Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)

                        Dim row As DataRow = dt.NewRow()

                        row(3) = "TOTAL: "

                        row("pares") = pub_SumarColumnaGridNombre(DGrid, "pares", DGrid.RowCount - 1)
                        row("porc") = pub_SumarColumnaGridNombre(DGrid, "porc", DGrid.RowCount - 1)

                        row("precio") = pub_SumarColumnaGridNombre(DGrid, "precio", DGrid.RowCount - 1)

                        For i As Integer = 4 To 104
                            row(i) = pub_SumarColumnaGridNombre(DGrid, DGrid.Columns(i + 1).Name, DGrid.RowCount - 1)
                            If row(i) = 0 Then
                                DGrid.Columns(i + 1).Visible = False
                            End If
                        Next

                        dt.Rows.InsertAt(row, 0)

                        DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

                        DGrid.Rows(0).Frozen = True
                        DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
                        DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                        DGrid.Columns(1).Frozen = True
                        DGrid.Columns(1).DefaultCellStyle.BackColor = Color.PowderBlue
                        DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        DGrid.Columns(1).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)


                        DGrid.Columns(2).Frozen = True
                        DGrid.Columns(2).DefaultCellStyle.BackColor = Color.PowderBlue
                        DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        DGrid.Columns(2).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                        DGrid.Columns(3).Frozen = True
                        DGrid.Columns(3).DefaultCellStyle.BackColor = Color.PowderBlue
                        DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        DGrid.Columns(3).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)


                        DGrid.Columns(4).Frozen = True
                        DGrid.Columns(4).DefaultCellStyle.BackColor = Color.PowderBlue
                        DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        DGrid.Columns(4).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                       

                        If blnBorroCol = True Then
                            DGrid.Columns.Remove(DGrid.Columns("renglon"))
                        End If
                        blnBorroCol = True
                        AgregarColumna()
                        For i As Integer = 1 To DGrid.Rows.Count - 2
                            DGrid.Rows(i).Cells("Renglon").Value = i.ToString
                        Next

                    End If

                End If


                UltimaModificacion()
                'Componentes()
                GeneraTexto()
                OcultarToolStrips()
            Else
                'OpcionAntMarca = Opcion
                Opcion = 12
                Using objRegistro As New BCL.BCLAparador(GLB_ConStringCipSis)
                    objDataSet = objRegistro.usp_TraerAparadorReal(Opcion, Sucursales(), Division, Depto, Familia, Linea, L1, L2, L3, L4, L5, L6, Marca, Modelo, strQueryInv)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    DGrid.DataSource = Nothing
                    DGrid.DataSource = objDataSet.Tables(0)
                    InicializaGridInventario()
                    UltimaModificacion()
                    '  Componentes()
                    GeneraTexto()
                    OcultarToolStrips()
                Else
                    MessageBox.Show("No se encontro la información solicitada", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        End If
        Me.Cursor = Cursors.Default
        Sw_Load = False
    End Sub

    Public Sub RellenarCorridas(ByVal Renglon As Integer, ByVal dataset As Data.DataSet)
        Try
            Dim objDataSet1 As Data.DataSet
            Dim Marca1 As String = Marca
            Dim Estilon1 As String = Modelo
            Dim MedIni As Integer = 0
            Dim MedFin As Integer = 0
            Dim MI As String = ""
            Dim MF As String = ""
            Dim Intervalo As String = ""
            Dim Inc As Integer = 0


            If blnNoEsTot = True Then
                'If Marca <> "" AndAlso blnNoEsTot = True Then 'blnMar = True Then

                Using objCorrida As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                    objDataSet1 = objCorrida.usp_TraerCorrida(Marca1, Estilon1, "", "")
                End Using

                For i As Integer = 5 To 104
                    DGrid.Columns(i).Visible = False
                    DGrid.Columns(i).DefaultCellStyle.BackColor = Color.Khaki
                Next

                For n As Integer = 0 To DGrid.Rows.Count - 1
                    For i As Integer = 5 To 104
                        If DGrid.Rows(n).Cells(i).Value = 0 Then
                            DGrid.Rows(n).Cells(i).Style.ForeColor = Color.Khaki
                        Else
                            DGrid.Columns(i).Visible = True
                        End If
                    Next
                Next

                If objDataSet1.Tables(0).Rows.Count > 0 Then
                    For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                        'If IsDBNull(objDataSet.Tables(0).Rows(i).Item("medini")) Then
                        '    Continue For
                        'End If
                        If objDataSet1.Tables(0).Rows(i).Item("medini").ToString.Trim = "CH" Or _
                            objDataSet1.Tables(0).Rows(i).Item("medini").ToString.Trim = "MED" Or _
                            objDataSet1.Tables(0).Rows(i).Item("medini").ToString.Trim = "GDE" Or _
                            objDataSet1.Tables(0).Rows(i).Item("medini").ToString.Trim = "XGE" Or _
                            objDataSet1.Tables(0).Rows(i).Item("medini").ToString.Trim = "XXG" Or _
                            objDataSet1.Tables(0).Rows(i).Item("medfin").ToString.Trim = "27E" Then
                            Continue For
                        End If

                        MedIni = Val(objDataSet1.Tables(0).Rows(i).Item("medini").ToString)
                        MedFin = Val(objDataSet1.Tables(0).Rows(i).Item("medfin").ToString)
                        MI = objDataSet1.Tables(0).Rows(i).Item("medini").ToString
                        MF = objDataSet1.Tables(0).Rows(i).Item("medfin").ToString

                        Intervalo = objDataSet1.Tables(0).Rows(i).Item("intervalo").ToString


                        For MedIni = Val(objDataSet1.Tables(0).Rows(i).Item("medini").ToString) To MedFin
                            Dim NombreColumna As String

                            If Intervalo <> "-" Then
                                If Intervalo = CStr(1) Then
                                    Inc = Intervalo
                                Else
                                    Inc = 1
                                End If
                            Else
                                Inc = 1
                            End If


                            If MedIni = Val(MI) Then
                                If MI.Substring(MI.Length - 1, 1) <> "-" Then
                                    NombreColumna = TraerNombreColumna(MedIni.ToString)
                                    DGrid.Columns(NombreColumna).Visible = True

                                End If
                            Else
                                NombreColumna = TraerNombreColumna(MedIni.ToString)
                                DGrid.Columns(NombreColumna).Visible = True

                            End If
                            If Intervalo = "-" Then
                                If MF = CStr(MedIni) Then
                                    'If MedFin.Substring(MedFin.Length - 1, 1) = "-" Then
                                    '    Call Inserta_Medida("N", pub_RellenarIzquierda(MI, 2) + Intervalo, I)
                                    'End If
                                Else
                                    NombreColumna = TraerNombreColumna(MedIni.ToString + "-")
                                    DGrid.Columns(NombreColumna).Visible = True
                                End If
                            End If
                            MedIni = MedIni + Inc - 1

                        Next
                    Next

                    Btn_Foto.Enabled = True
                    Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)

                    Dim row As DataRow = dt.NewRow()

                    row(3) = "TOTAL: "

                    ' row("pares") = pub_SumarColumnaGridNombre(DGrid, "pares", DGrid.RowCount - 1)

                    dt.Rows.InsertAt(row, 0)
                    DGrid.DataSource = dt

                    For i As Integer = 4 To 104
                        row(i) = pub_SumarColumnaGridNombre(DGrid, DGrid.Columns(i + 1).Name, DGrid.RowCount - 1)
                        If row(i) = 0 Then
                            DGrid.Columns(i + 1).Visible = False
                        End If
                    Next

                    DGrid.Columns("marca").HeaderText = "Marca"
                    DGrid.Columns("modelo").HeaderText = "Modelo"
                    DGrid.Columns("estilof").HeaderText = "Estilo Fabrica"
                    DGrid.Columns("Descripc").HeaderText = "Descripción"
                    DGrid.Columns("pares").HeaderText = "Pares"
                    DGrid.Columns("porc").HeaderText = "%"
                    DGrid.Columns("costoc").HeaderText = "Costo C/IVA"
                    DGrid.Columns("precioc").HeaderText = "Precio C/IVA"
                    DGrid.Columns("costo").HeaderText = "Costo S/IVA"
                    DGrid.Columns("precio").HeaderText = "Precio S/IVA"

                    DGrid.Columns("porc").Visible = False

                    DGrid.Columns("M1").HeaderText = "1"
                    DGrid.Columns("M1_").HeaderText = "*"
                    DGrid.Columns("M2").HeaderText = "2"
                    DGrid.Columns("M2_").HeaderText = "*"
                    DGrid.Columns("M3").HeaderText = "3"
                    DGrid.Columns("M3_").HeaderText = "*"
                    DGrid.Columns("M4").HeaderText = "4"
                    DGrid.Columns("M4_").HeaderText = "*"
                    DGrid.Columns("M5").HeaderText = "5"
                    DGrid.Columns("M5_").HeaderText = "*"
                    DGrid.Columns("M6").HeaderText = "6"
                    DGrid.Columns("M6_").HeaderText = "*"
                    DGrid.Columns("M7").HeaderText = "7"
                    DGrid.Columns("M7_").HeaderText = "*"
                    DGrid.Columns("M8").HeaderText = "8"
                    DGrid.Columns("M8_").HeaderText = "*"
                    DGrid.Columns("M9").HeaderText = "9"
                    DGrid.Columns("M9_").HeaderText = "*"
                    DGrid.Columns("M10").HeaderText = "10"
                    DGrid.Columns("M10_").HeaderText = "*"
                    DGrid.Columns("M11").HeaderText = "11"
                    DGrid.Columns("M11_").HeaderText = "*"
                    DGrid.Columns("M12").HeaderText = "12"
                    DGrid.Columns("M12_").HeaderText = "*"
                    DGrid.Columns("M13").HeaderText = "13"
                    DGrid.Columns("M13_").HeaderText = "*"
                    DGrid.Columns("M14").HeaderText = "14"
                    DGrid.Columns("M14_").HeaderText = "*"
                    DGrid.Columns("M15").HeaderText = "15"
                    DGrid.Columns("M15_").HeaderText = "*"
                    DGrid.Columns("M16").HeaderText = "16"
                    DGrid.Columns("M16_").HeaderText = "*"
                    DGrid.Columns("M17").HeaderText = "17"
                    DGrid.Columns("M17_").HeaderText = "*"
                    DGrid.Columns("M18").HeaderText = "18"
                    DGrid.Columns("M18_").HeaderText = "*"
                    DGrid.Columns("M19").HeaderText = "19"
                    DGrid.Columns("M19_").HeaderText = "*"
                    DGrid.Columns("M20").HeaderText = "20"
                    DGrid.Columns("M20_").HeaderText = "*"
                    DGrid.Columns("M21").HeaderText = "21"
                    DGrid.Columns("M21_").HeaderText = "*"
                    DGrid.Columns("M22").HeaderText = "22"
                    DGrid.Columns("M22_").HeaderText = "*"
                    DGrid.Columns("M23").HeaderText = "23"
                    DGrid.Columns("M23_").HeaderText = "*"
                    DGrid.Columns("M24").HeaderText = "24"
                    DGrid.Columns("M24_").HeaderText = "*"
                    DGrid.Columns("M25").HeaderText = "25"
                    DGrid.Columns("M25_").HeaderText = "*"
                    DGrid.Columns("M26").HeaderText = "26"
                    DGrid.Columns("M26_").HeaderText = "*"
                    DGrid.Columns("M27").HeaderText = "27"
                    DGrid.Columns("M27_").HeaderText = "*"
                    DGrid.Columns("M28").HeaderText = "28"
                    DGrid.Columns("M28_").HeaderText = "*"
                    DGrid.Columns("M29").HeaderText = "29"
                    DGrid.Columns("M29_").HeaderText = "*"
                    DGrid.Columns("M30").HeaderText = "30"
                    DGrid.Columns("M30_").HeaderText = "*"
                    DGrid.Columns("M31").HeaderText = "31"
                    DGrid.Columns("M31_").HeaderText = "*"
                    DGrid.Columns("M32").HeaderText = "32"
                    DGrid.Columns("M32_").HeaderText = "*"
                    DGrid.Columns("M33").HeaderText = "33"
                    DGrid.Columns("M33_").HeaderText = "*"
                    DGrid.Columns("M34").HeaderText = "34"
                    DGrid.Columns("M34_").HeaderText = "*"
                    DGrid.Columns("M35").HeaderText = "35"
                    DGrid.Columns("M35_").HeaderText = "*"
                    DGrid.Columns("M36").HeaderText = "36"
                    DGrid.Columns("M36_").HeaderText = "*"
                    DGrid.Columns("M37").HeaderText = "37"
                    DGrid.Columns("M37_").HeaderText = "*"
                    DGrid.Columns("M38").HeaderText = "38"
                    DGrid.Columns("M38_").HeaderText = "*"
                    DGrid.Columns("M39").HeaderText = "39"
                    DGrid.Columns("M39_").HeaderText = "*"
                    DGrid.Columns("M40").HeaderText = "40"
                    DGrid.Columns("M40_").HeaderText = "*"
                    DGrid.Columns("M41").HeaderText = "41"
                    DGrid.Columns("M41_").HeaderText = "*"
                    DGrid.Columns("M42").HeaderText = "42"
                    DGrid.Columns("M42_").HeaderText = "*"
                    DGrid.Columns("M43").HeaderText = "43"
                    DGrid.Columns("M43_").HeaderText = "*"
                    DGrid.Columns("M44").HeaderText = "44"
                    DGrid.Columns("M44_").HeaderText = "*"
                    DGrid.Columns("M45").HeaderText = "45"
                    DGrid.Columns("M45_").HeaderText = "*"
                    DGrid.Columns("M46").HeaderText = "46"
                    DGrid.Columns("M46_").HeaderText = "*"
                    DGrid.Columns("M47").HeaderText = "47"
                    DGrid.Columns("M47_").HeaderText = "*"
                    DGrid.Columns("M48").HeaderText = "48"
                    DGrid.Columns("M48_").HeaderText = "*"
                    DGrid.Columns("M49").HeaderText = "49"
                    DGrid.Columns("M49_").HeaderText = "*"
                    DGrid.Columns("M50").HeaderText = "50"
                    DGrid.Columns("M50_").HeaderText = "*"

                    DGrid.RowHeadersVisible = False
                    For i As Integer = 0 To DGrid.ColumnCount - 1
                        DGrid.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Next

                    DGrid.Columns("pares").DefaultCellStyle.Format = "#,##0"
                    DGrid.Columns("costo").DefaultCellStyle.Format = "c"
                    DGrid.Columns("precio").DefaultCellStyle.Format = "c"
                    DGrid.Columns("costoc").DefaultCellStyle.Format = "c"
                    DGrid.Columns("precioc").DefaultCellStyle.Format = "c"


                    If GLB_CveSucursal > "0" And GLB_CveSucursal < "90" Then
                        DGrid.Columns("costo").Visible = False
                    End If
                    DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

                    DGrid.Rows(0).Frozen = True
                    DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
                    DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                    DGrid.Columns(1).Frozen = True
                    DGrid.Columns(1).DefaultCellStyle.BackColor = Color.PowderBlue
                    DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns(1).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)


                    DGrid.Columns(2).Frozen = True
                    DGrid.Columns(2).DefaultCellStyle.BackColor = Color.PowderBlue
                    DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns(2).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                    DGrid.Columns(3).Frozen = True
                    DGrid.Columns(3).DefaultCellStyle.BackColor = Color.PowderBlue
                    DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns(3).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)


                    DGrid.Columns(4).Frozen = True
                    DGrid.Columns(4).DefaultCellStyle.BackColor = Color.PowderBlue
                    DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns(4).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)


                    If blnBorroCol = True Then
                        DGrid.Columns.Remove(DGrid.Columns("renglon"))
                    End If
                    blnBorroCol = True
                    AgregarColumna()
                    For i As Integer = 1 To DGrid.Rows.Count - 2
                        DGrid.Rows(i).Cells("Renglon").Value = i.ToString
                    Next
                End If




            Else


                'For n As Integer = 0 To DGrid.Rows.Count - 1
                '    For i As Integer = 5 To 104
                '        If DGrid.Rows(n).Cells(i).Value = 0 Then
                '            DGrid.Rows(n).Cells(i).Style.ForeColor = Color.White
                '        End If
                '    Next
                'Next


                'For i As Integer = 5 To 104
                '    If pub_SumarColumnaGridNombre(DGrid, DGrid.Columns(i).Name, DGrid.RowCount - 1) = 0 Then
                '        DGrid.Columns(i).Visible = False
                '    End If
                'Next
                'For i As Integer = 5 To 104

                '    DGrid.Columns(i).DefaultCellStyle.BackColor = Color.Khaki
                'Next

                'If objDataSet.Tables(0).Rows.Count > 0 Then
                ' For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1

                '                    Next

                Btn_Foto.Enabled = True
                'Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)

                'Dim row As DataRow = dt.NewRow()

                'row(3) = "TOTAL: "

                'row("pares") = pub_SumarColumnaGridNombre(DGrid, "pares", DGrid.RowCount - 1)
                'row("porc") = pub_SumarColumnaGridNombre(DGrid, "porc", DGrid.RowCount - 1)
                'row("costo") = pub_SumarColumnaGridNombre(DGrid, "costo", DGrid.RowCount - 1)
                'row("precio") = pub_SumarColumnaGridNombre(DGrid, "precio", DGrid.RowCount - 1)

                'dt.Rows.InsertAt(row, 0)
                'DGrid.DataSource = dt

                DGrid.Columns("marca").HeaderText = "Marca"
                DGrid.Columns("modelo").HeaderText = "Modelo"
                DGrid.Columns("estilof").HeaderText = "Estilo Fabrica"
                DGrid.Columns("Descripc").HeaderText = "Descripción"
                DGrid.Columns("pares").HeaderText = "Pares"
                DGrid.Columns("porc").HeaderText = "%"
                DGrid.Columns("costoC").HeaderText = "Costo C/IVA"
                DGrid.Columns("precioC").HeaderText = "Precio C/IVA"

                DGrid.Columns("costo").HeaderText = "Costo S/IVA"
                DGrid.Columns("precio").HeaderText = "Precio S/IVA"
                DGrid.Columns("porc").Visible = False

                DGrid.Columns("M1").HeaderText = "1"
                DGrid.Columns("M1_").HeaderText = "*"
                DGrid.Columns("M2").HeaderText = "2"
                DGrid.Columns("M2_").HeaderText = "*"
                DGrid.Columns("M3").HeaderText = "3"
                DGrid.Columns("M3_").HeaderText = "*"
                DGrid.Columns("M4").HeaderText = "4"
                DGrid.Columns("M4_").HeaderText = "*"
                DGrid.Columns("M5").HeaderText = "5"
                DGrid.Columns("M5_").HeaderText = "*"
                DGrid.Columns("M6").HeaderText = "6"
                DGrid.Columns("M6_").HeaderText = "*"
                DGrid.Columns("M7").HeaderText = "7"
                DGrid.Columns("M7_").HeaderText = "*"
                DGrid.Columns("M8").HeaderText = "8"
                DGrid.Columns("M8_").HeaderText = "*"
                DGrid.Columns("M9").HeaderText = "9"
                DGrid.Columns("M9_").HeaderText = "*"
                DGrid.Columns("M10").HeaderText = "10"
                DGrid.Columns("M10_").HeaderText = "*"
                DGrid.Columns("M11").HeaderText = "11"
                DGrid.Columns("M11_").HeaderText = "*"
                DGrid.Columns("M12").HeaderText = "12"
                DGrid.Columns("M12_").HeaderText = "*"
                DGrid.Columns("M13").HeaderText = "13"
                DGrid.Columns("M13_").HeaderText = "*"
                DGrid.Columns("M14").HeaderText = "14"
                DGrid.Columns("M14_").HeaderText = "*"
                DGrid.Columns("M15").HeaderText = "15"
                DGrid.Columns("M15_").HeaderText = "*"
                DGrid.Columns("M16").HeaderText = "16"
                DGrid.Columns("M16_").HeaderText = "*"
                DGrid.Columns("M17").HeaderText = "17"
                DGrid.Columns("M17_").HeaderText = "*"
                DGrid.Columns("M18").HeaderText = "18"
                DGrid.Columns("M18_").HeaderText = "*"
                DGrid.Columns("M19").HeaderText = "19"
                DGrid.Columns("M19_").HeaderText = "*"
                DGrid.Columns("M20").HeaderText = "20"
                DGrid.Columns("M20_").HeaderText = "*"
                DGrid.Columns("M21").HeaderText = "21"
                DGrid.Columns("M21_").HeaderText = "*"
                DGrid.Columns("M22").HeaderText = "22"
                DGrid.Columns("M22_").HeaderText = "*"
                DGrid.Columns("M23").HeaderText = "23"
                DGrid.Columns("M23_").HeaderText = "*"
                DGrid.Columns("M24").HeaderText = "24"
                DGrid.Columns("M24_").HeaderText = "*"
                DGrid.Columns("M25").HeaderText = "25"
                DGrid.Columns("M25_").HeaderText = "*"
                DGrid.Columns("M26").HeaderText = "26"
                DGrid.Columns("M26_").HeaderText = "*"
                DGrid.Columns("M27").HeaderText = "27"
                DGrid.Columns("M27_").HeaderText = "*"
                DGrid.Columns("M28").HeaderText = "28"
                DGrid.Columns("M28_").HeaderText = "*"
                DGrid.Columns("M29").HeaderText = "29"
                DGrid.Columns("M29_").HeaderText = "*"
                DGrid.Columns("M30").HeaderText = "30"
                DGrid.Columns("M30_").HeaderText = "*"
                DGrid.Columns("M31").HeaderText = "31"
                DGrid.Columns("M31_").HeaderText = "*"
                DGrid.Columns("M32").HeaderText = "32"
                DGrid.Columns("M32_").HeaderText = "*"
                DGrid.Columns("M33").HeaderText = "33"
                DGrid.Columns("M33_").HeaderText = "*"
                DGrid.Columns("M34").HeaderText = "34"
                DGrid.Columns("M34_").HeaderText = "*"
                DGrid.Columns("M35").HeaderText = "35"
                DGrid.Columns("M35_").HeaderText = "*"
                DGrid.Columns("M36").HeaderText = "36"
                DGrid.Columns("M36_").HeaderText = "*"
                DGrid.Columns("M37").HeaderText = "37"
                DGrid.Columns("M37_").HeaderText = "*"
                DGrid.Columns("M38").HeaderText = "38"
                DGrid.Columns("M38_").HeaderText = "*"
                DGrid.Columns("M39").HeaderText = "39"
                DGrid.Columns("M39_").HeaderText = "*"
                DGrid.Columns("M40").HeaderText = "40"
                DGrid.Columns("M40_").HeaderText = "*"
                DGrid.Columns("M41").HeaderText = "41"
                DGrid.Columns("M41_").HeaderText = "*"
                DGrid.Columns("M42").HeaderText = "42"
                DGrid.Columns("M42_").HeaderText = "*"
                DGrid.Columns("M43").HeaderText = "43"
                DGrid.Columns("M43_").HeaderText = "*"
                DGrid.Columns("M44").HeaderText = "44"
                DGrid.Columns("M44_").HeaderText = "*"
                DGrid.Columns("M45").HeaderText = "45"
                DGrid.Columns("M45_").HeaderText = "*"
                DGrid.Columns("M46").HeaderText = "46"
                DGrid.Columns("M46_").HeaderText = "*"
                DGrid.Columns("M47").HeaderText = "47"
                DGrid.Columns("M47_").HeaderText = "*"
                DGrid.Columns("M48").HeaderText = "48"
                DGrid.Columns("M48_").HeaderText = "*"
                DGrid.Columns("M49").HeaderText = "49"
                DGrid.Columns("M49_").HeaderText = "*"
                DGrid.Columns("M50").HeaderText = "50"
                DGrid.Columns("M50_").HeaderText = "*"

                DGrid.RowHeadersVisible = False
                For i As Integer = 0 To DGrid.ColumnCount - 1
                    DGrid.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Next

                DGrid.Columns("pares").DefaultCellStyle.Format = "#,##0"
                DGrid.Columns("costo").DefaultCellStyle.Format = "c"
                DGrid.Columns("precio").DefaultCellStyle.Format = "c"

                DGrid.Columns("costoC").DefaultCellStyle.Format = "c"
                DGrid.Columns("precioC").DefaultCellStyle.Format = "c"

                'DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

                'DGrid.Rows(0).Frozen = True
                'DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
                'DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                'DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                'DGrid.Columns(1).Frozen = True
                'DGrid.Columns(1).DefaultCellStyle.BackColor = Color.PowderBlue
                'DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                'DGrid.Columns(1).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)


                'DGrid.Columns(2).Frozen = True
                'DGrid.Columns(2).DefaultCellStyle.BackColor = Color.PowderBlue
                'DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                'DGrid.Columns(2).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                'DGrid.Columns(3).Frozen = True
                'DGrid.Columns(3).DefaultCellStyle.BackColor = Color.PowderBlue
                'DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                'DGrid.Columns(3).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)


                'DGrid.Columns(4).Frozen = True
                'DGrid.Columns(4).DefaultCellStyle.BackColor = Color.PowderBlue
                'DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                'DGrid.Columns(4).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)


                'If blnBorroCol = True Then
                '    DGrid.Columns.Remove(DGrid.Columns("renglon"))
                'End If
                'blnBorroCol = True
                'AgregarColumna()
                'For i As Integer = 1 To DGrid.Rows.Count - 2
                '    DGrid.Rows(i).Cells("Renglon").Value = i.ToString
                'Next
                'End If
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Public Function TraerNombreColumna(ByVal Medida As String) As String
        If Medida = "1" Then
            Return "M1"
        ElseIf Medida = "1-" Then
            Return "M1_"
        ElseIf Medida = "2" Then
            Return "M2"
        ElseIf Medida = "2-" Then
            Return "M2_"
        ElseIf Medida = "3" Then
            Return "M3"
        ElseIf Medida = "3-" Then
            Return "M3_"
        ElseIf Medida = "4" Then
            Return "M4"
        ElseIf Medida = "4-" Then
            Return "M4_"
        ElseIf Medida = "5" Then
            Return "M5"
        ElseIf Medida = "5-" Then
            Return "M5_"
        ElseIf Medida = "6" Then
            Return "M6"
        ElseIf Medida = "6-" Then
            Return "M6_"
        ElseIf Medida = "7" Then
            Return "M7"
        ElseIf Medida = "7-" Then
            Return "M7_"
        ElseIf Medida = "8" Then
            Return "M8"
        ElseIf Medida = "8-" Then
            Return "M8_"
        ElseIf Medida = "9" Then
            Return "M9"
        ElseIf Medida = "9-" Then
            Return "M9_"
        ElseIf Medida = "10" Then
            Return "M10"
        ElseIf Medida = "10-" Then
            Return "M10_"
        ElseIf Medida = "11" Then
            Return "M11"
        ElseIf Medida = "11-" Then
            Return "M11_"
        ElseIf Medida = "12" Then
            Return "M12"
        ElseIf Medida = "12-" Then
            Return "M12_"
        ElseIf Medida = "13" Then
            Return "M13"
        ElseIf Medida = "13-" Then
            Return "M13_"
        ElseIf Medida = "14" Then
            Return "M14"
        ElseIf Medida = "14-" Then
            Return "M14_"
        ElseIf Medida = "15" Then
            Return "M15"
        ElseIf Medida = "15-" Then
            Return "M15_"
        ElseIf Medida = "16" Then
            Return "M16"
        ElseIf Medida = "16-" Then
            Return "M16_"
        ElseIf Medida = "17" Then
            Return "M17"
        ElseIf Medida = "17-" Then
            Return "M17_"
        ElseIf Medida = "18" Then
            Return "M18"
        ElseIf Medida = "18-" Then
            Return "M18_"
        ElseIf Medida = "19" Then
            Return "M19"
        ElseIf Medida = "19-" Then
            Return "M19_"
        ElseIf Medida = "20" Then
            Return "M20"
        ElseIf Medida = "20-" Then
            Return "M20_"
        ElseIf Medida = "21" Then
            Return "M21"
        ElseIf Medida = "21-" Then
            Return "M21_"
        ElseIf Medida = "22" Then
            Return "M22"
        ElseIf Medida = "22-" Then
            Return "M22_"
        ElseIf Medida = "23" Then
            Return "M23"
        ElseIf Medida = "23-" Then
            Return "M23_"
        ElseIf Medida = "24" Then
            Return "M24"
        ElseIf Medida = "24-" Then
            Return "M24_"
        ElseIf Medida = "25" Then
            Return "M25"
        ElseIf Medida = "25-" Then
            Return "M25_"
        ElseIf Medida = "26" Then
            Return "M26"
        ElseIf Medida = "26-" Then
            Return "M26_"
        ElseIf Medida = "27" Then
            Return "M27"
        ElseIf Medida = "27-" Then
            Return "M27_"
        ElseIf Medida = "28" Then
            Return "M28"
        ElseIf Medida = "28-" Then
            Return "M28_"
        ElseIf Medida = "29" Then
            Return "M29"
        ElseIf Medida = "29-" Then
            Return "M29_"
        ElseIf Medida = "30" Then
            Return "M30"
        ElseIf Medida = "30-" Then
            Return "M30_"
        ElseIf Medida = "31" Then
            Return "M31"
        ElseIf Medida = "31-" Then
            Return "M31_"
        ElseIf Medida = "32" Then
            Return "M32"
        ElseIf Medida = "32-" Then
            Return "M32_"
        ElseIf Medida = "33" Then
            Return "M33"
        ElseIf Medida = "33-" Then
            Return "M33_"
        ElseIf Medida = "34" Then
            Return "M34"
        ElseIf Medida = "34-" Then
            Return "M34_"
        ElseIf Medida = "35" Then
            Return "M35"
        ElseIf Medida = "35-" Then
            Return "M35_"
        ElseIf Medida = "36" Then
            Return "M36"
        ElseIf Medida = "36-" Then
            Return "M36_"
        ElseIf Medida = "37" Then
            Return "M37"
        ElseIf Medida = "37-" Then
            Return "M37_"
        ElseIf Medida = "38" Then
            Return "M38"
        ElseIf Medida = "38-" Then
            Return "M38_"
        ElseIf Medida = "39" Then
            Return "M39"
        ElseIf Medida = "39-" Then
            Return "M39_"
        ElseIf Medida = "40" Then
            Return "M40"
        ElseIf Medida = "40-" Then
            Return "M40_"
        ElseIf Medida = "41" Then
            Return "M41"
        ElseIf Medida = "41-" Then
            Return "M41_"
        ElseIf Medida = "42" Then
            Return "M42"
        ElseIf Medida = "42-" Then
            Return "M42_"
        ElseIf Medida = "43" Then
            Return "M43"
        ElseIf Medida = "43-" Then
            Return "M43_"
        ElseIf Medida = "44" Then
            Return "M44"
        ElseIf Medida = "44-" Then
            Return "M44_"
        ElseIf Medida = "45" Then
            Return "M45"
        ElseIf Medida = "45-" Then
            Return "M45_"
        ElseIf Medida = "46" Then
            Return "M46"
        ElseIf Medida = "46-" Then
            Return "M46_"
        ElseIf Medida = "47" Then
            Return "M47"
        ElseIf Medida = "47-" Then
            Return "M47_"
        ElseIf Medida = "48" Then
            Return "M48"
        ElseIf Medida = "48-" Then
            Return "M48_"
        ElseIf Medida = "49" Then
            Return "M49"
        ElseIf Medida = "49-" Then
            Return "M49_"
        ElseIf Medida = "50" Then
            Return "M50"
        ElseIf Medida = "50-" Then
            Return "M50_"
        Else
            Return "Tipo"
        End If
    End Function

    Private Sub GenerarToolTip()
        Try
            '
            ToolTip.SetToolTip(Btn_Filtro, "Búsqueda Avanzada")
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
            ToolTip.SetToolTip(Btn_Salir, "Salir")
            ToolTip.SetToolTip(Btn_Foto, "Imagen del Producto")
            ToolTip.SetToolTip(Btn_Regresar, "Regresar")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Public Function pub_SumarColumnaGridNombre(ByVal DGrid As DataGridView, ByVal Columna As String, Optional ByVal HastaRenglon As Integer = 0) As Decimal
        'mreyes 14/Febrero/2012 05:08 p.m.
        Try
            Dim Col As Integer = DGrid.CurrentCell.ColumnIndex

            pub_SumarColumnaGridNombre = 0
            For renglon As Integer = 0 To IIf(HastaRenglon = 0, DGrid.RowCount - 2, HastaRenglon)
                If IsNumeric(DGrid.Rows(renglon).Cells(Columna).Value) Then
                    pub_SumarColumnaGridNombre = (DGrid.Rows(renglon).Cells(Columna).Value) + pub_SumarColumnaGridNombre
                End If
            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Sub InicializaGrid()
        Try
            PBox.Visible = False
            Btn_Foto.Enabled = False
            Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)

            Dim row As DataRow = dt.NewRow()

            If Opcion = 1 Then
                row(1) = "TOTAL: "
            Else
                row(0) = "TOTAL: "
            End If

            row("total") = pub_SumarColumnaGridNombre(DGrid, "total", DGrid.RowCount - 1)
            row("dias_15") = pub_SumarColumnaGridNombre(DGrid, "dias_15", DGrid.RowCount - 1)
            row("dias_30") = pub_SumarColumnaGridNombre(DGrid, "dias_30", DGrid.RowCount - 1)
            row("dias_45") = pub_SumarColumnaGridNombre(DGrid, "dias_45", DGrid.RowCount - 1)
            row("dias_60") = pub_SumarColumnaGridNombre(DGrid, "dias_60", DGrid.RowCount - 1)
            row("dias_90") = pub_SumarColumnaGridNombre(DGrid, "dias_90", DGrid.RowCount - 1)
            row("dias_120") = pub_SumarColumnaGridNombre(DGrid, "dias_120", DGrid.RowCount - 1)
            row("dias_140") = pub_SumarColumnaGridNombre(DGrid, "dias_140", DGrid.RowCount - 1)
            row("dias_160") = pub_SumarColumnaGridNombre(DGrid, "dias_160", DGrid.RowCount - 1)
            row("dias_200") = pub_SumarColumnaGridNombre(DGrid, "dias_200", DGrid.RowCount - 1)
            row("dias_250") = pub_SumarColumnaGridNombre(DGrid, "dias_250", DGrid.RowCount - 1)
            row("dias_300") = pub_SumarColumnaGridNombre(DGrid, "dias_300", DGrid.RowCount - 1)
            row("dias_350") = pub_SumarColumnaGridNombre(DGrid, "dias_350", DGrid.RowCount - 1)
            row("dias_450") = pub_SumarColumnaGridNombre(DGrid, "dias_450", DGrid.RowCount - 1)
            row("dias_550") = pub_SumarColumnaGridNombre(DGrid, "dias_550", DGrid.RowCount - 1)
            row("dias_650") = pub_SumarColumnaGridNombre(DGrid, "dias_650", DGrid.RowCount - 1)
            row("dias_750") = pub_SumarColumnaGridNombre(DGrid, "dias_750", DGrid.RowCount - 1)
            row("dias_850") = pub_SumarColumnaGridNombre(DGrid, "dias_850", DGrid.RowCount - 1)
            row("dias_1000") = pub_SumarColumnaGridNombre(DGrid, "dias_1000", DGrid.RowCount - 1)
            row("dias_1500") = pub_SumarColumnaGridNombre(DGrid, "dias_1500", DGrid.RowCount - 1)
            row("dias_2000") = pub_SumarColumnaGridNombre(DGrid, "dias_2000", DGrid.RowCount - 1)
            row("dias_2001") = pub_SumarColumnaGridNombre(DGrid, "dias_2001", DGrid.RowCount - 1)

            If row("total") > 0 Then
                row("porc_tot") = Math.Round((row("total") / row("total")) * 100, 2)
                row("porc_15") = Math.Round((row("dias_15") / row("total")) * 100, 2)
                row("porc_30") = Math.Round((row("dias_30") / row("total")) * 100, 2)
                row("porc_45") = Math.Round((row("dias_45") / row("total")) * 100, 2)
                row("porc_60") = Math.Round((row("dias_60") / row("total")) * 100, 2)
                row("porc_90") = Math.Round((row("dias_90") / row("total")) * 100, 2)
                row("porc_120") = Math.Round((row("dias_120") / row("total")) * 100, 2)
                row("porc_140") = Math.Round((row("dias_140") / row("total")) * 100, 2)
                row("porc_160") = Math.Round((row("dias_160") / row("total")) * 100, 2)
                row("porc_200") = Math.Round((row("dias_200") / row("total")) * 100, 2)
                row("porc_250") = Math.Round((row("dias_250") / row("total")) * 100, 2)
                row("porc_300") = Math.Round((row("dias_300") / row("total")) * 100, 2)
                row("porc_350") = Math.Round((row("dias_350") / row("total")) * 100, 2)
                row("porc_450") = Math.Round((row("dias_450") / row("total")) * 100, 2)
                row("porc_550") = Math.Round((row("dias_550") / row("total")) * 100, 2)
                row("porc_650") = Math.Round((row("dias_650") / row("total")) * 100, 2)
                row("porc_750") = Math.Round((row("dias_750") / row("total")) * 100, 2)
                row("porc_850") = Math.Round((row("dias_850") / row("total")) * 100, 2)
                row("porc_1000") = Math.Round((row("dias_1000") / row("total")) * 100, 2)
                row("porc_1500") = Math.Round((row("dias_1500") / row("total")) * 100, 2)
                row("porc_2000") = Math.Round((row("dias_2000") / row("total")) * 100, 2)
                row("porc_2001") = Math.Round((row("dias_2001") / row("total")) * 100, 2)
            Else
                row("porc_tot") = 0
                row("porc_15") = 0
                row("porc_30") = 0
                row("porc_45") = 0
                row("porc_60") = 0
                row("porc_90") = 0
                row("porc_120") = 0
                row("porc_140") = 0
                row("porc_160") = 0
                row("porc_200") = 0
                row("porc_250") = 0
                row("porc_300") = 0
                row("porc_350") = 0
                row("porc_450") = 0
                row("porc_550") = 0
                row("porc_650") = 0
                row("porc_750") = 0
                row("porc_850") = 0
                row("porc_1000") = 0
                row("porc_1500") = 0
                row("porc_2000") = 0
                row("porc_2001") = 0
            End If

            dt.Rows.InsertAt(row, 0)
            DGrid.DataSource = dt

            If Opcion = 1 Then
                DGrid.Columns("sucursal").HeaderText = "sucursal"
                DGrid.Columns("descripsucursal").HeaderText = "Sucursal"
            ElseIf Opcion = 2 Then
                DGrid.Columns("division").HeaderText = "División"
            ElseIf Opcion = 3 Then
                DGrid.Columns("depto").HeaderText = "Departamento"
            ElseIf Opcion = 4 Then
                DGrid.Columns("familia").HeaderText = "Familia"
            ElseIf Opcion = 5 Then
                DGrid.Columns("linea").HeaderText = "Linea"
            ElseIf Opcion = 6 Then
                DGrid.Columns("l1").HeaderText = "L1"
            ElseIf Opcion = 7 Then
                DGrid.Columns("l2").HeaderText = "L2"
            ElseIf Opcion = 8 Then
                DGrid.Columns("l3").HeaderText = "L3"
            ElseIf Opcion = 9 Then
                DGrid.Columns("l4").HeaderText = "L4"
            ElseIf Opcion = 10 Then
                DGrid.Columns("l5").HeaderText = "L5"
            ElseIf Opcion = 11 Then
                DGrid.Columns("l6").HeaderText = "L6"
            ElseIf Opcion = 12 Then
                DGrid.Columns("marca").HeaderText = "Marca"
            End If



            DGrid.Columns("total").HeaderText = "Total"
            DGrid.Columns("porc_tot").HeaderText = "%"
            DGrid.Columns("dias_15").HeaderText = "15"
            DGrid.Columns("porc_15").HeaderText = "%"
            DGrid.Columns("dias_30").HeaderText = "30"
            DGrid.Columns("porc_30").HeaderText = "%"
            DGrid.Columns("dias_45").HeaderText = "45"
            DGrid.Columns("porc_45").HeaderText = "%"
            DGrid.Columns("dias_60").HeaderText = "60"
            DGrid.Columns("porc_60").HeaderText = "%"
            DGrid.Columns("dias_90").HeaderText = "90"
            DGrid.Columns("porc_90").HeaderText = "%"
            DGrid.Columns("dias_120").HeaderText = "120"
            DGrid.Columns("porc_120").HeaderText = "%"
            DGrid.Columns("dias_140").HeaderText = "140"
            DGrid.Columns("porc_140").HeaderText = "%"
            DGrid.Columns("dias_160").HeaderText = "160"
            DGrid.Columns("porc_160").HeaderText = "%"
            DGrid.Columns("dias_200").HeaderText = "200"
            DGrid.Columns("porc_200").HeaderText = "%"
            DGrid.Columns("dias_250").HeaderText = "250"
            DGrid.Columns("porc_250").HeaderText = "%"
            DGrid.Columns("dias_300").HeaderText = "300"
            DGrid.Columns("porc_300").HeaderText = "%"
            DGrid.Columns("dias_350").HeaderText = "350"
            DGrid.Columns("porc_350").HeaderText = "%"
            DGrid.Columns("dias_450").HeaderText = "450"
            DGrid.Columns("porc_450").HeaderText = "%"
            DGrid.Columns("dias_550").HeaderText = "550"
            DGrid.Columns("porc_550").HeaderText = "%"
            DGrid.Columns("dias_650").HeaderText = "650"
            DGrid.Columns("porc_650").HeaderText = "%"
            DGrid.Columns("dias_750").HeaderText = "750"
            DGrid.Columns("porc_750").HeaderText = "%"
            DGrid.Columns("dias_850").HeaderText = "850"
            DGrid.Columns("porc_850").HeaderText = "%"
            DGrid.Columns("dias_1000").HeaderText = "1000"
            DGrid.Columns("porc_1000").HeaderText = "%"
            DGrid.Columns("dias_1500").HeaderText = "1500"
            DGrid.Columns("porc_1500").HeaderText = "%"
            DGrid.Columns("dias_2000").HeaderText = "2000"
            DGrid.Columns("porc_2000").HeaderText = "%"
            DGrid.Columns("dias_2001").HeaderText = "+2000"
            DGrid.Columns("porc_2001").HeaderText = "%"

            DGrid.RowHeadersVisible = False
            For i As Integer = 0 To DGrid.ColumnCount - 1
                DGrid.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next

            If Opcion2 = 1 Then
                DGrid.Columns("total").DefaultCellStyle.Format = "#,##0"
                DGrid.Columns("dias_15").DefaultCellStyle.Format = "#,##0"
                DGrid.Columns("dias_30").DefaultCellStyle.Format = "#,##0"
                DGrid.Columns("dias_45").DefaultCellStyle.Format = "#,##0"
                DGrid.Columns("dias_60").DefaultCellStyle.Format = "#,##0"
                DGrid.Columns("dias_90").DefaultCellStyle.Format = "#,##0"
                DGrid.Columns("dias_120").DefaultCellStyle.Format = "#,##0"
                DGrid.Columns("dias_140").DefaultCellStyle.Format = "#,##0"
                DGrid.Columns("dias_160").DefaultCellStyle.Format = "#,##0"
                DGrid.Columns("dias_200").DefaultCellStyle.Format = "#,##0"
                DGrid.Columns("dias_250").DefaultCellStyle.Format = "#,##0"
                DGrid.Columns("dias_300").DefaultCellStyle.Format = "#,##0"
                DGrid.Columns("dias_350").DefaultCellStyle.Format = "#,##0"
                DGrid.Columns("dias_450").DefaultCellStyle.Format = "#,##0"
                DGrid.Columns("dias_550").DefaultCellStyle.Format = "#,##0"
                DGrid.Columns("dias_650").DefaultCellStyle.Format = "#,##0"
                DGrid.Columns("dias_750").DefaultCellStyle.Format = "#,##0"
                DGrid.Columns("dias_850").DefaultCellStyle.Format = "#,##0"
                DGrid.Columns("dias_1000").DefaultCellStyle.Format = "#,##0"
                DGrid.Columns("dias_1500").DefaultCellStyle.Format = "#,##0"
                DGrid.Columns("dias_2000").DefaultCellStyle.Format = "#,##0"
                DGrid.Columns("dias_2001").DefaultCellStyle.Format = "#,##0"
            Else
                DGrid.Columns("total").DefaultCellStyle.Format = "c"
                DGrid.Columns("dias_15").DefaultCellStyle.Format = "c"
                DGrid.Columns("dias_30").DefaultCellStyle.Format = "c"
                DGrid.Columns("dias_45").DefaultCellStyle.Format = "c"
                DGrid.Columns("dias_60").DefaultCellStyle.Format = "c"
                DGrid.Columns("dias_90").DefaultCellStyle.Format = "c"
                DGrid.Columns("dias_120").DefaultCellStyle.Format = "c"
                DGrid.Columns("dias_140").DefaultCellStyle.Format = "c"
                DGrid.Columns("dias_160").DefaultCellStyle.Format = "c"
                DGrid.Columns("dias_200").DefaultCellStyle.Format = "c"
                DGrid.Columns("dias_250").DefaultCellStyle.Format = "c"
                DGrid.Columns("dias_300").DefaultCellStyle.Format = "c"
                DGrid.Columns("dias_350").DefaultCellStyle.Format = "c"
                DGrid.Columns("dias_450").DefaultCellStyle.Format = "c"
                DGrid.Columns("dias_550").DefaultCellStyle.Format = "c"
                DGrid.Columns("dias_650").DefaultCellStyle.Format = "c"
                DGrid.Columns("dias_750").DefaultCellStyle.Format = "c"
                DGrid.Columns("dias_850").DefaultCellStyle.Format = "c"
                DGrid.Columns("dias_1000").DefaultCellStyle.Format = "c"
                DGrid.Columns("dias_1500").DefaultCellStyle.Format = "c"
                DGrid.Columns("dias_2000").DefaultCellStyle.Format = "c"
                DGrid.Columns("dias_2001").DefaultCellStyle.Format = "c"
            End If

            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            DGrid.Rows(0).Frozen = True
            DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            If Opcion = 1 Then
                DGrid.Columns("sucursal").Visible = False
                DGrid.Columns("descripsucursal").Frozen = True
                DGrid.Columns("descripsucursal").DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Columns("descripsucursal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns("descripsucursal").DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If
            DGrid.Columns(1).Frozen = True
            DGrid.Columns(1).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(1).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)


            If blnBorroCol = True Then
                DGrid.Columns.Remove(DGrid.Columns("renglon"))
            End If
            blnBorroCol = True
            AgregarColumna()
            For i As Integer = 1 To DGrid.Rows.Count - 2
                DGrid.Rows(i).Cells("Renglon").Value = i.ToString
            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub AgregarColumna()
        Try
            Dim colRenglon As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
            colRenglon.Name = "Renglon"
            colRenglon.HeaderText = "Ren"
            colRenglon.Frozen = True
            colRenglon.DefaultCellStyle.BackColor = Color.PowderBlue
            colRenglon.DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            colRenglon.DisplayIndex = 0
            colRenglon.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            colRenglon.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            colRenglon.CellTemplate = New DataGridViewTextBoxCell

            'colPorcentaje.DefaultCellStyle.Format = "%"
            'colPorcentaje.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

            Me.DGrid.Columns.Add(colRenglon)

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Sub InicializaGridModelos()
        Try
            Btn_Foto.Enabled = True
            Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)

            Dim row As DataRow = dt.NewRow()

            row(3) = "TOTAL: "

            row("total") = pub_SumarColumnaGridNombre(DGrid, "total", DGrid.RowCount - 1)

            dt.Rows.InsertAt(row, 0)
            DGrid.DataSource = dt

            DGrid.Columns("marca").HeaderText = "Marca"
            DGrid.Columns("modelo").HeaderText = "Modelo"
            DGrid.Columns("estilof").HeaderText = "Estilo de Fabrica"
            DGrid.Columns("descripc").HeaderText = "Descripción"
            DGrid.Columns("dias").HeaderText = "Dias Antigüedad"
            If Opcion2 = 1 Then
                DGrid.Columns("total").HeaderText = "Pares"
            Else
                DGrid.Columns("total").HeaderText = "Costo"
            End If

            If Sw_Mas250 = False Then
                DGrid.Columns(7).HeaderText = "Costo"
                DGrid.Columns(8).HeaderText = "Venta"
                DGrid.Columns(9).HeaderText = "Margen"
                DGrid.Columns(7).DefaultCellStyle.Format = "c"
                DGrid.Columns(8).DefaultCellStyle.Format = "c"
                DGrid.Columns(9).DefaultCellStyle.Format = "#0.00"
            Else
                If sw_load = True Then
                    DGrid.Columns(6).HeaderText = "Costo"
                    DGrid.Columns(7).HeaderText = "Venta"
                    DGrid.Columns(8).HeaderText = "Margen"

                    DGrid.Columns(6).DefaultCellStyle.Format = "c"
                    DGrid.Columns(7).DefaultCellStyle.Format = "c"
                    DGrid.Columns(8).DefaultCellStyle.Format = "#0.00"
                Else
                    DGrid.Columns(6).HeaderText = "Pares"
                    DGrid.Columns(7).HeaderText = "Precio Lista"
                    DGrid.Columns(8).HeaderText = "Costo"
                    DGrid.Columns(9).HeaderText = "Venta"
                    DGrid.Columns(10).HeaderText = "Margen"

                    DGrid.Columns(7).DefaultCellStyle.Format = "c"
                    DGrid.Columns(8).DefaultCellStyle.Format = "c"
                    DGrid.Columns(9).DefaultCellStyle.Format = "c"
                    DGrid.Columns(10).DefaultCellStyle.Format = "#0.00"
                End If
            End If




            DGrid.RowHeadersVisible = False
            For i As Integer = 0 To DGrid.ColumnCount - 1
                DGrid.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next

            DGrid.Columns("dias").DefaultCellStyle.Format = "#,##0"
            If Opcion2 = 1 Then
                DGrid.Columns("total").DefaultCellStyle.Format = "#,##0"
            Else
                DGrid.Columns("total").DefaultCellStyle.Format = "c"
            End If

            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            DGrid.Rows(0).Frozen = True
            DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

            DGrid.Columns(1).Frozen = True
            DGrid.Columns(1).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(1).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            DGrid.Columns(2).Frozen = True
            DGrid.Columns(2).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(2).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

            If blnBorroCol = True Then
                DGrid.Columns.Remove(DGrid.Columns("renglon"))
            End If
            blnBorroCol = True
            AgregarColumna()
            For i As Integer = 1 To DGrid.Rows.Count - 2
                DGrid.Rows(i).Cells("Renglon").Value = i.ToString
            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Sub InicializaGridInventario()
        Try
            PBox.Visible = False
            Btn_Foto.Enabled = False
            Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)

            Dim row As DataRow = dt.NewRow()

            If Opcion = 1 Then
                row(1) = "TOTAL: "
            ElseIf Opcion = 12 Then
                row(1) = "TOTAL: "
            Else
                row(0) = "TOTAL: "
            End If

            row("pares") = pub_SumarColumnaGridNombre(DGrid, "pares", DGrid.RowCount - 1)
            row("porc") = pub_SumarColumnaGridNombre(DGrid, "porc", DGrid.RowCount - 1)

            row("precioC") = pub_SumarColumnaGridNombre(DGrid, "precioC", DGrid.RowCount - 1)

            dt.Rows.InsertAt(row, 0)
            DGrid.DataSource = dt

            If Opcion = 1 Then
                DGrid.Columns("sucursal").HeaderText = "sucursal"
                DGrid.Columns("descripsucursal").HeaderText = "Sucursal"
            ElseIf Opcion = 2 Then
                DGrid.Columns("division").HeaderText = "División"
            ElseIf Opcion = 3 Then
                DGrid.Columns("depto").HeaderText = "Departamento"
            ElseIf Opcion = 4 Then
                DGrid.Columns("familia").HeaderText = "Familia"
            ElseIf Opcion = 5 Then
                DGrid.Columns("linea").HeaderText = "Linea"
            ElseIf Opcion = 6 Then
                DGrid.Columns("l1").HeaderText = "L1"
            ElseIf Opcion = 7 Then
                DGrid.Columns("l2").HeaderText = "L2"
            ElseIf Opcion = 8 Then
                DGrid.Columns("l3").HeaderText = "L3"
            ElseIf Opcion = 9 Then
                DGrid.Columns("l4").HeaderText = "L4"
            ElseIf Opcion = 10 Then
                DGrid.Columns("l5").HeaderText = "L5"
            ElseIf Opcion = 11 Then
                DGrid.Columns("l6").HeaderText = "L6"
            ElseIf Opcion = 12 Then
                DGrid.Columns("marca").HeaderText = "Marca"
                DGrid.Columns("descripmarca").HeaderText = "Marca"
                DGrid.Columns("marca").Visible = False
            ElseIf Opcion = 13 Then
                DGrid.Columns("marca").HeaderText = "Marca"
                DGrid.Columns("modelo").HeaderText = "Modelo"
                DGrid.Columns("estilof").HeaderText = "Estilo Fabrica"
                DGrid.Columns("Descripc").HeaderText = "Descripción"
            End If



            DGrid.Columns("pares").HeaderText = "Pares"
            DGrid.Columns("porc").HeaderText = "%"

            If Opcion <> 13 Then
                DGrid.Columns("precioc").Visible = False
            End If
            DGrid.Columns("precioc").HeaderText = "Precio C/IVA"
            
            DGrid.RowHeadersVisible = False
            For i As Integer = 0 To DGrid.ColumnCount - 1
                DGrid.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next

            DGrid.Columns("pares").DefaultCellStyle.Format = "#,##0"

            DGrid.Columns("precioC").DefaultCellStyle.Format = "c"
            

            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            DGrid.Rows(0).Frozen = True
            DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            If Opcion = 1 Then
                DGrid.Columns("sucursal").Visible = False
                DGrid.Columns("descripsucursal").Frozen = True
                DGrid.Columns("descripsucursal").DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Columns("descripsucursal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns("descripsucursal").DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If
            If Opcion = 12 Then
                DGrid.Columns("descripmarca").Frozen = True
                DGrid.Columns("descripmarca").DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Columns("descripmarca").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns("descripmarca").DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If
            DGrid.Columns(1).Frozen = True
            DGrid.Columns(1).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(1).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

            If Opcion = 13 Then
                DGrid.Columns(2).Frozen = True
                DGrid.Columns(2).DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(2).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If

            If blnBorroCol = True Then
                DGrid.Columns.Remove(DGrid.Columns("renglon"))
            End If
            blnBorroCol = True
            AgregarColumna()
            For i As Integer = 1 To DGrid.Rows.Count - 2
                DGrid.Rows(i).Cells("Renglon").Value = i.ToString
            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick
        Try
            If Opcion = 1 Then
                If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                    If Sucursal = "" Then
                        Sucursal = ""
                    End If
                Else
                    Sucursal = DGrid.CurrentRow.Cells("sucursal").Value
                    DescripSucursal = DGrid.CurrentRow.Cells("DescripSucursal").Value
                End If
                arreglo(intPosicion) = Opcion
                intPosicion += 1
                Opcion = 2
                RellenaGrid()
                Exit Sub
            ElseIf Opcion = 2 Then
                If DGrid.CurrentRow.Cells(0).Value = "TOTAL: " Then
                    If Division = "" Then
                        Division = ""
                    End If
                Else
                    Division = DGrid.CurrentRow.Cells("division").Value
                End If
                arreglo(intPosicion) = Opcion
                intPosicion += 1
                Opcion = 3
                RellenaGrid()
                Exit Sub
            ElseIf Opcion = 3 Then
                If DGrid.CurrentRow.Cells(0).Value = "TOTAL: " Then
                    If Depto = "" Then
                        Depto = ""
                    End If
                Else
                    Depto = DGrid.CurrentRow.Cells("depto").Value
                End If
                arreglo(intPosicion) = Opcion
                intPosicion += 1
                Opcion = 4
                RellenaGrid()
                Exit Sub
            ElseIf Opcion = 4 Then
                If DGrid.CurrentRow.Cells(0).Value = "TOTAL: " Then
                    If Familia = "" Then
                        Familia = ""
                    End If
                Else
                    Familia = DGrid.CurrentRow.Cells("familia").Value
                End If
                arreglo(intPosicion) = Opcion
                intPosicion += 1
                Opcion = 5
                RellenaGrid()
                Exit Sub
            ElseIf Opcion = 5 Then
                If DGrid.CurrentRow.Cells(0).Value = "TOTAL: " Then
                    If Linea = "" Then
                        Linea = ""
                    End If
                Else
                    Linea = DGrid.CurrentRow.Cells("linea").Value
                End If
                arreglo(intPosicion) = Opcion
                intPosicion += 1
                Opcion = 6
                RellenaGrid()
                Exit Sub
            ElseIf Opcion = 6 Then
                If DGrid.CurrentRow.Cells(0).Value = "TOTAL: " Then
                    If L1 = "" Then
                        L1 = ""
                    End If
                Else
                    L1 = DGrid.CurrentRow.Cells("l1").Value
                End If
                arreglo(intPosicion) = Opcion
                intPosicion += 1
                Opcion = 7
                RellenaGrid()
                Exit Sub
            ElseIf Opcion = 7 Then
                If DGrid.CurrentRow.Cells(0).Value = "TOTAL: " Then
                    If L2 = "" Then
                        L2 = ""
                    End If
                Else
                    L2 = DGrid.CurrentRow.Cells("l2").Value
                End If
                arreglo(intPosicion) = Opcion
                intPosicion += 1
                Opcion = 8
                RellenaGrid()
                Exit Sub
            ElseIf Opcion = 8 Then
                If DGrid.CurrentRow.Cells(0).Value = "TOTAL: " Then
                    If L3 = "" Then
                        L3 = ""
                    End If
                Else
                    L3 = DGrid.CurrentRow.Cells("l3").Value
                End If
                arreglo(intPosicion) = Opcion
                intPosicion += 1
                Opcion = 9
                RellenaGrid()
                Exit Sub
            ElseIf Opcion = 9 Then
                If DGrid.CurrentRow.Cells(0).Value = "TOTAL: " Then
                    If L4 = "" Then
                        L4 = ""
                    End If
                Else
                    L4 = DGrid.CurrentRow.Cells("l4").Value
                End If
                arreglo(intPosicion) = Opcion
                intPosicion += 1
                Opcion = 10
                RellenaGrid()
                Exit Sub
            ElseIf Opcion = 10 Then
                If DGrid.CurrentRow.Cells(0).Value = "TOTAL: " Then
                    If L5 = "" Then
                        L5 = ""
                    End If
                Else
                    L5 = DGrid.CurrentRow.Cells("l5").Value
                End If
                arreglo(intPosicion) = Opcion
                intPosicion += 1
                Opcion = 11
                RellenaGrid()
                Exit Sub
            ElseIf Opcion = 11 Then
                If DGrid.CurrentRow.Cells(0).Value = "TOTAL: " Then
                    If L6 = "" Then
                        L6 = ""
                    End If
                Else
                    L6 = DGrid.CurrentRow.Cells("l6").Value
                End If
                arreglo(intPosicion) = Opcion
                intPosicion += 1
                'OpcionAntMarca = Opcion
                Opcion = 12
                RellenaGrid()
                Exit Sub
            ElseIf Opcion = 12 Then
                If DGrid.CurrentRow.Cells(1).Value.ToString = "TOTAL: " Then
                    If Marca = "" Then
                        Marca = ""
                        blnMar = True
                    Else
                        blnMar = False
                    End If
                    blnNoEsTot = True
                    arreglo(intPosicion) = Opcion
                    intPosicion += 1
                    Opcion = 13
                    RellenaGrid()
                Else
                    Marca = DGrid.CurrentRow.Cells("marca").Value
                    blnMar = False
                    blnNoEsTot = True
                    arreglo(intPosicion) = Opcion
                    intPosicion += 1
                    Opcion = 13
                    RellenaGrid()
                End If

                Exit Sub
            ElseIf Opcion = 13 Then
                If Accion = 2 Then
                    If strQueryInv = "" Then
                        If DGrid.CurrentRow.Cells(0).Value = "TOTAL: " Then
                            'Marca = ""
                            blnNoEsTot = False
                            arreglo(intPosicion) = Opcion
                            intPosicion += 1
                            Opcion = 14
                            RellenaGrid()
                        Else
                            Marca = DGrid.CurrentRow.Cells("marca").Value
                            Modelo = DGrid.CurrentRow.Cells("modelo").Value
                            blnNoEsTot = True
                            arreglo(intPosicion) = Opcion
                            intPosicion += 1
                            Opcion = 14
                            RellenaGrid()
                        End If


                        Exit Sub
                    End If

                End If
            End If
        Catch ExceptionErr As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Function Sucursales() As String
        Try

            If Sucursal.Trim <> "" Then
                Return "INSERT INTO suc (sucursal) VALUES ('" + Sucursal.Trim + "'); "
            Else
                Using objPedidos As New BCL.BCLResurtido(GLB_ConStringCipSis)
                    objDataSet = objPedidos.usp_TraerSucursal("")
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Dim strSuc As String = ""
                    strSuc = "INSERT INTO suc (sucursal) VALUES "

                    For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                        If objDataSet.Tables(0).Rows(i).Item("visible").ToString.Trim = "S" Then
                            strSuc += "('" + objDataSet.Tables(0).Rows(i).Item("sucursal").ToString.Trim + "'), "
                        End If
                    Next


                    Return strSuc.Substring(0, strSuc.Length - 2) + ";"
            End If
            Return ""
            End If

        Catch ExceptionErr As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Private Sub InventarioAnterior()
        Try
            strQueryInv = "INSERT INTO tbl_tempinv (sucursal, marca, modelo, ctd, costotsiva, ventatsiva, costotciva, ventatciva) " & vbCrLf & _
            "select  s.sucursal, e.marca, e.modelo, e.ctd, e.costotsiva, e.ventatsiva from cipsis.aparadorleer e " & vbCrLf & _
            "join cipsis.corrida c " & vbCrLf & _
            "on e.marca = c.marca and e.modelo = c.estilon and e.corrida = c.corrida and e.proveedor = c.proveedor " & vbCrLf & _
             ";"

            ' strQueryInv strQueryInv.Substring(0, strQueryInv.Length) + ";"
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub






    Private Sub Btn_Regresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Regresar.Click
        Try
            If Opcion = 1 Then
                Me.Close()
                Exit Sub
            End If
            intPosicion -= 1
            Opcion = arreglo(intPosicion)
            If Opcion = 14 Then
                'Opcion = 12
                Modelo = ""
                Marca = ""
                RellenaGrid()
                Exit Sub
            ElseIf Opcion = 13 Then
                'Opcion = 12
                'Marca = ""
                If blnMar = True Then
                    Marca = ""
                End If
                Modelo = ""
                RellenaGrid()
                Exit Sub
            ElseIf Opcion = 12 Then
                'Opcion = OpcionAntMarca
                'OpcionAntMarca = 0
                'RegresarMarca()
                Marca = ""
                RellenaGrid()
                Exit Sub
            ElseIf Opcion = 11 Then
                'Opcion = 10
                L6 = ""
                RellenaGrid()
                Exit Sub
            ElseIf Opcion = 10 Then
                'Opcion = 9
                L5 = ""
                RellenaGrid()
                Exit Sub
            ElseIf Opcion = 9 Then
                'Opcion = 8
                L4 = ""
                RellenaGrid()
                Exit Sub
            ElseIf Opcion = 8 Then
                'Opcion = 7
                L3 = ""
                RellenaGrid()
                Exit Sub
            ElseIf Opcion = 7 Then
                'Opcion = 6
                L2 = ""
                RellenaGrid()
                Exit Sub
            ElseIf Opcion = 6 Then
                'Opcion = 5
                L1 = ""
                RellenaGrid()
                Exit Sub
            ElseIf Opcion = 5 Then
                'Opcion = 4
                Linea = ""
                RellenaGrid()
                Exit Sub
            ElseIf Opcion = 4 Then
                'Opcion = 3
                Familia = ""
                RellenaGrid()
                Exit Sub
            ElseIf Opcion = 3 Then
                'Opcion = 2
                Depto = ""
                RellenaGrid()
                Exit Sub
            ElseIf Opcion = 2 Then
                'Opcion = 1
                Division = ""
                RellenaGrid()
                Exit Sub
            ElseIf Opcion = 1 Then
                Sucursal = ""
                RellenaGrid()
                Exit Sub
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub SucursalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemSucursal.Click
        Try
            ClickDerecho()
            Sucursal = ""
            arreglo(intPosicion) = Opcion
            intPosicion += 1
            Opcion = 1
            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DivisionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemDivision.Click
        Try
            ClickDerecho()
            Division = ""
            arreglo(intPosicion) = Opcion
            intPosicion += 1
            Opcion = 2
            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DepartamentoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemDepto.Click
        Try
            ClickDerecho()
            Depto = ""
            arreglo(intPosicion) = Opcion
            intPosicion += 1
            Opcion = 3
            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub FamiliaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemFamilia.Click
        Try
            ClickDerecho()
            Familia = ""
            arreglo(intPosicion) = Opcion
            intPosicion += 1
            Opcion = 4
            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub LineaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemLinea.Click
        Try
            ClickDerecho()
            Linea = ""
            arreglo(intPosicion) = Opcion
            intPosicion += 1
            Opcion = 5
            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub L1ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemL1.Click
        Try
            ClickDerecho()
            L1 = ""
            arreglo(intPosicion) = Opcion
            intPosicion += 1
            Opcion = 6
            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub L2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemL2.Click
        Try
            ClickDerecho()
            L2 = ""
            arreglo(intPosicion) = Opcion
            intPosicion += 1
            Opcion = 7
            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub L3ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemL3.Click
        Try
            ClickDerecho()
            L3 = ""
            arreglo(intPosicion) = Opcion
            intPosicion += 1
            Opcion = 8
            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub L4ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemL4.Click
        Try
            ClickDerecho()
            L4 = ""
            arreglo(intPosicion) = Opcion
            intPosicion += 1
            Opcion = 9
            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub L5ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemL5.Click
        Try
            ClickDerecho()
            L5 = ""
            arreglo(intPosicion) = Opcion
            intPosicion += 1
            Opcion = 10
            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub L6ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemL6.Click
        Try
            ClickDerecho()
            L6 = ""
            arreglo(intPosicion) = Opcion
            intPosicion += 1
            Opcion = 11
            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub MarcaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemMarca.Click
        Try
            ClickDerecho()
            Marca = ""
            arreglo(intPosicion) = Opcion
            intPosicion += 1
            'OpcionAntMarca = Opcion
            Opcion = 12
            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ModeloToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemModelo.Click
        Try
            If Accion = 1 Then
                Dim NomCol As String = DGrid.Columns(DGrid.CurrentCell.ColumnIndex).Name
                'NomCol = NomCol.Substring(5)
                If NomCol = "L1" Or NomCol = "L2" Or NomCol = "L3" Or NomCol = "L4" Or NomCol = "L5" Or NomCol = "L6" Then
                    DiasIni = 0
                    DiasFin = 0
                Else
                    If IsNumeric(NomCol.Substring(5)) Or NomCol = "TOTAL" Then
                        If NomCol = "TOTAL" Then
                            DiasIni = 0
                            DiasFin = 0
                        Else
                            blnDias = True
                            NomCol = NomCol.Substring(5)
                            DiasFin = CInt(NomCol)
                            DiasIni = RegresaDiasIni()
                        End If
                    End If
                End If
            End If

            'Exit Sub
            ClickDerecho()
            Modelo = ""
            arreglo(intPosicion) = Opcion
            intPosicion += 1
            'OpcionAntMarca = Opcion
            Opcion = 13
            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Function RegresaDiasIni() As Integer
        If DiasFin = 15 Then
            Return 0
        ElseIf DiasFin = 30 Then
            Return 16
        ElseIf DiasFin = 45 Then
            Return 31
        ElseIf DiasFin = 60 Then
            Return 46
        ElseIf DiasFin = 90 Then
            Return 61
        ElseIf DiasFin = 120 Then
            Return 91
        ElseIf DiasFin = 140 Then
            Return 121
        ElseIf DiasFin = 160 Then
            Return 141
        ElseIf DiasFin = 200 Then
            Return 161
        ElseIf DiasFin = 250 Then
            Return 201
        ElseIf DiasFin = 300 Then
            Return 251
        ElseIf DiasFin = 350 Then
            Return 301
        ElseIf DiasFin = 450 Then
            Return 351
        ElseIf DiasFin = 550 Then
            Return 451
        ElseIf DiasFin = 650 Then
            Return 551
        ElseIf DiasFin = 750 Then
            Return 651
        ElseIf DiasFin = 850 Then
            Return 751
        ElseIf DiasFin = 1000 Then
            Return 851
        ElseIf DiasFin = 1500 Then
            Return 1001
        ElseIf DiasFin = 2000 Then
            Return 1501
        Else
            DiasFin = 0
            Return 2001
        End If
    End Function

    Private Sub InicioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemInicio.Click
        Try
            Sucursal = ""
            Division = ""
            Depto = ""
            Familia = ""
            Linea = ""
            L1 = ""
            L2 = ""
            L3 = ""
            L4 = ""
            L5 = ""
            L6 = ""
            Marca = ""
            Modelo = ""
            intPosicion = 0
            arreglo(100) = New Integer
            'If RB_Activas.Checked Then
            '    Opcion = 1
            '    RellenaGrid()
            'Else
            '    RB_Activas.Checked = True
            'End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub CatModeloToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemCatModelo.Click
        Try
            Dim myForm As New frmCatalogoModelos
            myForm.Txt_Marca.Text = DGrid.CurrentRow.Cells("Marca").Value
            myForm.Txt_Modelo.Text = DGrid.CurrentRow.Cells("Modelo").Value
            myForm.Accion = 2
            myForm.Show()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub AnaModeloToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemAnaModelo.Click
        Try
            Dim myForm As New frmAnalisisModelo
            myForm.Txt_Marca.Text = DGrid.CurrentRow.Cells("Marca").Value
            myForm.Txt_Modelo.Text = DGrid.CurrentRow.Cells("Modelo").Value
            myForm.Accion = 1
            myForm.WindowState = FormWindowState.Maximized
            myForm.Show()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ClickDerecho()
        If Opcion = 1 Then
            If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                If Sucursal = "" Then
                    Sucursal = ""
                End If
            Else
                Sucursal = DGrid.CurrentRow.Cells("sucursal").Value
                DescripSucursal = DGrid.CurrentRow.Cells("DescripSucursal").Value
            End If
        ElseIf Opcion = 2 Then
            If DGrid.CurrentRow.Cells(0).Value = "TOTAL: " Then
                If Division = "" Then
                    Division = ""
                End If
            Else
                Division = DGrid.CurrentRow.Cells("division").Value
            End If
        ElseIf Opcion = 3 Then
            If DGrid.CurrentRow.Cells(0).Value = "TOTAL: " Then
                If Depto = "" Then
                    Depto = ""
                End If
            Else
                Depto = DGrid.CurrentRow.Cells("depto").Value
            End If
        ElseIf Opcion = 4 Then
            If DGrid.CurrentRow.Cells(0).Value = "TOTAL: " Then
                If Familia = "" Then
                    Familia = ""
                End If
            Else
                Familia = DGrid.CurrentRow.Cells("familia").Value
            End If
        ElseIf Opcion = 5 Then
            If DGrid.CurrentRow.Cells(0).Value = "TOTAL: " Then
                If Linea = "" Then
                    Linea = ""
                End If
            Else
                Linea = DGrid.CurrentRow.Cells("linea").Value
            End If
        ElseIf Opcion = 6 Then
            If DGrid.CurrentRow.Cells(0).Value = "TOTAL: " Then
                If L1 = "" Then
                    L1 = ""
                End If
            Else
                L1 = DGrid.CurrentRow.Cells("l1").Value
            End If
        ElseIf Opcion = 7 Then
            If DGrid.CurrentRow.Cells(0).Value = "TOTAL: " Then
                If L2 = "" Then
                    L2 = ""
                End If
            Else
                L2 = DGrid.CurrentRow.Cells("l2").Value
            End If
        ElseIf Opcion = 8 Then
            If DGrid.CurrentRow.Cells(0).Value = "TOTAL: " Then
                If L3 = "" Then
                    L3 = ""
                End If
            Else
                L3 = DGrid.CurrentRow.Cells("l3").Value
            End If
        ElseIf Opcion = 9 Then
            If DGrid.CurrentRow.Cells(0).Value = "TOTAL: " Then
                If L4 = "" Then
                    L4 = ""
                End If
            Else
                L4 = DGrid.CurrentRow.Cells("l4").Value
            End If
        ElseIf Opcion = 10 Then
            If DGrid.CurrentRow.Cells(0).Value = "TOTAL: " Then
                If L5 = "" Then
                    L5 = ""
                End If
            Else
                L5 = DGrid.CurrentRow.Cells("l5").Value
            End If
        ElseIf Opcion = 11 Then
            If DGrid.CurrentRow.Cells(0).Value = "TOTAL: " Then
                If L6 = "" Then
                    L6 = ""
                End If
            Else
                L6 = DGrid.CurrentRow.Cells("l6").Value
            End If
        ElseIf Opcion = 12 Then
            If DGrid.CurrentRow.Cells(0).Value = "TOTAL: " Then
                If Marca = "" Then
                    Marca = ""
                End If
            Else
                Marca = DGrid.CurrentRow.Cells("marca").Value
            End If
        ElseIf Opcion = 13 Then
            If DGrid.CurrentRow.Cells(0).Value = "TOTAL: " Then
                If Modelo = "" Then
                    Modelo = ""
                End If
            Else
                Modelo = DGrid.CurrentRow.Cells("modelo").Value
            End If
        End If
    End Sub

    'Private Sub RegresarMarca()
    '    If Opcion = 1 Then
    '        Sucursal = ""
    '    ElseIf Opcion = 2 Then
    '        If Chk_Calzado.Checked = False Then
    '            Division = ""
    '        End If
    '    ElseIf Opcion = 3 Then
    '        Depto = ""
    '    ElseIf Opcion = 4 Then
    '        Familia = ""
    '    ElseIf Opcion = 5 Then
    '        Linea = ""
    '    ElseIf Opcion = 6 Then
    '        L1 = ""
    '    ElseIf Opcion = 7 Then
    '        L2 = ""
    '    ElseIf Opcion = 8 Then
    '        L3 = ""
    '    ElseIf Opcion = 9 Then
    '        L4 = ""
    '    ElseIf Opcion = 10 Then
    '        L5 = ""
    '    ElseIf Opcion = 11 Then
    '        L6 = ""
    '    End If
    'End Sub

    Private Sub Chk_Calzado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_Calzado.CheckedChanged
        Try
            If Chk_Calzado.Checked Then
                Division = "CALZADO"
            Else
                Division = ""
            End If
            If checkInicio = True Then
                RellenaGrid()
            End If
            checkInicio = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub UltimaModificacion()
        Dim fechainve As Date
        Try
            If strQueryInv <> "" Then
                fechainve = CDate(FechaInv)
                'Lbl_FUM.Text = "Inventario al " + fechainve.ToString("dd-MMM-yyyy").ToUpper
            Else
                Using objFUM As New BCL.BCLAntiInvent(GLB_ConStringDWH)
                    objDataSet = objFUM.usp_TraerFecUltMod(Accion)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    FecHora = CDate(objDataSet.Tables(0).Rows(0).Item("fum"))
                    'Lbl_FUM.Text = "Ultima Modificación: " & FecHora.ToString("dd-MMM-yyyy hh:mm:ss tt").ToUpper
                    FechaInv = FecHora.ToString("yyyy-MM-dd")
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    'Private Sub Componentes()
    '    If Sucursal.Trim = "" Then
    '        GB_Sucursales.Enabled = True
    '    Else
    '        GB_Sucursales.Enabled = False
    '    End If
    'End Sub

    Private Sub GeneraTexto()
        If GLB_CveSucursal > "0" And GLB_CveSucursal < "90" Then
            Sucursal = GLB_Sucursal
        End If
        If Sucursal <> "" Then
            lbl_Sucursal.Text = DescripSucursal
  
        End If
        If Division = "" Then
            If Opcion = 2 Then
                lbl_Division.Text = "DIVISIÓN"
            Else
                lbl_Division.Text = ""
            End If
        Else
            lbl_Division.Text = Division
        End If
        If Depto = "" Then
            If Opcion = 3 Then
                lbl_Depto.Text = "DEPARTAMENTO"
            Else
                lbl_Depto.Text = ""
            End If
        Else
            lbl_Depto.Text = Depto
        End If
        If Familia = "" Then
            If Opcion = 4 Then
                lbl_Familia.Text = "FAMILIA"
            Else
                lbl_Familia.Text = ""
            End If
        Else
            lbl_Familia.Text = Familia
        End If
        If Linea = "" Then
            If Opcion = 5 Then
                lbl_Linea.Text = "LINEA"
            Else
                lbl_Linea.Text = ""
            End If
        Else
            lbl_Linea.Text = Linea
        End If
        If L1 = "" Then
            If Opcion = 6 Then
                lbl_L1.Text = "L1"
            Else
                lbl_L1.Text = ""
            End If
        Else
            lbl_L1.Text = L1
        End If
        If L2 = "" Then
            If Opcion = 7 Then
                lbl_L2.Text = "L2"
            Else
                lbl_L2.Text = ""
            End If
        Else
            lbl_L2.Text = L2
        End If
        If L3 = "" Then
            If Opcion = 8 Then
                lbl_L3.Text = "L3"
            Else
                lbl_L3.Text = ""
            End If
        Else
            lbl_L3.Text = L3
        End If
        If L4 = "" Then
            If Opcion = 9 Then
                lbl_L4.Text = "L4"
            Else
                lbl_L4.Text = ""
            End If
        Else
            lbl_L4.Text = L4
        End If
        If L5 = "" Then
            If Opcion = 10 Then
                lbl_L5.Text = "L5"
            Else
                lbl_L5.Text = ""
            End If
        Else
            lbl_L5.Text = L5
        End If
        If L6 = "" Then
            If Opcion = 11 Then
                lbl_L6.Text = "L6"
            Else
                lbl_L6.Text = ""
            End If
        Else
            lbl_L6.Text = L6
        End If
        If Marca = "" Then
            If Opcion = 12 Then
                lbl_Marca.Text = "MARCAS"
            Else
                lbl_Marca.Text = ""
            End If
        Else
            lbl_Marca.Text = Marca
        End If
        If Modelo = "" Then
            If Opcion = 13 Then
                lbl_Modelo.Text = "MODELOS"
            Else
                lbl_Modelo.Text = ""
            End If
        Else
            lbl_Modelo.Text = Modelo
        End If
        If blnDias = True Then
            lbl_Dias.Text = "ANTIGÜEDAD " + DiasFin.ToString + " DÍAS"
            DiasIni = 0
            DiasFin = 0
            blnDias = False
        Else
            lbl_Dias.Text = ""
        End If

        If lbl_Sucursal.Text.Trim <> "" Then
            lbl_Final.Text = lbl_Sucursal.Text
        End If
        If lbl_Division.Text.Trim <> "" Then
            lbl_Final.Text += ", " + lbl_Division.Text
        End If
        If lbl_Depto.Text.Trim <> "" Then
            lbl_Final.Text += ", " + lbl_Depto.Text
        End If
        If lbl_Familia.Text.Trim <> "" Then
            lbl_Final.Text += ", " + lbl_Familia.Text
        End If
        If lbl_Linea.Text.Trim <> "" Then
            lbl_Final.Text += ", " + lbl_Linea.Text
        End If
        If lbl_L1.Text.Trim <> "" Then
            lbl_Final.Text += ", " + lbl_L1.Text
        End If
        If lbl_L2.Text.Trim <> "" Then
            lbl_Final.Text += ", " + lbl_L2.Text
        End If
        If lbl_L3.Text.Trim <> "" Then
            lbl_Final.Text += ", " + lbl_L3.Text
        End If
        If lbl_L4.Text.Trim <> "" Then
            lbl_Final.Text += ", " + lbl_L4.Text
        End If
        If lbl_L5.Text.Trim <> "" Then
            lbl_Final.Text += ", " + lbl_L5.Text
        End If
        If lbl_L6.Text.Trim <> "" Then
            lbl_Final.Text += ", " + lbl_L6.Text
        End If
        If lbl_Marca.Text.Trim <> "" Then
            lbl_Final.Text += ", " + lbl_Marca.Text
        End If
        If lbl_Modelo.Text.Trim <> "" Then
            lbl_Final.Text += ", " + lbl_Modelo.Text
        End If
        If lbl_Dias.Text.Trim <> "" Then
            lbl_Final.Text += ", " + lbl_Dias.Text
        End If
    End Sub

    Private Sub CargarFotoArticulo(ByVal Marca, ByVal Estilon)
        'mreyes 14/Marzo/2012 07:06 p.m.
        'Glb_RutaArchivoFotos
        Try
            Dim Archivo As String = ""
            Dim NoFoto As String = "1"

            MarcaFOTO = Marca
            EstiloNFOTO = Estilon
            PBox.Visible = False
            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)

                Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Marca, Estilon, NoFoto)

                If objIO.pub_ExisteArchivo(Archivo) = True Then
                    PBox.Image = New System.Drawing.Bitmap(Archivo)
                    PBox.Visible = True
                    Exit Sub


                End If

                For i As Integer = 0 To 9
                    Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Marca, Estilon, i)
                    If objIO.pub_ExisteArchivo(Archivo) = True Then
                        PBox.Image = New System.Drawing.Bitmap(Archivo)
                        PBox.Visible = True
                        Exit Sub
                    End If
                Next

            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.Click
        Try

            If Opcion = 13 Or Opcion = 14 Then


                If IsDBNull(DGrid.CurrentRow.Cells("Marca").Value) Or IsDBNull(DGrid.CurrentRow.Cells("Marca").Value) Then
                    PBox.Visible = False
                Else
                    If Opcion = 13 And DGrid.CurrentRow.Cells("Marca").Value = "TOTAL: " Then
                        PBox.Visible = False
                    Else
                        CargarFotoArticulo(DGrid.CurrentRow.Cells("Marca").Value, DGrid.CurrentRow.Cells("Modelo").Value)
                    End If
                End If


            Else
                PBox.Visible = False
            End If
            If Accion = 1 Then
                Dim Suma As Integer = 0
                Dim Renglon As Integer
                Dim Columna As Integer
                If DGrid.SelectedCells.Count > 1 Then
                    For i As Integer = 0 To DGrid.SelectedCells.Count - 1
                        Columna = DGrid.SelectedCells.Item(i).ColumnIndex
                        Renglon = DGrid.SelectedCells.Item(i).RowIndex
                        If Opcion <> 13 Then
                            If DGrid.Columns(Columna).Name.Substring(0, 4).Trim = "dias" Or _
                            DGrid.Columns(Columna).Name.Substring(0, 5).Trim = "total" Then
                                If Not IsDBNull(DGrid.Rows(Renglon).Cells(Columna).Value) Then
                                    Suma += DGrid.Rows(Renglon).Cells(Columna).Value
                                End If
                            End If
                        Else
                            If DGrid.Columns(Columna).Name.Trim = "total" Then
                                If Not IsDBNull(DGrid.Rows(Renglon).Cells(Columna).Value) Then
                                    Suma += DGrid.Rows(Renglon).Cells(Columna).Value
                                End If
                            End If
                        End If
                    Next
                    
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGrid.KeyUp
        Try
            If Opcion = 13 Or Opcion = 14 Then
                If IsDBNull(DGrid.CurrentRow.Cells("Marca").Value) Then
                    PBox.Visible = False
                Else
                    CargarFotoArticulo(DGrid.CurrentRow.Cells("Marca").Value, DGrid.CurrentRow.Cells("Modelo").Value)
                End If
            Else
                PBox.Visible = False
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Foto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Foto.Click
        Try
            Dim myForm As New frmConsultaImagen
            myForm.Txt_Estilon.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("Modelo").Value.ToString
            myForm.Txt_Marca.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("Marca").Value.ToString.Trim()
            myForm.Txt_NoFoto.Text = "1"
            myForm.ShowDialog()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub PBox_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBox.DoubleClick
        Try
            Btn_Foto_Click(sender, e)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Excel.Click
        Try
            If ExportarDGridAExcel(DGrid) = False Then
                MsgBox("Error al exportar a Excel. Intente nuevamente.", MsgBoxStyle.Critical, "Excel")
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Me.Close()
    End Sub

    Private Sub PBox_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PBox.MouseDown
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                izquierda = e.X
                alto = e.Y
                PBox.Cursor = Cursors.SizeAll
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub PBox_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PBox.MouseMove
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                PBox.Location = New Point(PBox.Left + e.X - izquierda, PBox.Top + e.Y - alto)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub PBox_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PBox.MouseUp
        Try
            PBox.Cursor = Cursors.Default
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Filtro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        Try
            myFormFiltros.StartPosition = FormStartPosition.CenterParent
            myFormFiltros.Sw_Filtro = False
           
            myFormFiltros.DT_RecFin.Visible = False
            myFormFiltros.DT_RecIni.Visible = False
            myFormFiltros.Chk_UltRecibo.Visible = False
            'myFormFiltros.CB_Sucursal.Visible = False
            myFormFiltros.Suc = Sucursal
            'myFormFiltros.Label4.Visible = False
           
            If Accion = 1 Then
                myFormFiltros.Text = "Filtros Antigüedad Inventario"
            ElseIf Accion = 2 Then
                myFormFiltros.Text = "Filtros Inventario Costo/Venta"
                If GLB_CveSucursal > "0" And GLB_CveSucursal < "90" Then
                    myFormFiltros.CB_Sucursal.SelectedValue = GLB_CveSucursal
                    myFormFiltros.CB_Sucursal.Enabled = False
                End If
            End If





            If Division <> "" Then
                If Division = "CALZADO" Then
                    myFormFiltros.Txt_Division.Text = "001"
                ElseIf Division = "ACCESORIOS" Then
                    myFormFiltros.Txt_Division.Text = "002"
                ElseIf Division = "ELECTRONICA" Then
                    myFormFiltros.Txt_Division.Text = "003"
                ElseIf Division = "GENERAL" Then
                    myFormFiltros.Txt_Division.Text = "999"
                End If
                myFormFiltros.Txt_DescripDivision.Text = Division
            Else
                myFormFiltros.Txt_DescripDivision.Text = ""
                myFormFiltros.Txt_Division.Text = ""
            End If
            If Depto <> "" Then
                myFormFiltros.Txt_IdDepto.Text = Depto
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstDepto(0, 0, "", 0, Depto)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_DescripDepto.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                    myFormFiltros.Txt_Depto.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                End If
            End If
            If Familia <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstFamilia(0, 0, 0, "", 3, Familia)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_Familia.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripFamilia.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If Linea <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstLinea(0, 0, 0, 0, "", 3, Linea)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_Linea.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripLinea.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L1 <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl1(0, 0, 0, 0, 0, "", 3, L1)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_L1.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripL1.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L2 <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl2(0, 0, 0, 0, 0, 0, "", 3, L2)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_L2.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripL2.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L3 <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl3(0, 0, 0, 0, 0, 0, 0, "", 3, L3)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_L3.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripL3.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L4 <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl4(0, 0, 0, 0, 0, 0, 0, 0, "", 3, L4)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_L4.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripL4.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L5 <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl5(0, 0, 0, 0, 0, 0, 0, 0, 0, "", 3, L5)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_L5.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripL5.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L6 <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl6(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", 3, L6)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_L6.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripL6.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If Marca <> "" Then
                myFormFiltros.Txt_Marca.Text = Marca
            End If
            myFormFiltros.ShowDialog()
            If myFormFiltros.Sw_Filtro = True Then
                DGrid.DataSource = Nothing
                DGrid.Refresh()
                DGrid.Rows.Clear()

                If CInt(myFormFiltros.CB_Sucursal.SelectedValue.ToString) = 0 Then
                    Sucursal = ""
                Else
                    Sucursal = pub_RellenarIzquierda(myFormFiltros.CB_Sucursal.SelectedValue.ToString, 2)
                    DescripSucursal = myFormFiltros.CB_Sucursal.Text
                End If

               
                Marca = myFormFiltros.Txt_Marca.Text
                If Marca.Trim <> "" Then
                    lbl_Marca.Text = Marca
                End If

                If myFormFiltros.Txt_DescripDivision.Text.Trim = "" Then
                    Division = ""
                Else
                    Division = myFormFiltros.Txt_DescripDivision.Text
                End If
                If myFormFiltros.Txt_DescripDepto.Text.Trim = "" Then
                    Depto = ""
                Else
                    Depto = myFormFiltros.Txt_DescripDepto.Text
                End If
                If myFormFiltros.Txt_DescripFamilia.Text = "" Then
                    Familia = ""
                Else
                    Familia = myFormFiltros.Txt_DescripFamilia.Text
                End If
                If myFormFiltros.Txt_DescripLinea.Text = "" Then
                    Linea = ""
                Else
                    Linea = myFormFiltros.Txt_DescripLinea.Text
                End If
                If myFormFiltros.Txt_DescripL1.Text = "" Then
                    L1 = ""
                Else
                    L1 = myFormFiltros.Txt_DescripL1.Text
                End If
                If myFormFiltros.Txt_DescripL2.Text = "" Then
                    L2 = ""
                Else
                    L2 = myFormFiltros.Txt_DescripL2.Text
                End If
                If myFormFiltros.Txt_DescripL3.Text = "" Then
                    L3 = ""
                Else
                    L3 = myFormFiltros.Txt_DescripL3.Text
                End If
                If myFormFiltros.Txt_DescripL4.Text = "" Then
                    L4 = ""
                Else
                    L4 = myFormFiltros.Txt_DescripL4.Text
                End If
                If myFormFiltros.Txt_DescripL5.Text = "" Then
                    L5 = ""
                Else
                    L5 = myFormFiltros.Txt_DescripL5.Text
                End If
                If myFormFiltros.Txt_DescripL6.Text = "" Then
                    L6 = ""
                Else
                    L6 = myFormFiltros.Txt_DescripL6.Text
                End If

                If FechaInv <> FecHora.ToString("yyyy-MM-dd") Then
                    'Call GeneraNomTablaExist(FechaInv)
                    Call InventarioAnterior()
                Else
                    NomTablaExist = ""
                    strQueryInv = ""
                End If


                Call RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    'Private Sub GeneraNomTablaExist(ByVal Fecha As String)
    '    Dim anio As String = ""
    '    Dim mes As String = ""
    '    Try
    '        anio = Mid(Fecha, 3, 2)
    '        mes = Mid(Fecha, 6, 2)

    '        NomTablaExist = "existencia" + mes + anio
    '    Catch ExceptionErr As Exception
    '        MessageBox.Show(ExceptionErr.Message.ToString)
    '    End Try
    'End Sub

    Private Sub OcultarToolStrips()
        If Opcion = 1 Then
            ToolStripMenuItemSucursal.Visible = False
            ToolStripMenuItemDivision.Visible = True
            ToolStripMenuItemDepto.Visible = True
            ToolStripMenuItemFamilia.Visible = True
            ToolStripMenuItemLinea.Visible = True
            ToolStripMenuItemL1.Visible = True
            ToolStripMenuItemL2.Visible = True
            ToolStripMenuItemL3.Visible = True
            ToolStripMenuItemL4.Visible = True
            ToolStripMenuItemL5.Visible = True
            ToolStripMenuItemL6.Visible = True
            ToolStripMenuItemMarca.Visible = True
            ToolStripMenuItemModelo.Visible = True
            ToolStripMenuItemCatModelo.Visible = False
            ToolStripMenuItemAnaModelo.Visible = False
        End If
        If Opcion = 2 Then
            ToolStripMenuItemSucursal.Visible = True
            ToolStripMenuItemDivision.Visible = False
            ToolStripMenuItemDepto.Visible = True
            ToolStripMenuItemFamilia.Visible = True
            ToolStripMenuItemLinea.Visible = True
            ToolStripMenuItemL1.Visible = True
            ToolStripMenuItemL2.Visible = True
            ToolStripMenuItemL3.Visible = True
            ToolStripMenuItemL4.Visible = True
            ToolStripMenuItemL5.Visible = True
            ToolStripMenuItemL6.Visible = True
            ToolStripMenuItemMarca.Visible = True
            ToolStripMenuItemModelo.Visible = True
            ToolStripMenuItemCatModelo.Visible = False
            ToolStripMenuItemAnaModelo.Visible = False
        End If
        If Opcion = 3 Then
            ToolStripMenuItemSucursal.Visible = True
            ToolStripMenuItemDivision.Visible = True
            ToolStripMenuItemDepto.Visible = False
            ToolStripMenuItemFamilia.Visible = True
            ToolStripMenuItemLinea.Visible = True
            ToolStripMenuItemL1.Visible = True
            ToolStripMenuItemL2.Visible = True
            ToolStripMenuItemL3.Visible = True
            ToolStripMenuItemL4.Visible = True
            ToolStripMenuItemL5.Visible = True
            ToolStripMenuItemL6.Visible = True
            ToolStripMenuItemMarca.Visible = True
            ToolStripMenuItemModelo.Visible = True
            ToolStripMenuItemCatModelo.Visible = False
            ToolStripMenuItemAnaModelo.Visible = False
        End If
        If Opcion = 4 Then
            ToolStripMenuItemSucursal.Visible = True
            ToolStripMenuItemDivision.Visible = True
            ToolStripMenuItemDepto.Visible = True
            ToolStripMenuItemFamilia.Visible = False
            ToolStripMenuItemLinea.Visible = True
            ToolStripMenuItemL1.Visible = True
            ToolStripMenuItemL2.Visible = True
            ToolStripMenuItemL3.Visible = True
            ToolStripMenuItemL4.Visible = True
            ToolStripMenuItemL5.Visible = True
            ToolStripMenuItemL6.Visible = True
            ToolStripMenuItemMarca.Visible = True
            ToolStripMenuItemModelo.Visible = True
            ToolStripMenuItemCatModelo.Visible = False
            ToolStripMenuItemAnaModelo.Visible = False
        End If
        If Opcion = 5 Then
            ToolStripMenuItemSucursal.Visible = True
            ToolStripMenuItemDivision.Visible = True
            ToolStripMenuItemDepto.Visible = True
            ToolStripMenuItemFamilia.Visible = True
            ToolStripMenuItemLinea.Visible = False
            ToolStripMenuItemL1.Visible = True
            ToolStripMenuItemL2.Visible = True
            ToolStripMenuItemL3.Visible = True
            ToolStripMenuItemL4.Visible = True
            ToolStripMenuItemL5.Visible = True
            ToolStripMenuItemL6.Visible = True
            ToolStripMenuItemMarca.Visible = True
            ToolStripMenuItemModelo.Visible = True
            ToolStripMenuItemCatModelo.Visible = False
            ToolStripMenuItemAnaModelo.Visible = False
        End If
        If Opcion = 6 Then
            ToolStripMenuItemSucursal.Visible = True
            ToolStripMenuItemDivision.Visible = True
            ToolStripMenuItemDepto.Visible = True
            ToolStripMenuItemFamilia.Visible = True
            ToolStripMenuItemLinea.Visible = True
            ToolStripMenuItemL1.Visible = False
            ToolStripMenuItemL2.Visible = True
            ToolStripMenuItemL3.Visible = True
            ToolStripMenuItemL4.Visible = True
            ToolStripMenuItemL5.Visible = True
            ToolStripMenuItemL6.Visible = True
            ToolStripMenuItemMarca.Visible = True
            ToolStripMenuItemModelo.Visible = True
            ToolStripMenuItemCatModelo.Visible = False
            ToolStripMenuItemAnaModelo.Visible = False
        End If
        If Opcion = 7 Then
            ToolStripMenuItemSucursal.Visible = True
            ToolStripMenuItemDivision.Visible = True
            ToolStripMenuItemDepto.Visible = True
            ToolStripMenuItemFamilia.Visible = True
            ToolStripMenuItemLinea.Visible = True
            ToolStripMenuItemL1.Visible = True
            ToolStripMenuItemL2.Visible = False
            ToolStripMenuItemL3.Visible = True
            ToolStripMenuItemL4.Visible = True
            ToolStripMenuItemL5.Visible = True
            ToolStripMenuItemL6.Visible = True
            ToolStripMenuItemMarca.Visible = True
            ToolStripMenuItemModelo.Visible = True
            ToolStripMenuItemCatModelo.Visible = False
            ToolStripMenuItemAnaModelo.Visible = False
        End If
        If Opcion = 8 Then
            ToolStripMenuItemSucursal.Visible = True
            ToolStripMenuItemDivision.Visible = True
            ToolStripMenuItemDepto.Visible = True
            ToolStripMenuItemFamilia.Visible = True
            ToolStripMenuItemLinea.Visible = True
            ToolStripMenuItemL1.Visible = True
            ToolStripMenuItemL2.Visible = True
            ToolStripMenuItemL3.Visible = False
            ToolStripMenuItemL4.Visible = True
            ToolStripMenuItemL5.Visible = True
            ToolStripMenuItemL6.Visible = True
            ToolStripMenuItemMarca.Visible = True
            ToolStripMenuItemModelo.Visible = True
            ToolStripMenuItemCatModelo.Visible = False
            ToolStripMenuItemAnaModelo.Visible = False
        End If
        If Opcion = 9 Then
            ToolStripMenuItemSucursal.Visible = True
            ToolStripMenuItemDivision.Visible = True
            ToolStripMenuItemDepto.Visible = True
            ToolStripMenuItemFamilia.Visible = True
            ToolStripMenuItemLinea.Visible = True
            ToolStripMenuItemL1.Visible = True
            ToolStripMenuItemL2.Visible = True
            ToolStripMenuItemL3.Visible = True
            ToolStripMenuItemL4.Visible = False
            ToolStripMenuItemL5.Visible = True
            ToolStripMenuItemL6.Visible = True
            ToolStripMenuItemMarca.Visible = True
            ToolStripMenuItemModelo.Visible = True
            ToolStripMenuItemCatModelo.Visible = False
            ToolStripMenuItemAnaModelo.Visible = False
        End If
        If Opcion = 10 Then
            ToolStripMenuItemSucursal.Visible = True
            ToolStripMenuItemDivision.Visible = True
            ToolStripMenuItemDepto.Visible = True
            ToolStripMenuItemFamilia.Visible = True
            ToolStripMenuItemLinea.Visible = True
            ToolStripMenuItemL1.Visible = True
            ToolStripMenuItemL2.Visible = True
            ToolStripMenuItemL3.Visible = True
            ToolStripMenuItemL4.Visible = True
            ToolStripMenuItemL5.Visible = False
            ToolStripMenuItemL6.Visible = True
            ToolStripMenuItemMarca.Visible = True
            ToolStripMenuItemModelo.Visible = True
            ToolStripMenuItemCatModelo.Visible = False
            ToolStripMenuItemAnaModelo.Visible = False
        End If
        If Opcion = 11 Then
            ToolStripMenuItemSucursal.Visible = True
            ToolStripMenuItemDivision.Visible = True
            ToolStripMenuItemDepto.Visible = True
            ToolStripMenuItemFamilia.Visible = True
            ToolStripMenuItemLinea.Visible = True
            ToolStripMenuItemL1.Visible = True
            ToolStripMenuItemL2.Visible = True
            ToolStripMenuItemL3.Visible = True
            ToolStripMenuItemL4.Visible = True
            ToolStripMenuItemL5.Visible = True
            ToolStripMenuItemL6.Visible = False
            ToolStripMenuItemMarca.Visible = True
            ToolStripMenuItemModelo.Visible = True
            ToolStripMenuItemCatModelo.Visible = False
            ToolStripMenuItemAnaModelo.Visible = False
        End If
        If Opcion = 12 Then
            ToolStripMenuItemSucursal.Visible = True
            ToolStripMenuItemDivision.Visible = True
            ToolStripMenuItemDepto.Visible = True
            ToolStripMenuItemFamilia.Visible = True
            ToolStripMenuItemLinea.Visible = True
            ToolStripMenuItemL1.Visible = True
            ToolStripMenuItemL2.Visible = True
            ToolStripMenuItemL3.Visible = True
            ToolStripMenuItemL4.Visible = True
            ToolStripMenuItemL5.Visible = True
            ToolStripMenuItemL6.Visible = True
            ToolStripMenuItemMarca.Visible = False
            ToolStripMenuItemModelo.Visible = True
            ToolStripMenuItemCatModelo.Visible = False
            ToolStripMenuItemAnaModelo.Visible = False
        End If
        If Opcion = 13 Then
            ToolStripMenuItemSucursal.Visible = True
            ToolStripMenuItemDivision.Visible = True
            ToolStripMenuItemDepto.Visible = True
            ToolStripMenuItemFamilia.Visible = True
            ToolStripMenuItemLinea.Visible = True
            ToolStripMenuItemL1.Visible = True
            ToolStripMenuItemL2.Visible = True
            ToolStripMenuItemL3.Visible = True
            ToolStripMenuItemL4.Visible = True
            ToolStripMenuItemL5.Visible = True
            ToolStripMenuItemL6.Visible = True
            ToolStripMenuItemMarca.Visible = True
            ToolStripMenuItemModelo.Visible = False
            ToolStripMenuItemCatModelo.Visible = True
            ToolStripMenuItemAnaModelo.Visible = True
        End If
    End Sub

    Private Sub DGrid_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DGrid.MouseDown
        Try
            If e.Button = Windows.Forms.MouseButtons.Right Then
                With Me.DGrid
                    Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                    If Hitest.Type = DataGridViewHitTestType.Cell Then
                        .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    End If
                End With
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

   

    Private Sub Btn_Series_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Series.Click
        Try
            Dim myForm As New frmConsultaSeries

            myForm.Tipo = "A"

            myForm.Sucursal = Sucursal
            myForm.Division = Division
            myForm.Depto = Depto
            myForm.Familia = Familia
            myForm.Linea = Linea

            myForm.l1 = L1
            myForm.l2 = L2
            myForm.l3 = L3
            myForm.l4 = L4
            myForm.l5 = L5
            myForm.l6 = L6






            myForm.ShowDialog()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub
End Class