using System.Collections.Generic;
using Books.Models;

namespace Books.Services
{
    public class LibroService
    {
        private List<Libro> libros = new List<Libro>();
        public List<Libro> ObtenerTodos() => libros;
        public void Agregar(Libro libro) => libros.Add(libro);
        public Libro ObtenerPorIndice(int indice) 
        {
            if (indice >= 0 && indice < libros.Count) return libros[indice];
            return null;
        }
    }
}