using GoldenDates.WebServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace GoldenDates.WebServices.Controllers
{
    public class UsuariosController : Controller
    {
        //LOGIN
        [HttpPost]
        public JsonResult LoginUsers(LoginRequest _userData)
        {

            var _LoginResponse = new LoginResponse();
            using (var bd = new bdgoldendatesEntities ())
            {
                var usuario = bd.Usuarios.Where(w => w.username == _userData.username && w.password == _userData.password).FirstOrDefault();
                if (usuario != null)
                {
                    _LoginResponse.id_user = usuario.id_user;
                    _LoginResponse.username = usuario.username;
                    _LoginResponse.nombre= usuario.nombre;
                    _LoginResponse.apellido = usuario.apelllido;
                }
            }
            return Json(_LoginResponse, JsonRequestBehavior.DenyGet);
        }
        //AGREGAR USUARIO
        [HttpPost]
        public JsonResult AddUsers(UserRequest _userRequest)
        {
            var _userResponse = new UserResponse();
            using (var bd = new bdgoldendatesEntities())
            {
                var user = new Usuarios();
                user.username = _userRequest.username;
                user.password = _userRequest.password;
                user.nombre = _userRequest.nombre;
                user.apelllido = _userRequest.apellido;
                //user.birthday = _userRequest.birthday;
                user.birthday = DateTime.Now;
                user.IsActive = true;
                user.FechaRegistro = DateTime.Now;

                bd.Entry(user).State = System.Data.Entity.EntityState.Added;
                bd.SaveChanges();
                _userResponse.id_user = user.id_user;
            }

            return Json(_userResponse, JsonRequestBehavior.DenyGet);
        }

        //EDITAR
        [HttpPost]
        public JsonResult EditUsers(UserRequest _userRequest)
        {
            var _userResponse = new UserResponse();
            using (var bd = new bdgoldendatesEntities())
            {
                var user = bd.Usuarios.Where(w => w.id_user == _userRequest.id_user).FirstOrDefault();

                user.username = _userRequest.username;
                user.password = _userRequest.password;
                user.nombre = _userRequest.nombre;
                user.apelllido = _userRequest.apellido;
                user.birthday = _userRequest.birthday;
                //user.birthday = DateTime.Now;
                user.IsActive = true;
                user.FechaRegistro = DateTime.Now;

                bd.Entry(user).State = System.Data.Entity.EntityState.Modified;
                bd.SaveChanges();
                _userResponse.id_user = user.id_user;
            }

            return Json(_userResponse, JsonRequestBehavior.DenyGet);
        }

        //LISTAR/MOSTRAR
        [HttpGet]
        public JsonResult ListUsers()
        {
            //var _userResponse = new UserResponse();
            var user = new List<Usuarios>();
            using (var bd = new bdgoldendatesEntities())
            {
                user = bd.Usuarios.ToList();
            }

            return Json(user, JsonRequestBehavior.AllowGet);
        }

        //CONSULTAR
        [HttpGet]
        public JsonResult GetUser(int userid)
        {
            var user = new Usuarios();
            using (var bd = new bdgoldendatesEntities())
            {
                user = bd.Usuarios.Where(w => w.id_user == userid).FirstOrDefault();
            }

            return Json(user, JsonRequestBehavior.AllowGet);
        }

        //ELIMINAR
        [HttpPost]
        public JsonResult DeleteUser(int id_user)
        {
            bool result = false;
            using (var bd = new bdgoldendatesEntities())
            {
                try
                {
                    var user = bd.Usuarios.Where(w => w.id_user == id_user).FirstOrDefault();
                    bd.Entry(user).State = System.Data.Entity.EntityState.Deleted;
                    bd.SaveChanges();
                    result = true;

                }
                catch (Exception)
                {

                    result = false;
                }

                ////Borrado Logico
                //if (user != null)
                //{
                //    user.isActive = false;
                //    result = true;
                //}
                //else
                //{
                //    result = false;
                //}
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}