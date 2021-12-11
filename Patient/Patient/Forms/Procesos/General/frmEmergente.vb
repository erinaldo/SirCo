Imports System.Windows.Forms

Public Class frmEmergente


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        If GLB_OpcionEme = 1 Then
            ''' pendientes traspasos automaticos
            ''' 
            Dim myForm As New frmPpaPendientesRealizar

            myForm.MdiParent = BitacoraMain
            myForm.WindowState = FormWindowState.Maximized
            myForm.Opcion = 1
            myForm.OpcionSP = 1
            myForm.Show()
            myForm.Refresh()
        End If
        If GLB_OpcionEme = 2 Then


            Dim myForm As New frmPpalModelosNoTraspasados

            myForm.MdiParent = Me
            myForm.WindowState = FormWindowState.Maximized
            myForm.Opcion = 1
            myForm.OpcionSP = 1
            myForm.Show()
            myForm.Refresh()
        End If

        If GLB_OpcionEme = 3 Then


            If pub_TienePermiso("PEDNUEVO") = False Then Exit Sub
            Dim myForm As New frmPpalPedidoNuevo

            myForm.MdiParent = Me
            myForm.WindowState = FormWindowState.Maximized
            myForm.Sw_PedidoNuevo = False
            myForm.Show()
            myForm.Refresh()
        End If
        If GLB_OpcionEme = 4 Then
            Dim myForm As New frmPpalLiqAutomaticaTdas

            myForm.MdiParent = Me
            myForm.WindowState = FormWindowState.Maximized
            myForm.Opcion = 1
            myForm.OpcionSP = 1
            myForm.Show()
            myForm.Refresh()
        End If


        If GLB_OpcionEme = 5 Then
            ''' pendientes traspasos automaticos
            ''' 
            Dim myForm As New frmPpalTraspasosManuales

            myForm.MdiParent = BitacoraMain
            myForm.WindowState = FormWindowState.Maximized
            myForm.Opcion = 1

            myForm.Show()
            myForm.Refresh()
        End If

        GLB_Emergente = False
        Me.DialogResult = System.Windows.Forms.DialogResult.OK

        Me.Close()
        Me.Dispose()

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click

        InitializeComponent()
        GLB_Emergente = False
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
        Me.Dispose()

    End Sub

    Private Sub frmEmergente_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub frmEmergente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GLB_Emergente = True
    End Sub
End Class
