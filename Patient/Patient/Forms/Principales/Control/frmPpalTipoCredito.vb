Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid
Public Class frmPpalTipoCredito
    'vgallegos 19/Enero/2018 05:33 pm


    Private objDataSet As Data.DataSet
    Private objDataSetEmp As Data.DataSet
    Dim idTipoCredito As Integer = 0
    Dim Opcion As Integer = 0
    Dim idUsuario As Integer = 0
    Dim Sucursal As String = ""
    '---------------------------------
    Dim tipocredito As String = ""
    Dim idperiodicidad As Integer = 0
    Dim fechalimpago1 As Integer = 0
    Dim fechalimpago2 As Integer = 0
    Dim diacorte1 As Integer = 0
    Dim diacorte2 As Integer = 0
    Dim carterafresco As Integer = 0
    Dim gastofresco As Integer = 0
    Dim interesfresco As Integer = 0
    Dim carteravencido As Integer = 0
    Dim gastovencido As Integer = 0
    Dim interesvencido As Integer = 0
    Dim gastodemanda As Integer = 0
    Dim observaciones As String = 0
    Dim idusuariomodif As Integer = 0
    Dim bln_validarIdTipoCredito As Boolean = False



    Dim Sw_Load As Boolean = True
    Dim Sw_NoRegistros As Boolean = False


    Private Sub RellenaGrid()

        Using objTrasp As New BCL.BCLTipoCredito(GLB_ConStringSircoControlSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                DGrid.DataSource = Nothing
                Opcion = 3
                '--Acción es igual a 3---------------
                objDataSet = objTrasp.usp_TraerTipoCredito(Opcion, idTipoCredito, tipocredito, idperiodicidad, fechalimpago1, fechalimpago2, diacorte1, diacorte2,
                                                            carterafresco, gastofresco, interesfresco, carteravencido, gastovencido, interesvencido, gastodemanda,
                                                            observaciones, idUsuario, idusuariomodif)
                If objDataSet.Tables(0).Rows.Count > 0 Then

                    Btn_Editar.Enabled = True
                    DGrid.DataSource = objDataSet.Tables(0)
                    InicializaGrid()
                    GridView1.BestFitColumns()

                    Me.Cursor = Cursors.Default
                Else
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron registros que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Editar.Enabled = False
                End If

                Me.Cursor = Cursors.Default

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub



    Private Sub frmPpalTipoCredito_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RellenaGrid()
    End Sub

    Sub InicializaGrid()
        Try
            '            idTipoCredito,
            'tipocredito,
            'idperiodicidad,
            'fechalimpago1,
            'fechalimpago2,
            'diacorte1,
            'diacorte2,
            'carterafresco,
            'gastofresco,
            'interesfresco,
            'carteravencido,
            'gastovencido,
            'interesvencido,
            'gastodemanda,
            'observaciones 
            GridView1.Columns("idtipocredito").Caption = "IdTipoCredito"
            GridView1.Columns("tipocredito").Caption = "Tipo de crédito"
            GridView1.Columns("idperiodicidad").Caption = "Id Periodicidad"
            GridView1.Columns("periodicidad").Caption = "Periodicidad"
            GridView1.Columns("fechalimpago1").Caption = "Fecha limite de pago inicial"
            GridView1.Columns("fechalimpago2").Caption = "Fecha limite de pago final"
            GridView1.Columns("diacorte1").Caption = "Día de corte inicial"
            GridView1.Columns("diacorte2").Caption = "Día de corte final"
            GridView1.Columns("carterafresco").Caption = "Cartera Fresca"
            GridView1.Columns("gastofresco").Caption = "Gasto de cobranza de cartera fresca"
            GridView1.Columns("interesfresco").Caption = "Interés de cartera Fresca"
            GridView1.Columns("carteravencido").Caption = "Cartera vencida"
            GridView1.Columns("gastovencido").Caption = "Gasto de cobrabnza de cartera vencida"
            GridView1.Columns("interesvencido").Caption = "Interés de cartera vencida"
            GridView1.Columns("gastodemanda").Caption = "Gasto de cobranza demanda"
            GridView1.Columns("observaciones").Caption = "Observaciones"



            GridView1.OptionsView.ColumnAutoWidth = False

            GridView1.Columns("idtipocredito").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns("tipocredito").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns("periodicidad").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns("fechalimpago1").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns("fechalimpago2").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns("diacorte1").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns("diacorte2").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns("carterafresco").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns("gastofresco").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns("interesfresco").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns("carteravencido").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns("gastovencido").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns("interesvencido").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns("gastodemanda").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns("observaciones").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            For I As Integer = 0 To GridView1.Columns.Count - 1

                GridView1.Columns(I).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns(I).AppearanceHeader.Font = New Font(GridView1.Columns(I).AppearanceCell.Font, FontStyle.Bold)
                GridView1.Columns(I).OptionsColumn.ReadOnly = True

            Next


            GridView1.Columns("idtipocredito").Visible = False
            GridView1.Columns("idperiodicidad").Visible = False
            GridView1.Columns("fechalimpago1").Visible = False
            GridView1.Columns("fechalimpago2").Visible = False
            GridView1.Columns("diacorte1").Visible = False
            GridView1.Columns("diacorte2").Visible = False
            GridView1.Columns("carterafresco").Visible = False
            GridView1.Columns("gastofresco").Visible = False
            GridView1.Columns("interesfresco").Visible = False
            GridView1.Columns("carteravencido").Visible = False
            GridView1.Columns("gastovencido").Visible = False
            GridView1.Columns("interesvencido").Visible = False
            GridView1.Columns("gastodemanda").Visible = False







            GridView1.BestFitColumns()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub




    Private Sub Btn_Nuevo_Click_1(sender As Object, e As EventArgs) Handles Btn_Nuevo.Click
        Try
            Opcion = 1
            Dim myForm As New frmCatalogoTipoCredito
            myForm.Accion = Opcion
            myForm.Text = myForm.Text + "(Nuevo tipo de Crédito)"
            myForm.ShowDialog()

            'If (GLB_RefrescarPedido) Then
            Call RellenaGrid()
            'Call InicializaGrid()

            'End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Editar_Click_1(sender As Object, e As EventArgs) Handles Btn_Editar.Click
        Try
            Dim myForm As New frmCatalogoTipoCredito
            myForm.Accion = 2
            myForm.Text = myForm.Text + " (Editar tipo de Crédito)"

            Dim Renglon As Integer = 0
            Dim intposicion As Integer = 0
            Dim inttotalrows As Integer = 0
            Dim idtipocredito As Integer = 0
            Dim tipo As String = ""
            Dim Observaciones As String = ""

            For i As Integer = 0 To GridView1.RowCount - 1


                If GridView1.IsRowSelected(i) = True Then
                    idtipocredito = GridView1.GetRowCellValue(i, "idtipocredito")
                    tipocredito = GridView1.GetRowCellValue(i, "tipocredito")
                    idperiodicidad = GridView1.GetRowCellValue(i, "idperiodicidad")
                    fechalimpago1 = GridView1.GetRowCellValue(i, "fechalimpago1")
                    fechalimpago2 = GridView1.GetRowCellValue(i, "fechalimpago2")
                    diacorte1 = GridView1.GetRowCellValue(i, "diacorte1")
                    diacorte2 = GridView1.GetRowCellValue(i, "diacorte2")
                    carterafresco = GridView1.GetRowCellValue(i, "carterafresco")
                    gastofresco = GridView1.GetRowCellValue(i, "gastofresco")
                    interesfresco = GridView1.GetRowCellValue(i, "interesfresco")
                    carteravencido = GridView1.GetRowCellValue(i, "carteravencido")
                    gastovencido = GridView1.GetRowCellValue(i, "gastovencido")
                    interesvencido = GridView1.GetRowCellValue(i, "interesvencido")
                    gastodemanda = GridView1.GetRowCellValue(i, "gastodemanda")
                    Observaciones = GridView1.GetRowCellValue(i, "observaciones")
                End If
            Next

            myForm.getRow(idtipocredito)
            myForm.Txt_Tipo.Text = tipocredito
            myForm.Txt_FechaLimPag1.Text = fechalimpago1
            myForm.Txt_FechaLimPag2.Text = fechalimpago2
            myForm.Cmb_Periodicidad.EditValue = idperiodicidad
            myForm.Txt_DiaCorte1.Text = diacorte1
            myForm.Txt_DiaCorte2.Text = diacorte2
            myForm.Txt_CarteraFresca.Text = carterafresco
            myForm.Txt_GastoCarteraFresca.Text = gastofresco
            myForm.Txt_InteresCarteraFresca.Text = interesfresco
            myForm.Txt_CarteraVencida.Text = carteravencido
            myForm.Txt_GastoCarteraVencida.Text = gastovencido
            myForm.Txt_InteresCarteraVencida.Text = interesvencido
            myForm.Txt_GastoDemanda.Text = gastodemanda
            myForm.Txt_Observaciones.Text = Observaciones
            myForm.ShowDialog()
            Call InicializaGrid()
            Call RellenaGrid()

        Catch ExceptionErr As Exception
            MessageBox.Show("Seleccione un tipo de crédito porfavor, " & ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Excel_Click_1(sender As Object, e As EventArgs) Handles Btn_Excel.Click
        If sfdRuta.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            DGrid.ExportToXls(sfdRuta.FileName)
        End If
    End Sub

    Private Sub Btn_Salir_Click_1(sender As Object, e As EventArgs) Handles Btn_Salir.Click
        Me.Close()
    End Sub

    Private Sub DGrid_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DGrid_DoubleClick(sender As Object, e As EventArgs) Handles DGrid.DoubleClick
        Try
            Dim myForm As New frmCatalogoTipoCredito
            myForm.Accion = 3
            myForm.Text = myForm.Text + " (Consultar tipo de Crédito)"

            Dim Renglon As Point = DGrid.PointToClient(Control.MousePosition)
            Dim info As GridHitInfo = GridView1.CalcHitInfo(Renglon)
            Dim Renglon1 As Integer = info.RowHandle
            Dim idtipocredito As Integer = 0


            idtipocredito = GridView1.GetRowCellValue(Renglon1, "idtipocredito")
            tipocredito = GridView1.GetRowCellValue(Renglon1, "tipocredito")
            idperiodicidad = GridView1.GetRowCellValue(Renglon1, "idperiodicidad")
            fechalimpago1 = GridView1.GetRowCellValue(Renglon1, "fechalimpago1")
            fechalimpago2 = GridView1.GetRowCellValue(Renglon1, "fechalimpago2")
            diacorte1 = GridView1.GetRowCellValue(Renglon1, "diacorte1")
            diacorte2 = GridView1.GetRowCellValue(Renglon1, "diacorte2")
            carterafresco = GridView1.GetRowCellValue(Renglon1, "carterafresco")
            gastofresco = GridView1.GetRowCellValue(Renglon1, "gastofresco")
            interesfresco = GridView1.GetRowCellValue(Renglon1, "interesfresco")
            carteravencido = GridView1.GetRowCellValue(Renglon1, "carteravencido")
            gastovencido = GridView1.GetRowCellValue(Renglon1, "gastovencido")
            interesvencido = GridView1.GetRowCellValue(Renglon1, "interesvencido")
            gastodemanda = GridView1.GetRowCellValue(Renglon1, "gastodemanda")
            observaciones = GridView1.GetRowCellValue(Renglon1, "observaciones")

            ''-- Asignar valores----------------------
            myForm.getRow(idtipocredito)
            myForm.Txt_Tipo.Text = tipocredito
            myForm.Txt_FechaLimPag1.Text = fechalimpago1
            myForm.Txt_FechaLimPag2.Text = fechalimpago2
            myForm.Cmb_Periodicidad.EditValue = idperiodicidad
            myForm.Txt_DiaCorte1.Text = diacorte1
            myForm.Txt_DiaCorte2.Text = diacorte2
            myForm.Txt_CarteraFresca.Text = carterafresco
            myForm.Txt_GastoCarteraFresca.Text = gastofresco
            myForm.Txt_InteresCarteraFresca.Text = interesfresco
            myForm.Txt_CarteraVencida.Text = carteravencido
            myForm.Txt_GastoCarteraVencida.Text = gastovencido
            myForm.Txt_InteresCarteraVencida.Text = interesvencido
            myForm.Txt_GastoDemanda.Text = gastodemanda
            myForm.Txt_Observaciones.Text = observaciones

            ''-------------------------------------------
            myForm.Pnl_Ppal.Enabled = False
            myForm.Pnl_Fresca.Enabled = False
            myForm.Pnl_Vencida.Enabled = False
            myForm.Pnl_Abogado.Enabled = False
            myForm.Pnl_Obs.Enabled = False
            myForm.Btn_Aceptar.Enabled = False

            myForm.ShowDialog()
            Call InicializaGrid()
            Call RellenaGrid()




        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)

        End Try
    End Sub

    Private Sub Btn_Consultar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Btn_Consultar_Click_1(sender As Object, e As EventArgs) Handles Btn_Consultar.Click
        Try
            Dim myForm As New frmCatalogoTipoCredito
            myForm.Accion = 3
            myForm.Text = myForm.Text + " (Consultar tipo de Crédito)"

            Dim Renglon As Integer = 0
            Dim intposicion As Integer = 0
            Dim inttotalrows As Integer = 0
            Dim idtipocredito As Integer = 0
            Dim tipo As String = ""
            Dim Observaciones As String = ""

            For i As Integer = 0 To GridView1.RowCount - 1


                If GridView1.IsRowSelected(i) = True Then
                    idtipocredito = GridView1.GetRowCellValue(i, "idtipocredito")
                    tipocredito = GridView1.GetRowCellValue(i, "tipocredito")
                    idperiodicidad = GridView1.GetRowCellValue(i, "idperiodicidad")
                    fechalimpago1 = GridView1.GetRowCellValue(i, "fechalimpago1")
                    fechalimpago2 = GridView1.GetRowCellValue(i, "fechalimpago2")
                    diacorte1 = GridView1.GetRowCellValue(i, "diacorte1")
                    diacorte2 = GridView1.GetRowCellValue(i, "diacorte2")
                    carterafresco = GridView1.GetRowCellValue(i, "carterafresco")
                    gastofresco = GridView1.GetRowCellValue(i, "gastofresco")
                    interesfresco = GridView1.GetRowCellValue(i, "interesfresco")
                    carteravencido = GridView1.GetRowCellValue(i, "carteravencido")
                    gastovencido = GridView1.GetRowCellValue(i, "gastovencido")
                    interesvencido = GridView1.GetRowCellValue(i, "interesvencido")
                    gastodemanda = GridView1.GetRowCellValue(i, "gastodemanda")
                    Observaciones = GridView1.GetRowCellValue(i, "observaciones")
                End If
            Next
            ''-- Asignar valores----------------------
            myForm.getRow(idtipocredito)
            myForm.Txt_Tipo.Text = tipocredito
            myForm.Txt_FechaLimPag1.Text = fechalimpago1
            myForm.Txt_FechaLimPag2.Text = fechalimpago2
            myForm.Cmb_Periodicidad.EditValue = idperiodicidad
            myForm.Txt_DiaCorte1.Text = diacorte1
            myForm.Txt_DiaCorte2.Text = diacorte2
            myForm.Txt_CarteraFresca.Text = carterafresco
            myForm.Txt_GastoCarteraFresca.Text = gastofresco
            myForm.Txt_InteresCarteraFresca.Text = interesfresco
            myForm.Txt_CarteraVencida.Text = carteravencido
            myForm.Txt_GastoCarteraVencida.Text = gastovencido
            myForm.Txt_InteresCarteraVencida.Text = interesvencido
            myForm.Txt_GastoDemanda.Text = gastodemanda
            myForm.Txt_Observaciones.Text = Observaciones
            ''-------------------------------------------

            myForm.Pnl_Ppal.Enabled = False
            myForm.Pnl_Fresca.Enabled = False
            myForm.Pnl_Vencida.Enabled = False
            myForm.Pnl_Abogado.Enabled = False
            myForm.Pnl_Obs.Enabled = False
            myForm.Btn_Aceptar.Enabled = False


            myForm.ShowDialog()
            Call InicializaGrid()
            Call RellenaGrid()

        Catch ExceptionErr As Exception
            MessageBox.Show("Seleccione un tipo de crédito porfavor, " & ExceptionErr.Message.ToString)
        End Try
    End Sub
End Class