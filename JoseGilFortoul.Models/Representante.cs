using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Models
{
    public class Representante
    {
        public Guid Id { get; set; }
        public string Parentesco { get; set; }
        [Required(ErrorMessage = "Debe ingresar un nombre")]
        [Display(Name = "Primer Nombre")]
        public string PrimerNombre { get; set; }
        [Display(Name = "Segundo Nombre")]
        public string SegundoNombre { get; set; }
        [Required(ErrorMessage = "Debe ingresar un apellido")]
        [Display(Name = "Primer Apellido")]
        public string PrimerApellido { get; set; }
        [Display(Name = "Segundo Apellido")]
        public string SegundoApellido { get; set; }
        [Required(ErrorMessage = "Debe ingresar una cédula")]
        [Display(Name = "Cédula")]
        public string CedulaRepresentante { get; set; }
        [Required(ErrorMessage = "Debe ingresar un teléfono")]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }
        [Display(Name = "Teléfono Adicional")]
        public string TelefonoAdicional { get; set; }
        [Required(ErrorMessage = "Debe ingresar una ocupación")]
        [Display(Name = "Ocupación")]
        public string Ocupacion { get; set; }
        [Required(ErrorMessage = "Debe ingresar un correo electrónico")]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Debe ingresar una edad")]
        [Display(Name = "Edad")]
        public int Edad { get; set; }
        [Required(ErrorMessage = "Debe ingresar una profesión")]
        [Display(Name = "Profesión")]
        public string Profesion { get; set; }
        [Required(ErrorMessage = "Debe ingresar una empresa donde trabaja")]
        [Display(Name = "Empresa donde Trabaja")]
        public string EmpresaTrabaja { get; set; }
        public Guid IdDireccion { get; set; }
        public Direccion Direccion { get; set; } = new Direccion();
    }
}
