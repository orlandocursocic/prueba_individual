﻿using System;
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
        public string Nombre { get; set; }
    }
}