using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dominio;
using Negocio;

namespace CuotaSystem
{
    public class PagoExamen
    {
        PagosNego pagosNego = new PagosNego();

        #region "Estado del Examen"

        public string estadoDelExamen(int idAlumno, int idConcepto)
        {
            string examen = string.Empty;

            if (examenPagado(idAlumno, idConcepto))
            {
                examen = estadoExamen(idAlumno, idConcepto);
            }
            else
            {
               examen = "El Examen no está pagado";
            }

            return examen;
        }

        private string estadoExamen(int idAlumno, int idConcepto)
        {
            string estadoExamen = string.Empty;

            if (saldoExamen(idAlumno, idConcepto) == 0)
            {
                estadoExamen = "Pagado Completamente";
            }
            else
            {
                estadoExamen = "Pagado Parcialmente";
            }

            return "El Examen está " + estadoExamen;
        }

        public decimal saldoExamen(int idAlumno, int idConcepto)
        {
            decimal saldoDelExamen = 0;

            IList<DevuelveUltimoDetallePagoXAlumnoResultSet0> listaExamen = pagosNego.devuelveUltimoDetallePagoXAlumno(idAlumno, idConcepto).ToList();

            foreach (DevuelveUltimoDetallePagoXAlumnoResultSet0 examenData in listaExamen)
            {
                if (examenData.idConcepto == idConcepto)
                {
                    saldoDelExamen = Convert.ToDecimal(examenData.saldo);
                }
            }

            return saldoDelExamen;
        }

        private bool examenPagado(int idAlumno, int idConcepto)
        {
            bool isExamenPagado = false;

            IList<DevuelveUltimoDetallePagoXAlumnoResultSet0> listaExamen = pagosNego.devuelveUltimoDetallePagoXAlumno(idAlumno, idConcepto).ToList();

            foreach (DevuelveUltimoDetallePagoXAlumnoResultSet0 examenData in listaExamen)
            {
                if (examenData.idConcepto == idConcepto)
                {
                    isExamenPagado = true;
                }
            }

            return isExamenPagado;
        }

        public bool isExamenPagada(int idAlumno, int idConcepto)
        {
            bool examen = false;

            IList<DevuelveUltimoDetallePagoXAlumnoResultSet0> listaMatricula = pagosNego.devuelveUltimoDetallePagoXAlumno(idAlumno, idConcepto).ToList();

            foreach (DevuelveUltimoDetallePagoXAlumnoResultSet0 matricualData in listaMatricula)
            {
                if ((matricualData.idConcepto == idConcepto) && (saldoExamen(idAlumno, idConcepto) == 0))
                {
                    examen = true;
                }
            }

            return examen;
        }

        #endregion
    }
}