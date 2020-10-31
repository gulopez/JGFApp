using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Models
{
    public class DatosMedicos
    {
        public Guid Id { get; set; }
        public bool IsAlergias { get; set; }
        [Display(Name = "Alergías")]
        public string Alergias { get; set; }
        public bool IsServiciosMedicos { get; set; }
        [Display(Name = "Posee Servicios Médicos")]
        public string Servicios { get; set; }
        public bool IsAfeccion { get; set; }
        [Display(Name = "Posee Alguna Afectación de Salud")]
        public string Afeccion { get; set; }
        public bool IsTratamiento { get; set; }
        [Display(Name = "Posee Tratamiento Médico")]
        public string Tratamiento { get; set; }
    }
}
