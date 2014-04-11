using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.IO;
using Negocio;
using Dominio;

namespace CuotaSystem
{
    public partial class ReporteDePagos : System.Web.UI.Page
    {
        ReportesNego reposrtesNego = new ReportesNego();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            dtpFechaDesde.Text = DateTime.Today.ToShortDateString();
            dtpFechaHasta.Text = DateTime.Today.ToShortDateString();

            reporteSaldoDiario();
        }

        private void reporteSaldoDiario()
        {
            DateTime fechaDesde = Convert.ToDateTime(dtpFechaDesde.Text);
            DateTime fechaHasta = Convert.ToDateTime(dtpFechaHasta.Text);

            gdvReporteDiario.DataSource = reposrtesNego.reporteSaldoDiario(fechaDesde, fechaHasta).ToList();
            gdvReporteDiario.DataBind();
        }

        private void llenarReporte()
        {
            DateTime fechaDesde = Convert.ToDateTime(dtpFechaDesde.Text);
            DateTime fechaHasta = Convert.ToDateTime(dtpFechaHasta.Text);

            gdvReporteDiarioTemp.DataSource = reposrtesNego.reporteSaldoDiario(fechaDesde, fechaHasta).ToList();
            gdvReporteDiarioTemp.DataBind();
        }

        protected void gdvReporteDiario_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotal = (Label)e.Row.FindControl("lblTotal");
                lblTotal.Text = sumaSaldoDiario().ToString();
            }
        }

        private string sumaSaldoDiario()
        {
            decimal total = 0;

            DateTime fechaDesde = Convert.ToDateTime(dtpFechaDesde.Text);
            DateTime fechaHasta = Convert.ToDateTime(dtpFechaHasta.Text);

            IList<ReportePagosResultSet0> listaSaldoDiario = reposrtesNego.reporteSaldoDiario(fechaDesde, fechaHasta).ToList();

            foreach (ReportePagosResultSet0 saldoData in listaSaldoDiario)
            {
                total = Convert.ToDecimal(total + saldoData.Pago);
            }

            return String.Format("{0:C2}", total);
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        public void converToPdf()
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    //To Export all pages
                    gdvReporteDiarioTemp.AllowPaging = false;
                    this.llenarReporte();

                    gdvReporteDiarioTemp.RenderControl(hw);

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
                gdvReporteDiarioTemp.AllowPaging = false;
                this.llenarReporte();

                gdvReporteDiarioTemp.HeaderRow.BackColor = System.Drawing.Color.White;
                foreach (TableCell cell in gdvReporteDiarioTemp.HeaderRow.Cells)
                {
                    cell.BackColor = gdvReporteDiarioTemp.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in gdvReporteDiarioTemp.Rows)
                {
                    row.BackColor = System.Drawing.Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = gdvReporteDiarioTemp.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gdvReporteDiarioTemp.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                gdvReporteDiarioTemp.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }

        protected void btnPdf_Click(object sender, EventArgs e)
        {
            converToPdf();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            reporteSaldoDiario();
        }

        protected void btnExcel_Click(object sender, ImageClickEventArgs e)
        {
            convertToExcel();
        }
    }
}