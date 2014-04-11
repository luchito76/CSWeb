using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace CuotaSystem
{
    public partial class ListaEscuelas : System.Web.UI.Page
    {
        EscuelaNego escuelaNego = new EscuelaNego();

        protected void Page_Load(object sender, EventArgs e)
        {
            llenarTabla();
        }

        private void llenarTabla()
        {
            gdvListaEscuelas.DataSource = escuelaNego.listaEscuelas().ToList();
            gdvListaEscuelas.DataBind();
        }

        protected void gdvListaEscuelas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Escuela"))
            {
                Response.Redirect("EditarEscuela.aspx?idEscuela=" + e.CommandArgument);
            }
        }

        protected void gdvListaEscuelas_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            gdvListaEscuelas.PageIndex = e.NewSelectedIndex;
            gdvListaEscuelas.DataBind();
        }

        protected void gdvListaEscuelas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvListaEscuelas.PageIndex = e.NewPageIndex;
            gdvListaEscuelas.DataBind();
        }
    }
}