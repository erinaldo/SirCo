Imports DevExpress.DashboardCommon
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Columns.GridColumn
Imports DevExpress.XtraGrid
Public Class frmPpalEmpleados
    'mreyes 15/Junio/2012 04:44 p.m.

    Private objDataSet As DataSet
    Dim Sw_NoRegistros As Boolean = False
    Dim idEmpleadoB As Integer = 0
    Dim idPercDeducB As Integer = 0
    Dim InicioIniB As String = ""
    Dim InicioFinB As String = ""
    Dim BajaIniB As String = ""
    Dim BajaFinB As String = ""
    Dim NacimIniB As String = ""
    Dim NacimFinB As String = ""

    Dim EstatusB As String = False
    Dim IdDeptoB As Integer = 0
    Dim IdPuestoB As Integer = 0
    Dim SucursalB As String = ""

    Dim Sw_Pintar As Boolean = False
    Dim Sw_Load As Boolean = True

    Dim bconn As Boolean
    Dim CZKEM1 As New zkemkeeper.CZKEM
    Dim dwEnrollNumber As Integer
    Dim dwVerifyMode As Integer
    Dim dwInOutMode As Integer
    Dim dwEMachineNumber As Integer
    Dim dwBackupNumber As Integer
    Dim dwEnable As Integer
    Dim dwMachinePrivilege As Integer
    Dim dwFingerIndex As Integer = 0
    Dim TmpLength As Integer
    Dim Checador_Id As Integer
    Dim Direccion_IP As String
    Dim Descripcion As String

    Public arreChecadores() As Integer
    Public arrEmpleados() As Integer
    Dim Sw_Tienda As Boolean
    Private Sub frmPpalRepetitivos_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If GLB_RefrescarPedido = True Then
            GLB_RefrescarPedido = False
            Call RellenaGrid()
            Me.WindowState = FormWindowState.Maximized
        End If

        If Sw_Load = True Then
            If Sw_NoRegistros = False Then
                Sw_Load = False
            Else
                Sw_Load = False
                InicializaGrid()
            End If
        End If
    End Sub

    Private Sub frmPpalProveedores_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If

        If e.KeyCode = Keys.F5 Then
            Call Btn_Filtro_Click_1(sender, e)
        End If
    End Sub

    Private Sub frmPpalProveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Call LimpiarBusqueda()
            Call RellenaGrid()
            Call GenerarToolTip()
            Sw_Pintar = True
            Sw_Load = True


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Nuevo, "Nuevo Empleado")
            ToolTip.SetToolTip(Btn_Editar, "Editar Empleado")
            ToolTip.SetToolTip(Btn_Eliminar, "Eliminar Empleado")
            ToolTip.SetToolTip(Btn_Consultar, "Consultar Empleado")
            ToolTip.SetToolTip(Btn_Filtro, "Búsqueda Avanzada")
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
            ToolTip.SetToolTip(Btn_Imprimir, "Imprimir Información")
            ToolTip.SetToolTip(Btn_RegistrarHuella, "Registrar las huellas de los empleados seleccionados")
            ToolTip.SetToolTip(Btn_RecolectarHuellas, "Recolecta las huellas de los checadores seleccionados")
            ToolTip.SetToolTip(Btn_EliminarHuellas, "Elimina las huellas del empleado seleccionado")
            ToolTip.SetToolTip(Btn_Salir, "Salir")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub RellenaGrid()
        'mreyes 11/Junio/2012 05:31 p.m.
        Using objRepetitivo As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)

            Try
                Me.Cursor = Cursors.WaitCursor
                'DGrid.ReadOnly = True
                Grido.DataSource = Nothing

                If Sw_Load = True Then
                    ' Sw_Load = False 
                    EstatusB = "A"
                Else
                    'If Sw_NoRegistros = True Then
                    '    GridView1.Columns("Huella").Dispose()
                    'End If
                End If

                If GLB_Idempleado = 1400 Then
                    SucursalB = ""
                    IdDeptoB = 3
                    ' IdPuestoB = 0
                End If

                objDataSet = objRepetitivo.usp_PpalCatalogoEmpleado(idEmpleadoB, SucursalB, IdDeptoB, IdPuestoB, EstatusB, InicioIniB, InicioFinB, BajaIniB, BajaFinB, NacimIniB, NacimFinB)
                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section

                    Grido.DataSource = objDataSet.Tables(0)
                    If Sw_Load = False Then
                        InicializaGrid()
                    End If
                    'LimpiarBusqueda()
                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True
                    Btn_Editar.Enabled = True
                    Btn_Consultar.Enabled = True
                    Sw_NoRegistros = True
                    Sw_Pintar = True
                Else
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron Empleados que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                    Btn_Editar.Enabled = False
                    Btn_Consultar.Enabled = False
                End If
                Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using


    End Sub

    Private Sub LimpiarBusqueda()

        Sw_Tienda = False
        idEmpleadoB = 0
        idPercDeducB = 0
        If GLB_CveSucursal <> "" Then
            SucursalB = GLB_CveSucursal
            EstatusB = "AC"
            Btn_RegistrarHuella.Enabled = False
            Btn_Eliminar.Enabled = False
            Btn_Nuevo.Enabled = False
            Btn_EliminarHuellas.Enabled = False
            Btn_RecolectarHuellas.Enabled = False
            Btn_Filtro.Enabled = False
            Sw_Tienda = True
            Btn_Consultar.Enabled = False
        Else
            SucursalB = ""
            EstatusB = ""
        End If

        IdDeptoB = 0
        IdPuestoB = 0
        InicioIniB = "1900-01-01"
        InicioFinB = "1900-01-01"
        BajaIniB = "1900-01-01"
        BajaFinB = "1900-01-01"

        NacimIniB = "1900-01-01"
        NacimFinB = "1900-01-01"

    End Sub

    Private Sub Btn_Refrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Sub InicializaGrid()
        '' marca, Estilon, Estilof, descripc, familia, linea, proveedor, tipoart, categoria
        'mreyes 17/Febrero/2011 11:02 p.m.
        Try

            GridView1.Columns(0).Caption = " Sucursal"
            GridView1.Columns(1).Caption = " IdEmpleado "
            GridView1.Columns(2).Caption = " Clave "
            GridView1.Columns(3).Caption = " Nombre Completo "
            GridView1.Columns(4).Caption = " IdDepto"
            GridView1.Columns(5).Caption = " Departamento"
            GridView1.Columns(6).Caption = " Id Puesto "
            GridView1.Columns(7).Caption = " Puesto "
            GridView1.Columns(8).Caption = " Fecha Ingreso "
            GridView1.Columns(9).Caption = " Fecha Baja "
            GridView1.Columns(10).Caption = " Estatus "
            GridView1.Columns(2).Visible = False
            GridView1.Columns(4).Visible = False
            GridView1.Columns(6).Visible = False


            For j As Integer = 0 To GridView1.Columns().Count - 1
                GridView1.Columns(j).OptionsColumn.ReadOnly = True
                GridView1.Columns(j).OptionsColumn.AllowEdit = False
                GridView1.Columns(j).AppearanceHeader.BackColor = Color.LightBlue
                GridView1.Columns(j).AppearanceHeader.TextOptions.HAlignment = HorizontalAlignment.Center

            Next
            'Dim sender As Object = Nothing
            'Dim e As RowCellStyleEventArgs = Nothing
            'If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Estatus") = "ACTIVO" Then
            '    Call ver(sender, e)
            'End If
            'If GridView1.Columns(0).Name = "Sucursal" Then
            '    Call bla(sender, e)
            'End If

            GridView1.Columns(0).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(1).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(2).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(8).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(9).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(10).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center

            GridView1.Columns(0).AppearanceHeader.Font = New Font(GridView1.Columns(0).AppearanceHeader.Font, FontStyle.Bold)
            GridView1.Columns(1).AppearanceHeader.Font = New Font(GridView1.Columns(1).AppearanceHeader.Font, FontStyle.Bold)
            GridView1.Columns(3).AppearanceHeader.Font = New Font(GridView1.Columns(3).AppearanceHeader.Font, FontStyle.Bold)
            GridView1.Columns(5).AppearanceHeader.Font = New Font(GridView1.Columns(5).AppearanceHeader.Font, FontStyle.Bold)
            GridView1.Columns(7).AppearanceHeader.Font = New Font(GridView1.Columns(7).AppearanceHeader.Font, FontStyle.Bold)
            GridView1.Columns(8).AppearanceHeader.Font = New Font(GridView1.Columns(8).AppearanceHeader.Font, FontStyle.Bold)
            GridView1.Columns(9).AppearanceHeader.Font = New Font(GridView1.Columns(9).AppearanceHeader.Font, FontStyle.Bold)
            GridView1.Columns(10).AppearanceHeader.Font = New Font(GridView1.Columns(10).AppearanceHeader.Font, FontStyle.Bold)
            Call AgregarColumna()
            GridView1.BestFitColumns()
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

    Private Sub Btn_Nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Nuevo.Click
        Dim myForm As New frmCatalogoEmpleados
        myForm.Accion = 1
        myForm.ShowDialog()
        If GLB_RefrescarPedido = True Then
            Call RellenaGrid()
        End If
    End Sub
    Public Sub bus()
        GridView1.GetRowCellValue(GridView1.FocusedRowHandle, " Estatus ")
    End Sub
    Public Sub ver(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        Dim view As GridView = sender
        If view.IsDataRow(e.RowHandle) Then
            If e.CellValue.ToString = "ACTIVO" Then
                e.Appearance.BackColor = Color.GreenYellow
                e.Appearance.Font = New Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold)
            End If
            If e.CellValue.ToString = "INACTIVO" Then
                e.Appearance.BackColor = Color.Yellow
                e.Appearance.Font = New Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold)
            End If
            If e.CellValue.ToString = "BAJA" Then
                e.Appearance.BackColor = Color.Red
                e.Appearance.Font = New Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold)
            End If
        End If



    End Sub
    'Public Sub bla(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
    '    e.Appearance.BackColor = Color.White
    'End Sub
    Private Sub GridView1_(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        Try
            If GridView1.OptionsSelection.MultiSelect = True Then
                e.Column.AppearanceHeader.BackColor = Color.LightBlue
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub AgregarColumna()
        GridView1.OptionsSelection.MultiSelect = True
        GridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        GridView1.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.False
        GridView1.OptionsView.ColumnAutoWidth = True
        'añadir columna de imagen a la coleccion del grid 
        GridView1.OptionsView.RowAutoHeight = True
        'DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
        Call Agregarfiltro()
    End Sub
    Private Sub Agregarfiltro()
        GridView1.OptionsView.ShowAutoFilterRow = True
    End Sub
    Private Sub GridView_KeyPress(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.KeyPress
        Try
            'Call Btn_Consultar_Click(sender, e)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Btn_Consultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Consultar.Click
        If Sw_NoRegistros = False Then Exit Sub
        If GLB_CveSucursal <> "" Then Exit Sub
        Dim myForm As New frmCatalogoEmpleados
        myForm.Accion = 4
        myForm.Txt_idempleado.Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "idempleado")

        myForm.ShowDialog()
        If GLB_RefrescarPedido = True Then
            Call RellenaGrid()
        End If
    End Sub
    Public Sub Doble()
        If Sw_NoRegistros = False Then Exit Sub
        If GLB_CveSucursal <> "" Then Exit Sub
        Dim myForm As New frmCatalogoEmpleados
        myForm.Accion = 4
        myForm.Txt_idempleado.Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "idempleado")

        myForm.ShowDialog()
        If GLB_RefrescarPedido = True Then
            Call RellenaGrid()
        End If
    End Sub

    Private Sub Btn_Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar.Click
        If Sw_NoRegistros = False Then Exit Sub
        If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Estatus") = "BAJA" Then
            MsgBox("No puede modificar un Empleado dado de Baja.", MsgBoxStyle.Critical, "Validación")
            Exit Sub
        End If
        Dim myForm As New frmCatalogoEmpleados
        myForm.Accion = 2
        myForm.Sw_Tienda = Sw_Tienda
        myForm.Txt_idempleado.Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "idempleado").ToString().Trim()
        myForm.ShowDialog()
        If GLB_RefrescarPedido = True Then
            Call RellenaGrid()
        End If
    End Sub

    Private Sub Btn_Filtro_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        Dim myForm As New frmFiltrosEmpleados
        Dim Estatus As String = ""

        If EstatusB = "B" Then Estatus = "BAJA"
        If EstatusB = "I" Then Estatus = "INACTIVO"
        If EstatusB = "A" Then Estatus = "ACTIVO"

        myForm.Txt_IdEmpleado.Text = idEmpleadoB
        myForm.Txt_IdPuesto.Text = IdPuestoB
        myForm.Txt_IdDepto.Text = IdDeptoB
        If InicioIniB <> "1900-01-01" Then
            myForm.Chk_FechaIngreso.Checked = True
            myForm.DTPicker2.Value = InicioIniB
            myForm.DTPicker3.Value = InicioFinB
        End If
        If BajaIniB <> "1900-01-01" Then
            myForm.Chk_FechaBaja.Checked = True
            myForm.DTPicker6.Value = BajaIniB
            myForm.DTPicker7.Value = BajaFinB
        End If
        If NacimIniB <> "1900-01-01" Then
            myForm.Chk_Nacim.Checked = True
            myForm.DTPicker8.Value = NacimIniB
            myForm.DTPicker9.Value = NacimFinB
        End If
        myForm.Cbo_Estatus.Text = Estatus
        myForm.Txt_Sucursal.Text = SucursalB

        myForm.ShowDialog()

        idEmpleadoB = myForm.Txt_IdEmpleado.Text
        SucursalB = myForm.Txt_Sucursal.Text
        EstatusB = Mid(myForm.Cbo_Estatus.Text, 1, 1)
        IdPuestoB = myForm.Txt_IdPuesto.Text
        IdDeptoB = myForm.Txt_IdDepto.Text

        If myForm.Chk_FechaIngreso.Checked = True Then
            InicioIniB = Format(myForm.DTPicker2.Value, "yyyy-MM-dd")
            InicioFinB = Format(myForm.DTPicker3.Value, "yyyy-MM-dd")
        Else
            InicioIniB = "1900-01-01"
            InicioFinB = "1900-01-01"
        End If


        If myForm.Chk_FechaBaja.Checked = True Then
            BajaIniB = Format(myForm.DTPicker6.Value, "yyyy-MM-dd")
            BajaFinB = Format(myForm.DTPicker7.Value, "yyyy-MM-dd")
        Else
            BajaIniB = "1900-01-01"
            BajaFinB = "1900-01-01"
        End If

        If myForm.Chk_Nacim.Checked = True Then
            NacimIniB = Format(myForm.DTPicker8.Value, "yyyy-MM-dd")
            NacimFinB = Format(myForm.DTPicker9.Value, "yyyy-MM-dd")
        Else
            NacimIniB = "1900-01-01"
            NacimFinB = "1900-01-01"
        End If
        If myForm.Sw_Filtro = True Then
            Call RellenaGrid()
        End If
    End Sub
    Private Sub NuevoProveedorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call Btn_Nuevo_Click(sender, e)
    End Sub

    Private Sub ModificarProveedorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call Btn_Editar_Click(sender, e)
    End Sub

    Private Sub ConsultarProveedorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call Btn_Consultar_Click(sender, e)
    End Sub

    Private Sub Btn_Eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Eliminar.Click

    End Sub

    Private Sub Pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub
    'FALTA VERIFICAR ESTE CODIGO 
    Private Sub Btn_RegistrarHuella_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_RegistrarHuella.Click
        'Dim myForm As New frmCargaHuellas
        Dim intContador As Integer = 0
        Dim myForm As New frmChecador

        Dim Opcion As Integer = 1
        Try

            For i As Integer = 0 To GridView1.DataRowCount - 1
                If GridView1.IsRowSelected(i) = True Then
                    If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "estatus") = "BAJA" Then
                        MsgBox("Solo debe seleccionar empleados con estatus ACTIVO", MsgBoxStyle.Critical, "Validación")
                        Exit Sub
                    Else
                        ReDim Preserve arrEmpleados(intContador)
                        arrEmpleados(intContador) = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "idempleado")
                        intContador += 1
                    End If
                End If
            Next
            If intContador = 0 Then
                MsgBox("No se selecciono ningun Empleado para el envío de Huellas", MsgBoxStyle.OkOnly, "Aviso")
                Exit Sub
            End If
            myForm.arrEmpleado = arrEmpleados
            'myForm.Txt_IdEmpleado.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idempleado").Value.ToString.Trim()
            myForm.Opcion = Opcion
            myForm.ShowDialog()

            Call RellenaGrid()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Btn_RecolectarHuellas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_RecolectarHuellas.Click
        Dim myForm As New frmChecador
        'Dim myformEsp As New frmEspera
        Dim Opcion As Integer = 2
        Try
            myForm.Opcion = Opcion
            myForm.ShowDialog()

            arreChecadores = myForm.arreChecadores

            If arreChecadores Is Nothing Then
                Exit Sub
            End If
            If MsgBox("Desea recolectar las huellas de las terminales seleccionadas?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.Yes Then
                'frmEspera.Show()
                For Each objChecador As Integer In arreChecadores
                    Call Recolectar_HuellasTerm(objChecador)
                Next
                'frmEspera.Close()
            Else
                Exit Sub
            End If
            'Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    'Recolecta Huellas por Terminal
    Private Sub Recolectar_HuellasTerm(ByVal Terminal As Integer)
        'Tony Garcia - 01/Octubre/2012 - 4:30 p.m.

        Dim DataSetHuellas As New DataSet
        Dim DataSetInsertH As New DataSet
        Dim sOption As String = "~ZKFPVersion"
        Dim sValue As String = ""
        Dim iMachineNumber As Integer
        Dim nLectura As Integer = 0
        Dim nNuevas As Integer = 0


        Using objChecadorH As New BCL.BCLHuellasEmpleado(GLB_ConStringNomSis)
            Try
                objDataSet = objChecadorH.usp_EliminarHuellas(Terminal)
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using

        Using objChecador As New BCL.BCLHuellasEmpleado(GLB_ConStringNomSis)
            Try
                DataSetHuellas = objChecador.usp_TraerChecador(Terminal, "")

                For Each renglon As DataRow In DataSetHuellas.Tables(0).Rows
                        Try
                        Checador_Id = renglon.Item("idchecador").ToString.Trim
                        Direccion_IP = renglon.Item("ip").ToString.Trim
                        bconn = CZKEM1.Connect_Net(Direccion_IP, 4370)
                        Catch ExceptionErr As Exception
                            MessageBox.Show(ExceptionErr.Message.ToString)
                            Exit Sub
                        End Try

                        If bconn Then
                        '            'Bw1.ReportProgress(i)
                        If CZKEM1.GetSysOption(iMachineNumber, sOption, sValue) Then
                            If sValue = "10" Then
                                MsgBox("Your device is not using 9.0 arithmetic!", MsgBoxStyle.Exclamation, "Error")
                                Return
                            End If
                        End If
                        If CZKEM1.ReadAllUserID(iMachineNumber) Then 'CZKEM1.ReadAllTemplate(iMachineNumber) Then 'CZKEM1.ReadAll(1) Then

                            While CZKEM1.GetAllUserID(iMachineNumber, dwEnrollNumber, dwEMachineNumber, dwBackupNumber, dwMachinePrivilege, dwEnable)

                                For dwFingerIndex As Int16 = 0 To 1
                                    Dim byTmpData(700) As Byte

                                    If CZKEM1.GetUserTmp(iMachineNumber, dwEnrollNumber, dwFingerIndex, byTmpData(0), TmpLength) Then

                                        Try
                                            nLectura = nLectura + 1

                                            DataSetInsertH = objChecador.usp_Captura_Huella(Checador_Id, Format(dwEnrollNumber, "00000"), dwFingerIndex, byTmpData, DateTime.Now)

                                            nNuevas = nNuevas + 1
                                        Catch ExceptionErr As Exception
                                            MessageBox.Show(ExceptionErr.Message.ToString)
                                        End Try
                                    End If
                                Next
                            End While
                        Else
                            MsgBox("Fallo al Leer Usuarios", MsgBoxStyle.Exclamation)
                        End If
                    End If

                    CZKEM1.Disconnect()

                Next
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using

        MsgBox(Str(nLectura) + " Huellas Leídas" + vbCrLf + Str(nNuevas) + " Huellas Agregadas" + " en Terminal " + Terminal.ToString, MsgBoxStyle.Information, "Lectura")
        'Call RellenaGrid()
    End Sub
    'Private Sub Recolectar_HuellasEmp(ByVal IdEmpleado As Integer)
    '    Dim DataSetHuellas As New DataSet
    '    Dim DataSetInsertH As New DataSet
    '    Dim sOption As String = "~ZKFPVersion"
    '    Dim sValue As String = ""
    '    Dim iMachineNumber As Integer
    '    Dim nLectura As Integer = 0
    '    Dim nNuevas As Integer = 0
    '    Using objChecadorH As New BCL.BCLHuellasEmpleado(GLB_ConStringNomSisSQL)
    '        Try
    '            'objDataSet = objChecadorH.usp_EliminarHuellas(Cbo_Terminales.SelectedValue)
    '        Catch ExceptionErr As Exception
    '            MessageBox.Show(ExceptionErr.Message.ToString)
    '        End Try
    '    End Using
    '    Using objChecador As New BCL.BCLHuellasEmpleado(GLB_ConStringNomSisSQL)
    '        Try
    '            DataSetHuellas = objChecador.usp_TraerChecadores()
    '            For Each renglon As DataRow In DataSetHuellas.Tables(0).Rows
    '                Try
    '                    Checador_Id = renglon.Item("idchecador").ToString.Trim
    '                    Direccion_IP = renglon.Item("ip").ToString.Trim
    '                    bconn = CZKEM1.Connect_Net(Direccion_IP, 4370)
    '                Catch ExceptionErr As Exception
    '                    MessageBox.Show(ExceptionErr.Message.ToString)
    '                    Exit Sub
    '                End Try
    '                If bconn Then
    '                    '            'Bw1.ReportProgress(i)
    '                    If CZKEM1.GetSysOption(iMachineNumber, sOption, sValue) Then
    '                        If sValue = "10" Then
    '                            MsgBox("Your device is not using 9.0 arithmetic!", MsgBoxStyle.Exclamation, "Error")
    '                            Return
    '                        End If
    '                    End If
    '                    If CZKEM1.ReadAllUserID(iMachineNumber) Then 'CZKEM1.ReadAllTemplate(iMachineNumber) Then 'CZKEM1.ReadAll(1) Then
    '                        While CZKEM1.GetAllUserID(iMachineNumber, dwEnrollNumber, dwEMachineNumber, dwBackupNumber, dwMachinePrivilege, dwEnable)
    '                            For dwFingerIndex As Int16 = 0 To 1
    '                                Dim byTmpData(700) As Byte
    '                                If CZKEM1.GetUserTmp(iMachineNumber, dwEnrollNumber, dwFingerIndex, byTmpData(0), TmpLength) Then
    '                                    Try
    '                                        nLectura = nLectura + 1
    '                                        DataSetInsertH = objChecador.usp_Captura_Huella(Checador_Id, Format(dwEnrollNumber, "0000"), dwFingerIndex, byTmpData, DateTime.Now)
    '                                        nNuevas = nNuevas + 1
    '                                    Catch ExceptionErr As Exception
    '                                        MessageBox.Show(ExceptionErr.Message.ToString)
    '                                    End Try
    '                                End If
    '                            Next
    '                        End While
    '                    Else
    '                        MsgBox("Fallo al Leer Usuarios", MsgBoxStyle.Exclamation)
    '                    End If
    '                End If
    '                CZKEM1.Disconnect()
    '            Next
    '        Catch ExceptionErr As Exception
    '            MessageBox.Show(ExceptionErr.Message.ToString)
    '        End Try
    '    End Using
    '    MsgBox(Str(nLectura) + " Huellas Leídas" + vbCrLf + Str(nNuevas) + " Huellas Agregadas", MsgBoxStyle.Information, "Lectura")
    'End Sub
    Private Sub Btn_EliminarHuellas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_EliminarHuellas.Click
        Dim myForm As New frmChecador
        Dim Opcion As Integer = 3
        Dim intContador As Integer = 0
        Try
            For i As Integer = 0 To GridView1.DataRowCount - 1
                If GridView1.IsRowSelected(i) = True Then
                    If GridView1.GetRowCellValue(i, "Estatus") = "BAJA" Then
                        MsgBox("Solo debe seleccionar empleados con estatus ACTIVO", MsgBoxStyle.Critical, "Validación")
                        Exit Sub
                    Else
                        ReDim Preserve arrEmpleados(intContador)
                        arrEmpleados(intContador) = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "idempleado")
                        intContador += 1
                    End If
                End If
            Next
            If intContador = 0 Then
                MsgBox("No se selecciono ningun Empleado para Eliminar sus Huellas", MsgBoxStyle.OkOnly, "Aviso")
                Exit Sub
            End If

            myForm.Opcion = Opcion
            myForm.arrEmpleado = arrEmpleados

            myForm.ShowDialog()

            'Call RellenaGrid()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Grido_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs)
        Sw_Pintar = True
    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        Dim ea As DXMouseEventArgs = TryCast(e, DXMouseEventArgs)
        Dim view As GridView = TryCast(sender, GridView)
        Dim info As GridHitInfo = view.CalcHitInfo(ea.Location)
        If info.InRow OrElse info.InRowCell Then
            Call Doble()
        End If
    End Sub

    Private Sub Grido_Click(sender As Object, e As EventArgs) Handles Grido.Click

    End Sub
End Class