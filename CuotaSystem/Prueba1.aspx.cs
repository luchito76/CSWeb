using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace CuotaSystem
{
    public partial class Prueba1 : System.Web.UI.Page
    {
        AlumnoNego alumno = new AlumnoNego();

        protected void Page_Load(object sender, EventArgs e)
        {
            llenarTabla();
        }

        private void llenarTabla()
        {
            gdvPrueba.DataSource = alumno.listaAlumnos().ToList();
            gdvPrueba.DataBind();
        }
    }
}