using MiPrimeraAplicacionWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace MiPrimeraAplicacionWeb.Controllers
{
    public class AutomovilController : Controller
    {
        public static int resultado;
        Suma sum = new Suma();
        // GET: Automovil
        public ActionResult Index()
        {
            Automovil au1 = new Automovil();
            au1.marca = "Chevrolet Spark";
            au1.numero_chasis = 1234;
            au1.fecha_lanzamiento = new DateTime(2020, 1, 15);


            return View(au1);

        }

        public ActionResult Sumar()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Sumar(Suma param)
        {
            if (!ModelState.IsValid)
            {
                return View(param);
            }
            else
            {
                
                sum.a = param.a;
                sum.b = param.b;
                sum.resultado = param.a + param.b;
                resultado = param.a + param.b;

            }


            //return View();
            resultadooperacion(resultado);
            return RedirectToAction("ResultadoSuma");
        }

        public ActionResult ResultadoSuma()
        {
            int a = resultadooperacion(resultado);
            if (a == 0)
            {
                return RedirectToAction("Sumar");
            }
            else
            {
                return View(resultado);
            }


        }

        public int resultadooperacion(int a)
        {
            resultado= a;
            return resultado;
        }


    }
}