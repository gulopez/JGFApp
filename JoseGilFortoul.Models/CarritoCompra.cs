using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Models
{
    public class CarritoCompra
    {
        public Guid Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal MontoPagar { get; set; }
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
