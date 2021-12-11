Public Class frmPpalNominaResumen
    'miguel perez 20/Septiembre/2012 01:20 p.m.

    Private objDataSet As Data.DataSet
    Private blnFiltros As Boolean = False
    Private periodo As String
    Private estatus As String
    Private Sub frmPpalProveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call RellenaGrid()
    End Sub

    Private Sub RellenaGrid()
        Try
            Dim TotalNom As Decimal = 0
            Dim NomDisp As Decimal = 0
            Dim CompNomina As Decimal = 0
            Dim PersonalIng As Decimal = 0
            Dim SinTarjeta As Decimal = 0
            Dim TotalComp As Decimal = 0
            Dim TotalRenglones As Integer = 0
            DGrid.ColumnHeadersVisible = False
            Lbl_Periodo.Text = ""
            DGrid.Rows.Clear()
            DGrid.Refresh()
            If blnFiltros = False Then
                estatus = "A"
                periodo = pub_TraerUltimoPeriodo(2, estatus)
            Else
                estatus = ""
                blnFiltros = False
            End If
            If periodo = "" Then Exit Sub
            DGrid.Rows.Add(10)
            Dim FechaPeriodo As String = ""
            Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringNomSis)
                objDataSet = objMySqlGral.usp_TraerUltimoPeriodo(2, estatus, CInt(periodo))
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    FechaPeriodo = objDataSet.Tables(0).Rows(0).Item("FECHAINI").ToString.Substring(0, 10)
                    FechaPeriodo += " AL "
                    FechaPeriodo += objDataSet.Tables(0).Rows(0).Item("FECHAFIN").ToString.Substring(0, 10)
                End If
            End Using
            DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            Using objRegistro As New BCL.BCLNomina(GLB_ConStringNomSis)
                objDataSet = objRegistro.usp_TraerPagoNomina(periodo, "F")
                If objDataSet.Tables(0).Rows(0).Item("NominaPeriodo").ToString = "" Then
                    DGrid.Rows.Clear()
                    MessageBox.Show("El periodo seleccionado no contiene registros", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                TotalNom = CDec(objDataSet.Tables(0).Rows(0).Item("NominaPeriodo"))
            End Using
            Using objRegistro As New BCL.BCLNomina(GLB_ConStringNomSis)
                objDataSet = objRegistro.usp_TraerNominaADispersar(periodo, "F")
                NomDisp = CDec(objDataSet.Tables(0).Rows(0).Item("Pago"))
            End Using
            Using objRegistro As New BCL.BCLNomina(GLB_ConStringNomSis)
                objDataSet = objRegistro.usp_TraerPagoPersonalIng(periodo, "F")
                PersonalIng = CDec(objDataSet.Tables(0).Rows(0).Item("Pago"))
            End Using
            Using objRegistro As New BCL.BCLNomina(GLB_ConStringNomSis)
                objDataSet = objRegistro.usp_TraerPagoPersonalSinTarjeta(periodo, "F")
                If IsDBNull(objDataSet.Tables(0).Rows(0).Item("Pago")) Then
                Else
                    SinTarjeta = CDec(objDataSet.Tables(0).Rows(0).Item("Pago"))
                End If
            End Using
            DGrid.Rows(0).Cells("ColDatos").Value = "NOMINA DEL " + FechaPeriodo
            DGrid.Rows(1).Cells("ColDatos").Value = "TOTAL NOMINA"
            DGrid.Rows(1).Cells("Cantidades").Value = TotalNom
            DGrid.Rows(2).Cells("ColDatos").Value = "NOMINA A DISPERSAR"
            DGrid.Rows(2).Cells("Cantidades").Value = NomDisp
            DGrid.Rows(3).Cells("ColDatos").Value = "COMPLEMENTO DE NOMINA"
            CompNomina = TotalNom - NomDisp
            DGrid.Rows(3).Cells("Cantidades").Value = CompNomina
            DGrid.Rows(3).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Rows(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Rows(3).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

            DGrid.Rows(5).Cells("ColDatos").Value = "PERSONAL INGENIERO"
            DGrid.Rows(5).Cells("Cantidades").Value = PersonalIng
            DGrid.Rows(6).Cells("ColDatos").Value = "PERSONAL SIN TARJETA NOMINA"
            DGrid.Rows(6).Cells("Cantidades").Value = SinTarjeta
            DGrid.Rows(7).Cells("ColDatos").Value = "TOTAL DEL COMPLEMENTO"
            TotalComp = PersonalIng + SinTarjeta
            DGrid.Rows(7).Cells("Cantidades").Value = TotalComp
            DGrid.Rows(7).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Rows(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Rows(7).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

            Using objRegistro As New BCL.BCLNomina(GLB_ConStringNomSis)
                objDataSet = objRegistro.usp_TraerPersonalIng(periodo)
            End Using
            Dim persIng As Decimal = 0
            DGrid.Rows(9).Cells("ColDatos").Value = "LISTADO DEL PERSONAL DEL INGENIERO"
            DGrid.Rows(9).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Rows(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Rows(9).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            DGrid.Rows.Add(objDataSet.Tables(0).Rows.Count + 1)
            TotalRenglones = objDataSet.Tables(0).Rows.Count + 9
            For i As Integer = 10 To TotalRenglones
                DGrid.Rows(i).Cells("ColDatos").Value = objDataSet.Tables(0).Rows(i - 10).Item("Nombre").ToString
                DGrid.Rows(i).Cells("Cantidades").Value = objDataSet.Tables(0).Rows(i - 10).Item("Pago")
                persIng += CDec(objDataSet.Tables(0).Rows(i - 10).Item("Pago"))
            Next
            DGrid.Rows(TotalRenglones + 1).Cells("ColDatos").Value = "TOTAL"
            DGrid.Rows(TotalRenglones + 1).Cells("Cantidades").Value = persIng
            DGrid.Rows(TotalRenglones + 1).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Rows(TotalRenglones + 1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Rows(TotalRenglones + 1).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

            DGrid.Rows.Add(10)
            DGrid.Rows(TotalRenglones + 3).Cells("ColDatos").Value = DGrid.Rows(0).Cells("ColDatos").Value.ToString
            DGrid.Rows(TotalRenglones + 3).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Rows(TotalRenglones + 3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Rows(TotalRenglones + 3).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            DGrid.Rows(TotalRenglones + 4).Cells("ColDatos").Value = "BONOS ADMINISTRACION"
            DGrid.Rows(TotalRenglones + 5).Cells("ColDatos").Value = "BONOS MANTENIMIENTO"
            DGrid.Rows(TotalRenglones + 6).Cells("ColDatos").Value = "BONOS SISTEMAS"
            DGrid.Rows(TotalRenglones + 7).Cells("ColDatos").Value = "BONOS COMPRAS"
            DGrid.Rows(TotalRenglones + 8).Cells("ColDatos").Value = "BONOS CEDIS"
            DGrid.Rows(TotalRenglones + 9).Cells("ColDatos").Value = "BONOS PUBLICIDAD"
            DGrid.Rows(TotalRenglones + 10).Cells("ColDatos").Value = "BONOS CREDITO Y COBRANZA"
            DGrid.Rows(TotalRenglones + 11).Cells("ColDatos").Value = "PERSONAL DE TARJETA SIN NOMINA"

            Dim sucursal As String = ""
            Dim bono As Decimal = 0
            Dim totSuc As Decimal = 0
            For i As Integer = 1 To 7
                If i = 1 Then
                    sucursal = "00"
                ElseIf i = 2 Then
                    sucursal = "94"
                ElseIf i = 3 Then
                    sucursal = "95"
                ElseIf i = 4 Then
                    sucursal = "96"
                ElseIf i = 5 Then
                    sucursal = "15"
                ElseIf i = 6 Then
                    sucursal = "91"
                ElseIf i = 7 Then
                    sucursal = "98"
                End If
                Using objRegistro As New BCL.BCLNomina(GLB_ConStringNomSis)
                    objDataSet = objRegistro.usp_TraerBonoSucursal(periodo, sucursal)
                    bono = CDec(objDataSet.Tables(0).Rows(0).Item("Pago"))
                    totSuc += bono
                End Using
                DGrid.Rows(TotalRenglones + i + 3).Cells("Cantidades").Value = bono
            Next
            TotalRenglones += 9
            DGrid.Rows(TotalRenglones + 2).Cells("Cantidades").Value = SinTarjeta
            totSuc += SinTarjeta
            DGrid.Rows.Add()
            TotalRenglones += 1
            DGrid.Rows(TotalRenglones + 2).Cells("ColDatos").Value = "TOTAL"
            DGrid.Rows(TotalRenglones + 2).Cells("Cantidades").Value = totSuc
            DGrid.Rows(TotalRenglones + 2).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Rows(TotalRenglones + 2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Rows(TotalRenglones + 2).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            DGrid.Rows.Add(2)
            TotalRenglones += 2
            Using objRegistro As New BCL.BCLNomina(GLB_ConStringNomSis)
                objDataSet = objRegistro.usp_TraerPersSinTarjNom(periodo, "F")
            End Using
            Dim totSinTarjeta As Decimal = 0
            If objDataSet.Tables(0).Rows.Count > 0 Then
                DGrid.Rows.Add(objDataSet.Tables(0).Rows.Count)
                DGrid.Rows(TotalRenglones + 2).Cells("ColDatos").Value = "PERSONAL SIN TARJETA DE NOMINA"
                DGrid.Rows(TotalRenglones + 2).DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Rows(TotalRenglones + 2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Rows(TotalRenglones + 2).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                For j As Integer = TotalRenglones To TotalRenglones + objDataSet.Tables(0).Rows.Count - 1
                    DGrid.Rows(j + 3).Cells("ColDatos").Value = objDataSet.Tables(0).Rows(j - TotalRenglones).Item("Nombre").ToString
                    DGrid.Rows(j + 3).Cells("Cantidades").Value = objDataSet.Tables(0).Rows(j - TotalRenglones).Item("Pago")
                    totSinTarjeta += CDec(objDataSet.Tables(0).Rows(j - TotalRenglones).Item("Pago"))
                Next
                TotalRenglones += objDataSet.Tables(0).Rows.Count + 1
            End If
            DGrid.Rows.Add()
            TotalRenglones += 1
            DGrid.Rows(TotalRenglones + 1).Cells("ColDatos").Value = "TOTAL"
            DGrid.Rows(TotalRenglones + 1).Cells("Cantidades").Value = totSinTarjeta
            DGrid.Rows(TotalRenglones + 1).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Rows(TotalRenglones + 1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Rows(TotalRenglones + 1).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Using objRegistro As New BCL.BCLNomina(GLB_ConStringNomSis)
                objDataSet = objRegistro.usp_TraerPercdeduc(periodo, "F", "30")
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                Dim TotPension As Decimal = 0
                TotalRenglones += 3
                DGrid.Rows.Add(3)
                DGrid.Rows(TotalRenglones).Cells("ColDatos").Value = "PENSIÓN ALIMENTICIA"
                DGrid.Rows(TotalRenglones).DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Rows(TotalRenglones).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Rows(TotalRenglones).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                DGrid.Rows.Add(objDataSet.Tables(0).Rows.Count)
                For j As Integer = TotalRenglones To TotalRenglones + objDataSet.Tables(0).Rows.Count - 1
                    DGrid.Rows(j + 1).Cells("ColDatos").Value = objDataSet.Tables(0).Rows(j - TotalRenglones).Item("Nombre").ToString
                    DGrid.Rows(j + 1).Cells("Cantidades").Value = objDataSet.Tables(0).Rows(j - TotalRenglones).Item("Pago")
                    TotPension += CDec(objDataSet.Tables(0).Rows(j - TotalRenglones).Item("Pago"))
                Next
                TotalRenglones += objDataSet.Tables(0).Rows.Count
                DGrid.Rows(TotalRenglones + 1).Cells("ColDatos").Value = "TOTAL"
                DGrid.Rows(TotalRenglones + 1).Cells("Cantidades").Value = TotPension
                DGrid.Rows(TotalRenglones + 1).DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Rows(TotalRenglones + 1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Rows(TotalRenglones + 1).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Lbl_Periodo.Text = DGrid.Rows(0).Cells("ColDatos").Value.ToString
            InicializaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Sub InicializaGrid()

        Try
            Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
            DGrid.DataSource = dt

            DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid.Columns(1).DefaultCellStyle.Format = "c"
            DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            DGrid.RowHeadersVisible = False
            'DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.BackColor = Color.PowderBlue
            'DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            'DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Me.Close()
        Me.Dispose()
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

    Private Sub frmPpalPedidoNuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Filtro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        Try
            Dim myForm As New frmFiltrosNomina
            myForm.Label1.Visible = False
            myForm.Label2.Visible = False
            myForm.Label4.Visible = False
            myForm.Label5.Visible = False
            myForm.Empleado.Visible = False
            myForm.Departamento.Visible = False
            myForm.Txt_ClaveDepto.Visible = False
            myForm.Txt_ClavePuesto.Visible = False
            myForm.Txt_DescriConcepto.Visible = False
            myForm.Txt_DescripDepto.Visible = False
            myForm.Txt_DescripPuesto.Visible = False
            myForm.Txt_DescripSucursal.Visible = False
            myForm.Txt_IdConcepto.Visible = False
            myForm.Txt_IdEmpleado.Visible = False
            myForm.Txt_NombreEmpleado.Visible = False
            myForm.Txt_Sucursal.Visible = False
            myForm.Cbo_TipoNom.Visible = False
            myForm.Pnl_Edicion.Width = 528
            myForm.Pnl_Edicion.Height = 126
            myForm.Pnl_Botones.Left = 12
            myForm.Pnl_Botones.Top = 141
            myForm.Width = 552
            myForm.Height = 241
            myForm.ShowDialog()
            periodo = myForm.Periodo
            periodo = periodo.Substring(1, 3)
            blnFiltros = True
            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
End Class