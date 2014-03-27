using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Repositorio
{
    public class TipoDeAlumnoRepo
    {
        ModeloDominio dominio = new ModeloDominio();

        public IEnumerable<TipoDeAlumno> listaTiposDeAlumnos()
        {
            IEnumerable<TipoDeAlumno> result = dominio.TipoDeAlumnos.ToList();

            return result;
        }
    }
}
