Imports System.Web.UI.WebControls
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid

Public Class frmPpalEstadoCarteraNew
    Private objDataSet As Data.DataSet
    Private Opcion As Integer = 1
    Dim n As Integer
    Dim tot_cartera, tot_capital, tot_intereses, tot_gsts_cobranza As String
    Dim sumatoria As Double
    Dim flag As Boolean = True
    Dim tot As String
    Dim total As Double
    Dim tipo_cartera As Integer
    Dim id_consulta, primeraParte As String
    Dim footer_capital, footer_intereses, footer_cobranza, footer_total_cartera As GridColumnSummaryItem
    Dim posicion As Integer

    'jvargas 23/agosto/2018  09:28 a.m.

    Private Sub RellenaGrid(opcion_cartera As Integer)
        Using objVent As New BCL.BCLCreditoNew(GLB_ConStringCreditoSQL)

            Try
                tot_cartera = "0"
                tot_capital = "0"
                tot_intereses = "0"
                tot_gsts_cobranza = "0"

                Me.Cursor = Cursors.WaitCursor
                DGrid.DataSource = Nothing
                GridView1.Columns.Clear()
                objDataSet = objVent.usp_PpalEstadoCarteraNew(opcion_cartera, DEditHasta.EditValue)

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    calcula_totales_cartera()
                    modifica_dataset()
                    DGrid.DataSource = objDataSet.Tables(0)

                    InicializaGrid(0, GridView1)
                    totales_columnas(GridView1)
                    GridView1.BestFitColumns()
                Else
                    MsgBox("No se encontraron registros para este tipo de cartera.", MsgBoxStyle.Critical, "Aviso")
                End If

                Me.Cursor = Cursors.Default
            Catch ExceptionErr As Exception
                Me.Cursor = Cursors.Default
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub RellenaGrid_DrillDown(tipo_cartera As Integer, id_consulta As Integer)
        Using objVent As New BCL.BCLCreditoNew(GLB_ConStringCreditoSQL)

            Try
                tot_cartera = "0"
                tot_capital = "0"
                tot_intereses = "0"
                tot_gsts_cobranza = "0"

                Me.Cursor = Cursors.WaitCursor
                objDataSet = objVent.usp_PpalEstadoCarteraDrillDownNew(DEditHasta.EditValue, tipo_cartera, id_consulta)

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If tipo_cartera = 1 Then 'para la cartera de vencido por gestor, calcular los totales y acomodar el dataset
                        calcula_totales_cartera_vencida() 'calcula los totales para cada registro del dataset
                        modifica_datasetDrillDown() 'agrega y pone formato de moneda a las cifras del dataset

                        DGrid2.DataSource = Nothing
                        DGrid2.DataSource = objDataSet.Tables(0)
                        totales_columnas(GridView2) 'calcula y coloca las columnas de totales en el footer del gridview
                        DGrid.Visible = False
                        DGrid2.Visible = True
                        InicializaGrid(tipo_cartera, GridView2) 'pone formato de celdas y columnas del gridview a mostrar
                        GridView2.BestFitColumns()
                    ElseIf tipo_cartera = 2 Or tipo_cartera = 3 Or tipo_cartera = 5 Or tipo_cartera = 8 Then 'para desglosar las carteras de los distribuidores en fresco, vigente y demanda
                        calcula_totales_tipo_distribuidor()
                        modifica_datasetDrillDown_TipoDistrib()

                        If DGrid2.Visible Then 'evalua si el grid2 esta visible para realizar operaciones sobre el tercer gridview
                            DGrid2.Visible = False
                            DGrid3.Visible = True
                            DGrid3.DataSource = objDataSet.Tables(0)
                            totales_columnas(GridView3)
                            InicializaGrid(tipo_cartera, GridView3)
                            GridView3.BestFitColumns()
                        Else 'si no esta visible en grid2, se inicializa el mismo grid2 para mostrarse
                            DGrid2.DataSource = Nothing
                            DGrid2.DataSource = objDataSet.Tables(0)
                            totales_columnas(GridView2)
                            DGrid.Visible = False
                            DGrid2.Visible = True
                            InicializaGrid(tipo_cartera, GridView2)
                            GridView2.BestFitColumns()
                        End If
                    ElseIf tipo_cartera = 6 Then 'despliega los tarjetahabientes y distrIbuidores de cartera fresca y vencida
                        calcula_totales_tipo_distribuidor()
                        modifica_datasetDrillDown_TipoDistrib()
                        DGrid2.DataSource = Nothing
                        DGrid.Visible = False
                        DGrid2.Visible = True
                        DGrid2.DataSource = objDataSet.Tables(0)
                        totales_columnas(GridView2)
                        InicializaGrid(tipo_cartera, GridView2)
                        GridView2.BestFitColumns()
                    ElseIf tipo_cartera = 7 Then 'despliega los abogados para la cartera en demanda
                        calcula_totales_cartera_vencida() 'calcula los totales para cada registro del dataset
                        modifica_datasetDrillDown() 'agrega y pone formato de moneda a las cifras del dataset

                        DGrid2.DataSource = Nothing
                        DGrid2.DataSource = objDataSet.Tables(0)
                        totales_columnas(GridView2) 'calcula y coloca las columnas de totales en el footer del gridview
                        DGrid.Visible = False
                        DGrid2.Visible = True
                        InicializaGrid(tipo_cartera, GridView2) 'pone formato de celdas y columnas del gridview a mostrar
                        GridView2.BestFitColumns()
                    End If

                    DEditHasta.Enabled = False 'inhabilita el control de la fecha para que las demas consultas sean homogeneas sobre los totales consultados inicialmente
                    Btn_Consultar.Enabled = False 'inhabilita el boton para que las demas consultas sean homogeneas sobre los totales consultados inicialmente
                Else
                    MsgBox("No se encontraron movimientos para este tipo de cartera.", MsgBoxStyle.Critical, "Aviso")
                End If

                Me.Cursor = Cursors.Default
            Catch ExceptionErr As Exception
                Me.Cursor = Cursors.Default
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub calcula_totales_cartera()
        n = 0

        Try
            For Each row As DataRow In objDataSet.Tables(0).Rows
                If n >= 1 Then
                    tot_cartera = CDbl(row("capital")) + CDbl(row("intereses")) + CDbl(row("gsts_cobranza"))
                    row("total") = tot_cartera

                    tot_capital = CDbl(tot_capital) + row("capital")
                    tot_intereses = CDbl(tot_intereses) + row("intereses")
                    tot_gsts_cobranza = CDbl(tot_gsts_cobranza) + row("gsts_cobranza")
                End If

                objDataSet.AcceptChanges()
                n = n + 1
            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub calcula_totales_tipo_distribuidor()
        n = 0

        Try
            For Each row As DataRow In objDataSet.Tables(0).Rows
                If n >= 1 Then
                    tot_cartera = CDbl(row("capital")) + CDbl(row("intereses")) + CDbl(row("gsts_cobranza"))
                    row("total") = tot_cartera

                    tot_capital = CDbl(tot_capital) + row("capital")
                    tot_intereses = CDbl(tot_intereses) + row("intereses")
                    tot_gsts_cobranza = CDbl(tot_gsts_cobranza) + row("gsts_cobranza")
                End If

                objDataSet.AcceptChanges()
                n = n + 1
            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub calcula_totales_cartera_vencida()
        n = 0

        Try
            For Each row As DataRow In objDataSet.Tables(0).Rows
                If n >= 1 Then
                    tot_cartera = CDbl(row("capital")) + CDbl(row("intereses")) + CDbl(row("gsts_cobranza"))
                    row("total") = tot_cartera

                    tot_capital = CDbl(tot_capital) + CDbl(row("capital"))
                    tot_intereses = CDbl(tot_intereses) + CDbl(row("intereses"))
                    tot_gsts_cobranza = CDbl(tot_gsts_cobranza) + CDbl(row("gsts_cobranza"))
                End If

                objDataSet.AcceptChanges()
                n = n + 1
            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub modifica_dataset()
        tot = ""
        flag = True 'formatea segundo renglon de gridview, el de los totales y tomar la variable sumatoria como el total neto de la cartera visualizada
        total = 0
        n = 0

        Try
            For Each row As DataRow In objDataSet.Tables(0).Rows
                If n >= 1 And flag Then
                    sumatoria = "$" + Format(CDbl(tot_capital) + CDbl(tot_intereses) + CDbl(tot_gsts_cobranza), "##,##0.00")
                    row("capital") = "$" + Format(CDbl(row("capital")), "##,##0.00")
                    row("intereses") = "$" + Format(CDbl(row("intereses")), "##,##0.00")
                    row("gsts_cobranza") = "$" + Format(CDbl(row("gsts_cobranza")), "##,##0.00")
                End If

                If n >= 1 Then
                    row("total") = "$" + Format(CDbl(row("total")), "##,##0.00")
                    row("capital") = "$" + Format(CDbl(row("capital")), "##,##0.00")
                    row("intereses") = "$" + Format(CDbl(row("intereses")), "##,##0.00")
                    row("gsts_cobranza") = "$" + Format(CDbl(row("gsts_cobranza")), "##,##0.00")

                    flag = False
                End If

                If n >= 1 Then
                    total = CDbl(row("total"))
                    tot = CDbl(((total * 100) / sumatoria) / 100).ToString("0.00%")

                    row("porc") = tot
                End If

                objDataSet.AcceptChanges()
                n = n + 1
            Next

            calcula_porcentajes_header(sumatoria, CDbl(CDbl(tot_capital)), CDbl(tot_intereses), CDbl(tot_gsts_cobranza))
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub calcula_porcentajes_header(sumatoria As Double, tot_capital As Double, tot_intereses As Double, tot_cobranza As Double)
        n = 0

        Try
            For Each row As DataRow In objDataSet.Tables(0).Rows
                If n = 0 Then
                    row("capital") = Format(((tot_capital * 100) / sumatoria) / 100, "0.00%")
                    row("intereses") = Format(((tot_intereses * 100) / sumatoria) / 100, "0.00%")
                    row("gsts_cobranza") = Format(((tot_cobranza * 100) / sumatoria) / 100, "0.00%")

                    objDataSet.AcceptChanges()
                    n = n + 1
                Else
                    Exit Sub
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub modifica_datasetDrillDown()
        tot = ""
        total = 0
        flag = True
        n = 0

        Try
            For Each row As DataRow In objDataSet.Tables(0).Rows
                If n >= 1 And flag Then 'calcula la sumatoria total de toda la cartera y pone formato de moneda
                    sumatoria = "$" + Format(CDbl(tot_capital) + CDbl(tot_intereses) + CDbl(tot_gsts_cobranza), "##,##0.00")
                    row("capital") = "$" + Format(CDbl(row("capital")), "##,##0.00")
                    row("intereses") = "$" + Format(CDbl(row("intereses")), "##,##0.00")
                    row("gsts_cobranza") = "$" + Format(CDbl(row("gsts_cobranza")), "##,##0.00")
                End If

                If n >= 1 Then 'pone formato de moneda
                    row("total") = "$" + Format(CDbl(row("total")), "##,##0.00")
                    row("capital") = "$" + Format(CDbl(row("capital")), "##,##0.00")
                    row("intereses") = "$" + Format(CDbl(row("intereses")), "##,##0.00")
                    row("gsts_cobranza") = "$" + Format(CDbl(row("gsts_cobranza")), "##,##0.00")

                    flag = False
                End If

                If n >= 1 Then 'calcula los porcentajes por cada registro de la cartera a consultar
                    total = row("total")
                    tot = CDbl(((total * 100) / sumatoria) / 100).ToString("0.00%")

                    row("porc") = tot
                End If

                objDataSet.AcceptChanges()
                n = n + 1
            Next

            calcula_porcentajes_header(sumatoria, tot_capital, tot_intereses, tot_gsts_cobranza)
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub modifica_datasetDrillDown_TipoDistrib()
        tot = ""
        total = 0
        n = 0
        flag = True

        Try
            For Each row As DataRow In objDataSet.Tables(0).Rows
                If n >= 1 And flag Then
                    sumatoria = "$" + Format(CDbl(tot_capital) + CDbl(tot_intereses) + CDbl(tot_gsts_cobranza), "##,##0.00")
                    row("capital") = "$" + Format(CDbl(row("capital")), "##,##0.00")
                    row("intereses") = "$" + Format(CDbl(row("intereses")), "##,##0.00")
                    row("gsts_cobranza") = "$" + Format(CDbl(row("gsts_cobranza")), "##,##0.00")
                End If

                If n >= 1 Then
                    row("total") = "$" + Format(CDbl(row("total")), "##,##0.00")
                    row("capital") = "$" + Format(CDbl(row("capital")), "##,##0.00")
                    row("intereses") = "$" + Format(CDbl(row("intereses")), "##,##0.00")
                    row("gsts_cobranza") = "$" + Format(CDbl(row("gsts_cobranza")), "##,##0.00")

                    flag = False
                End If

                If n >= 1 Then
                    total = row("total")
                    tot = CDbl(((total * 100) / sumatoria) / 100).ToString("0.00%")

                    row("porc") = tot
                End If

                objDataSet.AcceptChanges()
                n = n + 1
            Next

            calcula_porcentajes_header(sumatoria, tot_capital, tot_intereses, tot_gsts_cobranza)
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub InicializaGrid(tipo_cartera As Integer, gridview As DevExpress.XtraGrid.Views.Grid.GridView)
        Try
            gridview.OptionsBehavior.Editable = False
            gridview.FixedLineWidth = 2

            If tipo_cartera = 0 Then
                gridview.Columns("tipo_cartera").Caption = "Tipo Cartera"
                gridview.Columns("porc").Caption = "%"
                gridview.Columns("total").Caption = "Total"
                gridview.Columns("capital").Caption = "Capital"
                gridview.Columns("intereses").Caption = "Intereses"
                gridview.Columns("gsts_cobranza").Caption = "Gsts. Cobranza"

                gridview.Columns("tipo_cartera").Fixed = Columns.FixedStyle.Left
                gridview.Columns("id").Visible = False

                gridview.Columns("porc").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                gridview.Columns("tipo_cartera").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                gridview.Columns("porc").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

                For i As Integer = 2 To 5 Step 1
                    gridview.Columns(i).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    gridview.Columns(i).OptionsColumn.ReadOnly = True
                Next
            ElseIf tipo_cartera = 1 Then 'para cartera de vencido por gestores
                gridview.Columns("gestor").Caption = "Gestor"
                gridview.Columns("porc").Caption = "%"
                gridview.Columns("total").Caption = "Total"
                gridview.Columns("capital").Caption = "Capital"
                gridview.Columns("intereses").Caption = "Intereses"
                gridview.Columns("gsts_cobranza").Caption = "Gsts. Cobranza"

                gridview.Columns("gestor").Fixed = Columns.FixedStyle.Left

                gridview.Columns("id").Visible = False
                gridview.Columns("idgestor").Visible = False
                gridview.Columns("gestor").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                gridview.Columns("porc").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

                For i As Integer = 4 To 7 Step 1
                    gridview.Columns(i).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    gridview.Columns(i).OptionsColumn.ReadOnly = True
                Next
            ElseIf tipo_cartera = 5 Or tipo_cartera = 2 Or tipo_cartera = 3 Or tipo_cartera = 8 Then 'para desglosar distribuidores de las carteras fresca, vigente, en demanda
                gridview.Columns("distrib").Caption = "Distribuidor"
                gridview.Columns("nombrecompleto").Caption = "Nombre"
                gridview.Columns("capital").Caption = "Capital"
                gridview.Columns("intereses").Caption = "Intereses"
                gridview.Columns("gsts_cobranza").Caption = "Gsts. Cobranza"
                gridview.Columns("porc").Caption = "%"
                gridview.Columns("total").Caption = "Total"

                gridview.Columns("distrib").Fixed = Columns.FixedStyle.Left
                gridview.Columns("nombrecompleto").Fixed = Columns.FixedStyle.Left

                gridview.Columns("distrib").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                gridview.Columns("nombrecompleto").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                gridview.Columns("porc").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                gridview.Columns("total").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

                For i As Integer = 3 To 6 Step 1
                    gridview.Columns(i).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    gridview.Columns(i).OptionsColumn.ReadOnly = True
                Next
            ElseIf tipo_cartera = 6 Then 'para desglosar los tipos de distribuidor(distribuidor, tarjetahabiente)
                gridview.Columns("clasificacion").Caption = "Clasificación"
                gridview.Columns("capital").Caption = "Capital"
                gridview.Columns("intereses").Caption = "Intereses"
                gridview.Columns("gsts_cobranza").Caption = "Gsts. Cobranza"
                gridview.Columns("porc").Caption = "%"
                gridview.Columns("total").Caption = "Total"

                gridview.Columns("clasificacion").Fixed = Columns.FixedStyle.Left

                gridview.Columns("id").Visible = False
                gridview.Columns("clasificacion").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near

                For i As Integer = 3 To 6 Step 1
                    gridview.Columns(i).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    gridview.Columns(i).OptionsColumn.ReadOnly = True
                Next
            ElseIf tipo_cartera = 7 Then 'para desglosar los abogados en cartera de demanda
                gridview.Columns("abogado").Caption = "Abogado"
                gridview.Columns("capital").Caption = "Capital"
                gridview.Columns("intereses").Caption = "Intereses"
                gridview.Columns("gsts_cobranza").Caption = "Gsts. Cobranza"
                gridview.Columns("porc").Caption = "%"
                gridview.Columns("total").Caption = "Total"

                gridview.Columns("abogado").Fixed = Columns.FixedStyle.Left

                gridview.Columns("id").Visible = False
                gridview.Columns("idabogado").Visible = False
                gridview.Columns("abogado").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near

                For i As Integer = 4 To 7 Step 1
                    gridview.Columns(i).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    gridview.Columns(i).OptionsColumn.ReadOnly = True
                Next
            End If

            gridview.OptionsView.ColumnAutoWidth = False
            gridview.OptionsView.ShowAutoFilterRow = False
            gridview.OptionsView.ShowFooter = True
            gridview.BestFitColumns()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub totales_columnas(gridview As Views.Grid.GridView)
        Try
            footer_capital = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "capital", "$" + Format(CDbl(tot_capital), "##,##0.00"))
            footer_intereses = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "intereses", "$" + Format(CDbl(tot_intereses), "##,##0.00"))
            footer_cobranza = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "gsts_cobranza", "$" + Format(CDbl(tot_gsts_cobranza), "##,##0.00"))
            footer_total_cartera = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", "$" + Format(CDbl(sumatoria), "##,##0.00"))

            gridview.Columns("capital").Summary.Add(footer_capital)
            gridview.Columns("total").Summary.Add(footer_total_cartera)
            gridview.Columns("intereses").Summary.Add(footer_intereses)
            gridview.Columns("gsts_cobranza").Summary.Add(footer_cobranza)
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub GenerarToolTip()
        Try
            tt_edo_cartera.SetToolTip(Btn_Consultar, "Consultar")
            tt_edo_cartera.SetToolTip(Btn_Regresar, "Regresar")
            tt_edo_cartera.SetToolTip(Btn_Salir, "Salir")
            tt_edo_cartera.SetToolTip(Btn_Excel, "Generar Excel")
            tt_edo_cartera.SetToolTip(DEditHasta, "Fecha hasta de la generación del reporte")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmPpalEstadoCarteraNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            DEditHasta.DateTime = DateTime.Today
            RellenaGrid(1)
            GenerarToolTip()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Salir_Click(sender As Object, e As EventArgs) Handles Btn_Salir.Click
        Me.Close()
    End Sub

    Private Sub DGrid3_Click(sender As Object, e As EventArgs) Handles DGrid3.Click

    End Sub

    Private Sub Btn_Consultar_Click(sender As Object, e As EventArgs) Handles Btn_Consultar.Click
        Try
            RellenaGrid(2)
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Function evalua_id_consulta(id_consulta As String) As Boolean
        Try
            If id_consulta <> "" Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
            Return False
        End Try
    End Function

    Private Sub DGrid2_DoubleClick(sender As Object, e As EventArgs) Handles DGrid2.DoubleClick
        id_consulta = ""

        Try
            GridView3.Columns.Clear()

            If tipo_cartera = 3 Then 'parametriza para el store la query para cartera vencida, con id 5
                id_consulta = GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "idgestor").ToString()
                If evalua_id_consulta(id_consulta) Then RellenaGrid_DrillDown(5, CInt(id_consulta)) Else Exit Sub
                navegacion_consultas(3, GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "gestor").ToString())
            ElseIf tipo_cartera = 2 Then 'parametriza para el store la query para cartera fresca, con id 2
                id_consulta = GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "id").ToString()
                If evalua_id_consulta(id_consulta) Then RellenaGrid_DrillDown(2, CInt(id_consulta)) Else Exit Sub
                navegacion_consultas(3, IIf(id_consulta = "1", "DISTRIBUIDORES", "TARJETAHABIENTES"))
            ElseIf tipo_cartera = 1 Then 'parametriza para el store la query para cartera vigente, con id 3
                id_consulta = GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "id").ToString()
                If evalua_id_consulta(id_consulta) Then RellenaGrid_DrillDown(3, CInt(id_consulta)) Else Exit Sub
                navegacion_consultas(3, IIf(id_consulta = "1", "DISTRIBUIDORES", "TARJETAHABIENTES"))
            ElseIf tipo_cartera = 4 Then 'parametriza para el store la query para cartera demanda, con id 7
                id_consulta = GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "idabogado").ToString()
                If evalua_id_consulta(id_consulta) Then RellenaGrid_DrillDown(8, CInt(id_consulta)) Else Exit Sub
                navegacion_consultas(3, GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "abogado").ToString())
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Excel.Click
        Try
            If sfdRuta.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                If DGrid.Visible Then
                    DGrid.ExportToXls(sfdRuta.FileName)
                ElseIf DGrid2.Visible Then
                    DGrid2.ExportToXls(sfdRuta.FileName)
                ElseIf DGrid3.Visible Then
                    DGrid3.ExportToXls(sfdRuta.FileName)
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub navegacion_consultas(nivel As Integer, nombre_nivel As String)
        Try
            If nombre_nivel = "" And nivel <> 1 Then
                posicion = lbl_navegacion.Text.IndexOf(" >>> ")
                primeraParte = lbl_navegacion.Text.Substring(0, posicion)
                lbl_navegacion.Text = primeraParte
                Exit Sub
            End If

            If nivel = 1 Then
                lbl_navegacion.Visible = False
                lbl_flechas.Visible = False
            ElseIf nivel = 2 Then
                lbl_navegacion.Text = nombre_nivel
                lbl_navegacion.Visible = True
                lbl_flechas.Visible = True
            ElseIf nivel = 3 Then
                lbl_navegacion.Text = lbl_navegacion.Text + "  >>>  " + nombre_nivel
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_DoubleClick_1(sender As Object, e As EventArgs) Handles DGrid.DoubleClick
        Try
            tipo_cartera = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "id").ToString()
            GridView2.Columns.Clear()

            If tipo_cartera = 3 Then 'cartera vencida
                RellenaGrid_DrillDown(1, 0)
                navegacion_consultas(2, "CARTERA VENCIDA POR GESTOR")
            ElseIf tipo_cartera = 2 Then 'cartera fresca
                RellenaGrid_DrillDown(6, 1)
                navegacion_consultas(2, "CARTERA FRESCA")
            ElseIf tipo_cartera = 1 Then 'cartera vigente
                RellenaGrid_DrillDown(6, 2)
                navegacion_consultas(2, "CARTERA VIGENTE")
            ElseIf tipo_cartera = 4 Then ' cartera demanda
                RellenaGrid_DrillDown(7, 0)
                navegacion_consultas(2, "DEMANDAS")
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Regresar_Click(sender As Object, e As EventArgs) Handles Btn_Regresar.Click
        Try
            If DGrid3.Visible Then
                DGrid2.Visible = True
                DGrid3.Visible = False
                navegacion_consultas(2, "")
            ElseIf DGrid2.Visible Then
                DGrid.Visible = True
                DGrid2.Visible = False
                DEditHasta.Enabled = True
                Btn_Consultar.Enabled = True
                navegacion_consultas(1, "")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub
End Class