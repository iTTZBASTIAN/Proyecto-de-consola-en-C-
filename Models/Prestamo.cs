using System;

namespace Books.Models
{
    public class Prestamo
    {
        public Libro LibroPrestado { get; set; }
        public Usuario UsuarioReceptor { get; set; }

        public DateTime FechaSalida { get; set; }
        public DateTime? FechaDevolucion { get; set; } 
        public bool Activo { get; set; }

        public Prestamo()
        {
            LibroPrestado = new Libro();
            UsuarioReceptor = new Usuario();
            FechaSalida = DateTime.Now;
            FechaDevolucion = null;
            Activo = true;
        }

        public Prestamo(Libro libro, Usuario usuario)
        {
            LibroPrestado = libro;
            UsuarioReceptor = usuario;
            FechaSalida = DateTime.Now;
            FechaDevolucion = null;
            Activo = true;
        }


        public bool EstaVencido()
        {
            return Activo && (DateTime.Now - FechaSalida).TotalDays > 7;
        }

        public int DiasTranscurridos()
        {
            return (DateTime.Now - FechaSalida).Days;
        }

        public string ResumenCorto()
        {
            return $"{LibroPrestado.Titulo} -> {UsuarioReceptor.Nombre}";
        }

        public string DetalleCompleto()
        {
            string fDevolucion = FechaDevolucion.HasValue 
                ? FechaDevolucion.Value.ToShortDateString() 
                : "Pendiente";

            return $"PRESTAMO: {LibroPrestado.Titulo.ToUpper()}\n" +
                   $"Usuario: {UsuarioReceptor.Nombre}\n" +
                   $"Fecha Salida: {FechaSalida.ToShortDateString()}\n" +
                   $"Fecha Devolución: {fDevolucion}\n" +
                   $"Días transcurridos: {DiasTranscurridos()}\n" +
                   $"Estado: {(Activo ? "Activo" : "Finalizado")}";
        }

        public override string ToString()
        {
            return $"[{FechaSalida.ToShortDateString()}] {LibroPrestado.Titulo} a {UsuarioReceptor.Nombre}";
        }
    }
}