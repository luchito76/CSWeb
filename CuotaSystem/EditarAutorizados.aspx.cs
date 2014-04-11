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
    public partial class EditarAutorizados : System.Web.UI.Page
    {
        AutorizadosNego autorizadosNego = new AutorizadosNego();

        Autorizado autorizado = new Autorizado();

        protected void Page_Load(object sender, EventArgs e)
        {
            Login login = new Login();

            if (!login.validarLogin())
                Response.Redirect("Login.aspx");

            if (IsPostBack) return;

            Utility.Utility.checkButtonDoubleClick(btnGuardar, this.Page);
            validaSoloNumeros();
            mostrarAutorizados();
        }

        private void validaSoloNumeros()
        {
            txtTelFijo.Attributes.Add("onkeypress",
      "return validarNumero(event,'" + btnGuardar.ClientID + "')");

            txtTelCelular.Attributes.Add("onkeypress",
            "return validarNumero(event,'" + btnGuardar.ClientID + "')");
        }

        private void mostrarAutorizados()
        {
            int idAutorizado = int.Parse(Request["idAutorizado"].ToString());

            autorizado = autorizadosNego.listaFliaAutorizadoXId(idAutorizado).FirstOrDefault();

            txtNombre.Text = autorizado.Nombre;
            txtApellido.Text = autorizado.Apellido;
            txtTelFijo.Text = autorizado.TelefonoFijo.ToString();
            txtTelCelular.Text = autorizado.TelefonoCelular.ToString();
            txtDireccion.Text = autorizado.Direccion;
            txtMail.Text = autorizado.Mail;
        }

        private void actualizarAutorizado()
        {
            autorizado.IdAutorizado = int.Parse(Request["idAutorizado"].ToString());
            autorizado.Nombre = txtNombre.Text;
            autorizado.Apellido = txtApellido.Text;
            autorizado.TelefonoFijo = Convert.ToInt64(txtTelFijo.Text);
            autorizado.TelefonoCelular = Convert.ToInt64(txtTelCelular.Text);
            autorizado.Direccion = txtDireccion.Text;
            autorizado.Mail = txtMail.Text;

            autorizadosNego.actualizarFliaAutorizada(autorizado);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                actualizarAutorizado();

                alerta.Visible = true;

                string script = @"<script type='text/javascript'>function r() { location.href='ListaAutorizados.aspx' } setTimeout ('r()', 2000);</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "r()", script, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}