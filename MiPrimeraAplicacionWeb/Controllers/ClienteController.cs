using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiPrimeraAplicacionWeb.Models;

namespace MiPrimeraAplicacionWeb.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            string prueba;
            prueba = "JUAN MARTÍN TABORDA GARCÍA";
            ViewBag.Pasar = prueba;
            List<ClienteCLS> ListaClientes = null;

            using (var bd = new BDPasajeEntities())
            {
                ListaClientes = (from a in bd.Cliente
                                 select new ClienteCLS
                                 {
                                     iidcliente=a.IIDCLIENTE,
                                     nombre=a.NOMBRE,
                                     appaterno =a.APPATERNO,
                                     apmaterno = a.APMATERNO,
                                     email =a.EMAIL,
                                     direccion =a.DIRECCION
                                     
                                     

                                 }).ToList();
            }

                return View(ListaClientes);
        }

        List<SelectListItem> listadeSexo;

        public void ObtenerSexo()
        {
            using (var bd = new BDPasajeEntities())
            {
                listadeSexo = (from sexo in bd.Sexo
                               select new SelectListItem
                               {
                                   Text = sexo.NOMBRE,
                                   Value = sexo.IIDSEXO.ToString()

                               }).ToList();

                listadeSexo.Insert(0, new SelectListItem { Text = "--SELECCIONE SEXO--", Value = "" });

                
            }
        }


        public ActionResult Adicionar()
        {
            ObtenerSexo(); // llama al método para poder llenar la lista de sexo o la SelectList
            ViewBag.Sexo = listadeSexo;
            
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(ClienteCLS reciboClientes)
        {
            if (!ModelState.IsValid)
            {
                ObtenerSexo();
                ViewBag.Sexo = listadeSexo;
                return View(reciboClientes);
            }
            return View();
        }
    }

}