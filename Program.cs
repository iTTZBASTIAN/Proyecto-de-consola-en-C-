
using System;

public static class Program
{
    
    public static void Main()
    {

    int opcion;

        do
        {
            Console.WriteLine("================ MENU PRINCIPAL ================");
            Console.WriteLine("1. Libros");
            Console.WriteLine("2. Usuarios");
            Console.WriteLine("3. Préstamos");
            Console.WriteLine("4. Busquedas y reportes");
            Console.WriteLine("5. Guardar / cargar datos");
            Console.WriteLine("0. Salir");
            Console.Write("Selecciona una opción: ");

            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("ingresando a Libros...");
                    Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("ingresando a Usuarios...");
                    Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("ingresando a Préstamos...");
                    Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("ingresando a Busquedas y reportes...");
                    Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("ingresando a Guardar / cargar datos...");
                    Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 0:
                    Console.Clear();
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                    break;
            }
        } while (opcion != 0);
    }
}

