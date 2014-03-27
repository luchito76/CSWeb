using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Repositorio;

namespace Negocio
{
    public class MesNego
    {
        MesRepo mesRepo = new MesRepo();

        public IEnumerable<Me> listaMeses(int idMes)
        {
            return mesRepo.listaMeses(idMes);
        }
    }
}
