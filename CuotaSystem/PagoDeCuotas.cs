using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dominio;
using Negocio;

namespace CuotaSystem
{
    public class PagoDeCuotas
    {
        PagosNego pagosNego = new PagosNego();
        MesNego mesNego = new MesNego();
        GrupoFamiliarNego grupoFamiliarNego = new GrupoFamiliarNego();
        DescuentoNego descuentoNego = new DescuentoNego();

        IList<Me> listaMeses;

        #region "Mes a Pagar"

        public string mesAPagar(int idAlumno, int idConcepto, DateTime fechaPago)
        {
            string mesApagar = string.Empty;

            if (isPrimerPagoCuota(idAlumno, idConcepto))
            {
                mesApagar = pagoPrimeraCuota(fechaPago);
            }
            else
                mesApagar = pagoCuotasPosteriores(idAlumno, idConcepto);

            return "Mes a Pagar: <strong>" + mesApagar + "</strong>";
        }

        private bool isPrimerPagoCuota(int idAlumno, int idConcepto)
        {
            bool primerPago = false;

            IList<Pago> listaPagos = pagosNego.listaPagosXIdAlumno(idAlumno).ToList();

            if (listaPagos.Count == 0)
            {
                primerPago = true;
            }
            else
            {
                primerPago = validaConceptoPrimerPago(listaPagos, idConcepto);
            }

            return primerPago;
        }

        private string pagoPrimeraCuota(DateTime fechaPago)
        {
            string mesApagar = string.Empty;

            int dia = fechaPago.Day;
            int mes = fechaPago.Month;

            if (dia > 15)
                listaMeses = mesNego.listaMeses(mes + 1).ToList();
            else
                listaMeses = mesNego.listaMeses(mes).ToList();

            foreach (Me mesData in listaMeses)
            {
                mesApagar = mesData.Nombre;
                HttpContext.Current.Session["idMes"] = mesData.IdMes;
            }

            return mesApagar;
        }

        //Este mpetodo es llamado cuando ya se ha pagado la primer cuota y se necesita saber cual es la siguiente cuota a pagar.
        private string pagoCuotasPosteriores(int idAlumno, int idConcepto)
        {
            string mesApagar = string.Empty;

            IList<DevuelveUltimoDetallePagoXAlumnoResultSet0> lista = pagosNego.devuelveUltimoDetallePagoXAlumno(idAlumno, idConcepto).ToList();

            foreach (DevuelveUltimoDetallePagoXAlumnoResultSet0 data in lista)
            {
                if (data.idConcepto == idConcepto)
                {
                    IList<Me> listaMeses = devuelveMesAPagar(data);

                    foreach (Me mesData in listaMeses)
                    {
                        mesApagar = mesData.Nombre;
                        HttpContext.Current.Session["idMes"] = mesData.IdMes;
                    }
                }
            }

            return mesApagar;
        }

        private IList<Me> devuelveMesAPagar(DevuelveUltimoDetallePagoXAlumnoResultSet0 data)
        {
            int idMes = data.idMes;

            if (data.saldo == 0)
                listaMeses = mesNego.listaMeses(idMes + 1).ToList();
            else
            {
                listaMeses = mesNego.listaMeses(idMes).ToList();
            }

            return listaMeses;
        }

        private bool validaConceptoPrimerPago(IList<Pago> listaPagos, int idConcepto)
        {
            IList<DetallePago> detallePago;

            bool validaConceptoCuota = true;

            foreach (Pago validaConcepto in listaPagos)
            {
                detallePago = pagosNego.listaDetallePagoXIdPago(validaConcepto.IdPago).ToList();

                foreach (DetallePago pago in detallePago)
                {
                    if (pago.IdConcepto == idConcepto)
                        validaConceptoCuota = false;
                }
            }

            return validaConceptoCuota;
        }

        #endregion

        #region "Calcular valor a pagar del textbox ValorAPagar"

        public decimal calcularValorAPagar(int idAlumno, int idConcepto, decimal valorConcepto)
        {
            decimal valorApagarCalculado = 0;
            decimal saldoAnterior = devuelveValorSaldoAnterior(idAlumno, idConcepto);

            if (saldoAnterior > 0)
            {
                valorApagarCalculado = saldoAnterior;
            }
            else if (cantidadDeHermanos(idAlumno) == 0)
            {
                valorApagarCalculado = valorConcepto;
            }
            else
            {
                valorApagarCalculado = valorAPagarCalculadoConDescuento(idAlumno, valorConcepto, cantidadDeHermanos(idAlumno));
            }

            return valorApagarCalculado;
        }

