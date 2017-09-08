using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prueba_individual.Models;
using prueba_individual.Repositories;

namespace prueba_individual.Services
{
    public class VuelosService : IVuelosService
    {
        private IVuelosRepository vuelosRepository;

        public VuelosService(IVuelosRepository vuelosRepository)
        {
            this.vuelosRepository = vuelosRepository;
        }

        public Vuelo Create(Vuelo vuelo)
        {
            return this.vuelosRepository.Create(vuelo);
        }

        public Vuelo Delete(long Id)
        {
            return this.vuelosRepository.Delete(Id);
        }

        public Vuelo Read(long Id)
        {
            return this.vuelosRepository.Read(Id);
        }

        public IQueryable<Vuelo> ReadAll()
        {
            return this.vuelosRepository.ReadAll();
        }

        public void Update(Vuelo vuelo)
        {
            this.vuelosRepository.Update(vuelo);
        }
    }
}