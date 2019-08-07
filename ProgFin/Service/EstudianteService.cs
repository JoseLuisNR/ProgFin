﻿using Microsoft.EntityFrameworkCore;
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
        IEnumerable<Estudiante> GetAll();
        bool Add(Estudiante Model);
        bool Delete(int id);
        bool Update(Estudiante Model);
        Estudiante Get(int id);
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

        public IEnumerable<Estudiante> GetAll()
        {
            var result = new List<Estudiante>();

            try
            {
                result = _libraryDbContext.Estudiantes.ToList();
            }
            catch (System.Exception)
            {

            }

            return result;
        }
        public Estudiante Get(int id)
        {
            var result = new Estudiante();

            try
            {
                result = _libraryDbContext.Estudiantes.Single(x => x.IdEstudiante == id);
            }
            catch (System.Exception)
            {

            }

            return result;
        }
        public bool Add(Estudiante Model)
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

        public bool Update(Estudiante Model)
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
                _libraryDbContext.Entry(new Estudiante { IdEstudiante = id }).State = EntityState.Deleted; ;
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
