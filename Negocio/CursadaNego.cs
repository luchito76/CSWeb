using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Repositorio;

namespace Negocio
{
    public class CursadaNego
    {
        CursadaRepo cursadaRepo = new CursadaRepo();

        public void guardarCursada(Cursada cursada)
        {
            cursadaRepo.guardarCursada(cursada);
        }

        public void actualizarCursada(Cursada cursada)
        {
            cursadaRepo.actualizarCursada(cursada);
        }

        public IEnumerable<Cursada> listaCursadas()
        {
            return cursadaRepo.listaCursadas();
        }

        public IEnumerable<Cursada> listaCursadaXId(int idCursada)
        {
            return cursadaRepo.listaCursadaXId(idCursada);
        }

        public IEnumerable<ListaCursadasXCursoResultSet0> listaCursadaXCurso()
        {
            return cursadaRepo.listaCursadaXCurso();
        }
    }
}
