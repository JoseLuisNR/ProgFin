using System;
using Microsoft.EntityFrameworkCore;
using Model;


namespace Persistence
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options)
        { }

        public DbSet<estudiante> Estudiantes { get; set; }
        public DbSet<Prestamos> Prestamos { get; set; } 
        public DbSet<Libros> Libros { get; set; }
        public DbSet<Autores> Autores { get; set; }
        public DbSet<Tipolibro> Tipolibros { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<estudiante>()
                .HasKey(e => e.IdEstudiante);

            modelBuilder.Entity<Prestamos>()
                .HasKey(p => p.IdPrestamo);

            modelBuilder.Entity<Libros>()
                .HasKey(l => l.IdLibro);

            modelBuilder.Entity<Tipolibro>()
                .HasKey(t => t.IdTipo);

            modelBuilder.Entity<Autores>()
                .HasKey(a => a.IdAutor);


            modelBuilder.Entity<estudiante>()
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

        public void Add(object model)
        {
            throw new NotImplementedException();
        }
    }
}
