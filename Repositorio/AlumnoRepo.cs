using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Repositorio
{
    public class AlumnoRepo
    {        
        ModeloDominio dominio = new ModeloDominio();
        
        public void guardarAlumno(Alumno alumno)
        {
            dominio.Add(alumno);
            dominio.SaveChanges();
        }

        public void actualizarAlumno(Alumno alumno)
        {
            dominio.AttachCopy(alumno);
            dominio.SaveChanges();
        }

        public IEnumerable<Alumno> listaAlumnos()
        {

            IEnumerable<Alumno> result = dominio.Alumnos.OrderBy(c => c.Apellido).ToList();

            return result;
        }

        public IEnumerable<Alumno> listaAlumnosXIdAlumno(int idAlumno)
        {

            IEnumerable<Alumno> result = dominio.Alumnos.Where(c => c.IdAlumno == idAlumno).OrderBy(c => c.Apellido).ToList();

            return result;
        }

        //public IEnumerable<Alumno> listaHermanos() { 
        //IList<Alumno> alumno = listaAlumnos().ToList();


        //var query2 = (from al in Alumno join gr in GrupoFamiliarXAlumno on al equals gr select al );

        ///*var query = (from p in people
        //     join pts in pets on p equals pts.Owner
        //     select p).Distinct();*/
        //}
    }
}
