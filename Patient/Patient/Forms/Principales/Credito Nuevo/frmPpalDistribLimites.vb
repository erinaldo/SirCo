Public Class frmPpalDistribLimites
    'mreyes 06/Junio/2017   12:25 p.m.

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
        'mreyes 06/Junio/2017   12:25 p.m.
        DGrid.Visible = False
        'InicializaGrid()
        Using objTrasp As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                'DGrid.ReadOnly = True
                DGrid.DataSource = Nothing

                objDataSet = objTrasp.usp_PpalDistribLimites()

                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section 
                    'DGrid.ColumnCount = objDataSet.Tables(0).Columns.Count
                    '
                    DGrid.DataSource = objDataSet.Tables(0)
                    InicializaGrid()

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

    'Private Sub AgregarColumna()
    '    Try
    '        Dim colImagen As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()

    '        ' colImagen.Frozen = True
    '        colImagen.Name = "Select"
    '        colImagen.HeaderText = "Select"
    '        colImagen.DisplayIndex = 12
    '        colImagen.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
    '        colImagen.CellTemplate = New DataGridViewCheckBoxCell()

    '        DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
    '        ''DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
    '        Me.DGrid.Columns.Add(colImagen)


    '    Catch ExceptionErr As Exception
    '        MessageBox.Show(ExceptionErr.Message.ToString)
    '    End Try
    'End Sub
    Sub InicializaGrid()
        'mreyes 08/Septiembre/2016  04:53 p.m.

        Try
            
            GridView1.Columns(0).Caption = "Distrib"
            GridView1.Columns(1).Caption = "Nombre"
            GridView1.Columns(2).Caption = "Fecha"
            GridView1.Columns(3).Caption = "Limite"
            GridView1.Columns(4).Caption = "Disponible"
            GridView1.Columns(5).Caption = "Venta"
            GridView1.Columns(6).Caption = "Aumento"
            GridView1.Columns(7).Caption = "Nuevo Limite"
            GridView1.Columns(8).Caption = "NuevoLimModif"
            GridView1.Columns(9).Caption = "Teléfono 1"
            GridView1.Columns(10).Caption = "Teléfono 2"
            GridView1.Columns(11).Caption = "Teléfono 3"


            GridView1.Columns(2).Visible = False
            GridView1.Columns(5).Visible = False
            GridView1.Columns(8).Visible = False

            GridView1.Columns(0).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(2).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(9).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(10).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(11).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            'DGrid.Columns(3).DefaultCellStyle.Format = "c"
            'DGrid.Columns(4).DefaultCellStyle.Format = "c"
            'DGrid.Columns(5).DefaultCellStyle.Format = "c"
            'DGrid.Columns(6).DefaultCellStyle.Format = "c"
            'DGrid.Columns(7).DefaultCellStyle.Format = "c"
            'DGrid.Columns(8).DefaultCellStyle.Format = "c"


            'AgregarColumna()


            GridView1.OptionsView.ColumnAutoWidth = False
            GridView1.OptionsView.ShowAutoFilterRow = True
            GridView1.OptionsView.ShowFooter = True

            GridView1.BestFitColumns()

            For I As Integer = 0 To GridView1.Columns.Count - 1

                GridView1.Columns(I).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns(I).AppearanceHeader.Font = New Font(GridView1.Columns(I).AppearanceCell.Font, FontStyle.Bold)
                'GridView1.Columns(I).OptionsColumn.ReadOnly = True
            Next


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Btn_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Excel.Click
        'Try
        '    If ExportarDGridAExcel(DGrid) = False Then
        '        MsgBox("Error al exportar a Excel. Intente nuevamente.", MsgBoxStyle.Critical, "Excel")
        '    End If
        'Catch ExceptionErr As Exception
        '    MessageBox.Show(ExceptionErr.Message.ToString)
        'End Try
        If sfdRuta.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            DGrid.ExportToXls(sfdRuta.FileName)
        End If
    End Sub

    Private Sub frmPpalPpalDetFactProv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Filtro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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


    Private Sub Btn_Series_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim myForm As New frmSeriesNoTraspaso

        myForm.ShowDialog()

        Call RellenaGrid()
    End Sub

    Private Sub Btn_InvertirSeleccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_InvertirSeleccion.Click
        If Sw_NoRegistros = False Then Exit Sub
        Call Selecciona()
    End Sub

    Private Sub Selecciona()
        'mreyes 6 / Junio / 2017   04:  21 p.m.
        Me.Cursor = Cursors.AppStarting
        DGrid.Visible = False
        For i As Integer = 0 To GridView1.RowCount - 1
            'If GridView1.IsRowSelected(i) = True Then
            GridView1.InvertRowSelection(i)
        Next

        DGrid.Visible = True
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Btn_NoPropuesta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Sw_Pintar = False
            If sw_liq = False Then
                If MessageBox.Show("Estas seguro de eliminar las filas seleccionadas de la liquidación. ?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            For i As Integer = 0 To GridView1.RowCount - 2
                '' Eliminar de liquidación DESCOMENTAR
                'If DGrid.Rows(i).Cells("Liq").Value = True Then
                '    If usp_Elimina_LiqAutomatica(DGrid.Rows(i).Cells("marca").Value, DGrid.Rows(i).Cells("estilon").Value) Then
                '        Sw_Pintar = False
                '    End If
                'End If

            Next
            'DGrid.Columns.Remove("Liq") DESCOMENTAR

            Call RellenaGrid()
            Sw_Pintar = True
            Me.Cursor = Cursors.Default


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        'mreyes 06/Junio/2017   04:22 p.m.
        Try
            Dim Renglon As Integer = 0
            Dim intposicion As Integer = 0
            Dim inttotalrows As Integer = 0
            Dim Distrib As String = ""
            Dim Fecha As Date
            Dim NuevoLimite As Decimal = 0


            If MsgBox("Esta seguro de confirmar el cambio de Limites.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmación") = MsgBoxResult.No Then Exit Sub

            Me.Cursor = Cursors.WaitCursor

            '' invertir.. 
            '' luego borrar..
            sw_liq = True

            For i As Integer = 0 To GridView1.RowCount - 1


                If GridView1.IsRowSelected(i) = True Then

                    'If GridView1.GetRowCellValue(i, "Select") = True Then
                    Distrib = GridView1.GetRowCellValue(i, "distrib")
                    Fecha = GridView1.GetRowCellValue(i, "fecha")
                    NuevoLimite = GridView1.GetRowCellValue(i, "nuevolimite")
                    If usp_AumentoLimite(2, Distrib, Fecha, NuevoLimite, GLB_Idempleado) = False Then

                    End If
                End If
            Next


            Me.Cursor = Cursors.Default

            MsgBox("Proceso de Autorización terminado", MsgBoxStyle.Information, "Aviso")

            '' rellenar otra vez
            Call RellenaGrid()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Function usp_AumentoLimite(Opcion As Integer, Distrib As String, ByVal Fecha As Date, NuevoLimite As Decimal, idusuario As Integer) As Boolean
        'mreyes 06/Junio/2017   04:23 p.m.


        Using objCalculo As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
            Try
                'Get the specific project selected in the ListView controlsu

                Application.DoEvents()

                usp_AumentoLimite = objCalculo.usp_AumentoLimite(Opcion, Distrib, Fecha, NuevoLimite, idusuario)


                Application.DoEvents()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function
    Private Function usp_GeneraProTraspArticulo() As Boolean
        'mreyes 23/Febrero/2012 03:47 p.m.

        Using objCalculo As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
            Try
                'Get the specific project selected in the ListView controlsu
                Dim Marca As String = ""
                Application.DoEvents()


                usp_GeneraProTraspArticulo = objCalculo.usp_GeneraProTraspArticulo("0", "       ", "0", "0", "", "", "", "", "", "", "", "", 100, GLB_Idempleado, 1)

                Application.DoEvents()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function
    Private Function usp_Captura_LiqAutomatica(ByVal Marca As String, ByVal Estilon As String, ByVal Regaladn As Integer, ByVal Porc As Integer, ByVal Contado As Integer, ByVal Credito As Integer, ByVal Tipo As String) As Boolean
        'mreyes 12/Septiembre/2016  10:42 a.m.
        '@regaladn int, @porc int, @contado int, @credito int 

        Using objCalculo As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
            Try
                'Get the specific project selected in the ListView controlsu

                Application.DoEvents()

                usp_Captura_LiqAutomatica = objCalculo.usp_Captura_LiqAutomatica(2, Marca, Estilon, Regaladn, Porc, Contado, Credito, Tipo)




                Application.DoEvents()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function
    Private Function usp_Elimina_LiqAutomatica(ByVal Marca As String, ByVal Estilon As String) As Boolean
        'mreyes 12/Septiembre/2016  10:24 a.m.


        Using objCalculo As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
            Try
                'Get the specific project selected in the ListView controlsu

                Application.DoEvents()

                usp_Elimina_LiqAutomatica = objCalculo.usp_Elimina_LiqAutomatica(Marca, Estilon)




                Application.DoEvents()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function
    Private Function usp_GeneraLiqAutomatica() As Boolean
        'mreyes 19/Septiembre/2016  04:15 p.m.

        '  Dim FechFin As Date = "12/09/2019"

        Using objCalculo As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
            Try
                'Get the specific project selected in the ListView controlsu

                Application.DoEvents()

                usp_GeneraLiqAutomatica = objCalculo.usp_GeneraLiqAutomatica(GLB_Idempleado)




                Application.DoEvents()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function


    Private Sub DGrid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub DGrid_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs)
        Dim validar As TextBox = CType(e.Control, TextBox)
        Try
            ' agregar el controlador de eventos para el KeyPress   
            AddHandler validar.KeyPress, AddressOf validar_Keypress
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'mreyes 12/Septiembre/2016  10:18 a.m.

        Try
            ' obtener indice de la columna  
            e.KeyChar = UCase(e.KeyChar)
            'DESCOMENTAR
            'Dim columna As Integer =  DGrid.CurrentCell.ColumnIndex

            'Dim renglon As Integer = DGrid.CurrentCell.RowIndex
            Dim caracter As Char = e.KeyChar
            Dim CaracterAnt As String = ""

            'If columna >= 10 And columna <= 13 Then


            '    If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
            '        e.KeyChar = Chr(0)
            '    End If



            'End If



        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub ToolStripMenuItemAnaModelo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemAnaModelo.Click
        Try
            Dim myForm As New frmAnalisisModelo
            'DESCOMENTAR
            'myForm.Txt_Marca.Text =  DGrid.CurrentRow.Cells("Marca").Value
            'myForm.Txt_Modelo.Text = DGrid.CurrentRow.Cells("estilon").Value
            myForm.Accion = 1
            myForm.WindowState = FormWindowState.Maximized
            myForm.Show()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Filtro_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            frmFiltrosLiqAutomatica.StartPosition = FormStartPosition.CenterParent
            frmFiltrosLiqAutomatica.Sw_Filtro = False

            If Division <> "" Then
                If Division = "CALZADO" Then
                    frmFiltrosLiqAutomatica.Txt_Division.Text = "001"
                ElseIf Division = "ACCESORIOS" Then
                    frmFiltrosLiqAutomatica.Txt_Division.Text = "002"
                ElseIf Division = "ELECTRONICA" Then
                    frmFiltrosLiqAutomatica.Txt_Division.Text = "003"
                ElseIf Division = "GENERAL" Then
                    frmFiltrosLiqAutomatica.Txt_Division.Text = "999"
                End If
                frmFiltrosLiqAutomatica.Txt_DescripDivision.Text = Division
            Else
                frmFiltrosLiqAutomatica.Txt_DescripDivision.Text = ""
                frmFiltrosLiqAutomatica.Txt_Division.Text = ""
            End If
            If Depto <> "" Then
                frmFiltrosLiqAutomatica.Txt_IdDepto.Text = Depto
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstDepto(0, 0, "", 0, Depto)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    frmFiltrosLiqAutomatica.Txt_DescripDepto.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                    frmFiltrosLiqAutomatica.Txt_Depto.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                End If
            End If
            If Familia <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstFamilia(0, 0, 0, "", 3, Familia)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    frmFiltrosLiqAutomatica.Txt_Familia.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    frmFiltrosLiqAutomatica.Txt_DescripFamilia.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If Linea <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstLinea(0, 0, 0, 0, "", 3, Linea)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    frmFiltrosLiqAutomatica.Txt_Linea.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    frmFiltrosLiqAutomatica.Txt_DescripLinea.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L1 <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl1(0, 0, 0, 0, 0, "", 3, L1)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    frmFiltrosLiqAutomatica.Txt_L1.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    frmFiltrosLiqAutomatica.Txt_DescripL1.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L2 <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl2(0, 0, 0, 0, 0, 0, "", 3, L2)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    frmFiltrosLiqAutomatica.Txt_L2.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    frmFiltrosLiqAutomatica.Txt_DescripL2.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L3 <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl3(0, 0, 0, 0, 0, 0, 0, "", 3, L3)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    frmFiltrosLiqAutomatica.Txt_L3.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    frmFiltrosLiqAutomatica.Txt_DescripL3.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L4 <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl4(0, 0, 0, 0, 0, 0, 0, 0, "", 3, L4)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    frmFiltrosLiqAutomatica.Txt_L4.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    frmFiltrosLiqAutomatica.Txt_DescripL4.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L5 <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl5(0, 0, 0, 0, 0, 0, 0, 0, 0, "", 3, L5)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    frmFiltrosLiqAutomatica.Txt_L5.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    frmFiltrosLiqAutomatica.Txt_DescripL5.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L6 <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl6(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", 3, L6)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    frmFiltrosLiqAutomatica.Txt_L6.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    frmFiltrosLiqAutomatica.Txt_DescripL6.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If Marca <> "" Then
                frmFiltrosLiqAutomatica.Txt_Marca.Text = Marca
            End If
            frmFiltrosLiqAutomatica.ShowDialog()
            If frmFiltrosLiqAutomatica.Sw_Filtro = True Then
                DGrid.DataSource = Nothing
                DGrid.Refresh()
                'DECOMENTAR
                'DGrid.Rows.Clear()




                Marca = frmFiltrosLiqAutomatica.Txt_Marca.Text
                'If Marca.Trim <> "" Then
                '    lbl_Marca.Text = Marca
                'End If

                If frmFiltrosLiqAutomatica.Txt_DescripDivision.Text.Trim = "" Then
                    Division = ""
                Else
                    Division = frmFiltrosLiqAutomatica.Txt_DescripDivision.Text
                End If
                If frmFiltrosLiqAutomatica.Txt_DescripDepto.Text.Trim = "" Then
                    Depto = ""
                Else
                    Depto = frmFiltrosLiqAutomatica.Txt_DescripDepto.Text
                End If
                If frmFiltrosLiqAutomatica.Txt_DescripFamilia.Text = "" Then
                    Familia = ""
                Else
                    Familia = frmFiltrosLiqAutomatica.Txt_DescripFamilia.Text
                End If
                If frmFiltrosLiqAutomatica.Txt_DescripLinea.Text = "" Then
                    Linea = ""
                Else
                    Linea = frmFiltrosLiqAutomatica.Txt_DescripLinea.Text
                End If
                If frmFiltrosLiqAutomatica.Txt_DescripL1.Text = "" Then
                    L1 = ""
                Else
                    L1 = frmFiltrosLiqAutomatica.Txt_DescripL1.Text
                End If
                If frmFiltrosLiqAutomatica.Txt_DescripL2.Text = "" Then
                    L2 = ""
                Else
                    L2 = frmFiltrosLiqAutomatica.Txt_DescripL2.Text
                End If
                If frmFiltrosLiqAutomatica.Txt_DescripL3.Text = "" Then
                    L3 = ""
                Else
                    L3 = frmFiltrosLiqAutomatica.Txt_DescripL3.Text
                End If
                If frmFiltrosLiqAutomatica.Txt_DescripL4.Text = "" Then
                    L4 = ""
                Else
                    L4 = frmFiltrosLiqAutomatica.Txt_DescripL4.Text
                End If
                If frmFiltrosLiqAutomatica.Txt_DescripL5.Text = "" Then
                    L5 = ""
                Else
                    L5 = frmFiltrosLiqAutomatica.Txt_DescripL5.Text
                End If
                If frmFiltrosLiqAutomatica.Txt_DescripL6.Text = "" Then
                    L6 = ""
                Else
                    L6 = frmFiltrosLiqAutomatica.Txt_DescripL6.Text
                End If

                'DESCOMENTAR
                'DGrid.Columns.Remove("Liq")

                Call RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub GridView1_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanging
        ' DGrid_CellBeginEdit

        Dim renglon As Integer = GridView1.GetDataSourceRowIndex(e.RowHandle)

        Dim NuevoLimite As Decimal = 0

        'NuevoLimite = DGrid.Rows(renglon).Cells("nuevolimite").Value
        NuevoLimite = GridView1.GetRowCellValue(renglon, "nuevolimite")
        If GridView1.GetRowCellValue(renglon, "nuevolimitemodif") = 0 Then
            GridView1.SetRowCellValue(renglon, "nuevolimitemodif", NuevoLimite)
        End If
    End Sub


End Class

