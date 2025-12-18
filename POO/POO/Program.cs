using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static POO.OficinaSeguros;

namespace POO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //---------------------------------ARRAY------------------------------------
            //int[] numeros = new int[3];
            //for (int i = 0; i < 3; i++)
            //{
            //    Console.WriteLine("Ingrese número: " + (i + 1) + ": ");
            //    numeros[i] = int.Parse(Console.ReadLine());
            //}
            //Console.WriteLine("\n numeros ingresados: ");
            //foreach (var item in numeros)
            //{
            //    Console.WriteLine(item);
            //}
            //int suma = 0;
            //for (int i = 0; i < 3; i++)
            //{
            //    suma += numeros[i];
            //}
            //Console.WriteLine("La suma de los números es: " + suma);

            //----------------------------------LISTA------------------------------------
            //List<int> numeros = new List<int>();
            //numeros.Add(10);
            //numeros.Add(20);
            //numeros.Add(30);
            //Console.WriteLine("Numeros en la lista: ");
            //foreach (int item in numeros) 
            //{ 
            //    Console.WriteLine(item);
            //}
            ////Acceder a un elemento por su índice
            //int primerNumero = numeros[1];
            //Console.WriteLine($"El numero en la lista es: {primerNumero}" );
            ////Modificar un elemento en la lista
            //numeros[2] = 50;
            //Console.WriteLine($"Numero modificado: {numeros[2]}");
            ////Insertar un elemento en una posición especifica
            //numeros.Insert(2, 15);
            //Console.WriteLine($"Numero insertado: {numeros[2]}");
            ////Eliminar un elemento de la lista especifica
            //numeros.RemoveAt(1);
            ////Eliminar por valor
            //numeros.Remove(10);

            //--------------EJERCICIO 1------------------------
            //List<string> productos = new List<string>();
            //List<double> precios = new List<double>();

            //int opcion = 0;

            //while (opcion != 5)
            //{
            //    Console.WriteLine("====== MENu DE PRODUCTOS ======");
            //    Console.WriteLine("1. Agregar producto");
            //    Console.WriteLine("2. Mostrar productos");
            //    Console.WriteLine("3. Actualizar producto");
            //    Console.WriteLine("4. Eliminar producto");
            //    Console.WriteLine("5. Salir");
            //    Console.Write("Elige una opción: ");
            //    opcion = int.Parse(Console.ReadLine());

            //    if (opcion == 1)
            //    {
            //        Console.Write("Nombre del producto: ");
            //        string nombre = Console.ReadLine();
            //        Console.Write("Precio: ");
            //        double precio = double.Parse(Console.ReadLine());
            //        productos.Add(nombre);
            //        precios.Add(precio);
            //        Console.WriteLine("Producto agregado ");
            //    }
            //    else if (opcion == 2)
            //    {
            //        Console.WriteLine("=== LISTA DE PRODUCTOS ===");
            //        for (int i = 0; i < productos.Count; i++)
            //        {
            //            Console.WriteLine($"{i + 1}. {productos[i]} - ${precios[i]}");
            //        }
            //    }
            //    else if (opcion == 3)
            //    {
            //        Console.Write("Número del producto a actualizar: ");
            //        int num = int.Parse(Console.ReadLine()) - 1;
            //        if (num >= 0 && num < productos.Count)
            //        {
            //            Console.Write("Nuevo nombre: ");
            //            productos[num] = Console.ReadLine();
            //            Console.Write("Nuevo precio: ");
            //            precios[num] = double.Parse(Console.ReadLine());
            //            Console.WriteLine("Producto actualizado ");
            //        }

            //    }
            //    else if (opcion == 4)
            //    {
            //        Console.Write("Número del producto a eliminar: ");
            //        int num = int.Parse(Console.ReadLine()) - 1;
            //        if (num >= 0 && num < productos.Count)
            //        {
            //            productos.RemoveAt(num);
            //            precios.RemoveAt(num);
            //            Console.WriteLine("Producto eliminado ");
            //        }

            //    }
            //    else if (opcion == 5)
            //    {
            //        Console.WriteLine("Saliendo del programa... ");
            //    }

            //    Console.WriteLine();
            //}


            //------------------------------CREAR OBJETO AUTO-------------------
            //Auto miAuto = new Auto("Toyota", "Corolla", "2020");
            //miAuto.MostrarInfo();

            //Auto camioneta = new Auto("Toyota", "TXL", "2026");
            //camioneta.MostrarInfo();

            //Auto camion = new Auto("FORD", "NPR", "2020");

            ////Editar info
            //camion.Marca = "Chevrolet";
            //camion.MostrarInfo();

            //-----------------------------CREAR OBJETO ESTUDIANTE-------------------
            //Console.WriteLine("Ingrese el nombre del estudiante ");
            //string nombre = Console.ReadLine();
            //Console.WriteLine("Ingrese la edad del estudiante");
            //int edad = int.Parse(Console.ReadLine());

            //Estudiante estudiante1 = new Estudiante(nombre, edad);
            //estudiante1.VerificarEdad();

            //---------------------------PRODUCTOS-----------------------------------
            //Producto.ProductoCrud producto = new Producto.ProductoCrud();
            //bool salir = false;
            //while (!salir)
            //{
            //    Console.WriteLine("\nSeleccione una opción");
            //    Console.WriteLine("1. Agregar producto");
            //    Console.WriteLine("2. Mostrar productos");
            //    Console.WriteLine("3. Actualizar producto");
            //    Console.WriteLine("4. Eliminar producto");
            //    Console.WriteLine("5. Salir");
            //    string opcion = Console.ReadLine();
            //    switch (opcion)
            //    {
            //        case "1":
            //            producto.AgregarProducto();
            //            break;
            //        case "2":
            //            producto.MostrarProductos();
            //            break;
            //        case "3":
            //            producto.ActualizarProducto();
            //            break;
            //        case "4":
            //            producto.EliminarProducto();
            //            break;
            //        case "5":
            //            salir = true;
            //            break;
            //        default:
            //            Console.WriteLine("Opcion no valida. Intenta de nuevo");
            //            break;
            //    }

            //}

            //-------------------------------------PERSONAS-------------------------------------
            //Console.WriteLine("=== PROGRAMA PERSONA ===");
            ////SOLICITAR DATOS
            //Console.WriteLine("Ingrese el nombre: ");
            //string nombre = Console.ReadLine();
            //Console.WriteLine("Ingrese la edad: ");
            //int edad = int.Parse(Console.ReadLine());

            //char genero;
            //do
            //{
            //    Console.WriteLine("Ingrese el género (F/M): ");
            //    genero = char.Parse(Console.ReadLine().ToUpper());
            //}
            //while (genero != 'F' && genero != 'M');
            //Console.WriteLine("Ingrese el telefono: ");
            //string telefono = Console.ReadLine();

            ////crear objeto
            //Persona persona = new Persona(nombre, edad, genero, telefono);
            //int opcion;
            //do
            //{
            //    Console.WriteLine("\nSeleccione una opción");
            //    Console.WriteLine("1. Imprimir detalles de la persona ");
            //    Console.WriteLine("2. Calcular edad en dias");
            //    Console.WriteLine("3. Salir");
            //    Console.WriteLine("Opción: ");
            //    opcion = int.Parse(Console.ReadLine());
            //    switch (opcion)
            //    {
            //        case 1:
            //            persona.ImprimirDetalles();
            //            break;
            //        case 2:
            //            persona.CalcularEdadEnDias();
            //            break;
            //        case 3:
            //            Console.WriteLine("Saliendo del programa...");
            //            break;
            //        default:
            //            Console.WriteLine("Opcion no valida, intente nuevamente.");
            //            break;
            //    }
            //} while (opcion != 3);

            //------------------------------------EJERCICIO DE LIBRO Y BIBLIOTECA---------------------
            //Biblioteca biblioteca = new Biblioteca();
            //int opcion;

            //do
            //{
            //    Console.WriteLine("=== MENÚ BIBLIOTECA ===");
            //    Console.WriteLine("1. Agregar libro");
            //    Console.WriteLine("2. Listar libros");
            //    Console.WriteLine("3. Buscar libro por título");
            //    Console.WriteLine("4. Salir");
            //    Console.Write("Elige una opción: ");

            //    if (!int.TryParse(Console.ReadLine(), out opcion))
            //    {
            //        Console.WriteLine("Opción no válida.\n");
            //        continue;
            //    }

            //    Console.WriteLine();

            //    switch (opcion)
            //    {
            //        case 1:
            //            Console.Write("Título: ");
            //            string titulo = Console.ReadLine();
            //            Console.Write("Autor: ");
            //            string autor = Console.ReadLine();
            //            Console.Write("Editorial: ");
            //            string editorial = Console.ReadLine();
            //            Console.Write("Año de publicación: ");
            //            int anio = int.Parse(Console.ReadLine());

            //            Libro nuevoLibro = new Libro(titulo, autor, editorial, anio);
            //            biblioteca.AgregarLibro(nuevoLibro);
            //            break;

            //        case 2:
            //            biblioteca.ListarLibros();
            //            break;

            //        case 3:
            //            Console.Write("Ingrese el título a buscar: ");
            //            string busqueda = Console.ReadLine();
            //            biblioteca.BuscarPorTitulo(busqueda);
            //            break;

            //        case 4:
            //            Console.WriteLine("Saliendo del programa...");
            //            break;

            //        default:
            //            Console.WriteLine("Opción no válida.\n");
            //            break;
            //    }

            //} while (opcion != 4);

            //----------------------------------PROGRAMA ACADEMICO------------------------------
            // Lista de carreras disponibles
            //List<Carrera> carreras = new List<Carrera>()
            //{
            //    new Carrera("Ingeniería de Sistemas", 20, 18),
            //    new Carrera("Psicología", 16, 12),
            //    new Carrera("Economía", 18, 10),
            //    new Carrera("Comunicación Social", 18, 5),
            //    new Carrera("Administración de Empresas", 20, 15)
            //};

            //List<Participante> participantes = new List<Participante>();

            //Console.Write("Ingrese el número de participantes a matricular: ");
            //int cantidad = int.Parse(Console.ReadLine());
            //Console.WriteLine();

            //// Registro de participantes
            //for (int i = 0; i < cantidad; i++)
            //{
            //    Console.WriteLine($"=== Participante #{i + 1} ===");
            //    Console.Write("Nombre del participante: ");
            //    string nombre = Console.ReadLine();

            //    Console.WriteLine("\nSeleccione la carrera:");
            //    for (int j = 0; j < carreras.Count; j++)
            //    {
            //        Console.WriteLine($"{j + 1}. {carreras[j].Nombre}");
            //    }

            //    Console.Write("Opción: ");
            //    int opcionCarrera = int.Parse(Console.ReadLine()) - 1;
            //    Carrera carreraSeleccionada = carreras[opcionCarrera];

            //    Console.Write("Método de pago (Efectivo / En línea): ");
            //    string metodoPago = Console.ReadLine();

            //    participantes.Add(new Participante(nombre, carreraSeleccionada, metodoPago));
            //    Console.WriteLine();
            //}

            //// Variables para los resultados
            //Dictionary<string, int> inscritosPorCarrera = new Dictionary<string, int>();
            //int totalCreditos = 0;
            //double totalBruto = 0;
            //double totalDescuentos = 0;
            //double totalNeto = 0;

            //foreach (var carrera in carreras)
            //    inscritosPorCarrera[carrera.Nombre] = 0;

            //foreach (var p in participantes)
            //{
            //    inscritosPorCarrera[p.CarreraSeleccionada.Nombre]++;
            //    totalCreditos += p.CarreraSeleccionada.Creditos;
            //    totalBruto += p.ValorSinDescuento();
            //    totalDescuentos += p.DescuentoAplicado();
            //    totalNeto += p.ValorFinal();
            //}

            //// Resultados finales
            //Console.WriteLine("\n=== RESULTADOS ===");
            //Console.WriteLine("\na) Cantidad de participantes por carrera:");
            //foreach (var kvp in inscritosPorCarrera)
            //{
            //    Console.WriteLine($"{kvp.Key}: {kvp.Value} participante(s)");
            //}

            //Console.WriteLine($"\nb) Total de créditos inscritos: {totalCreditos}");
            //Console.WriteLine($"c) Valor total sin descuento: ${totalBruto:N0}");
            //Console.WriteLine($"d) Valor total de descuentos: ${totalDescuentos:N0}");
            //Console.WriteLine($"e) Valor neto total pagado: ${totalNeto:N0}");

            //------------------------------COMPUTRONIC--------------------------------

            //Console.Write("Ingrese la cantidad de empleados: ");
            //int cantidadEmpleados = int.Parse(Console.ReadLine());
            //Console.WriteLine();


            //List<Computronic.Empleado> empleados = new List<Computronic.Empleado>();

            //for (int i = 0; i < cantidadEmpleados; i++)
            //{
            //    Console.Write($"Nombre del empleado #{i + 1}: ");
            //    string nombre = Console.ReadLine();

            //    Computronic.Empleado empleado = new Computronic.Empleado(nombre);

            //    Console.Write($"Ingrese cuántas ventas realizó {nombre} hoy: ");
            //    int cantidadVentas = int.Parse(Console.ReadLine());

            //    for (int j = 0; j < cantidadVentas; j++)
            //    {
            //        Console.Write($"Monto de la venta #{j + 1}: $");
            //        double venta = double.Parse(Console.ReadLine());
            //        empleado.AgregarVenta(venta);
            //    }

            //    empleados.Add(empleado);
            //    Console.WriteLine();
            //}

            //Console.WriteLine("\n===== RESUMEN FINAL =====");

            //foreach (var emp in empleados)
            //{
            //    emp.MostrarResumen();
            //}

            //--------------------------------OFICINA SEGUROS----------------------------
            //List<Conductor> conductores = new List<Conductor>();

            //Console.Write("Ingrese la cantidad de conductores a registrar: ");
            //int cantidad = int.Parse(Console.ReadLine());

            //int añoActual = DateTime.Now.Year;

            //for (int i = 0; i < cantidad; i++)
            //{
            //    Console.WriteLine($"\n--- Datos del conductor #{i + 1} ---");

            //    Console.Write("Año de nacimiento: ");
            //    int añoNacimiento = int.Parse(Console.ReadLine());

            //    int sexo;
            //    do
            //    {
            //        Console.Write("Sexo (1: Femenino, 2: Masculino): ");
            //        sexo = int.Parse(Console.ReadLine());
            //    } while (sexo != 1 && sexo != 2);

            //    int registro;
            //    do
            //    {
            //        Console.Write("Registro del carro (1: Bogotá, 2: Otras ciudades): ");
            //        registro = int.Parse(Console.ReadLine());
            //    } while (registro != 1 && registro != 2);

            //    conductores.Add(new Conductor
            //    {
            //        AñoNacimiento = añoNacimiento,
            //        Sexo = sexo,
            //        RegistroCarro = registro
            //    });
            //}

            //// Cálculos (igual que antes)...

            //int menores30 = 0;
            //int totalConductores = conductores.Count;

            //int contadorFemenino = 0;
            //int contadorMasculino = 0;

            //int masculinoEntre12y30 = 0;
            //int fueraBogota = 0;

            //foreach (var c in conductores)
            //{
            //    int edad = c.Edad(añoActual);

            //    if (edad < 30)
            //        menores30++;

            //    if (c.Sexo == 1)
            //        contadorFemenino++;
            //    else if (c.Sexo == 2)
            //        contadorMasculino++;

            //    if (c.Sexo == 2 && edad >= 12 && edad <= 30)
            //        masculinoEntre12y30++;

            //    if (c.RegistroCarro == 2)
            //        fueraBogota++;
            //}

            //Console.WriteLine("\n--- RESULTADOS ---");

            //Console.WriteLine($"Porcentaje de conductores menores de 30 años: {((double)menores30 / totalConductores) * 100:F2}%");
            //Console.WriteLine($"Porcentaje de conductores femeninos: {((double)contadorFemenino / totalConductores) * 100:F2}%");
            //Console.WriteLine($"Porcentaje de conductores masculinos: {((double)contadorMasculino / totalConductores) * 100:F2}%");
            //Console.WriteLine($"Porcentaje de conductores masculinos entre 12 y 30 años: {((double)masculinoEntre12y30 / totalConductores) * 100:F2}%");
            //Console.WriteLine($"Porcentaje de conductores con carros registrados fuera de Bogotá: {((double)fueraBogota / totalConductores) * 100:F2}%");

            //--------------------------------------------TIK TOK------------------------------------------------
            //List<Empleado> empleados = new List<Empleado>();

            //Console.Write("Ingrese la cantidad de empleados: ");
            //int cantidad = int.Parse(Console.ReadLine());

            //int añoActual = DateTime.Now.Year;
            //const int bono = 150000;

            //for (int i = 0; i < cantidad; i++)
            //{
            //    DateTime fechaNacimiento;
            //    while (true)
            //    {
            //        Console.Write($"Ingrese fecha de nacimiento del empleado #{i + 1} (formato: yyyy-MM-dd): ");
            //        string input = Console.ReadLine();

            //        if (DateTime.TryParse(input, out fechaNacimiento))
            //        {
            //            break;
            //        }
            //        else
            //        {
            //            Console.WriteLine("Fecha inválida, intente de nuevo.");
            //        }
            //    }

            //    empleados.Add(new Empleado { FechaNacimiento = fechaNacimiento });
            //}

            //// Filtrar empleados con edad entre 18 y 49 años
            //var empleadosConBono = empleados.Where(e =>
            //{
            //    int edad = e.Edad(añoActual);
            //    return edad >= 18 && edad < 50;
            //}).ToList();

            //// Promedio de edades de empleados con bono
            //double promedioEdad = empleadosConBono.Any() ? empleadosConBono.Average(e => e.Edad(añoActual)) : 0;

            //// Diccionario para almacenar empleados por mes
            //var empleadosPorMes = new Dictionary<int, List<Empleado>>();
            //for (int mes = 1; mes <= 12; mes++)
            //{
            //    empleadosPorMes[mes] = new List<Empleado>();
            //}

            //// Clasificar empleados con bono por mes de cumpleaños
            //foreach (var e in empleadosConBono)
            //{
            //    empleadosPorMes[e.FechaNacimiento.Month].Add(e);
            //}

            //// Mostrar resultados
            //Console.WriteLine($"\nPromedio de edad de empleados con bono: {promedioEdad:F2} años\n");

            //Console.WriteLine("Mes\tEmpleados\tDinero en bonos");
            //int totalBonos = 0;
            //string[] nombresMeses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio",
            //                         "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };

            //for (int mes = 1; mes <= 12; mes++)
            //{
            //    int cantidadEmpleadosMes = empleadosPorMes[mes].Count;
            //    int dineroBonosMes = cantidadEmpleadosMes * bono;
            //    totalBonos += dineroBonosMes;

            //    Console.WriteLine($"{nombresMeses[mes - 1]}\t{cantidadEmpleadosMes} empleados\tDinero en bonos: ${dineroBonosMes:N0}");
            //}

            //Console.WriteLine($"\nTotal dinero a pagar en bonos por la empresa Tik Tok: ${totalBonos:N0}");

            //------------------------------------DISTRIBUIDORA QUIMICO--------------------------------------------
            const int totalCamiones = 20;

            for (int camionNumero = 1; camionNumero <= totalCamiones; camionNumero++)
            {
                Console.WriteLine($"--- Camión #{camionNumero} ---");

                // Pedir capacidad del camión
                int capacidadCamion;
                do
                {
                    Console.Write("Ingrese la capacidad del camión (entre 18000 y 28000 litros): ");
                } while (!int.TryParse(Console.ReadLine(), out capacidadCamion) || capacidadCamion < 18000 || capacidadCamion > 28000);

                int cargaActual = 0;

                while (true)
                {
                    // Pedir volumen del tanque
                    int volumenTanque;
                    do
                    {
                        Console.Write("Ingrese el volumen del tanque (entre 3000 y 9000 litros): ");
                    } while (!int.TryParse(Console.ReadLine(), out volumenTanque) || volumenTanque < 3000 || volumenTanque > 9000);

                    if (cargaActual + volumenTanque <= capacidadCamion)
                    {
                        cargaActual += volumenTanque;
                        Console.WriteLine($"Tanque cargado. Carga actual: {cargaActual} litros.");
                    }
                    else
                    {
                        Console.WriteLine($"No se puede cargar el tanque porque excede la capacidad del camión.");
                        Console.WriteLine($"Despachando camión #{camionNumero} con carga de {cargaActual} litros.\n");
                        break; // Salir para pasar al siguiente camión
                    }
                }
            }

            Console.WriteLine("Carga de los 20 camiones finalizada.");
        }
    }
}