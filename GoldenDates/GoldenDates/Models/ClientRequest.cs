using System;
using System.Collections.Generic;
using System.Text;

namespace GoldenDates.Models
{
    public class ClientRequest
    {
        public int id_cli { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int telefono { get; set; }
        public string direccion { get; set; }
    }
}
