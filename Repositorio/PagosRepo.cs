using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Repositorio
{
    public class PagosRepo
    {
        ModeloDominio dominio = new ModeloDominio();

        public IEnumerable<Pago> listaPagosXIdAlumno(int idAlumno)
        {
            IEnumerable<Pago> result = dominio.Pagos.Where(c => c.IdAlumno == idAlumno).ToList();

            return result;
        }

        public IEnumerable<DevuelveUltimoDetallePagoXAlumnoResultSet0> devuelveUltimoDetallePagoXAlumno(int idAlumno, int idConcepto)
        {
            IEnumerable<DevuelveUltimoDetallePagoXAlumnoResultSet0> result = dominio.SP_DevuelveUltimoDetallePagoXAlumno(idAlumno, idConcepto).ToList();

            return result;
        }

        public IEnumerable<DetallePago> listaDetallePagoXIdPago(int idPago)
        {
            IEnumerable<DetallePago> result = dominio.DetallePagos.Where(c => c.IdPago == idPago).ToList();

            return result;
        }

        public void guardarPago(Pago pago)
        {
            dominio.Add(pago);
            dominio.SaveChanges();
        }

        public void guardarDetallePago(DetallePago detallePago)
        {
            dominio.Add(detallePago);
            dominio.SaveChanges();
        }

        public Pago obtieneUltimoIdPago()
        {
            IEnumerable<Pago> result = dominio.Pagos;
            Pago pago = result.Last();

            return pago;
        }

        public IEnumerable<ConceptoXAlumnoResultSet0> conceptoXAlumno(int idAlumno, int idConcepto)
        {
            IEnumerable<ConceptoXAlumnoResultSet0> result = dominio.SP_ConceptoXAlumno(idAlumno, idConcepto).ToList();

            return result;
        }
    }
}
