using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiPrimeraAplicacionWeb.Models;

namespace MiPrimeraAplicacionWeb.Controllers
{
    public class sucursalController : Controller
    {
        // GET: sucursal
        public ActionResult Index()
        {
            List<SucursalCLS> ListaSucursales = null;

            using (var _DbContext = new BDPasajeEntities())
            {
                ListaSucursales = (from a in _DbContext.Sucursal
                                   where a.BHABILITADO==1
                                   select new SucursalCLS
                                   {

                                       iidsucursal=a.IIDSUCURSAL,
                                       nombre=a.NOMBRE,
                                       telefono=a.TELEFONO,
                                       direccion=a.DIRECCION,
                                       email=a.EMAIL,
                                       fechaapertura=(DateTime)a.FECHAAPERTURA

                                       




                                   }).ToList();

            }

            return View(ListaSucursales);
        }

        public ActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(SucursalCLS recibosucursal)
        {

            if (!ModelState.IsValid)
            {
                return View(recibosucursal);
            }
            else
            {

                using (var bd = new BDPasajeEntities()) {

                    Sucursal onSucursal = new Sucursal();
                    onSucursal.NOMBRE = recibosucursal.nombre;
                    onSucursal.TELEFONO = recibosucursal.telefono;
                    onSucursal.DIRECCION = recibosucursal.direccion;
                    onSucursal.EMAIL = recibosucursal.email;
                    onSucursal.FECHAAPERTURA = recibosucursal.fechaapertura;
                    onSucursal.BHABILITADO = 1;

                    bd.Sucursal.Add(onSucursal);
                    bd.SaveChanges();
                }
             

            }
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            SucursalCLS Osucursal = new SucursalCLS();
            using (var bd = new BDPasajeEntities())
            {
                Sucursal sucursal = bd.Sucursal.Where(p => p.IIDSUCURSAL.Equals(id)).First();
                Osucursal.iidsucursal = sucursal.IIDSUCURSAL;
                Osucursal.nombre = sucursal.NOMBRE;
                Osucursal.telefono = sucursal.TELEFONO;
                Osucursal.fechaapertura = (DateTime) sucursal.FECHAAPERTURA;
                Osucursal.email = sucursal.EMAIL;
                Osucursal.direccion = sucursal.DIRECCION;
            }
           

                return View(Osucursal);

        }

        [HttpPost]
        public ActionResult Editar(SucursalCLS recibosucursal)
        {
            if (!ModelState.IsValid)
            {
                return View(recibosucursal);
            }
            else
            {

                using (var bd = new BDPasajeEntities())
                {

                    Sucursal onSucursal = new Sucursal();
                    onSucursal.NOMBRE = recibosucursal.nombre;
                    onSucursal.TELEFONO = recibosucursal.telefono;
                    onSucursal.DIRECCION = recibosucursal.direccion;
                    onSucursal.EMAIL = recibosucursal.email;
                    onSucursal.FECHAAPERTURA = recibosucursal.fechaapertura;
                    onSucursal.BHABILITADO = 1;

                    bd.Sucursal.Add(onSucursal);
                    bd.SaveChanges();
                }


            }
            return RedirectToAction("Index");

        }
    }
}