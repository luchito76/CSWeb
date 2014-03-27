using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace CuotaSystem
{
    public partial class ListaAutorizados : System.Web.UI.Page
    {
        AutorizadosNego fliaAutorizadaNego = new AutorizadosNego();

        protected void Page_Load(object sender, EventArgs e)
        {

            llenarTabla();
        }

        public void llenarTabla()
        {
            gdvListaFliaAutorizada.DataSource = fliaAutorizadaNego.SP_listaAutorizados();
            gdvListaFliaAutorizada.DataBind();
        }

        protected void gdvListaFliaAutorizada_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("FliaAutorizada"))
            {
                Response.Redirect("EditarAutorizados.aspx?idAutorizado=" + e.CommandArgument);
            }
        }
    }
}