using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Repositorio;

namespace Negocio
{
    public class InscripcionNego
    {
        InscripcionRepo inscripcionRepo = new InscripcionRepo();

        public void guardarInscripcion(Inscripcion inscripcion)
        {
            inscripcionRepo.guardarInscripcion(inscripcion);
        }

        public void actualizarInscripcion(Inscripcion inscripcion)
        {
            inscripcionRepo.actualizarInscripcion(inscripcion);
        }

        public IEnumerable<ListaInscripcionesResultSet0> listaInscripciones(int idAlumno)
        {
            return inscripcionRepo.listaInscripciones(idAlumno);
        }

        public IEnumerable<Inscripcion> listaInscripcionXIdInscripcion(int idInscripcion)
        {
            return inscripcionRepo.listaInscripcionXIdInscripcion(idInscripcion);
        }
    }
}
