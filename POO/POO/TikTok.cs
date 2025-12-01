using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{       
    public class Empleado
        {
            public DateTime FechaNacimiento { get; set; }
            public int Edad(int añoActual)
            {
                int edad = añoActual - FechaNacimiento.Year;
                if (FechaNacimiento > DateTime.Now.AddYears(-edad)) edad--;
                return edad;
            }
        }
    }
