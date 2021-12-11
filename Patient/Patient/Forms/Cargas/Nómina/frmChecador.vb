Public Class frmChecador
    Public SucSelect(50) As String
    Public IntSelect As Integer
    Public Opcion As Integer '1 = Registrar, 2 = Recolectar, '3 = Eliminar

    Public arrEmpleado() As Integer
    Public arreChecadores() As Integer
    Private objDataSet As Data.DataSet
    Private IdEmpleadoChec As String

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


    Private Sub TraerChecadores()

        Using objChecador As New BCL.BCLHuellasEmpleado(GLB_ConStringNomSis)
            Try
                'Me.Text = "Buscar Checador"

                'objDataSet = objChecador.usp_TraerChecadorSel("%" & Txt_Buscar.Text & "%")
                objDataSet = objChecador.usp_TraerChecadores()
                'Populate the Project Details section
                'DGrid.ReadOnly = True
                DGrid.DataSource = Nothing
                DGrid.DataSource = objDataSet.Tables(0)

                InicializaGrid()

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub RellenaGrid()
        Dim SqlWhere As String = ""
        Call TraerChecadores()
    End Sub

    Sub InicializaGrid()
        DGrid.RowHeadersVisible = False
        ''DGrid.AllowUserToResizeColumns = True
        DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGrid.Columns(2).Visible = False

        Call AgregarColumna()

        DGrid.Columns(2).ReadOnly = False
        DGrid.Columns(0).ReadOnly = True
        DGrid.Columns(1).ReadOnly = True
    End Sub

    Private Sub frmConsulta_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GLB_FormConsulta = False
    End Sub

    Private Sub frmConsulta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            GLB_FormConsulta = True
            Me.Close()
        End If

    End Sub

    Private Sub frmConsulta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            GLB_FormConsulta = True
            Call RellenaGrid()
            Call GenerarToolTip()

            If Opcion = 1 Then
                Label1.Text = "Seleccione las terminales a donde se Enviaran las Huellas."
            ElseIf Opcion = 2 Then
                Label1.Text = "Seleccione las terminales para Recolectar Huellas"
            ElseIf Opcion = 3 Then
                Label1.Text = "Seleccione las terminales donde se Eliminaran las Huellas."
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub GenerarToolTip()
        Try
            If Opcion = 1 Then
                ToolTip.SetToolTip(Btn_InvertirSeleccion, "Invertir selección")
                ToolTip.SetToolTip(Btn_Aceptar, "Enviar Huellas a sucursales seleccionadas")
            ElseIf Opcion = 2 Then
                ToolTip.SetToolTip(Btn_InvertirSeleccion, "Invertir selección")
                ToolTip.SetToolTip(Btn_Aceptar, "Recolectar Huellas de las sucursales seleccionadas")
            ElseIf Opcion = 3 Then
                ToolTip.SetToolTip(Btn_InvertirSeleccion, "Invertir selección")
                ToolTip.SetToolTip(Btn_Aceptar, "Eliminar Huellas de las sucursales seleccionadas")
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Buscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Buscar.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Buscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Buscar.TextChanged
        Try
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If ExportarDGridAExcel(DGrid) = False Then
                MsgBox("Error al exportar a Excel. Intente nuevamente.", MsgBoxStyle.Critical, "Excel")
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_InvertirSeleccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_InvertirSeleccion.Click
        For i As Integer = 0 To DGrid.Rows.Count - 2
            If DGrid.Rows(i).Cells("Selec").Value = True Then
                DGrid.Rows(i).Cells("Selec").Value = False
            Else
                DGrid.Rows(i).Cells("Selec").Value = True
            End If
        Next
    End Sub

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        'Tony Garcia - 05/Octubre/2012 - 6:00 p.m.
        'Dim myform As New frmEspera
        Dim i As Integer = 0
        Dim intContador = 0
        'Dim myForm As frmPpalEmpleados 

        If Opcion = 1 Then  'Llama al metodo registrarhuella
            If arrEmpleado.Length = 1 Then

                If MsgBox("Esta seguro de registrar las huellas del empleado seleccionado ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.Yes Then
                    'myform.Show()
                    For Each row As DataGridViewRow In DGrid.Rows
                        If row.Cells("Selec").Value = True Then
                            For emp As Integer = 0 To arrEmpleado.Length '* 2
                                IntSelect = row.Cells("idchecador").Value
                                Call Registrar(IntSelect)
                                i = i + 1
                                intContador += 1
                                GoTo BRINCO
                            Next
                        End If
                    Next
BRINCO:
                    If intContador > 1 Then
                        MsgBox("Las Huellas se han registrado correctamente en las Terminales seleccionadas.", MsgBoxStyle.Information, "Error")
                    Else
                        MsgBox("Las Huellas se han registrado correctamente en la Terminal " + Descripcion.ToString, MsgBoxStyle.Information, "Error")
                    End If
                End If
            ElseIf arrEmpleado.Length > 1 Then
                If MsgBox("Esta seguro de registrar las huellas de los empleados seleccionados ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.Yes Then
                    For Each row As DataGridViewRow In DGrid.Rows
                        If row.Cells("Selec").Value = True Then
                            For emp As Integer = 0 To arrEmpleado.Length '* 2
                                IntSelect = row.Cells("idchecador").Value
                                Call Registrar(IntSelect)
                                i = i + 1
                                intContador += 1
                            Next
                        End If
                    Next
                    If intContador > 1 Then
                        MsgBox("Las Huellas se han registrado correctamente en las Terminales seleccionadas.", MsgBoxStyle.Information, "Error")
                    Else
                        MsgBox("Las Huellas se han registrado correctamente en la Terminal " + Descripcion.ToString, MsgBoxStyle.Information, "Error")
                    End If

                End If
            End If

        ElseIf Opcion = 2 Then
            For Each row As DataGridViewRow In DGrid.Rows
                If row.Cells("Selec").Value = True Then
                    ReDim Preserve arreChecadores(intContador)
                    arreChecadores(intContador) = row.Cells("IdChecador").Value
                    intContador += 1
                End If
            Next

        ElseIf Opcion = 3 Then
            If MsgBox("Esta seguro de Eliminar las huellas de los empleados seleccionados ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.Yes Then
                For Each row As DataGridViewRow In DGrid.Rows
                    If row.Cells("Selec").Value = True Then
                        IntSelect = row.Cells("idchecador").Value

                        Call EliminarHuellas(IntSelect)
                        i = i + 1
                        intContador += 1
                    End If
                Next
            End If
        End If
            'arreChecadores = myForm.arreChecadores
        Me.Close()
    End Sub

    Private Sub AgregarColumna()
        Dim colImagen As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        colImagen.Name = "Selec"
        colImagen.HeaderText = "Selec"
        colImagen.DisplayIndex = 3

        colImagen.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        colImagen.CellTemplate = New DataGridViewCheckBoxCell()
        ' añadir columna de imagen a la coleccion del grid 
        DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        ''DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DGrid.Columns.Add(colImagen)
    End Sub

    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub

    Private Sub Pnl_Edicion_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Edicion.Paint

    End Sub

    Private Sub Registrar(ByVal Terminal As Integer)
        'Tony Garcia - 05/Octubre/2012 - 5:00 p.m.
        Dim iMachineNumber As Integer
        Dim sOption As String = "~ZKFPVersion"
        Dim DataSetHuellas As Data.DataSet
        Dim DataSetChecador As Data.DataSet
        Dim sValue As String = ""
        Dim blnHuella1 As Boolean = False
        Dim byTmpData(700) As Byte
        Dim byTmpData2(700) As Byte
        Dim intContH As Integer = 1

        'Ejecuta el proceso de registro de huella por cada empleado seleccionado en el Catalogo de Empleados
        For Each empleado As Integer In arrEmpleado

            blnHuella1 = False

            'Localiza las huellas del empleado a registrar en la terminal
            Using objHuellasEmp As New BCL.BCLHuellasEmpleado(GLB_ConStringNomSis)
                Try
                    DataSetHuellas = objHuellasEmp.usp_TraerHuellasEmp(empleado)

                    If DataSetHuellas.Tables(0).Rows.Count = 0 Then
                        ' MsgBox("No se encontraron huellas para registrar", MsgBoxStyle.Exclamation, "Error")
                        CZKEM1.Disconnect()
                        Exit Sub
                    End If

                    byTmpData = DataSetHuellas.Tables(0).Rows(0).Item("template")
                    'byTmpData2 = DataSetHuellas.Tables(0).Rows(1).Item("template")

                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try

            End Using

            'Localiza el checador a donde se enviara la huella
            Using objChecador As New BCL.BCLHuellasEmpleado(GLB_ConStringNomSis)
                Try
                    DataSetChecador = objChecador.usp_TraerChecador(Terminal, "")

                    Checador_Id = DataSetChecador.Tables(0).Rows(0).Item("IDChecador").ToString.Trim
                    Direccion_IP = DataSetChecador.Tables(0).Rows(0).Item("ip").ToString.Trim
                    Descripcion = DataSetChecador.Tables(0).Rows(0).Item("descripcion").ToString.Trim
                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using

            'Realiza la conexion con la terminal
            bconn = CZKEM1.Connect_Net(Direccion_IP, 4370)

            If bconn Then
                If CZKEM1.GetSysOption(iMachineNumber, sOption, sValue) Then
                    If sValue = "10" Then
                        MsgBox("Your device is not using 9.0 arithmetic!", MsgBoxStyle.Exclamation, "Error")
                        CZKEM1.Disconnect()
                        Return
                    End If
                End If

                Dim errorcode As Integer

                'Verifica si las huellas existen en la terminal y las registra en caso de no existir
                For i As Integer = 0 To DataSetHuellas.Tables(0).Rows.Count - 1

                    Dim TipoUsuario As Integer = 0
                    Dim Pass As String = Nothing


                    If Not CZKEM1.SetUserInfo(iMachineNumber, empleado, "", Pass, TipoUsuario, True) Then 'As U Suggest
                        CZKEM1.GetLastError(errorcode)
                        'If errorcode = 0 Then
                        '    MsgBox("No se encontro huella!", MsgBoxStyle.Exclamation, "Error")
                        'End If
                    Else
                        ' MsgBox("Usuario Creado en Terminal " & Descripcion, MsgBoxStyle.Information, "Registra Huella")
                    End If

                    If blnHuella1 = False Then
                        If Not CZKEM1.SetUserTmp(iMachineNumber, empleado, 0, byTmpData(0)) Then
                            CZKEM1.GetLastError(errorcode)
                            If errorcode = -5 Then
                                'MsgBox("La Huella " + intContH.ToString + " del empleado " + empleado.ToString + " ya Existe en la Terminal " + Terminal.ToString, MsgBoxStyle.Exclamation, "Error")
                            End If
                            blnHuella1 = True
                            intContH += 1
                        End If
                    Else
                        If Not CZKEM1.SetUserTmp(iMachineNumber, empleado, 1, byTmpData2(0)) Then
                            CZKEM1.GetLastError(errorcode)
                            If errorcode = -5 Then
                                'MsgBox("La Huella " + intContH.ToString + " del empleado " + empleado.ToString + " ya Existe en la Terminal " & Descripcion, MsgBoxStyle.Exclamation, "Error")
                            End If
                        End If
                    End If
                Next
                CZKEM1.Disconnect()
            End If
        Next
        'MsgBox("Las Huellas se han registrado correctamente en la Terminal " + Descripcion.ToString, MsgBoxStyle.Exclamation, "Error")
    End Sub

    Private Sub EliminarHuellas(ByVal Terminal As Integer)
        Dim DataSetHuellas As New DataSet
        Dim sOption As String = "~ZKFPVersion"
        Dim sValue As String = ""
        Dim iMachineNumber As Integer
        Dim blnHuella1 As Boolean = False

        For Each empleado As Integer In arrEmpleado
            Using objChecador As New BCL.BCLHuellasEmpleado(GLB_ConStringNomSis)
                Try
                    DataSetHuellas = objChecador.usp_TraerChecador(Terminal, "")
                    For Each renglon As DataRow In DataSetHuellas.Tables(0).Rows
                        Try
                            Checador_Id = renglon.Item("idchecador").ToString.Trim
                            Direccion_IP = renglon.Item("ip").ToString.Trim
                            Descripcion = renglon.Item("descripcion").ToString.Trim
                            bconn = CZKEM1.Connect_Net(Direccion_IP, 4370)
                        Catch ExceptionErr As Exception
                            MessageBox.Show(ExceptionErr.Message.ToString)
                            Exit Sub
                        End Try

                        If bconn Then

                            If CZKEM1.GetSysOption(iMachineNumber, sOption, sValue) Then
                                If sValue = "10" Then
                                    MsgBox("Your device is not using 9.0 arithmetic!", MsgBoxStyle.Exclamation, "Error")
                                    Return
                                End If
                            End If
                            Dim errorcode As Integer

                           
                            If Not CZKEM1.DeleteEnrollData(Terminal, empleado, 1, 12) Then 'As U Suggest
                                CZKEM1.GetLastError(errorcode)
                                If errorcode = 0 Then
                                    MsgBox("No se encontro huella!", MsgBoxStyle.Exclamation, "Error")
                                End If
                                blnHuella1 = True
                                'Else
                                '    MsgBox("Las Huellas se han Eliminado correctamente de las sucursales seleccionadas.", MsgBoxStyle.Exclamation, "OK")
                            End If
                            'CZKEM1.EnableDevice(1, True)

                            CZKEM1.Disconnect()

                        End If
                    Next
                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using
        Next
        MsgBox("Las Huellas fueron Eliminadas correctamente.", MsgBoxStyle.Exclamation, "OK")
    End Sub
End Class