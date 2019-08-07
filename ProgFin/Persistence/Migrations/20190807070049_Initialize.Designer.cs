﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    [Migration("20190807070049_Initialize")]
    partial class Initialize
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Model.Autores", b =>
                {
                    b.Property<int>("IdAutor")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApellidoAut");

                    b.Property<int>("LibrosForeignKey");

                    b.Property<string>("NombreAut");

                    b.HasKey("IdAutor");

                    b.HasIndex("LibrosForeignKey");

                    b.ToTable("Autores");
                });

            modelBuilder.Entity("Model.Estudiante", b =>
                {
                    b.Property<int>("IdEstudiante")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EstudianteForeignKey");

                    b.Property<string>("Nombre");

                    b.HasKey("IdEstudiante");

                    b.HasIndex("EstudianteForeignKey");

                    b.ToTable("Estudiantes");
                });

            modelBuilder.Entity("Model.Libros", b =>
                {
                    b.Property<int>("IdLibro")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdAutor");

                    b.Property<int>("IdTipo");

                    b.Property<string>("NombreLib");

                    b.Property<int>("PrestamosForeignKey");

                    b.HasKey("IdLibro");

                    b.HasIndex("PrestamosForeignKey");

                    b.ToTable("Libros");
                });

            modelBuilder.Entity("Model.Prestamos", b =>
                {
                    b.Property<int>("IdPrestamo")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaEntregar");

                    b.Property<DateTime>("FechaPrestamo");

                    b.Property<int>("IdEstudiante");

                    b.Property<int>("IdLibro");

                    b.Property<string>("Prestamo");

                    b.HasKey("IdPrestamo");

                    b.ToTable("Prestamos");
                });

            modelBuilder.Entity("Model.Tipolibro", b =>
                {
                    b.Property<int>("IdTipo")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NombreTipo");

                    b.Property<int>("TipolibroForeignKey");

                    b.HasKey("IdTipo");

                    b.HasIndex("TipolibroForeignKey");

                    b.ToTable("Tipolibros");
                });

            modelBuilder.Entity("Model.Autores", b =>
                {
                    b.HasOne("Model.Libros", "Libros")
                        .WithMany("Autores")
                        .HasForeignKey("LibrosForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Model.Estudiante", b =>
                {
                    b.HasOne("Model.Prestamos", "Prestamos")
                        .WithMany("Estudiante")
                        .HasForeignKey("EstudianteForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Model.Libros", b =>
                {
                    b.HasOne("Model.Prestamos", "Prestamos")
                        .WithMany("Libros")
                        .HasForeignKey("PrestamosForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Model.Tipolibro", b =>
                {
                    b.HasOne("Model.Libros", "Libros")
                        .WithMany("Tipolibro")
                        .HasForeignKey("TipolibroForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
