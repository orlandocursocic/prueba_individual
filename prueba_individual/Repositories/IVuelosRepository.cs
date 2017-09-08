using prueba_individual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prueba_individual.Repositories
{
    public interface IVuelosRepository
    {
        Vuelo Create(Vuelo vuelo);
        Vuelo Read(long Id);
        IQueryable<Vuelo> ReadAll();
        void Update(Vuelo vuelo);
        Vuelo Delete(long Id);
    }
}
