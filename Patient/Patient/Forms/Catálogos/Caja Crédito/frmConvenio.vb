Public Class frmConvenio

#Region "VARIABLES"
    Dim objDataSet As New DataSet
    Public DiaIni As Date
    Public Plazo As Integer = 0
    Public Dias As Integer = 0
    Public blnConvenio As Boolean = False
    Public TotalPago As Double = 0
#End Region

#Region "EVENTOS"

#Region "FORMA"

    Private Sub frmModificarDescuentoCaja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            GeneraGrid()
            lbl_TotImp.Text = "$" & Format(TotalPago, "###,##0.00")
            lbl_PenImp.Text = "$0.00"
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmCajaCredito_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub DGrid_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellEndEdit
        Try
            If DGrid.CurrentCell.ColumnIndex = 0 Then
                DGrid.CurrentCell.Value = CDate(DGrid.CurrentCell.Value).ToString("dd/MM/yyyy")
            End If
            If DGrid.CurrentCell.ColumnIndex = 2 Then
                DGrid.CurrentCell.Value = "$" & Format(CDbl(DGrid.CurrentCell.Value), "###,##0.00")
            End If
            Dim Pen As Double = 0
            For i As Integer = 0 To DGrid.Rows.Count - 1
                Pen += Math.Round(CDbl(DGrid.Rows(i).Cells("col_importe").Value), 2)
            Next
            lbl_PenImp.Text = "$" & Format(TotalPago - Pen, "###,##0.00")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

#End Region

#Region "BOTON"

    Private Sub btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancelar.Click
        Try
            blnConvenio = False
            Me.Close()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Aceptar.Click
        Try
            If ValidaGrid() Then
                blnConvenio = True
                Me.Close()
            Else
                blnConvenio = False
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

#End Region

#End Region

#Region "METODOS"

    Private Sub GeneraGrid()
        For i As Integer = 0 To Plazo - 1
            DGrid.Rows.Add()
            If i = 0 Then
                DGrid.Rows(i).Cells("col_fecha").Value = DiaIni.ToString("dd/MM/yyyy")
                DGrid.Rows(i).Cells("col_pago").Value = i + 1
                DGrid.Rows(i).Cells("col_importe").Value = Math.Round(TotalPago / Plazo, 2)
            Else
                DiaIni = DiaIni.AddDays(Dias)
                DGrid.Rows(i).Cells("col_fecha").Value = DiaIni.ToString("dd/MM/yyyy")
                DGrid.Rows(i).Cells("col_pago").Value = i + 1
                DGrid.Rows(i).Cells("col_importe").Value = Math.Round(TotalPago / Plazo, 2)
            End If
            'DiaIni = DiaIni.AddDays(Dias)
        Next
    End Sub

    Private Function ValidaGrid() As Boolean
        Dim TotImporteGrid As Double = 0
        For i As Integer = 0 To DGrid.Rows.Count - 1
            If i = 0 Then
                If CDate(DGrid.Rows(i).Cells("col_fecha").Value) <= GLB_FechaHoy Then
                    MessageBox.Show("El primer pago debe ser mayor al dia de hoy", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
            Else
                If CDate(DGrid.Rows(i).Cells("col_fecha").Value) <= CDate(DGrid.Rows(i - 1).Cells("col_fecha").Value) Then
                    MessageBox.Show("Por favor ingresa un orden correcto en las fechas de los pagos", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
            End If
            TotImporteGrid += CDbl(DGrid.Rows(i).Cells("col_importe").Value)
        Next

        'CHECAR ESTO MARTHA
        If Math.Round(TotImporteGrid, 2) < TotalPago Then
            MessageBox.Show("El importe de pago debe sumar " & "$" & Format(TotalPago, "###,##0.00"), "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

#End Region

    
End Class