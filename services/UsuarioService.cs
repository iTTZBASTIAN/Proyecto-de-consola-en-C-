using System.Collections.Generic;
using Books.Models;

namespace Books.Services
{
    public class UsuarioService
    {
        private List<Usuario> usuarios = new List<Usuario>();

        public List<Usuario> ObtenerTodos() => usuarios;

        public void Agregar(Usuario usuario) => usuarios.Add(usuario);

        public Usuario ObtenerPorIndice(int indice)
        {
            if (indice >= 0 && indice < usuarios.Count) return usuarios[indice];
            return null;
        }
    }
}