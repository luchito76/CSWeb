using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Repositorio;

namespace Negocio
{
    public class AutorizadosNego
    {
        AutorizadosRepo autorizadoRepo = new AutorizadosRepo();
        ModeloDominio dominio = new ModeloDominio();

        public void altaFliaAutorizada(Autorizado autorizado)
        {
            autorizadoRepo.altaFliaAutorizada(autorizado);
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
            return autorizadoRepo.listaAutorizados();
        }

        public Autorizado obtieneUltimoIdAutorizado()
        {
            return autorizadoRepo.obtieneUltimoIdAutorizado();
        }

        public IEnumerable<Autorizado> listaFliaAutorizadoXId(int idAutorizado)
        {

            return autorizadoRepo.listaFliaAutorizadoXId(idAutorizado);
        }

        public void actualizarFliaAutorizada(Autorizado autorizado)
        {
            autorizadoRepo.actualizarFiaAutorizada(autorizado);
        }

        public void guardarAutorizadoXAlumno(AutorizadosXAlumno autorizadoXAlumno)
        {
            autorizadoRepo.guardarAutorizadoXAlumno(autorizadoXAlumno);
        }
    }
}
