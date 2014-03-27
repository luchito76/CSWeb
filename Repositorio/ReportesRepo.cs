using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data;

namespace Repositorio
{
    public class ReportesRepo
    {
        ModeloDominio dominio = new ModeloDominio();

        public IEnumerable<ReportePagosResultSet0> reporteSaldoDiario(DateTime fechaDesde, DateTime fechaHasta)
        {
            IEnumerable<ReportePagosResultSet0> result = dominio.SP_ReportePagos(fechaDesde, fechaHasta).ToList();

            return result;
        }

        public IEnumerable<ReporteDePagosMensualesResultSet0> ReporteDePagosMensuales()
        {
            IEnumerable<ReporteDePagosMensualesResultSet0> result = dominio.SP_ReporteDePagosMensuales().ToList();

            return result;
        }        
    }
}
