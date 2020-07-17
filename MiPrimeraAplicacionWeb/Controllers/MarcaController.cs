using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiPrimeraAplicacionWeb.Models;

namespace MiPrimeraAplicacionWeb.Controllers
{
    public class MarcaController : Controller
    {
        // GET: Marca
        public ActionResult Index()
        {
            List<MarcaCLS> listaMarca = null;
            using (var bd= new BDPasajeEntities())
            {
                listaMarca = (from recorrer in bd.Marca
                                             select new MarcaCLS
                                             {
                                                 
                                               
                                                iidmarca = recorrer.IIDMARCA,
                                                 nombre = recorrer.NOMBRE,
                                                 descripcion = recorrer.DESCRIPCION

                                             }).ToList();
            }
            return View(listaMarca);
        }

        //Este crea la vista

        public ActionResult Adicionar()
        {
            return View();
        }






        //ESte hace la Inserción
        [HttpPost]
        public ActionResult Adicionar(MarcaCLS reciboMarca)
        {

            if (!ModelState.IsValid)
            {
                return View(reciboMarca);
            }
            else
            {
                using(var bd= new BDPasajeEntities())
                {
                    Marca oMarca = new Marca();
                    oMarca.NOMBRE = reciboMarca.nombre;
                    oMarca.DESCRIPCION = reciboMarca.descripcion;
                    oMarca.BHABILITADO = 1;

                    bd.Marca.Add(oMarca);
                    bd.SaveChanges();
                }
                

            }
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            MarcaCLS oMarcaCLS = new MarcaCLS();
            using (var bd = new BDPasajeEntities())
            {
                Marca oMarca = bd.Marca.Where(p => p.IIDMARCA.Equals(id)).First();
                oMarcaCLS.iidmarca = oMarca.IIDMARCA;
                oMarcaCLS.nombre = oMarca.NOMBRE;
                oMarcaCLS.descripcion = oMarca.DESCRIPCION;
            }

            return View(oMarcaCLS);
        }
    }
}