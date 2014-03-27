using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dominio;
using Negocio;

namespace CuotaSystem
{

    public class PagoDeMatricula
    {
        PagosNego pagosNego = new PagosNego();

        #region "Estado de la Matrícula"

        public string estadoDeLaMatricula(int idAlumno, int idConcepto)
        {
            string matricula = string.Empty;

            if (matriculaPagada(idAlumno, idConcepto))
            {
                matricula = estadoMatricula(idAlumno, idConcepto);
            }
            else
            {
                matricula = "La Matrícula no está pagada";
            }

            return matricula;
        }

        public string estadoMatricula(int idAlumno, int idConcepto)
        {
            string estadoMatricula = string.Empty;

            if (saldoMatricula(idAlumno, idConcepto) == 0)
            {
                estadoMatricula = "Pagada Completamente";
            }
            else
            {
                estadoMatricula = "Pagada Parcialmente";
            }

            return "La Matrícula está " + estadoMatricula;
        }

        public bool isMatriculaPagada(int idAlumno, int idConcepto)
        {
            bool matricula = false;

            IList<DevuelveUltimoDetallePagoXAlumnoResultSet0> listaMatricula = pagosNego.devuelveUltimoDetallePagoXAlumno(idAlumno, idConcepto).ToList();

            foreach (DevuelveUltimoDetallePagoXAlumnoResultSet0 matricualData in listaMatricula)
            {
                if ((matricualData.idConcepto == idConcepto) && (saldoMatricula(idAlumno, idConcepto) == 0))
                {
                    matricula = true;
                }
            }

            return matricula;
        }

        private decimal saldoMatricula(int idAlumno, int idConcepto)
        {
            decimal saldoDeMatricula = 0;

            IList<DevuelveUltimoDetallePagoXAlumnoResultSet0> listaMatricula = pagosNego.devuelveUltimoDetallePagoXAlumno(idAlumno, idConcepto).ToList();

            foreach (DevuelveUltimoDetallePagoXAlumnoResultSet0 matricualData in listaMatricula)
            {
                if (matricualData.idConcepto == idConcepto)
                {
                    saldoDeMatricula = Convert.ToDecimal(matricualData.saldo);
                }
            }

            return saldoDeMatricula;
        }

        public bool matriculaPagada(int idAlumno, int idConcepto)
        {
            bool isMatriculaPagada = false;

            IList<DevuelveUltimoDetallePagoXAlumnoResultSet0> listaMatricula = pagosNego.devuelveUltimoDetallePagoXAlumno(idAlumno, idConcepto).ToList();

            foreach (DevuelveUltimoDetallePagoXAlumnoResultSet0 matricualData in listaMatricula)
            {
                if (matricualData.idConcepto == idConcepto)
                {
                    isMatriculaPagada = true;
                }
            }

            return isMatriculaPagada;
        }

        #endregion


    }
}