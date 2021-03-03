﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoldenDates.WebServices.Models
{
    public class ClientRequest
    {
        public int id_cli { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int telefono { get; set; }
        public string direccion { get; set; }
    }

    public class ClientResponse
    {
        public int id_cli { get; set; }
    }


}