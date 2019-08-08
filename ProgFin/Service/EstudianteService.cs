using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public interface IEstudianteService
    {
        IEnumerable<estudiante> GetAll();
        bool Add(estudiante Model);
        bool Delete(int id);
        bool Update(estudiante Model);
        estudiante Get(int id);
    }
    public class EstudianteService : IEstudianteService
    {
        private readonly LibraryDbContext _libraryDbContext;
       

        public EstudianteService(
            LibraryDbContext libraryDbContext
            )
        {
            _libraryDbContext = libraryDbContext;
        }

        public IEnumerable<estudiante> GetAll()
        {
            var result = new List<estudiante>();

            try
            {
                result = _libraryDbContext.Estudiantes.ToList();
            }
            catch (System.Exception)
            {

            }

            return result;
        }
        public estudiante Get(int id)
        {
            var result = new estudiante();

            try
            {
                result = _libraryDbContext.Estudiantes.Single(x => x.IdEstudiante == id);
            }
            catch (System.Exception)
            {

            }

            return result;
        }
        public bool Add(estudiante Model)
        {
            
            try
            {
                _libraryDbContext.Estudiantes.Add(Model);
                _libraryDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
               
                return false;
                
                
            }
            return true;
            
        }

        public bool Update(estudiante Model)
        {

            try
            {
                var originalModel = _libraryDbContext.Estudiantes.Single(x =>
                    x.IdEstudiante == Model.IdEstudiante
                    );
                originalModel.Nombre = Model.Nombre;
                originalModel.Prestamos = Model.Prestamos;
               

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
                _libraryDbContext.Entry(new estudiante { IdEstudiante = id }).State = EntityState.Deleted; ;
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
