using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    class Estudiante
    {
        public int IdEstudiante { get; set; }
        public string Nombre { get; set; }
        public string EstudianteForeignKey { get; set; }
        public List<Prestamos> Prestamos { get; set; }
    }
}
