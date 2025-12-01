using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class Auto
    {
        //atributos
        public string Marca {  get; set; }
        public string Modelo { get; set; }
        public string Año { get; set; }

        //constructor
        public Auto(string marca, string modelo, string año)
        {
            Marca = marca;
            Modelo = modelo;
            Año = año;
        }


        //Metodo mostrar info del auto 
        public void MostrarInfo()
        {
            Console.WriteLine($"Marca: {Marca}, Modelo: {Modelo}, Año: {Año}");
        }
         

    }
}
