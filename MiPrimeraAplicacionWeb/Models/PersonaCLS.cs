using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MiPrimeraAplicacionWeb.Models
{
    public class PersonaCLS
    {
        [Key, Column(Order = 0)]
        public int IdPersona { get; set; }

        [Display(Name ="Nombre Completo")]
        [StringLength(40,ErrorMessage ="Ha sobrepado el limite de caracteres permitidos")]
        public string Nombre { get; set; }
        [Display(Name ="Apellidos")]
        [StringLength(79, ErrorMessage = "Ha sobrepado el limite de caracteres permitidos")]
        public string Apellido { get; set; }
        [Display(Name ="Cedúla de Ciudadania")]
        [StringLength(79, ErrorMessage = "Solo se permiten 10 caracteres")]
        
        public string Cedula { get; set; }
        [Display(Name ="Tipo de Sangre RH")]
        [StringLength(3, ErrorMessage = "Solo se permiten 3 caracteres")]
        public string TipoSangre { get; set; }
        public string Celular { get; set; }
    }
}