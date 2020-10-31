using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Models
{
    public class PagoMaster
    {
        public Guid Id { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; }
        public Guid IdAlumno { get; set; }
        public Alumno Alumno { get; set; }
        public Guid IdPeriodoEscolar { get; set; }
        public PeriodoEscolar PeriodoEscolar { get; set; }
        public Guid IdConceptoPago { get; set; }
        public ConceptoPago ConceptoPago { get; set; }
        public Guid? IdMesEscolar { get; set; }
        public MesEscolar MesEscolar { get; set; }
    }
}
