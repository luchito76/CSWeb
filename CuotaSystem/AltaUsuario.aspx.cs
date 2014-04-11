using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using System.Text;

namespace CuotaSystem
{
    public partial class AltaUsuario : System.Web.UI.Page
    {
        UsuarioNego usuarioNego = new UsuarioNego();

        protected void Page_Load(object sender, EventArgs e)
        {
            Login login = new Login();

            if (!login.validarLogin())
                Response.Redirect("Login.aspx");
        }

        private void agregarUsuario()
        {
            Usuario usuario = new Usuario();

            usuario.Nombre = txtNombre.Text;
            usuario.Apellido = txtApellido.Text;
            usuario.Usuario1 = txtUsuario.Text;
            usuario.Admin = true;
            usuario.Contraseña = validaContraseña(txtContraseña.Text); //HashSHA1(txtContraseña.Text);

            usuarioNego.agregraUsuario(usuario);
        }

        private string validaContraseña(string contraseña)
        {
            string clave = string.Empty;


            if (contraseña == txtContraseñaValida.Text)
            {
                clave = HashSHA1(txtContraseña.Text);
            }
            else { 
                errorClave.Visible = true;
                throw new Exception();
            }

            return clave;
        }

        private static string HashSHA1(string value)
        {
            var sha1 = System.Security.Cryptography.SHA1.Create();
            var inputBytes = Encoding.ASCII.GetBytes(value);
            var hash = sha1.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                agregarUsuario();

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