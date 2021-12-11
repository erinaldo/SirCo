Imports DevExpress.DashboardCommon
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Columns.GridColumn
Public Class frmPpalCambiarCajero
    'mreyes 26/Octubre/2016 11:25 a.m.

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

            ToolTip.SetToolTip(Btn_Editar, "Editar Cajero")

            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")

            ToolTip.SetToolTip(Btn_Salir, "Salir")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub RellenaGrid()
        'mreyes 26/Octubre/2016 11:46 a.m.

        Using objRepetitivo As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)
            Try
                Me.Cursor = Cursors.WaitCursor
                'DGrid.ReadOnly = True
                Grido.DataSource = Nothing
                objDataSet = objRepetitivo.usp_PpalCatalogoCajero()
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

                    Sw_NoRegistros = True
                    Sw_Pintar = True
                Else
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron Empleados que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                    Btn_Editar.Enabled = False

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

            GridView1.Columns(0).Caption = " IdEmpleado"
            GridView1.Columns(1).Caption = " Nombre Completo "
            GridView1.Columns(2).Caption = " Cajero "
            GridView1.Columns(3).Caption = " Usuario "
            GridView1.Columns(4).Caption = " Sucursal"
            For j As Integer = 0 To GridView1.Columns().Count - 1
                GridView1.Columns(j).OptionsColumn.ReadOnly = True
                GridView1.Columns(j).OptionsColumn.AllowEdit = False
                GridView1.Columns(j).AppearanceHeader.BackColor = Color.LightBlue
                GridView1.Columns(j).AppearanceHeader.TextOptions.HAlignment = HorizontalAlignment.Center
                GridView1.Columns(j).AppearanceHeader.Font = New Font(GridView1.Columns(j).AppearanceHeader.Font, FontStyle.Bold)

            Next
            GridView1.Columns(0).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(1).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(2).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(3).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(4).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center

            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
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
    Private Sub GridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grido.DoubleClick
        Try
            Call doble()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DGrid.KeyPress
        Try
            'Call Btn_Consultar_Click(sender, e)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Sub doble()
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
        If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SUCURSAL") = "TO" Then
            MsgBox("No tiene permiso para modificar este cajero.", MsgBoxStyle.Critical, "Validación")
            Exit Sub
        End If
        Dim myForm As New frmCatalogoCambiarCajero
        Try
            myForm.Accion = 2
            myForm.Txt_Nombre.Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "NOMBRE").ToString().Trim()
            myForm.Txt_Cajero.Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "CAJERO").ToString().Trim()
            myForm.Txt_SucActual.Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SUCURSAL").ToString().Trim()
            myForm.ShowDialog()
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Btn_Filtro_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
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

        idEmpleadoB = Val(myForm.Txt_IdEmpleado.Text)
        SucursalB = myForm.Txt_Sucursal.Text
        EstatusB = Mid(myForm.Cbo_Estatus.Text, 1, 1)
        IdPuestoB = Val(myForm.Txt_IdPuesto.Text)
        IdDeptoB = Val(myForm.Txt_IdDepto.Text)

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
    Private Sub ModificarProveedorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarProveedorToolStripMenuItem.Click
        Call Btn_Editar_Click(sender, e)
    End Sub
    Private Sub ConsultarProveedorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultarProveedorToolStripMenuItem.Click
        Call doble()
    End Sub
    Private Sub DGrid_ColumnHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGrid.ColumnHeaderMouseClick
        Sw_Pintar = True
    End Sub
End Class