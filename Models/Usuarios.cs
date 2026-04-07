using System;

namespace Books.Models
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public string Contacto { get; set; }
        public bool Activo { get; set; }

        public Usuario()
        {
            Nombre = string.Empty;
            Contacto = string.Empty;
            Activo = true;
        }

        public Usuario(string nombre, string contacto, bool activo)
        {
            Nombre = nombre;
            Contacto = contacto;
            Activo = activo;
        }

        public override string ToString()
        {
            string estado = Activo ? "Activo" : "Inactivo";
            return $"[USUARIO] {Nombre.PadRight(15)} | Tel: {Contacto.PadRight(12)} | Estado: {estado}";
        }
    }
}