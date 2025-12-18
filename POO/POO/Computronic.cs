using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class Computronic
    {
        public class Empleado
        {
            public string Nombre { get; set; }
            public List<double> Ventas { get; set; } = new List<double>();

            // Pago base fijo
            private const double PagoBase = 500000;

            public Empleado(string nombre)
            {
                Nombre = nombre;
            }

            public void AgregarVenta(double monto)
            {
                if (monto > 0)
                    Ventas.Add(monto);
                else
                    Console.WriteLine("❌ El monto debe ser positivo.");
            }

            public int VentasMenoresIguales300()
            {
                return Ventas.FindAll(v => v <= 300000).Count;
            }

            public int VentasEntre300y800()
            {
                return Ventas.FindAll(v => v > 300000 && v < 800000).Count;
            }

            public int VentasMayoresIguales800()
            {
                return Ventas.FindAll(v => v >= 800000).Count;
            }

            public double TotalVentas()
            {
                double total = 0;
                foreach (var v in Ventas)
                    total += v;
                return total;
            }

            public double CalcularBonificacion()
            {
                double total = TotalVentas();

                if (total >= 800000)
                    return total * 0.10;
                else if (total >= 400001 && total <= 800000)
                    return total * 0.05;
                else if (total >= 400000) // igual a 400000
                    return total * 0.03;
                else
                    return 0;
            }

            public double TotalPagar()
            {
                return PagoBase + CalcularBonificacion();
            }

            public void MostrarResumen()
            {
                Console.WriteLine($"\n=== Empleado: {Nombre} ===");
                Console.WriteLine($"Ventas ≤ 300.000: {VentasMenoresIguales300()}");
                Console.WriteLine($"Ventas > 300.000 y < 800.000: {VentasEntre300y800()}");
                Console.WriteLine($"Ventas ≥ 800.000: {VentasMayoresIguales800()}");
                Console.WriteLine($"Monto total vendido: ${TotalVentas():N0}");
                Console.WriteLine($"Bonificación: ${CalcularBonificacion():N0}");
                Console.WriteLine($"Pago base: ${PagoBase:N0}");
                Console.WriteLine($"Total a pagar: ${TotalPagar():N0}\n");
            }
        }
    }
}
