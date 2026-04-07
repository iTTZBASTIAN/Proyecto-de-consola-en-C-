using System;

namespace Books.Models
{
    public class Libro
    {
        public string Titulo { get; set; } = null!;
        public string Autor { get; set; } = null!;
        public string Categoria { get; set; } = null!;
        public string AñoPublicacion { get; set; } = null!;
        public bool Disponible { get; set; }
        public string ConteoPrestamos { get; set; } 

        public Libro()
        {
            Disponible = true;
            ConteoPrestamos = "0";
        }

        public Libro(string titulo, string autor, string categoria, string añoPublicacion, string prestamos)
        {
            Titulo = titulo;
            Autor = autor;
            Categoria = categoria;
            AñoPublicacion = añoPublicacion;
            ConteoPrestamos = prestamos;
            Disponible = true;
        }

        public string ResumenCorto()
        {
            return $"{Titulo} - {Autor}";
        }

        public string DetalleCompleto()
        {
            string estado = Disponible ? "Disponible" : "Prestado";

            return $"LIBRO: {Titulo.ToUpper()}\n" +
                   $"Autor: {Autor}\n" +
                   $"Categoría: {Categoria}\n" +
                   $"Año: {AñoPublicacion}\n" +
                   $"Estado: {estado}\n" +
                   $"Préstamos acumulados: {ConteoPrestamos}";
        }

        public override string ToString()
        {
            return $"[LIBRO] {Titulo} | Autor: {Autor} | Préstamos: {ConteoPrestamos}";
        }
    }
}