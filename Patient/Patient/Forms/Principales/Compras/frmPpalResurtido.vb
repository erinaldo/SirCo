Public Class frmPpalResurtido
    'miguel perez 12/Noviembre/2012 04:20 p.m.

    Private objDataSet As Data.DataSet
    Private FechaInicio As String
    Private FechaFin As String
    Private Sucursal As String
    Private Marca As String
    Private blnColumnaAgregada As Boolean = False

    Private Sub frmPpalProveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            blnColumnaAgregada = False
            Dt_Fin.MaxDate = Now
            Dt_Inicio.MaxDate = Now
            GenerarToolTip()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub RellenaGrid(ByVal FecIni As String, ByVal FecFin As String)
        Try
            DGrid.DataSource = Nothing
            Using objMercancia As New BCL.BCLResurtido(GLB_ConStringCipSis)
                objDataSet = objMercancia.usp_TraerEstilosVendExis(FecIni, FecFin, "", "")
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                DGrid.DataSource = objDataSet.Tables(0)
                InicializaGrid()
            Else
                MessageBox.Show("No se encontraron ventas en las fechas seleccionadas", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Sub InicializaGrid()
        Try
            For i As Integer = 0 To DGrid.Columns.Count - 1
                DGrid.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(i).ReadOnly = True
            Next
            DGrid.Columns("CP").ReadOnly = False
            DGrid.Columns("Oculta").Visible = False
            DGrid.Columns("Proveedor").Visible = False

            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            If blnColumnaAgregada = False Then
                AgregarColumna()
                blnColumnaAgregada = True
            End If
            ColorearGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub AgregarColumna()
        Dim colImagen As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        colImagen.Name = "Selec"
        colImagen.HeaderText = "Selec"
        colImagen.DisplayIndex = 12
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

    Private Sub frmPpalPedidoNuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub DGrid_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGrid.ColumnHeaderMouseClick
        Try
            ColorearGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick
        Try
            Btn_Foto_Click(sender, e)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Filtro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        Dim Estatus As String = ""
        Try
            Dim myForm As New frmFiltrosMercancia
            myForm.Txt_Sucursal.Text = GLB_CveSucursal
            myForm.ShowDialog()
            If myForm.Sw_Filtro = False Then Exit Sub
            If DGrid.DataSource IsNot Nothing Then
                DGrid.Columns.Remove("selec")
                blnColumnaAgregada = False
            End If
            blnColumnaAgregada = False
            If myForm.Chk_Fecha.Checked Then
                FechaInicio = myForm.DTPicker2.Value.Date.ToString("yyyy-MM-dd")
                FechaFin = myForm.DTPicker3.Value.Date.ToString("yyyy-MM-dd")
            Else
                FechaInicio = ""
                FechaFin = ""
            End If
            Sucursal = myForm.Txt_Sucursal.Text.Trim
            Marca = myForm.Txt_Marca.Text.Trim

            Using objMercancia As New BCL.BCLResurtido(GLB_ConStringCipSis)
                objDataSet = objMercancia.usp_TraerEstilosVendExis(FechaInicio, FechaFin, Sucursal, Marca)
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                DGrid.DataSource = Nothing
                DGrid.DataSource = objDataSet.Tables(0)
            Else
                MessageBox.Show("No se encontro información", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            InicializaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")

            ToolTip.SetToolTip(Btn_Salir, "Salir")
            ToolTip.SetToolTip(Btn_Filtro, "Filtros")

            ToolTip.SetToolTip(Btn_Transferir, "Generar Orden de Compra")
            ToolTip.SetToolTip(Btn_InvertirSeleccion, "Invertir selección")

            ToolTip.SetToolTip(Btn_Foto, "Ver la foto del Estilo")
            ToolTip.SetToolTip(Btn_Aceptar, "Aceptar")
            
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub Btn_Foto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Foto.Click
        Try
            Dim myForm As New frmConsultaImagen
            myForm.Txt_Estilon.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("estilon").Value.ToString
            myForm.Txt_Marca.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("marca").Value.ToString
            myForm.Txt_NoFoto.Text = "1"
            myForm.ShowDialog()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        Try
            Dim strFecIni As String = ""
            Dim strFecFin As String = ""
            strFecIni = Dt_Inicio.Value.Date.ToString("yyyy-MM-dd")
            strFecFin = Dt_Fin.Value.Date.ToString("yyyy-MM-dd")
            If CDate(strFecIni) > CDate(strFecFin) Then
                MessageBox.Show("La fecha de inicio debe ser menor a la fecha final", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If DGrid.DataSource IsNot Nothing Then
                DGrid.Columns.Remove("selec")
                blnColumnaAgregada = False
            End If
            RellenaGrid(strFecIni, strFecFin)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_InvertirSeleccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_InvertirSeleccion.Click
        Try
            For i As Integer = 0 To DGrid.Rows.Count - 1
                If DGrid.Rows(i).Cells("Selec").Value = True Then
                    DGrid.Rows(i).Cells("Selec").Value = False
                Else
                    DGrid.Rows(i).Cells("Selec").Value = True
                End If
            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub Btn_Transferir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Transferir.Click
        Try
            If DGrid.DataSource Is Nothing Then
                MessageBox.Show("Por favor selecciona articulos para generar la orden de compra", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Dim contador As Integer = 0
            Dim objDataSetMarPro As New Data.DataSet
            objDataSetMarPro.Tables.Clear()
            objDataSetMarPro.Tables.Add()
            objDataSetMarPro.Tables(0).Columns.Add("Sucursal")
            objDataSetMarPro.Tables(0).Columns.Add("Marca")
            objDataSetMarPro.Tables(0).Columns.Add("Proveedor")
            Dim contMarProv As Integer = 0

            Dim objDataSetSeleccionados As New Data.DataSet
            objDataSetSeleccionados.Tables.Clear()
            objDataSetSeleccionados.Tables.Add()
            objDataSetSeleccionados.Tables(0).Columns.Add("Sucursal")
            objDataSetSeleccionados.Tables(0).Columns.Add("Proveedor")
            objDataSetSeleccionados.Tables(0).Columns.Add("Marca")
            objDataSetSeleccionados.Tables(0).Columns.Add("Estilon")
            objDataSetSeleccionados.Tables(0).Columns.Add("Medida")
            objDataSetSeleccionados.Tables(0).Columns.Add("CP")
            Dim contMarSeleccionados As Integer = 0

            For i As Integer = 0 To DGrid.Rows.Count - 1
                If CBool(DGrid.Rows(i).Cells("selec").Value) = True And CInt(DGrid.Rows(i).Cells("CP").Value) <> 0 Then
                    If objDataSetMarPro.Tables(0).Rows.Count = 0 Then
                        objDataSetMarPro.Tables(0).Rows.Add()
                        objDataSetMarPro.Tables(0).Rows(contMarProv).Item("Sucursal") = DGrid.Rows(i).Cells("Sucursal").Value
                        objDataSetMarPro.Tables(0).Rows(contMarProv).Item("Marca") = DGrid.Rows(i).Cells("Marca").Value
                        objDataSetMarPro.Tables(0).Rows(contMarProv).Item("Proveedor") = DGrid.Rows(i).Cells("Proveedor").Value
                        contMarProv += 1
                    Else
                        Dim SucursalB As String = ""
                        Dim MarcaB As String = ""
                        Dim ProveedorB As String = ""
                        SucursalB = DGrid.Rows(i).Cells("Sucursal").Value
                        MarcaB = DGrid.Rows(i).Cells("Marca").Value
                        ProveedorB = DGrid.Rows(i).Cells("Proveedor").Value
                        Dim blnExiste As Boolean = False
                        For j As Integer = 0 To objDataSetMarPro.Tables(0).Rows.Count - 1
                            If SucursalB = objDataSetMarPro.Tables(0).Rows(j).Item("Sucursal").ToString Then
                                If MarcaB = objDataSetMarPro.Tables(0).Rows(j).Item("Marca").ToString Then
                                    If ProveedorB = objDataSetMarPro.Tables(0).Rows(j).Item("Proveedor").ToString Then
                                        blnExiste = True
                                        Exit For
                                    Else
                                        blnExiste = False
                                    End If
                                Else
                                    blnExiste = False
                                End If
                            Else
                                blnExiste = False
                            End If
                        Next
                        If blnExiste = False Then
                            objDataSetMarPro.Tables(0).Rows.Add()
                            objDataSetMarPro.Tables(0).Rows(contMarProv).Item("Sucursal") = DGrid.Rows(i).Cells("Sucursal").Value
                            objDataSetMarPro.Tables(0).Rows(contMarProv).Item("Marca") = DGrid.Rows(i).Cells("Marca").Value
                            objDataSetMarPro.Tables(0).Rows(contMarProv).Item("Proveedor") = DGrid.Rows(i).Cells("Proveedor").Value
                            contMarProv += 1
                        End If
                    End If
                    objDataSetSeleccionados.Tables(0).Rows.Add()
                    objDataSetSeleccionados.Tables(0).Rows(contMarSeleccionados).Item("Sucursal") = DGrid.Rows(i).Cells("Sucursal").Value
                    objDataSetSeleccionados.Tables(0).Rows(contMarSeleccionados).Item("Proveedor") = DGrid.Rows(i).Cells("Proveedor").Value
                    objDataSetSeleccionados.Tables(0).Rows(contMarSeleccionados).Item("Marca") = DGrid.Rows(i).Cells("Marca").Value
                    objDataSetSeleccionados.Tables(0).Rows(contMarSeleccionados).Item("Estilon") = DGrid.Rows(i).Cells("Estilon").Value
                    objDataSetSeleccionados.Tables(0).Rows(contMarSeleccionados).Item("Medida") = DGrid.Rows(i).Cells("Medida").Value
                    objDataSetSeleccionados.Tables(0).Rows(contMarSeleccionados).Item("CP") = DGrid.Rows(i).Cells("CP").Value
                    contMarSeleccionados += 1
                End If
            Next

            For i As Integer = 0 To objDataSetMarPro.Tables(0).Rows.Count - 1
                Dim Suc As String = objDataSetMarPro.Tables(0).Rows(i).Item("Sucursal").ToString.Trim
                Dim Pro As String = objDataSetMarPro.Tables(0).Rows(i).Item("Proveedor").ToString.Trim
                Dim Mar As String = objDataSetMarPro.Tables(0).Rows(i).Item("Marca").ToString.Trim
                Dim OrdeComp As String = fn_TraerFolioOrdeComp(1, Suc, 1)
                OrdeComp = pub_RellenarIzquierda(OrdeComp, 6)
                Using objProveedores As New BCL.BCLCatalogoProveedores(GLB_ConStringCipSis)
                    objDataSet = objProveedores.usp_TraerProveedor(Pro, Mar)
                End Using
                If objDataSet.Tables(0).Rows.Count = 0 Then
                    MessageBox.Show("El numero de proveedor " + Pro.ToString + " no existe", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Continue For
                End If
                Dim Dsctopp As Decimal = CDec(objDataSet.Tables(0).Rows(0).Item("dsctopp").ToString.Trim)
                Dim Diaspp As Decimal = CDec(objDataSet.Tables(0).Rows(0).Item("diaspp").ToString.Trim)
                Dim Dscto01 As Decimal = CDec(objDataSet.Tables(0).Rows(0).Item("dscto01").ToString.Trim)
                Dim Dscto02 As Decimal = CDec(objDataSet.Tables(0).Rows(0).Item("dscto02").ToString.Trim)
                Dim Dscto03 As Decimal = CDec(objDataSet.Tables(0).Rows(0).Item("dscto03").ToString.Trim)
                Dim Dscto04 As Decimal = CDec(objDataSet.Tables(0).Rows(0).Item("dscto04").ToString.Trim)
                Dim Dscto05 As Decimal = CDec(objDataSet.Tables(0).Rows(0).Item("dscto05").ToString.Trim)
                Inserta_OrdeComp(OrdeComp, Suc, Mar, Pro, Dsctopp, Diaspp, Dscto01, Dscto02, Dscto03, Dscto04, Dscto05, 16)
                Actualiza_FolioOrdeComp(2, Suc, 1)
                For j As Integer = 0 To objDataSetSeleccionados.Tables(0).Rows.Count - 1
                    Dim Sucursal1 As String = objDataSetSeleccionados.Tables(0).Rows(j).Item("Sucursal").ToString.Trim
                    Dim Marca1 As String = objDataSetSeleccionados.Tables(0).Rows(j).Item("Marca").ToString.Trim
                    Dim Proveedor1 As String = objDataSetSeleccionados.Tables(0).Rows(j).Item("Proveedor").ToString.Trim
                    Dim Estilon1 As String = objDataSetSeleccionados.Tables(0).Rows(j).Item("Estilon").ToString
                    Dim Medida1 As String = objDataSetSeleccionados.Tables(0).Rows(j).Item("Medida").ToString.Trim
                    Dim CP1 As Integer = CInt(objDataSetSeleccionados.Tables(0).Rows(j).Item("CP").ToString.Trim)
                    If Sucursal1 = Suc And Marca1 = Mar And Proveedor1 = Pro Then
                        Using objPrueba As New BCL.BCLResurtido(GLB_ConStringCipSis)
                            objDataSet = objPrueba.usp_TraerMedida2(Marca1, Estilon1, Medida1)
                        End Using
                        If objDataSet.Tables(0).Rows.Count = 0 Then
                            'MessageBox.Show("El articulo seleccionado no existe", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Continue For
                        End If
                        Dim Corrida1 As String = objDataSet.Tables(0).Rows(0).Item("corrida").ToString.Trim
                        Using objCantArti As New BCL.BCLPedidos(GLB_ConStringCipSis)
                            objDataSet = objCantArti.usp_TraerMedida(1, Marca1, Proveedor1, Estilon1, Corrida1)
                        End Using
                        Dim Costo1 As Decimal = CDec(objDataSet.Tables(0).Rows(0).Item("costo").ToString.Trim)
                        Dim PComp As Decimal = pub_CalcularCostoPedido(Costo1, Dsctopp, Dscto01, Dscto02, Dscto03, Dscto04, Dscto05, 16)
                        Using objCantArti As New BCL.BCLResurtido(GLB_ConStringCipSis)
                            objDataSet = objCantArti.usp_TraerDiasResProv(Proveedor1)
                        End Using
                        Dim FecEntrega As String
                        If objDataSet.Tables(0).Rows.Count = 0 Then
                            FecEntrega = Now.ToString("yyyy-MM-dd")
                        Else
                            FecEntrega = Now.AddDays(CInt(objDataSet.Tables(0).Rows(0).Item("diasrespuesta"))).ToString("yyyy-MM-dd")
                        End If
                        Inserta_Det_Oc(Sucursal1, OrdeComp, Marca1, Estilon1, Corrida1, Medida1, CP1, Costo1, PComp, FecEntrega)
                        contador += 1
                    End If
                Next
            Next
            If contador > 0 Then
                MessageBox.Show("Ordenes de compra generadas correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Function Inserta_OrdeComp(ByVal OrdeComp As String, ByVal Sucursal As String, ByVal Marca As String, ByVal Proveedor As String, _
                                    ByVal Dsctopp As Decimal, ByVal diaspp As Decimal, ByVal dscto01 As Decimal, ByVal dscto02 As Decimal, ByVal dscto03 As Decimal, ByVal dscto04 As Decimal, ByVal dscto05 As Decimal, ByVal iva As Decimal) As Boolean
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

    Private Function Inserta_Det_Oc(ByVal Sucursal As String, ByVal OrdeComp As String, ByVal Marca As String, ByVal Estilon As String, ByVal Corrida As String, ByVal Medida As String, ByVal Ctd As Integer, _
                                    ByVal Costo As Decimal, ByVal Pcomp As Decimal, ByVal FecEntrega As String) As Boolean
        Dim objDataSet As Data.DataSet
        Using objPedidos As New BCL.BCLPedidos(GLB_ConStringCipSis)
            'Get a new Project DataSet
            Try

                objDataSet = objPedidos.Inserta_Det_oc  'INSERTA NUEVO DATASET
                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow


                objDataRow.Item("sucursal") = Sucursal
                objDataRow.Item("ordecomp") = OrdeComp
                objDataRow.Item("marca") = Marca
                objDataRow.Item("estilon") = Estilon
                objDataRow.Item("corrida") = Corrida

                objDataRow.Item("medida") = Medida

                objDataRow.Item("ctd") = Ctd
                ' objDataRow.Item("costo") = DGrid.Rows(Renglon).Cells("pcomp").Value
                'objDataRow.Item("costdesc") = DGrid.Rows(Renglon).Cells("costo").Value
                objDataRow.Item("costo") = Pcomp
                objDataRow.Item("costdesc") = Costo
                objDataRow.Item("precio") = 0
                objDataRow.Item("entrega") = CDate(FecEntrega).ToString("yyyy-MM-dd")
                objDataRow.Item("cancela") = CDate(FecEntrega).AddDays(30).ToString("yyyy-MM-dd")
                'Add the DataRow to the DataSet
                objDataSet.Tables(0).Rows.Add(objDataRow)

                'Add the Project

                If Not objPedidos.usp_Captura_Det_oc(1, objDataSet) Then
                    Throw New Exception("Falló Inserción de Detalle")
                End If

                objDataSet.Dispose()
                objDataRow.Table.Dispose()

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Private Sub DGrid_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellEndEdit
        Try
            Dim columna As Integer = DGrid.CurrentCell.ColumnIndex
            If columna = 10 Then
                Dim Resmin As Integer = 0
                Dim CP As Integer = CInt(DGrid.CurrentRow.Cells(columna).Value.ToString.Trim)
                Dim Marca As String = DGrid.CurrentRow.Cells("Marca").Value.ToString.Trim
                Dim Estilon As String = DGrid.CurrentRow.Cells("Estilon").Value
                If CP = 0 Then Exit Sub
                Using objPedidos As New BCL.BCLResurtido(GLB_ConStringCipSis)
                    objDataSet = objPedidos.usp_TraerResmin(Marca, Estilon)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Resmin = CInt(objDataSet.Tables(0).Rows(0).Item("resmin"))
                    If CP < Resmin Then
                        DGrid.CurrentRow.Cells(columna).Value = Resmin.ToString
                    End If
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Public Sub ColorearGrid()
        Try
            Dim Estilon As String = ""
            Dim Marca As String = ""
            Dim Sucursal As String = ""
            Dim Col1 As Color
            Dim Num As Integer = 0
            Col1 = Color.LightSeaGreen
            If DGrid.DataSource Is Nothing Then Exit Sub
            Estilon = DGrid.Rows(0).Cells("Estilon").Value
            Marca = DGrid.Rows(0).Cells("Marca").Value
            Sucursal = DGrid.Rows(0).Cells("Sucursal").Value
            Num = 1
            For i As Integer = 0 To DGrid.Rows.Count - 1
                If Estilon = DGrid.Rows(i).Cells("Estilon").Value And Marca = DGrid.Rows(i).Cells("Marca").Value And Sucursal = DGrid.Rows(i).Cells("Sucursal").Value Then
                    DGrid.Rows(i).DefaultCellStyle.BackColor = Col1
                Else
                    If Num = 1 Then
                        Col1 = Color.PeachPuff
                        Num = 2
                    ElseIf Num = 2 Then
                        Col1 = Color.LightSeaGreen
                        Num = 1
                    End If
                    Sucursal = DGrid.Rows(i).Cells("Sucursal").Value
                    Marca = DGrid.Rows(i).Cells("Marca").Value
                    Estilon = DGrid.Rows(i).Cells("Estilon").Value
                    DGrid.Rows(i).DefaultCellStyle.BackColor = Col1
                End If
            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

End Class