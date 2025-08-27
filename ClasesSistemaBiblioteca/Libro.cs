using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesSistemaBiblioteca
{
    public abstract class Libro
    {
        public int ISBN { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Prestados { get; set; }

        public bool Disponible { get; set; }

        public Libro(int isbn, string titulo, string autor)
        {
            ISBN = isbn;
            Titulo = titulo;
            Autor = autor;
            Prestados = 0;
            Disponible = true;
        }


        
    }
}
