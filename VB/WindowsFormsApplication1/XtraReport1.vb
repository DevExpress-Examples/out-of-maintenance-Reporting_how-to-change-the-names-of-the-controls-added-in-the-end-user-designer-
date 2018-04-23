Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports DevExpress.XtraReports.UI

Namespace WindowsFormsApplication1
	Partial Public Class XtraReport1
		Inherits DevExpress.XtraReports.UI.XtraReport
		Public Sub New()
			InitializeComponent()

		End Sub

		Private Sub xrPivotGrid1_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs)
			'nWindDataSet1.WriteXml("test.xml", System.Data.XmlWriteMode.WriteSchema);


		End Sub

		Private Sub XtraReport1_AfterPrint(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.AfterPrint

		End Sub

		Private Sub xrTableRow3_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs)

		End Sub

		Private Sub xrLabel1_SummaryRowChanged(ByVal sender As Object, ByVal e As EventArgs)

		End Sub

		Private Sub xrLabel1_SummaryCalculated(ByVal sender As Object, ByVal e As TextFormatEventArgs)

		End Sub

		Private Sub xrLabel1_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs)

		End Sub

		Private Sub xrLabel1_SummaryReset(ByVal sender As Object, ByVal e As EventArgs)
		End Sub

		Private Sub xrPivotGrid1_CustomCellValue(ByVal sender As Object, ByVal e As DevExpress.XtraPivotGrid.PivotCellValueEventArgs)

		End Sub

	End Class
End Namespace
