using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace CuotaSystem.Cursos
{
    public partial class ListaCursos : System.Web.UI.Page
    {
        CursoNego cursoNego = new CursoNego();
        protected void Page_Load(object sender, EventArgs e)
        {
            Login login = new Login();

            if (!login.validarLogin())
                Response.Redirect("Login.aspx");

            llenarTabla();
        }

        private void llenarTabla()
        {
            gdvListaCursos.DataSource = cursoNego.listaCursos().ToList();
            gdvListaCursos.DataBind();
        }

        protected void gdvListaCursos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Curso"))
            {
                Response.Redirect("EditarCurso.aspx?idCurso=" + e.CommandArgument);
            }
        }

        protected void gdvListaCursos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            gdvListaCursos.PageIndex = e.NewSelectedIndex;
            gdvListaCursos.DataBind();
        }

        protected void gdvListaCursos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvListaCursos.PageIndex = e.NewPageIndex;
            gdvListaCursos.DataBind();
        }
    }
}