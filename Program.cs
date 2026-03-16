using System;
using System.Collections.Generic;
using System.Diagnostics;

public static class Program
{
    public static void MostrarMenuLibros()
    {   
        List<string> libros = new List<string> {"cien años de soledad", "el hobbit", "harry potter"};
        List<bool> prestados = new List<bool> { false, false, true };
        int opcionLibros;

        do
        {
            Console.WriteLine("================ LIBROS ================");
            Console.WriteLine("1. Registrar libro");
            Console.WriteLine("2. Listar libros");
            Console.WriteLine("3. Ver detalle (por ID/ISBN)");
            Console.WriteLine("4. Actualizar libro");
            Console.WriteLine("5. Eliminar libro");
            Console.WriteLine("0. Volver al menú principal");
            Console.Write("Selecciona una opción: ");

            opcionLibros = Convert.ToInt32(Console.ReadLine());

            switch (opcionLibros)
            {
                case 1:
                    Console.Write("Escribe el nombre del nuevo libro: ");
                    string nuevoLibro = Console.ReadLine();
                    
                    if (!string.IsNullOrWhiteSpace(nuevoLibro))
                    {
                        libros.Add(nuevoLibro);
                        Console.WriteLine("¡Libro registrado con éxito!");
                    }
                    else
                    {
                        Console.WriteLine("El nombre no puede estar vacío.");
                    }
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("\n--- Lista de Libros ---");
                    Console.WriteLine("1. listar todos");
                    Console.WriteLine("2. listar disponibles");
                    Console.WriteLine("3. Listar prestados");
                    Console.WriteLine("selecciona una opcion");
                    string subOpcion = Console.ReadLine();
                    
                    for (int i = 0; i < libros.Count; i++)
                    {
                        if (subOpcion == "1")
                        {
                            string estado = prestados[i] ? "[P]" : "[D]";
                            Console.WriteLine($"{i + 1}. {libros[i]} {estado}");
                        }
                        else if (subOpcion == "2" && prestados[i] == false)
                        {
                            Console.WriteLine($"{i + 1}. {libros[i]} [Disponible]");
                        }
                        else if (subOpcion == "3" && prestados[i] == true)
                        {
                            Console.WriteLine($"{i + 1}. {libros[i]} [Prestado]");
                        }
                    }
                    Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case 3:
                Console.Clear();
                Console.WriteLine("========== DETALLE DEL LIBRO ==========");
    
                if (libros.Count == 0)
                {
                    Console.WriteLine("No hay libros registrados en el sistema.");
                }
                else
                {
                    Console.Write($"Ingresa el ID del libro (1 al {libros.Count}): ");
                if (int.TryParse(Console.ReadLine(), out int idBuscado))
                {
                    int indice = idBuscado - 1;

                    if (indice >= 0 && indice < libros.Count)
                    {
                    string estado = prestados[indice] ? "Prestado" : "Disponible";
                    
                    Console.WriteLine("\n------------------------------------");
                    Console.WriteLine($"ID/ISBN: {idBuscado}");
                    Console.WriteLine($"Título:  {libros[indice].ToUpper()}");
                    Console.WriteLine($"Estado:  {estado}");
                    Console.WriteLine("------------------------------------");
                    }
                else
                {
                    Console.WriteLine("Error: El ID ingresado no existe.");
                }
                }
                else
                {
                    Console.WriteLine("Error: Por favor, ingresa un número válido.");
                }
                }

                Console.WriteLine("\nPresiona cualquier tecla para volver...");
                Console.ReadKey();
                Console.Clear();
                break;

            case 4:
                Console.Clear();
                Console.WriteLine("========== ACTUALIZAR LIBRO ==========");

                for (int i = 0; i < libros.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {libros[i]}");
                }

                Console.Write("\nIngresa el ID del libro que deseas editar: ");
                if (int.TryParse(Console.ReadLine(), out int idEditar))
                {
                    int indice = idEditar - 1;

                    if (indice >= 0 && indice < libros.Count)
                    {
                        Console.Clear();
                        Console.WriteLine($"Editando: {libros[indice].ToUpper()}");
                        Console.WriteLine("1. Cambiar título");
                        Console.WriteLine("2. Cambiar estado (Disponible/Prestado)");
                        Console.WriteLine("0. Cancelar");
                        Console.Write("Selecciona qué deseas hacer: ");
                        
                        string subOpcionEdit = Console.ReadLine();

                        switch (subOpcionEdit)
                        {
                            case "1":
                                Console.Write("Ingresa el nuevo título: ");
                                string nuevoTitulo = Console.ReadLine();
                                if (!string.IsNullOrWhiteSpace(nuevoTitulo))
                                {
                                    libros[indice] = nuevoTitulo;
                                    Console.WriteLine("¡Título actualizado!");
                                }
                                break;

                            case "2":

                                prestados[indice] = !prestados[indice]; 
                                string nuevoEstado = prestados[indice] ? "Prestado" : "Disponible";
                                Console.WriteLine($"¡Estado cambiado a {nuevoEstado}!");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: El ID no existe.");
                    }
                }
                
                    Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
                    Console.ReadKey();
                    Console.Clear();
    
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("======== ELIMINAR LIBRO ========");
                    Console.WriteLine("Validar no permitir si está prestado...");
                    Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 0:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                    break;
            }
        } while (opcionLibros != 0);
    }
}
