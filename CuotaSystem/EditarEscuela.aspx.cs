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
    public partial class EditarEscuela : System.Web.UI.Page
    {
        EscuelaNego escuelaNego = new EscuelaNego();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            Utility.Utility.checkButtonDoubleClick(btnGuardar, this.Page);
            mostrarEscuela();
        }

        private void mostrarEscuela()
        {
            int idEscuela = int.Parse(Request["idEscuela"].ToString());

            Escuela escuela = new Escuela();
            escuela = escuelaNego.listaEscuelasXIdEscuela(idEscuela).FirstOrDefault();

            txtDescripcion.Text = escuela.Nombre;
            escuelaActivo.Checked = isEscuelaActivo(escuela.Activo.Value);
        }

        private void actualizarEscuela()
        {
            Escuela escuela = new Escuela();

            escuela.IdEscuela = int.Parse(Request["idEscuela"]);
            escuela.Nombre = txtDescripcion.Text;
            escuela.Activo = isEscuelaChecked();

            escuelaNego.actualizarEscuela(escuela);
        }

        private bool isEscuelaChecked()
        {
            if (escuelaActivo.Checked)
                return true;
            else
                return false;
        }
        private bool isEscuelaActivo(bool activo)
        {
            if (activo == true)
                return true;
            else
                return false;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                actualizarEscuela();

                string script = @"<script type='text/javascript'>Confirmacion();</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Confirmacion()", script, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}