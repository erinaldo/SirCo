Public Class frmCatalogoMovEmp

    'Tony Garcia - 04/Septiembre/2012 - 5:00 p.m.

    Private objDataSet As Data.DataSet

    Public Accion As Integer  '' 1  = nuevo, 2 = edicion , 4 = consulta
    Dim IdDepto As Integer = 0
    Dim IdPuesto As Integer = 0

    Dim IdDeptoNuevo As Integer = 0
    Dim IdPuestoNuevo As Integer = 0

    Dim OpcionMov As Integer = 0
    Dim ContadorMov As Integer = 0
    Public TipoMov As String = ""
    Public Estatus As String = ""
    Public IdMovEmp As Integer

    Private Sub frmCatalogoMovEmp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            GLB_RefrescarPedido = False

            Call LLenarComboMotivoBaja()
            If Accion = 1 Then
            Else
                Call usp_TraerEmpleado()
                Call CargarFotoEmpleado()
            End If
            Call GenerarToolTip()
            Call Edicion()
           
            Txt_idempleado.Focus()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Editar, "Editar Movimientos del Empleado")
            ToolTip.SetToolTip(Btn_Nuevo, "Agregar un Movimiento Nuevo")
            ToolTip.SetToolTip(Btn_Aceptar, "Realizar el movimiento")

            ToolTip.SetToolTip(Btn_Salir, "Salir")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub HabilitaControlesBaja(ByVal blnEnabled As Boolean)
        Try
            Txt_ComentariosBaja.Enabled = blnEnabled
            DTBaja.Enabled = blnEnabled
            Cbo_MotivoBaja.Enabled = blnEnabled
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub HabilitaControlesVendedor(ByVal blnEnabled As Boolean)
        Try
            DTVendedor.Enabled = blnEnabled
            Txt_SucursalVen.Enabled = blnEnabled
            Txt_DescripSucVen.Enabled = blnEnabled
            Txt_VendedorVen.Enabled = blnEnabled
            Txt_ComentariosVen.Enabled = blnEnabled
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub HabilitaControlesSucursal(ByVal blnEnabled As Boolean)
        Try
            DTSucursal.Enabled = blnEnabled
            Txt_SucursalSuc.Enabled = blnEnabled
            Txt_DescripSusSuc.Enabled = blnEnabled
            Txt_VendedorSuc.Enabled = blnEnabled
            Txt_ComentariosSuc.Enabled = blnEnabled
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub LimpiaControlesBaja()
        DTBaja.Value = DateTime.Now
        Txt_ComentariosBaja.Text = ""
        Call LLenarComboMotivoBaja()
    End Sub

    Private Sub LimpiaControlesVendedor()
        DTVendedor.Value = DateTime.Now
        Txt_SucursalVen.Text = ""
        Txt_DescripSucVen.Text = ""
        Txt_VendedorVen.Text = ""
        Txt_ComentariosVen.Text = ""
    End Sub

    Private Sub LimpiaControlesSucursal()
        DTSucursal.Value = DateTime.Now
        Txt_SucursalSuc.Text = ""
        Txt_DescripSusSuc.Text = ""
        Txt_VendedorSuc.Text = ""
        Txt_ComentariosSuc.Text = ""
    End Sub

    Private Sub CargaOpcionMovimiento()
        If TipoMov = "BAJ" Then
            OpcionMov = 1
        ElseIf TipoMov = "VEN" Then
            OpcionMov = 2
        ElseIf TipoMov = "SUC" Then
            OpcionMov = 3
        ElseIf TipoMov = "DEP" Then
            OpcionMov = 4
        End If
    End Sub

    Private Sub usp_TraerMovEmp()
        'Tony Garcia - 10/Sept/2012 - 12:20 p.m.
        Dim objDataSet As Data.DataSet
        Using objCatalogo As New BCL.BCLCatalogoMovEmp(GLB_ConStringNomSis)
            Try
                If Accion = 1 Then
                    Tbc_Movimientos.Visible = True
                    HabilitaControlesBaja(True)
                    HabilitaControlesVendedor(True)
                    Exit Sub
                End If
                Call CargaOpcionMovimiento()
                If Txt_idempleado.Text.Length = 0 Then Exit Sub
                objDataSet = objCatalogo.usp_TraerMovEmp(OpcionMov, Txt_idempleado.Text, CDate(Txt_FechaMov.Text), TipoMov)
                If objDataSet.Tables(0).Rows.Count > 0 Then

                    If TipoMov = "BAJ" Then
                        Tbc_Movimientos.SelectedIndex = 0
                        DTBaja.Value = objDataSet.Tables(0).Rows(0).Item("baja")
                        Txt_ComentariosBaja.Text = objDataSet.Tables(0).Rows(0).Item("comentario").ToString
                        Cbo_MotivoBaja.SelectedValue = objDataSet.Tables(0).Rows(0).Item("idmotivo")

                    ElseIf TipoMov = "VEN" Then
                        Tbc_Movimientos.SelectedIndex = 6
                        DTVendedor.Value = objDataSet.Tables(0).Rows(0).Item("fecha").ToString
                        'Txt_SucursalVen.Text = Txt_Sucursal.Text
                        'Txt_DescripSucVen.Text = objDataSet.Tables(0).Rows(0).Item("descripsuc").ToString
                        Txt_ComentariosVen.Text = objDataSet.Tables(0).Rows(0).Item("comentario").ToString
                        Txt_VendedorVen.Text = objDataSet.Tables(0).Rows(0).Item("vendnuevo").ToString
                        'DTVendedor.Value=

                    ElseIf TipoMov = "SUC" Then
                        Tbc_Movimientos.SelectedIndex = 4
                        DTSucursal.Value = objDataSet.Tables(0).Rows(0).Item("fecha").ToString
                        Txt_SucursalSuc.Text = objDataSet.Tables(0).Rows(0).Item("sucnueva").ToString
                        Txt_DescripSusSuc.Text = objDataSet.Tables(0).Rows(0).Item("descripsuc").ToString
                        Txt_ComentariosSuc.Text = objDataSet.Tables(0).Rows(0).Item("comentario").ToString
                        Txt_VendedorSuc.Text = objDataSet.Tables(0).Rows(0).Item("vendedor").ToString

                    ElseIf TipoMov = "DEP" Then
                        Tbc_Movimientos.SelectedIndex = 3
                        DTDeptoPuesto.Value = objDataSet.Tables(0).Rows(0).Item("fecha").ToString
                        Txt_ComentariosDep.Text = objDataSet.Tables(0).Rows(0).Item("comentario").ToString

                        Txt_ClaveDeptoDep.Text = objDataSet.Tables(0).Rows(0).Item("clavedep").ToString
                        Txt_ClavePuestoDep.Text = objDataSet.Tables(0).Rows(0).Item("clavepue").ToString

                        Txt_DescripDeptoD.Text = objDataSet.Tables(0).Rows(0).Item("descripdepto").ToString
                        Txt_DescripPuestoD.Text = objDataSet.Tables(0).Rows(0).Item("descrippuesto").ToString

                        'TRAERDEPTO

                    End If

                    Tbc_Movimientos.Visible = True
                    Btn_Editar.Enabled = True

                    If Accion = 2 Or Accion = 4 Then
                        'Txt_FechaMov.Text = objDataSet.Tables(0).Rows(0).Item("fechaact")
                        Call HabilitaControlesBaja(True)
                        Call HabilitaControlesVendedor(True)
                    Else
                        Call HabilitaControlesBaja(False)
                        Call HabilitaControlesVendedor(False)
                    End If
                Else
                    Tbc_Movimientos.Visible = True
                    Btn_Editar.Enabled = False
                    Btn_Nuevo.Enabled = False

                End If

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub usp_TraerEmpleado()
        'Tony Gracia - 05/Septiembre/2012 - 09:20 a.m.
        Dim objDataSet As Data.DataSet
        Using objCatalogo As New BCL.BCLCatalogoMovEmp(GLB_ConStringNomSis)
            Try
                If Txt_idempleado.Text.Length = 0 Then Exit Sub
                objDataSet = objCatalogo.usp_TraerEmpleado(Txt_idempleado.Text)
                If objDataSet.Tables(0).Rows.Count > 0 Then

                    Txt_Clave.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    Txt_Nombre.Text = objDataSet.Tables(0).Rows(0).Item("nomcompleto").ToString
                    IdDepto = objDataSet.Tables(0).Rows(0).Item("iddepto")
                    Txt_ClaveDepto.Text = objDataSet.Tables(0).Rows(0).Item("clavedepto")
                    Txt_DescripDepto.Text = objDataSet.Tables(0).Rows(0).Item("descripdepto")
                    IdPuesto = objDataSet.Tables(0).Rows(0).Item("idpuesto")
                    Txt_ClavePuesto.Text = objDataSet.Tables(0).Rows(0).Item("clavepuesto")
                    Txt_DescripPuesto.Text = objDataSet.Tables(0).Rows(0).Item("descrippuesto")
                    Txt_Sucursal.Text = Mid(Txt_Clave.Text, 1, 2)
                    Txt_DescripSucursal.Text = objDataSet.Tables(0).Rows(0).Item("descripsucursal")
                    Txt_RFC.Text = objDataSet.Tables(0).Rows(0).Item("rfc")
                    Txt_NoIMSS.Text = objDataSet.Tables(0).Rows(0).Item("noimss")
                    Txt_Ingreso.Text = objDataSet.Tables(0).Rows(0).Item("ingreso")
                    Txt_SDiario.Text = objDataSet.Tables(0).Rows(0).Item("sdiario")
                    Estatus = objDataSet.Tables(0).Rows(0).Item("estatus")

                    If IdPuesto = 4 Then
                        Txt_Vendedor.Visible = True
                        Lbl_Vendedor.Visible = True
                        Txt_Vendedor.Text = objDataSet.Tables(0).Rows(0).Item("vendedor")
                    End If

                    Call usp_TraerMovEmp()
                    Call CargarFotoEmpleado()
                Else
                    Call CargarFormaConsultaEmpleado()
                    ''MessageBox.Show("El empleado no existe, ingrese un ID valido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub CargarFotoEmpleado()
        'Tony garcia 12/septiembre/2012 01:50 p.m.
        'Glb_RutaArchivoFotos
        Try
            Dim Archivo As String = ""
            Dim NoFoto As String = "1"
            Dim Sw_NoEncontro As Boolean = False
            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)

                Archivo = objIO.pub_ArmarNombreFotoEmpleado(GLB_RutaFotoEmpleado, Txt_idempleado.Text)
                If objIO.pub_ExisteArchivo(Archivo) = True Then
                    Sw_NoEncontro = True
                    PBox.Image = New System.Drawing.Bitmap(Archivo)
                    Exit Sub
                Else
                    PBox.Image = Nothing
                End If

                For i As Integer = 0 To 9
                    Archivo = objIO.pub_ArmarNombreFotoEmpleado(GLB_RutaArchivoFotos, Txt_idempleado.Text)
                    If objIO.pub_ExisteArchivo(Archivo) = True Then
                        Sw_NoEncontro = True
                        PBox.Image = New System.Drawing.Bitmap(Archivo)
                        Exit Sub
                    End If
                Next
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        ''Tony Garcia - 10/Sept/2012 - 11:00 a.m.
        Try
            'GLB_RefrescarPedido = False
            If Validar() = False Then Exit Sub
            If Accion = 1 Then '''' movimiento nuevo
                If MsgBox("Estas Seguro de Guardar el Movimiento del Empleado " + Txt_idempleado.Text + "?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    If Inserta_MovEmp() = True Then
                        GLB_RefrescarPedido = True
                        MessageBox.Show("Exitosamente Grabado el Movimiento '" & Txt_idempleado.Text & "' con razón social '" & Txt_Nombre.Text & " !", "Agregando Movimiento", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Close()
                        Me.Dispose()
                    Else
                        MessageBox.Show("Error al Guardar !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    End If
                End If
            ElseIf Accion = 2 Then ' es una actualización
                If MsgBox("Estas Seguro de Actualizar el Empleado?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    If Inserta_MovEmp() = True Then
                        GLB_RefrescarPedido = True
                        MessageBox.Show("Exitosamente Grabado el Movimiento del Empleado '" & Txt_idempleado.Text & "' con razón social '" & Txt_Nombre.Text & " !", "Actualizando Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Close()
                        Me.Dispose()
                    Else
                        MessageBox.Show("Error al Guardar !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            ElseIf Accion = 4 Then
                Me.Close()
                Me.Dispose()
            End If '' del if de accion = 1 

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_idempleado_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_idempleado.KeyPress
        Call pub_SoloNumeros(sender, e)
    End Sub

    Private Sub Txt_idempleado_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_idempleado.LostFocus
        Try
            Call usp_TraerEmpleado()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Comentarios_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_ComentariosBaja.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub LLenarComboMotivoBaja()
        Dim objDataSet As Data.DataSet
        Using objCatalogo As New BCL.BCLCatalogoMovEmp(GLB_ConStringNomSis)
            Try
                objDataSet = objCatalogo.usp_TraerMotivoBaja()
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Cbo_MotivoBaja.DataSource = objDataSet.Tables(0).DefaultView
                    Cbo_MotivoBaja.DisplayMember = "Motivo"
                    Cbo_MotivoBaja.ValueMember = "IdMotivo"
                End If
            Catch ex As Exception
            End Try
        End Using
    End Sub

    Private Sub Cbo_MotivoBaja_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cbo_MotivoBaja.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CargarFormaConsultaEmpleado()
        Dim myForm As New frmConsultaEmpleado
        Txt_Nombre.Text = ""
        myForm.Estatus = ""
        myForm.ShowDialog()
        Txt_idempleado.Text = myForm.Campo
        Txt_Nombre.Text = myForm.Campo1
        If Txt_idempleado.Text.Length = 0 Then
            Txt_idempleado.Focus()
        End If
    End Sub

    Private Sub Btn_Nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Nuevo.Click
        Try
            Accion = 1
            Call Edicion()
            'Tbc_Movimientos.Visible = True
            'Btn_Nuevo.Enabled = False
            'Btn_Editar.Enabled = False
            'Btn_Aceptar.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar.Click
        Try
            Accion = 2

            Btn_Nuevo.Enabled = False
            Btn_Editar.Enabled = False
            Btn_Aceptar.Enabled = True
            If Tbc_Movimientos.Visible = True Then
                Call HabilitaControlesBaja(True)
                Call HabilitaControlesVendedor(True)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Function Validar() As Boolean
        Try
            Validar = False
            If Tbc_Movimientos.SelectedIndex = 0 Then
                If Txt_ComentariosBaja.Text = "" Then
                    MsgBox("No puede registrar el movimiento mientras no especifique un comentario al mismo.", MsgBoxStyle.Critical, "Aviso")
                    Exit Function
                End If
                'Validar que no tenga repetitivos

                Dim objDataSet As Data.DataSet
                Using objCatalogo As New BCL.BCLCatalogoMovEmp(GLB_ConStringNomSis)
                    Try
                        objDataSet = objCatalogo.usp_TraerRepetitivoEmpleado(Txt_idempleado.Text)
                        If objDataSet.Tables(0).Rows.Count > 0 Then
                            If objDataSet.Tables(0).Rows(0).Item("saldo") > 0 Then
                                MsgBox("El empleado tiene un saldo vigente en repetitivos de: '" & objDataSet.Tables(0).Rows(0).Item("saldo").ToString & "'.   ESTO NO DETENDRA LA BAJA", MsgBoxStyle.Information, "Aviso")
                                ' Exit Function
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                End Using

            End If
            Validar = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function
    Private Function Inserta_MovEmp() As Boolean
        'Tony Garcia 10/Sept/2012 11:47 a.m.

        'Dim blnInsertaSegundo As Boolean
        Dim Clave As String = ""
        Using objCatalogoMovEmp As New BCL.BCLCatalogoMovEmp(GLB_ConStringNomSis)
            'Get a new Project DataSet
            Try
                objDataSet = objCatalogoMovEmp.Inserta_MovEmp  'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow
                'blnInsertaSegundo = False

                'Set the values in the DataRow
                If Accion = 1 Then
                    Call usp_TraerEmpleado()
                End If
                objDataRow.Item("IdPuesto") = 0
                objDataRow.Item("iddepto") = 0
                objDataRow.Item("idpuestonuevo") = 0
                objDataRow.Item("iddeptonuevo") = 0


                objDataRow.Item("idempleado") = Val(Txt_idempleado.Text)
                If Tbc_Movimientos.SelectedIndex = 0 Then 'Baja
                    objDataRow.Item("tipo") = "BAJ"
                ElseIf Tbc_Movimientos.SelectedIndex = 1 Then 'Sueldo
                    objDataRow.Item("tipo") = "SUE"
                ElseIf Tbc_Movimientos.SelectedIndex = 2 Then 'Reingreso
                    objDataRow.Item("tipo") = "REI"
                ElseIf Tbc_Movimientos.SelectedIndex = 3 Then ' Departamento y Puesto
                    objDataRow.Item("tipo") = "DEP"
                ElseIf Tbc_Movimientos.SelectedIndex = 4 Then ' Sucursal
                    objDataRow.Item("tipo") = "SUC"
                ElseIf Tbc_Movimientos.SelectedIndex = 5 Then ' Bono
                    objDataRow.Item("tipo") = "BON"
                ElseIf Tbc_Movimientos.SelectedIndex = 6 Then ' Vendedor
                    objDataRow.Item("tipo") = "VEN"
                End If

                If Accion = 1 Then
                    objDataRow.Item("fecha") = DateTime.Now
                    objDataRow.Item("fechaact") = "1900-01-01"
                    objDataRow.Item("idmovemp") = IdMovEmp
                    ' Txt_FechaMov.Text = DateTime.Now

                    '------------ Inserta Baja Empleado ------------------
                    If Tbc_Movimientos.SelectedIndex = 0 Then 'Tab Baja
                        'Call GuardaCambioBaja()
                        objDataRow.Item("baja") = DTBaja.Value
                        objDataRow.Item("idmotivo") = Cbo_MotivoBaja.SelectedValue
                        objDataRow.Item("vendedor") = ""
                        objDataRow.Item("vendnuevo") = ""
                        objDataRow.Item("sucursal") = ""
                        objDataRow.Item("sucnueva") = ""
                        objDataRow.Item("comentario") = Trim(Txt_ComentariosBaja.Text)

                        '--------- Inserta Cambio Vendedor ----------------
                    ElseIf Tbc_Movimientos.SelectedIndex = 6 Then 'Tab Vendedor
                        If ContadorMov = 1 Then
                            objDataRow.Item("idmotivo") = 0
                            objDataRow.Item("tipo") = "SUC"
                            objDataRow.Item("sucursal") = Txt_Sucursal.Text
                            objDataRow.Item("sucnueva") = Txt_SucursalVen.Text
                            objDataRow.Item("vendedor") = " "
                            objDataRow.Item("vendnuevo") = " "
                            ContadorMov = 0
                        Else
                            objDataRow.Item("idmotivo") = 0
                            objDataRow.Item("vendedor") = Txt_Vendedor.Text
                            objDataRow.Item("vendnuevo") = Txt_VendedorVen.Text
                            objDataRow.Item("sucursal") = " "
                            objDataRow.Item("sucnueva") = " "
                            If Txt_VendedorVen.Text <> "" Then
                                ContadorMov = 1
                            End If
                        End If
                        objDataRow.Item("baja") = "1900-01-01"
                        objDataRow.Item("comentario") = Trim(Txt_ComentariosVen.Text)

                        '----------- Inserta Cambio Sucursal ----------------
                    ElseIf Tbc_Movimientos.SelectedIndex = 4 Then 'Tab Sucursal
                        If ContadorMov = 1 Then
                            objDataRow.Item("idmotivo") = 0
                            objDataRow.Item("tipo") = "VEN"
                            objDataRow.Item("vendedor") = Txt_Vendedor.Text
                            objDataRow.Item("vendnuevo") = Txt_VendedorSuc.Text
                            objDataRow.Item("sucursal") = " "
                            objDataRow.Item("sucnueva") = " "
                            ContadorMov = 0
                        Else
                            objDataRow.Item("idmotivo") = 0
                            objDataRow.Item("sucursal") = Txt_Sucursal.Text
                            objDataRow.Item("sucnueva") = Txt_SucursalSuc.Text
                            objDataRow.Item("vendedor") = " "
                            objDataRow.Item("vendnuevo") = " "
                            If Txt_VendedorSuc.Text <> "" Then
                                ContadorMov = 1
                            End If
                        End If
                        objDataRow.Item("baja") = "1900-01-01"
                        objDataRow.Item("comentario") = Trim(Txt_ComentariosSuc.Text)
                    ElseIf Tbc_Movimientos.SelectedIndex = 3 Then
                        objDataRow.Item("iddepto") = IdDepto
                        objDataRow.Item("iddeptonuevo") = IdDeptoNuevo
                        objDataRow.Item("tipo") = "DEP"
                        objDataRow.Item("fecha") = DTDeptoPuesto.Text
                        objDataRow.Item("IdPuesto") = IdPuesto
                        objDataRow.Item("IdPuestoNUEVO") = IdPuestoNuevo
                        objDataRow.Item("idmotivo") = 0
                        objDataRow.Item("baja") = "1900-01-01"
                        objDataRow.Item("vendedor") = " "
                        objDataRow.Item("vendnuevo") = " "
                        objDataRow.Item("sucursal") = ""
                        objDataRow.Item("sucnueva") = ""
                        objDataRow.Item("comentario") = UCase(Trim(Txt_ComentariosDep.Text))

                    ElseIf Tbc_Movimientos.SelectedIndex = 2 Then
                        objDataRow.Item("iddepto") = IdDepto
                        objDataRow.Item("iddeptonuevo") = IdDeptoNuevo
                        objDataRow.Item("tipo") = "REI"
                        objDataRow.Item("fecha") = DTReingreso.Value
                        objDataRow.Item("IdPuesto") = IdPuesto
                        objDataRow.Item("IdPuestoNUEVO") = IdPuestoNuevo
                        objDataRow.Item("idmotivo") = 0
                        objDataRow.Item("baja") = "1900-01-01"
                        objDataRow.Item("vendedor") = " "
                        objDataRow.Item("vendnuevo") = " "
                        objDataRow.Item("sucursal") = ""
                        objDataRow.Item("sucnueva") = ""
                        objDataRow.Item("comentario") = UCase(Trim(Txt_ComentariosDep.Text))

                    End If

                ElseIf Accion = 2 Then
                    objDataRow.Item("idmovemp") = IdMovEmp
                    If TipoMov = "BAJ" Then
                        objDataRow.Item("fecha") = Txt_FechaMov.Text
                        objDataRow.Item("fechaact") = DateTime.Now
                        objDataRow.Item("baja") = DTBaja.Value
                        objDataRow.Item("idmotivo") = Cbo_MotivoBaja.SelectedValue
                        objDataRow.Item("vendedor") = ""
                        objDataRow.Item("vendnuevo") = ""
                        objDataRow.Item("sucursal") = ""
                        objDataRow.Item("sucnueva") = ""
                        objDataRow.Item("comentario") = Trim(Txt_ComentariosBaja.Text)

                    ElseIf TipoMov = "VEN" Then
                        objDataRow.Item("fecha") = Txt_FechaMov.Text
                        objDataRow.Item("fechaact") = DateTime.Now
                        objDataRow.Item("vendedor") = Txt_Vendedor.Text
                        objDataRow.Item("vendnuevo") = Txt_VendedorVen.Text
                        objDataRow.Item("sucursal") = " "
                        objDataRow.Item("sucnueva") = " "
                        objDataRow.Item("baja") = "1900-01-01"
                        objDataRow.Item("comentario") = Trim(Txt_ComentariosVen.Text)

                    ElseIf TipoMov = "SUC" Then
                        objDataRow.Item("fecha") = Txt_FechaMov.Text
                        objDataRow.Item("fechaact") = DTVendedor.Value
                        objDataRow.Item("vendedor") = " "
                        objDataRow.Item("vendnuevo") = " "
                        objDataRow.Item("sucursal") = Txt_Sucursal.Text
                        objDataRow.Item("sucnueva") = Txt_SucursalSuc.Text
                        objDataRow.Item("baja") = "1900-01-01"
                        objDataRow.Item("comentario") = Trim(Txt_ComentariosSuc.Text)
                    ElseIf TipoMov = "DEP" Then
                        objDataRow.Item("fecha") = DTDeptoPuesto.Text
                        objDataRow.Item("iddepto") = IdDepto
                        objDataRow.Item("iddeptonuevo") = IdDepto
                        objDataRow.Item("IdPuesto") = IdPuesto
                        objDataRow.Item("IdPuestoNUEVO") = IdPuesto
                        objDataRow.Item("baja") = "1900-01-01"
                        objDataRow.Item("idmotivo") = 0
                        objDataRow.Item("vendedor") = " "
                        objDataRow.Item("vendnuevo") = " "
                        objDataRow.Item("sucursal") = ""
                        objDataRow.Item("sucnueva") = ""
                        objDataRow.Item("comentario") = UCase(Trim(Txt_ComentariosDep.Text))

                    End If
                End If


                objDataRow.Item("estatus") = "C"
                objDataRow.Item("usuario") = GLB_Usuario
                ''objDataRow.Item("fum") = DateTime.Now
                objDataRow.Item("usumodif") = GLB_Usuario
                objDataRow.Item("fummodif") = DateTime.Now

                'Add the DataRow to the DataSet
                objDataSet.Tables(0).Rows.Add(objDataRow)

                'Add the Project
                If Not objCatalogoMovEmp.usp_Captura_MovEmp(Accion, objDataSet) Then
                    'Throw New Exception("Falló Inserción de Proveedor")
                Else
                    Inserta_MovEmp = True
                End If

                If ContadorMov = 1 Then
                    'Txt_VendedorSuc.Text = ""
                    'Txt_SucursalVen.Text = ""
                    Call Inserta_MovEmp()
                End If

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Private Sub Edicion()
        Try
            Select Case Accion
                Case 3, 4
                    Btn_Aceptar.Enabled = True
                    'Btn_Cancelar.Enabled = True
                    Btn_Nuevo.Enabled = True
                    Btn_Editar.Enabled = True
                    Pnl_Grid.Enabled = False
                    Txt_idempleado.BackColor = TextboxBackColor
                    Tbc_Movimientos.Visible = True
                    Call HabilitaControlesBaja(False)
                    Call HabilitaControlesVendedor(False)

                Case 1, 2
                    Btn_Aceptar.Enabled = True
                    'Btn_Cancelar.Enabled = True
                    Btn_Nuevo.Enabled = False
                    Btn_Editar.Enabled = False
                    Tbc_Movimientos.Visible = True

                    If Accion = 1 Then
                        Tbc_Movimientos.SelectedIndex = 0
                        Txt_Nombre.Focus()
                        Tbc_Movimientos.Visible = False
                        Application.DoEvents()

                    ElseIf Accion = 2 Then
                        Txt_Nombre.Focus()
                        Txt_idempleado.Enabled = False
                        Txt_Nombre.Enabled = False
                        Txt_idempleado.BackColor = TextboxBackColor
                        Txt_Nombre.BackColor = TextboxBackColor
                        Txt_Nombre.Focus()
                    End If
            End Select
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_SucursalVen_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_SucursalVen.KeyPress
        Call pub_SoloNumeros(sender, e)
    End Sub

    Private Sub Txt_SucursalVen_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_SucursalVen.LostFocus
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringPerSis)
            If Txt_SucursalVen.Text.Length = 0 Then Exit Sub

            Try
                'Get the specific project selected in the ListView control
                If Txt_SucursalVen.Text.Trim.Length < 2 Then
                    Txt_SucursalVen.Text = pub_RellenarIzquierda(Txt_SucursalVen.Text.Trim, 2)
                End If

                Call TxtLostfocusPersis(Txt_SucursalVen, Txt_DescripSucVen, "S")


            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub TxtLostfocusPersis(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
        Dim myForm As New frmConsulta

        If Txt_Campo.Text.Length = 0 Then Exit Sub
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringNomSis)
            Try

                objDataSet = objMySqlGral.usp_TraerDescripcion(Tipo, Txt_Campo.Text, "")

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_Campo1.Text = objDataSet.Tables(0).Rows(0).Item("campo").ToString
                Else
                    Txt_Campo.Text = ""
                    myForm.Tipo = Tipo
                    myForm.Sw_Nomina = True
                    myForm.ShowDialog()
                    Txt_Campo.Text = myForm.Campo
                    Txt_Campo1.Text = myForm.Campo1
                    If Txt_Campo.Text.Length = 0 Then
                        Txt_Campo.Focus()
                    End If
                End If

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub Txt_ComentariosVen_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_ComentariosVen.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_SucursalSuc_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_SucursalSuc.KeyPress
        Call pub_SoloNumeros(sender, e)
    End Sub

    Private Sub Txt_SucursalSuc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_SucursalSuc.LostFocus
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringPerSis)
            If Txt_SucursalSuc.Text.Length = 0 Then Exit Sub

            Try
                'Get the specific project selected in the ListView control
                If Txt_SucursalSuc.Text.Trim.Length < 2 Then
                    Txt_SucursalSuc.Text = pub_RellenarIzquierda(Txt_SucursalSuc.Text.Trim, 2)
                End If

                Call TxtLostfocusPersis(Txt_SucursalSuc, Txt_DescripSusSuc, "S")


            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub Txt_ComentariosSuc_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_ComentariosSuc.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub

    Private Sub frmCatalogoEmpleados_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then
                If Accion = 1 Or Accion = 2 Then
                    If MessageBox.Show("Estas seguro de cancelar el registro ?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                        Me.Dispose()
                        Me.Close()

                    End If
                Else
                    Me.Dispose()
                    Me.Close()
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub CargarFormaConsulta(ByVal TipoC As String, ByVal Opcion As Integer)
        'mreyes 13/Junio/2012 01:28 p.m.
        Try
            Dim myForm As New frmConsulta
            If Opcion = 1 Then 'depto
                idDepto = 0
            End If
            If Opcion = 2 Then
                IdPuesto = 0
            End If
           

            myForm.Tipo = TipoC
            myForm.idDepto = IdDepto
            myForm.ShowDialog()
            If Opcion = 1 Then
                idDepto = Val(myForm.Campo)
                Txt_ClaveDeptoDep.Text = myForm.Campo1
                Txt_DescripDeptoD.Text = myForm.Campo2
                If Txt_ClaveDeptoDep.Text.Length = 0 Then
                    Txt_ClaveDeptoDep.Focus()
                End If
            End If

            If Opcion = 2 Then
                IdPuesto = Val(myForm.Campo)
                Txt_ClavePuestoDep.Text = myForm.Campo1
                Txt_DescripPuestoD.Text = myForm.Campo2
                If Txt_ClavePuestoDep.Text.Length = 0 Then
                    Txt_ClavePuestoDep.Focus()
                End If
            End If

           
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)

        End Try
    End Sub

    Private Sub Txt_ClaveDeptoDep_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_ClaveDeptoDep.LostFocus

        Try
            If Txt_ClaveDeptoDep.Text.Length = 0 Then Exit Sub
            Using objMySqlGral As New BCL.BCLCatalogoDeptos(GLB_ConStringNomSis)
                Try
                    objDataSet = objMySqlGral.usp_PpalCatalogoDepto(0, Txt_ClaveDeptoDep.Text, "")
                    If objDataSet.Tables(0).Rows.Count = 1 Then
                        IdDeptoNuevo = objDataSet.Tables(0).Rows(0).Item("iddepto")
                        Txt_DescripDeptoD.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                        Txt_ClaveDeptoDep.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    Else
                        Call CargarFormaConsulta("DE", 1)
                    End If

                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_ClaveDeptoDep_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_ClaveDeptoDep.TextChanged

    End Sub

    Private Sub Txt_ClavePuestoDep_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_ClavePuestoDep.LostFocus
        'mreyes 13/Junio/2012 07:03 p.m.
        Try
            If Txt_ClavePuestoDep.Text.Length = 0 Then Exit Sub
            Using objMySqlGral As New BCL.BCLCatalogoPuestos(GLB_ConStringNomSis)
                Try
                    objDataSet = objMySqlGral.usp_PpalCatalogoPuesto(0, IdDepto, Txt_ClavePuestoDep.Text, "")
                    If objDataSet.Tables(0).Rows.Count = 1 Then
                        IdPuestoNuevo = objDataSet.Tables(0).Rows(0).Item("idpuesto")
                        Txt_DescripPuestoD.Text = objDataSet.Tables(0).Rows(0).Item("descrippuesto").ToString
                        Txt_ClavePuestoDep.Text = objDataSet.Tables(0).Rows(0).Item("clavepuesto").ToString
                    Else
                        Call CargarFormaConsulta("PU", 2)
                    End If

                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)

        End Try
    End Sub

    Private Sub Txt_ClavePuestoDep_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_ClavePuestoDep.TextChanged

    End Sub

    Private Sub Txt_ComentariosBaja_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_ComentariosBaja.TextChanged

    End Sub

    Private Sub Txt_ComentariosDep_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_ComentariosDep.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub Txt_ComentariosDep_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_ComentariosDep.TextChanged

    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_DescripDeptoR.TextChanged

    End Sub

    Private Sub Txt_DeptoReingreso_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_DeptoReingreso.LostFocus
        Try
            If Txt_DeptoReingreso.Text.Length = 0 Then Exit Sub
            Using objMySqlGral As New BCL.BCLCatalogoDeptos(GLB_ConStringNomSis)
                Try
                    objDataSet = objMySqlGral.usp_PpalCatalogoDepto(0, Txt_DeptoReingreso.Text, "")
                    If objDataSet.Tables(0).Rows.Count = 1 Then
                        IdDeptoNuevo = objDataSet.Tables(0).Rows(0).Item("iddepto")
                        Txt_DescripDeptoR.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                        Txt_DeptoReingreso.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    Else
                        Call CargarFormaConsulta("DE", 1)
                    End If

                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_DeptoReingreso_MarginChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_DeptoReingreso.MarginChanged

    End Sub

    Private Sub Txt_DeptoReingreso_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_DeptoReingreso.TextChanged

    End Sub

    Private Sub Txt_PuestoReingreso_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_PuestoReingreso.LostFocus
        'mreyes 13/Junio/2012 07:03 p.m.
        Try
            If Txt_PuestoReingreso.Text.Length = 0 Then Exit Sub
            Using objMySqlGral As New BCL.BCLCatalogoPuestos(GLB_ConStringNomSis)
                Try
                    objDataSet = objMySqlGral.usp_PpalCatalogoPuesto(0, IdDepto, Txt_PuestoReingreso.Text, "")
                    If objDataSet.Tables(0).Rows.Count = 1 Then
                        IdPuestoNuevo = objDataSet.Tables(0).Rows(0).Item("idpuesto")
                        Txt_DescripPuestoR.Text = objDataSet.Tables(0).Rows(0).Item("descrippuesto").ToString
                        Txt_PuestoReingreso.Text = objDataSet.Tables(0).Rows(0).Item("clavepuesto").ToString
                    Else
                        Call CargarFormaConsulta("PU", 2)
                    End If

                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)

        End Try
    End Sub

    Private Sub Txt_PuestoReingreso_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_PuestoReingreso.TextChanged

    End Sub
End Class