using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiPrimeraAplicacionWeb.Models
{
    public class ClienteCLS
    {
        [Display(Name ="Id de Cliente")]
        public int iidcliente { get; set; }

        [Display(Name ="Nombre de Cliente")]
        [Required]
        [StringLength(100,ErrorMessage ="Solo se permiten 100 caracteres")]
        public string nombre { get; set; }


       

        [Display(Name ="Apellido Materno")]
        [Required]
        [StringLength(150, ErrorMessage = "Solo se permiten 150 caracteres")]
        public string apmaterno { get; set; }


        [Display(Name = "Apellido Paterno")]
        [Required]
        [StringLength(150, ErrorMessage = "Solo se permiten 150 caracteres")]
        public string appaterno{ get; set; }


        [Display(Name ="Correo Electronico")]
        [Required]
        [StringLength(200, ErrorMessage = "Solo se permiten 200 caracteres")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }


        [Display(Name="Dirección")]
        [DataType(DataType.MultilineText)]
        [Required]
        [StringLength(200, ErrorMessage = "Solo se permiten 200 caracteres")]
        public string direccion { get; set;}

        [Display(Name = "Sexo")]
        [Required]
        public int sexo { get; set; }

        [Display(Name = "Telefono Fijo")]
        [Required]
        [StringLength(10, ErrorMessage = "Solo se permiten 10 caracteres")]
        public string telefonofijo { get; set; }

        [Display(Name = "Telefono Celular")]
        [Required]
        [StringLength(10, ErrorMessage = "Solo se permiten 10 caracteres")]
        public string telefonocelular { get; set; }

    }
}