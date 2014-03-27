using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace CuotaSystem
{
    public partial class ListaHermanos : System.Web.UI.Page
    {
        GrupoFamiliarNego grupoFamiliarNego = new GrupoFamiliarNego();
        AlumnoNego alumnoNego = new AlumnoNego();

        int idGrupoFamiliar = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            llenarListas();

            llenarTabla(idGrupoFamiliar);
        }

        private void llenarTabla(int idGrupoFamiliar)
        {
            gdvHermanos.DataSource = grupoFamiliarNego.listaHermanos(idGrupoFamiliar).ToList();
            gdvHermanos.DataBind();
        }

        private void llenarListas()
        {
            ddlAlumno.DataSource = grupoFamiliarNego.listaHermanos(idGrupoFamiliar).ToList();
            ddlAlumno.DataBind();
            ddlAlumno.Items.Insert(0, new ListItem("--Seleccione--", "0"));
        }

        protected void ddlAlumno_SelectedIndexChanged(object sender, EventArgs e)
        {
            gdvHermanos.Visible = true;

            int idAlumno = int.Parse(ddlAlumno.SelectedValue);

            IList<GrupoFamiliarXAlumno> lista = grupoFamiliarNego.listaGrupoFamiliarXIdAlumno(idAlumno).ToList();

            foreach (GrupoFamiliarXAlumno data in lista)
            {
                idGrupoFamiliar = data.GrupoFamiliar.IdGrupoFamiliar;
            }

            llenarTabla(idGrupoFamiliar);
        }
    }
}