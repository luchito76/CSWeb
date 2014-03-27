using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;
using Dominio;

namespace Negocio
{
    public class TipoDeAlumnoNego
    {
        TipoDeAlumnoRepo tipoDeAlumnoRepo = new TipoDeAlumnoRepo();

        public IEnumerable<TipoDeAlumno> listaTiposDeAlumnos()
        {
            return tipoDeAlumnoRepo.listaTiposDeAlumnos();
        }
    }
}
