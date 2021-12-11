Public Class frmPlazoPorcCondiciones

    Dim Sw_NoRegistros As Boolean = False
    Dim SqlBuscar As String
    Private objDataSet As Data.DataSet
    Public IdCondicion As Integer = 0
    Public IdProveedor As Integer = 0
    Public Marca As String = ""
    Public DescripMarca As String = ""
    Public Proveedor As String = ""
    Public Accion As Integer = 0

    

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
            'GLB_FormConsulta = True
            'Call RellenaGrid()
            Call GenerarToolTip()
            Lbl_M.Text = "Ingrese los porcentajes para la marca " & vbCrLf _
            & DescripMarca
            Call usp_TraerCondPlazoPorc()

            If Accion = 4 Then
                DGrid.ReadOnly = True
                DGrid.AllowUserToAddRows = False
                Lbl_M.Text = "Porcentajes para la marca " & vbCrLf _
            & DescripMarca
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub usp_TraerCondPlazoPorc()
        Using objCatalogoProveedores As New BCL.BCLCatalogoProveedoresN(GLB_ConStringCipSis)
            Try

                objDataSet = objCatalogoProveedores.usp_TraerCondPlazoPorc(IdProveedor, IdCondicion, Marca)

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    For I As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1

                        DGrid.Rows.Add(objDataSet.Tables(0).Rows(I).Item("porcentaje").ToString)
                    Next
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub
    Function Inserta_CondicionesPorc() As Boolean
        Dim Opcion As Integer = 0
        Dim PorcentajeB As Double = 0
        Try


            Using objCatalogoProveedores As New BCL.BCLCatalogoProveedoresN(GLB_ConStringCipSis)

                If Not objCatalogoProveedores.usp_Captura_CondPlazoPorc(3, IdProveedor, Proveedor, IdCondicion, Marca, PorcentajeB, GLB_Idempleado) Then
                    'Throw New Exception("Falló Inserción de Proveedor")
                Else
                    Inserta_CondicionesPorc = True
                End If
            End Using


            For i As Integer = 0 To DGrid.Rows.Count - 2
                Using objCatalogoProveedores As New BCL.BCLCatalogoProveedoresN(GLB_ConStringCipSis)

                    PorcentajeB = DGrid.Rows(i).Cells("col_porcentaje").Value.ToString
                    If Not objCatalogoProveedores.usp_Captura_CondPlazoPorc(1, IdProveedor, Proveedor, IdCondicion, Marca, PorcentajeB, GLB_Idempleado) Then
                        'Throw New Exception("Falló Inserción de Proveedor")
                    Else
                        Inserta_CondicionesPorc = True
                    End If
                End Using
            Next

            Inserta_CondicionesPorc = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Function

    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Aceptar, "Guardar Porcentajes")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    
    Private Sub Btn_Aceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        Try
            If Accion = 1 Or Accion = 2 Then
                If ValidarEdicion() = False Then Exit Sub
                If MsgBox("Está Seguro de Grabar estos porcentajes para las condiciones?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    If Inserta_CondicionesPorc() = True Then

                        MessageBox.Show("Exitosamente Grabados el registro de porcentajes '" & "' para la marca '" & DescripMarca & " !", "Agregando Arículo", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        Me.Close()
                        '' Me.Dispose()
                    Else
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


    Private Function ValidarEdicion() As Boolean
        ValidarEdicion = False
        Try
           

            ValidarEdicion = True
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Function

    Private Sub DGrid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGrid.KeyDown
        Dim columna As Integer
        Dim renglon As Integer = DGrid.CurrentRow.Index
        Dim marca As String = ""
        columna = DGrid.CurrentCell.ColumnIndex
        Try
            If (e.KeyCode = Keys.Delete) Then
                If Accion = 1 Or Accion = 2 Then
                    If DGrid.Rows(DGrid.CurrentRow.Index).Cells("col_porcentaje").Value <> "" Then
                        DGrid.Rows().Remove(DGrid.CurrentRow)
                    End If
                Else
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub
End Class