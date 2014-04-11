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
    public partial class AltaFliaAutorizada : System.Web.UI.Page
    {

        AlumnoNego alumnoNego = new AlumnoNego();
        AutorizadosNego autorizadoNego = new AutorizadosNego();
        ParentescoNego parentescoNego = new ParentescoNego();

        protected void Page_Load(object sender, EventArgs e)
        {
            Login login = new Login();

            if (!login.validarLogin())
                Response.Redirect("Login.aspx");

            if (IsPostBack) return;

            Utility.Utility.checkButtonDoubleClick(btnGuardar, this.Page);
            validaSoloNumeros();
            alerta.Visible = false;
            llenarCombos();
        }

        private void validaSoloNumeros()
        {
            txtTelFijo.Attributes.Add("onkeypress",
      "return validarNumero(event,'" + btnGuardar.ClientID + "')");

            txtTelCelular.Attributes.Add("onkeypress",
            "return validarNumero(event,'" + btnGuardar.ClientID + "')");
        }

        private void llenarCombos()
        {
            IList<Alumno> nombreCompletoAlumno = alumnoNego.listaAlumnos().Select(p => new Alumno() { Nombre = p.Apellido + " " + p.Nombre, IdAlumno = p.IdAlumno }).OrderBy(c => c.Apellido).ToList();
            IList<Autorizado> nombreCompletoAutorizado = autorizadoNego.listaAutorizados().Select(p => new Autorizado() { Nombre = p.Apellido + " " + p.Nombre, IdAutorizado = p.IdAutorizado }).OrderBy(c => c.Apellido).ToList();

            ddlAutorizado.DataSource = nombreCompletoAutorizado;
            ddlAutorizado.DataBind();
            ddlAutorizado.Items.Insert(0, new ListItem("--Seleccione--", "0"));

            ddlAlumno.DataSource = nombreCompletoAlumno;
            ddlAlumno.DataBind();
            ddlAlumno.Items.Insert(0, new ListItem("--Seleccione--", "0"));

            ddlParentesco.DataSource = parentescoNego.listaParentesco();
            ddlParentesco.DataBind();
            ddlParentesco.Items.Insert(0, new ListItem("--Seleccione--", "0"));
        }

        private void guardarFliaAutorizada()
        {
            Autorizado autorizados = new Autorizado();

            autorizados.Nombre = txtNombre.Text;
            autorizados.Apellido = txtApellido.Text;
            autorizados.TelefonoFijo = Convert.ToInt64(txtTelFijo.Text);
            autorizados.TelefonoCelular = Convert.ToInt64(txtTelCelular.Text);
            autorizados.Direccion = txtDireccion.Text;
            autorizados.Mail = txtMail.Text;

            autorizadoNego.altaFliaAutorizada(autorizados);
        }

        private void guardarRelacionAutrizado()
        {
            AutorizadosXAlumno autorizadoXAlumno = new AutorizadosXAlumno();

            autorizadoXAlumno.IdParentesco = int.Parse(ddlParentesco.SelectedValue);
            autorizadoXAlumno.IdAlumno = int.Parse(ddlAlumno.SelectedValue);
            autorizadoXAlumno.IdAutorizado = int.Parse(ddlAutorizado.SelectedValue);

            autorizadoNego.guardarAutorizadoXAlumno(autorizadoXAlumno);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                guardarFliaAutorizada();

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

        protected void cargar_Click(object sender, EventArgs e)
        {
            guardarRelacionAutrizado();
        }
    }
}