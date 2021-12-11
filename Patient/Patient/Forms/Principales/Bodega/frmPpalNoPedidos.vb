Public Class frmPpalNoPedidos
    'mreyes 12/Mayo/2017    07:13 p.m.

    Private objDataSet As Data.DataSet
    Private objDataSet1 As Data.DataSet 'Segundo Nivel


    Dim FechaFinB As String = "1900-01-01"
    Dim FechaIniB As String = "1900-01-01"
    Dim SucursalB As String = ""




    Dim EstatusB As String = "1900-01-01"
    Dim TraspasoIniB As String = "1900-01-01"
    Dim TraspasoFinB As String = "1900-01-01"
    Dim Opcion As Integer

    Dim MarcaFOTO As String = ""
    Dim EstiloNFOTO As String = ""
    Dim blnEntraDet As Boolean = False

    Private izquierda As Integer = 0
    Private alto As Integer = 0
    Dim Sw_Load As Boolean = False
    Dim Sw_Active As Boolean = False

    Public Sucursal As String = ""
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
    Dim idagrupacion As Integer = 0
    Private Sub RellenaGrid()
        'mreyes 12/Mayo/2017    07:15 p.m.


        Using objTrasp As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                DGrid.DataSource = Nothing
                DGrid.Visible = False
                objDataSet = objTrasp.usp_PpalNoMostrados(SucursalB, FechaIniB, FechaFinB, Division, Depto, Familia, Linea, L1, L2, L3, L4, L5, L6, Marca, Modelo, idagrupacion)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    DGrid.DataSource = objDataSet.Tables(0)
                    InicializaGrid()

                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True

                Else
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron registros que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                End If


                Me.Cursor = Cursors.Default
                DGrid.Visible = True
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Sub InicializaGrid()
        Try
            Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
            Dim row As DataRow = dt.NewRow()
            Dim Total As Decimal = 0.0

            Total = DGrid.Rows(0).Cells("venta").Value

            row(0) = ""
            row(1) = "Total:"

            row(3) = pub_SumarColumnaGrid(DGrid, 3, DGrid.RowCount - 1)


            dt.Rows.InsertAt(row, 0)
            DGrid.DataSource = dt
            'DGrid.Rows(1).DefaultCellStyle.Format = "#0.00"
            'Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
            'Dim row As DataRow = dt.NewRow()
            'row(0) = "TOTAL: "

            DGrid.RowHeadersVisible = False



            DGrid.Columns("marca").HeaderText = "Marca"
            DGrid.Columns("modelo").HeaderText = "Modelo"
            DGrid.Columns("propuesta").HeaderText = "Opción"
            DGrid.Columns("venta").HeaderText = "Venta"







            DGrid.Columns("marca").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns("propuesta").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns("venta").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter



            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)



            DGrid.Columns("marca").DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Columns("modelo").DefaultCellStyle.BackColor = Color.PowderBlue


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmPpalNoPedidos_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
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

    Private Sub frmPpalNoPedidos_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Sw_Load = True
            ' Call GenerarToolTip()

            Call LimpiarBusqueda()
            Division = "CALZADO"
            Lbl_Leyenda.Text = Division & "\" & Depto & "\" & Familia & "\" & Linea & "\" & L1 & "\" & L2 & "\" & L3 & "\" & L4 & "\" & L5 & "\" & L6 & " Fechas : " & FechaIniB & "-" & FechaFinB
            Call RellenaGrid()
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



        FechaIniB = Format(Now.Add(New TimeSpan(-1, 0, 0, 0)), "yyyy-MM-dd")
        FechaFinB = Format(Now.Add(New TimeSpan(-1, 0, 0, 0)), "yyyy-MM-dd")

    End Sub

    Private Sub frmPpalNoPedidos_Activated(sender As Object, e As EventArgs) Handles Me.Activated

        If Sw_Active = False Then
            DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

            DGrid.Columns("marca").DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Columns("modelo").DefaultCellStyle.BackColor = Color.PowderBlue

            Sw_Active = True
        End If
    End Sub

    Private Sub Btn_Filtro_Click(sender As Object, e As EventArgs) Handles Btn_Filtro.Click
        Try
            Dim myFormFiltros As New frmFiltrosNegBodega

            myFormFiltros.StartPosition = FormStartPosition.CenterParent
            myFormFiltros.Sw_Filtro = False


            'myFormFiltros.CB_Sucursal.Visible = False
            myFormFiltros.Suc = Sucursal
            'myFormFiltros.Label4.Visible = False


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

            If FechaIniB <> "1900-01-01" Then
                myFormFiltros.Chk_FechaTraspaso.Checked = True
                myFormFiltros.DTPicker2.Value = FechaIniB
                myFormFiltros.DTPicker3.Value = FechaFinB
            End If

            If idagrupacion <> 0 Then
                myFormFiltros.Txt_Agrupacion.Text = idagrupacion
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
                If Val(myFormFiltros.Txt_Agrupacion.Text) > 0 Then
                    idagrupacion = Val(myFormFiltros.Txt_Agrupacion.Text)
                End If

                Marca = myFormFiltros.Txt_Marca.Text


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

                If myFormFiltros.Chk_FechaTraspaso.Checked = True Then
                    FechaIniB = Format(myFormFiltros.DTPicker2.Value, "yyyy-MM-dd")
                    FechaFinB = Format(myFormFiltros.DTPicker3.Value, "yyyy-MM-dd")
                Else
                    FechaIniB = "1900-01-01"
                    FechaFinB = "1900-01-01"

                End If
                Lbl_Leyenda.Text = Division & "\" & Depto & "\" & Familia & "\" & Linea & "\" & L1 & "\" & L2 & "\" & L3 & "\" & L4 & "\" & L5 & "\" & L6 & " Fechas : " & FechaIniB & "-" & FechaFinB

                Call RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Excel.Click
        Try
            If ExportarDGridAExcel(DGrid) = False Then
                MsgBox("Error al exportar a Excel. Intente nuevamente.", MsgBoxStyle.Critical, "Excel")
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Salir_Click(sender As Object, e As EventArgs) Handles Btn_Salir.Click
        Me.Close()
        Me.Dispose()
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

    Private Sub DGrid_Click(sender As Object, e As EventArgs) Handles DGrid.Click
        CargarFotoArticulo(DGrid.Rows(DGrid.CurrentRow.Index).Cells("marca").Value, DGrid.Rows(DGrid.CurrentRow.Index).Cells("modelo").Value)

    End Sub

    Private Sub DGrid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGrid.KeyUp

        CargarFotoArticulo(DGrid.Rows(DGrid.CurrentRow.Index).Cells("marca").Value, DGrid.Rows(DGrid.CurrentRow.Index).Cells("modelo").Value)

    End Sub
End Class