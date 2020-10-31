using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Models
{
    public class SolicitudCupo
    {
        public Guid Id { get; set; }
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
        [Required(ErrorMessage = "Debe seleccionar un sexo")]
        [Display(Name = "Sexo")]
        public string Sexo { get; set; }
        [Required(ErrorMessage = "Debe ingresar una fecha de nacimiento")]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaDeNacimiento { get; set; }
        [Required(ErrorMessage = "Debe ingresar un teléfono")]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }
        [Display(Name = "Teléfono Adicional")]
        public string TelefonoAdicional { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid? IdAlumno { get; set; }
        public Guid IdPeriodoEscolar { get; set; }
        public PeriodoEscolar PeriodoEscolar { get; set; }
        public Guid IdGradoEscolar { get; set; }
        public GradoEscolar GradoEscolar { get; set; }
        public Guid IdEstado { get; set; }
        public Estado Estado { get; set; }
    }
}
