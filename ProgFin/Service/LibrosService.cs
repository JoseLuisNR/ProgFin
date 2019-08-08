using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public interface ILibrosService
    {
        IEnumerable<Libros> GetAll();
        bool Add(Libros Model);
        bool Delete(int id);
        bool Update(Libros Model);
        Libros Get(int id);
    }
    public class LibrosService : ILibrosService
    {
        private readonly LibraryDbContext _libraryDbContext;

        public LibrosService(
            LibraryDbContext libraryDbContext
            )
        {
            _libraryDbContext = libraryDbContext;
        }

        public IEnumerable<Libros> GetAll()
        {
            var result = new List<Libros>();

            try
            {
                result = _libraryDbContext.Libros.ToList();
            }
            catch (System.Exception)
            {

            }

            return result;
        }
        public Libros Get(int id)
        {
            var result = new Libros();

            try
            {
                result = _libraryDbContext.Libros.Single(x => x.IdLibro == id);
            }
            catch (System.Exception)
            {

            }

            return result;
        }
        public bool Add(Libros Model)
        {
            
            try
            {
                _libraryDbContext.Add(Model);
                _libraryDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
            
        }

        public bool Update(Libros Model)
        {

            try
            {
                var originalModel = _libraryDbContext.Libros.Single(x =>
                    x.IdLibro == Model.IdLibro
                    );
                originalModel.NombreLib = Model.NombreLib;
                
               

                _libraryDbContext.Update(Model);
                _libraryDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;

        }
        public bool Delete(int id)
        {
            try
            {
                _libraryDbContext.Entry(new Libros { IdLibro = id }).State = EntityState.Deleted; ;
                _libraryDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }
    }
}
