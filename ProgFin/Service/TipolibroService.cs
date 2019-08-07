using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public interface ITipolibroService
    {
        IEnumerable<Tipolibro> GetAll();
        bool Add(Tipolibro Model);
        bool Delete(int id);
        bool Update(Tipolibro Model);
        Tipolibro Get(int id);
    }
    public class TipolibroService : ITipolibroService
    {
        private readonly LibraryDbContext _libraryDbContext;

        public TipolibroService(
            LibraryDbContext libraryDbContext
            )
        {
            _libraryDbContext = libraryDbContext;
        }

        public IEnumerable<Tipolibro> GetAll()
        {
            var result = new List<Tipolibro>();

            try
            {
                result = _libraryDbContext.Tipolibros.ToList();
            }
            catch (System.Exception)
            {

            }

            return result;
        }
        public Tipolibro Get(int id)
        {
            var result = new Tipolibro();

            try
            {
                result = _libraryDbContext.Tipolibros.Single(x => x.IdTipo == id);
            }
            catch (System.Exception)
            {

            }

            return result;
        }
        public bool Add(Tipolibro Model)
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

        public bool Update(Tipolibro Model)
        {

            try
            {
                var originalModel = _libraryDbContext.Tipolibros.Single(x =>
                    x.IdTipo == Model.IdTipo
                    );
                originalModel.NombreTipo = Model.NombreTipo;
                
               

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
                _libraryDbContext.Entry(new Tipolibro { IdTipo = id }).State = EntityState.Deleted; ;
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
