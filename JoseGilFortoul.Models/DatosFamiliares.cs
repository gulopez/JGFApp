using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Models
{
    public class DatosFamiliares
    {
        public Guid Id { get; set; }
        [Display(Name = "Religión que profesan")]
        public string Religion { get; set; }

        [Display(Name = "Hermanos en la institución")]
        public string Hermanos { get; set; }

        [Display(Name = "Ingresos mensuales del grupo familiar")]
        public string Ingresos { get; set; }

        [Display(Name = "Cuantas personas conforman el grupo familiar")]
        public string Personas { get; set; }

        [Display(Name = "Estado civil de los padres")]
        public string EstadoCivil { get; set; }
    }
}
