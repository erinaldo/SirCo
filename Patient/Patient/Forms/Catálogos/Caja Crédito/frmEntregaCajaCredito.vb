Public Class frmEntregaCajaCredito

#Region "VARIABLES"
    Public blnAceptar As Boolean = False
    Dim objDataSet As New DataSet
    Dim Efec As Double = 0
    Dim TC As Double = 0
    Dim Act As Double = 0
    Dim Tot As Double = 0
#End Region

#Region "EVENTOS"

#Region "FORMA"

    Private Sub frmCorteCajaCredito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            DGridFormasPagoEfe.Columns("col_formapago").ReadOnly = True
            DGridFormasPagoEfe.Rows.Add()
            DGridFormasPagoEfe.Rows(0).Cells("col_formapago").Value = "EFECTIVO"
            DGridFormasPagoEfe.Rows(0).Cells("col_importe").Value = "$1000"
            DGridFormasPagoEfe.Rows(0).Cells("col_importe").ReadOnly = True
            DGridFormasPagoEfe.Rows.Add()
            DGridFormasPagoEfe.Rows(1).Cells("col_formapago").Value = "EFECTIVO"
            DGridFormasPagoEfe.Rows(1).Cells("col_importe").Value = "$500"
            DGridFormasPagoEfe.Rows(1).Cells("col_importe").ReadOnly = True
            DGridFormasPagoEfe.Rows.Add()
            DGridFormasPagoEfe.Rows(2).Cells("col_formapago").Value = "EFECTIVO"
            DGridFormasPagoEfe.Rows(2).Cells("col_importe").Value = "$200"
            DGridFormasPagoEfe.Rows(2).Cells("col_importe").ReadOnly = True
            DGridFormasPagoEfe.Rows.Add()
            DGridFormasPagoEfe.Rows(3).Cells("col_formapago").Value = "EFECTIVO"
            DGridFormasPagoEfe.Rows(3).Cells("col_importe").Value = "$100"
            DGridFormasPagoEfe.Rows(3).Cells("col_importe").ReadOnly = True
            DGridFormasPagoEfe.Rows.Add()
            DGridFormasPagoEfe.Rows(4).Cells("col_formapago").Value = "EFECTIVO"
            DGridFormasPagoEfe.Rows(4).Cells("col_importe").Value = "$50"
            DGridFormasPagoEfe.Rows(4).Cells("col_importe").ReadOnly = True
            DGridFormasPagoEfe.Rows.Add()
            DGridFormasPagoEfe.Rows(5).Cells("col_formapago").Value = "EFECTIVO"
            DGridFormasPagoEfe.Rows(5).Cells("col_importe").Value = "$20"
            DGridFormasPagoEfe.Rows(5).Cells("col_importe").ReadOnly = True
            DGridFormasPagoEfe.Rows.Add()
            DGridFormasPagoEfe.Rows(6).Cells("col_formapago").Value = "EFECTIVO"
            DGridFormasPagoEfe.Rows(6).Cells("col_importe").Value = "$10"
            DGridFormasPagoEfe.Rows(6).Cells("col_importe").ReadOnly = True
            DGridFormasPagoEfe.Rows.Add()
            DGridFormasPagoEfe.Rows(7).Cells("col_formapago").Value = "EFECTIVO"
            DGridFormasPagoEfe.Rows(7).Cells("col_importe").Value = "$5"
            DGridFormasPagoEfe.Rows(7).Cells("col_importe").ReadOnly = True
            DGridFormasPagoEfe.Rows.Add()
            DGridFormasPagoEfe.Rows(8).Cells("col_formapago").Value = "EFECTIVO"
            DGridFormasPagoEfe.Rows(8).Cells("col_importe").Value = "$2"
            DGridFormasPagoEfe.Rows(8).Cells("col_importe").ReadOnly = True
            DGridFormasPagoEfe.Rows.Add()
            DGridFormasPagoEfe.Rows(9).Cells("col_formapago").Value = "EFECTIVO"
            DGridFormasPagoEfe.Rows(9).Cells("col_importe").Value = "$1"
            DGridFormasPagoEfe.Rows(9).Cells("col_importe").ReadOnly = True
            DGridFormasPagoEfe.Rows.Add()
            DGridFormasPagoEfe.Rows(10).Cells("col_formapago").Value = "EFECTIVO"
            DGridFormasPagoEfe.Rows(10).Cells("col_importe").Value = "$.50"
            DGridFormasPagoEfe.Rows(10).Cells("col_importe").ReadOnly = True
            DGridFormasPagoEfe.Rows.Add()
            DGridFormasPagoEfe.Rows(11).Cells("col_formapago").Value = "EFECTIVO"
            DGridFormasPagoEfe.Rows(11).Cells("col_importe").Value = "$.20"
            DGridFormasPagoEfe.Rows(11).Cells("col_importe").ReadOnly = True
            DGridFormasPagoEfe.Rows.Add()
            DGridFormasPagoEfe.Rows(12).Cells("col_formapago").Value = "EFECTIVO"
            DGridFormasPagoEfe.Rows(12).Cells("col_importe").Value = "$.10"
            DGridFormasPagoEfe.Rows(12).Cells("col_importe").ReadOnly = True
            DGridFormasPagoEfe.Columns("col_formapago").Visible = False

            DGridFormasPagoTarChe.Rows.Add()
            DGridFormasPagoTarChe.Rows(0).Cells("col_formapagoTarChe").Value = "TARJ. CRÉDITO"
            DGridFormasPagoTarChe.Rows.Add()
            DGridFormasPagoTarChe.Rows(1).Cells("col_formapagoTarChe").Value = "TARJ. DÉBITO"
            DGridFormasPagoTarChe.Rows.Add()
            DGridFormasPagoTarChe.Rows(2).Cells("col_formapagoTarChe").Value = "CHEQUES"

            DGridDolares.Rows.Add()
            DGridDolares.Rows(0).Cells("col_Dolforma").Value = "DOLARES"

            'DGridFormasPagoAct.Rows.Add()
            'DGridFormasPagoAct.Rows(0).Cells("col_formapagoAct").Value = "ACTIVO"
            Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                objDataSet = objCajaCredito.usp_TraerPermisosCaja(GLB_IdDeptoEmpleado, GLB_IdPuestoEmpleado, "CAJ", "ACTIVOS")
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                DGridFormasPagoAct.Visible = True
                lbl_Activos.Visible = True
                UP_Activos.Visible = True
            Else
                DGridFormasPagoAct.Visible = False
                lbl_Activos.Visible = False
                UP_Activos.Visible = False
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub UP_Activos_SelectedItemChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UP_Activos.SelectedItemChanged
        Try
            Dim Renglon As Integer = CInt(UP_Activos.Text)
            Dim RenglonesGrid As Integer = DGridFormasPagoAct.Rows.Count
            If Renglon = 0 And RenglonesGrid = 0 Then
                Exit Sub
            End If
            If Renglon > RenglonesGrid Then
                DGridFormasPagoAct.Rows.Add()
                DGridFormasPagoAct.Rows(RenglonesGrid).Cells("col_formapagoAct").Value = "ACTIVO"
            Else
                DGridFormasPagoAct.Rows.Remove(DGridFormasPagoAct.Rows(RenglonesGrid - 1))
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmCajaCredito_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

