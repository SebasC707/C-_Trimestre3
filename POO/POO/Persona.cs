using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class Persona
    {
        public string Nombre { get; set; }
        public int Edad {  get; set; }
        public char Genero { get; set; }
        public string Telefono { get; set; }

        public Persona(string nombre, int edad, char genero, string telefono)
        {
            Nombre = nombre;
            Edad = edad;
            Genero = genero;
            Telefono = telefono;
        }

        //Imprimir 
        public void ImprimirDetalles()
        {
            Console.WriteLine("\n ---- DETALLES PERSONA----");
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Edad: {Edad}");
            Console.WriteLine($"Genero: {(Genero == 'F' || Genero == 'f' ? "Femenino" : "Masculino")}");
            Console.WriteLine($"Telefono: {Telefono}");
            Console.WriteLine("-------------------------------------------");

        }
        //Calcular edad en dias
        public void CalcularEdadEnDias()
        {
            int dias = Edad * 365;
            Console.WriteLine($"\nLa edad de {Nombre} en dias es aproximadamente: {dias} dias");
        }

    }
}
