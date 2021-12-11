Imports DevExpress.Utils
Imports DevExpress.Utils.Menu
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
'RAFAEL 
' ES 
Public Class frmPpalRotacion

    Dim DT As New DataTable
    Dim NivelAct As String
    Dim CambioCheck As Boolean

#Region "Metodos"

    Private Sub RellenaGrid()
        Dim objDataSet As DataSet
        Using objEstadistica As New BCL.BCLRotacion(GLB_ConStringDwhSQL)
            objDataSet = objEstadistica.Usp_PpalRotacion(DT.Rows(DT.Rows.Count - 1).Item("Nivel").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idplaza").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idsucursal").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("FecIni").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("FecFin").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("Division").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("Depto").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("Familia").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("Linea").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("L1").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("L2").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("L3").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("L4").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("L5").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("L6").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("Marca").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("Modelo").ToString, IIf(chk_DiaMes.Checked Or chk_DiaSemana.Checked, True, False), IIf(chk_DiaMes.Checked, True, False), IIf(chk_DiaSemana.Checked, True, False), IIf(chk_Miles.Checked, 1000, 1), DT.Rows(DT.Rows.Count - 1).Item("idagrupacion").ToString.Trim, IIf(chk_SucVenta.Checked, "S", ""))
        End Using
        PBox.Visible = False
        dgv_Reporte.ActiveFilterCriteria = Nothing
        dgv_Reporte.OptionsView.ShowAutoFilterRow = False
        gc_Reporte.DataSource = Nothing
        If objDataSet.Tables(0).Rows.Count > 1 Then
            gc_Reporte.DataSource = objDataSet.Tables(0)
            InicializaGrid()
            dgv_Reporte.BestFitColumns()
        Else 'CUANDO TIENE 1 O 0 BUSCA POR MARCA
            If Not (DT.Rows(DT.Rows.Count - 1).Item("nivel").ToString.Trim = "MARCA" Or DT.Rows(DT.Rows.Count - 1).Item("nivel").ToString.Trim = "MODELO") Then
                DT.Rows(DT.Rows.Count - 1).Item("nivel") = "MARCA"
                NivelAct = "MARCA"
                RellenaGrid()
                InicializaGrid()
                dgv_Reporte.BestFitColumns()
                Exit Sub
            Else
                lbl_Texto.Text = ""
                DT.Rows(DT.Rows.Count - 1).Item("nivel") = "DIVISION"
                NivelAct = "DIVISION"
                MessageBox.Show("No se encontró información", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub CreaDTEstado()
        DT.Columns.Add("Nivel")
        DT.Columns.Add("IdPlaza")
        DT.Columns.Add("Plaza")
        DT.Columns.Add("IdSucursal")
        DT.Columns.Add("Sucursal")
        DT.Columns.Add("FecIni")
        DT.Columns.Add("FecFin")
        DT.Columns.Add("IdDivision")
        DT.Columns.Add("Division")
        DT.Columns.Add("IdDepto")
        DT.Columns.Add("Depto")
        DT.Columns.Add("IdFamilia")
        DT.Columns.Add("Familia")
        DT.Columns.Add("IdLinea")
        DT.Columns.Add("Linea")
        DT.Columns.Add("IdL1")
        DT.Columns.Add("L1")
        DT.Columns.Add("IdL2")
        DT.Columns.Add("L2")
        DT.Columns.Add("IdL3")
        DT.Columns.Add("L3")
        DT.Columns.Add("IdL4")
        DT.Columns.Add("L4")
        DT.Columns.Add("IdL5")
        DT.Columns.Add("L5")
        DT.Columns.Add("IdL6")
        DT.Columns.Add("L6")
        DT.Columns.Add("Marca")
        DT.Columns.Add("Modelo")
        DT.Columns.Add("IdAgrupacion")
        DT.Columns.Add("Agrupacion")
        NivelAct = "DIVISION"
        ' AgregaRegistroDTEstado(NivelAct, 0, "", 0, "", Format(GLB_FechaHoy.AddDays(-1), "yyyy-MM-dd"), Format(GLB_FechaHoy.AddDays(-1), "yyyy-MM-dd"), "0", "", "0", "", "0", "", "0", "", "0", "", "0", "", "0", "", "0", "", "0", "", "0", "", "", "", "0", "")
        AgregaRegistroDTEstado(NivelAct, 0, "", 0, "", Format(DateSerial(Now.Year, Now.Month, Now.Day - 31), "yyyy-MM-dd"), Format(DateSerial(Now.Year, Now.Month, Now.Day - 1), "yyyy-MM-dd"), "0", "", "0", "", "0", "", "0", "", "0", "", "0", "", "0", "", "0", "", "0", "", "0", "", "", "", "0", "")

        ' FechaIniB = Format(DateSerial(Now.Year, Now.Month, 1), "yyyy-MM-dd")
    End Sub

    Private Sub AgregaRegistroDTEstado(Nivel As String, IdPlaza As String, Plaza As String, IdSucursal As String, Sucursal As String, FecIni As String, FecFin As String, IdDivision As String, Division As String, IdDepto As String, Depto As String, IdFamilia As String, Familia As String, IdLinea As String, Linea As String, IdL1 As String, L1 As String, IdL2 As String, L2 As String, IdL3 As String, L3 As String, IdL4 As String, L4 As String, IdL5 As String, L5 As String, IdL6 As String, L6 As String, Marca As String, Modelo As String, IdAgrupacion As String, Agrupacion As String)
        DT.Rows.Add(Nivel, IdPlaza, Plaza, IdSucursal, Sucursal, FecIni, FecFin, IIf(IdDivision = "", 0, IdDivision), Division, IIf(IdDepto = "", 0, IdDepto), Depto, IIf(IdFamilia = "", 0, IdFamilia), Familia, IIf(IdLinea = "", 0, IdLinea), Linea, IIf(IdL1 = "", 0, IdL1), L1, IIf(IdL2 = "", 0, IdL2), L2, IIf(IdL3 = "", 0, IdL3), L3, IIf(IdL4 = "", 0, IdL4), L4, IIf(IdL5 = "", 0, IdL5), L5, IIf(IdL6 = "", 0, IdL6), L6, Marca, Modelo, IIf(IdAgrupacion = "", 0, IdAgrupacion), Agrupacion)
    End Sub

    Private Function TraerSigNivel(ByVal NivelActual As String) As String
        TraerSigNivel = ""
        If NivelActual = "PLAZA" Then
            TraerSigNivel = "SUCURSAL"
        ElseIf NivelActual = "SUCURSAL" Then
            TraerSigNivel = "DIVISION"
        ElseIf NivelActual = "DIVISION" Then
            TraerSigNivel = "DEPTO"
        ElseIf NivelActual = "DEPTO" Then
            TraerSigNivel = "FAMILIA"
        ElseIf NivelActual = "FAMILIA" Then
            TraerSigNivel = "LINEA"
        ElseIf NivelActual = "LINEA" Then
            TraerSigNivel = "L1"
        ElseIf NivelActual = "L1" Then
            TraerSigNivel = "L2"
        ElseIf NivelActual = "L2" Then
            TraerSigNivel = "L3"
        ElseIf NivelActual = "L3" Then
            TraerSigNivel = "L4"
        ElseIf NivelActual = "L4" Then
            TraerSigNivel = "L5"
        ElseIf NivelActual = "L5" Then
            TraerSigNivel = "L6"
        ElseIf NivelActual = "L6" Then
            TraerSigNivel = "MARCA"
        ElseIf NivelActual = "MARCA" Then
            TraerSigNivel = "MODELO"
        ElseIf NivelActual = "MODELO" Then
            TraerSigNivel = ""
        Else
            TraerSigNivel = ""
        End If
    End Function

    Private Sub TraerTexto()
        lbl_Texto.Text = ""
        lbl_TextoFecha.Text = ""
        lbl_Texto.Text = "NIVEL: " & NivelAct
        lbl_TextoFecha.Text = lbl_TextoFecha.Text & "P. ACTUAL: " & Format(CDate(DT.Rows(DT.Rows.Count - 1).Item("fecini").ToString.Trim), "dd/MM/yyyy") & " - " & Format(CDate(DT.Rows(DT.Rows.Count - 1).Item("fecfin").ToString.Trim), "dd/MM/yyyy")
        If chk_DiaMes.Checked Or chk_DiaSemana.Checked Then
            If chk_DiaMes.Checked Then
                lbl_TextoFecha.Text = lbl_TextoFecha.Text & ", P. ANTERIOR MISMO DÍA MES"
            End If
            If chk_DiaSemana.Checked Then
                lbl_TextoFecha.Text = lbl_TextoFecha.Text & ", P. ANTERIOR MISMO DIA SEMANA"
            End If
        End If
        If DT.Rows(DT.Rows.Count - 1).Item("idplaza").ToString.Trim <> 0 Then
            lbl_TextoFecha.Text = lbl_TextoFecha.Text & vbCrLf & "" & DT.Rows(DT.Rows.Count - 1).Item("plaza").ToString.Trim
        Else
            lbl_TextoFecha.Text = lbl_TextoFecha.Text & vbCrLf & "TODAS LAS PLAZAS"
        End If
        If DT.Rows(DT.Rows.Count - 1).Item("idsucursal").ToString.Trim <> 0 Then
            lbl_TextoFecha.Text = lbl_TextoFecha.Text & ", " & DT.Rows(DT.Rows.Count - 1).Item("sucursal").ToString.Trim
        Else
            lbl_TextoFecha.Text = lbl_TextoFecha.Text & ", TODAS LAS SUCURSALES"
        End If
        If DT.Rows(DT.Rows.Count - 1).Item("iddivision").ToString.Trim <> 0 Then
            lbl_Texto.Text = lbl_Texto.Text & ", " & DT.Rows(DT.Rows.Count - 1).Item("division").ToString.Trim
        End If
        If DT.Rows(DT.Rows.Count - 1).Item("iddepto").ToString.Trim <> 0 Then
            lbl_Texto.Text = lbl_Texto.Text & ", " & DT.Rows(DT.Rows.Count - 1).Item("depto").ToString.Trim
        End If
        If DT.Rows(DT.Rows.Count - 1).Item("idfamilia").ToString.Trim <> 0 Then
            lbl_Texto.Text = lbl_Texto.Text & ", " & DT.Rows(DT.Rows.Count - 1).Item("familia").ToString.Trim
        End If
        If DT.Rows(DT.Rows.Count - 1).Item("idlinea").ToString.Trim <> 0 Then
            lbl_Texto.Text = lbl_Texto.Text & ", " & DT.Rows(DT.Rows.Count - 1).Item("linea").ToString.Trim
        End If
        If DT.Rows(DT.Rows.Count - 1).Item("idl1").ToString.Trim <> 0 Then
            lbl_Texto.Text = lbl_Texto.Text & ", " & DT.Rows(DT.Rows.Count - 1).Item("l1").ToString.Trim
        End If
        If DT.Rows(DT.Rows.Count - 1).Item("idl2").ToString.Trim <> 0 Then
            lbl_Texto.Text = lbl_Texto.Text & vbCrLf & ", " & DT.Rows(DT.Rows.Count - 1).Item("l2").ToString.Trim
        End If
        If DT.Rows(DT.Rows.Count - 1).Item("idl3").ToString.Trim <> 0 Then
            lbl_Texto.Text = lbl_Texto.Text & ", " & DT.Rows(DT.Rows.Count - 1).Item("l3").ToString.Trim
        End If
        If DT.Rows(DT.Rows.Count - 1).Item("idl4").ToString.Trim <> 0 Then
            lbl_Texto.Text = lbl_Texto.Text & ", " & DT.Rows(DT.Rows.Count - 1).Item("l4").ToString.Trim
        End If
        If DT.Rows(DT.Rows.Count - 1).Item("idl5").ToString.Trim <> 0 Then
            lbl_Texto.Text = lbl_Texto.Text & ", " & DT.Rows(DT.Rows.Count - 1).Item("l5").ToString.Trim
        End If
        If DT.Rows(DT.Rows.Count - 1).Item("idl6").ToString.Trim <> 0 Then
            lbl_Texto.Text = lbl_Texto.Text & ", " & DT.Rows(DT.Rows.Count - 1).Item("l6").ToString.Trim
        End If
        If DT.Rows(DT.Rows.Count - 1).Item("marca").ToString.Trim <> "" Then
            lbl_Texto.Text = lbl_Texto.Text & ", " & DT.Rows(DT.Rows.Count - 1).Item("marca").ToString.Trim
        End If
        If DT.Rows(DT.Rows.Count - 1).Item("modelo").ToString.Trim <> "" Then
            lbl_Texto.Text = lbl_Texto.Text & ", " & DT.Rows(DT.Rows.Count - 1).Item("modelo").ToString
        End If
        If DT.Rows(DT.Rows.Count - 1).Item("idagrupacion").ToString.Trim <> 0 Then
            lbl_Texto.Text = lbl_Texto.Text & ", Agrupación:" & DT.Rows(DT.Rows.Count - 1).Item("agrupacion").ToString.Trim
        End If
    End Sub

    Private Sub InicializaGrid()
        TraerTexto()
        Dim blnVisible As Boolean
        If Not (chk_DiaMes.Checked = True Or chk_DiaSemana.Checked = True) Then
            blnVisible = False
        Else
            blnVisible = True
        End If

        gc_CtdNeta.Visible = False
        gc_PorcPart.Visible = False
        gc_Existencia.Visible = False
        gc_CtdNormal.Visible = False
        gc_CtdDescto.Visible = False
        gc_CtdRegalo.Visible = False
        gc_PorcNormal.Visible = False
        gc_PorcDescto.Visible = False
        gc_PorcRegalo.Visible = False
        gc_ImpDescto.Visible = False
        gc_PorcImpNormal.Visible = False
        gc_PorcImpDescto.Visible = False
        'gc_ImpReg.Visible = False
        'gc_PorcImpReg.Visible = False
        gc_PorcImpPart.Visible = False
        gc_ImpNormal.Visible = False
        ImpReg.Visible = False


        gc_CtdNetaAnt.Visible = blnVisible
        gc_CtdNormalAnt.Visible = blnVisible
        gc_CtdDesctoAnt.Visible = blnVisible
        gc_CtdRegaloAnt.Visible = blnVisible
        gc_PorcNormalAnt.Visible = blnVisible
        gc_PorcDesctoAnt.Visible = blnVisible
        gc_PorcRegAnt.Visible = blnVisible
        gc_PorcPartAnt.Visible = blnVisible
        gc_ImpNormalAnt.Visible = blnVisible
        gc_ImpDesctoAnt.Visible = blnVisible
        gc_ImpRegAnt.Visible = blnVisible
        gc_PorcImpNormalAnt.Visible = blnVisible
        gc_PorcImpDesctoAnt.Visible = blnVisible
        gc_PorcImpRegAnt.Visible = blnVisible
        gc_CostoAnt.Visible = blnVisible
        gc_VentaAnt.Visible = blnVisible
        gc_PorcImpPartAnt.Visible = blnVisible
        gc_MargenAnt.Visible = blnVisible
        gc_PorcMargenAnt.Visible = blnVisible
        gc_PorcPares.Visible = blnVisible
        gc_PorcImporte.Visible = blnVisible

        If chk_Miles.Checked Then

            gc_ImpDescto.Caption = "$ Vta Descto (En Miles)"
            ImpReg.Caption = "$ Vta Regalo (En Miles)"
            gc_Costo.Caption = "Costo (En Miles)"
            gc_Venta.Caption = "$ Venta (En Miles)"
            gc_Margen.Caption = "$ Margen (En Miles)"
            gc_ImpNormalAnt.Caption = "$ Vta Normal Ant (En Miles)"
            gc_ImpDesctoAnt.Caption = "$ Vta Descto Ant (En Miles)"
            gc_ImpRegAnt.Caption = "$ Vta Regalo Ant (En Miles)"
            gc_CostoAnt.Caption = "Costo Ant (En Miles)"
            gc_VentaAnt.Caption = "$ Venta Ant (En Miles)"
            gc_MargenAnt.Caption = "$ Margen Ant (En Miles)"
        Else

            gc_ImpDescto.Caption = "$ Vta Descto"
            ImpReg.Caption = "$ Vta Regalo"
            gc_Costo.Caption = "Costo"
            gc_Venta.Caption = "$ Venta"
            gc_Margen.Caption = "$ Margen"
            gc_ImpNormalAnt.Caption = "$ Vta Normal Ant"
            gc_ImpDesctoAnt.Caption = "$ Vta Descto Ant"
            gc_ImpRegAnt.Caption = "$ Vta Regalo Ant"
            gc_CostoAnt.Caption = "Costo Ant"
            gc_VentaAnt.Caption = "$ Venta Ant"
            gc_MargenAnt.Caption = "$ Margen Ant"
        End If
        Dim IndexExtra
        If NivelAct = "Modelo" Then
            IndexExtra = 2
        Else
            IndexExtra = 0
        End If

        If blnVisible = True Then
            gc_CtdNetaAnt.VisibleIndex = 23 + IndexExtra
            gc_PorcPartAnt.VisibleIndex = 24 + IndexExtra
            gc_CtdNormalAnt.VisibleIndex = 25 + IndexExtra
            gc_CtdDesctoAnt.VisibleIndex = 26 + IndexExtra
            gc_CtdRegaloAnt.VisibleIndex = 27 + IndexExtra
            gc_PorcNormalAnt.VisibleIndex = 28 + IndexExtra
            gc_PorcDesctoAnt.VisibleIndex = 29 + IndexExtra
            gc_PorcRegAnt.VisibleIndex = 30 + IndexExtra
            gc_CostoAnt.VisibleIndex = 31 + IndexExtra
            gc_VentaAnt.VisibleIndex = 32 + IndexExtra
            gc_MargenAnt.VisibleIndex = 33 + IndexExtra
            gc_PorcMargenAnt.VisibleIndex = 34 + IndexExtra
            gc_PorcImpPartAnt.VisibleIndex = 35 + IndexExtra
            gc_ImpNormalAnt.VisibleIndex = 36 + IndexExtra
            gc_ImpDesctoAnt.VisibleIndex = 37 + IndexExtra
            gc_ImpRegAnt.VisibleIndex = 38 + IndexExtra
            gc_PorcImpNormalAnt.VisibleIndex = 39 + IndexExtra
            gc_PorcImpDesctoAnt.VisibleIndex = 40 + IndexExtra
            gc_PorcImpRegAnt.VisibleIndex = 41 + IndexExtra
            gc_PorcPares.VisibleIndex = 42 + IndexExtra
            gc_PorcImporte.VisibleIndex = 43 + IndexExtra
        End If

        gc_IdEstructura.Visible = False
        gc_Estilo.Visible = False
        gc_DescripArt.Visible = False
        dgv_Reporte.OptionsView.ShowAutoFilterRow = False
        If NivelAct = "DIVISION" Then
            gc_Estructura.Caption = "División"
        ElseIf NivelAct = "DEPTO" Then
            gc_Estructura.Caption = "Departamento"
        ElseIf NivelAct = "FAMILIA" Then
            gc_Estructura.Caption = "Familia"
        ElseIf NivelAct = "LINEA" Then
            gc_Estructura.Caption = "Linea"
        ElseIf NivelAct = "L1" Then
            gc_Estructura.Caption = "L1"
        ElseIf NivelAct = "L2" Then
            gc_Estructura.Caption = "L2"
        ElseIf NivelAct = "L3" Then
            gc_Estructura.Caption = "L3"
        ElseIf NivelAct = "L4" Then
            gc_Estructura.Caption = "L4"
        ElseIf NivelAct = "L5" Then
            gc_Estructura.Caption = "L5"
        ElseIf NivelAct = "L6" Then
            gc_Estructura.Caption = "L4"
        ElseIf NivelAct = "MARCA" Then
            gc_IdEstructura.Visible = True
            gc_IdEstructura.Caption = "Marca"
            gc_Estructura.Caption = "Nom Marca"
        ElseIf NivelAct = "MODELO" Then
            dgv_Reporte.OptionsView.ShowAutoFilterRow = True
            gc_IdEstructura.Caption = "Marca"
            gc_Estructura.Caption = "Modelo"
            gc_DescripArt.Visible = True
            gc_Estilo.Visible = True
            gc_IdEstructura.Visible = True
        ElseIf NivelAct = "PLAZA" Then
            gc_Estructura.Caption = "Plaza"
        ElseIf NivelAct = "SUCURSAL" Then
            gc_Estructura.Caption = "Sucursal"
        End If
    End Sub

    Private Sub TraerNivelClickDerecho(NivelAnt As String, NivelNvo As String, IdEstructura As String, Estructura As String)
        Try
            Dim IdPlaza As String
            Dim Plaza As String
            Dim IdSucursal As String
            Dim Sucursal As String
            Dim IdDiv As String
            Dim Div As String
            Dim IdDep As String
            Dim Dep As String
            Dim IdFam As String
            Dim Fam As String
            Dim IdLin As String
            Dim Lin As String
            Dim IdLi1 As String
            Dim Li1 As String
            Dim IdLi2 As String
            Dim Li2 As String
            Dim IdLi3 As String
            Dim Li3 As String
            Dim IdLi4 As String
            Dim Li4 As String
            Dim IdLi5 As String
            Dim Li5 As String
            Dim IdLi6 As String
            Dim Li6 As String
            Dim Mar As String
            Dim Mode As String
            If Estructura = "TOTAL" Then Estructura = ""
            If NivelAnt = "PLAZA" Then
                IdPlaza = IdEstructura
                Plaza = Estructura
                IdSucursal = DT.Rows(DT.Rows.Count - 1).Item("idsucursal").ToString.Trim
                Sucursal = DT.Rows(DT.Rows.Count - 1).Item("sucursal").ToString.Trim
                IdDiv = DT.Rows(DT.Rows.Count - 1).Item("iddivision").ToString.Trim
                Div = DT.Rows(DT.Rows.Count - 1).Item("division").ToString.Trim
                IdDep = DT.Rows(DT.Rows.Count - 1).Item("iddepto").ToString.Trim
                Dep = DT.Rows(DT.Rows.Count - 1).Item("depto").ToString.Trim
                IdFam = DT.Rows(DT.Rows.Count - 1).Item("idfamilia").ToString.Trim
                Fam = DT.Rows(DT.Rows.Count - 1).Item("familia").ToString.Trim
                IdLin = DT.Rows(DT.Rows.Count - 1).Item("idlinea").ToString.Trim
                Lin = DT.Rows(DT.Rows.Count - 1).Item("linea").ToString.Trim
                IdLi1 = DT.Rows(DT.Rows.Count - 1).Item("idl1").ToString.Trim
                Li1 = DT.Rows(DT.Rows.Count - 1).Item("l1").ToString.Trim
                IdLi2 = DT.Rows(DT.Rows.Count - 1).Item("idl2").ToString.Trim
                Li2 = DT.Rows(DT.Rows.Count - 1).Item("l2").ToString.Trim
                IdLi3 = DT.Rows(DT.Rows.Count - 1).Item("idl3").ToString.Trim
                Li3 = DT.Rows(DT.Rows.Count - 1).Item("l3").ToString.Trim
                IdLi4 = DT.Rows(DT.Rows.Count - 1).Item("idl4").ToString.Trim
                Li4 = DT.Rows(DT.Rows.Count - 1).Item("l4").ToString.Trim
                IdLi5 = DT.Rows(DT.Rows.Count - 1).Item("idl5").ToString.Trim
                Li5 = DT.Rows(DT.Rows.Count - 1).Item("l5").ToString.Trim
                IdLi6 = DT.Rows(DT.Rows.Count - 1).Item("idl6").ToString.Trim
                Li6 = DT.Rows(DT.Rows.Count - 1).Item("l6").ToString.Trim
                Mar = DT.Rows(DT.Rows.Count - 1).Item("marca").ToString.Trim
                Mode = DT.Rows(DT.Rows.Count - 1).Item("modelo").ToString.Trim
            ElseIf NivelAnt = "SUCURSAL" Then
                IdPlaza = DT.Rows(DT.Rows.Count - 1).Item("idplaza").ToString.Trim
                Plaza = DT.Rows(DT.Rows.Count - 1).Item("plaza").ToString.Trim
                IdSucursal = IdEstructura
                Sucursal = Estructura
                IdDiv = DT.Rows(DT.Rows.Count - 1).Item("iddivision").ToString.Trim
                Div = DT.Rows(DT.Rows.Count - 1).Item("division").ToString.Trim
                IdDep = DT.Rows(DT.Rows.Count - 1).Item("iddepto").ToString.Trim
                Dep = DT.Rows(DT.Rows.Count - 1).Item("depto").ToString.Trim
                IdFam = DT.Rows(DT.Rows.Count - 1).Item("idfamilia").ToString.Trim
                Fam = DT.Rows(DT.Rows.Count - 1).Item("familia").ToString.Trim
                IdLin = DT.Rows(DT.Rows.Count - 1).Item("idlinea").ToString.Trim
                Lin = DT.Rows(DT.Rows.Count - 1).Item("linea").ToString.Trim
                IdLi1 = DT.Rows(DT.Rows.Count - 1).Item("idl1").ToString.Trim
                Li1 = DT.Rows(DT.Rows.Count - 1).Item("l1").ToString.Trim
                IdLi2 = DT.Rows(DT.Rows.Count - 1).Item("idl2").ToString.Trim
                Li2 = DT.Rows(DT.Rows.Count - 1).Item("l2").ToString.Trim
                IdLi3 = DT.Rows(DT.Rows.Count - 1).Item("idl3").ToString.Trim
                Li3 = DT.Rows(DT.Rows.Count - 1).Item("l3").ToString.Trim
                IdLi4 = DT.Rows(DT.Rows.Count - 1).Item("idl4").ToString.Trim
                Li4 = DT.Rows(DT.Rows.Count - 1).Item("l4").ToString.Trim
                IdLi5 = DT.Rows(DT.Rows.Count - 1).Item("idl5").ToString.Trim
                Li5 = DT.Rows(DT.Rows.Count - 1).Item("l5").ToString.Trim
                IdLi6 = DT.Rows(DT.Rows.Count - 1).Item("idl6").ToString.Trim
                Li6 = DT.Rows(DT.Rows.Count - 1).Item("l6").ToString.Trim
                Mar = DT.Rows(DT.Rows.Count - 1).Item("marca").ToString.Trim
                Mode = DT.Rows(DT.Rows.Count - 1).Item("modelo").ToString.Trim
            ElseIf NivelAnt = "DIVISION" Then
                IdPlaza = DT.Rows(DT.Rows.Count - 1).Item("idplaza").ToString.Trim
                Plaza = DT.Rows(DT.Rows.Count - 1).Item("plaza").ToString.Trim
                IdSucursal = DT.Rows(DT.Rows.Count - 1).Item("idsucursal").ToString.Trim
                Sucursal = DT.Rows(DT.Rows.Count - 1).Item("sucursal").ToString.Trim
                IdDiv = IdEstructura
                Div = Estructura
                IdDep = DT.Rows(DT.Rows.Count - 1).Item("iddepto").ToString.Trim
                Dep = DT.Rows(DT.Rows.Count - 1).Item("depto").ToString.Trim
                IdFam = DT.Rows(DT.Rows.Count - 1).Item("idfamilia").ToString.Trim
                Fam = DT.Rows(DT.Rows.Count - 1).Item("familia").ToString.Trim
                IdLin = DT.Rows(DT.Rows.Count - 1).Item("idlinea").ToString.Trim
                Lin = DT.Rows(DT.Rows.Count - 1).Item("linea").ToString.Trim
                IdLi1 = DT.Rows(DT.Rows.Count - 1).Item("idl1").ToString.Trim
                Li1 = DT.Rows(DT.Rows.Count - 1).Item("l1").ToString.Trim
                IdLi2 = DT.Rows(DT.Rows.Count - 1).Item("idl2").ToString.Trim
                Li2 = DT.Rows(DT.Rows.Count - 1).Item("l2").ToString.Trim
                IdLi3 = DT.Rows(DT.Rows.Count - 1).Item("idl3").ToString.Trim
                Li3 = DT.Rows(DT.Rows.Count - 1).Item("l3").ToString.Trim
                IdLi4 = DT.Rows(DT.Rows.Count - 1).Item("idl4").ToString.Trim
                Li4 = DT.Rows(DT.Rows.Count - 1).Item("l4").ToString.Trim
                IdLi5 = DT.Rows(DT.Rows.Count - 1).Item("idl5").ToString.Trim
                Li5 = DT.Rows(DT.Rows.Count - 1).Item("l5").ToString.Trim
                IdLi6 = DT.Rows(DT.Rows.Count - 1).Item("idl6").ToString.Trim
                Li6 = DT.Rows(DT.Rows.Count - 1).Item("l6").ToString.Trim
                Mar = DT.Rows(DT.Rows.Count - 1).Item("marca").ToString.Trim
                Mode = DT.Rows(DT.Rows.Count - 1).Item("modelo").ToString.Trim
            ElseIf NivelAnt = "DEPTO" Then
                IdPlaza = DT.Rows(DT.Rows.Count - 1).Item("idplaza").ToString.Trim
                Plaza = DT.Rows(DT.Rows.Count - 1).Item("plaza").ToString.Trim
                IdSucursal = DT.Rows(DT.Rows.Count - 1).Item("idsucursal").ToString.Trim
                Sucursal = DT.Rows(DT.Rows.Count - 1).Item("sucursal").ToString.Trim
                IdDiv = DT.Rows(DT.Rows.Count - 1).Item("iddivision").ToString.Trim
                Div = DT.Rows(DT.Rows.Count - 1).Item("division").ToString.Trim
                IdDep = IdEstructura
                Dep = Estructura
                IdFam = DT.Rows(DT.Rows.Count - 1).Item("idfamilia").ToString.Trim
                Fam = DT.Rows(DT.Rows.Count - 1).Item("familia").ToString.Trim
                IdLin = DT.Rows(DT.Rows.Count - 1).Item("idlinea").ToString.Trim
                Lin = DT.Rows(DT.Rows.Count - 1).Item("linea").ToString.Trim
                IdLi1 = DT.Rows(DT.Rows.Count - 1).Item("idl1").ToString.Trim
                Li1 = DT.Rows(DT.Rows.Count - 1).Item("l1").ToString.Trim
                IdLi2 = DT.Rows(DT.Rows.Count - 1).Item("idl2").ToString.Trim
                Li2 = DT.Rows(DT.Rows.Count - 1).Item("l2").ToString.Trim
                IdLi3 = DT.Rows(DT.Rows.Count - 1).Item("idl3").ToString.Trim
                Li3 = DT.Rows(DT.Rows.Count - 1).Item("l3").ToString.Trim
                IdLi4 = DT.Rows(DT.Rows.Count - 1).Item("idl4").ToString.Trim
                Li4 = DT.Rows(DT.Rows.Count - 1).Item("l4").ToString.Trim
                IdLi5 = DT.Rows(DT.Rows.Count - 1).Item("idl5").ToString.Trim
                Li5 = DT.Rows(DT.Rows.Count - 1).Item("l5").ToString.Trim
                IdLi6 = DT.Rows(DT.Rows.Count - 1).Item("idl6").ToString.Trim
                Li6 = DT.Rows(DT.Rows.Count - 1).Item("l6").ToString.Trim
                Mar = DT.Rows(DT.Rows.Count - 1).Item("marca").ToString.Trim
                Mode = DT.Rows(DT.Rows.Count - 1).Item("modelo").ToString.Trim
            ElseIf NivelAnt = "FAMILIA" Then
                IdPlaza = DT.Rows(DT.Rows.Count - 1).Item("idplaza").ToString.Trim
                Plaza = DT.Rows(DT.Rows.Count - 1).Item("plaza").ToString.Trim
                IdSucursal = DT.Rows(DT.Rows.Count - 1).Item("idsucursal").ToString.Trim
                Sucursal = DT.Rows(DT.Rows.Count - 1).Item("sucursal").ToString.Trim
                IdDiv = DT.Rows(DT.Rows.Count - 1).Item("iddivision").ToString.Trim
                Div = DT.Rows(DT.Rows.Count - 1).Item("division").ToString.Trim
                IdDep = DT.Rows(DT.Rows.Count - 1).Item("iddepto").ToString.Trim
                Dep = DT.Rows(DT.Rows.Count - 1).Item("depto").ToString.Trim
                IdFam = IdEstructura
                Fam = Estructura
                IdLin = DT.Rows(DT.Rows.Count - 1).Item("idlinea").ToString.Trim
                Lin = DT.Rows(DT.Rows.Count - 1).Item("linea").ToString.Trim
                IdLi1 = DT.Rows(DT.Rows.Count - 1).Item("idl1").ToString.Trim
                Li1 = DT.Rows(DT.Rows.Count - 1).Item("l1").ToString.Trim
                IdLi2 = DT.Rows(DT.Rows.Count - 1).Item("idl2").ToString.Trim
                Li2 = DT.Rows(DT.Rows.Count - 1).Item("l2").ToString.Trim
                IdLi3 = DT.Rows(DT.Rows.Count - 1).Item("idl3").ToString.Trim
                Li3 = DT.Rows(DT.Rows.Count - 1).Item("l3").ToString.Trim
                IdLi4 = DT.Rows(DT.Rows.Count - 1).Item("idl4").ToString.Trim
                Li4 = DT.Rows(DT.Rows.Count - 1).Item("l4").ToString.Trim
                IdLi5 = DT.Rows(DT.Rows.Count - 1).Item("idl5").ToString.Trim
                Li5 = DT.Rows(DT.Rows.Count - 1).Item("l5").ToString.Trim
                IdLi6 = DT.Rows(DT.Rows.Count - 1).Item("idl6").ToString.Trim
                Li6 = DT.Rows(DT.Rows.Count - 1).Item("l6").ToString.Trim
                Mar = DT.Rows(DT.Rows.Count - 1).Item("marca").ToString.Trim
                Mode = DT.Rows(DT.Rows.Count - 1).Item("modelo").ToString.Trim
            ElseIf NivelAnt = "LINEA" Then
                IdPlaza = DT.Rows(DT.Rows.Count - 1).Item("idplaza").ToString.Trim
                Plaza = DT.Rows(DT.Rows.Count - 1).Item("plaza").ToString.Trim
                IdSucursal = DT.Rows(DT.Rows.Count - 1).Item("idsucursal").ToString.Trim
                Sucursal = DT.Rows(DT.Rows.Count - 1).Item("sucursal").ToString.Trim
                IdDiv = DT.Rows(DT.Rows.Count - 1).Item("iddivision").ToString.Trim
                Div = DT.Rows(DT.Rows.Count - 1).Item("division").ToString.Trim
                IdDep = DT.Rows(DT.Rows.Count - 1).Item("iddepto").ToString.Trim
                Dep = DT.Rows(DT.Rows.Count - 1).Item("depto").ToString.Trim
                IdFam = DT.Rows(DT.Rows.Count - 1).Item("idfamilia").ToString.Trim
                Fam = DT.Rows(DT.Rows.Count - 1).Item("familia").ToString.Trim
                IdLin = IdEstructura
                Lin = Estructura
                IdLi1 = DT.Rows(DT.Rows.Count - 1).Item("idl1").ToString.Trim
                Li1 = DT.Rows(DT.Rows.Count - 1).Item("l1").ToString.Trim
                IdLi2 = DT.Rows(DT.Rows.Count - 1).Item("idl2").ToString.Trim
                Li2 = DT.Rows(DT.Rows.Count - 1).Item("l2").ToString.Trim
                IdLi3 = DT.Rows(DT.Rows.Count - 1).Item("idl3").ToString.Trim
                Li3 = DT.Rows(DT.Rows.Count - 1).Item("l3").ToString.Trim
                IdLi4 = DT.Rows(DT.Rows.Count - 1).Item("idl4").ToString.Trim
                Li4 = DT.Rows(DT.Rows.Count - 1).Item("l4").ToString.Trim
                IdLi5 = DT.Rows(DT.Rows.Count - 1).Item("idl5").ToString.Trim
                Li5 = DT.Rows(DT.Rows.Count - 1).Item("l5").ToString.Trim
                IdLi6 = DT.Rows(DT.Rows.Count - 1).Item("idl6").ToString.Trim
                Li6 = DT.Rows(DT.Rows.Count - 1).Item("l6").ToString.Trim
                Mar = DT.Rows(DT.Rows.Count - 1).Item("marca").ToString.Trim
                Mode = DT.Rows(DT.Rows.Count - 1).Item("modelo").ToString.Trim
            ElseIf NivelAnt = "L1" Then
                IdPlaza = DT.Rows(DT.Rows.Count - 1).Item("idplaza").ToString.Trim
                Plaza = DT.Rows(DT.Rows.Count - 1).Item("plaza").ToString.Trim
                IdSucursal = DT.Rows(DT.Rows.Count - 1).Item("idsucursal").ToString.Trim
                Sucursal = DT.Rows(DT.Rows.Count - 1).Item("sucursal").ToString.Trim
                IdDiv = DT.Rows(DT.Rows.Count - 1).Item("iddivision").ToString.Trim
                Div = DT.Rows(DT.Rows.Count - 1).Item("division").ToString.Trim
                IdDep = DT.Rows(DT.Rows.Count - 1).Item("iddepto").ToString.Trim
                Dep = DT.Rows(DT.Rows.Count - 1).Item("depto").ToString.Trim
                IdFam = DT.Rows(DT.Rows.Count - 1).Item("idfamilia").ToString.Trim
                Fam = DT.Rows(DT.Rows.Count - 1).Item("familia").ToString.Trim
                IdLin = DT.Rows(DT.Rows.Count - 1).Item("idlinea").ToString.Trim
                Lin = DT.Rows(DT.Rows.Count - 1).Item("linea").ToString.Trim
                IdLi1 = IdEstructura
                Li1 = Estructura
                IdLi2 = DT.Rows(DT.Rows.Count - 1).Item("idl2").ToString.Trim
                Li2 = DT.Rows(DT.Rows.Count - 1).Item("l2").ToString.Trim
                IdLi3 = DT.Rows(DT.Rows.Count - 1).Item("idl3").ToString.Trim
                Li3 = DT.Rows(DT.Rows.Count - 1).Item("l3").ToString.Trim
                IdLi4 = DT.Rows(DT.Rows.Count - 1).Item("idl4").ToString.Trim
                Li4 = DT.Rows(DT.Rows.Count - 1).Item("l4").ToString.Trim
                IdLi5 = DT.Rows(DT.Rows.Count - 1).Item("idl5").ToString.Trim
                Li5 = DT.Rows(DT.Rows.Count - 1).Item("l5").ToString.Trim
                IdLi6 = DT.Rows(DT.Rows.Count - 1).Item("idl6").ToString.Trim
                Li6 = DT.Rows(DT.Rows.Count - 1).Item("l6").ToString.Trim
                Mar = DT.Rows(DT.Rows.Count - 1).Item("marca").ToString.Trim
                Mode = DT.Rows(DT.Rows.Count - 1).Item("modelo").ToString.Trim
            ElseIf NivelAnt = "L2" Then
                IdPlaza = DT.Rows(DT.Rows.Count - 1).Item("idplaza").ToString.Trim
                Plaza = DT.Rows(DT.Rows.Count - 1).Item("plaza").ToString.Trim
                IdSucursal = DT.Rows(DT.Rows.Count - 1).Item("idsucursal").ToString.Trim
                Sucursal = DT.Rows(DT.Rows.Count - 1).Item("sucursal").ToString.Trim
                IdDiv = DT.Rows(DT.Rows.Count - 1).Item("iddivision").ToString.Trim
                Div = DT.Rows(DT.Rows.Count - 1).Item("division").ToString.Trim
                IdDep = DT.Rows(DT.Rows.Count - 1).Item("iddepto").ToString.Trim
                Dep = DT.Rows(DT.Rows.Count - 1).Item("depto").ToString.Trim
                IdFam = DT.Rows(DT.Rows.Count - 1).Item("idfamilia").ToString.Trim
                Fam = DT.Rows(DT.Rows.Count - 1).Item("familia").ToString.Trim
                IdLin = DT.Rows(DT.Rows.Count - 1).Item("idlinea").ToString.Trim
                Lin = DT.Rows(DT.Rows.Count - 1).Item("linea").ToString.Trim
                IdLi1 = DT.Rows(DT.Rows.Count - 1).Item("idl1").ToString.Trim
                Li1 = DT.Rows(DT.Rows.Count - 1).Item("l1").ToString.Trim
                IdLi2 = IdEstructura
                Li2 = Estructura
                IdLi3 = DT.Rows(DT.Rows.Count - 1).Item("idl3").ToString.Trim
                Li3 = DT.Rows(DT.Rows.Count - 1).Item("l3").ToString.Trim
                IdLi4 = DT.Rows(DT.Rows.Count - 1).Item("idl4").ToString.Trim
                Li4 = DT.Rows(DT.Rows.Count - 1).Item("l4").ToString.Trim
                IdLi5 = DT.Rows(DT.Rows.Count - 1).Item("idl5").ToString.Trim
                Li5 = DT.Rows(DT.Rows.Count - 1).Item("l5").ToString.Trim
                IdLi6 = DT.Rows(DT.Rows.Count - 1).Item("idl6").ToString.Trim
                Li6 = DT.Rows(DT.Rows.Count - 1).Item("l6").ToString.Trim
                Mar = DT.Rows(DT.Rows.Count - 1).Item("marca").ToString.Trim
                Mode = DT.Rows(DT.Rows.Count - 1).Item("modelo").ToString.Trim
            ElseIf NivelAnt = "L3" Then
                IdPlaza = DT.Rows(DT.Rows.Count - 1).Item("idplaza").ToString.Trim
                Plaza = DT.Rows(DT.Rows.Count - 1).Item("plaza").ToString.Trim
                IdSucursal = DT.Rows(DT.Rows.Count - 1).Item("idsucursal").ToString.Trim
                Sucursal = DT.Rows(DT.Rows.Count - 1).Item("sucursal").ToString.Trim
                IdDiv = DT.Rows(DT.Rows.Count - 1).Item("iddivision").ToString.Trim
                Div = DT.Rows(DT.Rows.Count - 1).Item("division").ToString.Trim
                IdDep = DT.Rows(DT.Rows.Count - 1).Item("iddepto").ToString.Trim
                Dep = DT.Rows(DT.Rows.Count - 1).Item("depto").ToString.Trim
                IdFam = DT.Rows(DT.Rows.Count - 1).Item("idfamilia").ToString.Trim
                Fam = DT.Rows(DT.Rows.Count - 1).Item("familia").ToString.Trim
                IdLin = DT.Rows(DT.Rows.Count - 1).Item("idlinea").ToString.Trim
                Lin = DT.Rows(DT.Rows.Count - 1).Item("linea").ToString.Trim
                IdLi1 = DT.Rows(DT.Rows.Count - 1).Item("idl1").ToString.Trim
                Li1 = DT.Rows(DT.Rows.Count - 1).Item("l1").ToString.Trim
                IdLi2 = DT.Rows(DT.Rows.Count - 1).Item("idl2").ToString.Trim
                Li2 = DT.Rows(DT.Rows.Count - 1).Item("l2").ToString.Trim
                IdLi3 = IdEstructura
                Li3 = Estructura
                IdLi4 = DT.Rows(DT.Rows.Count - 1).Item("idl4").ToString.Trim
                Li4 = DT.Rows(DT.Rows.Count - 1).Item("l4").ToString.Trim
                IdLi5 = DT.Rows(DT.Rows.Count - 1).Item("idl5").ToString.Trim
                Li5 = DT.Rows(DT.Rows.Count - 1).Item("l5").ToString.Trim
                IdLi6 = DT.Rows(DT.Rows.Count - 1).Item("idl6").ToString.Trim
                Li6 = DT.Rows(DT.Rows.Count - 1).Item("l6").ToString.Trim
                Mar = DT.Rows(DT.Rows.Count - 1).Item("marca").ToString.Trim
                Mode = DT.Rows(DT.Rows.Count - 1).Item("modelo").ToString.Trim
            ElseIf NivelAnt = "L4" Then
                IdPlaza = DT.Rows(DT.Rows.Count - 1).Item("idplaza").ToString.Trim
                Plaza = DT.Rows(DT.Rows.Count - 1).Item("plaza").ToString.Trim
                IdSucursal = DT.Rows(DT.Rows.Count - 1).Item("idsucursal").ToString.Trim
                Sucursal = DT.Rows(DT.Rows.Count - 1).Item("sucursal").ToString.Trim
                IdDiv = DT.Rows(DT.Rows.Count - 1).Item("iddivision").ToString.Trim
                Div = DT.Rows(DT.Rows.Count - 1).Item("division").ToString.Trim
                IdDep = DT.Rows(DT.Rows.Count - 1).Item("iddepto").ToString.Trim
                Dep = DT.Rows(DT.Rows.Count - 1).Item("depto").ToString.Trim
                IdFam = DT.Rows(DT.Rows.Count - 1).Item("idfamilia").ToString.Trim
                Fam = DT.Rows(DT.Rows.Count - 1).Item("familia").ToString.Trim
                IdLin = DT.Rows(DT.Rows.Count - 1).Item("idlinea").ToString.Trim
                Lin = DT.Rows(DT.Rows.Count - 1).Item("linea").ToString.Trim
                IdLi1 = DT.Rows(DT.Rows.Count - 1).Item("idl1").ToString.Trim
                Li1 = DT.Rows(DT.Rows.Count - 1).Item("l1").ToString.Trim
                IdLi2 = DT.Rows(DT.Rows.Count - 1).Item("idl2").ToString.Trim
                Li2 = DT.Rows(DT.Rows.Count - 1).Item("l2").ToString.Trim
                IdLi3 = DT.Rows(DT.Rows.Count - 1).Item("idl3").ToString.Trim
                Li3 = DT.Rows(DT.Rows.Count - 1).Item("l3").ToString.Trim
                IdLi4 = IdEstructura
                Li4 = Estructura
                IdLi5 = DT.Rows(DT.Rows.Count - 1).Item("idl5").ToString.Trim
                Li5 = DT.Rows(DT.Rows.Count - 1).Item("l5").ToString.Trim
                IdLi6 = DT.Rows(DT.Rows.Count - 1).Item("idl6").ToString.Trim
                Li6 = DT.Rows(DT.Rows.Count - 1).Item("l6").ToString.Trim
                Mar = DT.Rows(DT.Rows.Count - 1).Item("marca").ToString.Trim
                Mode = DT.Rows(DT.Rows.Count - 1).Item("modelo").ToString.Trim
            ElseIf NivelAnt = "L5" Then
                IdPlaza = DT.Rows(DT.Rows.Count - 1).Item("idplaza").ToString.Trim
                Plaza = DT.Rows(DT.Rows.Count - 1).Item("plaza").ToString.Trim
                IdSucursal = DT.Rows(DT.Rows.Count - 1).Item("idsucursal").ToString.Trim
                Sucursal = DT.Rows(DT.Rows.Count - 1).Item("sucursal").ToString.Trim
                IdDiv = DT.Rows(DT.Rows.Count - 1).Item("iddivision").ToString.Trim
                Div = DT.Rows(DT.Rows.Count - 1).Item("division").ToString.Trim
                IdDep = DT.Rows(DT.Rows.Count - 1).Item("iddepto").ToString.Trim
                Dep = DT.Rows(DT.Rows.Count - 1).Item("depto").ToString.Trim
                IdFam = DT.Rows(DT.Rows.Count - 1).Item("idfamilia").ToString.Trim
                Fam = DT.Rows(DT.Rows.Count - 1).Item("familia").ToString.Trim
                IdLin = DT.Rows(DT.Rows.Count - 1).Item("idlinea").ToString.Trim
                Lin = DT.Rows(DT.Rows.Count - 1).Item("linea").ToString.Trim
                IdLi1 = DT.Rows(DT.Rows.Count - 1).Item("idl1").ToString.Trim
                Li1 = DT.Rows(DT.Rows.Count - 1).Item("l1").ToString.Trim
                IdLi2 = DT.Rows(DT.Rows.Count - 1).Item("idl2").ToString.Trim
                Li2 = DT.Rows(DT.Rows.Count - 1).Item("l2").ToString.Trim
                IdLi3 = DT.Rows(DT.Rows.Count - 1).Item("idl3").ToString.Trim
                Li3 = DT.Rows(DT.Rows.Count - 1).Item("l3").ToString.Trim
                IdLi4 = DT.Rows(DT.Rows.Count - 1).Item("idl4").ToString.Trim
                Li4 = DT.Rows(DT.Rows.Count - 1).Item("l4").ToString.Trim
                IdLi5 = IdEstructura
                Li5 = Estructura
                IdLi6 = DT.Rows(DT.Rows.Count - 1).Item("idl6").ToString.Trim
                Li6 = DT.Rows(DT.Rows.Count - 1).Item("l6").ToString.Trim
                Mar = DT.Rows(DT.Rows.Count - 1).Item("marca").ToString.Trim
                Mode = DT.Rows(DT.Rows.Count - 1).Item("modelo").ToString.Trim
            ElseIf NivelAnt = "L6" Then
                IdPlaza = DT.Rows(DT.Rows.Count - 1).Item("idplaza").ToString.Trim
                Plaza = DT.Rows(DT.Rows.Count - 1).Item("plaza").ToString.Trim
                IdSucursal = DT.Rows(DT.Rows.Count - 1).Item("idsucursal").ToString.Trim
                Sucursal = DT.Rows(DT.Rows.Count - 1).Item("sucursal").ToString.Trim
                IdDiv = DT.Rows(DT.Rows.Count - 1).Item("iddivision").ToString.Trim
                Div = DT.Rows(DT.Rows.Count - 1).Item("division").ToString.Trim
                IdDep = DT.Rows(DT.Rows.Count - 1).Item("iddepto").ToString.Trim
                Dep = DT.Rows(DT.Rows.Count - 1).Item("depto").ToString.Trim
                IdFam = DT.Rows(DT.Rows.Count - 1).Item("idfamilia").ToString.Trim
                Fam = DT.Rows(DT.Rows.Count - 1).Item("familia").ToString.Trim
                IdLin = DT.Rows(DT.Rows.Count - 1).Item("idlinea").ToString.Trim
                Lin = DT.Rows(DT.Rows.Count - 1).Item("linea").ToString.Trim
                IdLi1 = DT.Rows(DT.Rows.Count - 1).Item("idl1").ToString.Trim
                Li1 = DT.Rows(DT.Rows.Count - 1).Item("l1").ToString.Trim
                IdLi2 = DT.Rows(DT.Rows.Count - 1).Item("idl2").ToString.Trim
                Li2 = DT.Rows(DT.Rows.Count - 1).Item("l2").ToString.Trim
                IdLi3 = DT.Rows(DT.Rows.Count - 1).Item("idl3").ToString.Trim
                Li3 = DT.Rows(DT.Rows.Count - 1).Item("l3").ToString.Trim
                IdLi4 = DT.Rows(DT.Rows.Count - 1).Item("idl4").ToString.Trim
                Li4 = DT.Rows(DT.Rows.Count - 1).Item("l4").ToString.Trim
                IdLi5 = DT.Rows(DT.Rows.Count - 1).Item("idl5").ToString.Trim
                Li5 = DT.Rows(DT.Rows.Count - 1).Item("l5").ToString.Trim
                IdLi6 = IdEstructura
                Li6 = Estructura
                Mar = DT.Rows(DT.Rows.Count - 1).Item("marca").ToString.Trim
                Mode = DT.Rows(DT.Rows.Count - 1).Item("modelo").ToString.Trim
            ElseIf NivelAnt = "MARCA" Then
                IdPlaza = DT.Rows(DT.Rows.Count - 1).Item("idplaza").ToString.Trim
                Plaza = DT.Rows(DT.Rows.Count - 1).Item("plaza").ToString.Trim
                IdSucursal = DT.Rows(DT.Rows.Count - 1).Item("idsucursal").ToString.Trim
                Sucursal = DT.Rows(DT.Rows.Count - 1).Item("sucursal").ToString.Trim
                IdDiv = DT.Rows(DT.Rows.Count - 1).Item("iddivision").ToString.Trim
                Div = DT.Rows(DT.Rows.Count - 1).Item("division").ToString.Trim
                IdDep = DT.Rows(DT.Rows.Count - 1).Item("iddepto").ToString.Trim
                Dep = DT.Rows(DT.Rows.Count - 1).Item("depto").ToString.Trim
                IdFam = DT.Rows(DT.Rows.Count - 1).Item("idfamilia").ToString.Trim
                Fam = DT.Rows(DT.Rows.Count - 1).Item("familia").ToString.Trim
                IdLin = DT.Rows(DT.Rows.Count - 1).Item("idlinea").ToString.Trim
                Lin = DT.Rows(DT.Rows.Count - 1).Item("linea").ToString.Trim
                IdLi1 = DT.Rows(DT.Rows.Count - 1).Item("idl1").ToString.Trim
                Li1 = DT.Rows(DT.Rows.Count - 1).Item("l1").ToString.Trim
                IdLi2 = DT.Rows(DT.Rows.Count - 1).Item("idl2").ToString.Trim
                Li2 = DT.Rows(DT.Rows.Count - 1).Item("l2").ToString.Trim
                IdLi3 = DT.Rows(DT.Rows.Count - 1).Item("idl3").ToString.Trim
                Li3 = DT.Rows(DT.Rows.Count - 1).Item("l3").ToString.Trim
                IdLi4 = DT.Rows(DT.Rows.Count - 1).Item("idl4").ToString.Trim
                Li4 = DT.Rows(DT.Rows.Count - 1).Item("l4").ToString.Trim
                IdLi5 = DT.Rows(DT.Rows.Count - 1).Item("idl5").ToString.Trim
                Li5 = DT.Rows(DT.Rows.Count - 1).Item("l5").ToString.Trim
                IdLi6 = DT.Rows(DT.Rows.Count - 1).Item("idl6").ToString.Trim
                Li6 = DT.Rows(DT.Rows.Count - 1).Item("l6").ToString.Trim
                Mar = IdEstructura
                Mode = DT.Rows(DT.Rows.Count - 1).Item("modelo").ToString.Trim
            ElseIf NivelAnt = "MODELO" Then
                IdPlaza = DT.Rows(DT.Rows.Count - 1).Item("idplaza").ToString.Trim
                Plaza = DT.Rows(DT.Rows.Count - 1).Item("plaza").ToString.Trim
                IdSucursal = DT.Rows(DT.Rows.Count - 1).Item("idsucursal").ToString.Trim
                Sucursal = DT.Rows(DT.Rows.Count - 1).Item("sucursal").ToString.Trim
                IdDiv = DT.Rows(DT.Rows.Count - 1).Item("iddivision").ToString.Trim
                Div = DT.Rows(DT.Rows.Count - 1).Item("division").ToString.Trim
                IdDep = DT.Rows(DT.Rows.Count - 1).Item("iddepto").ToString.Trim
                Dep = DT.Rows(DT.Rows.Count - 1).Item("depto").ToString.Trim
                IdFam = DT.Rows(DT.Rows.Count - 1).Item("idfamilia").ToString.Trim
                Fam = DT.Rows(DT.Rows.Count - 1).Item("familia").ToString.Trim
                IdLin = DT.Rows(DT.Rows.Count - 1).Item("idlinea").ToString.Trim
                Lin = DT.Rows(DT.Rows.Count - 1).Item("linea").ToString.Trim
                IdLi1 = DT.Rows(DT.Rows.Count - 1).Item("idl1").ToString.Trim
                Li1 = DT.Rows(DT.Rows.Count - 1).Item("l1").ToString.Trim
                IdLi2 = DT.Rows(DT.Rows.Count - 1).Item("idl2").ToString.Trim
                Li2 = DT.Rows(DT.Rows.Count - 1).Item("l2").ToString.Trim
                IdLi3 = DT.Rows(DT.Rows.Count - 1).Item("idl3").ToString.Trim
                Li3 = DT.Rows(DT.Rows.Count - 1).Item("l3").ToString.Trim
                IdLi4 = DT.Rows(DT.Rows.Count - 1).Item("idl4").ToString.Trim
                Li4 = DT.Rows(DT.Rows.Count - 1).Item("l4").ToString.Trim
                IdLi5 = DT.Rows(DT.Rows.Count - 1).Item("idl5").ToString.Trim
                Li5 = DT.Rows(DT.Rows.Count - 1).Item("l5").ToString.Trim
                IdLi6 = DT.Rows(DT.Rows.Count - 1).Item("idl6").ToString.Trim
                Li6 = DT.Rows(DT.Rows.Count - 1).Item("l6").ToString.Trim
                Mar = IdEstructura
                Mode = Estructura
            End If
            AgregaRegistroDTEstado(NivelNvo, IdPlaza, Plaza, IdSucursal, Sucursal, DT.Rows(DT.Rows.Count - 1).Item("fecini").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("fecfin").ToString.Trim, IdDiv, Div, IdDep, Dep, IdFam, Fam, IdLin, Lin, IdLi1, Li1, IdLi2, Li2, IdLi3, Li3, IdLi4, Li4, IdLi5, Li5, IdLi6, Li6, Mar, Mode, DT.Rows(DT.Rows.Count - 1).Item("idagrupacion").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("agrupacion").ToString.Trim)

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub CargarFotoArticulo(ByVal Marca, ByVal Estilon)
        'mreyes 14/Marzo/2012 07:06 p.m.
        'Glb_RutaArchivoFotos
        Try
            Dim Archivo As String = ""
            Dim NoFoto As String = "1"

            'MarcaFOTO = Marca
            'EstiloNFOTO = Estilon
            PBox.Visible = False
            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)

                Archivo = objIO.pub_ArmarNombreFotoEstilo(If(GLB_CveSucursal <> "", GLB_RutaArchivoFotosLocal, GLB_RutaArchivoFotos), Marca, Estilon, NoFoto)

                If objIO.pub_ExisteArchivo(Archivo) = True Then
                    PBox.Image = New System.Drawing.Bitmap(Archivo)
                    PBox.Visible = True
                    Exit Sub


                End If

                For i As Integer = 1 To 9
                    Archivo = objIO.pub_ArmarNombreFotoEstilo(If(GLB_CveSucursal <> "", GLB_RutaArchivoFotosLocal, GLB_RutaArchivoFotos), Marca, Estilon, i)
                    If objIO.pub_ExisteArchivo(Archivo) = True Then
                        PBox.Image = New System.Drawing.Bitmap(Archivo)
                        PBox.Visible = True
                        Exit Sub

                    Else
                        Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Marca, Estilon, i)
                        If objIO.pub_ExisteArchivo(Archivo) = True Then
                            PBox.Image = New System.Drawing.Bitmap(Archivo)
                            PBox.Visible = True
                            Exit Sub
                        End If

                    End If
                Next

            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

