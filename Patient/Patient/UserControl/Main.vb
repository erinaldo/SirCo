Imports System.Data

Public Class Main
    Dim objDataSet As DataSet
    'Dim objClinic As BCL.BCLClinic
    

    Private Sub Main_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'LoadClinicByContactDate(Now.Date)
        Me.Dock = DockStyle.Fill

        LblVersion.Text = "Version " & Application.ProductVersion.ToString
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

        System.Diagnostics.Process.Start("http://zapateriastorreon.com/")
        'using the start method of system.diagnostics.process class
        'process class gives access to local and remote processes
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Dim proceso As New System.Diagnostics.Process

        With proceso
            .StartInfo.FileName = "http://www.facebook.com/zapateriastorreon"
            .Start()
        End With
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Dim proceso As New System.Diagnostics.Process

        With proceso
            .StartInfo.FileName = "http://twitter.com/ZapaTorreon"
            .Start()
        End With
    End Sub
End Class
