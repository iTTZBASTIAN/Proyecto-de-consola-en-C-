using System;

public static class Program
{
    public static void Main()
    {
        string[] libros = {"cien años de soledad", "la biblia", "el principito", "harry potter", "el hobbit"};
        for (int i = 0; i < libros.Length; i++)

        int opcion;

        do
        {
            Console.WriteLine("================ LIBROS ================");
            Console.WriteLine("1. Registrar libro");
            Console.WriteLine("2. Listar libros");
            Console.WriteLine("3. Registrar libro");
            Console.WriteLine("4. Ver detalle (por ID/ISBN)");
            Console.WriteLine("5. Actualizar libro");
            Console.WriteLine("6. Eliminar libro");
            Console.WriteLine("5. Actualizar libro");
            Console.WriteLine("0. Volver al menú principal");
            Console.Write("Selecciona una opción: ");

            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Promedio del grupo:");
                    break;
                case 2:
                    Console.WriteLine($"{i+1}. libro: {libros[i]}");
                    break;
                case 3:
                    Console.WriteLine("Promedio del grupo:");
                    break;
                case 4:
                    Console.WriteLine($"{i+1}. libro: {libros[i]}");
                    break;
                case 5:
                    Console.WriteLine($"{i+1}. libro: {libros[i]}");
                    break;
                case 0:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                    break;
            }
        } while (opcion != 0);
    }
}
