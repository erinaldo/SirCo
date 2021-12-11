Public Class frmCatalogoActividades


    'Tony Garcia - 13/Octubre/2012 - 12:10 p.m.

    Private objDataSet As Data.DataSet
    Private UltimoFolio As Integer = 0
    Private blnValida = False

    Public Accion As Integer  '' 1  = nuevo, 2 = edicion , 4 = consulta
    'Dim IdDepto As Integer = 0
    'Dim IdPuesto As Integer = 0 
    Dim ContadorMov As Integer = 0
    Public Estatus As String = ""
    Public IdActividad As Integer
    Public FechaAlta As Date
    Public FechaProceso As Date
    Public FechaRealizado As Date

    Private Sub frmCatalogoMovEmp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            GLB_RefrescarPedido = False
            Call CargaComboActSistemas()
            Call GenerarLabelFecha()
            If Accion = 1 Then
                Call usp_TraerUltimoFolioAct()
                UltimoFolio = UltimoFolio + 1
                Txt_Folio.Text = UltimoFolio.ToString
                pub_RellenarIzquierda(Txt_Folio.Text, 4)
            Else
                Call usp_TraerActividadEmp()
            End If
            Call GenerarToolTip()
            Call RedimensionarForm()
            Call Edicion()

            If GLB_Sucursal <> "" Then
                Txt_Asignado.Text = "132"
                Txt_DescripAsignado.Text = "REYES SANCHEZ MARTHA JOSEFINA"
                Txt_Asignado.Enabled = False
            End If

            Cbo_TipoAct.Focus()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub CargaComboActSistemas()
        Cbo_TipoAct.Items.Clear()
        Cbo_TipoAct.Items.Add("SELECCIONAR...")

        Dim Actividades(9) As String

        Actividades(0) = "DESARROLLO"
        Actividades(1) = "MODIFICACION"
        Actividades(2) = "REPORTE"
        Actividades(3) = "REPARACION"
        Actividades(4) = "SOPORTE"
        Actividades(5) = "RESPALDO"
        Actividades(6) = "COTIZACION"
        Actividades(7) = "DOCUMENTACION"
        Actividades(8) = "INSTALACION"
        Actividades(9) = "REVISION"

        Array.Sort(Actividades)
        Cbo_TipoAct.Items.AddRange(Actividades)
        Cbo_TipoAct.SelectedIndex = 0
    End Sub

    Private Sub RedimensionarForm()
        'Para nuevo registro
        If Accion = 1 AndAlso Estatus = "C" Then
            Me.Size = New System.Drawing.Size(444, 347)
            Txt_Resultado.Visible = False
        ElseIf Accion = 1 AndAlso Estatus = "S" Then
            Me.Size = New System.Drawing.Size(444, 431)
            Txt_Resultado.Visible = True
        ElseIf Accion = 1 AndAlso Estatus = "R" Then
            Me.Size = New System.Drawing.Size(444, 431)
            Txt_Resultado.Visible = True
        ElseIf Accion = 1 AndAlso Estatus = "P" Then
            Me.Size = New System.Drawing.Size(444, 431)
            Txt_Resultado.Visible = True
        ElseIf Accion = 1 AndAlso Estatus = "E" Then
            Me.Size = New System.Drawing.Size(444, 431)
            Txt_Resultado.Visible = True
        ElseIf Accion = 1 AndAlso Estatus = "X" Then
            Me.Size = New System.Drawing.Size(444, 347)
            Txt_Resultado.Visible = False
        ElseIf Accion = 1 AndAlso Estatus = "N" Then
            Me.Size = New System.Drawing.Size(444, 431)
            Txt_Resultado.Visible = True
        End If

        'Para modificar registro
        If Accion = 2 AndAlso Estatus = "C" Then
            Me.Size = New System.Drawing.Size(444, 347)
            Txt_Resultado.Visible = False
        ElseIf Accion = 2 AndAlso Estatus = "S" Then
            Me.Size = New System.Drawing.Size(444, 431)
            Txt_Resultado.Visible = True
        ElseIf Accion = 2 AndAlso Estatus = "R" Then
            Me.Size = New System.Drawing.Size(444, 522)
            Txt_Resultado.Visible = True
        ElseIf Accion = 2 AndAlso Estatus = "P" Then
            Me.Size = New System.Drawing.Size(444, 431)
            Txt_Resultado.Visible = True
        ElseIf Accion = 2 AndAlso Estatus = "E" Then
            Me.Size = New System.Drawing.Size(444, 431)
            Txt_Resultado.Visible = True
        ElseIf Accion = 2 AndAlso Estatus = "X" Then
            Me.Size = New System.Drawing.Size(444, 347)
            Txt_Resultado.Visible = False
        ElseIf Accion = 2 AndAlso Estatus = "N" Then
            Me.Size = New System.Drawing.Size(444, 431)
            Txt_Resultado.Visible = True
        End If

        'Para consulta de registro
        If Accion = 4 AndAlso Estatus = "C" Then
            Me.Size = New System.Drawing.Size(444, 347)
            Txt_Resultado.Visible = False
        ElseIf Accion = 4 AndAlso Estatus = "S" Then
            Me.Size = New System.Drawing.Size(444, 431)
            Txt_Resultado.Visible = True
        ElseIf Accion = 4 AndAlso Estatus = "R" Then
            Me.Size = New System.Drawing.Size(444, 522)
            Txt_Resultado.Visible = True
        ElseIf Accion = 4 AndAlso Estatus = "P" Then
            Me.Size = New System.Drawing.Size(444, 431)
            Txt_Resultado.Visible = True
        ElseIf Accion = 4 AndAlso Estatus = "E" Then
            Me.Size = New System.Drawing.Size(444, 431)
            Txt_Resultado.Visible = True
        ElseIf Accion = 4 AndAlso Estatus = "X" Then
            Me.Size = New System.Drawing.Size(444, 347)
            Txt_Resultado.Visible = False
        ElseIf Accion = 4 AndAlso Estatus = "N" Then
            Me.Size = New System.Drawing.Size(444, 431)
            Txt_Resultado.Visible = True
        End If
    End Sub

    Private Sub GenerarLabelFecha()
        If Accion = 1 Then
            Lbl_EstatusFecha.Text = "Ingrese los datos del Ticket: "
        End If

        If Estatus = "C" Then
            Lbl_EstatusFecha.Text = "Fecha Alta: " & FechaAlta.ToString("dd/MM/yyyy")
        ElseIf Estatus = "P" Or Estatus = "S" Or Estatus = "E" Then
            Lbl_EstatusFecha.Text = "Fecha de  Inicio: " & FechaProceso.ToString("dd/MM/yyyy")
        ElseIf Estatus = "R" Then
            Lbl_EstatusFecha.Text = "Fecha de Finalización: " & FechaRealizado.ToString("dd/MM/yyyy")
        ElseIf Estatus = "X" Then
            Lbl_EstatusFecha.Text = "TICKET CANCELADO"
        ElseIf Estatus = "N" Then
            Lbl_EstatusFecha.Text = "NO APLICA"
        End If

        Lbl_EstatusFecha.Visible = True
    End Sub

    Function EnviarCorreo() As Boolean
        Try
            'mreyes 28/Febrero/2012 04:45 p.m.
            Dim Correos As String = ""
            Dim Asunto As String = ""
            Dim Mensaje As String

            If Estatus = "S" Or Estatus = "P" Or Estatus = "E" Or Estatus = "X" Or Estatus = "N" Then
                Exit Function
            End If

            If Txt_Area.Text = "SIS" AndAlso Txt_Asignado.Text = "132" Then
                Correos = "marthar@zapateriastorreon.com"
            ElseIf Txt_Area.Text = "SIS" AndAlso Txt_Asignado.Text = "96" Then
                Correos = "miguelperez@zapateriastorreon.com"
            ElseIf Txt_Area.Text = "SIS" AndAlso Txt_Asignado.Text = "41" Then
                Correos = "luisantonio@zapateriastorreon.com"
            ElseIf Txt_Area.Text = "SIS" AndAlso Txt_Asignado.Text = "226" Then
                Correos = "raulr@zapateriastorreon.com"
            End If

            If Txt_Area.Text = "DIS" Then
                Correos = "edgarcarrillo@zapateriastorreon.com"
            ElseIf Txt_Area.Text = "REC" Then
                Correos = "paoladelatorre@zapateriastorreon.com"
            ElseIf Txt_Area.Text = "COM" Then
                Correos = "marydelrocio@zapateriastorreon.com"
            End If

            If Txt_Area.Text = "ADM" AndAlso Txt_Asignado.Text = "256" Then
                Correos = "javiersoto@zapateriastorreon.com"
            ElseIf Txt_Area.Text = "ADM" AndAlso Txt_Asignado.Text = "92" Then
                Correos = "ivonneorozco@zapateriastorreon.com"
            ElseIf Txt_Area.Text = "ADM" AndAlso Txt_Asignado.Text = "256" Then
                Correos = "javiersoto@zapateriastorreon.com"
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'If Txt_Area.Text = "SIS" AndAlso Txt_Asignado.Text = "132" Then
            '    Correos = "luis_bks@msn.com"
            'ElseIf Txt_Area.Text = "SIS" AndAlso Txt_Asignado.Text = "96" Then
            '    Correos = "luisantonio@zapateriastorreon.com"
            'ElseIf Txt_Area.Text = "SIS" AndAlso Txt_Asignado.Text = "41" Then
            '    Correos = "luisantonio@zapateriastorreon.com"
            'End If

            'If Txt_Area.Text = "DIS" Then
            '    Correos = "luisantonio@zapateriastorreon.com"
            'ElseIf Txt_Area.Text = "REC" Then
            '    Correos = "luisantonio@zapateriastorreon.com"
            'ElseIf Txt_Area.Text = "COM" Then
            '    Correos = "luisantonio@zapateriastorreon.com"
            'End If

            'If Txt_Area.Text = "ADM" AndAlso Txt_Asignado.Text = "104" Then
            '    Correos = "luisantonio@zapateriastorreon.com"
            'ElseIf Txt_Area.Text = "ADM" AndAlso Txt_Asignado.Text = "92" Then
            '    Correos = "luisantonio@zapateriastorreon.com"
            'ElseIf Txt_Area.Text = "ADM" AndAlso Txt_Asignado.Text = "104" Then
            '    Correos = "luisantonio@zapateriastorreon.com"
            'End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            If GLB_Sucursal <> "" Then
                If Accion = 1 Then
                    Asunto = "Sucursal " & GLB_Sucursal.ToString & " - Folio " & pub_RellenarIzquierda(Txt_Folio.Text, 4).ToString & " - Usuario " & GLB_Usuario.ToString
                ElseIf Accion = 2 Then
                    Asunto = "Modificación de Ticket - Sucursal " & GLB_Sucursal.ToString & " - Folio " & pub_RellenarIzquierda(Txt_Folio.Text, 4).ToString & " - Usuario " & GLB_Usuario.ToString
                End If
            Else
                If Accion = 1 Then
                    Asunto = "Administración" & GLB_Sucursal.ToString & " - Folio " & pub_RellenarIzquierda(Txt_Folio.Text, 4).ToString & " - Usuario " & GLB_Usuario.ToString
                    'Asunto = "Administración" & GLB_Sucursal.ToString & " - Folio " & pub_RellenarIzquierda(Txt_Folio.Text, 4).ToString & " - Reporta " & Txt_ReportaDescrip.Text
                ElseIf Accion = 2 Then
                    Asunto = "Modificación de Ticket - Administración " & GLB_Sucursal.ToString & " - Folio " & pub_RellenarIzquierda(Txt_Folio.Text, 4).ToString & " - Usuario " & GLB_Usuario.ToString
                End If
            End If
            
            Mensaje = Txt_Descripcion.Text

            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)
                objIO.pub_EnviarCorreo(GLB_SmtpClient, GLB_CorreoHelpDesk, GLB_PassCorreoHelpDesk, Correos, Asunto, Mensaje, "")
            End Using

            EnviarCorreo = True

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Editar, "Editar Ticket")
            ToolTip.SetToolTip(Btn_Nuevo, "Agregar una Ticket Nuevo")
            ToolTip.SetToolTip(Btn_Aceptar, "Guardar Ticket")
            ToolTip.SetToolTip(Btn_Cancelar, "Cancelar Ticket")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub usp_TraerEmpleadoRep()
        'Tony Gracia - 13/Octubre/2012 - 01:20 p.m.
        Dim objDataSet As Data.DataSet
        Using objEmpleado As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)
            Try
                If Txt_Reporta.Text.Length = 0 Then Exit Sub
                objDataSet = objEmpleado.usp_TraerNomEmpleado(Val(Txt_Reporta.Text), "", "", "", "", 0)
                If objDataSet.Tables(0).Rows.Count > 0 Then

                    Txt_ReportaDescrip.Text = objDataSet.Tables(0).Rows(0).Item("nomcompleto").ToString
                Else
                    Call CargarFormaConsultaEmpleadoR()
                    ''MessageBox.Show("El empleado no existe, ingrese un ID valido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub usp_TraerEmpleadoAsig()

        Dim objDataSet As Data.DataSet
        Using objEmpleado As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)
            Try
                If Txt_Asignado.Text.Length = 0 Then Exit Sub
                objDataSet = objEmpleado.usp_TraerNomEmpleado(Val(Txt_Asignado.Text), "", "", "", "", 4)
                If objDataSet.Tables(0).Rows.Count > 0 Then

                    Txt_DescripAsignado.Text = objDataSet.Tables(0).Rows(0).Item("nomcompleto").ToString
                Else
                    Call CargarFormaConsultaEmpleadoA()
                    ''MessageBox.Show("El empleado no existe, ingrese un ID valido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub HabilitaControles(ByVal blnEnabled As Boolean)
        Try
            Txt_Asignado.Enabled = blnEnabled
            Txt_Reporta.Enabled = blnEnabled
            Txt_Descripcion.Enabled = blnEnabled
            Cbo_TipoAct.Enabled = blnEnabled
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub usp_TraerNomDepto()
        'Tony Garcia - 23/Ocutbre/2012 - 5:25 p.m.
        Dim objDataSet As Data.DataSet
        Using objCatalogoActividades As New BCL.BCLCatalogoActividades(GLB_ConStringNomSis)
            objDataSet = objCatalogoActividades.usp_TraerNomDepto(Txt_Area.Text)
            If objDataSet.Tables(0).Rows.Count > 0 Then
                Txt_AreaDescrip.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                Txt_IdDepto.Text = objDataSet.Tables(0).Rows(0).Item("iddepto").ToString
            Else
                Dim myForm As New frmConsulta
                myForm.Tipo = "DE"
                myForm.ShowDialog()
                Txt_Area.Text = myForm.Campo1
                Txt_AreaDescrip.Text = myForm.Campo2
                Txt_IdDepto.Text = myForm.Campo
            End If
        End Using
    End Sub

    Private Sub AsignaIdRepAsigAdmin()
        If Txt_Reporta.Text = "9999" Then
            Txt_Reporta.Text = "IF"
        ElseIf Txt_Reporta.Text = "9998" Then
            Txt_Reporta.Text = "LF"
        ElseIf Txt_Reporta.Text = "9997" Then
            Txt_Reporta.Text = "IG"
        End If

        If Txt_Asignado.Text = "9999" Then
            Txt_Asignado.Text = "IF"
        ElseIf Txt_Asignado.Text = "9998" Then
            Txt_Asignado.Text = "LF"
        ElseIf Txt_Asignado.Text = "9997" Then
            Txt_Asignado.Text = "IG"
        End If
    End Sub

    Private Sub usp_TraerActividadEmp()
        'Tony Garcia - 10/Sept/2012 - 12:20 p.m.
        Dim objDataSet As Data.DataSet
        Using objCatalogoActividades As New BCL.BCLCatalogoActividades(GLB_ConStringNomSis)
            Try
                If Accion = 1 Then
                    Call HabilitaControles(True)
                    Exit Sub
                End If

                If IdActividad = 0 Then Exit Sub
                objDataSet = objCatalogoActividades.usp_TraerActividadEmp(IdActividad, FechaAlta, Estatus)
                If objDataSet.Tables(0).Rows.Count > 0 Then

                    Txt_Folio.Text = objDataSet.Tables(0).Rows(0).Item("idactividad").ToString
                    Txt_IdDepto.Text = objDataSet.Tables(0).Rows(0).Item("iddepto").ToString
                    Txt_Area.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    Txt_AreaDescrip.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                    DTI_FechaAct.Value = objDataSet.Tables(0).Rows(0).Item("fechaalta").ToString
                    Cbo_TipoAct.Text = objDataSet.Tables(0).Rows(0).Item("tipo").ToString
                    Txt_Reporta.Text = objDataSet.Tables(0).Rows(0).Item("reporta").ToString
                    Txt_ReportaDescrip.Text = objDataSet.Tables(0).Rows(0).Item("nombrer").ToString
                    Txt_Asignado.Text = objDataSet.Tables(0).Rows(0).Item("asignado").ToString
                    Txt_DescripAsignado.Text = objDataSet.Tables(0).Rows(0).Item("nombrea").ToString
                    Txt_Descripcion.Text = objDataSet.Tables(0).Rows(0).Item("descripcion").ToString
                    Txt_Resultado.Text = objDataSet.Tables(0).Rows(0).Item("resultado").ToString
                    Txt_Satisfaccion.Text = objDataSet.Tables(0).Rows(0).Item("satisfaccion").ToString

                    Call AsignaIdRepAsigAdmin()

                    If Accion = 2 Or Accion = 4 Then
                        Call HabilitaControles(True)
                    Else
                        Call HabilitaControles(False)
                    End If
                End If

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    
    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        ''Tony Garcia - 10/Sept/2012 - 11:00 a.m.
        Try
            'GLB_RefrescarPedido = False
            If Accion = 1 Then '''' registro nuevo
                If MsgBox("Esta Seguro de Guardar el Registro?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    If Inserta_Actividad() = True Then
                        GLB_RefrescarPedido = True
                        MessageBox.Show("El Ticket con el Folio '" + pub_RellenarIzquierda(Txt_Folio.Text, 4).ToString + "' se ha Guardado correctamente", "Agregando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Call EnviarCorreo()
                        Me.Close()
                        Me.Dispose()
                    Else
                        If blnValida = False Then Exit Sub
                        MessageBox.Show("Error al Guardar !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            ElseIf Accion = 2 Then '  actualización de registro
                If MsgBox("Esta Seguro de Actualizar el Registro?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    If Inserta_Actividad() = True Then
                        GLB_RefrescarPedido = True
                        MessageBox.Show("El Ticket con el Folio '" + pub_RellenarIzquierda(Txt_Folio.Text, 4).ToString + "' se Actualizó correctamente", "Actualizando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Call EnviarCorreo()
                        Me.Close()
                        Me.Dispose()
                    Else
                        If blnValida = False Then Exit Sub
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

    Private Sub Txt_Reporta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Reporta.LostFocus
        Try
            If Txt_Reporta.Text = "IF" Then
                Txt_ReportaDescrip.Text = "ING. FELIX B. GIACOMAN MOURRA"
            ElseIf Txt_Reporta.Text = "LF" Then
                Txt_ReportaDescrip.Text = "LIC. FELIX GIACOMAN"
            ElseIf Txt_Reporta.Text = "IG" Then
                Txt_ReportaDescrip.Text = "ING. JOSE LUIS GARCIA RAMIREZ"
            Else
                Call usp_TraerEmpleadoRep()
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Asignado_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Asignado.LostFocus
        Try
            If Txt_Asignado.Text = "IF" Then
                Txt_DescripAsignado.Text = "ING. FELIX B. GIACOMAN MOURRA"
            ElseIf Txt_Asignado.Text = "LF" Then
                Txt_DescripAsignado.Text = "LIC. FELIX GIACOMAN"
            ElseIf Txt_Asignado.Text = "IG" Then
                Txt_DescripAsignado.Text = "ING. JOSE LUIS GARCIA RAMIREZ"
            Else
                Call usp_TraerEmpleadoAsig()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Area_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Area.LostFocus
        Try
            Call usp_TraerNomDepto()

            If Txt_Area.Text = "SIS" Then
                Txt_Asignado.Text = "132"
                Txt_DescripAsignado.Text = "REYES SANCHEZ MARTHA JOSEFINA"
                Txt_Asignado.Enabled = False
                Txt_DescripAsignado.Enabled = False
            ElseIf Txt_Area.Text = "DIS" Then
                Txt_Asignado.Text = "280"
                Txt_DescripAsignado.Text = "CARRILLO MORENO EDGAR ADRIAN"
                Txt_Asignado.Enabled = False
                Txt_DescripAsignado.Enabled = False
            ElseIf Txt_Area.Text = "REC" Then
                Txt_Asignado.Text = "24"
                Txt_DescripAsignado.Text = "DE LA TORRE SANDOVAL DIANA PAOLA"
                Txt_Asignado.Enabled = False
                Txt_DescripAsignado.Enabled = False
            ElseIf Txt_Area.Text = "COM" Then
                Txt_Asignado.Text = "89"
                Txt_DescripAsignado.Text = "OLIVARES HERNANDEZ MARIA DEL ROCIO"
                Txt_Asignado.Enabled = False
                Txt_DescripAsignado.Enabled = False
            Else
                Txt_Asignado.Text = "256"
                Txt_DescripAsignado.Text = "SOTO DE LEON JAVIER"
                Txt_Asignado.Enabled = False
                Txt_DescripAsignado.Enabled = False
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub usp_TraerUltimoFolioAct()
        'Tony Garcia - 15/Octubre - 11:00 a.m.
        Dim objDataSet As Data.DataSet
        Using objActividadesEmp As New BCL.BCLCatalogoActividades(GLB_ConStringNomSis)
            Try
                objDataSet = objActividadesEmp.usp_TraerUltimoFolioAct()
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("ultimofolio").ToString.Trim = "" Then
                        UltimoFolio = 0
                    Else
                        UltimoFolio = objDataSet.Tables(0).Rows(0).Item("ultimofolio")
                    End If
                End If
            Catch ex As Exception
            End Try
        End Using
    End Sub

    Private Sub CargarFormaConsultaEmpleadoA()
        Dim myForm As New frmConsultaEmpleado
        Txt_DescripAsignado.Text = ""
        myForm.Estatus = ""
        myForm.ShowDialog()
        Txt_Asignado.Text = myForm.Campo
        Txt_DescripAsignado.Text = myForm.Campo1
        If Txt_Asignado.Text.Length = 0 Then
            Txt_Asignado.Focus()
        End If
    End Sub

    Private Sub CargarFormaConsultaEmpleadoR()
        Dim myForm As New frmConsultaEmpleado
        Txt_ReportaDescrip.Text = ""
        myForm.Estatus = ""
        myForm.ShowDialog()
        Txt_Reporta.Text = myForm.Campo
        Txt_ReportaDescrip.Text = myForm.Campo1
        If Txt_Reporta.Text.Length = 0 Then
            Txt_Reporta.Focus()
        End If
    End Sub

    Private Sub Btn_Nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Nuevo.Click
        Try
            Accion = 1
            Call Edicion()

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

            Call HabilitaControles(True)
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Function Inserta_Actividad() As Boolean
        'Tony Garcia 13/Octubre/2012 06:25 p.m.

        Using objCatalogoActividades As New BCL.BCLCatalogoActividades(GLB_ConStringNomSis)
            'Get a new Project DataSet
            Try
                objDataSet = objCatalogoActividades.Inserta_Actividad  'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow

                blnValida = ValidaCampos()
                If blnValida = True Then
                    If Accion = 1 Then
                        Call usp_TraerUltimoFolioAct()

                        objDataRow.Item("idactividad") = UltimoFolio + 1
                        objDataRow.Item("iddepto") = Val(Txt_IdDepto.Text)

                        If Txt_Reporta.Text = "IF" Then
                            objDataRow.Item("reporta") = 9999
                        ElseIf Txt_Reporta.Text = "LF" Then
                            objDataRow.Item("reporta") = 9998
                        ElseIf Txt_Reporta.Text = "IG" Then
                            objDataRow.Item("reporta") = 9997
                        Else
                            objDataRow.Item("reporta") = Val(Txt_Reporta.Text)
                        End If

                        If Txt_Asignado.Text = "IF" Then
                            objDataRow.Item("asignado") = 9999
                        ElseIf Txt_Asignado.Text = "LF" Then
                            objDataRow.Item("asignado") = 9998
                        ElseIf Txt_Asignado.Text = "IG" Then
                            objDataRow.Item("asignado") = 9997
                        Else
                            objDataRow.Item("asignado") = Val(Txt_Asignado.Text)
                        End If

                        objDataRow.Item("estatus") = "C"
                        objDataRow.Item("fechaalta") = DTI_FechaAct.Value
                        objDataRow.Item("fechaproc") = "1900-01-01"
                        objDataRow.Item("fechafin") = "1900-01-01"


                    ElseIf Accion = 2 Then
                        objDataRow.Item("idactividad") = Val(Txt_Folio.Text)
                        objDataRow.Item("iddepto") = Val(Txt_IdDepto.Text)

                        If Txt_Reporta.Text = "IF" Then
                            objDataRow.Item("reporta") = 9999
                        ElseIf Txt_Reporta.Text = "LF" Then
                            objDataRow.Item("reporta") = 9998
                        ElseIf Txt_Reporta.Text = "IG" Then
                            objDataRow.Item("reporta") = 9997
                        Else
                            objDataRow.Item("reporta") = Val(Txt_Reporta.Text)
                        End If

                        If Txt_Asignado.Text = "IF" Then
                            objDataRow.Item("asignado") = 9999
                        ElseIf Txt_Asignado.Text = "LF" Then
                            objDataRow.Item("asignado") = 9998
                        ElseIf Txt_Asignado.Text = "IG" Then
                            objDataRow.Item("asignado") = 9997
                        Else
                            objDataRow.Item("asignado") = Val(Txt_Asignado.Text)
                        End If
                        objDataRow.Item("fechaalta") = FechaAlta
                        objDataRow.Item("fechaproc") = FechaProceso
                        objDataRow.Item("fechafin") = FechaRealizado
                        objDataRow.Item("estatus") = Estatus
                    End If


                    objDataRow.Item("usuario") = GLB_Usuario
                    objDataRow.Item("usumodif") = GLB_Usuario
                    objDataRow.Item("fummodif") = DateTime.Now

                    'Add the DataRow to the DataSet
                    objDataSet.Tables(0).Rows.Add(objDataRow)

                    'Add the Project
                    If Not objCatalogoActividades.usp_Captura_Actividad(Accion, objDataSet) Then
                        'Throw New Exception("Falló Inserción de Proveedor")
                    Else
                        Inserta_Actividad = True
                        Call Inserta_ActividadDet()
                    End If
                End If
                

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Private Function Inserta_ActividadDet() As Boolean
        'Tony Garcia 13/Octubre/2012 06:25 p.m.

        Using objCatalogoActividades As New BCL.BCLCatalogoActividades(GLB_ConStringNomSis)
            'Get a new Project DataSet
            Try
                objDataSet = objCatalogoActividades.Inserta_ActividadDet  'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow

                If Accion = 1 Then
                  
                    objDataRow.Item("idactividad") = UltimoFolio + 1
                    objDataRow.Item("tipo") = Cbo_TipoAct.Text.Trim
                    If Txt_Reporta.Text = "IF" Then
                        objDataRow.Item("reporta") = Txt_ReportaDescrip.Text
                    ElseIf Txt_Reporta.Text = "LF" Then
                        objDataRow.Item("reporta") = Txt_ReportaDescrip.Text
                    ElseIf Txt_Reporta.Text = "IG" Then
                        objDataRow.Item("reporta") = Txt_ReportaDescrip.Text
                    Else
                        objDataRow.Item("reporta") = Txt_ReportaDescrip.Text
                    End If

                    If Txt_Asignado.Text = "IF" Then
                        objDataRow.Item("asignado") = Txt_DescripAsignado.Text
                    ElseIf Txt_Asignado.Text = "LF" Then
                        objDataRow.Item("asignado") = Txt_DescripAsignado.Text
                    ElseIf Txt_Asignado.Text = "IG" Then
                        objDataRow.Item("asignado") = Txt_DescripAsignado.Text
                    Else
                        objDataRow.Item("asignado") = Txt_DescripAsignado.Text
                    End If
                    objDataRow.Item("descripcion") = Txt_Descripcion.Text.Trim
                    objDataRow.Item("resultado") = " "
                    objDataRow.Item("satisfaccion") = " "
                    objDataRow.Item("estatus") = "C"

                ElseIf Accion = 2 Then
                 
                    objDataRow.Item("idactividad") = Val(Txt_Folio.Text)
                    objDataRow.Item("tipo") = Cbo_TipoAct.Text.Trim
                    If Txt_Reporta.Text = "IF" Then
                        objDataRow.Item("reporta") = Txt_ReportaDescrip.Text
                    ElseIf Txt_Reporta.Text = "LF" Then
                        objDataRow.Item("reporta") = Txt_ReportaDescrip.Text
                    ElseIf Txt_Reporta.Text = "IG" Then
                        objDataRow.Item("reporta") = Txt_ReportaDescrip.Text
                    Else
                        objDataRow.Item("reporta") = Txt_ReportaDescrip.Text
                    End If

                    If Txt_Asignado.Text = "IF" Then
                        objDataRow.Item("asignado") = Txt_DescripAsignado.Text
                    ElseIf Txt_Asignado.Text = "LF" Then
                        objDataRow.Item("asignado") = Txt_DescripAsignado.Text
                    ElseIf Txt_Asignado.Text = "IG" Then
                        objDataRow.Item("asignado") = Txt_DescripAsignado.Text
                    Else
                        objDataRow.Item("asignado") = Txt_DescripAsignado.Text
                    End If
                    objDataRow.Item("descripcion") = Txt_Descripcion.Text.Trim
                    objDataRow.Item("resultado") = Txt_Resultado.Text.Trim
                    objDataRow.Item("satisfaccion") = Txt_Satisfaccion.Text.Trim
                    objDataRow.Item("estatus") = Estatus
                End If


                objDataRow.Item("usuario") = GLB_Usuario
                objDataRow.Item("usumodif") = GLB_Usuario
                objDataRow.Item("fummodif") = DateTime.Now

                objDataSet.Tables(0).Rows.Add(objDataRow)

                If Not objCatalogoActividades.usp_Captura_ActividadDet(Accion, objDataSet) Then

                Else
                    Inserta_ActividadDet = True
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
                    Btn_Nuevo.Enabled = True
                    Btn_Editar.Enabled = True
                    Pnl_Grid.Enabled = False

                    Call HabilitaControles(False)

                Case 1
                    Btn_Aceptar.Enabled = True
                    'Btn_Cancelar.Enabled = True
                    Btn_Nuevo.Enabled = False
                    Btn_Editar.Enabled = False
                    DTI_FechaAct.Enabled = False
                    Txt_Resultado.Visible = False

                    Cbo_TipoAct.Focus()
                    Application.DoEvents()

                    Me.Size = New System.Drawing.Size(444, 347)

                Case 2
                    Btn_Aceptar.Enabled = True
                    'Btn_Cancelar.Enabled = True
                    Btn_Nuevo.Enabled = False
                    Btn_Editar.Enabled = False
                    DTI_FechaAct.Enabled = False
                    If GLB_Sucursal <> "" Then  'Para sucursales
                        If Estatus = "R" Or Estatus = "S" Or Estatus = "P" Or Estatus = "E" Then
                            Txt_Reporta.Enabled = False
                            Txt_Asignado.Enabled = False
                            Cbo_TipoAct.Enabled = False
                            DTI_FechaAct.Enabled = False
                            Txt_Area.Enabled = False
                            Txt_Descripcion.Enabled = False
                            Txt_Resultado.Enabled = False
                            If Estatus = "R" Then
                                Txt_Satisfaccion.Select()
                            Else
                                Txt_Resultado.Select()
                            End If
                        End If
                    Else 'Para area administrativa
                        If Estatus = "R" Then
                            Txt_Reporta.Enabled = False
                            Txt_Asignado.Enabled = False
                        End If
                    End If

                    Cbo_TipoAct.Focus()
            End Select
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Asignado_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Asignado.KeyPress
        'Call pub_SoloNumeros(sender, e)
    End Sub

    Private Sub Txt_Descripcion_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Descripcion.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Try
            If Accion = 1 Or Accion = 2 Then
                If MessageBox.Show("Esta seguro de Cancelar el Registro?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
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

    Private Sub frmPpalCatalogoActividades_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Txt_Resultado_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Resultado.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Function ValidaCampos() As Boolean
        If Cbo_TipoAct.Text = "SELECCIONAR..." Then
            MessageBox.Show("Debe Seleccionar un Tipo De Actividad.", "ATENCION!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Cbo_TipoAct.Focus()
            Exit Function
        End If

        If Txt_Reporta.Text = "" Then
            MessageBox.Show("Debe ingresar quién Reporta la Solicitud.", "ATENCION!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Txt_Reporta.Focus()
            Exit Function
        End If

        If Txt_Asignado.Text = "" Then
            MessageBox.Show("Debe ingresar un empleado Asignado a la Solicitud.", "ATENCION!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Txt_Asignado.Focus()
            Exit Function
        End If

        If Txt_Descripcion.Text = "" Then
            MessageBox.Show("Debe ingresar una Descripción de la solicitud.", "ATENCION!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Txt_Descripcion.Focus()
            Exit Function
        End If

        If Txt_Area.Text = "" Then
            MessageBox.Show("Debe ingresar el Área a donde se reporta la Solicitud.", "ATENCION!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Txt_Descripcion.Focus()
            Exit Function
        End If

        ValidaCampos = True
    End Function

    Private Sub Txt_Area_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Area.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Satisfaccion_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Satisfaccion.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class