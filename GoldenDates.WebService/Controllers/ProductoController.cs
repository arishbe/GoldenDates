using GoldenDates.WebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoldenDates.WebService.Controllers
{
 
        public class ProductoController : Controller
        {
            [HttpPost]
            public JsonResult AddItem(ProductoRequest _ProductoRequest)
            {
                var _ProductoResponse = new ProductoResponse();
                using (var bd = new bdgoldendatesEntities())
                {
                    var item = new Productos();
                    item.description = _ProductoRequest.description;
                    item.cantidad = _ProductoRequest.cantidad;
                    item.stockmin = _ProductoRequest.stockmin;
                    item.stockmax = _ProductoRequest.stockmax;
                    item.FechaRegistro = DateTime.Now;



                    bd.Entry(item).State = System.Data.Entity.EntityState.Added;
                    bd.SaveChanges();
                    _ProductoResponse.id_prod = item.id_prod;
                }

                return Json(_ProductoResponse, JsonRequestBehavior.DenyGet);
            }

            //EDITAR
            [HttpPost]
            public JsonResult EditItems(ProductoRequest _itemRequest)
            {
                var _itemResponse = new ProductoResponse();
                using (var bd = new bdgoldendatesEntities())
                {
                    var item = bd.Productos.Where(w => w.id_prod == _itemRequest.id_prod).FirstOrDefault();

                    item.description = _itemRequest.description;
                    item.cantidad = _itemRequest.cantidad;
                    item.stockmin = _itemRequest.stockmin;
                    item.stockmax = _itemRequest.stockmax;

                    bd.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    bd.SaveChanges();
                    _itemResponse.id_prod = item.id_prod;
                }

                return Json(_itemResponse, JsonRequestBehavior.DenyGet);
            }

            //LISTAR/MOSTRAR
            [HttpGet]
            public JsonResult ListItems()
            {
                //var _userResponse = new UserResponse();
                var items = new List<ProductoResponse>();
                using (var bd = new bdgoldendatesEntities())
                {
                    //items = bd.Items.ToList();
                    var ListItem = bd.Productos.ToList();
                    foreach (var item in ListItem)
                    {
                        items.Add(new ProductoResponse()
                        {
                            description = item.description,
                            cantidad = (int)item.cantidad,
                            stockmin = (int)item.stockmin,
                            stockmax = (int)item.stockmax,
                            id_prod = item.id_prod
                        });
                    }

                }

                return Json(items, JsonRequestBehavior.AllowGet);
            }

            //CONSULTAR
            [HttpGet]
            public JsonResult GetItem(int itemid)
            {
                var item = new Productos();
                using (var bd = new bdgoldendatesEntities())
                {
                    item = bd.Productos.Where(w => w.id_prod == itemid).FirstOrDefault();
                }
                return Json(item, JsonRequestBehavior.AllowGet);
            }

            //ELIMINAR
            [HttpPost]
            public JsonResult DeleteItem(int itemid)
            {
                bool result = false;
                using (var bd = new bdgoldendatesEntities())
                {
                    try
                    {
                        var item = bd.Productos.Where(w => w.id_prod == itemid).FirstOrDefault();
                        bd.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                        bd.SaveChanges();
                        result = true;
                    }
                    catch (Exception)
                    {
                        result = false;
                    }


                    //    //Borrado Logico
                    //    if (users != null)
                    //    {
                    //        users.isActive = false;
                    //        result = true;
                    //    }
                    //    else
                    //    {
                    //        result = false;
                    //    }
                    //}

                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
        }
    }