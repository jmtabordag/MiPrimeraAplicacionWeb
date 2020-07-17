using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiPrimeraAplicacionWeb.Models
{
    public class LugarCLS
    {
        [Display(Name = "Identificación de Lugar")]
        public int iidlugar { get; set; }
        [Required]
        [Display (Name ="Nombre de la ciudad")]
        public string nombre { get; set; }
        [Required]
        [Display (Name ="Descripción de la ciudad")]
        public string descripcion { get; set; }

        public int bhabilitado { get; set; }
    }
}