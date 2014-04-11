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
    public partial class ListaInscripciones : System.Web.UI.Page
    {
        InscripcionNego inscripcionNego = new InscripcionNego();
        protected void Page_Load(object sender, EventArgs e)
        {
            llenarLista();
        }

        private void llenarLista()
        {
            int idALumno = 0;

            gdvListaInscripcion.DataSource = inscripcionNego.listaInscripciones(idALumno).ToList();
            gdvListaInscripcion.DataBind();
        }

        protected void gdvListaInscripcion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Alumnos"))
            {
                Response.Redirect("EditarInscripcion.aspx?idInscripcion=" + e.CommandArgument);
            }
        }

        protected void gdvListaInscripcion_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            gdvListaInscripcion.PageIndex = e.NewSelectedIndex;
            gdvListaInscripcion.DataBind();
        }

        protected void gdvListaInscripcion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvListaInscripcion.PageIndex = e.NewPageIndex;
            gdvListaInscripcion.DataBind();
        }
    }
}