        private decimal valorAPagarCalculadoConDescuento(int idAlumno, decimal valorConcepto, int numeroHermanos)
        {
            decimal valorApagarCalculadoConDescuento = 0;

            if (numeroHermanos == 2)
            {
                valorApagarCalculadoConDescuento = valorConcepto - ((valorConcepto * 10) / 100);
            }
            else if (numeroHermanos > 2)
            {
                valorApagarCalculadoConDescuento = valorConcepto - ((valorConcepto * 15) / 100);
            }

            return valorApagarCalculadoConDescuento;
        }

        private decimal devuelveValorSaldoAnterior(int idAlumno, int idConcepto)
        {
            decimal valorSaldoAnterior = 0;

            IList<DevuelveUltimoDetallePagoXAlumnoResultSet0> lista = pagosNego.devuelveUltimoDetallePagoXAlumno(idAlumno, idConcepto).ToList();

            foreach (DevuelveUltimoDetallePagoXAlumnoResultSet0 saldoAnteriorData in lista)
            {
                if (saldoAnteriorData.idConcepto == idConcepto)
                    valorSaldoAnterior = Convert.ToDecimal(saldoAnteriorData.saldo);
            }

            return valorSaldoAnterior;
        }

        private int cantidadDeHermanos(int idAlumno)
        {
            int idGrupoFamialiar = 0;
            int cantidadDeHermanos = 0;

            IList<GrupoFamiliarXAlumno> listaGrupoFamiliar = grupoFamiliarNego.listaGrupoFamiliarXIdAlumno(idAlumno).ToList();
            IList<GrupoFamiliarXAlumno> listaCantidadHermanos;

            foreach (GrupoFamiliarXAlumno grupo in listaGrupoFamiliar)
            {
                idGrupoFamialiar = grupo.IdGrupoFamiliar.Value;

                listaCantidadHermanos = grupoFamiliarNego.cantidadDeHermanos(idGrupoFamialiar).ToList();
                cantidadDeHermanos = listaCantidadHermanos.Count;
            }

            return cantidadDeHermanos;
        }

        #endregion

        #region "Muestra el textbox ConceptoConDescuento"

        public decimal valorConceptoConDescuento(int idAlumno, decimal valorConcepto)
        {
            decimal valorConceptoConDescuentos = 0;

            valorConceptoConDescuentos = valorAPagarCalculadoConDescuento(idAlumno, valorConcepto, cantidadDeHermanos(idAlumno));

            return valorConceptoConDescuentos;
        }

        public bool muestraConceptoConDescuento(int idAlumno)
        {
            bool hermanos = false;

            if (cantidadDeHermanos(idAlumno) > 0)
                hermanos = true;

            return hermanos;
        }

        #endregion


        #region "Calcular nuevo saldo de cuota"

        public decimal calcularNuevoSaldo(int idAlumno, decimal valorAPagar, decimal valorConcepto, decimal valorConceptoConDescuento, int idConcepto)
        {
            decimal nuevoSaldoCalculado = 0;

            decimal saldoAnterior = devuelveValorSaldoAnterior(idAlumno, idConcepto);

            if (saldoAnterior > 0)
            {
                valorConcepto = saldoAnterior;
                valorConceptoConDescuento = saldoAnterior;
            }

            if (valorConceptoConDescuento == 0)
            {
                nuevoSaldoCalculado = valorConcepto - valorAPagar;
            }
            else
            {
                nuevoSaldoCalculado = valorConceptoConDescuento - valorAPagar;
            }

            return nuevoSaldoCalculado;

        }

        public int tipoDeDescuento(int idAlumno)
        {
            int tipoDescuento = 1;

            if (cantidadDeHermanos(idAlumno) == 2)
            {
                tipoDescuento = 2;
            }
            else if (cantidadDeHermanos(idAlumno) > 2)
            {
                tipoDescuento = 3;
            }

            return tipoDescuento;
        }

        public decimal descuentoAplicado(decimal valorConcepto, decimal valorDescuentoAplicado)
        {
            decimal descuentoAplicado = 0;

            if (valorDescuentoAplicado != 0)
            {
                descuentoAplicado = valorConcepto - valorDescuentoAplicado;
            }

            return descuentoAplicado;
        }
        #endregion
    }
}