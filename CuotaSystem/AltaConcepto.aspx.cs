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
    public partial class AltaConcepto : System.Web.UI.Page
    {
        ConceptoNego conceptoNego = new ConceptoNego();
        TipoDeConceptosNego tipoDeConceptoNego = new TipoDeConceptosNego();

        protected void Page_Load(object sender, EventArgs e)
        {
            Login login = new Login();

            if (!login.validarLogin())
                Response.Redirect("Login.aspx");

            if (IsPostBack) return;

            Utility.Utility.checkButtonDoubleClick(btnGuardar, this.Page);
            validaSoloNumeros();
            llenarListas();
            llenarTablas();
        }

        private void validaSoloNumeros()
        {
            txtValorConcepto.Attributes.Add("onkeypress",
      "return validarNumero(event,'" + btnGuardar.ClientID + "')");
        }

        private void llenarListas()
        {
            ddlTipoDeConcepto.DataSource = tipoDeConceptoNego.listaTipoDeConceptos().ToList();
            ddlTipoDeConcepto.DataBind();
            ddlTipoDeConcepto.Items.Insert(0, new ListItem("--Seleccione--", "0"));
        }

        private void llenarTablas()
        {
            gdvListaConceptos.DataSource = conceptoNego.listaConceptos().ToList(); ;
            gdvListaConceptos.DataBind();
        }

        private void guardarConcepto()
        {
            Concepto concepto = new Concepto();

            concepto.Nombre = txtDescripcion.Text;
            concepto.ValorConcepto = Decimal.Parse(txtValorConcepto.Text);
            concepto.IdTipoDeConcepto = int.Parse(ddlTipoDeConcepto.SelectedValue);
            concepto.Activo = true;

            conceptoNego.guardarConcepto(concepto);

            Response.Redirect("AltaConcepto.aspx");
        }

        protected void gdvListaConceptos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Escuela"))
            {
                Response.Redirect("EditarConcepto.aspx?idConcepto=" + e.CommandArgument);
            }
        }

        protected void gdvListaConceptos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            gdvListaConceptos.PageIndex = e.NewSelectedIndex;
            gdvListaConceptos.DataBind();
        }

        protected void gdvListaConceptos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvListaConceptos.PageIndex = e.NewPageIndex;
            gdvListaConceptos.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                guardarConcepto();

                Utility.Utility.limpiarControles(this.Controls);
            }
            catch (Exception ex)
            {
                Response.Write("<script language=javascript>alert('" + ex.Message + "')</script>");
                throw ex;
            }
        }
    }
}