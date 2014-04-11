using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Dominio;
using Negocio;

namespace CuotaSystem.Cursos
{
    public partial class AltaCurso : System.Web.UI.Page
    {

        CursoNego cursoNego = new CursoNego();
        ConceptoNego conceptoNego = new ConceptoNego();

        protected void Page_Load(object sender, EventArgs e)
        {
            Login login = new Login();

            if (!login.validarLogin())
                Response.Redirect("Login.aspx");

            Utility.Utility.checkButtonDoubleClick(btnGuardar, this.Page);
            llenarTabla();

            if (IsPostBack) return;

            llenarListas();
        }

        private void guardarCurso()
        {
            Curso curso = new Curso();

            curso.Nombre = txtDescripcion.Text;
            curso.Activo = true;

            cursoNego.guardarCurso(curso);

            guardarConceptoXCurso();

            Response.Redirect("AltaCurso.aspx");
        }

        private void guardarConceptoXCurso()
        {
            int idCurso = cursoNego.obtieneUltimoIdCurso().IdCurso;

            ConceptoXCurso conceptoXCursoCuota = new ConceptoXCurso();

            conceptoXCursoCuota.IdCurso = idCurso;
            conceptoXCursoCuota.IdConcepto = int.Parse(ddlConceptoCuota.SelectedValue);

            ConceptoXCurso conceptoXCursoMatricula = new ConceptoXCurso();

            conceptoXCursoMatricula.IdCurso = idCurso;
            conceptoXCursoMatricula.IdConcepto = int.Parse(ddlConceptoMatricula.SelectedValue);

            ConceptoXCurso conceptoXCursoExamen = new ConceptoXCurso();

            conceptoXCursoExamen.IdCurso = idCurso;
            conceptoXCursoExamen.IdConcepto = int.Parse(ddlConceptoExamen.SelectedValue);

            cursoNego.guardarConceptoXCurso(conceptoXCursoCuota);
            cursoNego.guardarConceptoXCurso(conceptoXCursoMatricula);
            cursoNego.guardarConceptoXCurso(conceptoXCursoExamen);
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                guardarCurso();
            }
            catch (SqlException ex)
            {
                Response.Write("<script language=javascript>alert('" + ex.Message + "')</script>");
                throw ex;
            }
        }

        private void llenarListas()
        {
            ddlConceptoCuota.DataSource = conceptoNego.listaConceptosXIdTipoConcepto(1).ToList();
            ddlConceptoCuota.DataBind();
            ddlConceptoCuota.Items.Insert(0, new ListItem("--Seleccione--", "0"));

            ddlConceptoMatricula.DataSource = conceptoNego.listaConceptosXIdTipoConcepto(2).ToList();
            ddlConceptoMatricula.DataBind();
            ddlConceptoMatricula.Items.Insert(0, new ListItem("--Seleccione--", "0"));

            ddlConceptoExamen.DataSource = conceptoNego.listaConceptosXIdTipoConcepto(3).ToList();
            ddlConceptoExamen.DataBind();
            ddlConceptoExamen.Items.Insert(0, new ListItem("--Seleccione--", "0"));
        }

        private void llenarTabla()
        {
            gdvListaCursos.DataSource = cursoNego.listaCursos().ToList();
            gdvListaCursos.DataBind();
        }

        protected void gdvListaCursos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Curso"))
            {
                Response.Redirect("EditarCurso.aspx?idCurso=" + e.CommandArgument);
            }
        }

        protected void gdvListaCursos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            gdvListaCursos.PageIndex = e.NewSelectedIndex;
            gdvListaCursos.DataBind();
        }

        protected void gdvListaCursos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvListaCursos.PageIndex = e.NewPageIndex;
            gdvListaCursos.DataBind();
        }

        protected void lnkEditarCurso_Click(object sender, EventArgs e)
        {
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            string rowNumber = grdrow.Cells[0].Text;
            string dealId = grdrow.Cells[1].Text;
            string dealTitle = grdrow.Cells[2].Text;
            Response.Redirect("EditarCurso.aspx?idCurso=" + int.Parse(rowNumber));
        }
    }
}