using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesSistemaBiblioteca
{
    public class Prestamo
    {

        public string Socio { get; set; }

        public string DiaPrestamo { get; set; }

        public string DiaDevolucion { get; set; }

        public List<Libro> LibrosPrestados { get; set; } = new List<Libro>();


        public Prestamo(string socio, string diaPrestamo, string diaDevolucion)
        {
            Socio = socio;
            DiaPrestamo = diaPrestamo;
            DiaDevolucion = diaDevolucion;
            LibrosPrestados = new List<Libro>();
        }


    }
}
