using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiPrimeraAplicacionWeb.Models
{
    public class Automovil
    {
        public string marca { get; set; }
        public int numero_chasis { get; set; }
        public DateTime fecha_lanzamiento { get; set; }
    }
}