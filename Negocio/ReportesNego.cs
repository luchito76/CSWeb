using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Repositorio;

namespace Negocio
{
    public class ReportesNego
    {
        ReportesRepo reportesRepo = new ReportesRepo();

        public IEnumerable<ReportePagosResultSet0> reporteSaldoDiario(DateTime fechaDesde, DateTime fechaHasta)
        {
            return reportesRepo.reporteSaldoDiario(fechaDesde, fechaHasta);
        }

        public IEnumerable<ReporteDePagosMensualesResultSet0> ReporteDePagosMensuales()
        {
            return reportesRepo.ReporteDePagosMensuales();
        }
    }
}
