Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid
Public Class frmPpalCatalogoDistrib
    'mreyes     07/02/2018  12:10 p.m.
    'principal de catálogo de distribuidores.
    Public TipoCatalogo As Integer = 0
    Private objDataSet As Data.DataSet
    Private objDataSet1 As Data.DataSet 'Segundo Nivel
    Dim SucurOriB As Integer = 0
    Dim SucurDesB As Integer = 0
    Dim FechaInib As String
    Dim FechaFinb As String
    Dim Sw_Load As Boolean = True
    Dim Sw_NoRegistros As Boolean = False
    Dim Sw_Pintar As Boolean = False
    Public Opcion As Integer = 0   '1 = Enviado,  2 = Por Recibir
    Public OpcionSP As Integer = 0
    Dim MarcaFOTO As String = ""
    Dim EstiloNFOTO As String = ""
    Dim blnEntraDet As Boolean = False
    Dim IdProTrasB As Integer = 0
    Dim EstatusB As String = ""
    Private izquierda As Integer = 0
    Private alto As Integer = 0
    'Dim myFormFiltros As frmFiltrosAparadorReal
    Dim sw_liq As Boolean = False
    '-- filtros
    Public Division As String = ""
    Public Depto As String = ""
    Public Familia As String = ""
    Public Linea As String = ""
    Public L1 As String = ""
    Public L2 As String = ""
    Public L3 As String = ""
    Public L4 As String = ""
    Public L5 As String = ""
    Public L6 As String = ""
    Public Marca As String = ""
    Public Modelo As String = ""
    Public IdAgrupacion As Integer = 0

    Private Sub frmPpalVencidosDias_Load(sender As Object, e As EventArgs) Handles Me.Load
        Sw_Load = True
        Call GenerarToolTip()
        Sw_Pintar = True
        Sw_Load = True

        If TipoCatalogo = 0 Then
            Me.Text = "Catálogo Distribuidores"
        Else
            Me.Text = "Catálogo Tarjetahabiente"
        End If

        Call LimpiarBusqueda()

        Call RellenaGrid()
    End Sub

    Private Sub Pnl_Botones_Paint(sender As Object, e As PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub
    Private Sub GenerarToolTip()
        Try

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub LimpiarBusqueda()
        If GLB_CveSucursal = "01" Or GLB_CveSucursal = "02" Or GLB_CveSucursal = "06" Or GLB_CveSucursal = "07" Or GLB_CveSucursal = "08" Or GLB_CveSucursal = "11" Then
            If Opcion = 1 Then
                SucurOriB = GLB_CveSucursal
            ElseIf Opcion = 2 Then
                SucurOriB = GLB_CveSucursal
            End If
        Else
            SucurOriB = 0
            SucurDesB = 0
        End If
        FechaInib = "1900-01-01"
        FechaFinb = "1900-01-01"
    End Sub

    Private Sub RellenaGrid()
        'mreyes 07/Febrero/2018     12:29 p.m.
        DGrid1.Visible = False
        InicializaGrid()
        Using objTrasp As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
            Try
                Me.Cursor = Cursors.WaitCursor
                Sw_Load = False
                'DGrid.ReadOnly = True
                ' GridControl.DataSource = Nothing
                '    If TipoCatalogo = 0 Then
                objDataSet = objTrasp.usp_PpalDistrib()
                '   Else
                '  objDataSet = objTrasp.usp_PpalDistribTarjetaHabiente()
                ' End If
                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section 
                    'DGrid.ColumnCount = objDataSet.Tables(0).Columns.Count
                    '
                    DGrid1.DataSource = objDataSet.Tables(0)
                    InicializaGrid()
                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True
                    Sw_NoRegistros = True
                    Sw_Pintar = True
                Else
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    MsgBox("LA INFORMACIÓN SE ESTA ACTUALIZANDO, FAVOR DE INTENTAR EN UNOS MINUTOS", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                End If
                Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()
                DGrid1.Visible = True
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Sub InicializaGrid()
        'GridView1
        Try
            GridView1.BestFitColumns()
            For j As Integer = 0 To GridView1.Columns().Count - 1
                GridView1.Columns(j).OptionsColumn.ReadOnly = True
                GridView1.Columns(j).OptionsColumn.AllowEdit = False
            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
        'GridView.BestFitColumns or GridColumn.BestFit 
    End Sub

    Private Sub SaveFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk

    End Sub

    Private Sub Btn_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Excel.Click
        If sfdRuta.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            DGrid1.ExportToXls(sfdRuta.FileName)
        End If
    End Sub

    Private Sub DateEdit1_EditValueChanged(sender As Object, e As EventArgs)
        If Sw_Load = False Then
            Call RellenaGrid()
        End If
    End Sub

    Private Sub DateEdit1_LostFocus(sender As Object, e As EventArgs)

    End Sub

    Private Sub Btn_Salir_Click(sender As Object, e As EventArgs) Handles Btn_Salir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub frmPpalVencidosDias_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub DGrid1_DoubleClick(sender As Object, e As EventArgs) Handles DGrid1.DoubleClick
        Try
            Dim Myform As New frmCatalogoTH
            Dim Renglon As Point = DGrid1.PointToClient(Control.MousePosition)
            Dim info As GridHitInfo = GridView1.CalcHitInfo(Renglon)
            Dim Renglon1 As Integer = info.RowHandle
            Myform.Accion = 4
            Myform.IdDistrib = GridView1.GetRowCellValue(Renglon1, "iddistrib")
            Myform.StartPosition = FormStartPosition.CenterScreen
            Myform.ShowDialog()
            If GLB_RefrescarPedido = True Then
                Call RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub GridView1_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GridView1.RowStyle
        Try
            Dim View As GridView = sender
            If (e.RowHandle >= 0) Then
                Dim concepto As String = (View.GetRowCellDisplayText(e.RowHandle, View.Columns("estatus")))
                If concepto = "SUSPENDIDO" Then
                    'el concepto 1 es que ya se hablo el dia actual
                    'el concepto 2 es que hay que hablarle.
                    'e.Appearance.BackColor = Color.Aqua
                    e.Appearance.BackColor = Color.Gold
                    e.Appearance.BackColor2 = Color.SeaShell
                    'e.Appearance.Font = New Font(Font.FontFamily, 2, FontStyle.Bold)
                    e.Appearance.BorderColor = Color.Red
                    'New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                    'e.Appearance.BackColor2 = Color.SeaShell
                End If

                If concepto = "BAJA" Then
                    'el concepto 1 es que ya se hablo el dia actual
                    'el concepto 2 es que hay que hablarle.
                    'e.Appearance.BackColor = Color.Aqua
                    e.Appearance.BackColor = Color.Red
                    e.Appearance.BackColor2 = Color.SeaShell
                    'e.Appearance.Font = New Font(Font.FontFamily, 2, FontStyle.Bold)
                    e.Appearance.BorderColor = Color.Red
                    'New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                    'e.Appearance.BackColor2 = Color.SeaShell
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid1_Click(sender As Object, e As EventArgs) Handles DGrid1.Click

    End Sub

    Private Sub Btn_Refrescar_Click(sender As Object, e As EventArgs) Handles Btn_Refrescar.Click
        Call RellenaGrid()
    End Sub

    Private Sub Btn_Guardar_Click(sender As Object, e As EventArgs) Handles Btn_Nuevo.Click
        Dim myForm As New frmCatalogoTH
        myForm.Accion = 1
        myForm.ShowDialog()
        If GLB_RefrescarPedido = True Then
            Call RellenaGrid()
        End If
    End Sub

    Private Sub Btn_Consultar_Click(sender As Object, e As EventArgs) Handles Btn_Consultar.Click
        Try
            Dim Myform As New frmCatalogoTH
            Dim Renglon As Point = DGrid1.PointToClient(Control.MousePosition)
            Dim info As GridHitInfo = GridView1.CalcHitInfo(Renglon)
            Dim Renglon1 As Integer = info.RowHandle
            Myform.Accion = 3
            Myform.IdDistrib = GridView1.GetRowCellValue(Renglon1, "iddistrib")
            For i As Integer = 0 To GridView1.RowCount - 1
                If GridView1.IsRowSelected(i) = True Then
                    Myform.IdDistrib = GridView1.GetRowCellValue(i, "iddistrib")
                    Exit For
                End If
            Next
            Myform.StartPosition = FormStartPosition.CenterScreen
            Myform.ShowDialog()
            If GLB_RefrescarPedido = True Then
                Call RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Editar_Click(sender As Object, e As EventArgs) Handles Btn_Editar.Click
        Try
            Dim Myform As New frmCatalogoTH
            Dim Renglon As Point = DGrid1.PointToClient(Control.MousePosition)
            Dim info As GridHitInfo = GridView1.CalcHitInfo(Renglon)
            Dim Renglon1 As Integer = info.RowHandle
            Myform.Accion = 2
            Myform.IdDistrib = GridView1.GetRowCellValue(Renglon1, "iddistrib")
            For i As Integer = 0 To GridView1.RowCount - 1
                If GridView1.IsRowSelected(i) = True Then
                    Myform.IdDistrib = GridView1.GetRowCellValue(i, "iddistrib")
                    Exit For
                End If
            Next
            'Myform.getRow(idtipovivienda)
            Myform.StartPosition = FormStartPosition.CenterScreen
            Myform.ShowDialog()
            If GLB_RefrescarPedido = True Then
                Call RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
End Class