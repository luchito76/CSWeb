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
    public partial class EditarCursada : System.Web.UI.Page
    {
        CursoNego cursoNego = new CursoNego();
        CursadaNego cursadaNego = new CursadaNego();
        Cursada cursada = new Cursada();        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            Utility.Utility.checkButtonDoubleClick(btnGuardar, this.Page);
            llenarListas();
            mostrarCurso();
        }

        private void llenarListas()
        {
            ddlCurso.DataSource = cursoNego.listaCursos().ToList();
            ddlCurso.DataBind();            
        }

        private void mostrarCurso()
        {
            int idCursada = int.Parse(Request["idCursada"]);

            cursada = cursadaNego.listaCursadaXId(idCursada).FirstOrDefault();

            ddlCurso.Text = cursada.Curso.IdCurso.ToString();           
            dtpFechaInicio.Text = String.Format("{0:dd/MM/yyyy}", cursada.FechaInicio);
            dtpFechaFin.Text = String.Format("{0:dd/MM/yyyy}", cursada.FechaFin);
        }

        private void actualizarCursada() { 
            cursada.IdCursada = int.Parse(Request["idCursada"].ToString());
            cursada.IdCurso = int.Parse(ddlCurso.SelectedValue);                  
            cursada.FechaInicio = Convert.ToDateTime(dtpFechaInicio.Text);
            cursada.FechaFin = Convert.ToDateTime(dtpFechaFin.Text);
            cursada.Activo = true;

            cursadaNego.actualizarCursada(cursada);
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                actualizarCursada();

                alerta.Visible = true;

                string script = @"<script type='text/javascript'>function r() { location.href='ListaCursadas.aspx' } setTimeout ('r()', 2000);</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "r()", script, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}