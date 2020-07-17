using MiPrimeraAplicacionWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiPrimeraAplicacionWeb.Controllers
{
    public class LugarController : Controller
    {
        List<SelectListItem> listaNombres = new List<SelectListItem>();
        // GET: Lugar
        public ActionResult Index()
        {
            List<LugarCLS> ListLugares = null;
            using (var bd = new BDPasajeEntities())
            {
                ListLugares = (from item in bd.Lugar
                               select new LugarCLS()
                               {
                                   iidlugar = item.IIDLUGAR,
                                   nombre = item.NOMBRE,
                                   descripcion = item.DESCRIPCION,
                                   
                               }).ToList();
            }
                return View(ListLugares);
        }

        public ActionResult Adicionar()
        {
            comboNombre();
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(LugarCLS recibo)
        {
            comboNombre();

            if (!ModelState.IsValid)
            {
                return View(recibo);
            }

            Lugar lugar = new Lugar();
            using(var bd = new BDPasajeEntities())
            {
                lugar.NOMBRE = recibo.nombre;
                lugar.DESCRIPCION = recibo.descripcion;
                lugar.BHABILITADO = 1;

                bd.Lugar.Add(lugar);
                bd.SaveChanges();
                return RedirectToAction("index");
            }
         

            

           
        }

         public ActionResult Editar(int id)
        {
            comboNombre();

            LugarCLS Olugar = new LugarCLS();
          
            using(var bd = new BDPasajeEntities())
            {
               Lugar lg = bd.Lugar.Where(p => p.IIDLUGAR.Equals(id)).First();
                Olugar.iidlugar = lg.IIDLUGAR;
                Olugar.nombre = lg.NOMBRE;
                Olugar.descripcion = lg.DESCRIPCION;

            }
            return View(Olugar);
        }

        public void comboNombre()
        {

            listaNombres.Add(new SelectListItem { Text = "MANIZALES CALDAS", Value = "MANIZALES CALDAS" });
            listaNombres.Add(new SelectListItem { Text = "MEDELLÍN ANTIOQUIA", Value = "MEDELLÍN ANTIOQUIA" });
            listaNombres.Add(new SelectListItem { Text = "CALI VALLE DEL CAUCA", Value = "CALI VALLE DEL CAUCA" });

            SelectList nombres = new SelectList(listaNombres, "value", "text");
            ViewBag.Nombre = nombres;

            
        }
    }
}