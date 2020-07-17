using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiPrimeraAplicacionWeb.Models
{
    public class MarcaCLS
    {
      
        [Display(Name ="Id Marca")]
        public int iidmarca { get; set; }
        [Display(Name ="Nombre de Marca")]
        [Required]
        [StringLength(100,ErrorMessage ="La longitud permitida es de 100 caracteres")]
        public string nombre { get; set; }
        [Display(Name = "Descripción de Marca")]
        [Required]
        [StringLength(200,ErrorMessage ="La longitud permitida es de 200 caracteres")]
        public string descripcion { get; set; }
        
        public int bhabilitado { get; set; }
    }
}