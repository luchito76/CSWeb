using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Repositorio;
namespace Negocio
{
    public class GrupoFamiliarNego
    {
        GrupoFamiliarRepo grupoFamiliarRepo = new GrupoFamiliarRepo();

        public void crearGrupoFamiliar(GrupoFamiliar grupoFamiliar)
        {
            grupoFamiliarRepo.crearGrupoFamiliar(grupoFamiliar);
        }

        public GrupoFamiliar obtieneUltimoGrupoFamiliar()
        {
            return grupoFamiliarRepo.obtieneUltimoGrupoFamiliar();
        }

        public IEnumerable<GrupoFamiliar> listaGrupoFamiliar()
        {
            return grupoFamiliarRepo.listaGruposFamiliares();
        }

        public IEnumerable<GrupoFamiliarXAlumno> listaGrupoFamiliarXIdAlumno(int idAlumno)
        {
            return grupoFamiliarRepo.listaGrupoFamiliarXIdAlumno(idAlumno);
        }

        public IEnumerable<GrupoFamiliar> listaGrupoFamiliarXIdGrupoFamiliar(int idGrupoFamiliar)
        {
            return grupoFamiliarRepo.listaGrupoFamiliarXIdGrupoFamiliar(idGrupoFamiliar);
        }

        public IEnumerable<GrupoFamiliarXAlumno> cantidadDeHermanos(int idGrupoFamiliar)
        {
            return grupoFamiliarRepo.cantidadDeHermanos(idGrupoFamiliar);
        }

        public void guardarGrupoFamiliarXAlumno(GrupoFamiliarXAlumno grupoFamiliarXAlumno)
        {
            grupoFamiliarRepo.guardarGrupoFamiliarXAlumno(grupoFamiliarXAlumno);
        }

        public IEnumerable<ListaHermanosResultSet0> listaHermanos(int idGrupoFamiliar)
        {
            return grupoFamiliarRepo.listaHermanos(idGrupoFamiliar);
        }
    }
}
