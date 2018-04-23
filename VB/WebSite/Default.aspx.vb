Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Drawing
Imports DevExpress.Web.ASPxGridView
Imports DevExpress.XtraPrinting
Imports DevExpress.Web.ASPxGridView.Export

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub
	Protected Sub btnExport_Click(ByVal sender As Object, ByVal e As EventArgs)
		Dim options As DevExpress.XtraPrinting.XlsExportOptions = New XlsExportOptions()
		options.SheetName = "DevExpress"
		gridExporter.WriteXlsToResponse(options)
	End Sub
	Protected Sub grid_HtmlDataCellPrepared(ByVal sender As Object, ByVal e As ASPxGridViewTableDataCellEventArgs)
		If e.DataColumn.FieldName = "UnitPrice" Then
			If Convert.ToInt32(e.CellValue) > 15 Then
				e.Cell.BackColor = Color.Yellow
			Else
				e.Cell.BackColor = Color.Green
			End If
		End If
	End Sub
	Protected Sub gridExporter_RenderBrick(ByVal sender As Object, ByVal e As ASPxGridViewExportRenderingEventArgs)
		If e.RowType <> GridViewRowType.Data Then
			Return
		End If
		If (TryCast(e.Column, GridViewDataColumn)).FieldName = "UnitPrice" AndAlso e.RowType <> GridViewRowType.Header Then
			If Convert.ToInt32(e.TextValue) > 15 Then
				e.BrickStyle.BackColor = Color.Yellow
			Else
				e.BrickStyle.BackColor = Color.Green
			End If
		End If
	End Sub
End Class
