Imports DevExpress.DashboardCommon
Imports DevExpress.Utils
Imports DevExpress.Utils.Menu



Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Columns.GridColumn

Public Class frmPpaPendientesRealizar
    'mreyes 06/Julio/2016   06:41 p.m.

    Private objDataSet As DataSet
    Private objDataSet1 As DataSet 'Segundo Nivel
    Dim SucurOriB As Integer = 0
    Dim SucurDesB As Integer = 0
    Dim FechaInib As String
    Dim FechaFinb As String
    Dim Tota As Integer = 0

    Dim Sw_Load As Boolean = True
    Dim Sw_NoRegistros As Boolean = False
    Dim Sw_Pintar As Boolean = False
    Public Opcion As Integer = 0   '1 = Enviado,  2 = Por Recibir
    Public OpcionSP As Integer = 0
    Dim MarcaFOTO As String = ""
    Dim EstiloNFOTO As String = ""
    Dim blnEntraDet As Boolean = False

    Public IdProTrasB As Integer = 0
    Dim EstatusB As String = ""
    Private izquierda As Integer = 0
    Private alto As Integer = 0



    Private Sub frmPpalPpalDetFactProv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call GenerarToolTip()
        Sw_Pintar = True
        Sw_Load = True
        Call LimpiarBusqueda()
        Call RellenaGrid()

    End Sub

    Private Sub frmPpalPpalDetFactProv_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Sw_NoRegistros = False Then Exit Sub
        'If Sw_Load = True Then
        '    Sw_Load = False
        'blnPrimero = True
        ' InicializaGrid()
        'AgregarColumna()
        '    Call BarrerGrid()
        'End If

    End Sub

    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Filtro, "Búsqueda Avanzada")
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
            ToolTip.SetToolTip(Btn_Pendientes, "Traspasos Pendientes")
            ToolTip.SetToolTip(Btn_RecibosParciales, "Traspasos Parciales")
            ToolTip.SetToolTip(Btn_RecibosTodos, "Todos los Traspasos")

            ToolTip.SetToolTip(Btn_Salir, "Salir")
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
        'mreyes 06/Julio/2016   06:42 p.m.
        Grido.Visible = False
        'InicializaGrid()
        Using objTrasp As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                'DGrid.ReadOnly = True
                Grido.DataSource = Nothing
                objDataSet = objTrasp.usp_PpalProTrasp(OpcionSP, IdProTrasB, SucurOriB, FechaInib, FechaFinb, "GE")


                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section 
                    'DGrid.ColumnCount = objDataSet.Tables(0).Columns.Count
                    '
                    Grido.DataSource = objDataSet.Tables(0)
                    InicializaGrid()
                    'If Sw_Load = False Then
                    ''''
                    'End If
                    'LimpiarBusqueda()
                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True
                    Sw_NoRegistros = True
                    Sw_Pintar = True
                    If GridView1.RowCount > 0 Then
                        If OpcionSP = 1 Then
                            Lbl_Trasp.Visible = True
                            Lbl_Trasp.Text = "Número de Traspasos: " & GridView1.RowCount - 1
                        Else
                            ' Lbl_Trasp.Text = "Número de Estilos a Traspasar: " & DGrid.RowCount - 1
                            Lbl_Trasp.Visible = False

                        End If
                    End If
                    'Call Colores()
                Else
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron registros que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                End If
                Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()
                Grido.Visible = True
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub
    Private Sub Grido_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        Dim ea As DXMouseEventArgs = TryCast(e, DXMouseEventArgs)
        Dim view As GridView = TryCast(sender, GridView)
        Dim info As GridHitInfo = view.CalcHitInfo(ea.Location)
        If info.InRow OrElse info.InRowCell Then
            Grid_DoubleClick()
        End If
    End Sub
    Sub InicializaGrid()
        Try
            Dim Total As Integer
            Dim Total2 As Integer
            Dim Total3 As Integer
            Dim Total4 As Integer
            Dim posi As Integer
            posi = GridView1.FocusedRowHandle
            Dim dt As DataTable = TryCast(Grido.DataSource, DataTable)
            Dim row As DataRow = dt.NewRow()
            dt.Rows.InsertAt(row, posi)
            row(3) = "TOTAL"
            row("PEDIDA") = 0
            row("diferencia") = 0
            row("recibida") = 0
            row("diferencia1") = 0
            For i As Integer = 0 To GridView1.DataRowCount - 1

                Total = Total + GridView1.GetRowCellValue(i, "pedida")
                Total2 = Total2 + GridView1.GetRowCellValue(i, "diferencia")
                Total3 = Total3 + GridView1.GetRowCellValue(i, "recibida")
                Total4 = Total4 + GridView1.GetRowCellValue(i, "diferencia1")
            Next
            row("PEDIDA") = Total
            row("diferencia") = Total2
            row("recibida") = Total3
            row("diferencia1") = Total4
            GridView1.Columns(0).Caption = "Id"
            GridView1.Columns(1).Caption = "IdSucursal"
            GridView1.Columns(2).Caption = "Det Origen"
            GridView1.Columns(3).Caption = "Origen"
            GridView1.Columns(4).Caption = "IdSucursal"
            GridView1.Columns(5).Caption = "Det Destino"
            GridView1.Columns(6).Caption = "Destino"
            GridView1.Columns(7).Caption = "Fum Solicitado"
            GridView1.Columns(8).Caption = "Tipo"
            GridView1.Columns(9).Caption = "Estatus"
            GridView1.Columns(10).Caption = "Fum Solicitado"
            GridView1.Columns(11).Caption = "Solicitado"
            GridView1.Columns(12).Caption = "Enviado"
            GridView1.Columns(13).Caption = "Diferencia"

            GridView1.Columns(14).Caption = "Fum Envio"
            GridView1.Columns(15).Caption = "Recibida"
            GridView1.Columns(16).Caption = "Diferencia"
            GridView1.Columns(17).Caption = "Fum Recibida"



            For j As Integer = 0 To GridView1.Columns().Count - 1
                GridView1.Columns(j).OptionsColumn.ReadOnly = True
                GridView1.Columns(j).OptionsColumn.AllowEdit = False
                GridView1.Columns(j).AppearanceHeader.BackColor = Color.LightBlue
                GridView1.Columns(j).AppearanceHeader.TextOptions.HAlignment = HorizontalAlignment.Center

            Next

            GridView1.Columns(0).Visible = True
            GridView1.Columns(1).Visible = False
            GridView1.Columns(4).Visible = False


            GridView1.Columns(2).Visible = False
            GridView1.Columns(9).Visible = False
            GridView1.Columns(5).Visible = False
            'DGrid.Columns(8).Visible = False
            GridView1.Columns(7).Visible = False




            GridView1.Columns(10).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(11).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(12).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(13).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(14).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(15).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(16).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(17).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(7).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(9).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.BestFitColumns()

            GridView1.Columns(14).DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            GridView1.Columns(14).DisplayFormat.FormatString = "G"

            GridView1.Columns(10).DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            GridView1.Columns(10).DisplayFormat.FormatString = "G"

            GridView1.Columns(17).DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            GridView1.Columns(17).DisplayFormat.FormatString = "G"



        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub InicializarGrido2()
        Try
            Dim Total As Integer
            Dim Total2 As Integer
            Dim Total3 As Integer
            Dim Total4 As Integer
            Dim posi As Integer
            posi = GridView1.FocusedRowHandle
            Dim dt As DataTable = TryCast(Grido.DataSource, DataTable)
            Dim row As DataRow = dt.NewRow()
            dt.Rows.InsertAt(row, posi)
            row(3) = "TOTAL"
            row("PEDIDA") = 0
            row("diferencia") = 0
            row("recibida") = 0
            row("diferencia1") = 0
            For i As Integer = 0 To GridView1.DataRowCount - 1

                Total = Total + GridView1.GetRowCellValue(i, "pedida")
                Total2 = Total2 + GridView1.GetRowCellValue(i, "diferencia")
                Total3 = Total3 + GridView1.GetRowCellValue(i, "recibida")
                Total4 = Total4 + GridView1.GetRowCellValue(i, "diferencia1")
            Next
            row("PEDIDA") = Total
            row("diferencia") = Total2
            row("recibida") = Total3
            row("diferencia1") = Total4
            GridView1.OptionsView.ColumnAutoWidth = False
            GridView1.Columns(0).Caption = "Id"
            GridView1.Columns(1).Caption = "IdSucusal"
            GridView1.Columns(2).Caption = "Det Origen"
            GridView1.Columns(3).Caption = "Origen"
            GridView1.Columns(4).Caption = "IdSucursal"
            GridView1.Columns(5).Caption = "Det Destino"
            GridView1.Columns(6).Caption = "Destino"
            GridView1.Columns(7).Caption = "Fecha"
            GridView1.Columns(8).Caption = "Tipo"
            GridView1.Columns(9).Caption = "Marca"
            GridView1.Columns(10).Caption = "Modelo"
            GridView1.Columns(11).Caption = "Descripción"
            GridView1.Columns(12).Caption = "Corrida"
            GridView1.Columns(13).Caption = "Medida"
            GridView1.Columns(14).Caption = "Fum Solicitado"
            GridView1.Columns(15).Caption = "Solicitado"
            GridView1.Columns(16).Caption = "Enviada"
            GridView1.Columns(17).Caption = "Diferencia"
            GridView1.Columns(18).Caption = "Fum Envio"
            GridView1.Columns(19).Caption = "Recibida"
            GridView1.Columns(20).Caption = "Diferencia"
            GridView1.Columns(21).Caption = "Fum Recibida"




            GridView1.Columns.AddField(18).Caption = "Fum Envio"
            GridView1.Columns.AddField(19).Caption = "Recibida"
            GridView1.Columns.AddField(20).Caption = "Diferencia"
            GridView1.Columns.AddField(21).Caption = "Fum Recibida"



            GridView1.Columns(3).Visible = True
            GridView1.Columns(6).Visible = True
            GridView1.Columns(8).Visible = True
            GridView1.Columns(9).Visible = True
            GridView1.Columns(10).Visible = True
            GridView1.Columns(13).Visible = True
            GridView1.Columns(14).Visible = True
            GridView1.Columns(16).Visible = True
            GridView1.Columns(17).Visible = True
            GridView1.Columns(18).Visible = True
            GridView1.Columns(19).Visible = True
            GridView1.Columns(20).Visible = True
            GridView1.Columns(21).Visible = True

            For j As Integer = 0 To GridView1.Columns().Count - 1
                GridView1.Columns(j).OptionsColumn.ReadOnly = True
                GridView1.Columns(j).OptionsColumn.AllowEdit = False
                GridView1.Columns(j).AppearanceHeader.BackColor = Color.LightBlue
                GridView1.Columns(j).AppearanceHeader.TextOptions.HAlignment = HorizontalAlignment.Center

            Next

            GridView1.Columns(0).Visible = False
            GridView1.Columns(1).Visible = False
            GridView1.Columns(2).Visible = False
            GridView1.Columns(4).Visible = False
            GridView1.Columns(5).Visible = False
            GridView1.Columns(7).Visible = False
            GridView1.Columns(11).Visible = False
            GridView1.Columns(12).Visible = False



            GridView1.Columns(13).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(14).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(15).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(16).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(17).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(18).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(19).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(20).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(21).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center

            GridView1.Columns(12).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(10).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(7).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(9).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.BestFitColumns()

            GridView1.Columns(14).DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            GridView1.Columns(14).DisplayFormat.FormatString = "G"

            GridView1.Columns(18).DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            GridView1.Columns(18).DisplayFormat.FormatString = "G"

            GridView1.Columns(21).DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            GridView1.Columns(21).DisplayFormat.FormatString = "G"



        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Grid_DoubleClick()
        Dim op = 2
        Dim Id As Integer
        Try
            Id = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "idprotras")
            GridView1.Columns.Clear()
            Using ObjTrasp As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
                objDataSet1 = ObjTrasp.usp_PpalProTrasp(op, Id, 0, "1900-01-01", "1900-01-01", "GE")
            End Using
            If objDataSet1.Tables(0).Rows.Count > 0 Then
                Grido.DataSource = Nothing
                Grido.DataSource = objDataSet1.Tables(0)
                InicializarGrido2()
                blnEntraDet = True
                Btn_Regresar.Enabled = True
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

    Private Sub frmPpalPpalDetFactProv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Filtro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        Try
            Dim myForm As New frmFiltrosTraspasosPendRecibo
            myForm.Opcion = Opcion
            myForm.Txt_SucurOri.Text = SucurOriB
            myForm.Txt_SucurDes.Text = SucurDesB

            If FechaInib <> "1900-01-01" Then
                myForm.Chk_FechaTraspaso.Checked = True
                myForm.DTPicker2.Value = FechaInib
                myForm.DTPicker3.Value = FechaFinb
            End If

            If OpcionSP = 3 Then
                myForm.Cbo_Tipo.Text = "PENDIENTES"
            ElseIf OpcionSP = 2 Then
                myForm.Cbo_Tipo.Text = "PARCIALES"
            ElseIf OpcionSP = 1 Then
                myForm.Cbo_Tipo.Text = "TODOS"
            End If

            myForm.ShowDialog()

            SucurOriB = myForm.Txt_SucurOri.Text
            SucurDesB = myForm.Txt_SucurDes.Text

            If myForm.Chk_FechaTraspaso.Checked = True Then
                FechaInib = Format(myForm.DTPicker2.Value, "yyyy-MM-dd")
                FechaFinb = Format(myForm.DTPicker3.Value, "yyyy-MM-dd")
            Else
                FechaInib = "1900-01-01"
                FechaFinb = "1900-01-01"
            End If

            If myForm.Cbo_Tipo.Text = "PENDIENTES" Then
                OpcionSP = 3
            ElseIf myForm.Cbo_Tipo.Text = "PARCIALES" Then
                OpcionSP = 2
            ElseIf myForm.Cbo_Tipo.Text = "TODOS" Then
                OpcionSP = 1
            End If

            If myForm.Sw_Filtro = True Then
                Call RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_RecibosParciales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_RecibosParciales.Click
        Try
            OpcionSP = 2
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_RecibosTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_RecibosTodos.Click
        Try
            OpcionSP = 1
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Public Sub ver(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        Try
            If e.Column.FieldName = "diferencia" Then
                If e.CellValue <> 0 Then
                    e.Appearance.BackColor = Color.Red
                    e.Appearance.Font = New Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold)
                Else
                    e.Appearance.BackColor = Color.PowderBlue
                    e.Appearance.Font = New Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold)
                End If

            End If
            If e.Column.FieldName = "diferencia1" Then
                If e.CellValue <> 0 Then
                    e.Appearance.BackColor = Color.Red
                    e.Appearance.Font = New Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold)
                Else
                    e.Appearance.BackColor = Color.PowderBlue
                    e.Appearance.Font = New Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold)
                End If

            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub Btn_Regresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Regresar.Click
        Try
            If Btn_Regresar.Enabled = True Then
                Dim op = 1
                Dim Id As Integer
                Try
                    Id = 0
                    GridView1.Columns.Clear()
                    Using ObjTrasp As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
                        objDataSet1 = ObjTrasp.usp_PpalProTrasp(op, Id, 0, "1900-01-01", "1900-01-01", "GE")
                    End Using
                    If objDataSet1.Tables(0).Rows.Count > 0 Then
                        Grido.DataSource = Nothing
                        Grido.DataSource = objDataSet1.Tables(0)
                        InicializaGrid()
                        blnEntraDet = True
                        Btn_Regresar.Enabled = True
                    End If
                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
                Btn_LeerSeries.Visible = False
                Call RellenaGrid()
                PBox.Image = Nothing
                PBox.Visible = False
                Btn_Regresar.Enabled = False
                blnEntraDet = False
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Pendientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Pendientes.Click
        Try
            OpcionSP = 1
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub CargarFotoArticulo(ByVal Marca, ByVal Estilon)
        'mreyes 14/Marzo/2012 07:06 p.m.
        'Glb_RutaArchivoFotos
        Try
            Dim Archivo As String = ""
            Dim NoFoto As String = "1"

            MarcaFOTO = Marca
            EstiloNFOTO = Estilon
            PBox.Visible = False
            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)

                Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Marca, Estilon, NoFoto)

                If objIO.pub_ExisteArchivo(Archivo) = True Then
                    PBox.Image = New System.Drawing.Bitmap(Archivo)
                    PBox.Visible = True
                    Exit Sub
                End If

                For i As Integer = 0 To 9
                    Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Marca, Estilon, i)
                    If objIO.pub_ExisteArchivo(Archivo) = True Then
                        PBox.Image = New System.Drawing.Bitmap(Archivo)
                        PBox.Visible = True
                        Exit Sub
                    End If
                Next

            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    'Private Sub DGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.Click
    '    If blnEntraDet = False Then Exit Sub
    '    If IsDBNull(DGrid.Rows(DGrid.CurrentRow.Index).Cells(1).Value) Then
    '    Else
    '        CargarFotoArticulo(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Marca"), GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Estilon"))
    '    End If
    'End Sub

    'Private Sub DGrid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGrid.KeyUp
    '    If blnEntraDet = False Then Exit Sub
    '    If IsDBNull(DGrid.Rows(DGrid.CurrentRow.Index).Cells(1).Value) Then
    '    Else
    '        CargarFotoArticulo(DGrid.Rows(DGrid.CurrentRow.Index).Cells("Marca").Value, DGrid.Rows(DGrid.CurrentRow.Index).Cells("Estilon").Value)
    '    End If
    'End Sub

    Private Sub PBox_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        'mreyes 03/Marzo/2012 10:01 a.m.
        Try
            Dim myForm As New frmConsultaImagen
            myForm.Txt_Estilon.Text = EstiloNFOTO
            myForm.Txt_Marca.Text = MarcaFOTO
            myForm.Txt_NoFoto.Text = 1
            myForm.ShowDialog()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub

    Private Sub PBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PBox_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
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

    Private Sub PBox_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                PBox.Location = New Point(PBox.Left + e.X - izquierda, PBox.Top + e.Y - alto)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub PBox_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Try
            PBox.Cursor = Cursors.Default
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Series_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Series.Click
        Dim myForm As New frmSeriesNoTraspaso

        myForm.ShowDialog()

        Call RellenaGrid()
    End Sub

    Private Sub Pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub

    Private Sub Btn_LeerSeries_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_LeerSeries.Click
        Dim myForm As New frmLeerTraspaso



        myForm.ShowDialog()


        If myForm.Sw_Filtro = True Then
            Btn_Regresar_Click(sender, e)
        End If
    End Sub

    Private Sub NuevoProveedorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoProveedorToolStripMenuItem.Click
        Try
            Dim myForm As New frmCatalogoTraspasosManuales
            Dim objDataSet As DataSet
            ' ir a buscar si es consulta ''
            If GridView1.RowCount = 0 Then Exit Sub

            Using objTraspasos As New BCL.BCLTraspasosSQL(GLB_ConStringSirCoSQL)
                objDataSet = objTraspasos.usp_TraerTraspasoManualEnvioDet(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "sucursal1"), "", GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "sucursal2"), 0, GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "idprotras"))
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    ' ya esta en proceso
                    myForm.Txt_IdTraspaso.Text = objDataSet.Tables(0).Rows(0).Item("idtraspaso")
                    myForm.Txt_Traspaso.Text = objDataSet.Tables(0).Rows(0).Item("traspaso")

                    myForm.Accion = 2
                Else
                    myForm.Accion = 1
                End If
            End Using

            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "descrip2") = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "descrip1") Then
                myForm.Sw_ParesUnicos = True
            End If

            myForm.Opcion = 1

            myForm.Sw_Automatico = True






            myForm.Txt_Sucursal.Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "sucursal1")
            myForm.Txt_DescripSucursal.Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "descrip1")
            myForm.Txt_IdTraspAut.Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "idprotras")
            myForm.Txt_Destino.Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "sucursal2")
            myForm.Txt_DescripDestino.Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "descrip2")
            '  myForm.DT_FechaTrasp.Value = DGrid.Rows(DGrid.CurrentRow.Index).Cells("fecha").Value
            myForm.Txt_IdMov1.Text = GLB_Idempleado

            myForm.ShowDialog()

            If myForm.Sw_Registro = True Then
                Call RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ModificarProveedorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarProveedorToolStripMenuItem.Click

        My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Hand)

    End Sub

    Private Sub Grido_Click(sender As Object, e As EventArgs) Handles Grido.Click
        If blnEntraDet = False Then Exit Sub
        If IsDBNull(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "idprotras").ToString()) Then
            'If IsDBNull(DGrid.Rows(DGrid.CurrentRow.Index).Cells(1).Value) Then
        Else
            'CargarFotoArticulo(DGrid.Rows(DGrid.CurrentRow.Index).Cells("Marca").Value, DGrid.Rows(DGrid.CurrentRow.Index).Cells("Estilon").Value)
            CargarFotoArticulo(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "marca").ToString(), GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "estilon").ToString())
        End If
    End Sub
    Private Sub dgv_Reporte_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView1.PopupMenuShowing
        Try
            Dim view As GridView = TryCast(sender, GridView)

            If e.MenuType = GridMenuType.Row Then
                Dim rowHandle As Integer = e.HitInfo.RowHandle
                e.Menu.Items.Clear()
                'e.Menu.Items.Add(CreateSubMenuRows(view, rowHandle))
                Dim item As DXMenuItem = CreateMenuItem(view, rowHandle, "Generar Traspaso", CType(SIRCO.My.Resources.store_plus, Image))

                e.Menu.Items.Add(item)
                item = CreateMenuItem(view, rowHandle, "Modificar Traspaso", CType(SIRCO.My.Resources.box_full, Image))
                item.BeginGroup = True

                item.BeginGroup = True
                e.Menu.Items.Add(item)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub OnCellMergingClick(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim item As DXMenuItem = TryCast(sender, DXMenuItem)
            Dim info As RowInfo = TryCast(item.Tag, RowInfo)
            Dim blnEsInicio As Boolean = False
            If sender.caption = "Generar Traspaso" Then
                Try
                    Dim myForm As New frmCatalogoTraspasosManuales
                    Dim objDataSet As DataSet
                    ' ir a buscar si es consulta ''
                    If GridView1.RowCount = 0 Then Exit Sub

                    Using objTraspasos As New BCL.BCLTraspasosSQL(GLB_ConStringSirCoSQL)
                        objDataSet = objTraspasos.usp_TraerTraspasoManualEnvioDet(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "sucursal1"), "", GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "sucursal2"), 0, GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "idprotras"))
                        If objDataSet.Tables(0).Rows.Count > 0 Then
                            ' ya esta en proceso
                            myForm.Txt_IdTraspaso.Text = objDataSet.Tables(0).Rows(0).Item("idtraspaso")
                            myForm.Txt_Traspaso.Text = objDataSet.Tables(0).Rows(0).Item("traspaso")

                            myForm.Accion = 2
                        Else
                            myForm.Accion = 1
                        End If
                    End Using

                    If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "descrip2") = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "descrip1") Then
                        myForm.Sw_ParesUnicos = True
                    End If

                    myForm.Opcion = 1

                    myForm.Sw_Automatico = True






                    myForm.Txt_Sucursal.Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "sucursal1")
                    myForm.Txt_DescripSucursal.Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "descrip1")
                    myForm.Txt_IdTraspAut.Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "idprotras")
                    myForm.Txt_Destino.Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "sucursal2")
                    myForm.Txt_DescripDestino.Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "descrip2")
                    '  myForm.DT_FechaTrasp.Value = DGrid.Rows(DGrid.CurrentRow.Index).Cells("fecha").Value
                    myForm.Txt_IdMov1.Text = GLB_Idempleado

                    myForm.ShowDialog()

                    If myForm.Sw_Registro = True Then
                        Call RellenaGrid()
                    End If
                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            ElseIf sender.caption = "Modificar Traspaso" Then
                My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Hand)

            End If

        Catch ExceptionErr As Exception
            Me.Cursor = DefaultCursor
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Function CreateMenuItem(ByVal view As GridView, ByVal rowHandle As Integer, ByVal Nombre As String, ByVal Imagen As Image) As DXMenuItem
        Dim im As New Bitmap(New Bitmap(Imagen), 16, 16)
        Dim checkItem As DXMenuItem = New DXMenuItem(Nombre, New EventHandler(AddressOf OnCellMergingClick))
        checkItem.Tag = New RowInfo(view, rowHandle)
        checkItem.ImageOptions.Image = im
        Return checkItem
    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs)
        Call RellenaGrid()
    End Sub

    Private Sub Pnl_Grid_Paint(sender As Object, e As PaintEventArgs) Handles Pnl_Grid.Paint

    End Sub
End Class
