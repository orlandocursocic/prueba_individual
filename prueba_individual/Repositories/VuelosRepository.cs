using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prueba_individual.Models;
using prueba_individual.Exceptions;
using System.Data.Entity;

namespace prueba_individual.Repositories
{
    public class VuelosRepository : IVuelosRepository
    {
        public Vuelo Create(Vuelo vuelo)
        {
            return ApplicationDbContext.applicationDbContext.Vuelos.Add(vuelo);
        }

        public Vuelo Delete(long Id)
        {
            Vuelo vuelo = ApplicationDbContext.applicationDbContext.Vuelos.Find(Id);
            if (vuelo == null)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }

            ApplicationDbContext.applicationDbContext.Vuelos.Remove(vuelo);
            return vuelo;
        }

        public Vuelo Read(long Id)
        {
            return ApplicationDbContext.applicationDbContext.Vuelos.Find(Id);
        }

        public IQueryable<Vuelo> ReadAll()
        {
            IList<Vuelo> lista = new List<Vuelo>(ApplicationDbContext.applicationDbContext.Vuelos);

            return lista.AsQueryable();
        }

        public void Update(Vuelo vuelo)
        {
            if (ApplicationDbContext.applicationDbContext.Vuelos.Count(v => v.Id == vuelo.Id) == 0)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }
            ApplicationDbContext.applicationDbContext.Entry(vuelo).State = EntityState.Modified;
        }
    }
}