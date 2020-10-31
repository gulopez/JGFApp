using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Models
{
    public class PagoDetallado
    {
        public Guid Id { get; set; }
        public Guid? IdPagoMaster { get; set; }
        public PagoMaster PagoMaster { get; set; }
        public Guid IdFormaPago { get; set; }
        public FormaPago FormaPago { get; set; }
        public Guid IdRepresentante { get; set; }
        public Representante Representante { get; set; }
        public string Referencia { get; set; }
        [DisplayFormat(DataFormatString = "{0:D}", ApplyFormatInEditMode = true)]
        public decimal Monto { get; set; }
    }
}
