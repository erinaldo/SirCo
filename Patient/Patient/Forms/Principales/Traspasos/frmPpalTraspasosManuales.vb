Public Class frmPpalTraspasosManuales


    Private objDataSet As Data.DataSet
    Private objDataSet1 As Data.DataSet 'Segundo Nivel
    Private objDataSetEmp As Data.DataSet
    Private objDataSet2 As Data.DataSet

    Dim IdTraspasoIniB As Integer = 0
    Dim IdTraspasoFinB As Integer = 0
    Dim SucursalB As String = ""
    Dim SucurdesB As String = ""
    Dim SucuroriB As String = ""
    Dim TraspasoIniB As String = ""
    Dim TraspasoFinB As String = ""
    Dim ReferencB As String = ""
    Dim EstatusB As String = ""
    Dim FechaInib As String = ""
    Dim FechaFinb As String = ""
    Dim FechaCanInib As String = ""
    Dim FechaCanFinb As String = ""


    Dim Sw_Load As Boolean = True
    Dim Sw_NoRegistros As Boolean = False
    Dim Sw_Pintar As Boolean = False
    Public Opcion As Integer = 0  '1 = Envío,  2 = Recibo,  3 = Dev Envío, 4 = Dev Recibo
    'Public OpcionSP As Integer = 0
    Dim MarcaFOTO As String = ""
    Dim EstiloNFOTO As String = ""
    Dim blnEntraDet As Boolean = False
    Dim Plaza As Integer = 1

    Private Sub frmPpalPpalTraspasosManuales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Opcion = 1 Then
            Me.Text = "Traspasos Manuales (Envío)"
        ElseIf Opcion = 2 Then
            Me.Text = "Traspasos Manuales (Recibo)"
        ElseIf Opcion = 3 Then
            Me.Text = "Traspasos De Devolución (Envío)"
        ElseIf Opcion = 4 Then
            Me.Text = "Traspasos Manuales (Recibo)"
        End If

        Call GenerarToolTip()
        Sw_Pintar = True
        Sw_Load = True
        Call LimpiarBusqueda()
        Call RellenaGrid()

        If Opcion = 2 Or Opcion = 4 Then
            Btn_Modificar.Visible = False
            Btn_Cancelar.Visible = False
            Btn_Aplicar.Visible = False
        End If
        If GLB_Idempleado = 132 Or GLB_Idempleado = 226 Then
            Btn_Cancelar.Visible = True
        Else
            Btn_Cancelar.Visible = False
        End If

        If Opcion = 1 Then
            If GLB_Sw_Costos = False And (GLB_CveSucursal <> "15" And GLB_CveSucursal <> "") Then
                Btn_Nuevo.Visible = False
            End If
            If GLB_IdDeptoEmpleado = 3 And (GLB_IdPuestoEmpleado = 5 Or GLB_IdPuestoEmpleado = 6) Then
                Btn_Nuevo.Visible = True
            End If
        End If

    End Sub

    Private Sub frmPpalPpalDetFactProv_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        'If Sw_NoRegistros = False Then Exit Sub

        'InicializaGrid()

        If Sw_NoRegistros = False Then
            Sw_Load = False
            Exit Sub
        End If

        If Sw_Load = True Then
            Sw_Load = False
            InicializaGrid()
            'AgregarColumna()
            '    Call BarrerGrid()
        End If
       
    End Sub

    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Filtro, "Búsqueda Avanzada")
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
            ToolTip.SetToolTip(Btn_Cancelar, "Cancelar Traspaso")
            ToolTip.SetToolTip(Btn_Modificar, "Modificar Traspaso")
            ToolTip.SetToolTip(Btn_Nuevo, "Nuevo Traspaso")
            ToolTip.SetToolTip(Btn_Aplicar, "Aplicar Traspaso")
            ToolTip.SetToolTip(Btn_Consultar, "Consultar Traspaso")

            ToolTip.SetToolTip(Btn_Salir, "Salir")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub LimpiarBusqueda()
        If GLB_CveSucursal = "01" Or GLB_CveSucursal = "02" Or GLB_CveSucursal = "06" Or GLB_CveSucursal = "07" Or GLB_CveSucursal = "08" Or GLB_CveSucursal = "11" Or GLB_CveSucursal = "15" Then
            SucursalB = GLB_CveSucursal
        Else
            SucursalB = ""
        End If

        TraspasoIniB = ""
        TraspasoFinB = ""

        If Opcion = 1 Or Opcion = 3 Then
            EstatusB = "CA"
        ElseIf Opcion = 2 Or Opcion = 4 Then
            EstatusB = "AP"
        End If


        FechaInib = Format(Now.Add(New TimeSpan(-1, 0, 0, 0)), "yyyy-MM-dd")
        FechaFinb = Format(Now.Date, "yyyy-MM-dd")

        FechaCanInib = "1900-01-01"
        FechaCanFinb = "1900-01-01"
    End Sub

    Private Sub RellenaGrid()
        'mreyes 09/Diciembre/2016   10:56 a.m.
        Using objTrasp As New BCL.BCLTraspasosSQL(GLB_ConStringSirCoSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                'DGrid.ReadOnly = True
                DGrid.DataSource = Nothing
                DGrid.Visible = False

                If Sw_Load = True Then
                    ' Sw_Load = False 
                Else
                    If Sw_NoRegistros = True Then
                        DGrid.Columns.Remove("Selec")
                    End If
                End If

                If Opcion = 1 Then 'Envío
                    objDataSet = objTrasp.usp_PpalTraspasosManualOri(SucursalB, TraspasoIniB, TraspasoFinB, SucurdesB, FechaInib, FechaFinb, EstatusB, IdTraspasoIniB, IdTraspasoFinB, FechaCanInib, FechaCanFinb)
                ElseIf Opcion = 2 Then 'Recibo
                    objDataSet = objTrasp.usp_PpalTraspasosManualDes(SucursalB, TraspasoIniB, TraspasoFinB, SucuroriB, ReferencB, FechaInib, FechaFinb, EstatusB, IdTraspasoIniB, IdTraspasoFinB, FechaCanInib, FechaCanFinb)
                ElseIf Opcion = 3 Then 'envio dev
                    objDataSet = objTrasp.usp_PpalTraspasosDevOri(SucursalB, TraspasoIniB, TraspasoFinB, SucurdesB, FechaInib, FechaFinb, EstatusB, IdTraspasoIniB, IdTraspasoFinB, FechaCanInib, FechaCanFinb)
                ElseIf Opcion = 4 Then 'Recibo dev
                    objDataSet = objTrasp.usp_PpalTraspasosDevDes(SucursalB, TraspasoIniB, TraspasoFinB, SucuroriB, ReferencB, FechaInib, FechaFinb, EstatusB, IdTraspasoIniB, IdTraspasoFinB, FechaCanInib, FechaCanFinb)
                End If


               
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section 

                    DGrid.DataSource = objDataSet.Tables(0)
                    If Sw_Load = False Then
                        InicializaGrid()
                    End If
                    'LimpiarBusqueda()
                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True
                    Sw_NoRegistros = True
                    Sw_Pintar = True

                Else
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron registros que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                End If
                Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()
                DGrid.Visible = True
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Sub InicializaGrid()
        Try

            'Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)

            'DGrid.DataSource = dt
            DGrid.Columns("observa").Visible = False
            DGrid.Columns("idprotras").Visible = False

            If Opcion = 1 Or Opcion = 3 Then 'Envio

                Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
                Dim row As DataRow = dt.NewRow()

                row(2) = "Totales"
                row(7) = pub_SumarColumnaGrid(DGrid, 7, DGrid.RowCount - 1)
                row(8) = pub_SumarColumnaGrid(DGrid, 8, DGrid.RowCount - 1)
                row(9) = pub_SumarColumnaGrid(DGrid, 9, DGrid.RowCount - 1)

                dt.Rows.InsertAt(row, 0)

                DGrid.DataSource = dt

                DGrid.RowHeadersVisible = False
                DGrid.Columns(0).HeaderText = "ID"
                DGrid.Columns(1).HeaderText = "suc"
                DGrid.Columns(2).HeaderText = "Sucursal"
                DGrid.Columns(3).HeaderText = "Trapaso"

                DGrid.Columns(4).HeaderText = "Estatus"
                DGrid.Columns(5).HeaderText = "SucDes"
                DGrid.Columns(6).HeaderText = "Destino"
                DGrid.Columns(7).HeaderText = "Pares"
                DGrid.Columns(8).HeaderText = "Costo"
                DGrid.Columns(9).HeaderText = "Precio"
                DGrid.Columns(10).HeaderText = "Envia"
                DGrid.Columns(11).HeaderText = "Transporta"
                DGrid.Columns(12).HeaderText = "Usuario"
                DGrid.Columns(13).HeaderText = "Fecha"

                'DGrid.Columns(0).Visible = False
                DGrid.Columns(1).Visible = False
                DGrid.Columns(5).Visible = False

                If GLB_CveSucursal = "01" Or GLB_CveSucursal = "02" Or GLB_CveSucursal = "06" Or GLB_CveSucursal = "07" Or GLB_CveSucursal = "08" Or GLB_CveSucursal = "15" Then
                    DGrid.Columns(8).Visible = False
                End If

                DGrid.Columns(8).DefaultCellStyle.Format = "c"
                DGrid.Columns(9).DefaultCellStyle.Format = "c"

                DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


                DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

                DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                DGrid.Columns(13).DisplayIndex = 5

            ElseIf Opcion = 2 Or Opcion = 4 Then 'Recibo

                Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
                Dim row As DataRow = dt.NewRow()

                row(2) = "Totales"
                row(8) = pub_SumarColumnaGrid(DGrid, 8, DGrid.RowCount - 1)
                row(9) = pub_SumarColumnaGrid(DGrid, 9, DGrid.RowCount - 1)
                row(10) = pub_SumarColumnaGrid(DGrid, 10, DGrid.RowCount - 1)

                dt.Rows.InsertAt(row, 0)

                DGrid.DataSource = dt

                DGrid.RowHeadersVisible = False
                DGrid.Columns(0).HeaderText = "ID"
                DGrid.Columns(1).HeaderText = "suc"
                DGrid.Columns(2).HeaderText = "Sucursal"
                DGrid.Columns(3).HeaderText = "Trapaso"
                DGrid.Columns(4).HeaderText = "Estatus"
                DGrid.Columns(5).HeaderText = "SucOri"
                DGrid.Columns(6).HeaderText = "Referencia"
                DGrid.Columns(7).HeaderText = "Origen"
                DGrid.Columns(8).HeaderText = "Pares"
                DGrid.Columns(9).HeaderText = "Costo"
                DGrid.Columns(10).HeaderText = "Precio"
                DGrid.Columns(11).HeaderText = "Recibe"
                DGrid.Columns(12).HeaderText = "Usuario"
                DGrid.Columns(13).HeaderText = "Fecha"
                DGrid.Columns(14).HeaderText = "IdTraspAut"
                'DGrid.Columns(0).Visible = False
                DGrid.Columns(1).Visible = False
                DGrid.Columns(5).Visible = False

                If GLB_CveSucursal = "01" Or GLB_CveSucursal = "02" Or GLB_CveSucursal = "06" Or GLB_CveSucursal = "07" Or GLB_CveSucursal = "08" Or GLB_CveSucursal = "15" Then
                    DGrid.Columns(9).Visible = False
                End If

                DGrid.Columns(9).DefaultCellStyle.Format = "c"
                DGrid.Columns(10).DefaultCellStyle.Format = "c"

                DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            End If

            For i As Integer = 0 To DGrid.Rows.Count - 1
                For j As Integer = 0 To DGrid.Columns.Count - 1
                    DGrid.Columns(j).ReadOnly = True
                Next
            Next

            AgregarColumna()

            DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            DGrid.Columns(13).DisplayIndex = 5
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub AgregarColumna()
        Dim colImagen As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        colImagen.Name = "Selec"
        colImagen.HeaderText = "Selec"
        colImagen.DisplayIndex = 15
        colImagen.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        colImagen.CellTemplate = New DataGridViewCheckBoxCell()
        ' añadir columna de imagen a la coleccion del grid 
        DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        ''DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DGrid.Columns.Add(colImagen)
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

    Private Sub frmPpalPpalDetFactProv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Filtro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        Try
            Dim myForm As New frmFiltrosTraspasosManuales
            myForm.Opcion = Opcion

            If Opcion = 1 Then 'ENVIO

                myForm.Txt_Folio1.Text = TraspasoIniB
                myForm.Txt_Folio2.Text = TraspasoFinB

                myForm.Txt_Id1.Text = IdTraspasoIniB.ToString
                myForm.Txt_Id2.Text = IdTraspasoFinB.ToString

                myForm.Txt_Suc1.Text = SucursalB
                myForm.Txt_Suc2.Text = SucurdesB
                myForm.Lbl_S1.Text = "Sucursal"
                myForm.Lbl_S2.Text = "Destino"

                myForm.Lbl_Ref.Visible = False
                myForm.Txt_Referenc.Visible = False

                If FechaInib <> "1900-01-01" Then
                    myForm.Chk_FechaTraspaso.Checked = True
                    myForm.DTPicker2.Value = FechaInib
                    myForm.DTPicker3.Value = FechaFinb
                End If

                If FechaCanInib <> "1900-01-01" Then
                    myForm.Chk_FechaCancela.Checked = True
                    myForm.DTC1.Value = FechaCanInib
                    myForm.DTC2.Value = FechaCanFinb
                End If

            ElseIf Opcion = 2 Then 'RECEPCION

                myForm.Txt_Folio1.Text = TraspasoIniB
                myForm.Txt_Folio2.Text = TraspasoFinB

                myForm.Txt_Id1.Text = IdTraspasoIniB.ToString
                myForm.Txt_Id2.Text = IdTraspasoFinB.ToString

                myForm.Txt_Suc1.Text = SucursalB
                myForm.Txt_Suc2.Text = SucuroriB
                myForm.Txt_Referenc.Text = ReferencB

                myForm.Lbl_S1.Text = "Recibe"
                myForm.Lbl_S2.Text = "Orígen"

                myForm.Lbl_Ref.Visible = True
                myForm.Txt_Referenc.Visible = True

            End If

            If EstatusB = "CA" Then
                myForm.Cbo_Estatus.Text = "CAPTURA"
            ElseIf EstatusB = "AP" Then
                myForm.Cbo_Estatus.Text = "APLICADO"
            ElseIf EstatusB = "RE" Then
                myForm.Cbo_Estatus.Text = "RECIBIDO"
            ElseIf EstatusB = "PA" Then
                myForm.Cbo_Estatus.Text = "PARCIAL"
            ElseIf EstatusB = "ZC" Then
                myForm.Cbo_Estatus.Text = "CANCELADO"
            ElseIf EstatusB = "" Then
                myForm.Cbo_Estatus.Text = ""
            End If


            If FechaInib <> "1900-01-01" Then
                myForm.Chk_FechaTraspaso.Checked = True
                myForm.DTPicker2.Value = FechaInib
                myForm.DTPicker3.Value = FechaFinb
            End If


            If FechaCanInib <> "1900-01-01" Then
                myForm.Chk_FechaCancela.Checked = True
                myForm.DTC1.Value = FechaCanInib
                myForm.DTC2.Value = FechaCanFinb
            End If

            myForm.ShowDialog()


            If Opcion = 1 Then 'ENVIO
                TraspasoIniB = myForm.Txt_Folio1.Text
                TraspasoFinB = myForm.Txt_Folio2.Text

                If myForm.Txt_Id1.Text <> "" Then
                    IdTraspasoIniB = CInt(myForm.Txt_Id1.Text)
                End If
                If myForm.Txt_Id2.Text <> "" Then
                    IdTraspasoFinB = CInt(myForm.Txt_Id2.Text)
                End If


                SucursalB = myForm.Txt_Suc1.Text
                SucurdesB = myForm.Txt_Suc2.Text

                If myForm.Chk_FechaTraspaso.Checked = True Then
                    FechaInib = Format(myForm.DTPicker2.Value, "yyyy-MM-dd")
                    FechaFinb = Format(myForm.DTPicker3.Value, "yyyy-MM-dd")
                Else
                    FechaInib = "1900-01-01"
                    FechaFinb = "1900-01-01"
                End If


                If myForm.Chk_FechaCancela.Checked = True Then
                    FechaCanInib = Format(myForm.DTC1.Value, "yyyy-MM-dd")
                    FechaCanFinb = Format(myForm.DTC2.Value, "yyyy-MM-dd")
                Else
                    FechaCanInib = "1900-01-01"
                    FechaCanFinb = "1900-01-01"
                End If
            ElseIf Opcion = 2 Then 'RECEPCION

                TraspasoIniB = myForm.Txt_Folio1.Text
                TraspasoFinB = myForm.Txt_Folio2.Text

                If myForm.Txt_Id1.Text <> "" Then
                    IdTraspasoIniB = CInt(myForm.Txt_Id1.Text)
                End If
                If myForm.Txt_Id2.Text <> "" Then
                    IdTraspasoFinB = CInt(myForm.Txt_Id2.Text)
                End If

                SucursalB = myForm.Txt_Suc1.Text
                SucuroriB = myForm.Txt_Suc2.Text
                ReferencB = myForm.Txt_Referenc.Text

                If myForm.Chk_FechaTraspaso.Checked = True Then
                    FechaInib = Format(myForm.DTPicker2.Value, "yyyy-MM-dd")
                    FechaFinb = Format(myForm.DTPicker3.Value, "yyyy-MM-dd")
                Else
                    FechaInib = "1900-01-01"
                    FechaFinb = "1900-01-01"
                End If

                If myForm.Chk_FechaCancela.Checked = True Then
                    FechaCanInib = Format(myForm.DTC1.Value, "yyyy-MM-dd")
                    FechaCanFinb = Format(myForm.DTC2.Value, "yyyy-MM-dd")
                Else
                    FechaCanInib = "1900-01-01"
                    FechaCanFinb = "1900-01-01"
                End If
            End If

            If myForm.Cbo_Estatus.Text = "CAPTURA" Then
                EstatusB = "CA"
            ElseIf myForm.Cbo_Estatus.Text = "APLICADO" Then
                EstatusB = "AP"
            ElseIf myForm.Cbo_Estatus.Text = "CANCELADO" Then
                EstatusB = "ZC"
            ElseIf myForm.Cbo_Estatus.Text = "RECIBIDO" Then
                EstatusB = "RE"
            ElseIf myForm.Cbo_Estatus.Text = "PARCIAL" Then
                EstatusB = "PA"
            ElseIf myForm.Cbo_Estatus.Text = "" Then
                EstatusB = ""
            End If

            If myForm.Sw_Filtro = True Then
                Call RellenaGrid()
            End If
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

    Private Sub DGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.Click
        If blnEntraDet = False Then Exit Sub
        If IsDBNull(DGrid.Rows(DGrid.CurrentRow.Index).Cells(1).Value) Then
        Else
            CargarFotoArticulo(DGrid.Rows(DGrid.CurrentRow.Index).Cells("Marca").Value, DGrid.Rows(DGrid.CurrentRow.Index).Cells("Estilon").Value)
        End If
    End Sub

    Private Sub Btn_Nuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Nuevo.Click
        Try
            Dim myForm As New frmCatalogoTraspasosManuales

            myForm.Opcion = Opcion
            myForm.Accion = 1

            If Opcion = 1 Or Opcion = 3 Then
                myForm.Txt_IdMov1.Text = GLB_Idempleado
            ElseIf Opcion = 2 Or Opcion = 4 Then
                myForm.Txt_IdMov2.Text = GLB_Idempleado
            End If

            myForm.ShowDialog()

            If myForm.Sw_Registro = True Then
                Call RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Consultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Consultar.Click
        Try
            Dim myForm As New frmCatalogoTraspasosManuales

            myForm.Opcion = Opcion
            myForm.Accion = 4
            If DGrid.Rows.Count = 0 Then Exit Sub

            If Opcion = 1 Or Opcion = 3 Then
                myForm.Txt_Sucursal.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("sucursal").Value
                myForm.Txt_DescripSucursal.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("descrip").Value
                myForm.Txt_Traspaso.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("traspaso").Value
                myForm.Txt_Destino.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("sucurdes").Value
                myForm.Txt_DescripDestino.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("descrip1").Value
                myForm.DT_FechaTrasp.Value = DGrid.Rows(DGrid.CurrentRow.Index).Cells("fecha").Value
                myForm.Txt_Estatus.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("status").Value
                myForm.Txt_IdTraspaso.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idtraspaso").Value
            ElseIf Opcion = 2 Or Opcion = 4 Then
                myForm.Txt_Traspaso.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("traspaso").Value
                myForm.Txt_Sucursal.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("sucursal").Value
                myForm.Txt_DescripSucursal.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("descrip").Value
                myForm.Txt_Referencia.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("referenc").Value
                myForm.Txt_Destino.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("sucurori").Value
                myForm.Txt_DescripDestino.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("descrip1").Value
                myForm.DT_FechaTrasp.Value = DGrid.Rows(DGrid.CurrentRow.Index).Cells("fecha").Value
                myForm.Txt_Estatus.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("status").Value
                myForm.Txt_IdTraspaso.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idtraspaso").Value
            End If

            myForm.ShowDialog()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Modificar.Click
        Try
            Dim myForm As New frmCatalogoTraspasosManuales

            myForm.Opcion = Opcion
            myForm.Accion = 2


            If DGrid.Rows.Count = 0 Then Exit Sub
            If DGrid.Rows(DGrid.CurrentRow.Index).Cells("status").Value = "APLICADO" Then
                MsgBox("Solo se pueden modificar traspasos con estatus de CAPTURA.", MsgBoxStyle.Exclamation, "Aviso")
                Exit Sub
            End If

            If Opcion = 1 Or Opcion = 3 Then
                myForm.Txt_Sucursal.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("sucursal").Value
                myForm.Txt_DescripSucursal.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("descrip").Value
                myForm.Txt_Traspaso.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("traspaso").Value
                myForm.Txt_Destino.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("sucurdes").Value
                myForm.Txt_DescripDestino.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("descrip1").Value
                myForm.DT_FechaTrasp.Value = DGrid.Rows(DGrid.CurrentRow.Index).Cells("fecha").Value
                myForm.Txt_Estatus.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("status").Value
            ElseIf Opcion = 2 Or Opcion = 4 Then
                myForm.Txt_Traspaso.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("traspaso").Value
                myForm.Txt_Sucursal.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("sucursal").Value
                myForm.Txt_DescripSucursal.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("descrip").Value
                myForm.Txt_Referencia.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("referenc").Value
                myForm.Txt_Destino.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("sucurori").Value
                myForm.Txt_DescripDestino.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("descrip1").Value
                myForm.DT_FechaTrasp.Value = DGrid.Rows(DGrid.CurrentRow.Index).Cells("fecha").Value
                myForm.Txt_Estatus.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("status").Value
            End If

            myForm.ShowDialog()

            If myForm.Sw_Registro = True Then
                Call RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click

        Dim intContador As Integer = 0
        Dim intContadorTR As Integer = 0

        Dim Traspaso As String = ""
        Dim Sucursal As String = ""
        Dim Sucurdes As String = ""
        Dim Serie As String = ""

        Try
            If DGrid.Rows.Count = 0 Then Exit Sub
            'valida que este seleccionado por lo menos un registro
            For Each row As DataGridViewRow In DGrid.Rows
                If row.Cells("Selec").Value = True Then
                    intContador += 1
                End If
            Next
            If intContador = 0 Then
                MsgBox("No se selecciono ningun Registro", MsgBoxStyle.OkOnly, "Aviso")
                Exit Sub
            End If

            If MsgBox("Esta seguro de Cancelar los traspasos seleccionados?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub
            For i As Integer = 1 To DGrid.Rows.Count - 1
                If DGrid.Rows(i).Cells("Selec").Value = True And (DGrid.Rows(i).Cells("status").Value = "CAPTURA" Or _
                DGrid.Rows(i).Cells("status").Value = "APLICADO") Then

                    Traspaso = DGrid.Rows(i).Cells("traspaso").Value
                    Sucurdes = DGrid.Rows(i).Cells("sucurdes").Value
                    Sucursal = DGrid.Rows(i).Cells("sucursal").Value


                    If DGrid.Rows(DGrid.CurrentRow.Index).Cells("status").Value = "APLICADO" Then
                        Using objTraspasos As New BCL.BCLTraspasosSQL(GLB_ConStringSirCoSQL)
                            If Opcion = 1 Or Opcion = 3 Then 'Envío
                                objDataSet = objTraspasos.usp_TraerTraspasoManualEnvioDet(Sucursal, Traspaso, Sucurdes, 0, 0)
                                If objDataSet.Tables(0).Rows.Count > 0 Then

                                    For n As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                                        Serie = objDataSet.Tables(0).Rows(n).Item("serie")
                                        Using objTraspasos1 As New BCL.BCLTraspasos(GLB_ConStringCipSis)
                                            objTraspasos1.usp_ActualizarSerie(Serie, Sucursal, "AC", Sucursal)
                                        End Using
                                    Next

                                End If
                            End If
                        End Using
                    End If

                    Using objTraspasos As New BCL.BCLTraspasosSQL(GLB_ConStringSirCoSQL)
                        If Opcion = 1 Or Opcion = 3 Then
                            objTraspasos.usp_ActualizarEstatusTraspaso(1, Sucursal, Traspaso, "ZC", 0, GLB_Idempleado)
                        ElseIf Opcion = 2 Or Opcion = 4 Then
                            objTraspasos.usp_ActualizarEstatusTraspaso(1, Sucursal, Traspaso, "ZC", 0, GLB_Idempleado)
                        End If
                    End Using
                    intContadorTR += 1
                End If
            Next
            If intContadorTR = 0 Then
                MsgBox("Solo puede cancelar Traspasos con estatus de CAPTURA o APLICADO.", MsgBoxStyle.OkOnly, "Aviso")
                Exit Sub
            Else
                MsgBox("Proceso Terminado", MsgBoxStyle.Information, "Confirmación")
            End If

            Call RellenaGrid()
            Me.Cursor = Cursors.Default
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Aplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aplicar.Click
        Dim intContador As Integer = 0
        Dim intContadorTR As Integer = 0
        Dim intContadorBA As Integer = 0
        Dim objDataSetAux As Data.DataSet
        Dim objDataSet1 As Data.DataSet

        Dim Traspaso As String = ""
        Dim Sucursal As String = ""
        Dim Sucurdes As String = ""
        Dim Serie As String = ""
        Dim IdTransporta As Integer = 0

        '' Dim myForm As New frmTransportaTrasp

       
        Try
            If DGrid.Rows.Count = 0 Then Exit Sub
            'valida que este seleccionado por lo menos un registro
            For Each row As DataGridViewRow In DGrid.Rows
                If row.Cells("Selec").Value = True Then
                    intContador += 1
                End If
            Next
            If intContador = 0 Then
                MsgBox("No se selecciono ningun Registro", MsgBoxStyle.OkOnly, "Aviso")
                Exit Sub
            End If

            If MsgBox("Esta seguro de APLICAR los traspasos seleccionados?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub



            ' myForm.ShowDialog()

            'If myForm.Sw_Filtro = True Then
            '    IdTransporta = myForm.IdTransporta

            'Else
            '    MsgBox("Debe asignar un empleado para transportar el traspaso.", MsgBoxStyle.OkOnly, "Aviso")
            '    Exit Sub
            'End If
            IdTransporta = 0

            If Opcion = 1 Or Opcion = 3 Then
                For i As Integer = 1 To DGrid.Rows.Count - 1
                    If DGrid.Rows(i).Cells("Selec").Value = True And DGrid.Rows(i).Cells("status").Value = "CAPTURA" Then
                        ' ir a buscar si tiene los mismos pares , y si son iguales a la petición

                        If GLB_Idempleado <> 132 And GLB_Idempleado <> 819 Then
                            If DGrid.Rows(i).Cells("observa").Value = "***** TRASPASO HORMIGA ******" Then
                                If (GLB_IdDeptoEmpleado <> 7 And GLB_IdPuestoEmpleado <> 23) Then

                                    If DGrid.Rows(i).Cells("sucurdes").Value <> "11" And DGrid.Rows(i).Cells("sucurdes").Value <> "13" And DGrid.Rows(i).Cells("sucurdes").Value <> "18" And DGrid.Rows(i).Cells("sucurdes").Value <> "19" And DGrid.Rows(i).Cells("sucurdes").Value <> "33" And DGrid.Rows(i).Cells("sucurdes").Value <> "12" And DGrid.Rows(i).Cells("sucurdes").Value <> "32" And DGrid.Rows(i).Cells("sucurdes").Value <> "09" And DGrid.Rows(i).Cells("sucurdes").Value <> "35" And DGrid.Rows(i).Cells("sucurdes").Value <> "36" And DGrid.Rows(i).Cells("sucurdes").Value <> "43" And DGrid.Rows(i).Cells("sucurdes").Value <> "41" Then
                                        MsgBox("Solo se pueden APLICAR TRASPASOS HORMIGA, por Supervisión de Tiendas.", MsgBoxStyle.Critical, "Aviso")
                                        Exit Sub
                                    End If
                                End If
                            End If
                        End If

                        If Val(DGrid.Rows(i).Cells("idprotras").Value) <> 0 Then
CHECARNUEVAMENTE:
                                Using objTraspasos1 As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
                                    objDataSet1 = objTraspasos1.usp_PpalProTrasp(1, Val(DGrid.Rows(i).Cells("idprotras").Value), 0, "1900-01-01", "1900-01-01", "")

                                    If objDataSet1.Tables(0).Rows.Count > 0 Then

                                        If Val(objDataSet1.Tables(0).Rows(0).Item("pedida")) <> Val(DGrid.Rows(i).Cells("pares").Value) Then
                                            'MsgBox("Se detendrá el proceso, ya que el traspaso en captura no concuerda con la petición de compras.", MsgBoxStyle.Critical, "Error")

                                            Dim myForm As New frmSeriesNoTraspasoAutomatico

                                            myForm.Txt_IdTraspAut.Text = Val(DGrid.Rows(i).Cells("idprotras").Value)
                                            myForm.Txt_Sucursal.Text = (DGrid.Rows(i).Cells("sucursal").Value)
                                            myForm.Txt_DescripSucursal.Text = (DGrid.Rows(i).Cells("descrip").Value)
                                            myForm.Txt_Destino.Text = (DGrid.Rows(i).Cells("sucurdes").Value)
                                            myForm.Txt_DescripDestino.Text = (DGrid.Rows(i).Cells("descrip1").Value)
                                            myForm.ShowDialog()

                                            If myForm.Sw_Registros = True Then
                                                Call RellenaGrid()
                                                GoTo CHECARNUEVAMENTE
                                            Else
                                                Call RellenaGrid()
                                                Exit Sub
                                            End If

                                            ' Exit Sub
                                        End If
                                    End If
                                End Using
                            End If

                            'Dim Tipo As String = CStr(DGrid.Rows(i).Cells("tipo").Value)

                            Traspaso = DGrid.Rows(i).Cells("traspaso").Value
                            Sucurdes = DGrid.Rows(i).Cells("sucurdes").Value
                            Sucursal = DGrid.Rows(i).Cells("sucursal").Value

                        If Sucurdes = 11 Or Sucurdes = 13 Or Sucurdes = 12 Or Sucurdes = 41 Or Sucurdes = 9 Or Sucurdes = 32 Or Sucurdes = 33 Or Sucurdes = 19 Then
                            Plaza = 2
                        Else
                            Plaza = 1
                        End If
                        If Opcion = 1 Or Opcion = 3 Then 'Envío
                                Using objTraspasos As New BCL.BCLTraspasosSQL(GLB_ConStringSirCoSQL)
                                    objDataSet = objTraspasos.usp_TraerTraspasoManualEnvioDet(Sucursal, Traspaso, Sucurdes, 0, 0)
                                End Using
                                If objDataSet.Tables(0).Rows.Count > 0 Then

                                    For n As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1

                                        Serie = objDataSet.Tables(0).Rows(n).Item("serie")

                                    Using objTraspasos As New BCL.BCLVentaEnLinea(GLB_ConStringSirCoSQL)
                                        objDataSetAux = objTraspasos.usp_TraerTraspasoSerieDescrip(Serie)
                                        If objDataSetAux.Tables(0).Rows.Count > 0 Then
                                            If objDataSetAux.Tables(0).Rows(0).Item("status") = "BA" Then
                                                intContadorBA += 1
                                                If intContadorBA > 0 Or intContadorTR > 0 Then
                                                    MsgBox("NO SE PUEDE APLICAR EL TRASPASO POR UNA MALA OPERACIÓN EN LA GENERACIÓN DEL TRASPASO, AVISE DE INMEDIATO A SISTEMAS.", MsgBoxStyle.Critical, "Error")
                                                    Exit Sub
                                                End If

                                                Continue For
                                            ElseIf objDataSetAux.Tables(0).Rows(0).Item("status") = "TR" Then
                                                intContadorTR += 1
                                                If intContadorBA > 0 Or intContadorTR > 0 Then
                                                    MsgBox("NO SE PUEDE APLICAR EL TRASPASO POR UNA MALA OPERACIÓN EN LA GENERACIÓN DEL TRASPASO, AVISE DE INMEDIATO A SISTEMAS.", MsgBoxStyle.Critical, "Error")
                                                    Exit Sub
                                                End If

                                                Continue For
                                            ElseIf objDataSetAux.Tables(0).Rows(0).Item("sucursal") <> Sucursal Then
                                                intContadorBA += 1
                                                If intContadorBA > 0 Or intContadorTR > 0 Then
                                                    MsgBox("NO SE PUEDE APLICAR EL TRASPASO POR UNA MALA OPERACIÓN EN LA GENERACIÓN DEL TRASPASO, AVISE DE INMEDIATO A SISTEMAS.", MsgBoxStyle.Critical, "Error")
                                                    Exit Sub
                                                End If

                                                Continue For


                                            End If

                                        End If
                                    End Using



                                    Using objTraspasos1 As New BCL.BCLTraspasos(GLB_ConStringCipSis)
                                            objTraspasos1.usp_ActualizarSerie(Serie, Sucursal, "TR", Sucurdes)
                                        End Using
                                        If Opcion = 3 Then
                                            Inserta_SerieDev(Serie, Sucursal)
                                        End If
                                    Next

                                End If
                            End If


                            Using objTraspasos As New BCL.BCLTraspasosSQL(GLB_ConStringSirCoSQL)

                                objTraspasos.usp_ActualizarEstatusTraspaso(1, Sucursal, Traspaso, "AP", IdTransporta, GLB_Idempleado)

                            End Using
                            intContadorTR += 1


                            ImprimirReporteEnvio(i)

                        End If
                Next

                If intContadorTR = 0 Then
                    MsgBox("Solo se pueden cancelar aplicar traspasos con estatus de CAPTURA.", MsgBoxStyle.OkOnly, "Aviso")
                    Exit Sub
                Else

                    If usp_MatchPropuestaTraspaso() Then

                    End If

                    MsgBox("Proceso Terminado", MsgBoxStyle.Information, "Confirmación")
                End If


            ElseIf Opcion = 2 Or Opcion = 4 Then

            End If

            Call RellenaGrid()
            Me.Cursor = Cursors.Default
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Function usp_MatchPropuestaTraspaso() As Boolean
        'mreyes 02/Noviembre/2016   05:32 p.m.


        Using objCalculo As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
            Try
                'Get the specific project selected in the ListView controlsu

                Application.DoEvents()

                usp_MatchPropuestaTraspaso = objCalculo.usp_MatchPropuestaTraspaso




                Application.DoEvents()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function
    Private Sub ImprimirReporteEnvio(ByVal Renglon As Integer)
        'mreyes 26/Enero/2016   10:27 a.m.
        Try
            Dim myForm As New frmReportsBrowser

            If Plaza = 1 Then

                myForm.objDataSetReporteTraspaso = GenerarReporte(Renglon)
                If plaza = 2 Then
                    myForm.ReportIndex = 20010940
                Else
                    myForm.ReportIndex = 2001
                End If
            End If

            If Plaza = 2 Then
                myForm.objDataSetReporteTraspaso = GenerarReportePlaza2(Renglon)
                If Plaza = 2 Then
                    myForm.ReportIndex = 20010940
                Else
                    myForm.ReportIndex = 2001
                End If

            End If

            myForm.WindowState = FormWindowState.Maximized
            myForm.Show()



        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Function GenerarReporte(ByVal Renglon As Integer) As DSPReporteTraspasos
        'mreyes 26/Enero/2016   10:27 a.m.
        Try


            Dim origen As String = ""
            Dim destino As String = ""
            Dim origendescrip As String = ""
            Dim destinodescrip As String = ""
            Dim usuario As String = ""
            Dim envia As String = ""
            Dim transporta As String = ""



            origen = DGrid.Rows(Renglon).Cells("sucursal").Value
            destino = DGrid.Rows(Renglon).Cells("sucurdes").Value

            origendescrip = DGrid.Rows(Renglon).Cells("descrip").Value
            destinodescrip = DGrid.Rows(Renglon).Cells("descrip1").Value
            usuario = DGrid.Rows(Renglon).Cells("idusuario").Value



          
            envia = DGrid.Rows(Renglon).Cells("envia").Value
     
          
            transporta = DGrid.Rows(Renglon).Cells("transporta").Value
      

            GenerarReporte = New DSPReporteTraspasos
           
            Dim objDataRow As Data.DataRow = GenerarReporte.Tables(0).NewRow()


          
            objDataRow.Item("origen") = origendescrip
            objDataRow.Item("usuario") = usuario
            objDataRow.Item("observa") = DGrid.Rows(Renglon).Cells("observa").Value
            objDataRow.Item("sucurdes") = destino
            objDataRow.Item("destino") = destinodescrip
            objDataRow.Item("fecha") = DGrid.Rows(Renglon).Cells("fecha").Value
            
            objDataRow.Item("ctdori") = DGrid.Rows(Renglon).Cells("pares").Value
            
            objDataRow.Item("opcion") = 1
            objDataRow.Item("envia") = envia
            objDataRow.Item("transporta") = transporta

            objDataRow.Item("folio") = origen & "-" & DGrid.Rows(Renglon).Cells("traspaso").Value
            objDataRow.Item("estatus") = "APLICADO"


            objDataRow.Item("idtraspaso") = CInt(DGrid.Rows(Renglon).Cells("idtraspaso").Value)

            If Plaza <> 2 Then
                GenerarReporte.Tables(0).Rows.Add(objDataRow)
            End If

            If Plaza = 2 Then


                GenerarReporte = New DSPReporteTraspasos
                Using objReporte As New BCL.BCLImprimeTraspasos(GLB_ConStringSirCoSQL)
                    objDataSet = objReporte.usp_ImprimeTraspasos(1, origen, DGrid.Rows(Renglon).Cells("traspaso").Value)
                    origen = objDataSet.Tables(0).Rows(0).Item("sucursal").ToString
                    destino = objDataSet.Tables(0).Rows(0).Item("sucurdes").ToString
                End Using



                With objDataSet
                    For I As Integer = 0 To .Tables(0).Rows.Count - 1


                        objDataRow.Item("origen") = origendescrip
                        objDataRow.Item("usuario") = usuario
                        objDataRow.Item("observa") = DGrid.Rows(Renglon).Cells("observa").Value
                        objDataRow.Item("sucurdes") = destino
                        objDataRow.Item("destino") = destinodescrip
                        objDataRow.Item("fecha") = DGrid.Rows(Renglon).Cells("fecha").Value

                        objDataRow.Item("ctdori") = DGrid.Rows(Renglon).Cells("pares").Value

                        objDataRow.Item("opcion") = 1
                        objDataRow.Item("envia") = envia
                        objDataRow.Item("transporta") = transporta

                        objDataRow.Item("folio") = origen & "-" & DGrid.Rows(Renglon).Cells("traspaso").Value
                        objDataRow.Item("estatus") = "APLICADO"


                        objDataRow.Item("idtraspaso") = CInt(DGrid.Rows(Renglon).Cells("idtraspaso").Value)



                        objDataRow.Item("serie") = .Tables(0).Rows(I).Item("serie").ToString
                        objDataRow.Item("marca") = .Tables(0).Rows(I).Item("marca").ToString
                        objDataRow.Item("estilon") = .Tables(0).Rows(I).Item("estilon").ToString
                        objDataRow.Item("estilof") = .Tables(0).Rows(I).Item("estilof").ToString
                        objDataRow.Item("medida") = .Tables(0).Rows(I).Item("medida").ToString


                        objDataRow.Item("estatus") = "APLICADO"


                        GenerarReporte.Tables(0).Rows.Add(objDataRow)
                    Next
                End With
            End If


            'Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function


    Private Function GenerarReportePlaza2(ByVal Renglon As Integer) As DSPReporteTraspasos
        'mreyes 20/Mayo/2021    12:58 p.m.
        Try


            Dim origen As String = ""
            Dim destino As String = ""
            Dim origendescrip As String = ""
            Dim destinodescrip As String = ""
            Dim usuario As String = ""
            Dim envia As String = ""
            Dim transporta As String = ""



            origen = DGrid.Rows(Renglon).Cells("sucursal").Value
            destino = DGrid.Rows(Renglon).Cells("sucurdes").Value

            origendescrip = DGrid.Rows(Renglon).Cells("descrip").Value
            destinodescrip = DGrid.Rows(Renglon).Cells("descrip1").Value
            usuario = DGrid.Rows(Renglon).Cells("idusuario").Value




            envia = DGrid.Rows(Renglon).Cells("envia").Value


            transporta = DGrid.Rows(Renglon).Cells("transporta").Value







            Using objReporte As New BCL.BCLImprimeTraspasos(GLB_ConStringSirCoSQL)
                    objDataSet = objReporte.usp_ImprimeTraspasos(1, origen, DGrid.Rows(Renglon).Cells("traspaso").Value)
                    origen = objDataSet.Tables(0).Rows(0).Item("sucursal").ToString
                    destino = objDataSet.Tables(0).Rows(0).Item("sucurdes").ToString
                End Using

            GenerarReportePlaza2 = New DSPReporteTraspasos

            With objDataSet
                    For I As Integer = 0 To .Tables(0).Rows.Count - 1


                    Dim objDataRow As Data.DataRow = GenerarReportePlaza2.Tables(0).NewRow()

                    objDataRow.Item("origen") = origendescrip
                        objDataRow.Item("usuario") = usuario
                        objDataRow.Item("observa") = DGrid.Rows(Renglon).Cells("observa").Value
                        objDataRow.Item("sucurdes") = destino
                        objDataRow.Item("destino") = destinodescrip
                        objDataRow.Item("fecha") = DGrid.Rows(Renglon).Cells("fecha").Value

                    '
                    objDataRow.Item("ctdori") = DGrid.Rows(Renglon).Cells("pares").Value
                    objDataRow.Item("ctdori") = 1
                    objDataRow.Item("opcion") = 1
                        objDataRow.Item("envia") = envia
                        objDataRow.Item("transporta") = transporta

                        objDataRow.Item("folio") = origen & "-" & DGrid.Rows(Renglon).Cells("traspaso").Value
                        objDataRow.Item("estatus") = "APLICADO"


                        objDataRow.Item("idtraspaso") = CInt(DGrid.Rows(Renglon).Cells("idtraspaso").Value)



                        objDataRow.Item("serie") = .Tables(0).Rows(I).Item("serie").ToString
                        objDataRow.Item("marca") = .Tables(0).Rows(I).Item("marca").ToString
                        objDataRow.Item("estilon") = .Tables(0).Rows(I).Item("estilon").ToString
                        objDataRow.Item("estilof") = .Tables(0).Rows(I).Item("estilof").ToString
                        objDataRow.Item("medida") = .Tables(0).Rows(I).Item("medida").ToString


                        objDataRow.Item("estatus") = "APLICADO"


                    GenerarReportePlaza2.Tables(0).Rows.Add(objDataRow)
                Next
                End With



            'Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function


    Private Sub DGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick


        Dim columna As Integer = DGrid.CurrentCell.ColumnIndex
        Dim Sucursal As String = ""
        Dim Traspaso As String = ""
        Dim SucurOri As String = ""
        Dim Referenc As String = ""
        Try
            Using objTrasp As New BCL.BCLTraspasosSQL(GLB_ConStringSirCoSQL)
                If Opcion = 1 Or Opcion = 3 Then
                    Sucursal = DGrid.CurrentRow.Cells("sucursal").Value
                    Traspaso = DGrid.CurrentRow.Cells("traspaso").Value
                    objDataSet1 = objTrasp.usp_TraerTraspasosDet(Sucursal, Traspaso)
                Else
                    Sucursal = DGrid.CurrentRow.Cells("sucurori").Value
                    Traspaso = DGrid.CurrentRow.Cells("referenc").Value
                    objDataSet1 = objTrasp.usp_TraerTraspasosDet(Sucursal, Traspaso)
                End If

            End Using

            If objDataSet1.Tables(0).Rows.Count > 0 Then

                DGrid.DataSource = Nothing
                DGrid.DataSource = objDataSet1.Tables(0)

                If Sw_Load = True Then
                    ' Sw_Load = False 
                Else
                    If Sw_NoRegistros = True Then
                        DGrid.Columns.Remove("Selec")
                    End If
                End If

                InicializaGrid2()

                blnEntraDet = True
                Btn_Regresar.Enabled = True

                Btn_Cancelar.Enabled = False
                Btn_Filtro.Enabled = False
                Btn_Aplicar.Enabled = False
                Btn_Consultar.Enabled = False
                Btn_Nuevo.Enabled = False
                Btn_Modificar.Enabled = False
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGrid.KeyUp
        If blnEntraDet = False Then Exit Sub
        If IsDBNull(DGrid.Rows(DGrid.CurrentRow.Index).Cells(1).Value) Then
        Else
            CargarFotoArticulo(DGrid.Rows(DGrid.CurrentRow.Index).Cells("marca").Value, DGrid.Rows(DGrid.CurrentRow.Index).Cells("estilon").Value)
        End If
    End Sub

    Private Sub PBox_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PBox.DoubleClick
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

    Sub InicializaGrid2()
        Try
            Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
            Dim row As DataRow = dt.NewRow()


            row(7) = pub_SumarColumnaGrid(DGrid, 7, DGrid.RowCount - 1)
            row(8) = pub_SumarColumnaGrid(DGrid, 8, DGrid.RowCount - 1)
            row(9) = pub_SumarColumnaGrid(DGrid, 9, DGrid.RowCount - 1)

            dt.Rows.InsertAt(row, 0)

            DGrid.DataSource = dt

            DGrid.RowHeadersVisible = False
            DGrid.Columns(0).HeaderText = "Sucursal"
            DGrid.Columns(1).HeaderText = "Traspaso"
            DGrid.Columns(2).HeaderText = "Marca"
            DGrid.Columns(3).HeaderText = "Modelo"
            DGrid.Columns(4).HeaderText = "Medida"
            DGrid.Columns(5).HeaderText = "Corrida"
            DGrid.Columns(6).HeaderText = "Serie"
            DGrid.Columns(7).HeaderText = "Pares"
            DGrid.Columns(8).HeaderText = "Costo"
            DGrid.Columns(9).HeaderText = "Precio"

            If GLB_CveSucursal = "01" Or GLB_CveSucursal = "02" Or GLB_CveSucursal = "06" Or GLB_CveSucursal = "07" Or GLB_CveSucursal = "08" Or GLB_CveSucursal = "15" Then
                DGrid.Columns(8).Visible = False
            End If

            DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            DGrid.Columns(8).DefaultCellStyle.Format = "c"
            DGrid.Columns(9).DefaultCellStyle.Format = "c"

            DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Rows(0).Cells(7).Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Regresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Regresar.Click
        Try
            If Btn_Regresar.Enabled = True Then

                DGrid.DataSource = Nothing
                objDataSet.Tables(0).Rows(0).Delete()
                DGrid.DataSource = objDataSet.Tables(0)

                InicializaGrid()
                PBox.Image = Nothing
                PBox.Visible = False
                Btn_Regresar.Enabled = False
                blnEntraDet = False


                Btn_Cancelar.Enabled = True
                Btn_Filtro.Enabled = True
                Btn_Aplicar.Enabled = True
                Btn_Consultar.Enabled = True
                Btn_Nuevo.Enabled = True
                Btn_Modificar.Enabled = True


            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Function Inserta_SerieDev(ByVal Serie As String, ByVal Sucursal As String) As Boolean
        'Dim AccionT As Integer = 0
        Dim objDataSetT As Data.DataSet
        Dim blnTraeSerie As Boolean = False
        'Get a new Project DataSet
        Try

            Using objTraspaso As New BCL.BCLTraspasos(GLB_ConStringCipSis)
                objDataSet1 = objTraspaso.usp_TraerSerie(Serie)
                If objDataSet1.Tables(0).Rows.Count > 0 Then
                    blnTraeSerie = True
                End If
            End Using

            If blnTraeSerie = True Then
                Using objTraspaso As New BCL.BCLTraspasos(GLB_ConStringCipSis)
                    objDataSetT = objTraspaso.Inserta_SerieDev  'INSERTA NUEVO DATASET
                    'Initialize a datarow object from the Project DataSet
                    Dim objDataRow As Data.DataRow = objDataSetT.Tables(0).NewRow

                    'Set the values in the DataRow

                    objDataRow.Item("serie") = Serie
                    objDataRow.Item("sucursal") = Sucursal
                    objDataRow.Item("status") = "TR"
                    objDataRow.Item("marca") = objDataSet1.Tables(0).Rows(0).Item("marca")
                    objDataRow.Item("estilon") = objDataSet1.Tables(0).Rows(0).Item("estilon")
                    objDataRow.Item("medida") = objDataSet1.Tables(0).Rows(0).Item("medida")
                    objDataRow.Item("sucurdes") = objDataSet1.Tables(0).Rows(0).Item("sucurdes")
                    objDataRow.Item("idfolio") = objDataSet1.Tables(0).Rows(0).Item("idfolio")
                    objDataRow.Item("idarticulo") = objDataSet1.Tables(0).Rows(0).Item("idarticulo")
                    objDataRow.Item("precioini") = objDataSet1.Tables(0).Rows(0).Item("precioini")
                    objDataRow.Item("costoini") = objDataSet1.Tables(0).Rows(0).Item("costoini")
                    objDataRow.Item("preciovta") = objDataSet1.Tables(0).Rows(0).Item("preciovta")
                    objDataRow.Item("ultcosto") = objDataSet1.Tables(0).Rows(0).Item("ultcosto")
                    objDataRow.Item("proveedors") = objDataSet1.Tables(0).Rows(0).Item("proveedors")

                    'Add the DataRow to the DataSet
                    objDataSetT.Tables(0).Rows.Add(objDataRow)

                    'Add the Project
                    If Not objTraspaso.usp_Captura_SerieDev(1, objDataSetT) Then
                        '    Throw New Exception("Falló Inserción de Artículo")
                    Else
                        Inserta_SerieDev = True
                    End If
                End Using
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Function

    Private Sub DGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub

    Private Sub Pnl_Botones_Paint(sender As Object, e As PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub
End Class