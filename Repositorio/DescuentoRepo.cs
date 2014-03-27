using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Repositorio
{
    public class DescuentoRepo
    {
        ModeloDominio dominio = new ModeloDominio();

        public IEnumerable<Descuento> listaDescuentos()
        {
            IEnumerable<Descuento> result = dominio.Descuentos.ToList();

            return result;
        }
    }
}
