using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace prueba_individual.Models
{
    [Table("Aeropuertos")]
    public class Aeropuerto
    {
        public long Id {get; set;}
        public string Nombre { get; set; }
        public int numTerminales { get; set; }
        public string Ciudad { get; set; } 
        public string Pais { get; set; }
    }
}