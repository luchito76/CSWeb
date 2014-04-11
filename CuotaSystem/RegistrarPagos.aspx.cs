using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace CuotaSystem
{
    public partial class RegistrarPagos : System.Web.UI.Page
    {
        AlumnoNego alumnoNego = new AlumnoNego();
        ConceptoNego conceptoNego = new ConceptoNego();
        TipoDeConceptosNego tipoDeConceptoNego = new TipoDeConceptosNego();
        PagosNego pagosNego = new PagosNego();
        MesNego mesNego = new MesNego();
        InscripcionNego inscripcionNego = new InscripcionNego();

        PagoDeCuotas pagarCuota = new PagoDeCuotas();
        PagoDeMatricula pagoDeMatricula = new PagoDeMatricula();
        PagoExamen pagoExamen = new PagoExamen();

        Login login = new Login();

        [Serializable]
        public class MyJsonDictionary<K, V> : ISerializable
        {
            Dictionary<K, V> dict = new Dictionary<K, V>();

            public MyJsonDictionary() { }

            protected MyJsonDictionary(SerializationInfo info, StreamingContext context)
            {
                throw new NotImplementedException();
            }

            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                foreach (K key in dict.Keys)
                {
                    info.AddValue(key.ToString(), dict[key]);
                }
            }

            public void Add(K key, V value)
            {
                dict.Add(key, value);
            }

            public V this[K index]
            {
                set { dict[index] = value; }
                get { return dict[index]; }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!login.validarLogin())
                Response.Redirect("Login.aspx");

            if (IsPostBack) return;

            Utility.Utility.checkButtonDoubleClick(btnGuardar, this.Page);
            Session.Remove("idMes");
            llenarListas();
            esconderAlertas();
        }

        public string fechaActual()
        {
            return DateTime.Now.ToShortDateString();
        }

        private void esconderAlertas()
        {
            alerta.Visible = false;
            error.Visible = false;
            alertaAlumno.Visible = false;
            inscripcionError.Visible = false;
        }

        public string llenarAutocomplete()
        {
            List<Alumno> nombreCompletoAlumno = alumnoNego.listaAlumnos().Select(p => new Alumno() { Nombre = p.Apellido + " " + p.Nombre, IdAlumno = p.IdAlumno }).OrderBy(c => c.Apellido).ToList();

            object[] pepe = new object[nombreCompletoAlumno.Count];
            int x = 0;

            MyJsonDictionary<String, String> result = null;

            foreach (Alumno alumno in nombreCompletoAlumno)
            {
                result = new MyJsonDictionary<String, String>();

                result["stateCode"] = alumno.IdAlumno.ToString();
                result["stateName"] = alumno.Nombre;
                pepe[x] = result;
                x++;
            }

            return JsonConvert.SerializeObject(pepe);
        }

        private void llenarListas()
        {
            ddlTipoDeConcepto.DataSource = tipoDeConceptoNego.listaTipoDeConceptos().ToList();
            ddlTipoDeConcepto.DataBind();
            ddlTipoDeConcepto.Items.Insert(0, new ListItem("--Seleccione--", "0"));

            ddlConcepto.Items.Insert(0, new ListItem("--Seleccione--", "0"));
        }

        protected void ddlTipoDeConcepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtpFechaPago.Text = (dtpFechaPago.Text == "") ? DateTime.Today.ToShortDateString() : dtpFechaPago.Text ;

            int idConcepto = 0;
            int idTipoDeConcepto = int.Parse(ddlTipoDeConcepto.SelectedValue);
            int idAlumno = string.IsNullOrEmpty(hdnAlumno.Value) ? 0 : int.Parse(hdnAlumno.Value);

            IList<ConceptoXAlumnoResultSet0> listaConceptoXAlumno = pagosNego.conceptoXAlumno(idAlumno, idTipoDeConcepto).ToList();
            IList<ListaInscripcionesResultSet0> listaInscripciones = inscripcionNego.listaInscripciones(idAlumno).ToList();

            if (pagosNego.validarPago(idAlumno, idTipoDeConcepto, listaInscripciones.Count, listaConceptoXAlumno.Count))
            {
                IList<Concepto> listaConceptos = conceptoNego.listaConceptosXIdTipoConcepto(idTipoDeConcepto).ToList();

                ddlConcepto.DataSource = listaConceptos;
                ddlConcepto.DataBind();

                foreach (ConceptoXAlumnoResultSet0 conceptoData in listaConceptoXAlumno)
                {
                    idConcepto = conceptoData.idConcepto;
                }

                Concepto concepto = new Concepto();
                concepto = conceptoNego.listaConceptosXIdConcepto(idConcepto).FirstOrDefault();

                Concepto tipoDeConcepto = new Concepto();
                tipoDeConcepto = conceptoNego.listaConceptosXIdTipoConcepto(idTipoDeConcepto).FirstOrDefault();

                ddlConcepto.Text = concepto.IdConcepto.ToString();
                decimal valorConcepto = Convert.ToDecimal(concepto.ValorConcepto);

                DateTime fechaPago = Convert.ToDateTime(dtpFechaPago.Text);
                
                txtAlumno.Text = hdnNombreAlumno.Value;

                Utility.PagosEnum pagos = (Utility.PagosEnum)concepto.IdTipoDeConcepto;

                switch (pagos)
                {
                    case Utility.PagosEnum.Cuota: pagoCuota(idAlumno, idConcepto, valorConcepto, fechaPago);
                        break;
                    case Utility.PagosEnum.Matricula: pagoMatricula(idAlumno, idConcepto, valorConcepto);
                        break;
                    case Utility.PagosEnum.Examen: pagoDelExamen(idAlumno, idConcepto, valorConcepto);
                        break;
                }

                typehead.Visible = false;
                alumnoTypehead.Visible = true;
                txtValoraPagar.Focus();
            }
        }

        private void pagoCuota(int idAlumno, int idConcepto, decimal valorConcepto, DateTime fechaPago)
        {
            lblConceptoAPagar.Visible = true;
            lblConceptoAPagar.Text = pagarCuota.mesAPagar(idAlumno, idConcepto, fechaPago);

            txtValorConcepto.Text = String.Format("{0:0.00}", valorConcepto);

            txtValoraPagar.Text = string.Empty;
            h3ValorAPagar.Visible = true;
            lblValorAPagar.Visible = true;
            lblValorAPagar.Text = String.Format("{0:0.00}", pagarCuota.calcularValorAPagar(idAlumno, idConcepto, valorConcepto));

            //Si tiene hermanos muestra el valor del concepto con descuento.
            lblValorDeConceptoConDescuento.Visible = pagarCuota.muestraConceptoConDescuento(idAlumno);
            txtValorConceptoConDescuento.Visible = pagarCuota.muestraConceptoConDescuento(idAlumno);
            txtValorConceptoConDescuento.Text = String.Format("{0:0.00}", pagarCuota.valorConceptoConDescuento(idAlumno, valorConcepto));
        }

        private void pagoMatricula(int idAlumno, int idConcepto, decimal valorConcepto)
        {
            lblConceptoAPagar.Visible = true;
            lblConceptoAPagar.Text = pagoDeMatricula.estadoDeLaMatricula(idAlumno, idConcepto);

            txtValorConcepto.Text = String.Format("{0:0.00}", valorConcepto);

            txtValoraPagar.Text = string.Empty;
            h3ValorAPagar.Visible = true;
            lblValorAPagar.Visible = true;
            lblValorAPagar.Text = String.Format("{0:0.00}", pagarCuota.calcularValorAPagar(idAlumno, idConcepto, valorConcepto));


            //Si tiene hermanos muestra el valor del concepto con descuento.
            lblValorDeConceptoConDescuento.Visible = pagarCuota.muestraConceptoConDescuento(idAlumno);
            txtValorConceptoConDescuento.Visible = pagarCuota.muestraConceptoConDescuento(idAlumno);
            txtValorConceptoConDescuento.Text = String.Format("{0:0.00}", pagarCuota.valorConceptoConDescuento(idAlumno, valorConcepto));

            if (pagoDeMatricula.isMatriculaPagada(idAlumno, idConcepto))
            {
                txtValoraPagar.ReadOnly = true;
                txtValoraPagar.Text = "0,00";
                lblValorAPagar.Visible = false;
                h3ValorAPagar.Visible = false;
            }
        }

        private void pagoDelExamen(int idAlumno, int idConcepto, decimal valorConcepto)
        {
            lblConceptoAPagar.Visible = true;
            lblConceptoAPagar.Text = pagoExamen.estadoDelExamen(idAlumno, idConcepto);

            txtValorConcepto.Text = String.Format("{0:0.00}", valorConcepto);

            txtValoraPagar.Text = string.Empty;
            h3ValorAPagar.Visible = true;
            lblValorAPagar.Visible = true;
            lblValorAPagar.Text = String.Format("{0:0.00}", pagarCuota.calcularValorAPagar(idAlumno, idConcepto, valorConcepto));

            //Si tiene hermanos muestra el valor del concepto con descuento.
            lblValorDeConceptoConDescuento.Visible = pagarCuota.muestraConceptoConDescuento(idAlumno);
            txtValorConceptoConDescuento.Visible = pagarCuota.muestraConceptoConDescuento(idAlumno);
            txtValorConceptoConDescuento.Text = String.Format("{0:0.00}", pagarCuota.valorConceptoConDescuento(idAlumno, valorConcepto));

            if (pagoExamen.isExamenPagada(idAlumno, idConcepto))
            {
                txtValoraPagar.ReadOnly = true;
                txtValoraPagar.Text = "0,00";
                lblValorAPagar.Visible = false;
                h3ValorAPagar.Visible = false;
            }
        }
        private void guardarPago()
        {
            //if (hdnNombreAlumno.Value != "")
            //{
            if (pagosNego.validarPago(txtValoraPagar.Text))
            {
                Pago pago = new Pago();
                DetallePago detallePago = new DetallePago();

                if (int.Parse(ddlTipoDeConcepto.SelectedValue) != 1)
                    detallePago.IdMes = null;
                else
                    detallePago.IdMes = int.Parse(Session["idMes"].ToString());

                pago.IdAlumno = int.Parse(hdnAlumno.Value);
                pago.FechaPago = Convert.ToDateTime(dtpFechaPago.Text);

                pagosNego.guardarPago(pago);

                //Tengo que obtener el ultimo idPago generado y llenar la tabla DetallePago.
                int ultimoIdPago = pagosNego.obtieneUltimoIdPago().IdPago;

                detallePago.IdPago = ultimoIdPago;
                detallePago.ValorAPagar = Convert.ToDecimal(txtValoraPagar.Text);
                detallePago.Saldo = Convert.ToDecimal(txtSaldo.Text);
                detallePago.ValorConcepto = Convert.ToDecimal(txtValorConcepto.Text);
                detallePago.ValorConceptoConDescuento = Convert.ToDecimal(txtValorConceptoConDescuento.Text);
                detallePago.IdDescuento = pagarCuota.tipoDeDescuento(int.Parse(hdnAlumno.Value));
                detallePago.DescuentoAplicado = pagarCuota.descuentoAplicado(Convert.ToDecimal(txtValorConcepto.Text), Convert.ToDecimal(txtValorConceptoConDescuento.Text));
                detallePago.IdConcepto = int.Parse(ddlConcepto.SelectedValue);
                detallePago.Observaciones = txtObservaciones.Text;

                pagosNego.guardarDetallePago(detallePago);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                guardarPago();

                Utility.Utility.limpiarControles(this.Controls);

                lblValorDeConceptoConDescuento.Visible = false;
                txtValorConceptoConDescuento.Visible = false;

                alerta.Visible = true;

                typehead.Visible = true;
                alumnoTypehead.Visible = false;
                typehead.Focus();

                string script = @"<script type='text/javascript'>function redirection(){ window.location ='RegistrarPagos.aspx'; }  setTimeout ('redirection()', 2000); //tiempo en milisegundos </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "redirection()", script, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void txtValorDePago_TextChanged(object sender, EventArgs e)
        {
            int idAlumno = int.Parse(hdnAlumno.Value);
            int idConcepto = int.Parse(ddlConcepto.SelectedValue);
            decimal valorAPagar = Convert.ToDecimal(txtValoraPagar.Text);
            decimal valorDeConcepto = Convert.ToDecimal(txtValorConcepto.Text);
            decimal valorConceptoConDescuento = 0;

            if (txtValorConceptoConDescuento.Text == "")
                txtValorConceptoConDescuento.Text = "0";
            else
            {
                valorConceptoConDescuento = Convert.ToDecimal(txtValorConceptoConDescuento.Text);
                valorDeConcepto = Convert.ToDecimal(lblValorAPagar.Text);
            }

            decimal saldo = 0;

            if (valorAPagar > valorDeConcepto)
            {
                error.Visible = true;
                txtValoraPagar.Text = string.Empty;
            }
            else
            {
                saldo = pagarCuota.calcularNuevoSaldo(idAlumno, valorAPagar, valorDeConcepto, valorConceptoConDescuento, idConcepto);
                txtSaldo.Text = String.Format("{0:0.00}", saldo);

                error.Visible = false;
            }
        }

        protected void btnLImpiar_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistrarPagos.aspx");
        }
    }
}