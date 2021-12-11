Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid
Public Class frmPpalPendientes

    'mreyes    20/Marzo/2018



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
    Private Sub GridView1_RowCellStyle(ByVal sender As Object, ByVal e As RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        Try
            Dim View As GridView = sender

            Dim Pos As Integer = 0
            Dim Pos1 As Integer = 0
            Dim Nombre As String = ""

            Pos = InStr(LCase(e.Column.FieldName), "descripcion")
            Pos1 = InStr(LCase(e.Column.FieldName), "fotos")

            Nombre = LCase(e.Column.Name)


            If Pos > 0 Or Pos1 > 0 Then
                Dim TipoPago As String = (View.GetRowCellDisplayText(e.RowHandle, e.Column))
                If TipoPago = "SIN FOTOS" Or TipoPago = "SIN DESCRIPCIÓN" Then
                    'e.Appearance.BackColor = Color.Red
                    'e.Appearance.BackColor2 = Color.LightCyan

                    e.Appearance.BackColor = Color.Yellow
                    e.Appearance.FontStyleDelta = FontStyle.Bold
                End If


                If TipoPago = "CON FOTOS" Or TipoPago = "CON DESCRIPCIÓN" Then
                    'e.Appearance.BackColor = Color.Red
                    'e.Appearance.BackColor2 = Color.LightCyan

                    e.Appearance.BackColor = Color.LightCoral
                    e.Appearance.FontStyleDelta = FontStyle.Bold
                End If
            End If
            'Dim concepto As String = (View.GetRowCellDisplayText(e.RowHandle, View.Columns("concepto")))
            'If concepto = "UTILIDAD BRUTA" Then
            '    Pos = InStr(LCase(e.Column.FieldName), "precio")
            '    If Pos > 0 Then

            '    End If

            'End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try


    End Sub

    Private Sub RellenaGrid()
        'mreyes 26/Octubre/2017     04:55 p.m.

        DGrid1.Visible = False

        Using objTrasp As New BCL.BCLVentaEnLinea(GLB_ConStringSirCoVentaEnLineaSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                Sw_Load = False
                'DGrid.ReadOnly = True
                ' GridControl.DataSource = Nothing

                objDataSet = objTrasp.usp_PpalProductsPendientes(GLB_Usuario)

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


    Private Sub Btn_Salir_Click(sender As Object, e As EventArgs) Handles Btn_Salir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub frmPpalVencidosDias_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub




    Private Sub Btn_FTP_Click(sender As Object, e As EventArgs)
        My.Computer.Network.UploadFile("c:\gestoria.xls", "ftp://home587140532.1and1-data.host/gestoria.xls", "u81839252-credito", "ZT_Sirco33")
    End Sub

    Private Sub Btn_Asignar_Click(sender As Object, e As EventArgs)
        Try
            Dim Idempleado As Integer = 0
            Dim Gestor As String = ""
            Dim myForm As New frmConsultaEmpleado

            myForm.Text = "Gestores"
            myForm.Estatus = "A"
            myForm.Pnl_Edicion.Visible = False
            myForm.Height = 200
            myForm.IdDepto = 5
            myForm.IdPuesto = 30



            myForm.ShowDialog()
            Idempleado = Val(myForm.Campo)
            Gestor = Idempleado & "-" & myForm.Campo1


            '''----
            Dim Rows As New ArrayList()
            ' Add the selected rows to the list.
            Dim I As Integer
            For I = 0 To GridView1.SelectedRowsCount() - 1
                If (GridView1.GetSelectedRows()(I) >= 0) Then
                    GridView1.SetRowCellValue(GridView1.GetSelectedRows()(I), "Campo4", Gestor)
                    'GridView1.SetRowCellValue(I, "Campo4", Gestor)
                End If
            Next

            '' Guardar el gestor asignado, por la fecha.

            'Using objTrasp As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
            '    If objTrasp.usp_CapturaProyeccionReciboL1(1, Linea, L1, Recibo1, Recibo2, Recibo3, Recibo4, Recibo5, Recibo6, Recibo7, Recibo8, Recibo9, Recibo10, Recibo11, Recibo12) Then

            '    End If
            'End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid1_DoubleClick(sender As Object, e As EventArgs) Handles DGrid1.DoubleClick
        Try

            Dim Myform As New frmProducts
            Dim Renglon As Point = DGrid1.PointToClient(Control.MousePosition)
            Dim info As GridHitInfo = GridView1.CalcHitInfo(Renglon)

            Dim Renglon1 As Integer = info.RowHandle

            Dim Marca As String = GridView1.GetRowCellValue(Renglon1, "marca")
            ' Myform.Accion = 1
            Myform.Txt_Marca.Text = Mid(Marca, 1, 3)
            Myform.Txt_DescripMarca.Text = Mid(Marca, 5)

            Myform.Txt_Modelo.Text = GridView1.GetRowCellValue(Renglon1, "modelo")
            Myform.Txt_Titulo.Text = GridView1.GetRowCellValue(Renglon1, "name")
            Myform.Txt_EstiloF.Text = GridView1.GetRowCellValue(Renglon1, "estilof")
            Myform.Lbl_Estructura.Text = GridView1.GetRowCellValue(Renglon1, "estructura")
            Myform.Cliente_Id = GridView1.GetRowCellValue(Renglon1, "cliente_id")
            Myform.StartPosition = FormStartPosition.CenterScreen
            Myform.ShowDialog()
            If GLB_RefrescarPedido = True Then
                Call RellenaGrid()
            End If



        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub




    Sub InicializaGrid()
        Try
            'view.GetRowCellValue(e.RowHandle1, e.Column)
            ' GridView1.Columns(I).OptionsColumn.AllowMerge = True
            'GridView1.GetRowCellValue(1, 0) '



            GridView1.Columns(0).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(1).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            GridView1.Columns(1).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(1).AppearanceHeader.Font = New Font(GridView1.Columns(1).AppearanceCell.Font, FontStyle.Bold)

            GridView1.Columns(2).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(2).AppearanceHeader.Font = New Font(GridView1.Columns(2).AppearanceCell.Font, FontStyle.Bold)

            GridView1.Columns(0).Visible = False
            GridView1.Columns(1).Caption = "División"
            GridView1.Columns(2).Caption = "Departamento"
            GridView1.Columns(3).Caption = "Línea"
            GridView1.Columns(4).Caption = "L1"
            GridView1.Columns(5).Caption = "Marca"
            GridView1.Columns(6).Caption = "Modelo"
            GridView1.Columns(7).Caption = "EstiloF"
            GridView1.Columns(8).Caption = "Título"
            GridView1.Columns(9).Caption = "Estructura"

            GridView1.Columns(10).Caption = "Descripción"
            GridView1.Columns(11).Caption = "Fotos"


            GridView1.Columns(9).Visible = False

            GridView1.OptionsView.ColumnAutoWidth = False
            GridView1.OptionsView.BestFitMaxRowCount = -1
            GridView1.BestFitColumns()


            ' Call Colorear()
            GridView1.FixedLineWidth = 2
            GridView1.Columns(0).Fixed = 0
            GridView1.Columns(1).Fixed = 1
            GridView1.Columns(2).Fixed = 1
            GridView1.Columns(3).Fixed = 1
            GridView1.Columns(4).Fixed = 1


            GridView1.Columns(0).OptionsColumn.ReadOnly = True
            GridView1.Columns(1).OptionsColumn.ReadOnly = True
            GridView1.Columns(2).OptionsColumn.ReadOnly = True
            GridView1.Columns(3).OptionsColumn.ReadOnly = True
            GridView1.Columns(4).OptionsColumn.ReadOnly = True
            GridView1.Columns(5).OptionsColumn.ReadOnly = True
            GridView1.Columns(6).OptionsColumn.ReadOnly = True
            GridView1.Columns(7).OptionsColumn.ReadOnly = True
            GridView1.Columns(8).OptionsColumn.ReadOnly = True

            GridView1.Columns(9).OptionsColumn.ReadOnly = True


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Refrescar_Click(sender As Object, e As EventArgs) Handles Btn_Refrescar.Click
        Call RellenaGrid()
    End Sub

    Private Sub DGrid1_Click(sender As Object, e As EventArgs) Handles DGrid1.Click
        Try


            Dim Renglon As Point = DGrid1.PointToClient(Control.MousePosition)
            Dim info As GridHitInfo = GridView1.CalcHitInfo(Renglon)
            Dim Marca As String = ""
            Dim Modelo As String = ""
            Dim Renglon1 As Integer = info.RowHandle


            Marca = Mid(GridView1.GetRowCellValue(Renglon1, "marca"), 1, 3)
            Modelo = GridView1.GetRowCellValue(Renglon1, "modelo")

            CargarFotoArticulo(Marca, Modelo)

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

                Archivo = objIO.pub_ArmarNombreFotoEstilo(If(GLB_CveSucursal <> "", GLB_RutaArchivoFotosLocal, GLB_RutaArchivoFotos), Marca, Estilon, NoFoto)

                If objIO.pub_ExisteArchivo(Archivo) = True Then
                    PBox.Image = New System.Drawing.Bitmap(Archivo)
                    PBox.Visible = True
                    Exit Sub


                End If

                For i As Integer = 1 To 9
                    Archivo = objIO.pub_ArmarNombreFotoEstilo(If(GLB_CveSucursal <> "", GLB_RutaArchivoFotosLocal, GLB_RutaArchivoFotos), Marca, Estilon, i)
                    If objIO.pub_ExisteArchivo(Archivo) = True Then
                        PBox.Image = New System.Drawing.Bitmap(Archivo)
                        PBox.Visible = True
                        Exit Sub

                    Else
                        Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Marca, Estilon, i)
                        If objIO.pub_ExisteArchivo(Archivo) = True Then
                            PBox.Image = New System.Drawing.Bitmap(Archivo)
                            PBox.Visible = True
                            Exit Sub
                        End If

                    End If
                Next

            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub PBox_Click(sender As Object, e As EventArgs) Handles PBox.Click

    End Sub

    Private Sub DGrid1_KeyUp(sender As Object, e As KeyEventArgs) Handles DGrid1.KeyUp
        Try


            Dim Renglon As Point = DGrid1.PointToClient(Control.MousePosition)
            Dim info As GridHitInfo = GridView1.CalcHitInfo(Renglon)
            Dim Marca As String = ""
            Dim Modelo As String = ""
            Dim Renglon1 As Integer = info.RowHandle


            Marca = Mid(GridView1.GetRowCellValue(Renglon1, "marca"), 1, 3)
            Modelo = GridView1.GetRowCellValue(Renglon1, "modelo")

            CargarFotoArticulo(Marca, Modelo)

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
End Class