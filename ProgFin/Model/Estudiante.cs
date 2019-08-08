using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class estudiante
    {
        public int IdEstudiante { get; set; }
        public string Nombre { get; set; }
        public int EstudianteForeignKey { get; set; }
        public Prestamos Prestamos { get; set; }
    }
}
