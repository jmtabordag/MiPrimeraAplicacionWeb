using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiPrimeraAplicacionWeb.Models;


namespace MiPrimeraAplicacionWeb.Controllers
{
    public class ViajeController : Controller
    {
        // GET: Viaje
        public ActionResult Index()
        {
            List<ViajeCLS> ListaViajes = null;

            using (var bd = new BDPasajeEntities())
            {
                ListaViajes = (from viaje in bd.Viaje
                               join lugarOrigen in bd.Lugar on viaje.IIDLUGARORIGEN equals(lugarOrigen.IIDLUGAR)
                               join lugarDestino in bd.Lugar on viaje.IIDLUGARDESTINO equals(lugarDestino.IIDLUGAR)
                               join bus in bd.Bus on viaje.IIDBUS equals(bus.IIDBUS)

                               select new ViajeCLS
                               {
                                   iidViaje = viaje.IIDVIAJE,
                                   nombreBus= bus.PLACA,
                                   nombreLugarOrigen = lugarOrigen.NOMBRE,
                                   nombreLugarDestino = lugarDestino.NOMBRE,


                               }).ToList();
            }
                return View(ListaViajes);
        }
    }
}