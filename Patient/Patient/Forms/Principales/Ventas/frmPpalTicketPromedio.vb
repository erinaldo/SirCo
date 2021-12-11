Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Web.UI.WebControls

Public Class frmPpalTicketPromedio
    Dim objDataSet As Data.DataSet
    Dim dt_desde, dt_hasta As Date
    Dim flag As Boolean = False

    Private Sub Btn_Consultar_Click(sender As Object, e As EventArgs) Handles Btn_Consultar.Click
        Try
            RellenaGrid()
            InicializaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show("Seleccione una fecha valida porfavor, " & ExceptionErr.Message.ToString)
        End Try
    End Sub

    Sub InicializaGrid()
        Dim i As Integer

        Try
            GridView2.Columns(0).Caption = "Vendedor"
            GridView2.Columns(1).Caption = "ID empleado"
            GridView2.Columns(2).Caption = "Nombre"
            GridView2.Columns(3).Caption = "Det"
            GridView2.Columns(4).Caption = "Sucursal"
            GridView2.Columns(5).Caption = "Pares"

            For i = 0 To 5 Step 1
                GridView2.Columns(i).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView2.Columns(i).AppearanceHeader.Font = New Font(GridView2.Columns(i).AppearanceCell.Font, FontStyle.Bold)
                GridView2.Columns(i).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView2.Columns(i).OptionsColumn.ReadOnly = True
            Next

            GridView1.Columns(0).Caption = "Det"
            GridView1.Columns(1).Caption = "Sucursal"
            GridView1.Columns(2).Caption = "Pares"

            For i = 0 To 2 Step 1
                GridView1.Columns(i).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns(i).AppearanceHeader.Font = New Font(GridView1.Columns(i).AppearanceCell.Font, FontStyle.Bold)
                GridView1.Columns(i).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns(i).OptionsColumn.ReadOnly = True
            Next

            GridView2.OptionsView.ColumnAutoWidth = False
            GridView1.OptionsView.ColumnAutoWidth = False

            GridView2.BestFitColumns()
            GridView1.BestFitColumns()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub RellenaGrid()
        Dim Cve_Sucursal As String = ""
        Using objTicketPromedio As New BCL.BCLTicketPromedio(GLB_ConStringSirCoSQL)

            Try
                Me.Cursor = Cursors.WaitCursor

                If GLB_CveSucursal <> "" Then
                    Cve_Sucursal = GLB_CveSucursal
                Else
                    Cve_Sucursal = ""
                End If
                If GLB_IdDeptoEmpleado = 7 Then
                    Cve_Sucursal = ""
                End If

                DGrid1.DataSource = Nothing
                DGrid2.DataSource = Nothing

                objDataSet = objTicketPromedio.usp_TraerTicketPromedio(dt_desde.ToString("yyyy/MM/dd"), dt_hasta.ToString("yyyy/MM/dd"), Cve_Sucursal)

                If objDataSet.Tables(0).Rows.Count > 0 And objDataSet.Tables(1).Rows.Count > 0 Then
                    DGrid1.DataSource = objDataSet.Tables(0)
                    DGrid2.DataSource = objDataSet.Tables(1)
                Else
                    MsgBox("No se encontraron registros que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                End If

                Me.Cursor = Cursors.Default
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub frmPpalTicketPromedio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            coloca_fechas()
            RellenaGrid()
            InicializaGrid()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DEditDesde_EditValueChanged(sender As Object, e As EventArgs) Handles DEditDesde.EditValueChanged
        Try
            If flag = True Then
                dt_desde = Convert.ToDateTime(DEditDesde.EditValue)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub DEditHasta_EditValueChanged(sender As Object, e As EventArgs) Handles DEditHasta.EditValueChanged
        Try
            If flag = True Then
                dt_hasta = Convert.ToDateTime(DEditHasta.EditValue)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub Btn_Salir_Click(sender As Object, e As EventArgs) Handles Btn_Salir.Click
        Me.Close()
    End Sub

    Private Sub Btn_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Excel.Click
        Dim fecha, archivo As String

        Try
            If (GridView1.RowCount > 0) Then
                If sfdRuta.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    fecha = Date.Today.ToString("dd-MM-yyyy")
                    archivo = sfdRuta.FileName.Replace(".xls", "")

                    DGrid2.ExportToXls(archivo + "_Ven_" + fecha + ".xls")
                    DGrid1.ExportToXls(archivo + "_Det_" + fecha + ".xls")

                    System.Diagnostics.Process.Start(archivo + "_Ven_" + fecha + ".xls")
                    System.Diagnostics.Process.Start(archivo + "_Det_" + fecha + ".xls")
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid2_Click(sender As Object, e As EventArgs) Handles DGrid2.Click

    End Sub

    Private Sub DGrid1_Click(sender As Object, e As EventArgs) Handles DGrid1.Click

    End Sub

    Private Sub coloca_fechas()
        Dim num_dia As Int32

        Try
            DEditHasta.DateTime = DateTime.Today
            dt_hasta = Convert.ToDateTime(DEditHasta.EditValue)
            DEditHasta.DateTime = dt_hasta.AddDays(-1)
            dt_hasta = dt_hasta.AddDays(-1)
            num_dia = Convert.ToInt32(dt_hasta.Day)

            If num_dia = 1 Then
                DEditDesde.DateTime = DateTime.Today
            Else
                DEditDesde.DateTime = dt_hasta.AddDays((num_dia - 1) * -1)
            End If

            dt_desde = Convert.ToDateTime(DEditDesde.EditValue)
            If GLB_Usuario <> "SISTEMAS" And GLB_Usuario <> "RESM1979" And GLB_Usuario <> "FELIX" And GLB_Usuario <> "FELIXJ" And GLB_Usuario <> "LORIS" Then
                DEditDesde.Properties.MinValue = "2018-12-17"
                DEditDesde.DateTime = DEditHasta.DateTime
                ' DEditDesde.DateTime = "2018-12-17"
                dt_desde = Convert.ToDateTime(DEditDesde.EditValue)

                'DEditDesde.Enabled = False
            End If


            flag = True
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class