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
                    Console.WriteLine("ingresando a Libros...");
                    break;
                case 2:
                    Console.WriteLine("ingresando a Usuarios...");
                    break;
                case 3:
                    Console.WriteLine("ingresando a Préstamos...");
                    break;
                case 4:
                    Console.WriteLine("ingresando a Busquedas y reportes...");
                    break;
                case 5:
                    Console.WriteLine("ingresando a Guardar / cargar datos...");
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