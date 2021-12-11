Imports DevExpress.DashboardCommon
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Columns.GridColumn
Imports System.Web.UI.WebControls
Imports DevExpress.XtraGrid
Public Class frmPpalBitacora
    'mreyes 26/Febrero/2012 10:16 p.m.
    Private objDataSet As DataSet
    Dim Marcab As String
    Dim Modelob As String
    Dim Estilofb As String
    'Dim IdDivisionb As Integer
    'Dim IdDepartamentob As Integer
    'Dim IdFamiliab As Integer
    'Dim IdLineab As Integer
    'Dim IdL1b As Integer
    'Dim IdL2b As Integer
    'Dim IdL3b As Integer
    'Dim IdL4b As Integer
    'Dim IdL5b As Integer
    'Dim IdL6b As Integer

    Dim IdDivisionb As String
    Dim IdDepartamentob As String
    Dim IdFamiliab As String
    Dim IdLineab As String
    Dim IdL1b As String
    Dim IdL2b As String
    Dim IdL3b As String
    Dim IdL4b As String
    Dim IdL5b As String
    Dim IdL6b As String

    Dim cveDivisionb As String = ""
    Dim cveDepartamentob As String = ""
    Dim cveFamiliab As String = ""
    Dim cveLineab As String = ""
    Dim cveL1b As String = ""
    Dim cveL2b As String = ""
    Dim cveL3b As String = ""
    Dim cveL4b As String = ""
    Dim cveL5b As String = ""
    Dim cveL6b As String = ""

    Dim Proveedorb As String

    Dim Sucursalb As String
    Dim OrdeCompb As String
    Dim FechaInib As String
    Dim FechaFinb As String
    Dim Statusb As String
    Dim FechaEInib As String
    Dim FechaEFinb As String
    Dim OrdeComInib As String
    Dim OrdeComFinb As String

    Dim Sw_Load As Boolean = False
    Dim Sw_Boton As Boolean = False
    Dim Sw_NoRegistros As Boolean = False
    Dim Sw_Pintar As Boolean = False
    Dim Opcion As Integer = 1
    Dim Sw_Costos As Boolean = True
    Dim MarcaFOTO As String = ""
    Dim EstiloNFOTO As String = ""
    Private izquierda As Integer = 0
    Private alto As Integer = 0

    Private Sub frmPpalBitacora_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Sw_NoRegistros = False Then Exit Sub
        If Sw_Load = True Then
            Sw_Load = False
            InicializaGrid()
            '    Call BarrerGrid()

        End If

        If GLB_RefrescarPedido = True Then
            GLB_RefrescarPedido = False
            Call RellenaGrid()
            Me.WindowState = FormWindowState.Maximized
        End If
    End Sub  '' 2 = proveedor , 3 = marca 
    Private Sub frmPpalBitacora_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
        If e.KeyCode = Keys.F5 Then
            Call Btn_Filtro_Click_1(sender, e)
        End If
    End Sub
    Private Sub frmPpalBitacora_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

    End Sub

    Private Sub frmPpalBitacora_Layout(ByVal sender As Object, ByVal e As System.Windows.Forms.LayoutEventArgs) Handles Me.Layout

    End Sub
    Private Sub frmPpalBitacora_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Sw_Load = True
            Call LimpiarBusqueda()

            '  FechaEInib = Format(Now.Add(New TimeSpan(-30, 0, 0, 0)), "yyyy-MM-dd")
            ' FechaEFinb = Format(Now.Date, "yyyy-MM-dd")
            'If GLB_CveSucursal <> "" Then
            '    Sucursalb = GLB_CveSucursal
            'End If

            'If GLB_CveSucursal > "20" Then
            '    Sucursalb = ""
            'End If

            'FechaEInib = Format(DateSerial(Now.Year, Now.Month, 1), "yyyy-MM-dd")


            'Dim fecha1 As Date = DateAdd(DateInterval.Month, 1, Now.Date)
            'FechaEFinb = Format(DateAdd(DateInterval.Day, -7, DateSerial(fecha1.Day, fecha1.Day, 1)), "yyyy-MM-dd")


            FechaEFinb = Format(Now.Date, "yyyy-MM-dd")
            FechaEInib = Format(Now.Add(New TimeSpan(-7, 0, 0, 0)), "yyyy-MM-dd")
            Sw_Pintar = True
            Sw_NoRegistros = False
            Call GenerarToolTip()
            Call RellenaGrid()


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub GenerarToolTip()
        Try

            ToolTip.SetToolTip(Btn_Filtro, "Búsqueda Avanzada")
            'ToolTip.SetToolTip(Btn_Refrescar, "Refrescar Información")
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
            ToolTip.SetToolTip(Btn_Imprimir, "Imprimir Información")
            ' ToolTip.SetToolTip(Btn_Pdf, "Generar Información en PDF")
            ToolTip.SetToolTip(Btn_Salir, "Salir")

            'ToolTip.SetToolTip(Btn_Proveedor, "Bitácora por Proveedor")
            'ToolTip.SetToolTip(Btn_Estilos, "Bitácora por Estilos")
            'ToolTip.SetToolTip(Btn_Marca, "Bitácora por Marca")
            ToolTip.SetToolTip(Btn_Seguimiento, "Registrar un seguimiento a la orden de compra")
            ToolTip.SetToolTip(Btn_Fechas, "Modificar fechas de la orden de compra")
            ToolTip.SetToolTip(Btn_OrdeComp, "Bitácora por Orden de Compra")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub RellenaGrid()
        'mreyes 27/Febrero/2012 10:44 a.m.
        Using objBitacora As New BCL.BCLBitacora(GLB_ConStringCipSis)
            Try
                Me.Cursor = Cursors.WaitCursor
                Dim accion As Integer


                Grido.DataSource = Nothing
                If Sw_Load = True Then

                    accion = 1
                    ''''Sw_Load = False
                Else
                    accion = 2
                End If
                objDataSet = objBitacora.usp_PpalBitacora(accion, Opcion, Sucursalb, OrdeComInib, OrdeComFinb, Marcab, Modelob, Estilofb,
                                                                    IdDivisionb, IdDepartamentob, IdFamiliab, IdLineab, IdL1b, IdL2b, IdL3b,
                                                                    IdL4b, IdL5b, IdL6b, Proveedorb, Statusb, FechaInib,
                                                                    FechaFinb, FechaEInib, FechaEFinb)
                If objDataSet.Tables(0).Rows.Count > 0 Then

                    'DGrid.Visible = False
                    'DGrid.Refresh()
                    'Application.DoEvents()
                    Grido.DataSource = objDataSet.Tables(0)
                    InicializaGrid()
                    If Opcion = 1 Then
                        ''''  BarrerGrid()
                        Sw_Pintar = True
                        'Application.DoEvents()
                        'Me.Refresh()
                        Btn_Foto.Enabled = True
                    End If
                    'LimpiarBusqueda()
                    ' Agregar totalizado

                    Me.Cursor = Cursors.Default
                    'Btn_Estilos.Enabled = True
                    'Btn_Marca.Enabled = True
                    'Btn_Proveedor.Enabled = True
                    Btn_Fechas.Enabled = True
                    Btn_Excel.Enabled = True
                    'DGrid.Visible = True
                    'DGrid.Refresh()
                    'Application.DoEvents()
                    Sw_NoRegistros = True
                    'DGrid.Visible = False
                    'Call Colores()
                    'DGrid.Visible = True
                Else
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron Pedidos que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    'Btn_Estilos.Enabled = False
                    'Btn_Marca.Enabled = False
                    'Btn_Proveedor.Enabled = False
                    Btn_Fechas.Enabled = False
                    Btn_Excel.Enabled = False
                End If

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using


    End Sub
    Private Sub BarrerGrid()
        'mreyes 01/Marzo/2012 09:58 a.m.
        ' FechaInib = Format(Now.Add(New TimeSpan(-30, 0, 0, 0)), "yyyyMMdd")

        Try
            'If Sw_Load = True Then Exit Sub
            'Dim Entrega As Date
            'Dim Fecha As Date
            'Dim DiasEntrega As Integer = 0
            'DGrid.Visible = False
            'PBar.Minimum = 0
            'PBar.Value = 0
            'PBar.Maximum = GridView1.RowCount
            'For j As Integer = 0 To GridView1.Columns().Count - 1
            'Next
            'For Each row As DataGridViewRow In DGrid.Rows
            '    PBar.Value = PBar.Value + 1
            '    PBar.Refresh()
            '    If row.Cells(12).Value = "" Or row.Cells(12).Value = Nothing Then Exit For
            '    Entrega = row.Cells(12).Value
            '    Fecha = Entrega.Add(New TimeSpan(-15, 0, 0, 0))
            '    ''If row.Cells(14).Value <> 0 Then
            '    ''    row.Cells(3).Style.BackColor = Color.GreenYellow
            '    ''    row.Cells(3).Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            '    ''End If
            '    If Not IsDBNull(row.Cells(14).Value) Then
            '        row.Cells(3).Style.BackColor = Color.GreenYellow
            '        row.Cells(3).Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)


            '    End If
            '    DiasEntrega = DateDiff(DateInterval.Day, Now.Date, Entrega)
            '    If DiasEntrega <= 7 Then
            '        row.Cells(3).Style.BackColor = Color.Red
            '        row.Cells(3).Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            '        'DGrid.Refresh()
            '    End If

            '    If DateDiff(DateInterval.Day, Now.Date, Entrega) > 7 And DateDiff(DateInterval.Day, Now.Date, Entrega) <= 30 Then
            '        row.Cells(3).Style.BackColor = Color.Yellow
            '        row.Cells(3).Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            '    End If
            'Next
            Grido.Visible = True
            Grido.Refresh()
            Me.Refresh()
            Application.DoEvents()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub LimpiarBusqueda()
        Marcab = ""
        Modelob = ""
        Estilofb = ""
        IdDivisionb = ""
        IdDepartamentob = ""
        IdFamiliab = ""
        IdLineab = ""
        IdL1b = ""
        IdL2b = ""
        IdL3b = ""
        IdL4b = ""
        IdL5b = ""
        IdL6b = ""
        Proveedorb = ""

        Sucursalb = ""
        OrdeCompb = ""

        Statusb = ""

        FechaEInib = "1900-01-01"
        FechaEFinb = "1900-01-01"
        FechaInib = "1900-01-01"
        FechaFinb = "1900-01-01"
        OrdeComInib = ""
        OrdeComFinb = ""
    End Sub
    Sub InicializaGrid()
        'mreyes 27/Febrero/2011 10:40 a.m.
        Try
            GridView1.Columns(0).Caption = " Marca"
            GridView1.Columns(1).Caption = " Proveedor"
            GridView1.Columns(2).Caption = " Det."
            GridView1.Columns(3).Caption = " O.C."
            GridView1.Columns(4).Caption = " N/R"
            GridView1.Columns(5).Caption = " Estilo Fábrica"
            GridView1.Columns(6).Caption = " Modelo "
            GridView1.Columns(7).Caption = " Ped"
            GridView1.Columns(8).Caption = " Rec"
            GridView1.Columns(9).Caption = " Canc"
            GridView1.Columns(10).Caption = " Pend"
            GridView1.Columns(11).Caption = " Costo"
            GridView1.Columns(12).Caption = " Importe"
            GridView1.Columns(13).Caption = " Entrega"
            GridView1.Columns(14).Caption = " Cancela"
            GridView1.Columns(15).Caption = " Seg."
            GridView1.Columns(7).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(8).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(9).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(10).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(12).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(7).SummaryItem.DisplayFormat = "{0:###,###,##0}"
            GridView1.Columns(8).SummaryItem.DisplayFormat = "{0:###,###,##0}"
            GridView1.Columns(9).SummaryItem.DisplayFormat = "{0:###,###,##0}"
            GridView1.Columns(10).SummaryItem.DisplayFormat = "{0:###,###,##0}"
            GridView1.Columns(12).SummaryItem.DisplayFormat = "{0:###,###,##0}"
            GridView1.Columns(7).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GridView1.Columns(8).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GridView1.Columns(9).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GridView1.Columns(10).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GridView1.Columns(12).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum

            GridView1.Columns(1).Visible = False
            GridView1.Columns(9).Visible = False
            GridView1.Columns(2).Visible = True
            '''' DGrid.Columns(8).Visible = False
            '''' DGrid.Columns(9).Visible = False
            ''  DGrid.Columns(14).Visible = False

            If Opcion = 2 Then 'PROVEEDOR
                GridView1.Columns(0).Visible = False
                GridView1.Columns(1).Visible = True
                GridView1.Columns(2).Visible = False
                GridView1.Columns(3).Visible = False
                GridView1.Columns(4).Visible = False
                GridView1.Columns(5).Visible = False
                GridView1.Columns(6).Visible = False
                GridView1.Columns(11).Visible = False
                GridView1.Columns(13).Visible = False
                GridView1.Columns(14).Visible = False
                GridView1.Columns(15).Visible = False

            End If
            If Opcion = 3 Then
                GridView1.Columns(0).Visible = True
                GridView1.Columns(1).Visible = False
                GridView1.Columns(2).Visible = False
                GridView1.Columns(3).Visible = False
                GridView1.Columns(4).Visible = False
                GridView1.Columns(5).Visible = False
                GridView1.Columns(6).Visible = False
                GridView1.Columns(11).Visible = False
                GridView1.Columns(13).Visible = False
                GridView1.Columns(14).Visible = False
                GridView1.Columns(15).Visible = False
            End If

            If Opcion = 4 Then  'orden  compra 
                GridView1.Columns(0).Visible = True
                GridView1.Columns(1).Visible = True
                GridView1.Columns(3).Visible = True
                GridView1.Columns(4).Visible = False
                GridView1.Columns(5).Visible = False
                GridView1.Columns(6).Visible = False
                GridView1.Columns(11).Visible = False
                GridView1.Columns(13).Visible = False
                GridView1.Columns(14).Visible = False
                GridView1.Columns(15).Visible = False
            End If
            For j As Integer = 0 To GridView1.Columns().Count - 1
                GridView1.Columns(j).OptionsColumn.ReadOnly = True
                GridView1.Columns(j).OptionsColumn.AllowEdit = False
                GridView1.Columns(j).AppearanceHeader.BackColor = Color.LightBlue
                GridView1.Columns(j).AppearanceHeader.TextOptions.HAlignment = HorizontalAlignment.Center
                GridView1.Columns(j).AppearanceHeader.Font = New Font(GridView1.Columns(j).AppearanceHeader.Font, FontStyle.Bold)
            Next
            GridView1.BestFitColumns()
            GridView1.Columns(1).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(2).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(3).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(4).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(5).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(6).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(7).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(8).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(9).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(10).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(11).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(12).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(13).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(14).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(15).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center

            'mreyes 17/Julio/2012 09:26 a.m.
            ' CHECAR SI PUEDE VER COSTOS.. LOS COSTOS NO SE PODRAN VER SI EN PUERTO EL PUERTO DICE 01...
            If GLB_Usuario <> "SISTEMAS" And GLB_Usuario <> "MREYES" Or GLB_Usuario <> "FELIX" Or GLB_Usuario <> "FELIXJ" Or GLB_Usuario <> "LORIS" Then
                If pub_TienePermisoProceso("COSBIT", "01", "", False) = False Then
                    Exit Sub
                Else
                    GridView1.Columns(11).Visible = False
                    GridView1.Columns(12).Visible = False
                    'DGrid.Columns(15).Visible = False
                    Sw_Costos = False

                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Public Sub veras(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        Try
            If e.RowHandle = GridControl.AutoFilterRowHandle Then
                e.Appearance.BackColor = Color.White
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
            If sfdRuta.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Grido.ExportToXls(sfdRuta.FileName)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim myForm As New frmCatalogoPedidoNuevo

            Sw_Boton = True
            myForm.Accion = 1
            myForm.Txt_OrdeComp.Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ordecomp").ToString.Trim()
            myForm.MdiParent = BitacoraMain
            myForm.Show()
            'Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub Btn_Filtro_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        Dim myForm As New frmFiltrosPedidoNuevo
        'mreyes 27/Febrero/2012 04:48 p.m.
        Try
            '' mandar datos de consulta 
            myForm.Txt_Marca.Text = Marcab
            myForm.Txt_Estilon.Text = Modelob
            myForm.Txt_Estilof.Text = Estilofb
            myForm.Txt_DescripDivision.Text = IdDivisionb
            myForm.Txt_DescripDepto.Text = IdDepartamentob
            myForm.Txt_DescripFamilia.Text = IdFamiliab
            myForm.Txt_DescripLinea.Text = IdLineab
            myForm.Txt_DescripL1.Text = IdL1b
            myForm.Txt_DescripL2.Text = IdL2b
            myForm.Txt_DescripL3.Text = IdL3b
            myForm.Txt_DescripL4.Text = IdL4b
            myForm.Txt_DescripL5.Text = IdL5b
            myForm.Txt_DescripL6.Text = IdL6b
            myForm.Txt_Proveedor.Text = Proveedorb

            If Sucursalb <> "" Then
                myForm.Txt_Sucursal.Enabled = False
            Else
                myForm.Txt_Sucursal.Enabled = True
            End If
            myForm.Txt_Sucursal.Text = Sucursalb
            myForm.Cbo_Estatus.Text = Statusb
            myForm.Txt_OrdeComp1.Text = OrdeComInib
            myForm.Txt_OrdeComp2.Text = OrdeComFinb


            myForm.Txt_Division.Text = cveDivisionb
            myForm.Txt_Depto.Text = cveDepartamentob
            myForm.Txt_Familia.Text = cveFamiliab
            myForm.Txt_Linea.Text = cveLineab
            myForm.Txt_L1.Text = cveL1b
            myForm.Txt_L2.Text = cveL2b
            myForm.Txt_L3.Text = cveL3b
            myForm.Txt_L4.Text = cveL4b
            myForm.Txt_L5.Text = cveL5b
            myForm.Txt_L6.Text = cveL6b

            If FechaInib <> "1900-01-01" Then
                myForm.Chk_FechaOrden.Checked = True
                myForm.DTPicker2.Value = FechaInib
                myForm.DTPicker3.Value = FechaFinb
            End If
            If FechaEInib <> "1900-01-01" Then
                myForm.Chk_FechaEntrega.Checked = True
                myForm.DTPicker4.Value = FechaEInib
                myForm.DTPicker5.Value = FechaEFinb
            End If

            myForm.Text = "Filtros Bitácora"

            myForm.ShowDialog()

            Marcab = myForm.Txt_Marca.Text
            Modelob = myForm.Txt_Estilon.Text
            Estilofb = myForm.Txt_Estilof.Text
            IdDivisionb = myForm.Txt_DescripDivision.Text
            IdDepartamentob = myForm.Txt_DescripDepto.Text
            IdFamiliab = myForm.Txt_DescripFamilia.Text
            IdLineab = myForm.Txt_DescripLinea.Text
            IdL1b = myForm.Txt_DescripL1.Text
            IdL2b = myForm.Txt_DescripL2.Text
            IdL3b = myForm.Txt_DescripL3.Text
            IdL4b = myForm.Txt_DescripL4.Text
            IdL5b = myForm.Txt_DescripL5.Text
            IdL6b = myForm.Txt_DescripL6.Text


            cveDivisionb = myForm.Txt_Division.Text
            cveDepartamentob = myForm.Txt_Depto.Text
            cveFamiliab = myForm.Txt_Familia.Text
            cveLineab = myForm.Txt_Linea.Text
            cveL1b = myForm.Txt_L1.Text
            cveL2b = myForm.Txt_L2.Text
            cveL3b = myForm.Txt_L3.Text
            cveL4b = myForm.Txt_L4.Text
            cveL5b = myForm.Txt_L5.Text
            cveL6b = myForm.Txt_L6.Text
            Proveedorb = myForm.Txt_Proveedor.Text
            If myForm.Chk_FechaOrden.Checked = True Then
                FechaInib = Format(myForm.DTPicker2.Value, "yyyy-MM-dd")
                FechaFinb = Format(myForm.DTPicker3.Value, "yyyy-MM-dd")
            Else
                FechaInib = "1900-01-01"
                FechaFinb = "1900-01-01"

            End If
            If myForm.Chk_FechaEntrega.Checked = True Then
                FechaEInib = Format(myForm.DTPicker4.Value, "yyyy-MM-dd")
                FechaEFinb = Format(myForm.DTPicker5.Value, "yyyy-MM-dd")
            Else
                FechaEInib = "1900-01-01"
                FechaEFinb = "1900-01-01"

            End If
            Sucursalb = myForm.Txt_Sucursal.Text
            Statusb = myForm.Cbo_Estatus.Text
            OrdeComInib = myForm.Txt_OrdeComp1.Text
            OrdeComFinb = myForm.Txt_OrdeComp2.Text
            If myForm.Sw_Filtro = True Then
                Call RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub Btn_Proveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'mreyes 27/Febrero/2012 12:35 p.m.
        Try
            Opcion = 2
            Call RellenaGrid()
            Btn_Foto.Enabled = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub

    Private Sub Btn_Estilos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'mreyes 27/Febrero/2012 12:52 p.m.
        Try
            Opcion = 1
            Btn_Foto.Enabled = True
            Call RellenaGrid()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Marca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'mreyes 27/Febrero/2012 12:52 p.m.
        Try
            Opcion = 3
            Call RellenaGrid()
            Btn_Foto.Enabled = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Function Permiso() As Boolean
        If Sw_Costos = False Then
            MsgBox("No tiene permiso para realizar este proceso.", MsgBoxStyle.Critical, "Permisos")
            Exit Function
        End If
        Permiso = True
    End Function
    Private Sub RegistrarSegToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistrarSegToolStripMenuItem.Click
        'mreyes 01/Marzo/2012 09:29
        Try
            If Permiso() = False Then Exit Sub

            Dim myForm As New frmCatalogoSegBit

            Sw_Boton = True
            myForm.Accion = 1
            myForm.Txt_Sucursal.Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "sucursal").ToString.Trim()
            myForm.Txt_OrdeComp.Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ordecomp").ToString.Trim()
            myForm.Txt_Estilon.Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "estilon").ToString()
            myForm.Txt_Marca.Text = Mid(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "marca").ToString, 1, 3)
            myForm.Txt_DescripMarca.Text = Mid(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "marca").ToString, 7)
            myForm.Txt_Realiza.Text = GLB_Idempleado & "-" & GLB_NomUsuario

            myForm.Txt_OrdeComp.ReadOnly = True

            myForm.WindowState = FormWindowState.Normal
            myForm.Refresh()
            myForm.ShowDialog()
            If myForm.Sw_Registro = True Then
                Call RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Seguimiento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Seguimiento.Click
        Try
            'mreyes 01/Marzo/2012 05:16
            If Sw_Costos = False Then
                MsgBox("No tiene permiso para realizar este proceso.", MsgBoxStyle.Critical, "Permisos")
                Exit Sub
            End If
            Dim myForm As New frmCatalogoSegBit

            Sw_Boton = True
            myForm.Accion = 1



            myForm.Txt_OrdeComp.ReadOnly = False
            myForm.Txt_Sucursal.Enabled = True

            myForm.WindowState = FormWindowState.Normal
            myForm.Refresh()
            myForm.ShowDialog()
            If myForm.Sw_Registro = True Then
                Call RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Fechas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Fechas.Click
        Try
            If Sw_Costos = False Then
                MsgBox("No tiene permiso para realizar este proceso.", MsgBoxStyle.Critical, "Permisos")
                Exit Sub
            End If
            Call Consultar_OrdenCompra(2)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Consultar_OrdenCompra(ByVal Accion As Integer)
        '' '' ''mreyes 01/Marzo/2012 05:37 p.m.
        ' '' ''If Accion = 2 Then ''' modificación
        ' '' ''    '' checar permiso
        ' '' ''    If pub_TienePermisoProceso("BITACORA", "00", "") = False Then Exit Sub
        ' '' ''    ''' traer la forma para pedir el permiso
        ' '' ''    ''' 
        ' '' ''    If GLB_Usuario <> "SISTEMAS" And GLB_Usuario <> "MREYES" Or GLB_Usuario <> "FELIX" Or GLB_Usuario <> "FELIXJ" Then
        ' '' ''        Dim myFpermiso As New frmPermisoProceso
        ' '' ''        myFpermiso.ShowDialog()
        ' '' ''        If GLB_PermisoProceso = False Then Exit Sub
        ' '' ''    End If
        ' '' ''End If
        If Opcion <> 1 And Opcion <> 4 Then Exit Sub
        Dim myForm As New frmCatalogoPedidoNuevo
        Sw_Boton = True
        myForm.Accion = Accion
        myForm.Txt_Sucursal.Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "sucursal").ToString.Trim()
        myForm.Txt_OrdeComp.Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ordecomp").ToString.Trim()
        myForm.Sw_Bitacora = True
        myForm.MdiParent = BitacoraMain
        myForm.Show()
        ' Call RellenaGrid()
    End Sub
    Private Sub CMenu_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMenu.Opening
        If Opcion <> 1 And Opcion <> 4 Then
            RegistrarSegToolStripMenuItem.Enabled = False
            VerSeguimientoToolStripMenuItem.Enabled = False
            VerProveedorToolStripMenuItem.Enabled = False
            ImagenToolStripMenuItem.Enabled = False
        End If
        If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "marca").ToString = "" Then
            RegistrarSegToolStripMenuItem.Enabled = False
            VerSeguimientoToolStripMenuItem.Enabled = False
            VerProveedorToolStripMenuItem.Enabled = False
            ImagenToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub Btn_Foto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Foto.Click
        'mreyes 03/Marzo/2012 10:01 a.m.
        Try
            If Opcion = 1 Then
                Me.Cursor = Cursors.WaitCursor
                Dim myForm As New frmConsultaImagen
                myForm.Txt_Estilon.Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "estilon").ToString()
                myForm.Txt_Marca.Text = Mid(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "marca").ToString.Trim(), 1, 3)
                myForm.Txt_NoFoto.Text = "1"
                myForm.ShowDialog()
                Me.Cursor = Cursors.Default
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ImagenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImagenToolStripMenuItem.Click
        'mreyes 03/Marzo/2012 10:01 a.m.
        Try
            If Opcion = 1 Then
                Dim myForm As New frmConsultaImagen
                myForm.Txt_Estilon.Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "estilon").ToString()
                myForm.Txt_Marca.Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "marca").ToString()
                myForm.Txt_NoFoto.Text = "1"
                myForm.ShowDialog()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Imprimir.Click

    End Sub

    Private Sub VerSeguimientoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerSeguimientoToolStripMenuItem.Click
        If Permiso() = False Then Exit Sub

        'mreyes 07/Marzo/2012 11:07 a.m.
        Try
            Dim myForm As New frmPpalSeguimientos

            Sw_Boton = True

            myForm.OrdeComInib = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ordecomp").ToString.Trim()
            myForm.OrdeComFinb = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ordecomp").ToString.Trim()

            myForm.WindowState = FormWindowState.Normal
            myForm.Refresh()
            myForm.ShowDialog()
            'If myForm.Sw_Registro = True Then
            'Call RellenaGrid()
            'End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ConsultaOrdenDeCompraToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultaOrdenDeCompraToolStripMenuItem.Click
        Consultar_OrdenCompra(4)
    End Sub



    Private Sub Btn_OrdeComp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_OrdeComp.Click
        'mreyes 09/Marzo/2012 07:39 p.m.
        Try
            Opcion = 4
            Call RellenaGrid()
            Btn_Foto.Enabled = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_CellErrorTextNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellErrorTextNeededEventArgs) Handles DGrid.CellErrorTextNeeded

    End Sub
    Public Sub ver(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        Try
            Dim Sw_NoEntro As Boolean = False
            Dim Entrega As Date
            Dim Fecha As Date
            Dim DiasEntrega As Integer = 0
            For i As Integer = 0 To DGrid.RowCount - 1
                Entrega = GridView1.GetRowCellValue(i, "Entrega")
                Fecha = Entrega.Add(New TimeSpan(-15, 0, 0, 0))
            Next
            If Not IsNothing(GridView1.GetRowCellValue(e.RowHandle, "FechaSeg")) Then
                If Not IsDBNull(GridView1.GetRowCellValue(e.RowHandle, "FechaSeg")) Then
                    Sw_NoEntro = True
                    GridView1.Columns(3).AppearanceCell.BackColor = Color.GreenYellow
                    GridView1.Columns(3).AppearanceCell.Font = New Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold)
                    GridView1.Columns(2).AppearanceCell.BackColor = Color.GreenYellow
                    GridView1.Columns(2).AppearanceCell.Font = New Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold)
                End If
            End If
            If DiasEntrega <= 7 Then
                Sw_NoEntro = True
                GridView1.Columns(3).AppearanceCell.BackColor = Color.Red
                GridView1.Columns(3).AppearanceCell.Font = New Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold)
                GridView1.Columns(2).AppearanceCell.BackColor = Color.Red
                GridView1.Columns(2).AppearanceCell.Font = New Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold)
            End If

            If DiasEntrega <= 7 Then
                If Not IsDBNull(GridView1.GetRowCellValue(e.RowHandle, "FechaSeg")) Then
                    Sw_NoEntro = True
                    GridView1.Columns(3).AppearanceCell.BackColor = Color.Orange
                    GridView1.Columns(3).AppearanceCell.Font = New Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold)
                    GridView1.Columns(2).AppearanceCell.BackColor = Color.Orange
                    GridView1.Columns(2).AppearanceCell.Font = New Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold)
                End If
            End If

            If DateDiff(DateInterval.Day, Now.Date, Entrega) > 7 And DateDiff(DateInterval.Day, Now.Date, Entrega) <= 30 Then
                If IsDBNull(GridView1.GetRowCellValue(e.RowHandle, "FechaSeg")) Then
                    Sw_NoEntro = True
                    GridView1.Columns(3).AppearanceCell.BackColor = Color.Yellow
                    GridView1.Columns(3).AppearanceCell.Font = New Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold)
                    GridView1.Columns(2).AppearanceCell.BackColor = Color.Yellow
                    GridView1.Columns(2).AppearanceCell.Font = New Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold)
                End If
            End If
            If Sw_NoEntro = False Then
                GridView1.Columns(3).AppearanceCell.BackColor = Color.LightBlue
                GridView1.Columns(3).AppearanceCell.Font = New Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold)
                GridView1.Columns(2).AppearanceCell.BackColor = Color.LightBlue
                GridView1.Columns(2).AppearanceCell.Font = New Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold)
            End If
            If GridView1.GetRowCellValue(e.RowHandle, "pendiente") < 0 Then
                e.Appearance.BackColor = Color.Red
                e.Appearance.Font = New Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ModificarFechasOrdendeCompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarFechasOrdendeCompra.Click
        If Permiso() = False Then Exit Sub
        Call Btn_Fechas_Click(sender, e)
    End Sub
    Private Sub DGrid_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGrid.ColumnHeaderMouseClick
        Sw_Pintar = True
    End Sub
    Private Sub CargarFotoArticulo(ByVal Marca, ByVal Estilon)
        'mreyes 14/Marzo/2012 07:06 p.m.
        'Glb_RutaArchivoFotos
        Try
            Dim Archivo As String = ""
            Dim NoFoto As String = "1"

            MarcaFOTO = Marca
            EstiloNFOTO = Estilon

            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)

                Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Marca, Estilon, NoFoto)

                If objIO.pub_ExisteArchivo(Archivo) = True Then
                    PictureBox1.Image = New System.Drawing.Bitmap(Archivo)
                    PictureBox1.Visible = True
                Else
                    PictureBox1.Visible = False

                End If
                For i As Integer = 0 To 9
                    Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Marca, Estilon, i)
                    If objIO.pub_ExisteArchivo(Archivo) = True Then
                        PictureBox1.Image = New System.Drawing.Bitmap(Archivo)
                        PictureBox1.Visible = True
                        Exit Sub
                    End If
                Next

            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub PBox_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PBox.MouseDown
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                izquierda = e.X
                alto = e.Y
                PBox.Cursor = Cursors.SizeAll
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub PBox_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PBox.MouseMove
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                PBox.Location = New Point(PBox.Left + e.X - izquierda, PBox.Top + e.Y - alto)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub PBox_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PBox.MouseUp
        Try
            PBox.Cursor = Cursors.Default
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub AnalisisToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AnalisisToolStripMenuItem.Click
        Try
            Dim myForm As New frmAnalisisModelo
            myForm.Txt_Marca.Text = Mid(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "marca").ToString, 1, 3)
            myForm.Txt_Modelo.Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "estilon").ToString()
            myForm.Accion = 1
            myForm.WindowState = FormWindowState.Maximized
            myForm.Show()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub CatalogoModToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CatalogoModToolStripMenuItem.Click
        Try
            Dim myForm As New frmCatalogoModelos
            myForm.Txt_Marca.Text = Mid(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "marca").ToString, 1, 3)
            myForm.Txt_Modelo.Text = DGrid.CurrentRow.Cells("estilon").Value
            myForm.Accion = 4
            myForm.Show()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grido.KeyUp
        Try
            Dim Marca As String = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "marca").ToString()
            Dim mmarca As String = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "marca").ToString()
            Dim estilon As String = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "estilon").ToString()
            If IsDBNull(Marca) Then
                PictureBox1.Visible = False
            Else
                CargarFotoArticulo(Mid(mmarca, 1, 3), estilon)
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Grido.MouseDown
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
    Private Sub Grido_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grido.DoubleClick
        'mreyes 02/Marzo/2011 10:14 a.m.
        Try
            If Opcion = 1 Then '' es estilo
                Dim myForm As New frmCatalogoSegBit
                Dim Sucursal As String = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "sucursal").ToString()
                Dim Traspaso As String = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ordecomp").ToString().Trim()
                If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Cancela") = " " Then Exit Sub
                Sw_Boton = True
                myForm.Accion = 4
                myForm.Txt_Sucursal.Text = Sucursal
                myForm.Txt_OrdeComp.Text = Traspaso
                myForm.Txt_Estilon.Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "estilon").ToString()
                myForm.Txt_Marca.Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "marca")
                myForm.Txt_DescripMarca.Text = Mid(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "marca").ToString, 7)

                myForm.WindowState = FormWindowState.Normal
                myForm.Refresh()
                myForm.ShowDialog()
            End If

            If Opcion = 2 Then
                If UCase(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Proveedor")) = "TOT" Then
                    Proveedorb = ""
                Else
                    Proveedorb = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Proveedor")
                End If
                Opcion = 3
                Call RellenaGrid()
            End If

            If Opcion = 4 Then
                If UCase(Mid(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Proveedor").ToString, 1, 3)) = "TOT" Then
                    Proveedorb = ""
                Else
                    Proveedorb = Mid(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Proveedor").ToString, 1, 3)
                End If
                If UCase(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "marca")) = "TOT" Then
                    Marcab = ""
                Else
                    Marcab = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "marca")
                End If
                Sucursalb = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "sucursal").ToString.Trim()
                OrdeComInib = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, " O.C.").ToString.Trim()
                OrdeComFinb = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, " O.C.").ToString.Trim()
                Opcion = 1
                Call RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid1_Click(sender As Object, e As EventArgs) Handles Grido.Click
        Try
            If IsDBNull(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "marca")) Then
                PictureBox1.Visible = False
            Else
                CargarFotoArticulo(Mid(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "marca"), 1, 3), GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "estilon").ToString())
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
End Class