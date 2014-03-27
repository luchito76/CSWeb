using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Repositorio
{
    public class TipoDeConceptoRepo
    {
        ModeloDominio dominio = new ModeloDominio();

        public IEnumerable<TipoDeConcepto> listaTipoDeConceptos()
        {
            IEnumerable<TipoDeConcepto> result = dominio.TipoDeConceptos.ToList();

            return result;
        }
    }
}
