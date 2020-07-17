using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiPrimeraAplicacionWeb.Models
{
    public class EmpleadoCLS
    {

        [Display(Name ="Id Empleado")]
        [Required]
        public int iidEmpleado { get; set; }



        [Display(Name = "Nombre")]
        [Required]
        [StringLength(100,ErrorMessage ="Longitud no permitida")]
        public string nombre { get; set; }




        [Display(Name = "Apellido Paterno")]
        [Required]
        [StringLength(200, ErrorMessage = "Longitud no permitida")]
        public string apPaterno { get; set; }



        [Display(Name = "Apellido Materno")]
        [Required]
        [StringLength(200, ErrorMessage = "Longitud no permitida")]
        public string apMaterno { get; set; }




        [Display(Name = "Fecha de Contrato")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fechaContrato { get; set; }



        [Display(Name = "Tipo Usuario")]
        [Required]
        public int iidtipoUsuario { get; set; }



        [Display(Name = "Tipo Contrato")]
        [Required]
        public int iidtipoContrato { get; set; }
        


        [Display(Name = "Sexo")]
        [Required]
      
        public int iidtipoSexo { get; set; }

        public int bhabilitado { get; set; }


        [Required]
        [Range(0,90000000,ErrorMessage ="Solo se pemite una cuantia hasta $90.000.000")]
        [Display(Name ="Sueldo Empleado")]
        public decimal sueldo { get; set; }



        //Atributos adicionales

        [Display(Name = "Tipo de Usuario")]
        public string nombreTipoUsuario { get; set; }


        [Display(Name = "Tipo de Contrato")]
        public string nombreTipoContrato { get; set; }

    }
}