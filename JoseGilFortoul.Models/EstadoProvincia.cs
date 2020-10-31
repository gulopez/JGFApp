using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Models
{
    public class EstadoProvincia
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Debe ingresar un estado")]
        [Display(Name = "Estado")]
        public string Nombre { get; set; }
        public string Abbreviation { get; set; }
        public Guid IdPais { get; set; }
        public Pais Pais { get; set; } = new Pais();
    }
}
