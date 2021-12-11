Imports System.Net
Public Class BitacoraMain
#Region " Variable Declarations "
    'Private variables and objects


    Private intIndex As Integer

    Private strActiveScreen As String = "Projects"
    Private strAppTitle As String

    Private imgCurrentNavImage As Image

    Private Const ImageSelected As Integer = 0
    Private Const ImageUnselected As Integer = 1
    Private Const ImageHighlighted As Integer = 2

    Private Test As String
#End Region
#Region " Navigation Procedures "
    Private Sub DockPanel(ByRef objPanel As Panel)
        'Set the Dock property to Fill
        '(this will cause the location to change to 0,0)
        objPanel.Dock = DockStyle.Fill
        'Set the navigation panel information
        'Select Case objPanel.Name
        '    Case "pnlPatients"
        '        strActiveScreen = "Patients"
        '        lblCurrentScreen.Text = "Empleados"
        '        lblAllScreens.Text = "Todos " & "Empleados"
        '        imgScreen.Image = imgProjects.Image
        '        lblScreen.Text = "Empleados"
        '    Case "pnlClinic"
        '        strActiveScreen = "Clinic"
        '        lblCurrentScreen.Text = "Clinic"
        '        lblAllScreens.Text = "All " & "Clinic"
        '        'imgScreen.Image = imgClinic.Image
        '        lblScreen.Text = "Clinic"
        '    Case "pnlUsers"
        '        strActiveScreen = "Users"
        '        lblCurrentScreen.Text = "Usuarios"
        '        lblAllScreens.Text = "Todos " & "Usuarios"
        '        imgScreen.Image = imgUsers.Image
        '        lblScreen.Text = "Usuarios"
        'End Select
    End Sub

    Private Sub UnDockPanel(ByRef objPanel As Panel, _
        ByRef objNavControl As Control)

        'Undock the Panel
        objPanel.Dock = DockStyle.None
        'Move it out of the way
        objPanel.Location = New Point(5000, 5000)
        'Set the image to be unselected
        objNavControl.BackgroundImage = imlNavigation.Images(ImageUnselected)
    End Sub



    Private Sub NavigationPanel_MouseEnter(ByVal sender As Object, _
        ByVal e As System.EventArgs)

        imgCurrentNavImage = sender.backgroundimage
        sender.backgroundimage = imlNavigation.Images(ImageHighlighted)
        sender.Cursor = Cursors.Hand
    End Sub

    Private Sub NavigationPanel_MouseLeave(ByVal sender As Object, _
        ByVal e As System.EventArgs)

        sender.backgroundimage = imgCurrentNavImage
        sender.Cursor = Cursors.Default
    End Sub

    Private Sub NavigationPanel_MouseUp(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.MouseEventArgs)

        imgCurrentNavImage = imlNavigation.Images(ImageSelected)
        'Call Navigate(sender.name)
    End Sub

    Private Sub NavigationChildControl_MouseEnter( _
        ByVal sender As Object, ByVal e As System.EventArgs)

        NavigationPanel_MouseEnter(sender.Parent, e)
    End Sub

    Private Sub NavigationChildControl_MouseLeave( _
        ByVal sender As Object, ByVal e As System.EventArgs)

        NavigationPanel_MouseLeave(sender.Parent, e)
    End Sub

    Private Sub NavigationChildControl_MouseUp( _
        ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        NavigationPanel_MouseUp(sender.parent, e)
    End Sub

    Private Sub pnlGrabbar_Resize(ByVal sender As Object, _
        ByVal e As System.EventArgs)


    End Sub
#End Region

#Region " Load Procedures "

    Private Sub BitacoraMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

    End Sub

    Private Sub ZapateriaMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If MessageBox.Show("Estas seguro de salir ?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            usp_LiberarAccesoSIRCO()
            Me.Dispose()
            Me.Close()
            End
        Else
            usp_LiberarAccesoSIRCO()
            Me.Dispose()
            Me.Close()
            End
        End If
    End Sub





#End Region

    Private Sub TextShow()

    End Sub
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        If MessageBox.Show("Estas seguro de salir ?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            usp_LiberarAccesoSIRCO()
            Me.Dispose()
            Me.Close()
            End
        End If

    End Sub

    Private Function usp_LiberarAccesoSIRCO() As Boolean
        'mreyes 20/Febrero/2019 06:43 p.m.

        Try
            Using objCaptura As New BCL.BCLTipoVivienda(GLB_ConStringSircoControlSQL)


                usp_LiberarAccesoSIRCO = objCaptura.usp_CapturaAccesosSIRCO(2, GLB_Idempleado, GLB_Usuario, GLB_Ip)



            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Private Sub ChangeLoginToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim facceso As New frmPermisoProceso
        If facceso.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            facceso.Close()
            facceso.Dispose()
            '  Me.ShowDialog()
        End If


    End Sub






    Public Sub New()


        InitializeComponent()



    End Sub



    Private Sub BitacoraMain_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            If MessageBox.Show("Estas seguro de salir ?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                usp_LiberarAccesoSIRCO()
                Me.Dispose()
                Me.Close()
                End
            End If
        End If
    End Sub



    ''Private Sub InstallUpdateSyncWithInfo()
    ''    Dim info As UpdateCheckInfo = Nothing

    ''    If (ApplicationDeployment.IsNetworkDeployed) Then
    ''        Dim AD As ApplicationDeployment = ApplicationDeployment.CurrentDeployment

    ''        Try
    ''            info = AD.CheckForDetailedUpdate()
    ''        Catch dde As DeploymentDownloadException
    ''            MessageBox.Show("The new version of the application cannot be downloaded at this time. " + ControlChars.Lf & ControlChars.Lf & "Please check your network connection, or try again later. Error: " + dde.Message)
    ''            Return
    ''        Catch ioe As InvalidOperationException
    ''            MessageBox.Show("This application cannot be updated. It is likely not a ClickOnce application. Error: " & ioe.Message)
    ''            Return
    ''        End Try

    ''        If (info.UpdateAvailable) Then
    ''            Dim doUpdate As Boolean = True

    ''            If (Not info.IsUpdateRequired) Then
    ''                Dim dr As DialogResult = MessageBox.Show("An update is available. Would you like to update the application now?", "Update Available", MessageBoxButtons.OKCancel)
    ''                If (Not System.Windows.Forms.DialogResult.OK = dr) Then
    ''                    doUpdate = False
    ''                End If
    ''            Else
    ''                ' Display a message that the app MUST reboot. Display the minimum required version.
    ''                MessageBox.Show("This application has detected a mandatory update from your current " &
    ''                    "version to version " & info.MinimumRequiredVersion.ToString() &
    ''                    ". The application will now install the update and restart.",
    ''                    "Update Available", MessageBoxButtons.OK,
    ''                    MessageBoxIcon.Information)
    ''            End If

    ''            If (doUpdate) Then
    ''                Try
    ''                    AD.Update()
    ''                    MessageBox.Show("The application has been upgraded, and will now restart.")
    ''                    Application.Restart()
    ''                Catch dde As DeploymentDownloadException
    ''                    MessageBox.Show("Cannot install the latest version of the application. " & ControlChars.Lf & ControlChars.Lf & "Please check your network connection, or try again later.")
    ''                    Return
    ''                End Try
    ''            End If
    ''        End If
    ''    End If
    ''End Sub
    Private Sub BitacoraMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Temporizador.Start()


            'mreyes 23/Marzo/2012 10:24 a.m.
            Dim FechaPc As Date = "1900-01-01"
            '' Cargar Parámetros ..
            GLB_FechaHoy = pub_TraerFechaHoy()

            If GLB_FechaHoy >= "2019-04-11" Then
                AparadorToolStripMenuItem.Visible = False
                ToolStripMenuItem34.Visible = False
                EtiquetasAparadorToolStripMenuItem.Visible = False
                AparadorRealToolStripMenuItem.Visible = False
                MatchEstructuraVsAToolStripMenuItem.Visible = False
            End If
            FechaPc = Date.Today
            If GLB_FechaHoy = "1900-01-01" Then
                MsgBox("Error al validar Fecha del Servidor. Reporte a Sistemas.", MsgBoxStyle.Critical, "Aviso")
                End
            End If
            If FechaPc <> GLB_FechaHoy Then
                MsgBox("La fecha de su PC no coincide con la fecha del servidor, no puede acceder al sistema.", MsgBoxStyle.Critical, "Aviso")
                End
            End If
            Call CargarParametros()
            'If GLB_AccesoEmpleado = False Then

            ' End If
            TssUsuario.Text = GLB_Usuario
            TssFecha.Text = Format(Now, "Short Date")
            TssSucursal.Text = GLB_CveSucursal & "-" & GLB_Sucursal

            If My.Application.IsNetworkDeployed Then
                Me.Text = "SIRCO  Version " & My.Application.Deployment.CurrentVersion.ToString()
            Else
                Me.Text = "SIRCO  Version " & Application.ProductVersion
            End If

            '' ''If pub_TienePermiso("BITACORA", False) = False Then Exit Sub
            '' ''Dim myForm As New frmPpalBitacora

            '' ''myForm.MdiParent = Me
            '' ''myForm.WindowState = FormWindowState.Maximized
            '' ''myForm.Show()
            '' ''myForm.Refresh()

            If GLB_Usuario = "FELIXJ" Or GLB_Usuario = "LORIS" Then
                '' ''If pub_TienePermiso("RESURTI") = False Then Exit Sub
                '' ''Dim myForm As New frmPpalResurtidoAut


                '' ''myForm.Opcion = 4
                '' ''myForm.MdiParent = Me
                '' ''myForm.WindowState = FormWindowState.Maximized
                '' ''myForm.Show()
                '' ''myForm.Refresh()

                'If pub_TienePermiso("LIQAUT") = False Then Exit Sub
                'Dim myForm As New frmPpalLiqAutomatica

                'myForm.MdiParent = Me
                'myForm.WindowState = FormWindowState.Maximized
                'myForm.Opcion = 1
                'myForm.OpcionSP = 1
                'myForm.Show()
                'myForm.Refresh()
            End If

            If GLB_IdPuestoEmpleado = 15 Or GLB_IdPuestoEmpleado = 50 Then

            End If


            If GLB_IdDeptoEmpleado = 8 And GLB_IdPuestoEmpleado = 15 Then
                Dim myForm As New frmPpalPedidoNuevo
                myForm.MdiParent = Me
                myForm.WindowState = FormWindowState.Maximized
                myForm.Sw_PedidoNuevo = False
                myForm.Show()
                myForm.Refresh()
            End If

            If GLB_IdPuestoEmpleado = 52 Then
                If pub_TienePermiso("FACTURAS") = False Then Exit Sub
                Dim myForm As New frmPpalFacturas

                myForm.MdiParent = Me
                myForm.WindowState = FormWindowState.Maximized
                myForm.Sw_FacturaNueva = False
                myForm.blnInicioAdmon = True
                myForm.Show()
                myForm.Refresh()
            End If



            If GLB_AccesoEmpleado = True And GLB_Idempleado <> 0 And GLB_CveSucursal.Length > 0 Then

                If GLB_IdPuestoEmpleado <> 8 Then
                    If GLB_CveSucursal = "01" Or GLB_CveSucursal = "02" Or GLB_CveSucursal = "06" Or GLB_CveSucursal = "08" Then

                        Dim myForm As New frmPpalTrasPendRecibo

                        myForm.MdiParent = Me
                        myForm.WindowState = FormWindowState.Maximized
                        myForm.Opcion = 2
                        myForm.OpcionSP = 3
                        myForm.Show()
                        myForm.Refresh()



                        'Dim myForm As New frmPpalTrasPendRecibo

                        'myForm.MdiParent = Me
                        'myForm.WindowState = FormWindowState.Maximized
                        'myForm.Opcion = 1
                        'myForm.OpcionSP = 3
                        'myForm.Show()
                        'myForm.Refresh()



                        'If pub_TienePermiso("TRAPEN") = False Then Exit Sub
                        'Dim myForm As New frmPpaPendientesRealizar

                        'myForm.MdiParent = Me
                        'myForm.WindowState = FormWindowState.Maximized
                        'myForm.Opcion = 1
                        'myForm.OpcionSP = 1
                        'myForm.Show()
                        'myForm.Refresh()
                    End If
                End If

            End If
            If GLB_IdPuestoEmpleado = 8 Then
                Dim myForm As New frmPpalEtiquetasAparador

                myForm.MdiParent = Me
                myForm.WindowState = FormWindowState.Maximized

                myForm.Show()
                myForm.Refresh()
            End If

            If GLB_IdPuestoEmpleado = 18 Or GLB_Idempleado = 132 Then
                Dim myForm As New frmPpalBitProcesos

                myForm.MdiParent = Me
                myForm.Opcion = 1
                myForm.WindowState = FormWindowState.Maximized
                myForm.Show()
                myForm.Refresh()
            End If

            'If GLB_IdDeptoEmpleado = 5 And (GLB_IdDeptoEmpleado = 32 Or GLB_IdDeptoEmpleado = 33) Then
            '    Call CajaCredito()
            'End If

            If GLB_IdDeptoEmpleado = 5 And GLB_IdPuestoEmpleado = 26 Then
                If pub_TienePermiso("REPGESTO") = False Then Exit Sub
                Dim myForm As New frmPpalGestoria

                myForm.MdiParent = Me
                myForm.WindowState = FormWindowState.Maximized

                myForm.Show()
                myForm.Refresh()
            End If

            If GLB_IdDeptoEmpleado = 5 And (GLB_IdPuestoEmpleado = 32 Or GLB_IdPuestoEmpleado = 33) Then
                If pub_TienePermiso("CALLCEN") = False Then Exit Sub
                Dim myForm As New frmPpalCallCenter

                myForm.MdiParent = Me
                myForm.WindowState = FormWindowState.Maximized

                myForm.Show()
                myForm.Refresh()
            End If

            ' Me.BackgroundImage = Image.FromFile("\\10.10.1.1\Sistemas .Net\SirCo\Portada\PORTADA5.jpg")
            'If TimeOfDay >= "09:00:00" And TimeOfDay < "11:00:00" Then
            '    Me.BackgroundImage = Image.FromFile("\\10.10.1.1\Sistemas .Net\SirCo\Portada\PORTADA5.jpg")

            'ElseIf TimeOfDay >= "17:00:00" And TimeOfDay <= "20:00:00" Then
            '    If GLB_CveSucursal = "11" Then
            '        Me.BackgroundImage = Image.FromFile("\\10.10.1.1\Sistemas .Net\SirCo\Portada\PORTADAPAPOS.PNG")
            '    Else
            '        Me.BackgroundImage = Image.FromFile("\\10.10.1.1\Sistemas .Net\SirCo\Portada\Portada10.jpg")
            '    End If

            'End If
            Call usp_TraerMenspaga()

            'Dim LocalHostName As String = Dns.GetHostName
            'Dim LocalIP As IPHostEntry = Dns.GetHostEntry(LocalHostName)
            'GLB_Ip = LocalIP.AddressList(6).ToString

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub CargarParametros()
        Try
            'mreyes 23/Marzo/2012 10:24 a.m.
            GLB_RutaArchivoDigitalPedidos = pub_TraerParame_Det("RUTAPED")
            GLB_RutaArchivoFotos = pub_TraerParame_Det("RUTAFOTO")  '"d:\fotos"
            GLB_RutaArchivoFotosLocal = pub_TraerParame_Det("RUTAFOTL")  '"d:\fotos"

            If GLB_CveSucursal <> "11" Then
                GLB_RutaArchivoFotosREC = pub_TraerParame_Det("RUTAREC")  '"d:\fotos"
            Else
                GLB_RutaArchivoFotosREC = pub_TraerParame_Det("RREC11")  '"d:\fotos"
            End If


            GLB_CorreoCompras = pub_TraerParame_Det("EMAILCOM")
            GLB_PassCorreoCompras = pub_TraerParame_Det("PASSECOM")

            GLB_CorreoResurtidoCompras = pub_TraerParame_Det("EMAILRES")
            GLB_PassCorreoResurtidoCompras = pub_TraerParame_Det("PASSERES")

            GLB_CorreoHelpDesk = pub_TraerParame_Det("EMAILHEL")
            GLB_PassCorreoHelpDesk = pub_TraerParame_Det("PASSEHEL")
            GLB_SmtpClient = pub_TraerParame_Det("SMTP")
            GLB_Microsip = IIf(pub_TraerParame_Det("MICROSIP") = "SI", True, False)
            GLB_VariasOC = IIf(pub_TraerParame_Det("VARIASOC") = "SI", True, False)
            GLB_ProvDif = pub_TraerParame_Det("PROVDIF")
            GLB_OcXSuc = IIf(pub_TraerParame_Det("OCXSUC") = "SI", True, False)
            GLB_ComEmp = Val(pub_TraerParame_Det("COMEMB"))
            GLB_PedidoExcel = IIf(pub_TraerParame_Det("PEDEXCEL") = "SI", True, False)
            GLB_RutaFotoEmpleado = pub_TraerParame_Det("FOTEMPLE")  '"d:\fotos"
            GLB_CLayout = pub_TraerParame_Det("CLAYOUT")
            GLB_RutaArchivoFotoFichaRem = pub_TraerParame_Det("FICHAREM")
            GLB_RutaContratoAdicionalProv = pub_TraerParame_Det("RUTACTPR")
            GLB_RutaTxtOzono = pub_TraerParame_Det("RUTAOZO")
            GLB_RutaTxtCoqueta = pub_TraerParame_Det("RUTACTA")
            GLB_TiempoHD = pub_TraerParame_Det("TIEMPOHD")
            GLB_DireInv = pub_TraerParame_Det("DIREINV")
            GLB_OPedido = pub_TraerParame_Det("OPEDIDO")

            If GLB_PassCorreoEmpleado = "" Then
                GLB_PassCorreoEmpleado = GLB_PassCorreoCompras
                '            GLB_IdDeptoEmpleado = 0
                GLB_CorreoEmpleado = GLB_CorreoCompras
            End If

            GLB_ImpresoraPredeterminada = usp_CargarPrinter()
            GLB_ImpresoraTicket = "tick"
            GLB_Sw_Plaza = IIf(pub_TraerParame_Det("Sw_Plaza") = "SI", True, False)

            Glb_porcComision = pub_TraerParame_Det("PORCCOM")
            Glb_FTP = pub_TraerParame_Det("FTP")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub





    Private Sub CatalogoEstilos()


        Dim myForm As New frmCatalogoEstilosTienda
        myForm.WindowState = FormWindowState.Normal
        myForm.MdiParent = Me
        myForm.Show()
    End Sub

    Private Sub CatalogoModelos()


        Dim myForm As New frmCatalogoModelos
        myForm.Accion = 5
        myForm.Txt_Marca.Text = "CTA"
        myForm.Txt_Modelo.Text = "    270"
        myForm.WindowState = FormWindowState.Normal
        'myForm.MdiParent = Me
        myForm.Show()
    End Sub

    Private Sub CatalogoMarca()
        If pub_TienePermiso("ABCMARCA") = False Then Exit Sub
        Dim myForm As New frmPpalMarcas
        myForm.WindowState = FormWindowState.Maximized
        myForm.MdiParent = Me
        myForm.Show()
    End Sub

    Private Sub CatalogoDeptos()
        'mreyes 04/Junio/2012 12:10 p.m.
        If pub_TienePermiso("ABCDEPTO") = False Then Exit Sub
        Dim myForm As New frmPpalDeptos
        myForm.WindowState = FormWindowState.Maximized
        myForm.MdiParent = Me
        myForm.Show()
    End Sub

    Private Sub CatalogoPuestos()
        'mreyes 05/Junio/2012 12:05
        If pub_TienePermiso("ABCPUEST") = False Then Exit Sub
        Dim myForm As New frmPpalPuestos
        myForm.WindowState = FormWindowState.Maximized
        myForm.MdiParent = Me
        myForm.Show()
    End Sub


    Private Sub CatalogoDiaFestivo()
        'mreyes 23/Agosto/2012 12:31 p.m.
        If pub_TienePermiso("ABCDFES") = False Then Exit Sub
        Dim myForm As New frmPpalDiaFestivo
        myForm.WindowState = FormWindowState.Maximized
        myForm.MdiParent = Me
        myForm.Show()
    End Sub
    Private Sub CatalogoPreNomina()
        'mreyes 15/Abril/2015   05:56 p.m.
        If pub_TienePermiso("PRENOM") = False Then Exit Sub
        Dim myForm As New frmPpalPreNomina
        myForm.WindowState = FormWindowState.Maximized
        myForm.MdiParent = Me
        myForm.Show()
    End Sub
    Private Sub CatalogoRepetitivos()
        'mreyes 09/Junio/2012 01:09 p.m.
        If pub_TienePermiso("ABCREP") = False Then Exit Sub
        Dim myForm As New frmPpalRepetitivos
        myForm.WindowState = FormWindowState.Maximized
        myForm.MdiParent = Me
        myForm.Show()
    End Sub

    Private Sub CatalogoIncapacidades()
        'mreyes 07/Agosto/2012 11:44 a.m.
        If pub_TienePermiso("ABCINC") = False Then Exit Sub
        Dim myForm As New frmPpalIncapacidad
        myForm.WindowState = FormWindowState.Maximized
        myForm.MdiParent = Me
        myForm.Show()
    End Sub

    Private Sub CatalogoMovEmp()
        'mreyes 07/Agosto/2012 11:44 a.m.
        If pub_TienePermiso("MOVEMP") = False Then Exit Sub
        If Weekday(GLB_FechaHoy) = 5 Then
            MsgBox("No puede acceder al Proceso este día, por petición de Nóminas.", MsgBoxStyle.Information, "Aviso")
            Exit Sub
        End If

        Dim myForm As New frmPpalMovEmp
        myForm.WindowState = FormWindowState.Maximized
        myForm.MdiParent = Me
        myForm.Show()
    End Sub
    Private Sub CatalogoTrack()
        'mreyes 09/Junio/2012 01:09 p.m.
        If pub_TienePermiso("TRACK") = False Then Exit Sub
        '        Dim myForm As New frmCoquetaTrack
        Dim myForm As New frmCatalogoEstilosTrackCoqueta
        'myForm.WindowState = FormWindowState.Maximized
        'myForm.MdiParent = Me
        myForm.Show()
    End Sub
    Private Sub CatalogoEmpleados()
        If Val(GLB_CveSucursal) > 0 And Val(GLB_CveSucursal) < 20 Then
            If Weekday(GLB_FechaHoy) = 5 Then
                MsgBox("No puede acceder al Horario este día.", MsgBoxStyle.Information, "Aviso")
                Exit Sub
            End If
        End If

        'mreyes 09/Junio/2012 01:09 p.m.
        If pub_TienePermiso("ABCEMP") = False Then Exit Sub
        Dim myForm As New frmPpalEmpleados
        myForm.WindowState = FormWindowState.Maximized
        myForm.MdiParent = Me
        myForm.Show()
    End Sub

    Private Sub CatalogoPercDeduc()
        'mreyes 13/Junio/2012 11:17 a.m.
        If pub_TienePermiso("ABCPD") = False Then Exit Sub
        Dim myForm As New frmPpalPercDeduc
        myForm.WindowState = FormWindowState.Maximized
        myForm.MdiParent = Me
        myForm.Show()
    End Sub


    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Call SalirSistema()
    End Sub
    Private Sub SalirSistema()
        If MessageBox.Show("Estas seguro de salir ?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            usp_LiberarAccesoSIRCO()
            Me.Dispose()
            Me.Close()
            End
        End If
    End Sub
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call CatalogoEstilos()
    End Sub

    Private Sub PedidoNuevoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call PedidoNuevo()
    End Sub

    Private Sub Facturas(ByVal Sw_FacturaNueva As Boolean)
        'mreyes 15/Marzo/2012 04:18 p.m.
        If pub_TienePermiso("FACTURAS") = False Then Exit Sub
        Dim myForm As New frmPpalFacturas

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Sw_FacturaNueva = Sw_FacturaNueva
        myForm.Show()
        myForm.Refresh()
    End Sub



    Private Sub DetalleFacturas()

        If pub_TienePermiso("DETFACT") = False Then Exit Sub
        Dim myForm As New frmPpalDetFactProv

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub
    Private Sub Devoluciones()
        'mreyes 29/Marzo/2012 10:34 p.m.
        If pub_TienePermiso("DEVPROV") = False Then Exit Sub
        Dim myForm As New frmPpalDevoluciones

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub
    Private Sub PedidoNuevo()
        If pub_TienePermiso("PEDNUEVO") = False Then Exit Sub
        Dim myForm As New frmPpalPedidoNuevo

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Sw_PedidoNuevo = True
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub Resurtidos()
        'mreyes 14/Marzo/2012 04:18 p.m.
        If pub_TienePermiso("PEDNUEVO") = False Then Exit Sub
        Dim myForm As New frmPpalPedidoNuevo

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Sw_PedidoNuevo = False
        myForm.Show()
        myForm.Refresh()
    End Sub




    Private Sub ProveedoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call CatalogoProveedores()
    End Sub

    Private Sub MercancíaPendientePorRecibirToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MercancíaPendientePorRecibirToolStripMenuItem1.Click
        Call Bitacora()
    End Sub

    Private Sub Bitacora()
        If pub_TienePermiso("BITACORA") = False Then Exit Sub
        Dim myForm As New frmPpalBitacora

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub


    Private Sub CargaChecada()
        'If pub_TienePermiso("BITACORA") = False Then Exit Sub
        If pub_TienePermiso("ABCCHECA") = False Then Exit Sub
        Dim myForm As New frmCargaChecada

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Normal
        myForm.Show()
        myForm.Refresh()
    End Sub
    Private Sub CargaVentasNomina(ByVal Sw_Permiso As Boolean)
        'mreyes 21/Junio/2012 12:11 p.m.
        If Sw_Permiso = True Then
            If pub_TienePermiso("VTASNOM") = False Then Exit Sub
        End If
        Dim myForm As New frmCargaVentasNomina

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Normal
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub CatalogoPeriodo()
        If pub_TienePermiso("PERIODO") = False Then Exit Sub
        Dim myForm As New frmCatalogoPeriodo

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Normal
        myForm.Accion = 1
        myForm.Show()
        myForm.Refresh()
    End Sub
    Private Sub NominaCalculada(ByVal tiponom As String)
        'mreyes 30/Junio/2012 10:50 a.m.
        If pub_TienePermiso("NOMC") = False Then Exit Sub
        Dim myForm As New frmPpalNomina

        myForm.MdiParent = Me
        If tiponom = "B" Then
            myForm.Text = "Nómina Calculada GRAN BONO"
        ElseIf tiponom = "F" Then
            myForm.Text = "Nómina Calculada FISCAL "
        Else
            myForm.Text = "Nómina Calculada AGUINALDO "
        End If
        myForm.TipoNomB = tiponom
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub
    Private Sub Desglose()

        If pub_TienePermiso("DESG") = False Then Exit Sub
        Dim myForm As New frmPpalDesgloseMon

        myForm.MdiParent = Me


        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub
    Private Sub EliminarDetalleNomina()
        'mreyes 30/Junio/2012 10:50 a.m.
        If pub_TienePermiso("ELINOM") = False Then Exit Sub
        Dim myForm As New frmPpalUnidadesEmp

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub
    Private Sub NominaPorConcepto()
        'mreyes 30/Junio/2012 10:50 a.m.
        If pub_TienePermiso("NOMC") = False Then Exit Sub
        Dim myForm As New frmPpalConceptoRep






        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub
    Private Sub Marcajes()
        'mreyes 23/Junio/2012 02:16 p.m.
        If pub_TienePermiso("MARCAJE") = False Then Exit Sub
        Dim myForm As New frmPpalMarcajes

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub
    Private Sub BitacoraRecibida()
        If pub_TienePermiso("BITACORA") = False Then Exit Sub
        Dim myForm As New frmPpalBitacoraRecibida

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub
    Private Sub FotosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Call CatalogoFotos()


    End Sub






    Private Sub CatalogoFotos()




        If pub_TienePermiso("ABCFOTOS") = False Then Exit Sub
        Dim myForm As New frmCatalogoFotos
        myForm.Accion = 2
        'myForm.WindowState = FormWindowState.Maximized
        myForm.MdiParent = Me
        myForm.Show()
    End Sub


    Private Sub CatalogoFotosEmpleado()

        If pub_TienePermiso("ABCFOTOS") = False Then Exit Sub
        Dim myForm As New frmCatalogoFotosEmp
        myForm.Accion = 2
        'myForm.WindowState = FormWindowState.Maximized
        myForm.MdiParent = Me
        myForm.Show()
    End Sub
    Private Sub ReporteDeSeguimientoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReporteDeSeguimientoToolStripMenuItem.Click
        Call Seguimiento()
    End Sub

    Private Sub CatalogoProveedores()
        If pub_TienePermiso("ABCPROVE") = False Then Exit Sub
        Dim myForm As New frmppalproveedoresn

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub
    Private Sub Seguimiento()
        If pub_TienePermiso("RPTSEG") = False Then Exit Sub
        Dim myForm As New frmPpalSeguimientos
        myForm.Sw_Load = True
        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub TSProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSProveedor.Click
        CatalogoProveedores()
    End Sub

    Private Sub TsCamara_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsCamara.Click
        CatalogoFotos()
    End Sub

    Private Sub TsPedidoNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsPedidoNuevo.Click
        Call PedidoNuevo()
    End Sub

    Private Sub TsOrdenCompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsOrdenCompra.Click
        Call Bitacora()
    End Sub

    Private Sub TsSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsSalir.Click
        Call SalirSistema()
    End Sub

    Private Sub TsCarpetaPedidos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsCarpetaPedidos.Click
        Try

            'mreyes 29/Marzo/2012 10:34 p.m.
            If pub_TienePermiso("CARDIG") = False Then Exit Sub

            Dim directorio As String = GLB_RutaArchivoDigitalPedidos


            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)

                If objIO.pub_DirectorioExiste(directorio) = True Then
                    Process.Start("explorer.exe", "/n,/e," + directorio)
                Else
                    MsgBox("No existe la ruta de Pedidos, o no tiene acceso a ella. Verifiquelo con el área correspondiente.", MsgBoxStyle.Critical, "Error de acceso")
                End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ToolStripStatusLabel3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ResurtidoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call Resurtidos()
    End Sub

    Private Sub TSResurtidos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSResurtidos.Click
        Call Resurtidos()
    End Sub

    Private Sub FacturasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call Facturas(False)
    End Sub

    Private Sub TSFacturas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSFacturas.Click
        Call Facturas(False)
    End Sub



    Private Sub IndexToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IndexToolStripMenuItem.Click
        Ayuda()
    End Sub
    Private Sub Ayuda()
        If pub_TienePermiso("AYUDA") = False Then Exit Sub
        Dim Directorio As String = Application.StartupPath
        Process.Start("explorer.exe", "/n,/e," + "\\10.10.1.1\tempo\Bitacora\Help\Bitacora.htm")
    End Sub

    Private Sub TsAyuda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Ayuda()
    End Sub

    Private Sub DevolucionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call Devoluciones()
    End Sub

    Private Sub MercancíaRecibidaToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox("Reporte en proceso", MsgBoxStyle.Information)
        'Call BitacoraRecibida()
    End Sub

    Private Sub TsReconectar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsReconectar.Click
        Try

            ' ''G_ConString = New String(My.Settings.ConnectionStringBonos)
            GLB_ConStringMicrosip = New String(My.Settings.ConnectionStringMicrosip)
            GLB_ConStringCipSis = New String(My.Settings.ConnectionStringCipsis)

            GLB_ConStringPerSis = New String(My.Settings.ConnectionStringPerSis)
            GLB_ConStringNomSis = New String(My.Settings.ConnectionStringNomSis)
            ' ''Glb_ConStringPerSis = New String(My.Settings.ConnectionStringPerSis)

            '' ''ObjCon = New SqlConnection(G_ConString)

            '' ObjCon.Open()
            MsgBox("Conexión realizada con éxito.", MsgBoxStyle.Information, "Confirmación")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsFacturasPendientes.Click
        'Call FacturasPendientes()
        'mreyes 15/Marzo/2012 04:18 p.m.
        If pub_TienePermiso("FACTURAS") = False Then Exit Sub
        Dim myForm As New frmPpalFacturasPendPago

        myForm.MdiParent = Me

        myForm.WindowState = FormWindowState.Maximized
        myForm.Statusb = "PENDIENTE"

        myForm.Sw_FacturaNueva = False
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub EnviarFacturasAMicrosipToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call Facturas(False)
    End Sub



    Private Sub MarcasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call CatalogoMarca()
    End Sub

    Private Sub TsCatalogoMarcas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call CatalogoMarca()
    End Sub


    Private Sub ReciboToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call Facturas(True)
    End Sub

    'Private Sub RelojChecadorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RelojChecadorToolStripMenuItem.Click
    '    Call CargaChecada()
    'End Sub

    Private Sub DepartamentosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DepartamentosToolStripMenuItem.Click
        Call CatalogoDeptos()
    End Sub

    Private Sub PuestosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PuestosToolStripMenuItem.Click
        Call CatalogoPuestos()
    End Sub



    Private Sub ReToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepetitivosToolStripMenuItem.Click
        Call CatalogoRepetitivos()
    End Sub

    Private Sub PercepToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PercepToolStripMenuItem.Click
        Call CatalogoPercDeduc()
    End Sub

    Private Sub EmpleadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmpleadosToolStripMenuItem.Click
        Call CatalogoEmpleados()
    End Sub



    Private Sub MarcajesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MarcajesToolStripMenuItem.Click
        Call Marcajes()
    End Sub

    Private Sub NóminasCalculadasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NóminasCalculadasToolStripMenuItem.Click
        Call NominaCalculada("B")
    End Sub

    Private Sub AperturaDeNóminaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AperturaDeNóminaToolStripMenuItem.Click
        Call CatalogoPeriodo()
    End Sub

    Private Sub IncapacidadesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IncapacidadesToolStripMenuItem.Click
        Call CatalogoIncapacidades()
    End Sub


    'Private Sub VentasNóminaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VentasNóminaToolStripMenuItem.Click
    '    Call CargaVentasNomina(True)
    'End Sub

    Private Sub DíaFestivoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DíaFestivoToolStripMenuItem.Click
        Call CatalogoDiaFestivo()
    End Sub

    Private Sub AlcanceDeMetasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AlcanceDeMetasToolStripMenuItem.Click
        'If GLB_AccesoEmpleado = True Or GLB_Usuario = "MREYES" Or GLB_Usuario = "PAOLA" Or GLB_Usuario = "DLANDE" Then

        If Val(GLB_CveSucursal) > 0 And Val(GLB_CveSucursal) < 20 Then
            If TimeOfDay >= "08:00:00" And TimeOfDay < "19:00:00" Then
                MsgBox("El horario para acceso a reporte es después de las 19:00 hrs.", MsgBoxStyle.Information, "Aviso")
                Exit Sub
            End If
        End If

        Call PrincipalVentaNomina(True)
        'Else
        'MsgBox("No tiene permiso para Acceder a esta opción", MsgBoxStyle.Critical, "Error Acceso")
        'End If
    End Sub

    Private Sub ResumenNomina()

        If pub_TienePermiso("PPALRNOM") = False Then Exit Sub
        Dim myForm As New frmPpalNominaResumen
        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()


    End Sub
    Private Sub PrincipalVentaNomina(ByVal Sw_Permiso As Boolean)
        If pub_TienePermiso("ALCNOM") = False Then Exit Sub
        Dim myForm As New frmPpalVentaNomina


        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub CalculoDeLaNóminaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalculoDeLaNóminaToolStripMenuItem.Click
        Call CalculoNomina()
    End Sub
    Private Sub CalculoNomina()
        If pub_TienePermiso("CALNOM") = False Then Exit Sub
        Dim myForm As New frmCalculoNomina

        myForm.MdiParent = Me
        ' myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub MetasPorSucursal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetasPorSucursal.Click
        Call CalculoMeta()
    End Sub

    Private Sub CalculoMeta()
        'mreyes 28/Agosto/2012 03:12 p.m.

        If pub_TienePermiso("CALMET") = False Then Exit Sub
        Dim myForm As New frmPpalMeta

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub NóminaPorConceptoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NóminaPorConceptoToolStripMenuItem.Click
        Call NominaPorConcepto()
    End Sub

    Private Sub FotoEmpleadoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FotoEmpleadoToolStripMenuItem.Click
        CatalogoFotosEmpleado()
    End Sub

    Private Sub EliminarDetalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarDetalToolStripMenuItem.Click
        EliminarDetalleNomina()
    End Sub

    Private Sub MovEmpToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MovEmpToolStripMenuItem.Click
        CatalogoMovEmp()
    End Sub

    Private Sub TsCatalogoEmpleados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsCatalogoEmpleados.Click
        Call CatalogoEmpleados()
    End Sub

    Private Sub TrackToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackToolStripMenuItem.Click
        Call CatalogoTrack()
    End Sub

    Private Sub ResumenDeNToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResumenDeNToolStripMenuItem.Click
        ResumenNomina()
    End Sub

    Private Sub NóminasCalculadasFiscalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NóminasCalculadasFiscalToolStripMenuItem.Click
        Call NominaCalculada("F")
    End Sub

    Private Sub DesgloseMonetarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DesgloseMonetarioToolStripMenuItem.Click
        Call Desglose()
    End Sub

    Private Sub ToolStripButton1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        'If pub_TienePermiso("CONTRASE") = False Then Exit Sub
        Dim myForm As New frmCambioPassword
        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Normal
        myForm.Show()
        myForm.Refresh()
    End Sub




    Private Sub ActividadesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActividadesToolStripMenuItem.Click
        Call aCTIVIDADES()
    End Sub
    Private Sub aCTIVIDADES()
        ' If pub_TienePermiso("ACTIVI") = False Then Exit Sub
        Dim myForm As New frmPpalActividadesEmp
        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub AntigüedadDelInventarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call AntiguedadInventario()
    End Sub
    Private Sub ArtSinFoto()

        If pub_TienePermiso("SINFOTO") = False Then Exit Sub

        Dim myForm As New frmPpalArticulosSinFoto


        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub AntiguedadInventario()

        If pub_TienePermiso("AntiInv") = False Then Exit Sub

        Dim myForm As New frmPpalAntiInventEstructura


        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Opcion = 1
        myForm.Show()

        If myForm.blnActualizando = True Then
            myForm.Close()
        End If
        myForm.Refresh()
    End Sub
    Private Sub Inventario()

        If pub_TienePermiso("INVENT") = False Then Exit Sub

        Dim myForm As New frmPpalAntiInventEstructura


        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Accion = 2
        myForm.Show()
        myForm.Refresh()
    End Sub


    Private Sub ArtículosSinFotoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ArtículosSinFotoToolStripMenuItem.Click
        Call ArtSinFoto()
    End Sub

    Private Sub VerificarTraspasoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GeneraTraspasoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TraspasoAutomáticoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub NoDeValesPorNegocioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If pub_TienePermiso("VALNEG") = False Then Exit Sub

        Dim myForm As New frmPpalValesPorNegocio


        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub



    Private Sub PendientesPorRecibirToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PendientesPorRecibirToolStripMenuItem1.Click
        'Dim myForm As New frmPpalTraspasos
        'GLB_TraspasosRecibidos = False
        'myForm.MdiParent = Me
        'myForm.WindowState = FormWindowState.Maximized
        'myForm.Show()
        'myForm.Refresh()
        'If pub_TienePermiso("VALNEG") = False Then Exit Sub
        Dim myForm As New frmPpalTrasPendRecibo

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Opcion = 1
        myForm.OpcionSP = 3
        myForm.Show()
        myForm.Refresh()

    End Sub




    Private Sub GeneraTraspasoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim myForm As New frmPpalGenerarTraspaso

        'GLB_TraspasosRecibidos = True
        'myForm.MdiParent = Me
        'myForm.WindowState = FormWindowState.Maximized
        'myForm.Show()
        'myForm.Refresh()
    End Sub



    Private Sub MarcasToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MarcasToolStripMenuItem.Click
        Call CatalogoMarca()
    End Sub

    Private Sub ProveedoresToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProveedoresToolStripMenuItem.Click
        Call CatalogoProveedores()
    End Sub



    Private Sub FotosToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FotosToolStripMenuItem.Click
        Call CatalogoFotos()
    End Sub

    Private Sub PedidoNuevoToolStripMenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PedidoNuevoToolStripMenuItem1.Click
        Call PedidoNuevo()
    End Sub

    Private Sub ResurtidoToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResurtidoToolStripMenuItem.Click
        Call Resurtidos()
    End Sub



    Private Sub DevolucionesToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DevolucionesToolStripMenuItem.Click
        Call Devoluciones()
    End Sub



    Private Sub ReciboToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call Facturas(True)
    End Sub


    Private Sub EnviarFacturasAMicrosipToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call Facturas(True)
    End Sub

    'Private Sub ClasificaciónDeEstilosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClasificaciónDeEstilosToolStripMenuItem.Click
    '    Call ClasificacionEstilos()
    'End Sub

    Private Sub DetalleFacturasDeProveedorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call DetalleFacturas()
    End Sub


    Private Sub CalculoDeAguinaldoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalculoDeAguinaldoToolStripMenuItem.Click
        If pub_TienePermiso("CALNOM") = False Then Exit Sub
        Dim myForm As New frmCalculoNomina

        myForm.MdiParent = Me
        myForm.Tipo = "AGUINALDO"
        ' myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub NóminaAguinaldoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NóminaAguinaldoToolStripMenuItem.Click
        Call NominaCalculada("A")
    End Sub

    Private Sub ReciboDeBultosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub ReciboBultos()
        If pub_TienePermiso("RECBUL") = False Then Exit Sub
        '        Dim myForm As New frmPpalReciboBultos
        Dim myForm As New frmPpalBultosDet

        myForm.MdiParent = Me
        myForm.Opcion = 2
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ReciboDeBultosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If pub_TienePermiso("RECBU1") = False Then Exit Sub
        '        Dim myForm As New frmPpalReciboBultos
        Dim myForm As New frmPpalBultosDet

        myForm.MdiParent = Me
        myForm.Opcion = 2
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub DiarioValesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If pub_TienePermiso("VALNEG") = False Then Exit Sub

        Dim myForm As New frmPpalDiarioVales


        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ReciboADetalleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReciboADetalleToolStripMenuItem.Click
        'mreyes 15/Marzo/2012 04:18 p.m.
        If pub_TienePermiso("RECDET") = False Then Exit Sub
        Dim myForm As New frmPpalFacturas

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Sw_FacturaNueva = True
        myForm.Sw_Costos = False
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub InventarioCedis()
        If pub_TienePermiso("INVCEDI") = False Then Exit Sub
        '        Dim myForm As New frmPpalReciboBultos
        Dim myForm As New frmPpalInventCedis

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub
    Private Sub AntigüedadDeBultosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AntigüedadDeBultosToolStripMenuItem.Click
        If pub_TienePermiso("RECBU6") = False Then Exit Sub
        '        Dim myForm As New frmPpalReciboBultos
        Dim myForm As New frmPpalBultosDet

        myForm.MdiParent = Me
        myForm.Opcion = 1
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub CatálogoDeEstilosPorEstructuraToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CatálogoDeEstilosPorEstructuraToolStripMenuItem.Click
        If pub_TienePermiso("CATFOTO") = False Then Exit Sub
        Dim myForm As New frmCatalogoFotosFamLinea
        myForm.WindowState = FormWindowState.Normal
        'myForm.MdiParent = Me
        myForm.Show()
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If pub_TienePermiso("VALNEG") = False Then Exit Sub

        Dim myForm As New frmPpalDiarioVales


        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub




    Private Sub InventarioCedisToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InventarioCedisToolStripMenuItem.Click
        Call InventarioCedis()
    End Sub







    Private Sub AntigüedadDelInventarioToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AntigüedadDelInventarioToolStripMenuItem.Click
        Call AntiguedadInventario()
    End Sub

    Private Sub InventarioACostoYVentaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InventarioACostoYVentaToolStripMenuItem.Click
        Call Inventario()
    End Sub

    Private Sub FirmasDeDistribuidorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FirmasDeDistribuidorToolStripMenuItem.Click
        Dim myForm As New frmCatalogoFirmasDistrib


        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Normal
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub NoDeValesPorNegocioToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NoDeValesPorNegocioToolStripMenuItem.Click
        If pub_TienePermiso("VALNEG") = False Then Exit Sub

        Dim myForm As New frmPpalValesPorNegocio


        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    'Private Sub AsignarSerieRelojToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AsignarSerieRelojToolStripMenuItem.Click
    '    If pub_TienePermiso("X") = False Then Exit Sub
    '    Dim myForm As New frmCargaSerieReloj

    '    myForm.MdiParent = Me
    '    myForm.WindowState = FormWindowState.Normal
    '    myForm.Show()
    '    myForm.Refresh()
    'End Sub









    Private Sub EstructuraToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstructuraToolStripMenuItem1.Click
        If pub_TienePermiso("ESTRUC") = False Then Exit Sub
        Dim myForm As New frmPpalEstructura

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()

    End Sub

    Private Sub DivisiónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DivisiónToolStripMenuItem.Click
        If pub_TienePermiso("ESTRUC") = False Then Exit Sub
        Dim myForm As New frmPpalDivisiones

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub DepartamentoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DepartamentoToolStripMenuItem.Click
        If pub_TienePermiso("ESTRUC") = False Then Exit Sub
        Dim myForm As New frmPpalDepartamento

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub FamiliaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FamiliaToolStripMenuItem.Click
        If pub_TienePermiso("ESTRUC") = False Then Exit Sub
        Dim myForm As New frmPpalFamilia

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub LíneaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LíneaToolStripMenuItem.Click
        If pub_TienePermiso("ESTRUC") = False Then Exit Sub
        Dim myForm As New frmPpalLinea

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub SubSubLíneaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubSubLíneaToolStripMenuItem.Click

        'Dim myForm As New frmPpalSubSubLinea

        'myForm.MdiParent = Me
        'myForm.WindowState = FormWindowState.Maximized
        'myForm.Show()
        'myForm.Refresh()
    End Sub

    Private Sub SubSubSubLíneaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubSubSubLíneaToolStripMenuItem.Click
        'Dim myForm As New frmPpalSubSubSubLinea

        'myForm.MdiParent = Me
        'myForm.WindowState = FormWindowState.Maximized
        'myForm.Show()
        'myForm.Refresh()
    End Sub

    Private Sub ModelosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModelosToolStripMenuItem.Click
        If pub_TienePermiso("CATMOD") = False Then Exit Sub
        Dim myForm As New frmPpalModelos
        myForm.WindowState = FormWindowState.Maximized
        myForm.MdiParent = Me
        myForm.Show()
    End Sub

    Private Sub TsCatalogoModelos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call CatalogoModelos()
    End Sub

    Private Sub CargoPorDevoluciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CargoPorDevoluciónToolStripMenuItem.Click
        Call Devoluciones()
    End Sub

    Private Sub Ventas8020ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If pub_TienePermiso("VTAS80") = False Then Exit Sub

        Dim myForm As New frmPpalreporteVentas


        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub VentasDesglosadoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If pub_TienePermiso("VTASDE") = False Then Exit Sub

        Dim myForm As New frmPpalVentasDistribuidores


        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub RemisiónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemisiónToolStripMenuItem.Click
        'mreyes 15/Marzo/2012 04:18 p.m.
        If pub_TienePermiso("FACTURAS") = False Then Exit Sub
        Dim myForm As New frmPpalFacturas

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Sw_Remision = True
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub VentasPorPeriodoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VentasPorPeriodoToolStripMenuItem.Click
        Dim myForm As New frmPpalReporteVentasDwh

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub TS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TS.Click
        Call CatalogoEmpleados()
    End Sub





    Private Sub LiquidacionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LiquidacionesToolStripMenuItem.Click
        If pub_TienePermiso("PEDNUEVO") = False Then Exit Sub
        Dim myForm As New frmCatalogoLiquidacion

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub





    Private Sub ToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem7.Click
        'mreyes 15/Marzo/2012 04:18 p.m.
        If pub_TienePermiso("FACTURAS") = False Then Exit Sub
        Dim myForm As New frmPpalFacturas

        myForm.MdiParent = Me

        ' myForm.Sw_PagoUnico = False
        myForm.WindowState = FormWindowState.Maximized
        myForm.Statusb = "PENDIENTE"
        myForm.Reporte = 2
        myForm.Sw_FacturaNueva = False
        myForm.Sw_PagoUnico = True
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ToolStripMenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem10.Click
        'mreyes 15/Marzo/2012 04:18 p.m.
        If pub_TienePermiso("FACTURAS") = False Then Exit Sub
        Dim myForm As New frmPpalFacturas

        myForm.MdiParent = Me

        myForm.WindowState = FormWindowState.Maximized
        myForm.Statusb = "PAGADO"
        myForm.Sw_FacturaNueva = False
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ToolStripMenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem9.Click
        'mreyes 15/Marzo/2012 04:18 p.m.
        If pub_TienePermiso("FACTURAS") = False Then Exit Sub
        Dim myForm As New frmPpalFacturas

        myForm.MdiParent = Me

        myForm.WindowState = FormWindowState.Maximized
        myForm.Statusb = ""
        myForm.Sw_FacturaNueva = False
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        'mreyes 15/Marzo/2012 04:18 p.m.
        If pub_TienePermiso("FACTURAS") = False Then Exit Sub
        Dim myForm As New frmPpalFacturas

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Sw_Remision = True
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub SaldosDeProveedoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaldosDeProveedoresToolStripMenuItem.Click
        'mreyes 15/Marzo/2012 04:18 p.m.
        If pub_TienePermiso("FACTURAS") = False Then Exit Sub
        Dim myForm As New frmPpalFacturas

        myForm.MdiParent = Me

        myForm.WindowState = FormWindowState.Maximized
        myForm.Statusb = "0"
        myForm.Reporte = 1
        myForm.Sw_FacturaNueva = False
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub NotasDeCréditoOCargoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotasDeCréditoOCargoToolStripMenuItem.Click
        'mreyes 15/Marzo/2012 04:18 p.m.
        If pub_TienePermiso("CREDI") = False Then Exit Sub
        Dim myForm As New frmPpalCargos

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ToolStripMenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem11.Click
        'mreyes 15/Marzo/2012 04:18 p.m.
        If pub_TienePermiso("FACTURAS") = False Then Exit Sub
        Dim myForm As New frmPpalFacturas

        myForm.MdiParent = Me

        myForm.WindowState = FormWindowState.Maximized
        myForm.Statusb = "0"
        myForm.Reporte = 1
        myForm.Sw_FacturaNueva = False
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ToolStripMenuItem12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem12.Click
        CatalogoProveedores()
    End Sub

    Private Sub EstadísticaDeVentasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstadísticaDeVentasToolStripMenuItem.Click

        Dim myForm As New frmPpalReporteVentasDwh

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub


    Private Sub ToolStripMenuItem13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem13.Click
        Dim myForm As New frmPpalTrasPendRecibo

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Opcion = 2
        myForm.OpcionSP = 3
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub GastosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GastosToolStripMenuItem.Click

        Dim myForm As New frmPpalGastos
        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ReportesToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportesToolStripMenuItem2.Click

    End Sub




    Private Sub ToolStripMenuItem20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem20.Click
        If pub_TienePermiso("NEGEXT") = False Then Exit Sub
        Dim myForm As New frmPpalNegExternos
        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub


    Private Sub ToolStripMenuItem17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem17.Click
        If pub_TienePermiso("CATDIS") = False Then Exit Sub

        Dim myForm As New frmPpalCatalogoDistrib
        myForm.TipoCatalogo = 0
        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ToolStripMenuItem19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem19.Click
        If pub_TienePermiso("CATCLIE") = False Then Exit Sub
        Dim myForm As New frmPpalCliente
        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub







    Private Sub EntregaDeValeraToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ValesCanceladosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub



    Private Sub CargoPorDevoluciónPorSerieToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CargoPorDevoluciónPorSerieToolStripMenuItem.Click
        If pub_TienePermiso("DEVPROV") = False Then Exit Sub
        Dim myForm As New frmPpalDevoluciones

        myForm.Sw_Serie = True
        myForm.MdiParent = Me
        myForm.Text = "Cargo de Devolución por Serie"
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        'Dim myForm As New frmCatalogoExistenciasTienda
        'myForm.WindowState = FormWindowState.Normal
        'myForm.Accion = 2
        ''myForm.MdiParent = Me
        'myForm.Show()

        If GLB_CveSucursal = "01" Or GLB_CveSucursal = "02" Or GLB_CveSucursal = "06" Or GLB_CveSucursal = "07" Or GLB_CveSucursal = "08" Or GLB_CveSucursal = "11" Or GLB_CveSucursal = "91" Or GLB_CveSucursal = "15" Then
            If pub_TienePermiso("EXISTDA") = False Then Exit Sub
            Dim myForm As New frmCatalogoExistenciasTienda
            myForm.WindowState = FormWindowState.Maximized
            myForm.Accion = 2
            myForm.MdiParent = Me
            myForm.Show()
        Else
            If pub_TienePermiso("EXISTDA") = False Then Exit Sub
            If GLB_IdDeptoEmpleado = 7 And GLB_IdPuestoEmpleado = 23 Then
                Dim myForm As New frmCatalogoExistenciasTienda
                myForm.WindowState = FormWindowState.Maximized
                myForm.Accion = 2
                myForm.MdiParent = Me
                myForm.Show()
            Else

                Dim myForm As New frmAnalisisModelo
                myForm.Sw_Menu = True
                myForm.WindowState = FormWindowState.Maximized
                myForm.Accion = 2

                myForm.Show()
            End If

        End If
    End Sub



    Private Sub ToolStripMenuItem22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If pub_TienePermiso("APENDI") = False Then Exit Sub
        Dim myForm As New frmApendice

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Normal
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub VentasPorFormasDePagoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VentasPorFormasDePagoToolStripMenuItem.Click
        If pub_TienePermiso("FPAGO") = False Then Exit Sub
        Dim myForm As New frmPpalFormasPago

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()

    End Sub











    Private Sub VentasCeroToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VentasCeroToolStripMenuItem.Click
        If pub_TienePermiso("VTACERO") = False Then Exit Sub
        Dim myForm As New frmPpalVentasCero

        myForm.MdiParent = Me
        myForm.Accion = 0
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub VentaPorNúmeroDeParesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VentaPorNúmeroDeParesToolStripMenuItem.Click
        Dim myForm As New frmPpalVentasCero

        myForm.MdiParent = Me
        myForm.Accion = 2
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub



    Private Sub EnvioTraspasoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnvioTraspasoToolStripMenuItem.Click
        Dim myForm As New frmPpalTraspasosManuales

        myForm.Opcion = 1
        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub RecepciónTraspasoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RecepciónTraspasoToolStripMenuItem.Click
        Dim myForm As New frmPpalTraspasosManuales

        myForm.Opcion = 2
        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub EnvioTraspasoDEVOLUCIÓNToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim myForm As New frmPpalTraspasosManuales

        myForm.Opcion = 3
        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub RecepciónTraspasoDEVOLUCIÓNToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim myForm As New frmPpalTraspasosManuales

        myForm.Opcion = 4
        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub



    Private Sub ArchivoOzonoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ArchivoOzonoToolStripMenuItem.Click
        Dim myForm As New frmGeneraTxtOzono

        'myForm.MdiParent = Me
        'myForm.Accion = 0
        'myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub



    Private Sub BaseVentasNóminaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BaseVentasNóminaToolStripMenuItem.Click
        Call CargaVentasNomina(True)
    End Sub




    Private Sub RelojChecadorToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RelojChecadorToolStripMenuItem1.Click
        Call CargaChecada()
    End Sub

    Private Sub CentroDeCostosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim myForm As New frmPpalCentroCosto
        'myForm.MdiParent = Me
        'myForm.WindowState = FormWindowState.Maximized
        'myForm.Show()
        'myForm.Refresh()
    End Sub


    Private Sub CentroDeFlujoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim myForm As New frmPpalCentroFlujo
        'myForm.MdiParent = Me
        'myForm.WindowState = FormWindowState.Maximized
        'myForm.Show()
        'myForm.Refresh()
    End Sub

    Private Sub SaldosProveedoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaldosProveedoresToolStripMenuItem.Click
        'mreyes 15/Marzo/2012 04:18 p.m.
        If pub_TienePermiso("FACTURAS") = False Then Exit Sub
        Dim myForm As New frmPpalSaldosProv

        myForm.MdiParent = Me

        myForm.WindowState = FormWindowState.Maximized
        myForm.Opcion = 1

        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        'mreyes 15/Marzo/2012 04:18 p.m.
        If pub_TienePermiso("FACTURAS") = False Then Exit Sub
        Dim myForm As New frmPpalFacturas

        myForm.MdiParent = Me

        myForm.WindowState = FormWindowState.Maximized
        myForm.Statusb = "PAGADO"
        myForm.Sw_FacturaNueva = False
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ToolStripMenuItem23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem23.Click
        If pub_TienePermiso("CATVALER") = False Then Exit Sub
        Dim myForm As New frmPpalValeras
        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ToolStripMenuItem24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem24.Click
        If pub_TienePermiso("CATVAC") = False Then Exit Sub
        Dim myForm As New frmPpalCancelarVales
        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub





    Private Sub ProcesosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub









    Private Sub DiarioDeValesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DiarioDeValesToolStripMenuItem.Click
        If pub_TienePermiso("VALNEG") = False Then Exit Sub

        Dim myForm As New frmPpalDiarioVales


        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub












    Private Sub Antigüedad250DíasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Antigüedad250DíasToolStripMenuItem.Click

        If pub_TienePermiso("AntiInv") = False Then Exit Sub

        Dim myForm As New frmPpalAntiInventEstructura


        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Opcion = 13
        myForm.Accion = 1
        myForm.DiasIni = 365
        myForm.DiasFin = 9000

        myForm.Sw_Mas250 = True
        myForm.Show()

        If myForm.blnActualizando = True Then
            myForm.Close()
        End If
        myForm.Refresh()

    End Sub


    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click

        If pub_TienePermiso("DETSE") = False Then Exit Sub
        Dim myForm As New frmDet_Serie

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Accion = 2
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ArchivoParaFactorajeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ArchivoParaFactorajeToolStripMenuItem.Click
        'mreyes 14/Octubre/2014 |0:48 a.m.
        If pub_TienePermiso("FACTOR") = False Then Exit Sub
        Dim myForm As New frmPpalArchivoFactoraje

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Statusb = "FACTORAJE"
        myForm.Reporte = 2
        myForm.Sw_FacturaNueva = False
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub CatálogoDeBancosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CatálogoDeBancosToolStripMenuItem.Click
        'mreyes 14/Octubre/2014 04:13 p.m.
        'If pub_TienePermiso("FACTOR") = False Then Exit Sub
        'Dim myForm As New frmPpalCatalogoBancosFactoraje
        'myForm.MdiParent = Me

        'myForm.WindowState = FormWindowState.Maximized

        'myForm.Show()
        'myForm.Refresh()
    End Sub

    Private Sub ToolStripMenuItem27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub SaldosFactorajeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaldosFactorajeToolStripMenuItem.Click
        If pub_TienePermiso("FACTOR") = False Then Exit Sub
        Dim myForm As New frmPpalSaldosFactoraje

        myForm.MdiParent = Me

        myForm.WindowState = FormWindowState.Maximized
        myForm.Opcion = 1
        myForm.Sw_Reporte = 1
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub SaldosCondiciónProveedorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaldosCondiciónProveedorToolStripMenuItem.Click
        If pub_TienePermiso("FACTOR") = False Then Exit Sub
        Dim myForm As New frmPpalSaldosFactoraje

        myForm.MdiParent = Me

        myForm.WindowState = FormWindowState.Maximized
        myForm.Opcion = 1
        myForm.Sw_Reporte = 2
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub PorBancoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PorBancoToolStripMenuItem.Click
        If pub_TienePermiso("FACTOR") = False Then Exit Sub
        Dim myForm As New frmPpalSaldosFactoraje

        myForm.MdiParent = Me

        myForm.WindowState = FormWindowState.Maximized
        myForm.Opcion = 1
        myForm.Sw_Reporte = 3
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub CancelaciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelaciónToolStripMenuItem.Click
        'mreyes 24/Octubre/2014 09:32 a.m.
        If pub_TienePermiso("FACTOR") = False Then Exit Sub
        Dim myForm As New frmPpalCancelaFactoraje

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Statusb = "RECIBIDO"
        myForm.Reporte = 2
        myForm.Sw_FacturaNueva = False
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub EmparrilladoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmparrilladoToolStripMenuItem.Click

    End Sub

    Private Sub FacturasPorVencerAFactorajeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacturasPorVencerAFactorajeToolStripMenuItem.Click
        'mreyes 15/Marzo/2012 04:18 p.m.
        If pub_TienePermiso("FACTURAS") = False Then Exit Sub
        Dim myForm As New frmPpalFacturas

        myForm.MdiParent = Me

        myForm.WindowState = FormWindowState.Maximized
        myForm.Statusb = "RECIBIDO"
        myForm.Sw_Factoraje = True
        myForm.Reporte = 2
        myForm.Sw_FacturaNueva = False
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub FacturasPendientesDePagoDiferidoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacturasPendientesDePagoDiferidoToolStripMenuItem.Click
        'mreyes 15/Marzo/2012 04:18 p.m.
        If pub_TienePermiso("FACTURAS") = False Then Exit Sub
        Dim myForm As New frmPpalFacturasDiferidos

        myForm.MdiParent = Me

        myForm.WindowState = FormWindowState.Maximized
        myForm.Statusb = "PENDIENTE"
        myForm.Reporte = 2
        myForm.Sw_FacturaNueva = False
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub SaldosPorProveedorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub FacturasYAPublicadasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacturasYAPublicadasToolStripMenuItem.Click
        'mreyes 14/Octubre/2014 |0:48 a.m.
        If pub_TienePermiso("FACTOR") = False Then Exit Sub
        Dim myForm As New frmPpalArchivoFactoraje

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Statusb = "PUBLICADO"
        myForm.Reporte = 2
        myForm.Text = "Facturas YA Publicadas"
        myForm.Sw_Publicadas = True
        myForm.Sw_FacturaNueva = False
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub SalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ProyecciónDePagosFactorajeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub SaldosPorProveedorPagoUnicoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If pub_TienePermiso("FACTOR") = False Then Exit Sub
        Dim myForm As New frmPpalSaldosFactoraje

        myForm.MdiParent = Me

        myForm.WindowState = FormWindowState.Maximized
        myForm.Opcion = 1
        myForm.Sw_Reporte = 4
        myForm.TipoB = "PAGOUNICO"
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub SaldosPorProveedorPagoDiferidoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub MatchTimbradoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MatchTimbradoToolStripMenuItem.Click
        If pub_TienePermiso("MATTIM") = False Then Exit Sub
        Dim myForm As New frmPpalMatchTimbrado


        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub StatusStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles StatusStrip1.ItemClicked

    End Sub

    Private Sub PreNóminaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreNóminaToolStripMenuItem.Click
        Call CatalogoPreNomina()
    End Sub

    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
        Call CatalogoPreNomina()
    End Sub

    Private Sub AparadorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AparadorToolStripMenuItem.Click
        If pub_TienePermiso("APARADO") = False Then Exit Sub
        Dim myForm As New frmPpalAparador
        myForm.WindowState = FormWindowState.Maximized
        myForm.MdiParent = Me
        myForm.Show()
    End Sub



    Private Sub ComisiónVansToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComisiónVansToolStripMenuItem.Click
        If pub_TienePermiso("FACTURAS") = False Then Exit Sub
        Dim myForm As New frmPpalFacturas554

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Sw_FacturaNueva = False
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub CorteDeFoliosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CorteDeFoliosToolStripMenuItem.Click
        If pub_TienePermiso("CORFOLIO") = False Then Exit Sub

        Dim myForm As New frmPpalCorteFolios

        myForm.MdiParent = Me

        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub AperturaDeInventarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AperturaDeInventarioToolStripMenuItem.Click
        If pub_TienePermiso("APEINV") = False Then Exit Sub

        Dim myForm As New frmAbrirInventario

        myForm.MdiParent = Me

        myForm.WindowState = FormWindowState.Normal
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ArtículosNoInventariadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ArtículosNoInventariadosToolStripMenuItem.Click
        If pub_TienePermiso("SUBEINV") = False Then Exit Sub

        Dim myForm As New frmPpalFaltanteInv

        myForm.MdiParent = Me

        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub RegistrarInventarioFísicoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistrarInventarioFísicoToolStripMenuItem.Click
        If pub_TienePermiso("SUBEINV") = False Then Exit Sub

        Dim myForm As New frmPpalInvFis

        myForm.MdiParent = Me

        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ToolStripMenuItem35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem35.Click
        If pub_TienePermiso("FACTOR") = False Then Exit Sub
        Dim myForm As New frmPpalSaldosFactoraje

        myForm.MdiParent = Me

        myForm.WindowState = FormWindowState.Maximized
        myForm.Opcion = 1
        myForm.Sw_Reporte = 4
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ToolStripMenuItem32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem32.Click
        If pub_TienePermiso("FACTOR") = False Then Exit Sub
        Dim myForm As New frmPpalSaldosFactoraje

        myForm.MdiParent = Me

        myForm.WindowState = FormWindowState.Maximized
        myForm.Opcion = 1
        myForm.Sw_Reporte = 4
        myForm.TipoB = "PAGODIF"
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ToolStripMenuItem30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem30.Click
        If pub_TienePermiso("FACTOR") = False Then Exit Sub
        Dim myForm As New frmPpalSaldosFactoraje

        myForm.MdiParent = Me

        myForm.WindowState = FormWindowState.Maximized
        myForm.Opcion = 1
        myForm.Sw_Reporte = 3
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ToolStripMenuItem31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem31.Click
        If pub_TienePermiso("FACTOR") = False Then Exit Sub
        Dim myForm As New frmPpalSaldosFactoraje

        myForm.MdiParent = Me

        myForm.WindowState = FormWindowState.Maximized
        myForm.Opcion = 1
        myForm.Sw_Reporte = 5
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ToolStripMenuItem33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem33.Click
        If pub_TienePermiso("FACTOR") = False Then Exit Sub
        Dim myForm As New frmPpalSaldosFactoraje

        myForm.MdiParent = Me

        myForm.WindowState = FormWindowState.Maximized
        myForm.Opcion = 1
        myForm.Sw_Reporte = 4
        myForm.TipoB = "PAGOUNICO"
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub PagosAFactorajeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PagosAFactorajeToolStripMenuItem.Click
        'mreyes 29/Julio/2015   11:03 a.m.
        If pub_TienePermiso("FACTOR") = False Then Exit Sub
        Dim myForm As New frmPpalPagosBancoFactoraje
        myForm.MdiParent = Me

        myForm.WindowState = FormWindowState.Maximized

        myForm.Show()
        myForm.Refresh()
    End Sub



    Private Sub EmparrilladosPagoUnicoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmparrilladosPagoUnicoToolStripMenuItem.Click
        If pub_TienePermiso("FACTOR") = False Then Exit Sub
        Dim myForm As New frmPpalSaldosProvPedido

        myForm.MdiParent = Me

        myForm.WindowState = FormWindowState.Maximized
        myForm.Opcion = 1
        myForm.Sw_Reporte = 4
        myForm.TipoB = "PAGOUNICO"
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub EmparrilladosPagoDiferidoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmparrilladosPagoDiferidoToolStripMenuItem.Click
        If pub_TienePermiso("FACTOR") = False Then Exit Sub
        Dim myForm As New frmPpalSaldosProvPedido

        myForm.MdiParent = Me

        myForm.WindowState = FormWindowState.Maximized
        myForm.Opcion = 1
        myForm.Sw_Reporte = 4
        myForm.TipoB = "PAGODIF"
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub EmparrilladosTotalesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmparrilladosTotalesToolStripMenuItem.Click
        If pub_TienePermiso("FACTOR") = False Then Exit Sub
        Dim myForm As New frmPpalSaldosProvPedido

        myForm.MdiParent = Me

        myForm.WindowState = FormWindowState.Maximized
        myForm.Opcion = 1
        myForm.Sw_Reporte = 4
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ImprimirEtiquetasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimirEtiquetasToolStripMenuItem.Click
        If pub_TienePermiso("IMPSE") = False Then Exit Sub
        Dim myForm As New frmImprimirSeries

        myForm.Btn_Series.Visible = True
        myForm.ShowDialog()



    End Sub




    Private Sub CerrarInventarioFísicoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CerrarInventarioFísicoToolStripMenuItem.Click

    End Sub



    Private Sub CajaCalzadoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CajaCalzadoToolStripMenuItem.Click
        If pub_TienePermiso("CAJCALZ") = False Then Exit Sub
        Dim myForm As New frmPpalCajaCalzado
        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ArchivoCoquetaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ArchivoCoquetaToolStripMenuItem.Click
        Dim myForm As New frmGeneraTxtCoqueta

        'myForm.MdiParent = Me
        'myForm.Accion = 0
        'myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ToolStripMenuItem34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem34.Click
        If pub_TienePermiso("APARADO") = False Then Exit Sub
        Dim myForm As New frmPpalTraerReciboAparador
        myForm.Accion = 2
        myForm.WindowState = FormWindowState.Maximized
        myForm.MdiParent = Me
        myForm.Show()
    End Sub

    Private Sub MostrarIPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MostrarIPToolStripMenuItem.Click

        Dim myForm As New frmMostrarIP

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Normal
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub TraspaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TraspaToolStripMenuItem.Click
        'If pub_TienePermiso("TRAPEN") = False Then Exit Sub
        Dim myForm As New frmPpaPendientesRealizar

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Opcion = 1
        myForm.OpcionSP = 1
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub TraspasosAutomáticosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TraspasosAutomáticosToolStripMenuItem.Click
        'Dim myForm As New frmAnalisisPropuestaTraspasos
        'myForm.Sw_Menu = True
        'myForm.WindowState = FormWindowState.Maximized
        'myForm.Accion = 2

        'myForm.Show()

        If pub_TienePermiso("TRAAUT") = False Then Exit Sub
        Dim myForm As New frmFiltrosTraspasosAutomaticos

        myForm.WindowState = FormWindowState.Normal

        myForm.StartPosition = FormStartPosition.CenterScreen


        myForm.Show()
    End Sub

    Private Sub BitácoraModelosNoTraspasadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BitácoraModelosNoTraspasadToolStripMenuItem.Click
        If pub_TienePermiso("TRAPEN") = False Then Exit Sub
        Dim myForm As New frmPpalModelosNoTraspasados

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Opcion = 1
        myForm.OpcionSP = 1
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub EtiquetasAparadorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EtiquetasAparadorToolStripMenuItem.Click

        Dim myForm As New frmPpalEtiquetasAparador

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized

        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub BitácoraDeProcesosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BitácoraDeProcesosToolStripMenuItem.Click
        If GLB_IdPuestoEmpleado = 18 Or GLB_Idempleado = 132 Or GLB_Usuario = "FELIXJ" Or GLB_Usuario = "FELIX" Or GLB_Usuario = "LORIS" Then
            Dim myForm As New frmPpalBitProcesos

            myForm.MdiParent = Me
            myForm.Opcion = 1
            myForm.WindowState = FormWindowState.Maximized
            myForm.Show()
            myForm.Refresh()
        End If
    End Sub

    Private Sub LiquidaciónAutomáticaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LiquidaciónAutomáticaToolStripMenuItem.Click
        If pub_TienePermiso("LIQAUT") = False Then Exit Sub
        Dim myForm As New frmPpalLiqAutomatica

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Opcion = 1
        myForm.OpcionSP = 1
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ListadoOfertasPorLiquidaciónAutomáticaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoOfertasPorLiquidaciónAutomáticaToolStripMenuItem.Click
        ' If pub_TienePermiso("AUTTDAS") = False Then Exit Sub
        Dim myForm As New frmPpalLiqAutomaticaTdas

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Opcion = 1
        myForm.OpcionSP = 1
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub NuevoResurtidoAutomáticoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoResurtidoAutomáticoToolStripMenuItem.Click
        If pub_TienePermiso("REAUT") = False Then Exit Sub
        Dim myForm As New frmPpalResurtidoTmp

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Opcion = 1
        myForm.OpcionSP = 1
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub DetalladoDePreciosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetalladoDePreciosToolStripMenuItem.Click
        If pub_TienePermiso("DETPRE") = False Then Exit Sub
        Dim myForm As New frmPpalPreciosDet
        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub CambioCajeroToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CambioCajeroToolStripMenuItem.Click
        'mreyes 09/Junio/2012 01:09 p.m.
        If pub_TienePermiso("ABCCAJ") = False Then Exit Sub
        Dim myForm As New frmPpalCambiarCajero
        myForm.WindowState = FormWindowState.Maximized
        myForm.MdiParent = Me
        myForm.Show()
    End Sub

    Private Sub ToolStripButton9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton9.Click
        ' If pub_TienePermiso("APARADO") = False Then Exit Sub
        Dim myForm As New frmPpalDineroElectronico

        myForm.WindowState = FormWindowState.Maximized
        myForm.MdiParent = Me
        myForm.Show()
    End Sub

    Private Sub SalidaTraspasoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalidaTraspasoToolStripMenuItem.Click
        Try
            Dim myForm As New frmSalidaTraspasos

            myForm.Opcion = 2
            myForm.Accion = 1


            myForm.Txt_IdMov1.Text = GLB_Idempleado

            myForm.Txt_IdMov2.Text = GLB_Idempleado


            myForm.ShowDialog()


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub PedidoDeBodegaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PedidoDeBodegaToolStripMenuItem.Click
        Dim myForm As New frmPedidoBodega
        myForm.Sw_Menu = True
        myForm.WindowState = FormWindowState.Maximized
        myForm.MdiParent = Me
        myForm.Accion = 2

        myForm.Show()
    End Sub

    Private Sub ToolStripTextBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TSSSplit_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub usp_TraerMenspaga()
        'mreyes 12/Abril/2018   05:04 p.m.
        Try
            Dim objDataSet As Data.DataSet
            Using objTrasp As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                objDataSet = objTrasp.usp_TraerMenspaga()

                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Glb_Mensaje = objDataSet.Tables(0).Rows(0).Item("registro").ToString
                    Glb_Mensaje1 = objDataSet.Tables(0).Rows(1).Item("registro").ToString
                    Glb_Mensaje2 = objDataSet.Tables(0).Rows(2).Item("registro").ToString
                    Glb_Mensaje3 = objDataSet.Tables(0).Rows(3).Item("registro").ToString
                    Glb_Mensaje4 = objDataSet.Tables(0).Rows(4).Item("registro").ToString

                End If

            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Temporizador_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Temporizador.Tick
        'mreyes 30/Enero/2017   05:06 p.m.
        If GLB_Emergente = True Then Exit Sub
        If GLB_FormPedidoBodega = True Then Exit Sub
        If GLB_FormPuntoVenta = True Then Exit Sub

        GLB_FechaHoy = pub_TraerFechaHoy()


        Dim objDataSet As Data.DataSet
        GLB_OpcionEme = 0
        Try
            If Val(GLB_CveSucursal) < 11 And GLB_CveSucursal <> "" Then

                Using objTrasp As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)



                    objDataSet = objTrasp.usp_TraspasoEnLinea(GLB_CveSucursal)

                    'Populate the Project Details section
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        GLB_OpcionEme = 5
                        Dim myForm As New frmEmergente
                        myForm.Txt_Leyenda.Text = "Tiene " & objDataSet.Tables(0).Rows(0).Item("traspaso").ToString & " Traspasos para VENTA EN LÍNEA pendientes de DAR SALIDA"
                        myForm.Show()
                        'While myForm.Opacity > 0
                        '    myForm.Opacity -= 0.001
                        'End While


                        'myForm.Dispose()
                        'myForm.Close()
                        Exit Sub
                    End If

                End Using



                ''Using objTrasp As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)



                ''    objDataSet = objTrasp.usp_TraspasoEnLineaSalida(GLB_CveSucursal)

                ''    'Populate the Project Details section
                ''    If objDataSet.Tables(0).Rows.Count > 0 Then
                ''        GLB_OpcionEme = 5
                ''        Dim myForm As New frmEmergente
                ''        myForm.Txt_Leyenda.Text = "Tiene Traspasos para VENTA EN LÍNEA pendientes de DAR SALIDA"
                ''        myForm.Show()
                ''        'While myForm.Opacity > 0
                ''        '    myForm.Opacity -= 0.001
                ''        'End While


                ''        'myForm.Dispose()
                ''        'myForm.Close()
                ''        Exit Sub
                ''    End If

                ''End Using


                '' CHECAR SI HAY TRASPASOS.. 
                'InicializaGrid()
                Using objTrasp As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)


                    ' Me.Cursor = Cursors.WaitCursor
                    'DGrid.ReadOnly = True


                    objDataSet = objTrasp.usp_PpalProTrasp(1, 0, GLB_CveSucursal, "1900-01-01", "1900-01-01", "GE")

                    'Populate the Project Details section
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        GLB_OpcionEme = 1
                        Dim myForm As New frmEmergente
                        myForm.Show()
                        'While myForm.Opacity > 0
                        '    myForm.Opacity -= 0.001
                        'End While


                        'myForm.Dispose()
                        'myForm.Close()
                    End If

                End Using



                '' CHECAR SI HAY TRASPASOS enl inea urgentes.. 
                'InicializaGrid()


                '' CHECAR SI HAY LIQUIDACIOÓN

                '''''Using objTrasp As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)

                '''''    Try



                '''''        objDataSet = objTrasp.usp_PpalLiqAutomaticaTdas(1, GLB_CveSucursal, GLB_FechaHoy)

                '''''        'Populate the Project Details section
                '''''        If objDataSet.Tables(0).Rows.Count > 0 Then
                '''''            'Populate the Project Details section 
                '''''            'DGrid.ColumnCount = objDataSet.Tables(0).Columns.Count
                '''''            If (TimeOfDay > "08:00:00" And TimeOfDay < "10:00:00") Then
                '''''                GLB_OpcionEme = 4
                '''''                Dim myForm As New frmEmergente
                '''''                myForm.Txt_Leyenda.Text = "Hoy inicia una LIQUIDACIÓN AUTOMÁTICA"
                '''''                myForm.Show()
                '''''            End If



                '''''        End If

                '''''    Catch ExceptionErr As Exception
                '''''        MessageBox.Show(ExceptionErr.Message.ToString)
                '''''    End Try
                '''''End Using

                '' TERMINA LIQUIDACIÓN




            ElseIf GLB_Idempleado = 99 Then
                ''-- VIRI
                Using objTrasp As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)


                    objDataSet = objTrasp.usp_PpalProTraspDetNoAplica(0)

                    'Populate the Project Details section
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        GLB_OpcionEme = 2
                        Dim myForm As New frmEmergente
                        myForm.Txt_Leyenda.Text = "Tiene pendiente de revisar Modelos no traspasados."


                        myForm.Show()
                    End If
                End Using
            ElseIf GLB_Idempleado = 1033 Then
                If Weekday(GLB_FechaHoy) = 3 Then
                    If (TimeOfDay > "09:00:00" And TimeOfDay < "10:00:00") Or (TimeOfDay > "16:00:00" And TimeOfDay < "17:00:00") Then


                        GLB_OpcionEme = 3
                        Dim myForm As New frmEmergente
                        myForm.Txt_Leyenda.Text = "Tiene pendiente seguimiento a Resurtidos Automáticos."


                        myForm.Show()

                    End If
                End If

            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub TmrClock_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmrClock.Tick

    End Sub

    Private Sub NegadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NegadosToolStripMenuItem.Click
        If pub_TienePermiso("NEGBOD") = False Then Exit Sub
        Dim myForm As New frmPpalNegBodega

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub AnálisisDeMarcasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PrevioTimbradoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrevioTimbradoToolStripMenuItem.Click
        If pub_TienePermiso("TIMBRA") = False Then Exit Sub
        Dim myForm As New frmGeneraTimbradovb

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Normal
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SalidasDeInventarioToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ReporteNoVendidosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteNoVendidosToolStripMenuItem.Click
        If pub_TienePermiso("NEGBOD") = False Then Exit Sub
        Dim myForm As New frmPpalPedBodega

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ToolStripButton2_Click_1(sender As Object, e As EventArgs)
        frmCatalogoSegPedidos.Show()
    End Sub

    Private Sub ToolStripMenuItem21_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem21.Click
        If pub_TienePermiso("VALNEG") = False Then Exit Sub

        Dim myForm As New frmPpalDiarioVales


        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ReciboPorRangosYExistenciaActualToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReciboPorRangosYExistenciaActualToolStripMenuItem.Click
        If pub_TienePermiso("RECEXI") = False Then Exit Sub
        Dim myForm As New frmPpalEstrYExistActual

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub DíasDeRespuestaDelProveedorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DíasDeRespuestaDelProveedorToolStripMenuItem.Click
        If pub_TienePermiso("DIASRESP") = False Then Exit Sub
        Dim myForm As New frmPpalDiasResProv
        myForm.WindowState = FormWindowState.Maximized
        myForm.MdiParent = Me
        myForm.Show()
    End Sub

    Private Sub VentasPorMesDistribuidoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentasPorMesDistribuidoresToolStripMenuItem.Click
        If pub_TienePermiso("VTADME") = False Then Exit Sub

        Dim myForm As New frmPpalVentaXmesDistr


        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub SobranteDeInventarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SobranteDeInventarioToolStripMenuItem.Click
        If pub_TienePermiso("SOBINV") = False Then Exit Sub

        Dim myForm As New frmPpalSobranteInv

        myForm.MdiParent = Me

        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub TraspasosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles TraspasosToolStripMenuItem1.Click
        If pub_TienePermiso("PPTRA") = False Then Exit Sub

        Dim myForm As New frmPpalTraspasosResyEnv

        myForm.MdiParent = Me

        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub CurvaIdealToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CurvaIdealToolStripMenuItem.Click
        If pub_TienePermiso("NEGBOD") = False Then Exit Sub
        Dim myForm As New frmPpalCurvaIdeal

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ToolStripMenuItem29_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem29.Click
        If pub_TienePermiso("NEGBOD") = False Then Exit Sub
        Dim myForm As New frmPpalNoPedidos

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub RebajaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RebajaToolStripMenuItem.Click
        If pub_TienePermiso("REBAJA") = False Then Exit Sub
        Dim myForm As New frmPpalRebaja
        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub LimitesDeCréditoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LimitesDeCréditoToolStripMenuItem.Click
        If pub_TienePermiso("LIMCRED") = False Then Exit Sub
        Dim myForm As New frmPpalDistribLimites

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Opcion = 1
        myForm.OpcionSP = 1
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub CobranzaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CobranzaToolStripMenuItem.Click
        'If pub_TienePermiso("COBVENC") = False Then Exit Sub
        'Dim myForm As New frmPpalVencido

        'myForm.MdiParent = Me
        'myForm.WindowState = FormWindowState.Maximized
        'myForm.Opcion = 1
        'myForm.OpcionSP = 1
        'myForm.Show()
        'myForm.Refresh()
    End Sub

    Private Sub ListadoDeSaldosVencidosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListadoDeSaldosVencidosToolStripMenuItem.Click
        If pub_TienePermiso("COBVENC") = False Then Exit Sub
        Dim myForm As New frmPpalVencidosDias

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized

        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub DescuentosDeVentaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DescuentosDeVentaToolStripMenuItem.Click
        ' If pub_TienePermiso("COBVENC") = False Then Exit Sub
        Dim myForm As New frmPpalDescuentosXMes

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized

        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub CostoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CostoToolStripMenuItem.Click
        If pub_TienePermiso("COSTO") = False Then Exit Sub
        Dim myForm As New frmPpalCostoMargen

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub BitácoraDeProveedorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BitácoraDeProveedorToolStripMenuItem.Click
        If pub_TienePermiso("ABCPROVE") = False Then Exit Sub
        Dim myForm As New frmppalproveeBita

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub NuevaMacaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevaMacaToolStripMenuItem.Click
        If pub_TienePermiso("ABCPROVE") = False Then Exit Sub
        Dim myForm As New frmCatalogoMuestras

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ProyecciónDeComprasL1ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProyecciónDeComprasL1ToolStripMenuItem.Click
        If pub_TienePermiso("COSTO") = False Then Exit Sub
        Dim myForm As New frmPpalProyeccionComprasL1

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub PpalMuestrasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PpalMuestrasToolStripMenuItem.Click
        If pub_TienePermiso("ABCPROVE") = False Then Exit Sub
        Dim myForm As New frmPpalMuestras

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub MuestrasCompletasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MuestrasCompletasToolStripMenuItem.Click
        If pub_TienePermiso("ABCPROVE") = False Then Exit Sub
        Dim myForm As New frmCatalogoMuestrasCompleto


        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Text = "Muestras Completas"
        myForm.EstatusB = "ES"
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub MuestrasRevisadasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MuestrasRevisadasToolStripMenuItem.Click
        If pub_TienePermiso("ABCPROVE") = False Then Exit Sub
        Dim myForm As New frmCatalogoMuestrasCompleto


        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Text = "Muestras a Revisión"
        myForm.EstatusB = "RE"
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub MuestrasCanceladasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MuestrasCanceladasToolStripMenuItem.Click
        If pub_TienePermiso("ABCPROVE") = False Then Exit Sub
        Dim myForm As New frmCatalogoMuestrasCompleto


        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Text = "Muestras Canceladas"
        myForm.EstatusB = "ZC"
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ReporteDeGestoríaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeGestoríaToolStripMenuItem.Click
        If pub_TienePermiso("REPGESTO") = False Then Exit Sub
        Dim myForm As New frmPpalGestoria

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized

        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ReporteDeCallCenterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeCallCenterToolStripMenuItem.Click
        If pub_TienePermiso("CALLCEN") = False Then Exit Sub
        Dim myForm As New frmPpalCallCenterAdmon

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized

        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ToolStripButton10_Click(sender As Object, e As EventArgs) Handles TsCallCenter.Click
        If pub_TienePermiso("CALLCEN") = False Then Exit Sub
        Dim myForm As New frmPpalCallCenter

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized

        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ToolStripButton10_Click_1(sender As Object, e As EventArgs)
        If pub_TienePermiso("VTASDE") = False Then Exit Sub

        Dim myForm As New frmPpalVentasDistribuidores


        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ReporteDeVencdidoToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If pub_TienePermiso("REPVENC") = False Then Exit Sub
        Dim myForm As New frmPpalVencido

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized

        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub AsignaciónDeVencidoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsignaciónDeVencidoToolStripMenuItem.Click
        If pub_TienePermiso("REPVENC") = False Then Exit Sub
        Dim myForm As New frmPpalVencido

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized

        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub CarteraVencidoPorGestorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CarteraVencidoPorGestorToolStripMenuItem.Click
        If pub_TienePermiso("REPVENC") = False Then Exit Sub
        Dim myForm As New frmPpalVencidoGestor

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized

        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ReporteDePagosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDePagosToolStripMenuItem.Click


        If pub_TienePermiso("REPPAG") = False Then Exit Sub
        Dim myForm As New frmPpalPagosDistribuidor
        myForm.Opcion = 1
        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized

        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ToolStripMenuItem37_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem37.Click

        If pub_TienePermiso("COMISI") = False Then Exit Sub
        Dim myForm As New frmPpalComisionesCarteraVencida

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized

        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub BitácoraNoUsoPedidoDeBodegaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BitácoraNoUsoPedidoDeBodegaToolStripMenuItem.Click


        If pub_TienePermiso("PEDBOD") = False Then Exit Sub
        Dim myForm As New frmPpalBitacoraPedBod

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized

        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ConsultaVentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaVentasToolStripMenuItem.Click
        If pub_TienePermiso("APENDI") = False Then Exit Sub
        Dim myForm As New frmVentasFiscal

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Normal
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ApéndiceFiscalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApéndiceFiscalToolStripMenuItem.Click
        If pub_TienePermiso("APENDI") = False Then Exit Sub
        Dim myForm As New frmApendiceSql

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Normal
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ComparativaVentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComparativaVentasToolStripMenuItem.Click
        If pub_TienePermiso("APENDI") = False Then Exit Sub
        Dim myForm As New frmPpalVentasFiscal

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ToolStripMenuItem39_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub EstadoDeCarteraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EstadoDeCarteraToolStripMenuItem.Click
        If pub_TienePermiso("EDOCAR") = False Then Exit Sub
        Dim myForm As New frmPpalEstadoCarteraNew

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub TipoCréditoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TipoCréditoToolStripMenuItem.Click
        If pub_TienePermiso("TIPCRE") = False Then Exit Sub
        Dim myForm As New frmPpalTipoCredito

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub TipoViviendaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TipoViviendaToolStripMenuItem.Click
        'If pub_TienePermiso("TIPVIV") = False Then Exit Sub
        'Dim myForm As New frmPpalTipoVivenda

        'myForm.MdiParent = Me
        'myForm.WindowState = FormWindowState.Maximized
        'myForm.Show()
        'myForm.Refresh()
    End Sub

    Private Sub CódigosPostalesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CódigosPostalesToolStripMenuItem.Click
        If pub_TienePermiso("LAYCP") = False Then Exit Sub
        Dim myForm As New frmLayoutCP

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Normal
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub AbogadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbogadosToolStripMenuItem.Click
        If pub_TienePermiso("CATABO") = False Then Exit Sub
        Dim myForm As New frmPpalAbogados
        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub GestoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GestoresToolStripMenuItem.Click
        If pub_TienePermiso("CATGEST") = False Then Exit Sub
        Dim myForm As New frmPpalGestoresDeCartera
        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub PromotoresExternosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PromotoresExternosToolStripMenuItem.Click
        If pub_TienePermiso("PROMOEX") = False Then Exit Sub
        Dim myForm As New frmPpalPromotorExterno
        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub FirmasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FirmasToolStripMenuItem.Click
        If pub_TienePermiso("LAYCP") = False Then Exit Sub
        Dim myForm As New frmCargarFirmasDistrib

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Normal
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub AsignaciónDeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsignaciónDeToolStripMenuItem.Click
        If pub_TienePermiso("VTPER") = False Then Exit Sub
        Dim myForm As New frmPpalUsuario

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub PendientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PendientesToolStripMenuItem.Click
        If pub_TienePermiso("VTPTE") = False Then Exit Sub
        Dim myForm As New frmPpalPendientes

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub EntregaDeRelacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EntregaDeRelacionesToolStripMenuItem.Click
        If pub_TienePermiso("EREL") = False Then Exit Sub
        Dim myForm As New frmPpalRelaciones

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ParesÚnicosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ParesÚnicosToolStripMenuItem.Click
        Dim myForm As New frmPpalParesUnicos

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        If pub_TienePermiso("EREL") = False Then Exit Sub
        Dim myForm As New frmPpalRelaciones

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ReporteDeBonoSemanalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeBonoSemanalToolStripMenuItem.Click
        If Val(GLB_CveSucursal) > 0 And Val(GLB_CveSucursal) < 20 Then
            If TimeOfDay >= "08:00:00" And TimeOfDay < "19:00:00" Then
                MsgBox("El horario para acceso a reporte es después de las 19:00 hrs.", MsgBoxStyle.Information, "Aviso")
                Exit Sub
            End If
        End If

        If pub_TienePermiso("BONOS") = False Then Exit Sub
        Dim myForm As New frmPpalBonoSemanal

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub TarjetaHabientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TarjetaHabientesToolStripMenuItem.Click
        If pub_TienePermiso("CATDIS") = False Then Exit Sub

        Dim myForm As New frmPpalCatalogoDistrib
        myForm.TipoCatalogo = 1

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ToolStripMenuItem38_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem38.Click
        If pub_TienePermiso("TICKPR") = False Then Exit Sub
        Dim myForm As New frmPpalTicketPromedio

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized

        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ActualizaReciboToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualizaReciboToolStripMenuItem.Click
        If pub_TienePermiso("ACTSQL1") = False Then Exit Sub
        Dim myForm As New frmActualizaSql

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Normal
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub QuitarDeParesUnicosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitarDeParesUnicosToolStripMenuItem.Click
        If pub_TienePermiso("ACTSQL") = False Then Exit Sub
        Dim myForm As New frmQuitarParesUnicos

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Normal
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ModificarCargoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificarCargoToolStripMenuItem.Click
        If pub_TienePermiso("MODCARGO") = False Then Exit Sub
        Dim myForm As New frmModificarCargo

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        If pub_TienePermiso("MODCARGO") = False Then Exit Sub
        Dim myForm As New frmPpalCajaCredito

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub AutorizarVentaElectrónicaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutorizarVentaElectrónicaToolStripMenuItem.Click
        If pub_TienePermiso("MODCARGO") = False Then Exit Sub
        Dim myForm As New frmAutorizaElectronica

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized

        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub RevisarNotaDeVentaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RevisarNotaDeVentaToolStripMenuItem.Click
        If pub_TienePermiso("MODCARGO") = False Then Exit Sub
        Dim myForm As New frmModificarCargo

        myForm.MdiParent = Me
        Me.Text = "Revisión Nota de Venta"
        myForm.WindowState = FormWindowState.Normal
        myForm.MaximizeBox = False
        myForm.Height = 448
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub CorteDeCajaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CorteDeCajaToolStripMenuItem.Click
        If pub_TienePermiso("CORCRE") = False Then Exit Sub
        Dim myForm As New frmCorteCredito

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub BAsicosToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BasicosToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles BasicosToolStripMenuItem.Click
        If pub_TienePermiso("BASICO") = False Then Exit Sub
        Dim myForm As New frmCatalogoBasicos

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub AparadorRealToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AparadorRealToolStripMenuItem.Click
        If pub_TienePermiso("APARADO") = False Then Exit Sub

        Dim myForm As New frmPpalAparadorReal
        myForm.Accion = 2
        myForm.WindowState = FormWindowState.Maximized
        myForm.MdiParent = Me
        myForm.Show()
    End Sub

    Private Sub MatchEstructuraVsAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MatchEstructuraVsAToolStripMenuItem.Click
        If pub_TienePermiso("APARADO") = False Then Exit Sub
        Dim myForm As New frmPpalMathAparador
        myForm.Accion = 2
        myForm.WindowState = FormWindowState.Maximized
        myForm.MdiParent = Me
        myForm.Show()
    End Sub

    Private Sub ToolStripMenuItem15_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ReciboDeBultoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReciboDeBultoToolStripMenuItem.Click
        If pub_TienePermiso("RECBU1") = False Then Exit Sub
        '        Dim myForm As New frmPpalReciboBultos
        Dim myForm As New frmPpalBultosDet

        myForm.MdiParent = Me
        myForm.Opcion = 2
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ExistenciaPorLineaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExistenciaPorLineaToolStripMenuItem.Click
        If pub_TienePermiso("EXIXLI") = False Then Exit Sub
        '        Dim myForm As New frmPpalReciboBultos
        Dim myForm As New frmPpalControlAparador

        myForm.MdiParent = Me

        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ToolStripButton2_Click_2(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        If pub_TienePermiso("PVENTA") = False Then Exit Sub

        Dim myForm As New frmPuntoVenta
        GLB_FormPuntoVenta = True
        myForm.MdiParent = Me

        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()



    End Sub

    Private Sub ControlDeAparadorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ControlDeAparadorToolStripMenuItem.Click
        If pub_TienePermiso("CTRLAP") = False Then Exit Sub
        '        Dim myForm As New frmPpalReciboBultos
        Dim myForm As New frmPpalControlAparador

        myForm.MdiParent = Me

        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub NegadosPropuestaVendidosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NegadosPropuestaVendidosToolStripMenuItem.Click

        If pub_TienePermiso("PEDBOD") = False Then Exit Sub
        Dim myForm As New frmPpalNegPropuestaVendido

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized

        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub EstadísticaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EstadísticaToolStripMenuItem.Click
        If pub_TienePermiso("ESTADI") = False Then Exit Sub
        Dim myForm As New frmRepVentas

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub CapturaPresupuestoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CapturaPresupuestoToolStripMenuItem.Click
        If pub_TienePermiso("ESTADI") = False Then Exit Sub
        Dim myForm As New frmPpalPresupuesto

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub CatPresupuestoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CatPresupuestoToolStripMenuItem.Click
        If pub_TienePermiso("ESTADI") = False Then Exit Sub
        Dim myForm As New frmCatPresupuesto

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub VentasToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles VentasToolStripMenuItem1.Click
        If pub_TienePermiso("VTALINEA") = False Then Exit Sub
        Dim myForm As New frmPpalVentasenLinea

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub PrevioVentaAnualToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrevioVentaAnualToolStripMenuItem.Click
        If pub_TienePermiso("RECEXI") = False Then Exit Sub
        Dim myForm As New frmPpalPrevioVentaAnual

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ToolStripMenuItem22_Click_1(sender As Object, e As EventArgs) Handles ToolStripMenuItem22.Click
        If pub_TienePermiso("RECEXI") = False Then Exit Sub
        Dim myForm As New frmPpalPrevioVentaAnual

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub VentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentasToolStripMenuItem.Click

    End Sub

    Private Sub SapicaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SapicaToolStripMenuItem.Click
        If pub_TienePermiso("SAPICA") = False Then Exit Sub
        '        Dim myForm As New frmPpalReciboBultos
        Dim myForm As New frmPpalSapica

        myForm.MdiParent = Me

        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub RotaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RotaciónToolStripMenuItem.Click
        If pub_TienePermiso("ROTACION") = False Then Exit Sub
        '        Dim myForm As New frmPpalReciboBultos
        Dim myForm As New frmPpalRotacion

        myForm.MdiParent = Me

        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub PasivoDeProveedoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasivoDeProveedoresToolStripMenuItem.Click
        If pub_TienePermiso("PASIVO") = False Then Exit Sub
        '        Dim myForm As New frmPpalReciboBultos
        Dim myForm As New frmPpalPasivoProveedores

        myForm.MdiParent = Me

        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ToolStripMenuItem15_Click_1(sender As Object, e As EventArgs) Handles ToolStripMenuItem15.Click
        If pub_TienePermiso("PASIVO") = False Then Exit Sub
        '        Dim myForm As New frmPpalReciboBultos
        Dim myForm As New frmPpalPagosProveedores

        myForm.MdiParent = Me

        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ToolStripMenuItem26_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem26.Click
        If pub_TienePermiso("PASIVO") = False Then Exit Sub
        '        Dim myForm As New frmPpalReciboBultos
        Dim myForm As New usp_PpalAsigLiquidaciones

        myForm.MdiParent = Me

        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub PendientesPorRecibirAlmacenTerminadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PendientesPorRecibirAlmacenTerminadoToolStripMenuItem.Click
        If pub_TienePermiso("VTALI") = False Then Exit Sub
        Dim myForm As New frmPpalTrasPendRecibo


        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Opcion = 1
        myForm.OpcionSP = 3
        myForm.SucurOriB = "16"
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub PendientesPorRecibirAlmadenMúltiplesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PendientesPorRecibirAlmadenMúltiplesToolStripMenuItem.Click
        If pub_TienePermiso("VTALI") = False Then Exit Sub
        Dim myForm As New frmPpalTrasPendRecibo


        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Opcion = 1
        myForm.OpcionSP = 3
        myForm.SucurOriB = "17"
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ToolStripButton10_Click_2(sender As Object, e As EventArgs) Handles ToolStripButton10.Click
        If pub_TienePermiso("DESPC") = False Then Exit Sub
        Dim myForm As New frmPpalDespacho


        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub CobranzaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CobranzaToolStripMenuItem1.Click
        If pub_TienePermiso("COBRAN") = False Then Exit Sub
        Dim myForm As New frm_PpalrecuperacionCortes


        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ToolStripButton11_Click(sender As Object, e As EventArgs) Handles ToolStripButton11.Click
        If pub_TienePermiso("COBRAN") = False Then Exit Sub
        Dim myForm As New frm_PpalrecuperacionCortes


        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub LinioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LinioToolStripMenuItem.Click
        If pub_TienePermiso("LINIO") = False Then Exit Sub
        Dim myForm As New frm_Lineo


        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub SeguimientoReciboMercancíaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeguimientoReciboMercancíaToolStripMenuItem.Click
        If pub_TienePermiso("SECEDI") = False Then Exit Sub
        Dim myForm As New frmPpalSeguimientoCedis


        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub SubirUPCsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SubirUPCsToolStripMenuItem.Click


        If pub_TienePermiso("UPC") = False Then Exit Sub
        Dim myForm As New frmactualizaUPCs

        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Normal
        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ReporteDePagosXCorteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDePagosXCorteToolStripMenuItem.Click
        If pub_TienePermiso("REPPAG") = False Then Exit Sub
        Dim myForm As New frmPpalPagosDistribuidor

        myForm.Opcion = 2
        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized

        myForm.Show()
        myForm.Refresh()
    End Sub

    Private Sub ToolStripButton12_Click(sender As Object, e As EventArgs) Handles ToolStripButton12.Click
        If pub_TienePermiso("ANFULL") = False Then Exit Sub
        Dim myForm As New frmAnalisisfull
        myForm.WindowState = FormWindowState.Maximized

        myForm.MdiParent = Me
        myForm.Show()
    End Sub

    Private Sub ComprasToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ComprasToolStripMenuItem1.Click

    End Sub

    Private Sub PruebasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PruebasToolStripMenuItem.Click
        Dim myForm As New frm_PpalrecuperacionCortes
        myForm.MdiParent = Me
        myForm.WindowState = FormWindowState.Maximized
        myForm.Show()
        myForm.Refresh()
    End Sub
End Class
