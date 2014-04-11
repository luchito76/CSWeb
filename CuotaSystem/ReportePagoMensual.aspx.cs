using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Collections.Generic;

namespace CuotaSystem.Reportes
{
    public partial class ReportePagoMensual : System.Web.UI.Page
    {
        ReportesNego reportesNego = new ReportesNego();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            llenarTabla();
        }

        private void llenarTabla()
        {
            gdvReportePagoMensual.DataSource = reportesNego.ReporteDePagosMensuales().ToList();
            gdvReportePagoMensual.DataBind();
        }

        private void llenarReporte()
        {
            gdvReporte.DataSource = reportesNego.ReporteDePagosMensuales().ToList();
            gdvReporte.DataBind();
        }

        private void sumaSaldoMensual()
        {
            IList<ReporteDePagosMensualesResultSet0> listaPagoMensual = reportesNego.ReporteDePagosMensuales().ToList();

            foreach (ReporteDePagosMensualesResultSet0 data in listaPagoMensual)
            {
                //data.
            }
        }

        protected void gdvReportePagoMensual_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Label lblMarzo = (Label)e.Row.FindControl("lblMarzo");
                System.Web.UI.WebControls.Image imgMarzo = (System.Web.UI.WebControls.Image)e.Row.FindControl("imgMarzo");
                System.Web.UI.WebControls.Image imgAbril = (System.Web.UI.WebControls.Image)e.Row.FindControl("imgAbril");
                System.Web.UI.WebControls.Image imgMayo = (System.Web.UI.WebControls.Image)e.Row.FindControl("imgMayo");
                System.Web.UI.WebControls.Image imgJunio = (System.Web.UI.WebControls.Image)e.Row.FindControl("imgJunio");
                System.Web.UI.WebControls.Image imgJulio = (System.Web.UI.WebControls.Image)e.Row.FindControl("imgJulio");
                System.Web.UI.WebControls.Image imgAgosto = (System.Web.UI.WebControls.Image)e.Row.FindControl("imgAgosto");
                System.Web.UI.WebControls.Image imgSetiembre = (System.Web.UI.WebControls.Image)e.Row.FindControl("imgSetiembre");
                System.Web.UI.WebControls.Image imgOctubre = (System.Web.UI.WebControls.Image)e.Row.FindControl("imgOctubre");
                System.Web.UI.WebControls.Image imgNoviembre = (System.Web.UI.WebControls.Image)e.Row.FindControl("imgNoviembre");
                System.Web.UI.WebControls.Image imgDiciembre = (System.Web.UI.WebControls.Image)e.Row.FindControl("imgDiciembre");

                if (imgMarzo.AlternateText == "Pagado")
                    imgMarzo.ImageUrl = "../imagenes/pagado.ico";
                else
                    imgMarzo.ImageUrl = "../imagenes/nopagado.ico";

                if (imgAbril.AlternateText == "Pagado")
                    imgAbril.ImageUrl = "../imagenes/pagado.ico";
                else
                    imgAbril.ImageUrl = "../imagenes/nopagado.ico";

                if (imgMayo.AlternateText == "Pagado")
                    imgMayo.ImageUrl = "../imagenes/pagado.ico";
                else
                    imgMayo.ImageUrl = "../imagenes/nopagado.ico";

                if (imgJunio.AlternateText == "Pagado")
                    imgJunio.ImageUrl = "../imagenes/pagado.ico";
                else
                    imgJunio.ImageUrl = "../imagenes/nopagado.ico";

                if (imgJulio.AlternateText == "Pagado")
                    imgJulio.ImageUrl = "../imagenes/pagado.ico";
                else
                    imgJulio.ImageUrl = "../imagenes/nopagado.ico";

                if (imgAgosto.AlternateText == "Pagado")
                    imgAgosto.ImageUrl = "../imagenes/pagado.ico";
                else
                    imgAgosto.ImageUrl = "../imagenes/nopagado.ico";

                if (imgSetiembre.AlternateText == "Pagado")
                    imgSetiembre.ImageUrl = "../imagenes/pagado.ico";
                else
                    imgSetiembre.ImageUrl = "../imagenes/nopagado.ico";

                if (imgOctubre.AlternateText == "Pagado")
                    imgOctubre.ImageUrl = "../imagenes/pagado.ico";
                else
                    imgOctubre.ImageUrl = "../imagenes/nopagado.ico";

                if (imgNoviembre.AlternateText == "Pagado")
                    imgNoviembre.ImageUrl = "../imagenes/pagado.ico";
                else
                    imgNoviembre.ImageUrl = "../imagenes/nopagado.ico";

                if (imgDiciembre.AlternateText == "Pagado")
                    imgDiciembre.ImageUrl = "../imagenes/pagado.ico";
                else
                    imgDiciembre.ImageUrl = "../imagenes/nopagado.ico";
            }
        }

        protected void btnPdf_Click(object sender, EventArgs e)
        {
            convertirPDF();
        }

        private void convertirPDF()
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    //To Export all pages
                    gdvReporte.AllowPaging = false;
                    this.llenarReporte();

                    gdvReporte.RenderControl(hw);

                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=Reporte_de_Pagos_Mensuales.pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();
                }
            }
        }

        private void convertToExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=ReporteSaldoDiario.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                gdvReporte.AllowPaging = false;
                this.llenarReporte();

                gdvReporte.HeaderRow.BackColor = System.Drawing.Color.White;
                foreach (TableCell cell in gdvReporte.HeaderRow.Cells)
                {
                    cell.BackColor = gdvReporte.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in gdvReporte.Rows)
                {
                    row.BackColor = System.Drawing.Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = gdvReporte.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gdvReporte.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                gdvReporte.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void gdvReporte_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnExcel_Click(object sender, ImageClickEventArgs e)
        {
            convertToExcel();
        }
    }
}