﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using DevExpress.Web.ASPxGridView;
using DevExpress.XtraPrinting;
using DevExpress.Web.ASPxGridView.Export;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {

    }
    protected void btnExport_Click(object sender, EventArgs e) {
        DevExpress.XtraPrinting.XlsExportOptions options = new XlsExportOptions();
        options.SheetName = "DevExpress";
        gridExporter.WriteXlsToResponse(options);
    }
    protected void grid_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e) {
        if (e.DataColumn.FieldName == "UnitPrice") {
            if (Convert.ToInt32(e.CellValue) > 15)
                e.Cell.BackColor = Color.Yellow;
            else
                e.Cell.BackColor = Color.Green;
        }
    }
    protected void gridExporter_RenderBrick(object sender, ASPxGridViewExportRenderingEventArgs e) {
        if (e.RowType != GridViewRowType.Data)
            return;
        if ((e.Column as GridViewDataColumn).FieldName == "UnitPrice" && e.RowType != GridViewRowType.Header) {
            if (Convert.ToInt32(e.TextValue) > 15)
                e.BrickStyle.BackColor = Color.Yellow;
            else
                e.BrickStyle.BackColor = Color.Green;
        }
    }
}
