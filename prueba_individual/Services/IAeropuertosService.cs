using prueba_individual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prueba_individual.Services
{
    public interface IAeropuertosService
    {
        Aeropuerto Create(Aeropuerto aeropuerto);
        Aeropuerto Read(long Id);
        IQueryable<Aeropuerto> ReadAll();
        void Update(Aeropuerto aeropuerto);
        Aeropuerto Delete(long Id);
    }
}
