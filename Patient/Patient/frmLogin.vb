Imports System.Drawing.Printing
Imports System.Deployment.Application
Imports System.Net


Public Class frmLogin
    Private objDataSet As Data.DataSet
    Private objUserDataSet As DataSet
    Private veces As Integer = 0
    Private Const NumeroIntentos As Integer = 3

    Private sw_ActualizaSirco As Boolean = False

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        End
        'Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        'mreyes 22/Febrero/2012 12:56 p.m.
        Try
            sw_ActualizaSirco = False
            Call InstallUpdateSyncWithInfo()

            Dim LocalHostName As String = Dns.GetHostName
            Dim LocalIP As IPHostEntry = Dns.GetHostEntry(LocalHostName)
            Dim SW_REGISTRO As Boolean = False
            GLB_Ip = LocalHostName
            If Txt_Password.Text.Length = 0 Then MsgBox("Usuario no registrado. Intente Nuevamente", MsgBoxStyle.Critical, "Validación de usuario") : Exit Sub : Txt_Password.Focus()
            If Txt_Password.Text = "REDADM" Then
                MsgBox("Usuario no registrado. Intente Nuevamente", MsgBoxStyle.Critical, "Validación de usuario")

                Txt_Password.Focus()
                Exit Sub
            End If

            If usp_TraerUsuario() = True Then
                DialogResult = DialogResult.OK
            Else
                'Me.Close()
                MsgBox("Usuario no registrado. Intente Nuevamente", MsgBoxStyle.Critical, "Validación de usuario")
                Txt_Password.Focus()
            End If

            If sw_ActualizaSirco = True Then

                Using objCaptura As New BCL.BCLTipoVivienda(GLB_ConStringSircoControlSQL)
                    SW_REGISTRO = objCaptura.usp_CapturaAccesosSIRCO(1, GLB_Idempleado, GLB_Usuario, GLB_Ip)
                End Using
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Function usp_TraerUsuario() As Boolean
        'mreyes 22/Febrero/2012 12:48 p.m.
        ''Using objPersis As New BCL.BCLPersis(Glb_ConStringPerSis)

        ''    Try
        ''        'Get the specific project selected in the ListView control
        ''        objDataSet = objPersis.usp_TraerUsuario(Txt_Password.Text)
        ''        If objDataSet.Tables(0).Rows.Count > 0 Then
        ''            GLB_Usuario = (objDataSet.Tables(0).Rows(0).Item("usuario").ToString)
        ''            '' cambiar cuando se tenga el campo 
        ''            GLB_NomUsuario = objDataSet.Tables(0).Rows(0).Item("nombre").ToString
        ''            usp_TraerUsuario = True
        ''        Else
        ''            usp_TraerUsuario = False
        ''            '''' buscar el de nómina
        ''            If usp_TraerUsuarioNomina() = False Then
        ''                usp_TraerUsuario = False
        ''            Else
        ''                usp_TraerUsuario = True
        ''            End If
        ''        End If

        ''    Catch ExceptionErr As Exception
        ''        MessageBox.Show(ExceptionErr.Message.ToString)
        ''    End Try
        ''End Using


        Using objPersis As New BCL.BCLPersis(GLB_ConStringPerSis)

            Try
                'Get the specific project selected in the ListView control

                If usp_TraerUsuarioNomina() = False Then
                    usp_TraerUsuario = False
                    If (Txt_Password.Text = "FG0881" Or Txt_Password.Text = "BLFB32" Or Txt_Password.Text = "20140514" Or Txt_Password.Text = "MAGIC3" Or Txt_Password.Text = "335700") Then
                        GLB_CveSucursal = ""
                        objDataSet = objPersis.usp_TraerUsuario(Txt_Password.Text)
                        If objDataSet.Tables(0).Rows.Count > 0 Then
                            GLB_Usuario = (objDataSet.Tables(0).Rows(0).Item("usuario").ToString)
                            '' cambiar cuando se tenga el campo 
                            GLB_NomUsuario = objDataSet.Tables(0).Rows(0).Item("nombre").ToString
                            usp_TraerUsuario = True
                        End If
                    End If
                Else
                    usp_TraerUsuario = True
                    If Txt_Password.Text = "20140514" Then
                        GLB_AccesoEmpleado = False
                        GLB_CveSucursal = ""
                        GLB_Sw_Costos = True
                        GLB_Sw_Venta = True
                    End If

                    'If Txt_Password = 'MAO08A'

                End If




                ' TRAER SI ESTA ABIERTO
                'Dim LocalHostName As String = Dns.GetHostName
                'Dim LocalIP As IPHostEntry = Dns.GetHostEntry(LocalHostName)
                Dim SW_REGISTRO As Boolean = False
                'GLB_Ip = LocalIP.AddressList(6).ToString


                Using objCaptura As New BCL.BCLTipoVivienda(GLB_ConStringSircoControlSQL)
                    objDataSet = objCaptura.usp_TraerAccesosSIRCO(3, GLB_Idempleado, GLB_Usuario, GLB_Ip)
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        ''' ESTA ABIERTO EN OTRO LADO

                        MsgBox("Tiene una sesión activa del SirCo en la dirección '" & objDataSet.Tables(0).Rows(0).Item("ip").ToString & "' desde las '" & objDataSet.Tables(0).Rows(0).Item("inicio").ToString & "' NECESITA CERRARLA PARA PODER ACCEDER.", MsgBoxStyle.Critical, "ERROR DE ACCESO")
                        End

                    Else
                        SW_REGISTRO = objCaptura.usp_CapturaAccesosSIRCO(1, GLB_Idempleado, GLB_Usuario, GLB_Ip)
                    End If

                End Using




            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using

    End Function



    Private Function usp_TraerUsuarioNomina() As Boolean
        'mreyes 19/Septiembre/2012 09:38 a.m.
        Using objPersis As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)

            Try
                'Get the specific project selected in the ListView control
                objDataSet = objPersis.usp_TraerUsuarioNomina(Txt_Password.Text)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    GLB_Usuario = Mid((objDataSet.Tables(0).Rows(0).Item("usuario").ToString), 1, 8)
                    '' cambiar cuando se tenga el campo 
                    GLB_NomUsuario = objDataSet.Tables(0).Rows(0).Item("nomcompleto").ToString
                    GLB_Sucursal = objDataSet.Tables(0).Rows(0).Item("descripsucursal").ToString
                    GLB_CveSucursal = objDataSet.Tables(0).Rows(0).Item("sucursal").ToString

                    'If GLB_CveSucursal = "99" Then GLB_CveSucursal = "15"

                    GLB_IdDeptoEmpleado = objDataSet.Tables(0).Rows(0).Item("iddepto").ToString
                    GLB_Idempleado = objDataSet.Tables(0).Rows(0).Item("idempleado").ToString
                    If objDataSet.Tables(0).Rows(0).Item("costos").ToString = 1 Then
                        GLB_Sw_Costos = True
                    Else
                        GLB_Sw_Costos = False
                    End If

                    If objDataSet.Tables(0).Rows(0).Item("ventas").ToString = 1 Then
                        GLB_Sw_Venta = True
                    Else
                        GLB_Sw_Venta = False
                    End If

                    'mientras
                    If GLB_Idempleado = 0 Then GLB_Idempleado = 132
                    usp_TraerUsuarioNomina = True
                    GLB_AccesoEmpleado = True

                    If (Mid(GLB_CveSucursal, 1, 1) <> "0" And Mid(GLB_CveSucursal, 1, 1) <> "9" And Mid(GLB_CveSucursal, 1, 1) <> "1") Or GLB_CveSucursal = "00" Then GLB_CveSucursal = "" : GLB_AccesoEmpleado = False

                    '' el lic pidio que se les quitara el 23 de abril 2021
                    '''If GLB_Idempleado = 1505 Or GLB_Idempleado = 1032 Or GLB_IdDeptoEmpleado = 4 Then
                    '''    GLB_CveSucursal = ""
                    '''End If
                    GLB_CorreoEmpleado = objDataSet.Tables(0).Rows(0).Item("email").ToString
                    GLB_PassCorreoEmpleado = objDataSet.Tables(0).Rows(0).Item("passemail").ToString
                        GLB_IdDeptoEmpleado = Val(objDataSet.Tables(0).Rows(0).Item("iddepto"))
                        GLB_IdPuestoEmpleado = Val(objDataSet.Tables(0).Rows(0).Item("idPUESTO"))



                    ' GLB_ImpresoraMovs = pub_TraerParame_Det("MOVS" & GLB_CveSucursal)
                    'If GLB_ImpresoraMovs = "" Then
                    '    GLB_ImpresoraMovs = pub_TraerParame_Det("MOVSAD")
                    '    GLB_ImpresoraMovs = GLB_ImpresoraPredeterminada
                    'End If

                    '   If GLB_Ip = "192.168.1.47" Then
                    '   GLB_ImpresoraMovs = "\\10.10.1.49\movs"
                    ' End If

                    If GLB_ImpresoraMovs = "" Then
                        For Each Impresora As String In PrinterSettings.InstalledPrinters
                            'En la variabla Impresora se almacenará el nombre de la impresora
                            If InStr(Impresora, "movs") > 0 Then
                                GLB_ImpresoraMovs = Impresora
                                Exit For
                            End If
                        Next
                    End If


                    If GLB_ImpresoraRELACION = "" Then
                        For Each Impresora As String In PrinterSettings.InstalledPrinters
                            'En la variabla Impresora se almacenará el nombre de la impresora
                            If InStr(Impresora, "hpm521") > 0 Then
                                GLB_ImpresoraRELACION = Impresora
                                Exit For
                            End If
                        Next
                    End If

                    If GLB_ImpresoraRELACION = "" Then
                        GLB_ImpresoraRELACION = GLB_ImpresoraMovs
                    End If

                Else
                        usp_TraerUsuarioNomina = False
                    '''' buscar el de nómina

                End If

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using


    End Function
    Public Sub InstallUpdateSyncWithInfo()
        Dim sw_registro As Boolean = False
        Dim info As UpdateCheckInfo = Nothing

        If (ApplicationDeployment.IsNetworkDeployed) Then

            Dim AD As ApplicationDeployment = ApplicationDeployment.CurrentDeployment

            Try
                info = AD.CheckForDetailedUpdate()
            Catch dde As DeploymentDownloadException

            Catch ioe As InvalidOperationException

            End Try

            If (info.UpdateAvailable) Then

                Try
                    sw_ActualizaSirco = True

                    'cerrar conexion
                    'Using objCaptura As New BCL.BCLTipoVivienda(GLB_ConStringSircoControlSQL)
                    '    sw_registro = objCaptura.usp_CapturaAccesosSIRCO(2, GLB_Idempleado, GLB_Usuario, GLB_Ip)
                    'End Using

                    AD.Update()




                    Application.Restart()
                Catch dde As DeploymentDownloadException

                End Try

            End If

        End If
    End Sub
    Private Sub LoginForm1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load



        If My.Application.IsNetworkDeployed Then
            Me.Text = "SIRCO  Version " & My.Application.Deployment.CurrentVersion.ToString()
        Else
            Me.Text = "SIRCO  Version " & Application.ProductVersion
        End If


        If CheckDatabaseConnection() = False Then
            Me.Close()
        End If

    End Sub

    Private Sub Txt_Password_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Password.GotFocus
        Txt_Password.SelectAll()
    End Sub

    Private Sub Txt_Password_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Password.LostFocus

    End Sub


    Private Sub Txt_Password_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Password.TextChanged

    End Sub


End Class