#End Region

#Region "Eventos"
    Private Sub frmRepVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            CreaDTEstado()
            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Salir_Click(sender As Object, e As EventArgs) Handles btn_Salir.Click
        Me.Close()
    End Sub

    Private Sub frmRepVentas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub dgv_Reporte_DoubleClick(sender As Object, e As EventArgs) Handles dgv_Reporte.DoubleClick
        Try
            If NivelAct = "MODELO" Then Exit Sub
            Dim ea As DXMouseEventArgs = TryCast(e, DXMouseEventArgs)
            Dim view As GridView = TryCast(sender, GridView)
            Dim info As GridHitInfo = view.CalcHitInfo(ea.Location)
            If info.InRow OrElse info.InRowCell Then
                'MessageBox.Show(dgv_Reporte.GetRowCellValue(info.RowHandle, "estructura"))
                Dim IdEstructura As String
                Dim Estructura As String
                IdEstructura = dgv_Reporte.GetRowCellValue(info.RowHandle, "idestructura").ToString.Trim
                Estructura = dgv_Reporte.GetRowCellValue(info.RowHandle, "estructura").ToString.Trim
                If Estructura = "TOTAL" Then
                    Estructura = ""
                End If
                If NivelAct = "PLAZA" Then
                    NivelAct = TraerSigNivel(NivelAct)
                    AgregaRegistroDTEstado(NivelAct, IdEstructura, Estructura, DT.Rows(DT.Rows.Count - 1).Item("idsucursal").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("sucursal").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("fecini").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("fecfin").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("iddivision").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("division").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("iddepto").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("depto").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idfamilia").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("familia").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idlinea").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("linea").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl1").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l1").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl2").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l2").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl3").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l3").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl4").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l4").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl5").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l5").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl6").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l6").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("marca").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("modelo").ToString, DT.Rows(DT.Rows.Count - 1).Item("idagrupacion").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("agrupacion").ToString.Trim)
                ElseIf NivelAct = "SUCURSAL" Then
                    NivelAct = TraerSigNivel(NivelAct)
                    AgregaRegistroDTEstado(NivelAct, DT.Rows(DT.Rows.Count - 1).Item("idplaza").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("plaza").ToString.Trim, IdEstructura, Estructura, DT.Rows(DT.Rows.Count - 1).Item("fecini").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("fecfin").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("iddivision").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("division").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("iddepto").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("depto").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idfamilia").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("familia").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idlinea").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("linea").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl1").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l1").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl2").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l2").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl3").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l3").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl4").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l4").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl5").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l5").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl6").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l6").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("marca").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("modelo").ToString, DT.Rows(DT.Rows.Count - 1).Item("idagrupacion").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("agrupacion").ToString.Trim)
                ElseIf NivelAct = "DIVISION" Then
                    NivelAct = TraerSigNivel(NivelAct)
                    AgregaRegistroDTEstado(NivelAct, DT.Rows(DT.Rows.Count - 1).Item("idplaza").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("plaza").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idsucursal").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("sucursal").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("fecini").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("fecfin").ToString.Trim, IdEstructura, Estructura, DT.Rows(DT.Rows.Count - 1).Item("iddepto").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("depto").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idfamilia").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("familia").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idlinea").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("linea").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl1").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l1").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl2").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l2").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl3").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l3").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl4").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l4").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl5").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l5").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl6").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l6").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("marca").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("modelo").ToString, DT.Rows(DT.Rows.Count - 1).Item("idagrupacion").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("agrupacion").ToString.Trim)
                ElseIf NivelAct = "DEPTO" Then
                    NivelAct = TraerSigNivel(NivelAct)
                    AgregaRegistroDTEstado(NivelAct, DT.Rows(DT.Rows.Count - 1).Item("idplaza").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("plaza").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idsucursal").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("sucursal").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("fecini").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("fecfin").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("iddivision").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("division").ToString.Trim, IdEstructura, Estructura, DT.Rows(DT.Rows.Count - 1).Item("idfamilia").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("familia").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idlinea").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("linea").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl1").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l1").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl2").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l2").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl3").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l3").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl4").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l4").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl5").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l5").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl6").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l6").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("marca").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("modelo").ToString, DT.Rows(DT.Rows.Count - 1).Item("idagrupacion").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("agrupacion").ToString.Trim)
                ElseIf NivelAct = "FAMILIA" Then
                    NivelAct = TraerSigNivel(NivelAct)
                    AgregaRegistroDTEstado(NivelAct, DT.Rows(DT.Rows.Count - 1).Item("idplaza").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("plaza").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idsucursal").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("sucursal").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("fecini").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("fecfin").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("iddivision").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("division").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("iddepto").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("depto").ToString.Trim, IdEstructura, Estructura, DT.Rows(DT.Rows.Count - 1).Item("idlinea").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("linea").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl1").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l1").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl2").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l2").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl3").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l3").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl4").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l4").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl5").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l5").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl6").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l6").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("marca").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("modelo").ToString, DT.Rows(DT.Rows.Count - 1).Item("idagrupacion").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("agrupacion").ToString.Trim)
                ElseIf NivelAct = "LINEA" Then
                    NivelAct = TraerSigNivel(NivelAct)
                    AgregaRegistroDTEstado(NivelAct, DT.Rows(DT.Rows.Count - 1).Item("idplaza").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("plaza").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idsucursal").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("sucursal").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("fecini").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("fecfin").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("iddivision").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("division").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("iddepto").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("depto").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idfamilia").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("familia").ToString.Trim, IdEstructura, Estructura, DT.Rows(DT.Rows.Count - 1).Item("idl1").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l1").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl2").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l2").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl3").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l3").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl4").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l4").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl5").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l5").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl6").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l6").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("marca").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("modelo").ToString, DT.Rows(DT.Rows.Count - 1).Item("idagrupacion").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("agrupacion").ToString.Trim)
                ElseIf NivelAct = "L1" Then
                    NivelAct = TraerSigNivel(NivelAct)
                    AgregaRegistroDTEstado(NivelAct, DT.Rows(DT.Rows.Count - 1).Item("idplaza").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("plaza").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idsucursal").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("sucursal").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("fecini").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("fecfin").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("iddivision").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("division").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("iddepto").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("depto").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idfamilia").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("familia").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idlinea").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("linea").ToString.Trim, IdEstructura, Estructura, DT.Rows(DT.Rows.Count - 1).Item("idl2").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l2").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl3").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l3").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl4").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l4").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl5").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l5").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl6").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l6").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("marca").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("modelo").ToString, DT.Rows(DT.Rows.Count - 1).Item("idagrupacion").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("agrupacion").ToString.Trim)
                ElseIf NivelAct = "L2" Then
                    NivelAct = TraerSigNivel(NivelAct)
                    AgregaRegistroDTEstado(NivelAct, DT.Rows(DT.Rows.Count - 1).Item("idplaza").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("plaza").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idsucursal").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("sucursal").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("fecini").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("fecfin").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("iddivision").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("division").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("iddepto").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("depto").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idfamilia").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("familia").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idlinea").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("linea").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl1").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l1").ToString.Trim, IdEstructura, Estructura, DT.Rows(DT.Rows.Count - 1).Item("idl3").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l3").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl4").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l4").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl5").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l5").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl6").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l6").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("marca").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("modelo").ToString, DT.Rows(DT.Rows.Count - 1).Item("idagrupacion").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("agrupacion").ToString.Trim)
                ElseIf NivelAct = "L3" Then
                    NivelAct = TraerSigNivel(NivelAct)
                    AgregaRegistroDTEstado(NivelAct, DT.Rows(DT.Rows.Count - 1).Item("idplaza").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("plaza").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idsucursal").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("sucursal").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("fecini").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("fecfin").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("iddivision").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("division").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("iddepto").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("depto").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idfamilia").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("familia").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idlinea").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("linea").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl1").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l1").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl2").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l2").ToString.Trim, IdEstructura, Estructura, DT.Rows(DT.Rows.Count - 1).Item("idl4").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l4").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl5").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l5").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl6").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l6").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("marca").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("modelo").ToString, DT.Rows(DT.Rows.Count - 1).Item("idagrupacion").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("agrupacion").ToString.Trim)
                ElseIf NivelAct = "L4" Then
                    NivelAct = TraerSigNivel(NivelAct)
                    AgregaRegistroDTEstado(NivelAct, DT.Rows(DT.Rows.Count - 1).Item("idplaza").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("plaza").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idsucursal").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("sucursal").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("fecini").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("fecfin").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("iddivision").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("division").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("iddepto").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("depto").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idfamilia").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("familia").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idlinea").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("linea").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl1").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l1").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl2").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l2").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl3").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l3").ToString.Trim, IdEstructura, Estructura, DT.Rows(DT.Rows.Count - 1).Item("idl5").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l5").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl6").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l6").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("marca").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("modelo").ToString, DT.Rows(DT.Rows.Count - 1).Item("idagrupacion").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("agrupacion").ToString.Trim)
                ElseIf NivelAct = "L5" Then
                    NivelAct = TraerSigNivel(NivelAct)
                    AgregaRegistroDTEstado(NivelAct, DT.Rows(DT.Rows.Count - 1).Item("idplaza").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("plaza").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idsucursal").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("sucursal").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("fecini").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("fecfin").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("iddivision").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("division").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("iddepto").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("depto").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idfamilia").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("familia").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idlinea").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("linea").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl1").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l1").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl2").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l2").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl3").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l3").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl4").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l4").ToString.Trim, IdEstructura, Estructura, DT.Rows(DT.Rows.Count - 1).Item("idl6").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l6").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("marca").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("modelo").ToString, DT.Rows(DT.Rows.Count - 1).Item("idagrupacion").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("agrupacion").ToString.Trim)
                ElseIf NivelAct = "L6" Then
                    NivelAct = TraerSigNivel(NivelAct)
                    AgregaRegistroDTEstado(NivelAct, DT.Rows(DT.Rows.Count - 1).Item("idplaza").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("plaza").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idsucursal").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("sucursal").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("fecini").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("fecfin").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("iddivision").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("division").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("iddepto").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("depto").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idfamilia").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("familia").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idlinea").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("linea").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl1").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l1").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl2").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l2").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl3").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l3").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl4").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l4").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl5").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l5").ToString.Trim, IdEstructura, Estructura, DT.Rows(DT.Rows.Count - 1).Item("marca").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("modelo").ToString, DT.Rows(DT.Rows.Count - 1).Item("idagrupacion").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("agrupacion").ToString.Trim)
                ElseIf NivelAct = "MARCA" Then
                    NivelAct = TraerSigNivel(NivelAct)
                    AgregaRegistroDTEstado(NivelAct, DT.Rows(DT.Rows.Count - 1).Item("idplaza").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("plaza").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idsucursal").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("sucursal").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("fecini").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("fecfin").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("iddivision").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("division").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("iddepto").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("depto").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idfamilia").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("familia").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idlinea").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("linea").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl1").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l1").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl2").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l2").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl3").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l3").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl4").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l4").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl5").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l5").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idl6").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("l6").ToString.Trim, IdEstructura, DT.Rows(DT.Rows.Count - 1).Item("modelo").ToString, DT.Rows(DT.Rows.Count - 1).Item("idagrupacion").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("agrupacion").ToString.Trim)
                End If
            End If
            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Regresar_Click(sender As Object, e As EventArgs) Handles btn_Regresar.Click
        Try
            If DT.Rows.Count = 1 Then
                MessageBox.Show("No puedes regresar, estas en el inicio", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            DT.Rows.Remove(DT.Rows(DT.Rows.Count - 1))
            NivelAct = DT.Rows(DT.Rows.Count - 1).Item("Nivel").ToString.Trim
            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub dgv_Reporte_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs)
        Try
            Dim view As GridView = TryCast(sender, GridView)

            If e.MenuType = GridMenuType.Row Then
                Dim rowHandle As Integer = e.HitInfo.RowHandle
                e.Menu.Items.Clear()
                'e.Menu.Items.Add(CreateSubMenuRows(view, rowHandle))
                Dim item As DXMenuItem = CreateMenuItem(view, rowHandle, "Plaza", CType(SIRCO.My.Resources._04_maps, Image))
                e.Menu.Items.Add(item)
                item = CreateMenuItem(view, rowHandle, "Sucursal", CType(SIRCO.My.Resources.store_plus, Image))
                e.Menu.Items.Add(item)
                item = CreateMenuItem(view, rowHandle, "División", CType(SIRCO.My.Resources.box_full, Image))
                item.BeginGroup = True
                e.Menu.Items.Add(item)
                item = CreateMenuItem(view, rowHandle, "Departamento", CType(SIRCO.My.Resources.DEPTOS, Image))
                e.Menu.Items.Add(item)
                item = CreateMenuItem(view, rowHandle, "Familia", CType(SIRCO.My.Resources.usuario1, Image))
                e.Menu.Items.Add(item)
                item = CreateMenuItem(view, rowHandle, "Linea", CType(SIRCO.My.Resources.shoe, Image))
                e.Menu.Items.Add(item)
                item = CreateMenuItem(view, rowHandle, "L1", CType(SIRCO.My.Resources.shoe__1_, Image))
                e.Menu.Items.Add(item)
                item = CreateMenuItem(view, rowHandle, "L2", CType(SIRCO.My.Resources.shoes_search, Image))
                e.Menu.Items.Add(item)
                item = CreateMenuItem(view, rowHandle, "L3", CType(SIRCO.My.Resources.images1, Image))
                e.Menu.Items.Add(item)
                item = CreateMenuItem(view, rowHandle, "L4", CType(SIRCO.My.Resources.gucci_shoe, Image))
                e.Menu.Items.Add(item)
                item = CreateMenuItem(view, rowHandle, "L5", CType(SIRCO.My.Resources.buckle_shoe, Image))
                e.Menu.Items.Add(item)
                item = CreateMenuItem(view, rowHandle, "L6", CType(SIRCO.My.Resources.if_telephone_531914, Image))
                e.Menu.Items.Add(item)
                item = CreateMenuItem(view, rowHandle, "Marca", CType(SIRCO.My.Resources.document_mark_as_final, Image))
                item.BeginGroup = True
                e.Menu.Items.Add(item)
                item = CreateMenuItem(view, rowHandle, "Modelo", CType(SIRCO.My.Resources.ZAPATO, Image))
                e.Menu.Items.Add(item)
                If NivelAct = "MODELO" Then
                    item = CreateMenuItem(view, rowHandle, "Catálogo de Modelos", CType(SIRCO.My.Resources.document_add, Image))
                    e.Menu.Items.Add(item)
                    item = CreateMenuItem(view, rowHandle, "Análisis de Modelos", CType(SIRCO.My.Resources.monitoreo, Image))
                    e.Menu.Items.Add(item)
                End If
                item = CreateMenuItem(view, rowHandle, "Inicio", CType(SIRCO.My.Resources.arrowright, Image))
                item.BeginGroup = True
                e.Menu.Items.Add(item)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub OnCellMergingClick(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim item As DXMenuItem = TryCast(sender, DXMenuItem)
            Dim info As rowinforotacion = TryCast(item.Tag, rowinforotacion)
            Dim blnEsInicio As Boolean = False
            If sender.caption = "Plaza" Then
                NivelAct = "PLAZA"
            ElseIf sender.caption = "Sucursal" Then
                NivelAct = "SUCURSAL"
            ElseIf sender.caption = "División" Then
                NivelAct = "DIVISION"
            ElseIf sender.caption = "Departamento" Then
                NivelAct = "DEPTO"
            ElseIf sender.caption = "Familia" Then
                NivelAct = "FAMILIA"
            ElseIf sender.caption = "Linea" Then
                NivelAct = "LINEA"
            ElseIf sender.caption = "L1" Then
                NivelAct = "L1"
            ElseIf sender.caption = "L2" Then
                NivelAct = "L2"
            ElseIf sender.caption = "L3" Then
                NivelAct = "L3"
            ElseIf sender.caption = "L4" Then
                NivelAct = "L4"
            ElseIf sender.caption = "L5" Then
                NivelAct = "L5"
            ElseIf sender.caption = "L6" Then
                NivelAct = "L6"
            ElseIf sender.caption = "Marca" Then
                NivelAct = "MARCA"
            ElseIf sender.caption = "Modelo" Then
                NivelAct = "MODELO"
            ElseIf sender.caption = "Catálogo de Modelos" Then
                Dim myForm As New frmCatalogoModelos
                myForm.Txt_Marca.Text = dgv_Reporte.GetRowCellValue(dgv_Reporte.FocusedRowHandle, "idestructura").ToString.Trim
                myForm.Txt_Modelo.Text = dgv_Reporte.GetRowCellValue(dgv_Reporte.FocusedRowHandle, "estructura").ToString
                myForm.Accion = 2
                myForm.ShowDialog()
                Exit Sub
            ElseIf sender.caption = "Análisis de Modelos" Then
                Dim myForm As New frmAnalisisModelo
                myForm.Txt_Marca.Text = dgv_Reporte.GetRowCellValue(dgv_Reporte.FocusedRowHandle, "idestructura").ToString.Trim
                myForm.Txt_Modelo.Text = dgv_Reporte.GetRowCellValue(dgv_Reporte.FocusedRowHandle, "estructura").ToString
                myForm.Accion = 1
                myForm.WindowState = FormWindowState.Maximized
                myForm.ShowDialog()
                Exit Sub
            ElseIf sender.caption = "Inicio" Then
                blnEsInicio = True
                NivelAct = "DIVISION"
                For i As Integer = 1 To DT.Rows.Count - 1
                    DT.Rows.Remove(DT.Rows(1))
                Next
            Else
                Exit Sub
            End If
            If blnEsInicio = False Then
                TraerNivelClickDerecho(DT.Rows(DT.Rows.Count - 1).Item("nivel").ToString.Trim, NivelAct, dgv_Reporte.GetRowCellValue(info.RowHandle, "idestructura").ToString.Trim, dgv_Reporte.GetRowCellValue(info.RowHandle, "estructura").ToString)
            End If
            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Function CreateMenuItem(ByVal view As GridView, ByVal rowHandle As Integer, ByVal Nombre As String, ByVal Imagen As Image) As DXMenuItem
        Try
            Dim im As New Bitmap(New Bitmap(Imagen), 16, 16)
            Dim checkItem As DXMenuItem = New DXMenuItem(Nombre, New EventHandler(AddressOf OnCellMergingClick))
            checkItem.Tag = New rowinforotacion(view, rowHandle)
            checkItem.ImageOptions.Image = im
            Return checkItem
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Private Sub btn_Filtros_Click(sender As Object, e As EventArgs) Handles btn_Filtros.Click
        Try
            Dim myForm As New frmFiltrosRepVentas
            myForm.dt_FecIni.EditValue = CDate(DT.Rows(DT.Rows.Count - 1).Item("fecini").ToString.Trim)
            myForm.dt_FecFin.EditValue = CDate(DT.Rows(DT.Rows.Count - 1).Item("fecfin").ToString.Trim)
            myForm.IdPlaza = DT.Rows(DT.Rows.Count - 1).Item("idplaza").ToString.Trim
            myForm.IdSucursal = DT.Rows(DT.Rows.Count - 1).Item("idsucursal").ToString.Trim
            myForm.txt_Marca.Text = DT.Rows(DT.Rows.Count - 1).Item("marca").ToString.Trim
            myForm.txt_Marca_LostFocus(sender, e)
            myForm.txt_Modelo.Text = DT.Rows(DT.Rows.Count - 1).Item("modelo").ToString
            myForm.txt_IdDivision.Text = DT.Rows(DT.Rows.Count - 1).Item("iddivision").ToString.Trim
            myForm.txt_DescripDivision.Text = DT.Rows(DT.Rows.Count - 1).Item("division").ToString.Trim
            myForm.txt_IdDepto.Text = DT.Rows(DT.Rows.Count - 1).Item("iddepto").ToString.Trim
            myForm.txt_DescripDepto.Text = DT.Rows(DT.Rows.Count - 1).Item("depto").ToString.Trim
            myForm.txt_IdFamilia.Text = DT.Rows(DT.Rows.Count - 1).Item("idfamilia").ToString.Trim
            myForm.txt_DescripFamilia.Text = DT.Rows(DT.Rows.Count - 1).Item("familia").ToString.Trim
            myForm.txt_IdLinea.Text = DT.Rows(DT.Rows.Count - 1).Item("idlinea").ToString.Trim
            myForm.txt_DescripLinea.Text = DT.Rows(DT.Rows.Count - 1).Item("linea").ToString.Trim
            myForm.txt_IdL1.Text = DT.Rows(DT.Rows.Count - 1).Item("idl1").ToString.Trim
            myForm.txt_DescripL1.Text = DT.Rows(DT.Rows.Count - 1).Item("l1").ToString.Trim
            myForm.txt_IdL2.Text = DT.Rows(DT.Rows.Count - 1).Item("idl2").ToString.Trim
            myForm.txt_DescripL2.Text = DT.Rows(DT.Rows.Count - 1).Item("l2").ToString.Trim
            myForm.txt_IdL3.Text = DT.Rows(DT.Rows.Count - 1).Item("idl3").ToString.Trim
            myForm.txt_DescripL3.Text = DT.Rows(DT.Rows.Count - 1).Item("l3").ToString.Trim
            myForm.txt_IdL4.Text = DT.Rows(DT.Rows.Count - 1).Item("idl4").ToString.Trim
            myForm.txt_DescripL4.Text = DT.Rows(DT.Rows.Count - 1).Item("l4").ToString.Trim
            myForm.txt_IdL5.Text = DT.Rows(DT.Rows.Count - 1).Item("idl5").ToString.Trim
            myForm.txt_DescripL5.Text = DT.Rows(DT.Rows.Count - 1).Item("l5").ToString.Trim
            myForm.txt_IdL6.Text = DT.Rows(DT.Rows.Count - 1).Item("idl6").ToString.Trim
            myForm.txt_DescripL6.Text = DT.Rows(DT.Rows.Count - 1).Item("l6").ToString.Trim
            myForm.txt_IdAgrupacion.Text = DT.Rows(DT.Rows.Count - 1).Item("idagrupacion").ToString.Trim
            myForm.txt_descripAgru.Text = DT.Rows(DT.Rows.Count - 1).Item("agrupacion").ToString.Trim
            myForm.ShowDialog()
            If myForm.Sw_Filtro = True Then
                Dim IdPla, Pla, IdSuc, Suc As String
                If myForm.cbo_Plaza.EditValue IsNot Nothing Then
                    If myForm.cbo_Plaza.EditValue.ToString.Trim = "" Then
                        IdPla = 0
                        Pla = ""
                    Else
                        IdPla = myForm.cbo_Plaza.EditValue
                        Pla = myForm.cbo_Plaza.Text.Trim.Substring(3, myForm.cbo_Plaza.Text.Trim.Length - 3)
                    End If
                Else
                    IdPla = 0
                    Pla = ""
                End If
                If myForm.cbo_Sucursal.EditValue IsNot Nothing Then
                    If myForm.cbo_Sucursal.EditValue.ToString.Trim = "" Then
                        IdSuc = 0
                        Suc = ""
                    Else
                        IdSuc = myForm.cbo_Sucursal.EditValue
                        Suc = myForm.cbo_Sucursal.Text.Trim.Substring(3, myForm.cbo_Sucursal.Text.Trim.Length - 3)
                    End If
                Else
                    IdSuc = 0
                    Suc = ""
                End If
                AgregaRegistroDTEstado(DT.Rows(DT.Rows.Count - 1).Item("nivel").ToString.Trim, IdPla, Pla, IdSuc, Suc, Format(myForm.dt_FecIni.EditValue, "yyyy-MM-dd"), Format(myForm.dt_FecFin.EditValue, "yyyy-MM-dd"), myForm.txt_IdDivision.Text.Trim, myForm.txt_DescripDivision.Text.Trim, myForm.txt_IdDepto.Text.Trim, myForm.txt_DescripDepto.Text.Trim, myForm.txt_IdFamilia.Text.Trim, myForm.txt_DescripFamilia.Text.Trim, myForm.txt_IdLinea.Text.Trim, myForm.txt_DescripLinea.Text.Trim, myForm.txt_IdL1.Text.Trim, myForm.txt_DescripL1.Text.Trim, myForm.txt_IdL2.Text.Trim, myForm.txt_DescripL2.Text.Trim, myForm.txt_IdL3.Text.Trim, myForm.txt_DescripL3.Text.Trim, myForm.txt_IdL4.Text.Trim, myForm.txt_DescripL4.Text.Trim, myForm.txt_IdL5.Text.Trim, myForm.txt_DescripL5.Text.Trim, myForm.txt_IdL6.Text.Trim, myForm.txt_DescripL6.Text.Trim, myForm.txt_Marca.Text.Trim, myForm.txt_Modelo.Text, myForm.txt_IdAgrupacion.Text.Trim, myForm.txt_descripAgru.Text.Trim)
                RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub dgv_Reporte_RowStyle(sender As Object, e As RowStyleEventArgs)
        Try
            If e.RowHandle = 0 Then
                e.Appearance.BackColor = Color.MediumAquamarine
                e.Appearance.BackColor2 = Color.MediumAquamarine
                e.Appearance.FontStyleDelta = FontStyle.Bold
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub chk_Miles_CheckedChanged(sender As Object, e As EventArgs) Handles chk_Miles.CheckedChanged
        Try
            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub chk_DiaSemana_CheckedChanged(sender As Object, e As EventArgs) Handles chk_DiaSemana.CheckedChanged
        Try
            If CambioCheck = False Then
                If chk_DiaMes.Checked Then
                    CambioCheck = True
                    chk_DiaMes.Checked = False
                    CambioCheck = False
                End If
                RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub chk_DiaMes_CheckedChanged(sender As Object, e As EventArgs) Handles chk_DiaMes.CheckedChanged
        Try
            If CambioCheck = False Then
                If chk_DiaSemana.Checked Then
                    CambioCheck = True
                    chk_DiaSemana.Checked = False
                    CambioCheck = False
                End If
                RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Excel_Click(sender As Object, e As EventArgs) Handles btn_Excel.Click
        Try
            If dgv_Reporte.RowCount = 0 Then
                MessageBox.Show("No hay resultados, no se puede exportar a Excel", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            sfdRuta.DefaultExt = ".xls"
            sfdRuta.Filter = "Archivos de Excel(.xls)|.xls"
            If sfdRuta.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                gc_Reporte.ExportToXls(sfdRuta.FileName)
                MessageBox.Show("Archivo Excel creado en la ruta " & sfdRuta.FileName, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub dgv_Reporte_Click(sender As Object, e As EventArgs)
        Try
            If NivelAct <> "MODELO" Then
                PBox.Visible = False
                Exit Sub
            End If
            Dim ea As DXMouseEventArgs = TryCast(e, DXMouseEventArgs)
            Dim view As GridView = TryCast(sender, GridView)
            Dim info As GridHitInfo = view.CalcHitInfo(ea.Location)
            If info.InRow OrElse info.InRowCell Then
                Dim Marca As String
                Dim Modelo As String
                Marca = dgv_Reporte.GetRowCellValue(info.RowHandle, "idestructura").ToString.Trim
                Modelo = dgv_Reporte.GetRowCellValue(info.RowHandle, "estructura").ToString
                If Marca = "TOTAL" Then
                    PBox.Visible = False
                End If
                CargarFotoArticulo(Marca, Modelo)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub dgv_Reporte_KeyUp(sender As Object, e As KeyEventArgs)
        Try
            If NivelAct <> "MODELO" Then
                PBox.Visible = False
                Exit Sub
            End If
            Dim Marca As String
            Dim Modelo As String
            Marca = dgv_Reporte.GetRowCellValue(dgv_Reporte.FocusedRowHandle, "idestructura").ToString.Trim
            Modelo = dgv_Reporte.GetRowCellValue(dgv_Reporte.FocusedRowHandle, "estructura").ToString
            If Marca = "TOTAL" Then
                PBox.Visible = False
            End If
            CargarFotoArticulo(Marca, Modelo)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub chk_SucVenta_CheckedChanged(sender As Object, e As EventArgs) Handles chk_SucVenta.CheckedChanged
        Try
            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub gc_Reporte_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub gc_Reporte_Click_1(sender As Object, e As EventArgs) Handles gc_Reporte.Click

    End Sub

    Private Sub PanelControl1_Paint(sender As Object, e As PaintEventArgs) Handles PanelControl1.Paint

    End Sub


#End Region

End Class

Class rowinforotacion
    Public Sub New(ByVal view As GridView, ByVal rowHandle As Integer)
        Me.RowHandle = rowHandle
        Me.View = view
    End Sub

    Public View As GridView
    Public RowHandle As Integer
End Class