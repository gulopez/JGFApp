using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Models
{
    public class Pais
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Debe ingresar un país")]
        [Display(Name = "País")]
        public string Nombre { get; set; }
        public string TwoLetterIsoCode { get; set; }
        public string ThreeLetterIsoCode { get; set; }
    }
}
