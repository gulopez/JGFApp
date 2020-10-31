using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Models
{
    public class PreInscripcion
    {
        public Guid Id { get; set; }
        public string Comentarios { get; set; }
        public DateTime FechaPreInscripcion { get; set; }
        public DateTime Actualizado { get; set; }
        public Guid IdAlumno { get; set; }
        public Alumno Alumno { get; set; }
        public Guid IdPeriodoEscolar { get; set; }
        public PeriodoEscolar PeriodoEscolar { get; set; }
        public Guid IdGradoEscolar { get; set; }
        public GradoEscolar GradoEscolar { get; set; }
        public Guid IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public Guid IdEstado { get; set; }
        public Estado Estado { get; set; }
        public Guid IdRepresentante { get; set; }
        public Representante Representante { get; set; }
    }
}
