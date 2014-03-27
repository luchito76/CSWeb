using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Repositorio
{
    public class CursadaRepo
    {
        ModeloDominio dominio = new ModeloDominio();

        public void guardarCursada(Cursada cursada)
        {
            dominio.Add(cursada);
            dominio.SaveChanges();
        }

        public void actualizarCursada(Cursada cursada)
        {
            dominio.AttachCopy(cursada);
            dominio.SaveChanges();
        }

        public IEnumerable<Cursada> listaCursadas()
        {
            IEnumerable<Cursada> result = dominio.Cursadas.ToList();

            return result;
        }

        public IEnumerable<Cursada> listaCursadaXId(int idCursada)
        {
            IEnumerable<Cursada> result = dominio.Cursadas.Where(c => c.IdCursada == idCursada).ToList();

            return result;
        }

        public IEnumerable<ListaCursadasXCursoResultSet0> listaCursadaXCurso()
        {
            IEnumerable<ListaCursadasXCursoResultSet0> result = dominio.SP_ListaCursadasXCurso().ToList();

            return result;
        }
    }
}
