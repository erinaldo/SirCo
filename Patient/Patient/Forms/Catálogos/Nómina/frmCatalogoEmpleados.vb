Public Class frmCatalogoEmpleados
    'mreyes 15/Junio/2012 04:36 p.m.

    Dim Sql As String
    Public Accion As Integer  '' 1  = nuevo, 2 = edicion , 3 = eliminar , 4 = consultar 

    Private objDataSet As Data.DataSet
    Dim Sw_LibresProveedores As Boolean = False

    Dim IdDepto As Integer
    Dim IdPuesto As Integer
    Dim IdFrecPago As Integer

    Dim blnValVendedor As Boolean = False
    Public Sw_Tienda As Boolean = False
    Dim Sw_Validar As Boolean = True

    Function Inserta_Empleados() As Boolean
        'mreyes 18/Junio/2012 05:47 p.m.
        Dim Clave As String = ""
        Using objCatalogo As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)
            'Get a new Project DataSet
            Try

                objDataSet = objCatalogo.Inserta_Empleado  'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow

                blnValVendedor = ValidaVendedor()
                If blnValVendedor = True Then
                    'Set the values in the DataRow
                    If Accion = 1 Or Accion = 2 Then
                        ''Call usp_TraerClaveEmpleado()
                        Txt_Clave.Text = Txt_Sucursal.Text & pub_TraerConsecutivoEmp(Txt_Sucursal.Text)
                    End If

                    objDataRow.Item("idempleado") = Val(Txt_idempleado.Text)
                    objDataRow.Item("clave") = Txt_Clave.Text
                    objDataRow.Item("appaterno") = Trim(Txt_ApPaterno.Text)
                    objDataRow.Item("apmaterno") = Trim(Txt_ApMaterno.Text)
                    objDataRow.Item("nombre") = Trim(Txt_Nombre.Text)
                    objDataRow.Item("iddepto") = IdDepto
                    objDataRow.Item("idpuesto") = IdPuesto
                    objDataRow.Item("vendedor") = Trim(Txt_Vendedor.Text)
                    objDataRow.Item("idfrecpago") = 2
                    objDataRow.Item("jornada") = Val(Txt_jornada.Text)
                    objDataRow.Item("entrada") = Trim(Msk_Entrada.Text)
                    objDataRow.Item("comida") = Val(Txt_Comida.Text)
                    objDataRow.Item("descanso") = pub_TraerDiaDescanso(Cbo_Descanso.Text)
                    If Chk_Extras.Checked = True Then
                        objDataRow.Item("extras") = "S"
                    Else
                        objDataRow.Item("extras") = "N"
                    End If
                    objDataRow.Item("baja") = DtBaja.Value
                    objDataRow.Item("ingreso") = DTIngreso.Value
                    objDataRow.Item("estatus") = Mid(Cbo_Estatus.Text, 1, 1)
                    If Txt_BonoFijo.Text = "" Then
                        Txt_BonoFijo.Text = 0.0
                        objDataRow.Item("bonofijo") = CDec(Txt_BonoFijo.Text)
                    Else
                        objDataRow.Item("bonofijo") = CDec(Txt_BonoFijo.Text)
                    End If

                    objDataRow.Item("tsalario") = Mid(Cbo_TSalario.Text, 1, 1)
                    objDataRow.Item("zsalario") = Mid(Cbo_ZSalario.Text, 1, 1)
                    objDataRow.Item("porinteg") = (Txt_PorInteg.Text)
                    objDataRow.Item("sdiario") = Txt_Sdiario.Text
                    objDataRow.Item("shora") = Txt_SHora.Text
                    objDataRow.Item("sinteg") = Txt_SInteg.Text
                    If Chk_PTU.Checked = True Then
                        objDataRow.Item("ptu") = "S"
                    Else
                        objDataRow.Item("ptu") = "N"

                    End If

                    If Chk_IMSS.Checked = True Then
                        objDataRow.Item("imss") = "S"
                    Else
                        objDataRow.Item("imss") = "N"
                    End If
                    objDataRow.Item("bono") = "S"
                    objDataRow.Item("cuenta") = Txt_Cuenta.Text
                    objDataRow.Item("licencia") = Txt_Licencia.Text
                    objDataRow.Item("unimed") = Txt_UniMed.Text
                    objDataRow.Item("calle") = Txt_Calle.Text
                    objDataRow.Item("colonia") = Txt_Colonia.Text
                    objDataRow.Item("ciudad") = Cbo_Ciudad.Text
                    objDataRow.Item("estado") = Cbo_Estado.Text
                    objDataRow.Item("codpos") = Txt_CodPos.Text
                    objDataRow.Item("numext") = Txt_NumExt.Text
                    objDataRow.Item("numint") = Txt_NumInt.Text
                    objDataRow.Item("sexo") = Mid(Cbo_Sexo.Text, 1, 1)

                    objDataRow.Item("telef1") = Txt_Telef1.Text
                    objDataRow.Item("telef2") = Txt_Telef2.Text
                    objDataRow.Item("email") = Txt_Email.Text
                    objDataRow.Item("nacim") = DtNacim.Value
                    objDataRow.Item("ciudadnac") = Trim(Txt_CiudadNacim.Text)
                    objDataRow.Item("edocivil") = Mid(Cbo_EdoCivil.Text, 1, 1)
                    objDataRow.Item("numhijos") = Val(Txt_NumHijos.Text)
                    objDataRow.Item("nompadre") = Txt_NomPadre.Text
                    objDataRow.Item("nommadre") = Txt_NomMadre.Text
                    objDataRow.Item("rfc") = Txt_RFC.Text
                    objDataRow.Item("curp") = Txt_CURP.Text
                    objDataRow.Item("noimss") = Txt_IMSS.Text
                    If Chk_Checa.Checked = True Then
                        objDataRow.Item("checa") = "S"
                    Else
                        objDataRow.Item("checa") = "N"

                    End If
                    objDataRow.Item("usuario") = GLB_Usuario
                    objDataRow.Item("usumodif") = GLB_Usuario
                    objDataRow.Item("fummodif") = DateTime.Now


                    objDataRow.Item("beneficiario1") = Txt_Beneficiario1.Text
                    objDataRow.Item("parentesco1") = Cbo_Parentesco1.Text
                    objDataRow.Item("porcentaje1") = Val(Txt_Porcentaje1.Text)


                    objDataRow.Item("beneficiario2") = Txt_Beneficiario2.Text
                    objDataRow.Item("parentesco2") = Cbo_Parentesco2.Text
                    objDataRow.Item("porcentaje2") = Val(Txt_Porcentaje2.Text)

                    objDataRow.Item("cuentabajio") = Txt_CuentaBajio.Text




                    'Add the DataRow to the DataSet
                    objDataSet.Tables(0).Rows.Add(objDataRow)

                    'Add the Project
                    If Not objCatalogo.usp_Captura_Empleado(Accion, objDataSet) Then
                        'Throw New Exception("Falló Inserción de Proveedor")
                    Else
                        Inserta_Empleados = True
                    End If
                End If

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function


    Function Inserta_Horario() As Boolean
        'mreyes 20/Abril/2015   05:26 p.m.
        Dim Clave As String = ""

        'Get a new Project DataSet
        Try
            Dim DiaIngles As String = ""
            Dim prioridad As Integer = 0
            'DIA	DIAINGLES


            'INSERTA NUEVO DATASET
            'Initialize a datarow object from the Project DataSet
            For i As Integer = 0 To DGrid_Horario.RowCount - 2
                Using objCatalogo As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)
                    objDataSet = objCatalogo.Inserta_Horario
                    Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow


                    objDataRow.Item("idempleado") = Val(Txt_idempleado.Text)
                    'objDataRow.Item("dia") = DGrid_Horario.Rows(i).Cells("dia").Value.ToString.Trim()
                    'objDataRow.Item("entrada") = DGrid_Horario.Rows(i).Cells("entrada").Value.ToString.Trim()
                    'objDataRow.Item("salida") = DGrid_Horario.Rows(i).Cells("salida").Value.ToString.Trim()
                    'objDataRow.Item("entrada1") = DGrid_Horario.Rows(i).Cells("entrada1").Value.ToString.Trim()
                    'objDataRow.Item("salida1") = DGrid_Horario.Rows(i).Cells("salida1").Value.ToString.Trim()

                    objDataRow.Item("dia") = DGrid_Horario.Rows(i).Cells(0).Value.ToString.Trim()
                    objDataRow.Item("entrada") = DGrid_Horario.Rows(i).Cells(1).Value.ToString.Trim()
                    objDataRow.Item("salida") = DGrid_Horario.Rows(i).Cells(2).Value.ToString.Trim()
                    objDataRow.Item("entrada1") = DGrid_Horario.Rows(i).Cells(3).Value.ToString.Trim()
                    objDataRow.Item("salida1") = DGrid_Horario.Rows(i).Cells(4).Value.ToString.Trim()

                    If UCase(DGrid_Horario.Rows(i).Cells(0).Value.ToString.Trim()) = "DOMINGO" Then
                        DiaIngles = "SUNDAY"
                        prioridad = 4
                    ElseIf UCase(DGrid_Horario.Rows(i).Cells(0).Value.ToString.Trim()) = "JUEVES" Then
                        DiaIngles = "THURSDAY"

                        prioridad = 1
                    ElseIf UCase(DGrid_Horario.Rows(i).Cells(0).Value.ToString.Trim()) = "LUNES" Then
                        DiaIngles = "MONDAY"
                        prioridad = 5
                    ElseIf UCase(DGrid_Horario.Rows(i).Cells(0).Value.ToString.Trim()) = "MARTES" Then
                        DiaIngles = "TUESDAY"
                        prioridad = 6
                    ElseIf UCase(DGrid_Horario.Rows(i).Cells(0).Value.ToString.Trim()) = "MIÉRCOLES" Then
                        DiaIngles = "WEDNESDAY"
                        prioridad = 7
                    ElseIf UCase(DGrid_Horario.Rows(i).Cells(0).Value.ToString.Trim()) = "SÁBADO" Then
                        prioridad = 3
                        DiaIngles = "SATURDAY"
                    ElseIf UCase(DGrid_Horario.Rows(i).Cells(0).Value.ToString.Trim()) = "VIERNES" Then
                        prioridad = 2
                        DiaIngles = "FRIDAY"

                    End If
                    objDataRow.Item("prioridad") = prioridad
                    objDataRow.Item("diaingles") = DiaIngles
                    'Add the DataRow to the DataSet
                    objDataSet.Tables(0).Rows.Add(objDataRow)

                    'Add the Project
                    If Not objCatalogo.usp_Captura_Horario(Accion, objDataSet) Then
                        'Throw New Exception("Falló Inserción de Proveedor")
                    Else
                        Inserta_Horario = True
                    End If
                End Using
            Next

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Function

    Private Sub CargarFotoEmpleado()
        'miguel pérez 03/septiembre/2012 04:12 p.m.
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

    Private Sub TxtLostfocus(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
        'mreyes 28/Febrero/2012 01:20 p.m.
        Dim myForm As New frmConsulta

        If Txt_Campo.Text.Length = 0 Then Exit Sub
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
            Try
                objDataSet = objMySqlGral.usp_TraerDescripcion(Tipo, Txt_Campo.Text, "")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_Campo1.Text = objDataSet.Tables(0).Rows(0).Item("campo").ToString
                Else
                    Txt_Campo.Text = ""
                    myForm.Tipo = Tipo
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

    Private Function Validar() As Boolean
        'mreyes 06/Enero/2017   01:21 p.m.
        Try
            Validar = False

            If Txt_RFC.Text = "" Or Txt_RFC.TextLength <> 13 Then
                MsgBox("No puede registrar el empleado sin RFC correcto.", MsgBoxStyle.Critical, "Error")
                Exit Function
            End If

            If Txt_CURP.Text = "" Or Txt_CURP.TextLength < 10 Then
                MsgBox("No puede registrar el empleado sin CURP correcto.", MsgBoxStyle.Critical, "Error")
                Exit Function
            End If

            If Txt_IMSS.Text = "" Or Txt_IMSS.TextLength < 10 Then
                MsgBox("No puede registrar el empleado sin IMSS correcto.", MsgBoxStyle.Critical, "Error")
                Exit Function
            End If

            If Txt_Email.Text = "" Or Txt_Email.TextLength < 10 Then
                MsgBox("No puede registrar el empleado sin EMAIL correcto.", MsgBoxStyle.Critical, "Error")
                Exit Function
            End If
            Validar = True

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function
    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click

        Try
            If Sw_Validar = False Then
                MsgBox("No se puede grabar el empleado, verifique el horario.", MsgBoxStyle.Critical, "Error")
                Exit Sub
            End If
            If Validar() = False Then

                Exit Sub
            End If
            GLB_RefrescarPedido = False
            If Accion = 1 Then '''' es un articulo nuevo
                If MsgBox("Estas Seguro de Grabar el Empleado?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    If Inserta_Empleados() = True Then
                        If Inserta_Horario() = False Then
                            MessageBox.Show("No se grabo el horario '" & Txt_idempleado.Text & "' con nombre '" & Txt_Nombre.Text & " !", "Agregando Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.Close()
                        End If
                        GLB_RefrescarPedido = True
                        MessageBox.Show("Exitosamente Grabado el Empleado '" & Txt_idempleado.Text & "' con nombre '" & Txt_Nombre.Text & " !", "Agregando Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Close()
                        '' Me.Dispose()
                    Else
                        If blnValVendedor = False Then Exit Sub
                        MessageBox.Show("Error Grabando !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    End If
                End If
            ElseIf Accion = 2 Then ' es una actualización
                If MsgBox("Estas Seguro de Actualizar el Empleado?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    If Inserta_Empleados() = True Then

                        If Inserta_Horario() = False Then
                            'MessageBox.Show("No se grabo el horario '" & Txt_idempleado.Text & "' con nombre '" & Txt_Nombre.Text & " !", "Agregando Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            'Me.Close()
                        End If

                        GLB_RefrescarPedido = True
                        MessageBox.Show("Exitosamente Grabado el Empleado '" & Txt_idempleado.Text & "' con nombre '" & Txt_Nombre.Text & " !", "Actualizando Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Close()
                        ' Me.Dispose()
                    Else
                        If blnValVendedor = False Then Exit Sub
                        MessageBox.Show("Error Grabando !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Sub InicializaGrid()
        'mreyes 20/Abril/2015   12:56 p.m.
        Try

            DGrid_Horario.RowHeadersVisible = False
           



            If Accion = 1 Then
                DGrid_Horario.ColumnCount = 5
                DGrid_Horario.Rows.Add("JUEVES", "09:00:00", "14:00:00", "16:00:00", "19:30:00")
                DGrid_Horario.Rows.Add("VIERNES", "09:00:00", "14:00:00", "16:00:00", "19:30:00")
                DGrid_Horario.Rows.Add("SÁBADO", "09:00:00", "14:00:00", "", "")
                DGrid_Horario.Rows.Add("DOMINGO", "09:00:00", "14:00:00", "16:00:00", "19:30:00")
                DGrid_Horario.Rows.Add("LUNES", "09:00:00", "14:00:00", "16:00:00", "19:30:00")
                DGrid_Horario.Rows.Add("MARTES", "09:00:00", "14:00:00", "16:00:00", "19:30:00")
                DGrid_Horario.Rows.Add("MIÉRCOLES", "09:00:00", "14:00:00", "16:00:00", "19:30:00")
                DGrid_Horario.Columns(0).Frozen = True
            End If

            DGrid_Horario.Columns(0).Frozen = True
            DGrid_Horario.Columns(0).HeaderText = "Dia"
            DGrid_Horario.Columns(1).HeaderText = "Entrada"
            DGrid_Horario.Columns(2).HeaderText = "Salida"
            DGrid_Horario.Columns(3).HeaderText = "Entrada1"
            DGrid_Horario.Columns(4).HeaderText = "Salida1"

            DGrid_Horario.Columns(0).ReadOnly = True


            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmCatalogoEmpleados_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Call RellenaCombos(Cbo_Estado, "ESTADO", "", GLB_ConStringPerSis, True)

            If Accion = 1 Then
                ' LimpiarDatos()
                DtBaja.Enabled = False
                DtBaja.Value = "1900-01-01"
                Cbo_Estatus.Text = "ACTIVO"
                Cbo_Estatus.Enabled = False
                InicializaGrid()
            Else
                Call usp_TraerEmpleado()
                Call CargarFotoEmpleado()
            End If
            Call GenerarToolTip()

            Call Edicion()
            If Accion = 1 Then
                Txt_Nombre.Focus()
                Me.Txt_Nombre.SelectionStart = Me.Txt_Nombre.TextLength
            End If
            If Sw_Tienda = True Then
                TabControl1.TabPages.Remove(TabPage2)
                TabControl1.TabPages.Remove(TabPage3)
                TabControl1.TabPages.Remove(TabPage4)
                Txt_Nombre.Enabled = False
                Txt_ApPaterno.Enabled = False
                Txt_ApMaterno.Enabled = False
                Txt_Sucursal.Enabled = False
                Txt_ClaveDepto.Enabled = False
                Txt_ClavePuesto.Enabled = False
                Txt_Vendedor.Enabled = False
                Txt_ClaveFrecPago.Enabled = False
                Txt_jornada.Visible = False
                Chk_Checa.Visible = False
                Chk_Extras.Visible = False
                Txt_Comida.Enabled = False
                Cbo_Estatus.Enabled = False
                DTIngreso.Enabled = False
                DtBaja.Enabled = False


            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub usp_TraerClaveEmpleado()
        'mreyes 19/Junio/2012 04;57 p.m.
        Dim objDataSet As Data.DataSet
        Using objCatalogo As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)
            Try

                objDataSet = objCatalogo.usp_TraerClaveEmpleado(Txt_Sucursal.Text)
                If objDataSet.Tables(0).Rows.Count > 0 Then

                    Txt_Clave.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString


                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub


    Private Sub usp_TraerHorarioEmpleado(ByVal IdEmpleado As String)
        'mreyes 20/Abril/2015   01:21 p.m.


        Using objRepetitivo As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)

            Try
                Me.Cursor = Cursors.WaitCursor
                'DGrid.ReadOnly = True
                DGrid_Horario.DataSource = Nothing


                objDataSet = objRepetitivo.usp_TraerHorarioEmpleado(IdEmpleado)
                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section

                    DGrid_Horario.DataSource = objDataSet.Tables(0)

                    InicializaGrid()

                    'LimpiarBusqueda()


                End If
                Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using



    End Sub

    Private Sub usp_TraerEmpleado()
        'mreyes 20/Junio/2012 12:31 p.m.
        Dim objDataSet As Data.DataSet
        Using objCatalogo As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)
            Try

                objDataSet = objCatalogo.usp_TraerEmpleado(Txt_idempleado.Text)
                If objDataSet.Tables(0).Rows.Count > 0 Then

                    Txt_Clave.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    Txt_ApPaterno.Text = objDataSet.Tables(0).Rows(0).Item("appaterno").ToString
                    Txt_ApMaterno.Text = objDataSet.Tables(0).Rows(0).Item("apmaterno").ToString
                    Txt_Nombre.Text = objDataSet.Tables(0).Rows(0).Item("nombre").ToString
                    IdDepto = objDataSet.Tables(0).Rows(0).Item("iddepto")
                    Txt_ClaveDepto.Text = objDataSet.Tables(0).Rows(0).Item("clavedepto")
                    Txt_DescripDepto.Text = objDataSet.Tables(0).Rows(0).Item("descripdepto")
                    IdPuesto = objDataSet.Tables(0).Rows(0).Item("idpuesto")
                    Txt_Vendedor.Text = objDataSet.Tables(0).Rows(0).Item("vendedor")
                    Txt_ClavePuesto.Text = objDataSet.Tables(0).Rows(0).Item("clavepuesto")
                    Txt_DescripPuesto.Text = objDataSet.Tables(0).Rows(0).Item("descrippuesto")
                    Txt_Sucursal.Text = Mid(Txt_Clave.Text, 1, 2)
                    Txt_DescripSucursal.Text = pub_TraerNomSucursalNOMINA(Txt_Sucursal.Text)

                    IdFrecPago = objDataSet.Tables(0).Rows(0).Item("idfrecpago")
                    Txt_ClaveFrecPago.Text = objDataSet.Tables(0).Rows(0).Item("clavefrecpago")
                    Txt_DescripFrecPago.Text = objDataSet.Tables(0).Rows(0).Item("descripfrecpago")
                    Txt_jornada.Text = objDataSet.Tables(0).Rows(0).Item("jornada")
                    Msk_Entrada.Text = objDataSet.Tables(0).Rows(0).Item("entrada")
                    Txt_Comida.Text = objDataSet.Tables(0).Rows(0).Item("comida")



                    Cbo_Descanso.Text = pub_TraerDiaLargoDescanso(objDataSet.Tables(0).Rows(0).Item("descanso"))


                    If objDataSet.Tables(0).Rows(0).Item("extras") = "S" Then
                        Chk_Extras.Checked = True
                    Else
                        Chk_Extras.Checked = False
                    End If

                    DtBaja.Value = objDataSet.Tables(0).Rows(0).Item("baja")
                    DTIngreso.Value = objDataSet.Tables(0).Rows(0).Item("ingreso")

                    If (objDataSet.Tables(0).Rows(0).Item("estatus")) = "I" Then
                        Cbo_Estatus.Text = "INACTIVO"
                    ElseIf objDataSet.Tables(0).Rows(0).Item("estatus") = "B" Then
                        Cbo_Estatus.Text = "BAJA"
                    Else
                        Cbo_Estatus.Text = "ACTIVO"
                    End If
                    If objDataSet.Tables(0).Rows(0).Item("tsalario") = "M" Then
                        Cbo_TSalario.Text = "MIXTO"
                    ElseIf objDataSet.Tables(0).Rows(0).Item("tsalario") = "V" Then
                        Cbo_TSalario.Text = "VARIABLE"
                    Else
                        Cbo_TSalario.Text = "FIJO"
                    End If
                    Cbo_ZSalario.Text = objDataSet.Tables(0).Rows(0).Item("zsalario").ToString
                    Txt_PorInteg.Text = objDataSet.Tables(0).Rows(0).Item("porinteg")
                    Txt_Sdiario.Text = objDataSet.Tables(0).Rows(0).Item("sdiario")
                    Txt_SHora.Text = objDataSet.Tables(0).Rows(0).Item("shora")
                    Txt_SInteg.Text = objDataSet.Tables(0).Rows(0).Item("sinteg")
                    Txt_BonoFijo.Text = objDataSet.Tables(0).Rows(0).Item("bonofijo")

                    If objDataSet.Tables(0).Rows(0).Item("ptu") = "S" Then
                        Chk_PTU.Checked = True
                    Else
                        Chk_PTU.Checked = False
                    End If

                    If objDataSet.Tables(0).Rows(0).Item("imss") = "S" Then
                        Chk_IMSS.Checked = True
                    Else
                        Chk_IMSS.Checked = False
                    End If

                    Txt_Licencia.Text = objDataSet.Tables(0).Rows(0).Item("licencia")
                    Txt_UniMed.Text = objDataSet.Tables(0).Rows(0).Item("unimed")
                    Txt_Calle.Text = objDataSet.Tables(0).Rows(0).Item("calle")
                    Txt_Colonia.Text = objDataSet.Tables(0).Rows(0).Item("colonia").ToString
                    Cbo_Ciudad.Text = objDataSet.Tables(0).Rows(0).Item("ciudad").ToString
                    Cbo_Estado.Text = objDataSet.Tables(0).Rows(0).Item("estado").ToString


                    Txt_CodPos.Text = objDataSet.Tables(0).Rows(0).Item("codpos").ToString

                    Txt_NumExt.Text = objDataSet.Tables(0).Rows(0).Item("numext")
                    Txt_NumInt.Text = objDataSet.Tables(0).Rows(0).Item("numint")

                    If objDataSet.Tables(0).Rows(0).Item("sexo") = "F" Then
                        Cbo_Sexo.Text = "FEMENINO"
                    Else
                        Cbo_Sexo.Text = "MASCULINO"
                    End If

                    Txt_Telef1.Text = objDataSet.Tables(0).Rows(0).Item("telef1").ToString
                    Txt_Telef2.Text = objDataSet.Tables(0).Rows(0).Item("telef2").ToString
                    Txt_Email.Text = objDataSet.Tables(0).Rows(0).Item("email").ToString
                    DtNacim.Value = objDataSet.Tables(0).Rows(0).Item("nacim")
                    Txt_CiudadNacim.Text = objDataSet.Tables(0).Rows(0).Item("ciudadnac").ToString

                    Txt_NumHijos.Text = objDataSet.Tables(0).Rows(0).Item("numhijos")
                    Txt_NomPadre.Text = objDataSet.Tables(0).Rows(0).Item("nompadre").ToString
                    Txt_NomMadre.Text = objDataSet.Tables(0).Rows(0).Item("nommadre").ToString
                    Txt_RFC.Text = objDataSet.Tables(0).Rows(0).Item("rfc").ToString
                    Txt_CURP.Text = objDataSet.Tables(0).Rows(0).Item("curp").ToString
                    Txt_IMSS.Text = objDataSet.Tables(0).Rows(0).Item("noimss").ToString

                    If objDataSet.Tables(0).Rows(0).Item("checa").ToString = "S" Then
                        Chk_Checa.Checked = True
                    Else
                        Chk_Checa.Checked = False

                    End If

                    If objDataSet.Tables(0).Rows(0).Item("edocivil") = "S" Then
                        Cbo_EdoCivil.Text = "SOLTERO"
                    ElseIf objDataSet.Tables(0).Rows(0).Item("edocivil") = "C" Then
                        Cbo_EdoCivil.Text = "CASADO"
                    ElseIf objDataSet.Tables(0).Rows(0).Item("edocivil") = "D" Then
                        Cbo_EdoCivil.Text = "DIVORCIADO"
                    ElseIf objDataSet.Tables(0).Rows(0).Item("edocivil") = "U" Then
                        Cbo_EdoCivil.Text = "UNIÓN LIBRE"
                    Else
                        Cbo_EdoCivil.Text = "VIUDO"
                    End If

                    Txt_Cuenta.Text = objDataSet.Tables(0).Rows(0).Item("cuenta").ToString


                    Txt_Beneficiario1.Text = objDataSet.Tables(0).Rows(0).Item("beneficiario1").ToString
                    Cbo_Parentesco1.Text = objDataSet.Tables(0).Rows(0).Item("parentesco1").ToString
                    Txt_Porcentaje1.Text = Val(objDataSet.Tables(0).Rows(0).Item("porcentaje1"))

                    Txt_Beneficiario2.Text = objDataSet.Tables(0).Rows(0).Item("beneficiario2").ToString
                    Cbo_Parentesco2.Text = objDataSet.Tables(0).Rows(0).Item("parentesco2").ToString
                    Txt_Porcentaje2.Text = Val(objDataSet.Tables(0).Rows(0).Item("porcentaje2"))

                    Txt_CuentaBajio.Text = objDataSet.Tables(0).Rows(0).Item("cuentabajio").ToString




                    Call usp_TraerHorarioEmpleado(Txt_idempleado.Text)

                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Aceptar, "Aceptar la acción requerida por el usuario")
            ToolTip.SetToolTip(Btn_Cancelar, "Cancelar cualquier acción requerida por el usuario")
            ToolTip.SetToolTip(Btn_Nuevo, "Nuevo Proveedor")
            ToolTip.SetToolTip(Btn_Editar, "Editar Proveedor")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub LimpiarDatos()
        Try

            Txt_idempleado.Text = ""

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub TxtLostfocus(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Sql As String, ByVal Tipo As String)
        Dim myForm As New frmConsulta


        If Txt_Campo.Text.Length = 0 Then Exit Sub
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
            Try


                objDataSet = objMySqlGral.usp_TraerUnCampo(Sql)

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_Campo1.Text = objDataSet.Tables(0).Rows(0).Item("campo").ToString
                Else
                    Txt_Campo.Text = ""
                    myForm.Tipo = Tipo
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

    Private Sub Btn_Nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Nuevo.Click
        Try
            Accion = 1
            Call Edicion()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub Edicion()
        Try
            Select Case Accion
                Case 3, 4
                    Btn_Aceptar.Enabled = True
                    Btn_Cancelar.Enabled = True
                    Btn_Nuevo.Enabled = True
                    Btn_Editar.Enabled = True


                    Pnl_Edicion.Enabled = False
                    Pnl_Salario.Enabled = False
                    Pnl_Salario1.Enabled = False
                    Pnl_Salario3.Enabled = False
                    Pnl_DP.Enabled = False
                    Pnl_DP1.Enabled = False

                    Pnl_DP3.Enabled = False

                    Txt_idempleado.BackColor = TextboxBackColor


                Case 1, 2
                    Btn_Aceptar.Enabled = True
                    Btn_Cancelar.Enabled = True
                    Btn_Nuevo.Enabled = False
                    Btn_Editar.Enabled = False


                    If Accion = 1 Then
                        Txt_Nombre.Focus()
                        Application.DoEvents()
                    ElseIf Accion = 2 Then
                        Txt_Nombre.Focus()
                        Txt_idempleado.Enabled = False
                        ' Txt_Nombre.Enabled = False
                        Txt_idempleado.BackColor = TextboxBackColor
                        'Txt_Nombre.BackColor = TextboxBackColor
                        Txt_Nombre.Focus()
                        DtBaja.Enabled = False
                        Cbo_Estatus.Enabled = False
                     
                    End If
            End Select
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar.Click
        Accion = 2
        Call Edicion()
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

    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Try

            If Accion = 1 Or Accion = 2 Then
                If MessageBox.Show("Estas seguro de cancelar el registro ?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                    'Me.Dispose()
                    Me.Close()

                End If
            Else
                Me.Close()
                Me.Dispose()
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)


        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub Txt_RFC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Raz_Soc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Cbo_Ciudad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Cbo_CodPos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Cbo_Colonia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Cbo_Colonia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Txt_Calle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Telef1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Telef2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Fax_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Nombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Nombre.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_ApPaterno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_ApPaterno.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_ApMaterno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_ApMaterno.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_ApMaterno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_ApMaterno.TextChanged

    End Sub

    Private Sub Cbo_Departamento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Cbo_Frecuencia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Cbo_Frecuencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Cbo_Puesto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Cbo_Puesto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

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
            If Opcion = 3 Then
                IdFrecPago = 0
            End If
       
            myForm.Tipo = TipoC
            myForm.idDepto = IdDepto
            myForm.ShowDialog()
            If Opcion = 1 Then
                idDepto = Val(myForm.Campo)
                Txt_ClaveDepto.Text = myForm.Campo1
                Txt_DescripDepto.Text = myForm.Campo2
                If Txt_ClaveDepto.Text.Length = 0 Then
                    Txt_ClaveDepto.Focus()
                End If
            End If

            If Opcion = 2 Then
                IdPuesto = Val(myForm.Campo)
                Txt_ClavePuesto.Text = myForm.Campo1
                Txt_DescripPuesto.Text = myForm.Campo2
                If Txt_ClavePuesto.Text.Length = 0 Then
                    Txt_ClavePuesto.Focus()
                End If
            End If

            If Opcion = 3 Then
                IdFrecPago = Val(myForm.Campo)
                Txt_ClaveFrecPago.Text = myForm.Campo1
                Txt_DescripFrecPago.Text = myForm.Campo2
                If Txt_ClaveFrecPago.Text.Length = 0 Then
                    Txt_ClaveFrecPago.Focus()
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)

        End Try
    End Sub

    Private Sub Txt_ClaveDepto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_ClaveDepto.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_ClaveDepto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_ClaveDepto.LostFocus
        'mreyes 13/Junio/2012 07:03 p.m.
        Try
            If Txt_ClaveDepto.Text.Length = 0 Then Exit Sub
            Using objMySqlGral As New BCL.BCLCatalogoDeptos(GLB_ConStringNomSis)
                Try
                    objDataSet = objMySqlGral.usp_PpalCatalogoDepto(0, Txt_ClaveDepto.Text, "")
                    If objDataSet.Tables(0).Rows.Count = 1 Then
                        IdDepto = objDataSet.Tables(0).Rows(0).Item("iddepto")
                        Txt_DescripDepto.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                        Txt_ClaveDepto.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    Else
                        Call CargarFormaConsulta("DE", 1)
                    End If

                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using

            If Txt_ClaveDepto.Text = "VEN" Then
                '' TRAER VENDEDOR DE CIPSIS.
                '' GENERAR EL USUARIO 
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_ClavePuesto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_ClavePuesto.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Clave_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_ClavePuesto.LostFocus
        'mreyes 13/Junio/2012 07:03 p.m.
        Try
            If Txt_ClavePuesto.Text.Length = 0 Then Exit Sub
            Using objMySqlGral As New BCL.BCLCatalogoPuestos(GLB_ConStringNomSis)
                Try
                    objDataSet = objMySqlGral.usp_PpalCatalogoPuesto(0, 0, Txt_ClavePuesto.Text, "")
                    If objDataSet.Tables(0).Rows.Count = 1 Then
                        IdPuesto = objDataSet.Tables(0).Rows(0).Item("idpuesto")
                        Txt_DescripPuesto.Text = objDataSet.Tables(0).Rows(0).Item("descrippuesto").ToString
                        Txt_ClavePuesto.Text = objDataSet.Tables(0).Rows(0).Item("clavepuesto").ToString
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

    Private Sub Txt_Sucursal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Sucursal.KeyPress
        Call pub_SoloNumeros(sender, e)
    End Sub

    Private Sub Txt_Sucursal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Sucursal.LostFocus
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringPerSis)
            If Txt_Sucursal.Text.Length = 0 Then Exit Sub

            Try
                'Get the specific project selected in the ListView control
                If Txt_Sucursal.Text.Trim.Length < 2 Then
                    Txt_Sucursal.Text = pub_RellenarIzquierda(Txt_Sucursal.Text.Trim, 2)
                End If

                Call TxtLostfocusPersis(Txt_Sucursal, Txt_DescripSucursal, "S")


            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub Txt_ClaveFrecPago_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_ClaveFrecPago.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_ClaveFrecPago_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_ClaveFrecPago.LostFocus
        'mreyes 13/Junio/2012 07:03 p.m.
        Try
            If Txt_ClaveFrecPago.Text.Length = 0 Then Exit Sub
            Using objMySqlGral As New BCL.BCLCatalogoFrecPago(GLB_ConStringNomSis)
                Try
                    objDataSet = objMySqlGral.usp_PpalCatalogoFrecPago(Txt_ClaveFrecPago.Text)
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Txt_DescripFrecPago.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                        Txt_ClaveFrecPago.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    Else
                        Call CargarFormaConsulta("FP", 3)
                    End If


                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)

        End Try
    End Sub

    Private Function ValidaVendedor() As Boolean
        ValidaVendedor = True
        If Txt_ClavePuesto.Text = "VEN" Then

            If Txt_Vendedor.Text = "" Then
                ValidaVendedor = False
                MessageBox.Show("Debe ingresar el número de Vendedor.", "ATENCION!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Txt_Vendedor.Focus()
                Exit Function
            End If

        End If
    End Function

    Private Sub Txt_NomPadre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_NomPadre.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_jornada_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_jornada.KeyPress
        ''Call pub_SoloNumeros(sender, e)
        Call pub_NumDecimales(sender, e)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Msk_Entrada_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Msk_Entrada.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Comida_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Comida.KeyPress
        Call pub_NumDecimales(sender, e)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Cbo_Estatus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cbo_Estatus.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub ComboBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cbo_TSalario.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_PorInteg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_PorInteg.KeyPress
        ''Call pub_SoloNumeros(sender, e)
        Call pub_NumDecimales(sender, e)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Sdiario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Sdiario.KeyPress
        'Call pub_SoloNumeros(sender, e)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_SHora_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_SHora.KeyPress
        Call pub_SoloNumeros(sender, e)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_SInteg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_SInteg.KeyPress
        ''Call pub_SoloNumeros(sender, e)
        Call pub_NumDecimales(sender, e)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_BonoFijo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_BonoFijo.KeyPress
        ''Call pub_SoloNumeros(sender, e)
        Call pub_NumDecimales(sender, e)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Cbo_Sexo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cbo_Sexo.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Cbo_EdoCivil_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cbo_EdoCivil.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_NumHijos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_NumHijos.KeyPress
        Call pub_SoloNumeros(sender, e)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DtNacim_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtNacim.KeyPress


        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Cbo_CiudadNacim_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_CiudadNacim_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_CiudadNacim.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_NomMadre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_NomMadre.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_UniMed_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_UniMed.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_RFC_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_RFC.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_CURP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_CURP.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_IMSS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_IMSS.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Licencia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Licencia.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Calle_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Calle.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Telef1_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Telef1.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Telef2_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Telef2.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Email_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Email.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TextBox15_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_NumExt.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Colonia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Colonia.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Cuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Cuenta.KeyPress
        Call pub_SoloNumeros(sender, e)
    End Sub

    Private Sub Cbo_Estado_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cbo_Estado.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Cbo_Estado_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cbo_Estado.LostFocus
        Call RellenaCombos(Cbo_Ciudad, "CIUDAD", " WHERE estado = '" & Cbo_Estado.Text & "'", GLB_ConStringPerSis, True)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    End Sub

    Private Sub Pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub

    Private Sub Txt_Nombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Nombre.TextChanged

    End Sub

    Private Sub Txt_Sdiario_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Sdiario.LostFocus
        Try

            If Val(Txt_Sdiario.Text) = 100 Then
                Txt_PorInteg.Text = "4.93"
                Txt_SHora.Text = "12.50"
                Txt_SInteg.Text = "104.79"
            ElseIf Val(Txt_Sdiario.Text) = 90 Then
                Txt_PorInteg.Text = "4.52"
                Txt_SHora.Text = "11.25"
                Txt_SInteg.Text = "94.07"
            ElseIf Val(Txt_Sdiario.Text) = 80 Then
                Txt_PorInteg.Text = "4.52"
                Txt_SHora.Text = "10.00"
                Txt_SInteg.Text = "83.62"
            ElseIf Val(Txt_Sdiario.Text) = 88.36 Then
                Txt_PorInteg.Text = "1.0452"
                Txt_SHora.Text = "11.04"
                Txt_SInteg.Text = "92.35"
            ElseIf Val(Txt_Sdiario.Text) = 95 Then
                Txt_PorInteg.Text = "4.66"
                Txt_SHora.Text = "11.88"
                Txt_SInteg.Text = "99.42"
            ElseIf Val(Txt_Sdiario.Text) = 85 Then
                Txt_PorInteg.Text = "4.93"
                Txt_SHora.Text = "10.63"
                Txt_SInteg.Text = "89.07"
            ElseIf Val(Txt_Sdiario.Text) = 96 Then
                Txt_PorInteg.Text = "1.0452"
                Txt_SHora.Text = "12.00"
                Txt_SInteg.Text = "100.34"
            ElseIf Val(Txt_Sdiario.Text) = 108 Then
                Txt_PorInteg.Text = "1.0452"
                Txt_SHora.Text = "13.50"
                Txt_SInteg.Text = "112.88"
            ElseIf Val(Txt_Sdiario.Text) = 102.68 Then
                Txt_PorInteg.Text = "1.0452"
                Txt_SHora.Text = "12.84"
                Txt_SInteg.Text = "107.32"
            ElseIf Val(Txt_Sdiario.Text) = 104.6 Then
                Txt_PorInteg.Text = "1.0452"
                Txt_SHora.Text = "13.08"
                Txt_SInteg.Text = "109.33"
            ElseIf Val(Txt_Sdiario.Text) = 110.4 Then
                Txt_PorInteg.Text = "1.0452"
                Txt_SHora.Text = "13.8"
                Txt_SInteg.Text = "115.39"
            ElseIf Val(Txt_Sdiario.Text) = 116.2 Then
                Txt_PorInteg.Text = "1.0452"
                Txt_SHora.Text = "14.53"
                Txt_SInteg.Text = "121.45"
            ElseIf Val(Txt_Sdiario.Text) = 127.82 Then
                Txt_PorInteg.Text = "1.0452"
                Txt_SHora.Text = "18.26"
                Txt_SInteg.Text = "133.6"

            ElseIf Val(Txt_Sdiario.Text) = 123.22 Then
                Txt_PorInteg.Text = "1.0452"
                Txt_SHora.Text = "15.40"
                Txt_SInteg.Text = "128.79"
            ElseIf Val(Txt_Sdiario.Text) = 125.14 Then
                Txt_PorInteg.Text = "1.0452"
                Txt_SHora.Text = "15.64"
                Txt_SInteg.Text = "130.80"
            ElseIf Val(Txt_Sdiario.Text) = 130.94 Then
                Txt_PorInteg.Text = "1.0452"
                Txt_SHora.Text = "16.37"
                Txt_SInteg.Text = "136.86"
            ElseIf Val(Txt_Sdiario.Text) = 136.74 Then
                Txt_PorInteg.Text = "1.0452"
                Txt_SHora.Text = "17.09"
                Txt_SInteg.Text = "142.92"
            ElseIf Val(Txt_Sdiario.Text) = 148.36 Then
                Txt_PorInteg.Text = "1.0452"
                Txt_SHora.Text = "18.55"
                Txt_SInteg.Text = "155.07"


            ElseIf Val(Txt_Sdiario.Text) = 141.7 Then
                Txt_PorInteg.Text = "1.0452"
                Txt_SHora.Text = "17.71"
                Txt_SInteg.Text = "148.10"
            ElseIf Val(Txt_Sdiario.Text) = 143.7 Then
                Txt_PorInteg.Text = "1.0452"
                Txt_SHora.Text = "17.96"
                Txt_SInteg.Text = "150.20"
            ElseIf Val(Txt_Sdiario.Text) = 147.7 Then
                Txt_PorInteg.Text = "1.0452"
                Txt_SHora.Text = "18.46"
                Txt_SInteg.Text = "154.38"
            ElseIf Val(Txt_Sdiario.Text) = 151.7 Then
                Txt_PorInteg.Text = "1.0452"
                Txt_SHora.Text = "18.96"
                Txt_SInteg.Text = "158.56"
            ElseIf Val(Txt_Sdiario.Text) = 155.7 Then
                Txt_PorInteg.Text = "1.0452"
                Txt_SHora.Text = "19.46"
                Txt_SInteg.Text = "162.74"

            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Sdiario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Sdiario.TextChanged

    End Sub

    Private Sub validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'mreyes 20/Abril/2015   04:58 p.m.
        Try
            ' obtener indice de la columna  
           
            If Accion = 3 Or Accion = 4 Then
                e.KeyChar = Chr(0)
                Exit Sub
            End If

            e.KeyChar = UCase(e.KeyChar)
            Dim columna As Integer = DGrid_Horario.CurrentCell.ColumnIndex
            Dim renglon As Integer = DGrid_Horario.CurrentCell.RowIndex
            Dim caracter As Char = e.KeyChar
            Dim CaracterAnt As String = ""


            If Not Char.IsNumber(caracter) And (caracter = ":") = False And (caracter <> "") Then
                If (caracter <> ChrW(58)) Then
                    e.KeyChar = Chr(0)
                End If
            End If




        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_Horario_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid_Horario.CellDoubleClick
        Dim renglon As Integer = DGrid_Horario.CurrentCell.RowIndex
        Dim columna As Integer = DGrid_Horario.CurrentCell.ColumnIndex
        For I As Integer = renglon + 1 To DGrid_Horario.RowCount - 2

            DGrid_Horario.Rows(I).Cells(columna).Value = DGrid_Horario.Rows(renglon).Cells(columna).Value
            DGrid_Horario.Rows(I).Cells(columna).Value = DGrid_Horario.Rows(renglon).Cells(columna).Value

        Next
    End Sub

    Private Sub DGrid_Horario_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid_Horario.CellEndEdit
        Dim columna As Integer = DGrid_Horario.CurrentCell.ColumnIndex
        Dim renglon As Integer = DGrid_Horario.CurrentCell.RowIndex
        Try

            Sw_Validar = True

            If Len(DGrid_Horario.Rows(renglon).Cells(3).Value) <> 8 And Len(DGrid_Horario.Rows(renglon).Cells(4).Value) = 8 Then

                DGrid_Horario.Rows(renglon).Cells(columna).Style.BackColor = Color.Yellow
                DGrid_Horario.Rows(renglon).Cells(columna).Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                MsgBox("Verificar horario", MsgBoxStyle.Critical, "Error")


                Sw_Validar = False
            End If


            If Len(DGrid_Horario.Rows(renglon).Cells(2).Value) <> 8 And Len(DGrid_Horario.Rows(renglon).Cells(1).Value) = 8 Then

                DGrid_Horario.Rows(renglon).Cells(columna).Style.BackColor = Color.Yellow
                DGrid_Horario.Rows(renglon).Cells(columna).Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                MsgBox("Verificar horario", MsgBoxStyle.Critical, "Error")


                Sw_Validar = False
            End If


            If Len(DGrid_Horario.Rows(renglon).Cells(columna).Value) <> 8 Then

                DGrid_Horario.Rows(renglon).Cells(columna).Style.BackColor = Color.Yellow
                DGrid_Horario.Rows(renglon).Cells(columna).Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                MsgBox("Verificar horario", MsgBoxStyle.Critical, "Error")


                Sw_Validar = False
            End If

            If Mid(DGrid_Horario.Rows(renglon).Cells(columna).Value, 1, 2) = "00" Then
                DGrid_Horario.Rows(renglon).Cells(columna).Style.BackColor = Color.Yellow
                DGrid_Horario.Rows(renglon).Cells(columna).Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                MsgBox("Verificar horario", MsgBoxStyle.Critical, "Error")
                Sw_Validar = False
            End If

            If Mid(DGrid_Horario.Rows(renglon).Cells(columna).Value, 4, 2) <> "00" And Mid(DGrid_Horario.Rows(renglon).Cells(columna).Value, 4, 2) <> "30" Then
                DGrid_Horario.Rows(renglon).Cells(columna).Style.BackColor = Color.Yellow
                DGrid_Horario.Rows(renglon).Cells(columna).Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                MsgBox("Verificar horario", MsgBoxStyle.Critical, "Error")


                Sw_Validar = False

            End If

            If Mid(DGrid_Horario.Rows(renglon).Cells(columna).Value, 7, 2) <> "00" And Mid(DGrid_Horario.Rows(renglon).Cells(columna).Value, 4, 2) <> "30" Then
                DGrid_Horario.Rows(renglon).Cells(columna).Style.BackColor = Color.Yellow
                DGrid_Horario.Rows(renglon).Cells(columna).Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                MsgBox("Verificar horario", MsgBoxStyle.Critical, "Error")


                Sw_Validar = False

            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub DGrid_Horario_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGrid_Horario.EditingControlShowing
        Dim validar As TextBox = CType(e.Control, TextBox)
        Try
            ' agregar el controlador de eventos para el KeyPress   
            AddHandler validar.KeyPress, AddressOf validar_Keypress
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_Horario_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid_Horario.CellContentClick

    End Sub

    Private Sub Txt_idempleado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_idempleado.TextChanged

    End Sub

    Private Sub Txt_IdEmpleado1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_IdEmpleado1.LostFocus
        Dim objDataSet As Data.DataSet
        Using objCatalogo As New BCL.BCLCatalogoMovEmp(GLB_ConStringNomSis)
            Try
                If Txt_idempleado.Text.Length = 0 Then Exit Sub
                objDataSet = objCatalogo.usp_TraerEmpleado(Txt_IdEmpleado1.Text)
                If objDataSet.Tables(0).Rows.Count > 0 Then

                    Txt_NomEmpleado1.Text = objDataSet.Tables(0).Rows(0).Item("nomcompleto").ToString


                Else
                    Call CargarFormaConsultaEmpleado()
                    ''MessageBox.Show("El empleado no existe, ingrese un ID valido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
                Call usp_TraerHorarioEmpleado(Txt_IdEmpleado1.Text)
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub Txt_IdEmpleado1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_IdEmpleado1.TextChanged
       
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

    Private Sub Txt_ClaveDepto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_ClaveDepto.TextChanged

    End Sub

    Private Sub Txt_ClavePuesto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_ClavePuesto.TextChanged

    End Sub

    Private Sub Msk_Entrada_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles Msk_Entrada.MaskInputRejected

    End Sub

    Private Sub Txt_PorInteg_TextChanged(sender As Object, e As EventArgs) Handles Txt_PorInteg.TextChanged

    End Sub

    Private Sub Cbo_TSalario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cbo_TSalario.SelectedIndexChanged

    End Sub

    Private Sub Cbo_TSalario_KeyDown(sender As Object, e As KeyEventArgs) Handles Cbo_TSalario.KeyDown

    End Sub
End Class