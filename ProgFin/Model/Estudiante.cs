using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Estudiante
    {
        public int IdEstudiante { get; set; }
        public string Nombre { get; set; }
        public string EstudianteForeignKey { get; set; }
        public Prestamos Prestamos { get; set; }
    }
}
