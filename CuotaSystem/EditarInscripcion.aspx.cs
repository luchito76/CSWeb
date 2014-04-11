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
    public partial class EditarInscripcion : System.Web.UI.Page
    {
        AlumnoNego alumnoNego = new AlumnoNego();
        InscripcionNego inscripcionNego = new InscripcionNego();
        CursadaNego cursadaNego = new CursadaNego();

        protected void Page_Load(object sender, EventArgs e)
        {
            Login login = new Login();

            if (!login.validarLogin())
                Response.Redirect("Login.aspx");

            if (IsPostBack) return;

            Utility.Utility.checkButtonDoubleClick(btnGuardar, this.Page);
            alerta.Visible = false;
            llenarListas();
            mostrarInscripcion();
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

        private void mostrarInscripcion()
        {
            int idInscripcion = int.Parse(Request["idInscripcion"].ToString());

            Dominio.Inscripcion inscripcion = new Dominio.Inscripcion();
            inscripcion = inscripcionNego.listaInscripcionXIdInscripcion(idInscripcion).FirstOrDefault();

            ddlAlumno.Text = inscripcion.Alumno.IdAlumno.ToString();
            ddlCursada.Text = inscripcion.Cursada.IdCursada.ToString();
            dtpFechaInscripcion.Text = String.Format("{0:dd/MM/yyyy}", inscripcion.FechaInscripcion);
            txtObservaciones.Text = inscripcion.Observaciones;
            inscripcionAnulada.Checked = isActivo(inscripcion.InscripcionAnulada.Value);
        }

        private bool isActivo(bool activo)
        {
            if (activo == true)
                return true;
            else
                return false;
        }

        private bool isInscripcionChecked()
        {
            if (inscripcionAnulada.Checked)
                return true;
            else
                return false;
        }

        private void actualizarInscripcion()
        {
            Dominio.Inscripcion inscripcion = new Dominio.Inscripcion();

            inscripcion.IdInscripcion = int.Parse(Request["idInscripcion"].ToString());
            inscripcion.IdAlumno = int.Parse(ddlAlumno.SelectedValue);
            inscripcion.IdCursada = int.Parse(ddlCursada.SelectedValue);
            inscripcion.FechaInscripcion = Convert.ToDateTime(dtpFechaInscripcion.Text);
            inscripcion.Observaciones = txtObservaciones.Text;
            inscripcion.InscripcionAnulada = isInscripcionChecked();

            inscripcionNego.actualizarInscripcion(inscripcion);

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                actualizarInscripcion();

                alerta.Visible = true;

                string script = @"<script type='text/javascript'>function r() { location.href='ListaInscripciones.aspx' } setTimeout ('r()', 2000);</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "r()", script, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}