using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Repositorio
{
    public class UsuarioRepo
    {
        ModeloDominio dominio = new ModeloDominio();

        public void agregarUsuario(Usuario usuario)
        {
            dominio.Add(usuario);
            dominio.SaveChanges();
        }

        public IEnumerable<Usuario> listaUsuarioXId(int idUsuario)
        {
            IEnumerable<Usuario> result = dominio.Usuarios.Where(c => c.IdUsuario == idUsuario).ToList();

            return result;
        }

        public IEnumerable<Usuario> listaUsuarioXusuario(string usuario)
        {
            IEnumerable<Usuario> result = dominio.Usuarios.Where(c => c.Usuario1 == usuario).ToList();

            return result;
        }
    }
}
