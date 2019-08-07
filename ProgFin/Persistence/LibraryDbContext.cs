using Microsoft.EntityFrameworkCore;
using Model;


namespace Persistence
{
    public class LibraryDbContext : DbContext
    {
        
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Prestamos> Prestamos { get; set; } 
        public DbSet<Libros> Libros { get; set; }
        public DbSet<Autores> Autores { get; set; }
        public DbSet<Tipolibro> Tipolibros { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudiante>()
                .HasKey(e => e.IdEstudiante);

            modelBuilder.Entity<Prestamos>()
                .HasKey(e => e.IdPrestamo);


            modelBuilder.Entity<Estudiante>()
                .HasOne(e => e.Prestamos)
                .WithMany(p => p.Estudiante)
                .HasForeignKey(p => p.EstudianteForeignKey);

            modelBuilder.Entity<Libros>()
                .HasOne(l => l.Prestamos)
                .WithMany(p => p.Libros)
                .HasForeignKey(l => l.PrestamosForeignKey);

            modelBuilder.Entity<Autores>()
                .HasOne(a => a.Libros)
                .WithMany(l => l.Autores)
                .HasForeignKey(a => a.LibrosForeignKey);

            modelBuilder.Entity<Tipolibro>()
                .HasOne(t => t.Libros)
                .WithMany(l => l.Tipolibro)
                .HasForeignKey(t => t.TipolibroForeignKey);






        }
    }
}
