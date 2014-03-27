using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Repositorio;

namespace Negocio
{
    public class TipoDeConceptosNego
    {
        TipoDeConceptoRepo tipoDeConceptoRepo = new TipoDeConceptoRepo();

        public IEnumerable<TipoDeConcepto> listaTipoDeConceptos()
        {
            return tipoDeConceptoRepo.listaTipoDeConceptos(); ;
        }
    }
}
