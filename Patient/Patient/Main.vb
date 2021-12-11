
Public Class BonoMain
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

        'Recenter PictureBox control
        'imgGrabbarHandle.Location = New Point( _
        '    (pnlGrabbar.Size.Width - imgGrabbarHandle.Size.Width) \ 2, _
        '    (pnlGrabbar.Size.Height - imgGrabbarHandle.Size.Height) \ 2)
    End Sub
#End Region

#Region " Load Procedures "

    Private Sub ZapateriaMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MessageBox.Show("Estas seguro de salir ?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            Me.Dispose()
            Me.Close()
            End
        End If
    End Sub

    Private Sub ObtenReloj(ByVal fecini As Date, ByVal fecfin As Date)
        Using objChecadas As New BCL.BCLChecadas(G_ConString)
            Try
                'Get the specific project selected in the ListView control
                objChecadas.ObTenReloj(fecini, fecfin)

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub Admin_Load(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        Call ObtenReloj(Now(), Now())

        'Add handlers for shortcut Panel controls MouseEnter event
        'AddHandler pnlNavPatients.MouseEnter, AddressOf NavigationPanel_MouseEnter
        ''AddHandler pnlNavClinic.MouseEnter, AddressOf NavigationPanel_MouseEnter
        'AddHandler pnlNavUsers.MouseEnter, AddressOf NavigationPanel_MouseEnter
        'AddHandler pnlNavDoctor.MouseEnter, AddressOf NavigationPanel_MouseEnter
        'AddHandler pnlNavSection.MouseEnter, AddressOf NavigationPanel_MouseEnter

        ''Add handlers for shortcut Panel controls MouseLeave event
        'AddHandler pnlNavPatients.MouseLeave, AddressOf NavigationPanel_MouseLeave
        ''AddHandler pnlNavClinic.MouseLeave, AddressOf NavigationPanel_MouseLeave
        'AddHandler pnlNavUsers.MouseLeave, AddressOf NavigationPanel_MouseLeave
        'AddHandler pnlNavDoctor.MouseLeave, AddressOf NavigationPanel_MouseLeave
        'AddHandler pnlNavSection.MouseLeave, AddressOf NavigationPanel_MouseLeave


        ''Add handlers for shortcut Panel controls MouseUp event
        'AddHandler pnlNavPatients.MouseUp, AddressOf NavigationPanel_MouseUp
        ''AddHandler pnlNavClinic.MouseUp, AddressOf NavigationPanel_MouseUp
        'AddHandler pnlNavUsers.MouseUp, AddressOf NavigationPanel_MouseUp
        'AddHandler pnlNavDoctor.MouseUp, AddressOf NavigationPanel_MouseUp
        'AddHandler pnlNavSection.MouseUp, AddressOf NavigationPanel_MouseUp

        ''Add handlers for shortcut Label controls MouseEnter event
        'AddHandler lblProjects.MouseEnter, _
        '    AddressOf NavigationChildControl_MouseEnter
        ''AddHandler lblGroups.MouseEnter, _
        ''    AddressOf NavigationChildControl_MouseEnter

        'AddHandler lblUsers.MouseEnter, AddressOf NavigationChildControl_MouseEnter
        'AddHandler lblDoctor.MouseEnter, AddressOf NavigationChildControl_MouseEnter
        'AddHandler lblSection.MouseEnter, AddressOf NavigationChildControl_MouseEnter

        ''Add handlers for shortcut Label controls MouseLeave event
        'AddHandler lblProjects.MouseLeave, _
        '    AddressOf NavigationChildControl_MouseLeave
        ''AddHandler lblGroups.MouseLeave, _
        ''    AddressOf NavigationChildControl_MouseLeave

        'AddHandler lblUsers.MouseLeave, AddressOf NavigationChildControl_MouseLeave
        'AddHandler lblDoctor.MouseLeave, AddressOf NavigationChildControl_MouseLeave
        'AddHandler lblSection.MouseLeave, AddressOf NavigationChildControl_MouseLeave

        ''Add handlers for shortcut Label controls MouseUp event
        'AddHandler lblProjects.MouseUp, AddressOf NavigationChildControl_MouseUp
        ''AddHandler lblGroups.MouseUp, AddressOf NavigationChildControl_MouseUp

        'AddHandler lblUsers.MouseUp, AddressOf NavigationChildControl_MouseUp
        'AddHandler lblDoctor.MouseUp, AddressOf NavigationChildControl_MouseUp
        'AddHandler lblSection.MouseUp, AddressOf NavigationChildControl_MouseUp

        ''Add handlers for shortcut PictureBox controls MouseEnter event
        'AddHandler imgProjects.MouseEnter, _
        '    AddressOf NavigationChildControl_MouseEnter
        ''AddHandler imgGroups.MouseEnter, _
        ''    AddressOf NavigationChildControl_MouseEnter

        'AddHandler imgUsers.MouseEnter, AddressOf NavigationChildControl_MouseEnter
        'AddHandler imgDoctor.MouseEnter, AddressOf NavigationChildControl_MouseEnter
        'AddHandler imgSection.MouseEnter, AddressOf NavigationChildControl_MouseEnter

        ''Add handlers for shortcut PictureBox controls MouseLeave event
        'AddHandler imgProjects.MouseLeave, _
        '    AddressOf NavigationChildControl_MouseLeave
        ''AddHandler imgGroups.MouseLeave, _
        ''    AddressOf NavigationChildControl_MouseLeave

        'AddHandler imgUsers.MouseLeave, AddressOf NavigationChildControl_MouseLeave
        'AddHandler imgDoctor.MouseLeave, AddressOf NavigationChildControl_MouseLeave
        'AddHandler imgSection.MouseLeave, AddressOf NavigationChildControl_MouseLeave

        ''Add handlers for shortcut PictureBox controls MouseUp event
        'AddHandler imgProjects.MouseUp, AddressOf NavigationChildControl_MouseUp
        ''AddHandler imgGroups.MouseUp, AddressOf NavigationChildControl_MouseUp

        'AddHandler imgUsers.MouseUp, AddressOf NavigationChildControl_MouseUp
        'AddHandler imgDoctor.MouseUp, AddressOf NavigationChildControl_MouseUp
        'AddHandler imgSection.MouseUp, AddressOf NavigationChildControl_MouseUp

        'Set the current date in the date panel in the status bar

        'Get the applicataion title
        strAppTitle = My.Application.Info.Title

        Dim myMain As New Main
        pnlMain.Controls.Clear()
        pnlMain.Controls.Add(myMain)
    End Sub

#End Region

    Private Sub TextShow()
        'If Test = "Patients" Then
        '    strActiveScreen = "Patients"
        '    lblCurrentScreen.Text = "Empleados"
        '    lblAllScreens.Text = "Todos " & "Empleados"
        '    imgScreen.Image = imgProjects.Image
        '    lblScreen.Text = "Empleados"
        'ElseIf Test = "Clinic" Then
        '    strActiveScreen = "Clinic"
        '    lblCurrentScreen.Text = "Clinic"
        '    lblAllScreens.Text = "All " & "Clinic"
        '    'imgScreen.Image = imgClinic.Image
        '    lblScreen.Text = "Clinic"
        'ElseIf Test = "Users" Then
        '    strActiveScreen = "Users"
        '    lblCurrentScreen.Text = "Usuarios"
        '    lblAllScreens.Text = "Todos " & "Usuarios"
        '    imgScreen.Image = imgUsers.Image
        '    lblScreen.Text = "Usuarios"
        'ElseIf Test = "Doctor" Then
        '    strActiveScreen = "Puestos"
        '    lblCurrentScreen.Text = "Puestos"
        '    lblAllScreens.Text = "Todos " & "Puestos"
        '    'imgScreen.Image = imgClinic.Image
        '    lblScreen.Text = "Puestos"
        'ElseIf Test = "Section" Then
        '    strActiveScreen = "Departamento"
        '    lblCurrentScreen.Text = "Dapartamento"
        '    lblAllScreens.Text = "Todos " & "Departamentos"
        '    imgScreen.Image = imgUsers.Image
        '    lblScreen.Text = "Departamento"
        'End If
    End Sub
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        If MessageBox.Show("Estas seguro de salir ?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            Me.Dispose()
            Me.Close()
            End
        End If

    End Sub

    'Private Sub PatientClinicToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim myClinicList As New ClinicList
    '    pnlMain.Controls.Clear()
    '    pnlMain.Controls.Add(myClinicList)
    'End Sub

    Private Sub PatientToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim myPatientList As New EmpleadoList
        'pnlMain.Controls.Clear()
        'pnlMain.Controls.Add(myPatientList)
    End Sub

    Private Sub ChangeLoginToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeLoginToolStripMenuItem.Click
        'Me.Close()
        'LoginForm1.ShowDialog()
        Dim facceso As New LoginForm1
        If facceso.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            facceso.Close()
            facceso.Dispose()
            '  Me.ShowDialog()
        End If
        'LoginForm1.Close()
        'Me.Close()
        'Me.Dispose()

    End Sub

    Private Sub AboutSoftwareToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutSoftwareToolStripMenuItem.Click
        Dim myAbout As New frmAbout
        myAbout.ShowDialog()
    End Sub

    Private Sub DoctorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim myDoctoryList As New DoctorList
        'pnlMain.Controls.Clear()
        'pnlMain.Controls.Add(myDoctoryList)
    End Sub

    Private Sub SectionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim mySectionList As New SectionList
        'pnlMain.Controls.Clear()
        'pnlMain.Controls.Add(mySectionList)
    End Sub

    Private Sub UsersToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim myUserList As New UserList
        'pnlMain.Controls.Clear()
        'pnlMain.Controls.Add(myUserList)
    End Sub

    'Private Sub pnlNavPatients_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlNavPatients.Click, PatientToolStripMenuItem.Click
    '    Test = ""
    '    Test = "Patients"
    '    Call TextShow()
    '    Dim myCurrentModulesPatients As New CurrentModulesPatients
    '    pnlCurrentModules.Controls.Clear()
    '    pnlCurrentModules.Controls.Add(myCurrentModulesPatients)
    '    Dim myPatientList As New EmpleadoList
    '    pnlMain.Controls.Clear()
    '    pnlMain.Controls.Add(myPatientList)
    'End Sub

    'Private Sub pnlNavDoctor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlNavDoctor.Click, DoctorToolStripMenuItem.Click
    '    Test = ""
    '    Test = "Doctor"
    '    Call TextShow()
    '    Dim myDoctorList As New DoctorList
    '    pnlMain.Controls.Clear()
    '    pnlMain.Controls.Add(myDoctorList)
    'End Sub


    'Private Sub pnlNavClinic_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PatientClinicToolStripMenuItem.Click
    '    Test = ""
    '    Test = "Clinic"
    '    Call TextShow()
    'Dim myCurrentModulesClinic As New CurrentModulesClinic
    'pnlCurrentModules.Controls.Clear()
    'pnlCurrentModules.Controls.Add(myCurrentModulesClinic)
    'Dim myClinicList As New ClinicList
    '   pnlMain.Controls.Clear()
    '   pnlMain.Controls.Add(myClinicList)
    'End Sub

    Private Sub pnlNavUsers_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UsersToolStripMenuItem.Click
        Test = ""
        Test = "Users"
        Call TextShow()
        'Dim myCurrentModulesUsers As New CurrentModulesUsers
        'pnlCurrentModules.Controls.Clear()
        'pnlCurrentModules.Controls.Add(myCurrentModulesUsers)
        Dim myUserList As New UserList
        pnlMain.Controls.Clear()
        pnlMain.Controls.Add(myUserList)
    End Sub

    'Private Sub pnlNavSection_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlNavSection.Click, SectionToolStripMenuItem.Click
    '    Test = ""
    '    Test = "Section"
    '    Call TextShow()
    '    Dim mySectionList As New SectionList
    '    pnlMain.Controls.Clear()
    '    pnlMain.Controls.Add(mySectionList)
    'End Sub

    'Private Sub CombineToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    frmPatientClinicCombine.Show()
    'End Sub

    Private Sub lblUsers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub lblProjects_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub TmrClock_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TmrClock.Tick
        Me.ToolStripStatusLabel3.Text = String.Format("{0:hh:mm:ss tt}", Date.Now)
    End Sub

    Private Sub UsuariosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim myUserList As New UserList
        pnlMain.Controls.Clear()
        pnlMain.Controls.Add(myUserList)
    End Sub

    Private Sub PuestosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PuestosToolStripMenuItem.Click
        Dim myDoctoryList As New DoctorList
        pnlMain.Controls.Clear()
        pnlMain.Controls.Add(myDoctoryList)
    End Sub

    Private Sub DepartamentosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DepartamentosToolStripMenuItem.Click
        Dim mySectionList As New SectionList
        pnlMain.Controls.Clear()
        pnlMain.Controls.Add(mySectionList)
    End Sub

    Private Sub EmpleadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmpleadosToolStripMenuItem.Click
        Dim myPatientList As New EmpleadoList
        pnlMain.Controls.Clear()
        pnlMain.Controls.Add(myPatientList)
    End Sub

    Private Sub UsuariosToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UsuariosToolStripMenuItem.Click
        Dim myUserList As New UserList
        pnlMain.Controls.Clear()
        pnlMain.Controls.Add(myUserList)
    End Sub

    Private Sub ComisionesDesempeñoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub BonosFijosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub ChecadasToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim myList As New ListaChecadas
        pnlMain.Controls.Clear()
        pnlMain.Controls.Add(myList)
    End Sub

    Private Sub NominaBonosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NominaBonosToolStripMenuItem.Click
        Dim myList As New ListaNominaBonos
        pnlMain.Controls.Clear()
        pnlMain.Controls.Add(myList)
    End Sub

    Private Sub ConceptosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CargosAEmpleadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TurnosAsistenciaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub DeduccionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub DescuentosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim myList As New ListaCargos
        pnlMain.Controls.Clear()
        pnlMain.Controls.Add(myList)
    End Sub

    Private Sub NivelesBonoFijoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub BonosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub RevisiónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim myList As New Form1
        'pnlMain.Controls.Clear()
        'pnlMain.Controls.Add(myList)
        myList.Show()
    End Sub

    Private Sub AusentismoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim myList As New ListaAusentismo
        pnlMain.Controls.Clear()
        pnlMain.Controls.Add(myList)
    End Sub

    Private Sub PremiosPuntualidadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TurnosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TurnosToolStripMenuItem.Click
        Dim myList As New ListaTurnos
        pnlMain.Controls.Clear()
        pnlMain.Controls.Add(myList)
    End Sub

    Private Sub RevisionAsistenciasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RevisionAsistenciasToolStripMenuItem.Click
        Dim myList As New ListaRevision
        pnlMain.Controls.Clear()
        pnlMain.Controls.Add(myList)
    End Sub

    Private Sub RelojChecadorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RelojChecadorToolStripMenuItem.Click
        Dim myList As New ListaChecadas
        pnlMain.Controls.Clear()
        pnlMain.Controls.Add(myList)
    End Sub

    Private Sub AusentismoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AusentismoToolStripMenuItem1.Click
        Dim myList As New ListaAusentismo
        pnlMain.Controls.Clear()
        pnlMain.Controls.Add(myList)
    End Sub

    Private Sub BosnosSeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CargosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CargosToolStripMenuItem1.Click
        Dim myList As New ListaCargos
        pnlMain.Controls.Clear()
        pnlMain.Controls.Add(myList)
    End Sub

    Private Sub DeduccionesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeduccionesToolStripMenuItem1.Click
        Dim myList As New ListaDeducciones
        pnlMain.Controls.Clear()
        pnlMain.Controls.Add(myList)
    End Sub

    Private Sub NivelesBonoFijoSemanalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PremiosSemanalesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub NivelesBonoFijoToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NivelesBonoFijoToolStripMenuItem.Click
        Dim myList As New BonoFijoList
        pnlMain.Controls.Clear()
        pnlMain.Controls.Add(myList)
    End Sub

    Private Sub MontoPremiosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MontoPremiosToolStripMenuItem.Click
        Dim myList As New ListaPremios
        pnlMain.Controls.Clear()
        pnlMain.Controls.Add(myList)
    End Sub

    Private Sub PremiosPorDeptoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PremiosPorDeptoToolStripMenuItem.Click
        Dim myUserList As New ComisionList
        pnlMain.Controls.Clear()
        pnlMain.Controls.Add(myUserList)
    End Sub

    Private Sub VentasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub DiasFestivosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DiasFestivosToolStripMenuItem.Click
        Dim myUserList As New ListaDFestivos
        pnlMain.Controls.Clear()
        pnlMain.Controls.Add(myUserList)
    End Sub

    Private Sub MetasDeptartamentoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetasDeptartamentoToolStripMenuItem.Click
        Dim myUserList As New ListaMetaBonos
        pnlMain.Controls.Clear()
        pnlMain.Controls.Add(myUserList)
    End Sub

    Private Sub MontoBonosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MontoBonosToolStripMenuItem.Click
        Dim myUserList As New ListaBonosM
        pnlMain.Controls.Clear()
        pnlMain.Controls.Add(myUserList)
    End Sub
End Class
