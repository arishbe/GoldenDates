using System;
using System.Collections.Generic;
using System.Text;

namespace GoldenDates.Models
{
   public class LoginResponse
    {
        public int id_user { get; set; }
        public string username { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
    }
}
