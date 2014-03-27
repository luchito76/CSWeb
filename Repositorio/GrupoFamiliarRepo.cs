using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Repositorio
{
    public class GrupoFamiliarRepo
    {
        ModeloDominio dominio = new ModeloDominio();

        public void crearGrupoFamiliar(GrupoFamiliar grupoFamiliar)
        {
            dominio.Add(grupoFamiliar);
            dominio.SaveChanges();
        }

        public GrupoFamiliar obtieneUltimoGrupoFamiliar()
        {
            IEnumerable<GrupoFamiliar> result = dominio.GrupoFamiliars;
            GrupoFamiliar grupo = result.Last();

            return grupo;
        }

        public IEnumerable<GrupoFamiliar> listaGruposFamiliares()
        {
            IEnumerable<GrupoFamiliar> result = dominio.GrupoFamiliars.ToList();

            return result;
        }

        public IEnumerable<GrupoFamiliarXAlumno> listaGrupoFamiliarXIdAlumno(int idAlumno)
        {
            IEnumerable<GrupoFamiliarXAlumno> result = dominio.GrupoFamiliarXAlumnos.Where(c => c.IdAlumno == idAlumno).ToList();

            return result;
        }

        public IEnumerable<GrupoFamiliar> listaGrupoFamiliarXIdGrupoFamiliar(int idGrupoFamiliar)
        {
            IEnumerable<GrupoFamiliar> result = dominio.GrupoFamiliars.Where(c => c.IdGrupoFamiliar == idGrupoFamiliar).ToList();

            return result;
        }

        public IEnumerable<GrupoFamiliarXAlumno> cantidadDeHermanos(int idGrupoFamiliar)
        {
            IEnumerable<GrupoFamiliarXAlumno> result = dominio.GrupoFamiliarXAlumnos.Where(c => c.IdGrupoFamiliar == idGrupoFamiliar).ToList();

            return result;
        }

        public void guardarGrupoFamiliarXAlumno(GrupoFamiliarXAlumno grupoFamiliarXAlumno)
        {
            dominio.Add(grupoFamiliarXAlumno);
            dominio.SaveChanges();
        }

        public IEnumerable<ListaHermanosResultSet0> listaHermanos(int idGrupoFamiliar)
        {
            IEnumerable<ListaHermanosResultSet0> result = dominio.SP_ListaHermanos(idGrupoFamiliar).ToList();

            return result;
        }       
    }
}
