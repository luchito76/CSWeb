using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Repositorio;
using Excepciones;

namespace Negocio
{
    public class PagosNego
    {
        PagosRepo pagosRepo = new PagosRepo();

        public IEnumerable<Pago> listaPagosXIdAlumno(int idAlumno)
        {
            return pagosRepo.listaPagosXIdAlumno(idAlumno);
        }

        public IEnumerable<DevuelveUltimoDetallePagoXAlumnoResultSet0> devuelveUltimoDetallePagoXAlumno(int idAlumno, int idConcepto)
        {
            return pagosRepo.devuelveUltimoDetallePagoXAlumno(idAlumno, idConcepto);
        }

        public IEnumerable<DetallePago> listaDetallePagoXIdPago(int idPago)
        {
            return pagosRepo.listaDetallePagoXIdPago(idPago);
        }

        public void guardarPago(Pago pago)
        {
            pagosRepo.guardarPago(pago);
        }

        public void guardarDetallePago(DetallePago detallePago)
        {
            pagosRepo.guardarDetallePago(detallePago);
        }

        public Pago obtieneUltimoIdPago()
        {
            return pagosRepo.obtieneUltimoIdPago();
        }

        public IEnumerable<ConceptoXAlumnoResultSet0> conceptoXAlumno(int idAlumno, int idConcepto)
        {
            return pagosRepo.conceptoXAlumno(idAlumno, idConcepto);
        }


        //*************************************VALIDACIONES**********************************************************************

        public bool validarPago(int idAlumno, int idTipoConcepto, int inscripcion, int idConcepto)
        {
            bool pagoError = true;

            if (idAlumno == 0)
                throw new PagoExcepcion("Debe ingresar un alumno");

            if (idTipoConcepto == 0)
                throw new PagoExcepcion("Debe seleccionar un concepto");

            if (inscripcion == 0)
                throw new PagoExcepcion("El alumno no esta inscripto a ninguna cursada");

            if (idConcepto == 0)
                throw new PagoExcepcion("Verifique los conceptos del curso al cual está inscripto el alumno.");

            return pagoError;
        }

        public bool validarPago(string valorAPagar)
        {
            bool pagoError = true;

            if (string.IsNullOrEmpty(valorAPagar))
                throw new PagoExcepcion("Debe ingresar el valor a pagar");

            return pagoError;
        }
    }
}
