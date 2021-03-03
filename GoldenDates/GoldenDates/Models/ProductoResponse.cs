using System;
using System.Collections.Generic;
using System.Text;

namespace GoldenDates.Models
{
   public class ProductoResponse
    {
        public int id_prod { get; set; }
        public string description { get; set; }
        public int cantidad { get; set; }
        public int stockmin { get; set; }
        public int stockmax { get; set; }

    }
}
