using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Dominio;

namespace Repositorio
{
    public class CursosRepo
    {

        ModeloDominio dominio = new ModeloDominio();
        public IEnumerable<Curso> listaCursos()
        {
            IEnumerable<Curso> result = dominio.Cursos.ToList().OrderBy(c => c.Nombre).ToList();

            return result;
        }

        public IEnumerable<Curso> listaCursoXId(int idCurso)
        {

            IEnumerable<Curso> result = dominio.Cursos.Where(c => c.IdCurso == idCurso).OrderBy(c => c.Nombre).ToList();

            return result;

        }

        public void guardarCurso(Curso curso)
        {
            try
            {
                dominio.Add(curso);
                dominio.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en capa de negocio. Error guardando al cliente.", ex);
            }
        }

        public void actualizarCurso(Curso curso)
        {
            try
            {
                dominio.AttachCopy(curso);
                dominio.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write("<script language=javascript>alert('" + ex.Message + "')</script>");
                throw ex;
            }
        }

        public Curso obtieneUltimoIdCurso()
        {
            IEnumerable<Curso> result = dominio.Cursos;
            Curso curso = result.Last();

            return curso;
        }

        public void guardarConceptoXCurso(ConceptoXCurso conceptoXCurso)
        {
            dominio.Add(conceptoXCurso);
            dominio.SaveChanges();
        }

        public void actualizarConceptoXCurso(ConceptoXCurso conceptoXCurso)
        {
            dominio.AttachCopy(conceptoXCurso);
            dominio.SaveChanges();
        }

        public IEnumerable<DevuelveConceptoXCursoResultSet0> listaConceptosXCurso(int idCurso)
        {
            IEnumerable<DevuelveConceptoXCursoResultSet0> result = dominio.SP_DevuelveConceptoXCurso(idCurso).ToList();

            return result;
        }        
    }
}
