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
    public partial class EditarAlumnos : System.Web.UI.Page
    {
        GradoNego gradoNego = new GradoNego();
        EscuelaNego escuelaNego = new EscuelaNego();
        AlumnoNego alumnoNego = new AlumnoNego();
        TipoDeAlumnoNego tipoDeAlumnoNego = new TipoDeAlumnoNego();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            Utility.Utility.checkButtonDoubleClick(btnGuardar, this.Page);
            validaSoloNumeros();
            mostrarAlumno();
            llenarListas();
        }

        private void validaSoloNumeros()
        {
            txtDni.Attributes.Add("onkeypress",
      "return validarNumero(event,'" + btnGuardar.ClientID + "')");

            txtTelefono.Attributes.Add("onkeypress",
            "return validarNumero(event,'" + btnGuardar.ClientID + "')");
        }

        private void llenarListas()
        {
            ddlEscuela.DataSource = escuelaNego.listaEscuelas().ToList();
            ddlEscuela.DataBind();

            ddlGrado.DataSource = gradoNego.listaGrados().ToList();
            ddlGrado.DataBind();

            ddlTipoDeAlumno.DataSource = tipoDeAlumnoNego.listaTiposDeAlumnos().ToList();
            ddlTipoDeAlumno.DataBind();
        }
        private void mostrarAlumno()
        {
            int idAlumno = int.Parse(Request["idAlumno"]);

            Alumno alumno = new Alumno();
            alumno = alumnoNego.listaAlumnosXIdAlumno(idAlumno).FirstOrDefault();

            txtNombre.Text = alumno.Nombre;
            txtApellido.Text = alumno.Apellido;
            txtDni.Text = alumno.Dni;
            dtpFechaNacimiento.Text = String.Format("{0:dd/MM/yyyy}", alumno.FechaNacimiento);
            ddlEscuela.Text = alumno.Escuela.IdEscuela.ToString();
            ddlGrado.Text = alumno.Grado.IdGrado.ToString();
            ddlTurno.Text = alumno.Turno.ToString();
            txtTelefono.Text = alumno.Telefono.ToString();
            chkLibretaSanitaria.Checked = isActivo(alumno.LibretaSanitaria.Value);
            txtMail.Text = alumno.Mail;
            txtDireccion.Text = alumno.Direccion;
            txtCiudad.Text = alumno.Ciudad;
            txtNombrePadre.Text = alumno.NombrePadre;
            txtNombreMadre.Text = alumno.NombreMadre;
            ddlTipoDeAlumno.Text = alumno.TipoDeAlumno.IdTipoAlumno.ToString();
            txtObservaciones.Text = alumno.Observaciones;
            alumnoActivo.Checked = isActivo(alumno.Activo.Value);
        }

        private bool isActivo(bool activo)
        {
            if (activo == true)
                return true;
            else
                return false;
        }

        private void actualizarAlumno()
        {
            Alumno alumno = new Alumno();

            if (dtpFechaNacimiento.Text != null && dtpFechaNacimiento.Text != " ")
                alumno.FechaNacimiento = Convert.ToDateTime(dtpFechaNacimiento.Text);

            alumno.IdAlumno = int.Parse(Request["idAlumno"]);
            alumno.Nombre = txtNombre.Text;
            alumno.Apellido = txtApellido.Text;
            alumno.Dni = txtDni.Text;
            alumno.IdEscuela = int.Parse(ddlEscuela.SelectedValue);
            alumno.IdGrado = int.Parse(ddlGrado.SelectedValue);
            alumno.Telefono = (txtTelefono.Text != "") ? Convert.ToInt64(txtTelefono.Text) : 0;
            alumno.Turno = ddlTurno.SelectedValue;
            alumno.LibretaSanitaria = tieneLIbretaSanitaria();
            alumno.Mail = txtMail.Text;
            alumno.Ciudad = txtCiudad.Text;
            alumno.Direccion = txtDireccion.Text;
            alumno.NombrePadre = txtNombrePadre.Text;
            alumno.NombreMadre = txtNombreMadre.Text;
            alumno.IdTipoAlumno = int.Parse(ddlTipoDeAlumno.SelectedValue);
            alumno.Observaciones = txtObservaciones.Text;
            alumno.Activo = isAlumnoChecked();

            alumnoNego.actualizarAlumno(alumno);
        }

        private bool isAlumnoActivo(bool activo)
        {
            if (activo == true)
                return true;
            else
                return false;
        }

        private bool isAlumnoChecked()
        {
            if (alumnoActivo.Checked)
                return true;
            else
                return false;
        }

        private bool tieneLIbretaSanitaria()
        {
            if (chkLibretaSanitaria.Checked)
                return true;
            else
                return false;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                btnGuardar.Enabled = false;

                actualizarAlumno();

                alerta.Visible = true;

                string script = @"<script type='text/javascript'>function r() { location.href='ListaAlumnos.aspx' } setTimeout ('r()', 2000);</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "r()", script, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}