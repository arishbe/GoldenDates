using System;

namespace GoldenDates.Models
{
    public class UserRequest
    {
        public int id_user { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime birthday { get; set; }
    }
}
