using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiPrimeraAplicacionWeb.Models
{
    public class ViajeCLS
    {
        [Display(Name ="Id viaje")]
        public int iidViaje { get; set; }
        [Display(Name = "Lugar Origen")]
        [Required]
        public int iidlugarOrigen{ get; set; }
        [Display(Name = "Lugar Destino")]
        [Required]

        public int iidLugarDestino { get; set; }
        [Display(Name = "Precio")]
        [Required]
        public double precio { get; set; }
        [Display(Name = "Fecha Viaje")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fechaViaje { get; set; }
        [Display(Name = "Número Asientos Disponibles")]
        [Required]
        public int numeroAsientosDisponibles { get; set; }

        //Propiedades Adicionales
        [Display(Name = "Lugar de Origen")]
        public string nombreLugarOrigen { get; set; }
        [Display(Name = "Lugar de Destino")]
        public string nombreLugarDestino { get; set; }
        [Display(Name = "Nombre del bus")]
        public string nombreBus { get; set; }

    }
}