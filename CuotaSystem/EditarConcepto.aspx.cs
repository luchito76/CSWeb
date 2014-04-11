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
    public partial class EditarConcepto : System.Web.UI.Page
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
            mostrarConcepto();
            llenarListas();
            alerta.Visible = false;
        }

        private void llenarListas()
        {
            ddlTipoDeConcepto.DataSource = tipoDeConceptoNego.listaTipoDeConceptos().ToList();
            ddlTipoDeConcepto.DataBind();            
        }

        private void mostrarConcepto()
        {
            int idConcepto = int.Parse(Request["idConcepto"].ToString());

            Concepto concepto = new Concepto();
            concepto = conceptoNego.listaConceptosXIdConcepto(idConcepto).FirstOrDefault();

            ddlTipoDeConcepto.Text = concepto.TipoDeConcepto.IdTipoDeConcepto.ToString();
            txtDescripcion.Text = concepto.Nombre;
            txtValorConcepto.Text = String.Format("{0:0.00}", concepto.ValorConcepto);
            conceptoActivo.Checked = isConceptoActivo(concepto.Activo.Value);
        }

        private bool isConceptoActivo(bool activo)
        {
            if (activo == true)
                return true;
            else
                return false;
        }

        private bool isConceptChecked()
        {
            if (conceptoActivo.Checked)
                return true;
            else
                return false;
        }

        private void actualizarConcepto()
        {
            Concepto concepto = new Concepto();

            concepto.IdConcepto = int.Parse(Request["idConcepto"].ToString());
            concepto.IdTipoDeConcepto = int.Parse(ddlTipoDeConcepto.SelectedValue);
            concepto.Nombre = txtDescripcion.Text;
            concepto.ValorConcepto = Convert.ToDecimal(txtValorConcepto.Text);
            concepto.Activo = isConceptChecked();

            conceptoNego.actualizarConcepto(concepto);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                actualizarConcepto();
                alerta.Visible = true;

                string script = @"<script type='text/javascript'>function r() { location.href='ListaConceptos.aspx' } setTimeout ('r()', 2000);</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "r()", script, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}