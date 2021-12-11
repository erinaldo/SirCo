Public Class frmPpalAparador
    'mreyes 24/Abril/2015   10:14 a.m.

    Private objDataSet As Data.DataSet
    Private FecReciIniB As String
    Private FecReciFinB As String
    Private EstilonB As String = ""
    Private MarcaB As String = ""
    Private SucursalB As String = ""
    Private idusuarioinicialapab As Integer = 0
    Private izquierda As Integer = 0
    Private alto As Integer = 0

    Dim ProveedorB As String
    Dim blnBindingOff As Boolean = False
    Dim blnBorrarCad As Boolean = False

    Dim Sw_Load As Boolean = True
    Dim Sw_NoRegistros As Boolean = False
    Dim Sw_Pintar As Boolean = False

    Private Sub frmPpalEstilosSinExist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        Call LimpiarBusqueda()
        FecReciIniB = Format(DateSerial(Now.Year, Now.Month, 1), "yyyy-MM-dd")
        ' FechaEInib = Format(DateSerial(Now.Year, Now.Month, 1), "yyyy-MM-dd")
        FecReciFinB = Format(Now.Date, "yyyy-MM-dd")
        If GLB_CveSucursal <> "" Then
            If GLB_AccesoEmpleado = False Then
                SucursalB = ""
            Else
                SucursalB = GLB_CveSucursal
                If SucursalB = "95" Or SucursalB = "96" Then SucursalB = ""
            End If


        End If
        Call RellenaGrid()
        Sw_Pintar = True
        'Sw_Load = False 
        Sw_Load = True
    End Sub

    Private Sub frmPpalEstilosSinExist_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Sw_NoRegistros = False Then Exit Sub
        If Sw_Load = True Then
            Sw_Load = False
            InicializaGrid()
            'AgregarColumna()
            '    Call BarrerGrid()
        End If
    End Sub

    Private Sub GenerarToolTip()
        Try

            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub LimpiarBusqueda()

        FecReciFinB = "1900-01-01"
        FecReciFinB = "1900-01-01"
        ProveedorB = ""
    End Sub

    Private Sub RellenaGrid()
        'mreyes 24/Abril/2015   10:16 a.m.
        Using objDiasResProv As New BCL.BCLAparador(GLB_ConStringCipSis)

            Try
                Me.Cursor = Cursors.WaitCursor
                'DGrid.ReadOnly = True
                DGrid.DataSource = Nothing

                If Sw_Load = True Then
                    ' Sw_Load = False 
                Else
                    If Sw_NoRegistros = True Then
                        DGrid.Columns.Remove("Selec")
                    End If
                End If

                objDataSet = objDiasResProv.usp_PpalAparador(SucursalB, MarcaB, EstilonB, FecReciIniB, FecReciFinB, idusuarioinicialapab)

                'Populate the Project Details section
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
                    'Call Colores()
                Else
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron registros que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                End If
                Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Sub InicializaGrid()
        Try

            DGrid.RowHeadersVisible = False
            DGrid.Columns(0).HeaderText = "Det."
            DGrid.Columns(1).HeaderText = "Sucursal"
            DGrid.Columns(2).HeaderText = "Marca"
            DGrid.Columns(3).HeaderText = "Modelo"
            DGrid.Columns(4).HeaderText = "C"
            DGrid.Columns(5).HeaderText = "Precio"
            DGrid.Columns(6).HeaderText = "Fecha Recibo"
            DGrid.Columns(7).HeaderText = "Fum Recibo"
            DGrid.Columns(8).HeaderText = "Fum Aparador"
            DGrid.Columns(9).HeaderText = "Usuario Aparador"
            DGrid.Columns(10).HeaderText = "Observaciones"


            DGrid.Columns(6).Visible = False
            'DGrid.Columns(8).Visible = False

            DGrid.Columns(0).ReadOnly = True
            DGrid.Columns(1).ReadOnly = True
            DGrid.Columns(2).ReadOnly = True
            DGrid.Columns(3).ReadOnly = True
            DGrid.Columns(4).ReadOnly = True
            DGrid.Columns(5).ReadOnly = True
            DGrid.Columns(7).ReadOnly = True
            DGrid.Columns(8).ReadOnly = True
            DGrid.Columns(9).ReadOnly = True

            DGrid.Columns(10).ReadOnly = False


            'DGrid.Columns(8).ReadOnly = True

            
            'DGrid.Columns(4).DefaultCellStyle.Format = "dd-MMM-yyyy"
            'DGrid.Columns(6).DefaultCellStyle.Format = "dd-MMM-yyyy"
            DGrid.Columns(5).DefaultCellStyle.Format = "c"
            DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            Call AgregarColumna()



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

    Private Sub frmPpalEstilosSinExist_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub AgregarColumna()
        Dim colSelec As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        colSelec.Name = "Selec"
        colSelec.HeaderText = "Selec"
        colSelec.DisplayIndex = 11
        colSelec.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        colSelec.CellTemplate = New DataGridViewCheckBoxCell()
        ' añadir columna de imagen a la coleccion del grid 
        DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        ''DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DGrid.Columns.Add(colSelec)
    End Sub



    Private Sub Btn_Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim intContador As Integer = 0
        Dim intContadorMovs As Integer = 0
        Try

            For Each row As DataGridViewRow In DGrid.Rows
                If row.Cells("Selec").Value = True Then
                    intContador += 1
                End If
            Next

            If intContador = 0 Then
                MsgBox("No se selecciono ningun Registro para Actualizar", MsgBoxStyle.OkOnly, "Aviso")
                Exit Sub
            End If

            If MsgBox("Desea Modificar los días de Resurtido de los registros seleccionados?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub

            For i As Integer = 0 To DGrid.Rows.Count - 1
                If DGrid.Rows(i).Cells("Selec").Value = True Then
                    Dim Proveedor As String = DGrid.Rows(i).Cells("proveedor").Value
                    Dim Marca As String = DGrid.Rows(i).Cells("marca").Value
                    Dim Estilon As String = DGrid.Rows(i).Cells("estilon").Value
                    Dim DiasRes As Integer = DGrid.Rows(i).Cells("diasresurtido").Value

                    If DGrid.Rows(i).Cells("estilon").Value = "" Then
                        Marca = ""
                    End If

                    Using objDiasResProv As New BCL.BCLDiasResProv(GLB_ConStringCipSis)
                        objDiasResProv.usp_ActualizaDiasResProv(Proveedor, Marca, Estilon, DiasRes)
                    End Using
                    intContadorMovs += 1
                End If
            Next

            If intContadorMovs = 0 Then
                MsgBox("No se actualizó ningun registro.", MsgBoxStyle.OkOnly, "Aviso")
                Exit Sub
            Else
                MsgBox("Los registros se actualizaron correctamente.", MsgBoxStyle.Information, "Confirmación")
            End If

            Call RellenaGrid()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.Click
        If IsDBNull(DGrid.CurrentRow.Cells("Marca").Value) Then
            PBox.Visible = False
        Else
            PBox.Visible = True
            CargarFotoArticulo(DGrid.CurrentRow.Cells("Marca").Value, DGrid.CurrentRow.Cells("Modelo").Value)
        End If
    End Sub

   
  

   
    Private Sub DGrid_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles DGrid.EditingControlShowing
        Try
            Dim validar As TextBox = CType(e.Control, TextBox)
            AddHandler validar.KeyPress, AddressOf validar_Keypress

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub




    Private Sub validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ' obtener indice de la columna 
        Dim columna As Integer = DGrid.CurrentCell.ColumnIndex
        ' comprobar si la celda en edicin corresponde a la columna 0 o 1
        Dim caracter As Char = e.KeyChar
        Dim strval As String = DGrid.CurrentCell.EditedFormattedValue.ToString

        Try
            If columna = 5 Then
                If Not Char.IsNumber(caracter) Then
                    e.Handled = True
                Else
                    e.Handled = False
                End If
            End If
            If columna = 5 Then

                'If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False And (caracter = ChrW(Keys.Enter)) = False _
                'And (caracter = ChrW(Keys.Tab)) Then
                If Char.IsNumber(caracter) Or (caracter = ChrW(Keys.Back)) = True Or (caracter = ChrW(Keys.Enter)) = True _
                Or (caracter = ChrW(Keys.Tab)) = True Then
                    'Me.Text =
                    'e.KeyChar = Chr(0)
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub NuevoEstilo(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call NuevoEstilo(sender, e)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub EliminarEstilo()
        Try
            Call EliminarEstilo()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

   

    Private Sub DGrid_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DGrid.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With Me.DGrid
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If
    End Sub

   

   


    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub

    Private Sub Btn_Activas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Activas.Click
        Dim intContador As Integer = 0
        Dim intContadorMovs As Integer = 0
        Try

            For Each row As DataGridViewRow In DGrid.Rows
                If row.Cells("Selec").Value = True Then
                    intContador += 1
                End If
            Next

            If intContador = 0 Then
                MsgBox("No se selecciono ningun Registro para Actualizar", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            End If

            If MsgBox("Desea Modificar la Fecha de Colocación en Aparador del Modelo Seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub

            For i As Integer = 0 To DGrid.Rows.Count - 1
                If DGrid.Rows(i).Cells("Selec").Value = True And DGrid.Rows(i).Cells("USUAPARADOR").Value = "" Then
                    Dim Sucursal As String = DGrid.Rows(i).Cells("sucursal").Value
                    Dim Marca As String = DGrid.Rows(i).Cells("marca").Value
                    Dim Estilon As String = DGrid.Rows(i).Cells("modelo").Value
                    Dim Corrida As String = DGrid.Rows(i).Cells("corrida").Value
                    Dim Observaciones As String = DGrid.Rows(i).Cells("observaciones").Value



                    Using objDiasResProv As New BCL.BCLAparador(GLB_ConStringCipSis)
                        objDiasResProv.usp_ActualizaAparador(1, Sucursal, Marca, Estilon, Corrida, GLB_Idempleado, Observaciones)
                    End Using
                    intContadorMovs += 1
                ElseIf DGrid.Rows(i).Cells("Selec").Value = True And DGrid.Rows(i).Cells("USUAPARADOR").Value <> "" Then
                    Dim Sucursal As String = DGrid.Rows(i).Cells("sucursal").Value
                    Dim Marca As String = DGrid.Rows(i).Cells("marca").Value
                    Dim Estilon As String = DGrid.Rows(i).Cells("modelo").Value
                    Dim Corrida As String = DGrid.Rows(i).Cells("corrida").Value
                    Dim Observaciones As String = DGrid.Rows(i).Cells("observaciones").Value

                    Using objDiasResProv As New BCL.BCLAparador(GLB_ConStringCipSis)
                        objDiasResProv.usp_ActualizaAparador(2, Sucursal, Marca, Estilon, Corrida, GLB_Idempleado, Observaciones)
                    End Using
                    intContadorMovs += 1
                End If
            Next

            If intContadorMovs = 0 Then
                MsgBox("No se actualizó ningun registro.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Aviso")
                Exit Sub
            Else
                MsgBox("Los registros se actualizaron correctamente.", MsgBoxStyle.Information, "Confirmación")
            End If

            Call RellenaGrid()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Filtro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        'mreyes 24/Abril/2015   05:21 p.m.
        Dim myForm As New frmFiltrosAparador

        myForm.Txt_Marca.Text = MarcaB
        myForm.Txt_Estilon.Text = EstilonB
        myForm.Txt_Sucursal.Text = SucursalB
        If GLB_CveSucursal <> "" Then
            myForm.Txt_Sucursal.Enabled = False

        End If

        If FecReciIniB <> "1900-01-01" Then
            myForm.Chk_FechaOrden.Checked = True
            myForm.DTPicker2.Value = FecReciIniB
            myForm.DTPicker3.Value = FecReciFinB
        End If

        myForm.ShowDialog()
        MarcaB = myForm.Txt_Marca.Text
        EstilonB = myForm.Txt_Estilon.Text


        If myForm.Chk_FechaOrden.Checked = True Then
            FecReciIniB = Format(myForm.DTPicker2.Value, "yyyy-MM-dd")
            FecReciFinB = Format(myForm.DTPicker3.Value, "yyyy-MM-dd")
        Else
            FecReciIniB = "1900-01-01"
            FecReciFinB = "1900-01-01"

        End If
        SucursalB = myForm.Txt_Sucursal.Text

        If myForm.Sw_Filtro = True Then
            Call RellenaGrid()
        End If
    End Sub

    Private Sub Btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Imprimir.Click
        'mreyes 24/Abril/2015   12:38 p.m.
        Dim myForm As New frmReportsBrowser

        myForm.objDataSetPpalAparador = GenerarReporteAparador()
        myForm.ReportIndex = 8454
        myForm.Show()
    End Sub


    Private Function GenerarReporteAparador() As DSAparador
        'mreyes 24/Abril/2015   12:47 p.m.
        Try
            GenerarReporteAparador = New DSAparador
            With DGrid
                For I As Integer = 0 To .Rows.Count - 2

                    Dim objDataRow As Data.DataRow = GenerarReporteAparador.Tables(0).NewRow()
                    objDataRow.Item("det") = .Rows(I).Cells("sucursal").Value
                    objDataRow.Item("sucursal") = .Rows(I).Cells("descrip").Value
                    objDataRow.Item("marca") = .Rows(I).Cells("marca").Value
                    objDataRow.Item("modelo") = .Rows(I).Cells("modelo").Value
                    objDataRow.Item("corrida") = .Rows(I).Cells("corrida").Value
                    objDataRow.Item("precio") = .Rows(I).Cells("precio").Value

                    objDataRow.Item("fecreci") = .Rows(I).Cells("fecreci").Value
                    objDataRow.Item("fumrecibo") = .Rows(I).Cells("fumrecibo").Value
                    objDataRow.Item("fumaparador") = .Rows(I).Cells("fuminicialapa").Value
                    objDataRow.Item("usuarioaparador") = .Rows(I).Cells("USUAPARADOR").Value


                    GenerarReporteAparador.Tables(0).Rows.Add(objDataRow)
                Next

            End With
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function
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
    Private Sub CargarFotoArticulo(ByVal Marca As String, ByVal Estilon As String)
        'mreyes 14/Marzo/2012 07:06 p.m.
        'Glb_RutaArchivoFotos
        Try
            Dim Archivo As String = ""
            Dim NoFoto As String = "1"


            PBox.Visible = False
            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)

                Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Marca, pub_RellenarEspaciosIzquierda(Estilon, 7), NoFoto)

                If objIO.pub_ExisteArchivo(Archivo) = True Then
                    PBox.Image = New System.Drawing.Bitmap(Archivo)
                    PBox.Visible = True
                    Exit Sub


                End If

                For i As Integer = 0 To 9
                    Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Marca, pub_RellenarEspaciosIzquierda(Estilon, 7), i)
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

    Private Sub DGrid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGrid.KeyUp
        Try


            If IsDBNull(DGrid.CurrentRow.Cells("Marca").Value) Then
                PBox.Visible = False
            Else
                PBox.Visible = True
                CargarFotoArticulo(DGrid.CurrentRow.Cells("Marca").Value, DGrid.CurrentRow.Cells("Modelo").Value)
            End If
            
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_InvertirSeleccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_InvertirSeleccion.Click
        If Sw_NoRegistros = False Then Exit Sub
        Call Factura_Microsip()
    End Sub

    Private Sub Factura_Microsip()
        'mreyes 21/Marzo/2012 11:53 a.m.
        For Each row As DataGridViewRow In DGrid.Rows
            If row.Cells("Selec").Value = True Then
                row.Cells("Selec").Value = False
            Else
                row.Cells("Selec").Value = True
            End If
        Next

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_LeerSeries.Click
        'mreyes 28/Abril/2015   10:12 a.m.
        Dim myForm As New frmLeerAparador

       

        myForm.ShowDialog()
       

        If myForm.Sw_Filtro = True Then
            Call RellenaGrid()
        End If
    End Sub
End Class