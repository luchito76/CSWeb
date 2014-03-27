using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Repositorio
{
    public class InscripcionRepo
    {
        ModeloDominio dominio = new ModeloDominio();

        public void guardarInscripcion(Inscripcion inscripcion)
        {
            dominio.Add(inscripcion);
            dominio.SaveChanges();
        }

        public void actualizarInscripcion(Inscripcion inscripcion)
        {
            dominio.AttachCopy(inscripcion);
            dominio.SaveChanges();
        }

        public IEnumerable<ListaInscripcionesResultSet0> listaInscripciones(int idAlumno)
        {
            IEnumerable<ListaInscripcionesResultSet0> result = dominio.SP_ListaInscripciones(idAlumno).ToList();

            return result;
        }

        public IEnumerable<Inscripcion> listaInscripcionXIdInscripcion(int idInscripcion)
        {
            IEnumerable<Inscripcion> result = dominio.Inscripcions.Where(c => c.IdInscripcion == idInscripcion).ToList();

            return result;
        }
    }
}
