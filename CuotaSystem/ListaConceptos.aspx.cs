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
    public partial class ListaConceptos : System.Web.UI.Page
    {
        ConceptoNego conceptoNego = new ConceptoNego();

        protected void Page_Load(object sender, EventArgs e)
        {
            Login login = new Login();

            if (!login.validarLogin())
                Response.Redirect("Login.aspx");

            mostrarLista();
        }

        private void mostrarLista()
        {
            gdvListaConceptos.DataSource = conceptoNego.listaConceptos().ToList();
            gdvListaConceptos.DataBind();
        }

        protected void gdvListaConceptos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Concepto"))
            {
                Response.Redirect("EditarConcepto.aspx?idConcepto=" + e.CommandArgument);
            }
        }

        protected void gdvListaConceptos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            gdvListaConceptos.PageIndex = e.NewSelectedIndex;
            gdvListaConceptos.DataBind();
        }

        protected void gdvListaConceptos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvListaConceptos.PageIndex = e.NewPageIndex;
            gdvListaConceptos.DataBind();
        }
    }
}