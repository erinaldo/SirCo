Public Class frmCorteCredito

#Region "VARIABLES"
    Public blnAceptar As Boolean = False
    Dim objDataSet As New DataSet
    Dim Fecha As Date
    Dim idUsuario As Integer
    Dim NuevoDia As Boolean = False
#End Region

#Region "EVENTOS"

#Region "FORMA"

    Private Sub frmCorteCajaCredito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Fecha = GLB_FechaHoy
            idUsuario = 0
            DT_Fecha.MaxDate = GLB_FechaHoy
            'InicializaGrid(1)
            'RellenaGrid()

            GenerarHojaEntrega()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub frmCajaCredito_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub DT_Fecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DT_Fecha.ValueChanged
        Try
            Fecha = DT_Fecha.Value
            Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                objDataSet = objCajaCredito.usp_TraerInfoCorte(1, Fecha, 0)
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                cb_Cajero.Enabled = True
                NuevoDia = False
                cb_Cajero.DataSource = objDataSet.Tables(0)
                cb_Cajero.DisplayMember = "nombre"
                cb_Cajero.ValueMember = "idusuario"
                idUsuario = CInt(objDataSet.Tables(0).Rows(0).Item("idusuario").ToString)
                RellenaGrid()
                NuevoDia = True
            Else
                NuevoDia = False
                cb_Cajero.DataSource = Nothing
                cb_Cajero.Enabled = False
                idUsuario = 0
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub cb_Cajero_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_Cajero.SelectedIndexChanged
        Try
            If NuevoDia = False Then Exit Sub
            idUsuario = cb_Cajero.SelectedValue
            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

#End Region

#Region "DGRID"


#End Region

#Region "BOTON"

    Private Sub btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancelar.Click
        Try
            blnAceptar = False
            Me.Close()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Aceptar.Click
        Try
            
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

#End Region

#End Region

#Region "METODOS"


    Private Sub RellenaGrid()
        Try
            Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                objDataSet = objCajaCredito.usp_TraerInfoCorte(2, Fecha, idUsuario)
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                DGridCobrado.DataSource = objDataSet.Tables(0)
                InicializaGrid(1)
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub InicializaGrid(ByVal Opcion As Integer)
        Try
            If Opcion = 1 Then
                DGridCobrado.Columns("formapago").HeaderText = "FormaPago"
                DGridCobrado.Columns("descripcion").HeaderText = "Forma Pago"
                DGridCobrado.Columns("cobrado").HeaderText = "Cobrado"
                DGridCobrado.Columns("recibido").HeaderText = "Recibido"
                DGridCobrado.Columns("desviacion").HeaderText = "Desviación"
                DGridCobrado.Columns("formapago").Visible = False
                DGridCobrado.Columns("cobrado").DefaultCellStyle.Format = "c"
                DGridCobrado.Columns("recibido").DefaultCellStyle.Format = "c"
                DGridCobrado.Columns("desviacion").DefaultCellStyle.Format = "c"
                DGridCobrado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                DGridCobrado.Columns("cobrado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGridCobrado.Columns("recibido").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGridCobrado.Columns("desviacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                For i As Integer = 0 To DGridCobrado.RowCount - 1
                    If CDbl(DGridCobrado.Rows(i).Cells("desviacion").Value) = 0 Then
                        DGridCobrado.Rows(i).Cells("desviacion").Style.BackColor = Color.GreenYellow
                    ElseIf CDbl(DGridCobrado.Rows(i).Cells("desviacion").Value) > 0 Then
                        DGridCobrado.Rows(i).Cells("desviacion").Style.BackColor = Color.Yellow
                    Else
                        DGridCobrado.Rows(i).Cells("desviacion").Style.BackColor = Color.Red
                    End If
                Next
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub




    Private Sub ImprimirHojaEntrega()

        Try
            Dim myForm As New frmReportsBrowser
            myForm.objDataSetHojaEntrega = GenerarHojaEntrega()

            myForm.ReportIndex = 111111

            myForm.Show()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Function GenerarHojaEntrega() As DSEntregaCredito
        'Roberto 04/03/13
        Try

            Dim Columna As Integer = 0
            Dim Cont As Integer = 0
            GenerarHojaEntrega = New DSEntregaCredito

            With DGridCobrado

                Dim objDataRow As Data.DataRow = GenerarHojaEntrega.Tables("DTEfectivo").NewRow()
                objDataRow.Item("_1000") = If(.Rows(0).Cells(2).Value Is Nothing, 0, .Rows(0).Cells(2).Value)
                objDataRow.Item("_500") = If(.Rows(1).Cells(2).Value Is Nothing, 0, .Rows(1).Cells(2).Value)
                objDataRow.Item("_200") = If(.Rows(2).Cells(2).Value Is Nothing, 0, .Rows(2).Cells(2).Value)
                objDataRow.Item("_100") = If(.Rows(3).Cells(2).Value Is Nothing, 0, .Rows(3).Cells(2).Value)
                objDataRow.Item("_50") = If(.Rows(4).Cells(2).Value Is Nothing, 0, .Rows(4).Cells(2).Value)
                objDataRow.Item("_20") = If(.Rows(5).Cells(2).Value Is Nothing, 0, .Rows(5).Cells(2).Value)
                objDataRow.Item("_10") = If(.Rows(6).Cells(2).Value Is Nothing, 0, .Rows(6).Cells(2).Value)
                objDataRow.Item("_5") = If(.Rows(7).Cells(2).Value Is Nothing, 0, .Rows(7).Cells(2).Value)
                objDataRow.Item("_2") = If(.Rows(8).Cells(2).Value Is Nothing, 0, .Rows(8).Cells(2).Value)
                objDataRow.Item("_1") = If(.Rows(9).Cells(2).Value Is Nothing, 0, .Rows(9).Cells(2).Value)
                objDataRow.Item("_50c") = If(.Rows(10).Cells(2).Value Is Nothing, 0, .Rows(10).Cells(2).Value)
                objDataRow.Item("_20c") = If(.Rows(11).Cells(2).Value Is Nothing, 0, .Rows(11).Cells(2).Value)
                objDataRow.Item("_10c") = If(.Rows(12).Cells(2).Value Is Nothing, 0, .Rows(12).Cells(2).Value)
                GenerarHojaEntrega.Tables("DTEfectivo").Rows.Add(objDataRow)

            End With

           



            Dim objDataRowNombre As Data.DataRow
            objDataRowNombre = GenerarHojaEntrega.Tables("DTNombres").NewRow()
            objDataRowNombre.Item("cajero") = GLB_NomUsuario
            GenerarHojaEntrega.Tables("DTNombres").Rows.Add(objDataRowNombre)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function


#End Region

End Class