#End Region

#Region "DGRID"



    Private Sub DGridFormasPago_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGridFormasPagoEfe.CellEndEdit
        Try
            If DGridFormasPagoEfe.CurrentCell.ColumnIndex = 1 Then
                If DGridFormasPagoEfe.CurrentCell.Value Is Nothing Then
                    DGridFormasPagoEfe.CurrentCell.Value = 0
                End If
                If DGridFormasPagoEfe.CurrentCell.Value.ToString.Trim = "" Then
                    DGridFormasPagoEfe.CurrentCell.Value = 0
                End If
                DGridFormasPagoEfe.CurrentCell.Value = "$ " + DGridFormasPagoEfe.CurrentCell.Value.ToString
            End If
            If DGridFormasPagoEfe.CurrentCell.ColumnIndex = 2 Then
                Efec = 0
                For i As Integer = 0 To DGridFormasPagoEfe.RowCount - 1
                    Efec += (CDbl(DGridFormasPagoEfe.Rows(i).Cells("col_cantidad").Value) * (DGridFormasPagoEfe.Rows(i).Cells("col_importe").Value))
                Next
                'Efec += (CDbl(DGridFormasPagoEfe.CurrentCell.Value) * (DGridFormasPagoEfe.CurrentRow.Cells(DGridFormasPagoEfe.CurrentCell.ColumnIndex - 1).Value))
                Tot = Efec + TC + Act
                lbl_totEfe.Text = "EFECTIVO: $" & Efec.ToString("###,##0.00")
                lbl_Total.Text = "TOTAL: $" & Tot.ToString("###,##0.00")
                DGridFormasPagoEfe.CurrentRow.Cells("col_efectivo").Value = (CDbl(DGridFormasPagoEfe.CurrentCell.Value) * (DGridFormasPagoEfe.CurrentRow.Cells(DGridFormasPagoEfe.CurrentCell.ColumnIndex - 1).Value))
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGridFormasPagoTarChe_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGridFormasPagoTarChe.CellEndEdit
        Try
            If DGridFormasPagoTarChe.CurrentCell.ColumnIndex = 1 Then
                If DGridFormasPagoTarChe.CurrentCell.Value Is Nothing Then
                    DGridFormasPagoTarChe.CurrentCell.Value = 0
                End If
                If DGridFormasPagoTarChe.CurrentCell.Value.ToString.Trim = "" Then
                    DGridFormasPagoTarChe.CurrentCell.Value = 0
                End If
                TC = 0
                For i As Integer = 0 To DGridFormasPagoTarChe.RowCount - 1
                    TC += CDbl(DGridFormasPagoTarChe.Rows(i).Cells("col_ImporteTarChe").Value)
                Next
                'TC += CDbl(DGridFormasPagoTarChe.CurrentCell.Value)
                Tot = Efec + TC + Act
                lbl_TotTarChe.Text = "IMPORTE: $" & TC.ToString("###,##0.00")
                lbl_Total.Text = "TOTAL: $" & Tot.ToString("###,##0.00")
                DGridFormasPagoTarChe.CurrentCell.Value = "$ " + DGridFormasPagoTarChe.CurrentCell.Value.ToString
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGridFormasPagoAct_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGridFormasPagoAct.CellEndEdit
        Try
            If DGridFormasPagoAct.CurrentCell.ColumnIndex = 2 Then
                If DGridFormasPagoAct.CurrentCell.Value Is Nothing Then
                    DGridFormasPagoAct.CurrentCell.Value = 0
                End If
                If DGridFormasPagoAct.CurrentCell.Value.ToString.Trim = "" Then
                    DGridFormasPagoAct.CurrentCell.Value = 0
                End If
                Act = 0
                For i As Integer = 0 To DGridFormasPagoAct.RowCount - 1
                    Act += CDbl(DGridFormasPagoAct.Rows(i).Cells("col_importeact").Value)
                Next
                'Act += CDbl(DGridFormasPagoAct.CurrentCell.Value)
                Tot = Efec + TC + Act
                lbl_TotAct.Text = "IMPORTE: $" & Act.ToString("###,##0.00")
                lbl_Total.Text = "TOTAL: $" & Tot.ToString("###,##0.00")
                DGridFormasPagoAct.CurrentCell.Value = "$ " + DGridFormasPagoAct.CurrentCell.Value.ToString
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGridDolares_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGridDolares.CellEndEdit
        Try
            If DGridDolares.CurrentCell.ColumnIndex = 1 Then
                If DGridDolares.CurrentCell.Value Is Nothing Then
                    DGridDolares.CurrentCell.Value = 0
                End If
                If DGridDolares.CurrentCell.Value.ToString.Trim = "" Then
                    DGridDolares.CurrentCell.Value = 0
                End If
                DGridDolares.CurrentCell.Value = "$ " + DGridDolares.CurrentCell.Value.ToString
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
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
            If MessageBox.Show("Estas seguro que deseas realizar la entrega de caja?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
            If ValidaActivos() = False Then
                Exit Sub
            End If
            Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                objCajaCredito.usp_CapturaEntrega(1, GLB_Idempleado, GLB_FechaHoy.ToString("yyyy-MM-dd"), 0, "", 0, "", 0, 0)
            End Using
            Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                objDataSet = objCajaCredito.usp_TraerEntrega(1, GLB_Idempleado, GLB_FechaHoy.ToString("yyyy-MM-dd"))
            End Using
            Dim idEntrega As Integer = CInt(objDataSet.Tables(0).Rows(0).Item("identrega").ToString)
            Dim Formas As String = ""
            Dim Cantidad As Integer = 0
            Dim Importe As Double = 0.0
            For i As Integer = 0 To DGridFormasPagoEfe.Rows.Count - 1
                Formas = ""
                Cantidad = 0
                Importe = 0.0
                Formas = "EFE"
                If DGridFormasPagoEfe.Rows(i).Cells("col_cantidad").Value Is Nothing Then
                    Cantidad = 0
                Else
                    If DGridFormasPagoEfe.Rows(i).Cells("col_cantidad").Value.ToString.Trim = "" Then
                        Cantidad = 0
                    Else
                        Cantidad = CInt(DGridFormasPagoEfe.Rows(i).Cells("col_cantidad").Value.ToString.Trim)
                    End If
                End If
                If DGridFormasPagoEfe.Rows(i).Cells("col_importe").Value Is Nothing Then
                    Importe = 0
                Else
                    If DGridFormasPagoEfe.Rows(i).Cells("col_importe").Value.ToString.Trim = "" Then
                        Importe = 0
                    Else
                        Importe = CDbl(DGridFormasPagoEfe.Rows(i).Cells("col_importe").Value.ToString.Trim)
                    End If
                End If
                Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                    objCajaCredito.usp_CapturaEntrega(2, GLB_Idempleado, GLB_FechaHoy.ToString("yyyy-MM-dd"), idEntrega,
                                                      Formas, Cantidad, "", Importe, 0)
                End Using
            Next
            For i As Integer = 0 To DGridFormasPagoTarChe.Rows.Count - 1
                Formas = ""
                Cantidad = 0
                Importe = 0.0
                If i = 0 Then
                    Formas = "TAC"
                ElseIf i = 1 Then
                    Formas = "TAD"
                ElseIf i = 2 Then
                    Formas = "CHE"
                End If
                If DGridFormasPagoTarChe.Rows(i).Cells("col_cantidadtarche").Value Is Nothing Then
                    Cantidad = 0
                Else
                    If DGridFormasPagoTarChe.Rows(i).Cells("col_cantidadtarche").Value.ToString.Trim = "" Then
                        Cantidad = 0
                    Else
                        Cantidad = CInt(DGridFormasPagoTarChe.Rows(i).Cells("col_cantidadtarche").Value.ToString.Trim)
                    End If
                End If
                If DGridFormasPagoTarChe.Rows(i).Cells("col_importetarche").Value Is Nothing Then
                    Importe = 0
                Else
                    If DGridFormasPagoTarChe.Rows(i).Cells("col_importetarche").Value.ToString.Trim = "" Then
                        Importe = 0
                    Else
                        Importe = CDbl(DGridFormasPagoTarChe.Rows(i).Cells("col_importetarche").Value.ToString.Trim)
                    End If
                End If
                Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                    objCajaCredito.usp_CapturaEntrega(2, GLB_Idempleado, GLB_FechaHoy.ToString("yyyy-MM-dd"), idEntrega,
                                                      Formas, Cantidad, "", Importe, 0)
                End Using
            Next
            Dim Articulo As String = ""
            For i As Integer = 0 To DGridFormasPagoAct.Rows.Count - 1
                Formas = ""
                Cantidad = 0
                Importe = 0.0
                Articulo = ""
                Formas = "ACT"
                Cantidad = 1
                If DGridFormasPagoAct.Rows(i).Cells("col_articulo").Value Is Nothing Then
                    Articulo = ""
                Else
                    If DGridFormasPagoAct.Rows(i).Cells("col_articulo").Value.ToString.Trim = "" Then
                        Articulo = ""
                    Else
                        Articulo = DGridFormasPagoAct.Rows(i).Cells("col_articulo").Value.ToString.Trim
                    End If
                End If
                If DGridFormasPagoAct.Rows(i).Cells("col_ImporteAct").Value Is Nothing Then
                    Importe = 0
                Else
                    If DGridFormasPagoAct.Rows(i).Cells("col_ImporteAct").Value.ToString.Trim = "" Then
                        Importe = 0
                    Else
                        Importe = CDbl(DGridFormasPagoAct.Rows(i).Cells("col_ImporteAct").Value.ToString.Trim)
                    End If
                End If
                Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                    objCajaCredito.usp_CapturaEntrega(2, GLB_Idempleado, GLB_FechaHoy.ToString("yyyy-MM-dd"), idEntrega,
                                                      Formas, Cantidad, Articulo, Importe, 0)
                End Using
            Next
            Formas = ""
            Cantidad = 0
            Importe = 0.0
            Articulo = ""
            Formas = "DOL"
            If DGridDolares.Rows(0).Cells("col_DolDolares").Value Is Nothing Then
                Importe = 0
            Else
                If DGridDolares.Rows(0).Cells("col_DolDolares").Value.ToString.Trim = "" Then
                    Importe = 0
                Else
                    Importe = CDbl(DGridDolares.Rows(0).Cells("col_DolDolares").Value.ToString.Trim)
                End If
            End If
            Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                objCajaCredito.usp_CapturaEntrega(2, GLB_Idempleado, GLB_FechaHoy.ToString("yyyy-MM-dd"), idEntrega,
                                                  Formas, Cantidad, Articulo, 0, Importe)
            End Using
            ImprimirHojaEntrega()
            blnAceptar = True
            Me.Close()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

#End Region

#End Region


#Region "METODOS"

    Private Function ValidaActivos() As Boolean
        Dim Efe As Double = 0
        Dim TarChe As Double = 0
        Dim Act As Double = 0
        For i As Integer = 0 To DGridFormasPagoEfe.Rows.Count - 1
            If DGridFormasPagoEfe.Rows(i).Cells("col_cantidad").Value Is Nothing Then
                Efe += 0
            Else
                If DGridFormasPagoEfe.Rows(i).Cells("col_cantidad").Value.ToString.Trim = "" Then
                    Efe += 0
                Else
                    Efe += CDbl(DGridFormasPagoEfe.Rows(i).Cells("col_cantidad").Value.ToString)
                End If
            End If
        Next
        For i As Integer = 0 To DGridFormasPagoTarChe.Rows.Count - 1
            If DGridFormasPagoTarChe.Rows(i).Cells("col_importetarche").Value Is Nothing Then
                TarChe += 0
            Else
                If DGridFormasPagoTarChe.Rows(i).Cells("col_importetarche").Value.ToString.Trim = "" Then
                    TarChe += 0
                Else
                    TarChe += CDbl(DGridFormasPagoTarChe.Rows(i).Cells("col_importetarche").Value.ToString)
                End If
            End If
        Next
        For i As Integer = 0 To DGridFormasPagoAct.Rows.Count - 1
            If DGridFormasPagoAct.Rows(i).Cells("col_importeact").Value Is Nothing Then
                Act += 0
            Else
                If DGridFormasPagoAct.Rows(i).Cells("col_importeact").Value.ToString.Trim = "" Then
                    Act += 0
                Else
                    Act += CDbl(DGridFormasPagoAct.Rows(i).Cells("col_importeact").Value.ToString)
                End If
            End If
        Next
        If Efe = 0 And TarChe = 0 And Act = 0 Then
            MessageBox.Show("Debes ingresar los datos correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ValidaActivos = False
            Exit Function
        End If
        For i As Integer = 0 To DGridFormasPagoAct.Rows.Count - 1
            If DGridFormasPagoAct.Rows(i).Cells("col_articulo").Value Is Nothing Then
                MessageBox.Show("Debes ingresar correctamente todos los activos", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ValidaActivos = False
                Exit Function
            Else
                If DGridFormasPagoAct.Rows(i).Cells("col_articulo").Value.ToString.Trim = "" Then
                    MessageBox.Show("Debes ingresar correctamente todos los activos", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ValidaActivos = False
                    Exit Function
                End If
            End If
            If DGridFormasPagoAct.Rows(i).Cells("col_importeact").Value Is Nothing Then
                MessageBox.Show("Debes ingresar correctamente todos los activos", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ValidaActivos = False
                Exit Function
            Else
                If DGridFormasPagoAct.Rows(i).Cells("col_importeact").Value.ToString.Trim = "" Then
                    MessageBox.Show("Debes ingresar correctamente todos los activos", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ValidaActivos = False
                    Exit Function
                End If
            End If
        Next
        ValidaActivos = True
    End Function

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

            With DGridFormasPagoEfe

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

            With DGridFormasPagoTarChe
                Dim objDataRow As Data.DataRow
                objDataRow = GenerarHojaEntrega.Tables("DTCTDTarjetaCheque").NewRow()
                objDataRow.Item("ctdcredito") = If(.Rows(0).Cells(2).Value Is Nothing, 0, .Rows(0).Cells(2).Value)
                objDataRow.Item("ctddebito") = If(.Rows(1).Cells(2).Value Is Nothing, 0, .Rows(1).Cells(2).Value)
                objDataRow.Item("ctdcheques") = If(.Rows(2).Cells(2).Value Is Nothing, 0, .Rows(2).Cells(2).Value)
                GenerarHojaEntrega.Tables("DTCTDTarjetaCheque").Rows.Add(objDataRow)
                Dim objDataRow2 As Data.DataRow
                objDataRow2 = GenerarHojaEntrega.Tables("DTIMPTarjetaCheque").NewRow()
                objDataRow2.Item("impcredito") = If(.Rows(0).Cells(1).Value Is Nothing, 0, CDbl(.Rows(0).Cells(1).Value))
                objDataRow2.Item("impdebito") = If(.Rows(1).Cells(1).Value Is Nothing, 0, CDbl(.Rows(1).Cells(1).Value))
                objDataRow2.Item("impcheque") = If(.Rows(2).Cells(1).Value Is Nothing, 0, CDbl(.Rows(2).Cells(1).Value))
                GenerarHojaEntrega.Tables("DTIMPTarjetaCheque").Rows.Add(objDataRow2)
            End With

            With DGridFormasPagoAct
                Dim objDataRow As Data.DataRow
                For i As Integer = 0 To .Rows.Count - 1
                    objDataRow = GenerarHojaEntrega.Tables("DTActivos").NewRow()
                    objDataRow.Item("articulo") = .Rows(i).Cells(1).Value
                    objDataRow.Item("importe") = CDbl(.Rows(i).Cells(2).Value)
                    objDataRow.Item("renglon") = i
                    GenerarHojaEntrega.Tables("DTActivos").Rows.Add(objDataRow)
                Next
            End With

            With DGridDolares
                Dim objDataRow As Data.DataRow
                objDataRow = GenerarHojaEntrega.Tables("DTDolares").NewRow()

                objDataRow.Item("dolares") = If(.Rows(0).Cells(1).Value Is Nothing, 0, CDbl(.Rows(0).Cells(1).Value))
                Using objCajaCredito As New BCL.BCLCajaCredito(GLB_ConStringCredito)
                    objDataSet = objCajaCredito.usp_TraerTipoCambio()
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Dim TipoCambio As Double = CDbl(objDataSet.Tables(0).Rows(0).Item("tipocambio").ToString)
                    objDataRow.Item("pesos") = Math.Round(If(.Rows(0).Cells(1).Value Is Nothing, 0, CDbl(.Rows(0).Cells(1).Value) * TipoCambio), 2)
                Else
                    objDataRow.Item("pesos") = If(.Rows(0).Cells(1).Value Is Nothing, 0, .Rows(0).Cells(1).Value)
                End If
                GenerarHojaEntrega.Tables("DTDolares").Rows.Add(objDataRow)
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