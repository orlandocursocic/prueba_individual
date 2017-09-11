using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace prueba_individual.Models
{
    [Table("Vuelos")]
    public class Vuelo
    {
        public long Id { get; set; }
        public string CodigoVuelo { get; set; }
        public string Companyia { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaLlegada { get; set; }
    }
}