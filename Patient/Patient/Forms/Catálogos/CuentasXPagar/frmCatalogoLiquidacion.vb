Public Class frmCatalogoLiquidacion
    'mreyes 25/Abril/2012 06:30 p.m.
    Private objDataSet As Data.DataSet
    Private objDataSet1 As Data.DataSet
    Public Sw_Registro As Boolean = False

    Dim Marcab As String
    Dim Estilonb As String
    Dim Estilofb As String
    Dim Familiab As String
    Dim Lineab As String
    Dim Proveedorb As Integer
    Dim TipoArtb As String
    Dim Categoriab As String

    Dim Sucursalb As String
    Dim OrdeCompb As String
    Dim FechaInib As String
    Dim FechaFinb As String
    Dim Statusb As String
    Dim VenceInib As String
    Dim VenceFinb As String
    Dim FactInib As String
    Dim FactFinb As String
    Dim FechaRecInib As String
    Dim FechaRecFinB As String
    Dim Sw_Pintar As Boolean = False
    Dim EstatusLiquidacion As String = ""
    Public OpcionLiquidacion As Integer = 0
    Dim DetalladoRevision As Boolean = False
    Dim Est As String = ""
    Dim Est1 As String = ""
    Dim Est2 As String = ""
    Dim Est3 As String = ""


    Dim Sw_Load As Boolean = True
    Dim Sw_Boton As Boolean = False
    Dim Sw_NoRegistros As Boolean = False
    Public Opcion As Integer = 0
    Public idLiquidacion As Integer = 0
    Private blnEntro As Boolean = False
    Private OpcionReporte As Integer = 0
    Private numCheque As String = ""
    Private idCuenta As Integer = 0
    Dim Prov As String = ""
    Private blnPagados As Boolean = False
    Private Banco As String = ""
    Dim blnPrimero As Boolean = False
    Dim blbBooleano As Boolean = False
    Dim TipoRF As String = ""

    Dim TipoB As String = ""
    Public Function pub_TraerIdFolioBulto(ByVal IdFolioSuc As String) As Integer
        'mreyes 25/Junio/2013 01:03 p.m.
        Try
            Dim objDataSet As Data.DataSet
            pub_TraerIdFolioBulto = 0
            Using objParame_Det As New BCL.BCLBulto(GLB_ConStringCipSis)
                objDataSet = objParame_Det.pub_TraerIdFolio(IdFolioSuc)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    pub_TraerIdFolioBulto = objDataSet.Tables(0).Rows(0).Item("idfolio").ToString
                End If

            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
            pub_TraerIdFolioBulto = 0
        End Try
    End Function
    Private Sub frmPpalFacturas_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            If blnPrimero = False Then
                blnPrimero = True
                If DGrid.DataSource Is Nothing Then Exit Sub
                DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                DGrid.Rows(0).Frozen = True
                DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmPpalFacturas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
        If e.KeyCode = Keys.F5 Then
            'Call Btn_Filtro_Click_1(sender, e)
        End If
    End Sub

    Private Sub frmPpalFacturas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Sw_Load = True
            Call LimpiarBusqueda()
            'Opcion = 1
            Est = "INSERT INTO clasificacion (status) VALUES ('GE'),('RV')"
            Est1 = "INSERT INTO clasificacionB (status) VALUES ('GE'),('RV')"
            Est2 = "INSERT INTO clasificacionBb (status) VALUES ('GE'),('RV')"
            Est3 = "INSERT INTO clasificacionBbB (status) VALUES ('GE'),('RV')"
            FechaInib = "1900-01-01"
            FechaFinb = "1900-01-01"
            If Opcion = 0 Then
                Opcion = 1
            End If
            Prov = ""
            Call RellenaGrid(TipoB)
            Call GenerarToolTip()
            ''   Call Factura_Microsip()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub GenerarToolTip()
        Try




            ToolTip.SetToolTip(Btn_Regresar, "Búsqueda Avanzada")
            'ToolTip.SetToolTip(Btn_Refrescar, "Refrescar Información")
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
            ToolTip.SetToolTip(Btn_Imprimir, "Imprimir Información")
            'ToolTip.SetToolTip(Btn_Pdf, "Generar Información en PDF")
            ToolTip.SetToolTip(Btn_Salir, "Salir")
            ToolTip.SetToolTip(Btn_Revisado, "Revisado")
            ToolTip.SetToolTip(Btn_Aplicar, "Aplicar Liquidación")
            ToolTip.SetToolTip(Btn_Pagados, "Liquidaciones Pagadas")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub RellenaGrid(ByVal TipoB As String)
        Try
            DGrid.DataSource = Nothing
            If Opcion = 1 Then
                Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                    objDataSet = objCuentas.usp_TraerLiquidacion(0, FechaInib, FechaFinb, Est, Est1, Est2, Est3, TipoRF)
                End Using
                OpcionLiquidacion = 0
                idCuenta = 0
                Banco = ""
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                        If objDataSet.Tables(0).Rows(i).Item("tipo").ToString.Trim = "F" Then
                            objDataSet.Tables(0).Rows(i).Item("tipo") = "PAGOUNICO"
                        ElseIf objDataSet.Tables(0).Rows(i).Item("tipo").ToString.Trim = "J" Then
                            objDataSet.Tables(0).Rows(i).Item("tipo") = "FACTORAJE"
                        ElseIf objDataSet.Tables(0).Rows(i).Item("tipo").ToString.Trim = "D" Then
                            objDataSet.Tables(0).Rows(i).Item("tipo") = "PAGODIF"
                        ElseIf objDataSet.Tables(0).Rows(i).Item("tipo").ToString.Trim = "T" Then
                            objDataSet.Tables(0).Rows(i).Item("tipo") = "TRANSFERENCIA"
                        Else

                            objDataSet.Tables(0).Rows(i).Item("tipo") = "CONSIGNACIÓN"
                        End If
                    Next
                End If
                'FechaInib = "1900-01-01"
                'FechaFinb = "1900-01-01"
            End If
            If Opcion = 2 Then
                If TipoB = "FACTORAJE" Then
                    Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                        'OpcionLiquidacion
                        objDataSet = objCuentas.usp_TraerLiquidacionDetFactoraje(OpcionLiquidacion, idLiquidacion, Prov)
                    End Using
                ElseIf TipoB = "PAGOUNICO" Then
                    Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                        objDataSet = objCuentas.usp_TraerLiquidacionDet(OpcionLiquidacion, idLiquidacion, Prov)
                    End Using
                ElseIf TipoB = "PAGODIF" Then
                    Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                        objDataSet = objCuentas.usp_TraerLiquidacionDetDiferidos(OpcionLiquidacion, idLiquidacion, Prov)
                    End Using
                ElseIf TipoB = "CONSIGNACIÓN" Then
                    Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                        objDataSet = objCuentas.usp_TraerLiquidacionDet(OpcionLiquidacion, idLiquidacion, Prov)
                    End Using
                ElseIf TipoB = "TRANSFERENCIA" Then
                    Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                        objDataSet = objCuentas.usp_TraerLiquidacionDetTransferencia(OpcionLiquidacion, idLiquidacion, Prov)
                    End Using
                End If
            End If
            If objDataSet.Tables(0).Rows.Count > 0 Then
                blbBooleano = True
                DGrid.DataSource = objDataSet.Tables(0)
                blbBooleano = False
                InicializaGrid()
            Else
                If Opcion = 1 Then
                    MessageBox.Show("No se encontraron liquidaciones pendientes", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Btn_Revisado.Enabled = False
                    Btn_Aplicar.Enabled = False
                End If
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub LimpiarBusqueda()

    End Sub


    Private Sub Btn_Refrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call RellenaGrid(TipoB)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Sub InicializaGrid()
        '' 
        'mreyes 12/Febrero/2011 05:37 p.m.
        Try
            If Opcion = 1 Then
                Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
                Dim row As DataRow = dt.NewRow()
                row(2) = "TOTAL: "

                row(5) = pub_SumarColumnaGridSC(DGrid, 5, DGrid.RowCount - 1)
                row(6) = pub_SumarColumnaGridSC(DGrid, 6, DGrid.RowCount - 1)
                row(7) = pub_SumarColumnaGridSC(DGrid, 7, DGrid.RowCount - 1)
                row(8) = pub_SumarColumnaGridSC(DGrid, 8, DGrid.RowCount - 1)
                row(9) = pub_SumarColumnaGridSC(DGrid, 9, DGrid.RowCount - 1)
                row(10) = pub_SumarColumnaGridSC(DGrid, 10, DGrid.RowCount - 1)
                row(11) = pub_SumarColumnaGridSC(DGrid, 11, DGrid.RowCount - 1)

                row(15) = pub_SumarColumnaGridSC(DGrid, 15, DGrid.RowCount - 1)

                dt.Rows.InsertAt(row, 0)
                DGrid.DataSource = dt

                'DGrid.Columns(0).Visible = False
                DGrid.Columns(1).Visible = False
                DGrid.Columns(13).Visible = False

                DGrid.Columns(0).HeaderText = "Liquidacion"
                DGrid.Columns(1).HeaderText = "idCuenta"
                DGrid.Columns(2).HeaderText = "Banco"
                DGrid.Columns(3).HeaderText = "N° Cheques"
                DGrid.Columns(4).HeaderText = "Estatus"
                DGrid.Columns(5).HeaderText = "Subtotal"
                DGrid.Columns(6).HeaderText = "Gastos"
                DGrid.Columns(7).HeaderText = "Impuesto"
                DGrid.Columns(8).HeaderText = "Cargo"
                DGrid.Columns(9).HeaderText = "Credito"
                DGrid.Columns(10).HeaderText = "Descuento"

                DGrid.Columns(11).HeaderText = "Total"
                DGrid.Columns(12).HeaderText = "Fecha"
                DGrid.Columns(13).HeaderText = "Usuario"
                DGrid.Columns(14).HeaderText = "Tipo"

                DGrid.Columns(15).DisplayIndex = 11
                DGrid.Columns(15).HeaderText = "Improcedente"

                DGrid.Columns(5).DefaultCellStyle.Format = "c"
                DGrid.Columns(6).DefaultCellStyle.Format = "c"
                DGrid.Columns(7).DefaultCellStyle.Format = "c"
                DGrid.Columns(8).DefaultCellStyle.Format = "c"
                DGrid.Columns(9).DefaultCellStyle.Format = "c"
                DGrid.Columns(10).DefaultCellStyle.Format = "c"
                DGrid.Columns(11).DefaultCellStyle.Format = "c"

                DGrid.Columns(15).DefaultCellStyle.Format = "c"

                DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                DGrid.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(14).DisplayIndex = 0


                Btn_Regresar.Enabled = False
                For i As Integer = 0 To DGrid.Columns.Count - 1
                    DGrid.Columns(i).ReadOnly = True
                Next
                DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                DGrid.Rows(0).Frozen = True
                CancelarLiquidacionBultoToolStripMenuItem.Visible = True
                DetalleLiquidacionToolStripMenuItem.Visible = True
                MostrarDetalladoToolStripMenuItem.Visible = False
                MostrarDetalladoProvToolStripMenuItem.Visible = False
                ImprimirAnexoToolStripMenuItem.Visible = False
                ImprimirChequeToolStripMenuItem.Visible = False
                ImprimirLiquidacionToolStripMenuItem.Visible = False
                CancelarChequeToolStripMenuItem.Visible = False
                FichadeDepositoToolStripMenuItem.Visible = False
                DetalleFacturaToolStripMenuItem.Visible = False
                ConsultarBultoToolStripMenuItem.Visible = False
                VerFichaDepositoToolStripMenuItem.Visible = False
                NotasCCProvToolStripMenuItem.Visible = False
                NotasCCToolStripMenuItem.Visible = False
                Btn_Aplicar.Enabled = False
                Btn_Revisado.Enabled = False
                Btn_Imprimir.Enabled = False
                DetalladoRevision = False
                Btn_Regresar.Enabled = True
                Lbl_IdLiquidacion.Visible = False
                Lbl_Factura.Visible = False
                Txt_Factura.Visible = False
                Txt_Factura.Text = ""
            End If
            If Opcion = 2 Then
                Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
                Dim row As DataRow = dt.NewRow()
                row(9) = "TOTAL: "

                row(10) = pub_SumarColumnaGridCheck(DGrid, 10, DGrid.RowCount - 1)
                row(11) = pub_SumarColumnaGridCheck(DGrid, 11, DGrid.RowCount - 1)
                row(12) = pub_SumarColumnaGridCheck(DGrid, 12, DGrid.RowCount - 1)
                row(13) = pub_SumarColumnaGridCheck(DGrid, 13, DGrid.RowCount - 1)
                row(14) = pub_SumarColumnaGridCheck(DGrid, 14, DGrid.RowCount - 1)
                row(15) = pub_SumarColumnaGridCheck(DGrid, 15, DGrid.RowCount - 1)
                row(16) = pub_SumarColumnaGridCheck(DGrid, 16, DGrid.RowCount - 1)

                row(17) = pub_SumarColumnaGridCheck(DGrid, 17, DGrid.RowCount - 1)

                dt.Rows.InsertAt(row, 0)
                DGrid.DataSource = dt
                Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                    objDataSet1 = objCuentas.usp_TraerLiquidacion(idLiquidacion, "1900-01-01", "1900-01-01", "INSERT INTO clasificacion (status) VALUES ('AP'), ('RV'), ('GE')", "INSERT INTO clasificacionB (status) VALUES ('AP'), ('RV'), ('GE')", "INSERT INTO clasificacionB (status) VALUES ('AP'), ('RV'), ('GE')", "INSERT INTO clasificacionB (status) VALUES ('AP'), ('RV'), ('GE')", "")
                End Using
                Dim Tipo As String = ""
                If objDataSet1.Tables(0).Rows.Count > 0 Then
                    Tipo = objDataSet1.Tables(0).Rows(0).Item("tipo").ToString
                End If
                DGrid.Columns(0).HeaderText = "Liquidación"
                If Tipo = "F" Or Tipo = "D" Or Tipo = "J" Or Tipo = "T" Then
                    DGrid.Columns(1).HeaderText = "Factura"
                    DGrid.Columns(5).HeaderText = "Fecha Factura"
                    Lbl_Factura.Text = "Buscar Factura"
                Else
                    DGrid.Columns(1).HeaderText = "Consignación"
                    DGrid.Columns(5).HeaderText = "Fecha Consignación"
                    Lbl_Factura.Text = "Buscar Consignación"
                    DGrid.Columns(7).Visible = False
                End If
                DGrid.Columns(2).HeaderText = "Folio Bulto"
                If OpcionLiquidacion <> 1 Then DGrid.Columns(3).Visible = False
                DGrid.Columns(3).HeaderText = "No. Pago"
                DGrid.Columns(4).HeaderText = "Estatus"
                DGrid.Columns(5).HeaderText = "Fecha"

                DGrid.Columns(7).HeaderText = "Vencimiento"
                DGrid.Columns(8).HeaderText = "N° Cheque"
                DGrid.Columns(9).HeaderText = "Proveedor"
                DGrid.Columns(10).HeaderText = "Subtotal"
                DGrid.Columns(11).HeaderText = "Gastos"
                DGrid.Columns(12).HeaderText = "Impuesto"
                DGrid.Columns(13).HeaderText = "Cargo"
                DGrid.Columns(14).HeaderText = "Credito"
                DGrid.Columns(15).HeaderText = "Descuento"
                DGrid.Columns(16).HeaderText = "Total"

                DGrid.Columns(17).DisplayIndex = 16
                DGrid.Columns(17).HeaderText = "Improcedente"

                DGrid.Columns(10).DefaultCellStyle.Format = "c"
                DGrid.Columns(11).DefaultCellStyle.Format = "c"
                DGrid.Columns(12).DefaultCellStyle.Format = "c"
                DGrid.Columns(13).DefaultCellStyle.Format = "c"
                DGrid.Columns(14).DefaultCellStyle.Format = "c"
                DGrid.Columns(15).DefaultCellStyle.Format = "c"
                DGrid.Columns(16).DefaultCellStyle.Format = "c"

                DGrid.Columns(17).DefaultCellStyle.Format = "c"


                DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                DGrid.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


                Btn_Regresar.Enabled = True
                DGrid.Columns(1).DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Columns(2).DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                DGrid.Rows(0).Frozen = True
                CancelarLiquidacionBultoToolStripMenuItem.Visible = False
                DetalleLiquidacionToolStripMenuItem.Visible = False
                MostrarDetalladoToolStripMenuItem.Visible = False
                MostrarDetalladoProvToolStripMenuItem.Visible = False
                Btn_Imprimir.Enabled = True
                For i As Integer = 0 To DGrid.Columns.Count - 1
                    DGrid.Columns(i).ReadOnly = True
                Next
                AgregarColumna()
                For i As Integer = 0 To DGrid.Rows.Count - 1
                    DGrid.Rows(i).Cells("selec").Value = DGrid.Rows(i).Cells("status").Value
                Next
                DGrid.Columns("selec").HeaderText = "Estatus"
                DGrid.Columns(4).Visible = False
                Lbl_IdLiquidacion.Text = "Liquidación: " + DGrid.Rows(1).Cells("idliquidacion").Value.ToString
                Lbl_IdLiquidacion.Visible = True
                Lbl_Factura.Visible = True
                Txt_Factura.Visible = True
                Txt_Factura.Text = ""
                If EstatusLiquidacion = "REVISION" Then
                    If DetalladoRevision = True Then
                        MostrarDetalladoToolStripMenuItem.Visible = False
                        MostrarDetalladoProvToolStripMenuItem.Visible = False
                        CancelarChequeToolStripMenuItem.Visible = False
                        DetalleFacturaToolStripMenuItem.Visible = True
                        ConsultarBultoToolStripMenuItem.Visible = True
                        VerFichaDepositoToolStripMenuItem.Visible = False
                        NotasCCProvToolStripMenuItem.Visible = False
                        NotasCCToolStripMenuItem.Visible = False
                        If GLB_Usuario = "FELIX" Or GLB_Usuario = "FELIXJ" Or GLB_Usuario <> "LORIS" Then
                            DGrid.Columns("selec").ReadOnly = False
                            Btn_Revisado.Enabled = True
                            Btn_Aplicar.Enabled = False
                        Else
                            DGrid.Columns("selec").ReadOnly = True
                            Btn_Revisado.Enabled = False
                            Btn_Aplicar.Enabled = True
                        End If
                        DGrid.Columns(1).Visible = True
                        DGrid.Columns(2).Visible = True
                        DGrid.Columns(6).Visible = True
                        DGrid.Columns(7).Visible = True
                    Else
                        DGrid.Columns("selec").ReadOnly = True
                        MostrarDetalladoToolStripMenuItem.Visible = True
                        MostrarDetalladoProvToolStripMenuItem.Visible = True
                        DetalleFacturaToolStripMenuItem.Visible = False
                        ConsultarBultoToolStripMenuItem.Visible = False
                        VerFichaDepositoToolStripMenuItem.Visible = False
                        NotasCCProvToolStripMenuItem.Visible = False
                        NotasCCToolStripMenuItem.Visible = False
                        DGrid.Columns(1).Visible = False
                        DGrid.Columns(2).Visible = False
                        DGrid.Columns(6).Visible = False
                        DGrid.Columns(7).Visible = False
                        DGrid.Columns("selec").Visible = False
                        Btn_Revisado.Enabled = False
                        'If GLB_Usuario = "FELIX" Or GLB_Usuario = "FELIXJ" Or GLB_Usuario <> "LORIS" Then
                        '    Btn_Revisado.Enabled = True
                        '    Btn_Aplicar.Enabled = False
                        'Else
                        Btn_Revisado.Enabled = True
                        Btn_Aplicar.Enabled = True
                        '  End If
                    End If
                DGrid.Columns("fecha").DisplayIndex = 4
            Else
                If EstatusLiquidacion = "PAGADO" Or EstatusLiquidacion = "CANCELADO" Then
                    DGrid.Columns("selec").ReadOnly = True
                    Btn_Aplicar.Enabled = False
                    Btn_Revisado.Enabled = False
                    If EstatusLiquidacion = "PAGADO" Then

                        If Tipo = "R" Then
                            ImprimirChequeToolStripMenuItem.Visible = False
                            CancelarChequeToolStripMenuItem.Visible = False
                            DGrid.Columns(8).Visible = False
                        Else
                            ImprimirChequeToolStripMenuItem.Visible = True
                            CancelarChequeToolStripMenuItem.Visible = True
                            DGrid.Columns(8).Visible = True
                        End If
                        ImprimirAnexoToolStripMenuItem.Visible = True
                        'ImprimirChequeToolStripMenuItem.Visible = True
                        ImprimirLiquidacionToolStripMenuItem.Visible = True
                        'CancelarChequeToolStripMenuItem.Visible = True
                        FichadeDepositoToolStripMenuItem.Visible = True
                        DetalleFacturaToolStripMenuItem.Visible = True
                        ConsultarBultoToolStripMenuItem.Visible = True
                        VerFichaDepositoToolStripMenuItem.Visible = True
                        NotasCCProvToolStripMenuItem.Visible = True
                        NotasCCToolStripMenuItem.Visible = True
                        If DetalladoRevision = True Then
                            MostrarDetalladoToolStripMenuItem.Visible = False
                            MostrarDetalladoProvToolStripMenuItem.Visible = False
                            DGrid.Columns(1).Visible = True
                            DGrid.Columns(2).Visible = True
                            DGrid.Columns("fecha").DisplayIndex = 5
                            DGrid.Columns("fechafactura").DisplayIndex = 6
                            DGrid.Columns("fecha").Frozen = True
                            DGrid.Columns("fecha").DefaultCellStyle.BackColor = Color.PowderBlue
                        Else
                            MostrarDetalladoToolStripMenuItem.Visible = True
                            MostrarDetalladoProvToolStripMenuItem.Visible = True
                            DGrid.Columns(1).Visible = False
                            DGrid.Columns(2).Visible = False
                            DGrid.Columns("fecha").Visible = False
                            DGrid.Columns("fechafactura").Visible = False
                        End If
                    Else
                        ImprimirAnexoToolStripMenuItem.Visible = False
                        ImprimirChequeToolStripMenuItem.Visible = False
                        ImprimirLiquidacionToolStripMenuItem.Visible = False
                        CancelarChequeToolStripMenuItem.Visible = False
                        FichadeDepositoToolStripMenuItem.Visible = False
                        DetalleFacturaToolStripMenuItem.Visible = False
                        ConsultarBultoToolStripMenuItem.Visible = False
                        VerFichaDepositoToolStripMenuItem.Visible = False
                        NotasCCProvToolStripMenuItem.Visible = False
                        NotasCCToolStripMenuItem.Visible = False
                        DGrid.Columns("fum").Visible = False
                        DGrid.Columns("nocheque").Visible = False
                        DGrid.Columns("fecha").DisplayIndex = 5
                        DGrid.Columns("fecha").Frozen = True
                        DGrid.Columns("fecha").DefaultCellStyle.BackColor = Color.PowderBlue
                    End If
                Else
                    DGrid.Columns("selec").ReadOnly = False
                    Btn_Aplicar.Enabled = False
                    Btn_Revisado.Enabled = True
                    DGrid.Columns("fum").Visible = False
                    DGrid.Columns("nocheque").Visible = False
                    DGrid.Columns("fecha").DisplayIndex = 5
                    DGrid.Columns("fecha").Frozen = True
                    DGrid.Columns("fecha").DefaultCellStyle.BackColor = Color.PowderBlue
                End If

            End If
                DGrid.Columns(0).Visible = False
                DGrid.Columns(1).Frozen = True
                DGrid.Columns(2).Frozen = True
            End If
                DGrid.RowHeadersVisible = False
            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            '  DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Public Function pub_SumarColumnaGridCheck(ByVal DGrid As DataGridView, ByVal Columna As Integer, Optional ByVal HastaRenglon As Integer = 0) As Decimal
        'mreyes 14/Febrero/2012 05:08 p.m.
        Try
            Dim Col As Integer = DGrid.CurrentCell.ColumnIndex

            pub_SumarColumnaGridCheck = 0
            For renglon As Integer = 0 To IIf(HastaRenglon = 0, DGrid.RowCount - 2, HastaRenglon)
                If IsNumeric(DGrid.Rows(renglon).Cells(Columna).Value) Then
                    If IsDBNull(DGrid.Rows(renglon).Cells("status").Value) Then Continue For
                    If DGrid.Rows(renglon).Cells("status").Value = 1 Then
                        pub_SumarColumnaGridCheck = (DGrid.Rows(renglon).Cells(Columna).Value) + pub_SumarColumnaGridCheck
                    End If
                End If
            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Public Function pub_SumarColumnaGridSC(ByVal DGrid As DataGridView, ByVal Columna As Integer, Optional ByVal HastaRenglon As Integer = 0) As Decimal
        'mreyes 14/Febrero/2012 05:08 p.m.
        Try
            Dim Col As Integer = DGrid.CurrentCell.ColumnIndex

            pub_SumarColumnaGridSC = 0
            For renglon As Integer = 0 To IIf(HastaRenglon = 0, DGrid.RowCount - 2, HastaRenglon)
                If IsNumeric(DGrid.Rows(renglon).Cells(Columna).Value) Then
                    If DGrid.Rows(renglon).Cells("status").Value <> "CANCELADO" Then
                        pub_SumarColumnaGridSC = (DGrid.Rows(renglon).Cells(Columna).Value) + pub_SumarColumnaGridSC
                    End If
                End If
            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Me.Close()
        Me.Dispose()
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


    Private Sub Btn_Regresar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Regresar.Click
        Try
            If Opcion = 2 Then
                DGrid.Columns.Remove(DGrid.Columns("selec"))

                DetalladoRevision = False
                idCuenta = 0
                Banco = ""
                Opcion = 1
                Prov = ""
                RellenaGrid(TipoB)
            Else
                If blnPagados = True Then
                    'DGrid.Columns.Remove(DGrid.Columns("selec"))
                    Opcion = 1
                    Est = "INSERT INTO clasificacion (status) VALUES ('GE'),('RV')"
                    Est1 = "INSERT INTO clasificacionb (status) VALUES ('GE'),('RV')"
                    Est2 = "INSERT INTO clasificacionbb (status) VALUES ('GE'),('RV')"
                    Est3 = "INSERT INTO clasificacionbbB (status) VALUES ('GE'),('RV')"
                    'FechaInib = "1900-01-01"
                    'FechaFinb = "1900-01-01"
                    DetalladoRevision = False
                    idCuenta = 0
                    Banco = ""
                    Prov = ""
                    RellenaGrid(TipoB)
                    blnPagados = False
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub AgregarColumna()
        'mreyes 21/Marzo/2012 09:52 a.m.

        Dim colImagen As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        colImagen.Name = "selec"
        colImagen.HeaderText = "Selec"
        colImagen.DisplayIndex = 200
        colImagen.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        colImagen.CellTemplate = New DataGridViewCheckBoxCell()
        ' añadir columna de imagen a la coleccion del grid 
        DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        ''DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DGrid.Columns.Add(colImagen)
        DGrid.Columns("selec").ReadOnly = False

    End Sub


    Private Sub DetalleLiquidacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetalleLiquidacionToolStripMenuItem.Click
        Try
            If DGrid.CurrentRow.Cells("status").Value = "REVISADO" Then
                EstatusLiquidacion = "REVISION"
                OpcionLiquidacion = 2
                idCuenta = 0
                Banco = ""
            Else
                EstatusLiquidacion = DGrid.CurrentRow.Cells("status").Value
                If EstatusLiquidacion = "PAGADO" Then
                    OpcionLiquidacion = 2
                    idCuenta = DGrid.CurrentRow.Cells("idcuenta").Value
                    Banco = DGrid.CurrentRow.Cells("banco").Value
                Else
                    OpcionLiquidacion = 1
                    idCuenta = 0
                    Banco = ""
                End If
            End If
            idLiquidacion = DGrid.CurrentRow.Cells("idliquidacion").Value
            Opcion = 2
            Prov = ""
            RellenaGrid(TipoB)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub CancelarLiquidacionBultoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelarLiquidacionBultoToolStripMenuItem.Click
        Try
            If DGrid.CurrentRow.Cells("status").Value.ToString.Trim = "PAGADO" Then
                MessageBox.Show("No se puede cancelar una Liquidación pagada", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If MessageBox.Show("Esta seguro de cancelar la Liquidación?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                idLiquidacion = DGrid.CurrentRow.Cells("idliquidacion").Value
                Dim blnCancelo As Boolean = False
                If DGrid.CurrentRow.Cells("tipo").Value.ToString.Trim = "FACTORAJE" Then
                    Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                        blnCancelo = objCuentas.usp_ActualizaEstatusLiquidacionFactoraje(1, idLiquidacion, "ZC", 0, 0, 0, 0, 0, 0, 0, 0, "", 0)
                    End Using
                    If blnCancelo = True Then
                        Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                            objDataSet = objCuentas.usp_TraerLiquidacionDetFactoraje(1, idLiquidacion, "")
                        End Using
                        For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                            Dim idFolio As String = objDataSet.Tables(0).Rows(i).Item("idfolio").ToString
                            Using objCuentas As New BCL.BCLCatalogoCuentas(GLB_ConStringCipSis)
                                objCuentas.usp_ActualizaPagoFactura(1, idFolio, 3, "", 0)
                            End Using
                        Next

                        MessageBox.Show("Liquidación cancelada correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Error al cancelar la Liquidación", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                    Prov = ""
                    RellenaGrid(TipoB)
                ElseIf DGrid.CurrentRow.Cells("tipo").Value.ToString.Trim = "TRANSFERENCIA" Then
                    Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                        blnCancelo = objCuentas.usp_ActualizaEstatusLiquidacionTransferencia(1, idLiquidacion, "ZC", 0, 0, 0, 0, 0, 0, 0, 0, "", 0)
                    End Using
                    If blnCancelo = True Then
                        Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                            objDataSet = objCuentas.usp_TraerLiquidacionDetTransferencia(1, idLiquidacion, "")
                        End Using
                        For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                            Dim idFolio As String = objDataSet.Tables(0).Rows(i).Item("idfolio").ToString
                            Using objCuentas As New BCL.BCLCatalogoCuentas(GLB_ConStringCipSis)
                                objCuentas.usp_ActualizaPagoFactura(1, idFolio, 3, "", 0)
                            End Using
                        Next

                        MessageBox.Show("Liquidación cancelada correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Error al cancelar la Liquidación", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                    Prov = ""
                    RellenaGrid(TipoB)
                Else
                    Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                        blnCancelo = objCuentas.usp_ActualizaEstatusLiquidacion(1, idLiquidacion, "ZC", 0, 0, 0, 0, 0, 0, 0, 0, "", 0)
                    End Using
                    If blnCancelo = True Then
                        Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                            objDataSet = objCuentas.usp_TraerLiquidacionDet(1, idLiquidacion, "")
                        End Using
                        For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                            Dim idFolio As String = objDataSet.Tables(0).Rows(i).Item("idfolio").ToString
                            Using objCuentas As New BCL.BCLCatalogoCuentas(GLB_ConStringCipSis)
                                objCuentas.usp_ActualizaPagoFactura(1, idFolio, 3, "", 0)
                            End Using
                        Next

                        MessageBox.Show("Liquidación cancelada correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Error al cancelar la Liquidación", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                    Prov = ""
                    RellenaGrid(TipoB)

                End If
                
            End If









        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub MostrarDetalladoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MostrarDetalladoToolStripMenuItem.Click
        Try
            OpcionLiquidacion = 1
            DetalladoRevision = True
            DGrid.Columns.Remove(DGrid.Columns("selec"))
            Opcion = 2
            Prov = ""
            RellenaGrid(TipoB)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub MostrarDetalladoProvToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MostrarDetalladoProvToolStripMenuItem.Click
        Try

            OpcionLiquidacion = 1
            DetalladoRevision = True
            DGrid.Columns.Remove(DGrid.Columns("selec"))
            Opcion = 2
            Prov = DGrid.CurrentRow.Cells("proveedor").Value.ToString.Substring(0, 3)
            RellenaGrid(TipoB)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGrid.CellFormatting
        Try
            If blbBooleano = True Then Exit Sub
            If Opcion = 1 Then
                If DGrid.DataSource Is Nothing Then
                    Exit Sub
                End If
                If DGrid.Columns(e.ColumnIndex).Name = "status" Then
                    If IsDBNull(DGrid.Rows(e.RowIndex).Cells("status").Value) Then Exit Sub
                    If DGrid.Rows(e.RowIndex).Cells("status").Value = "PAGADO" Then
                        DGrid.Rows(e.RowIndex).Cells("status").Style.BackColor = Color.GreenYellow
                        DGrid.Rows(e.RowIndex).Cells("status").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                    End If
                    If DGrid.Rows(e.RowIndex).Cells("status").Value = "CANCELADO" Then
                        DGrid.Rows(e.RowIndex).Cells("status").Style.BackColor = Color.Red
                        DGrid.Rows(e.RowIndex).Cells("status").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                    End If
                    If DGrid.Rows(e.RowIndex).Cells("status").Value = "GENERADO" Then
                        DGrid.Rows(e.RowIndex).Cells("status").Style.BackColor = Color.Yellow
                        DGrid.Rows(e.RowIndex).Cells("status").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                    End If
                    If DGrid.Rows(e.RowIndex).Cells("status").Value = "REVISADO" Then
                        DGrid.Rows(e.RowIndex).Cells("status").Style.BackColor = Color.PowderBlue
                        DGrid.Rows(e.RowIndex).Cells("status").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                    End If
                End If
                If DGrid.Columns(e.ColumnIndex).Name = "tipo" Then
                    If IsDBNull(DGrid.Rows(e.RowIndex).Cells("tipo").Value) Then Exit Sub
                    If DGrid.Rows(e.RowIndex).Cells("tipo").Value = "PAGOUNICO" Then
                        DGrid.Rows(e.RowIndex).Cells("tipo").Style.BackColor = Color.PeachPuff
                        DGrid.Rows(e.RowIndex).Cells("tipo").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                    End If
                    If DGrid.Rows(e.RowIndex).Cells("tipo").Value = "CONSIGNACIÓN" Then
                        DGrid.Rows(e.RowIndex).Cells("tipo").Style.BackColor = Color.MediumTurquoise
                        DGrid.Rows(e.RowIndex).Cells("tipo").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                    End If
                    If DGrid.Rows(e.RowIndex).Cells("tipo").Value = "PAGODIF" Then
                        DGrid.Rows(e.RowIndex).Cells("tipo").Style.BackColor = Color.Aqua
                        DGrid.Rows(e.RowIndex).Cells("tipo").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                    End If
                    If DGrid.Rows(e.RowIndex).Cells("tipo").Value = "FACTORAJE" Then
                        DGrid.Rows(e.RowIndex).Cells("tipo").Style.BackColor = Color.MistyRose
                        DGrid.Rows(e.RowIndex).Cells("tipo").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                    End If
                    If DGrid.Rows(e.RowIndex).Cells("tipo").Value = "TRANSFERENCIA" Then
                        DGrid.Rows(e.RowIndex).Cells("tipo").Style.BackColor = Color.Beige
                        DGrid.Rows(e.RowIndex).Cells("tipo").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                    End If

                End If
                DGrid.RowHeadersVisible = False
                DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            End If
            If Opcion = 2 Then
                If DGrid.Columns(e.ColumnIndex).Name <> "total" Then Exit Sub
                If IsDBNull(DGrid.Rows(e.RowIndex).Cells(0).Value) Then Exit Sub
                If DGrid.Rows(e.RowIndex).Cells("total").Value Is Nothing Then Exit Sub
                If DGrid.Rows(e.RowIndex).Cells("total").Value < 0 Then
                    DGrid.Rows(e.RowIndex).Cells("total").Style.BackColor = Color.Red
                    DGrid.Rows(e.RowIndex).Cells("total").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_CellContentClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.CellContentClick
        Try
            If Opcion = 2 Then
                If DGrid.CurrentCell.ColumnIndex = 17 Then
                    If EstatusLiquidacion = "REVISION" Then
                        If DGrid.CurrentCell.ReadOnly = False Then
                            If DetalladoRevision = True Then
                                If DGrid.CurrentCell.Value = False Then
                                    DGrid.CurrentRow.Cells("status").Value = 1
                                Else
                                    DGrid.CurrentRow.Cells("status").Value = 0
                                End If
                                Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
                                dt.Rows.RemoveAt(0)
                                Dim row As DataRow = dt.NewRow()
                                row(9) = "TOTAL: "

                                row(10) = pub_SumarColumnaGridCheck(DGrid, 10, DGrid.RowCount - 1)
                                row(11) = pub_SumarColumnaGridCheck(DGrid, 11, DGrid.RowCount - 1)
                                row(12) = pub_SumarColumnaGridCheck(DGrid, 12, DGrid.RowCount - 1)
                                row(13) = pub_SumarColumnaGridCheck(DGrid, 13, DGrid.RowCount - 1)
                                row(14) = pub_SumarColumnaGridCheck(DGrid, 14, DGrid.RowCount - 1)
                                row(15) = pub_SumarColumnaGridCheck(DGrid, 15, DGrid.RowCount - 1)
                                row(16) = pub_SumarColumnaGridCheck(DGrid, 16, DGrid.RowCount - 1)
                                dt.Rows.InsertAt(row, 0)
                                DGrid.DataSource = dt
                                DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
                                DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                                DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                                DGrid.Rows(0).Frozen = True
                            End If
                        End If
                    Else
                        If DGrid.CurrentCell.ReadOnly = False Then
                            If DGrid.CurrentRow.Cells("status").Value = False Then
                                DGrid.CurrentRow.Cells("status").Value = 1
                            Else
                                DGrid.CurrentRow.Cells("status").Value = 0
                            End If
                            'Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
                            'dt.Rows.RemoveAt(0)
                            'Dim row As DataRow = dt.NewRow()
                            'row(8) = "TOTAL: "


                            DGrid.Rows(0).Cells(10).Value = pub_SumarColumnaGridCheck(DGrid, 10, DGrid.RowCount - 1)
                            DGrid.Rows(0).Cells(11).Value = pub_SumarColumnaGridCheck(DGrid, 11, DGrid.RowCount - 1)
                            DGrid.Rows(0).Cells(12).Value = pub_SumarColumnaGridCheck(DGrid, 12, DGrid.RowCount - 1)
                            DGrid.Rows(0).Cells(13).Value = pub_SumarColumnaGridCheck(DGrid, 13, DGrid.RowCount - 1)
                            DGrid.Rows(0).Cells(14).Value = pub_SumarColumnaGridCheck(DGrid, 14, DGrid.RowCount - 1)
                            DGrid.Rows(0).Cells(15).Value = pub_SumarColumnaGridCheck(DGrid, 15, DGrid.RowCount - 1)
                            DGrid.Rows(0).Cells(16).Value = pub_SumarColumnaGridCheck(DGrid, 16, DGrid.RowCount - 1)
                            'dt.Rows.InsertAt(row, 0)
                            'DGrid.DataSource = dt
                            'DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
                            'DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            'DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                            'DGrid.Rows(0).Frozen = True
                        End If
                    End If
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick
        Try
            ImprimirChequeToolStripMenuItem.Enabled = True
            If Opcion = 1 Then
                If DGrid.CurrentRow.Cells(0).Value.ToString.Trim = "" Then Exit Sub
                Opcion = 2
                If DGrid.CurrentRow.Cells("status").Value = "REVISADO" Then
                    EstatusLiquidacion = "REVISION"
                    OpcionLiquidacion = 2
                    idCuenta = 0
                    Banco = ""
                Else
                    EstatusLiquidacion = DGrid.CurrentRow.Cells("status").Value
                    If EstatusLiquidacion = "PAGADO" Then
                        OpcionLiquidacion = 2
                        idCuenta = DGrid.CurrentRow.Cells("idcuenta").Value
                        If IsDBNull(DGrid.CurrentRow.Cells("banco").Value) Then
                            Banco = ""
                        Else
                            Banco = DGrid.CurrentRow.Cells("banco").Value
                        End If
                    Else
                        OpcionLiquidacion = 1
                        idCuenta = 0
                        Banco = ""
                    End If
                End If
                idLiquidacion = DGrid.CurrentRow.Cells("idLiquidacion").Value
                Prov = ""
                TipoB = DGrid.CurrentRow.Cells("tipo").Value
                RellenaGrid(TipoB)
            ElseIf Opcion = 2 And OpcionLiquidacion = 2 Then
                MostrarDetalladoProvToolStripMenuItem_Click(sender, e)
                ImprimirChequeToolStripMenuItem.Enabled = False
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
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

    Private Sub Btn_Revisado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Revisado.Click
        Dim objDataSetFacturas As New DataSet
        Dim objDataSetLiquidacionAux As New DataSet
        Dim EmpezoActualizar1 As Boolean = False
        Dim EmpezoActualizar2 As Boolean = False
        Try
            If TipoB = "FACTORAJE" Then
                If MessageBox.Show("Esta seguro que desea revisar la liquidación, para generar el factoraje?", "CONFIRMACIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If
            Else
                If MessageBox.Show("Esta seguro que desea revisar la liquidación?", "CONFIRMACIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If
            End If
            Dim sumSubTotal As Double = 0
            Dim sumGastos As Double = 0
            Dim sumImpuesto As Double = 0
            Dim sumCargo As Double = 0
            Dim sumCredito As Double = 0
            Dim sumDescuento As Double = 0
            Dim sumTotal As Double = 0
            Dim idLiquidacion As Integer = 0
            'Dim idCuenta As Integer = CInt(CBO_Cuentas.SelectedValue.ToString)
            ''Suma los importes
            idLiquidacion = DGrid.Rows(1).Cells("idliquidacion").Value

            'Dim NoPago As Integer = Mid(DGrid.Rows(1).Cells("pago").Value, 1, 1)

            If TipoB = "FACTORAJE" Then
                Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                    objDataSetFacturas = objCuentas.usp_TraerLiquidacionDetalleFactoraje(4, idLiquidacion, "")
                End Using
                Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                    objDataSetLiquidacionAux = objCuentas.usp_TraerLiquidacionDetalleFactoraje(5, idLiquidacion, "")
                End Using
            ElseIf TipoB = "PAGOUNICO" Or TipoB = "CONSIGNACIÓN" Then
                Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                    objDataSetFacturas = objCuentas.usp_TraerLiquidacionDetalle(4, idLiquidacion, "")
                End Using
                Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                    objDataSetLiquidacionAux = objCuentas.usp_TraerLiquidacionDetalle(5, idLiquidacion, "")
                End Using
            ElseIf TipoB = "PAGODIF" Then
                Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                    objDataSetFacturas = objCuentas.usp_TraerLiquidacionDetalleDiferidos(4, idLiquidacion, "")
                End Using
                Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                    objDataSetLiquidacionAux = objCuentas.usp_TraerLiquidacionDetalleDiferidos(5, idLiquidacion, "")
                End Using
            ElseIf TipoB = "TRANSFERENCIA" Then
                Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                    objDataSetFacturas = objCuentas.usp_TraerLiquidacionDetalleTRANSFERENCIA(4, idLiquidacion, "")
                End Using
                Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                    objDataSetLiquidacionAux = objCuentas.usp_TraerLiquidacionDetalleTRANSFERENCIA(5, idLiquidacion, "")
                End Using
            End If
            For i As Integer = 0 To DGrid.Rows.Count - 2
                If IsDBNull(DGrid.Rows(i).Cells("selec").Value) Then Continue For
                If CBool(DGrid.Rows(i).Cells("selec").Value) = True Then
                    Dim subtotal As Double = DGrid.Rows(i).Cells("subtotal").Value
                    Dim gastos As Double = DGrid.Rows(i).Cells("gastos").Value
                    Dim impuesto As Double = DGrid.Rows(i).Cells("impuesto").Value
                    Dim cargo As Double = DGrid.Rows(i).Cells("cargo").Value
                    Dim credito As Double = DGrid.Rows(i).Cells("credito").Value
                    Dim descuento As Double = DGrid.Rows(i).Cells("descuento").Value
                    Dim Total As Double = DGrid.Rows(i).Cells("total").Value
                    Dim idFolio As String = DGrid.Rows(i).Cells("idfolio").Value
                    Dim NoPago As Integer = Mid(DGrid.Rows(i).Cells("pago").Value, 1, 1)
                    sumSubTotal += subtotal
                    sumGastos += gastos
                    sumImpuesto += impuesto
                    sumCargo += cargo
                    sumCredito += credito
                    sumDescuento += descuento
                    sumTotal += Total
                    If TipoB = "PAGOUNICO" Or TipoB = "CONSIGNACIÓN" Then
                        Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                            objCuentas.usp_ActualizaLiquidacionDet(1, idLiquidacion, idFolio, "", 1, "")
                        End Using
                    ElseIf TipoB = "FACTORAJE" Then
                        Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                            objCuentas.usp_ActualizaLiquidacionDetFactoraje(1, idLiquidacion, idFolio, "", 1, "")
                        End Using
                        'Using objCatCuentas As New BCL.BCLCatalogoCuentas(GLB_ConStringCipSis)
                        '    If Not objCatCuentas.usp_GeneraFactprovFactoraje(Mid(DGrid.Rows(i).Cells("PROVEEDOR").Value.ToString.Trim(), 1, 3), DGrid.Rows(i).Cells("idfolio").Value.ToString.Trim()) Then
                        '        'Throw New Exception("No se pudo actualizar el Estatus.")
                        '    Else
                        '        'MsgBox("Estatus Actualizado correctamente.", MsgBoxStyle.Information, "Confirmación")
                        '    End If
                        ' End Using
                    ElseIf TipoB = "PAGODIF" Then
                        Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                            objCuentas.usp_ActualizaLiquidacionDetDiferidos(1, idLiquidacion, idFolio, "", 1, "", NoPago)
                        End Using
                    ElseIf TipoB = "TRANSFERENCIA" Then
                        Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                            objCuentas.usp_ActualizaLiquidacionDetTransferencia(1, idLiquidacion, idFolio, "", 1, "")
                        End Using
                    End If
                    EmpezoActualizar1 = True
                    If TipoB = "PAGOUNICO" Or TipoB = "PAGODIF" Or TipoB = "CONSIGNACIÓN" Or TipoB = "TRANSFERENCIA" Then
                        Using objCuentas As New BCL.BCLCatalogoCuentas(GLB_ConStringCipSis)
                            objCuentas.usp_ActualizaPagoFactura(1, idFolio, 5, "", 0)
                        End Using
                    End If
                    'ACTUALIZAR FACTORAJES
                    If TipoB = "FACTORAJE" Then
                        Using objCatCuentas As New BCL.BCLCatalogoCuentas(GLB_ConStringCipSis)

                            If Not objCatCuentas.usp_GeneraFactprovFactoraje(Mid(DGrid.Rows(i).Cells("PROVEEDOR").Value.ToString.Trim(), 1, 3), pub_TraerIdFolioBulto(DGrid.Rows(i).Cells("idfolio").Value.ToString.Trim())) Then
                                'Throw New Exception("No se pudo actualizar el Estatus.")
                            Else
                                'MsgBox("Estatus Actualizado correctamente.", MsgBoxStyle.Information, "Confirmación")
                            End If
                        End Using
                    End If
                    System.GC.Collect()
                Else
                    If DGrid.Rows(i).Cells("selec").Value Is Nothing Then Continue For
                    Dim idFolio As String = DGrid.Rows(i).Cells("idfolio").Value
                    If TipoB = "FACTORAJE" Then
                        Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                            objCuentas.usp_ActualizaLiquidacionDetFactoraje(1, idLiquidacion, idFolio, "", 0, "")
                        End Using
                        Using objCuentas As New BCL.BCLCatalogoCuentas(GLB_ConStringCipSis)
                            objCuentas.usp_ActualizaPagoFactura(1, idFolio, 3, "", 0)
                        End Using
                    ElseIf TipoB = "PAGOUNICO" Then
                        Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                            objCuentas.usp_ActualizaLiquidacionDet(1, idLiquidacion, idFolio, "", 0, "")
                        End Using
                        Using objCuentas As New BCL.BCLCatalogoCuentas(GLB_ConStringCipSis)
                            objCuentas.usp_ActualizaPagoFactura(1, idFolio, 3, "", 0)
                        End Using
                    ElseIf TipoB = "TRANSFERENCIA" Then
                        Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                            objCuentas.usp_ActualizaLiquidacionDetTransferencia(1, idLiquidacion, idFolio, "", 0, "")
                        End Using
                        Using objCuentas As New BCL.BCLCatalogoCuentas(GLB_ConStringCipSis)
                            objCuentas.usp_ActualizaPagoFactura(1, idFolio, 3, "", 0)
                        End Using
                    Else
                        Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                            objCuentas.usp_ActualizaLiquidacionDetDiferidos(1, idLiquidacion, idFolio, "", 0, "", 0)
                        End Using
                        Using objCuentas As New BCL.BCLCatalogoCuentas(GLB_ConStringCipSis)
                            objCuentas.usp_ActualizaPagoFactura(1, idFolio, 3, "", 0)
                        End Using
                    End If
                End If
            Next
            Dim encabezado As Boolean = False
            ''CAMBIA EL ENCABEZADO
            If TipoB = "FACTORAJE" Then
                Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                    encabezado = objCuentas.usp_ActualizaEstatusLiquidacionFactoraje(2, idLiquidacion, "RV", 0, sumSubTotal, sumGastos, sumImpuesto, sumCargo, sumCredito, sumDescuento, sumTotal, Now.ToString("yyyy-MM-dd HH:mm:ss"), GLB_Idempleado)
                End Using
            ElseIf TipoB = "PAGOUNICO" Or TipoB = "CONSIGNACIÓN" Then
                Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                    encabezado = objCuentas.usp_ActualizaEstatusLiquidacion(2, idLiquidacion, "RV", 0, sumSubTotal, sumGastos, sumImpuesto, sumCargo, sumCredito, sumDescuento, sumTotal, Now.ToString("yyyy-MM-dd HH:mm:ss"), GLB_Idempleado)
                End Using
            ElseIf TipoB = "PAGODIF" Then
                Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                    encabezado = objCuentas.usp_ActualizaEstatusLiquidacionDiferidos(2, idLiquidacion, "RV", 0, sumSubTotal, sumGastos, sumImpuesto, sumCargo, sumCredito, sumDescuento, sumTotal, Now.ToString("yyyy-MM-dd HH:mm:ss"), GLB_Idempleado)
                End Using
            ElseIf TipoB = "TRANSFERENCIA" Then
                Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                    encabezado = objCuentas.usp_ActualizaEstatusLiquidacionTransferencia(2, idLiquidacion, "RV", 0, sumSubTotal, sumGastos, sumImpuesto, sumCargo, sumCredito, sumDescuento, sumTotal, Now.ToString("yyyy-MM-dd HH:mm:ss"), GLB_Idempleado)
                End Using
            End If
            If encabezado = False Then
                MessageBox.Show("Error al guardar, por favor intenta de nuevo", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            'no se si aplica saldos.

            MessageBox.Show("Liquidación revisada correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            EmpezoActualizar1 = False
            EmpezoActualizar2 = False
            Btn_Regresar_Click_1(sender, e)
        Catch ExceptionErr As Exception
            Try
                If EmpezoActualizar1 = True Then
                    For i As Integer = 0 To objDataSetFacturas.Tables(0).Rows.Count - 1
                        Using objCuentas As New BCL.BCLCatalogoCuentas(GLB_ConStringCipSis)
                            objCuentas.usp_ActualizaPagoFactura(1, objDataSetFacturas.Tables(0).Rows(i).Item("idfoliosuc").ToString, objDataSetFacturas.Tables(0).Rows(i).Item("pagado").ToString, "", 0)
                        End Using
                    Next
                    For i As Integer = 0 To objDataSetLiquidacionAux.Tables(0).Rows.Count - 1

                        Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                            If TipoB = "FACTORAJE" Then
                                objCuentas.usp_ActualizaLiquidacionDetFactoraje(1, objDataSetLiquidacionAux.Tables(0).Rows(i).Item("idliquidacion").ToString, objDataSetLiquidacionAux.Tables(0).Rows(i).Item("idfolio").ToString, "", objDataSetLiquidacionAux.Tables(0).Rows(i).Item("status").ToString, "")
                            ElseIf TipoB = "PAGOUNICO" Then
                                objCuentas.usp_ActualizaLiquidacionDet(1, objDataSetLiquidacionAux.Tables(0).Rows(i).Item("idliquidacion").ToString, objDataSetLiquidacionAux.Tables(0).Rows(i).Item("idfolio").ToString, "", objDataSetLiquidacionAux.Tables(0).Rows(i).Item("status").ToString, "")
                            ElseIf TipoB = "PAGODIF" Then
                                objCuentas.usp_ActualizaLiquidacionDetDiferidos(1, objDataSetLiquidacionAux.Tables(0).Rows(i).Item("idliquidacion").ToString, objDataSetLiquidacionAux.Tables(0).Rows(i).Item("idfolio").ToString, "", objDataSetLiquidacionAux.Tables(0).Rows(i).Item("status").ToString, "", Mid(objDataSetLiquidacionAux.Tables(0).Rows(i).Item("pago").ToString, 1, 1))

                            ElseIf TipoB = "TRANSFERENCIA" Then
                                objCuentas.usp_ActualizaLiquidacionDetTransferencia(1, objDataSetLiquidacionAux.Tables(0).Rows(i).Item("idliquidacion").ToString, objDataSetLiquidacionAux.Tables(0).Rows(i).Item("idfolio").ToString, "", objDataSetLiquidacionAux.Tables(0).Rows(i).Item("status").ToString, "")
                            End If
                        End Using
                    Next
                End If
                If EmpezoActualizar2 = True Then
                    Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                        If TipoB = "FACTORAJE" Then
                            objCuentas.usp_ActualizaEstatusLiquidacionFactoraje(1, DGrid.Rows(1).Cells("idliquidacion").Value, "GE", 0, 0, 0, 0, 0, 0, 0, 0, "", 0)
                        ElseIf TipoB = "PAGOUNICO" Then
                            objCuentas.usp_ActualizaEstatusLiquidacion(1, DGrid.Rows(1).Cells("idliquidacion").Value, "GE", 0, 0, 0, 0, 0, 0, 0, 0, "", 0)
                        ElseIf TipoB = "PAGODIF" Then
                            objCuentas.usp_ActualizaEstatusLiquidacionDiferidos(1, DGrid.Rows(1).Cells("idliquidacion").Value, "GE", 0, 0, 0, 0, 0, 0, 0, 0, "", 0)
                        ElseIf TipoB = "TRANSFERENCIA" Then
                            objCuentas.usp_ActualizaEstatusLiquidacionTransferencia(1, DGrid.Rows(1).Cells("idliquidacion").Value, "GE", 0, 0, 0, 0, 0, 0, 0, 0, "", 0)
                        End If
                    End Using
                End If
                MessageBox.Show("Error al hacer los cambios, por favor vuelve a intentarlo", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                MessageBox.Show(ExceptionErr.Message.ToString)
            Catch ExceptionErr1 As Exception
                MessageBox.Show(ExceptionErr1.Message.ToString)
            End Try
        End Try
    End Sub

    Private Sub Btn_Aplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aplicar.Click
        Try
            Dim contador As Integer = 0
            Dim objDataSetLiquidacion As New DataSet
            objDataSetLiquidacion = objDataSet.Clone
            If MessageBox.Show("Esta seguro que desea pagar la Liquidación", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            If DetalladoRevision = False Then
                If TipoB = "PAGOUNICO" Or TipoB = "CONSIGNACIÓN" Then
                    Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                        objDataSet = objCuentas.usp_TraerLiquidacionDet(1, idLiquidacion, "")
                    End Using
                ElseIf TipoB = "PAGODIF" Then
                    Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                        objDataSet = objCuentas.usp_TraerLiquidacionDetDiferidos(1, idLiquidacion, "")
                    End Using
                ElseIf TipoB = "FACTORAJE" Then
                    Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                        objDataSet = objCuentas.usp_TraerLiquidacionDetFactoraje(1, idLiquidacion, "")
                    End Using
                ElseIf TipoB = "TRANSFERENCIA" Then
                    Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                        objDataSet = objCuentas.usp_TraerLiquidacionDetTransferencia(1, idLiquidacion, "")
                    End Using
                End If
            End If
            For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                If objDataSet.Tables(0).Rows(i).Item("status").ToString.Trim = "" Then Continue For
                'If CBool(objDataSet.Tables(0).Rows(i).Item("status").ToString) = True Then
                objDataSetLiquidacion.Tables(0).LoadDataRow(objDataSet.Tables(0).Rows(i).ItemArray, True)
                contador += 1
                'End If
            Next

            If TipoB = "PAGOUNICO" Or TipoB = "CONSIGNACIÓN" Then
                Dim myForm As New frmLiquidacion

                myForm.objDataSetLiquidacion = objDataSetLiquidacion
                myForm.DT_FecVencimientoIni.Visible = False
                myForm.DT_FecVencimientoFin.Visible = False
                myForm.Label5.Visible = False
                myForm.Label8.Visible = False
                myForm.Txt_Proveedor.Visible = False
                myForm.Txt_Raz_Soc.Visible = False
                myForm.Chk_Fechas.Visible = False
                myForm.blnAplicar = True
                Dim Tipo As String = ""
                Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                    objDataSet1 = objCuentas.usp_TraerLiquidacion(idLiquidacion, "1900-01-01", "1900-01-01", "INSERT INTO clasificacion (status) VALUES ('RV')", "INSERT INTO clasificacionB (status) VALUES ('RV')", "INSERT INTO clasificacionB (status) VALUES ('RV')", "INSERT INTO clasificacionB (status) VALUES ('RV')", "")
                End Using
                If objDataSet1.Tables(0).Rows.Count > 0 Then
                    Tipo = objDataSet1.Tables(0).Rows(0).Item("tipo").ToString
                End If
                Dim objDataSetProveedores As New DataTable
                If Tipo.Trim = "F" Then
                    myForm.ShowDialog()
                Else
                    myForm.PagarRemision = True
                    myForm.Show()
                End If
            ElseIf TipoB = "PAGODIF" Then
                Dim myForm As New frmLiquidacionDiferidos

                myForm.objDataSetLiquidacion = objDataSetLiquidacion
                myForm.DT_FecVencimientoIni.Visible = False
                myForm.DT_FecVencimientoFin.Visible = False
                myForm.Label5.Visible = False
                myForm.Label8.Visible = False
                myForm.Txt_Proveedor.Visible = False
                myForm.Txt_Raz_Soc.Visible = False
                myForm.Chk_Fechas.Visible = False
                myForm.blnAplicar = True
                Dim Tipo As String = ""
                Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                    objDataSet1 = objCuentas.usp_TraerLiquidacionDiferidos(idLiquidacion, "1900-01-01", "1900-01-01", "INSERT INTO clasificacion (status) VALUES ('RV')", "INSERT INTO clasificacionB (status) VALUES ('RV')", "INSERT INTO clasificacionBB (status) VALUES ('RV')", "")
                End Using
                If objDataSet1.Tables(0).Rows.Count > 0 Then
                    Tipo = objDataSet1.Tables(0).Rows(0).Item("tipo").ToString
                End If
                Dim objDataSetProveedores As New DataTable
                If Tipo.Trim = "F" Or Tipo.Trim = "J" Or Tipo.Trim = "D" Then
                    myForm.ShowDialog()
                Else
                    myForm.PagarRemision = True
                    myForm.Show()
                End If
            ElseIf TipoB = "FACTORAJE" Then
                Dim myForm As New frmLiquidacionFactoraje

                myForm.objDataSetLiquidacion = objDataSetLiquidacion
                myForm.DT_FecVencimientoIni.Visible = False
                myForm.DT_FecVencimientoFin.Visible = False
                myForm.Label5.Visible = False
                myForm.Label8.Visible = False
                myForm.Txt_Proveedor.Visible = False
                myForm.Txt_Raz_Soc.Visible = False
                myForm.Chk_Fechas.Visible = False
                myForm.blnAplicar = True
                Dim Tipo As String = ""
                Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                    objDataSet1 = objCuentas.usp_TraerLiquidacion(idLiquidacion, "1900-01-01", "1900-01-01", "INSERT INTO clasificacion (status) VALUES ('RV')", "INSERT INTO clasificacionB (status) VALUES ('RV')", "INSERT INTO clasificacionB (status) VALUES ('RV')", "INSERT INTO clasificacionB (status) VALUES ('RV')", "")
                End Using
                If objDataSet1.Tables(0).Rows.Count > 0 Then
                    Tipo = objDataSet1.Tables(0).Rows(0).Item("tipo").ToString
                End If
                Dim objDataSetProveedores As New DataTable
                If Tipo.Trim = "F" Then
                    myForm.ShowDialog()
                Else
                    myForm.PagarRemision = True
                    myForm.Show()
                End If
            ElseIf TipoB = "TRANSFERENCIA" Then
                Dim myForm As New frmLiquidacionTransferencia

                myForm.objDataSetLiquidacion = objDataSetLiquidacion
                myForm.DT_FecVencimientoIni.Visible = False
                myForm.DT_FecVencimientoFin.Visible = False
                myForm.Label5.Visible = False
                myForm.Label8.Visible = False
                myForm.Txt_Proveedor.Visible = False
                myForm.Txt_Raz_Soc.Visible = False
                myForm.Chk_Fechas.Visible = False
                myForm.blnAplicar = True
                Dim Tipo As String = ""
                Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                    objDataSet1 = objCuentas.usp_TraerLiquidacionTransferencia(idLiquidacion, "1900-01-01", "1900-01-01", "INSERT INTO clasificacion (status) VALUES ('RV')", "INSERT INTO clasificacionB (status) VALUES ('RV')", "INSERT INTO clasificacionBB (status) VALUES ('RV')", "")
                End Using
                If objDataSet1.Tables(0).Rows.Count > 0 Then
                    Tipo = objDataSet1.Tables(0).Rows(0).Item("tipo").ToString
                End If
                Dim objDataSetProveedores As New DataTable
                If Tipo.Trim = "F" Or Tipo.Trim = "J" Or Tipo.Trim = "T" Then
                    myForm.ShowDialog()
                Else
                    myForm.PagarRemision = True
                    myForm.Show()
                End If
            End If
            Btn_Regresar_Click_1(sender, e)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ImprimirChequeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimirChequeToolStripMenuItem.Click
        Try
            If DGrid.CurrentRow.Cells("nocheque").Value.ToString.Trim = "" Then Exit Sub
            OpcionReporte = 3
            Btn_Imprimir_Click(sender, e)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ImprimirAnexoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimirAnexoToolStripMenuItem.Click
        Try
            OpcionReporte = 2
            Prov = DGrid.CurrentRow.Cells("Proveedor").Value.ToString.Trim
            Btn_Imprimir_Click(sender, e)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ImprimirLiquidacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimirLiquidacionToolStripMenuItem.Click
        Try
            OpcionReporte = 1
            Btn_Imprimir_Click(sender, e)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ImprimirReporte()
        Try
            Dim myForm As New frmReportsBrowser

            myForm.objDataSetLiquidacion = GenerarReporte()

            If EstatusLiquidacion = "GENERADO" Then
                myForm.Observaciones = "Reporte de Liquidación GENERADA"

            ElseIf EstatusLiquidacion = "REVISADO" Then
                myForm.Observaciones = "Reporte de Liquidación REVISADO"
            ElseIf EstatusLiquidacion = "PAGADO" Then
                myForm.Observaciones = "Reporte de Liquidación PAGADA"

            End If
            myForm.TipoRecibo = TipoB
            myForm.ReportIndex = 12
            myForm.Show()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Function GenerarReporte() As DSPLiqfinal
        'Roberto 04/03/13
        Try
            GenerarReporte = New DSPLiqfinal
            With DGrid
                For I As Integer = 1 To .Rows.Count - 2

                    If .Rows(I).Cells("Selec").Value = 1 Then
                        Dim objDataRow As Data.DataRow = GenerarReporte.Tables(0).NewRow()
                        objDataRow.Item("factura") = .Rows(I).Cells(1).Value
                        objDataRow.Item("idfolio") = .Rows(I).Cells(2).Value
                        objDataRow.Item("NOPAGO") = .Rows(I).Cells(3).Value

                        objDataRow.Item("fum") = .Rows(I).Cells(5).Value
                        objDataRow.Item("fecfact") = .Rows(I).Cells(6).Value
                        objDataRow.Item("fecha") = .Rows(I).Cells(7).Value
                        objDataRow.Item("nocheque") = .Rows(I).Cells(8).Value
                        objDataRow.Item("proveedor") = .Rows(I).Cells(9).Value
                        objDataRow.Item("subtotal") = .Rows(I).Cells(10).Value
                        objDataRow.Item("gastos") = .Rows(I).Cells(11).Value
                        objDataRow.Item("impuesto") = .Rows(I).Cells(12).Value
                        objDataRow.Item("cargo") = .Rows(I).Cells(13).Value
                        objDataRow.Item("credito") = .Rows(I).Cells(14).Value
                        objDataRow.Item("descuento") = .Rows(I).Cells(15).Value
                        objDataRow.Item("total") = .Rows(I).Cells(16).Value
                        objDataRow.Item("liquidacion") = .Rows(I).Cells(0).Value

                        objDataRow.Item("improcedente") = .Rows(I).Cells("improcedente").Value

                        'objDataRow.Item("suma") = suma
                        GenerarReporte.Tables(0).Rows.Add(objDataRow)

                    End If
                Next

            End With
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Private Sub Btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Imprimir.Click
        Try
            If OpcionReporte = 1 Then
                Call ImprimirReporte()
            ElseIf OpcionReporte = 2 Then
                Call ImprimirReporte2()
            ElseIf OpcionReporte = 3 Then
                Call ImprimirReporte3()
            Else
                Call ImprimirReporte()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ImprimirReporte2()
        '--   'Juan galvan 08-07-13
        Try

            'anexos
            Dim myForm2 As New frmReportsBrowser
            myForm2.objDataSetChequeProveedoresAnexos = GenerarDSChequeProveedores(1)
            myForm2.ReportIndex = 41
            myForm2.Show()
            If DetalladoRevision = False Then
                Dim myForm3 As New frmReportsBrowser
                If DGrid.CurrentRow.Cells("nocheque").Value.ToString.Trim = "" Then Exit Sub
                myForm3.objDataSetChequeProveedoresAnexos = GenerarDSChequeProveedores(2)
                myForm3.ReportIndex = 41
                myForm3.Show()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub ImprimirReporte3()
        '--   'Juan galvan 08-07-13
        Try
            ' cheque poliza
            Dim myForm As New frmReportsBrowser
            myForm.objDataSetChequeProveedores = GenerarDSChequeProveedores2()
            myForm.ReportIndex = 40
            myForm.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try

    End Sub
    '''''
    Private Function GenerarDSChequeProveedores(ByVal OpcionCheck As Integer) As DSChequeProvedor
        'Juan galvan 08-07-13
        Try
            If OpcionCheck = 1 Then


                Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                    objDataSet = objCuentas.usp_TraerLiquidacionDet(1, idLiquidacion, "")
                End Using
                GenerarDSChequeProveedores = New DSChequeProvedor
                For I As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                    If (objDataSet.Tables(0).Rows(I).Item("status").ToString() = 1) Then
                        If Prov = objDataSet.Tables(0).Rows(I).Item("proveedor").ToString.Trim Then
                            Dim objDataRow1 As Data.DataRow
                            objDataRow1 = GenerarDSChequeProveedores.Tables("Tlb_ChequeProveedor").NewRow()
                            objDataRow1.Item("nomEmp") = objDataSet.Tables(0).Rows(I).Item("proveedor").ToString() 'objDataSet.Tables(0).Rows(I).Item("proveedor").ToString() '.Rows(I).Cells(2).Value
                            objDataRow1.Item("total") = objDataSet.Tables(0).Rows(I).Item("total").ToString() '58314.53 '.Rows(I).Cells(0).Value
                            objDataRow1.Item("noCheque") = objDataSet.Tables(0).Rows(I).Item("nocheque").ToString()  ' 4292 '.Rows(I).Cells(9).Value
                            objDataRow1.Item("CPFactura") = objDataSet.Tables(0).Rows(I).Item("factura").ToString() ' "000081319" + I.ToString  '.Rows(I).Cells(10).Value

                            objDataRow1.Item("fechafactura") = objDataSet.Tables(0).Rows(I).Item("fechafactura").ToString() '.Rows(I).Cells(3).Value
                            objDataRow1.Item("subtotal") = objDataSet.Tables(0).Rows(I).Item("subtotal").ToString()  'CDbl(Int((4120 * Rnd()) + 1)) '.Rows(I).Cells(6).Value
                            objDataRow1.Item("descuento") = objDataSet.Tables(0).Rows(I).Item("descuento").ToString()  '.Rows(I).Cells(7).Value
                            objDataRow1.Item("gastos") = objDataSet.Tables(0).Rows(I).Item("gastos").ToString()  'CDbl(Int((2006 * Rnd()) + 1)) '.Rows(I).Cells(4).Value
                            objDataRow1.Item("impuesto") = objDataSet.Tables(0).Rows(I).Item("impuesto").ToString()
                            '  idfolio
                            objDataRow1.Item("folioBultos") = objDataSet.Tables(0).Rows(I).Item("idfolio").ToString()
                            objDataRow1.Item("fecha") = objDataSet.Tables(0).Rows(I).Item("fum").ToString()
                            objDataRow1.Item("Liquidacion") = objDataSet.Tables(0).Rows(I).Item("idliquidacion").ToString()
                            objDataRow1.Item("Vencido") = objDataSet.Tables(0).Rows(I).Item("fecha").ToString()

                            objDataRow1.Item("cargo") = objDataSet.Tables(0).Rows(I).Item("cargo").ToString() 'objDataSet.Tables(0).Rows(I).Item("cargo").ToString() 'objDataSet.Tables(0).Rows(I).Item("cargo").ToString()
                            objDataRow1.Item("credito") = objDataSet.Tables(0).Rows(I).Item("credito").ToString() ' objDataSet.Tables(0).Rows(I).Item("credito").ToString() 'objDataSet.Tables(0).Rows(I).Item("credito").ToString()

                            objDataRow1.Item("improcedente") = objDataSet.Tables(0).Rows(I).Item("improcedente").ToString()


                            GenerarDSChequeProveedores.Tables("Tlb_ChequeProveedor").Rows.Add(objDataRow1)
                        End If
                    End If
                Next
            End If
            If OpcionCheck = 2 Then
                GenerarDSChequeProveedores = New DSChequeProvedor
                With DGrid
                    ' For I As Integer = 1 To .Rows.Count - 2

                    Dim objDataRow1 As Data.DataRow
                    objDataRow1 = GenerarDSChequeProveedores.Tables("Tlb_ChequeProveedor").NewRow()
                    objDataRow1.Item("nomEmp") = DGrid.CurrentRow.Cells("proveedor").Value  'objDataSet.Tables(0).Rows(I).Item("proveedor").ToString() '.Rows(I).Cells(2).Value
                    objDataRow1.Item("total") = DGrid.CurrentRow.Cells("total").Value '58314.53 '.Rows(I).Cells(0).Value
                    objDataRow1.Item("noCheque") = DGrid.CurrentRow.Cells("nocheque").Value  ' 4292 '.Rows(I).Cells(9).Value
                    objDataRow1.Item("CPFactura") = DGrid.CurrentRow.Cells("factura").Value ' "000081319" + I.ToString  '.Rows(I).Cells(10).Value

                    objDataRow1.Item("fechafactura") = DGrid.CurrentRow.Cells("fechafactura").Value '.Rows(I).Cells(3).Value
                    objDataRow1.Item("subtotal") = DGrid.CurrentRow.Cells("subtotal").Value  'CDbl(Int((4120 * Rnd()) + 1)) '.Rows(I).Cells(6).Value
                    objDataRow1.Item("descuento") = DGrid.CurrentRow.Cells("descuento").Value  '.Rows(I).Cells(7).Value
                    objDataRow1.Item("gastos") = DGrid.CurrentRow.Cells("gastos").Value  'CDbl(Int((2006 * Rnd()) + 1)) '.Rows(I).Cells(4).Value
                    objDataRow1.Item("impuesto") = DGrid.CurrentRow.Cells("impuesto").Value
                    '  idfolio
                    objDataRow1.Item("folioBultos") = DGrid.CurrentRow.Cells("idfolio").Value
                    objDataRow1.Item("fecha") = DGrid.CurrentRow.Cells("fum").Value
                    objDataRow1.Item("Liquidacion") = DGrid.CurrentRow.Cells("idliquidacion").Value

                    objDataRow1.Item("cargo") = DGrid.CurrentRow.Cells("cargo").Value
                    objDataRow1.Item("credito") = DGrid.CurrentRow.Cells("credito").Value


                    objDataRow1.Item("improcedente") = DGrid.CurrentRow.Cells("improcedente").Value
                    'GenerarDSChequeProveedores2.Tables(0).Rows.Add(objDataRow1)
                    'GenerarDSChequeProveedores2.Tables("Tlb_ChequeProveedor").Rows.Add(objDataRow1)
                    'Next



                    objDataRow1.Item("Vencido") = DGrid.CurrentRow.Cells("fecha").Value

                    'objDataRow1.Item("cargo") = DGrid.CurrentRow.Cells("cargo").Value 'objDataSet.Tables(0).Rows(I).Item("cargo").ToString()
                    ' objDataRow1.Item("credito") = DGrid.CurrentRow.Cells("credito").Value 'objDataSet.Tables(0).Rows(I).Item("credito").ToString()

                    GenerarDSChequeProveedores.Tables("Tlb_ChequeProveedor").Rows.Add(objDataRow1)

                End With
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Private Function GenerarDSChequeProveedores2() As DSChequeProvedor
        'Juan galvan 08-07-13

        Try
            GenerarDSChequeProveedores2 = New DSChequeProvedor
            With DGrid
                ' For I As Integer = 1 To .Rows.Count - 2

                Dim objDataRow1 As Data.DataRow
                objDataRow1 = GenerarDSChequeProveedores2.Tables("Tlb_ChequeProveedor").NewRow()
                objDataRow1.Item("nomEmp") = DGrid.CurrentRow.Cells("proveedor").Value.ToString.Substring(5) 'objDataSet.Tables(0).Rows(I).Item("proveedor").ToString() '.Rows(I).Cells(2).Value
                objDataRow1.Item("total") = DGrid.CurrentRow.Cells("total").Value '58314.53 '.Rows(I).Cells(0).Value
                objDataRow1.Item("noCheque") = DGrid.CurrentRow.Cells("nocheque").Value  ' 4292 '.Rows(I).Cells(9).Value
                objDataRow1.Item("CPFactura") = DGrid.CurrentRow.Cells("factura").Value ' "000081319" + I.ToString  '.Rows(I).Cells(10).Value

                objDataRow1.Item("fechafactura") = DGrid.CurrentRow.Cells("fechafactura").Value '.Rows(I).Cells(3).Value
                objDataRow1.Item("subtotal") = DGrid.CurrentRow.Cells("subtotal").Value  'CDbl(Int((4120 * Rnd()) + 1)) '.Rows(I).Cells(6).Value
                objDataRow1.Item("descuento") = DGrid.CurrentRow.Cells("descuento").Value  '.Rows(I).Cells(7).Value
                objDataRow1.Item("gastos") = DGrid.CurrentRow.Cells("gastos").Value  'CDbl(Int((2006 * Rnd()) + 1)) '.Rows(I).Cells(4).Value
                objDataRow1.Item("impuesto") = DGrid.CurrentRow.Cells("impuesto").Value
                '  idfolio
                objDataRow1.Item("folioBultos") = DGrid.CurrentRow.Cells("idfolio").Value
                objDataRow1.Item("fecha") = DGrid.CurrentRow.Cells("fum").Value
                objDataRow1.Item("Liquidacion") = DGrid.CurrentRow.Cells("idliquidacion").Value
                objDataRow1.Item("Vencido") = DGrid.CurrentRow.Cells("fecha").Value

                objDataRow1.Item("improcedente") = DGrid.CurrentRow.Cells("improcedente").Value
                'GenerarDSChequeProveedores2.Tables(0).Rows.Add(objDataRow1)
                'GenerarDSChequeProveedores2.Tables("Tlb_ChequeProveedor").Rows.Add(objDataRow1)
                'Next
                GenerarDSChequeProveedores2.Tables("Tlb_ChequeProveedor").Rows.Add(objDataRow1)

            End With

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Private Sub CancelarChequeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelarChequeToolStripMenuItem.Click
        Try
            Dim Chq As String = DGrid.CurrentRow.Cells("nocheque").Value
            If MessageBox.Show("Desea cancelar el cheque " + Chq + " y asignar uno nuevo?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
            Using objCuentas As New BCL.BCLCatalogoCuentas(GLB_ConStringCipSis)
                objDataSet = objCuentas.usp_TraerCuenta(idCuenta, "")
            End Using
            Dim noCheque As String = objDataSet.Tables(0).Rows(0).Item("nocheque").ToString
            Dim noChequeNvo As String = pub_RellenarIzquierda(CInt(noCheque) + 1, 7)
            Using objCuentas As New BCL.BCLCatalogoCuentas(GLB_ConStringCipSis)
                objCuentas.usp_ActualizaNoCheque(idCuenta, noChequeNvo)
            End Using
            Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                objCuentas.usp_ActualizaLiquidacionDet(3, idLiquidacion, 0, noCheque, 0, Chq)
            End Using
            MessageBox.Show("El cheque " + Chq + " se cancelo correctamente, y se asigno el cheque " + noCheque, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DGrid.Columns.Remove(DGrid.Columns("selec"))
            Prov = ""
            RellenaGrid(TipoB)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Pagados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Pagados.Click
        Try
            If Opcion = 2 Then
                DGrid.Columns.Remove(DGrid.Columns("selec"))
            End If
            Est = "INSERT INTO clasificacion (status) VALUES ('AP')"
            Est1 = "INSERT INTO clasificacionb (status) VALUES ('AP')"
            Est2 = "INSERT INTO clasificacionbb (status) VALUES ('AP')"
            Est3 = "INSERT INTO clasificacionbbB (status) VALUES ('AP')"
            Opcion = 1
            blnPagados = True
            Prov = ""
            Call RellenaGrid(TipoB)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Filtros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtros.Click
        Try
            Dim myForm As New frmFiltrosLiquidaciones
            myForm.ShowDialog()
            If myForm.Sw_Filtro = True Then
                Est = "INSERT INTO clasificacion (status) VALUES "
                Est1 = "INSERT INTO clasificacionB (status) VALUES "
                Est2 = "INSERT INTO clasificacionBb (status) VALUES "
                Est3 = "INSERT INTO clasificacionBbB (status) VALUES "
                If myForm.Chk_Pagados.Checked Then
                    Est += "('AP'),"
                    Est1 += "('AP'),"
                    Est2 += "('AP'),"
                    Est3 += "('AP'),"
                End If
                If myForm.Chk_Generados.Checked Then
                    Est += "('GE'),"
                    Est1 += "('GE'),"
                    Est2 += "('GE'),"
                    Est3 += "('GE'),"

                End If
                If myForm.Chk_Revisados.Checked Then

                    Est += "('RV'),"
                    Est1 += "('RV'),"
                    Est2 += "('RV'),"
                    Est3 += "('RV'),"
                End If
                If myForm.Chk_Cancelados.Checked Then
                    Est += "('ZC'),"
                    Est1 += "('ZC'),"
                    Est2 += "('ZC'),"
                    Est3 += "('ZC'),"

                End If
                If myForm.Chk_Pagados.Checked = False And myForm.Chk_Generados.Checked = False And myForm.Chk_Revisados.Checked = False And myForm.Chk_Cancelados.Checked = False Then
                    Est += "('AP'),('GE'),('RV'),('ZC'),"
                    Est1 += "('AP'),('GE'),('RV'),('ZC'),"
                    Est2 += "('AP'),('GE'),('RV'),('ZC'),"
                    Est3 += "('AP'),('GE'),('RV'),('ZC'),"
                End If
                If myForm.Chk_Fechas.Checked Then
                    FechaInib = myForm.DTPicker2.Value.ToString("yyyy-MM-dd")
                    FechaFinb = myForm.DTPicker3.Value.ToString("yyyy-MM-dd")
                Else
                    FechaInib = "1900-01-01"
                    FechaFinb = "1900-01-01"
                End If
                Est = Est.Substring(0, Est.Length - 1)
                Est1 = Est1.Substring(0, Est1.Length - 1)
                Est2 = Est2.Substring(0, Est2.Length - 1)
                Est3 = Est3.Substring(0, Est3.Length - 1)
                If Opcion = 2 Then
                    DGrid.Columns.Remove(DGrid.Columns("selec"))
                End If
                If myForm.CB_Tipo.Text.Trim = "FACTURA" Then
                    TipoRF = "F"
                ElseIf myForm.CB_Tipo.Text.Trim = "CONSIGNACIÓN" Then
                    TipoRF = "R"
                ElseIf myForm.CB_Tipo.Text.Trim = "TRANSFERENCIA" Then
                    TipoRF = "T"
                Else
                    TipoRF = ""
                End If
                Opcion = 1
                Prov = ""
                RellenaGrid(TipoB)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub FichadeDepositoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FichadeDepositoToolStripMenuItem.Click
        Try
            If Opcion <> 2 Then Exit Sub
            'If DGrid.CurrentRow.Cells("status").Value.ToString.Trim <> "PAGADO" Then
            '    MessageBox.Show("Seleccione una liquidación pagada", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Exit Sub
            'End If
            Dim myForm As New frmFichaDeposito
            myForm.Txt_Liquidacion.Text = DGrid.CurrentRow.Cells("idliquidacion").Value
            myForm.Txt_Banco.Text = Banco
            myForm.Txt_NoCheque.Text = DGrid.CurrentRow.Cells("nocheque").Value
            myForm.Txt_Proveedor.Text = DGrid.CurrentRow.Cells("proveedor").Value
            myForm.Dt_Fecha.Value = DGrid.CurrentRow.Cells("fum").Value
            myForm.Show()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Factura_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Factura.TextChanged
        Try
            If Txt_Factura.Text = "" Then Exit Sub
            Dim Factura As String = ""
            Dim blnExiste As Boolean = False
            For i As Integer = 0 To DGrid.Rows.Count - 2
                If IsDBNull(DGrid.Rows(i).Cells("factura").Value) Then Continue For
                Factura = DGrid.Rows(i).Cells("factura").Value
                blnExiste = Factura.Contains(Txt_Factura.Text)
                If blnExiste = True Then
                    DGrid.Rows(i).Cells("factura").Selected = True
                Else
                    DGrid.Rows(i).Cells("factura").Selected = False
                End If
            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ConsultarBultoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultarBultoToolStripMenuItem.Click
        Try
            If Opcion <> 2 Then Exit Sub
            Dim myForm As New frmCatalogoReciboBultos
            myForm.Accion = 3
            myForm.Txt_Folio.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idfolio").Value.ToString.Trim()
            myForm.ShowDialog()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DetalleFacturaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetalleFacturaToolStripMenuItem.Click
        Try
            If Opcion <> 2 Then Exit Sub
            Dim myForm As New frmCatalogoPedidoNuevo
            Sw_Boton = True
            myForm.Accion = 4
            myForm.Txt_Sucursal.Text = DGrid.CurrentRow.Cells("idfolio").Value.ToString.Substring(0, 2)
            myForm.Txt_OrdeComp.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("factura").Value.ToString.Trim()
            myForm.Txt_NoBulto.Text = DGrid.CurrentRow.Cells("idfolio").Value.ToString.Trim()

            Dim Folio As String = ""
            Using objCuentas As New BCL.BCLBulto(GLB_ConStringCipSis)
                Folio = objCuentas.usp_TraerBulto("", DGrid.CurrentRow.Cells("idfolio").Value.ToString.Trim()).Tables(0).Rows(0).Item("idfolio").ToString
            End Using
            myForm.FolioB = Folio   
            myForm.Sw_Factura = True
            myForm.MdiParent = BitacoraMain
            myForm.Show()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub VerFichaDepositoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerFichaDepositoToolStripMenuItem.Click
        Try
            If Opcion <> 2 Then Exit Sub
            Dim myForm As New frmFichaDeposito
            myForm.Txt_Liquidacion.Text = DGrid.CurrentRow.Cells("idliquidacion").Value
            myForm.Txt_Banco.Text = Banco
            myForm.Txt_NoCheque.Text = DGrid.CurrentRow.Cells("nocheque").Value
            myForm.Txt_Proveedor.Text = DGrid.CurrentRow.Cells("proveedor").Value
            myForm.Dt_Fecha.Value = DGrid.CurrentRow.Cells("fum").Value
            myForm.Accion = 1
            myForm.Show()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Layout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Layout.Click
        Try
            'mreyes 07/Agosto/2013 09:35 a.m.
       
            If MsgBox("Esta seguro de querer generar la póliza de la liquidación.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmación") = MsgBoxResult.No Then Exit Sub



            Dim Archivo As String = "c:\PólizaPagos\Póliza" & Replace(Replace(Format(Date.Now, "yyyy-MM-dd hh:mm:ss"), "-", ""), ":", "") & ".txt"
            Dim Linea As String = ""
            Dim Columna1 As String = "3000101001"
            Dim TTarjeta As String = "03"
            Dim pagosdec As Decimal = 0
            Dim Cuenta As String = ""
            Dim Nombre As String = ""
            Dim FecLayout As String = ""

            Dim CuentaNos As String = "4001"
            Dim SumPago As Double = 0
            Dim SumPagoDec As String = ""
            Dim i As Integer
            Dim Cont As Integer = 0
            Dim Fecha = Format(Now.Date, "dd/MM/yyyy")
            Dim Cheque As String = ""
            ' Fecha = Format(Date.Now, "dd") & " de " & Format(Date.Now, "MMM") & "15D01"


            Dim Encabezado As String = "|1|E,," & Fecha & ",MN,1,," & "PÓLIZA DE PAGOS" & ",,"
            Dim sw As New System.IO.StreamWriter(Archivo)
            Linea = Encabezado
            sw.WriteLine(Linea)
            Linea = Encabezado

            SumPago = 0
            Cont = 0
            For i = 1 To DGrid.RowCount - 2
                ' CAST(Taller.cod_taller AS CHAR CHARACTER SET utf8 

                If DGrid.Rows(i).Cells("nocheque").Value <> "" Then
                    Encabezado = "|1|E,," & Fecha & ",MN,1,,DESCRIPCION,,"
                    Linea = Encabezado
                    sw.WriteLine(Linea)

                    ' Descuentos sobre compra
                    Cuenta = "4206"
                    pagosdec = Format(DGrid.Rows(i).Cells("descuento").Value / 1.16, "n2")
                    Cheque = DGrid.Rows(i).Cells("nocheque").Value & ""
                    Linea = "|1.1|" & Cuenta & ",,A," & pagosdec & "," & Cheque & ",DESCRIPCION,,"
                    sw.WriteLine(Linea)

                    Cuenta = "1105.1"
                    pagosdec = Format(DGrid.Rows(i).Cells("descuento").Value - DGrid.Rows(i).Cells("descuento").Value / 1.16, "n2")
                    Cheque = DGrid.Rows(i).Cells("nocheque").Value & ""
                    Linea = "|1.1|" & Cuenta & ",,A," & pagosdec & "," & Cheque & ",DESCRIPCION,,"
                    sw.WriteLine(Linea)

                    Cuenta = "2101"
                    pagosdec = Format(DGrid.Rows(i).Cells("total").Value + DGrid.Rows(i).Cells("descuento").Value, "n2")

                    Cheque = DGrid.Rows(i).Cells("nocheque").Value & ""
                    Linea = "|1.1|" & Cuenta & ",,C," & pagosdec & "," & Cheque & ",DESCRIPCION,,"
                    sw.WriteLine(Linea)

                    Cuenta = "1101.2.3"
                    pagosdec = Format(DGrid.Rows(i).Cells("total").Value, "n2")
                    Cheque = DGrid.Rows(i).Cells("nocheque").Value & ""
                    Linea = "|1.1|" & Cuenta & ",,A," & pagosdec & "," & Cheque & ",DESCRIPCION,,"
                    sw.WriteLine(Linea)


                    Cuenta = "1105.2"
                    pagosdec = Format((DGrid.Rows(i).Cells("total").Value + DGrid.Rows(i).Cells("descuento").Value) * 0.16, "n2")
                    Cheque = DGrid.Rows(i).Cells("nocheque").Value & ""
                    Linea = "|1.1|" & Cuenta & ",,C," & pagosdec & "," & Cheque & ",DESCRIPCION,,"
                    sw.WriteLine(Linea)


                    Cuenta = "1105.1"
                    pagosdec = Format((DGrid.Rows(i).Cells("total").Value + DGrid.Rows(i).Cells("descuento").Value) * 0.16, "n2")
                    Cheque = DGrid.Rows(i).Cells("nocheque").Value & ""
                    Linea = "|1.1|" & Cuenta & ",,A," & pagosdec & "," & Cheque & ",DESCRIPCION,,"
                    sw.WriteLine(Linea)


                End If
            Next
            sw.Close()
            MsgBox("Archivo creado en '" & Archivo & "')", MsgBoxStyle.Information, "Confirmación")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub tbn_Pruebas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try
            Dim myForm As New frmReportsBrowser

            myForm.objDataSetLiquidacionDetalle = GenerarReporteLiquidacionesDetalle(3, idLiquidacion, "")
            myForm.ReportIndex = 13
            myForm.Show()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Function GenerarReporteLiquidacionesDetalle(ByVal opcion As Integer, ByVal liquidacion As String, ByVal proveedor As String) As DSPLiquidacionDetalle
        'Juan 05/12/13
        Try
            Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                objDataSet = objCuentas.usp_TraerLiquidacionDetalle(opcion, liquidacion, proveedor) ' detalle de la liquidacion con comentarios y motivos
            End Using
            If objDataSet.Tables(0).Rows.Count = 0 Then
                MessageBox.Show("No se encontro informacion del Proveedor Seleccionado", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Function
            End If
            GenerarReporteLiquidacionesDetalle = New DSPLiquidacionDetalle
            For I As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                'If (objDataSet.Tables(0).Rows(I).Item("status").ToString() = 1) Then
                'If Prov = objDataSet.Tables(0).Rows(I).Item("proveedor").ToString.Trim Then
                Dim objDataRow1 As Data.DataRow

                '
                'd.proveedor,
                'd.factura,
                'd.gastos,
                'd.impuesto,
                'd.cargo,
                'd.credito,
                'd.descuento,
                'd.total,
                'ifnull(n.descrip, "") as 'comentario',
                'ifnull(m.descrip, "") as 'motivo'
                '

                objDataRow1 = GenerarReporteLiquidacionesDetalle.Tables("Tbl_LiquidacionDetalle").NewRow()
                objDataRow1.Item("idliquidacion") = objDataSet.Tables(0).Rows(I).Item("idliquidacion").ToString() 'objDataSet.Tables(0).Rows(I).Item("proveedor").ToString() '.Rows(I).Cells(2).Value
                objDataRow1.Item("factura") = objDataSet.Tables(0).Rows(I).Item("factura").ToString() '58314.53 '.Rows(I).Cells(0).Value
                objDataRow1.Item("proveedor") = objDataSet.Tables(0).Rows(I).Item("proveedor").ToString() 'objDataSet.Tables(0).Rows(I).Item("proveedor").ToString() '.Rows(I).Cells(2).Value
                objDataRow1.Item("subtotal") = objDataSet.Tables(0).Rows(I).Item("subtotal").ToString()  ' 4292 '.Rows(I).Cells(9).Value
                objDataRow1.Item("gastos") = objDataSet.Tables(0).Rows(I).Item("gastos").ToString() ' "000081319" + I.ToString  '.Rows(I).Cells(10).Value

                objDataRow1.Item("impuesto") = objDataSet.Tables(0).Rows(I).Item("impuesto").ToString() '.Rows(I).Cells(3).Value
                objDataRow1.Item("subtotal") = objDataSet.Tables(0).Rows(I).Item("subtotal").ToString()  'CDbl(Int((4120 * Rnd()) + 1)) '.Rows(I).Cells(6).Value
                objDataRow1.Item("descuento") = objDataSet.Tables(0).Rows(I).Item("descuento").ToString()  '.Rows(I).Cells(7).Value
                objDataRow1.Item("gastos") = objDataSet.Tables(0).Rows(I).Item("gastos").ToString()  'CDbl(Int((2006 * Rnd()) + 1)) '.Rows(I).Cells(4).Value
                objDataRow1.Item("cargo") = objDataSet.Tables(0).Rows(I).Item("cargo").ToString()
                '  idfolio
                objDataRow1.Item("credito") = objDataSet.Tables(0).Rows(I).Item("credito").ToString()
                objDataRow1.Item("descuento") = objDataSet.Tables(0).Rows(I).Item("descuento").ToString()
                objDataRow1.Item("total") = objDataSet.Tables(0).Rows(I).Item("total").ToString()

                objDataRow1.Item("improcedente") = objDataSet.Tables(0).Rows(I).Item("improcedente").ToString()

                objDataRow1.Item("comentario") = objDataSet.Tables(0).Rows(I).Item("comentario").ToString()

                objDataRow1.Item("motivo") = objDataSet.Tables(0).Rows(I).Item("motivo").ToString() 'objDataSet.Tables(0).Rows(I).Item("cargo").ToString() 'objDataSet.Tables(0).Rows(I).Item("cargo").ToString()
                'objDataRow1.Item("credito") = objDataSet.Tables(0).Rows(I).Item("credito").ToString() ' objDataSet.Tables(0).Rows(I).Item("credito").ToString() 'objDataSet.Tables(0).Rows(I).Item("credito").ToString()

                GenerarReporteLiquidacionesDetalle.Tables("Tbl_LiquidacionDetalle").Rows.Add(objDataRow1)
                'End If
                'End If
            Next
            'With DGrid
            '    For I As Integer = 1 To .Rows.Count - 2

            '        If .Rows(I).Cells("Selec").Value = 1 Then
            '            Dim objDataRow As Data.DataRow = GenerarReporte.Tables(0).NewRow()
            '            objDataRow.Item("factura") = .Rows(I).Cells(1).Value
            '            objDataRow.Item("idfolio") = .Rows(I).Cells(2).Value
            '            objDataRow.Item("fum") = .Rows(I).Cells(4).Value
            '            objDataRow.Item("fecfact") = .Rows(I).Cells(5).Value
            '            objDataRow.Item("fecha") = .Rows(I).Cells(6).Value
            '            objDataRow.Item("nocheque") = .Rows(I).Cells(7).Value
            '            objDataRow.Item("proveedor") = .Rows(I).Cells(8).Value
            '            objDataRow.Item("subtotal") = .Rows(I).Cells(9).Value
            '            objDataRow.Item("gastos") = .Rows(I).Cells(10).Value
            '            objDataRow.Item("impuesto") = .Rows(I).Cells(11).Value
            '            objDataRow.Item("cargo") = .Rows(I).Cells(12).Value
            '            objDataRow.Item("credito") = .Rows(I).Cells(13).Value
            '            objDataRow.Item("descuento") = .Rows(I).Cells(14).Value
            '            objDataRow.Item("total") = .Rows(I).Cells(15).Value
            '            objDataRow.Item("liquidacion") = .Rows(I).Cells(0).Value
            '            'objDataRow.Item("suma") = suma
            '            GenerarReporte.Tables(0).Rows.Add(objDataRow)

            '        End If
            '    Next
            'End With
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Private Sub NotasCCProvToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotasCCProvToolStripMenuItem.Click
        Try
            Dim myForm As New frmReportsBrowser

            myForm.objDataSetLiquidacionDetalle = GenerarReporteLiquidacionesDetalle(3, idLiquidacion, DGrid.CurrentRow.Cells("proveedor").Value)
            If myForm.objDataSetLiquidacionDetalle Is Nothing Then Exit Sub
            myForm.ReportIndex = 16
            myForm.Show()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub NotasCCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotasCCToolStripMenuItem.Click
        Try
            Dim myForm As New frmReportsBrowser

            myForm.objDataSetLiquidacionDetalle = GenerarReporteLiquidacionesDetalle(3, idLiquidacion, "")
            If myForm.objDataSetLiquidacionDetalle Is Nothing Then Exit Sub
            myForm.ReportIndex = 16
            myForm.Show()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Publicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Publicar.Click
        'mreyes  29/Junio/2015   10:05 a.m.

        If TipoB = "FACTORAJE" Then
            Try
                'mreyes 14/Octubre/2014 11:56 a.m.
                Dim Mes As String
                If MsgBox("Esta seguro de querer generar el layout para el banco, CON EL PUBLICADO DE FACTORAJE.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmación") = MsgBoxResult.No Then Exit Sub
                Mes = Format(CDate(Now.Date), "MMMM").ToUpper

                Dim Ruta As String = "c:\Factoraje\Bajio\" & Mes


                Using objIO As New BCL.BCLio(GLB_ConStringCipSis)


                    If objIO.pub_CrearDirectorio(Ruta) Then
                        MsgBox("No se pudo generar la carpeta '" & Ruta & "'", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If
                End Using

                Dim Archivo As String = Ruta & "\Bajio" & Replace(Replace(Format(Date.Now, "yyyy-MM-dd hh:mm:ss"), "-", ""), ":", "") & ".txt"
                Dim Linea As String = ""
                Dim Columna1 As String = "3000101001"
                Dim TTarjeta As String = "03"
                Dim pagosdec As String = ""
                Dim Cuenta As String = ""
                Dim Nombre As String = ""
                Dim FecLayout As String = ""


                Dim i As Integer
                Dim Cont As Integer = 0
                Dim Producto As String = "2CALTORR"
                Dim RFC As String = ""
                Dim factura As String = ""
                Dim fechafactura As Date = "1900-01-01"
                Dim fechavenc As Date = "1900-01-01"
                Dim sw As New System.IO.StreamWriter(Archivo)
                Dim Monto As Decimal = 0
                Dim montoant As Decimal = 0
                Cont = 0
                montoant = 0

                For i = 1 To DGrid.RowCount - 1
                    ' CAST(Taller.cod_taller AS CHAR CHARACTER SET utf8 
                    If DGrid.Rows(i).Cells("Selec").Value = 1 Then
                        If DGrid.Rows(i).Cells("total").Value > 0 Then
                            ' ACTUALIZAR FACTPROV.
                            'mreyes 31/Octubre/2014 05:44 p.m. fACTORAJE

                            Using objCatCuentas As New BCL.BCLCatalogoCuentas(GLB_ConStringCipSis)
                                If Not objCatCuentas.usp_GeneraDatosFactprovArchivoFactoraje(Mid(DGrid.Rows(i).Cells("PROVEEDOR").Value.ToString.Trim(), 1, 3), DGrid.Rows(i).Cells("idfolio").Value.ToString.Trim(), GLB_Idempleado) Then
                                    'Throw New Exception("No se pudo actualizar el Estatus.")
                                Else
                                    'MsgBox("Estatus Actualizado correctamente.", MsgBoxStyle.Information, "Confirmación")
                                End If
                            End Using

                            'RFC = Replace(Trim(DGrid.Rows(i).Cells("marca").Value & ""), "-", "")

                     
                            Using objProveedor As New BCL.BCLCatalogoProveedores(GLB_ConStringCipSis)
                                objDataSet = objProveedor.usp_TraerProveedorNoPagos(Mid(DGrid.Rows(i).Cells("PROVEEDOR").Value.ToString.Trim(), 1, 3)) 'checar variable
                                If objDataSet.Tables(0).Rows.Count > 0 Then
                                    'Generar el emparrillado de pagos.
                                    RFC = objDataSet.Tables(0).Rows(0).Item("rfc").ToString
                                    
                                End If
                            End Using


                            RFC = Replace(Trim(RFC), "-", "")

                            factura = Mid(DGrid.Rows(i).Cells("factura").Value & "", 3)
                            'fechafactura = DGrid.Rows(i).Cells("fecha").Value & ""
                            'fechavenc = DGrid.Rows(i).Cells("fecha").Value & ""

                            fechafactura = DGrid.Rows(i).Cells("fecha").Value & ""
                            fechavenc = DGrid.Rows(i).Cells("fecha").Value & ""

                            'fechafactura = 

                            fechafactura = Now.Date

                            fechavenc = DateAdd(DateInterval.Day, 180, fechafactura)
                            If Format(fechavenc, "ddd") = "dom" Then
                                fechavenc = DateAdd(DateInterval.Day, 178, fechafactura)
                            ElseIf Format(fechavenc, "ddd") = "sáb" Or Format(fechavenc, "ddd") = "sab" Then
                                fechavenc = DateAdd(DateInterval.Day, 179, fechafactura)
                            End If

                            Monto = Format(DGrid.Rows(i).Cells("total").Value, "###0.00") + montoant

                            If Monto >= 1000 Then
                                montoant = 0

                                Linea = RFC & "|" & factura & "|" & fechafactura & "|" & fechavenc & "|" & Monto & "|" & Producto
                                '000000000000043683
                                Cont = Cont + 1
                                sw.WriteLine(Linea)
                            Else
                                montoant = Monto
                            End If

                           
                        End If

                    End If
                Next
                'checar 
                If montoant > 0 Then
                    montoant = 0

                    Linea = RFC & "|" & factura & "|" & fechafactura & "|" & fechavenc & "|" & Monto & "|" & Producto
                    '000000000000043683
                    Cont = Cont + 1
                    sw.WriteLine(Linea)
                End If
                sw.Close()

                Using objCatCuentas As New BCL.BCLCatalogoCuentas(GLB_ConStringCipSis)
                    If Not objCatCuentas.usp_GeneraSaldoProvFactorajeArt() Then
                        'Throw New Exception("No se pudo actualizar el Estatus.")
                    Else
                        'MsgBox("Estatus Actualizado correctamente.", MsgBoxStyle.Information, "Confirmación")
                    End If
                End Using


                Using objCatCuentas As New BCL.BCLCatalogoCuentas(GLB_ConStringCipSis)
                    If Not objCatCuentas.usp_GeneraSaldoProvFactoraje() Then
                        'Throw New Exception("No se pudo actualizar el Estatus.")
                    Else
                        'MsgBox("Estatus Actualizado correctamente.", MsgBoxStyle.Information, "Confirmación")
                    End If
                End Using
                ' gENERA SALDOS PROVEEDOR NORMALES.

                Using objCatCuentas As New BCL.BCLCatalogoCuentas(GLB_ConStringCipSis)
                    If Not objCatCuentas.usp_GeneraSaldoProv() Then

                    Else

                    End If
                End Using

                Using objCatCuentas As New BCL.BCLCatalogoCuentas(GLB_ConStringCipSis)
                    If Not objCatCuentas.usp_ActualizaDisponibleFactoraje(1) Then
                        'Throw New Exception("No se pudo actualizar el Estatus.")
                    Else
                        'MsgBox("Estatus Actualizado correctamente.", MsgBoxStyle.Information, "Confirmación")
                    End If
                End Using


                MsgBox("Archivo creado en '" & Archivo & "')", MsgBoxStyle.Information, "Confirmación")

                'Call RellenaGrid()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        Else
            MsgBox("No puede crear un archivo para liquidación que no es de factoraje.", MsgBoxStyle.Critical, "Aviso")
        End If
    End Sub

    Private Sub CancelarLiquidaciónPagadaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelarLiquidaciónPagadaToolStripMenuItem.Click
        'mreyes17/08/2016110:15 a.m.
        Try
            If DGrid.CurrentRow.Cells("status").Value.ToString.Trim <> "PAGADO" Then
                MessageBox.Show("Use la otra opción de Cancelar, para liquidaciones no pagadas.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If MessageBox.Show("Esta seguro de cancelar la Liquidación?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                idLiquidacion = DGrid.CurrentRow.Cells("idliquidacion").Value
                Dim blnCancelo As Boolean = False
                If DGrid.CurrentRow.Cells("tipo").Value.ToString.Trim = "FACTORAJE" Then
                    Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                        blnCancelo = objCuentas.usp_ActualizaEstatusLiquidacionFactoraje(1, idLiquidacion, "ZC", 0, 0, 0, 0, 0, 0, 0, 0, "", 0)
                    End Using
                    If blnCancelo = True Then
                        Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                            objDataSet = objCuentas.usp_TraerLiquidacionDetFactoraje(1, idLiquidacion, "")
                        End Using
                        For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                            Dim idFolio As String = objDataSet.Tables(0).Rows(i).Item("idfolio").ToString
                            Using objCuentas As New BCL.BCLCatalogoCuentas(GLB_ConStringCipSis)
                                objCuentas.usp_ActualizaPagoFactura(1, idFolio, 3, "", 0)
                            End Using
                        Next

                        MessageBox.Show("Liquidación cancelada correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Error al cancelar la Liquidación", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                    Prov = ""
                    RellenaGrid(TipoB)
                ElseIf DGrid.CurrentRow.Cells("tipo").Value.ToString.Trim = "TRANSFERENCIA" Then
                    Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                        blnCancelo = objCuentas.usp_ActualizaEstatusLiquidacionTransferencia(1, idLiquidacion, "ZC", 0, 0, 0, 0, 0, 0, 0, 0, "", 0)
                    End Using
                    If blnCancelo = True Then
                        Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                            objDataSet = objCuentas.usp_TraerLiquidacionDetTransferencia(1, idLiquidacion, "")
                        End Using
                        For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                            Dim idFolio As String = objDataSet.Tables(0).Rows(i).Item("idfolio").ToString
                            Using objCuentas As New BCL.BCLCatalogoCuentas(GLB_ConStringCipSis)
                                objCuentas.usp_ActualizaPagoFactura(1, idFolio, 3, "", 0)
                            End Using
                        Next

                        MessageBox.Show("Liquidación cancelada correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Error al cancelar la Liquidación", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                    Prov = ""
                    RellenaGrid(TipoB)
                Else
                    Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                        blnCancelo = objCuentas.usp_ActualizaEstatusLiquidacion(1, idLiquidacion, "ZC", 0, 0, 0, 0, 0, 0, 0, 0, "", 0)
                    End Using
                    If blnCancelo = True Then
                        Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                            objDataSet = objCuentas.usp_TraerLiquidacionDet(1, idLiquidacion, "")
                        End Using
                        For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                            Dim idFolio As String = objDataSet.Tables(0).Rows(i).Item("idfolio").ToString
                            Using objCuentas As New BCL.BCLCatalogoCuentas(GLB_ConStringCipSis)
                                objCuentas.usp_ActualizaPagoFactura(1, idFolio, 3, "", 0)
                            End Using
                        Next

                        MessageBox.Show("Liquidación cancelada correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Error al cancelar la Liquidación", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                    Prov = ""
                    RellenaGrid(TipoB)

                End If

            End If









        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Btn_BanRegio.Click
        'mreyes  20/Agosto/2021   09:26 a.m.

        If TipoB = "FACTORAJE" Then
            Try
                'mreyes 14/Octubre/2014 11:56 a.m.
                Dim Mes As String
                If MsgBox("Esta seguro de querer generar el layout para el banco, CON EL PUBLICADO DE FACTORAJE.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmación") = MsgBoxResult.No Then Exit Sub
                Mes = Format(CDate(Now.Date), "MMMM").ToUpper

                Dim Ruta As String = "c:\Factoraje\Banregio\" & Mes


                Using objIO As New BCL.BCLio(GLB_ConStringCipSis)


                    If objIO.pub_CrearDirectorio(Ruta) Then
                        MsgBox("No se pudo generar la carpeta '" & Ruta & "'", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If
                End Using

                Dim Archivo As String = Ruta & "\Banregio" & Replace(Replace(Format(Date.Now, "yyyy-MM-dd hh:mm:ss"), "-", ""), ":", "") & ".txt"
                Dim Linea As String = ""
                Dim Columna1 As String = "3000101001"
                Dim TTarjeta As String = "03"
                Dim pagosdec As String = ""
                Dim Cuenta As String = ""
                Dim Nombre As String = ""
                Dim FecLayout As String = ""
                Dim NumProv As String = ""
                Dim NombreProv As String = ""


                Dim i As Integer
                Dim Cont As Integer = 0
                Dim Producto As String = "2CALTORR"
                Dim RFC As String = ""
                Dim factura As String = ""
                Dim fechafactura As Date = "1900-01-01"
                Dim fechavenc As Date = "1900-01-01"
                Dim sw As New System.IO.StreamWriter(Archivo)
                Dim Monto As Decimal = 0
                Dim montoant As Decimal = 0
                Cont = 0
                montoant = 0

                For i = 1 To DGrid.RowCount - 1
                    ' CAST(Taller.cod_taller AS CHAR CHARACTER SET utf8 
                    If DGrid.Rows(i).Cells("Selec").Value = 1 Then
                        If DGrid.Rows(i).Cells("total").Value > 0 Then
                            ' ACTUALIZAR FACTPROV.
                            'mreyes 31/Octubre/2014 05:44 p.m. fACTORAJE

                            Using objCatCuentas As New BCL.BCLCatalogoCuentas(GLB_ConStringCipSis)
                                If Not objCatCuentas.usp_GeneraDatosFactprovArchivoFactoraje(Mid(DGrid.Rows(i).Cells("PROVEEDOR").Value.ToString.Trim(), 1, 3), DGrid.Rows(i).Cells("idfolio").Value.ToString.Trim(), GLB_Idempleado) Then
                                    'Throw New Exception("No se pudo actualizar el Estatus.")
                                Else
                                    'MsgBox("Estatus Actualizado correctamente.", MsgBoxStyle.Information, "Confirmación")
                                End If
                            End Using

                            'RFC = Replace(Trim(DGrid.Rows(i).Cells("marca").Value & ""), "-", "")


                            Using objProveedor As New BCL.BCLCatalogoProveedores(GLB_ConStringCipSis)
                                objDataSet = objProveedor.usp_TraerProveedoBanregio(Mid(DGrid.Rows(i).Cells("PROVEEDOR").Value.ToString.Trim(), 1, 3)) 'checar variable
                                If objDataSet.Tables(0).Rows.Count > 0 Then
                                    'Generar el emparrillado de pagos.
                                    ' RFC = objDataSet.Tables(0).Rows(0).Item("rfc").ToString
                                    NumProv = objDataSet.Tables(0).Rows(0).Item("provbr").ToString
                                    NombreProv = objDataSet.Tables(0).Rows(0).Item("razonsocial").ToString
                                End If
                            End Using


                            RFC = Replace(Trim(RFC), "-", "")

                            factura = Mid(DGrid.Rows(i).Cells("factura").Value & "", 3)
                            'fechafactura = DGrid.Rows(i).Cells("fecha").Value & ""
                            'fechavenc = DGrid.Rows(i).Cells("fecha").Value & ""

                            fechafactura = Format(CDate(DGrid.Rows(i).Cells("fecha").Value), "yyyy/MM/dd")
                            fechavenc = DGrid.Rows(i).Cells("fecha").Value & ""

                            'fechafactura = 

                            fechafactura = Now.Date

                            fechavenc = Format(CDate(DateAdd(DateInterval.Day, 179, fechafactura)), "yyyy/MM/dd")
                            'If Format(fechavenc, "ddd") = "dom" Then
                            '    fechavenc = DateAdd(DateInterval.Day, 178, fechafactura)
                            'ElseIf Format(fechavenc, "ddd") = "sáb" Or Format(fechavenc, "ddd") = "sab" Then
                            '    fechavenc = DateAdd(DateInterval.Day, 179, fechafactura)
                            'End If

                            Monto = Format(DGrid.Rows(i).Cells("total").Value, "###0.00") + montoant

                            If Monto >= 1000 Then
                                montoant = 0

                                Linea = """" & factura & """,""01"",""" & Format(Now.Date, "yyyy/MM/dd") & """,""" & Monto & """,""01"",""" & Format(CDate(DateAdd(DateInterval.Day, 179, fechafactura)), "yyyy/MM/dd") & """,""" & NumProv & """"
                                '000000000000043683
                                Cont = Cont + 1
                                sw.WriteLine(Linea)
                            Else
                                montoant = Monto
                            End If


                        End If

                    End If
                Next
                'checar 
                If montoant > 0 Then
                    montoant = 0

                    Linea = """" & factura & """,""01"",""" & fechafactura & """,""" & Monto & """,""01"",""" & fechavenc & """,""" & NumProv & """"

                    '000000000000043683
                    Cont = Cont + 1
                    sw.WriteLine(Linea)
                End If
                sw.Close()

                Using objCatCuentas As New BCL.BCLCatalogoCuentas(GLB_ConStringCipSis)
                    If Not objCatCuentas.usp_GeneraSaldoProvFactorajeArt() Then
                        'Throw New Exception("No se pudo actualizar el Estatus.")
                    Else
                        'MsgBox("Estatus Actualizado correctamente.", MsgBoxStyle.Information, "Confirmación")
                    End If
                End Using


                Using objCatCuentas As New BCL.BCLCatalogoCuentas(GLB_ConStringCipSis)
                    If Not objCatCuentas.usp_GeneraSaldoProvFactoraje() Then
                        'Throw New Exception("No se pudo actualizar el Estatus.")
                    Else
                        'MsgBox("Estatus Actualizado correctamente.", MsgBoxStyle.Information, "Confirmación")
                    End If
                End Using
                ' gENERA SALDOS PROVEEDOR NORMALES.

                Using objCatCuentas As New BCL.BCLCatalogoCuentas(GLB_ConStringCipSis)
                    If Not objCatCuentas.usp_GeneraSaldoProv() Then

                    Else

                    End If
                End Using

                Using objCatCuentas As New BCL.BCLCatalogoCuentas(GLB_ConStringCipSis)
                    If Not objCatCuentas.usp_ActualizaDisponibleFactoraje(1) Then
                        'Throw New Exception("No se pudo actualizar el Estatus.")
                    Else
                        'MsgBox("Estatus Actualizado correctamente.", MsgBoxStyle.Information, "Confirmación")
                    End If
                End Using


                MsgBox("Archivo creado en '" & Archivo & "')", MsgBoxStyle.Information, "Confirmación")

                'Call RellenaGrid()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        Else
            MsgBox("No puede crear un archivo para liquidación que no es de factoraje.", MsgBoxStyle.Critical, "Aviso")
        End If
    End Sub
End Class