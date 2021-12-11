Public Class frmPeriodoPresupuesto

    Public Filtro As Boolean

#Region "Metodos"

    Private Sub RellenaAño(AñoActual As Integer)
        For i As Integer = AñoActual - 1 To AñoActual + 1
            cbo_Año.Properties.Items.Add(i)
        Next
        cbo_Año.Text = AñoActual
    End Sub

    Private Function CrearPresupuesto() As Boolean
        CrearPresupuesto = False
        Dim objDataSetSuc As DataSet
        Dim objDataSetDiv As DataSet
        Using objPresupuesto As New BCL.BCLAgrupaciones(GLB_ConStringSirCoPVSQL)
            objDataSetDiv = objPresupuesto.usp_TraerEstructura("DIVISIÓN", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
        End Using
        If objDataSetDiv.Tables(0).Rows.Count = 0 Then
            MessageBox.Show("No se encontro información de la División", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Function
        End If
        Using objPresupuesto As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
            objDataSetSuc = objPresupuesto.usp_TraerPlazasSucursales("SUCURSAL", 0)
        End Using
        If objDataSetSuc.Tables(0).Rows.Count = 0 Then
            MessageBox.Show("No se encontro información de las sucursales", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Function
        End If

        For i As Integer = 0 To objDataSetSuc.Tables(0).Rows.Count - 1
            For j As Integer = 0 To objDataSetDiv.Tables(0).Rows.Count - 1
                Using objPresupuesto As New BCL.BCLPresupuesto(GLB_ConStringDwhSQL)
                    objPresupuesto.usp_CapturaPresupuesto(objDataSetSuc.Tables(0).Rows(i).Item("idsucursal").ToString.Trim, cbo_Año.Text.Trim, cbo_Mes.Text.Substring(0, 2), objDataSetDiv.Tables(0).Rows(j).Item("iddivisiones").ToString.Trim, objDataSetDiv.Tables(0).Rows(j).Item("descrip").ToString.Trim, 0, GLB_Usuario)
                End Using
            Next
        Next

    End Function

#End Region

#Region "Eventos"
    Private Sub frmPeriodoPresupuesto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cbo_Mes.Text = pub_RellenarIzquierda(GLB_FechaHoy.Month, 2) & "-" & MonthName(GLB_FechaHoy.Month)
            Filtro = False
            RellenaAño(GLB_FechaHoy.Year)
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Nuevo_Click(sender As Object, e As EventArgs) Handles btn_Nuevo.Click
        Try
            Dim objDataSet As DataSet
            Using objPresupuesto As New BCL.BCLPresupuesto(GLB_ConStringDwhSQL)
                objDataSet = objPresupuesto.usp_TraerPresupuesto("MENSUAL", cbo_Año.Text.Trim, cbo_Mes.Text.Trim.Substring(0, 2))
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                MessageBox.Show("El Presupuesto para el mes " & cbo_Mes.Text.Trim.Substring(3, cbo_Mes.Text.Trim.Length - 3).ToUpper & " del año " & cbo_Año.Text.Trim & " ya fue creado anteriormente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Filtro = True
            CrearPresupuesto()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Salir_Click(sender As Object, e As EventArgs) Handles btn_Salir.Click
        Me.Close()
    End Sub

    Private Sub frmPeriodoPresupuesto_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

#End Region

End Class