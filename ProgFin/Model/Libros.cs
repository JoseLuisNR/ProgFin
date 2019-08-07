using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
   public class Libros
    {
        public int IdLibro { get; set; }
        public string NombreLib { get; set; }
        public int IdAutor { get; set; }
        public int IdTipo { get; set; }
        public Prestamos Prestamos { get; set; }
        public List<Autores> Autores { get; set; }
        public List<Tipolibro> Tipolibro  { get; set; }
        public int PrestamosForeignKey { get; set; }
        
    }
}
