using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Repositorio;
using Excepciones;

namespace Negocio
{
    public class CursoNego
    {
        CursosRepo cursoRepo = new CursosRepo();

        public IEnumerable<Curso> listaCursos()
        {
            return cursoRepo.listaCursos();
        }

        public IEnumerable<Curso> listaCursoXId(int idCurso)
        {
            return cursoRepo.listaCursoXId(idCurso);
        }

        public bool validarCurso(Curso curso)
        {
            bool cursoError = true;

            if (string.IsNullOrEmpty(curso.Nombre))
            {
                cursoError = false;
                throw new CursoExcepcion("Deebe completar el nombre del curso");
            }

            return cursoError;
        }

        public void guardarCurso(Curso curso)
        {
            if (validarCurso(curso))
                cursoRepo.guardarCurso(curso);
        }

        public void actualizarCurso(Curso curso)
        {
            cursoRepo.actualizarCurso(curso);
        }

        public Curso obtieneUltimoIdCurso()
        {
            return cursoRepo.obtieneUltimoIdCurso();
        }

        public void guardarConceptoXCurso(ConceptoXCurso conceptoXCurso)
        {
            cursoRepo.guardarConceptoXCurso(conceptoXCurso);
        }

        public void actualizarConceptoXCurso(ConceptoXCurso conceptoXCurso)
        {
            cursoRepo.actualizarConceptoXCurso(conceptoXCurso);
        }

        public IEnumerable<DevuelveConceptoXCursoResultSet0> listaConceptosXCurso(int idCurso)
        {
            return cursoRepo.listaConceptosXCurso(idCurso);
        }
    }
}
