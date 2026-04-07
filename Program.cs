
using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Books.Models;
using Books.Services;
public static class Program
{
    class DataStorage
    {
        public List<Libro> Libros { get; set; } = new List<Libro>();
        public List<Usuario> Usuarios { get; set; } = new List<Usuario>();
        public List<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
    }
    static LibroService _libroService = new LibroService();
    static UsuarioService _usuarioService = new UsuarioService();
    static PrestamoService _prestamoService = new PrestamoService();

    public static void Main()
    {
        int opcion;
        CargarDatos();
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
                        GuardarDatos();
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
            Console.Clear();
            Console.WriteLine("======= REGISTRAR NUEVO LIBRO =======");
            Console.Write("Titulo: "); string t = Console.ReadLine() ?? "";
            Console.Write("Autor: "); string a = Console.ReadLine() ?? "";
            Console.Write("Categoria: "); string c = Console.ReadLine() ?? "";
            Console.Write("Año: "); string anio = Console.ReadLine() ?? "";

            if (!string.IsNullOrWhiteSpace(t)) {
                Libro nuevoLibro = new Libro(t, a, c, anio, "0");
                _libroService.Agregar(nuevoLibro); 
                GuardarDatos(); 

                Console.WriteLine("¡Libro registrado con éxito!");
            } else {
                Console.WriteLine("❌ El título no puede estar vacío.");
            }
            break;

        case 2: // LISTAR
            Console.Clear();
            Console.WriteLine("1. Listar todos\n2. Disponibles\n3. Prestados");
            string sub = Console.ReadLine() ?? "";

            var listaLibrosActual = _libroService.ObtenerTodos();

            for (int i = 0; i < listaLibrosActual.Count; i++) 
            {
                var libro = listaLibrosActual[i]; 
                if (sub == "1")
                    Console.WriteLine($"{i + 1}. {libro.ResumenCorto()} [{(libro.Disponible ? "D" : "P")}]");
                else if (sub == "2" && libro.Disponible)
                    Console.WriteLine($"{i + 1}. {libro.ResumenCorto()}");
                else if (sub == "3" && !libro.Disponible)
                    Console.WriteLine($"{i + 1}. {libro.ResumenCorto()}");
            }
            
            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
            break;

        case 3: // VER DETALLE
            var librosDetalle = _libroService.ObtenerTodos();
            
            if (librosDetalle.Count == 0) {
                Console.WriteLine("⚠️ No hay libros registrados para ver detalles.");
            } else {
                Console.Write($"ID (1-{librosDetalle.Count}): ");
                if (int.TryParse(Console.ReadLine(), out int id) && id > 0 && id <= librosDetalle.Count) {
                    Console.WriteLine(librosDetalle[id - 1].DetalleCompleto());
                } else {
                    Console.WriteLine("❌ ID no válido.");
                }
            }
            break;

            case 4: // ACTUALIZAR
                var librosEdit = _libroService.ObtenerTodos();
                Console.Write("ID a editar: ");
                
                if (int.TryParse(Console.ReadLine(), out int idEd) && idEd > 0 && idEd <= librosEdit.Count) {
                    var libro = librosEdit[idEd - 1];
                    
                    Console.WriteLine("1. Cambiar Título\n2. Cambiar Estado");
                    string opt = Console.ReadLine() ?? "";
                    
                    if (opt == "1") {
                        Console.Write("Nuevo título: ");
                        libro.Titulo = Console.ReadLine() ?? "";
                    } else if (opt == "2") {
                        libro.Disponible = !libro.Disponible;
                    }
                    GuardarDatos();
                    Console.WriteLine("✅ Libro actualizado.");
                }
                break;

            case 5: // ELIMINAR
                var librosDel = _libroService.ObtenerTodos();
                Console.Write("ID a eliminar: ");
                
                if (int.TryParse(Console.ReadLine(), out int idEl) && idEl > 0 && idEl <= librosDel.Count) {
                    var libroParaEliminar = librosDel[idEl - 1];
                    
                    if (libroParaEliminar.Disponible) {
                        librosDel.RemoveAt(idEl - 1);
                        GuardarDatos();
                        Console.WriteLine("🗑️ Libro eliminado.");
                    } else {
                        Console.WriteLine("❌ No se puede eliminar un libro que está prestado.");
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
case 1: // REGISTRAR
    Console.Clear();
    Console.WriteLine("======= REGISTRAR NUEVO USUARIO =======");
    
    Console.Write("Ingrese el nombre del usuario: ");
    string nombreIngresado = Console.ReadLine() ?? "";

    if (!string.IsNullOrWhiteSpace(nombreIngresado)) 
    {
        Usuario nuevoUsuarioObj = new Usuario(nombreIngresado, "Sin contacto", true, "0");

        _usuarioService.Agregar(nuevoUsuarioObj); 
        GuardarDatos(); 
        
        Console.WriteLine("\n✅ ¡Usuario registrado con éxito!");
    }
    else 
    {
        Console.WriteLine("\n❌ El nombre no puede estar vacío.");
    }
    break;

            case 2: // LISTAR
                Console.Clear();
                Console.WriteLine("\n--- Lista de Usuarios ---");
                
                // Obtenemos la lista del servicio
                var listaActual = _usuarioService.ObtenerTodos();

                for (int i = 0; i < listaActual.Count; i++)
                {
                    var u = listaActual[i];
                    string estado = u.Activo ? "[Activo]" : "[Inactivo]";
                    Console.WriteLine($"{i + 1}. {u.Nombre} - {u.Contacto} {estado}");
                }
                break;

            case 3: // VER DETALLE
                Console.Clear();
                var usuariosDetalle = _usuarioService.ObtenerTodos();

                if (usuariosDetalle.Count == 0)
                {
                    Console.WriteLine("No hay usuarios registrados.");
                }
                else
                {
                    Console.Write($"Ingresa el ID (1 al {usuariosDetalle.Count}): ");
                    if (int.TryParse(Console.ReadLine(), out int idBuscado))
                    {
                        int indice = idBuscado - 1;
                        // Usamos el servicio para obtener el usuario de forma segura
                        var usuario = _usuarioService.ObtenerPorIndice(indice);
                        
                        if (usuario != null)
                        {
                            Console.WriteLine(usuario.ToString());
                        }
                        else
                        {
                            Console.WriteLine("❌ ID fuera de rango.");
                        }
                    }
                }
                break;

                case 4:
                    Console.Clear();
                    Console.WriteLine("========== ACTUALIZAR USUARIO ==========");
                    var usuariosActuales = _usuarioService.ObtenerTodos();
                    for (int i = 0; i < usuariosActuales.Count; i++)
                    {
                        var usuario = usuariosActuales[i];
                        string estado = usuario.Activo ? "[Activo]" : "[Inactivo]";
                        
                        Console.WriteLine($"{i + 1}. {usuario.Nombre} - {usuario.Contacto} {estado}");
                    }

                    Console.Write("\nID a editar: ");
                    if (int.TryParse(Console.ReadLine(), out int idEditar))
                    {
                        int indice = idEditar - 1;
                    var usuariosParaValidar = _usuarioService.ObtenerTodos();
                    if (indice >= 0 && indice < usuariosParaValidar.Count)
                    {
                        var usuario = usuariosParaValidar[indice];
                    }
                        {
                            Console.WriteLine("1. Nombre | 2. Contacto | 3. Estado | 0. Salir");
                            string subOpcion = Console.ReadLine() ?? "";
                            switch (subOpcion)
                            {
                                case "1":
                                    Console.Write("Nuevo nombre: ");
                                    _usuarioService.ObtenerTodos()[indice].Nombre = Console.ReadLine() ?? ""; 
                                    break;

                                case "2":
                                    Console.Write("Nuevo contacto: ");
                                    _usuarioService.ObtenerTodos()[indice].Contacto = Console.ReadLine() ?? ""; 
                                    break;

                                case "3":
                                    _usuarioService.ObtenerTodos()[indice].Activo = _usuarioService.ObtenerTodos()[indice].Activo; 
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
                    var usuariosParaEliminar = _usuarioService.ObtenerTodos();
                    var prestamosActivos = _prestamoService.ObtenerTodos();
                    for (int i = 0; i < usuariosParaEliminar.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {usuariosParaEliminar[i].Nombre}");
                    }

                    Console.Write("\nIngresa el ID del usuario a eliminar: ");
                    if (int.TryParse(Console.ReadLine(), out int idEliminar))
                    {
                        int indice = idEliminar - 1;
                        if (indice >= 0 && indice < usuariosParaEliminar.Count)
                        {
                            var usuarioSeleccionado = usuariosParaEliminar[indice];

                            bool tienePrestamos = prestamosActivos.Any(p => p.UsuarioReceptor.Nombre == usuarioSeleccionado.Nombre);

                            if (tienePrestamos)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n[ERROR] No se puede eliminar: El usuario tiene préstamos activos.");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.Write($"¿Estás seguro de eliminar a {usuarioSeleccionado.Nombre}? (s/n): ");
                                if (Console.ReadLine()?.ToLower() == "s")
                                {
                                    usuariosParaEliminar.RemoveAt(indice);
                                    GuardarDatos(); 
                                    Console.WriteLine("\nUsuario eliminado correctamente.");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("ID no válido.");
                        }
                    }

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
        Console.Clear();
        Console.WriteLine("================ PRESTAMOS ================");
        Console.WriteLine("1. Crear prestamos");
        Console.WriteLine("2. Listar prestamos");
        Console.WriteLine("3. Ver detalle de préstamo (por ID)");
        Console.WriteLine("4. Registrar devolución / Editar");
        Console.WriteLine("5. Eliminar préstamo");
        Console.WriteLine("0. Volver al menú principal");
        Console.Write("Selecciona una opción: ");

        if (!int.TryParse(Console.ReadLine(), out opcionPrestamos)) continue;
        switch (opcionPrestamos)
        {
            case 1: CrearPrestamo(); break;
            case 2: ListarPrestamos(); break;
            case 3: VerDetallePrestamo(); break;
            case 4: RegistrarDevolucion(); break;
            case 5: EliminarPrestamo(); break;
        }
            } while (opcionPrestamos != 0);
        }
static void VerDetallePrestamo()
{
    Console.Clear();
    Console.WriteLine("======= DETALLE DE PRÉSTAMO =======");

    if (_prestamoService.ObtenerTodos().Count == 0)
    {
        Console.WriteLine("No hay préstamos registrados actualmente.");
    }
    else
    {

        if (_prestamoService.ObtenerTodos().Count == 0)
        {
            var prestamos = _prestamoService.ObtenerTodos();
            for (int i = 0; i < prestamos.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {prestamos[i].LibroPrestado.Titulo}");
                }
        }

        Console.Write($"\nIngresa el ID (1 al {_prestamoService.ObtenerTodos().Count}): ");
        
        if (int.TryParse(Console.ReadLine(), out int idBuscado))
        {
            int indice = idBuscado - 1;
        var prestamosActuales = _prestamoService.ObtenerTodos();
        if (indice >= 0 && indice < prestamosActuales.Count)
        {
                var prestamo = prestamosActuales[indice];
                var p = _prestamoService.ObtenerTodos()[indice]; 
                Console.WriteLine("\n-------------------------------------------");
                Console.WriteLine($"ID:              {idBuscado}");
                Console.WriteLine($"Libro:           {p.LibroPrestado.Titulo.ToUpper()}");
                Console.WriteLine($"Usuario:         {p.UsuarioReceptor.Nombre}");
                Console.WriteLine($"Contacto:        {p.UsuarioReceptor.Contacto}");
                Console.WriteLine($"Fecha Salida:    {p.FechaSalida:dd/MM/yyyy}");
                Console.WriteLine($"Estado actual:   {p.Estado}");
                
                if (p.FechaDevolucion != null)
                    Console.WriteLine($"Fecha Devolución: {p.FechaDevolucion:dd/MM/yyyy}");
                
                Console.WriteLine("-------------------------------------------");
            }
            else
            {
                Console.WriteLine("❌ Error: Ese ID no existe.");
            }
        }
        else
        {
            Console.WriteLine("❌ Error: Debes ingresar un número válido.");
        }
    }
    
    Console.WriteLine("\nPresiona cualquier tecla para volver...");
    Console.ReadKey();
}
static void CrearPrestamo()
{
    Console.Clear();
    Console.WriteLine("======= CREAR NUEVO PRÉSTAMO =======");

    // 1. Usamos el UsuarioService para listar
    var usuarios = _usuarioService.ObtenerTodos();
    Console.WriteLine("\nUsuarios registrados:");
    for (int i = 0; i < usuarios.Count; i++)
    {
        Console.WriteLine($"{i}. {usuarios[i].Nombre} ({(usuarios[i].Activo ? "Activo" : "Inactivo")})");
    }
    Console.Write("\nSelecciona el índice del usuario: ");
    if (!int.TryParse(Console.ReadLine(), out int indexU)) return;

    // 2. Usamos el LibroService para listar
    var libros = _libroService.ObtenerTodos();
    Console.WriteLine("\nLibros en inventario:");
    for (int i = 0; i < libros.Count; i++)
    {
        string estado = libros[i].Disponible ? "Disponible" : "Prestado";
        Console.WriteLine($"{i}. {libros[i].Titulo} - [{estado}]");
    }
    Console.Write("\nSelecciona el índice del libro: ");
    if (!int.TryParse(Console.ReadLine(), out int indexL)) return;

    // 3. Obtenemos los objetos desde los servicios
    Usuario user = _usuarioService.ObtenerPorIndice(indexU);
    Libro book = _libroService.ObtenerPorIndice(indexL);

    // 4. Validaciones y Registro a través del PrestamoService
    if (user != null && book != null)
    {
        if (!user.Activo) 
        {
            Console.WriteLine("❌ El usuario está inactivo.");
        }
        else if (!book.Disponible)
        {
            Console.WriteLine("❌ El libro ya está ocupado.");
        }
        else
        {
            // Creamos el objeto y lo mandamos al servicio
            Prestamo nuevo = new Prestamo(book, user);
            _prestamoService.Registrar(nuevo);
            
            Console.WriteLine($"\n✅ Préstamo registrado: {book.Titulo} para {user.Nombre}");
        }
    }
    else
    {
        Console.WriteLine("❌ Índices fuera de rango.");
    }

    Console.ReadKey();
}
static void ListarPrestamos()
{
    Console.Clear();
    Console.WriteLine("\n--- Lista de Prestamos ---");
    var prestamos = _prestamoService.ObtenerTodos();

    if (prestamos.Count == 0)
    {
        Console.WriteLine("No hay préstamos registrados.");
    }
    else
    {
        for (int i = 0; i < prestamos.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {prestamos[i].LibroPrestado.Titulo} -> {prestamos[i].UsuarioReceptor.Nombre} | [{prestamos[i].Estado}]");
        }
    }
    PausarContinuar();
}
static void RegistrarDevolucion()
{
    Console.Clear();
    Console.WriteLine("========== REGISTRAR DEVOLUCION ==========");
    var prestamos = _prestamoService.ObtenerTodos();

    for (int i = 0; i < prestamos.Count; i++)
        Console.WriteLine($"{i + 1}. {prestamos[i].LibroPrestado.Titulo} ({prestamos[i].Estado})");

    Console.Write("\nIngresa el ID del préstamo: ");
    if (int.TryParse(Console.ReadLine(), out int id) && (id - 1) >= 0 && (id - 1) < prestamos.Count)
    {
        var p = prestamos[id - 1];
        // Alternamos el estado
        if (p.Estado == EstadoPrestamo.Activo)
        {
            p.Estado = EstadoPrestamo.Devuelto;
            p.FechaDevolucion = DateTime.Now;
            p.LibroPrestado.Disponible = true; // El libro vuelve a estar libre
            Console.WriteLine("✅ ¡Libro devuelto con éxito!");
        }
        else
        {
            p.Estado = EstadoPrestamo.Activo;
            p.FechaDevolucion = null;
            p.LibroPrestado.Disponible = false; // El libro vuelve a estar ocupado
            Console.WriteLine("🔄 Préstamo reactivado.");
        }
    }
    PausarContinuar();
}

static void EliminarPrestamo()
{
    Console.Clear();
    Console.WriteLine("======= ELIMINAR REGISTRO DE PRESTAMO =======");
    var prestamos = _prestamoService.ObtenerTodos();

    for (int i = 0; i < prestamos.Count; i++)
        Console.WriteLine($"{i + 1}. {prestamos[i].LibroPrestado.Titulo}");

    Console.Write("\nIngresa el ID del préstamo a eliminar: ");
    if (int.TryParse(Console.ReadLine(), out int id))
    {
        _prestamoService.Eliminar(id - 1);
        Console.WriteLine("🗑️ Registro eliminado correctamente.");
    }
    PausarContinuar();
}

static void PausarContinuar()
{
    Console.WriteLine("\nPresiona cualquier tecla para continuar...");
    Console.ReadKey();
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

                            for (int i = 0; i < _libroService.ObtenerTodos().Count; i++) 
                            {
                                // CAMBIO: Accedemos a _libroService.ObtenerTodos()[i].Titulo
                                if (_libroService.ObtenerTodos()[i].Titulo.ToLower().Contains(busquedaTitulo)) 
                                {
                                    // CAMBIO: Usamos las propiedades del objeto o el método DetalleCompleto()
                                    Console.WriteLine(_libroService.ObtenerTodos()[i].DetalleCompleto());
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
                        for (int i = 0; i < _libroService.ObtenerTodos().Count; i++) 
                        {
                            if (_libroService.ObtenerTodos()[i].Autor.ToLower().Contains(busquedaAutor)) 
                            {
                                Console.WriteLine($"Autor: {_libroService.ObtenerTodos()[i].Autor} | Libro: {_libroService.ObtenerTodos()[i].Titulo}");
                                encontrado = true;
                            }
                        }
                        if (!encontrado) Console.WriteLine("No se encontró el autor.");
                    }
                    else if (subOpcion == "3")
                    {
                        Console.Clear();
                        Console.Write($"Ingrese el ID (1 al {_libroService.ObtenerTodos().Count}): "); 

                        if (int.TryParse(Console.ReadLine(), out int idBuscado)) 
                        {
                            int indice = idBuscado - 1;

                            if (indice >= 0 && indice < _libroService.ObtenerTodos().Count) 
                            {
                                Console.WriteLine("\nLibro Encontrado:");
                                
                                Console.WriteLine(_libroService.ObtenerTodos()[indice].DetalleCompleto());

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
                        for (int i = 0; i < _usuarioService.ObtenerTodos().Count; i++) {
                            if (_usuarioService.ObtenerPorIndice(i).Nombre.ToLower().Contains(busquedaUsuario)) {
                                Console.WriteLine($"Usuario: {_usuarioService.ObtenerPorIndice(i).Nombre} | Contacto: {_usuarioService.ObtenerPorIndice(i).Contacto}");
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
                        Console.Write($"Ingrese el ID (1 al {_usuarioService.ObtenerTodos().Count}): ");
                        if (int.TryParse(Console.ReadLine(), out int idBuscado)) {
                            int indice = idBuscado - 1;
                            if (indice >= 0 && indice < _usuarioService.ObtenerTodos().Count) {
                                Console.WriteLine("\nUsuario encontrado:");
                                Console.WriteLine($"-----------------------");
                                Console.WriteLine($"ID:      {idBuscado}"); 
                                Console.WriteLine($"Usuario:  {_usuarioService.ObtenerTodos()[indice]}");
                                Console.WriteLine($"Contacto:   {_usuarioService.ObtenerTodos()[indice].Contacto}");
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
                        for (int i = 0; i < _usuarioService.ObtenerTodos().Count; i++) {
                            if (_usuarioService.ObtenerPorIndice(i).Nombre.ToLower().Contains(busquedaUsuario)) {
                                Console.WriteLine($"Usuario: {_usuarioService.ObtenerPorIndice(i).Nombre} | prestamos: {_usuarioService.ObtenerPorIndice(i).PrestamosAcumulados}");
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

                        for (int i = 0; i < _libroService.ObtenerTodos().Count; i++) 
                        {

                            if (_libroService.ObtenerTodos()[i].Titulo.ToLower().Contains(busquedaLibro)) 
                            {
                                Console.WriteLine($"Libro: {_libroService.ObtenerTodos()[i].Titulo} | prestamos: {_libroService.ObtenerTodos()[i].ConteoPrestamos}");
                                
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

                        for (int i = 0; i < _libroService.ObtenerTodos().Count; i++)
                        {
                            string estado = _libroService.ObtenerTodos()[i].Disponible ? "Disponible" : "Prestado";
                            Console.WriteLine($"{i + 1}. {_libroService.ObtenerTodos()[i].Titulo.PadRight(25)} | Estado: {estado}");
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
static void GuardarDatos()
{
    try
    {
        var opciones = new JsonSerializerOptions { WriteIndented = true };
        var datos = new DataStorage
        {
            Libros = _libroService.ObtenerTodos(),
            Usuarios = _usuarioService.ObtenerTodos(),
            Prestamos = _prestamoService.ObtenerTodos()
        };

        string jsonString = JsonSerializer.Serialize(datos, opciones);
        File.WriteAllText("biblioteca.json", jsonString);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al guardar: {ex.Message}");
    }
}

static void CargarDatos()
{
    if (File.Exists("biblioteca.json"))
    {
        string jsonString = File.ReadAllText("biblioteca.json");
        var datosValidos = JsonSerializer.Deserialize<DataStorage>(jsonString);

        if (datosValidos != null)
        {
            _libroService.ObtenerTodos().Clear();
            _libroService.ObtenerTodos().AddRange(datosValidos.Libros ?? new List<Libro>());

            _usuarioService.ObtenerTodos().Clear();
            _usuarioService.ObtenerTodos().AddRange(datosValidos.Usuarios ?? new List<Usuario>());

            _prestamoService.ObtenerTodos().Clear();
            _prestamoService.ObtenerTodos().AddRange(datosValidos.Prestamos ?? new List<Prestamo>());
        }
    }
}
}
