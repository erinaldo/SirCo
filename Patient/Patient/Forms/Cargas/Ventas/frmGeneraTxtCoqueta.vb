Public Class frmGeneraTxtCoqueta
    'mreyes 25/Abril/2016   10:24 a.m.
    Dim Sql As String
    Public Sw_Filtro As Boolean = False
    Public Sw_Cancelar As Boolean = False

    Private objDataSet As Data.DataSet
    Public FechaIniB As Date
    Public Tipo As String = ""
    Dim FechaFinB As Date



    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        'mreyes     25/Abril/2016   10:31 a.m.
        Try



            If MsgBox("Esta seguro de querer generar el archivo .txt para TRAC COQUETA?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmación") = MsgBoxResult.No Then Exit Sub

            Dim NomArchivo As String = ""

            Dim Linea As String = ""
            Dim Archivo As String = "" '"c:\Prueba\Banamex" & Replace(Replace(Format(Date.Now, "yyyy-MM-dd hh:mm:ss"), "-", ""), ":", "") & ".txt"

            Dim Sku As String = ""
            Dim Ctd As String = ""
            Dim Matriz As String = "3934"
            Dim Sucursal As String = ""

            FechaIniB = DT_FechaIni.Value
            FechaFinB = DT_FechaFin.Value

            NomArchivo = Format(CDate(FechaFinB), "yyyyMMdd")

            Using objVtas As New BCL.BCLVentas(GLB_ConStringDWH)
                objDataSet = objVtas.usp_GeneraTxtCoqueta(Txt_Sucursal.Text, FechaIniB, FechaFinB)
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                Archivo = GLB_RutaTxtCoqueta & Txt_Sucursal.Text & NomArchivo & ".txt"
                Dim sw As New System.IO.StreamWriter(Archivo)
                For i As Integer = 1 To objDataSet.Tables(0).Rows.Count

                    Sku = objDataSet.Tables(0).Rows(i - 1).Item("sku").ToString & ","
                    Ctd = objDataSet.Tables(0).Rows(i - 1).Item("ctd").ToString & ","
                    Matriz = objDataSet.Tables(0).Rows(i - 1).Item("matriz").ToString & ","
                    Sucursal = objDataSet.Tables(0).Rows(i - 1).Item("coqueta").ToString



                    Linea = Sku & Ctd & Matriz & Sucursal
                    sw.WriteLine(Linea)
                Next
                sw.Close()
            Else
                MsgBox("No se encontraron registros que cumplan el filtro.", MsgBoxStyle.Critical, "Aviso")
                Exit Sub 
            End If

            MsgBox("Archivo creado en '" & Archivo, MsgBoxStyle.Information, "Confirmación")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Try
            '' Me.Dispose()
            Sw_Cancelar = True
            Sw_Filtro = False
            Me.Close()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Aceptar, "Aceptar la acción requerida por el usuario")
            ToolTip.SetToolTip(Btn_Cancelar, "Cancelar cualquier acción requerida por el usuario")
            ToolTip.SetToolTip(Btn_Limpiar, "Limpiar Filtros")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub frmFiltrosFacturas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Sw_Filtro = False
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub frmConsultaEstilo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call GenerarToolTip()
    End Sub

    Private Sub Btn_Limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Limpiar.Click
    End Sub



End Class