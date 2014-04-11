using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Dominio;
using Negocio;

namespace CuotaSystem
{
    public partial class AgregarHermano : System.Web.UI.Page
    {
        AlumnoNego alumnoNego = new AlumnoNego();
        GrupoFamiliarNego grupoFamiliarNego = new GrupoFamiliarNego();

        protected void Page_Load(object sender, EventArgs e)
        {
            Login login = new Login();

            if (!login.validarLogin())
                Response.Redirect("Login.aspx");

            if (IsPostBack) return;
            Utility.Utility.checkButtonDoubleClick(btnGuardar, this.Page);
            alerta.Visible = false;
            llenarListas();
        }

        private void llenarListas()
        {
            IList<Alumno> nombreCompleto = alumnoNego.listaAlumnos().Select(p => new Alumno() { Nombre = p.Apellido + " " + p.Nombre, IdAlumno = p.IdAlumno}).OrderBy(c => c.Apellido).ToList();
            
            ddlAlumno.DataSource = nombreCompleto;
            ddlAlumno.DataBind();
            ddlAlumno.Items.Insert(0, new ListItem("--Seleccione--", "0"));

            ddlHermano.DataSource = nombreCompleto;
            ddlHermano.DataBind();
            ddlHermano.Items.Insert(0, new ListItem("--Seleccione--", "0"));
        }

        private string crearGrupoFamiliar(string apellido)
        {
            string codigo = String.Empty;
            int x = 1;

            do
            {
                codigo = apellido.Substring(0, 3) + "0" + x;
                x++;

            } while (existeGrupoFamiliar(codigo));

            return codigo;
        }

        /// <summary>
        /// Método que verficia si el grupo familiar creado existe.
        /// </summary>
        /// <returns></returns>
        private bool existeGrupoFamiliar(string codigo)
        {
            bool grupoFamiliar = false;

            IList<GrupoFamiliar> lista = grupoFamiliarNego.listaGrupoFamiliar().ToList();

            foreach (GrupoFamiliar grupo in lista)
            {
                if (codigo == grupo.NombreGrupoFamiliar)
                    grupoFamiliar = true;
            }

            return grupoFamiliar;
        }

        private void guardarHermano()
        {
            if (compruebaHermanos(int.Parse(ddlAlumno.SelectedValue)))
            {
                GrupoFamiliarXAlumno grupoFamiliarXAlumno = new GrupoFamiliarXAlumno();
                grupoFamiliarXAlumno.IdAlumno = int.Parse(ddlHermano.SelectedValue);
                grupoFamiliarXAlumno.IdGrupoFamiliar = devuelveGrupoFamiliar();

                grupoFamiliarNego.guardarGrupoFamiliarXAlumno(grupoFamiliarXAlumno);
            }
            else
            {
                GrupoFamiliar grupoFamiliar = new GrupoFamiliar();

                string apellido = ddlAlumno.SelectedItem.Text;

                grupoFamiliar.NombreGrupoFamiliar = crearGrupoFamiliar(apellido);

                grupoFamiliarNego.crearGrupoFamiliar(grupoFamiliar);

                guardaGrupoFamiliarXAlumno(devuelveGrupoFamiliar());
            }
        }

        /// <summary>
        /// Si el alumno seleccionado ya tiene un hermano y se le quiere agregar un tercero, el método devuelve el grupo familiar que corresponde
        /// al alumno.
        /// </summary>
        /// <param name="idAlumno"></param>
        /// <returns></returns>
        private string devuelveGrupoFamiliar(int idAlumno)
        {
            string grupo = String.Empty;

            IList<GrupoFamiliarXAlumno> lista = grupoFamiliarNego.listaGrupoFamiliarXIdAlumno(idAlumno).ToList();

            foreach (GrupoFamiliarXAlumno dato in lista)
            {
                int idGrupoFamiliar = int.Parse(dato.IdGrupoFamiliar.ToString());
                IList<GrupoFamiliar> listaGrupo = grupoFamiliarNego.listaGrupoFamiliarXIdGrupoFamiliar(idGrupoFamiliar).ToList();

                foreach (GrupoFamiliar grupoFamiliar in listaGrupo)
                {
                    grupo = grupoFamiliar.NombreGrupoFamiliar;
                }
            }

            return grupo;
        }

        private void guardaGrupoFamiliarXAlumno(int idGrupoFamiliar)
        {
            GrupoFamiliarXAlumno grupoFamiliarXALumno = new GrupoFamiliarXAlumno();

            grupoFamiliarXALumno.IdAlumno = int.Parse(ddlAlumno.SelectedValue);
            grupoFamiliarXALumno.IdGrupoFamiliar = idGrupoFamiliar;

            grupoFamiliarNego.guardarGrupoFamiliarXAlumno(grupoFamiliarXALumno);

            GrupoFamiliarXAlumno grupoFamiliarXALumno1 = new GrupoFamiliarXAlumno();

            grupoFamiliarXALumno1.IdAlumno = int.Parse(ddlHermano.SelectedValue);
            grupoFamiliarXALumno1.IdGrupoFamiliar = idGrupoFamiliar;

            grupoFamiliarNego.guardarGrupoFamiliarXAlumno(grupoFamiliarXALumno1);
        }

        /// <summary>
        /// Devuelve el utlimo grupo familiar creado para guardar los hermanos con este grupo familiar.
        /// </summary>
        /// <returns></returns>
        private int devuelveGrupoFamiliar()
        {
            GrupoFamiliar grupoFamiliar = new GrupoFamiliar();
            int idGrupoFamiliar = grupoFamiliarNego.obtieneUltimoGrupoFamiliar().IdGrupoFamiliar;

            return idGrupoFamiliar;
        }

        /// <summary>
        /// El método verifica si el alumno seleccionado ya tiene hermanos asociados para usar su grupo familiar y no crear uno nuevo.
        /// </summary>
        /// <param name="idAlumno"></param>
        /// <returns></returns>
        private bool compruebaHermanos(int idAlumno)
        {
            bool hermano = false;

            IList<GrupoFamiliarXAlumno> lista = grupoFamiliarNego.listaGrupoFamiliarXIdAlumno(idAlumno).ToList();

            if (lista.Count > 0)
                hermano = true;

            return hermano;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                guardarHermano();

                alerta.Visible = true;

                string script = @"<script type='text/javascript'>function r() { window.close(); } setTimeout ('r()', 2000);</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "r()", script, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}