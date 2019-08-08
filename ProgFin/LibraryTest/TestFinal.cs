using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Persistence;
using ProgFin.Controllers;
using Service;
namespace LibraryTest
{
    [TestClass]
    public class TestFinal
    {
        LibraryDbContext dbContext = new LibraryDbContext(new DbContextOptions<LibraryDbContext>());
        private readonly estudiante estudiante;
        private readonly Libros libros;
        private readonly Prestamos prestamos;
        private readonly Tipolibro tipolibro;
        private readonly Autores autores;
        private readonly LibraryDbContext _libraryDbContext;
        [TestMethod]
        public void Estud()
        {
            var estudiante = new estudiante();
            var fin = estudiante.ToString();
            Assert.IsNotNull(fin);


        }
        [TestMethod]
        public void AddEstudiante()
        {
            var service = new EstudianteService(dbContext);
            var controller = new EstudianteController(service);
            var fin = service.Add(estudiante);
            Assert.IsNotNull(fin);


        }
        [TestMethod]
        public void UpdateLibros()
        {
            var service = new LibrosService(dbContext);
            var controller = new LibrosController(service);
            var fin = service.Update(libros);
            Assert.IsNotNull(fin);


        }
        [TestMethod]
        public void DeletePrestamos()
        {
            var service = new PrestamosService(dbContext);
            var controller = new PrestamosController(service);
            var fin = service.Update(prestamos);
            Assert.IsNotNull(fin);


        }
        [TestMethod]
        public void AddAutores()
        {
            var service = new AutoresService(dbContext);
            var controller = new AutoresController(service);
            var fin = service.Update(autores);
            Assert.IsNotNull(fin);


        }
        [TestMethod]
        public void UpdateTipolibro()
        {
            var service = new TipolibroService(dbContext);
            var controller = new TipolibroController(service);
            var fin = service.Update(tipolibro);
            Assert.IsNotNull(fin);


        }

    }
    }

