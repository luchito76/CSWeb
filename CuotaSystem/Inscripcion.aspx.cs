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
    public partial class Inscripcion : System.Web.UI.Page
    {
        AlumnoNego alumnoNego = new AlumnoNego();
        CursadaNego cursadaNego = new CursadaNego();
        InscripcionNego inscripcionNego = new InscripcionNego();        

        protected void Page_Load(object sender, EventArgs e)
        {
            Login login = new Login();

            if (!login.validarLogin())
                Response.Redirect("Login.aspx");

            if (IsPostBack) return;

            Utility.Utility.checkButtonDoubleClick(btnGuardar, this.Page);
            alerta.Visible = false;
            llenarListas();
        }

        private void llenarListas()
        {
            IList<Alumno> nombreCompletoAlumno = alumnoNego.listaAlumnos().Select(p => new Alumno() { Nombre = p.Apellido + " " + p.Nombre, IdAlumno = p.IdAlumno }).OrderBy(c => c.Apellido).ToList();

            ddlAlumno.DataSource = nombreCompletoAlumno;
            ddlAlumno.DataBind();
            ddlAlumno.Items.Insert(0, new ListItem("--Seleccione--", "0"));

            ddlCursada.DataSource = cursadaNego.listaCursadaXCurso().ToList();
            ddlCursada.DataBind();
            ddlCursada.Items.Insert(0, new ListItem("--Seleccione--", "0"));           
        }

        private void guardarCursada()
        {
            Dominio.Inscripcion inscripcion = new Dominio.Inscripcion();

            inscripcion.IdAlumno = int.Parse(ddlAlumno.SelectedValue);
            inscripcion.IdCursada = int.Parse(ddlCursada.SelectedValue);
            inscripcion.FechaInscripcion = Convert.ToDateTime(dtpFechaInscripcion.Text);
            inscripcion.InscripcionAnulada = false;
            inscripcion.Observaciones = txtObservaciones.Text;

            inscripcionNego.guardarInscripcion(inscripcion);            
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