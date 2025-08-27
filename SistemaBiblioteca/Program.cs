using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesSistemaBiblioteca;

namespace SistemaBiblioteca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Digital> digitales = new List<Digital>();
            List<Libro> libros = new List<Libro>();
            List<Prestamo> prestamos = new List<Prestamo>();

            while (true)
            {


                int opcion = 0;
                Console.Clear();
                Console.WriteLine("Sistema de Biblioteca");
                Console.WriteLine("\n1. Registrar libro");
                Console.WriteLine("2. Registrar un préstamo");
                Console.WriteLine("3. Mostrar info de un libro");
                Console.WriteLine("4. Mostrar todos los libros");
                Console.WriteLine("5. Salir");
                Console.Write("\nSeleccione una opción: ");







                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        AgregarLibro(libros);
                        break;


                    case 2:
                        RegistrarPrestamo(libros, prestamos);
                        break;


                    case 3:
                        MostrarInfoLibro(libros);
                        break;


                    case 4:
                        MostrarTodosLosLibros(libros);
                        break;

                    case 5:
                        return;

                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }

            }








        }








        static void AgregarLibro(List<Libro> libros)
        {
            Console.Clear();
            Console.WriteLine("Agregar Libro");
            Console.WriteLine("\n1. Fisico");
            Console.WriteLine("2. Digital");
            Console.Write("\nSeleccione el tipo de libro: ");
            int tipo = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.Write("Ingrese el ISBN: ");
            int isbn = int.Parse(Console.ReadLine());

            foreach (var libro in libros)
            {
                if (libro.ISBN == isbn)
                {
                    Console.WriteLine("El ISBN ya existe. No se puede agregar el libro.");
                    Console.ReadKey();
                    return;
                }
            }


            Console.Write("Título: ");
            string titulo = Console.ReadLine();
            Console.Write("Autor: ");
            string autor = Console.ReadLine();
            

            switch (tipo)
            {
                case 1:
                    libros.Add(new Fisico(isbn, titulo, autor));
                    break;
                case 2:
                    libros.Add(new Digital(isbn, titulo, autor));
                    break;
                default:
                    Console.WriteLine("Tipo no válido");
                    break;
            }
            Console.WriteLine("Libro agregado exitosamente!");
            Console.ReadKey();
        }


        static void RegistrarPrestamo(List<Libro> libros, List<Prestamo> prestamos)
        {
            Console.Clear();
            Console.WriteLine("Registrar Préstamo");
            Console.Write("ISBN del libro: ");
            int isbn = int.Parse(Console.ReadLine());

            foreach (var libro in libros)
            {
                if (libro.ISBN == isbn)
                {
                    
                    if (libro.Disponible)
                    {


                        Console.Write("Nombre del usuario: ");
                        string cliente = Console.ReadLine();

                        Console.Write("Fecha de préstamo (dd/mm/yyyy): ");
                        String diaPrestamo = Console.ReadLine();

                        Console.Write("Duracion de prestamos: ");
                        String diaDevolucion = Console.ReadLine();

                        libro.Prestados += 1;
                        if (libro is Digital)
                        {
                            
                            libro.Disponible = true;
                        }

                        else
                            libro.Disponible = false;

                        prestamos.Add(new Prestamo(cliente, diaPrestamo, diaDevolucion));
                        Console.WriteLine("Préstamo registrado exitosamente!");
                        Console.WriteLine("Toque una tecla para continuar...");
                        Console.ReadKey();
                        return;

                    }


                    else
                    {
                        Console.WriteLine("El libro no está disponible para préstamo.");
                        Console.WriteLine("Toque una tecla para continuar...");
                        Console.ReadKey();
                        return;
                    }

                }
            }
            Console.WriteLine("Libro no encontrado");
            Console.WriteLine("Toque una tecla para continuar...");
            Console.ReadKey();
        }


        static void MostrarInfoLibro(List<Libro> libros)
        {
            Console.Clear();
            Console.WriteLine("Mostrar Información de un Libro");
            Console.Write("ISBN del libro: ");
            int isbn = int.Parse(Console.ReadLine());
            foreach (var libro in libros)
            {
                if (libro.ISBN == isbn)
                {
                    Console.WriteLine($"Título: {libro.Titulo}");
                    Console.WriteLine($"Autor: {libro.Autor}");
                    Console.WriteLine($"Tipo: {libro.GetType().Name}");
                    Console.WriteLine($"Cantidad de préstamos: {libro.Prestados}");
                    Console.WriteLine($"Disponible: {(libro.Disponible ? "Disponible" : "No está disponible")}");

                    Console.WriteLine("Toque una tecla para continuar...");
                    Console.ReadKey();
                    return;
                }
            }
            Console.WriteLine("Libro no encontrado");
            Console.WriteLine("\nToque una tecla para continuar...");
            Console.ReadKey();
        }



        static void MostrarTodosLosLibros(List<Libro> libros)
        {
            Console.Clear();
            Console.WriteLine("Lista de todos los libros:\n");
            foreach (var libro in libros)
            {
                Console.WriteLine($"ISBN: {libro.ISBN}, Título: {libro.Titulo}, Autor: {libro.Autor}, Tipo: {libro.GetType().Name}, Préstados: {libro.Prestados}, Disponible: {(libro.Disponible ? "Sí" : "No")}");
            }

            Console.WriteLine("\n ESTADISTICAS GENERALES");
            int totalLibros = libros.Count;
            int totalPrestamos = 0;
            foreach (var libro in libros)
            {
                totalPrestamos += libro.Prestados;
            }
            Console.WriteLine($"Total de libros: {totalLibros}");
            Console.WriteLine($"Total de préstamos realizados: {totalPrestamos}");

            Console.WriteLine("\nToque una tecla para continuar...");
            Console.ReadKey();
        }


    }
}