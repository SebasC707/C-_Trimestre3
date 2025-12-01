using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class Carrera
    {
        public string Nombre { get; set; }
        public int Creditos { get; set; }
        public double DescuentoEfectivo { get; set; }

        public Carrera(string nombre, int creditos, double descuento)
        {
            Nombre = nombre;
            Creditos = creditos;
            DescuentoEfectivo = descuento;
        }
    }

    // Clase Participante
    class Participante
    {
        public string NombreCompleto { get; set; }
        public Carrera CarreraSeleccionada { get; set; }
        public string MetodoPago { get; set; } // "Efectivo" o "En línea"

        public Participante(string nombre, Carrera carrera, string metodoPago)
        {
            NombreCompleto = nombre;
            CarreraSeleccionada = carrera;
            MetodoPago = metodoPago;
        }

        public double ValorSinDescuento()
        {
            return CarreraSeleccionada.Creditos * 200000;
        }

        public double DescuentoAplicado()
        {
            if (MetodoPago.ToLower() == "efectivo")
                return ValorSinDescuento() * CarreraSeleccionada.DescuentoEfectivo / 100;
            else
                return 0;
        }

        public double ValorFinal()
        {
            return ValorSinDescuento() - DescuentoAplicado();
        }
    }
}
