using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prueba_individual.Models;
using prueba_individual.Repositories;

namespace prueba_individual.Services
{
    public class AeropuertosService : IAeropuertosService
    {
        private IAeropuertosRepository aeropuertosRepository;

        public AeropuertosService(IAeropuertosRepository aeropuertosRepository)
        {
            this.aeropuertosRepository = aeropuertosRepository;
        }

        public Aeropuerto Create(Aeropuerto aeropuerto)
        {
            return aeropuertosRepository.Create(aeropuerto);
        }

        public Aeropuerto Delete(long Id)
        {
            return this.aeropuertosRepository.Delete(Id);
        }

        public Aeropuerto Read(long Id)
        {
            return this.aeropuertosRepository.Read(Id);
        }

        public IQueryable<Aeropuerto> ReadAll()
        {
            return this.aeropuertosRepository.ReadAll();
        }

        public void Update(Aeropuerto aeropuerto)
        {
            this.aeropuertosRepository.Update(aeropuerto);
        }
    }
}