using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Models
{
    public class Alumno
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
        [Display(Name = "Cédula")]
        public string CedulaAlumno { get; set; }
        [Display(Name = "Carnet de Estudiante")]
        public string CarnetEstudiante { get; set; }
        [Required(ErrorMessage = "Debe ingresar un lugar de nacimiento")]
        [Display(Name = "Lugar de Nacimiento")]
        public string LugardeNacimiento { get; set; }
        [Required(ErrorMessage = "Debe ingresar un estado de nacimiento")]
        [Display(Name = "Estado de Nacimiento")]
        public string EstadoDeNacimiento { get; set; }
        [Required(ErrorMessage = "Debe ingresar un país de nacimiento")]
        [Display(Name = "País de Nacimiento")]
        public string PaisDeNacimiento { get; set; }
        [Required(ErrorMessage = "Debe ingresar una fecha de nacimiento")]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaDeNacimiento { get; set; }
        [Required(ErrorMessage = "Debe ingresar un teléfono")]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }
        [Display(Name = "Teléfono Adicional")]
        public string TelefonoAdicional { get; set; }
        [Required(ErrorMessage = "Debe ingresar un correo")]
        [Display(Name = "Correo Electrónico")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Debe ingresar una dirección de correo valida")]
        public string Email { get; set; }
        public string Comentarios { get; set; }
        public string Escolaridad { get; set; }
        public string Materias { get; set; }
        [Display(Name = "Plantel de Procedencia")]
        public string PlantelProcedencia { get; set; }
        public Guid IdRepresentante { get; set; }
        public Representante Representante { get; set; } = new Representante();
        public Guid IdPadre { get; set; }
        public Representante Padre { get; set; } = new Representante();
        public Guid IdMadre { get; set; }
        public Representante Madre { get; set; } = new Representante();
        public Guid IdDireccion { get; set; }
        public Direccion Direccion { get; set; } = new Direccion();
        public Guid IdDatosMedicos { get; set; }
        public DatosMedicos DatosMedicos { get; set; } = new DatosMedicos();
        public Guid IdDatosFamiliares { get; set; }
        public DatosFamiliares DatosFamiliares { get; set; } = new DatosFamiliares();
        public Guid IdPeriodoEscolar { get; set; }
        public PeriodoEscolar PeriodoEscolar { get; set; } = new PeriodoEscolar();
        public Guid IdGradoEscolar { get; set; }
        public GradoEscolar GradoEscolar { get; set; } = new GradoEscolar();
    }
}
