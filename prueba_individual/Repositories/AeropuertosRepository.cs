using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prueba_individual.Models;
using prueba_individual.Exceptions;
using System.Data.Entity;

namespace prueba_individual.Repositories
{
    public class AeropuertosRepository : IAeropuertosRepository
    {
        public Aeropuerto Create(Aeropuerto aeropuerto)
        {
            return ApplicationDbContext.applicationDbContext.Aeropuertos.Add(aeropuerto);
        }

        public Aeropuerto Delete(long Id)
        {
            Aeropuerto aeropuerto = ApplicationDbContext.applicationDbContext.Aeropuertos.Find(Id);
            if (aeropuerto == null)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }

            ApplicationDbContext.applicationDbContext.Aeropuertos.Remove(aeropuerto);
            return aeropuerto;
        }

        public Aeropuerto Read(long Id)
        {
            return ApplicationDbContext.applicationDbContext.Aeropuertos.Find(Id);
        }

        public IQueryable<Aeropuerto> ReadAll()
        {
            IList<Aeropuerto> lista = new List<Aeropuerto>(ApplicationDbContext.applicationDbContext.Aeropuertos);

            return lista.AsQueryable();
        }

        public void Update(Aeropuerto aeropuerto)
        {
            if (ApplicationDbContext.applicationDbContext.Aeropuertos.Count(a => a.Id == aeropuerto.Id) == 0)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }
            ApplicationDbContext.applicationDbContext.Entry(aeropuerto).State = EntityState.Modified;
        }
    }
}