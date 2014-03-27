using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Repositorio;

namespace Negocio
{
    public class ParentescoNego
    {
        ParentescoRepo parentescoRepo = new ParentescoRepo();

        public IEnumerable<Parentesco> listaParentesco()
        {
           return  parentescoRepo.listaParentesco();
        }
    }
}
