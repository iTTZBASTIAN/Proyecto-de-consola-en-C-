public class Libro
{
    public string libros { get; set; }
    public string autor { get; set; }
    public int Paginas { get; set; }
    public bool Disponible { get; set; } = true;

    public Libro(string libros, string autor)
        {
            Disponible = true;
        }
}