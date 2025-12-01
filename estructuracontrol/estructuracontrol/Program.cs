using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estructuracontrol
{
    internal class Program
    {
        static void Main(string[] args) //punto de partida
        {
            //// Solicitar los datos al usuario
            //Console.Write("Ingrese el nombre del empleado: ");
            //string usuario = Console.ReadLine();

            //Console.Write("Ingrese el salario mensual del empleado: ");
            //decimal salario = Convert.ToDecimal(Console.ReadLine());

            //Console.Write("Ingrese el valor de ahorro mensual programado: ");
            //decimal ahorroMensual = Convert.ToDecimal(Console.ReadLine());

            //// Calcular las deducciones
            //decimal aporteSalud = salario * 0.125m;  // 12.5% para EPS
            //decimal aportePension = salario * 0.16m; // 16% para Fondo de pensiones

            //// Calcular el total a recibir
            //decimal totalDeducido = aporteSalud + aportePension + ahorroMensual;
            //decimal totalRecibido = salario - totalDeducido;

            //// Mostrar la colilla de pago
            //Console.WriteLine("\n=== COLILLA DE PAGO ===");
            //Console.WriteLine($"Empleado: {usuario}");
            //Console.WriteLine($"Salario: {salario:C}");
            //Console.WriteLine($"Ahorro Mensual Programado: {ahorroMensual:C}");
            //Console.WriteLine($"Deducción por Aporte a la Salud (EPS - 12.5%): {aporteSalud:C}");
            //Console.WriteLine($"Deducción por Aporte al Fondo de Pensiones (16%): {aportePension:C}");
            //Console.WriteLine($"Total a Recibir: {totalRecibido:C}");

            //------------------------------------------------------------------------------------------------
            // Solicitar el valor total de la matrícula
            //Console.Write("Ingrese el valor total de la matrícula: ");
            //decimal matriculaTotal = Convert.ToDecimal(Console.ReadLine());

            //// Calcular el valor de cada cuota
            //decimal cuota1 = matriculaTotal * 0.40m;  // 40% para la primera cuota
            //decimal cuota2 = matriculaTotal * 0.25m;  // 25% para la segunda cuota
            //decimal cuota3 = matriculaTotal * 0.20m;  // 20% para la tercera cuota
            //decimal cuota4 = matriculaTotal * 0.15m;  // 15% para la cuarta cuota

            //// Mostrar el desglose de las cuotas
            //Console.WriteLine("\n=== DESGLOSE DE LAS CUOTAS DE MATRÍCULA ===");
            //Console.WriteLine($"Valor total de la matrícula: {matriculaTotal:C}");
            //Console.WriteLine($"Primera cuota (40%): {cuota1:C}");
            //Console.WriteLine($"Segunda cuota (25%): {cuota2:C}");
            //Console.WriteLine($"Tercera cuota (20%): {cuota3:C}");
            //Console.WriteLine($"Cuarta cuota (15%): {cuota4:C}");

            //-----------------------------------------------------------------------------
            //Console.WriteLine("Ingrese el nombre: ");
            //string nombre = Console.ReadLine();

            //Console.WriteLine("Ingrese la dirección: ");
            //string direccion = Console.ReadLine();

            //Console.WriteLine("Ingrese el año de nacimiento: ");
            //int anioNacimiento = int.Parse(Console.ReadLine());

            //int edad = DateTime.Now.Year - anioNacimiento;

            //Console.WriteLine($"/nNombre: {nombre}");
            //Console.WriteLine($"/nDirección: {direccion}");
            //Console.WriteLine($"/nEdad: {edad} años");

            //--------------------------------------------------------------------------------
            //float tiempo1Litro = 1.5f;
            //float tiempo3Litros = tiempo1Litro * 3;
            //float tiempo5Litros = tiempo1Litro * 5;

            //Console.WriteLine($"Tiempo para llenar 3 litros: {tiempo3Litros} horas");
            //Console.WriteLine($"Tiempo para llenar 5 litros: {tiempo5Litros} horas");

            //----------------------------------------------------------------------------------
            //float tiempo7m = 5f;

            //Console.WriteLine("Ingrese la altura que desea subir (en metros): ");
            //float altura = float.Parse(Console.ReadLine());

            //float tiempoEstimado = (tiempo7m / 7f) * altura;

            //Console.WriteLine($"Tiempo estimado: {tiempoEstimado} horas");

            //---------------------------------------------------------------------------------------
            //Console.WriteLine("=== Cálculo de tiempo para llenar baldes ===");

            //float tiempo1Litro = 90f;

            //float tiempo3Litros = tiempo1Litro * 3;
            //float tiempo5Litros = tiempo1Litro * 5;

            //Console.WriteLine("\n--- Baldes conocidos (1L, 3L, 5L) ---");
            //Console.WriteLine($"Tiempo para llenar 1 litro: {tiempo1Litro} minutos");
            //Console.WriteLine($"Tiempo para llenar 3 litros: {tiempo3Litros} minutos");
            //Console.WriteLine($"Tiempo para llenar 5 litros: {tiempo5Litros} minutos");

            //Console.WriteLine("\n--- Baldes de tamaño ingresado por el usuario ---");
            //Console.Write("Ingrese la cantidad de litros de un balde desconocido: ");
            //float litros = float.Parse(Console.ReadLine());

            //float tiempoDesconocido = tiempo1Litro * litros;

            //Console.WriteLine($"Tiempo estimado para llenar {litros} litros: {tiempoDesconocido} minutos");

            //-------------------------------------------------------------------------------------------------
            // Solicitar monto del préstamo
            Console.Write("Ingrese el monto del préstamo: ");
            decimal montoPrestamo = Convert.ToDecimal(Console.ReadLine());

            // Tasa de interés fija anual
            decimal tasaInteresAnual = 0.05m;  // 5%

            // Calcular el interés anual
            decimal interesAnual = montoPrestamo * tasaInteresAnual;

            // Calcular los intereses para el primer mes, tercer trimestre y total a pagar
            decimal interesPrimerMes = interesAnual / 12;
            decimal interesTercerTrimestre = interesAnual / 4;
            decimal totalPagar = montoPrestamo + (interesAnual * 5); // 5 años de préstamo

            // Mostrar la información calculada
            Console.WriteLine("\n=== INFORMACIÓN DEL PRÉSTAMO ===");
            Console.WriteLine($"Monto del préstamo: {montoPrestamo:C}");
            Console.WriteLine($"Interés pagado en un año: {interesAnual:C}");
            Console.WriteLine($"Interés pagado en el tercer trimestre (julio-septiembre): {interesTercerTrimestre:C}");
            Console.WriteLine($"Interés pagado en el primer mes: {interesPrimerMes:C}");
            Console.WriteLine($"Total a pagar durante 5 años (incluyendo intereses): {totalPagar:C}");
        }
    }
}
