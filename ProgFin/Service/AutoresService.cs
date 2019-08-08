using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public interface IAutoresService
    {
        IEnumerable<Autores> GetAll();
        bool Add(Autores Model);
        bool Delete(int id);
        bool Update(Autores Model);
        Autores Get(int id);
    }
    public class AutoresService : IAutoresService
    {
        private readonly LibraryDbContext _libraryDbContext;

        public AutoresService(
            LibraryDbContext libraryDbContext
            )
        {
            _libraryDbContext = libraryDbContext;
        }

        public IEnumerable<Autores> GetAll()
        {
            var result = new List<Autores>();

            try
            {
                result = _libraryDbContext.Autores.ToList();
            }
            catch (System.Exception)
            {

            }

            return result;
        }
        public Autores Get(int id)
        {
            var result = new Autores();

            try
            {
                result = _libraryDbContext.Autores.Single(x => x.IdAutor == id);
            }
            catch (System.Exception)
            {

            }

            return result;
        }
        public bool Add(Autores Model)
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

        public bool Update(Autores Model)
        {

            try
            {
                var originalModel = _libraryDbContext.Autores.Single(x =>
                    x.IdAutor == Model.IdAutor
                    );
                originalModel.NombreAut = Model.NombreAut;
                originalModel.ApellidoAut = Model.ApellidoAut;
               

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
                _libraryDbContext.Entry(new Autores { IdAutor = id }).State = EntityState.Deleted; ;
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
