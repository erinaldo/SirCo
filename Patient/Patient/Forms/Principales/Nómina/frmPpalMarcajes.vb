Imports DevExpress.DashboardCommon
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Columns.GridColumn
Public Class frmPpalMarcajes
    'mreyes 23/Junio/2012 01:54 p.m. 
    Private objDataSet As DataSet
    Public Sw_Registro As Boolean = False
    Public Sw_PedidoNuevo As Boolean = True
    Public Sw_Cancelaciones As Boolean = False
    Dim RutaArchivoCorreo As String = ""
    Public Sw_NoLimpiar As Boolean = True
    Public IdEmpleadoB As Integer
    Dim IdPuestoB As Integer
    Dim IdDeptoB As Integer
    Public SucursalB As String
    Public FechaIniB As Date
    Public FechaFinB As Date
    Dim Sw_Load As Boolean = True
    Dim Sw_Boton As Boolean = False
    Dim Sw_NoRegistros As Boolean = False
    Dim FechaUltResurt As Date
    Dim Sw_Pintar As Boolean = False
    Private Sub frmPpalPedidoNuevo_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Sw_Load = True Then
            If Sw_NoRegistros = False Then
                Sw_Load = False
                ''     InicializaGrid()
                'Factura_Microsip()
            Else
                Sw_Load = False
                'Sw_NoRegistros = False
            End If
        End If
    End Sub
    Private Sub frmPpalPedidoNuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
        If e.KeyCode = Keys.F5 Then
            Call Btn_Filtro_Click_1(sender, e)
        End If
    End Sub
    Private Sub frmPpalPedidoNuevo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Sw_Load = True
            Sw_Pintar = True
            Call LimpiarBusqueda()
            '  FechaInib = Format(Now.Date, "yyyy-MM-dd")
            '  FechaFinb = Format(Now.Date, "yyyy-MM-dd")
            If Sw_NoLimpiar = True Then
                Call FechaUltimoPeriodo()
            End If
            Call RellenaGrid()
            Call GenerarToolTip()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub FechaUltimoPeriodo()
        'mreyes 23/Agosto/2012 06:43 p.m.
        Try
            Dim objDataSet1 As DataSet
            Using objCantArti As New BCL.BCLMySqlGral(GLB_ConStringNomSis)
                objDataSet1 = objCantArti.usp_TraerUltimoPeriodo(2, "", 0)
                If objDataSet1.Tables(0).Rows.Count > 0 Then
                    FechaIniB = Format(objDataSet1.Tables(0).Rows(0).Item("fechaini"), "yyyy-MM-dd")
                    FechaFinB = Format(objDataSet1.Tables(0).Rows(0).Item("fechafin"), "yyyy-MM-dd")
                End If
            End Using
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
            ToolTip.SetToolTip(Btn_Salir, "Salir")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub RellenaGrid()
        Using objChecador As New BCL.BCLChecador(GLB_ConStringNomSis)
            Try
                Me.Cursor = Cursors.WaitCursor
                '''' DGrid.ReadOnly = True
                Grido.DataSource = Nothing
                objDataSet = objChecador.usp_PpalMarcaje(IdEmpleadoB, SucursalB, IdDeptoB, IdPuestoB, FechaIniB, FechaFinB)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section
                    Grido.DataSource = objDataSet.Tables(0)
                    InicializaGrid()
                    'LimpiarBusqueda()
                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True
                    Sw_NoRegistros = True
                    Sw_Pintar = True
                    'DGrid.Rows(0).Selected = True
                Else
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    If Sw_Load = False Then
                        MsgBox("No se encontraron Marcajes que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    End If
                    Btn_Excel.Enabled = False
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub
    Private Sub LimpiarBusqueda()
        If Sw_NoLimpiar = False Then Exit Sub
        IdEmpleadoB = 0
        IdDeptoB = 0
        IdPuestoB = 0
        SucursalB = ""
        FechaIniB = "2012-06-08"
        FechaFinB = "2012-06-08"
        If GLB_CveSucursal <> "" Then
            SucursalB = GLB_CveSucursal
        Else
            SucursalB = ""
        End If
    End Sub
    Private Sub Btn_Refrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Sub InicializaGrid()
        'mreyes 23/Junio/2012 02:09 p.m.
        Try
            GridView1.OptionsView.ColumnAutoWidth = False
            GridView1.Columns(0).Caption = " Sucursal"
            GridView1.Columns(1).Caption = " IdEmpleado "
            GridView1.Columns(2).Caption = " Nombre "
            GridView1.Columns(3).Caption = " Fecha "
            GridView1.Columns(4).Caption = " Día "
            GridView1.Columns(5).Caption = " Entrada"
            GridView1.Columns(6).Caption = " Salida "
            GridView1.Columns(7).Caption = " Entrada "
            GridView1.Columns(8).Caption = " Salida "
            GridView1.Columns(9).Caption = " Retardo "
            GridView1.Columns(10).Caption = " Extras "
            GridView1.Columns(0).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(1).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(3).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(4).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(5).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(6).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(7).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(8).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(9).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(10).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center



            GridView1.Columns(0).AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(1).AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(2).AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(3).AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(4).AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(5).AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(6).AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(7).AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(8).AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(9).AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(10).AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center


            GridView1.Columns(0).AppearanceHeader.Font = New Font(GridView1.Columns(0).AppearanceCell.Font, FontStyle.Bold)
            GridView1.Columns(1).AppearanceHeader.Font = New Font(GridView1.Columns(1).AppearanceCell.Font, FontStyle.Bold)
            GridView1.Columns(2).AppearanceHeader.Font = New Font(GridView1.Columns(2).AppearanceCell.Font, FontStyle.Bold)
            GridView1.Columns(3).AppearanceHeader.Font = New Font(GridView1.Columns(3).AppearanceCell.Font, FontStyle.Bold)
            GridView1.Columns(4).AppearanceHeader.Font = New Font(GridView1.Columns(4).AppearanceCell.Font, FontStyle.Bold)
            GridView1.Columns(5).AppearanceHeader.Font = New Font(GridView1.Columns(5).AppearanceCell.Font, FontStyle.Bold)
            GridView1.Columns(6).AppearanceHeader.Font = New Font(GridView1.Columns(6).AppearanceCell.Font, FontStyle.Bold)
            GridView1.Columns(7).AppearanceHeader.Font = New Font(GridView1.Columns(7).AppearanceCell.Font, FontStyle.Bold)
            GridView1.Columns(8).AppearanceHeader.Font = New Font(GridView1.Columns(8).AppearanceCell.Font, FontStyle.Bold)
            GridView1.Columns(9).AppearanceHeader.Font = New Font(GridView1.Columns(9).AppearanceCell.Font, FontStyle.Bold)
            GridView1.Columns(10).AppearanceHeader.Font = New Font(GridView1.Columns(10).AppearanceCell.Font, FontStyle.Bold)


            GridView1.BestFitColumns()
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
        Dim myForm As New frmCatalogoPedidoNuevo
        Sw_Boton = True
        myForm.Accion = 1
        myForm.Sw_PedidoNuevo = Sw_PedidoNuevo
        myForm.MdiParent = BitacoraMain
        myForm.Show()
        If myForm.Sw_Registro = True Then
            Call RellenaGrid()
        End If
    End Sub
    Private Sub Btn_Filtro_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        'mreyes 25/Junio/2012 09:44 a.m.
        Dim myForm As New frmFiltrosMarcajes
        myForm.Txt_IdEmpleado.Text = IdEmpleadoB
        myForm.Txt_IdPuesto.Text = IdPuestoB
        myForm.Txt_IdDepto.Text = IdDeptoB
        If GLB_CveSucursal <> "" Then
            myForm.Txt_Sucursal.Enabled = False
        End If
        myForm.Txt_Sucursal.Text = SucursalB
        If FechaIniB <> "1900-01-01" Then
            myForm.Chk_Fecha.Checked = True
            myForm.DTPicker2.Value = FechaIniB
            myForm.DTPicker3.Value = FechaFinB
        End If
        myForm.ShowDialog()
        IdEmpleadoB = Val(myForm.Txt_IdEmpleado.Text)
        IdPuestoB = Val(myForm.Txt_IdPuesto.Text)
        IdDeptoB = Val(myForm.Txt_IdDepto.Text)
        SucursalB = myForm.Txt_Sucursal.Text
        If myForm.Chk_Fecha.Checked = True Then
            FechaIniB = Format(myForm.DTPicker2.Value, "yyyy-MM-dd")
            FechaFinB = Format(myForm.DTPicker3.Value, "yyyy-MM-dd")
        Else
            FechaIniB = "1900-01-01"
            FechaFinB = "1900-01-01"
        End If
        If myForm.Sw_Filtro = True Then
            Call RellenaGrid()
        End If
    End Sub
    Private Sub NuevoPDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoPDToolStripMenuItem.Click
        Call Btn_Nuevo_Click(sender, e)
    End Sub
    Private Sub Btn_Eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'mreyes 28/Abril/2012 10:48 a.m.
        If Sw_NoRegistros = False Then Exit Sub
        '' PRIMERO TIENE QUE GENERAR EL ID DOCTO PARA GRABAR EN DOCTOS_CP
        Try
            If MsgBox("Esta seguro de querer cancelar los Pedidos Seleccionados?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub
            Me.Cursor = Cursors.WaitCursor
            Dim Cont As Integer = 0
            Dim OrdeComp As String
            Dim Sucursal As String
            For Each row As DataGridViewRow In DGrid.Rows
                If row.Cells("Selec").Value = True Then
                    OrdeComp = row.Cells("ordecomp").Value
                    Sucursal = row.Cells("sucursal").Value
                    Cont = Cont + 1
                    Using objPedidos As New BCL.BCLPedidos(GLB_ConStringCipSis)
                        Try
                            'Get the specific project selected in the ListView control
                            If objPedidos.usp_ActualizarOrdeComp(Sucursal, OrdeComp) = True Then
                                ' SI SE ACTUALIZO
                            End If
                        Catch ExceptionErr As Exception
                            MessageBox.Show(ExceptionErr.Message.ToString)
                        End Try
                    End Using
                End If ' del select  
            Next
            Me.Cursor = Cursors.Default
            MsgBox("Se han Cancelado '" & Cont & "' Pedidos.", MsgBoxStyle.Information, "Confirmación")
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Btn_InvertirSeleccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Sw_NoRegistros = False Then Exit Sub
        Call Factura_Microsip()
    End Sub
    Private Sub Factura_Microsip()
        'mreyes 21/Marzo/2012 11:53 a.m.
        For Each row As DataGridViewRow In DGrid.Rows
            If row.Cells("ordecomp").Value = "Total: " Then Exit For
            If row.Cells("Selec").Value = True Then
                row.Cells("Selec").Value = False
            Else
                row.Cells("Selec").Value = True
            End If
        Next
    End Sub
    Private Sub Btn_Pdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'mreyes 16/Marzo/2012 06:24 p.m.
        If Sw_NoRegistros = False Then Exit Sub
        '' PRIMERO TIENE QUE GENERAR EL ID DOCTO PARA GRABAR EN DOCTOS_CP
        Try
            Dim Cont As Integer = 0
            If MsgBox("Esta seguro de querer generar los archivos PDF de los pedidos seleccionados. Este proceso puede durar varios minutos.?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub
            Me.Cursor = Cursors.WaitCursor
            For Each row As DataGridViewRow In DGrid.Rows
                If row.Cells("Selec").Value = True Then
                    If row.Cells("status").Value <> "ZC" Then
                        Cont = Cont + 1
                        Dim myForm As New frmCatalogoPedidoNuevo
                        Sw_Boton = True
                        myForm.Accion = 4
                        myForm.Sw_SoloPasoPDF = True
                        myForm.Sw_PedidoNuevo = Sw_PedidoNuevo
                        myForm.Txt_Sucursal.Text = row.Cells("sucursal").Value.ToString.Trim()
                        myForm.Txt_OrdeComp.Text = row.Cells("ordecomp").Value.ToString.Trim()
                        myForm.MdiParent = BitacoraMain
                        myForm.Show()
                        myForm.Close()
                        myForm.Dispose()
                    End If
                End If ' del microsip 
            Next
            Me.Cursor = Cursors.Default
            MsgBox("Se han creado '" & Cont & "' Archivos de Pedido.", MsgBoxStyle.Information, "Confirmación")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Function Inserta_OrdeComp(ByVal OrdeComp As String, ByVal Sucursal As String, ByVal Marca As String, ByVal Proveedor As String,
                                    ByVal Dsctopp As Decimal, ByVal diaspp As Decimal, ByVal dscto01 As Decimal, ByVal dscto02 As Decimal, ByVal dscto03 As Decimal, ByVal dscto04 As Decimal, ByVal dscto05 As Decimal, ByVal iva As Decimal) As Boolean
        'mreyes 14/Febrero/2012 01:44 p.m.
        Using objPedidos As New BCL.BCLPedidos(GLB_ConStringCipSis)
            'Get a new Project DataSet
            Try
                objDataSet = objPedidos.Inserta_OrdeComp  'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As DataRow = objDataSet.Tables(0).NewRow
                'Set the values in the DataRow
                objDataRow.Item("sucursal") = Trim(Sucursal)
                objDataRow.Item("ordecomp") = Trim(OrdeComp)
                objDataRow.Item("status") = "AP"
                objDataRow.Item("fecha") = Now.Date
                objDataRow.Item("marca") = Trim(Marca)
                objDataRow.Item("proveedor") = Proveedor
                objDataRow.Item("observa") = "RESURTIDO AUTOMÁTICO"
                objDataRow.Item("usuario") = GLB_Usuario
                objDataRow.Item("resurtsn") = "S"
                objDataRow.Item("dsctopp") = Val(Dsctopp)
                objDataRow.Item("diaspp") = Val(diaspp)
                objDataRow.Item("dscto01") = Val(dscto01)
                objDataRow.Item("dscto02") = Val(dscto02)
                objDataRow.Item("dscto03") = Val(dscto03)
                objDataRow.Item("dscto04") = Val(dscto04)
                objDataRow.Item("dscto05") = Val(dscto05)
                objDataRow.Item("iva") = Val(iva)
                'Add the DataRow to the DataSet
                objDataSet.Tables(0).Rows.Add(objDataRow)
                'Add the Project
                If Not objPedidos.usp_Captura_OrdeComp(1, objDataSet) Then
                    '' Throw New Exception("Falló Inserción de OrdeComp")
                Else
                    Inserta_OrdeComp = True
                End If
                Inserta_OrdeComp = True
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function
    Private Function ActualizarCantSolMedida(ByVal Marca As String, ByVal Estilon As String, ByVal Corrida As String, ByVal Medida As String) As Boolean
        'mreyes 21/Marzo/2012 07:19 p.m.
        Using objPedidos As New BCL.BCLPedidos(GLB_ConStringCipSis)
            Try
                'Get the specific project selected in the ListView control
                ActualizarCantSolMedida = objPedidos.usp_ActualizarCantSolMedida(Marca, Estilon, Corrida, Medida)
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function
    'Private Sub DGrid_CellFormatting(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs)
    'Try
    '        'mreyes 30/Junio/2012 10:59 a.m.
    '        Dim Sw_NoEntro As Boolean = False
    '        Dim DiasEntrega As Integer = 0
    '        If Sw_Pintar = False Then Exit Sub
    '        If GridView1.FocusedColumn.FieldName <> "Retardo" Then Exit Sub
    '        ''If Me.DGrid.Columns(e.ColumnIndex).Name <> "fecha" Then Exit Sub
    '        If e.RowIndex >= DGrid.RowCount - 1 Then
    '            If Sw_Load = False Then
    '                Sw_Pintar = False
    '            End If
    '            Exit Sub
    '        End If
    '        If IsDBNull(DGrid.Rows(e.RowIndex).Cells("Extras").Value) = False Then
    '            If DGrid.Rows(e.RowIndex).Cells("Extras").Value <> "00:00:00" And DGrid.Rows(e.RowIndex).Cells("Extras").Value.ToString.Length > 0 Then
    '                DGrid.Rows(e.RowIndex).Cells("Extras").Style.BackColor = Color.Yellow
    '                DGrid.Rows(e.RowIndex).Cells("Extras").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
    '            End If
    '        End If
    '        If IsDBNull(DGrid.Rows(e.RowIndex).Cells("Retardo").Value) = False Then
    '            If DGrid.Rows(e.RowIndex).Cells("Retardo").Value <> "00:00:00" Then
    '                DGrid.Rows(e.RowIndex).Cells("Retardo").Style.BackColor = Color.Red
    '                DGrid.Rows(e.RowIndex).Cells("Retardo").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
    '            Else
    '                DGrid.Rows(e.RowIndex).Cells("Retardo").Style.BackColor = Color.Yellow
    '                DGrid.Rows(e.RowIndex).Cells("Retardo").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
    '            End If
    '        End If
    '    Catch ExceptionErr As Exception
    '        MessageBox.Show(ExceptionErr.Message.ToString)
    '    End Try
    'End Sub
    Private Sub GridView1_CustomDrawCell(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        Try
            Dim Sw_NoEntro As Boolean = False
            Dim DiasEntrega As Integer = 0
            If GridView1.FocusedColumn.Name <> "Retardo" Then
                If e.RowHandle >= GridView1.RowCount - 0 Then
                    If Sw_Load = False Then
                        Sw_Pintar = False
                    End If
                    Exit Sub
                End If
            End If
            If IsDBNull(GridView1.GetRowCellValue(e.RowHandle, "Extras")) = False Then
                If e.CellValue.ToString() <> "00:00:00" And GridView1.GetFocusedRowCellValue("Extras").ToString().Length > 0 Then
                    e.Appearance.BackColor = Color.Yellow
                    e.Appearance.Font = New Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold)
                End If
            End If


            If IsDBNull(GridView1.GetRowCellValue(e.RowHandle, "Retardo")) = False Then
                If e.CellValue.ToString() <> "00:00:00" Then
                    e.Appearance.BackColor = Color.Red
                    e.Appearance.Font = New Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold)
                Else
                    e.Appearance.BackColor = Color.Yellow
                    e.Appearance.Font = New Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold)
                End If
                If e.Column.Caption.ToString() <> "Retardo" Then
                    e.Column.AppearanceCell.BackColor = Color.White
                End If
            End If
            If e.Column.FieldName.ToString() <> "Retardo" Then
                e.Appearance.BackColor = Color.White
                e.Appearance.Font = New Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Regular)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
End Class