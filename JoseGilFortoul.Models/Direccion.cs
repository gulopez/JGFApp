using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Models
{
    public class Direccion
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Debe ingresar una ciudad")]
        [Display(Name = "Ciudad")]
        public string Ciudad { get; set; }
        [Required(ErrorMessage = "Debe ingresar una avenida/calle")]
        [Display(Name = "Avenida/Calle")]
        public string Linea1 { get; set; }
        [Required(ErrorMessage = "Debe ingresar una casa/apartamento")]
        [Display(Name = "Casa/Apartamento")]
        public string Linea2 { get; set; }
        [Required(ErrorMessage = "Debe ingresar un sector")]
        [Display(Name = "Sector")]
        public string Sector { get; set; }
        [Required(ErrorMessage = "Debe ingresar una urbanización")]
        [Display(Name = "Urbanización")]
        public string Urbanizacion { get; set; }
        [Required(ErrorMessage = "Debe ingresar un código postal")]
        [Display(Name = "Código Postal")]
        public string CodigoPostal { get; set; }
        public DateTime FechaModificacion { get; set; }
        public Guid IdEstadoProvincia { get; set; }
        public EstadoProvincia EstadoProvincia { get; set; } = new EstadoProvincia();
    }
}
