using System;
using System.Collections.Generic;

public static class Program
{
    static List<string> usuarios = new List<string> { "Jose", "Joseluis", "Karim" };
    static List<string> contactos = new List<string> { "305-457820", "314-34566", "315-467752" };
    static List<bool> activos = new List<bool> { true, true, true }; 

    public static void Main()
    {
        int opcionUsuario = -1; 

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

            if (!int.TryParse(Console.ReadLine(), out opcionUsuario))
            {
                Console.WriteLine("Por favor, ingresa un número válido.");
                continue;
            }

            switch (opcionUsuario)
            {
                case 1: 
                    Console.Write("Escribe el nombre del nuevo usuario: ");
                    string nuevoUsuario = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(nuevoUsuario))
                    {
                        usuarios.Add(nuevoUsuario);
                        contactos.Add("Sin contacto");
                        activos.Add(true);
                        Console.WriteLine("¡Usuario registrado con éxito!");
                    }
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("\n--- Lista de Usuarios ---");
                    for (int i = 0; i < usuarios.Count; i++)
                    {

                        string estado = activos[i] ? "[Activo]" : "[Inactivo]";
                        Console.WriteLine($"{i + 1}. {usuarios[i]} - {contactos[i]} {estado}");
                    }
                    break;

                case 3:
                    Console.Clear();
                    if (usuarios.Count == 0)
                    {
                        Console.WriteLine("No hay usuarios registrados.");
                    }
                    else
                    {
                        Console.Write($"Ingresa el ID (1 al {usuarios.Count}): ");
                        if (int.TryParse(Console.ReadLine(), out int idBuscado))
                        {
                            int indice = idBuscado - 1;
                            if (indice >= 0 && indice < usuarios.Count)
                            {

                                Console.WriteLine("\n------------------------------------");
                                Console.WriteLine($"ID: {idBuscado}");
                                Console.WriteLine($"Usuario:  {usuarios[indice].ToUpper()}");
                                Console.WriteLine($"Contacto: {contactos[indice]}");
                                Console.WriteLine($"Estado:   {(activos[indice] ? "Activo" : "Inactivo")}");
                                Console.WriteLine("------------------------------------");
                            }
                        }
                    }
                    break;

                case 4:
                    Console.Clear();
                    Console.WriteLine("========== ACTUALIZAR USUARIO ==========");
                    for (int i = 0; i < usuarios.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {usuarios[i]}");
                    }

                    Console.Write("\nID a editar: ");
                    if (int.TryParse(Console.ReadLine(), out int idEditar))
                    {
                        int indice = idEditar - 1;
                        if (indice >= 0 && indice < usuarios.Count)
                        {
                            Console.WriteLine("1. Nombre | 2. Contacto | 3. Estado | 0. Salir");
                            string subOpcion = Console.ReadLine();
                            switch (subOpcion)
                            {
                                case "1":
                                    Console.Write("Nuevo nombre: ");
                                    usuarios[indice] = Console.ReadLine();
                                    break;
                                case "2":
                                    Console.Write("Nuevo contacto: ");
                                    contactos[indice] = Console.ReadLine();
                                    break;
                                case "3":
                                    activos[indice] = !activos[indice];
                                    Console.WriteLine("Estado cambiado.");
                                    break;
                            }
                        }
                    }
                    Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("======= ELIMINAR USUARIO =======");
                    Console.WriteLine("Validar no permitir si tiene préstamos activos");
                    Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 0:
                    Console.WriteLine("Saliendo...");
                    break;
            }

            if (opcionUsuario != 0)
            {
                Console.WriteLine("\nPresiona una tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }

        } while (opcionUsuario != 0);
    }
}