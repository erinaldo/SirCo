Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class frmPromocionesDet
    Sub New()

        InitializeComponent()
    End Sub

    Public IdPromocion As Integer
    Public NomPromocion As String
    Public TipoPromo As String
    Public NumUnidad As String
    Public Tipo As String
    Public Accion As Integer

#Region "Metodos"

    Private Sub TraerInfoAgrupacion()
        Dim objDataSet As DataSet
        Using objPromocion As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
            objDataSet = objPromocion.usp_TraerPromocionAgrupacion(IdPromocion)
        End Using
        If objDataSet.Tables(0).Rows.Count = 0 Then
            MessageBox.Show("No se encontro la información", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        txt_IdPromocion.Text = IdPromocion
        txt_NombrePromocion.Text = NomPromocion
        txt_TipoPromo.Text = TipoPromo
        txt_Usuario.Text = objDataSet.Tables(0).Rows(0).Item("idusuario").ToString.Trim
        txt_Fum.Text = objDataSet.Tables(0).Rows(0).Item("fum").ToString.Trim
        'txt_AgrupacionCompra.Text = objDataSet.Tables(0).Rows(0).Item("idagrupacioncompra").ToString.Trim
        'txt_NomAgruCompra.Text = objDataSet.Tables(0).Rows(0).Item("agrupacioncompra").ToString.Trim
        'txt_UniMin.Text = CInt(objDataSet.Tables(0).Rows(0).Item("minunicompra").ToString.Trim)
        'txt_ImpMinimo.Text = objDataSet.Tables(0).Rows(0).Item("minimpcompra").ToString.Trim
        'txt_AgrupacionPromo.Text = objDataSet.Tables(0).Rows(0).Item("idagrupacionpromo").ToString.Trim
        'txt_NomAgruPromo.Text = objDataSet.Tables(0).Rows(0).Item("agrupacionpromo").ToString.Trim
        'txt_UniPromo.Text = objDataSet.Tables(0).Rows(0).Item("unipromo").ToString.Trim
        'gc_Agrupaciones.DataSource = TraerPromocionDet(0, "AGRUPADO", "").Tables(0)
        'InicializaGridAgrupaciones()
    End Sub

    'Private Sub InicializaGridAgrupaciones()
    '    dgv_Agrupaciones.Columns("idpromocion").Visible = False
    '    dgv_Agrupaciones.Columns("idagrupacion").Visible = False
    '    dgv_Agrupaciones.Columns("renglon").Visible = False

    '    dgv_Agrupaciones.Columns("agrupacion").Caption = "Agrupación"
    '    dgv_Agrupaciones.Columns("numunidad").Caption = "Num Unidad"
    '    dgv_Agrupaciones.Columns("tipo").Caption = "Tipo"
    'End Sub

    Private Function TraerPromocionDet(Unidad As Integer, Tipo As String, FormaPago As String) As DataSet
        Dim objDataSet As DataSet
        Using objPromocion As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
            objDataSet = objPromocion.usp_TraerPromocionDet(IdPromocion, Unidad, Tipo, FormaPago)
        End Using
        TraerPromocionDet = objDataSet
    End Function

    Private Sub TraerInfoPromocion()
        Dim objDataSet As DataSet
        Dim objDataSetPro As DataSet
        objDataSet = TraerPromocionDet(NumUnidad, "DESGLOSADO", "")
        objDataSetPro = GeneraDataSetFP()
        If objDataSet.Tables(0).Rows.Count = 0 Then
            'SE QUEDA EL GRID CON DATOS EN BLANCO
            Exit Sub
        End If
        For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
            For j As Integer = 0 To objDataSetPro.Tables(0).Rows.Count - 1
                If objDataSet.Tables(0).Rows(i).Item("formapago").ToString.Trim = objDataSetPro.Tables(0).Rows(j).Item("fp").ToString.Trim Then
                    objDataSetPro.Tables(0).Rows(j).Item("impfijo") = objDataSet.Tables(0).Rows(i).Item("impfijo").ToString.Trim
                    objDataSetPro.Tables(0).Rows(j).Item("PorcDesc") = objDataSet.Tables(0).Rows(i).Item("descdirecto").ToString.Trim
                    objDataSetPro.Tables(0).Rows(j).Item("PorcDE") = objDataSet.Tables(0).Rows(i).Item("porcdinelec").ToString.Trim
                    objDataSetPro.Tables(0).Rows(j).Item("Bono") = objDataSet.Tables(0).Rows(i).Item("impbono").ToString.Trim
                    Exit For
                End If
            Next
        Next
        gc_PromocionesDet.DataSource = objDataSetPro.Tables(0)

        Using objPromocion As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
            objDataSet = objPromocion.usp_TraerUsuFumPromocionesDet(IdPromocion)
        End Using
        If objDataSet.Tables(0).Rows.Count > 0 Then
            txt_Usuario.Text = objDataSet.Tables(0).Rows(0).Item("idusuario").ToString.Trim
            txt_Fum.Text = objDataSet.Tables(0).Rows(0).Item("fum").ToString.Trim
        End If
    End Sub

    Private Function GeneraDataSetFP() As DataSet
        Dim objDataSet As New DataSet
        objDataSet.Tables.Add()
        objDataSet.Tables(0).Columns.Add("fp", Type.GetType("System.String"))
        objDataSet.Tables(0).Columns.Add("formapago", Type.GetType("System.String"))
        objDataSet.Tables(0).Columns.Add("ImpFijo", Type.GetType("System.Double"))
        objDataSet.Tables(0).Columns.Add("PorcDesc", Type.GetType("System.Double"))
        objDataSet.Tables(0).Columns.Add("PorcDE", Type.GetType("System.Double"))
        objDataSet.Tables(0).Columns.Add("Bono", Type.GetType("System.Double"))
        objDataSet.Tables(0).Rows.Add("TO", "TODAS", 0.00, 0.00, 0.00, 0.00)
        objDataSet.Tables(0).Rows.Add("EF", "EFECTIVO", 0.00, 0.00, 0.00, 0.00)
        objDataSet.Tables(0).Rows.Add("TD", "TARJETA DE DÉBITO", 0.00, 0.00, 0.00, 0.00)
        objDataSet.Tables(0).Rows.Add("TC", "TARJETA DE CRÉDITO", 0.00, 0.00, 0.00, 0.00)
        objDataSet.Tables(0).Rows.Add("MD", "MONEDERO ELECTRÓNICO", 0.00, 0.00, 0.00, 0.00)
        objDataSet.Tables(0).Rows.Add("DV", "DEVOLUCIÓN", 0.00, 0.00, 0.00, 0.00)
        objDataSet.Tables(0).Rows.Add("DP", "DEVOLUCIÓN DE PROMOCIÓN", 0.00, 0.00, 0.00, 0.00)
        objDataSet.Tables(0).Rows.Add("VA", "VALE CON PROMOCIÓN", 0.00, 0.00, 0.00, 0.00)
        objDataSet.Tables(0).Rows.Add("VS", "VALE SIN PROMOCIÓN", 0.00, 0.00, 0.00, 0.00)
        objDataSet.Tables(0).Rows.Add("CV", "CONTRAVALE CON PROMOCIÓN", 0.00, 0.00, 0.00, 0.00)
        objDataSet.Tables(0).Rows.Add("CS", "CONTRAVALE SIN PROMOCIÓN", 0.00, 0.00, 0.00, 0.00)
        objDataSet.Tables(0).Rows.Add("CP", "CRÉDITO VALE", 0.00, 0.00, 0.00, 0.00)
        GeneraDataSetFP = objDataSet
    End Function
#End Region

#Region "Eventos"
    Private Sub frmPromocionesDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If Accion = 3 Then
                btn_GuardaPromocionesDet.Enabled = False
                dgv_PromocionesDet.OptionsBehavior.Editable = False
            End If
            TraerInfoPromocion()
            txt_IdPromocion.Text = IdPromocion
            txt_NombrePromocion.Text = NomPromocion
            txt_TipoPromo.Text = TipoPromo
            txt_NumUnidad.Text = NumUnidad
            txt_TipoUni.Text = Tipo
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_GuardaPromocionesDet_Click(sender As Object, e As EventArgs) Handles btn_GuardaPromocionesDet.Click
        Try
            Dim objDataSet As DataSet
            Dim blnTransaccion As Boolean
            Dim ImpFijo, PorcDesc, PorcDinElec, ImpBono As Decimal
            Dim Fp As String
            Using objPromocion As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
                For i As Integer = 0 To dgv_PromocionesDet.RowCount - 1
                    ImpFijo = CDec(dgv_PromocionesDet.GetRowCellValue(i, "ImpFijo").ToString.Trim)
                    PorcDesc = CDec(dgv_PromocionesDet.GetRowCellValue(i, "PorcDesc").ToString.Trim)
                    PorcDinElec = CDec(dgv_PromocionesDet.GetRowCellValue(i, "PorcDE").ToString.Trim)
                    ImpBono = CDec(dgv_PromocionesDet.GetRowCellValue(i, "Bono").ToString.Trim)
                    Fp = dgv_PromocionesDet.GetRowCellValue(i, "fp").ToString.Trim
                    objDataSet = objPromocion.usp_TraerPromocionDet(IdPromocion, NumUnidad, "DESGLOSADO", Fp)
                    If objDataSet.Tables(0).Rows.Count = 0 Then
                        If ImpFijo <> 0 Or PorcDesc <> 0 Or PorcDinElec <> 0 Or ImpBono <> 0 Then
                            Using objPromocionCaptura As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
                                blnTransaccion = objPromocionCaptura.usp_CapturaPromocionDet(IdPromocion, Fp, NumUnidad, Tipo, ImpFijo, PorcDesc, PorcDinElec, ImpBono, GLB_Usuario)
                            End Using
                        End If
                    Else
                        Using objPromocionModifica As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
                            blnTransaccion = objPromocionModifica.usp_ModificaPromocionDet(IdPromocion, Fp, NumUnidad, Tipo, ImpFijo, PorcDesc, PorcDinElec, ImpBono, GLB_Usuario)
                        End Using
                    End If
                Next
            End Using
            MessageBox.Show("Información almacenada correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Salir_Click(sender As Object, e As EventArgs) Handles btn_Salir.Click
        Me.Close()
    End Sub

    Private Sub Form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub dgv_PromocionesDet_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles dgv_PromocionesDet.ValidatingEditor
        Try
            Dim view As ColumnView = sender
            Dim column As GridColumn = If(TryCast(e, EditFormValidateEditorEventArgs)?.Column, view.FocusedColumn)
            If column.Name = "gc_PorcDirecto" Then
                If (Convert.ToInt32(e.Value) < 0) Or (Convert.ToInt32(e.Value) > 100) Then
                    e.Valid = False
                End If
            End If
            If column.Name = "gc_PorcDE" Then
                If (Convert.ToInt32(e.Value) < 0) Or (Convert.ToInt32(e.Value) > 100) Then
                    e.Valid = False
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

#End Region
End Class