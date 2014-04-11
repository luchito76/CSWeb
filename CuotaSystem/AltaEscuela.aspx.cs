using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Negocio;
using Dominio;

namespace CuotaSystem
{
    public partial class AltaEscuela : System.Web.UI.Page
    {
        EscuelaNego escuelaNego = new EscuelaNego();

        protected void Page_Load(object sender, EventArgs e)
        {
            Login login = new Login();

            if (!login.validarLogin())
                Response.Redirect("Login.aspx");

            Utility.Utility.checkButtonDoubleClick(btnGuardar, this.Page);
            llenarTabla();
        }

        private void guardarEscuela()
        {
            Escuela escuela = new Escuela();

            escuela.Nombre = txtDescripcion.Text;
            escuela.Activo = true;

            escuelaNego.guardarEscuela(escuela);

            Response.Redirect("AltaEscuela.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                guardarEscuela();
            }
            catch (SqlException ex)
            {
                Response.Write("<script language=javascript>alert('" + ex.Message + "')</script>");
                throw ex;
            }
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
                Response.Redirect("EditarEscuela.aspx?idCurso=" + e.CommandArgument);
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