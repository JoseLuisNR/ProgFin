using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Autores
    {
        public int IdAutor { get; set; }
        public string NombreAut { get; set; }
        public string ApellidoAut { get; set; }
        public string LibrosForeignKey { get; set; }
        public Libros Libros { get; set; }
    }
}
