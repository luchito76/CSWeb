using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Repositorio
{

    public class AutorizadosRepo
    {
        ModeloDominio dominio = new ModeloDominio();

        public void altaFliaAutorizada(Autorizado autorizados)
        {
            dominio.Add(autorizados);
            dominio.SaveChanges();
        }

        /// <summary>
        /// Stored Procedure que devuelve una lista con todos los Familiares autorizados y los alumnos que pueden retirar.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ListaAutorizadosXAlumnoResultSet0> SP_listaAutorizados()
        {
            IEnumerable<ListaAutorizadosXAlumnoResultSet0> result = dominio.SP_ListaAutorizadosXAlumno().ToList();

            return result;
        }

        public IEnumerable<Autorizado> listaAutorizados()
        {
            IEnumerable<Autorizado> result = dominio.Autorizados.Select(p => new Autorizado() { Nombre = p.Apellido + " " + p.Nombre}).OrderBy(c => c.Apellido).ToList();

            return result;
        }

        public Autorizado obtieneUltimoIdAutorizado()
        {
            IEnumerable<Autorizado> result = dominio.Autorizados;
            Autorizado auto = result.Last();

            return auto;
        }

        public IEnumerable<Autorizado> listaFliaAutorizadoXId(int idAutorizado)
        {

            IEnumerable<Autorizado> result = dominio.Autorizados.Where(c => c.IdAutorizado == idAutorizado).OrderBy(c => c.Apellido).ToList();

            return result;
        }

        public void actualizarFiaAutorizada(Autorizado autorizado)
        {
            dominio.AttachCopy(autorizado);
            dominio.SaveChanges();
        }

        public void guardarAutorizadoXAlumno(AutorizadosXAlumno autorizadoXAlumno)
        {
            dominio.Add(autorizadoXAlumno);
            dominio.SaveChanges();
        }
    }
}
