using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class Libro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }
        public int AnioPublicacion { get; set; }

        public Libro(string titulo, string autor, string editorial, int anio)
        {
            Titulo = titulo;
            Autor = autor;
            Editorial = editorial;
            AnioPublicacion = anio;
        }

        public override string ToString()
        {
            return $"Título: {Titulo}, Autor: {Autor}, Editorial: {Editorial}, Año: {AnioPublicacion}";
        }
    }

    // Clase Biblioteca
    class Biblioteca
    {
        private List<Libro> libros = new List<Libro>();

        public void AgregarLibro(Libro libro)
        {
            libros.Add(libro);
            Console.WriteLine("Libro agregado correctamente.\n");
        }

        public void ListarLibros()
        {
            if (libros.Count == 0)
            {
                Console.WriteLine("No hay libros en la biblioteca.\n");
                return;
            }

            Console.WriteLine("Lista de libros:");
            foreach (var libro in libros)
            {
                Console.WriteLine(libro);
            }
            Console.WriteLine();
        }

        public void BuscarPorTitulo(string titulo)
        {
            var encontrados = libros.FindAll(l => l.Titulo.ToLower().Contains(titulo.ToLower()));

            if (encontrados.Count == 0)
            {
                Console.WriteLine("No se encontraron libros con ese título.\n");
                return;
            }

            Console.WriteLine("Libros encontrados:");
            foreach (var libro in encontrados)
            {
                Console.WriteLine(libro);
            }
            Console.WriteLine();
        }
    }
}
