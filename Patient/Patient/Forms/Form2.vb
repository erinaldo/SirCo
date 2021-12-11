Imports CrystalDecisions.CrystalReports.Engine

Public Class Form2

    Private Sub Form2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim myReportDocument As ReportDocument = ChooseReport(1)

        cvwmain.ReportSource = myReportDocument
    End Sub

    Private Function ChooseReport(ByVal i As Integer) As ReportDocument
        Dim Rpt As ReportDocument
        Select Case i
            Case 1
                Dim Reporte As New CustomersBasic()
                Rpt = Reporte
            Case 2
                Dim Reporte As New rptDetalleBonos
                Rpt = Reporte
            Case 3
                Dim Reporte As New rptListChecadas
                Rpt = Reporte
            Case Else
                
        End Select
        Dim tbCurrent As CrystalDecisions.CrystalReports.Engine.Table
        Dim tliCurrent As CrystalDecisions.Shared.TableLogOnInfo

        For Each tbCurrent In Rpt.Database.Tables
            tliCurrent = tbCurrent.LogOnInfo
            With tliCurrent.ConnectionInfo
                .ServerName = "10.10.1.1"
                .UserID = "bonos"
                .Password = "bonos"
                .DatabaseName = "Northwind"
            End With
            tbCurrent.ApplyLogOnInfo(tliCurrent)
        Next tbCurrent

        Return CType(Rpt, ReportDocument)
    End Function

End Class