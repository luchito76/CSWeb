using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Repositorio;

namespace Negocio
{
    public class EscuelaNego
    {
        EscuelaRepo escuelaRepo = new EscuelaRepo();

        public void guardarEscuela(Escuela escuela)
        {
            escuelaRepo.guardarEscuela(escuela);
        }

        public void actualizarEscuela(Escuela escuela)
        {
            escuelaRepo.actualizarEscuela(escuela);
        }

        public IEnumerable<Escuela> listaEscuelas()
        {

            return escuelaRepo.listaEscuelas();
        }

        public IEnumerable<Escuela> listaEscuelasXIdEscuela(int idEscuela)
        {

            return escuelaRepo.listaEscuelasXIdEscuela(idEscuela);
        }
    }
}
