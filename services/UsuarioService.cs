using System.Collections.Generic;
using Books.Models;

namespace Books.Services
{
    public class UsuarioService
    {
        private List<Usuario> usuarios = new List<Usuario>
        {
            new Usuario("Jose", "305-457820", true, "2"),
            new Usuario("Joseluis", "314-34566", true, "0"),
            new Usuario("Karim", "315-467752", true, "3")
        };

        public List<Usuario> ObtenerTodos() => usuarios;

        public void Agregar(Usuario usuario) => usuarios.Add(usuario);

        public Usuario ObtenerPorIndice(int indice)
        {
            if (indice >= 0 && indice < usuarios.Count) return usuarios[indice];
            return null;
        }
    }
}