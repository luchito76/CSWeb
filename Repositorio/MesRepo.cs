using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
namespace Repositorio
{
    public class MesRepo
    {
        ModeloDominio dominio = new ModeloDominio();

        public IEnumerable<Me> listaMeses(int idMes)
        {
            IEnumerable<Me> result = dominio.Mes.Where(c => c.IdMes == idMes).ToList();

            return result;
        }
    }
}
