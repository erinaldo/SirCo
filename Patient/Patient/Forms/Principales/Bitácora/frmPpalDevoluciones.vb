Public Class frmPpalDevoluciones
    'mreyes 29/Marzo/2012 10:04 p.m.
    Private objDataSet As Data.DataSet
    Public Sw_Registro As Boolean = False
    Public Sw_Serie As Boolean = False

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
    Dim Statusb As String
    Dim VenceInib As String
    Dim VenceFinb As String
    Dim DevInib As String
    Dim DevFinb As String

    Dim Folio As String = ""
    Dim IdFolioSuc As String = ""
    Dim ImporteTot As Decimal
    Dim Importe As Decimal
    Dim IVA As Decimal

    Dim IdFolioSucIniB As String
    Dim IdFolioSucFinB As String
    Dim FactProvInib As String
    Dim FactProvFinb As String

    Dim Sw_Load As Boolean = True
    Dim Sw_Boton As Boolean = False
    Dim Sw_NoRegistros As Boolean = False


    Private Sub frmPpalDevoluciones_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Sw_Load = True Then
            If Sw_NoRegistros = False Then
                Sw_Load = False
                ''     InicializaGrid()
                Devolucion_Microsip()
            Else
                Sw_Load = False
                'Sw_NoRegistros = False
            End If
        End If


        If Sw_NoRegistros = True Then
            DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
        End If

    End Sub





    Private Sub frmPpalDevoluciones_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
        If e.KeyCode = Keys.F5 Then
            Call Btn_Filtro_Click_1(sender, e)
        End If
    End Sub

    Private Sub frmPpalDevoluciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Sw_Load = True
            Call LimpiarBusqueda()
            FechaInib = Format(Now.Date, "yyyy-MM-dd")
            FechaFinb = Format(Now.Date, "yyyy-MM-dd")
            FechaInib = Format(Now.Add(New TimeSpan(-1, 0, 0, 0)), "yyyy-MM-dd")
            If GLB_Sw_Costos = True Then
                Btn_Editar.Visible = True
            End If

            Call RellenaGrid()
            Call GenerarToolTip()
            ''   Call Factura_Microsip()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub GenerarToolTip()
        Try


            ToolTip.SetToolTip(Btn_Nuevo, "Nuevo Devolución")
            ToolTip.SetToolTip(Btn_Editar, "Editar Devolución")
            ToolTip.SetToolTip(Btn_Eliminar, "Eliminar Devolución")
            ToolTip.SetToolTip(Btn_Consultar, "Consultar Devolución")
            ToolTip.SetToolTip(Btn_Microsip, "Traspasar las Devoluciones a MicroSip")
            ToolTip.SetToolTip(Btn_InvertirSeleccion, "Invertir selección")

            ToolTip.SetToolTip(Btn_Filtro, "Búsqueda Avanzada")
            'ToolTip.SetToolTip(Btn_Refrescar, "Refrescar Información")
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
            ToolTip.SetToolTip(Btn_Imprimir, "Imprimir Información")
            ' ToolTip.SetToolTip(Btn_Pdf, "Generar Información en PDF")
            ToolTip.SetToolTip(Btn_Salir, "Salir")

            ToolTip.SetToolTip(Btn_Factura, "Detalle de Devolución")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub RellenaGrid()
        Using objDevoluciones As New BCL.BCLDevoluciones(GLB_ConStringCipSis)
            Try

                Me.Cursor = Cursors.WaitCursor
                ''DGrid.ReadOnly = True

                If Sw_Load = True Then
                    ' Sw_Load = False
                Else
                    If Sw_NoRegistros = True Then
                        DGrid.Columns.Remove("MicroSip")

                    End If

                End If

                DGrid.DataSource = Nothing
                objDataSet = objDevoluciones.usp_PpalDevoluciones(Sucursalb, DevInib, DevFinb, IIf(FactProvInib = "F-" Or FactProvInib = "", "", "F-" & FactProvInib), IIf(FactProvFinb = "F-" Or FactProvFinb = "", "", "F-" & FactProvFinb), Marcab, _
                                                                    Proveedorb, Statusb, FechaInib, FechaFinb, _
                                                                    VenceInib, VenceFinb, IdFolioSucIniB, IdFolioSucFinB)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section
                    Sw_NoRegistros = True
                    DGrid.DataSource = objDataSet.Tables(0)
                    InicializaGrid()
                    'LimpiarBusqueda()
                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True
                    Btn_Editar.Enabled = True
                    Btn_Consultar.Enabled = True

                    Btn_Factura.Enabled = True
                    Btn_InvertirSeleccion.Enabled = True
                    Btn_Microsip.Enabled = True

                    Sw_NoRegistros = True
                Else
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron Devoluciones que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                    Btn_Editar.Enabled = False
                    Btn_Consultar.Enabled = False
                    Btn_Factura.Enabled = False
                    Btn_InvertirSeleccion.Enabled = False
                    Btn_Microsip.Enabled = False

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

        Statusb = ""

        VenceInib = "1900-01-01"
        VenceFinb = "1900-01-01"
        FechaInib = "1900-01-01"
        FechaFinb = "1900-01-01"
        DevInib = ""
        DevFinb = ""
        IdFolioSucIniB = ""
        IdFolioSucFinB = ""
        FactProvInib = ""
        FactProvFinb = ""
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
            DGrid.RowHeadersVisible = False
            Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
            Dim row As DataRow = dt.NewRow()
            ' row(3) = "Total: "
            row(3) = "Total: "
            row(9) = pub_SumarColumnaGrid(DGrid, 9, DGrid.RowCount - 1)
            row(10) = pub_SumarColumnaGrid(DGrid, 10, DGrid.RowCount - 1)
            row(11) = pub_SumarColumnaGrid(DGrid, 11, DGrid.RowCount - 1)
            row(12) = pub_SumarColumnaGrid(DGrid, 12, DGrid.RowCount - 1)

            dt.Rows.Add(row)
            DGrid.DataSource = dt

            DGrid.Columns(0).HeaderText = "Sucursal"
            DGrid.Columns(1).HeaderText = "DevProv"
            DGrid.Columns(2).HeaderText = "Factura"
            DGrid.Columns(3).HeaderText = "OrdeComp"
            DGrid.Columns(4).HeaderText = "Estatus"
            DGrid.Columns(5).HeaderText = "Fecha"
            DGrid.Columns(6).HeaderText = "Vence"
            DGrid.Columns(7).HeaderText = "Marca"
            DGrid.Columns(8).HeaderText = "Proveedor"
            DGrid.Columns(9).HeaderText = "Pares"
            DGrid.Columns(10).HeaderText = "Subtotal"
            DGrid.Columns(11).HeaderText = "Impuesto"
            DGrid.Columns(12).HeaderText = "Total"
            DGrid.Columns(13).HeaderText = "Observaciones"
            DGrid.Columns(14).HeaderText = "IdFolio"
            DGrid.Columns(15).HeaderText = "Folio Bulto"
            DGrid.Columns(16).HeaderText = "DsctoPP"
            DGrid.Columns(17).HeaderText = "Dscto01"
            DGrid.Columns(18).HeaderText = "Dscto02"
            DGrid.Columns(19).HeaderText = "Dscto03"
            DGrid.Columns(20).HeaderText = "Dscto04"
            DGrid.Columns(21).HeaderText = "Dscto05"

         

            DGrid.Columns(0).ReadOnly = True
            DGrid.Columns(1).ReadOnly = True
            DGrid.Columns(2).ReadOnly = True
            DGrid.Columns(3).ReadOnly = True
            DGrid.Columns(4).ReadOnly = True
            DGrid.Columns(5).ReadOnly = True
            DGrid.Columns(6).ReadOnly = True
            DGrid.Columns(7).ReadOnly = True
            DGrid.Columns(8).ReadOnly = True
            DGrid.Columns(9).ReadOnly = True
            DGrid.Columns(10).ReadOnly = True
            DGrid.Columns(11).ReadOnly = True
            DGrid.Columns(12).ReadOnly = True
            DGrid.Columns(13).ReadOnly = True



            DGrid.Columns(0).Visible = False
            DGrid.Columns(3).Visible = False
            DGrid.Columns(6).Visible = False

            DGrid.Columns(16).Visible = False
            DGrid.Columns(17).Visible = False
            DGrid.Columns(18).Visible = False
            DGrid.Columns(19).Visible = False
            DGrid.Columns(20).Visible = False
            DGrid.Columns(21).Visible = False
            DGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells


            DGrid.Columns(10).DefaultCellStyle.Format = "c"
            DGrid.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns(11).DefaultCellStyle.Format = "c"
            DGrid.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns(12).DefaultCellStyle.Format = "c"
            DGrid.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


            DGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            AgregarColumna()

            DGrid.Columns(22).ReadOnly = False
            DGrid.Columns(14).DisplayIndex = 0
            DGrid.Columns(15).DisplayIndex = 1
            DGrid.Columns(22).Visible = False
            DGrid.Columns(14).Visible = False

            'DGrid.Columns(16).ReadOnly = False
            'DGrid.Columns(14).DisplayIndex = 0
            'DGrid.Columns(15).DisplayIndex = 1
            'DGrid.Columns(16).Visible = False
            'DGrid.Columns(14).Visible = False

            DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)


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

    Private Sub Btn_Nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Nuevo.Click
        Dim myForm As New frmCatalogoPedidoNuevo
        Sw_Boton = True
        myForm.Accion = 1
        myForm.Sw_Devolucion = True
        myForm.Sw_FacturaNueva = False
        myForm.sw_serie = Sw_Serie

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
        myForm.Txt_Sucursal.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells(0).Value.ToString.Trim()
        myForm.Txt_OrdeComp.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells(1).Value.ToString.Trim()
        myForm.MdiParent = BitacoraMain
        myForm.Show()
        Call RellenaGrid()
    End Sub

    Private Sub Btn_Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar.Click
        Try
            Dim myForm As New frmCatalogoPedidoNuevo
            Sw_Boton = True
            myForm.Sw_Devolucion = True
            myForm.Sw_FacturaNueva = False
            myForm.Accion = 2
            myForm.Txt_Sucursal.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells(0).Value.ToString.Trim()
            myForm.Txt_OrdeComp.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells(1).Value.ToString.Trim()
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
            Dim myForm As New frmFiltrosDevoluciones
            myForm.Txt_Marca.Text = Marcab

            myForm.Txt_Proveedor.Text = Proveedorb

            myForm.Txt_Sucursal.Text = Sucursalb
            myForm.Cbo_Estatus.Text = Statusb
            myForm.Txt_DevProv1.Text = DevInib
            myForm.Txt_DevProv2.Text = DevFinb
            myForm.Txt_OrdeComp1.Text = FactProvInib
            myForm.Txt_OrdeComp2.Text = FactProvFinb

            myForm.Txt_IdFolio.Text = IdFolioSucIniB
            myForm.Txt_IdFolio1.Text = IdFolioSucFinB

            If FechaInib <> "1900-01-01" Then
                myForm.Chk_FechaOrden.Checked = True
                myForm.DTPicker2.Value = FechaInib
                myForm.DTPicker3.Value = FechaFinb
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

            IdFolioSucIniB = myForm.Txt_IdFolio.Text
            IdFolioSucFinB = myForm.Txt_IdFolio1.Text

            Sucursalb = myForm.Txt_Sucursal.Text
            Statusb = myForm.Cbo_Estatus.Text
            DevInib = myForm.Txt_DevProv1.Text
            DevFinb = myForm.Txt_DevProv2.Text
            FactProvInib = myForm.Txt_OrdeComp1.Text
            FactProvFinb = myForm.Txt_OrdeComp2.Text

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
        colImagen.DisplayIndex = 22 '16
        colImagen.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        colImagen.CellTemplate = New DataGridViewCheckBoxCell()
        ' añadir columna de imagen a la coleccion del grid 
        DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        ''DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DGrid.Columns.Add(colImagen)


    End Sub
    Private Sub Btn_Microsip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Microsip.Click
        'mreyes 16/Marzo/2012 06:24 p.m.
        If Sw_NoRegistros = False Then Exit Sub
        '' PRIMERO TIENE QUE GENERAR EL ID DOCTO PARA GRABAR EN DOCTOS_CP
        Try
            If MsgBox("Esta seguro de querer traspasar las Devoluciones a Microsip?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub
            Me.Cursor = Cursors.WaitCursor
            Dim Docto_Id As Integer = 0
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
            Dim Gastos As Double = 0
            Dim Proveedor As String = ""
            Dim Referenc As String = ""
            Dim IdFolioB As String = ""
            For Each row As DataGridViewRow In DGrid.Rows

                idfoliob = row.Cells("idfoliosuc").Value

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

                    If ups_Traer_Doctos_CP(60, Proveedor_Id, Folio, Fecha, Clave_Prov) = 0 And Proveedor_Id <> 0 Then
                        '' no existe dada de alta la factura en microsip 

                        Docto_Id = Gen_Doctos_Id()
                        Impte_Docto_cp_id = Gen_Doctos_Id()
                        Impte_Docto_cp_impto_id = Gen_Doctos_Id()
                        '' traer proveedor 

                        Observaciones = row.Cells("observa").Value
                        Folio = pub_RellenarIzquierda(row.Cells("referenc").Value, 9)
                        Referenc = "F-" & row.Cells("referenc").Value
                        Proveedor = Mid(row.Cells("proveedor").Value, 1, 3)
                        Fecha = Format(row.Cells("fecha").Value, "dd-MM-yyyy")


                        'FechaVencimiento = Format(row.Cells("fecvenc").Value, "dd-MM-yyyy")
                        'FechaVencimiento = Format(Fecha.Add(New TimeSpan(Dias, 0, 0, 0)), "dd-MM-yyyy")

                        ' row.Cells("fecvenc").Value = Format(FechaVencimiento, "dd-MM-yyyy")

                        Subtotal = Val(row.Cells("subtotal").Value)
                        impuesto = Val(row.Cells("impuesto").Value)

                        Gastos = 0

                        importe = Val(row.Cells("importe").Value)  '+ Val(row.Cells("gastos").Value)

                        ' Documentos para facturas...

                        If Inserta_Doctos_CP_Microsip(Docto_Id, Folio, Fecha, Clave_Prov, Proveedor_Id, Observaciones, Cond_Pago_Id, FechaVencimiento, Porc, IdFolioB) Then

                        End If


                        'If Inserta_Vencimientos_Cargos_CP_Microsip(Docto_Id, FechaVencimiento, 100) Then

                        'End If

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



                        Cont = Cont + 1
                        row.DefaultCellStyle.BackColor = Color.LightGreen
                    Else

                        If Proveedor_Id = 0 Then
                            row.DefaultCellStyle.BackColor = Color.Yellow
                        Else
                            row.DefaultCellStyle.BackColor = Color.PowderBlue
                        End If

                    End If

                End If ' del microsip 
            Next
            Me.Cursor = Cursors.Default
            MsgBox("Se han traspasado '" & Cont & "' Devoluciones a MicroSip.", MsgBoxStyle.Information, "Confirmación")
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

    Private Function ups_Traer_Doctos_CP(ByVal Concepto_CP_Id As Integer, ByVal Proveedor_Id As Integer, ByVal Folio As String, ByVal Fecha As Date, ByVal Clave_Prov As String) As Integer
        'mreyes 16/Marzo/2012 06:25 p.m.
        Try
            Dim objDataset As Data.DataSet
            ups_Traer_Doctos_CP = 0
            Using objMicrosip As New BCL.BCLMicrosip(GLB_ConStringMicrosip)
                objDataset = objMicrosip.usp_Traer_Doctos_CP(Concepto_CP_Id, Proveedor_Id, Folio, Fecha, Clave_Prov)
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
                                        ByVal cond_pago_id As Integer, ByVal fecha_dscto_ppag As Date, ByVal pctje_dscto_ppag As Integer, ByVal idfolioB As String) As Boolean
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
                objDataRow.Item("concepto_cp_id") = 60
                objDataRow.Item("folio") = pub_RellenarIzquierda(Factura, 9)
                objDataRow.Item("naturaleza_concepto") = "R"
                objDataRow.Item("fecha") = Format(Fecha, "dd-MM-yyyy")
                objDataRow.Item("clave_prov") = Clave_Prov
                objDataRow.Item("proveedor_id") = Proveedor_Id
                objDataRow.Item("tipo_cambio") = "1.0"
                objDataRow.Item("cancelado") = "N"
                objDataRow.Item("aplicado") = "S"
                objDataRow.Item("descripcion") = Observaciones
                objDataRow.Item("forma_emitida") = "N"
                objDataRow.Item("contabilizado") = "S"
                objDataRow.Item("contabilizado_gyp") = "N"
                objDataRow.Item("cond_pago_id") = DBNull.Value
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
                If Not objMicrosip.usp_Inserta_Doctos_CP(1, idfoliob, objDataset) Then
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


    Private Sub Devolucion_Microsip()
        'mreyes 29/Marzo/2012 10:44 a.m.

        For Each row As DataGridViewRow In DGrid.Rows

            'If row.Cells("MicroSip").Value = "" Then
            ' row.Cells("MicroSip").Value = True
            'Else
            If row.Cells("MicroSip").Value = True Then
                row.Cells("MicroSip").Value = False
            Else
                row.Cells("MicroSip").Value = True
            End If
            ''If row.Cells("MicroSip").Value = Nothing Then
            ''    row.Cells("MicroSip").Value = True
            ''End If
            'End If

        Next
    End Sub

    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub

    Private Sub Btn_InvertirSeleccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_InvertirSeleccion.Click
        If Sw_NoRegistros = False Then Exit Sub
        Call Devolucion_Microsip()
    End Sub

    Private Sub Btn_Factura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Factura.Click
        'mreyes 29/Marzo/2012 10:59 p.m.
        If Sw_NoRegistros = False Then Exit Sub

        Dim myForm As New frmCatalogoPedidoNuevo
        Sw_Boton = True
        myForm.Accion = 4
        'myForm.Sw_Serie = Sw_Serie
        myForm.Txt_Sucursal.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("sucursal").Value.ToString.Trim()
        myForm.Txt_OrdeComp.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("devoprov").Value.ToString.Trim()
        myForm.Txt_NoBulto.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idfoliosuc").Value.ToString.Trim()
        myForm.FolioB = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idfolio").Value.ToString.Trim()
        myForm.Sw_Devolucion = True
        myForm.MdiParent = BitacoraMain
        myForm.Show()
        ' Call RellenaGrid()
    End Sub

    Private Sub DGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick
        Call Btn_Factura_Click(sender, e)
    End Sub

    Private Sub DGrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DGrid.KeyPress
        Call Btn_Factura_Click(sender, e)
    End Sub

    Private Sub AplicarDevToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AplicarDevToolStripMenuItem.Click
        Try

            If IsDBNull(DGrid.CurrentRow.Cells("idfoliosuc").Value) Then Exit Sub

            Call usp_TraerUltFolioNotaCC("CA")
            Importe = DGrid.CurrentRow.Cells("SUBTOTAL").Value
            IVA = DGrid.CurrentRow.Cells("IMPUESTO").Value
            ImporteTot = DGrid.CurrentRow.Cells("importe").Value
            IdFolioSuc = DGrid.CurrentRow.Cells("idfoliosuc").Value

            If Inserta_Nota() = True Then
                If MsgBox("Está Seguro de Aplicar el Cargo por Devolución?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    Using objNotas As New BCL.BCLNotasCC(GLB_ConStringCipSis)
                        Dim IdFolioSuc As String = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idfoliosuc").Value.ToString.Trim()
                        Dim dsctopp As Integer = CInt(DGrid.Rows(DGrid.CurrentRow.Index).Cells("dsctopp").Value)
                        Dim dscto01 As Integer = CInt(DGrid.Rows(DGrid.CurrentRow.Index).Cells("dscto01").Value)
                        Dim dscto02 As Integer = CInt(DGrid.Rows(DGrid.CurrentRow.Index).Cells("dscto02").Value)
                        Dim dscto03 As Integer = CInt(DGrid.Rows(DGrid.CurrentRow.Index).Cells("dscto03").Value)
                        Dim dscto04 As Integer = CInt(DGrid.Rows(DGrid.CurrentRow.Index).Cells("dscto04").Value)
                        Dim dscto05 As Integer = CInt(DGrid.Rows(DGrid.CurrentRow.Index).Cells("dscto05").Value)

                        If Not objNotas.usp_ActualizaFacturaNotaCC(IdFolioSuc, "CA", ImporteTot, 4, dsctopp, dscto01, dscto02, dscto03, dscto04, dscto05) Then
                            Throw New Exception("Error al Actualizar el Estatus de la Nota")
                        Else
                            MsgBox("El Cargo por Devolución se Aplicó satisfactoriamente.", MsgBoxStyle.Information, "Aviso")
                            'InsertaNota = True
                        End If
                    End Using
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Function Inserta_Nota() As Boolean
        Dim objDataSet As Data.DataSet
        Dim Estatus As String = ""
        Dim Opcion As Integer = 1
        Using objNotas As New BCL.BCLNotasCC(GLB_ConStringCipSis)
            'Get a new Project DataSet
            Try

                'Estatus = "AP"

                objDataSet = objNotas.Inserta_Nota  'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow

                'Set the values in the DataRow

                objDataRow.Item("folio") = Folio
                objDataRow.Item("idfoliosuc") = IdFolioSuc
                objDataRow.Item("cvesuc") = "00"
                objDataRow.Item("fecha") = GLB_FechaHoy
                objDataRow.Item("tipo") = "CA"
                objDataRow.Item("status") = "AP"
                objDataRow.Item("aplicada") = GLB_FechaHoy
                objDataRow.Item("idmotivo") = 4
                objDataRow.Item("importe") = Importe
                objDataRow.Item("iva") = IVA
                objDataRow.Item("imptotal") = ImporteTot
                objDataRow.Item("descrip") = "CARGO POR DEVOLUCION"
                objDataRow.Item("idusuario") = GLB_Idempleado

                'Add the DataRow to the DataSet
                objDataSet.Tables(0).Rows.Add(objDataRow)

                ''Add the Project
                If Not objNotas.usp_Captura_NotaCC(Opcion, objDataSet) Then
                    Throw New Exception("Falló Inserción de Cuenta")
                Else
                    Inserta_Nota = True
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Private Sub usp_TraerUltFolioNotaCC(ByVal Tipo As String)

        Using objNotas As New BCL.BCLNotasCC(GLB_ConStringCipSis)
            Try
                objDataSet = objNotas.usp_TraerUltFolioNotaCC(Tipo)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("folio").ToString.Trim = "" Then
                        Folio = 1
                    Else
                        Folio = objDataSet.Tables(0).Rows(0).Item("folio").ToString
                        Folio = Folio + 1
                    End If
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub DGrid_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DGrid.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With Me.DGrid
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If
    End Sub
End Class