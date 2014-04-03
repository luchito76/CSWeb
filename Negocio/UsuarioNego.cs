using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Repositorio;

namespace Negocio
{
    public class UsuarioNego
    {
        UsuarioRepo usuarioRepo = new UsuarioRepo();

        public void agregraUsuario(Usuario usuario)
        {
            usuarioRepo.agregarUsuario(usuario);
        }

        public IEnumerable<Usuario> listaUsuarioXId(int idUsuario)
        {
            return usuarioRepo.listaUsuarioXId(idUsuario);
        }

        public IEnumerable<Usuario> listaUsuarioXusuario(string usuario)
        {
            return usuarioRepo.listaUsuarioXusuario(usuario);
        }
    }
}
