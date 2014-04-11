using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using System.Windows.Forms;

namespace CuotaSystem.Cursos
{
    public partial class EditarCurso : System.Web.UI.Page
    {
        CursoNego cursoNego = new CursoNego();
        ConceptoNego conceptoNego = new ConceptoNego();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            Utility.Utility.checkButtonDoubleClick(btnGuardar, this.Page);
            llenarListas();
            mostrarCurso();
        }

        private void llenarListas()
        {
            ddlConceptoCuota.DataSource = conceptoNego.listaConceptosXIdTipoConcepto(1).ToList();
            ddlConceptoCuota.DataBind();

            ddlConceptoMatricula.DataSource = conceptoNego.listaConceptosXIdTipoConcepto(2).ToList();
            ddlConceptoMatricula.DataBind();

            ddlConceptoExamen.DataSource = conceptoNego.listaConceptosXIdTipoConcepto(3).ToList();
            ddlConceptoExamen.DataBind();
        }

        private void mostrarCurso()
        {
            int idCurso = int.Parse(Request["idCurso"].ToString());

            Curso curso = new Curso();
            curso = cursoNego.listaCursoXId(idCurso).FirstOrDefault();

            IList<DevuelveConceptoXCursoResultSet0> listaConceptoXCurso = cursoNego.listaConceptosXCurso(idCurso).ToList();

            int x = 0;
            int[] conceptoXCurso = new int[3];

            foreach (DevuelveConceptoXCursoResultSet0 conceptoXCursoData in listaConceptoXCurso)
            {
                conceptoXCurso[x] = conceptoXCursoData.idConcepto;
                x++;
            }

            txtDescripcion.Text = curso.Nombre;
            ddlConceptoCuota.Text = conceptoXCurso[0].ToString();
            ddlConceptoMatricula.Text = conceptoXCurso[1].ToString();
            ddlConceptoExamen.Text = conceptoXCurso[2].ToString();
            cursoActivo.Checked = isCursoActivo(curso.Activo.Value);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                actualizarCurso();

                alerta.Visible = true;

                string script = @"<script type='text/javascript'>function r() { location.href='ListaCursos.aspx' } setTimeout ('r()', 2000);</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "r()", script, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void actualizarCurso()
        {
            Curso curso = new Curso();

            curso.IdCurso = int.Parse(Request["idCurso"]);
            curso.Nombre = txtDescripcion.Text;

            curso.Activo = isCursoChecked();

            cursoNego.actualizarCurso(curso);

            actualizarConceptoXCurso();
        }

        private void actualizarConceptoXCurso()
        {
            int idCurso = int.Parse(Request["idCurso"].ToString());

            int x = 0;
            int[] idConceptoXCurso = new int[3];

            IList<DevuelveConceptoXCursoResultSet0> listaConceptoXCurso = cursoNego.listaConceptosXCurso(idCurso).ToList();

            foreach (DevuelveConceptoXCursoResultSet0 data in listaConceptoXCurso)
            {
                idConceptoXCurso[x] = data.idConceptoXCurso;
                x++;
            }

            ConceptoXCurso conceptoXCursoCuota = new ConceptoXCurso();

            conceptoXCursoCuota.IdCurso = idCurso;
            conceptoXCursoCuota.IdConcepto = int.Parse(ddlConceptoCuota.SelectedValue);
            conceptoXCursoCuota.IdConceptoXCurso = idConceptoXCurso[0];

            cursoNego.actualizarConceptoXCurso(conceptoXCursoCuota);

            ConceptoXCurso conceptoXCursoMatricula = new ConceptoXCurso();

            conceptoXCursoMatricula.IdCurso = idCurso;
            conceptoXCursoMatricula.IdConcepto = int.Parse(ddlConceptoMatricula.SelectedValue);
            conceptoXCursoMatricula.IdConceptoXCurso = idConceptoXCurso[1];

            cursoNego.actualizarConceptoXCurso(conceptoXCursoMatricula);

            ConceptoXCurso conceptoXCursoExamen = new ConceptoXCurso();

            conceptoXCursoExamen.IdCurso = idCurso;
            conceptoXCursoExamen.IdConcepto = int.Parse(ddlConceptoExamen.SelectedValue);
            conceptoXCursoExamen.IdConceptoXCurso = idConceptoXCurso[2];

            cursoNego.actualizarConceptoXCurso(conceptoXCursoExamen);

        }

        private bool isCursoChecked()
        {
            if (cursoActivo.Checked)
                return true;
            else
                return false;
        }
        private bool isCursoActivo(bool activo)
        {
            if (activo == true)
                return true;
            else
                return false;
        }
    }
}