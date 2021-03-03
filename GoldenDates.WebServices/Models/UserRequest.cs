using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoldenDates.WebServices.Models
{
    public class LoginRequest
    {
        public string username { get; set; }
        public string password { get; set; }
    }
    public class LoginResponse
    {
        public int id_user { get; set; }
        public string username { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
    }
    public class UserRequest
    {
        public int id_user { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime birthday { get; set; }
    }
    public class UserResponse
    {
        public int id_user { get; set; }
    }
}