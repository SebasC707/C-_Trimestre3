using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class OficinaSeguros
    {
        public class Conductor
        {
            public int AñoNacimiento { get; set; }
            public int Sexo { get; set; } // 1: Femenino, 2: Masculino
            public int RegistroCarro { get; set; } // 1: Bogotá, 2: Otras ciudades

            public int Edad(int añoActual)
            {
                return añoActual - AñoNacimiento;
            }
        }
    }
}
