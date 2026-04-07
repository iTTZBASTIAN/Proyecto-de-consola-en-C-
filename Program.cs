
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Books.Models;

public static class Program
{
    static List<Libro> inventario = new List<Libro>()
    {
        new Libro("cien años de soledad", "Gabriel Garcia Marquez", "fantasia", "1967", "20"),
        new Libro("el hobbit", "J. R. R. Tolkien", "fantasia", "1937", "15"),
        new Libro("harry potter", "J. K. Rowling", "fantasia", "1997", "40")
    };
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
                        menuUsuarios();
                        Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        MenuPrestamos();
                        Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4: 
                        Console.Clear();
                        menuBusquedaYReportes();
                        Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5: 
                        Console.Clear();
                        menuGuardarCargardatos();
                        Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 0:
                        Console.Clear();
                        Exit();
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

        if (!int.TryParse(Console.ReadLine(), out opcionLibros)) continue;

        switch (opcionLibros)
        {
            case 1: // REGISTRAR
                Console.Write("Título: "); string t = Console.ReadLine() ?? "";
                Console.Write("Autor: "); string a = Console.ReadLine() ?? "";
                Console.Write("Categoría: "); string c = Console.ReadLine() ?? "";
                Console.Write("Año: "); string anio = Console.ReadLine() ?? "";

                if (!string.IsNullOrWhiteSpace(t)) {
                    inventario.Add(new Libro(t, a, c, anio, "0"));
                    Console.WriteLine("¡Libro registrado con éxito!");
                }
                break;

            case 2: // LISTAR
                Console.Clear();
                Console.WriteLine("1. Listar todos\n2. Disponibles\n3. Prestados");
                string sub = Console.ReadLine() ?? "";
                
                for (int i = 0; i < inventario.Count; i++) {
                    var libro = inventario[i]; // Accedemos al objeto completo
                    
                    if (sub == "1") 
                        Console.WriteLine($"{i + 1}. {libro.ResumenCorto()} [{(libro.Disponible ? "D" : "P")}]");
                    else if (sub == "2" && libro.Disponible)
                        Console.WriteLine($"{i + 1}. {libro.ResumenCorto()}");
                    else if (sub == "3" && !libro.Disponible)
                        Console.WriteLine($"{i + 1}. {libro.ResumenCorto()}");
                }
                break;

            case 3: // VER DETALLE
                Console.Write($"ID (1-{inventario.Count}): ");
                if (int.TryParse(Console.ReadLine(), out int id) && id > 0 && id <= inventario.Count) {
                    // ¡Usamos el método que creamos en la clase!
                    Console.WriteLine(inventario[id - 1].DetalleCompleto());
                }
                break;

            case 4: // ACTUALIZAR
                Console.Write("ID a editar: ");
                if (int.TryParse(Console.ReadLine(), out int idEd) && idEd > 0 && idEd <= inventario.Count) {
                    var libro = inventario[idEd - 1];
                    Console.WriteLine("1. Cambiar Título\n2. Cambiar Estado");
                    string opt = Console.ReadLine() ?? "";
                    if (opt == "1") {
                        Console.Write("Nuevo título: ");
                        libro.Titulo = Console.ReadLine() ?? "";
                    } else if (opt == "2") {
                        libro.Disponible = !libro.Disponible;
                    }
                }
                break;

            case 5: // ELIMINAR
                Console.Write("ID a eliminar: ");
                if (int.TryParse(Console.ReadLine(), out int idEl) && idEl > 0 && idEl <= inventario.Count) {
                    if (inventario[idEl - 1].Disponible) {
                        inventario.RemoveAt(idEl - 1);
                        Console.WriteLine("Libro eliminado.");
                    } else {
                        Console.WriteLine("No se puede eliminar un libro prestado.");
                    }
                }
                break;
        }
        if (opcionLibros != 0) { Console.WriteLine("\nPresiona una tecla..."); Console.ReadKey(); Console.Clear(); }
    } while (opcionLibros != 0);
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
                    string nuevoUsuario = Console.ReadLine() ??"" ;
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
                            string subOpcion = Console.ReadLine() ?? "";
                            switch (subOpcion)
                            {
                                case "1":
                                    Console.Write("Nuevo nombre: ");
                                    usuarios[indice] = Console.ReadLine() ?? "";
                                    break;
                                case "2":
                                    Console.Write("Nuevo contacto: ");
                                    contactos[indice] = Console.ReadLine() ?? "";
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
                            
                            string subOpcionEdit = Console.ReadLine() ?? "";

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
                    string subOpcion = Console.ReadLine() ?? "";

                    if (subOpcion == "1")
                    {
                        Console.Clear();
                        Console.Write("Ingrese el titulo del libro: ");
                        string busquedaTitulo = Console.ReadLine() ?? "".ToLower();
                        bool encontrado = false;

                            for (int i = 0; i < inventario.Count; i++) 
                            {
                                // CAMBIO: Accedemos a inventario[i].Titulo
                                if (inventario[i].Titulo.ToLower().Contains(busquedaTitulo)) 
                                {
                                    // CAMBIO: Usamos las propiedades del objeto o el método DetalleCompleto()
                                    Console.WriteLine(inventario[i].DetalleCompleto());
                                    encontrado = true;
                                }
                            }
                        if (!encontrado) Console.WriteLine("No se encontró el autor.");
                    }
                    else if (subOpcion == "2")
                    {
                        Console.Clear();
                        Console.Write("Ingrese el autor: ");
                        string busquedaAutor = Console.ReadLine() ?? "".ToLower();
                        bool encontrado = false;
                        for (int i = 0; i < inventario.Count; i++) 
                        {
                            if (inventario[i].Autor.ToLower().Contains(busquedaAutor)) 
                            {
                                Console.WriteLine($"Autor: {inventario[i].Autor} | Libro: {inventario[i].Titulo}");
                                encontrado = true;
                            }
                        }
                        if (!encontrado) Console.WriteLine("No se encontró el autor.");
                    }
                    else if (subOpcion == "3")
                    {
                        Console.Clear();
                        Console.Write($"Ingrese el ID (1 al {inventario.Count}): "); 

                        if (int.TryParse(Console.ReadLine(), out int idBuscado)) 
                        {
                            int indice = idBuscado - 1;

                            if (indice >= 0 && indice < inventario.Count) 
                            {
                                Console.WriteLine("\nLibro Encontrado:");
                                
                                Console.WriteLine(inventario[indice].DetalleCompleto());

                                Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
                                Console.ReadKey();
                                Console.Clear();
                            } 
                            else 
                            {
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
                    string subOpcionUsuario = Console.ReadLine() ?? "";

                    if (subOpcionUsuario == "1")
                    {
                        Console.Clear();
                        Console.Write("Ingrese el nombre de usuario: ");
                        string busquedaUsuario = Console.ReadLine() ?? "".ToLower();
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
                    string subOpcionReporte = Console.ReadLine() ?? "";

                    if (subOpcionReporte == "1")
                    {
                        Console.Clear();
                        Console.WriteLine("\n--- PRESTAMOS POR USUARIO ---");
                        Console.Write("Ingrese el nombre del usuario: ");
                        string busquedaUsuario = Console.ReadLine() ?? "".ToLower();
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
                        string busquedaLibro = Console.ReadLine() ?? "".ToLower();
                        bool encontrado = false;

                        // Cambiamos 'libros.Count' por 'inventario.Count'
                        for (int i = 0; i < inventario.Count; i++) 
                        {

                            if (inventario[i].Titulo.ToLower().Contains(busquedaLibro)) 
                            {
                                Console.WriteLine($"Libro: {inventario[i].Titulo} | prestamos: {inventario[i].ConteoPrestamos}");
                                
                                encontrado = true;
                            }
                        }

                        if (!encontrado) Console.WriteLine("No se encontró el libro.");
                        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                        Console.ReadKey();
                    }
                    if (subOpcionReporte == "3")
                    {
                        Console.Clear();
                        Console.WriteLine("==========================================");
                        Console.WriteLine("           RESUMEN GENERAL DE LIBROS      ");
                        Console.WriteLine("==========================================\n");

                        for (int i = 0; i < inventario.Count; i++)
                        {
                            string estado = prestados[i] ? "Prestado" : "Disponible";
                            Console.WriteLine($"{i + 1}. {inventario[i].Titulo.PadRight(25)} | Estado: {estado}");
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
    public static void menuGuardarCargardatos()
    {
        int opcionCGD;

        do
        {
            Console.Clear();
            Console.WriteLine("================ CARGAR / GUARDAR DATOS ================");
            Console.WriteLine("1. Guardar datos");
            Console.WriteLine("2. Cargar datos");
            Console.WriteLine("3. Reiniciar datos");
            Console.WriteLine("0. Volver al menú principal");
            Console.Write("Selecciona una opción: ");

            opcionCGD = Convert.ToInt32(Console.ReadLine());

            switch (opcionCGD)
            {
                case 1:
                    Console.WriteLine("¿guardar datos? (S/N)");
                    string opcionGuardado = Console.ReadLine() ?? "";
                    if (opcionGuardado == "S")
                    {
                        Console.WriteLine("Guardando datos...");
                        Console.WriteLine("¡hecho!");
                    }
                    else if (opcionGuardado == "N")
                    {
                        Console.WriteLine("cancelando...");
                    }
                    else
                    {
                        Console.WriteLine("ingresa una respuesta valida");
                    }
                        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                        Console.ReadKey();

                    break;
                case 2:
                    Console.WriteLine("--------------- CARGAR DATOS ---------------");
                    Console.WriteLine("\n------------------------------------------");
                    Console.WriteLine("Presiona cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;
                case 3:
                    Console.WriteLine("¿reiniciar datos? (S/N)");
                    string RespuestaReiniciar = Console.ReadLine() ?? "";
                    if (RespuestaReiniciar == "S")
                    {
                        Console.WriteLine("¿Estás seguro? (S/N)");
                        string RespuestaConfirmacion = Console.ReadLine() ?? "";

                        if (RespuestaConfirmacion == "S")
                        {
                            Console.WriteLine("Reiniciando datos...");
                            Console.WriteLine("¡Hecho!");
                        }
                        else if (RespuestaConfirmacion == "N")
                        {
                            Console.WriteLine("Abortando...");
                        }
                    }
                    else if (RespuestaReiniciar == "N")
                    {
                        Console.WriteLine("cancelando...");
                    }
                    else
                    {
                        Console.WriteLine("ingresa una respuesta valida");
                    }
                        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                        Console.ReadKey();
                    break;
            }
        } while (opcionCGD != 0);
    }
    public static void Exit()
    {
        Console.WriteLine("¿Guardar antes de salir? (S/N)");
        string RespuestaSalir = Console.ReadLine() ?? "";

        if (RespuestaSalir == "S")
        {
            Console.Clear();
        }
        else if (RespuestaSalir == "N")
        {
            Console.WriteLine("Cancelando...");
            Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
            Console.ReadKey();
            Main();
        }
        else
        {
            Console.WriteLine("Error: Por favor, ingresa un número válido.");
        }
    }
}
