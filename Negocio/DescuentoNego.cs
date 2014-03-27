using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Repositorio;

namespace Negocio
{
    public class DescuentoNego
    {
        DescuentoRepo descuentoRepo = new DescuentoRepo();

        public IEnumerable<Descuento> listaDescuentos()
        {
            return descuentoRepo.listaDescuentos();
        }
    }
}
