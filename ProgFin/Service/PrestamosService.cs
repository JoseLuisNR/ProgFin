using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public interface IPrestamosService
    {
        IEnumerable<Prestamos> GetAll();
        bool Add(Prestamos Model);
        bool Delete(int id);
        bool Update(Prestamos Model);
        Prestamos Get(int id);
    }
    public class PrestamosService : IPrestamosService
    {
        private readonly LibraryDbContext _libraryDbContext;

        public PrestamosService(
            LibraryDbContext libraryDbContext
            )
        {
            _libraryDbContext = libraryDbContext;
        }

        public IEnumerable<Prestamos> GetAll()
        {
            var result = new List<Prestamos>();

            try
            {
                result = _libraryDbContext.Prestamos.ToList();
            }
            catch (System.Exception)
            {

            }

            return result;
        }
        public Prestamos Get(int id)
        {
            var result = new Prestamos();

            try
            {
                result = _libraryDbContext.Prestamos.Single(x => x.IdPrestamo == id);
            }
            catch (System.Exception)
            {

            }

            return result;
        }
        public bool Add(Prestamos Model)
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

        public bool Update(Prestamos Model)
        {

            try
            {
                var originalModel = _libraryDbContext.Prestamos.Single(x =>
                    x.IdPrestamo == Model.IdPrestamo
                    );
                originalModel.Prestamo = Model.Prestamo;
               
               

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
                _libraryDbContext.Entry(new Prestamos { IdPrestamo = id }).State = EntityState.Deleted; ;
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
