using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Tipolibro
    {
        public int IdTipo { get; set; }
        public string NombreTipo { get; set; }
        public Libros Libros { get; set; }
        public string TipolibroForeignKey { get; set; }
    }
}
