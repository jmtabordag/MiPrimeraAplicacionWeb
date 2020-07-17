using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiPrimeraAplicacionWeb.Models
{
    public class SucursalCLS
    {
        [Display(Name ="Id Sucursal")]
        public int iidsucursal { get; set; }
        [Display(Name = "Nombre Sucursal")]
        [Required]
        [StringLength(100,ErrorMessage ="Solo se permiten 100 caracteres")]
        public string nombre { get; set; }
        [Display(Name = "Dirección")]
        [Required]
        [StringLength(200, ErrorMessage = "Solo se permiten 200 caracteres")]
        public string direccion { get; set; }
        [Display(Name ="Télefono")]
        [Required]
        [StringLength(10, ErrorMessage = "Solo se permiten 10 caracteres")]
        public string telefono { get; set; }
        [Display(Name = "Correo Electronico")]
        [Required]
        [StringLength(100, ErrorMessage = "Solo se permiten 100 caracteres")]
        public string email { get; set; }
        [Display(Name = "Fecha de Apertura")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime fechaapertura { get; set; }
        public int bhabilitado { get; set; }

    }
}