Public Class frmPpalArchivoFactoraje
    'mreyes 14/Octubre/2014 09:59 a.m.

    Public Sw_Publicadas As Boolean = False
    Private objDataSet As Data.DataSet
    Public Sw_Registro As Boolean = False
    Public Sw_FacturaNueva As Boolean = False
    Public Sw_Costos As Boolean = True
    Dim Sw_Pintar As Boolean = False
    Dim Marcab As String
    Dim Estilonb As String
    Dim Estilofb As String
    Dim Familiab As String
    Dim Lineab As String
    Dim Proveedorb As String
    Dim TipoArtb As String
    Dim Categoriab As String

    Dim Sucursalb As String
    Dim OrdeCompb As String
    Dim FechaInib As String
    Dim FechaFinb As String
    Public Statusb As String = ""
    Dim VenceInib As String
    Dim VenceFinb As String
    Dim FactInib As String
    Dim FactFinb As String

    Dim FactProvInib As String
    Dim FactProvFinb As String

    Dim IdFolioIniB As String
    Dim IdFolioFinB As String

    Dim FechaRecInib As String
    Dim FechaRecFinB As String


    Dim Sw_Load As Boolean = True
    Dim Sw_Boton As Boolean = False
    Dim Sw_NoRegistros As Boolean = False
    Public Sw_Remision As Boolean = False
    Dim TipoB As String
    Public Reporte As Integer = 0

    Public arrRemisiones() As String
    Public arrProv() As String
    Public arrImporte() As Decimal
    Public arrReferencias() As String
    Public arrIdFolio() As Integer
    'Remisiones
    Public fechadep As String
    Public importe As String
    Public referencia As String
    Dim sucursal As String
    Dim factprov As String
    Dim FechaPagoInib As String
    Dim FechaPagoFinB As String
    Public blnInicioAdmon As Boolean = False


    Private Sub frmPpalFacturas_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If GLB_RefrescarPedido = True Then
            GLB_RefrescarPedido = False
            Call RellenaGrid()
            Me.WindowState = FormWindowState.Maximized
        End If
        If Sw_Load = True Then
            If Sw_NoRegistros = False Then
                Sw_Load = False
                ''     InicializaGrid()
                Factura_Microsip()
            Else
                Sw_Load = False
                'Sw_NoRegistros = False
            End If
        End If
        If Sw_NoRegistros = True Then
            DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
        End If


    End Sub

    Private Sub frmPpalFacturas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
        If e.KeyCode = Keys.F5 Then
            Call Btn_Filtro_Click_1(sender, e)
        End If
    End Sub

    Private Sub frmPpalFacturas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Btn_Imprimir.Enabled = False
            TipoB = "F"
            

            Sw_Load = True
            Call LimpiarBusqueda()


            Sw_Pintar = True
            If GLB_CveSucursal <> "" Then
                Sucursalb = GLB_CveSucursal
            End If
            'FechaInib = Format(Now.Date, "yyyy-MM-dd")
            'FechaFinb = Format(Now.Date, "yyyy-MM-dd")
            'FechaInib = Format(Now.Add(New TimeSpan(-1, 0, 0, 0)), "yyyy-MM-dd")

            If Sw_Load = True And Statusb = "PENDIENTE" Then
                FechaRecFinB = "1900-01-01"
                FechaRecInib = "1900-01-01"
                Me.Text = "Facturas Pendientes de Pago"
            
            Else

                FechaRecFinB = Format(Now.Date, "yyyy-MM-dd")
                FechaRecInib = Format(Now.Add(New TimeSpan(-1, 0, 0, 0)), "yyyy-MM-dd")
            End If
            If Reporte = 1 Then
                Me.Text = "Saldos de Proveedores"
            End If
            If Statusb = "PAGADO" Then
                Me.Text = "Reporte de Facturas Pagadas"
            End If

            If blnInicioAdmon = True Then

                FechaRecInib = "1900-01-01"
                FechaRecFinB = "1900-01-01"
                Statusb = "STAND BY"
                Sw_Load = False

                blnInicioAdmon = False
            End If

            Call RellenaGrid()
            Call GenerarToolTip()
            If Sw_FacturaNueva = True Then

                ' Btn_Editar.Visible = True
                Btn_Consultar.Visible = True

                Me.Text = "Recibo a Detalle"

                Btn_Imprimir.Enabled = True
            End If

            If Sw_Costos = False Or Reporte = 1 Or Statusb = "PAGADO" Then
               
                Btn_InvertirSeleccion.Visible = False
                
                StandByToolStripMenuItem.Enabled = False
                RecibidoToolStripMenuItem1.Enabled = False

                Btn_Factura.Visible = False

            End If
            ' If Sw_Remision = True Then Btn_Liquidacion.Visible = False
            ''   Call Factura_Microsip()
            If Sw_Publicadas = True Then
                Btn_Layout.Visible = False
                Btn_InvertirSeleccion.Visible = False
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub GenerarToolTip()
        Try





            ToolTip.SetToolTip(Btn_Consultar, "Consultar Factura")
            ToolTip.SetToolTip(Btn_Layout, "Generar archivo de factoraje")
            ToolTip.SetToolTip(Btn_InvertirSeleccion, "Invertir selección")

            ToolTip.SetToolTip(Btn_Filtro, "Búsqueda Avanzada")
            'ToolTip.SetToolTip(Btn_Refrescar, "Refrescar Información")
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
            ToolTip.SetToolTip(Btn_Imprimir, "Imprimir Información")
            'ToolTip.SetToolTip(Btn_Pdf, "Generar Información en PDF")
            ToolTip.SetToolTip(Btn_Salir, "Salir")

                ToolTip.SetToolTip(Btn_Factura, "Detalle de Factura")
   


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub RellenaGrid(Optional ByVal Opcion1 As Integer = 0)
        Using objFactura As New BCL.BCLFacturas(GLB_ConStringCipSis)
            Dim Opcion As Integer
            Try
                Dim FactNueva As Integer

                Me.Cursor = Cursors.WaitCursor
                ''DGrid.ReadOnly = True

                If Sw_Load = True Then
                    ' Sw_Load = False
                    Opcion = 1
                    If Statusb = "PAGADO" Then
                        Opcion = 5

                        FechaRecFinB = "1900-01-01"
                        FechaRecInib = "1900-01-01"

                        FechaPagoFinB = Format(Now.Date, "yyyy-MM-dd")
                        FechaPagoInib = Format(Now.Add(New TimeSpan(-7, 0, 0, 0)), "yyyy-MM-dd")
                    End If
                Else
                    Opcion = 2
                    If Sw_Remision = True Then
                        If Sw_NoRegistros = True Then
                            DGrid.Columns.Remove("Selec")
                            DGrid.Columns.Remove("SelecR")
                        End If
                    Else
                        If Sw_NoRegistros = True Then
                            DGrid.Columns.Remove("MicroSip")
                            DGrid.Columns.Remove("SelecR")
                        End If
                    End If
                    Sw_Pintar = True
                    If Opcion1 <> 0 Then Opcion = 3
                End If
                If Reporte = 1 Then Opcion = 3
                If Opcion1 = 4 Then Opcion = 4
                If Statusb = "PAGADO" Then Opcion = 5

                If Sw_FacturaNueva = True Then
                    FactNueva = 1
                Else
                    FactNueva = 0
                End If
                Dim sTATUSB1 As String

                If Statusb = "PENDIENTE" Then
                    sTATUSB1 = "0"
                ElseIf Statusb = "PAGADO" Then
                    sTATUSB1 = "1"
                ElseIf Statusb = "STAND BY" Then
                    sTATUSB1 = "2"
                ElseIf Statusb = "RECIBIDO" Then
                    sTATUSB1 = "3"
                ElseIf Statusb = "EN LIQUIDACION" Then
                    sTATUSB1 = "4"
                ElseIf Statusb = "AUTORIZADO" Then
                    sTATUSB1 = "5"
                ElseIf Statusb = "CANCELADO" Then
                    sTATUSB1 = "6"
                ElseIf Statusb = "REVISADO" Then
                    sTATUSB1 = "7"
                ElseIf Statusb = "FACTORAJE" Then
                    sTATUSB1 = "8"
                Else
                    sTATUSB1 = "9"
                End If


                DGrid.DataSource = Nothing
                '    objDataSet = objFactura.usp_PpalFacturas(Opcion, FactNueva, Sucursalb, IIf(FactInib = "F-" Or FactInib = "", "", "F-" & FactInib), IIf(FactFinb = "F-" Or FactFinb = "", "", "F-" & FactFinb), Marcab, _
                '                                                    Proveedorb, sTATUSB1, FechaInib, _
                '                                                   FechaFinb, VenceInib, VenceFinb, FechaRecInib, FechaRecFinB, FactProvInib, FactProvFinb, IdFolioIniB, IdFolioFinB, TipoB)

                If Sw_Publicadas = False Then
                    objDataSet = objFactura.usp_PpalArchivoFactoraje(1, FactNueva, Sucursalb, IIf(FactInib = "F-" Or FactInib = "", "", "F-" & FactInib), IIf(FactFinb = "F-" Or FactFinb = "", "", "F-" & FactFinb), Marcab, _
                                                                       Proveedorb, sTATUSB1, FechaInib, _
                                                                       FechaFinb, VenceInib, VenceFinb, FechaRecInib, FechaRecFinB, FechaPagoInib, FechaPagoFinB, FactProvInib, FactProvFinb, IdFolioIniB, IdFolioFinB, TipoB)
                Else
                    objDataSet = objFactura.usp_PpalArchivoFactoraje(3, FactNueva, Sucursalb, IIf(FactInib = "F-" Or FactInib = "", "", "F-" & FactInib), IIf(FactFinb = "F-" Or FactFinb = "", "", "F-" & FactFinb), Marcab, _
                                                                       Proveedorb, sTATUSB1, FechaInib, _
                                                                       FechaFinb, VenceInib, VenceFinb, FechaRecInib, FechaRecFinB, FechaPagoInib, FechaPagoFinB, FactProvInib, FactProvFinb, IdFolioIniB, IdFolioFinB, TipoB)

                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section
                    Sw_NoRegistros = True
                    DGrid.DataSource = objDataSet.Tables(0)
                    Sw_Pintar = True
                    InicializaGrid()
                    'LimpiarBusqueda()
                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True

                    Btn_Consultar.Enabled = True

                    Btn_Factura.Enabled = True
                    Btn_InvertirSeleccion.Enabled = True


                    Sw_NoRegistros = True
                Else
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    If Sw_Remision = True Then
                        MsgBox("No se encontraron Remisiones que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Else
                        MsgBox("No se encontraron Facturas que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    End If
                    Btn_Excel.Enabled = False

                    Btn_Consultar.Enabled = False
                    Btn_Factura.Enabled = False
                    Btn_InvertirSeleccion.Enabled = False


                End If

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using


    End Sub
    Private Sub LimpiarBusqueda()
        Marcab = ""
        Estilonb = ""
        Estilofb = ""
        Familiab = ""
        Lineab = ""
        Proveedorb = ""
        TipoArtb = ""
        Categoriab = ""

        Sucursalb = ""
        OrdeCompb = ""

        If Sw_Load = False Then
            Statusb = ""
        Else
            If Statusb = "PENDIENTE" Then

            End If
        End If


        VenceInib = "1900-01-01"
        VenceFinb = "1900-01-01"
        FechaInib = "1900-01-01"
        FechaFinb = "1900-01-01"
        FechaRecInib = "1900-01-01"
        FechaRecFinB = "1900-01-01"
        FactInib = ""
        FactFinb = ""
        FactProvInib = ""
        FactProvFinb = ""

        IdFolioFinB = ""
        IdFolioIniB = ""
        FechaPagoInib = "1900-01-01"
        FechaPagoFinB = "1900-01-01"

    End Sub
    Private Sub Pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub

    Private Sub Btn_Refrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Sub InicializaGrid()
        '' 
        'mreyes 12/Febrero/2011 05:37 p.m.
        Try

            Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
            Dim row As DataRow = dt.NewRow()
            ' row(3) = "Total: "
            row(9) = "Total: "
            row(10) = pub_SumarColumnaGrid(DGrid, 10, DGrid.RowCount - 1)
            row(11) = pub_SumarColumnaGrid(DGrid, 11, DGrid.RowCount - 1)
            row(12) = pub_SumarColumnaGrid(DGrid, 12, DGrid.RowCount - 1)
            row(13) = pub_SumarColumnaGrid(DGrid, 13, DGrid.RowCount - 1)
            row(14) = pub_SumarColumnaGrid(DGrid, 14, DGrid.RowCount - 1)
            row(15) = pub_SumarColumnaGrid(DGrid, 15, DGrid.RowCount - 1)
            row(16) = pub_SumarColumnaGrid(DGrid, 16, DGrid.RowCount - 1)
            row(17) = pub_SumarColumnaGrid(DGrid, 17, DGrid.RowCount - 1)
            dt.Rows.InsertAt(row, 0)
            DGrid.DataSource = dt

            DGrid.RowHeadersVisible = False

            ' DGrid.Columns(3).Visible = False
            DGrid.Columns("idliquidacion").Visible = False
            DGrid.Columns(19).Visible = False
            DGrid.Columns(5).Visible = False
            DGrid.Columns(8).Visible = False

            DGrid.Columns(0).HeaderText = "Sucursal"
            DGrid.Columns(1).HeaderText = "Entrada"
            DGrid.Columns(2).HeaderText = IIf(Sw_Remision = True, "Folio", "FactProv")
            DGrid.Columns(3).HeaderText = "Folio Bulto"
            DGrid.Columns(4).HeaderText = "Folio Bulto"
            DGrid.Columns(5).HeaderText = "Estatus"
            DGrid.Columns(6).HeaderText = "Fecha Factura"
            DGrid.Columns(7).HeaderText = "Fecha Vence"
            DGrid.Columns(8).HeaderText = "Folio Devolución"
            DGrid.Columns(9).HeaderText = "Proveedor"
            DGrid.Columns(10).HeaderText = "Pares"
            DGrid.Columns(11).HeaderText = "Subtotal"
            DGrid.Columns(12).HeaderText = "Gastos"
            If Sw_Remision = True Then
                DGrid.Columns(13).HeaderText = "Adicional"
            Else
                DGrid.Columns(13).HeaderText = "Impuesto"
            End If

            DGrid.Columns(14).HeaderText = "NCargo"
            DGrid.Columns(15).HeaderText = "NCredito"

            DGrid.Columns(16).HeaderText = "Dscto"
            'DGrid.Columns("aportaciones").HeaderText = "Aportaciones"
            DGrid.Columns(17).HeaderText = "Total"
            DGrid.Columns(18).HeaderText = "Observaciones"
            DGrid.Columns(19).HeaderText = "Días por Vencer"
            If Statusb = "PAGADO" Then DGrid.Columns(19).Visible = False

            DGrid.Columns("idliquidacion").DisplayIndex = 5
            DGrid.Columns("idliquidacion").HeaderText = "IdLiq"

            DGrid.Columns(0).Frozen = True
            DGrid.Columns(1).Frozen = True
            DGrid.Columns(2).Frozen = True
            DGrid.Columns(3).Frozen = True
            DGrid.Columns(4).Frozen = True
            DGrid.Columns("idliquidacion").Frozen = True


            If Sw_Costos = False Then
                DGrid.Columns(17).Visible = False
                DGrid.Columns(11).Visible = False
                DGrid.Columns(12).Visible = False
                DGrid.Columns(13).Visible = False
                DGrid.Columns(16).Visible = False
                DGrid.Columns(14).Visible = False
                DGrid.Columns(15).Visible = False

            End If

            If Reporte = 1 Then
                DGrid.Columns(0).Visible = False
                DGrid.Columns(1).Visible = False
                DGrid.Columns(2).Visible = False
                DGrid.Columns(3).Visible = False
                DGrid.Columns(4).Visible = False
                DGrid.Columns(5).Visible = False
                DGrid.Columns(6).Visible = False
                DGrid.Columns(7).Visible = False
                DGrid.Columns(8).Visible = False
                DGrid.Columns(10).Visible = False
                DGrid.Columns(18).Visible = False
                DGrid.Columns(19).Visible = False
            End If
            DGrid.Columns(0).ReadOnly = True
            DGrid.Columns(1).ReadOnly = True
            DGrid.Columns(2).ReadOnly = True
            DGrid.Columns(3).ReadOnly = True

            DGrid.Columns(4).ReadOnly = True
            DGrid.Columns(6).ReadOnly = True
            DGrid.Columns(5).ReadOnly = True
            DGrid.Columns(7).ReadOnly = True
            DGrid.Columns(8).ReadOnly = True
            DGrid.Columns(9).ReadOnly = True
            DGrid.Columns(10).ReadOnly = True
            DGrid.Columns(11).ReadOnly = True
            DGrid.Columns(12).ReadOnly = True
            DGrid.Columns(13).ReadOnly = True
            DGrid.Columns(16).ReadOnly = True
            DGrid.Columns(19).ReadOnly = True

            DGrid.Columns(17).ReadOnly = True
            DGrid.Columns(14).ReadOnly = True
            DGrid.Columns(15).ReadOnly = True

            DGrid.Columns(18).ReadOnly = True



            DGrid.Columns(0).Visible = False
            If Sw_FacturaNueva = True Then
                DGrid.Columns(1).Visible = True
            Else
                DGrid.Columns(1).Visible = False
            End If
            'DGrid.Columns(8).Visible = False
            DGrid.Columns(3).Visible = False
            'DGrid.Columns(3).Visible = False

            '  DGrid.Columns(3).Visible = False
           
            DGrid.Columns("Observa").Visible = False

            DGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells


            DGrid.Columns(15).DefaultCellStyle.Format = "c"
            DGrid.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns(11).DefaultCellStyle.Format = "c"
            DGrid.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns(12).DefaultCellStyle.Format = "c"
            DGrid.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns(13).DefaultCellStyle.Format = "c"
            DGrid.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns(14).DefaultCellStyle.Format = "c"
            DGrid.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns(15).DefaultCellStyle.Format = "c"
            DGrid.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns(16).DefaultCellStyle.Format = "c"
            DGrid.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns(17).DefaultCellStyle.Format = "c"
            DGrid.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns("idliquidacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Columns(2).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Columns(3).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Columns(4).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Columns("idliquidacion").DefaultCellStyle.BackColor = Color.PowderBlue

            DGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


            'DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.BackColor = Color.PowderBlue
            'DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            'DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

            DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)


            If Sw_Remision = True Then
                AgregarColumnaFicha()
                AgregarColumnaRecibido()
            Else
                AgregarColumna()
                AgregarColumnaRecibido()

            End If

            If Sw_Remision = True Then
                If GLB_Usuario = "FELIX" Then
                    DGrid.Columns("SelecR").ReadOnly = False
                Else
                    DGrid.Columns("SelecR").ReadOnly = True
                End If
            End If

            'AgregarColumna()
            DGrid.Columns(18).ReadOnly = False

            ' DGrid.Columns(4).DisplayIndex = 0
            DGrid.Columns(19).DisplayIndex = 5
            DGrid.Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            If Sw_Publicadas = True Then
                DGrid.Columns("SelecR").Visible = False
            End If


            If Sw_Remision = False Then
                DGrid.Columns("MicroSip").Visible = False
            End If
            If Reporte = 1 Or Statusb = "PAGADO" Then
                DGrid.Columns("SelecR").Visible = False
            End If

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

    Private Sub Btn_Nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim myForm As New frmCatalogoPedidoNuevo
        Sw_Boton = True
        myForm.Accion = 1
        myForm.Sw_FacturaNueva = Sw_FacturaNueva
        myForm.MdiParent = BitacoraMain
        myForm.Show()
        If myForm.Sw_Registro = True Then
            Call RellenaGrid()
        End If


    End Sub



    ''Private Sub DGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick
    ''    ' ''Try
    ''    ' ''    If DGrid.CurrentCell.ColumnIndex = 14 Then Exit Sub
    ''    ' ''    Call Btn_Consultar_Click(sender, e)
    ''    ' ''Catch ExceptionErr As Exception
    ''    ' ''    MessageBox.Show(ExceptionErr.Message.ToString)
    ''    ' ''End Try
    ''End Sub



    Private Sub Btn_Consultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Consultar.Click
        Dim myForm As New frmCatalogoPedidoNuevo
        Sw_Boton = True
        myForm.Accion = 4
        myForm.Sw_FacturaNueva = Sw_FacturaNueva
        myForm.Txt_Sucursal.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("sucursal").Value.ToString.Trim()
        myForm.Txt_OrdeComp.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("factprov").Value.ToString.Trim()
        myForm.FolioB = DGrid.Rows(DGrid.CurrentRow.Index).Cells("IDFOLIO").Value.ToString.Trim()
        myForm.Txt_NoBulto.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idfoliosuc").Value.ToString.Trim()
        myForm.Txt_Proveedor.Text = Mid(DGrid.Rows(DGrid.CurrentRow.Index).Cells("proveedor").Value.ToString.Trim(), 1, 3)

        myForm.Txt_NotaCargo.Text = Val(DGrid.Rows(DGrid.CurrentRow.Index).Cells("cargo").Value.ToString)
        myForm.Txt_NotaCredito.Text = Val(DGrid.Rows(DGrid.CurrentRow.Index).Cells("credito").Value.ToString)



        myForm.Sw_Factura = True
        myForm.MdiParent = BitacoraMain
        myForm.Show()
        Call RellenaGrid()
    End Sub

    Private Sub Btn_Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try


            If DGrid.Rows(DGrid.CurrentRow.Index).Cells("status").Value.ToString.Trim() = "PAGADO" Then
                MsgBox("No puede editar una factura ya pagada.", MsgBoxStyle.Critical, "Validación")
                Exit Sub
            End If
            Dim myForm As New frmCatalogoPedidoNuevo
            Sw_Boton = True
            myForm.Accion = 2
            myForm.Sw_FacturaNueva = Sw_FacturaNueva
            ' myForm.Txt_Sucursal.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("sucursal").Value.ToString.Trim()
            ' myForm.Txt_OrdeComp.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("factprov").Value.ToString.Trim()
            myForm.Txt_Sucursal.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("sucursal").Value.ToString.Trim()
            If Sw_Remision = True Then
                myForm.Txt_OrdeComp.Text = "R-" & DGrid.Rows(DGrid.CurrentRow.Index).Cells("referenc").Value.ToString.Trim()
            Else
                myForm.Txt_OrdeComp.Text = "F-" & DGrid.Rows(DGrid.CurrentRow.Index).Cells("referenc").Value.ToString.Trim()
            End If
            myForm.Txt_NoBulto.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idfoliosuc").Value.ToString.Trim()
            myForm.FolioB = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idfolio").Value.ToString.Trim()
            myForm.Txt_Proveedor.Text = Mid(DGrid.Rows(DGrid.CurrentRow.Index).Cells("proveedor").Value.ToString.Trim(), 1, 3)
            myForm.Txt_NotaCargo.Text = Val(DGrid.Rows(DGrid.CurrentRow.Index).Cells("cargo").Value.ToString)
            myForm.Txt_NotaCredito.Text = Val(DGrid.Rows(DGrid.CurrentRow.Index).Cells("credito").Value.ToString)

            myForm.Sw_Factura = True
            myForm.MdiParent = BitacoraMain
            myForm.Show()
            If myForm.Sw_Registro = True Then
                Call RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Filtro_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        'mreyes 15/Marzo/2012 05:49 a.m.
        Try
            Dim myForm As New frmFiltrosFacturas
            myForm.Chk_FechaRec.Text = "Fecha Publica"
            myForm.Txt_Marca.Text = Marcab

            myForm.Txt_Proveedor.Text = Proveedorb

            myForm.Txt_Sucursal.Text = Sucursalb

            myForm.Cbo_Estatus.Text = Statusb
            myForm.Txt_OrdeComp1.Text = FactInib
            myForm.Txt_OrdeComp2.Text = FactFinb

            myForm.Txt_FactProv.Text = FactProvInib
            myForm.Txt_FactProv1.Text = FactProvFinb
            myForm.Txt_IdFolio.Text = IdFolioIniB
            myForm.Txt_IdFolio1.Text = IdFolioFinB


            If FechaInib <> "1900-01-01" Then
                myForm.Chk_FechaOrden.Checked = True
                myForm.DTPicker2.Value = FechaInib
                myForm.DTPicker3.Value = FechaFinb
            End If
            If VenceInib <> "1900-01-01" Then
                myForm.Chk_FechaEntrega.Checked = True
                myForm.DTPicker4.Value = VenceInib
                myForm.DTPicker5.Value = VenceFinb
            End If
            If FechaRecInib <> "1900-01-01" Then
                myForm.Chk_FechaRec.Checked = True
                myForm.DTPicker6.Value = FechaRecInib
                myForm.DTPicker7.Value = FechaRecFinB
            End If


            If FechaPagoInib <> "1900-01-01" Then
                myForm.Chk_FechaPago.Checked = True
                myForm.DT_FechaPini.Value = FechaPagoInib
                myForm.DT_FechaPFin.Value = FechaPagoFinB
            End If

            If Sw_Remision = True Then
                myForm.Sw_Remision = True
            End If

            myForm.ShowDialog()
            Marcab = myForm.Txt_Marca.Text

            Proveedorb = myForm.Txt_Proveedor.Text

            If myForm.Chk_FechaOrden.Checked = True Then
                FechaInib = Format(myForm.DTPicker2.Value, "yyyy-MM-dd")
                FechaFinb = Format(myForm.DTPicker3.Value, "yyyy-MM-dd")
            Else
                FechaInib = "1900-01-01"
                FechaFinb = "1900-01-01"

            End If
            If myForm.Chk_FechaEntrega.Checked = True Then
                VenceInib = Format(myForm.DTPicker4.Value, "yyyy-MM-dd")
                VenceFinb = Format(myForm.DTPicker5.Value, "yyyy-MM-dd")
            Else
                VenceInib = "1900-01-01"
                VenceFinb = "1900-01-01"
            End If

            If myForm.Chk_FechaRec.Checked = True Then
                FechaRecInib = Format(myForm.DTPicker6.Value, "yyyy-MM-dd")
                FechaRecFinB = Format(myForm.DTPicker7.Value, "yyyy-MM-dd")
            Else
                FechaRecInib = "1900-01-01"
                FechaRecFinB = "1900-01-01"
            End If

            If myForm.Chk_FechaPago.Checked = True Then
                FechaPagoInib = Format(myForm.DT_FechaPini.Value, "yyyy-MM-dd")
                FechaPagoFinB = Format(myForm.DT_FechaPFin.Value, "yyyy-MM-dd")
            Else
                FechaPagoInib = "1900-01-01"
                FechaPagoFinB = "1900-01-01"
            End If

            Sucursalb = myForm.Txt_Sucursal.Text
            Statusb = myForm.Cbo_Estatus.Text
            FactInib = myForm.Txt_OrdeComp1.Text
            FactFinb = myForm.Txt_OrdeComp2.Text


            FactProvInib = myForm.Txt_FactProv.Text
            FactProvFinb = myForm.Txt_FactProv1.Text
            IdFolioIniB = myForm.Txt_IdFolio.Text
            IdFolioFinB = myForm.Txt_IdFolio1.Text


            If myForm.Sw_Filtro = True Then
                Call RellenaGrid()
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub




    Private Sub NuevoPDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoPDToolStripMenuItem.Click
        Call Btn_Microsip_Click(sender, e)
    End Sub

    Private Sub EditarPDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditarPDToolStripMenuItem.Click
        Call Btn_Factura_Click(sender, e)
    End Sub

    Private Sub ConsultarPDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call Btn_Consultar_Click(sender, e)
    End Sub
    Private Sub AgregarColumna()
        'mreyes 21/Marzo/2012 09:52 a.m.

        Dim colImagen As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        colImagen.Name = "MicroSip"
        colImagen.HeaderText = "MicroSip"
        colImagen.DisplayIndex = 18
        colImagen.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        colImagen.CellTemplate = New DataGridViewCheckBoxCell()
        ' añadir columna de imagen a la coleccion del grid 
        DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        ''DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DGrid.Columns.Add(colImagen)


    End Sub

    Private Function ActualizarFactura(ByVal Proveedor As String, ByVal Referenc As String, ByVal Fecha As Date, ByVal FechaVence As Date) As Boolean
        'mreyes 23/Abril/2012 09:48 p.m.

        Using objPedidos As New BCL.BCLFacturas(GLB_ConStringCipSis)
            Try
                'Get the specific project selected in the ListView control
                ActualizarFactura = objPedidos.usp_ActualizarFacturas(Proveedor, Referenc, Fecha, FechaVence)
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function
    Private Sub Btn_Microsip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Call microsipantes
        Try

            'Dim Archivos As Integer = 0

            'If MsgBox("Esta seguro de querer generar los archivos de Póliza de Compras para Microsip?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub
            'GLB_CLayout = pub_TraerParame_Det("CLAYOUT")

            'Dim Archivo As String = "c:\Layout\PolCompras" & Replace(Replace(Format(Date.Now, "yyyy-MM-dd hh:mm:ss"), "-", ""), ":", "") & ".txt"
            'Dim Linea As String = ""
            'Dim Encabezado As String = "|1|C,," & Format(Now, "dd/mm/yyyy") & ",MN,1,," & "Póliza de Compras" & ",,"
            'Dim sw As New System.IO.StreamWriter(Archivo)
            'Linea = Encabezado
            'sw.WriteLine(Linea)
            'Linea = Encabezado

            'Using objPedidos As New BCL.BCLPedidos(GLB_ConStringCipSis)
            '    Try
            '        Dim objDataSet As Data.DataSet
            '        Dim Corrida As String
            '        Dim Entrega As Date
            '        Dim Cancela As Date
            '        Dim margen As Double
            '        Dim Sucursal As String = ""


            '        objDataSet = objPedidos.usp_TraerDet_Oc(Txt_Sucursal.Text, Txt_OrdeComp.Text)
            '        DGrid.Visible = False
            '        If objDataSet.Tables(0).Rows.Count > 0 Then
            '            For I As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1

            '                Corrida = objDataSet.Tables(0).Rows(I).Item("corrida").ToString
            '                Entrega = Format(objDataSet.Tables(0).Rows(I).Item("entrega"), "dd-MM-yyyy")
            '                Txt_FechaEntrega.Text = Entrega
            '                Cancela = Format(objDataSet.Tables(0).Rows(I).Item("cancela"), "dd-MM-yyyy")

            '                margen = Format(pub_CalcularMargenPedido(Val(objDataSet.Tables(0).Rows(I).Item("precio")), Val(objDataSet.Tables(0).Rows(I).Item("pcomp"))), "#0.00")
            '                margen = Format(pub_CalcularMargenPedido(Val(objDataSet.Tables(0).Rows(I).Item("precio")), Val(objDataSet.Tables(0).Rows(I).Item("costo"))), "#0.00")
            '                MedidaEstilo = objDataSet.Tables(0).Rows(I).Item("medida")
            '                DGrid.Rows.Add("", "", "", "", "", "", objDataSet.Tables(0).Rows(I).Item("claveedi").ToString, _
            '                                 objDataSet.Tables(0).Rows(I).Item("claveed").ToString, _
            '                                 objDataSet.Tables(0).Rows(I).Item("claveff").ToString, _
            '                                 objDataSet.Tables(0).Rows(I).Item("claveel").ToString, _
            '                                 objDataSet.Tables(0).Rows(I).Item("estilof").ToString, _
            '                                 objDataSet.Tables(0).Rows(I).Item("estilon"), _
            '                                 objDataSet.Tables(0).Rows(I).Item("descripc"), _
            '                                 objDataSet.Tables(0).Rows(I).Item("corrida").ToString, _
            '                                 objDataSet.Tables(0).Rows(I).Item("intervalo").ToString, _
            '                                 objDataSet.Tables(0).Rows(I).Item("medini").ToString, _
            '                                 objDataSet.Tables(0).Rows(I).Item("medfin").ToString, _
            '                                  Format(Val(objDataSet.Tables(0).Rows(I).Item("pcomp").ToString), "#,##0.00"), Format(Val(objDataSet.Tables(0).Rows(I).Item("costo").ToString), "#,##0.00"), _
            '                                 Format(Val(objDataSet.Tables(0).Rows(I).Item("precio").ToString), "#,##0.00"), Format(margen, "#0.00"), _
            '                                 Txt_Sucursal.Text, Txt_DescripSucursal.Text, "", "", "", _
            '                                 "", "", "", "", "", "", "", "", "", "", _
            '                                 "", "", "", "", "", "", "", "", "", "", _
            '                                 "", "", "", "", "", "", "", "", "", "", _
            '                                "", "", "", "", "", "", "", "", "", "", _
            '                                "", "", "", _
            '                                "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", _
            '                                "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", _
            '                                 "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", Entrega, Cancela, _
            '                                 objDataSet.Tables(0).Rows(I).Item("clavel1").ToString, objDataSet.Tables(0).Rows(I).Item("clavel2").ToString, _
            '                                  objDataSet.Tables(0).Rows(I).Item("clavel3").ToString, objDataSet.Tables(0).Rows(I).Item("clavel4").ToString, _
            '                                objDataSet.Tables(0).Rows(I).Item("clavel5").ToString, objDataSet.Tables(0).Rows(I).Item("clavel6").ToString, _
            '                                objDataSet.Tables(0).Rows(I).Item("descripdivision") & "\" & _
            '                                                                objDataSet.Tables(0).Rows(I).Item("descripdepto") & "\" & _
            '                                                                objDataSet.Tables(0).Rows(I).Item("descripfamilia") & "\" & _
            '                                                                objDataSet.Tables(0).Rows(I).Item("descriplinea") & "\" & _
            '                                                                objDataSet.Tables(0).Rows(I).Item("descripl1") & "\" & _
            '                                                                objDataSet.Tables(0).Rows(I).Item("descripl2") & "\" & _
            '                                                                objDataSet.Tables(0).Rows(I).Item("descripl3") & "\" & _
            '                                                                objDataSet.Tables(0).Rows(I).Item("descripl4") & "\" & _
            '                                                                objDataSet.Tables(0).Rows(I).Item("descripl5") & "\" & _
            '                                                                objDataSet.Tables(0).Rows(I).Item("descripl6"))






            '            Next

            '        End If

            '        DGrid.Visible = True


            '        '''' LLENAR DETALLADO DE ORDE COMP
            '    Catch ExceptionErr As Exception
            '        MessageBox.Show(ExceptionErr.Message.ToString)
            '    End Try
            'End Using

            'Linea = CuentaNos & pub_RellenarIzquierda(Cont, 6) & SumPagoDec & "000001" & SumPagoDec
            'sw.WriteLine(Linea)
            'sw.Close()
            'If ActualizarParameDet("CLAYOUT", pub_RellenarIzquierda(Val(GLB_CLayout) + 1, 4)) Then

            'End If

            'MsgBox("Archivo creado en '" & Archivo & "')", MsgBoxStyle.Information, "Confirmación")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub MicroSipAntes()
        'mreyes 16/Marzo/2012 06:24 p.m.
        If Sw_NoRegistros = False Then Exit Sub
        '' PRIMERO TIENE QUE GENERAR EL ID DOCTO PARA GRABAR EN DOCTOS_CP
        Try
            If MsgBox("Esta seguro de querer traspasar las Facturas a Microsip?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub
            Me.Cursor = Cursors.WaitCursor
            Dim Docto_Id As Integer = 0
            Dim Docto_IdB As Integer = 0
            Dim Proveedor_Id As Integer = 0
            Dim Clave_Prov As String = ""
            Dim Folio As String = ""
            Dim Fecha As Date
            Dim Observaciones As String = ""
            Dim Cond_Pago_Id As Integer = 0
            Dim Porc As Integer = 0
            Dim Impte_Docto_cp_id As Integer = 0
            Dim Impte_Docto_cp_impto_id As Integer = 0
            Dim importe As Double = 0
            Dim impuesto As Double = 0
            Dim Dias As Integer = 0
            Dim FechaVencimiento As Date
            Dim iva As Integer = 16
            Dim Subtotal As Decimal = 0
            Dim Cont As Integer = 0
            Dim ContM As Integer = 0
            Dim Gastos As Double = 0
            Dim Proveedor As String = ""
            Dim Referenc As String = ""
            Dim IdFolioB As String = ""

            For Each row As DataGridViewRow In DGrid.Rows

                IdFolioB = row.Cells("idfoliosuc").Value


                If row.Cells("MicroSip").Value = True Then
                    Folio = pub_RellenarIzquierda(row.Cells("referenc").Value, 9)
                    Fecha = Format(row.Cells("fecha").Value, "dd-MM-yyyy")
                    Using objMicrosip As New BCL.BCLMicrosip(GLB_ConStringMicrosip)
                        objDataSet = objMicrosip.usp_Traer_Proveedor(0, Trim(Mid(row.Cells("proveedor").Value, 7)))
                        If objDataSet.Tables(0).Rows.Count > 0 Then
                            Proveedor_Id = Val(objDataSet.Tables(0).Rows(0).Item("proveedor_idB").ToString)
                            Cond_Pago_Id = Val(objDataSet.Tables(0).Rows(0).Item("cond_pago_idB").ToString)
                            Porc = Val(objDataSet.Tables(0).Rows(0).Item("porcb").ToString)
                            Dias = Val(objDataSet.Tables(0).Rows(0).Item("diasb").ToString)
                            Clave_Prov = objDataSet.Tables(0).Rows(0).Item("clave_provB").ToString
                        End If
                    End Using
                    Docto_IdB = ups_Traer_Doctos_CP(51, Proveedor_Id, Folio, Fecha, Clave_Prov)
                    If Docto_IdB = 0 And Proveedor_Id <> 0 Then
                        '' no existe dada de alta la factura en microsip 
                        Docto_Id = Gen_Doctos_Id()
                        Impte_Docto_cp_id = Gen_Doctos_Id()
                        Impte_Docto_cp_impto_id = Gen_Doctos_Id()
                        '' traer proveedor 
                        Observaciones = row.Cells("observa").Value & ""
                        Folio = pub_RellenarIzquierda(row.Cells("referenc").Value, 9)
                        Referenc = "F-" & row.Cells("referenc").Value
                        Proveedor = Mid(row.Cells("proveedor").Value, 1, 3)
                        Fecha = Format(row.Cells("fecha").Value, "dd-MM-yyyy")
                        FechaVencimiento = Format(row.Cells("fecvenc").Value, "dd-MM-yyyy")
                        FechaVencimiento = Format(Fecha.Add(New TimeSpan(Dias, 0, 0, 0)), "dd-MM-yyyy")
                        row.Cells("fecvenc").Value = Format(FechaVencimiento, "dd-MM-yyyy")
                        Subtotal = Val(row.Cells("subtotal").Value)
                        impuesto = Val(row.Cells("impuesto").Value)
                        Gastos = Val(row.Cells("gastos").Value)
                        'Gastos = Gastos - 1
                        If Val(row.Cells("descuento").Value) > 0 Then
                            Gastos = Gastos - Val(row.Cells("descuento").Value)
                        End If
                        importe = Val(row.Cells("importe").Value)  '+ Val(row.Cells("gastos").Value)
                        ' Documentos para facturas...
                        If Inserta_Doctos_CP_Microsip(Docto_Id, Folio, Fecha, Clave_Prov, Proveedor_Id, Observaciones, Cond_Pago_Id, FechaVencimiento, Porc, IdFolioB) Then

                        End If
                        ' Programación nueva para ir por plazos
                        ' mreyes 25/Mayo/2012 10:51 a.m.

                        'Using objMicrosip As New BCL.BCLMicrosip(GLB_ConStringMicrosip)
                        '    Dim PorcVence As Double = 0
                        '    Dim DiasVence As Integer = 0
                        '    objDataSet = objMicrosip.usp_Traer_Plazos_Cond_Pag_Cp(Cond_Pago_Id)
                        '    If objDataSet.Tables(0).Rows.Count > 0 Then
                        '        For x As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                        '            PorcVence = Val(objDataSet.Tables(0).Rows(x).Item("pctje_ven").ToString)
                        '            DiasVence = Val(objDataSet.Tables(0).Rows(x).Item("dias_plazo").ToString)
                        '            FechaVencimiento = Format(Fecha.Add(New TimeSpan(DiasVence, 0, 0, 0)), "dd-MM-yyyy")
                        '            If Inserta_Vencimientos_Cargos_CP_Microsip(Docto_Id, FechaVencimiento, PorcVence) Then

                        '            End If
                        '        Next
                        '    End If
                        'End Using

                        If Inserta_Vencimientos_Cargos_CP_Microsip(Docto_Id, FechaVencimiento, 100) Then

                        End If

                        If Gastos = 0 Then
                            If Inserta_Importes_Doctos_CP_Microsip(Impte_Docto_cp_id, Docto_Id, Subtotal, impuesto, 0) Then

                            End If

                            If Inserta_Importes_Doctos_CP_IMPTOS_Microsip(Impte_Docto_cp_impto_id, Impte_Docto_cp_id, Subtotal, iva, impuesto) Then

                            End If
                        Else
                            If Inserta_Importes_Doctos_CP_Microsip(Impte_Docto_cp_id, Docto_Id, Subtotal + Gastos, impuesto, 0) Then

                            End If

                            If Inserta_Importes_Doctos_CP_IMPTOS_Microsip(Impte_Docto_cp_impto_id, Impte_Docto_cp_id, Subtotal + Gastos, iva, impuesto) Then

                            End If

                        End If

                        If Inserta_Libres_Cargos_CP_Microsip(Docto_Id) Then

                        End If

                        '' Actualizar Factura en MYSQL... 
                        If ActualizarFactura(Proveedor, Referenc, Fecha, FechaVencimiento) = False Then

                            ' Throw New Exception("Fallo actualización de cantidad solicitada")
                        End If

                        Cont = Cont + 1
                        row.DefaultCellStyle.BackColor = Color.LightGreen
                    Else

                        If Proveedor_Id = 0 Then
                            row.DefaultCellStyle.BackColor = Color.Yellow
                        Else
                            'mODIFICACIÓN DE FACTURAS. 

                            ContM = ContM + 1

                            If Actualizar_Doctos_CP_Microsip(Docto_IdB, pub_RellenarIzquierda(row.Cells("referenc").Value, 9), IdFolioB) = False Then
                                row.DefaultCellStyle.BackColor = Color.Red
                            Else
                                row.DefaultCellStyle.BackColor = Color.PowderBlue
                            End If


                        End If

                    End If

                End If ' del microsip 
            Next
            Me.Cursor = Cursors.Default
            MsgBox("Se han traspasado '" & Cont & "' Facturas a MicroSip. Se han modificado '" & ContM & "' NÚMEROS DE FACTURAS' ", MsgBoxStyle.Information, "Confirmación")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Function Gen_Doctos_Id() As Integer
        'mreyes 16/Marzo/2012 06:25 p.m.
        Try
            Dim objDataset As Data.DataSet
            Gen_Doctos_Id = 0
            Using objMicrosip As New BCL.BCLMicrosip(GLB_ConStringMicrosip)
                objDataset = objMicrosip.usp_Gen_Docto_Id()
                If objDataset.Tables(0).Rows.Count > 0 Then
                    Gen_Doctos_Id = Val(objDataset.Tables(0).Rows(0).Item(0).ToString)

                Else
                    Gen_Doctos_Id = 1
                End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Private Function ups_Traer_Doctos_CP(ByVal Concepto_CP_ID As Integer, ByVal Proveedor_Id As Integer, ByVal Folio As String, ByVal Fecha As Date, ByVal Clave_Prov As String) As Integer
        'mreyes 16/Marzo/2012 06:25 p.m.
        Try
            Dim objDataset As Data.DataSet
            ups_Traer_Doctos_CP = 0
            Using objMicrosip As New BCL.BCLMicrosip(GLB_ConStringMicrosip)
                objDataset = objMicrosip.usp_Traer_Doctos_CP(Concepto_CP_ID, Proveedor_Id, Folio, "1900/01/01", Clave_Prov)
                If objDataset.Tables(0).Rows.Count > 0 Then
                    ups_Traer_Doctos_CP = Val(objDataset.Tables(0).Rows(0).Item("docto_cp_idB").ToString)

                End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function
    Function Inserta_Doctos_CP_Microsip(ByVal Docto_Id As Integer, ByVal Factura As String, ByVal Fecha As Date, ByVal Clave_Prov As String, _
                                        ByVal Proveedor_Id As Integer, ByVal Observaciones As String, _
                                        ByVal cond_pago_id As Integer, ByVal fecha_dscto_ppag As Date, ByVal pctje_dscto_ppag As Integer, ByVal IdFolioB As String) As Boolean
        'mreyes 16/Marzo/2012 05:37 a.m.

        Using objMicrosip As New BCL.BCLMicrosip(GLB_ConStringMicrosip)
            'Get a new Project DataSet
            Try
                Dim objDataset As Data.DataSet


                'Set the values in the DataRo
                objDataset = objMicrosip.Inserta_Doctos_CP     'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataset.Tables(0).NewRow

                objDataRow.Item("docto_cp_id") = Docto_Id
                objDataRow.Item("concepto_cp_id") = 51
                objDataRow.Item("folio") = pub_RellenarIzquierda(Factura, 9)
                objDataRow.Item("naturaleza_concepto") = "C"
                objDataRow.Item("fecha") = Format(Fecha, "dd-MM-yyyy")
                objDataRow.Item("clave_prov") = Clave_Prov
                objDataRow.Item("proveedor_id") = Proveedor_Id
                objDataRow.Item("tipo_cambio") = "1.0"
                objDataRow.Item("cancelado") = "N"
                objDataRow.Item("aplicado") = "S"
                objDataRow.Item("descripcion") = Observaciones
                objDataRow.Item("forma_emitida") = "N"
                objDataRow.Item("contabilizado") = "N"
                objDataRow.Item("contabilizado_gyp") = "N"
                objDataRow.Item("cond_pago_id") = cond_pago_id
                objDataRow.Item("fecha_dscto_ppag") = fecha_dscto_ppag
                objDataRow.Item("pctje_dscto_ppag") = pctje_dscto_ppag
                objDataRow.Item("exportado") = "N"
                objDataRow.Item("sistema_origen") = "CP"
                objDataRow.Item("integ_ba") = "N"
                objDataRow.Item("contabilizado_ba") = "N"
                objDataRow.Item("usuario_creador") = GLB_Usuario


                'Add the DataRow to the DataSet
                objDataset.Tables(0).Rows.Add(objDataRow)

                'Add the Project
                If Not objMicrosip.usp_Inserta_Doctos_CP(1, IdFolioB, objDataset) Then
                    ' Throw New Exception("Falló Inserción de Proveedores a Microsip")
                Else
                    Inserta_Doctos_CP_Microsip = True
                End If
                Inserta_Doctos_CP_Microsip = True
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Function Inserta_Importes_Doctos_CP_Microsip(ByVal Impte_Docto_cp_id As Integer, ByVal Docto_Id As Integer, _
                                                 ByVal importe As Decimal, ByVal impuesto As Decimal, _
                                                 ByVal dscto_ppag As Integer) As Boolean
        'mreyes 17/Marzo/2012 11:24 a.m.

        Using objMicrosip As New BCL.BCLMicrosip(GLB_ConStringMicrosip)
            'Get a new Project DataSet
            Try
                Dim objDataset As Data.DataSet


                'Set the values in the DataRo
                objDataset = objMicrosip.Inserta_Importes_Doctos_CP      'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataset.Tables(0).NewRow

                objDataRow.Item("impte_docto_cp_id") = Impte_Docto_cp_id
                objDataRow.Item("docto_cp_id") = Docto_Id
                objDataRow.Item("cancelado") = "N"
                objDataRow.Item("aplicado") = "S"
                objDataRow.Item("tipo_impte") = "C"
                objDataRow.Item("docto_cp_acr_id") = Docto_Id
                objDataRow.Item("importe") = importe
                objDataRow.Item("impuesto") = impuesto
                objDataRow.Item("iva_retenido") = 0
                objDataRow.Item("isr_retenido") = 0
                objDataRow.Item("dscto_ppag") = dscto_ppag


                'Add the DataRow to the DataSet
                objDataset.Tables(0).Rows.Add(objDataRow)

                'Add the Project
                If Not objMicrosip.usp_Inserta_Importes_Doctos_CP(1, objDataset) Then
                    ' Throw New Exception("Falló Inserción de Proveedores a Microsip")
                Else
                    Inserta_Importes_Doctos_CP_Microsip = True
                End If


                Inserta_Importes_Doctos_CP_Microsip = True
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Function Inserta_Importes_Doctos_CP_IMPTOS_Microsip(ByVal Impte_docto_cp_impto_id As Integer, ByVal Impte_Docto_Cp_Id As Integer, ByVal Subtotal As Decimal, ByVal Iva As Integer, ByVal Impuesto As Decimal) As Boolean
        'mreyes 20/Marzo/2012 05:07 p.m.

        Using objMicrosip As New BCL.BCLMicrosip(GLB_ConStringMicrosip)
            'Get a new Project DataSet
            Try
                Dim objDataset As Data.DataSet


                'Set the values in the DataRo
                objDataset = objMicrosip.Inserta_Importes_Doctos_CP_IMPTOS      'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataset.Tables(0).NewRow

                objDataRow.Item("impte_docto_cp_IMPTO_id") = Impte_docto_cp_impto_id
                objDataRow.Item("impte_docto_cp_id") = Impte_Docto_Cp_Id
                objDataRow.Item("imIdPuesto") = 4377
                objDataRow.Item("importe") = Subtotal
                objDataRow.Item("pctje_impuesto") = Iva
                objDataRow.Item("impuesto") = Impuesto



                'Add the DataRow to the DataSet
                objDataset.Tables(0).Rows.Add(objDataRow)

                'Add the Project
                If Not objMicrosip.usp_Inserta_Importes_Doctos_CP_IMPTOS(1, objDataset) Then
                    ' Throw New Exception("Falló Inserción de Proveedores a Microsip")
                Else
                    Inserta_Importes_Doctos_CP_IMPTOS_Microsip = True
                End If


                Inserta_Importes_Doctos_CP_IMPTOS_Microsip = True
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Function Inserta_Libres_Cargos_CP_Microsip(ByVal Docto_Id As Integer) As Boolean
        'mreyes 20/Marzo/2012 04:53 a.m.

        Using objMicrosip As New BCL.BCLMicrosip(GLB_ConStringMicrosip)
            'Get a new Project DataSet
            Try
                Dim objDataset As Data.DataSet


                'Set the values in the DataRo
                objDataset = objMicrosip.Inserta_Libres_Cargos_CP      'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataset.Tables(0).NewRow

                objDataRow.Item("docto_cp_id") = Docto_Id
                'Add the DataRow to the DataSet
                objDataset.Tables(0).Rows.Add(objDataRow)

                'Add the Project
                If Not objMicrosip.usp_Inserta_Libres_Cargos_CP(1, objDataset) Then
                    ' Throw New Exception("Falló Inserción de Proveedores a Microsip")
                Else
                    Inserta_Libres_Cargos_CP_Microsip = True
                End If


                Inserta_Libres_Cargos_CP_Microsip = True
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function


    Function Actualizar_Doctos_CP_Microsip(ByVal Docto_IdB As Integer, ByVal Folio As String, ByVal idfoliob As String) As Boolean
        'mreyes 24/Junio/2013 01:20 p.m.

        Using objMicrosip As New BCL.BCLMicrosip(GLB_ConStringMicrosip)
            'Get a new Project DataSet
            Try
                Dim objDataset As Data.DataSet


                'Set the values in the DataRo
                objDataset = objMicrosip.Inserta_Doctos_CP      'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataset.Tables(0).NewRow

                objDataRow.Item("docto_cp_id") = Docto_IdB
                objDataRow.Item("folio") = Folio

                'Add the DataRow to the DataSet
                objDataset.Tables(0).Rows.Add(objDataRow)

                'Add the Project
                If Not objMicrosip.usp_Inserta_Doctos_CP(2, idfoliob, objDataset) Then
                    ' Throw New Exception("Falló Inserción de Proveedores a Microsip")
                Else
                    Actualizar_Doctos_CP_Microsip = True
                End If


                Actualizar_Doctos_CP_Microsip = True
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Function Inserta_Vencimientos_Cargos_CP_Microsip(ByVal Docto_Id As Integer, ByVal FechaVencimiento As Date, ByVal Pctje_Ven As Integer) As Boolean
        'mreyes 20/Marzo/2012 05:46 a.m.

        Using objMicrosip As New BCL.BCLMicrosip(GLB_ConStringMicrosip)
            'Get a new Project DataSet
            Try
                Dim objDataset As Data.DataSet


                'Set the values in the DataRo
                objDataset = objMicrosip.Inserta_Vencimientos_Cargos_CP      'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataset.Tables(0).NewRow

                objDataRow.Item("docto_cp_id") = Docto_Id
                objDataRow.Item("fecha_vencimiento") = FechaVencimiento
                objDataRow.Item("pctje_ven") = Pctje_Ven
                'Add the DataRow to the DataSet
                objDataset.Tables(0).Rows.Add(objDataRow)

                'Add the Project
                If Not objMicrosip.usp_Inserta_Vencimientos_Cargos_CP(1, objDataset) Then
                    ' Throw New Exception("Falló Inserción de Proveedores a Microsip")
                Else
                    Inserta_Vencimientos_Cargos_CP_Microsip = True
                End If


                Inserta_Vencimientos_Cargos_CP_Microsip = True
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function


    Private Sub Factura_Microsip()
        'mreyes 21/Marzo/2012 11:53 a.m.

        For Each row As DataGridViewRow In DGrid.Rows


            If row.Cells("MicroSip").Value = True Then
                row.Cells("MicroSip").Value = False
            Else
                row.Cells("MicroSip").Value = True
            End If


        Next
    End Sub



    Private Sub Btn_InvertirSeleccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_InvertirSeleccion.Click
        If Sw_NoRegistros = False Then Exit Sub

        If Sw_Remision = True Then
            Call MarcarSelec()
        Else
            Call Factura_Microsip()
        End If

    End Sub

    Private Sub Btn_Factura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Factura.Click
        'mreyes 22/Marzo/2012 01:53 p.m.
        If Sw_NoRegistros = False Then Exit Sub

        Dim myForm As New frmCatalogoPedidoNuevo
        Sw_Boton = True
        myForm.Accion = 4
        myForm.Txt_Sucursal.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("sucursal").Value.ToString.Trim()
        If Sw_Remision = True Then
            myForm.Txt_OrdeComp.Text = "R-" & DGrid.Rows(DGrid.CurrentRow.Index).Cells("referenc").Value.ToString.Trim()
        Else

            myForm.Txt_OrdeComp.Text = "F-" & DGrid.Rows(DGrid.CurrentRow.Index).Cells("referenc").Value.ToString.Trim()
        End If
        myForm.Txt_NoBulto.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idfoliosuc").Value.ToString.Trim()
        myForm.FolioB = DGrid.Rows(DGrid.CurrentRow.Index).Cells("IDFOLIO").Value.ToString.Trim()

        myForm.Sw_Factura = True
        myForm.MdiParent = BitacoraMain
        myForm.Show()
        ' Call RellenaGrid()
    End Sub




    Private Sub DGrid_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGrid.CellFormatting
        Try
            Dim Sw_NoEntro As Boolean = False

            Dim DiasEntrega As Integer = 0
            If Sw_Pintar = False Then Exit Sub
            'If Opcion <> 1 Then Exit Sub

            If Me.DGrid.Columns(e.ColumnIndex).Name <> "dias" Then Exit Sub
            If e.RowIndex = DGrid.RowCount - 1 Then
                If Sw_Load = False Then
                    Sw_Pintar = False
                End If
                Exit Sub
            End If

            If IsNothing(DGrid.Rows(e.RowIndex).Cells("dias").Value) Then Exit Sub
            If IsDBNull(DGrid.Rows(e.RowIndex).Cells("dias").Value) Then Exit Sub


            If DGrid.Rows(e.RowIndex).Cells("dias").Value < 0 Then
                DGrid.Rows(e.RowIndex).Cells("dias").Style.BackColor = Color.Red
                DGrid.Rows(e.RowIndex).Cells("dias").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If

            If DGrid.Rows(e.RowIndex).Cells("marca").Value <> "" Then
                DGrid.Rows(e.RowIndex).Cells("marca").Style.BackColor = Color.Yellow
                DGrid.Rows(e.RowIndex).Cells("marca").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                If DGrid.Rows(e.RowIndex).Cells("cargo").Value = 0 Then
                    DGrid.Rows(e.RowIndex).Cells("marca").Style.BackColor = Color.Red
                    DGrid.Rows(e.RowIndex).Cells("marca").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                End If

            End If


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub




    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub

   
    Private Sub ImprimirReporte()
        Try
            Dim myForm As New frmReportsBrowser

            myForm.objDataSetRemision = GenerarReporte()
            myForm.ReportIndex = 11
            myForm.Show()


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Function GenerarReporte() As DSPRemision
        'Roberto 04/03/13
        Try
            GenerarReporte = New DSPRemision
            'Dim obj As New Data.DataSet
            'Dim myform As New frmFichaRemision
            'obj = myform.objDataSet

            With DGrid
                For I As Integer = 0 To .Rows.Count - 2
                    If .Rows(I).Cells("Selec").Value = True Then
                        Dim objDataRow As Data.DataRow = GenerarReporte.Tables(0).NewRow()
                        sucursal = .Rows(I).Cells(0).Value
                        objDataRow.Item("referenc") = .Rows(I).Cells(2).Value
                        'objDataRow.Item("idfolio") = .Tables(0).Rows(I).Item("idfolio").ToString
                        objDataRow.Item("idfoliosuc") = .Rows(I).Cells(4).Value
                        objDataRow.Item("status") = .Rows(I).Cells(5).Value
                        objDataRow.Item("fecha") = .Rows(I).Cells(6).Value
                        objDataRow.Item("fecvenc") = .Rows(I).Cells(7).Value
                        'objDataRow.Item("marca") = .Tables(0).Rows(I).Item("idfolio").ToString
                        objDataRow.Item("proveedor") = .Rows(I).Cells(9).Value
                        objDataRow.Item("pares") = .Rows(I).Cells(10).Value
                        objDataRow.Item("SUBTOTAL") = .Rows(I).Cells(11).Value
                        objDataRow.Item("gastos") = .Rows(I).Cells(12).Value
                        objDataRow.Item("IMPUESTO") = .Rows(I).Cells(13).Value
                        objDataRow.Item("descuento") = .Rows(I).Cells(14).Value
                        objDataRow.Item("importe") = .Rows(I).Cells(15).Value
                        objDataRow.Item("fechadep") = fechadep
                        objDataRow.Item("referencia") = referencia
                        objDataRow.Item("importe2") = importe.Substring(1)
                        GenerarReporte.Tables(0).Rows.Add(objDataRow)
                        Using objImpreso As New BCL.BCLFacturas(GLB_ConStringCipSis)
                            objImpreso.usp_ImprimirMasUno(sucursal, .Rows(I).Cells(2).Value)
                        End Using
                    End If

                Next
            End With
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Private Sub Btn_Proveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Reporte = 1
        LimpiarBusqueda()
        Statusb = "PENDIENTE"


        Call RellenaGrid(3)
    End Sub

    Private Sub AgregarColumnaFicha()
        'mreyes 21/Marzo/2012 09:52 a.m.

        Dim colImagen As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        colImagen.Name = "Selec"
        colImagen.HeaderText = "Pagar"
        colImagen.DisplayIndex = 18
        colImagen.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        colImagen.CellTemplate = New DataGridViewCheckBoxCell()
        ' añadir columna de imagen a la coleccion del grid 
        DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        ''DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DGrid.Columns.Add(colImagen)

    End Sub


    Private Sub AgregarColumnaRecibido()
        'mreyes 21/Marzo/2012 09:52 a.m.

        Dim colImagen As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        colImagen.Name = "SelecR"
        If Sw_Remision = True Then
            colImagen.HeaderText = "S"
        Else
            colImagen.HeaderText = "S"
        End If

        colImagen.DisplayIndex = 19
        colImagen.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        colImagen.CellTemplate = New DataGridViewCheckBoxCell()
        ' añadir columna de imagen a la coleccion del grid 
        DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        ''DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DGrid.Columns.Add(colImagen)

    End Sub


    Private Sub MarcarSelec()

        For i As Integer = 0 To DGrid.Rows.Count - 3

            If Sw_Remision = True Then
                If DGrid.Rows(i).Cells("Selec").Value = True Then
                    DGrid.Rows(i).Cells("Selec").Value = False
                Else
                    DGrid.Rows(i).Cells("Selec").Value = True
                End If
            End If
        Next
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

            'If Not IsDBNull(DGrid.Rows(DGrid.CurrentRow.Index).Cells("status").Value) Then
            'If DGrid.Rows(DGrid.CurrentRow.Index).Cells("status").Value = "PAGADO" Then
            '    RecibidoToolStripMenuItem1.Enabled = False
            'End If

            'If DGrid.Rows(DGrid.CurrentRow.Index).Cells("status").Value = "STAND BY" Then
            '    ConsultaMotivoToolStripMenuItem1.Enabled = True
            'Else
            '    ConsultaMotivoToolStripMenuItem1.Enabled = False
            'End If
            'Else

            'End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try


    End Sub

    Private Sub StandByToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles StandByToolStripMenuItem.Click
        Try
            Dim myForm As New frmMotivo
            Sw_Boton = True

            If DGrid.Rows(DGrid.CurrentRow.Index).Cells("status").Value = "PAGADO" Or _
            DGrid.Rows(DGrid.CurrentRow.Index).Cells("status").Value = "STAND BY" Or _
            DGrid.Rows(DGrid.CurrentRow.Index).Cells("status").Value = "EN LIQUIDACION" Or _
            DGrid.Rows(DGrid.CurrentRow.Index).Cells("status").Value = "AUTORIZADO" Or _
            DGrid.Rows(DGrid.CurrentRow.Index).Cells("status").Value = "CANCELADO" Then
                MsgBox("Solo puede poner en Stand By las Remisiones que están PENDIENTES O RECIBIDAS.", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If

            myForm.Opcion = 1
            myForm.Txt_Folio.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idfoliosuc").Value.ToString.Trim()
            myForm.Txt_IdFolio.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idfolio").Value.ToString.Trim()

            myForm.ShowDialog()

            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub RecibidoToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RecibidoToolStripMenuItem1.Click
        Try
            Call Btn_Recibido_Click(sender, e)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Recibido_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If Sw_Remision = True Then ''Si es remision

                Dim intContador As Integer = 0
                DGrid.Rows(DGrid.CurrentRow.Index).Cells("SelecR").Value = True

                'valida que este seleccionado por lo menos un registro
                For Each row As DataGridViewRow In DGrid.Rows
                    If row.Cells("SelecR").Value = True Then
                        If row.Cells("status").Value = "PENDIENTE" Or _
                        row.Cells("status").Value = "STAND BY" Then
                            intContador += 1
                        Else
                            MsgBox("Solo puede seleccionar Folios con estatus PENDIENTE o en STAND BY.", MsgBoxStyle.Critical, "Aviso")
                            Exit Sub
                        End If
                    End If
                Next

                If intContador = 0 Then
                    MsgBox("No se selecciono ningun Registro", MsgBoxStyle.OkOnly, "Aviso")
                    Exit Sub
                End If

                If MsgBox("Desea cambiar a RECIBIDO el Estatus de las Facturas seleccionadas?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub
                For i As Integer = 0 To DGrid.Rows.Count - 1
                    If DGrid.Rows(i).Cells("SelecR").Value = True Then
                        Using objCatCuentas As New BCL.BCLCatalogoCuentas(GLB_ConStringCipSis)
                            If Not objCatCuentas.usp_ActualizaPagoFactura(1, DGrid.Rows(i).Cells("idfoliosuc").Value.ToString.Trim(), "3", "", 0) Then
                                'Throw New Exception("No se pudo actualizar el Estatus.")
                            Else
                                'MsgBox("Estatus Actualizado correctamente.", MsgBoxStyle.Information, "Confirmación")
                            End If
                        End Using

                        ' Checar primero si el proveedor tiene condición de quincena

                        Using objProveedor As New BCL.BCLCatalogoProveedores(GLB_ConStringCipSis)
                            objDataSet = objProveedor.usp_TraerProveedor(Mid(DGrid.Rows(DGrid.CurrentRow.Index).Cells("proveedor").Value, 1, 3), Mid(DGrid.Rows(DGrid.CurrentRow.Index).Cells("marca").Value, 1, 3))
                            If objDataSet.Tables(0).Rows.Count > 0 Then
                                'Generar el emparrillado de pagos.
                                If objDataSet.Tables(0).Rows(0).Item("numpagos").ToString > 0 Then
                                    If Genera_Det_fpp() = True Then
                                        MsgBox("Se ha generado correctamente el emparrillado de pagos para el folio.", MsgBoxStyle.Information, "Aviso")

                                    End If
                                End If
                            End If
                        End Using
                        ' Generar detallado de pagos
                    End If
                Next
                MsgBox("Estatus Actualizado correctamente.", MsgBoxStyle.Information, "Confirmación")
                ' Generar detallado de pagos
                Call RellenaGrid()


            Else '' si es factura

                Dim intContador As Integer = 0
                DGrid.Rows(DGrid.CurrentRow.Index).Cells("SelecR").Value = True

                'valida que este seleccionado por lo menos un registro
                For Each row As DataGridViewRow In DGrid.Rows
                    If row.Cells("SelecR").Value = True Then
                        If row.Cells("status").Value = "PENDIENTE" Or _
                        row.Cells("status").Value = "STAND BY" Then
                            intContador += 1
                        Else
                            MsgBox("Solo puede seleccionar Facturas PENDIENTES o en STAND BY.", MsgBoxStyle.Critical, "Aviso")
                            Exit Sub
                        End If
                    End If
                Next

                If intContador = 0 Then
                    MsgBox("No se selecciono ningun Registro", MsgBoxStyle.OkOnly, "Aviso")
                    Exit Sub
                End If

                If MsgBox("Desea cambiar a RECIBIDO el Estatus de las Facturas seleccionadas?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub
                For i As Integer = 0 To DGrid.Rows.Count - 1
                    If DGrid.Rows(i).Cells("SelecR").Value = True Then
                        Using objCatCuentas As New BCL.BCLCatalogoCuentas(GLB_ConStringCipSis)
                            If Not objCatCuentas.usp_ActualizaPagoFactura(1, DGrid.Rows(i).Cells("idfoliosuc").Value.ToString.Trim(), "3", "", 0) Then
                                'Throw New Exception("No se pudo actualizar el Estatus.")
                            Else
                                'MsgBox("Estatus Actualizado correctamente.", MsgBoxStyle.Information, "Confirmación")
                            End If
                        End Using

                        ' Checar primero si el proveedor tiene condición de quincena

                        Using objProveedor As New BCL.BCLCatalogoProveedores(GLB_ConStringCipSis)
                            objDataSet = objProveedor.usp_TraerProveedor(Mid(DGrid.Rows(DGrid.CurrentRow.Index).Cells("proveedor").Value, 1, 3), DGrid.Rows(DGrid.CurrentRow.Index).Cells("marca").Value) 'checar variable
                            If objDataSet.Tables(0).Rows.Count > 0 Then
                                'Generar el emparrillado de pagos.
                                If objDataSet.Tables(0).Rows(0).Item("numpagos").ToString > 0 Then
                                    If Genera_Det_fpp() = True Then
                                        MsgBox("Se ha generado correctamente el emparrillado de pagos para el folio.", MsgBoxStyle.Information, "Aviso")

                                    End If
                                End If
                            End If
                        End Using
                        ' Generar detallado de pagos

                    End If
                Next
                MsgBox("Estatus Actualizado correctamente.", MsgBoxStyle.Information, "Confirmación")


                Call RellenaGrid()
            End If


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Function Genera_Det_fpp() As Boolean
        'mreyes 20/Enero/2014 09:59 a.m.

        Dim objDataset As Data.DataSet
        Dim idFolioB As Integer
        Genera_Det_fpp = False
        idFolioB = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idfolio").Value
        Using objFacturas As New BCL.BCLFacturas(GLB_ConStringCipSis)
            Try
                objDataset = objFacturas.usp_TraerDet_FPP(1, idFolioB)
                If objDataset.Tables(0).Rows.Count > 0 Then

                    'Si existe ya.
                    MsgBox("No se puede generar el emparrillado de pagos, puesto que ya existe.", MsgBoxStyle.Information, "Aviso")
                    Exit Function
                Else
                    'Generar el emparrillado de pagos.
                    Using objFacturas1 As New BCL.BCLFacturas(GLB_ConStringCipSis)
                        Try
                            'Get the specific project selected in the ListView control
                            Genera_Det_fpp = objFacturas1.usp_GeneraDet_FPP("", idFolioB)
                            If Genera_Det_fpp = False Then
                                'MsgBox("No se puede generar el emparillado, consulte con sistemas.", MsgBoxStyle.Critical, "Error")
                                ' Exit Function
                            End If
                        Catch ExceptionErr As Exception
                            MessageBox.Show(ExceptionErr.Message.ToString)
                        End Try
                    End Using
                    Genera_Det_fpp = True
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using


    End Function

    Private Sub ConsultaMotivoToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ConsultaMotivoToolStripMenuItem1.Click
        Try
            Dim myForm As New frmMotivo

            If DGrid.Rows(DGrid.CurrentRow.Index).Cells("status").Value <> "STAND BY" Then
                MsgBox("La Factura no tiene estatus de STAND BY.", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If

            myForm.Opcion = 4
            myForm.Txt_Folio.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idfoliosuc").Value.ToString.Trim()
            myForm.Txt_IdFolio.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idfolio").Value.ToString.Trim()

            myForm.ShowDialog()

            If myForm.Sw_Filtro = True Then
                Call RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ConsultarNotaToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ConsultarNotaToolStripMenuItem1.Click
        Try
            Dim myForm As New frmPpalCargos

            'If DGrid.Rows(DGrid.CurrentRow.Index).Cells("status").Value <> "STAND BY" Then
            '    MsgBox("La Factura no tiene estatus de STAND BY.", MsgBoxStyle.Critical, "Aviso")
            '    Exit Sub
            'End If
            If DGrid.Rows(DGrid.CurrentRow.Index).Cells("cargo").Value = 0 AndAlso DGrid.Rows(DGrid.CurrentRow.Index).Cells("credito").Value = 0 Then
                MsgBox("La Factura no tiene Notas de Cargo ó Crédito.", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If

            myForm.blnConsulta = True
            myForm.FolioBulto = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idfoliosuc").Value.ToString.Trim()

            myForm.MdiParent = BitacoraMain
            myForm.WindowState = FormWindowState.Maximized
            myForm.Show()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub VerPagoFichaToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles VerPagoFichaToolStripMenuItem1.Click
        Dim myForm2 As New frmFichaRemision
        Try
            If Sw_NoRegistros = False Then Exit Sub

            If DGrid.Rows(DGrid.CurrentRow.Index).Cells("status").Value <> "PAGADO" Then
                MsgBox("La Factura no está pagada.", MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If

            myForm2.Txt_IdFolio.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idfolio").Value
            myForm2.Txt_Folio.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idfoliosuc").Value
            myForm2.Prov = DGrid.Rows(DGrid.CurrentRow.Index).Cells("proveedor").Value
            myForm2.Accion = 4

            myForm2.ShowDialog()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Liquidacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim contChecks As Integer = 0
            Dim objDataSetLiquidacion As New DataSet
            objDataSetLiquidacion = objDataSet.Clone
            For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                If DGrid.Rows(i).Cells("selecR").Value Is Nothing Then Continue For
                If DGrid.Rows(i).Cells("selecR").Value = True Then
                    objDataSetLiquidacion.Tables(0).LoadDataRow(objDataSet.Tables(0).Rows(i).ItemArray, True)
                    contChecks += 1
                End If
            Next
            If contChecks > 0 Then
                Dim myForm1 As New frmLiquidacion
                myForm1.Remision = Sw_Remision
                myForm1.objDataSetLiquidacion = objDataSetLiquidacion
                myForm1.CBO_Cuentas.Visible = False
                myForm1.Label2.Visible = False
                myForm1.Label3.Visible = False
                myForm1.Label1.Text = "Fecha Inicio"
                myForm1.StartPosition = FormStartPosition.CenterScreen
                myForm1.blnAplicar = False
                myForm1.blnCheck = True
                myForm1.Pnl_Edicion.Enabled = False
                myForm1.Txt_Raz_Soc.Enabled = False
                myForm1.ShowDialog()
                Exit Sub
            End If


            Dim contador As Integer = 0
            For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                If IsDBNull(objDataSet.Tables(0).Rows(i).Item(0)) Then Continue For
                If objDataSet.Tables(0).Rows(i).Item("proveedor").ToString.Trim = "1505 - COMERCIAL D'PORTENIS, S.A. DE C.V." Then Continue For
                objDataSetLiquidacion.Tables(0).LoadDataRow(objDataSet.Tables(0).Rows(i).ItemArray, True)
                contador += 1
                'End If
            Next
            If contador = 0 Then
                MessageBox.Show("NO SE ENCONTRO INFORMACIÓN", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Dim myForm As New frmLiquidacion
            myForm.Remision = Sw_Remision
            myForm.objDataSetLiquidacion = objDataSetLiquidacion
            myForm.CBO_Cuentas.Visible = False
            myForm.Label2.Visible = False
            myForm.Label3.Visible = False
            myForm.Label1.Text = "Fecha Inicio"
            myForm.StartPosition = FormStartPosition.CenterScreen
            myForm.Show()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub ConsultarLiquidaciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultarLiquidaciónToolStripMenuItem.Click
        Try
            If DGrid.Rows(DGrid.CurrentRow.Index).Cells("status").Value <> "PAGADO" Then
                MessageBox.Show("Esta Factura no esta pagada, no puedes ver su Liquidación", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Dim myForm As New frmCatalogoLiquidacion
            myForm.Opcion = 2
            myForm.OpcionLiquidacion = 2
            myForm.idLiquidacion = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idliquidacion").Value
            myForm.MdiParent = BitacoraMain
            myForm.WindowState = FormWindowState.Maximized
            myForm.Show()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ConsultarDevoluciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultarDevoluciónToolStripMenuItem.Click
        ' ir a buscar si tiene una o varias devoluciones.


        Dim myForm As New frmCatalogoPedidoNuevo
        Sw_Boton = True
        myForm.Accion = 4
        myForm.Sw_Devolucion = True
        myForm.Txt_Sucursal.Text = Mid(DGrid.Rows(DGrid.CurrentRow.Index).Cells("marca").Value.ToString.Trim(), 1, 2)
        myForm.Txt_OrdeComp.Text = Mid(DGrid.Rows(DGrid.CurrentRow.Index).Cells("marca").Value.ToString.Trim(), 4, 6)
        myForm.MdiParent = BitacoraMain
        myForm.Show()
        Call RellenaGrid()
    End Sub

    Private Sub Btn_Estilos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Using objFactura As New BCL.BCLFacturas(GLB_ConStringCipSis)
            Try


                DGrid.DataSource = Nothing
                If GLB_CveSucursal > "0" And GLB_CveSucursal < "90" Then
                    Sucursalb = GLB_CveSucursal
                End If
                objDataSet = objFactura.usp_PpalFacturasDet(1, Sucursalb, Marcab, _
                                                                   Proveedorb, _
                                                                   FechaRecInib, FechaRecFinB)

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section
                    Sw_NoRegistros = True
                    DGrid.DataSource = objDataSet.Tables(0)
                    Sw_Pintar = True
                    InicializaGridEstilos()
                    'LimpiarBusqueda()
                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True

                    Btn_Consultar.Enabled = True

                    Btn_Factura.Enabled = True
                    Btn_InvertirSeleccion.Enabled = True


                    Sw_NoRegistros = True
                Else
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron Entradas que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                End If
                Btn_Excel.Enabled = False

                Btn_Consultar.Enabled = False
                Btn_Factura.Enabled = False
                Btn_InvertirSeleccion.Enabled = False




            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Sub InicializaGridEstilos()
        '' 
        'mreyes 12/Febrero/2011 05:37 p.m.
        Try

            'Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
            'Dim row As DataRow = dt.NewRow()
            '' row(3) = "Total: "
            'row(9) = "Total: "
            'row(10) = pub_SumarColumnaGrid(DGrid, 10, DGrid.RowCount - 1)
            'row(11) = pub_SumarColumnaGrid(DGrid, 11, DGrid.RowCount - 1)
            'row(12) = pub_SumarColumnaGrid(DGrid, 12, DGrid.RowCount - 1)
            'row(13) = pub_SumarColumnaGrid(DGrid, 13, DGrid.RowCount - 1)
            'row(14) = pub_SumarColumnaGrid(DGrid, 14, DGrid.RowCount - 1)
            'row(15) = pub_SumarColumnaGrid(DGrid, 15, DGrid.RowCount - 1)
            'row(16) = pub_SumarColumnaGrid(DGrid, 16, DGrid.RowCount - 1)
            'row(17) = pub_SumarColumnaGrid(DGrid, 17, DGrid.RowCount - 1)
            'dt.Rows.InsertAt(row, 0)
            'DGrid.DataSource = dt

            DGrid.RowHeadersVisible = False

            DGrid.Columns("sucursal").Visible = False
            DGrid.Columns("idarticulo").Visible = False
            DGrid.Columns("descripmarca").Visible = False
            DGrid.Columns("estilof").Visible = False
            DGrid.Columns("descripc").Visible = False
            DGrid.Columns("descripap").Visible = False
            DGrid.Columns("iddivisiones").Visible = False
            DGrid.Columns("claveedi").Visible = False
            DGrid.Columns("descripdivision").Visible = False
            DGrid.Columns("iddepto").Visible = False
            DGrid.Columns("claveed").Visible = False
            DGrid.Columns("descripdepto").Visible = False
            DGrid.Columns("idfamilia").Visible = False
            DGrid.Columns("claveff").Visible = False
            DGrid.Columns("descripfamilia").Visible = False
            DGrid.Columns("idlinea").Visible = False
            DGrid.Columns("claveel").Visible = False
            DGrid.Columns("descriplinea").Visible = False
            DGrid.Columns("idl1").Visible = False
            DGrid.Columns("clavel1").Visible = False
            DGrid.Columns("descripl1").Visible = False
            DGrid.Columns("idl2").Visible = False
            DGrid.Columns("clavel2").Visible = False
            DGrid.Columns("descripl2").Visible = False
            DGrid.Columns("idl3").Visible = False
            DGrid.Columns("clavel3").Visible = False
            DGrid.Columns("descripl3").Visible = False
            DGrid.Columns("idl4").Visible = False
            DGrid.Columns("clavel4").Visible = False
            DGrid.Columns("descripl4").Visible = False
            DGrid.Columns("idl5").Visible = False
            DGrid.Columns("clavel5").Visible = False
            DGrid.Columns("descripl5").Visible = False
            DGrid.Columns("idl6").Visible = False
            DGrid.Columns("clavel6").Visible = False
            DGrid.Columns("descripl6").Visible = False
            DGrid.Columns("medini").Visible = False
            DGrid.Columns("medfin").Visible = False
            DGrid.Columns("intervalo").Visible = False

            DGrid.Columns("suc").HeaderText = "Sucursal"
            DGrid.Columns("marca").HeaderText = "Marca"
            DGrid.Columns("estilon").HeaderText = "Modelo"
            DGrid.Columns("corrida").HeaderText = "Corrida"
            DGrid.Columns("estructura").HeaderText = "Estructura"
            DGrid.Columns("fecha").HeaderText = "Fecha"
            DGrid.Columns("pares").HeaderText = "Pares"
            DGrid.Columns("precio").HeaderText = "Precio"

            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells


            DGrid.Columns("suc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns("pares").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns("corrida").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns("precio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            DGrid.Columns("precio").DefaultCellStyle.Format = "c"

            DGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Imprimir.Click
        Dim myForm As New frmReportsBrowser

        myForm.objDataSetArticulosRecibidos = GenerarReporteArticulosRecibidos()
        myForm.ReportIndex = 160589
        myForm.Show()
    End Sub

    Private Function GenerarReporteArticulosRecibidos() As DSArticulosRecibidos
        'Roberto 04/03/13
        Try
            GenerarReporteArticulosRecibidos = New DSArticulosRecibidos
            With DGrid
                For I As Integer = 1 To .Rows.Count - 2

                    Dim objDataRow As Data.DataRow = GenerarReporteArticulosRecibidos.Tables(0).NewRow()
                    objDataRow.Item("sucursal") = .Rows(I).Cells("suc").Value
                    objDataRow.Item("marca") = .Rows(I).Cells("marca").Value
                    objDataRow.Item("modelo") = .Rows(I).Cells("estilon").Value
                    objDataRow.Item("corrida") = .Rows(I).Cells("corrida").Value
                    objDataRow.Item("estructura") = .Rows(I).Cells("estructura").Value
                    objDataRow.Item("fecha") = .Rows(I).Cells("fecha").Value
                    objDataRow.Item("pares") = .Rows(I).Cells("pares").Value
                    objDataRow.Item("precio") = .Rows(I).Cells("precio").Value
                    GenerarReporteArticulosRecibidos.Tables(0).Rows.Add(objDataRow)
                Next

            End With
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function


    Private Sub Btn_Layout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Layout.Click
        Try
            'mreyes 14/Octubre/2014 11:56 a.m.
            Dim Mes As String = ""
            If MsgBox("Esta seguro de querer generar el layout para el banco.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmación") = MsgBoxResult.No Then Exit Sub

            Dim Ruta As String = "c:\Factoraje\Bajio\" & Mes
            Mes = Format(CDate(Now.Date), "MMMM").ToUpper

            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)


                If objIO.pub_CrearDirectorio(ruta) Then
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
            Dim Producto As String = "CALTORR"
            Dim RFC As String = ""
            Dim factura As String = ""
            Dim fechafactura As Date = "1900-01-01"
            Dim fechavenc As Date = "1900-01-01"
            Dim sw As New System.IO.StreamWriter(Archivo)
            Dim Monto As Decimal = 0
            Cont = 0
            For i = 0 To DGrid.RowCount - 2
                ' CAST(Taller.cod_taller AS CHAR CHARACTER SET utf8 
                If DGrid.Rows(i).Cells("SelecR").Value = True Then
                    If DGrid.Rows(i).Cells("importe").Value > 0 Then
                        ' ACTUALIZAR FACTPROV.
                        'mreyes 31/Octubre/2014 05:44 p.m. fACTORAJE

                        Using objCatCuentas As New BCL.BCLCatalogoCuentas(GLB_ConStringCipSis)
                            If Not objCatCuentas.usp_GeneraDatosFactprovArchivoFactoraje(Mid(DGrid.Rows(i).Cells("PROVEEDOR").Value.ToString.Trim(), 1, 3), DGrid.Rows(i).Cells("idfolio").Value.ToString.Trim(), GLB_Idempleado) Then
                                'Throw New Exception("No se pudo actualizar el Estatus.")
                            Else
                                'MsgBox("Estatus Actualizado correctamente.", MsgBoxStyle.Information, "Confirmación")
                            End If
                        End Using

                        RFC = Replace(Trim(DGrid.Rows(i).Cells("marca").Value & ""), "-", "")
                        factura = DGrid.Rows(i).Cells("referenc").Value & ""
                        fechafactura = DGrid.Rows(i).Cells("FECHA").Value & ""
                        fechavenc = DGrid.Rows(i).Cells("fecvenc").Value & ""



                        fechafactura = Now.Date
                        fechavenc = DateAdd(DateInterval.Day, 180, fechafactura)
                        If Format(fechavenc, "ddd") = "dom" Then
                            fechavenc = DateAdd(DateInterval.Day, 178, fechafactura)
                        ElseIf Format(fechavenc, "ddd") = "sáb" Or Format(fechavenc, "ddd") = "sab" Then
                            fechavenc = DateAdd(DateInterval.Day, 179, fechafactura)
                        End If

                        Monto = Format(DGrid.Rows(i).Cells("importe").Value, "###0.00")
                        Linea = RFC & "|" & factura & "|" & fechafactura & "|" & fechavenc & "|" & Monto & "|" & Producto
                        '000000000000043683
                        Cont = Cont + 1
                        sw.WriteLine(Linea)
                    End If

                End If
            Next
            
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

            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick
        Call Btn_Factura_Click(sender, e)
    End Sub
End Class