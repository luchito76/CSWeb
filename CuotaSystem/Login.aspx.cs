using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using System.Text;
using System.Configuration;
using System.Web.Security;

namespace CuotaSystem
{
    public partial class Login : System.Web.UI.Page
    {
        UsuarioNego usuarioNego = new UsuarioNego();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            alerta.Visible = false;
        }

        public bool validarUsuario()
        {
            bool usuarioValidado = false;

            string usuario = txtUsuario.Text;
            string contraseña = txtContraseña.Text;

            Usuario oUsuario = new Usuario();
            oUsuario = new Usuario();
            usuarioNego = new UsuarioNego();

            oUsuario = usuarioNego.listaUsuarioXusuario(usuario).FirstOrDefault();

            string hashedPassword = HashSHA1(contraseña);

            if (oUsuario != null)
            {
                if (oUsuario.Contraseña == hashedPassword)
                {
                    usuarioValidado = true;
                }
            }

            return usuarioValidado;
        }

        private string HashSHA1(string value)
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

        protected void btnEntrar_ServerClick(object sender, EventArgs e)
        {
            string usuarioSession = string.Empty;




            bool usuarioValidado = validarUsuario();

            if (usuarioValidado == true)
            {
                Session["login"] = true;
                Session["usuario"] = txtUsuario.Text;

                Response.Redirect("Default.aspx");
            }
            else
            {
                alerta.Visible = true;

                Utility.Utility.limpiarControles(this.Controls);
            }
        }

        public bool validarLogin()
        {
            bool usuarioValidado = false;
            bool login = Convert.ToBoolean(Session["login"]);

            if ((login == true) && (Session["usuario"] != null))
                usuarioValidado = true;

            else
                usuarioValidado = false;

            return usuarioValidado;
        }
    }
}