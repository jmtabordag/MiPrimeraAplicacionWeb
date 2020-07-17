using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using MiPrimeraAplicacionWeb.Models;

namespace MiPrimeraAplicacionWeb.Controllers
{
    public class InfoPersonalController : Controller
    {
        // GET: InfoPersonal
        public ActionResult Index()
        {
            //Crear una lista para este caso, una lista de personas
            List<PersonaCLS> ListaPersonas = null;

            //Llamar la consulta a través de LINQ TO, e inyectar la data a la lista que se creo anteriormente.
            using(var bd = new BDPasajeEntities())
            {
                ListaPersonas = (from a in bd.Persona
                                 select new PersonaCLS
                                 {
                                     
                                     Nombre=a.nombre,
                                     Apellido=a.apellido,
                                     Cedula=a.cedula,
                                     TipoSangre= a.TipoSangre,
                                     Celular=a.Celular

                                 }).ToList();
            }
            ViewBag.Martin = "HOLA MI NOMBRE ES JUAN MARTÍN TABORDA GARCÍA";

            return View(ListaPersonas);
        }

        public SelectList ObtenerRH()
        {
            List<SelectListItem> ListRH = new List<SelectListItem>();

            ListRH.Add(new SelectListItem() { Text = "O+", Value = "O+" });
            ListRH.Add(new SelectListItem() { Text = "O-", Value = "O-" });
            ListRH.Add(new SelectListItem() { Text = "AB+", Value = "AB+" });
            ListRH.Add(new SelectListItem() { Text = "AB-", Value = "AB-" });


            SelectList RH = new SelectList(ListRH, "Value", "Text");

            return RH;

        }

        public ActionResult Crear()
        {
            
            //ViewBag.ListRH = new SelectList(ObtenerRH(), "Value", "Text");
            ViewBag.ListRH = ObtenerRH();



            return View();
        }

      

        [HttpPost]
        public ActionResult Crear(PersonaCLS Persona)
        {
            if (!ModelState.IsValid)
            {
                return View(Persona);
            }
            else
            {
                using (var bd = new BDPasajeEntities())
                {
                    Persona OnPersona = new Persona();

                    //Consulte cual es el id mayor
                    int valorMaximo = 0;
                    try
                    {
                        using (var consulta = new BDPasajeEntities())
                        {
                            valorMaximo = consulta.Persona.Select(x => x.idPersona).Max();
                        }
                    }
                    catch (System.InvalidOperationException)
                    {
                        valorMaximo = 0;
                    }

                    if (valorMaximo == null || valorMaximo==0)
                    {
                        valorMaximo = 1;

                        OnPersona.idPersona = (valorMaximo );
                 
                    }
                    else
                    {
                        OnPersona.idPersona = (valorMaximo + 1);
                
                    }

                    OnPersona.nombre = Persona.Nombre;
                    OnPersona.apellido = Persona.Apellido;
                    OnPersona.cedula = Persona.Cedula;
                    OnPersona.Celular = Persona.Celular;
                    OnPersona.TipoSangre = Persona.TipoSangre;

                    bd.Persona.Add(OnPersona);


                    bd.SaveChanges();



                }

                return RedirectToAction("Index");
            }
           
        }

       

    
    }
}