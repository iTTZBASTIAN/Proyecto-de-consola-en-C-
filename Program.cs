

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

public static class Program
{
    static List<string> libros = new List<string> {"cien años de soledad", "el hobbit", "harry potter"};
    static List<string> autor = new List<string> {"Gabriel Garcia Marquez", "J. R. R. Tolkien", "J. K. Rowling"}; 
    static List<string> categoria = new List<string> {"fantasia", "fantasia", "fantasia"};
    static List<string> añoPublicacion = new List<string> {"1967", "1937", "1997"};
    static List<bool> prestados = new List<bool> { true, false, true };
    static List<string> usuarios = new List<string> { "Jose", "Joseluis", "Karim" };
    static List<string> contactos = new List<string> { "305-457820", "314-34566", "315-467752" };
    static List<bool> activos = new List<bool> { true, true, true };
    static List<string> listaPrestamos = new List<string> { "cien años de soledad", "harry potter", ""};
    static List<string> EstadoPrestamos = new List<string> {"activo", "devuelto", "activo"};
    static List<string> PrestamosPorUsuario = new List<string> {"2", "0", "3"};
    static List<string> PrestamosPorLibro = new List<string> {"20", "15", "40"};

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
                        MostrarMenuLibros();
                        Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("ingresando a Usuarios...");
                        menuUsuarios();
                        Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        MenuPrestamos();
                        Console.WriteLine("ingresando a Prestamos...");
                        Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4: 
                        Console.Clear();
                        menuBusquedaYReportes();
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
                        Console.WriteLine("Volver al menú principal");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                        break;
                }
            } while (opcion != 0);
        }
            
    public static void MostrarMenuLibros()
    {   
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
                        Console.WriteLine($"Autor:  {autor[indice].ToUpper()}");
                        Console.WriteLine($"categoria:  {categoria[indice].ToUpper()}");
                        Console.WriteLine($"año de publicacoin:  {añoPublicacion[indice].ToUpper()}");
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

                    Console.Clear();
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                    break;
            }
        } while (opcionLibros !=0);
    }
    public static void menuUsuarios()
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
    public static void MenuPrestamos()
    {
        int opcionPrestamos;

        do
        {
            Console.WriteLine("================ PRESTAMOS ================");
            Console.WriteLine("1. Crear prestamos");
            Console.WriteLine("2. Listar prestamos");
            Console.WriteLine("3. Ver detalle de préstamo (por ID)");
            Console.WriteLine("4. Registrar devolución");
            Console.WriteLine("5. Eliminar préstamo");
            Console.WriteLine("0. Volver al menú principal");
            Console.Write("Selecciona una opción: ");

            opcionPrestamos = Convert.ToInt32(Console.ReadLine());

            switch (opcionPrestamos)
            {
                case 1:
                    Console.WriteLine("======= CREAR PRESTAMO =======");
                    Console.WriteLine("======= VALIDACIONES: =======");
                    Console.WriteLine("1. usuario existe y está activo");
                    Console.WriteLine("2. libro existe y está disponible");
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("\n--- Lista de Prestamos ---");
                    for (int i = 0; i < listaPrestamos.Count; i++)
                    {

                        string estado = EstadoPrestamos[i];
                        Console.WriteLine($"{i + 1}. {listaPrestamos[i]} - {EstadoPrestamos[i]}");
                    }
                    Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 3:
                    Console.Clear();
                    if (listaPrestamos.Count == 0)
                    {
                        Console.WriteLine("No hay prestamos registrados.");
                    }
                    else
                    {
                        Console.Write($"Ingresa el ID (1 al {listaPrestamos.Count}): ");
                        if (int.TryParse(Console.ReadLine(), out int idBuscado))
                        {
                            int indice = idBuscado - 1;
                            if (indice >= 0 && indice < listaPrestamos.Count)
                            {

                                Console.WriteLine("\n------------------------------------");
                                Console.WriteLine($"ID: {idBuscado}");
                                Console.WriteLine($"Libro prestado:  {listaPrestamos[indice].ToUpper()}");
                                Console.WriteLine($"Contacto: {contactos[indice]}");
                                Console.WriteLine($"Estado:   {(EstadoPrestamos[indice])}");
                                Console.WriteLine("------------------------------------");
                            }
                        }
                    }
                    Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("========== REGISTRAR DEVOLUCION ==========");

                    for (int i = 0; i < listaPrestamos.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {listaPrestamos[i]}");
                    }

                    Console.Write("\nIngresa el ID del prestamo que deseas editar: ");
                    if (int.TryParse(Console.ReadLine(), out int idEditar))
                    {
                        int indice = idEditar - 1;

                        if (indice >= 0 && indice < listaPrestamos.Count)
                        {
                            Console.Clear();
                            Console.WriteLine($"Editando: {listaPrestamos[indice].ToUpper()}");
                            Console.WriteLine("1. Cambiar estado (Devuelto/Activo)");
                            Console.WriteLine("0. Cancelar");
                            Console.Write("Selecciona qué deseas hacer: ");
                            
                            string subOpcionEdit = Console.ReadLine();

                            switch (subOpcionEdit)
                            {
                                case "1":
                                    EstadoPrestamos[indice] = EstadoPrestamos[indice]; 
                                    string nuevoEstado = EstadoPrestamos[indice];
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
                    Console.WriteLine("======= ELIMINAR PRESTAMO =======");
                    Console.WriteLine("Reglas sugeridas");
                    Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 0:
                    Console.WriteLine("Saliendo...");
                    break;
            }
        } while (opcionPrestamos != 0);
    }
    public static void menuBusquedaYReportes()
    {
        int opcionBYR;
        do
        {  
            Console.Clear();
            Console.WriteLine("\n================ BUSQUEDA Y REPORTES ================");
            Console.WriteLine("1. Buscar libro");
            Console.WriteLine("2. Buscar usuario");
            Console.WriteLine("3. Reportes");
            Console.WriteLine("0. Volver al menú principal");
            Console.Write("Selecciona una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcionBYR)) continue;

            switch (opcionBYR)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("\n--- BUSCAR LIBRO ---");
                    Console.WriteLine("1. Buscar por título");
                    Console.WriteLine("2. Buscar por autor");
                    Console.WriteLine("3. Buscar por ID");
                    Console.Write("Selecciona una opcion: ");
                    string subOpcion = Console.ReadLine();

                    if (subOpcion == "1")
                    {
                        Console.Clear();
                        Console.Write("Ingrese el titulo del libro: ");
                        string busquedaTitulo = Console.ReadLine().ToLower();
                        bool encontrado = false;
                        for (int i = 0; i < libros.Count; i++) {
                            if (libros[i].ToLower().Contains(busquedaTitulo)) {
                                Console.WriteLine($"Libro: {libros[i]}");
                                Console.WriteLine($"Autor: {autor[i]}");
                                Console.WriteLine($"Categoria: {categoria[i]}");
                                Console.WriteLine($"Año de publicacion {añoPublicacion[i]}");
                                encontrado = true;
                            }
                        }
                        if (!encontrado) Console.WriteLine("No se encontró el autor.");
                    }
                    else if (subOpcion == "2")
                    {
                        Console.Clear();
                        Console.Write("Ingrese el autor: ");
                        string busquedaAutor = Console.ReadLine().ToLower();
                        bool encontrado = false;
                        for (int i = 0; i < autor.Count; i++) {
                            if (autor[i].ToLower().Contains(busquedaAutor)) {
                                Console.WriteLine($"Autor: {autor[i]} | Libro: {libros[i]}");
                                encontrado = true;
                            }
                        }
                        if (!encontrado) Console.WriteLine("No se encontró el autor.");
                    }
                    else if (subOpcion == "3")
                    {
                        Console.Clear();
                        Console.Write($"Ingrese el ID (1 al {libros.Count}): ");
                        if (int.TryParse(Console.ReadLine(), out int idBuscado)) {
                            int indice = idBuscado - 1;
                            if (indice >= 0 && indice < libros.Count) {
                                Console.WriteLine("\nLibro Encontrado:");
                                Console.WriteLine($"-----------------------");
                                Console.WriteLine($"ID:      {idBuscado}"); 
                                Console.WriteLine($"Título:  {libros[indice]}");
                                Console.WriteLine($"Autor:   {autor[indice]}");
                                Console.WriteLine($"-----------------------");
                                Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
                                Console.ReadKey();
                                Console.Clear();
                            } else {
                                Console.WriteLine("ID fuera de rango.");
                            }
                        }
                    }
                    Console.WriteLine("\nPresiona una tecla para continuar...");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("\n--- BUSCAR USUARIOS ---");
                    Console.WriteLine("1. Buscar por nombre");
                    Console.WriteLine("2. Buscar por ID");
                    Console.Write("Selecciona una opcion: ");
                    string subOpcionUsuario = Console.ReadLine();

                    if (subOpcionUsuario == "1")
                    {
                        Console.Clear();
                        Console.Write("Ingrese el nombre de usuario: ");
                        string busquedaUsuario = Console.ReadLine().ToLower();
                        bool encontrado = false;
                        for (int i = 0; i < usuarios.Count; i++) {
                            if (usuarios[i].ToLower().Contains(busquedaUsuario)) {
                                Console.WriteLine($"Usuario: {usuarios[i]} | Contacto: {contactos[i]}");
                                encontrado = true;
                            }
                        }
                        if (!encontrado) Console.WriteLine("No se encontró el usuario.");
                        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                        Console.ReadKey();
                    }
                    else if (subOpcionUsuario == "2")
                    {
                        Console.Clear();
                        Console.Write($"Ingrese el ID (1 al {usuarios.Count}): ");
                        if (int.TryParse(Console.ReadLine(), out int idBuscado)) {
                            int indice = idBuscado - 1;
                            if (indice >= 0 && indice < usuarios.Count) {
                                Console.WriteLine("\nUsuario encontrado:");
                                Console.WriteLine($"-----------------------");
                                Console.WriteLine($"ID:      {idBuscado}"); 
                                Console.WriteLine($"Usuario:  {usuarios[indice]}");
                                Console.WriteLine($"Contacto:   {contactos[indice]}");
                                Console.WriteLine($"-----------------------");
                                Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
                                Console.ReadKey();
                                Console.Clear();
                            } else {
                                Console.WriteLine("ID fuera de rango.");
                            }
                        }
                    }
                    Console.WriteLine("\nPresiona una tecla para continuar...");
                    Console.ReadKey();
                    break; 
                case 3:
                    Console.Clear();
                    Console.WriteLine("\n--- REPORTES ---");
                    Console.WriteLine("1. Préstamos por usuario");
                    Console.WriteLine("2. Préstamos por libro");
                    Console.WriteLine("3. Resumen general");
                    Console.Write("Selecciona una opcion: ");
                    string subOpcionReporte = Console.ReadLine();

                    if (subOpcionReporte == "1")
                    {
                        Console.Clear();
                        Console.WriteLine("\n--- PRESTAMOS POR USUARIO ---");
                        Console.Write("Ingrese el nombre del usuario: ");
                        string busquedaUsuario = Console.ReadLine().ToLower();
                        bool encontrado = false;
                        for (int i = 0; i < usuarios.Count; i++) {
                            if (usuarios[i].ToLower().Contains(busquedaUsuario)) {
                                Console.WriteLine($"Usuario: {usuarios[i]} | prestamos: {PrestamosPorUsuario[i]}");
                                encontrado = true;
                            }
                        }
                        if (!encontrado) Console.WriteLine("No se encontró el usuario.");
                        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                        Console.ReadKey();
                    }
                    if (subOpcionReporte == "2")
                    {
                        Console.Clear();
                        Console.WriteLine("\n--- PRESTAMOS POR LIBRO ---");
                        Console.Write("Ingrese el titulo del libro: ");
                        string busquedaLibro = Console.ReadLine().ToLower();
                        bool encontrado = false;
                        for (int i = 0; i < libros.Count; i++) {
                            if (libros[i].ToLower().Contains(busquedaLibro)) {
                                Console.WriteLine($"Libro: {libros[i]} | prestamos: {PrestamosPorLibro[i]}");
                                encontrado = true;
                            }
                        }
                        if (!encontrado) Console.WriteLine("No se encontró el usuario.");
                        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                        Console.ReadKey();
                    }
                    if (subOpcionReporte == "3")
                    {
                        Console.Clear();
                        Console.WriteLine("==========================================");
                        Console.WriteLine("           RESUMEN GENERAL DE LIBROS      ");
                        Console.WriteLine("==========================================\n");

                        for (int i = 0; i < libros.Count; i++)
                        {
                            string estado = prestados[i] ? "Prestado" : "Disponible";
                            Console.WriteLine($"{i + 1}. {libros[i].PadRight(25)} | Estado: {estado}");
                        }

                        Console.WriteLine("\n------------------------------------------");
                        Console.WriteLine("Presiona cualquier tecla para continuar...");
                        Console.ReadKey();
                    }
                    break;
                case 0: break;
            }
        } while (opcionBYR != 0);
    }
}