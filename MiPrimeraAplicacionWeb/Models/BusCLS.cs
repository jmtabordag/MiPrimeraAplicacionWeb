using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiPrimeraAplicacionWeb.Models
{
    public class BusCLS
    {
        [Display(Name = "Id Tipo Bus")]
        public int idTipobus { get; set; }
        [Display(Name = "Placa de Vehiculo")]
        public string Placa { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fechaCompra { get; set; }

        public int IdModelo { get; set; }

        [Display(Name = "Categorización del Bus")]
        public string Descripcion { get; set; }
        [Display(Name = "Marca del Bus")]
        public int idMarca { get; set; }


        // otros atributos

        [Display(Name = "Sucursal")]
        public string Sucursal { get; set; }

        [Display(Name = "Tipo de Bus")]
        public string TipoBus { get; set; }

        [Display(Name = "Modelo")]
        public string descModelo { get; set; }
        [Display(Name = "Marca del bus")]
        public string Marca { get; set; }

    }
}