using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Repositorio;

namespace Negocio
{
    public class AlumnoNego
    {
        AlumnoRepo alumnoRepo = new AlumnoRepo();
        public void guardarAlumno(Alumno alumno)
        {
            alumnoRepo.guardarAlumno(alumno);
        }

        public void actualizarAlumno(Alumno alumno)
        {
            alumnoRepo.actualizarAlumno(alumno);
        }

        public IEnumerable<Alumno> listaAlumnos()
        {
            return alumnoRepo.listaAlumnos();
        }

        public IEnumerable<Alumno> listaAlumnosXIdAlumno(int idAlumno)
        {
            return alumnoRepo.listaAlumnosXIdAlumno(idAlumno);
        }

        
    }
}
