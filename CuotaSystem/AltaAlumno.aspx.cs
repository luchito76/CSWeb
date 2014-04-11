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
    public partial class AltaAlumno : System.Web.UI.Page
    {
        AlumnoNego alumnoNego = new AlumnoNego();
        EscuelaNego escuelaNego = new EscuelaNego();
        GradoNego gradoNego = new GradoNego();
        TipoDeAlumnoNego tipoDeAlumnoNego = new TipoDeAlumnoNego();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            Utility.Utility.checkButtonDoubleClick(btnGuardar, this.Page);
            validaSoloNumeros();
            alerta.Visible = false;
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
            ddlEscuela.Items.Insert(0, new ListItem("--Seleccione--", "0"));

            ddlGrado.DataSource = gradoNego.listaGrados().ToList();
            ddlGrado.DataBind();
            ddlGrado.Items.Insert(0, new ListItem("--Seleccione--", "0"));

            ddlTipoDeAlumno.DataSource = tipoDeAlumnoNego.listaTiposDeAlumnos().ToList();
            ddlTipoDeAlumno.DataBind();
            ddlTipoDeAlumno.Items.Insert(0, new ListItem("--Seleccione--", "0"));
        }

        public void guardarAlumno()
        {
            Alumno alumno = new Alumno();

            if ((dtpFechaNacimiento.Text != null) && (dtpFechaNacimiento.Text != ""))
                alumno.FechaNacimiento = Convert.ToDateTime(dtpFechaNacimiento.Text);

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
            alumno.Activo = true;

            alumnoNego.guardarAlumno(alumno);
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
                guardarAlumno();

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