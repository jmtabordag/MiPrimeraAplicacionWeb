using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiPrimeraAplicacionWeb.Models;


namespace MiPrimeraAplicacionWeb.Controllers
{
    public class BusController : Controller
    {
        List<SelectListItem> ListTipoBus = new List<SelectListItem>();
      
        

        
        // GET: Buse
        public ActionResult Index()
        {

            List<BusCLS> ListaBuses = null;

            using(var bd = new BDPasajeEntities())
            {
                ListaBuses = (from bus in bd.Bus
                              join tipobus in bd.TipoBus on bus.IIDTIPOBUS equals(tipobus.IIDTIPOBUS)
                              join sucursal in bd.Sucursal on bus.IIDSUCURSAL equals(sucursal.IIDSUCURSAL)
                              join modelo in bd.Modelo on bus.IIDMODELO equals(modelo.IIDMODELO)
                              select new BusCLS
                              {
                                 Placa=bus.PLACA,
                                 fechaCompra =(DateTime)bus.FECHACOMPRA,
                                 Descripcion = bus.DESCRIPCION,
                                 TipoBus=tipobus.NOMBRE,
                                 Sucursal=sucursal.NOMBRE,
                                 descModelo = modelo.NOMBRE

                                 

                              }).ToList();
                              
                                 

                            

            }

            return View(ListaBuses);
        }

        //LLevar al formulario
        public ActionResult Adicionar()
        {
            obtenerTipoBus();
            SelectList tipobus = new SelectList(ListTipoBus,"value","text");
            ViewBag.tipobus = tipobus;
            return View();

        }

        //Mandar los parametros del formulario
        [HttpPost]
        public ActionResult Adicionar(BusCLS datos)
        {
          

            return RedirectToAction("index");

        }

        public void obtenerTipoBus()
        {
            using (var bd = new BDPasajeEntities())
            {
                ListTipoBus = (from a in bd.TipoBus
                               select new SelectListItem
                               {
                                   Value = a.IIDTIPOBUS.ToString(),
                                   Text = a.NOMBRE
                               }).ToList();
            }

            //ListTipoBus.Add(new SelectListItem { Text = "Masculino", Value = "1" });
            //ListTipoBus.Add(new SelectListItem { Text = "Femenino", Value = "2" });


        }
    }
}