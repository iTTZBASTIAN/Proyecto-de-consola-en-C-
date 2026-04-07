using System.Collections.Generic;
using Books.Models;

namespace Books.Services
{
    public class PrestamoService
    {
        private List<Prestamo> prestamos = new List<Prestamo>();

        public List<Prestamo> ObtenerTodos() => prestamos;

        public void Registrar(Prestamo prestamo)
        {
            prestamos.Add(prestamo);
            // Al registrar, marcamos el libro como no disponible
            prestamo.LibroPrestado.Disponible = false;
        }

        public void Eliminar(int indice)
        {
            if (indice >= 0 && indice < prestamos.Count)
            {
                // Antes de borrar, liberamos el libro
                prestamos[indice].LibroPrestado.Disponible = true;
                prestamos.RemoveAt(indice);
            }
        }
    }
}