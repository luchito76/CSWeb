using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Repositorio
{
    public class EscuelaRepo
    {
        ModeloDominio dominio = new ModeloDominio();

        public void guardarEscuela(Escuela escuela)
        {
            dominio.Add(escuela);
            dominio.SaveChanges();
        }

        public void actualizarEscuela(Escuela escuela)
        {
            dominio.AttachCopy(escuela);
            dominio.SaveChanges();
        }

        public IEnumerable<Escuela> listaEscuelas()
        {

            IEnumerable<Escuela> result = dominio.Escuelas.OrderBy(c => c.Nombre).ToList();

            return result;
        }

        public IEnumerable<Escuela> listaEscuelasXIdEscuela(int idEscuela)
        {

            IEnumerable<Escuela> result = dominio.Escuelas.Where(c => c.IdEscuela == idEscuela).OrderBy(c => c.Nombre).ToList();

            return result;
        }
    }
}
