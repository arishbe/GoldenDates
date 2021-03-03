using GoldenDates.WebServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoldenDates.WebServices.Controllers
{
    public class ClienteController : Controller
    {
        //AGREGAR CLIENTE
        [HttpPost]
        public JsonResult AddClient(ClientRequest _clientRequest)
        {
            var _clientResponse = new ClientResponse();
            using (var bd = new bdgoldendatesEntities())
            {
                var cli = new Clientes();
       
                cli.nombre = _clientRequest.nombre;
                cli.apellido = _clientRequest.apellido;
                cli.telefono = _clientRequest.telefono;
                cli.direccion = _clientRequest.direccion;
               
                //user.birthday= DateTime.Now;
          

                bd.Entry(cli).State = System.Data.Entity.EntityState.Added;
                bd.SaveChanges();
                _clientResponse.id_cli = cli.id_cli;
            }

            return Json(_clientResponse, JsonRequestBehavior.DenyGet);
        }

        //EDITAR
        [HttpPost]
        public JsonResult EditClient(ClientRequest _clientRequest)
        {
            var _clientResponse = new ClientRequest();
            using (var bd = new bdgoldendatesEntities())
            {
                var cli = bd.Clientes.Where(w => w.id_cli == _clientRequest.id_cli).FirstOrDefault();

                cli.nombre = _clientRequest.nombre;
                cli.apellido = _clientRequest.apellido;
                cli.telefono = _clientRequest.telefono;
                cli.direccion = _clientRequest.direccion;

                

                bd.Entry(cli).State = System.Data.Entity.EntityState.Modified;
                bd.SaveChanges();
                _clientResponse.id_cli = cli.id_cli;
            }

            return Json(_clientResponse, JsonRequestBehavior.DenyGet);
        }

        //LISTAR/MOSTRAR
        [HttpGet]
        public JsonResult ListClient()
        {
            //var _userResponse = new UserResponse();
            var cli = new List<Clientes>();
            using (var bd = new bdgoldendatesEntities())
            {
                cli = bd.Clientes.ToList();
            }

            return Json(cli, JsonRequestBehavior.AllowGet);
        }

        //CONSULTAR
        [HttpGet]
        public JsonResult GetClient(int idcli)
        {
            var cli = new Clientes();
            using (var bd = new bdgoldendatesEntities())
            {
                cli = bd.Clientes.Where(w => w.id_cli == idcli).FirstOrDefault();
            }

            return Json(cli, JsonRequestBehavior.AllowGet);
        }

        //ELIMINAR
        [HttpPost]
        public JsonResult DeleteClient(int idcli)
        {
            bool result = false;
            using (var bd = new bdgoldendatesEntities())
            {
                try
                {
                    var cli = bd.Usuarios.Where(w => w.id_user == idcli).FirstOrDefault();
                    bd.Entry(cli).State = System.Data.Entity.EntityState.Deleted;
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