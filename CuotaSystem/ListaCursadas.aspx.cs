using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace CuotaSystem
{
    public partial class ListaCursadas : System.Web.UI.Page
    {
        CursadaNego cursadaNego = new CursadaNego();
        protected void Page_Load(object sender, EventArgs e)
        {
            llenarTabla();
        }

        private void llenarTabla()
        {
            gdvListaCursadas.DataSource = cursadaNego.listaCursadas().ToList();
            gdvListaCursadas.DataBind();
        }

        protected void gdvListaCursadas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Cursada"))
            {
                Response.Redirect("EditarCursada.aspx?idCursada=" + e.CommandArgument);
            }
        }

        protected void gdvListaCursadas_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            gdvListaCursadas.PageIndex = e.NewSelectedIndex;
            gdvListaCursadas.DataBind();
        }

        protected void gdvListaCursadas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvListaCursadas.PageIndex = e.NewPageIndex;
            gdvListaCursadas.DataBind();
        }
    }
}