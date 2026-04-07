using System.Collections.Generic;
using Books.Models;

namespace Books.Services
{
    public class LibroService
    {
        private List<Libro> libros = new List<Libro>
        {
            new Libro("cien años de soledad", "Gabriel Garcia Marquez", "Fantasia", "1967", "20"),
            new Libro("el hobbit", "J. R. R. Tolkien", "Fantasia", "1937", "15"),
            new Libro("harry potter", "J. K. Rowling", "Fantasia", "1997", "40")
        };
        public List<Libro> ObtenerTodos() => libros;
        public void Agregar(Libro libro) => libros.Add(libro);
        public Libro ObtenerPorIndice(int indice) 
        {
            if (indice >= 0 && indice < libros.Count) return libros[indice];
            return null;
        }
    }
}