using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Repositorio
{
    public class ParentescoRepo
    {
        ModeloDominio dominio = new ModeloDominio();

        public IEnumerable<Parentesco> listaParentesco()
        {
            IEnumerable<Parentesco> result = dominio.Parentescos.ToList();

            return result;
        }
    }
}
