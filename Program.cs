

using System;
using System.Collections.Generic;
using System.Diagnostics;

public static class Program
{
    static List<string> usuarios = new List<string> {"Jose", "Joseluis", "Karim"};
    static List<string> contactoUsuario = new List<string> { "305-457820", "314-34566", "315-467752" };
    
    public static void MostrarMenuUsuario()
    {   
        int opcionUsuario;

        do
        {
            Console.WriteLine("================ USUARIO ================");
            Console.WriteLine("1. Registrar Usuario");
            Console.WriteLine("2. Listar Usuarios");
            Console.WriteLine("3. Ver detalle (por ID / documento)");
            Console.WriteLine("4. Actualizar usuario");
            Console.WriteLine("5. Eliminar usuario");
            Console.WriteLine("0. Volver al menú principal");
            Console.Write("Selecciona una opción: ");

            opcionUsuario = Convert.ToInt32(Console.ReadLine());

            switch (opcionUsuario)
            {
                case 1:
                    Console.Write("Escribe el nombre del nuevo usuario: ");
                    string nuevoUsuario = Console.ReadLine();
                    
                    if (!string.IsNullOrWhiteSpace(nuevoUsuario))
                    {
                        usuarios.Add(nuevoUsuario);
                        Console.WriteLine("¡Usuario registrado con éxito!");
                    }
                    else
                    {
                        Console.WriteLine("El nombre no puede estar vacío.");
                    }
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("\n--- Lista de Usuarios ---");
                    for (int i = 0; i < usuarios.Count; i++)
                    {
                        if (opcionUsuario == "1")
                        {
                            Console.WriteLine($"{i + 1}. {usuarios[i]} {contactoUsuario}");
                        }
                    }
                    Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 3:
                Console.Clear();
                Console.WriteLine("========== DETALLE DEL USUARIO ==========");
    
                if (usuarios.Count == 0)
                {
                    Console.WriteLine("No hay usuarios registrados en el sistema.");
                }
                else
                {
                    Console.Write($"Ingresa el ID del usuario (1 al {usuarios.Count}): ");
                if (int.TryParse(Console.ReadLine(), out int idBuscado))
                {
                    int indice = idBuscado - 1;

                    if (indice >= 0 && indice < usuarios.Count)
                    {
                    string contactoUsuario = contacto[indice];
                    
                    Console.WriteLine("\n------------------------------------");
                    Console.WriteLine($"ID/ISBN: {idBuscado}");
                    Console.WriteLine($"Usuario:  {usuarios[indice].ToUpper()}");
                    Console.WriteLine($"Estado:  {contactoUsuario}");
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
                Console.WriteLine("========== ACTUALIZAR USUARIO ==========");

                for (int i = 0; i < usuarios.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {usuarios[i]}");
                }

                Console.Write("\nIngresa el ID del usuario que deseas editar: ");
                if (int.TryParse(Console.ReadLine(), out int idEditar))
                {
                    int indice = idEditar - 1;

                    if (indice >= 0 && indice < usuarios.Count)
                    {
                        Console.Clear();
                        Console.WriteLine($"Editando: {usuarios[indice].ToUpper()}");
                        Console.WriteLine("1. Cambiar nombre de usuario");
                        Console.WriteLine("2. Editar contacto");
                        Console.WriteLine("0. Cancelar");
                        Console.Write("Selecciona qué deseas hacer: ");
                        
                        string subOpcionEdit = Console.ReadLine();

                        switch (subOpcionEdit)
                        {
                            case "1":
                                Console.Write("Ingresa el nuevo título: ");
                                string nuevoNombre = Console.ReadLine();
                                if (!string.IsNullOrWhiteSpace(nuevoNombre))
                                {
                                    usuarios[indice] = nuevoNombre;
                                    Console.WriteLine("¡Nombre de usuario actualizado!");
                                }
                                break;

                            case "2":

                                contacto[indice] = !contacto[indice]; 
                                string nuevoContactoUsuario = contacto[indice] ? "Acitvo" : "Desconectado";
                                Console.WriteLine($"¡Estado cambiado a {nuevoContactoUsuario}!");
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

                    Console.Clear();
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                    break;
            }
        } while (opcionUsuario !=0);
    }
}



