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
    public partial class Cursadas : System.Web.UI.Page
    {
        CursoNego cursoNego = new CursoNego();
        CursadaNego cursadaNego = new CursadaNego();        

        protected void Page_Load(object sender, EventArgs e)
        {
            Login login = new Login();

            if (!login.validarLogin())
                Response.Redirect("Login.aspx");

            if (IsPostBack) return;

            Utility.Utility.checkButtonDoubleClick(btnGuardar, this.Page);
            llenarListas();
        }

        private void llenarListas()
        {
            ddlCurso.DataSource = cursoNego.listaCursos().ToList();
            ddlCurso.DataBind();
            ddlCurso.Items.Insert(0, new ListItem("--Seleccion--", "0"));
            ddlCurso.Items.Insert(0, new ListItem("--Seleccione--", "0"));           
        }

        private void guardarCursada()
        {
            Cursada cursada = new Cursada();

            cursada.IdCurso = int.Parse(ddlCurso.SelectedValue);
            cursada.FechaInicio = Convert.ToDateTime(dtpFechaInicio.Text);
            cursada.FechaFin = Convert.ToDateTime(dtpFechaFin.Text);            
            cursada.Activo = true;

            cursadaNego.guardarCursada(cursada);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                guardarCursada();

                alerta.Visible = true;

                Utility.Utility.limpiarControles(this.Controls);

                string script = @"<script type='text/javascript'>function r() {  } setTimeout ('r()', 2000);</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "r()", script, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}