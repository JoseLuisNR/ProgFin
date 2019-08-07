using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    class Prestamos
    {
        public int IdPrestamo { get; set; }
        public string IdEstudiante { get; set; }
        public string IdLibro { get; set; }
        public string EstudianteForeignKey { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaEntregar { get; set; }
        public Estudiante Estudiante { get; set; }
    }
}
