Public Class frmPpalResurtidoTmp
    'mreyes 19/Octubre/2016 07:12 p.m.

    Private objDataSet As Data.DataSet
    Private objDataSet1 As Data.DataSet 'Segundo Nivel
    Private objDataSett As Data.DataSet 'Segundo Nivel
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
        DGrid.Visible = False
        'InicializaGrid()
        Using objTrasp As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                'DGrid.ReadOnly = True
                DGrid.DataSource = Nothing

                objDataSet = objTrasp.usp_PpalResurtidoTmp(OpcionSP, "", 0, "", "")

                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section 
                    'DGrid.ColumnCount = objDataSet.Tables(0).Columns.Count
                    '
                    DGrid.DataSource = objDataSet.Tables(0)
                    InicializaGrid()
                    'If Sw_Load = False Then
                    ''''
                    'End If
                    'LimpiarBusqueda()
                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True
                    Sw_NoRegistros = True
                    Sw_Pintar = True
                    'If DGrid.RowCount > 0 Then
                    '    If OpcionSP = 1 Then
                    '        Lbl_Trasp.Visible = True
                    '        Lbl_Trasp.Text = "Número de Traspasos: " & DGrid.RowCount - 1
                    '    Else
                    '        ' Lbl_Trasp.Text = "Número de Estilos a Traspasar: " & DGrid.RowCount - 1
                    '        Lbl_Trasp.Visible = False

                    '    End If
                    'End If
                    'Call Colores()
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
            If OpcionSP = 1 Then
                Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
                Dim row As DataRow = dt.NewRow()

                row(0) = "TOTAL: "
                row("CTD") = pub_SumarColumnaGrid(DGrid, 2, DGrid.RowCount - 1)


                dt.Rows.InsertAt(row, 0)
                DGrid.DataSource = dt

                DGrid.RowHeadersVisible = False
                DGrid.Columns(0).HeaderText = "Depto"
                DGrid.Columns(1).HeaderText = "Marca"
                DGrid.Columns(2).HeaderText = "Pares"



                DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells


            End If

            DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

            AgregarColumna()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub AgregarColumna()
        Try
            Dim colImagen As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()

            ' colImagen.Frozen = True
            colImagen.Name = "Resurtir"
            colImagen.HeaderText = "Resurtir"
            colImagen.DisplayIndex = 3
            colImagen.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            colImagen.CellTemplate = New DataGridViewCheckBoxCell()

            DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            ''DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
            Me.DGrid.Columns.Add(colImagen)


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

    Private Sub Btn_RecibosParciales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            OpcionSP = 2
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_RecibosTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            OpcionSP = 1
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGrid.CellFormatting
       
    End Sub

    Private Sub DGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick
        Dim columna As Integer = DGrid.CurrentCell.ColumnIndex
        Dim Sucursal As String = ""
        Dim Traspaso As String = ""
        Try
            OpcionSP = 2


            IdProTrasB = DGrid.CurrentRow.Cells("idprotras").Value

            Call RellenaGrid()




            blnEntraDet = True
            Btn_Regresar.Enabled = True

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Regresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Regresar.Click
        Try
            If Btn_Regresar.Enabled = True Then
                OpcionSP = 1
                RellenaGrid()
                PBox.Image = Nothing
                PBox.Visible = False
                Btn_Regresar.Enabled = False
                blnEntraDet = False
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Pendientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
            ESTILONFOTO = Estilon
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

    Private Sub DGrid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGrid.KeyUp
        If blnEntraDet = False Then Exit Sub
        If IsDBNull(DGrid.Rows(DGrid.CurrentRow.Index).Cells(1).Value) Then
        Else
            CargarFotoArticulo(DGrid.Rows(DGrid.CurrentRow.Index).Cells("Marca").Value, DGrid.Rows(DGrid.CurrentRow.Index).Cells("Estilon").Value)
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

    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub

    Private Sub PBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBox.Click

    End Sub

    Private Sub PBox_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PBox.MouseDown
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

    Private Sub PBox_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PBox.MouseMove
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                PBox.Location = New Point(PBox.Left + e.X - izquierda, PBox.Top + e.Y - alto)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub PBox_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PBox.MouseUp
        Try
            PBox.Cursor = Cursors.Default
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Series_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim myForm As New frmSeriesNoTraspaso

        myForm.ShowDialog()

        Call RellenaGrid()
    End Sub

    Private Sub Selecciona()
        'mreyes 09/Septiembre/2016  12:05 p.m.
        Me.Cursor = Cursors.AppStarting
        DGrid.Visible = False
        For Each row As DataGridViewRow In DGrid.Rows
            If row.Cells("resurtir").Value = True Then
                row.Cells("resurtir").Value = False
            Else
                row.Cells("resurtir").Value = True
            End If
        Next
        DGrid.Visible = True
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Btn_InvertirSeleccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_InvertirSeleccion.Click
        If Sw_NoRegistros = False Then Exit Sub
        Call Selecciona()
    End Sub

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        'mreyes 20/Octubre/2016 10:43 a.m.
        Try
            Dim objDataSet3 As Data.DataSet

            Dim OrdeComp As String = ""
            Dim OrdeComp15 As String = ""
            Dim Sucursal As String = ""
            Dim Marca As String = ""
            Dim Proveedor As String = ""
            Dim Dsctopp As Decimal
            Dim Diaspp As Decimal
            Dim Dscto01 As Decimal
            Dim Dscto02 As Decimal
            Dim Dscto03 As Decimal
            Dim Dscto04 As Decimal
            Dim Dscto05 As Decimal
            Dim Iva As Decimal
            Dim Costo As Decimal = 0
            Dim costdesc As Decimal = 0
            Dim Precio As Decimal = 0
            Dim Depto As String = ""
            Dim diasrespuesta As Integer


            If MsgBox("Esta seguro de Generar el resurtido automático de las marcas seleccionadas.?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmación") = MsgBoxResult.No Then Exit Sub


            '' ir marca por marca... 
            '' generar la orden de compra en matriz
            '' borrar del resurtidotmp la marca seleccionada.

            '1. generar folio de ordecomp


            ' ir a traer el detallado de marcas - sucursal

            For Each row As DataGridViewRow In DGrid.Rows
                If row.Cells("resurtir").Value = True Then
                    Marca = row.Cells("marca").Value
                    Depto = row.Cells("depto").Value
                    Using objTrasp As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)


                        OrdeComp15 = fn_TraerFolioOrdeComp(1, "15", 1)
                        OrdeComp15 = pub_RellenarIzquierda(OrdeComp15, 6)
                        If Actualiza_FolioOrdeComp(2, "15", 1) = False Then
                            Exit Sub
                        End If
                        'Populate the Project Details section
                        objDataSet3 = objTrasp.usp_PpalResurtidoTmp(2, Marca, 0, "", Depto)
                        If objDataSet3.Tables(0).Rows.Count > 0 Then

                            Sucursal = pub_RellenarIzquierda(objDataSet3.Tables(0).Rows(0).Item("idsucursal"), 2)
                            Proveedor = objDataSet3.Tables(0).Rows(0).Item("Proveedor")

                            Dsctopp = objDataSet3.Tables(0).Rows(0).Item("Dsctopp")
                            Diaspp = objDataSet3.Tables(0).Rows(0).Item("Diaspp")
                            Dscto01 = objDataSet3.Tables(0).Rows(0).Item("Dscto01")
                            Dscto02 = objDataSet3.Tables(0).Rows(0).Item("Dscto02")
                            Dscto03 = objDataSet3.Tables(0).Rows(0).Item("Dscto03")
                            Dscto04 = objDataSet3.Tables(0).Rows(0).Item("Dscto04")
                            Dscto05 = objDataSet3.Tables(0).Rows(0).Item("Dscto05")
                            diasrespuesta = objDataSet3.Tables(0).Rows(0).Item("diasrespuesta")



                            OrdeComp = fn_TraerFolioOrdeComp(-1, Sucursal, 1)
                                OrdeComp = pub_RellenarIzquierda(OrdeComp, 6)
                                ''' Traer proveedor, para condiciones, según  marca. 
                                ''' 

                                If objDataSet3.Tables(0).Rows(0).Item("rprov") = 1 Then
                                    Iva = 0
                                Else
                                    Iva = 16
                                End If



                            If objDataSet3.Tables(0).Rows(0).Item("rprov") = 1 Then
                                Iva = 0
                            Else
                                Iva = 16
                            End If



                        End If

                        '' INICIA MARCA
                        ''' TERMINA UNA MARCA 
                        ''' 
                        Sucursal = "15"
                        OrdeComp = OrdeComp15





                        ''' Traer proveedor, para condiciones, según  marca. 
                        ''' 



                        ' generar folio de orden de compra 
                        If Inserta_OrdeComp(OrdeComp, Sucursal, Marca, Proveedor, Dsctopp, Diaspp, _
                       Dscto01, Dscto02, Dscto03, Dscto04, _
                       Dscto05, Iva) = False Then
                            Exit Sub
                        End If




                        '' Registrar el detalle. 
                        Using objTrasp1 As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)

                            objDataSet1 = objTrasp.usp_PpalResurtidoTmp(3, Marca, 0, Proveedor, Depto)

                            'Populate the Project Details section
                            If objDataSet1.Tables(0).Rows.Count > 0 Then
                                For i As Integer = 0 To objDataSet1.Tables(0).Rows.Count - 1
                                    Using objPedidos As New BCL.BCLPedidos(GLB_ConStringCipSis)
                                        objDataSett = objPedidos.Inserta_Det_oc  'INSERTA NUEVO DATASET
                                        Dim objDataRow As Data.DataRow = objDataSett.Tables(0).NewRow

                                        Precio = objDataSet1.Tables(0).Rows(i).Item("precio")
                                        Costo = objDataSet1.Tables(0).Rows(i).Item("costo")
                                        costdesc = Format(pub_CalcularCostoPedido(Costo, Dsctopp, Dscto01, Dscto02, Dscto03, Dscto04, Dscto05, Iva), "#,##0.00")

                                        objDataRow.Item("sucursal") = Sucursal
                                        objDataRow.Item("ordecomp") = OrdeComp
                                        objDataRow.Item("marca") = Marca
                                        objDataRow.Item("estilon") = objDataSet1.Tables(0).Rows(i).Item("ESTILON") '' 'ESTILON
                                        objDataRow.Item("corrida") = objDataSet1.Tables(0).Rows(i).Item("CORRIDA")

                                        objDataRow.Item("medida") = objDataSet1.Tables(0).Rows(i).Item("MEDIDA")

                                        objDataRow.Item("ctd") = Val(objDataSet1.Tables(0).Rows(i).Item("CTD"))

                                        objDataRow.Item("costo") = costdesc
                                        objDataRow.Item("costdesc") = Costo
                                        objDataRow.Item("precio") = Precio

                                        objDataRow.Item("entrega") = Format(Now.Add(New TimeSpan(diasrespuesta, 0, 0, 0)), "yyyy-MM-dd")
                                        objDataRow.Item("cancela") = Format(Now.Add(New TimeSpan(diasrespuesta, 0, 0, 0)), "yyyy-MM-dd")

                                        'Add the DataRow to the DataSet
                                        objDataSett.Tables(0).Rows.Add(objDataRow)

                                        'Add the Project

                                        If Not objPedidos.usp_Captura_Det_oc(1, objDataSett) Then
                                            Throw New Exception("Falló Inserción de Detalle ")
                                        End If

                                    End Using
                                Next


                                ''termina el detalle
                            End If

                        End Using
                        'TERMINA MARCA 
                    End Using
                End If

            Next

            MsgBox("Proceso terminado correctamente", MsgBoxStyle.Information, "Confirmación")


            Dim myForm As New frmPpalPedidoNuevo


            myForm.WindowState = FormWindowState.Maximized
            myForm.Sw_PedidoNuevo = False
            myForm.Show()
            myForm.Refresh()

            Me.Close()
            Me.Dispose()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Function Inserta_OrdeComp(ByVal OrdeComp As String, ByVal Sucursal As String, ByVal Marca As String, _
                              ByVal Proveedor As String, ByVal Dsctopp As Decimal, ByVal Diaspp As Integer, _
                              ByVal Dscto01 As Decimal, ByVal Dscto02 As Decimal, ByVal Dscto03 As Decimal, ByVal Dscto04 As Decimal, _
                              ByVal Dscto05 As Decimal, ByVal Iva As Integer) As Boolean
        'mreyes 14/Febrero/2012 01:44 p.m.
        Using objPedidos As New BCL.BCLPedidos(GLB_ConStringCipSis)
            'Get a new Project DataSet
            Try
                objDataSet = objPedidos.Inserta_OrdeComp  'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow

                'Set the values in the DataRow

                objDataRow.Item("sucursal") = Trim(Sucursal)
                objDataRow.Item("ordecomp") = Trim(OrdeComp)
                objDataRow.Item("status") = "AP"
                objDataRow.Item("fecha") = Now.Date
                objDataRow.Item("marca") = Trim(Marca)
                objDataRow.Item("proveedor") = Trim(Proveedor)
                objDataRow.Item("observa") = Trim("RESURTIDO AUTOMÁTICO NOCTURNO")
                objDataRow.Item("usuario") = GLB_Usuario
                objDataRow.Item("resurtsn") = "S"
                objDataRow.Item("dsctopp") = Val(Dsctopp)
                objDataRow.Item("diaspp") = Val(Diaspp)
                objDataRow.Item("dscto01") = Val(Dscto01)
                objDataRow.Item("dscto02") = Val(Dscto02)
                objDataRow.Item("dscto03") = Val(Dscto03)
                objDataRow.Item("dscto04") = Val(Dscto04)
                objDataRow.Item("dscto05") = Val(Dscto05)
                objDataRow.Item("iva") = Val(Iva)

                objDataRow.Item("tipopedido") = "CATALOGO"

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

    Function Inserta_OrdeCompResAut(ByVal OrdeComp As String, ByVal Sucursal As String, ByVal Marca As String, _
                              ByVal Proveedor As String, ByVal Dsctopp As Decimal, ByVal Diaspp As Integer, _
                              ByVal Dscto01 As Decimal, ByVal Dscto02 As Decimal, ByVal Dscto03 As Decimal, ByVal Dscto04 As Decimal, _
                              ByVal Dscto05 As Decimal, ByVal Iva As Integer) As Boolean
        'mreyes 16/Febrero/2017 05:18 p.m.
        Using objPedidos As New BCL.BCLPedidos(GLB_ConStringCipSis)
            'Get a new Project DataSet
            Try
                objDataSet = objPedidos.Inserta_OrdeCompResAut  'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow

                'Set the values in the DataRow

                objDataRow.Item("sucursal") = Trim(Sucursal)
                objDataRow.Item("ordecomp") = Trim(OrdeComp)
                objDataRow.Item("status") = "AP"
                objDataRow.Item("fecha") = Now.Date
                objDataRow.Item("marca") = Trim(Marca)
                objDataRow.Item("proveedor") = Trim(Proveedor)
                objDataRow.Item("observa") = Trim("RESURTIDO AUTOMÁTICO NOCTURNO")
                objDataRow.Item("usuario") = GLB_Usuario
                objDataRow.Item("resurtsn") = "S"
                objDataRow.Item("dsctopp") = Val(Dsctopp)
                objDataRow.Item("diaspp") = Val(Diaspp)
                objDataRow.Item("dscto01") = Val(Dscto01)
                objDataRow.Item("dscto02") = Val(Dscto02)
                objDataRow.Item("dscto03") = Val(Dscto03)
                objDataRow.Item("dscto04") = Val(Dscto04)
                objDataRow.Item("dscto05") = Val(Dscto05)
                objDataRow.Item("iva") = Val(Iva)

                objDataRow.Item("tipopedido") = "CATALOGO"

                'Add the DataRow to the DataSet
                objDataSet.Tables(0).Rows.Add(objDataRow)

                'Add the Project
                If Not objPedidos.usp_Captura_OrdeComp(11, objDataSet) Then
                    '' Throw New Exception("Falló Inserción de OrdeComp")
                Else
                    Inserta_OrdeCompResAut = True
                End If
                Inserta_OrdeCompResAut = True
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using

    End Function
End Class
