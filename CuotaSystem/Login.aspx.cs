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
    public partial class Login : System.Web.UI.Page
    {
        UsuarioNego usuarioNego = new UsuarioNego();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private int validarUsuario()
        {
            int idUsuario = 0;
            string usuario = txtUsuario.Text;//user.Value;
            string contraseña = txtContraseña.Text;//passw.Value;


            Usuario oUsuario = new Usuario();
            oUsuario = usuarioNego.listaUsuarioXusuario(usuario).FirstOrDefault();

            string hashedPassword = HashSHA1(contraseña);

            if (oUsuario.Contraseña == hashedPassword)
            {
                idUsuario = oUsuario.IdUsuario;
            }

            return idUsuario;
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
            int idUsuario = validarUsuario();

            if (idUsuario > 0)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                Response.Redirect("Error_404.aspx");
            }
        }
    }
}