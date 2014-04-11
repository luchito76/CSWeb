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
    public partial class ListaAlumnos : System.Web.UI.Page
    {
        AlumnoNego alumnoNego = new AlumnoNego();
        protected void Page_Load(object sender, EventArgs e)
        {
            llenarTabla();
        }

        private void llenarTabla()
        {
            gdvListaAlumnos.DataSource = alumnoNego.listaAlumnos().ToList();
            gdvListaAlumnos.DataBind();
        }

        protected void gdvListaAlumnos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Alumnos"))
            {
                Response.Redirect("EditarAlumnos.aspx?idAlumno=" + e.CommandArgument);
            }
        }

        protected void gdvListaAlumnos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            gdvListaAlumnos.PageIndex = e.NewSelectedIndex;
            gdvListaAlumnos.DataBind();
        }

        protected void gdvListaAlumnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvListaAlumnos.PageIndex = e.NewPageIndex;
            gdvListaAlumnos.DataBind();
        }
    }
}