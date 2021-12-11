Public Class frmPpalEstrYExistActual
    'mreyes 25/Mayo/2016    11:36 a.m.

    Dim Sw_Load As Boolean = False
    Private objDataSet As Data.DataSet
    Public Opcion As Integer = 0
    'Public OpcionAntMarca As Integer = 0
    Public Sucursal As String = ""
    Public Division As String = ""
    Private FechIniB As String = "1900-01-01"
    Private FechFinB As String = "1900-01-01"
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
    Dim MarcaFOTO As String = ""
    Dim EstiloNFOTO As String = ""
    Dim DescripSucursal As String = ""
    Dim checkInicio As Boolean = False
    Private izquierda As Integer = 0
    Private alto As Integer = 0
    Dim blnBorroCol As Boolean = False
    Dim myFormFiltros As frmFiltrosEstrYExistActual
    Public Accion As Integer = 0
    'Accion 1 = Antiguedad ----- Accion 2 = Inventario
    Dim blnEntro As Boolean = False
    Public blnActualizando As Boolean = False
    Dim arreglo(100) As Integer
    Dim intPosicion As Integer = 0
    Public DiasIni As Integer = 0
    Public DiasFin As Integer = 0
    Dim blnDias As Boolean = False
    Dim blnEsTotal As Boolean = False
    Dim Marca1 As String = ""
    Dim blnMar As Boolean = False
    Dim blnNoEsTot As Boolean = False
    Dim Opcion2 As Integer = 1

    Dim FecHora As Date
    Dim FechaInv As String = ""
    Dim NomTablaExist As String = ""
    Dim strQueryInv As String = ""
    Public Sw_Mas250 As Boolean = False



    Private Sub frmPpalProveedores_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then
                Me.Close()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmPpalProveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'sw_load = True
        'If Sw_Mas250 = False Then
        '    If Accion = 0 Then Accion = 1
        '    If Opcion = 0 Then
        '        Opcion = 1
        '    End If


        'End If
        Call LimpiarBusqueda()
        fechFinB = Format(Now.Date, "yyyy-MM-dd")
        fechIniB = Format(Now.Add(New TimeSpan(-7, 0, 0, 0)), "yyyy-MM-dd")

        ' Call RellenaGrid()
        Call GenerarToolTip()
        myFormFiltros = New frmFiltrosEstrYExistActual
       

    End Sub

    Private Sub LimpiarBusqueda()
        If GLB_CveSucursal = "01" Or GLB_CveSucursal = "02" Or GLB_CveSucursal = "06" Or GLB_CveSucursal = "07" Or GLB_CveSucursal = "08" Or GLB_CveSucursal = "11" Or GLB_CveSucursal = "15" Then
            Sucursal = GLB_CveSucursal
        Else
            Sucursal = ""
        End If

        PBox.Visible = False

        'FechaInib = "1900-01-01"
        'FechaFinb = "1900-01-01"
        'FechaIniB = Format(Now.Add(New TimeSpan(0, 0, 0, 0)), "yyyy-MM-dd")
        'FechaFinB = Format(Now.Date, "yyyy-MM-dd")

    End Sub
    Private Sub RellenaGrid()

        Try
            Using objRegistro As New BCL.BCLExistenciaActual(GLB_ConStringCipSis)
                Me.Cursor = Cursors.WaitCursor
                DGrid.DataSource = Nothing

                objDataSet = objRegistro.usp_PpalEstructuraYExistActual(FechIniB, FechFinB, Division, Depto, Linea, L1, L2, L3, L4, L5, L6)
            End Using


            If objDataSet.Tables(0).Rows.Count > 0 Then
                DGrid.DataSource = objDataSet.Tables(0)
                InicializaGrid()
                'Else
                Me.Cursor = Cursors.Default
                Btn_Excel.Enabled = True

            Else
                Me.Cursor = Cursors.Default
                MsgBox("No se encontraron registros que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                Btn_Excel.Enabled = False
            End If

            LimpiarBusqueda()
            'OcultarToolStrips()

            'Me.Cursor = Cursors.Default
            'Sw_Load = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub GenerarToolTip()
        Try
            '
            ToolTip.SetToolTip(Btn_Filtro, "Búsqueda Avanzada")
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
            ToolTip.SetToolTip(Btn_Salir, "Salir")
            ToolTip.SetToolTip(Btn_Foto, "Imagen del Producto")
            ToolTip.SetToolTip(Btn_Imprimir, "Imprimir Reporte")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Sub InicializaGrid()




        Try
            '    PBox.Visible = False
            '    Btn_Foto.Enabled = False
            Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
            Dim row As DataRow = dt.NewRow()

            DGrid.RowHeadersVisible = False
            DGrid.Columns("DIVISION").HeaderText = "Division"
            DGrid.Columns("DEPTO").HeaderText = "Departamento"
            DGrid.Columns("L1").HeaderText = "L1"
            DGrid.Columns("MARCA").HeaderText = "Marca"
            DGrid.Columns("MODELO").HeaderText = "Modelo"
            DGrid.Columns("recibo").HeaderText = "Recibo"
            DGrid.Columns("EXIST").HeaderText = "Existencia Actual"
            



            DGrid.Columns("DIVISION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns("DEPTO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns("L1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns("MARCA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns("MODELO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns("recibo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns("EXIST").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            
            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub InicioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemInicio.Click
        Try
            Sucursal = ""
            Division = ""
            Depto = ""
            Familia = ""
            Linea = ""
            L1 = ""
            L2 = ""
            L3 = ""
            L4 = ""
            L5 = ""
            L6 = ""
            Marca = ""
            Modelo = ""
            intPosicion = 0
            arreglo(100) = New Integer
            'If RB_Activas.Checked Then
            '    Opcion = 1
            '    RellenaGrid()
            'Else
            '    RB_Activas.Checked = True
            'End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick

        CargarFotoArticulo(DGrid.Rows(DGrid.CurrentRow.Index).Cells("Marca").Value, DGrid.Rows(DGrid.CurrentRow.Index).Cells("Modelo").Value)

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
                    'GLB_RutaArchivoFotos = "C:\Users\Sistemas\Pictures\Sample Pictures\"
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

        CargarFotoArticulo(DGrid.Rows(DGrid.CurrentRow.Index).Cells("Marca").Value, DGrid.Rows(DGrid.CurrentRow.Index).Cells("Modelo").Value)

    End Sub

    Private Sub DGrid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGrid.KeyUp

        CargarFotoArticulo(DGrid.Rows(DGrid.CurrentRow.Index).Cells("Marca").Value, DGrid.Rows(DGrid.CurrentRow.Index).Cells("Modelo").Value)

    End Sub

    Private Sub Btn_Foto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Foto.Click
        Try
            Dim myForm As New frmConsultaImagen
            myForm.Txt_Estilon.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("Modelo").Value.ToString
            myForm.Txt_Marca.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("Marca").Value.ToString.Trim()
            myForm.Txt_NoFoto.Text = "1"
            myForm.ShowDialog()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
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

    Private Sub Btn_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Excel.Click
        Try
            If ExportarDGridAExcel(DGrid) = False Then
                MsgBox("Error al exportar a Excel. Intente nuevamente.", MsgBoxStyle.Critical, "Excel")
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Me.Close()
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

    Private Sub Btn_Filtro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        Try
            myFormFiltros.StartPosition = FormStartPosition.CenterParent
            myFormFiltros.Sw_Filtro = False
            myFormFiltros.CB_Sucursal.Visible = False
            myFormFiltros.Label4.Visible = False
            myFormFiltros.DT_RecFin.Visible = True
            myFormFiltros.DT_RecIni.Visible = True
            myFormFiltros.Chk_UltRecibo.Visible = True
            'myFormFiltros.CB_Sucursal.Visible = False
            myFormFiltros.Suc = Sucursal
            'myFormFiltros.Label4.Visible = False

            'If Accion = 1 Then
            '    myFormFiltros.Text = "Filtros Antigüedad Inventario"
            'ElseIf Accion = 2 Then
            '    myFormFiltros.Text = "Filtros Inventario Costo/Venta"
            '    If GLB_CveSucursal > "0" And GLB_CveSucursal < "90" Then
            '        myFormFiltros.CB_Sucursal.SelectedValue = GLB_CveSucursal
            '        myFormFiltros.CB_Sucursal.Enabled = False
            '    End If
            'End If


            If fechFinB <> "1900-01-01" Then
                myFormFiltros.Chk_UltRecibo.Checked = True
                myFormFiltros.DT_RecIni.Value = fechIniB
                myFormFiltros.DT_RecFin.Value = fechFinB
            End If


            If Division <> "" Then
                If Division = "CALZADO" Then
                    myFormFiltros.Txt_Division.Text = "001"
                ElseIf Division = "ACCESORIOS" Then
                    myFormFiltros.Txt_Division.Text = "002"
                ElseIf Division = "ELECTRONICA" Then
                    myFormFiltros.Txt_Division.Text = "003"
                ElseIf Division = "GENERAL" Then
                    myFormFiltros.Txt_Division.Text = "999"
                End If
                myFormFiltros.Txt_DescripDivision.Text = Division
            Else
                myFormFiltros.Txt_DescripDivision.Text = ""
                myFormFiltros.Txt_Division.Text = ""
            End If
            If Depto <> "" Then
                myFormFiltros.Txt_IdDepto.Text = Depto
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstDepto(0, 0, "", 0, Depto)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_DescripDepto.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                    myFormFiltros.Txt_Depto.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                End If
            End If
            If Familia <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstFamilia(0, 0, 0, "", 3, Familia)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_Familia.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripFamilia.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If Linea <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstLinea(0, 0, 0, 0, "", 3, Linea)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_Linea.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripLinea.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L1 <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl1(0, 0, 0, 0, 0, "", 3, L1)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_L1.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripL1.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L2 <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl2(0, 0, 0, 0, 0, 0, "", 3, L2)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_L2.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripL2.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L3 <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl3(0, 0, 0, 0, 0, 0, 0, "", 3, L3)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_L3.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripL3.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L4 <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl4(0, 0, 0, 0, 0, 0, 0, 0, "", 3, L4)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_L4.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripL4.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L5 <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl5(0, 0, 0, 0, 0, 0, 0, 0, 0, "", 3, L5)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_L5.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripL5.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L6 <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl6(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", 3, L6)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_L6.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripL6.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If Marca <> "" Then
                myFormFiltros.Txt_Marca.Text = Marca
            End If
            myFormFiltros.ShowDialog()
            If myFormFiltros.Sw_Filtro = True Then
                DGrid.DataSource = Nothing
                DGrid.Refresh()
                DGrid.Rows.Clear()

                'If CInt(myFormFiltros.CB_Sucursal.SelectedValue.ToString) = 0 Then
                '    Sucursal = ""
                'Else
                '    Sucursal = pub_RellenarIzquierda(myFormFiltros.CB_Sucursal.SelectedValue.ToString, 2)
                '    DescripSucursal = myFormFiltros.CB_Sucursal.Text
                'End If

                ' fecha ultimo recibo
                If myFormFiltros.Chk_UltRecibo.Checked = True Then
                    ' Format(Now.Date, "yyyy-MM-dd")

                    fechIniB = Format(myFormFiltros.DT_RecIni.Value, "yyyy-MM-dd")
                    fechFinB = Format(myFormFiltros.DT_RecFin.Value, "yyyy-MM-dd")
                Else
                    fechIniB = "1900-01-01"
                    fechFinB = "1900-01-01"
                End If
                Marca = myFormFiltros.Txt_Marca.Text
                If Marca.Trim <> "" Then
                    lbl_Marca.Text = Marca
                End If

                If myFormFiltros.Txt_DescripDivision.Text.Trim = "" Then
                    Division = ""
                Else
                    Division = myFormFiltros.Txt_DescripDivision.Text
                End If
                If myFormFiltros.Txt_DescripDepto.Text.Trim = "" Then
                    Depto = ""
                Else
                    Depto = myFormFiltros.Txt_DescripDepto.Text
                End If
                If myFormFiltros.Txt_DescripFamilia.Text = "" Then
                    Familia = ""
                Else
                    Familia = myFormFiltros.Txt_DescripFamilia.Text
                End If
                If myFormFiltros.Txt_DescripLinea.Text = "" Then
                    Linea = ""
                Else
                    Linea = myFormFiltros.Txt_DescripLinea.Text
                End If
                If myFormFiltros.Txt_DescripL1.Text = "" Then
                    L1 = ""
                Else
                    L1 = myFormFiltros.Txt_DescripL1.Text
                End If
                If myFormFiltros.Txt_DescripL2.Text = "" Then
                    L2 = ""
                Else
                    L2 = myFormFiltros.Txt_DescripL2.Text
                End If
                If myFormFiltros.Txt_DescripL3.Text = "" Then
                    L3 = ""
                Else
                    L3 = myFormFiltros.Txt_DescripL3.Text
                End If
                If myFormFiltros.Txt_DescripL4.Text = "" Then
                    L4 = ""
                Else
                    L4 = myFormFiltros.Txt_DescripL4.Text
                End If
                If myFormFiltros.Txt_DescripL5.Text = "" Then
                    L5 = ""
                Else
                    L5 = myFormFiltros.Txt_DescripL5.Text
                End If
                If myFormFiltros.Txt_DescripL6.Text = "" Then
                    L6 = ""
                Else
                    L6 = myFormFiltros.Txt_DescripL6.Text
                End If

                If FechaInv <> FecHora.ToString("yyyy-MM-dd") Then
                    'Call GeneraNomTablaExist(FechaInv)
                    '  Call InventarioAnterior()
                Else
                    NomTablaExist = ""
                    strQueryInv = ""
                End If


                Call RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
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
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub Btn_Series_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim myForm As New frmConsultaSeries

            ' myForm.Tipo = "A"

            myForm.Sucursal = Sucursal
            'myForm.Division = Division
            myForm.Depto = Depto
            myForm.Familia = Familia
            myForm.Linea = Linea

            myForm.l1 = L1
            myForm.l2 = L2
            myForm.l3 = L3
            myForm.l4 = L4
            myForm.l5 = L5
            myForm.l6 = L6






            myForm.ShowDialog()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub

    Private Sub Btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Imprimir.Click

        Dim myForm As New frmReportsBrowser
        myForm.objDataSetExistenciaActual = GenerarExistenciaActual()
        myForm.ReportIndex = 5523
        myForm.Show()
    End Sub

    Private Function GenerarExistenciaActual() As DSEstrucExistenActual

        Try
            GenerarExistenciaActual = New DSEstrucExistenActual
            With DGrid
                For I As Integer = 0 To .Rows.Count - 2

                    Dim objDataRow1 As Data.DataRow = GenerarExistenciaActual.Tables("Tbl_ExistenciaActual").NewRow()

                    objDataRow1.Item("division") = DGrid.Rows(I).Cells("DIVISION").Value.ToString
                    objDataRow1.Item("depto") = DGrid.Rows(I).Cells("DEPTO").Value.ToString
                    objDataRow1.Item("l1") = DGrid.Rows(I).Cells("L1").Value.ToString
                    objDataRow1.Item("marca") = DGrid.Rows(I).Cells("MARCA").Value.ToString
                    objDataRow1.Item("modelo") = DGrid.Rows(I).Cells("MODELO").Value.ToString
                    objDataRow1.Item("recibo") = DGrid.Rows(I).Cells("recibo").Value.ToString
                    objDataRow1.Item("exist") = DGrid.Rows(I).Cells("EXIST").Value.ToString
                    




                    GenerarExistenciaActual.Tables("Tbl_ExistenciaActual").Rows.Add(objDataRow1)
                Next

            End With
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function


End Class