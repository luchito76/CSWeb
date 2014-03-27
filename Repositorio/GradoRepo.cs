using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Repositorio
{
    public class GradoRepo
    {
    ModeloDominio dominio = new ModeloDominio();

    public IEnumerable<Grado> listaGrados() { 
    IEnumerable<Grado> result = dominio.Grados.ToList();

    return result;
    }
    }
}
