using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Prestamos
    {
        public int IdPrestamo { get; set; }
        public int IdEstudiante { get; set; }
        public int IdLibro { get; set; }
        public string Prestamo { get; set; }
       
        

        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaEntregar { get; set; }
        public List<Estudiante> Estudiante { get; set; }
        public List<Libros> Libros { get; set; }
    }
}
