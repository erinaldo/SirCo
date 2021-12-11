Public Class frmConsultaEstructura
    'mreyes 15/Febrero/2012 09:50 a.m.

    Public Tipo As String    'DI = DIVISION, D = DEPARTAMENTO, F = FAMILIA, L = LINEA, S = SUBLINEA , SS = SUBSUBLINEA, SSS = SUBSUBSUBLINEA
    'E = ESTILO
    Public IdCampo As String '' valor de regreso para el primer texto
    Public ClaveCampo As String ''valor de regreso para el segundo texto
    Public DescripCampo As String = ""

    Dim SqlBuscar As String
    Public IdSuperior1 As Integer
    Public IdSuperior2 As Integer
    Public IdSuperior3 As Integer
    Public IdSuperior4 As Integer
    Public IdSuperior5 As Integer
    Public IdSuperior6 As Integer
    Public IdSuperior7 As Integer
    Public IdSuperior8 As Integer
    Public IdSuperior9 As Integer
    Public Opcion As Integer
    Private objDataSet As Data.DataSet

    'Forma que busca en varias tablas, por lo general un id y descripción


    Private Sub RellenaGrid()
        Using objEstilos As New BCL.BCLEstructura(GLB_ConStringCipSis)
            Try
                If Tipo = "DI" Then
                    objDataSet = objEstilos.usp_TraerEstDivisiones(0, "")
                End If
                If Tipo = "D" Then
                    objDataSet = objEstilos.usp_TraerEstDepto(0, IdSuperior1, "", Opcion, Txt_Buscar.Text)
                End If
                If Tipo = "F" Then
                    objDataSet = objEstilos.usp_TraerEstFamilia(0, IdSuperior1, IdSuperior2, "", Opcion, Txt_Buscar.Text)
                End If
                If Tipo = "L" Then
                    objDataSet = objEstilos.usp_TraerEstLinea(0, IdSuperior1, IdSuperior2, IdSuperior3, "", Opcion, Txt_Buscar.Text)
                End If
                If Tipo = "S" Then
                    objDataSet = objEstilos.usp_TraerEstl1(0, IdSuperior1, IdSuperior2, IdSuperior3, IdSuperior4, "", Opcion, Txt_Buscar.Text)
                End If
                If Tipo = "SS" Then
                    objDataSet = objEstilos.usp_TraerEstl2(0, IdSuperior1, IdSuperior2, IdSuperior3, IdSuperior4, IdSuperior5, "", Opcion, Txt_Buscar.Text)
                End If
                If Tipo = "SSS" Then
                    objDataSet = objEstilos.usp_TraerEstl3(0, IdSuperior1, IdSuperior2, IdSuperior3, IdSuperior4, IdSuperior5, IdSuperior6, "", Opcion, Txt_Buscar.Text)
                End If
                If Tipo = "SSSS" Then
                    objDataSet = objEstilos.usp_TraerEstl4(0, IdSuperior1, IdSuperior2, IdSuperior3, IdSuperior4, IdSuperior5, IdSuperior6, IdSuperior7, "", Opcion, Txt_Buscar.Text)
                End If
                If Tipo = "SSSSS" Then
                    objDataSet = objEstilos.usp_TraerEstl5(0, IdSuperior1, IdSuperior2, IdSuperior3, IdSuperior4, IdSuperior5, IdSuperior6, IdSuperior7, IdSuperior8, "", Opcion, Txt_Buscar.Text)
                End If



                'objDataSet = objEstilos.usp_TraerEstilo(Marcab, "", EstiloFb, "", "", "", "", "", "%" & Txt_Buscar.Text & "%")
                'Populate the Project Details section
                DGrid.ReadOnly = True
                DGrid.DataSource = Nothing

                DGrid.DataSource = objDataSet.Tables(0)

                Call InicializaGrid()

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using


    End Sub



    Sub InicializaGrid()
        '' marca, Estilon, Estilof, descripc, familia, linea, proveedor, tipoart, categoria
        'mreyes 15/Febrero/2011 09:52 p.m.
        Try
            DGrid.RowHeadersVisible = False
            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            If Tipo = "DI" Then
                DGrid.Columns(0).Visible = False
                DGrid.Columns(1).HeaderText = "Clave"
                DGrid.Columns(2).HeaderText = "Descripción"
                DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If

            If Tipo = "D" Then
                DGrid.Columns(0).Visible = False
                DGrid.Columns(1).Visible = False
                DGrid.Columns(2).Visible = False
                DGrid.Columns(3).Visible = False
                DGrid.Columns(4).HeaderText = "Clave"
                DGrid.Columns(5).HeaderText = "Descripción"
                DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If

            If Tipo = "F" Then
                DGrid.Columns(0).Visible = False
                DGrid.Columns(1).Visible = False
                DGrid.Columns(2).Visible = False
                DGrid.Columns(3).Visible = False
                DGrid.Columns(4).Visible = False
                DGrid.Columns(5).Visible = False
                DGrid.Columns(6).Visible = False
                DGrid.Columns(7).HeaderText = "Clave"
                DGrid.Columns(8).HeaderText = "Descripción"
                DGrid.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If

            If Tipo = "L" Then
                DGrid.Columns(0).Visible = False
                DGrid.Columns(1).Visible = False
                DGrid.Columns(2).Visible = False
                DGrid.Columns(3).Visible = False
                DGrid.Columns(4).Visible = False
                DGrid.Columns(5).Visible = False
                DGrid.Columns(6).Visible = False
                DGrid.Columns(7).Visible = False
                DGrid.Columns(8).Visible = False
                DGrid.Columns(9).Visible = False
                DGrid.Columns(10).HeaderText = "Clave"
                DGrid.Columns(11).HeaderText = "Descripción"
                DGrid.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If

            If Tipo = "S" Then
                DGrid.Columns(0).Visible = False
                DGrid.Columns(1).Visible = False
                DGrid.Columns(2).Visible = False
                DGrid.Columns(3).Visible = False
                DGrid.Columns(4).Visible = False
                DGrid.Columns(5).Visible = False
                DGrid.Columns(6).Visible = False
                DGrid.Columns(7).Visible = False
                DGrid.Columns(8).Visible = False
                DGrid.Columns(9).Visible = False
                DGrid.Columns(10).Visible = False
                DGrid.Columns(11).Visible = False
                DGrid.Columns(12).Visible = False
                DGrid.Columns(13).HeaderText = "Clave"
                DGrid.Columns(14).HeaderText = "Descripción"
                DGrid.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If

            If Tipo = "SS" Then
                DGrid.Columns(0).Visible = False
                DGrid.Columns(1).Visible = False
                DGrid.Columns(2).Visible = False
                DGrid.Columns(3).Visible = False
                DGrid.Columns(4).Visible = False
                DGrid.Columns(5).Visible = False
                DGrid.Columns(6).Visible = False
                DGrid.Columns(7).Visible = False
                DGrid.Columns(8).Visible = False
                DGrid.Columns(9).Visible = False
                DGrid.Columns(10).Visible = False
                DGrid.Columns(11).Visible = False
                DGrid.Columns(12).Visible = False
                DGrid.Columns(13).Visible = False
                DGrid.Columns(14).Visible = False
                DGrid.Columns(15).Visible = False
                DGrid.Columns(16).HeaderText = "Clave"
                DGrid.Columns(17).HeaderText = "Descripción"
                DGrid.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If

            If Tipo = "SSS" Then
                DGrid.Columns(0).Visible = False
                DGrid.Columns(1).Visible = False
                DGrid.Columns(2).Visible = False
                DGrid.Columns(3).Visible = False
                DGrid.Columns(4).Visible = False
                DGrid.Columns(5).Visible = False
                DGrid.Columns(6).Visible = False
                DGrid.Columns(7).Visible = False
                DGrid.Columns(8).Visible = False
                DGrid.Columns(9).Visible = False
                DGrid.Columns(10).Visible = False
                DGrid.Columns(11).Visible = False
                DGrid.Columns(12).Visible = False
                DGrid.Columns(13).Visible = False
                DGrid.Columns(14).Visible = False
                DGrid.Columns(15).Visible = False
                DGrid.Columns(16).Visible = False
                DGrid.Columns(17).Visible = False
                DGrid.Columns(18).Visible = False
                DGrid.Columns(19).HeaderText = "Clave"
                DGrid.Columns(20).HeaderText = "Descripción"
                DGrid.Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(20).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If

            If Tipo = "SSSS" Then
                DGrid.Columns(0).Visible = False
                DGrid.Columns(1).Visible = False
                DGrid.Columns(2).Visible = False
                DGrid.Columns(3).Visible = False
                DGrid.Columns(4).Visible = False
                DGrid.Columns(5).Visible = False
                DGrid.Columns(6).Visible = False
                DGrid.Columns(7).Visible = False
                DGrid.Columns(8).Visible = False
                DGrid.Columns(9).Visible = False
                DGrid.Columns(10).Visible = False
                DGrid.Columns(11).Visible = False
                DGrid.Columns(12).Visible = False
                DGrid.Columns(13).Visible = False
                DGrid.Columns(14).Visible = False
                DGrid.Columns(15).Visible = False
                DGrid.Columns(16).Visible = False
                DGrid.Columns(17).Visible = False
                DGrid.Columns(18).Visible = False
                DGrid.Columns(19).Visible = False
                DGrid.Columns(20).Visible = False
                DGrid.Columns(21).Visible = False
                DGrid.Columns(22).HeaderText = "Clave"
                DGrid.Columns(23).HeaderText = "Descripción"
                DGrid.Columns(22).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(23).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If

            If Tipo = "SSSSS" Then
                DGrid.Columns(0).Visible = False
                DGrid.Columns(1).Visible = False
                DGrid.Columns(2).Visible = False
                DGrid.Columns(3).Visible = False
                DGrid.Columns(4).Visible = False
                DGrid.Columns(5).Visible = False
                DGrid.Columns(6).Visible = False
                DGrid.Columns(7).Visible = False
                DGrid.Columns(8).Visible = False
                DGrid.Columns(9).Visible = False
                DGrid.Columns(10).Visible = False
                DGrid.Columns(11).Visible = False
                DGrid.Columns(12).Visible = False
                DGrid.Columns(13).Visible = False
                DGrid.Columns(14).Visible = False
                DGrid.Columns(15).Visible = False
                DGrid.Columns(16).Visible = False
                DGrid.Columns(17).Visible = False
                DGrid.Columns(18).Visible = False
                DGrid.Columns(19).Visible = False
                DGrid.Columns(20).Visible = False
                DGrid.Columns(21).Visible = False
                DGrid.Columns(22).Visible = False
                DGrid.Columns(23).Visible = False
                DGrid.Columns(24).Visible = False
                DGrid.Columns(25).HeaderText = "Clave"
                DGrid.Columns(26).HeaderText = "Descripción"
                DGrid.Columns(25).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(26).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If
            
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmConsulta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If

    End Sub

    Private Sub frmConsulta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Call RellenaGrid()
            Call GenerarToolTip()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub
    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
            ToolTip.SetToolTip(Txt_Buscar, "Escriba lo que pretende buscar")
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
            Opcion = 3
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub DGrid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellDoubleClick


    End Sub


    Private Sub DGrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DGrid.KeyPress
        Try
            If e.KeyChar = ChrW(Keys.Enter) Then
                If Tipo = "DI" Then
                    IdCampo = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("iddivisiones").Value.ToString
                    ClaveCampo = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("clave").Value.ToString
                    DescripCampo = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("descrip").Value.ToString
                End If
                If Tipo = "D" Then
                    IdCampo = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("iddepto").Value.ToString
                    ClaveCampo = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("clave").Value.ToString
                    DescripCampo = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("descrip").Value.ToString
                End If
                If Tipo = "F" Then
                    IdCampo = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("idfamilia").Value.ToString
                    ClaveCampo = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("clave").Value.ToString
                    DescripCampo = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("descrip").Value.ToString
                End If
                If Tipo = "L" Then
                    IdCampo = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("idlinea").Value.ToString
                    ClaveCampo = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("clave").Value.ToString
                    DescripCampo = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("descrip").Value.ToString
                End If
                If Tipo = "S" Then
                    IdCampo = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("idl1").Value.ToString
                    ClaveCampo = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("clave").Value.ToString
                    DescripCampo = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("descrip").Value.ToString
                End If
                If Tipo = "SS" Then
                    IdCampo = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("idl2").Value.ToString
                    ClaveCampo = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("clave").Value.ToString
                    DescripCampo = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("descrip").Value.ToString
                End If
                If Tipo = "SSS" Then
                    IdCampo = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("idl3").Value.ToString
                    ClaveCampo = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("clave").Value.ToString
                    DescripCampo = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("descrip").Value.ToString
                End If
                If Tipo = "SSSS" Then
                    IdCampo = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("idl4").Value.ToString
                    ClaveCampo = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("clave").Value.ToString
                    DescripCampo = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("descrip").Value.ToString
                End If
                If Tipo = "SSSSS" Then
                    IdCampo = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("idl5").Value.ToString
                    ClaveCampo = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("clave").Value.ToString
                    DescripCampo = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("descrip").Value.ToString
                End If
                Me.Close()
                Me.Dispose()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub Btn_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Excel.Click
        Try
            If ExportarDGridAExcel(DGrid) = False Then
                MsgBox("Error al exportar a Excel. Intente nuevamente.", MsgBoxStyle.Critical, "Excel")
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub DGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick
        Try
            If Tipo = "DI" Then
                IdCampo = DGrid.CurrentRow.Cells("iddivisiones").Value.ToString
                ClaveCampo = DGrid.CurrentRow.Cells("clave").Value.ToString
                DescripCampo = DGrid.CurrentRow.Cells("descrip").Value.ToString
            End If
            If Tipo = "D" Then
                IdCampo = DGrid.CurrentRow.Cells("iddepto").Value.ToString
                ClaveCampo = DGrid.CurrentRow.Cells("clave").Value.ToString
                DescripCampo = DGrid.CurrentRow.Cells("descrip").Value.ToString
            End If
            If Tipo = "F" Then
                IdCampo = DGrid.CurrentRow.Cells("idfamilia").Value.ToString
                ClaveCampo = DGrid.CurrentRow.Cells("clave").Value.ToString
                DescripCampo = DGrid.CurrentRow.Cells("descrip").Value.ToString
            End If
            If Tipo = "L" Then
                IdCampo = DGrid.CurrentRow.Cells("idlinea").Value.ToString
                ClaveCampo = DGrid.CurrentRow.Cells("clave").Value.ToString
                DescripCampo = DGrid.CurrentRow.Cells("descrip").Value.ToString
            End If
            If Tipo = "S" Then
                IdCampo = DGrid.CurrentRow.Cells("idl1").Value.ToString
                ClaveCampo = DGrid.CurrentRow.Cells("clave").Value.ToString
                DescripCampo = DGrid.CurrentRow.Cells("descrip").Value.ToString
            End If
            If Tipo = "SS" Then
                IdCampo = DGrid.CurrentRow.Cells("idl2").Value.ToString
                ClaveCampo = DGrid.CurrentRow.Cells("clave").Value.ToString
                DescripCampo = DGrid.CurrentRow.Cells("descrip").Value.ToString
            End If
            If Tipo = "SSS" Then
                IdCampo = DGrid.CurrentRow.Cells("idl3").Value.ToString
                ClaveCampo = DGrid.CurrentRow.Cells("clave").Value.ToString
                DescripCampo = DGrid.CurrentRow.Cells("descrip").Value.ToString
            End If
            If Tipo = "SSSS" Then
                IdCampo = DGrid.CurrentRow.Cells("idl4").Value.ToString
                ClaveCampo = DGrid.CurrentRow.Cells("clave").Value.ToString
                DescripCampo = DGrid.CurrentRow.Cells("descrip").Value.ToString
            End If

            If Tipo = "SSSSS" Then
                IdCampo = DGrid.CurrentRow.Cells("idl5").Value.ToString
                ClaveCampo = DGrid.CurrentRow.Cells("clave").Value.ToString
                DescripCampo = DGrid.CurrentRow.Cells("descrip").Value.ToString
            End If

            Me.Close()
            Me.Dispose()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
End Class